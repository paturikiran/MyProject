using CDR.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CDR.Web.Controllers
{
    public class SearchProcessorController : Controller
    {
        private ISubRequest _request;
        public SearchProcessorController(ISubRequest subRequest)
        {
            _request = subRequest;
        }
        //
        // GET: /SearchProcessor/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadjqData(string sidx, string sord, int page, int rows,
                     bool _search, string searchField, string searchOper, string searchString, int representativeId)
        {

            var results = _request.GetSubRequestByRepresentative(representativeId);
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

        public void ExportSubRequestToExcel(int representativeId)
        {
            var records = _request.GetSubRequestByRepresentative(representativeId);
            GridView gv = new GridView();
            gv.DataSource = records;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=InitiatedEmployees.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);

            byte[] byteArray = Encoding.ASCII.GetBytes(sw.ToString());
            MemoryStream s = new MemoryStream(byteArray);
            StreamReader sr = new StreamReader(s, Encoding.ASCII);

            Response.Write(sr.ReadToEnd());
            Response.Flush();
            Response.End();
            //return RedirectToAction("Index");
        }

    }

}

