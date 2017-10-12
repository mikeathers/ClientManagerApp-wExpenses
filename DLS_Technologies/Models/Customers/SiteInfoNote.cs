using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DLS_Technologies.Models.Customers
{
    public class SiteInfoNote
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Title:")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Note:")]
        public string Note { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }
    }
}