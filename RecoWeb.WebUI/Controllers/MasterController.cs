using RecoWeb.Domain.Abstract;
using RecoWeb.Domain.Concrete;
using RecoWeb.Module;
using RecoWeb.Module.Controllers;
using RecoWeb.Module.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using RecoWeb.Module.Infrastructure.Concrete;
using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Data;
using Newtonsoft.Json;
using System.Data;
using RecoWeb.WebUI.Models.POCO;
using RecoWeb.Module.Models.POCO;
using RecoWeb.WebUI.Models;

namespace RecoWeb.WebUI.Controllers
{
    [Authorize]
    public class MasterController : BaseController
    {
        //2018 07 20 by roy (1) : BaseController에서 하단으로 내려옴
        public ResourceWrapper _resourceManager = new ResourceWrapper();

        private DomainConnectionManager DomainManager;
        public MasterController(DomainConnectionManager Domains)
        {
            this.DomainManager = Domains;
        }

        #region 초중종물 검사항목관리

        public PartialViewResult AjaxInquiryContextMenu2()
        {
            return PartialView("_BCI3Context");
        }

        [OutputCache(Duration = 0)]
        public PartialViewResult AjaxInquiryContextMenu4(string plant, string workshop, string part)
        {
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_PlantId", plant);
            parameters01.Add("@p_WorkShopId", workshop);
            parameters01.Add("@p_PartId", part);

            TQW_TCIViewModel viewModel = new TQW_TCIViewModel
            {
                TQW_CheckSheetImageInquiry = DomainManager.GetEntityToList<TQW_CheckSheetImageInquiry_Result>("TQW_CheckSheetImageInquiry", parameters01).ToList()
            };

            return PartialView("_BCI3ImageUpload", viewModel);
        }

        public PartialViewResult AjaxChecksheetItemUpload()
        {
            return PartialView("_BCI3ExcelUpload");
        }

