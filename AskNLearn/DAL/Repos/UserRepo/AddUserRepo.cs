using DAL.Interface.IUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using System.Web.Script.Serialization;

namespace DAL.Repos.UserRepo
{
    public class AddUserRepo : IAddUser<User>
    {
        AskNLearnEntities dbObj;
        public AddUserRepo(AskNLearnEntities dbObj)
        {
            this.dbObj = dbObj;
        }
        public string AddUser(User u)
        {
            dbObj.Users.Add(u);
            dbObj.SaveChanges();
            var User = new JavaScriptSerializer().Serialize(u);
            return User;
           
        }

        public string UpdateUser(User x)
        {
            var Use = dbObj.Users.Where(p=>p.email.Equals(x.email)).FirstOrDefault();
            var ui = dbObj.UsersInfoes.Where(q=>q.uid.Equals(x.uid)).FirstOrDefault();

            Use.name = x.name;
            Use.username = Use.username ;
            Use.password = x.password;
            Use.email = x.email;
            Use.dob = x.dob;
            Use.gender = x.gender;
            Use.proPic = x.proPic;
            Use.approval = x.approval;
            Use.dateTime = x.dateTime;

            dbObj.SaveChanges();

            return "Information Updated";        
        }
    }
}
