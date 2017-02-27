using System;
using System.Collections.Generic;
using MyCashFlow.Domains.DataObject;
using MyCashFlow.Repositories.Repository;

namespace MyCashFlow.Web.Services
{
	public class CountryService : ICountryService
	{
		private readonly IReadOnlyRepository<Country> countryRepository;

		public CountryService(IReadOnlyRepository<Country> countryRepository)
		{
			if(countryRepository == null)
			{
				throw new ArgumentNullException(nameof(countryRepository));
			}

			this.countryRepository = countryRepository;
		}

		public IEnumerable<Country> GetAllCountries()
		{
			var countries = countryRepository.Get();
			return countries;
		}

		public Country GetCountry(short countryId)
		{
			var country = countryRepository.GetByID(countryId);
			return country;
		}
	}
}