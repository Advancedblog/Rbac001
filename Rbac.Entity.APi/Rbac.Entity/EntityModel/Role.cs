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
     /// 角色类
     /// </summary>
    [Table("Role")]
    public class Role: UnifIedUseClass
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; } //角色名称
       
    }
}
