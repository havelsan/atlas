using System;

namespace AtlasModel.Enterprise
{
    public partial class TTAssemblyDef
    {
        public Guid AssemblyDefId { get; set; }
        public string Name { get; set; }
        public int Version { get; set; }
        public string Description { get; set; }
        public DateTime? LastBuildDate { get; set; }
        public string CheckOutId { get; set; }
        public short CheckOutStatus { get; set; }
    }
}