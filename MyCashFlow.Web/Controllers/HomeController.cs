using MyCashFlow.Web.Infrastructure.Controllers;
using MyCashFlow.Web.Services.Home;
using System.Threading.Tasks;
using System.Web.Mvc;
using System;

namespace MyCashFlow.Web.Controllers
{
	public partial class HomeController : UserManagerBasedController
	{
		private readonly IHomeService _homeService;

		public HomeController(IHomeService homeService)
		{
			if (homeService == null)
			{
				throw new ArgumentNullException(nameof(homeService));
			}

			_homeService = homeService;
		}

		public virtual async Task<ActionResult> Index()
		{
			var userId = await GetCurrentUserIdAsync();
			var model = _homeService.BuildHomeIndexViewModel(userId);
			return View(model);
		}
	}
}