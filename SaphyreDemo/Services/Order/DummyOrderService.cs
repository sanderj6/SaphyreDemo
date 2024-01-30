using SaphyreDemo.Data.Models;
using SaphyreDemo.Helpers.Extensions;

namespace SaphyreDemo.Services.Order
{
	public class DummyOrderService
	{
		private readonly Random _random = new Random();
		private readonly List<OrderDescription> _orders = new List<OrderDescription>();

		public DummyOrderService()
		{
			GenerateOrders(20); // Generate dummy orders
		}

		private void GenerateOrders(int numberOfOrders)
		{
			for (int i = 0; i < numberOfOrders; i++)
			{
				_orders.Add(GenerateRandomOrder());
			}
		}

		private OrderDescription GenerateRandomOrder()
		{
			return new OrderDescription
			{
				Id = Guid.NewGuid(),
				Description = $"Order {_random.Next(100, 10000)}",
				ShippingType = new DropDownItem { Id = Guid.NewGuid(), Name = $"Shipping {_random.Next(1, 5)}" },
				Amount = _random.Next(100, 10000),
				Currency = new Currency() { Id = Guid.NewGuid(), ISOCode = $"USD", Name = "US Dollar" },
				Products = GenerateRandomProducts(),
				TaxPercentage = _random.Next(5, 20),
				Date = RandomDay()
			};
		}

		private IEnumerable<DropDownItem> GenerateRandomProducts()
		{
			return Enumerable.Range(1, _random.Next(1, 10))
							 .Select(x => new DropDownItem { Id = Guid.NewGuid(), Name = $"Product {x}" });
		}

		private DateTime RandomDay()
		{
			DateTime start = new DateTime(1995, 1, 1);
			int range = (DateTime.Today - start).Days;
			return start.AddDays(_random.Next(range));
		}

		public IEnumerable<OrderDescription> GetAllOrders()
		{
			return _orders;
		}

		public async Task<IEnumerable<OrderDescription>> GetFilteredOrders(string searchText)
		{
			var filteredOrders = await StringExtensions.SearchModelForValue(_orders, searchText);
			return filteredOrders;
		}
	}

}
