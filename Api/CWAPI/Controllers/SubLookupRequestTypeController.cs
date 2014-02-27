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
    public class SubLookupRequestTypeController : ApiController
    {
        private DocumentContext _context = new DocumentContext();
        readonly IDocSubLookupRequestTypeRepository _repoObj = new DocSubLookupRequestTypeRepository();

        [HttpGet]
        public IEnumerable<DOCUS_SUB_LOOKUP_REQUEST_TYPE> GetDOCUS_SUB_REQUEST()
        {
            return _repoObj.GetAll();
        }

        // GET api/Sub_Request/5
        [HttpGet]
        public IEnumerable<DOCUS_SUB_LOOKUP_REQUEST_TYPE> GetDOCUS_SUB_REQUEST(int id)
        {
            return _repoObj.Get(id);
        }

        [HttpPost]
        public void Inset([FromBody] DOCUS_SUB_LOOKUP_REQUEST_TYPE subLookupRequestTypeData)
        {
            _repoObj.Insert(subLookupRequestTypeData);
        }

        [HttpPut]
        public bool Update([FromBody] DOCUS_SUB_LOOKUP_REQUEST_TYPE subLookupRequestTypeData)
        {
            bool result = true;
            try
            {
                _repoObj.Update(subLookupRequestTypeData);
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
