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
    public class AsmLookupEnteredByController : ApiController
    {
        private DocumentContext _context = new DocumentContext();
        readonly IDocAsmLookupEnteredByRepository _repoObj = new DocAsmLookupEnteredByRepository();

        [HttpGet]
        public IEnumerable<DOCUS_ASM_LOOKUP_ENTERED_BY> GetDocAsmLookupEnteredBy()
        {
            return _repoObj.GetAll();
        }

        // GET api/Sub_Request/5
        [HttpGet]
        public IEnumerable<DOCUS_ASM_LOOKUP_ENTERED_BY> GetDocAsmLookupEnteredById(int id)
        {
            return _repoObj.Get(id);
        }

        [HttpPost]
        public void Inset([FromBody] DOCUS_ASM_LOOKUP_ENTERED_BY enteredByData)
        {
            _repoObj.Insert(enteredByData);
        }

        [HttpPut]
        public bool Update([FromBody] DOCUS_ASM_LOOKUP_ENTERED_BY enteredByData)
        {
            bool result = true;
            try
            {
                _repoObj.Update(enteredByData);
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
