
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
    public partial class CollectedInvoiceReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public CollectedInvoiceReport MyParentReport
            {
                get { return (CollectedInvoiceReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField FATURATARIHI { get {return Header().FATURATARIHI;} }
            public TTReportField KURUMADI { get {return Header().KURUMADI;} }
            public TTReportField BANKAHESABI { get {return Header().BANKAHESABI;} }
            public TTReportField VERGIDAIRENO { get {return Header().VERGIDAIRENO;} }
            public TTReportField ACCOUNTANTNAME { get {return Header().ACCOUNTANTNAME;} }
            public TTReportField ACCOUNTANTTITLE { get {return Header().ACCOUNTANTTITLE;} }
            public TTReportField ACCOUNTANT { get {return Header().ACCOUNTANT;} }
            public TTReportField HOSPITALIBANNO { get {return Header().HOSPITALIBANNO;} }
            public TTReportField CASHIER { get {return Header().CASHIER;} }
            public TTReportField CASHIERNAME { get {return Header().CASHIERNAME;} }
            public TTReportField CASHIERTITLE { get {return Header().CASHIERTITLE;} }
            public TTReportField CASHIERRECID { get {return Header().CASHIERRECID;} }
            public TTReportField TOPLAMTUTAR { get {return Footer().TOPLAMTUTAR;} }
            public TTReportField TOPLAMTUTAR1 { get {return Footer().TOPLAMTUTAR1;} }
            public TTReportField YAZIYLA { get {return Footer().YAZIYLA;} }
            public TTReportField KURUMADI1 { get {return Footer().KURUMADI1;} }
            public TTReportField FATURATARIHI1 { get {return Footer().FATURATARIHI1;} }
            public TTReportField TOPLAMTUTAR2 { get {return Footer().TOPLAMTUTAR2;} }
            public TTReportField TOPLAMTUTAR3 { get {return Footer().TOPLAMTUTAR3;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<CollectedInvoice.CollectedInvoiceReportQuery_Class>("CollectedInvoiceReportQuery", CollectedInvoice.CollectedInvoiceReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public CollectedInvoiceReport MyParentReport
                {
                    get { return (CollectedInvoiceReport)ParentReport; }
                }
                
                public TTReportField FATURATARIHI;
                public TTReportField KURUMADI;
                public TTReportField BANKAHESABI;
                public TTReportField VERGIDAIRENO;
                public TTReportField ACCOUNTANTNAME;
                public TTReportField ACCOUNTANTTITLE;
                public TTReportField ACCOUNTANT;
                public TTReportField HOSPITALIBANNO;
                public TTReportField CASHIER;
                public TTReportField CASHIERNAME;
                public TTReportField CASHIERTITLE;
                public TTReportField CASHIERRECID; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 88;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    FATURATARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 16, 166, 20, false);
                    FATURATARIHI.Name = "FATURATARIHI";
                    FATURATARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATURATARIHI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    FATURATARIHI.TextFormat = @"Short Date";
                    FATURATARIHI.TextFont.Name = "Arial";
                    FATURATARIHI.TextFont.Size = 9;
                    FATURATARIHI.TextFont.CharSet = 162;
                    FATURATARIHI.Value = @"{#DOCUMENTDATE#}";

                    KURUMADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 38, 166, 46, false);
                    KURUMADI.Name = "KURUMADI";
                    KURUMADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMADI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    KURUMADI.MultiLine = EvetHayirEnum.ehEvet;
                    KURUMADI.NoClip = EvetHayirEnum.ehEvet;
                    KURUMADI.WordBreak = EvetHayirEnum.ehEvet;
                    KURUMADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    KURUMADI.TextFont.Name = "Arial";
                    KURUMADI.TextFont.Size = 9;
                    KURUMADI.TextFont.CharSet = 162;
                    KURUMADI.Value = @"{#PAYERCODE#} {#PAYERNAME#} {#PAYERCITY#}";

                    BANKAHESABI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 56, 111, 64, false);
                    BANKAHESABI.Name = "BANKAHESABI";
                    BANKAHESABI.FieldType = ReportFieldTypeEnum.ftExpression;
                    BANKAHESABI.MultiLine = EvetHayirEnum.ehEvet;
                    BANKAHESABI.NoClip = EvetHayirEnum.ehEvet;
                    BANKAHESABI.WordBreak = EvetHayirEnum.ehEvet;
                    BANKAHESABI.ExpandTabs = EvetHayirEnum.ehEvet;
                    BANKAHESABI.TextFont.Name = "Arial";
                    BANKAHESABI.TextFont.Size = 9;
                    BANKAHESABI.TextFont.CharSet = 162;
                    BANKAHESABI.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""BANKACCOUNTINFO"", """")
";

                    VERGIDAIRENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 56, 60, 68, false);
                    VERGIDAIRENO.Name = "VERGIDAIRENO";
                    VERGIDAIRENO.FieldType = ReportFieldTypeEnum.ftExpression;
                    VERGIDAIRENO.MultiLine = EvetHayirEnum.ehEvet;
                    VERGIDAIRENO.NoClip = EvetHayirEnum.ehEvet;
                    VERGIDAIRENO.WordBreak = EvetHayirEnum.ehEvet;
                    VERGIDAIRENO.ExpandTabs = EvetHayirEnum.ehEvet;
                    VERGIDAIRENO.TextFont.Name = "Arial";
                    VERGIDAIRENO.TextFont.Size = 9;
                    VERGIDAIRENO.TextFont.CharSet = 162;
                    VERGIDAIRENO.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""TAXOFFICEINFO"", """")
";

                    ACCOUNTANTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 56, 200, 60, false);
                    ACCOUNTANTNAME.Name = "ACCOUNTANTNAME";
                    ACCOUNTANTNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTANTNAME.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTANTNAME.NoClip = EvetHayirEnum.ehEvet;
                    ACCOUNTANTNAME.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTANTNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACCOUNTANTNAME.TextFont.Name = "Arial";
                    ACCOUNTANTNAME.TextFont.Size = 9;
                    ACCOUNTANTNAME.TextFont.CharSet = 162;
                    ACCOUNTANTNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""DONERSERMAYEISLETMEMUDURUADI"", """")";

                    ACCOUNTANTTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 60, 200, 64, false);
                    ACCOUNTANTTITLE.Name = "ACCOUNTANTTITLE";
                    ACCOUNTANTTITLE.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTANTTITLE.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTANTTITLE.NoClip = EvetHayirEnum.ehEvet;
                    ACCOUNTANTTITLE.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTANTTITLE.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACCOUNTANTTITLE.TextFont.Name = "Arial";
                    ACCOUNTANTTITLE.TextFont.Size = 9;
                    ACCOUNTANTTITLE.TextFont.CharSet = 162;
                    ACCOUNTANTTITLE.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""DONERSERMAYEISLETMEMUDURUUNVANI"", """")
";

                    ACCOUNTANT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 64, 200, 68, false);
                    ACCOUNTANT.Name = "ACCOUNTANT";
                    ACCOUNTANT.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.NoClip = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.TextFont.Name = "Arial";
                    ACCOUNTANT.TextFont.Size = 9;
                    ACCOUNTANT.TextFont.CharSet = 162;
                    ACCOUNTANT.Value = @"Döner Sermaye İşl. Md.";

                    HOSPITALIBANNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 64, 111, 68, false);
                    HOSPITALIBANNO.Name = "HOSPITALIBANNO";
                    HOSPITALIBANNO.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALIBANNO.VertAlign = VerticalAlignmentEnum.vaBottom;
                    HOSPITALIBANNO.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALIBANNO.NoClip = EvetHayirEnum.ehEvet;
                    HOSPITALIBANNO.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITALIBANNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    HOSPITALIBANNO.TextFont.Name = "Arial";
                    HOSPITALIBANNO.TextFont.Size = 9;
                    HOSPITALIBANNO.TextFont.CharSet = 162;
                    HOSPITALIBANNO.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALIBANNO"", """")
";

                    CASHIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 46, 258, 51, false);
                    CASHIER.Name = "CASHIER";
                    CASHIER.Visible = EvetHayirEnum.ehHayir;
                    CASHIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIER.TextFont.Name = "Courier New";
                    CASHIER.TextFont.Size = 8;
                    CASHIER.TextFont.CharSet = 162;
                    CASHIER.Value = @"{#CASHIER#}";

                    CASHIERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 56, 152, 60, false);
                    CASHIERNAME.Name = "CASHIERNAME";
                    CASHIERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERNAME.TextFont.Name = "Arial";
                    CASHIERNAME.TextFont.Size = 9;
                    CASHIERNAME.TextFont.CharSet = 162;
                    CASHIERNAME.Value = @"";

                    CASHIERTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 60, 152, 64, false);
                    CASHIERTITLE.Name = "CASHIERTITLE";
                    CASHIERTITLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERTITLE.TextFont.Name = "Arial";
                    CASHIERTITLE.TextFont.Size = 9;
                    CASHIERTITLE.TextFont.CharSet = 162;
                    CASHIERTITLE.Value = @"";

                    CASHIERRECID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 64, 152, 68, false);
                    CASHIERRECID.Name = "CASHIERRECID";
                    CASHIERRECID.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERRECID.TextFont.Name = "Arial";
                    CASHIERRECID.TextFont.Size = 9;
                    CASHIERRECID.TextFont.CharSet = 162;
                    CASHIERRECID.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CollectedInvoice.CollectedInvoiceReportQuery_Class dataset_CollectedInvoiceReportQuery = ParentGroup.rsGroup.GetCurrentRecord<CollectedInvoice.CollectedInvoiceReportQuery_Class>(0);
                    FATURATARIHI.CalcValue = (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.DocumentDate) : "");
                    KURUMADI.CalcValue = (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.Payercode) : "") + @" " + (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.Payername) : "") + @" " + (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.Payercity) : "");
                    ACCOUNTANT.CalcValue = ACCOUNTANT.Value;
                    CASHIER.CalcValue = (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.Cashier) : "");
                    CASHIERNAME.CalcValue = @"";
                    CASHIERTITLE.CalcValue = @"";
                    CASHIERRECID.CalcValue = @"";
                    BANKAHESABI.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("BANKACCOUNTINFO", "")
;
                    VERGIDAIRENO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("TAXOFFICEINFO", "")
;
                    ACCOUNTANTNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("DONERSERMAYEISLETMEMUDURUADI", "");
                    ACCOUNTANTTITLE.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("DONERSERMAYEISLETMEMUDURUUNVANI", "")
;
                    HOSPITALIBANNO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALIBANNO", "")
;
                    return new TTReportObject[] { FATURATARIHI,KURUMADI,ACCOUNTANT,CASHIER,CASHIERNAME,CASHIERTITLE,CASHIERRECID,BANKAHESABI,VERGIDAIRENO,ACCOUNTANTNAME,ACCOUNTANTTITLE,HOSPITALIBANNO};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
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
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public CollectedInvoiceReport MyParentReport
                {
                    get { return (CollectedInvoiceReport)ParentReport; }
                }
                
                public TTReportField TOPLAMTUTAR;
                public TTReportField TOPLAMTUTAR1;
                public TTReportField YAZIYLA;
                public TTReportField KURUMADI1;
                public TTReportField FATURATARIHI1;
                public TTReportField TOPLAMTUTAR2;
                public TTReportField TOPLAMTUTAR3; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 115;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOPLAMTUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 2, 178, 6, false);
                    TOPLAMTUTAR.Name = "TOPLAMTUTAR";
                    TOPLAMTUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMTUTAR.CaseFormat = CaseFormatEnum.fcUpperCase;
                    TOPLAMTUTAR.TextFormat = @"#,##0.#0";
                    TOPLAMTUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAMTUTAR.MultiLine = EvetHayirEnum.ehEvet;
                    TOPLAMTUTAR.NoClip = EvetHayirEnum.ehEvet;
                    TOPLAMTUTAR.WordBreak = EvetHayirEnum.ehEvet;
                    TOPLAMTUTAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    TOPLAMTUTAR.TextFont.Name = "Arial";
                    TOPLAMTUTAR.TextFont.Size = 9;
                    TOPLAMTUTAR.TextFont.CharSet = 162;
                    TOPLAMTUTAR.Value = @"{#TOTALPRICE#}";

                    TOPLAMTUTAR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 225, 4, 251, 8, false);
                    TOPLAMTUTAR1.Name = "TOPLAMTUTAR1";
                    TOPLAMTUTAR1.Visible = EvetHayirEnum.ehHayir;
                    TOPLAMTUTAR1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMTUTAR1.CaseFormat = CaseFormatEnum.fcUpperCase;
                    TOPLAMTUTAR1.MultiLine = EvetHayirEnum.ehEvet;
                    TOPLAMTUTAR1.NoClip = EvetHayirEnum.ehEvet;
                    TOPLAMTUTAR1.WordBreak = EvetHayirEnum.ehEvet;
                    TOPLAMTUTAR1.ExpandTabs = EvetHayirEnum.ehEvet;
                    TOPLAMTUTAR1.TextFont.Name = "Arial";
                    TOPLAMTUTAR1.TextFont.Size = 9;
                    TOPLAMTUTAR1.TextFont.CharSet = 162;
                    TOPLAMTUTAR1.Value = @"{#TOTALPRICE#}";

                    YAZIYLA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 11, 177, 15, false);
                    YAZIYLA.Name = "YAZIYLA";
                    YAZIYLA.FieldType = ReportFieldTypeEnum.ftVariable;
                    YAZIYLA.CaseFormat = CaseFormatEnum.fcUpperCase;
                    YAZIYLA.TextFormat = @"NUMBERTEXT( TL , KR)";
                    YAZIYLA.TextFont.Name = "Arial";
                    YAZIYLA.TextFont.Size = 9;
                    YAZIYLA.TextFont.CharSet = 162;
                    YAZIYLA.Value = @"{%TOPLAMTUTAR1%}";

                    KURUMADI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 40, 183, 44, false);
                    KURUMADI1.Name = "KURUMADI1";
                    KURUMADI1.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMADI1.CaseFormat = CaseFormatEnum.fcUpperCase;
                    KURUMADI1.MultiLine = EvetHayirEnum.ehEvet;
                    KURUMADI1.NoClip = EvetHayirEnum.ehEvet;
                    KURUMADI1.WordBreak = EvetHayirEnum.ehEvet;
                    KURUMADI1.ExpandTabs = EvetHayirEnum.ehEvet;
                    KURUMADI1.TextFont.Name = "Arial";
                    KURUMADI1.TextFont.Size = 9;
                    KURUMADI1.TextFont.CharSet = 162;
                    KURUMADI1.Value = @"{#PAYERCODE#} {#PAYERNAME#} {#PAYERCITY#}";

                    FATURATARIHI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 49, 168, 53, false);
                    FATURATARIHI1.Name = "FATURATARIHI1";
                    FATURATARIHI1.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATURATARIHI1.CaseFormat = CaseFormatEnum.fcUpperCase;
                    FATURATARIHI1.TextFormat = @"Short Date";
                    FATURATARIHI1.TextFont.Name = "Arial";
                    FATURATARIHI1.TextFont.Size = 9;
                    FATURATARIHI1.TextFont.CharSet = 162;
                    FATURATARIHI1.Value = @"{#DOCUMENTDATE#}";

                    TOPLAMTUTAR2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 57, 168, 61, false);
                    TOPLAMTUTAR2.Name = "TOPLAMTUTAR2";
                    TOPLAMTUTAR2.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMTUTAR2.CaseFormat = CaseFormatEnum.fcUpperCase;
                    TOPLAMTUTAR2.TextFormat = @"#,##0.#0";
                    TOPLAMTUTAR2.MultiLine = EvetHayirEnum.ehEvet;
                    TOPLAMTUTAR2.NoClip = EvetHayirEnum.ehEvet;
                    TOPLAMTUTAR2.WordBreak = EvetHayirEnum.ehEvet;
                    TOPLAMTUTAR2.ExpandTabs = EvetHayirEnum.ehEvet;
                    TOPLAMTUTAR2.TextFont.Name = "Arial";
                    TOPLAMTUTAR2.TextFont.Size = 9;
                    TOPLAMTUTAR2.TextFont.CharSet = 162;
                    TOPLAMTUTAR2.Value = @"{#TOTALPRICE#}";

                    TOPLAMTUTAR3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 225, 46, 249, 50, false);
                    TOPLAMTUTAR3.Name = "TOPLAMTUTAR3";
                    TOPLAMTUTAR3.Visible = EvetHayirEnum.ehHayir;
                    TOPLAMTUTAR3.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMTUTAR3.TextFont.Name = "Arial";
                    TOPLAMTUTAR3.TextFont.Size = 9;
                    TOPLAMTUTAR3.TextFont.CharSet = 162;
                    TOPLAMTUTAR3.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CollectedInvoice.CollectedInvoiceReportQuery_Class dataset_CollectedInvoiceReportQuery = ParentGroup.rsGroup.GetCurrentRecord<CollectedInvoice.CollectedInvoiceReportQuery_Class>(0);
                    TOPLAMTUTAR.CalcValue = (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.TotalPrice) : "");
                    TOPLAMTUTAR1.CalcValue = (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.TotalPrice) : "");
                    YAZIYLA.CalcValue = MyParentReport.PARTA.TOPLAMTUTAR1.CalcValue;
                    KURUMADI1.CalcValue = (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.Payercode) : "") + @" " + (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.Payername) : "") + @" " + (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.Payercity) : "");
                    FATURATARIHI1.CalcValue = (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.DocumentDate) : "");
                    TOPLAMTUTAR2.CalcValue = (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.TotalPrice) : "");
                    TOPLAMTUTAR3.CalcValue = @"";
                    return new TTReportObject[] { TOPLAMTUTAR,TOPLAMTUTAR1,YAZIYLA,KURUMADI1,FATURATARIHI1,TOPLAMTUTAR2,TOPLAMTUTAR3};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    //this.TOPLAMTUTAR3.CalcValue = this.TOPLAMTUTAR2.FormattedValue + "  TL";
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public CollectedInvoiceReport MyParentReport
            {
                get { return (CollectedInvoiceReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField ACIKLAMA { get {return Body().ACIKLAMA;} }
            public TTReportField ADET { get {return Body().ADET;} }
            public TTReportField TUTAR { get {return Body().TUTAR;} }
            public TTReportField TOPLAMTUTAR { get {return Body().TOPLAMTUTAR;} }
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
                public CollectedInvoiceReport MyParentReport
                {
                    get { return (CollectedInvoiceReport)ParentReport; }
                }
                
                public TTReportField SIRANO;
                public TTReportField ACIKLAMA;
                public TTReportField ADET;
                public TTReportField TUTAR;
                public TTReportField TOPLAMTUTAR; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 70;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 3, 22, 7, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.CaseFormat = CaseFormatEnum.fcUpperCase;
                    SIRANO.TextFont.Name = "Arial";
                    SIRANO.TextFont.Size = 9;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"1";

                    ACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 3, 106, 29, false);
                    ACIKLAMA.Name = "ACIKLAMA";
                    ACIKLAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMA.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ACIKLAMA.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA.NoClip = EvetHayirEnum.ehEvet;
                    ACIKLAMA.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACIKLAMA.TextFont.Name = "Arial";
                    ACIKLAMA.TextFont.Size = 9;
                    ACIKLAMA.TextFont.CharSet = 162;
                    ACIKLAMA.Value = @"{#PARTA.DESCRIPTION#}";

                    ADET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 3, 116, 7, false);
                    ADET.Name = "ADET";
                    ADET.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADET.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ADET.MultiLine = EvetHayirEnum.ehEvet;
                    ADET.NoClip = EvetHayirEnum.ehEvet;
                    ADET.WordBreak = EvetHayirEnum.ehEvet;
                    ADET.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADET.TextFont.Name = "Arial";
                    ADET.TextFont.Size = 9;
                    ADET.TextFont.CharSet = 162;
                    ADET.Value = @"{#PARTA.AMOUNT#}";

                    TUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 3, 141, 7, false);
                    TUTAR.Name = "TUTAR";
                    TUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TUTAR.CaseFormat = CaseFormatEnum.fcUpperCase;
                    TUTAR.TextFormat = @"#,##0.#0";
                    TUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR.TextFont.Name = "Arial";
                    TUTAR.TextFont.Size = 9;
                    TUTAR.TextFont.CharSet = 162;
                    TUTAR.Value = @"{#PARTA.TOTALPRICE#}";

                    TOPLAMTUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 3, 178, 7, false);
                    TOPLAMTUTAR.Name = "TOPLAMTUTAR";
                    TOPLAMTUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMTUTAR.CaseFormat = CaseFormatEnum.fcUpperCase;
                    TOPLAMTUTAR.TextFormat = @"#,##0.#0";
                    TOPLAMTUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAMTUTAR.MultiLine = EvetHayirEnum.ehEvet;
                    TOPLAMTUTAR.NoClip = EvetHayirEnum.ehEvet;
                    TOPLAMTUTAR.WordBreak = EvetHayirEnum.ehEvet;
                    TOPLAMTUTAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    TOPLAMTUTAR.TextFont.Name = "Arial";
                    TOPLAMTUTAR.TextFont.Size = 9;
                    TOPLAMTUTAR.TextFont.CharSet = 162;
                    TOPLAMTUTAR.Value = @"{#PARTA.TOTALPRICE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CollectedInvoice.CollectedInvoiceReportQuery_Class dataset_CollectedInvoiceReportQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<CollectedInvoice.CollectedInvoiceReportQuery_Class>(0);
                    SIRANO.CalcValue = SIRANO.Value;
                    ACIKLAMA.CalcValue = (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.Description) : "");
                    ADET.CalcValue = (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.Amount) : "");
                    TUTAR.CalcValue = (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.TotalPrice) : "");
                    TOPLAMTUTAR.CalcValue = (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.TotalPrice) : "");
                    return new TTReportObject[] { SIRANO,ACIKLAMA,ADET,TUTAR,TOPLAMTUTAR};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public CollectedInvoiceReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action Object ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "COLLECTEDINVOICEREPORT";
            Caption = "Toplu Fatura";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 40;
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