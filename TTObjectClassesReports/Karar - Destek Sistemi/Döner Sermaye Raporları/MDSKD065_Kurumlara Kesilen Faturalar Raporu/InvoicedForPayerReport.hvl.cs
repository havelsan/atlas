
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using TTReportTool;
using TTVisual;
namespace TTReportClasses
{
    /// <summary>
    /// Kurumlara Kesilen Faturalar Raporu
    /// </summary>
    public partial class InvoicedForPayerReport : TTReport
    {
#region Methods
   public class KurumFatura
        {
            public string kurumAdi;
            public int hastaSayisi;
            public double faturaToplami, odenenTutar, indirimTutari, kalanTutar;
            
            public KurumFatura()
            {
                kurumAdi = "";
                hastaSayisi = 0;
                faturaToplami = 0;
                odenenTutar = 0;
                indirimTutari = 0;
                kalanTutar = 0;
            }
        }
        
        public int yazdirmaSayac = 0;
        public int toplamHastaSayisi = 0;
        public double toplamFaturaToplami = 0;
        public double toplamOdenenTutar = 0;
        public double toplamIndirimTutari = 0;
        public double toplamKalanTutar = 0;
        public List<KurumFatura> kurumFaturaBilgisi = new List<KurumFatura>();
        public List<KurumFatura> yurtdisiKurumFaturaBilgisi = new List<KurumFatura>();
        
        public class AscBranchComparer : IComparer<KurumFatura>
        {
            #region IComparer<LotoItem> Members
            public int Compare(KurumFatura x, KurumFatura y)
            {
                return (x.kurumAdi.CompareTo(y.kurumAdi)); // artan sıra ile sıralayan Compare
            }
            #endregion
        }
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public List<string> PAYER = new List<string>();
            public int? PAYERFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTFGroup : TTReportGroup
        {
            public InvoicedForPayerReport MyParentReport
            {
                get { return (InvoicedForPayerReport)ParentReport; }
            }

            new public PARTFGroupHeader Header()
            {
                return (PARTFGroupHeader)_header;
            }

            new public PARTFGroupFooter Footer()
            {
                return (PARTFGroupFooter)_footer;
            }

            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportShape NewLine111111 { get {return Footer().NewLine111111;} }
            public TTReportField CURRENTUSER1 { get {return Footer().CURRENTUSER1;} }
            public TTReportField PageNumber1 { get {return Footer().PageNumber1;} }
            public TTReportField PrintDate1 { get {return Footer().PrintDate1;} }
            public PARTFGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTFGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTFGroupHeader(this);
                _footer = new PARTFGroupFooter(this);

            }

