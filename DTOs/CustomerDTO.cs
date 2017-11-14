using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.DTOs
{
    using System.ComponentModel.DataAnnotations;

    using WebApplication1.Models;

    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }
        
        //[Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
    }
}