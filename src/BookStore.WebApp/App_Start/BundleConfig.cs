using System.Web;
using System.Web.Optimization;

namespace BookStore.WebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.cookie.js",
                        "~/Scripts/jquery.jcarousel.js",
                        "~/Scripts/carousel.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/style.css",
                      "~/Content/puritan.css",
                      "~/Content/bootstrap-grid.css",
                      "~/Content/bootstrap-reboot.css",
                      "~/Content/Site.css",
                      "~/Content/menu.css"));
            bundles.Add(new ScriptBundle("~/bundles/menu").Include(
                "~/Scripts/Menu.js"));
            bundles.Add(new ScriptBundle("~/bundles/shim").Include(
                "~/Scripts/es5-shim.js"));
        }
    }
}
