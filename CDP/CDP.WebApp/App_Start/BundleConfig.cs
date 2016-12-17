using System.Web;
using System.Web.Optimization;

namespace CDP.WebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            AddDefaultIgnorePatterns(bundles.IgnoreList);
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                   .Include("~/Content/bower_components/jquery/dist/jquery.js",
                            "~/Content/bower_components/bootstrap/dist/js/bootstrap.min.js",
                            "~/Content/bower_components/slimscroll/jquery.slimscroll.js",
                            "~/Content/bower_components/select2/dist/js/select2.min.js",
                            "~/Content/bower_components/jquery-icheck/icheck.min.js",
                            "~/Content/bower_components/parsleyjs/dist/parsley.js",
                            "~/Content/bower_components/bootstrap-3-timepicker/js/bootstrap-timepicker.js",
                            "~/Content/bower_components/bootstrap-datepicker/js/bootstrap-datepicker.js",
                            "~/Content/bower_components/bootstrap-jasny/js/fileinput.js",
                            "~/Content/bower_components/jquery-simplecolorpicker/jquery.simplecolorpicker.js",
                            "~/Content/bower_components/datatables/media/js/jquery.dataTables.min.js",
                            "~/Content/bower_components/datatables-plugins/integration/bootstrap/3/dataTables.bootstrap.js",
                            "~/Content/bower_components/datatables-helper/js/datatables-helper.js",
                            "~/Content/global/js/mvpready-core.js",
                            "~/Content/global/js/mvpready-helpers.js",
                            "~/Scripts/mvpready-admin.js",
                            "~/Content/global/js/demos/form-pickers.js",
                            "~/Content/bower_components/select2/dist/js/i18n/es.js"));

            //.IncludeDirectory("~/Content/bower_components/jquery", "*.js", true)
            //.IncludeDirectory("~/Scripts", "*.js", true)
            //.IncludeDirectory("~/Content/bower_components/jquery/src", "*.js", true)
            //.IncludeDirectory("~/Content/bower_components/datatables", "*.js", true));

            //.Include("~/Scripts/jquery-{version}.js",
            //            "~/Content/bower_components/jquery/dist/jquery.js",
            //            "~/Content/bower_components/jquery/src/jquery.js",
            //            "~/Content/bower_components/select2/src/js/jquery.select2.js",
            //            "~/Content/global/js/demos/form-pickers.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/bundles/css")
                .Include("~/Content/bower_components/fontawesome/css/font-awesome.min.css",
                         "~/Content/bower_components/bootstrap/dist/css/bootstrap.min.css",
                         "~/Content/bower_components/select2/dist/css/select2.min.css",
                         "~/Content/bower_components/select2-bootstrap-theme/dist/select2-bootstrap.min.css",
                         "~/Content/bower_components/jquery-icheck/skins/minimal/_all.css",
                         "~/Content/bower_components/bootstrap-3-timepicker/css/bootstrap-timepicker.css",
                         "~/Content/bower_components/bootstrap-datepicker/css/datepicker3.css",
                         "~/Content/bower_components/bootstrap-jasny/dist/css/jasny-bootstrap.css",
                         "~/Content/bower_components/jquery-simplecolorpicker/jquery.simplecolorpicker.css",
                         "~/Content/css/mvpready-admin.css"));






            BundleTable.EnableOptimizations = true;




            //.Include(
            //      "~/Content/bootstrap.css",
            //      "~/Content/site.css",
            //      "~/Content/css/mvpready-admin.css",
            //      "~/Content/bower_components/select2-bootstrap-theme/dist/select2-bootstrap.min.css",
            //      "~/Content/bower_components/select2/dist/css/select2.min.css",
            //      "~/Content/bower_components/jquery-icheck/skins/minimal/_all.css",
            //      "~/Content/bower_components/fontawesome/css/font-awesome.min.css",
            //      "~/Content/bower_components/bootstrap-3-timepicker/css/bootstrap-timepicker.css",
            //      "~/Content/bower_components/bootstrap/dist/css/bootstrap.min.css",
            //      "~/Content/css/mvpready-admin.css",
            //      "~/Content/bower_components/bootstrap-jasny/dist/css/jasny-bootstrap.css",
            //      "~/Content/bower_components/bootstrap-datepicker/css/datepicker3.css",
            //      "~/Content/bower_components/jquery-simplecolorpicker/jquery.simplecolorpicker.css",
            //      "~/content/bower_components/bootstrap-datepicker/css/*.css"));
        }

        public static void AddDefaultIgnorePatterns(IgnoreList ignoreList)
        {
            if (ignoreList == null)
            {
                throw new System.ArgumentNullException("ignoreList");
            }

            ignoreList.Ignore("*.intellisense.js");
            ignoreList.Ignore("*-vsdoc.js");
            ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
            //ignoreList.Ignore("*.min.js", OptimizationMode.WhenDisabled);
            //ignoreList.Ignore("*.min.css", OptimizationMode.WhenDisabled);
        }
    }
}
