using DLS_Technologies.Models;
using DLS_Technologies.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Helpers;
using DLS_Technologies.ViewModels.CustomerViewModels;



namespace DLS_Technologies.Controllers.Api.Customers
{
    public class CustomersController : ApiController
    {
        ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }        

        [HttpDelete]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.FirstOrDefault(e => e.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }        

        [HttpDelete]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        public void DeleteNote(int id)
        {
            var note = _context.SiteInfoNotes.FirstOrDefault(n => n.Id == id);

            if (note == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.SiteInfoNotes.Remove(note);
            _context.SaveChanges();
        }

        
    }
}
