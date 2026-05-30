using System.Text;
using UglyToad.PdfPig;

namespace SalesInvoiceExtPdf.Services
{
    public class PdfService
    {
        public string ExtractText(Stream stream)
        {
            StringBuilder sb = new();

            using (PdfDocument document = PdfDocument.Open(stream))
            {
                foreach (var page in document.GetPages())
                {
                    sb.AppendLine(page.Text);
                }
            }

            return sb.ToString();
        }
    }
}
