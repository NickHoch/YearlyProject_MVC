using System.Web;
using System.Web.Optimization;

namespace Home3__MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                      "~/Scripts/popper.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css"));
            //bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
            //          "~/Scripts/buy.js",
            //          "~/Scripts/makeOrder.js"));
            //bundles.Add(new ScriptBundle("~/bundles/checkEmail").Include(
            //          ));
            //bundles.Add(new ScriptBundle("~/bundles/checkEditedEmail").Include(
            //          ));
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                      "~/Scripts/calcSum.js",
                      "~/Scripts/checkEmail.js",
                      "~/Scripts/delOrderItem.js",
                      "~/Scripts/editEmail.js",
                      "~/Scripts/orderActions.js"));
            bundles.Add(new ScriptBundle("~/bundles/adminScripts").Include(
                      "~/Scripts/checkEmail.js",
                      "~/Scripts/checkEditedEmail.js"));
        }
    }
}
