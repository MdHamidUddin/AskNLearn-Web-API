using BLL.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace AskNLearn_WebAPI.Authentication
{
    public class CustomAuth : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var authHeader = actionContext.Request.Headers.Authorization;
            if (authHeader == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.NotFound, "No token supplied in authorization header");

            }
            else
            {
                string token = authHeader.ToString();
                var rs = UserServices.IsAuthenticated(token);
                if (!rs)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized Access Or Token Expired");
                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}