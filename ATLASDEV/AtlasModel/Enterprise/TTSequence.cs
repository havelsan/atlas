using System;

namespace AtlasModel.Enterprise
{
    public partial class TTSequence
    {
        public Guid DataTypeId { get; set; }
        public string GroupName { get; set; }
        public int? Year { get; set; }
        public long Seed { get; set; }
        public string DbSequenceName { get; set; }
    }
}