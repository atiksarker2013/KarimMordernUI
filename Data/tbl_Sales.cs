//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Sales
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string PayType { get; set; }
        public string PayNo { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> OtherDiscount { get; set; }
        public Nullable<decimal> GrandTotal { get; set; }
        public Nullable<decimal> Receive { get; set; }
        public Nullable<decimal> Due { get; set; }
        public Nullable<decimal> CuriarCharg { get; set; }
    }
}
