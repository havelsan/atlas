using AtlasModel.Enterprise.Enums;
using System;

namespace AtlasModel.Enterprise
{
    public partial class TTRightDef
    {
        public int RightDefId { get; set; }
        public Guid? PermissionDefId { get; set; }
        public string Name { get; set; }
        public RightDefTargetEnum Target { get; set; }
        public short CheckOutStatus { get; set; }
    }
}