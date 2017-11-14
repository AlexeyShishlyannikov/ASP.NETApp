using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers.Api
{
    using System.Data.Entity;

    using AutoMapper;

    using WebApplication1.DTOs;
    using WebApplication1.Models;

    public class NewRentalController : ApiController
    {
        public ApplicationDbContext _context;

        public NewRentalController()
        {
            this._context = new ApplicationDbContext();
        }

        //GET /api/newrental/
        [HttpGet]
        public IHttpActionResult GetRentals()
        {
            return this.Ok(this._context.Rentals.Include(c => c.Movie).Include(c => c.Customer).ToList());
        }

        //POST /api/newrental/
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var customer = this._context.Customers.Single(c => c.Id == newRental.CustomerId);
            
            var movies = this._context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                {
                    return this.BadRequest("Movie is not available.");
                }
                movie.NumberAvailable--;

                var rental = new Rental
                                 {
                                     Customer = customer,
                                     Movie = movie,
                                     DateRented = DateTime.Now
                                 };
                this._context.Rentals.Add(rental);
            }

            this._context.SaveChanges();

            return this.Ok();
        }
    }
}
