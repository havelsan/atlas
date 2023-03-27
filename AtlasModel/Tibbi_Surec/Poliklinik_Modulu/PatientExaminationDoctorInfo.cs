using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PatientExaminationDoctorInfo
    {
        public Guid ObjectId { get; set; }
        public DateTime? ExaminationDate { get; set; }
        public bool? ExaminationFlag { get; set; }
        public bool? IsSMSsendForDoctor { get; set; }
        public bool? IsSMSsendForChief { get; set; }
        public bool? IsSMSsendForResponsible { get; set; }
        public bool? IsActiveFlag { get; set; }
        public Guid? ResUserRef { get; set; }
        public Guid? PatientExaminationRef { get; set; }

        #region Parent Relations
        public virtual ResUser ResUser { get; set; }
        public virtual PatientExamination PatientExamination { get; set; }
        #endregion Parent Relations
    }
}