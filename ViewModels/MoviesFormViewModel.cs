using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;

    using WebApplication1.Models;

    public class MoviesFormViewModel
    {
        public string header { get; set; }

        public IEnumerable<Genres> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleasedDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Display(Name = "Number in Stock")]
        [Min1ItemInStock]
        [Required]
        public int? NumberInStock { get; set; }

        public MoviesFormViewModel()
        {
            Id = 0;
            DateAdded = DateTime.Now;
        }

        public MoviesFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleasedDate = movie.ReleasedDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
            DateAdded = movie.DateAdded;
        }

    }
}