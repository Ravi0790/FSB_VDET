﻿using System.Web;
using System.Web.Optimization;

namespace FSBUI
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

            bundles.Add(new ScriptBundle("~/bundles/fsbscript").Include(
                        "~/Scripts/common.js",                        
                        "~/Scripts/toastr.js",
                        "~/Scripts/bootbox.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/fusionscript").Include(
                        "~/Scripts/fusionchart/fusioncharts.js",
                        "~/Scripts/fusionchart/fusioncharts.theme.fusion.js",
                        "~/Scripts/fusionchart/fusioncharts.jqueryplugin.min.js"
                        ));



            bundles.Add(new ScriptBundle("~/bundles/bakeryscript").Include(
                        "~/Scripts/waste.js",
                        "~/Scripts/bakery.js"
                        
                        
                        ));

            bundles.Add(new ScriptBundle("~/bundles/packagingscript").Include(
                       "~/Scripts/waste.js",
                       "~/Scripts/packaging.js"


                       ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/fsb_stylesheet.css",
                      "~/Content/ripple.min.css",
                      "~/Content/toastr.css"
                      ));
        }
    }
}
