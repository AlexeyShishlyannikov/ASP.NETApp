﻿using System;
using System.Data.Entity;

using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Controllers.Api
{
    using System.Net;
    using System.Web.Http;

    using AutoMapper;

    using WebApplication1.DTOs;
    using WebApplication1.Models;

    public class MoviesController : ApiController
    {
        
        private ApplicationDbContext _context;

        public MoviesController()
        {
            this._context = new ApplicationDbContext();
        }
        //GET api/movies/
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery =  this._context.Movies
                .Include(c => c.Genre).Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(c => c.Name.Contains(query));
            }

            var moviesDto = moviesQuery.ToList().Select(Mapper.Map<Movie, MovieDTO>);

            return this.Ok(moviesDto);
        }

        //GET /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = this._context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            if (movie == null)
            {
                return this.NotFound();
            }

            return this.Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }

        //Post /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDto)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }
            var movie = Mapper.Map<MovieDTO, Movie>(movieDto);
            movie.NumberAvailable = movie.NumberInStock;
            this._context.Movies.Add(movie);
            this._context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //PUT /api/movies/1
        [HttpPut]
        public void UpdateMovie(int id, MovieDTO movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var movieInDb = this._context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            
            Mapper.Map(movieDto, movieInDb);

            this._context.SaveChanges();
        }

        //DELETE /api/movies/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = this._context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            this._context.Movies.Remove(movieInDb);
            this._context.SaveChanges();
        }
    }
}