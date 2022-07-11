using Admin.Dto;
using Rbac.Entity;
using Rbac.IRepository;
using System;
using System.Collections.Generic;

namespace Admin
{
    public interface IAdministratorsIntInterface : IRepository<Administrators, int>
    {
    }
}
