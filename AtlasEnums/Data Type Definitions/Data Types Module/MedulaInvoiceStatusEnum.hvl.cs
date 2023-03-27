namespace TTObjectClasses
{
    public enum MedulaInvoiceStatusEnum : int
    {
        ReadWaiting = 0,
        Read = 1,
        ReadWithError = 2,
        InvoiceEntryWaiting = 3,
        Invoiced = 4,
        InvoiceEntryWithError = 5,
        InvoiceCancelWaiting = 6,
        InvoiceCancelled = 7,
        InvoiceCancelWithError = 8
    }
}