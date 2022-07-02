
using Admin.Dto;
using IBaseService;
using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    public interface ILoginService : IBservice<Administrators, RegisterDto>
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        Eroor Register (RegisterDto admin);
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Toenk GetLogin(AdminDto dto);
        AdminQuery admin1(Page page);
        public Tuple<List<AdminQuery>, int> GetPage(int PIndex = 1, int PSizs = 2);
    }
}
