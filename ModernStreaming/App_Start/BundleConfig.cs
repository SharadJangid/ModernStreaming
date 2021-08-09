using System.Collections.Generic;
using System.Web;
using System.Web.Optimization;

namespace ModernStreaming
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            // styles for the layout page
            var bundle = new StyleBundle("~/bundles/mainCss").Include(
                "~/Content/admin.css",
                "~/Content/main.min.css",
                "~/Content/jquery.fancybox.min.css",
                "~/Content/daterangepicker.css",
                "~/Content/jquery-confirm.css"
                );
            bundle.Orderer = new AsIsBundleOrderer();
            bundles.Add(bundle);

            var bundle_jquery = new ScriptBundle("~/bundles/jqueryJS").Include(
                    "~/Scripts/jquery.min.js"
                );
            bundles.Add(bundle_jquery);

            // all javascript jquery bundles for layout page
            var bundle_main = new ScriptBundle("~/bundles/mainJS").Include(
                "~/Scripts/bootstrap.bundle.min.js",
                "~/Scripts/jquery.fancybox.pack.js",
                "~/Scripts/jquery.fancybox.min.js",
                "~/Scripts/jquery-confirm.js",
                "~/Scripts/main.js",
                "~/Scripts/admin.js",
                "~/Scripts/script.js",
                "~/Scripts/CommonFunction.js"
              );
            bundles.Add(bundle_main);


            // Script bundle for Date
            var bundle_5 = new ScriptBundle("~/bundles/dateJS").Include(
                "~/Scripts/moment.min.js",
                "~/Scripts/daterangepicker.js"
                );
            bundle_5.Orderer = new AsIsBundleOrderer();
            bundles.Add(bundle_5);


            // styles for the layout page
            var bundle_css = new StyleBundle("~/bundles/Content").Include(
                "~/Content/admin.css",
                "~/Content/main.min.css",
                "~/Content/jquery.fancybox.min.css"
                );
            bundle_css.Orderer = new AsIsBundleOrderer();
            bundles.Add(bundle);

            // all javascript jquery bundles for layout page
            var bundle_11 = new ScriptBundle("~/bundles/Scripts").Include(
                "~/Scripts/jquery.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/jquery.fancybox.min.js",
                "~/Scripts/main.js",
                "~/Scripts/admin.js"
                );

            bundle_11.Orderer = new AsIsBundleOrderer();
            bundles.Add(bundle_11);

            // Script bundle for Form Page
            var bundle_7 = new ScriptBundle("~/bundles/PageScript").Include(
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/jquery.validate.globalize.js"
                );
            bundle_7.Orderer = new AsIsBundleOrderer();
            bundles.Add(bundle_7);



            BundleTable.EnableOptimizations = false;
        }

    }

    class AsIsBundleOrderer : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }
}