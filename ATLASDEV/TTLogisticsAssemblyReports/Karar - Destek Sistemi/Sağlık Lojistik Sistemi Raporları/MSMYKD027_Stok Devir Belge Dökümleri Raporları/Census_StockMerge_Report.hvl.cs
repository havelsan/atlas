
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
    /// Stok Devir Belge Dökümleri (Değiş Çizelgesi)
    /// </summary>
    public partial class Census_StockMerge : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TERMID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string SIGNS = (string)TTObjectDefManager.Instance.DataTypes["RTF(LongText)"].ConvertValue("");
            public string TRANSACTIONTYPE = (string)TTObjectDefManager.Instance.DataTypes["String10"].ConvertValue("");
            public string CARDDRAWER = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public Census_StockMerge MyParentReport
            {
                get { return (Census_StockMerge)ParentReport; }
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
                public Census_StockMerge MyParentReport
                {
                    get { return (Census_StockMerge)ParentReport; }
                }
                
                public TTReportField REPORTNAME;
                public TTReportField AdditionNO;
                public TTReportField AccountingTerm;
                public TTReportField AccountYear;
                public TTReportField ENDDATE; 
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
                    AdditionNO.Visible = EvetHayirEnum.ehHayir;
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

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 260, 5, 285, 10, false);
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
                    return new TTReportObject[] { REPORTNAME,AdditionNO,AccountingTerm,AccountYear,ENDDATE};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    string termID = ((Census_StockMerge)ParentReport).RuntimeParameters.TERMID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            AccountingTerm term = (AccountingTerm)ctx.GetObject(new Guid(termID), typeof(AccountingTerm));
            REPORTNAME.CalcValue = Convert.ToDateTime(term.EndDate).Year.ToString() + " YILI DEĞİŞ ÇİZELGESİ";
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public Census_StockMerge MyParentReport
                {
                    get { return (Census_StockMerge)ParentReport; }
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
                    PAGENUMBER.Value = @"{@pagenumber@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PAGENUMBER.CalcValue = ParentReport.CurrentPageNumber.ToString();
                    return new TTReportObject[] { PAGENUMBER};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public Census_StockMerge MyParentReport
            {
                get { return (Census_StockMerge)ParentReport; }
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
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField1211 { get {return Header().NewField1211;} }
            public TTReportField NewField1212 { get {return Header().NewField1212;} }
            public TTReportField NewField12121 { get {return Header().NewField12121;} }
            public TTReportField NewField1213 { get {return Header().NewField1213;} }
            public TTReportField NewField11121 { get {return Header().NewField11121;} }
            public TTReportField NewField112111 { get {return Header().NewField112111;} }
            public TTReportField NewField112112 { get {return Header().NewField112112;} }
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
                public Census_StockMerge MyParentReport
                {
                    get { return (Census_StockMerge)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField112;
                public TTReportField NewField1211;
                public TTReportField NewField1212;
                public TTReportField NewField12121;
                public TTReportField NewField1213;
                public TTReportField NewField11121;
                public TTReportField NewField112111;
                public TTReportField NewField112112; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -1, 0, 9, 5, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"SIRA";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 37, 5, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112.TextFont.Name = "Arial";
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"ESKİ STOK NU.";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 0, 65, 5, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1211.TextFont.Name = "Arial";
                    NewField1211.TextFont.Bold = true;
                    NewField1211.TextFont.CharSet = 162;
                    NewField1211.Value = @"YENİ STOK NU.";

                    NewField1212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 0, 125, 5, false);
                    NewField1212.Name = "NewField1212";
                    NewField1212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1212.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1212.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1212.TextFont.Name = "Arial";
                    NewField1212.TextFont.Bold = true;
                    NewField1212.TextFont.CharSet = 162;
                    NewField1212.Value = @"ESKİ MALZEME ADI";

                    NewField12121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 0, 185, 5, false);
                    NewField12121.Name = "NewField12121";
                    NewField12121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12121.TextFont.Name = "Arial";
                    NewField12121.TextFont.Bold = true;
                    NewField12121.TextFont.CharSet = 162;
                    NewField12121.Value = @"YENİ MALZEME ADI";

                    NewField1213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 0, 205, 5, false);
                    NewField1213.Name = "NewField1213";
                    NewField1213.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1213.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1213.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1213.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1213.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1213.TextFont.Name = "Arial";
                    NewField1213.TextFont.Bold = true;
                    NewField1213.TextFont.CharSet = 162;
                    NewField1213.Value = @"ESKİ FİYAT";

                    NewField11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 0, 225, 5, false);
                    NewField11121.Name = "NewField11121";
                    NewField11121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11121.TextFont.Name = "Arial";
                    NewField11121.TextFont.Bold = true;
                    NewField11121.TextFont.CharSet = 162;
                    NewField11121.Value = @"YENİ FİYAT";

                    NewField112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 225, 0, 249, 5, false);
                    NewField112111.Name = "NewField112111";
                    NewField112111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112111.TextFont.Name = "Arial";
                    NewField112111.TextFont.Bold = true;
                    NewField112111.TextFont.CharSet = 162;
                    NewField112111.Value = @"TARİH";

                    NewField112112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 0, 257, 5, false);
                    NewField112112.Name = "NewField112112";
                    NewField112112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112112.TextFont.Name = "Arial";
                    NewField112112.TextFont.Bold = true;
                    NewField112112.TextFont.CharSet = 162;
                    NewField112112.Value = @"ÖB";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField1212.CalcValue = NewField1212.Value;
                    NewField12121.CalcValue = NewField12121.Value;
                    NewField1213.CalcValue = NewField1213.Value;
                    NewField11121.CalcValue = NewField11121.Value;
                    NewField112111.CalcValue = NewField112111.Value;
                    NewField112112.CalcValue = NewField112112.Value;
                    return new TTReportObject[] { NewField11,NewField112,NewField1211,NewField1212,NewField12121,NewField1213,NewField11121,NewField112111,NewField112112};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public Census_StockMerge MyParentReport
                {
                    get { return (Census_StockMerge)ParentReport; }
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

                    Height = 82;
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

                    TEFTIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 265, 19, 294, 24, false);
                    TEFTIS.Name = "TEFTIS";
                    TEFTIS.Visible = EvetHayirEnum.ehHayir;
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

                    COUNTTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -1, 3, 257, 8, false);
                    COUNTTEXT.Name = "COUNTTEXT";
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

                    SIGNS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 10, 257, 79, false);
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
            
            string termID = ((Census_StockMerge)ParentReport).RuntimeParameters.TERMID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            AccountingTerm term = (AccountingTerm)ctx.GetObject(new Guid(termID), typeof(AccountingTerm));
            if(term.EndDate != null)
            {
                //TEFTIS.CalcValue = Convert.ToDateTime(term.EndDate).Year.ToString() + " yılına ait Belge Kayıt Kütüğüne toplam " + SUBGROUPCOUNT.FormattedValue + " adet belgenin kaydedilmiş olduğu görüşmüştür.";
//                    + ACCOUNTANCYNAME.FormattedValue + " saymanlığının " + 
//                    + " bütçe yılı teftişinde saymandan alınarak teftiş sandığına konulmuştur.";
            }
            COUNTTEXT.CalcValue = "///////////YALNIZ " + SUBGROUPCOUNT.FormattedValue + " (" + SUBGROUPCOUNTTEXT.FormattedValue.ToUpper() + ") ADET BELGE///////////";
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
            public Census_StockMerge MyParentReport
            {
                get { return (Census_StockMerge)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ObjectID { get {return Body().ObjectID;} }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField DATE { get {return Body().DATE;} }
            public TTReportField OB { get {return Body().OB;} }
            public TTReportField OLDPRICE { get {return Body().OLDPRICE;} }
            public TTReportField NEWPRICE { get {return Body().NEWPRICE;} }
            public TTReportField OLDNSN { get {return Body().OLDNSN;} }
            public TTReportField NEWNSN { get {return Body().NEWNSN;} }
            public TTReportField OLDSTOCKCARD { get {return Body().OLDSTOCKCARD;} }
            public TTReportField NEWSTOCKCARD { get {return Body().NEWSTOCKCARD;} }
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
                list[0] = new TTReportNqlData<StockMerge.CensusReportNQL_StockMerge_Class>("CensusReportNQL_StockMerge2", StockMerge.CensusReportNQL_StockMerge((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TERMID),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.CARDDRAWER)));
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
                public Census_StockMerge MyParentReport
                {
                    get { return (Census_StockMerge)ParentReport; }
                }
                
                public TTReportField ObjectID;
                public TTReportField COUNT;
                public TTReportField DATE;
                public TTReportField OB;
                public TTReportField OLDPRICE;
                public TTReportField NEWPRICE;
                public TTReportField OLDNSN;
                public TTReportField NEWNSN;
                public TTReportField OLDSTOCKCARD;
                public TTReportField NEWSTOCKCARD; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    ObjectID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 0, 328, 5, false);
                    ObjectID.Name = "ObjectID";
                    ObjectID.Visible = EvetHayirEnum.ehHayir;
                    ObjectID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ObjectID.Value = @"{#OBJECTID#}";

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 9, 5, false);
                    COUNT.Name = "COUNT";
                    COUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.TextFont.Name = "Arial";
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{@counter@}";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 225, 0, 249, 5, false);
                    DATE.Name = "DATE";
                    DATE.DrawStyle = DrawStyleConstants.vbSolid;
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"dd/MM/yyyy";
                    DATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DATE.TextFont.Name = "Arial";
                    DATE.TextFont.CharSet = 162;
                    DATE.Value = @"";

                    OB = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 0, 257, 5, false);
                    OB.Name = "OB";
                    OB.DrawStyle = DrawStyleConstants.vbSolid;
                    OB.FieldType = ReportFieldTypeEnum.ftVariable;
                    OB.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OB.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OB.TextFont.Name = "Arial";
                    OB.TextFont.CharSet = 162;
                    OB.Value = @"";

                    OLDPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 0, 205, 5, false);
                    OLDPRICE.Name = "OLDPRICE";
                    OLDPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    OLDPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDPRICE.TextFormat = @"#,##0.0#";
                    OLDPRICE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OLDPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLDPRICE.TextFont.Name = "Arial";
                    OLDPRICE.TextFont.CharSet = 162;
                    OLDPRICE.Value = @"";

                    NEWPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 0, 225, 5, false);
                    NEWPRICE.Name = "NEWPRICE";
                    NEWPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWPRICE.TextFormat = @"#,##0.0#";
                    NEWPRICE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NEWPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEWPRICE.TextFont.Name = "Arial";
                    NEWPRICE.TextFont.CharSet = 162;
                    NEWPRICE.Value = @"";

                    OLDNSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 37, 5, false);
                    OLDNSN.Name = "OLDNSN";
                    OLDNSN.DrawStyle = DrawStyleConstants.vbSolid;
                    OLDNSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDNSN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OLDNSN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLDNSN.TextFont.Name = "Arial";
                    OLDNSN.TextFont.CharSet = 162;
                    OLDNSN.Value = @"";

                    NEWNSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 0, 65, 5, false);
                    NEWNSN.Name = "NEWNSN";
                    NEWNSN.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWNSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWNSN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NEWNSN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEWNSN.TextFont.Name = "Arial";
                    NEWNSN.TextFont.CharSet = 162;
                    NEWNSN.Value = @"";

                    OLDSTOCKCARD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 0, 125, 5, false);
                    OLDSTOCKCARD.Name = "OLDSTOCKCARD";
                    OLDSTOCKCARD.DrawStyle = DrawStyleConstants.vbSolid;
                    OLDSTOCKCARD.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDSTOCKCARD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLDSTOCKCARD.MultiLine = EvetHayirEnum.ehEvet;
                    OLDSTOCKCARD.WordBreak = EvetHayirEnum.ehEvet;
                    OLDSTOCKCARD.TextFont.Name = "Arial";
                    OLDSTOCKCARD.TextFont.CharSet = 162;
                    OLDSTOCKCARD.Value = @"";

                    NEWSTOCKCARD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 0, 185, 5, false);
                    NEWSTOCKCARD.Name = "NEWSTOCKCARD";
                    NEWSTOCKCARD.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWSTOCKCARD.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWSTOCKCARD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEWSTOCKCARD.MultiLine = EvetHayirEnum.ehEvet;
                    NEWSTOCKCARD.WordBreak = EvetHayirEnum.ehEvet;
                    NEWSTOCKCARD.TextFont.Name = "Arial";
                    NEWSTOCKCARD.TextFont.CharSet = 162;
                    NEWSTOCKCARD.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockMerge.CensusReportNQL_StockMerge_Class dataset_CensusReportNQL_StockMerge2 = ParentGroup.rsGroup.GetCurrentRecord<StockMerge.CensusReportNQL_StockMerge_Class>(0);
                    ObjectID.CalcValue = (dataset_CensusReportNQL_StockMerge2 != null ? Globals.ToStringCore(dataset_CensusReportNQL_StockMerge2.ObjectID) : "");
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    DATE.CalcValue = @"";
                    OB.CalcValue = @"";
                    OLDPRICE.CalcValue = @"";
                    NEWPRICE.CalcValue = @"";
                    OLDNSN.CalcValue = @"";
                    NEWNSN.CalcValue = @"";
                    OLDSTOCKCARD.CalcValue = @"";
                    NEWSTOCKCARD.CalcValue = @"";
                    return new TTReportObject[] { ObjectID,COUNT,DATE,OB,OLDPRICE,NEWPRICE,OLDNSN,NEWNSN,OLDSTOCKCARD,NEWSTOCKCARD};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            StockAction cd = (StockAction)ctx.GetObject(new Guid(ObjectID.CalcValue), typeof(StockAction).Name);
            if(cd.StockActionDetails.Count > 0)
            {
                PARTBGroup.totalAmount = cd.StockActionDetails.Count + PARTBGroup.totalAmount;
                if(cd.StockActionOutDetails.Count > 0 && cd.StockActionInDetails.Count > 0)
                {
                    if(cd.StockActionOutDetails[0].Material.StockCard == null || cd.StockActionInDetails[0].Material.StockCard == null)
                        return;
                    OLDSTOCKCARD.CalcValue = cd.StockActionOutDetails[0].Material.StockCard.Name;
                    NEWSTOCKCARD.CalcValue = cd.StockActionInDetails[0].Material.StockCard.Name;
                    OLDNSN.CalcValue = cd.StockActionOutDetails[0].Material.StockCard.NATOStockNO;
                    NEWNSN.CalcValue = cd.StockActionInDetails[0].Material.StockCard.NATOStockNO;
                    DATE.CalcValue = cd.TransactionDate.ToString();
                }
            }
            
            double inCardPrice = 0;
            double outCardPrice = 0;
            foreach(StockActionDetailOut sout in cd.StockActionOutDetails)
                outCardPrice += Convert.ToDouble(sout.Amount) * Convert.ToDouble(sout.UnitPrice);
            
            foreach(StockActionDetailIn sin in cd.StockActionInDetails)
                inCardPrice += Convert.ToDouble(sin.Amount) * Convert.ToDouble(sin.UnitPrice);

            OLDPRICE.CalcValue = (outCardPrice / cd.StockActionOutDetails.Count).ToString();
            NEWPRICE.CalcValue = (inCardPrice / cd.StockActionInDetails.Count).ToString();
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

        public Census_StockMerge()
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
            reportParameter = Parameters.Add("CARDDRAWER", "", "Masa", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("03e2de85-a832-4760-a20c-e921071b5c37");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TERMID"))
                _runtimeParameters.TERMID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TERMID"]);
            if (parameters.ContainsKey("SIGNS"))
                _runtimeParameters.SIGNS = (string)TTObjectDefManager.Instance.DataTypes["RTF(LongText)"].ConvertValue(parameters["SIGNS"]);
            if (parameters.ContainsKey("TRANSACTIONTYPE"))
                _runtimeParameters.TRANSACTIONTYPE = (string)TTObjectDefManager.Instance.DataTypes["String10"].ConvertValue(parameters["TRANSACTIONTYPE"]);
            if (parameters.ContainsKey("CARDDRAWER"))
                _runtimeParameters.CARDDRAWER = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["CARDDRAWER"]);
            Name = "CENSUS_STOCKMERGE";
            Caption = "Stok Devir Belge Dökümleri (Değiş Çizelgesi)";
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