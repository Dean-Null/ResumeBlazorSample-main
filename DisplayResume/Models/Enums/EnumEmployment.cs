using System.ComponentModel.DataAnnotations;

namespace DisplayResume.Models.Enums
{
	public enum EnumEmployment
	{
		[Display(Name = "None", ShortName = "N")]
		None = 0,
		[Display(Name = "Independent", ShortName = "IDPT")]
		Independent = 1,
		[Display(Name = "Contract", ShortName = "CNRT")]
		Contract = 2,
		[Display(Name = "Full-Time", ShortName = "FTE")]
		FullTime = 3,
		[Display(Name = "Part-Time", ShortName = "PTE")]
		PartTime = 4,
		[Display(Name = "Seasonal", ShortName = "SSNL")]
		Seasonal = 5
	}
}
