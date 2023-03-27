using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class MemberOfHealthCommiittee
    {
        public Guid ObjectId { get; set; }
        public MemberOfHCTypeEnum? HealthCommitteeType { get; set; }
        public bool? Approve { get; set; }
        public bool? Reject { get; set; }
        public string Description { get; set; }
        public Guid? HealthCommitteeRef { get; set; }
        public Guid? MemberDoctorRef { get; set; }
        public Guid? SpecialityRef { get; set; }

        #region Parent Relations
        public virtual HealthCommittee HealthCommittee { get; set; }
        public virtual ResUser MemberDoctor { get; set; }
        #endregion Parent Relations
    }
}