            public partial class PARTFGroupHeader : TTReportSection
            {
                public InvoicedForPayerReport MyParentReport
                {
                    get { return (InvoicedForPayerReport)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTFGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 9;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 32, 6, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 1, 58, 6, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    return new TTReportObject[] { STARTDATE,ENDDATE};
                }

                public override void RunScript()
                {
#region PARTF HEADER_Script
                    Dictionary<string,KurumFatura> kurumFaturaBilgisi = new Dictionary<string,KurumFatura>();
            Dictionary<string,KurumFatura> yurtdisiKurumFaturaBilgisi = new Dictionary<string,KurumFatura>();
            List<KurumFatura> kurumFaturaList = new List<KurumFatura>();
            List<KurumFatura> yurtdisiKurumFaturaList = new List<KurumFatura>();
            ((InvoicedForPayerReport)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
            ((InvoicedForPayerReport)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
            if (((InvoicedForPayerReport)ParentReport).RuntimeParameters.PAYER == null)
                ((InvoicedForPayerReport)ParentReport).RuntimeParameters.PAYERFLAG = 0;
            else
                ((InvoicedForPayerReport)ParentReport).RuntimeParameters.PAYERFLAG = 1;
            
            BindingList<PayerInvoice.GetPayerInvoiceByPayer_Class> payerInvoiceList = PayerInvoice.GetPayerInvoiceByPayer((DateTime)((InvoicedForPayerReport)ParentReport).RuntimeParameters.STARTDATE, (DateTime)((InvoicedForPayerReport)ParentReport).RuntimeParameters.ENDDATE, ((InvoicedForPayerReport)ParentReport).RuntimeParameters.PAYER, (int)((InvoicedForPayerReport)ParentReport).RuntimeParameters.PAYERFLAG);
            BindingList<GeneralInvoice.GetGeneralInvoiceByPayer_Class> generalInvoiceList = GeneralInvoice.GetGeneralInvoiceByPayer((DateTime)((InvoicedForPayerReport)ParentReport).RuntimeParameters.STARTDATE, (DateTime)((InvoicedForPayerReport)ParentReport).RuntimeParameters.ENDDATE, ((InvoicedForPayerReport)ParentReport).RuntimeParameters.PAYER, (int)((InvoicedForPayerReport)ParentReport).RuntimeParameters.PAYERFLAG);
            BindingList<ManualInvoice.GetManualInvoiceByPayer_Class> manualInvoiceList = ManualInvoice.GetManualInvoiceByPayer((DateTime)((InvoicedForPayerReport)ParentReport).RuntimeParameters.STARTDATE, (DateTime)((InvoicedForPayerReport)ParentReport).RuntimeParameters.ENDDATE, ((InvoicedForPayerReport)ParentReport).RuntimeParameters.PAYER, (int)((InvoicedForPayerReport)ParentReport).RuntimeParameters.PAYERFLAG);
            
            BindingList<PayerInvoiceDocument.GetPayerInvoiceDocumentByPayer_Class> payerInvoiceDocumentList = PayerInvoiceDocument.GetPayerInvoiceDocumentByPayer((DateTime)((InvoicedForPayerReport)ParentReport).RuntimeParameters.STARTDATE, (DateTime)((InvoicedForPayerReport)ParentReport).RuntimeParameters.ENDDATE, ((InvoicedForPayerReport)ParentReport).RuntimeParameters.PAYER, (int)((InvoicedForPayerReport)ParentReport).RuntimeParameters.PAYERFLAG);
            BindingList<GeneralInvoiceDocument.GetGeneralInvoiceDocumentByPayer_Class> generalInvoiceDocumentList = GeneralInvoiceDocument.GetGeneralInvoiceDocumentByPayer((DateTime)((InvoicedForPayerReport)ParentReport).RuntimeParameters.STARTDATE, (DateTime)((InvoicedForPayerReport)ParentReport).RuntimeParameters.ENDDATE, ((InvoicedForPayerReport)ParentReport).RuntimeParameters.PAYER, (int)((InvoicedForPayerReport)ParentReport).RuntimeParameters.PAYERFLAG);
            BindingList<ManualInvoiceDocument.GetManualInvoiceDocumentByPayer_Class> manualInvoiceDocumentList = ManualInvoiceDocument.GetManualInvoiceDocumentByPayer((DateTime)((InvoicedForPayerReport)ParentReport).RuntimeParameters.STARTDATE, (DateTime)((InvoicedForPayerReport)ParentReport).RuntimeParameters.ENDDATE, ((InvoicedForPayerReport)ParentReport).RuntimeParameters.PAYER, (int)((InvoicedForPayerReport)ParentReport).RuntimeParameters.PAYERFLAG);
            
            if(payerInvoiceList.Count > 0)
            {
                foreach(PayerInvoice.GetPayerInvoiceByPayer_Class payerInvoice in payerInvoiceList)
                {
                    PayerDefinition payer = (PayerDefinition)MyParentReport.ReportObjectContext.GetObject(new Guid(payerInvoice.Payer.ToString()), "PayerDefinition");
                    //if (payer.Type.PayerType != PayerTypeEnum.ForeignInsurance)
                    //{
                        KurumFatura kurumFatura = new KurumFatura();
                        kurumFatura.kurumAdi = payerInvoice.Payername;
                        kurumFatura.faturaToplami = Convert.ToDouble(payerInvoice.Totalprice);
                        kurumFatura.kalanTutar = Convert.ToDouble(payerInvoice.Totalprice);
                        kurumFatura.hastaSayisi = Convert.ToInt32(payerInvoice.Patientcount);
                        kurumFaturaBilgisi.Add(payerInvoice.Payer.ToString(), kurumFatura);
//                    }
//                    else
//                    {
//                        KurumFatura yurtdisiKurumFatura = new KurumFatura();
//                        yurtdisiKurumFatura.kurumAdi = payerInvoice.Payername;
//                        yurtdisiKurumFatura.faturaToplami = Convert.ToDouble(payerInvoice.Totalprice);
//                        yurtdisiKurumFatura.kalanTutar = Convert.ToDouble(payerInvoice.Totalprice);
//                        yurtdisiKurumFatura.hastaSayisi = Convert.ToInt32(payerInvoice.Patientcount);
//                        yurtdisiKurumFaturaBilgisi.Add(payerInvoice.Payer.ToString(), yurtdisiKurumFatura);
//                    }
                }
            }
            
            if(generalInvoiceList.Count > 0)
            {
                foreach(GeneralInvoice.GetGeneralInvoiceByPayer_Class generalInvoice in generalInvoiceList)
                {
                    PayerDefinition payer = (PayerDefinition)MyParentReport.ReportObjectContext.GetObject(new Guid(generalInvoice.Payer.ToString()), "PayerDefinition");
//                    if (payer.Type.PayerType != PayerTypeEnum.ForeignInsurance)
//                    {
                        if(kurumFaturaBilgisi.ContainsKey(generalInvoice.Payer.ToString()))
                        {
                            KurumFatura kurumFatura = kurumFaturaBilgisi[generalInvoice.Payer.ToString()];
                            kurumFatura.faturaToplami += Convert.ToDouble(generalInvoice.Totalprice);
                            kurumFatura.kalanTutar += Convert.ToDouble(generalInvoice.Totalprice);
                            kurumFatura.hastaSayisi += Convert.ToInt32(generalInvoice.Patientcount);
                        }
                        else
                        {
                            KurumFatura kurumFatura = new KurumFatura();
                            kurumFatura.kurumAdi = generalInvoice.Payername;
                            kurumFatura.faturaToplami = Convert.ToDouble(generalInvoice.Totalprice);
                            kurumFatura.kalanTutar = Convert.ToDouble(generalInvoice.Totalprice);
                            kurumFatura.hastaSayisi = Convert.ToInt32(generalInvoice.Patientcount);
                            kurumFaturaBilgisi.Add(generalInvoice.Payer.ToString(),kurumFatura);
                        }
//                    }
//                    else
//                    {
//                        if(yurtdisiKurumFaturaBilgisi.ContainsKey(generalInvoice.Payer.ToString()))
//                        {
//                            KurumFatura yurtdisiKurumFatura = yurtdisiKurumFaturaBilgisi[generalInvoice.Payer.ToString()];
//                            yurtdisiKurumFatura.faturaToplami += Convert.ToDouble(generalInvoice.Totalprice);
//                            yurtdisiKurumFatura.kalanTutar += Convert.ToDouble(generalInvoice.Totalprice);
//                            yurtdisiKurumFatura.hastaSayisi += Convert.ToInt32(generalInvoice.Patientcount);
//                        }
//                        else
//                        {
//                            KurumFatura yurtdisiKurumFatura = new KurumFatura();
//                            yurtdisiKurumFatura.kurumAdi = generalInvoice.Payername;
//                            yurtdisiKurumFatura.faturaToplami = Convert.ToDouble(generalInvoice.Totalprice);
//                            yurtdisiKurumFatura.kalanTutar = Convert.ToDouble(generalInvoice.Totalprice);
//                            yurtdisiKurumFatura.hastaSayisi = Convert.ToInt32(generalInvoice.Patientcount);
//                            yurtdisiKurumFaturaBilgisi.Add(generalInvoice.Payer.ToString(),yurtdisiKurumFatura);
//                        }
//                    }
                }
            }
            
            if(manualInvoiceList.Count > 0)
            {
                foreach(ManualInvoice.GetManualInvoiceByPayer_Class manualInvoice in manualInvoiceList)
                {
                    PayerDefinition payer = (PayerDefinition)MyParentReport.ReportObjectContext.GetObject(new Guid(manualInvoice.Payer.ToString()), "PayerDefinition");
//                    if (payer.Type.PayerType != PayerTypeEnum.ForeignInsurance)
//                    {
                        if(kurumFaturaBilgisi.ContainsKey(manualInvoice.Payer.ToString()))
                        {
                            KurumFatura kurumFatura = kurumFaturaBilgisi[manualInvoice.Payer.ToString()];
                            kurumFatura.faturaToplami += Convert.ToDouble(manualInvoice.Totalprice);
                            kurumFatura.kalanTutar += Convert.ToDouble(manualInvoice.Totalprice);
                            kurumFatura.hastaSayisi += Convert.ToInt32(manualInvoice.Patientcount);
                        }
                        else
                        {
                            KurumFatura kurumFatura = new KurumFatura();
                            kurumFatura.kurumAdi = manualInvoice.Payername;
                            kurumFatura.faturaToplami = Convert.ToDouble(manualInvoice.Totalprice);
                            kurumFatura.kalanTutar = Convert.ToDouble(manualInvoice.Totalprice);
                            kurumFatura.hastaSayisi = Convert.ToInt32(manualInvoice.Patientcount);
                            kurumFaturaBilgisi.Add(manualInvoice.Payer.ToString(),kurumFatura);
                        }
//                    }
//                    else
//                    {
//                        if(yurtdisiKurumFaturaBilgisi.ContainsKey(manualInvoice.Payer.ToString()))
//                        {
//                            KurumFatura yurtdisiKurumFatura = yurtdisiKurumFaturaBilgisi[manualInvoice.Payer.ToString()];
//                            yurtdisiKurumFatura.faturaToplami += Convert.ToDouble(manualInvoice.Totalprice);
//                            yurtdisiKurumFatura.kalanTutar += Convert.ToDouble(manualInvoice.Totalprice);
//                            yurtdisiKurumFatura.hastaSayisi += Convert.ToInt32(manualInvoice.Patientcount);
//                        }
//                        else
//                        {
//                            KurumFatura yurtdisiKurumFatura = new KurumFatura();
//                            yurtdisiKurumFatura.kurumAdi = manualInvoice.Payername;
//                            yurtdisiKurumFatura.faturaToplami = Convert.ToDouble(manualInvoice.Totalprice);
//                            yurtdisiKurumFatura.kalanTutar = Convert.ToDouble(manualInvoice.Totalprice);
//                            yurtdisiKurumFatura.hastaSayisi = Convert.ToInt32(manualInvoice.Patientcount);
//                            yurtdisiKurumFaturaBilgisi.Add(manualInvoice.Payer.ToString(),yurtdisiKurumFatura);
//                        }
//                    }
                }
            }
            
            if(payerInvoiceDocumentList.Count > 0)
            {
                foreach(PayerInvoiceDocument.GetPayerInvoiceDocumentByPayer_Class payerInvoiceDocument in payerInvoiceDocumentList)
                {
                    PayerDefinition payer = (PayerDefinition)MyParentReport.ReportObjectContext.GetObject(new Guid(payerInvoiceDocument.Payer.ToString()), "PayerDefinition");
//                    if (payer.Type.PayerType != PayerTypeEnum.ForeignInsurance)
//                    {
                        if(kurumFaturaBilgisi.ContainsKey(payerInvoiceDocument.Payer.ToString()))
                        {
                            KurumFatura kurumFatura = kurumFaturaBilgisi[payerInvoiceDocument.Payer.ToString()];
                            kurumFatura.odenenTutar = Convert.ToDouble(payerInvoiceDocument.Paidprice);
                            kurumFatura.indirimTutari = Convert.ToDouble(payerInvoiceDocument.Cutoffprice);
                            kurumFatura.kalanTutar = kurumFatura.faturaToplami - (kurumFatura.odenenTutar + kurumFatura.indirimTutari);
                        }
                        else
                        {
                            KurumFatura kurumFatura = new KurumFatura();
                            kurumFatura.kurumAdi = payerInvoiceDocument.Payername;
                            kurumFatura.odenenTutar = Convert.ToDouble(payerInvoiceDocument.Paidprice);
                            kurumFatura.indirimTutari = Convert.ToDouble(payerInvoiceDocument.Cutoffprice);
                            kurumFatura.kalanTutar = kurumFatura.faturaToplami - (kurumFatura.odenenTutar + kurumFatura.indirimTutari);
                            kurumFaturaBilgisi.Add(payerInvoiceDocument.Payer.ToString(),kurumFatura);
                        }
//                    }
//                    else
//                    {
//                        if(yurtdisiKurumFaturaBilgisi.ContainsKey(payerInvoiceDocument.Payer.ToString()))
//                        {
//                            KurumFatura yurtdisiKurumFatura = yurtdisiKurumFaturaBilgisi[payerInvoiceDocument.Payer.ToString()];
//                            yurtdisiKurumFatura.odenenTutar = Convert.ToDouble(payerInvoiceDocument.Paidprice);
//                            yurtdisiKurumFatura.indirimTutari = Convert.ToDouble(payerInvoiceDocument.Cutoffprice);
//                            yurtdisiKurumFatura.kalanTutar = yurtdisiKurumFatura.faturaToplami - (yurtdisiKurumFatura.odenenTutar + yurtdisiKurumFatura.indirimTutari);
//                        }
//                        else
//                        {
//                            KurumFatura yurtdisiKurumFatura = new KurumFatura();
//                            yurtdisiKurumFatura.kurumAdi = payerInvoiceDocument.Payername;
//                            yurtdisiKurumFatura.odenenTutar = Convert.ToDouble(payerInvoiceDocument.Paidprice);
//                            yurtdisiKurumFatura.indirimTutari = Convert.ToDouble(payerInvoiceDocument.Cutoffprice);
//                            yurtdisiKurumFatura.kalanTutar = yurtdisiKurumFatura.faturaToplami - (yurtdisiKurumFatura.odenenTutar + yurtdisiKurumFatura.indirimTutari);
//                            yurtdisiKurumFaturaBilgisi.Add(payerInvoiceDocument.Payer.ToString(),yurtdisiKurumFatura);
//                        }
//                    }
                }
            }
            
            if(generalInvoiceDocumentList.Count > 0)
            {
                foreach(GeneralInvoiceDocument.GetGeneralInvoiceDocumentByPayer_Class generalInvoiceDocument in generalInvoiceDocumentList)
                {
                    PayerDefinition payer = (PayerDefinition)MyParentReport.ReportObjectContext.GetObject(new Guid(generalInvoiceDocument.Payer.ToString()), "PayerDefinition");
//                    if (payer.Type.PayerType != PayerTypeEnum.ForeignInsurance)
//                    {
                        if(kurumFaturaBilgisi.ContainsKey(generalInvoiceDocument.Payer.ToString()))
                        {
                            KurumFatura kurumFatura = kurumFaturaBilgisi[generalInvoiceDocument.Payer.ToString()];
                            kurumFatura.odenenTutar += Convert.ToDouble(generalInvoiceDocument.Paidprice);
                            kurumFatura.indirimTutari += Convert.ToDouble(generalInvoiceDocument.Cutoffprice);
                            kurumFatura.kalanTutar = kurumFatura.faturaToplami - (kurumFatura.odenenTutar + kurumFatura.indirimTutari);
                        }
                        else
                        {
                            KurumFatura kurumFatura = new KurumFatura();
                            kurumFatura.kurumAdi = generalInvoiceDocument.Payername;
                            kurumFatura.odenenTutar = Convert.ToDouble(generalInvoiceDocument.Paidprice);
                            kurumFatura.indirimTutari = Convert.ToDouble(generalInvoiceDocument.Cutoffprice);
                            kurumFatura.kalanTutar = kurumFatura.faturaToplami - (kurumFatura.odenenTutar + kurumFatura.indirimTutari);
                            kurumFaturaBilgisi.Add(generalInvoiceDocument.Payer.ToString(), kurumFatura);
                        }
//                    }
//                    else
//                    {
//                        if(yurtdisiKurumFaturaBilgisi.ContainsKey(generalInvoiceDocument.Payer.ToString()))
//                        {
//                            KurumFatura yurtdisiKurumFatura = yurtdisiKurumFaturaBilgisi[generalInvoiceDocument.Payer.ToString()];
//                            yurtdisiKurumFatura.odenenTutar += Convert.ToDouble(generalInvoiceDocument.Paidprice);
//                            yurtdisiKurumFatura.indirimTutari += Convert.ToDouble(generalInvoiceDocument.Cutoffprice);
//                            yurtdisiKurumFatura.kalanTutar = yurtdisiKurumFatura.faturaToplami - (yurtdisiKurumFatura.odenenTutar + yurtdisiKurumFatura.indirimTutari);
//                        }
//                        else
//                        {
//                            KurumFatura yurtdisiKurumFatura = new KurumFatura();
//                            yurtdisiKurumFatura.kurumAdi = generalInvoiceDocument.Payername;
//                            yurtdisiKurumFatura.odenenTutar = Convert.ToDouble(generalInvoiceDocument.Paidprice);
//                            yurtdisiKurumFatura.indirimTutari = Convert.ToDouble(generalInvoiceDocument.Cutoffprice);
//                            yurtdisiKurumFatura.kalanTutar = yurtdisiKurumFatura.faturaToplami - (yurtdisiKurumFatura.odenenTutar + yurtdisiKurumFatura.indirimTutari);
//                            yurtdisiKurumFaturaBilgisi.Add(generalInvoiceDocument.Payer.ToString(), yurtdisiKurumFatura);
//                        }
//                    }
                }
            }
            
            if(manualInvoiceDocumentList.Count > 0)
            {
                foreach(ManualInvoiceDocument.GetManualInvoiceDocumentByPayer_Class manualInvoiceDocument in manualInvoiceDocumentList)
                {
                    PayerDefinition payer = (PayerDefinition)MyParentReport.ReportObjectContext.GetObject(new Guid(manualInvoiceDocument.Payer.ToString()), "PayerDefinition");
//                    if (payer.Type.PayerType != PayerTypeEnum.ForeignInsurance)
//                    {
                        if(kurumFaturaBilgisi.ContainsKey(manualInvoiceDocument.Payer.ToString()))
                        {
                            KurumFatura kurumFatura = kurumFaturaBilgisi[manualInvoiceDocument.Payer.ToString()];
                            kurumFatura.odenenTutar += Convert.ToDouble(manualInvoiceDocument.Paidprice);
                            kurumFatura.indirimTutari += Convert.ToDouble(manualInvoiceDocument.Cutoffprice);
                            kurumFatura.kalanTutar = kurumFatura.faturaToplami - (kurumFatura.odenenTutar + kurumFatura.indirimTutari);
                        }
                        else
                        {
                            KurumFatura kurumFatura = new KurumFatura();
                            kurumFatura.kurumAdi = manualInvoiceDocument.Payername;
                            kurumFatura.odenenTutar = Convert.ToDouble(manualInvoiceDocument.Paidprice);
                            kurumFatura.indirimTutari = Convert.ToDouble(manualInvoiceDocument.Cutoffprice);
                            kurumFatura.kalanTutar = kurumFatura.faturaToplami - (kurumFatura.odenenTutar + kurumFatura.indirimTutari);
                            kurumFaturaBilgisi.Add(manualInvoiceDocument.Payer.ToString(),kurumFatura);
                        }
//                    }
//                    else
//                    {
//                        if(yurtdisiKurumFaturaBilgisi.ContainsKey(manualInvoiceDocument.Payer.ToString()))
//                        {
//                            KurumFatura yurtdisiKurumFatura = yurtdisiKurumFaturaBilgisi[manualInvoiceDocument.Payer.ToString()];
//                            yurtdisiKurumFatura.odenenTutar += Convert.ToDouble(manualInvoiceDocument.Paidprice);
//                            yurtdisiKurumFatura.indirimTutari += Convert.ToDouble(manualInvoiceDocument.Cutoffprice);
//                            yurtdisiKurumFatura.kalanTutar = yurtdisiKurumFatura.faturaToplami - (yurtdisiKurumFatura.odenenTutar + yurtdisiKurumFatura.indirimTutari);
//                        }
//                        else
//                        {
//                            KurumFatura yurtdisiKurumFatura = new KurumFatura();
//                            yurtdisiKurumFatura.kurumAdi = manualInvoiceDocument.Payername;
//                            yurtdisiKurumFatura.odenenTutar = Convert.ToDouble(manualInvoiceDocument.Paidprice);
//                            yurtdisiKurumFatura.indirimTutari = Convert.ToDouble(manualInvoiceDocument.Cutoffprice);
//                            yurtdisiKurumFatura.kalanTutar = yurtdisiKurumFatura.faturaToplami - (yurtdisiKurumFatura.odenenTutar + yurtdisiKurumFatura.indirimTutari);
//                            yurtdisiKurumFaturaBilgisi.Add(manualInvoiceDocument.Payer.ToString(),yurtdisiKurumFatura);
//                        }
//                    }
                }
            }
            
            foreach(KurumFatura kurumFatura in kurumFaturaBilgisi.Values)
            {
                kurumFaturaList.Add(kurumFatura);
            }
            foreach(KurumFatura yurtdisiKurumFatura in yurtdisiKurumFaturaBilgisi.Values)
            {
                yurtdisiKurumFaturaList.Add(yurtdisiKurumFatura);
            }
            
            ((InvoicedForPayerReport)ParentReport).kurumFaturaBilgisi = kurumFaturaList;
            ((InvoicedForPayerReport)ParentReport).kurumFaturaBilgisi.Sort(new AscBranchComparer());
            ((InvoicedForPayerReport)ParentReport).MAIN.RepeatCount = kurumFaturaList.Count;
            
            ((InvoicedForPayerReport)ParentReport).yurtdisiKurumFaturaBilgisi = yurtdisiKurumFaturaList;
            ((InvoicedForPayerReport)ParentReport).yurtdisiKurumFaturaBilgisi.Sort(new AscBranchComparer());
            ((InvoicedForPayerReport)ParentReport).PARTC.RepeatCount = yurtdisiKurumFaturaList.Count;
#endregion PARTF HEADER_Script
                }
            }
            public partial class PARTFGroupFooter : TTReportSection
            {
                public InvoicedForPayerReport MyParentReport
                {
                    get { return (InvoicedForPayerReport)ParentReport; }
                }
                
                public TTReportShape NewLine111111;
                public TTReportField CURRENTUSER1;
                public TTReportField PageNumber1;
                public TTReportField PrintDate1; 
                public PARTFGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 14;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 1, 204, 1, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;

                    CURRENTUSER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 2, 138, 7, false);
                    CURRENTUSER1.Name = "CURRENTUSER1";
                    CURRENTUSER1.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER1.TextFont.Name = "Arial";
                    CURRENTUSER1.TextFont.Size = 8;
                    CURRENTUSER1.TextFont.CharSet = 162;
                    CURRENTUSER1.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 2, 204, 7, false);
                    PageNumber1.Name = "PageNumber1";
                    PageNumber1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber1.TextFont.Name = "Arial";
                    PageNumber1.TextFont.Size = 8;
                    PageNumber1.TextFont.CharSet = 162;
                    PageNumber1.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 2, 39, 7, false);
                    PrintDate1.Name = "PrintDate1";
                    PrintDate1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate1.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    PrintDate1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate1.TextFont.Name = "Arial";
                    PrintDate1.TextFont.Size = 8;
                    PrintDate1.TextFont.CharSet = 162;
                    PrintDate1.Value = @"{@printdatetime@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PageNumber1.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    PrintDate1.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    CURRENTUSER1.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PageNumber1,PrintDate1,CURRENTUSER1};
                }
            }

        }

        public PARTFGroup PARTF;

        public partial class PARTBGroup : TTReportGroup
        {
            public InvoicedForPayerReport MyParentReport
            {
                get { return (InvoicedForPayerReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField NewField1112111 { get {return Header().NewField1112111;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField11122111 { get {return Header().NewField11122111;} }
            public TTReportField NewField111122111 { get {return Header().NewField111122111;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public InvoicedForPayerReport MyParentReport
                {
                    get { return (InvoicedForPayerReport)ParentReport; }
                }
                
                public TTReportField NewField111111;
                public TTReportField NewField111211;
                public TTReportField STARTDATE;
                public TTReportField NewField1112111;
                public TTReportField ENDDATE;
                public TTReportField NewField11122111;
                public TTReportField NewField111122111; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 34;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 12, 203, 18, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111.TextFont.Size = 11;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"KURUMLARA KESİLEN FATURA TUTARLARININ ÖDEME BİLGİSİ";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 23, 34, 28, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.TextFont.Name = "Arial";
                    NewField111211.TextFont.Size = 8;
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"Başlangıç Tarihi";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 23, 74, 28, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.TextFont.Name = "Arial";
                    STARTDATE.TextFont.Size = 8;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    NewField1112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 28, 34, 33, false);
                    NewField1112111.Name = "NewField1112111";
                    NewField1112111.TextFont.Name = "Arial";
                    NewField1112111.TextFont.Size = 8;
                    NewField1112111.TextFont.Bold = true;
                    NewField1112111.TextFont.CharSet = 162;
                    NewField1112111.Value = @"Bitiş Tarihi";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 28, 74, 33, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.TextFont.Name = "Arial";
                    ENDDATE.TextFont.Size = 8;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField11122111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 28, 37, 33, false);
                    NewField11122111.Name = "NewField11122111";
                    NewField11122111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11122111.TextFont.Name = "Arial";
                    NewField11122111.TextFont.Size = 8;
                    NewField11122111.TextFont.Bold = true;
                    NewField11122111.TextFont.CharSet = 162;
                    NewField11122111.Value = @":";

                    NewField111122111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 23, 37, 28, false);
                    NewField111122111.Name = "NewField111122111";
                    NewField111122111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111122111.TextFont.Name = "Arial";
                    NewField111122111.TextFont.Size = 8;
                    NewField111122111.TextFont.Bold = true;
                    NewField111122111.TextFont.CharSet = 162;
                    NewField111122111.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField1112111.CalcValue = NewField1112111.Value;
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField11122111.CalcValue = NewField11122111.Value;
                    NewField111122111.CalcValue = NewField111122111.Value;
                    return new TTReportObject[] { NewField111111,NewField111211,STARTDATE,NewField1112111,ENDDATE,NewField11122111,NewField111122111};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public InvoicedForPayerReport MyParentReport
                {
                    get { return (InvoicedForPayerReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public InvoicedForPayerReport MyParentReport
            {
                get { return (InvoicedForPayerReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField1112311 { get {return Header().NewField1112311;} }
            public TTReportField NewFieldb11 { get {return Header().NewFieldb11;} }
            public TTReportField NewFielda11 { get {return Header().NewFielda11;} }
            public TTReportField NewFieldb111 { get {return Header().NewFieldb111;} }
            public TTReportField NewFieldb112 { get {return Header().NewFieldb112;} }
            public TTReportField NewFieldb113 { get {return Header().NewFieldb113;} }
            public TTReportShape NewLine111112 { get {return Header().NewLine111112;} }
            public TTReportField NewField11132111 { get {return Footer().NewField11132111;} }
            public TTReportField ADET { get {return Footer().ADET;} }
            public TTReportField TOPLAM { get {return Footer().TOPLAM;} }
            public TTReportField ODENENTUTAR { get {return Footer().ODENENTUTAR;} }
            public TTReportField INDIRIMTUTARI { get {return Footer().INDIRIMTUTARI;} }
            public TTReportField KALANTUTAR { get {return Footer().KALANTUTAR;} }
            public TTReportShape NewLine111111 { get {return Footer().NewLine111111;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public InvoicedForPayerReport MyParentReport
                {
                    get { return (InvoicedForPayerReport)ParentReport; }
                }
                
                public TTReportField NewField1112311;
                public TTReportField NewFieldb11;
                public TTReportField NewFielda11;
                public TTReportField NewFieldb111;
                public TTReportField NewFieldb112;
                public TTReportField NewFieldb113;
                public TTReportShape NewLine111112; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 11;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1112311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 102, 9, false);
                    NewField1112311.Name = "NewField1112311";
                    NewField1112311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1112311.TextFont.Name = "Arial";
                    NewField1112311.TextFont.Size = 8;
                    NewField1112311.TextFont.Bold = true;
                    NewField1112311.TextFont.CharSet = 162;
                    NewField1112311.Value = @"KURUM";

                    NewFieldb11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 1, 138, 9, false);
                    NewFieldb11.Name = "NewFieldb11";
                    NewFieldb11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewFieldb11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewFieldb11.MultiLine = EvetHayirEnum.ehEvet;
                    NewFieldb11.NoClip = EvetHayirEnum.ehEvet;
                    NewFieldb11.WordBreak = EvetHayirEnum.ehEvet;
                    NewFieldb11.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewFieldb11.TextFont.Name = "Arial";
                    NewFieldb11.TextFont.Size = 8;
                    NewFieldb11.TextFont.Bold = true;
                    NewFieldb11.TextFont.CharSet = 162;
                    NewFieldb11.Value = @"FATURA
TOPLAMI";

                    NewFielda11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 1, 116, 9, false);
                    NewFielda11.Name = "NewFielda11";
                    NewFielda11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewFielda11.MultiLine = EvetHayirEnum.ehEvet;
                    NewFielda11.NoClip = EvetHayirEnum.ehEvet;
                    NewFielda11.WordBreak = EvetHayirEnum.ehEvet;
                    NewFielda11.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewFielda11.TextFont.Name = "Arial";
                    NewFielda11.TextFont.Size = 8;
                    NewFielda11.TextFont.Bold = true;
                    NewFielda11.TextFont.CharSet = 162;
                    NewFielda11.Value = @"FATURA
SAYISI";

                    NewFieldb111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 1, 160, 9, false);
                    NewFieldb111.Name = "NewFieldb111";
                    NewFieldb111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewFieldb111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewFieldb111.MultiLine = EvetHayirEnum.ehEvet;
                    NewFieldb111.NoClip = EvetHayirEnum.ehEvet;
                    NewFieldb111.WordBreak = EvetHayirEnum.ehEvet;
                    NewFieldb111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewFieldb111.TextFont.Name = "Arial";
                    NewFieldb111.TextFont.Size = 8;
                    NewFieldb111.TextFont.Bold = true;
                    NewFieldb111.TextFont.CharSet = 162;
                    NewFieldb111.Value = @"ÖDENEN
TUTAR";

                    NewFieldb112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 1, 182, 9, false);
                    NewFieldb112.Name = "NewFieldb112";
                    NewFieldb112.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewFieldb112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewFieldb112.MultiLine = EvetHayirEnum.ehEvet;
                    NewFieldb112.NoClip = EvetHayirEnum.ehEvet;
                    NewFieldb112.WordBreak = EvetHayirEnum.ehEvet;
                    NewFieldb112.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewFieldb112.TextFont.Name = "Arial";
                    NewFieldb112.TextFont.Size = 8;
                    NewFieldb112.TextFont.Bold = true;
                    NewFieldb112.TextFont.CharSet = 162;
                    NewFieldb112.Value = @"KESİNTİ
TUTARI";

                    NewFieldb113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 1, 204, 9, false);
                    NewFieldb113.Name = "NewFieldb113";
                    NewFieldb113.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewFieldb113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewFieldb113.MultiLine = EvetHayirEnum.ehEvet;
                    NewFieldb113.NoClip = EvetHayirEnum.ehEvet;
                    NewFieldb113.WordBreak = EvetHayirEnum.ehEvet;
                    NewFieldb113.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewFieldb113.TextFont.Name = "Arial";
                    NewFieldb113.TextFont.Size = 8;
                    NewFieldb113.TextFont.Bold = true;
                    NewFieldb113.TextFont.CharSet = 162;
                    NewFieldb113.Value = @"KALAN
TUTAR";

                    NewLine111112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 10, 204, 10, false);
                    NewLine111112.Name = "NewLine111112";
                    NewLine111112.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1112311.CalcValue = NewField1112311.Value;
                    NewFieldb11.CalcValue = NewFieldb11.Value;
                    NewFielda11.CalcValue = NewFielda11.Value;
                    NewFieldb111.CalcValue = NewFieldb111.Value;
                    NewFieldb112.CalcValue = NewFieldb112.Value;
                    NewFieldb113.CalcValue = NewFieldb113.Value;
                    return new TTReportObject[] { NewField1112311,NewFieldb11,NewFielda11,NewFieldb111,NewFieldb112,NewFieldb113};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public InvoicedForPayerReport MyParentReport
                {
                    get { return (InvoicedForPayerReport)ParentReport; }
                }
                
                public TTReportField NewField11132111;
                public TTReportField ADET;
                public TTReportField TOPLAM;
                public TTReportField ODENENTUTAR;
                public TTReportField INDIRIMTUTARI;
                public TTReportField KALANTUTAR;
                public TTReportShape NewLine111111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 15;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11132111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 3, 102, 7, false);
                    NewField11132111.Name = "NewField11132111";
                    NewField11132111.TextFont.Name = "Arial";
                    NewField11132111.TextFont.Size = 8;
                    NewField11132111.TextFont.Bold = true;
                    NewField11132111.TextFont.CharSet = 162;
                    NewField11132111.Value = @"TOPLAM";

                    ADET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 3, 116, 7, false);
                    ADET.Name = "ADET";
                    ADET.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADET.MultiLine = EvetHayirEnum.ehEvet;
                    ADET.NoClip = EvetHayirEnum.ehEvet;
                    ADET.WordBreak = EvetHayirEnum.ehEvet;
                    ADET.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADET.TextFont.Name = "Arial";
                    ADET.TextFont.Size = 8;
                    ADET.TextFont.CharSet = 162;
                    ADET.Value = @"";

                    TOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 3, 138, 7, false);
                    TOPLAM.Name = "TOPLAM";
                    TOPLAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAM.TextFormat = @"#,##0.#0";
                    TOPLAM.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAM.MultiLine = EvetHayirEnum.ehEvet;
                    TOPLAM.NoClip = EvetHayirEnum.ehEvet;
                    TOPLAM.WordBreak = EvetHayirEnum.ehEvet;
                    TOPLAM.ExpandTabs = EvetHayirEnum.ehEvet;
                    TOPLAM.TextFont.Name = "Arial";
                    TOPLAM.TextFont.Size = 8;
                    TOPLAM.TextFont.CharSet = 162;
                    TOPLAM.Value = @"";

                    ODENENTUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 3, 160, 7, false);
                    ODENENTUTAR.Name = "ODENENTUTAR";
                    ODENENTUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ODENENTUTAR.TextFormat = @"#,##0.#0";
                    ODENENTUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ODENENTUTAR.MultiLine = EvetHayirEnum.ehEvet;
                    ODENENTUTAR.NoClip = EvetHayirEnum.ehEvet;
                    ODENENTUTAR.WordBreak = EvetHayirEnum.ehEvet;
                    ODENENTUTAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    ODENENTUTAR.TextFont.Name = "Arial";
                    ODENENTUTAR.TextFont.Size = 8;
                    ODENENTUTAR.TextFont.CharSet = 162;
                    ODENENTUTAR.Value = @"";

                    INDIRIMTUTARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 3, 182, 7, false);
                    INDIRIMTUTARI.Name = "INDIRIMTUTARI";
                    INDIRIMTUTARI.FieldType = ReportFieldTypeEnum.ftVariable;
                    INDIRIMTUTARI.TextFormat = @"#,##0.#0";
                    INDIRIMTUTARI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    INDIRIMTUTARI.MultiLine = EvetHayirEnum.ehEvet;
                    INDIRIMTUTARI.NoClip = EvetHayirEnum.ehEvet;
                    INDIRIMTUTARI.WordBreak = EvetHayirEnum.ehEvet;
                    INDIRIMTUTARI.ExpandTabs = EvetHayirEnum.ehEvet;
                    INDIRIMTUTARI.TextFont.Name = "Arial";
                    INDIRIMTUTARI.TextFont.Size = 8;
                    INDIRIMTUTARI.TextFont.CharSet = 162;
                    INDIRIMTUTARI.Value = @"";

                    KALANTUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 3, 204, 7, false);
                    KALANTUTAR.Name = "KALANTUTAR";
                    KALANTUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KALANTUTAR.TextFormat = @"#,##0.#0";
                    KALANTUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    KALANTUTAR.MultiLine = EvetHayirEnum.ehEvet;
                    KALANTUTAR.NoClip = EvetHayirEnum.ehEvet;
                    KALANTUTAR.WordBreak = EvetHayirEnum.ehEvet;
                    KALANTUTAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    KALANTUTAR.TextFont.Name = "Arial";
                    KALANTUTAR.TextFont.Size = 8;
                    KALANTUTAR.TextFont.CharSet = 162;
                    KALANTUTAR.Value = @"";

                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 103, 2, 204, 2, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11132111.CalcValue = NewField11132111.Value;
                    ADET.CalcValue = @"";
                    TOPLAM.CalcValue = @"";
                    ODENENTUTAR.CalcValue = @"";
                    INDIRIMTUTARI.CalcValue = @"";
                    KALANTUTAR.CalcValue = @"";
                    return new TTReportObject[] { NewField11132111,ADET,TOPLAM,ODENENTUTAR,INDIRIMTUTARI,KALANTUTAR};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    this.ADET.CalcValue = (((InvoicedForPayerReport)ParentReport).toplamHastaSayisi).ToString();
            this.TOPLAM.CalcValue = (((InvoicedForPayerReport)ParentReport).toplamFaturaToplami).ToString();
            this.ODENENTUTAR.CalcValue = (((InvoicedForPayerReport)ParentReport).toplamOdenenTutar).ToString();
            this.INDIRIMTUTARI.CalcValue = (((InvoicedForPayerReport)ParentReport).toplamIndirimTutari).ToString();
            this.KALANTUTAR.CalcValue = (((InvoicedForPayerReport)ParentReport).toplamKalanTutar).ToString();
            
            ((InvoicedForPayerReport)ParentReport).toplamHastaSayisi = 0;
            ((InvoicedForPayerReport)ParentReport).toplamFaturaToplami = 0;
            ((InvoicedForPayerReport)ParentReport).toplamOdenenTutar = 0;
            ((InvoicedForPayerReport)ParentReport).toplamIndirimTutari = 0;
            ((InvoicedForPayerReport)ParentReport).toplamKalanTutar = 0;
            ((InvoicedForPayerReport)ParentReport).yazdirmaSayac = 0;
            (((InvoicedForPayerReport)ParentReport).kurumFaturaBilgisi).Clear();
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public InvoicedForPayerReport MyParentReport
            {
                get { return (InvoicedForPayerReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ADET { get {return Body().ADET;} }
            public TTReportField TOPLAM { get {return Body().TOPLAM;} }
            public TTReportField KURUMADI { get {return Body().KURUMADI;} }
            public TTReportField ODENENTUTAR { get {return Body().ODENENTUTAR;} }
            public TTReportField INDIRIMTUTARI { get {return Body().INDIRIMTUTARI;} }
            public TTReportField KALANTUTAR { get {return Body().KALANTUTAR;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public InvoicedForPayerReport MyParentReport
                {
                    get { return (InvoicedForPayerReport)ParentReport; }
                }
                
                public TTReportField ADET;
                public TTReportField TOPLAM;
                public TTReportField KURUMADI;
                public TTReportField ODENENTUTAR;
                public TTReportField INDIRIMTUTARI;
                public TTReportField KALANTUTAR; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    ADET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 1, 116, 5, false);
                    ADET.Name = "ADET";
                    ADET.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADET.MultiLine = EvetHayirEnum.ehEvet;
                    ADET.NoClip = EvetHayirEnum.ehEvet;
                    ADET.WordBreak = EvetHayirEnum.ehEvet;
                    ADET.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADET.TextFont.Name = "Arial";
                    ADET.TextFont.Size = 8;
                    ADET.TextFont.CharSet = 162;
                    ADET.Value = @"";

                    TOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 1, 138, 5, false);
                    TOPLAM.Name = "TOPLAM";
                    TOPLAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAM.TextFormat = @"#,##0.#0";
                    TOPLAM.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAM.MultiLine = EvetHayirEnum.ehEvet;
                    TOPLAM.NoClip = EvetHayirEnum.ehEvet;
                    TOPLAM.WordBreak = EvetHayirEnum.ehEvet;
                    TOPLAM.ExpandTabs = EvetHayirEnum.ehEvet;
                    TOPLAM.TextFont.Name = "Arial";
                    TOPLAM.TextFont.Size = 8;
                    TOPLAM.TextFont.CharSet = 162;
                    TOPLAM.Value = @"";

                    KURUMADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 102, 5, false);
                    KURUMADI.Name = "KURUMADI";
                    KURUMADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMADI.MultiLine = EvetHayirEnum.ehEvet;
                    KURUMADI.NoClip = EvetHayirEnum.ehEvet;
                    KURUMADI.WordBreak = EvetHayirEnum.ehEvet;
                    KURUMADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    KURUMADI.TextFont.Name = "Arial";
                    KURUMADI.TextFont.Size = 8;
                    KURUMADI.TextFont.CharSet = 162;
                    KURUMADI.Value = @"";

                    ODENENTUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 1, 160, 5, false);
                    ODENENTUTAR.Name = "ODENENTUTAR";
                    ODENENTUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ODENENTUTAR.TextFormat = @"#,##0.#0";
                    ODENENTUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ODENENTUTAR.MultiLine = EvetHayirEnum.ehEvet;
                    ODENENTUTAR.NoClip = EvetHayirEnum.ehEvet;
                    ODENENTUTAR.WordBreak = EvetHayirEnum.ehEvet;
                    ODENENTUTAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    ODENENTUTAR.TextFont.Name = "Arial";
                    ODENENTUTAR.TextFont.Size = 8;
                    ODENENTUTAR.TextFont.CharSet = 162;
                    ODENENTUTAR.Value = @"";

                    INDIRIMTUTARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 1, 182, 5, false);
                    INDIRIMTUTARI.Name = "INDIRIMTUTARI";
                    INDIRIMTUTARI.FieldType = ReportFieldTypeEnum.ftVariable;
                    INDIRIMTUTARI.TextFormat = @"#,##0.#0";
                    INDIRIMTUTARI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    INDIRIMTUTARI.MultiLine = EvetHayirEnum.ehEvet;
                    INDIRIMTUTARI.NoClip = EvetHayirEnum.ehEvet;
                    INDIRIMTUTARI.WordBreak = EvetHayirEnum.ehEvet;
                    INDIRIMTUTARI.ExpandTabs = EvetHayirEnum.ehEvet;
                    INDIRIMTUTARI.TextFont.Name = "Arial";
                    INDIRIMTUTARI.TextFont.Size = 8;
                    INDIRIMTUTARI.TextFont.CharSet = 162;
                    INDIRIMTUTARI.Value = @"";

                    KALANTUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 1, 204, 5, false);
                    KALANTUTAR.Name = "KALANTUTAR";
                    KALANTUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KALANTUTAR.TextFormat = @"#,##0.#0";
                    KALANTUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    KALANTUTAR.MultiLine = EvetHayirEnum.ehEvet;
                    KALANTUTAR.NoClip = EvetHayirEnum.ehEvet;
                    KALANTUTAR.WordBreak = EvetHayirEnum.ehEvet;
                    KALANTUTAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    KALANTUTAR.TextFont.Name = "Arial";
                    KALANTUTAR.TextFont.Size = 8;
                    KALANTUTAR.TextFont.CharSet = 162;
                    KALANTUTAR.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ADET.CalcValue = @"";
                    TOPLAM.CalcValue = @"";
                    KURUMADI.CalcValue = @"";
                    ODENENTUTAR.CalcValue = @"";
                    INDIRIMTUTARI.CalcValue = @"";
                    KALANTUTAR.CalcValue = @"";
                    return new TTReportObject[] { ADET,TOPLAM,KURUMADI,ODENENTUTAR,INDIRIMTUTARI,KALANTUTAR};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    List<KurumFatura> kurumFaturaBilgisi = ((InvoicedForPayerReport)ParentReport).kurumFaturaBilgisi;
            int yazdirmaSayac = ((InvoicedForPayerReport)ParentReport).yazdirmaSayac;
            if(kurumFaturaBilgisi.Count > 0)
            {
                KurumFatura kurumFatura = kurumFaturaBilgisi[yazdirmaSayac];
                this.KURUMADI.CalcValue = kurumFatura.kurumAdi;
                this.ADET.CalcValue = kurumFatura.hastaSayisi.ToString();
                this.TOPLAM.CalcValue = kurumFatura.faturaToplami.ToString();
                this.ODENENTUTAR.CalcValue = kurumFatura.odenenTutar.ToString();
                this.INDIRIMTUTARI.CalcValue = kurumFatura.indirimTutari.ToString();
                this.KALANTUTAR.CalcValue = kurumFatura.kalanTutar.ToString();
                ((InvoicedForPayerReport)ParentReport).toplamHastaSayisi += Convert.ToInt32(this.ADET.CalcValue);
                ((InvoicedForPayerReport)ParentReport).toplamFaturaToplami += Convert.ToDouble(this.TOPLAM.CalcValue);
                ((InvoicedForPayerReport)ParentReport).toplamOdenenTutar += Convert.ToDouble(this.ODENENTUTAR.CalcValue);
                ((InvoicedForPayerReport)ParentReport).toplamIndirimTutari += Convert.ToDouble(this.INDIRIMTUTARI.CalcValue);
                ((InvoicedForPayerReport)ParentReport).toplamKalanTutar += Convert.ToDouble(this.KALANTUTAR.CalcValue);
                ((InvoicedForPayerReport)ParentReport).yazdirmaSayac++;
            }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PARTDGroup : TTReportGroup
        {
            public InvoicedForPayerReport MyParentReport
            {
                get { return (InvoicedForPayerReport)ParentReport; }
            }

            new public PARTDGroupHeader Header()
            {
                return (PARTDGroupHeader)_header;
            }

            new public PARTDGroupFooter Footer()
            {
                return (PARTDGroupFooter)_footer;
            }

            public TTReportField NewField11132111 { get {return Header().NewField11132111;} }
            public TTReportField NewFieldb111 { get {return Header().NewFieldb111;} }
            public TTReportField NewFielda111 { get {return Header().NewFielda111;} }
            public TTReportField NewFieldb1111 { get {return Header().NewFieldb1111;} }
            public TTReportField NewFieldb1211 { get {return Header().NewFieldb1211;} }
            public TTReportField NewFieldb1311 { get {return Header().NewFieldb1311;} }
            public TTReportShape NewLine1211111 { get {return Header().NewLine1211111;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField111123111 { get {return Footer().NewField111123111;} }
            public TTReportField ADET { get {return Footer().ADET;} }
            public TTReportField TOPLAM { get {return Footer().TOPLAM;} }
            public TTReportField ODENENTUTAR { get {return Footer().ODENENTUTAR;} }
            public TTReportField INDIRIMTUTARI { get {return Footer().INDIRIMTUTARI;} }
            public TTReportField KALANTUTAR { get {return Footer().KALANTUTAR;} }
            public TTReportShape NewLine1111111 { get {return Footer().NewLine1111111;} }
            public PARTDGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTDGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTDGroupHeader(this);
                _footer = new PARTDGroupFooter(this);

            }

            public partial class PARTDGroupHeader : TTReportSection
            {
                public InvoicedForPayerReport MyParentReport
                {
                    get { return (InvoicedForPayerReport)ParentReport; }
                }
                
                public TTReportField NewField11132111;
                public TTReportField NewFieldb111;
                public TTReportField NewFielda111;
                public TTReportField NewFieldb1111;
                public TTReportField NewFieldb1211;
                public TTReportField NewFieldb1311;
                public TTReportShape NewLine1211111;
                public TTReportField NewField1; 
                public PARTDGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 16;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11132111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 7, 102, 15, false);
                    NewField11132111.Name = "NewField11132111";
                    NewField11132111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11132111.TextFont.Name = "Arial";
                    NewField11132111.TextFont.Size = 8;
                    NewField11132111.TextFont.Bold = true;
                    NewField11132111.TextFont.CharSet = 162;
                    NewField11132111.Value = @"KURUM";

                    NewFieldb111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 7, 138, 15, false);
                    NewFieldb111.Name = "NewFieldb111";
                    NewFieldb111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewFieldb111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewFieldb111.MultiLine = EvetHayirEnum.ehEvet;
                    NewFieldb111.NoClip = EvetHayirEnum.ehEvet;
                    NewFieldb111.WordBreak = EvetHayirEnum.ehEvet;
                    NewFieldb111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewFieldb111.TextFont.Name = "Arial";
                    NewFieldb111.TextFont.Size = 8;
                    NewFieldb111.TextFont.Bold = true;
                    NewFieldb111.TextFont.CharSet = 162;
                    NewFieldb111.Value = @"FATURA
TOPLAMI";

                    NewFielda111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 7, 116, 15, false);
                    NewFielda111.Name = "NewFielda111";
                    NewFielda111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewFielda111.MultiLine = EvetHayirEnum.ehEvet;
                    NewFielda111.NoClip = EvetHayirEnum.ehEvet;
                    NewFielda111.WordBreak = EvetHayirEnum.ehEvet;
                    NewFielda111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewFielda111.TextFont.Name = "Arial";
                    NewFielda111.TextFont.Size = 8;
                    NewFielda111.TextFont.Bold = true;
                    NewFielda111.TextFont.CharSet = 162;
                    NewFielda111.Value = @"FATURA
