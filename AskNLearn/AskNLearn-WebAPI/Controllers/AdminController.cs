using BLL.Entities;
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

        //[HttpGet]
        //[Route("api/User/{id}")]
        //public HttpResponseMessage Get(int id)
        //{
        //    var data = AdminServices.Get(id);
        //    //var d = new JavaScriptSerializer().Deserialize<List<UsersModel>>(data);
        //    return Request.CreateResponse(HttpStatusCode.OK, data);
        //}

        [HttpGet]
        [Route("api/users/{uid}")]
        public HttpResponseMessage AllUsers(int uid)
        {
            var data = AdminServices.Get(uid);
            var d = new JavaScriptSerializer().Deserialize<List<UsersListModel>>(data);
            return Request.CreateResponse(HttpStatusCode.OK, d);
        }

        [HttpGet]
        [Route("api/user/")]
        public HttpResponseMessage Get()
        {
            var data = AdminServices.Get();
            var d = new JavaScriptSerializer().Deserialize<List<UsersListModel>>(data);
            return Request.CreateResponse(HttpStatusCode.OK, d);

        }

        //[HttpGet]
        //[Route("api/InstructorList")]
        //public HttpResponseMessage InstructorList()
        //{
        //    var data = AdminServices.InstructorList();
        //    return Request.CreateResponse(HttpStatusCode.OK, data);
        //}

        //[HttpGet]
        //[Route("api/InstructorInfo")]
        //public HttpResponseMessage InstructorInfo()
        //{
        //    var data = AdminServices.InstructorInfoList();
        //    return Request.CreateResponse(HttpStatusCode.OK, data);
        //}
        //[HttpGet]
        //[Route("api/AllInstructorInfo")]
        //public HttpResponseMessage AllInst()
        //{
        //    var data = AdminServices.AllInstructor();
        //    return Request.CreateResponse(HttpStatusCode.OK, data);
        //}



        [HttpGet]
        [Route("api/Instructors")]
        public HttpResponseMessage InstructorsList()
        {
            var data = AdminServices.Instructors();
            var d = new JavaScriptSerializer().Deserialize<List<UsersListModel>>(data);
            return Request.CreateResponse(HttpStatusCode.OK, d);
        }
        [HttpGet]
        [Route("api/moderators")]
        public HttpResponseMessage ModeratorsList()
        {
            var data = AdminServices.Moderators();
            var d = new JavaScriptSerializer().Deserialize<List<UsersListModel>>(data);
            return Request.CreateResponse(HttpStatusCode.OK, d);
        }

        [HttpGet]
        [Route("api/learners")]
        public HttpResponseMessage LearnersList()
        {
            var data = AdminServices.Learners();
            var d = new JavaScriptSerializer().Deserialize<List<UsersListModel>>(data);
            return Request.CreateResponse(HttpStatusCode.OK, d);
        }

        [HttpGet]
        [Route("api/admins")]
        public HttpResponseMessage AdminsList()
        {
            var data = AdminServices.Admins();
            var d = new JavaScriptSerializer().Deserialize<List<UsersListModel>>(data);
            return Request.CreateResponse(HttpStatusCode.OK, d);
        }

        //public HttpResponseMessage UserList()
        //{
        //    var st = AdminServices.UserList();
        //    return Request.CreateResponse(HttpStatusCode.OK, st);
        //}
        [HttpGet]
        [Route("api/recentPost")]
        public HttpResponseMessage RecentPost()
        {
            var data = AdminServices.GetRecentPost();
            var d = new JavaScriptSerializer().Deserialize<List<RecentPostModel>>(data);
            return Request.CreateResponse(HttpStatusCode.OK, d);
        }


        [HttpGet]
        [Route("api/recentCourses")]
        public HttpResponseMessage RecentCourses()
        {
            var data = AdminServices.GetRecentCourses();
            var d = new JavaScriptSerializer().Deserialize<List<RecentCoursesModel>>(data);
            int n = d.Count();

            List<RecentCoursesModel> LS = new List<RecentCoursesModel>();
            RecentCoursesModel obj = new RecentCoursesModel();

           

            return Request.CreateResponse(HttpStatusCode.OK, d);
        }



    }
}
