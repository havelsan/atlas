using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PatientAdmissionCount
    {
        public Guid ObjectId { get; set; }
        public int? Counter { get; set; }
        public DateTime? PatientAdmissionDate { get; set; }
        public Guid? PoliclinicRef { get; set; }
        public Guid? DoctorRef { get; set; }

        #region Parent Relations
        public virtual ResPoliclinic Policlinic { get; set; }
        public virtual ResUser Doctor { get; set; }
        #endregion Parent Relations
    }
}