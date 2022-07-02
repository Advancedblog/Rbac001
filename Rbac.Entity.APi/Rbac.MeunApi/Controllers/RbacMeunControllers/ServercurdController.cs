using Microsoft.AspNetCore.Mvc;
using Rbac.Entity;
using Rbac.Iservic;
using Rbac.servic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rbac.MeunApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServercurdController : ControllerBase
    {
        private readonly Iservic2  iservic;

        public ServercurdController(Iservic2 iservica)
        {
            this.iservic = iservica;
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
       
    }
}
