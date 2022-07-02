
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Dto
{
    /// <summary>
    /// 注册 
    /// </summary>
    public class RegisterDto 
    {
        public int AdmID { get; set; }
        public string AdmName { get; set; } //管理账号
        public string AdmPwd { get; set; } //管理密码
        public string AdmEmile { get; set; } //管理邮箱
        public DateTime AddDateTimeA { get; set; } //添加时间
        public DateTime LastLoginDateTimeA { get; set; } //末次登陆时间
        public string LastLoginIPA { get; set; } //末次登陆IP
    }
}
