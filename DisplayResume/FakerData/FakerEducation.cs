using Bogus;
using DisplayResume.Models;

namespace DisplayResume.FakerData
{
	public class FakerEducation : Faker<Education>
	{
		public FakerEducation()
		{
			UseSeed(100)
				.RuleFor(o => o.Name, f => f.Commerce.ProductName())
				.RuleFor(o => o.Degree, f => f.Random.Words())
				.RuleFor(o => o.Address, f => new FakerAddress().Generate())
				.RuleFor(o => o.Duration, f => new FakerDuration().Generate())
				.RuleFor(o => o.HasGraduated, f => f.Random.Bool())
				.RuleFor(o => o.Major, f => f.Random.Words())
				.RuleFor(o => o.Minor, f => f.Random.Words())
				.RuleFor(o => o.Studies, f => f.Make(3, () => f.Lorem.Text()));

		}
	}
}
