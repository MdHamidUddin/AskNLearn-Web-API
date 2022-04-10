using DAL.Repos.IUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.UserRepo
{
    public class Delete : IDeleteUser<User>
    {
        AskNLearnEntities dbObj;

        public Delete(AskNLearnEntities dbObj)
        {
            this.dbObj = dbObj;
        }
        public string DeleteUser(int id)
        {
            var ui = dbObj.UsersInfoes.Where(x=>x.uid.Equals(id)).FirstOrDefault();
            var u = dbObj.Users.Where(x => x.uid.Equals(id)).FirstOrDefault();
            dbObj.UsersInfoes.Remove(ui);
            dbObj.SaveChanges();

            dbObj.Users.Remove(u);
            dbObj.SaveChanges();

            return "User Removed!!!";
        }
    }
}
