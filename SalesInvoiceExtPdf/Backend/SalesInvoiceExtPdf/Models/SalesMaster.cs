namespace SalesInvoiceExtPdf.Models
{
    public class SalesMaster
    {
        public int Id { get; set; }

        public string OrderID { get; set; }

        public string BillTo { get; set; }

        public string ShipTo { get; set; }

        public DateTime? InvDate { get; set; }

        public string ShipMode { get; set; }

        public decimal DiscPrc { get; set; }

        public decimal Shipping { get; set; }

        public List<SalesItems> Items { get; set; } = new();

        public DateTime? UploadedDate { get; set; }

        public string UploadedBy { get; set; }
    }
}
