namespace TTObjectClasses
{
    public enum InvoiceCollectionStateEnum : int
    {
        Cancelled = 0,
        Closed = 1,
        Delivered = 2,
        Locked = 3,
        Open = 4,
        Send = 5,
        PartialPaid = 6,
        Paid = 7
    }
}