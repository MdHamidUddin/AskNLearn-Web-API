using DAL.Interface.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DAL.Repos.Users
{
    public class AddUserInfoRepo : IAddUser<UsersInfo>
    {
        AskNLearnEntities dbObj;

        public AddUserInfoRepo(AskNLearnEntities dbObj)
        {
            this.dbObj = dbObj;
        }
        public string AddUser(UsersInfo x)
        {
            dbObj.UsersInfoes.Add(x);
            dbObj.SaveChanges();
            //var User = new JavaScriptSerializer().Serialize(x);
            return "Use Info Added";
        }
    }
}
