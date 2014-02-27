using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CWAPI.DAL;
using CWAPI.Repository.IRepo;

namespace CWAPI.Repository.Repo
{
    public class DocSubLookupRepresentativeRepository : IDocSubLookupRepresentativeRepository
    {
        readonly DocumentContext _context = new DocumentContext();
        public IEnumerable<DOCUS_SUB_LOOKUP_REPRESENTATIVE> GetAll()
        {
            return _context.DOCUS_SUB_LOOKUP_REPRESENTATIVE.AsQueryable();
        }

        public IEnumerable<DOCUS_SUB_LOOKUP_REPRESENTATIVE> Get(int id)
        {
            if (_context.DOCUS_SUB_LOOKUP_REPRESENTATIVE != null)
                return _context.DOCUS_SUB_LOOKUP_REPRESENTATIVE.Where(lookup => lookup.LOOKUP_ID == id);
            return null;
        }

        public void Insert(DOCUS_SUB_LOOKUP_REPRESENTATIVE representativeData)
        {
            _context.DOCUS_SUB_LOOKUP_REPRESENTATIVE.Add(representativeData);
            _context.SaveChanges();
        }

        public void Update(DOCUS_SUB_LOOKUP_REPRESENTATIVE representativeData)
        {
            _context.Entry(representativeData).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}