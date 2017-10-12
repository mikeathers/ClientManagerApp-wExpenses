using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DLS_Technologies.Models.Customers
{
    public class CustomerServer
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Server Name:")]
        public string ServerName { get; set; }

        [Required]
        [Display(Name = "Public IP Address:")]
        public string PublicIpAddress { get; set; }

        [Required]
        [Display(Name = "Private IP Address:")]
        public string PrivateIpAddress { get; set; }

        [Required]
        [Display(Name = "Port:")]
        public string Port { get; set; }

        [Required]
        [Display(Name = "Username:")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password:")]
        public string Password { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }
    }
}