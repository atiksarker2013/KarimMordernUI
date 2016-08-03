namespace Models
{
    public class Discounts : ModelBase
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                RaisePropertyChanged("Id");
            }
        }

        private int _invoiceId;
        public int InvoiceId
        {
            get { return _invoiceId; }
            set
            {
                _invoiceId = value;
                RaisePropertyChanged("InvoiceId");
            }
        }

        private string _publisherName;
        public string PublisherName
        {
            get { return _publisherName; }
            set
            {
                _publisherName = value;
                RaisePropertyChanged("PublisherName");
            }
        }

        private decimal _totalAmount;
        public decimal TotalAmount
        {
            get { return _totalAmount; }
            set
            {
                _totalAmount = value;
                RaisePropertyChanged("TotalAmount");
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
            }
        }

        private decimal _discountAmount;
        public decimal DiscountAmount
        {
            get { return _discountAmount; }
            set
            {
                _discountAmount = value;
                RaisePropertyChanged("DiscountAmount");
            }
        }

    }
}
