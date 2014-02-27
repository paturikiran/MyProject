using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWAPI.DAL;

namespace CWAPI.Repository.IRepo
{
    interface IDocAsmLookupEnteredByRepository
    {
        IEnumerable<DOCUS_ASM_LOOKUP_ENTERED_BY> GetAll();
        IEnumerable<DOCUS_ASM_LOOKUP_ENTERED_BY> Get(int id);
        void Insert(DOCUS_ASM_LOOKUP_ENTERED_BY enteredByData);
        void Update(DOCUS_ASM_LOOKUP_ENTERED_BY enteredByData);
    }
}
