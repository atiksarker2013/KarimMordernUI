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
        public decimal TotalUnitPrice { get; set; }
        public int Id { get; set; }
        public string PayNo { get; set; }
        public int? BookId { get; set; }
        public int? ReturnQty { get; set; }
        public decimal? UnitDiscountPercent { get; set; }
        public decimal? BookPrice { get; set; }
        public int? OutOfStock { get; set; }
        public int? InStock { get; set; }
        public string PublisherUnit { get; set; }
        public string BookType { get; set; }
        public bool IsCustomerSlNo { get; set; }
        public bool IsTitle { get; set; }
        public bool IsWriter { get; set; }
        public bool IsPublisher { get; set; }
        public bool IsBarcode { get; set; }
        public bool IsBookType { get; set; }
        public bool IsPublisherPrice { get; set; }
        public bool IsPublisherUnit { get; set; }
        public bool IsPrice { get; set; }
        public bool IsInStock { get; set; }
        public bool IsOrderQty { get; set; }
        public bool IsTotalUnitPrice { get; set; }
        public bool IsUnitDiscountPercent { get; set; }
        public bool IsDiscountTaka { get; set; }


        //public string BookType { get; set; }
        public string Edition { get; set; }
        public string BookBinding { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryTime { get; set; }
    }
}
