using System.Web;
using System.Web.Mvc;

namespace LocadoraVeiculos.Security
{
    public class SessionAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return httpContext.Session["LOCADORAUSER"] != null;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("/Funcionarios/Login");
        }
    }
}