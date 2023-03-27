using AtlasModel.Enterprise.Enums;
using System;

namespace AtlasModel.Enterprise
{
    public partial class TTAttributeDef
    {
        public string AttributeDefId { get; set; }
        public Guid? InterfaceDefId { get; set; }
        public string Body { get; set; }
        public string CheckBody { get; set; }
        public AttributeTargetEnum Target { get; set; }
        public AttributeEventTypeEnum EventType { get; set; }
        public AttributeWhenEnum When { get; set; }
    }
}