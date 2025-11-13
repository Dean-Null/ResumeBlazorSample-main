using System.Text;
using DisplayResume.Models.Enums;
using DisplayResume.Models.Extensions;

namespace DisplayResume.Models
{
	public class Resume
	{
		private List<Organization> organizations = [];

		private DateTime timelimit = DateTime.Now.AddYears(-10);

		public Resume()
		{
			Education = Education.OrderByDescending(edu => edu.Duration.EndDate).ToList();
			Organizations = Organizations.OrderByDescending(org => org.Duration.EndDate).ToList();
			Technologies = Technologies.OrderByDescending(tech => tech.Focus).ToList();
			TechDict = PrintList();
		}

		public string Summary { get; set; } = string.Empty;
		public ContactInfo Contact { get; set; } = new();
		public List<Education> Education { get; set; } = [];
		public List<Organization> Organizations
		{
			get => organizations.OrderByDescending(org => org.Duration.StartDate).ToList();
			set => organizations = value;
		}
		public List<Technology> Technologies { get; set; } = [];
		public List<string> UsedDescriptors { get; set; } = [];
		public List<string> Qualifications { get; set; } = [];
		public Dictionary<string, string> TechDict { get; set; }

		public string GetMyName()
		{
			return Contact.FirstLastName();
		}

		public string GetMyAddress()
		{
			return Contact.Address.USAddress();
		}

		public void GetTimeLimtedOrganizations()
		{
			Organizations = Organizations.Where(org => org.Duration.EndDate >= timelimit).OrderByDescending(org => org.Duration.EndDate).ToList();
		}

		public List<Technology> GetTechnologyFocus(EnumFocus focusValue) =>
			Technologies.Where(tech => tech.Focus == focusValue)
			.ToList();

		public static IEnumerable<EnumFocus> GetFocustList()
		{
			return Enum.GetValues<EnumFocus>().OrderBy(focus => focus.GetDisplayName()).Cast<EnumFocus>();
		}

		public Dictionary<string, string> PrintList()
		{
			Dictionary<string, string> dict = new();
			StringBuilder stringBuilder = new();

			foreach (EnumFocus techFocus in GetFocustList())
			{
				string techlist = string.Empty;
				stringBuilder.AppendLine($"{techFocus.GetDisplayShortName()}: ");

				List<Technology> focusTech = GetTechnologyFocus(techFocus);
				foreach (Technology technology in focusTech)
				{
					stringBuilder.Append(technology.Name);
					techlist += $"{technology.Name}";
					if (!technology.Equals(focusTech.Last()))
					{
						stringBuilder.Append(", ");
						techlist += ", ";
					}
				}
				stringBuilder.AppendLine("\n");
				dict.Add($"{techFocus.GetDisplayShortName()}: ", techlist);
			}

			return dict;
		}

		public override bool Equals(object? obj)
		{
			return obj is Resume resume &&
				   Summary == resume.Summary &&
				   Contact.Equals(resume.Contact) &&
				   Education.Equals(resume.Education) &&
				   Organizations.Equals(resume.Organizations) &&
				   Technologies.Equals(resume.Technologies);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(
                Contact,
                Summary,
                Organizations.Count,
                Education.Count,
                Technologies.Count
            );
		}

		public override string? ToString()
		{
			StringBuilder sb = new();

			sb.Append(Contact.ToString());
			sb.AppendLine(Summary);
			sb.AppendLine("Experience:");
			Organizations.ForEach(org => sb.AppendLine(org.ToString()));
			sb.AppendLine("Education:");
			Education.ForEach(edu => sb.AppendLine(edu.ToString()));
			sb.AppendLine("Skills:");
			Technologies.Where(tech => !tech.Retired).ToList().ForEach(tech => sb.AppendLine(tech.ToString()));

			return sb.ToString();
		}

	}
}
