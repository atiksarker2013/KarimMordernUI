using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Data.EM;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace Data.DC
{
    public class SalesContext
    {
        KARIM_INT_HOUSTONEEntities _db = new KARIM_INT_HOUSTONEEntities();

        public int Insert(Sales SalesModel)
        {
            try
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
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
           
        }

        public List<Sales> GetSalesHistoryByDateRange(DateTime fromDate, DateTime toDate)
        {
            List<tbl_Sales> result = (from c in _db.tbl_Sales.Where(t => t.Date > fromDate && t.Date < toDate) select c).OrderByDescending(m=>m.Date).ToList();
            List<Sales> list = result.Select(n => EM_Sales.ConverToModel(n)).ToList();
            return list;
        }

        public void InsertDueReceive(SalesReceiveDue salesObj)
        {
            tbl_ReceiveDue _salesModel = EM_SalesReceiveDue.ConvertToEntity(salesObj);
            _db.tbl_ReceiveDue.Add(_salesModel);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateException ue)
            {
                // HandleException(ue);
            }
           // return _salesModel.Id;
        }
        public void UpdateDue(Sales drugupdateoptionsModel)
        {
            tbl_Sales drugupdateoptionsEntity = EM_Sales.ConvertToEntity(drugupdateoptionsModel);
            var originalEntity = _db.tbl_Sales.FirstOrDefault(x => x.Id == drugupdateoptionsEntity.Id);
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

        public List<Sales> GetSalesInfoByBookId(int salesInvoiceId)
        {
            List<tbl_Sales> result = (from c in _db.tbl_Sales.Where(t => t.Id == salesInvoiceId) select c).ToList();
            List<Sales> list = result.Select(n => EM_Sales.ConverToModel(n)).ToList();
            return list;
        }

        public List<SalesReceiveDue> GetReceiveDueHistoryByDateRange(DateTime fromDate, DateTime toDate)
        {
            List<tbl_ReceiveDue> result = (from c in _db.tbl_ReceiveDue.Where(t => t.ReceiveDate > fromDate && t.ReceiveDate < toDate) select c).ToList();
            List<SalesReceiveDue> list = result.Select(n => EM_SalesReceiveDue.ConverToModel(n)).ToList();
            return list;
        }
    }
}
