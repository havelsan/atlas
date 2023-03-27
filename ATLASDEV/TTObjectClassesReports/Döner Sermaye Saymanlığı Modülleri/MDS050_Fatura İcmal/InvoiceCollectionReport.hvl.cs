
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
    /// Toplu Fatura
    /// </summary>
    public partial class InvoiceCollectionReport : TTReport
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
            public InvoiceCollectionReport MyParentReport
            {
                get { return (InvoiceCollectionReport)ParentReport; }
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
            public TTReportField ICDOBJECTID { get {return Header().ICDOBJECTID;} }
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
                list[0] = new TTReportNqlData<InvoiceCollectionDocument.InvoiceCollectionReportInfoQuery_Class>("InvoiceCollectionReportInfoQuery", InvoiceCollectionDocument.InvoiceCollectionReportInfoQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public InvoiceCollectionReport MyParentReport
                {
                    get { return (InvoiceCollectionReport)ParentReport; }
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
                public TTReportField ICDOBJECTID; 
                public HEADGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 98;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    SEVKTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 42, 254, 47, false);
                    SEVKTARIHI.Name = "SEVKTARIHI";
                    SEVKTARIHI.Visible = EvetHayirEnum.ehHayir;
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

                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 56, 254, 61, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.Visible = EvetHayirEnum.ehHayir;
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PATIENTNAME.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENTNAME.NoClip = EvetHayirEnum.ehEvet;
                    PATIENTNAME.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENTNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    PATIENTNAME.TextFont.Size = 8;
                    PATIENTNAME.TextFont.CharSet = 162;
                    PATIENTNAME.Value = @"";

                    HPROTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 49, 254, 54, false);
                    HPROTNO.Name = "HPROTNO";
                    HPROTNO.Visible = EvetHayirEnum.ehHayir;
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

                    MAPULKE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 64, 254, 68, false);
                    MAPULKE.Name = "MAPULKE";
                    MAPULKE.Visible = EvetHayirEnum.ehHayir;
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

                    ICDOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 31, 254, 36, false);
                    ICDOBJECTID.Name = "ICDOBJECTID";
                    ICDOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    ICDOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ICDOBJECTID.TextFont.Name = "Arial Narrow";
                    ICDOBJECTID.Value = @"{#ICDOBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InvoiceCollectionDocument.InvoiceCollectionReportInfoQuery_Class dataset_InvoiceCollectionReportInfoQuery = ParentGroup.rsGroup.GetCurrentRecord<InvoiceCollectionDocument.InvoiceCollectionReportInfoQuery_Class>(0);
                    SEVKTARIHI.CalcValue = @"";
                    PAYER.CalcValue = (dataset_InvoiceCollectionReportInfoQuery != null ? Globals.ToStringCore(dataset_InvoiceCollectionReportInfoQuery.Payercode) : "") + @" " + (dataset_InvoiceCollectionReportInfoQuery != null ? Globals.ToStringCore(dataset_InvoiceCollectionReportInfoQuery.Payername) : "") + @" " + (dataset_InvoiceCollectionReportInfoQuery != null ? Globals.ToStringCore(dataset_InvoiceCollectionReportInfoQuery.Payercityname) : "");
                    PATIENTNAME.CalcValue = @"";
                    HPROTNO.CalcValue = @"";
                    DOCUMENTDATE.CalcValue = (dataset_InvoiceCollectionReportInfoQuery != null ? Globals.ToStringCore(dataset_InvoiceCollectionReportInfoQuery.DocumentDate) : "");
                    DOCUMENTNO.CalcValue = (dataset_InvoiceCollectionReportInfoQuery != null ? Globals.ToStringCore(dataset_InvoiceCollectionReportInfoQuery.DocumentNo) : "");
                    ICD10.CalcValue = @"";
                    TAXOFFICE.CalcValue = (dataset_InvoiceCollectionReportInfoQuery != null ? Globals.ToStringCore(dataset_InvoiceCollectionReportInfoQuery.Payertaxoffice) : "");
                    TAXNUMBER.CalcValue = (dataset_InvoiceCollectionReportInfoQuery != null ? Globals.ToStringCore(dataset_InvoiceCollectionReportInfoQuery.Payertaxnumber) : "");
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
                    ICDOBJECTID.CalcValue = (dataset_InvoiceCollectionReportInfoQuery != null ? Globals.ToStringCore(dataset_InvoiceCollectionReportInfoQuery.Icdobjectid) : "");
                    TAXINFO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("TAXOFFICEINFO", "");
                    BANKACCOUNT.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("BANKACCOUNTINFO", "")
