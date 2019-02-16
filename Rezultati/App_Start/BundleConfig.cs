using BundleTransformer.Core.Builders;
using BundleTransformer.Core.Bundles;
using BundleTransformer.Core.Orderers;
using BundleTransformer.Core.Resolvers;
using System.Web;
using System.Web.Optimization;

namespace Rezultati
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
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                      "~/Scripts/umd/popper.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/MDB").Include(
                      "~/Content/css/mdb.css"));

            bundles.Add(new ScriptBundle("~/Scripts/MDB").Include(
                      "~/Scripts/js/mdb.js"));

            bundles.Add(new StyleBundle("~/Content/datatablesCss").Include(
                      "~/Content/css/addons/datatables.css",
                      "~/Content/css/addons/datatables-select.css"));

            bundles.Add(new ScriptBundle("~/Content/datatablesJs").Include(
                      "~/Scripts/js/addons/datatables.js",
                      "~/Scripts/js/addons/datatables-select.js"));
            bundles.Add(new ScriptBundle("~/Content/charts").Include(
                      "~/Scripts/js/modules/chart.js",
                      "~/Scripts/js/modules/enhanced-modals.js"));

            var nullBulider = new NullBuilder();
            var nullOrderer = new NullOrderer();

            BundleResolver.Current = new CustomBundleResolver();
            var commonStyleBundle = new CustomStyleBundle("~/Content/sass");
            var dataTablesBundle = new CustomStyleBundle("~/Content/datatablesSass");

            dataTablesBundle.Include("~/Content/scss/addons/_datatables.scss");
            dataTablesBundle.Include("~/Content/scss/addons/_datatables-select.scss");
            dataTablesBundle.Include("~/Content/scss/addons/_directives.scss");
            dataTablesBundle.Orderer = nullOrderer;
            commonStyleBundle.Include("~/Content/scss/mdb.scss");
            commonStyleBundle.Orderer = nullOrderer;
            bundles.Add(commonStyleBundle);
            bundles.Add(dataTablesBundle);
        }
    }
}
