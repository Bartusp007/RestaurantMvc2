using System.Web;
using System.Web.Optimization;

namespace RestaurantMvc.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            //bundles.Add(new ScriptBundle("~/bundles/jquerytimepicker").Include(
            //        "~/Scripts/jquery.timepicker.js"));
            //bundles.Add(new StyleBundle("~/bundles/jquerytimepickercss").Include(
            //        "~/Scripts/jquery.timepicker.css"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/toastr.css"));

            bundles.Add(new StyleBundle("~/Content/MyCss").Include(
                      "~/Content/MyCcc.css"));
            bundles.Add(new ScriptBundle("~/bundles/myScript").Include(
               "~/Scripts/myScript.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapdatetimepicker").Include(
                      "~/Scripts/bootstrap-datetimepicker.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap-datetimepicker").Include(
                     "~/Content/bootstrap-datetimepicker.css"));

            //Added for toaster
            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                "~/Scripts/toastr.js*",
                "~/Scripts/toastrImp.js"));
            bundles.Add(new StyleBundle("~/Content/simple-sidebar")
                .Include("~/Content/simple-sidebar.css"));

        }
    }
}
