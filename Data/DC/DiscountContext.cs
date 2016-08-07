using Data.EM;
using Models;
using System.Data.Entity.Infrastructure;

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
    }
}
