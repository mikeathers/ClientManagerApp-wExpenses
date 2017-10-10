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
            var customer = _context.Customers.Single(c => c.Id == id);
            return View("CustomerDetails", customer);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            var accountTypes = _context.AccountTypes.ToList();

            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerViewModel
                {
                    AccountTypes = accountTypes,
                    DateJoined = DateTime.Now
                };
                RedirectToAction("NewCustomer");
            }


            if(customer.Id == 0)
            {
                if(customer.Note != null)
                {
                    var custNote = new CustomerNote
                    {
                        CustomerId = customer.Id,
                        Note = customer.Note,
                        DateAdded = DateTime.Now
                    };
                    _context.CustomerNotes.Add(custNote);
                }

                if (customer.AccountTypeId == 1)
                    customer.MonthlySiteVisitDue = true;
                else
                {
                    customer.MonthlySiteVisitDate = null;
                    customer.MonthlySiteVisitDue = false;
                }
                
                _context.Customers.Add(customer);
                _context.SaveChanges();

                
                return View("CustomerDetails", customer);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewNote(CustomerNote customerNote)
        {           
            var customer = _context.Customers.First(c => c.Id == customerNote.CustomerId);

            if (!ModelState.IsValid)
                return View("CustomerDetails", customer);
            
            customerNote.DateAdded = DateTime.Now;
            _context.CustomerNotes.Add(customerNote);
            _context.SaveChanges();

            return View("CustomerDetails", customer);
        }

        public ActionResult NewNotePartial(int customerId)
        {
            var newNote = new CustomerNote
            {
                CustomerId = customerId
            };

            return PartialView("_CustomerNote", newNote);
        }

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
    }
}