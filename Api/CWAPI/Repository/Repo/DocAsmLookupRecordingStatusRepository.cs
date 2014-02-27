using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CWAPI.DAL;
using CWAPI.Repository.IRepo;

namespace CWAPI.Repository.Repo
{
    public class DocAsmLookupRecordingStatusRepository : IDocAsmLookupRecordingStatusRepository
    {
        readonly DocumentContext _context = new DocumentContext();
        public IEnumerable<DOCUS_ASM_LOOKUP_RECORDING_STATUS> GetAll()
        {
            return _context.DOCUS_ASM_LOOKUP_RECORDING_STATUS.AsQueryable();
        }

        public IEnumerable<DOCUS_ASM_LOOKUP_RECORDING_STATUS> Get(int id)
        {
            if (_context.DOCUS_ASM_LOOKUP_RECORDING_STATUS != null)
                return _context.DOCUS_ASM_LOOKUP_RECORDING_STATUS.Where(lookup => lookup.LOOKUP_ID == id);
            return null;
        }

        public void Insert(DOCUS_ASM_LOOKUP_RECORDING_STATUS recordingStatusData)
        {
            _context.DOCUS_ASM_LOOKUP_RECORDING_STATUS.Add(recordingStatusData);
            _context.SaveChanges();
        }

        public void Update(DOCUS_ASM_LOOKUP_RECORDING_STATUS recordingStatusData)
        {
            _context.Entry(recordingStatusData).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}