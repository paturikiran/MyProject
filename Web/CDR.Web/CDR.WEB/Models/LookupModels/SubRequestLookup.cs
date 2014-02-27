using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CDR.Web.Api;

namespace CDR.Web.Models.LookupModels
{
    public class SubRequestLookup
    {
         private IApiRepository<SubRequestLookup> _apiInstance;

         public SubRequestLookup()
        {
            _apiInstance = new ApiRepository<SubRequestLookup>();
        }

        public int LOOKUP_ID { get; set; }
        public int? LOOKUP_ORDER { get; set; }
        public string LOOKUP_VALUE { get; set; }

        public IEnumerable<SubRequestLookup> Get(string url)
        {
            var result = _apiInstance.Get(url);
            return result.OrderBy(x => x.LOOKUP_ORDER);
        }
    }
}