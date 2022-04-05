using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IAdmin<X, ID>
    {
        X Get(ID uid);
        List<X> Get();
    }
}
