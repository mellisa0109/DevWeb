﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using DevExtreme.AspNet.Mvc;
    
    #line 3 "..\..\Views\Shared\_Layout.cshtml"
    using RecoWeb.Domain.LocalResource;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\Shared\_Layout.cshtml"
    using RecoWeb.Module;
    
    #line default
    #line hidden
    
    #line 1 "..\..\Views\Shared\_Layout.cshtml"
    using RecoWeb.Module.Infrastructure.Helper;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/_Layout.cshtml")]
    public partial class _Views_Shared__Layout_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Shared__Layout_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 5 "..\..\Views\Shared\_Layout.cshtml"
  
    ViewBag.Theme = "~/Content/dx.material.purple.light.css";

            
            #line default
            #line hidden
WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <meta");

WriteLiteral(" http-equiv=\"Content-Type\"");

WriteLiteral(" content=\"text/html; charset=utf-8\"");

WriteLiteral(" />\r\n    <meta");

WriteLiteral(" charset=\"utf-8\"");

WriteLiteral(" />\r\n    <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width, initial-scale=1.0\"");

WriteLiteral(">\r\n    <meta");

WriteLiteral(" http-equiv=\"X-UA-Compatible\"");

WriteLiteral(" content=\"IE=edge\"");

WriteLiteral(">\r\n    <title>");

            
            #line 15 "..\..\Views\Shared\_Layout.cshtml"
      Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral("</title>\r\n\r\n");

            
            #line 17 "..\..\Views\Shared\_Layout.cshtml"
    
            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\Shared\_Layout.cshtml"
     if (IsSectionDefined("Styles"))
    {
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\Shared\_Layout.cshtml"
Write(RenderSection("Styles", required: false));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\Shared\_Layout.cshtml"
                                              }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 20 "..\..\Views\Shared\_Layout.cshtml"
    
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\Shared\_Layout.cshtml"
     if (IsSectionDefined("scripts"))
    {
            
            #line default
            #line hidden
            
            #line 21 "..\..\Views\Shared\_Layout.cshtml"
Write(RenderSection("scripts", required: false));

            
            #line default
            #line hidden
            
            #line 21 "..\..\Views\Shared\_Layout.cshtml"
                                               }

            
            #line default
            #line hidden
WriteLiteral("\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 678), Tuple.Create("\"", 730)
            
            #line 23 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 684), Tuple.Create<System.Object, System.Int32>(Url.Content("../Scripts/jquery-3.1.1.min.js")
            
            #line default
            #line hidden
, 684), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 777), Tuple.Create("\"", 832)
            
            #line 24 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 783), Tuple.Create<System.Object, System.Int32>(Url.Content("../Scripts/jquery.validate.min.js")
            
            #line default
            #line hidden
, 783), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 879), Tuple.Create("\"", 942)
            
            #line 25 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 885), Tuple.Create<System.Object, System.Int32>(Url.Content("../Scripts/jquery.unobtrusive-ajax.min.js")
            
            #line default
            #line hidden
, 885), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 989), Tuple.Create("\"", 1057)
            
            #line 27 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 996), Tuple.Create<System.Object, System.Int32>(Url.Action("plugins/jquery-ui/jquery-ui.min.css", "Scripts")
            
            #line default
            #line hidden
, 996), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 1107), Tuple.Create("\"", 1157)
            
            #line 29 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 1114), Tuple.Create<System.Object, System.Int32>(Url.Action("bootstrap.min.css", "Content")
            
            #line default
            #line hidden
, 1114), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 1205), Tuple.Create("\"", 1249)
            
            #line 30 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 1212), Tuple.Create<System.Object, System.Int32>(Url.Action("animate.css", "Content")
            
            #line default
            #line hidden
, 1212), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 1297), Tuple.Create("\"", 1339)
            
            #line 31 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 1304), Tuple.Create<System.Object, System.Int32>(Url.Action("style.css", "Content")
            
            #line default
            #line hidden
, 1304), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 1387), Tuple.Create("\"", 1434)
            
            #line 32 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 1394), Tuple.Create<System.Object, System.Int32>(Url.Action("reco_style.css", "Content")
            
            #line default
            #line hidden
