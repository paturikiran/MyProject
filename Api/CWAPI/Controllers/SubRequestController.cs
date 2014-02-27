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
    public class SubRequestController : ApiController
    {
        private DocumentContext _context = new DocumentContext();
        readonly IDocSubRequestRepository _repoObj = new DocSubRequestRepository();

        [HttpGet]
        public IEnumerable<DOCUS_SUB_REQUEST> GetDOCUS_SUB_REQUEST()
        {
            return _repoObj.GetAll();
        }

        // GET api/Sub_Request/5
        [HttpGet]
        public IEnumerable<DOCUS_SUB_REQUEST> GetDOCUS_SUB_REQUEST(int id)
        {
            return _repoObj.Get(id);
        }

        [HttpPost]
        public void Inset([FromBody] DOCUS_SUB_REQUEST subRequest)
        {
            _repoObj.Insert(subRequest);
        }

        [HttpPut]
        public bool Update([FromBody] DOCUS_SUB_REQUEST subRequest)
        {
            bool result = true;
            try
            {
                _repoObj.Update(subRequest);
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
