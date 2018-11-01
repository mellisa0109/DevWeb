using RecoWeb.Domain.Concrete;
using RecoWeb.Module;
using RecoWeb.Module.Controllers;
using RecoWeb.Module.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web.Mvc;
using RecoWeb.Module.Infrastructure.Concrete;
using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Data;
using Newtonsoft.Json;
using System.Data.Entity.Core.Objects;
using RecoWeb.WebUI.Models.POCO;
using RecoWeb.Module.Models.POCO;
using RecoWeb.WebUI.Models;

namespace RecoWeb.WebUI.Controllers
{
    public class ProductionController : BaseController
    {

        //2018 07 20 by roy (1) : BaseController에서 하단으로 내려옴
        public ResourceWrapper _resourceManager = new ResourceWrapper();

        private DomainConnectionManager DomainManager;
        public ProductionController(DomainConnectionManager Domains)
        {
            this.DomainManager = Domains;
        }


        // GET: Production
        public ActionResult Index()
        {
            return View();
        }

        #region 비가동Top10
        public PartialViewResult DowntimeTop100ContextMenu()
        {

            return PartialView("_PNS3Context");
        }

        public ActionResult PNS3()
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
            
            Dapper.DynamicParameters parameters00 = new Dapper.DynamicParameters();
            parameters00.Add("@p_UserId", HttpContext.User.Identity.Name);

            var plants = DomainManager.GetEntityToList<COW_FilterPlantInquiry_Result>("COW_FilterPlantInquiry", parameters00).ToList();
            
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_PlantId", plants.FirstOrDefault().PlantId);
            
            Dapper.DynamicParameters parameters02 = new Dapper.DynamicParameters();
            parameters02.Add("@p_EmployeeId", HttpContext.User.Identity.Name);
            parameters02.Add("@p_MenuCode", MethodBase.GetCurrentMethod().Name);
            
            var factory = DomainManager.GetEntityToList<COW_FilterFactoriesInquiry_Result>("COW_FilterFactoriesInquiry", parameters01).ToList();
            var workType = DomainManager.GetEntityToList<COW_FilterWorkshopTypesInquiry_Result>("COW_FilterWorkshopTypesInquiry", parameters01).ToList();

            Dapper.DynamicParameters parameters05 = new Dapper.DynamicParameters();
            parameters05.Add("@p_PlantId", plants.FirstOrDefault().PlantId);
            parameters05.Add("@p_FactoryId", factory.FirstOrDefault().FactoryId);
            parameters05.Add("@p_WorkshopTypeId", workType.FirstOrDefault().WorkshopTypeId);
            
            PRW_NotworkTop10ViewModel viewModel = new PRW_NotworkTop10ViewModel
            {
                MenuLocation = _menuPage
                ,
                ActivePage = _activePage
                ,
                resourceManager = _resourceManager
                ,
                PRW_PlantInquiry = DomainManager.GetEntityToList<PRW_PlantInquiry_Result>("PRW_PlantInquiry", null).Where(w => w.IsUse == "Y") //repository.PRW_PlantInquiry().Where(w => w.IsUse == "Y")
                ,
                //차종 불러오기.
                SMW_CarTypesInquiry = DomainManager.GetEntityToList<SMW_CarTypesInquiry_Result>("SMW_CarTypesInquiry", parameters01).ToList()  // repository.SMW_CarTypesInquiry(repository.PRW_PlantInquiry().FirstOrDefault().PlantId.ToString()).ToList()
                ,
                //선택된 plantId
                plantId = plants.FirstOrDefault().PlantId //DomainManager.GetEntityToList<>("PRW_PlantInquiry", null).Cast<PRW_PlantInquiry_Result>().FirstOrDefault().PlantId.ToString() // repository.PRW_PlantInquiry().FirstOrDefault().PlantId.ToString()
                ,
                startDate = DateTime.Today
                ,
                endDate = DateTime.Today
                ,
                Auth = DomainManager.GetEntityToList<COW_NavMenuAuthorizeInquiry_Result>("COW_NavMenuAuthorizeInquiry", parameters02).ToList().First() // repository.COW_NavMenuAuthorizeInquiry(HttpContext.User.Identity.Name, MethodBase.GetCurrentMethod().Name).ToList().First()
                ,
                COW_FilterPlantInquiry = plants.ToList()
                ,
                COW_FilterFactoriesAllInquiry = DomainManager.GetEntityToList<COW_FilterFactoriesAllInquiry_Result>("COW_FilterFactoriesAllInquiry", parameters01).ToList() // repository.COW_FilterFactoriesAllInquiry(repository.COW_FilterPlantInquiry(HttpContext.User.Identity.Name).FirstOrDefault().PlantId.ToString()).ToList()
                ,
                COW_FilterWorkshopTypesAllInquiry = DomainManager.GetEntityToList<COW_FilterWorkshopTypesAllInquiry_Result>("COW_FilterWorkshopTypesAllInquiry", parameters01).ToList()    //repository.COW_FilterWorkshopTypesAllInquiry(repository.COW_FilterPlantInquiry(HttpContext.User.Identity.Name).FirstOrDefault().PlantId.ToString()).ToList()
                ,
                COW_FilterWorkshopsAllInquiry = DomainManager.GetEntityToList<COW_FilterWorkshopsAllInquiry_Result>("COW_FilterWorkshopsAllInquiry", parameters05).ToList()
                ,
                Gubun2 = "D" //일간:D,주간:W,월간:M
                ,
                Gubun1 = "W" //라인:W,비가동:D
            };

