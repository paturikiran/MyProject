using System.Collections.Generic;
using System.Linq;
using CDR.Web.Api;

namespace CDR.Web.Models.LookupModels
{
    public class AssignmentLookup : IAssignmentLookup
    {
        private IApiRepository<AssignmentLookup> _apiInstance;

        public AssignmentLookup()
        {
            _apiInstance = new ApiRepository<AssignmentLookup>();
        }

        public int LOOKUP_ID { get; set; }
        public int? LOOKUP_ORDER { get; set; }
        public string LOOKUP_VALUE { get; set; }

        public IEnumerable<AssignmentLookup> Get(string url)
        {
            var result = _apiInstance.Get(url);
            return result.OrderBy(x => x.LOOKUP_ORDER);
        }
    }
}