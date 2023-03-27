
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
    /// Toplu Fatura Önyazı Raporu (Alt Vaka)
    /// </summary>
    public partial class CollectedInvoicePreReport_SE : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public CollectedInvoicePreReport_SE MyParentReport
            {
                get { return (CollectedInvoicePreReport_SE)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField XXXXXXADI { get {return Body().XXXXXXADI;} }
            public TTReportField BASLIK13 { get {return Body().BASLIK13;} }
            public TTReportField BASLIK131 { get {return Body().BASLIK131;} }
            public TTReportField BASLIK132 { get {return Body().BASLIK132;} }
            public TTReportField BASLIK1231 { get {return Body().BASLIK1231;} }
            public TTReportField BASLIK133 { get {return Body().BASLIK133;} }
            public TTReportField DOSENO { get {return Body().DOSENO;} }
            public TTReportField FATURATARIHI { get {return Body().FATURATARIHI;} }
            public TTReportField BODYTEXT1 { get {return Body().BODYTEXT1;} }
            public TTReportField BASLIK11 { get {return Body().BASLIK11;} }
            public TTReportField BASLIK111 { get {return Body().BASLIK111;} }
            public TTReportField BIRIMADI { get {return Body().BIRIMADI;} }
            public TTReportField ACCOUNTANTNAME { get {return Body().ACCOUNTANTNAME;} }
            public TTReportField ACCOUNTANTTITLE { get {return Body().ACCOUNTANTTITLE;} }
            public TTReportField ACCOUNTANT1 { get {return Body().ACCOUNTANT1;} }
            public TTReportField BODYTEXT2 { get {return Body().BODYTEXT2;} }
            public TTReportField STARTDATE { get {return Body().STARTDATE;} }
            public TTReportField ENDDATE { get {return Body().ENDDATE;} }
            public TTReportField BANKACCOUNT { get {return Body().BANKACCOUNT;} }
            public TTReportField IBANNO { get {return Body().IBANNO;} }
            public TTReportField BIRIMILI { get {return Body().BIRIMILI;} }
            public TTReportField PAYEROBJID { get {return Body().PAYEROBJID;} }
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
                list[0] = new TTReportNqlData<CollectedInvoice.CollectedInvoiceReportQuery_Class>("CollectedInvoiceReportQuery", CollectedInvoice.CollectedInvoiceReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public CollectedInvoicePreReport_SE MyParentReport
                {
                    get { return (CollectedInvoicePreReport_SE)ParentReport; }
                }
                
                public TTReportField XXXXXXADI;
                public TTReportField BASLIK13;
                public TTReportField BASLIK131;
                public TTReportField BASLIK132;
                public TTReportField BASLIK1231;
                public TTReportField BASLIK133;
                public TTReportField DOSENO;
                public TTReportField FATURATARIHI;
                public TTReportField BODYTEXT1;
                public TTReportField BASLIK11;
                public TTReportField BASLIK111;
                public TTReportField BIRIMADI;
                public TTReportField ACCOUNTANTNAME;
                public TTReportField ACCOUNTANTTITLE;
                public TTReportField ACCOUNTANT1;
                public TTReportField BODYTEXT2;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField BANKACCOUNT;
                public TTReportField IBANNO;
                public TTReportField BIRIMILI;
                public TTReportField PAYEROBJID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 118;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    XXXXXXADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 12, 197, 35, false);
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
                    XXXXXXADI.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")
";

                    BASLIK13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 41, 22, 45, false);
                    BASLIK13.Name = "BASLIK13";
                    BASLIK13.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK13.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK13.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK13.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK13.TextFont.Name = "Arial";
                    BASLIK13.TextFont.Bold = true;
                    BASLIK13.TextFont.CharSet = 162;
                    BASLIK13.Value = @"DÖSE";

                    BASLIK131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 46, 22, 50, false);
                    BASLIK131.Name = "BASLIK131";
                    BASLIK131.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK131.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK131.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK131.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK131.TextFont.Name = "Arial";
                    BASLIK131.TextFont.Bold = true;
                    BASLIK131.TextFont.CharSet = 162;
                    BASLIK131.Value = @"KONU";

                    BASLIK132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 41, 24, 45, false);
                    BASLIK132.Name = "BASLIK132";
                    BASLIK132.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK132.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK132.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK132.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK132.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK132.TextFont.Name = "Arial";
                    BASLIK132.TextFont.Bold = true;
                    BASLIK132.TextFont.CharSet = 162;
                    BASLIK132.Value = @":";

                    BASLIK1231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 46, 24, 50, false);
                    BASLIK1231.Name = "BASLIK1231";
                    BASLIK1231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK1231.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK1231.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK1231.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK1231.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK1231.TextFont.Name = "Arial";
                    BASLIK1231.TextFont.Bold = true;
                    BASLIK1231.TextFont.CharSet = 162;
                    BASLIK1231.Value = @":";

                    BASLIK133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 46, 148, 50, false);
                    BASLIK133.Name = "BASLIK133";
                    BASLIK133.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK133.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK133.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK133.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK133.TextFont.Name = "Arial";
                    BASLIK133.TextFont.CharSet = 162;
                    BASLIK133.Value = @"Tedavi Giderleri";

                    DOSENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 41, 148, 45, false);
                    DOSENO.Name = "DOSENO";
                    DOSENO.FieldType = ReportFieldTypeEnum.ftExpression;
                    DOSENO.MultiLine = EvetHayirEnum.ehEvet;
                    DOSENO.NoClip = EvetHayirEnum.ehEvet;
                    DOSENO.WordBreak = EvetHayirEnum.ehEvet;
                    DOSENO.ExpandTabs = EvetHayirEnum.ehEvet;
                    DOSENO.TextFont.Name = "Arial";
                    DOSENO.TextFont.CharSet = 162;
                    DOSENO.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALDOSENO"", """")";

                    FATURATARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 41, 197, 45, false);
                    FATURATARIHI.Name = "FATURATARIHI";
                    FATURATARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATURATARIHI.TextFormat = @"Short Date";
                    FATURATARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    FATURATARIHI.NoClip = EvetHayirEnum.ehEvet;
                    FATURATARIHI.WordBreak = EvetHayirEnum.ehEvet;
                    FATURATARIHI.ExpandTabs = EvetHayirEnum.ehEvet;
                    FATURATARIHI.TextFont.Name = "Arial";
                    FATURATARIHI.TextFont.Bold = true;
                    FATURATARIHI.TextFont.CharSet = 162;
                    FATURATARIHI.Value = @"{#DOCUMENTDATE#}";

                    BODYTEXT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 79, 197, 90, false);
                    BODYTEXT1.Name = "BODYTEXT1";
                    BODYTEXT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    BODYTEXT1.MultiLine = EvetHayirEnum.ehEvet;
                    BODYTEXT1.NoClip = EvetHayirEnum.ehEvet;
                    BODYTEXT1.WordBreak = EvetHayirEnum.ehEvet;
                    BODYTEXT1.ExpandTabs = EvetHayirEnum.ehEvet;
                    BODYTEXT1.TextFont.Name = "Arial";
                    BODYTEXT1.TextFont.Size = 9;
                    BODYTEXT1.TextFont.CharSet = 162;
                    BODYTEXT1.Value = @"";

                    BASLIK11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 57, 197, 61, false);
                    BASLIK11.Name = "BASLIK11";
                    BASLIK11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK11.TextFont.Name = "Arial";
                    BASLIK11.TextFont.Bold = true;
                    BASLIK11.TextFont.CharSet = 162;
                    BASLIK11.Value = @"T.C.";

                    BASLIK111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 62, 197, 66, false);
                    BASLIK111.Name = "BASLIK111";
                    BASLIK111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK111.TextFont.Name = "Arial";
                    BASLIK111.TextFont.Bold = true;
                    BASLIK111.TextFont.CharSet = 162;
                    BASLIK111.Value = @"SOSYAL GÜVENLİK KURUM BAŞKANLIĞI";

                    BIRIMADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 67, 197, 71, false);
                    BIRIMADI.Name = "BIRIMADI";
                    BIRIMADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIMADI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIMADI.TextFont.Name = "Arial";
                    BIRIMADI.TextFont.Bold = true;
                    BIRIMADI.TextFont.CharSet = 162;
                    BIRIMADI.Value = @"{#PAYERNAME#}";

                    ACCOUNTANTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 105, 197, 109, false);
                    ACCOUNTANTNAME.Name = "ACCOUNTANTNAME";
                    ACCOUNTANTNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTANTNAME.TextFont.Name = "Arial";
                    ACCOUNTANTNAME.TextFont.Size = 9;
                    ACCOUNTANTNAME.TextFont.CharSet = 162;
                    ACCOUNTANTNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""DONERSERMAYEISLETMEMUDURUADI"", """")
