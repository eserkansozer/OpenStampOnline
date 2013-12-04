using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using StampOnline.Models;

namespace StampOnline.FileAccess
{
    public class PdfManager : StampOnline.FileAccess.IPdfManager
    {
        PdfDocument _document;

        public PdfManager()
        {
            _document = new PdfDocument();
        }

        public string CreatePdf(OStamp stamp)
        {
            _document.Info.Title = "PDFsharp XGraphic Sample";
            _document.Info.Author = "Stefan Lange";
            _document.Info.Subject = "Created with code snippets that show the use of graphical functions";
            _document.Info.Keywords = "PDFsharp, XGraphics";

            SamplePage1(_document, stamp);

            var fileName = HttpContext.Current.Server.MapPath("~/App_Data/Pdfs/" + stamp.Id.ToString() + ".pdf");
            _document.Save(fileName);
            return fileName;
        }

        private void SamplePage1(PdfDocument document, OStamp stamp)
        {
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Verdana", 20, XFontStyle.Bold);

            foreach (var line in stamp.StampLines)
            {
                if (line.Text != null)
                    gfx.DrawString(line.Text, font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormat.Center);
            }
        }

    }
}