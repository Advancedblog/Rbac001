using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rbac.Entity;
using Rbac.IServicMeunRole;
using Rbac.MyDbcontextEF;

namespace Rbac.ServicMeunRole
{
    public class ServicMeunRole1: IServicMeunRole1
    {

        public ServicMeunRole1(MyDbContext myDbContext)
        {
            dbContext = myDbContext;
        }

        public MyDbContext dbContext { get; }

        public List<Meun> GetMeunQuery()
        {
            var list = dbContext.
        }
    }
}
