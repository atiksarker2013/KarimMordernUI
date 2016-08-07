using Models;

namespace Data.EM
{
    public static class EM_BookPriceUpdate
    {
        public static BookPriceUpdate ConverToModel(tbl_BookPriceUpdate entity)
        {
            BookPriceUpdate model = new BookPriceUpdate();

            model.Id = entity.Id;
            model.BookId = entity.BookId ?? 0;
            model.OldPrice = entity.OldPrice ?? 0;
            model.NewPrice = entity.NewPrice ?? 0;
            model.UpdateDate = entity.UpdateDate;
            return model;
        }

        public static tbl_BookPriceUpdate ConvertToEntity(BookPriceUpdate model)
        {
            tbl_BookPriceUpdate entity = new tbl_BookPriceUpdate();

            entity.Id = model.Id;
            entity.BookId = model.BookId;
            entity.OldPrice = model.OldPrice;
            entity.NewPrice = model.NewPrice;
            entity.UpdateDate = model.UpdateDate;
            return entity;
        }
    }
}
