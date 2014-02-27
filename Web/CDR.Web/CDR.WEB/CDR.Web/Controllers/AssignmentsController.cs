using CDR.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CDR.Web.Models.LookupModels;

namespace CDR.Web.Controllers
{
    public class AssignmentsController : Controller
    {
        private IAssignments _assignment;
        private ICustodianDetails _custodian;
        private IAssignmentLookup _assignmentLookup;
        public AssignmentsController(IAssignments assignment, ICustodianDetails custodian, IAssignmentLookup assignmentLookup)
        {
            _assignment = assignment;
            _custodian = custodian;
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

        public ActionResult GetDetails(int assignmentId, int accountNumber)
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
            return PartialView("_AssignmentDetails", details);
        }

        public bool AddOrUpdate(DOCUS_ASM_ASSIGNMENTS assignment)
        {
            if (ModelState.IsValid)
            {
                return _assignment.Update(assignment);
            }
            else
            {
                return false;
            }
        }

        public ActionResult Create()
        {
            var assignment = new DOCUS_ASM_ASSIGNMENTS();
            ViewData["TransactionType"] = "Create";
            return View(assignment);
        }

        public ActionResult GetCustodianDetails(int accountNumber)
        {
            var custodianDetails = _custodian.Get(accountNumber);
            return Json(new { data = custodianDetails });
        }

        public bool AddLookUpValue(string look)
        {
            return true;
        }

        public ActionResult GetAssignmentLookup(string LookupType)
        {
            IEnumerable<AssignmentLookup> lookup;
            switch (LookupType)
            {
                case "RequestorName":
                   lookup = _assignmentLookup.Get(Constants.ASMREQUESTORNAMELOOKUPURL);
            }
        }
    }
}
