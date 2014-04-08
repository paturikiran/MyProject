using CDR.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CDR.Web.Controllers
{
    public class SubRequestSearchUpdateController : Controller
    {
        private ISubRequest _request;

        public SubRequestSearchUpdateController(ISubRequest subRequest)
        {
            _request = subRequest;
        }

        //
        // GET: /SubRequest/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(int id)
        {
            var result = _request.GetSubRequestByID(id);
            TempData["records"] = result;
            return PartialView("_SubRequestSearchResults", result);
        }


        public ActionResult Create()
        {
            var newReqest = new DOCUS_SUB_REQUEST();
            return View(newReqest);
        }

        public ActionResult LoadjqData(string sidx, string sord, int page, int rows,
                bool _search, string searchField, string searchOper, string searchString, int accountNumber)
        {
            var results = _request.GetSubRequestByID(accountNumber);
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

        public ActionResult GetSubDocuments(int id)
        {
            var subRequestSearchResults = new SubReqSearchUpdateViewModel();
            var results = subRequestSearchResults.GetAllLoans().Where(x => x.LoanAccountNumber == id);

            return PartialView("subRequestSearchResults", results);
        }

        public ActionResult GetSubRequestDetails(int id, int loanNumber)
        {
            var result = new DOCUS_SUB_REQUEST();
            if (TempData["records"] != null)
            {
                var records = TempData["records"] as IEnumerable<DOCUS_SUB_REQUEST>;
                result = records.FirstOrDefault(x => x.ID == id && x.GT_Loan_Number == loanNumber);
            }
            else
                result = _request.GetSubRequestDetails(id, loanNumber);

            return PartialView("_SubRequestDetails", result);
        }

        public string UpdateSubRequest(DOCUS_SUB_REQUEST model)
        {
            string result = "";
            if (ModelState.IsValid)
            {
                try
                {
                    if (_request.UpdateSubRequest(model))
                        result = "success";
                }
                catch (Exception ex)
                {
                    result = "error";
                }
            }
            return result;
        }


        public string CreateNewRequest(DOCUS_SUB_REQUEST model)
        {
            var result = "";
            if (ModelState.IsValid)
            {
                try
                {
                    if (_request.CreateSubRequest(model))
                        result = "Request Created Successfully";
                }
                catch (Exception ex)
                {
                    result = "Error";
                }
            }
            return result;
        }

    }

}
