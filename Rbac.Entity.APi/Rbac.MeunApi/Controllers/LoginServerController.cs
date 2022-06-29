using Admin;
using Admin.Dto;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rbac.MeunApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginServerController : ControllerBase

    {
        private readonly ILoginService login;

        public LoginServerController(ILoginService login)
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
        /// <summary>
        /// 验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public int GetRandom()
        {
            Random ran = new Random();
            int sum = ran.Next(10000, 99999);

            return sum;
        }

        /// <summary>
        /// 管理 查询
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        //[HttpGet]
        //public AdminQuery admin1([FromQuery] Page page)
        //{
        //    return login.admin1(page);
        //}

    }
}
