using DLS_Technologies.Models.ExpensesModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DLS_Technologies.ViewModels
{
    public class ExpenseViewModel
    {
        
        public IEnumerable<ExpenseType> ExpenseTypes { get; set; }

        [Required]
        [Display(Name = "Expense Type")]
        public byte? ExpenseTypeId { get; set; }

        
        public string Description { get; set; }

        public int Id { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        public DateTime DateTime { get; set; }

        [Display(Name = "Total Cost (£):")]
        [Required]
        public double? Cost { get; set; }

        public ExpenseForm ExpenseForm { get; set; }

        [Display(Name = "Expense Form")]
        public int ExpenseFormId { get; set; }

        public ExpenseType ExpenseType { get; set; }

        

    }
}