using DLS_Technologies.Models;
using DLS_Technologies.Models.Customers;
using DLS_Technologies.ViewModels.CustomerViewModels;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;

namespace DLS_Technologies.Controllers.Customers
{
    /// <summary>
    /// TODO: Add validation for each HTTP Request.
    /// TODO: Use DTOs instead of domain model.
    /// TODO: Organize Methods.
    /// </summary>
    
    public class CustomersController : Controller
    {
        ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        public ActionResult NewCustomer()
        {
            var accountTypes = _context.AccountTypes.ToList();

            var viewModel = new CustomerViewModel
            {
                AccountTypes = accountTypes,
                DateJoined = DateTime.Now,
                MonthlySiteVisitDate = DateTime.Now.AddDays(30)
            };

            return View("CustomerForm", viewModel);
        }

        public ActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.Include(c => c.AccountType).Single(c => c.Id == id);
            return View("Customer", customer);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            var accountTypes = _context.AccountTypes.ToList();
            var viewModel = new CustomerViewModel
            {
                AccountTypes = accountTypes,
                DateJoined = DateTime.Now
            };

            if (_context.Customers.Any(c => c.Name == customer.Name))
            {
                ModelState.AddModelError("Name", "This customer already exists.");                
                return View("CustomerForm", viewModel);
            }

            if (!ModelState.IsValid)
            {
                return View("CustomerForm", viewModel);
            }            

            if(customer.Id == 0)
            {                
                if (customer.AccountTypeId != 1)                
                {
                    customer.MonthlySiteVisitDate = null;
                }

                var siteInfo = new SiteInfo
                {
                    CustomerId = customer.Id                   
                };

                _context.SiteInfos.Add(siteInfo);
                _context.Customers.Add(customer);
                _context.SaveChanges();              
                
                return View("Customer", customer);
            }

            return View("Customer", customer);
        }

        public ActionResult GetNoteContent(int id)
        {
            if (id == 0)
                return Json(new { } );

            var note = _context.SiteInfoNotes.Single(n => n.Id == id).Note;
            var title = _context.SiteInfoNotes.Single(n => n.Id == id).Title;

            return Json(new { note = note, title = title }, JsonRequestBehavior.AllowGet) ;
        }


        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCustomerNote(int id, string note)
        {
            var customer = _context.Customers.Include(c => c.AccountType).Single(c => c.Id == id);

            if (!ModelState.IsValid)
            {
                return PartialView("_CustomerDetails", customer);
            }


            customer.Note = note;
            _context.SaveChanges();

            return PartialView("_CustomerDetails", customer);

        }


        [HttpPut]
        [ValidateAntiForgeryToken]
        public void SaveSiteInfoTabNote(int id, string note, string noteType)
        {
            var parsedType = noteType.Substring(0, noteType.Length - 4);

            var siteNotes = _context.SiteInfoNotes.Where(n => n.CustomerId == id).ToList();
            var servers = _context.CustomerServers.Where(s => s.CustomerId == id).ToList();
            var siteInfo = _context.SiteInfos.Single(s => s.CustomerId == id);

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

            switch (parsedType)
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

        [HttpPut]
        [ValidateAntiForgeryToken]
        public int SaveSiteInfoNote(int id, int noteId, string noteTitle, string noteContent)
        {
            var note = _context.SiteInfoNotes.FirstOrDefault(n => n.Id == noteId);

            if (note == null)
            {
                var siteInfoNote = new SiteInfoNote
                {
                    CustomerId = id,
                    Note = noteContent,
                    Title = noteTitle
                };
                _context.SiteInfoNotes.Add(siteInfoNote);
                _context.SaveChanges();
                return siteInfoNote.Id;
            }
            else
            {
                note.Title = noteTitle;
                note.Note = noteContent;
                _context.SaveChanges();
                return note.Id;
            }
        }



        // Partials //

        public ActionResult LoadCustomerNotes(int id)
        {
            var customer = _context.Customers.Single(c => c.Id == id);
            var customerNotes = new CustomerViewModel
            {
                Id = customer.Id,
                Note = customer.Note
            };

            return PartialView("_CustomerNotes", customerNotes);
        }

        public ActionResult LoadCustomerInfoPartial(int custId, int btnId)
        {
            var customer = _context.Customers.Include(c => c.AccountType).Single(c => c.Id == custId);
            var siteInfo = _context.SiteInfos.FirstOrDefault(s => s.CustomerId == custId);
            var siteNotes = _context.SiteInfoNotes.Where(n => n.CustomerId == custId).ToList();
            var servers = _context.CustomerServers.Where(s => s.CustomerId == custId).ToList();
            

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

            switch (btnId)
            {
                case 1:
                    return PartialView("_CustomerDetails", customer);
                case 2:
                    return PartialView("_SiteInfo", siteInfoVm);
                case 3:
                    return PartialView("_ServerInfo", siteInfoVm);
                case 4:
                    return PartialView("_AccountInfo", customer);
                default:
                    return PartialView("_CustomerDetails", customer);
            }
        }

        public ActionResult LoadSiteInfoNotesTable(int id, int noteId)
        {
            var siteInfoNotes = _context.SiteInfoNotes.Where(n => n.CustomerId == id).ToList();
            var note = _context.SiteInfoNotes.FirstOrDefault(n => n.Id == noteId);

            if (note == null)
            {
                var viewModel = new SiteInfoViewModel
                {
                    Notes = siteInfoNotes,
                    NoteTitle = "",
                    NoteId = 0                    
                };

                return PartialView("_SiteInfoNotesTable", viewModel);
            }
            else
            {
                var viewModel = new SiteInfoViewModel
                {
                    Notes = siteInfoNotes,
                    NoteTitle = note.Title,
                    NoteContent = note.Note,
                    NoteId = note.Id
                };

                return PartialView("_SiteInfoNotesTable", viewModel);
            }
            

            
            

        }
    }
}