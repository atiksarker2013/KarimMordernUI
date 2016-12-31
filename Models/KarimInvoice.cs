using System;

namespace Models
{
    public class KarimInvoice
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }

        public string CustomerRefNo { get; set; }
        public string KarimRefNo { get; set; }
        public string PayType { get; set; }
        public decimal Total { get; set; }

        public decimal Discount { get; set; }
        public decimal OtherDiscount { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal Receive { get; set; }
        public decimal Due { get; set; }
        public decimal CuriarCharg { get; set; }
        public int OrderQty { get; set; }
        public decimal Price { get; set; }

        public string CustomerSlNo { get; set; }

        public decimal DiscountTaka { get; set; }

        public decimal NetTaka { get; set; }

        public string Title { get; set; }

        public string Writer { get; set; }
        public string Publisher { get; set; }

        public decimal Qty { get; set; }
        public decimal PublisherPrice { get; set; }

        public string Barcode { get; set; }

        public string PublishYear { get; set; }

        public string BookType { get; set; }
    }
}
