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
    public class AsmLookupRequestTypeController : ApiController
    {
        private DocumentContext _context = new DocumentContext();
        readonly IDocAsmLookupRequestTypeRepository _repoObj = new DocAsmLookupRequestTypeRepository();

        [HttpGet]
        public IEnumerable<DOCUS_ASM_LOOKUP_REQUEST_TYPE> GetDocAsmLookupRequestType()
        {
            return _repoObj.GetAll();
        }

        // GET api/Sub_Request/5
        [HttpGet]
        public IEnumerable<DOCUS_ASM_LOOKUP_REQUEST_TYPE> GetDocAsmLookupRequestTypeById(int id)
        {
            return _repoObj.Get(id);
        }

        [HttpPost]
        public void Inset([FromBody] DOCUS_ASM_LOOKUP_REQUEST_TYPE requestTypeData)
        {
            _repoObj.Insert(requestTypeData);
        }

        [HttpPut]
        public bool Update([FromBody] DOCUS_ASM_LOOKUP_REQUEST_TYPE requestTypeData)
        {
            bool result = true;
            try
            {
                _repoObj.Update(requestTypeData);
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
