using MyCashFlow.Domains.DataObject;
using MyCashFlow.Repositories.Repository;
using System.Collections.Generic;
using System;

namespace MyCashFlow.Web.Services
{
	public class UserService : IUserService
	{
		private readonly IRepository<User> userRepository;

		public UserService(IRepository<User> userRepository)
		{
			if (userRepository == null)
			{
				throw new ArgumentNullException(nameof(userRepository));
			}

			this.userRepository = userRepository;
		}

		public User GetUser(int userId)
		{
			var user = userRepository.GetByID(userId);
			return user;
		}

		public IEnumerable<User> GetAllUsers()
		{
			var users = userRepository.Get();
			return users;
		}

		public void InsertUser(User user)
		{
			userRepository.Insert(user);
			userRepository.Save();
		}

		public void UpdateUser(User user)
		{
			userRepository.Update(user);
			userRepository.Save();
		}

		public void DeleteUser(int userId)
		{
			userRepository.Delete(userId);
			userRepository.Save();
		}
	}
}