SAYISI";

                    NewFieldb1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 7, 160, 15, false);
                    NewFieldb1111.Name = "NewFieldb1111";
                    NewFieldb1111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewFieldb1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewFieldb1111.MultiLine = EvetHayirEnum.ehEvet;
                    NewFieldb1111.NoClip = EvetHayirEnum.ehEvet;
                    NewFieldb1111.WordBreak = EvetHayirEnum.ehEvet;
                    NewFieldb1111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewFieldb1111.TextFont.Name = "Arial";
                    NewFieldb1111.TextFont.Size = 8;
                    NewFieldb1111.TextFont.Bold = true;
                    NewFieldb1111.TextFont.CharSet = 162;
                    NewFieldb1111.Value = @"ÖDENEN
TUTAR";

                    NewFieldb1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 7, 182, 15, false);
                    NewFieldb1211.Name = "NewFieldb1211";
                    NewFieldb1211.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewFieldb1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewFieldb1211.MultiLine = EvetHayirEnum.ehEvet;
                    NewFieldb1211.NoClip = EvetHayirEnum.ehEvet;
                    NewFieldb1211.WordBreak = EvetHayirEnum.ehEvet;
                    NewFieldb1211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewFieldb1211.TextFont.Name = "Arial";
                    NewFieldb1211.TextFont.Size = 8;
                    NewFieldb1211.TextFont.Bold = true;
                    NewFieldb1211.TextFont.CharSet = 162;
                    NewFieldb1211.Value = @"KESİNTİ
