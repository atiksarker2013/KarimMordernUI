using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Shared;

namespace Data.EM
{
   public class EM_KarimBook
    {
        public static KarimBook ConverToModel(tbl_KarimBook entity)
        {
            KarimBook model = new KarimBook();

            model.Id = entity.Id;
            model.Title = entity.Title.TrimWithNull();
            model.Writer = entity.Writer.TrimWithNull();
            model.Publisher = entity.Publisher.TrimWithNull();
            model.Barcode = entity.Barcode.TrimWithNull();
            model.Qty = entity.Qty ?? 0;
            model.Price = entity.Price ?? 0;
            model.PublisherPrice = entity.PublisherPrice ?? 0;
            model.PublisherUnit = entity.PublisherUnit.TrimWithNull();
            model.PublishYear = entity.PublishYear;
            model.BookType = entity.BookType.TrimWithNull();
            model.OutOfStock = entity.OutOfStock ?? 0;
            model.InStock = entity.InStock ?? 0;
            model.EntryDate = entity.EntryDate;

            return model;
        }

        //internal static DarusSalamBook ConvertToModel(USP_GetBookList_Result entity)
        //{
        //    DarusSalamBook model = new DarusSalamBook();

        //    model.Id = entity.Id;
        //    model.Title = entity.Title.TrimWithNull();
        //    model.Writer = entity.Writer.TrimWithNull();
        //    model.Publisher = entity.Publisher.TrimWithNull();
        //    model.Barcode = entity.Barcode.TrimWithNull();
        //    model.Qty = entity.Qty ?? 0;
        //    model.Price = entity.Price ?? 0;
        //    model.OutOfStock = entity.OutOfStock ?? 0;
        //    model.InStock = entity.InStock ?? 0;
        //    model.EntryDate = entity.EntryDate;

        //    return model;
        //}

        public static tbl_KarimBook ConvertToEntity(KarimBook model)
        {
            tbl_KarimBook entity = new tbl_KarimBook();

            entity.Id = model.Id;
            entity.Title = model.Title;
            entity.Writer = model.Writer;
            entity.Publisher = model.Publisher;
            entity.Qty = model.Qty;
            entity.Price = model.Price;


            entity.PublisherPrice = model.PublisherPrice;
            entity.PublisherUnit = model.PublisherUnit;
            entity.PublishYear = model.PublishYear;
            entity.BookType = model.BookType;

            entity.Barcode = model.Barcode;
            entity.OutOfStock = model.OutOfStock;
            entity.InStock = model.InStock;
            entity.EntryDate = model.EntryDate;


            return entity;
        }
    }
}
