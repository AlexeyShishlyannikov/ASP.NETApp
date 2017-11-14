using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    using System.Data.Entity;

    using WebApplication1.ViewModels;

    public class MoviesController : Controller
    {
        // GET: Movies/Random
        private ApplicationDbContext _context;

        public MoviesController()
        {
            this._context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = this._context.Genres.ToList();
            

            var movies = new MoviesFormViewModel
                             {
                                 Genres = genres,
                                 header = "New"
                             };

            return this.View("MovieForm",movies);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]

        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MoviesFormViewModel(movie)
                                    {
                                        Genres = this._context.Genres.ToList()
                                    };
                return this.View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                this._context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = this._context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleasedDate = movie.ReleasedDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.DateAdded = movie.DateAdded;
            }

            this._context.SaveChanges();

           
            return RedirectToAction("Index","Movies");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int? id)
        {
            var movie = this._context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return this.HttpNotFound();
            }
            var viewModel = new MoviesFormViewModel(movie)
                                {
                                    
                                    Genres = this._context.Genres.ToList(),
                                    header = "Edit"
                                };

            return this.View("MovieForm", viewModel);
        }

        public ViewResult Index()
        {
            return this.View(this.User.IsInRole(RoleName.CanManageMovies) ? "List" : "ReadOnlyList");
        }

        public ActionResult Details(int? id)
        {
            var movie = this._context.Movies.SingleOrDefault(m => m.Id == id);

            var movieDetails = new MoviesViewModel { MovieDetails = movie };

            if (movie == null)
            {
                return this.HttpNotFound();
            }

            return this.View(movieDetails);
        }
    }
}