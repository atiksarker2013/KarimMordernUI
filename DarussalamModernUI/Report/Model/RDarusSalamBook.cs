using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarussalamModernUI.Report.Model
{
  public  class RDarusSalamBook
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
              //  RaisePropertyChanged("Id");
                //if (Id == 0)
                //AddErrorForProperty("Id","D cannot be empty");
                //else
                //RemoveError("Id");
            }
        }

        private string _Title;
        public string Title
        {
            get { return _Title; }
            set
            {
                _Title = value;
               // RaisePropertyChanged("Title");
                //if (string.IsNullOrEmpty(Title))
                //AddErrorForProperty("Title","Itle cannot be empty");
                //else
                //RemoveError("Title");
            }
        }

        private string _Writer;
        public string Writer
        {
            get { return _Writer; }
            set
            {
                _Writer = value;
                //RaisePropertyChanged("Writer");
                //if (string.IsNullOrEmpty(Writer))
                //AddErrorForProperty("Writer","Riter cannot be empty");
                //else
                //RemoveError("Writer");
            }
        }

        private string _Publisher;
        public string Publisher
        {
            get { return _Publisher; }
            set
            {
                _Publisher = value;
               // RaisePropertyChanged("Publisher");
                //if (string.IsNullOrEmpty(Publisher))
                //AddErrorForProperty("Publisher","Ublisher cannot be empty");
                //else
                //RemoveError("Publisher");
            }
        }

        private int _Qty;
        public int Qty
        {
            get { return _Qty; }
            set
            {
                _Qty = value;
              //  RaisePropertyChanged("Qty");
                //if (Qty == 0)
                //AddErrorForProperty("Qty","Ty cannot be empty");
                //else
                //RemoveError("Qty");
            }
        }

        private int _OrderQty;
        public int OrderQty
        {
            get { return _OrderQty; }
            set
            {
                _OrderQty = value;
               // RaisePropertyChanged("OrderQty");
                //if (Qty == 0)
                //AddErrorForProperty("Qty","Ty cannot be empty");
                //else
                //RemoveError("Qty");
            }
        }


        private decimal _totalUnitPrice;
        public decimal TotalUnitPrice
        {
            get { return _totalUnitPrice; }
            set
            {
                _totalUnitPrice = value;
                //RaisePropertyChanged("TotalUnitPrice");
                //if (Qty == 0)
                //AddErrorForProperty("Qty","Ty cannot be empty");
                //else
                //RemoveError("Qty");
            }
        }

        private decimal _Price;
        public decimal Price
        {
            get { return _Price; }
            set
            {
                _Price = value;
               // RaisePropertyChanged("Price");
                //if (Price == 0)
                //AddErrorForProperty("Price","Rice cannot be empty");
                //else
                //RemoveError("Price");
            }
        }

        private int _OutOfStock;
        public int OutOfStock
        {
            get { return _OutOfStock; }
            set
            {
                _OutOfStock = value;
                //RaisePropertyChanged("OutOfStock");
                //if (OutOfStock == 0)
                //AddErrorForProperty("OutOfStock","UtOfStock cannot be empty");
                //else
                //RemoveError("OutOfStock");
            }
        }

        private int _InStock;
        public int InStock
        {
            get { return _InStock; }
            set
            {
                _InStock = value;
                //RaisePropertyChanged("InStock");
                //if (InStock == 0)
                //AddErrorForProperty("InStock","NStock cannot be empty");
                //else
                //RemoveError("InStock");
            }
        }

        public string Name { get; internal set; }
        public string Mobile { get; internal set; }
        public DateTime Date { get; internal set; }
        public string Address { get; internal set; }
        public string PayType { get; internal set; }
        public string PayNo { get; internal set; }
        public decimal Total { get; internal set; }
        public decimal Discount { get; internal set; }
        public decimal GrandTotal { get; internal set; }
        public decimal Receive { get; internal set; }
        public decimal Due { get; internal set; }
        public int InvoiceNo { get; internal set; }

        public DateTime FromDate { get; internal set; }
        public DateTime ToDate { get; internal set; }


        private string _publisherName;
        public string PublisherName
        {
            get { return _publisherName; }
            set
            {
                _publisherName = value;
               // RaisePropertyChanged("PublisherName");
            }
        }

        private decimal _totalAmount;
        public decimal TotalAmount
        {
            get { return _totalAmount; }
            set
            {
                _totalAmount = value;
              //  RaisePropertyChanged("TotalAmount");
            }
        }


        private int _discountPercentage;
        public int DiscountPercentage
        {
            get { return _discountPercentage; }
            set
            {
                _discountPercentage = value;
               // RaisePropertyChanged("DiscountPercentage");
            }
        }

        private decimal _discountAmount;
        public decimal DiscountAmount
        {
            get { return _discountAmount; }
            set
            {
                _discountAmount = value;
               // RaisePropertyChanged("DiscountAmount");
            }
        }

        public decimal CuriarCharg { get; internal set; }
        public decimal OtherDiscount { get; internal set; }
    }
}
