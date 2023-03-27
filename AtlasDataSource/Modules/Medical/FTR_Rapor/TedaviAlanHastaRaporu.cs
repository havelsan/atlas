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
    public class TedaviAlanHastaRaporu
    {
        public static FTRReportData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<FTRReportData>(parameters, "GetTedaviAlanHastaReportData");
        }

        public static FTRReportData GetTedaviAlanHastaReportData(string parameters)
        {
            FTRReportData data = new FTRReportData();
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<FTRReportParameters>(parameters.ToString());
                using (var objectContext = new TTObjectContext(false))
                {
                    PhysiotherapyRequest physiotherapyRequest = objectContext.GetObject<PhysiotherapyRequest>(param.ObjectID);
                    SubEpisode subEpisode = physiotherapyRequest.SubEpisode;
                    Patient patient = subEpisode.Episode.Patient;

                    data.HastahaneAdi = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    data.TCKimlikNo = patient.UniqueRefNo == null ? "" : patient.UniqueRefNo.ToString();
                    data.AdSoyad = patient.Name + " " + patient.Surname;
                    data.PoliklinikAdi = physiotherapyRequest.FromResource == null ? "" : physiotherapyRequest.FromResource.Name;
                    data.Tarih = DateTime.Now;

                    var orderedList = physiotherapyRequest.PhysiotherapyOrderDetails.OrderByDescending(x => x.PlannedDate).ToList();
                    data.TedaviBaslangicTarihi = orderedList.FirstOrDefault().PlannedDate;
                    data.TedaviBitisTarihi = orderedList.LastOrDefault().PlannedDate;
                }
            }

            return data;
        }
    }

    [Serializable]
    public class FTRReportParameters
    {
        [DataMember]
        public Guid ObjectID { get; set; } //PhysiotherapyRequest'nin ObjectIDsi

    }

    [Serializable]
    public class FTRReportData
    {
        [DataMember]
        public string HastahaneAdi { get; set; }

        [DataMember]
        public string TCKimlikNo { get; set; }
        [DataMember]
        public string AdSoyad { get; set; }
        [DataMember]
        public string PoliklinikAdi { get; set; }
        [DataMember]
        public DateTime? TedaviBaslangicTarihi { get; set; }
        [DataMember]
        public DateTime? TedaviBitisTarihi { get; set; }
        [DataMember]
        public DateTime? Tarih { get; set; }
    }
}
