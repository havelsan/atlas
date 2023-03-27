using Newtonsoft.Json;
using ReportClasses.ReportUtils;
using System;
using System.Runtime.Serialization;
using TTInstanceManagement;
using TTObjectClasses;
using TTUtils;

namespace AtlasDataSource.Modules.Invoice
{
    public class CashOfficeReceiptDocumentReport
    {
        public static CashOfficeReceiptDocumentReportData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<CashOfficeReceiptDocumentReportData>(parameters, "GetCashOfficeReceiptDocumentReport");
        }

        public static CashOfficeReceiptDocumentReportData GetCashOfficeReceiptDocumentReport(string parameters)
        {
            CashOfficeReceiptDocumentReportData data = new CashOfficeReceiptDocumentReportData();
            if (parameters == null)
            {
                //AtlasDev veri tabanından alınmış test objectidsi
                var testParam = new CashOfficeReceiptDocumentReporParamters() { MAINCASHOFFICEOPERATIONOBJECTID = new Guid("4487a17d-e6f0-4b6b-9cba-157dbdb675eb") };
                parameters = JsonConvert.SerializeObject(testParam);
            }
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<CashOfficeReceiptDocumentReporParamters>(parameters.ToString());

                using (TTObjectContext objectContext = new TTObjectContext(true))
                {
                    MainCashOfficeOperation.CashOfficeReceiptDocumentReportQuery_Class queryResult = MainCashOfficeOperation.CashOfficeReceiptDocumentReportQuery(param.MAINCASHOFFICEOPERATIONOBJECTID.ToString())[0];

                    data.MakbuzNo = AccountDocument.ReceiptDocumentNo(queryResult.DocumentNo);
                    data.MakbuzAltAciklama = SystemParameter.GetParameterValue("MAKBUZALTACIKLAMA", "");
                    data.MakbuzTarihi = queryResult.DocumentDate;
                    data.MakbuzUstAciklama = SystemParameter.GetParameterValue("MAKBUZUSTACIKLAMA", "");
                    data.MutemetlikAdi = SystemParameter.GetParameterValue("RECEIPTREPORTACCOUNTOFFICENAME", "");

                    data.VezneGorevlisi = queryResult.Cashiername;
                    data.HastaAdi = queryResult.PayeeName.ToString();
                    data.Adres = queryResult.PayeeAddress;
                    data.DigerTahsilatAciklama = queryResult.Description;
                    data.HizmetFiyati = queryResult.TotalPrice.Value.ToString();
                    data.TCNo = queryResult.PayeeUniqueRefNo;
                    data.Hizmet = queryResult.Moneyreceivedtypename.ToString();
                    data.ToplamFiyat = queryResult.TotalPrice.Value;
                    data.ToplamFiyatYazi = ReportHelper.Yaziyla(data.ToplamFiyat.Value);
                }
            }
            return data;
        }
    }

    [Serializable]
    public class CashOfficeReceiptDocumentReportData
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
        public string DigerTahsilatAciklama { get; set; }
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
    public class CashOfficeReceiptDocumentReporParamters
    {
        [DataMember]
        public Guid MAINCASHOFFICEOPERATIONOBJECTID { get; set; } //ForensicMedicalReport'un ObjectIDsi
    }
}
