using System;

namespace AtlasModel.Enterprise.Enums
{
    [Serializable]
    public enum RoleSubTypeEnum : byte
    {
        System = 0,
        User = 1,
        Core = 2,
        BuiltIn = 3
    }
}
