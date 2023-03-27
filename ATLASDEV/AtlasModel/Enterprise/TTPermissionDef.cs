using System;

namespace AtlasModel.Enterprise
{
    public partial class TTPermissionDef
    {
        public Guid PermissionDefId { get; set; }
        public Guid? BasePermissionDefId { get; set; }
        public string Name { get; set; }
        public Guid? InterfaceDefId { get; set; }
        public string Body { get; set; }
        public Guid ModuleDefId { get; set; }
        public string CheckOutId { get; set; }
        public short CheckOutStatus { get; set; }
    }
}