using System.Collections.Generic;
using System.Data;
using System.Linq;
using CWAPI.DAL;
using CWAPI.Repository.IRepo;

namespace CWAPI.Repository.Repo
{
    public class DocSysCustodianRepository : IDocSysCustodianRepository
    {
        readonly DocumentContext _context = new DocumentContext();
        public IEnumerable<DOCUS_SYS_CUSTODIAN> GetAll()
        {
            return _context.DOCUS_SYS_CUSTODIAN.AsQueryable();
        }

        public IEnumerable<DOCUS_SYS_CUSTODIAN> Get(int id)
        {
            if (_context.DOCUS_SYS_CUSTODIAN != null)
                return _context.DOCUS_SYS_CUSTODIAN.Where(custodianId => custodianId.CUSTODIAN_ID == id);
            return null;
        }

       

        public void Insert(DOCUS_SYS_CUSTODIAN custodianData)
        {
            _context.DOCUS_SYS_CUSTODIAN.Add(custodianData);
            _context.SaveChanges();
        }

        public void Update(DOCUS_SYS_CUSTODIAN subRequest)
        {
            _context.Entry(subRequest).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}