using Data.EM;
using Models;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

namespace Data.DC
{
    public class KarimSalesContext
    {
        KARIM_INT_HOUSTONEEntities _db = new KARIM_INT_HOUSTONEEntities();

        public int Insert(KarimSales SalesModel)
        {
            try
            {
                int maxAge = _db.tbl_KarimSales.Any() ? _db.tbl_KarimSales.Max(s => s.Id) : 0;  
                SalesModel.Id = maxAge + 1;
                tbl_KarimSales _salesModel = EM_KarimSales.ConvertToEntity(SalesModel);
                _db.tbl_KarimSales.Add(_salesModel);

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
    }
}
