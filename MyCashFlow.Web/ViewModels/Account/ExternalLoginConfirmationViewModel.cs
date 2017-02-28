using System.ComponentModel.DataAnnotations;

namespace MyCashFlow.Web.ViewModels.Account
{
	public class ExternalLoginConfirmationViewModel
	{
		[Required]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}
}