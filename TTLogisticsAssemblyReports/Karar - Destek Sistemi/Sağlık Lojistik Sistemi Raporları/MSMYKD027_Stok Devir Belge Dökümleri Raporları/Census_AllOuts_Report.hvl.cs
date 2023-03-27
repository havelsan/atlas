
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
    /// Stok Devir Belge Dökümleri (Çıkış Belgeleri Dökümleri EK-129B)
    /// </summary>
    public partial class Census_AllOuts : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TERMID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public Census_AllOuts MyParentReport
            {
                get { return (Census_AllOuts)ParentReport; }
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
            public TTReportField AdditionNO11 { get {return Header().AdditionNO11;} }
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
                public Census_AllOuts MyParentReport
                {
                    get { return (Census_AllOuts)ParentReport; }
                }
                
                public TTReportField REPORTNAME;
                public TTReportField AdditionNO;
                public TTReportField AccountingTerm;
                public TTReportField AccountYear;
                public TTReportField ENDDATE;
                public TTReportField AdditionNO11; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 29;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -3, 11, 188, 29, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 12;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"ÇIKIŞ BELGELERİ DÖKÜM ÇİZELGESİ";

                    AdditionNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 0, 254, 5, false);
                    AdditionNO.Name = "AdditionNO";
                    AdditionNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AdditionNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AdditionNO.TextFont.Name = "Arial";
                    AdditionNO.TextFont.Bold = true;
                    AdditionNO.TextFont.CharSet = 162;
                    AdditionNO.Value = @"";

                    AccountingTerm = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 300, 0, 325, 5, false);
                    AccountingTerm.Name = "AccountingTerm";
                    AccountingTerm.Visible = EvetHayirEnum.ehHayir;
                    AccountingTerm.FieldType = ReportFieldTypeEnum.ftVariable;
                    AccountingTerm.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AccountingTerm.ObjectDefName = "AccountingTerm";
                    AccountingTerm.DataMember = "STARTDATE";
                    AccountingTerm.Value = @"{@TERMID@}";

                    AccountYear = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 300, 5, 325, 10, false);
                    AccountYear.Name = "AccountYear";
                    AccountYear.Visible = EvetHayirEnum.ehHayir;
                    AccountYear.FieldType = ReportFieldTypeEnum.ftVariable;
                    AccountYear.Value = @"";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 6, 188, 11, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ENDDATE.ObjectDefName = "AccountingTerm";
                    ENDDATE.DataMember = "ENDDATE";
                    ENDDATE.TextFont.Name = "Arial";
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@TERMID@}";

                    AdditionNO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 1, 188, 6, false);
                    AdditionNO11.Name = "AdditionNO11";
                    AdditionNO11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AdditionNO11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AdditionNO11.TextFont.Name = "Arial";
                    AdditionNO11.TextFont.Bold = true;
                    AdditionNO11.TextFont.CharSet = 162;
                    AdditionNO11.Value = @"EK-129B";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    AdditionNO.CalcValue = AdditionNO.Value;
                    AccountingTerm.CalcValue = MyParentReport.RuntimeParameters.TERMID.ToString();
                    AccountingTerm.PostFieldValueCalculation();
                    AccountYear.CalcValue = @"";
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.TERMID.ToString();
                    ENDDATE.PostFieldValueCalculation();
                    AdditionNO11.CalcValue = AdditionNO11.Value;
                    return new TTReportObject[] { REPORTNAME,AdditionNO,AccountingTerm,AccountYear,ENDDATE,AdditionNO11};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public Census_AllOuts MyParentReport
                {
                    get { return (Census_AllOuts)ParentReport; }
                }
                
                public TTReportField PAGENUMBER; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -2, 1, 188, 6, false);
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
            public Census_AllOuts MyParentReport
            {
                get { return (Census_AllOuts)ParentReport; }
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
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField NewField12221 { get {return Header().NewField12221;} }
            public TTReportField NewField13221 { get {return Header().NewField13221;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField TOTAL { get {return Footer().TOTAL;} }
            public TTReportField TEFTIS { get {return Footer().TEFTIS;} }
            public TTReportField SUBGROUPCOUNT { get {return Footer().SUBGROUPCOUNT;} }
            public TTReportField PAGECOUNT { get {return Footer().PAGECOUNT;} }
            public TTReportField AMOUNTTEXT { get {return Footer().AMOUNTTEXT;} }
            public TTReportField ACCOUNTANCYNAME { get {return Footer().ACCOUNTANCYNAME;} }
            public TTReportField COUNTTEXT { get {return Footer().COUNTTEXT;} }
            public TTReportField SUBGROUPCOUNTTEXT { get {return Footer().SUBGROUPCOUNTTEXT;} }
            public TTReportField NewField11121111 { get {return Footer().NewField11121111;} }
            public TTReportField NewField111112111 { get {return Footer().NewField111112111;} }
            public TTReportField NewField113111121111 { get {return Footer().NewField113111121111;} }
            public TTReportField TEXT116543211 { get {return Footer().TEXT116543211;} }
            public TTReportField SAYMAN { get {return Footer().SAYMAN;} }
            public TTReportField HESAPSORUMLUSU { get {return Footer().HESAPSORUMLUSU;} }
            public TTReportField BIRLIKXXXXXXI { get {return Footer().BIRLIKXXXXXXI;} }
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
                public Census_AllOuts MyParentReport
                {
                    get { return (Census_AllOuts)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField1221;
                public TTReportField NewField12221;
                public TTReportField NewField13221;
                public TTReportField NewField111; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 10;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -3, 0, 9, 10, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"SIRA NU.";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 33, 10, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1221.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField1221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1221.TextFont.Name = "Arial";
                    NewField1221.TextFont.Size = 11;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @"BELGE KAYIT NU.";

                    NewField12221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 0, 176, 10, false);
                    NewField12221.Name = "NewField12221";
                    NewField12221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12221.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField12221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12221.TextFont.Name = "Arial";
                    NewField12221.TextFont.Size = 11;
                    NewField12221.TextFont.Bold = true;
                    NewField12221.TextFont.CharSet = 162;
                    NewField12221.Value = @"KALEM ADEDİ";

                    NewField13221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 0, 158, 10, false);
                    NewField13221.Name = "NewField13221";
                    NewField13221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13221.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField13221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13221.TextFont.Name = "Arial";
                    NewField13221.TextFont.Size = 11;
                    NewField13221.TextFont.Bold = true;
                    NewField13221.TextFont.CharSet = 162;
                    NewField13221.Value = @"BİRİNCİ KALEM MALZEMENİN CİNSİ";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 0, 188, 10, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 11;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"EKİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField12221.CalcValue = NewField12221.Value;
                    NewField13221.CalcValue = NewField13221.Value;
                    NewField111.CalcValue = NewField111.Value;
                    return new TTReportObject[] { NewField11,NewField1221,NewField12221,NewField13221,NewField111};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public Census_AllOuts MyParentReport
                {
                    get { return (Census_AllOuts)ParentReport; }
                }
                
                public TTReportField TOTAL;
                public TTReportField TEFTIS;
                public TTReportField SUBGROUPCOUNT;
                public TTReportField PAGECOUNT;
                public TTReportField AMOUNTTEXT;
                public TTReportField ACCOUNTANCYNAME;
                public TTReportField COUNTTEXT;
                public TTReportField SUBGROUPCOUNTTEXT;
                public TTReportField NewField11121111;
                public TTReportField NewField111112111;
                public TTReportField NewField113111121111;
                public TTReportField TEXT116543211;
                public TTReportField SAYMAN;
                public TTReportField HESAPSORUMLUSU;
                public TTReportField BIRLIKXXXXXXI; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 67;
                    RepeatCount = 0;
                    
                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -3, 7, 188, 12, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTAL.TextFont.Name = "Arial";
                    TOTAL.TextFont.CharSet = 162;
                    TOTAL.Value = @"";

                    TEFTIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -4, 13, 188, 25, false);
                    TEFTIS.Name = "TEFTIS";
                    TEFTIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEFTIS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEFTIS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEFTIS.MultiLine = EvetHayirEnum.ehEvet;
                    TEFTIS.WordBreak = EvetHayirEnum.ehEvet;
                    TEFTIS.TextFont.Name = "Arial";
                    TEFTIS.TextFont.CharSet = 162;
                    TEFTIS.Value = @"";

                    SUBGROUPCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 324, 1, 349, 6, false);
                    SUBGROUPCOUNT.Name = "SUBGROUPCOUNT";
                    SUBGROUPCOUNT.Visible = EvetHayirEnum.ehHayir;
                    SUBGROUPCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBGROUPCOUNT.Value = @"{@subgroupcount@}";

                    PAGECOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 324, 6, 349, 11, false);
                    PAGECOUNT.Name = "PAGECOUNT";
                    PAGECOUNT.Visible = EvetHayirEnum.ehHayir;
                    PAGECOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGECOUNT.Value = @"{@pagecount@}";

                    AMOUNTTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 299, 1, 324, 6, false);
                    AMOUNTTEXT.Name = "AMOUNTTEXT";
                    AMOUNTTEXT.Visible = EvetHayirEnum.ehHayir;
                    AMOUNTTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNTTEXT.CaseFormat = CaseFormatEnum.fcUpperCase;
                    AMOUNTTEXT.TextFormat = @"NUMBERTEXT";
                    AMOUNTTEXT.Value = @"";

                    ACCOUNTANCYNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 299, 6, 324, 11, false);
                    ACCOUNTANCYNAME.Name = "ACCOUNTANCYNAME";
                    ACCOUNTANCYNAME.Visible = EvetHayirEnum.ehHayir;
                    ACCOUNTANCYNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCOUNTANCYNAME.ObjectDefName = "AccountingTerm";
                    ACCOUNTANCYNAME.DataMember = "ACCOUNTANCY.NAME";
                    ACCOUNTANCYNAME.Value = @"{@TERMID@}";

                    COUNTTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -3, 1, 188, 6, false);
                    COUNTTEXT.Name = "COUNTTEXT";
                    COUNTTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTTEXT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNTTEXT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNTTEXT.TextFont.Name = "Arial";
                    COUNTTEXT.TextFont.CharSet = 162;
                    COUNTTEXT.Value = @"";

                    SUBGROUPCOUNTTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 299, 11, 324, 16, false);
                    SUBGROUPCOUNTTEXT.Name = "SUBGROUPCOUNTTEXT";
                    SUBGROUPCOUNTTEXT.Visible = EvetHayirEnum.ehHayir;
                    SUBGROUPCOUNTTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBGROUPCOUNTTEXT.TextFormat = @"NUMBERTEXT";
                    SUBGROUPCOUNTTEXT.Value = @"";

                    NewField11121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 52, 56, 62, false);
                    NewField11121111.Name = "NewField11121111";
                    NewField11121111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11121111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11121111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11121111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11121111.TextFont.Name = "Arial";
                    NewField11121111.TextFont.Bold = true;
                    NewField11121111.TextFont.CharSet = 162;
                    NewField11121111.Value = @"Sayman";

                    NewField111112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 52, 165, 61, false);
                    NewField111112111.Name = "NewField111112111";
                    NewField111112111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111112111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111112111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111112111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111112111.TextFont.Name = "Arial";
                    NewField111112111.TextFont.Bold = true;
                    NewField111112111.TextFont.CharSet = 162;
                    NewField111112111.Value = @"Hesap Sorumlusu";

                    NewField113111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 52, 116, 62, false);
                    NewField113111121111.Name = "NewField113111121111";
                    NewField113111121111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113111121111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113111121111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113111121111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113111121111.TextFont.Name = "Arial";
                    NewField113111121111.TextFont.Bold = true;
                    NewField113111121111.TextFont.CharSet = 162;
                    NewField113111121111.Value = @"Birlik XXXXXXı";

                    TEXT116543211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -3, 30, 31, 67, false);
                    TEXT116543211.Name = "TEXT116543211";
                    TEXT116543211.Visible = EvetHayirEnum.ehHayir;
                    TEXT116543211.MultiLine = EvetHayirEnum.ehEvet;
                    TEXT116543211.WordBreak = EvetHayirEnum.ehEvet;
                    TEXT116543211.TextFont.Size = 11;
                    TEXT116543211.TextFont.Bold = true;
                    TEXT116543211.TextFont.CharSet = 162;
                    TEXT116543211.Value = @"İmza ve Mühür
