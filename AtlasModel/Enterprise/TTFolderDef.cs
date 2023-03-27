using System;

namespace AtlasModel.Enterprise
{
    public partial class TTFolderDef
    {
        public Guid FolderDefId { get; set; }
        public string Name { get; set; }
        public Guid? ParentFolderDefId { get; set; }
        public Guid? PTNodeId { get; set; }
        public short CheckOutStatus { get; set; }
        public string CheckOutId { get; set; }
        public string Description { get; set; }
    }
}