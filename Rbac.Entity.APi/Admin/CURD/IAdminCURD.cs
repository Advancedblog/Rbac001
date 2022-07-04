using Admin.Dto;
using Rbac.Entity;
using Rbac.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.CURD
{
    public interface IAdminCURD : IRepository<AdimRoleDto, int>
    {
        bool AdminDelete(int id);
        int GetCheckAdd(AdimRoleDto dtos);
    }
}
