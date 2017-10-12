using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using DLS_Technologies.Models;

namespace DLS_Technologies.Utilities
{
    public static class HangFireJobs
    {

        

        public static void CheckMonthlySiteVisitDates()
        {
            ApplicationDbContext _context = new ApplicationDbContext();

            var customers = _context.Customers.ToList();

            foreach (var customer in customers)
            {
                if(customer.AccountTypeId == 1)
                {
                    //customer.MonthlySiteVisitDue = (customer.MonthlySiteVisitDate.Value - DateTime.Now).TotalSeconds < 30;
                    //if(customer.MonthlySiteVisitDue == true)
                   // {
                   //     HangFireTest(customer.MonthlySiteVisitDate.Value);
                    //}

                }
            }

            _context.Dispose();
        }

       public static string HangFireTest(DateTime dateDue)
        {
            string text = "Monthly Site Visit is due on " + dateDue;
            File.WriteAllText(@"C:\Users\Mike\Desktop\WriteText.txt", text);

            return "Completed";
        }
    }
}