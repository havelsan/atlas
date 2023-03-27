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


namespace AtlasDataSource.Controllers
{
    public class ManipulasyonRandevuBilgiFormu
    {
        public static ManipulasyonRandevuReportData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<ManipulasyonRandevuReportData>(parameters, "GetManipulasyonRandevuReportData");
        }

        public static ManipulasyonRandevuReportData GetManipulasyonRandevuReportData(string parameters)
        {
            ManipulasyonRandevuReportData data = new ManipulasyonRandevuReportData();
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<ManipulasyonRandevuParameters>(parameters.ToString());
                using (var objectContext = new TTObjectContext(false))
                {
                    Manipulation manipulation = objectContext.GetObject<Manipulation>(param.ManipulationObjectID);
                    SubEpisode subepisode = manipulation.SubEpisode;
                    Patient patient = subepisode.Episode.Patient;

                    data.HastahaneAdi = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    data.HastaTC = patient.UniqueRefNo.ToString();
                    data.HastaAdiSoyadi = patient.Name.ToString() + " " + patient.Surname.ToString();
                    data.HastaDogumTarihi = patient.BirthDate;
                    data.HastaDogumYeri = patient.TownOfBirth == null ? "" : patient.TownOfBirth.Name;
                    data.Cinsiyeti = patient.Sex == null ? "" : patient.Sex.ADI;
                    data.KabulNumarasi = subepisode.ProtocolNo;

                    var diagnosisList = DiagnosisGrid.GetBySubEpisode(objectContext, subepisode.ObjectID.ToString());
                    data.Tanilar = new List<RadiologyDiagnosisData>();
                    foreach (DiagnosisGrid d in diagnosisList)
                    {
                        RadiologyDiagnosisData tani = new RadiologyDiagnosisData();
                        tani.TaniKodu = d.Diagnose.Code;
                        tani.TaniAdi = d.Diagnose.Name;
                        data.Tanilar.Add(tani);
                    }

                    data.OnBilgi = manipulation.PreInformation == null ? "" : manipulation.PreInformation.ToString();
                    data.TetkikKodu = manipulation.ManipulationProcedures[0].ProcedureObject.Code;
                    data.TetkikAdi = manipulation.ManipulationProcedures[0].ProcedureObject.Name;
                    data.IstekYapanDoktor = manipulation.RequestedByUser == null ? "" : manipulation.RequestedByUser.Name;
                    data.RandevuTarihi = "";
                    data.RandevuBilgileri = BaseAction.GetFullAppointmentDescription(manipulation);
                    data.RandevuVeren = "";


                }
            }
            return data;
        }
    }

    [Serializable]
    public class ManipulasyonRandevuParameters
    {
        [DataMember]
        public Guid ManipulationObjectID { get; set; } //MANIPULATION'nin ObjectIDsi

    }

    [Serializable]
    public class ManipulasyonRandevuReportData
    {
        [DataMember]
        public string HastahaneAdi { get; set; }
        //Hasta Bilgileri
        [DataMember]
        public string HastaTC { get; set; }
        [DataMember]
        public string HastaAdiSoyadi { get; set; }
        [DataMember]
        public DateTime? HastaDogumTarihi { get; set; }
        [DataMember]
        public string HastaDogumYeri { get; set; }
        [DataMember]
        public string Cinsiyeti { get; set; }
        [DataMember]
        public string KabulNumarasi { get; set; }
        //Tanılar
        [DataMember]
        public List<RadiologyDiagnosisData> Tanilar { get; set; }

        [DataMember]
        public string OnBilgi { get; set; }
        [DataMember]
        public string RandevuTarihi { get; set; }
        [DataMember]
        public string RandevuBilgileri { get; set; }
        [DataMember]
        public string TetkikKodu { get; set; }
        [DataMember]
        public string TetkikAdi{ get; set; }
        [DataMember]
        public string RandevuVeren { get; set; }
        [DataMember]
        public string IstekYapanDoktor { get; set; }
    }
}
