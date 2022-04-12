using AskNLearn_WebAPI.Authentication;
using BLL.Entities.Admin;
using BLL.Entities.Instructor;
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
    [IntructorAuth]
    public class InstructorController : ApiController
    {
        [HttpGet]
        [Route("api/instructor/profile/{uid}")]
        public HttpResponseMessage InstructorProfile(int uid)
        {
                var data = InstructorServices.Instructor(uid);
                return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/instructor/course/list/{uid}")]
        public HttpResponseMessage PostedCourses(int uid)
        {
            var data = InstructorServices.PostedCourses(uid);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "No Posted Courses For This User");
        }
        [HttpPost]
        [Route("api/instructor/course/add/{uid}")]
        public HttpResponseMessage AddCourse(CourseModel c, int uid)
        {
            if (ModelState.IsValid)
            {
                InstructorServices.AddCourse(c, uid);
                return Request.CreateResponse(HttpStatusCode.Created, "Course Added Successfully");
                //return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }
        [HttpGet]
        [Route("api/instructor/course/view/{id}")]
        public HttpResponseMessage GetCourse(int id)
        {
            var data = InstructorServices.GetCourse(id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Course Found");
        }
        [HttpGet]
        [Route("api/instructor/course/delete/{id}")]
        public HttpResponseMessage DeleteCourse(int id)
        {
            var data = InstructorServices.DeleteCourse(id);
            if (data)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Course Successfully Deleted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Error! Course Not Found");
        }
        [HttpPost]
        [Route("api/instructor/course/edit/{coid}")]
        public HttpResponseMessage EditCourse(CourseModel c, int coid)
        {
            if (ModelState.IsValid)
            {
                InstructorServices.EditCourse(c, coid);
                return Request.CreateResponse(HttpStatusCode.Created, "Course Updated Successfully");
                //return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }
    }
}