;
                    HOSPITALIBANNO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALIBANNO", "")
;
                    SIGNATUREBLOCK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("PAYERINVOICEREPORTSIGNATUREBLOCK", "");
                    return new TTReportObject[] { SEVKTARIHI,PAYER,PATIENTNAME,HPROTNO,DOCUMENTDATE,DOCUMENTNO,ICD10,TAXOFFICE,TAXNUMBER,TURNOVERTOTALLABEL,TURNOVERTOTAL,PAGENO,ICD10CODE,CASHIERNAME,CASHIERTITLE,CASHIERRECID,INVOICELABEL,MAPULKE,SEVKNO,ICDOBJECTID,TAXINFO,BANKACCOUNT,HOSPITALIBANNO,SIGNATUREBLOCK};
                }

                public override void RunScript()
                {
#region HEAD HEADER_Script
                    InvoiceCollectionDocument icd = (InvoiceCollectionDocument)MyParentReport.ReportObjectContext.GetObject(new Guid(this.ICDOBJECTID.CalcValue), typeof(InvoiceCollectionDocument));
            if (icd != null)
            {
                // Fatura Numarasının Seri No Kısmının yazılması istenmiyor, sadece Sıra No sunun yazılması isteniyor.
                if (!string.IsNullOrEmpty(icd.DocumentNo))
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (Char ch in icd.DocumentNo)
                        if (Char.IsDigit(ch))
                        sb.Append(ch);

                    this.DOCUMENTNO.CalcValue = sb.ToString();
                }

                // Cashier ın bilgilieri gösterilir veya gösterilmez
                if (TTObjectClasses.SystemParameter.GetParameterValue("PAYERINVOICEREPORTSHOWCASHIERINFO", "TRUE") == "TRUE")
                {
                    if (icd.ResUser != null)
                    {
                        this.CASHIERNAME.CalcValue = icd.ResUser.Name;

                        if (icd.ResUser.UserType.HasValue)
                            this.CASHIERTITLE.CalcValue = TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(icd.ResUser.UserType.Value);

                        if (icd.ResUser.EmploymentRecordID != null)
                            this.CASHIERRECID.CalcValue = icd.ResUser.EmploymentRecordID;
                    }
                }
                
                if (this.PAGENO.CalcValue == "1. SAYFA")
                    MyParentReport.RuntimeParameters.TURNOVERTOTAL = 0;

                MyParentReport.RuntimeParameters.PAGETOTAL = 0;
                this.TURNOVERTOTAL.CalcValue = (MyParentReport.RuntimeParameters.TURNOVERTOTAL).ToString();

                if (MyParentReport.RuntimeParameters.TURNOVERTOTAL == (double)0)
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
                
            }
