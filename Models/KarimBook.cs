using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //class KarimBook
    //{
    //}

    [Serializable]
    public class KarimBook : ModelBase
    {


        private int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                RaisePropertyChanged("Id");
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
                RaisePropertyChanged("Title");
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
                RaisePropertyChanged("Writer");
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
                RaisePropertyChanged("Publisher");
                //if (string.IsNullOrEmpty(Publisher))
                //AddErrorForProperty("Publisher","Ublisher cannot be empty");
                //else
                //RemoveError("Publisher");
            }
        }

        private int? _Qty;
        public int? Qty
        {
            get { return _Qty; }
            set
            {
                _Qty = value;
                RaisePropertyChanged("Qty");
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
                RaisePropertyChanged("OrderQty");
                //if (Qty == 0)
                //AddErrorForProperty("Qty","Ty cannot be empty");
                //else
                //RemoveError("Qty");
            }
        }

        private int _newEntryQty;
        public int NewEntryQty
        {
            get { return _newEntryQty; }
            set
            {
                _newEntryQty = value;
                RaisePropertyChanged("NewEntryQty");
                //if (Qty == 0)
                //AddErrorForProperty("Qty","Ty cannot be empty");
                //else
                //RemoveError("Qty");
            }
        }


        private decimal? _totalUnitPrice;
        public decimal? TotalUnitPrice
        {
            get { return _totalUnitPrice; }
            set
            {
                _totalUnitPrice = value;
                RaisePropertyChanged("TotalUnitPrice");
                //if (Qty == 0)
                //AddErrorForProperty("Qty","Ty cannot be empty");
                //else
                //RemoveError("Qty");
            }
        }

        private decimal? _Price;
        public decimal? Price
        {
            get { return _Price; }
            set
            {
                _Price = value;
                RaisePropertyChanged("Price");
                //if (Price == 0)
                //AddErrorForProperty("Price","Rice cannot be empty");
                //else
                //RemoveError("Price");
            }
        }

        private decimal? _newPrice;
        public decimal? NewPrice
        {
            get { return _newPrice; }
            set
            {
                _newPrice = value;
                RaisePropertyChanged("NewPrice");
                //if (Price == 0)
                //AddErrorForProperty("Price","Rice cannot be empty");
                //else
                //RemoveError("Price");
            }
        }



        private int? _OutOfStock;
        public int? OutOfStock
        {
            get { return _OutOfStock; }
            set
            {
                _OutOfStock = value;
                RaisePropertyChanged("OutOfStock");
                //if (OutOfStock == 0)
                //AddErrorForProperty("OutOfStock","UtOfStock cannot be empty");
                //else
                //RemoveError("OutOfStock");
            }
        }

        private int? _InStock;
        public int? InStock
        {
            get { return _InStock; }
            set
            {
                _InStock = value;
                RaisePropertyChanged("InStock");
                //if (InStock == 0)
                //AddErrorForProperty("InStock","NStock cannot be empty");
                //else
                //RemoveError("InStock");
            }
        }

        private DateTime? _entryDate;
        public DateTime? EntryDate
        {
            get { return _entryDate; }
            set
            {
                _entryDate = value;
                RaisePropertyChanged("EntryDate");
                //if (InStock == 0)
                //AddErrorForProperty("InStock","NStock cannot be empty");
                //else
                //RemoveError("InStock");
            }
        }


        private int _discountPercentage;
        public int DiscountPercentage
        {
            get { return _discountPercentage; }
            set
            {
                _discountPercentage = value;
                RaisePropertyChanged("DiscountPercentage");
                //if (Id == 0)
                //AddErrorForProperty("Id","D cannot be empty");
                //else
                //RemoveError("Id");
            }
        }

        private decimal _unitWiseNetTaka;
        public decimal UnitWiseNetTaka
        {
            get { return _unitWiseNetTaka; }
            set
            {
                _unitWiseNetTaka = value;
                RaisePropertyChanged("UnitWiseNetTaka");
                //if (Id == 0)
                //AddErrorForProperty("Id","D cannot be empty");
                //else
                //RemoveError("Id");
            }
        }


        private decimal _unitWiseDiscountAmount;
        public decimal UnitWiseDiscountAmount
        {
            get { return _unitWiseDiscountAmount; }
            set
            {
                _unitWiseDiscountAmount = value;
                RaisePropertyChanged("UnitWiseDiscountAmount");
                //if (Id == 0)
                //AddErrorForProperty("Id","D cannot be empty");
                //else
                //RemoveError("Id");
            }
        }

        private decimal _customerSlNo;
        public decimal CustomerSlNo
        {
            get { return _customerSlNo; }
            set
            {
                _customerSlNo = value;
                RaisePropertyChanged("CustomerSlNo");
                //if (Id == 0)
                //AddErrorForProperty("Id","D cannot be empty");
                //else
                //RemoveError("Id");
            }
        }

        
        public string Barcode { get; set; }
        public decimal PublisherPrice { get; set; }
        public string PublisherUnit { get; set; }
        public int? PublishYear { get; set; }
        public string BookType { get; set; }
      //  public decimal DiscountPercentage { get; set; }

        public bool CheckValidation()
        {
            bool _result = false;
            int _trueCount = 0;
            int _falseCount = 0;
            if (Id == 0)
            {
                AddErrorForProperty("Id", "D cannot be empty");
                _trueCount++;
            }
            else
            {
                RemoveError("Id");
                _falseCount++;
            }
            if (string.IsNullOrEmpty(Title))
            {
                AddErrorForProperty("Title", "Itle cannot be empty");
                _trueCount++;
            }
            else
            {
                RemoveError("Title");
                _falseCount++;
            }
            if (string.IsNullOrEmpty(Writer))
            {
                AddErrorForProperty("Writer", "Riter cannot be empty");
                _trueCount++;
            }
            else
            {
                RemoveError("Writer");
                _falseCount++;
            }
            if (string.IsNullOrEmpty(Publisher))
            {
                AddErrorForProperty("Publisher", "Ublisher cannot be empty");
                _trueCount++;
            }
            else
            {
                RemoveError("Publisher");
                _falseCount++;
            }
            if (Qty == 0)
            {
                AddErrorForProperty("Qty", "Ty cannot be empty");
                _trueCount++;
            }
            else
            {
                RemoveError("Qty");
                _falseCount++;
            }
            if (Price == 0)
            {
                AddErrorForProperty("Price", "Rice cannot be empty");
                _trueCount++;
            }
            else
            {
                RemoveError("Price");
                _falseCount++;
            }
            if (OutOfStock == 0)
            {
                AddErrorForProperty("OutOfStock", "UtOfStock cannot be empty");
                _trueCount++;
            }
            else
            {
                RemoveError("OutOfStock");
                _falseCount++;
            }
            if (InStock == 0)
            {
                AddErrorForProperty("InStock", "NStock cannot be empty");
                _trueCount++;
            }
            else
            {
                RemoveError("InStock");
                _falseCount++;
            }
            if (_trueCount > 0)
                _result = true;
            else if (_trueCount < _falseCount)
                _result = false;
            return _result;
        }
    }
}
