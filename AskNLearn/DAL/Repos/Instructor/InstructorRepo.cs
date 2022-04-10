using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Instructor
{
    public class InstructorRepo : IRepository<User, int>
    {
        AskNLearnEntities db;
        public InstructorRepo(AskNLearnEntities db)
        {
            this.db = db;
        }
        public bool Add(User obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(User obj)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }
    }
}
