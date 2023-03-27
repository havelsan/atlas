
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
    /// Kurum Faturası
    /// </summary>
    public partial class PayerInvoiceReport : TTReport
    {
#region Methods
   Currency PageTotal = 0;
        Currency TurnOverTotal = 0;
        bool IsLastPage = false;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADGroup : TTReportGroup
        {
            public PayerInvoiceReport MyParentReport
            {
                get { return (PayerInvoiceReport)ParentReport; }
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
            public TTReportField PAYER { get {return Header().PAYER;} }
            public TTReportField PATIENTNAME { get {return Header().PATIENTNAME;} }
            public TTReportField HPROTNO { get {return Header().HPROTNO;} }
            public TTReportField DOCUMENTDATE { get {return Header().DOCUMENTDATE;} }
            public TTReportField DOCUMENTNO { get {return Header().DOCUMENTNO;} }
            public TTReportField ICD10 { get {return Header().ICD10;} }
            public TTReportField TAXINFO { get {return Header().TAXINFO;} }
            public TTReportField BANKACCOUNT { get {return Header().BANKACCOUNT;} }
            public TTReportField TAXOFFICE { get {return Header().TAXOFFICE;} }
            public TTReportField TAXNUMBER { get {return Header().TAXNUMBER;} }
            public TTReportField TURNOVERTOTALLABEL { get {return Header().TURNOVERTOTALLABEL;} }
            public TTReportField TURNOVERTOTAL { get {return Header().TURNOVERTOTAL;} }
            public TTReportField HOSPITALIBANNO { get {return Header().HOSPITALIBANNO;} }
            public TTReportField PAGENO { get {return Header().PAGENO;} }
            public TTReportField SIGNATUREBLOCK { get {return Header().SIGNATUREBLOCK;} }
            public TTReportField ICD10CODE { get {return Header().ICD10CODE;} }
            public TTReportField CASHIERNAME { get {return Header().CASHIERNAME;} }
            public TTReportField CASHIERTITLE { get {return Header().CASHIERTITLE;} }
            public TTReportField CASHIERRECID { get {return Header().CASHIERRECID;} }
            public TTReportField INVOICELABEL { get {return Header().INVOICELABEL;} }
            public TTReportField MAPULKE { get {return Header().MAPULKE;} }
            public TTReportField SEVKNO { get {return Header().SEVKNO;} }
            public TTReportField TOTALPRICE { get {return Footer().TOTALPRICE;} }
            public TTReportField PRICEWITHLETTERS { get {return Footer().PRICEWITHLETTERS;} }
            public TTReportField SEVKTARIHIFOOTER { get {return Footer().SEVKTARIHIFOOTER;} }
            public TTReportField PATIENTNAMEFOOTER { get {return Footer().PATIENTNAMEFOOTER;} }
            public TTReportField DOCUMENTDATEFOOTER { get {return Footer().DOCUMENTDATEFOOTER;} }
            public TTReportField TOTAL { get {return Footer().TOTAL;} }
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
            public TTReportField SEVKNOFOOTER { get {return Footer().SEVKNOFOOTER;} }
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
                list[0] = new TTReportNqlData<PayerInvoiceDocument.PayerInvoiceReportInfoQuery_Class>("PayerInvoiceReportInfoQuery", PayerInvoiceDocument.PayerInvoiceReportInfoQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public PayerInvoiceReport MyParentReport
                {
                    get { return (PayerInvoiceReport)ParentReport; }
                }
                
                public TTReportField SEVKTARIHI;
                public TTReportField PAYER;
                public TTReportField PATIENTNAME;
                public TTReportField HPROTNO;
                public TTReportField DOCUMENTDATE;
                public TTReportField DOCUMENTNO;
                public TTReportField ICD10;
                public TTReportField TAXINFO;
                public TTReportField BANKACCOUNT;
                public TTReportField TAXOFFICE;
                public TTReportField TAXNUMBER;
                public TTReportField TURNOVERTOTALLABEL;
                public TTReportField TURNOVERTOTAL;
                public TTReportField HOSPITALIBANNO;
                public TTReportField PAGENO;
                public TTReportField SIGNATUREBLOCK;
                public TTReportField ICD10CODE;
                public TTReportField CASHIERNAME;
                public TTReportField CASHIERTITLE;
                public TTReportField CASHIERRECID;
                public TTReportField INVOICELABEL;
                public TTReportField MAPULKE;
                public TTReportField SEVKNO; 
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
                    SEVKTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEVKTARIHI.TextFormat = @"dd/MM/yyyy";
                    SEVKTARIHI.TextFont.Size = 8;
                    SEVKTARIHI.TextFont.CharSet = 162;
                    SEVKTARIHI.Value = @"";

                    PAYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 47, 168, 55, false);
                    PAYER.Name = "PAYER";
                    PAYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYER.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYER.MultiLine = EvetHayirEnum.ehEvet;
                    PAYER.WordBreak = EvetHayirEnum.ehEvet;
                    PAYER.ExpandTabs = EvetHayirEnum.ehEvet;
                    PAYER.TextFont.Size = 8;
                    PAYER.TextFont.CharSet = 162;
                    PAYER.Value = @"{#PAYERCODE#} {#PAYERNAME#} {#PAYERCITYNAME#}";

                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 38, 168, 43, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PATIENTNAME.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENTNAME.NoClip = EvetHayirEnum.ehEvet;
                    PATIENTNAME.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENTNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    PATIENTNAME.TextFont.Size = 8;
                    PATIENTNAME.TextFont.CharSet = 162;
                    PATIENTNAME.Value = @"";

                    HPROTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 38, 91, 43, false);
                    HPROTNO.Name = "HPROTNO";
                    HPROTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HPROTNO.TextFont.Size = 8;
                    HPROTNO.TextFont.CharSet = 162;
                    HPROTNO.Value = @"";

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

                    ICD10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 64, 202, 68, false);
                    ICD10.Name = "ICD10";
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
                    BANKACCOUNT.FieldType = ReportFieldTypeEnum.ftExpression;
                    BANKACCOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.NoClip = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.ExpandTabs = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.TextFont.Size = 8;
                    BANKACCOUNT.TextFont.CharSet = 162;
                    BANKACCOUNT.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""BANKACCOUNTINFO"", """")
";

                    TAXOFFICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 12, 254, 17, false);
                    TAXOFFICE.Name = "TAXOFFICE";
                    TAXOFFICE.Visible = EvetHayirEnum.ehHayir;
                    TAXOFFICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TAXOFFICE.Value = @"{#PAYERTAXOFFICE#}";

                    TAXNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 18, 254, 23, false);
                    TAXNUMBER.Name = "TAXNUMBER";
                    TAXNUMBER.Visible = EvetHayirEnum.ehHayir;
                    TAXNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    TAXNUMBER.Value = @"{#PAYERTAXNUMBER#}";

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

                    HOSPITALIBANNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 77, 111, 81, false);
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

                    SIGNATUREBLOCK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 69, 202, 81, false);
                    SIGNATUREBLOCK.Name = "SIGNATUREBLOCK";
                    SIGNATUREBLOCK.FieldType = ReportFieldTypeEnum.ftExpression;
                    SIGNATUREBLOCK.MultiLine = EvetHayirEnum.ehEvet;
                    SIGNATUREBLOCK.NoClip = EvetHayirEnum.ehEvet;
                    SIGNATUREBLOCK.WordBreak = EvetHayirEnum.ehEvet;
                    SIGNATUREBLOCK.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIGNATUREBLOCK.TextFont.Size = 8;
                    SIGNATUREBLOCK.TextFont.CharSet = 162;
                    SIGNATUREBLOCK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""PAYERINVOICEREPORTSIGNATUREBLOCK"", """")";

                    ICD10CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 60, 202, 64, false);
                    ICD10CODE.Name = "ICD10CODE";
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

                    INVOICELABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 5, 261, 10, false);
                    INVOICELABEL.Name = "INVOICELABEL";
                    INVOICELABEL.Visible = EvetHayirEnum.ehHayir;
                    INVOICELABEL.TextFont.Size = 16;
                    INVOICELABEL.TextFont.CharSet = 162;
                    INVOICELABEL.Value = @"FATURADIR";

                    MAPULKE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 56, 202, 60, false);
                    MAPULKE.Name = "MAPULKE";
                    MAPULKE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAPULKE.TextFont.Size = 8;
                    MAPULKE.TextFont.CharSet = 162;
                    MAPULKE.Value = @"";

                    SEVKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 24, 254, 29, false);
                    SEVKNO.Name = "SEVKNO";
                    SEVKNO.Visible = EvetHayirEnum.ehHayir;
                    SEVKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEVKNO.TextFont.Size = 8;
                    SEVKNO.TextFont.CharSet = 162;
                    SEVKNO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PayerInvoiceDocument.PayerInvoiceReportInfoQuery_Class dataset_PayerInvoiceReportInfoQuery = ParentGroup.rsGroup.GetCurrentRecord<PayerInvoiceDocument.PayerInvoiceReportInfoQuery_Class>(0);
                    SEVKTARIHI.CalcValue = @"";
                    PAYER.CalcValue = (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.Payercode) : "") + @" " + (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.Payername) : "") + @" " + (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.Payercityname) : "");
                    PATIENTNAME.CalcValue = @"";
                    HPROTNO.CalcValue = @"";
                    DOCUMENTDATE.CalcValue = (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.DocumentDate) : "");
                    DOCUMENTNO.CalcValue = (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.DocumentNo) : "");
                    ICD10.CalcValue = @"";
                    TAXOFFICE.CalcValue = (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.Payertaxoffice) : "");
                    TAXNUMBER.CalcValue = (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.Payertaxnumber) : "");
                    TURNOVERTOTALLABEL.CalcValue = TURNOVERTOTALLABEL.Value;
                    TURNOVERTOTAL.CalcValue = @"";
                    PAGENO.CalcValue = ParentReport.CurrentPageNumber.ToString() + @". SAYFA";
                    ICD10CODE.CalcValue = @"";
                    CASHIERNAME.CalcValue = @"";
                    CASHIERTITLE.CalcValue = @"";
                    CASHIERRECID.CalcValue = @"";
                    INVOICELABEL.CalcValue = INVOICELABEL.Value;
                    MAPULKE.CalcValue = @"";
                    SEVKNO.CalcValue = @"";
                    TAXINFO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("TAXOFFICEINFO", "");
                    BANKACCOUNT.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("BANKACCOUNTINFO", "")
