using System;

namespace AtlasModel.Enterprise
{
    public partial class TTPropertyPropagationDef
    {
        public Guid RelationDefId { get; set; }
        public Guid ChildPropertyDefId { get; set; }
        public Guid ParentPropertyDefId { get; set; }
        public short CheckOutStatus { get; set; }
        public Guid? RelationSubtypeDefId { get; set; }
    }
}