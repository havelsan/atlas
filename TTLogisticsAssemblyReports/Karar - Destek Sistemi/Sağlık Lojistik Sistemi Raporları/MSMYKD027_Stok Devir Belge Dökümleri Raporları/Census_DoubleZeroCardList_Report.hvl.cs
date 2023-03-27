
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
    /// Stok Devir Belge Dökümleri (Çift Sıfırlı Çizelgesi EK-26A)
    /// </summary>
    public partial class Census_DoubleZeroCardList : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TERMID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string CARDDRAWER = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public Census_DoubleZeroCardList MyParentReport
            {
                get { return (Census_DoubleZeroCardList)ParentReport; }
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
            public TTReportField AdditionNO111 { get {return Header().AdditionNO111;} }
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
                public Census_DoubleZeroCardList MyParentReport
                {
                    get { return (Census_DoubleZeroCardList)ParentReport; }
                }
                
                public TTReportField REPORTNAME;
                public TTReportField AdditionNO;
                public TTReportField AccountingTerm;
                public TTReportField AccountYear;
                public TTReportField ENDDATE;
                public TTReportField AdditionNO111; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 37;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 12, 181, 30, false);
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

                    AdditionNO111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 6, 181, 11, false);
                    AdditionNO111.Name = "AdditionNO111";
                    AdditionNO111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AdditionNO111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AdditionNO111.TextFont.Name = "Arial";
                    AdditionNO111.TextFont.Bold = true;
                    AdditionNO111.TextFont.CharSet = 162;
                    AdditionNO111.Value = @"EK-26A";

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
                    AdditionNO111.CalcValue = AdditionNO111.Value;
                    return new TTReportObject[] { REPORTNAME,AdditionNO,AccountingTerm,AccountYear,ENDDATE,AdditionNO111};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    string termID = ((Census_DoubleZeroCardList)ParentReport).RuntimeParameters.TERMID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            AccountingTerm term = (AccountingTerm)ctx.GetObject(new Guid(termID), typeof(AccountingTerm));
            REPORTNAME.CalcValue = Convert.ToDateTime(term.EndDate).Year.ToString() + " YILI STOK KAYIT KARTI ÇİFT SIFIR ÇİZELGESİ";
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public Census_DoubleZeroCardList MyParentReport
                {
                    get { return (Census_DoubleZeroCardList)ParentReport; }
                }
                
                public TTReportField PAGENUMBER; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 181, 5, false);
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
            public Census_DoubleZeroCardList MyParentReport
            {
                get { return (Census_DoubleZeroCardList)ParentReport; }
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
            public TTReportField NewField12121 { get {return Header().NewField12121;} }
            public TTReportField TOTAL { get {return Footer().TOTAL;} }
            public TTReportField TEFTIS { get {return Footer().TEFTIS;} }
            public TTReportField SUBGROUPCOUNT { get {return Footer().SUBGROUPCOUNT;} }
            public TTReportField PAGECOUNT { get {return Footer().PAGECOUNT;} }
            public TTReportField AMOUNTTEXT { get {return Footer().AMOUNTTEXT;} }
            public TTReportField ACCOUNTANCYNAME { get {return Footer().ACCOUNTANCYNAME;} }
            public TTReportField COUNTTEXT { get {return Footer().COUNTTEXT;} }
            public TTReportField SUBGROUPCOUNTTEXT { get {return Footer().SUBGROUPCOUNTTEXT;} }
            public TTReportField SAYMAN { get {return Footer().SAYMAN;} }
            public TTReportField HESAPSORUMLUSU { get {return Footer().HESAPSORUMLUSU;} }
            public TTReportField TKM { get {return Footer().TKM;} }
            public TTReportField TKB { get {return Footer().TKB;} }
            public TTReportField NewField11121 { get {return Footer().NewField11121;} }
            public TTReportField NewField112111 { get {return Footer().NewField112111;} }
            public TTReportField NewField1111211 { get {return Footer().NewField1111211;} }
            public TTReportField NewField111211113 { get {return Footer().NewField111211113;} }
            public TTReportField TEXT123456 { get {return Footer().TEXT123456;} }
            public TTReportField BIRLIKXXXXXXI { get {return Footer().BIRLIKXXXXXXI;} }
            public TTReportField NewField1111212 { get {return Footer().NewField1111212;} }
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
                public Census_DoubleZeroCardList MyParentReport
                {
                    get { return (Census_DoubleZeroCardList)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField112;
                public TTReportField NewField1211;
                public TTReportField NewField12121; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 9;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, -1, 9, 9, false);
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

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, -1, 37, 9, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112.TextFont.Name = "Arial";
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"ESKİ DEVİR SIRA NU.";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, -1, 75, 9, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1211.TextFont.Name = "Arial";
                    NewField1211.TextFont.Bold = true;
                    NewField1211.TextFont.CharSet = 162;
                    NewField1211.Value = @"STOK NUMARASI";

                    NewField12121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, -1, 181, 9, false);
                    NewField12121.Name = "NewField12121";
                    NewField12121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12121.TextFont.Name = "Arial";
                    NewField12121.TextFont.Bold = true;
                    NewField12121.TextFont.CharSet = 162;
                    NewField12121.Value = @"MALZEME ADI";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField12121.CalcValue = NewField12121.Value;
                    return new TTReportObject[] { NewField11,NewField112,NewField1211,NewField12121};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public Census_DoubleZeroCardList MyParentReport
                {
                    get { return (Census_DoubleZeroCardList)ParentReport; }
                }
                
                public TTReportField TOTAL;
                public TTReportField TEFTIS;
                public TTReportField SUBGROUPCOUNT;
                public TTReportField PAGECOUNT;
                public TTReportField AMOUNTTEXT;
                public TTReportField ACCOUNTANCYNAME;
                public TTReportField COUNTTEXT;
                public TTReportField SUBGROUPCOUNTTEXT;
                public TTReportField SAYMAN;
                public TTReportField HESAPSORUMLUSU;
                public TTReportField TKM;
                public TTReportField TKB;
                public TTReportField NewField11121;
                public TTReportField NewField112111;
                public TTReportField NewField1111211;
                public TTReportField NewField111211113;
                public TTReportField TEXT123456;
                public TTReportField BIRLIKXXXXXXI;
                public TTReportField NewField1111212; 
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

                    TEFTIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 10, 181, 26, false);
                    TEFTIS.Name = "TEFTIS";
                    TEFTIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEFTIS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEFTIS.MultiLine = EvetHayirEnum.ehEvet;
                    TEFTIS.NoClip = EvetHayirEnum.ehEvet;
                    TEFTIS.WordBreak = EvetHayirEnum.ehEvet;
                    TEFTIS.ExpandTabs = EvetHayirEnum.ehEvet;
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

                    COUNTTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -1, 3, 181, 8, false);
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

                    SAYMAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 28, 47, 43, false);
                    SAYMAN.Name = "SAYMAN";
                    SAYMAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAYMAN.MultiLine = EvetHayirEnum.ehEvet;
                    SAYMAN.WordBreak = EvetHayirEnum.ehEvet;
                    SAYMAN.TextFont.Size = 9;
                    SAYMAN.TextFont.CharSet = 162;
                    SAYMAN.Value = @"";

                    HESAPSORUMLUSU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 28, 106, 44, false);
                    HESAPSORUMLUSU.Name = "HESAPSORUMLUSU";
                    HESAPSORUMLUSU.FieldType = ReportFieldTypeEnum.ftVariable;
                    HESAPSORUMLUSU.MultiLine = EvetHayirEnum.ehEvet;
                    HESAPSORUMLUSU.WordBreak = EvetHayirEnum.ehEvet;
                    HESAPSORUMLUSU.TextFont.Size = 9;
                    HESAPSORUMLUSU.TextFont.CharSet = 162;
                    HESAPSORUMLUSU.Value = @"";

                    TKM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 60, 143, 77, false);
                    TKM.Name = "TKM";
                    TKM.FieldType = ReportFieldTypeEnum.ftVariable;
                    TKM.MultiLine = EvetHayirEnum.ehEvet;
                    TKM.WordBreak = EvetHayirEnum.ehEvet;
                    TKM.TextFont.Size = 9;
                    TKM.TextFont.CharSet = 162;
                    TKM.Value = @"";

                    TKB = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 60, 77, 77, false);
                    TKB.Name = "TKB";
                    TKB.FieldType = ReportFieldTypeEnum.ftVariable;
                    TKB.MultiLine = EvetHayirEnum.ehEvet;
                    TKB.WordBreak = EvetHayirEnum.ehEvet;
                    TKB.TextFont.Size = 9;
                    TKB.TextFont.CharSet = 162;
                    TKB.Value = @"";

                    NewField11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 43, 45, 53, false);
                    NewField11121.Name = "NewField11121";
                    NewField11121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11121.TextFont.Name = "Arial";
                    NewField11121.TextFont.Bold = true;
                    NewField11121.TextFont.CharSet = 162;
                    NewField11121.Value = @"Sayman";

                    NewField112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 44, 106, 53, false);
                    NewField112111.Name = "NewField112111";
                    NewField112111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112111.TextFont.Name = "Arial";
                    NewField112111.TextFont.Bold = true;
                    NewField112111.TextFont.CharSet = 162;
                    NewField112111.Value = @"Hesap Sorumlusu";

                    NewField1111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 78, 144, 88, false);
                    NewField1111211.Name = "NewField1111211";
                    NewField1111211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111211.TextFont.Name = "Arial";
                    NewField1111211.TextFont.Bold = true;
                    NewField1111211.TextFont.CharSet = 162;
                    NewField1111211.Value = @"Teftiş Kurulu Müfettişi";

                    NewField111211113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 78, 77, 88, false);
                    NewField111211113.Name = "NewField111211113";
                    NewField111211113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111211113.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111211113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111211113.TextFont.Name = "Arial";
                    NewField111211113.TextFont.Bold = true;
                    NewField111211113.TextFont.CharSet = 162;
                    NewField111211113.Value = @"Teftiş Kurulu Başkanı";

                    TEXT123456 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 12, 251, 49, false);
                    TEXT123456.Name = "TEXT123456";
                    TEXT123456.Visible = EvetHayirEnum.ehHayir;
                    TEXT123456.MultiLine = EvetHayirEnum.ehEvet;
                    TEXT123456.WordBreak = EvetHayirEnum.ehEvet;
                    TEXT123456.TextFont.Size = 11;
                    TEXT123456.TextFont.Bold = true;
                    TEXT123456.TextFont.CharSet = 162;
                    TEXT123456.Value = @"İmza ve Mühür
