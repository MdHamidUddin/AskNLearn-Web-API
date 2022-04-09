using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DAL.Repos
{
    public class UsersRepo : IAdmin<User, int>
    {
        AskNLearnEntities dbObj;

        public UsersRepo(AskNLearnEntities dbObj)
        {
            this.dbObj = dbObj;
        }
        //public User Get(int uid)
        //{

        //    return dbObj.Users.FirstOrDefault(x => x.uid == uid);
        //}

        public string Get(int uid)
        {
            var data = (from u in dbObj.Users
                        join ui in dbObj.UsersInfoes on u.uid equals ui.uid
                        where (u.uid.Equals(uid))
                        select new { u.uid, u.name, u.username, u.email, u.dob, u.gender, u.userType, u.proPic, u.approval, u.dateTime, ui.eduInfo, ui.currentPosition, ui.reputation }).ToList();

            var data1 = new JavaScriptSerializer().Serialize(data);
            return data1;
        }

        //public List<User> Get()
        //{
        //    return dbObj.Users.ToList();
        //}

        public string Get()
        {
            var data = (from u in dbObj.Users
                        join ui in dbObj.UsersInfoes on u.uid equals ui.uid
                        select new { u.uid, u.name, u.username, u.email, u.dob, u.gender, u.userType, u.proPic, u.approval, u.dateTime, ui.eduInfo, ui.currentPosition, ui.reputation }).ToList();

            var data1 = new JavaScriptSerializer().Serialize(data);
            return data1;
        }

        public string InstructorsList()
        {

            var data = (from u in dbObj.Users
                        join ui in dbObj.UsersInfoes on u.uid equals ui.uid
                        where (u.userType.Equals("Instructor"))
                        select new { u.uid, u.name, u.username, u.email, u.dob, u.gender, u.userType, u.proPic, u.approval, u.dateTime, ui.eduInfo, ui.currentPosition, ui.reputation }).ToList();

            var data1 = new JavaScriptSerializer().Serialize(data);
            return data1;

        }

        public string ModeratorsList()
        {
            var data = (from u in dbObj.Users
                        join ui in dbObj.UsersInfoes on u.uid equals ui.uid
                        where (u.userType.Equals("Moderator"))
                        select new { u.uid, u.name, u.username, u.email, u.dob, u.gender, u.userType, u.proPic, u.approval, u.dateTime, ui.eduInfo, ui.currentPosition, ui.reputation }).ToList();

            var data1 = new JavaScriptSerializer().Serialize(data);
            return data1;
        }

        public string LearnersList()
        {
            var data = (from u in dbObj.Users
                        join ui in dbObj.UsersInfoes on u.uid equals ui.uid
                        where (u.userType.Equals("Learner"))
                        select new { u.uid, u.name, u.username, u.email, u.dob, u.gender, u.userType, u.proPic, u.approval, u.dateTime, ui.eduInfo, ui.currentPosition, ui.reputation }).ToList();

            var data1 = new JavaScriptSerializer().Serialize(data);
            return data1;
        }

        public string AdminsList()
        {
            var data = (from u in dbObj.Users
                        join ui in dbObj.UsersInfoes on u.uid equals ui.uid
                        where (u.userType.Equals("Admin"))
                        select new { u.uid, u.name, u.username, u.email, u.dob, u.gender, u.userType, u.proPic, u.approval, u.dateTime, ui.eduInfo, ui.currentPosition, ui.reputation }).ToList();

            var data1 = new JavaScriptSerializer().Serialize(data);
            return data1;
        }

        public User BlockUser(int id)
        {
            var user = dbObj.Users.Where(x => x.uid.Equals(id)).FirstOrDefault();
            user.approval = "blocked";
            dbObj.SaveChanges();
            return user;
        }

        public User UnBlockUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
