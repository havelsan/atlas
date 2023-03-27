using AtlasModel.Enterprise.Enums;
using System;

namespace AtlasModel.Enterprise
{
    public partial class TTAttributeParameterDef
    {
        public Guid ParameterDefId { get; set; }
        public Guid AttributeDefId { get; set; }
        public string Name { get; set; }
        public Guid? DataTypeId { get; set; }
        public Guid? ObjectDefId { get; set; }
        public AttributeParameterTargetEnum Target { get; set; }
        public bool IsRequired { get; set; }
        public short CheckOutStatus { get; set; }
        public string Description { get; set; }
    }
}