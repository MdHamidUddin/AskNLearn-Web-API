using DAL.Interface.IUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DAL.Repos.UserRepo
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

        public string UpdateUser(UsersInfo x)
        {
            var ui = dbObj.UsersInfoes.Where(q => q.uid.Equals(x.uid)).FirstOrDefault();

            ui.eduInfo = x.eduInfo;
            ui.currentPosition = x.currentPosition;
            ui.reputation = x.reputation;
            dbObj.SaveChanges();

            return "Information Updated";
        }
    }
}
