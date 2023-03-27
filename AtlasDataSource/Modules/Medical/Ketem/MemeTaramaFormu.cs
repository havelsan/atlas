using System;
using System.Runtime.Serialization;
using TTObjectClasses;
using System.ComponentModel;
using TTInstanceManagement;
using TTStorageManager.Security;
using ReportClasses.ReportUtils;

namespace AtlasDataSource.Controllers
{
    public class MemeTaramaFormu
    {
        public static MemeTaramaFormuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<MemeTaramaFormuData>(parameters, "GetMemeTaramaFormuData");
        }
        public static MemeTaramaFormuData GetMemeTaramaFormuData(string parameters)
        {
            MemeTaramaFormuData data = new MemeTaramaFormuData();

            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<MemeTaramaFormParameters>(parameters.ToString());
                using (var objectContext = new TTObjectContext(true))
                {
                    BreastScreening breastScreening = objectContext.GetObject<BreastScreening>(param.ObjectID);
                    SubEpisode subEpisode = breastScreening.SubEpisode;
                    Patient patient = subEpisode.Episode.Patient;

                    data.HastahaneAdi = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    data.TCKimlikNo = patient.UniqueRefNo == null ? "": patient.UniqueRefNo.ToString();
                    data.AdSoyad = patient.Name + " " + patient.Surname;
                    data.BabaAdi = patient.FatherName == null ? "" : patient.FatherName.ToString();
                    data.DogumYeri = patient.CityOfBirth == null ? "" : patient.CityOfBirth.ToString();
                    data.DogumTarihi = patient.BirthDate;
                    data.KabulNo = subEpisode.ProtocolNo;
                    data.MedeniDurum = patient.SKRSMaritalStatus == null ? "" : patient.SKRSMaritalStatus.ADI;
                    data.KullanilanAilePlanlamasiYontemi = breastScreening.AilePlanlamasiAPYontemi == null ? "" : breastScreening.AilePlanlamasiAPYontemi.ADI;
                    data.MensturelSiklus = breastScreening.MenstrualCycle == null ? "" : breastScreening.MenstrualCycle;
                    data.IlkGebelikYasi = breastScreening.FirstGestationalAge == null ? "" : breastScreening.FirstGestationalAge.ToString();
                    data.MenarsYasi = breastScreening.MenarcheAge == null ? "" : breastScreening.MenarcheAge.ToString();
                    data.GebelikSayisi = breastScreening.GestationalNumber == null ? "" : breastScreening.GestationalNumber.ToString();
                    data.MenapozYasi = breastScreening.MenopauseAge == null ? "" : breastScreening.MenopauseAge.ToString();
                    data.CanliDogumSayisi = breastScreening.LiveBirthNumber == null ? "" : breastScreening.LiveBirthNumber.ToString();
                    data.SonAdetTarihi = breastScreening.LastMenstruationDate;
                    data.IlkEvlilikYasi = breastScreening.FirstMarriageAge == null ? "" : breastScreening.FirstMarriageAge.ToString();
                    if(breastScreening.AnamnesisInfo != null)
                    {
                        data.SigaraKullanimi = breastScreening.AnamnesisInfo.SKRSSigaraKullanimi == null ? "" : breastScreening.AnamnesisInfo.SKRSSigaraKullanimi.ADI;
                        data.MaddeKullanimi = breastScreening.AnamnesisInfo.SKRSMaddeKullanimi == null ? "" : breastScreening.AnamnesisInfo.SKRSMaddeKullanimi.ADI;
                        data.AlkolKullanimi = breastScreening.AnamnesisInfo.SKRSAlkolKullanimi == null ? "" : breastScreening.AnamnesisInfo.SKRSAlkolKullanimi.ADI;

                    }
                    data.OgrenimDurumu = patient.EducationStatus == null ? "" : patient.EducationStatus.ADI;
                    data.IsDurumu = subEpisode.Episode.MedulaSigortaliTuru == null ? "" : subEpisode.Episode.MedulaSigortaliTuru.sigortaliTuruAdi;
                    data.Meslegi = patient.Occupation == null ? "" : patient.Occupation.ADI;
                    data.AiledeMemeCAOykusu = breastScreening.FamilyBreastCA  == null ? "" : Common.GetDisplayTextOfEnumValue("VarYokGarantiEnum", Convert.ToInt32(breastScreening.FamilyBreastCA.Value));
                    data.KisiselMemeCAOykusu = breastScreening.PersonalBreastCA == null ? "" : Common.GetDisplayTextOfEnumValue("PersonalBreastCAEnum", Convert.ToInt32(breastScreening.PersonalBreastCA.Value));
                    data.MastektomiYapilmisMi = breastScreening.Mastectomy == null ? "" : Common.GetDisplayTextOfEnumValue("YesNoEnum", Convert.ToInt32(breastScreening.Mastectomy.Value));
                    data.MastektomiAciklama = breastScreening.MastectomyText == null ? "" : breastScreening.MastectomyText;
                    data.LaktasyonOykusu = breastScreening.Lactation == null ? "" : Common.GetDisplayTextOfEnumValue("VarYokGarantiEnum", Convert.ToInt32(breastScreening.Lactation.Value));
                    data.LaktasyonAciklama = breastScreening.LactationText == null ? "" : breastScreening.LactationText;
                    data.NormalMemeMuayenesiYapildi = breastScreening.BreastExamination == null ? false : Convert.ToBoolean(breastScreening.BreastExamination);
                    data.MaligniteIcinFikirVerici = breastScreening.Malignite == null ? false : Convert.ToBoolean(breastScreening.Malignite);
                    data.BeningBulgularaRastlandi = breastScreening.Bening == null ? false : Convert.ToBoolean(breastScreening.Bening);
                    data.DegerlendimeTamamlandi = breastScreening.AssessmentCompleted == null ? false : Convert.ToBoolean(breastScreening.AssessmentCompleted);
                    data.MuhtemelBening = breastScreening.PossibleBening == null ? false : Convert.ToBoolean(breastScreening.PossibleBening);
                    data.Bilgilendirildi = breastScreening.Informed == null ? false : Convert.ToBoolean(breastScreening.Informed);
                    data.MamografiCekildi = breastScreening.Mammography == null ? false : Convert.ToBoolean(breastScreening.Mammography);
                    data.YetersizSonuc = breastScreening.InsufficientResult == null ? false : Convert.ToBoolean(breastScreening.InsufficientResult);
                    data.BiyopsiOnerisi = breastScreening.BiopsySuggestion == null ? false : Convert.ToBoolean(breastScreening.BiopsySuggestion);
                    data.SupheliAnomali = breastScreening.SuspiciousAnomaly == null ? false : Convert.ToBoolean(breastScreening.SuspiciousAnomaly);
                    data.Aciklama = breastScreening.Description == null ? "" : breastScreening.Description;
                }
            }
            return data;
        }

    }

    [Serializable]
    public class MemeTaramaFormParameters
    {
        [DataMember]
        public Guid ObjectID { get; set; } //BreastScreening'in ObjectIDsi

    }


    [Serializable]
    public class MemeTaramaFormuData
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
        public string KullanilanAilePlanlamasiYontemi { get; set; }
        [DataMember]
        public string MensturelSiklus { get; set; }
        [DataMember]
        public string IlkGebelikYasi { get; set; }
        [DataMember]
        public string MenarsYasi { get; set; }
        [DataMember]
        public string GebelikSayisi { get; set; }
        [DataMember]
        public string MenapozYasi { get; set; }
        [DataMember]
        public string CanliDogumSayisi { get; set; }
        [DataMember]
        public DateTime? SonAdetTarihi { get; set; }
        [DataMember]
        public string IlkEvlilikYasi { get; set; }

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
        public string OgrenimDurumu { get; set; }
        [DataMember]
        public string Meslegi { get; set; }
        [DataMember]
        public string IsDurumu { get; set; }
        #endregion


        #region Kanser ve Laktasyon Öykü Bilgileri
        [DataMember]
        public string AiledeMemeCAOykusu { get; set; }
        [DataMember]
        public string KisiselMemeCAOykusu { get; set; }
        [DataMember]
        public string MastektomiYapilmisMi { get; set; }
        [DataMember]
        public string MastektomiAciklama { get; set; }
        [DataMember]
        public string LaktasyonOykusu { get; set; }
        [DataMember]
        public string LaktasyonAciklama { get; set; }
        #endregion

        #region Sonuç Bilgileri
        [DataMember]
        public bool NormalMemeMuayenesiYapildi { get; set; }
        [DataMember]
        public bool MaligniteIcinFikirVerici { get; set; }
        [DataMember]
        public bool BeningBulgularaRastlandi { get; set; }
        [DataMember]
        public bool DegerlendimeTamamlandi { get; set; }
        [DataMember]
        public bool MuhtemelBening { get; set; }
        [DataMember]
        public bool Bilgilendirildi { get; set; }
        [DataMember]
        public bool MamografiCekildi { get; set; }
        [DataMember]
        public bool YetersizSonuc { get; set; }
        [DataMember]
        public bool BiyopsiOnerisi { get; set; }
        [DataMember]
        public bool SupheliAnomali { get; set; }
        [DataMember]
        public string Aciklama { get; set; }
        #endregion
    }
}
