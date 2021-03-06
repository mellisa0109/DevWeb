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
    
    #line 2 "..\..\Views\System\_Permissions.cshtml"
    using RecoWeb.Domain.LocalResource;
    
    #line default
    #line hidden
    using RecoWeb.Module;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/System/_Permissions.cshtml")]
    public partial class _Views_System__Permissions_cshtml : System.Web.Mvc.WebViewPage<RecoWeb.Module.Models.PermissionViewModel>
    {
        public _Views_System__Permissions_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"col-lg-5 col-md-5 h-100\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"ibox\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"ibox-title\"");

WriteLiteral(">\r\n            <span");

WriteLiteral(" style=\"font-size:1.4rem;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-list-alt\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral("></i>&nbsp;메뉴</span>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"ibox-content\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 10 "..\..\Views\System\_Permissions.cshtml"
        Write(Html.DevExtreme().TreeList()
                    .ID("gridContainer01")
                    .KeyExpr("Id")
                    .ParentIdExpr("ParentId")
                    //.DataSource(new JS("menuList"))
                    .DataSource(ds => ds.Mvc().Controller("System").Key("Id")
                        .LoadAction("GetCOW_PermissionMenuInquiry")
                        .LoadParams(new
                        {
                            userId = ""
                        }
                        )
                    )
                    .Columns(columns =>
                    {
                        columns.Add().DataField("MenuCode").Caption("메뉴").Alignment(HorizontalAlignment.Left);

                        columns.Add().DataField("Description").Caption("설명").Alignment(HorizontalAlignment.Left);

                        columns.Add().DataField("IsUse").Caption("사용여부").Alignment(HorizontalAlignment.Center);

                        columns.Add().DataField("Sequence").Caption("순서").Alignment(HorizontalAlignment.Right);

                        columns.Add().DataField("ParentMenuCode").Caption("A").Alignment(HorizontalAlignment.Center).Visible(false);

                        columns.Add().DataField("TreeLevel").Caption("B").Alignment(HorizontalAlignment.Left).Visible(false);
                        columns.Add().DataField("IsLeaf").Caption("C").Alignment(HorizontalAlignment.Left).Visible(false);
                        columns.Add().DataField("Loaded").Caption("D").Alignment(HorizontalAlignment.Left).Visible(false);
                        columns.Add().DataField("Expanded").Caption("E").Alignment(HorizontalAlignment.Left).Visible(false);
                        columns.Add().DataField("_KeyColumn").Caption("키").Alignment(HorizontalAlignment.Left).Visible(false);
                    })
                    .ShowRowLines(true)
                    .ShowColumnLines(true)
                    .ShowBorders(true)
                    .ColumnAutoWidth(true)
                    .ExpandedRowKeys(new[] { 1 })
                    .HoverStateEnabled(true)
                    .Selection(e => e.Mode(SelectionMode.Single))
                    .OnSelectionChanged("tree1Change") //체인지 이벤트를 선언함
                    .OnContentReady("onReady") // 레디 이벤트
            );

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div");

WriteLiteral(" class=\"col-lg-7 col-md-7 h-100\"");

WriteLiteral(">\r\n    <div>\r\n        <div");

WriteLiteral(" class=\"ibox\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"ibox-title\"");

WriteLiteral(">\r\n                <span");

WriteLiteral(" style=\"font-size:1.4rem;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-list-ul\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral("></i>&nbsp;역할권한</span>\r\n                <span");

WriteLiteral(" class=\"pull-right\"");

WriteLiteral(">\r\n                    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default ibox-title-btn\"");

WriteLiteral(" id=\"btnCreateRole\"");

WriteLiteral(">추가</button>\r\n                    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default ibox-title-btn\"");

WriteLiteral(" id=\"btnReadRole\"");

WriteLiteral(">읽기</button>\r\n                    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default ibox-title-btn\"");

WriteLiteral(" id=\"btnUpdateRole\"");

WriteLiteral(">수정</button>\r\n                    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default ibox-title-btn\"");

WriteLiteral(" id=\"btnDeleteRole\"");

WriteLiteral(">삭제</button>\r\n                    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default ibox-title-btn\"");

WriteLiteral(" id=\"btnNoAuthRole\"");

WriteLiteral(">권한없음</button>\r\n                    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default view-modal ibox-title-btn\"");

WriteLiteral(" id=\"btnAddRole\"");

WriteLiteral(" data-toggle=\'modal\'");

WriteLiteral(" data-target=\'#Modals\'");

WriteLiteral(">역할추가</button>\r\n                    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default ibox-title-btn\"");

WriteLiteral(" id=\"btnRemoveRole\"");

WriteLiteral(">역할삭제</button>\r\n                </span>\r\n\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"ibox-content\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 72 "..\..\Views\System\_Permissions.cshtml"
            Write(Html.DevExtreme().DataGrid()
                    .ID("gridContainer02")
                    .Paging(paging => paging.PageSize(20))
                    .Pager(pager =>
                    {
                        pager.ShowPageSizeSelector(true);
                        pager.AllowedPageSizes(new List<int> { 20, 50, 100, 200, 300, 500 });
                        pager.ShowInfo(true);
                    })
                    .Export(e => e.Enabled(true).FileName("ExportTest").AllowExportSelectedData(true))  //Export
                    .ColumnAutoWidth(true)
                    .ShowColumnLines(true)
                    .ShowRowLines(true)
                    .ShowBorders(true)
                    .HoverStateEnabled(true)
                    .Sorting(e => e.Mode(GridSortingMode.Multiple))
                    .ColumnMinWidth(50)
                    .AllowColumnResizing(true)
                    .Option("columnResizingMode", ColumnResizingMode.Widget)
                    .Columns(columns =>
                    {
                        columns.Add().DataField("RoleId").Caption("역할코드").Alignment(HorizontalAlignment.Left);
                        columns.Add().DataField("RoleName").Caption("역할이름").Alignment(HorizontalAlignment.Left);
                        columns.Add().DataField("MenuCode").Caption("메뉴코드").Alignment(HorizontalAlignment.Left);
                        columns.Add().DataField("AuthCreate").Caption("추가").Alignment(HorizontalAlignment.Center);
                        columns.Add().DataField("AuthRead").Caption("읽기").Alignment(HorizontalAlignment.Center);
                        columns.Add().DataField("AuthUpdate").Caption("수정").Alignment(HorizontalAlignment.Center);
                        columns.Add().DataField("AuthDelete").Caption("삭제").Alignment(HorizontalAlignment.Center);
                        columns.Add().DataField("C_KeyColumn").Caption("키").Alignment(HorizontalAlignment.Left).Visible(false);
                    })
                    .Editing(e => e.Mode(GridEditMode.Popup)
                            .AllowAdding(true)
                            .AllowUpdating(true)
                            .AllowDeleting(true)
                            .UseIcons(true)
                            .Popup(p => p
                                    .ShowTitle(true)
                                    .Width(800)
                                    .Height(550)
                                    .Position(pos => pos
                                            .My(HorizontalAlignment.Center, VerticalAlignment.Center)
                                            .At(HorizontalAlignment.Center, VerticalAlignment.Center)
                                            .Of(new JS("window"))
                                            )
                                )
                            )
                    .Height(new JS("heightCalc('50')"))
                    .Selection(e => e.Mode(SelectionMode.Multiple))
                );

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <div>\r\n        <div");

WriteLiteral(" class=\"ibox\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"ibox-title\"");

WriteLiteral(">\r\n                <span");

WriteLiteral(" style=\"font-size:1.4rem;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-th-list\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral("></i>&nbsp;작업자권한</span>\r\n                <span");

WriteLiteral(" class=\"pull-right\"");

WriteLiteral(">\r\n                    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default ibox-title-btn\"");

WriteLiteral(" id=\"btnCreateEmployee\"");

WriteLiteral(">추가</button>\r\n                    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default ibox-title-btn\"");

WriteLiteral(" id=\"btnReadEmployee\"");

WriteLiteral(">읽기</button>\r\n                    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default ibox-title-btn\"");

WriteLiteral(" id=\"btnUpdateEmployee\"");

WriteLiteral(">수정</button>\r\n                    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default ibox-title-btn\"");

WriteLiteral(" id=\"btnDeleteEmployee\"");

WriteLiteral(">삭제</button>\r\n                    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default ibox-title-btn\"");

WriteLiteral(" id=\"btnNoAuthEmployee\"");

WriteLiteral(">권한없음</button>\r\n                    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default view-modal ibox-title-btn\"");

WriteLiteral(" id=\"btnAddEmployee\"");

WriteLiteral(" data-toggle=\'modal\'");

WriteLiteral(" data-target=\'#ModalsEmployee\'");

WriteLiteral(">작업자추가</button>\r\n                    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default ibox-title-btn\"");

WriteLiteral(" id=\"btnRemoveEmployee\"");

WriteLiteral(">작업자삭제</button>\r\n                </span>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"ibox-content\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 140 "..\..\Views\System\_Permissions.cshtml"
            Write(Html.DevExtreme().DataGrid()
                    .ID("gridContainer03")
                    .Paging(paging => paging.PageSize(20))
                    .Pager(pager =>
                    {
                        pager.ShowPageSizeSelector(true);
                        pager.AllowedPageSizes(new List<int> { 20, 50, 100, 200, 300, 500 });
                        pager.ShowInfo(true);
                    })
                    .Export(e => e.Enabled(true).FileName("ExportTest").AllowExportSelectedData(true))  //Export
                    .ColumnAutoWidth(true)
                    .ShowColumnLines(true)
                    .ShowRowLines(true)
                    .ShowBorders(true)
                    .HoverStateEnabled(true)
                    .Sorting(e => e.Mode(GridSortingMode.Multiple))
                    .ColumnMinWidth(50)
                    .AllowColumnResizing(true)
                    .Option("columnResizingMode", ColumnResizingMode.Widget)
                    .Columns(columns =>
                    {
                        columns.Add().DataField("EmployeeId").Caption("작업자코드").Alignment(HorizontalAlignment.Left);
                        columns.Add().DataField("EmployeeName").Caption("작업자이름").Alignment(HorizontalAlignment.Left);
                        columns.Add().DataField("MenuCode").Caption("메뉴코드").Alignment(HorizontalAlignment.Left);
                        columns.Add().DataField("AuthCreate").Caption("추가").Alignment(HorizontalAlignment.Center);
                        columns.Add().DataField("AuthRead").Caption("읽기").Alignment(HorizontalAlignment.Center);
                        columns.Add().DataField("AuthUpdate").Caption("수정").Alignment(HorizontalAlignment.Center);
                        columns.Add().DataField("AuthDelete").Caption("삭제").Alignment(HorizontalAlignment.Center);
                        columns.Add().DataField("C_KeyColumn").Caption("키").Alignment(HorizontalAlignment.Left).Visible(false);
                    })
                    .Height(new JS("heightCalc('50')"))
                    .Selection(e => e.Mode(SelectionMode.Multiple))
                );

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");

DefineSection("Styles", () => {

WriteLiteral("\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 10522), Tuple.Create("\"", 10604)
            
            #line 180 "..\..\Views\System\_Permissions.cshtml"
, Tuple.Create(Tuple.Create("", 10529), Tuple.Create<System.Object, System.Int32>(Url.Action("plugins/bootstrap-toggle/bootstrap-toggle.min.css", "Content")
            
            #line default
            #line hidden
, 10529), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n\r\n    <link");

WriteAttribute("href", Tuple.Create(" href=\"", 10654), Tuple.Create("\"", 10720)
            
            #line 182 "..\..\Views\System\_Permissions.cshtml"
, Tuple.Create(Tuple.Create("", 10661), Tuple.Create<System.Object, System.Int32>(Url.Action("plugins/sweetalert/sweetalert.css", "Content")
            
            #line default
            #line hidden
, 10661), false)
);

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(" />\r\n\r\n");

});

WriteLiteral("\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
    var row_grid1;

    //그리드 Load이후 타는 이벤트
    function onReady(a) {
        if ($('#gridContainer01').dxTreeList(""instance"").totalCount() > 0) {
            $('#gridContainer01').dxTreeList(""instance"").selectRowsByIndexes(0);
            //↑ 동일함. (↓더 많은 테스트는 진행못함)
            //$('#' + a.element[0].id).dxDataGrid(""instance"").selectRows(1)
        }
    }

    function getAllSelectOptions() {
        var states = {};
        states = { ""Administrator"": ""관리자"", ""Developer"": ""개발자"", ""Executives"": ""임원"", ""Master"": ""마스터"", ""Production"": ""생산"", ""Qulity"": ""품질"", ""Worker"": ""작업자"" };
        $.post('../Common/GetCOW_CodeRolesInquiry', null, function (data) {
            var userDetails = {};
            $.each(data, function () {
                userDetails[this.RoleId] = this.RoleName;
            })
            states = userDetails;
        }).fail(function (jqXHR, textStatus, errorThrown) {
            alert('Error getting products!');
        });
        return states;
    }

</script>");

        }
    }
}
#pragma warning restore 1591
