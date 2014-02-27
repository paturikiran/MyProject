using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWAPI.DAL;

namespace CWAPI.Repository.IRepo
{
    interface IDocSubLookupStatusRepository
    {
        IEnumerable<DOCUS_SUB_LOOKUP_STATUS> GetAll();
        IEnumerable<DOCUS_SUB_LOOKUP_STATUS> Get(int id);
        void Insert(DOCUS_SUB_LOOKUP_STATUS statusData);
        void Update(DOCUS_SUB_LOOKUP_STATUS statusData);
    }
}
