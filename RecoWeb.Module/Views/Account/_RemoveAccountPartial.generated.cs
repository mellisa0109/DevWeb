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
    using RecoWeb.Module;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Account/_RemoveAccountPartial.cshtml")]
    public partial class _Views_Account__RemoveAccountPartial_cshtml : System.Web.Mvc.WebViewPage<ICollection<Microsoft.AspNet.Identity.UserLoginInfo>>
    {
        public _Views_Account__RemoveAccountPartial_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Account\_RemoveAccountPartial.cshtml"
 if (Model.Count > 0)
{

            
            #line default
            #line hidden
WriteLiteral("    <h4>Registered Logins</h4>\r\n");

WriteLiteral("    <table");

WriteLiteral(" class=\"table\"");

WriteLiteral(">\r\n        <tbody>\r\n");

            
            #line 8 "..\..\Views\Account\_RemoveAccountPartial.cshtml"
            
            
            #line default
            #line hidden
            
            #line 8 "..\..\Views\Account\_RemoveAccountPartial.cshtml"
             foreach (var account in Model)
            {

            
            #line default
            #line hidden
WriteLiteral("                <tr>\r\n                    <td>");

            
            #line 11 "..\..\Views\Account\_RemoveAccountPartial.cshtml"
                   Write(account.LoginProvider);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td>\r\n");

            
            #line 13 "..\..\Views\Account\_RemoveAccountPartial.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 13 "..\..\Views\Account\_RemoveAccountPartial.cshtml"
                         if (ViewBag.ShowRemoveButton)
                        {
                            using (Html.BeginForm("Disassociate", "Account"))
                            {
                            
            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\Account\_RemoveAccountPartial.cshtml"
                       Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\Account\_RemoveAccountPartial.cshtml"
                                                    

            
            #line default
            #line hidden
WriteLiteral("                            <div>\r\n");

WriteLiteral("                                ");

            
            #line 19 "..\..\Views\Account\_RemoveAccountPartial.cshtml"
                           Write(Html.Hidden("loginProvider", account.LoginProvider));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                ");

            
            #line 20 "..\..\Views\Account\_RemoveAccountPartial.cshtml"
                           Write(Html.Hidden("providerKey", account.ProviderKey));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" value=\"Remove\"");

WriteAttribute("title", Tuple.Create(" title=\"", 867), Tuple.Create("\"", 933)
, Tuple.Create(Tuple.Create("", 875), Tuple.Create("Remove", 875), true)
, Tuple.Create(Tuple.Create(" ", 881), Tuple.Create("this", 882), true)
            
            #line 21 "..\..\Views\Account\_RemoveAccountPartial.cshtml"
                               , Tuple.Create(Tuple.Create(" ", 886), Tuple.Create<System.Object, System.Int32>(account.LoginProvider
            
            #line default
            #line hidden
, 887), false)
, Tuple.Create(Tuple.Create(" ", 909), Tuple.Create("login", 910), true)
, Tuple.Create(Tuple.Create(" ", 915), Tuple.Create("from", 916), true)
, Tuple.Create(Tuple.Create(" ", 920), Tuple.Create("your", 921), true)
, Tuple.Create(Tuple.Create(" ", 925), Tuple.Create("account", 926), true)
);

WriteLiteral(" />\r\n                            </div>\r\n");

            
            #line 23 "..\..\Views\Account\_RemoveAccountPartial.cshtml"
                            }
                        }
                        else
                        {

            
            #line default
            #line hidden
WriteLiteral("                            ");

WriteLiteral(" &nbsp;\r\n");

            
            #line 28 "..\..\Views\Account\_RemoveAccountPartial.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </td>\r\n                </tr>\r\n");

            
            #line 31 "..\..\Views\Account\_RemoveAccountPartial.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </tbody>\r\n    </table>\r\n");

            
            #line 34 "..\..\Views\Account\_RemoveAccountPartial.cshtml"
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
