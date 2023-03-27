using System;

namespace AtlasModel.Enterprise
{
    public partial class TTModuleDef
    {
        public Guid ModuleDefId { get; set; }
        public string Name { get; set; }
        public Guid FolderDefId { get; set; }
        public int Version { get; set; }
        public Guid? PTNodeId { get; set; }
        public short CheckOutStatus { get; set; }
        public string CheckOutId { get; set; }
        public DateTime? LastBuildDate { get; set; }
        public string Description { get; set; }
        public Guid AssemblyDefId { get; set; }
    }
}