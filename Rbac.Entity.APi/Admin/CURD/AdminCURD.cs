using Admin.Dto;
using Admin.Login.pagestratorsIntInterfaceFile;
using AutoMapper;
using Rbac.Entity;
using Rbac.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.CURD
{
    public class AdminCURD : Repository<RegisterDto, int>, IAdminCURD
    {
        private readonly IpagestratorsIntInterface ipagestratorsInt;
        private readonly IMapper mapper;

        public AdminCURD(IpagestratorsIntInterface ipagestratorsInt,IMapper mapper)
        {
            this.ipagestratorsInt = ipagestratorsInt;
            this.mapper = mapper;
        }

        public bool AdminDelete(int id)
        {
           int a = Convert.ToInt32( mapper.Map<RegisterDto>(id));
            return ipagestratorsInt.GetDelete(a);
        }
    }
}
