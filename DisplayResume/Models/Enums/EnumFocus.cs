using System.ComponentModel.DataAnnotations;

namespace DisplayResume.Models.Enums
{
	public enum EnumFocus
	{
		[Display(Name = "Application Protocol Interface", ShortName = "API")]
		API = 0,
		[Display(Name = "Continuous Integration Continuous Development", ShortName = "CI/CD")]
		CICD = 1,
		[Display(Name = "Database", ShortName = "Database")]
		Database = 2,
		[Display(Name = "Framework", ShortName = "Framework")]
		Framework = 4,
		[Display(Name = "Integrated Development Environment", ShortName = "IDE")]
		IDE = 5,
		[Display(Name = "Programming Language", ShortName = "Language")]
		Language = 6,
		[Display(Name = "Library", ShortName = "Library")]
		Library = 7,
		[Display(Name = "Message Bus", ShortName = "Message")]
		MessageBus = 8,
		[Display(Name = "Network Tool", ShortName = "Network")]
		NetworkTool = 9,
		[Display(Name = "Mobile Operating System", ShortName = "Mobile OS")]
		MobileOperatingSystem = 10,
		[Display(Name = "Project Management", ShortName = "Tasking")]
		ProjectManagement = 11,
		[Display(Name = "Service", ShortName = "Cloud Service")]
		Service = 13,
		[Display(Name = "Testing Framework", ShortName = "Test framework")]
		TestingFramework = 15,
		[Display(Name = "Version Control", ShortName = "Versioning")]
		VersionControl = 16,
		[Display(Name = "Containerization", ShortName = "Containers")]
		Containers = 17,
		[Display(Name = "Server", ShortName = "Server")]
		Server = 18,
		[Display(Name = "Command Line Interface", ShortName = "CLI")]
		CommandLineInterface = 19,
		[Display(Name = "Operating System", ShortName = "OS")]
		OperatingSystem = 20,
		[Display(Name = "Office", ShortName = "Office")]
		Office = 21,
		[Display(Name = "Format", ShortName = "Format")]
		Format = 22,
		[Display(Name = "Authorization", ShortName = "Auth")]
		Authorization = 23,
		[Display(Name = "Logging Service", ShortName = "Logging")]
		Logging = 24,
		[Display(Name = "Hardware", ShortName = "Hardware")]
		Hardware = 25
	}
}
