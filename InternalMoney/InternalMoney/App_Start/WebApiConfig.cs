using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace InternalMoney
{
    public static class WebApiConfig
    {

		public static string ApiRootSegment {
			get { return "api/"; }
		}

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
			config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/octet-stream"));

			config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: ApiRootSegment+"{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

			
        }
    }
}