Adı ve Soyadı
Sınıfı ve Rütbesi
Görevi		
";

                    BIRLIKXXXXXXI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 29, 166, 44, false);
                    BIRLIKXXXXXXI.Name = "BIRLIKXXXXXXI";
                    BIRLIKXXXXXXI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIKXXXXXXI.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIKXXXXXXI.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIKXXXXXXI.TextFont.Size = 9;
                    BIRLIKXXXXXXI.TextFont.CharSet = 162;
                    BIRLIKXXXXXXI.Value = @"";

                    NewField1111212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 44, 165, 53, false);
                    NewField1111212.Name = "NewField1111212";
                    NewField1111212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111212.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111212.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111212.TextFont.Name = "Arial";
                    NewField1111212.TextFont.Bold = true;
                    NewField1111212.TextFont.CharSet = 162;
                    NewField1111212.Value = @"Birlik XXXXXXı";

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
                    SAYMAN.CalcValue = @"";
                    HESAPSORUMLUSU.CalcValue = @"";
                    TKM.CalcValue = @"";
                    TKB.CalcValue = @"";
                    NewField11121.CalcValue = NewField11121.Value;
                    NewField112111.CalcValue = NewField112111.Value;
                    NewField1111211.CalcValue = NewField1111211.Value;
                    NewField111211113.CalcValue = NewField111211113.Value;
                    TEXT123456.CalcValue = TEXT123456.Value;
                    BIRLIKXXXXXXI.CalcValue = @"";
                    NewField1111212.CalcValue = NewField1111212.Value;
                    return new TTReportObject[] { TOTAL,TEFTIS,SUBGROUPCOUNT,PAGECOUNT,AMOUNTTEXT,ACCOUNTANCYNAME,COUNTTEXT,SUBGROUPCOUNTTEXT,SAYMAN,HESAPSORUMLUSU,TKM,TKB,NewField11121,NewField112111,NewField1111211,NewField111211113,TEXT123456,BIRLIKXXXXXXI,NewField1111212};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    AMOUNTTEXT.CalcValue = PARTBGroup.totalAmount.ToString();
            SUBGROUPCOUNTTEXT.CalcValue = SUBGROUPCOUNT.CalcValue;
            PARTBGroup.totalAmount = 0;
            
            string termID = ((Census_DoubleZeroCardList)ParentReport).RuntimeParameters.TERMID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            AccountingTerm term = (AccountingTerm)ctx.GetObject(new Guid(termID), typeof(AccountingTerm));
            if(term.EndDate != null)
            {
                TEFTIS.CalcValue = "1.Yukarıda stok numarası ve cinsi yazılı toplam " + SUBGROUPCOUNT.FormattedValue
                    + " adet ÇİFT SIFIRLI stok kayıt kartları " + ACCOUNTANCYNAME.FormattedValue
                    + " saymanlığının " + Convert.ToDateTime(term.EndDate).Year.ToString() + " bütçe yılı teftişinde"
                    + " sistem tarafından envandertençıkartılmıştır."
                    + "\r\n2.Envanter kayıtları bilgisayarda tutulan saymanlıkların Ana Stok Kütüğünden atılan ÇİFT SIFIRLI"
                    + " kayıtlarına ilişkin sandığa herhangi bir kart koyulmamaktadır.";
            }
            COUNTTEXT.CalcValue = "///////////YALNIZ " + SUBGROUPCOUNT.FormattedValue + " (" + SUBGROUPCOUNTTEXT.FormattedValue.ToUpper() + ") ADET BELGE///////////";

            

            IList checkStockCensusActions = ctx.QueryObjects("CHECKSTOCKCENSUSACTION","ACCOUNTINGTERM=" + ConnectionManager.GuidToString(term.ObjectID));
            if(checkStockCensusActions.Count > 0)
            {
                CheckStockCensusAction checkStockCensusAction = (CheckStockCensusAction)checkStockCensusActions[0];
                
                SAYMAN.CalcValue =  checkStockCensusAction.SingOfCensusAction(SignUserTypeEnum.MalSaymani);
                TKB.CalcValue = checkStockCensusAction.SingOfCensusAction(SignUserTypeEnum.TeftisKuruluBaskani);
                TKM.CalcValue = checkStockCensusAction.SingOfCensusAction(SignUserTypeEnum.TeftisKuruluMufettisi);

                BIRLIKXXXXXXI.CalcValue = checkStockCensusAction.SingOfCensusAction(SignUserTypeEnum.BirlikXXXXXXi);
                Guid oID = new Guid(MyParentReport.RuntimeParameters.CARDDRAWER);
                HESAPSORUMLUSU.CalcValue = checkStockCensusAction.SignOfAccontingterm(oID);
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
            public Census_DoubleZeroCardList MyParentReport
            {
                get { return (Census_DoubleZeroCardList)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ObjectID { get {return Body().ObjectID;} }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField OB { get {return Body().OB;} }
            public TTReportField NSN { get {return Body().NSN;} }
            public TTReportField STOCKCARDNAME { get {return Body().STOCKCARDNAME;} }
            public TTReportField CENSUSORDER { get {return Body().CENSUSORDER;} }
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
                list[0] = new TTReportNqlData<DoubleZeroCardEpochMaterial.CensusReportNQL_DoubleZeros_Class>("CensusReportNQL_DoubleZeros", DoubleZeroCardEpochMaterial.CensusReportNQL_DoubleZeros((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TERMID),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.CARDDRAWER)));
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
                public Census_DoubleZeroCardList MyParentReport
                {
                    get { return (Census_DoubleZeroCardList)ParentReport; }
                }
                
                public TTReportField ObjectID;
                public TTReportField COUNT;
                public TTReportField OB;
                public TTReportField NSN;
                public TTReportField STOCKCARDNAME;
                public TTReportField CENSUSORDER; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
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

                    OB = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 0, 257, 5, false);
                    OB.Name = "OB";
                    OB.Visible = EvetHayirEnum.ehHayir;
                    OB.DrawStyle = DrawStyleConstants.vbSolid;
                    OB.FieldType = ReportFieldTypeEnum.ftVariable;
                    OB.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OB.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OB.TextFont.Name = "Arial";
                    OB.TextFont.CharSet = 162;
                    OB.Value = @"";

                    NSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 0, 75, 5, false);
                    NSN.Name = "NSN";
                    NSN.DrawStyle = DrawStyleConstants.vbSolid;
                    NSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    NSN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NSN.Value = @"{#NSN#}";

                    STOCKCARDNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 0, 181, 5, false);
                    STOCKCARDNAME.Name = "STOCKCARDNAME";
                    STOCKCARDNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    STOCKCARDNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDNAME.Value = @"{#STOCKCARDNAME#}";

                    CENSUSORDER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 37, 5, false);
                    CENSUSORDER.Name = "CENSUSORDER";
                    CENSUSORDER.DrawStyle = DrawStyleConstants.vbSolid;
                    CENSUSORDER.FieldType = ReportFieldTypeEnum.ftVariable;
                    CENSUSORDER.Value = @"{#CENSUSORDER#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DoubleZeroCardEpochMaterial.CensusReportNQL_DoubleZeros_Class dataset_CensusReportNQL_DoubleZeros = ParentGroup.rsGroup.GetCurrentRecord<DoubleZeroCardEpochMaterial.CensusReportNQL_DoubleZeros_Class>(0);
                    ObjectID.CalcValue = (dataset_CensusReportNQL_DoubleZeros != null ? Globals.ToStringCore(dataset_CensusReportNQL_DoubleZeros.ObjectID) : "");
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    OB.CalcValue = @"";
                    NSN.CalcValue = (dataset_CensusReportNQL_DoubleZeros != null ? Globals.ToStringCore(dataset_CensusReportNQL_DoubleZeros.Nsn) : "");
                    STOCKCARDNAME.CalcValue = (dataset_CensusReportNQL_DoubleZeros != null ? Globals.ToStringCore(dataset_CensusReportNQL_DoubleZeros.Stockcardname) : "");
                    CENSUSORDER.CalcValue = (dataset_CensusReportNQL_DoubleZeros != null ? Globals.ToStringCore(dataset_CensusReportNQL_DoubleZeros.Censusorder) : "");
                    return new TTReportObject[] { ObjectID,COUNT,OB,NSN,STOCKCARDNAME,CENSUSORDER};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //            TTObjectContext ctx = new TTObjectContext(true);
