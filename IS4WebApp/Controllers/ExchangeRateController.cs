using IS4WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IS4WebApp.Controllers
{
    [Authorize]
    [ApiController]
    public class ExchangeRateController
    {
        private static readonly string[] Currencies = new[]
        {
            "EUR", "USD", "BGN", "AUD", "CNY", "TWD", "NZD", "TND", "UAH", "UYU", "MAD"
        };

        [HttpGet("api/rates")]
        public IEnumerable<ExchangeRateItem> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new ExchangeRateItem
            {
                FromCurrency = "RUR",
                ToCurrency = Currencies[rng.Next(Currencies.Length)],
                Value = Math.Round(1.0 + 1.0 / rng.Next(1, 100), 2)
            })
                .ToArray();
        }
    }
}
