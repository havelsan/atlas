using System;
using System.Runtime.Serialization;
using TTObjectClasses;
using System.ComponentModel;
using TTInstanceManagement;
using TTStorageManager.Security;
using ReportClasses.ReportUtils;

namespace AtlasDataSource.Controllers
{
    public class SmearTaramaFormu
    {
        public static SmearTaramaFormuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<SmearTaramaFormuData>(parameters, "GetSmearTaramaFormuData");
        }
        public static SmearTaramaFormuData GetSmearTaramaFormuData(string parameters)
        {
            SmearTaramaFormuData data = new SmearTaramaFormuData();
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<SmearTaramaFormParameters>(parameters.ToString());
                using (var objectContext = new TTObjectContext(true))
                {
                    SmearScreening smearScreening = objectContext.GetObject<SmearScreening>(param.ObjectID);
                    SubEpisode subEpisode = smearScreening.SubEpisode;
                    Patient patient = subEpisode.Episode.Patient;

                    data.HastahaneAdi = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    data.TCKimlikNo = patient.UniqueRefNo == null ? "" : patient.UniqueRefNo.ToString();
                    data.AdSoyad = patient.Name + " " + patient.Surname;
                    data.BabaAdi = patient.FatherName == null ? "" : patient.FatherName.ToString();
                    data.DogumYeri = patient.CityOfBirth == null ? "" : patient.CityOfBirth.ToString();
                    data.DogumTarihi = patient.BirthDate;
                    data.KabulNo = subEpisode.ProtocolNo;
                    data.MedeniDurum = patient.SKRSMaritalStatus == null ? "" : patient.SKRSMaritalStatus.ADI;
                    data.AilePlanlamasiYontemi = smearScreening.AilePlanlamasiAPYontemi == null ? "" : smearScreening.AilePlanlamasiAPYontemi.ADI;
                    data.MensturelSiklus = smearScreening.MenstrualCycle == null ? "" : smearScreening.MenstrualCycle.ToString();
                    data.IlkEvlilikYasi = smearScreening.FirstMarriageAge == null ? "" : smearScreening.FirstMarriageAge.ToString();
                    data.CinselIliskideAgri = smearScreening.PainDuringIntercourse == null ? "" : Common.GetDisplayTextOfEnumValue("VarYokGarantiEnum", Convert.ToInt32(smearScreening.PainDuringIntercourse.Value));
                    data.CinselIliskideAgri += " "+ smearScreening.PainDuringIntercourseText == null ? "" : smearScreening.PainDuringIntercourseText.ToString();
                    data.MenarsYasi = smearScreening.MenarcheAge == null ? "" : smearScreening.MenarcheAge.ToString();
                    data.IlkGebelikYasi = smearScreening.FirstGestationalAge == null ? "" : smearScreening.FirstGestationalAge.ToString();
                    data.CanliDogumSayisi = smearScreening.LiveBirthNumber == null ? "" : smearScreening.LiveBirthNumber.ToString();
                    data.CinselIliskiSonrasiKanama = smearScreening.BleedingAfterIntercourse == null ? "" : Common.GetDisplayTextOfEnumValue("VarYokGarantiEnum", Convert.ToInt32(smearScreening.BleedingAfterIntercourse.Value));
                    data.MenapozYasi = smearScreening.MenopauseAge == null ? "" : smearScreening.MenopauseAge.ToString();
                    data.GebelikSayisi = smearScreening.GestationalNumber == null ? "" : smearScreening.GestationalNumber.ToString();
                    data.SonAdetTarihi = smearScreening.LastMenstruationDate;
                    if (smearScreening.AnamnesisInfo != null)
                    {
                        data.SigaraKullanimi = smearScreening.AnamnesisInfo.SKRSSigaraKullanimi == null ? "" : smearScreening.AnamnesisInfo.SKRSSigaraKullanimi.ADI;
                        data.MaddeKullanimi = smearScreening.AnamnesisInfo.SKRSMaddeKullanimi == null ? "" : smearScreening.AnamnesisInfo.SKRSMaddeKullanimi.ADI;
                        data.AlkolKullanimi = smearScreening.AnamnesisInfo.SKRSAlkolKullanimi == null ? "" : smearScreening.AnamnesisInfo.SKRSAlkolKullanimi.ADI;

                    }
                    data.OgrenimDurumu = patient.EducationStatus == null ? "" : patient.EducationStatus.ADI;
                    data.IsDurumu = subEpisode.Episode.MedulaSigortaliTuru == null ? "" : subEpisode.Episode.MedulaSigortaliTuru.sigortaliTuruAdi;
                    data.Meslegi = patient.Occupation == null ? "" : patient.Occupation.ADI;
                    data.AiledeKanserOykusu = smearScreening.FamilyCancerHistory == null ? "" : Common.GetDisplayTextOfEnumValue("VarYokGarantiEnum", Convert.ToInt32(smearScreening.FamilyCancerHistory.Value));
                    data.AiledeKanserOykusuText = smearScreening.FamilyCancerHistoryDesc == null ? "" : smearScreening.FamilyCancerHistoryDesc.ToString();
                    data.KisiselKanserOykusu = smearScreening.PersonalCancerHistory == null ? "" : Common.GetDisplayTextOfEnumValue("VarYokGarantiEnum", Convert.ToInt32(smearScreening.PersonalCancerHistory.Value));
                    data.KisiselKanserOykusuText = smearScreening.PersonalCancerHistoryDesc == null ? "" : smearScreening.PersonalCancerHistoryDesc.ToString();
                    data.JinekolojikKanserOykusu = smearScreening.GynecologicCancerHistory == null ? "" : Common.GetDisplayTextOfEnumValue("VarYokGarantiEnum", Convert.ToInt32(smearScreening.GynecologicCancerHistory.Value));
                    data.JinekolojikKanserOykusuText = smearScreening.GynecologicCancerHistoryDesc == null ? "" : smearScreening.GynecologicCancerHistoryDesc.ToString();
                    data.Sonuc = smearScreening.SmearResult == null ? "" : Common.GetDisplayTextOfEnumValue("SmearResultEnum", Convert.ToInt32(smearScreening.SmearResult.Value));
                    data.HPV = smearScreening.HPVResult == null ? "" : Common.GetDisplayTextOfEnumValue("HPVEnum", Convert.ToInt32(smearScreening.HPVResult.Value));
                    data.Aciklama = smearScreening.Description == null ? "" : smearScreening.Description.ToString();
                }
            }
            return data;
        }
    }

    [Serializable]
    public class SmearTaramaFormParameters
    {
        [DataMember]
        public Guid ObjectID { get; set; } //SmearScreening'in ObjectIDsi

    }
    [Serializable]
    public class SmearTaramaFormuData
    {
        [DataMember]
        public string HastahaneAdi { get; set; }

        #region Hasta Bilgileri
        [DataMember]
        public string TCKimlikNo { get; set; }
        [DataMember]
        public string AdSoyad { get; set; }
        [DataMember]
        public string BabaAdi { get; set; }
        [DataMember]
        public string DogumYeri { get; set; }
        [DataMember]
        public DateTime? DogumTarihi { get; set; }
        [DataMember]
        public string KabulNo { get; set; }

        #endregion


        #region Tarama Bilgileri
        [DataMember]
        public string MedeniDurum { get; set; }
        [DataMember]
        public string AilePlanlamasiYontemi { get; set; }
        [DataMember]
        public string MensturelSiklus { get; set; }
        [DataMember]
        public string IlkEvlilikYasi { get; set; }
        [DataMember]
        public string CinselIliskideAgri { get; set; }
        [DataMember]
        public string MenarsYasi { get; set; }
        [DataMember]
        public string IlkGebelikYasi { get; set; }
        [DataMember]
        public string CanliDogumSayisi { get; set; }
        [DataMember]
        public string CinselIliskiSonrasiKanama { get; set; }
        [DataMember]
        public string MenapozYasi { get; set; }
        [DataMember]
        public string GebelikSayisi { get; set; }
        [DataMember]
        public DateTime? SonAdetTarihi { get; set; }
        #endregion

        #region Anamnez Bilgileri
        [DataMember]
        public string SigaraKullanimi { get; set; }
        [DataMember]
        public string MaddeKullanimi { get; set; }
        [DataMember]
        public string AlkolKullanimi { get; set; }
        #endregion

        #region Öğrenim ve İş Bilgileri
        [DataMember]
        public string IsDurumu { get; set; }
        [DataMember]
        public string OgrenimDurumu { get; set; }
        [DataMember]
        public string Meslegi { get; set; }
        #endregion

        #region Kanser Öyküsü Bilgileri
        [DataMember]
        public string AiledeKanserOykusu { get; set; }
        [DataMember]
        public string AiledeKanserOykusuText { get; set; }
        [DataMember]
        public string KisiselKanserOykusu { get; set; }
        [DataMember]
        public string KisiselKanserOykusuText { get; set; }
        [DataMember]
        public string JinekolojikKanserOykusu { get; set; }
        [DataMember]
        public string JinekolojikKanserOykusuText { get; set; }
        #endregion

        #region Sonuc Bilgileri
        [DataMember]
        public string Sonuc { get; set; }
        [DataMember]
        public string HPV { get; set; }
        [DataMember]
        public string Aciklama { get; set; }
        #endregion

    }
}
