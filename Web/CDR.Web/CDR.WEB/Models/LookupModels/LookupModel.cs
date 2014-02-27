using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CDR.Web.Api;

namespace CDR.Web.Models.LookupModels
{
    public class LookupModel : ILookupModel
    {
        private IApiRepository<LookupModel> _apiInstance;
        
        public LookupModel()
        {
            _apiInstance = new ApiRepository<LookupModel>();
        }
        public string Section { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }

        public bool Create(LookupModel model)
        {
            return _apiInstance.Insert(model, Constants.ADDLOOKUP);
        }
    }
}