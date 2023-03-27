
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
    /// Manuel Kurum Faturası
    /// </summary>
    public partial class ManualInvoiceReport : TTReport
    {
#region Methods
   public int kdv = 0;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public double? PAGETOTAL = (double?)TTObjectDefManager.Instance.DataTypes["Double23.8"].ConvertValue("0");
            public double? TURNOVERTOTAL = (double?)TTObjectDefManager.Instance.DataTypes["Double23.8"].ConvertValue("0");
            public string ISLASTPAGE = (string)TTObjectDefManager.Instance.DataTypes["String10"].ConvertValue("False");
        }

        public partial class HEADGroup : TTReportGroup
        {
            public ManualInvoiceReport MyParentReport
            {
                get { return (ManualInvoiceReport)ParentReport; }
            }

            new public HEADGroupHeader Header()
            {
                return (HEADGroupHeader)_header;
            }

            new public HEADGroupFooter Footer()
            {
                return (HEADGroupFooter)_footer;
            }

            public TTReportField SEVKTARIHI { get {return Header().SEVKTARIHI;} }
            public TTReportField PAGE { get {return Header().PAGE;} }
            public TTReportField PAYER { get {return Header().PAYER;} }
            public TTReportField PATIENT { get {return Header().PATIENT;} }
            public TTReportField HPROTNO { get {return Header().HPROTNO;} }
            public TTReportField DOCUMENTDATE { get {return Header().DOCUMENTDATE;} }
            public TTReportField DOCUMENTNO { get {return Header().DOCUMENTNO;} }
            public TTReportField EPISODEOBJID { get {return Header().EPISODEOBJID;} }
            public TTReportField TAXINFO { get {return Header().TAXINFO;} }
            public TTReportField BANKACCOUNT { get {return Header().BANKACCOUNT;} }
            public TTReportField TURNOVERTOTALLABEL { get {return Header().TURNOVERTOTALLABEL;} }
            public TTReportField TURNOVERTOTAL { get {return Header().TURNOVERTOTAL;} }
            public TTReportField HOSPITALIBANNO { get {return Header().HOSPITALIBANNO;} }
            public TTReportField PAGENO { get {return Header().PAGENO;} }
            public TTReportField TL { get {return Header().TL;} }
            public TTReportField ACCOUNTANTNAME { get {return Header().ACCOUNTANTNAME;} }
            public TTReportField ACCOUNTANTTITLE { get {return Header().ACCOUNTANTTITLE;} }
            public TTReportField adsasd { get {return Header().adsasd;} }
            public TTReportField DESCRIPTION { get {return Header().DESCRIPTION;} }
            public TTReportField TOTALPRICE { get {return Footer().TOTALPRICE;} }
            public TTReportField PRICEWITHLETTERS { get {return Footer().PRICEWITHLETTERS;} }
            public TTReportField RESMIYAZITARIHI { get {return Footer().RESMIYAZITARIHI;} }
            public TTReportField PATIENTNAMEFOOTER { get {return Footer().PATIENTNAMEFOOTER;} }
            public TTReportField DOCUMENTDATEFOOTER { get {return Footer().DOCUMENTDATEFOOTER;} }
            public TTReportField TOTAL { get {return Footer().TOTAL;} }
            public TTReportField PAGE2 { get {return Footer().PAGE2;} }
            public TTReportField HPROTNOFOOTER { get {return Footer().HPROTNOFOOTER;} }
            public TTReportField TOTALDISCOUNTPRICE { get {return Footer().TOTALDISCOUNTPRICE;} }
            public TTReportField GENERALTOTALPRICE { get {return Footer().GENERALTOTALPRICE;} }
            public TTReportField PAGETOTALLABEL { get {return Footer().PAGETOTALLABEL;} }
            public TTReportField PAGETOTAL { get {return Footer().PAGETOTAL;} }
            public TTReportField TL1 { get {return Footer().TL1;} }
            public TTReportField TL2 { get {return Footer().TL2;} }
            public TTReportField TL3 { get {return Footer().TL3;} }
            public TTReportField TL4 { get {return Footer().TL4;} }
            public TTReportField PAGENO2 { get {return Footer().PAGENO2;} }
            public TTReportField RESMIYAZINO { get {return Footer().RESMIYAZINO;} }
            public TTReportField PAYERFOOTER { get {return Footer().PAYERFOOTER;} }
            public TTReportField PRICE { get {return Footer().PRICE;} }
            public TTReportField DOCUMENTNOFOOTER { get {return Footer().DOCUMENTNOFOOTER;} }
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
                list[0] = new TTReportNqlData<ManualInvoice.ManualInvoiceReportInfoQuery_Class>("ManualInvoiceReportInfoQuery2", ManualInvoice.ManualInvoiceReportInfoQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public ManualInvoiceReport MyParentReport
                {
                    get { return (ManualInvoiceReport)ParentReport; }
                }
                
                public TTReportField SEVKTARIHI;
                public TTReportField PAGE;
                public TTReportField PAYER;
                public TTReportField PATIENT;
                public TTReportField HPROTNO;
                public TTReportField DOCUMENTDATE;
                public TTReportField DOCUMENTNO;
                public TTReportField EPISODEOBJID;
                public TTReportField TAXINFO;
                public TTReportField BANKACCOUNT;
                public TTReportField TURNOVERTOTALLABEL;
                public TTReportField TURNOVERTOTAL;
                public TTReportField HOSPITALIBANNO;
                public TTReportField PAGENO;
                public TTReportField TL;
                public TTReportField ACCOUNTANTNAME;
                public TTReportField ACCOUNTANTTITLE;
                public TTReportField adsasd;
                public TTReportField DESCRIPTION; 
                public HEADGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 97;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    SEVKTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 38, 62, 43, false);
                    SEVKTARIHI.Name = "SEVKTARIHI";
                    SEVKTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEVKTARIHI.TextFormat = @"dd/MM/yyyy";
                    SEVKTARIHI.TextFont.Size = 8;
                    SEVKTARIHI.TextFont.CharSet = 162;
                    SEVKTARIHI.Value = @"{#SENDINGDATE#}";

                    PAGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 277, 14, 302, 19, false);
                    PAGE.Name = "PAGE";
                    PAGE.Visible = EvetHayirEnum.ehHayir;
                    PAGE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGE.Value = @"";

                    PAYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 47, 168, 55, false);
                    PAYER.Name = "PAYER";
                    PAYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYER.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYER.MultiLine = EvetHayirEnum.ehEvet;
                    PAYER.WordBreak = EvetHayirEnum.ehEvet;
                    PAYER.ExpandTabs = EvetHayirEnum.ehEvet;
                    PAYER.TextFont.Size = 8;
                    PAYER.TextFont.CharSet = 162;
                    PAYER.Value = @"{#PAYERCODE#} {#PAYERNAME#} {#PAYERCITY#}";

                    PATIENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 38, 168, 43, false);
                    PATIENT.Name = "PATIENT";
                    PATIENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENT.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PATIENT.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENT.NoClip = EvetHayirEnum.ehEvet;
                    PATIENT.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENT.ExpandTabs = EvetHayirEnum.ehEvet;
                    PATIENT.TextFont.Size = 8;
                    PATIENT.TextFont.CharSet = 162;
                    PATIENT.Value = @"{#PATIENTNAME#}";

                    HPROTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 38, 91, 43, false);
                    HPROTNO.Name = "HPROTNO";
                    HPROTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HPROTNO.TextFont.Size = 8;
                    HPROTNO.TextFont.CharSet = 162;
                    HPROTNO.Value = @"{#SENDINGNO#}";

                    DOCUMENTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 25, 167, 30, false);
                    DOCUMENTDATE.Name = "DOCUMENTDATE";
                    DOCUMENTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTDATE.TextFormat = @"dd/MM/yyyy";
                    DOCUMENTDATE.TextFont.Size = 8;
                    DOCUMENTDATE.TextFont.CharSet = 162;
                    DOCUMENTDATE.Value = @"{#DOCUMENTDATE#}";

                    DOCUMENTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 8, 167, 13, false);
                    DOCUMENTNO.Name = "DOCUMENTNO";
                    DOCUMENTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNO.TextFont.Size = 8;
                    DOCUMENTNO.TextFont.CharSet = 162;
                    DOCUMENTNO.Value = @"{#DOCUMENTNO#}";

                    EPISODEOBJID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 277, 7, 302, 12, false);
                    EPISODEOBJID.Name = "EPISODEOBJID";
                    EPISODEOBJID.Visible = EvetHayirEnum.ehHayir;
                    EPISODEOBJID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEOBJID.Value = @"";

                    TAXINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 68, 60, 80, false);
                    TAXINFO.Name = "TAXINFO";
                    TAXINFO.FieldType = ReportFieldTypeEnum.ftExpression;
                    TAXINFO.MultiLine = EvetHayirEnum.ehEvet;
                    TAXINFO.NoClip = EvetHayirEnum.ehEvet;
                    TAXINFO.WordBreak = EvetHayirEnum.ehEvet;
                    TAXINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TAXINFO.TextFont.Size = 8;
                    TAXINFO.TextFont.CharSet = 162;
                    TAXINFO.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""TAXOFFICEINFO"", """")";

                    BANKACCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 68, 111, 76, false);
                    BANKACCOUNT.Name = "BANKACCOUNT";
                    BANKACCOUNT.FieldType = ReportFieldTypeEnum.ftExpression;
                    BANKACCOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.NoClip = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.ExpandTabs = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.TextFont.Size = 8;
                    BANKACCOUNT.TextFont.CharSet = 162;
                    BANKACCOUNT.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""BANKACCOUNTINFO"", """")
