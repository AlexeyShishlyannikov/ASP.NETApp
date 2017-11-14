using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers.Api
{
    using AutoMapper;

    using WebApplication1.DTOs;
    using WebApplication1.Models;

    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            this._context = new ApplicationDbContext();
        }
        // GET /api/customers/
        public IHttpActionResult GetCustomers(string query = null)
        {
           var customersQuery = this._context.Customers
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }

            var customerDtos = customersQuery.ToList().Select(Mapper.Map<Customer, CustomerDTO>);


            return this.Ok(customerDtos);
        }

        //GET /api/customer/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = this._context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return this.NotFound();
            }

            return this.Ok(Mapper.Map<Customer,CustomerDTO>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }
            var customer = Mapper.Map<CustomerDTO,Customer>(customerDto);
            this._context.Customers.Add(customer);
            this._context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customerInDb = this._context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(customerDto, customerInDb);

            this._context.SaveChanges();
        }

        // DELETE /api/customer/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = this._context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            this._context.Customers.Remove(customerInDb);
            this._context.SaveChanges();
        }
    }
}
