using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDR.Web.Models
{
    public interface INotes
    {
        IEnumerable<AssignmentNotes> Get(int assignmentId);
        bool SaveNotes(AssignmentNotes notes);
    }
}
