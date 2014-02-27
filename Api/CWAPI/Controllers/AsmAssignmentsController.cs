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
    public class AsmAssignmentsController : ApiController
    {
        private DocumentContext _context = new DocumentContext();
        readonly IDocAsmAssignmentsRepository _repoObj = new DocAsmAssignmentsRepository();

        [HttpGet]
        public IEnumerable<DOCUS_ASM_ASSIGNMENTS> GetDocAsmAssignments()
        {
            return _repoObj.GetAll();
        }

        // GET api/Sub_Request/5
        [HttpGet]
        public IEnumerable<DOCUS_ASM_ASSIGNMENTS> GetDocAsmAssignmentsById(int id)
        {
            return _repoObj.Get(id);
        }

        [HttpPost]
        public void Insert(DOCUS_ASM_ASSIGNMENTS assignmentsRequest)
        {
            _repoObj.Insert(assignmentsRequest);

        }

        [HttpPut]
        public bool Update([FromBody] DOCUS_ASM_ASSIGNMENTS assignmentsRequest)
        {
            bool result = true;
            _repoObj.Update(assignmentsRequest);
            return result;
        }
        
        public DOCUS_ASM_GET_GTA_FIELDS_Result GetGTA(int accountNumber)
        {
            return _repoObj.GetGTA(accountNumber);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
    }
}
