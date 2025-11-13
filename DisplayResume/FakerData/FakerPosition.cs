using Bogus;
using DisplayResume.Models;

namespace DisplayResume.FakerData
{
	public class FakerPosition : Faker<Position>
	{
		public FakerPosition()
		{
			UseSeed(100)
				.RuleFor(o => o.Role, f => f.Name.JobTitle())
				.RuleFor(o => o.Duties, f => f.Make(3, () => f.Lorem.Sentence()).ToList());
		}
	}
}
