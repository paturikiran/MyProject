using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Http;
using CDR.Web.Api;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CDR.Web.Infrastructure.CustomAttributes;

namespace CDR.Web.Models
{
    public class DOCUS_ASM_ASSIGNMENTS : IAssignments
    {
        private IApiRepository<DOCUS_ASM_ASSIGNMENTS> apiInstance;
        public DOCUS_ASM_ASSIGNMENTS()
        {
            apiInstance = new ApiRepository<DOCUS_ASM_ASSIGNMENTS>();
        }


        public int ASSIGNMENT_ID { get; set; }

        [Display(Name = "Account Number ")]
        public int? ACCOUNT_NUMBER { get; set; }

        [Display(Name = "Borrower Last Name")]
        public string BORROWER_LAST_NAME { get; set; }

        [Display(Name = "Request Type")]
        public int? REQUEST_TYPE_ID { get; set; }

        [Display(Name = "Request Reason")]
        public int? REQUEST_REASON_ID { get; set; }

        [Display(Name = "Doc Type")]
        public int? DOC_TYPE_ID { get; set; }

        [Display(Name = "Request Date")]
        public DateTime? REQUEST_DATE { get; set; }

        [Display(Name = "Date Entered")]
        public DateTime? DATE_ENTERED { get; set; }

        [Display(Name = "Entered By")]
        public int? REQUEST_ENTERED_BY_ID { get; set; }

        [Display(Name = "Requestor Name")]
        public int? REQUESTOR_NAME_ID { get; set; }

        [Display(Name = "MERS", Description = "MERS")]
        public bool? MERS_INDICATOR { get; set; }

        [Display(Name = "MERS Updated", Description = "MERS Updated")]
        public bool? MERS_UPDATED { get; set; }

        [Display(Name = "Assignor")]
        public string ASSIGNOR { get; set; }

        [Display(Name = "Assignee")]
        public string ASSIGNEE { get; set; }

        [Display(Name = "Assigned To")]
        public int? ASSIGNED_TO_ID { get; set; }

        [Display(Name = "Processed By")]
        public int? PROCESSED_BY_ID { get; set; }

        [Display(Name = "Assigned Date")]
        public DateTime? ASSIGNED_DATE { get; set; }

        [Display(Name = "Collateral File Request Date")]
        public DateTime? COLLATERAL_FILE_REQUEST_DATE { get; set; }

        [Display(Name = "AOMInCOL", Description = "AOM In Collerateral file")]
        public bool? AOM_IN_COL { get; set; }

        [Display(Name = "Third Party Contact Name")]
        public string THIRD_PARTY_CONTACT_NAME { get; set; }

        [Display(Name = "Third Party Contact Info")]
        public string THIRD_PARTY_CONTACT_INFO { get; set; }

        [Display(Name = "Status ")]
        public int? STATUS_ID { get; set; }

        [Display(Name = "Tracking Number")]
        public string TRACKING_NUMBER { get; set; }

        [Display(Name = "Last Status Date")]
        public DateTime? LAST_STATUS_DATE { get; set; }

        [Display(Name = "Follow Up Date")]
        public DateTime? FOLLOW_UP_DATE { get; set; }

        [Display(Name = "Sale Date")]
        public DateTime? SALE_DATE { get; set; }

        [Display(Name = "Attention To")]
        public string ATTENTION_TO { get; set; }

        [Display(Name = "Company Name")]
        public string COMPANY_NAME { get; set; }

        [Display(Name = "Address")]
        public string COMPANY_ADDRESS { get; set; }

        [Display(Name = "City")]
        public string CITY { get; set; }

        [Display(Name = "State")]
        public string STATE { get; set; }

        [Display(Name = "Zip")]
        public string ZIP { get; set; }

        [Display(Name="Rush")]
        public bool? RUSH { get; set; }

        public int? CUSTODIAN_ID { get; set; }

        public string CUST_REF_NUMBER { get; set; }

        public string MERS_INFO_NUMBER { get; set; }

        public int? LSCOD1 { get; set; }

        public int? SBSCOD { get; set; }

        public int? RECORDED_STATUS_ID { get; set; }

        public string RECORDED_COUNTY { get; set; }

        public DateTime? RECORDED_DATE { get; set; }

        public string RECORDED_DOC_INST_NUM { get; set; }

        public string RECORDED_BOOK { get; set; }

        public string RECORDED_PAGE { get; set; }

        public System.DateTime DATE_CREATED { get; set; }

        public System.DateTime DATE_UPDATED { get; set; }

        public string CREATED_BY { get; set; }

        public string UPDATED_BY { get; set; }
        public DateTime? DATE_COMPLETE { get; set; }

        public IEnumerable<DOCUS_ASM_ASSIGNMENTS> GetAssignments(int Id)
        {
            var url = Constants.GETASSIGNEMNTS + Id;
            return apiInstance.Get(url);
        }

        public bool Update(DOCUS_ASM_ASSIGNMENTS assignment)
        {
            var url = Constants.UPDATEASSIGNMENT;
            return apiInstance.Update(assignment, url);
        }

        public bool Create(DOCUS_ASM_ASSIGNMENTS assginment)
        {
            throw new NotImplementedException();
        }
    }
}