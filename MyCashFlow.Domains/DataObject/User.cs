using MyCashFlow.Domains.Artificial;

namespace MyCashFlow.Domains.DataObject
{
	public class User
	{
		public int ID { get; set; }
		public string NickName { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public Gender Gender { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public int AddressID { get; set; }
		public int ContactID { get; set; }
		public bool Active { get; set; } = true;

		public virtual Address Address { get; set; }
		public virtual Contact Contact { get; set; }
	}
}
