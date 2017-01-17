using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace InternalMoney
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

		private const string ROOT_DOCUMENT = "/index.html";

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
			string url = Request.Url.LocalPath;
			bool isApi = Request.Url.Segments.Contains(WebApiConfig.ApiRootSegment);
			bool isToken = Request.Url.Segments.Contains(WebApiConfig.TokenSegment);
			if (!System.IO.File.Exists(Context.Server.MapPath(url)) && !isApi && !isToken)
				Context.RewritePath(ROOT_DOCUMENT);
		}
    }
}
