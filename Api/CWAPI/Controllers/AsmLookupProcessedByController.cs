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
    public class AsmLookupProcessedByController : ApiController
    {
        private DocumentContext _context = new DocumentContext();
        readonly IDocAsmLookupProcessedByRepository _repoObj = new DocAsmLookupProcessedByRepository();

        [HttpGet]
        public IEnumerable<DOCUS_ASM_LOOKUP_PROCESSED_BY> GetDocAsmLookupProcessedBy()
        {
            return _repoObj.GetAll();
        }

        // GET api/Sub_Request/5
        [HttpGet]
        public IEnumerable<DOCUS_ASM_LOOKUP_PROCESSED_BY> GetDocAsmLookupProcessedById(int id)
        {
            return _repoObj.Get(id);
        }

        [HttpPost]
        public void Inset([FromBody] DOCUS_ASM_LOOKUP_PROCESSED_BY processedByData)
        {
            _repoObj.Insert(processedByData);
        }

        [HttpPut]
        public bool Update([FromBody] DOCUS_ASM_LOOKUP_PROCESSED_BY processedByData)
        {
            bool result = true;
            try
            {
                _repoObj.Update(processedByData);
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
