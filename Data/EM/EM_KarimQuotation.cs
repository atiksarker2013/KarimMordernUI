using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EM
{
   public class EM_KarimQuotation
    {
        public static tbl_KarimQuotation ConvertToEntity(KarimSales model)
        {
            tbl_KarimQuotation entity = new tbl_KarimQuotation();

            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.Mobile = model.Mobile;
            entity.Address = model.Address;
            entity.Date = model.Date;
            entity.PayType = model.PayType;
            entity.PayNo = model.PayNo;
            entity.Total = model.Total;
            entity.Discount = model.Discount;
            entity.OtherDiscount = model.OtherDiscount;
            entity.GrandTotal = model.GrandTotal;
            entity.Receive = model.Receive;
            entity.Due = model.Due;
            entity.CuriarCharg = model.CuriarCharg;
            entity.CustomerRefNo = model.CustomerRefNo;
            entity.KarimRefNo = model.KarimRefNo;

            return entity;
        }
    }
}
