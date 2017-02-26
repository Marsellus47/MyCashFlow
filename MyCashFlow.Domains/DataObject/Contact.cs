namespace MyCashFlow.Domains.DataObject
{
	public class Contact
	{
		public int ID { get; set; }
		public string Phone { get; set; }
		public string Mobile { get; set; }
		public string Email { get; set; }
		public bool Active { get; set; } = true;
	}
}
