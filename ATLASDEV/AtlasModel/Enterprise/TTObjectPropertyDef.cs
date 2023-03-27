using AtlasModel.Enterprise.Enums;
using System;

namespace AtlasModel.Enterprise
{
    public partial class TTObjectPropertyDef
    {
        public Guid PropertyDefId { get; set; }
        public Guid ObjectDefId { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public Guid DataTypeId { get; set; }
        public PropertyDefaultValueTypeEnum DefaultValueType { get; set; }
        public object DefaultValue { get; set; }
        public bool IsDynamic { get; set; }
        public bool IsRequired { get; set; }
        public bool IsProtected { get; set; }
        public string SetScript { get; set; }
        public short CheckOutStatus { get; set; }
        public short IsIndexed { get; set; }
        public Guid? ShadowOfPropertyDefId { get; set; }
        public bool IsNoLock { get; set; }
        public string Description { get; set; }
        public bool AllowUpdateProtected { get; set; }
    }
}