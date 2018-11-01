using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecoWeb.Module.Infrastructure.Helper;
using RecoWeb.Module.Infrastructure.Concrete;
using System.Configuration;
using System.Xml;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Data.Entity.Core.Objects;
using System.Web.Script.Serialization;
using System.Collections;
using Newtonsoft.Json;

namespace RecoWeb.Module.Controllers
{
    public class BaseController : Controller
    {
        //언어변환시 참조할 리소스를 모든 컨트롤러에서 상속 받도록 한다
        public ResourceWrapper _resourceManager = new ResourceWrapper();

        public DomainConnectionManager _DBManager;
        
        string PasswordKey = "Reco";

        protected override void ExecuteCore()
        {
            ViewBag.Title = "asd";

            // 언어변환 관련 - 문화권 설정
            int culture = 0;

            if (this.Session == null || this.Session["CurrentCulture"] == null)
            {
                int.TryParse(ConfigurationManager.AppSettings["Culture"], out culture);
                this.Session["CurrentCulture"] = culture;
            }
            else
            {
                culture = (int)this.Session["CurrentCulture"];
            }

            // 문화권 설정
            CultureHelper.CurrentCulture = culture;

            //webSettings.xml에 있는 설정 값들 갖고오기.
            XmlDocument xml = new XmlDocument();
            xml.Load(Server.MapPath("~/Settings/webSettings.xml"));
            if (xml != null)
            {
                ViewBag.Title = xml.GetElementsByTagName("TitleName")[0].InnerText;
            }
            else
            {
                ViewBag.Title = "RecoWeb";
            }

            ViewBag.Skin = GetCookieValue(HttpContext.User.Identity.Name + "_Skin");

            base.ExecuteCore();
        }

        //protected override bool DisableAsyncSupport
        //{
        //    get { return true; }
        //}

        /// <summary>
        /// object[] -> ObjectParameter[]로 변환해줌
        /// 사용처 1. DB호출시 필요한 파라미터 변환
        /// 사용처 2. GetEntityResult의 결과물을 ObjectParameter로 변환 
        /// </summary>
        //public ObjectParameter[] ConvertObjParameters(object[] objParameters)
        //{
        //    if (objParameters != null)
        //    {
        //        ObjectParameter[] returnParameters = new ObjectParameter[objParameters.Length];
        //        for (int index = 0; index < objParameters.Length; index++)
        //        {
        //            if (objParameters[index] == null)
        //            {
        //                returnParameters[index] = new ObjectParameter("z_" + index.ToString(), typeof(string));
        //                returnParameters[index].Value = objParameters[index];
        //            }
        //            else if (objParameters[index].GetType().Name.Replace("[]", "") == returnParameters.GetType().Name.Replace("[]", ""))
        //            {
        //                switch (((ObjectParameter)objParameters[index]).ParameterType.Name)
        //                {
        //                    case "Int32":
        //                        returnParameters[index] = new ObjectParameter(((ObjectParameter)objParameters[index]).Name, typeof(Int32));
        //                        returnParameters[index].Value = ((ObjectParameter)objParameters[index]).Value == null ? "" : ((ObjectParameter)objParameters[index]).Value;
        //                        break;

        //                    case "String":
        //                        returnParameters[index] = new ObjectParameter(((ObjectParameter)objParameters[index]).Name, typeof(string));
        //                        returnParameters[index].Value = ((ObjectParameter)objParameters[index]).Value == null ? "" : ((ObjectParameter)objParameters[index]).Value;
        //                        break;

        //                    case "Boolean":
        //                        returnParameters[index] = new ObjectParameter(((ObjectParameter)objParameters[index]).Name, typeof(bool));
        //                        returnParameters[index].Value = ((ObjectParameter)objParameters[index]).Value == null ? "" : ((ObjectParameter)objParameters[index]).Value;
        //                        break;
        //                }

        //            }
        //            else
        //            {
        //                switch (objParameters[index].GetType().Name.ToString())
        //                {
        //                    case "Int32":
        //                        returnParameters[index] = new ObjectParameter("z_" + index.ToString(), typeof(Int32));
        //                        returnParameters[index].Value = objParameters[index].ToString();
        //                        break;

        //                    case "String":
        //                        returnParameters[index] = new ObjectParameter("z_" + index.ToString(), typeof(string));
        //                        returnParameters[index].Value = objParameters[index].ToString();
        //                        break;
        //                    case "Boolean":
        //                        returnParameters[index] = new ObjectParameter("z_" + index.ToString(), typeof(bool));
        //                        returnParameters[index].Value = objParameters[index];
        //                        break;
        //                }
        //            }
        //        }
        //        return returnParameters;
        //    }

        //    return null;
        //}

        /// <summary>
        /// IList → JsonString
        /// </summary>
        public static string ConvertIListToJsonString(IList vv)
        {
            return new JavaScriptSerializer().Serialize(vv);
        }
        
