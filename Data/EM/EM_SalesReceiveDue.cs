using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EM
{
   public static class EM_SalesReceiveDue
    {
        public static tbl_ReceiveDue ConvertToEntity(SalesReceiveDue model)
        {
            tbl_ReceiveDue entity = new tbl_ReceiveDue();

          //  entity.Id = model.Id;
            entity.SaleInvoiceId = model.SalesInvoiceId;
            entity.CustomerInvoiceId = model.CustomerInvoiceId;
            entity.ReceiveAmount = model.ReceiveAmount;
            entity.ReceiveDate = model.ReceiveDate;

            return entity;
        }

        public static tbl_KarimReceiveDue ConvertToEntityKarim(SalesReceiveDue model)
        {
            tbl_KarimReceiveDue entity = new tbl_KarimReceiveDue();

            //  entity.Id = model.Id;
            entity.SaleInvoiceId = model.SalesInvoiceId;
            entity.CustomerInvoiceId = model.CustomerInvoiceId;
            entity.ReceiveAmount = model.ReceiveAmount;
            entity.ReceiveDate = model.ReceiveDate;

            return entity;
        }

        internal static SalesReceiveDue ConverToModel(tbl_ReceiveDue model)
        {
            SalesReceiveDue entity = new SalesReceiveDue();
            entity.Id = model.Id;
            entity.SalesInvoiceId = (int)model.SaleInvoiceId;
            entity.CustomerInvoiceId = model.CustomerInvoiceId;
            entity.ReceiveAmount = (decimal)model.ReceiveAmount;
            entity.ReceiveDate = (DateTime)model.ReceiveDate;
            return entity;
        }
    }
}
