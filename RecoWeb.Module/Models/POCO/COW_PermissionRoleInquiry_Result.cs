using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoWeb.Module.Models.POCO
{
    public class COW_PermissionRoleInquiry_Result
    {
        public string RoleId { get; set; }
        public string MenuCode { get; set; }
        public string RoleName { get; set; }
        public string AuthCreate { get; set; }
        public string AuthRead { get; set; }
        public string AuthUpdate { get; set; }
        public string AuthDelete { get; set; }
    }
}
