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
  public  class BookStockUpdateContext
    {
        KARIM_INT_HOUSTONEEntities _db = new KARIM_INT_HOUSTONEEntities();


        public int Insert(NewBookStockUpdate SalesModel)
        {
            tbl_NewEntryQty _salesModel = EM_NewBookStockUpdate.ConvertToEntity(SalesModel);
            _db.tbl_NewEntryQty.Add(_salesModel);

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
