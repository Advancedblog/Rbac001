using Rbac.Entity;
using Rbac.IRepository;
using System;

namespace Admin
{
    public interface IAdministratorsIntInterface : IRepository<Administrators,int>
    {
    }
}
