using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DLS_Technologies.Models.Customers
{
    public class MonthlySiteVisit
    {
        public int Id { get; set; }

        [Display(Name = "Due Date:")]
        public DateTime NextDueDate { get; set; }

        [Display(Name = "Due:")]
        public bool Due { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        [Display(Name = "Completed Date")]
        public DateTime? CompletedDate { get; set; }

    }
}