";

                    ACCOUNTANTTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 109, 197, 113, false);
                    ACCOUNTANTTITLE.Name = "ACCOUNTANTTITLE";
                    ACCOUNTANTTITLE.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTANTTITLE.TextFont.Name = "Arial";
                    ACCOUNTANTTITLE.TextFont.Size = 9;
                    ACCOUNTANTTITLE.TextFont.CharSet = 162;
                    ACCOUNTANTTITLE.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""DONERSERMAYEISLETMEMUDURUUNVANI"", """")
";

                    ACCOUNTANT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 113, 197, 117, false);
                    ACCOUNTANT1.Name = "ACCOUNTANT1";
                    ACCOUNTANT1.TextFont.Name = "Arial";
                    ACCOUNTANT1.TextFont.Size = 9;
                    ACCOUNTANT1.TextFont.CharSet = 162;
                    ACCOUNTANT1.Value = @"Döner Sermaye İşletme Müdürü";

                    BODYTEXT2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 91, 197, 102, false);
                    BODYTEXT2.Name = "BODYTEXT2";
                    BODYTEXT2.FieldType = ReportFieldTypeEnum.ftVariable;
                    BODYTEXT2.MultiLine = EvetHayirEnum.ehEvet;
                    BODYTEXT2.WordBreak = EvetHayirEnum.ehEvet;
                    BODYTEXT2.TextFont.Name = "Arial";
                    BODYTEXT2.TextFont.Size = 9;
                    BODYTEXT2.TextFont.CharSet = 162;
                    BODYTEXT2.Value = @"";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 44, 238, 48, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.CaseFormat = CaseFormatEnum.fcUpperCase;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.TextFont.Name = "Arial";
                    STARTDATE.TextFont.Size = 9;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{#STARTDATE#}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 49, 238, 53, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.TextFont.Name = "Arial";
                    ENDDATE.TextFont.Size = 9;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{#ENDDATE#}";

                    BANKACCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 55, 239, 60, false);
                    BANKACCOUNT.Name = "BANKACCOUNT";
                    BANKACCOUNT.Visible = EvetHayirEnum.ehHayir;
                    BANKACCOUNT.FieldType = ReportFieldTypeEnum.ftExpression;
                    BANKACCOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.NoClip = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.ExpandTabs = EvetHayirEnum.ehEvet;
                    BANKACCOUNT.TextFont.Name = "Arial";
                    BANKACCOUNT.TextFont.CharSet = 162;
                    BANKACCOUNT.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""BANKACCOUNTINFO"", """")
