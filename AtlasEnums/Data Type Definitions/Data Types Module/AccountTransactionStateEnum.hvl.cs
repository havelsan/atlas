namespace TTObjectClasses
{
    public enum AccountTransactionStateEnum : int
    {
        New = 0,
        Paid = 1,
        Cancelled = 2,
        Send = 3,
        ToBeNew = 4,
        Invoiced = 5,
        Ready = 6
    }
}