using System;

namespace AtlasModel.Enterprise
{
    public partial class TTFormFieldEventDef
    {
        public Guid EventDefId { get; set; }
        public Guid FieldDefId { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public short CheckOutStatus { get; set; }
    }
}