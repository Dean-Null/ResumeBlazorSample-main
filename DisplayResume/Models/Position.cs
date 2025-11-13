using System.Text;

namespace DisplayResume.Models
{
	public class Position
	{
		public string Role { get; set; } = string.Empty;
		public List<string> Duties { get; set; } = [];

		public string GetPositionTitle(string delimiter = "")
		{
			return Role + delimiter;
		}

		public override bool Equals(object? obj)
		{
			return obj is Position position &&
				   Role == position.Role;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Role, Duties.Count);
		}

		public override string? ToString()
		{
			StringBuilder sb = new();

			sb.AppendLine(Role);

			foreach (string item in Duties)
			{
				sb.AppendLine("\t" + item.ToString());
			}

			return sb.ToString();
		}
	}
}