Adı ve Soyadı
Sınıfı ve Rütbesi
Görevi		
";

                    SAYMAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 36, 81, 52, false);
                    SAYMAN.Name = "SAYMAN";
                    SAYMAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAYMAN.MultiLine = EvetHayirEnum.ehEvet;
                    SAYMAN.WordBreak = EvetHayirEnum.ehEvet;
                    SAYMAN.Value = @"";

                    HESAPSORUMLUSU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 36, 180, 52, false);
                    HESAPSORUMLUSU.Name = "HESAPSORUMLUSU";
                    HESAPSORUMLUSU.FieldType = ReportFieldTypeEnum.ftVariable;
                    HESAPSORUMLUSU.MultiLine = EvetHayirEnum.ehEvet;
                    HESAPSORUMLUSU.WordBreak = EvetHayirEnum.ehEvet;
                    HESAPSORUMLUSU.Value = @"";

                    BIRLIKXXXXXXI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 36, 131, 52, false);
                    BIRLIKXXXXXXI.Name = "BIRLIKXXXXXXI";
                    BIRLIKXXXXXXI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIKXXXXXXI.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIKXXXXXXI.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIKXXXXXXI.Value = @"";

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
                    NewField11121111.CalcValue = NewField11121111.Value;
                    NewField111112111.CalcValue = NewField111112111.Value;
                    NewField113111121111.CalcValue = NewField113111121111.Value;
                    TEXT116543211.CalcValue = TEXT116543211.Value;
                    SAYMAN.CalcValue = @"";
                    HESAPSORUMLUSU.CalcValue = @"";
                    BIRLIKXXXXXXI.CalcValue = @"";
                    return new TTReportObject[] { TOTAL,TEFTIS,SUBGROUPCOUNT,PAGECOUNT,AMOUNTTEXT,ACCOUNTANCYNAME,COUNTTEXT,SUBGROUPCOUNTTEXT,NewField11121111,NewField111112111,NewField113111121111,TEXT116543211,SAYMAN,HESAPSORUMLUSU,BIRLIKXXXXXXI};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    AMOUNTTEXT.CalcValue = PARTBGroup.totalAmount.ToString();
            SUBGROUPCOUNTTEXT.CalcValue = SUBGROUPCOUNT.CalcValue;
            TOTAL.CalcValue = "///////////YALNIZ " + PARTBGroup.totalAmount.ToString() +" (" + AMOUNTTEXT.FormattedValue + ") KALEMDİR///////////";
            PARTBGroup.totalAmount = 0;
            
            string termID = ((Census_AllOuts)ParentReport).RuntimeParameters.TERMID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            AccountingTerm term = (AccountingTerm)ctx.GetObject(new Guid(termID), typeof(AccountingTerm));
            if(term.EndDate != null)
            {
                TEFTIS.CalcValue = "Yukarıda cinsi belirtilen toplam " + SUBGROUPCOUNT.FormattedValue + " adet Çıkış Belgelerini "
                    + ACCOUNTANCYNAME.FormattedValue + "nın " + Convert.ToDateTime(term.EndDate).Year.ToString()
                   + " yılı bütçe teftişinde müfettişler tarafından arşivlenmek üzere saymanlığa bırakılmıştır.";
                 
                
            }
            COUNTTEXT.CalcValue = "///////////YALNIZ " + SUBGROUPCOUNT.FormattedValue + " (" + SUBGROUPCOUNTTEXT.FormattedValue.ToUpper() + ") ADET BELGE///////////";
            
            
             IList checkStockCensusActions = ctx.QueryObjects("CHECKSTOCKCENSUSACTION","ACCOUNTINGTERM=" + ConnectionManager.GuidToString(term.ObjectID));
            if(checkStockCensusActions.Count > 0)
            {
                CheckStockCensusAction checkStockCensusAction = (CheckStockCensusAction)checkStockCensusActions[0];
                
                SAYMAN.CalcValue =  checkStockCensusAction.SingOfCensusAction(SignUserTypeEnum.MalSaymani);
                BIRLIKXXXXXXI.CalcValue = checkStockCensusAction.SingOfCensusAction(SignUserTypeEnum.BirlikXXXXXXi);

                
                if(term.Accountancy.MainStores.Count > 0)
                {
                    if(term.Accountancy.MainStores[0].AccountManager != null)
                     HESAPSORUMLUSU.CalcValue = term.Accountancy.MainStores[0].AccountManager.Name+"\n"+term.Accountancy.MainStores[0].AccountManager.MilitaryClass+  " - "  + term.Accountancy.MainStores[0].AccountManager.Rank ;
                }
                
//                
//                MainStoreDefinition msd = new MainStoreDefinition(ctx);
//                if(msd.AccountManager != null)
//                {
//                    HESAPSORUMLUSU.CalcValue = msd.AccountManager.Name;
//                }
            }
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
            public Census_AllOuts MyParentReport
            {
                get { return (Census_AllOuts)ParentReport; }
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
            public TTReportField EXTRA { get {return Body().EXTRA;} }
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
                list[0] = new TTReportNqlData<DocumentRecordLog.CensusReportNQL_DocRecLogByInOutIncludeCancels_Class>("CensusReportNQL_DocumentRecLog", DocumentRecordLog.CensusReportNQL_DocRecLogByInOutIncludeCancels((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TERMID),(string)TTObjectDefManager.Instance.DataTypes["String10"].ConvertValue(@"1")));
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
                public Census_AllOuts MyParentReport
                {
                    get { return (Census_AllOuts)ParentReport; }
                }
                
                public TTReportField ObjectID;
                public TTReportField COUNT;
                public TTReportField REGISTRATIONNUMBER;
                public TTReportField AMOUNT;
                public TTReportField MATERIALNAME;
                public TTReportField EXTRA; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 10;
                    RepeatCount = 0;
                    
                    ObjectID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 300, 0, 325, 5, false);
                    ObjectID.Name = "ObjectID";
                    ObjectID.Visible = EvetHayirEnum.ehHayir;
                    ObjectID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ObjectID.MultiLine = EvetHayirEnum.ehEvet;
                    ObjectID.WordBreak = EvetHayirEnum.ehEvet;
                    ObjectID.TextFont.CharSet = 162;
                    ObjectID.Value = @"{#OBJECTID#}";

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -3, 0, 9, 10, false);
                    COUNT.Name = "COUNT";
                    COUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.MultiLine = EvetHayirEnum.ehEvet;
                    COUNT.WordBreak = EvetHayirEnum.ehEvet;
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{@counter@}";

                    REGISTRATIONNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 33, 10, false);
                    REGISTRATIONNUMBER.Name = "REGISTRATIONNUMBER";
                    REGISTRATIONNUMBER.DrawStyle = DrawStyleConstants.vbSolid;
                    REGISTRATIONNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    REGISTRATIONNUMBER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REGISTRATIONNUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REGISTRATIONNUMBER.MultiLine = EvetHayirEnum.ehEvet;
                    REGISTRATIONNUMBER.WordBreak = EvetHayirEnum.ehEvet;
                    REGISTRATIONNUMBER.TextFont.CharSet = 162;
                    REGISTRATIONNUMBER.Value = @"";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 0, 176, 10, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFormat = @"#,###";
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    AMOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 0, 158, 10, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"";

                    EXTRA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 0, 188, 10, false);
                    EXTRA.Name = "EXTRA";
                    EXTRA.DrawStyle = DrawStyleConstants.vbSolid;
                    EXTRA.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXTRA.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EXTRA.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EXTRA.MultiLine = EvetHayirEnum.ehEvet;
                    EXTRA.WordBreak = EvetHayirEnum.ehEvet;
                    EXTRA.TextFont.CharSet = 162;
                    EXTRA.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DocumentRecordLog.CensusReportNQL_DocRecLogByInOutIncludeCancels_Class dataset_CensusReportNQL_DocumentRecLog = ParentGroup.rsGroup.GetCurrentRecord<DocumentRecordLog.CensusReportNQL_DocRecLogByInOutIncludeCancels_Class>(0);
                    ObjectID.CalcValue = (dataset_CensusReportNQL_DocumentRecLog != null ? Globals.ToStringCore(dataset_CensusReportNQL_DocumentRecLog.ObjectID) : "");
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    REGISTRATIONNUMBER.CalcValue = @"";
                    AMOUNT.CalcValue = @"";
                    MATERIALNAME.CalcValue = @"";
                    EXTRA.CalcValue = @"";
                    return new TTReportObject[] { ObjectID,COUNT,REGISTRATIONNUMBER,AMOUNT,MATERIALNAME,EXTRA};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            DocumentRecordLog dr = (DocumentRecordLog)ctx.GetObject(new Guid(ObjectID.CalcValue), typeof(DocumentRecordLog).Name);
            StockAction cd = dr.StockAction;
            if(cd.StockActionOutDetails.Count > 0)
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
                EXTRA.CalcValue = cd.AdditionalDocumentCount.ToString();
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

        public Census_AllOuts()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TERMID", "", "Hesap Dönemini Seçiniz", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("429e41e5-620c-4652-9e24-aa488e0aaaaf");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TERMID"))
                _runtimeParameters.TERMID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TERMID"]);
            Name = "CENSUS_ALLOUTS";
            Caption = "Stok Devir Belge Dökümleri (Çıkış Belgeleri Dökümleri EK-129B)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            UserMarginLeft = 15;
            UserMarginTop = 10;
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