namespace TTObjectClasses
{
    public enum TransactionTypeEnum : int
    {
        Nothing = 0,
        In = 1,
        Out = 2,
        Transfer = 3,
        Consumption = 4,
        Production = 5,
        ChangeStockLevel = 6,
        MergeStock = 7,
        ChangeExpirationDate = 8
    }
}