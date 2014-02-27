using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CWAPI.DAL;
using CWAPI.Repository.IRepo;

namespace CWAPI.Repository.Repo
{
    public class DocAsmLookupDocTypeRepository : IDocAsmLookupDocTypeRepository
    {
        readonly DocumentContext _context = new DocumentContext();
        public IEnumerable<DOCUS_ASM_LOOKUP_DOC_TYPE> GetAll()
        {
            return _context.DOCUS_ASM_LOOKUP_DOC_TYPE.AsQueryable();
        }

        public IEnumerable<DOCUS_ASM_LOOKUP_DOC_TYPE> Get(int id)
        {
            if (_context.DOCUS_ASM_LOOKUP_DOC_TYPE != null)
                return _context.DOCUS_ASM_LOOKUP_DOC_TYPE.Where(lookup => lookup.LOOKUP_ID == id);
            return null;
        }

        public void Insert(DOCUS_ASM_LOOKUP_DOC_TYPE docTypeData)
        {
            _context.DOCUS_ASM_LOOKUP_DOC_TYPE.Add(docTypeData);
            _context.SaveChanges();
        }

        public void Update(DOCUS_ASM_LOOKUP_DOC_TYPE docTypeData)
        {
            _context.Entry(docTypeData).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}