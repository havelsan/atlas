using System;

namespace AtlasModel.Enterprise
{
    public partial class TTPermissionParameterDef
    {
        public Guid ParameterDefId { get; set; }
        public Guid PermissionDefId { get; set; }
        public Guid DataTypeId { get; set; }
        public string Name { get; set; }
        public byte OrderNo { get; set; }
        public short CheckOutStatus { get; set; }
    }
}