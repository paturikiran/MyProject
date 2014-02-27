using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CWAPI.DAL;
using CWAPI.Repository.IRepo;

namespace CWAPI.Repository.Repo
{
    public class DocAsmLookupProcessedByRepository : IDocAsmLookupProcessedByRepository
    {
        readonly DocumentContext _context = new DocumentContext();
        public IEnumerable<DOCUS_ASM_LOOKUP_PROCESSED_BY> GetAll()
        {
            return _context.DOCUS_ASM_LOOKUP_PROCESSED_BY.AsQueryable();
        }

        public IEnumerable<DOCUS_ASM_LOOKUP_PROCESSED_BY> Get(int id)
        {
            if (_context.DOCUS_ASM_LOOKUP_PROCESSED_BY != null)
                return _context.DOCUS_ASM_LOOKUP_PROCESSED_BY.Where(lookup => lookup.LOOKUP_ID == id);
            return null;
        }

        public void Insert(DOCUS_ASM_LOOKUP_PROCESSED_BY processedByData)
        {
            _context.DOCUS_ASM_LOOKUP_PROCESSED_BY.Add(processedByData);
            _context.SaveChanges();
        }

        public void Update(DOCUS_ASM_LOOKUP_PROCESSED_BY processedByData)
        {
            _context.Entry(processedByData).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}