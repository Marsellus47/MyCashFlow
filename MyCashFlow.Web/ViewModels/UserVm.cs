using MyCashFlow.Domains.DataObject;
using System.Collections.Generic;

namespace MyCashFlow.Web.ViewModels
{
	public class UserVm : BaseVm
	{
		public User User { get; set; }
		public IEnumerable<Country> Countries { get; set; }
	}
}