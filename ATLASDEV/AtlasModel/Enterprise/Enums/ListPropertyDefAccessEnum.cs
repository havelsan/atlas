using System;

namespace AtlasModel.Enterprise.Enums
{
    [Serializable]
    public enum ListPropertyDefAccessEnum : byte
    {
        None = 0,
        Full = 1,
        PartialLeft = 2,
        PartialRight = 4,
        PartialFull = 6
    }
}
