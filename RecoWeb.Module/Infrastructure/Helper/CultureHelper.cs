using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Threading;
using System.Globalization;


namespace RecoWeb.Module.Infrastructure.Helper
{
    public class CultureHelper
    {
        protected HttpSessionState session;

        //constructor 
        public CultureHelper(HttpSessionState httpSessionState)
        {
            session = httpSessionState;
        }
        // Properties
        public static int CurrentCulture
        {
            get
            {
                if (RecoWeb.Domain.Properties.Resources.Culture.Name == "ko-KR")
                {
                    return 0;
                }
                else if (RecoWeb.Domain.Properties.Resources.Culture.Name == "en-GB")
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            set
            {

                if (value == 0)
                {
                    RecoWeb.Domain.Properties.Resources.Culture = new CultureInfo("ko-KR");
                }
                else if (value == 1)
                {
                    RecoWeb.Domain.Properties.Resources.Culture = new CultureInfo("en-GB");
                }
                else
                {
                    if (RecoWeb.Domain.Properties.Resources.DefaultLang == "KOR")
                        RecoWeb.Domain.Properties.Resources.Culture = new CultureInfo("ko-KR");
                    else
                        RecoWeb.Domain.Properties.Resources.Culture = new CultureInfo("en-GB");
                }
            }
        }
    }
}