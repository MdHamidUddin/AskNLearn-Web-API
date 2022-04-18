using BLL.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace AskNLearn_WebAPI.Authentication
{
    public class IntructorAuth : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var authHeader = actionContext.Request.Headers.Authorization;
            if (authHeader == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.NotFound, "No token supplied in Authorization Header");

            }
            else
            {
                string token = authHeader.ToString();
                var rs = UserServices.InstructorIsAuthenticated(token);
                if (!rs)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Instructor Access Required Or Token Expired");
                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}