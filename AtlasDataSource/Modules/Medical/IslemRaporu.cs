using System;
using System.Runtime.Serialization;
using TTObjectClasses;
using System.ComponentModel;
using TTInstanceManagement;
using TTStorageManager.Security;
using ReportClasses.ReportUtils;

namespace AtlasDataSource.Controllers
{
    public class IslemRaporu
    {
        public static IslemRaporuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<IslemRaporuData>(parameters, "GetIslemRaporuData");
        }

        public static IslemRaporuData GetIslemRaporuData(string parameters)
        {
            IslemRaporuData data = new IslemRaporuData();
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<IslemRaporuParameters>(parameters.ToString());
                using (var objectContext = new TTObjectContext(false))
                {
                    BaseAdditionalApplication app = objectContext.GetObject<BaseAdditionalApplication>(param.ObjectID);
                    data.HastahaneAdi = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    data.IstekTarihi = app.CreationDate;
                    data.GerceklesmeTarihi = app.PerformedDate;
                    data.IslemAdi = app.ProcedureObject.Name;
                    data.IslemKodu = app.ProcedureObject.Code;
                    data.DoktorAdSoyad = app.ProcedureDoctor.Name;
                    data.Yas = app.Episode.Patient.Age.ToString();
                    data.Cinsiyet = app.Episode.Patient.Sex.ADI;
                    data.TCKimlikNo = app.Episode.Patient.UniqueRefNo.ToString();
                    data.AdSoyad = app.Episode.Patient.Name + " " + app.Episode.Patient.Surname;
                    data.KabulNo = app.SubEpisode.ProtocolNo;
                    data.DogumTarihi = app.Episode.Patient.BirthDate;
                    data.Rapor = ((AdditionalReport)app.BaseAdditionalInfoForm[0]).Report.ToString();
                    data.Tamamlandi = ((AdditionalReport)app.BaseAdditionalInfoForm[0]).IsCompleted == null ? false : Convert.ToBoolean(((AdditionalReport)app.BaseAdditionalInfoForm[0]).IsCompleted);
                    data.RaporYazilmaTarihi = ((AdditionalReport)app.BaseAdditionalInfoForm[0]).CreationDate;
                }

            }  

            return data;
        }

    }

    [Serializable]
    public class IslemRaporuParameters
    {
        [DataMember]
        public Guid ObjectID { get; set; } //Baseadditionalapplication'ın ObjectIDsi

    }

    [Serializable]
    public class IslemRaporuData
    {
        [DataMember]
        public string HastahaneAdi { get; set; }
        [DataMember]
        public DateTime? IstekTarihi { get; set; }
        [DataMember]
        public DateTime? GerceklesmeTarihi { get; set; }
        [DataMember]
        public string IslemAdi { get; set; }
        [DataMember]
        public string IslemKodu { get; set; }
        [DataMember]
        public string DoktorAdSoyad { get; set; }
        [DataMember]
        public string TCKimlikNo { get; set; }
        [DataMember]
        public string AdSoyad { get; set; }
        [DataMember]
        public string Yas { get; set; }
        [DataMember]
        public string Cinsiyet { get; set; }
        [DataMember]
        public DateTime? DogumTarihi { get; set; }
        [DataMember]
        public string KabulNo { get; set; }
        [DataMember]
        public string Rapor { get; set; }
        [DataMember]
        public bool Tamamlandi { get; set; }
        [DataMember]
        public DateTime? RaporYazilmaTarihi { get; set; }

    }
}
