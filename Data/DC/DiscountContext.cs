using Data.EM;
using Models;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Data.DC
{
    public  class DiscountContext
    {
        KARIM_INT_HOUSTONEEntities _db = new KARIM_INT_HOUSTONEEntities();

        public int Insert(Discounts SalesModel)
        {
            tbl_Discount _salesModel = EM_Discount.ConvertToEntity(SalesModel);
            _db.tbl_Discount.Add(_salesModel);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateException ue)
            {
                // HandleException(ue);
            }
            return _salesModel.Id;
        }

        public List<Discounts> GetBookDiscountByInvoiceNo(int id)
        {
            List<tbl_Discount> result = (from c in _db.tbl_Discount.Where(t => t.InvoiceId == id) select c).ToList();
            List<Discounts> list = result.Select(n => EM_Discount.ConverToModel(n)).ToList();
            return list;
        }
    }
}
