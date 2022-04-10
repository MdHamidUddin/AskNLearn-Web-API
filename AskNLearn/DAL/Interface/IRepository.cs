using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRepository<X, ID>
    {
        bool Add(X obj);
        bool Edit(X obj);
        X Get(ID id);
        List<X> Get();
        bool Delete(ID id);
    }
}
