using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AskNLearn.Controllers
{
    public class AdminController : ApiController
    {
        [HttpGet]
        [Route("api/User/{id}")]

        public HttpResponseMessage Get(int id)
        {
            var st = AdminServices.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, st);
        }

        [HttpGet]
        [Route("api/User/")]
        public HttpResponseMessage UserList()
        {
            var st = AdminServices.UserList();
            return Request.CreateResponse(HttpStatusCode.OK, st);
        }


}
}
