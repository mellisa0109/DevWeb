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
    
    #line 2 "..\..\Views\System\Preferences.cshtml"
    using RecoWeb.Domain.LocalResource;
    
    #line default
    #line hidden
    using RecoWeb.Module;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/System/Preferences.cshtml")]
    public partial class _Views_System_Preferences_cshtml : System.Web.Mvc.WebViewPage<RecoWeb.Module.Models.PreferencesViewModel>
    {
        public _Views_System_Preferences_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n<div");

WriteLiteral(" id=\"Context\"");

WriteLiteral(" class=\"row wrapper wrapper-content animated fadeInRight\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"col-lg-3 col-md-3\"");

WriteLiteral(">\r\n");

            
            #line 6 "..\..\Views\System\Preferences.cshtml"
        
            
            #line default
            #line hidden
            
            #line 6 "..\..\Views\System\Preferences.cshtml"
         using (Html.BeginForm("TitleSave", "System", new { title = Model.Title }, FormMethod.Get, new { role = "form" }))
        {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"ibox\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"ibox-title\"");

WriteLiteral(">\r\n                    <span");

WriteLiteral(" style=\"font-size:1.4rem;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-list-alt\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral("></i>&nbsp;사이트정보</span>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"ibox-content\"");

WriteLiteral(">\r\n                    <p>사이트명:</p>\r\n");

WriteLiteral("                    ");

            
            #line 14 "..\..\Views\System\Preferences.cshtml"
               Write(Html.TextBoxFor(x => x.Title));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(">\r\n                        저장\r\n                    </button>\r\n                </d" +
"iv>\r\n\r\n            </div>\r\n");

            
            #line 21 "..\..\Views\System\Preferences.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n\r\n    <div");

WriteLiteral(" class=\"col-lg-3 col-md-3\"");

WriteLiteral(">\r\n");

            
            #line 26 "..\..\Views\System\Preferences.cshtml"
        
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\System\Preferences.cshtml"
         using (Html.BeginForm("RecentVisitSave", "System", new { title = Model.RecentVisit }, FormMethod.Get, new { role = "form" }))
        {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"ibox\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"ibox-title\"");

WriteLiteral(">\r\n                    <span");

WriteLiteral(" style=\"font-size:1.4rem;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-list-ul\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral("></i>&nbsp;화면정보</span>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"ibox-content\"");

WriteLiteral(">\r\n                    <p>최근 방문 페이지 개수:</p>\r\n");

WriteLiteral("                    ");

            
            #line 34 "..\..\Views\System\Preferences.cshtml"
               Write(Html.TextBoxFor(x => x.RecentVisit));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(">\r\n                        저장\r\n                    </button>\r\n                </d" +
"iv>\r\n            </div>\r\n");

            
            #line 40 "..\..\Views\System\Preferences.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n    <div");

WriteLiteral(" class=\"col-lg-3 col-md-3\"");

WriteLiteral(">\r\n\r\n        ");

WriteLiteral("\r\n        ");

WriteLiteral("\r\n");

            
            #line 46 "..\..\Views\System\Preferences.cshtml"
        
            
            #line default
            #line hidden
            
            #line 46 "..\..\Views\System\Preferences.cshtml"
         using (Html.BeginForm("FooterFixedSave", "System", new { title = Model.isFooterFixed }, FormMethod.Get, new { role = "form" }))
        {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"ibox\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"ibox-title\"");

WriteLiteral(">\r\n                    <span");

WriteLiteral(" style=\"font-size:1.4rem;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-list-ul\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral("></i>&nbsp;설정</span>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"ibox-content\"");

WriteLiteral(">\r\n                    <p>Footer Fixed:</p>\r\n");

WriteLiteral("                    ");

            
            #line 54 "..\..\Views\System\Preferences.cshtml"
               Write(Html.CheckBoxFor(x => x.isFooterFixed, new { @data_toggle = "toggle", @data_on = "Yes", @data_off = "No", @checked = true, @data_size = "normal" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" id=\"footer-save\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" value=\"저장\"");

WriteLiteral(" />\r\n                </div>\r\n            </div>\r\n");

            
            #line 58 "..\..\Views\System\Preferences.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n    <div");

WriteLiteral(" class=\"col-lg-3 col-md-3\"");

WriteLiteral(">\r\n        <div>\r\n");

            
            #line 62 "..\..\Views\System\Preferences.cshtml"
            
            
            #line default
            #line hidden
            
            #line 62 "..\..\Views\System\Preferences.cshtml"
             using (Html.BeginForm("BackgoundSave", "System", FormMethod.Post, new { id = "form-Background" }))
            {

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"ibox\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"ibox-title\"");

WriteLiteral(">\r\n                        <span");

WriteLiteral(" style=\"font-size:1.4rem;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-list-ul\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral("></i>&nbsp;로그인화면</span>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"ibox-content\"");

WriteLiteral(">\r\n                        <p>로그인화면 설정</p>\r\n                        <div");

WriteLiteral(" style=\"display:flex;\"");

WriteLiteral(">\r\n                            <input");

WriteLiteral(" type=\"file\"");

WriteLiteral(" id=\"background-files\"");

WriteLiteral(" class=\"backgound-file\"");

WriteLiteral(" name=\"postedFile\"");

WriteLiteral(">\r\n                            <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" id=\"background-save\"");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" value=\"저장\"");

WriteLiteral(" />\r\n                        </div>\r\n                    </div>\r\n                " +
"</div>\r\n");

            
            #line 76 "..\..\Views\System\Preferences.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n\r\n");

DefineSection("Styles", () => {

WriteLiteral("\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 3512), Tuple.Create("\"", 3594)
            
            #line 82 "..\..\Views\System\Preferences.cshtml"
, Tuple.Create(Tuple.Create("", 3519), Tuple.Create<System.Object, System.Int32>(Url.Action("plugins/bootstrap-toggle/bootstrap-toggle.min.css", "Content")
            
            #line default
            #line hidden
, 3519), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 3642), Tuple.Create("\"", 3708)
            
            #line 83 "..\..\Views\System\Preferences.cshtml"
, Tuple.Create(Tuple.Create("", 3649), Tuple.Create<System.Object, System.Int32>(Url.Action("plugins/sweetalert/sweetalert.css", "Content")
            
            #line default
            #line hidden
, 3649), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n\r\n");

});

WriteLiteral("\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n    <script");

WriteLiteral(" src=\"../Scripts/jquery-3.1.1.min.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"../Scripts/plugins/bootstrap-toggle/bootstrap-toggle.min.js\"");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"../Scripts/plugins/sweetalert/sweetalert.min.js\"");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral("></script>\r\n\r\n\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n        $().ready(function () {\r\n\r\n            //Footer Fixed Toggle 이벤트\r\n    " +
"        $(\'#isFooterFixed\').on(\'change\', function () {\r\n                $(\'#isFo" +
"oterFixed\').val($(this).prop(\'checked\'));\r\n            });\r\n            //Footer" +
" Fixed 저장버튼 클릭\r\n            $(\'#footer-save\').on(\'click\', function () {\r\n       " +
"         if ($(\'#isFooterFixed\').prop(\'checked\')) {\r\n                    console" +
".log(\'on\');\r\n                    localStorage.setItem(\'fixedfooter\', \'on\');\r\n   " +
"             } else {\r\n                    console.log(\'off\');\r\n                " +
"    localStorage.setItem(\'fixedfooter\', \'off\');\r\n                }\r\n            " +
"});\r\n\r\n            //배경화면 저장버튼 클릭\r\n            $(\'#background-save\').on(\"click\"," +
" function () {\r\n                var filesss = $(\".backgound-file\")[0];\r\n        " +
"        if (filesss !== undefined) {\r\n                    var filea = filesss.fi" +
"les[0];\r\n\r\n                    if (filea == undefined) {\r\n                      " +
"  swal({\r\n                            title: \"알림\",\r\n                            " +
"text: \"파일을 선택하세요.\",\r\n                            type: \"warning\"\r\n              " +
"          });\r\n                        return;\r\n                    }\r\n         " +
"           if (filea.size > 20971520) {\r\n                        swal({\r\n       " +
"                     title: \"알림\",\r\n                            text: \"파일 크기는 20M" +
"B이하 입니다.\",\r\n                            type: \"warning\"\r\n                       " +
" });\r\n                        return;\r\n                    }\r\n                  " +
"  var imgTypes, inputFileName;\r\n                    inputFileName = filesss.file" +
"s[0].name;\r\n                    if (inputFileName.split(\'.\').length != 2) {\r\n   " +
"                     swal({\r\n                            title: \"알림\",\r\n         " +
"                   text: \"파일 이름이 잘못되었습니다.\",\r\n                            type: \"" +
"warning\"\r\n                        });\r\n                        return;\r\n        " +
"            }\r\n\r\n                    imgTypes = inputFileName.split(\'.\')[1];\r\n  " +
"                  if (imgTypes != \'jpg\' && imgTypes != \'jepg\' && imgTypes != \'pn" +
"g\' && imgTypes != \'gif\' && imgTypes != \'bmp\') {\r\n                        swal({\r" +
"\n                            title: \"알림\",\r\n                            text: \"파일" +
"을 형식이 잘못되었습니다.\",\r\n                            type: \"warning\"\r\n                 " +
"       });\r\n                        return;\r\n                    }\r\n\r\n          " +
"          var reader = new FileReader();\r\n                    reader.readAsDataU" +
"RL(filea);\r\n                    reader.onload = function () {\r\n                 " +
"       result = reader.result;\r\n                        result = result.replace(" +
"/\\+/g, \'_\');\r\n\r\n                        $.ajax({\r\n                            ur" +
"l: \'../System/BackgoundSave\',\r\n\r\n                            //파일 이름은 index.jpg로" +
" 고정\r\n                            data: \"&fileData=\" + result + \"&file=\" + \"index" +
".jpg\",\r\n\r\n                            processData: false,\r\n                     " +
"       contentType: \"application/x-www-form-urlencoded; charset=UTF-8\",\r\n       " +
"                     type: \'POST\',\r\n                            success: functio" +
"n (data) {\r\n                                swal({\r\n                            " +
"        title: \"알림\",\r\n                                    text: \"업로드 완료\",\r\n     " +
"                               type: \"success\",\r\n                               " +
"     showCancelButton: false,\r\n                                    confirmButton" +
"Class: \"confirm\",\r\n                                    confirmButtonText: \"OK\",\r" +
"\n                                    closeOnConfirm: false\r\n                    " +
"            }, function (isConfirm) {\r\n                                    //성공시" +
" 새로고침\r\n                                    if (isConfirm) {\r\n                   " +
"                     location.reload(true);\r\n                                   " +
" }\r\n                                });\r\n\r\n                            },\r\n     " +
"                       error: function (request, status, error) {\r\n             " +
"                   console.log(\"code:\" + request.status + \"\\n\" + \"message:\" + re" +
"quest.responseText + \"\\n\" + \"error:\" + error);\r\n                                " +
"swal({\r\n                                    title: \"알림\",\r\n                      " +
"              text: \"업로드 실패\",\r\n                                    type: \"error\"" +
"\r\n                                });\r\n                                return;\r\n" +
"                            }\r\n                        });\r\n                    " +
"}\r\n                }\r\n            });\r\n\r\n        });\r\n\r\n    </script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
