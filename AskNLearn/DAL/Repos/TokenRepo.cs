using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class TokenRepo : IRepository<TokenAccess, string>
    {
        AskNLearnEntities db;
        public TokenRepo(AskNLearnEntities db)
        {
            this.db = db;
        }
        public bool Add(TokenAccess obj)
        {
            try
            {
                db.TokenAccesses.Add(obj);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                var token = db.TokenAccesses.FirstOrDefault(c => c.Token == id);
                db.TokenAccesses.Remove(token);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(TokenAccess obj)
        {
            try
            {
                var token = db.TokenAccesses.FirstOrDefault(c => c.tid == obj.tid);
                db.Entry(token).CurrentValues.SetValues(obj);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public TokenAccess Get(string id)
        {
            return db.TokenAccesses.FirstOrDefault(t => t.Token == id);
        }

        public List<TokenAccess> Get()
        {
            return db.TokenAccesses.ToList();
        }
    }
}
