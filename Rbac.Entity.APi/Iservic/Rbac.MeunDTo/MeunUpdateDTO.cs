using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Iservic
{
    public class MeunUpdateDTO
    {
        public int mid { get; set; }
        public int MeunFatherId { get; set; }
        public string meunLink { get; set; }
        public string meunName { get; set; }
    }
}