, 1394), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 1486), Tuple.Create("\"", 1535)
            
            #line 34 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 1492), Tuple.Create<System.Object, System.Int32>(Url.Content("../Scripts/bootstrap.min.js")
            
            #line default
            #line hidden
, 1492), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 1584), Tuple.Create("\"", 1651)
            
            #line 36 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 1590), Tuple.Create<System.Object, System.Int32>(Url.Content("../Scripts/plugins/metisMenu/metisMenu.min.js")
            
            #line default
            #line hidden
, 1590), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 1700), Tuple.Create("\"", 1757)
            
            #line 38 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 1706), Tuple.Create<System.Object, System.Int32>(Url.Content("../Scripts/plugins/pace/pace.min.js")
            
            #line default
            #line hidden
, 1706), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 1806), Tuple.Create("\"", 1882)
            
            #line 40 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 1812), Tuple.Create<System.Object, System.Int32>(Url.Content("../Scripts/plugins/slimScroll/jquery.slimscroll.min.js")
            
            #line default
            #line hidden
, 1812), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 1931), Tuple.Create("\"", 1992)
            
            #line 42 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 1937), Tuple.Create<System.Object, System.Int32>(Url.Content("../Content/plugins/jqGrid/ui.jqgrid.css")
            
            #line default
            #line hidden
, 1937), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 2039), Tuple.Create("\"", 2109)
            
            #line 43 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 2045), Tuple.Create<System.Object, System.Int32>(Url.Content("../Scripts/plugins/jqGrid/i18n/grid.locale-en.js")
            
            #line default
            #line hidden
, 2045), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 2156), Tuple.Create("\"", 2224)
            
            #line 44 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 2162), Tuple.Create<System.Object, System.Int32>(Url.Content("../Scripts/plugins/jqGrid/jquery.jqGrid.min.js")
            
            #line default
            #line hidden
, 2162), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 2273), Tuple.Create("\"", 2321)
            
            #line 46 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 2279), Tuple.Create<System.Object, System.Int32>(Url.Content("../Scripts/app/inspinia.js")
            
            #line default
            #line hidden
, 2279), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 2370), Tuple.Create("\"", 2430)
            
            #line 48 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 2376), Tuple.Create<System.Object, System.Int32>(Url.Content("../Scripts/bootstrap-datepicker.min.js")
            
            #line default
            #line hidden
, 2376), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 2477), Tuple.Create("\"", 2548)
            
            #line 49 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 2483), Tuple.Create<System.Object, System.Int32>(Url.Content("../Scripts/locales/bootstrap-datepicker.ko.min.js")
            
            #line default
            #line hidden
, 2483), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 2593), Tuple.Create("\"", 2683)
            
            #line 50 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 2600), Tuple.Create<System.Object, System.Int32>(Url.Action("plugins/bootstrap-datepicker/bootstrap-datepicker.min.css", "Content")
            
            #line default
            #line hidden
, 2600), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 2735), Tuple.Create("\"", 2806)
            
            #line 52 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 2741), Tuple.Create<System.Object, System.Int32>(Url.Content("../Scripts/locales/bootstrap-datepicker.ko.min.js")
            
            #line default
            #line hidden
, 2741), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 2853), Tuple.Create("\"", 2920)
            
            #line 54 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 2860), Tuple.Create<System.Object, System.Int32>(Url.Action("font-awesome/css/font-awesome.min.css","fonts")
            
            #line default
            #line hidden
, 2860), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 2972), Tuple.Create("\"", 3016)
            
            #line 56 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 2978), Tuple.Create<System.Object, System.Int32>(Url.Content("../Scripts/app/reco.js")
            
            #line default
            #line hidden
, 2978), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n\r\n    <!-- DevExtreme Style-->\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 3093), Tuple.Create("\"", 3149)
            
            #line 59 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 3100), Tuple.Create<System.Object, System.Int32>(Url.Action("devExtreme/dx.common.css","Content")
            
            #line default
            #line hidden