        /// <summary>
        /// 쿠키 체크->쿠기 추가
        /// </summary>
        public void SetCookie(string userName, string Configs)
        {
            if (HttpContext.Request.Cookies["Current_User"] == null)
            {
                AddCookie("Current_User", userName.ToString());
            }
            else if (DescryptString(HttpContext.Request.Cookies["Current_User"].Value.ToString()) != userName)
            {
                AddCookie("Current_User", userName.ToString());
            }

            if (HttpContext.Request.Cookies[userName + "_Skin"] == null)
            {
                if (string.IsNullOrEmpty(Configs))
                {
                    AddCookie(userName + "_Skin", ""); //Skin의 값이 ""이면 Default
                }
                else
                {
                    string[] options;
                    options = Configs.Split(';');
                    AddCookie(userName + "_Skin", options[0].ToString());
                    AddCookie(userName + "_Test1", options[1].ToString());
                    AddCookie(userName + "_Test2", options[2].ToString());
                    AddCookie(userName + "_IsTrue", options[3].ToString());
                    AddCookie(userName + "_IsFalse", options[4].ToString());
                }

                ViewBag.Skin = DescryptString(HttpContext.Request.Cookies[userName + "_Skin"].Value.ToString());
            }
            else
            {
                ViewBag.Skin = GetCookieValue(userName + "_Skin");
            }
        }
        /// <summary>
        /// 쿠키 저장
        /// </summary>
        public void AddCookie(string keyName, string value)
        {
            HttpCookie ConfigCookie;
            ConfigCookie = new HttpCookie(keyName, EncryptString(value));
            ConfigCookie.Expires = DateTime.Now.AddHours(1);

            Response.Cookies.Add(ConfigCookie);
            //Response.SetCookie(ConfigCookie);
        }

        /// <summary>
        /// 쿠기 값 가져오기(복호화해서)
        /// </summary>
        public string GetCookieValue(string keyName)
        {
            string returnValue;
            if (HttpContext.Request.Cookies[keyName] == null)
            {
                returnValue = null;
            }
            else
            {
                returnValue = DescryptString(HttpContext.Request.Cookies[keyName].Value.ToString());
            }

            return returnValue;
        }
        
        /// <summary>
        /// 암호화2 ?
        /// </summary>
        /// <param name="_text"></param>
        /// <returns></returns>
        public string Encrypt256(string _text)
        {
            string Password = "RecoSys";
            RijndaelManaged RijndaeCipher = new RijndaelManaged();
            byte[] PlainText = Encoding.Unicode.GetBytes(_text);
            byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
            ICryptoTransform Encryptor = RijndaeCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream();

            CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(PlainText, 0, PlainText.Length);
            cryptoStream.FlushFinalBlock();

            byte[] CipherBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            
            return Convert.ToBase64String(CipherBytes);
        }

        /// <summary>
        /// 암호화
        /// </summary>
        public string EncryptString(string text)
        {
            byte[] inputText = System.Text.Encoding.Unicode.GetBytes(text);
            byte[] passwordSalt = Encoding.ASCII.GetBytes(PasswordKey.Length.ToString());
            PasswordDeriveBytes secretKey = new PasswordDeriveBytes(PasswordKey, passwordSalt);
            Rijndael rijAlg = Rijndael.Create();
            rijAlg.Key = secretKey.GetBytes(32);
            rijAlg.IV = secretKey.GetBytes(16);
            ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);
            MemoryStream msEncrypt = new MemoryStream();
            CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            csEncrypt.Write(inputText, 0, inputText.Length);
            csEncrypt.FlushFinalBlock();
            byte[] encryptBytes = msEncrypt.ToArray();
            msEncrypt.Close();
            csEncrypt.Close();
            
            // Base64
            string encryptedData = Convert.ToBase64String(encryptBytes);
            return encryptedData;
        }

        /// <summary>
        /// 복호화
        /// </summary>
        public string DescryptString(string text)
        {
            byte[] encryptedData = Convert.FromBase64String(text);
            byte[] passwordSalt = Encoding.ASCII.GetBytes(PasswordKey.Length.ToString());
            PasswordDeriveBytes secretKey = new PasswordDeriveBytes(PasswordKey, passwordSalt);
            Rijndael rijAlg = Rijndael.Create();
            rijAlg.Key = secretKey.GetBytes(32);
            rijAlg.IV = secretKey.GetBytes(16);
            ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
            MemoryStream msDecrypt = new MemoryStream(encryptedData);
            CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            int decryptedCount = csDecrypt.Read(encryptedData, 0, encryptedData.Length);
            msDecrypt.Close();
            csDecrypt.Close();
            // Base64
            string decryptedData = Encoding.Unicode.GetString(encryptedData, 0, decryptedCount);
            return decryptedData;
        }
    }
}
