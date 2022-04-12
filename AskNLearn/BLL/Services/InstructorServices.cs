using BLL.Entities;
using BLL.Entities.Instructor;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using System.Web.Script.Serialization;

namespace BLL.Services
{
    public class InstructorServices
    {
        public static InstructorModel Instructor(int uid)
        {
            InstructorModel im = null;
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
        public static List<CourseModel> PostedCourses(int uid)
        {
            CourseModel cm = null;
            List<CourseModel> cList = new List<CourseModel>();
            var u = DataAccessFactory.CoursDataAccess().Get();
            var data = (from c in u
                        where c.uid == uid
                        select new
                        {
                            c.coid,
                            c.uid,
                            c.title,
                            c.details,
                            c.price,
                            c.thumbnail
                        }).ToList();
            foreach (var item in data)
            {
                cm = new CourseModel();
                cm.coid = item.coid;
                cm.uid = item.uid;
                cm.title = item.title;
                cm.details = item.details;
                cm.price = item.price;
                cm.thumbnail = item.thumbnail;
                cList.Add(cm);
            }
            return cList;
        }
        public static CourseModel GetCourse(int id)
        {
            CourseModel cm = null;
            var u = DataAccessFactory.CoursDataAccess().Get();
            var data = (from c in u
                        where c.coid == id
                        select new
                        {
                            c.coid,
                            c.uid,
                            c.title,
                            c.details,
                            c.price,
                            c.thumbnail
                        }).ToList();
            foreach (var item in data)
            {
                cm = new CourseModel();
                cm.coid = item.coid;
                cm.uid = item.uid;
                cm.title = item.title;
                cm.details = item.details;
                cm.price = item.price;
                cm.thumbnail = item.thumbnail;
            }
            return cm;
        }
        public static bool AddCourse(CourseModel cm, int uid)
        {
            //CourseModel cm = null;
            //var u = DataAccessFactory.CoursDataAccess().Add(cours);
            //join usr in u
            Cours cours = new Cours()
            {
                uid = uid,
                title = cm.title,
                details = cm.details,
                price = cm.price,
                dateTime =DateTime.Now
            };
            if (DataAccessFactory.CoursDataAccess().Add(cours))
            {
                return true;
            }
            return false;
        }
        public static bool DeleteCourse(int coid)
        {
            if (DataAccessFactory.CoursDataAccess().Delete(coid))
            {
                return true;
            }
            return false;
        }
        public static bool EditCourse(CourseModel cm, int coid)
        {
            //CourseModel cm = null;
            //var u = DataAccessFactory.CoursDataAccess().Add(cours);
            //join usr in u
            Cours cours = new Cours()
            {
                coid = coid,
                title = cm.title,
                details = cm.details,
                price = cm.price,
                thumbnail = cm.thumbnail,
                dateTime = DateTime.Now
            };
            if (DataAccessFactory.CoursDataAccess().Edit(cours))
            {
                return true;
            }
            return false;
        }
    }
}
