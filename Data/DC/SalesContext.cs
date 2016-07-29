using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Data.EM;
using System.Data.Entity.Infrastructure;

namespace Data.DC
{
   public class SalesContext
    {
        KARIM_INT_HOUSTONEEntities _db = new KARIM_INT_HOUSTONEEntities();

        public int Insert(Sales SalesModel)
        {
            tbl_Sales _salesModel = EM_Sales.ConvertToEntity(SalesModel);
            _db.tbl_Sales.Add(_salesModel);

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
