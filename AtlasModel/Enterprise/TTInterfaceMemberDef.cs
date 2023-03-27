using System;

namespace AtlasModel.Enterprise
{
    public partial class TTInterfaceMemberDef
    {
        public Guid InterfaceDefId { get; set; }
        public string Name { get; set; }
        public string CodeType { get; set; }
        public bool IsReadOnly { get; set; }
        public short CheckOutStatus { get; set; }
        public string Description { get; set; }
    }
}