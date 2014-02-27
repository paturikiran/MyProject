using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CWAPI.DAL;
using CWAPI.Repository.IRepo;

namespace CWAPI.Repository.Repo
{
    public class DocSubLookupFeeRepository : IDocSubLookupFeeRepository
    {
        readonly DocumentContext _context = new DocumentContext();
        public IEnumerable<DOCUS_SUB_LOOKUP_FEE> GetAll()
        {
            return _context.DOCUS_SUB_LOOKUP_FEE.AsQueryable();
        }

        public IEnumerable<DOCUS_SUB_LOOKUP_FEE> Get(int id)
        {
            if (_context.DOCUS_SUB_REQUEST != null)
                return _context.DOCUS_SUB_LOOKUP_FEE.Where(lookup => lookup.LOOKUP_ID == id);
            return null;
        }

        public void Insert(DOCUS_SUB_LOOKUP_FEE feeData)
        {
            _context.DOCUS_SUB_LOOKUP_FEE.Add(feeData);
            _context.SaveChanges();
        }

        public void Update(DOCUS_SUB_LOOKUP_FEE feeData)
        {
            _context.Entry(feeData).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}