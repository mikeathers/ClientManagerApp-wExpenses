using DLS_Technologies.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace DLS_Technologies.ViewModels
{
    public class UserViewModel
    {
        /// Application DB context        
        protected ApplicationDbContext _context { get; set; }

        /// User manager - attached to application DB context        
        protected UserManager<ApplicationUser> _userManager { get; set; }

        public UserViewModel()
        {
            _context = new ApplicationDbContext();
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));

        }
    }
        
}