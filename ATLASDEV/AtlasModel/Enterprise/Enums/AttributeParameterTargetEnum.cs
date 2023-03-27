using System;

namespace AtlasModel.Enterprise.Enums
{
    [Serializable]
    public enum AttributeParameterTargetEnum : byte
    {
        Object = 0,
        State = 1,
        Transition = 2,
        ObjectAndState = 3,
        ObjectAndTransition = 4
    }
}
