namespace MyCashFlow.Domains.DataObject
{
	public class Address
	{
		public int ID { get; set; }
		public string Line1 { get; set; }
		public string Line2 { get; set; }
		public string City { get; set; }
		public string Zip { get; set; }
		public string District { get; set; }
		public short CountryID { get; set; }
		public bool Active { get; set; } = true;

		public virtual Country Country { get; set; }
	}
}
