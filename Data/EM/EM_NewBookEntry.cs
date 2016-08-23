using Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EM
{
   public static class EM_NewBookEntry
    {
        public static DarusSalamBook ConverToModel(tbl_NewBookEntry entity)
        {
            DarusSalamBook model = new DarusSalamBook();

            model.Id = entity.Id;
            model.Title = entity.Title.TrimWithNull();
            model.Writer = entity.Writer.TrimWithNull();
            model.Publisher = entity.Publisher.TrimWithNull();
            model.Barcode = entity.Barcode.TrimWithNull();
            model.Qty = entity.Qty ?? 0;
            model.Price = entity.Price ?? 0;
            model.OutOfStock = entity.OutOfStock ?? 0;
            model.InStock = entity.InStock ?? 0;
            model.EntryDate = entity.EntryDate;

            return model;
        }

        public static tbl_NewBookEntry ConvertToEntity(DarusSalamBook model)
        {
            tbl_NewBookEntry entity = new tbl_NewBookEntry();

            entity.Id = model.Id;
            entity.Title = model.Title;
            entity.Writer = model.Writer;
            entity.Publisher = model.Publisher;
            entity.Qty = model.Qty;
            entity.Price = model.Price;
            entity.Barcode = model.Barcode;
            entity.OutOfStock = model.OutOfStock;
            entity.InStock = model.InStock;
            entity.EntryDate = model.EntryDate;


            return entity;
        }
    }
}
