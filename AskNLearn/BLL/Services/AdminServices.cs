using AutoMapper;
using BLL.Entities;
using BLL.Entities.Admin;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace BLL.Services
{
    public class AdminServices
    {
        AskNLearnEntities dbObj = new AskNLearnEntities();
        //public static UsersModel Get(int id)
        //{
        //    JavaScriptSerializer js = new JavaScriptSerializer();

        //    var u = AdminDataAccessFactory.GetUser().Get(id);
        //    return new UsersModel()
        //    {
        //        uid = u.uid,
        //        name = u.name,
        //        username = u.username,
        //        password = u.password,
        //        email = u.email,
        //        approval = u.approval,
        //        dob = u.dob,
        //        gender = u.gender,
        //        userType = u.userType,
        //        proPic = u.proPic,
        //        dateTime = u.dateTime
        //    };
        //}

        //public static UsersModel Get(int id)
        //{

        //    var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UsersModel>());
        //    var mapper = new Mapper(config);
        //    var u = AdminDataAccessFactory.GetUser().Get(id);
        //    var Data = mapper.Map<UsersModel>(u);

        //    //var data = js.Serialize(u);
        //    return Data;
        //}

        public static string Get(int uid)
        {
            var u = AdminDataAccessFactory.GetUser().Get(uid);
            return u;
        }
        public static string Get()
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UsersModel>());
            var mapper = new Mapper(config);
            var u = AdminDataAccessFactory.GetUser().Get();
            //var Data = mapper.Map<List<UsersModel>>(u);
            //var s = new JavaScriptSerializer.serialize(u);
            return u;
        }

        //public static List<UsersModel> InstructorList()
        //{

        //    var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UsersModel>());
        //    var mapper = new Mapper(config);
        //    var u = AdminDataAccessFactory.GetIInfo().GetInstructor();
        //    var Data = mapper.Map<List<UsersModel>>(u);
        //    return Data;
        //}

        //public static List<UsersInfoModel> InstructorInfoList()
        //{

        //    var config = new MapperConfiguration(cfg => cfg.CreateMap<UsersInfo, UsersInfoModel>());
        //    var mapper = new Mapper(config);
        //    var u = AdminDataAccessFactory.GetIInfo().GetInstructorInfo();
        //    var Data = mapper.Map<List<UsersInfoModel>>(u);
        //    return Data;
        //}

        //public static List<UsersListModel> AllInstructor()
        //{
        //    UsersListModel obj = new UsersListModel();

        //    List<UsersListModel> List = new List<UsersListModel>();

        //    var config = new MapperConfiguration(cfg => cfg.CreateMap<UsersInfo, UsersInfoModel>());
        //    var mapper = new Mapper(config);
        //    //var Data = mapper.Map<List<UsersInfoModel>>(u);

        //    var v = AdminDataAccessFactory.GetIInfo().GetInstructorInfo();
        //    var u = AdminDataAccessFactory.GetIInfo().GetInstructor();

        //    int count = v.Count();

        //    for (int i = 0; i < count; i++)
        //    {
        //        obj.name = u[i].name;
        //        obj.username = u[i].username;
        //        obj.email = u[i].email;
        //        obj.dob = u[i].dob;
        //        obj.gender = u[i].gender;
        //        obj.userType = u[i].userType;
        //        obj.proPic = u[i].proPic;
        //        obj.approval = u[i].approval;
        //        obj.dateTime = u[i].dateTime;

        //        obj.eduInfo = v[i].eduInfo;
        //        obj.currentPosition = v[i].currentPosition;
        //        obj.reputation = v[i].reputation;
        //        List.Add(obj);
        //    }

        //    return List;
        //}



        
        public static string Instructors()
        {
            var u = AdminDataAccessFactory.GetUser().InstructorsList();
            return u;
        }

        public static string Moderators()
        {
            var u = AdminDataAccessFactory.GetUser().ModeratorsList();
            return u;
        }

        public static string Learners()
        {
            var u = AdminDataAccessFactory.GetUser().LearnersList();
            return u;
        }

        public static string Admins()
        {
            var u = AdminDataAccessFactory.GetUser().AdminsList();
            return u;
        }

        public static string GetRecentPost()
        {
            var p = AdminDataAccessFactory.GetRecentPost().Posts();
            return p;
        }

        public static string GetRecentCourses()
        {
            var p = AdminDataAccessFactory.GetRecentCourses().RecentCourses();
            return p;
        }

        public static string DeleteUser(int id)
        {
            var data = AdminDataAccessFactory.DeleteUser().DeleteUser(id);
            return data;
        }
        public static string UpdateUser(string U)
        {

            var d = new JavaScriptSerializer().Deserialize<AddUserModel>(U);
            User u = new User();
            UsersInfo ui = new UsersInfo();
            DateTime localDate = DateTime.Now;

            u.name = d.name;
            u.username = d.username;
            u.email = d.username;
            u.password = d.password;
            u.dob = d.dob;
            u.gender = d.gender;
            u.userType = d.userType;
            u.proPic = d.proPic;
            u.approval = d.approval;
            u.dateTime = localDate;


            var UU = AdminDataAccessFactory.AddUser().UpdateUser(u);
            //var NewUser = new JavaScriptSerializer().Deserialize<User>(UU);

            //ui.uid = NewUser.uid;
            ui.eduInfo = d.eduInfo;
            ui.currentPosition = d.currentPosition;
            ui.reputation = d.reputation;

            var AddUI = AdminDataAccessFactory.AddUserInfo().UpdateUser(ui);
            return "Updated Success";

        }

        public static string AddUser(string U)
        {
            var d = new JavaScriptSerializer().Deserialize<AddUserModel>(U);
            User u = new User();
            UsersInfo ui = new UsersInfo();
            DateTime localDate = DateTime.Now;

            u.name = d.name;
            u.username = d.username;
                u.email = d.username;
                u.password = d.password;
                u.dob = d.dob;
                u.gender = d.gender;
                u.userType = d.userType;
                u.proPic = d.proPic;
                u.approval = d.approval;
                 u.dateTime = localDate;


                var AddU = AdminDataAccessFactory.AddUser().AddUser(u);
                var NewUser= new JavaScriptSerializer().Deserialize<User>(AddU);

            ui.uid = NewUser.uid;
            ui.eduInfo = d.eduInfo;
            ui.currentPosition = d.currentPosition;
            ui.reputation = d.reputation;

            var AddUI = AdminDataAccessFactory.AddUserInfo().AddUser(ui);

            //var UI = AddU + AddUI;
            //var UserAdded = new JavaScriptSerializer().Deserialize<AddUserModel>(UI);

            return "User Added \n";
            
        }

        //string UserSerial(string uType)
        //{
        //    var UserSerial = 0;
        //    var uname = "";
        //    var user = dbObj.Users.Where(x => x.userType.Equals(uType)).ToList();
        //    var count = dbObj.Users.Where(x => x.userType.Equals(uType)).Count();
        //    if (count == 0)
        //    {
        //        string type = uType.Substring(0, 1);
        //        uname = type + "1";
        //    }
        //    else if (count >= 1)
        //    {
        //        foreach (var u in user)
        //        {
        //            uname = u.username;
        //        }
        //        string type = uname.Substring(0, 1);
        //        uname = uname.Substring(1, 1);
        //        UserSerial = Convert.ToInt32(uname);
        //        UserSerial++;
        //        uname = Convert.ToString(UserSerial);
        //        uname = type + uname;
        //    }
        //    return uname;
        //}

        //public void BuildEmailTemplate(int uid)
        //{
        //    string body = System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/EmailTemplate/") + "Text" + ".cshtml");
        //    var regInfo = dbObj.Users.Where(x => x.uid == uid).FirstOrDefault();
        //    var url = "https://localhost:44343/" + "Register/Confirm?regId=" + uid;
        //    body = body.Replace("@ViewBag.ConfirmationLink", url);
        //    body = body.ToString();
        //    BuildEmailTemplate("Your Account is Successfully Created", body, regInfo.email, uname);
        //}

        public static void BuildEmailTemplate(string subjectText, string bodyText, string sendTo, string uname)
        {
            string from, to, bcc, cc, subject, body;
            from = "hamiduddin09@gmail.com";
            to = sendTo.Trim();
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




    }


}
