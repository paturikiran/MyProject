using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWAPI.DAL;

namespace CWAPI.Repository.IRepo
{
    interface IDocAsmLookupRequestReasonRepository
    {
        IEnumerable<DOCUS_ASM_LOOKUP_REQUEST_REASON> GetAll();
        IEnumerable<DOCUS_ASM_LOOKUP_REQUEST_REASON> Get(int id);
        void Insert(DOCUS_ASM_LOOKUP_REQUEST_REASON requestReasonData);
        void Update(DOCUS_ASM_LOOKUP_REQUEST_REASON requestReasonData);
    }
}
