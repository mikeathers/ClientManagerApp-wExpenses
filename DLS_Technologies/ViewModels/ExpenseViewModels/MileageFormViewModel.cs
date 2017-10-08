using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DLS_Technologies.ViewModels
{
    public class MileageFormViewModel : ExpenseViewModel
    {
        [Required]
        public string Origin { get; set; }

        
        public string Destination { get; set; }
        
        
        [Display(Name = "Odometer Start")]
        public int? OdometerStart { get; set; }
        
        
        [Display(Name = "Odometer End")]        
        public int? OdometerEnd { get; set; }

        
        [Display(Name = "Total Miles:")]
        public double? TotalMiles { get; set; }

    }
}