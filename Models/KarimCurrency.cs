namespace Models
{
    public class KarimCurrency: ModelBase
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

        private string _currencyName;
        public string CurrencyName
        {
            get { return _currencyName; }
            set
            {
                _currencyName = value;
                RaisePropertyChanged("CurrencyName");
                
            }
        }

        private string _currencySymbol;
        public string CurrencySymbol
        {
            get { return _currencySymbol; }
            set
            {
                _currencySymbol = value;
                RaisePropertyChanged("CurrencySymbol");
               
            }
        }

        private decimal _takaInAmount;
        public decimal TakaInAmount
        {
            get { return _takaInAmount; }
            set
            {
                _takaInAmount = value;
                RaisePropertyChanged("TakaInAmount");
                
            }
        }
        
    }
   

}
