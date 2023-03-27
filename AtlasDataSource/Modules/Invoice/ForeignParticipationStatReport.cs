using AtlasModel;
using DevExpress.Entity.Model.Metadata;
using ReportClasses.ReportUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using TTDataDictionary;
using TTObjectClasses;

namespace AtlasDataSource.Modules.Invoice
{
    public class ForeignParticipationStatReport
    {
        public static ForeignParticipationStatReportData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<ForeignParticipationStatReportData>(parameters, "GetForeignParticipationStatReport");
        }

        public static ForeignParticipationStatReportData GetForeignParticipationStatReport(string parameters)
        {
            if (!string.IsNullOrEmpty(parameters))
            {
                ForeignParticipationStatReportData data = new ForeignParticipationStatReportData();
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<ForeignParticipationStatReportParameters>(parameters.ToString());

                param.StartDate = param.StartDate.AddHours(3);
                param.EndDate = param.EndDate.AddHours(3);

                data.StartDate = param.StartDate;
                data.EndDate = param.EndDate;


                var queryResult = TTObjectClasses.AccountTransaction.ForeignParticipationStatQuery(param.StartDate, param.EndDate);
                data.PaticipationStats = queryResult.Select(x => new PaticipationStat
                {
                    Hastaadi = x.Hastaadi,
                    Hastasoyadi = x.Hastasoyadi,
                    Hastatcno = x.Hastatcno,
                    Kabulno = x.Kabulno,
                    Kabultarihi = x.Kabultarihi,
                    Makbuzno = x.Makbuzno,
                    Odemetutari = x.Odemetutari
                }).ToList();

                return data;
            }
            else
                return null;
        }


        [Serializable]
        public class ForeignParticipationStatReportData
        {
            [DataMember]
            public List<PaticipationStat> PaticipationStats { get; set; }
            [DataMember]
            public DateTime StartDate { get; set; }

            [DataMember]
            public DateTime EndDate { get; set; }
        }

        [Serializable]
        public class PaticipationStat
        {

            [DataMember]
            public long? Hastatcno { get; set; }
            [DataMember]
            public string Hastaadi { get; set; }
            [DataMember]
            public string Hastasoyadi { get; set; }
            [DataMember]
            public string Kabulno { get; set; }
            [DataMember]
            public DateTime? Kabultarihi { get; set; }
            [DataMember]
            public string Makbuzno { get; set; }
            [DataMember]
            public double? Odemetutari { get; set; }
        }

        [Serializable]
        public class ForeignParticipationStatReportParameters
        {
            [DataMember]
            public DateTime StartDate { get; set; }
            [DataMember]
            public DateTime EndDate { get; set; }
        }
    }
}
