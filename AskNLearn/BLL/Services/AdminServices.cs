using AutoMapper;
using BLL.Entities;
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

        public static UsersModel Get(int id)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UsersModel>());
            var mapper = new Mapper(config);
            var u = AdminDataAccessFactory.GetUser().Get(id);
            var Data = mapper.Map<UsersModel>(u);

            //var data = js.Serialize(u);
            return Data;
        }

        public static List<UsersModel> Get()
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UsersModel>());
            var mapper = new Mapper(config);
            var u = AdminDataAccessFactory.GetUser().Get();
            var Data = mapper.Map<List<UsersModel>>(u);


            return Data;
        }

    }

    
}
