using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using MyCashFlow.Identity.Managers;
using MyCashFlow.Identity.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;

namespace MyCashFlow.Web.Infrastructure.Controllers
{
	public abstract class UserManagerBasedController : Controller
	{
		private ApplicationUserManager _userManager;

		public UserManagerBasedController() { }

		public UserManagerBasedController(ApplicationUserManager userManager)
		{

		}

		public ApplicationUserManager UserManager
		{
			get
			{
				return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
			}
			private set
			{
				_userManager = value;
			}
		}

		protected async Task<ApplicationUser> GetCurrentUserAsync()
		{
			var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
			return user;
		}

		protected ApplicationUser GetCurrentUser()
		{
			var user = UserManager.FindById(User.Identity.GetUserId());
			return user;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_userManager != null)
				{
					_userManager.Dispose();
					_userManager = null;
				}
			}

			base.Dispose(disposing);
		}
	}
}