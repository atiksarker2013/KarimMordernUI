using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EM
{
    public static class EM_KarimSales
    {
        public static KarimSales ConverToModel(tbl_KarimSales entity)
        {
            KarimSales model = new KarimSales();

            model.Id = entity.Id;
            model.Name = entity.Name;
            model.Mobile = entity.Mobile;
            model.Address = entity.Address;
            model.Date = entity.Date;
            model.PayType = entity.PayType;
            model.PayNo = entity.PayNo;
            model.Total = entity.Total ?? 0;
            model.Discount = entity.Discount ?? 0;
            model.GrandTotal = entity.GrandTotal ?? 0;
            model.Receive = entity.Receive ?? 0;
            model.Due = entity.Due ?? 0;
            model.CuriarCharg = entity.CuriarCharg ?? 0;
            model.CustomerRefNo = entity.CustomerRefNo;
            model.KarimRefNo = entity.KarimRefNo;

            return model;
        }

        public static tbl_KarimSales ConvertToEntity(KarimSales model)
        {
            tbl_KarimSales entity = new tbl_KarimSales();

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
