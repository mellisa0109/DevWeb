using RecoWeb.Domain.LocalResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Globalization;
using System.Web;
using System.Threading;

namespace RecoWeb.Module.Infrastructure.Concrete
{
    public class ResourceWrapper : IDisposable
    {
        private ResourceManager resourceManager;

        /// <summary>
        /// True:WebUI,False:Module
        /// </summary>
        /// <param name="isLangType"></param>
        public ResourceWrapper()
        {
            resourceManager = new ResourceManager("RecoWeb.Domain.LocalResource.Resource", typeof(Resource).Assembly);
            //if (isLangType)
            //    resourceManager = new ResourceManager("RecoWeb.Domain.LocalResource.Resource", typeof(Resource).Assembly);
            //else
            //    resourceManager = new ResourceManager("RecoWeb.Domain.LocalResource.Resource", typeof(Resource).Assembly);
        }

        public string String(string resourceKey)
        {
            //if(resourceKey == "Menu_JWP_page4")
            //{
            //    string aa = "";
            //}
            if (!string.IsNullOrEmpty(resourceManager.GetString(resourceKey)))
            {
                if (RecoWeb.Domain.Properties.Resources.Culture == null)
                    RecoWeb.Domain.Properties.Resources.Culture = new CultureInfo("ko-KR");     //언어가 설정되지 않았을때 한글로.
                switch (RecoWeb.Domain.Properties.Resources.Culture.Name)
                {
                    case "ko-KR":
                        if (string.IsNullOrEmpty(resourceManager.GetString(resourceKey, RecoWeb.Domain.Properties.Resources.Culture)))
                        {
                            return resourceKey;
                        }
                        else
                        {
                            return resourceManager.GetString(resourceKey, RecoWeb.Domain.Properties.Resources.Culture);
                        }

                    case "en-GB":
                        if (string.IsNullOrEmpty(resourceManager.GetString(resourceKey, RecoWeb.Domain.Properties.Resources.Culture)))
                        {
                            return resourceKey;
                        }
                        else
                        {
                            return resourceManager.GetString(resourceKey, RecoWeb.Domain.Properties.Resources.Culture);
                        }
                }
                return resourceKey;
            }
            else
            {
                //언어변환(resourceManager.GetString(resourceKey))시에 아래의 두개 항목중에 CurrentUICulture 사용한다.
                //언어변환시 선택된 언어에 값이 없을 경우, 다른 언어의 값을 찾아보고 그래도 없으면 resourceKey값 리턴
                //Thread.CurrentThread.CurrentUICulture.Name
                //Thread.CurrentThread.CurrentCulture.Name
                //if (Thread.CurrentThread.CurrentCulture.Name == Thread.CurrentThread.CurrentUICulture.Name)
                //{
                //    if (Thread.CurrentThread.CurrentUICulture.Name == "ko-KR")
                //    {
                //        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
                //    }
                //    else
                //    {
                //        Thread.CurrentThread.CurrentCulture = new CultureInfo("ko-KR");
                //    }
                //}

                return resourceManager.GetString(resourceKey);
            }

        }

        public void Dispose()
        {
            resourceManager = null;
        }
    }
}
//using RecoWeb.Domain.LocalResource;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Resources;
//using System.Globalization;
//using System.Web;
//using System.Threading;

//namespace RecoWeb.Module.Infrastructure.Concrete
//{
//    public class ResourceWrapper : IDisposable
//    {
//        private ResourceManager resourceManager;

//        /// <summary>
//        /// True:WebUI,False:Module
//        /// </summary>
//        /// <param name="isLangType"></param>
//        public ResourceWrapper()
//        {
//            resourceManager = new ResourceManager("RecoWeb.Domain.LocalResource.Resource", typeof(Resource).Assembly);
//            //if (isLangType)
//            //    resourceManager = new ResourceManager("RecoWeb.Domain.LocalResource.Resource", typeof(Resource).Assembly);
//            //else
//            //    resourceManager = new ResourceManager("RecoWeb.Domain.LocalResource.Resource", typeof(Resource).Assembly);
//        }

//        public string String(string resourceKey)
//        {
//            //if(resourceKey == "Menu_JWP_page4")
//            //{
//            //    string aa = "";
//            //}
//            if(!string.IsNullOrEmpty(resourceManager.GetString(resourceKey)))
//            {
//                //언어변환(resourceManager.GetString(resourceKey))시에 아래의 두개 항목중에 CurrentUICulture 사용한다.
//                //언어변환시 선택된 언어에 값이 없을 경우, 다른 언어의 값을 찾아보고 그래도 없으면 resourceKey값 리턴
//                //Thread.CurrentThread.CurrentUICulture.Name
//                //Thread.CurrentThread.CurrentCulture.Name
//                if (Thread.CurrentThread.CurrentCulture.Name == Thread.CurrentThread.CurrentUICulture.Name)
//                {
//                    if (Thread.CurrentThread.CurrentUICulture.Name == "ko-KR")
//                        Thread.CurrentThread.CurrentCulture = new CultureInfo("ko-KR");
//                    else
//                        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
//                }
//                else
//                    return resourceKey;

//                switch (Thread.CurrentThread.CurrentCulture.Name)
//                {
//                    case "ko-KR":
//                        if(string.IsNullOrEmpty(resourceManager.GetString(resourceKey, Thread.CurrentThread.CurrentCulture)))
//                        {
//                            return resourceKey;
//                        }
//                        else
//                        {
//                            return resourceManager.GetString(resourceKey, Thread.CurrentThread.CurrentCulture);
//                        }

//                    case "en-GB":
//                        if (string.IsNullOrEmpty(resourceManager.GetString(resourceKey, Thread.CurrentThread.CurrentCulture)))
//                        {
//                            return resourceKey;
//                        }
//                        else
//                        {
//                            return resourceManager.GetString(resourceKey, Thread.CurrentThread.CurrentCulture);
//                        }
//                }
//                return resourceKey;
//            }
//            else
//            {
//                return resourceManager.GetString(resourceKey);
//            }

//        }

//        public void Dispose()
//        {
//             resourceManager = null;
//        }
//    }
//}