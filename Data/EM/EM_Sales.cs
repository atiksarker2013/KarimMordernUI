using Models;
namespace Data.EM
{
    public static class EM_Sales
    {

        public static Sales ConverToModel(tbl_Sales entity)
        {
            Sales model = new Sales();

            model.Id = entity.Id ;
            model.Name = entity.Name ;
            model.Mobile = entity.Mobile ;
            model.Address = entity.Address ;
            model.Date = entity.Date;
            model.PayType = entity.PayType ;
            model.PayNo = entity.PayNo ;
            model.Total = entity.Total ?? 0;
            model.Discount = entity.Discount ?? 0;
            model.GrandTotal = entity.GrandTotal ?? 0;
            model.Receive = entity.Receive ?? 0;
            model.Due = entity.Due ?? 0;

            return model;
        }

        public static tbl_Sales ConvertToEntity(Sales model)
        {
            tbl_Sales entity = new tbl_Sales();

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

            return entity;
        }
    }
}