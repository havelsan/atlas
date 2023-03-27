using System;
using System.Runtime.Serialization;
using TTObjectClasses;
using System.ComponentModel;
using TTInstanceManagement;
using TTStorageManager.Security;
using ReportClasses.ReportUtils;

namespace AtlasDataSource.Controllers
{
    public class ProstatTaramaFormu
    {
        public static ProstatTaramaFormuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<ProstatTaramaFormuData>(parameters, "GetMemeTaramaFormuData");
        }

        public static  ProstatTaramaFormuData GetProstatTaramaFormuData(string parameters)
        {
            ProstatTaramaFormuData data = new ProstatTaramaFormuData();
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<ProstatTaramaFormParameters>(parameters.ToString());
                using (var objectContext = new TTObjectContext(true))
                {
                    ProstateScreening prostateScreening = objectContext.GetObject<ProstateScreening>(param.ObjectID);
                    SubEpisode subEpisode = prostateScreening.SubEpisode;
                    Patient patient = subEpisode.Episode.Patient;

                    data.HastahaneAdi = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    data.TCKimlikNo = patient.UniqueRefNo == null ? "" : patient.UniqueRefNo.ToString();
                    data.AdSoyad = patient.Name + " " + patient.Surname;
                    data.BabaAdi = patient.FatherName == null ? "" : patient.FatherName.ToString();
                    data.DogumYeri = patient.CityOfBirth == null ? "" : patient.CityOfBirth.ToString();
                    data.DogumTarihi = patient.BirthDate;
                    data.KabulNo = subEpisode.ProtocolNo;
                    data.Meslek = patient.Occupation==null?"" : patient.Occupation.ADI;
                    data.AiledeKanserOykusu = prostateScreening.FamilyCancerHistory == null ? "" : Common.GetDisplayTextOfEnumValue("VarYokGarantiEnum", Convert.ToInt32(prostateScreening.FamilyCancerHistory.Value));
                    if (prostateScreening.AnamnesisInfo != null)
                    {
                        data.SigaraKullanimi = prostateScreening.AnamnesisInfo.SKRSSigaraKullanimi == null ? "" : prostateScreening.AnamnesisInfo.SKRSSigaraKullanimi.ADI;
                        data.AlkolKullanimi = prostateScreening.AnamnesisInfo.SKRSAlkolKullanimi == null ? "" : prostateScreening.AnamnesisInfo.SKRSAlkolKullanimi.ADI;

                    }
                    data.KullandigiIlaclar = prostateScreening.UsedMedicines == null ? "" : prostateScreening.UsedMedicines;
                    data.KronikHastaliklar = prostateScreening.ChronicDiseases == null ? "" : prostateScreening.ChronicDiseases;
                    data.SikIdraraCikma = prostateScreening.FrequentUrination == null ? false : Convert.ToBoolean(prostateScreening.FrequentUrination);
                    data.AgriliIdrar = prostateScreening.PainfulUrination == null ? false : Convert.ToBoolean(prostateScreening.PainfulUrination);
                    data.IdrarTamBosaltamama = prostateScreening.RetentionOfUrine == null ? false : Convert.ToBoolean(prostateScreening.RetentionOfUrine);
                    data.IdrarAkisindaAzalma = prostateScreening.ReductionInUrineFlow == null ? false : Convert.ToBoolean(prostateScreening.ReductionInUrineFlow);
                    data.PSA = prostateScreening.PSA == null ? "" : prostateScreening.PSA;
                    data.Muayene = prostateScreening.Examination == null ? "" : prostateScreening.Examination;
                    data.TotalPSA = prostateScreening.TotalPSA == null ? "" : prostateScreening.TotalPSA;
                    data.SerbestPSA = prostateScreening.FreePSA == null ? "" : prostateScreening.FreePSA;
                    data.MuayeneBulgulari = prostateScreening.ScreeningResult == null ? "" : prostateScreening.ScreeningResult;
                }
            }
            return data;
        }
    }

    [Serializable]
    public class ProstatTaramaFormParameters
    {
        [DataMember]
        public Guid ObjectID { get; set; } //ProstateScreening'in ObjectIDsi

    }
    [Serializable]
    public class ProstatTaramaFormuData
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
        public string Meslek { get; set; }
        [DataMember]
        public string AiledeKanserOykusu { get; set; }
        [DataMember]
        public string SigaraKullanimi { get; set; }
        [DataMember]
        public string AlkolKullanimi { get; set; }
        [DataMember]
        public string KullandigiIlaclar { get; set; }
        [DataMember]
        public string KronikHastaliklar { get; set; }
        [DataMember]
        public bool SikIdraraCikma { get; set; }
        [DataMember]
        public bool AgriliIdrar { get; set; }
        [DataMember]
        public bool IdrarTamBosaltamama { get; set; }
        [DataMember]
        public bool IdrarAkisindaAzalma { get; set; }
        [DataMember]
        public string PSA { get; set; }
        [DataMember]
        public string Muayene { get; set; }
        [DataMember]
        public string TotalPSA { get; set; }
        [DataMember]
        public string SerbestPSA { get; set; }
        [DataMember]
        public string MuayeneBulgulari { get; set; }
        #endregion
    }
}
