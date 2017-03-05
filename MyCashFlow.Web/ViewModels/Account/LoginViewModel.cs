using System.ComponentModel.DataAnnotations;
using Rsx = MyCashFlow.Resources.Localization.Views.Account.Login;

namespace MyCashFlow.Web.ViewModels.Account
{
	public class LoginViewModel
	{
		[Required]
		[Display(Name = nameof(Rsx.Field_UserName), ResourceType = typeof(Rsx))]
		public string UserName { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = nameof(Rsx.Field_Password), ResourceType = typeof(Rsx))]
		public string Password { get; set; }

		[Display(Name = nameof(Rsx.Field_RememberMe), ResourceType = typeof(Rsx))]
		public bool RememberMe { get; set; }
	}
}