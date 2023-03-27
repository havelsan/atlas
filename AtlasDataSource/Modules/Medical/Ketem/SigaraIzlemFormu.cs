using System;
using System.Runtime.Serialization;
using TTObjectClasses;
using System.ComponentModel;
using TTInstanceManagement;
using TTStorageManager.Security;
using ReportClasses.ReportUtils;

namespace AtlasDataSource.Controllers
{
    public class SigaraIzlemFormu
    {
        public static SigaraIzlemFormuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<SigaraIzlemFormuData>(parameters, "GetSigaraIzlemFormuData");
        }
        public static SigaraIzlemFormuData GetSigaraIzlemFormuData(string parameters)
        {
            SigaraIzlemFormuData data = new SigaraIzlemFormuData();
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<SigaraIzlemFormParameters>(parameters.ToString());
                using (var objectContext = new TTObjectContext(true))
                {
                    CigaretteExamination cigaretteExamination = objectContext.GetObject<CigaretteExamination>(param.ObjectID);
                    SubEpisode subEpisode = cigaretteExamination.SubEpisode;
                    Patient patient = subEpisode.Episode.Patient;

                    data.HastahaneAdi = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    data.TCKimlikNo = patient.UniqueRefNo == null ? "" : patient.UniqueRefNo.ToString();
                    data.AdSoyad = patient.Name + " " + patient.Surname;
                    data.BabaAdi = patient.FatherName == null ? "" : patient.FatherName.ToString();
                    data.DogumYeri = patient.CityOfBirth == null ? "" : patient.CityOfBirth.ToString();
                    data.DogumTarihi = patient.BirthDate;
                    data.KabulNo = subEpisode.ProtocolNo;
                    data.KontrolSekli = cigaretteExamination.ControlType == null ? "" : Common.GetDisplayTextOfEnumValue("ControlTypeEnum", Convert.ToInt32(cigaretteExamination.ControlType.Value));
                    data.EgitimAldiMi = cigaretteExamination.GetTraining == null ? "" : Common.GetDisplayTextOfEnumValue("YesNoEnum", Convert.ToInt32(cigaretteExamination.GetTraining.Value));
                    data.KacinciKontrol = cigaretteExamination.ControlNumber == null ? "" : cigaretteExamination.ControlNumber.ToString();
                    data.BirakmaTarihi = cigaretteExamination.QuitDate;
                    data.SigaraIctiMi = cigaretteExamination.DidSheHeSmoke == null ? "" : Common.GetDisplayTextOfEnumValue("YesNoEnum", Convert.ToInt32(cigaretteExamination.DidSheHeSmoke.Value));
                    data.KacTaneIcti = cigaretteExamination.SmokingAmount == null ? "" : cigaretteExamination.SmokingAmount.ToString();
                    data.NedenIcti = cigaretteExamination.SmokingReason == null ? "" : cigaretteExamination.SmokingReason.ToString();
                    data.SigarayiBirakmaYontemi = cigaretteExamination.QuitSmokingMethod == null ? "" : Common.GetDisplayTextOfEnumValue("QuitSmokingMethodEnum", Convert.ToInt32(cigaretteExamination.QuitSmokingMethod.Value));
                    data.KontrolCO = cigaretteExamination.ControlCO == null ? "" : cigaretteExamination.ControlCO.ToString();
                    data.KontrolCOHb = cigaretteExamination.ControlCOHb == null ? "" : cigaretteExamination.ControlCOHb.ToString();
                    data.FizikiMuayene = cigaretteExamination.PhysicalExamination == null ? "" : Common.GetDisplayTextOfEnumValue("PhysicalExaminationEnum", Convert.ToInt32(cigaretteExamination.PhysicalExamination.Value));
                    data.IlacKullanimSuresi = cigaretteExamination.MedicationRange == null ? "" : cigaretteExamination.MedicationRange.ToString();
                    data.IlacKullanimSuresi += " " + cigaretteExamination.MedicineRangeType == null ? "" : Common.GetDisplayTextOfEnumValue("PeriodUnitTypeEnum", Convert.ToInt32(cigaretteExamination.MedicineRangeType.Value));
                    data.TedaviAliyorMu = cigaretteExamination.Treatment == null ? "" : Common.GetDisplayTextOfEnumValue("YesNoEnum", Convert.ToInt32(cigaretteExamination.Treatment.Value));
                    data.EkSikayet = cigaretteExamination.AdditionalComplaint == null ? "" : cigaretteExamination.AdditionalComplaint.ToString();
                    data.Sinirlilik = cigaretteExamination.Irritability == null ? false : Convert.ToBoolean(cigaretteExamination.Irritability);
                    data.KonsantrasyonBozuklugu = cigaretteExamination.LossOfConcentration == null ? false : Convert.ToBoolean(cigaretteExamination.LossOfConcentration);
                    data.YuzBastaUyusma = cigaretteExamination.HeadAndFacialNumbness == null ? false : Convert.ToBoolean(cigaretteExamination.HeadAndFacialNumbness);
                    data.UykuBozuklugu = cigaretteExamination.SleepingDisorder == null ? false : Convert.ToBoolean(cigaretteExamination.SleepingDisorder);
                    data.Dengesizlik = cigaretteExamination.Imbalance == null ? false : Convert.ToBoolean(cigaretteExamination.Imbalance);
                    data.AsiriSigaraIcme = cigaretteExamination.ExcessiveSmoking == null ? false : Convert.ToBoolean(cigaretteExamination.ExcessiveSmoking);
                    data.Kabiz = cigaretteExamination.Constipation == null ? false : Convert.ToBoolean(cigaretteExamination.Constipation);
                    data.BasAgrisi = cigaretteExamination.HeadacheAndDizziness == null ? false : Convert.ToBoolean(cigaretteExamination.HeadacheAndDizziness);
                    data.IstahArtmasi = cigaretteExamination.IncreasedAppetite == null ? false : Convert.ToBoolean(cigaretteExamination.IncreasedAppetite);
                    data.AgizYaralari = cigaretteExamination.MouthSore == null ? false : Convert.ToBoolean(cigaretteExamination.MouthSore);
                    data.ZorlukYok = cigaretteExamination.NoDifficulty == null ? false : Convert.ToBoolean(cigaretteExamination.NoDifficulty);
                    data.Diger = cigaretteExamination.Other == null ? false : Convert.ToBoolean(cigaretteExamination.Other);
                    data.DigerText = cigaretteExamination.Challenges == null ? "" : cigaretteExamination.Challenges.ToString();

                }
            }
            return data;
        }
    }

    [Serializable]
    public class SigaraIzlemFormParameters
    {
        [DataMember]
        public Guid ObjectID { get; set; } //CigaretteExamination'in ObjectIDsi

    }
    [Serializable]
    public class SigaraIzlemFormuData
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
        public string KontrolSekli { get; set; }
        [DataMember]
        public string EgitimAldiMi { get; set; }
        [DataMember]
        public string KacinciKontrol { get; set; }
        [DataMember]
        public DateTime? BirakmaTarihi { get; set; }
        [DataMember]
        public string SigaraIctiMi { get; set; }
        [DataMember]
        public string KacTaneIcti { get; set; }
        [DataMember]
        public string NedenIcti { get; set; }
        [DataMember]
        public string SigarayiBirakmaYontemi { get; set; }
        [DataMember]
        public string KontrolCO { get; set; }
        [DataMember]
        public string KontrolCOHb { get; set; }
        [DataMember]
        public string FizikiMuayene { get; set; }
        [DataMember]
        public string IlacKullanimSuresi { get; set; }
        [DataMember]
        public string TedaviAliyorMu { get; set; }
        [DataMember]
        public string EkSikayet { get; set; }
        [DataMember]
        public bool Sinirlilik { get; set; }
        [DataMember]
        public bool KonsantrasyonBozuklugu { get; set; }
        [DataMember]
        public bool YuzBastaUyusma { get; set; }
        [DataMember]
        public bool UykuBozuklugu { get; set; }
        [DataMember]
        public bool Dengesizlik { get; set; }
        [DataMember]
        public bool AsiriSigaraIcme { get; set; }
        [DataMember]
        public bool Kabiz { get; set; }
        [DataMember]
        public bool BasAgrisi { get; set; }
        [DataMember]
        public bool IstahArtmasi { get; set; }
        [DataMember]
        public bool AgizYaralari { get; set; }
        [DataMember]
        public bool ZorlukYok { get; set; }
        [DataMember]
        public bool Diger { get; set; }
        [DataMember]
        public string DigerText { get; set; }
        #endregion
    }

}
