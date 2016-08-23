using Data.EM;
using Models;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Data.DC
{
    public class DarussalamBookContext
    {
        KARIM_INT_HOUSTONEEntities _db = new KARIM_INT_HOUSTONEEntities();

        public List<DarusSalamBook> GetDarusSalamBookLookupList(string startsWith = "")
        {
            List<tbl_DarusSalamBook> result = (from c in _db.tbl_DarusSalamBook orderby c.Title where c.Title.StartsWith(startsWith) select c).Take(20).ToList();
            List<DarusSalamBook> list = result.Select(n => EM_DarusSalamBook.ConverToModel(n)).ToList();
            return list;
        }

        public void Update(DarusSalamBook drugupdateoptionsModel)
        {
            tbl_DarusSalamBook drugupdateoptionsEntity = EM_DarusSalamBook.ConvertToEntity(drugupdateoptionsModel);
            var originalEntity = _db.tbl_DarusSalamBook.FirstOrDefault(x => x.Id == drugupdateoptionsEntity.Id);
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

        public void Insert(DarusSalamBook darusSalamBook)
        {

            tbl_NewBookEntry _BookModel = EM_NewBookEntry.ConvertToEntity(darusSalamBook);
            _db.tbl_NewBookEntry.Add(_BookModel);
            // insert in to main stock
            tbl_DarusSalamBook _darussalamBookModel = EM_DarusSalamBook.ConvertToEntity(darusSalamBook);
            _db.tbl_DarusSalamBook.Add(_darussalamBookModel);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateException ue)
            {
                // HandleException(ue);
            }

        }

        public List<SalesDetails> GetBookDetailsByInvoiceNo(int id)
        {
            List<tbl_SalesDetails> result = (from c in _db.tbl_SalesDetails.Where(t => t.SalesId == id) select c).ToList();
            List<SalesDetails> list = result.Select(n => EM_SalesDetails.ConverToModel(n)).ToList();
            return list;
        }

        public List<DarusSalamBook> GetBookInfoByBookId(int id)
        {
            List<tbl_DarusSalamBook> result = (from c in _db.tbl_DarusSalamBook.Where(t => t.Id == id) select c).ToList();
            List<DarusSalamBook> list = result.Select(n => EM_DarusSalamBook.ConverToModel(n)).ToList();
            return list;
        }
    }
}
