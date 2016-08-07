using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data
{
    public class BookContext
    {
        public KARIM_INT_HOUSTONEEntities _db;

        public BookContext()
        {
            _db = new KARIM_INT_HOUSTONEEntities();
        }
        public List<DarusSalamBook> GetAllBookListLookup(string title)
        {
            return (from c in _db.tbl_DarusSalamBook
                    where c.Title.StartsWith(title)
                    orderby c.Title

                    select new DarusSalamBook
                    {
                        Id = c.Id,
                        Title = c.Title,
                        Writer = c.Writer,
                        Publisher = c.Publisher,
                        Qty = (int)c.Qty,
                        Price = (decimal)c.Price,
                        OutOfStock = (int)c.OutOfStock,
                        InStock = (int)c.InStock,
                        Barcode = c.Barcode

                    }).Take(20).ToList();

        }
    }
}
