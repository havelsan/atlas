using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class Consultation
    {
        public Guid ObjectId { get; set; }
        public Guid? ConsultationResultAndOffers { get; set; }
        public string drAnesteziTescilNo { get; set; }
        public bool? InPatientBed { get; set; }
        public bool? IsPatientApprovalFormGiven { get; set; }
        public Guid? RequestDescription { get; set; }
        public Guid? RequesterDoctorRef { get; set; }
        public Guid? RequesterResourceRef { get; set; }
        public Guid? PhysicianApplicationRef { get; set; }

        #region Base Object Navigation Property
        public virtual PhysicianApplication PhysicianApplication { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResUser RequesterDoctor { get; set; }
        public virtual ResSection RequesterResource { get; set; }
        public virtual PhysicianApplication PhysicianApplicationConsultations { get; set; }
        #endregion Parent Relations
    }
}