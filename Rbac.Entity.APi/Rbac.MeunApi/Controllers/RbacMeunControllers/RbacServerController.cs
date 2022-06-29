using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rbac.Entity;
using Rbac.Iservic;
using System.Collections.Generic;

namespace Rbac.MeunApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class RbacServerController : ControllerBase
    {
        public RbacServerController(Iservic2 servicMeunRole)
        {
            ServicMeunRole = servicMeunRole;
        }

        public Iservic2 ServicMeunRole { get; }

        /// <summary>
        /// 菜单查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous] //特性 该特性用于标记在授权期间要跳过
        public List<MeunDTo> GetAll()
        {
            return ServicMeunRole.GetAll();
        }

        /// <summary>
        /// 添加 下拉框查询
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<MeunAddDto> AddDtos()
        {
            return ServicMeunRole.AddDtos();
        }
        /// <summary>
        /// 添加 菜单
        /// </summary>
        /// <param name="meun"></param>
        /// <returns></returns>
        [HttpPost]
        public bool GetMeunAdd(MeunAddDto meun)
        {
            return ServicMeunRole.GetMeunAdd(meun);
        }
        /// <summary>
        /// 编辑 菜单数据
        /// </summary>
        /// <param name="updDto"></param>
        /// <returns></returns>
        [HttpPut]
        public bool GetMeunUpdate(MeunAddDto updDto)
        {
            return ServicMeunRole.GetMeunUpdate(updDto);
        }

        /// <summary>
        /// 动态下拉框
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public List<Meun> GetMeunList()
        {
            return ServicMeunRole.GetMeunList();
        }

    }
}
