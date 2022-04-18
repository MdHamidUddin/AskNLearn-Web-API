using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Instructor
{
    public class DocumentRepo : IRepository<Document, int>
    {
        AskNLearnEntities db;
        public DocumentRepo(AskNLearnEntities db)
        {
            this.db = db;
        }
        public bool Add(Document obj)
        {
            try
            {
                db.Documents.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Document obj)
        {
            throw new NotImplementedException();
        }

        public Document Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Document> Get()
        {
            throw new NotImplementedException();
        }
    }
}
