﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Http;
using CDR.Web.Agents;
using CDR.Web.Api;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CDR.Web.Infrastructure.CustomAttributes;
using StructureMap;
using WebGrease.Css.Extensions;

namespace CDR.Web.Models
{
    public class DOCUS_ASM_ASSIGNMENTS : IAssignments
    {
        private IApiRepository<DOCUS_ASM_ASSIGNMENTS> apiInstance;
       // private DateTime? _dateEntered = DateTime.Now.Date;
       // private DateTime? _dateAssigned = DateTime.Now.Date;
        public DOCUS_ASM_ASSIGNMENTS()
        {
            apiInstance = new ApiRepository<DOCUS_ASM_ASSIGNMENTS>();
        }

        [Display(Name = "Account Number ")]
        [Required(ErrorMessage = "Account Number Requried")]
        public int? ACCOUNT_NUMBER { get; set; }

       

        [Display(Name = "Request Type")]
        [CustomDropDown(LookupMethodName = "RequestType", AddLookupData = true, LookupType = "Request Type")]
        public int? REQUEST_TYPE_ID { get; set; }

        [Display(Name = "Borrower Last Name")]
        public string BORROWER_LAST_NAME { get; set; }

        [Display(Name = "Request Reason")]
        [CustomDropDown(LookupMethodName = "RequestReason", AddLookupData = true, LookupType = "Request Reason")]
        public int? REQUEST_REASON_ID { get; set; }



        [Display(Name = "Request Date")]
        [CustomTextBox(IsDateType = true, IsMultiline = false)]
        public string REQUEST_DATE { get; set; }

        [Display(Name = "Collateral File Request Date")]
        [CustomTextBox(IsDateType = true, IsMultiline = false)]
        public string COLLATERAL_FILE_REQUEST_DATE { get; set; }

        [Display(Name = "Doc Type")]
        [CustomDropDown(LookupMethodName = "DocumentType", AddLookupData = true, LookupType = "Doc Type")]
        public int? DOC_TYPE_ID { get; set; }

        [Display(Name = "Assigned To")]
        [CustomDropDown(LookupMethodName = "AssignedTo", AddLookupData = true, LookupType = "Assigned To")]
        public int? ASSIGNED_TO_ID { get; set; }
        [Display(Name = "Assignor")]
        [CustomTextBox(IsDateType = false, IsMultiline = true)]
        public string ASSIGNOR { get; set; }

        [Display(Name = "Assignee")]
        [CustomTextBox(IsDateType = false, IsMultiline = true)]
        public string ASSIGNEE { get; set; }

        [Display(Name = "MERS", Description = "MERS")]
        public bool? MERS_INDICATOR { get; set; }

        [Display(Name = "MERS Updated", Description = "MERS Updated")]
        public bool? MERS_UPDATED { get; set; }

        [Display(Name = "Entered By")]
        [CustomDropDown(LookupMethodName = "EnteredBy", AddLookupData = false, LookupType = "Entered By")]
        public int? REQUEST_ENTERED_BY_ID { get; set; }

        [Display(Name = "Requestor Name")]
        [CustomDropDown(LookupMethodName = "RequestorName", AddLookupData = true, LookupType = "Requestor Name")]
        public int? REQUESTOR_NAME_ID { get; set; }

        [Display(Name = "Processed By")]
        [CustomDropDown(LookupMethodName = "ProcessedBy", AddLookupData = false, LookupType = "Processed By")]
        public int? PROCESSED_BY_ID { get; set; }

        [Display(Name = "Assigned Date")]
        [CustomTextBox(IsDateType = false, IsMultiline = false)]
        public string ASSIGNED_DATE { get; set; }

        [Display(Name = "Date Entered")]
        [CustomTextBox(IsDateType = false, IsMultiline = false, IsReadonly = true)]
        public string DATE_ENTERED { get; set; } 

        [Display(Name = "AOMInCOL", Description = "AOM In Collerateral file")]
        public bool? AOM_IN_COL { get; set; }

        [Display(Name = "Third Party Contact Name")]
        [CustomTextBox(IsDateType = false, IsMultiline = false)]
        public string THIRD_PARTY_CONTACT_NAME { get; set; }

        [Display(Name = "Third Party Contact Info")]
        [CustomTextBox(IsDateType = false, IsMultiline = true)]
        public string THIRD_PARTY_CONTACT_INFO { get; set; }

        [Display(Name = "Status ")]
        [CustomDropDown(LookupMethodName = "Status", AddLookupData = true, LookupType = "Status")]
        public int? STATUS_ID { get; set; }
        
        [Display(Name = "Last Status Date")]
        [CustomTextBox(IsDateType = false, IsMultiline = false)]
        public string LAST_STATUS_DATE { get; set; }

        [Display(Name = "Tracking Number")]
        [CustomTextBox(IsDateType = false, IsMultiline = false)]
        public string TRACKING_NUMBER { get; set; }

        [Display(Name = "Follow Up Date")]
        [CustomTextBox(IsDateType = true, IsMultiline = false)]
        public string FOLLOW_UP_DATE { get; set; }

