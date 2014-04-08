using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CWAPI.DAL;
using CWAPI.Repository.IRepo;

namespace CWAPI.Repository.Repo
{
    public class DocSubRequestRepository : IDocSubRequestRepository
    {
        readonly DocumentContext _context = new DocumentContext();
        public IEnumerable<DOCUS_SUB_REQUEST> GetAll()
        {
            return _context.DOCUS_SUB_REQUEST.AsQueryable();
        }

        public IEnumerable<DOCUS_SUB_REQUEST> Get(int id)
        {
            if (_context.DOCUS_SUB_REQUEST != null)
                return _context.DOCUS_SUB_REQUEST.Where(reqId => reqId.GT_LOAN_NUMBER == id);
            return null;
        }

        public void Insert(DOCUS_SUB_REQUEST subRequest)
        {
            _context.DOCUS_SUB_REQUEST.Add(subRequest);
            _context.SaveChanges();
        }

        public void Update(DOCUS_SUB_REQUEST subRequest)
        {
            _context.Entry(subRequest).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}