using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoWeb.Module.Models.POCO
{
    public class COW_NavMenuAuthorizeInquiry_Result
    {
        public string UserId { get; set; }
        public string MenuCode { get; set; }
        public int AuthRead { get; set; }
        public int AuthCreate { get; set; }
        public int AuthUpdate { get; set; }
        public int AuthDelete { get; set; }
    }
}
