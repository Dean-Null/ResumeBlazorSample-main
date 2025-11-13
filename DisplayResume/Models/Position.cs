using System.Text;
using DisplayResume.Models.Enums;

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
			AddPersistentDuties();
			PoolIntoModifiedDuties();
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

			AddPersistentDuties();
			PoolIntoModifiedDuties();
		}

		internal UpdatedDutiesBase dutiesBase = new();
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

		private void AddPersistentDuties()
		{
			if (Automated)
			{
				foreach (KeyValuePair<int, string> item in dutiesBase.Automation)
				{
					DutiesPool.TryAdd(item.Key, item.Value);
				}
			}
			if (Manual)
			{
				foreach (KeyValuePair<int, string> item in dutiesBase.Manual)
				{
					DutiesPool.TryAdd(item.Key, item.Value);
				}
			}
			if (Teambased)
			{
				foreach (KeyValuePair<int, string> item in dutiesBase.Teamss)
				{
					DutiesPool.TryAdd(item.Key, item.Value);
				}
			}
		}

		private void PoolIntoModifiedDuties()
		{
			foreach (KeyValuePair<int, string> item in Duties)
			{
				DutiesPool.TryAdd(item.Key, item.Value);
			}
			foreach (KeyValuePair<int, string> item in PreselectedDuties)
			{
				DutiesPool.TryAdd(item.Key, item.Value);
			}

			Duties.Clear();
		}

		public void GetUniqueDuties(int limitAmount, List<string> usedStrings)
		{
			Duties = DutiesPool.Where(desc => !usedStrings.Contains(desc.Value) && desc.Key < 1000)
				.OrderByDescending(x => x.Key)
				.Take(limitAmount)
				.ToDictionary();
		}

		public void GetParameterDuties(int limitAmount, List<string> usedStrings)
		{
			Duties = DutiesPool.Where(desc => !usedStrings.Contains(desc.Value) && desc.Key > 1000)
				.OrderByDescending(x => x.Key)
				.ThenBy(x => x.Value)
				.ToDictionary();
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
