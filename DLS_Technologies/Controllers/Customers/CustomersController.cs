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
            return View("CustomerParent", customer);

        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Single(c => c.Id == id);
            var accountTypes = _context.AccountTypes.ToList();

            var viewModel = new CustomerViewModel
            {
                Id = customer.Id,
                Name = customer.Name,
                AccountTypeId = customer.AccountTypeId,
                Address = customer.Address,
                PostCode = customer.PostCode,
                ContactInfo = customer.ContactInfo,
                ContactOnSite = customer.ContactOnSite,
                EmailAddress = customer.EmailAddress,
                DateJoined = customer.DateJoined,
                MonthlySiteVisitDate = customer.MonthlySiteVisitDate,
                Note = customer.Note,
                AccountTypes = accountTypes
            };


            return View("CustomerForm", viewModel);
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

            if (!ModelState.IsValid) { return View("CustomerForm", viewModel); }            

            if(customer.Id == 0)
            {
                if (_context.Customers.Any(c => c.Name == customer.Name))
                {
                    ModelState.AddModelError("Name", "This customer already exists.");
                    return View("CustomerForm", viewModel);
                }

                if (customer.AccountTypeId != 1)                
                {
                    customer.MonthlySiteVisitDate = null;
                }

                var siteInfo = new SiteInfo { CustomerId = customer.Id };

                _context.SiteInfos.Add(siteInfo);
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return View("CustomerParent", customer);
            }
            else
            {
                var custIndDb = _context.Customers.Single(c => c.Id == customer.Id);

                custIndDb.Id = customer.Id;
                custIndDb.Name = customer.Name;
                custIndDb.AccountTypeId = customer.AccountTypeId;
                custIndDb.Address = customer.Address;
                custIndDb.PostCode = customer.PostCode;
                custIndDb.ContactInfo = customer.ContactInfo;
                custIndDb.ContactOnSite = customer.ContactOnSite;
                custIndDb.EmailAddress = customer.EmailAddress;
                custIndDb.DateJoined = customer.DateJoined;
                custIndDb.MonthlySiteVisitDate = customer.MonthlySiteVisitDate;
                custIndDb.Note = customer.Note;

                _context.SaveChanges();
                return View("CustomerParent", customer);
            }            
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
                Notes = siteNotes
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddServer(CustomerServer server)
        {
            var servers = _context.CustomerServers.Where(s => s.CustomerId == server.CustomerId);

            var serverViewModel = new ServerViewModel
            {
                Servers = servers,
                CustomerId = server.CustomerId
            };

            if (server.Id == 0)
            {               
                _context.CustomerServers.Add(server);
                _context.SaveChanges();
                return View("_ServerInfo", serverViewModel);
            }
           
            var customer = _context.Customers.Single(c => c.Id == server.CustomerId);
            
            var serverInDb = _context.CustomerServers.SingleOrDefault(s => s.Id == server.Id);

            serverInDb.ServerName = server.ServerName;
            serverInDb.PublicIpAddress = server.PublicIpAddress;
            serverInDb.PrivateIpAddress = server.PrivateIpAddress;
            serverInDb.Port = server.Port;
            serverInDb.UserName = server.UserName;
            serverInDb.Password = server.Password;

            _context.SaveChanges();
            return View("_ServerInfo", serverViewModel);
        }

        public ActionResult OpenRdp()
        {
            string address = Request.QueryString["address"];
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", string.Format("attachment; filename={0}.rdp", address));
            Response.Output.Write(string.Format(@"
                screen mode id:i:2
                session bpp:i:32
                compression:i:1
                keyboardhook:i:2
                displayconnectionbar:i:1
                disable wallpaper:i:1
                disable full window drag:i:1
                allow desktop composition:i:0
                allow font smoothing:i:0
                disable menu anims:i:1
                disable themes:i:0
                disable cursor setting:i:0
                bitmapcachepersistenable:i:1
                full address:s:{0}
                audiomode:i:0
                redirectprinters:i:1
                redirectcomports:i:0
                redirectsmartcards:i:1
                redirectclipboard:i:1
                redirectposdevices:i:0
                autoreconnection enabled:i:1
                authentication level:i:2
                prompt for credentials:i:0
                negotiate security layer:i:1
                remoteapplicationmode:i:0
                alternate shell:s:
                shell working directory:s:
                gatewayhostname:s:
                gatewayusagemethod:i:4
                gatewaycredentialssource:i:4
                gatewayprofileusagemethod:i:0
                promptcredentialonce:i:1
                drivestoredirect:s:E:;
                use multimon:i:0
                audiocapturemode:i:0
                videoplaybackmode:i:1
                connection type:i:2
                redirectdirectx:i:1
                use redirection server name:i:0", address));

            Response.End();
            return View();
        }

        public JsonResult AutoComplete(string custName)
        {
            var customerName = _context.Customers.Where(c => c.Name.StartsWith(custName)).Select(c => new { id = c.Id, name = c.Name });
            return Json(customerName, JsonRequestBehavior.AllowGet);
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
            var serverList = _context.CustomerServers.Where(s => s.CustomerId == custId).ToList();
            

            var siteInfoVm = new SiteInfoViewModel
            {
                Id = siteInfo.Id,
                CustomerId = siteInfo.CustomerId,
                NetworkInfo = siteInfo.NetworkInfo,
                WifiInfo = siteInfo.WifiInfo,
                DomainInfo = siteInfo.DomainInfo,
                Notes = siteNotes,
            };

            var serverInfoVm = new ServerViewModel
            {
                Servers = serverList,
                CustomerId = custId
            };

            switch (btnId)
            {
                case 1:
                    return PartialView("_CustomerDetails", customer);
                case 2:
                    return PartialView("_SiteInfo", siteInfoVm);
                case 3:
                    return PartialView("_ServerInfo", serverInfoVm);
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

        public ActionResult LoadServersTable(int id)
        {
            var servers = _context.CustomerServers.Where(s => s.CustomerId == id).ToList();
            var serverViewModel = new ServerViewModel
            {                
                Servers = servers,
                CustomerId = id
            };

            return PartialView("_ServersTable", serverViewModel);
        }
    }
}