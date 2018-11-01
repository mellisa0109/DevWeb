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
    
    #line 3 "..\..\Views\Shared\_Navigation.cshtml"
    using System.Globalization;
    
    #line default
    #line hidden
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    
    #line 4 "..\..\Views\Shared\_Navigation.cshtml"
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
    
    #line 5 "..\..\Views\Shared\_Navigation.cshtml"
    using System.Xml;
    
    #line default
    #line hidden
    using DevExtreme.AspNet.Mvc;
    
    #line 6 "..\..\Views\Shared\_Navigation.cshtml"
    using RecoWeb.Module;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/_Navigation.cshtml")]
    public partial class _Views_Shared__Navigation_cshtml : System.Web.Mvc.WebViewPage<RecoWeb.Module.Models.NavMenuInquiryViewModel>
    {
        public _Views_Shared__Navigation_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("\r\n");

            
            #line 8 "..\..\Views\Shared\_Navigation.cshtml"
  
    var _action = this.Url.RequestContext.RouteData.Values["action"].ToString();
    var _control = this.Url.RequestContext.RouteData.Values["controller"].ToString();

    var _menu = "";
    var _middlemenu = "";
    var _item = "";
    var _recentVisitCount = "";
    XmlDocument xml = new XmlDocument();
    xml.Load(Server.MapPath("~/Settings/webSettings.xml"));
    if (xml != null)
    {
        _recentVisitCount = xml.GetElementsByTagName("RecentVisitCount")[0].InnerText;
    }


    if (Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).Count() > 0)
    {
        if (Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).Count() > 0)
        { _middlemenu = Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().MenuCode.ToString(); }
        if (Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).Count() > 0)
        { _item = Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().ParentMenuCode.ToString(); }

        if (_middlemenu != "")
        {
            if (Model.COW_NavMenuListInquiry.Where(s => s.ParentMenuCode == _middlemenu).Count() > 0)
            {
                _menu = Model.COW_NavMenuListInquiry.Where(s => s.ParentMenuCode == _middlemenu).FirstOrDefault().MenuCode.ToString();
            }

            if(_menu == "Root")
            {
                _menu = _middlemenu;
                _middlemenu = _item;
            }
        }

        if (Session["MenuHistory"] != null)
        {
            var menuList = (Session["MenuHistory"] as List<Tuple<string, string, string>>);

            //최근 방문 리스트에 선택한 메뉴가 존재한다면
            if (menuList.Contains(new Tuple<string, string, string>(Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().ActionMethod.ToString()
            , Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().Controller.ToString()
            , "Menu_" + Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().ActionMethod.ToString())))
            {
                //선택한 메뉴 지우고, 새로 넣어줌
                menuList.Remove(new Tuple<string, string, string>(Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().ActionMethod.ToString()
                , Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().Controller.ToString()
                , "Menu_" + Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().ActionMethod.ToString()));

                menuList.Add(new Tuple<string, string, string>(Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().ActionMethod.ToString()
                , Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().Controller.ToString()
                , "Menu_" + Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().ActionMethod.ToString()));
                
            }
            else
            {
                //존재하지 않는다면 단순 추가
                menuList.Add(new Tuple<string, string, string>(Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().ActionMethod.ToString()
                    , Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().Controller.ToString()
                    , "Menu_" + Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().ActionMethod.ToString()));
            }

            //최근 방문 메뉴 사이즈 체크
            for (int dCount = menuList.Count; dCount > Convert.ToInt32(_recentVisitCount); dCount = menuList.Count)
            {
                menuList.RemoveAt(0);
            }
            Session["MenuHistory"] = menuList;

            //var dictionary = (Session["MenuHistory"] as SortedDictionary<int, Tuple<string,string,string>>);

            //if (!dictionary.ContainsValue(new Tuple<string,string,string>(Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().ActionMethod.ToString()
            //, Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().Controller.ToString()
            //, "Menu_" + Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().ActionMethod.ToString())))
            //{
            //    for(int dCount = dictionary.Count; dCount >= Convert.ToInt32(_recentVisitCount); dCount = dictionary.Count)
            //    {
            //        dictionary.Remove(dictionary.First().Key);
            //    }

            //    dictionary.Add(dictionary.Last().Key + 1, new Tuple<string, string, string>(Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().ActionMethod.ToString()
            //        , Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().Controller.ToString()
            //        , "Menu_" + Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().ActionMethod.ToString())
            //                );
            //    Session["MenuHistory"] = dictionary;
            //}
        }
        else
        {
            List<Tuple<string, string, string>> currentMenu = new List<Tuple<string, string, string>>()
                {
                    {new Tuple<string,string,string>(Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().ActionMethod.ToString()
                    , Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().Controller.ToString()
                    , "Menu_"+Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().ActionMethod.ToString()) }
                };

            Session.Add("MenuHistory", currentMenu);


            //SortedDictionary<int, Tuple<string, string, string>> currentMenu = new SortedDictionary<int, Tuple<string, string, string>>()
            //    {
            //        {0, new Tuple<string,string,string>(Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().ActionMethod.ToString()
            //        , Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().Controller.ToString()
            //        , "Menu_"+Model.COW_NavMenuListInquiry.Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().ActionMethod.ToString()) }
            //    };

            //Session.Add("MenuHistory", currentMenu);
        }
    }

    var south_korea = Url.Content("~/Content/Images/south-korea_clicked_32.png");
    var usa = Url.Content("~/Content/Images/usa_clicked_32.png");
    if (Session["CurrentCulture"] != null)
    {
        if(Session["CurrentCulture"].ToString() == "0")
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
WriteLiteral("\r\n\r\n<nav");

WriteLiteral(" class=\"navbar-default navbar-static-side\"");

WriteLiteral(" role=\"navigation\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"sidebar-collapse\"");

WriteLiteral(">\r\n        <ul");

WriteLiteral(" class=\"nav\"");

WriteLiteral(" id=\"side-menu\"");

WriteLiteral(">\r\n\r\n            ");

WriteLiteral("\r\n            ");

WriteLiteral("     \r\n            \r\n            ");

WriteLiteral("\r\n            <li");

WriteLiteral(" class=\"in \"");

WriteLiteral(">\r\n                <a");

WriteAttribute("href", Tuple.Create(" href=\"", 8740), Tuple.Create("\"", 8774)
            
            #line 148 "..\..\Views\Shared\_Navigation.cshtml"
, Tuple.Create(Tuple.Create("", 8747), Tuple.Create<System.Object, System.Int32>(Url.Action("Index","Home")
            
            #line default
            #line hidden
, 8747), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-home\"");

WriteLiteral("></i>\r\n                    <span");

WriteLiteral(" class=\"nav-label\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 150 "..\..\Views\Shared\_Navigation.cshtml"
                   Write(Model.resourceManager.String("Menu_Home"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </span></a>\r\n            </li>\r\n\r\n");

            
            #line 154 "..\..\Views\Shared\_Navigation.cshtml"
            
            
            #line default
            #line hidden
            
            #line 154 "..\..\Views\Shared\_Navigation.cshtml"
             foreach (var menu in Model.COW_NavMenuListInquiry.Where(s => s.MenuCode == "Root"))
            {

            
            #line default
            #line hidden
WriteLiteral("                    <li");

WriteAttribute("class", Tuple.Create(" class=\"", 9108), Tuple.Create("\"", 9293)
, Tuple.Create(Tuple.Create("", 9116), Tuple.Create<System.Object, System.Int32>(new System.Web.WebPages.HelperResult(__razor_attribute_value_writer => {

            
            #line 156 "..\..\Views\Shared\_Navigation.cshtml"
                                if (menu.ParentMenuCode == _menu || menu.ActionMethod != "") {
            
            #line default
            #line hidden
            
            #line 156 "..\..\Views\Shared\_Navigation.cshtml"
                                                       WriteTo(__razor_attribute_value_writer, Html.IsSelected(action: menu.ActionMethod));

            
            #line default
            #line hidden
            
            #line 156 "..\..\Views\Shared\_Navigation.cshtml"
                                                                                                                                         } else { 
            
            #line default
            #line hidden
            
            #line 156 "..\..\Views\Shared\_Navigation.cshtml"
                                                                                                           WriteTo(__razor_attribute_value_writer, Html.IsSelected(action: menu.ActionMethod, cssClass: "in"));

            
            #line default
            #line hidden
            
            #line 156 "..\..\Views\Shared\_Navigation.cshtml"
                                                                                                                                                                                                              }
            
            #line default
            #line hidden
}), 9116), false)
, Tuple.Create(Tuple.Create(" ", 9292), Tuple.Create("", 9292), true)
);

WriteLiteral(">\r\n                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 9323), Tuple.Create("\"", 9377)
            
            #line 157 "..\..\Views\Shared\_Navigation.cshtml"
, Tuple.Create(Tuple.Create("", 9330), Tuple.Create<System.Object, System.Int32>(Url.Action(menu.ActionMethod, menu.Controller)
            
            #line default
            #line hidden
, 9330), false)
);

WriteLiteral("><i");

WriteAttribute("class", Tuple.Create(" class=\"", 9381), Tuple.Create("\"", 9399)
            
            #line 157 "..\..\Views\Shared\_Navigation.cshtml"
            , Tuple.Create(Tuple.Create("", 9389), Tuple.Create<System.Object, System.Int32>(menu.Icon
            
            #line default
            #line hidden
, 9389), false)
);

WriteLiteral("></i>\r\n                            <span");

WriteLiteral(" class=\"nav-label\"");

WriteLiteral(">                                \r\n");

WriteLiteral("                                ");

            
            #line 159 "..\..\Views\Shared\_Navigation.cshtml"
                           Write(Model.resourceManager.String("Menu_" + @menu.ParentMenuCode.ToString()));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </span> ");

            
            #line 160 "..\..\Views\Shared\_Navigation.cshtml"
                                     if (Model.COW_NavMenuListInquiry.Where(s => s.MenuCode == menu.ParentMenuCode).Count() > 0) {
            
            #line default
            #line hidden
WriteLiteral("<span");

WriteLiteral(" class=\"fa arrow\"");

WriteLiteral("></span>");

            
            #line 160 "..\..\Views\Shared\_Navigation.cshtml"
                                                                                                                                                                }
            
            #line default
            #line hidden
WriteLiteral("</a>\r\n\r\n");

            
            #line 162 "..\..\Views\Shared\_Navigation.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 162 "..\..\Views\Shared\_Navigation.cshtml"
                         if (Model.COW_NavMenuListInquiry.Where(s => s.MenuCode == menu.ParentMenuCode).Count() > 0)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <ul");

WriteAttribute("class", Tuple.Create(" class=\"", 9944), Tuple.Create("\"", 10047)
, Tuple.Create(Tuple.Create("", 9952), Tuple.Create("nav", 9952), true)
, Tuple.Create(Tuple.Create(" ", 9955), Tuple.Create("nav-second-level", 9956), true)
, Tuple.Create(Tuple.Create(" ", 9972), Tuple.Create("collapse", 9973), true)
            
            #line 164 "..\..\Views\Shared\_Navigation.cshtml"
, Tuple.Create(Tuple.Create(" ", 9981), Tuple.Create<System.Object, System.Int32>(Html.IsSelected(controller: menu.ParentMenuCode, cssClass: "in")
            
            #line default
            #line hidden
, 9982), false)
);

WriteLiteral(">\r\n");

            
            #line 165 "..\..\Views\Shared\_Navigation.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 165 "..\..\Views\Shared\_Navigation.cshtml"
                                 foreach (var middle in Model.COW_NavMenuListInquiry.Where(s => s.MenuCode == menu.ParentMenuCode))
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <li");

WriteAttribute("class", Tuple.Create(" class=\"", 10258), Tuple.Create("\"", 10458)
, Tuple.Create(Tuple.Create("", 10266), Tuple.Create<System.Object, System.Int32>(new System.Web.WebPages.HelperResult(__razor_attribute_value_writer => {

            
            #line 167 "..\..\Views\Shared\_Navigation.cshtml"
                                                if (middle.ParentMenuCode != _middlemenu || middle.ParentMenuCode == "") {
            
            #line default
            #line hidden
            
            #line 167 "..\..\Views\Shared\_Navigation.cshtml"
                                                                                   WriteTo(__razor_attribute_value_writer, Html.IsSelected(action: middle.ActionMethod, cssClass: "in"));

            
            #line default
            #line hidden
            
            #line 167 "..\..\Views\Shared\_Navigation.cshtml"
                                                                                                                                                                                       } else { 
            
            #line default
            #line hidden
            
            #line 167 "..\..\Views\Shared\_Navigation.cshtml"
                                                                                                                                                         WriteTo(__razor_attribute_value_writer, Html.IsSelected(action: middle.ActionMethod));

            
            #line default
            #line hidden
            
            #line 167 "..\..\Views\Shared\_Navigation.cshtml"
                                                                                                                                                                                                                                              }
            
            #line default
            #line hidden
}), 10266), false)
);

WriteLiteral(">\r\n                                        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 10504), Tuple.Create("\"", 10562)
            
            #line 168 "..\..\Views\Shared\_Navigation.cshtml"
, Tuple.Create(Tuple.Create("", 10511), Tuple.Create<System.Object, System.Int32>(Url.Action(middle.ActionMethod, middle.Controller)
            
            #line default
            #line hidden
, 10511), false)
);

WriteLiteral("><i");

WriteAttribute("class", Tuple.Create(" class=\"", 10566), Tuple.Create("\"", 10598)
            
            #line 168 "..\..\Views\Shared\_Navigation.cshtml"
                               , Tuple.Create(Tuple.Create("", 10574), Tuple.Create<System.Object, System.Int32>(middle.Icon
            
            #line default
            #line hidden
, 10574), false)
, Tuple.Create(Tuple.Create(" ", 10586), Tuple.Create("only-mobile", 10587), true)
);

WriteLiteral("></i>\r\n                                            <span");

WriteLiteral(" class=\"nav-label only-mobile\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                ");

            
            #line 170 "..\..\Views\Shared\_Navigation.cshtml"
                                           Write(Model.resourceManager.String("Menu_" + @middle.ParentMenuCode.ToString()));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </span>");

            
            #line 171 "..\..\Views\Shared\_Navigation.cshtml"
                                                    if (Model.COW_NavMenuListInquiry.Where(s => s.MenuCode == middle.ParentMenuCode).Count() > 0) {
            
            #line default
            #line hidden
WriteLiteral("<span");

WriteLiteral(" class=\"fa arrow only-mobile\"");

WriteLiteral("></span>");

            
            #line 171 "..\..\Views\Shared\_Navigation.cshtml"
                                                                                                                                                                                             }
            
            #line default
            #line hidden
WriteLiteral("</a>\r\n");

            
            #line 172 "..\..\Views\Shared\_Navigation.cshtml"
                                        
            
            #line default
            #line hidden
            
            #line 172 "..\..\Views\Shared\_Navigation.cshtml"
                                         if (Model.COW_NavMenuListInquiry.Where(s => s.MenuCode == middle.ParentMenuCode).Count() > 0)
                                        {
                                            if (middle.ParentMenuCode == _middlemenu)
                                            {

            
            #line default
            #line hidden
WriteLiteral("                                                <ul");

WriteAttribute("class", Tuple.Create(" class=\"", 11372), Tuple.Create("\"", 11474)
, Tuple.Create(Tuple.Create("", 11380), Tuple.Create("nav", 11380), true)
, Tuple.Create(Tuple.Create(" ", 11383), Tuple.Create("nav-third-level", 11384), true)
, Tuple.Create(Tuple.Create(" ", 11399), Tuple.Create("collapse", 11400), true)
            
            #line 176 "..\..\Views\Shared\_Navigation.cshtml"
      , Tuple.Create(Tuple.Create(" ", 11408), Tuple.Create<System.Object, System.Int32>(Html.IsSelected(controller: menu.ParentMenuCode, cssClass: "in")
            
            #line default
            #line hidden
, 11409), false)
);

WriteLiteral(">\r\n");

            
            #line 177 "..\..\Views\Shared\_Navigation.cshtml"
                                                    
            
            #line default
            #line hidden
            
            #line 177 "..\..\Views\Shared\_Navigation.cshtml"
                                                     foreach (var item in Model.COW_NavMenuListInquiry.Where(s => s.MenuCode == middle.ParentMenuCode))
                                                    {

            
            #line default
            #line hidden
WriteLiteral("                                                        <li");

WriteAttribute("class", Tuple.Create(" class=\"", 11745), Tuple.Create("\"", 11796)
            
            #line 179 "..\..\Views\Shared\_Navigation.cshtml"
, Tuple.Create(Tuple.Create("", 11753), Tuple.Create<System.Object, System.Int32>(Html.IsSelected(action: item.ActionMethod)
            
            #line default
            #line hidden
, 11753), false)
);

WriteLiteral(">\r\n                                                            <a");

WriteAttribute("href", Tuple.Create(" href=\"", 11862), Tuple.Create("\"", 11916)
            
            #line 180 "..\..\Views\Shared\_Navigation.cshtml"
, Tuple.Create(Tuple.Create("", 11869), Tuple.Create<System.Object, System.Int32>(Url.Action(item.ActionMethod, item.Controller)
            
            #line default
            #line hidden
, 11869), false)
);

WriteLiteral(" class=\"nav-third-item\"");

WriteLiteral("><i");

WriteAttribute("class", Tuple.Create(" class=\"", 11943), Tuple.Create("\"", 11973)
            
            #line 180 "..\..\Views\Shared\_Navigation.cshtml"
                                                                      , Tuple.Create(Tuple.Create("", 11951), Tuple.Create<System.Object, System.Int32>(item.Icon
            
            #line default
            #line hidden
, 11951), false)
, Tuple.Create(Tuple.Create(" ", 11961), Tuple.Create("only-mobile", 11962), true)
);

WriteLiteral("></i>\r\n                                                                <span");

WriteLiteral(" class=\"nav-label only-mobile\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                                    ");

            
            #line 182 "..\..\Views\Shared\_Navigation.cshtml"
                                                               Write(Model.resourceManager.String("Menu_" + @item.ParentMenuCode.ToString()));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                                </span> </a>\r\n " +
"                                                       </li>\r\n");

            
            #line 185 "..\..\Views\Shared\_Navigation.cshtml"
                                                    }

            
            #line default
            #line hidden
WriteLiteral("                                                </ul>\r\n");

            
            #line 187 "..\..\Views\Shared\_Navigation.cshtml"
                                            }
                                            else
                                            {

            
            #line default
            #line hidden
WriteLiteral("                                                <ul");

WriteAttribute("class", Tuple.Create(" class=\"", 12671), Tuple.Create("\"", 12757)
, Tuple.Create(Tuple.Create("", 12679), Tuple.Create("nav", 12679), true)
, Tuple.Create(Tuple.Create(" ", 12682), Tuple.Create("nav-third-level", 12683), true)
, Tuple.Create(Tuple.Create(" ", 12698), Tuple.Create("collapse", 12699), true)
            
            #line 190 "..\..\Views\Shared\_Navigation.cshtml"
      , Tuple.Create(Tuple.Create(" ", 12707), Tuple.Create<System.Object, System.Int32>(Html.IsSelected(controller: menu.ParentMenuCode)
            
            #line default
            #line hidden
, 12708), false)
);

WriteLiteral(">\r\n");

            
            #line 191 "..\..\Views\Shared\_Navigation.cshtml"
                                                    
            
            #line default
            #line hidden
            
            #line 191 "..\..\Views\Shared\_Navigation.cshtml"
                                                     foreach (var item in Model.COW_NavMenuListInquiry.Where(s => s.MenuCode == middle.ParentMenuCode))
                                                    {

            
            #line default
            #line hidden
WriteLiteral("                                                        <li");

WriteAttribute("class", Tuple.Create(" class=\"", 13028), Tuple.Create("\"", 13095)
            
            #line 193 "..\..\Views\Shared\_Navigation.cshtml"
, Tuple.Create(Tuple.Create("", 13036), Tuple.Create<System.Object, System.Int32>(Html.IsSelected(action: item.ActionMethod, cssClass: "in")
            
            #line default
            #line hidden
, 13036), false)
);

WriteLiteral(">\r\n                                                            <a");

WriteAttribute("href", Tuple.Create(" href=\"", 13161), Tuple.Create("\"", 13215)
            
            #line 194 "..\..\Views\Shared\_Navigation.cshtml"
, Tuple.Create(Tuple.Create("", 13168), Tuple.Create<System.Object, System.Int32>(Url.Action(item.ActionMethod, item.Controller)
            
            #line default
            #line hidden
, 13168), false)
);

WriteLiteral(" class=\"nav-third-item\"");

WriteLiteral("><i");

WriteAttribute("class", Tuple.Create(" class=\"", 13242), Tuple.Create("\"", 13272)
            
            #line 194 "..\..\Views\Shared\_Navigation.cshtml"
                                                                      , Tuple.Create(Tuple.Create("", 13250), Tuple.Create<System.Object, System.Int32>(item.Icon
            
            #line default
            #line hidden
, 13250), false)
, Tuple.Create(Tuple.Create(" ", 13260), Tuple.Create("only-mobile", 13261), true)
);

WriteLiteral("></i>\r\n                                                                <span");

WriteLiteral(" class=\"nav-label only-mobile\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                                    ");

            
            #line 196 "..\..\Views\Shared\_Navigation.cshtml"
                                                               Write(Model.resourceManager.String("Menu_" + @item.ParentMenuCode.ToString()));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                                </span> </a>\r\n " +
"                                                       </li>\r\n");

            
            #line 199 "..\..\Views\Shared\_Navigation.cshtml"
                                                    }

            
            #line default
            #line hidden
WriteLiteral("                                                </ul>\r\n");

            
            #line 201 "..\..\Views\Shared\_Navigation.cshtml"
                                            }
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                    </li>\r\n");

            
            #line 204 "..\..\Views\Shared\_Navigation.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                            </ul>\r\n");

            
            #line 206 "..\..\Views\Shared\_Navigation.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </li>\r\n");

            
            #line 208 "..\..\Views\Shared\_Navigation.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("\r\n                ");

WriteLiteral("\r\n            </ul>\r\n        </div>\r\n    </nav>\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n<script");

WriteLiteral(" src=\"../Scripts/jquery-3.1.1.min.js\"");

WriteLiteral("></script>\r\n<script");

WriteLiteral(" src=\"../Content/style.css\"");

WriteLiteral("></script>\r\n<script");

WriteLiteral(" src=\"../Content/reco_style.css\"");

WriteLiteral("></script>\r\n");

});

WriteLiteral("\r\n");

WriteLiteral("\r\n");

WriteLiteral("\r\n\r\n\r\n                    ");

WriteLiteral("\r\n\r\n");

WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591
