using System;
using System.Runtime.Serialization;
using TTObjectClasses;
using System.ComponentModel;
using TTInstanceManagement;
using TTStorageManager.Security;
using ReportClasses.ReportUtils;

namespace AtlasDataSource.Controllers
{
    public class SigaraMuayeneFormu
    {
        public static SigaraMuayeneFormuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<SigaraMuayeneFormuData>(parameters, "GetSigaraMuayeneFormuData");
        }
        public static SigaraMuayeneFormuData GetSigaraMuayeneFormuData(string parameters)
        {
            SigaraMuayeneFormuData data = new SigaraMuayeneFormuData();
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<SigaraMuayeneFormParameters>(parameters.ToString());
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
                    data.BasAgrisiveDonmesi = cigaretteExamination.HeadacheAndDizziness == null ? false : Convert.ToBoolean(cigaretteExamination.HeadacheAndDizziness);
                    data.GozlerdeKizariklik = cigaretteExamination.RedEye == null ? false : Convert.ToBoolean(cigaretteExamination.RedEye);
                    data.DislerdeSararma = cigaretteExamination.YellowTeeth == null ? false : Convert.ToBoolean(cigaretteExamination.YellowTeeth);
                    data.PasliDil = cigaretteExamination.CoatedTongue == null ? false : Convert.ToBoolean(cigaretteExamination.CoatedTongue);
                    data.KotuTat = cigaretteExamination.BadTaste == null ? false : Convert.ToBoolean(cigaretteExamination.BadTaste);
                    data.BurunTikanikligi = cigaretteExamination.NasalBlockage == null ? false : Convert.ToBoolean(cigaretteExamination.NasalBlockage);
                    data.Oksuruk = cigaretteExamination.Cough == null ? false : Convert.ToBoolean(cigaretteExamination.Cough);
                    data.Balgam = cigaretteExamination.Phlegm == null ? false : Convert.ToBoolean(cigaretteExamination.Phlegm);
                    data.NefesDarligi = cigaretteExamination.ShortnessOfBreath == null ? false : Convert.ToBoolean(cigaretteExamination.ShortnessOfBreath);
                    data.KanTukurme = cigaretteExamination.BloodSpitting == null ? false : Convert.ToBoolean(cigaretteExamination.BloodSpitting);
                    data.GogusAgrisi = cigaretteExamination.ChestPain == null ? false : Convert.ToBoolean(cigaretteExamination.ChestPain);
                    data.Angina = cigaretteExamination.Angina == null ? false : Convert.ToBoolean(cigaretteExamination.Angina);
                    data.Ortopne = cigaretteExamination.Ortopne == null ? false : Convert.ToBoolean(cigaretteExamination.Ortopne);
                    data.PND = cigaretteExamination.PND == null ? false : Convert.ToBoolean(cigaretteExamination.PND);
                    data.Carpinti = cigaretteExamination.Palpitation == null ? false : Convert.ToBoolean(cigaretteExamination.Palpitation);
                    data.Konvulsiyon = cigaretteExamination.Convulsion == null ? false : Convert.ToBoolean(cigaretteExamination.Convulsion);
                    data.Epilepsi = cigaretteExamination.Epilepsy == null ? false : Convert.ToBoolean(cigaretteExamination.Epilepsy);
                    data.SerebrovaskulerCerrahi = cigaretteExamination.CerebrovascularSurgery == null ? false : Convert.ToBoolean(cigaretteExamination.CerebrovascularSurgery);
                    data.KafaTravmasi = cigaretteExamination.HeadTrauma == null ? false : Convert.ToBoolean(cigaretteExamination.HeadTrauma);
                    data.Bulanti = cigaretteExamination.Nausea == null ? false : Convert.ToBoolean(cigaretteExamination.Nausea);
                    data.Ishal = cigaretteExamination.Diarrhea == null ? false : Convert.ToBoolean(cigaretteExamination.Diarrhea);
                    data.Kabiz = cigaretteExamination.Constipation == null ? false : Convert.ToBoolean(cigaretteExamination.Constipation);
                    data.MidedeEksime = cigaretteExamination.GastricAcidity == null ? false : Convert.ToBoolean(cigaretteExamination.GastricAcidity);
                    data.Nokturi = cigaretteExamination.Nocturia == null ? false : Convert.ToBoolean(cigaretteExamination.Nocturia);
                    data.Dizuri = cigaretteExamination.Dysuria == null ? false : Convert.ToBoolean(cigaretteExamination.Dysuria);
                    data.LibidoKaybi = cigaretteExamination.LibidoLoss == null ? false : Convert.ToBoolean(cigaretteExamination.LibidoLoss);
                    data.PsikolojikTedaviAldiMi = cigaretteExamination.PreviousPsychologicalTrt == null ? "" : Common.GetDisplayTextOfEnumValue("YesNoEnum", Convert.ToInt32(cigaretteExamination.PreviousPsychologicalTrt.Value));
                    data.SonIkiHafta = cigaretteExamination.HowHeSheFeels == null ? "" : cigaretteExamination.HowHeSheFeels.ToString();
                    data.HT = cigaretteExamination.HT == null ? false : Convert.ToBoolean(cigaretteExamination.HT);
                    data.DM = cigaretteExamination.DM == null ? false : Convert.ToBoolean(cigaretteExamination.DM);
                    data.Hiperlipidemi = cigaretteExamination.Hyperlipidemia == null ? false : Convert.ToBoolean(cigaretteExamination.Hyperlipidemia);
                    data.EnfarktusAngina = cigaretteExamination.InfarctionAngina == null ? false : Convert.ToBoolean(cigaretteExamination.InfarctionAngina);
                    data.KRBronsit = cigaretteExamination.KrBronchitis == null ? false : Convert.ToBoolean(cigaretteExamination.KrBronchitis);
                    data.PUlcus = cigaretteExamination.PUlcus == null ? false : Convert.ToBoolean(cigaretteExamination.PUlcus);
                    data.DamarTikanikligi = cigaretteExamination.Embolism == null ? false : Convert.ToBoolean(cigaretteExamination.Embolism);
                    data.AKCDigerKanserler = cigaretteExamination.AKCOtherCancers == null ? false : Convert.ToBoolean(cigaretteExamination.AKCOtherCancers);
                    data.GecirdiğiHastaliklar = cigaretteExamination.PreviousDiseases == null ? "" : cigaretteExamination.PreviousDiseases.ToString();
                    data.IlacOykusu = cigaretteExamination.MedicineHistory == null ? "" : cigaretteExamination.MedicineHistory.ToString();
                    data.KazaOperasyonBilgisi = cigaretteExamination.OperationInfo == null ? "" : cigaretteExamination.OperationInfo.ToString();
                    data.TansiyonArteriyel = cigaretteExamination.TensionArterial == null ? "" : cigaretteExamination.TensionArterial.ToString();
                    data.Nabiz = cigaretteExamination.Pulse == null ? "" : cigaretteExamination.Pulse.ToString();
                    data.SolunumSayisi = cigaretteExamination.RespirationRate == null ? "" : cigaretteExamination.RespirationRate.ToString();
                    data.CiltMukoza = cigaretteExamination.SkinMucosa == null ? "" : cigaretteExamination.SkinMucosa.ToString();
                    data.BasBoyun = cigaretteExamination.HeadNeck == null ? "" : cigaretteExamination.HeadNeck.ToString();
                    data.SolunumSistemi = cigaretteExamination.RespiratorySystem == null ? "" : cigaretteExamination.RespiratorySystem.ToString();
                    data.KardiyovaskulerSistem = cigaretteExamination.CardiovascularSystem == null ? "" : cigaretteExamination.CardiovascularSystem.ToString();
                    data.GastroIntestinalSistem = cigaretteExamination.GastrointestinalSystem == null ? "" : cigaretteExamination.GastrointestinalSystem.ToString();
                    data.GenitourinerSistem = cigaretteExamination.GenitourinarySystem == null ? "" : cigaretteExamination.GenitourinarySystem.ToString();
                    data.AkcigerGrafisi = cigaretteExamination.ChestRadiography == null ? "" : cigaretteExamination.ChestRadiography.ToString();
                    data.EKG = cigaretteExamination.EKG == null ? "" : cigaretteExamination.EKG.ToString();
                    data.COKArboksiHB = cigaretteExamination.COCarboxyHB == null ? "" : cigaretteExamination.COCarboxyHB.ToString();
                    data.SFT = cigaretteExamination.SFT == null ? "" : cigaretteExamination.SFT.ToString();
                }

            }
                    return data;
        }
    }

    [Serializable]
    public class SigaraMuayeneFormParameters
    {
        [DataMember]
        public Guid ObjectID { get; set; } //CigaretteExamination'in ObjectIDsi

    }

    [Serializable]
    public class SigaraMuayeneFormuData
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
        public bool BasAgrisiveDonmesi { get; set; }
        [DataMember]
        public bool GozlerdeKizariklik { get; set; }
        [DataMember]
        public bool DislerdeSararma { get; set; }
        [DataMember]
        public bool PasliDil { get; set; }
        [DataMember]
        public bool KotuTat { get; set; }
        [DataMember]
        public bool BurunTikanikligi { get; set; }
        [DataMember]
        public bool Oksuruk { get; set; }
        [DataMember]
        public bool Balgam { get; set; }
        [DataMember]
        public bool NefesDarligi { get; set; }
        [DataMember]
        public bool KanTukurme { get; set; }
        [DataMember]
        public bool GogusAgrisi { get; set; }
        [DataMember]
        public bool Angina { get; set; }
        [DataMember]
        public bool Ortopne { get; set; }
        [DataMember]
        public bool PND { get; set; }
        [DataMember]
        public bool Carpinti { get; set; }
        [DataMember]
        public bool Konvulsiyon { get; set; }
        [DataMember]
        public bool Epilepsi { get; set; }
        [DataMember]
        public bool SerebrovaskulerCerrahi { get; set; }
        [DataMember]
        public bool KafaTravmasi { get; set; }
        [DataMember]
        public bool Bulanti { get; set; }
        [DataMember]
        public bool Kabiz { get; set; }
        [DataMember]
        public bool Ishal { get; set; }
        [DataMember]
        public bool MidedeEksime { get; set; }
        [DataMember]
        public bool Nokturi { get; set; }
        [DataMember]
        public bool LibidoKaybi { get; set; }
        [DataMember]
        public bool Dizuri { get; set; }
        [DataMember]
        public string PsikolojikTedaviAldiMi { get; set; }
        [DataMember]
        public string SonIkiHafta { get; set; }
        [DataMember]
        public bool HT { get; set; }
        [DataMember]
        public bool DM { get; set; }
        [DataMember]
        public bool Hiperlipidemi { get; set; }
        [DataMember]
        public bool EnfarktusAngina { get; set; }
        [DataMember]
        public bool KRBronsit { get; set; }
        [DataMember]
        public bool PUlcus { get; set; }
        [DataMember]
        public bool DamarTikanikligi { get; set; }
        [DataMember]
        public bool AKCDigerKanserler { get; set; }
        [DataMember]
        public string GecirdiğiHastaliklar { get; set; }
        [DataMember]
        public string IlacOykusu { get; set; }
        [DataMember]
        public string KazaOperasyonBilgisi { get; set; }
        [DataMember]
        public string TansiyonArteriyel { get; set; }
        [DataMember]
        public string Nabiz { get; set; }
        [DataMember]
        public string SolunumSayisi { get; set; }
        [DataMember]
        public string CiltMukoza { get; set; }
        [DataMember]
        public string BasBoyun { get; set; }
        [DataMember]
        public string SolunumSistemi { get; set; }
        [DataMember]
        public string KardiyovaskulerSistem { get; set; }
        [DataMember]
        public string GastroIntestinalSistem { get; set; }
        [DataMember]
        public string GenitourinerSistem { get; set; }
        [DataMember]
        public string AkcigerGrafisi { get; set; }
        [DataMember]
        public string EKG { get; set; }
        [DataMember]
        public string COKArboksiHB { get; set; }
        [DataMember]
        public string SFT { get; set; }

        #endregion
    }
}
