using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DispatchToOtherHospital
    {
        public Guid ObjectId { get; set; }
        public int? MedulaSiteCode { get; set; }
        public string DispatcherDoctorName { get; set; }
        public string DispatcherDoctorEmploymentID { get; set; }
        public string DispatchedDoctorName { get; set; }
        public string DispatchedDoctorEmploymentID { get; set; }
        public string DispatcherDoctorDiplomaRegNo { get; set; }
        public string DispatchedDoctorDiplomaRegNo { get; set; }
        public string ReasonOfDispatch { get; set; }
        public string CompanionReason { get; set; }
        public string DispatchVehicle { get; set; }
        public string SourceObjectID { get; set; }
        public string TargetObjectID { get; set; }
        public bool? MedulaRefakatciDurumu { get; set; }
        public long? MutatDisiAracRaporId { get; set; }
        public DateTime? MutatDisiAracRaporTarihi { get; set; }
        public DateTime? MutatDisiAracBitisTarihi { get; set; }
        public DateTime? MutatDisiAracBaslangicTarihi { get; set; }
        public string MutatDisiGerekcesi { get; set; }
        public string MedulaSevkTakipNo { get; set; }
        public string MessageID { get; set; }
        public string Description { get; set; }
        public Guid? TargetEpisodeObjectID { get; set; }
        public string GSSOwnerName { get; set; }
        public DateTime? RestingStartDate { get; set; }
        public string CompanionStatus { get; set; }
        public DateTime? RestingEndDate { get; set; }
        public long? MutatDisiAracXXXXXXRaporID { get; set; }
        public long? GSSOwnerUniquerefNo { get; set; }
        public bool? EpicrisisDelivered { get; set; }
        public bool? NeedSpecialEquipment { get; set; }
        public IlSınırBilgisi? IlSinir { get; set; }
        public Guid? DispatcherDoctorRef { get; set; }
        public Guid? RequestedSiteRef { get; set; }
        public Guid? DispatchedSpecialityRef { get; set; }
        public Guid? DispatchedDoctorRef { get; set; }
        public Guid? RequestedReferableResourceRef { get; set; }
        public Guid? RequestedReferableHospitalRef { get; set; }
        public Guid? RequestedExternalHospitalRef { get; set; }
        public Guid? RequestedExternalDepartmentRef { get; set; }
        public Guid? RequesterHospitalRef { get; set; }
        public Guid? RequesterSiteRef { get; set; }
        public Guid? SevkVasitasiRef { get; set; }
        public Guid? SevkNedeniRef { get; set; }
        public Guid? SevkTedaviTipiRef { get; set; }
        public Guid? DispatchCityRef { get; set; }

        #region Base Object Navigation Property
        public virtual EpisodeActionWithDiagnosis EpisodeActionWithDiagnosis { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual ResUser DispatcherDoctor { get; set; }
        public virtual ResUser DispatchedDoctor { get; set; }
        public virtual ReferableResource RequestedReferableResource { get; set; }
        public virtual ExternalHospitalDefinition RequestedExternalHospital { get; set; }
        #endregion Parent Relations
    }
}