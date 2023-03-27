using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportClasses.Controllers.ReportModels;
using System.Runtime.Serialization;
using TTObjectClasses;
using System.ComponentModel;
using TTInstanceManagement;
using ReportClasses.ReportUtils;

namespace AtlasDataSource.Modules.Medical.Yatan_Hasta_Rapor
{
    public class HemodiyalizRaporu
    {
        public static HemodiyalizRaporuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<HemodiyalizRaporuData>(parameters, "GetHemodiyalizRaporuData");
        }

        public static HemodiyalizRaporuListesi GetHemodiyalizRaporuData(string parameters)
        {
            var param = Newtonsoft.Json.JsonConvert.DeserializeObject<HemodiyalizRaporuParam>(parameters.ToString());

            HemodiyalizRaporuListesi list = new HemodiyalizRaporuListesi();
            if (parameters != null)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    HemodialysisRequest hemodialysisRequest = objectContext.GetObject<HemodialysisRequest>(param.RequestObjectID);
                    list.HastaAdiSoyadi = hemodialysisRequest.Episode.Patient.Name + " " + hemodialysisRequest.Episode.Patient.Surname;
                    list.KabulNo = hemodialysisRequest.SubEpisode.ProtocolNo;
                    list.KabulTarihi = hemodialysisRequest.SubEpisode.OpeningDate;
                    list.HemodiyalizİstekTarihi = hemodialysisRequest.HemodialysisRequestDate;
                    list.SorumluDoktor = hemodialysisRequest.ProcedureDoctor.Name;

                    foreach (var detail in hemodialysisRequest.HemodialysisOrderDetail.Where(x => x.CurrentStateDefID != HemodialysisOrderDetail.States.Cancelled))
                    {
                        HemodiyalizRaporuData _data = new HemodiyalizRaporuData();
                        _data.SeansTarihi = detail.SessionDate;
                        _data.Cihaz = detail.TreatmentEquipment.Name;
                        _data.Durum = detail.CurrentStateDef.Name;
                    }
                }
            }
            return list;
        }
    }

    [Serializable]
    public class HemodiyalizRaporuParam
    {
        [DataMember]
        public Guid RequestObjectID { get; set; }

    }


    [Serializable]
    public class HemodiyalizRaporuListesi
    {
        [DataMember]
        public string HastaAdiSoyadi { get; set; }
        [DataMember]
        public string KabulNo { get; set; }
        [DataMember]
        public DateTime? KabulTarihi { get; set; }
        [DataMember]
        public DateTime? HemodiyalizİstekTarihi { get; set; }
        [DataMember]
        public string SorumluDoktor { get; set; }
        [DataMember]
        public string Birim { get; set; }
        [DataMember]
        public List<HemodiyalizRaporuData> HemodiyalizRaporuData { get; set; }
    }

    [Serializable]
    public class HemodiyalizRaporuData
    {
        [DataMember]
        public DateTime? SeansTarihi { get; set; }
        [DataMember]
        public string Cihaz { get; set; }
        [DataMember]
        public string Durum { get; set; }
    }

}


