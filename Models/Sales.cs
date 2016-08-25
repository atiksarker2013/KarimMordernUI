using System;
using System.Collections.Generic;

namespace Models
{

    [Serializable]
    public class Sales : ModelBase
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

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                RaisePropertyChanged("Name");
                //if (string.IsNullOrEmpty(Name))
                //AddErrorForProperty("Name","Ame cannot be empty");
                //else
                //RemoveError("Name");
            }
        }

        private string _Mobile;
        public string Mobile
        {
            get { return _Mobile; }
            set
            {
                _Mobile = value;
                RaisePropertyChanged("Mobile");
                //if (string.IsNullOrEmpty(Mobile))
                //AddErrorForProperty("Mobile","Obile cannot be empty");
                //else
                //RemoveError("Mobile");
            }
        }

        private string _Address;
        public string Address
        {
            get { return _Address; }
            set
            {
                _Address = value;
                RaisePropertyChanged("Address");
                //if (string.IsNullOrEmpty(Address))
                //AddErrorForProperty("Address","Ddress cannot be empty");
                //else
                //RemoveError("Address");
            }
        }

        private DateTime? _Date;
        public DateTime? Date
        {
            get { return _Date; }
            set
            {
                _Date = value;
                RaisePropertyChanged("Date");
                //if (!Date.HasValue)
                //AddErrorForProperty("Date","Ate cannot be empty");
                //else
                //RemoveError("Date");
            }
        }

        private string _PayType;
        public string PayType
        {
            get { return _PayType; }
            set
            {
                _PayType = value;
                RaisePropertyChanged("PayType");
                //if (string.IsNullOrEmpty(PayType))
                //AddErrorForProperty("PayType","AyType cannot be empty");
                //else
                //RemoveError("PayType");
            }
        }

        private string _PayNo;
        public string PayNo
        {
            get { return _PayNo; }
            set
            {
                _PayNo = value;
                RaisePropertyChanged("PayNo");
                //if (string.IsNullOrEmpty(PayNo))
                //AddErrorForProperty("PayNo","AyNo cannot be empty");
                //else
                //RemoveError("PayNo");
            }
        }

        private decimal _Total;
        public decimal Total
        {
            get { return _Total; }
            set
            {
                _Total = value;
                RaisePropertyChanged("Total");
                //if (Total == 0)
                //AddErrorForProperty("Total","Otal cannot be empty");
                //else
                //RemoveError("Total");
            }
        }

        private decimal _Discount;
        public decimal Discount
        {
            get { return _Discount; }
            set
            {
                _Discount = value;
                RaisePropertyChanged("Discount");
                //if (Discount == 0)
                //AddErrorForProperty("Discount","Iscount cannot be empty");
                //else
                //RemoveError("Discount");
            }
        }

        private decimal _otherDiscount;
        public decimal OtherDiscount
        {
            get { return _otherDiscount; }
            set
            {
                _otherDiscount = value;
                RaisePropertyChanged("OtherDiscount");
                //if (Discount == 0)
                //AddErrorForProperty("Discount","Iscount cannot be empty");
                //else
                //RemoveError("Discount");
            }
        }

        private decimal _GrandTotal;
        public decimal GrandTotal
        {
            get { return _GrandTotal; }
            set
            {
                _GrandTotal = value;
                RaisePropertyChanged("GrandTotal");
                //if (GrandTotal == 0)
                //AddErrorForProperty("GrandTotal","RandTotal cannot be empty");
                //else
                //RemoveError("GrandTotal");
            }
        }

        private decimal _Receive;
        public decimal Receive
        {
            get { return _Receive; }
            set
            {
                _Receive = value;
                RaisePropertyChanged("Receive");
                //if (Receive == 0)
                //AddErrorForProperty("Receive","Eceive cannot be empty");
                //else
                //RemoveError("Receive");
            }
        }

        private decimal _Due;
        public decimal Due
        {
            get { return _Due; }
            set
            {
                _Due = value;
                RaisePropertyChanged("Due");
                //if (Due == 0)
                //AddErrorForProperty("Due","Ue cannot be empty");
                //else
                //RemoveError("Due");
            }
        }


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
            if (string.IsNullOrEmpty(Name))
            {
                AddErrorForProperty("Name", "Ame cannot be empty");
                _trueCount++;
            }
            else
            {
                RemoveError("Name");
                _falseCount++;
            }
            if (string.IsNullOrEmpty(Mobile))
            {
                AddErrorForProperty("Mobile", "Obile cannot be empty");
                _trueCount++;
            }
            else
            {
                RemoveError("Mobile");
                _falseCount++;
            }
            if (string.IsNullOrEmpty(Address))
            {
                AddErrorForProperty("Address", "Ddress cannot be empty");
                _trueCount++;
            }
            else
            {
                RemoveError("Address");
                _falseCount++;
            }
            if (!Date.HasValue)
            {
                AddErrorForProperty("Date", "Ate cannot be empty");
                _trueCount++;
            }
            else
            {
                RemoveError("Date");
                _falseCount++;
            }
            if (string.IsNullOrEmpty(PayType))
            {
                AddErrorForProperty("PayType", "AyType cannot be empty");
                _trueCount++;
            }
            else
            {
                RemoveError("PayType");
                _falseCount++;
            }
            if (string.IsNullOrEmpty(PayNo))
            {
                AddErrorForProperty("PayNo", "AyNo cannot be empty");
                _trueCount++;
            }
            else
            {
                RemoveError("PayNo");
                _falseCount++;
            }
            if (Total == 0)
            {
                AddErrorForProperty("Total", "Otal cannot be empty");
                _trueCount++;
            }
            else
            {
                RemoveError("Total");
                _falseCount++;
            }
            if (Discount == 0)
            {
                AddErrorForProperty("Discount", "Iscount cannot be empty");
                _trueCount++;
            }
            else
            {
                RemoveError("Discount");
                _falseCount++;
            }
            if (GrandTotal == 0)
            {
                AddErrorForProperty("GrandTotal", "RandTotal cannot be empty");
                _trueCount++;
            }
            else
            {
                RemoveError("GrandTotal");
                _falseCount++;
            }
            if (Receive == 0)
            {
                AddErrorForProperty("Receive", "Eceive cannot be empty");
                _trueCount++;
            }
            else
            {
                RemoveError("Receive");
                _falseCount++;
            }
            if (Due == 0)
            {
                AddErrorForProperty("Due", "Ue cannot be empty");
                _trueCount++;
            }
            else
            {
                RemoveError("Due");
                _falseCount++;
            }
            if (_trueCount > 0)
                _result = true;
            else if (_trueCount < _falseCount)
                _result = false;
            return _result;
        }

        private List<SalesDetails> _salesDetailsList = new List<SalesDetails>();
        public List<SalesDetails> SalesDetailsList
        {
            get { return _salesDetailsList; }
            set { _salesDetailsList = value; }
        }

        public decimal CuriarCharg { get; set; }
        public string Status { get; set; }
    }
}

