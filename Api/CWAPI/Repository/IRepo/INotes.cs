using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWAPI.DAL;

namespace CWAPI.Repository.IRepo
{
    public interface INotesRepository
    {
        IEnumerable<DOCUS_ASM_ASSIGNMENT_NOTES> GetNotes(int AssignmentId);
        int SaveNotes(DOCUS_ASM_ASSIGNMENT_NOTES notes);


    }
}
