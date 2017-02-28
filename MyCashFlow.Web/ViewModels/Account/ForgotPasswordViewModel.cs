using System.ComponentModel.DataAnnotations;

namespace MyCashFlow.Web.ViewModels.Account
{
	public class ForgotPasswordViewModel
	{
		[Required]
		[EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}
}