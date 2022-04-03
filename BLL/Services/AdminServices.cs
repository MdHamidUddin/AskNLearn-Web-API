using AutoMapper;
using BLL.Entities;
using DAL;
using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BLL.Services
{
   public class AdminServices
    {
        public static UsersModel Get(int id)
        {
          
            var u = AdminDataAccessFactory.GetUser().Get(id);
            return new UsersModel()
            {
                uid = u.uid,
                name = u.name,
                username = u.username,
                password = u.password,
                email = u.email,
                approval = u.approval,
                dob = u.dob,
                gender = u.gender,
                userType = u.userType,
                proPic = u.proPic,
                dateTime = u.dateTime
            };
        }

    }
}
