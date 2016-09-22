using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PropSpect.Web.Controllers.PDF
{
    public class PDFManager : Controller
    {
        //Pens
        public XPen PropspectPen { get; set; }

        //Brushes
        public XSolidBrush PropspectBrush { get; set; }

        //Fonts
        public XFont Font8 { get; set; }
        public XFont Font10 { get; set; }
        public XFont Font12 { get; set; }        
        public XFont Font14 { get; set; }       
        public XFont Font16 { get; set; }
        public XFont Font18 { get; set; }
        public XFont Font8Bold { get; set; }
        public XFont Font10Bold { get; set; }
        public XFont Font12Bold { get; set; }
        public XFont Font14Bold { get; set; }
        public XFont Font16Bold { get; set; }
        public XFont Font18Bold { get; set; }
        public XFont Font8Italic { get; set; }
        public XFont Font10Italic { get; set; }
        public XFont Font12Italic { get; set; }
        public XFont Font14Italic { get; set; }
        public XFont Font16Italic { get; set; }
        public XFont Font18Italic { get; set; }



        public HttpServerUtilityBase ServerProperty { get; set; }

        public PDFManager(HttpServerUtilityBase server)
        {
            ServerProperty = server;

            //Brushes
            InitializeBrushes();

            //Pens
            InitializePens();

            //Fonts
            InitializeFonts("Calibri");
        }
    

        public void Save (PdfDocument document)
        {
            // Save the document...  
            var filename = Path.Combine(ServerProperty.MapPath("~/Resources/PDF"), "test.pdf");
            document.Save(filename);

        }

        private void InitializeBrushes()
        {
            PropspectBrush = new XSolidBrush(XColor.FromCmyk(0.5424, 0.0508, 0, 0.3059));

        }

        public void InitializePens()
        {
            PropspectPen = new XPen(XColor.FromCmyk(0.5424, 0.0508, 0, 0.3059));
        }

        public void InitializeFonts(string font)
        {
            //Regular
            Font8 = new XFont(font, 8, XFontStyle.Regular);
            Font10 = new XFont(font, 10, XFontStyle.Regular);
            Font12 = new XFont(font, 12, XFontStyle.Regular);
            Font14 = new XFont(font, 14, XFontStyle.Regular);
            Font16 = new XFont(font, 16, XFontStyle.Regular);
            Font18 = new XFont(font, 18, XFontStyle.Regular);

            //Bold
            Font8Bold = new XFont(font, 8, XFontStyle.Bold);
            Font10Bold = new XFont(font, 10, XFontStyle.Bold);
            Font12Bold = new XFont(font, 12, XFontStyle.Bold);
            Font14Bold = new XFont(font, 14, XFontStyle.Bold);
            Font16Bold = new XFont(font, 16, XFontStyle.Bold);
            Font18Bold = new XFont(font, 18, XFontStyle.Bold);

            //Italic
            Font8Italic = new XFont(font, 8, XFontStyle.Italic);
            Font10Italic = new XFont(font, 10, XFontStyle.Italic);
            Font12Italic = new XFont(font, 12, XFontStyle.Italic);
            Font14Italic = new XFont(font, 14, XFontStyle.Italic);
            Font16Italic = new XFont(font, 16, XFontStyle.Italic);
            Font18Italic = new XFont(font, 18, XFontStyle.Italic);
        }

        public void GenerateHeadingBlock(string title, PdfPage page, XGraphics gfx, double currentWidth, double currentLine)
        {
            XRect headerRect = new XRect(currentWidth, currentLine, page.Width - currentWidth * 2, 17);
            gfx.DrawRectangle(PropspectBrush, currentWidth, currentLine, page.Width - currentWidth * 2, 18);
            gfx.DrawString(title, Font16Bold, XBrushes.White, headerRect, XStringFormats.Center);
        }
        

    }
}