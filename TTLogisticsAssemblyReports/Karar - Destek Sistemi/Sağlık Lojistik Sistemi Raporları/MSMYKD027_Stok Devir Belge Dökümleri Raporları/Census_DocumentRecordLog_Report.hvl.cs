
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
    /// Stok Devir Belge Dökümleri (Belge Kayıt Kütüğü)
    /// </summary>
    public partial class Census_DocumentRecordLog : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TERMID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string SIGNS = (string)TTObjectDefManager.Instance.DataTypes["RTF(LongText)"].ConvertValue("");
            public string TRANSACTIONTYPE = (string)TTObjectDefManager.Instance.DataTypes["String10"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public Census_DocumentRecordLog MyParentReport
            {
                get { return (Census_DocumentRecordLog)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField REPORTNAME { get {return Header().REPORTNAME;} }
            public TTReportField AdditionNO { get {return Header().AdditionNO;} }
            public TTReportField AccountingTerm { get {return Header().AccountingTerm;} }
            public TTReportField AccountYear { get {return Header().AccountYear;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField ACCOUNTANCYNAME { get {return Header().ACCOUNTANCYNAME;} }
            public TTReportField PAGENUMBER { get {return Footer().PAGENUMBER;} }
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
                public Census_DocumentRecordLog MyParentReport
                {
                    get { return (Census_DocumentRecordLog)ParentReport; }
                }
                
                public TTReportField REPORTNAME;
                public TTReportField AdditionNO;
                public TTReportField AccountingTerm;
                public TTReportField AccountYear;
                public TTReportField ENDDATE;
                public TTReportField ACCOUNTANCYNAME; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 37;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 12, 257, 30, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 12;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"";

                    AdditionNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 0, 257, 5, false);
                    AdditionNO.Name = "AdditionNO";
                    AdditionNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AdditionNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AdditionNO.TextFont.Name = "Arial";
                    AdditionNO.TextFont.Bold = true;
                    AdditionNO.TextFont.CharSet = 162;
                    AdditionNO.Value = @"EK-88";

                    AccountingTerm = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 0, 328, 5, false);
                    AccountingTerm.Name = "AccountingTerm";
                    AccountingTerm.Visible = EvetHayirEnum.ehHayir;
                    AccountingTerm.FieldType = ReportFieldTypeEnum.ftVariable;
                    AccountingTerm.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AccountingTerm.ObjectDefName = "AccountingTerm";
                    AccountingTerm.DataMember = "STARTDATE";
                    AccountingTerm.Value = @"{@TERMID@}";

                    AccountYear = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 5, 328, 10, false);
                    AccountYear.Name = "AccountYear";
                    AccountYear.Visible = EvetHayirEnum.ehHayir;
                    AccountYear.FieldType = ReportFieldTypeEnum.ftVariable;
                    AccountYear.Value = @"";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 15, 328, 20, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ENDDATE.ObjectDefName = "AccountingTerm";
                    ENDDATE.DataMember = "ENDDATE";
                    ENDDATE.TextFont.Name = "Arial";
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@TERMID@}";

                    ACCOUNTANCYNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 10, 328, 15, false);
                    ACCOUNTANCYNAME.Name = "ACCOUNTANCYNAME";
                    ACCOUNTANCYNAME.Visible = EvetHayirEnum.ehHayir;
                    ACCOUNTANCYNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCOUNTANCYNAME.ObjectDefName = "AccountingTerm";
                    ACCOUNTANCYNAME.DataMember = "ACCOUNTANCY.NAME";
                    ACCOUNTANCYNAME.Value = @"{@TERMID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME.CalcValue = @"";
                    AdditionNO.CalcValue = AdditionNO.Value;
                    AccountingTerm.CalcValue = MyParentReport.RuntimeParameters.TERMID.ToString();
                    AccountingTerm.PostFieldValueCalculation();
                    AccountYear.CalcValue = @"";
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.TERMID.ToString();
                    ENDDATE.PostFieldValueCalculation();
                    ACCOUNTANCYNAME.CalcValue = MyParentReport.RuntimeParameters.TERMID.ToString();
                    ACCOUNTANCYNAME.PostFieldValueCalculation();
                    return new TTReportObject[] { REPORTNAME,AdditionNO,AccountingTerm,AccountYear,ENDDATE,ACCOUNTANCYNAME};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    string termID = ((Census_DocumentRecordLog)ParentReport).RuntimeParameters.TERMID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            AccountingTerm term = (AccountingTerm)ctx.GetObject(new Guid(termID), typeof(AccountingTerm));
            REPORTNAME.CalcValue = ACCOUNTANCYNAME.FormattedValue + "\r\n" + Convert.ToDateTime(term.EndDate).Year.ToString() + " YILI BELGE KAYIT KÜTÜĞÜ";
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public Census_DocumentRecordLog MyParentReport
                {
                    get { return (Census_DocumentRecordLog)ParentReport; }
                }
                
                public TTReportField PAGENUMBER; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 1, 142, 6, false);
                    PAGENUMBER.Name = "PAGENUMBER";
                    PAGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PAGENUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER.TextFont.Name = "Arial";
                    PAGENUMBER.TextFont.Size = 9;
                    PAGENUMBER.TextFont.Bold = true;
                    PAGENUMBER.TextFont.CharSet = 162;
                    PAGENUMBER.Value = @"EK-88-{@pagenumber@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PAGENUMBER.CalcValue = @"EK-88-" + ParentReport.CurrentPageNumber.ToString();
                    return new TTReportObject[] { PAGENUMBER};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public Census_DocumentRecordLog MyParentReport
            {
                get { return (Census_DocumentRecordLog)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12221 { get {return Header().NewField12221;} }
            public TTReportField NewField13221 { get {return Header().NewField13221;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField113 { get {return Header().NewField113;} }
            public TTReportField NewField114 { get {return Header().NewField114;} }
            public TTReportField NewField1411 { get {return Header().NewField1411;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField1112 { get {return Header().NewField1112;} }
            public TTReportField NewField1113 { get {return Header().NewField1113;} }
            public TTReportField NewField1114 { get {return Header().NewField1114;} }
            public TTReportField NewField1115 { get {return Header().NewField1115;} }
            public TTReportField TOTAL { get {return Footer().TOTAL;} }
            public TTReportField TEFTIS { get {return Footer().TEFTIS;} }
            public TTReportField SUBGROUPCOUNT { get {return Footer().SUBGROUPCOUNT;} }
            public TTReportField PAGECOUNT { get {return Footer().PAGECOUNT;} }
            public TTReportField AMOUNTTEXT { get {return Footer().AMOUNTTEXT;} }
            public TTReportField ACCOUNTANCYNAME { get {return Footer().ACCOUNTANCYNAME;} }
            public TTReportField COUNTTEXT { get {return Footer().COUNTTEXT;} }
            public TTReportField SUBGROUPCOUNTTEXT { get {return Footer().SUBGROUPCOUNTTEXT;} }
            public TTReportField SIGNS { get {return Footer().SIGNS;} }
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
                public Census_DocumentRecordLog MyParentReport
                {
                    get { return (Census_DocumentRecordLog)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField12221;
                public TTReportField NewField13221;
                public TTReportField NewField111;
                public TTReportField NewField112;
                public TTReportField NewField113;
                public TTReportField NewField114;
                public TTReportField NewField1411;
                public TTReportField NewField1111;
                public TTReportField NewField1112;
                public TTReportField NewField1113;
                public TTReportField NewField1114;
                public TTReportField NewField1115; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 12, 5, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Blg.Nu.";

                    NewField12221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 0, 84, 5, false);
                    NewField12221.Name = "NewField12221";
                    NewField12221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12221.TextFont.Name = "Arial";
                    NewField12221.TextFont.Bold = true;
                    NewField12221.TextFont.CharSet = 162;
                    NewField12221.Value = @"Kalem";

                    NewField13221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 0, 158, 5, false);
                    NewField13221.Name = "NewField13221";
                    NewField13221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13221.TextFont.Name = "Arial";
                    NewField13221.TextFont.Bold = true;
                    NewField13221.TextFont.CharSet = 162;
                    NewField13221.Value = @"Birinci Kalem Malzemenin Cinsi";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 0, 178, 5, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Sipariş Nu.";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 0, 24, 5, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112.TextFont.Name = "Arial";
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"Kodu";

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 0, 36, 5, false);
                    NewField113.Name = "NewField113";
                    NewField113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113.TextFont.Name = "Arial";
                    NewField113.TextFont.Bold = true;
                    NewField113.TextFont.CharSet = 162;
                    NewField113.Value = @"İptal";

                    NewField114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 0, 58, 5, false);
                    NewField114.Name = "NewField114";
                    NewField114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField114.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField114.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField114.MultiLine = EvetHayirEnum.ehEvet;
                    NewField114.WordBreak = EvetHayirEnum.ehEvet;
                    NewField114.TextFont.Name = "Arial";
                    NewField114.TextFont.Bold = true;
                    NewField114.TextFont.CharSet = 162;
                    NewField114.Value = @"Tarih";

                    NewField1411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 0, 71, 5, false);
                    NewField1411.Name = "NewField1411";
                    NewField1411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1411.TextFont.Name = "Arial";
                    NewField1411.TextFont.Bold = true;
                    NewField1411.TextFont.CharSet = 162;
                    NewField1411.Value = @"Mhtp.";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 0, 190, 5, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Cilt";

                    NewField1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 0, 197, 5, false);
                    NewField1112.Name = "NewField1112";
                    NewField1112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1112.TextFont.Name = "Arial";
                    NewField1112.TextFont.Bold = true;
                    NewField1112.TextFont.CharSet = 162;
                    NewField1112.Value = @"Tk.";

                    NewField1113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 197, 0, 207, 5, false);
                    NewField1113.Name = "NewField1113";
                    NewField1113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1113.TextFont.Name = "Arial";
                    NewField1113.TextFont.Bold = true;
                    NewField1113.TextFont.CharSet = 162;
                    NewField1113.Value = @"Eki";

                    NewField1114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 207, 0, 227, 5, false);
                    NewField1114.Name = "NewField1114";
                    NewField1114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1114.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1114.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1114.TextFont.Name = "Arial";
                    NewField1114.TextFont.Bold = true;
                    NewField1114.TextFont.CharSet = 162;
                    NewField1114.Value = @"Hazırlayan";

                    NewField1115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 0, 257, 5, false);
                    NewField1115.Name = "NewField1115";
                    NewField1115.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1115.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1115.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1115.TextFont.Name = "Arial";
                    NewField1115.TextFont.Bold = true;
                    NewField1115.TextFont.CharSet = 162;
                    NewField1115.Value = @"Belge Açıklaması";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField12221.CalcValue = NewField12221.Value;
                    NewField13221.CalcValue = NewField13221.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField113.CalcValue = NewField113.Value;
                    NewField114.CalcValue = NewField114.Value;
                    NewField1411.CalcValue = NewField1411.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1112.CalcValue = NewField1112.Value;
                    NewField1113.CalcValue = NewField1113.Value;
                    NewField1114.CalcValue = NewField1114.Value;
                    NewField1115.CalcValue = NewField1115.Value;
                    return new TTReportObject[] { NewField11,NewField12221,NewField13221,NewField111,NewField112,NewField113,NewField114,NewField1411,NewField1111,NewField1112,NewField1113,NewField1114,NewField1115};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public Census_DocumentRecordLog MyParentReport
                {
                    get { return (Census_DocumentRecordLog)ParentReport; }
                }
                
                public TTReportField TOTAL;
                public TTReportField TEFTIS;
                public TTReportField SUBGROUPCOUNT;
                public TTReportField PAGECOUNT;
                public TTReportField AMOUNTTEXT;
                public TTReportField ACCOUNTANCYNAME;
                public TTReportField COUNTTEXT;
                public TTReportField SUBGROUPCOUNTTEXT;
                public TTReportField SIGNS; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 90;
                    RepeatCount = 0;
                    
                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 265, 7, 294, 12, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.Visible = EvetHayirEnum.ehHayir;
                    TOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTAL.TextFont.Name = "Arial";
                    TOTAL.TextFont.CharSet = 162;
                    TOTAL.Value = @"";

                    TEFTIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 2, 258, 14, false);
                    TEFTIS.Name = "TEFTIS";
                    TEFTIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEFTIS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEFTIS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEFTIS.MultiLine = EvetHayirEnum.ehEvet;
                    TEFTIS.WordBreak = EvetHayirEnum.ehEvet;
                    TEFTIS.TextFont.Name = "Arial";
                    TEFTIS.TextFont.CharSet = 162;
                    TEFTIS.Value = @"";

                    SUBGROUPCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 327, 1, 352, 6, false);
                    SUBGROUPCOUNT.Name = "SUBGROUPCOUNT";
                    SUBGROUPCOUNT.Visible = EvetHayirEnum.ehHayir;
                    SUBGROUPCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBGROUPCOUNT.Value = @"{@subgroupcount@}";

                    PAGECOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 327, 6, 352, 11, false);
                    PAGECOUNT.Name = "PAGECOUNT";
                    PAGECOUNT.Visible = EvetHayirEnum.ehHayir;
                    PAGECOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGECOUNT.Value = @"{@pagecount@}";

                    AMOUNTTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 302, 1, 327, 6, false);
                    AMOUNTTEXT.Name = "AMOUNTTEXT";
                    AMOUNTTEXT.Visible = EvetHayirEnum.ehHayir;
                    AMOUNTTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNTTEXT.CaseFormat = CaseFormatEnum.fcUpperCase;
                    AMOUNTTEXT.TextFormat = @"NUMBERTEXT";
                    AMOUNTTEXT.Value = @"";

                    ACCOUNTANCYNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 302, 6, 327, 11, false);
                    ACCOUNTANCYNAME.Name = "ACCOUNTANCYNAME";
                    ACCOUNTANCYNAME.Visible = EvetHayirEnum.ehHayir;
                    ACCOUNTANCYNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCOUNTANCYNAME.ObjectDefName = "AccountingTerm";
                    ACCOUNTANCYNAME.DataMember = "ACCOUNTANCY.NAME";
                    ACCOUNTANCYNAME.Value = @"{@TERMID@}";

                    COUNTTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 265, 13, 294, 18, false);
                    COUNTTEXT.Name = "COUNTTEXT";
                    COUNTTEXT.Visible = EvetHayirEnum.ehHayir;
                    COUNTTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTTEXT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNTTEXT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNTTEXT.TextFont.Name = "Arial";
                    COUNTTEXT.TextFont.CharSet = 162;
                    COUNTTEXT.Value = @"";

                    SUBGROUPCOUNTTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 302, 11, 327, 16, false);
                    SUBGROUPCOUNTTEXT.Name = "SUBGROUPCOUNTTEXT";
                    SUBGROUPCOUNTTEXT.Visible = EvetHayirEnum.ehHayir;
                    SUBGROUPCOUNTTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBGROUPCOUNTTEXT.TextFormat = @"NUMBERTEXT";
                    SUBGROUPCOUNTTEXT.Value = @"";

                    SIGNS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 19, 257, 88, false);
                    SIGNS.Name = "SIGNS";
                    SIGNS.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIGNS.MultiLine = EvetHayirEnum.ehEvet;
                    SIGNS.Value = @"{@SIGNS@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TOTAL.CalcValue = @"";
                    TEFTIS.CalcValue = @"";
                    SUBGROUPCOUNT.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    PAGECOUNT.CalcValue = ParentReport.ReportTotalPageCount;
                    AMOUNTTEXT.CalcValue = @"";
                    ACCOUNTANCYNAME.CalcValue = MyParentReport.RuntimeParameters.TERMID.ToString();
                    ACCOUNTANCYNAME.PostFieldValueCalculation();
                    COUNTTEXT.CalcValue = @"";
                    SUBGROUPCOUNTTEXT.CalcValue = @"";
                    SIGNS.CalcValue = MyParentReport.RuntimeParameters.SIGNS.ToString();
                    return new TTReportObject[] { TOTAL,TEFTIS,SUBGROUPCOUNT,PAGECOUNT,AMOUNTTEXT,ACCOUNTANCYNAME,COUNTTEXT,SUBGROUPCOUNTTEXT,SIGNS};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    AMOUNTTEXT.CalcValue = PARTBGroup.totalAmount.ToString();
            SUBGROUPCOUNTTEXT.CalcValue = SUBGROUPCOUNT.CalcValue;
            //TOTAL.CalcValue = "///////////YALNIZ " + PARTBGroup.totalAmount.ToString() +" (" + AMOUNTTEXT.FormattedValue + ") KALEMDİR///////////";
            PARTBGroup.totalAmount = 0;
            
            string termID = ((Census_DocumentRecordLog)ParentReport).RuntimeParameters.TERMID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            AccountingTerm term = (AccountingTerm)ctx.GetObject(new Guid(termID), typeof(AccountingTerm));
            if(term.EndDate != null)
            {
                TEFTIS.CalcValue = Convert.ToDateTime(term.EndDate).Year.ToString() + " yılına ait Belge Kayıt Kütüğüne toplam " + SUBGROUPCOUNT.FormattedValue + " adet belgenin kaydedilmiş olduğu görüşmüştür.";
//                    + ACCOUNTANCYNAME.FormattedValue + " saymanlığının " + 
//                    + " bütçe yılı teftişinde saymandan alınarak teftiş sandığına konulmuştur.";
            }
            //COUNTTEXT.CalcValue = "///////////YALNIZ " + SUBGROUPCOUNT.FormattedValue + " (" + SUBGROUPCOUNTTEXT.FormattedValue.ToUpper() + ") ADET BELGE///////////";