TUTARI";

                    NewFieldb1311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 7, 204, 15, false);
                    NewFieldb1311.Name = "NewFieldb1311";
                    NewFieldb1311.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewFieldb1311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewFieldb1311.MultiLine = EvetHayirEnum.ehEvet;
                    NewFieldb1311.NoClip = EvetHayirEnum.ehEvet;
                    NewFieldb1311.WordBreak = EvetHayirEnum.ehEvet;
                    NewFieldb1311.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewFieldb1311.TextFont.Name = "Arial";
                    NewFieldb1311.TextFont.Size = 8;
                    NewFieldb1311.TextFont.Bold = true;
                    NewFieldb1311.TextFont.CharSet = 162;
                    NewFieldb1311.Value = @"KALAN
TUTAR";

                    NewLine1211111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 16, 204, 16, false);
                    NewLine1211111.Name = "NewLine1211111";
                    NewLine1211111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 46, 6, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Yurtdışı Sigorta";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11132111.CalcValue = NewField11132111.Value;
                    NewFieldb111.CalcValue = NewFieldb111.Value;
                    NewFielda111.CalcValue = NewFielda111.Value;
                    NewFieldb1111.CalcValue = NewFieldb1111.Value;
                    NewFieldb1211.CalcValue = NewFieldb1211.Value;
                    NewFieldb1311.CalcValue = NewFieldb1311.Value;
                    NewField1.CalcValue = NewField1.Value;
                    return new TTReportObject[] { NewField11132111,NewFieldb111,NewFielda111,NewFieldb1111,NewFieldb1211,NewFieldb1311,NewField1};
                }
            }
            public partial class PARTDGroupFooter : TTReportSection
            {
                public InvoicedForPayerReport MyParentReport
                {
                    get { return (InvoicedForPayerReport)ParentReport; }
                }
                
                public TTReportField NewField111123111;
                public TTReportField ADET;
                public TTReportField TOPLAM;
                public TTReportField ODENENTUTAR;
                public TTReportField INDIRIMTUTARI;
                public TTReportField KALANTUTAR;
                public TTReportShape NewLine1111111; 
                public PARTDGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField111123111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 2, 102, 6, false);
                    NewField111123111.Name = "NewField111123111";
                    NewField111123111.TextFont.Name = "Arial";
                    NewField111123111.TextFont.Size = 8;
                    NewField111123111.TextFont.Bold = true;
                    NewField111123111.TextFont.CharSet = 162;
                    NewField111123111.Value = @"TOPLAM";

                    ADET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 2, 116, 6, false);
                    ADET.Name = "ADET";
                    ADET.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADET.MultiLine = EvetHayirEnum.ehEvet;
                    ADET.NoClip = EvetHayirEnum.ehEvet;
                    ADET.WordBreak = EvetHayirEnum.ehEvet;
                    ADET.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADET.TextFont.Name = "Arial";
                    ADET.TextFont.Size = 8;
                    ADET.TextFont.CharSet = 162;
                    ADET.Value = @"";

                    TOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 2, 138, 6, false);
                    TOPLAM.Name = "TOPLAM";
                    TOPLAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAM.TextFormat = @"#,##0.#0";
                    TOPLAM.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAM.MultiLine = EvetHayirEnum.ehEvet;
                    TOPLAM.NoClip = EvetHayirEnum.ehEvet;
                    TOPLAM.WordBreak = EvetHayirEnum.ehEvet;
                    TOPLAM.ExpandTabs = EvetHayirEnum.ehEvet;
                    TOPLAM.TextFont.Name = "Arial";
                    TOPLAM.TextFont.Size = 8;
                    TOPLAM.TextFont.CharSet = 162;
                    TOPLAM.Value = @"";

                    ODENENTUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 2, 160, 6, false);
                    ODENENTUTAR.Name = "ODENENTUTAR";
                    ODENENTUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ODENENTUTAR.TextFormat = @"#,##0.#0";
                    ODENENTUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ODENENTUTAR.MultiLine = EvetHayirEnum.ehEvet;
                    ODENENTUTAR.NoClip = EvetHayirEnum.ehEvet;
                    ODENENTUTAR.WordBreak = EvetHayirEnum.ehEvet;
                    ODENENTUTAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    ODENENTUTAR.TextFont.Name = "Arial";
                    ODENENTUTAR.TextFont.Size = 8;
                    ODENENTUTAR.TextFont.CharSet = 162;
                    ODENENTUTAR.Value = @"";

                    INDIRIMTUTARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 2, 182, 6, false);
                    INDIRIMTUTARI.Name = "INDIRIMTUTARI";
                    INDIRIMTUTARI.FieldType = ReportFieldTypeEnum.ftVariable;
                    INDIRIMTUTARI.TextFormat = @"#,##0.#0";
                    INDIRIMTUTARI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    INDIRIMTUTARI.MultiLine = EvetHayirEnum.ehEvet;
                    INDIRIMTUTARI.NoClip = EvetHayirEnum.ehEvet;
                    INDIRIMTUTARI.WordBreak = EvetHayirEnum.ehEvet;
                    INDIRIMTUTARI.ExpandTabs = EvetHayirEnum.ehEvet;
                    INDIRIMTUTARI.TextFont.Name = "Arial";
                    INDIRIMTUTARI.TextFont.Size = 8;
                    INDIRIMTUTARI.TextFont.CharSet = 162;
                    INDIRIMTUTARI.Value = @"";

                    KALANTUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 2, 204, 6, false);
                    KALANTUTAR.Name = "KALANTUTAR";
                    KALANTUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KALANTUTAR.TextFormat = @"#,##0.#0";
                    KALANTUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    KALANTUTAR.MultiLine = EvetHayirEnum.ehEvet;
                    KALANTUTAR.NoClip = EvetHayirEnum.ehEvet;
                    KALANTUTAR.WordBreak = EvetHayirEnum.ehEvet;
                    KALANTUTAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    KALANTUTAR.TextFont.Name = "Arial";
                    KALANTUTAR.TextFont.Size = 8;
                    KALANTUTAR.TextFont.CharSet = 162;
                    KALANTUTAR.Value = @"";

                    NewLine1111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 103, 1, 204, 1, false);
                    NewLine1111111.Name = "NewLine1111111";
                    NewLine1111111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111123111.CalcValue = NewField111123111.Value;
                    ADET.CalcValue = @"";
                    TOPLAM.CalcValue = @"";
                    ODENENTUTAR.CalcValue = @"";
                    INDIRIMTUTARI.CalcValue = @"";
                    KALANTUTAR.CalcValue = @"";
                    return new TTReportObject[] { NewField111123111,ADET,TOPLAM,ODENENTUTAR,INDIRIMTUTARI,KALANTUTAR};
                }

                public override void RunScript()
                {
#region PARTD FOOTER_Script
                    this.ADET.CalcValue = (((InvoicedForPayerReport)ParentReport).toplamHastaSayisi).ToString();
            this.TOPLAM.CalcValue = (((InvoicedForPayerReport)ParentReport).toplamFaturaToplami).ToString();
            this.ODENENTUTAR.CalcValue = (((InvoicedForPayerReport)ParentReport).toplamOdenenTutar).ToString();
            this.INDIRIMTUTARI.CalcValue = (((InvoicedForPayerReport)ParentReport).toplamIndirimTutari).ToString();
            this.KALANTUTAR.CalcValue = (((InvoicedForPayerReport)ParentReport).toplamKalanTutar).ToString();
            
            ((InvoicedForPayerReport)ParentReport).toplamHastaSayisi = 0;
            ((InvoicedForPayerReport)ParentReport).toplamFaturaToplami = 0;
            ((InvoicedForPayerReport)ParentReport).toplamOdenenTutar = 0;
            ((InvoicedForPayerReport)ParentReport).toplamIndirimTutari = 0;
            ((InvoicedForPayerReport)ParentReport).toplamKalanTutar = 0;
            ((InvoicedForPayerReport)ParentReport).yazdirmaSayac = 0;
            (((InvoicedForPayerReport)ParentReport).yurtdisiKurumFaturaBilgisi).Clear();
#endregion PARTD FOOTER_Script
                }
            }

        }

        public PARTDGroup PARTD;

        public partial class PARTCGroup : TTReportGroup
        {
            public InvoicedForPayerReport MyParentReport
            {
                get { return (InvoicedForPayerReport)ParentReport; }
            }

            new public PARTCGroupBody Body()
            {
                return (PARTCGroupBody)_body;
            }
            public TTReportField ADET { get {return Body().ADET;} }
            public TTReportField TOPLAM { get {return Body().TOPLAM;} }
            public TTReportField KURUMADI { get {return Body().KURUMADI;} }
            public TTReportField ODENENTUTAR { get {return Body().ODENENTUTAR;} }
            public TTReportField INDIRIMTUTARI { get {return Body().INDIRIMTUTARI;} }
            public TTReportField KALANTUTAR { get {return Body().KALANTUTAR;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTCGroupBody(this);
            }

            public partial class PARTCGroupBody : TTReportSection
            {
                public InvoicedForPayerReport MyParentReport
                {
                    get { return (InvoicedForPayerReport)ParentReport; }
                }
                
                public TTReportField ADET;
                public TTReportField TOPLAM;
                public TTReportField KURUMADI;
                public TTReportField ODENENTUTAR;
                public TTReportField INDIRIMTUTARI;
                public TTReportField KALANTUTAR; 
                public PARTCGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    ADET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 1, 116, 5, false);
                    ADET.Name = "ADET";
                    ADET.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADET.MultiLine = EvetHayirEnum.ehEvet;
                    ADET.NoClip = EvetHayirEnum.ehEvet;
                    ADET.WordBreak = EvetHayirEnum.ehEvet;
                    ADET.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADET.TextFont.Name = "Arial";
                    ADET.TextFont.Size = 8;
                    ADET.TextFont.CharSet = 162;
                    ADET.Value = @"";

                    TOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 1, 138, 5, false);
                    TOPLAM.Name = "TOPLAM";
                    TOPLAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAM.TextFormat = @"#,##0.#0";
                    TOPLAM.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAM.MultiLine = EvetHayirEnum.ehEvet;
                    TOPLAM.NoClip = EvetHayirEnum.ehEvet;
                    TOPLAM.WordBreak = EvetHayirEnum.ehEvet;
                    TOPLAM.ExpandTabs = EvetHayirEnum.ehEvet;
                    TOPLAM.TextFont.Name = "Arial";
                    TOPLAM.TextFont.Size = 8;
                    TOPLAM.TextFont.CharSet = 162;
                    TOPLAM.Value = @"";

                    KURUMADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 102, 5, false);
                    KURUMADI.Name = "KURUMADI";
                    KURUMADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMADI.MultiLine = EvetHayirEnum.ehEvet;
                    KURUMADI.NoClip = EvetHayirEnum.ehEvet;
                    KURUMADI.WordBreak = EvetHayirEnum.ehEvet;
                    KURUMADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    KURUMADI.TextFont.Name = "Arial";
                    KURUMADI.TextFont.Size = 8;
                    KURUMADI.TextFont.CharSet = 162;
                    KURUMADI.Value = @"";

                    ODENENTUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 1, 160, 5, false);
                    ODENENTUTAR.Name = "ODENENTUTAR";
                    ODENENTUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ODENENTUTAR.TextFormat = @"#,##0.#0";
                    ODENENTUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ODENENTUTAR.MultiLine = EvetHayirEnum.ehEvet;
                    ODENENTUTAR.NoClip = EvetHayirEnum.ehEvet;
                    ODENENTUTAR.WordBreak = EvetHayirEnum.ehEvet;
                    ODENENTUTAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    ODENENTUTAR.TextFont.Name = "Arial";
                    ODENENTUTAR.TextFont.Size = 8;
                    ODENENTUTAR.TextFont.CharSet = 162;
                    ODENENTUTAR.Value = @"";

                    INDIRIMTUTARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 1, 182, 5, false);
                    INDIRIMTUTARI.Name = "INDIRIMTUTARI";
                    INDIRIMTUTARI.FieldType = ReportFieldTypeEnum.ftVariable;
                    INDIRIMTUTARI.TextFormat = @"#,##0.#0";
                    INDIRIMTUTARI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    INDIRIMTUTARI.MultiLine = EvetHayirEnum.ehEvet;
                    INDIRIMTUTARI.NoClip = EvetHayirEnum.ehEvet;
                    INDIRIMTUTARI.WordBreak = EvetHayirEnum.ehEvet;
                    INDIRIMTUTARI.ExpandTabs = EvetHayirEnum.ehEvet;
                    INDIRIMTUTARI.TextFont.Name = "Arial";
                    INDIRIMTUTARI.TextFont.Size = 8;
                    INDIRIMTUTARI.TextFont.CharSet = 162;
                    INDIRIMTUTARI.Value = @"";

                    KALANTUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 1, 204, 5, false);
                    KALANTUTAR.Name = "KALANTUTAR";
                    KALANTUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KALANTUTAR.TextFormat = @"#,##0.#0";
                    KALANTUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    KALANTUTAR.MultiLine = EvetHayirEnum.ehEvet;
                    KALANTUTAR.NoClip = EvetHayirEnum.ehEvet;
                    KALANTUTAR.WordBreak = EvetHayirEnum.ehEvet;
                    KALANTUTAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    KALANTUTAR.TextFont.Name = "Arial";
                    KALANTUTAR.TextFont.Size = 8;
                    KALANTUTAR.TextFont.CharSet = 162;
                    KALANTUTAR.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ADET.CalcValue = @"";
                    TOPLAM.CalcValue = @"";
                    KURUMADI.CalcValue = @"";
                    ODENENTUTAR.CalcValue = @"";
                    INDIRIMTUTARI.CalcValue = @"";
                    KALANTUTAR.CalcValue = @"";
                    return new TTReportObject[] { ADET,TOPLAM,KURUMADI,ODENENTUTAR,INDIRIMTUTARI,KALANTUTAR};
                }

                public override void RunScript()
                {
#region PARTC BODY_Script
                    List<KurumFatura> yurtdisiKurumFaturaBilgisi = ((InvoicedForPayerReport)ParentReport).yurtdisiKurumFaturaBilgisi;
            int yazdirmaSayac = ((InvoicedForPayerReport)ParentReport).yazdirmaSayac;
            if(yurtdisiKurumFaturaBilgisi.Count > 0)
            {
                KurumFatura yurtdisiKurumFatura = yurtdisiKurumFaturaBilgisi[yazdirmaSayac];
                this.KURUMADI.CalcValue = yurtdisiKurumFatura.kurumAdi;
                this.ADET.CalcValue = yurtdisiKurumFatura.hastaSayisi.ToString();
                this.TOPLAM.CalcValue = yurtdisiKurumFatura.faturaToplami.ToString();
                this.ODENENTUTAR.CalcValue = yurtdisiKurumFatura.odenenTutar.ToString();
                this.INDIRIMTUTARI.CalcValue = yurtdisiKurumFatura.indirimTutari.ToString();
                this.KALANTUTAR.CalcValue = yurtdisiKurumFatura.kalanTutar.ToString();
                ((InvoicedForPayerReport)ParentReport).toplamHastaSayisi += Convert.ToInt32(this.ADET.CalcValue);
                ((InvoicedForPayerReport)ParentReport).toplamFaturaToplami += Convert.ToDouble(this.TOPLAM.CalcValue);
                ((InvoicedForPayerReport)ParentReport).toplamOdenenTutar += Convert.ToDouble(this.ODENENTUTAR.CalcValue);
                ((InvoicedForPayerReport)ParentReport).toplamIndirimTutari += Convert.ToDouble(this.INDIRIMTUTARI.CalcValue);
                ((InvoicedForPayerReport)ParentReport).toplamKalanTutar += Convert.ToDouble(this.KALANTUTAR.CalcValue);
                ((InvoicedForPayerReport)ParentReport).yazdirmaSayac++;
            }
#endregion PARTC BODY_Script
                }
            }

        }

        public PARTCGroup PARTC;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public InvoicedForPayerReport()
        {
            PARTF = new PARTFGroup(this,"PARTF");
            PARTB = new PARTBGroup(PARTF,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            PARTD = new PARTDGroup(PARTB,"PARTD");
            PARTC = new PARTCGroup(PARTD,"PARTC");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("PAYER", "", "Kurum", @"", false, true, true, new Guid("ea658106-fa2f-4da3-a702-db9139c4e63f"));
            reportParameter.ListDefID = new Guid("61cb92fe-0330-48f5-9e09-674ba7a57b3d");
            reportParameter = Parameters.Add("PAYERFLAG", "", "Kurum Kontrol", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("PAYER"))
                _runtimeParameters.PAYER = (List<string>)parameters["PAYER"];
            if (parameters.ContainsKey("PAYERFLAG"))
                _runtimeParameters.PAYERFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PAYERFLAG"]);
            Name = "INVOICEDFORPAYERREPORT";
            Caption = "Kurumlara Kesilen Faturalar Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
        }

        protected TTReportField SetFieldDefaultProperties()
        {
            TTReportField fd = new TTReportField();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.FieldType = ReportFieldTypeEnum.ftConstant;
            fd.CaseFormat = CaseFormatEnum.fcNoChange;
            fd.TextFormat = "";
            fd.TextColor = System.Drawing.Color.Black;
            fd.FontAngle = 0;
            fd.HorzAlign = HorizontalAlignmentEnum.haleft;
            fd.VertAlign = VerticalAlignmentEnum.vaTop;
            fd.MultiLine = EvetHayirEnum.ehHayir;
            fd.NoClip = EvetHayirEnum.ehHayir;
            fd.WordBreak = EvetHayirEnum.ehHayir;
            fd.ExpandTabs = EvetHayirEnum.ehHayir;
            fd.CrossTabRole = CrosstabRoleEnum.ctrNone;
            fd.CrossTabValues = "";
            fd.ExcelCol = 0;
            fd.ObjectDefName = "";
            fd.DataMember = "";
            fd.TextFont.Name = "Arial Narrow";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 1;
            return fd;
        }

        protected TTReportRTF SetRTFDefaultProperties()
        {
            TTReportRTF fd = new TTReportRTF();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportHTML SetHTMLDefaultProperties()
        {
            TTReportHTML fd = new TTReportHTML();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportShape SetShapeDefaultProperties()
        {
            TTReportShape fd = new TTReportShape();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbSolid;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;
            return fd;
        }

    }
}