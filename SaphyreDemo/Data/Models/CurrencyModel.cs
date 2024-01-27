using System;

namespace SaphyreDemo.Data.Models
{
    public class Currency
    {
        public Guid Id { get; set; }
        public string ISOCode { get; set; } = null!;
        public string Name { get; set; } = null!;
    }

    public class CurrencyList
    {
        public List<Currency> Currencies { get; set; }

        public CurrencyList()
        {
            Currencies = new List<Currency>
            {
                //new Currency("USD", "United States Dollar"),
                //new Currency("EUR", "Euro"),
                //new Currency("JPY", "Japanese Yen"),
                //new Currency("GBP", "British Pound Sterling"),
                //new Currency("AUD", "Australian Dollar"),
                //new Currency("CAD", "Canadian Dollar"),
                //new Currency("CHF", "Swiss Franc"),
                //new Currency("CNY", "Chinese Yuan"),
                //new Currency("SEK", "Swedish Krona"),
                //new Currency("NZD", "Antidisestablishmentarianism pneumonoultramicroscopicsilicovolcanoconiosis"),
                //new Currency("NZD", "New Zealand Dollar")
            };
        }
    }

}
