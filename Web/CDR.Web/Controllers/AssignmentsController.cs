using System.Runtime.Remoting.Messaging;
using System.Web.Helpers;
using CDR.Web.Agents;
using CDR.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CDR.Web.Models.LookupModels;
using StructureMap.Query;

namespace CDR.Web.Controllers
{
    public class AssignmentsController : Controller
    {
        private IAssignments _assignment;
        private ICustodianDetails _custodian;
        private ILookupModel _lookupModel;
        private IAssignmentLookupAgent _assignmentLookup;
        public AssignmentsController(IAssignments assignment, ICustodianDetails custodian, ILookupModel lookupModel, IAssignmentLookupAgent assignmentLookup)
        {
            _assignment = assignment;
            _custodian = custodian;
            _lookupModel = lookupModel;
            _assignmentLookup = assignmentLookup;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAssignmentsById(int Id)
        {
            var results = _assignment.GetAssignments(Id);
            TempData["Assignments"] = results;
            return PartialView("_Assignments", results);
        }

        public ActionResult GetDetails(int assignmentId, int accountNumber,string type)
        {
            var details = new DOCUS_ASM_ASSIGNMENTS();
            var results = new List<DOCUS_ASM_ASSIGNMENTS>();
            if (TempData["Assignments"] != null)
            {
                results = TempData["Assignments"] as List<DOCUS_ASM_ASSIGNMENTS>;
            }
            else
            {
                results = _assignment.GetAssignments(accountNumber) as List<DOCUS_ASM_ASSIGNMENTS>;
            }
            details = results.Where(x => x.ACCOUNT_NUMBER == accountNumber && x.ASSIGNMENT_ID == assignmentId).FirstOrDefault();
            ViewData["TransactionType"] = "Update";
            if (type == "recordedAssignments")
            {
                details.IsNewRecordedAssignemnt = false;
                return PartialView("_RecordedAssignments", details);
            }
            else if (type == "newRecord")
            {
                details.IsNewRecordedAssignemnt = true;
                return PartialView("_RecordedAssignments", details);
            }
            return PartialView("_AssignmentDetails", details);
        }

        public JsonResult AddOrUpdate(DOCUS_ASM_ASSIGNMENTS assignment)
        {
           JsonResult result = new JsonResult();

            if (ModelState.IsValid)
            {
                //return _assignment.Create(assignment);
                switch (assignment.TransactionType)
                {
                    case "New Request":
                        var response= _assignment.Create(assignment);
                        result = Json(new {data = response ? "Record Created Successuflly" : "Error Occurred",IsSuccess=result});
                        break;
                    default:
                        var update= _assignment.Update(assignment);
                        result= Json(new { data = update ? "Record Updated Successuflly" : "Error Occurred",IsSuccess= result });
                        break;
                }
            }
            else
            {
                var errors  = ModelState.Where(x => x.Value.Errors.Count > 0);
                result = Json(new {data = errors,IsSuccess = false});
            }
            return result;
        }

        public ActionResult Create()
        {
            var assignment = mock();
            assignment.TransactionType = "New";
            ViewData["TransactionType"] = "New Request";
            return View(assignment);
        }

        public ActionResult Search()
        {
            return View();
        }

        private DOCUS_ASM_ASSIGNMENTS mock()
        {
            var obj = new DOCUS_ASM_ASSIGNMENTS();
            obj.UPDATED_BY = "abcd";
            obj.CREATED_BY = "bcde";
            obj.DATE_CREATED = DateTime.Now;
            obj.DATE_UPDATED = DateTime.Now;
            return obj;
        }

        public ActionResult GetCustodianDetails(int accountNumber)
        {
           var custodianDetails = _custodian.Get(accountNumber);
            return Json(new {data= custodianDetails});
        }

        public JsonResult AddLookUpValue(LookupModel model)
        {
            model.Section = "ASM";
            var result = _lookupModel.Create(model);
            IEnumerable<AssignmentLookup> lookupData = new List<AssignmentLookup>();

            if (!result) return Json(new {data = lookupData, IsSuccess = false});
            switch (model.Type)
            {
                case  "Requestor Name":
                    lookupData = _assignmentLookup.RequestorName;
                    break;
                case "Assigned To":
                    lookupData = _assignmentLookup.AssignedTo;
                    break;
                default:
                    lookupData = new List<AssignmentLookup>();
                    break;
            }
            return Json(new {data = lookupData,IsSuccess =true});
        }

        public ActionResult LoadjqData(string sidx, string sord, int page, int rows,
               bool _search, string searchField, string searchOper, string searchString, int accountNumber)
        {
            var results = _assignment.GetAssignments(accountNumber);
            var totalRecords = results.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / (double)rows);

            var jsonData = new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = results.Skip((page - 1) * rows).Take(rows)
            };

            return Json(jsonData);
        }

       
    }
}
