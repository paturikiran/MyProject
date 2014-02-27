using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CWAPI.DAL;
using CWAPI.Repository.IRepo;

namespace CWAPI.Repository.Repo
{
    public class DocSubLookupRequestTypeRepository:IDocSubLookupRequestTypeRepository
    {
        readonly DocumentContext _context = new DocumentContext();
        public IEnumerable<DOCUS_SUB_LOOKUP_REQUEST_TYPE> GetAll()
        {
            return _context.DOCUS_SUB_LOOKUP_REQUEST_TYPE.AsQueryable();
        }

        public IEnumerable<DOCUS_SUB_LOOKUP_REQUEST_TYPE> Get(int id)
        {
            if (_context.DOCUS_SUB_LOOKUP_REQUEST_TYPE != null)
                return _context.DOCUS_SUB_LOOKUP_REQUEST_TYPE.Where(lookup => lookup.LOOKUP_ID == id);
            return null;
        }

        public void Insert(DOCUS_SUB_LOOKUP_REQUEST_TYPE requestTypeData)
        {
            _context.DOCUS_SUB_LOOKUP_REQUEST_TYPE.Add(requestTypeData);
            _context.SaveChanges();
        }

        public void Update(DOCUS_SUB_LOOKUP_REQUEST_TYPE requestTypeData)
        {
            _context.Entry(requestTypeData).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}