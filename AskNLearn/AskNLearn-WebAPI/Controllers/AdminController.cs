using AskNLearn_WebAPI.Authentication;
using BLL.Entities;
using BLL.Entities.Admin;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web.Hosting;
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

        [AdminAuth]
        [HttpGet]
        [Route("api/admin/user/{uid}")]
        public HttpResponseMessage AllUsers(int uid)
        {
            var data = AdminServices.Get(uid);
            var d = new JavaScriptSerializer().Deserialize<List<UsersListModel>>(data);
            return Request.CreateResponse(HttpStatusCode.OK, d);
        }
        [AdminAuth]
        [HttpGet]
        [Route("api/admin/user/")]
        public HttpResponseMessage Get()
        {
            var data = AdminServices.Get();
            var d = new JavaScriptSerializer().Deserialize<List<UsersListModel>>(data);
            return Request.CreateResponse(HttpStatusCode.OK, d);
        }
        [AdminAuth]
        [HttpGet]
        [Route("api/admin/users/delete/{id}")]
        public HttpResponseMessage DeleteUsers(int id)
        {
            var data = AdminServices.DeleteUser(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [AdminAuth]
        [HttpGet]
        [Route("api/admin/users/block/{id}")]
        public HttpResponseMessage Block(int id)
        {
            var data = AdminServices.BlockUser(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [AdminAuth]
        [HttpGet]
        [Route("api/admin/users/unblock/{id}")]
        public HttpResponseMessage Unblock(int id)
        {
            var data = AdminServices.UnblockUser(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        [AdminAuth]
        [HttpPost]
        [Route("api/admin/UpdateUser")]
        public HttpResponseMessage Update(AddUserModel user)
        {
            var User = new JavaScriptSerializer().Serialize(user);
            var data = AdminServices.UpdateUser(user);
            return Request.CreateResponse(HttpStatusCode.OK, data);
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


        //Create User 



        //public void BuildEmailTemplate(int uid)
        //{
        //    string body = System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/EmailTemplate/") + "Text" + ".cshtml");
        //    var regInfo = dbObj.Users.Where(x => x.uid == uid).FirstOrDefault();
        //    var url = "https://localhost:44343/" + "Register/Confirm?regId=" + uid;
        //    body = body.Replace("@ViewBag.ConfirmationLink", url);
        //    body = body.ToString();
        //    BuildEmailTemplate("Your Account is Successfully Created", body, regInfo.email, uname);
        //}














        [AdminAuth]
        [HttpGet]
        [Route("api/admin/Instructors")]
        public HttpResponseMessage InstructorsList()
        {
            var data = AdminServices.Instructors();
            var d = new JavaScriptSerializer().Deserialize<List<UsersListModel>>(data);
            return Request.CreateResponse(HttpStatusCode.OK, d);
        }
        [AdminAuth]
        [HttpGet]
        [Route("api/admin/moderators")]
        public HttpResponseMessage ModeratorsList()
        {
            var data = AdminServices.Moderators();
            var d = new JavaScriptSerializer().Deserialize<List<UsersListModel>>(data);
            return Request.CreateResponse(HttpStatusCode.OK, d);
        }
        [AdminAuth]
        [HttpGet]
        [Route("api/admin/learners")]
        public HttpResponseMessage LearnersList()
        {
            var data = AdminServices.Learners();
            var d = new JavaScriptSerializer().Deserialize<List<UsersListModel>>(data);
            return Request.CreateResponse(HttpStatusCode.OK, d);
        }
        [AdminAuth]
        [HttpGet]
        [Route("api/admin/admins")]
        public HttpResponseMessage AdminsList()
        {
            var data = AdminServices.Admins();
            var d = new JavaScriptSerializer().Deserialize<List<UsersListModel>>(data);
            return Request.CreateResponse(HttpStatusCode.OK, d);
        }
        [AdminAuth]
        [HttpGet]
        [Route("api/admin/pendingusers")]
        public HttpResponseMessage PendingUser()
        {
            var data = AdminServices.GetPendingUsers();
            var d = new JavaScriptSerializer().Deserialize<List<UsersListModel>>(data);
            return Request.CreateResponse(HttpStatusCode.OK, d);
        }
        [AdminAuth]
        [HttpPost]
        [Route("api/admin/approveuser/{uid}")]
        public HttpResponseMessage ApproveUser(int uid)
        {
            var data = AdminServices.ApproveUser(uid);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //public HttpResponseMessage UserList()
        //{
        //    var st = AdminServices.UserList();
        //    return Request.CreateResponse(HttpStatusCode.OK, st);
        //}
        [AdminAuth]
        [HttpGet]
        [Route("api/admin/recentPost")]
        public HttpResponseMessage RecentPost()
        {
            var data = AdminServices.GetRecentPost();
            var d = new JavaScriptSerializer().Deserialize<List<RecentPostModel>>(data);
            return Request.CreateResponse(HttpStatusCode.OK, d);
        }

        [AdminAuth]
        [HttpGet]
        [Route("api/admin/recentCourses")]
        public HttpResponseMessage RecentCourses()
        {
            var data = AdminServices.GetRecentCourses();
            var d = new JavaScriptSerializer().Deserialize<List<RecentCoursesModel>>(data);
            int n = d.Count();

            List<RecentCoursesModel> LS = new List<RecentCoursesModel>();
            RecentCoursesModel obj = new RecentCoursesModel();
            return Request.CreateResponse(HttpStatusCode.OK, d);
        }



        ///Email Sending .

        [HttpGet]
        [Route("api/GetLastUserName/{uType}/{username}")]
        public HttpResponseMessage UserSerial(string uType,string username)
        {
            var UserSerial = 0;
            var uname = "";
            var user = AdminServices.GetUserByType(uType);
            var count = user.Count();
            if (count == 0)
            {
                string type = uType.Substring(0, 1);
                uname = type + "1";
            }
            else if (count >= 1)
            {
                foreach (var u in user)
                {
                    uname = u.username;
                }
                string type = uname.Substring(0, 1);
                uname = uname.Substring(1, 1);
                UserSerial = Convert.ToInt32(uname);
                UserSerial++;
                uname = Convert.ToString(UserSerial);
                uname = type + uname+"-";
                uname +=username;
            }
            return Request.CreateResponse(HttpStatusCode.OK, uname);
          
        }



        //
      
        [HttpPost]
        [Route("api/AddUser")]
        public HttpResponseMessage Post(AddUserModel user)
        {

           
                var NewUserName = USerial(user.userType, user.username);//user.userType,user.username
                user.username = NewUserName;
                var User = new JavaScriptSerializer().Serialize(user);
                var data = AdminServices.AddUser(User);
                int id = data.uid;
                BuildEmailTemplate(id, data.username, data.email.ToString());
                return Request.CreateResponse(HttpStatusCode.OK, data);
           
            //var NewData = new JavaScriptSerializer().Deserialize(data,AddUserModel);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //
        public string USerial(string uType, string username)
        {
            var UserSerial = 0;
            var uname = "";
            var user = AdminServices.GetUserByType(uType);
            var count = user.Count();
            if (count == 0)
            {
                string type = uType.Substring(0, 1);
                uname = type + "1";
            }
            else if (count >= 1)
            {
                foreach (var u in user)
                {
                    uname = u.username;
                }
                string type = uname.Substring(0, 1);
                uname = uname.Substring(1, 1);
                UserSerial = Convert.ToInt32(uname);
                UserSerial++;
                uname = Convert.ToString(UserSerial);
                uname = type + uname + "-";
                uname += username;
            }
            return uname;
        }



        public void BuildEmailTemplate(int id,string uname,string email)
        {
            string body = "Welcome to Ask & Learn. Your User Name Is : ";
            //string body = System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/EmailTemplate/") + "Text" + ".cshtml");
            //var regInfo = dbObj.Users.Where(x => x.uid == uid).FirstOrDefault();
            //var regInfo = AdminServices.GetUserById(id);

            string Email = AdminServices.GetEmail(id);
            body = body.ToString();
            BuildEmailTemplate("Your Account is Successfully Created", body,email, uname);
        }
        public HttpResponseMessage GetEmail(int uid)
        {
            var regInfo = AdminServices.GetUserById(uid);
            return Request.CreateResponse(HttpStatusCode.OK, regInfo.email);
        }

        public static void BuildEmailTemplate(string subjectText, string bodyText, string email, string uname)
        {
            string from, to, bcc, cc, subject, body;
            from = "hamiduddin09@gmail.com";
            //string Email = AdminServices.GetEmail(id);
            to = email;
            bcc = "";
            cc = "";
            subject = subjectText;
            StringBuilder sb = new StringBuilder();
            sb.Append(bodyText);
            sb.Append(uname);
            body = sb.ToString();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(to));
            if (!string.IsNullOrEmpty(bcc))
            {
                mail.Bcc.Add(new MailAddress(bcc));
            }

            if (!string.IsNullOrEmpty(cc))
            {
                mail.CC.Add(new MailAddress(cc));

            }

            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SendEmail(mail);
        }


        public static void SendEmail(MailMessage mail)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential("hamiduddin09@gmail.com", "Neverstoplearning1998");
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;

            }


        }



        ///




    }
}
