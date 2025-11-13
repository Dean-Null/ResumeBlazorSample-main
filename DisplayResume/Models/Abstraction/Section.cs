namespace DisplayResume.Models.Abstraction
{
	public abstract class Section
	{
		public string Header { get; set; } = string.Empty;

		public abstract string PrintSection();
	}
}
