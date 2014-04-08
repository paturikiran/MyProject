using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CWAPI.DAL;
using CWAPI.Models;
using CWAPI.Repository.IRepo;
using CWAPI.Repository.Repo;



namespace CWAPI.Controllers
{
    public class LookupController : ApiController
    {
        private ICreateLookup _lookup;

        public LookupController()
        {
            _lookup = new CreateLookup();
        }


        public int Create(LookupModel lookup)
        {
            return _lookup.Create(lookup);
        }

        [HttpPut]
        public int Update(LookupModel lookup)
        {
            return _lookup.Delete(lookup);
        }
    }
}
