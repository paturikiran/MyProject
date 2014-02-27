using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CWAPI.DAL;
using CWAPI.Repository.IRepo;

namespace CWAPI.Repository.Repo
{
    public class DocAsmLookupAssignedToRepository : IDocAsmLookupAssignedToRepository
    {
        readonly DocumentContext _context = new DocumentContext();
        public IEnumerable<DOCUS_ASM_LOOKUP_ASSIGNED_TO> GetAll()
        {
          //  return new List<DOCUS_ASM_LOOKUP_ASSIGNED_TO>();
             return _context.DOCUS_ASM_LOOKUP_ASSIGNED_TO.AsQueryable();
        }

        //public IEnumerable<DOCUS_ASM_ASSIGNMENTS> Get(int id)
        //{
        //    return _context.DOCUS_ASM_ASSIGNMENTS.Where(docusAsmAssignments => docusAsmAssignments.ACCOUNT_NUMBER == id);
        //}

        public IEnumerable<DOCUS_ASM_LOOKUP_ASSIGNED_TO> Get(int id)
        {
            if (_context.DOCUS_ASM_ASSIGNMENTS != null)
                return _context.DOCUS_ASM_LOOKUP_ASSIGNED_TO.Where(lookup => lookup.LOOKUP_ID == id);
            return null;
        }

        public void Insert(DOCUS_ASM_LOOKUP_ASSIGNED_TO assignedToData)
        {
            _context.DOCUS_ASM_LOOKUP_ASSIGNED_TO.Add(assignedToData);
            _context.SaveChanges();
        }

        public void Update(DOCUS_ASM_LOOKUP_ASSIGNED_TO assignedToData)
        {
            _context.Entry(assignedToData).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}