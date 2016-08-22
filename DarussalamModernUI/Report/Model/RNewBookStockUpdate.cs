using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarussalamModernUI.Report.Model
{
  public  class RNewBookStockUpdate
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
            //    RaisePropertyChanged("Id");
                //if (Id == 0)
                //AddErrorForProperty("Id","D cannot be empty");
                //else
                //RemoveError("Id");
            }
        }

        private int _BookId;
        public int BookId
        {
            get { return _BookId; }
            set
            {
                _BookId = value;
               // RaisePropertyChanged("BookId");
                //if (Id == 0)
                //AddErrorForProperty("Id","D cannot be empty");
                //else
                //RemoveError("Id");
            }
        }


        private int _OldStock;
        public int OldStock
        {
            get { return _OldStock; }
            set
            {
                _OldStock = value;
              //  RaisePropertyChanged("OldStock");
                //if (Id == 0)
                //AddErrorForProperty("Id","D cannot be empty");
                //else
                //RemoveError("Id");
            }
        }


        private int _NewEntryQty;
        public int NewEntryQty
        {
            get { return _NewEntryQty; }
            set
            {
                _NewEntryQty = value;
                //RaisePropertyChanged("NewEntryQty");
                //if (Id == 0)
                //AddErrorForProperty("Id","D cannot be empty");
                //else
                //RemoveError("Id");
            }
        }

        private DateTime _EntryDate;
        public DateTime EntryDate
        {
            get { return _EntryDate; }
            set
            {
                _EntryDate = value;
                //RaisePropertyChanged("EntryDate");
                //if (Id == 0)
                //AddErrorForProperty("Id","D cannot be empty");
                //else
                //RemoveError("Id");
            }
        }

        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Writer { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }
    }
}
