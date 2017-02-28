using MyCashFlow.Domains.DataObject;
using MyCashFlow.Repositories.Repository;
using MyCashFlow.Web.Models;
using MyCashFlow.Web.ViewModels.User;
using System.Collections.Generic;
using System;

namespace MyCashFlow.Web.Services
{
	public class UserService : IUserService
	{
		private readonly IRepository<User> userRepository;
		private readonly IReadOnlyRepository<Country> countryRepository;
		private readonly IRepository<Address> addressRepository;
		private readonly IRepository<Contact> contactRepository;

		public UserService(
			IRepository<User> userRepository,
			IReadOnlyRepository<Country> countryRepository,
			IRepository<Address> addressRepository,
			IRepository<Contact> contactRepository)
		{
			if (userRepository == null)
			{
				throw new ArgumentNullException(nameof(userRepository));
			}
			if (countryRepository == null)
			{
				throw new ArgumentNullException(nameof(countryRepository));
			}
			if (addressRepository == null)
			{
				throw new ArgumentNullException(nameof(addressRepository));
			}
			if (contactRepository == null)
			{
				throw new ArgumentNullException(nameof(contactRepository));
			}

			this.userRepository = userRepository;
			this.countryRepository = countryRepository;
			this.addressRepository = addressRepository;
			this.contactRepository = contactRepository;
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

		public void InsertUpdateUser(UserVm userVm)
		{
			try
			{
				switch (userVm.DatabaseOperation)
				{
					case DatabaseOperation.Insert:
						userRepository.Insert(userVm.User);
						break;
					case DatabaseOperation.Update:
						userRepository.Update(userVm.User);
						break;
				}
				
				if(!userVm.User.AddressID.HasValue)
				{
					addressRepository.Insert(userVm.User.Address);
				}
				else
				{
					addressRepository.Update(userVm.User.Address);
				}

				if (!userVm.User.ContactID.HasValue)

				{
					contactRepository.Insert(userVm.User.Contact);
				}
				else
				{
					contactRepository.Update(userVm.User.Contact);
				}

				userRepository.Save();
				addressRepository.Save();
				contactRepository.Save();
			}
			catch
			{
				throw;
			}
		}

		public void DeleteUser(int userId)
		{
			userRepository.Delete(userId);
			var user = GetUser(userId);

			if (user.AddressID.HasValue)
			{
				addressRepository.Delete(user.AddressID.Value);
			}

			if (user.ContactID.HasValue)
			{
				contactRepository.Delete(user.ContactID.Value);
			}

			userRepository.Save();
			addressRepository.Save();
			contactRepository.Save();
		}

		public UserVm BuildUserVm(int? userId = null)
		{
			var result = new UserVm
			{
				Countries = countryRepository.Get()
			};

			if (userId.HasValue)
			{
				result.User = GetUser(userId.Value);
				result.DatabaseOperation = DatabaseOperation.Update;
			}

			return result;
		}
	}
}