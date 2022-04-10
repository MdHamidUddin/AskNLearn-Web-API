using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Instructor
{
    public class CourseRepo : IRepository<Cours, int>
    {
        AskNLearnEntities db;
        public CourseRepo(AskNLearnEntities db)
        {
            this.db = db;
        }
        public bool Add(Cours obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Cours obj)
        {
            throw new NotImplementedException();
        }

        public Cours Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cours> Get()
        {
            var courses = db.Courses.ToList();
            return courses;
        }
    }
}
