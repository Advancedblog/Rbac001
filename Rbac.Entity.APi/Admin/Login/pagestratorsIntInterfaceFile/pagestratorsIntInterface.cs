using Admin.Dto;
using AutoMapper;
using IBaseService;
using Rbac.Entity;
using Rbac.IRepository;
using Rbac.MyDbcontextEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Login.pagestratorsIntInterfaceFile  
{
    public class pagestratorsIntInterface : Repository<AdimRoleDto, int>, IpagestratorsIntInterface
    {
       
    }
}
