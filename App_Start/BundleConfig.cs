using System.Web;
using System.Web.Optimization;

namespace IRRCMS
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap-rtl.js", "~/Scripts/hoverex.min.js",
                      "~/Scripts/hoverdir.js", "~/Scripts/isotope.min.js",
                      "~/Content/prettyphoto/js/prettyphoto.js", "~/Scripts/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-rtl.css",                     
                      "~/Content/prettyphoto/css/prettyphoto.css",
                      "~/Content/hoverex-all.css",
                      "~/Content/font-awesome.min.css",
                      "~/Fonts/vazir.css",
                      "~/Content/style.css",
                      "~/Content/main.css"));

            BundleTable.EnableOptimizations = false;

        }
    }
}
