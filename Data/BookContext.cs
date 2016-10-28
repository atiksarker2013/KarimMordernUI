using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Data.EM;

namespace Data
{
    public class BookContext
    {
        public KARIM_INT_HOUSTONEEntities _db;

        public BookContext()
        {
            _db = new KARIM_INT_HOUSTONEEntities();
        }
        public List<DarusSalamBook> GetAllBookListLookup(string title)
        {
            return (from c in _db.tbl_DarusSalamBook
                    where c.Title.StartsWith(title)
                    orderby c.Title

                    select new DarusSalamBook
                    {
                        Id = c.Id,
                        Title = c.Title,
                        Writer = c.Writer,
                        Publisher = c.Publisher,
                        Qty = (int)c.Qty,
                        Price = (decimal)c.Price,
                        OutOfStock = (int)c.OutOfStock,
                        InStock = (int)c.InStock,
                        Barcode = c.Barcode

                    }).ToList();

        }

        public List<DarusSalamBook> GetDarusSalamBookLookupList(string startsWith = "")
        {
            List<USP_GetBookList_Result> drugNameLookUpList = _db.USP_GetBookList(startsWith).ToList();
            List<DarusSalamBook> bodrugNameLookUpList = drugNameLookUpList.Select(n => EM_DarusSalamBook.ConvertToModel(n)).ToList();
            return bodrugNameLookUpList;
           
        }

        public List<DarusSalamBook> GetAllBookListForUpdateLookup(string title)
        {
            return (from c in _db.tbl_DarusSalamBook
                    where c.Title.StartsWith(title)
                    orderby c.Title

                    select new DarusSalamBook
                    {
                        Id = c.Id,
                        Title = c.Title,
                        Writer = c.Writer,
                        Publisher = c.Publisher,
                        Qty = (int)c.Qty,
                        Price = (decimal)c.Price,
                        OutOfStock = (int)c.OutOfStock,
                        InStock = (int)c.InStock,
                        Barcode = c.Barcode

                    }).Take(15).ToList();

        }

        public List<DarusSalamBook> GetAllBookListREportLookup(string title)
        {
            return (from c in _db.tbl_DarusSalamBook
                    where c.Title.StartsWith(title)
                    orderby c.Title

                    select new DarusSalamBook
                    {
                        Id = c.Id,
                        Title = c.Title,
                        Writer = c.Writer,
                        Publisher = c.Publisher,
                        Qty = (int)c.Qty,
                        Price = (decimal)c.Price,
                        OutOfStock = (int)c.OutOfStock,
                        InStock = (int)c.InStock,
                        Barcode = c.Barcode

                    }).ToList();

        }

        public List<DarusSalamBook> GetAllBookListLookup()
        {
            return (from c in _db.tbl_DarusSalamBook
                   // where c.Title.StartsWith(title)
                    orderby c.Title

                    select new DarusSalamBook
                    {
                        Id = c.Id,
                        Title = c.Title,
                        Writer = c.Writer,
                        Publisher = c.Publisher,
                        Qty = (int)c.Qty,
                        Price = (decimal)c.Price,
                        OutOfStock = (int)c.OutOfStock,
                        InStock = (int)c.InStock,
                        Barcode = c.Barcode

                    }).ToList();

        }

        public List<KarimBook> GetAllKarimBookListForUpdateLookup(string title)
        {
            return (from c in _db.tbl_KarimBook
                    where c.Title.StartsWith(title)
                    orderby c.Title

                    select new KarimBook
                    {
                        Id = c.Id,
                        Title = c.Title,
                        Writer = c.Writer,
                        Publisher = c.Publisher,
                        Qty = (int)c.Qty,
                        PublisherPrice = (decimal)c.PublisherPrice,
                        Price = (decimal)c.Price,
                        OutOfStock = (int)c.OutOfStock,
                        InStock = (int)c.InStock,
                        Barcode = c.Barcode,
                       // PublishYear=(int)c.PublishYear,
                        PublisherUnit=c.PublisherUnit,
                        BookType=c.BookType

                    }).Take(15).ToList();

        }

        public List<KarimBook> GetKarimBookLookupList(string startsWith = "")
        {
            List<USP_GetKarimBookList_Result> drugNameLookUpList = _db.USP_GetKarimBookList(startsWith).ToList();
            List<KarimBook> bodrugNameLookUpList = drugNameLookUpList.Select(n => EM_KarimBook.ConvertToModel(n)).ToList();
            return bodrugNameLookUpList;

        }

        public List<KarimBook> GetAllKarimBookListLookup(string title)
        {
            return (from c in _db.tbl_KarimBook
                    where c.Title.StartsWith(title)
                    orderby c.Title

                    select new KarimBook
                    {
                        Id = c.Id,
                        Title = c.Title,
                        Writer = c.Writer,
                        Publisher = c.Publisher,
                        Qty = (int)c.Qty,
                        Price = (decimal)c.Price,
                        OutOfStock = (int)c.OutOfStock,
                        InStock = (int)c.InStock,
                        Barcode = c.Barcode

                    }).ToList();

        }
    }
}
