
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Iservic
{
    /// <summary>
    /// 菜单 （实现菜单列表查询）
    /// </summary>
    public class MeunDTo
    {
        public int Mid { get; set; }
        public string MeunName { get; set; } //菜单名称
        public int MeunFatherId { get; set; } //父ID
        public string MeunLink { get; set; } //菜单链接
        public bool MeunIsck { get; set; }  //判断状态

        public List<MeunDTo> children { get; set; } = new List<MeunDTo>(); //自包含
    }
}
