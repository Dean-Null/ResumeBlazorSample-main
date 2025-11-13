using Bogus;
using DisplayResume.Models;

namespace DisplayResume.FakerData
{
	public class FakerDuration : Faker<Duration>
	{
		public FakerDuration()
		{
			UseSeed(100)
				.RuleFor(o => o.StartDate, f => f.Date.Past())
				.RuleFor(o => o.EndDate, f => f.Date.Future());
		}
	}
}
