using System;

namespace AtlasModel.Enterprise
{
    public partial class TTQueryParameterDef
    {
        public Guid ParameterDefId { get; set; }
        public Guid QueryDefId { get; set; }
        public short OrderNo { get; set; }
        public string Name { get; set; }
        public Guid DataTypeId { get; set; }
        public bool IsArray { get; set; }
        public string SqlTestValue { get; set; }
        public short CheckOutStatus { get; set; }
        public string Description { get; set; }
    }
}