﻿using System.Web;
using System.Web.Optimization;

namespace Vidly
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ajax-helper.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/DataTables/dataTables.bootstrap.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/vidly-customer").Include(
                        "~/Scripts/vidly-customer.js"));

            bundles.Add(new ScriptBundle("~/bundles/vidly-movies").Include(
                        "~/Scripts/vidly-movies.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/bootstrap-lumen.css",
                       "~/Content/Site.css",
                       "~/Content/Utility.css",
                       "~/Content/loading-spinner.css",
                       "~/Content/DataTables/css/dataTables.bootstrap.css"
                       ));
        }
    }
}
