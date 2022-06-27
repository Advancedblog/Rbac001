using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.IServicMeunRole
{
    public interface IServicMeunRole1
    {
        //bool GetRoleMeunAdd(Role obj); //添加角色

        List<Meun> GetMeunQuery();

    }
}
