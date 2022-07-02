using Admin.Dto;
using IBaseService;
using Rbac.Entity;
using Rbac.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Login.pagestratorsIntInterfaceFile
{
    public interface IpagestratorsIntInterface : IRepository<AdminQuery, int>
    {
    }
}
