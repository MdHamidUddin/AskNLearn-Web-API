using BLL.Entities;
using BLL.Entities.Instructor;
using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
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
                cm.upVote = 0;
                cm.downVote = 0;
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
            if (cm.ImageFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(cm.ImageFile.FileName);
                string extension = Path.GetExtension(cm.ImageFile.FileName);
                fileName = cm.title+"-" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + fileName + extension;
                fileName = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Instructor/CourseThumbnail/"), fileName);
                cm.thumbnail = fileName;
                cm.ImageFile.SaveAs(fileName);
            }
            Cours cours = new Cours()
            {
                uid = uid,
                title = cm.title,
                details = cm.details,
                price = cm.price,
                thumbnail = cm.thumbnail,
                upVote = 0,
                downVote = 0,
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
        public static bool AddDocuments(DocumentModel d, int coid)
        {
            var videoLink = "";
                if (d.videoLink != null)
                {
                    const string pattern = @"(?:https?:\/\/)?(?:www\.)?(?:(?:(?:youtube.com\/watch\?[^?]*v=|youtu.be\/)([\w\-]+))(?:[^\s?]+)?)";
                    const string replacement = "https://www.youtube.com/embed/$1";
                    var rgx = new Regex(pattern);
                    videoLink = rgx.Replace(d.videoLink, replacement);
                }
                //For image Upload
                if (d.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(d.ImageFile.FileName);
                    string extension = Path.GetExtension(d.ImageFile.FileName);
                    fileName = d.imageTitle + "-" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + extension;
                    fileName = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Instructor/Courses/Images/"), fileName);
                    d.image = fileName;
                    d.ImageFile.SaveAs(fileName);
                }
                //For Documents Upload
                if (d.DocFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(d.DocFile.FileName);
                    string extension = Path.GetExtension(d.DocFile.FileName);
                    fileName = d.docTitle + "-" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + extension;
                    fileName = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Instructor/Courses/Documents/"), fileName);
                    d.docs = fileName;
                    d.DocFile.SaveAs(fileName);
                }
                Document doc = new Document();
                doc.coid = coid;
                doc.videoTitle = d.videoTitle;
                if (!videoLink.Equals(""))
                {
                    doc.videoLink = videoLink;
                }
                doc.imageTitle = d.imageTitle;
                doc.image = d.image;
                doc.docTitle = d.docTitle;
                doc.docs = d.docs;
                if (DataAccessFactory.CourseDocumentDataAccess().Add(doc))
                {
                    return true;
                }
            return false;
        }
        public static List<PostModel> PostList()
        {
            PostModel pm = null;
            List<PostModel> cList = new List<PostModel>();
            var u = DataAccessFactory.PostDataAccess().Get();
            var data = new JavaScriptSerializer().Deserialize<List<PostModel>>(u);
            foreach (var item in data)
            {
                pm = new PostModel();
                pm.pid = item.pid;
                pm.uid = item.uid;
                pm.PostedBy = item.PostedBy;
                pm.title = item.title;
                pm.details = item.details;
                pm.upVote = 0;
                pm.downVote = 0;
                cList.Add(pm);
            }
            return cList;
        }

    }
}
