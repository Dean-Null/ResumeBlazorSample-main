using System.ComponentModel.DataAnnotations;
using System.Text;
using DisplayResume.Models.Enums;
using DisplayResume.Models.Extensions;

namespace DisplayResume.Models
{
	public class Organization
	{
		[MaxLength(49)]
		public string Name { get; set; } = string.Empty;
		public Address Address { get; set; } = new();
		public List<Position> Positions { get; set; } = [];
		public Duration Duration { get; set; } = new();
		public EnumEmployment Employment { get; set; } = EnumEmployment.None;
		public string Description { get; set; } = string.Empty;

		public Organization() { }

		public string GetOrganizationDescription()
		{
			return Description;
		}

		public string GetName(string delimiter = "")
		{
			return Name + delimiter;
		}

		public string GetOrgShortDuration(string delimiter = "")
		{
			return Duration.GetShortDuration() + delimiter;
		}

		public string GetOrgDuration(string delimiter = "")
		{
			return Duration.GetNumericalDuration() + delimiter;
		}

		public string GetAddress(string delimiter = "")
		{
			return Address.CityState() + delimiter;
		}

		public string GetLastPositionName()
		{
			return Positions.Last().Role;
		}

		public override bool Equals(object? obj)
		{
			return obj is Organization organization &&
				   Name == organization.Name &&
				   Address.Equals(organization.Address) &&
				   Positions.Equals(organization.Positions) &&
				   Duration.Equals(organization.Duration);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(
				Name,
				Address,
				Positions.Count,
				Duration
			);
		}

		public override string? ToString()
		{
			StringBuilder sb = new();

			sb.AppendLine(Description);
			sb.AppendLine(GetOrgShortDuration());
			Positions.ForEach(position => sb.AppendLine(position.ToString()));
			sb.AppendLine(Employment.GetDisplayName());
			sb.AppendLine(Name);
			sb.AppendLine(Address.USAddress());
			sb.AppendLine(GetOrganizationDescription());

			return sb.ToString();
		}
	}
}
