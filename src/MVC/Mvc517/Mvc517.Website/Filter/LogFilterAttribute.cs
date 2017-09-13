using Mvc517.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc517.Website.Filter
{
    public class LogFilterAttribute : ActionFilterAttribute
    {

        /// <summary>
        /// Action執行前
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //base.OnActionExecuting(filterContext);
            //Debug.WriteLine("OnActionExecuting");

            var values = filterContext.RouteData.Values;

            var controllerName = values["controller"].ToString();

            var log = $"Controller : {values["controller"]?.ToString()}, Action : {values["action"]?.ToString()}, Id : {values["id"]?.ToString()}";
            LogUtility.Logger.Info(log);

        }

        /// <summary>
        /// Action執行後
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            Debug.WriteLine("OnActionExecuted");

        }

        /// <summary>
        /// 結果執行前
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            Debug.WriteLine("OnResultExecuting");

        }

        /// <summary>
        /// 結果執行後
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
            Debug.WriteLine("OnResultExecuted");

        }
    }
}