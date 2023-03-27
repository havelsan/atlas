using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class VaccineDetails
    {
        public Guid ObjectId { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public bool? DisMerkezMi { get; set; }
        public string Notes { get; set; }
        public string DisMerkez { get; set; }
        public VaccineStateEnum? VaccineState { get; set; }
        public string AsiAntiSerumuKarekodu { get; set; }
        public string AsiKarekodu { get; set; }
        public string AsiSulandiriciKarekodu { get; set; }
        public DateTime? AsininSonKullanmaTarihi { get; set; }
        public string SorguNumarasi { get; set; }
        public string Barkod { get; set; }
        public string SeriNumarasi { get; set; }
        public string PartiNumarasi { get; set; }
        public string KirilimBilgisi { get; set; }
        public bool? GeziciHizmetMi { get; set; }
        public string BildirimDurumu { get; set; }
        public string SorguSonucu { get; set; }
        public int? VaccinePostponeTime { get; set; }
        public string VaccineName { get; set; }
        public string PeriodName { get; set; }
        public int? PeriodRange { get; set; }
        public PeriodUnitTypeEnum? PeriodUnit { get; set; }
        public string IslemYapan { get; set; }
        public string BilgiAlinanKisiAdiSoyadi { get; set; }
        public string BilgiAlinanKisiTel { get; set; }
        public DateTime? ASIEOrtayaCikisTarihi { get; set; }
        public Guid? PatientRef { get; set; }
        public Guid? ResponsibleDoctorRef { get; set; }
        public Guid? SKRSAsiYapilmamaDurumuRef { get; set; }
        public Guid? SKRSAsiYapilmamaNedeniRef { get; set; }
        public Guid? SKRSASIISLEMTURURef { get; set; }
        public Guid? SKRSKurumlarRef { get; set; }
        public Guid? SKRSAsiKoduRef { get; set; }
        public Guid? VaccineFollowUpRef { get; set; }
        public Guid? SKRSAsininDozuRef { get; set; }
        public Guid? SKRSAsininUygulamaSekliRef { get; set; }
        public Guid? SKRSAsininSaglandigiKaynakRef { get; set; }
        public Guid? SKRSAsiUygulamaYeriRef { get; set; }
        public Guid? ResponsibleNurseRef { get; set; }
        public Guid? SKRSAsiOzelDurumNedeniRef { get; set; }

        #region Parent Relations
        public virtual Patient Patient { get; set; }
        public virtual ResUser ResponsibleDoctor { get; set; }
        public virtual SKRSKurumlar SKRSKurumlar { get; set; }
        public virtual SKRSAsiKodu SKRSAsiKodu { get; set; }
        public virtual VaccineFollowUp VaccineFollowUp { get; set; }
        public virtual ResUser ResponsibleNurse { get; set; }
        #endregion Parent Relations
    }
}