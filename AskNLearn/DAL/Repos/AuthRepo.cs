using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DAL.Repos
{
    public class AuthRepo : IAuth
    {
        AskNLearnEntities db;
        public AuthRepo(AskNLearnEntities db)
        {
            this.db = db;
        }

        public TokenAccess Authenticate(string username, string password)
        {
            TokenAccess t = null;
            var authcheck = db.Users.FirstOrDefault(u => u.username == username && u.password == password);
            if(authcheck != null)
            {
                //var r = new Random();
                var g = Guid.NewGuid();
                var token = g.ToString();
                t = new TokenAccess()
                {
                    uid = authcheck.uid,
                    Token = token,
                    CreatedAt = DateTime.Now
                };
                db.TokenAccesses.Add(t);
                db.SaveChanges();
                return t;
            }
            else
            {
                return null;
            }
        }

        public bool IsAuthenticated(string token)
        {
            var tokencheck = db.TokenAccesses.FirstOrDefault(t => t.Token.Equals(token) && t.ExpiredAt == null);
            if (tokencheck != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Logout(int id)
        {
            var data = db.TokenAccesses.FirstOrDefault(t => t.uid == id && t.ExpiredAt == null);
            if (data != null)
            {
                data.ExpiredAt = DateTime.Now;
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