        [Display(Name = "Sale Date")]
        [CustomTextBox(IsDateType = true, IsMultiline = false)]
        public string SALE_DATE { get; set; }

        [Display(Name = "Attention To")]
        [CustomTextBox(IsDateType = false, IsMultiline = false)]
        public string ATTENTION_TO { get; set; }

        [Display(Name = "Company Name")]
        [CustomTextBox(IsDateType = false, IsMultiline = false)]
        public string COMPANY_NAME { get; set; }

        [Display(Name = "Address")]
        [CustomTextBox(IsDateType = false, IsMultiline = false)]
        public string COMPANY_ADDRESS { get; set; }

        [Display(Name = "City")]
        [CustomTextBox(IsDateType = false, IsMultiline = false)]
        public string CITY { get; set; }

        [Display(Name = "State")]
        [CustomTextBox(IsDateType = false, IsMultiline = false)]
        public string STATE { get; set; }

        [Display(Name = "Zip")]
        [CustomTextBox(IsDateType = false, IsMultiline = false)]
        public string ZIP { get; set; }

        [Display(Name = "Rush", Description = "CheckBox")]
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
        public int ASSIGNMENT_ID { get; set; }
        public string TransactionType { get; set; }

        public string Status { get; set; }
        public string DocumentType { get; set; }
        public string Notes { get; set; }

        public bool IsNewRecordedAssignemnt { get; set; }

        public IEnumerable<DOCUS_ASM_ASSIGNMENTS> GetAssignments(int Id)
        {
            var url = Constants.GETASSIGNEMNTS + Id;
            var assginments = apiInstance.Get(url);
            if (assginments.Any())
            {
                assginments.ForEach(x => x.TranslateASsignments(x));
            }
            return assginments;
        }

        public bool Update(DOCUS_ASM_ASSIGNMENTS assignment)
        {
            var url = Constants.UPDATEASSIGNMENT;
            return apiInstance.Update(assignment, url);
        }

        public int Create(DOCUS_ASM_ASSIGNMENTS assginment)
        {
            var url = Constants.CREATEASSIGNMENT;
            return apiInstance.Create(assginment, url);
        }

        private DOCUS_ASM_ASSIGNMENTS TranslateASsignments(DOCUS_ASM_ASSIGNMENTS assignments)
        {
            var statusLookup = ObjectFactory.GetInstance<IAssignmentLookupAgent>();
            if (assignments.STATUS_ID != null)
            {
                var firstOrDefault = statusLookup.Status.FirstOrDefault(x => x.LOOKUP_ID.Equals(assignments.STATUS_ID) && assignments.STATUS_ID!=0);
                if (firstOrDefault != null)
                    assignments.Status = firstOrDefault.LOOKUP_VALUE;
            }
            if (assignments.DOC_TYPE_ID != null)
            {
                var firstOrDefault = statusLookup.DocumentType.FirstOrDefault(x => x.LOOKUP_ID.Equals(assignments.DOC_TYPE_ID) && assignments.DOC_TYPE_ID!=0);
                if (firstOrDefault != null)
                    assignments.DocumentType = firstOrDefault.LOOKUP_VALUE;
            }
            if (assignments.DATE_ENTERED!=null)
            {
                DateTime dateentered;
                DateTime.TryParse(assignments.DATE_ENTERED,out dateentered);
                assignments.DATE_ENTERED = dateentered.ToShortDateString();
            }

            if(!string.IsNullOrEmpty(assignments.REQUEST_DATE))
            {
                DateTime date;
                DateTime.TryParse(assignments.REQUEST_DATE,out date);
                assignments.REQUEST_DATE = date.ToShortDateString();
            }
            if(!string.IsNullOrEmpty(assignments.COLLATERAL_FILE_REQUEST_DATE))
            {
                DateTime date;
                DateTime.TryParse(assignments.COLLATERAL_FILE_REQUEST_DATE,out date);
                assignments.COLLATERAL_FILE_REQUEST_DATE = date.ToShortDateString();
            }
            if (!string.IsNullOrEmpty(assignments.LAST_STATUS_DATE))
            {
                DateTime date;
                DateTime.TryParse(assignments.LAST_STATUS_DATE, out date);
                assignments.LAST_STATUS_DATE = date.ToShortDateString();
            }

            if(!string.IsNullOrEmpty(assignments.ASSIGNED_DATE))
            {
                DateTime date;
                DateTime.TryParse(assignments.ASSIGNED_DATE,out date);
                assignments.ASSIGNED_DATE = date.ToShortDateString();
            }
            if (!string.IsNullOrEmpty(assignments.FOLLOW_UP_DATE))
            {
                DateTime date;
                DateTime.TryParse(assignments.FOLLOW_UP_DATE, out date);
                assignments.FOLLOW_UP_DATE = date.ToShortDateString();
            }
            if (!string.IsNullOrEmpty(assignments.SALE_DATE))
            {
                DateTime date;
                DateTime.TryParse(assignments.SALE_DATE, out date);
                assignments.SALE_DATE = date.ToShortDateString();
            }

            return assignments;
        }
    }
}