;
                    HOSPITALIBANNO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALIBANNO", "")
;
                    SIGNATUREBLOCK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("PAYERINVOICEREPORTSIGNATUREBLOCK", "");
                    return new TTReportObject[] { SEVKTARIHI,PAYER,PATIENTNAME,HPROTNO,DOCUMENTDATE,DOCUMENTNO,ICD10,TAXOFFICE,TAXNUMBER,TURNOVERTOTALLABEL,TURNOVERTOTAL,PAGENO,ICD10CODE,CASHIERNAME,CASHIERTITLE,CASHIERRECID,INVOICELABEL,MAPULKE,SEVKNO,TAXINFO,BANKACCOUNT,HOSPITALIBANNO,SIGNATUREBLOCK};
                }

                public override void RunScript()
                {
#region HEAD HEADER_Script
                    PayerInvoiceDocument pid = (PayerInvoiceDocument)MyParentReport.ReportObjectContext.GetObject(new Guid(MyParentReport.RuntimeParameters.TTOBJECTID), TTObjectDefManager.Instance.ObjectDefs[typeof(PayerInvoiceDocument).Name], false);
            if (pid != null)
            {
                Episode episode = null;
                foreach (InvoiceCollectionDetail icd in pid.InvoiceCollectionDetails)
                {
                    if (icd.Episode != null)
                    {
                        episode = icd.Episode;
                        break;
                    }
                }

                if (episode != null)
                {
                    this.SEVKNO.CalcValue = episode.DocumentNumber.Equals("0") ? string.Empty : episode.DocumentNumber;
                    this.SEVKTARIHI.CalcValue = episode.DocumentDate.HasValue ? episode.DocumentDate.Value.ToShortDateString() : string.Empty;
                    this.HPROTNO.CalcValue = episode.HospitalProtocolNo.Value.ToString();
                    this.PATIENTNAME.CalcValue = episode.Patient.FullName;
                    if (episode.Patient.UniqueRefNo.HasValue)
                        this.PATIENTNAME.CalcValue += " (" + episode.Patient.UniqueRefNo.Value.ToString() + ")";

                    string diagnosisCodePrimer = "ICD10 KODU     : ";
                    string diagnosisStrPrimer = "ICD10 AÇIKLAMA : ";
                    IList primerDiagnosisList = new List<string>();

                    string diagnosisCodeSeconder = "ICD10 KODU     : ";
                    string diagnosisStrSeconder = "ICD10 AÇIKLAMA : ";
                    IList seconderDiagnosisList = new List<string>();
                    int seconderDiagnosisExists = 0;

                    foreach (DiagnosisGrid dg in episode.Diagnosis)
                    {
                        if (dg.DiagnosisType == DiagnosisTypeEnum.Seconder)
                        {
                            if (!seconderDiagnosisList.Contains(dg.DiagnoseCode))
                            {
                                diagnosisCodeSeconder += dg.DiagnoseCode + " , ";
                                diagnosisStrSeconder += dg.Diagnose + " , ";
                                seconderDiagnosisList.Add(dg.DiagnoseCode);
                                seconderDiagnosisExists++;
                            }
                        }
                        else if (dg.DiagnosisType == DiagnosisTypeEnum.Primer && seconderDiagnosisExists == 0)
                        {
                            if (!primerDiagnosisList.Contains(dg.DiagnoseCode))
                            {
                                diagnosisCodePrimer += dg.DiagnoseCode + " , ";
                                diagnosisStrPrimer += dg.Diagnose + " , ";
                                primerDiagnosisList.Add(dg.DiagnoseCode);
                            }
                        }
                    }

                    if (seconderDiagnosisExists > 0)
                    {
                        this.ICD10CODE.CalcValue = diagnosisCodeSeconder.Substring(0, diagnosisCodeSeconder.Length - 3);
                        this.ICD10.CalcValue = diagnosisStrSeconder.Substring(0, diagnosisStrSeconder.Length - 3);
                    }
                    else if (seconderDiagnosisExists == 0)
                    {
                        this.ICD10CODE.CalcValue = diagnosisCodePrimer.Substring(0, diagnosisCodePrimer.Length - 3);
                        this.ICD10.CalcValue = diagnosisStrPrimer.Substring(0, diagnosisStrPrimer.Length - 3);
                    }
                }

                // Fatura Numarasının Seri No Kısmının yazılması istenmiyor, sadece Sıra No sunun yazılması isteniyor.
                if (!string.IsNullOrEmpty(pid.DocumentNo))
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (Char ch in pid.DocumentNo)
                        if (Char.IsDigit(ch))
                        sb.Append(ch);

                    this.DOCUMENTNO.CalcValue = sb.ToString();
                }

                // Cashier ın bilgilieri gösterilir veya gösterilmez
                if (TTObjectClasses.SystemParameter.GetParameterValue("PAYERINVOICEREPORTSHOWCASHIERINFO", "TRUE") == "TRUE")
                {
                    if (pid.ResUser != null)
                    {
                        this.CASHIERNAME.CalcValue = pid.ResUser.Name;

                        if (pid.ResUser.UserType.HasValue)
                            this.CASHIERTITLE.CalcValue = TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(pid.ResUser.UserType.Value);

                        if (pid.ResUser.EmploymentRecordID != null)
                            this.CASHIERRECID.CalcValue = pid.ResUser.EmploymentRecordID;
                    }
                }

                if (this.PAGENO.CalcValue == "1. SAYFA")
                    MyParentReport.TurnOverTotal = 0;

                MyParentReport.PageTotal = 0;
                this.TURNOVERTOTAL.CalcValue = MyParentReport.TurnOverTotal.ToString();

                if (MyParentReport.TurnOverTotal == 0)
                {
                    this.TURNOVERTOTAL.Visible = EvetHayirEnum.ehHayir;
                    this.TURNOVERTOTALLABEL.Visible = EvetHayirEnum.ehHayir;
                }
                else
                {
                    this.TURNOVERTOTAL.Visible = EvetHayirEnum.ehEvet;
                    this.TURNOVERTOTALLABEL.Visible = EvetHayirEnum.ehEvet;
                }

                // FATURADIR ibaresi sistem parametresinin değerine göre görünür veya görünmez
                //if (TTObjectClasses.SystemParameter.GetParameterValue("SHOWINVOICELABELONPAYERINVOICEREPORT", "FALSE") == "TRUE")
                //{
                //    // Ortez-Protez Faturalarında FATURADIR ibaresi istenmiyor
                //    if (payerInv != null && payerInv.PROCEDUREGROUP != CollectedInvoiceProcedureGroupEnum.OrthesisProsthesis)
                //        this.INVOICELABEL.Visible = EvetHayirEnum.ehEvet;
                //}

                // Misafir XXXXXX Personeller için ülke bilgisi
                //this.MAPULKE.Visible = EvetHayirEnum.ehHayir;
                //ATLAS için kaldırıldı BB
                /*if(episode != null)
                        {
                            if(episode.PatientAdmission != null && episode.PatientAdmission is PA_VisitorMilitary)
                            {
                                if(((PA_VisitorMilitary)episode.PatientAdmission).Country != null)
                                {
                                    this.MAPULKE.CalcValue = "ÜLKE           : " + ((PA_VisitorMilitary)episode.PatientAdmission).Country.Name;
                                    this.MAPULKE.Visible = EvetHayirEnum.ehEvet;
                                }
                            }
                        }*/
            }
