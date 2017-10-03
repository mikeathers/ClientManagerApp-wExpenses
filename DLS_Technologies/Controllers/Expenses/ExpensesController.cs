using DLS_Technologies.Models;
using DLS_Technologies.Models.ExpensesModels;
using DLS_Technologies.ViewModels;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Microsoft.AspNet.Identity;

namespace DLS_Technologies.Controllers
{
    public class ExpensesController : Controller
    {
        ApplicationDbContext _context;

        public ExpensesController()
        {
            _context = new ApplicationDbContext();
        }       
        


        public ActionResult Index()
        {
            var expenseForms = _context.ExpenseForms.ToList();
            var expenseForm = new ExpenseForm();
            return View(expenseForms);
        }   
        

        // GET expenses/getexpense/1

        public ActionResult GetExpense(int id)
        {         


            var expense = _context.Expenses.Include(e => e.ExpenseType).FirstOrDefault(e => e.Id == id);            

            if (expense == null)
                return Content("Expense is null");

            ViewBag.Title = "Expense - " + expense.ExpenseType.Name;
            

            if (expense.ExpenseTypeId == 1)
            {
                var viewModel = new MileageFormViewModel
                {                    
                    Date = expense.Date,
                    ExpenseTypeId = expense.ExpenseTypeId,
                    ExpenseFormId = expense.ExpenseFormId,
                    Origin = expense.Origin,
                    Destination = expense.Destination,
                    OdometerStart = expense.OdometerStart,
                    OdometerEnd = expense.OdometerEnd,
                    TotalMiles = expense.TotalMiles,
                    Cost = expense.Cost,
                    Id = expense.Id,
                    ExpenseTypes = _context.ExpenseTypes.ToList(),
                    ExpenseType = _context.ExpenseTypes.Where(e => e.Id == expense.ExpenseTypeId).FirstOrDefault()
                    

                };

                return View("ViewMileageExpenseForm", viewModel);
            }
            else
            {
                var viewModel = new ExpenseViewModel
                {
                    Date = expense.Date.Value,
                    ExpenseTypeId = expense.ExpenseTypeId,
                    ExpenseFormId = expense.ExpenseFormId,
                    Cost = expense.Cost,
                    Description = expense.Description,
                    Id = expense.Id,
                    ExpenseTypes = _context.ExpenseTypes.ToList()
                };

                return View("ViewExpenseForm", viewModel);
            }

           
        }

        public ActionResult LoadViewExpensePartial(int id)
        {
            var expense = _context.Expenses.Include(e => e.ExpenseType).FirstOrDefault(e => e.Id == id);

            if (expense == null)
                return Content("Expense is null");

            ViewBag.Title = "Expense - " + expense.ExpenseType.Name;


            if (expense.ExpenseTypeId == 1)
            {
                var viewModel = new MileageFormViewModel
                {
                    Date = expense.Date,
                    ExpenseTypeId = expense.ExpenseTypeId,
                    ExpenseFormId = expense.ExpenseFormId,
                    Origin = expense.Origin,
                    Destination = expense.Destination,
                    OdometerStart = expense.OdometerStart,
                    OdometerEnd = expense.OdometerEnd,
                    TotalMiles = expense.TotalMiles,
                    Cost = expense.Cost,
                    Id = expense.Id,
                    ExpenseTypes = _context.ExpenseTypes.ToList(),
                    ExpenseType = _context.ExpenseTypes.Where(e => e.Id == expense.ExpenseTypeId).FirstOrDefault()


                };

                return View("ViewMileageExpenseForm", viewModel);
            }
            else
            {
                var viewModel = new ExpenseViewModel
                {
                    Date = expense.Date.Value,
                    ExpenseTypeId = expense.ExpenseTypeId,
                    ExpenseFormId = expense.ExpenseFormId,
                    Cost = expense.Cost,
                    Description = expense.Description,
                    Id = expense.Id,
                    ExpenseTypes = _context.ExpenseTypes.ToList()
                };

                return View("ViewExpenseForm", viewModel);
            }
        }
        

