namespace TTObjectClasses
{
    public enum ehrAccountTransactionStateEnum : int
    {
        ToBeNew = 0,
        New = 1,
        Invoiced = 2,
        Paid = 3,
        Ready = 4,
        Send = 5,
        Cancelled = 6,
        MedulaDontSend = 7,
        MedulaSentServer = 8,
        MedulaEntrySuccessful = 9,
        MedulaEntryUnsuccessful = 10
    }
}