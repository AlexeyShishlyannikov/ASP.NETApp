
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.DTOs
{
    using System.ComponentModel.DataAnnotations;

    using WebApplication1.Models;

    public class MovieDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }
        
        public DateTime ReleasedDate { get; set; }

        public DateTime DateAdded { get; set; }
        
        //[Min1ItemInStock]
        public int NumberInStock { get; set; }

        public int? NumberAvailable { get; set; }
    }
}