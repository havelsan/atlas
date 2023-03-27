
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
    /// Mutemetlikler Tahsilat Ve Ödeme Defteri
    /// </summary>
    public partial class CashOfficeRevenueReport : TTReport
    {
        #region Methods
        List<ReceiptDetail> receiptDetailList = new List<ReceiptDetail>();

        class ReceiptDetail
        {
            public string ObjectId;
            public string AccountCode;
            public Currency Price;
        }

        string firstDocumentNo = string.Empty;
        string lastDocumentNo = string.Empty;
        int mainDataCounter = 0;
        Currency CashTotal = 0;
        Currency CreditCardTotal = 0;
        Currency Total = 0;

        Currency T600_01_01_01 = 0;
        Currency T600_01_01_02 = 0;
        Currency T600_01_02_01 = 0;
        Currency T600_01_02_02 = 0;
        Currency T600_01_02_04 = 0;
        Currency T600_01_03_01 = 0;
        Currency T600_01_03_02 = 0;
        Currency T600_01_04_01 = 0;
        Currency T600_01_04_02 = 0;
        Currency T600_01_01_04_01 = 0;
        Currency T600_01_05_01 = 0;
        Currency T600_01_05_02 = 0;
        Currency T600_01_06_01 = 0;
        Currency T600_01_07_01 = 0;
        Currency T600_01_08_01 = 0;
        Currency T600_01_08_02 = 0;
        Currency T600_01_99 = 0;

        // Sağlık Turizm Uygulaması için yukarıdaki hesapların 601 ile başlayanları
        Currency T601_01_01_01 = 0;
        Currency T601_01_01_02 = 0;
        Currency T601_01_02_01 = 0;
        Currency T601_01_02_02 = 0;
        Currency T601_01_03_01 = 0;
        Currency T601_01_03_02 = 0;
        Currency T601_01_04_01 = 0;
        Currency T601_01_04_02 = 0;
        Currency T601_01_01_04_01 = 0;
        Currency T601_01_05_01 = 0;
        Currency T601_01_05_02 = 0;
        Currency T601_01_06_01 = 0;
        Currency T601_01_07_01 = 0;
        Currency T601_01_08_01 = 0;
        Currency T601_01_08_02 = 0;
        Currency T601_01_99 = 0;

        Currency T340_11_01 = 0;
        Currency T195_01 = 0;
        Currency T336_06_01 = 0;
        Currency T336_06_02 = 0;
        Currency T600_01_94 = 0;
        Currency T649_09_09_02 = 0;
        Currency T679_09_9099 = 0;

        #endregion Methods

        public class ReportRuntimeParameters
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public Guid? CASHOFFICE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public int? CASHOFFICECONTROL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public Guid? CASHIER = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public int? CASHIERCONTROL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public PaymentTypeCashCCEnum? PAYMENTTYPE = (PaymentTypeCashCCEnum?)(int?)TTObjectDefManager.Instance.DataTypes["PaymentTypeCashCCEnum"].ConvertValue("");
            public int? PAYMENTTYPECONTROL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public bool? USETIME = (bool?)TTObjectDefManager.Instance.DataTypes["Boolean"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public CashOfficeRevenueReport MyParentReport
            {
                get { return (CashOfficeRevenueReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField STARTDATE { get { return Header().STARTDATE; } }
            public TTReportField ENDDATE { get { return Header().ENDDATE; } }
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
                public CashOfficeRevenueReport MyParentReport
                {
                    get { return (CashOfficeRevenueReport)ParentReport; }
                }

                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;

                    Height = 9;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 2, 26, 7, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    STARTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTDATE.MultiLine = EvetHayirEnum.ehEvet;
                    STARTDATE.WordBreak = EvetHayirEnum.ehEvet;
                    STARTDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 2, 54, 7, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ENDDATE.MultiLine = EvetHayirEnum.ehEvet;
                    ENDDATE.WordBreak = EvetHayirEnum.ehEvet;
                    ENDDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                }


                override public TTReportObject[] GetCalculatedFields()
                {
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    return new TTReportObject[] { STARTDATE, ENDDATE };
                }

                public override void RunScript()
                {
                    #region PARTB HEADER_Script
                    MyParentReport.CashTotal = 0;
                    MyParentReport.CreditCardTotal = 0;
                    MyParentReport.Total = 0;

                    MyParentReport.T600_01_01_01 = 0;
                    MyParentReport.T600_01_01_02 = 0;
                    MyParentReport.T600_01_02_01 = 0;
                    MyParentReport.T600_01_02_02 = 0;
                    MyParentReport.T600_01_02_04 = 0;
                    MyParentReport.T600_01_03_01 = 0;
                    MyParentReport.T600_01_03_02 = 0;
                    MyParentReport.T600_01_04_01 = 0;
                    MyParentReport.T600_01_04_02 = 0;
                    MyParentReport.T600_01_01_04_01 = 0;
                    MyParentReport.T600_01_05_01 = 0;
                    MyParentReport.T600_01_05_02 = 0;
                    MyParentReport.T600_01_06_01 = 0;
                    MyParentReport.T600_01_07_01 = 0;
                    MyParentReport.T600_01_08_01 = 0;
                    MyParentReport.T600_01_08_02 = 0;
                    MyParentReport.T600_01_99 = 0;

                    MyParentReport.T601_01_01_01 = 0;
                    MyParentReport.T601_01_01_02 = 0;
                    MyParentReport.T601_01_02_01 = 0;
                    MyParentReport.T601_01_02_02 = 0;
                    MyParentReport.T601_01_03_01 = 0;
                    MyParentReport.T601_01_03_02 = 0;
                    MyParentReport.T601_01_04_01 = 0;
                    MyParentReport.T601_01_04_02 = 0;
                    MyParentReport.T601_01_01_04_01 = 0;
                    MyParentReport.T601_01_05_01 = 0;
                    MyParentReport.T601_01_05_02 = 0;
                    MyParentReport.T601_01_06_01 = 0;
                    MyParentReport.T601_01_07_01 = 0;
                    MyParentReport.T601_01_08_01 = 0;
                    MyParentReport.T601_01_08_02 = 0;
                    MyParentReport.T601_01_99 = 0;

                    MyParentReport.T340_11_01 = 0;
                    MyParentReport.T195_01 = 0;
                    MyParentReport.T336_06_01 = 0;
                    MyParentReport.T336_06_02 = 0;
                    MyParentReport.T600_01_94 = 0;
                    MyParentReport.T649_09_09_02 = 0;
                    MyParentReport.T679_09_9099 = 0;

                    if (MyParentReport.RuntimeParameters.USETIME != true)
                    {
                        MyParentReport.RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
                        MyParentReport.RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
                    }

                    if (MyParentReport.RuntimeParameters.PAYMENTTYPECONTROL.HasValue == false) // Rapor refresh edildiğinde bu bloğa tekrar girmemesi lazım
                    {
                        if (MyParentReport.RuntimeParameters.PAYMENTTYPE.HasValue)
                            MyParentReport.RuntimeParameters.PAYMENTTYPECONTROL = 1;
                        else
                        {
                            MyParentReport.RuntimeParameters.PAYMENTTYPECONTROL = 0;
                            MyParentReport.RuntimeParameters.PAYMENTTYPE = PaymentTypeCashCCEnum.Cash;
                        }
                    }

                    if (!MyParentReport.RuntimeParameters.CASHOFFICE.HasValue)
                        MyParentReport.RuntimeParameters.CASHOFFICE = Guid.Empty;
                    if (!MyParentReport.RuntimeParameters.CASHIER.HasValue)
                        MyParentReport.RuntimeParameters.CASHIER = Guid.Empty;

                    if (MyParentReport.RuntimeParameters.CASHOFFICE == Guid.Empty)
                        MyParentReport.RuntimeParameters.CASHOFFICECONTROL = 0;
                    else
                        MyParentReport.RuntimeParameters.CASHOFFICECONTROL = 1;

                    if (MyParentReport.RuntimeParameters.CASHIER == Guid.Empty)
                        MyParentReport.RuntimeParameters.CASHIERCONTROL = 0;
                    else
                        MyParentReport.RuntimeParameters.CASHIERCONTROL = 1;

                    MyParentReport.receiptDetailList.Clear();

                    BindingList<ReceiptDocument.CashOfficeRevenueReportDetailQuery_Class> receiptDetailList = ReceiptDocument.CashOfficeRevenueReportDetailQuery(MyParentReport.RuntimeParameters.STARTDATE.Value, MyParentReport.RuntimeParameters.ENDDATE.Value, MyParentReport.RuntimeParameters.CASHOFFICE.Value, MyParentReport.RuntimeParameters.CASHOFFICECONTROL.Value, MyParentReport.RuntimeParameters.CASHIER.Value, MyParentReport.RuntimeParameters.CASHIERCONTROL.Value, MyParentReport.RuntimeParameters.PAYMENTTYPE.Value, MyParentReport.RuntimeParameters.PAYMENTTYPECONTROL.Value);
                    foreach (ReceiptDocument.CashOfficeRevenueReportDetailQuery_Class item in receiptDetailList)
                    {
                        ReceiptDetail receiptDetail = new ReceiptDetail();
                        receiptDetail.ObjectId = item.Receiptobjectid.Value.ToString();
                        receiptDetail.Price = item.PaymentPrice.Value;

                        if (item.Type.Equals("PROCEDURE"))
                        {   // SGK lı hastadan alınmış katılım payı ise
                            if ((item.PayerType == PayerTypeEnum.SGK || item.PayerType == PayerTypeEnum.SGKManual) && (item.Isparticipationshare.ToString().Equals("1") || item.Isparticipationprocedure.ToString().Equals("1")))
                            {
                                if (!string.IsNullOrEmpty(item.MedulaTakipNo)) // Takip numarası var ise Provizyon Alınan SGK Katılım payı olarak gelir
                                {
                                    if (item.Medulaistisnaihalkodu.ToString().Equals("9")) // BKK Prim borçlu ise hesap 600.01.94 olmalı
                                        receiptDetail.AccountCode = "600.01.94";
                                    else
                                        receiptDetail.AccountCode = "336.06.01";
                                }
                                else                                           // Takip numarası yok ise Provizyon Alınmayan SGK Katılım payı sütununa gelir
                                    receiptDetail.AccountCode = "336.06.02";
                            }
                            else
                            {
                                if (item.Accountcode != null)
                                {
                                    receiptDetail.AccountCode = item.Accountcode.ToString();

                                    if (receiptDetail.AccountCode.Equals("600.01.01") || receiptDetail.AccountCode.Equals("600.01.02") || receiptDetail.AccountCode.Equals("600.01.03") || receiptDetail.AccountCode.Equals("600.01.04") || receiptDetail.AccountCode.Equals("600.01.05"))
                                    {
                                        if (item.tedaviTuruKodu.ToString().Equals("A"))
                                            receiptDetail.AccountCode += ".01";
                                        else
                                            receiptDetail.AccountCode += ".02";
                                    }
                                    else if (receiptDetail.AccountCode.Equals("600.01.06") || receiptDetail.AccountCode.Equals("600.01.07"))
                                        receiptDetail.AccountCode += ".01";
                                }
                                else
                                    receiptDetail.AccountCode = "600.01.99";
                            }
                        }
                        else if (item.Type.Equals("MATERIAL"))
                        {
                            if ((item.PayerType == PayerTypeEnum.SGK || item.PayerType == PayerTypeEnum.SGKManual) && item.Isparticipationshare.ToString().Equals("1"))
                            {
                                if (!string.IsNullOrEmpty(item.MedulaTakipNo)) // Takip numarası var ise Provizyon Alınan SGK Katılım payı olarak gelir
                                {
                                    if (item.Medulaistisnaihalkodu.ToString().Equals("9")) // BKK Prim borçlu ise hesap 600.01.94 olmalı
                                        receiptDetail.AccountCode = "600.01.94";
                                    else
                                        receiptDetail.AccountCode = "336.06.01";
                                }
                                else                                           // Takip numarası yok ise Provizyon Alınmayan SGK Katılım payı sütununa gelir
                                    receiptDetail.AccountCode = "336.06.02";
                            }
                            else if (item.Materialobjectdefname.Equals("DRUGDEFINITION") || item.Materialobjectdefname.Equals("MAGISTRALPREPARATIONDEFINITION"))
                                receiptDetail.AccountCode = "600.01.08.01";
                            else
                                receiptDetail.AccountCode = "600.01.08.02";
                        }

                        if (receiptDetail.AccountCode.StartsWith("600.") && item.Ishealthtourism.ToString().Equals("1") && receiptDetail.AccountCode != "600.01.94")
                            receiptDetail.AccountCode = "601." + receiptDetail.AccountCode.Substring(4, receiptDetail.AccountCode.Length - 4);

                        MyParentReport.receiptDetailList.Add(receiptDetail);
                    }
                    #endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public CashOfficeRevenueReport MyParentReport
                {
                    get { return (CashOfficeRevenueReport)ParentReport; }
                }

                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
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
            public CashOfficeRevenueReport MyParentReport
            {
                get { return (CashOfficeRevenueReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField13 { get { return Header().NewField13; } }
            public TTReportField STARTDATE { get { return Header().STARTDATE; } }
            public TTReportField NewField14 { get { return Header().NewField14; } }
            public TTReportField CLOSINGDATE { get { return Header().CLOSINGDATE; } }
            public TTReportField NewField16 { get { return Header().NewField16; } }
            public TTReportField NewField17 { get { return Header().NewField17; } }
            public TTReportField NewField181 { get { return Header().NewField181; } }
            public TTReportField NewField1181 { get { return Header().NewField1181; } }
            public TTReportField CASHOFFICE { get { return Header().CASHOFFICE; } }
            public TTReportField NewField191 { get { return Header().NewField191; } }
            public TTReportField NewField11811 { get { return Header().NewField11811; } }
            public TTReportField CASHIER { get { return Header().CASHIER; } }
            public TTReportField HOSPITALNAME { get { return Header().HOSPITALNAME; } }
            public TTReportShape NewLine1 { get { return Header().NewLine1; } }
            public TTReportShape NewLine111 { get { return Header().NewLine111; } }
            public TTReportField PAGE { get { return Header().PAGE; } }
            public TTReportField NewField15 { get { return Header().NewField15; } }
            public TTReportShape NewLine1111 { get { return Header().NewLine1111; } }
            public TTReportShape NewLine1112 { get { return Header().NewLine1112; } }
            public TTReportShape NewLine13111 { get { return Header().NewLine13111; } }
            public TTReportShape NewLine11 { get { return Header().NewLine11; } }
            public TTReportField NewField161 { get { return Header().NewField161; } }
            public TTReportField NewField1161 { get { return Header().NewField1161; } }
            public TTReportShape NewLine13113 { get { return Header().NewLine13113; } }
            public TTReportShape NewLine131131 { get { return Header().NewLine131131; } }
            public TTReportShape NewLine131132 { get { return Header().NewLine131132; } }
            public TTReportShape NewLine131134 { get { return Header().NewLine131134; } }
            public TTReportShape NewLine1431131 { get { return Header().NewLine1431131; } }
            public TTReportShape NewLine11311341 { get { return Header().NewLine11311341; } }
            public TTReportShape NewLine114311311 { get { return Header().NewLine114311311; } }
            public TTReportShape NewLine1231131 { get { return Header().NewLine1231131; } }
            public TTReportShape NewLine1131131 { get { return Header().NewLine1131131; } }
            public TTReportShape NewLine1231132 { get { return Header().NewLine1231132; } }
            public TTReportShape NewLine11311321 { get { return Header().NewLine11311321; } }
            public TTReportShape NewLine1131132 { get { return Header().NewLine1131132; } }
            public TTReportShape NewLine1231133 { get { return Header().NewLine1231133; } }
            public TTReportShape NewLine1113113411 { get { return Header().NewLine1113113411; } }
            public TTReportShape NewLine11311322 { get { return Header().NewLine11311322; } }
            public TTReportShape NewLine1131133 { get { return Header().NewLine1131133; } }
            public TTReportShape NewLine1113113412 { get { return Header().NewLine1113113412; } }
            public TTReportField NewField11466154 { get { return Header().NewField11466154; } }
            public TTReportField NewField1162 { get { return Header().NewField1162; } }
            public TTReportField NewField12611 { get { return Header().NewField12611; } }
            public TTReportField NewField12612 { get { return Header().NewField12612; } }
            public TTReportShape NewLine1131134 { get { return Header().NewLine1131134; } }
            public TTReportShape NewLine1431132 { get { return Header().NewLine1431132; } }
            public TTReportShape NewLine11311342 { get { return Header().NewLine11311342; } }
            public TTReportShape NewLine114311312 { get { return Header().NewLine114311312; } }
            public TTReportShape NewLine1113113413 { get { return Header().NewLine1113113413; } }
            public TTReportShape NewLine131133 { get { return Header().NewLine131133; } }
            public TTReportShape NewLine1431133 { get { return Header().NewLine1431133; } }
            public TTReportShape NewLine11311343 { get { return Header().NewLine11311343; } }
            public TTReportShape NewLine114311313 { get { return Header().NewLine114311313; } }
            public TTReportShape NewLine13311321 { get { return Header().NewLine13311321; } }
            public TTReportField CASHOFFICEOBJECTID { get { return Header().CASHOFFICEOBJECTID; } }
            public TTReportField CASHIEROBJECTID { get { return Header().CASHIEROBJECTID; } }
            public TTReportField NewField1191 { get { return Header().NewField1191; } }
            public TTReportField NewField111811 { get { return Header().NewField111811; } }
            public TTReportField PAYMENTTYPE { get { return Header().PAYMENTTYPE; } }
            public TTReportField G326_01_120 { get { return Header().G326_01_120; } }
            public TTReportShape NewLine2 { get { return Header().NewLine2; } }
            public TTReportField G326_01_1021 { get { return Header().G326_01_1021; } }
            public TTReportField G326_01_1022 { get { return Header().G326_01_1022; } }
            public TTReportField G326_01_11201 { get { return Header().G326_01_11201; } }
            public TTReportField G326_01_1023 { get { return Header().G326_01_1023; } }
            public TTReportField G326_01_13201 { get { return Header().G326_01_13201; } }
            public TTReportField G326_01_13202 { get { return Header().G326_01_13202; } }
            public TTReportField G326_01_110231 { get { return Header().G326_01_110231; } }
            public TTReportField G326_01_13203 { get { return Header().G326_01_13203; } }
            public TTReportField G326_01_130231 { get { return Header().G326_01_130231; } }
            public TTReportField G326_01_130232 { get { return Header().G326_01_130232; } }
            public TTReportField G326_01_1132031 { get { return Header().G326_01_1132031; } }
            public TTReportField G326_01_130233 { get { return Header().G326_01_130233; } }
            public TTReportField G326_01_1332031 { get { return Header().G326_01_1332031; } }
            public TTReportField G326_01_1332032 { get { return Header().G326_01_1332032; } }
            public TTReportField G326_01_11302331 { get { return Header().G326_01_11302331; } }
            public TTReportField G326_01_1332033 { get { return Header().G326_01_1332033; } }
            public TTReportField G326_01_13302331 { get { return Header().G326_01_13302331; } }
            public TTReportField G326_01_1332034 { get { return Header().G326_01_1332034; } }
            public TTReportField G326_01_14302331 { get { return Header().G326_01_14302331; } }
            public TTReportField G326_01_14302332 { get { return Header().G326_01_14302332; } }
            public TTReportField G326_01_123320341 { get { return Header().G326_01_123320341; } }
            public TTReportField G326_01_14302333 { get { return Header().G326_01_14302333; } }
            public TTReportField G326_01_133320341 { get { return Header().G326_01_133320341; } }
            public TTReportField G326_01_133320342 { get { return Header().G326_01_133320342; } }
            public TTReportField G326_01_1243023331 { get { return Header().G326_01_1243023331; } }
            public TTReportField G326_0 { get { return Header().G326_0; } }
            public TTReportField G326_10 { get { return Header().G326_10; } }
            public TTReportField G326_11 { get { return Header().G326_11; } }
            public TTReportField G326_111 { get { return Header().G326_111; } }
            public TTReportField G326_112 { get { return Header().G326_112; } }
            public TTReportField G326_1211 { get { return Header().G326_1211; } }
            public TTReportField lblNakit { get { return Header().lblNakit; } }
            public TTReportField lblKK { get { return Header().lblKK; } }
            public TTReportField G326_01_1142011 { get { return Header().G326_01_1142011; } }
            public TTReportField G326_01_1142012 { get { return Header().G326_01_1142012; } }
            public TTReportField G326_01_1142013 { get { return Header().G326_01_1142013; } }
            public TTReportField G326_01_13102411 { get { return Header().G326_01_13102411; } }
            public TTReportField G326_01_11102411 { get { return Header().G326_01_11102411; } }
            public TTReportField G326_01_111420111 { get { return Header().G326_01_111420111; } }
            public TTReportField G326_01_18 { get { return Header().G326_01_18; } }
            public TTReportShape NewLine3 { get { return Header().NewLine3; } }
            public TTReportField G326_01_13102412 { get { return Header().G326_01_13102412; } }
            public TTReportField NewField11611 { get { return Header().NewField11611; } }
            public TTReportField lbl600_01_02_04 { get { return Header().lbl600_01_02_04; } }
            public TTReportField T600_01_01_01 { get { return Footer().T600_01_01_01; } }
            public TTReportField T600_01_01_02 { get { return Footer().T600_01_01_02; } }
            public TTReportField T600_01_02_01 { get { return Footer().T600_01_02_01; } }
            public TTReportField T600_01_02_02 { get { return Footer().T600_01_02_02; } }
            public TTReportField T600_01_03_01 { get { return Footer().T600_01_03_01; } }
            public TTReportField T600_01_03_02 { get { return Footer().T600_01_03_02; } }
            public TTReportField T600_01_05_02 { get { return Footer().T600_01_05_02; } }
            public TTReportField T600_01_01_04_01 { get { return Footer().T600_01_01_04_01; } }
            public TTReportField T600_01_04_02 { get { return Footer().T600_01_04_02; } }
            public TTReportField T600_01_04_01 { get { return Footer().T600_01_04_01; } }
            public TTReportField T600_01_06_01 { get { return Footer().T600_01_06_01; } }
            public TTReportField T600_01_05_01 { get { return Footer().T600_01_05_01; } }
            public TTReportField T195_01 { get { return Footer().T195_01; } }
            public TTReportField T340_11_01 { get { return Footer().T340_11_01; } }
            public TTReportField T600_01_94 { get { return Footer().T600_01_94; } }
            public TTReportField T336_06_01 { get { return Footer().T336_06_01; } }
            public TTReportField T600_01_99 { get { return Footer().T600_01_99; } }
            public TTReportField T600_01_08_02 { get { return Footer().T600_01_08_02; } }
            public TTReportField T600_01_08_01 { get { return Footer().T600_01_08_01; } }
            public TTReportField T600_01_07_01 { get { return Footer().T600_01_07_01; } }
            public TTReportField T649_09_09_02 { get { return Footer().T649_09_09_02; } }
            public TTReportField T679_09_9099 { get { return Footer().T679_09_9099; } }
            public TTReportField TTOTAL { get { return Footer().TTOTAL; } }
            public TTReportField TOPLAM { get { return Footer().TOPLAM; } }
            public TTReportField LBL1 { get { return Footer().LBL1; } }
            public TTReportField LBL2 { get { return Footer().LBL2; } }
            public TTReportField LBL3 { get { return Footer().LBL3; } }
            public TTReportField CASHTOTAL { get { return Footer().CASHTOTAL; } }
            public TTReportField CREDITCARDTOTAL { get { return Footer().CREDITCARDTOTAL; } }
            public TTReportField TOTAL { get { return Footer().TOTAL; } }
            public TTReportField T601_01_01_01 { get { return Footer().T601_01_01_01; } }
            public TTReportField T601_01_01_02 { get { return Footer().T601_01_01_02; } }
            public TTReportField T601_01_02_01 { get { return Footer().T601_01_02_01; } }
            public TTReportField T601_01_02_02 { get { return Footer().T601_01_02_02; } }
            public TTReportField T601_01_03_01 { get { return Footer().T601_01_03_01; } }
            public TTReportField T601_01_03_02 { get { return Footer().T601_01_03_02; } }
            public TTReportField T601_01_05_02 { get { return Footer().T601_01_05_02; } }
            public TTReportField T601_01_01_04_01 { get { return Footer().T601_01_01_04_01; } }
            public TTReportField T601_01_04_02 { get { return Footer().T601_01_04_02; } }
            public TTReportField T601_01_04_01 { get { return Footer().T601_01_04_01; } }
            public TTReportField T601_01_06_01 { get { return Footer().T601_01_06_01; } }
            public TTReportField T601_01_05_01 { get { return Footer().T601_01_05_01; } }
            public TTReportField T601_01_99 { get { return Footer().T601_01_99; } }
            public TTReportField T601_01_08_02 { get { return Footer().T601_01_08_02; } }
            public TTReportField T601_01_08_01 { get { return Footer().T601_01_08_01; } }
            public TTReportField T601_01_07_01 { get { return Footer().T601_01_07_01; } }
            public TTReportField BOS3 { get { return Footer().BOS3; } }
            public TTReportField BOS4 { get { return Footer().BOS4; } }
            public TTReportField T336_06_02 { get { return Footer().T336_06_02; } }
            public TTReportField BOS5 { get { return Footer().BOS5; } }
            public TTReportField BOS6 { get { return Footer().BOS6; } }
            public TTReportField BOS2 { get { return Footer().BOS2; } }
            public TTReportField NewField1 { get { return Footer().NewField1; } }
            public TTReportField DOCUMENTNORANGE { get { return Footer().DOCUMENTNORANGE; } }
            public TTReportField DATERANGE { get { return Footer().DATERANGE; } }
            public TTReportField TCASH { get { return Footer().TCASH; } }
            public TTReportField TCC { get { return Footer().TCC; } }
            public TTReportField T600_01_02_04 { get { return Footer().T600_01_02_04; } }
            public TTReportField BOS1 { get { return Footer().BOS1; } }
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
                public CashOfficeRevenueReport MyParentReport
                {
                    get { return (CashOfficeRevenueReport)ParentReport; }
                }

                public TTReportField NewField13;
                public TTReportField STARTDATE;
                public TTReportField NewField14;
                public TTReportField CLOSINGDATE;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField181;
                public TTReportField NewField1181;
                public TTReportField CASHOFFICE;
                public TTReportField NewField191;
                public TTReportField NewField11811;
                public TTReportField CASHIER;
                public TTReportField HOSPITALNAME;
                public TTReportShape NewLine1;
                public TTReportShape NewLine111;
                public TTReportField PAGE;
                public TTReportField NewField15;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine1112;
                public TTReportShape NewLine13111;
                public TTReportShape NewLine11;
                public TTReportField NewField161;
                public TTReportField NewField1161;
                public TTReportShape NewLine13113;
                public TTReportShape NewLine131131;
                public TTReportShape NewLine131132;
                public TTReportShape NewLine131134;
                public TTReportShape NewLine1431131;
                public TTReportShape NewLine11311341;
                public TTReportShape NewLine114311311;
                public TTReportShape NewLine1231131;
                public TTReportShape NewLine1131131;
                public TTReportShape NewLine1231132;
                public TTReportShape NewLine11311321;
                public TTReportShape NewLine1131132;
                public TTReportShape NewLine1231133;
                public TTReportShape NewLine1113113411;
                public TTReportShape NewLine11311322;
                public TTReportShape NewLine1131133;
                public TTReportShape NewLine1113113412;
                public TTReportField NewField11466154;
                public TTReportField NewField1162;
                public TTReportField NewField12611;
                public TTReportField NewField12612;
                public TTReportShape NewLine1131134;
                public TTReportShape NewLine1431132;
                public TTReportShape NewLine11311342;
                public TTReportShape NewLine114311312;
                public TTReportShape NewLine1113113413;
                public TTReportShape NewLine131133;
                public TTReportShape NewLine1431133;
                public TTReportShape NewLine11311343;
                public TTReportShape NewLine114311313;
                public TTReportShape NewLine13311321;
                public TTReportField CASHOFFICEOBJECTID;
                public TTReportField CASHIEROBJECTID;
                public TTReportField NewField1191;
                public TTReportField NewField111811;
                public TTReportField PAYMENTTYPE;
                public TTReportField G326_01_120;
                public TTReportShape NewLine2;
                public TTReportField G326_01_1021;
                public TTReportField G326_01_1022;
                public TTReportField G326_01_11201;
                public TTReportField G326_01_1023;
                public TTReportField G326_01_13201;
                public TTReportField G326_01_13202;
                public TTReportField G326_01_110231;
                public TTReportField G326_01_13203;
                public TTReportField G326_01_130231;
                public TTReportField G326_01_130232;
                public TTReportField G326_01_1132031;
                public TTReportField G326_01_130233;
                public TTReportField G326_01_1332031;
                public TTReportField G326_01_1332032;
                public TTReportField G326_01_11302331;
                public TTReportField G326_01_1332033;
                public TTReportField G326_01_13302331;
                public TTReportField G326_01_1332034;
                public TTReportField G326_01_14302331;
                public TTReportField G326_01_14302332;
                public TTReportField G326_01_123320341;
                public TTReportField G326_01_14302333;
                public TTReportField G326_01_133320341;
                public TTReportField G326_01_133320342;
                public TTReportField G326_01_1243023331;
                public TTReportField G326_0;
                public TTReportField G326_10;
                public TTReportField G326_11;
                public TTReportField G326_111;
                public TTReportField G326_112;
                public TTReportField G326_1211;
                public TTReportField lblNakit;
                public TTReportField lblKK;
                public TTReportField G326_01_1142011;
                public TTReportField G326_01_1142012;
                public TTReportField G326_01_1142013;
                public TTReportField G326_01_13102411;
                public TTReportField G326_01_11102411;
                public TTReportField G326_01_111420111;
                public TTReportField G326_01_18;
                public TTReportShape NewLine3;
                public TTReportField G326_01_13102412;
                public TTReportField NewField11611;
                public TTReportField lbl600_01_02_04;
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;

                    Height = 76;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 8, 296, 13, false);
                    NewField13.Name = "NewField13";
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.TextFont.Size = 11;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"MUTEMETLİKLER TAHSİLAT VE ÖDEME DEFTERİ";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 13, 44, 17, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.Value = @"{@STARTDATE@}";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 13, 48, 17, false);
                    NewField14.Name = "NewField14";
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.Value = @"-";

                    CLOSINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 13, 70, 17, false);
                    CLOSINGDATE.Name = "CLOSINGDATE";
                    CLOSINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLOSINGDATE.TextFormat = @"dd/MM/yyyy";
                    CLOSINGDATE.Value = @"{@ENDDATE@}";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 13, 23, 17, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"Tarih";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 17, 23, 21, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"Vezne";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 13, 27, 17, false);
                    NewField181.Name = "NewField181";
                    NewField181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField181.TextFont.Bold = true;
                    NewField181.TextFont.CharSet = 162;
                    NewField181.Value = @":";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 17, 27, 21, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1181.TextFont.Bold = true;
                    NewField1181.TextFont.CharSet = 162;
                    NewField1181.Value = @":";

                    CASHOFFICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 17, 186, 21, false);
                    CASHOFFICE.Name = "CASHOFFICE";
                    CASHOFFICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHOFFICE.Value = @"";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 21, 23, 25, false);
                    NewField191.Name = "NewField191";
                    NewField191.TextFont.Bold = true;
                    NewField191.TextFont.CharSet = 162;
                    NewField191.Value = @"Veznedar";

                    NewField11811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 21, 27, 25, false);
                    NewField11811.Name = "NewField11811";
                    NewField11811.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11811.TextFont.Bold = true;
                    NewField11811.TextFont.CharSet = 162;
                    NewField11811.Value = @":";

                    CASHIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 21, 186, 25, false);
                    CASHIER.Name = "CASHIER";
                    CASHIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIER.Value = @"";

                    HOSPITALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 4, 296, 8, false);
                    HOSPITALNAME.Name = "HOSPITALNAME";
                    HOSPITALNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITALNAME.TextFont.Bold = true;
                    HOSPITALNAME.TextFont.CharSet = 162;
                    HOSPITALNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 30, 296, 30, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 30, 6, 77, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.ExtendTo = ExtendToEnum.extSectionHeight;

                    PAGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 276, 23, 291, 28, false);
                    PAGE.Name = "PAGE";
                    PAGE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGE.Value = @"{@pagenumber@} / {@pagecount@}";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 260, 23, 274, 28, false);
                    NewField15.Name = "NewField15";
                    NewField15.Value = @"Sayfa No :";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 30, 18, 77, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 33, 30, 33, 77, false);
                    NewLine1112.Name = "NewLine1112";
                    NewLine1112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1112.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine13111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 57, 30, 57, 77, false);
                    NewLine13111.Name = "NewLine13111";
                    NewLine13111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13111.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 57, 38, 296, 38, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 32, 214, 37, false);
                    NewField161.Name = "NewField161";
                    NewField161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField161.TextFont.Size = 8;
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"GELİRLER";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 32, 267, 37, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1161.TextFont.Size = 8;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"EMANETLER";

                    NewLine13113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 62, 38, 62, 77, false);
                    NewLine13113.Name = "NewLine13113";
                    NewLine13113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13113.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine131131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 107, 38, 107, 77, false);
                    NewLine131131.Name = "NewLine131131";
                    NewLine131131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine131131.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine131132 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 116, 38, 116, 77, false);
                    NewLine131132.Name = "NewLine131132";
                    NewLine131132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine131132.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine131134 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 71, 38, 71, 77, false);
                    NewLine131134.Name = "NewLine131134";
                    NewLine131134.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine131134.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1431131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 80, 38, 80, 77, false);
                    NewLine1431131.Name = "NewLine1431131";
                    NewLine1431131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1431131.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine11311341 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 89, 38, 89, 77, false);
                    NewLine11311341.Name = "NewLine11311341";
                    NewLine11311341.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11311341.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine114311311 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 98, 38, 98, 77, false);
                    NewLine114311311.Name = "NewLine114311311";
                    NewLine114311311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine114311311.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1231131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 125, 38, 125, 77, false);
                    NewLine1231131.Name = "NewLine1231131";
                    NewLine1231131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1231131.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1131131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 134, 38, 134, 77, false);
                    NewLine1131131.Name = "NewLine1131131";
                    NewLine1131131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1131131.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1231132 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 143, 38, 143, 77, false);
                    NewLine1231132.Name = "NewLine1231132";
                    NewLine1231132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1231132.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine11311321 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 152, 38, 152, 77, false);
                    NewLine11311321.Name = "NewLine11311321";
                    NewLine11311321.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11311321.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1131132 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 179, 38, 179, 77, false);
                    NewLine1131132.Name = "NewLine1131132";
                    NewLine1131132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1131132.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1231133 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 188, 38, 188, 77, false);
                    NewLine1231133.Name = "NewLine1231133";
                    NewLine1231133.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1231133.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1113113411 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 170, 38, 170, 77, false);
                    NewLine1113113411.Name = "NewLine1113113411";
                    NewLine1113113411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1113113411.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine11311322 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 197, 38, 197, 77, false);
                    NewLine11311322.Name = "NewLine11311322";
                    NewLine11311322.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11311322.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1131133 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 206, 38, 206, 77, false);
                    NewLine1131133.Name = "NewLine1131133";
                    NewLine1131133.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1131133.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1113113412 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 286, 38, 286, 77, false);
                    NewLine1113113412.Name = "NewLine1113113412";
                    NewLine1113113412.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1113113412.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewField11466154 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 38, 60, 77, false);
                    NewField11466154.Name = "NewField11466154";
                    NewField11466154.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField11466154.FontAngle = 900;
                    NewField11466154.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11466154.TextFont.Size = 8;
                    NewField11466154.TextFont.CharSet = 162;
                    NewField11466154.Value = @"Durum";

                    NewField1162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 55, 16, 60, false);
                    NewField1162.Name = "NewField1162";
                    NewField1162.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1162.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1162.TextFont.Size = 8;
                    NewField1162.TextFont.Bold = true;
                    NewField1162.TextFont.CharSet = 162;
                    NewField1162.Value = @"Tarih";

                    NewField12611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 55, 31, 65, false);
                    NewField12611.Name = "NewField12611";
                    NewField12611.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField12611.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12611.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12611.NoClip = EvetHayirEnum.ehEvet;
                    NewField12611.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12611.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12611.TextFont.Size = 8;
                    NewField12611.TextFont.Bold = true;
                    NewField12611.TextFont.CharSet = 162;
                    NewField12611.Value = @"Makbuz 
