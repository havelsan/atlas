using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using TTObjectClasses;
using System.ComponentModel;
using ReportClasses.ReportUtils;


using TTInstanceManagement;
using TTStorageManager.Security;


namespace AtlasDataSource.Controllers
{
    public class ToplumTabanliKanserTaramaFormu
    {
        public static ToplumTabanliKanserTaramaFormuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<ToplumTabanliKanserTaramaFormuData>(parameters, "GetToplumTabanliKanserTaramaFormuData");
        }
        public static ToplumTabanliKanserTaramaFormuData GetToplumTabanliKanserTaramaFormuData(string parameters)
        {
            ToplumTabanliKanserTaramaFormuData data = new ToplumTabanliKanserTaramaFormuData();
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<ToplumTabanliKanserTaramaFormuParameters>(parameters.ToString());
                using (var objectContext = new TTObjectContext(true))
                {
                    CancerScreening cancerScreening = objectContext.GetObject<CancerScreening>(param.ObjectID);
                    SubEpisode subEpisode = cancerScreening.SubEpisode;
                    Patient patient = subEpisode.Episode.Patient;

                    data.HastahaneAdi = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    data.TCKimlikNo = patient.UniqueRefNo == null ? "" : patient.UniqueRefNo.ToString();
                    data.AdSoyad = patient.Name + " " + patient.Surname;
                    data.BabaAdi = patient.FatherName == null ? "" : patient.FatherName.ToString();
                    data.DogumYeri = patient.CityOfBirth == null ? "" : patient.CityOfBirth.ToString();
                    data.DogumTarihi = patient.BirthDate;
                    data.KabulNo = subEpisode.ProtocolNo;

                    data.TaramaTipi = cancerScreening.SKRSTARAMATIPI == null ? "" : cancerScreening.SKRSTARAMATIPI.ADI;
                    data.TaramaTarihi = cancerScreening.TaramaTarihi;
                    data.TaramaSonuclanmaTarihi = cancerScreening.TaramaSonuclanmaTarihi;
                    data.GaitadaGizliKanTesti = cancerScreening.SKRSGaitadaGizliKanTesti == null ? "" : cancerScreening.SKRSGaitadaGizliKanTesti.ADI;
                    data.HPVTaramaTesti = cancerScreening.SKRSHPVTaramaTesti == null ? "" : cancerScreening.SKRSHPVTaramaTesti.ADI;
                    data.KendiKendineMemeMuayenesi = cancerScreening.SKRSKendiKendineMemeMuayenesi == null ? "" : cancerScreening.SKRSKendiKendineMemeMuayenesi.ADI;
                    data.KlinikMemeMuayenesi = cancerScreening.SKRSKlinikMemeMuayenesi == null ? "" : cancerScreening.SKRSKlinikMemeMuayenesi.ADI;
                    data.Kolonoskopi = cancerScreening.SKRSKolonoskopi == null ? "" : cancerScreening.SKRSKolonoskopi.ADI;
                    data.KolonoskopininSuresi = cancerScreening.SKRSKolonoskopininSuresi == null ? "" : cancerScreening.SKRSKolonoskopininSuresi.ADI;
                    data.KolonGoruntulemeYontemi = cancerScreening.SKRSKolonGoruntulemeYontemi == null ? "" : cancerScreening.SKRSKolonGoruntulemeYontemi.ADI;
                    data.Kolposkopi = cancerScreening.SKRSKolposkopi == null ? "" : cancerScreening.SKRSKolposkopi.ADI;
                    data.Mamografi = cancerScreening.SKRSMamografi == null ? "" : cancerScreening.SKRSMamografi.ADI;
                    data.MamografiSonucu = cancerScreening.SKRSMamografiSonucu == null ? "" : cancerScreening.SKRSMamografiSonucu.ADI;
                    data.PapSmearTesti = cancerScreening.SKRSPapSmearTesti == null ? "" : cancerScreening.SKRSPapSmearTesti.ADI;
                    data.Sigmoidoskopi = cancerScreening.SKRSSigmoidoskopi == null ? "" : cancerScreening.SKRSSigmoidoskopi.ADI;

                    data.HpvTipiList = new List<KetemData>();
                    foreach(var hpv in cancerScreening.HPVTypeInfo)
                    {
                        KetemData d = new KetemData();
                        d.Info = hpv.SKRSHpvTipi == null ? "" : hpv.SKRSHpvTipi.ADI;
                        data.HpvTipiList.Add(d);
                    }

                    data.KolonoskopiKaliteKriterleriList = new List<KetemData>();
                    foreach (var kolonoskopi in cancerScreening.ColonoscopyQualityCriteria)
                    {
                        KetemData d = new KetemData();
                        d.Info = kolonoskopi.KolonoskopiKaliteKriterleri == null ? "" : kolonoskopi.KolonoskopiKaliteKriterleri.ADI;
                        data.KolonoskopiKaliteKriterleriList.Add(d);
                    }

                    data.KolorektalBiyopsiSonucuList = new List<KetemData>();
                    foreach (var kolorektal in cancerScreening.ColorectalBiopsyResults)
                    {
                        KetemData d = new KetemData();
                        d.Info = kolorektal.SKRSKolorektalBiyopsiSonucu == null ? "" : kolorektal.SKRSKolorektalBiyopsiSonucu.ADI;
                        data.KolorektalBiyopsiSonucuList.Add(d);
                    }

                    data.ServikalBiyopsiSonucuList = new List<KetemData>();
                    foreach (var cervicalBiopsy in cancerScreening.CervicalBiopsyResults)
                    {
                        KetemData d = new KetemData();
                        d.Info = cervicalBiopsy.SKRSServikalBiyopsiSonucu == null ? "" : cervicalBiopsy.SKRSServikalBiyopsiSonucu.ADI;
                        data.ServikalBiyopsiSonucuList.Add(d);
                    }

                    data.ServikalSitolojiSonucuList = new List<KetemData>();
                    foreach (var cervicalCytology in cancerScreening.CervicalCytologyResults)
                    {
                        KetemData d = new KetemData();
                        d.Info = cervicalCytology.SKRSServikalSitolojiSonucu == null ? "" : cervicalCytology.SKRSServikalSitolojiSonucu.ADI;
                        data.ServikalSitolojiSonucuList.Add(d);
                    }

                    data.MemeBiyopsiList = new List<MemeBiyopsiData>();
                    foreach (var bBiopsy in cancerScreening.BreastBiopsy)
                    {
                        MemeBiyopsiData d = new MemeBiyopsiData();
                        d.MemedenBiyopsiAlimi = bBiopsy.SKRSMemedenBiyopsiAlimi == null ? "" : bBiopsy.SKRSMemedenBiyopsiAlimi.ADI;
                        d.MemedenBiyopsiSonucu = bBiopsy.SKRSMemeBiyopsiSonucu == null ? "" : bBiopsy.SKRSMemeBiyopsiSonucu.ADI;
                        data.MemeBiyopsiList.Add(d);
                    }
                }
            }
            return data;
        }
    }

    [Serializable]
    public class ToplumTabanliKanserTaramaFormuParameters
    {
        [DataMember]
        public Guid ObjectID { get; set; } //CancerScreening'in ObjectIDsi

    }

    [Serializable]
    public class ToplumTabanliKanserTaramaFormuData
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
        public string TaramaTipi { get; set; }
        [DataMember]
        public DateTime? TaramaTarihi { get; set; }
        [DataMember]
        public DateTime? TaramaSonuclanmaTarihi { get; set; }
        [DataMember]
        public string GaitadaGizliKanTesti { get; set; }
        [DataMember]
        public string HPVTaramaTesti { get; set; }
        [DataMember]
        public string KendiKendineMemeMuayenesi { get; set; }
        [DataMember]
        public string KlinikMemeMuayenesi { get; set; }
        [DataMember]
        public string Kolonoskopi { get; set; }
        [DataMember]
        public string KolonoskopininSuresi { get; set; }
        [DataMember]
        public string KolonGoruntulemeYontemi { get; set; }
        [DataMember]
        public string Kolposkopi { get; set; }
        [DataMember]
        public string Mamografi { get; set; }
        [DataMember]
        public string MamografiSonucu { get; set; }
        [DataMember]
        public string PapSmearTesti { get; set; }
        [DataMember]
        public string Sigmoidoskopi { get; set; }
        [DataMember]
        public List<KetemData> HpvTipiList { get; set; }
        [DataMember]
        public List<KetemData> KolonoskopiKaliteKriterleriList { get; set; }
        [DataMember]
        public List<KetemData> KolorektalBiyopsiSonucuList { get; set; }
        [DataMember]
        public List<KetemData> ServikalBiyopsiSonucuList { get; set; }
        [DataMember]
        public List<KetemData> ServikalSitolojiSonucuList { get; set; }
        [DataMember]
        public List<MemeBiyopsiData> MemeBiyopsiList { get; set; }

        #endregion
    }
    [Serializable]
    public class KetemData
    {
        [DataMember]
        public string Info { get; set; }
       
    }

    [Serializable]
    public class MemeBiyopsiData
    {
        [DataMember]
        public string MemedenBiyopsiAlimi { get; set; }
        [DataMember]
        public string MemedenBiyopsiSonucu { get; set; }

    }

}
