using DLS_Technologies.Models;
using DLS_Technologies.Models.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DLS_Technologies.ViewModels.CustomerViewModels
{
    public class SiteInfoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Network Info:")]
        public string NetworkInfo { get; set; }

        [Display(Name = "Wifi Info:")]
        public string WifiInfo { get; set; }

        [Display(Name = "Domain Info:")]
        public string DomainInfo { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public IEnumerable<CustomerServer> Servers { get; set; }

        public IEnumerable<SiteInfoNote> Notes { get; set; }
    }
}