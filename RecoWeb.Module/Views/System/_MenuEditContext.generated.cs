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
    
    #line 1 "..\..\Views\System\_MenuEditContext.cshtml"
    using RecoWeb.Domain.LocalResource;
    
    #line default
    #line hidden
    using RecoWeb.Module;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/System/_MenuEditContext.cshtml")]
    public partial class _Views_System__MenuEditContext_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_System__MenuEditContext_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"col-lg-6 col-md-6 h-100\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"ibox\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"ibox-title\"");

WriteLiteral(">\r\n            <span");

WriteLiteral(" style=\"font-size:1.4rem;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-list-alt\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral("></i>&nbsp;");

            
            #line 6 "..\..\Views\System\_MenuEditContext.cshtml"
                                                                                              Write(Resource.LargeMenu);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"ibox-content\"");

WriteLiteral(">\r\n            <table");

WriteLiteral(" id=\"MenuEdit-Grid1\"");

WriteLiteral(" cellpadding=\"0\"");

WriteLiteral(" cellspacing=\"0\"");

WriteLiteral("></table>\r\n            <div");

WriteLiteral(" id=\"MenuEdit-Pager1\"");

WriteLiteral(" style=\"text-align: center;\"");

WriteLiteral(">\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div");

WriteLiteral(" class=\"col-lg-6 col-md-6 h-100\"");

WriteLiteral(">\r\n    <div>\r\n        <div");

WriteLiteral(" class=\"ibox\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"ibox-title\"");

WriteLiteral(">\r\n                <span");

WriteLiteral(" style=\"font-size:1.4rem;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-list-ul\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral("></i>&nbsp;");

            
            #line 20 "..\..\Views\System\_MenuEditContext.cshtml"
                                                                                                 Write(Resource.MiddleMenu);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"ibox-content\"");

WriteLiteral(">\r\n                <table");

WriteLiteral(" id=\"MenuEdit-Grid2\"");

WriteLiteral(" cellpadding=\"0\"");

WriteLiteral(" cellspacing=\"0\"");

WriteLiteral("></table>\r\n                <div");

WriteLiteral(" id=\"MenuEdit-Pager2\"");

WriteLiteral(" style=\"text-align: center;\"");

WriteLiteral(">\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    " +
"<div>\r\n        <div");

WriteLiteral(" class=\"ibox\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"ibox-title\"");

WriteLiteral(">\r\n                <span");

WriteLiteral(" style=\"font-size:1.4rem;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-th-list\"");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral("></i>&nbsp;");

            
            #line 33 "..\..\Views\System\_MenuEditContext.cshtml"
                                                                                                 Write(Resource.SmallMenu);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"ibox-content\"");

WriteLiteral(">\r\n                <table");

WriteLiteral(" id=\"MenuEdit-Grid3\"");

WriteLiteral(" cellpadding=\"0\"");

WriteLiteral(" cellspacing=\"0\"");

WriteLiteral("></table>\r\n                <div");

WriteLiteral(" id=\"MenuEdit-Pager3\"");

WriteLiteral(" style=\"text-align: center;\"");

