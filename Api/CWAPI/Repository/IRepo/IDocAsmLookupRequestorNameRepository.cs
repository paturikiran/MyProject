using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWAPI.DAL;

namespace CWAPI.Repository.IRepo
{
    interface IDocAsmLookupRequestorNameRepository
    {
        IEnumerable<DOCUS_ASM_LOOKUP_REQUESTOR_NAME> GetAll();
        IEnumerable<DOCUS_ASM_LOOKUP_REQUESTOR_NAME> Get(int id);
        void Insert(DOCUS_ASM_LOOKUP_REQUESTOR_NAME requestorNameData);
        void Update(DOCUS_ASM_LOOKUP_REQUESTOR_NAME requestorNameData);
    }
}
