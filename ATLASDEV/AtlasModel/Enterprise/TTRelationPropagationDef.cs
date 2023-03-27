using System;

namespace AtlasModel.Enterprise
{
    public partial class TTRelationPropagationDef
    {
        public Guid RelationDefId { get; set; }
        public Guid ChildRelationDefId { get; set; }
        public Guid ParentRelationDefId { get; set; }
        public short CheckOutStatus { get; set; }
    }
}