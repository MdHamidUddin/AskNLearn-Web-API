using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
//using HttpSessionState.Clear;


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

        public string Get(int id)
        {
            using (AskNLearnEntities dbObj = new AskNLearnEntities())
            {
                var data = (from u in dbObj.Users
                            join ui in dbObj.UsersInfoes on u.uid equals ui.uid
                            where (u.uid.Equals(id)) || u.approval.Equals("blocked")
                            select new { u.uid, u.name, u.username,u.password, u.email, u.dob, u.gender, u.userType, u.proPic, u.approval, u.dateTime, ui.eduInfo, ui.currentPosition, ui.reputation }).ToList();

                var data1 = new JavaScriptSerializer().Serialize(data);
                return data1;
            }
              
        }

        //public List<User> Get()
        //{
        //    return dbObj.Users.ToList();
        //}

        public string Get()
        {
            var data = (from u in dbObj.Users
                        join ui in dbObj.UsersInfoes on u.uid equals ui.uid
                        orderby u.userType
                        where u.approval.Equals("active") || u.approval.Equals("blocked")
                        select new { u.uid, u.name, u.username, u.email, u.dob,u.password, u.gender, u.userType, u.proPic, u.approval, u.dateTime, ui.eduInfo, ui.currentPosition, ui.reputation }).ToList();

            var data1 = new JavaScriptSerializer().Serialize(data);
            return data1;
        }

        public string InstructorsList()
        {

            var data = (from u in dbObj.Users
                        join ui in dbObj.UsersInfoes on u.uid equals ui.uid
                        where (u.userType.Equals("Instructor") & u.approval.Equals("active")) || u.approval.Equals("blocked")
                        select new { u.uid, u.name, u.username, u.email, u.dob, u.gender, u.userType, u.proPic, u.approval, u.dateTime, ui.eduInfo, ui.currentPosition, ui.reputation }).ToList();

            var data1 = new JavaScriptSerializer().Serialize(data);
            return data1;

        }

        public string ModeratorsList()
        {
            var data = (from u in dbObj.Users
                        join ui in dbObj.UsersInfoes on u.uid equals ui.uid
                        where (u.userType.Equals("Moderator") & u.approval.Equals("active")) || u.approval.Equals("blocked")
                        select new { u.uid, u.name, u.username, u.email, u.dob, u.gender, u.userType, u.proPic, u.approval, u.dateTime, ui.eduInfo, ui.currentPosition, ui.reputation }).ToList();

            var data1 = new JavaScriptSerializer().Serialize(data);
            return data1;
        }

        public string LearnersList()
        {
            var data = (from u in dbObj.Users
                        join ui in dbObj.UsersInfoes on u.uid equals ui.uid
                        where (u.userType.Equals("Learner") & u.approval.Equals("active")) || u.approval.Equals("blocked")
                        select new { u.uid, u.name, u.username, u.email, u.dob, u.gender, u.userType, u.proPic, u.approval, u.dateTime, ui.eduInfo, ui.currentPosition, ui.reputation }).ToList();

            var data1 = new JavaScriptSerializer().Serialize(data);
            return data1;
        }

        public string AdminsList()
        {
            var data = (from u in dbObj.Users
                        join ui in dbObj.UsersInfoes on u.uid equals ui.uid
                        where (u.userType.Equals("Admin") & u.approval.Equals("active")) || u.approval.Equals("blocked")
                        select new { u.uid, u.name, u.username, u.email, u.dob, u.gender, u.userType, u.proPic, u.approval, u.dateTime, ui.eduInfo, ui.currentPosition, ui.reputation }).ToList();

            var data1 = new JavaScriptSerializer().Serialize(data);
            return data1;
        }

        public User BlockUser(int id)
        {
            using (AskNLearnEntities dbObj=new AskNLearnEntities())
            {
                var user = dbObj.Users.Where(x => x.uid.Equals(id)).FirstOrDefault();
                user.approval = "blocked";
                dbObj.SaveChanges();
                return user;
            }
               
        }

        public User UnBlockUser(int id)
        {
            using (AskNLearnEntities dbObj = new AskNLearnEntities())
            {
                var user = dbObj.Users.Where(x => x.uid.Equals(id)).FirstOrDefault();
                user.approval = "active";
                dbObj.SaveChanges();
                return user;
            }

        }

        public string ApproveUser(int id)
        {
            using (AskNLearnEntities db=new AskNLearnEntities())
            {
                var user = db.Users.FirstOrDefault(x => x.uid.Equals(id));
                user.approval = "active";
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return " Approved !";

            }
           
        }

        public List<User> GetUserByType(string type)
        {
            var user = dbObj.Users.Where(x => x.userType.Equals(type)).ToList();
            //var data1 = new JavaScriptSerializer().Serialize(user);
            return user;
        }

        public User GetUserById(int uid)
        {
            var user = dbObj.Users.Where(x => x.uid.Equals(uid)).FirstOrDefault();
            return user;
        }

        public string PendingList()
        {
            var data = (from u in dbObj.Users
                        join ui in dbObj.UsersInfoes on u.uid equals ui.uid
                        where ( u.approval.Equals("pending"))
                        select new { u.uid, u.name, u.username, u.email, u.dob, u.gender, u.userType, u.proPic, u.approval, u.dateTime, ui.eduInfo, ui.currentPosition, ui.reputation }).ToList();

            var data1 = new JavaScriptSerializer().Serialize(data);
            return data1;
        }
    }
}
