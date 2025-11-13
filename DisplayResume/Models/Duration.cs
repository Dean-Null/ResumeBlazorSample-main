namespace DisplayResume.Models
{
	public class Duration
	{
		public DateTime StartDate { get; init; } = DateTime.MinValue;
		public DateTime EndDate { get; init; } = DateTime.MaxValue;

		internal string HasEndDate(string formatting)
		{
			if (EndDate == DateTime.MaxValue)
				return "Current";

			return EndDate.ToString(formatting);
		}

		public string GetShortDuration() => $"{StartDate:MMM yyyy} – {HasEndDate("MMM yyyy")}";
		public string GetNumericalDuration() => $"{StartDate:MM/yyyy} – {HasEndDate("MM/yyyy")}";
		public string GetLongDuration() => $"{StartDate:MMMM yyyy} – {HasEndDate("MMMM yyyy")}";
		public string GetLongDuration(string delimiter) => $"{GetLongDuration()}{delimiter}";
		public string GetGradYear(string delimiter) => $"Graduation {EndDate:yyyy}{delimiter}";

		public override bool Equals(object? obj)
		{
			return obj is Duration duration &&
				   StartDate == duration.StartDate &&
				   EndDate == duration.EndDate;
		}

		public override int GetHashCode()
		{
            return HashCode.Combine(StartDate, EndDate);
		}

		public override string? ToString() => GetNumericalDuration();
	}
}
