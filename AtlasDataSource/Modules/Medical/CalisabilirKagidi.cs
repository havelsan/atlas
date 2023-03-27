using ReportClasses.ReportUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;
using TTObjectClasses;

namespace AtlasDataSource.Modules.Medical
{
    public class CalisabilirKagidi
    {
        public static CalisabilirKagidiData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<CalisabilirKagidiData>(parameters, "GetCalisabilirKagidiData");
        }

        public static CalisabilirKagidiData GetCalisabilirKagidiData(string parameters)
        {
            CalisabilirKagidiData data = new CalisabilirKagidiData();
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<CalisabilirKagidiParameters>(parameters.ToString());
                var workDate = Convert.ToDateTime(param.WorkDate);
                var leaveDate = Convert.ToDateTime(param.LeaveDate);
                using (var objectContext = new TTObjectContext(false))
                {

                    SubEpisode subEpisode = objectContext.GetObject<SubEpisode>(param.SubEpisodeID);
                    if (subEpisode.Diagnosis.Count > 0)
                    {
                        data.GeldigiTarihSaat = subEpisode.OpeningDate.Value.ToString("dd.MM.yyyy - HH:mm");
                        data.AyrildigiTarihSaat = param.LeaveDate != null ? leaveDate.ToString("dd.MM.yyyy - HH:mm") : Common.RecTime().ToString("dd.MM.yyyy HH:mm");
                        data.CalisabilecegiTarih = param.WorkDate != null ? workDate.ToString("dd.MM.yyyy") : Common.RecTime().ToString("dd.MM.yyyy");
                        data.HastaAdiSoyadi = subEpisode.Episode.Patient.Name + " " + subEpisode.Episode.Patient.Surname + "   (TC:" + subEpisode.Episode.Patient.UniqueRefNo + ")";
                        data.Kurum = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                        var hasRadiology = subEpisode.SubActionProcedures.Where(t => (t.ProcedureObject is RadiologyTestDefinition || t.ProcedureObject is LaboratoryTestDefinition)).Count() > 0 ? true : false;
                        data.Not = hasRadiology == true ? "NOT: Hastanın Devam Eden Tetkikleri Vardır" : "";
                        data.YapilanIslemler = "Hasta muayene edildi.";
                    }
                    else
                    {
                        throw new Exception("Hasta üzerine tanı kaydedilmeden bu rapor alınamaz!");
                    }


                }
            }

            return data;
        }

    }


    [Serializable]
    public class CalisabilirKagidiParameters
    {
        [DataMember]
        public Guid SubEpisodeID { get; set; }
        [DataMember]
        public string LeaveDate { get; set; }
        [DataMember]
        public string WorkDate { get; set; }

    }

    [Serializable]
    public class CalisabilirKagidiData
    {
        [DataMember]
        public string Kurum { get; set; }
        [DataMember]
        public string HastaAdiSoyadi { get; set; }
        [DataMember]
        public string GeldigiTarihSaat { get; set; }
        [DataMember]
        public string AyrildigiTarihSaat { get; set; }
        [DataMember]
        public string CalisabilecegiTarih { get; set; }
        [DataMember]
        public string YapilanIslemler { get; set; }
        [DataMember]
        public string Not { get; set; }
    }
}
