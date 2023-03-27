using System;

namespace AtlasModel.Enterprise.Enums
{
    [Serializable]
    public enum TTWebMethodAuthenticationTypeEnum : byte
    {
        PerUser = 0,
        PerSite = 1,
        ByParameter = 2
    }
}
