using System.Web;
using System.Web.Optimization;

namespace DLS_Technologies
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // JavaScript Bundle. Added to _Layout partial. 
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery/jquery-{version}.js",
                        "~/Scripts/jquery/jquery-ui-{version}.js",
                        "~/Scripts/jquery/bootstrap.js",
                        "~/scripts/jquery/bootbox.js",
                        "~/Scripts/jquery/respond.js",
                        "~/scripts/jquery/toastr.js",
                        "~/scripts/jquery/toastr-options.js",
                        "~/content/datatables/datatables.min.js",
                        "~/scripts/formscripts/base/_sidenavbar.js",
                        "~/scripts/formscripts/base/search-box.js"
                        ));
                

            // jQuery Validation bundle. 
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/jquery/modernizr-*"));

            // CSS Bundle. 
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/bootstrap-flatly.css",
                      "~/Content/themes/base/base.css",
                      "~/Content/themes/base/jquery-ui.css",
                      "~/Content/themes/base/autocomplete.css",
                      "~/Content/themes/base/datepicker.css",
                      "~/content/DataTables/datatables.min.css",
                      "~/content/font-awesome/css/font-awesome.min.css",
                      "~/content/_sidenavbar.css",
                      "~/Content/toastr.css",
                      "~/Content/site.css"));
        }
    }
}
