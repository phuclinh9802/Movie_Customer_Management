using AutoMapper;
using Movie.Dtos;
using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Movie.Controllers.Api
{
    public class CustomersController : ApiController
    {
        //create DBContext
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //Get api/customers
        public IHttpActionResult GetCustomers()
        {
            var customerDtos = _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customers, CustomerDto>);
            return Ok(customerDtos);
        }
        //Get api/customers/1
        public IHttpActionResult GetCustomerById(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Customers, CustomerDto>(customer));
        }
        //Post api/customers/
        [HttpPost]
        public IHttpActionResult PostCustomers(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customers>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            //return the URI (Unified Resource Identifier)
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }
        //Put api/customers/1
        [HttpPut]
        public void UpdateCustomers(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerDb = _context.Customers.SingleOrDefault(cus => cus.Id == id);
            if (customerDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            var c = Mapper.Map(customerDto, customerDb);



            _context.SaveChanges();

        }
        //Delete api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomers(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerDb == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customerDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
