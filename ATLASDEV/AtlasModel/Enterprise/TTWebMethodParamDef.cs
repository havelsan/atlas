using System;

namespace AtlasModel.Enterprise
{
    public partial class TTWebMethodParamDef
    {
        public string WebMethodParamDefId { get; set; }
        public Guid WebMethodDefId { get; set; }
        public string ParameterName { get; set; }
        public string ParameterType { get; set; }
        public short OrderNo { get; set; }
        public short CheckOutStatus { get; set; }
    }
}