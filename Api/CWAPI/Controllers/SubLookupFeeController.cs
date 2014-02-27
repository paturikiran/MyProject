﻿using System;
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
    public class SubLookupFeeController : ApiController
    {
        private DocumentContext _context = new DocumentContext();
        readonly IDocSubLookupFeeRepository _repoObj = new DocSubLookupFeeRepository();

        [HttpGet]
        public IEnumerable<DOCUS_SUB_LOOKUP_FEE> GetLookupFees()
        {
            return _repoObj.GetAll();
        }

        // GET api/Sub_Request/5
        [HttpGet]
        public IEnumerable<DOCUS_SUB_LOOKUP_FEE> GetLookupFeesById(int id)
        {
            return _repoObj.Get(id);
        }

        [HttpPost]
        public void Inset([FromBody] DOCUS_SUB_LOOKUP_FEE feeData)
        {
            _repoObj.Insert(feeData);
        }

        [HttpPut]
        public bool Update([FromBody] DOCUS_SUB_LOOKUP_FEE feeData)
        {
            bool result = true;
            try
            {
                _repoObj.Update(feeData);
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
