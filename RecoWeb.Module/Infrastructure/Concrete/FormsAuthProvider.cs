using QLicense;
using RecoLicense;
using RecoWeb.Domain.Abstract;
using RecoWeb.Module.Controllers;
using RecoWeb.Module.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RecoWeb.Module.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        IMesEntityRepository repository;
        BaseController c = new BaseController();
        public string UserConfig;


        public FormsAuthProvider(IMesEntityRepository repositoryParam)
        {
            repository = repositoryParam;
        }

        public bool Authenticate(string username, string password)
        {
            bool result = false;

            result = CheckAuthenticate(username, password);
            //bool result = FormsAuthentication.Authenticate(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }
            return result;
        }



        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        public bool CheckAuthenticate(string username, string password)
        {
            Dapper.DynamicParameters parameters01 = new Dapper.DynamicParameters();
            parameters01.Add("@p_UserId", username);
            parameters01.Add("@p_Password", password);
            parameters01.Add("@p_OutResult", dbType: DbType.Boolean, direction: ParameterDirection.Output, size: 5215585);
            parameters01.Add("@p_OutMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
            parameters01.Add("@p_OutConfig", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);

            var returnParameter = repository.CallProcudureToReturnMessage("COW_AuthenticateInquiry", parameters01);

            //repository.COW_AuthenticateInquiry(username, password, p_OutResult, p_OutMessage, p_OutConfig);
            UserConfig = parameters01.Get<string>("@p_OutConfig").ToString();
            return parameters01.Get<bool>("@p_OutResult");
        }

        public string GetConfig(string Configs)
        {
            Configs = UserConfig;

            return Configs;
        }

        byte[] _certPubicKeyData;
        /// <summary>
        /// 라이센스 확인
        /// </summary>
        /// <param name="appName"></param>
        /// <returns></returns>
        public bool CheckRecoLicense(HttpServerUtilityBase Server, string appName, ref string outMessage)
        {
            //Initialize variables with default values
            MyLicense _lic = null;
            string _msg = string.Empty;
            LicenseStatus _status = LicenseStatus.UNDEFINED;

            //Read public key from assembly
            Assembly _assembly = Assembly.GetExecutingAssembly();
            using (MemoryStream _mem = new MemoryStream())
            {
                _assembly.GetManifestResourceStream("RecoWeb.Module.LicenseVerify.cer").CopyTo(_mem);

                _certPubicKeyData = _mem.ToArray();
            }

            //Check if the XML license file exists
            if (File.Exists(Server.MapPath("~/") + "Content/license/License.lic"))
            {
                //string appName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                //string appName = System.Reflection.Assembly.GetExecutingAssembly().CodeBase.ToString();
                _lic = (MyLicense)LicenseHandler.ParseLicenseFromBASE64String(
                    appName,
                    typeof(MyLicense),
                    File.ReadAllText(Server.MapPath("~/") + "Content/license/License.lic"),
                    _certPubicKeyData,
                    out _status,
                    out _msg);
            }
            else
            {
                _status = LicenseStatus.INVALID;
                _msg = "Your copy of this application is not activated";
            }

            bool returnBool = false;
            switch (_status)
            {
                case LicenseStatus.VALID:

                    //TODO: If license is valid, you can do extra checking here
                    //TODO: E.g., check license expiry date if you have added expiry date property to your license entity
                    //TODO: Also, you can set feature switch here based on the different properties you added to your license entity 

                    //Here for demo, just show the license information and RETURN without additional checking       
                    //licInfo.ShowLicenseInfo(_lic);

                    outMessage = "Licensed";

                    returnBool = true;
                    break;

                default:
                    //for the other status of license file, show the warning message
                    //and also popup the activation form for user to activate your application
                    //MessageBox.Show(_msg, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    //outMessage = _msg + "\r\n Please contact the MES Administrator with this code [" + LicenseHandler.GenerateUID(appName) + "] (" + appName + ")"; 
                    outMessage = _msg + "\r\n Please contact the MES Administrator with this code [" + LicenseHandler.GenerateUID(appName) + "]";
                    returnBool = false;
                    break;
            }
            return returnBool;
        }
    }
}