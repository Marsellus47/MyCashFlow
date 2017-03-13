namespace MyCashFlow.Web.Infrastructure.ProjectsFilter
{
	public enum ProjectsFilterType
	{
		AllProjects,
		OpenProjects,
		OpenProjectsWithSpentBudget,
		OpenProjectsWithUnspentBudget,
		OpenProjectsWithUnknownBudget,
		OpenProjectsWithReachedTargetValue,
		OpenProjectsWithMissedTargetValue,
		OpenProjectsWithUnknownTargetValue,
		FinishedProjects,
		FinishedProjectsWithSpentBudget,
		FinishedProjectsWithUnspentBudget,
		FinishedProjectsWithUnknownBudget,
		FinishedProjectsWithReachedTargetValue,
		FinishedProjectsWithMissedTargetValue,
		FinishedProjectsWithUnknownTargetValue
	}
}