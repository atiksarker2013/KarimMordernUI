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
    
    public partial class tbl_KarimBookPriceUpdate
    {
        public int Id { get; set; }
        public Nullable<int> BookId { get; set; }
        public Nullable<decimal> OldPrice { get; set; }
        public Nullable<decimal> NewPrice { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    }
}