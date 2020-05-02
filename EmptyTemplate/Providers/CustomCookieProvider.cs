using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EmptyTemplate.Providers
{
    public class CustomCookieProvider : CookieAuthenticationProvider
    {
        public override void ApplyRedirect(CookieApplyRedirectContext context)
        {
            if (!IsAjaxRequest(context.Request))
            {
                UrlHelper urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
                string actionUrl = urlHelper.Action("Login", "Account");

                context.Response.Redirect(actionUrl);
            }
        }

        private static bool IsAjaxRequest(IOwinRequest request)
        {
            IReadableStringCollection query = request.Query;
            if ((query != null) && (query["X-Requested-With"] == "XMLHttpRequest"))
            {
                return true;
            }
            IHeaderDictionary headers = request.Headers;
            return ((headers != null) && (headers["X-Requested-With"] == "XMLHttpRequest"));
        }

        //public override Task ValidateIdentity(CookieValidateIdentityContext context)
        //{
        //    var userId = Convert.ToInt32(context.Identity.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value);
        //    var passwordhash = context.Identity.Claims.Single(x => x.Type == CustomClaimTypes.Password).Value;

        //    AccountService accountService = new AccountService();
        //    User user = accountService.GetUser(userId);

        //    if (passwordhash != user.Password)
        //    {
        //        context.OwinContext.Authentication.SignOut();
        //        context.RejectIdentity();
        //    }

        //    return base.ValidateIdentity(context);
        //}
    }
}