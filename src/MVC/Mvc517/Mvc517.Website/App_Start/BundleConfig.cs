using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Mvc517.Website
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Scripts/npm/jquery/jquery.min.js",
                        "~/Scripts/npm/bootstrap/bootstrap.min.js",
                        "~/Scripts/npm/vue/vue.min.js"));


            bundles.Add(new StyleBundle("~/bundles/css").Include(
                    "~/Content/bootstrap.min.css",
                    "~/Content/site.css"
                    ));

            //Minify
            BundleTable.EnableOptimizations = true;
        }
    }
}