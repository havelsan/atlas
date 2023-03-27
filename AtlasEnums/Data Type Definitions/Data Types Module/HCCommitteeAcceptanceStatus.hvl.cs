namespace TTObjectClasses
{
    public enum HCCommitteeAcceptanceStatus : int
    {
        Unknown = 0,
        ExaminationsNotCompleted = 1,
        ExaminationsCompletedDecisionNotExists = 2,
        ExaminationsCompletedDecisionExists = 3,
        CommitteeAcceptancePassed = 4
    }
}