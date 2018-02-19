using MovieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieShop.Controllers.Api
{
    public class CustomersController : ApiController
    {
        MyDbContext _context;
        public CustomersController()
        {
            _context = new MyDbContext();
        }

        // Get api/customers
        [HttpGet]
        public IEnumerable<Customer> GetAll()
        {
            var customers = _context.Customers.ToList();
            return customers;
        }

        // Get /api/customers/1
        public Customer GetByFilter(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            return customer;
        }

        //Post /api/customers
        [HttpPost]
        public Customer Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        //Put /api/customers/1
        [HttpPut]
        public void Edit(Customer customer)
        {
            var DbCustomer = _context.Customers.FirstOrDefault(c => c.Id == customer.Id);
            if (DbCustomer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            DbCustomer.Name = customer.Name;
            DbCustomer.MembershiptypeId = customer.MembershiptypeId;
            DbCustomer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            DbCustomer.Birthdate = customer.Birthdate;
            _context.SaveChanges();
        }

        //Delete /api/customers/1
        public void Delete(int id)
        {
            var DbCustomer = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (DbCustomer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(DbCustomer);
            _context.SaveChanges();
        }

    }
}
