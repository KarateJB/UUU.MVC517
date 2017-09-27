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
    [ScriptService]
    [WebService(Namespace = "Mvc517.Website.Webservice", Description = "System information")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WsSysInfo : System.Web.Services.WebService
    {

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        //Use HttpGet makes returning-json not works! See https://weblogs.asp.net/scottgu/json-hijacking-and-how-asp-net-ajax-1-0-mitigates-these-attacks
        public SysInfo GetJsonObj()
        {
            var sys = new SysInfo()
            {
                Title = "Get json object from web service",
                Year = 2017,
                Author = "JB.Lin"
            };
            return sys;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)] 
        //Use HttpGet makes returning-json not works! See https://weblogs.asp.net/scottgu/json-hijacking-and-how-asp-net-ajax-1-0-mitigates-these-attacks
        public string GetJsonStr()
        {
            var sys = new SysInfo()
            {
                Title = "Get json string from web service",
                Year = 2017,
                Author = "JB.Lin"
            };
            return new JavaScriptSerializer().Serialize(sys);
            
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)] 
        public SysInfo GetXml()
        {
            var sys = new SysInfo()
            {
                Title = "Get XML from web service",
                Year = 2017,
                Author = "JB.Lin"
            };
            return sys;
        }
    }
}
