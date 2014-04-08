using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CDR.Web.Models.LookupModels;

namespace CDR.Web.Agents
{
    public class SubRequestLookupAgent : ISubRequestLookupAgent
    {
        private SubRequestLookup _lookup;
        public SubRequestLookupAgent()
        {
            _lookup = new SubRequestLookup();
        }
        public IEnumerable<SubRequestLookup> Representative
        {
            get { return _lookup.Get(Constants.SUBREPRESENTATIVELOOKUPURL); }
        }

        public IEnumerable<SubRequestLookup> LoanType
        {
            get { return _lookup.Get(Constants.SUBLOANTYPELOOKUPURL); }
        }

        public IEnumerable<SubRequestLookup> RequestStatus
        {
            get { return _lookup.Get(Constants.SUBSTATUSLOOKUPURL); }
        }

        public IEnumerable<SubRequestLookup> Fee
        {
            get { return _lookup.Get(Constants.SUBFEELOOKUPURL); }
        }

        public IEnumerable<SubRequestLookup> RequestType
        {
            get { return _lookup.Get(Constants.SUBREQUESTTYPELOOKUPURL); }
        }
    }
}
