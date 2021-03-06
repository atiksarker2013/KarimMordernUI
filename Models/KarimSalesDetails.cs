﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //class KarimSalesDetails
    //{
    //}
    public class KarimSalesDetails : ModelBase
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

        private int _SalesId;
        public int SalesId
        {
            get { return _SalesId; }
            set
            {
                _SalesId = value;
                RaisePropertyChanged("SalesId");
                //if (SalesId == 0)
                //AddErrorForProperty("SalesId","AlesId cannot be empty");
                //else
                //RemoveError("SalesId");
            }
        }

        private int _BookId;
        public int BookId
        {
            get { return _BookId; }
            set
            {
                _BookId = value;
                RaisePropertyChanged("BookId");
                //if (BookId == 0)
                //AddErrorForProperty("BookId","OokId cannot be empty");
                //else
                //RemoveError("BookId");
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
                //if (OrderQty == 0)
                //AddErrorForProperty("OrderQty","RderQty cannot be empty");
                //else
                //RemoveError("OrderQty");
            }
        }

        private decimal _Price;
        public decimal Price
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

        private DateTime deliveryDate;
        public DateTime DeliveryDate
        {
            get { return deliveryDate; }
            set
            {
                deliveryDate = value;
                RaisePropertyChanged("DeliveryDate");
                //if (Price == 0)
                //AddErrorForProperty("Price","Rice cannot be empty");
                //else
                //RemoveError("Price");
            }
        }

        public string Writer { get; set; }
        public string Publisher { get; set; }
        public string Title { get; set; }
        public int ReturnQty { get; set; }
        public int InvoiceNo { get; set; }
        public string CustomerSlNo { get; set; }
        public decimal UnitDiscountPercent { get; set; }
        public decimal DiscountTaka { get; set; }
        public decimal NetTaka { get; set; }
        public string DeliveryTime { get; set; }

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
            if (SalesId == 0)
            {
                AddErrorForProperty("SalesId", "AlesId cannot be empty");
                _trueCount++;
            }
            else
            {
                RemoveError("SalesId");
                _falseCount++;
            }
            if (BookId == 0)
            {
                AddErrorForProperty("BookId", "OokId cannot be empty");
                _trueCount++;
            }
            else
            {
                RemoveError("BookId");
                _falseCount++;
            }
            if (OrderQty == 0)
            {
                AddErrorForProperty("OrderQty", "RderQty cannot be empty");
                _trueCount++;
            }
            else
            {
                RemoveError("OrderQty");
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
            if (_trueCount > 0)
                _result = true;
            else if (_trueCount < _falseCount)
                _result = false;
            return _result;
        }
    }
}
