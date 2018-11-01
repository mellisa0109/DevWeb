using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace RecoWeb.WebUI.App_Start
{
    public class DevExtremeBundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var scriptBundle = new ScriptBundle("~/Scripts/DevExtremeBundle");

            var styleBundle = new StyleBundle("~/Content/DevExtremeBundle");
            //var styleBundle = new StyleBundle("~/Content/DevExtremeBundlePurple");
            //var styleBundle = new StyleBundle("~/Content/DevExtremeBundleNormal");
            // CLDR scripts
            scriptBundle
                .Include("~/Scripts/devExtreme/cldr.js")
                .Include("~/Scripts/devExtreme/cldr/event.js")
                .Include("~/Scripts/devExtreme/cldr/supplemental.js")
                .Include("~/Scripts/devExtreme/cldr/unresolved.js");
            // Globalize 1.x
            scriptBundle
                .Include("~/Scripts/devExtreme/globalize.js")
                .Include("~/Scripts/devExtreme/globalize/message.js")
                .Include("~/Scripts/devExtreme/globalize/number.js")
                .Include("~/Scripts/devExtreme/globalize/currency.js")
                .Include("~/Scripts/devExtreme/globalize/date.js");
            // NOTE: jQuery may already be included in the default script bundle. Check the BundleConfig.cs file​​​
            // scriptBundle
            //    .Include("~/Scripts/jquery-1.10.2.js");
            // JSZip for client-side exporting
            // scriptBundle
            //    .Include("~/Scripts/jszip.js");
            // DevExtreme + extensions
            scriptBundle
                .Include("~/Scripts/devExtreme/dx.all.js")
                .Include("~/Scripts/devExtreme/dx.aspnet.data.js")
                .Include("~/Scripts/devExtreme/dx.aspnet.mvc.js");
            // VectorMap data
            // scriptBundle
            //    .Include("~/Scripts/vectormap-data/africa.js")
            //    .Include("~/Scripts/vectormap-data/canada.js")
            //    .Include("~/Scripts/vectormap-data/eurasia.js")
            //    .Include("~/Scripts/vectormap-data/europe.js")
            //    .Include("~/Scripts/vectormap-data/usa.js")
            //    .Include("~/Scripts/vectormap-data/world.js");
            // DevExtreme themes              
            styleBundle
                .Include("~/Content/devExtreme/dx.common.css")
                .Include("~/Content/devExtreme/dx.material.blue.light.css");
            //.Include("~/Content/devExtreme/dx.material.lime.light.css");
            //.Include("~/Content/devExtreme/dx.material.purple.light.css");
            //.Include("~/Content/devExtreme/dx.material.teal.light.css");

            //이 아래는 Module/Views/Shared/_layout.cshtml에 붙여넣으면 됨(테마).
            //<link href = "@Url.Action("devExtreme/dx.material.lime.light.css","Content")" rel="stylesheet" type="text/css" />
            //<link href = "@Url.Action("devExtreme/dx.material.teal.light.css","Content")" rel="stylesheet" type="text/css" />
            //<link href = "@Url.Action("devExtreme/dx.material.purple.light.css","Content")" rel="stylesheet" type="text/css" />

                                 bundles.Add(scriptBundle);
            bundles.Add(styleBundle);
#if !DEBUG
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}