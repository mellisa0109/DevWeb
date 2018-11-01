using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using RecoWeb.Module;
using RecoWeb.Module.Controllers;
using RecoWeb.Module.Infrastructure.Concrete;
using RecoWeb.Module.Models.POCO;
using RecoWeb.WebUI.Models;
using RecoWeb.WebUI.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RecoWeb.WebUI.Controllers
{
    public class DeliveryController : BaseController
    {
        //2018 07 20 by roy (1) : BaseController에서 하단으로 내려옴
        public ResourceWrapper _resourceManager = new ResourceWrapper();

        private DomainConnectionManager DomainManager;
        public DeliveryController(DomainConnectionManager Domains)
        {
            this.DomainManager = Domains;
        }

        // GET: Delivery
        public ActionResult Index()
        {
            return View();
        }


        #region 서열정보 집계(DYP5)
        public PartialViewResult AjaxInquiryContextMenu()
        {
            return PartialView("_DYP5Context");
        }
        public ActionResult DYP5()
        {
            var _action = this.Url.RequestContext.RouteData.Values["action"].ToString();
            var _control = this.Url.RequestContext.RouteData.Values["controller"].ToString();
            string _activePage = "";
            if (Session["Menu"] != null)
            {
                _activePage = DomainManager.GetEntityToList<COW_MenuListByJsonInquiry_Result>("COW_MenuListByJsonInquiry", null).Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().ParentMenuCode.ToString();

                //_activePage = repository.COW_MenuListByJsonInquiry().ToList().Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().ParentMenuCode.ToString();
            }
            else
            {
                _activePage = DomainManager.GetEntityToList<COW_MenuListByJsonInquiry_Result>("COW_MenuListByJsonInquiry", null).Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().ParentMenuCode.ToString();

                //_activePage = repository.COW_MenuListByJsonInquiry().ToList().Where(s => s.ActionMethod == _action && s.Controller == _control).FirstOrDefault().ParentMenuCode.ToString();
            }

            MenuHistory getMenuLocation = new MenuHistory();
            var a = DomainManager.GetEntityToList<COW_MenuListByJsonInquiry_Result>("COW_MenuListByJsonInquiry", null).ToList();
            List<string> _menuPage = new List<string>(getMenuLocation.GetMenu(_action, _control, _activePage, a));


            //repository.PRW_PlantInquiry().FirstOrDefault().PlantId.ToString()

            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_PlantId", DomainManager.GetEntityToList<PRW_PlantInquiry_Result>("PRW_PlantInquiry", null).FirstOrDefault().PlantId.ToString());

            SMW_DYP5ViewModel viewModel = new SMW_DYP5ViewModel
            {
                MenuLocation = _menuPage
                ,
                ActivePage = _activePage
                ,
                resourceManager = _resourceManager
                ,
                PRW_PlantInquiry = DomainManager.GetEntityToList<PRW_PlantInquiry_Result>("PRW_PlantInquiry", null).Where(w => w.IsUse == "Y") // repository.PRW_PlantInquiry().Where(w => w.IsUse == "Y")
                ,
                //차종 불러오기.
                SMW_CarTypesInquiry = DomainManager.GetEntityToList<SMW_CarTypesInquiry_Result>("SMW_CarTypesInquiry", parameters01).ToList()  // repository.SMW_CarTypesInquiry(repository.PRW_PlantInquiry().FirstOrDefault().PlantId.ToString()).ToList()
                ,
                //선택된 plantId
                plantId = DomainManager.GetEntityToList<PRW_PlantInquiry_Result>("PRW_PlantInquiry", null).FirstOrDefault().PlantId.ToString() // repository.PRW_PlantInquiry().FirstOrDefault().PlantId.ToString()
                ,
                startDate = DateTime.Today
                ,
                endDate = DateTime.Today
                ,
                //라디오 버튼의 기본값.
                printType = "2"
            };

            return View(viewModel);
        }

        public JsonResult GetCarType(string PlantId)
        {
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_PlantId", PlantId);

            var products = DomainManager.GetEntityToList<SMW_CarTypesInquiry_Result>("SMW_CarTypesInquiry", parameters01).ToList(); // repository.SMW_CarTypesInquiry(PlantId).ToList();
            return Json(products, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDYP5Result(string plantId, string startDate, string endDate, string carType, string printFlag, DataSourceLoadOptions loadOptions)
        {
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_PlantId", plantId);
            parameters01.Add("@p_StartDate", startDate);
            parameters01.Add("@p_EndDate", endDate);
            parameters01.Add("@p_CarType", carType);
            parameters01.Add("@p_PrintFlag", printFlag);

            var result = DataSourceLoader.Load(DomainManager.GetEntityToList<SMW_RankHistorySummaryInquiry_Result>("SMW_RankHistorySummaryInquiry", parameters01), loadOptions);
            var resultJson = JsonConvert.SerializeObject(result);

            return Content(resultJson, "application/json");
        }

        public ActionResult GetDYP5ResultByPart(string plantId, string startDate, string endDate, string carType, string printFlag, string parameter, DataSourceLoadOptions loadOptions)
        {
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_PlantId", plantId);
            parameters01.Add("@p_StartDate", startDate);
            parameters01.Add("@p_EndDate", endDate);
            parameters01.Add("@p_CarType", carType);
            parameters01.Add("@p_PrintFlag", printFlag);
            parameters01.Add("@p_Parameter", parameter);

            var result = DataSourceLoader.Load(DomainManager.GetEntityToList<SMW_RankHistorySummaryDPartInquiry_Result>("SMW_RankHistorySummaryDPartInquiry", parameters01), loadOptions);
            var resultJson = JsonConvert.SerializeObject(result);
            return Content(resultJson, "application/json");
        }

        [HttpGet]
        public ActionResult GetDYP5Detail(string plantId, string startDate, string endDate, string carType, string printFlag, string parameter, DataSourceLoadOptions loadOptions)
        {
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_PlantId", plantId);
            parameters01.Add("@p_StartDate", startDate);
            parameters01.Add("@p_EndDate", endDate);
            parameters01.Add("@p_CarType", carType);
            parameters01.Add("@p_PrintFlag", printFlag);
            parameters01.Add("@p_Parameter", parameter);

            var result = DataSourceLoader.Load(DomainManager.GetEntityToList<SMW_RankHistorySummaryDRawInquiry_Result>("SMW_RankHistorySummaryDRawInquiry", parameters01), loadOptions);
            var resultJson = JsonConvert.SerializeObject(result);
            return Content(resultJson, "application/json");
        }
        #endregion


    }
}