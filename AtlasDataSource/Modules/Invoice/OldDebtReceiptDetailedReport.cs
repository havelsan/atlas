using Newtonsoft.Json;
using ReportClasses.ReportUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using TTInstanceManagement;
using TTObjectClasses;
using TTUtils;

namespace AtlasDataSource.Modules.Invoice
{
    public class OldDebtReceiptDetailedReport
    {
        public static OldDebtReceiptDetailedReportData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<OldDebtReceiptDetailedReportData>(parameters, "GetOldDebtReceiptDetailedReport");
        }

        public static OldDebtReceiptDetailedReportData GetOldDebtReceiptDetailedReport(string parameters)
        {
            OldDebtReceiptDetailedReportData data = new OldDebtReceiptDetailedReportData();

            if (parameters == null)
            {
                //AtlasDev veri tabanından alınmış test objectidsi
                var testParam = new OldDebtReceiptDetailedReportParamters() { PATIENTOBJECTID = new Guid("9a80070b-9919-476b-b151-fa5673167a37") };
                parameters = JsonConvert.SerializeObject(testParam);
            }
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<OldDebtReceiptDetailedReportParamters>(parameters.ToString());

                using (TTObjectContext context = new TTObjectContext(true))
                {
                    PatientOldDebt.OldDebtReceiptReportQuery_Class queryResult = PatientOldDebt.OldDebtReceiptReportQuery(param.PATIENTOBJECTID)[0];

                    List<PatientOldDebt> oldDebts = (List<PatientOldDebt>)context.QueryObjects<PatientOldDebt>("PATIENT = '" + param.PATIENTOBJECTID + "'").ToList();

                    data.MakbuzNo = AccountDocument.ReceiptDocumentNo(queryResult.DocumentNo);
                    data.MakbuzAltAciklama = SystemParameter.GetParameterValue("MAKBUZALTACIKLAMA", "");
                    data.MakbuzTarihi = queryResult.DocumentDate;
                    data.MakbuzUstAciklama = SystemParameter.GetParameterValue("MAKBUZUSTACIKLAMA", "");
                    data.MutemetlikAdi = SystemParameter.GetParameterValue("RECEIPTREPORTACCOUNTOFFICENAME", "");

                    data.VezneGorevlisi = queryResult.Cashiername;
                    data.HastaAdi = queryResult.Payeename.ToString();
                    data.Adres = queryResult.HomeAddress;
                    data.TCNo = queryResult.Uniquerefno;
                    data.ToplamFiyat = queryResult.Totalpayment.Value;
                    data.ToplamFiyatYazi = ReportHelper.Yaziyla(data.ToplamFiyat.Value);
                    data.Hizmet = "600.01.99 - Diğer Sağlık Hizmet Gelirleri";
                    data.HizmetFiyati = oldDebts[0].OldDebtReceiptDocument.TotalPrice.ToString();

                }
            }

            return data;
        }


    }

    [Serializable]
    public class OldDebtReceiptDetailedReportData
    {
        [DataMember]
        public string Hizmet { get; set; }
        [DataMember]
        public string HizmetFiyati { get; set; }
        /// <summary>
        /// Sistem parametresi MAKBUZUSTACIKLAMA
        /// </summary>
        [DataMember]
        public string MakbuzUstAciklama { get; set; }
        [DataMember]
        public string MakbuzNo { get; set; }
        /// <summary>
        /// Sistem parametresi RECEIPTREPORTACCOUNTOFFICENAME
        /// </summary>
        [DataMember]
        public string MutemetlikAdi { get; set; }
        [DataMember]
        public string HastaAdi { get; set; }
        /// <summary>
        /// UniqueRefNo
        /// </summary>
        [DataMember]
        public string TCNo { get; set; }
        [DataMember]
        public string Adres { get; set; }
        /// <summary>
        /// DocumentDate
        /// </summary>
        [DataMember]
        public DateTime? MakbuzTarihi { get; set; }
        /// <summary>
        /// CashierName
        /// </summary>
        [DataMember]
        public string VezneGorevlisi { get; set; }
        /// <summary>
        /// Sistem Parametresi MAKBUZALTACIKLAMA
        /// </summary>
        [DataMember]
        public string MakbuzAltAciklama { get; set; }
        /// <summary>
        /// Toplam Fiyatın yazı hali
        /// </summary>
        [DataMember]
        public string ToplamFiyatYazi { get; set; }
        [DataMember]
        public double? ToplamFiyat { get; set; }
    }

    [Serializable]
    public class OldDebtReceiptDetailedReportParamters
    {
        [DataMember]
        public Guid PATIENTOBJECTID { get; set; } //ForensicMedicalReport'un ObjectIDsi
    }
}
