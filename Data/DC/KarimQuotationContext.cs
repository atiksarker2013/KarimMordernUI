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

        public List<KarimInvoice> GetQuotationInvoiceDetailsById(int pk)
        {
            List<KarimInvoice> list = new List<KarimInvoice>();
            var query = from qut in _db.tbl_KarimQuotation
                        join det in _db.tbl_KarimQuotationDetails on qut.Id equals det.SalesId
                        join book in _db.tbl_KarimBook on det.BookId equals book.Id
                        where qut.Id == pk
                        select new
                        {
                            Id = qut.Id,
                            Name = qut.Name,
                            Mobile = qut.Mobile,
                            Address = qut.Address,
                            Date = qut.Date,
                            KarimRefNo = qut.KarimRefNo,
                            PayType = qut.PayType,
                            PayNo = qut.PayNo,
                            Total = qut.Total,
                            Discount = qut.Discount,
                            OtherDiscount = qut.OtherDiscount,
                            GrandTotal = qut.GrandTotal,
                            Receive = qut.Receive,
                            Due = qut.Due,
                            CustomerRefNo = qut.CustomerRefNo,
                            BookId = det.BookId,
                            OrderQty = det.OrderQty,
                            Price = det.Price,
                            ReturnQty = det.ReturnQty,
                            CustomerSlNo = det.CustomerSlNo,
                            UnitDiscountPercent = det.UnitDiscountPercent,
                            DiscountTaka = det.DiscountTaka,
                            NetTaka = det.NetTaka,
                            DeliveryDate = det.DeliveryDate,
                            DeliveryTime = det.DeliveryTime,
                            Title = book.Title,
                            Writer = book.Writer,
                            Publisher = book.Publisher,
                            Qty = book.Qty,
                            PublisherPrice = book.PublisherPrice,
                            BookPrice = book.Price,
                            OutOfStock = book.OutOfStock,
                            InStock = book.InStock,
                            Barcode = book.Barcode,
                            EntryDate = book.EntryDate,
                            PublishYear = book.PublishYear,
                            PublisherUnit = book.PublisherUnit,
                            Edition = book.Edition,
                            BookBinding = book.BookBinding,
                            BookType = book.BookType
                        };

            foreach (var item in query)
            {
                KarimInvoice inv = new KarimInvoice();
                inv.Id = item.Id;
                inv.Name = item.Name;
                inv.Mobile = item.Mobile;
                inv.Address = item.Address;
                inv.KarimRefNo = item.KarimRefNo;
                inv.PayType = item.PayType;
                inv.PayNo = item.PayNo;
                inv.Total = (decimal)item.Total;
                inv.Discount = (decimal)item.Discount;
                inv.OtherDiscount = (decimal)item.OtherDiscount;
                inv.GrandTotal = (decimal)item.GrandTotal;
                inv.Receive = (decimal)item.Receive;
                inv.Due = (decimal)item.Due;
                inv.CustomerRefNo = item.CustomerRefNo;
                inv.BookId = item.BookId;
                inv.OrderQty = (int)item.OrderQty;
                inv.Price = (decimal)item.Price;
                inv.TotalUnitPrice = (decimal)(item.OrderQty * item.Price);
                inv.ReturnQty = item.ReturnQty;
                inv.CustomerSlNo = item.CustomerSlNo;
                inv.UnitDiscountPercent = item.UnitDiscountPercent;
                inv.DiscountTaka = (decimal)item.DiscountTaka;
                inv.NetTaka = (decimal)item.NetTaka;
                inv.Title = item.Title;
                inv.Writer = item.Writer;
                inv.Publisher = item.Publisher;
                inv.Qty = (int)item.Qty;
                inv.PublisherPrice = (decimal)item.PublisherPrice;
                inv.BookPrice = item.BookPrice;
                inv.OutOfStock = item.OutOfStock;
                inv.InStock = item.InStock;
                inv.Barcode = item.Barcode;
                inv.PublishYear = item.PublishYear.ToString();
                inv.PublisherUnit = item.PublisherUnit;
                inv.Edition = item.Edition;
                inv.BookBinding = item.BookBinding;
                inv.BookType = item.BookType;
                inv.DeliveryDate = item.DeliveryDate;
                inv.DeliveryTime = item.DeliveryTime;
                inv.IsCustomerSlNo = false;
                inv.IsTitle = false;
                inv.IsWriter = false;
                inv.IsPublisher = false;
                inv.IsBarcode = false;
                inv.IsBookType = false;
                inv.IsPublisherPrice = false;
                inv.IsPublisherUnit = false;
                inv.IsPrice = false;
                inv.IsInStock = false;
                inv.IsOrderQty = false;
                inv.IsTotalUnitPrice = false;
                inv.IsUnitDiscountPercent = false;
                inv.IsDiscountTaka = false;

                list.Add(inv);
            }



            return list;
        }
    }
}
