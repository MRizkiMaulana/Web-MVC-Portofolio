using System.Web;
using System.Web.Optimization;

namespace Web_MVC_Portofolio
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

            bundles.Add(new Bundle("~/main/js").Include(
                        "~/Scripts/js/main.js"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/vendor/purecounter/purecounter_vanilla.js",
                      "~/Scripts/vendor/aos/aos.js",
                      "~/Scripts/vendor/bootstrap/js/bootstrap.bundle.min.js",
                      "~/Scripts/vendor/glightbox/js/glightbox.min.js",
                      "~/Scripts/vendor/isotope-layout/isotope.pkgd.min.js",
                      "~/Scripts/vendor/swiper/swiper-bundle.min.js",
                      "~/Scripts/vendor/typed.js/typed.min.js",
                      "~/Scripts/vendor/waypoints/noframework.waypoints.js"));

            bundles.Add(new StyleBundle("~/main/css").Include(
                        "~/Content/css/style.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/vendor/aos/aos.css",
                      "~/Content/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/vendor/bootstrap-icons/bootstrap-icons.css",
                      "~/Content/vendor/boxicons/css/boxicons.min.css",
                      "~/Content/vendor/glightbox/css/glightbox.min.css",
                      "~/Content/vendor/swiper/swiper-bundle.min.css"));
        }
    }
}
