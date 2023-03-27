using System;

namespace AtlasModel.Enterprise.Enums
{
    [Serializable]
    public enum TTWebMethodResourceParameterEnum : byte
    {
        None = 0,
        ByParameter = 1,
        UserOutPatientResource = 2,
        UserInPatientResource = 3,
        UserSecMasterResource = 4
    }
}
