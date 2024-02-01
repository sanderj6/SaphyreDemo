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
			var orderNumber = _random.Next(25000, 50000);
			GenerateOrders(orderNumber); // Generate dummy orders
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
				ShippingType = shippingOptions[_random.Next(shippingOptions.Count)],
				Amount = _random.Next(100, 10000),
				Currency = new Currency() { Id = Guid.NewGuid(), ISOCode = $"USD", Name = "US Dollar" },
				Products = GenerateRandomProducts(),
				TaxPercentage = _random.Next(5, 20),
				Date = RandomDay()
			};
		}

		private IEnumerable<DropDownItem> GenerateRandomProducts()
		{
			productTypes = productTypes.OrderBy(x => _random.Next()).ToList();
			int itemsToTake = _random.Next(1, productTypes.Count + 1);
			return productTypes.Take(itemsToTake);
		}

		private DateTime RandomDay()
		{
			DateTime start = new DateTime(1995, 1, 1);
			int range = (DateTime.Today - start).Days;
			return start.AddDays(_random.Next(range));
		}

		public List<OrderDescription> GetAllOrders()
		{
			return _orders;
		}

		public async Task<IEnumerable<OrderDescription>> GetFilteredOrders(string searchText)
		{
			var filteredOrders = await StringExtensions.SearchModelForValue(_orders, searchText);
			return filteredOrders;
		}
		
		// Dummy Product Types
		public List<DropDownItem> productTypes = new()
		{

			new DropDownItem()
			{
				Id = Guid.NewGuid(),
				Name = "Electronics",
				SecondaryName = "TVs, Computers, Audio"
			},
			new DropDownItem()
			{
				Id = Guid.NewGuid(),
				Name = "Clothing",
				SecondaryName = "Men's, Women's, Kids'"
			},
			new DropDownItem()
			{
				Id = Guid.NewGuid(),
				Name = "Furniture",
				SecondaryName = "Living Room, Bedroom, Outdoor"
			},
			new DropDownItem()
			{
				Id = Guid.NewGuid(),
				Name = "Toys",
				SecondaryName = "Action Figures, Learning Toys, Puzzles"
			},
			new DropDownItem()
			{
				Id = Guid.NewGuid(),
				Name = "Books",
				SecondaryName = "Fiction, Non-Fiction, Children's"
			}
		};
		
		// Dummy Shipping Options
		public List<DropDownItem> shippingOptions = new()
		{
			new DropDownItem()
			{
				Id = Guid.NewGuid(),
				Name = "Expedited"
			},
			new DropDownItem()
			{
				Id = Guid.NewGuid(),
				Name = "Overnight"
			},
			new DropDownItem()
			{
				Id = Guid.NewGuid(),
				Name = "Priority"
			},
			new DropDownItem()
			{
				Id = Guid.NewGuid(),
				Name = "Standard"
			}
		};
	}

}
