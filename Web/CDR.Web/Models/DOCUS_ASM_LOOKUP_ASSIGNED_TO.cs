using System;
using System.Collections.Generic;
using CDR.Web.Api;

namespace CDR.Web.Models
{
    public class DOCUS_ASM_LOOKUP_ASSIGNED_TO
    {
        private IApiRepository<DOCUS_ASM_LOOKUP_ASSIGNED_TO> apiInstance;

        public DOCUS_ASM_LOOKUP_ASSIGNED_TO()
        {
            apiInstance = new ApiRepository<DOCUS_ASM_LOOKUP_ASSIGNED_TO>();
        }
        public int LOOKUP_ID { get; set; }
        public Nullable<int> LOOKUP_ORDER { get; set; }
        public string LOOKUP_VALUE { get; set; }

        public IEnumerable<DOCUS_ASM_LOOKUP_ASSIGNED_TO> Get()
        {
            return apiInstance.Get(Constants.ASMASSIGNEDTOLOOKUPURL);
        }
    }
}