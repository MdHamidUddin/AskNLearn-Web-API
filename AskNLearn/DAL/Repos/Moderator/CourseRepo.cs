using DAL.Interface.Moderator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DAL.Repos.Moderator
{
    public class CourseRepo : IModerator<Cours, int>
    {
        AskNLearnEntities dbObj;
        public CourseRepo(AskNLearnEntities dbObj)
        {
            this.dbObj = dbObj;
        }

        public string AddComment(Cours x)
        {
            throw new NotImplementedException();
        }

        public string AddPost(Cours x)
        {
            throw new NotImplementedException();
        }

        public string Courselist()
        {
            var data = (from u in dbObj.Users
                        join ui in dbObj.Courses on u.uid equals ui.uid
                        where (u.uid.Equals(ui.uid))
                        select new { u.uid, u.name, u.username, u.email, ui.title, ui.details, ui.coid, ui.price, ui.thumbnail, ui.upVote, ui.downVote }).ToList();

            var data1 = new JavaScriptSerializer().Serialize(data);
            return data1;
        }

        public string CourseList()
        {
            throw new NotImplementedException();
        }

        public string DeletePost(int id)
        {
            throw new NotImplementedException();
        }

        public string Get(int uid)
        {
            throw new NotImplementedException();
        }

        public string Get()
        {
            throw new NotImplementedException();
        }

        public string InstructorsList()
        {
            throw new NotImplementedException();
        }

        public string LearnersList()
        {
            var data = (from u in dbObj.Users
                        join ui in dbObj.UsersInfoes on u.uid equals ui.uid
                        where (u.userType.Equals("Learner"))
                        select new { u.uid, u.name, u.email, u.dob, u.gender, u.userType, u.approval, u.dateTime, ui.eduInfo, ui.currentPosition, ui.reputation }).ToList();

            var data1 = new JavaScriptSerializer().Serialize(data);
            return data1;
        }

        public string LearnersList(int id)
        {
            var data = (from u in dbObj.Users
                        join ui in dbObj.UsersInfoes on u.uid equals ui.uid
                        where (u.uid.Equals(id) & u.userType.Equals("Learner")) 
                        select new { u.uid, u.name, u.email, u.dob, u.gender, u.userType, u.approval, u.dateTime, ui.eduInfo, ui.currentPosition, ui.reputation }).ToList();

            var data1 = new JavaScriptSerializer().Serialize(data);
            return data1;
        }

        public string ModeratorsList()
        {
            throw new NotImplementedException();
        }

        public string PostList()
        {
            throw new NotImplementedException();
        }

        public string UpdateComment(Cours x)
        {
            throw new NotImplementedException();
        }

        public string UpdatePost(Cours x)
        {
            throw new NotImplementedException();
        }
    }
}
