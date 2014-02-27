using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CWAPI.DAL;
using CWAPI.Repository.IRepo;

namespace CWAPI.Repository.Repo
{
    public class DocAsmLookupRequestReasonRepository : IDocAsmLookupRequestReasonRepository
    {
        readonly DocumentContext _context = new DocumentContext();
        public IEnumerable<DOCUS_ASM_LOOKUP_REQUEST_REASON> GetAll()
        {
            return _context.DOCUS_ASM_LOOKUP_REQUEST_REASON.AsQueryable();
        }

        public IEnumerable<DOCUS_ASM_LOOKUP_REQUEST_REASON> Get(int id)
        {
            if (_context.DOCUS_ASM_LOOKUP_REQUEST_REASON != null)
                return _context.DOCUS_ASM_LOOKUP_REQUEST_REASON.Where(lookup => lookup.LOOKUP_ID == id);
            return null;
        }

        public void Insert(DOCUS_ASM_LOOKUP_REQUEST_REASON requestReasonData)
        {
            _context.DOCUS_ASM_LOOKUP_REQUEST_REASON.Add(requestReasonData);
            _context.SaveChanges();
        }

        public void Update(DOCUS_ASM_LOOKUP_REQUEST_REASON requestReasonData)
        {
            _context.Entry(requestReasonData).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}