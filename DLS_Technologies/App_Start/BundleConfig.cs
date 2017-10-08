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
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/scripts/bootbox.js",
                        "~/Scripts/respond.js",
                        "~/scripts/datatables/jquery.datatables.js",
                        "~/scripts/datatables/datatables.bootstrap.js",
                        "~/Content/DataTables-Buttons/datatables.min.js",
                        "~/scripts/_sidenavbar.js"
                        ));

            // jQuery Validation bundle. 
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            // CSS Bundle. 
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-flatly.css",
                      "~/Content/themes/base/jquery-ui.css",
                      "~/Content/themes/base/base.css",
                      "~/Content/themes/base/datepicker.css",
                      "~/content/datatables/css/datatables.bootstrap.css",
                      "~/content/datatables/css/buttons.dataTables.min.css",
                      "~/content/DataTables-Buttons/datatables.min.css",
                      "~/content/font-awesome/css/font-awesome.min.css",
                      "~/Content/site.css",
                      "~/content/_sidenavbar.css"));
        }
    }
}
