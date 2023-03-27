using System;

namespace AtlasModel.Enterprise
{
    public partial class TTBinaryData
    {
        public Guid DataId { get; set; }
        public Guid? ObjectId { get; set; }
        public byte[] Data { get; set; }
        public Guid? PropertyDefId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}