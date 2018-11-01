using RecoWeb.Module;
using RecoWeb.Module.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using RecoWeb.Module.Infrastructure.Concrete;
using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Data;
using Newtonsoft.Json;
using RecoWeb.WebUI.Models.POCO;
using RecoWeb.WebUI.Models;
using RecoWeb.Module.Models.POCO;

namespace RecoWeb.WebUI.Controllers
{
    public class LotController : BaseController
    {
        //2018 07 20 by roy (1) : BaseController에서 하단으로 내려옴
        public ResourceWrapper _resourceManager = new ResourceWrapper();

        private DomainConnectionManager DomainManager;
        public LotController(DomainConnectionManager Domains)
        {
            this.DomainManager = Domains;
        }

        // GET: Lot
        public ActionResult Index()
        {
            return View();
        }

        # region 정전계TreeView(LTM5)
        public ActionResult LTM5()
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

            var plants = DomainManager.GetEntityToList<PRW_PlantInquiry_Result>("PRW_PlantInquiry", null).ToList();
            
            Dapper.DynamicParameters parameters = new Dapper.DynamicParameters();
            parameters.Add("@p_PlantId", plants.FirstOrDefault().PlantId);
            
            Dapper.DynamicParameters parameters02 = new Dapper.DynamicParameters();
            parameters02.Add("@p_EmployeeId", HttpContext.User.Identity.Name);
            parameters02.Add("@p_MenuCode", MethodBase.GetCurrentMethod().Name);
            
            Dapper.DynamicParameters parameters03 = new Dapper.DynamicParameters();
            parameters03.Add("@p_UserId", HttpContext.User.Identity.Name);
            
            Dapper.DynamicParameters parameters04 = new Dapper.DynamicParameters();
            parameters04.Add("@p_PlantId", plants.FirstOrDefault().PlantId);
            
            Dapper.DynamicParameters parameters05 = new Dapper.DynamicParameters();
            parameters05.Add("@p_PlantId", plants.FirstOrDefault().PlantId);
            parameters05.Add("@p_FactoryId", DomainManager.GetEntityToList<COW_FilterFactoriesInquiry_Result>("COW_FilterFactoriesInquiry", parameters04).FirstOrDefault().FactoryId.ToString());
            parameters05.Add("@p_WorkshopTypeId", DomainManager.GetEntityToList<COW_FilterWorkshopTypesInquiry_Result>("COW_FilterWorkshopTypesInquiry", parameters04).FirstOrDefault().WorkshopTypeId.ToString());
            
            LotTraceTreeViewModel viewModel = new LotTraceTreeViewModel
            {
                MenuLocation = _menuPage
                ,
                ActivePage = _activePage
                ,
                resourceManager = _resourceManager
                ,
                PRW_PlantInquiry = DomainManager.GetEntityToList<PRW_PlantInquiry_Result>("PRW_PlantInquiry", null).Where(w => w.IsUse == "Y")
                ,
                //차종 불러오기.
                SMW_CarTypesInquiry = DomainManager.GetEntityToList<SMW_CarTypesInquiry_Result>("SMW_CarTypesInquiry", parameters).ToList()
                ,
                //선택된 plantId
                plantId = plants.FirstOrDefault().PlantId.ToString()
                ,
                startDate = DateTime.Today
                ,
                endDate = DateTime.Today
                ,
                printType = "2"
                ,
                Auth = DomainManager.GetEntityToList<COW_NavMenuAuthorizeInquiry_Result>("COW_NavMenuAuthorizeInquiry", parameters02).ToList().First()
                ,
                COW_FilterPlantInquiry = DomainManager.GetEntityToList<COW_FilterPlantInquiry_Result>("COW_FilterPlantInquiry", parameters03).ToList()
                ,
                COW_FilterFactoriesInquiry = DomainManager.GetEntityToList<COW_FilterFactoriesInquiry_Result>("COW_FilterFactoriesInquiry", parameters04).ToList()
                ,
                COW_FilterWorkshopTypesInquiry = DomainManager.GetEntityToList<COW_FilterWorkshopTypesInquiry_Result>("COW_FilterWorkshopTypesInquiry", parameters04).ToList()
                ,
                COW_FilterWorkshopsInquiry = DomainManager.GetEntityToList<COW_FilterWorkshopsInquiry_Result>("COW_FilterWorkshopsInquiry", parameters05).ToList()
                
            };
            return View(viewModel);
        }



