using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Dto
{
    public  class AdminQuery : RegisterDto
    {
        public int PToTa { get; set; }
        public List<AdminQuery> admins { get; set; }
    }
}
