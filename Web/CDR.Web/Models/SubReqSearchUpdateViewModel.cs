using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDR.Web.Models
{
    public class SubReqSearchUpdateViewModel
    {
        public int LoanId { get; set; }
        public int LoanAccountNumber {get;set;}

        public string BorrowerLastName { get; set; }

        public string DateReceived { get; set; }


        public IEnumerable<SubReqSearchUpdateViewModel> GetAllLoans()
        {
            var loans = new List<SubReqSearchUpdateViewModel>();

            for(int i=1,j=100;i<20 && j<120;i++)
            {
                var loan = new SubReqSearchUpdateViewModel();
                loan.BorrowerLastName = "LastName" + j;
                loan.LoanId = i;
                loan.LoanAccountNumber = j;
                loan.DateReceived = DateTime.Now.AddDays(-i).ToShortDateString();
                loans.Add(loan);
            }
            return loans;
        }
    }
}