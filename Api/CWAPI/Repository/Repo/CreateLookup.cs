using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CWAPI.Models;
using CWAPI.Repository.IRepo;
using CWAPI.DAL;
using CWAPI.Repository.IRepo;

namespace CWAPI.Repository.Repo
{
    public class CreateLookup: ICreateLookup
    {
        readonly DocumentContext _context = new DocumentContext();
        public int Create(LookupModel model)
        {
            return _context.DOCUS_SYS_ADD_LOOKUP_VALUE(model.Section,model.Type,model.Value);
        }

        public int Delete(LookupModel model)
        {
            return _context.DOCUS_SYS_DELETE_LOOKUP_SOFT(model.Id);
        }
    }
}