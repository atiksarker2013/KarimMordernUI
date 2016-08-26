﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class SalesReceiveDue
    {
        public int SalesInvoiceId { get; set; }
        public string CustomerInvoiceId { get; set; }
        public decimal ReceiveAmount { get; set; }
        public DateTime ReceiveDate { get; set; }
    }
}
