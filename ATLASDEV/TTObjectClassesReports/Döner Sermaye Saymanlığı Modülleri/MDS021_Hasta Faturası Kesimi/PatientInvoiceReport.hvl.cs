
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
    /// Hasta Faturası
    /// </summary>
    public partial class PatientInvoiceReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public double? PAGETOTAL = (double?)TTObjectDefManager.Instance.DataTypes["Double23.8"].ConvertValue("0");
            public double? TURNOVERTOTAL = (double?)TTObjectDefManager.Instance.DataTypes["Double23.8"].ConvertValue("0");
            public string ISLASTPAGE = (string)TTObjectDefManager.Instance.DataTypes["String10"].ConvertValue("False");
        }

        public partial class HEADGroup : TTReportGroup
        {
            public PatientInvoiceReport MyParentReport
            {
                get { return (PatientInvoiceReport)ParentReport; }
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
            public TTReportField PAGENO { get {return Header().PAGENO;} }
            public TTReportField PATIENT { get {return Header().PATIENT;} }
            public TTReportField DOCUMENTDATE { get {return Header().DOCUMENTDATE;} }
            public TTReportField DOCUMENTNO { get {return Header().DOCUMENTNO;} }
            public TTReportField EPISODEOBJID { get {return Header().EPISODEOBJID;} }
            public TTReportField TURNOVERTOTALLABEL { get {return Header().TURNOVERTOTALLABEL;} }
            public TTReportField TURNOVERTOTAL { get {return Header().TURNOVERTOTAL;} }
            public TTReportField BRANS { get {return Header().BRANS;} }
            public TTReportField PROVIZYONNO { get {return Header().PROVIZYONNO;} }
            public TTReportField HPROTNO { get {return Header().HPROTNO;} }
            public TTReportField PAYER { get {return Header().PAYER;} }
            public TTReportField ICD10 { get {return Header().ICD10;} }
            public TTReportField TAXINFO { get {return Header().TAXINFO;} }
            public TTReportField BANKACCOUNT { get {return Header().BANKACCOUNT;} }
            public TTReportField HOSPITALIBANNO { get {return Header().HOSPITALIBANNO;} }
            public TTReportField ACCOUNTANTNAME { get {return Header().ACCOUNTANTNAME;} }
            public TTReportField ACCOUNTANTTITLE { get {return Header().ACCOUNTANTTITLE;} }
            public TTReportField ACCOUNTANT { get {return Header().ACCOUNTANT;} }
            public TTReportField ICD10CODE { get {return Header().ICD10CODE;} }
            public TTReportField CASHIERNAME { get {return Header().CASHIERNAME;} }
            public TTReportField CASHIERTITLE { get {return Header().CASHIERTITLE;} }
            public TTReportField CASHIERRECID { get {return Header().CASHIERRECID;} }
            public TTReportField PATIENTUNIQUEREFNO { get {return Header().PATIENTUNIQUEREFNO;} }
            public TTReportField CASHIER { get {return Header().CASHIER;} }
            public TTReportField MAPULKE { get {return Header().MAPULKE;} }
            public TTReportField TOTALPRICE { get {return Footer().TOTALPRICE;} }
            public TTReportField PRICEWITHLETTERS { get {return Footer().PRICEWITHLETTERS;} }
            public TTReportField DOCUMENTNOFOOTER { get {return Footer().DOCUMENTNOFOOTER;} }
            public TTReportField DOCUMENTDATEFOOTER { get {return Footer().DOCUMENTDATEFOOTER;} }
            public TTReportField TOTAL { get {return Footer().TOTAL;} }
            public TTReportField PAGENO2 { get {return Footer().PAGENO2;} }
            public TTReportField PAGETOTALLABEL { get {return Footer().PAGETOTALLABEL;} }
            public TTReportField PAGETOTAL { get {return Footer().PAGETOTAL;} }
            public TTReportField RESMIYAZITARIHI { get {return Footer().RESMIYAZITARIHI;} }
            public TTReportField PATIENTNAMEFOOTER { get {return Footer().PATIENTNAMEFOOTER;} }
            public TTReportField HPROTNOFOOTER { get {return Footer().HPROTNOFOOTER;} }
            public TTReportField RESMIYAZINO { get {return Footer().RESMIYAZINO;} }
            public TTReportField PRICE { get {return Footer().PRICE;} }
            public TTReportField PAYER1 { get {return Footer().PAYER1;} }
            public TTReportField PATIENTUNIQUEREFNOFOOTER { get {return Footer().PATIENTUNIQUEREFNOFOOTER;} }
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
                list[0] = new TTReportNqlData<PatientInvoice.PatientInvoiceReportInfoQuery_Class>("PatientInvoiceReportInfoQuery", PatientInvoice.PatientInvoiceReportInfoQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public PatientInvoiceReport MyParentReport
                {
                    get { return (PatientInvoiceReport)ParentReport; }
                }
                
                public TTReportField SEVKTARIHI;
                public TTReportField PAGENO;
                public TTReportField PATIENT;
                public TTReportField DOCUMENTDATE;
                public TTReportField DOCUMENTNO;
                public TTReportField EPISODEOBJID;
                public TTReportField TURNOVERTOTALLABEL;
                public TTReportField TURNOVERTOTAL;
                public TTReportField BRANS;
                public TTReportField PROVIZYONNO;
                public TTReportField HPROTNO;
                public TTReportField PAYER;
                public TTReportField ICD10;
                public TTReportField TAXINFO;
                public TTReportField BANKACCOUNT;
                public TTReportField HOSPITALIBANNO;
                public TTReportField ACCOUNTANTNAME;
                public TTReportField ACCOUNTANTTITLE;
                public TTReportField ACCOUNTANT;
                public TTReportField ICD10CODE;
                public TTReportField CASHIERNAME;
                public TTReportField CASHIERTITLE;
                public TTReportField CASHIERRECID;
                public TTReportField PATIENTUNIQUEREFNO;
                public TTReportField CASHIER;
                public TTReportField MAPULKE; 
                public HEADGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 98;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    SEVKTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 38, 62, 43, false);
                    SEVKTARIHI.Name = "SEVKTARIHI";
                    SEVKTARIHI.Visible = EvetHayirEnum.ehHayir;
                    SEVKTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEVKTARIHI.TextFormat = @"dd/MM/yyyy";
                    SEVKTARIHI.TextFont.Size = 8;
                    SEVKTARIHI.TextFont.CharSet = 162;
                    SEVKTARIHI.Value = @"";

                    PAGENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 8, 184, 13, false);
                    PAGENO.Name = "PAGENO";
                    PAGENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENO.TextFont.Size = 8;
                    PAGENO.TextFont.CharSet = 162;
                    PAGENO.Value = @"{@pagenumber@}. SAYFA";

                    PATIENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 38, 168, 43, false);
                    PATIENT.Name = "PATIENT";
                    PATIENT.Visible = EvetHayirEnum.ehHayir;
                    PATIENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENT.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENT.NoClip = EvetHayirEnum.ehEvet;
                    PATIENT.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENT.ExpandTabs = EvetHayirEnum.ehEvet;
                    PATIENT.TextFont.Size = 8;
                    PATIENT.TextFont.CharSet = 162;
                    PATIENT.Value = @"{#PATIENTNAME#}";

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

                    EPISODEOBJID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 37, 283, 42, false);
                    EPISODEOBJID.Name = "EPISODEOBJID";
                    EPISODEOBJID.Visible = EvetHayirEnum.ehHayir;
                    EPISODEOBJID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEOBJID.Value = @"{#EPISODEOBJID#}";

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

                    BRANS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 29, 283, 34, false);
                    BRANS.Name = "BRANS";
                    BRANS.Visible = EvetHayirEnum.ehHayir;
                    BRANS.FieldType = ReportFieldTypeEnum.ftVariable;
                    BRANS.MultiLine = EvetHayirEnum.ehEvet;
                    BRANS.NoClip = EvetHayirEnum.ehEvet;
                    BRANS.WordBreak = EvetHayirEnum.ehEvet;
                    BRANS.ExpandTabs = EvetHayirEnum.ehEvet;
                    BRANS.TextFont.Size = 8;
                    BRANS.TextFont.CharSet = 162;
                    BRANS.Value = @"{#SPECIALITYCODE#}";

                    PROVIZYONNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 53, 283, 58, false);
                    PROVIZYONNO.Name = "PROVIZYONNO";
                    PROVIZYONNO.Visible = EvetHayirEnum.ehHayir;
                    PROVIZYONNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROVIZYONNO.TextFont.Size = 8;
                    PROVIZYONNO.TextFont.CharSet = 162;
                    PROVIZYONNO.Value = @"";

                    HPROTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 38, 91, 43, false);
                    HPROTNO.Name = "HPROTNO";
                    HPROTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HPROTNO.ObjectDefName = "Episode";
                    HPROTNO.DataMember = "HOSPITALPROTOCOLNO";
                    HPROTNO.TextFont.Size = 8;
                    HPROTNO.TextFont.CharSet = 162;
                    HPROTNO.Value = @"{#EPISODE#}";

                    PAYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 47, 168, 55, false);
                    PAYER.Name = "PAYER";
                    PAYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYER.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYER.MultiLine = EvetHayirEnum.ehEvet;
                    PAYER.WordBreak = EvetHayirEnum.ehEvet;
                    PAYER.ExpandTabs = EvetHayirEnum.ehEvet;
                    PAYER.TextFont.Size = 8;
                    PAYER.TextFont.CharSet = 162;
                    PAYER.Value = @"{#PATIENTNAME#}";

                    ICD10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 64, 202, 68, false);
                    ICD10.Name = "ICD10";
                    ICD10.Visible = EvetHayirEnum.ehHayir;
                    ICD10.FieldType = ReportFieldTypeEnum.ftVariable;
                    ICD10.MultiLine = EvetHayirEnum.ehEvet;
                    ICD10.WordBreak = EvetHayirEnum.ehEvet;
                    ICD10.ExpandTabs = EvetHayirEnum.ehEvet;
                    ICD10.TextFont.Size = 8;
                    ICD10.TextFont.CharSet = 162;
                    ICD10.Value = @"";

                    TAXINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 69, 60, 81, false);
                    TAXINFO.Name = "TAXINFO";
                    TAXINFO.FieldType = ReportFieldTypeEnum.ftExpression;
                    TAXINFO.MultiLine = EvetHayirEnum.ehEvet;
                    TAXINFO.NoClip = EvetHayirEnum.ehEvet;
                    TAXINFO.WordBreak = EvetHayirEnum.ehEvet;
                    TAXINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TAXINFO.TextFont.Size = 8;
                    TAXINFO.TextFont.CharSet = 162;
                    TAXINFO.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""TAXOFFICEINFO"", """")";

                    BANKACCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 69, 111, 77, false);
                    BANKACCOUNT.Name = "BANKACCOUNT";
                    BANKACCOUNT.Visible = EvetHayirEnum.ehHayir;
                    BANKACCOUNT.FieldType = ReportFieldTypeEnum.ftExpression;
                    BANKACCOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.NoClip = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.ExpandTabs = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.TextFont.Size = 8;
                    BANKACCOUNT.TextFont.CharSet = 162;
                    BANKACCOUNT.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""BANKACCOUNTINFO"", """")