, 3100), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 3197), Tuple.Create("\"", 3266)
            
            #line 60 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 3204), Tuple.Create<System.Object, System.Int32>(Url.Action("devExtreme/dx.material.blue.light.css","Content")
            
            #line default
            #line hidden
, 3204), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n\r\n    <!-- DevExtreme Javascript-->\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 3353), Tuple.Create("\"", 3404)
            
            #line 63 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 3359), Tuple.Create<System.Object, System.Int32>(Url.Content("../Scripts/devExtreme/cldr.js")
            
            #line default
            #line hidden
, 3359), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 3451), Tuple.Create("\"", 3508)
            
            #line 64 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 3457), Tuple.Create<System.Object, System.Int32>(Url.Content("../Scripts/devExtreme/cldr/event.js")
            
            #line default
            #line hidden
, 3457), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 3555), Tuple.Create("\"", 3619)
            
            #line 65 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 3561), Tuple.Create<System.Object, System.Int32>(Url.Content("../Scripts/devExtreme/cldr/supplemental.js")
            
            #line default
            #line hidden
, 3561), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 3666), Tuple.Create("\"", 3728)
            
            #line 66 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 3672), Tuple.Create<System.Object, System.Int32>(Url.Content("../Scripts/devExtreme/cldr/unresolved.js")
            
            #line default
            #line hidden
, 3672), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 3775), Tuple.Create("\"", 3831)
            
            #line 67 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 3781), Tuple.Create<System.Object, System.Int32>(Url.Content("../Scripts/devExtreme/globalize.js")
            
            #line default
            #line hidden
, 3781), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 3878), Tuple.Create("\"", 3942)
            
            #line 68 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 3884), Tuple.Create<System.Object, System.Int32>(Url.Content("../Scripts/devExtreme/globalize/message.js")
            
            #line default
            #line hidden
, 3884), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 3989), Tuple.Create("\"", 4052)
            
            #line 69 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 3995), Tuple.Create<System.Object, System.Int32>(Url.Content("../Scripts/devExtreme/globalize/number.js")
            
            #line default
            #line hidden
, 3995), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 4099), Tuple.Create("\"", 4164)
            
            #line 70 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 4105), Tuple.Create<System.Object, System.Int32>(Url.Content("../Scripts/devExtreme/globalize/currency.js")
            
            #line default
            #line hidden
, 4105), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 4211), Tuple.Create("\"", 4272)
            
            #line 71 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 4217), Tuple.Create<System.Object, System.Int32>(Url.Content("../Scripts/devExtreme/globalize/date.js")
            
            #line default
            #line hidden
, 4217), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 4319), Tuple.Create("\"", 4372)
            
            #line 72 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 4325), Tuple.Create<System.Object, System.Int32>(Url.Content("../Scripts/devExtreme/dx.all.js")
            
            #line default
            #line hidden
, 4325), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 4419), Tuple.Create("\"", 4480)
            
            #line 73 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 4425), Tuple.Create<System.Object, System.Int32>(Url.Content("../Scripts/devExtreme/dx.aspnet.data.js")
            
            #line default
            #line hidden
, 4425), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 4527), Tuple.Create("\"", 4587)
            
            #line 74 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 4533), Tuple.Create<System.Object, System.Int32>(Url.Content("../Scripts/devExtreme/dx.aspnet.mvc.js")
            
            #line default
            #line hidden
, 4533), false)
);

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n\r\n\r\n</head>\r\n<body");

WriteAttribute("class", Tuple.Create(" class=\"", 4641), Tuple.Create("\"", 4662)
            
            #line 78 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 4649), Tuple.Create<System.Object, System.Int32>(ViewBag.Skin
            
            #line default
            #line hidden
, 4649), false)
);

WriteLiteral(">\r\n    <!-- Wrapper-->\r\n    <div");

WriteLiteral(" id=\"wrapper\"");

WriteAttribute("class", Tuple.Create(" class=\"", 4708), Tuple.Create("\"", 4733)
            
            #line 80 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 4716), Tuple.Create<System.Object, System.Int32>(Html.PageClass()
            
            #line default
            #line hidden
, 4716), false)
);

