using MyCashFlow.Domains.DataObject;
using System.Collections.Generic;
using System;

namespace MyCashFlow.Web.Infrastructure.ProjectsFilter
{
	public static class ProjectsFilterTypeResolver
	{
		private static readonly Dictionary<ProjectsFilterType, Func<Project, bool>> projectsFilterTypes;

		static ProjectsFilterTypeResolver()
		{
			projectsFilterTypes = new Dictionary<ProjectsFilterType, Func<Project, bool>>
			{
				{ ProjectsFilterType.AllProjects, project => true },
				{ ProjectsFilterType.OpenProjects, project => project.ValidTill >= DateTime.Now || !project.ValidTill.HasValue },
				{ ProjectsFilterType.OpenProjectsWithSpentBudget, project => (project.ValidTill >= DateTime.Now || !project.ValidTill.HasValue) && project.ActualValue >= project.Budget },
				{ ProjectsFilterType.OpenProjectsWithUnspentBudget, project => (project.ValidTill >= DateTime.Now || !project.ValidTill.HasValue) && project.ActualValue < project.Budget },
				{ ProjectsFilterType.OpenProjectsWithUnknownBudget, project => (project.ValidTill >= DateTime.Now || !project.ValidTill.HasValue) && !project.Budget.HasValue },
				{ ProjectsFilterType.OpenProjectsWithReachedTargetValue, project => (project.ValidTill >= DateTime.Now || !project.ValidTill.HasValue) && project.ActualValue >= project.TargetValue },
				{ ProjectsFilterType.OpenProjectsWithMissedTargetValue, project => (project.ValidTill >= DateTime.Now || !project.ValidTill.HasValue) && project.ActualValue < project.TargetValue },
				{ ProjectsFilterType.OpenProjectsWithUnknownTargetValue, project => (project.ValidTill >= DateTime.Now || !project.ValidTill.HasValue) && !project.TargetValue.HasValue },
				{ ProjectsFilterType.FinishedProjects, project => project.ValidTill < DateTime.Now },
				{ ProjectsFilterType.FinishedProjectsWithSpentBudget, project => project.ValidTill < DateTime.Now && project.ActualValue >= project.Budget },
				{ ProjectsFilterType.FinishedProjectsWithUnspentBudget, project => project.ValidTill < DateTime.Now && project.ActualValue < project.Budget },
				{ ProjectsFilterType.FinishedProjectsWithUnknownBudget, project => project.ValidTill < DateTime.Now && !project.Budget.HasValue },
				{ ProjectsFilterType.FinishedProjectsWithReachedTargetValue, project => project.ValidTill < DateTime.Now && project.ActualValue >= project.TargetValue },
				{ ProjectsFilterType.FinishedProjectsWithMissedTargetValue, project => project.ValidTill < DateTime.Now && project.ActualValue < project.TargetValue },
				{ ProjectsFilterType.FinishedProjectsWithUnknownTargetValue, project => project.ValidTill < DateTime.Now && !project.TargetValue.HasValue }
			};
		}

		public static Func<Project, bool> ResolveFilter(ProjectsFilterType filterType)
		{
			return projectsFilterTypes[filterType];
		}
	}
}