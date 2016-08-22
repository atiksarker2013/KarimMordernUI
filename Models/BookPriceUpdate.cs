using System;

namespace Models
{
    [Serializable]
 public   class BookPriceUpdate: ModelBase
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

        private int _bookId;
        public int BookId
        {
            get { return _bookId; }
            set
            {
                _bookId = value;
                RaisePropertyChanged("BookId");
                //if (Id == 0)
                //AddErrorForProperty("Id","D cannot be empty");
                //else
                //RemoveError("Id");
            }
        }


        private decimal? _oldPrice;
        public decimal? OldPrice
        {
            get { return _oldPrice; }
            set
            {
                _oldPrice = value;
                RaisePropertyChanged("OldPrice");
                //if (Qty == 0)
                //AddErrorForProperty("Qty","Ty cannot be empty");
                //else
                //RemoveError("Qty");
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
                //if (Qty == 0)
                //AddErrorForProperty("Qty","Ty cannot be empty");
                //else
                //RemoveError("Qty");
            }
        }

        private DateTime? _updateDate;
        public DateTime? UpdateDate
        {
            get { return _updateDate; }
            set
            {
                _updateDate = value;
                RaisePropertyChanged("UpdateDate");
                //if (Qty == 0)
                //AddErrorForProperty("Qty","Ty cannot be empty");
                //else
                //RemoveError("Qty");
            }
        }

        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Writer { get; set; }
    }
}
