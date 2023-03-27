using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SurgeryRejectReason
    {
        public Guid ObjectId { get; set; }
        public bool? LackOfMaterial { get; set; }
        public bool? PreopPreparation { get; set; }
        public bool? PatientNotCome { get; set; }
        public bool? ProlongSurgery { get; set; }
        public bool? OtherReason { get; set; }
        public string OtherReasonExplanation { get; set; }
    }
}