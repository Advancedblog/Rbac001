using System;
using System.Collections.Generic;
using Admin.Dto;
using Rbac.Entity;
using Rbac.IRepository;
using Rbac.MyDbcontextEF;

namespace Admin
{
    //继承 底层Repository泛型仓储
    public class AdministratorsIntInterface : Repository<Administrators, int>, IAdministratorsIntInterface
    {
        private readonly ILoginService loginService;

        public AdministratorsIntInterface(MyDbContext myDb)
        {
            this.db = myDb;
        }

        
    }
}