WriteLiteral(">\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>" +
"\r\n\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n    function showGrid1() {\r\n        //그리드 서 ㄴ언\r\n        $(\"#MenuEdit-Grid1\").j" +
"qGrid\r\n        ({\r\n            url: paramGrid1.Url,\r\n            datatype: \'json" +
"\',\r\n            mtype: \'GET\',\r\n            //파라메타\r\n            postData: {\r\n    " +
"            isUse: $(\"input[name=\'isUse\']:checked\").val()\r\n            },\r\n     " +
"       hidegrid: true,\r\n            loadonce: true, //이놈을 true주면 리로드가안됨..찾아볼것. t" +
"rue를안주면 하단 page버튼이 활성화안됨..결국 true를 주고 재조회를 수동으로해야할듯!\r\n            navOptions: { " +
"reloadGridOptions: { fromServer: true } },\r\n            loadtext: \'Loading...\',\r" +
"\n            rownumbers: true,\r\n            //pager 기능을 탑에 복사(하단 cloneToTop: tru" +
"e 필요)\r\n            //toppager: true,\r\n            shrinkToFit: true,\r\n          " +
"  loadComplete: function () {\r\n                $(\"#MenuEdit-Grid1\").setSelection" +
"($(\"#MenuEdit-Grid1\").getDataIDs()[0], true);\r\n                showGrid2($(\"#Men" +
"uEdit-Grid1\").getDataIDs()[0]);\r\n            },\r\n            gridComplete: funct" +
"ion () {\r\n            },\r\n            //table header name\r\n            colNames:" +
" paramGrid1.ColName,\r\n            //colModel takes the data from controller and " +
"binds to grid\r\n            colModel: paramGrid1.ColModel,\r\n\r\n            onSelec" +
"tRow: function (id) {\r\n                var rid = jQuery(\'#MenuEdit-Grid1\').jqGri" +
"d(\"getGridParam\", \"selrow\");\r\n                if (rid) {\r\n                    $(" +
"\"#MenuEdit-Grid2\").clearGridData();\r\n                    $(\"#MenuEdit-Grid3\").cl" +
"earGridData();\r\n\r\n                    var row = jQuery(\'#MenuEdit-Grid1\').jqGrid" +
"(\"getRowData\", rid);\r\n                    var Urlstring = \"../System/GetMediumMe" +
"nu?IsUse=\" + $(\"input[name=\'isUse\']:checked\").val() + \"&largeMenuCode=\" + row.Me" +
"nuCode;\r\n\r\n                    $(\"#MenuEdit-Grid2\").setGridParam({ datatype: \'js" +
"on\', page: 1, url: Urlstring }).trigger(\'reloadGrid\');\r\n                }\r\n     " +
"       },\r\n            pager: jQuery(\'#MenuEdit-Pager1\'),\r\n            rowNum: p" +
"aramGrid1.RowNum,\r\n            rowList: paramGrid1.RowList,\r\n            height:" +
" \'100%\',\r\n            viewrecords: true,\r\n            //caption: \'대 메뉴\',\r\n      " +
"      emptyrecords: \'No records to display\',\r\n            autowidth: true,\r\n    " +
"        multiselect: false\r\n        }).navGrid(\'#MenuEdit-Pager1\',\r\n     {\r\n    " +
"     //pager 기능을 탑에 복사 (상단 toppager: true 필요)\r\n         //cloneToTop: true,\r\n   " +
"      edit: false,\r\n         add: false,\r\n         del: false,\r\n         search:" +
" false,\r\n         refresh: false\r\n     });\r\n\r\n        //////////////////////////" +
"/////////////////    Add     ///////////////////////////////////////////////////" +
"/\r\n        var btn = \'<i class=\"fa fa-plus\" aria-hidden=\"true\" style=\"font-size:" +
"1.4rem;\"></i>\';\r\n        $(\"#MenuEdit-Grid1_id\")[0].innerHTML = btn;\r\n        $(" +
"$(\"#MenuEdit-Grid1_id\")[0]).children(\'i\').click(function (e) {\r\n            $(\"#" +
"MenuEdit-Grid1\").editGridRow(\"new\", {\r\n                // add options\r\n         " +
"       zIndex: 100,\r\n                modal: true,\r\n                url: \"../Syst" +
"em/RootCreate\",\r\n                closeOnEscape: true,\r\n                closeAfte" +
"rAdd: true,\r\n                savekey: [true, 1],         //enter키\r\n             " +
"   recreateForm: true,\r\n                beforeInitData: function (formid) {\r\n   " +
"                 $(\"#MenuEdit-Grid1\").jqGrid(\'setColProp\', \'ParentMenuCode\', { e" +
"ditoptions: { defaultValue: \'Root\', readonly: \'readonly\' } });\r\n                " +
"    $(\"#MenuEdit-Grid1\").jqGrid(\"setColProp\", \"IconValue\", {\r\n                  " +
"      edittype: \'custom\',\r\n                        editoptions: {\r\n             " +
"               custom_element: createIcon,\r\n                            custom_v" +
"alue: customValue,\r\n                            dataInit: function (elem) {\r\n   " +
"                         },\r\n                            dataEvents: [\r\n        " +
"                        {\r\n                                    type: \'click\',\r\n " +
"                                   fn: function (e, s) {\r\n                      " +
"                  var selects = $(e.target).attr(\'class\');\r\n\r\n                  " +
"                      if (selects.match(\'fa \')) {\r\n                             " +
"               $(\"#select-icon\").text(selects);\r\n                               " +
"             var form = $(e.target).closest(\'form.FormGrid\');\r\n                 " +
"                           $(\"div#IconValue.customelement\", form[0]).val(selects" +
");\r\n                                        } else {\r\n                          " +
"                  console.log(\"중단\");\r\n                                          " +
"  e.preventDefault();\r\n                                        }\r\n\r\n            " +
"                        }\r\n                                }\r\n                  " +
"          ]\r\n                        }\r\n\r\n                    });\r\n             " +
"       //이곳은 +버튼(추가)을 눌렀을때 타는 로직이다.\r\n                    //MenuEdit.cshtml에 이와 유" +
"사한 로직이 있는데, 그것은 \'수정\'할 때의 로직이다.\r\n                    //그러므로 둘 다 추가해줘야 한다.\r\n      " +
"              $(\"#MenuEdit-Grid1\").jqGrid(\"setColProp\", \"Category\", {\r\n         " +
"               edittype: \'custom\',\r\n                        editoptions: {\r\n    " +
"                        custom_element: createCategoryRadio,\r\n                  " +
"          custom_value: RadioCategoryValue,\r\n                            dataIni" +
"t: function (elem) {\r\n\r\n                            },\r\n                        " +
"    dataEvents: [\r\n                                {\r\n                          " +
"          type: \'change\',\r\n                                    fn: function (e) " +
"{\r\n                                        //if ($(e.target).is(\'input\')) {\r\n   " +
"                                     selectedCategory = $(e.target).attr(\'id\');\r" +
"\n                                        var vals = $(e.target).attr(\'value\')\r\n " +
"                                           , form = $(e.target).closest(\'form.Fo" +
"rmGrid\');\r\n\r\n                                        $(\"span#Category.customelem" +
"ent\", form[0]).val(vals);\r\n                                        if (vals == \"" +
"Menu\") {\r\n                                            //초기화\r\n                   " +
"                         //$(\"#Controller\").val(\'\');\r\n                          " +
"                  //$(\"#Controller\").attr(\"readonly\", true);\r\n                  " +
"                          //$(\"#Controller\").css(\'cursor\', \'not-allowed\');\r\n    " +
"                                        $(\"#ActionMethod\").val(\'\');\r\n           " +
"                                 $(\"#ActionMethod\").attr(\"readonly\", true);\r\n   " +
"                                         $(\"#ActionMethod\").css(\'cursor\', \'not-a" +
"llowed\');\r\n                                        } else if (vals == \"Item\") {\r" +
"\n                                            //$(\"#Controller\").attr(\"readonly\"," +
" false);\r\n                                            //$(\"#Controller\").css(\'cu" +
"rsor\', \'auto\');\r\n                                            $(\"#ActionMethod\")." +
"attr(\"readonly\", false);\r\n                                            $(\"#Action" +
"Method\").css(\'cursor\', \'auto\');\r\n                                        }\r\n    " +
"                                    //}\r\n                                       " +
" //} else {\r\n\r\n                                        //}\r\n                    " +
"                }\r\n                                }\r\n                          " +
"  ]\r\n                        }\r\n                    });\r\n                    $(\"" +
"#MenuEdit-Grid1\").jqGrid(\"setColProp\", \"IsUse\", {\r\n                        editt" +
"ype: \'custom\',\r\n                        editoptions: {\r\n                        " +
"    custom_element: createRadio,\r\n                            custom_value: Radi" +
"oValue,\r\n                            dataInit: function (elem) {\r\n\r\n            " +
"                },\r\n                            dataEvents: [\r\n                 " +
"               {\r\n                                    type: \'click\',\r\n          " +
"                          fn: function (e) {\r\n                                  " +
"      if ($(e.target).is(\'input\')) {\r\n                                          " +
"  selectedIsUse = $(e.target).attr(\'id\');\r\n                                     " +
"       var vals = $(e.target).attr(\'value\')\r\n                                   " +
"             , form = $(e.target).closest(\'form.FormGrid\');\r\n                   " +
"                         $(\"span#IsUse.customelement\", form[0]).val(vals);\r\n    " +
"                                    } else {\r\n\r\n                                " +
"        }\r\n                                    }\r\n                              " +
"  }\r\n                            ]\r\n                        }\r\n                 " +
"   });\r\n                }, afterShowForm: function (m) {\r\n                    $(" +
"\"#select-icon\").text(selectedIcon);\r\n                    $(\"#MenuEdit-Grid1\").jq" +
"Grid(\"setColProp\", \"IconValue\", { value: selectedIcon });\r\n                },\r\n " +
"               afterComplete: function (response) {\r\n                    if (res" +
"ponse.responseText) {\r\n                        alert(response.responseText);\r\n  " +
"                      //재조회\r\n                        $(\"#MenuEdit-Grid1\").setGri" +
"dParam({ datatype: \'json\', page: 1 }).trigger(\'reloadGrid\');\r\n                  " +
"  }\r\n                }\r\n            });\r\n\r\n        })\r\n        /////////////////" +
"//////////////////////////////////////////////////////////////////////////////\r\n" +
"    }\r\n\r\n    function showGrid2(largeMenuCode) {\r\n        //그리드 선언\r\n        $(\"#" +
"MenuEdit-Grid2\").jqGrid\r\n     ({\r\n         url: paramGrid2.Url,\r\n         dataty" +
"pe: \'json\',\r\n         mtype: \'GET\',\r\n         //파라메타\r\n         postData: {\r\n    " +
"         isUse: $(\"input[name=\'isUse\']:checked\").val()\r\n             , largeMenu" +
"Code: largeMenuCode\r\n         },\r\n         hidegrid: true,\r\n         loadonce: t" +
"rue, //이놈을 true주면 리로드가안됨..찾아볼것. true를안주면 하단 page버튼이 활성화안됨..결국 true를 주고 재조회를 수동으로" +
"해야할듯!\r\n         navOptions: { reloadGridOptions: { fromServer: true } },\r\n      " +
"   loadtext: \'Loading...\',\r\n         rownumbers: true,\r\n         //pager 기능을 탑에 " +
"복사(하단 cloneToTop: true 필요)\r\n         //toppager: true,\r\n         shrinkToFit: tr" +
"ue,\r\n         loadComplete: function () {\r\n             $(\"#MenuEdit-Grid2\").set" +
"Selection($(\"#MenuEdit-Grid2\").getDataIDs()[0], true);\r\n             showGrid3($" +
"(\"#MenuEdit-Grid2\").getDataIDs()[0]);\r\n         },\r\n         gridComplete: funct" +
"ion () {\r\n         },\r\n         //table header name\r\n         colNames: paramGri" +
"d2.ColName,\r\n         //colModel takes the data from controller and binds to gri" +
"d\r\n         colModel: paramGrid2.ColModel,\r\n         onSelectRow: function (id) " +
"{\r\n             var rid = jQuery(\'#MenuEdit-Grid2\').jqGrid(\"getGridParam\", \"selr" +
"ow\");\r\n             if (rid) {\r\n                 $(\"#MenuEdit-Grid3\").clearGridD" +
"ata();\r\n\r\n                 var row = jQuery(\'#MenuEdit-Grid2\').jqGrid(\"getRowDat" +
"a\", rid);\r\n                 var Urlstring = \"../System/GetSmallMenu?IsUse=\" + $(" +
"\"input[name=\'isUse\']:checked\").val() + \"&mediumParentMenuCode=\" + row.MenuCode;\r" +
"\n                 $(\"#MenuEdit-Grid3\").setGridParam({ datatype: \'json\', page: 1," +
" url: Urlstring }).trigger(\'reloadGrid\');\r\n             }\r\n         },\r\n        " +
" pager: jQuery(\'#MenuEdit-Pager2\'),\r\n         rowNum: paramGrid1.RowNum,\r\n      " +
"   rowList: paramGrid1.RowList,\r\n         height: \'100%\',\r\n         viewrecords:" +
" true,\r\n         //caption: \'대 메뉴\',\r\n         emptyrecords: \'No records to displ" +
"ay\',\r\n         autowidth: true,\r\n         multiselect: false\r\n     }).navGrid(\'#" +
"MenuEdit-Pager2\',\r\n     {\r\n         //pager 기능을 탑에 복사 (상단 toppager: true 필요)\r\n  " +
"       //cloneToTop: true,\r\n         edit: false,\r\n         add: false,\r\n       " +
"  del: false,\r\n         search: false,\r\n         refresh: false\r\n     });\r\n\r\n   " +
"     var btn = \'<i class=\"fa fa-plus\" aria-hidden=\"true\" style=\"font-size:1.4rem" +
";\"></i>\';\r\n        $(\"#MenuEdit-Grid2_id\")[0].innerHTML = btn;\r\n        $($(\"#Me" +
"nuEdit-Grid2_id\")[0]).children(\'i\').click(function (e) {\r\n            $(\"#MenuEd" +
"it-Grid2\").editGridRow(\"new\", {\r\n                // add options\r\n               " +
" zIndex: 100,\r\n                modal: true,\r\n                url: \"../System/Sub" +
"Create\",\r\n                closeOnEscape: true,\r\n                closeAfterAdd: t" +
"rue,\r\n                savekey: [true, 1],         //enter키\r\n                recr" +
"eateForm: true,\r\n                beforeInitData: function (formid) {\r\n          " +
"          $(\"#MenuEdit-Grid2\").jqGrid(\'setColProp\', \'ParentMenuCode\', { editopti" +
"ons: { defaultValue: $(\"#MenuEdit-Grid1\").jqGrid(\'getGridParam\', \"selrow\"), read" +
"only: \'readonly\' } });\r\n                    $(\"#MenuEdit-Grid2\").jqGrid(\"setColP" +
"rop\", \"IconValue\", {\r\n                        edittype: \'custom\',\r\n             " +
"           editoptions: {\r\n                            custom_element: createIco" +
"n,\r\n                            custom_value: customValue,\r\n                    " +
"        dataInit: function (elem) {\r\n\r\n                                $(\"#selec" +
"t-icon\").text(selectedIcon);\r\n                            },\r\n                  " +
"          dataEvents: [\r\n                                {\r\n                    " +
"                type: \'click\',\r\n                                    fn: function" +
" (e, s) {\r\n                                        var selects = $(e.target).att" +
"r(\'class\');\r\n\r\n                                        if (selects.match(\'fa \'))" +
" {\r\n                                            $(\"#select-icon\").text(selects);" +
"\r\n                                            var form = $(e.target).closest(\'fo" +
"rm.FormGrid\');\r\n                                            $(\"div#IconValue.cus" +
"tomelement\", form[0]).val(selects);\r\n                                        } e" +
"lse {\r\n                                            console.log(\"중단\");\r\n         " +
"                                   e.preventDefault();\r\n                        " +
"                }\r\n\r\n                                    }\r\n                    " +
"            }\r\n                            ]\r\n                        }\r\n\r\n     " +
"               });\r\n\r\n                    $(\"#MenuEdit-Grid2\").jqGrid(\"setColPro" +
"p\", \"Category\", {\r\n                        edittype: \'custom\',\r\n                " +
"        editoptions: {\r\n                            custom_element: createCatego" +
"ryRadio,\r\n                            custom_value: RadioCategoryValue,\r\n       " +
"                     dataInit: function (elem) {\r\n\r\n                            " +
"},\r\n                            dataEvents: [\r\n                                {" +
"\r\n                                    type: \'change\',\r\n                         " +
"           fn: function (e) {\r\n                                        //if ($(e" +
".target).is(\'input\')) {\r\n                                        selectedCategor" +
"y = $(e.target).attr(\'id\');\r\n                                        var vals = " +
"$(e.target).attr(\'value\')\r\n                                            , form = " +
"$(e.target).closest(\'form.FormGrid\');\r\n\r\n                                       " +
" $(\"span#Category.customelement\", form[0]).val(vals);\r\n                         " +
"               if (vals == \"Menu\") {\r\n                                          " +
"  //초기화\r\n                                            //$(\"#Controller\").val(\'\');" +
"\r\n                                            //$(\"#Controller\").attr(\"readonly\"" +
", true);\r\n                                            //$(\"#Controller\").css(\'cu" +
"rsor\', \'not-allowed\');\r\n                                            $(\"#ActionMe" +
"thod\").val(\'\');\r\n                                            $(\"#ActionMethod\")." +
"attr(\"readonly\", true);\r\n                                            $(\"#ActionM" +
"ethod\").css(\'cursor\', \'not-allowed\');\r\n                                        }" +
" else if (vals == \"Item\") {\r\n                                            //$(\"#C" +
"ontroller\").attr(\"readonly\", false);\r\n                                          " +
"  //$(\"#Controller\").css(\'cursor\', \'auto\');\r\n                                   " +
"         $(\"#ActionMethod\").attr(\"readonly\", false);\r\n                          " +
"                  $(\"#ActionMethod\").css(\'cursor\', \'auto\');\r\n                   " +
"                     }\r\n                                        //}\r\n           " +
"                             //} else {\r\n\r\n                                     " +
"   //}\r\n                                    }\r\n                                }" +
"\r\n                            ]\r\n                        }\r\n                    " +
"});\r\n                    $(\"#MenuEdit-Grid2\").jqGrid(\"setColProp\", \"IsUse\", {\r\n " +
"                       edittype: \'custom\',\r\n                        editoptions:" +
" {\r\n                            custom_element: createRadio,\r\n                  " +
"          custom_value: RadioValue,\r\n                            dataInit: funct" +
"ion (elem) {\r\n\r\n                            },\r\n                            data" +
"Events: [\r\n                                {\r\n                                  " +
"  type: \'click\',\r\n                                    fn: function (e) {\r\n      " +
"                                  if ($(e.target).is(\'input\')) {\r\n              " +
"                              selectedIsUse = $(e.target).attr(\'id\');\r\n         " +
"                                   var vals = $(e.target).attr(\'value\')\r\n       " +
"                                         , form = $(e.target).closest(\'form.Form" +
"Grid\');\r\n                                            $(\"span#IsUse.customelement" +
"\", form[0]).val(vals);\r\n                                        } else {\r\n\r\n    " +
"                                    }\r\n                                    }\r\n  " +
"                              }\r\n                            ]\r\n                " +
"        }\r\n                    });\r\n                }, afterShowForm: function (" +
"m) {\r\n                    $(\"#select-icon\").text(selectedIcon);\r\n               " +
"     $(\"#MenuEdit-Grid2\").jqGrid(\"setColProp\", \"IconValue\", { value: selectedIco" +
"n });\r\n                },\r\n                afterComplete: function (response) {\r" +
"\n                    if (response.responseText) {\r\n                        alert" +
"(response.responseText);\r\n                        //재조회\r\n                       " +
" $(\"#MenuEdit-Grid2\").setGridParam({ datatype: \'json\', page: 1 }).trigger(\'reloa" +
"dGrid\');\r\n                    }\r\n                }\r\n            });\r\n        })\r" +
"\n    }\r\n\r\n    function showGrid3(mediumParentMenuCode) {\r\n        //그리드 서 ㄴ언\r\n  " +
"      $(\"#MenuEdit-Grid3\").jqGrid\r\n        ({\r\n            url: paramGrid3.Url,\r" +
"\n            datatype: \'json\',\r\n            mtype: \'GET\',\r\n            //파라메타\r\n " +
"           postData: {\r\n                isUse: $(\"input[name=\'isUse\']:checked\")." +
"val()\r\n                , mediumParentMenuCode: mediumParentMenuCode\r\n           " +
" },\r\n            hidegrid: true,\r\n            loadonce: true, //이놈을 true주면 리로드가안" +
"됨..찾아볼것. true를안주면 하단 page버튼이 활성화안됨..결국 true를 주고 재조회를 수동으로해야할듯!\r\n            navO" +
"ptions: { reloadGridOptions: { fromServer: true } },\r\n            loadtext: \'Loa" +
"ding...\',\r\n            rownumbers: true,\r\n            //pager 기능을 탑에 복사(하단 clone" +
"ToTop: true 필요)\r\n            //toppager: true,\r\n            shrinkToFit: true,\r\n" +
"            loadComplete: function () {\r\n\r\n            },\r\n            //table h" +
"eader name\r\n            colNames: paramGrid3.ColName,\r\n            //colModel ta" +
"kes the data from controller and binds to grid\r\n            colModel: paramGrid3" +
".ColModel,\r\n            onSelectRow: function (id) {\r\n                var rid = " +
"jQuery(\'#MenuEdit-Grid3\').jqGrid(\"getGridParam\", \"selrow\");\r\n                if " +
"(rid) {\r\n\r\n                    var row = jQuery(\'#MenuEdit-Grid3\').jqGrid(\"getRo" +
"wData\", rid);\r\n                }\r\n            },\r\n            pager: jQuery(\'#Me" +
"nuEdit-Pager3\'),\r\n            rowNum: paramGrid1.RowNum,\r\n            rowList: p" +
"aramGrid1.RowList,\r\n            height: \'100%\',\r\n            viewrecords: true,\r" +
"\n            emptyrecords: \'No records to display\',\r\n            autowidth: true" +
",\r\n            multiselect: false\r\n        }).navGrid(\'#MenuEdit-Pager3\',\r\n     " +
"   {\r\n            //pager 기능을 탑에 복사 (상단 toppager: true 필요)\r\n            //cloneT" +
"oTop: true,\r\n            edit: false,\r\n            add: false,\r\n            del:" +
" false,\r\n            search: false,\r\n            refresh: false\r\n        });\r\n\r\n" +
"        var btn = \'<i class=\"fa fa-plus\" aria-hidden=\"true\" style=\"font-size:1.4" +
"rem;\"></i>\';\r\n        $(\"#MenuEdit-Grid3_id\")[0].innerHTML = btn;\r\n        $($(\"" +
"#MenuEdit-Grid3_id\")[0]).children(\'i\').click(function (e) {\r\n\r\n            $(\"#M" +
"enuEdit-Grid3\").editGridRow(\"new\", {\r\n                // add options\r\n          " +
"      zIndex: 100,\r\n                modal: true,\r\n                url: \"../Syste" +
"m/SubCreate\",\r\n                closeOnEscape: true,\r\n                closeAfterA" +
"dd: true,\r\n                savekey: [true, 1],         //enter키\r\n               " +
" recreateForm: true,\r\n                beforeInitData: function (formid) {\r\n     " +
"               $(\"#MenuEdit-Grid3\").jqGrid(\'setColProp\', \'ParentMenuCode\', { edi" +
"toptions: { defaultValue: $(\"#MenuEdit-Grid2\").jqGrid(\'getGridParam\', \"selrow\")," +
" readonly: \'readonly\' } });\r\n                    $(\"#MenuEdit-Grid3\").jqGrid(\"se" +
"tColProp\", \"Category\", {\r\n                        edittype: \'custom\',\r\n         " +
"               editoptions: {\r\n                            custom_element: creat" +
"eCategoryRadio,\r\n                            custom_value: RadioCategoryValue,\r\n" +
"                            dataInit: function (elem) {\r\n\r\n                     " +
"       },\r\n                            dataEvents: [\r\n                          " +
"      {\r\n                                    type: \'change\',\r\n                  " +
"                  fn: function (e) {\r\n                                        //" +
"if ($(e.target).is(\'input\')) {\r\n                                        selected" +
"Category = $(e.target).attr(\'id\');\r\n                                        var " +
"vals = $(e.target).attr(\'value\')\r\n                                            , " +
"form = $(e.target).closest(\'form.FormGrid\');\r\n\r\n                                " +
"        $(\"span#Category.customelement\", form[0]).val(vals);\r\n                  " +
"                      if (vals == \"Menu\") {\r\n                                   " +
"         //초기화\r\n                                            //$(\"#Controller\").v" +
"al(\'\');\r\n                                            //$(\"#Controller\").attr(\"re" +
"adonly\", true);\r\n                                            //$(\"#Controller\")." +
"css(\'cursor\', \'not-allowed\');\r\n                                            $(\"#A" +
"ctionMethod\").val(\'\');\r\n                                            $(\"#ActionMe" +
"thod\").attr(\"readonly\", true);\r\n                                            $(\"#" +
"ActionMethod\").css(\'cursor\', \'not-allowed\');\r\n                                  " +
"      } else if (vals == \"Item\") {\r\n                                            " +
"//$(\"#Controller\").attr(\"readonly\", false);\r\n                                   " +
"         //$(\"#Controller\").css(\'cursor\', \'auto\');\r\n                            " +
"                $(\"#ActionMethod\").attr(\"readonly\", false);\r\n                   " +
"                         $(\"#ActionMethod\").css(\'cursor\', \'auto\');\r\n            " +
"                            }\r\n                                        //}\r\n    " +
"                                    //} else {\r\n\r\n                              " +
"          //}\r\n                                    }\r\n                          " +
"      }\r\n                            ]\r\n                        }\r\n             " +
"       });\r\n                    $(\"#MenuEdit-Grid3\").jqGrid(\"setColProp\", \"IsUse" +
"\", {\r\n                        edittype: \'custom\',\r\n                        edito" +
"ptions: {\r\n                            custom_element: createRadio,\r\n           " +
"                 custom_value: RadioValue,\r\n                            dataInit" +
": function (elem) {\r\n\r\n                            },\r\n                         " +
"   dataEvents: [\r\n                                {\r\n                           " +
"         type: \'click\',\r\n                                    fn: function (e) {\r" +
"\n                                        if ($(e.target).is(\'input\')) {\r\n       " +
"                                     selectedIsUse = $(e.target).attr(\'id\');\r\n  " +
"                                          var vals = $(e.target).attr(\'value\')\r\n" +
"                                                , form = $(e.target).closest(\'fo" +
"rm.FormGrid\');\r\n                                            $(\"span#IsUse.custom" +
"element\", form[0]).val(vals);\r\n                                        } else {\r" +
"\n\r\n                                        }\r\n                                  " +
"  }\r\n                                }\r\n                            ]\r\n         " +
"               }\r\n                    });\r\n                },\r\n                a" +
"fterComplete: function (response) {\r\n                    if (response.responseTe" +
"xt) {\r\n                        alert(response.responseText);\r\n                  " +
"      //재조회\r\n                        $(\"#MenuEdit-Grid3\").setGridParam({ datatyp" +
"e: \'json\', page: 1 }).trigger(\'reloadGrid\');\r\n                    }\r\n           " +
"     }\r\n            });\r\n        })\r\n    }\r\n</script>");

        }
    }
}
#pragma warning restore 1591
