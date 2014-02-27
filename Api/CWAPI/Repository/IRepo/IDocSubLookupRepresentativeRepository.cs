using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWAPI.DAL;
using CWAPI.Repository.IRepo;

namespace CWAPI.Repository.IRepo
{
    interface IDocSubLookupRepresentativeRepository
    {
        IEnumerable<DOCUS_SUB_LOOKUP_REPRESENTATIVE> GetAll();
        IEnumerable<DOCUS_SUB_LOOKUP_REPRESENTATIVE> Get(int id);
        void Insert(DOCUS_SUB_LOOKUP_REPRESENTATIVE representativeData);
        void Update(DOCUS_SUB_LOOKUP_REPRESENTATIVE representativeData);
    }
}
