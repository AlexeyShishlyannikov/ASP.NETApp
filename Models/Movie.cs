using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        

        public Genres Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Display (Name = "Release Date")]
        public DateTime ReleasedDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in Stock")]
        [Min1ItemInStock]
        public int NumberInStock { get; set; }

        public int? NumberAvailable  { get; set; }

    }

    // /movies/random
}