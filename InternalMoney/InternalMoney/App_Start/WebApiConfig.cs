using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;

namespace InternalMoney
{
    public static class WebApiConfig
    {

		public static string ApiRootSegment {
			get { return "api/"; }
		}

        public static void Register(HttpConfiguration config)
        {
			// Конфигурация и службы Web API
			// Настройка Web API для использования только проверки подлинности посредством маркера-носителя.
			config.SuppressDefaultHostAuthentication();
			config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

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
