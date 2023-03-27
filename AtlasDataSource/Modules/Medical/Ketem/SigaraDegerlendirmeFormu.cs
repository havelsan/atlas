using System;
using System.Runtime.Serialization;
using TTObjectClasses;
using System.ComponentModel;
using TTInstanceManagement;
using TTStorageManager.Security;
using ReportClasses.ReportUtils;

namespace AtlasDataSource.Controllers
{
    public class SigaraDegerlendirmeFormu
    {
        public static SigaraDegerlendirmeFormuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<SigaraDegerlendirmeFormuData>(parameters, "GetSigaraDegerlendirmeFormuData");
        }
        public static SigaraDegerlendirmeFormuData GetSigaraDegerlendirmeFormuData(string parameters)
        {
            SigaraDegerlendirmeFormuData data = new SigaraDegerlendirmeFormuData();
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<SigaraDegerlendirmeFormParameters>(parameters.ToString());
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
                    data.SigaraBaslamaYasi = cigaretteExamination.SmokingStartAge == null ? "" : cigaretteExamination.SmokingStartAge.ToString();
                    data.YildaIcilenSigaraMiktari = cigaretteExamination.SmokingYearRate == null ? "" : cigaretteExamination.SmokingYearRate.ToString();
                    data.SigaraBaslamaNedeni = cigaretteExamination.StartSmokingReason == null ? "" : Common.GetDisplayTextOfEnumValue("SmokingStartReasonEnum", Convert.ToInt32(cigaretteExamination.StartSmokingReason.Value));
                    data.SigaraBirakmaIstekNedeni = cigaretteExamination.QuitSmokingReason == null ? "" : Common.GetDisplayTextOfEnumValue("QuitSmokingMethodEnum", Convert.ToInt32(cigaretteExamination.QuitSmokingReason.Value));
                    data.SigaraMiktarindakiDegisim = cigaretteExamination.SmokingAmountChange == null ? "" : Common.GetDisplayTextOfEnumValue("SmokingAmountChangeEnum", Convert.ToInt32(cigaretteExamination.SmokingAmountChange.Value));
                    data.SigaraTipi = cigaretteExamination.CigaretteType == null ? "" : Common.GetDisplayTextOfEnumValue("CigaretteTypeEnum", Convert.ToInt32(cigaretteExamination.CigaretteType.Value));
                    data.GundeIcilenSigaraMiktari = cigaretteExamination.DailyCigaretteAmount == null ? "" : cigaretteExamination.DailyCigaretteAmount.ToString();
                    data.SigarayiBirakmayiDusundunuzMu = cigaretteExamination.ThinkingOfQuitSmoking == null ? "" : Common.GetDisplayTextOfEnumValue("YesNoEnum", Convert.ToInt32(cigaretteExamination.ThinkingOfQuitSmoking.Value));
                    data.SigaraBirakmayiDenedinizMi = cigaretteExamination.TryingQuitSmoking == null ? "" : Common.GetDisplayTextOfEnumValue("YesNoEnum", Convert.ToInt32(cigaretteExamination.TryingQuitSmoking.Value));
                    data.SigaraBirakmayiDenedinizMi += " " + cigaretteExamination.TryingQuitSmokingAmount == null ? "" : cigaretteExamination.TryingQuitSmokingAmount.ToString();
                    data.SigaraBirakmaYontemi = cigaretteExamination.QuitSmokingMethod == null ? "" : Common.GetDisplayTextOfEnumValue("QuitSmokingMethodEnum", Convert.ToInt32(cigaretteExamination.QuitSmokingMethod.Value));
                    data.SigaraİcmeİstegiArtNedenler = cigaretteExamination.IncreaseSmokingReasons == null ? "" : Common.GetDisplayTextOfEnumValue("IncreaseSmokingReasonEnum", Convert.ToInt32(cigaretteExamination.IncreaseSmokingReasons.Value));
                    data.IsYerindeIcilenSigara = cigaretteExamination.SmokingAtWorkPlaceAmount == null ? "" : cigaretteExamination.SmokingAtWorkPlaceAmount.ToString();
                    data.IsYerindeIcilenSigara += " " + cigaretteExamination.SmokingAtWorkPlaceAmountType == null ? "" : Common.GetDisplayTextOfEnumValue("CigaretteAmountTypeEnum", Convert.ToInt32(cigaretteExamination.SmokingAtWorkPlaceAmountType.Value));
                    data.BosZamanlar = cigaretteExamination.FreeTime == null ? "" : cigaretteExamination.FreeTime.ToString();
                    data.DevamliKullanilanMadde = cigaretteExamination.UsedAddictiveDrugs == null ? "" : Common.GetDisplayTextOfEnumValue("YesNoEnum", Convert.ToInt32(cigaretteExamination.UsedAddictiveDrugs.Value));
                    data.IlkSigaraIcmeZamani = cigaretteExamination.FirstSmokeAfterWakeUp == null ? "" : cigaretteExamination.FirstSmokeAfterWakeUp.ToString();
                    data.IlkSigaraIcmeZamani += " " + cigaretteExamination.FirstsmokeAfterWakeUpType == null ? "" : Common.GetDisplayTextOfEnumValue("MinuteHourEnum", Convert.ToInt32(cigaretteExamination.FirstsmokeAfterWakeUpType.Value));
                    data.SigaraYasagi = cigaretteExamination.PlacesThatBanSmoking == null ? "" : Common.GetDisplayTextOfEnumValue("YesNoEnum", Convert.ToInt32(cigaretteExamination.PlacesThatBanSmoking.Value));
                    data.VazgecmekİstenilenZaman = cigaretteExamination.GiveUpTime == null ? "" : Common.GetDisplayTextOfEnumValue("GiveUpTimeEnum", Convert.ToInt32(cigaretteExamination.GiveUpTime.Value));
                    data.AgirHasta = cigaretteExamination.ContinueSmoking == null ? "" : Common.GetDisplayTextOfEnumValue("YesNoEnum", Convert.ToInt32(cigaretteExamination.ContinueSmoking.Value));
                    data.EvdeBaskaIcen = cigaretteExamination.OtherSmokersAtHome == null ? "" : Common.GetDisplayTextOfEnumValue("YesNoEnum", Convert.ToInt32(cigaretteExamination.OtherSmokersAtHome.Value));
                    data.IsYerindeIcilenSigara = cigaretteExamination.OtherSmokersAtWorkPlace == null ? "" : Common.GetDisplayTextOfEnumValue("YesNoEnum", Convert.ToInt32(cigaretteExamination.OtherSmokersAtWorkPlace.Value));
                    data.EvdeDumanaMaruzKalanKisi = cigaretteExamination.PassiveSmokersAtHome == null ? "" : cigaretteExamination.PassiveSmokersAtHome.ToString();
                    data.ProfosyonelDestek = cigaretteExamination.ProfessionalSupport == null ? "" : Common.GetDisplayTextOfEnumValue("YesNoEnum", Convert.ToInt32(cigaretteExamination.ProfessionalSupport.Value));
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
    public class SigaraDegerlendirmeFormParameters
    {
        [DataMember]
        public Guid ObjectID { get; set; } //CigaretteExamination'in ObjectIDsi

    }
    [Serializable]
    public class SigaraDegerlendirmeFormuData
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
        public string SigaraBaslamaYasi { get; set; }
        [DataMember]
        public string YildaIcilenSigaraMiktari { get; set; }
        [DataMember]
        public string SigaraBaslamaNedeni { get; set; }
        [DataMember]
        public string SigaraBirakmaIstekNedeni { get; set; }
        [DataMember]
        public string SigaraMiktarindakiDegisim { get; set; }
        [DataMember]
        public string SigaraTipi { get; set; }
        [DataMember]
        public string GundeIcilenSigaraMiktari { get; set; }
        [DataMember]
        public string SigarayiBirakmayiDusundunuzMu { get; set; }
        [DataMember]
        public string SigaraBirakmayiDenedinizMi { get; set; }
        [DataMember]
        public string SigaraBirakmaYontemi { get; set; }
        [DataMember]
        public string SigaraİcmeİstegiArtNedenler { get; set; }
        [DataMember]
        public string IsYerindeIcilenSigara { get; set; }
        [DataMember]
        public string BosZamanlar { get; set; }
        [DataMember]
        public string DevamliKullanilanMadde { get; set; }
        [DataMember]
        public string IlkSigaraIcmeZamani { get; set; }
        [DataMember]
        public string SigaraYasagi { get; set; }
        [DataMember]
        public string VazgecmekİstenilenZaman { get; set; }
        [DataMember]
        public string AgirHasta { get; set; }
        [DataMember]
        public string EvdeBaskaIcen { get; set; }
        [DataMember]
        public string IsyerindeBaskaIcen { get; set; }
        [DataMember]
        public string EvdeDumanaMaruzKalanKisi { get; set; }
        [DataMember]
        public string ProfosyonelDestek { get; set; }
        #endregion

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
    }

}
