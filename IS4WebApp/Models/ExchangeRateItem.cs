using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS4WebApp.Models
{
    public class ExchangeRateItem
    {
        public string FromCurrency { get; set; }

        public string ToCurrency { get; set; }

        public double Value { get; set; }
    }
}