            return View(viewModel);

        }

        //[HttpGet]
        public ActionResult GetDowntimeTop10Result(string p_PlantId, string p_FactoryId, string p_WorkshopTypeId, string p_WorkshopId, string p_WorkDate, string p_Gubun1, string p_Gubun2, DataSourceLoadOptions loadOptions)
        {
            try
            {
                Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
                parameters01.Add("@p_PlantId", p_PlantId);
                parameters01.Add("@p_FactoriesId", p_FactoryId);
                parameters01.Add("@p_WorkshopTypeId", p_WorkshopTypeId);
                parameters01.Add("@p_WorkshopId", p_WorkshopId);
                parameters01.Add("@p_StandardDate", p_WorkDate);
                parameters01.Add("@p_Section", p_Gubun1);
                parameters01.Add("@p_Period", p_Gubun2);
                
                var result = DataSourceLoader.Load(DomainManager.GetEntityToList<PRW_DowntimeHistoryTop10Inquiry_Result>("PRW_DowntimeHistoryTop10Inquiry", parameters01), loadOptions);
                var resultJson = JsonConvert.SerializeObject(result);
                return Content(resultJson, "application/json");
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message.ToString() });
            }
        }

        //그리드 불러오는 곳인데, 주석 쳐놓은게 기존에 쓰던것임..
        //어떻게 불러와야할지 몰라서 둘다 두긴함..
        //기존 반환 형식 : JsonResult
        //Extreme 반환 형식 : ActionResult
        public ActionResult GetDowntimeTop10ChartResult(string p_PlantId, string p_FactoryId, string p_WorkshopTypeId, string p_WorkshopId, string p_WorkDate, string p_Gubun1, string p_Gubun2, DataSourceLoadOptions loadOptions)
        {
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_PlantId", p_PlantId);
            parameters01.Add("@p_FactoriesId", p_FactoryId);
            parameters01.Add("@p_WorkshopTypeId", p_WorkshopTypeId);
            parameters01.Add("@p_WorkshopId", p_WorkshopId);
            parameters01.Add("@p_StandardDate", p_WorkDate);
            parameters01.Add("@p_Section", p_Gubun1);
            parameters01.Add("@p_Period", p_Gubun2);

            var result = DataSourceLoader.Load(DomainManager.GetEntityToList<PRW_DowntimeHistoryTop10Chart1Inquiry_Result>("PRW_DowntimeHistoryTop10Chart1Inquiry", parameters01), loadOptions);
            var resultJson = JsonConvert.SerializeObject(result);
            return Content(resultJson, "application/json");
        }
        
        #endregion
    }
}