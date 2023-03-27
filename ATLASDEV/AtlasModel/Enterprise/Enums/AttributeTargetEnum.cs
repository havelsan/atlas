using System;

namespace AtlasModel.Enterprise.Enums
{
    [Serializable]
    public enum AttributeTargetEnum : byte
    {
        Object = 0,
        State = 1,
        Transition = 2
    }
}
