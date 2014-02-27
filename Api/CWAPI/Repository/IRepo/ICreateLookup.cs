using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWAPI.DAL;
using CWAPI.Models;


namespace CWAPI.Repository.IRepo
{
    interface ICreateLookup
    {
        int Create(LookupModel  model);
        
    }
}
