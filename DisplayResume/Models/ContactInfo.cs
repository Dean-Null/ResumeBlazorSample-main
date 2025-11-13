using System.ComponentModel.DataAnnotations;
using System.Text;
using DisplayResume.Models.Abstraction;

namespace DisplayResume.Models
{
	public class ContactInfo : Section
	{
		public ContactInfo() => Header = "ContactInfo";

		public string URLAddress = "";
		public string URLLinkedIn = "";

		[MaxLength(36)]
		public string FirstName { get; set; } = string.Empty;
		[MaxLength(36)]
		public string? MiddleName { get; set; }
		[MaxLength(36)]
		public string LastName { get; set; } = string.Empty;
		public Address Address { get; set; } = new();
		[MaxLength(10)]
		public string PhoneNumber { get; set; } = string.Empty;
		[MaxLength(64)]
		public string EmailAddress { get; set; } = string.Empty;

		public string FullName() => $"{FirstName} {MiddleName} {LastName}";

		public override bool Equals(object? obj)
		{
			return obj is ContactInfo info &&
				   FirstName == info.FirstName &&
				   MiddleName == info.MiddleName &&
				   LastName == info.LastName &&
				   Address.Equals(info.Address) &&
				   PhoneNumber == info.PhoneNumber &&
				   EmailAddress == info.EmailAddress;
		}

		public override int GetHashCode()
		{
			throw new NotImplementedException();
		}

		public override string? ToString()
		{
			StringBuilder sb = new();

			sb.AppendLine($"{FirstName} {LastName}");
			sb.AppendLine(Address.ToString());
			sb.AppendLine(PhoneNumber);
			sb.AppendLine(EmailAddress);

			return sb.ToString();
		}

		public override string PrintSection()
		{
			throw new NotImplementedException();
		}
	}
}
