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
    public class PcrIzolasyonRaporu
    {
        public static PcrIzolasyonRaporuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<PcrIzolasyonRaporuData>(parameters, "GetPcrIzolasyonRaporuData");
        }

        public static PcrIzolasyonRaporuData GetPcrIzolasyonRaporuData(string parameters)
        {
            PcrIzolasyonRaporuData data = new PcrIzolasyonRaporuData();
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<PcrIzolasyonRaporuParameters>(parameters.ToString());
                using (var objectContext = new TTObjectContext(false))
                {
                    PatientExamination patientExamination = objectContext.GetObject<PatientExamination>(param.PatientExaminationId);
                    data.HastaAdiSoyadi = patientExamination.Episode.Patient.Name + " " + patientExamination.Episode.Patient.Surname;

                    var labreqList = (patientExamination as EpisodeAction).SubactionProcedures[0].SubEpisode.EpisodeActions.Where(c => c.ActionType == ActionTypeEnum.LaboratoryRequest && (c as LaboratoryRequest).MasterAction == patientExamination);
                    foreach (var labre in labreqList.OrderBy(c=>c.RequestDate))
                    {
                        if (labre.SubactionProcedures.Where(c => c.ProcedureObject.Code == "901260").Count() > 0)
                        {
                            data.BaslangicTarihi = labre.RequestDate.Value.ToString("MM/dd/yyyy HH:mm");
                            data.IzolasyonTarihi = labre.RequestDate.Value.AddHours(4).ToString("MM/dd/yyyy HH:mm");
                            data.BitisTarihi= labre.RequestDate.Value.AddDays(20).ToString("MM/dd/yyyy HH:mm");
                        }
                    }
                }
            }

            return data;
        }

    }


    [Serializable]
    public class PcrIzolasyonRaporuParameters
    {
        [DataMember]
        public Guid PatientExaminationId { get; set; }
    }

    [Serializable]
    public class PcrIzolasyonRaporuData
    {
        [DataMember]
        public string HastaAdiSoyadi { get; set; }
        [DataMember]
        public string IzolasyonTarihi { get; set; }
        [DataMember]
        public string BaslangicTarihi { get; set; }
        [DataMember]
        public string BitisTarihi { get; set; }
    }
}
