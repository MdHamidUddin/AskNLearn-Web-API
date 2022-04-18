using BLL.Entities;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AskNLearn_WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class UsersController : ApiController
    {
        [HttpPost]
        [Route("api/user/login")]
        public HttpResponseMessage Login(UserModel u)
        {
            var data = UserServices.Authenticate(u.username, u.password);
            if (data==null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Username Or Password Invalid");
            }
            //var user = InstructorServices.Instructor(data.uid);
            //var userType = "";
            //if (user.userType.Equals("Instructor") && user.approval.Equals("active"))
            //{
            //    userType = "Instructor";
            //}
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/user/logout/{uid}")]
        public HttpResponseMessage Logout(int uid)
        {
            var data = UserServices.Logout(uid);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully Logged Out");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Already Loggedout");
        }
    }
}
