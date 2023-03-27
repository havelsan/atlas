using Newtonsoft.Json;
using ReportClasses.ReportUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using TTInstanceManagement;
using TTObjectClasses;
using TTUtils;

namespace AtlasDataSource.Controllers
{
    public class InvoicedProceduresReport
    {
        public static InvoicedProceduresReportData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<InvoicedProceduresReportData>(parameters, "GetInvoicedProceduresReport");
        }

        public static InvoicedProceduresReportData GetInvoicedProceduresReport(string parameters)
        {
            InvoicedProceduresReportData data = new InvoicedProceduresReportData();

            if (!string.IsNullOrWhiteSpace(parameters))
            {
                var param = JsonConvert.DeserializeObject<InvoicedProceduresReportParamters>(parameters.ToString());

                // Tarih tipindeki alanlar 3 saat geri geliyor GMT, düzeltilene kadar tarihlere 3 saat ekledim. 
                // İleride bu sorun düzelince aşağıdaki 2 satır kaldırılacak.
                param.StartDate = param.StartDate.AddHours(3);
                param.EndDate = param.EndDate.AddHours(3);

                int type = 0;
                int typeControl = 0;
                if (param.PayerType.HasValue)
                {
                    type = param.PayerType.Value;
                    typeControl = 1;
                }

                // Gün bazında bakıldığı için başlangıç tarihinin saati "00:00:00", bitiş tarihinin saati "23:59:59" olarak değiştirilir
                data.StartDate = param.StartDate.Date;
                data.EndDate = param.EndDate.Date.AddDays(1).AddSeconds(-1);

                var result = AccountTransaction.InvoicedProceduresReportQuery(data.StartDate, data.EndDate, type, typeControl);

                foreach (var item in result)
                {
                    PayerType payerType = data.PayerTypes.FirstOrDefault(x => x.Name.Equals(item.Payertype.ToString().ToUpper()));
                    if (payerType == null)
                        payerType = data.AddPayerType(item.Payertype.ToString().ToUpper());

                    string day = (decimal)item.Day < 10 ? "0" + item.Day.ToString() : item.Day.ToString();
                    string month = (decimal)item.Month < 10 ? "0" + item.Month.ToString() : item.Month.ToString();
                    string year = item.Year.ToString();
                    string date = day + "." + month + "." + year;

                    payerType.AddProcedure(item.Medulaproceduretype.ToString(), item.Code, item.Name, date, item.Amount.ToString(), item.Price.ToString());
                }
            }

            return data;
        }

        [Serializable]
        public class InvoicedProceduresReportParamters
        {
            [DataMember]
            public DateTime StartDate { get; set; }

            [DataMember]
            public DateTime EndDate { get; set; }

            [DataMember]
            public int? PayerType { get; set; }
        }

        [Serializable]
        public class InvoicedProceduresReportData
        {
            [DataMember]
            public DateTime StartDate { get; set; }

            [DataMember]
            public DateTime EndDate { get; set; }

            public List<PayerType> PayerTypes { get; set; }

            public InvoicedProceduresReportData()
            {
                PayerTypes = new List<PayerType>();
            }

            public PayerType AddPayerType(string name)
            {
                PayerType payerType = new PayerType() { Name = name };
                PayerTypes.Add(payerType);
                return payerType;
            }
        }

        [Serializable]
        public class PayerType
        {
            [DataMember]
            public string Name { get; set; }

            public List<Procedure> Procedures { get; set; }

            public PayerType()
            {
                Procedures = new List<Procedure>();
            }

            public Procedure AddProcedure(string medulaType, string code, string name, string date, string amount, string price)
            {
                Procedure procedure = new Procedure()
                {
                    MedulaType = medulaType,
                    Code = code,
                    Name = name,
                    Date = date,
                    Amount = amount,
                    Price = price
                };

                Procedures.Add(procedure);
                return procedure;
            }
        }

        [Serializable]
        public class Procedure
        {
            [DataMember]
            public string MedulaType { get; set; }

            [DataMember]
            public string Code { get; set; }

            [DataMember]
            public string Name { get; set; }

            [DataMember]
            public string Date { get; set; }

            [DataMember]
            public string Amount { get; set; }

            [DataMember]
            public string Price { get; set; }
        }
    }
}
