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
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            

            routes.MapRoute(
                name: "UpdateTotalCost",
                url: "ExpenseForms/UpdateTotalCost",
                defaults: new { controller = "ExpenseForms", action = "UpdateTotalCost",  }
            );

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