#endregion PARTB FOOTER_Script
                }
            }

#region PARTB_Methods
            public static int totalAmount = 0;
#endregion PARTB_Methods
        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public Census_DocumentRecordLog MyParentReport
            {
                get { return (Census_DocumentRecordLog)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ObjectID { get {return Body().ObjectID;} }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField REGISTRATIONNUMBER { get {return Body().REGISTRATIONNUMBER;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField CANCEL { get {return Body().CANCEL;} }
            public TTReportField DATE { get {return Body().DATE;} }
            public TTReportField MHTP { get {return Body().MHTP;} }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField CILT { get {return Body().CILT;} }
            public TTReportField TK { get {return Body().TK;} }
            public TTReportField EK { get {return Body().EK;} }
            public TTReportField PREPAREDBY { get {return Body().PREPAREDBY;} }
            public TTReportField DESC { get {return Body().DESC;} }
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
                list[0] = new TTReportNqlData<DocumentRecordLog.CensusReportNQL_DocRecLogByInOutIncludeCancels_Class>("CensusReportNQL_DocRecLogByInOutIncludeCancels", DocumentRecordLog.CensusReportNQL_DocRecLogByInOutIncludeCancels((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TERMID),(string)TTObjectDefManager.Instance.DataTypes["String10"].ConvertValue(MyParentReport.RuntimeParameters.TRANSACTIONTYPE)));
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
                public Census_DocumentRecordLog MyParentReport
                {
                    get { return (Census_DocumentRecordLog)ParentReport; }
                }
                
                public TTReportField ObjectID;
                public TTReportField COUNT;
                public TTReportField REGISTRATIONNUMBER;
                public TTReportField AMOUNT;
                public TTReportField MATERIALNAME;
                public TTReportField CANCEL;
                public TTReportField DATE;
                public TTReportField MHTP;
                public TTReportField ORDERNO;
                public TTReportField CILT;
                public TTReportField TK;
                public TTReportField EK;
                public TTReportField PREPAREDBY;
                public TTReportField DESC; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    ObjectID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 0, 328, 5, false);
                    ObjectID.Name = "ObjectID";
                    ObjectID.Visible = EvetHayirEnum.ehHayir;
                    ObjectID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ObjectID.Value = @"{#STOCKACTIONOBJECTID#}";

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 12, 5, false);
                    COUNT.Name = "COUNT";
                    COUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.TextFont.Name = "Arial";
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{@counter@}";

                    REGISTRATIONNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 0, 24, 5, false);
                    REGISTRATIONNUMBER.Name = "REGISTRATIONNUMBER";
                    REGISTRATIONNUMBER.DrawStyle = DrawStyleConstants.vbSolid;
                    REGISTRATIONNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    REGISTRATIONNUMBER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REGISTRATIONNUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REGISTRATIONNUMBER.TextFont.Name = "Arial";
                    REGISTRATIONNUMBER.TextFont.CharSet = 162;
                    REGISTRATIONNUMBER.Value = @"";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 0, 84, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFormat = @"#,###";
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 0, 158, 5, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALNAME.TextFont.Name = "Arial";
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"";

                    CANCEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 0, 36, 5, false);
                    CANCEL.Name = "CANCEL";
                    CANCEL.DrawStyle = DrawStyleConstants.vbSolid;
                    CANCEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    CANCEL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CANCEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CANCEL.TextFont.Name = "Arial";
                    CANCEL.TextFont.CharSet = 162;
                    CANCEL.Value = @"";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 0, 58, 5, false);
                    DATE.Name = "DATE";
                    DATE.DrawStyle = DrawStyleConstants.vbSolid;
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DATE.TextFont.Name = "Arial";
                    DATE.TextFont.CharSet = 162;
                    DATE.Value = @"";

                    MHTP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 0, 71, 5, false);
                    MHTP.Name = "MHTP";
                    MHTP.DrawStyle = DrawStyleConstants.vbSolid;
                    MHTP.FieldType = ReportFieldTypeEnum.ftVariable;
                    MHTP.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MHTP.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MHTP.TextFont.Name = "Arial";
                    MHTP.TextFont.CharSet = 162;
                    MHTP.Value = @"";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 0, 178, 5, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"";

                    CILT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 0, 190, 5, false);
                    CILT.Name = "CILT";
                    CILT.DrawStyle = DrawStyleConstants.vbSolid;
                    CILT.FieldType = ReportFieldTypeEnum.ftVariable;
                    CILT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CILT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CILT.TextFont.Name = "Arial";
                    CILT.TextFont.CharSet = 162;
                    CILT.Value = @"";

                    TK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 0, 197, 5, false);
                    TK.Name = "TK";
                    TK.DrawStyle = DrawStyleConstants.vbSolid;
                    TK.FieldType = ReportFieldTypeEnum.ftVariable;
                    TK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TK.TextFont.Name = "Arial";
                    TK.TextFont.CharSet = 162;
                    TK.Value = @"";

                    EK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 197, 0, 207, 5, false);
                    EK.Name = "EK";
                    EK.DrawStyle = DrawStyleConstants.vbSolid;
                    EK.FieldType = ReportFieldTypeEnum.ftVariable;
                    EK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EK.TextFont.Name = "Arial";
                    EK.TextFont.CharSet = 162;
                    EK.Value = @"";

                    PREPAREDBY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 207, 0, 227, 5, false);
                    PREPAREDBY.Name = "PREPAREDBY";
                    PREPAREDBY.DrawStyle = DrawStyleConstants.vbSolid;
                    PREPAREDBY.FieldType = ReportFieldTypeEnum.ftVariable;
                    PREPAREDBY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PREPAREDBY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PREPAREDBY.TextFont.Name = "Arial";
                    PREPAREDBY.TextFont.CharSet = 162;
                    PREPAREDBY.Value = @"";

                    DESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 0, 257, 5, false);
                    DESC.Name = "DESC";
                    DESC.DrawStyle = DrawStyleConstants.vbSolid;
                    DESC.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESC.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESC.TextFont.Name = "Arial";
                    DESC.TextFont.CharSet = 162;
                    DESC.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DocumentRecordLog.CensusReportNQL_DocRecLogByInOutIncludeCancels_Class dataset_CensusReportNQL_DocRecLogByInOutIncludeCancels = ParentGroup.rsGroup.GetCurrentRecord<DocumentRecordLog.CensusReportNQL_DocRecLogByInOutIncludeCancels_Class>(0);
                    ObjectID.CalcValue = (dataset_CensusReportNQL_DocRecLogByInOutIncludeCancels != null ? Globals.ToStringCore(dataset_CensusReportNQL_DocRecLogByInOutIncludeCancels.Stockactionobjectid) : "");
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    REGISTRATIONNUMBER.CalcValue = @"";
                    AMOUNT.CalcValue = @"";
                    MATERIALNAME.CalcValue = @"";
                    CANCEL.CalcValue = @"";
                    DATE.CalcValue = @"";
                    MHTP.CalcValue = @"";
                    ORDERNO.CalcValue = @"";
                    CILT.CalcValue = @"";
                    TK.CalcValue = @"";
                    EK.CalcValue = @"";
                    PREPAREDBY.CalcValue = @"";
                    DESC.CalcValue = @"";
                    return new TTReportObject[] { ObjectID,COUNT,REGISTRATIONNUMBER,AMOUNT,MATERIALNAME,CANCEL,DATE,MHTP,ORDERNO,CILT,TK,EK,PREPAREDBY,DESC};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            DocumentRecordLog dr = (DocumentRecordLog)ctx.GetObject(new Guid(ObjectID.CalcValue), typeof(DocumentRecordLog).Name);
            StockAction cd = dr.StockAction;
            if(dr.DocumentTransactionType == 0)
            {
                if(cd.StockActionInDetails[0].Material.StockCard == null)
                    return;
                
                BindingList<StockAction.StockActionInDetailsReportQuery_Class> list = StockAction.StockActionInDetailsReportQuery(cd.ObjectID);
                StockAction.StockActionInDetailsReportQuery_Class cdInClass = list[0];
                StockActionDetailIn cdIn = (StockActionDetailIn)ctx.GetObject((Guid)cdInClass.Stockactiondetailobjectid , typeof(StockActionDetailIn).Name);
                PARTBGroup.totalAmount = cd.StockActionInDetails.Count + PARTBGroup.totalAmount;
                AMOUNT.CalcValue = cd.StockActionInDetails.Count.ToString() + " ";
                MATERIALNAME.CalcValue = " " + cdIn.Material.StockCard.NATOStockNO + " | " + cdIn.Amount + " " + cdIn.Material.StockCard.DistributionType.QRef + " | " + cdIn.Material.StockCard.Name;
                REGISTRATIONNUMBER.CalcValue = "G" + dr.DocumentRecordLogNumber.Value.ToString();
            }
            else
            {
                if(cd.StockActionOutDetails[0].Material.StockCard == null)
                    return;
                
                BindingList<StockAction.StockActionOutDetailsReportQuery_Class> list = StockAction.StockActionOutDetailsReportQuery(cd.ObjectID);
                StockAction.StockActionOutDetailsReportQuery_Class cdOutClass = list[0];
                StockActionDetailOut cdOut = (StockActionDetailOut)ctx.GetObject((Guid)cdOutClass.Stockactiondetailobjectid, typeof(StockActionDetailOut).Name);
                PARTBGroup.totalAmount = cd.StockActionOutDetails.Count + PARTBGroup.totalAmount;
                AMOUNT.CalcValue = cd.StockActionOutDetails.Count.ToString() + " ";
                MATERIALNAME.CalcValue = " " + cdOut.Material.StockCard.NATOStockNO + " | " + cdOut.Amount + " " + cdOut.Material.StockCard.DistributionType.QRef + " | " + cdOut.Material.StockCard.Name;
                REGISTRATIONNUMBER.CalcValue = "Ç" + dr.DocumentRecordLogNumber.Value.ToString();
            }
            //EXTRA.CalcValue = cd.AdditionalDocumentCount.ToString();
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

        public Census_DocumentRecordLog()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TERMID", "", "Hesap Dönemini Seçiniz", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("429e41e5-620c-4652-9e24-aa488e0aaaaf");
            reportParameter = Parameters.Add("SIGNS", "", "İmza Bloğu", @"", false, true, false, new Guid("bdf152e5-b22d-423b-99dd-fadf6e6b7686"));
            reportParameter = Parameters.Add("TRANSACTIONTYPE", "", "", @"", false, false, false, new Guid("cf463436-3c34-4659-a92f-d2d0af106485"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TERMID"))
                _runtimeParameters.TERMID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TERMID"]);
            if (parameters.ContainsKey("SIGNS"))
                _runtimeParameters.SIGNS = (string)TTObjectDefManager.Instance.DataTypes["RTF(LongText)"].ConvertValue(parameters["SIGNS"]);
            if (parameters.ContainsKey("TRANSACTIONTYPE"))
                _runtimeParameters.TRANSACTIONTYPE = (string)TTObjectDefManager.Instance.DataTypes["String10"].ConvertValue(parameters["TRANSACTIONTYPE"]);
            Name = "CENSUS_DOCUMENTRECORDLOG";
            Caption = "Stok Devir Belge Dökümleri (Belge Kayıt Kütüğü)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 25;
            UserMarginTop = 15;
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