";

                    IBANNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 62, 238, 66, false);
                    IBANNO.Name = "IBANNO";
                    IBANNO.Visible = EvetHayirEnum.ehHayir;
                    IBANNO.FieldType = ReportFieldTypeEnum.ftExpression;
                    IBANNO.MultiLine = EvetHayirEnum.ehEvet;
                    IBANNO.NoClip = EvetHayirEnum.ehEvet;
                    IBANNO.WordBreak = EvetHayirEnum.ehEvet;
                    IBANNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    IBANNO.TextFont.Name = "Arial";
                    IBANNO.TextFont.CharSet = 162;
                    IBANNO.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALIBANNO"", """")
";

                    BIRIMILI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 72, 197, 76, false);
                    BIRIMILI.Name = "BIRIMILI";
                    BIRIMILI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIMILI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    BIRIMILI.TextFont.Name = "Arial";
                    BIRIMILI.TextFont.Bold = true;
                    BIRIMILI.TextFont.CharSet = 162;
                    BIRIMILI.Value = @"{#PAYERCITY#}";

                    PAYEROBJID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 68, 241, 72, false);
                    PAYEROBJID.Name = "PAYEROBJID";
                    PAYEROBJID.Visible = EvetHayirEnum.ehHayir;
                    PAYEROBJID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYEROBJID.TextFormat = @"Short Date";
                    PAYEROBJID.MultiLine = EvetHayirEnum.ehEvet;
                    PAYEROBJID.NoClip = EvetHayirEnum.ehEvet;
                    PAYEROBJID.WordBreak = EvetHayirEnum.ehEvet;
                    PAYEROBJID.ExpandTabs = EvetHayirEnum.ehEvet;
                    PAYEROBJID.TextFont.Name = "Arial";
                    PAYEROBJID.TextFont.CharSet = 162;
                    PAYEROBJID.Value = @"{#PAYEROBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CollectedInvoice.CollectedInvoiceReportQuery_Class dataset_CollectedInvoiceReportQuery = ParentGroup.rsGroup.GetCurrentRecord<CollectedInvoice.CollectedInvoiceReportQuery_Class>(0);
                    BASLIK13.CalcValue = BASLIK13.Value;
                    BASLIK131.CalcValue = BASLIK131.Value;
                    BASLIK132.CalcValue = BASLIK132.Value;
                    BASLIK1231.CalcValue = BASLIK1231.Value;
                    BASLIK133.CalcValue = BASLIK133.Value;
                    FATURATARIHI.CalcValue = (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.DocumentDate) : "");
                    BODYTEXT1.CalcValue = @"";
                    BASLIK11.CalcValue = BASLIK11.Value;
                    BASLIK111.CalcValue = BASLIK111.Value;
                    BIRIMADI.CalcValue = (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.Payername) : "");
                    ACCOUNTANT1.CalcValue = ACCOUNTANT1.Value;
                    BODYTEXT2.CalcValue = @"";
                    STARTDATE.CalcValue = (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.STARTDATE) : "");
                    ENDDATE.CalcValue = (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.ENDDATE) : "");
                    BIRIMILI.CalcValue = (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.Payercity) : "");
                    PAYEROBJID.CalcValue = (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.Payerobjectid) : "");
                    XXXXXXADI.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "")
;
                    DOSENO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALDOSENO", "");
                    ACCOUNTANTNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("DONERSERMAYEISLETMEMUDURUADI", "")
;
                    ACCOUNTANTTITLE.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("DONERSERMAYEISLETMEMUDURUUNVANI", "")
;
                    BANKACCOUNT.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("BANKACCOUNTINFO", "")
;
                    IBANNO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALIBANNO", "")
;
                    return new TTReportObject[] { BASLIK13,BASLIK131,BASLIK132,BASLIK1231,BASLIK133,FATURATARIHI,BODYTEXT1,BASLIK11,BASLIK111,BIRIMADI,ACCOUNTANT1,BODYTEXT2,STARTDATE,ENDDATE,BIRIMILI,PAYEROBJID,XXXXXXADI,DOSENO,ACCOUNTANTNAME,ACCOUNTANTTITLE,BANKACCOUNT,IBANNO};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    this.BODYTEXT1.CalcValue = "       Müdürlüğünüze teslim edilen aşağıda dökümü bulunan "  + this.STARTDATE.FormattedValue + " - " + this.ENDDATE.FormattedValue + " dönemine ait fatura bedellerinin dökümü aşağıda sunulmuştur.";
            this.BODYTEXT2.CalcValue = "       Ödemelerin XXXXXXmiz Döner Sermaye Muhasebe Biriminin "  + this.BANKACCOUNT.FormattedValue + " nolu hesabına (IBAN: " + this.IBANNO.FormattedValue + ") yatırılması arz/rica olunur.";
            
            PayerDefinition payer = (PayerDefinition)MyParentReport.ReportObjectContext.GetObject(new Guid (PAYEROBJID.CalcValue), "PayerDefinition");
            if (payer.Type != null)
            {
                if (payer.Type.PayerType == PayerTypeEnum.SGK)
                {
                    this.BASLIK11.Visible = EvetHayirEnum.ehEvet;
                    this.BASLIK111.Visible = EvetHayirEnum.ehEvet;
                }
                else
                {
                    this.BASLIK11.Visible = EvetHayirEnum.ehHayir;
                    this.BASLIK111.Visible = EvetHayirEnum.ehHayir;
                }
            }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PARTDGroup : TTReportGroup
        {
            public CollectedInvoicePreReport_SE MyParentReport
            {
                get { return (CollectedInvoicePreReport_SE)ParentReport; }
            }

            new public PARTDGroupHeader Header()
            {
                return (PARTDGroupHeader)_header;
            }

            new public PARTDGroupFooter Footer()
            {
                return (PARTDGroupFooter)_footer;
            }

            public TTReportField BASLIK11 { get {return Footer().BASLIK11;} }
            public TTReportField A1 { get {return Footer().A1;} }
            public TTReportField T1 { get {return Footer().T1;} }
            public TTReportField BASLIK12 { get {return Footer().BASLIK12;} }
            public TTReportField BASLIK13 { get {return Footer().BASLIK13;} }
            public TTReportField BASLIK131 { get {return Footer().BASLIK131;} }
            public TTReportField A2 { get {return Footer().A2;} }
            public TTReportField T2 { get {return Footer().T2;} }
            public TTReportField A3 { get {return Footer().A3;} }
            public TTReportField T3 { get {return Footer().T3;} }
            public TTReportField A4 { get {return Footer().A4;} }
            public TTReportField T4 { get {return Footer().T4;} }
            public TTReportField AYAKTANYATAN { get {return Footer().AYAKTANYATAN;} }
            public TTReportField DESC { get {return Footer().DESC;} }
            public PARTDGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTDGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
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
                _header = new PARTDGroupHeader(this);
                _footer = new PARTDGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTDGroupHeader : TTReportSection
            {
                public CollectedInvoicePreReport_SE MyParentReport
                {
                    get { return (CollectedInvoicePreReport_SE)ParentReport; }
                }
                 
                public PARTDGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 3;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTDGroupFooter : TTReportSection
            {
                public CollectedInvoicePreReport_SE MyParentReport
                {
                    get { return (CollectedInvoicePreReport_SE)ParentReport; }
                }
                
                public TTReportField BASLIK11;
                public TTReportField A1;
                public TTReportField T1;
                public TTReportField BASLIK12;
                public TTReportField BASLIK13;
                public TTReportField BASLIK131;
                public TTReportField A2;
                public TTReportField T2;
                public TTReportField A3;
                public TTReportField T3;
                public TTReportField A4;
                public TTReportField T4;
                public TTReportField AYAKTANYATAN;
                public TTReportField DESC; 
                public PARTDGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 26;
                    RepeatCount = 0;
                    
                    BASLIK11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 43, 6, false);
                    BASLIK11.Name = "BASLIK11";
                    BASLIK11.DrawStyle = DrawStyleConstants.vbSolid;
                    BASLIK11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK11.TextFont.CharSet = 162;
                    BASLIK11.Value = @"Tedavi Türü";

                    A1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 6, 43, 12, false);
                    A1.Name = "A1";
                    A1.DrawStyle = DrawStyleConstants.vbSolid;
                    A1.FieldType = ReportFieldTypeEnum.ftVariable;
                    A1.CaseFormat = CaseFormatEnum.fcUpperCase;
                    A1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    A1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    A1.TextFont.Bold = true;
                    A1.TextFont.CharSet = 162;
                    A1.Value = @"{%AYAKTANYATAN%}";

                    T1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 12, 43, 18, false);
                    T1.Name = "T1";
                    T1.DrawStyle = DrawStyleConstants.vbSolid;
                    T1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T1.TextFont.Bold = true;
                    T1.TextFont.CharSet = 162;
                    T1.Value = @"Genel Toplam";

                    BASLIK12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 1, 68, 6, false);
                    BASLIK12.Name = "BASLIK12";
                    BASLIK12.DrawStyle = DrawStyleConstants.vbSolid;
                    BASLIK12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK12.Value = @"Branş Adedi";

                    BASLIK13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 1, 99, 6, false);
                    BASLIK13.Name = "BASLIK13";
                    BASLIK13.DrawStyle = DrawStyleConstants.vbSolid;
                    BASLIK13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK13.Value = @"Hasta Sayısı";

                    BASLIK131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 1, 197, 6, false);
                    BASLIK131.Name = "BASLIK131";
                    BASLIK131.DrawStyle = DrawStyleConstants.vbSolid;
                    BASLIK131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK131.Value = @"Toplam Fatura Tutarı (TL)";

                    A2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 6, 68, 12, false);
                    A2.Name = "A2";
                    A2.DrawStyle = DrawStyleConstants.vbSolid;
                    A2.FieldType = ReportFieldTypeEnum.ftVariable;
                    A2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    A2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    A2.TextFont.Bold = true;
                    A2.TextFont.CharSet = 162;
                    A2.Value = @"{@subgroupcount@}";

                    T2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 12, 68, 18, false);
                    T2.Name = "T2";
                    T2.DrawStyle = DrawStyleConstants.vbSolid;
                    T2.FieldType = ReportFieldTypeEnum.ftVariable;
                    T2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T2.TextFont.Bold = true;
                    T2.TextFont.CharSet = 162;
                    T2.Value = @"{@subgroupcount@}";

                    A3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 6, 99, 12, false);
                    A3.Name = "A3";
                    A3.DrawStyle = DrawStyleConstants.vbSolid;
                    A3.FieldType = ReportFieldTypeEnum.ftVariable;
                    A3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    A3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    A3.TextFont.Bold = true;
                    A3.TextFont.CharSet = 162;
                    A3.Value = @"{#EPISODECOUNT#}";

                    T3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 12, 99, 18, false);
                    T3.Name = "T3";
                    T3.DrawStyle = DrawStyleConstants.vbSolid;
                    T3.FieldType = ReportFieldTypeEnum.ftVariable;
                    T3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T3.TextFont.Bold = true;
                    T3.TextFont.CharSet = 162;
                    T3.Value = @"{#EPISODECOUNT#}";

                    A4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 6, 197, 12, false);
                    A4.Name = "A4";
                    A4.DrawStyle = DrawStyleConstants.vbSolid;
                    A4.FieldType = ReportFieldTypeEnum.ftVariable;
                    A4.TextFormat = @"#,##0.#0";
                    A4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    A4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    A4.TextFont.Bold = true;
                    A4.TextFont.CharSet = 162;
                    A4.Value = @"{#TOTALPRICE#}";

                    T4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 12, 197, 18, false);
                    T4.Name = "T4";
                    T4.DrawStyle = DrawStyleConstants.vbSolid;
                    T4.FieldType = ReportFieldTypeEnum.ftVariable;
                    T4.TextFormat = @"#,##0.#0";
                    T4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    T4.TextFont.Bold = true;
                    T4.TextFont.CharSet = 162;
                    T4.Value = @"{#TOTALPRICE#}";

                    AYAKTANYATAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 20, 195, 25, false);
                    AYAKTANYATAN.Name = "AYAKTANYATAN";
                    AYAKTANYATAN.Visible = EvetHayirEnum.ehHayir;
                    AYAKTANYATAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    AYAKTANYATAN.ObjectDefName = "OutPatientInPatientEnum";
                    AYAKTANYATAN.DataMember = "DISPLAYTEXT";
                    AYAKTANYATAN.Value = @"{#PATIENTSTATUS#}";

                    DESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 21, 155, 26, false);
                    DESC.Name = "DESC";
                    DESC.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESC.CaseFormat = CaseFormatEnum.fcUpperCase;
                    DESC.Value = @"{%AYAKTANYATAN%} HASTA BİLGİLERİ   FATURA NO : {#DOCUMENTNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CollectedInvoice.CollectedInvoiceReportQuery_Class dataset_CollectedInvoiceReportQuery = ParentGroup.rsGroup.GetCurrentRecord<CollectedInvoice.CollectedInvoiceReportQuery_Class>(0);
                    BASLIK11.CalcValue = BASLIK11.Value;
                    AYAKTANYATAN.CalcValue = (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.PATIENTSTATUS) : "");
                    AYAKTANYATAN.PostFieldValueCalculation();
                    A1.CalcValue = MyParentReport.PARTD.AYAKTANYATAN.CalcValue;
                    T1.CalcValue = T1.Value;
                    BASLIK12.CalcValue = BASLIK12.Value;
                    BASLIK13.CalcValue = BASLIK13.Value;
                    BASLIK131.CalcValue = BASLIK131.Value;
                    A2.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    T2.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    A3.CalcValue = (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.Episodecount) : "");
                    T3.CalcValue = (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.Episodecount) : "");
                    A4.CalcValue = (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.TotalPrice) : "");
                    T4.CalcValue = (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.TotalPrice) : "");
                    DESC.CalcValue = MyParentReport.PARTD.AYAKTANYATAN.CalcValue + @" HASTA BİLGİLERİ   FATURA NO : " + (dataset_CollectedInvoiceReportQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceReportQuery.DocumentNo) : "");
                    return new TTReportObject[] { BASLIK11,AYAKTANYATAN,A1,T1,BASLIK12,BASLIK13,BASLIK131,A2,T2,A3,T3,A4,T4,DESC};
                }

                public override void RunScript()
                {
#region PARTD FOOTER_Script
                    if (this.A1.CalcValue == "")
                this.A1.CalcValue = "Ayaktan ve Yatan";
#endregion PARTD FOOTER_Script
                }
            }

        }

        public PARTDGroup PARTD;

        public partial class PARTAGroup : TTReportGroup
        {
            public CollectedInvoicePreReport_SE MyParentReport
            {
                get { return (CollectedInvoicePreReport_SE)ParentReport; }
            }

            new public PARTAGroupBody Body()
            {
                return (PARTAGroupBody)_body;
            }
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
                list[0] = new TTReportNqlData<CollectedPatientList.CollectedInvoicePreReportQuery_SE_Class>("CollectedInvoicePreReportQuery_SE", CollectedPatientList.CollectedInvoicePreReportQuery_SE((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTAGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTAGroupBody : TTReportSection
            {
                public CollectedInvoicePreReport_SE MyParentReport
                {
                    get { return (CollectedInvoicePreReport_SE)ParentReport; }
                }
                 
                public PARTAGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 11;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTFGroup : TTReportGroup
        {
            public CollectedInvoicePreReport_SE MyParentReport
            {
                get { return (CollectedInvoicePreReport_SE)ParentReport; }
            }

            new public PARTFGroupHeader Header()
            {
                return (PARTFGroupHeader)_header;
            }

            new public PARTFGroupFooter Footer()
            {
                return (PARTFGroupFooter)_footer;
            }

            public TTReportField BASLIK111 { get {return Header().BASLIK111;} }
            public TTReportField BASLIK121 { get {return Header().BASLIK121;} }
            public TTReportField BASLIK131 { get {return Header().BASLIK131;} }
            public TTReportField BASLIK1121 { get {return Header().BASLIK1121;} }
            public TTReportField BASLIK11211 { get {return Header().BASLIK11211;} }
            public TTReportField BASLIK111211 { get {return Header().BASLIK111211;} }
            public TTReportField BASLIK111212 { get {return Header().BASLIK111212;} }
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
                public CollectedInvoicePreReport_SE MyParentReport
                {
                    get { return (CollectedInvoicePreReport_SE)ParentReport; }
                }
                
                public TTReportField BASLIK111;
                public TTReportField BASLIK121;
                public TTReportField BASLIK131;
                public TTReportField BASLIK1121;
                public TTReportField BASLIK11211;
                public TTReportField BASLIK111211;
                public TTReportField BASLIK111212; 
                public PARTFGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 17;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    BASLIK111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 7, 26, 17, false);
                    BASLIK111.Name = "BASLIK111";
                    BASLIK111.DrawStyle = DrawStyleConstants.vbSolid;
                    BASLIK111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASLIK111.TextFont.CharSet = 162;
                    BASLIK111.Value = @"Klasör No";

                    BASLIK121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 7, 44, 17, false);
                    BASLIK121.Name = "BASLIK121";
                    BASLIK121.DrawStyle = DrawStyleConstants.vbSolid;
                    BASLIK121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASLIK121.Value = @"Branş Kodu";

                    BASLIK131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 7, 128, 17, false);
                    BASLIK131.Name = "BASLIK131";
                    BASLIK131.DrawStyle = DrawStyleConstants.vbSolid;
                    BASLIK131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASLIK131.Value = @"Branş Adı";

                    BASLIK1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 7, 157, 17, false);
                    BASLIK1121.Name = "BASLIK1121";
                    BASLIK1121.DrawStyle = DrawStyleConstants.vbSolid;
                    BASLIK1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASLIK1121.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK1121.Value = @"Koli 
Adedi";

                    BASLIK11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 7, 173, 17, false);
                    BASLIK11211.Name = "BASLIK11211";
                    BASLIK11211.DrawStyle = DrawStyleConstants.vbSolid;
                    BASLIK11211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK11211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASLIK11211.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK11211.Value = @"Toplam 
Hasta Sayısı";

                    BASLIK111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 7, 197, 17, false);
                    BASLIK111211.Name = "BASLIK111211";
                    BASLIK111211.DrawStyle = DrawStyleConstants.vbSolid;
                    BASLIK111211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK111211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASLIK111211.Value = @"Toplam Tutar(TL)";

                    BASLIK111212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 7, 145, 17, false);
                    BASLIK111212.Name = "BASLIK111212";
                    BASLIK111212.DrawStyle = DrawStyleConstants.vbSolid;
                    BASLIK111212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK111212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASLIK111212.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK111212.Value = @"Örneklenen
Hasta Sayısı";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BASLIK111.CalcValue = BASLIK111.Value;
                    BASLIK121.CalcValue = BASLIK121.Value;
                    BASLIK131.CalcValue = BASLIK131.Value;
                    BASLIK1121.CalcValue = BASLIK1121.Value;
                    BASLIK11211.CalcValue = BASLIK11211.Value;
                    BASLIK111211.CalcValue = BASLIK111211.Value;
                    BASLIK111212.CalcValue = BASLIK111212.Value;
                    return new TTReportObject[] { BASLIK111,BASLIK121,BASLIK131,BASLIK1121,BASLIK11211,BASLIK111211,BASLIK111212};
                }
            }
            public partial class PARTFGroupFooter : TTReportSection
            {
                public CollectedInvoicePreReport_SE MyParentReport
                {
                    get { return (CollectedInvoicePreReport_SE)ParentReport; }
                }
                 
                public PARTFGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 15;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTFGroup PARTF;

        public partial class PARTCGroup : TTReportGroup
        {
            public CollectedInvoicePreReport_SE MyParentReport
            {
                get { return (CollectedInvoicePreReport_SE)ParentReport; }
            }

            new public PARTCGroupBody Body()
            {
                return (PARTCGroupBody)_body;
            }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField BRANSKODU { get {return Body().BRANSKODU;} }
            public TTReportField BRANSADI { get {return Body().BRANSADI;} }
            public TTReportField KOLIADEDI { get {return Body().KOLIADEDI;} }
            public TTReportField SUBEPIZOTSAYISI { get {return Body().SUBEPIZOTSAYISI;} }
            public TTReportField TOPLAMTUTAR { get {return Body().TOPLAMTUTAR;} }
            public TTReportField ORNEKLENENHASTASAYISI { get {return Body().ORNEKLENENHASTASAYISI;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<CollectedPatientList.CollectedInvoicePreReportQuery_SE_Class>("CollectedInvoicePreReportQuery_SE", CollectedPatientList.CollectedInvoicePreReportQuery_SE((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTCGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTCGroupBody : TTReportSection
            {
                public CollectedInvoicePreReport_SE MyParentReport
                {
                    get { return (CollectedInvoicePreReport_SE)ParentReport; }
                }
                
                public TTReportField SIRANO;
                public TTReportField BRANSKODU;
                public TTReportField BRANSADI;
                public TTReportField KOLIADEDI;
                public TTReportField SUBEPIZOTSAYISI;
                public TTReportField TOPLAMTUTAR;
                public TTReportField ORNEKLENENHASTASAYISI; 
                public PARTCGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 0, 26, 5, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.DrawStyle = DrawStyleConstants.vbSolid;
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIRANO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                    BRANSKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 0, 44, 5, false);
                    BRANSKODU.Name = "BRANSKODU";
                    BRANSKODU.DrawStyle = DrawStyleConstants.vbSolid;
                    BRANSKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    BRANSKODU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BRANSKODU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BRANSKODU.Value = @"{#SPECIALITYCODE#}";

                    BRANSADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 0, 128, 5, false);
                    BRANSADI.Name = "BRANSADI";
                    BRANSADI.DrawStyle = DrawStyleConstants.vbSolid;
                    BRANSADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BRANSADI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BRANSADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BRANSADI.Value = @"{#SPECIALITYNAME#}";

                    KOLIADEDI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 156, 5, false);
                    KOLIADEDI.Name = "KOLIADEDI";
                    KOLIADEDI.DrawStyle = DrawStyleConstants.vbSolid;
                    KOLIADEDI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KOLIADEDI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KOLIADEDI.Value = @"1";

                    SUBEPIZOTSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 0, 173, 5, false);
                    SUBEPIZOTSAYISI.Name = "SUBEPIZOTSAYISI";
                    SUBEPIZOTSAYISI.DrawStyle = DrawStyleConstants.vbSolid;
                    SUBEPIZOTSAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBEPIZOTSAYISI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUBEPIZOTSAYISI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUBEPIZOTSAYISI.Value = @"{#SUBEPISODECOUNT#}";

                    TOPLAMTUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 0, 197, 5, false);
                    TOPLAMTUTAR.Name = "TOPLAMTUTAR";
                    TOPLAMTUTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    TOPLAMTUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMTUTAR.TextFormat = @"#,##0.#0";
                    TOPLAMTUTAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOPLAMTUTAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOPLAMTUTAR.Value = @"{#TOTALPRICE#}";

                    ORNEKLENENHASTASAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 0, 145, 5, false);
                    ORNEKLENENHASTASAYISI.Name = "ORNEKLENENHASTASAYISI";
                    ORNEKLENENHASTASAYISI.DrawStyle = DrawStyleConstants.vbSolid;
                    ORNEKLENENHASTASAYISI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORNEKLENENHASTASAYISI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORNEKLENENHASTASAYISI.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CollectedPatientList.CollectedInvoicePreReportQuery_SE_Class dataset_CollectedInvoicePreReportQuery_SE = ParentGroup.rsGroup.GetCurrentRecord<CollectedPatientList.CollectedInvoicePreReportQuery_SE_Class>(0);
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    BRANSKODU.CalcValue = (dataset_CollectedInvoicePreReportQuery_SE != null ? Globals.ToStringCore(dataset_CollectedInvoicePreReportQuery_SE.Specialitycode) : "");
                    BRANSADI.CalcValue = (dataset_CollectedInvoicePreReportQuery_SE != null ? Globals.ToStringCore(dataset_CollectedInvoicePreReportQuery_SE.Specialityname) : "");
                    KOLIADEDI.CalcValue = KOLIADEDI.Value;
                    SUBEPIZOTSAYISI.CalcValue = (dataset_CollectedInvoicePreReportQuery_SE != null ? Globals.ToStringCore(dataset_CollectedInvoicePreReportQuery_SE.Subepisodecount) : "");
                    TOPLAMTUTAR.CalcValue = (dataset_CollectedInvoicePreReportQuery_SE != null ? Globals.ToStringCore(dataset_CollectedInvoicePreReportQuery_SE.Totalprice) : "");
                    ORNEKLENENHASTASAYISI.CalcValue = ORNEKLENENHASTASAYISI.Value;
                    return new TTReportObject[] { SIRANO,BRANSKODU,BRANSADI,KOLIADEDI,SUBEPIZOTSAYISI,TOPLAMTUTAR,ORNEKLENENHASTASAYISI};
                }
            }

        }

        public PARTCGroup PARTC;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public CollectedInvoicePreReport_SE()
        {
            MAIN = new MAINGroup(this,"MAIN");
            PARTD = new PARTDGroup(this,"PARTD");
            PARTA = new PARTAGroup(PARTD,"PARTA");
            PARTF = new PARTFGroup(this,"PARTF");
            PARTC = new PARTCGroup(PARTF,"PARTC");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action Object ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "COLLECTEDINVOICEPREREPORT_SE";
            Caption = "Toplu Fatura Önyazı Raporu (Alt Vaka)";
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