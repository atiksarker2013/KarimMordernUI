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
    }
}
