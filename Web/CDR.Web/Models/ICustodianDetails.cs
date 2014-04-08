using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CDR.Web.Models
{
    public interface ICustodianDetails
    {
        CustodianDetails Get(int accountNumber);
    }
}
