using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDR.Web.Models
{
    public class AssignmentViewModel
    {
        public string TransanctionMode { get; set; }
        public DOCUS_ASM_ASSIGNMENTS Assginment { get; set; }
    }
}