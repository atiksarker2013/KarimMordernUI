using Models;

namespace Data.EM
{
    public static class EM_NewBookStockUpdate
    {
        public static NewBookStockUpdate ConverToModel(tbl_NewEntryQty entity)
        {
            NewBookStockUpdate model = new NewBookStockUpdate();
            model.Id = entity.Id;
            model.BookId = entity.BookId ?? 0;
             
            model.OldStock = entity.OldStock ?? 0;
            model.NewEntryQty = entity.NewEntryQty ?? 0;
            model.EntryDate = entity.EntryDate;
            return model;
        }

        public static tbl_NewEntryQty ConvertToEntity(NewBookStockUpdate model)
        {
            tbl_NewEntryQty entity = new tbl_NewEntryQty();
            entity.BookId = model.BookId;
            entity.OldStock = model.OldStock;
            entity.NewEntryQty = model.NewEntryQty;
            entity.EntryDate = model.EntryDate;
           
            return entity;
        }
    }
}
