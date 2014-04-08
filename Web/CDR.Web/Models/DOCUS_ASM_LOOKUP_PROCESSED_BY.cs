using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CDR.Web.Api;

using CDR.Web.Models;

namespace CDR.Web.Models
{
    public class DOCUS_ASM_LOOKUP_PROCESSED_BY
    {
         private IApiRepository<DOCUS_ASM_LOOKUP_PROCESSED_BY> apiInstance;

        public DOCUS_ASM_LOOKUP_PROCESSED_BY()
        {
            apiInstance = new ApiRepository<DOCUS_ASM_LOOKUP_PROCESSED_BY>();
        }
        public int LOOKUP_ID { get; set; }
        public Nullable<int> LOOKUP_ORDER { get; set; }
        public string LOOKUP_VALUE { get; set; }

        public IEnumerable<DOCUS_ASM_LOOKUP_PROCESSED_BY> Get()
        {
            return apiInstance.Get(Constants.ASMPROCESSEDBYLOOKUPURL);
        }
    }
}