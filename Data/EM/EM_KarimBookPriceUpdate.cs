using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EM
{
   
    public static class EM_KarimBookPriceUpdate
    {
        public static KarimBookPriceUpdate ConverToModel(tbl_KarimBookPriceUpdate entity)
        {
            KarimBookPriceUpdate model = new KarimBookPriceUpdate();

            model.Id = entity.Id;
            model.BookId = entity.BookId ?? 0;
            model.OldPrice = entity.OldPrice ?? 0;
            model.NewPrice = entity.NewPrice ?? 0;
            model.UpdateDate = entity.UpdateDate;
            return model;
        }

        public static tbl_KarimBookPriceUpdate ConvertToEntity(KarimBookPriceUpdate model)
        {
            tbl_KarimBookPriceUpdate entity = new tbl_KarimBookPriceUpdate();

            entity.Id = model.Id;
            entity.BookId = model.BookId;
            entity.OldPrice = model.OldPrice;
            entity.NewPrice = model.NewPrice;
            entity.UpdateDate = model.UpdateDate;
            return entity;
        }
    }
}