WriteLiteral(">\r\n\r\n        <!-- Navigation -->\r\n");

            
            #line 83 "..\..\Views\Shared\_Layout.cshtml"
        
            
            #line default
            #line hidden
            
            #line 83 "..\..\Views\Shared\_Layout.cshtml"
         if (Session["Menu"] == null)
        {

        }
        else
        {
            
            
            #line default
            #line hidden
            
            #line 89 "..\..\Views\Shared\_Layout.cshtml"
       Write(Html.Partial("_Navigation", Session["Menu"]));

            
            #line default
            #line hidden
            
            #line 89 "..\..\Views\Shared\_Layout.cshtml"
                                                         
        }

            
            #line default
            #line hidden
WriteLiteral("\r\n        ");

WriteLiteral("\r\n\r\n        <!-- Page wraper -->\r\n        <div");

WriteLiteral(" id=\"page-wrapper\"");

WriteLiteral(" style=\"background-color:#f3f3f4;\"");

WriteLiteral(">\r\n\r\n            <!-- Top Navbar -->\r\n");

WriteLiteral("            ");

            
            #line 98 "..\..\Views\Shared\_Layout.cshtml"
       Write(Html.Partial("_TopNavbar"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n            <!-- Main view  -->\r\n");

WriteLiteral("            ");

            
            #line 101 "..\..\Views\Shared\_Layout.cshtml"
       Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral("\r\n            <!-- Footer -->\r\n");

WriteLiteral("            ");

            
            #line 103 "..\..\Views\Shared\_Layout.cshtml"
       Write(Html.Partial("_Footer"));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <!-- End page wrapper-->\r\n    </div>\r\n    <!-- End wrap" +
"per-->\r\n    ");

WriteLiteral("\r\n\r\n\r\n\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n        $().ready(function () {\r\n            $(\".btn-language-transform\").clic" +
"k(function (e,s) {\r\n                var originSrc;\r\n                var route;\r\n" +
"                var country;\r\n                var img;\r\n\r\n                $(this" +
").toggleClass(\'clicked\').siblings().removeClass(\'clicked\');\r\n                img" +
" = $(this).children()[0];\r\n                originSrc = $(img).attr(\'src\');\r\n    " +
"            route = originSrc.split(\'_\')[0];\r\n                country = route.sp" +
"lit(\'/\')[3];\r\n                $(\".language-\" + country + \" img\").attr(\'src\', \'/C" +
"ontent/Images/\' + country + \'_clicked_32.png\');\r\n                //$(img).attr(\'" +
"src\', \"/Content/Images/\" + country + \"_clicked_32.png\");\r\n\r\n                $(th" +
"is).siblings().each(function (number, item) {\r\n                    img = $(this)" +
".children()[0];\r\n                    originSrc = $(img).attr(\'src\');\r\n          " +
"          route = originSrc.split(\'_\')[0];\r\n                    country = route." +
"split(\'/\')[3];\r\n                    $(\".language-\" + country + \" img\").attr(\'src" +
"\', \"/Content/Images/\" + country + \"_32.png\");\r\n                });\r\n            " +
"});\r\n\r\n            //값으로 삭제,찾기가 안되서 프로토 타입 메서드 추가.\r\n            // 변수명.deleteVal" +
"ue(값)\r\n            // 리턴 값 없음.\r\n            Array.prototype.deleteValue = functi" +
"on (s) {\r\n                str = String(s);\r\n                if (this.includes(s)" +
") {\r\n                    let num = this.indexOf(str);\r\n                    retur" +
"n this.splice(num, 1);\r\n                } else {\r\n                    return und" +
"efined;\r\n                }\r\n            };\r\n\r\n            // 변수명.findValue(값)\r\n " +
"           // return 값\r\n            Array.prototype.findValue = function (s) {\r\n" +
"                str = String(s);\r\n                if (this.includes(s)) {\r\n     " +
"               let num = this.indexOf(str);\r\n                    return this[num" +
"];\r\n                } else {\r\n                    return undefined;\r\n           " +
"     }\r\n            };\r\n\r\n        });\r\n    </script>\r\n\r\n</body>\r\n</html>");

        }
    }
}
#pragma warning restore 1591