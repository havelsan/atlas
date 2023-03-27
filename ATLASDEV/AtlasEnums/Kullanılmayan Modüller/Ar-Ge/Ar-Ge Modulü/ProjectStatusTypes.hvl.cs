namespace TTObjectClasses
{
    public enum ProjectStatusTypes : int
    {
        FinishedAfterAdditionalTime = 0,
        InCreation = 1,
        WaitingPreClaimAppeal = 2,
        PreClaimAppealDenied = 3,
        PreClaimAppealApproved = 4,
        WaitingEticsCommissionAppeal = 5,
        EticsCommissionAppealDenied = 6,
        EticsCommissionAppealApproved = 7,
        WaitingScientificCommissionAppeal = 8,
        ScientificCommissionAppealDenied = 9,
        ScientificCommissionAppealApproved = 10,
        Started = 11,
        WaitingProgressReport = 12,
        ProgressReportAppealDenied = 13,
        ProgressReportAppealApproved = 14,
        Continuing = 15,
        Cancelled = 16,
        Finished = 17,
        Paused = 18,
        TimeExpired = 19
    }
}