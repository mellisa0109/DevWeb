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
    using RecoWeb.Module;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/System/_PopupPermissionsAddEmployee.cshtml")]
    public partial class _Views_System__PopupPermissionsAddEmployee_cshtml : System.Web.Mvc.WebViewPage<RecoWeb.Module.Models.PermissionViewModel>
    {
        public _Views_System__PopupPermissionsAddEmployee_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\"modal-dialog modal-lg\"");

WriteLiteral(" onload=\"Loads()\"");

WriteLiteral(" id=\"ModalsEmployee\"");

WriteLiteral(">\r\n\r\n    <div");

WriteLiteral(" class=\"modal-content animated fadeInRight\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-lg-7 col-md-7 h-100\"");

WriteLiteral(">\r\n            <div>\r\n                <div");

WriteLiteral(" class=\"ibox\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"ibox-title\"");

WriteLiteral(">\r\n                        <span");

WriteLiteral(" style=\"font-size:1.4rem;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-list-ul\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral("></i>&nbsp;작업자추가</span>\r\n                        <span");

WriteLiteral(" class=\"pull-right\"");

WriteLiteral(">\r\n                            <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default ibox-title-btn\"");

WriteLiteral(" id=\"btnReadEmployeeAdd\"");

WriteLiteral(">읽기</button>\r\n                            <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default ibox-title-btn\"");

WriteLiteral(" id=\"btnAllEmployeeAdd\"");

WriteLiteral(">읽기+추가+수정+삭제</button>\r\n                            <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default ibox-title-btn\"");

WriteLiteral(" id=\"btnNoAuthEmployeeAdd\"");

WriteLiteral(">권한없음</button>\r\n                        </span>\r\n\r\n                    </div>\r\n  " +
"                  <div");

WriteLiteral(" class=\"ibox-content modal-body\"");

WriteLiteral(">\r\n                        <table");

WriteLiteral(" id=\"TCI-Grid5\"");

WriteLiteral(" cellpadding=\"0\"");

WriteLiteral(" cellspacing=\"0\"");

WriteLiteral("></table>\r\n                        <div");

WriteLiteral(" id=\"TCI-Pager5\"");

WriteLiteral(" style=\"text-align: center;\"");

WriteLiteral(">\r\n                        </div>\r\n                    </div>\r\n                </" +
"div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n        $(document).ready(function () {\r\n            showGrid11(\'");

            
            #line 33 "..\..\Views\System\_PopupPermissionsAddEmployee.cshtml"
                   Write(Model.MenuCode);

            
            #line default
            #line hidden
WriteLiteral("\', \'");

            
            #line 33 "..\..\Views\System\_PopupPermissionsAddEmployee.cshtml"
                                      Write(Model.Ids);

            
            #line default
            #line hidden
WriteLiteral("\');\r\n        })\r\n\r\n        var row_grid2;\r\n        function showGrid11(menuCode, " +
"Ids) {\r\n            //그리드 선언\r\n            $(\"#TCI-Grid5\").jqGrid\r\n             (" +
"{\r\n                 url: \'../System/GetCOW_PermissionEmployeeAddInquiry\',\r\n     " +
"            datatype: \'json\',\r\n                 mtype: \'GET\',\r\n                 " +
"//파라메타\r\n                 postData: {\r\n                     //menuCode: $(\".check" +
"-item input[name=\'menuCode\']\").val()\r\n                     menuCode: menuCode\r\n " +
"                    , ids: Ids\r\n                 },\r\n                 hidegrid: " +
"true,\r\n                 loadonce: true,\r\n                 navOptions: { reloadGr" +
"idOptions: { fromServer: true } },\r\n                 loadtext: \'Loading...\',\r\n  " +
"               rownumbers: true,\r\n                 shrinkToFit: true,\r\n         " +
"        colNames: [\'작업자코드\', \'작업자명\'],\r\n                 colModel: [\r\n            " +
"        {\r\n                        key: true,\r\n                        name: \'Em" +
"ployeeId\',\r\n                        index: \'EmployeeId\',\r\n                      " +
"  width: \'200%\'\r\n                        , hidden: false, editable: true\r\n      " +
"              }, {\r\n                        key: false,\r\n                       " +
" name: \'EmployeeName\',\r\n                        index: \'EmployeeName\',\r\n        " +
"                width: \'250%\'\r\n                        , hidden: false, editable" +
": true\r\n                    }\r\n                 ],\r\n                 pager: jQue" +
"ry(\'#TCI-Pager5\'),\r\n                 rowNum: 100,\r\n                 rowList: [20" +
", 50, 100, 200, 300, 500],\r\n                 height: \'100%\',\r\n                 v" +
"iewrecords: true,\r\n                 emptyrecords: \'No records to display\',\r\n    " +
"             autowidth: true,\r\n                 multiselect: true\r\n             " +
"}).navGrid(\'#TCI-Pager5\',\r\n             {\r\n                 edit: false,\r\n      " +
"           add: false,\r\n                 del: false,\r\n                 search: f" +
"alse,\r\n                 refresh: false\r\n             });\r\n        }\r\n\r\n        $" +
"(\'#btnReadEmployeeAdd\').click(function () {\r\n            var pids = $(\"#TCI-Grid" +
"5\").getGridParam(\'selarrrow\'); // 선택된 행을 가지고 온다\r\n            SetCOW_PermissionEm" +
"ployeeAddSave(\'");

            
            #line 92 "..\..\Views\System\_PopupPermissionsAddEmployee.cshtml"
                                         Write(Model.MenuCode);

            
            #line default
            #line hidden
WriteLiteral(@"', pids, '0', '1', '0', '0');

            $('#ModalsEmployee').modal('hide')
        });

        $('#btnAllEmployeeAdd').click(function () {
            var pids = $(""#TCI-Grid5"").getGridParam('selarrrow'); // 선택된 행을 가지고 온다
            SetCOW_PermissionEmployeeAddSave('");

            
            #line 99 "..\..\Views\System\_PopupPermissionsAddEmployee.cshtml"
                                         Write(Model.MenuCode);

            
            #line default
            #line hidden
WriteLiteral(@"', pids, '1', '1', '1', '1');

            $('#ModalsEmployee').modal('hide')
        });

        $('#btnNoAuthEmployeeAdd').click(function () {
            var pids = $(""#TCI-Grid5"").getGridParam('selarrrow'); // 선택된 행을 가지고 온다
            SetCOW_PermissionEmployeeAddSave('");

            
            #line 106 "..\..\Views\System\_PopupPermissionsAddEmployee.cshtml"
                                         Write(Model.MenuCode);

            
            #line default
            #line hidden
WriteLiteral(@"', pids, '0', '0', '0', '0');

            $('#ModalsEmployee').modal('hide')
        });

        function SetCOW_PermissionEmployeeAddSave(pmenuCode, pids, pauthCreate, pauthRead, pauthUpdate, pauthDelete) {
            var dat = """";
            for (var i = 0; i < pids.length; i++) {
                dat += pids[i] + ',';
            }

            $.post('../System/SetCOW_PermissionEmployeeAddSave', {
                menuCode: pmenuCode
                , ids: dat
                , authCreate: pauthCreate
                , authRead: pauthRead
                , authUpdate: pauthUpdate
                , authDelete: pauthDelete
            }, function (data) {

            }).fail(function (jqXHR, textStatus, errorThrown) {
                alert('Error getting products!');
            });
            return;
        }
    </script>
");

        }
    }
}
#pragma warning restore 1591