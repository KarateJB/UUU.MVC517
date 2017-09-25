using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using Mvc517.DAL.Models;

namespace Mvc517.Website.Webservice
{
    /// <summary>
    /// Summary description for SysInfo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WsSysInfo : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string Get()
        {
            var sys = new SysInfo()
            {
                Title = "UUU.MVC517",
                Year = 2017,
                Author = "JB.Lin"
            };
            return new JavaScriptSerializer().Serialize(sys);
        }
    }
}
