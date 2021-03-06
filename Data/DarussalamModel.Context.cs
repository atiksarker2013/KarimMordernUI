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
        public virtual DbSet<tbl_SalesDetails> tbl_SalesDetails { get; set; }
        public virtual DbSet<tbl_NewBookEntry> tbl_NewBookEntry { get; set; }
        public virtual DbSet<tbl_ReceiveDue> tbl_ReceiveDue { get; set; }
        public virtual DbSet<tbl_KarimNewEntryQty> tbl_KarimNewEntryQty { get; set; }
        public virtual DbSet<tbl_KarimNewBookEntry> tbl_KarimNewBookEntry { get; set; }
        public virtual DbSet<tbl_KarimBookPriceUpdate> tbl_KarimBookPriceUpdate { get; set; }
        public virtual DbSet<tbl_Sales> tbl_Sales { get; set; }
        public virtual DbSet<tbl_KarimCurrency> tbl_KarimCurrency { get; set; }
        public virtual DbSet<tbl_KarimSales> tbl_KarimSales { get; set; }
        public virtual DbSet<tbl_KarimQuotation> tbl_KarimQuotation { get; set; }
        public virtual DbSet<tbl_KarimBook> tbl_KarimBook { get; set; }
        public virtual DbSet<tbl_KarimQuotationDetails> tbl_KarimQuotationDetails { get; set; }
        public virtual DbSet<tbl_KarimSalesDetails> tbl_KarimSalesDetails { get; set; }
        public virtual DbSet<tbl_KarimReceiveDue> tbl_KarimReceiveDue { get; set; }
        public virtual DbSet<tbl_DarusSalamBook> tbl_DarusSalamBook { get; set; }
    
        public virtual ObjectResult<USP_GetBookList_Result> USP_GetBookList(string searchStr)
        {
            var searchStrParameter = searchStr != null ?
                new ObjectParameter("SearchStr", searchStr) :
                new ObjectParameter("SearchStr", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_GetBookList_Result>("USP_GetBookList", searchStrParameter);
        }
    
        public virtual ObjectResult<USP_GetCustomerInfoByMobile_Result> USP_GetCustomerInfoByMobile(string searchStr)
        {
            var searchStrParameter = searchStr != null ?
                new ObjectParameter("SearchStr", searchStr) :
                new ObjectParameter("SearchStr", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_GetCustomerInfoByMobile_Result>("USP_GetCustomerInfoByMobile", searchStrParameter);
        }
    
        public virtual ObjectResult<USP_GetKarimBookList_Result> USP_GetKarimBookList(string searchStr)
        {
            var searchStrParameter = searchStr != null ?
                new ObjectParameter("SearchStr", searchStr) :
                new ObjectParameter("SearchStr", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_GetKarimBookList_Result>("USP_GetKarimBookList", searchStrParameter);
        }
    
        public virtual ObjectResult<USP_GetKarimBookWithBdPriceList_Result> USP_GetKarimBookWithBdPriceList(string searchStr)
        {
            var searchStrParameter = searchStr != null ?
                new ObjectParameter("SearchStr", searchStr) :
                new ObjectParameter("SearchStr", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_GetKarimBookWithBdPriceList_Result>("USP_GetKarimBookWithBdPriceList", searchStrParameter);
        }
    
        public virtual ObjectResult<USP_GetKarimBookWithBdPriceListALL_Result> USP_GetKarimBookWithBdPriceListALL(string searchStr, string subject)
        {
            var searchStrParameter = searchStr != null ?
                new ObjectParameter("SearchStr", searchStr) :
                new ObjectParameter("SearchStr", typeof(string));
    
            var subjectParameter = subject != null ?
                new ObjectParameter("subject", subject) :
                new ObjectParameter("subject", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_GetKarimBookWithBdPriceListALL_Result>("USP_GetKarimBookWithBdPriceListALL", searchStrParameter, subjectParameter);
        }
    
        public virtual ObjectResult<USP_GetKarimBookWithBdPriceListALLSubjectWise_Result> USP_GetKarimBookWithBdPriceListALLSubjectWise(string subject)
        {
            var subjectParameter = subject != null ?
                new ObjectParameter("subject", subject) :
                new ObjectParameter("subject", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_GetKarimBookWithBdPriceListALLSubjectWise_Result>("USP_GetKarimBookWithBdPriceListALLSubjectWise", subjectParameter);
        }
    }
}
