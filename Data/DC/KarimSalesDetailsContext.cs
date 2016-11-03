using Data.EM;
using Models;
using System.Data.Entity.Infrastructure;

namespace Data.DC
{
    public class KarimSalesDetailsContext
    {
        KARIM_INT_HOUSTONEEntities _db = new KARIM_INT_HOUSTONEEntities();

        public void Insert(KarimSalesDetails salesDetails)
        {
            tbl_KarimSalesDetails _salesDetailsModel = EM_KarinSalesDetails.ConvertToEntity(salesDetails);
            _db.tbl_KarimSalesDetails.Add(_salesDetailsModel);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateException ue)
            {
                // HandleException(ue);
            }

        }
    }
}
