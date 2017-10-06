using System.Web;
using System.Web.Mvc;

namespace DLS_Technologies
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            
            // Turns on setting which requires you to be logged in to view any web page. 
            // Add DataAnnotation to controller actions you want to be accessible when a user is not logged in. 
            filters.Add(new AuthorizeAttribute());
        }
    }
}