#endregion HEAD HEADER_Script
                }
            }
            public partial class HEADGroupFooter : TTReportSection
            {
                public InvoiceCollectionReport MyParentReport
                {
                    get { return (InvoiceCollectionReport)ParentReport; }
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
                    
                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 258, 8, 287, 12, false);
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

                    SEVKTARIHIFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 37, 269, 41, false);
                    SEVKTARIHIFOOTER.Name = "SEVKTARIHIFOOTER";
                    SEVKTARIHIFOOTER.Visible = EvetHayirEnum.ehHayir;
                    SEVKTARIHIFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEVKTARIHIFOOTER.TextFormat = @"dd/MM/yyyy";
                    SEVKTARIHIFOOTER.TextFont.Size = 8;
                    SEVKTARIHIFOOTER.TextFont.CharSet = 162;
                    SEVKTARIHIFOOTER.Value = @"{%HEAD.SEVKTARIHI%}";

                    PATIENTNAMEFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 41, 269, 45, false);
                    PATIENTNAMEFOOTER.Name = "PATIENTNAMEFOOTER";
                    PATIENTNAMEFOOTER.Visible = EvetHayirEnum.ehHayir;
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

                    HPROTNOFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 45, 269, 49, false);
                    HPROTNOFOOTER.Name = "HPROTNOFOOTER";
                    HPROTNOFOOTER.Visible = EvetHayirEnum.ehHayir;
                    HPROTNOFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    HPROTNOFOOTER.TextFont.Size = 8;
                    HPROTNOFOOTER.TextFont.CharSet = 162;
                    HPROTNOFOOTER.Value = @"{%HEAD.HPROTNO%}";

                    TOTALDISCOUNTPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 258, 13, 287, 17, false);
                    TOTALDISCOUNTPRICE.Name = "TOTALDISCOUNTPRICE";
                    TOTALDISCOUNTPRICE.Visible = EvetHayirEnum.ehHayir;
                    TOTALDISCOUNTPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALDISCOUNTPRICE.TextFormat = @"#,##0.#0";
                    TOTALDISCOUNTPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALDISCOUNTPRICE.TextFont.Size = 8;
                    TOTALDISCOUNTPRICE.TextFont.CharSet = 162;
                    TOTALDISCOUNTPRICE.Value = @"";

                    GENERALTOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 258, 18, 287, 22, false);
                    GENERALTOTALPRICE.Name = "GENERALTOTALPRICE";
                    GENERALTOTALPRICE.Visible = EvetHayirEnum.ehHayir;
                    GENERALTOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    GENERALTOTALPRICE.TextFormat = @"#,##0.#0";
                    GENERALTOTALPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GENERALTOTALPRICE.TextFont.Size = 8;
                    GENERALTOTALPRICE.TextFont.CharSet = 162;
                    GENERALTOTALPRICE.Value = @"";

                    PAGETOTALLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 3, 257, 7, false);
                    PAGETOTALLABEL.Name = "PAGETOTALLABEL";
                    PAGETOTALLABEL.Visible = EvetHayirEnum.ehHayir;
                    PAGETOTALLABEL.TextFont.Size = 8;
                    PAGETOTALLABEL.TextFont.CharSet = 162;
                    PAGETOTALLABEL.Value = @"Sayfa Toplamı:";

                    PAGETOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 258, 3, 287, 7, false);
                    PAGETOTAL.Name = "PAGETOTAL";
                    PAGETOTAL.Visible = EvetHayirEnum.ehHayir;
                    PAGETOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGETOTAL.TextFormat = @"#,##0.#0";
                    PAGETOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGETOTAL.TextFont.Size = 8;
                    PAGETOTAL.TextFont.CharSet = 162;
                    PAGETOTAL.Value = @"";

                    PAGENO2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 69, 184, 74, false);
                    PAGENO2.Name = "PAGENO2";
                    PAGENO2.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENO2.TextFont.Size = 8;
                    PAGENO2.TextFont.CharSet = 162;
                    PAGENO2.Value = @"{@pagenumber@}. SAYFA";

                    SEVKNOFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 33, 269, 37, false);
                    SEVKNOFOOTER.Name = "SEVKNOFOOTER";
                    SEVKNOFOOTER.Visible = EvetHayirEnum.ehHayir;
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
                    InvoiceCollectionDocument.InvoiceCollectionReportInfoQuery_Class dataset_InvoiceCollectionReportInfoQuery = ParentGroup.rsGroup.GetCurrentRecord<InvoiceCollectionDocument.InvoiceCollectionReportInfoQuery_Class>(0);
                    TOTALPRICE.CalcValue = (dataset_InvoiceCollectionReportInfoQuery != null ? Globals.ToStringCore(dataset_InvoiceCollectionReportInfoQuery.TotalPrice) : "");
                    PRICEWITHLETTERS.CalcValue = @"";
                    SEVKTARIHIFOOTER.CalcValue = MyParentReport.HEAD.SEVKTARIHI.FormattedValue;
                    PATIENTNAMEFOOTER.CalcValue = MyParentReport.HEAD.PATIENTNAME.CalcValue;
                    DOCUMENTDATEFOOTER.CalcValue = MyParentReport.HEAD.DOCUMENTDATE.FormattedValue;
                    TOTAL.CalcValue = @"";
                    HPROTNOFOOTER.CalcValue = MyParentReport.HEAD.HPROTNO.CalcValue;
                    TOTALDISCOUNTPRICE.CalcValue = @"";
                    GENERALTOTALPRICE.CalcValue = @"";
                    PAGETOTALLABEL.CalcValue = PAGETOTALLABEL.Value;
                    PAGETOTAL.CalcValue = @"";
                    PAGENO2.CalcValue = ParentReport.CurrentPageNumber.ToString() + @". SAYFA";
                    SEVKNOFOOTER.CalcValue = MyParentReport.HEAD.SEVKNO.CalcValue;
                    PAYERFOOTER.CalcValue = (dataset_InvoiceCollectionReportInfoQuery != null ? Globals.ToStringCore(dataset_InvoiceCollectionReportInfoQuery.Payercode) : "") + @" " + (dataset_InvoiceCollectionReportInfoQuery != null ? Globals.ToStringCore(dataset_InvoiceCollectionReportInfoQuery.Payername) : "") + @" " + (dataset_InvoiceCollectionReportInfoQuery != null ? Globals.ToStringCore(dataset_InvoiceCollectionReportInfoQuery.Payercityname) : "");
                    PRICE.CalcValue = @"";
                    DOCUMENTNOFOOTER.CalcValue = MyParentReport.HEAD.DOCUMENTNO.CalcValue;
                    return new TTReportObject[] { TOTALPRICE,PRICEWITHLETTERS,SEVKTARIHIFOOTER,PATIENTNAMEFOOTER,DOCUMENTDATEFOOTER,TOTAL,HPROTNOFOOTER,TOTALDISCOUNTPRICE,GENERALTOTALPRICE,PAGETOTALLABEL,PAGETOTAL,PAGENO2,SEVKNOFOOTER,PAYERFOOTER,PRICE,DOCUMENTNOFOOTER};
                }

                public override void RunScript()
                {
#region HEAD FOOTER_Script
                    //            InvoiceCollectionDocument icd = (InvoiceCollectionDocument)MyParentReport.ReportObjectContext.GetObject(new Guid(MyParentReport.HEAD.Header().ICDOBJECTID.CalcValue), typeof(InvoiceCollectionDocument));
//            if (icd != null)
//            {
//                //Fatura Numarasının Seri No Kısmının yazılması istenmiyor, sadece Sıra No sunun yazılması isteniyor.
//                if (!string.IsNullOrEmpty(icd.DocumentNo))
//                {
//                    StringBuilder sb = new StringBuilder();
//
//                    foreach (Char ch in icd.DocumentNo)
//                        if (Char.IsDigit(ch))
//                        sb.Append(ch);
//
//                    this.DOCUMENTNOFOOTER.CalcValue = sb.ToString();
//                }
//            }

            this.PAGETOTAL.CalcValue = MyParentReport.RuntimeParameters.PAGETOTAL.ToString();
            MyParentReport.RuntimeParameters.TURNOVERTOTAL = MyParentReport.RuntimeParameters.TURNOVERTOTAL + MyParentReport.RuntimeParameters.PAGETOTAL;
            this.PRICE.CalcValue = MyParentReport.RuntimeParameters.TURNOVERTOTAL.ToString();
            this.TOTAL.CalcValue = MyParentReport.RuntimeParameters.TURNOVERTOTAL.ToString();
            this.PRICEWITHLETTERS.CalcValue = MyParentReport.RuntimeParameters.TURNOVERTOTAL.ToString();

            if (MyParentReport.RuntimeParameters.ISLASTPAGE == "True")
            {
                //this.PRICEWITHLETTERS.Visible = EvetHayirEnum.ehEvet;
                this.TOTALPRICE.Visible = EvetHayirEnum.ehEvet;
                this.TOTALDISCOUNTPRICE.Visible = EvetHayirEnum.ehEvet;
                this.GENERALTOTALPRICE.Visible = EvetHayirEnum.ehEvet;
            }
            else
            {
                //this.PRICEWITHLETTERS.Visible = EvetHayirEnum.ehHayir;
                this.TOTALPRICE.Visible = EvetHayirEnum.ehHayir;
                this.TOTALDISCOUNTPRICE.Visible = EvetHayirEnum.ehHayir;
                this.GENERALTOTALPRICE.Visible = EvetHayirEnum.ehHayir;
            }
#endregion HEAD FOOTER_Script
                }
            }

        }

        public HEADGroup HEAD;

        public partial class TRXDESCGroup : TTReportGroup
        {
            public InvoiceCollectionReport MyParentReport
            {
                get { return (InvoiceCollectionReport)ParentReport; }
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
                list[0] = new TTReportNqlData<InvoiceCollectionDocument.InvoiceCollectionReportQuery_Class>("InvoiceCollectionReportQuery", InvoiceCollectionDocument.InvoiceCollectionReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public InvoiceCollectionReport MyParentReport
                {
                    get { return (InvoiceCollectionReport)ParentReport; }
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
                    InvoiceCollectionDocument.InvoiceCollectionReportQuery_Class dataset_InvoiceCollectionReportQuery = ParentGroup.rsGroup.GetCurrentRecord<InvoiceCollectionDocument.InvoiceCollectionReportQuery_Class>(0);
                    BUTCODE.CalcValue = (dataset_InvoiceCollectionReportQuery != null ? Globals.ToStringCore(dataset_InvoiceCollectionReportQuery.Pricinggroupdescription) : "");
                    return new TTReportObject[] { BUTCODE};
                }
            }
            public partial class TRXDESCGroupFooter : TTReportSection
            {
                public InvoiceCollectionReport MyParentReport
                {
                    get { return (InvoiceCollectionReport)ParentReport; }
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
            public InvoiceCollectionReport MyParentReport
            {
                get { return (InvoiceCollectionReport)ParentReport; }
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

             
            protected override object[] GetGroupByValues()
            {

                InvoiceCollectionDocument.InvoiceCollectionReportQuery_Class dataSet_InvoiceCollectionReportQuery = ParentGroup.rsGroup.GetCurrentRecord<InvoiceCollectionDocument.InvoiceCollectionReportQuery_Class>(0);    
                return new object[] {(dataSet_InvoiceCollectionReportQuery==null ? null : dataSet_InvoiceCollectionReportQuery.Pricinggroupdescription)};
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
                public InvoiceCollectionReport MyParentReport
                {
                    get { return (InvoiceCollectionReport)ParentReport; }
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
                    ORDERNO.Value = @"{@counter@}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 0, 103, 4, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Size = 8;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{#TRXDESC.EXTERNALCODE#} {#TRXDESC.DESCRIPTION#}";

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

                    TRANSACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 0, 246, 4, false);
                    TRANSACTIONDATE.Name = "TRANSACTIONDATE";
                    TRANSACTIONDATE.Visible = EvetHayirEnum.ehHayir;
                    TRANSACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TRANSACTIONDATE.TextFont.Size = 8;
                    TRANSACTIONDATE.TextFont.CharSet = 162;
                    TRANSACTIONDATE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InvoiceCollectionDocument.InvoiceCollectionReportQuery_Class dataset_InvoiceCollectionReportQuery = MyParentReport.TRXDESC.rsGroup.GetCurrentRecord<InvoiceCollectionDocument.InvoiceCollectionReportQuery_Class>(0);
                    ORDERNO.CalcValue = ParentGroup.Counter.ToString();
                    DESCRIPTION.CalcValue = (dataset_InvoiceCollectionReportQuery != null ? Globals.ToStringCore(dataset_InvoiceCollectionReportQuery.ExternalCode) : "") + @" " + (dataset_InvoiceCollectionReportQuery != null ? Globals.ToStringCore(dataset_InvoiceCollectionReportQuery.Description) : "");
                    AMOUNT.CalcValue = (dataset_InvoiceCollectionReportQuery != null ? Globals.ToStringCore(dataset_InvoiceCollectionReportQuery.Amount) : "");
                    UNITPRICE.CalcValue = (dataset_InvoiceCollectionReportQuery != null ? Globals.ToStringCore(dataset_InvoiceCollectionReportQuery.UnitPrice) : "");
                    PRICE.CalcValue = @"Convert.ToDouble(this.AMOUNT.CalcValue) * Convert.ToDouble(this.UNITPRICE.CalcValue)";
                    TRANSACTIONDATE.CalcValue = @"";
                    return new TTReportObject[] { ORDERNO,DESCRIPTION,AMOUNT,UNITPRICE,PRICE,TRANSACTIONDATE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //            if (this.PACKAGEOUTREASON.CalcValue != "")
            //                this.DESCRIPTION.CalcValue = this.DESCRIPTION.CalcValue + "(" + this.PACKAGEOUTREASON.CalcValue + ")" ;

            //            if(this.DAY.CalcValue.Length == 1)
            //                this.DAY.CalcValue = "0" + this.DAY.CalcValue;

            //            if(this.MONTH.CalcValue.Length == 1)
            //                this.MONTH.CalcValue = "0" + this.MONTH.CalcValue;

            //            this.TRANSACTIONDATE.CalcValue = this.DAY.CalcValue + "." + this.MONTH.CalcValue + "." + this.YEAR.CalcValue;

            this.PRICE.CalcValue = (Convert.ToDouble(this.AMOUNT.CalcValue) * Convert.ToDouble(this.UNITPRICE.CalcValue)).ToString() ;
            
            MyParentReport.RuntimeParameters.PAGETOTAL = MyParentReport.RuntimeParameters.PAGETOTAL + Convert.ToDouble(this.PRICE.CalcValue);
#endregion MAIN BODY_Script
                }
            }


            protected override bool RunScript()
            {
#region MAIN_Script
                if (MyParentReport.TRXDESC.IsLastData())
                MyParentReport.RuntimeParameters.ISLASTPAGE = "True";
            else
                MyParentReport.RuntimeParameters.ISLASTPAGE = "False";
            
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

        public InvoiceCollectionReport()
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
            Name = "INVOICECOLLECTIONREPORT";
            Caption = "Toplu Fatura";
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