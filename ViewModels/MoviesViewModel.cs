using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels
{
    using WebApplication1.Models;

    public class MoviesViewModel
    {
        public List<Movie> MovieList { get; set; }

        public Movie MovieDetails { get; set; }
    }
}