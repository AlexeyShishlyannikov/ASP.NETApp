using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Min1ItemInStock : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            if (movie.NumberInStock < 1 || movie.NumberInStock > 20)
            {
                return new ValidationResult("Number in stock should be between 1 and 20.");
            }
            if (movie.NumberInStock ==  null)
            {
                return new ValidationResult("Number of items is required");
            }
            
                return ValidationResult.Success;
            
        }
    }
}