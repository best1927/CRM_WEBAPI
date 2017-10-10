using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

/// <summary>
/// Summary description for BundleConfig
/// </summary>
public class BundleConfig
{
    public static void RegisterBundles(BundleCollection bundles)
    {
        bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
        //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/moment.min.js",
        //    "~/Scripts/bootstrap.min.js",
        //      "~/Scripts/bootstrap-datetimepicker.js",
        //    "~/Scripts/jojo_bootstrap/bootstrap-datepicker.js",
        //      "~/Scripts/jojo_bootstrap/bootstrap-datepicker-thai.js",
        //     "~/Scripts/jojo_bootstrap/locales/bootstrap-datepicker.th.js"
        //    ));

        //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/moment.js",
        //    "~/Scripts/moment-with-locales.js",
        //    "~/Scripts/moment-timezone-with-data.js",
        //   "~/Scripts/bootstrap.min.js",
        //     "~/Scripts/bootstrap-datetimepicker.js"
        //   ));
        bundles.Add(new ScriptBundle("~/bundles/moment-with-locales").Include("~/Scripts/moment-with-locales.js"));
        bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.min.js",
          "~/Scripts/bootstrap-datetimepicker.js"
        ));
        bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));
        bundles.Add(new ScriptBundle("~/bundles/app").Include("~/dist/js/app.js"));
        bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include("~/Scripts/jquery-ui.1.11.1.min.js"));
        bundles.Add(new ScriptBundle("~/bundles/autonumeric").Include("~/Scripts/autoNumeric.js"));
       
        bundles.Add(new ScriptBundle("~/bundles/common").Include("~/Scripts/common.js"));
        bundles.Add(new ScriptBundle("~/bundles/plugins").Include("~/plugins/iCheck/icheck.min.js",
            "~/plugins/underscore/underscore-min.js",
            "~/plugins/iCheck/icheck.min.js",
            "~/plugins/waitMe/waitMe.min.js",
            "~/plugins/sweet-alert/sweet-alert.min.js",
            "~/plugins/jQuery-Autocomplete-master/jquery.autocomplete.js",
            "~/plugins/jquery.sessionTimeout/jquery.sessionTimeout.min.js"
            ));
        bundles.Add(new ScriptBundle("~/bundles/custom").Include("~/Scripts/custom.js"));

        /**************************** CSS ***********************************/
        //  bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css"));
    }
}






