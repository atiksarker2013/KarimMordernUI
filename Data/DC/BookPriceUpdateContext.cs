using Data.EM;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Data.DC
{
    public class BookPriceUpdateContext
    {
        KARIM_INT_HOUSTONEEntities _db = new KARIM_INT_HOUSTONEEntities();


        public int Insert(BookPriceUpdate SalesModel)
        {
            tbl_BookPriceUpdate _salesModel = EM_BookPriceUpdate.ConvertToEntity(SalesModel);
            _db.tbl_BookPriceUpdate.Add(_salesModel);

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



        public List<BookPriceUpdate> GetBookPriceUpdateListByDateRange(DateTime fromDate, DateTime toDate)
        {
            List<tbl_BookPriceUpdate> result = (from c in _db.tbl_BookPriceUpdate.Where(t => t.UpdateDate > fromDate && t.UpdateDate < toDate) select c).ToList();
            List<BookPriceUpdate> list = result.Select(n => EM_BookPriceUpdate.ConverToModel(n)).ToList();
            return list;
        }
    }
}
