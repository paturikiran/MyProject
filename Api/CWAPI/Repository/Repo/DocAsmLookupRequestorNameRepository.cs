using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CWAPI.DAL;
using CWAPI.Repository.IRepo;

namespace CWAPI.Repository.Repo
{
    public class DocAsmLookupRequestorNameRepository : IDocAsmLookupRequestorNameRepository
    {
        readonly DocumentContext _context = new DocumentContext();
        public IEnumerable<DOCUS_ASM_LOOKUP_REQUESTOR_NAME> GetAll()
        {
            return _context.DOCUS_ASM_LOOKUP_REQUESTOR_NAME.AsQueryable();
        }

        public IEnumerable<DOCUS_ASM_LOOKUP_REQUESTOR_NAME> Get(int id)
        {
            if (_context.DOCUS_ASM_LOOKUP_RECORDING_STATUS != null)
                return _context.DOCUS_ASM_LOOKUP_REQUESTOR_NAME.Where(lookup => lookup.LOOKUP_ID == id);
            return null;
        }

        public void Insert(DOCUS_ASM_LOOKUP_REQUESTOR_NAME requestorNameData)
        {
            _context.DOCUS_ASM_LOOKUP_REQUESTOR_NAME.Add(requestorNameData);
            _context.SaveChanges();
        }

        public void Update(DOCUS_ASM_LOOKUP_REQUESTOR_NAME requestorNameData)
        {
            _context.Entry(requestorNameData).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}