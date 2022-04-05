using BLL.Entities;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;

namespace AskNLearn_WebAPI.Controllers
{
    [EnableCors("*","*","*")]
    public class AdminController : ApiController
    {
            //[HttpGet]
            //[Route("api/User/{id}")]

            //public HttpResponseMessage Get(int id)
            //{
            //    var st = AdminServices.Get(id);
            //    return Request.CreateResponse(HttpStatusCode.OK, st);
            //}

        [HttpGet]
        [Route("api/User/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = AdminServices.Get(id);
            //var d = new JavaScriptSerializer().Deserialize<List<UsersModel>>(data);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/User/")]
        public HttpResponseMessage Get()
        {
            var data = AdminServices.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }






        //public HttpResponseMessage UserList()
        //{
        //    var st = AdminServices.UserList();
        //    return Request.CreateResponse(HttpStatusCode.OK, st);
        //}

    }
}
