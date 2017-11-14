using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{

    public class CustomersViewModel
    {
        public List<Customer> Customers { get; set; }

        public Customer CustomerInfo { get; set; }
    }
}