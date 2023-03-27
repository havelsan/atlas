using AtlasDataModel;
using AtlasDataModel.Configurations;
using DevExpress.Charts.Model;
using ReportClasses.ReportUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using TTObjectClasses;

namespace AtlasDataSource.Modules.Invoice
{
    public class ReceiptPaymentStatReport
    {
        public static ReceiptPaymentStatReportData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<ReceiptPaymentStatReportData>(parameters, "GetReceiptPaymentStatReport");
        }

        public static ReceiptPaymentStatReportData GetReceiptPaymentStatReport(string parameters)
        {
            if (!string.IsNullOrEmpty(parameters))
            {
                ReceiptPaymentStatReportData data = new ReceiptPaymentStatReportData();
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<ReceiptPaymentStatReportParameters>(parameters.ToString());

                param.StartDate = param.StartDate.AddHours(3);
                param.EndDate = param.EndDate.AddHours(3);

                Guid? type = null;
                int typeControl = 0;
                if (param.Payer.HasValue && param.Payer.Value != Guid.Empty)
                {
                    type = param.Payer.Value;
                    typeControl = 1;
                }
                else
                    type = Guid.Empty;

                data.StartDate = param.StartDate;
                data.EndDate = param.EndDate;

                var queryResult = TTObjectClasses.ReceiptDocument.ReceiptPaymentStatQuery(param.StartDate, param.EndDate, type.Value, typeControl);
                
                data.ReceiptPaymentStats = queryResult.Select(x => new ReceiptPaymentStat
                {
                    Adsoyad = x.Adsoyad != null ? x.Adsoyad.ToString() : string.Empty,
                    Kabulno = x.Kabulno,
                    Makbuzno = x.Makbuzno,
                    Odemetarihi = x.Odemetarihi,
                    Tutar = x.Tutar,
                    Uyruk = x.Ulke,
                    Kurumadi = string.IsNullOrEmpty(x.Kurumadi) == false ? x.Kurumadi.ToUpper() : string.Empty                    
                }).ToList();

                return data;
            }
            else
                return null;
        }

        [Serializable]
        public class ReceiptPaymentStatReportData
        {
            [DataMember]
            public List<ReceiptPaymentStat> ReceiptPaymentStats { get; set; }
            [DataMember]
            public DateTime StartDate { get; set; }

            [DataMember]
            public DateTime EndDate { get; set; }
        }

        [Serializable]
        public class ReceiptPaymentStat
        {
            [DataMember]
            public string Kabulno { get; set; }
            [DataMember]
            public string Adsoyad { get; set; }
            [DataMember]
            public string Uyruk { get; set; }
            [DataMember]
            public string Makbuzno { get; set; }
            [DataMember]
            public double? Tutar { get; set; }
            [DataMember]
            public DateTime? Odemetarihi { get; set; }
            [DataMember]
            public string Kurumadi { get; set; }
        }


        [Serializable]
        public class ReceiptPaymentStatReportParameters
        {
            [DataMember]
            public Guid? Payer { get; set; }
            [DataMember]
            public DateTime StartDate { get; set; }
            [DataMember]
            public DateTime EndDate { get; set; }
        }
    }
}
