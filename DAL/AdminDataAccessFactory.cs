using DAL.Database;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AdminDataAccessFactory
    {
        static AskNLearnEntities dbObj = new AskNLearnEntities();

        public static IAdmin<User,int> GetUser()
        {
            return new UsersRepo(dbObj);
        }
    }
}
