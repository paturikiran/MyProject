using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDR.Web.Models.LookupModels;

namespace CDR.Web.Agents
{
    public interface ISubRequestLookupAgent
    {
        IEnumerable<SubRequestLookup> Representative { get; }
        IEnumerable<SubRequestLookup> LoanType { get; }
        IEnumerable<SubRequestLookup> RequestStatus { get; }
        IEnumerable<SubRequestLookup> Fee { get; }
        IEnumerable<SubRequestLookup> RequestType { get; }

    }
}
