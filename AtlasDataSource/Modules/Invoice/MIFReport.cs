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
    public class MIFReport
    {
        public static MIFReportData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<MIFReportData>(parameters, "GetMIFReport");
        }

        public static MIFReportData GetMIFReport(string parameters)
        {
            MIFReportData data = new MIFReportData();

            if (!string.IsNullOrWhiteSpace(parameters))
            {
                TTObjectContext objectContext = new TTObjectContext(true);
                var param = JsonConvert.DeserializeObject<MIFReportParamters>(parameters.ToString());

                MIF mif = objectContext.GetObject<MIF>(param.MIFObjectID, false);
                if (mif == null)
                    throw new TTException("Muhasebe İşlem Fişi bulunamadı.");

                string MuhasebeBirim = SystemParameter.GetParameterValue("MUHASEBEBIRIMKODU", "XXXXXX");
                string MuhasebeBirimAdi = SystemParameter.GetParameterValue("MUHASEBEBIRIMADI", "");
                string SaglikTesisi = SystemParameter.GetParameterValue("MIFSAGLIKTESISI", "");
                string KurumAdi = SystemParameter.GetParameterValue("MIFKURUMADI", "");
                string BankaSubeAdi = SystemParameter.GetParameterValue("BANKACCOUNTINFO", "");
                string BankaHesapNo = SystemParameter.GetParameterValue("HOSPITALIBANNO", "");

                if (param.byPayer) // Her kurum için ayrı sayfa
                {
                    List<PayerDefinition> payerList = mif.MIFDetails.Select(x => x.Payer).Distinct().OrderBy(x => x.Name).ToList();
                    foreach (PayerDefinition payer in payerList)
                    {
                        MIFReportPayer mifReportPayer = new MIFReportPayer()
                        {
                            MuhasebeBirim = MuhasebeBirim,
                            MuhasebeBirimAdi = MuhasebeBirimAdi,
                            ButceYili = mif.InvoiceTerm.EndDate.Value.Year.ToString(),
                            Tarihi = mif.InvoiceTerm.EndDate.Value.ToString("dd.MM.yyyy"),
                            SaglikTesisi = SaglikTesisi,
                            KurumAdi = KurumAdi,
                            AdiSoyadiUnvani = payer.Name,
                            VergiKimlikNo = payer.TaxNumber,
                            VergiDairesiNo = payer.TaxOffice,
                            BankaSubeAdi = BankaSubeAdi,
                            BankaHesapNo = BankaHesapNo
                        };

                        data.payerList.Add(mifReportPayer);

                        List<MIFDetail> MIFDetails = mif.MIFDetails.Where(x => x.Payer.ObjectID == payer.ObjectID).OrderBy(x => x.AccountCode).ToList();
                        foreach (MIFDetail mifDetail in MIFDetails)
                        {
                            MIFReportPayerDetail detail = new MIFReportPayerDetail()
                            {
                                HesapNo = mifDetail.AccountCode,
                                HesapAdi = mifDetail.AccountName,
                                BorcTutari = mifDetail.Debt,
                                AlacakTutari = mifDetail.Credit
                            };
                            mifReportPayer.Details.Add(detail);
                        }
                    }
                }
                else // Tüm kurumlar için tek sayfa ve tutarlar toplanır
                {
                    // MİF te tek kurum varsa kurum ile ilgili bilgiler dolsun, birden fazla kurum varsa kurum bilgileri boş kalsın
                    string AdiSoyadiUnvani = string.Empty;
                    string VergiKimlikNo = string.Empty;
                    string VergiDairesiNo = string.Empty;

                    List<PayerDefinition> payerList = mif.MIFDetails.Select(x => x.Payer).Distinct().ToList();
                    if (payerList.Count == 1)
                    {
                        PayerDefinition payer = payerList.First();

                        AdiSoyadiUnvani = payer.Name;
                        VergiKimlikNo = payer.TaxNumber;
                        VergiDairesiNo = payer.TaxOffice;
                    }

                    MIFReportPayer mifReportPayer = new MIFReportPayer()
                    {
                        MuhasebeBirim = MuhasebeBirim,
                        MuhasebeBirimAdi = MuhasebeBirimAdi,
                        ButceYili = mif.InvoiceTerm.EndDate.Value.Year.ToString(),
                        Tarihi = mif.InvoiceTerm.EndDate.Value.ToString("dd.MM.yyyy"),
                        SaglikTesisi = SaglikTesisi,
                        KurumAdi = KurumAdi,
                        AdiSoyadiUnvani = AdiSoyadiUnvani,
                        VergiKimlikNo = VergiKimlikNo,
                        BankaSubeAdi = BankaSubeAdi,
                        BankaHesapNo = BankaHesapNo,
                        VergiDairesiNo = VergiDairesiNo
                    };

                    data.payerList.Add(mifReportPayer);

                    List<MIFDetail> MIFDetails = mif.MIFDetails.OrderBy(x => x.AccountCode).ToList();
                    foreach (MIFDetail mifDetail in MIFDetails)
                    {
                        MIFReportPayerDetail detail = mifReportPayer.Details.FirstOrDefault(x => x.HesapNo == mifDetail.AccountCode);
                        if (detail == null)
                            mifReportPayer.AddDetail(mifDetail.AccountCode, mifDetail.AccountName, mifDetail.Debt, mifDetail.Credit);
                        else
                        {
                            if (mifDetail.Debt.HasValue)
                                detail.BorcTutari += (decimal)mifDetail.Debt;
                            else if (mifDetail.Credit.HasValue)
                                detail.AlacakTutari += (decimal)mifDetail.Credit;
                        }
                    }
                }

                objectContext.Dispose();
            }

            return data;
        }

        [Serializable]
        public class MIFReportParamters
        {
            [DataMember]
            public Guid MIFObjectID { get; set; }
            [DataMember]
            public bool byPayer { get; set; } // Her kurum için ayrı rapor mu alınacak
        }

        [Serializable]
        public class MIFReportData
        {
            public List<MIFReportPayer> payerList { get; set; }

            public MIFReportData()
            {
                payerList = new List<MIFReportPayer>();
            }
        }

        [Serializable]
        public class MIFReportPayer
        {
            [DataMember]
            public string MuhasebeBirim { get; set; }

            [DataMember]
            public string MuhasebeBirimAdi { get; set; }

            [DataMember]
            public string ButceYili { get; set; }

            [DataMember]
            public string Tarihi { get; set; }

            [DataMember]
            public string SaglikTesisi { get; set; }

            [DataMember]
            public string KurumAdi { get; set; }

            [DataMember]
            public string AdiSoyadiUnvani { get; set; }

            [DataMember]
            public string VergiKimlikNo { get; set; }

            [DataMember]
            public string BankaSubeAdi { get; set; }

            [DataMember]
            public string BankaHesapNo { get; set; }

            [DataMember]
            public string VergiDairesiNo { get; set; }

            [DataMember]
            public List<MIFReportPayerDetail> Details { get; set; }

            public MIFReportPayer()
            {
                Details = new List<MIFReportPayerDetail>();
            }

            public MIFReportPayerDetail AddDetail(string hesapNo, string hesapAdi, decimal? borcTutari, decimal? alacakTutari)
            {
                MIFReportPayerDetail detail = new MIFReportPayerDetail()
                {
                    HesapNo = hesapNo,
                    HesapAdi = hesapAdi,
                    BorcTutari = borcTutari,
                    AlacakTutari = alacakTutari
                };

                Details.Add(detail);
                return detail;
            }
        }

        public class MIFReportPayerDetail
        {
            [DataMember]
            public string HesapNo { get; set; }

            [DataMember]
            public string HesapAdi { get; set; }

            [DataMember]
            public decimal? BorcTutari { get; set; }

            [DataMember]
            public decimal? AlacakTutari { get; set; }

            public MIFReportPayerDetail()
            {
            }
        }
    }
}
