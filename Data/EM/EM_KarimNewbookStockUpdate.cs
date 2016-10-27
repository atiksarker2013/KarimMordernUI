using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EM
{
  public static  class EM_KarimNewbookStockUpdate
    {
        public static KarimNewBookStockUpdate ConverToModel(tbl_KarimNewEntryQty entity)
        {
            KarimNewBookStockUpdate model = new KarimNewBookStockUpdate();
            model.Id = entity.Id;
            model.BookId = entity.BookId ?? 0;

            model.OldStock = entity.OldStock ?? 0;
            model.NewEntryQty = entity.NewEntryQty ?? 0;
            model.EntryDate = entity.EntryDate;
            return model;
        }

        public static tbl_KarimNewEntryQty ConvertToEntity(KarimNewBookStockUpdate model)
        {
            tbl_KarimNewEntryQty entity = new tbl_KarimNewEntryQty();
            entity.BookId = model.BookId;
            entity.OldStock = model.OldStock;
            entity.NewEntryQty = model.NewEntryQty;
            entity.EntryDate = model.EntryDate;

            return entity;
        }
    }
}
