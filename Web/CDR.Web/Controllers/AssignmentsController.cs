using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Web.Helpers;
using CDR.Web.Agents;
using CDR.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CDR.Web.Models.LookupModels;
using Microsoft.Ajax.Utilities;
using StructureMap;
using StructureMap.Query;
using WebGrease.Css.Extensions;

namespace CDR.Web.Controllers
{
    public class AssignmentsController : Controller
    {
        private IAssignments _assignment;
        private ICustodianDetails _custodian;
        private ILookupModel _lookupModel;
        private INotes _notes;
        private IAssignmentLookupAgent _assignmentLookup;
        public AssignmentsController(IAssignments assignment, ICustodianDetails custodian, ILookupModel lookupModel, IAssignmentLookupAgent assignmentLookup, INotes notes)
        {
            _assignment = assignment;
            _custodian = custodian;
            _lookupModel = lookupModel;
            _assignmentLookup = assignmentLookup;
            _notes = notes;
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

        public ActionResult GetDetails(int assignmentId, int accountNumber, string type)
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

                var notesTobeSaved = new AssignmentNotes();
                var notesResponse = true;
                if (!assignment.Notes.IsNullOrWhiteSpace())
                {

                    notesTobeSaved.ASSIGNMENT_ID = assignment.ASSIGNMENT_ID;
                    notesTobeSaved.NOTE = assignment.Notes;
                }
                //return _assignment.Create(assignment);
                switch (assignment.TransactionType)
                {
                    case "New Request":
                        // assignment.DATE_ENTERED = DateTime.Now.To
                        var response = _assignment.Create(assignment);
                        if (!assignment.Notes.IsNullOrWhiteSpace())
                        {
                            notesTobeSaved.ASSIGNMENT_ID = response;
                            notesResponse = _notes.SaveNotes(notesTobeSaved);
                        }
                        result =
                              Json(
                                  new
                                  {
                                      data =
                                          response > 0 && notesResponse ? "Record Created Successuflly" : "Error Occurred",
                                      IsSuccess = result
                                  });
                        //RedirectToAction("Index", "Home",new{ id = assignment.ACCOUNT_NUMBER});
                        break;
                    default:
                        var update = _assignment.Update(assignment);
                        if (!assignment.Notes.IsNullOrWhiteSpace())
                            notesResponse = _notes.SaveNotes(notesTobeSaved);
                        result = Json(new { data = update && notesResponse ? "Record Updated Successuflly" : "Error Occurred", IsSuccess = result });
                        //RedirectToAction("Index", "Home", new { id = assignment.ACCOUNT_NUMBER });
                        break;
                }


            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Count > 0);
                result = Json(new { data = errors, IsSuccess = false });
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
            var defaultDate = DateTime.Now.Date;
            obj.DATE_ENTERED = defaultDate.ToShortDateString();
            //obj.LAST_STATUS_DATE = defaultDate.ToShortDateString();
            // obj.REQUEST_DATE = defaultDate.ToShortDateString();
            //obj.DATE_CREATED = defaultDate;
            //obj.COLLATERAL_FILE_REQUEST_DATE = defaultDate.ToShortDateString();
            //obj.LAST_STATUS_DATE = defaultDate.ToShortDateString();
            //obj.FOLLOW_UP_DATE = defaultDate.ToShortDateString();
            //obj.SALE_DATE = defaultDate.ToShortDateString();
            //obj.DATE_UPDATED = defaultDate;
            obj.MERS_INDICATOR = false;
            obj.MERS_UPDATED = false;
            return obj;
        }

        public ActionResult GetCustodianAndNotesDetails(int accountNumber, int assignmentId)
        {
            var custodianDetails = _custodian.Get(accountNumber);
            List<string> sb = new List<string>();

            if (assignmentId != null && assignmentId > 0)
            {
                var notes = _notes.Get(assignmentId);
                if (notes.Any())
                {

                    foreach (var note in notes)
                    {
                        sb.Add(note.NOTE);
                    }
                }
            }
            return Json(new { custodianDetails = custodianDetails, notes = sb });
        }

        public JsonResult AddLookUpValue(LookupModel model)
        {
            model.Section = "ASM";
            bool result;
            if (model.Transaction.Equals("Delete"))
            {
                result = _lookupModel.Update(model);
            }
            else
            {
                result = _lookupModel.Create(model);
            }
            IEnumerable<AssignmentLookup> lookupData = new List<AssignmentLookup>();

            if (!result) return Json(new { data = lookupData, IsSuccess = false });
            switch (model.Type)
            {
                case "Requestor Name":
                    lookupData = _assignmentLookup.RequestorName;
                    break;
                case "Request Type":
                    lookupData = _assignmentLookup.RequestType;
                    break;
                case "Request Reason":
                    lookupData = _assignmentLookup.RequestReason;
                    break;
                case "Doc Type":
                    lookupData = _assignmentLookup.DocumentType;
                    break;
                case "Status":
                    lookupData = _assignmentLookup.Status;
                    break;
                case "Assigned To":
                    lookupData = _assignmentLookup.AssignedTo;
                    break;
                default:
                    lookupData = new List<AssignmentLookup>();
                    break;
            }
            return Json(new { data = lookupData, IsSuccess = true });
        }

        public ActionResult LoadjqData(string sidx, string sord, int page, int rows,
               bool _search, string searchField, string searchOper, string searchString, int accountNumber)
        {
            var results = _assignment.GetAssignments(accountNumber);

            var totalRecords = results.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / (double)rows);
            if (sidx == "DATE_ENTERED" && sord != null)
            {
                if (sord == "asc")
                    results = results.OrderBy(x => x.DATE_ENTERED);
                else
                    results = results.OrderByDescending(x => x.DATE_ENTERED);
            }
            var jsonData = new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = results.Skip((page - 1) * rows).Take(rows)
            };

            return Json(jsonData);
        }

        public ActionResult Reports()
        {
            return View();
        }

    }
}
