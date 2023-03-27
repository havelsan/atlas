using System;

namespace AtlasModel.Enterprise
{
    public partial class TTObjectCodedPropertyDef
    {
        public Guid CodedPropertyDefId { get; set; }
        public Guid ObjectDefId { get; set; }
        public string Name { get; set; }
        public Guid DataTypeId { get; set; }
        public string GetScript { get; set; }
        public string SetScript { get; set; }
        public short CheckOutStatus { get; set; }
        public string Description { get; set; }
    }
}