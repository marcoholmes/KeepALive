using System.Web;
using System.Web.Optimization;

namespace KeepAlive
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                                                                     "~/Scripts/jquery-{version}.js",
                                                                     "~/Scripts/jquery.unobtrusive*"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryscripts").Include(
                        "~/js/main.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryvalunob").Include(
                        "~/Scripts/jquery.validate.unobtrusive.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            //bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
            //          "~/js/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/custom_bootstrap/custom-bootstrap.css",
                      "~/Content/css/custom/theme-orange-blu.css",
                      "~/Content/css/fontawesome-all.css"));
        }
    }
}
