using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDR.Web.Models.LookupModels
{
    public interface ILookupModel
    {
        bool Create(LookupModel model);
       
    }
}
