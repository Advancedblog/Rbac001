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
    /// 角色  和 管理员 关系 类
    /// </summary>
    [Table("RoleAdminisrationType")]
    public class RoleAdminisrationType
    {
        [Key]
        public int RoleAdminisID { get; set; }
        public int RoleID { get; set; } //角色
        public int AdmID { get; set; } //管理员
    }
}
