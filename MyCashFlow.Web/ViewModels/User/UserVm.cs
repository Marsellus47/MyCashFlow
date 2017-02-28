using MyCashFlow.Domains.DataObject;
using System.Collections.Generic;

namespace MyCashFlow.Web.ViewModels.User
{
	public class UserVm : BaseVm
	{
		public Domains.DataObject.User User { get; set; }
		public IEnumerable<Country> Countries { get; set; }
	}
}