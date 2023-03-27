using Newtonsoft.Json;
using ReportClasses.ReportUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using TTDataDictionary;
using TTInstanceManagement;
using TTObjectClasses;
using TTUtils;

namespace AtlasDataSource.Controllers
{
    public class PriceChangedAccTrxsReport
    {
        public static PriceChangedAccTrxsReportData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<PriceChangedAccTrxsReportData>(parameters, "GetPriceChangedAccTrxsReport");
        }

        public static PriceChangedAccTrxsReportData GetPriceChangedAccTrxsReport(string parameters)
        {
            PriceChangedAccTrxsReportData data = new PriceChangedAccTrxsReportData();
            data.detailList = new List<Detail>();

            if (!string.IsNullOrWhiteSpace(parameters))
            {
                TTObjectContext objectContext = new TTObjectContext(true);
                var param = JsonConvert.DeserializeObject<PriceChangedAccTrxsReportParamters>(parameters.ToString());

                // Tarih tipindeki alanlar 3 saat geri geliyor GMT, düzeltilene kadar tarihlere 3 saat ekledim. 
                // İleride bu sorun düzelince aşağıdaki blok kaldırılacak.
                var properties = param.InvoiceSEPSearchCriteria.GetType().GetProperties();
                foreach (var property in properties)
                {
                    if ((property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?)) &&
                        property.GetValue(param.InvoiceSEPSearchCriteria, null) != null)
                        property.SetValue(param.InvoiceSEPSearchCriteria, ((DateTime)property.GetValue(param.InvoiceSEPSearchCriteria, null)).AddHours(3).Date, null);
                }

                // Tarih Aralığı
                if (param.InvoiceSEPSearchCriteria.episodeStartDate.HasValue)
                    data.DateInterval += param.InvoiceSEPSearchCriteria.episodeStartDate.Value.ToString("dd.MM.yyyy");

                data.DateInterval += " - ";

                if (param.InvoiceSEPSearchCriteria.episodeEndDate.HasValue)
                    data.DateInterval += param.InvoiceSEPSearchCriteria.episodeEndDate.Value.ToString("dd.MM.yyyy");

                // Arama Türü
                if (param.InvoiceSEPSearchCriteria.InvoiceSearchType.HasValue)
                    data.PayerType = Common.GetDisplayTextOfEnumValue("PayerTypeEnum", param.InvoiceSEPSearchCriteria.InvoiceSearchType.Value);

                StringBuilder sb = SubEpisodeProtocol.InvoiceSEPSearchFilter(param.InvoiceSEPSearchCriteria, objectContext);

                int APRType = 1;
                if (param.InvoiceSEPSearchCriteria.InvoiceSearchType == (int)PayerTypeEnum.Paid)
                    APRType = (int)APRTypeEnum.PATIENT;

                List<Guid> SEPObjectIdList = new List<Guid>();
                BindingList<SubEpisodeProtocol.GetSEPByInjection_Class> sepList = SubEpisodeProtocol.GetSEPByInjection(objectContext, APRType, " AND " + sb.ToString());

                foreach (SubEpisodeProtocol.GetSEPByInjection_Class item in sepList)
                    SEPObjectIdList.Add(item.ObjectID.Value);

                if (SEPObjectIdList.Count > 0)
                {
                    // InvoiceLogs 
                    string filterExpression = Common.CreateFilterExpressionOfGuidList(" AND OPERATIONTYPE = 43", "ACCOUNTTRANSACTION.SUBEPISODEPROTOCOL", SEPObjectIdList);
                    int orderNo = 1;
                    BindingList<InvoiceLog.GetAccTrxLogs_Class> logList = InvoiceLog.GetAccTrxLogs(filterExpression);

                    foreach (InvoiceLog.GetAccTrxLogs_Class log in logList)
                    {
                        Detail detail = new Detail()
                        {
                            OrderNo = orderNo,
                            LogDate = log.Logdate,
                            UserName = log.Username,
                            PatientUniqueRefNo = log.Patientuniquerefno,
                            PatientName = log.Patientname.ToString(),
                            ProtocolNo = log.ProtocolNo,
                            AccTrxId = log.Acctrxid,
                            AccTrxCodeName = log.Acctrxcodename.ToString(),
                            AccTrxType = log.Acctrxtype.HasValue ? Common.GetDisplayTextOfDataTypeEnum(log.Acctrxtype.Value) : string.Empty,
                            OldValue = log.OldValue,
                            NewValue = log.NewValue
                        };

                        data.detailList.Add(detail);
                        orderNo++;
                    }
                }

                objectContext.Dispose();
            }
            return data;
        }

        [Serializable]
        public class PriceChangedAccTrxsReportParamters
        {
            [DataMember]
            public SubEpisodeProtocol.InvoiceSEPSearchCriteria InvoiceSEPSearchCriteria { get; set; }
        }

        [Serializable]
        public class PriceChangedAccTrxsReportData
        {
            [DataMember]
            public string DateInterval { get; set; }

            [DataMember]
            public string PayerType { get; set; }

            [DataMember]
            public List<Detail> detailList { get; set; }
        }

        [Serializable]
        public class Detail
        {
            [DataMember]
            public int OrderNo { get; set; }

            [DataMember]
            public DateTime? LogDate { get; set; }

            [DataMember]
            public string UserName { get; set; }

            [DataMember]
            public long? PatientUniqueRefNo { get; set; }

            [DataMember]
            public string PatientName { get; set; }

            [DataMember]
            public string ProtocolNo { get; set; }

            [DataMember]
            public long? AccTrxId { get; set; }

            [DataMember]
            public string AccTrxCodeName { get; set; }

            [DataMember]
            public string AccTrxType { get; set; }

            [DataMember]
            public string OldValue { get; set; }

            [DataMember]
            public string NewValue { get; set; }

            public Detail()
            {
            }
        }
    }
}
