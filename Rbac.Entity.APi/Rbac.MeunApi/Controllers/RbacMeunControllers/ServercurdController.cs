using Microsoft.AspNetCore.Mvc;
using Rbac.servic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rbac.MeunApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServercurdController : ControllerBase
    {
        private readonly IMIservic mIservic;

        public ServercurdController(IMIservic mIservic)
        {
            this.mIservic = mIservic;
        }

        /// <summary>
        /// 菜单 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public bool GetRomre(int id)
        {
            return mIservic.GetRomre(id);
        }
       
    }
}
