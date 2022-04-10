using AskNLearn_WebAPI.Authentication;
using BLL.Entities.Admin;
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
    [EnableCors("*", "*", "*")]
    [CustomAuth]
    public class InstructorController : ApiController
    {
        [HttpGet]
        [Route("api/instructor/courses/list/{uid}")]
        public HttpResponseMessage PostedCourses(int uid)
        {
            if (InstructorServices.IsInRoleInstructor(uid))
            {
                var data = InstructorServices.PostedCourses(uid);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "You Need To Be Authorized As Instructor To Get Access");
        }
        [HttpGet]
        [Route("api/instructor/profile/{uid}")]
        public HttpResponseMessage InstructorProfile(int uid)
        {
            if (InstructorServices.IsInRoleInstructor(uid))
            {
                var data = InstructorServices.Instructor(uid);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "You Need To Be Authorized As Instructor To Get Access");
        }
    }
}
