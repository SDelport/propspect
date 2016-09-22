using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
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


        public void GeneratePDF()
        {
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

            //Inspection Detais
            currentSection = "Inspection Details";
            
            p.GenerateHeadingBlock(currentSection,page, gfx, currentWidth, currentLine);
            

            // Create a font
            XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);

            // Draw the text            
            gfx.DrawString("In-Out Inspection", font, XBrushes.Black,
            new XRect(0, 0, page.Width, page.Height),
            XStringFormats.Center);

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
            rect.Inflate(0,-18);
            gfx.DrawString("Date: " + DateTime.Now.ToString("yyyy-MM-dd"), p.Font14, XBrushes.Black, rect, XStringFormats.TopCenter);

            //Customer Logo
            filename = Path.Combine(p.ServerProperty.MapPath("~/Content/Images"), "olea.png");
            image = XImage.FromFile(filename);
            gfx.DrawImage(image, page.Width-20-120, 20, 120, 50);


            //Footer




            
            rect.Offset(0, 5);
            XStringFormat format = new XStringFormat();
            format.Alignment = XStringAlignment.Near;
            format.LineAlignment = XLineAlignment.Far;
            gfx.DrawString("Copyright: Paideia Solutions 2016", p.Font8Italic, XBrushes.Black, rect, format);

            
            format.Alignment = XStringAlignment.Far;
            gfx.DrawString(document.PageCount.ToString(), p.Font8Italic, XBrushes.Black, rect, format);

            document.Outlines.Add(title, page, true);

        }
    }
}