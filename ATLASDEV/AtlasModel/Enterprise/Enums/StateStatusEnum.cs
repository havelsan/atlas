using System;

namespace AtlasModel.Enterprise.Enums
{
    [Serializable]
    public enum StateStatusEnum : byte
    {
        Uncompleted = 0,
        CompletedSuccessfully = 1,
        CompletedUnsuccessfully = 2,
        Cancelled = 4
    }
}
