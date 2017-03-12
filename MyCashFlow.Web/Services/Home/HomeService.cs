using MyCashFlow.Repositories;
using MyCashFlow.Web.ViewModels.Home;
using System.Linq;
using System;

namespace MyCashFlow.Web.Services.Home
{
	public class HomeService : IHomeService
	{
		private readonly IUnitOfWork _unitOfWork;

		public HomeService(IUnitOfWork unitOfWork)
		{
			if (unitOfWork == null)
			{
				throw new ArgumentNullException(nameof(unitOfWork));
			}

			_unitOfWork = unitOfWork;
		}

		public HomeIndexViewModel BuildHomeIndexViewModel(int userId)
		{
			var allProjects = _unitOfWork.ProjectRepository.Get(x => x.CreatorID == userId);
			var finishedProjects = allProjects.Where(x => x.ValidTill < DateTime.Now.Date);
			var openProjects = allProjects.Except(finishedProjects);
			var openFilledProjects = openProjects.Where(x => x.ActualValue >= x.Budget);
			var numberOfFinishedFilledProjects = finishedProjects.Where(x => x.ActualValue >= x.Budget).Count();
			var numberOfTotalFilledProjects = allProjects.Where(x => x.ActualValue >= x.Budget).Count();
			var numberOfNonFilledProjects = openProjects.Except(openFilledProjects).Count();

			var model = new HomeIndexViewModel
			{
				Projects = allProjects.Count(),
				FinishedProjects = finishedProjects.Count(),
				OpenProjects = openProjects.Count(),
				OpenFilledProjects = openFilledProjects.Count(),
				FinishedFilledProjects = numberOfFinishedFilledProjects,
				TotalFilledProjects = numberOfTotalFilledProjects,
				NonFilledProjects = numberOfNonFilledProjects
			};
			return model;
		}
	}
}