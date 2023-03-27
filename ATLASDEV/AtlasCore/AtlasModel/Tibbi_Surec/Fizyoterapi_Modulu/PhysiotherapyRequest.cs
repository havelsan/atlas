using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class PhysiotherapyRequest
    {
        public Guid ObjectId { get; set; }
        public string NoteToPhysiotherapist { get; set; }
        public long? ProtocolNo { get; set; }
        public string DiagnosisGroup { get; set; }
        public bool? InPatientsBed { get; set; }
        public Guid? ClinicInformationRTF { get; set; }
        public string MedulaRaporTakipNo { get; set; }
        public DateTime? ReportEndDate { get; set; }
        public DateTime? ReportStartDate { get; set; }
        public string ReportNo { get; set; }
        public string ClinicInformation { get; set; }
        public DateTime? PhysiotherapyRequestDate { get; set; }
        public DateTime? PhysiotherapyStartDate { get; set; }
        public Guid? SecondProcedureDoctorRef { get; set; }
        public Guid? ThirdProcedureDoctorRef { get; set; }
        public Guid? InpatientBedRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeActionWithDiagnosis EpisodeActionWithDiagnosis { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResUser SecondProcedureDoctor { get; set; }
        public virtual ResUser ThirdProcedureDoctor { get; set; }
        public virtual ResBed InpatientBed { get; set; }
        #endregion Parent Relations
    }
}