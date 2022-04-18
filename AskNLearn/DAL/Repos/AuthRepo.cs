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
                    CreatedAt = DateTime.Now,
                    ExpiredAt = DateTime.Now.AddMinutes(10)
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
            //DateTime.Compare(t1, t2);
            //Less than zero t1 is earlier than t2.
            //Zero t1 is the same as t2.
            //Greater than zero   t1 is later than t2.
            var tokencheck = db.TokenAccesses.FirstOrDefault(t => t.Token.Equals(token) && DateTime.Compare((DateTime)t.ExpiredAt, DateTime.Now)>0);
            var userType = (from t in db.TokenAccesses
                            join u in db.Users on t.uid equals u.uid
                            where t.Token.Equals(token) && u.approval.Equals("active")
                            select new
                            {
                                u.userType
                            }).ToList();
            var utype = "";
            foreach (var item in userType)
            {
                utype = item.userType.ToString();
            }
            if (tokencheck != null && utype.Equals("Instructor"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsAdminAuthenticated(string token)
        {
            //DateTime.Compare(t1, t2);
            //Less than zero t1 is earlier than t2.
            //Zero t1 is the same as t2.
            //Greater than zero   t1 is later than t2.
            using (AskNLearnEntities db=new AskNLearnEntities())
            {
                var tokencheck = db.TokenAccesses.FirstOrDefault(t => t.Token.Equals(token) && DateTime.Compare((DateTime)t.ExpiredAt, DateTime.Now) > 0);
                var userType = (from t in db.TokenAccesses
                                join u in db.Users on t.uid equals u.uid
                                where t.Token.Equals(token) && u.approval.Equals("active")
                                select new
                                {
                                    u.userType
                                }).ToList();
                var utype = "";
                foreach (var item in userType)
                {
                    utype = item.userType.ToString();
                }
                if (tokencheck != null && utype.Equals("Admin"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
          
        }

        public bool Logout(int id)
        {
            var data = db.TokenAccesses.FirstOrDefault(t => t.uid == id && DateTime.Compare((DateTime)t.CreatedAt, DateTime.Now) < 0 && DateTime.Compare((DateTime)t.ExpiredAt, DateTime.Now) > 0);
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

        public string GetUserType(string username, string password)
        {
            var data = db.Users.FirstOrDefault(x => x.username.Equals(username) && x.password.Equals(password));
            if (data != null)
            {
                return data.userType;
            }
            else
                return "No data";
        }
    }
}