No";

                    NewField12612 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 55, 55, 60, false);
                    NewField12612.Name = "NewField12612";
                    NewField12612.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField12612.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12612.TextFont.Size = 8;
                    NewField12612.TextFont.Bold = true;
                    NewField12612.TextFont.CharSet = 162;
                    NewField12612.Value = @"Açıklama";

                    NewLine1131134 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 242, 38, 242, 77, false);
                    NewLine1131134.Name = "NewLine1131134";
                    NewLine1131134.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1131134.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1431132 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 215, 30, 215, 77, false);
                    NewLine1431132.Name = "NewLine1431132";
                    NewLine1431132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1431132.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine11311342 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 277, 38, 277, 77, false);
                    NewLine11311342.Name = "NewLine11311342";
                    NewLine11311342.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11311342.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine114311312 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 223, 38, 223, 77, false);
                    NewLine114311312.Name = "NewLine114311312";
                    NewLine114311312.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine114311312.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1113113413 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 231, 38, 231, 77, false);
                    NewLine1113113413.Name = "NewLine1113113413";
                    NewLine1113113413.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1113113413.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine131133 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 252, 38, 252, 77, false);
                    NewLine131133.Name = "NewLine131133";
                    NewLine131133.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine131133.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1431133 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 260, 38, 260, 77, false);
                    NewLine1431133.Name = "NewLine1431133";
                    NewLine1431133.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1431133.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine11311343 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 268, 30, 268, 77, false);
                    NewLine11311343.Name = "NewLine11311343";
                    NewLine11311343.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11311343.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine114311313 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 296, 30, 296, 77, false);
                    NewLine114311313.Name = "NewLine114311313";
                    NewLine114311313.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine114311313.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine13311321 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 161, 38, 161, 77, false);
                    NewLine13311321.Name = "NewLine13311321";
                    NewLine13311321.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13311321.ExtendTo = ExtendToEnum.extSectionHeight;

                    CASHOFFICEOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 307, 4, 341, 9, false);
                    CASHOFFICEOBJECTID.Name = "CASHOFFICEOBJECTID";
                    CASHOFFICEOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    CASHOFFICEOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHOFFICEOBJECTID.Value = @"{@CASHOFFICE@}";

                    CASHIEROBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 307, 9, 341, 14, false);
                    CASHIEROBJECTID.Name = "CASHIEROBJECTID";
                    CASHIEROBJECTID.Visible = EvetHayirEnum.ehHayir;
                    CASHIEROBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIEROBJECTID.Value = @"{@CASHIER@}";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 25, 23, 29, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.TextFont.Bold = true;
                    NewField1191.TextFont.CharSet = 162;
                    NewField1191.Value = @"Ödeme Tipi";

                    NewField111811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 25, 27, 29, false);
                    NewField111811.Name = "NewField111811";
                    NewField111811.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111811.TextFont.Bold = true;
                    NewField111811.TextFont.CharSet = 162;
                    NewField111811.Value = @":";

                    PAYMENTTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 25, 186, 29, false);
                    PAYMENTTYPE.Name = "PAYMENTTYPE";
                    PAYMENTTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYMENTTYPE.ObjectDefName = "PaymentTypeCashCCEnum";
                    PAYMENTTYPE.DataMember = "DISPLAYTEXT";
                    PAYMENTTYPE.Value = @"{@PAYMENTTYPE@}";

                    G326_01_120 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 39, 71, 57, false);
                    G326_01_120.Name = "G326_01_120";
                    G326_01_120.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_120.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_120.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_120.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_120.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_120.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_120.TextFont.Size = 7;
                    G326_01_120.TextFont.CharSet = 162;
                    G326_01_120.Value = @"600.01.
01.01
Ayaktan
Muayene, 
Kons. ve 
Rpr.";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 62, 57, 215, 57, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    G326_01_1021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 58, 71, 76, false);
                    G326_01_1021.Name = "G326_01_1021";
                    G326_01_1021.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_1021.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_1021.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_1021.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_1021.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_1021.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_1021.TextFont.Size = 7;
                    G326_01_1021.TextFont.CharSet = 162;
                    G326_01_1021.Value = @"601.01.
01.01
Ayaktan
Muayene, 
Kons. ve 
Rpr.";

                    G326_01_1022 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 39, 80, 57, false);
                    G326_01_1022.Name = "G326_01_1022";
                    G326_01_1022.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_1022.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_1022.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_1022.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_1022.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_1022.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_1022.TextFont.Size = 7;
                    G326_01_1022.TextFont.CharSet = 162;
                    G326_01_1022.Value = @"600.01.
01.02
Yatan
Muayene, 
Kons. ve
Rpr.";

                    G326_01_11201 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 58, 80, 76, false);
                    G326_01_11201.Name = "G326_01_11201";
                    G326_01_11201.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_11201.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_11201.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_11201.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_11201.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_11201.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_11201.TextFont.Size = 7;
                    G326_01_11201.TextFont.CharSet = 162;
                    G326_01_11201.Value = @"601.01.
01.02
Yatan
Muayene, 
Kons. ve 
Rpr.";

                    G326_01_1023 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 39, 89, 57, false);
                    G326_01_1023.Name = "G326_01_1023";
                    G326_01_1023.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_1023.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_1023.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_1023.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_1023.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_1023.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_1023.TextFont.Size = 7;
                    G326_01_1023.TextFont.CharSet = 162;
                    G326_01_1023.Value = @"600.01.
02.01
Ayaktan
Lab.
Gelirleri";

                    G326_01_13201 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 58, 89, 76, false);
                    G326_01_13201.Name = "G326_01_13201";
                    G326_01_13201.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_13201.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_13201.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_13201.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_13201.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_13201.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_13201.TextFont.Size = 7;
                    G326_01_13201.TextFont.CharSet = 162;
                    G326_01_13201.Value = @"601.01.
02.01
Ayaktan
Lab.
Gelirleri";

                    G326_01_13202 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 39, 98, 57, false);
                    G326_01_13202.Name = "G326_01_13202";
                    G326_01_13202.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_13202.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_13202.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_13202.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_13202.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_13202.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_13202.TextFont.Size = 7;
                    G326_01_13202.TextFont.CharSet = 162;
                    G326_01_13202.Value = @"600.01.
02.02
Yatan
Lab.
Gelirleri";

                    G326_01_110231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 58, 98, 76, false);
                    G326_01_110231.Name = "G326_01_110231";
                    G326_01_110231.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_110231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_110231.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_110231.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_110231.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_110231.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_110231.TextFont.Size = 7;
                    G326_01_110231.TextFont.CharSet = 162;
                    G326_01_110231.Value = @"601.01.
