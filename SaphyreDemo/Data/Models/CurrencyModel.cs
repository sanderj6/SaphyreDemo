using System;

namespace SaphyreDemo.Data.Models
{
	public class Currency
	{
		public Guid Id { get; set; }
		public string ISOCode { get; set; } = null!;
		public string Name { get; set; } = null!;

		public Currency(Guid id, string code, string name)
		{
			Id = id;
			ISOCode = code;
			Name = name;
		}

	}

	public class CurrencyList
	{
		public List<Currency> Currencies { get; set; }

		// TODO: Dummy List
		public CurrencyList()
		{
			Currencies = new List<Currency>
			{
				new Currency(Guid.NewGuid(), "USD", "United States Dollar"),
				new Currency(Guid.NewGuid(), "EUR", "Euro"),
				new Currency(Guid.NewGuid(), "JPY", "Japanese Yen"),
				new Currency(Guid.NewGuid(), "GBP", "British Pound Sterling"),
				new Currency(Guid.NewGuid(), "AUD", "Australian Dollar"),
				new Currency(Guid.NewGuid(), "CAD", "Canadian Dollar"),
				new Currency(Guid.NewGuid(), "CHF", "Swiss Franc"),
				new Currency(Guid.NewGuid(), "CNY", "Chinese Yuan"),
				new Currency(Guid.NewGuid(), "SEK", "Swedish Krona"),
				new Currency(Guid.NewGuid(), "NZD", "Antidisestablishmentarianism pneumonoultramicroscopicsilicovolcanoconiosis"),
				new Currency(Guid.NewGuid(), "NZD", "New Zealand Dollar")
			};
		}
	}

}
