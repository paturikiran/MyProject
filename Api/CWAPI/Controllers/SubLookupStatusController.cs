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
    public class SubLookupStatusController : ApiController
    {
        private DocumentContext _context = new DocumentContext();
        readonly IDocSubLookupStatusRepository _repoObj = new DocSubLookupStatusRepository();

        [HttpGet]
        public IEnumerable<DOCUS_SUB_LOOKUP_STATUS> GetStatus()
        {
            return _repoObj.GetAll();
        }

        // GET api/Sub_Request/5
        [HttpGet]
        public IEnumerable<DOCUS_SUB_LOOKUP_STATUS> GetStatusById(int id)
        {
            return _repoObj.Get(id);
        }

        [HttpPost]
        public void Inset([FromBody] DOCUS_SUB_LOOKUP_STATUS statusData)
        {
            _repoObj.Insert(statusData);
        }

        [HttpPut]
        public bool Update([FromBody] DOCUS_SUB_LOOKUP_STATUS statusData)
        {
            bool result = true;
            try
            {
                _repoObj.Update(statusData);
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
