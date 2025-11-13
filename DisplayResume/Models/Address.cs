using System.ComponentModel.DataAnnotations;

namespace DisplayResume.Models
{
	public class Address
	{
		[MaxLength(36)]
		public string Address1 { get; set; } = string.Empty;
		[MaxLength(36)]
		public string Address2 { get; set; } = string.Empty;
		[MaxLength(36)]
		public string City { get; set; } = string.Empty;
		[MaxLength(2)]
		public string State { get; set; } = "";
		public int PostalCode { get; set; }
		public string Country { get; set; } = "";

		internal string AddressStart() => $"{Address1}";

		public string CityState() => $"{City}, {State}".Trim(' ', ',');
		public string USAddress() => $"{AddressStart()}, {CityState()} {PostalCode}".Trim(' ', ',');
		public string FullAddress() => $"{AddressStart()}, {CityState()} {PostalCode}, {Country}".Trim(' ', ',');

		public override bool Equals(object? obj)
		{
			return obj is Address info &&
				   Address1 == info.Address1 &&
				   Address2 == info.Address2 &&
				   City == info.City &&
				   State == info.State &&
				   PostalCode == info.PostalCode &&
				   Country == info.Country;
		}

		public override int GetHashCode()
		{
			throw new NotImplementedException();
		}

		public override string? ToString() => FullAddress();
	}
}
