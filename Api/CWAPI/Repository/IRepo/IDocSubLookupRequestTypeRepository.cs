using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWAPI.DAL;
using CWAPI.Repository.IRepo;

namespace CWAPI.Repository.IRepo
{
    interface IDocSubLookupRequestTypeRepository
    {
        IEnumerable<DOCUS_SUB_LOOKUP_REQUEST_TYPE> GetAll();
        IEnumerable<DOCUS_SUB_LOOKUP_REQUEST_TYPE> Get(int id);
        void Insert(DOCUS_SUB_LOOKUP_REQUEST_TYPE requestTypeData);
        void Update(DOCUS_SUB_LOOKUP_REQUEST_TYPE requestTypeData);
    }
}
