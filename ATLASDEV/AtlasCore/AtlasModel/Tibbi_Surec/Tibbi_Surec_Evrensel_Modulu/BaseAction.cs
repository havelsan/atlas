using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class BaseAction
    {
        public Guid ObjectId { get; set; }
        public DateTime? ActionDate { get; set; }
        public string ReasonOfCancel { get; set; }
        public bool? Active { get; set; }
        public DateTime? WorkListDate { get; set; }
        public Guid? ReasonOfReject { get; set; }
        public long? ID { get; set; }
        public DateTime? OlapLastUpdate { get; set; }
        public DateTime? OlapDate { get; set; }
        public Guid? ClonedObjectID { get; set; }
        public string WorkListDescription { get; set; }
        public bool? IsOldAction { get; set; }
        public Guid? MasterActionRef { get; set; }

        #region Parent Relations
        public virtual BaseAction MasterAction { get; set; }
        #endregion Parent Relations
    }
}