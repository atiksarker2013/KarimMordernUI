using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EM
{
  public static  class EM_Discount
    {
        public static Discounts ConverToModel(tbl_Discount entity)
        {
            Discounts model = new Discounts();
            model.Id = entity.Id;
            model.InvoiceId = entity.InvoiceId ?? 0;
            model.PublisherName = entity.PublisherName;
            model.TotalAmount = entity.TotalAmount ?? 0;
            model.DiscountPercentage = entity.DiscountPercentage ?? 0;
            model.DiscountAmount = entity.DiscountAmount ?? 0;
            return model;
        }

        public static tbl_Discount ConvertToEntity(Discounts model)
        {
            tbl_Discount entity = new tbl_Discount();
            entity.InvoiceId = model.InvoiceId;
            entity.PublisherName = model.PublisherName;
            entity.TotalAmount = model.TotalAmount;
            entity.DiscountPercentage = model.DiscountPercentage;
            entity.DiscountAmount = model.DiscountAmount;
            return entity;
        }
    }
}
