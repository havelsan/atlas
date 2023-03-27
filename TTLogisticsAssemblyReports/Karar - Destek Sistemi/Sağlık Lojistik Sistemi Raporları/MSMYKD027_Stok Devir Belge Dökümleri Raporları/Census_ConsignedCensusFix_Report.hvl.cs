
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
    /// Stok Devir Belge Dökümleri (TMİB Sayım Düzeltme - Birlik Üzerinden Döküm Çizelgesi)
    /// </summary>
    public partial class Census_ConsignedCensusFix : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TERMID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string SIGNS = (string)TTObjectDefManager.Instance.DataTypes["RTF(LongText)"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public Census_ConsignedCensusFix MyParentReport
            {
                get { return (Census_ConsignedCensusFix)ParentReport; }
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
                public Census_ConsignedCensusFix MyParentReport
                {
                    get { return (Census_ConsignedCensusFix)ParentReport; }
                }
                
                public TTReportField REPORTNAME;
                public TTReportField AdditionNO;
                public TTReportField AccountingTerm;
                public TTReportField AccountYear;
                public TTReportField ENDDATE; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 31;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 12, 192, 30, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 12;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"TMİB SAYIM DÜZELTME - BİRLİK ÜZERİNDEN DÖKÜM ÇİZELGESİ";

                    AdditionNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 2, 192, 7, false);
                    AdditionNO.Name = "AdditionNO";
                    AdditionNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AdditionNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AdditionNO.TextFont.Name = "Arial";
                    AdditionNO.TextFont.Bold = true;
                    AdditionNO.TextFont.CharSet = 162;
                    AdditionNO.Value = @"";

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

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 7, 192, 12, false);
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
                    return new TTReportObject[] { REPORTNAME,AdditionNO,AccountingTerm,AccountYear,ENDDATE};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public Census_ConsignedCensusFix MyParentReport
                {
                    get { return (Census_ConsignedCensusFix)ParentReport; }
                }
                
                public TTReportField PAGENUMBER; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 192, 6, false);
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
            public Census_ConsignedCensusFix MyParentReport
            {
                get { return (Census_ConsignedCensusFix)ParentReport; }
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
                public Census_ConsignedCensusFix MyParentReport
                {
                    get { return (Census_ConsignedCensusFix)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField1221;
                public TTReportField NewField12221;
                public TTReportField NewField13221;
                public TTReportField NewField111; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 11;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 12, 10, false);
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

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 0, 36, 10, false);
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

                    NewField12221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 0, 182, 10, false);
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

                    NewField13221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 0, 164, 10, false);
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

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 0, 192, 10, false);
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
                public Census_ConsignedCensusFix MyParentReport
                {
                    get { return (Census_ConsignedCensusFix)ParentReport; }
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

                    Height = 48;
                    RepeatCount = 0;
                    
                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 7, 192, 12, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTAL.TextFont.Name = "Arial";
                    TOTAL.TextFont.CharSet = 162;
                    TOTAL.Value = @"";

                    TEFTIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), -1, 13, 192, 25, false);
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

                    COUNTTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 192, 6, false);
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

                    SIGNS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 29, 192, 47, false);
                    SIGNS.Name = "SIGNS";
                    SIGNS.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIGNS.MultiLine = EvetHayirEnum.ehEvet;
                    SIGNS.WordBreak = EvetHayirEnum.ehEvet;
                    SIGNS.ExpandTabs = EvetHayirEnum.ehEvet;
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
            TOTAL.CalcValue = "///////////YALNIZ " + PARTBGroup.totalAmount.ToString() +" (" + AMOUNTTEXT.FormattedValue + ") KALEMDİR///////////";
            PARTBGroup.totalAmount = 0;
            
            string termID = ((Census_ConsignedCensusFix)ParentReport).RuntimeParameters.TERMID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            AccountingTerm term = (AccountingTerm)ctx.GetObject(new Guid(termID), typeof(AccountingTerm));
            if(term.EndDate != null)
            {
                TEFTIS.CalcValue = "Yukarıda cinsi belirtilen toplam " + SUBGROUPCOUNT.FormattedValue + " adet TMİB Sayım Düzeltme - Birlik Üzerinden'in 4'üncü nüshaları "
                    + ACCOUNTANCYNAME.FormattedValue + " saymanlığının " + Convert.ToDateTime(term.EndDate).Year.ToString()
                    + " bütçe yılı teftişinde saymandan alınarak teftiş sandığına konulmuştur.";
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
            public Census_ConsignedCensusFix MyParentReport
            {
                get { return (Census_ConsignedCensusFix)ParentReport; }
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
                list[0] = new TTReportNqlData<DocumentRecordLog.CensusReportNQL_DocumentRecLogByObjectDef_Class>("CensusReportNQL_DocumentRecLogByObjectDef", DocumentRecordLog.CensusReportNQL_DocumentRecLogByObjectDef((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TERMID),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(@"7536de26-3fb2-4747-abf0-d0e53d2b8ff2")));
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
                public Census_ConsignedCensusFix MyParentReport
                {
                    get { return (Census_ConsignedCensusFix)ParentReport; }
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

                    Height = 6;
                    RepeatCount = 0;
                    
                    ObjectID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 0, 328, 5, false);
                    ObjectID.Name = "ObjectID";
                    ObjectID.Visible = EvetHayirEnum.ehHayir;
                    ObjectID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ObjectID.Value = @"{#OBJECTID#}";

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 12, 5, false);
                    COUNT.Name = "COUNT";
                    COUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.TextFont.Name = "Arial";
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{@counter@}";

                    REGISTRATIONNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 0, 36, 5, false);
                    REGISTRATIONNUMBER.Name = "REGISTRATIONNUMBER";
                    REGISTRATIONNUMBER.DrawStyle = DrawStyleConstants.vbSolid;
                    REGISTRATIONNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    REGISTRATIONNUMBER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REGISTRATIONNUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REGISTRATIONNUMBER.TextFont.Name = "Arial";
                    REGISTRATIONNUMBER.TextFont.CharSet = 162;
                    REGISTRATIONNUMBER.Value = @"";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 0, 182, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFormat = @"#,###";
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 0, 164, 5, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALNAME.TextFont.Name = "Arial";
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"";

                    EXTRA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 0, 192, 5, false);
                    EXTRA.Name = "EXTRA";
                    EXTRA.DrawStyle = DrawStyleConstants.vbSolid;
                    EXTRA.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXTRA.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EXTRA.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EXTRA.TextFont.Name = "Arial";
                    EXTRA.TextFont.CharSet = 162;
                    EXTRA.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DocumentRecordLog.CensusReportNQL_DocumentRecLogByObjectDef_Class dataset_CensusReportNQL_DocumentRecLogByObjectDef = ParentGroup.rsGroup.GetCurrentRecord<DocumentRecordLog.CensusReportNQL_DocumentRecLogByObjectDef_Class>(0);
                    ObjectID.CalcValue = (dataset_CensusReportNQL_DocumentRecLogByObjectDef != null ? Globals.ToStringCore(dataset_CensusReportNQL_DocumentRecLogByObjectDef.ObjectID) : "");
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
            if(dr.DocumentTransactionType == DocumentTransactionTypeEnum.Out)
            {
                if(cd.StockActionOutDetails[0].Material.StockCard == null)
                    return;
                
                BindingList<StockAction.StockActionOutDetailsReportQuery_Class> list = StockAction.StockActionOutDetailsReportQuery(cd.ObjectID);
                StockAction.StockActionOutDetailsReportQuery_Class cdOutClass = list[0];
                StockActionDetailOut cdOut = (StockActionDetailOut)ctx.GetObject((Guid)cdOutClass.Stockactiondetailobjectid, typeof(StockActionDetailOut).Name);
                PARTBGroup.totalAmount = cd.StockActionOutDetails.Count + PARTBGroup.totalAmount;
                AMOUNT.CalcValue = cd.StockActionOutDetails.Count.ToString() + " ";
                MATERIALNAME.CalcValue = " " + cdOut.Material.StockCard.NATOStockNO + " | " + cdOut.Amount + " " + cdOut.Material.StockCard.DistributionType.QRef + " | " + cdOut.Material.StockCard.Name;
                EXTRA.CalcValue = cd.AdditionalDocumentCount.ToString();
                REGISTRATIONNUMBER.CalcValue = "Ç" + dr.DocumentRecordLogNumber.Value.ToString();
                return;
            }
            else
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
                EXTRA.CalcValue = cd.AdditionalDocumentCount.ToString();
                return;
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

        public Census_ConsignedCensusFix()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TERMID", "", "Hesap Dönemini Seçiniz", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("429e41e5-620c-4652-9e24-aa488e0aaaaf");
            reportParameter = Parameters.Add("SIGNS", "", "İmza Bloğu", @"", false, true, false, new Guid("bdf152e5-b22d-423b-99dd-fadf6e6b7686"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TERMID"))
                _runtimeParameters.TERMID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TERMID"]);
            if (parameters.ContainsKey("SIGNS"))
                _runtimeParameters.SIGNS = (string)TTObjectDefManager.Instance.DataTypes["RTF(LongText)"].ConvertValue(parameters["SIGNS"]);
            Name = "CENSUS_CONSIGNEDCENSUSFIX";
            Caption = "Stok Devir Belge Dökümleri (TMİB Sayım Düzeltme - Birlik Üzerinden Döküm Çizelgesi)";
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