";

                    TURNOVERTOTALLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 85, 150, 89, false);
                    TURNOVERTOTALLABEL.Name = "TURNOVERTOTALLABEL";
                    TURNOVERTOTALLABEL.TextFont.Size = 8;
                    TURNOVERTOTALLABEL.TextFont.CharSet = 162;
                    TURNOVERTOTALLABEL.Value = @"Nakli Yekün :";

                    TURNOVERTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 85, 181, 89, false);
                    TURNOVERTOTAL.Name = "TURNOVERTOTAL";
                    TURNOVERTOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TURNOVERTOTAL.TextFormat = @"#,##0.#0";
                    TURNOVERTOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TURNOVERTOTAL.TextFont.Size = 8;
                    TURNOVERTOTAL.TextFont.CharSet = 162;
                    TURNOVERTOTAL.Value = @"";

                    HOSPITALIBANNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 76, 111, 80, false);
                    HOSPITALIBANNO.Name = "HOSPITALIBANNO";
                    HOSPITALIBANNO.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALIBANNO.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALIBANNO.NoClip = EvetHayirEnum.ehEvet;
                    HOSPITALIBANNO.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITALIBANNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    HOSPITALIBANNO.TextFont.Size = 8;
                    HOSPITALIBANNO.TextFont.CharSet = 162;
                    HOSPITALIBANNO.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALIBANNO"", """")
";

                    PAGENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 8, 184, 13, false);
                    PAGENO.Name = "PAGENO";
                    PAGENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENO.TextFont.Size = 8;
                    PAGENO.TextFont.CharSet = 162;
                    PAGENO.Value = @"{@pagenumber@}. SAYFA";

                    TL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 74, 233, 79, false);
                    TL.Name = "TL";
                    TL.Visible = EvetHayirEnum.ehHayir;
                    TL.TextFont.Size = 8;
                    TL.TextFont.CharSet = 162;
                    TL.Value = @"TL";

                    ACCOUNTANTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 68, 202, 72, false);
                    ACCOUNTANTNAME.Name = "ACCOUNTANTNAME";
                    ACCOUNTANTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCOUNTANTNAME.TextFont.Size = 8;
                    ACCOUNTANTNAME.TextFont.CharSet = 162;
                    ACCOUNTANTNAME.Value = @"{#ACCOUNTANTNAME#}";

                    ACCOUNTANTTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 72, 202, 76, false);
                    ACCOUNTANTTITLE.Name = "ACCOUNTANTTITLE";
                    ACCOUNTANTTITLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCOUNTANTTITLE.TextFont.Size = 8;
                    ACCOUNTANTTITLE.TextFont.CharSet = 162;
                    ACCOUNTANTTITLE.Value = @"{#ACCOUNTANTTITLE#}";

                    adsasd = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 76, 202, 80, false);
                    adsasd.Name = "adsasd";
                    adsasd.TextFont.Size = 8;
                    adsasd.TextFont.CharSet = 162;
                    adsasd.Value = @"Gelir Kısım Amiri";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 61, 202, 67, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Size = 8;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{#DESCRIPTION#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ManualInvoice.ManualInvoiceReportInfoQuery_Class dataset_ManualInvoiceReportInfoQuery2 = ParentGroup.rsGroup.GetCurrentRecord<ManualInvoice.ManualInvoiceReportInfoQuery_Class>(0);
                    SEVKTARIHI.CalcValue = (dataset_ManualInvoiceReportInfoQuery2 != null ? Globals.ToStringCore(dataset_ManualInvoiceReportInfoQuery2.SendingDate) : "");
                    PAGE.CalcValue = @"";
                    PAYER.CalcValue = (dataset_ManualInvoiceReportInfoQuery2 != null ? Globals.ToStringCore(dataset_ManualInvoiceReportInfoQuery2.Payercode) : "") + @" " + (dataset_ManualInvoiceReportInfoQuery2 != null ? Globals.ToStringCore(dataset_ManualInvoiceReportInfoQuery2.Payername) : "") + @" " + (dataset_ManualInvoiceReportInfoQuery2 != null ? Globals.ToStringCore(dataset_ManualInvoiceReportInfoQuery2.Payercity) : "");
                    PATIENT.CalcValue = (dataset_ManualInvoiceReportInfoQuery2 != null ? Globals.ToStringCore(dataset_ManualInvoiceReportInfoQuery2.PatientName) : "");
                    HPROTNO.CalcValue = (dataset_ManualInvoiceReportInfoQuery2 != null ? Globals.ToStringCore(dataset_ManualInvoiceReportInfoQuery2.SendingNo) : "");
                    DOCUMENTDATE.CalcValue = (dataset_ManualInvoiceReportInfoQuery2 != null ? Globals.ToStringCore(dataset_ManualInvoiceReportInfoQuery2.DocumentDate) : "");
                    DOCUMENTNO.CalcValue = (dataset_ManualInvoiceReportInfoQuery2 != null ? Globals.ToStringCore(dataset_ManualInvoiceReportInfoQuery2.DocumentNo) : "");
                    EPISODEOBJID.CalcValue = @"";
                    TURNOVERTOTALLABEL.CalcValue = TURNOVERTOTALLABEL.Value;
                    TURNOVERTOTAL.CalcValue = @"";
                    PAGENO.CalcValue = ParentReport.CurrentPageNumber.ToString() + @". SAYFA";
                    TL.CalcValue = TL.Value;
                    ACCOUNTANTNAME.CalcValue = (dataset_ManualInvoiceReportInfoQuery2 != null ? Globals.ToStringCore(dataset_ManualInvoiceReportInfoQuery2.AccountantName) : "");
                    ACCOUNTANTTITLE.CalcValue = (dataset_ManualInvoiceReportInfoQuery2 != null ? Globals.ToStringCore(dataset_ManualInvoiceReportInfoQuery2.AccountantTitle) : "");
                    adsasd.CalcValue = adsasd.Value;
                    DESCRIPTION.CalcValue = (dataset_ManualInvoiceReportInfoQuery2 != null ? Globals.ToStringCore(dataset_ManualInvoiceReportInfoQuery2.Description) : "");
                    TAXINFO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("TAXOFFICEINFO", "");
                    BANKACCOUNT.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("BANKACCOUNTINFO", "")
;
                    HOSPITALIBANNO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALIBANNO", "")
;
                    return new TTReportObject[] { SEVKTARIHI,PAGE,PAYER,PATIENT,HPROTNO,DOCUMENTDATE,DOCUMENTNO,EPISODEOBJID,TURNOVERTOTALLABEL,TURNOVERTOTAL,PAGENO,TL,ACCOUNTANTNAME,ACCOUNTANTTITLE,adsasd,DESCRIPTION,TAXINFO,BANKACCOUNT,HOSPITALIBANNO};
                }

                public override void RunScript()
                {
#region HEAD HEADER_Script
                    if(this.PAGENO.CalcValue == "1. SAYFA")
                ((ManualInvoiceReport)ParentReport).RuntimeParameters.TURNOVERTOTAL = 0;
            
            ((ManualInvoiceReport)ParentReport).RuntimeParameters.PAGETOTAL = 0;
            this.TURNOVERTOTAL.CalcValue = (((ManualInvoiceReport)ParentReport).RuntimeParameters.TURNOVERTOTAL).ToString();
            
            if(((ManualInvoiceReport)ParentReport).RuntimeParameters.TURNOVERTOTAL == (double)0)
            {
                this.TURNOVERTOTAL.Visible = EvetHayirEnum.ehHayir;
                this.TURNOVERTOTALLABEL.Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
                this.TURNOVERTOTAL.Visible = EvetHayirEnum.ehEvet;
                this.TURNOVERTOTALLABEL.Visible = EvetHayirEnum.ehEvet;
            }
#endregion HEAD HEADER_Script
                }
            }
            public partial class HEADGroupFooter : TTReportSection
            {
                public ManualInvoiceReport MyParentReport
                {
                    get { return (ManualInvoiceReport)ParentReport; }
                }
                
                public TTReportField TOTALPRICE;
                public TTReportField PRICEWITHLETTERS;
                public TTReportField RESMIYAZITARIHI;
                public TTReportField PATIENTNAMEFOOTER;
                public TTReportField DOCUMENTDATEFOOTER;
                public TTReportField TOTAL;
                public TTReportField PAGE2;
                public TTReportField HPROTNOFOOTER;
                public TTReportField TOTALDISCOUNTPRICE;
                public TTReportField GENERALTOTALPRICE;
                public TTReportField PAGETOTALLABEL;
                public TTReportField PAGETOTAL;
                public TTReportField TL1;
                public TTReportField TL2;
                public TTReportField TL3;
                public TTReportField TL4;
                public TTReportField PAGENO2;
                public TTReportField RESMIYAZINO;
                public TTReportField PAYERFOOTER;
                public TTReportField PRICE;
                public TTReportField DOCUMENTNOFOOTER; 
                public HEADGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 109;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 8, 286, 12, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.Visible = EvetHayirEnum.ehHayir;
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.TextFormat = @"#,##0.#0";
                    TOTALPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALPRICE.TextFont.Size = 8;
                    TOTALPRICE.TextFont.CharSet = 162;
                    TOTALPRICE.Value = @"{#TOTALPRICE#}";

                    PRICEWITHLETTERS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 13, 181, 17, false);
                    PRICEWITHLETTERS.Name = "PRICEWITHLETTERS";
                    PRICEWITHLETTERS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICEWITHLETTERS.TextFormat = @"NUMBERTEXT( TL , KR)";
                    PRICEWITHLETTERS.TextFont.Size = 8;
                    PRICEWITHLETTERS.TextFont.CharSet = 162;
                    PRICEWITHLETTERS.Value = @"";

                    RESMIYAZITARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 52, 134, 56, false);
                    RESMIYAZITARIHI.Name = "RESMIYAZITARIHI";
                    RESMIYAZITARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESMIYAZITARIHI.TextFormat = @"dd/MM/yyyy";
                    RESMIYAZITARIHI.TextFont.Size = 8;
                    RESMIYAZITARIHI.TextFont.CharSet = 162;
                    RESMIYAZITARIHI.Value = @"{#SENDINGDATE#}";

                    PATIENTNAMEFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 56, 134, 60, false);
                    PATIENTNAMEFOOTER.Name = "PATIENTNAMEFOOTER";
                    PATIENTNAMEFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAMEFOOTER.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PATIENTNAMEFOOTER.TextFont.Size = 8;
                    PATIENTNAMEFOOTER.TextFont.CharSet = 162;
                    PATIENTNAMEFOOTER.Value = @"{#PATIENTNAME#}";

                    DOCUMENTDATEFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 52, 167, 56, false);
                    DOCUMENTDATEFOOTER.Name = "DOCUMENTDATEFOOTER";
                    DOCUMENTDATEFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTDATEFOOTER.TextFormat = @"dd/MM/yyyy";
                    DOCUMENTDATEFOOTER.TextFont.Size = 8;
                    DOCUMENTDATEFOOTER.TextFont.CharSet = 162;
                    DOCUMENTDATEFOOTER.Value = @"{#DOCUMENTDATE#}";

                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 60, 167, 64, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL.TextFormat = @"#,##0.#0";
                    TOTAL.TextFont.Size = 8;
                    TOTAL.TextFont.CharSet = 162;
                    TOTAL.Value = @"";

                    PAGE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 67, 261, 72, false);
                    PAGE2.Name = "PAGE2";
                    PAGE2.Visible = EvetHayirEnum.ehHayir;
                    PAGE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGE2.Value = @"";

                    HPROTNOFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 60, 134, 64, false);
                    HPROTNOFOOTER.Name = "HPROTNOFOOTER";
                    HPROTNOFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    HPROTNOFOOTER.TextFont.Size = 8;
                    HPROTNOFOOTER.TextFont.CharSet = 162;
                    HPROTNOFOOTER.Value = @"{#SENDINGNO#}";

                    TOTALDISCOUNTPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 13, 286, 17, false);
                    TOTALDISCOUNTPRICE.Name = "TOTALDISCOUNTPRICE";
                    TOTALDISCOUNTPRICE.Visible = EvetHayirEnum.ehHayir;
                    TOTALDISCOUNTPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALDISCOUNTPRICE.TextFormat = @"#,##0.#0";
                    TOTALDISCOUNTPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALDISCOUNTPRICE.TextFont.Size = 8;
                    TOTALDISCOUNTPRICE.TextFont.CharSet = 162;
                    TOTALDISCOUNTPRICE.Value = @"0";

                    GENERALTOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 18, 286, 22, false);
                    GENERALTOTALPRICE.Name = "GENERALTOTALPRICE";
                    GENERALTOTALPRICE.Visible = EvetHayirEnum.ehHayir;
                    GENERALTOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    GENERALTOTALPRICE.TextFormat = @"#,##0.#0";
                    GENERALTOTALPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GENERALTOTALPRICE.TextFont.Size = 8;
                    GENERALTOTALPRICE.TextFont.CharSet = 162;
                    GENERALTOTALPRICE.Value = @"{#TOTALPRICE#}";

                    PAGETOTALLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 3, 256, 7, false);
                    PAGETOTALLABEL.Name = "PAGETOTALLABEL";
                    PAGETOTALLABEL.Visible = EvetHayirEnum.ehHayir;
                    PAGETOTALLABEL.TextFont.Size = 8;
                    PAGETOTALLABEL.TextFont.CharSet = 162;
                    PAGETOTALLABEL.Value = @"Sayfa Toplamı:";

                    PAGETOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 3, 286, 7, false);
                    PAGETOTAL.Name = "PAGETOTAL";
                    PAGETOTAL.Visible = EvetHayirEnum.ehHayir;
                    PAGETOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGETOTAL.TextFormat = @"#,##0.#0";
                    PAGETOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGETOTAL.TextFont.Size = 8;
                    PAGETOTAL.TextFont.CharSet = 162;
                    PAGETOTAL.Value = @"";

                    TL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 290, 3, 295, 7, false);
                    TL1.Name = "TL1";
                    TL1.Visible = EvetHayirEnum.ehHayir;
                    TL1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TL1.TextFont.Size = 8;
                    TL1.TextFont.CharSet = 162;
                    TL1.Value = @"TL";

                    TL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 290, 8, 295, 12, false);
                    TL2.Name = "TL2";
                    TL2.Visible = EvetHayirEnum.ehHayir;
                    TL2.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TL2.TextFont.Size = 8;
                    TL2.TextFont.CharSet = 162;
                    TL2.Value = @"TL";

                    TL3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 290, 13, 295, 17, false);
                    TL3.Name = "TL3";
                    TL3.Visible = EvetHayirEnum.ehHayir;
                    TL3.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TL3.TextFont.Size = 8;
                    TL3.TextFont.CharSet = 162;
                    TL3.Value = @"TL";

                    TL4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 290, 18, 295, 22, false);
                    TL4.Name = "TL4";
                    TL4.Visible = EvetHayirEnum.ehHayir;
                    TL4.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TL4.TextFont.Size = 8;
                    TL4.TextFont.CharSet = 162;
                    TL4.Value = @"TL";

                    PAGENO2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 69, 186, 74, false);
                    PAGENO2.Name = "PAGENO2";
                    PAGENO2.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENO2.TextFont.Size = 8;
                    PAGENO2.TextFont.CharSet = 162;
                    PAGENO2.Value = @"{@pagenumber@}. SAYFA";

                    RESMIYAZINO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 48, 134, 52, false);
                    RESMIYAZINO.Name = "RESMIYAZINO";
                    RESMIYAZINO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESMIYAZINO.TextFont.Size = 8;
                    RESMIYAZINO.TextFont.CharSet = 162;
                    RESMIYAZINO.Value = @"";

                    PAYERFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 42, 180, 48, false);
                    PAYERFOOTER.Name = "PAYERFOOTER";
                    PAYERFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYERFOOTER.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYERFOOTER.MultiLine = EvetHayirEnum.ehEvet;
                    PAYERFOOTER.WordBreak = EvetHayirEnum.ehEvet;
                    PAYERFOOTER.ExpandTabs = EvetHayirEnum.ehEvet;
                    PAYERFOOTER.TextFont.Size = 8;
                    PAYERFOOTER.TextFont.CharSet = 162;
                    PAYERFOOTER.Value = @"{#PAYERCODE#} {#PAYERNAME#} {#PAYERCITY#}";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 5, 181, 9, false);
                    PRICE.Name = "PRICE";
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"#,##0.#0";
                    PRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICE.TextFont.Size = 8;
                    PRICE.TextFont.CharSet = 162;
                    PRICE.Value = @"";

                    DOCUMENTNOFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 69, 168, 74, false);
                    DOCUMENTNOFOOTER.Name = "DOCUMENTNOFOOTER";
                    DOCUMENTNOFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNOFOOTER.TextFont.Size = 8;
                    DOCUMENTNOFOOTER.TextFont.CharSet = 162;
                    DOCUMENTNOFOOTER.Value = @"{#DOCUMENTNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ManualInvoice.ManualInvoiceReportInfoQuery_Class dataset_ManualInvoiceReportInfoQuery2 = ParentGroup.rsGroup.GetCurrentRecord<ManualInvoice.ManualInvoiceReportInfoQuery_Class>(0);
                    TOTALPRICE.CalcValue = (dataset_ManualInvoiceReportInfoQuery2 != null ? Globals.ToStringCore(dataset_ManualInvoiceReportInfoQuery2.TotalPrice) : "");
                    PRICEWITHLETTERS.CalcValue = @"";
                    RESMIYAZITARIHI.CalcValue = (dataset_ManualInvoiceReportInfoQuery2 != null ? Globals.ToStringCore(dataset_ManualInvoiceReportInfoQuery2.SendingDate) : "");
                    PATIENTNAMEFOOTER.CalcValue = (dataset_ManualInvoiceReportInfoQuery2 != null ? Globals.ToStringCore(dataset_ManualInvoiceReportInfoQuery2.PatientName) : "");
                    DOCUMENTDATEFOOTER.CalcValue = (dataset_ManualInvoiceReportInfoQuery2 != null ? Globals.ToStringCore(dataset_ManualInvoiceReportInfoQuery2.DocumentDate) : "");
                    TOTAL.CalcValue = @"";
                    PAGE2.CalcValue = @"";
                    HPROTNOFOOTER.CalcValue = (dataset_ManualInvoiceReportInfoQuery2 != null ? Globals.ToStringCore(dataset_ManualInvoiceReportInfoQuery2.SendingNo) : "");
                    TOTALDISCOUNTPRICE.CalcValue = @"0";
                    GENERALTOTALPRICE.CalcValue = (dataset_ManualInvoiceReportInfoQuery2 != null ? Globals.ToStringCore(dataset_ManualInvoiceReportInfoQuery2.TotalPrice) : "");
                    PAGETOTALLABEL.CalcValue = PAGETOTALLABEL.Value;
                    PAGETOTAL.CalcValue = @"";
                    TL1.CalcValue = TL1.Value;
                    TL2.CalcValue = TL2.Value;
                    TL3.CalcValue = TL3.Value;
                    TL4.CalcValue = TL4.Value;
                    PAGENO2.CalcValue = ParentReport.CurrentPageNumber.ToString() + @". SAYFA";
                    RESMIYAZINO.CalcValue = @"";
                    PAYERFOOTER.CalcValue = (dataset_ManualInvoiceReportInfoQuery2 != null ? Globals.ToStringCore(dataset_ManualInvoiceReportInfoQuery2.Payercode) : "") + @" " + (dataset_ManualInvoiceReportInfoQuery2 != null ? Globals.ToStringCore(dataset_ManualInvoiceReportInfoQuery2.Payername) : "") + @" " + (dataset_ManualInvoiceReportInfoQuery2 != null ? Globals.ToStringCore(dataset_ManualInvoiceReportInfoQuery2.Payercity) : "");
                    PRICE.CalcValue = @"";
                    DOCUMENTNOFOOTER.CalcValue = (dataset_ManualInvoiceReportInfoQuery2 != null ? Globals.ToStringCore(dataset_ManualInvoiceReportInfoQuery2.DocumentNo) : "");
                    return new TTReportObject[] { TOTALPRICE,PRICEWITHLETTERS,RESMIYAZITARIHI,PATIENTNAMEFOOTER,DOCUMENTDATEFOOTER,TOTAL,PAGE2,HPROTNOFOOTER,TOTALDISCOUNTPRICE,GENERALTOTALPRICE,PAGETOTALLABEL,PAGETOTAL,TL1,TL2,TL3,TL4,PAGENO2,RESMIYAZINO,PAYERFOOTER,PRICE,DOCUMENTNOFOOTER};
                }

                public override void RunScript()
                {
#region HEAD FOOTER_Script
                    if(((ManualInvoiceReport)ParentReport).RuntimeParameters.ISLASTPAGE == "True")
            {
                this.PRICE.CalcValue = (((ManualInvoiceReport)ParentReport).RuntimeParameters.TURNOVERTOTAL + (((ManualInvoiceReport)ParentReport).RuntimeParameters.TURNOVERTOTAL * ((ManualInvoiceReport)ParentReport).kdv)/100).ToString();
                //this.PRICEWITHLETTERS.Visible = EvetHayirEnum.ehEvet;
                this.TOTALPRICE.Visible = EvetHayirEnum.ehEvet;
                this.TOTALDISCOUNTPRICE.Visible = EvetHayirEnum.ehEvet;
                this.GENERALTOTALPRICE.Visible = EvetHayirEnum.ehEvet;
                this.TL2.Visible = EvetHayirEnum.ehEvet;
                this.TL3.Visible = EvetHayirEnum.ehEvet;
                this.TL4.Visible = EvetHayirEnum.ehEvet;
            }
            else
            {
                this.PAGETOTAL.CalcValue = (((ManualInvoiceReport)ParentReport).RuntimeParameters.PAGETOTAL).ToString();
                ((ManualInvoiceReport)ParentReport).RuntimeParameters.TURNOVERTOTAL = ((ManualInvoiceReport)ParentReport).RuntimeParameters.TURNOVERTOTAL + ((ManualInvoiceReport)ParentReport).RuntimeParameters.PAGETOTAL;
                this.PRICE.CalcValue = (((ManualInvoiceReport)ParentReport).RuntimeParameters.TURNOVERTOTAL).ToString();
                //this.PRICEWITHLETTERS.Visible = EvetHayirEnum.ehHayir;
                this.TOTALPRICE.Visible = EvetHayirEnum.ehHayir;
                this.TOTALDISCOUNTPRICE.Visible = EvetHayirEnum.ehHayir;
                this.GENERALTOTALPRICE.Visible = EvetHayirEnum.ehHayir;
                this.TL2.Visible = EvetHayirEnum.ehHayir;
                this.TL3.Visible = EvetHayirEnum.ehHayir;
                this.TL4.Visible = EvetHayirEnum.ehHayir;
            }
            this.TOTAL.CalcValue = this.PRICE.CalcValue;
            this.PRICEWITHLETTERS.CalcValue = this.PRICE.CalcValue;
#endregion HEAD FOOTER_Script
                }
            }

        }

        public HEADGroup HEAD;

        public partial class TRXDESCGroup : TTReportGroup
        {
            public ManualInvoiceReport MyParentReport
            {
                get { return (ManualInvoiceReport)ParentReport; }
            }

            new public TRXDESCGroupHeader Header()
            {
                return (TRXDESCGroupHeader)_header;
            }

            new public TRXDESCGroupFooter Footer()
            {
                return (TRXDESCGroupFooter)_footer;
            }

            public TTReportField TOTAL { get {return Footer().TOTAL;} }
            public TTReportField KDV { get {return Footer().KDV;} }
            public TTReportField PRICE { get {return Footer().PRICE;} }
            public TTReportField KDVRATE { get {return Footer().KDVRATE;} }
            public TTReportField PAGETOTAL { get {return Footer().PAGETOTAL;} }
            public TRXDESCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TRXDESCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new TRXDESCGroupHeader(this);
                _footer = new TRXDESCGroupFooter(this);

            }

            public partial class TRXDESCGroupHeader : TTReportSection
            {
                public ManualInvoiceReport MyParentReport
                {
                    get { return (ManualInvoiceReport)ParentReport; }
                }
                 
                public TRXDESCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 4;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class TRXDESCGroupFooter : TTReportSection
            {
                public ManualInvoiceReport MyParentReport
                {
                    get { return (ManualInvoiceReport)ParentReport; }
                }
                
                public TTReportField TOTAL;
                public TTReportField KDV;
                public TTReportField PRICE;
                public TTReportField KDVRATE;
                public TTReportField PAGETOTAL; 
                public TRXDESCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 11;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 1, 148, 5, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.TextFormat = @"#,##0.#0";
                    TOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTAL.TextFont.Size = 8;
                    TOTAL.TextFont.CharSet = 162;
                    TOTAL.Value = @"Tutar :";

                    KDV = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 6, 148, 10, false);
                    KDV.Name = "KDV";
                    KDV.TextFormat = @"#,##0.#0";
                    KDV.HorzAlign = HorizontalAlignmentEnum.haRight;
                    KDV.TextFont.Size = 8;
                    KDV.TextFont.CharSet = 162;
                    KDV.Value = @"KDV Oranı(%) :";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 1, 181, 5, false);
                    PRICE.Name = "PRICE";
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"#,##0.#0";
                    PRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICE.TextFont.Size = 8;
                    PRICE.TextFont.CharSet = 162;
                    PRICE.Value = @"{@sumof(PRICE)@}";

                    KDVRATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 6, 181, 10, false);
                    KDVRATE.Name = "KDVRATE";
                    KDVRATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    KDVRATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    KDVRATE.TextFont.Size = 8;
                    KDVRATE.TextFont.CharSet = 162;
                    KDVRATE.Value = @"{#HEAD.KDVRATE#}";

                    PAGETOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 1, 257, 5, false);
                    PAGETOTAL.Name = "PAGETOTAL";
                    PAGETOTAL.Visible = EvetHayirEnum.ehHayir;
                    PAGETOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGETOTAL.TextFormat = @"#,##0.#0";
                    PAGETOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGETOTAL.TextFont.Size = 8;
                    PAGETOTAL.TextFont.CharSet = 162;
                    PAGETOTAL.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ManualInvoice.ManualInvoiceReportInfoQuery_Class dataset_ManualInvoiceReportInfoQuery2 = MyParentReport.HEAD.rsGroup.GetCurrentRecord<ManualInvoice.ManualInvoiceReportInfoQuery_Class>(0);
                    TOTAL.CalcValue = TOTAL.Value;
                    KDV.CalcValue = KDV.Value;
                    PRICE.CalcValue = ParentGroup.FieldSums["PRICE"].Value.ToString();;
                    KDVRATE.CalcValue = (dataset_ManualInvoiceReportInfoQuery2 != null ? Globals.ToStringCore(dataset_ManualInvoiceReportInfoQuery2.KDVRate) : "");
                    PAGETOTAL.CalcValue = @"";
                    return new TTReportObject[] { TOTAL,KDV,PRICE,KDVRATE,PAGETOTAL};
                }

                public override void RunScript()
                {
#region TRXDESC FOOTER_Script
                    this.PAGETOTAL.CalcValue = (((ManualInvoiceReport)ParentReport).RuntimeParameters.PAGETOTAL).ToString();
            ((ManualInvoiceReport)ParentReport).RuntimeParameters.TURNOVERTOTAL = ((ManualInvoiceReport)ParentReport).RuntimeParameters.TURNOVERTOTAL + ((ManualInvoiceReport)ParentReport).RuntimeParameters.PAGETOTAL;
            this.PRICE.CalcValue = (((ManualInvoiceReport)ParentReport).RuntimeParameters.TURNOVERTOTAL).ToString();
          
            if(string.IsNullOrEmpty(this.KDVRATE.CalcValue))
            {
                this.KDVRATE.CalcValue = "0";
                ((ManualInvoiceReport)ParentReport).kdv = 0;
            }
            else
                ((ManualInvoiceReport)ParentReport).kdv = Convert.ToInt16(this.KDVRATE.CalcValue);
#endregion TRXDESC FOOTER_Script
                }
            }

        }

        public TRXDESCGroup TRXDESC;

        public partial class MAINGroup : TTReportGroup
        {
            public ManualInvoiceReport MyParentReport
            {
                get { return (ManualInvoiceReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField PRICE { get {return Body().PRICE;} }
            public TTReportField TRANSACTIONDATE { get {return Body().TRANSACTIONDATE;} }
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
                list[0] = new TTReportNqlData<ManualInvoice.GetProceduresByMedulaInvoice_Class>("GetProceduresByMedulaInvoice", ManualInvoice.GetProceduresByMedulaInvoice((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public ManualInvoiceReport MyParentReport
                {
                    get { return (ManualInvoiceReport)ParentReport; }
                }
                
                public TTReportField ORDERNO;
                public TTReportField DESCRIPTION;
                public TTReportField AMOUNT;
                public TTReportField UNITPRICE;
                public TTReportField PRICE;
                public TTReportField TRANSACTIONDATE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 4;
                    RepeatCount = 0;
                    
                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 0, 20, 4, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ORDERNO.TextFont.Size = 8;
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{@groupcounter@}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 0, 103, 4, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Size = 8;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{#PROCEDURE#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 0, 120, 4, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.TextFont.Size = 8;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 0, 148, 4, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.TextFormat = @"#,##0.#0";
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE.TextFont.Size = 8;
                    UNITPRICE.TextFont.CharSet = 162;
                    UNITPRICE.Value = @"{#UNITPRICE#}";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 0, 181, 4, false);
                    PRICE.Name = "PRICE";
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"#,##0.#0";
                    PRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICE.TextFont.Size = 8;
                    PRICE.TextFont.CharSet = 162;
                    PRICE.Value = @"{#TOTALPRICE#}";

                    TRANSACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 0, 40, 4, false);
                    TRANSACTIONDATE.Name = "TRANSACTIONDATE";
                    TRANSACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TRANSACTIONDATE.TextFormat = @"dd/MM/yyyy";
                    TRANSACTIONDATE.TextFont.Size = 8;
                    TRANSACTIONDATE.TextFont.CharSet = 162;
                    TRANSACTIONDATE.Value = @"{#ACTIONDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ManualInvoice.GetProceduresByMedulaInvoice_Class dataset_GetProceduresByMedulaInvoice = ParentGroup.rsGroup.GetCurrentRecord<ManualInvoice.GetProceduresByMedulaInvoice_Class>(0);
                    ORDERNO.CalcValue = ParentGroup.GroupCounter.ToString();
                    DESCRIPTION.CalcValue = (dataset_GetProceduresByMedulaInvoice != null ? Globals.ToStringCore(dataset_GetProceduresByMedulaInvoice.Procedure) : "");
                    AMOUNT.CalcValue = (dataset_GetProceduresByMedulaInvoice != null ? Globals.ToStringCore(dataset_GetProceduresByMedulaInvoice.Amount) : "");
                    UNITPRICE.CalcValue = (dataset_GetProceduresByMedulaInvoice != null ? Globals.ToStringCore(dataset_GetProceduresByMedulaInvoice.UnitPrice) : "");
                    PRICE.CalcValue = (dataset_GetProceduresByMedulaInvoice != null ? Globals.ToStringCore(dataset_GetProceduresByMedulaInvoice.TotalPrice) : "");
                    TRANSACTIONDATE.CalcValue = (dataset_GetProceduresByMedulaInvoice != null ? Globals.ToStringCore(dataset_GetProceduresByMedulaInvoice.ActionDate) : "");
                    return new TTReportObject[] { ORDERNO,DESCRIPTION,AMOUNT,UNITPRICE,PRICE,TRANSACTIONDATE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    ((ManualInvoiceReport)ParentReport).RuntimeParameters.PAGETOTAL = ((ManualInvoiceReport)ParentReport).RuntimeParameters.PAGETOTAL + Convert.ToDouble(this.PRICE.CalcValue);
#endregion MAIN BODY_Script
                }
            }


            protected override bool RunScript()
            {
#region MAIN_Script
                if (this.MyParentReport.MAIN.IsLastData())
            {
                ((ManualInvoiceReport)ParentReport).RuntimeParameters.ISLASTPAGE = "True";
            }
            else
            {
                
                ((ManualInvoiceReport)ParentReport).RuntimeParameters.ISLASTPAGE = "False";
            }
            
            return true;
#endregion MAIN_Script
            }
        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ManualInvoiceReport()
        {
            HEAD = new HEADGroup(this,"HEAD");
            TRXDESC = new TRXDESCGroup(HEAD,"TRXDESC");
            MAIN = new MAINGroup(TRXDESC,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action guid", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("PAGETOTAL", "0", "SAYFA TOPLAMI", @"", false, false, false, new Guid("53710a7d-9fdd-4078-a98e-228d2cc89909"));
            reportParameter = Parameters.Add("TURNOVERTOTAL", "0", "NAKLİ YEKÜN", @"", false, false, false, new Guid("53710a7d-9fdd-4078-a98e-228d2cc89909"));
            reportParameter = Parameters.Add("ISLASTPAGE", "False", "SON SAYFA", @"", false, false, false, new Guid("cf463436-3c34-4659-a92f-d2d0af106485"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("PAGETOTAL"))
                _runtimeParameters.PAGETOTAL = (double?)TTObjectDefManager.Instance.DataTypes["Double23.8"].ConvertValue(parameters["PAGETOTAL"]);
            if (parameters.ContainsKey("TURNOVERTOTAL"))
                _runtimeParameters.TURNOVERTOTAL = (double?)TTObjectDefManager.Instance.DataTypes["Double23.8"].ConvertValue(parameters["TURNOVERTOTAL"]);
            if (parameters.ContainsKey("ISLASTPAGE"))
                _runtimeParameters.ISLASTPAGE = (string)TTObjectDefManager.Instance.DataTypes["String10"].ConvertValue(parameters["ISLASTPAGE"]);
            Name = "MANUALINVOICEREPORT";
            Caption = "Manuel Kurum Faturası";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 256;
            DontUseWatermark = EvetHayirEnum.ehEvet;
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
            fd.TextFont.Name = "Courier New";
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