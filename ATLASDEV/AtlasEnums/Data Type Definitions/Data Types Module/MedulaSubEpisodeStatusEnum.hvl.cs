namespace TTObjectClasses
{
    public enum MedulaSubEpisodeStatusEnum : int
    {
        ProvisionNoNotExists = 0,
        ProcedureEntryNotCompleted = 2,
        ProcedureEntryWithError = 3,
        ProcedureEntryCompleted = 4,
        InvoiceEntryWithError = 6,
        Invoiced = 7,
        InvoiceRead = 9,
        InvoiceReadWithError = 10,
        InsideInvoiceCollection = 11,
        InvoiceInconsistent = 12
    }
}