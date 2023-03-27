using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SendToDoctorPerformance
    {
        public Guid ObjectId { get; set; }
        public DPStatus? Status { get; set; }
        public DateTime? RecordDate { get; set; }
        public DPInternalObjectStatus? InternalObjectStatus { get; set; }
        public Guid? InternalObjectID { get; set; }
        public string InternalObjectDefName { get; set; }
    }
}