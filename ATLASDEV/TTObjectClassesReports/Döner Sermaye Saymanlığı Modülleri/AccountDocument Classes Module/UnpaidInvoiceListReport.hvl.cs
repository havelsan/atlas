
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
    /// Ödenmemiş Faturalar Listesi
    /// </summary>
    public partial class UnpaidInvoiceListReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public long? PAYERSTARTCODE = (long?)TTObjectDefManager.Instance.DataTypes["Long9"].ConvertValue("");
            public long? PAYERENDCODE = (long?)TTObjectDefManager.Instance.DataTypes["Long9"].ConvertValue("");
            public OutPatientInPatientBothEnum? OUTPATIENTINPATIENT = (OutPatientInPatientBothEnum?)(int?)TTObjectDefManager.Instance.DataTypes["OutPatientInPatientBothEnum"].ConvertValue("3");
            public OutPatientInPatientBothEnum? OUTPATIENTINPATIENTOTHER = (OutPatientInPatientBothEnum?)(int?)TTObjectDefManager.Instance.DataTypes["OutPatientInPatientBothEnum"].ConvertValue("");
            public string STARTPAYEROBJ = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string ENDPAYEROBJ = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public OutPatientInPatientBothEnum? OUTPATIENTINPATIENTBOTH = (OutPatientInPatientBothEnum?)(int?)TTObjectDefManager.Instance.DataTypes["OutPatientInPatientBothEnum"].ConvertValue("");
            public InvoiceTypeEnum? INVOICETYPE = (InvoiceTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["InvoiceTypeEnum"].ConvertValue("");
            public int? OUTPATIENTINPATIENTFORCOLLECTEDINV = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? OUTPATIENTINPATIENTFORCOLLECTEDINV2 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public List<int> INVOICETYPEINT = new List<int>();
            public double? TOTALINVOICEPRICE = (double?)TTObjectDefManager.Instance.DataTypes["Double23.8"].ConvertValue("0");
            public string DOSENOFIRSTVALUE = (string)TTObjectDefManager.Instance.DataTypes["String10"].ConvertValue("4");
            public string DOSENOLASTVALUE = (string)TTObjectDefManager.Instance.DataTypes["String10"].ConvertValue("5");
            public string YEAR = (string)TTObjectDefManager.Instance.DataTypes["String10"].ConvertValue("10");
            public InvoiceOrCollectedInvoiceEnum? INVOICEORCOLLECTEDINVOICE = (InvoiceOrCollectedInvoiceEnum?)(int?)TTObjectDefManager.Instance.DataTypes["InvoiceOrCollectedInvoiceEnum"].ConvertValue("");
            public int? ISINVOICE = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? ISCOLLECTEDINVOICE = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class HEADGroup : TTReportGroup
        {
            public UnpaidInvoiceListReport MyParentReport
            {
                get { return (UnpaidInvoiceListReport)ParentReport; }
            }

            new public HEADGroupHeader Header()
            {
                return (HEADGroupHeader)_header;
            }

            new public HEADGroupFooter Footer()
            {
                return (HEADGroupFooter)_footer;
            }

            public HEADGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<AccountDocument.GetUnpaidAccDocs_Class>("GetUnpaidAccDocs", AccountDocument.GetUnpaidAccDocs((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(long)TTObjectDefManager.Instance.DataTypes["Long9"].ConvertValue(MyParentReport.RuntimeParameters.PAYERSTARTCODE),(long)TTObjectDefManager.Instance.DataTypes["Long9"].ConvertValue(MyParentReport.RuntimeParameters.PAYERENDCODE),((OutPatientInPatientBothEnum)TTObjectDefManager.Instance.DataTypes["OutPatientInPatientBothEnum"].EnumValueDefs[MyParentReport.RuntimeParameters.OUTPATIENTINPATIENT.ToString()].EnumValue),((OutPatientInPatientBothEnum)TTObjectDefManager.Instance.DataTypes["OutPatientInPatientBothEnum"].EnumValueDefs[MyParentReport.RuntimeParameters.OUTPATIENTINPATIENTOTHER.ToString()].EnumValue),((OutPatientInPatientBothEnum)TTObjectDefManager.Instance.DataTypes["OutPatientInPatientBothEnum"].EnumValueDefs[MyParentReport.RuntimeParameters.OUTPATIENTINPATIENTBOTH.ToString()].EnumValue),(List<int>) MyParentReport.RuntimeParameters.INVOICETYPEINT,(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.OUTPATIENTINPATIENTFORCOLLECTEDINV),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.OUTPATIENTINPATIENTFORCOLLECTEDINV2),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.ISINVOICE),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.ISCOLLECTEDINVOICE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADGroupHeader(this);
                _footer = new HEADGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HEADGroupHeader : TTReportSection
            {
                public UnpaidInvoiceListReport MyParentReport
                {
                    get { return (UnpaidInvoiceListReport)ParentReport; }
                }
                 
                public HEADGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 3;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class HEADGroupFooter : TTReportSection
            {
                public UnpaidInvoiceListReport MyParentReport
                {
                    get { return (UnpaidInvoiceListReport)ParentReport; }
                }
                 
                public HEADGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 16;
                    RepeatCount = 0;
                    
                }
                
            }

            protected override bool RunPreScript()
            {
#region HEAD_PreScript
                if(((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.OUTPATIENTINPATIENT == OutPatientInPatientBothEnum.Both)
            {
                ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.OUTPATIENTINPATIENT = OutPatientInPatientBothEnum.InPatient;
                ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTOTHER = OutPatientInPatientBothEnum.OutPatient;
                ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTBOTH = OutPatientInPatientBothEnum.Both;
                
                ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTFORCOLLECTEDINV = 0;
                ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTFORCOLLECTEDINV2 = 1;
            }
            else if (((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.OUTPATIENTINPATIENT == OutPatientInPatientBothEnum.InPatient)
            {
                ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTOTHER = OutPatientInPatientBothEnum.InPatient;
                ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTBOTH = OutPatientInPatientBothEnum.InPatient;
                
                ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTFORCOLLECTEDINV = 1;
                ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTFORCOLLECTEDINV2 = 1;
            }
            else if (((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.OUTPATIENTINPATIENT == OutPatientInPatientBothEnum.OutPatient)
            {
                ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTOTHER = OutPatientInPatientBothEnum.OutPatient;
                ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTBOTH = OutPatientInPatientBothEnum.OutPatient;
                
                ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTFORCOLLECTEDINV = 0;
                ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTFORCOLLECTEDINV2 = 0;
            }
            
            List<int> invoiceTypeList = new List<int>();

            if(((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.INVOICETYPE == InvoiceTypeEnum.Procedure)
            {
                invoiceTypeList.Add(0);
                ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTFORCOLLECTEDINV = 99;
                ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTFORCOLLECTEDINV2 = 99;
            }
            else if (((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.INVOICETYPE == InvoiceTypeEnum.Package)
            {
                invoiceTypeList.Add(1);
                ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTFORCOLLECTEDINV = 99;
                ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTFORCOLLECTEDINV2 = 99;
            }
            else if (((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.INVOICETYPE == InvoiceTypeEnum.ProcedureAndPackage)
            {
                invoiceTypeList.Add(2);
                ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTFORCOLLECTEDINV = 99;
                ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTFORCOLLECTEDINV2 = 99;
            }
            //            else if (((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.INVOICETYPE == InvoiceTypeEnum.CollectedInvoice)
            //            {
            //                invoiceTypeList.Add(9);
            //            }
            else if (((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.INVOICETYPE == InvoiceTypeEnum.All)
            {
                invoiceTypeList.Add(0);
                invoiceTypeList.Add(1);
                invoiceTypeList.Add(2);
            }
            ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.INVOICETYPEINT = invoiceTypeList;
            
            // Fatura Tipine (Toplu Fatura , Kurum Faturası , Hepsi) göre sorgudaki UNION ın farklı çalışması için
            if(((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.INVOICEORCOLLECTEDINVOICE == InvoiceOrCollectedInvoiceEnum.Invoice)
            {
                ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.ISINVOICE = 1;
                ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.ISCOLLECTEDINVOICE = 0;
            }
            else if(((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.INVOICEORCOLLECTEDINVOICE == InvoiceOrCollectedInvoiceEnum.CollectedInvoice)
            {
                ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.ISINVOICE = 0;
                ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.ISCOLLECTEDINVOICE = 1;
            }
            else
            {
                ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.ISINVOICE = 1;
                ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.ISCOLLECTEDINVOICE = 1;
            }
            
            TTObjectContext context = new TTObjectContext(true);
            TTObjectContext context2 = new TTObjectContext(true);
            
            string sPayerObjID = ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.STARTPAYEROBJ;
            string ePayerObjID = ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.ENDPAYEROBJ;
            PayerDefinition spayerDef = (PayerDefinition)context.GetObject(new Guid(sPayerObjID),"PayerDefinition");
            PayerDefinition epayerDef = (PayerDefinition)context2.GetObject(new Guid(ePayerObjID),"PayerDefinition");
            ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.PAYERSTARTCODE = spayerDef.Code ;
            ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.PAYERENDCODE = epayerDef.Code ;
            
            return true;
#endregion HEAD_PreScript
            }
        }

        public HEADGroup HEAD;

        public partial class HEADERBGroup : TTReportGroup
        {
            public UnpaidInvoiceListReport MyParentReport
            {
                get { return (UnpaidInvoiceListReport)ParentReport; }
            }

            new public HEADERBGroupHeader Header()
            {
                return (HEADERBGroupHeader)_header;
            }

            new public HEADERBGroupFooter Footer()
            {
                return (HEADERBGroupFooter)_footer;
            }

            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField PAYERCODE { get {return Header().PAYERCODE;} }
            public TTReportField PAYERNAME { get {return Header().PAYERNAME;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField PATIENTSTATUS { get {return Header().PATIENTSTATUS;} }
            public TTReportField NewField11011 { get {return Header().NewField11011;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportField SDATE { get {return Header().SDATE;} }
            public TTReportField EDATE { get {return Header().EDATE;} }
            public TTReportField NewField1112 { get {return Header().NewField1112;} }
            public TTReportField NewField12111 { get {return Header().NewField12111;} }
            public TTReportField NewField12112 { get {return Header().NewField12112;} }
            public TTReportField NewField12114 { get {return Header().NewField12114;} }
            public TTReportField PAYERCITY { get {return Header().PAYERCITY;} }
            public TTReportField NewField111112 { get {return Header().NewField111112;} }
            public TTReportField INVOICEORCOLLECTEDINVOICE { get {return Header().INVOICEORCOLLECTEDINVOICE;} }
            public TTReportField NewField131121 { get {return Header().NewField131121;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public HEADERBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                AccountDocument.GetUnpaidAccDocs_Class dataSet_GetUnpaidAccDocs = ParentGroup.rsGroup.GetCurrentRecord<AccountDocument.GetUnpaidAccDocs_Class>(0);    
                return new object[] {(dataSet_GetUnpaidAccDocs==null ? null : dataSet_GetUnpaidAccDocs.Payercode)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new HEADERBGroupHeader(this);
                _footer = new HEADERBGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class HEADERBGroupHeader : TTReportSection
            {
                public UnpaidInvoiceListReport MyParentReport
                {
                    get { return (UnpaidInvoiceListReport)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField PAYERCODE;
                public TTReportField PAYERNAME;
                public TTReportField NewField1111;
                public TTReportField PATIENTSTATUS;
                public TTReportField NewField11011;
                public TTReportField NewField111111;
                public TTReportField DATE;
                public TTReportField SDATE;
                public TTReportField EDATE;
                public TTReportField NewField1112;
                public TTReportField NewField12111;
                public TTReportField NewField12112;
                public TTReportField NewField12114;
                public TTReportField PAYERCITY;
                public TTReportField NewField111112;
                public TTReportField INVOICEORCOLLECTEDINVOICE;
                public TTReportField NewField131121;
                public TTReportField LOGO; 
                public HEADERBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 59;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 29, 30, 34, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 9;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Kurum Kodu";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 35, 30, 40, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 9;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Kurum Adı";

                    PAYERCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 29, 77, 34, false);
                    PAYERCODE.Name = "PAYERCODE";
                    PAYERCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYERCODE.TextFont.Name = "Arial";
                    PAYERCODE.TextFont.Size = 9;
                    PAYERCODE.TextFont.CharSet = 162;
                    PAYERCODE.Value = @"{#HEAD.PAYERCODE#}";

                    PAYERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 35, 203, 40, false);
                    PAYERNAME.Name = "PAYERNAME";
                    PAYERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYERNAME.TextFont.Name = "Arial";
                    PAYERNAME.TextFont.Size = 9;
                    PAYERNAME.TextFont.CharSet = 162;
                    PAYERNAME.Value = @"{#HEAD.PAYERNAME#}";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 41, 30, 46, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Size = 9;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Hasta Durumu";

                    PATIENTSTATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 41, 91, 46, false);
                    PATIENTSTATUS.Name = "PATIENTSTATUS";
                    PATIENTSTATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTSTATUS.TextFont.Name = "Arial";
                    PATIENTSTATUS.TextFont.Size = 9;
                    PATIENTSTATUS.TextFont.CharSet = 162;
                    PATIENTSTATUS.Value = @"";

                    NewField11011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 7, 162, 27, false);
                    NewField11011.Name = "NewField11011";
                    NewField11011.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11011.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11011.TextFont.Name = "Arial";
                    NewField11011.TextFont.Size = 11;
                    NewField11011.TextFont.Bold = true;
                    NewField11011.TextFont.CharSet = 162;
                    NewField11011.Value = @"ÖDENMEMİŞ FATURALAR LİSTESİ";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 53, 30, 58, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111111.NoClip = EvetHayirEnum.ehEvet;
                    NewField111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111111.TextFont.Name = "Arial";
                    NewField111111.TextFont.Size = 9;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"Tarih";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 53, 91, 58, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFont.Name = "Arial";
                    DATE.TextFont.Size = 9;
                    DATE.TextFont.CharSet = 162;
                    DATE.Value = @"{%SDATE%} / {%EDATE%}";

                    SDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 15, 256, 20, false);
                    SDATE.Name = "SDATE";
                    SDATE.Visible = EvetHayirEnum.ehHayir;
                    SDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SDATE.TextFormat = @"Short Date";
                    SDATE.Value = @"{@STARTDATE@}";

                    EDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 24, 256, 29, false);
                    EDATE.Name = "EDATE";
                    EDATE.Visible = EvetHayirEnum.ehHayir;
                    EDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EDATE.TextFormat = @"Short Date";
                    EDATE.Value = @"{@ENDDATE@}";

                    NewField1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 29, 36, 34, false);
                    NewField1112.Name = "NewField1112";
                    NewField1112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112.TextFont.Bold = true;
                    NewField1112.TextFont.CharSet = 162;
                    NewField1112.Value = @":";

                    NewField12111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 35, 36, 40, false);
                    NewField12111.Name = "NewField12111";
                    NewField12111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12111.TextFont.Bold = true;
                    NewField12111.TextFont.CharSet = 162;
                    NewField12111.Value = @":";

                    NewField12112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 41, 36, 46, false);
                    NewField12112.Name = "NewField12112";
                    NewField12112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12112.TextFont.Bold = true;
                    NewField12112.TextFont.CharSet = 162;
                    NewField12112.Value = @":";

                    NewField12114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 53, 36, 58, false);
                    NewField12114.Name = "NewField12114";
                    NewField12114.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12114.TextFont.Bold = true;
                    NewField12114.TextFont.CharSet = 162;
                    NewField12114.Value = @":";

                    PAYERCITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 43, 266, 48, false);
                    PAYERCITY.Name = "PAYERCITY";
                    PAYERCITY.Visible = EvetHayirEnum.ehHayir;
                    PAYERCITY.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYERCITY.Value = @"{#HEAD.PAYERCITY#}";

                    NewField111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 47, 30, 52, false);
                    NewField111112.Name = "NewField111112";
                    NewField111112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111112.NoClip = EvetHayirEnum.ehEvet;
                    NewField111112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111112.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111112.TextFont.Name = "Arial";
                    NewField111112.TextFont.Size = 9;
                    NewField111112.TextFont.Bold = true;
                    NewField111112.TextFont.CharSet = 162;
                    NewField111112.Value = @"Fatura Tipi";

                    INVOICEORCOLLECTEDINVOICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 47, 91, 52, false);
                    INVOICEORCOLLECTEDINVOICE.Name = "INVOICEORCOLLECTEDINVOICE";
                    INVOICEORCOLLECTEDINVOICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    INVOICEORCOLLECTEDINVOICE.ObjectDefName = "InvoiceOrCollectedInvoiceEnum";
                    INVOICEORCOLLECTEDINVOICE.DataMember = "DISPLAYTEXT";
                    INVOICEORCOLLECTEDINVOICE.TextFont.Name = "Arial";
                    INVOICEORCOLLECTEDINVOICE.TextFont.Size = 9;
                    INVOICEORCOLLECTEDINVOICE.TextFont.CharSet = 162;
                    INVOICEORCOLLECTEDINVOICE.Value = @"{@INVOICEORCOLLECTEDINVOICE@}";

                    NewField131121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 47, 36, 52, false);
                    NewField131121.Name = "NewField131121";
                    NewField131121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131121.TextFont.Bold = true;
                    NewField131121.TextFont.CharSet = 162;
                    NewField131121.Value = @":";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 7, 48, 27, false);
                    LOGO.Name = "LOGO";
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountDocument.GetUnpaidAccDocs_Class dataset_GetUnpaidAccDocs = MyParentReport.HEAD.rsGroup.GetCurrentRecord<AccountDocument.GetUnpaidAccDocs_Class>(0);
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    PAYERCODE.CalcValue = (dataset_GetUnpaidAccDocs != null ? Globals.ToStringCore(dataset_GetUnpaidAccDocs.Payercode) : "");
                    PAYERNAME.CalcValue = (dataset_GetUnpaidAccDocs != null ? Globals.ToStringCore(dataset_GetUnpaidAccDocs.Payername) : "");
                    NewField1111.CalcValue = NewField1111.Value;
                    PATIENTSTATUS.CalcValue = @"";
                    NewField11011.CalcValue = NewField11011.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    SDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    EDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    DATE.CalcValue = MyParentReport.HEADERB.SDATE.FormattedValue + @" / " + MyParentReport.HEADERB.EDATE.FormattedValue;
                    NewField1112.CalcValue = NewField1112.Value;
                    NewField12111.CalcValue = NewField12111.Value;
                    NewField12112.CalcValue = NewField12112.Value;
                    NewField12114.CalcValue = NewField12114.Value;
                    PAYERCITY.CalcValue = (dataset_GetUnpaidAccDocs != null ? Globals.ToStringCore(dataset_GetUnpaidAccDocs.Payercity) : "");
                    NewField111112.CalcValue = NewField111112.Value;
                    INVOICEORCOLLECTEDINVOICE.CalcValue = MyParentReport.RuntimeParameters.INVOICEORCOLLECTEDINVOICE.ToString();
                    INVOICEORCOLLECTEDINVOICE.PostFieldValueCalculation();
                    NewField131121.CalcValue = NewField131121.Value;
                    LOGO.CalcValue = LOGO.Value;
                    return new TTReportObject[] { NewField111,NewField121,PAYERCODE,PAYERNAME,NewField1111,PATIENTSTATUS,NewField11011,NewField111111,SDATE,EDATE,DATE,NewField1112,NewField12111,NewField12112,NewField12114,PAYERCITY,NewField111112,INVOICEORCOLLECTEDINVOICE,NewField131121,LOGO};
                }

                public override void RunScript()
                {
#region HEADERB HEADER_Script
                    if(((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.OUTPATIENTINPATIENT != ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.OUTPATIENTINPATIENTOTHER )
                this.PATIENTSTATUS.CalcValue = "Hepsi";
            else if (((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.OUTPATIENTINPATIENT == OutPatientInPatientBothEnum.InPatient)
                this.PATIENTSTATUS.CalcValue = "Yatan";
            else if (((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.OUTPATIENTINPATIENT == OutPatientInPatientBothEnum.OutPatient)
                this.PATIENTSTATUS.CalcValue = "Ayaktan";
            
            ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.TOTALINVOICEPRICE = 0;
#endregion HEADERB HEADER_Script
                }
            }
            public partial class HEADERBGroupFooter : TTReportSection
            {
                public UnpaidInvoiceListReport MyParentReport
                {
                    get { return (UnpaidInvoiceListReport)ParentReport; }
                }
                 
                public HEADERBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADERBGroup HEADERB;

        public partial class PROCEDURETYPEGroup : TTReportGroup
        {
            public UnpaidInvoiceListReport MyParentReport
            {
                get { return (UnpaidInvoiceListReport)ParentReport; }
            }

            new public PROCEDURETYPEGroupHeader Header()
            {
                return (PROCEDURETYPEGroupHeader)_header;
            }

            new public PROCEDURETYPEGroupFooter Footer()
            {
                return (PROCEDURETYPEGroupFooter)_footer;
            }

            public TTReportField NewField1111111 { get {return Header().NewField1111111;} }
            public TTReportField INVOICETYPE { get {return Header().INVOICETYPE;} }
            public TTReportField NewField1121131 { get {return Header().NewField1121131;} }
            public TTReportField NewField11511 { get {return Header().NewField11511;} }
            public TTReportField NewField11611 { get {return Header().NewField11611;} }
            public TTReportField NewField171 { get {return Header().NewField171;} }
            public TTReportField NewField11811 { get {return Header().NewField11811;} }
            public TTReportField NewField191 { get {return Header().NewField191;} }
            public TTReportField NewField111011 { get {return Header().NewField111011;} }
            public TTReportShape NewLine11111 { get {return Header().NewLine11111;} }
            public TTReportField NewField111811 { get {return Header().NewField111811;} }
            public TTReportField NewField11111 { get {return Footer().NewField11111;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
            public TTReportField TOTALPRICE { get {return Footer().TOTALPRICE;} }
            public PROCEDURETYPEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PROCEDURETYPEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                AccountDocument.GetUnpaidAccDocs_Class dataSet_GetUnpaidAccDocs = ParentGroup.rsGroup.GetCurrentRecord<AccountDocument.GetUnpaidAccDocs_Class>(0);    
                return new object[] {(dataSet_GetUnpaidAccDocs==null ? null : dataSet_GetUnpaidAccDocs.Type), (dataSet_GetUnpaidAccDocs==null ? null : dataSet_GetUnpaidAccDocs.Payercode)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new PROCEDURETYPEGroupHeader(this);
                _footer = new PROCEDURETYPEGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class PROCEDURETYPEGroupHeader : TTReportSection
            {
                public UnpaidInvoiceListReport MyParentReport
                {
                    get { return (UnpaidInvoiceListReport)ParentReport; }
                }
                
                public TTReportField NewField1111111;
                public TTReportField INVOICETYPE;
                public TTReportField NewField1121131;
                public TTReportField NewField11511;
                public TTReportField NewField11611;
                public TTReportField NewField171;
                public TTReportField NewField11811;
                public TTReportField NewField191;
                public TTReportField NewField111011;
                public TTReportShape NewLine11111;
                public TTReportField NewField111811; 
                public PROCEDURETYPEGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 4, 31, 9, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111111.NoClip = EvetHayirEnum.ehEvet;
                    NewField1111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1111111.TextFont.Name = "Arial";
                    NewField1111111.TextFont.Size = 9;
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.TextFont.CharSet = 162;
                    NewField1111111.Value = @"Hizmet Tipi";

                    INVOICETYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 4, 92, 9, false);
                    INVOICETYPE.Name = "INVOICETYPE";
                    INVOICETYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    INVOICETYPE.ObjectDefName = "InvoicePostingInvoiceTypeEnum";
                    INVOICETYPE.DataMember = "DISPLAYTEXT";
                    INVOICETYPE.TextFont.Name = "Arial";
                    INVOICETYPE.TextFont.Size = 9;
                    INVOICETYPE.TextFont.CharSet = 162;
                    INVOICETYPE.Value = @"{#HEAD.TYPE#}";

                    NewField1121131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 4, 37, 9, false);
                    NewField1121131.Name = "NewField1121131";
                    NewField1121131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121131.TextFont.Bold = true;
                    NewField1121131.TextFont.CharSet = 162;
                    NewField1121131.Value = @":";

                    NewField11511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 16, 18, 21, false);
                    NewField11511.Name = "NewField11511";
                    NewField11511.TextFont.Name = "Arial";
                    NewField11511.TextFont.Size = 9;
                    NewField11511.TextFont.Bold = true;
                    NewField11511.TextFont.CharSet = 162;
                    NewField11511.Value = @"Sıra";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 16, 40, 21, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.TextFont.Name = "Arial";
                    NewField11611.TextFont.Size = 9;
                    NewField11611.TextFont.Bold = true;
                    NewField11611.TextFont.CharSet = 162;
                    NewField11611.Value = @"Fatura No";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 16, 168, 21, false);
                    NewField171.Name = "NewField171";
                    NewField171.TextFont.Name = "Arial";
                    NewField171.TextFont.Size = 9;
                    NewField171.TextFont.Bold = true;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @"Hasta No";

                    NewField11811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 16, 66, 21, false);
                    NewField11811.Name = "NewField11811";
                    NewField11811.TextFont.Name = "Arial";
                    NewField11811.TextFont.Size = 9;
                    NewField11811.TextFont.Bold = true;
                    NewField11811.TextFont.CharSet = 162;
                    NewField11811.Value = @"Fatura Tarihi";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 16, 141, 21, false);
                    NewField191.Name = "NewField191";
                    NewField191.TextFont.Name = "Arial";
                    NewField191.TextFont.Size = 9;
                    NewField191.TextFont.Bold = true;
                    NewField191.TextFont.CharSet = 162;
                    NewField191.Value = @"Hasta Adı";

                    NewField111011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 16, 203, 21, false);
                    NewField111011.Name = "NewField111011";
                    NewField111011.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField111011.TextFont.Name = "Arial";
                    NewField111011.TextFont.Size = 9;
                    NewField111011.TextFont.Bold = true;
                    NewField111011.TextFont.CharSet = 162;
                    NewField111011.Value = @"Tutar";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 22, 203, 22, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.DrawWidth = 2;

                    NewField111811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 16, 91, 21, false);
                    NewField111811.Name = "NewField111811";
                    NewField111811.TextFont.Name = "Arial";
                    NewField111811.TextFont.Size = 9;
                    NewField111811.TextFont.Bold = true;
                    NewField111811.TextFont.CharSet = 162;
                    NewField111811.Value = @"Tc Kimlik No";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountDocument.GetUnpaidAccDocs_Class dataset_GetUnpaidAccDocs = MyParentReport.HEAD.rsGroup.GetCurrentRecord<AccountDocument.GetUnpaidAccDocs_Class>(0);
                    NewField1111111.CalcValue = NewField1111111.Value;
                    INVOICETYPE.CalcValue = (dataset_GetUnpaidAccDocs != null ? Globals.ToStringCore(dataset_GetUnpaidAccDocs.Type) : "");
                    INVOICETYPE.PostFieldValueCalculation();
                    NewField1121131.CalcValue = NewField1121131.Value;
                    NewField11511.CalcValue = NewField11511.Value;
                    NewField11611.CalcValue = NewField11611.Value;
                    NewField171.CalcValue = NewField171.Value;
                    NewField11811.CalcValue = NewField11811.Value;
                    NewField191.CalcValue = NewField191.Value;
                    NewField111011.CalcValue = NewField111011.Value;
                    NewField111811.CalcValue = NewField111811.Value;
                    return new TTReportObject[] { NewField1111111,INVOICETYPE,NewField1121131,NewField11511,NewField11611,NewField171,NewField11811,NewField191,NewField111011,NewField111811};
                }

                public override void RunScript()
                {
#region PROCEDURETYPE HEADER_Script
                    if(((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.INVOICEORCOLLECTEDINVOICE == InvoiceOrCollectedInvoiceEnum.CollectedInvoice)
            {
                this.NewField191.CalcValue = "Açıklama";
                this.NewField171.CalcValue = "";
            }
#endregion PROCEDURETYPE HEADER_Script
                }
            }
            public partial class PROCEDURETYPEGroupFooter : TTReportSection
            {
                public UnpaidInvoiceListReport MyParentReport
                {
                    get { return (UnpaidInvoiceListReport)ParentReport; }
                }
                
                public TTReportField NewField11111;
                public TTReportShape NewLine1111;
                public TTReportField TOTALPRICE; 
                public PROCEDURETYPEGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 23;
                    RepeatCount = 0;
                    
                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 4, 168, 9, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Size = 9;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Toplam :";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 140, 3, 203, 3, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 4, 203, 9, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.TextFormat = @"#,##0.#0";
                    TOTALPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALPRICE.TextFont.Name = "Arial";
                    TOTALPRICE.TextFont.Size = 9;
                    TOTALPRICE.TextFont.CharSet = 162;
                    TOTALPRICE.Value = @"{@sumof(PRICE)@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountDocument.GetUnpaidAccDocs_Class dataset_GetUnpaidAccDocs = MyParentReport.HEAD.rsGroup.GetCurrentRecord<AccountDocument.GetUnpaidAccDocs_Class>(0);
                    NewField11111.CalcValue = NewField11111.Value;
                    TOTALPRICE.CalcValue = ParentGroup.FieldSums["PRICE"].Value.ToString();;
                    return new TTReportObject[] { NewField11111,TOTALPRICE};
                }
            }

        }

        public PROCEDURETYPEGroup PROCEDURETYPE;

        public partial class MAINGroup : TTReportGroup
        {
            public UnpaidInvoiceListReport MyParentReport
            {
                get { return (UnpaidInvoiceListReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DOCUMENTNO { get {return Body().DOCUMENTNO;} }
            public TTReportField DOCUMENTDATE { get {return Body().DOCUMENTDATE;} }
            public TTReportField SNO { get {return Body().SNO;} }
            public TTReportField PATIENTNAME { get {return Body().PATIENTNAME;} }
            public TTReportField PATIENTNO { get {return Body().PATIENTNO;} }
            public TTReportField PRICE { get {return Body().PRICE;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField SURNAME { get {return Body().SURNAME;} }
            public TTReportField PATIENTID { get {return Body().PATIENTID;} }
            public TTReportField UNIQUEREFNO { get {return Body().UNIQUEREFNO;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                AccountDocument.GetUnpaidAccDocs_Class dataSet_GetUnpaidAccDocs = ParentGroup.rsGroup.GetCurrentRecord<AccountDocument.GetUnpaidAccDocs_Class>(0);    
                return new object[] {(dataSet_GetUnpaidAccDocs==null ? null : dataSet_GetUnpaidAccDocs.Payercode), (dataSet_GetUnpaidAccDocs==null ? null : dataSet_GetUnpaidAccDocs.Type)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public UnpaidInvoiceListReport MyParentReport
                {
                    get { return (UnpaidInvoiceListReport)ParentReport; }
                }
                
                public TTReportField DOCUMENTNO;
                public TTReportField DOCUMENTDATE;
                public TTReportField SNO;
                public TTReportField PATIENTNAME;
                public TTReportField PATIENTNO;
                public TTReportField PRICE;
                public TTReportField NAME;
                public TTReportField SURNAME;
                public TTReportField PATIENTID;
                public TTReportField UNIQUEREFNO; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    DOCUMENTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 1, 40, 6, false);
                    DOCUMENTNO.Name = "DOCUMENTNO";
                    DOCUMENTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNO.TextFont.Name = "Arial";
                    DOCUMENTNO.TextFont.Size = 9;
                    DOCUMENTNO.TextFont.CharSet = 162;
                    DOCUMENTNO.Value = @"{#HEAD.DOCUMENTNO#}";

                    DOCUMENTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 1, 66, 6, false);
                    DOCUMENTDATE.Name = "DOCUMENTDATE";
                    DOCUMENTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTDATE.TextFormat = @"Short Date";
                    DOCUMENTDATE.TextFont.Name = "Arial";
                    DOCUMENTDATE.TextFont.Size = 9;
                    DOCUMENTDATE.TextFont.CharSet = 162;
                    DOCUMENTDATE.Value = @"{#HEAD.DOCUMENTDATE#}";

                    SNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 18, 6, false);
                    SNO.Name = "SNO";
                    SNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SNO.TextFont.Name = "Arial";
                    SNO.TextFont.Size = 9;
                    SNO.TextFont.CharSet = 162;
                    SNO.Value = @"{@groupcounter@}";

                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 1, 141, 6, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.TextFormat = @"Short Date";
                    PATIENTNAME.TextFont.Name = "Arial";
                    PATIENTNAME.TextFont.Size = 9;
                    PATIENTNAME.TextFont.CharSet = 162;
                    PATIENTNAME.Value = @"{#HEAD.NAME#} {#HEAD.SURNAME#}";

                    PATIENTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 1, 168, 6, false);
                    PATIENTNO.Name = "PATIENTNO";
                    PATIENTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNO.TextFormat = @"Short Date";
                    PATIENTNO.TextFont.Name = "Arial";
                    PATIENTNO.TextFont.Size = 9;
                    PATIENTNO.TextFont.CharSet = 162;
                    PATIENTNO.Value = @"{#HEAD.ID#}";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 1, 203, 6, false);
                    PRICE.Name = "PRICE";
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"#,##0.#0";
                    PRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICE.TextFont.Name = "Arial";
                    PRICE.TextFont.Size = 9;
                    PRICE.TextFont.CharSet = 162;
                    PRICE.Value = @"{#HEAD.GENERALTOTALPRICE#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 0, 273, 5, false);
                    NAME.Name = "NAME";
                    NAME.Visible = EvetHayirEnum.ehHayir;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.Value = @"{#HEAD.NAME#}";

                    SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 0, 333, 5, false);
                    SURNAME.Name = "SURNAME";
                    SURNAME.Visible = EvetHayirEnum.ehHayir;
                    SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURNAME.Value = @"{#HEAD.SURNAME#}";

                    PATIENTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 278, 0, 303, 5, false);
                    PATIENTID.Name = "PATIENTID";
                    PATIENTID.Visible = EvetHayirEnum.ehHayir;
                    PATIENTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTID.Value = @"{#HEAD.ID#}";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 1, 91, 6, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.TextFormat = @"Short Date";
                    UNIQUEREFNO.TextFont.Name = "Arial";
                    UNIQUEREFNO.TextFont.Size = 9;
                    UNIQUEREFNO.TextFont.CharSet = 162;
                    UNIQUEREFNO.Value = @"{#HEAD.UNIQUEREFNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountDocument.GetUnpaidAccDocs_Class dataset_GetUnpaidAccDocs = MyParentReport.HEAD.rsGroup.GetCurrentRecord<AccountDocument.GetUnpaidAccDocs_Class>(0);
                    DOCUMENTNO.CalcValue = (dataset_GetUnpaidAccDocs != null ? Globals.ToStringCore(dataset_GetUnpaidAccDocs.DocumentNo) : "");
                    DOCUMENTDATE.CalcValue = (dataset_GetUnpaidAccDocs != null ? Globals.ToStringCore(dataset_GetUnpaidAccDocs.DocumentDate) : "");
                    SNO.CalcValue = ParentGroup.GroupCounter.ToString();
                    PATIENTNAME.CalcValue = (dataset_GetUnpaidAccDocs != null ? Globals.ToStringCore(dataset_GetUnpaidAccDocs.Name) : "") + @" " + (dataset_GetUnpaidAccDocs != null ? Globals.ToStringCore(dataset_GetUnpaidAccDocs.Surname) : "");
                    PATIENTNO.CalcValue = (dataset_GetUnpaidAccDocs != null ? Globals.ToStringCore(dataset_GetUnpaidAccDocs.ID) : "");
                    PRICE.CalcValue = (dataset_GetUnpaidAccDocs != null ? Globals.ToStringCore(dataset_GetUnpaidAccDocs.GeneralTotalPrice) : "");
                    NAME.CalcValue = (dataset_GetUnpaidAccDocs != null ? Globals.ToStringCore(dataset_GetUnpaidAccDocs.Name) : "");
                    SURNAME.CalcValue = (dataset_GetUnpaidAccDocs != null ? Globals.ToStringCore(dataset_GetUnpaidAccDocs.Surname) : "");
                    PATIENTID.CalcValue = (dataset_GetUnpaidAccDocs != null ? Globals.ToStringCore(dataset_GetUnpaidAccDocs.ID) : "");
                    UNIQUEREFNO.CalcValue = (dataset_GetUnpaidAccDocs != null ? Globals.ToStringCore(dataset_GetUnpaidAccDocs.UniqueRefNo) : "");
                    return new TTReportObject[] { DOCUMENTNO,DOCUMENTDATE,SNO,PATIENTNAME,PATIENTNO,PRICE,NAME,SURNAME,PATIENTID,UNIQUEREFNO};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.TOTALINVOICEPRICE = ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.TOTALINVOICEPRICE + Convert.ToDouble(this.PRICE.CalcValue);
            
            if (this.PATIENTNO.CalcValue == "0")
                this.PATIENTNO.CalcValue = "";
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class NOTEGroup : TTReportGroup
        {
            public UnpaidInvoiceListReport MyParentReport
            {
                get { return (UnpaidInvoiceListReport)ParentReport; }
            }

            new public NOTEGroupHeader Header()
            {
                return (NOTEGroupHeader)_header;
            }

            new public NOTEGroupFooter Footer()
            {
                return (NOTEGroupFooter)_footer;
            }

            public TTReportField NewField1116111 { get {return Header().NewField1116111;} }
            public TTReportField NewField11116111 { get {return Header().NewField11116111;} }
            public TTReportField NOTE1 { get {return Header().NOTE1;} }
            public TTReportField NewField1151611 { get {return Header().NewField1151611;} }
            public TTReportField BASLIK111 { get {return Header().BASLIK111;} }
            public TTReportField BASLIK112 { get {return Header().BASLIK112;} }
            public TTReportField BASLIK11211 { get {return Header().BASLIK11211;} }
            public TTReportField XXXXXXSEHIR { get {return Header().XXXXXXSEHIR;} }
            public TTReportField XXXXXXADI { get {return Header().XXXXXXADI;} }
            public TTReportField DOSENO { get {return Header().DOSENO;} }
            public TTReportField ACCOUNTANTNAME { get {return Header().ACCOUNTANTNAME;} }
            public TTReportField ACCOUNTANTTITLE { get {return Header().ACCOUNTANTTITLE;} }
            public TTReportField ACCOUNTANT11 { get {return Header().ACCOUNTANT11;} }
            public TTReportField SUBJECT { get {return Header().SUBJECT;} }
            public TTReportField HEADTEXT { get {return Header().HEADTEXT;} }
            public TTReportField DATE2 { get {return Header().DATE2;} }
            public NOTEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public NOTEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new NOTEGroupHeader(this);
                _footer = new NOTEGroupFooter(this);

            }

            public partial class NOTEGroupHeader : TTReportSection
            {
                public UnpaidInvoiceListReport MyParentReport
                {
                    get { return (UnpaidInvoiceListReport)ParentReport; }
                }
                
                public TTReportField NewField1116111;
                public TTReportField NewField11116111;
                public TTReportField NOTE1;
                public TTReportField NewField1151611;
                public TTReportField BASLIK111;
                public TTReportField BASLIK112;
                public TTReportField BASLIK11211;
                public TTReportField XXXXXXSEHIR;
                public TTReportField XXXXXXADI;
                public TTReportField DOSENO;
                public TTReportField ACCOUNTANTNAME;
                public TTReportField ACCOUNTANTTITLE;
                public TTReportField ACCOUNTANT11;
                public TTReportField SUBJECT;
                public TTReportField HEADTEXT;
                public TTReportField DATE2; 
                public NOTEGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 167;
                    IsAligned = EvetHayirEnum.ehEvet;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1116111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 55, 31, 61, false);
                    NewField1116111.Name = "NewField1116111";
                    NewField1116111.TextFont.Bold = true;
                    NewField1116111.TextFont.CharSet = 162;
                    NewField1116111.Value = @"SAYI  :";

                    NewField11116111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 62, 31, 68, false);
                    NewField11116111.Name = "NewField11116111";
                    NewField11116111.TextFont.Bold = true;
                    NewField11116111.TextFont.CharSet = 162;
                    NewField11116111.Value = @"KONU  :";

                    NOTE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 89, 193, 130, false);
                    NOTE1.Name = "NOTE1";
                    NOTE1.MultiLine = EvetHayirEnum.ehEvet;
                    NOTE1.WordBreak = EvetHayirEnum.ehEvet;
                    NOTE1.TextFont.Name = "Arial";
                    NOTE1.TextFont.Size = 9;
                    NOTE1.TextFont.CharSet = 162;
                    NOTE1.Value = @"";

                    NewField1151611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 145, 110, 161, false);
                    NewField1151611.Name = "NewField1151611";
                    NewField1151611.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1151611.NoClip = EvetHayirEnum.ehEvet;
                    NewField1151611.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1151611.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1151611.TextFont.Name = "Arial";
                    NewField1151611.TextFont.Size = 9;
                    NewField1151611.TextFont.CharSet = 162;
                    NewField1151611.Value = @"EKLER
------
EK A  - Fatura Dökümü ve İsim Listesi";

                    BASLIK111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 15, 129, 20, false);
                    BASLIK111.Name = "BASLIK111";
                    BASLIK111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK111.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK111.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK111.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK111.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK111.TextFont.Name = "Arial";
                    BASLIK111.TextFont.Bold = true;
                    BASLIK111.TextFont.CharSet = 162;
                    BASLIK111.Value = @"T.C.";

                    BASLIK112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 21, 133, 27, false);
                    BASLIK112.Name = "BASLIK112";
                    BASLIK112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK112.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK112.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK112.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK112.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK112.TextFont.Name = "Arial";
                    BASLIK112.TextFont.Bold = true;
                    BASLIK112.TextFont.CharSet = 162;
                    BASLIK112.Value = @"XXXXXX";

                    BASLIK11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 24, 298, 30, false);
                    BASLIK11211.Name = "BASLIK11211";
                    BASLIK11211.Visible = EvetHayirEnum.ehHayir;
                    BASLIK11211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK11211.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK11211.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK11211.TextFont.Name = "Arial";
                    BASLIK11211.TextFont.Bold = true;
                    BASLIK11211.TextFont.CharSet = 162;
                    BASLIK11211.Value = @"DÖNER SERMAYE İŞLETME MÜDÜRLÜĞÜ";

                    XXXXXXSEHIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 35, 138, 41, false);
                    XXXXXXSEHIR.Name = "XXXXXXSEHIR";
                    XXXXXXSEHIR.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXSEHIR.CaseFormat = CaseFormatEnum.fcUpperCase;
                    XXXXXXSEHIR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXSEHIR.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXSEHIR.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXSEHIR.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXSEHIR.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXSEHIR.TextFont.Name = "Arial";
                    XXXXXXSEHIR.TextFont.Bold = true;
                    XXXXXXSEHIR.TextFont.CharSet = 162;
                    XXXXXXSEHIR.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")
";

                    XXXXXXADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 28, 204, 34, false);
                    XXXXXXADI.Name = "XXXXXXADI";
                    XXXXXXADI.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXADI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    XXXXXXADI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXADI.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXADI.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXADI.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXADI.TextFont.Name = "Arial";
                    XXXXXXADI.TextFont.Bold = true;
                    XXXXXXADI.TextFont.CharSet = 162;
                    XXXXXXADI.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")
";

                    DOSENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 55, 132, 61, false);
                    DOSENO.Name = "DOSENO";
                    DOSENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOSENO.MultiLine = EvetHayirEnum.ehEvet;
                    DOSENO.WordBreak = EvetHayirEnum.ehEvet;
                    DOSENO.TextFont.Name = "Arial";
                    DOSENO.TextFont.CharSet = 162;
                    DOSENO.Value = @"";

                    ACCOUNTANTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 139, 193, 145, false);
                    ACCOUNTANTNAME.Name = "ACCOUNTANTNAME";
                    ACCOUNTANTNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTANTNAME.TextFont.Name = "Arial";
                    ACCOUNTANTNAME.TextFont.Size = 9;
                    ACCOUNTANTNAME.TextFont.CharSet = 162;
                    ACCOUNTANTNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""DONERSERMAYEISLETMEMUDURUADI"", """")
";

                    ACCOUNTANTTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 146, 193, 152, false);
                    ACCOUNTANTTITLE.Name = "ACCOUNTANTTITLE";
                    ACCOUNTANTTITLE.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTANTTITLE.TextFont.Name = "Arial";
                    ACCOUNTANTTITLE.TextFont.Size = 9;
                    ACCOUNTANTTITLE.TextFont.CharSet = 162;
                    ACCOUNTANTTITLE.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""DONERSERMAYEISLETMEMUDURUUNVANI"", """")
";

                    ACCOUNTANT11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 152, 193, 160, false);
                    ACCOUNTANT11.Name = "ACCOUNTANT11";
                    ACCOUNTANT11.TextFont.Name = "Arial";
                    ACCOUNTANT11.TextFont.Size = 9;
                    ACCOUNTANT11.TextFont.CharSet = 162;
                    ACCOUNTANT11.Value = @"Döner Sermaye İşletme Müdürü";

                    SUBJECT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 62, 132, 68, false);
                    SUBJECT.Name = "SUBJECT";
                    SUBJECT.TextFont.Name = "Arial";
                    SUBJECT.TextFont.CharSet = 162;
                    SUBJECT.Value = @"Ödenmeyen Faturalar Hk.";

                    HEADTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 73, 193, 78, false);
                    HEADTEXT.Name = "HEADTEXT";
                    HEADTEXT.Visible = EvetHayirEnum.ehHayir;
                    HEADTEXT.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HEADTEXT.MultiLine = EvetHayirEnum.ehEvet;
                    HEADTEXT.WordBreak = EvetHayirEnum.ehEvet;
                    HEADTEXT.TextFont.Name = "Arial";
                    HEADTEXT.TextFont.Size = 9;
                    HEADTEXT.TextFont.CharSet = 162;
                    HEADTEXT.Value = @"{%PAYERNAME%}  {%PAYERCITY%} 
";

                    DATE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 55, 193, 61, false);
                    DATE2.Name = "DATE2";
                    DATE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE2.TextFormat = @"dd/MM/yy";
                    DATE2.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DATE2.TextFont.Name = "Arial";
                    DATE2.TextFont.CharSet = 162;
                    DATE2.Value = @"{@printdate@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1116111.CalcValue = NewField1116111.Value;
                    NewField11116111.CalcValue = NewField11116111.Value;
                    NOTE1.CalcValue = NOTE1.Value;
                    NewField1151611.CalcValue = NewField1151611.Value;
                    BASLIK111.CalcValue = BASLIK111.Value;
                    BASLIK112.CalcValue = BASLIK112.Value;
                    BASLIK11211.CalcValue = BASLIK11211.Value;
                    DOSENO.CalcValue = @"";
                    ACCOUNTANT11.CalcValue = ACCOUNTANT11.Value;
                    SUBJECT.CalcValue = SUBJECT.Value;
                    HEADTEXT.CalcValue = HEADTEXT.Value;
                    DATE2.CalcValue = DateTime.Now.ToShortDateString();
                    XXXXXXSEHIR.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "")
;
                    XXXXXXADI.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "")
;
                    ACCOUNTANTNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("DONERSERMAYEISLETMEMUDURUADI", "")
;
                    ACCOUNTANTTITLE.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("DONERSERMAYEISLETMEMUDURUUNVANI", "")
;
                    return new TTReportObject[] { NewField1116111,NewField11116111,NOTE1,NewField1151611,BASLIK111,BASLIK112,BASLIK11211,DOSENO,ACCOUNTANT11,SUBJECT,HEADTEXT,DATE2,XXXXXXSEHIR,XXXXXXADI,ACCOUNTANTNAME,ACCOUNTANTTITLE};
                }

                public override void RunScript()
                {
#region NOTE HEADER_Script
                    string s = new string (' ',15);
            this.DOSENO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALDOSENOWITHOUTYEAR", "") + " - " + ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.DOSENOFIRSTVALUE.ToString() + " - " +  ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.YEAR.ToString() + " / " + ((UnpaidInvoiceListReport)ParentReport).RuntimeParameters.DOSENOLASTVALUE.ToString();
            this.NOTE1.CalcValue = s + "XXXXXXmizde ayaktan ve yatarak tedavi gören  EK' li listede bilgileri yazılı kurumunuz personellerine ait tedavi faturalarının ödenmediği tespit edilmiştir."  + "\r\n\n"  + s + "Tedavi ücretlerinin ivedilikle  " + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALIBANNO", "") + "  nolu hesaba ödenmesi, ödenmiş ise fatura numaralarının,ödeme miktarı ve tarihlerinin belirtildiği liste ile birlikte, ödeme emri ve banka dekontlarının tarafımıza gönderilmesi, aksi takdirde gereken işlemin başlatılacağı bilgilerinize rica olunur.";
#endregion NOTE HEADER_Script
                }
            }
            public partial class NOTEGroupFooter : TTReportSection
            {
                public UnpaidInvoiceListReport MyParentReport
                {
                    get { return (UnpaidInvoiceListReport)ParentReport; }
                }
                 
                public NOTEGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public NOTEGroup NOTE;

        public partial class USTYAZIMAINGroup : TTReportGroup
        {
            public UnpaidInvoiceListReport MyParentReport
            {
                get { return (UnpaidInvoiceListReport)ParentReport; }
            }

            new public USTYAZIMAINGroupBody Body()
            {
                return (USTYAZIMAINGroupBody)_body;
            }
            public USTYAZIMAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public USTYAZIMAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new USTYAZIMAINGroupBody(this);
            }

            public partial class USTYAZIMAINGroupBody : TTReportSection
            {
                public UnpaidInvoiceListReport MyParentReport
                {
                    get { return (UnpaidInvoiceListReport)ParentReport; }
                }
                 
                public USTYAZIMAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public USTYAZIMAINGroup USTYAZIMAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public UnpaidInvoiceListReport()
        {
            HEAD = new HEADGroup(this,"HEAD");
            HEADERB = new HEADERBGroup(HEAD,"HEADERB");
            PROCEDURETYPE = new PROCEDURETYPEGroup(HEADERB,"PROCEDURETYPE");
            MAIN = new MAINGroup(PROCEDURETYPE,"MAIN");
            NOTE = new NOTEGroup(HEADERB,"NOTE");
            USTYAZIMAIN = new USTYAZIMAINGroup(NOTE,"USTYAZIMAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("PAYERSTARTCODE", "", "Kurum Başlangıç Kodu", @"", false, false, false, new Guid("c573f560-55ee-4514-8ef8-380110697129"));
            reportParameter = Parameters.Add("PAYERENDCODE", "", "Kurum Bitiş Kodu", @"", false, false, false, new Guid("c573f560-55ee-4514-8ef8-380110697129"));
            reportParameter = Parameters.Add("OUTPATIENTINPATIENT", "3", "Hasta Durumu", @"", true, true, false, new Guid("0ab6e9e9-139a-4b78-9a97-05ed687758d5"));
            reportParameter = Parameters.Add("OUTPATIENTINPATIENTOTHER", "", "Ayaktan/Yatan/Hepsi", @"", false, false, false, new Guid("0ab6e9e9-139a-4b78-9a97-05ed687758d5"));
            reportParameter = Parameters.Add("STARTPAYEROBJ", "", "İlk Kurum", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("61cb92fe-0330-48f5-9e09-674ba7a57b3d");
            reportParameter = Parameters.Add("ENDPAYEROBJ", "", "Son Kurum", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("61cb92fe-0330-48f5-9e09-674ba7a57b3d");
            reportParameter = Parameters.Add("OUTPATIENTINPATIENTBOTH", "", "Hepsi", @"", false, false, false, new Guid("0ab6e9e9-139a-4b78-9a97-05ed687758d5"));
            reportParameter = Parameters.Add("INVOICETYPE", "", "Hizmet Tipi", @"", true, true, false, new Guid("0a3c4939-e962-4672-9723-309d296eecae"));
            reportParameter = Parameters.Add("OUTPATIENTINPATIENTFORCOLLECTEDINV", "", "Ayaktan / Yatan", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("OUTPATIENTINPATIENTFORCOLLECTEDINV2", "", "Ayaktan / Yatan", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("INVOICETYPEINT", "", "Hizmet Tipi Sayısal", @"", false, false, true, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("TOTALINVOICEPRICE", "0", "Toplam Fatura Tutarı", @"", false, false, false, new Guid("53710a7d-9fdd-4078-a98e-228d2cc89909"));
            reportParameter = Parameters.Add("DOSENOFIRSTVALUE", "4", "İlk Ara Değer", @"", true, true, false, new Guid("cf463436-3c34-4659-a92f-d2d0af106485"));
            reportParameter = Parameters.Add("DOSENOLASTVALUE", "5", "Son Ara Değer", @"", true, true, false, new Guid("cf463436-3c34-4659-a92f-d2d0af106485"));
            reportParameter = Parameters.Add("YEAR", "10", "Yıl", @"", true, true, false, new Guid("cf463436-3c34-4659-a92f-d2d0af106485"));
            reportParameter = Parameters.Add("INVOICEORCOLLECTEDINVOICE", "", "Fatura Tipi", @"", true, true, false, new Guid("5ead1ad8-a6f9-4b3c-8cca-8ec0bc89aa24"));
            reportParameter = Parameters.Add("ISINVOICE", "", "FATURA", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("ISCOLLECTEDINVOICE", "", "Toplu Fatura", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("PAYERSTARTCODE"))
                _runtimeParameters.PAYERSTARTCODE = (long?)TTObjectDefManager.Instance.DataTypes["Long9"].ConvertValue(parameters["PAYERSTARTCODE"]);
            if (parameters.ContainsKey("PAYERENDCODE"))
                _runtimeParameters.PAYERENDCODE = (long?)TTObjectDefManager.Instance.DataTypes["Long9"].ConvertValue(parameters["PAYERENDCODE"]);
            if (parameters.ContainsKey("OUTPATIENTINPATIENT"))
                _runtimeParameters.OUTPATIENTINPATIENT = (OutPatientInPatientBothEnum?)(int?)TTObjectDefManager.Instance.DataTypes["OutPatientInPatientBothEnum"].ConvertValue(parameters["OUTPATIENTINPATIENT"]);
            if (parameters.ContainsKey("OUTPATIENTINPATIENTOTHER"))
                _runtimeParameters.OUTPATIENTINPATIENTOTHER = (OutPatientInPatientBothEnum?)(int?)TTObjectDefManager.Instance.DataTypes["OutPatientInPatientBothEnum"].ConvertValue(parameters["OUTPATIENTINPATIENTOTHER"]);
            if (parameters.ContainsKey("STARTPAYEROBJ"))
                _runtimeParameters.STARTPAYEROBJ = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["STARTPAYEROBJ"]);
            if (parameters.ContainsKey("ENDPAYEROBJ"))
                _runtimeParameters.ENDPAYEROBJ = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["ENDPAYEROBJ"]);
            if (parameters.ContainsKey("OUTPATIENTINPATIENTBOTH"))
                _runtimeParameters.OUTPATIENTINPATIENTBOTH = (OutPatientInPatientBothEnum?)(int?)TTObjectDefManager.Instance.DataTypes["OutPatientInPatientBothEnum"].ConvertValue(parameters["OUTPATIENTINPATIENTBOTH"]);
            if (parameters.ContainsKey("INVOICETYPE"))
                _runtimeParameters.INVOICETYPE = (InvoiceTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["InvoiceTypeEnum"].ConvertValue(parameters["INVOICETYPE"]);
            if (parameters.ContainsKey("OUTPATIENTINPATIENTFORCOLLECTEDINV"))
                _runtimeParameters.OUTPATIENTINPATIENTFORCOLLECTEDINV = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["OUTPATIENTINPATIENTFORCOLLECTEDINV"]);
            if (parameters.ContainsKey("OUTPATIENTINPATIENTFORCOLLECTEDINV2"))
                _runtimeParameters.OUTPATIENTINPATIENTFORCOLLECTEDINV2 = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["OUTPATIENTINPATIENTFORCOLLECTEDINV2"]);
            if (parameters.ContainsKey("INVOICETYPEINT"))
                _runtimeParameters.INVOICETYPEINT = (List<int>)parameters["INVOICETYPEINT"];
            if (parameters.ContainsKey("TOTALINVOICEPRICE"))
                _runtimeParameters.TOTALINVOICEPRICE = (double?)TTObjectDefManager.Instance.DataTypes["Double23.8"].ConvertValue(parameters["TOTALINVOICEPRICE"]);
            if (parameters.ContainsKey("DOSENOFIRSTVALUE"))
                _runtimeParameters.DOSENOFIRSTVALUE = (string)TTObjectDefManager.Instance.DataTypes["String10"].ConvertValue(parameters["DOSENOFIRSTVALUE"]);
            if (parameters.ContainsKey("DOSENOLASTVALUE"))
                _runtimeParameters.DOSENOLASTVALUE = (string)TTObjectDefManager.Instance.DataTypes["String10"].ConvertValue(parameters["DOSENOLASTVALUE"]);
            if (parameters.ContainsKey("YEAR"))
                _runtimeParameters.YEAR = (string)TTObjectDefManager.Instance.DataTypes["String10"].ConvertValue(parameters["YEAR"]);
            if (parameters.ContainsKey("INVOICEORCOLLECTEDINVOICE"))
                _runtimeParameters.INVOICEORCOLLECTEDINVOICE = (InvoiceOrCollectedInvoiceEnum?)(int?)TTObjectDefManager.Instance.DataTypes["InvoiceOrCollectedInvoiceEnum"].ConvertValue(parameters["INVOICEORCOLLECTEDINVOICE"]);
            if (parameters.ContainsKey("ISINVOICE"))
                _runtimeParameters.ISINVOICE = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["ISINVOICE"]);
            if (parameters.ContainsKey("ISCOLLECTEDINVOICE"))
                _runtimeParameters.ISCOLLECTEDINVOICE = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["ISCOLLECTEDINVOICE"]);
            Name = "UNPAIDINVOICELISTREPORT";
            Caption = "Ödenmemiş Faturalar Listesi";
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