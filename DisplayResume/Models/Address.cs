using System.ComponentModel.DataAnnotations;

namespace DisplayResume.Models
{
	public class Address
	{
		[MaxLength(36)]
		public string AddressFirst { get; set; } = string.Empty;
		[MaxLength(36)]
		public string AddressSecond { get; set; } = string.Empty;
		[MaxLength(36)]
		public string City { get; set; } = string.Empty;
		[MaxLength(2)]
		public string State { get; set; } = "";
		public int PostalCode { get; set; }
		public string Country { get; set; } = "";

		internal string AddressStart() => $"{AddressFirst}";

		public string CityState() => $"{City}, {State}".Trim(' ', ',');
		public string USAddress() => $"{AddressStart()}, {CityState()} {PostalCode}".Trim(' ', ',');
		public string FullAddress() => $"{AddressStart()}, {CityState()} {PostalCode}, {Country}".Trim(' ', ',');

		public override bool Equals(object? obj)
		{
			return obj is Address info &&
				   AddressFirst == info.AddressFirst &&
				   AddressSecond == info.AddressSecond &&
				   City == info.City &&
				   State == info.State &&
				   PostalCode == info.PostalCode &&
				   Country == info.Country;
		}

		public override int GetHashCode()
		{
            return HashCode.Combine(AddressFirst, AddressSecond, City, State, PostalCode, Country);
		}

		public override string? ToString() => FullAddress();
	}
}
