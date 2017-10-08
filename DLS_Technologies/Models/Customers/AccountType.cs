using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DLS_Technologies.Models.Customers
{
    public class AccountType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        public string Name { get; set; }

        public bool MonthlySiteVisit { get; set; }

    }
}