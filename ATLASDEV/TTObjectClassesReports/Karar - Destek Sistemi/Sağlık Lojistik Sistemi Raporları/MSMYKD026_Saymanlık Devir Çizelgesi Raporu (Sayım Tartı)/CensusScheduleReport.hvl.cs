
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
    /// Sayım Tartı Çizelgesi (SHH-VET. MAL SYM.)
    /// </summary>
    public partial class CensusScheduleReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? TERMID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public string ASSETACCOUNTANT = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string ACCOUNTRESPONSIBLE = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public Guid? CARDDRAWER = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public CensusScheduleReport MyParentReport
            {
                get { return (CensusScheduleReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField ReportName { get {return Header().ReportName;} }
            public TTReportField ReportName1 { get {return Header().ReportName1;} }
            public TTReportField AdditionNO1 { get {return Header().AdditionNO1;} }
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
                public CensusScheduleReport MyParentReport
                {
                    get { return (CensusScheduleReport)ParentReport; }
                }
                
                public TTReportField ReportName;
                public TTReportField ReportName1;
                public TTReportField AdditionNO1; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 19;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 257, 11, false);
                    ReportName.Name = "ReportName";
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Name = "Arial";
                    ReportName.TextFont.Size = 12;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"DEVİR ÇİZELGESİ";

                    ReportName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 11, 257, 17, false);
                    ReportName1.Name = "ReportName1";
                    ReportName1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName1.TextFont.Name = "Arial";
                    ReportName1.TextFont.Size = 12;
                    ReportName1.TextFont.Bold = true;
                    ReportName1.TextFont.CharSet = 162;
                    ReportName1.Value = @"(SHH-VET MAL SYM.)";

                    AdditionNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 0, 257, 5, false);
                    AdditionNO1.Name = "AdditionNO1";
                    AdditionNO1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AdditionNO1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AdditionNO1.TextFont.Name = "Arial";
                    AdditionNO1.TextFont.Bold = true;
                    AdditionNO1.TextFont.CharSet = 162;
                    AdditionNO1.Value = @"EK-160";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReportName.CalcValue = ReportName.Value;
                    ReportName1.CalcValue = ReportName1.Value;
                    AdditionNO1.CalcValue = AdditionNO1.Value;
                    return new TTReportObject[] { ReportName,ReportName1,AdditionNO1};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public CensusScheduleReport MyParentReport
                {
                    get { return (CensusScheduleReport)ParentReport; }
                }
                
                public TTReportField PAGENUMBER; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 30;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
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
                    PAGENUMBER.Value = @"EK-160-{@pagenumber@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PAGENUMBER.CalcValue = @"EK-160-" + ParentReport.CurrentPageNumber.ToString();
                    return new TTReportObject[] { PAGENUMBER};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public CensusScheduleReport MyParentReport
            {
                get { return (CensusScheduleReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField OldOrderNO { get {return Header().OldOrderNO;} }
            public TTReportField NewOrderNO { get {return Header().NewOrderNO;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField YearCensus { get {return Header().YearCensus;} }
            public TTReportField AtOldYear { get {return Header().AtOldYear;} }
            public TTReportField NewField111221 { get {return Header().NewField111221;} }
            public TTReportField NewField1122111 { get {return Header().NewField1122111;} }
            public TTReportField AtNewYear { get {return Header().AtNewYear;} }
            public TTReportField NewField1122121 { get {return Header().NewField1122121;} }
            public TTReportField NewField11212211 { get {return Header().NewField11212211;} }
            public TTReportField NewField1111131 { get {return Header().NewField1111131;} }
            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField AccountantName { get {return Footer().AccountantName;} }
            public TTReportField NewField11 { get {return Footer().NewField11;} }
            public TTReportField AccountResponsibleName { get {return Footer().AccountResponsibleName;} }
            public TTReportField AccountantTitle { get {return Footer().AccountantTitle;} }
            public TTReportField AccountResponsibleTitle { get {return Footer().AccountResponsibleTitle;} }
            public TTReportField AccountantTitleName { get {return Footer().AccountantTitleName;} }
            public TTReportField AccountResponsibleTitleName { get {return Footer().AccountResponsibleTitleName;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
            public TTReportField NewField12 { get {return Footer().NewField12;} }
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
                public CensusScheduleReport MyParentReport
                {
                    get { return (CensusScheduleReport)ParentReport; }
                }
                
                public TTReportField OldOrderNO;
                public TTReportField NewOrderNO;
                public TTReportField NewField11111;
                public TTReportField YearCensus;
                public TTReportField AtOldYear;
                public TTReportField NewField111221;
                public TTReportField NewField1122111;
                public TTReportField AtNewYear;
                public TTReportField NewField1122121;
                public TTReportField NewField11212211;
                public TTReportField NewField1111131;
                public TTReportField NewField111211; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 24;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    OldOrderNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 36, 20, false);
                    OldOrderNO.Name = "OldOrderNO";
                    OldOrderNO.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO.MultiLine = EvetHayirEnum.ehEvet;
                    OldOrderNO.WordBreak = EvetHayirEnum.ehEvet;
                    OldOrderNO.TextFont.Name = "Arial";
                    OldOrderNO.TextFont.Size = 11;
                    OldOrderNO.TextFont.Bold = true;
                    OldOrderNO.TextFont.CharSet = 162;
                    OldOrderNO.Value = @"BİR ÖNCEKİ YILIN DEVİR ÇİZELGESİNDEKİ SIRA NU.";

                    NewOrderNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 0, 48, 20, false);
                    NewOrderNO.Name = "NewOrderNO";
                    NewOrderNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NewOrderNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewOrderNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewOrderNO.MultiLine = EvetHayirEnum.ehEvet;
                    NewOrderNO.WordBreak = EvetHayirEnum.ehEvet;
                    NewOrderNO.TextFont.Name = "Arial";
                    NewOrderNO.TextFont.Size = 11;
                    NewOrderNO.TextFont.Bold = true;
                    NewOrderNO.TextFont.CharSet = 162;
                    NewOrderNO.Value = @"
SIRA
NU.";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 0, 128, 20, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Size = 11;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"
ÖLÇÜ
BİRİMİ";

                    YearCensus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 0, 151, 20, false);
                    YearCensus.Name = "YearCensus";
                    YearCensus.DrawStyle = DrawStyleConstants.vbSolid;
                    YearCensus.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YearCensus.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YearCensus.MultiLine = EvetHayirEnum.ehEvet;
                    YearCensus.WordBreak = EvetHayirEnum.ehEvet;
                    YearCensus.TextFont.Name = "Arial";
                    YearCensus.TextFont.Size = 11;
                    YearCensus.TextFont.Bold = true;
                    YearCensus.TextFont.CharSet = 162;
                    YearCensus.Value = @"";

                    AtOldYear = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 0, 187, 10, false);
                    AtOldYear.Name = "AtOldYear";
                    AtOldYear.DrawStyle = DrawStyleConstants.vbSolid;
                    AtOldYear.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AtOldYear.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AtOldYear.TextFont.Name = "Arial";
                    AtOldYear.TextFont.Size = 11;
                    AtOldYear.TextFont.Bold = true;
                    AtOldYear.TextFont.CharSet = 162;
                    AtOldYear.Value = @"";

                    NewField111221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 10, 169, 20, false);
                    NewField111221.Name = "NewField111221";
                    NewField111221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111221.TextFont.Name = "Arial";
                    NewField111221.TextFont.Size = 11;
                    NewField111221.TextFont.Bold = true;
                    NewField111221.TextFont.CharSet = 162;
                    NewField111221.Value = @" GİREN";

                    NewField1122111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 10, 187, 20, false);
                    NewField1122111.Name = "NewField1122111";
                    NewField1122111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1122111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1122111.TextFont.Name = "Arial";
                    NewField1122111.TextFont.Size = 11;
                    NewField1122111.TextFont.Bold = true;
                    NewField1122111.TextFont.CharSet = 162;
                    NewField1122111.Value = @" ÇIKAN";

                    AtNewYear = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 0, 237, 10, false);
                    AtNewYear.Name = "AtNewYear";
                    AtNewYear.DrawStyle = DrawStyleConstants.vbSolid;
                    AtNewYear.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AtNewYear.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AtNewYear.TextFont.Name = "Arial";
                    AtNewYear.TextFont.Size = 11;
                    AtNewYear.TextFont.Bold = true;
                    AtNewYear.TextFont.CharSet = 162;
                    AtNewYear.Value = @"";

                    NewField1122121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 10, 212, 20, false);
                    NewField1122121.Name = "NewField1122121";
                    NewField1122121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1122121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1122121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1122121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1122121.TextFont.Name = "Arial";
                    NewField1122121.TextFont.Size = 11;
                    NewField1122121.TextFont.Bold = true;
                    NewField1122121.TextFont.CharSet = 162;
                    NewField1122121.Value = @" DEPO
 MEVCUDU";

                    NewField11212211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 10, 237, 20, false);
                    NewField11212211.Name = "NewField11212211";
                    NewField11212211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11212211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11212211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11212211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11212211.TextFont.Name = "Arial";
                    NewField11212211.TextFont.Size = 11;
                    NewField11212211.TextFont.Bold = true;
                    NewField11212211.TextFont.CharSet = 162;
                    NewField11212211.Value = @" MUVAKKAT
 VERİLEN";

                    NewField1111131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 0, 257, 20, false);
                    NewField1111131.Name = "NewField1111131";
                    NewField1111131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111131.TextFont.Name = "Arial";
                    NewField1111131.TextFont.Size = 11;
                    NewField1111131.TextFont.Bold = true;
                    NewField1111131.TextFont.CharSet = 162;
                    NewField1111131.Value = @"
