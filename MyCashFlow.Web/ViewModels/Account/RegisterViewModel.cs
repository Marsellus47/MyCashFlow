using MyCashFlow.Domains.Artificial;
using MyCashFlow.Domains.DataObject;
using Rsx = MyCashFlow.Resources.Localization.Views.Account.Register;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyCashFlow.Web.ViewModels.Account
{
	public class RegisterViewModel
	{
		[Required]
		[StringLength(128)]
		[Display(Name = nameof(Rsx.Field_Username), ResourceType = typeof(Rsx))]
		public string UserName { get; set; }

		[Required]
		[EmailAddress]
		[Display(Name = nameof(Rsx.Field_Email), ResourceType = typeof(Rsx))]
		public string Email { get; set; }

		[Phone]
		[Display(Name = nameof(Rsx.Field_PhoneNumber), ResourceType = typeof(Rsx))]
		public string PhoneNumber { get; set; }

		[Required]
		[StringLength(100, MinimumLength = 6, ErrorMessageResourceType = typeof(Rsx), ErrorMessageResourceName = nameof(Rsx.Field_Password_StringLength_ErrorMessage))]
		[DataType(DataType.Password)]
		[Display(Name = nameof(Rsx.Field_Password), ResourceType = typeof(Rsx))]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = nameof(Rsx.Field_ConfirmPassword), ResourceType = typeof(Rsx))]
		[Compare(nameof(Password), ErrorMessageResourceType = typeof(Rsx), ErrorMessageResourceName = nameof(Rsx.Field_ConfirmPassword_Compare_ErrorMessage))]
		public string ConfirmPassword { get; set; }

		[Display(Name = nameof(Rsx.Field_Country), ResourceType = typeof(Rsx))]
		public short CountryID { get; set; }

		[Display(Name = nameof(Rsx.Field_Gender), ResourceType = typeof(Rsx))]
		public Gender Gender { get; set; }

		[Display(Name = nameof(Rsx.Field_FirstName), ResourceType = typeof(Rsx))]
		public string FirstName { get; set; }

		[Display(Name = nameof(Rsx.Field_MiddleName), ResourceType = typeof(Rsx))]
		public string MiddleName { get; set; }

		[Display(Name = nameof(Rsx.Field_LastName), ResourceType = typeof(Rsx))]
		public string LastName { get; set; }

		public IEnumerable<Country> Countries { get; set; }
	}
}