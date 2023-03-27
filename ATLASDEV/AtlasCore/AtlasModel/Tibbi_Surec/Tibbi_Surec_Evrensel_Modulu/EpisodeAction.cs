using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class EpisodeAction
    {
        public Guid ObjectId { get; set; }
        public DateTime? RequestDate { get; set; }
        public bool? Emergency { get; set; }
        public bool? PatientPay { get; set; }
        public string OrderObject { get; set; }
        public string DescriptionForWorkList { get; set; }
        public long? AdmissionQueueNumber { get; set; }
        public Guid? SecondaryMasterResourceRef { get; set; }
        public Guid? MasterResourceRef { get; set; }
        public Guid? FromResourceRef { get; set; }
        public Guid? ProcedureSpecialityRef { get; set; }
        public Guid? EpisodeRef { get; set; }
        public Guid? MedulaHastaKabulRef { get; set; }
        public Guid? PatientAdmissionRef { get; set; }
        public Guid? SubEpisodeRef { get; set; }
        public Guid? ProcedureDoctorRef { get; set; }
        public Guid? ProcedureByUserRef { get; set; }

        #region Base Object Navigation Property
        public virtual BaseAction BaseAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResSection SecondaryMasterResource { get; set; }
        public virtual ResSection MasterResource { get; set; }
        public virtual ResSection FromResource { get; set; }
        public virtual Episode Episode { get; set; }
        public virtual PatientAdmission PatientAdmission { get; set; }
        public virtual SubEpisode SubEpisode { get; set; }
        public virtual ResUser ProcedureDoctor { get; set; }
        public virtual ResUser ProcedureByUser { get; set; }
        #endregion Parent Relations

        #region Child Relations
        public virtual ICollection<SubActionProcedure> SubactionProcedures { get; set; }
        public virtual ICollection<VitalSign> VitalSigns { get; set; }
        #endregion Child Relations
    }
}