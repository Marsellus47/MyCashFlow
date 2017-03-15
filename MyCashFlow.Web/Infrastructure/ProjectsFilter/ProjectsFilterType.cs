namespace MyCashFlow.Web.Infrastructure.ProjectsFilter
{
	public enum ProjectsFilterType
	{
		AllProjects,
		OpenProjects,
		OpenProjectsWithSpentBudget,
		OpenProjectsWithUnspentBudget,
		OpenProjectsWithReachedTargetValue,
		OpenProjectsWithMissedTargetValue,
		FinishedProjects,
		FinishedProjectsWithSpentBudget,
		FinishedProjectsWithUnspentBudget,
		FinishedProjectsWithReachedTargetValue,
		FinishedProjectsWithMissedTargetValue
	}
}