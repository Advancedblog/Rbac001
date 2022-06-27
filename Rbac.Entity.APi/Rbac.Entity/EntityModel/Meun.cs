using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Rbac.Entity
{
    /// <summary>
    /// 菜单类
    /// </summary>
    [Table("Meun")]
    public class Meun
    {
        [Key]
        public int Mid { get; set; }
        public string MeunName { get; set; } //菜单名称
        public int MeunFatherId { get; set; } //父ID
        public string MeunLink { get; set; } //菜单链接
        public bool MeunIsck { get; set; }  //判断状态
        
    }
}
