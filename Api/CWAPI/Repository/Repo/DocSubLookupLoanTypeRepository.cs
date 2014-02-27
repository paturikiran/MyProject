using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CWAPI.DAL;
using CWAPI.Repository.IRepo;

namespace CWAPI.Repository.Repo
{
    public class DocSubLookupLoanTypeRepository : IDocSubLookupLoanTypeRepository
    {
        readonly DocumentContext _context = new DocumentContext();
        public IEnumerable<DOCUS_SUB_LOOKUP_LOAN_TYPE> GetAll()
        {
            return _context.DOCUS_SUB_LOOKUP_LOAN_TYPE.AsQueryable();
        }

        public IEnumerable<DOCUS_SUB_LOOKUP_LOAN_TYPE> Get(int id)
        {
            if (_context.DOCUS_SUB_REQUEST != null)
                return _context.DOCUS_SUB_LOOKUP_LOAN_TYPE.Where(lookup => lookup.LOOKUP_ID == id);
            return null;
        }

        public void Insert(DOCUS_SUB_LOOKUP_LOAN_TYPE loanTypeData)
        {
            _context.DOCUS_SUB_LOOKUP_LOAN_TYPE.Add(loanTypeData);
            _context.SaveChanges();
        }

        public void Update(DOCUS_SUB_LOOKUP_LOAN_TYPE loanTypeData)
        {
            _context.Entry(loanTypeData).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}