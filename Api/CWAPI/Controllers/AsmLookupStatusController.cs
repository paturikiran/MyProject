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
    public class AsmLookupStatusController : ApiController
    {
        private DocumentContext _context = new DocumentContext();
        readonly IDocAsmLookupStatusRepository _repoObj = new DocAsmLookupStatusRepository();

        [HttpGet]
        public IEnumerable<DOCUS_ASM_LOOKUP_STATUS> GetDocAsmLookupRequestType()
        {
            return _repoObj.GetAll();
        }

        // GET api/Sub_Request/5
        [HttpGet]
        public IEnumerable<DOCUS_ASM_LOOKUP_STATUS> GetDocAsmLookupRequestTypeById(int id)
        {
            return _repoObj.Get(id);
        }

        [HttpPost]
        public void Inset([FromBody] DOCUS_ASM_LOOKUP_STATUS assignmentStatus)
        {
            _repoObj.Insert(assignmentStatus);
        }

        [HttpPut]
        public bool Update([FromBody] DOCUS_ASM_LOOKUP_STATUS assignmentStatus)
        {
            bool result = true;
            try
            {
                _repoObj.Update(assignmentStatus);
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
