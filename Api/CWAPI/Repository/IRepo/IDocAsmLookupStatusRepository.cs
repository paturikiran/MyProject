using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWAPI.DAL;

namespace CWAPI.Repository.IRepo
{
    interface IDocAsmLookupStatusRepository
    {
        IEnumerable<DOCUS_ASM_LOOKUP_STATUS> GetAll();
        IEnumerable<DOCUS_ASM_LOOKUP_STATUS> Get(int id);
        void Insert(DOCUS_ASM_LOOKUP_STATUS assignmentStatus);
        void Update(DOCUS_ASM_LOOKUP_STATUS assignmentStatus);
    }
}
