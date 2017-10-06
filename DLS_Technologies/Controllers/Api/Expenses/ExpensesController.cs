using DLS_Technologies.Models;
using DLS_Technologies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DLS_Technologies.Controllers.Api
{
    public class ExpensesController : ApiController
    {
        ApplicationDbContext _context;

        public ExpensesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/expenses/deleteexpense/1
        [HttpDelete]
        public void DeleteExpense(int id)
        {
            var expenseInDb = _context.Expenses.FirstOrDefault(e => e.Id == id);
            var expenseForm = _context.Expenses.Where(e => e.Id == id).Select(e => e.ExpenseForm).FirstOrDefault();

            if (expenseInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            expenseForm.TotalCost -= expenseInDb.Cost.Value;           

            _context.Expenses.Remove(expenseInDb);
            _context.SaveChanges();
        }
    }
}
