using RecoWeb.Module;
//using RecoWeb.Module.Interfaces;
using RecoWeb.Module.Models;
using RecoWeb.Module.Infrastructure.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web.Mvc;
using System.Xml;
using RecoWeb.Module.Models.POCO;
using Newtonsoft.Json;
using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Data;

namespace RecoWeb.Module.Controllers
{
    [Authorize]
    public class SystemController : BaseController
    {
        //2018 07 20 by roy (1) : BaseController에서 하단으로 내려옴
        public ResourceWrapper _resourceManager = new ResourceWrapper();

        private DomainConnectionManager DomainManager;
        public SystemController(DomainConnectionManager Domains)
        {
            this.DomainManager = Domains;
        }

        #region 메뉴 편집
        /// <summary>
        /// 메뉴 편집
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MenuEdit()
        {
            string rmString = _resourceManager.String("ExamplePage");

            var _action = this.Url.RequestContext.RouteData.Values["action"].ToString();
            var _control = this.Url.RequestContext.RouteData.Values["controller"].ToString();
            string _activePage = "";
            if (Session["Menu"] != null)
            {
                _activePage = DomainManager.GetEntityToList<COW_MenuListByJsonInquiry_Result>("COW_MenuListByJsonInquiry", null).Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().ParentMenuCode.ToString();
            }
            else
            {
                _activePage = DomainManager.GetEntityToList<COW_MenuListByJsonInquiry_Result>("COW_MenuListByJsonInquiry", null).Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().ParentMenuCode.ToString();
            }

            MenuHistory getMenuLocation = new MenuHistory();
            List<string> _menuPage = new List<string>(getMenuLocation.GetMenu(_action, _control, _activePage, DomainManager.GetEntityToList<COW_MenuListByJsonInquiry_Result>("COW_MenuListByJsonInquiry", null).ToList()));


            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_IsUse", true);

            Dapper.DynamicParameters parameters02 = new Dapper.DynamicParameters();
            parameters02.Add("@p_IsUse", true);
            parameters02.Add("@p_ParentMenuCode", "");

            COW_MenuListInquiryViewModel viewModel = new COW_MenuListInquiryViewModel
            {
                COW_RootMenuListInquiry = DomainManager.GetEntityToList<COW_RootMenuListInquiry_Result>("COW_RootMenuListInquiry", parameters01).ToList()
                ,
                COW_SubMenuListInquiry = DomainManager.GetEntityToList<COW_SubMenuListInquiry_Result>("COW_SubMenuListInquiry", parameters02).ToList()
                ,
                MenuLocation = _menuPage
                ,
                ActivePage = _activePage
                ,
                isUse = true
                ,
                resourceManager = _resourceManager
            };

            return View(viewModel);
        }

        public PartialViewResult AjaxInquiryContextMenu()
        {
            return PartialView("_MenuEditContext");
        }

        [HttpGet]
        public JsonResult GetLargeMenu(bool isUse)
        {
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_IsUse", isUse);

            COW_MenuListInquiryViewModel viewModel = new COW_MenuListInquiryViewModel
            {
                COW_RootMenuListInquiry = DomainManager.GetEntityToList<COW_RootMenuListInquiry_Result>("COW_RootMenuListInquiry", parameters01)
            };

            return Json(viewModel.COW_RootMenuListInquiry, JsonRequestBehavior.AllowGet);

            //var result = DataSourceLoader.Load(DomainManager.GetEntityToList<COW_RootMenuListInquiry_Result>("COW_RootMenuListInquiry", parameters01), loadOptions);
            //var resultJson = JsonConvert.SerializeObject(result);
            //return Content(resultJson, "application/json");
        }

        [HttpGet]
        public ActionResult GetMediumMenu(bool isUse, string largeMenuCode)//, DataSourceLoadOptions loadOptions)
        {
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_IsUse", isUse);
            parameters01.Add("@p_ParentMenuCode", largeMenuCode);

            COW_MenuListInquiryViewModel viewModel = new COW_MenuListInquiryViewModel
            {
                COW_SubMenuListInquiry = DomainManager.GetEntityToList<COW_SubMenuListInquiry_Result>("COW_SubMenuListInquiry", parameters01)
            };

            return Json(viewModel.COW_SubMenuListInquiry, JsonRequestBehavior.AllowGet);

            //var result = DataSourceLoader.Load(DomainManager.GetEntityToList<COW_SubMenuListInquiry_Result>("COW_SubMenuListInquiry", parameters01), loadOptions);
            //var resultJson = JsonConvert.SerializeObject(result);
            //return Content(resultJson, "application/json");
        }

        [HttpGet]
        public ActionResult GetSmallMenu(bool isUse, string mediumParentMenuCode)//, DataSourceLoadOptions loadOptions)
        {
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_IsUse", isUse);
            parameters01.Add("@p_ParentMenuCode", mediumParentMenuCode);

            COW_MenuListInquiryViewModel viewModel = new COW_MenuListInquiryViewModel
            {
                COW_SubMenuListInquiry = DomainManager.GetEntityToList<COW_SubMenuListInquiry_Result>("COW_SubMenuListInquiry", parameters01)
            };

            return Json(viewModel.COW_SubMenuListInquiry, JsonRequestBehavior.AllowGet);
            //주섟풀기
            //var result = DataSourceLoader.Load(DomainManager.GetEntityToList<COW_SubMenuListInquiry_Result>("COW_SubMenuListInquiry", parameters01), loadOptions);
            //var resultJson = JsonConvert.SerializeObject(result);
            //return Content(resultJson, "application/json");
        }

