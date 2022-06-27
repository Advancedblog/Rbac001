using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Iservic
{
    /// <summary>
    /// 菜单 （实现新增）
    /// </summary>
    public class MeunAddDto
    {

        public int Mid { get; set; }
        public int value{get; set; }
        public string label { get; set; }
        public string meunLink { get; set; }

        public List<MeunAddDto> children { get; set; } = new List<MeunAddDto>(); //自包含
    }
}
