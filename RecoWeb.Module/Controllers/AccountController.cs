using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using RecoWeb.Module.Models;
using RecoWeb.Module.Infrastructure.Helper;
using RecoWeb.Module.Infrastructure.Abstract;
using System.Xml;
using RecoWeb.Domain.Abstract;
using System.Data;

namespace RecoWeb.Module.Controllers
{
    public class AccountController : BaseController
    {
        //public AccountController()
        //    : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        //{
        //}

        //public AccountController(UserManager<ApplicationUser> userManager)
        //{
        //    UserManager = userManager;
        //}

        private DomainConnectionManager DomainManager;
        public AccountController(DomainConnectionManager Domains)
        {
            this.DomainManager = Domains;
        }

        IAuthProvider authProvider;
        private IMesEntityRepository repository;
        public string userConfig;

        public AccountController(IAuthProvider auth, IMesEntityRepository reposi, DomainConnectionManager Domains)
        {
            authProvider = auth;
            repository = reposi;
            this.DomainManager = Domains;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }

        //
        // GET: /Account/Login
        //[AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel());
        }


        // POST: /Account/Login
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //기준 언어 설정.
                if (RecoWeb.Domain.Properties.Resources.DefaultLang == "KOR")
                {
                    Session["CurrentCulture"] = 0;
                    CultureHelper.CurrentCulture = 0;       //세션 및 지역권 설정.
                }                    
                else
                {
                    Session["CurrentCulture"] = 1;
                    CultureHelper.CurrentCulture = 1;       //세션 및 지역권 설정.
                }

                //2018 06 08 by roy - Reco License를 취득하였는지 체크
                XmlDocument xml = new XmlDocument();
                bool crl = false;
                string siteTitle = "";
                xml.Load(Server.MapPath("~/Settings/webSettings.xml"));
                if (xml != null)
                {
                    crl = Convert.ToBoolean(xml.GetElementsByTagName("CRL")[0].InnerText);
                    siteTitle = xml.GetElementsByTagName("TitleName")[0].InnerText;
                }

                if (crl == true)
                {
                    //string appName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                    //string appName = Request.ServerVariables.Get("INSTANCE_ID");
                    string appName = System.Reflection.Assembly.GetExecutingAssembly().CodeBase.ToString();

                    string outMessage = "";

                    if (authProvider.CheckRecoLicense(Server, appName, ref outMessage) == false)
                    {
                        ModelState.AddModelError("", outMessage);
                        return View();
                    }
                }

                if (authProvider.Authenticate(model.UserName, model.Password))
                {
                    ViewBag.Title = (siteTitle == null ? "Reco+" : siteTitle);
                    //ObjectParameter a = new ObjectParameter("ee","master");
                    //ObjectParameter[] parameters =
                    //{    
                    //    new ObjectParameter("e", "master")       
                    //};
                    //repository.CallProcudure("COW_PlantInquiry", parameters);
                    SetCookie(model.UserName, authProvider.GetConfig(userConfig));
                    return Redirect(returnUrl ?? Url.Action("Index", "Home"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View(model);
            }


        }
        //LoginViewModel
        public ViewResult ManagePassword()
        {
            ManageUserInfo model = new ManageUserInfo()
            {
                UserName = HttpContext.User.Identity.Name
            };
            return View(model);
        }

        [HttpPost]
        public string ResetPassword(string userName)
        {
            try
            {
                Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
                parameters01.Add("@p_Id", userName);
                parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

                var returnParameter = DomainManager.GetEntityResult("COW_ResetPasswordSave", parameters01);

                if (parameters01.Get<string>("@p_OutMessage").ToString() == "OK")
                    return "OK";
                else
                    return parameters01.Get<string>("@p_OutMessage").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        [HttpPost]
        public string ChangePassword(string userName, string nowPassword, string changePassword)
        {
            try
            {
                Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
                parameters01.Add("@p_Id", userName);
                parameters01.Add("@p_NowPassword", nowPassword);
                parameters01.Add("@p_ChangePassword", changePassword);
                parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

                var returnParameter = DomainManager.GetEntityResult("COW_ChangePasswordSave", parameters01);

                if (parameters01.Get<string>("@p_OutMessage").ToString() == "OK")
                    return "OK";
                else
                    return parameters01.Get<string>("@p_OutMessage").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        //
        // GET: /Account/Register
        //[AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        //[AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser() { UserName = model.UserName };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/Disassociate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Disassociate(string loginProvider, string providerKey)
        {
            ManageMessageId? message = null;
            IdentityResult result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            if (result.Succeeded)
            {
                message = ManageMessageId.RemoveLoginSuccess;
            }
            else
            {
                message = ManageMessageId.Error;
            }
            return RedirectToAction("Manage", new { Message = message });
        }

        //
        // GET: /Account/Manage
        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";
            ViewBag.HasLocalPassword = HasPassword();
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        //
        // POST: /Account/Manage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Manage(ManageUserViewModel model)
        {
            bool hasPassword = HasPassword();
            ViewBag.HasLocalPassword = hasPassword;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (hasPassword)
            {
                if (ModelState.IsValid)
                {
                    IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
            }
            else
            {
                // User does not have a password so remove any validation errors caused by a missing OldPassword field
                ModelState state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (ModelState.IsValid)
                {
                    IdentityResult result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/LogOff
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {


            //AuthenticationManager.SignOut();
            authProvider.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        //[AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult RemoveAccountList()
        {
            var linkedAccounts = UserManager.GetLogins(User.Identity.GetUserId());
            ViewBag.ShowRemoveButton = HasPassword() || linkedAccounts.Count > 1;
            return (ActionResult)PartialView("_RemoveAccountPartial", linkedAccounts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && UserManager != null)
            {
                UserManager.Dispose();
                UserManager = null;
            }
            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            Error
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //2018 04 03 by roy - 언어변환
        public ActionResult ChangeCurrentCulture(int id)
        {
            //CultureHelper를 통해 문화권 설정 F12로 타고 들어가면 자세히 볼 수 있음.
            CultureHelper.CurrentCulture = id;

            //세션에 추가
            Session["CurrentCulture"] = id;

            // Redirect 
            return Redirect(Request.UrlReferrer.ToString());
        }
        #endregion
    }
}