";

                    HOSPITALIBANNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 77, 111, 81, false);
                    HOSPITALIBANNO.Name = "HOSPITALIBANNO";
                    HOSPITALIBANNO.Visible = EvetHayirEnum.ehHayir;
                    HOSPITALIBANNO.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALIBANNO.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALIBANNO.NoClip = EvetHayirEnum.ehEvet;
                    HOSPITALIBANNO.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITALIBANNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    HOSPITALIBANNO.TextFont.Size = 8;
                    HOSPITALIBANNO.TextFont.CharSet = 162;
                    HOSPITALIBANNO.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALIBANNO"", """")
";

                    ACCOUNTANTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 69, 202, 73, false);
                    ACCOUNTANTNAME.Name = "ACCOUNTANTNAME";
                    ACCOUNTANTNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTANTNAME.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTANTNAME.NoClip = EvetHayirEnum.ehEvet;
                    ACCOUNTANTNAME.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTANTNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACCOUNTANTNAME.TextFont.Size = 8;
                    ACCOUNTANTNAME.TextFont.CharSet = 162;
                    ACCOUNTANTNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""DONERSERMAYEISLETMEMUDURUADI"", """")";

                    ACCOUNTANTTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 73, 202, 77, false);
                    ACCOUNTANTTITLE.Name = "ACCOUNTANTTITLE";
                    ACCOUNTANTTITLE.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTANTTITLE.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTANTTITLE.NoClip = EvetHayirEnum.ehEvet;
                    ACCOUNTANTTITLE.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTANTTITLE.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACCOUNTANTTITLE.TextFont.Size = 8;
                    ACCOUNTANTTITLE.TextFont.CharSet = 162;
                    ACCOUNTANTTITLE.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""DONERSERMAYEISLETMEMUDURUUNVANI"", """")
";

                    ACCOUNTANT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 77, 202, 81, false);
                    ACCOUNTANT.Name = "ACCOUNTANT";
                    ACCOUNTANT.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.NoClip = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.TextFont.Size = 8;
                    ACCOUNTANT.TextFont.CharSet = 162;
                    ACCOUNTANT.Value = @"Döner Sermaye İşl. M.";

                    ICD10CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 60, 202, 64, false);
                    ICD10CODE.Name = "ICD10CODE";
                    ICD10CODE.Visible = EvetHayirEnum.ehHayir;
                    ICD10CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ICD10CODE.MultiLine = EvetHayirEnum.ehEvet;
                    ICD10CODE.WordBreak = EvetHayirEnum.ehEvet;
                    ICD10CODE.ExpandTabs = EvetHayirEnum.ehEvet;
                    ICD10CODE.TextFont.Size = 8;
                    ICD10CODE.TextFont.CharSet = 162;
                    ICD10CODE.Value = @"";

                    CASHIERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 69, 152, 73, false);
                    CASHIERNAME.Name = "CASHIERNAME";
                    CASHIERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERNAME.TextFont.Size = 8;
                    CASHIERNAME.TextFont.CharSet = 162;
                    CASHIERNAME.Value = @"";

                    CASHIERTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 73, 152, 77, false);
                    CASHIERTITLE.Name = "CASHIERTITLE";
                    CASHIERTITLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERTITLE.TextFont.Size = 8;
                    CASHIERTITLE.TextFont.CharSet = 162;
                    CASHIERTITLE.Value = @"";

                    CASHIERRECID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 77, 152, 81, false);
                    CASHIERRECID.Name = "CASHIERRECID";
                    CASHIERRECID.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERRECID.TextFont.Size = 8;
                    CASHIERRECID.TextFont.CharSet = 162;
                    CASHIERRECID.Value = @"";

                    PATIENTUNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 22, 283, 27, false);
                    PATIENTUNIQUEREFNO.Name = "PATIENTUNIQUEREFNO";
                    PATIENTUNIQUEREFNO.Visible = EvetHayirEnum.ehHayir;
                    PATIENTUNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTUNIQUEREFNO.ObjectDefName = "Patient";
                    PATIENTUNIQUEREFNO.DataMember = "UNIQUEREFNO";
                    PATIENTUNIQUEREFNO.TextFont.Size = 8;
                    PATIENTUNIQUEREFNO.TextFont.CharSet = 162;
                    PATIENTUNIQUEREFNO.Value = @"{#PATIENT#}";

                    CASHIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 72, 283, 77, false);
                    CASHIER.Name = "CASHIER";
                    CASHIER.Visible = EvetHayirEnum.ehHayir;
                    CASHIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIER.TextFont.Size = 8;
                    CASHIER.TextFont.CharSet = 162;
                    CASHIER.Value = @"{#CASHIER#}";

                    MAPULKE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 56, 168, 60, false);
                    MAPULKE.Name = "MAPULKE";
                    MAPULKE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAPULKE.TextFont.Size = 8;
                    MAPULKE.TextFont.CharSet = 162;
                    MAPULKE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PatientInvoice.PatientInvoiceReportInfoQuery_Class dataset_PatientInvoiceReportInfoQuery = ParentGroup.rsGroup.GetCurrentRecord<PatientInvoice.PatientInvoiceReportInfoQuery_Class>(0);
                    SEVKTARIHI.CalcValue = @"";
                    PAGENO.CalcValue = ParentReport.CurrentPageNumber.ToString() + @". SAYFA";
                    PATIENT.CalcValue = (dataset_PatientInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PatientInvoiceReportInfoQuery.PatientName) : "");
                    DOCUMENTDATE.CalcValue = (dataset_PatientInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PatientInvoiceReportInfoQuery.DocumentDate) : "");
                    DOCUMENTNO.CalcValue = (dataset_PatientInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PatientInvoiceReportInfoQuery.DocumentNo) : "");
                    EPISODEOBJID.CalcValue = (dataset_PatientInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PatientInvoiceReportInfoQuery.Episodeobjid) : "");
                    TURNOVERTOTALLABEL.CalcValue = TURNOVERTOTALLABEL.Value;
                    TURNOVERTOTAL.CalcValue = @"";
                    BRANS.CalcValue = (dataset_PatientInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PatientInvoiceReportInfoQuery.Specialitycode) : "");
                    PROVIZYONNO.CalcValue = @"";
                    HPROTNO.CalcValue = (dataset_PatientInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PatientInvoiceReportInfoQuery.Episode) : "");
                    HPROTNO.PostFieldValueCalculation();
                    PAYER.CalcValue = (dataset_PatientInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PatientInvoiceReportInfoQuery.PatientName) : "");
                    ICD10.CalcValue = @"";
                    ACCOUNTANT.CalcValue = ACCOUNTANT.Value;
                    ICD10CODE.CalcValue = @"";
                    CASHIERNAME.CalcValue = @"";
                    CASHIERTITLE.CalcValue = @"";
                    CASHIERRECID.CalcValue = @"";
                    PATIENTUNIQUEREFNO.CalcValue = (dataset_PatientInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PatientInvoiceReportInfoQuery.Patient) : "");
                    PATIENTUNIQUEREFNO.PostFieldValueCalculation();
                    CASHIER.CalcValue = (dataset_PatientInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PatientInvoiceReportInfoQuery.Cashier) : "");
                    MAPULKE.CalcValue = @"";
                    TAXINFO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("TAXOFFICEINFO", "");
                    BANKACCOUNT.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("BANKACCOUNTINFO", "")
;
                    HOSPITALIBANNO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALIBANNO", "")
;
                    ACCOUNTANTNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("DONERSERMAYEISLETMEMUDURUADI", "");
                    ACCOUNTANTTITLE.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("DONERSERMAYEISLETMEMUDURUUNVANI", "")
;
                    return new TTReportObject[] { SEVKTARIHI,PAGENO,PATIENT,DOCUMENTDATE,DOCUMENTNO,EPISODEOBJID,TURNOVERTOTALLABEL,TURNOVERTOTAL,BRANS,PROVIZYONNO,HPROTNO,PAYER,ICD10,ACCOUNTANT,ICD10CODE,CASHIERNAME,CASHIERTITLE,CASHIERRECID,PATIENTUNIQUEREFNO,CASHIER,MAPULKE,TAXINFO,BANKACCOUNT,HOSPITALIBANNO,ACCOUNTANTNAME,ACCOUNTANTTITLE};
                }

                public override void RunScript()
                {
#region HEAD HEADER_Script
                    BindingList<DiagnosisGrid.GetDiagnosisByEpisode_Class> diagnosis = DiagnosisGrid.GetDiagnosisByEpisode(this.EPISODEOBJID.CalcValue.ToString());
            
            string diagnosisCode = "ICD10 KODU     : ";
            string diagnosisStr  = "ICD10 AÇIKLAMA : ";
            string diagnosisList = "";
            
            foreach(DiagnosisGrid.GetDiagnosisByEpisode_Class myDiagnose in diagnosis)
            {
                if(!diagnosisList.Contains(myDiagnose.Diagnose.ToString()))
                {
                    diagnosisCode = diagnosisCode + myDiagnose.Code + " , ";
                    diagnosisStr = diagnosisStr + myDiagnose.Name + " , ";
                    diagnosisList = diagnosisList + myDiagnose.Diagnose.ToString() + " , ";
                }
            }
            
            if (diagnosisStr != "")
            {
                diagnosisCode = diagnosisCode.Remove(diagnosisCode.Length -3,3);
                diagnosisStr = diagnosisStr.Remove(diagnosisStr.Length -3,3);
            }
            
            this.ICD10CODE.CalcValue = diagnosisCode;
            this.ICD10.CalcValue = diagnosisStr ;
            
            if(this.PAGENO.CalcValue == "1. SAYFA")
                ((PatientInvoiceReport)ParentReport).RuntimeParameters.TURNOVERTOTAL = 0;
            
            ((PatientInvoiceReport)ParentReport).RuntimeParameters.PAGETOTAL = 0;
            this.TURNOVERTOTAL.CalcValue = (((PatientInvoiceReport)ParentReport).RuntimeParameters.TURNOVERTOTAL).ToString();
            
            if(((PatientInvoiceReport)ParentReport).RuntimeParameters.TURNOVERTOTAL == (double)0)
            {
                this.TURNOVERTOTAL.Visible = EvetHayirEnum.ehHayir;
                this.TURNOVERTOTALLABEL.Visible = EvetHayirEnum.ehHayir;
            }
            else
            {
                this.TURNOVERTOTAL.Visible = EvetHayirEnum.ehEvet;
                this.TURNOVERTOTALLABEL.Visible = EvetHayirEnum.ehEvet;
            }
            
            string TCKimlikNo = this.PATIENTUNIQUEREFNO.CalcValue;
            if (TCKimlikNo.Trim() != "")
            {
                this.PATIENT.CalcValue += " (" + this.PATIENTUNIQUEREFNO.CalcValue + ")";
                this.PAYER.CalcValue += " (" + this.PATIENTUNIQUEREFNO.CalcValue + ")";
            }
            
            TTObjectContext context = new TTObjectContext(true);
            if(TTObjectClasses.SystemParameter.GetParameterValue("PATIENTINVOICEREPORTSHOWSIGNATUREBLOCK", "TRUE") == "TRUE")
            {
                string cashierObjectID = this.CASHIER.CalcValue;
                ResUser cashier = (ResUser)context.GetObject(new Guid(cashierObjectID),"ResUser");
                
                if (cashier != null)
                {
                    this.CASHIERNAME.CalcValue = cashier.Name;
                    if(cashier.UserType.HasValue)
                        this.CASHIERTITLE.CalcValue = TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(cashier.UserType.Value);
                    if(cashier.EmploymentRecordID != null)
                        this.CASHIERRECID.CalcValue = cashier.EmploymentRecordID;
                }
             
                this.ACCOUNTANTNAME.Visible = EvetHayirEnum.ehEvet;
                this.ACCOUNTANTTITLE.Visible = EvetHayirEnum.ehEvet;
                this.ACCOUNTANT.Visible = EvetHayirEnum.ehEvet;
            }
            else
            {
                this.ACCOUNTANTNAME.Visible = EvetHayirEnum.ehHayir;
                this.ACCOUNTANTTITLE.Visible = EvetHayirEnum.ehHayir;
                this.ACCOUNTANT.Visible = EvetHayirEnum.ehHayir;
            }
            
            // Fatura Numarasının Seri No Kısmının yazılması istenmiyor, sadece Sıra No sunun yazılması isteniyor.
            // Aşağıdaki kısım fatura numarasının sayı olmayan kısmını çıkarıyor.
            if(this.DOCUMENTNO.CalcValue.Trim() != "")
            {
                string numberChar = "0123456789";
                string documentNo = this.DOCUMENTNO.CalcValue;
                string newDocumentNo = "";
                char subChar;
                
                for (int i = 0; i <= documentNo.Length - 1; i++)
                {
                    subChar = documentNo.Substring(i, 1).ToCharArray(0, 1)[0];
                    if (numberChar.IndexOf(subChar) != -1)
                        newDocumentNo += subChar.ToString();
                }
                
                this.DOCUMENTNO.CalcValue = newDocumentNo;
            }
            
            // Misafir XXXXXX Personeller için ülke bilgisi
            this.MAPULKE.Visible = EvetHayirEnum.ehHayir;
            //ATLAS için kapatıldı BB
            /*Episode episode = (Episode)context.GetObject(new Guid(this.EPISODEOBJID.CalcValue.ToString()),"Episode");
            if(episode != null)
            {
                if(episode.PatientAdmission != null && episode.PatientAdmission is PA_VisitorMilitary)
                {
                    if(((PA_VisitorMilitary)episode.PatientAdmission).Country != null)
                    {
                        this.MAPULKE.CalcValue = "ÜLKE : " + ((PA_VisitorMilitary)episode.PatientAdmission).Country.Name;
                        this.MAPULKE.Visible = EvetHayirEnum.ehEvet;
                    }
                }
            }*/
#endregion HEAD HEADER_Script
                }
            }
            public partial class HEADGroupFooter : TTReportSection
            {
                public PatientInvoiceReport MyParentReport
                {
                    get { return (PatientInvoiceReport)ParentReport; }
                }
                
                public TTReportField TOTALPRICE;
                public TTReportField PRICEWITHLETTERS;
                public TTReportField DOCUMENTNOFOOTER;
                public TTReportField DOCUMENTDATEFOOTER;
                public TTReportField TOTAL;
                public TTReportField PAGENO2;
                public TTReportField PAGETOTALLABEL;
                public TTReportField PAGETOTAL;
                public TTReportField RESMIYAZITARIHI;
                public TTReportField PATIENTNAMEFOOTER;
                public TTReportField HPROTNOFOOTER;
                public TTReportField RESMIYAZINO;
                public TTReportField PRICE;
                public TTReportField PAYER1;
                public TTReportField PATIENTUNIQUEREFNOFOOTER; 
                public HEADGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 109;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 274, 19, 297, 23, false);
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

                    DOCUMENTNOFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 69, 168, 74, false);
                    DOCUMENTNOFOOTER.Name = "DOCUMENTNOFOOTER";
                    DOCUMENTNOFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNOFOOTER.TextFont.Size = 8;
                    DOCUMENTNOFOOTER.TextFont.CharSet = 162;
                    DOCUMENTNOFOOTER.Value = @"{#DOCUMENTNO#}";

                    DOCUMENTDATEFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 52, 167, 56, false);
                    DOCUMENTDATEFOOTER.Name = "DOCUMENTDATEFOOTER";
                    DOCUMENTDATEFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTDATEFOOTER.TextFormat = @"dd/MM/yyyy";
                    DOCUMENTDATEFOOTER.TextFont.Size = 8;
                    DOCUMENTDATEFOOTER.TextFont.CharSet = 162;
                    DOCUMENTDATEFOOTER.Value = @"{%HEAD.DOCUMENTDATE%}";

                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 60, 167, 64, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL.TextFormat = @"#,##0.#0";
                    TOTAL.TextFont.Size = 8;
                    TOTAL.TextFont.CharSet = 162;
                    TOTAL.Value = @"";

                    PAGENO2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 69, 186, 74, false);
                    PAGENO2.Name = "PAGENO2";
                    PAGENO2.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENO2.TextFont.Size = 8;
                    PAGENO2.TextFont.CharSet = 162;
                    PAGENO2.Value = @"{@pagenumber@}. SAYFA";

                    PAGETOTALLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 2, 271, 6, false);
                    PAGETOTALLABEL.Name = "PAGETOTALLABEL";
                    PAGETOTALLABEL.Visible = EvetHayirEnum.ehHayir;
                    PAGETOTALLABEL.TextFont.Size = 8;
                    PAGETOTALLABEL.TextFont.CharSet = 162;
                    PAGETOTALLABEL.Value = @"Sayfa Toplamı :";

                    PAGETOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 274, 2, 297, 6, false);
                    PAGETOTAL.Name = "PAGETOTAL";
                    PAGETOTAL.Visible = EvetHayirEnum.ehHayir;
                    PAGETOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGETOTAL.TextFormat = @"#,##0.#0";
                    PAGETOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGETOTAL.TextFont.Size = 8;
                    PAGETOTAL.TextFont.CharSet = 162;
                    PAGETOTAL.Value = @"Sayfa Toplamı :";

                    RESMIYAZITARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 52, 134, 56, false);
                    RESMIYAZITARIHI.Name = "RESMIYAZITARIHI";
                    RESMIYAZITARIHI.Visible = EvetHayirEnum.ehHayir;
                    RESMIYAZITARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESMIYAZITARIHI.TextFormat = @"dd/MM/yyyy";
                    RESMIYAZITARIHI.TextFont.Size = 8;
                    RESMIYAZITARIHI.TextFont.CharSet = 162;
                    RESMIYAZITARIHI.Value = @"{#EVRAKTARIHI#}";

                    PATIENTNAMEFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 60, 134, 64, false);
                    PATIENTNAMEFOOTER.Name = "PATIENTNAMEFOOTER";
                    PATIENTNAMEFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAMEFOOTER.TextFont.Size = 8;
                    PATIENTNAMEFOOTER.TextFont.CharSet = 162;
                    PATIENTNAMEFOOTER.Value = @"{#PATIENTNAME#}";

                    HPROTNOFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 56, 134, 60, false);
                    HPROTNOFOOTER.Name = "HPROTNOFOOTER";
                    HPROTNOFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    HPROTNOFOOTER.TextFont.Size = 8;
                    HPROTNOFOOTER.TextFont.CharSet = 162;
                    HPROTNOFOOTER.Value = @"{%HEAD.HPROTNO%}";

                    RESMIYAZINO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 48, 134, 52, false);
                    RESMIYAZINO.Name = "RESMIYAZINO";
                    RESMIYAZINO.Visible = EvetHayirEnum.ehHayir;
                    RESMIYAZINO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESMIYAZINO.TextFont.Size = 8;
                    RESMIYAZINO.TextFont.CharSet = 162;
                    RESMIYAZINO.Value = @"{#EVRAKSAYISI#}";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 5, 181, 9, false);
                    PRICE.Name = "PRICE";
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"#,##0.#0";
                    PRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICE.TextFont.Size = 8;
                    PRICE.TextFont.CharSet = 162;
                    PRICE.Value = @"";

                    PAYER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 42, 180, 48, false);
                    PAYER1.Name = "PAYER1";
                    PAYER1.Visible = EvetHayirEnum.ehHayir;
                    PAYER1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYER1.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYER1.MultiLine = EvetHayirEnum.ehEvet;
                    PAYER1.WordBreak = EvetHayirEnum.ehEvet;
                    PAYER1.ExpandTabs = EvetHayirEnum.ehEvet;
                    PAYER1.TextFont.Size = 8;
                    PAYER1.TextFont.CharSet = 162;
                    PAYER1.Value = @"";

                    PATIENTUNIQUEREFNOFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 54, 289, 59, false);
                    PATIENTUNIQUEREFNOFOOTER.Name = "PATIENTUNIQUEREFNOFOOTER";
                    PATIENTUNIQUEREFNOFOOTER.Visible = EvetHayirEnum.ehHayir;
                    PATIENTUNIQUEREFNOFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTUNIQUEREFNOFOOTER.ObjectDefName = "Patient";
                    PATIENTUNIQUEREFNOFOOTER.DataMember = "UNIQUEREFNO";
                    PATIENTUNIQUEREFNOFOOTER.TextFont.Size = 8;
                    PATIENTUNIQUEREFNOFOOTER.TextFont.CharSet = 162;
                    PATIENTUNIQUEREFNOFOOTER.Value = @"{#PATIENT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PatientInvoice.PatientInvoiceReportInfoQuery_Class dataset_PatientInvoiceReportInfoQuery = ParentGroup.rsGroup.GetCurrentRecord<PatientInvoice.PatientInvoiceReportInfoQuery_Class>(0);
                    TOTALPRICE.CalcValue = (dataset_PatientInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PatientInvoiceReportInfoQuery.TotalPrice) : "");
                    PRICEWITHLETTERS.CalcValue = @"";
                    DOCUMENTNOFOOTER.CalcValue = (dataset_PatientInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PatientInvoiceReportInfoQuery.DocumentNo) : "");
                    DOCUMENTDATEFOOTER.CalcValue = MyParentReport.HEAD.DOCUMENTDATE.FormattedValue;
                    TOTAL.CalcValue = @"";
                    PAGENO2.CalcValue = ParentReport.CurrentPageNumber.ToString() + @". SAYFA";
                    PAGETOTALLABEL.CalcValue = PAGETOTALLABEL.Value;
                    PAGETOTAL.CalcValue = @"Sayfa Toplamı :";
                    RESMIYAZITARIHI.CalcValue = (dataset_PatientInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PatientInvoiceReportInfoQuery.Evraktarihi) : "");
                    PATIENTNAMEFOOTER.CalcValue = (dataset_PatientInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PatientInvoiceReportInfoQuery.PatientName) : "");
                    HPROTNOFOOTER.CalcValue = MyParentReport.HEAD.HPROTNO.CalcValue;
                    RESMIYAZINO.CalcValue = (dataset_PatientInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PatientInvoiceReportInfoQuery.Evraksayisi) : "");
                    PRICE.CalcValue = @"";
                    PAYER1.CalcValue = @"";
                    PATIENTUNIQUEREFNOFOOTER.CalcValue = (dataset_PatientInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PatientInvoiceReportInfoQuery.Patient) : "");
                    PATIENTUNIQUEREFNOFOOTER.PostFieldValueCalculation();
                    return new TTReportObject[] { TOTALPRICE,PRICEWITHLETTERS,DOCUMENTNOFOOTER,DOCUMENTDATEFOOTER,TOTAL,PAGENO2,PAGETOTALLABEL,PAGETOTAL,RESMIYAZITARIHI,PATIENTNAMEFOOTER,HPROTNOFOOTER,RESMIYAZINO,PRICE,PAYER1,PATIENTUNIQUEREFNOFOOTER};
                }

                public override void RunScript()
                {
#region HEAD FOOTER_Script
                    //                                    this.PAGETOTAL.CalcValue = (((PatientInvoiceReport)ParentReport).RuntimeParameters.PAGETOTAL).ToString();
//            ((PatientInvoiceReport)ParentReport).RuntimeParameters.TURNOVERTOTAL = ((PatientInvoiceReport)ParentReport).RuntimeParameters.TURNOVERTOTAL + ((PatientInvoiceReport)ParentReport).RuntimeParameters.PAGETOTAL;
//            this.PRICE.CalcValue = (((PatientInvoiceReport)ParentReport).RuntimeParameters.TURNOVERTOTAL).ToString();
//            this.TOTAL.CalcValue = (((PatientInvoiceReport)ParentReport).RuntimeParameters.TURNOVERTOTAL).ToString();
//            this.PRICEWITHLETTERS.CalcValue = (((PatientInvoiceReport)ParentReport).RuntimeParameters.TURNOVERTOTAL).ToString();
//            
//            if(((PatientInvoiceReport)ParentReport).RuntimeParameters.ISLASTPAGE == "True")
//            {
//                //this.PRICEWITHLETTERS.Visible = EvetHayirEnum.ehEvet;
//                this.TOTALPRICE.Visible = EvetHayirEnum.ehEvet;
//            }
//            else
//            {
//                //this.PRICEWITHLETTERS.Visible = EvetHayirEnum.ehHayir;
//                this.TOTALPRICE.Visible = EvetHayirEnum.ehHayir;
//            }
//            
//            string TCKimlikNo = this.PATIENTUNIQUEREFNOFOOTER.CalcValue;
//            if (TCKimlikNo.Trim() != "")
//                this.PATIENTNAMEFOOTER.CalcValue += " (" + this.PATIENTUNIQUEREFNOFOOTER.CalcValue + ")";
//            
//            if (this.RESMIYAZINO.CalcValue == "0")
//                this.RESMIYAZINO.CalcValue = "";
//            
//            // Fatura Numarasının Seri No Kısmının yazılması istenmiyor, sadece Sıra No sunun yazılması isteniyor.
//            // Aşağıdaki kısım fatura numarasının sayı olmayan kısmını çıkarıyor.
//            if(this.DOCUMENTNOFOOTER.CalcValue.Trim() != "")
//            {
//                string numberChar = "0123456789";
//                string documentNo = this.DOCUMENTNOFOOTER.CalcValue;
//                string newDocumentNo = "";
//                char subChar;
//                
//                for (int i = 0; i <= documentNo.Length - 1; i++)
//                {
//                    subChar = documentNo.Substring(i, 1).ToCharArray(0, 1)[0];
//                    if (numberChar.IndexOf(subChar) != -1)
//                        newDocumentNo += subChar.ToString();
//                }
//                
//                this.DOCUMENTNOFOOTER.CalcValue = newDocumentNo;
//            }
//
#endregion HEAD FOOTER_Script
                }
            }

        }

        public HEADGroup HEAD;

        public partial class TRXDESCGroup : TTReportGroup
        {
            public PatientInvoiceReport MyParentReport
            {
                get { return (PatientInvoiceReport)ParentReport; }
            }

            new public TRXDESCGroupHeader Header()
            {
                return (TRXDESCGroupHeader)_header;
            }

            new public TRXDESCGroupFooter Footer()
            {
                return (TRXDESCGroupFooter)_footer;
            }

            public TTReportField BUTCODE { get {return Header().BUTCODE;} }
            public TRXDESCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TRXDESCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PatientInvoice.PatientInvoiceReportQuery_Class>("PatientInvoiceReportQuery", PatientInvoice.PatientInvoiceReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new TRXDESCGroupHeader(this);
                _footer = new TRXDESCGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class TRXDESCGroupHeader : TTReportSection
            {
                public PatientInvoiceReport MyParentReport
                {
                    get { return (PatientInvoiceReport)ParentReport; }
                }
                
                public TTReportField BUTCODE; 
                public TRXDESCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 4;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    BUTCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 0, 181, 4, false);
                    BUTCODE.Name = "BUTCODE";
                    BUTCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BUTCODE.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BUTCODE.TextFont.Size = 8;
                    BUTCODE.TextFont.Bold = true;
                    BUTCODE.TextFont.CharSet = 162;
                    BUTCODE.Value = @"{#PRICINGGROUPDESCRIPTION#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PatientInvoice.PatientInvoiceReportQuery_Class dataset_PatientInvoiceReportQuery = ParentGroup.rsGroup.GetCurrentRecord<PatientInvoice.PatientInvoiceReportQuery_Class>(0);
                    BUTCODE.CalcValue = (dataset_PatientInvoiceReportQuery != null ? Globals.ToStringCore(dataset_PatientInvoiceReportQuery.Pricinggroupdescription) : "");
                    return new TTReportObject[] { BUTCODE};
                }
            }
            public partial class TRXDESCGroupFooter : TTReportSection
            {
                public PatientInvoiceReport MyParentReport
                {
                    get { return (PatientInvoiceReport)ParentReport; }
                }
                 
                public TRXDESCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public TRXDESCGroup TRXDESC;

        public partial class MAINGroup : TTReportGroup
        {
            public PatientInvoiceReport MyParentReport
            {
                get { return (PatientInvoiceReport)ParentReport; }
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
            public TTReportField TRXNAME { get {return Body().TRXNAME;} }
            public TTReportField TRXEXTERNALCODE { get {return Body().TRXEXTERNALCODE;} }
            public TTReportField DAY { get {return Body().DAY;} }
            public TTReportField MONTH { get {return Body().MONTH;} }
            public TTReportField YEAR { get {return Body().YEAR;} }
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

                PatientInvoice.PatientInvoiceReportQuery_Class dataSet_PatientInvoiceReportQuery = ParentGroup.rsGroup.GetCurrentRecord<PatientInvoice.PatientInvoiceReportQuery_Class>(0);    
                return new object[] {(dataSet_PatientInvoiceReportQuery==null ? null : dataSet_PatientInvoiceReportQuery.Pricinggroupdescription)};
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
                public PatientInvoiceReport MyParentReport
                {
                    get { return (PatientInvoiceReport)ParentReport; }
                }
                
                public TTReportField ORDERNO;
                public TTReportField DESCRIPTION;
                public TTReportField AMOUNT;
                public TTReportField UNITPRICE;
                public TTReportField PRICE;
                public TTReportField TRANSACTIONDATE;
                public TTReportField TRXNAME;
                public TTReportField TRXEXTERNALCODE;
                public TTReportField DAY;
                public TTReportField MONTH;
                public TTReportField YEAR; 
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
                    ORDERNO.Value = @"{@counter@}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 0, 103, 4, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Size = 8;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 0, 111, 4, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.TextFont.Size = 8;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#TRXDESC.AMOUNT#}";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 0, 143, 4, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.TextFormat = @"#,##0.#0";
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE.TextFont.Size = 8;
                    UNITPRICE.TextFont.CharSet = 162;
                    UNITPRICE.Value = @"{#TRXDESC.UNITPRICE#}";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 0, 181, 4, false);
                    PRICE.Name = "PRICE";
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"#,##0.#0";
                    PRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICE.TextFont.Size = 8;
                    PRICE.TextFont.CharSet = 162;
                    PRICE.Value = @"";

                    TRANSACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 0, 40, 4, false);
                    TRANSACTIONDATE.Name = "TRANSACTIONDATE";
                    TRANSACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TRANSACTIONDATE.TextFont.Size = 8;
                    TRANSACTIONDATE.TextFont.CharSet = 162;
                    TRANSACTIONDATE.Value = @"";

                    TRXNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 0, 260, 4, false);
                    TRXNAME.Name = "TRXNAME";
                    TRXNAME.Visible = EvetHayirEnum.ehHayir;
                    TRXNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    TRXNAME.Value = @"{#TRXDESC.TRXNAME#}";

                    TRXEXTERNALCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 262, 0, 296, 4, false);
                    TRXEXTERNALCODE.Name = "TRXEXTERNALCODE";
                    TRXEXTERNALCODE.Visible = EvetHayirEnum.ehHayir;
                    TRXEXTERNALCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TRXEXTERNALCODE.Value = @"{#TRXDESC.TRXEXTERNALCODE#}";

                    DAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 311, 0, 328, 4, false);
                    DAY.Name = "DAY";
                    DAY.Visible = EvetHayirEnum.ehHayir;
                    DAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAY.TextFont.Size = 8;
                    DAY.TextFont.CharSet = 162;
                    DAY.Value = @"{#TRXDESC.DAY#}";

                    MONTH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 330, 0, 347, 4, false);
                    MONTH.Name = "MONTH";
                    MONTH.Visible = EvetHayirEnum.ehHayir;
                    MONTH.FieldType = ReportFieldTypeEnum.ftVariable;
                    MONTH.TextFont.Size = 8;
                    MONTH.TextFont.CharSet = 162;
                    MONTH.Value = @"{#TRXDESC.MONTH#}";

                    YEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 351, 0, 368, 4, false);
                    YEAR.Name = "YEAR";
                    YEAR.Visible = EvetHayirEnum.ehHayir;
                    YEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    YEAR.TextFont.Size = 8;
                    YEAR.TextFont.CharSet = 162;
                    YEAR.Value = @"{#TRXDESC.YEAR#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PatientInvoice.PatientInvoiceReportQuery_Class dataset_PatientInvoiceReportQuery = MyParentReport.TRXDESC.rsGroup.GetCurrentRecord<PatientInvoice.PatientInvoiceReportQuery_Class>(0);
                    ORDERNO.CalcValue = ParentGroup.Counter.ToString();
                    DESCRIPTION.CalcValue = @"";
                    AMOUNT.CalcValue = (dataset_PatientInvoiceReportQuery != null ? Globals.ToStringCore(dataset_PatientInvoiceReportQuery.Amount) : "");
                    UNITPRICE.CalcValue = (dataset_PatientInvoiceReportQuery != null ? Globals.ToStringCore(dataset_PatientInvoiceReportQuery.UnitPrice) : "");
                    PRICE.CalcValue = @"";
                    TRANSACTIONDATE.CalcValue = @"";
                    TRXNAME.CalcValue = (dataset_PatientInvoiceReportQuery != null ? Globals.ToStringCore(dataset_PatientInvoiceReportQuery.Trxname) : "");
                    TRXEXTERNALCODE.CalcValue = (dataset_PatientInvoiceReportQuery != null ? Globals.ToStringCore(dataset_PatientInvoiceReportQuery.Trxexternalcode) : "");
                    DAY.CalcValue = (dataset_PatientInvoiceReportQuery != null ? Globals.ToStringCore(dataset_PatientInvoiceReportQuery.Day) : "");
                    MONTH.CalcValue = (dataset_PatientInvoiceReportQuery != null ? Globals.ToStringCore(dataset_PatientInvoiceReportQuery.Month) : "");
                    YEAR.CalcValue = (dataset_PatientInvoiceReportQuery != null ? Globals.ToStringCore(dataset_PatientInvoiceReportQuery.Year) : "");
                    return new TTReportObject[] { ORDERNO,DESCRIPTION,AMOUNT,UNITPRICE,PRICE,TRANSACTIONDATE,TRXNAME,TRXEXTERNALCODE,DAY,MONTH,YEAR};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    this.DESCRIPTION.CalcValue = this.TRXEXTERNALCODE.CalcValue + "  " + this.TRXNAME.CalcValue ;
            
            if(this.DAY.CalcValue.Length == 1)
                this.DAY.CalcValue = "0" + this.DAY.CalcValue;
            
            if(this.MONTH.CalcValue.Length == 1)
                this.MONTH.CalcValue = "0" + this.MONTH.CalcValue;
            
            this.TRANSACTIONDATE.CalcValue = this.DAY.CalcValue + "." + this.MONTH.CalcValue + "." + this.YEAR.CalcValue;
            
            this.PRICE.CalcValue = (Convert.ToDouble(this.AMOUNT.CalcValue) * Convert.ToDouble(this.UNITPRICE.CalcValue)).ToString() ;
            ((PatientInvoiceReport)ParentReport).RuntimeParameters.PAGETOTAL = ((PatientInvoiceReport)ParentReport).RuntimeParameters.PAGETOTAL + Convert.ToDouble(this.PRICE.CalcValue);
#endregion MAIN BODY_Script
                }
            }


            protected override bool RunScript()
            {
#region MAIN_Script
                if (this.MyParentReport.TRXDESC.IsLastData())
            {
                ((PatientInvoiceReport)ParentReport).RuntimeParameters.ISLASTPAGE = "True";
            }
            else
            {
                
                ((PatientInvoiceReport)ParentReport).RuntimeParameters.ISLASTPAGE = "False";
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

        public PatientInvoiceReport()
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
            Name = "PATIENTINVOICEREPORT";
            Caption = "Hasta Faturası";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 256;
            p_PageWidth = 216;
            p_PageHeight = 309;
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