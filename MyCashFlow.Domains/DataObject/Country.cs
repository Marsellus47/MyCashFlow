namespace MyCashFlow.Domains.DataObject
{
	public class Country
	{
		public short ID { get; set; }
		public string Name { get; set; }
		public string ISOCode2 { get; set; }
		public string ISOCode3 { get; set; }
		public short TelephoneCountryCode { get; set; }
		public bool Active { get; set; } = true;
	}
}
