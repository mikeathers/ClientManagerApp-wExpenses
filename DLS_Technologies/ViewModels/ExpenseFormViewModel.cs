using DLS_Technologies.Models;
using DLS_Technologies.Models.ExpensesModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DLS_Technologies.ViewModels
{
    public class ExpenseFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ExpenseForm ExpenseForm { get; set; }

        public IEnumerable<Expense> Expenses { get; set; }

        [Display(Name = "Expense Forms")]
        public IEnumerable<ExpenseForm> ExpenseForms { get; set; }

        public IEnumerable<ExpenseType> ExpenseTypes { get; set; }

        [Display(Name = "Expense Type")]
        public ExpenseType ExpenseType { get; set; }
        
        public int ExpenseTypeId { get; set; }

        public Expense Expense { get; set; }

        public double? TotalCost { get; set; }
        
        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public DateTime? DateAdded { get; set; }      

    }
}