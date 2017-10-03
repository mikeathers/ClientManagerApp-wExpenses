using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DLS_Technologies.Models.ExpensesModels
{
    public class ExpenseForm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]        
        [Display(Name = "New Form Name:")]
        public string Name { get; set; }


        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }

        [Display(Name = "Total Cost")]
        public double? TotalCost { get; set; }

       
        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }
        



    }
}