TOPLAM";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 0, 109, 20, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111211.TextFont.Name = "Arial";
                    NewField111211.TextFont.Size = 11;
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"STOK KAYIT KARTININ
AİT OLDUĞU MALIN
STOK NUMARASI VE
ADI";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OldOrderNO.CalcValue = OldOrderNO.Value;
                    NewOrderNO.CalcValue = NewOrderNO.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    YearCensus.CalcValue = YearCensus.Value;
                    AtOldYear.CalcValue = AtOldYear.Value;
                    NewField111221.CalcValue = NewField111221.Value;
                    NewField1122111.CalcValue = NewField1122111.Value;
                    AtNewYear.CalcValue = AtNewYear.Value;
                    NewField1122121.CalcValue = NewField1122121.Value;
                    NewField11212211.CalcValue = NewField11212211.Value;
                    NewField1111131.CalcValue = NewField1111131.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    return new TTReportObject[] { OldOrderNO,NewOrderNO,NewField11111,YearCensus,AtOldYear,NewField111221,NewField1122111,AtNewYear,NewField1122121,NewField11212211,NewField1111131,NewField111211};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    string termID = ((CensusScheduleReport)ParentReport).RuntimeParameters.TERMID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            AccountingTerm accountingTerm = (AccountingTerm)ctx.GetObject(new Guid(termID), typeof(AccountingTerm));
            if(accountingTerm.EndDate != null)
            {
                int actionYear = Convert.ToDateTime(accountingTerm.EndDate).Year;
                this.YearCensus.CalcValue = "\n" + actionYear.ToString() + " YILINA\nDEVİR";
                this.AtOldYear.CalcValue = actionYear.ToString() + " YILINDA";
                this.AtNewYear.CalcValue = (actionYear + 1).ToString() + " YILINA DEVİR";
            }
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public CensusScheduleReport MyParentReport
                {
                    get { return (CensusScheduleReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField AccountantName;
                public TTReportField NewField11;
                public TTReportField AccountResponsibleName;
                public TTReportField AccountantTitle;
                public TTReportField AccountResponsibleTitle;
                public TTReportField AccountantTitleName;
                public TTReportField AccountResponsibleTitleName;
                public TTReportField NewField2;
                public TTReportField NewField12; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 37;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 3, 90, 8, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Mal Saymanı";

                    AccountantName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 13, 90, 18, false);
                    AccountantName.Name = "AccountantName";
                    AccountantName.FieldType = ReportFieldTypeEnum.ftVariable;
                    AccountantName.CaseFormat = CaseFormatEnum.fcNameSurname;
                    AccountantName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AccountantName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AccountantName.NoClip = EvetHayirEnum.ehEvet;
                    AccountantName.ObjectDefName = "ResUser";
                    AccountantName.DataMember = "NAME";
                    AccountantName.TextFont.Name = "Arial";
                    AccountantName.TextFont.CharSet = 162;
                    AccountantName.Value = @"{@ASSETACCOUNTANT@}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 3, 217, 8, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Hesap Sorumlusu";

                    AccountResponsibleName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 13, 217, 18, false);
                    AccountResponsibleName.Name = "AccountResponsibleName";
                    AccountResponsibleName.FieldType = ReportFieldTypeEnum.ftVariable;
                    AccountResponsibleName.CaseFormat = CaseFormatEnum.fcNameSurname;
                    AccountResponsibleName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AccountResponsibleName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AccountResponsibleName.NoClip = EvetHayirEnum.ehEvet;
                    AccountResponsibleName.ObjectDefName = "ResUser";
                    AccountResponsibleName.DataMember = "NAME";
                    AccountResponsibleName.TextFont.Name = "Arial";
                    AccountResponsibleName.TextFont.CharSet = 162;
                    AccountResponsibleName.Value = @"{@ACCOUNTRESPONSIBLE@}";

                    AccountantTitle = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 7, 326, 12, false);
                    AccountantTitle.Name = "AccountantTitle";
                    AccountantTitle.Visible = EvetHayirEnum.ehHayir;
                    AccountantTitle.FieldType = ReportFieldTypeEnum.ftVariable;
                    AccountantTitle.ObjectDefName = "ResUser";
                    AccountantTitle.DataMember = "TITLE";
                    AccountantTitle.Value = @"{@ASSETACCOUNTANT@}";

                    AccountResponsibleTitle = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 12, 326, 17, false);
                    AccountResponsibleTitle.Name = "AccountResponsibleTitle";
                    AccountResponsibleTitle.Visible = EvetHayirEnum.ehHayir;
                    AccountResponsibleTitle.FieldType = ReportFieldTypeEnum.ftVariable;
                    AccountResponsibleTitle.ObjectDefName = "ResUser";
                    AccountResponsibleTitle.DataMember = "TITLE";
                    AccountResponsibleTitle.Value = @"{@ACCOUNTRESPONSIBLE@}";

                    AccountantTitleName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 8, 90, 13, false);
                    AccountantTitleName.Name = "AccountantTitleName";
                    AccountantTitleName.FieldType = ReportFieldTypeEnum.ftVariable;
                    AccountantTitleName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    AccountantTitleName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AccountantTitleName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AccountantTitleName.NoClip = EvetHayirEnum.ehEvet;
                    AccountantTitleName.ObjectDefName = "UserTitleEnum";
                    AccountantTitleName.DataMember = "DISPLAYTEXT";
                    AccountantTitleName.TextFont.Name = "Arial";
                    AccountantTitleName.TextFont.CharSet = 162;
                    AccountantTitleName.Value = @"{%AccountantTitle%}";

                    AccountResponsibleTitleName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 8, 217, 13, false);
                    AccountResponsibleTitleName.Name = "AccountResponsibleTitleName";
                    AccountResponsibleTitleName.FieldType = ReportFieldTypeEnum.ftVariable;
                    AccountResponsibleTitleName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    AccountResponsibleTitleName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AccountResponsibleTitleName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AccountResponsibleTitleName.NoClip = EvetHayirEnum.ehEvet;
                    AccountResponsibleTitleName.ObjectDefName = "UserTitleEnum";
                    AccountResponsibleTitleName.DataMember = "DISPLAYTEXT";
                    AccountResponsibleTitleName.TextFont.Name = "Arial";
                    AccountResponsibleTitleName.TextFont.CharSet = 162;
                    AccountResponsibleTitleName.Value = @"{%AccountResponsibleTitle%}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 18, 90, 33, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 18, 217, 33, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    AccountantName.CalcValue = MyParentReport.RuntimeParameters.ASSETACCOUNTANT.ToString();
                    AccountantName.PostFieldValueCalculation();
                    NewField11.CalcValue = NewField11.Value;
                    AccountResponsibleName.CalcValue = MyParentReport.RuntimeParameters.ACCOUNTRESPONSIBLE.ToString();
                    AccountResponsibleName.PostFieldValueCalculation();
                    AccountantTitle.CalcValue = MyParentReport.RuntimeParameters.ASSETACCOUNTANT.ToString();
                    AccountantTitle.PostFieldValueCalculation();
                    AccountResponsibleTitle.CalcValue = MyParentReport.RuntimeParameters.ACCOUNTRESPONSIBLE.ToString();
                    AccountResponsibleTitle.PostFieldValueCalculation();
                    AccountantTitleName.CalcValue = MyParentReport.PARTB.AccountantTitle.CalcValue;
                    AccountantTitleName.PostFieldValueCalculation();
                    AccountResponsibleTitleName.CalcValue = MyParentReport.PARTB.AccountResponsibleTitle.CalcValue;
                    AccountResponsibleTitleName.PostFieldValueCalculation();
                    NewField2.CalcValue = NewField2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    return new TTReportObject[] { NewField1,AccountantName,NewField11,AccountResponsibleName,AccountantTitle,AccountResponsibleTitle,AccountantTitleName,AccountResponsibleTitleName,NewField2,NewField12};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public CensusScheduleReport MyParentReport
            {
                get { return (CensusScheduleReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField OLDORDERNO { get {return Body().OLDORDERNO;} }
            public TTReportField NEWORDERNO { get {return Body().NEWORDERNO;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportField YEARCENSUS { get {return Body().YEARCENSUS;} }
            public TTReportField TOTALIN { get {return Body().TOTALIN;} }
            public TTReportField TOTALOUT { get {return Body().TOTALOUT;} }
            public TTReportField TOTALINHELD { get {return Body().TOTALINHELD;} }
            public TTReportField CONSIGNED { get {return Body().CONSIGNED;} }
            public TTReportField TOTAL { get {return Body().TOTAL;} }
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
                list[0] = new TTReportNqlData<StockCensus.GetCensusScheduleReportQuery_Class>("GetCensusScheduleReportQuery", StockCensus.GetCensusScheduleReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TERMID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.CARDDRAWER)));
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
                public CensusScheduleReport MyParentReport
                {
                    get { return (CensusScheduleReport)ParentReport; }
                }
                
                public TTReportField OLDORDERNO;
                public TTReportField NEWORDERNO;
                public TTReportField MATERIALNAME;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField YEARCENSUS;
                public TTReportField TOTALIN;
                public TTReportField TOTALOUT;
                public TTReportField TOTALINHELD;
                public TTReportField CONSIGNED;
                public TTReportField TOTAL; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    RepeatCount = 0;
                    
                    OLDORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 36, 13, false);
                    OLDORDERNO.Name = "OLDORDERNO";
                    OLDORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    OLDORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OLDORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLDORDERNO.MultiLine = EvetHayirEnum.ehEvet;
                    OLDORDERNO.WordBreak = EvetHayirEnum.ehEvet;
                    OLDORDERNO.TextFont.Name = "Arial";
                    OLDORDERNO.TextFont.CharSet = 162;
                    OLDORDERNO.Value = @"{#OLDORDERNO#}";

                    NEWORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 0, 48, 13, false);
                    NEWORDERNO.Name = "NEWORDERNO";
                    NEWORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NEWORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEWORDERNO.MultiLine = EvetHayirEnum.ehEvet;
                    NEWORDERNO.WordBreak = EvetHayirEnum.ehEvet;
                    NEWORDERNO.TextFont.Name = "Arial";
                    NEWORDERNO.TextFont.CharSet = 162;
                    NEWORDERNO.Value = @"{#NEWORDERNO#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 0, 109, 13, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALNAME.TextFont.Name = "Arial";
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"{#NATOSTOCKNO#} - {#MATERIALNAME#}";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 0, 128, 13, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISTRIBUTIONTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DISTRIBUTIONTYPE.MultiLine = EvetHayirEnum.ehEvet;
                    DISTRIBUTIONTYPE.WordBreak = EvetHayirEnum.ehEvet;
                    DISTRIBUTIONTYPE.TextFont.Name = "Arial";
                    DISTRIBUTIONTYPE.TextFont.CharSet = 162;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}";

                    YEARCENSUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 0, 151, 13, false);
                    YEARCENSUS.Name = "YEARCENSUS";
                    YEARCENSUS.DrawStyle = DrawStyleConstants.vbSolid;
                    YEARCENSUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    YEARCENSUS.TextFormat = @"#,###";
                    YEARCENSUS.HorzAlign = HorizontalAlignmentEnum.haRight;
                    YEARCENSUS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YEARCENSUS.MultiLine = EvetHayirEnum.ehEvet;
                    YEARCENSUS.WordBreak = EvetHayirEnum.ehEvet;
                    YEARCENSUS.TextFont.Name = "Arial";
                    YEARCENSUS.TextFont.CharSet = 162;
                    YEARCENSUS.Value = @"{#YEARCENSUS#}";

                    TOTALIN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 0, 169, 13, false);
                    TOTALIN.Name = "TOTALIN";
                    TOTALIN.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALIN.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALIN.TextFormat = @"#,###";
                    TOTALIN.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALIN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALIN.MultiLine = EvetHayirEnum.ehEvet;
                    TOTALIN.WordBreak = EvetHayirEnum.ehEvet;
                    TOTALIN.TextFont.Name = "Arial";
                    TOTALIN.TextFont.CharSet = 162;
                    TOTALIN.Value = @"{#TOTALIN#}";

                    TOTALOUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 0, 187, 13, false);
                    TOTALOUT.Name = "TOTALOUT";
                    TOTALOUT.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALOUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALOUT.TextFormat = @"#,###";
                    TOTALOUT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALOUT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALOUT.MultiLine = EvetHayirEnum.ehEvet;
                    TOTALOUT.WordBreak = EvetHayirEnum.ehEvet;
                    TOTALOUT.TextFont.Name = "Arial";
                    TOTALOUT.TextFont.CharSet = 162;
                    TOTALOUT.Value = @"{#TOTALOUT#}";

                    TOTALINHELD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 0, 212, 13, false);
                    TOTALINHELD.Name = "TOTALINHELD";
                    TOTALINHELD.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALINHELD.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALINHELD.TextFormat = @"#,###";
                    TOTALINHELD.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALINHELD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALINHELD.MultiLine = EvetHayirEnum.ehEvet;
                    TOTALINHELD.WordBreak = EvetHayirEnum.ehEvet;
                    TOTALINHELD.TextFont.Name = "Arial";
                    TOTALINHELD.TextFont.CharSet = 162;
                    TOTALINHELD.Value = @"{#TOTALINHELD#}";

                    CONSIGNED = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 0, 237, 13, false);
                    CONSIGNED.Name = "CONSIGNED";
                    CONSIGNED.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSIGNED.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSIGNED.TextFormat = @"#,###";
                    CONSIGNED.HorzAlign = HorizontalAlignmentEnum.haRight;
                    CONSIGNED.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONSIGNED.MultiLine = EvetHayirEnum.ehEvet;
                    CONSIGNED.WordBreak = EvetHayirEnum.ehEvet;
                    CONSIGNED.TextFont.Name = "Arial";
                    CONSIGNED.TextFont.CharSet = 162;
                    CONSIGNED.Value = @"{#CONSIGNED#}";

                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 0, 257, 13, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTAL.MultiLine = EvetHayirEnum.ehEvet;
                    TOTAL.WordBreak = EvetHayirEnum.ehEvet;
                    TOTAL.TextFont.Name = "Arial";
                    TOTAL.TextFont.CharSet = 162;
                    TOTAL.Value = @"{#TOTAL#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockCensus.GetCensusScheduleReportQuery_Class dataset_GetCensusScheduleReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockCensus.GetCensusScheduleReportQuery_Class>(0);
                    OLDORDERNO.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Oldorderno) : "");
                    NEWORDERNO.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Neworderno) : "");
                    MATERIALNAME.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.NATOStockNO) : "") + @" - " + (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Materialname) : "");
                    DISTRIBUTIONTYPE.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.DistributionType) : "");
                    YEARCENSUS.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Yearcensus) : "");
                    TOTALIN.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Totalin) : "");
                    TOTALOUT.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Totalout) : "");
                    TOTALINHELD.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Totalinheld) : "");
                    CONSIGNED.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Consigned) : "");
                    TOTAL.CalcValue = (dataset_GetCensusScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetCensusScheduleReportQuery.Total) : "");
                    return new TTReportObject[] { OLDORDERNO,NEWORDERNO,MATERIALNAME,DISTRIBUTIONTYPE,YEARCENSUS,TOTALIN,TOTALOUT,TOTALINHELD,CONSIGNED,TOTAL};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public CensusScheduleReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STOREID", "00000000-0000-0000-0000-000000000000", "Devri Yapılacak Depoyu Seçiniz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("cd051a98-4361-4c40-8ad6-6f7b69696f8e");
            reportParameter = Parameters.Add("TERMID", "00000000-0000-0000-0000-000000000000", "Devri Yapılacak Dönemi Seçiniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("429e41e5-620c-4652-9e24-aa488e0aaaaf");
            reportParameter = Parameters.Add("ASSETACCOUNTANT", "", "Mal Saymanını Seçiniz", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
            reportParameter.ListFilterExpression = "USERTYPE = 20";
            reportParameter = Parameters.Add("ACCOUNTRESPONSIBLE", "", "Mal Sorumlusunu Seçiniz", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
            reportParameter.ListFilterExpression = "USERTYPE = 21";
            reportParameter = Parameters.Add("CARDDRAWER", "00000000-0000-0000-0000-000000000000", "Masa", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("03e2de85-a832-4760-a20c-e921071b5c37");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STOREID"))
                _runtimeParameters.STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STOREID"]);
            if (parameters.ContainsKey("TERMID"))
                _runtimeParameters.TERMID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TERMID"]);
            if (parameters.ContainsKey("ASSETACCOUNTANT"))
                _runtimeParameters.ASSETACCOUNTANT = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["ASSETACCOUNTANT"]);
            if (parameters.ContainsKey("ACCOUNTRESPONSIBLE"))
                _runtimeParameters.ACCOUNTRESPONSIBLE = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["ACCOUNTRESPONSIBLE"]);
            if (parameters.ContainsKey("CARDDRAWER"))
                _runtimeParameters.CARDDRAWER = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["CARDDRAWER"]);
            Name = "CENSUSSCHEDULEREPORT";
            Caption = "Sayım Tartı Çizelgesi (SHH-VET. MAL SYM.)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 25;
            UserMarginTop = 15;
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