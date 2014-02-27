using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWAPI.DAL;
using CWAPI.Repository.IRepo;

namespace CWAPI.Repository.IRepo
{
    interface IDocSubLookupLoanTypeRepository
    {
        IEnumerable<DOCUS_SUB_LOOKUP_LOAN_TYPE> GetAll();
        IEnumerable<DOCUS_SUB_LOOKUP_LOAN_TYPE> Get(int id);
        void Insert(DOCUS_SUB_LOOKUP_LOAN_TYPE loanTypeData);
        void Update(DOCUS_SUB_LOOKUP_LOAN_TYPE loanTypeData);
    }
}
