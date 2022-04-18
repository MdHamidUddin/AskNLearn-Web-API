using DAL.Interface.IUser;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using System.Web.Script.Serialization;

namespace DAL.Repos.UserRepo
{
    public class AddUserRepo : IAddUser<User, int>
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

        public string GetEmail(int id)
        {
            var user = dbObj.Users.FirstOrDefault(x=>x.uid.Equals(id));
            string Email = user.email;
            return Email;
        }

        public string UpdateUser(User x)
        {

            using (AskNLearnEntities db=new AskNLearnEntities())
            {
                var obj = db.Users.Where(p => p.uid.Equals(x.uid)).FirstOrDefault();
                obj.name = x.name;
                obj.username = x.username;
                obj.email = x.email;
                obj.password = x.password;
                obj.dob = x.dob;
                obj.gender = x.gender;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return "Information Updated";
            }
                    
        }
    }
}
