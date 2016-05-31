using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace BootstrapSupport
{
    public class BootstrapBundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js").Include(
                "~/Scripts/moment.js",
                "~/Scripts/moment-with-locales.js",
                "~/Scripts/moment-with-locales.min.js",
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/bootstrap-datetimepicker.js",
                "~/Scripts/chosen.jquery.js",
                "~/Scripts/jquery.maskedinput.js",
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/methods_pt.js",
                "~/Scripts/jquery.timer.js",
                "~/Scripts/base.js"
                ));

            bundles.Add(new StyleBundle("~/content/css").Include(
                "~/Content/Styles/bootstrap.css",
                "~/Content/Styles/bootstrap-datetimepicker.css",
                "~/content/Styles/base.css",
                "~/Content/Styles/body.css",
                "~/Content/Styles/bootstrap-responsive.css",
                "~/Content/Styles/bootstrap-mvc-validation.css"
                ));
        }
    }
}