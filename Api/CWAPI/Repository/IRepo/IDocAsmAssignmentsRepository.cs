using System.Collections.Generic;
using CWAPI.DAL;

namespace CWAPI.Repository.IRepo
{
    interface IDocAsmAssignmentsRepository
    {
        IEnumerable<DOCUS_ASM_ASSIGNMENTS> GetAll();
        IEnumerable<DOCUS_ASM_ASSIGNMENTS> Get(int id);
        int Insert(DOCUS_ASM_ASSIGNMENTS assignmentsRequest);
        void Update(DOCUS_ASM_ASSIGNMENTS assignmentsRequest);

        DOCUS_ASM_GET_GTA_FIELDS_Result GetGTA(int id);
    }
}
