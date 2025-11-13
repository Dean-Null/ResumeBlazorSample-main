using System.Text;
using DisplayResume.Models.Enums;
using DisplayResume.Models.Extensions;

namespace DisplayResume.Models
{
	public class Position
	{
		public Position(
			bool automated = false,
			bool development = false,
			bool devOps = false,
			bool manual = false
		)
		{
			Automated = automated;
			Development = development;
			DevOps = devOps;
			Manual = manual;
		}

		public Position(
			Dictionary<int, string> duties,
			Dictionary<int, string> preselectedDuties,
			EnumPositionRole role,
			bool automated = false,
			bool development = false,
			bool devOps = false,
			bool manual = false,
			bool teambased = false
			) : this(automated, development, devOps, manual)
		{
			Teambased = teambased;
			Role = role;
			Duties = duties;
			PreselectedDuties = preselectedDuties;

		}

		public bool Automated { get; set; } = false;
		public bool Development { get; set; } = false;
		public bool DevOps { get; set; } = false;
		public bool Manual { get; set; } = false;
		public bool Teambased { get; set; } = false;
		public EnumPositionRole Role { get; set; } = EnumPositionRole.QualityAssuranceTester;

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
				   Role == position.Role &&
				   Automated == position.Automated &&
				   Development == position.Development &&
				   DevOps == position.DevOps &&
				   Manual == position.Manual &&
				   Teambased == position.Teambased;
		}

		public override int GetHashCode()
		{
			throw new NotImplementedException();
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
