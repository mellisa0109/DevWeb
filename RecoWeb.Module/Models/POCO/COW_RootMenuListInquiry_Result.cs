using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoWeb.Module.Models.POCO
{
    public class COW_RootMenuListInquiry_Result
    {
        public string ParentMenuCode { get; set; }
        public string MenuCode { get; set; }
        public string MenuName { get; set; }
        public string Description { get; set; }
        public int Sequence { get; set; }
        public string Category { get; set; }
        public string Controller { get; set; }
        public string ActionMethod { get; set; }
        public string Icon { get; set; }
        public string IconValue { get; set; }
        public string IsUse { get; set; }
    }
}
