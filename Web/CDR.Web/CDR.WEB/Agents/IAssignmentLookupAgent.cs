using CDR.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDR.Web.Models.LookupModels;

namespace CDR.Web.Agents
{
    public interface IAssignmentLookupAgent
    {
        IEnumerable<AssignmentLookup> AssignedTo { get; }
        IEnumerable<AssignmentLookup> DocumentType { get; }
        IEnumerable<AssignmentLookup> EnteredBy { get; }
        IEnumerable<AssignmentLookup> ProcessedBy { get; }
        IEnumerable<AssignmentLookup> ProcessorName { get; }
        IEnumerable<AssignmentLookup> RecordingStatus { get; }
        IEnumerable<AssignmentLookup> RequestorName { get; }
        IEnumerable<AssignmentLookup> RequestReason { get; }
        IEnumerable<AssignmentLookup> RequestType { get; }
        IEnumerable<AssignmentLookup> Status { get; }
      //  IEnumerable<DOCUS_ASM_LOOKUP_ASSIGNED_TO> Assignor{ get; set; }
      ////  IEnumerable<DOCUS_ASM_LOOKUP_> Assignee { get; set; }
      //  IEnumerable<DOCUS_ASM_LOOKUP_ENTERED_BY> DataEnteredBy { get; set; }
      //  IEnumerable<DOCUS_ASM_LOOKUP_DOC_TYPE> DocumentType { get; set; }
      //  IEnumerable<DOCUS_ASM_LOOKUP_ENTERED_BY> EnteredBy { get; set; }
      //  IEnumerable<DOCUS_ASM_LOOKUP_PREPARED_BY> PreparedBy { get; set; }
      //  IEnumerable<DOCUS_ASM_LOOKUP_PROCESSOR_NAME> ProcessorName { get; set; }
      //  IEnumerable<DOCUS_ASM_LOOKUP_RECORDING_STATUS> RecordingStatus { get; set; }
      //  IEnumerable<DOCUS_ASM_LOOKUP_REQUEST_REASON> RequestReason { get; set; }
      //  IEnumerable<DOCUS_ASM_LOOKUP_REQUEST_TYPE> RequestType { get; set; }
      //  IEnumerable<DOCUS_ASM_LOOKUP_REQUESTOR_NAME> RequestorName { get; set; }
      //  IEnumerable<DOCUS_SUB_LOOKUP_STATUS> RequestStatus { get; set; }
    }
}
