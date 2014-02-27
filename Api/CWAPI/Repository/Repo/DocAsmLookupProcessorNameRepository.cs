using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CWAPI.DAL;
using CWAPI.Repository.IRepo;

namespace CWAPI.Repository.Repo
{
    public class DocAsmLookupProcessorNameRepository : IDocAsmLookupProcessorNameRepository
    {
        readonly DocumentContext _context = new DocumentContext();
        public IEnumerable<DOCUS_ASM_LOOKUP_PROCESSOR_NAME> GetAll()
        {
            return _context.DOCUS_ASM_LOOKUP_PROCESSOR_NAME.AsQueryable();
        }

        public IEnumerable<DOCUS_ASM_LOOKUP_PROCESSOR_NAME> Get(int id)
        {
            if (_context.DOCUS_ASM_LOOKUP_PROCESSOR_NAME != null)
                return _context.DOCUS_ASM_LOOKUP_PROCESSOR_NAME.Where(lookup => lookup.LOOKUP_ID == id);
            return null;
        }

        public void Insert(DOCUS_ASM_LOOKUP_PROCESSOR_NAME processorNameData)
        {
            _context.DOCUS_ASM_LOOKUP_PROCESSOR_NAME.Add(processorNameData);
            _context.SaveChanges();
        }

        public void Update(DOCUS_ASM_LOOKUP_PROCESSOR_NAME processorNameData)
        {
            _context.Entry(processorNameData).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}