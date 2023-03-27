using Newtonsoft.Json;
using ReportClasses.ReportUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using TTDataDictionary;
using TTInstanceManagement;
using TTObjectClasses;
using TTUtils;

namespace AtlasDataSource.Controllers
{
    public class ReceiptDetailedReport
    {
        public static ReceiptDetailedReportData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<ReceiptDetailedReportData>(parameters, "GetReceiptDetailedReport");
        }

        public static ReceiptDetailedReportData GetReceiptDetailedReport(string parameters)
        {
            int rowCount = 6;
            bool detailFound = false;
            string description = string.Empty;
            bool isHealthTourism = false;

            const string otherDescription = "600.01.99 - Diğer Sağlık Hizmet Gelirleri";
            const string otherDescriptionHealthTourism = "601.01.99 - Diğer Sağlık Hizmet Gelirleri";
            const string BKKPrimBorcuOlanlar = "600.01.94 - Cumhurbaşkanlığı Kararı İle Muaf Tut. Has. Kat. Pay. Gelirler";
            const string PrvAlinanSGKKatılımPayı = "336.06.01 - Provizyon Alınan SGK Katılım Payları";
            const string PrvAlinmayanSGKKatılımPayı = "336.06.02 - Provizyon Alınmayan SGK Katılım Payları";
            const string IlacGelirleri = "600.01.08.01 - İlaç Gelirleri";
            const string SarfMalzemeGelirleri = "600.01.08.02 - Tıbbi Sarf Malzemesi Gelirleri";

            ReceiptDetailedReportData data = new ReceiptDetailedReportData();
            data.detailList = new List<Detail>();
            data.printList = new List<Detail>();

            if (parameters == null)
            {
                //AtlasDev veri tabanından alınmış test objectidsi
                var testParam = new ReceiptDetailedReportParamters() { RECEIPTOBJECTID = new Guid("2a17025a-da51-4b38-8319-0c2a7e57446e") };
                parameters = JsonConvert.SerializeObject(testParam);
            }
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<ReceiptDetailedReportParamters>(parameters.ToString());
                using (TTObjectContext objectContext = new TTObjectContext(true))
                {
                    Receipt.ReceiptReportQuery_Class receiptReportQueryResult = Receipt.ReceiptReportQuery(param.RECEIPTOBJECTID.ToString())[0];
                    if (param.RECEIPTOBJECTID == Guid.Empty)
                        param.RECEIPTOBJECTID = new Guid("287e4f06-8a7f-4f6f-89c3-821e311f9723");
                    data.Adres = receiptReportQueryResult.HomeAddress;

                    if (!string.IsNullOrEmpty(receiptReportQueryResult.Hometown))
                    {
                        if (!string.IsNullOrEmpty(receiptReportQueryResult.HomeAddress))
                            data.Adres += " ";

                        data.Adres += receiptReportQueryResult.Hometown;
                    }

                    if (!string.IsNullOrEmpty(receiptReportQueryResult.Homecity))
                    {
                        if (!string.IsNullOrEmpty(receiptReportQueryResult.Hometown))
                            data.Adres += "/";

                        data.Adres += " " + receiptReportQueryResult.Homecity;
                    }

                    data.MakbuzNo = AccountDocument.ReceiptDocumentNo(receiptReportQueryResult.DocumentNo);
                    data.HastaAdi = receiptReportQueryResult.Patientname.ToString();
                    data.MakbuzAltAciklama = SystemParameter.GetParameterValue("MAKBUZALTACIKLAMA", "");
                    data.MakbuzTarihi = receiptReportQueryResult.DocumentDate;
                    data.MakbuzUstAciklama = SystemParameter.GetParameterValue("MAKBUZUSTACIKLAMA", "");
                    data.MutemetlikAdi = SystemParameter.GetParameterValue("RECEIPTREPORTACCOUNTOFFICENAME", "");
                    if (SystemParameter.GetParameterValue("RECEIPTREPORTSHOWSPECIALNO", "FALSE") == "TRUE")
                    {
                        data.SpecialNo = receiptReportQueryResult.SpecialNo;
                    }
                    data.TCNo = receiptReportQueryResult.UniqueRefNo;
                    CurrencyTypeDefinition currencyType = null;
                    if (receiptReportQueryResult.Dailyratecurrencytype.HasValue)
                        currencyType = objectContext.GetObject<CurrencyTypeDefinition>(receiptReportQueryResult.Dailyratecurrencytype.Value);

                    if (currencyType == null)
                        currencyType = objectContext.QueryObjects<CurrencyTypeDefinition>("QREF = 'TL'")[0];

                    double? toplamFiyat = receiptReportQueryResult.ConvertedTotalPayment;
                    data.ToplamFiyat = toplamFiyat + " " + currencyType.LeftSymbol;
                    data.ToplamFiyatYazi = ReportHelper.Yaziyla(toplamFiyat.Value, currencyType.LeftSymbol, currencyType.RightSymbol);
                    data.VezneGorevlisi = receiptReportQueryResult.Cashiername;
                    if (receiptReportQueryResult.DailyRateDefinition != null && receiptReportQueryResult.DailyRateDefinition.Value != Guid.Empty && currencyType.Qref != "TL")
                        data.Kur = "1 " + currencyType.LeftSymbol + "=" + objectContext.GetObject<DailyRateDefinition>(receiptReportQueryResult.DailyRateDefinition.Value).DailyRate.Value.ToString() + " TL";
                    Receipt receipt = objectContext.GetObject<Receipt>(param.RECEIPTOBJECTID);
                    data.OdemeTuru = Common.GetDescriptionOfDataTypeEnumV2("PaymentTypeEnum", (int)receipt.ReceiptDocument.PaymentType);
                    foreach (ReceiptDocumentGroup recGroup in receipt.ReceiptDocument.ReceiptDocumentGroups)
                    {
                        foreach (ReceiptDocumentDetail receiptDetail in recGroup.ReceiptDocumentDetails)
                        {
                            description = otherDescription;
                            AccountTransaction accTrx = receiptDetail.AccountTrxDocument[0].AccountTransaction;

                            PayerTypeEnum payerType = accTrx.SubEpisodeProtocol.Payer.Type.PayerType.Value;

                            if (accTrx.SubActionProcedure != null && accTrx.SubActionProcedure.ProcedureObject != null)
                            {   // SGK lı hastadan alınmış katılım payı ise
                                if ((payerType == PayerTypeEnum.SGK || payerType == PayerTypeEnum.SGKManual) && (receiptDetail.IsParticipationShare == true || accTrx.SubActionProcedure.ProcedureObject.ParticipationProcedure == true))
                                {
                                    if (!string.IsNullOrEmpty(accTrx.SubEpisodeProtocol.MedulaTakipNo)) // Takip numarası var ise Provizyon Alınan SGK Katılım payı olarak gelir
                                    {
                                        if (accTrx.SubEpisodeProtocol?.MedulaIstisnaiHal?.Kodu == "9")  // BKK Prim borçlu ise hesap 600.01.94 olmalı
                                            description = BKKPrimBorcuOlanlar;
                                        else
                                            description = PrvAlinanSGKKatılımPayı;
                                    }
                                    else
                                        description = PrvAlinmayanSGKKatılımPayı;
                                }
                                else
                                {
                                    RevenueSubAccountCodeDefinition revenue = accTrx.SubActionProcedure.ProcedureObject.GetRevenueSubAccountCode();
                                    if (revenue != null)
                                    {
                                        string accountCode = revenue.AccountCode;
                                        string accountDescription = revenue.Description;

                                        if (accountCode.Equals("600.01.01") || accountCode.Equals("600.01.02") || accountCode.Equals("600.01.03") || accountCode.Equals("600.01.04") || accountCode.Equals("600.01.05"))
                                        {
                                            if (accTrx.SubEpisodeProtocol.MedulaTedaviTuru.tedaviTuruKodu.Equals("A"))
                                            {
                                                accountCode += ".01";
                                                accountDescription = "Ayaktan Hasta " + accountDescription;
                                            }
                                            else
                                            {
                                                accountCode += ".02";
                                                accountDescription = "Yatan Hasta " + accountDescription;
                                            }
                                        }
                                        else if (accountCode.Equals("600.01.06") || accountCode.Equals("600.01.07"))
                                        {
                                            accountCode += ".01";
                                            accountDescription = "Yatan Hasta " + accountDescription;
                                        }

                                        description = accountCode + " - " + accountDescription;
                                    }
                                }
                            }
                            else if (accTrx.SubActionMaterial != null)
                            {
                                if ((payerType == PayerTypeEnum.SGK || payerType == PayerTypeEnum.SGKManual) && receiptDetail.IsParticipationShare == true)
                                {
                                    if (!string.IsNullOrEmpty(accTrx.SubEpisodeProtocol.MedulaTakipNo)) // Takip numarası var ise Provizyon Alınan SGK Katılım payı olarak gelir
                                    {
                                        if (accTrx.SubEpisodeProtocol?.MedulaIstisnaiHal?.Kodu == "9")  // BKK Prim borçlu ise hesap 600.01.94 olmalı
                                            description = BKKPrimBorcuOlanlar;
                                        else
                                            description = PrvAlinanSGKKatılımPayı;
                                    }
                                    else
                                        description = PrvAlinmayanSGKKatılımPayı;
                                }
                                else if (accTrx.SubActionMaterial.Material is DrugDefinition || accTrx.SubActionMaterial.Material is MagistralPreparationDefinition)
                                    description = IlacGelirleri;
                                else
                                    description = SarfMalzemeGelirleri;
                            }

                            // Kurum Sağlık Turizmi ise
                            if (accTrx.SubEpisodeProtocol.Payer.HealthTourism == true)
                            {
                                if (description.StartsWith("600.") && description != BKKPrimBorcuOlanlar)  // Sağlık Turizmi için hesap kodunun başı 601 olarak değiştirilir
                                    description = "601." + description.Substring(4, description.Length - 4);

                                isHealthTourism = true; // Makbuzdaki hizmetlerden birinin kurumu Sağlık Turizmi ise tüm makbuz o şekilde değerlendirilir
                            }

                            detailFound = false;
                            foreach (Detail detail in data.detailList)
                            {
                                if (detail.Description.Equals(description))
                                {
                                    detail.Price += receiptDetail.PaymentPrice.Value;
                                    detailFound = true;
                                    break;
                                }
                            }

                            if (!detailFound)
                            {
                                int orderNo = data.detailList.Count;

                                if (description.Equals(otherDescription) || description.Equals(otherDescriptionHealthTourism))
                                    orderNo = int.MaxValue;

                                data.detailList.Add(new Detail(orderNo, description, receiptDetail.PaymentPrice.Value));
                            }
                        }
                    }

                    data.detailList = data.detailList.OrderBy(x => x.OrderNo).ToList();
                    data.HizmetListesi = "";
                    data.Fiyatlar = "";

                    if (data.detailList.Count > rowCount)
                    {
                        foreach (Detail detail in data.detailList)
                        {
                            if (data.printList.Count < rowCount - 1)
                            {
                                data.printList.Add(detail);
                                data.HizmetListesi += detail.Description + Environment.NewLine;
                                data.Fiyatlar += detail.Price + " " + currencyType.LeftSymbol + Environment.NewLine;
                            }
                            else
                            {
                                // "600.01.99 / 601.01.99 - Diğer Sağlık Hizmet Gelirleri" grubu eklenir
                                if (data.printList.Count == rowCount - 1)
                                {
                                    string otherDesc = otherDescription;
                                    if (isHealthTourism)
                                        otherDesc = otherDescriptionHealthTourism;

                                    data.printList.Add(new Detail(rowCount - 1, otherDesc, 0));
                                    data.HizmetListesi += otherDesc;
                                }

                                // Eklenen "600.01.99 / 601.01.99 - Diğer Sağlık Hizmet Gelirleri" grubunun tutarı artırılır
                                data.printList[rowCount - 1].Price += detail.Price;
                            }
                        }
                        if (data.printList.Count == 6)
                        {
                            data.Fiyatlar += data.printList[rowCount - 1].Price + "TL";
                        }
                    }
                    else
                    {
                        data.printList = data.detailList;
                        //En uzun string'i bulur.
                        //var longest = data.detailList.Aggregate(description, (max, cur) => max.Length > cur.Description.Length ? max : cur.Description);

                        foreach (Detail detail in data.detailList)
                        {
                            data.HizmetListesi += detail.Description + Environment.NewLine;
                            data.Fiyatlar += detail.Price + "TL" + Environment.NewLine;
                        }
                    }
                }
            }
            return data;
        }

        [Serializable]
        public class ReceiptDetailedReportParamters
        {
            [DataMember]
            public Guid RECEIPTOBJECTID { get; set; } //ForensicMedicalReport'un ObjectIDsi
        }

        [Serializable]
        public class ReceiptDetailedReportData
        {
            [DataMember]
            public List<Detail> printList { get; set; }
            [DataMember]
            public string HizmetListesi { get; set; }
            [DataMember]
            public string Fiyatlar { get; set; }
            [DataMember]
            public List<Detail> detailList { get; set; }
            /// <summary>
            /// Sistem parametresi MAKBUZUSTACIKLAMA
            /// </summary>
            [DataMember]
            public string MakbuzUstAciklama { get; set; }
            [DataMember]
            public string MakbuzNo { get; set; }
            [DataMember]
            public long? SpecialNo { get; set; }
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
            public long? TCNo { get; set; }
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
            public string ToplamFiyatYazi { get; set; } = string.Empty;
            [DataMember]
            public string ToplamFiyat { get; set; } = null;
            [DataMember]
            public string Kur { get; set; }
            public string OdemeTuru { get; set; }
        }

        [Serializable]
        public class Detail
        {
            [DataMember]
            public int OrderNo { get; set; }

            [DataMember]
            public string Description { get; set; }

            [DataMember]
            public double Price { get; set; }

            public Detail()
            {
            }

            public Detail(int orderNo, string description, Currency price)
            {
                OrderNo = orderNo;
                Description = description;
                Price = price;
            }
        }
    }
}
