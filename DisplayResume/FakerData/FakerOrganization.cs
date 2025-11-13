using Bogus;
using DisplayResume.Models;
using DisplayResume.Models.Enums;

namespace DisplayResume.FakerData
{
	public class FakerOrganization : Faker<Organization>
	{
		public FakerOrganization()
		{
			UseSeed(100)
				.RuleFor(o => o.Name, f => f.Company.CompanyName())
				.RuleFor(o => o.Address, new FakerAddress().Generate())
				.RuleFor(o => o.Duration, new FakerDuration().Generate())
				.RuleFor(o => o.Employment, f => f.Random.Enum<EnumEmployment>())
				.RuleFor(o => o.Description, f => f.Lorem.Sentence())
				.RuleFor(o => o.Positions, new FakerPosition().Generate(2));
		}
	}
}
