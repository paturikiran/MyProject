using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWAPI.DAL;

namespace CWAPI.Repository.IRepo
{
    interface IDocSysCustodianRepository
    {
        IEnumerable<DOCUS_SYS_CUSTODIAN> GetAll();
        IEnumerable<DOCUS_SYS_CUSTODIAN> Get(int id);
        void Insert(DOCUS_SYS_CUSTODIAN custodianData);
        void Update(DOCUS_SYS_CUSTODIAN custodianData);
    }
}