#endregion HEAD HEADER_Script
                }
            }
            public partial class HEADGroupFooter : TTReportSection
            {
                public PayerInvoiceReport MyParentReport
                {
                    get { return (PayerInvoiceReport)ParentReport; }
                }
                
                public TTReportField TOTALPRICE;
                public TTReportField PRICEWITHLETTERS;
                public TTReportField SEVKTARIHIFOOTER;
                public TTReportField PATIENTNAMEFOOTER;
                public TTReportField DOCUMENTDATEFOOTER;
                public TTReportField TOTAL;
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
                public TTReportField SEVKNOFOOTER;
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

                    SEVKTARIHIFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 52, 134, 56, false);
                    SEVKTARIHIFOOTER.Name = "SEVKTARIHIFOOTER";
                    SEVKTARIHIFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEVKTARIHIFOOTER.TextFormat = @"dd/MM/yyyy";
                    SEVKTARIHIFOOTER.TextFont.Size = 8;
                    SEVKTARIHIFOOTER.TextFont.CharSet = 162;
                    SEVKTARIHIFOOTER.Value = @"{%HEAD.SEVKTARIHI%}";

                    PATIENTNAMEFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 56, 134, 60, false);
                    PATIENTNAMEFOOTER.Name = "PATIENTNAMEFOOTER";
                    PATIENTNAMEFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAMEFOOTER.TextFont.Size = 8;
                    PATIENTNAMEFOOTER.TextFont.CharSet = 162;
                    PATIENTNAMEFOOTER.Value = @"{%HEAD.PATIENTNAME%}";

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

                    HPROTNOFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 60, 134, 64, false);
                    HPROTNOFOOTER.Name = "HPROTNOFOOTER";
                    HPROTNOFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    HPROTNOFOOTER.TextFont.Size = 8;
                    HPROTNOFOOTER.TextFont.CharSet = 162;
                    HPROTNOFOOTER.Value = @"{%HEAD.HPROTNO%}";

                    TOTALDISCOUNTPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 13, 286, 17, false);
                    TOTALDISCOUNTPRICE.Name = "TOTALDISCOUNTPRICE";
                    TOTALDISCOUNTPRICE.Visible = EvetHayirEnum.ehHayir;
                    TOTALDISCOUNTPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALDISCOUNTPRICE.TextFormat = @"#,##0.#0";
                    TOTALDISCOUNTPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALDISCOUNTPRICE.TextFont.Size = 8;
                    TOTALDISCOUNTPRICE.TextFont.CharSet = 162;
                    TOTALDISCOUNTPRICE.Value = @"{#TOTALDISCOUNTPRICE#}";

                    GENERALTOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 18, 286, 22, false);
                    GENERALTOTALPRICE.Name = "GENERALTOTALPRICE";
                    GENERALTOTALPRICE.Visible = EvetHayirEnum.ehHayir;
                    GENERALTOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    GENERALTOTALPRICE.TextFormat = @"#,##0.#0";
                    GENERALTOTALPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GENERALTOTALPRICE.TextFont.Size = 8;
                    GENERALTOTALPRICE.TextFont.CharSet = 162;
                    GENERALTOTALPRICE.Value = @"{#GENERALTOTALPRICE#}";

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

                    PAGENO2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 69, 184, 74, false);
                    PAGENO2.Name = "PAGENO2";
                    PAGENO2.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENO2.TextFont.Size = 8;
                    PAGENO2.TextFont.CharSet = 162;
                    PAGENO2.Value = @"{@pagenumber@}. SAYFA";

                    SEVKNOFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 48, 134, 52, false);
                    SEVKNOFOOTER.Name = "SEVKNOFOOTER";
                    SEVKNOFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEVKNOFOOTER.TextFont.Size = 8;
                    SEVKNOFOOTER.TextFont.CharSet = 162;
                    SEVKNOFOOTER.Value = @"{%HEAD.SEVKNO%}";

                    PAYERFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 43, 180, 48, false);
                    PAYERFOOTER.Name = "PAYERFOOTER";
                    PAYERFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYERFOOTER.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYERFOOTER.MultiLine = EvetHayirEnum.ehEvet;
                    PAYERFOOTER.WordBreak = EvetHayirEnum.ehEvet;
                    PAYERFOOTER.ExpandTabs = EvetHayirEnum.ehEvet;
                    PAYERFOOTER.TextFont.Size = 8;
                    PAYERFOOTER.TextFont.CharSet = 162;
                    PAYERFOOTER.Value = @"{#PAYERCODE#} {#PAYERNAME#} {#PAYERCITYNAME#}";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 5, 181, 9, false);
                    PRICE.Name = "PRICE";
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"#,##0.#0";
                    PRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICE.TextFont.Size = 8;
                    PRICE.TextFont.CharSet = 162;
                    PRICE.Value = @"";

                    DOCUMENTNOFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 69, 167, 74, false);
                    DOCUMENTNOFOOTER.Name = "DOCUMENTNOFOOTER";
                    DOCUMENTNOFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNOFOOTER.TextFont.Size = 8;
                    DOCUMENTNOFOOTER.TextFont.CharSet = 162;
                    DOCUMENTNOFOOTER.Value = @"{%HEAD.DOCUMENTNO%}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PayerInvoiceDocument.PayerInvoiceReportInfoQuery_Class dataset_PayerInvoiceReportInfoQuery = ParentGroup.rsGroup.GetCurrentRecord<PayerInvoiceDocument.PayerInvoiceReportInfoQuery_Class>(0);
                    TOTALPRICE.CalcValue = (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.TotalPrice) : "");
                    PRICEWITHLETTERS.CalcValue = @"";
                    SEVKTARIHIFOOTER.CalcValue = MyParentReport.HEAD.SEVKTARIHI.FormattedValue;
                    PATIENTNAMEFOOTER.CalcValue = MyParentReport.HEAD.PATIENTNAME.CalcValue;
                    DOCUMENTDATEFOOTER.CalcValue = MyParentReport.HEAD.DOCUMENTDATE.FormattedValue;
                    TOTAL.CalcValue = @"";
                    HPROTNOFOOTER.CalcValue = MyParentReport.HEAD.HPROTNO.CalcValue;
                    TOTALDISCOUNTPRICE.CalcValue = (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.TotalDiscountPrice) : "");
                    GENERALTOTALPRICE.CalcValue = (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.GeneralTotalPrice) : "");
                    PAGETOTALLABEL.CalcValue = PAGETOTALLABEL.Value;
                    PAGETOTAL.CalcValue = @"";
                    TL1.CalcValue = TL1.Value;
                    TL2.CalcValue = TL2.Value;
                    TL3.CalcValue = TL3.Value;
                    TL4.CalcValue = TL4.Value;
                    PAGENO2.CalcValue = ParentReport.CurrentPageNumber.ToString() + @". SAYFA";
                    SEVKNOFOOTER.CalcValue = MyParentReport.HEAD.SEVKNO.CalcValue;
                    PAYERFOOTER.CalcValue = (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.Payercode) : "") + @" " + (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.Payername) : "") + @" " + (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.Payercityname) : "");
                    PRICE.CalcValue = @"";
                    DOCUMENTNOFOOTER.CalcValue = MyParentReport.HEAD.DOCUMENTNO.CalcValue;
                    return new TTReportObject[] { TOTALPRICE,PRICEWITHLETTERS,SEVKTARIHIFOOTER,PATIENTNAMEFOOTER,DOCUMENTDATEFOOTER,TOTAL,HPROTNOFOOTER,TOTALDISCOUNTPRICE,GENERALTOTALPRICE,PAGETOTALLABEL,PAGETOTAL,TL1,TL2,TL3,TL4,PAGENO2,SEVKNOFOOTER,PAYERFOOTER,PRICE,DOCUMENTNOFOOTER};
                }

                public override void RunScript()
                {
#region HEAD FOOTER_Script
                    //            PayerInvoiceDocument pid = (PayerInvoiceDocument)MyParentReport.ReportObjectContext.GetObject(new Guid(MyParentReport.RuntimeParameters.TTOBJECTID), typeof(PayerInvoiceDocument));
            //            if (pid != null)
            //            {
            //                Episode episode = null;
            //                foreach (InvoiceCollectionDetail icd in pid.InvoiceCollectionDetails)
            //                {
            //                    if (icd.Episode != null)
            //                    {
            //                        episode = icd.Episode;
            //                        break;
            //                    }
            //                }

            //                if (episode != null)
            //                {
            //                    this.SEVKNOFOOTER.CalcValue = episode.DocumentNumber.Equals("0") ? string.Empty : episode.DocumentNumber;
            //                    this.SEVKTARIHIFOOTER.CalcValue = episode.DocumentDate.HasValue ? episode.DocumentDate.Value.ToShortDateString() : string.Empty;
            //                    this.HPROTNOFOOTER.CalcValue = episode.HospitalProtocolNo.Value.ToString();
            //                    this.PATIENTNAMEFOOTER.CalcValue = episode.Patient.FullName;
            //                    if (episode.Patient.UniqueRefNo.HasValue)
            //                        this.PATIENTNAMEFOOTER.CalcValue += " (" + episode.Patient.UniqueRefNo.Value.ToString() + ")";
            //                }

            //                //Fatura Numarasının Seri No Kısmının yazılması istenmiyor, sadece Sıra No sunun yazılması isteniyor.
            //                if (!string.IsNullOrEmpty(pid.DocumentNo))
            //                {
            //                    StringBuilder sb = new StringBuilder();

            //                    foreach (Char ch in pid.DocumentNo)
            //                        if (Char.IsDigit(ch))
            //                        sb.Append(ch);

            //                    this.DOCUMENTNOFOOTER.CalcValue = sb.ToString();
            //                }
            //            }

            this.PAGETOTAL.CalcValue = MyParentReport.PageTotal.ToString();
            MyParentReport.TurnOverTotal += MyParentReport.PageTotal;
            this.PRICE.CalcValue = MyParentReport.TurnOverTotal.ToString();
            this.TOTAL.CalcValue = MyParentReport.TurnOverTotal.ToString();
            this.PRICEWITHLETTERS.CalcValue = MyParentReport.TurnOverTotal.ToString();

            if (MyParentReport.IsLastPage)
            {
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
                //this.PRICEWITHLETTERS.Visible = EvetHayirEnum.ehHayir;
                this.TOTALPRICE.Visible = EvetHayirEnum.ehHayir;
                this.TOTALDISCOUNTPRICE.Visible = EvetHayirEnum.ehHayir;
                this.GENERALTOTALPRICE.Visible = EvetHayirEnum.ehHayir;
                this.TL2.Visible = EvetHayirEnum.ehHayir;
                this.TL3.Visible = EvetHayirEnum.ehHayir;
                this.TL4.Visible = EvetHayirEnum.ehHayir;
            }
#endregion HEAD FOOTER_Script
                }
            }

        }

        public HEADGroup HEAD;

        public partial class TRXDESCGroup : TTReportGroup
        {
            public PayerInvoiceReport MyParentReport
            {
                get { return (PayerInvoiceReport)ParentReport; }
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
                list[0] = new TTReportNqlData<PayerInvoiceDocument.PayerInvoiceReportQuery_Class>("PayerInvoiceReportQuery", PayerInvoiceDocument.PayerInvoiceReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public PayerInvoiceReport MyParentReport
                {
                    get { return (PayerInvoiceReport)ParentReport; }
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
                    PayerInvoiceDocument.PayerInvoiceReportQuery_Class dataset_PayerInvoiceReportQuery = ParentGroup.rsGroup.GetCurrentRecord<PayerInvoiceDocument.PayerInvoiceReportQuery_Class>(0);
                    BUTCODE.CalcValue = (dataset_PayerInvoiceReportQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportQuery.Pricinggroupdescription) : "");
                    return new TTReportObject[] { BUTCODE};
                }
            }
            public partial class TRXDESCGroupFooter : TTReportSection
            {
                public PayerInvoiceReport MyParentReport
                {
                    get { return (PayerInvoiceReport)ParentReport; }
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
            public PayerInvoiceReport MyParentReport
            {
                get { return (PayerInvoiceReport)ParentReport; }
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
            public TTReportField PACKAGEOUTREASON { get {return Body().PACKAGEOUTREASON;} }
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

                PayerInvoiceDocument.PayerInvoiceReportQuery_Class dataSet_PayerInvoiceReportQuery = ParentGroup.rsGroup.GetCurrentRecord<PayerInvoiceDocument.PayerInvoiceReportQuery_Class>(0);    
                return new object[] {(dataSet_PayerInvoiceReportQuery==null ? null : dataSet_PayerInvoiceReportQuery.Pricinggroupdescription)};
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
                public PayerInvoiceReport MyParentReport
                {
                    get { return (PayerInvoiceReport)ParentReport; }
                }
                
                public TTReportField ORDERNO;
                public TTReportField DESCRIPTION;
                public TTReportField AMOUNT;
                public TTReportField UNITPRICE;
                public TTReportField PRICE;
                public TTReportField TRANSACTIONDATE;
                public TTReportField TRXNAME;
                public TTReportField TRXEXTERNALCODE;
                public TTReportField PACKAGEOUTREASON;
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
                    PRICE.Value = @"Convert.ToDouble(this.AMOUNT.CalcValue) * Convert.ToDouble(this.UNITPRICE.CalcValue)";

                    TRANSACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 0, 40, 4, false);
                    TRANSACTIONDATE.Name = "TRANSACTIONDATE";
                    TRANSACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TRANSACTIONDATE.TextFont.Size = 8;
                    TRANSACTIONDATE.TextFont.CharSet = 162;
                    TRANSACTIONDATE.Value = @"";

                    TRXNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 0, 260, 5, false);
                    TRXNAME.Name = "TRXNAME";
                    TRXNAME.Visible = EvetHayirEnum.ehHayir;
                    TRXNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    TRXNAME.Value = @"{#TRXDESC.TRXNAME#}";

                    TRXEXTERNALCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 0, 297, 5, false);
                    TRXEXTERNALCODE.Name = "TRXEXTERNALCODE";
                    TRXEXTERNALCODE.Visible = EvetHayirEnum.ehHayir;
                    TRXEXTERNALCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TRXEXTERNALCODE.Value = @"{#TRXDESC.TRXEXTERNALCODE#}";

                    PACKAGEOUTREASON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 0, 353, 5, false);
                    PACKAGEOUTREASON.Name = "PACKAGEOUTREASON";
                    PACKAGEOUTREASON.Visible = EvetHayirEnum.ehHayir;
                    PACKAGEOUTREASON.FieldType = ReportFieldTypeEnum.ftVariable;
                    PACKAGEOUTREASON.ObjectDefName = "PackageOutReasonEnum";
                    PACKAGEOUTREASON.DataMember = "DISPLAYTEXT";
                    PACKAGEOUTREASON.Value = @"{#TRXDESC.PACKAGEOUTREASON#}";

                    DAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 359, 0, 376, 4, false);
                    DAY.Name = "DAY";
                    DAY.Visible = EvetHayirEnum.ehHayir;
                    DAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAY.TextFont.Size = 8;
                    DAY.TextFont.CharSet = 162;
                    DAY.Value = @"{#TRXDESC.DAY#}";

                    MONTH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 378, 0, 395, 4, false);
                    MONTH.Name = "MONTH";
                    MONTH.Visible = EvetHayirEnum.ehHayir;
                    MONTH.FieldType = ReportFieldTypeEnum.ftVariable;
                    MONTH.TextFont.Size = 8;
                    MONTH.TextFont.CharSet = 162;
                    MONTH.Value = @"{#TRXDESC.MONTH#}";

                    YEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 399, 0, 416, 4, false);
                    YEAR.Name = "YEAR";
                    YEAR.Visible = EvetHayirEnum.ehHayir;
                    YEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    YEAR.TextFont.Size = 8;
                    YEAR.TextFont.CharSet = 162;
                    YEAR.Value = @"{#TRXDESC.YEAR#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PayerInvoiceDocument.PayerInvoiceReportQuery_Class dataset_PayerInvoiceReportQuery = MyParentReport.TRXDESC.rsGroup.GetCurrentRecord<PayerInvoiceDocument.PayerInvoiceReportQuery_Class>(0);
                    ORDERNO.CalcValue = ParentGroup.Counter.ToString();
                    DESCRIPTION.CalcValue = @"";
                    AMOUNT.CalcValue = (dataset_PayerInvoiceReportQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportQuery.Amount) : "");
                    UNITPRICE.CalcValue = (dataset_PayerInvoiceReportQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportQuery.UnitPrice) : "");
                    PRICE.CalcValue = @"Convert.ToDouble(this.AMOUNT.CalcValue) * Convert.ToDouble(this.UNITPRICE.CalcValue)";
                    TRANSACTIONDATE.CalcValue = @"";
                    TRXNAME.CalcValue = (dataset_PayerInvoiceReportQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportQuery.Trxname) : "");
                    TRXEXTERNALCODE.CalcValue = (dataset_PayerInvoiceReportQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportQuery.Trxexternalcode) : "");
                    PACKAGEOUTREASON.CalcValue = (dataset_PayerInvoiceReportQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportQuery.PackageOutReason) : "");
                    PACKAGEOUTREASON.PostFieldValueCalculation();
                    DAY.CalcValue = (dataset_PayerInvoiceReportQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportQuery.Day) : "");
                    MONTH.CalcValue = (dataset_PayerInvoiceReportQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportQuery.Month) : "");
                    YEAR.CalcValue = (dataset_PayerInvoiceReportQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportQuery.Year) : "");
                    return new TTReportObject[] { ORDERNO,DESCRIPTION,AMOUNT,UNITPRICE,PRICE,TRANSACTIONDATE,TRXNAME,TRXEXTERNALCODE,PACKAGEOUTREASON,DAY,MONTH,YEAR};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    this.DESCRIPTION.CalcValue = this.TRXEXTERNALCODE.CalcValue + " " + this.TRXNAME.CalcValue ;
            if (this.PACKAGEOUTREASON.CalcValue != "")
                this.DESCRIPTION.CalcValue = this.DESCRIPTION.CalcValue + "(" + this.PACKAGEOUTREASON.CalcValue + ")" ;
            
            if(this.DAY.CalcValue.Length == 1)
                this.DAY.CalcValue = "0" + this.DAY.CalcValue;
            
            if(this.MONTH.CalcValue.Length == 1)
                this.MONTH.CalcValue = "0" + this.MONTH.CalcValue;
            
            this.TRANSACTIONDATE.CalcValue = this.DAY.CalcValue + "." + this.MONTH.CalcValue + "." + this.YEAR.CalcValue;
            this.PRICE.CalcValue = (Convert.ToDecimal(this.AMOUNT.CalcValue) * Convert.ToDecimal(this.UNITPRICE.CalcValue)).ToString();
            MyParentReport.PageTotal += Convert.ToDecimal(this.PRICE.CalcValue);
#endregion MAIN BODY_Script
                }
            }


            protected override bool RunScript()
            {
#region MAIN_Script
                if (this.MyParentReport.TRXDESC.IsLastData())
                MyParentReport.IsLastPage = true;
            else
                MyParentReport.IsLastPage = false;
            
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

        public PayerInvoiceReport()
        {
            HEAD = new HEADGroup(this,"HEAD");
            TRXDESC = new TRXDESCGroup(HEAD,"TRXDESC");
            MAIN = new MAINGroup(TRXDESC,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action guid", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "PAYERINVOICEREPORT";
            Caption = "Kurum Faturası";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 256;
            p_PageWidth = 216;
            p_PageHeight = 305;
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