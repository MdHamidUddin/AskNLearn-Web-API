using DAL.Interface.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using System.Web.Script.Serialization;

namespace DAL.Repos.Users
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
    }
}
