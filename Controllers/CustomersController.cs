using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    using WebApplication1.ViewModels;

    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            this._context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = this._context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel {Customer = new Customer(),
                MembershipTypes = membershipTypes };

            return this.View("CustomerForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                                    {
                                        Customer = customer,
                                        MembershipTypes = this._context.MembershipTypes.ToList()
                                    };
                return this.View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
            {
                this._context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = this._context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

            }
            this._context.SaveChanges();

            return RedirectToAction("Index","Customers");
        }


        public ViewResult Index()
        {
            return this.View();
        }
        


        public ActionResult Details(int? id)
        {
            var customer = this._context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            var customerInfo = new CustomersViewModel
                                   {
                                       CustomerInfo = customer
                                   };

            if (customer == null) return this.HttpNotFound();

            return this.View(customerInfo);
        }

        public ActionResult Edit(int? id)
        {
            var customer = this._context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return this.HttpNotFound();
            }
            var viewModel = new CustomerFormViewModel
                                {
                                    Customer = customer,
                                    MembershipTypes = this._context.MembershipTypes.ToList()
                                };

            return this.View("CustomerForm",viewModel);
        }
    }
}