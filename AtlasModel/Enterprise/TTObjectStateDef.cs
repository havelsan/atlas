using AtlasModel.Enterprise.Enums;
using System;

namespace AtlasModel.Enterprise
{
    public partial class TTObjectStateDef
    {
        public Guid StateDefId { get; set; }
        public Guid ObjectDefId { get; set; }
        public string Name { get; set; }
        public string DisplayText { get; set; }
        public Guid? BaseStateDefId { get; set; }
        public Guid? FormDefId { get; set; }
        public bool IsEntry { get; set; }
        public bool IsProtected { get; set; }
        public StateStatusEnum Status { get; set; }
        public short CheckOutStatus { get; set; }
        public string Description { get; set; }
        public bool Disabled { get; set; }
    }
}