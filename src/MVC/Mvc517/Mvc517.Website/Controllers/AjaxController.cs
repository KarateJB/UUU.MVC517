using Mvc517.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Mvc517.Website.Controllers
{
    public class AjaxController : Controller
    {
        [HttpGet]
        public async Task<JsonResult> SysInfo()
        {
            var sys = new SysInfo()
            {
                Title = "UUU.MVC517",
                Year = 2017,
                Author = "JB.Lin"
            };

            return Json(sys, JsonRequestBehavior.AllowGet);

            //if (Request.IsAjaxRequest())
            //{
            //    return Json(sys);
            //}
            //else
            //    return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<JsonResult> CurrentUsers()
        {
            var users = new List<User> {

                new User{ Id=8804, Name="JB Lin", JobTitle="Team lead"},
                new User{ Id=1234, Name="Amy Lin", JobTitle="Kid"}
            };

            return Json(users, JsonRequestBehavior.AllowGet);
        }
    }
}
