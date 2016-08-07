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

        //public void Update(BookPriceUpdate drugupdateoptionsModel)
        //{
        //    tbl_BookPriceUpdate drugupdateoptionsEntity = EM_BookPriceUpdate.ConvertToEntity(drugupdateoptionsModel);
        //    var originalEntity = _db.tbl_BookPriceUpdate.FirstOrDefault(x => x.Id == drugupdateoptionsEntity.Id);
        //    if (originalEntity != null) { _db.Entry(originalEntity).CurrentValues.SetValues(drugupdateoptionsEntity); }

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateException ue)
        //    {
        //        //  HandleException(ue);
        //    }
        //}

    }
}
