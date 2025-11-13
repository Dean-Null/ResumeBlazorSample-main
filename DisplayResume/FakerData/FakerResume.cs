using Bogus;
using DisplayResume.Models;

namespace DisplayResume.FakerData
{
	public class FakerResume : Faker<Resume>
	{
		public FakerResume()
		{
			UseSeed(100)
				.RuleFor(o => o.Summary, f => f.Lorem.Sentence())
				.RuleFor(o => o.Contact, f => new FakerContactInfo().Generate())
				.RuleFor(o => o.Education, f => new FakerEducation().Generate(1))
				.RuleFor(o => o.Organizations, f => new FakerOrganization().Generate(3))
				.RuleFor(o => o.Technologies, f => new FakerTechnology().Generate(20))
				.RuleFor(o => o.Qualifications, f => f.Make(3, () => f.Lorem.Sentence()).ToList());
		}
	}
}