        public FileResult AjaxChecksheetItemDownload()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath("~/") + "Document/Checksheet/Mes_CheckSheetUpload.xlsx");
            string fileName = "Mes_CheckSheetUpload.xlsx";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        #region 테스트중
        public ActionResult AAA(string values)
        {
            string va = values;

            //values는 모든 값들이 JSON string 형태로 넘어옴.
            JsonConvert.DeserializeObject(values);

            //+ DB처리 로직이 들어가야함.

            //정상 처리 후 new HttpStatusCodeResult(HttpStatusCode.OK)를 리턴해줌 → Load함수로 이동(재조회).
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
        public ActionResult AAA(int key, string values)
        {

            // key는 .cshtml에서 설정한 칼럼의 값을 가져옴.
            // values는 JSON string 형태로 넘어옴.
            int keyValue = key;
            string va = values;
            JsonConvert.DeserializeObject(values);

            //+ DB처리 로직이 들어가야함.

            //정상 처리 후 new HttpStatusCodeResult(HttpStatusCode.Created)를 리턴해줌 → Load함수로 이동(재조회).
            return new HttpStatusCodeResult(HttpStatusCode.Created);
        }
        public ActionResult AAA(int key)
        {
            int keyc = key;
            return new HttpStatusCodeResult(HttpStatusCode.Created);
        }
        #endregion

        public ActionResult BCI3()
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
            var a = DomainManager.GetEntityToList<COW_MenuListByJsonInquiry_Result>("COW_MenuListByJsonInquiry", null).ToList();
            List<string> _menuPage = new List<string>(getMenuLocation.GetMenu(_action, _control, _activePage, a));



            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_UserId", HttpContext.User.Identity.Name);
            var plants = DomainManager.GetEntityToList<COW_FilterPlantInquiry_Result>("COW_FilterPlantInquiry", parameters01).ToList();

            Dapper.DynamicParameters parameters02 = new Dapper.DynamicParameters();
            parameters02.Add("@p_PlantId", plants.FirstOrDefault().PlantId);

            var factory = DomainManager.GetEntityToList<COW_FilterFactoriesInquiry_Result>("COW_FilterFactoriesInquiry", parameters02).ToList();
            var workType = DomainManager.GetEntityToList<COW_FilterWorkshopTypesInquiry_Result>("COW_FilterWorkshopTypesInquiry", parameters02).ToList();

            Dapper.DynamicParameters parameters03 = new Dapper.DynamicParameters();
            parameters03.Add("@p_EmployeeId", HttpContext.User.Identity.Name);
            parameters03.Add("@p_MenuCode", MethodBase.GetCurrentMethod().Name);

            Dapper.DynamicParameters parameters04 = new Dapper.DynamicParameters();
            parameters04.Add("@p_PlantId", plants.FirstOrDefault().PlantId);
            parameters04.Add("@p_FactoryId", factory.FirstOrDefault().FactoryId);
            parameters04.Add("@p_WorkshopTypeId", workType.FirstOrDefault().WorkshopTypeId);

            TQW_TCIViewModel viewModel = new TQW_TCIViewModel
            {
                MenuLocation = _menuPage
                ,
                ActivePage = _activePage
                ,
                resourceManager = _resourceManager
                ,
                //라디오 버튼의 기본값.
                isUse = true
                ,
                Auth = DomainManager.GetEntityToList<COW_NavMenuAuthorizeInquiry_Result>("COW_NavMenuAuthorizeInquiry", parameters03).ToList().First() // repository.COW_NavMenuAuthorizeInquiry(HttpContext.User.Identity.Name, MethodBase.GetCurrentMethod().Name).ToList().First()
                ,
                COW_FilterPlantInquiry = plants
                ,
                COW_FilterFactoriesInquiry = factory
                ,
                COW_FilterWorkshopTypesInquiry = workType
                ,
                COW_FilterWorkshopsInquiry = DomainManager.GetEntityToList<COW_FilterWorkshopsInquiry_Result>("COW_FilterWorkshopsInquiry", parameters04).ToList()
            };

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult GetBCI3PartByLine(string plantId, string factoryId, string workshopTypeId, string workshopId, string partCode, bool isUse, string user, DataSourceLoadOptions loadOptions)
        {
            try
            {
                Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
                parameters01.Add("@p_PlantId", plantId);
                parameters01.Add("@p_FactoriesId", factoryId);
                parameters01.Add("@p_WorkshopTypeId", workshopTypeId);
                parameters01.Add("@p_WorkshopId", workshopId);
                parameters01.Add("@p_PartCode", partCode);
                parameters01.Add("@p_IsUse", Convert.ToBoolean(isUse));
                parameters01.Add("@p_User", HttpContext.User.Identity.Name);

                var result = DataSourceLoader.Load(DomainManager.GetEntityToList<TQW_CheckSheetItemManageInquiry_Result>("TQW_CheckSheetItemManageInquiry", parameters01), loadOptions);
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
        public ActionResult GetBCI3CheckList(string plantId, string factoryId, string workshopTypeId, string workshopId, string partCode, string isUse, string user, string workshopParam, string partidParam, DataSourceLoadOptions loadOptions)
        {
            try
            {
                Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
                parameters01.Add("@p_PlantId", plantId);
                parameters01.Add("@p_FactoriesId", factoryId);
                parameters01.Add("@p_WorkshopTypeId", workshopTypeId);
                parameters01.Add("@p_WorkshopId", workshopId);
                parameters01.Add("@p_PartCode", partCode);
                parameters01.Add("@p_IsUse", Convert.ToBoolean(isUse));
                parameters01.Add("@p_User", HttpContext.User.Identity.Name);
                parameters01.Add("@p_WorkShopIdParam", workshopParam);
                parameters01.Add("@p_PartIdParam", partidParam);

                var result = DataSourceLoader.Load(DomainManager.GetEntityToList<TQW_CheckSheetItemManageDetailInquiry_Result>("TQW_CheckSheetItemManageDetailInquiry", parameters01), loadOptions);
                var resultJson = JsonConvert.SerializeObject(result);

                return Content(resultJson, "application/json");
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message.ToString() });
            }
        }

        [HttpPost]
        public string ImageSave(string plant, string workshop, string part, string imgName)
        {
            try
            {
                Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
                parameters01.Add("@p_PlantId", plant);
                parameters01.Add("@p_WorkShopId", workshop);
                parameters01.Add("@p_PartId", part);
                parameters01.Add("@p_ImageName", imgName);
                parameters01.Add("@p_UserId", HttpContext.User.Identity.Name);
                parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                string msg;
                var returnParameter = DomainManager.GetEntityResult("TQW_CheckSheetImageSave", parameters01);

                if (parameters01.Get<string>("@p_OutMessage").ToString() == "OK")
                    msg = "성공";
                else
                    msg = parameters01.Get<string>("@p_OutMessage").ToString();
                return msg;
            }
            catch (Exception ex)
            {
                string aa = ex.Message.ToString();
                return aa;
            }
        }

        [HttpPost]
        public string ExcelUpload(string plantId, string workshopId, string parameters)
        {
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();

            parameters01.Add("@p_PlantId", plantId);
            parameters01.Add("@p_WorkshopId", workshopId);
            parameters01.Add("@p_Data", parameters);
            parameters01.Add("@p_UpdateBy", HttpContext.User.Identity.Name);
            parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

            try
            {
                if (ModelState.IsValid)
                {
                    var returnParameter = DomainManager.GetEntityResult("TQW_CheckSheetUploadSave", parameters01);

                    if (parameters01.Get<string>("@p_OutMessage").ToString() == "OK")
                        return "Success";
                    else
                        return parameters01.Get<string>("@p_OutMessage").ToString();
                }
                else
                {
                    throw new Exception("Error");
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        #endregion

    }
}