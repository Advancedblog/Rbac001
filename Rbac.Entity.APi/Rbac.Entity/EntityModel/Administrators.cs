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
    /// 管理员 类
    /// </summary>
    [Table("Administrators")]
    public class Administrators: UnifIedUseClass
    {
        [Key]
        public int AdmID { get; set; }
        public string AdmName { get; set; } //管理账号
        public string AdmPwd { get; set; } //管理密码
        public string AdmEmile { get; set; } //管理邮箱
    }
}
