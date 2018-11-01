using RecoWeb.Domain;
using RecoWeb.Module.Models.POCO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;

//2018 04 03 by roy : [RecoWeb.Module] 네임스페이스가 폴더 경로랑 맞지 않지만.. 변경하지 말것! - 변경시 오류남

//namespace RecoWeb.Module
namespace RecoWeb.Module
{
    public static class HMTLHelperExtensions
    {
        public static string IsSelected(this HtmlHelper html, string controller = null, string action = null, string cssClass = null)
        {
            if (String.IsNullOrEmpty(cssClass))
                cssClass = "active";

            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ?
                cssClass : String.Empty;
        }

        public static string PageClass(this HtmlHelper html)
        {
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            return currentAction;
        }

        public static MvcHtmlString RawActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            var repID = Guid.NewGuid().ToString();
            var lnk = ajaxHelper.ActionLink(repID, actionName, controllerName, routeValues, ajaxOptions, htmlAttributes);
            return MvcHtmlString.Create(lnk.ToString().Replace(repID, linkText));
        }

        public static MvcHtmlString RawActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            var repID = Guid.NewGuid().ToString();
            var lnk = ajaxHelper.ActionLink(repID, actionName, routeValues, ajaxOptions, htmlAttributes);
            return MvcHtmlString.Create(lnk.ToString().Replace(repID, linkText));
        }

        public static MvcHtmlString SpanFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            var valueGetter = expression.Compile();
            var value = valueGetter(helper.ViewData.Model);

            var span = new TagBuilder("span");
            span.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            if (value != null)
            {
                span.SetInnerText(value.ToString());
            }

            return MvcHtmlString.Create(span.ToString());
        }

        public static IList ToList(this IQueryable query)
        {
            return (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(query.ElementType), query);
        }

        public static ObjectParameter[] ConvertObjParameters(object[] objParameters)
        {
            ObjectParameter[] returnParameters = new ObjectParameter[objParameters.Length];
            for (int index = 0; index < objParameters.Length; index++)
            {
                if (objParameters[index].GetType().Name.Replace("[]", "") == returnParameters.GetType().Name.Replace("[]", ""))
                {

                    returnParameters[index] = new ObjectParameter(((ObjectParameter)objParameters[index]).Name, typeof(string));
                    returnParameters[index] = new ObjectParameter(((ObjectParameter)objParameters[index]).Name, ((ObjectParameter)objParameters[index]).Value);
                }
                else
                {

                    returnParameters[index] = new ObjectParameter("z_" + index.ToString(), typeof(string));
                    returnParameters[index] = new ObjectParameter("z_" + index.ToString(), objParameters[index].ToString());
                }
            }
            return returnParameters;
        }
    }

    public class MenuHistory
    {
        public List<string> GetMenu(string _action, string _control, string _activePage, List<COW_MenuListByJsonInquiry_Result> menuModel)//List<COW_MenuListByJsonInquiry_Result> menuModel)
        {
            List<string> _menuPage = new List<string>();

            if (menuModel.Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().MenuCode.ToString() != "Root")
            {
                string _categoryMenu = menuModel.Where(s => s.ParentMenuCode == _activePage).FirstOrDefault().MenuCode.ToString();
                if (menuModel.Where(s => s.ParentMenuCode == _activePage).FirstOrDefault().MenuCode.ToString() != "Root")
                {
                    if (menuModel.Where(s => s.ParentMenuCode == _categoryMenu).FirstOrDefault().MenuCode.ToString() != "Root")
                    {
                        //string _topMenu = menuModel.Where(s => s.ParentMenuCode == _activePage).FirstOrDefault().ParentMenuCode.ToString();
                        string _topMenu = menuModel.Where(s => s.ParentMenuCode == _activePage).FirstOrDefault().Controller.ToString();
                        _menuPage.Add(_topMenu);
                    }
                }
                _menuPage.Add(_categoryMenu);
            }

            _menuPage.Add(_activePage);

            return _menuPage;
        }
    }


}
