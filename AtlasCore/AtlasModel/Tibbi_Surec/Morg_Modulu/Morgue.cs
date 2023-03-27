using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class Morgue
    {
        public Guid ObjectId { get; set; }
        public Guid? ReasonofReturn { get; set; }
        public string PhoneNumberOfAdmitted { get; set; }
        public bool? CancelledByMasterAction { get; set; }
        public bool? IsOutRequest { get; set; }
        public string MorgueCupboardNo { get; set; }
        public string GraveyardPlotNo { get; set; }
        public long? DiplomaNo { get; set; }
        public int? DeathReportNo { get; set; }
        public DateTime? DateOfSentToGrave { get; set; }
        public string CitizenshipNoOfAdmitted { get; set; }
        public string FoundationToFixDeath { get; set; }
        public string PhoneNumberOfAdmittedFrom { get; set; }
        public string ExternalDoctorFixed { get; set; }
        public DateTime? DateOfDeathReport { get; set; }
        public string AddressOfAdmittedFrom { get; set; }
        public DeathPlaceEnum? DeathPlace { get; set; }
        public string DeathBodyAdmittedFrom { get; set; }
        public string QuarantineCupboardNo { get; set; }
        public long? DeathOrderNo { get; set; }
        public long? ProtocolNo { get; set; }
        public string MaterialsAdmittedTo { get; set; }
        public string AddresOfAdmitted { get; set; }
        public long? OutDeathOrderNo { get; set; }
        public DateTime? DateTimeOfDeath { get; set; }
        public string DeathBodyAdmittedTo { get; set; }
        public string CitizenshipNoOfAdmittedFrom { get; set; }
        public StatisticalDeathReason? StatisticalDeathReason { get; set; }
        public Guid? Report { get; set; }
        public string TombVillage { get; set; }
        public string ObjectsFromPatient { get; set; }
        public string ExternalDoctorFixedUniqueNo { get; set; }
        public bool? InjuryExisting { get; set; }
        public DateTime? InjuryDate { get; set; }
        public Guid? DeathReasonEvaluation { get; set; }
        public Guid? Note { get; set; }
        public bool? SendToMorgue { get; set; }
        public bool? AutopsyToDo { get; set; }
        public bool? PatientCameEx { get; set; }
        public string ExternalSenderDoctorToMorgue { get; set; }
        public string ExternalSenderDoctorMorgueUnR { get; set; }
        public Guid? SKRSDeathPlaceRef { get; set; }
        public Guid? SKRSDeathReasonRef { get; set; }
        public Guid? SKRSInjuryPlaceRef { get; set; }
        public Guid? SenderDoctorRef { get; set; }
        public Guid? ReasonForDeathRef { get; set; }
        public Guid? DoctorFixedRef { get; set; }
        public Guid? CupboardRef { get; set; }
        public Guid? DiedClinicRef { get; set; }
        public Guid? DeliveredByRef { get; set; }
        public Guid? NurseRef { get; set; }
        public Guid? MernisDeathReasonsRef { get; set; }
        public Guid? MaterialsAdmittedFromRef { get; set; }
        public Guid? SKRSTombCityRef { get; set; }
        public Guid? SKRSTombTownRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeAction EpisodeAction { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResUser SenderDoctor { get; set; }
        public virtual ResUser DoctorFixed { get; set; }
        public virtual ResSection DiedClinic { get; set; }
        public virtual ResUser DeliveredBy { get; set; }
        public virtual ResUser Nurse { get; set; }
        public virtual ResUser MaterialsAdmittedFrom { get; set; }
        public virtual SKRSIlceKodlari SKRSTombTown { get; set; }
        #endregion Parent Relations
    }
}