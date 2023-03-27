using System;

namespace AtlasModel.Enterprise
{
    public partial class TTObjectRelationSubtypeDef
    {
        public Guid RelationSubtypeDefID { get; set; }
        public Guid RelationDefID { get; set; }
        public Guid ParentObjectDefID { get; set; }
        public Guid ChildObjectDefID { get; set; }
        public string ParentName { get; set; }
        public string ChildrenName { get; set; }
        public short CheckOutStatus { get; set; }
    }
}