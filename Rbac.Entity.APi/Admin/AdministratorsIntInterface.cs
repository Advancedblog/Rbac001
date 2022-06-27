using System;
using Rbac.Entity;
using Rbac.IRepository;
using Rbac.MyDbcontextEF;

namespace Admin
{
    //继承 底层Repository泛型仓储
    public class AdministratorsIntInterface : Repository<Administrators, int>, IAdministratorsIntInterface
    {
        public AdministratorsIntInterface(MyDbContext myDb)
        {
            this.db = myDb;
        }
    }
}
