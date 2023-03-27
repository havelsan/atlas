using System;

namespace AtlasModel.Enterprise
{
    public partial class TTRemoteMethodParamDef
    {
        public string RemoteMethodParamDefId { get; set; }
        public Guid RemoteMethodDefId { get; set; }
        public string ParameterName { get; set; }
        public string ParameterType { get; set; }
        public short OrderNo { get; set; }
        public short CheckOutStatus { get; set; }
    }
}