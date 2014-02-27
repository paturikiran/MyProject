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
    public class GTAResultsController : ApiController
    {
        private DocumentContext _context = new DocumentContext();
        readonly IDocAsmAssignmentsRepository _repoObj = new DocAsmAssignmentsRepository();
        public DOCUS_ASM_GET_GTA_FIELDS_Result GetGTA(int accountNumber)
        {
            return _repoObj.GetGTA(accountNumber);
        }
    }
}
