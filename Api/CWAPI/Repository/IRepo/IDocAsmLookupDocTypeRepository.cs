using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWAPI.DAL;

namespace CWAPI.Repository.IRepo
{
    interface IDocAsmLookupDocTypeRepository
    {
        IEnumerable<DOCUS_ASM_LOOKUP_DOC_TYPE> GetAll();
        IEnumerable<DOCUS_ASM_LOOKUP_DOC_TYPE> Get(int id);
        void Insert(DOCUS_ASM_LOOKUP_DOC_TYPE docTypeData);
        void Update(DOCUS_ASM_LOOKUP_DOC_TYPE docTypeData);
    }
}
