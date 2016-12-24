using Data.EM;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DC
{
   public class KarimQuotationContext
    {
        KARIM_INT_HOUSTONEEntities _db = new KARIM_INT_HOUSTONEEntities();

        public int Insert(KarimSales SalesModel)
        {
            try
            {
                //int maxAge = _db.tbl_KarimSales.Max(p => p.Id);
                //SalesModel.Id = maxAge + 1;
                tbl_KarimQuotation _salesModel = EM_KarimQuotation.ConvertToEntity(SalesModel);
                _db.tbl_KarimQuotation.Add(_salesModel);

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
