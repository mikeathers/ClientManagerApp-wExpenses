using DLS_Technologies.Models;
using DLS_Technologies.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace DLS_Technologies.Controllers.Api.Customers
{
    public class CustomersController : ApiController
    {
        ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult AddNewNote(FormDataCollection formData)
        {
            var customerId = Convert.ToInt32(formData.Get("CustomerId"));
            var note = formData.Get("Note");

            var newNote = new CustomerNote
            {
                Note = note,
                DateAdded = DateTime.Now,
                CustomerId = customerId
            };

            if (note == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.CustomerNotes.Add(newNote);
            _context.SaveChanges();

            return Ok();

        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomerNote(int id)
        {
            var note = _context.CustomerNotes.Single(n => n.Id == id);

            if (note == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.CustomerNotes.Remove(note);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/customers/deletecustomer/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.FirstOrDefault(e => e.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }

        [HttpPut]
        public IHttpActionResult UpdateCustomerNote(FormDataCollection formData)
        {
            var id = Convert.ToInt32(formData.Get("id"));
            var note = formData.Get("note");

            var customer = _context.Customers.Single(c => c.Id == id);

            customer.Note = note;
            _context.SaveChanges();

            return Ok();
        }
    }
}
