using RecoWeb.Domain.Abstract;
using RecoWeb.Domain.Concrete;
using RecoWeb.Module.Controllers;
using RecoWeb.Module.Infrastructure.Concrete;
using RecoWeb.WebUI.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace RecoWeb.WebUI.Controllers
{
    public class CommonController : BaseController
    {
        //2018 07 20 by roy (1) : BaseController에서 하단으로 내려옴
        public ResourceWrapper _resourceManager = new ResourceWrapper();

        private DomainConnectionManager DomainManager;
        public CommonController(DomainConnectionManager Domains)
        {
            this.DomainManager = Domains;
        }
        
        // GET: Common
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetCOW_FilterPlantInquiry(string p_UserId)
        {
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_UserId", p_UserId);

            return Json(DomainManager.GetEntityToList<COW_FilterPlantInquiry_Result>("COW_FilterPlantInquiry", parameters01)
                , JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCOW_FilterFactoriesInquiry(string p_PlantId)
        {
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_PlantId", p_PlantId);

            return Json(DomainManager.GetEntityToList<COW_FilterFactoriesInquiry_Result>("COW_FilterFactoriesInquiry", parameters01)
                , JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCOW_FilterWorkshopsInquiry(string p_PlantId, string p_FactoryId, string p_WorkshopTypeId)
        {
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_PlantId", p_PlantId);
            parameters01.Add("@p_FactoryId", p_FactoryId);
            parameters01.Add("@p_WorkshopTypeId", p_WorkshopTypeId);

            return Json(DomainManager.GetEntityToList<COW_FilterWorkshopsInquiry_Result>("COW_FilterWorkshopsInquiry", parameters01)
                , JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCOW_FilterWorkshopTypesInquiry(string p_PlantId)
        {
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_PlantId", p_PlantId);

            return Json(DomainManager.GetEntityToList<COW_FilterWorkshopTypesInquiry_Result>("COW_FilterWorkshopTypesInquiry", parameters01)
                , JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCOW_CodeRolesInquiry()
        {

            //return Json(repository.COW_CodeRolesInquiry()
            //    , JsonRequestBehavior.AllowGet);
            var jj = Json(DomainManager.GetEntityToList<COW_CodeRolesInquiry_Result>("COW_CodeRolesInquiry", null)
                , JsonRequestBehavior.AllowGet);
            string jjs = new JavaScriptSerializer().Serialize(jj.Data);
            return jj;
        }
        

        public ActionResult GetCOW_CodeRolesInquiryP()
        {
            List<COW_CodeRolesInquiry_Result> results = DomainManager.GetEntityToList<COW_CodeRolesInquiry_Result>("COW_CodeRolesInquiry", null).ToList();
            Dictionary<string, string> resultList = new Dictionary<string, string>();
            foreach (var result in results)
            {
                resultList.Add(result.RoleId, result.RoleName);
            }
            return PartialView(resultList);
        }

        public ActionResult GetCOW_FilterFactoriesAllInquiry(string p_PlantId)
        {
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_PlantId", p_PlantId);

            return Json(DomainManager.GetEntityToList<COW_FilterFactoriesAllInquiry_Result>("COW_FilterFactoriesAllInquiry", parameters01)
                , JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCOW_FilterWorkshopsAllInquiry(string p_PlantId, string p_FactoryId, string p_WorkshopTypeId)
        {
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_PlantId", p_PlantId);
            parameters01.Add("@p_FactoryId", p_FactoryId);
            parameters01.Add("@p_WorkshopTypeId", p_WorkshopTypeId);

            return Json(DomainManager.GetEntityToList<COW_FilterWorkshopsAllInquiry_Result>("COW_FilterWorkshopsAllInquiry", parameters01)
                , JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCOW_FilterWorkshopTypesAllInquiry(string p_PlantId)
        {
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_PlantId", p_PlantId);

            return Json(DomainManager.GetEntityToList<COW_FilterWorkshopTypesAllInquiry_Result>("COW_FilterWorkshopTypesAllInquiry", parameters01)
                , JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCOW_FilterEmployeeInquiry(string p_PlantId)
        {
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_PlantId", p_PlantId);

            return Json(DomainManager.GetEntityToList<COW_FilterEmployeeInquiry_Result>("COW_FilterEmployeeInquiry", parameters01)
                , JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCOW_PlantInquiry(string employee)
        {
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_EmployeeId", employee);

            return Json(DomainManager.GetEntityToList<COW_PlantInquiry_Result>("COW_PlantInquiry", parameters01)
                , JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCOW_WorkTypeInquiry(string plant)
        {
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_PlantId", plant);

            return Json(DomainManager.GetEntityToList<COW_WorkTypeInquiry_Result>("COW_WorkTypeInquiry", parameters01)
                , JsonRequestBehavior.AllowGet);
        }
    }
}