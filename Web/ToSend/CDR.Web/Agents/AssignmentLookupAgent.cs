using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using CDR.Web.Models;
using CDR.Web.Api;
using CDR.Web.Models.LookupModels;

namespace CDR.Web.Agents
{
    public class AssignmentLookupAgent:IAssignmentLookupAgent
    {
        private AssignmentLookup _assigmentLookup;

        public AssignmentLookupAgent()
        {
            _assigmentLookup = new AssignmentLookup();
        }

        public IEnumerable<AssignmentLookup> AssignedTo
        {
            get { return _assigmentLookup.Get(Constants.ASMASSIGNEDTOLOOKUPURL); }
        }

        public IEnumerable<AssignmentLookup> DocumentType
        {
            get { return _assigmentLookup.Get(Constants.ASMDOCTYPELOOKUPURL); }
        }

        public IEnumerable<AssignmentLookup> EnteredBy
        {
            get { return _assigmentLookup.Get(Constants.ASMASSIGNEDTOLOOKUPURL); }
        }

        public IEnumerable<AssignmentLookup> ProcessedBy
        {
            get { return _assigmentLookup.Get(Constants.ASMASSIGNEDTOLOOKUPURL); }
        }

        public IEnumerable<AssignmentLookup> ProcessorName
        {
            get { return _assigmentLookup.Get(Constants.ASMPROCESSORNAMELOOKUPURL); }
        }

        public IEnumerable<AssignmentLookup> RecordingStatus
        {
            get { return _assigmentLookup.Get(Constants.ASMRECORDINGSTATUSLOOKUPURL); }
        }

        public IEnumerable<AssignmentLookup> RequestorName
        {
            get { return _assigmentLookup.Get(Constants.ASMREQUESTORNAMELOOKUPURL); }
        }

        public IEnumerable<AssignmentLookup> RequestReason
        {
            get { return _assigmentLookup.Get(Constants.ASMREQUESTREASONLOOKUPURL); }
        }

        public IEnumerable<AssignmentLookup> RequestType
        {
            get { return _assigmentLookup.Get(Constants.ASMREQUESTTYPELOOKUPURL); }
        }

        public IEnumerable<AssignmentLookup> Status
        {
            get { return _assigmentLookup.Get(Constants.ASMSTATUSLOOKUPURL); }
        }

        //private ObjectCache cache;
       
        ////TODO to be implemented later
        ////public AssignmentLookupAgent()
        ////{
        ////    this.cache = MemoryCache.Default;
        ////}

        //public IEnumerable<DOCUS_ASM_LOOKUP_ASSIGNED_TO> Assignor
        //{
        //    get
        //    {
        //        var lookup = new DOCUS_ASM_LOOKUP_ASSIGNED_TO();
        //        return lookup.Get();
        //    }
        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public IEnumerable<DOCUS_ASM_LOOKUP_ENTERED_BY> DataEnteredBy
        //{
        //    get
        //    {
        //        var lookup = new DOCUS_ASM_LOOKUP_ENTERED_BY();
        //        return lookup.Get();
        //    }
        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public IEnumerable<DOCUS_ASM_LOOKUP_DOC_TYPE> DocumentType
        //{
        //    get
        //    {
        //        var lookup = new DOCUS_ASM_LOOKUP_DOC_TYPE();
        //        return lookup.Get();
        //    }
        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public IEnumerable<DOCUS_ASM_LOOKUP_ENTERED_BY> EnteredBy
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public IEnumerable<DOCUS_ASM_LOOKUP_PREPARED_BY> PreparedBy
        //{
        //    get
        //    {
        //        var lookup = new DOCUS_ASM_LOOKUP_PREPARED_BY();
        //        return lookup.Get();
        //    }
        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public IEnumerable<DOCUS_ASM_LOOKUP_PROCESSOR_NAME> ProcessorName
        //{
        //    get
        //    {
        //        var lookup = new DOCUS_ASM_LOOKUP_PROCESSOR_NAME();
        //        return lookup.Get();
        //    }
        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public IEnumerable<DOCUS_ASM_LOOKUP_RECORDING_STATUS> RecordingStatus
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public IEnumerable<DOCUS_ASM_LOOKUP_REQUEST_REASON> RequestReason
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public IEnumerable<DOCUS_ASM_LOOKUP_REQUEST_TYPE> RequestType
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public IEnumerable<DOCUS_ASM_LOOKUP_REQUESTOR_NAME> RequestorName
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public IEnumerable<DOCUS_SUB_LOOKUP_STATUS> RequestStatus
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}