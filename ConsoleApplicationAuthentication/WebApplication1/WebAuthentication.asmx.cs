using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebAuthentication
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebAuthentication : System.Web.Services.WebService
    {
        public Authenticator a = new Authenticator();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]                                                         //WebMethod using Authenticator.cs to return a bool confirming
        public bool authenticateMe(string myUsername, string myPassword)    //or denying a username and password match as a web service
        {
            bool tORf = a.authenticated;
            tORf = a.authenticate(myUsername, myPassword);
            return tORf;

        }
    }
}
