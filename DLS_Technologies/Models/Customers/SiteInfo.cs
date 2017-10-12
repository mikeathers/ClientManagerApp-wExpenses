using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLS_Technologies.Models.Customers
{
    public class SiteInfo
    {
        public int Id { get; set; }

        public string NetworkInfo { get; set; }

        public string WifiInfo { get; set; }

        public string DomainInfo { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }
    }
}