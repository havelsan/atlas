namespace AtlasModel.Enterprise.Enums
{
    public enum UserStatusEnum : int
    {
        Disabled = -1,
        PowerUser = 1,
        SuperUser = 2,
        SystemAccount = 3,
        Cancelled = -99,
        Normal = 0
    }
}
