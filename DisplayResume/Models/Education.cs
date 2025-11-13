using System.Text;
using DisplayResume.Models.Abstraction;

namespace DisplayResume.Models
{
	public class Education : Section
	{
		public Education() => Header = "Education";
		public string Name { get; set; } = string.Empty;
		public string Degree { get; set; } = string.Empty;
		public Address Address { get; set; } = new();
		public Duration Duration { get; set; } = new();
		public bool HasGraduated { get; set; } = true;
		public string Major { get; set; } = string.Empty;
		public string Minor { get; set; } = string.Empty;
		public IList<string> Studies { get; set; } = [];

		public string GetName()
		{
			return Name;
		}

		public string GetName(string delimiter)
		{
			return Name + delimiter;
		}

		public string VerboseDegree()
		{
			return $"{Degree} in {Major}";
		}

		public string GetDetails()
		{
			if (Major != string.Empty)
				return $"{Degree} in {Major}";
			return Degree;
		}

		public string GetDuration()
		{
			return Duration.GetGradYear(",");
		}

		public override bool Equals(object? obj)
		{
			return obj is Education education &&
				   Name == education.Name &&
				   Degree == education.Degree &&
				   Address.Equals(education.Address) &&
				   Duration.Equals(education.Duration) &&
				   HasGraduated == education.HasGraduated &&
				   Major == education.Major &&
				   Minor == education.Minor;
		}

		public override int GetHashCode()
		{
			throw new NotImplementedException();
		}

		public override string? ToString()
		{
			StringBuilder sb = new();

			sb.AppendLine(Name);
			sb.AppendLine(Duration.ToString());
			sb.AppendLine(GetDetails());
			sb.AppendLine(Minor);

			return sb.ToString();
		}

		public override string PrintSection()
		{
			throw new NotImplementedException();
		}

	}
}
