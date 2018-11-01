using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoWeb.Module.Models.POCO
{
    public class COW_PermissionMenuInquiry_Result
    {
        public string MenuCode { get; set; }
        public string Description { get; set; }
        public string IsUse { get; set; }
        public string Sequence { get; set; }
        public string ParentMenuCode { get; set; }
        public string TreeLevel { get; set; }
        public string IsLeaf { get; set; }
        public string Loaded { get; set; }
        public string Expanded { get; set; }

        public string Id { get; set; }
        public string ParentId { get; set; }
        public string _KeyColumn { get; set; }
    }
}
