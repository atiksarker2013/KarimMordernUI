using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarimModernUINavigationApp
{
    public static class GlobalVar
    {
        public static List<KarimBook> UpdateKarimBookList = new List<KarimBook>();
        public static List<KarimBook> TempNewKarimBookEntryList = new List<KarimBook>();

        //public static List<KarimBook> UpdateBookPriceList { get; internal set; }
        //public static List<KarimBook> BookPriceUpdateList { get; internal set; }


        public static List<KarimBook> UpdateBookPriceList = new List<KarimBook>();
        public static List<KarimBook> BookPriceUpdateList = new List<KarimBook>();
    }
}
