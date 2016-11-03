using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EM
{
    public static class EM_KarinSalesDetails
    {
        public static KarimSalesDetails ConverToModel(tbl_KarimSalesDetails entity)
        {
            KarimSalesDetails model = new KarimSalesDetails();

            model.Id = entity.Id;
            model.SalesId = entity.SalesId ?? 0;
            model.BookId = entity.BookId ?? 0;
            model.OrderQty = entity.OrderQty ?? 0;
            model.ReturnQty = entity.ReturnQty ?? 0;
            model.Price = entity.Price ?? 0;

            model.CustomerSlNo = entity.CustomerSlNo;
            model.UnitDiscountPercent = entity.UnitDiscountPercent ?? 0;
            model.DiscountTaka = entity.DiscountTaka ?? 0;
            model.NetTaka = entity.NetTaka ?? 0;

            return model;
        }

        public static tbl_KarimSalesDetails ConvertToEntity(KarimSalesDetails model)
        {
            tbl_KarimSalesDetails entity = new tbl_KarimSalesDetails();

            entity.Id = model.Id;
            entity.SalesId = model.SalesId;
            entity.BookId = model.BookId;
            entity.OrderQty = model.OrderQty;
            entity.ReturnQty = model.ReturnQty;
            entity.Price = model.Price;

            entity.CustomerSlNo = model.CustomerSlNo;
            entity.UnitDiscountPercent = model.UnitDiscountPercent;
            entity.DiscountTaka = model.DiscountTaka;
            entity.NetTaka = model.NetTaka;

            return entity;
        }
    }
}
