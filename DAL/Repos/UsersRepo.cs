using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class UsersRepo : IAdmin<User,int>
    {
        AskNLearnEntities dbObj;

        public UsersRepo(AskNLearnEntities dbObj)
        {
            this.dbObj = dbObj;
        }
        public User Get(int uid)
        {
            return dbObj.Users.FirstOrDefault(x => x.uid == uid);
        }

        public List<User> Get()
        {
            return dbObj.Users.ToList();
        }
    }
}
