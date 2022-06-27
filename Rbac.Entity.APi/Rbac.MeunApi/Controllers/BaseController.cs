using IBaseService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Rbac.MeunApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController<aa, TCURDDto, TDto> : ControllerBase
        where aa : IBservice<TCURDDto, TDto>
        where TCURDDto : class, new()
        where TDto : class, new()
    {
        private readonly aa service;

        public BaseController(aa service)
        {
            this.service = service;
        }
        [HttpPost]
        public IActionResult GetAdd(TDto dto)
        {
            return Ok(service.GetAdd(dto));
        }
        [HttpGet]
        public IActionResult GetDelete(int id)
        {
            return Ok(service.GetDelete(id));
        }
        [HttpGet]
        public IActionResult GetQuery()
        {
            return new JsonResult(service.GetQuery());
        }
        [HttpPost]
        public IActionResult GetUpdate(TDto dto)
        {
            return Ok(service.GetUpdate(dto));
        }
    }
}
