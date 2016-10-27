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
   public class KarimBookContext
    {

        KARIM_INT_HOUSTONEEntities _db = new KARIM_INT_HOUSTONEEntities();



        public void Update(KarimBook drugupdateoptionsModel)
        {
            tbl_KarimBook drugupdateoptionsEntity = EM_KarimBook.ConvertToEntity(drugupdateoptionsModel);
            var originalEntity = _db.tbl_KarimBook.FirstOrDefault(x => x.Id == drugupdateoptionsEntity.Id);
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

        public void Insert(KarimBook darusSalamBook)
        {

            tbl_KarimNewBookEntry _BookModel = EM_KarimNewBookEntry.ConvertToEntity(darusSalamBook);
            _db.tbl_KarimNewBookEntry.Add(_BookModel);
            // insert in to main stock
            tbl_KarimBook _darussalamBookModel = EM_KarimBook.ConvertToEntity(darusSalamBook);
            _db.tbl_KarimBook.Add(_darussalamBookModel);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateException ue)
            {
                // HandleException(ue);
            }

        }

        public bool DoesExist(KarimBook obj)
        {
            List<tbl_KarimBook> result = (from c in _db.tbl_KarimBook.Where(t => t.Title == obj.Title && t.Writer == obj.Writer && t.Publisher == obj.Publisher) select c).ToList();

            if (result.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<SalesDetails> GetBookDetailsByInvoiceNo(int id)
        {
            List<tbl_SalesDetails> result = (from c in _db.tbl_SalesDetails.Where(t => t.SalesId == id) select c).ToList();
            List<SalesDetails> list = result.Select(n => EM_SalesDetails.ConverToModel(n)).ToList();
            return list;
        }

        public List<KarimBook> GetBookInfoByBookId(int id)
        {
            List<tbl_KarimBook> result = (from c in _db.tbl_KarimBook.Where(t => t.Id == id) select c).ToList();
            List<KarimBook> list = result.Select(n => EM_KarimBook.ConverToModel(n)).ToList();
            return list;
        }

        public List<KarimBook> GetNewBookAddBookListByDateRange(DateTime fromDate, DateTime toDate)
        {
            List<tbl_KarimBook> result = (from c in _db.tbl_KarimBook.Where(t => t.EntryDate > fromDate && t.EntryDate < toDate) select c).ToList();
            List<KarimBook> list = result.Select(n => EM_KarimBook.ConverToModel(n)).ToList();
            return list;
        }
    }
}
