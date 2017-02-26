using MyCashFlow.Domains.DataObject;
using System.Collections.Generic;

namespace MyCashFlow.Web.Services
{
	public interface IUserService
	{
		User GetUser(int userId);
		IEnumerable<User> GetAllUsers();
		void InsertUser(User user);
		void UpdateUser(User user);
		void DeleteUser(int userId);
	}
}
