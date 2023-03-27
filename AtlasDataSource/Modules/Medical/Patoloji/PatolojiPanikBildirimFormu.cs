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
    public class PatolojiPanikBildirimFormu
    {
        public static PatolojiPanikBildirimFormuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<PatolojiPanikBildirimFormuData>(parameters, "GetPatolojiPanikBildirimFormu");
        }
        public static PatolojiPanikBildirimFormuData GetPatolojiPanikBildirimFormu(string parameters)
        {
            PatolojiPanikBildirimFormuData data = new PatolojiPanikBildirimFormuData();
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<PatolojiPanikBildirimParameters>(parameters.ToString());
                using (var objectContext = new TTObjectContext(false))
                {
                    PathologyPanicAlert panicAlert = objectContext.GetObject<PathologyPanicAlert>(param.ObjectID);
                    Pathology pathology = panicAlert.Pathology[0];
                    SubEpisode subEpisode = pathology.SubEpisode;
                    Patient patient = subEpisode.Episode.Patient;
                    data.HastaAdiSoyadi = patient.Name + " " + patient.Surname;
                    data.HastaKabulNo = subEpisode.ProtocolNo;
                    data.PatolojiProtokolNo = pathology.MatPrtNoString;
                    data.Birimi = subEpisode.StarterEpisodeAction.MasterResource.Name;
                    data.PanikBildirimSebebi = panicAlert.PathologyPanicReason.ReasonName;
                    data.BildirimiYapanDoktor = pathology.ProcedureDoctor != null ? pathology.ProcedureDoctor.Name : "";
                    data.BildirimYapilanDoktor = pathology.PathologyRequest.RequestDoctor.Name;
                    data.BildirimTarihi = panicAlert.PanicAlertDate;
                }
            }

            return data;
        }
    }
    [Serializable]
    public class PatolojiPanikBildirimParameters
    {
        [DataMember]
        public Guid ObjectID { get; set; } //PathologyPanicAlert'in ObjectIDsi

    }

    [Serializable]
    public class PatolojiPanikBildirimFormuData
    {
        [DataMember]
        public string HastaAdiSoyadi { get; set; }
        [DataMember]
        public string HastaKabulNo { get; set; }
        [DataMember]
        public string PatolojiProtokolNo { get; set; }
        [DataMember]
        public string Birimi { get; set; }
        [DataMember]
        public string PanikBildirimSebebi { get; set; }
        [DataMember]
        public string BildirimiYapanDoktor { get; set; }
        [DataMember]
        public string BildirimYapilanDoktor { get; set; }
        [DataMember]
        public DateTime? BildirimTarihi { get; set; }
    }
}
