using System;

namespace AtlasModel.Enterprise.Enums
{
    [Serializable]
    public enum AttributeEventTypeEnum : byte
    {
        Insert = 0,
        Update = 1,
        Both = 2
    }
}
