using MyCashFlow.Domains.DataObject;
using System.Collections.Generic;

namespace MyCashFlow.Web.Services
{
	public interface ICountryService
	{
		IEnumerable<Country> GetAllCountries();
		Country GetCountry(short countryId);
	}
}
