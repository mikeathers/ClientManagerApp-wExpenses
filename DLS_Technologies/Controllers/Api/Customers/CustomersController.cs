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

        [HttpPut]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        public void SaveSiteInfoNote(FormDataCollection formData)
        {
            var note = formData.Get("note");
            var noteType = formData.Get("noteType");
            var custId = Convert.ToInt32(formData.Get("custId"));
            var type = noteType.Substring(noteType.Length - 4);

            var siteNotes = _context.SiteInfoNotes.Where(n => n.CustomerId == custId).ToList() != null ? _context.SiteInfoNotes.Where(n => n.CustomerId == custId).ToList() : null;
            var servers = _context.CustomerServers.Where(s => s.CustomerId == custId).ToList() != null ? _context.CustomerServers.Where(s => s.CustomerId == custId).ToList() : null;

            var siteInfo = _context.SiteInfos.Single(s => s.CustomerId == custId);
            var siteInfoVm = new SiteInfoViewModel
            {
                Id = siteInfo.Id,
                CustomerId = siteInfo.CustomerId,
                NetworkInfo = siteInfo.NetworkInfo,
                WifiInfo = siteInfo.WifiInfo,
                DomainInfo = siteInfo.DomainInfo,
                Notes = siteNotes,
                Servers = servers
            };

            if (note == null)
            {
                ModelState.AddModelError(noteType, type + " Info box does not contain any data.");
            }

            switch (noteType)
            {
                case "Network":
                    siteInfo.NetworkInfo = note;
                    break;
                case "Wifi":
                    siteInfo.WifiInfo = note;
                    break;
                case "Domain":
                    siteInfo.DomainInfo = note;
                    break;
            }

            _context.SaveChanges();


        }

        [HttpDelete]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.FirstOrDefault(e => e.Id == id);



            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }

        [HttpPut]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        public void UpdateCustomerNote(FormDataCollection formData)
        {
            var id = Convert.ToInt32(formData.Get("id"));
            var note = formData.Get("note");

            var customer = _context.Customers.Single(c => c.Id == id);

            customer.Note = note;
            _context.SaveChanges();

        }
    }
}
