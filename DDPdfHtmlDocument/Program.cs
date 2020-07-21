using GrapeCity.Documents.Html;
using GrapeCity.Documents.Pdf;
using System.Drawing;

namespace DDPdfHtmlDocument
{
    class Program
    {
        static void Main(string[] args)
        {
            //GcPdfDocument.SetLicenseKey("");

            var doc = new GcPdfDocument();
            var page = doc.NewPage();
            var g = page.Graphics;

            var html = "<!DOCTYPE html>" +
            "<html>" +
            "<head>" +
            "<style>" +
            "p.round {" +
            "font: 28px Yu Gothic;" +
            "color: Blue;" +
            "padding: 3px 5px 3px 5px;" +
            "}" +
            "</style>" +
            "</head>" +
            "<body>" +
            "<p class='round'>Hello, World!</p>" +
            "<p class='round'>こんにちは、DioDocs（ディオドック）です</p>" +
            "</body>" +
            "</html>";

            g.DrawHtml(html,
                       72,
                       72,
                       new HtmlToPdfFormat(false),
                       out SizeF size);

            doc.Save("HTMLStringToPDF.pdf");

            var gcHtmlRenderer = new GcHtmlRenderer(html);
            gcHtmlRenderer.RenderToJpeg("HTMLStringToImage.jpeg", new JpegSettings());
            gcHtmlRenderer.RenderToPng("HTMLStringToImage.png", new PngSettings());
        }
    }
}
