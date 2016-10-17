using System.Web;
using System.Web.Optimization;

namespace demo1
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/Assets/html5shiv").Include(
            //    "~/Assets/scripts/html5shiv.min.js"));

            //bundles.Add(new ScriptBundle("~/Assets/respond").Include(
            //    "~/Assets/scripts/respond.min.js"));

            //bundles.Add(new ScriptBundle("~/Assets/jquery").Include(
            //            "~/Assets/scripts/jquery.js"));
            //bundles.Add(new ScriptBundle("~/Assets/jquery").Include(
            //            "~/Assets/scripts/jquery.validate.js"));

            //bundles.Add(new ScriptBundle("~/Assets/main").Include(
            //            "~/Assets/scripts/main.js"));

            bundles.Add(new ScriptBundle("~/Assets/scripts").Include(
                "~/Assets/scripts/html5shiv.min.js",
                "~/Assets/scripts/respond.min.js",
                "~/Assets/scripts/jquery.js",
                "~/Assets/scripts/jquery.validate.js",
                "~/Assets/scripts/main.js"));

            bundles.Add(new ScriptBundle("~/Assets/login").Include(
                        "~/Assets/scripts/login.js"));


            bundles.Add(new StyleBundle("~/Assets/css").Include(
                      "~/Assets/css/font-awesome.css",
                      "~/Assets/css/normalize.css",
                      "~/Assets/css/base.css",
                      "~/Assets/css/login.css"));


            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
        }
    }
}