using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using Microsoft.Owin.Security.Cookies;
namespace TCFPROJECT
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            CookieAuthenticationOptions options = new CookieAuthenticationOptions
            {
                LoginPath = new Microsoft.Owin.PathString("/Auth/Login"),
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            };
            app.UseCookieAuthentication(options);
        }
    }
}