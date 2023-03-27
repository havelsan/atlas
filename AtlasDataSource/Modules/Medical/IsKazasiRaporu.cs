using System;
using System.Runtime.Serialization;
using TTObjectClasses;
using System.ComponentModel;
using TTInstanceManagement;
using TTStorageManager.Security;
using ReportClasses.ReportUtils;

namespace AtlasDataSource.Controllers
{
    public class IsKazasiRaporu
    {
        public static IsKazasiRaporuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<IsKazasiRaporuData>(parameters, "GetIsKazasiRaporuData");
        }

        public static IsKazasiRaporuData GetIsKazasiRaporuData(string parameters)
        {
            IsKazasiRaporuData data = new IsKazasiRaporuData();
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<IsKazasiParameters>(parameters.ToString());
                using (var objectContext = new TTObjectContext(false))
                {
                    SubEpisode subepisode = objectContext.GetObject<SubEpisode>(new Guid(param.SubEpisodeID));
                    Patient patient = subepisode.Episode.Patient;
                    data.AdiSoyadi = patient.Name + " " + patient.Surname;
                    data.TCKimlikNo = patient.UniqueRefNo == null ? "" : patient.UniqueRefNo.ToString();
                    data.DogumTarihi = patient.BirthDate;
                    data.Uyruk = patient.Nationality.Adi;
                    data.HastahaneAdi = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");

                    BindingList<IndustrialAccidentReport.GetIndustrialAccidentReportBySubepisode_Class> reportList = IndustrialAccidentReport.GetIndustrialAccidentReportBySubepisode(subepisode.ObjectID);
                    if (reportList.Count > 0)
                    {
                  
                        IndustrialAccidentReport report = objectContext.GetObject<IndustrialAccidentReport>(new Guid(reportList[0].ObjectID.ToString()));
           
                        data.IsYeriIl = report.City == null ? "" : report.City;
                        data.SaptanmaSekli = report.DeterminationWay == null ? "" : report.DeterminationWay;
                        data.MeslekHastaligiEtkenSuresi = report.DiseaseActiveTime == null ? "" : report.DiseaseActiveTime;
                        data.MeslekHastaligiEtkeni = report.DiseaseFactor == null ? "" : report.DiseaseFactor;
                        data.IsGoremezlikSeviyesi = report.IncapacityLevel == null ? "" : report.IncapacityLevel;
                        data.BildirimTarihi = report.NoticeDate;
                        data.BildirimTarihi2 = report.NoticeDate2;
                        data.Tel = report.PhoneNumber == null ? "" : report.PhoneNumber;
                        data.Gorevi = report.Position == null ? "" : report.Position;
                        data.Unite = report.Unit == null ? "" : report.Unit;
                        data.IsYeriAdres = report.WorkAddress == null ? "" : report.WorkAddress;
                        data.CalisilanOrtam = report.WorkEnvironment == null ? "" : report.WorkEnvironment;
                        data.IsYeriNo = report.WorkPlaceNo == null ? "" : report.WorkPlaceNo;
                        data.IsYeriUnvan = report.WorkTitle == null ? "" : report.WorkTitle;
                        data.Arac = report.WoundCause == null ? "" : report.WoundCause;
                        data.YaraninVucuttakiYeri = report.WoundLocation == null ? "" : report.WoundLocation;
                        data.YaraninTuru = report.WoundType == null ? "" : report.WoundType;

                    }
                }

            }
            return data;
        }

        [Serializable]
        public class IsKazasiParameters
        {
            [DataMember]
            public string SubEpisodeID { get; set; } 

        }


        [Serializable]
        public class IsKazasiRaporuData
        {
            [DataMember]
            public string HastahaneAdi { get; set; }
            //Is Yeri Bilgileri
            [DataMember]
            public string IsYeriNo { get; set; }
            [DataMember]
            public string Unite { get; set; }
            [DataMember]
            public string IsYeriAdres { get; set; }
            [DataMember]
            public string IsYeriUnvan { get; set; }
            [DataMember]
            public string IsYeriIl { get; set; }

            //Sigortalı Bilgileri
            [DataMember]
            public string AdiSoyadi { get; set; }
            [DataMember]
            public string TCKimlikNo { get; set; }
            [DataMember]
            public string Gorevi { get; set; }
            [DataMember]
            public string Tel { get; set; }
            [DataMember]
            public string YaraninTuru { get; set; }
            [DataMember]
            public DateTime? DogumTarihi { get; set; }
            [DataMember]
            public string Uyruk { get; set; }
            [DataMember]
            public string YaraninVucuttakiYeri { get; set; }
            [DataMember]
            public string Arac { get; set; }
            [DataMember]
            public DateTime? BildirimTarihi { get; set; }

            //Meslek Hastaligi
            [DataMember]
            public string CalisilanOrtam { get; set; }
            [DataMember]
            public string SaptanmaSekli { get; set; }
            [DataMember]
            public string MeslekHastaligiEtkeni { get; set; }
            [DataMember]
            public DateTime? TaniTarihi { get; set; }
            [DataMember]
            public string MeslekHastaligiEtkenSuresi { get; set; }
            [DataMember]
            public string IsGoremezlikSeviyesi { get; set; }
            [DataMember]
            public DateTime? BildirimTarihi2 { get; set; }

        }
    }
}
