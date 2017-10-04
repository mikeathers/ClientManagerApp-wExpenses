using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DLS_Technologies.Models.ExpensesModels
{
    public class Expense
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        public DateTime DateTime { get; set; }

        public double? Cost { get; set; }
        
        public Customer Customer { get; set; }

        [Display(Name = "Customer")]
        public int? CustomerId { get; set; }
        
        public ExpenseType ExpenseType { get; set; }

        [Display(Name = "Expense Type")]
        public byte ExpenseTypeId { get; set; }
              
        public string Origin { get; set; }        
        
        public string Destination { get; set; }

        [Display(Name = "Odometer Start")]
        public int? OdometerStart { get; set; }

        [Display(Name = "Odometer End")]
        public int? OdometerEnd { get; set; }

        public ExpenseForm ExpenseForm { get; set; }

        [Display(Name = "Expense Form")]
        public int ExpenseFormId { get; set; }
        
        [Display(Name = "Total Miles")]
        public double? TotalMiles { get; set; }




    }
}