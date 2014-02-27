using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDR.Web.Models
{
    public interface ISubRequest
    {
        IEnumerable<DOCUS_SUB_REQUEST> GetSubRequestByID(int id);
        IEnumerable<DOCUS_SUB_REQUEST> GetSubRequestByRepresentative(int representativeId);
        DOCUS_SUB_REQUEST GetSubRequestDetails(int id, int loanNumber);
        bool UpdateSubRequest(DOCUS_SUB_REQUEST docSubReq);
        bool CreateSubRequest(DOCUS_SUB_REQUEST docSubReq);
    }
}