//            StockAction cd = (StockAction)ctx.GetObject(new Guid(ObjectID.CalcValue), typeof(StockAction).Name);
//            if(cd.StockActionDetails.Count > 0)
//            {
//                PARTBGroup.totalAmount = cd.StockActionDetails.Count + PARTBGroup.totalAmount;
//                AMOUNT.CalcValue = cd.StockActionDetails.Count.ToString() + " ";
//                MATERIALNAME.CalcValue = " " + cd.StockActionDetails[0].Material.StockCard.NATOStockNO + " | " + cd.StockActionDetails[0].Amount + " " + cd.StockActionDetails[0].Material.StockCard.DistributionType.QRef + " | " + cd.StockActionDetails[0].Material.StockCard.Name;
//                if(cd.StockActionOutDetails.Count > 0 && cd.StockActionInDetails.Count > 0)
//                {
//                    OLDSTOCKCARD.CalcValue = cd.StockActionOutDetails[0].Material.StockCard.Name;
//                    NEWSTOCKCARD.CalcValue = cd.StockActionInDetails[0].Material.StockCard.Name;
//                    OLDNSN.CalcValue = cd.StockActionOutDetails[0].Material.StockCard.NATOStockNO;
//                    NEWNSN.CalcValue = cd.StockActionInDetails[0].Material.StockCard.NATOStockNO;
//                    DATE.CalcValue = cd.TransactionDate.ToString();
//                }
//                
//                if(cd.RegistrationNumber != null)
//                REGISTRATIONNUMBER.CalcValue = cd.RegistrationNumber.ToString();
//                EXTRA.CalcValue = cd.AdditionalDocumentCount.ToString();
//            }
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

        public Census_DoubleZeroCardList()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TERMID", "", "Hesap Dönemini Seçiniz", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("429e41e5-620c-4652-9e24-aa488e0aaaaf");
            reportParameter = Parameters.Add("CARDDRAWER", "", "Masa", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("03e2de85-a832-4760-a20c-e921071b5c37");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TERMID"))
                _runtimeParameters.TERMID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TERMID"]);
            if (parameters.ContainsKey("CARDDRAWER"))
                _runtimeParameters.CARDDRAWER = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["CARDDRAWER"]);
            Name = "CENSUS_DOUBLEZEROCARDLIST";
            Caption = "Stok Devir Belge Dökümleri (Çift Sıfırlı Çizelgesi EK-26A)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
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