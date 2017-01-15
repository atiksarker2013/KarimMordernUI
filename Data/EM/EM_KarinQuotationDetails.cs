using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EM
{
   public class EM_KarinQuotationDetails
    {
        public static tbl_KarimQuotationDetails ConvertToEntity(KarimSalesDetails model)
        {
            tbl_KarimQuotationDetails entity = new tbl_KarimQuotationDetails();

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

            entity.DeliveryDate = model.DeliveryDate;
            entity.DeliveryTime = model.DeliveryTime;
            
            return entity;
        }
    }
}
