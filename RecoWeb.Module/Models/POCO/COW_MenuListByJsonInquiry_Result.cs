using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoWeb.Module.Models.POCO
{
    public class COW_MenuListByJsonInquiry_Result
    {
        public string MenuCode { get; set; }
        public string ParentMenuCode { get; set; }
        public string Description { get; set; }
        public string Controller { get; set; }
        public string ActionMethod { get; set; }
        public string Icon { get; set; }
    }
}
