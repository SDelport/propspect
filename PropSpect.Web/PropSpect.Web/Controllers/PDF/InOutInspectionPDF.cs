using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PropSpect.Api.Models.Response;
using PropSpect.Web.Controllers.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PropSpect.Web.Controllers.PDF
{
    public class InOutInspectionPDF
    {
        private PDFManager p;
        private double currentLine;
        private double currentWidth;
        private string currentSection;

        public InOutInspectionPDF(PDFManager manager)
        {
            p = manager;
        }


        public void GeneratePDF(int inspectionID)
        {
            //Initialise
            #region initialise
            // Create New PDF
            PdfDocument document = new PdfDocument();
            document.Info.Title = "In-Out Inspection Report";

            // Create an empty page
            PdfPage page = document.AddPage();
            page.Size = PageSize.A4;

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            //Create Header and set current height
            DrawHeaderAndFooter(document, page, gfx, "In-Out Inspection");
            currentLine = 80;
            currentWidth = 20;
            #endregion

            //Inspection Detais
            #region Inspection Details
            currentSection = "Inspection Details";

            p.GenerateHeadingBlock(currentSection, page, gfx, currentWidth, currentLine);
            currentLine += 35;

            gfx.DrawString("Address:", p.Font12Bold, XBrushes.Black, 40, currentLine);
            gfx.DrawString("163 Koedoe Street Wierda Park", p.Font12, XBrushes.Black, 120, currentLine);

            gfx.DrawString("Date of inspection:", p.Font12Bold, XBrushes.Black, page.Width / 2, currentLine);
            gfx.DrawString(DateTime.Now.ToString("yyyy-MM-dd"), p.Font12, XBrushes.Black, page.Width / 2 + 140, currentLine);

            currentLine += 15;

            gfx.DrawString("Tenant:", p.Font12Bold, XBrushes.Black, 40, currentLine);
            gfx.DrawString("Eckardt Briedenhann", p.Font12, XBrushes.Black, 120, currentLine);

            gfx.DrawString("Type of inspection:", p.Font12Bold, XBrushes.Black, page.Width / 2, currentLine);
            gfx.DrawString("In-Out Inspection", p.Font12, XBrushes.Black, page.Width / 2 + 140, currentLine);

            currentLine += 15;

            gfx.DrawString("Agent:", p.Font12Bold, XBrushes.Black, 40, currentLine);
            gfx.DrawString("Stefan Delport", p.Font12, XBrushes.Black, 120, currentLine);

            currentLine += 20;
            #endregion

            //Inspection Results
            #region Inspection Results
            currentSection = "Inspection Results";
            p.GenerateHeadingBlock(currentSection, page, gfx, currentWidth, currentLine);
            currentLine += 30;

            List<InspectionAreaResponse> Areas = new List<InspectionAreaResponse>();
            Areas = ApiWrapper.Get<List<InspectionAreaResponse>>($"/api/inspection/areas/{inspectionID}");


            //Per Area
            foreach (var inspectionArea in Areas)
            {
                AreaResponse area = ApiWrapper.Get<AreaResponse>($"/api/area/get/{inspectionArea.AreaID}");

                if (area != null)
                {
                    List<InspectionAreaItemResponse> areaItems = ApiWrapper.Get<List<InspectionAreaItemResponse>>($"/api/inspection/areaItems/{inspectionArea.InspectionAreaID}");

                    if (areaItems.Count > 0)
                    {
                        #region Table Generation
                        p.GenerateTitle(area.Name, page, gfx, currentWidth, currentLine);
                        currentLine += 30;

                        p.GenerateTableHeader(new string[]
                        {
                            "Area Item",
                            "Condition",
                            "Repair Needed"
                        }, page, gfx, currentWidth, currentLine);
                        currentLine += 14;
                        p.GenerateDivider(page, gfx, currentWidth, currentLine);
                        currentLine += 2;

                        foreach (var item in areaItems)
                        {
                            if (currentLine >= page.Height - 40)
                            {
                                p.CreateNewPage(ref document, ref page, ref gfx);
                                DrawHeaderAndFooter(document, page, gfx, "");
                                currentLine = 80;
                                p.GenerateTableHeader(new string[]
                                {
                                    "Area Item",
                                    "Condition",
                                    "Repair Needed"
                                }, page, gfx, currentWidth, currentLine);
                                currentLine += 14;
                                p.GenerateDivider(page, gfx, currentWidth, currentLine);
                                currentLine += 2;
                            }

                            p.GenerateTableRow(new string[]
                            {
                                item.ItemDescription,
                                item.ItemCondition,
                                item.ItemRepair
                            }, page, gfx, currentWidth, currentLine);
                            currentLine += 16;
                        }
                        p.GenerateDivider(page, gfx, currentWidth, currentLine);

                        currentLine += 30;
                        #endregion Table generation

                    }
                }
            }


            #endregion Inspection Details
            p.Save(document);
        }

        public void DrawHeaderAndFooter(PdfDocument document, PdfPage page, XGraphics gfx, string title)
        {
            //PropSpect Logo
            var filename = Path.Combine(p.ServerProperty.MapPath("~/Content/Images"), "PropSpect.png");
            XImage image = XImage.FromFile(filename);
            gfx.DrawImage(image, 20, 20, 120, 50);


            //Title Text
            XRect rect = new XRect(new XPoint(), gfx.PageSize);
            rect.Inflate(-10, -25);
            gfx.DrawString(title, p.Font16Bold, XBrushes.Black, rect, XStringFormats.TopCenter);

            //Title Date
            if (!string.IsNullOrEmpty(title))
            {
                rect.Inflate(0, -18);
                gfx.DrawString("Date: " + DateTime.Now.ToString("yyyy-MM-dd"), p.Font14, XBrushes.Black, rect, XStringFormats.TopCenter);
            }            

            //Customer Logo
            filename = Path.Combine(p.ServerProperty.MapPath("~/Content/Images"), "olea.png");
            image = XImage.FromFile(filename);
            gfx.DrawImage(image, page.Width - 20 - 120, 20, 120, 50);


            //Footer
            rect = new XRect(20, page.Height - 20, page.Width - 40, 10);
            XStringFormat format = new XStringFormat();
            format.Alignment = XStringAlignment.Near;
            format.LineAlignment = XLineAlignment.Far;
            gfx.DrawString("Copyright: Paideia Solutions 2016", p.Font8Italic, XBrushes.Black, rect, format);


            format.Alignment = XStringAlignment.Far;
            gfx.DrawString(document.PageCount.ToString(), p.Font8Italic, XBrushes.Black, rect, format);

            //document.Outlines.Add(title, page, true);
        }


    }
}