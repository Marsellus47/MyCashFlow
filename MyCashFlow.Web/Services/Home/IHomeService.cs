using MyCashFlow.Web.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCashFlow.Web.Services.Home
{
	public interface IHomeService
	{
		HomeIndexViewModel BuildHomeIndexViewModel(int userId);
	}
}
