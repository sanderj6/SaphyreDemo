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

		// TODO: Dummy List
		public CurrencyList()
		{
			Currencies = new List<Currency>
			{
				new Currency(){Id = Guid.NewGuid(), ISOCode = "USD", Name = "United States Dollar"},
				new Currency(){Id = Guid.NewGuid(), ISOCode = "EUR", Name = "Euro"},
				new Currency(){Id = Guid.NewGuid(), ISOCode = "JPY", Name = "Japanese Yen"},
				new Currency(){Id = Guid.NewGuid(), ISOCode = "GBP", Name = "British Pound Sterling"},
				new Currency(){Id = Guid.NewGuid(), ISOCode = "AUD", Name = "Australian Dollar"},
				new Currency(){Id = Guid.NewGuid(), ISOCode = "CAD", Name = "Canadian Dollar"},
				new Currency(){Id = Guid.NewGuid(), ISOCode = "CHF", Name = "Swiss Franc"},
				new Currency(){Id = Guid.NewGuid(), ISOCode = "CNY", Name = "Chinese Yuan"},
				new Currency(){Id = Guid.NewGuid(), ISOCode = "SEK", Name = "Swedish Krona"},
				new Currency(){Id = Guid.NewGuid(), ISOCode = "JOSH", Name = "Antidisestablishmentarianism pneumonoultramicroscopicsilicovolcanoconiosis"},
				new Currency(){Id = Guid.NewGuid(), ISOCode = "NZD", Name = "New Zealand Dollar"}
			};
		}
	}

}
