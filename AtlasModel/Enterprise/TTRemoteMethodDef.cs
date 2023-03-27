using AtlasModel.Enterprise.Enums;
using System;

namespace AtlasModel.Enterprise
{
    public partial class TTRemoteMethodDef
    {
        public Guid RemoteMethodDefId { get; set; }
        public string Name { get; set; }
        public string ReturnType { get; set; }
        public string Body { get; set; }
        public short CheckOutStatus { get; set; }
        public RemoteMethodCallModeEnum CallMode { get; set; }
        public TTMessagePriorityEnum Priority { get; set; }
        public Guid ObjectDefId { get; set; }
        public string Description { get; set; }
        public string DisplayText { get; set; }
        public string CallbackBody { get; set; }
    }
}