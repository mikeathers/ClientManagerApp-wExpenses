using DLS_Technologies.Models;
using DLS_Technologies.Models.ExpensesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DLS_Technologies.Controllers.Api
{
    public class ExpenseFormsController : ApiController
    {
        private ApplicationDbContext _context;

        public ExpenseFormsController()
        {
            _context = new ApplicationDbContext();
        }


       


        // DELETE api/expenseforms/1
        [HttpDelete]
        public void DeleteExpenseForm (int id)
        {
            var expenseFormInDb = _context.ExpenseForms.SingleOrDefault(e => e.Id == id);

            if (expenseFormInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.ExpenseForms.Remove(expenseFormInDb);
            _context.SaveChanges();
        }



        // UPDATE api/expenseforms/1
        [HttpPut]
        public void UpdateExpenseFormName(int id, string name)
        {
            var expenseFormInDb = _context.ExpenseForms.SingleOrDefault(e => e.Id == id);

            if (expenseFormInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            expenseFormInDb.Name = name;
            _context.SaveChanges();
        }


        [HttpPost]
        public void UpdateTotalCost(int id, double totalCostValue)
        {
            var expenseForm = _context.ExpenseForms.FirstOrDefault(e => e.Id == id);

            if (expenseForm == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            expenseForm.TotalCost = totalCostValue;
            _context.SaveChanges();
        }


    }
}
