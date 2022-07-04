using Admin.CURD;
using Admin.Dto;
using Microsoft.AspNetCore.Mvc;
using Rbac.Entity;
using Rbac.Iservic;
using Rbac.servic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rbac.MeunApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServercurdController : ControllerBase
    {
        private readonly Iservic2  iservic;
        private readonly IAdminCURD admin;

        public ServercurdController(Iservic2 iservica, IAdminCURD admin)
        {
            this.iservic = iservica;
            this.admin = admin;
        }

        /// <summary>
        /// 菜单 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public int GetRomre(int id)
        {
            return iservic.GetRomre(id);
        }
        /// <summary>
        /// 管理员 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public bool AdminDelete(int id)
        {
            return admin.AdminDelete(id);
        }

        /// <summary>
        /// 权限添加
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        [HttpPost]
        public  int GetCheckAdd(AdimRoleDto dtos)
        {
            return admin.GetCheckAdd(dtos);
        }


    }
}
