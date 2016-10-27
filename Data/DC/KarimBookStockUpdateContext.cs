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
   public class KarimBookStockUpdateContext
    {
        KARIM_INT_HOUSTONEEntities _db = new KARIM_INT_HOUSTONEEntities();


        public int Insert(KarimNewBookStockUpdate SalesModel)
        {
            tbl_KarimNewEntryQty _salesModel = EM_KarimNewbookStockUpdate.ConvertToEntity(SalesModel);
            _db.tbl_KarimNewEntryQty.Add(_salesModel);

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

        public List<KarimNewBookStockUpdate> GetStockUpdateBookListByDateRange(DateTime fromDate, DateTime toDate)
        {
            List<tbl_KarimNewEntryQty> result = (from c in _db.tbl_KarimNewEntryQty.Where(t => t.EntryDate > fromDate && t.EntryDate < toDate) select c).ToList();
            List<KarimNewBookStockUpdate> list = result.Select(n => EM_KarimNewbookStockUpdate.ConverToModel(n)).ToList();
            return list;
        }
    }
}
