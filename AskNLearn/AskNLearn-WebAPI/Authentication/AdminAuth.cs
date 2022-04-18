using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace AskNLearn_WebAPI.Authentication
{
    public class AdminAuth : AuthorizationFilterAttribute
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
                var rs = UserServices.AdminIsAuthenticated(token);
                if (!rs)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized Access Or Token Expired");
                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}