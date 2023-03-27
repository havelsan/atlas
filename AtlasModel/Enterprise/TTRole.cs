using AtlasModel.Enterprise.Enums;
using System;

namespace AtlasModel.Enterprise
{
    public partial class TTRole
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public RoleSubTypeEnum SubType { get; set; }
        public Guid ModuleDefId { get; set; }
        public string CheckOutId { get; set; }
        public short CheckOutStatus { get; set; }
    }
}