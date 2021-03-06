﻿using System.ComponentModel.DataAnnotations;

namespace MyCashFlow.Web.ViewModels.Manage
{
	public class VerifyPhoneNumberViewModel
	{
		[Required]
		[Display(Name = "Code")]
		public string Code { get; set; }

		[Required]
		[Phone]
		[Display(Name = "Phone Number")]
		public string PhoneNumber { get; set; }
	}
}