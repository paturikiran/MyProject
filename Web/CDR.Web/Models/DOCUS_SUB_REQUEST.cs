using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.ComponentModel;
using CDR.Web.Api;
using StructureMap;


namespace CDR.Web.Models
{
    public class DOCUS_SUB_REQUEST : ISubRequest
    {
        private IApiRepository<DOCUS_SUB_REQUEST> apiInstance;

        public DOCUS_SUB_REQUEST()
        {
            apiInstance = new ApiRepository<DOCUS_SUB_REQUEST>();
        }

        [DisplayName("ID")]
        [HiddenInput]
        public int ID { get; set; }

        [DisplayName("Date Received")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public Nullable<System.DateTime> Date_Received { get; set; }

        [DisplayName("GT Loan Number")]
        [HiddenInput]
        public Nullable<int> GT_Loan_Number { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage="Last Name is required")]
        public string Borrower_Last_Name { get; set; }

        [DisplayName("Date Assigned To Processor")]
        [HiddenInput]
        public Nullable<System.DateTime> Date_Assigned_To_Processor { get; set; }

        [StringLength(10, MinimumLength = 5)]
        [DisplayName("Requestor")]
        public string Requestor { get; set; }

        [DisplayName("Status Date")]
        public Nullable<System.DateTime> Status_Date { get; set; }
        [DisplayName("Reason")]
        public string Reason { get; set; }
        [DisplayName("Principal Loan Balance")]
        public Nullable<decimal> Principal_Loan_Balance { get; set; }
        [DisplayName("Loan Balance 2")]
        public Nullable<decimal> Loan_Balance_2 { get; set; }
        [DisplayName("New Loan Amount")]
        public Nullable<decimal> New_Loan_Amount { get; set; }
        [DisplayName("New_CLTV")]
        public Nullable<int> New_CLTV { get; set; }
        [DisplayName("Comments")]
        public string Comments { get; set; }
        [DisplayName("HELOC")]
        public Nullable<int> HELOC { get; set; }
        [DisplayName("FICO")]
        public Nullable<int> FICO { get; set; }
        [DisplayName("Owner ID")]
        [HiddenInput]
        public string Owner_Id { get; set; }

        [DisplayName("Proposed DTI")]
        [HiddenInput]
        public Nullable<int> Proposed_DTI { get; set; }
        [DisplayName("Current DTI")]
        [HiddenInput]
        public Nullable<int> Current_DTI { get; set; }
        [DisplayName("Representative ID")]
        [HiddenInput]
        public Nullable<int> Representative_Id { get; set; }
        [DisplayName("Request Type ID")]
        [HiddenInput]
        public Nullable<int> Request_Type_Id { get; set; }

        [DisplayName("Fee ID")]
        [HiddenInput]
        public Nullable<int> Fee_Id { get; set; }

        [DisplayName("Request Status ID")]
        [HiddenInput]
        public Nullable<int> Request_Status_Id { get; set; }

        [DisplayName("Loan Type")]
        [HiddenInput]
        public Nullable<int> Loan_Type_Id { get; set; }


        public IEnumerable<DOCUS_SUB_REQUEST> GetSubRequestByID(int id)
        {
            var url = Constants.SUBREQUESTURL + "GT_Loan_Number?=" + id;
            return apiInstance.Get(url);
        }

        public DOCUS_SUB_REQUEST GetSubRequestDetails(int id, int loanNumber)
        {
            var details = GetSubRequestByID(id).SingleOrDefault(x => x.ID == id && x.GT_Loan_Number == loanNumber);
            return details;
        }
        public bool UpdateSubRequest(DOCUS_SUB_REQUEST DocSubReq)
        {
            return apiInstance.Update(DocSubReq, Constants.SUBREQUESTURL);
        }





        public bool CreateSubRequest(DOCUS_SUB_REQUEST subRequest)
        {
            return apiInstance.Insert(subRequest, Constants.SUBREQUESTURL);
        }


        public IEnumerable<DOCUS_SUB_REQUEST> GetSubRequestByRepresentative(int representativeId)
        {
            var results = apiInstance.Get(Constants.SUBREQUESTURL).Where(x => x.Representative_Id == representativeId);
            return results;
        }
    }
}