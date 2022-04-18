using AskNLearn_WebAPI.Authentication;
using BLL.Entities.Admin;
using BLL.Entities.Instructor;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;

namespace AskNLearn_WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    [IntructorAuth]
    public class InstructorController : ApiController
    {
        //Will Show Instructor Profile Info
        [HttpGet]
        [Route("api/instructor/profile/{uid}")]
        public HttpResponseMessage InstructorProfile(int uid)
        {
                var data = InstructorServices.Instructor(uid);
                return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        //For showing the posted courses list by the instructor
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
        //For Creating a course
        [HttpPost]
        [Route("api/instructor/course/add/{uid}")]
        public HttpResponseMessage AddCourse(CourseModel c, int uid)
        {
            var httpRequest = HttpContext.Current.Request;
            c.ImageFile = httpRequest.Files[0];
            var data = c;
            if (ModelState.IsValid)
            {
                InstructorServices.AddCourse(data, uid);
                return Request.CreateResponse(HttpStatusCode.Created, "Course Added Successfully");
                //return new HttpResponseMessage(HttpStatusCode.OK);
            }
            //var sl = new JavaScriptSerializer().Serialize(ModelState);
            //var err = ModelState.ToDictionary(x => x.Key, x => x.Value);
            //var data = (from e in err
            //            select e.Key + e.Value).ToList();
            //var sl = new JavaScriptSerializer().Serialize(data);
            //var data = ModelState.Where(e => e.Value.Errors.Count > 0).ToList();
            //var query = from state in ModelState.Values
            //            from error in state.Errors
            //            select error.ErrorMessage;
            string messages = string.Join("", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
            //var sl = new JavaScriptSerializer().Serialize(data);
            //return Request.CreateErrorResponse(HttpStatusCode.OK, data);

            return Request.CreateErrorResponse(HttpStatusCode.OK, messages);
        }
        //To View The Course
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
        //To Delete the course
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
        //To Update the course
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
        [HttpPost]
        [Route("api/instructor/course/documents/add/{coid}")]
        public HttpResponseMessage AddDocumentsCourse(DocumentModel d, int coid)
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files[0].ContentType.Equals("image/jpeg") || httpRequest.Files[0].ContentType.Equals("image/png") || httpRequest.Files[0].ContentType.Equals("image/gif"))
            {
                d.ImageFile = httpRequest.Files[0];
            }
            if (httpRequest.Files[1]!=null)
            {
                d.DocFile = httpRequest.Files[1];
            }
            var data = d;
            if (ModelState.IsValid)
            {
                InstructorServices.AddDocuments(data, coid);
                return Request.CreateResponse(HttpStatusCode.Created, "Documents Added Successfully");
                //return new HttpResponseMessage(HttpStatusCode.OK);
            }
            //string messages = string.Join("", ModelState.Values
            //                            .SelectMany(x => x.Errors)
            //                            .Select(x => x.ErrorMessage));

            return Request.CreateResponse(HttpStatusCode.OK, ModelState);
        }

        [HttpGet]
        [Route("api/instructor/post/list")]
        public HttpResponseMessage PostList()
        {
            var data = InstructorServices.PostList();

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
