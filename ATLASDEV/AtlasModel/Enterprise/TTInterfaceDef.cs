using System;

namespace AtlasModel.Enterprise
{
    public partial class TTInterfaceDef
    {
        public Guid InterfaceDefId { get; set; }
        public string Name { get; set; }
        public string Methods { get; set; }
        public Guid? BaseInterfaceDefId { get; set; }
        public Guid ModuleDefId { get; set; }
        public bool IsBuiltIn { get; set; }
        public string CheckOutId { get; set; }
        public short CheckOutStatus { get; set; }
        public string Description { get; set; }
    }
}