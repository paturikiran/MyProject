using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CWAPI.DAL;
using CWAPI.Repository.IRepo;

namespace CWAPI.Repository.Repo
{
    public class DocAsmLookupEnteredByRepository : IDocAsmLookupEnteredByRepository
    {
        readonly DocumentContext _context = new DocumentContext();
        public IEnumerable<DOCUS_ASM_LOOKUP_ENTERED_BY> GetAll()
        {
            return _context.DOCUS_ASM_LOOKUP_ENTERED_BY.AsQueryable();
        }

        public IEnumerable<DOCUS_ASM_LOOKUP_ENTERED_BY> Get(int id)
        {
            if (_context.DOCUS_ASM_LOOKUP_ENTERED_BY != null)
                return _context.DOCUS_ASM_LOOKUP_ENTERED_BY.Where(lookup => lookup.LOOKUP_ID == id);
            return null;
        }

        public void Insert(DOCUS_ASM_LOOKUP_ENTERED_BY enteredByData)
        {
            _context.DOCUS_ASM_LOOKUP_ENTERED_BY.Add(enteredByData);
            _context.SaveChanges();
        }

        public void Update(DOCUS_ASM_LOOKUP_ENTERED_BY enteredByData)
        {
            _context.Entry(enteredByData).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}