using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CWAPI.DAL;
using CWAPI.Repository.IRepo;

namespace CWAPI.Repository.Repo
{
    public class DocSubLookupStatusRepository : IDocSubLookupStatusRepository
    {
        readonly DocumentContext _context = new DocumentContext();
        public IEnumerable<DOCUS_SUB_LOOKUP_STATUS> GetAll()
        {
            return _context.DOCUS_SUB_LOOKUP_STATUS.AsQueryable();
        }

        public IEnumerable<DOCUS_SUB_LOOKUP_STATUS> Get(int id)
        {
            return _context.DOCUS_SUB_LOOKUP_STATUS.Where(lookup => lookup.LOOKUP_ID == id);
        }

        public void Insert(DOCUS_SUB_LOOKUP_STATUS assignmentStatus)
        {
            _context.DOCUS_SUB_LOOKUP_STATUS.Add(assignmentStatus);
            _context.SaveChanges();
        }

        public void Update(DOCUS_SUB_LOOKUP_STATUS assignmentStatus)
        {
            _context.Entry(assignmentStatus).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}