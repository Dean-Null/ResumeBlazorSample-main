using System.Text;
using DisplayResume.Models.Enums;
using DisplayResume.Models.Extensions;

namespace DisplayResume.Models
{
	public class Technology
	{
		public string Description { get; set; } = string.Empty;
		public EnumFocus Focus { get; set; } = EnumFocus.NetworkTool;
		public string Name { get; set; } = string.Empty;
		public string ProperName { get; set; } = string.Empty;
		public bool Retired { get; set; } = false;
		public string URL { get; set; } = string.Empty;

		public string GetName(string delimiter, List<Technology> TechList)
		{
			if (!Name.Equals(TechList.Last().Name))
			{
				return $"{Name}{delimiter}";
			}

			return Name;
		}

		public string GetUrl()
		{
			return URL.TrimEnd('/');
		}

		public override bool Equals(object? obj)
		{
			return obj is Technology technology &&
				   Description == technology.Description &&
				   Focus == technology.Focus &&
				   Name == technology.Name &&
				   Retired == technology.Retired &&
				   URL == technology.URL;
		}

		public override int GetHashCode()
		{
			throw new NotImplementedException();
		}

		public override string? ToString()
		{
			StringBuilder sb = new();
			if (string.IsNullOrEmpty(ProperName))
			{
				sb.AppendLine(Name);
			}
			else
			{
				sb.AppendLine($"{Name}({ProperName})");
			}

			sb.AppendLine(Focus.GetDisplayShortName());
			sb.AppendLine(GetUrl().ToString());

			return sb.ToString();
		}
	}
}
