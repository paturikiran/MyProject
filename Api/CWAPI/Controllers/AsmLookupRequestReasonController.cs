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
    public class AsmLookupRequestReasonController : ApiController
    {
        private DocumentContext _context = new DocumentContext();
        readonly IDocAsmLookupRequestReasonRepository _repoObj = new DocAsmLookupRequestReasonRepository();

        [HttpGet]
        public IEnumerable<DOCUS_ASM_LOOKUP_REQUEST_REASON> GetDocAsmLookupRequestReasonBy()
        {
            return _repoObj.GetAll();
        }

        // GET api/Sub_Request/5
        [HttpGet]
        public IEnumerable<DOCUS_ASM_LOOKUP_REQUEST_REASON> GetDocAsmLookupRequestReasonById(int id)
        {
            return _repoObj.Get(id);
        }

        [HttpPost]
        public void Inset([FromBody] DOCUS_ASM_LOOKUP_REQUEST_REASON requestReasonData)
        {
            _repoObj.Insert(requestReasonData);
        }

        [HttpPut]
        public bool Update([FromBody] DOCUS_ASM_LOOKUP_REQUEST_REASON requestReasonData)
        {
            bool result = true;
            try
            {
                _repoObj.Update(requestReasonData);
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
