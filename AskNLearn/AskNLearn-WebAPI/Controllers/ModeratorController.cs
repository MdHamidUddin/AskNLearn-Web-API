using AskNLearn_WebAPI.Authentication;
using BLL.Entities.Admin;
using BLL.Entities.Moderator;
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
    [ModeratorAuth]
    public class ModeratorController : ApiController
    {
        [HttpGet]
        [Route("api/Moderator/Learners/{uid}")]
        public HttpResponseMessage GetUser(int uid)
        {
            var data = ModeratorServices.Get(uid);
            var d = new JavaScriptSerializer().Deserialize<List<LearnerlistModel>>(data);
            return Request.CreateResponse(HttpStatusCode.OK, d);
        }

        [HttpGet]
        [Route("api/Moderator/Learners")]
        public HttpResponseMessage AllUsers()
        {
            var data = ModeratorServices.Get();
            var d = new JavaScriptSerializer().Deserialize<List<LearnerlistModel>>(data);
            return Request.CreateResponse(HttpStatusCode.OK, d);
        }


        [HttpPost]
        [Route("api/Moderator/AddPost")]
        public HttpResponseMessage Post(AddPostModel User)
        {
            var U = new JavaScriptSerializer().Serialize(User);
            var data = ModeratorServices.AddNewPost(U);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        [HttpGet]
        [Route("api/Moderator/AllPost")]
        public HttpResponseMessage RecentPost()
        {
            var data = ModeratorServices.GetPost();
            var d = new JavaScriptSerializer().Deserialize<List<RecentPostModel>>(data);
            return Request.CreateResponse(HttpStatusCode.OK, d);
        }

        [HttpPost]
        [Route("api/Moderator/post/update")]
        public HttpResponseMessage UpdatePost(AddPostModel User)
        {
            var data = ModeratorServices.UpdatePost(User);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/Moderator/post/delete/{pid}")]
        public HttpResponseMessage DeletePost(int pid)
        {
            var data = ModeratorServices.DeletePost(pid);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
