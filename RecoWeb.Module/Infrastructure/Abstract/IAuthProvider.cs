using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecoWeb.Module.Infrastructure.Abstract
{
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password);
        bool CheckRecoLicense(HttpServerUtilityBase Server, string appName, ref string outMessage);
        void SignOut();

        string GetConfig(string config);
    }
}