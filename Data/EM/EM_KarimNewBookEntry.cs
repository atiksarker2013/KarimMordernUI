using Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EM
{
   public static class EM_KarimNewBookEntry
    {
        public static KarimBook ConverToModel(tbl_KarimNewBookEntry entity)
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

        public static tbl_KarimNewBookEntry ConvertToEntity(KarimBook model)
        {
            tbl_KarimNewBookEntry entity = new tbl_KarimNewBookEntry();

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
