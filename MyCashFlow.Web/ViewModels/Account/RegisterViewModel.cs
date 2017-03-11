using MyCashFlow.Domains.Artificial;
using MyCashFlow.Domains.DataObject;
using MyCashFlow.Web.Infrastructure.Automapper;
using Rsx = MyCashFlow.Resources.Localization.Views.Account.Register;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyCashFlow.Web.ViewModels.Account
{
	public class RegisterViewModel : IMapTo<Domains.DataObject.User>
	{
		#region Main info

		[Required]
		[StringLength(128)]
		[Display(Name = nameof(Rsx.Field_Username), ResourceType = typeof(Rsx))]
		public string UserName { get; set; }

		[Required]
		[StringLength(100, MinimumLength = 6, ErrorMessageResourceType = typeof(Rsx), ErrorMessageResourceName = nameof(Rsx.Field_Password_StringLength_ErrorMessage))]
		[DataType(DataType.Password)]
		[Display(Name = nameof(Rsx.Field_Password), ResourceType = typeof(Rsx))]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = nameof(Rsx.Field_ConfirmPassword), ResourceType = typeof(Rsx))]
		[Compare(nameof(Password), ErrorMessageResourceType = typeof(Rsx), ErrorMessageResourceName = nameof(Rsx.Field_ConfirmPassword_Compare_ErrorMessage))]
		public string ConfirmPassword { get; set; }

		#endregion

		#region Additional info

		[Display(Name = nameof(Rsx.Field_Gender), ResourceType = typeof(Rsx))]
		public Gender Gender { get; set; }

		[Display(Name = nameof(Rsx.Field_FirstName), ResourceType = typeof(Rsx))]
		public string FirstName { get; set; }

		[Display(Name = nameof(Rsx.Field_MiddleName), ResourceType = typeof(Rsx))]
		public string MiddleName { get; set; }

		[Display(Name = nameof(Rsx.Field_LastName), ResourceType = typeof(Rsx))]
		public string LastName { get; set; }

		#endregion

		#region Contact info

		[Required]
		[EmailAddress]
		[Display(Name = nameof(Rsx.Field_Email), ResourceType = typeof(Rsx))]
		public string Email { get; set; }

		[Phone]
		[Display(Name = nameof(Rsx.Field_PhoneNumber), ResourceType = typeof(Rsx))]
		public string PhoneNumber { get; set; }

		#endregion

		#region Address info

		[Display(Name = nameof(Rsx.Field_Country), ResourceType = typeof(Rsx))]
		public short CountryID { get; set; }

		public IEnumerable<Country> Countries { get; set; }

		[Display(Name = nameof(Rsx.Field_AddressLine1), ResourceType = typeof(Rsx))]
		public string AddressLine1 { get; set; }

		[Display(Name = nameof(Rsx.Field_AddressLine2), ResourceType = typeof(Rsx))]
		public string AddressLine2 { get; set; }

		[Display(Name = nameof(Rsx.Field_City), ResourceType = typeof(Rsx))]
		public string City { get; set; }

		[Display(Name = nameof(Rsx.Field_Zip), ResourceType = typeof(Rsx))]
		public string Zip { get; set; }

		[Display(Name = nameof(Rsx.Field_District), ResourceType = typeof(Rsx))]
		public string District { get; set; }

		#endregion
	}
}