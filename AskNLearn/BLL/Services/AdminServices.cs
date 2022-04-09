using AutoMapper;
using BLL.Entities;
using BLL.Entities.Admin;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace BLL.Services
{
    public class AdminServices
    {
        
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




    }


}
