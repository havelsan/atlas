using System;

namespace AtlasModel.Enterprise
{
    public partial class TTPermission
    {
        public Guid PermissionId { get; set; }
        public Guid SecurityId { get; set; }
        public Guid? SubSecurityId { get; set; }
        public Guid RoleId { get; set; }
        public int RightDefId { get; set; }
        public Guid? PermissionDefId { get; set; }
        public string Parameters { get; set; }
        public short CheckOutStatus { get; set; }
    }
}