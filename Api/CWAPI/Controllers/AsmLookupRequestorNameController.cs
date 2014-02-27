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
    public class AsmLookupRequestorNameController : ApiController
    {
        private DocumentContext _context = new DocumentContext();
        readonly IDocAsmLookupRequestorNameRepository _repoObj = new DocAsmLookupRequestorNameRepository();

        [HttpGet]
        public IEnumerable<DOCUS_ASM_LOOKUP_REQUESTOR_NAME> GetDocAsmLookupRecordingStatusBy()
        {
            return _repoObj.GetAll();
        }

        // GET api/Sub_Request/5
        [HttpGet]
        public IEnumerable<DOCUS_ASM_LOOKUP_REQUESTOR_NAME> GetDocAsmLookupRecordingStatusById(int id)
        {
            return _repoObj.Get(id);
        }

        [HttpPost]
        public void Inset([FromBody] DOCUS_ASM_LOOKUP_REQUESTOR_NAME requestorNameDat)
        {
            _repoObj.Insert(requestorNameDat);
        }

        [HttpPut]
        public bool Update([FromBody] DOCUS_ASM_LOOKUP_REQUESTOR_NAME requestorNameDat)
        {
            bool result = true;
            try
            {
                _repoObj.Update(requestorNameDat);
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
