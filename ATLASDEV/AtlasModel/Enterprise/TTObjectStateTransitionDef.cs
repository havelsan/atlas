using System;

namespace AtlasModel.Enterprise
{
    public partial class TTObjectStateTransitionDef
    {
        public Guid StateTransitionDefId { get; set; }
        public string Name { get; set; }
        public string DisplayText { get; set; }
        public Guid? FromStateDefId { get; set; }
        public Guid ToStateDefId { get; set; }
        public string PreScript { get; set; }
        public string PostScript { get; set; }
        public string UndoScript { get; set; }
        public bool ShouldCallBasePreScript { get; set; }
        public bool ShouldCallBasePostScript { get; set; }
        public bool ShouldCallBaseUndoScript { get; set; }
        public bool ChildShouldCallPreScript { get; set; }
        public bool ChildShouldCallPostScript { get; set; }
        public bool ChildShouldCallUndoScript { get; set; }
        public byte OrderNo { get; set; }
        public short CheckOutStatus { get; set; }
        public string Description { get; set; }
    }
}