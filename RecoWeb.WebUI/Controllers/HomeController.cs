using RecoWeb.Domain.Concrete;
using RecoWeb.Module.Controllers;
//using RecoWeb.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecoWeb.Module.Models;
using RecoWeb.Module.Infrastructure.Concrete;
using RecoWeb.Module.Models.POCO;

namespace RecoWeb.WebUI.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        //2018 07 20 by roy (1) : BaseController에서 하단으로 내려옴
        public ResourceWrapper _resourceManager = new ResourceWrapper();

        private DomainConnectionManager DomainManager;
        public HomeController(DomainConnectionManager Domains)
        {
            this.DomainManager = Domains;
        }
                
        public ActionResult Index()
        {
            //ViewData["SubTitle"] = "Welcome in ASP.NET MVC 5 INSPINIA SeedProject ";
            //ViewData["Message"] = "It is an application skeleton for a typical MVC 5 project. You can use it to quickly bootstrap your webapp projects.";
            ViewData["SubTitle"] = "Welcome in Reco Web Middleware ";
            ViewData["Message"] = "It is an middleware application for a mes project. You can use it to quickly admin web app your mes";
            
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@EmployeeId", HttpContext.User.Identity.Name);

            NavMenuInquiryViewModel viewModel1 = new NavMenuInquiryViewModel();
            var a = DomainManager.GetEntityToList<COW_NavMenuListInquiry_Result>("COW_NavMenuListInquiry", parameters01);

            NavMenuInquiryViewModel viewModel = new NavMenuInquiryViewModel
            {
                COW_NavMenuListInquiry = DomainManager.GetEntityToList<COW_NavMenuListInquiry_Result>("COW_NavMenuListInquiry", parameters01)//.ToList() //repository.COW_NavMenuListInquiry(HttpContext.User.Identity.Name).ToList()
                ,
                resourceManager = _resourceManager
            };
             Session.Add("UserId", User.Identity.Name);
            Session.Add("Menu", viewModel);
            return View();
        }

        public ActionResult ActionWithParameters(string category)
        {
            ViewData["SubTitle"] = "Simple example of second view";
            ViewData["Message"] = "Data are passing to view by ViewData from controller";

            return PartialView("");
        }
    }
}