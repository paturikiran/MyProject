using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http;
using CWAPI.DAL;
using CWAPI.Repository.IRepo;
using CWAPI.Repository.Repo;

namespace CWAPI.Controllers
{
    public class SubLookupLoanTypeController : ApiController
    {
        private DocumentContext _context = new DocumentContext();
        readonly IDocSubLookupLoanTypeRepository _repoObj = new DocSubLookupLoanTypeRepository();

        [HttpGet]
        public IEnumerable<DOCUS_SUB_LOOKUP_LOAN_TYPE> GetSubLookupLoanTypes()
        {
            return _repoObj.GetAll();
        }

        // GET api/Sub_Request/5
        [HttpGet]
        public IEnumerable<DOCUS_SUB_LOOKUP_LOAN_TYPE> GetSubLookupLoanTypesById(int id)
        {
            return _repoObj.Get(id);
        }

        [HttpPost]
        public void Inset([FromBody] DOCUS_SUB_LOOKUP_LOAN_TYPE loanTypeData)
        {
            _repoObj.Insert(loanTypeData);
        }

        [HttpPut]
        public bool Update([FromBody] DOCUS_SUB_LOOKUP_LOAN_TYPE loanTypeData)
        {
            bool result = true;
            try
            {
                _repoObj.Update(loanTypeData);
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
