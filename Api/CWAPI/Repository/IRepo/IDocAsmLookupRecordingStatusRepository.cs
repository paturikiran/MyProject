using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWAPI.DAL;

namespace CWAPI.Repository.IRepo
{
    interface IDocAsmLookupRecordingStatusRepository
    {
        IEnumerable<DOCUS_ASM_LOOKUP_RECORDING_STATUS> GetAll();
        IEnumerable<DOCUS_ASM_LOOKUP_RECORDING_STATUS> Get(int id);
        void Insert(DOCUS_ASM_LOOKUP_RECORDING_STATUS recordingStatusData);
        void Update(DOCUS_ASM_LOOKUP_RECORDING_STATUS recordingStatusData);
    }
}
