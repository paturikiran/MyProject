using System.Collections.Generic;
using CWAPI.DAL;

namespace CWAPI.Repository.IRepo
{
    interface IDocAsmLookupAssignedToRepository
    {
        IEnumerable<DOCUS_ASM_LOOKUP_ASSIGNED_TO> GetAll();
        IEnumerable<DOCUS_ASM_LOOKUP_ASSIGNED_TO> Get(int id);
        void Insert(DOCUS_ASM_LOOKUP_ASSIGNED_TO assignedToData);
        void Update(DOCUS_ASM_LOOKUP_ASSIGNED_TO assignedToData);
    }
}
