﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class KARIM_INT_HOUSTONEEntities : DbContext
    {
        public KARIM_INT_HOUSTONEEntities()
            : base("name=KARIM_INT_HOUSTONEEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_Discount> tbl_Discount { get; set; }
        public virtual DbSet<tbl_BookPriceUpdate> tbl_BookPriceUpdate { get; set; }
        public virtual DbSet<tbl_NewEntryQty> tbl_NewEntryQty { get; set; }
        public virtual DbSet<tbl_DarusSalamBook> tbl_DarusSalamBook { get; set; }
        public virtual DbSet<tbl_SalesDetails> tbl_SalesDetails { get; set; }
        public virtual DbSet<tbl_NewBookEntry> tbl_NewBookEntry { get; set; }
        public virtual DbSet<tbl_ReceiveDue> tbl_ReceiveDue { get; set; }
        public virtual DbSet<tbl_Sales> tbl_Sales { get; set; }
    
        public virtual ObjectResult<USP_GetBookList_Result> USP_GetBookList(string searchStr)
        {
            var searchStrParameter = searchStr != null ?
                new ObjectParameter("SearchStr", searchStr) :
                new ObjectParameter("SearchStr", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_GetBookList_Result>("USP_GetBookList", searchStrParameter);
        }
    }
}
