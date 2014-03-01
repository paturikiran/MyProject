using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDR.Web.Models
{
    public interface IAssignments
    {
        //IEnumerable<DOCUS_SUB_REQUEST> GetSubRequestByRepresentative(int representativeId);
        IEnumerable<DOCUS_ASM_ASSIGNMENTS> GetAssignments(int Id);
        bool Update(DOCUS_ASM_ASSIGNMENTS assignment);
        int Create(DOCUS_ASM_ASSIGNMENTS assginment);
    }
}
