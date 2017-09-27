using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc517.Website.HttpModules
{
    /// <summary>
    /// Redirect custom http module
    /// </summary>
    public class CustomModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication app)
        {
            app.BeginRequest += (s,e) =>
            {
                var uri = app.Context.Request.QueryString["uri"];
                if (!string.IsNullOrEmpty(uri))
                {
                    app.Context.Response.Redirect(uri);
                }
            };
        }
    }
}