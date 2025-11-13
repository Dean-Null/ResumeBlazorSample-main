using Bogus;
using DisplayResume.Models;

namespace DisplayResume.FakerData
{
	public class FakerAddress : Faker<Address>
	{
		public FakerAddress()
		{
			UseSeed(100)
				.RuleFor(o => o.AddressFirst, f => f.Address.StreetAddress())
				.RuleFor(o => o.AddressSecond, f => f.Address.SecondaryAddress())
				.RuleFor(o => o.City, f => f.Address.City())
				.RuleFor(o => o.State, f => f.Address.State())
				.RuleFor(o => o.PostalCode, f => f.Address.ZipCode())
				.RuleFor(o => o.Country, f => f.Address.Country());
		}
	}
}
