using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class HospitalsUnitsGrid
    {
        public Guid ObjectId { get; set; }
        public string Explanation { get; set; }
        public bool? Approve { get; set; }
        public bool? Reject { get; set; }
        public string ExaminationState { get; set; }
        public string DisableRatio { get; set; }
        public Guid? DoctorRef { get; set; }
        public Guid? UnitRef { get; set; }
        public Guid? SpecialityRef { get; set; }

        #region Parent Relations
        public virtual ResUser Doctor { get; set; }
        public virtual ResSection Unit { get; set; }
        #endregion Parent Relations
    }
}