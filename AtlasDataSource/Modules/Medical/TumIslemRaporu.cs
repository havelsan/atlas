using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel;
using TTInstanceManagement;
using TTObjectClasses;
using ReportClasses.ReportUtils;

namespace AtlasDataSource.Controllers
{
    public class TumIslemRaporu 
    {
        public static TumIslemRaporuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<TumIslemRaporuData>(parameters, "GetTumIslemRaporuData");
        }
        public static TumIslemRaporuData GetTumIslemRaporuData(string parameters)
        {
            TumIslemRaporuData data = new TumIslemRaporuData();
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<TumIslemRaporuParameters>(parameters.ToString());

                using (var objectContext = new TTObjectContext(false)) 
                {
                    SubEpisode subepisode = objectContext.GetObject<SubEpisode>(param.ObjectID);
                    Episode episode = subepisode.Episode;
                    Patient patient = episode.Patient;
                    data.HastaAdiSoyadi = patient.Name + " " + patient.Surname;
                    data.KabulNo = subepisode.ProtocolNo  == null ? " " : subepisode.ProtocolNo.ToString();
                    data.KabulTarihi = subepisode.OpeningDate;
                    data.TCKimlikNo = patient.UniqueRefNo == null ? " " : patient.UniqueRefNo.ToString();
                    data.YatisTarihi = null;
                    data.CikisTarihi = null;
                    if (subepisode.PatientStatus == SubEpisodeStatusEnum.Daily)
                        data.HastaTuru = "Günübirlik";
                    else if (subepisode.PatientStatus == SubEpisodeStatusEnum.Outpatient)
                        data.HastaTuru = "Ayaktan";
                    else if (subepisode.PatientStatus == SubEpisodeStatusEnum.Inpatient)
                    {
                        data.HastaTuru = "Yatan";
                        var starterEpisodeAction = subepisode.StarterEpisodeAction;
                        if (starterEpisodeAction is InPatientTreatmentClinicApplication)
                        {
                            InPatientTreatmentClinicApplication inPatientTreatmentClinicApplication = (InPatientTreatmentClinicApplication)starterEpisodeAction;
                            data.YatisTarihi = inPatientTreatmentClinicApplication.ClinicInpatientDate;
                            data.CikisTarihi = inPatientTreatmentClinicApplication.ClinicDischargeDate;
                        }
                    }
                    else
                        data.HastaTuru = "";

                    SubEpisodeProtocol sep = subepisode.SGKSEP;
                    if (sep != null && sep.MedulaTakipNo != null)
                        data.ProvizyonNo = sep.MedulaTakipNo;
                    else
                        data.ProvizyonNo = "";
                    data.Birim = subepisode.ResSection.Name;
                    data.KurumAdi = subepisode.LastSubEpisodeProtocol.Payer.Name;

                }

                BindingList<SubActionProcedure.GetSubactionProceduresBySubepisode_Class> subactionProcedures = SubActionProcedure.GetSubactionProceduresBySubepisode(param.ObjectID);
                data.Islemler = new List<IslemData>();
                foreach (SubActionProcedure.GetSubactionProceduresBySubepisode_Class procedure in subactionProcedures)
                {
                    IslemData islem = new IslemData();
                    islem.IslemTarihi = procedure.PerformedDate;
                    islem.IslemTetkikKodu = procedure.Procedurecode == null ? " " : procedure.Procedurecode.ToString();
                    islem.IslemTetkikAdi = procedure.Procedurename == null ? " " : procedure.Procedurename.ToString();
                    islem.Miktar = procedure.Amount == null ? " " : procedure.Amount.ToString();
                    islem.Fiyat = procedure.Price == null ? " " : procedure.Price.ToString();
                    data.Islemler.Add(islem);
                }


                BindingList<DiagnosisGrid.getDiagnosisJustBySubepisode_Class> diagnosis = DiagnosisGrid.getDiagnosisJustBySubepisode(param.ObjectID.ToString());
                data.Tanilar = new List<TaniData>();
                foreach(DiagnosisGrid.getDiagnosisJustBySubepisode_Class d in diagnosis)
                {
                    TaniData tani = new TaniData();
                    tani.TaniKodu = d.Icd10_kodu;
                    tani.TaniAdi = d.Idc10_deger;
                    data.Tanilar.Add(tani);
                }
            }

            return data;
        }
    }
    [Serializable]
    public class TumIslemRaporuParameters
    {
        [DataMember]
        public Guid ObjectID { get; set; } //Subepisode'un ObjectIDsi

    }

    [Serializable]
    public class TumIslemRaporuData
    {
        [DataMember]
        public string HastaAdiSoyadi { get; set; }
        [DataMember]
        public string KabulNo { get; set; }
        [DataMember]
        public DateTime? KabulTarihi { get; set; }
        [DataMember]
        public string TCKimlikNo { get; set; }
        [DataMember]
        public string HastaTuru { get; set; }
        [DataMember]
        public DateTime? YatisTarihi { get; set; }
        [DataMember]
        public DateTime? CikisTarihi { get; set; }
        [DataMember]
        public string ProvizyonNo { get; set; }
        [DataMember]
        public string Birim { get; set; }
        [DataMember]
        public string KurumAdi { get; set; }
        [DataMember]
        public List<TaniData> Tanilar { get; set; }
        [DataMember]
        public List<IslemData> Islemler { get; set; }
    }
    [Serializable]
    public class TaniData
    {
        [DataMember]
        public string TaniKodu { get; set; }
        [DataMember]
        public string TaniAdi { get; set; }
    }
    [Serializable]
    public class IslemData
    {
        [DataMember]
        public DateTime? IslemTarihi { get; set; }
        [DataMember]
        public string IslemTetkikKodu { get; set; }
        [DataMember]
        public string IslemTetkikAdi { get; set; }
        [DataMember]
        public string Miktar { get; set; }
        [DataMember]
        public string Fiyat { get; set; }
     
    }
}