        // GET expenses/new
        public ActionResult NewExpense(int expenseFormId)
        {
            var expenseTypes = _context.ExpenseTypes.ToList();

            var viewModel = new ExpenseViewModel
            {
                 ExpenseTypes = expenseTypes,
                 ExpenseForm = _context.ExpenseForms.Single(e => e.Id == expenseFormId),
                 ExpenseFormId = expenseFormId,
                 Date = DateTime.Now
            };

            return View("NewExpenseForm", viewModel);           
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Expense expense)
        {
            var parsedOrigin = "";
            var parsedDestination = "";


            if (!ModelState.IsValid)
            {
                var expenseTypes = _context.ExpenseTypes.ToList();

                var viewModel = new ExpenseViewModel
                {
                    ExpenseTypes = expenseTypes,
                    ExpenseForm = _context.ExpenseForms.Single(e => e.Id == expense.ExpenseFormId),

                };

                return View("NewExpenseForm", viewModel);
            }





            if(!String.IsNullOrEmpty(expense.Origin) || !String.IsNullOrEmpty(expense.Destination))
            {
                if (String.IsNullOrEmpty(expense.Origin))
                    expense.Origin = "";
                if (String.IsNullOrEmpty(expense.Destination))
                    expense.Destination = "";

                if (!expense.Origin.Contains(",") && !expense.Destination.Contains(","))
                {
                    if (expense.Id == 0)
                        _context.Expenses.Add(expense);
                    else
                    {
                        var expenseInDb = _context.Expenses.Single(e => e.Id == expense.Id);
                        expenseInDb.Cost = expense.Cost;
                        expenseInDb.CustomerId = expense.CustomerId;
                        expenseInDb.Date = expense.Date;
                        expenseInDb.Destination = expense.Destination;
                        expenseInDb.ExpenseFormId = expense.ExpenseFormId;
                        expenseInDb.ExpenseTypeId = expense.ExpenseTypeId;
                        expenseInDb.OdometerEnd = expense.OdometerEnd;
                        expenseInDb.OdometerStart = expense.OdometerStart;
                        expenseInDb.Origin = expense.Origin;
                        expenseInDb.TotalMiles = expense.TotalMiles;
                    }
                }
                else
                {
                    if (expense.Origin.Contains(","))
                        parsedOrigin = expense.Origin.Substring(0, expense.Origin.IndexOf(","));
                    else
                        parsedOrigin = expense.Origin;

                    if (expense.Destination.Contains(","))
                        parsedDestination = expense.Destination.Substring(0, expense.Destination.IndexOf(","));
                    else
                        parsedDestination = expense.Destination;

                    if (expense.Id == 0)
                    {
                        expense.Origin = parsedOrigin;
                        expense.Destination = parsedDestination;
                        _context.Expenses.Add(expense);
                    }
                    else
                    {
                        var expenseInDb = _context.Expenses.Single(e => e.Id == expense.Id);
                        expenseInDb.Cost = expense.Cost;
                        expenseInDb.CustomerId = expense.CustomerId;
                        expenseInDb.Date = expense.Date;
                        expenseInDb.Destination = parsedDestination;
                        expenseInDb.ExpenseFormId = expense.ExpenseFormId;
                        expenseInDb.ExpenseTypeId = expense.ExpenseTypeId;
                        expenseInDb.OdometerEnd = expense.OdometerEnd;
                        expenseInDb.OdometerStart = expense.OdometerStart;
                        expenseInDb.Origin = parsedOrigin;
                        expenseInDb.TotalMiles = expense.TotalMiles;
                    }
                }
            }
            else 
            {
                if (expense.Id == 0)
                {
                    _context.Expenses.Add(expense);
                }
                else
                {
                    var expenseInDb = _context.Expenses.Single(e => e.Id == expense.Id);
                    expenseInDb.Cost = expense.Cost;
                    expenseInDb.CustomerId = expense.CustomerId;
                    expenseInDb.Date = expense.Date;
                    expenseInDb.Description = expense.Description;
                    expenseInDb.ExpenseFormId = expense.ExpenseFormId;
                    expenseInDb.ExpenseTypeId = expense.ExpenseTypeId;
                }                
            }      

            _context.SaveChanges();
            return RedirectToAction("ShowExpenses", "ExpenseForms", new { expenseFormId = expense.ExpenseFormId });
        }


        
        public ActionResult LoadMileageFormat(int id)
        {
            if (id == 1)
            {
                var viewModel = new MileageFormViewModel();
                return PartialView("_GoogleMapsForm", viewModel);
            }
            else
            {
                var viewModel = new MileageFormViewModel();
                return PartialView("_OdometerForm", viewModel);
            }
        }
        
        public ActionResult LoadPartial(int id)
        {
            if (id == 1)
            {
                var mileageViewModel = new MileageFormViewModel();
                return PartialView("_MileageForm", mileageViewModel);
            }
            else
            {
                var expenseViewModel = new ExpenseViewModel();
                return PartialView("_OtherExpenseForm", expenseViewModel);
            }
        }




        
    }
}