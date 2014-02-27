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
    public class AsmLookupProcessorNameController : ApiController
    {
        private DocumentContext _context = new DocumentContext();
        readonly IDocAsmLookupProcessorNameRepository _repoObj = new DocAsmLookupProcessorNameRepository();

        [HttpGet]
        public IEnumerable<DOCUS_ASM_LOOKUP_PROCESSOR_NAME> GetDocAsmLookupProcessedBy()
        {
            return _repoObj.GetAll();
        }

        // GET api/Sub_Request/5
        [HttpGet]
        public IEnumerable<DOCUS_ASM_LOOKUP_PROCESSOR_NAME> GetDocAsmLookupProcessedById(int id)
        {
            return _repoObj.Get(id);
        }

        [HttpPost]
        public void Inset([FromBody] DOCUS_ASM_LOOKUP_PROCESSOR_NAME processorName)
        {
            _repoObj.Insert(processorName);
        }

        [HttpPut]
        public bool Update([FromBody] DOCUS_ASM_LOOKUP_PROCESSOR_NAME processorName)
        {
            bool result = true;
            try
            {
                _repoObj.Update(processorName);
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