02.02
Yatan
Lab.
Gelirleri";

                    G326_01_13203 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 39, 116, 57, false);
                    G326_01_13203.Name = "G326_01_13203";
                    G326_01_13203.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_13203.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_13203.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_13203.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_13203.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_13203.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_13203.TextFont.Size = 7;
                    G326_01_13203.TextFont.CharSet = 162;
                    G326_01_13203.Value = @"600.01.
03.01
Ayaktan
Radyoloji 
ve Gör.";

                    G326_01_130231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 58, 116, 76, false);
                    G326_01_130231.Name = "G326_01_130231";
                    G326_01_130231.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_130231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_130231.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_130231.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_130231.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_130231.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_130231.TextFont.Size = 7;
                    G326_01_130231.TextFont.CharSet = 162;
                    G326_01_130231.Value = @"601.01.
03.01
Ayaktan
Radyoloji 
ve Gör.";

                    G326_01_130232 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 39, 125, 57, false);
                    G326_01_130232.Name = "G326_01_130232";
                    G326_01_130232.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_130232.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_130232.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_130232.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_130232.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_130232.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_130232.TextFont.Size = 7;
                    G326_01_130232.TextFont.CharSet = 162;
                    G326_01_130232.Value = @"600.01.
03.02
Yatan
Radyoloji 
ve Gör.";

                    G326_01_1132031 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 58, 125, 76, false);
                    G326_01_1132031.Name = "G326_01_1132031";
                    G326_01_1132031.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_1132031.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_1132031.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_1132031.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_1132031.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_1132031.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_1132031.TextFont.Size = 7;
                    G326_01_1132031.TextFont.CharSet = 162;
                    G326_01_1132031.Value = @"601.01.
03.02
Yatan
Radyoloji 
ve Gör.";

                    G326_01_130233 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 39, 134, 57, false);
                    G326_01_130233.Name = "G326_01_130233";
                    G326_01_130233.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_130233.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_130233.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_130233.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_130233.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_130233.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_130233.TextFont.Size = 7;
                    G326_01_130233.TextFont.CharSet = 162;
                    G326_01_130233.Value = @"600.01.
04.01
Ayaktan
Tıbbi 
Uyg.";

                    G326_01_1332031 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 58, 134, 76, false);
                    G326_01_1332031.Name = "G326_01_1332031";
                    G326_01_1332031.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_1332031.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_1332031.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_1332031.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_1332031.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_1332031.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_1332031.TextFont.Size = 7;
                    G326_01_1332031.TextFont.CharSet = 162;
                    G326_01_1332031.Value = @"601.01.
04.01
Ayaktan
Tıbbi 
Uyg.";

                    G326_01_1332032 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 39, 143, 57, false);
                    G326_01_1332032.Name = "G326_01_1332032";
                    G326_01_1332032.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_1332032.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_1332032.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_1332032.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_1332032.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_1332032.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_1332032.TextFont.Size = 7;
                    G326_01_1332032.TextFont.CharSet = 162;
                    G326_01_1332032.Value = @"600.01.
04.02
Yatan
Tıbbi 
Uyg.";

                    G326_01_11302331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 58, 143, 76, false);
                    G326_01_11302331.Name = "G326_01_11302331";
                    G326_01_11302331.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_11302331.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_11302331.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_11302331.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_11302331.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_11302331.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_11302331.TextFont.Size = 7;
                    G326_01_11302331.TextFont.CharSet = 162;
                    G326_01_11302331.Value = @"601.01.
04.02
Yatan
Tıbbi 
Uyg.";

                    G326_01_1332033 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 39, 152, 57, false);
                    G326_01_1332033.Name = "G326_01_1332033";
                    G326_01_1332033.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_1332033.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_1332033.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_1332033.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_1332033.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_1332033.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_1332033.TextFont.Size = 7;
                    G326_01_1332033.TextFont.CharSet = 162;
                    G326_01_1332033.Value = @"600.01.
01.04.01
Silah
Ruhsatı 
Rapor";

                    G326_01_13302331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 58, 152, 76, false);
                    G326_01_13302331.Name = "G326_01_13302331";
                    G326_01_13302331.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_13302331.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_13302331.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_13302331.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_13302331.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_13302331.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_13302331.TextFont.Size = 7;
                    G326_01_13302331.TextFont.CharSet = 162;
                    G326_01_13302331.Value = @"601.01.
01.04.01
Silah
Ruhsatı 
Rapor";

                    G326_01_1332034 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 39, 161, 57, false);
                    G326_01_1332034.Name = "G326_01_1332034";
                    G326_01_1332034.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_1332034.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_1332034.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_1332034.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_1332034.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_1332034.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_1332034.TextFont.Size = 7;
                    G326_01_1332034.TextFont.CharSet = 162;
                    G326_01_1332034.Value = @"600.01.
05.01
Ayaktan
Uyg. ve 
Gir.";

                    G326_01_14302331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 58, 161, 76, false);
                    G326_01_14302331.Name = "G326_01_14302331";
                    G326_01_14302331.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_14302331.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_14302331.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_14302331.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_14302331.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_14302331.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_14302331.TextFont.Size = 7;
                    G326_01_14302331.TextFont.CharSet = 162;
                    G326_01_14302331.Value = @"601.01.
05.01
Ayaktan
Uyg. ve 
Gir.";

                    G326_01_14302332 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 39, 170, 57, false);
                    G326_01_14302332.Name = "G326_01_14302332";
                    G326_01_14302332.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_14302332.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_14302332.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_14302332.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_14302332.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_14302332.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_14302332.TextFont.Size = 7;
                    G326_01_14302332.TextFont.CharSet = 162;
                    G326_01_14302332.Value = @"600.01.
05.02
Yatan
Uyg. ve 
Gir.";

                    G326_01_123320341 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 58, 170, 76, false);
                    G326_01_123320341.Name = "G326_01_123320341";
                    G326_01_123320341.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_123320341.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_123320341.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_123320341.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_123320341.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_123320341.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_123320341.TextFont.Size = 7;
                    G326_01_123320341.TextFont.CharSet = 162;
                    G326_01_123320341.Value = @"601.01.
05.02
Yatan
Uyg. ve 
Gir.";

                    G326_01_14302333 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 39, 179, 57, false);
                    G326_01_14302333.Name = "G326_01_14302333";
                    G326_01_14302333.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_14302333.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_14302333.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_14302333.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_14302333.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_14302333.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_14302333.TextFont.Size = 7;
                    G326_01_14302333.TextFont.CharSet = 162;
                    G326_01_14302333.Value = @"600.01.
06.01
Ameliyat 
Anestezi
Gelirleri";

                    G326_01_133320341 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 58, 179, 76, false);
                    G326_01_133320341.Name = "G326_01_133320341";
                    G326_01_133320341.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_133320341.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_133320341.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_133320341.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_133320341.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_133320341.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_133320341.TextFont.Size = 7;
                    G326_01_133320341.TextFont.CharSet = 162;
                    G326_01_133320341.Value = @"601.01.
06.01
Ameliyat 
Anestezi
Gelirleri";

                    G326_01_133320342 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 39, 188, 57, false);
                    G326_01_133320342.Name = "G326_01_133320342";
                    G326_01_133320342.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_133320342.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_133320342.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_133320342.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_133320342.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_133320342.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_133320342.TextFont.Size = 7;
                    G326_01_133320342.TextFont.CharSet = 162;
                    G326_01_133320342.Value = @"600.01.
07.01
Yatak ve
Refakat
Gelirleri";

                    G326_01_1243023331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 58, 188, 76, false);
                    G326_01_1243023331.Name = "G326_01_1243023331";
                    G326_01_1243023331.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_1243023331.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_1243023331.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_1243023331.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_1243023331.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_1243023331.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_1243023331.TextFont.Size = 7;
                    G326_01_1243023331.TextFont.CharSet = 162;
                    G326_01_1243023331.Value = @"601.01.
07.01
Yatak ve
Refakat
Gelirleri";

                    G326_0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 39, 197, 57, false);
                    G326_0.Name = "G326_0";
                    G326_0.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_0.MultiLine = EvetHayirEnum.ehEvet;
                    G326_0.NoClip = EvetHayirEnum.ehEvet;
                    G326_0.WordBreak = EvetHayirEnum.ehEvet;
                    G326_0.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_0.TextFont.Size = 7;
                    G326_0.TextFont.CharSet = 162;
                    G326_0.Value = @"600.01.
08.01
İlaç
Gelirleri";

                    G326_10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 58, 197, 76, false);
                    G326_10.Name = "G326_10";
                    G326_10.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_10.MultiLine = EvetHayirEnum.ehEvet;
                    G326_10.NoClip = EvetHayirEnum.ehEvet;
                    G326_10.WordBreak = EvetHayirEnum.ehEvet;
                    G326_10.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_10.TextFont.Size = 7;
                    G326_10.TextFont.CharSet = 162;
                    G326_10.Value = @"601.01.
08.01
İlaç
Gelirleri";

                    G326_11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 197, 39, 206, 57, false);
                    G326_11.Name = "G326_11";
                    G326_11.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_11.MultiLine = EvetHayirEnum.ehEvet;
                    G326_11.NoClip = EvetHayirEnum.ehEvet;
                    G326_11.WordBreak = EvetHayirEnum.ehEvet;
                    G326_11.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_11.TextFont.Size = 7;
                    G326_11.TextFont.CharSet = 162;
                    G326_11.Value = @"600.01.
08.02
Tıbbi 
Sarf
Malzeme";

                    G326_111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 197, 58, 206, 76, false);
                    G326_111.Name = "G326_111";
                    G326_111.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_111.MultiLine = EvetHayirEnum.ehEvet;
                    G326_111.NoClip = EvetHayirEnum.ehEvet;
                    G326_111.WordBreak = EvetHayirEnum.ehEvet;
                    G326_111.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_111.TextFont.Size = 7;
                    G326_111.TextFont.CharSet = 162;
                    G326_111.Value = @"601.01.
08.02
Tıbbi 
Sarf
Malzeme";

                    G326_112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 206, 39, 215, 57, false);
                    G326_112.Name = "G326_112";
                    G326_112.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_112.MultiLine = EvetHayirEnum.ehEvet;
                    G326_112.NoClip = EvetHayirEnum.ehEvet;
                    G326_112.WordBreak = EvetHayirEnum.ehEvet;
                    G326_112.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_112.TextFont.Size = 7;
                    G326_112.TextFont.CharSet = 162;
                    G326_112.Value = @"600.01.
99
Diğer 
Sağlık 
Hizmet";

                    G326_1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 206, 58, 215, 76, false);
                    G326_1211.Name = "G326_1211";
                    G326_1211.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_1211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_1211.MultiLine = EvetHayirEnum.ehEvet;
                    G326_1211.NoClip = EvetHayirEnum.ehEvet;
                    G326_1211.WordBreak = EvetHayirEnum.ehEvet;
                    G326_1211.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_1211.TextFont.Size = 7;
                    G326_1211.TextFont.CharSet = 162;
                    G326_1211.Value = @"601.01.
99
Diğer 
Sağlık 
Hizmet";

                    lblNakit = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 268, 39, 276, 57, false);
                    lblNakit.Name = "lblNakit";
                    lblNakit.FillStyle = FillStyleConstants.vbFSTransparent;
                    lblNakit.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblNakit.MultiLine = EvetHayirEnum.ehEvet;
                    lblNakit.NoClip = EvetHayirEnum.ehEvet;
                    lblNakit.WordBreak = EvetHayirEnum.ehEvet;
                    lblNakit.ExpandTabs = EvetHayirEnum.ehEvet;
                    lblNakit.TextFont.Size = 7;
                    lblNakit.TextFont.CharSet = 162;
                    lblNakit.Value = @"Nakit";

                    lblKK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 277, 39, 286, 57, false);
                    lblKK.Name = "lblKK";
                    lblKK.FillStyle = FillStyleConstants.vbFSTransparent;
                    lblKK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblKK.MultiLine = EvetHayirEnum.ehEvet;
                    lblKK.NoClip = EvetHayirEnum.ehEvet;
                    lblKK.WordBreak = EvetHayirEnum.ehEvet;
                    lblKK.ExpandTabs = EvetHayirEnum.ehEvet;
                    lblKK.TextFont.Size = 7;
                    lblKK.TextFont.CharSet = 162;
                    lblKK.Value = @"Kredi
Kartı 
(123.02)";

                    G326_01_1142011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 39, 223, 57, false);
                    G326_01_1142011.Name = "G326_01_1142011";
                    G326_01_1142011.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_1142011.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_1142011.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_1142011.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_1142011.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_1142011.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_1142011.TextFont.Size = 7;
                    G326_01_1142011.TextFont.CharSet = 162;
                    G326_01_1142011.Value = @"340.11.
01
Tedavi
Avansı";

                    G326_01_1142012 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 39, 231, 57, false);
                    G326_01_1142012.Name = "G326_01_1142012";
                    G326_01_1142012.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_1142012.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_1142012.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_1142012.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_1142012.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_1142012.TextFont.Size = 7;
                    G326_01_1142012.TextFont.CharSet = 162;
                    G326_01_1142012.Value = @"195.01
Harcama
Yetkilisi
Mut.
Avansı";

                    G326_01_1142013 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 39, 242, 56, false);
                    G326_01_1142013.Name = "G326_01_1142013";
                    G326_01_1142013.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_1142013.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_1142013.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_1142013.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_1142013.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_1142013.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_1142013.TextFont.Size = 7;
                    G326_01_1142013.TextFont.CharSet = 162;
                    G326_01_1142013.Value = @"336.06.01
Prv.Alınan
SGK
Kat.Pay.";

                    G326_01_13102411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 242, 39, 252, 64, false);
                    G326_01_13102411.Name = "G326_01_13102411";
                    G326_01_13102411.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_13102411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_13102411.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_13102411.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_13102411.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_13102411.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_13102411.TextFont.Size = 7;
                    G326_01_13102411.TextFont.CharSet = 162;
                    G326_01_13102411.Value = @"600.01.
94
Cum. Bşk.
Kararı İle
Muaf. Tut.
Has. Kat.
Pay.
Gelirler";

                    G326_01_11102411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 252, 39, 260, 57, false);
                    G326_01_11102411.Name = "G326_01_11102411";
                    G326_01_11102411.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_11102411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_11102411.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_11102411.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_11102411.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_11102411.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_11102411.TextFont.Size = 7;
                    G326_01_11102411.TextFont.CharSet = 162;
                    G326_01_11102411.Value = @"649.09.
09.02
Şartname
Gelirleri";

                    G326_01_111420111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 260, 39, 268, 60, false);
                    G326_01_111420111.Name = "G326_01_111420111";
                    G326_01_111420111.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_111420111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_111420111.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_111420111.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_111420111.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_111420111.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_111420111.TextFont.Size = 7;
                    G326_01_111420111.TextFont.CharSet = 162;
                    G326_01_111420111.Value = @"679.09.
9099
Çeşitli
Olağan
dışı
Gelir ve
Karlar";

                    G326_01_18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 286, 39, 295, 57, false);
                    G326_01_18.Name = "G326_01_18";
                    G326_01_18.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_18.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_18.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_18.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_18.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_18.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_18.TextFont.Size = 7;
                    G326_01_18.TextFont.Bold = true;
                    G326_01_18.TextFont.CharSet = 162;
                    G326_01_18.Value = @"Genel
Toplam
";

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 231, 57, 242, 57, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    G326_01_13102412 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 58, 242, 76, false);
                    G326_01_13102412.Name = "G326_01_13102412";
                    G326_01_13102412.FillStyle = FillStyleConstants.vbFSTransparent;
                    G326_01_13102412.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G326_01_13102412.MultiLine = EvetHayirEnum.ehEvet;
                    G326_01_13102412.NoClip = EvetHayirEnum.ehEvet;
                    G326_01_13102412.WordBreak = EvetHayirEnum.ehEvet;
                    G326_01_13102412.ExpandTabs = EvetHayirEnum.ehEvet;
                    G326_01_13102412.TextFont.Size = 7;
                    G326_01_13102412.TextFont.CharSet = 162;
                    G326_01_13102412.Value = @"336.06.02
Prv.
Alınmayan
SGK
Kat.Pay.";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 269, 32, 295, 37, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11611.TextFont.Size = 8;
                    NewField11611.TextFont.Bold = true;
                    NewField11611.TextFont.CharSet = 162;
                    NewField11611.Value = @"GELİRLER TOPLAMI";

                    lbl600_01_02_04 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 39, 107, 57, false);
                    lbl600_01_02_04.Name = "lbl600_01_02_04";
                    lbl600_01_02_04.FillStyle = FillStyleConstants.vbFSTransparent;
                    lbl600_01_02_04.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lbl600_01_02_04.MultiLine = EvetHayirEnum.ehEvet;
                    lbl600_01_02_04.NoClip = EvetHayirEnum.ehEvet;
                    lbl600_01_02_04.WordBreak = EvetHayirEnum.ehEvet;
                    lbl600_01_02_04.ExpandTabs = EvetHayirEnum.ehEvet;
                    lbl600_01_02_04.TextFont.Size = 7;
                    lbl600_01_02_04.TextFont.CharSet = 162;
                    lbl600_01_02_04.Value = @"600.01.
