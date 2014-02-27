using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CWAPI.DAL;
using CWAPI.Repository.IRepo;
using CWAPI.Repository.Repo;

namespace CWAPI.Controllers
{
    public class SysCustodianController : ApiController
    {
         private DocumentContext _context = new DocumentContext();
        readonly IDocSysCustodianRepository _repoObj = new DocSysCustodianRepository();

        [HttpGet]
        public IEnumerable<DOCUS_SYS_CUSTODIAN> GetSysCustodians()
        {
            return _repoObj.GetAll();
        }

        // GET api/Sub_Request/5
        [HttpGet]
        public IEnumerable<DOCUS_SYS_CUSTODIAN> GetSysCustodiansById(int id)
        {
            return _repoObj.Get(id);
        }

        [HttpPost]
        public void Inset([FromBody] DOCUS_SYS_CUSTODIAN custodianData)
        {
            _repoObj.Insert(custodianData);
        }

        [HttpPut]
        public bool Update([FromBody] DOCUS_SYS_CUSTODIAN custodianData)
        {
            bool result = true;
            try
            {
                _repoObj.Update(custodianData);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
    
    }
}
