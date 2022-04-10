using BLL.Entities;
using BLL.Entities.Instructor;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace BLL.Services
{
    public class InstructorServices
    {
        public static CourseModel PostedCourses(int uid)
        {
            CourseModel cm = null; ;
            var u = DataAccessFactory.CoursDataAccess().Get();
            var data = (from c in u
                        where c.uid == uid
                        select new
                        {
                            c.uid,
                            c.title,
                            c.details,
                            c.price,
                            c.thumbnail
                        }).ToList();
            foreach (var item in data)
            {
                cm = new CourseModel();
                cm.uid = item.uid;
                cm.title = item.title;
                cm.details = item.details;
                cm.price = item.price;
                cm.thumbnail = item.thumbnail;
            }
            return cm;
        }
        public static InstructorModel Instructor(int uid)
        {
            InstructorModel im = null; ;
            var u = DataAccessFactory.InstructorDataAccess().Get();
            var data = (from i in u
                        where i.uid == uid
                        select new
                        {
                            i.uid,
                            i.name,
                            i.username,
                            i.email,
                            i.password,
                            i.dob,
                            i.gender,
                            i.proPic,
                            i.userType,
                            i.approval
                        }).ToList();
            foreach (var item in data)
            {
                im = new InstructorModel();
                im.uid = item.uid;
                im.name = item.name;
                im.username = item.username;
                im.email = item.email;
                im.password = item.password;
                im.dob = item.dob;
                im.gender = item.gender;
                im.proPic = item.proPic;
                im.userType = item.userType;
                im.approval = item.approval;
            }
            return im;
        }
        public static bool IsInRoleInstructor(int uid)
        {
            var u = DataAccessFactory.InstructorDataAccess().Get();
            var userType = "";
            var data = (from i in u
                        where i.uid == uid && i.approval == "active"
                        select new
                        {
                            i.userType
                        }).ToList();
            foreach (var item in data)
            {
                userType = item.userType;
            }
            if (userType.Equals("Instructor"))
            {
                return true;
            }
            return false;
        }
    }
}
