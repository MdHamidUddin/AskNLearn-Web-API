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
        public static UsersModel GetUserById(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UsersModel>());
            var mapper = new Mapper(config);
            var u = AdminDataAccessFactory.GetUser().GetUserById(id);
            var Data = mapper.Map<UsersModel>(u);
            return Data;
        }

        public static string GetEmail(int id)
        {
            var Email = AdminDataAccessFactory.AddUser().GetEmail(id);
            return Email;
        }

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
        public static string GetPendingUsers()
        {
            var p = AdminDataAccessFactory.GetUser().PendingList();
            return p;
        }
        public static string ApproveUser(int uid)
        {
            var p = AdminDataAccessFactory.GetUser().ApproveUser(uid);
            return p;
        }

        public static string BlockUser(int uid)
        {
            var p = AdminDataAccessFactory.GetUser().BlockUser(uid);
            if (p!=null)
            {
                return "User Blocked";
            }
            return "Cant Block User";
        }

        public static string UnblockUser(int uid)
        {
            var p = AdminDataAccessFactory.GetUser().UnBlockUser(uid);
            if (p != null)
            {
                return "User Unblocked";
            }
            return "Cant Unblock User";
        }



        public static string DeleteUser(int id)
        {
            var data = AdminDataAccessFactory.DeleteUser().DeleteUser(id);
            return data;
        }
        public static string UpdateUser(AddUserModel d)
        {

            //var d = new JavaScriptSerializer().Deserialize<AddUserModel>(U);
            User u = new User();
            UsersInfo ui = new UsersInfo();
            DateTime localDate = DateTime.Now;

            u.uid = d.uid;
            u.name = d.name;
            u.username = d.username;
            u.email = d.email;
            u.password = d.password;
            u.dob = d.dob;
            u.gender = d.gender;
            u.userType = d.userType;
            u.dateTime = localDate;


            var UU = AdminDataAccessFactory.AddUser().UpdateUser(u);
            //var NewUser = new JavaScriptSerializer().Deserialize<User>(UU);

            ui.uid = d.uid;
            ui.eduInfo = d.eduInfo;
            ui.currentPosition = d.currentPosition;

            var AddUI = AdminDataAccessFactory.AddUserInfo().UpdateUser(ui);
            return "Updated Success";

        }

        public static UsersModel AddUser(string U)
        {
            var d = new JavaScriptSerializer().Deserialize<AddUserModel>(U);
            User u = new User();
            UsersInfo ui = new UsersInfo();
            DateTime localDate = DateTime.Now;

            u.name = d.name;
            u.username = d.username;
            u.email = d.email;
            u.password = d.password;
            u.dob = d.dob;
            u.gender = d.gender;
            u.userType = d.userType;
            //u.proPic = d.proPic;
            u.approval = "pending";
            u.dateTime = localDate;


                var AddU = AdminDataAccessFactory.AddUser().AddUser(u);
                var NewUser= new JavaScriptSerializer().Deserialize<User>(AddU);

            //Here i have to map user 
            //
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UsersModel>());
            var mapper = new Mapper(config);
            
            var Data = mapper.Map<UsersModel>(NewUser);

            //

            ui.uid = NewUser.uid;
            ui.eduInfo = d.eduInfo;
            ui.currentPosition = d.currentPosition;
            //ui.reputation = d.reputation;

            var AddUI = AdminDataAccessFactory.AddUserInfo().AddUser(ui);

            //var UI = AddU + AddUI;
            //var UserAdded = new JavaScriptSerializer().Deserialize<AddUserModel>(UI);

            return Data;
            
        }

       public static List<UsersModel> GetUserByType(string UType)
        {
            //var data1 = new JavaScriptSerializer().Serialize(u);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UsersModel>());
            var mapper = new Mapper(config);
            var u = AdminDataAccessFactory.GetUByType().GetUserByType(UType);
            var Data = mapper.Map<List<UsersModel>>(u);
            return Data;

        }

      

       




    }


}
