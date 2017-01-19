using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using InternalMoney.Providers;
using InternalMoney.Infrasturcture;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Serialization;

[assembly: OwinStartup(typeof(InternalMoney.Startup))]

namespace InternalMoney
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration httpConfig = new HttpConfiguration();
            ConfigureWebApi(httpConfig);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            //app.UseWebApi(httpConfig);
            ConfigureOAuth(app);
            //Rest of code is here;
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(InternalMoneyContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(7),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }

        private void ConfigureWebApi(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
