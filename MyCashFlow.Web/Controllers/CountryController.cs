using MyCashFlow.Web.Services;
using System;
using System.Web.Mvc;

namespace MyCashFlow.Web.Controllers
{
	public partial class CountryController : Controller
	{
		private readonly ICountryService countryService;

		public CountryController(ICountryService countryService)
		{
			if (countryService == null)
			{
				throw new ArgumentNullException(nameof(countryService));
			}

			this.countryService = countryService;
		}

		public virtual ActionResult Index()
		{
			var model = countryService.GetAllCountries();
			return View(model);
		}

		public virtual ActionResult Details(short id)
		{
			var model = countryService.GetCountry(id);
			return View(model);
		}
	}
}