using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;

namespace DLS_Technologies
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            /// Routes for API requests. 
            // Add API routes here if they differ from the default route. 

            config.MapHttpAttributeRoutes();           


            RouteTable.Routes.MapHttpRoute(
            name: "UpdateExpenseFormName",
            routeTemplate: "api/{controller}/{action}/{id}",
            defaults: new
                {
                    id = RouteParameter.Optional,
                    controller = "ExepenseForms",
                    action = "UpdateExpenseFormName"
                }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
