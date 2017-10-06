using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DLS_Technologies
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            /// Add Routes so the browser displays and the user can see organized URLs instead of long query strings. 
            // Define the controller and the action for the route. 
            // Add UrlParameter as optional if the action doesnt need the parameter passed in through the URL. 

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            // Route for the AJAX call to keep the total cost updated on the ExpenseForm Index when an expense is deleted from a form.
            routes.MapRoute(
                name: "UpdateTotalCost",
                url: "ExpenseForms/UpdateTotalCost",
                defaults: new { controller = "ExpenseForms", action = "UpdateTotalCost",  }
            );

            // Route for AJAX call when clicking on a row in the DataTable on the ShowExpenses Form. 
            routes.MapRoute(
                name: "ShowExpenses",
                url: "ExpenseForms/ShowExpenses/{expenseFormId}",
                defaults: new { controller = "ExpenseForms", action = "ShowExpenses" }
            );

            

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
