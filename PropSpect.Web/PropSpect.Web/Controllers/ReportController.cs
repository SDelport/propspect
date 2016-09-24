using PropSpect.Web.Controllers.PDF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropSpect.Web.Controllers
{
    public class ReportController : Controller
    {
        [Route("report/inoutinspection/{InspectionID}")]
        public FileContentResult GetInOutInspectionReport(int InspectionID)
        {
            PDFManager pdfManager = new PDFManager(Server);
            InOutInspectionPDF inspectionPdf = new InOutInspectionPDF(pdfManager);
            inspectionPdf.GeneratePDF(InspectionID);


            // return the actual PDF
            string fileName = "test.pdf";
            FileContentResult reportResult = GetFileContent(fileName);

            return reportResult;           
            
        }

        public FileContentResult GetFileContent(string fileName)
        {
            string filepath = Path.Combine(Server.MapPath("~/Resources/PDF"), fileName);
            byte[] filedata = System.IO.File.ReadAllBytes(filepath);
            string contentType = MimeMapping.GetMimeMapping(filepath);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = fileName,
                Inline = true,
            };

            Response.AppendHeader("Content-Disposition", cd.ToString());

            return File(filedata, contentType);
        }
    }
}