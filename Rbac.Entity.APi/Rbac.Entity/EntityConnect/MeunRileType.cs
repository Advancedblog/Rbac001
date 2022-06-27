using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Entity
{
    /// <summary>
    /// 关联 菜单和角色  类
    /// </summary>
    [Table("MeunRileType")]
    public class MeunRileType
    {
        [Key]
        public int MeunRileTypeId { get; set; }
        public int Mid { get; set; } //菜单ID
        public int RoleID { get; set; } //角色ID

        ////导航
        ////菜单
        //[ForeignKey("Mid")]
        //public Meun Meun { get; set; }
        ////角色
        //[ForeignKey("RoleID")]
        //public Role Role { get; set; }
    }
}
