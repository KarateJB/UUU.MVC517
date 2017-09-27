using Mvc517.DAL;
using Mvc517.DAL.Models;
using Mvc517.Utility;
using Mvc517.Website.Filter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Mvc517.Website.Controllers
{
    //[HandleError(View ="Error")]
    public class RestController : Controller
    {
        MvcDbContext _dbContext = null;

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.Result = View("Error");
        }


        public RestController()
        {
            this._dbContext = new MvcDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this._dbContext.Dispose();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="myName"></param>
        /// <returns></returns>
        [LogFilter]
        public ActionResult Index()
        {
            return View();
        }
        
    }
}
