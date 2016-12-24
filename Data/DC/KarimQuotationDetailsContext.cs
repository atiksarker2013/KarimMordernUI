using Data.EM;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DC
{
   public class KarimQuotationDetailsContext
    {
        KARIM_INT_HOUSTONEEntities _db = new KARIM_INT_HOUSTONEEntities();

        public void Insert(KarimSalesDetails salesDetails)
        {
            tbl_KarimQuotationDetails _salesDetailsModel = EM_KarinQuotationDetails.ConvertToEntity(salesDetails);
            _db.tbl_KarimQuotationDetails.Add(_salesDetailsModel);

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
