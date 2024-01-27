﻿using System;

namespace SaphyreDemo.Data.Models
{
    public class Currency
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public Currency(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }

    public class CurrencyList
    {
        public List<Currency> Currencies { get; set; }

        public CurrencyList()
        {
            Currencies = new List<Currency>
            {
                new Currency("USD", "United States Dollar"),
                new Currency("EUR", "Euro"),
                new Currency("JPY", "Japanese Yen"),
                new Currency("GBP", "British Pound Sterling"),
                new Currency("AUD", "Australian Dollar"),
                new Currency("CAD", "Canadian Dollar"),
                new Currency("CHF", "Swiss Franc"),
                new Currency("CNY", "Chinese Yuan"),
                new Currency("SEK", "Swedish Krona"),
                new Currency("NZD", "New Zealand Dollar")
            };
        }
    }

}
