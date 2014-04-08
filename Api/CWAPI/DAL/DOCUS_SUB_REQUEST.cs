//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CWAPI.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class DOCUS_SUB_REQUEST
    {
        public int REQUEST_ID { get; set; }
        public Nullable<System.DateTime> DATE_RECEIVED { get; set; }
        public Nullable<int> GT_LOAN_NUMBER { get; set; }
        public string BORROWER_LAST_NAME { get; set; }
        public Nullable<int> REPRESENTATIVE_ID { get; set; }
        public Nullable<System.DateTime> DATE_ASSIGNED_TO_PROCESSOR { get; set; }
        public Nullable<int> OWNER_ID { get; set; }
        public string REQUESTOR { get; set; }
        public Nullable<int> REQUEST_TYPE_ID { get; set; }
        public Nullable<int> FEE_ID { get; set; }
        public Nullable<int> REQUEST_STATUS_ID { get; set; }
        public Nullable<System.DateTime> STATUS_DATE { get; set; }
        public Nullable<int> REASON_ID { get; set; }
        public Nullable<decimal> PRINCIPAL_LOAN_BALANCE { get; set; }
        public Nullable<decimal> LOAN_BALANCE_2 { get; set; }
        public Nullable<decimal> NEW_LOAN_AMOUNT { get; set; }
        public Nullable<int> NEW_CLTV { get; set; }
        public string COMMENTS { get; set; }
        public Nullable<int> HELOC { get; set; }
        public Nullable<int> FICO { get; set; }
        public Nullable<int> PROPOSED_DTI { get; set; }
        public Nullable<int> CURRENT_DTI { get; set; }
        public Nullable<int> LOAN_TYPE_ID { get; set; }
    }
}
