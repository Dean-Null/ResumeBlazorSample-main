using Bogus;
using DisplayResume.Models;

namespace DisplayResume.FakerData
{
	public class FakerContactInfo : Faker<ContactInfo>
	{
		public FakerContactInfo()
		{
			UseSeed(100)
				.RuleFor(o => o.FirstName, f => f.Name.FirstName())
				.RuleFor(o => o.MiddleName, f => f.Name.FirstName())
				.RuleFor(o => o.LastName, f => f.Name.LastName())
				.RuleFor(o => o.Address, new FakerAddress().Generate())
				.RuleFor(o => o.PhoneNumber, "555-555-5555")
				.RuleFor(o => o.EmailAddress, f => f.Internet.ExampleEmail())
				.RuleFor(o => o.URLAddress, f => f.Internet.Url())
				.RuleFor(o => o.URLLinkedIn, f => f.Internet.Url());
		}
	}
}
