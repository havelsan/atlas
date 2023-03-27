using System;

namespace AtlasModel.Enterprise
{
    public partial class TTObjectState
    {
        public Guid StateDefId { get; set; }
        public Guid ObjectId { get; set; }
        public bool IsUndo { get; set; }
        public long BranchDateTimeTick { get; set; }
        public string Description { get; set; }
        public Guid? UserId { get; set; }
        public DateTime BranchDate { get; set; }
    }
}