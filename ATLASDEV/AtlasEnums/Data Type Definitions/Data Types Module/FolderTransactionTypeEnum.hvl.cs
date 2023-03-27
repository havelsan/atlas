namespace TTObjectClasses
{
    public enum FolderTransactionTypeEnum : int
    {
        FileCreated = 0,
        FulfilledFromMR = 1,
        FulfilledFromDepartment = 2,
        SendToDepartment = 3,
        AcknowledgedByDepartment = 4,
        SendToMR = 5,
        AcknowledgedByMR = 6,
        PreMissing = 7,
        NotifyMR = 8,
        Missing = 9,
        Analysed = 10,
        FolderisFetching = 11,
        Cancelled = 12
    }
}