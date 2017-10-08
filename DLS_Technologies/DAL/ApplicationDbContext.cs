using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using DLS_Technologies.Models.ExpensesModels;
using DLS_Technologies.Models.Customers;

namespace DLS_Technologies.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<ExpenseForm> ExpenseForms { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<CustomerNote> CustomerNotes { get; set; }


    }
}