using DLS_Technologies.Models;
using DLS_Technologies.Models.Customers;
using DLS_Technologies.ViewModels.CustomerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
        }

        public ActionResult NewCustomer()
        {
            var accountTypes = _context.AccountTypes.ToList();

            var viewModel = new CustomerViewModel
            {
                AccountTypes = accountTypes,
                DateJoined = DateTime.Now
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var accountTypes = _context.AccountTypes.ToList();

                var viewModel = new CustomerViewModel
                {
                    AccountTypes = accountTypes,
                    DateJoined = DateTime.Now
                };

                RedirectToAction("NewCustomer");
            }


            if(customer.Id == 0)
            {
                var custNote = new CustomerNote
                {
                    CustomerId = customer.Id,
                    Note = customer.InitialNote,
                    DateAdded = DateTime.Now
                };

                _context.CustomerNotes.Add(custNote);
                _context.Customers.Add(customer);

                _context.SaveChanges();

                RedirectToAction("NewCustomer");
            }

            return View();
        }
    }
}