        //[HttpGet]
        public ActionResult GetDataLTW_TraceReverseTreeviewLotInquiry(string p_PlantId, string p_FactoryId, string p_WorkshopTypeId, string p_WorkshopId, string p_WorkDate, string p_PaletteLotId, string p_LotId, string p_PaletteTagId, string p_UserId, DataSourceLoadOptions loadOptions)
        {
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_PlantId", p_PlantId);
            parameters01.Add("@p_FactoryId", p_FactoryId);
            parameters01.Add("@p_WorkshopTypeId", p_WorkshopTypeId);
            parameters01.Add("@p_WorkshopId", p_WorkshopId);
            parameters01.Add("@p_WorkDate", p_WorkDate);
            parameters01.Add("@p_PaletteLotId", p_PaletteLotId);
            parameters01.Add("@p_LotId", p_LotId);
            parameters01.Add("@p_PaletteTagId", p_PaletteTagId);
            parameters01.Add("@p_UserId", HttpContext.User.Identity.Name);
            
            var result = DataSourceLoader.Load(DomainManager.GetEntityToList<LTW_TraceReverseTreeviewLotInquiry_Result>("LTW_TraceReverseTreeviewLotInquiry", parameters01), loadOptions);
            var resultJson = JsonConvert.SerializeObject(result);
            return Content(resultJson, "application/json");
            
        }
        
        private static List<LTW_TraceReverseTreeviewInquiry_Result> LTW_TraceReverseTreeviewInquiry = new List<LTW_TraceReverseTreeviewInquiry_Result>();
        private static List<LTW_TraceReverseTreeviewInquiry_Result> LTW_TraceReverseTreeviewInquiryTarget = new List<LTW_TraceReverseTreeviewInquiry_Result>();

        public ActionResult GetDataLTW_TraceReverseTreeviewInquiry(string p_PartId, string p_LotTransId, string p_PaletteLotTransId, DataSourceLoadOptions loadOptions)
        {
            p_PartId = "0";
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_PartId", int.Parse(p_PartId));
            parameters01.Add("@p_LotTransId", int.Parse(p_LotTransId));
            parameters01.Add("@p_PaletteLotTransId", int.Parse(p_PaletteLotTransId));
            
            try
            {
                LTW_TraceReverseTreeviewInquiry = DomainManager.GetEntityToList<LTW_TraceReverseTreeviewInquiry_Result>("LTW_TraceReverseTreeviewInquiry", parameters01).ToList();  //repository.LTW_TraceReverseTreeviewInquiry(int.Parse(p_PartId), int.Parse(p_LotTransId), int.Parse(p_PaletteLotTransId)).ToList();
                LTW_TraceReverseTreeviewInquiryTarget = new List<LTW_TraceReverseTreeviewInquiry_Result>();
                LTW_TraceReverseTreeviewInquiry_Result itemRoot = LTW_TraceReverseTreeviewInquiry.Where(x => x.ParentPartId == "0").First();
                LTW_TraceReverseTreeviewInquiryTarget.Add(itemRoot);
                LTW_TraceReverseTreeviewInquiry.Remove(itemRoot);
                GetOrderByList(itemRoot.PartId, ref LTW_TraceReverseTreeviewInquiryTarget);

                var result = DataSourceLoader.Load(LTW_TraceReverseTreeviewInquiryTarget, loadOptions);
                //return Json(LTW_TraceReverseTreeviewInquiryTarget, JsonRequestBehavior.AllowGet);
                var resultJson = JsonConvert.SerializeObject(result);
                return Content(resultJson, "application/json");
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        private static void GetOrderByList(string myKey, ref List<LTW_TraceReverseTreeviewInquiry_Result> lst)
        {
            List<LTW_TraceReverseTreeviewInquiry_Result> listado2 = LTW_TraceReverseTreeviewInquiry.Where(x => x.ParentPartId == myKey).ToList();
            if (listado2.Count > 0)
            {
                foreach (LTW_TraceReverseTreeviewInquiry_Result item in listado2)
                {
                    lst.Add(item);
                    GetOrderByList(item.PartId, ref lst);
                }
            }
        }

        public PartialViewResult AjaxInquiryContextMenu3()
        {
            return PartialView("_LTM5Context");
        }

        #endregion

    }
}