using Models;
using System.Data.Entity.Infrastructure;

namespace Data.DC
{
    public  class SalesDetailsContext
    {
        KARIM_INT_HOUSTONEEntities _db = new KARIM_INT_HOUSTONEEntities();

        public void Insert(SalesDetails salesDetails)
        {  
            tbl_SalesDetails _salesDetailsModel = EM_SalesDetails.ConvertToEntity(salesDetails);
            _db.tbl_SalesDetails.Add(_salesDetailsModel);

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
