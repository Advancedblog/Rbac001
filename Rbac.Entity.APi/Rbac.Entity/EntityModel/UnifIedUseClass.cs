using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Entity
{
    /// <summary>
    /// 统用 字段
    /// </summary>
    public  class UnifIedUseClass 
    {
        public DateTime AddDateTimeA { get; set; } //添加时间
        public DateTime LastLoginDateTimeA { get; set; } //末次登陆时间
        public string LastLoginIPA { get; set; } //末次登陆IP

    }
}
