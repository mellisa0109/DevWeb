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
    
    #line 1 "..\..\Views\Shared\_LoginPartial.cshtml"
    using System.Globalization;
    
    #line default
    #line hidden
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    
    #line 2 "..\..\Views\Shared\_LoginPartial.cshtml"
    using System.Threading;
    
    #line default
    #line hidden
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
    
    #line 3 "..\..\Views\Shared\_LoginPartial.cshtml"
    using Microsoft.AspNet.Identity;
    
    #line default
    #line hidden
    using RecoWeb.Module;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/_LoginPartial.cshtml")]
    public partial class _Views_Shared__LoginPartial_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Shared__LoginPartial_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\Shared\_LoginPartial.cshtml"
   

    var south_korea = Url.Content("~/Content/Images/south-korea_clicked_32.png");
    var usa = Url.Content("~/Content/Images/usa_clicked_32.png");
    if (Session["CurrentCulture"] != null)
    {
        if (Session["CurrentCulture"].ToString() == "0")
        {
            south_korea = Url.Content("~/Content/Images/south-korea_32.png");
        }
        else if (Session["CurrentCulture"].ToString() == "1")
        {
            usa = Url.Content("~/Content/Images/usa_32.png");
        }
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 21 "..\..\Views\Shared\_LoginPartial.cshtml"
 if (Request.IsAuthenticated)
{
    using (Html.BeginForm("LogOff", "Account", FormMethod.Post, new { id = "logoutForm", @class = "navbar-right" }))
    {
        
            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\Shared\_LoginPartial.cshtml"
   Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\Shared\_LoginPartial.cshtml"
                                

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"nav navbar-top-links navbar-right nav-only-PC\"");

WriteLiteral(" style=\"margin-right:20px;\"");

WriteLiteral(">\r\n            <li");

WriteLiteral(" class=\"dropdown\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" class=\"dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(" style=\"color:#ffffff; background-color:#f39c12;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-user\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral("></i><i");

WriteLiteral(" class=\"fa fa-caret-down\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral("></i></a>\r\n                <ul");

WriteLiteral(" class=\"dropdown-menu dropdown-alerts animated fadeInRight\"");

WriteLiteral(">\r\n                    <li>\r\n                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">");

            
            #line 31 "..\..\Views\Shared\_LoginPartial.cshtml"
                               Write(User.Identity.Name);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                    </li>\r\n                    <li");

WriteLiteral(" class=\"divider\"");

WriteLiteral("></li>\r\n                    <li>\r\n                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1460), Tuple.Create("\"", 1506)
            
            #line 35 "..\..\Views\Shared\_LoginPartial.cshtml"
, Tuple.Create(Tuple.Create("", 1467), Tuple.Create<System.Object, System.Int32>(Url.Action("ManagePassword","Account")
            
            #line default
            #line hidden
, 1467), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-key\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral("></i> 비밀번호 변경</a>\r\n                    </li>\r\n                    <li");

WriteLiteral(" class=\"divider\"");

WriteLiteral("></li>\r\n                    <li>\r\n                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 1692), Tuple.Create("\"", 1731)
            
            #line 39 "..\..\Views\Shared\_LoginPartial.cshtml"
, Tuple.Create(Tuple.Create("", 1699), Tuple.Create<System.Object, System.Int32>(Url.Action("LogOff", "Account")
            
            #line default
            #line hidden
, 1699), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-sign-out\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral("></i> 로그아웃</a>\r\n                    </li>\r\n                </ul>\r\n            </l" +
"i>\r\n            \r\n            <li");

WriteLiteral(" class=\"dropdown\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" class=\"dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(" style=\"color:#ffffff; background-color:#2980b9;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-globe\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral("></i><i");

WriteLiteral(" class=\"fa fa-caret-down\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral("></i></a>\r\n                <ul");

WriteLiteral(" class=\"dropdown-menu dropdown-alerts animated fadeInRight\"");

WriteLiteral(">\r\n                    <li>\r\n                        <div");

WriteLiteral(" class=\"div-language\"");

WriteLiteral(" style=\"min-height:0;\"");

WriteLiteral(">\r\n                            ");

WriteLiteral("\r\n\r\n");

            
            #line 52 "..\..\Views\Shared\_LoginPartial.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\Shared\_LoginPartial.cshtml"
                              
                                // 나라 이미지를 추가할때 필요한것
                                // 1. ~/Content/Images/나라이름_32.png
                                // 2. <a태그 안에 class="btn-language-transform language-나라이름"추가
                                // * 1번과 2번의 나라이름은 동일하게 사용해야함.
                                CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;

            
            #line default
            #line hidden
WriteLiteral("                                <a");

WriteAttribute("href", Tuple.Create(" href=\"", 3078), Tuple.Create("\"", 3117)
, Tuple.Create(Tuple.Create("", 3085), Tuple.Create<System.Object, System.Int32>(Href("~/Account/ChangeCurrentCulture/0")
, 3085), false)
);

WriteLiteral(" class=\"btn-language-transform language-south-korea\"");

WriteLiteral("><img");

WriteAttribute("src", Tuple.Create(" src=\"", 3175), Tuple.Create("\"", 3193)
            
            #line 58 "..\..\Views\Shared\_LoginPartial.cshtml"
                                                         , Tuple.Create(Tuple.Create("", 3181), Tuple.Create<System.Object, System.Int32>(south_korea
            
            #line default
            #line hidden
, 3181), false)
);

WriteLiteral(" /></a>\r\n");

WriteLiteral("                                <a");

WriteAttribute("href", Tuple.Create(" href=\"", 3237), Tuple.Create("\"", 3276)
, Tuple.Create(Tuple.Create("", 3244), Tuple.Create<System.Object, System.Int32>(Href("~/Account/ChangeCurrentCulture/1")
, 3244), false)
);

WriteLiteral(" class=\"btn-language-transform language-usa\"");

WriteLiteral("><img");

WriteAttribute("src", Tuple.Create(" src=\"", 3326), Tuple.Create("\"", 3336)
            
            #line 59 "..\..\Views\Shared\_LoginPartial.cshtml"
                                                 , Tuple.Create(Tuple.Create("", 3332), Tuple.Create<System.Object, System.Int32>(usa
            
            #line default
            #line hidden
, 3332), false)
);

WriteLiteral(" /></a>\r\n");

            
            #line 60 "..\..\Views\Shared\_LoginPartial.cshtml"
                            
            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </li>\r\n                </ul" +
">\r\n            </li>\r\n            \r\n            <li");

WriteLiteral(" class=\"dropdown\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" class=\"dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(" style=\"color:#ffffff; background-color:#16A085;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-paint-brush\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral("></i><i");

WriteLiteral(" class=\"fa fa-caret-down\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral("></i></a>\r\n                <ul");

WriteLiteral(" class=\"dropdown-menu dropdown-alerts animated fadeInRight\"");

WriteLiteral(">\r\n                    <li>\r\n                        <li>\r\n                      " +
"      <div");

WriteLiteral(" class=\"setings-item default-skin s-skin-0\"");

WriteLiteral(">\r\n                                ");

WriteLiteral("\r\n                                    <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" >\r\n                                        Default\r\n                            " +
"        </a>\r\n                                ");

WriteLiteral("\r\n                            </div>\r\n                        </li>\r\n            " +
"            <li");

WriteLiteral(" class=\"divider\"");

WriteLiteral("></li>\r\n                        <li>\r\n                            <div");

WriteLiteral(" class=\"setings-item blue-skin s-skin-1\"");

WriteLiteral(">\r\n                                ");

WriteLiteral("\r\n                                    <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" >\r\n                                        Blue light\r\n                         " +
"           </a>\r\n                                ");

WriteLiteral("\r\n                            </div>\r\n                        </li>\r\n            " +
"        <li");

WriteLiteral(" class=\"divider\"");

WriteLiteral("></li>\r\n                    <li>\r\n                        <div");

WriteLiteral(" class=\"setings-item yellow-skin s-skin-3\"");

WriteLiteral(">\r\n                            ");

WriteLiteral("\r\n                                <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" >\r\n                                    Yellow/Purple\r\n                          " +
"      </a>\r\n                            ");

WriteLiteral("\r\n                        </div>\r\n                    </li>\r\n                </ul" +
">\r\n            </li>\r\n        </div>\r\n");

            
            #line 102 "..\..\Views\Shared\_LoginPartial.cshtml"


            
            #line default
            #line hidden
WriteLiteral("        <ul");

WriteLiteral(" class=\"nav navbar-top-links navbar-right nav-only-mobile\"");

WriteLiteral(">\r\n            <li");

WriteLiteral(" class=\"dropdown\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" class=\"dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(" style=\"color:#ffffff;background-color:#f39c12;\"");

WriteLiteral(">\r\n                    <i");

WriteLiteral(" class=\"fa fa-user\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral("></i><i");

WriteLiteral(" class=\"fa fa-caret-down\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral("></i>\r\n                </a>\r\n                <ul");

WriteLiteral(" class=\"dropdown-menu dropdown-alerts animated fadeInRight\"");

WriteLiteral(">\r\n                    <li>\r\n                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">");

            
            #line 110 "..\..\Views\Shared\_LoginPartial.cshtml"
                               Write(User.Identity.Name);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                    </li>\r\n                    <li");

WriteLiteral(" class=\"divider\"");

WriteLiteral("></li>\r\n                    <li>\r\n                        <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n                            <div>\r\n                                <i");

WriteLiteral(" class=\"fa fa-key\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral("></i> 비밀번호 변경\r\n                            </div>\r\n                        </a>\r\n" +
"                    </li>\r\n                    <li");

WriteLiteral(" class=\"divider\"");

WriteLiteral("></li>\r\n                    <li>\r\n                        <div");

WriteLiteral(" class=\"div-language\"");

WriteLiteral(" style=\"padding:3px 10px; min-height:0; display:inline;\"");

WriteLiteral(">\r\n                            ");

WriteLiteral("\r\n\r\n");

            
            #line 126 "..\..\Views\Shared\_LoginPartial.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 126 "..\..\Views\Shared\_LoginPartial.cshtml"
                              
                                // 나라 이미지를 추가할때 필요한것
                                // 1. ~/Content/Images/나라이름_32.png
                                // 2. <a태그 안에 class="btn-language-transform language-나라이름"추가
                                // * 1번과 2번의 나라이름은 동일하게 사용해야함.
                                currentCulture = Thread.CurrentThread.CurrentCulture;

            
            #line default
            #line hidden
WriteLiteral("                                <a");

WriteAttribute("href", Tuple.Create(" href=\"", 7093), Tuple.Create("\"", 7132)
, Tuple.Create(Tuple.Create("", 7100), Tuple.Create<System.Object, System.Int32>(Href("~/Account/ChangeCurrentCulture/0")
, 7100), false)
);

WriteLiteral(" class=\"btn-language-transform language-south-korea\"");

WriteLiteral("><img");

WriteAttribute("src", Tuple.Create(" src=\"", 7190), Tuple.Create("\"", 7208)
            
            #line 132 "..\..\Views\Shared\_LoginPartial.cshtml"
                                                         , Tuple.Create(Tuple.Create("", 7196), Tuple.Create<System.Object, System.Int32>(south_korea
            
            #line default
            #line hidden
, 7196), false)
);

WriteLiteral(" /></a>\r\n");

WriteLiteral("                                <a");

WriteAttribute("href", Tuple.Create(" href=\"", 7252), Tuple.Create("\"", 7291)
, Tuple.Create(Tuple.Create("", 7259), Tuple.Create<System.Object, System.Int32>(Href("~/Account/ChangeCurrentCulture/1")
, 7259), false)
);

WriteLiteral(" class=\"btn-language-transform language-usa\"");

WriteLiteral("><img");

WriteAttribute("src", Tuple.Create(" src=\"", 7341), Tuple.Create("\"", 7351)
            
            #line 133 "..\..\Views\Shared\_LoginPartial.cshtml"
                                                 , Tuple.Create(Tuple.Create("", 7347), Tuple.Create<System.Object, System.Int32>(usa
            
            #line default
            #line hidden
, 7347), false)
);

WriteLiteral(" /></a>\r\n");

            
            #line 134 "..\..\Views\Shared\_LoginPartial.cshtml"
                            
            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </li>\r\n                    " +
"<li");

WriteLiteral(" class=\"divider\"");

WriteLiteral("></li>\r\n                    <li>\r\n                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 7550), Tuple.Create("\"", 7589)
            
            #line 139 "..\..\Views\Shared\_LoginPartial.cshtml"
, Tuple.Create(Tuple.Create("", 7557), Tuple.Create<System.Object, System.Int32>(Url.Action("LogOff", "Account")
            
            #line default
            #line hidden
, 7557), false)
);

WriteLiteral(">\r\n                            <i");

WriteLiteral(" class=\"fa fa-sign-out\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral("></i> 로그아웃\r\n                        </a>\r\n                    </li>\r\n            " +
"    </ul>\r\n            </li>\r\n        </ul>\r\n");

            
            #line 146 "..\..\Views\Shared\_LoginPartial.cshtml"
    }
}
else
{

            
            #line default
            #line hidden
WriteLiteral("    <ul");

WriteLiteral(" class=\"nav navbar-top-links navbar-right\"");

WriteLiteral(">\r\n        ");

WriteLiteral("\r\n        <li>");

            
            #line 152 "..\..\Views\Shared\_LoginPartial.cshtml"
       Write(Html.ActionLink("로그인", "Login", "Account", routeValues: null, htmlAttributes: new { id = "loginLink" }));

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n    </ul>\r\n");

            
            #line 154 "..\..\Views\Shared\_LoginPartial.cshtml"



    
            
            #line default
            #line hidden
            
            #line 157 "..\..\Views\Shared\_LoginPartial.cshtml"
                                                    
    
            
            #line default
            #line hidden
            
            #line 194 "..\..\Views\Shared\_LoginPartial.cshtml"
           



    
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
