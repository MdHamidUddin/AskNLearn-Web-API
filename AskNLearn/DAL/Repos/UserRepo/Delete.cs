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
         
            using(AskNLearnEntities db=new AskNLearnEntities())
            {
                var ui = db.UsersInfoes.Where(x => x.uid.Equals(id)).FirstOrDefault();
                var u = db.Users.Where(x => x.uid.Equals(id)).FirstOrDefault();
                if (ui != null)
                {
                    db.UsersInfoes.Remove(ui);
                    db.SaveChanges();
                }
                if (u != null)
                {
                    db.Users.Remove(u);
                    db.SaveChanges();
                    return "User Removed!!!";
                }
            }
          
          
            return "There is some problem !!";
        }
    }
}
