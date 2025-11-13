using System.Text;
using DisplayResume.Models.Enums;
using DisplayResume.Models.Extensions;

namespace DisplayResume.Models
{
	public class Position
	{
		public Position() { }

		public Position(
			Dictionary<int, string> duties,
			Dictionary<int, string> preselectedDuties,
			EnumPositionRole role
			)
		{
			Role = role;
			Duties = duties;
			PreselectedDuties = preselectedDuties;

		}

		public EnumPositionRole Role { get; set; } = EnumPositionRole.None;
		public Dictionary<int, string> Duties { get; set; } = [];
		public Dictionary<int, string> PreselectedDuties { get; set; } = [];
		public Dictionary<int, string> DutiesPool { get; set; } = [];

		public string GetPositionTitle(string delimiter = "")
		{
			return Role.GetDisplayName() + delimiter;
		}

		public override bool Equals(object? obj)
		{
			return obj is Position position &&
				   Role == position.Role;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Role);
		}

		public override string? ToString()
		{
			StringBuilder sb = new();

			sb.AppendLine(Role.GetDisplayName());

			foreach (KeyValuePair<int, string> item in Duties)
			{
				sb.AppendLine("\t" + item.Value.ToString());
			}

			return sb.ToString();
		}
	}
}
