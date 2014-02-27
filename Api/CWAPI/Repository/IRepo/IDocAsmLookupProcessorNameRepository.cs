using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWAPI.DAL;

namespace CWAPI.Repository.IRepo
{
    interface IDocAsmLookupProcessorNameRepository
    {
        IEnumerable<DOCUS_ASM_LOOKUP_PROCESSOR_NAME> GetAll();
        IEnumerable<DOCUS_ASM_LOOKUP_PROCESSOR_NAME> Get(int id);
        void Insert(DOCUS_ASM_LOOKUP_PROCESSOR_NAME processorNameData);
        void Update(DOCUS_ASM_LOOKUP_PROCESSOR_NAME processorNameData);
    }
}
