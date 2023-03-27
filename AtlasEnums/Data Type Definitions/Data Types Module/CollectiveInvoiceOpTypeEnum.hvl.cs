namespace TTObjectClasses
{
    public enum CollectiveInvoiceOpTypeEnum : int
    {
        GetProvision = 0,
        DeleteProvision = 1,
        SaveProcedure = 2,
        DeleteProcedure = 3,
        RunRule = 4,
        SaveInvoice = 5,
        DeleteInvoice = 6,
        ReadInvoicePrice = 7,
        AddInvoiceCollection = 8,
        RemoveInvoiceCollection = 9,
        AddWatchList = 10,
        RemoveWatchList = 11,
        ChangeTrxCurState = 12,
        Fix1108 = 13,
        Fix1108AndInvoice = 14,
        Fix1108AndReadInvoice = 15,
        ChangeDoctor = 16,
        AddDiagnosis = 17,
        ArrangeInvoice = 18,
        AddDescription = 19,
        SetDonotSendMedula = 20,
        SendNabiz = 21,
        SendNabiz700 = 22,
        AddOperation = 23
    }
}