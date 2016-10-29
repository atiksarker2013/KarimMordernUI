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
  public  class KarimBookPriceUpdateContext
    {
        KARIM_INT_HOUSTONEEntities _db = new KARIM_INT_HOUSTONEEntities();


        public int Insert(KarimBookPriceUpdate SalesModel)
        {
            tbl_KarimBookPriceUpdate _salesModel = EM_KarimBookPriceUpdate.ConvertToEntity(SalesModel);
            _db.tbl_KarimBookPriceUpdate.Add(_salesModel);

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



        public List<KarimBookPriceUpdate> GetBookPriceUpdateListByDateRange(DateTime fromDate, DateTime toDate)
        {
            List<tbl_KarimBookPriceUpdate> result = (from c in _db.tbl_KarimBookPriceUpdate.Where(t => t.UpdateDate > fromDate && t.UpdateDate < toDate) select c).ToList();
            List<KarimBookPriceUpdate> list = result.Select(n => EM_KarimBookPriceUpdate.ConverToModel(n)).ToList();
            return list;
        }
    }
}
