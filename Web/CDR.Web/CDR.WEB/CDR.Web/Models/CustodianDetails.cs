using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CDR.Web.Api;

namespace CDR.Web.Models
{
    public class CustodianDetails:ICustodianDetails
    {
        private IApiRepository<CustodianDetails> apiInstance;

        public CustodianDetails()
        {
           apiInstance = new ApiRepository<CustodianDetails>();
        }
        public int AccountNumber { get; set; }
        public Nullable<int> CustodianId { get; set; }
        public string BorrowerName { get; set; }
        public string CustodianName { get; set; }
        public string CustRefNumber { get; set; }
        public Nullable<decimal> MersInfoNumber { get; set; }
        public Nullable<int> LSCOD1 { get; set; }
        public string AcquiredFrom { get; set; }
        public Nullable<int> SBSCOD { get; set; }
        public string ServicingFor { get; set; }

        public CustodianDetails Get(int accountNumber)
         {
             var  details = apiInstance.GetDetails(Constants.GETCUSTODIANDETAILS+accountNumber);
            return details;
         }
    }
}