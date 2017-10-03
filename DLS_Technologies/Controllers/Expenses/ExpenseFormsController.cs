using DLS_Technologies.Models;
using DLS_Technologies.Models.ExpensesModels;
using DLS_Technologies.ViewModels;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DLS_Technologies.Controllers
{
    public class ExpenseFormsController : Controller
    {
        /// Application DB context        
        protected ApplicationDbContext _context { get; set; }
       
        /// User manager - attached to application DB context        
        protected UserManager<ApplicationUser> _userManager { get; set; }

        public ExpenseFormsController()
        {
            _context = new ApplicationDbContext();
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            
        }




        public ActionResult Index()
        {
            var _user = _userManager.FindById(User.Identity.GetUserId());
            var expenseForms = _context.ExpenseForms.Where(e => e.UserId == _user.Id).ToList();            

            return View(expenseForms);
        }       
        
        
        
        // GET: Expenses
        [HttpPost]
        public ActionResult SaveExpenseForm(ExpenseFormViewModel expenseForm)
        {
            var _user = _userManager.FindById(User.Identity.GetUserId());
            var expenseForms = _context.ExpenseForms.Where(e => e.UserId == _user.Id).ToList();

            if (!ModelState.IsValid)
            {              
                return View("Index");
            }

            if (expenseForm.Id == 0)
            {

                var expenseFormToSave = new ExpenseForm
                {
                    Name = expenseForm.Name,
                    DateAdded = DateTime.Now,
                    TotalCost = 0,
                    UserId = _user.Id,
                    User = _user
                };
                _context.ExpenseForms.Add(expenseFormToSave);
            }
                
            else
            {
                var _expenseFormInDb = _context.ExpenseForms.First(e => e.Id == expenseForm.Id);
                _expenseFormInDb.Name = expenseForm.Name;
            }

            _context.SaveChanges();          

            return RedirectToAction("Index");

        }

        public ActionResult ShowExpenses(int expenseFormId)
        {
            var expenseForm = _context.ExpenseForms.Include(e => e.User).SingleOrDefault(e => e.Id == expenseFormId);
            var viewModel = new ExpenseFormViewModel
            {
                ExpenseForm = expenseForm,
                Expenses = _context.Expenses.Include(e => e.ExpenseType).Where(e => e.ExpenseFormId == expenseFormId).ToList(),
                User = expenseForm.User
                
            };

            var name = !String.IsNullOrEmpty(viewModel.User.FullName) ? viewModel.User.FullName : viewModel.User.FirstName + " " + viewModel.User.LastName;

            ViewBag.Title = viewModel.ExpenseForm.Name + " - " + name;            

            return View("ShowExpensesForm", viewModel);
        }                
        
        [HttpPost]
        public void UpdateTotalCost(int id, double totalCost)
        {
            var expenseForm = _context.ExpenseForms.Include(e => e.User).FirstOrDefault(e => e.Id == id);
            var expenses = _context.Expenses.Where(e => e.ExpenseFormId == id).ToList();

            if (expenseForm == null)
                return;

            double totalCosts = 0;

            foreach (var expense in expenses)
            {
                totalCosts += expense.Cost.Value;
            }

            expenseForm.TotalCost = totalCosts;
            _context.SaveChanges();
            
        }
    }
}