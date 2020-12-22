using System.Web;
using System.Web.Optimization;

namespace Point_of_sale_system
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

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/template/css").Include(
                      "~/assets/css/loader.css",
                      "~/bootstrap/css/bootstrap.min.css",
                      "~/assets/css/plugins.css",
                      "~/plugins/apex/apexcharts.css",
                      "~/assets/css/dashboard/dash_1.css",
                      "~/assets/css/dashboard/dash_2.css",
                      "~/plugins/table/datatable/datatables.css",
                      "~/plugins/table/datatable/custom_dt_html5.css",
                      "~/plugins/table/datatable/dt-global_style.css",
                      "~/plugins/dropify/dropify.min.css",
                      "~/assets/css/users/account-setting.css"
                ));
            bundles.Add(new ScriptBundle("~/template/Js").Include(
                      "~/assets/js/loader.js",
                      "~/assets/js/libs/jquery-3.1.1.min.js",
                      "~/bootstrap/js/popper.min.js",
                      "~/bootstrap/js/bootstrap.min.js",
                      "~/plugins/perfect-scrollbar/perfect-scrollbar.min.js",
                      "~/assets/js/app.js",
                      "~/assets/js/custom.js",
                      "~/plugins/apex/apexcharts.min.js",
                      "~/assets/js/dashboard/dash_1.js",
                      "~/assets/js/dashboard/dash_2.js",
                      "~/plugins/table/datatable/button-ext/dataTables.buttons.min.js",
                      "~/plugins/table/datatable/button-ext/jszip.min.js",
                      "~/plugins/table/datatable/button-ext/buttons.html5.min.js",
                      "~/plugins/table/datatable/button-ext/buttons.print.min.js",
                      "~/plugins/dropify/dropify.min.js",
                      "~/plugins/blockui/jquery.blockUI.min.js",
                      "~/assets/js/users/account-settings.js"
            ));
        }
    }
}
