using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWAPI.DAL;

namespace CWAPI.Repository.IRepo
{
    interface IDocSubLookupFeeRepository
    {
        IEnumerable<DOCUS_SUB_LOOKUP_FEE> GetAll();
        IEnumerable<DOCUS_SUB_LOOKUP_FEE> Get(int id);
        void Insert(DOCUS_SUB_LOOKUP_FEE feeData);
        void Update(DOCUS_SUB_LOOKUP_FEE feeData);
    }
}