02.04
Diğer
Hasta 
Lab.
Gelirleri";

                }


                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField13.CalcValue = NewField13.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField14.CalcValue = NewField14.Value;
                    CLOSINGDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField181.CalcValue = NewField181.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    CASHOFFICE.CalcValue = @"";
                    NewField191.CalcValue = NewField191.Value;
                    NewField11811.CalcValue = NewField11811.Value;
                    CASHIER.CalcValue = @"";
                    PAGE.CalcValue = ParentReport.CurrentPageNumber.ToString() + @" / " + ParentReport.ReportTotalPageCount;
                    NewField15.CalcValue = NewField15.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField11466154.CalcValue = NewField11466154.Value;
                    NewField1162.CalcValue = NewField1162.Value;
                    NewField12611.CalcValue = NewField12611.Value;
                    NewField12612.CalcValue = NewField12612.Value;
                    CASHOFFICEOBJECTID.CalcValue = MyParentReport.RuntimeParameters.CASHOFFICE.ToString();
                    CASHIEROBJECTID.CalcValue = MyParentReport.RuntimeParameters.CASHIER.ToString();
                    NewField1191.CalcValue = NewField1191.Value;
                    NewField111811.CalcValue = NewField111811.Value;
                    PAYMENTTYPE.CalcValue = MyParentReport.RuntimeParameters.PAYMENTTYPE.ToString();
                    PAYMENTTYPE.PostFieldValueCalculation();
                    G326_01_120.CalcValue = G326_01_120.Value;
                    G326_01_1021.CalcValue = G326_01_1021.Value;
                    G326_01_1022.CalcValue = G326_01_1022.Value;
                    G326_01_11201.CalcValue = G326_01_11201.Value;
                    G326_01_1023.CalcValue = G326_01_1023.Value;
                    G326_01_13201.CalcValue = G326_01_13201.Value;
                    G326_01_13202.CalcValue = G326_01_13202.Value;
                    G326_01_110231.CalcValue = G326_01_110231.Value;
                    G326_01_13203.CalcValue = G326_01_13203.Value;
                    G326_01_130231.CalcValue = G326_01_130231.Value;
                    G326_01_130232.CalcValue = G326_01_130232.Value;
                    G326_01_1132031.CalcValue = G326_01_1132031.Value;
                    G326_01_130233.CalcValue = G326_01_130233.Value;
                    G326_01_1332031.CalcValue = G326_01_1332031.Value;
                    G326_01_1332032.CalcValue = G326_01_1332032.Value;
                    G326_01_11302331.CalcValue = G326_01_11302331.Value;
                    G326_01_1332033.CalcValue = G326_01_1332033.Value;
                    G326_01_13302331.CalcValue = G326_01_13302331.Value;
                    G326_01_1332034.CalcValue = G326_01_1332034.Value;
                    G326_01_14302331.CalcValue = G326_01_14302331.Value;
                    G326_01_14302332.CalcValue = G326_01_14302332.Value;
                    G326_01_123320341.CalcValue = G326_01_123320341.Value;
                    G326_01_14302333.CalcValue = G326_01_14302333.Value;
                    G326_01_133320341.CalcValue = G326_01_133320341.Value;
                    G326_01_133320342.CalcValue = G326_01_133320342.Value;
                    G326_01_1243023331.CalcValue = G326_01_1243023331.Value;
                    G326_0.CalcValue = G326_0.Value;
                    G326_10.CalcValue = G326_10.Value;
                    G326_11.CalcValue = G326_11.Value;
                    G326_111.CalcValue = G326_111.Value;
                    G326_112.CalcValue = G326_112.Value;
                    G326_1211.CalcValue = G326_1211.Value;
                    lblNakit.CalcValue = lblNakit.Value;
                    lblKK.CalcValue = lblKK.Value;
                    G326_01_1142011.CalcValue = G326_01_1142011.Value;
                    G326_01_1142012.CalcValue = G326_01_1142012.Value;
                    G326_01_1142013.CalcValue = G326_01_1142013.Value;
                    G326_01_13102411.CalcValue = G326_01_13102411.Value;
                    G326_01_11102411.CalcValue = G326_01_11102411.Value;
                    G326_01_111420111.CalcValue = G326_01_111420111.Value;
                    G326_01_18.CalcValue = G326_01_18.Value;
                    G326_01_13102412.CalcValue = G326_01_13102412.Value;
                    NewField11611.CalcValue = NewField11611.Value;
                    lbl600_01_02_04.CalcValue = lbl600_01_02_04.Value;
                    HOSPITALNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { NewField13, STARTDATE, NewField14, CLOSINGDATE, NewField16, NewField17, NewField181, NewField1181, CASHOFFICE, NewField191, NewField11811, CASHIER, PAGE, NewField15, NewField161, NewField1161, NewField11466154, NewField1162, NewField12611, NewField12612, CASHOFFICEOBJECTID, CASHIEROBJECTID, NewField1191, NewField111811, PAYMENTTYPE, G326_01_120, G326_01_1021, G326_01_1022, G326_01_11201, G326_01_1023, G326_01_13201, G326_01_13202, G326_01_110231, G326_01_13203, G326_01_130231, G326_01_130232, G326_01_1132031, G326_01_130233, G326_01_1332031, G326_01_1332032, G326_01_11302331, G326_01_1332033, G326_01_13302331, G326_01_1332034, G326_01_14302331, G326_01_14302332, G326_01_123320341, G326_01_14302333, G326_01_133320341, G326_01_133320342, G326_01_1243023331, G326_0, G326_10, G326_11, G326_111, G326_112, G326_1211, lblNakit, lblKK, G326_01_1142011, G326_01_1142012, G326_01_1142013, G326_01_13102411, G326_01_11102411, G326_01_111420111, G326_01_18, G326_01_13102412, NewField11611, lbl600_01_02_04, HOSPITALNAME };
                }

                public override void RunScript()
                {
                    #region PARTA HEADER_Script
                    if (this.CASHOFFICEOBJECTID.CalcValue != Guid.Empty.ToString())
                    {
                        CashOfficeDefinition cashOffice = MyParentReport.ReportObjectContext.GetObject(new Guid(this.CASHOFFICEOBJECTID.CalcValue), typeof(CashOfficeDefinition)) as CashOfficeDefinition;
                        this.CASHOFFICE.CalcValue = cashOffice.Name;
                    }

                    if (this.CASHIEROBJECTID.CalcValue != Guid.Empty.ToString())
                    {
                        ResUser cashier = MyParentReport.ReportObjectContext.GetObject(new Guid(this.CASHIEROBJECTID.CalcValue), typeof(ResUser)) as ResUser;
                        this.CASHIER.CalcValue = cashier.Name;
                    }

                    if (MyParentReport.RuntimeParameters.PAYMENTTYPECONTROL.Value.Equals(0)) // Ödeme Tipi seçilmemişse boş kalsın
                        this.PAYMENTTYPE.CalcValue = string.Empty;
                    #endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public CashOfficeRevenueReport MyParentReport
                {
                    get { return (CashOfficeRevenueReport)ParentReport; }
                }

                public TTReportField T600_01_01_01;
                public TTReportField T600_01_01_02;
                public TTReportField T600_01_02_01;
                public TTReportField T600_01_02_02;
                public TTReportField T600_01_03_01;
                public TTReportField T600_01_03_02;
                public TTReportField T600_01_05_02;
                public TTReportField T600_01_01_04_01;
                public TTReportField T600_01_04_02;
                public TTReportField T600_01_04_01;
                public TTReportField T600_01_06_01;
                public TTReportField T600_01_05_01;
                public TTReportField T195_01;
                public TTReportField T340_11_01;
                public TTReportField T600_01_94;
                public TTReportField T336_06_01;
                public TTReportField T600_01_99;
                public TTReportField T600_01_08_02;
                public TTReportField T600_01_08_01;
                public TTReportField T600_01_07_01;
                public TTReportField T649_09_09_02;
                public TTReportField T679_09_9099;
                public TTReportField TTOTAL;
                public TTReportField TOPLAM;
                public TTReportField LBL1;
                public TTReportField LBL2;
                public TTReportField LBL3;
                public TTReportField CASHTOTAL;
                public TTReportField CREDITCARDTOTAL;
                public TTReportField TOTAL;
                public TTReportField T601_01_01_01;
                public TTReportField T601_01_01_02;
                public TTReportField T601_01_02_01;
                public TTReportField T601_01_02_02;
                public TTReportField T601_01_03_01;
                public TTReportField T601_01_03_02;
                public TTReportField T601_01_05_02;
                public TTReportField T601_01_01_04_01;
                public TTReportField T601_01_04_02;
                public TTReportField T601_01_04_01;
                public TTReportField T601_01_06_01;
                public TTReportField T601_01_05_01;
                public TTReportField T601_01_99;
                public TTReportField T601_01_08_02;
                public TTReportField T601_01_08_01;
                public TTReportField T601_01_07_01;
                public TTReportField BOS3;
                public TTReportField BOS4;
                public TTReportField T336_06_02;
                public TTReportField BOS5;
                public TTReportField BOS6;
                public TTReportField BOS2;
                public TTReportField NewField1;
                public TTReportField DOCUMENTNORANGE;
                public TTReportField DATERANGE;
                public TTReportField TCASH;
                public TTReportField TCC;
                public TTReportField T600_01_02_04;
                public TTReportField BOS1;
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 30;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;

                    T600_01_01_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, -1, 71, 4, false);
                    T600_01_01_01.Name = "T600_01_01_01";
                    T600_01_01_01.DrawStyle = DrawStyleConstants.vbSolid;
                    T600_01_01_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    T600_01_01_01.TextFormat = @"#,##0.#0";
                    T600_01_01_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T600_01_01_01.TextFont.Size = 7;
                    T600_01_01_01.TextFont.CharSet = 162;
                    T600_01_01_01.Value = @"";

                    T600_01_01_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, -1, 80, 4, false);
                    T600_01_01_02.Name = "T600_01_01_02";
                    T600_01_01_02.DrawStyle = DrawStyleConstants.vbSolid;
                    T600_01_01_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    T600_01_01_02.TextFormat = @"#,##0.#0";
                    T600_01_01_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T600_01_01_02.TextFont.Size = 7;
                    T600_01_01_02.TextFont.CharSet = 162;
                    T600_01_01_02.Value = @"";

                    T600_01_02_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, -1, 89, 4, false);
                    T600_01_02_01.Name = "T600_01_02_01";
                    T600_01_02_01.DrawStyle = DrawStyleConstants.vbSolid;
                    T600_01_02_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    T600_01_02_01.TextFormat = @"#,##0.#0";
                    T600_01_02_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T600_01_02_01.TextFont.Size = 7;
                    T600_01_02_01.TextFont.CharSet = 162;
                    T600_01_02_01.Value = @"";

                    T600_01_02_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, -1, 98, 4, false);
                    T600_01_02_02.Name = "T600_01_02_02";
                    T600_01_02_02.DrawStyle = DrawStyleConstants.vbSolid;
                    T600_01_02_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    T600_01_02_02.TextFormat = @"#,##0.#0";
                    T600_01_02_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T600_01_02_02.TextFont.Size = 7;
                    T600_01_02_02.TextFont.CharSet = 162;
                    T600_01_02_02.Value = @"";

                    T600_01_03_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, -1, 116, 4, false);
                    T600_01_03_01.Name = "T600_01_03_01";
                    T600_01_03_01.DrawStyle = DrawStyleConstants.vbSolid;
                    T600_01_03_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    T600_01_03_01.TextFormat = @"#,##0.#0";
                    T600_01_03_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T600_01_03_01.TextFont.Size = 7;
                    T600_01_03_01.TextFont.CharSet = 162;
                    T600_01_03_01.Value = @"";

                    T600_01_03_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, -1, 125, 4, false);
                    T600_01_03_02.Name = "T600_01_03_02";
                    T600_01_03_02.DrawStyle = DrawStyleConstants.vbSolid;
                    T600_01_03_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    T600_01_03_02.TextFormat = @"#,##0.#0";
                    T600_01_03_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T600_01_03_02.TextFont.Size = 7;
                    T600_01_03_02.TextFont.CharSet = 162;
                    T600_01_03_02.Value = @"";

                    T600_01_05_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, -1, 170, 4, false);
                    T600_01_05_02.Name = "T600_01_05_02";
                    T600_01_05_02.DrawStyle = DrawStyleConstants.vbSolid;
                    T600_01_05_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    T600_01_05_02.TextFormat = @"#,##0.#0";
                    T600_01_05_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T600_01_05_02.TextFont.Size = 7;
                    T600_01_05_02.TextFont.CharSet = 162;
                    T600_01_05_02.Value = @"";

                    T600_01_01_04_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, -1, 152, 4, false);
                    T600_01_01_04_01.Name = "T600_01_01_04_01";
                    T600_01_01_04_01.DrawStyle = DrawStyleConstants.vbSolid;
                    T600_01_01_04_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    T600_01_01_04_01.TextFormat = @"#,##0.#0";
                    T600_01_01_04_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T600_01_01_04_01.TextFont.Size = 7;
                    T600_01_01_04_01.TextFont.CharSet = 162;
                    T600_01_01_04_01.Value = @"";

                    T600_01_04_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, -1, 143, 4, false);
                    T600_01_04_02.Name = "T600_01_04_02";
                    T600_01_04_02.DrawStyle = DrawStyleConstants.vbSolid;
                    T600_01_04_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    T600_01_04_02.TextFormat = @"#,##0.#0";
                    T600_01_04_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T600_01_04_02.TextFont.Size = 7;
                    T600_01_04_02.TextFont.CharSet = 162;
                    T600_01_04_02.Value = @"";

                    T600_01_04_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, -1, 134, 4, false);
                    T600_01_04_01.Name = "T600_01_04_01";
                    T600_01_04_01.DrawStyle = DrawStyleConstants.vbSolid;
                    T600_01_04_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    T600_01_04_01.TextFormat = @"#,##0.#0";
                    T600_01_04_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T600_01_04_01.TextFont.Size = 7;
                    T600_01_04_01.TextFont.CharSet = 162;
                    T600_01_04_01.Value = @"";

                    T600_01_06_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, -1, 179, 4, false);
                    T600_01_06_01.Name = "T600_01_06_01";
                    T600_01_06_01.DrawStyle = DrawStyleConstants.vbSolid;
                    T600_01_06_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    T600_01_06_01.TextFormat = @"#,##0.#0";
                    T600_01_06_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T600_01_06_01.TextFont.Size = 7;
                    T600_01_06_01.TextFont.CharSet = 162;
                    T600_01_06_01.Value = @"";

                    T600_01_05_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, -1, 161, 4, false);
                    T600_01_05_01.Name = "T600_01_05_01";
                    T600_01_05_01.DrawStyle = DrawStyleConstants.vbSolid;
                    T600_01_05_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    T600_01_05_01.TextFormat = @"#,##0.#0";
                    T600_01_05_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T600_01_05_01.TextFont.Size = 7;
                    T600_01_05_01.TextFont.CharSet = 162;
                    T600_01_05_01.Value = @"";

                    T195_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, -1, 231, 4, false);
                    T195_01.Name = "T195_01";
                    T195_01.DrawStyle = DrawStyleConstants.vbSolid;
                    T195_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    T195_01.TextFormat = @"#,##0.#0";
                    T195_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T195_01.TextFont.Size = 7;
                    T195_01.TextFont.CharSet = 162;
                    T195_01.Value = @"";

                    T340_11_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, -1, 223, 4, false);
                    T340_11_01.Name = "T340_11_01";
                    T340_11_01.DrawStyle = DrawStyleConstants.vbSolid;
                    T340_11_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    T340_11_01.TextFormat = @"#,##0.#0";
                    T340_11_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T340_11_01.TextFont.Size = 7;
                    T340_11_01.TextFont.CharSet = 162;
                    T340_11_01.Value = @"";

                    T600_01_94 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 242, -1, 252, 4, false);
                    T600_01_94.Name = "T600_01_94";
                    T600_01_94.DrawStyle = DrawStyleConstants.vbSolid;
                    T600_01_94.FieldType = ReportFieldTypeEnum.ftVariable;
                    T600_01_94.TextFormat = @"#,##0.#0";
                    T600_01_94.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T600_01_94.TextFont.Size = 7;
                    T600_01_94.TextFont.CharSet = 162;
                    T600_01_94.Value = @"";

                    T336_06_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, -1, 242, 4, false);
                    T336_06_01.Name = "T336_06_01";
                    T336_06_01.DrawStyle = DrawStyleConstants.vbSolid;
                    T336_06_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    T336_06_01.TextFormat = @"#,##0.#0";
                    T336_06_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T336_06_01.TextFont.Size = 7;
                    T336_06_01.TextFont.CharSet = 162;
                    T336_06_01.Value = @"";

                    T600_01_99 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 206, -1, 215, 4, false);
                    T600_01_99.Name = "T600_01_99";
                    T600_01_99.DrawStyle = DrawStyleConstants.vbSolid;
                    T600_01_99.FieldType = ReportFieldTypeEnum.ftVariable;
                    T600_01_99.TextFormat = @"#,##0.#0";
                    T600_01_99.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T600_01_99.TextFont.Size = 7;
                    T600_01_99.TextFont.CharSet = 162;
                    T600_01_99.Value = @"";

                    T600_01_08_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 197, -1, 206, 4, false);
                    T600_01_08_02.Name = "T600_01_08_02";
                    T600_01_08_02.DrawStyle = DrawStyleConstants.vbSolid;
                    T600_01_08_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    T600_01_08_02.TextFormat = @"#,##0.#0";
                    T600_01_08_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T600_01_08_02.TextFont.Size = 7;
                    T600_01_08_02.TextFont.CharSet = 162;
                    T600_01_08_02.Value = @"";

                    T600_01_08_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, -1, 197, 4, false);
                    T600_01_08_01.Name = "T600_01_08_01";
                    T600_01_08_01.DrawStyle = DrawStyleConstants.vbSolid;
                    T600_01_08_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    T600_01_08_01.TextFormat = @"#,##0.#0";
                    T600_01_08_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T600_01_08_01.TextFont.Size = 7;
                    T600_01_08_01.TextFont.CharSet = 162;
                    T600_01_08_01.Value = @"";

                    T600_01_07_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, -1, 188, 4, false);
                    T600_01_07_01.Name = "T600_01_07_01";
                    T600_01_07_01.DrawStyle = DrawStyleConstants.vbSolid;
                    T600_01_07_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    T600_01_07_01.TextFormat = @"#,##0.#0";
                    T600_01_07_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T600_01_07_01.TextFont.Size = 7;
                    T600_01_07_01.TextFont.CharSet = 162;
                    T600_01_07_01.Value = @"";

                    T649_09_09_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 252, -1, 260, 4, false);
                    T649_09_09_02.Name = "T649_09_09_02";
                    T649_09_09_02.DrawStyle = DrawStyleConstants.vbSolid;
                    T649_09_09_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    T649_09_09_02.TextFormat = @"#,##0.#0";
                    T649_09_09_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T649_09_09_02.TextFont.Size = 7;
                    T649_09_09_02.TextFont.CharSet = 162;
                    T649_09_09_02.Value = @"";

                    T679_09_9099 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 260, -1, 268, 4, false);
                    T679_09_9099.Name = "T679_09_9099";
                    T679_09_9099.DrawStyle = DrawStyleConstants.vbSolid;
                    T679_09_9099.FieldType = ReportFieldTypeEnum.ftVariable;
                    T679_09_9099.TextFormat = @"#,##0.#0";
                    T679_09_9099.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T679_09_9099.TextFont.Size = 7;
                    T679_09_9099.TextFont.CharSet = 162;
                    T679_09_9099.Value = @"";

                    TTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 286, -1, 296, 9, false);
                    TTOTAL.Name = "TTOTAL";
                    TTOTAL.DrawStyle = DrawStyleConstants.vbSolid;
                    TTOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTOTAL.TextFormat = @"#,##0.#0";
                    TTOTAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TTOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TTOTAL.TextFont.Size = 7;
                    TTOTAL.TextFont.CharSet = 162;
                    TTOTAL.Value = @"";

                    TOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, -1, 62, 9, false);
                    TOPLAM.Name = "TOPLAM";
                    TOPLAM.DrawStyle = DrawStyleConstants.vbSolid;
                    TOPLAM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOPLAM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOPLAM.TextFont.Size = 8;
                    TOPLAM.TextFont.CharSet = 162;
                    TOPLAM.Value = @"GENEL TOPLAM";

                    LBL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 13, 266, 18, false);
                    LBL1.Name = "LBL1";
                    LBL1.DrawStyle = DrawStyleConstants.vbSolid;
                    LBL1.TextFont.Bold = true;
                    LBL1.TextFont.CharSet = 162;
                    LBL1.Value = @"TOPLAM NAKİT TAHSİLATLAR";

                    LBL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 18, 266, 23, false);
                    LBL2.Name = "LBL2";
                    LBL2.DrawStyle = DrawStyleConstants.vbSolid;
                    LBL2.TextFont.Bold = true;
                    LBL2.TextFont.CharSet = 162;
                    LBL2.Value = @"TOPLAM KREDİLİ TAHSİLATLAR";

                    LBL3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 23, 266, 28, false);
                    LBL3.Name = "LBL3";
                    LBL3.DrawStyle = DrawStyleConstants.vbSolid;
                    LBL3.TextFont.Bold = true;
                    LBL3.TextFont.CharSet = 162;
                    LBL3.Value = @"GENEL TOPLAM (KASADAKİ MİKTAR)";

                    CASHTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 266, 13, 296, 18, false);
                    CASHTOTAL.Name = "CASHTOTAL";
                    CASHTOTAL.DrawStyle = DrawStyleConstants.vbSolid;
                    CASHTOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHTOTAL.TextFormat = @"#,##0.#0";
                    CASHTOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CASHTOTAL.TextFont.CharSet = 162;
                    CASHTOTAL.Value = @"";

                    CREDITCARDTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 266, 18, 296, 23, false);
                    CREDITCARDTOTAL.Name = "CREDITCARDTOTAL";
                    CREDITCARDTOTAL.DrawStyle = DrawStyleConstants.vbSolid;
                    CREDITCARDTOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    CREDITCARDTOTAL.TextFormat = @"#,##0.#0";
                    CREDITCARDTOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CREDITCARDTOTAL.TextFont.CharSet = 162;
                    CREDITCARDTOTAL.Value = @"";

                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 266, 23, 296, 28, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL.TextFormat = @"#,##0.#0";
                    TOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTAL.TextFont.CharSet = 162;
                    TOTAL.Value = @"";

                    T601_01_01_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 4, 71, 9, false);
                    T601_01_01_01.Name = "T601_01_01_01";
                    T601_01_01_01.DrawStyle = DrawStyleConstants.vbSolid;
                    T601_01_01_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    T601_01_01_01.TextFormat = @"#,##0.#0";
                    T601_01_01_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T601_01_01_01.TextFont.Size = 7;
                    T601_01_01_01.TextFont.CharSet = 162;
                    T601_01_01_01.Value = @"";

                    T601_01_01_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 4, 80, 9, false);
                    T601_01_01_02.Name = "T601_01_01_02";
                    T601_01_01_02.DrawStyle = DrawStyleConstants.vbSolid;
                    T601_01_01_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    T601_01_01_02.TextFormat = @"#,##0.#0";
                    T601_01_01_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T601_01_01_02.TextFont.Size = 7;
                    T601_01_01_02.TextFont.CharSet = 162;
                    T601_01_01_02.Value = @"";

                    T601_01_02_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 4, 89, 9, false);
                    T601_01_02_01.Name = "T601_01_02_01";
                    T601_01_02_01.DrawStyle = DrawStyleConstants.vbSolid;
                    T601_01_02_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    T601_01_02_01.TextFormat = @"#,##0.#0";
                    T601_01_02_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T601_01_02_01.TextFont.Size = 7;
                    T601_01_02_01.TextFont.CharSet = 162;
                    T601_01_02_01.Value = @"";

                    T601_01_02_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 4, 98, 9, false);
                    T601_01_02_02.Name = "T601_01_02_02";
                    T601_01_02_02.DrawStyle = DrawStyleConstants.vbSolid;
                    T601_01_02_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    T601_01_02_02.TextFormat = @"#,##0.#0";
                    T601_01_02_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T601_01_02_02.TextFont.Size = 7;
                    T601_01_02_02.TextFont.CharSet = 162;
                    T601_01_02_02.Value = @"";

                    T601_01_03_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 4, 116, 9, false);
                    T601_01_03_01.Name = "T601_01_03_01";
                    T601_01_03_01.DrawStyle = DrawStyleConstants.vbSolid;
                    T601_01_03_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    T601_01_03_01.TextFormat = @"#,##0.#0";
                    T601_01_03_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T601_01_03_01.TextFont.Size = 7;
                    T601_01_03_01.TextFont.CharSet = 162;
                    T601_01_03_01.Value = @"";

                    T601_01_03_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 4, 125, 9, false);
                    T601_01_03_02.Name = "T601_01_03_02";
                    T601_01_03_02.DrawStyle = DrawStyleConstants.vbSolid;
                    T601_01_03_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    T601_01_03_02.TextFormat = @"#,##0.#0";
                    T601_01_03_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T601_01_03_02.TextFont.Size = 7;
                    T601_01_03_02.TextFont.CharSet = 162;
                    T601_01_03_02.Value = @"";

                    T601_01_05_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 4, 170, 9, false);
                    T601_01_05_02.Name = "T601_01_05_02";
                    T601_01_05_02.DrawStyle = DrawStyleConstants.vbSolid;
                    T601_01_05_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    T601_01_05_02.TextFormat = @"#,##0.#0";
                    T601_01_05_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T601_01_05_02.TextFont.Size = 7;
                    T601_01_05_02.TextFont.CharSet = 162;
                    T601_01_05_02.Value = @"";

                    T601_01_01_04_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 4, 152, 9, false);
                    T601_01_01_04_01.Name = "T601_01_01_04_01";
                    T601_01_01_04_01.DrawStyle = DrawStyleConstants.vbSolid;
                    T601_01_01_04_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    T601_01_01_04_01.TextFormat = @"#,##0.#0";
                    T601_01_01_04_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T601_01_01_04_01.TextFont.Size = 7;
                    T601_01_01_04_01.TextFont.CharSet = 162;
                    T601_01_01_04_01.Value = @"";

                    T601_01_04_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 4, 143, 9, false);
                    T601_01_04_02.Name = "T601_01_04_02";
                    T601_01_04_02.DrawStyle = DrawStyleConstants.vbSolid;
                    T601_01_04_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    T601_01_04_02.TextFormat = @"#,##0.#0";
                    T601_01_04_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T601_01_04_02.TextFont.Size = 7;
                    T601_01_04_02.TextFont.CharSet = 162;
                    T601_01_04_02.Value = @"";

                    T601_01_04_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 4, 134, 9, false);
                    T601_01_04_01.Name = "T601_01_04_01";
                    T601_01_04_01.DrawStyle = DrawStyleConstants.vbSolid;
                    T601_01_04_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    T601_01_04_01.TextFormat = @"#,##0.#0";
                    T601_01_04_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T601_01_04_01.TextFont.Size = 7;
                    T601_01_04_01.TextFont.CharSet = 162;
                    T601_01_04_01.Value = @"";

                    T601_01_06_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 4, 179, 9, false);
                    T601_01_06_01.Name = "T601_01_06_01";
                    T601_01_06_01.DrawStyle = DrawStyleConstants.vbSolid;
                    T601_01_06_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    T601_01_06_01.TextFormat = @"#,##0.#0";
                    T601_01_06_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T601_01_06_01.TextFont.Size = 7;
                    T601_01_06_01.TextFont.CharSet = 162;
                    T601_01_06_01.Value = @"";

                    T601_01_05_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 4, 161, 9, false);
                    T601_01_05_01.Name = "T601_01_05_01";
                    T601_01_05_01.DrawStyle = DrawStyleConstants.vbSolid;
                    T601_01_05_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    T601_01_05_01.TextFormat = @"#,##0.#0";
                    T601_01_05_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T601_01_05_01.TextFont.Size = 7;
                    T601_01_05_01.TextFont.CharSet = 162;
                    T601_01_05_01.Value = @"";

                    T601_01_99 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 206, 4, 215, 9, false);
                    T601_01_99.Name = "T601_01_99";
                    T601_01_99.DrawStyle = DrawStyleConstants.vbSolid;
                    T601_01_99.FieldType = ReportFieldTypeEnum.ftVariable;
                    T601_01_99.TextFormat = @"#,##0.#0";
                    T601_01_99.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T601_01_99.TextFont.Size = 7;
                    T601_01_99.TextFont.CharSet = 162;
                    T601_01_99.Value = @"";

                    T601_01_08_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 197, 4, 206, 9, false);
                    T601_01_08_02.Name = "T601_01_08_02";
                    T601_01_08_02.DrawStyle = DrawStyleConstants.vbSolid;
                    T601_01_08_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    T601_01_08_02.TextFormat = @"#,##0.#0";
                    T601_01_08_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T601_01_08_02.TextFont.Size = 7;
                    T601_01_08_02.TextFont.CharSet = 162;
                    T601_01_08_02.Value = @"";

                    T601_01_08_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 4, 197, 9, false);
                    T601_01_08_01.Name = "T601_01_08_01";
                    T601_01_08_01.DrawStyle = DrawStyleConstants.vbSolid;
                    T601_01_08_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    T601_01_08_01.TextFormat = @"#,##0.#0";
                    T601_01_08_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T601_01_08_01.TextFont.Size = 7;
                    T601_01_08_01.TextFont.CharSet = 162;
                    T601_01_08_01.Value = @"";

                    T601_01_07_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 4, 188, 9, false);
                    T601_01_07_01.Name = "T601_01_07_01";
                    T601_01_07_01.DrawStyle = DrawStyleConstants.vbSolid;
                    T601_01_07_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    T601_01_07_01.TextFormat = @"#,##0.#0";
                    T601_01_07_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T601_01_07_01.TextFont.Size = 7;
                    T601_01_07_01.TextFont.CharSet = 162;
                    T601_01_07_01.Value = @"";

                    BOS3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 4, 231, 9, false);
                    BOS3.Name = "BOS3";
                    BOS3.DrawStyle = DrawStyleConstants.vbSolid;
                    BOS3.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOS3.TextFormat = @"#,##0.#0";
                    BOS3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BOS3.TextFont.Size = 7;
                    BOS3.TextFont.CharSet = 162;
                    BOS3.Value = @"";

                    BOS4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 242, 4, 252, 9, false);
                    BOS4.Name = "BOS4";
                    BOS4.DrawStyle = DrawStyleConstants.vbSolid;
                    BOS4.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOS4.TextFormat = @"#,##0.#0";
                    BOS4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BOS4.TextFont.Size = 7;
                    BOS4.TextFont.CharSet = 162;
                    BOS4.Value = @"";

                    T336_06_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 4, 242, 9, false);
                    T336_06_02.Name = "T336_06_02";
                    T336_06_02.DrawStyle = DrawStyleConstants.vbSolid;
                    T336_06_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    T336_06_02.TextFormat = @"#,##0.#0";
                    T336_06_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T336_06_02.TextFont.Size = 7;
                    T336_06_02.TextFont.CharSet = 162;
                    T336_06_02.Value = @"";

                    BOS5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 252, 4, 260, 9, false);
                    BOS5.Name = "BOS5";
                    BOS5.DrawStyle = DrawStyleConstants.vbSolid;
                    BOS5.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOS5.TextFormat = @"#,##0.#0";
                    BOS5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BOS5.TextFont.Size = 7;
                    BOS5.TextFont.CharSet = 162;
                    BOS5.Value = @"";

                    BOS6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 260, 4, 268, 9, false);
                    BOS6.Name = "BOS6";
                    BOS6.DrawStyle = DrawStyleConstants.vbSolid;
                    BOS6.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOS6.TextFormat = @"#,##0.#0";
                    BOS6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BOS6.TextFont.Size = 7;
                    BOS6.TextFont.CharSet = 162;
                    BOS6.Value = @"";

                    BOS2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 4, 223, 9, false);
                    BOS2.Name = "BOS2";
                    BOS2.DrawStyle = DrawStyleConstants.vbSolid;
                    BOS2.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOS2.TextFormat = @"#,##0.#0";
                    BOS2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BOS2.TextFont.Size = 7;
                    BOS2.TextFont.CharSet = 162;
                    BOS2.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 16, 32, 21, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Seri Sıra Numarası";

                    DOCUMENTNORANGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 16, 143, 21, false);
                    DOCUMENTNORANGE.Name = "DOCUMENTNORANGE";
                    DOCUMENTNORANGE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNORANGE.TextFont.CharSet = 162;
                    DOCUMENTNORANGE.Value = @"";

                    DATERANGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 22, 108, 27, false);
                    DATERANGE.Name = "DATERANGE";
                    DATERANGE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATERANGE.TextFont.CharSet = 162;
                    DATERANGE.Value = @"";

                    TCASH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 268, -1, 277, 9, false);
                    TCASH.Name = "TCASH";
                    TCASH.DrawStyle = DrawStyleConstants.vbSolid;
                    TCASH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCASH.TextFormat = @"#,##0.#0";
                    TCASH.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TCASH.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TCASH.TextFont.Size = 7;
                    TCASH.TextFont.CharSet = 162;
                    TCASH.Value = @"";

                    TCC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 277, -1, 286, 9, false);
                    TCC.Name = "TCC";
                    TCC.DrawStyle = DrawStyleConstants.vbSolid;
                    TCC.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCC.TextFormat = @"#,##0.#0";
                    TCC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TCC.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TCC.TextFont.Size = 7;
                    TCC.TextFont.CharSet = 162;
                    TCC.Value = @"";

                    T600_01_02_04 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, -1, 107, 4, false);
                    T600_01_02_04.Name = "T600_01_02_04";
                    T600_01_02_04.DrawStyle = DrawStyleConstants.vbSolid;
                    T600_01_02_04.FieldType = ReportFieldTypeEnum.ftVariable;
                    T600_01_02_04.TextFormat = @"#,##0.#0";
                    T600_01_02_04.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T600_01_02_04.TextFont.Size = 7;
                    T600_01_02_04.TextFont.CharSet = 162;
                    T600_01_02_04.Value = @"";

                    BOS1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 4, 107, 9, false);
                    BOS1.Name = "BOS1";
                    BOS1.DrawStyle = DrawStyleConstants.vbSolid;
                    BOS1.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOS1.TextFormat = @"#,##0.#0";
                    BOS1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BOS1.TextFont.Size = 7;
                    BOS1.TextFont.CharSet = 162;
                    BOS1.Value = @"";

                }


                override public TTReportObject[] GetCalculatedFields()
                {
                    T600_01_01_01.CalcValue = @"";
                    T600_01_01_02.CalcValue = @"";
                    T600_01_02_01.CalcValue = @"";
                    T600_01_02_02.CalcValue = @"";
                    T600_01_03_01.CalcValue = @"";
                    T600_01_03_02.CalcValue = @"";
                    T600_01_05_02.CalcValue = @"";
                    T600_01_01_04_01.CalcValue = @"";
                    T600_01_04_02.CalcValue = @"";
                    T600_01_04_01.CalcValue = @"";
                    T600_01_06_01.CalcValue = @"";
                    T600_01_05_01.CalcValue = @"";
                    T195_01.CalcValue = @"";
                    T340_11_01.CalcValue = @"";
                    T600_01_94.CalcValue = @"";
                    T336_06_01.CalcValue = @"";
                    T600_01_99.CalcValue = @"";
                    T600_01_08_02.CalcValue = @"";
                    T600_01_08_01.CalcValue = @"";
                    T600_01_07_01.CalcValue = @"";
                    T649_09_09_02.CalcValue = @"";
                    T679_09_9099.CalcValue = @"";
                    TTOTAL.CalcValue = @"";
                    TOPLAM.CalcValue = TOPLAM.Value;
                    LBL1.CalcValue = LBL1.Value;
                    LBL2.CalcValue = LBL2.Value;
                    LBL3.CalcValue = LBL3.Value;
                    CASHTOTAL.CalcValue = @"";
                    CREDITCARDTOTAL.CalcValue = @"";
                    TOTAL.CalcValue = @"";
                    T601_01_01_01.CalcValue = @"";
                    T601_01_01_02.CalcValue = @"";
                    T601_01_02_01.CalcValue = @"";
                    T601_01_02_02.CalcValue = @"";
                    T601_01_03_01.CalcValue = @"";
                    T601_01_03_02.CalcValue = @"";
                    T601_01_05_02.CalcValue = @"";
                    T601_01_01_04_01.CalcValue = @"";
                    T601_01_04_02.CalcValue = @"";
                    T601_01_04_01.CalcValue = @"";
                    T601_01_06_01.CalcValue = @"";
                    T601_01_05_01.CalcValue = @"";
                    T601_01_99.CalcValue = @"";
                    T601_01_08_02.CalcValue = @"";
                    T601_01_08_01.CalcValue = @"";
                    T601_01_07_01.CalcValue = @"";
                    BOS3.CalcValue = @"";
                    BOS4.CalcValue = @"";
                    T336_06_02.CalcValue = @"";
                    BOS5.CalcValue = @"";
                    BOS6.CalcValue = @"";
                    BOS2.CalcValue = @"";
                    NewField1.CalcValue = NewField1.Value;
                    DOCUMENTNORANGE.CalcValue = @"";
                    DATERANGE.CalcValue = @"";
                    TCASH.CalcValue = @"";
                    TCC.CalcValue = @"";
                    T600_01_02_04.CalcValue = @"";
                    BOS1.CalcValue = @"";
                    return new TTReportObject[] { T600_01_01_01, T600_01_01_02, T600_01_02_01, T600_01_02_02, T600_01_03_01, T600_01_03_02, T600_01_05_02, T600_01_01_04_01, T600_01_04_02, T600_01_04_01, T600_01_06_01, T600_01_05_01, T195_01, T340_11_01, T600_01_94, T336_06_01, T600_01_99, T600_01_08_02, T600_01_08_01, T600_01_07_01, T649_09_09_02, T679_09_9099, TTOTAL, TOPLAM, LBL1, LBL2, LBL3, CASHTOTAL, CREDITCARDTOTAL, TOTAL, T601_01_01_01, T601_01_01_02, T601_01_02_01, T601_01_02_02, T601_01_03_01, T601_01_03_02, T601_01_05_02, T601_01_01_04_01, T601_01_04_02, T601_01_04_01, T601_01_06_01, T601_01_05_01, T601_01_99, T601_01_08_02, T601_01_08_01, T601_01_07_01, BOS3, BOS4, T336_06_02, BOS5, BOS6, BOS2, NewField1, DOCUMENTNORANGE, DATERANGE, TCASH, TCC, T600_01_02_04, BOS1 };
                }

                public override void RunScript()
                {
                    #region PARTA FOOTER_Script
                    if (MyParentReport.T600_01_01_01 != 0)
                        this.T600_01_01_01.CalcValue = MyParentReport.T600_01_01_01.ToString();
                    if (MyParentReport.T600_01_01_02 != 0)
                        this.T600_01_01_02.CalcValue = MyParentReport.T600_01_01_02.ToString();
                    if (MyParentReport.T600_01_02_01 != 0)
                        this.T600_01_02_01.CalcValue = MyParentReport.T600_01_02_01.ToString();
                    if (MyParentReport.T600_01_02_02 != 0)
                        this.T600_01_02_02.CalcValue = MyParentReport.T600_01_02_02.ToString();
                    if (MyParentReport.T600_01_02_04 != 0)
                        this.T600_01_02_04.CalcValue = MyParentReport.T600_01_02_04.ToString();
                    if (MyParentReport.T600_01_03_01 != 0)
                        this.T600_01_03_01.CalcValue = MyParentReport.T600_01_03_01.ToString();
                    if (MyParentReport.T600_01_03_02 != 0)
                        this.T600_01_03_02.CalcValue = MyParentReport.T600_01_03_02.ToString();
                    if (MyParentReport.T600_01_04_01 != 0)
                        this.T600_01_04_01.CalcValue = MyParentReport.T600_01_04_01.ToString();
                    if (MyParentReport.T600_01_04_02 != 0)
                        this.T600_01_04_02.CalcValue = MyParentReport.T600_01_04_02.ToString();
                    if (MyParentReport.T600_01_01_04_01 != 0)
                        this.T600_01_01_04_01.CalcValue = MyParentReport.T600_01_01_04_01.ToString();
                    if (MyParentReport.T600_01_05_01 != 0)
                        this.T600_01_05_01.CalcValue = MyParentReport.T600_01_05_01.ToString();
                    if (MyParentReport.T600_01_05_02 != 0)
                        this.T600_01_05_02.CalcValue = MyParentReport.T600_01_05_02.ToString();
                    if (MyParentReport.T600_01_06_01 != 0)
                        this.T600_01_06_01.CalcValue = MyParentReport.T600_01_06_01.ToString();
                    if (MyParentReport.T600_01_07_01 != 0)
                        this.T600_01_07_01.CalcValue = MyParentReport.T600_01_07_01.ToString();
                    if (MyParentReport.T600_01_08_01 != 0)
                        this.T600_01_08_01.CalcValue = MyParentReport.T600_01_08_01.ToString();
                    if (MyParentReport.T600_01_08_02 != 0)
                        this.T600_01_08_02.CalcValue = MyParentReport.T600_01_08_02.ToString();
                    if (MyParentReport.T600_01_99 != 0)
                        this.T600_01_99.CalcValue = MyParentReport.T600_01_99.ToString();

                    if (MyParentReport.T601_01_01_01 != 0)
                        this.T601_01_01_01.CalcValue = MyParentReport.T601_01_01_01.ToString();
                    if (MyParentReport.T601_01_01_02 != 0)
                        this.T601_01_01_02.CalcValue = MyParentReport.T601_01_01_02.ToString();
                    if (MyParentReport.T601_01_02_01 != 0)
                        this.T601_01_02_01.CalcValue = MyParentReport.T601_01_02_01.ToString();
                    if (MyParentReport.T601_01_02_02 != 0)
                        this.T601_01_02_02.CalcValue = MyParentReport.T601_01_02_02.ToString();
                    if (MyParentReport.T601_01_03_01 != 0)
                        this.T601_01_03_01.CalcValue = MyParentReport.T601_01_03_01.ToString();
                    if (MyParentReport.T601_01_03_02 != 0)
                        this.T601_01_03_02.CalcValue = MyParentReport.T601_01_03_02.ToString();
                    if (MyParentReport.T601_01_04_01 != 0)
                        this.T601_01_04_01.CalcValue = MyParentReport.T601_01_04_01.ToString();
                    if (MyParentReport.T601_01_04_02 != 0)
                        this.T601_01_04_02.CalcValue = MyParentReport.T601_01_04_02.ToString();
                    if (MyParentReport.T601_01_01_04_01 != 0)
                        this.T601_01_01_04_01.CalcValue = MyParentReport.T601_01_01_04_01.ToString();
                    if (MyParentReport.T601_01_05_01 != 0)
                        this.T601_01_05_01.CalcValue = MyParentReport.T601_01_05_01.ToString();
                    if (MyParentReport.T601_01_05_02 != 0)
                        this.T601_01_05_02.CalcValue = MyParentReport.T601_01_05_02.ToString();
                    if (MyParentReport.T601_01_06_01 != 0)
                        this.T601_01_06_01.CalcValue = MyParentReport.T601_01_06_01.ToString();
                    if (MyParentReport.T601_01_07_01 != 0)
                        this.T601_01_07_01.CalcValue = MyParentReport.T601_01_07_01.ToString();
                    if (MyParentReport.T601_01_08_01 != 0)
                        this.T601_01_08_01.CalcValue = MyParentReport.T601_01_08_01.ToString();
                    if (MyParentReport.T601_01_08_02 != 0)
                        this.T601_01_08_02.CalcValue = MyParentReport.T601_01_08_02.ToString();
                    if (MyParentReport.T601_01_99 != 0)
                        this.T601_01_99.CalcValue = MyParentReport.T601_01_99.ToString();

                    if (MyParentReport.T340_11_01 != 0)
                        this.T340_11_01.CalcValue = MyParentReport.T340_11_01.ToString();
                    if (MyParentReport.T195_01 != 0)
                        this.T195_01.CalcValue = MyParentReport.T195_01.ToString();
                    if (MyParentReport.T336_06_01 != 0)
                        this.T336_06_01.CalcValue = MyParentReport.T336_06_01.ToString();
                    if (MyParentReport.T336_06_02 != 0)
                        this.T336_06_02.CalcValue = MyParentReport.T336_06_02.ToString();
                    if (MyParentReport.T600_01_94 != 0)
                        this.T600_01_94.CalcValue = MyParentReport.T600_01_94.ToString();
                    if (MyParentReport.T649_09_09_02 != 0)
                        this.T649_09_09_02.CalcValue = MyParentReport.T649_09_09_02.ToString();
                    if (MyParentReport.T679_09_9099 != 0)
                        this.T679_09_9099.CalcValue = MyParentReport.T679_09_9099.ToString();

                    this.TCASH.CalcValue = MyParentReport.CashTotal.ToString();
                    this.TCC.CalcValue = MyParentReport.CreditCardTotal.ToString();
                    this.TTOTAL.CalcValue = MyParentReport.Total.ToString();

                    this.CASHTOTAL.CalcValue = MyParentReport.CashTotal.ToString();
                    this.CREDITCARDTOTAL.CalcValue = MyParentReport.CreditCardTotal.ToString();
                    this.TOTAL.CalcValue = MyParentReport.Total.ToString();

                    this.DOCUMENTNORANGE.CalcValue = MyParentReport.firstDocumentNo + " - " + MyParentReport.lastDocumentNo + " arası " + MyParentReport.mainDataCounter + " adet makbuz.";
                    this.DATERANGE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.Value.ToShortDateString() + " - " + MyParentReport.RuntimeParameters.ENDDATE.Value.ToShortDateString();
                    #endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTCGroup : TTReportGroup
        {
            public CashOfficeRevenueReport MyParentReport
            {
                get { return (CashOfficeRevenueReport)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportShape NewLine1 { get { return Footer().NewLine1; } }
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
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public CashOfficeRevenueReport MyParentReport
                {
                    get { return (CashOfficeRevenueReport)ParentReport; }
                }

                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;

                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;

                }

            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public CashOfficeRevenueReport MyParentReport
                {
                    get { return (CashOfficeRevenueReport)ParentReport; }
                }

                public TTReportShape NewLine1;
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 0, 296, 0, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }


                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class MAINGroup : TTReportGroup
        {
            public CashOfficeRevenueReport MyParentReport
            {
                get { return (CashOfficeRevenueReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DOCUMENTDATE { get { return Body().DOCUMENTDATE; } }
            public TTReportField DOCUMENTNO { get { return Body().DOCUMENTNO; } }
            public TTReportField STATUS { get { return Body().STATUS; } }
            public TTReportField G600_01_01_01 { get { return Body().G600_01_01_01; } }
            public TTReportField G600_01_02_01 { get { return Body().G600_01_02_01; } }
            public TTReportField G600_01_01_02 { get { return Body().G600_01_01_02; } }
            public TTReportField G600_01_03_01 { get { return Body().G600_01_03_01; } }
            public TTReportField G600_01_02_02 { get { return Body().G600_01_02_02; } }
            public TTReportField G600_01_03_02 { get { return Body().G600_01_03_02; } }
            public TTReportField G600_01_04_01 { get { return Body().G600_01_04_01; } }
            public TTReportField G600_01_04_02 { get { return Body().G600_01_04_02; } }
            public TTReportField G600_01_01_04_01 { get { return Body().G600_01_01_04_01; } }
            public TTReportField G600_01_05_01 { get { return Body().G600_01_05_01; } }
            public TTReportField G600_01_05_02 { get { return Body().G600_01_05_02; } }
            public TTReportField G600_01_07_01 { get { return Body().G600_01_07_01; } }
            public TTReportField G600_01_08_02 { get { return Body().G600_01_08_02; } }
            public TTReportField G600_01_99 { get { return Body().G600_01_99; } }
            public TTReportField G600_01_06_01 { get { return Body().G600_01_06_01; } }
            public TTReportField G600_01_08_01 { get { return Body().G600_01_08_01; } }
            public TTReportField G600_01_94 { get { return Body().G600_01_94; } }
            public TTReportField G195_01 { get { return Body().G195_01; } }
            public TTReportField G340_11_01 { get { return Body().G340_11_01; } }
            public TTReportField G649_09_09_02 { get { return Body().G649_09_09_02; } }
            public TTReportField G679_09_9099 { get { return Body().G679_09_9099; } }
            public TTReportField GTOTAL { get { return Body().GTOTAL; } }
            public TTReportField OBJECTDEF { get { return Body().OBJECTDEF; } }
            public TTReportField OBJECTID { get { return Body().OBJECTID; } }
            public TTReportField PAYMENTTYPE { get { return Body().PAYMENTTYPE; } }
            public TTReportField STATESTATUS { get { return Body().STATESTATUS; } }
            public TTReportField ACCOUNTCODE { get { return Body().ACCOUNTCODE; } }
            public TTReportShape NewLine1111 { get { return Body().NewLine1111; } }
            public TTReportShape NewLine11111 { get { return Body().NewLine11111; } }
            public TTReportShape NewLine11112 { get { return Body().NewLine11112; } }
            public TTReportShape NewLine11113 { get { return Body().NewLine11113; } }
            public TTReportShape NewLine131111 { get { return Body().NewLine131111; } }
            public TTReportShape NewLine131112 { get { return Body().NewLine131112; } }
            public TTReportShape NewLine131113 { get { return Body().NewLine131113; } }
            public TTReportShape NewLine131114 { get { return Body().NewLine131114; } }
            public TTReportShape NewLine131116 { get { return Body().NewLine131116; } }
            public TTReportShape NewLine131117 { get { return Body().NewLine131117; } }
            public TTReportShape NewLine1311131 { get { return Body().NewLine1311131; } }
            public TTReportShape NewLine1311132 { get { return Body().NewLine1311132; } }
            public TTReportShape NewLine1311133 { get { return Body().NewLine1311133; } }
            public TTReportShape NewLine1311134 { get { return Body().NewLine1311134; } }
            public TTReportShape NewLine1311135 { get { return Body().NewLine1311135; } }
            public TTReportShape NewLine1311136 { get { return Body().NewLine1311136; } }
            public TTReportShape NewLine1311137 { get { return Body().NewLine1311137; } }
            public TTReportShape NewLine1311138 { get { return Body().NewLine1311138; } }
            public TTReportShape NewLine1311139 { get { return Body().NewLine1311139; } }
            public TTReportShape NewLine1311140 { get { return Body().NewLine1311140; } }
            public TTReportShape NewLine17311131 { get { return Body().NewLine17311131; } }
            public TTReportShape NewLine18311131 { get { return Body().NewLine18311131; } }
            public TTReportShape NewLine19311131 { get { return Body().NewLine19311131; } }
            public TTReportShape NewLine10411131 { get { return Body().NewLine10411131; } }
            public TTReportShape NewLine17311132 { get { return Body().NewLine17311132; } }
            public TTReportShape NewLine18311132 { get { return Body().NewLine18311132; } }
            public TTReportShape NewLine113111401 { get { return Body().NewLine113111401; } }
            public TTReportShape NewLine123111371 { get { return Body().NewLine123111371; } }
            public TTReportShape NewLine123111381 { get { return Body().NewLine123111381; } }
            public TTReportShape NewLine113111402 { get { return Body().NewLine113111402; } }
            public TTReportField DESCRIPTION { get { return Body().DESCRIPTION; } }
            public TTReportShape NewLine11 { get { return Body().NewLine11; } }
            public TTReportField G601_01_01_01 { get { return Body().G601_01_01_01; } }
            public TTReportField G601_01_02_01 { get { return Body().G601_01_02_01; } }
            public TTReportField G601_01_01_02 { get { return Body().G601_01_01_02; } }
            public TTReportField G601_01_03_01 { get { return Body().G601_01_03_01; } }
            public TTReportField G601_01_02_02 { get { return Body().G601_01_02_02; } }
            public TTReportField G601_01_03_02 { get { return Body().G601_01_03_02; } }
            public TTReportField G601_01_04_01 { get { return Body().G601_01_04_01; } }
            public TTReportField G601_01_04_02 { get { return Body().G601_01_04_02; } }
            public TTReportField G601_01_01_04_01 { get { return Body().G601_01_01_04_01; } }
            public TTReportField G601_01_05_01 { get { return Body().G601_01_05_01; } }
            public TTReportField G601_01_05_02 { get { return Body().G601_01_05_02; } }
            public TTReportField G601_01_07_01 { get { return Body().G601_01_07_01; } }
            public TTReportField G601_01_08_02 { get { return Body().G601_01_08_02; } }
            public TTReportField G601_01_99 { get { return Body().G601_01_99; } }
            public TTReportField G601_01_06_01 { get { return Body().G601_01_06_01; } }
            public TTReportField G601_01_08_01 { get { return Body().G601_01_08_01; } }
            public TTReportShape NewLine1211131 { get { return Body().NewLine1211131; } }
            public TTReportShape NewLine1311141 { get { return Body().NewLine1311141; } }
            public TTReportShape NewLine11311131 { get { return Body().NewLine11311131; } }
            public TTReportShape NewLine12311131 { get { return Body().NewLine12311131; } }
            public TTReportShape NewLine13311131 { get { return Body().NewLine13311131; } }
            public TTReportShape NewLine14311131 { get { return Body().NewLine14311131; } }
            public TTReportShape NewLine15311131 { get { return Body().NewLine15311131; } }
            public TTReportShape NewLine16311131 { get { return Body().NewLine16311131; } }
            public TTReportShape NewLine17311133 { get { return Body().NewLine17311133; } }
            public TTReportShape NewLine18311133 { get { return Body().NewLine18311133; } }
            public TTReportShape NewLine19311132 { get { return Body().NewLine19311132; } }
            public TTReportShape NewLine10411132 { get { return Body().NewLine10411132; } }
            public TTReportShape NewLine113111371 { get { return Body().NewLine113111371; } }
            public TTReportShape NewLine113111381 { get { return Body().NewLine113111381; } }
            public TTReportShape NewLine113111391 { get { return Body().NewLine113111391; } }
            public TTReportShape NewLine1 { get { return Body().NewLine1; } }
            public TTReportField G336_06_01 { get { return Body().G336_06_01; } }
            public TTReportField G336_06_02 { get { return Body().G336_06_02; } }
            public TTReportField GCASH { get { return Body().GCASH; } }
            public TTReportShape NewLine1611131 { get { return Body().NewLine1611131; } }
            public TTReportShape NewLine1611132 { get { return Body().NewLine1611132; } }
            public TTReportField GCC { get { return Body().GCC; } }
            public TTReportField G600_01_02_04 { get { return Body().G600_01_02_04; } }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }


            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<AccountDocument.CashOfficeRevenueReportQuery_Class>("CashOfficeRevenueReportQuery", AccountDocument.CashOfficeRevenueReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE), (DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE), (Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.CASHOFFICE), (int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.CASHOFFICECONTROL), (Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.CASHIER), (int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.CASHIERCONTROL), ((PaymentTypeCashCCEnum)TTObjectDefManager.Instance.DataTypes["PaymentTypeCashCCEnum"].EnumValueDefs[MyParentReport.RuntimeParameters.PAYMENTTYPE.ToString()].EnumValue), (int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.PAYMENTTYPECONTROL)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public CashOfficeRevenueReport MyParentReport
                {
                    get { return (CashOfficeRevenueReport)ParentReport; }
                }

                public TTReportField DOCUMENTDATE;
                public TTReportField DOCUMENTNO;
                public TTReportField STATUS;
                public TTReportField G600_01_01_01;
                public TTReportField G600_01_02_01;
                public TTReportField G600_01_01_02;
                public TTReportField G600_01_03_01;
                public TTReportField G600_01_02_02;
                public TTReportField G600_01_03_02;
                public TTReportField G600_01_04_01;
                public TTReportField G600_01_04_02;
                public TTReportField G600_01_01_04_01;
                public TTReportField G600_01_05_01;
                public TTReportField G600_01_05_02;
                public TTReportField G600_01_07_01;
                public TTReportField G600_01_08_02;
                public TTReportField G600_01_99;
                public TTReportField G600_01_06_01;
                public TTReportField G600_01_08_01;
                public TTReportField G600_01_94;
                public TTReportField G195_01;
                public TTReportField G340_11_01;
                public TTReportField G649_09_09_02;
                public TTReportField G679_09_9099;
                public TTReportField GTOTAL;
                public TTReportField OBJECTDEF;
                public TTReportField OBJECTID;
                public TTReportField PAYMENTTYPE;
                public TTReportField STATESTATUS;
                public TTReportField ACCOUNTCODE;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine11111;
                public TTReportShape NewLine11112;
                public TTReportShape NewLine11113;
                public TTReportShape NewLine131111;
                public TTReportShape NewLine131112;
                public TTReportShape NewLine131113;
                public TTReportShape NewLine131114;
                public TTReportShape NewLine131116;
                public TTReportShape NewLine131117;
                public TTReportShape NewLine1311131;
                public TTReportShape NewLine1311132;
                public TTReportShape NewLine1311133;
                public TTReportShape NewLine1311134;
                public TTReportShape NewLine1311135;
                public TTReportShape NewLine1311136;
                public TTReportShape NewLine1311137;
                public TTReportShape NewLine1311138;
                public TTReportShape NewLine1311139;
                public TTReportShape NewLine1311140;
                public TTReportShape NewLine17311131;
                public TTReportShape NewLine18311131;
                public TTReportShape NewLine19311131;
                public TTReportShape NewLine10411131;
                public TTReportShape NewLine17311132;
                public TTReportShape NewLine18311132;
                public TTReportShape NewLine113111401;
                public TTReportShape NewLine123111371;
                public TTReportShape NewLine123111381;
                public TTReportShape NewLine113111402;
                public TTReportField DESCRIPTION;
                public TTReportShape NewLine11;
                public TTReportField G601_01_01_01;
                public TTReportField G601_01_02_01;
                public TTReportField G601_01_01_02;
                public TTReportField G601_01_03_01;
                public TTReportField G601_01_02_02;
                public TTReportField G601_01_03_02;
                public TTReportField G601_01_04_01;
                public TTReportField G601_01_04_02;
                public TTReportField G601_01_01_04_01;
                public TTReportField G601_01_05_01;
                public TTReportField G601_01_05_02;
                public TTReportField G601_01_07_01;
                public TTReportField G601_01_08_02;
                public TTReportField G601_01_99;
                public TTReportField G601_01_06_01;
                public TTReportField G601_01_08_01;
                public TTReportShape NewLine1211131;
                public TTReportShape NewLine1311141;
                public TTReportShape NewLine11311131;
                public TTReportShape NewLine12311131;
                public TTReportShape NewLine13311131;
                public TTReportShape NewLine14311131;
                public TTReportShape NewLine15311131;
                public TTReportShape NewLine16311131;
                public TTReportShape NewLine17311133;
                public TTReportShape NewLine18311133;
                public TTReportShape NewLine19311132;
                public TTReportShape NewLine10411132;
                public TTReportShape NewLine113111371;
                public TTReportShape NewLine113111381;
                public TTReportShape NewLine113111391;
                public TTReportShape NewLine1;
                public TTReportField G336_06_01;
                public TTReportField G336_06_02;
                public TTReportField GCASH;
                public TTReportShape NewLine1611131;
                public TTReportShape NewLine1611132;
                public TTReportField GCC;
                public TTReportField G600_01_02_04;
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;

                    DOCUMENTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 0, 18, 8, false);
                    DOCUMENTDATE.Name = "DOCUMENTDATE";
                    DOCUMENTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTDATE.TextFormat = @"dd/MM/yyyy";
                    DOCUMENTDATE.TextFont.Size = 7;
                    DOCUMENTDATE.TextFont.CharSet = 162;
                    DOCUMENTDATE.Value = @"{#DOCUMENTDATE#}";

                    DOCUMENTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 0, 33, 8, false);
                    DOCUMENTNO.Name = "DOCUMENTNO";
                    DOCUMENTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNO.MultiLine = EvetHayirEnum.ehEvet;
                    DOCUMENTNO.WordBreak = EvetHayirEnum.ehEvet;
                    DOCUMENTNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    DOCUMENTNO.TextFont.Size = 7;
                    DOCUMENTNO.TextFont.CharSet = 162;
                    DOCUMENTNO.Value = @"{#DOCUMENTNO#}";

                    STATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 0, 62, 8, false);
                    STATUS.Name = "STATUS";
                    STATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    STATUS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    STATUS.TextFont.Size = 7;
                    STATUS.TextFont.CharSet = 162;
                    STATUS.Value = @"";

                    G600_01_01_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 0, 71, 4, false);
                    G600_01_01_01.Name = "G600_01_01_01";
                    G600_01_01_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    G600_01_01_01.TextFormat = @"#,##0.#0";
                    G600_01_01_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G600_01_01_01.TextFont.Size = 7;
                    G600_01_01_01.TextFont.CharSet = 162;
                    G600_01_01_01.Value = @"";

                    G600_01_02_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 0, 89, 4, false);
                    G600_01_02_01.Name = "G600_01_02_01";
                    G600_01_02_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    G600_01_02_01.TextFormat = @"#,##0.#0";
                    G600_01_02_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G600_01_02_01.TextFont.Size = 7;
                    G600_01_02_01.TextFont.CharSet = 162;
                    G600_01_02_01.Value = @"";

                    G600_01_01_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 0, 80, 4, false);
                    G600_01_01_02.Name = "G600_01_01_02";
                    G600_01_01_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    G600_01_01_02.TextFormat = @"#,##0.#0";
                    G600_01_01_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G600_01_01_02.TextFont.Size = 7;
                    G600_01_01_02.TextFont.CharSet = 162;
                    G600_01_01_02.Value = @"";

                    G600_01_03_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 0, 116, 4, false);
                    G600_01_03_01.Name = "G600_01_03_01";
                    G600_01_03_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    G600_01_03_01.TextFormat = @"#,##0.#0";
                    G600_01_03_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G600_01_03_01.TextFont.Size = 7;
                    G600_01_03_01.TextFont.CharSet = 162;
                    G600_01_03_01.Value = @"";

                    G600_01_02_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 0, 98, 4, false);
                    G600_01_02_02.Name = "G600_01_02_02";
                    G600_01_02_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    G600_01_02_02.TextFormat = @"#,##0.#0";
                    G600_01_02_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G600_01_02_02.TextFont.Size = 7;
                    G600_01_02_02.TextFont.CharSet = 162;
                    G600_01_02_02.Value = @"";

                    G600_01_03_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 0, 125, 4, false);
                    G600_01_03_02.Name = "G600_01_03_02";
                    G600_01_03_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    G600_01_03_02.TextFormat = @"#,##0.#0";
                    G600_01_03_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G600_01_03_02.TextFont.Size = 7;
                    G600_01_03_02.TextFont.CharSet = 162;
                    G600_01_03_02.Value = @"";

                    G600_01_04_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 0, 134, 4, false);
                    G600_01_04_01.Name = "G600_01_04_01";
                    G600_01_04_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    G600_01_04_01.TextFormat = @"#,##0.#0";
                    G600_01_04_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G600_01_04_01.TextFont.Size = 7;
                    G600_01_04_01.TextFont.CharSet = 162;
                    G600_01_04_01.Value = @"";

                    G600_01_04_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 0, 143, 4, false);
                    G600_01_04_02.Name = "G600_01_04_02";
                    G600_01_04_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    G600_01_04_02.TextFormat = @"#,##0.#0";
                    G600_01_04_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G600_01_04_02.TextFont.Size = 7;
                    G600_01_04_02.TextFont.CharSet = 162;
                    G600_01_04_02.Value = @"";

                    G600_01_01_04_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 0, 152, 4, false);
                    G600_01_01_04_01.Name = "G600_01_01_04_01";
                    G600_01_01_04_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    G600_01_01_04_01.TextFormat = @"#,##0.#0";
                    G600_01_01_04_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G600_01_01_04_01.TextFont.Size = 7;
                    G600_01_01_04_01.TextFont.CharSet = 162;
                    G600_01_01_04_01.Value = @"";

                    G600_01_05_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 0, 161, 4, false);
                    G600_01_05_01.Name = "G600_01_05_01";
                    G600_01_05_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    G600_01_05_01.TextFormat = @"#,##0.#0";
                    G600_01_05_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G600_01_05_01.TextFont.Size = 7;
                    G600_01_05_01.TextFont.CharSet = 162;
                    G600_01_05_01.Value = @"";

                    G600_01_05_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 0, 170, 4, false);
                    G600_01_05_02.Name = "G600_01_05_02";
                    G600_01_05_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    G600_01_05_02.TextFormat = @"#,##0.#0";
                    G600_01_05_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G600_01_05_02.TextFont.Size = 7;
                    G600_01_05_02.TextFont.CharSet = 162;
                    G600_01_05_02.Value = @"";

                    G600_01_07_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 0, 188, 4, false);
                    G600_01_07_01.Name = "G600_01_07_01";
                    G600_01_07_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    G600_01_07_01.TextFormat = @"#,##0.#0";
                    G600_01_07_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G600_01_07_01.TextFont.Size = 7;
                    G600_01_07_01.TextFont.CharSet = 162;
                    G600_01_07_01.Value = @"";

                    G600_01_08_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 197, 0, 206, 4, false);
                    G600_01_08_02.Name = "G600_01_08_02";
                    G600_01_08_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    G600_01_08_02.TextFormat = @"#,##0.#0";
                    G600_01_08_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G600_01_08_02.TextFont.Size = 7;
                    G600_01_08_02.TextFont.CharSet = 162;
                    G600_01_08_02.Value = @"";

                    G600_01_99 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 206, 0, 215, 4, false);
                    G600_01_99.Name = "G600_01_99";
                    G600_01_99.FieldType = ReportFieldTypeEnum.ftVariable;
                    G600_01_99.TextFormat = @"#,##0.#0";
                    G600_01_99.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G600_01_99.TextFont.Size = 7;
                    G600_01_99.TextFont.CharSet = 162;
                    G600_01_99.Value = @"";

                    G600_01_06_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 0, 179, 4, false);
                    G600_01_06_01.Name = "G600_01_06_01";
                    G600_01_06_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    G600_01_06_01.TextFormat = @"#,##0.#0";
                    G600_01_06_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G600_01_06_01.TextFont.Size = 7;
                    G600_01_06_01.TextFont.CharSet = 162;
                    G600_01_06_01.Value = @"";

                    G600_01_08_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 0, 197, 4, false);
                    G600_01_08_01.Name = "G600_01_08_01";
                    G600_01_08_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    G600_01_08_01.TextFormat = @"#,##0.#0";
                    G600_01_08_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G600_01_08_01.TextFont.Size = 7;
                    G600_01_08_01.TextFont.CharSet = 162;
                    G600_01_08_01.Value = @"";

                    G600_01_94 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 242, 0, 252, 4, false);
                    G600_01_94.Name = "G600_01_94";
                    G600_01_94.FieldType = ReportFieldTypeEnum.ftVariable;
                    G600_01_94.TextFormat = @"#,##0.#0";
                    G600_01_94.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G600_01_94.TextFont.Size = 7;
                    G600_01_94.TextFont.CharSet = 162;
                    G600_01_94.Value = @"";

                    G195_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 0, 231, 4, false);
                    G195_01.Name = "G195_01";
                    G195_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    G195_01.TextFormat = @"#,##0.#0";
                    G195_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G195_01.TextFont.Size = 7;
                    G195_01.TextFont.CharSet = 162;
                    G195_01.Value = @"";

                    G340_11_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 0, 223, 4, false);
                    G340_11_01.Name = "G340_11_01";
                    G340_11_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    G340_11_01.TextFormat = @"#,##0.#0";
                    G340_11_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G340_11_01.TextFont.Size = 7;
                    G340_11_01.TextFont.CharSet = 162;
                    G340_11_01.Value = @"";

                    G649_09_09_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 252, 0, 260, 4, false);
                    G649_09_09_02.Name = "G649_09_09_02";
                    G649_09_09_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    G649_09_09_02.TextFormat = @"#,##0.#0";
                    G649_09_09_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G649_09_09_02.TextFont.Size = 7;
                    G649_09_09_02.TextFont.CharSet = 162;
                    G649_09_09_02.Value = @"";

                    G679_09_9099 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 260, 0, 268, 4, false);
                    G679_09_9099.Name = "G679_09_9099";
                    G679_09_9099.FieldType = ReportFieldTypeEnum.ftVariable;
                    G679_09_9099.TextFormat = @"#,##0.#0";
                    G679_09_9099.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G679_09_9099.TextFont.Size = 7;
                    G679_09_9099.TextFont.CharSet = 162;
                    G679_09_9099.Value = @"";

                    GTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 286, 0, 296, 8, false);
                    GTOTAL.Name = "GTOTAL";
                    GTOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    GTOTAL.TextFormat = @"#,##0.#0";
                    GTOTAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GTOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GTOTAL.TextFont.Size = 7;
                    GTOTAL.TextFont.CharSet = 162;
                    GTOTAL.Value = @"{#TOTALPRICE#}";

                    OBJECTDEF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 299, 0, 317, 4, false);
                    OBJECTDEF.Name = "OBJECTDEF";
                    OBJECTDEF.Visible = EvetHayirEnum.ehHayir;
                    OBJECTDEF.DrawStyle = DrawStyleConstants.vbSolid;
                    OBJECTDEF.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTDEF.CaseFormat = CaseFormatEnum.fcUpperCase;
                    OBJECTDEF.TextFont.Size = 8;
                    OBJECTDEF.TextFont.CharSet = 162;
                    OBJECTDEF.Value = @"{#OBJECTDEF#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 320, 0, 340, 4, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.DrawStyle = DrawStyleConstants.vbSolid;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.TextFont.Size = 8;
                    OBJECTID.TextFont.CharSet = 162;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    PAYMENTTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 343, 0, 363, 4, false);
                    PAYMENTTYPE.Name = "PAYMENTTYPE";
                    PAYMENTTYPE.Visible = EvetHayirEnum.ehHayir;
                    PAYMENTTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    PAYMENTTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYMENTTYPE.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYMENTTYPE.TextFont.Size = 8;
                    PAYMENTTYPE.TextFont.CharSet = 162;
                    PAYMENTTYPE.Value = @"{#PAYMENTTYPE#}";

                    STATESTATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 366, 0, 391, 4, false);
                    STATESTATUS.Name = "STATESTATUS";
                    STATESTATUS.Visible = EvetHayirEnum.ehHayir;
                    STATESTATUS.DrawStyle = DrawStyleConstants.vbSolid;
                    STATESTATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    STATESTATUS.Value = @"{#STATESTATUS#}";

                    ACCOUNTCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 394, 0, 419, 4, false);
                    ACCOUNTCODE.Name = "ACCOUNTCODE";
                    ACCOUNTCODE.Visible = EvetHayirEnum.ehHayir;
                    ACCOUNTCODE.DrawStyle = DrawStyleConstants.vbSolid;
                    ACCOUNTCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCOUNTCODE.Value = @"{#ACCOUNTCODE#}";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 0, 6, 8, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 0, 18, 8, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine11112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 33, 0, 33, 8, false);
                    NewLine11112.Name = "NewLine11112";
                    NewLine11112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11112.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine11113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 57, 0, 57, 8, false);
                    NewLine11113.Name = "NewLine11113";
                    NewLine11113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11113.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine131111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 62, 0, 62, 8, false);
                    NewLine131111.Name = "NewLine131111";
                    NewLine131111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine131111.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine131112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 71, 0, 71, 5, false);
                    NewLine131112.Name = "NewLine131112";
                    NewLine131112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine131112.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine131113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 80, 0, 80, 5, false);
                    NewLine131113.Name = "NewLine131113";
                    NewLine131113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine131113.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine131114 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 260, 0, 260, 4, false);
                    NewLine131114.Name = "NewLine131114";
                    NewLine131114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine131114.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine131116 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 286, 0, 286, 8, false);
                    NewLine131116.Name = "NewLine131116";
                    NewLine131116.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine131116.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine131117 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 296, 0, 296, 8, false);
                    NewLine131117.Name = "NewLine131117";
                    NewLine131117.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine131117.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1311131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 98, 0, 98, 5, false);
                    NewLine1311131.Name = "NewLine1311131";
                    NewLine1311131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1311131.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1311132 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 89, 0, 89, 5, false);
                    NewLine1311132.Name = "NewLine1311132";
                    NewLine1311132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1311132.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1311133 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 107, 0, 107, 5, false);
                    NewLine1311133.Name = "NewLine1311133";
                    NewLine1311133.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1311133.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1311134 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 116, 0, 116, 5, false);
                    NewLine1311134.Name = "NewLine1311134";
                    NewLine1311134.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1311134.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1311135 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 125, 0, 125, 5, false);
                    NewLine1311135.Name = "NewLine1311135";
                    NewLine1311135.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1311135.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1311136 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 134, 0, 134, 5, false);
                    NewLine1311136.Name = "NewLine1311136";
                    NewLine1311136.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1311136.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1311137 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 143, 0, 143, 5, false);
                    NewLine1311137.Name = "NewLine1311137";
                    NewLine1311137.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1311137.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1311138 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 152, 0, 152, 5, false);
                    NewLine1311138.Name = "NewLine1311138";
                    NewLine1311138.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1311138.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1311139 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 161, 0, 161, 5, false);
                    NewLine1311139.Name = "NewLine1311139";
                    NewLine1311139.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1311139.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1311140 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 170, 0, 170, 5, false);
                    NewLine1311140.Name = "NewLine1311140";
                    NewLine1311140.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1311140.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine17311131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 179, 0, 179, 5, false);
                    NewLine17311131.Name = "NewLine17311131";
                    NewLine17311131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine17311131.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine18311131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 188, 0, 188, 5, false);
                    NewLine18311131.Name = "NewLine18311131";
                    NewLine18311131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine18311131.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine19311131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 197, 0, 197, 5, false);
                    NewLine19311131.Name = "NewLine19311131";
                    NewLine19311131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine19311131.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine10411131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 206, 0, 206, 8, false);
                    NewLine10411131.Name = "NewLine10411131";
                    NewLine10411131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine10411131.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine17311132 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 215, 0, 215, 8, false);
                    NewLine17311132.Name = "NewLine17311132";
                    NewLine17311132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine17311132.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine18311132 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 223, 0, 223, 4, false);
                    NewLine18311132.Name = "NewLine18311132";
                    NewLine18311132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine18311132.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine113111401 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 231, 0, 231, 4, false);
                    NewLine113111401.Name = "NewLine113111401";
                    NewLine113111401.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine113111401.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine123111371 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 252, 0, 252, 4, false);
                    NewLine123111371.Name = "NewLine123111371";
                    NewLine123111371.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine123111371.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine123111381 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 231, 0, 231, 8, false);
                    NewLine123111381.Name = "NewLine123111381";
                    NewLine123111381.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine123111381.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine113111402 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 242, 0, 242, 8, false);
                    NewLine113111402.Name = "NewLine113111402";
                    NewLine113111402.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine113111402.ExtendTo = ExtendToEnum.extSectionHeight;

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 0, 56, 8, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Size = 7;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{#EPISODEID#} - {#PATIENTNAME#}";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 0, 296, 0, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    G601_01_01_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 4, 71, 8, false);
                    G601_01_01_01.Name = "G601_01_01_01";
                    G601_01_01_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    G601_01_01_01.TextFormat = @"#,##0.#0";
                    G601_01_01_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G601_01_01_01.TextFont.Size = 7;
                    G601_01_01_01.TextFont.CharSet = 162;
                    G601_01_01_01.Value = @"";

                    G601_01_02_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 4, 89, 8, false);
                    G601_01_02_01.Name = "G601_01_02_01";
                    G601_01_02_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    G601_01_02_01.TextFormat = @"#,##0.#0";
                    G601_01_02_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G601_01_02_01.TextFont.Size = 7;
                    G601_01_02_01.TextFont.CharSet = 162;
                    G601_01_02_01.Value = @"";

                    G601_01_01_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 4, 80, 8, false);
                    G601_01_01_02.Name = "G601_01_01_02";
                    G601_01_01_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    G601_01_01_02.TextFormat = @"#,##0.#0";
                    G601_01_01_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G601_01_01_02.TextFont.Size = 7;
                    G601_01_01_02.TextFont.CharSet = 162;
                    G601_01_01_02.Value = @"";

                    G601_01_03_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 4, 116, 8, false);
                    G601_01_03_01.Name = "G601_01_03_01";
                    G601_01_03_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    G601_01_03_01.TextFormat = @"#,##0.#0";
                    G601_01_03_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G601_01_03_01.TextFont.Size = 7;
                    G601_01_03_01.TextFont.CharSet = 162;
                    G601_01_03_01.Value = @"";

                    G601_01_02_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 4, 98, 8, false);
                    G601_01_02_02.Name = "G601_01_02_02";
                    G601_01_02_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    G601_01_02_02.TextFormat = @"#,##0.#0";
                    G601_01_02_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G601_01_02_02.TextFont.Size = 7;
                    G601_01_02_02.TextFont.CharSet = 162;
                    G601_01_02_02.Value = @"";

                    G601_01_03_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 4, 125, 8, false);
                    G601_01_03_02.Name = "G601_01_03_02";
                    G601_01_03_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    G601_01_03_02.TextFormat = @"#,##0.#0";
                    G601_01_03_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G601_01_03_02.TextFont.Size = 7;
                    G601_01_03_02.TextFont.CharSet = 162;
                    G601_01_03_02.Value = @"";

                    G601_01_04_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 4, 134, 8, false);
                    G601_01_04_01.Name = "G601_01_04_01";
                    G601_01_04_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    G601_01_04_01.TextFormat = @"#,##0.#0";
                    G601_01_04_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G601_01_04_01.TextFont.Size = 7;
                    G601_01_04_01.TextFont.CharSet = 162;
                    G601_01_04_01.Value = @"";

                    G601_01_04_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 4, 143, 8, false);
                    G601_01_04_02.Name = "G601_01_04_02";
                    G601_01_04_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    G601_01_04_02.TextFormat = @"#,##0.#0";
                    G601_01_04_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G601_01_04_02.TextFont.Size = 7;
                    G601_01_04_02.TextFont.CharSet = 162;
                    G601_01_04_02.Value = @"";

                    G601_01_01_04_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 4, 152, 8, false);
                    G601_01_01_04_01.Name = "G601_01_01_04_01";
                    G601_01_01_04_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    G601_01_01_04_01.TextFormat = @"#,##0.#0";
                    G601_01_01_04_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G601_01_01_04_01.TextFont.Size = 7;
                    G601_01_01_04_01.TextFont.CharSet = 162;
                    G601_01_01_04_01.Value = @"";

                    G601_01_05_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 4, 161, 8, false);
                    G601_01_05_01.Name = "G601_01_05_01";
                    G601_01_05_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    G601_01_05_01.TextFormat = @"#,##0.#0";
                    G601_01_05_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G601_01_05_01.TextFont.Size = 7;
                    G601_01_05_01.TextFont.CharSet = 162;
                    G601_01_05_01.Value = @"";

                    G601_01_05_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 4, 170, 8, false);
                    G601_01_05_02.Name = "G601_01_05_02";
                    G601_01_05_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    G601_01_05_02.TextFormat = @"#,##0.#0";
                    G601_01_05_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G601_01_05_02.TextFont.Size = 7;
                    G601_01_05_02.TextFont.CharSet = 162;
                    G601_01_05_02.Value = @"";

                    G601_01_07_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 4, 188, 8, false);
                    G601_01_07_01.Name = "G601_01_07_01";
                    G601_01_07_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    G601_01_07_01.TextFormat = @"#,##0.#0";
                    G601_01_07_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G601_01_07_01.TextFont.Size = 7;
                    G601_01_07_01.TextFont.CharSet = 162;
                    G601_01_07_01.Value = @"";

                    G601_01_08_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 197, 4, 206, 8, false);
                    G601_01_08_02.Name = "G601_01_08_02";
                    G601_01_08_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    G601_01_08_02.TextFormat = @"#,##0.#0";
                    G601_01_08_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G601_01_08_02.TextFont.Size = 7;
                    G601_01_08_02.TextFont.CharSet = 162;
                    G601_01_08_02.Value = @"";

                    G601_01_99 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 206, 4, 215, 8, false);
                    G601_01_99.Name = "G601_01_99";
                    G601_01_99.FieldType = ReportFieldTypeEnum.ftVariable;
                    G601_01_99.TextFormat = @"#,##0.#0";
                    G601_01_99.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G601_01_99.TextFont.Size = 7;
                    G601_01_99.TextFont.CharSet = 162;
                    G601_01_99.Value = @"";

                    G601_01_06_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 4, 179, 8, false);
                    G601_01_06_01.Name = "G601_01_06_01";
                    G601_01_06_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    G601_01_06_01.TextFormat = @"#,##0.#0";
                    G601_01_06_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G601_01_06_01.TextFont.Size = 7;
                    G601_01_06_01.TextFont.CharSet = 162;
                    G601_01_06_01.Value = @"";

                    G601_01_08_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 4, 197, 8, false);
                    G601_01_08_01.Name = "G601_01_08_01";
                    G601_01_08_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    G601_01_08_01.TextFormat = @"#,##0.#0";
                    G601_01_08_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G601_01_08_01.TextFont.Size = 7;
                    G601_01_08_01.TextFont.CharSet = 162;
                    G601_01_08_01.Value = @"";

                    NewLine1211131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 71, 5, 71, 8, false);
                    NewLine1211131.Name = "NewLine1211131";
                    NewLine1211131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1211131.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1311141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 80, 5, 80, 8, false);
                    NewLine1311141.Name = "NewLine1311141";
                    NewLine1311141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1311141.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine11311131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 98, 5, 98, 8, false);
                    NewLine11311131.Name = "NewLine11311131";
                    NewLine11311131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11311131.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine12311131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 89, 5, 89, 8, false);
                    NewLine12311131.Name = "NewLine12311131";
                    NewLine12311131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12311131.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine13311131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 107, 5, 107, 8, false);
                    NewLine13311131.Name = "NewLine13311131";
                    NewLine13311131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13311131.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine14311131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 116, 5, 116, 8, false);
                    NewLine14311131.Name = "NewLine14311131";
                    NewLine14311131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14311131.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine15311131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 125, 5, 125, 8, false);
                    NewLine15311131.Name = "NewLine15311131";
                    NewLine15311131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine15311131.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine16311131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 134, 5, 134, 8, false);
                    NewLine16311131.Name = "NewLine16311131";
                    NewLine16311131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine16311131.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine17311133 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 143, 5, 143, 8, false);
                    NewLine17311133.Name = "NewLine17311133";
                    NewLine17311133.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine17311133.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine18311133 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 152, 5, 152, 8, false);
                    NewLine18311133.Name = "NewLine18311133";
                    NewLine18311133.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine18311133.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine19311132 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 161, 5, 161, 8, false);
                    NewLine19311132.Name = "NewLine19311132";
                    NewLine19311132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine19311132.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine10411132 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 170, 5, 170, 8, false);
                    NewLine10411132.Name = "NewLine10411132";
                    NewLine10411132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine10411132.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine113111371 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 179, 5, 179, 8, false);
                    NewLine113111371.Name = "NewLine113111371";
                    NewLine113111371.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine113111371.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine113111381 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 188, 5, 188, 8, false);
                    NewLine113111381.Name = "NewLine113111381";
                    NewLine113111381.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine113111381.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine113111391 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 197, 5, 197, 8, false);
                    NewLine113111391.Name = "NewLine113111391";
                    NewLine113111391.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine113111391.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 62, 4, 268, 4, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    G336_06_01 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 0, 242, 4, false);
                    G336_06_01.Name = "G336_06_01";
                    G336_06_01.FieldType = ReportFieldTypeEnum.ftVariable;
                    G336_06_01.TextFormat = @"#,##0.#0";
                    G336_06_01.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G336_06_01.TextFont.Size = 7;
                    G336_06_01.TextFont.CharSet = 162;
                    G336_06_01.Value = @"";

                    G336_06_02 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 4, 242, 8, false);
                    G336_06_02.Name = "G336_06_02";
                    G336_06_02.FieldType = ReportFieldTypeEnum.ftVariable;
                    G336_06_02.TextFormat = @"#,##0.#0";
                    G336_06_02.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G336_06_02.TextFont.Size = 7;
                    G336_06_02.TextFont.CharSet = 162;
                    G336_06_02.Value = @"";

                    GCASH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 268, 0, 277, 8, false);
                    GCASH.Name = "GCASH";
                    GCASH.FieldType = ReportFieldTypeEnum.ftVariable;
                    GCASH.TextFormat = @"#,##0.#0";
                    GCASH.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GCASH.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GCASH.TextFont.Size = 7;
                    GCASH.TextFont.CharSet = 162;
                    GCASH.Value = @"";

                    NewLine1611131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 268, 0, 268, 8, false);
                    NewLine1611131.Name = "NewLine1611131";
                    NewLine1611131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1611131.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1611132 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 277, 0, 277, 8, false);
                    NewLine1611132.Name = "NewLine1611132";
                    NewLine1611132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1611132.ExtendTo = ExtendToEnum.extSectionHeight;

                    GCC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 277, 0, 286, 8, false);
                    GCC.Name = "GCC";
                    GCC.FieldType = ReportFieldTypeEnum.ftVariable;
                    GCC.TextFormat = @"#,##0.#0";
                    GCC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GCC.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GCC.TextFont.Size = 7;
                    GCC.TextFont.CharSet = 162;
                    GCC.Value = @"";

                    G600_01_02_04 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 0, 107, 4, false);
                    G600_01_02_04.Name = "G600_01_02_04";
                    G600_01_02_04.FieldType = ReportFieldTypeEnum.ftVariable;
                    G600_01_02_04.TextFormat = @"#,##0.#0";
                    G600_01_02_04.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    G600_01_02_04.TextFont.Size = 7;
                    G600_01_02_04.TextFont.CharSet = 162;
                    G600_01_02_04.Value = @"";

                }


                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountDocument.CashOfficeRevenueReportQuery_Class dataset_CashOfficeRevenueReportQuery = ParentGroup.rsGroup.GetCurrentRecord<AccountDocument.CashOfficeRevenueReportQuery_Class>(0);
                    DOCUMENTDATE.CalcValue = (dataset_CashOfficeRevenueReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeRevenueReportQuery.DocumentDate) : "");
                    DOCUMENTNO.CalcValue = (dataset_CashOfficeRevenueReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeRevenueReportQuery.DocumentNo) : "");
                    STATUS.CalcValue = @"";
                    G600_01_01_01.CalcValue = @"";
                    G600_01_02_01.CalcValue = @"";
                    G600_01_01_02.CalcValue = @"";
                    G600_01_03_01.CalcValue = @"";
                    G600_01_02_02.CalcValue = @"";
                    G600_01_03_02.CalcValue = @"";
                    G600_01_04_01.CalcValue = @"";
                    G600_01_04_02.CalcValue = @"";
                    G600_01_01_04_01.CalcValue = @"";
                    G600_01_05_01.CalcValue = @"";
                    G600_01_05_02.CalcValue = @"";
                    G600_01_07_01.CalcValue = @"";
                    G600_01_08_02.CalcValue = @"";
                    G600_01_99.CalcValue = @"";
                    G600_01_06_01.CalcValue = @"";
                    G600_01_08_01.CalcValue = @"";
                    G600_01_94.CalcValue = @"";
                    G195_01.CalcValue = @"";
                    G340_11_01.CalcValue = @"";
                    G649_09_09_02.CalcValue = @"";
                    G679_09_9099.CalcValue = @"";
                    GTOTAL.CalcValue = (dataset_CashOfficeRevenueReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeRevenueReportQuery.TotalPrice) : "");
                    OBJECTDEF.CalcValue = (dataset_CashOfficeRevenueReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeRevenueReportQuery.Objectdef) : "");
                    OBJECTID.CalcValue = (dataset_CashOfficeRevenueReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeRevenueReportQuery.ObjectID) : "");
                    PAYMENTTYPE.CalcValue = (dataset_CashOfficeRevenueReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeRevenueReportQuery.PaymentType) : "");
                    STATESTATUS.CalcValue = (dataset_CashOfficeRevenueReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeRevenueReportQuery.Statestatus) : "");
                    ACCOUNTCODE.CalcValue = (dataset_CashOfficeRevenueReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeRevenueReportQuery.Accountcode) : "");
                    DESCRIPTION.CalcValue = (dataset_CashOfficeRevenueReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeRevenueReportQuery.Episodeid) : "") + @" - " + (dataset_CashOfficeRevenueReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeRevenueReportQuery.Patientname) : "");
                    G601_01_01_01.CalcValue = @"";
                    G601_01_02_01.CalcValue = @"";
                    G601_01_01_02.CalcValue = @"";
                    G601_01_03_01.CalcValue = @"";
                    G601_01_02_02.CalcValue = @"";
                    G601_01_03_02.CalcValue = @"";
                    G601_01_04_01.CalcValue = @"";
                    G601_01_04_02.CalcValue = @"";
                    G601_01_01_04_01.CalcValue = @"";
                    G601_01_05_01.CalcValue = @"";
                    G601_01_05_02.CalcValue = @"";
                    G601_01_07_01.CalcValue = @"";
                    G601_01_08_02.CalcValue = @"";
                    G601_01_99.CalcValue = @"";
                    G601_01_06_01.CalcValue = @"";
                    G601_01_08_01.CalcValue = @"";
                    G336_06_01.CalcValue = @"";
                    G336_06_02.CalcValue = @"";
                    GCASH.CalcValue = @"";
                    GCC.CalcValue = @"";
                    G600_01_02_04.CalcValue = @"";
                    return new TTReportObject[] { DOCUMENTDATE, DOCUMENTNO, STATUS, G600_01_01_01, G600_01_02_01, G600_01_01_02, G600_01_03_01, G600_01_02_02, G600_01_03_02, G600_01_04_01, G600_01_04_02, G600_01_01_04_01, G600_01_05_01, G600_01_05_02, G600_01_07_01, G600_01_08_02, G600_01_99, G600_01_06_01, G600_01_08_01, G600_01_94, G195_01, G340_11_01, G649_09_09_02, G679_09_9099, GTOTAL, OBJECTDEF, OBJECTID, PAYMENTTYPE, STATESTATUS, ACCOUNTCODE, DESCRIPTION, G601_01_01_01, G601_01_02_01, G601_01_01_02, G601_01_03_01, G601_01_02_02, G601_01_03_02, G601_01_04_01, G601_01_04_02, G601_01_01_04_01, G601_01_05_01, G601_01_05_02, G601_01_07_01, G601_01_08_02, G601_01_99, G601_01_06_01, G601_01_08_01, G336_06_01, G336_06_02, GCASH, GCC, G600_01_02_04 };
                }

                public override void RunScript()
                {
                    #region MAIN BODY_Script
                    this.DOCUMENTNO.CalcValue = AccountDocument.ReceiptDocumentNo(this.DOCUMENTNO.CalcValue);
                    if (string.IsNullOrEmpty(MyParentReport.firstDocumentNo))
                        MyParentReport.firstDocumentNo = this.DOCUMENTNO.CalcValue;
                    MyParentReport.lastDocumentNo = this.DOCUMENTNO.CalcValue;
                    MyParentReport.mainDataCounter++;
                    if (this.OBJECTDEF.CalcValue.Equals("RECEIPTDOCUMENT"))
                    {
                        foreach (ReceiptDetail rd in MyParentReport.receiptDetailList.Where(x => x.ObjectId.Equals(this.OBJECTID.CalcValue)))
                        {
                            TTReportField field = MyParentReport.MAIN.Fields("G" + rd.AccountCode.Replace(".", "_"));
                            if (field != null)
                                field.CalcValue = ((!string.IsNullOrEmpty(field.CalcValue) ? Convert.ToDecimal(field.CalcValue) : 0) + rd.Price).ToString();
                            else
                            {
                                if (rd.AccountCode.StartsWith("601."))
                                    this.G601_01_99.CalcValue = ((!string.IsNullOrEmpty(this.G601_01_99.CalcValue) ? Convert.ToDecimal(this.G601_01_99.CalcValue) : 0) + rd.Price).ToString();
                                else
                                    this.G600_01_99.CalcValue = ((!string.IsNullOrEmpty(this.G600_01_99.CalcValue) ? Convert.ToDecimal(this.G600_01_99.CalcValue) : 0) + rd.Price).ToString();
                            }
                        }
                    }
                    else if (this.OBJECTDEF.CalcValue.Equals("ADVANCEDOCUMENT"))
                    {
                        this.G340_11_01.CalcValue = this.GTOTAL.CalcValue;
                    }
                    else if (this.OBJECTDEF.CalcValue.Equals("CASHOFFICERECEIPTDOCUMENT"))
                    {
                        TTReportField field = MyParentReport.MAIN.Fields("G" + this.ACCOUNTCODE.CalcValue.Replace(".", "_"));
                        if (field != null)
                            field.CalcValue = this.GTOTAL.CalcValue;
                        else
                            this.G679_09_9099.CalcValue = this.GTOTAL.CalcValue;
                    }
                    else if (this.OBJECTDEF.CalcValue.Equals("BONDPAYMENTDOCUMENT"))
                    {
                        this.G679_09_9099.CalcValue = this.GTOTAL.CalcValue;
                    }
                    else if (this.OBJECTDEF.CalcValue.Equals("OLDDEBTRECEIPTDOCUMENT"))
                    {
                        this.G600_01_99.CalcValue = this.GTOTAL.CalcValue;

                        OldDebtReceiptDocument oldReceipt = MyParentReport.ReportObjectContext.GetObject(new Guid(this.OBJECTID.CalcValue), typeof(OldDebtReceiptDocument)) as OldDebtReceiptDocument;
                        if (oldReceipt.PatientOldDebt.Count() > 0)
                            this.DESCRIPTION.CalcValue = oldReceipt.PatientOldDebt[0].OldPatientNameSurname;
                    }

                    if (this.STATESTATUS.CalcValue.Equals("4"))
                    {
                        this.STATUS.CalcValue = "İptal";

                        this.G600_01_01_01.CalcValue = !string.IsNullOrEmpty(this.G600_01_01_01.CalcValue) ? "0" : "";
                        this.G600_01_01_02.CalcValue = !string.IsNullOrEmpty(this.G600_01_01_02.CalcValue) ? "0" : "";
                        this.G600_01_02_01.CalcValue = !string.IsNullOrEmpty(this.G600_01_02_01.CalcValue) ? "0" : "";
                        this.G600_01_02_02.CalcValue = !string.IsNullOrEmpty(this.G600_01_02_02.CalcValue) ? "0" : "";
                        this.G600_01_02_04.CalcValue = !string.IsNullOrEmpty(this.G600_01_02_04.CalcValue) ? "0" : "";
                        this.G600_01_03_01.CalcValue = !string.IsNullOrEmpty(this.G600_01_03_01.CalcValue) ? "0" : "";
                        this.G600_01_03_02.CalcValue = !string.IsNullOrEmpty(this.G600_01_03_02.CalcValue) ? "0" : "";
                        this.G600_01_04_01.CalcValue = !string.IsNullOrEmpty(this.G600_01_04_01.CalcValue) ? "0" : "";
                        this.G600_01_04_02.CalcValue = !string.IsNullOrEmpty(this.G600_01_04_02.CalcValue) ? "0" : "";
                        this.G600_01_01_04_01.CalcValue = !string.IsNullOrEmpty(this.G600_01_01_04_01.CalcValue) ? "0" : "";
                        this.G600_01_05_01.CalcValue = !string.IsNullOrEmpty(this.G600_01_05_01.CalcValue) ? "0" : "";
                        this.G600_01_05_02.CalcValue = !string.IsNullOrEmpty(this.G600_01_05_02.CalcValue) ? "0" : "";
                        this.G600_01_06_01.CalcValue = !string.IsNullOrEmpty(this.G600_01_06_01.CalcValue) ? "0" : "";
                        this.G600_01_07_01.CalcValue = !string.IsNullOrEmpty(this.G600_01_07_01.CalcValue) ? "0" : "";
                        this.G600_01_08_01.CalcValue = !string.IsNullOrEmpty(this.G600_01_08_01.CalcValue) ? "0" : "";
                        this.G600_01_08_02.CalcValue = !string.IsNullOrEmpty(this.G600_01_08_02.CalcValue) ? "0" : "";
                        this.G600_01_99.CalcValue = !string.IsNullOrEmpty(this.G600_01_99.CalcValue) ? "0" : "";

                        this.G601_01_01_01.CalcValue = !string.IsNullOrEmpty(this.G601_01_01_01.CalcValue) ? "0" : "";
                        this.G601_01_01_02.CalcValue = !string.IsNullOrEmpty(this.G601_01_01_02.CalcValue) ? "0" : "";
                        this.G601_01_02_01.CalcValue = !string.IsNullOrEmpty(this.G601_01_02_01.CalcValue) ? "0" : "";
                        this.G601_01_02_02.CalcValue = !string.IsNullOrEmpty(this.G601_01_02_02.CalcValue) ? "0" : "";
                        this.G601_01_03_01.CalcValue = !string.IsNullOrEmpty(this.G601_01_03_01.CalcValue) ? "0" : "";
                        this.G601_01_03_02.CalcValue = !string.IsNullOrEmpty(this.G601_01_03_02.CalcValue) ? "0" : "";
                        this.G601_01_04_01.CalcValue = !string.IsNullOrEmpty(this.G601_01_04_01.CalcValue) ? "0" : "";
                        this.G601_01_04_02.CalcValue = !string.IsNullOrEmpty(this.G601_01_04_02.CalcValue) ? "0" : "";
                        this.G601_01_01_04_01.CalcValue = !string.IsNullOrEmpty(this.G601_01_01_04_01.CalcValue) ? "0" : "";
                        this.G601_01_05_01.CalcValue = !string.IsNullOrEmpty(this.G601_01_05_01.CalcValue) ? "0" : "";
                        this.G601_01_05_02.CalcValue = !string.IsNullOrEmpty(this.G601_01_05_02.CalcValue) ? "0" : "";
                        this.G601_01_06_01.CalcValue = !string.IsNullOrEmpty(this.G601_01_06_01.CalcValue) ? "0" : "";
                        this.G601_01_07_01.CalcValue = !string.IsNullOrEmpty(this.G601_01_07_01.CalcValue) ? "0" : "";
                        this.G601_01_08_01.CalcValue = !string.IsNullOrEmpty(this.G601_01_08_01.CalcValue) ? "0" : "";
                        this.G601_01_08_02.CalcValue = !string.IsNullOrEmpty(this.G601_01_08_02.CalcValue) ? "0" : "";
                        this.G601_01_99.CalcValue = !string.IsNullOrEmpty(this.G601_01_99.CalcValue) ? "0" : "";

                        this.G340_11_01.CalcValue = !string.IsNullOrEmpty(this.G340_11_01.CalcValue) ? "0" : "";
                        this.G195_01.CalcValue = !string.IsNullOrEmpty(this.G195_01.CalcValue) ? "0" : "";
                        this.G336_06_01.CalcValue = !string.IsNullOrEmpty(this.G336_06_01.CalcValue) ? "0" : "";
                        this.G336_06_02.CalcValue = !string.IsNullOrEmpty(this.G336_06_02.CalcValue) ? "0" : "";
                        this.G600_01_94.CalcValue = !string.IsNullOrEmpty(this.G600_01_94.CalcValue) ? "0" : "";
                        this.G649_09_09_02.CalcValue = !string.IsNullOrEmpty(this.G649_09_09_02.CalcValue) ? "0" : "";
                        this.G679_09_9099.CalcValue = !string.IsNullOrEmpty(this.G679_09_9099.CalcValue) ? "0" : "";
                        this.GTOTAL.CalcValue = "0";
                    }
                    else
                    {
                        this.STATUS.CalcValue = "Aktif";

                        MyParentReport.T600_01_01_01 += !string.IsNullOrEmpty(this.G600_01_01_01.CalcValue) ? Convert.ToDecimal(this.G600_01_01_01.CalcValue) : 0;
                        MyParentReport.T600_01_01_02 += !string.IsNullOrEmpty(this.G600_01_01_02.CalcValue) ? Convert.ToDecimal(this.G600_01_01_02.CalcValue) : 0;
                        MyParentReport.T600_01_02_01 += !string.IsNullOrEmpty(this.G600_01_02_01.CalcValue) ? Convert.ToDecimal(this.G600_01_02_01.CalcValue) : 0;
                        MyParentReport.T600_01_02_02 += !string.IsNullOrEmpty(this.G600_01_02_02.CalcValue) ? Convert.ToDecimal(this.G600_01_02_02.CalcValue) : 0;
                        MyParentReport.T600_01_02_04 += !string.IsNullOrEmpty(this.G600_01_02_04.CalcValue) ? Convert.ToDecimal(this.G600_01_02_04.CalcValue) : 0;
                        MyParentReport.T600_01_03_01 += !string.IsNullOrEmpty(this.G600_01_03_01.CalcValue) ? Convert.ToDecimal(this.G600_01_03_01.CalcValue) : 0;
                        MyParentReport.T600_01_03_02 += !string.IsNullOrEmpty(this.G600_01_03_02.CalcValue) ? Convert.ToDecimal(this.G600_01_03_02.CalcValue) : 0;
                        MyParentReport.T600_01_04_01 += !string.IsNullOrEmpty(this.G600_01_04_01.CalcValue) ? Convert.ToDecimal(this.G600_01_04_01.CalcValue) : 0;
                        MyParentReport.T600_01_04_02 += !string.IsNullOrEmpty(this.G600_01_04_02.CalcValue) ? Convert.ToDecimal(this.G600_01_04_02.CalcValue) : 0;
                        MyParentReport.T600_01_01_04_01 += !string.IsNullOrEmpty(this.G600_01_01_04_01.CalcValue) ? Convert.ToDecimal(this.G600_01_01_04_01.CalcValue) : 0;
                        MyParentReport.T600_01_05_01 += !string.IsNullOrEmpty(this.G600_01_05_01.CalcValue) ? Convert.ToDecimal(this.G600_01_05_01.CalcValue) : 0;
                        MyParentReport.T600_01_05_02 += !string.IsNullOrEmpty(this.G600_01_05_02.CalcValue) ? Convert.ToDecimal(this.G600_01_05_02.CalcValue) : 0;
                        MyParentReport.T600_01_06_01 += !string.IsNullOrEmpty(this.G600_01_06_01.CalcValue) ? Convert.ToDecimal(this.G600_01_06_01.CalcValue) : 0;
                        MyParentReport.T600_01_07_01 += !string.IsNullOrEmpty(this.G600_01_07_01.CalcValue) ? Convert.ToDecimal(this.G600_01_07_01.CalcValue) : 0;
                        MyParentReport.T600_01_08_01 += !string.IsNullOrEmpty(this.G600_01_08_01.CalcValue) ? Convert.ToDecimal(this.G600_01_08_01.CalcValue) : 0;
                        MyParentReport.T600_01_08_02 += !string.IsNullOrEmpty(this.G600_01_08_02.CalcValue) ? Convert.ToDecimal(this.G600_01_08_02.CalcValue) : 0;
                        MyParentReport.T600_01_99 += !string.IsNullOrEmpty(this.G600_01_99.CalcValue) ? Convert.ToDecimal(this.G600_01_99.CalcValue) : 0;

                        MyParentReport.T601_01_01_01 += !string.IsNullOrEmpty(this.G601_01_01_01.CalcValue) ? Convert.ToDecimal(this.G601_01_01_01.CalcValue) : 0;
                        MyParentReport.T601_01_01_02 += !string.IsNullOrEmpty(this.G601_01_01_02.CalcValue) ? Convert.ToDecimal(this.G601_01_01_02.CalcValue) : 0;
                        MyParentReport.T601_01_02_01 += !string.IsNullOrEmpty(this.G601_01_02_01.CalcValue) ? Convert.ToDecimal(this.G601_01_02_01.CalcValue) : 0;
                        MyParentReport.T601_01_02_02 += !string.IsNullOrEmpty(this.G601_01_02_02.CalcValue) ? Convert.ToDecimal(this.G601_01_02_02.CalcValue) : 0;
                        MyParentReport.T601_01_03_01 += !string.IsNullOrEmpty(this.G601_01_03_01.CalcValue) ? Convert.ToDecimal(this.G601_01_03_01.CalcValue) : 0;
                        MyParentReport.T601_01_03_02 += !string.IsNullOrEmpty(this.G601_01_03_02.CalcValue) ? Convert.ToDecimal(this.G601_01_03_02.CalcValue) : 0;
                        MyParentReport.T601_01_04_01 += !string.IsNullOrEmpty(this.G601_01_04_01.CalcValue) ? Convert.ToDecimal(this.G601_01_04_01.CalcValue) : 0;
                        MyParentReport.T601_01_04_02 += !string.IsNullOrEmpty(this.G601_01_04_02.CalcValue) ? Convert.ToDecimal(this.G601_01_04_02.CalcValue) : 0;
                        MyParentReport.T601_01_01_04_01 += !string.IsNullOrEmpty(this.G601_01_01_04_01.CalcValue) ? Convert.ToDecimal(this.G601_01_01_04_01.CalcValue) : 0;
                        MyParentReport.T601_01_05_01 += !string.IsNullOrEmpty(this.G601_01_05_01.CalcValue) ? Convert.ToDecimal(this.G601_01_05_01.CalcValue) : 0;
                        MyParentReport.T601_01_05_02 += !string.IsNullOrEmpty(this.G601_01_05_02.CalcValue) ? Convert.ToDecimal(this.G601_01_05_02.CalcValue) : 0;
                        MyParentReport.T601_01_06_01 += !string.IsNullOrEmpty(this.G601_01_06_01.CalcValue) ? Convert.ToDecimal(this.G601_01_06_01.CalcValue) : 0;
                        MyParentReport.T601_01_07_01 += !string.IsNullOrEmpty(this.G601_01_07_01.CalcValue) ? Convert.ToDecimal(this.G601_01_07_01.CalcValue) : 0;
                        MyParentReport.T601_01_08_01 += !string.IsNullOrEmpty(this.G601_01_08_01.CalcValue) ? Convert.ToDecimal(this.G601_01_08_01.CalcValue) : 0;
                        MyParentReport.T601_01_08_02 += !string.IsNullOrEmpty(this.G601_01_08_02.CalcValue) ? Convert.ToDecimal(this.G601_01_08_02.CalcValue) : 0;
                        MyParentReport.T601_01_99 += !string.IsNullOrEmpty(this.G601_01_99.CalcValue) ? Convert.ToDecimal(this.G601_01_99.CalcValue) : 0;

                        MyParentReport.T340_11_01 += !string.IsNullOrEmpty(this.G340_11_01.CalcValue) ? Convert.ToDecimal(this.G340_11_01.CalcValue) : 0;
                        MyParentReport.T195_01 += !string.IsNullOrEmpty(this.G195_01.CalcValue) ? Convert.ToDecimal(this.G195_01.CalcValue) : 0;
                        MyParentReport.T336_06_01 += !string.IsNullOrEmpty(this.G336_06_01.CalcValue) ? Convert.ToDecimal(this.G336_06_01.CalcValue) : 0;
                        MyParentReport.T336_06_02 += !string.IsNullOrEmpty(this.G336_06_02.CalcValue) ? Convert.ToDecimal(this.G336_06_02.CalcValue) : 0;
                        MyParentReport.T600_01_94 += !string.IsNullOrEmpty(this.G600_01_94.CalcValue) ? Convert.ToDecimal(this.G600_01_94.CalcValue) : 0;
                        MyParentReport.T649_09_09_02 += !string.IsNullOrEmpty(this.G649_09_09_02.CalcValue) ? Convert.ToDecimal(this.G649_09_09_02.CalcValue) : 0;
                        MyParentReport.T679_09_9099 += !string.IsNullOrEmpty(this.G679_09_9099.CalcValue) ? Convert.ToDecimal(this.G679_09_9099.CalcValue) : 0;
                    }

                    MyParentReport.Total += !string.IsNullOrEmpty(this.GTOTAL.CalcValue) ? Convert.ToDecimal(this.GTOTAL.CalcValue) : 0;

                    if (this.PAYMENTTYPE.CalcValue.ToUpper().Equals("CASH"))
                    {
                        this.GCASH.CalcValue = this.GTOTAL.CalcValue;
                        MyParentReport.CashTotal += Convert.ToDecimal(this.GTOTAL.CalcValue);
                    }
                    else
                    {
                        this.GCC.CalcValue = this.GTOTAL.CalcValue;
                        MyParentReport.CreditCardTotal += Convert.ToDecimal(this.GTOTAL.CalcValue);
                    }
                    #endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public CashOfficeRevenueReport()
        {
            PARTB = new PARTBGroup(this, "PARTB");
            PARTA = new PARTAGroup(PARTB, "PARTA");
            PARTC = new PARTCGroup(PARTA, "PARTC");
            MAIN = new MAINGroup(PARTC, "MAIN");
            _runtimeParameters = new ReportRuntimeParameters();

            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("CASHOFFICE", "00000000-0000-0000-0000-000000000000", "Vezne", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("ffa9d300-1561-46fa-a262-4126167d70a5");
            reportParameter = Parameters.Add("CASHOFFICECONTROL", "", "Vezne Kontrol", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("CASHIER", "00000000-0000-0000-0000-000000000000", "Veznedar", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("b91d94bd-e04f-48fb-ada4-edbeb0973d62");
            reportParameter = Parameters.Add("CASHIERCONTROL", "", "Veznedar Kontrol", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("PAYMENTTYPE", "", "Ödeme Tipi", @"", false, true, false, new Guid("44fa3277-ac8f-4c8f-855c-11b370e2ac95"));
            reportParameter = Parameters.Add("PAYMENTTYPECONTROL", "", "Ödeme Tipi Kontrolü", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("USETIME", "", "Saat Bazlı", @"", false, true, false, new Guid("87fa0907-eeb7-43e0-b870-8690afc73bc3"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("CASHOFFICE"))
                _runtimeParameters.CASHOFFICE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["CASHOFFICE"]);
            if (parameters.ContainsKey("CASHOFFICECONTROL"))
                _runtimeParameters.CASHOFFICECONTROL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["CASHOFFICECONTROL"]);
            if (parameters.ContainsKey("CASHIER"))
                _runtimeParameters.CASHIER = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["CASHIER"]);
            if (parameters.ContainsKey("CASHIERCONTROL"))
                _runtimeParameters.CASHIERCONTROL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["CASHIERCONTROL"]);
            if (parameters.ContainsKey("PAYMENTTYPE"))
                _runtimeParameters.PAYMENTTYPE = (PaymentTypeCashCCEnum?)(int?)TTObjectDefManager.Instance.DataTypes["PaymentTypeCashCCEnum"].ConvertValue(parameters["PAYMENTTYPE"]);
            if (parameters.ContainsKey("PAYMENTTYPECONTROL"))
                _runtimeParameters.PAYMENTTYPECONTROL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PAYMENTTYPECONTROL"]);
            if (parameters.ContainsKey("USETIME"))
                _runtimeParameters.USETIME = (bool?)TTObjectDefManager.Instance.DataTypes["Boolean"].ConvertValue(parameters["USETIME"]);
            Name = "CASHOFFICEREVENUEREPORT";
            Caption = "Mutemetlikler Tahsilat Ve Ödeme Defteri";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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



