namespace SalesInvoiceExtPdf.Models
{
    public class SalesItems
    {
        public int Id { get; set; }

        public int Sid { get; set; }

        public string ItemName { get; set; }

        public string ItemDesc { get; set; }

        public int Qty { get; set; }

        public decimal Rate { get; set; }

        public decimal Amt { get; set; }
        public SalesMaster SalesMaster { get; set; }
    }
}
