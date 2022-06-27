using Admin;
using Admin.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rbac.MeunApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginServerController : ControllerBase/*<ILoginService, AdminDto, RegisterDto>*/

    {
        private readonly ILoginService login;

        public LoginServerController(ILoginService login)/*:base(login)*/
        {
            this.login = login;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetLogin(AdminDto dto)
        {
            return Ok(login.GetLogin(dto));
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        [HttpPost]
        public Eroor Register(RegisterDto admin)
        {
            return login.Register(admin);
        }
    }
}
