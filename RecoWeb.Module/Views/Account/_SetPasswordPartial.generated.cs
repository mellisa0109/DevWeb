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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Account/_SetPasswordPartial.cshtml")]
    public partial class _Views_Account__SetPasswordPartial_cshtml : System.Web.Mvc.WebViewPage<RecoWeb.Module.Models.ManageUserViewModel>
    {
        public _Views_Account__SetPasswordPartial_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<p");

WriteLiteral(" class=\"text-info\"");

WriteLiteral(">\r\n    You do not have a local username/password for this site. Add a local\r\n    " +
"account so you can log in without an external login.\r\n</p>\r\n\r\n");

            
            #line 8 "..\..\Views\Account\_SetPasswordPartial.cshtml"
 using (Html.BeginForm("Manage", "Account", FormMethod.Post, new { @class = "form-horizontal", role = "form" }))
{
    
            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\Account\_SetPasswordPartial.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\Account\_SetPasswordPartial.cshtml"
                            


            
            #line default
            #line hidden
WriteLiteral("    <h4>Create Local Login</h4>\r\n");

WriteLiteral("    <hr />\r\n");

            
            #line 14 "..\..\Views\Account\_SetPasswordPartial.cshtml"
    
            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\Account\_SetPasswordPartial.cshtml"
Write(Html.ValidationSummary());

            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\Account\_SetPasswordPartial.cshtml"
                             

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 16 "..\..\Views\Account\_SetPasswordPartial.cshtml"
   Write(Html.LabelFor(m => m.NewPassword, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 18 "..\..\Views\Account\_SetPasswordPartial.cshtml"
       Write(Html.PasswordFor(m => m.NewPassword, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 22 "..\..\Views\Account\_SetPasswordPartial.cshtml"
   Write(Html.LabelFor(m => m.ConfirmPassword, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 24 "..\..\Views\Account\_SetPasswordPartial.cshtml"
       Write(Html.PasswordFor(m => m.ConfirmPassword, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n            <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Set password\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" />\r\n        </div>\r\n    </div>\r\n");

            
            #line 32 "..\..\Views\Account\_SetPasswordPartial.cshtml"
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
