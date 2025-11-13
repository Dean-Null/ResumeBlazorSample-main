using Bogus;
using DisplayResume.Models;
using DisplayResume.Models.Enums;

namespace DisplayResume.FakerData
{
	public class FakerTechnology : Faker<Technology>
	{
		public FakerTechnology()
		{
			UseSeed(100)
				.RuleFor(o => o.Name, f => f.Company.CompanyName())
				.RuleFor(o => o.ProperName, f => f.Company.CompanyName())
				.RuleFor(o => o.Description, f => f.Lorem.Sentence())
				.RuleFor(o => o.URL, f => f.Internet.Url())
				.RuleFor(o => o.Focus, f => f.Random.Enum<EnumFocus>());
		}
	}
}
