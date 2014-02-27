using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWAPI.DAL;

namespace CWAPI.Repository.IRepo
{
    interface IDocAsmLookupRequestTypeRepository
    {
        IEnumerable<DOCUS_ASM_LOOKUP_REQUEST_TYPE> GetAll();
        IEnumerable<DOCUS_ASM_LOOKUP_REQUEST_TYPE> Get(int id);
        void Insert(DOCUS_ASM_LOOKUP_REQUEST_TYPE requestTypeData);
        void Update(DOCUS_ASM_LOOKUP_REQUEST_TYPE requestTypeData);
    }
}
