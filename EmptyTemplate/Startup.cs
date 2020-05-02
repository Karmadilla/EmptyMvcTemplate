using EmptyTemplate.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmptyTemplate
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureCookieAuthentication(app);
        }

        private void ConfigureCookieAuthentication(IAppBuilder app)
        {
            CookieAuthenticationOptions options = new CookieAuthenticationOptions();
            options.AuthenticationType = "ApplicationCookie";
            options.ExpireTimeSpan = TimeSpan.FromHours(24);
            options.LoginPath = new PathString("/Account/Login");
            options.Provider = new CustomCookieProvider();

            app.UseCookieAuthentication(options);
        }
    }
}