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
    public class AsmLookupDocTypeController : ApiController
    {
        private DocumentContext _context = new DocumentContext();
        readonly IDocAsmLookupDocTypeRepository _repoObj = new DocAsmLookupDocTypeRepository();

        [HttpGet]
        public IEnumerable<DOCUS_ASM_LOOKUP_DOC_TYPE> GetDocAsmLookupDocType()
        {
            //var repo = new CustomRepository.Repository();
            //repo.CreateContextInstance();

            return _repoObj.GetAll();
        }

        // GET api/Sub_Request/5
        [HttpGet]
        public IEnumerable<DOCUS_ASM_LOOKUP_DOC_TYPE> GetDocAsmLookupDocTypeById(int id)
        {
            return _repoObj.Get(id);
        }

        [HttpPost]
        public void Inset([FromBody] DOCUS_ASM_LOOKUP_DOC_TYPE docTypeData)
        {
            _repoObj.Insert(docTypeData);
        }

        [HttpPut]
        public bool Update([FromBody] DOCUS_ASM_LOOKUP_DOC_TYPE docTypeData)
        {
            bool result = true;
            try
            {
                _repoObj.Update(docTypeData);
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