        [HttpPost]
        public string RootCreate([Bind(Exclude = "Id")] COW_RootMenuListInquiry_Result obj)
        {

            string msg;

            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_MenuCode", obj.MenuCode);
            parameters01.Add("@p_MenuName", obj.MenuName);
            parameters01.Add("@p_Description", obj.Description);
            parameters01.Add("@p_Sequence", Convert.ToInt32(obj.Sequence));
            parameters01.Add("@p_ParentMenuCode", "Root");
            parameters01.Add("@p_Category", obj.Category);
            parameters01.Add("@p_Controller", obj.Controller);
            parameters01.Add("@p_ActionMethod", obj.ActionMethod);
            parameters01.Add("@p_Icon", obj.IconValue);
            parameters01.Add("@p_IsUse", Convert.ToBoolean(Convert.ToInt16(obj.IsUse)));
            parameters01.Add("@p_UserName", HttpContext.User.Identity.Name);
            parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

            try
            {
                if (ModelState.IsValid)
                {
                    var returnParameter = DomainManager.GetEntityResult("COW_MenuListSave", parameters01);

                    if (parameters01.Get<string>("@p_OutMessage").ToString() == "OK")
                        msg = "Saved Successfully";
                    else
                        msg = parameters01.Get<string>("@p_OutMessage").ToString();
                }
                else
                {
                    msg = "Validation data not successfull";
                }
                return msg;
                //return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
                return msg;
                //return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
        }



        public string RootEdit(COW_RootMenuListInquiry_Result obj, string id)
        {
            string msg;
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_MenuCode", obj.MenuCode);
            parameters01.Add("@p_MenuName", obj.MenuName);
            parameters01.Add("@p_Description", obj.Description);
            parameters01.Add("@p_Sequence", Convert.ToInt32(obj.Sequence));
            parameters01.Add("@p_ParentMenuCode", obj.ParentMenuCode);
            parameters01.Add("@p_Category", obj.Category);
            parameters01.Add("@p_Controller", obj.Controller);
            parameters01.Add("@p_ActionMethod", obj.ActionMethod);
            parameters01.Add("@p_Icon", obj.IconValue);
            parameters01.Add("@p_IsUse", Convert.ToBoolean(Convert.ToInt16(obj.IsUse)));
            parameters01.Add("@p_UserName", HttpContext.User.Identity.Name);
            parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

            try
            {
                if (ModelState.IsValid)
                {
                    var returnParameter = DomainManager.GetEntityResult("COW_MenuListSave", parameters01);

                    if (parameters01.Get<string>("@p_OutMessage").ToString() == "OK")
                        msg = "Saved Successfully";
                    else
                        msg = parameters01.Get<string>("@p_OutMessage").ToString();
                }
                else
                {
                    msg = "Validation data not successfull";
                }
                return msg;
                //return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
                return msg;
                //return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
        }


        [HttpPost]
        public ActionResult Delete(string menuCode, string parentMenuCode)
        {
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_MenuCode", menuCode);
            parameters01.Add("@p_ParentMenuCode", parentMenuCode);
            parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

            var returnParameter = DomainManager.GetEntityResult("COW_MenuListDelete", parameters01);
            //return new HttpStatusCodeResult(HttpStatusCode.Created);
            return Json(parameters01.Get<string>("@p_OutMessage").ToString());
        }

        [HttpPost]
        public string SubCreate([Bind(Exclude = "Id")] COW_SubMenuListInquiry_Result obj)
        {
            string msg;
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_MenuCode", obj.MenuCode);
            parameters01.Add("@p_MenuName", obj.MenuName);
            parameters01.Add("@p_Description", obj.Description);
            parameters01.Add("@p_Sequence", Convert.ToInt32(obj.Sequence));
            parameters01.Add("@p_ParentMenuCode", obj.ParentMenuCode);
            parameters01.Add("@p_Category", obj.Category);
            parameters01.Add("@p_Controller", obj.Controller);
            parameters01.Add("@p_ActionMethod", obj.ActionMethod);
            parameters01.Add("@p_Icon", obj.IconValue == null ? "" : obj.IconValue);
            parameters01.Add("@p_IsUse", Convert.ToBoolean(Convert.ToInt16(obj.IsUse)));
            parameters01.Add("@p_UserName", HttpContext.User.Identity.Name);
            parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

            try
            {
                if (ModelState.IsValid)
                {
                    var returnParameter = DomainManager.GetEntityResult("COW_MenuListSave", parameters01);

                    if (parameters01.Get<string>("@p_OutMessage").ToString() == "OK")
                        msg = "Saved Successfully";
                    else
                        msg = parameters01.Get<string>("@p_OutMessage").ToString();
                }
                else
                {
                    msg = "Validation data not successfull";
                }
                return msg;
                //return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
                return msg;
                //return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
        }

        //변경전 리턴타입 ActionResult
        public string SubEdit(COW_SubMenuListInquiry_Result obj, string id)
        {
            string msg;
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_MenuCode", obj.MenuCode);
            parameters01.Add("@p_MenuName", obj.MenuName);
            parameters01.Add("@p_Description", obj.Description);
            parameters01.Add("@p_Sequence", Convert.ToInt32(obj.Sequence));
            parameters01.Add("@p_ParentMenuCode", obj.ParentMenuCode);
            parameters01.Add("@p_Category", obj.Category);
            parameters01.Add("@p_Controller", obj.Controller);
            parameters01.Add("@p_ActionMethod", obj.ActionMethod);
            parameters01.Add("@p_Icon", obj.IconValue == null ? "" : obj.IconValue);
            parameters01.Add("@p_IsUse", Convert.ToBoolean(Convert.ToInt16(obj.IsUse)));
            parameters01.Add("@p_UserName", HttpContext.User.Identity.Name);
            parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

            try
            {
                if (ModelState.IsValid)
                {
                    var returnParameter = DomainManager.GetEntityResult("COW_MenuListSave", parameters01);

                    if (parameters01.Get<string>("@p_OutMessage").ToString() == "OK")
                        msg = "Saved Successfully";
                    else
                        msg = parameters01.Get<string>("@p_OutMessage").ToString();
                }
                else
                {
                    msg = "Validation data not successfull";
                }
                return msg;
                //return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
                return msg;
                //return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
        }

        #endregion

        #region 시스템 환경설정

        //public ICommon _iCommon { get; set; }

        /// <summary>
        /// 웹 시스템 환경설정
        /// </summary>
        /// <returns></returns>
        public ActionResult Preferences()
        {
            XmlDocument xml = new XmlDocument();
            string RecentVisitCount = "";
            string siteTitle = "";
            bool FooterFixed = false;
            xml.Load(Server.MapPath("~/Settings/webSettings.xml"));
            if (xml != null)
            {
                RecentVisitCount = xml.GetElementsByTagName("RecentVisitCount")[0].InnerText;
                FooterFixed = Convert.ToBoolean(xml.GetElementsByTagName("FooterFixed")[0].InnerText);
                siteTitle = xml.GetElementsByTagName("TitleName")[0].InnerText;
            }

            PreferencesViewModel viewModel = new PreferencesViewModel()
            {
                Title = (ViewBag.Title == null ? siteTitle : ViewBag.Title)
                ,
                RecentVisit = RecentVisitCount
                ,
                isFooterFixed = FooterFixed
            };

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult TitleSave(PreferencesViewModel model)
        {

            XmlDocument xml = new XmlDocument();
            xml.Load(Server.MapPath("~/Settings/webSettings.xml"));
            if (xml != null)
            {
                xml.GetElementsByTagName("TitleName")[0].InnerText = model.Title;
                xml.Save(Server.MapPath("~/Settings/webSettings.xml"));
                ViewBag.Title = xml.GetElementsByTagName("TitleName")[0].InnerText;
            }

            return RedirectToAction("Preferences", "System");
        }

        [HttpGet]
        public ActionResult RecentVisitSave(PreferencesViewModel model)
        {
            double num;
            if (double.TryParse(model.RecentVisit, out num))
            {
            }
            else
            {
                //숫자가 아닌경우.
                return RedirectToAction("Preferences", "System");
            }
            XmlDocument xml = new XmlDocument();
            xml.Load(Server.MapPath("~/Settings/webSettings.xml"));
            if (xml != null)
            {
                xml.GetElementsByTagName("RecentVisitCount")[0].InnerText = model.RecentVisit;
                xml.Save(Server.MapPath("~/Settings/webSettings.xml"));
            }

            return RedirectToAction("Preferences", "System");
        }

        [HttpGet]
        public ActionResult FooterFixedSave(PreferencesViewModel model)
        {
            try
            {
                string result;
                result = model.isFooterFixed.ToString();
                XmlDocument xml = new XmlDocument();
                xml.Load(Server.MapPath("~/Settings/webSettings.xml"));
                if (xml != null)
                {
                    xml.GetElementsByTagName("FooterFixed")[0].InnerText = result;
                    xml.Save(Server.MapPath("~/Settings/webSettings.xml"));
                }

                return RedirectToAction("Preferences", "System");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Preferences", "System");
            }
        }

        [HttpPost]
        public string BackgoundSave(string fileData, string file)
        {
            try
            {
                if (fileData != null && file != null)
                {
                    string fileCode = fileData.Split(',')[1];
                    string fileName = file;
                    fileCode = fileCode.Replace('_', '+');
                    string path = Server.MapPath("~/Images/Background/");

                    byte[] myData = Decoder(fileCode);

                    //byte[] myData = Decompress(fileCode);

                    FileStream fileStream = new FileStream(path + @"\\" + file, FileMode.OpenOrCreate, FileAccess.Write);
                    fileStream.Write(myData, 0, myData.GetUpperBound(0) + 1);
                    fileStream.Close();
                    fileStream.Dispose();
                }
                else
                {

                }

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        public static byte[] Decompress(string compressedText)
        {
            byte[] gzBuffer = Convert.FromBase64String(compressedText);
            using (MemoryStream ms = new MemoryStream())
            {
                int msgLength = BitConverter.ToInt32(gzBuffer, 0);
                ms.Write(gzBuffer, 4, gzBuffer.Length - 4);

                byte[] buffer = new byte[msgLength];

                ms.Position = 0;
                using (GZipStream zip = new GZipStream(ms, CompressionMode.Decompress))
                {
                    zip.Read(buffer, 0, buffer.Length);
                }

                ms.Close();
                ms.Flush();
                ms.Dispose();

                return buffer;
            }
        }
        public static byte[] Decoder(string text)
        {
            return Convert.FromBase64String(text);
        }
        #endregion

        #region 메뉴 권한 설정
        public PartialViewResult AjaxInquiryContextMenuPermissions()
        {
            return PartialView("_Permissions");
        }
        public ActionResult Permissions()
        {
            var _action = this.Url.RequestContext.RouteData.Values["action"].ToString();
            var _control = this.Url.RequestContext.RouteData.Values["controller"].ToString();
            string _activePage = "";
            if (Session["Menu"] != null)
            {
                _activePage = DomainManager.GetEntityToList<COW_MenuListByJsonInquiry_Result>("COW_MenuListByJsonInquiry", null).Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().ParentMenuCode.ToString();
            }
            else
            {
                _activePage = DomainManager.GetEntityToList<COW_MenuListByJsonInquiry_Result>("COW_MenuListByJsonInquiry", null).Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().ParentMenuCode.ToString();
            }

            MenuHistory getMenuLocation = new MenuHistory();
            List<string> _menuPage = new List<string>(getMenuLocation.GetMenu(_action, _control, _activePage, DomainManager.GetEntityToList<COW_MenuListByJsonInquiry_Result>("COW_MenuListByJsonInquiry", null).ToList()));

            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_EmployeeId", HttpContext.User.Identity.Name);
            parameters01.Add("@p_MenuCode", MethodBase.GetCurrentMethod().Name);

            PermissionViewModel viewModel = new PermissionViewModel
            {
                MenuLocation = _menuPage
                ,
                ActivePage = _activePage
                ,
                resourceManager = _resourceManager
                ,
                Auth = DomainManager.GetEntityToList<COW_NavMenuAuthorizeInquiry_Result>("COW_NavMenuAuthorizeInquiry", parameters01).ToList().First()
                ,
                UserId = HttpContext.User.Identity.Name
            };

            return View(viewModel);
        }

        private static List<COW_PermissionMenuInquiry_Result> COW_PermissionMenuInquiry = new List<COW_PermissionMenuInquiry_Result>();
        private static List<COW_PermissionMenuInquiry_Result> COW_PermissionMenuInquiryTarget = new List<COW_PermissionMenuInquiry_Result>();
        private static void GetOrderByList(string myKey, ref List<COW_PermissionMenuInquiry_Result> lst)
        {
            List<COW_PermissionMenuInquiry_Result> listado2 = COW_PermissionMenuInquiry.Where(x => x.ParentMenuCode == myKey).ToList();
            if (listado2.Count > 0)
            {
                foreach (COW_PermissionMenuInquiry_Result item in listado2)
                {
                    lst.Add(item);
                    GetOrderByList(item.MenuCode, ref lst);
                }
            }
        }

        [HttpGet]
        public JsonResult GetCOW_PermissionMenuInquiry(string userId)
        {
            try
            {
                Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
                parameters01.Add("@p_UserId", userId == HttpContext.User.Identity.Name ? userId : HttpContext.User.Identity.Name);

                COW_PermissionMenuInquiry = DomainManager.GetEntityToList<COW_PermissionMenuInquiry_Result>("COW_PermissionMenuInquiry", parameters01).ToList();
                COW_PermissionMenuInquiryTarget = new List<COW_PermissionMenuInquiry_Result>();

                List<COW_PermissionMenuInquiry_Result> itemRoots = COW_PermissionMenuInquiry.Where(x => x.ParentMenuCode == "Root").ToList();

                foreach (var itemRoot in itemRoots)
                {
                    COW_PermissionMenuInquiryTarget.Add(itemRoot);
                    COW_PermissionMenuInquiry.Remove(itemRoot);
                    GetOrderByList(itemRoot.MenuCode, ref COW_PermissionMenuInquiryTarget);
                }

                return Json(COW_PermissionMenuInquiryTarget, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Message = ex.Message.ToString() });
            }
        }

        [HttpGet]
        public ActionResult GetCOW_PermissionRoleInquiry(string menuCode, DataSourceLoadOptions loadOptions)
        {
            try
            {
                Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
                parameters01.Add("@p_MenuCode", menuCode);

                //return Json(DomainManager.GetEntityToList<COW_PermissionRoleInquiry_Result>("COW_PermissionRoleInquiry", parameters01).ToList()
                //    , JsonRequestBehavior.AllowGet);
                var result = DataSourceLoader.Load(DomainManager.GetEntityToList<COW_PermissionRoleInquiry_Result>("COW_PermissionRoleInquiry", parameters01).ToList(), loadOptions);
                var resultJson = JsonConvert.SerializeObject(result);
                return Content(resultJson, "application/json");
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message.ToString() });
            }
        }

        [HttpGet]
        public ActionResult GetCOW_PermissionEmployeeInquiry(string menuCode, DataSourceLoadOptions loadOptions)
        {
            try
            {
                Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
                parameters01.Add("@p_MenuCode", menuCode);

                //return Json(DomainManager.GetEntityToList<COW_PermissionEmployeeInquiry_Result>("COW_PermissionEmployeeInquiry", parameters01)
                //    , JsonRequestBehavior.AllowGet);
                var result = DataSourceLoader.Load(DomainManager.GetEntityToList<COW_PermissionEmployeeInquiry_Result>("COW_PermissionEmployeeInquiry", parameters01), loadOptions);
                var resultJson = JsonConvert.SerializeObject(result);
                return Content(resultJson, "application/json");
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message.ToString() });
            }
        }


        public ActionResult SetCOW_PermissionRoleSave(COW_PermissionRoleInquiry_Result obj, string id)
        {
            string msg;

            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_RoleId", obj.RoleId);
            parameters01.Add("@p_MenuCode", obj.MenuCode);
            parameters01.Add("@p_AuthCreate", Convert.ToBoolean(Convert.ToInt16(obj.AuthCreate)));
            parameters01.Add("@p_AuthRead", Convert.ToBoolean(Convert.ToInt16(obj.AuthRead)));
            parameters01.Add("@p_AuthUpdate", Convert.ToBoolean(Convert.ToInt16(obj.AuthUpdate)));
            parameters01.Add("@p_AuthDelete", Convert.ToBoolean(Convert.ToInt16(obj.AuthDelete)));
            parameters01.Add("@p_UserName", HttpContext.User.Identity.Name);
            parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

            try
            {
                if (ModelState.IsValid)
                {
                    var returnParameter = DomainManager.GetEntityResult("COW_PermissionRoleSave", parameters01);
                    if (parameters01.Get<string>("@p_OutMessage").ToString() == "OK")
                        msg = "Saved Successfully";
                    else
                        msg = parameters01.Get<string>("@p_OutMessage").ToString();
                }
                else
                {
                    msg = "Validation data not successfull";
                }
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
        }

        public ActionResult SetCOW_PermissionRoleDelete(COW_PermissionRoleInquiry_Result obj, string id)
        {
            string msg;

            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_RoleId", obj.RoleId);
            parameters01.Add("@p_MenuCode", obj.MenuCode);
            parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

            try
            {
                if (ModelState.IsValid)
                {
                    var returnParameter = DomainManager.GetEntityResult("COW_PermissionRoleDelete", parameters01);

                    if (parameters01.Get<string>("@p_OutMessage").ToString() == "OK")
                        msg = "Deleted Successfully";
                    else
                        msg = parameters01.Get<string>("@p_OutMessage").ToString();
                }
                else
                {
                    msg = "Validation data not successfull";
                }
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
        }

        public ActionResult SetCOW_PermissionEmployeeSave(COW_PermissionEmployeeInquiry_Result obj, string id)
        {
            string msg;

            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_EmployeeId", obj.EmployeeId);
            parameters01.Add("@p_MenuCode", obj.MenuCode);
            parameters01.Add("@p_AuthCreate", Convert.ToBoolean(Convert.ToInt16(obj.AuthCreate)));
            parameters01.Add("@p_AuthRead", Convert.ToBoolean(Convert.ToInt16(obj.AuthRead)));
            parameters01.Add("@p_AuthUpdate", Convert.ToBoolean(Convert.ToInt16(obj.AuthUpdate)));
            parameters01.Add("@p_AuthDelete", Convert.ToBoolean(Convert.ToInt16(obj.AuthDelete)));
            parameters01.Add("@p_UserName", HttpContext.User.Identity.Name);
            parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

            try
            {
                if (ModelState.IsValid)
                {
                    var returnParameter = DomainManager.GetEntityResult("COW_PermissionEmployeeSave", parameters01);

                    if (parameters01.Get<string>("@p_OutMessage").ToString() == "OK")
                        msg = "Saved Successfully";
                    else
                        msg = parameters01.Get<string>("@p_OutMessage").ToString();
                }
                else
                {
                    msg = "Validation data not successfull";
                }
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
        }

        public ActionResult SetCOW_PermissionEmployeeDelete(COW_PermissionEmployeeInquiry_Result obj, string id)
        {
            string msg;

            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_EmployeeId", obj.EmployeeId);
            parameters01.Add("@p_MenuCode", obj.MenuCode);
            parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

            try
            {
                if (ModelState.IsValid)
                {
                    var returnParameter = DomainManager.GetEntityResult("COW_PermissionEmployeeDelete", parameters01);

                    if (parameters01.Get<string>("@p_OutMessage").ToString() == "OK")
                        msg = "Deleted Successfully";
                    else
                        msg = parameters01.Get<string>("@p_OutMessage").ToString();
                }
                else
                {
                    msg = "Validation data not successfull";
                }
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
        }

        public ActionResult SetCOW_PermissionRoleCreateSave(string menuCode, string ids)
        {
            string msg;

            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_RoleIds", ids);
            parameters01.Add("@p_MenuCode", menuCode);
            parameters01.Add("@p_UserName", HttpContext.User.Identity.Name);
            parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

            try
            {
                if (ModelState.IsValid)
                {
                    var returnParameter = DomainManager.GetEntityResult("COW_PermissionRoleCreateSave", parameters01);

                    if (parameters01.Get<string>("@p_OutMessage").ToString() == "OK")
                        msg = "Saved Successfully";
                    else
                        msg = parameters01.Get<string>("@p_OutMessage").ToString();
                }
                else
                {
                    msg = "Validation data not successfull";
                }
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
        }

        public ActionResult SetCOW_PermissionRoleReadSave(string menuCode, string ids)
        {
            string msg;

            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_RoleIds", ids);
            parameters01.Add("@p_MenuCode", menuCode);
            parameters01.Add("@p_UserName", HttpContext.User.Identity.Name);
            parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

            try
            {
                if (ModelState.IsValid)
                {
                    var returnParameter = DomainManager.GetEntityResult("COW_PermissionRoleReadSave", parameters01);

                    if (parameters01.Get<string>("@p_OutMessage").ToString() == "OK")
                        msg = "Saved Successfully";
                    else
                        msg = parameters01.Get<string>("@p_OutMessage").ToString();
                }
                else
                {
                    msg = "Validation data not successfull";
                }
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
        }

        public ActionResult SetCOW_PermissionRoleUpdateSave(string menuCode, string ids)
        {
            string msg;

            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_RoleIds", ids);
            parameters01.Add("@p_MenuCode", menuCode);
            parameters01.Add("@p_UserName", HttpContext.User.Identity.Name);
            parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

            try
            {
                if (ModelState.IsValid)
                {
                    var returnParameter = DomainManager.GetEntityResult("COW_PermissionRoleUpdateSave", parameters01);

                    if (parameters01.Get<string>("@p_OutMessage").ToString() == "OK")
                        msg = "Saved Successfully";
                    else
                        msg = parameters01.Get<string>("@p_OutMessage").ToString();
                }
                else
                {
                    msg = "Validation data not successfull";
                }
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
        }

        public ActionResult SetCOW_PermissionRoleDeleteSave(string menuCode, string ids)
        {
            string msg;

            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_RoleIds", ids);
            parameters01.Add("@p_MenuCode", menuCode);
            parameters01.Add("@p_UserName", HttpContext.User.Identity.Name);
            parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

            try
            {
                if (ModelState.IsValid)
                {
                    var returnParameter = DomainManager.GetEntityResult("COW_PermissionRoleDeleteSave", parameters01);

                    if (parameters01.Get<string>("@p_OutMessage").ToString() == "OK")
                        msg = "Saved Successfully";
                    else
                        msg = parameters01.Get<string>("@p_OutMessage").ToString();
                }
                else
                {
                    msg = "Validation data not successfull";
                }
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
        }


        public ActionResult SetCOW_PermissionRoleNoAuthSave(string menuCode, string ids)
        {
            string msg;

            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_RoleIds", ids);
            parameters01.Add("@p_MenuCode", menuCode);
            parameters01.Add("@p_UserName", HttpContext.User.Identity.Name);
            parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

            try
            {
                if (ModelState.IsValid)
                {
                    var returnParameter = DomainManager.GetEntityResult("COW_PermissionRoleNoAuthSave", parameters01);

                    if (parameters01.Get<string>("@p_OutMessage").ToString() == "OK")
                        msg = "Saved Successfully";
                    else
                        msg = parameters01.Get<string>("@p_OutMessage").ToString();
                }
                else
                {
                    msg = "Validation data not successfull";
                }
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
        }

        public string SetCOW_PermissionRoleAddSave(string menuCode, string ids, string authCreate, string authRead, string authUpdate, string authDelete)
        {
            string msg;

            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_RoleIds", ids);
            parameters01.Add("@p_MenuCode", menuCode);
            parameters01.Add("@p_AuthCreate", Convert.ToBoolean(Convert.ToInt16(authCreate)));
            parameters01.Add("@p_AuthRead", Convert.ToBoolean(Convert.ToInt16(authRead)));
            parameters01.Add("@p_AuthUpdate", Convert.ToBoolean(Convert.ToInt16(authUpdate)));
            parameters01.Add("@p_AuthDelete", Convert.ToBoolean(Convert.ToInt16(authDelete)));
            parameters01.Add("@p_UserName", HttpContext.User.Identity.Name);
            parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

            try
            {
                if (ModelState.IsValid)
                {
                    var returnParameter = DomainManager.GetEntityResult("COW_PermissionRoleAddSave", parameters01);

                    if (parameters01.Get<string>("@p_OutMessage").ToString() == "OK")
                        msg = "Saved Successfully";
                    else
                        msg = parameters01.Get<string>("@p_OutMessage").ToString();
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }

        public ActionResult SetCOW_PermissionRoleRemoveSave(string menuCode, string ids)
        {
            string msg;

            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_RoleIds", ids);
            parameters01.Add("@p_MenuCode", menuCode);
            parameters01.Add("@p_UserName", HttpContext.User.Identity.Name);
            parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

            try
            {
                if (ModelState.IsValid)
                {
                    var returnParameter = DomainManager.GetEntityResult("COW_PermissionRoleRemoveSave", parameters01);

                    if (parameters01.Get<string>("@p_OutMessage").ToString() == "OK")
                        msg = "Saved Successfully";
                    else
                        msg = parameters01.Get<string>("@p_OutMessage").ToString();
                }
                else
                {
                    msg = "Validation data not successfull";
                }
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
        }

        public ActionResult SetCOW_PermissionEmployeeCreateSave(string menuCode, string ids)
        {
            string msg;

            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_EmployeeIds", ids);
            parameters01.Add("@p_MenuCode", menuCode);
            parameters01.Add("@p_UserName", HttpContext.User.Identity.Name);
            parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

            try
            {
                if (ModelState.IsValid)
                {
                    var returnParameter = DomainManager.GetEntityResult("COW_PermissionEmployeeCreateSave", parameters01);

                    if (parameters01.Get<string>("@p_OutMessage").ToString() == "OK")
                        msg = "Saved Successfully";
                    else
                        msg = parameters01.Get<string>("@p_OutMessage").ToString();
                }
                else
                {
                    msg = "Validation data not successfull";
                }
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
        }

        public ActionResult SetCOW_PermissionEmployeeReadSave(string menuCode, string ids)
        {
            string msg;

            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_EmployeeIds", ids);
            parameters01.Add("@p_MenuCode", menuCode);
            parameters01.Add("@p_UserName", HttpContext.User.Identity.Name);
            parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

            try
            {
                if (ModelState.IsValid)
                {
                    var returnParameter = DomainManager.GetEntityResult("COW_PermissionEmployeeReadSave", parameters01);

                    if (parameters01.Get<string>("@p_OutMessage").ToString() == "OK")
                        msg = "Saved Successfully";
                    else
                        msg = parameters01.Get<string>("@p_OutMessage").ToString();
                }
                else
                {
                    msg = "Validation data not successfull";
                }
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
        }

        public ActionResult SetCOW_PermissionEmployeeUpdateSave(string menuCode, string ids)
        {
            string msg;

            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_EmployeeIds", ids);
            parameters01.Add("@p_MenuCode", menuCode);
            parameters01.Add("@p_UserName", HttpContext.User.Identity.Name);
            parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

            try
            {
                if (ModelState.IsValid)
                {
                    var returnParameter = DomainManager.GetEntityResult("COW_PermissionEmployeeUpdateSave", parameters01);

                    if (parameters01.Get<string>("@p_OutMessage").ToString() == "OK")
                        msg = "Saved Successfully";
                    else
                        msg = parameters01.Get<string>("@p_OutMessage").ToString();
                }
                else
                {
                    msg = "Validation data not successfull";
                }
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
        }

        public ActionResult SetCOW_PermissionEmployeeDeleteSave(string menuCode, string ids)
        {
            string msg;

            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_EmployeeIds", ids);
            parameters01.Add("@p_MenuCode", menuCode);
            parameters01.Add("@p_UserName", HttpContext.User.Identity.Name);
            parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

            try
            {
                if (ModelState.IsValid)
                {
                    var returnParameter = DomainManager.GetEntityResult("COW_PermissionEmployeeDeleteSave", parameters01);

                    if (parameters01.Get<string>("@p_OutMessage").ToString() == "OK")
                        msg = "Saved Successfully";
                    else
                        msg = parameters01.Get<string>("@p_OutMessage").ToString();
                }
                else
                {
                    msg = "Validation data not successfull";
                }
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
        }


        public ActionResult SetCOW_PermissionEmployeeNoAuthSave(string menuCode, string ids)
        {
            string msg;

            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_EmployeeIds", ids);
            parameters01.Add("@p_MenuCode", menuCode);
            parameters01.Add("@p_UserName", HttpContext.User.Identity.Name);
            parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

            try
            {
                if (ModelState.IsValid)
                {
                    var returnParameter = DomainManager.GetEntityResult("COW_PermissionEmployeeNoAuthSave", parameters01);

                    if (parameters01.Get<string>("@p_OutMessage").ToString() == "OK")
                        msg = "Saved Successfully";
                    else
                        msg = parameters01.Get<string>("@p_OutMessage").ToString();
                }
                else
                {
                    msg = "Validation data not successfull";
                }
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
        }

        public string SetCOW_PermissionEmployeeAddSave(string menuCode, string ids, string authCreate, string authRead, string authUpdate, string authDelete)
        {
            string msg;

            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_EmployeeIds", ids);
            parameters01.Add("@p_MenuCode", menuCode);
            parameters01.Add("@p_AuthCreate", Convert.ToBoolean(Convert.ToInt16(authCreate)));
            parameters01.Add("@p_AuthRead", Convert.ToBoolean(Convert.ToInt16(authRead)));
            parameters01.Add("@p_AuthUpdate", Convert.ToBoolean(Convert.ToInt16(authUpdate)));
            parameters01.Add("@p_AuthDelete", Convert.ToBoolean(Convert.ToInt16(authDelete)));
            parameters01.Add("@p_UserName", HttpContext.User.Identity.Name);
            parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

            try
            {
                if (ModelState.IsValid)
                {
                    var returnParameter = DomainManager.GetEntityResult("COW_PermissionEmployeeAddSave", parameters01);

                    if (parameters01.Get<string>("@p_OutMessage").ToString() == "OK")
                        msg = "Saved Successfully";
                    else
                        msg = parameters01.Get<string>("@p_OutMessage").ToString();
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }

        public ActionResult SetCOW_PermissionEmployeeRemoveSave(string menuCode, string ids)
        {
            string msg;

            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_EmployeeIds", ids);
            parameters01.Add("@p_MenuCode", menuCode);
            parameters01.Add("@p_UserName", HttpContext.User.Identity.Name);
            parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

            try
            {
                if (ModelState.IsValid)
                {
                    var returnParameter = DomainManager.GetEntityResult("COW_PermissionEmployeeRemoveSave", parameters01);

                    if (parameters01.Get<string>("@p_OutMessage").ToString() == "OK")
                        msg = "Saved Successfully";
                    else
                        msg = parameters01.Get<string>("@p_OutMessage").ToString();
                }
                else
                {
                    msg = "Validation data not successfull";
                }
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
                return new HttpStatusCodeResult(HttpStatusCode.Created);
            }
        }

        public PartialViewResult Popup_PermissionRoleAdd(string menuCode, string ids)
        {
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_EmployeeId", HttpContext.User.Identity.Name);
            parameters01.Add("@p_MenuCode", menuCode);

            PermissionViewModel viewModel = new PermissionViewModel
            {
                resourceManager = _resourceManager
                ,
                Auth = DomainManager.GetEntityToList<COW_NavMenuAuthorizeInquiry_Result>("COW_NavMenuAuthorizeInquiry", parameters01).ToList().First()
                ,
                MenuCode = menuCode
                ,
                Ids = ids
            };
            return PartialView("_PopupPermissionsAddRole", viewModel);
        }

        [HttpGet]
        public JsonResult GetCOW_PermissionRoleAddInquiry(string menuCode, string ids)
        {
            try
            {
                Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
                parameters01.Add("@p_RoleIds", ids);
                parameters01.Add("@p_MenuCode", menuCode);

                return Json(DomainManager.GetEntityToList<COW_PermissionRoleAddInquiry_Result>("COW_PermissionRoleAddInquiry", parameters01)
                    , JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message.ToString() });
            }
        }


        public PartialViewResult Popup_PermissionEmployeeAdd(string menuCode, string ids)
        {
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_EmployeeId", HttpContext.User.Identity.Name);
            parameters01.Add("@p_MenuCode", MethodBase.GetCurrentMethod().Name);

            PermissionViewModel viewModel = new PermissionViewModel
            {
                resourceManager = _resourceManager
                ,
                Auth = DomainManager.GetEntityToList<COW_NavMenuAuthorizeInquiry_Result>("COW_NavMenuAuthorizeInquiry", parameters01).ToList().First()
                ,
                MenuCode = menuCode
                ,
                Ids = ids
            };
            return PartialView("_PopupPermissionsAddEmployee", viewModel);
        }

        [HttpGet]
        public JsonResult GetCOW_PermissionEmployeeAddInquiry(string menuCode, string ids)
        {
            try
            {
                Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
                parameters01.Add("@p_EmployeeIds", ids);
                parameters01.Add("@p_MenuCode", menuCode);


                return Json(DomainManager.GetEntityToList<COW_PermissionEmployeeAddInquiry_Result>("COW_PermissionEmployeeAddInquiry", parameters01)
                    , JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message.ToString() });
            }
        }
        #endregion


        //스킨 저장(ID별로)
        [HttpGet]
        public ActionResult SkinSave(string skinName)
        {
            try
            {
                if (HttpContext.User.Identity.Name != null)
                {
                    string userName = HttpContext.User.Identity.Name;

                    AddCookie(userName + "_Skin", skinName);

                    ViewBag.Skin = skinName;

                    string saveConfig = "";
                    saveConfig += skinName + ";";
                    saveConfig += GetCookieValue(userName + "_Test1") + ";";
                    saveConfig += GetCookieValue(userName + "_Test2") + ";";
                    saveConfig += GetCookieValue(userName + "_IsTrue") + ";";
                    saveConfig += GetCookieValue(userName + "_IsFalse");

                    Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
                    parameters01.Add("@p_UserId", userName);
                    parameters01.Add("@p_Config", saveConfig);
                    parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

                    var returnParameter = DomainManager.GetEntityResult("COW_ConfigSave", parameters01);

                    if (parameters01.Get<string>("@p_OutMessage").ToString() == "OK")
                    {
                        return RedirectToAction("", "");
                    }
                    else
                    {
                        throw new ArgumentException(parameters01.Get<string>("@p_OutMessage").ToString());
                    }
                }

                return RedirectToAction("", "");
            }
            catch (Exception ex)
            {
                string aa = ex.Message.ToString();
                return RedirectToAction("Login", "Account");
            }
        }
    }
}