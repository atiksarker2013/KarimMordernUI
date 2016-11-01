using Data.EM;
using Models;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Data.DC
{
    public class KarimCurrencyContext
    {
        KARIM_INT_HOUSTONEEntities _db = new KARIM_INT_HOUSTONEEntities();

        public void Update(KarimCurrency drugupdateoptionsModel)
        {
            tbl_KarimCurrency drugupdateoptionsEntity = EM_KarimCurrency.ConvertToEntity(drugupdateoptionsModel);
            var originalEntity = _db.tbl_KarimCurrency.FirstOrDefault(x => x.Id == drugupdateoptionsEntity.Id);
            if (originalEntity != null) { _db.Entry(originalEntity).CurrentValues.SetValues(drugupdateoptionsEntity); }

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateException ue)
            {
                //  HandleException(ue);
            }
        }

        public List<KarimCurrency> GetAllCurrency()
        {
            List<tbl_KarimCurrency> result = (from c in _db.tbl_KarimCurrency select c).ToList();
            List<KarimCurrency> list = result.Select(n => EM_KarimCurrency.ConverToModel(n)).ToList();
            return list;
        }
    }
}
