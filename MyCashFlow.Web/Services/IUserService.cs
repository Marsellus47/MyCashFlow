using MyCashFlow.Domains.DataObject;
using MyCashFlow.Web.ViewModels.User;
using System.Collections.Generic;

namespace MyCashFlow.Web.Services
{
	public interface IUserService
	{
		User GetUser(int userId);
		IEnumerable<User> GetAllUsers();
		void InsertUpdateUser(UserVm userVm);
		void DeleteUser(int userId);
		UserVm BuildUserVm(int? userId = null);
	}
}
