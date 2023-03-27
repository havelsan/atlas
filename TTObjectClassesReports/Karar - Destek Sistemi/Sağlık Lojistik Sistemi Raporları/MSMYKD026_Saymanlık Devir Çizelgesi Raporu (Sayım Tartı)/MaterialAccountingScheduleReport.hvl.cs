
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
    /// Mal Muhasebe Çizelgesi
    /// </summary>
    public partial class MaterialAccountingScheduleReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TERMID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTCGroup : TTReportGroup
        {
            public MaterialAccountingScheduleReport MyParentReport
            {
                get { return (MaterialAccountingScheduleReport)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField ReportName { get {return Header().ReportName;} }
            public TTReportField NewOrderNO { get {return Header().NewOrderNO;} }
            public TTReportField OldOrderNO { get {return Header().OldOrderNO;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField YearCensus { get {return Header().YearCensus;} }
            public TTReportField AtThisYear { get {return Header().AtThisYear;} }
            public TTReportField NewField12211 { get {return Header().NewField12211;} }
            public TTReportField NewField111221 { get {return Header().NewField111221;} }
            public TTReportField NewYearCensus { get {return Header().NewYearCensus;} }
            public TTReportField NewField121221 { get {return Header().NewField121221;} }
            public TTReportField NewField1122121 { get {return Header().NewField1122121;} }
            public TTReportField NewField131111 { get {return Header().NewField131111;} }
            public TTReportField NewField11122121212 { get {return Header().NewField11122121212;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField111112 { get {return Header().NewField111112;} }
            public TTReportField NewField111113 { get {return Header().NewField111113;} }
            public TTReportField NewField111222 { get {return Header().NewField111222;} }
            public TTReportField NewField111223 { get {return Header().NewField111223;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField TermID { get {return Header().TermID;} }
            public TTReportField HospitalName { get {return Header().HospitalName;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportShape NewLine11111 { get {return Footer().NewLine11111;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public MaterialAccountingScheduleReport MyParentReport
                {
                    get { return (MaterialAccountingScheduleReport)ParentReport; }
                }
                
                public TTReportField ReportName;
                public TTReportField NewOrderNO;
                public TTReportField OldOrderNO;
                public TTReportField NewField121;
                public TTReportField NewField1121;
                public TTReportField NewField11211;
                public TTReportField NewField1111;
                public TTReportField YearCensus;
                public TTReportField AtThisYear;
                public TTReportField NewField12211;
                public TTReportField NewField111221;
                public TTReportField NewYearCensus;
                public TTReportField NewField121221;
                public TTReportField NewField1122121;
                public TTReportField NewField131111;
                public TTReportField NewField11122121212;
                public TTReportField NewField11111;
                public TTReportField NewField111111;
                public TTReportField NewField111112;
                public TTReportField NewField111113;
                public TTReportField NewField111222;
                public TTReportField NewField111223;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField TermID;
                public TTReportField HospitalName; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 0, 230, 8, false);
                    ReportName.Name = "ReportName";
                    ReportName.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.NoClip = EvetHayirEnum.ehEvet;
                    ReportName.TextFont.Size = 12;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"";

                    NewOrderNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 8, 12, 23, false);
                    NewOrderNO.Name = "NewOrderNO";
                    NewOrderNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NewOrderNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewOrderNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewOrderNO.MultiLine = EvetHayirEnum.ehEvet;
                    NewOrderNO.WordBreak = EvetHayirEnum.ehEvet;
                    NewOrderNO.TextFont.Bold = true;
                    NewOrderNO.TextFont.CharSet = 162;
                    NewOrderNO.Value = @"";

                    OldOrderNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 8, 24, 23, false);
                    OldOrderNO.Name = "OldOrderNO";
                    OldOrderNO.DrawStyle = DrawStyleConstants.vbSolid;
                    OldOrderNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO.MultiLine = EvetHayirEnum.ehEvet;
                    OldOrderNO.WordBreak = EvetHayirEnum.ehEvet;
                    OldOrderNO.TextFont.Bold = true;
                    OldOrderNO.TextFont.CharSet = 162;
                    OldOrderNO.Value = @"";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 8, 151, 13, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Malzemenin";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 13, 52, 23, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"NATO Stok Nu.";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 13, 151, 23, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"İsmi";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 8, 170, 23, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Ölçü Birimi";

                    YearCensus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 8, 191, 23, false);
                    YearCensus.Name = "YearCensus";
                    YearCensus.DrawStyle = DrawStyleConstants.vbSolid;
                    YearCensus.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YearCensus.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YearCensus.MultiLine = EvetHayirEnum.ehEvet;
                    YearCensus.WordBreak = EvetHayirEnum.ehEvet;
                    YearCensus.TextFont.Bold = true;
                    YearCensus.TextFont.CharSet = 162;
                    YearCensus.Value = @"";

                    AtThisYear = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 8, 217, 13, false);
                    AtThisYear.Name = "AtThisYear";
                    AtThisYear.DrawStyle = DrawStyleConstants.vbSolid;
                    AtThisYear.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AtThisYear.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AtThisYear.MultiLine = EvetHayirEnum.ehEvet;
                    AtThisYear.WordBreak = EvetHayirEnum.ehEvet;
                    AtThisYear.TextFont.Bold = true;
                    AtThisYear.TextFont.CharSet = 162;
                    AtThisYear.Value = @"";

                    NewField12211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 13, 204, 23, false);
                    NewField12211.Name = "NewField12211";
                    NewField12211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12211.TextFont.Bold = true;
                    NewField12211.TextFont.CharSet = 162;
                    NewField12211.Value = @"Giren";

                    NewField111221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 13, 217, 23, false);
                    NewField111221.Name = "NewField111221";
                    NewField111221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111221.TextFont.Bold = true;
                    NewField111221.TextFont.CharSet = 162;
                    NewField111221.Value = @"Çıkan";

                    NewYearCensus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 326, 8, 360, 13, false);
                    NewYearCensus.Name = "NewYearCensus";
                    NewYearCensus.DrawStyle = DrawStyleConstants.vbSolid;
                    NewYearCensus.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewYearCensus.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewYearCensus.TextFont.Bold = true;
                    NewYearCensus.TextFont.CharSet = 162;
                    NewYearCensus.Value = @"";

                    NewField121221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 326, 13, 343, 23, false);
                    NewField121221.Name = "NewField121221";
                    NewField121221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121221.TextFont.Bold = true;
                    NewField121221.TextFont.CharSet = 162;
                    NewField121221.Value = @"Depo Mev.";

                    NewField1122121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 343, 13, 360, 23, false);
                    NewField1122121.Name = "NewField1122121";
                    NewField1122121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1122121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1122121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1122121.TextFont.Bold = true;
                    NewField1122121.TextFont.CharSet = 162;
                    NewField1122121.Value = @"Muvakkat";

                    NewField131111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 360, 8, 380, 23, false);
                    NewField131111.Name = "NewField131111";
                    NewField131111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField131111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField131111.TextFont.Bold = true;
                    NewField131111.TextFont.CharSet = 162;
                    NewField131111.Value = @"Toplam";

                    NewField11122121212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 8, 230, 23, false);
                    NewField11122121212.Name = "NewField11122121212";
                    NewField11122121212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11122121212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11122121212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11122121212.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11122121212.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11122121212.TextFont.Bold = true;
                    NewField11122121212.TextFont.CharSet = 162;
                    NewField11122121212.Value = @"İşlem Kodu";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 8, 248, 23, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Belge Döküman Nu.";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 8, 266, 23, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"Artış/
Eksiliş Miktarı";

                    NewField111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 266, 8, 283, 23, false);
                    NewField111112.Name = "NewField111112";
                    NewField111112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111112.TextFont.Bold = true;
                    NewField111112.TextFont.CharSet = 162;
                    NewField111112.Value = @"İşlem Tarihi";

                    NewField111113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 283, 8, 326, 13, false);
                    NewField111113.Name = "NewField111113";
                    NewField111113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111113.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111113.TextFont.Bold = true;
                    NewField111113.TextFont.CharSet = 162;
                    NewField111113.Value = @"İşlem Sonucu Mik.";

                    NewField111222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 283, 13, 307, 18, false);
                    NewField111222.Name = "NewField111222";
                    NewField111222.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111222.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111222.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111222.TextFont.Bold = true;
                    NewField111222.TextFont.CharSet = 162;
                    NewField111222.Value = @"Depo Miktarı";

                    NewField111223 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 307, 13, 326, 23, false);
                    NewField111223.Name = "NewField111223";
                    NewField111223.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111223.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111223.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111223.TextFont.Bold = true;
                    NewField111223.TextFont.CharSet = 162;
                    NewField111223.Value = @"Muvakkat";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 283, 18, 295, 23, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Y";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 295, 18, 307, 23, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"K";

                    TermID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 432, 9, 457, 14, false);
                    TermID.Name = "TermID";
                    TermID.Visible = EvetHayirEnum.ehHayir;
                    TermID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TermID.TextFormat = @"dd/MM/yyyy";
                    TermID.ObjectDefName = "AccountingTerm";
                    TermID.DataMember = "STARTDATE";
                    TermID.Value = @"{@TERMID@}";

                    HospitalName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 0, 38, 5, false);
                    HospitalName.Name = "HospitalName";
                    HospitalName.Visible = EvetHayirEnum.ehHayir;
                    HospitalName.FieldType = ReportFieldTypeEnum.ftExpression;
                    HospitalName.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReportName.CalcValue = ReportName.Value;
                    NewOrderNO.CalcValue = NewOrderNO.Value;
                    OldOrderNO.CalcValue = OldOrderNO.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    YearCensus.CalcValue = YearCensus.Value;
                    AtThisYear.CalcValue = AtThisYear.Value;
                    NewField12211.CalcValue = NewField12211.Value;
                    NewField111221.CalcValue = NewField111221.Value;
                    NewYearCensus.CalcValue = NewYearCensus.Value;
                    NewField121221.CalcValue = NewField121221.Value;
                    NewField1122121.CalcValue = NewField1122121.Value;
                    NewField131111.CalcValue = NewField131111.Value;
                    NewField11122121212.CalcValue = NewField11122121212.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField111112.CalcValue = NewField111112.Value;
                    NewField111113.CalcValue = NewField111113.Value;
                    NewField111222.CalcValue = NewField111222.Value;
                    NewField111223.CalcValue = NewField111223.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    TermID.CalcValue = MyParentReport.RuntimeParameters.TERMID.ToString();
                    TermID.PostFieldValueCalculation();
                    HospitalName.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { ReportName,NewOrderNO,OldOrderNO,NewField121,NewField1121,NewField11211,NewField1111,YearCensus,AtThisYear,NewField12211,NewField111221,NewYearCensus,NewField121221,NewField1122121,NewField131111,NewField11122121212,NewField11111,NewField111111,NewField111112,NewField111113,NewField111222,NewField111223,NewField1,NewField11,TermID,HospitalName};
                }

                public override void RunScript()
                {
#region PARTC HEADER_Script
                    DateTime termYear = new DateTime();
                    termYear = Convert.ToDateTime(this.TermID.CalcValue);
                    this.ReportName.CalcValue = this.HospitalName.CalcValue + " " + termYear.Year.ToString() + " MAL MUHASEBE ÇİZELGESİ";
                    NewOrderNO.CalcValue = termYear.Year.ToString() + " Yılı Sıra Nu.";
                    OldOrderNO.CalcValue = (termYear.Year - 1).ToString() + " Yılı Sıra Nu.";
                    YearCensus.CalcValue = (termYear.Year - 1).ToString() + " Yılından Devir Miktarı";
                    AtThisYear.CalcValue = termYear.Year.ToString() + " Yılında";
                    NewYearCensus.CalcValue = (termYear.Year + 1).ToString() + " Yılına Devir";
#endregion PARTC HEADER_Script
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public MaterialAccountingScheduleReport MyParentReport
                {
                    get { return (MaterialAccountingScheduleReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField PageNumber;
                public TTReportField CurrentUser;
                public TTReportShape NewLine11111; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 35;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 25, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 355, 0, 380, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 0, 205, 5, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 380, 0, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = @"Sayfa Nu." + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate,PageNumber,CurrentUser};
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTAGroup : TTReportGroup
        {
            public MaterialAccountingScheduleReport MyParentReport
            {
                get { return (MaterialAccountingScheduleReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField OBJECTID { get {return Header().OBJECTID;} }
            public TTReportField MATERIALID { get {return Header().MATERIALID;} }
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
                list[0] = new TTReportNqlData<StockCensusDetail.GetObjectIDForMaterialAccountingReportQuery_Class>("GetObjectIDForMaterialAccountingReportQuery", StockCensusDetail.GetObjectIDForMaterialAccountingReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TERMID)));
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
                public MaterialAccountingScheduleReport MyParentReport
                {
                    get { return (MaterialAccountingScheduleReport)ParentReport; }
                }
                
                public TTReportField OBJECTID;
                public TTReportField MATERIALID; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 5;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 0, 39, 5, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    MATERIALID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 58, 5, false);
                    MATERIALID.Name = "MATERIALID";
                    MATERIALID.Visible = EvetHayirEnum.ehHayir;
                    MATERIALID.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALID.Value = @"{#MATERIALID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockCensusDetail.GetObjectIDForMaterialAccountingReportQuery_Class dataset_GetObjectIDForMaterialAccountingReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockCensusDetail.GetObjectIDForMaterialAccountingReportQuery_Class>(0);
                    OBJECTID.CalcValue = (dataset_GetObjectIDForMaterialAccountingReportQuery != null ? Globals.ToStringCore(dataset_GetObjectIDForMaterialAccountingReportQuery.ObjectID) : "");
                    MATERIALID.CalcValue = (dataset_GetObjectIDForMaterialAccountingReportQuery != null ? Globals.ToStringCore(dataset_GetObjectIDForMaterialAccountingReportQuery.Materialid) : "");
                    return new TTReportObject[] { OBJECTID,MATERIALID};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public MaterialAccountingScheduleReport MyParentReport
                {
                    get { return (MaterialAccountingScheduleReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTDGroup : TTReportGroup
        {
            public MaterialAccountingScheduleReport MyParentReport
            {
                get { return (MaterialAccountingScheduleReport)ParentReport; }
            }

            new public PARTDGroupHeader Header()
            {
                return (PARTDGroupHeader)_header;
            }

            new public PARTDGroupFooter Footer()
            {
                return (PARTDGroupFooter)_footer;
            }

            public TTReportField NewOrderNo { get {return Header().NewOrderNo;} }
            public TTReportField OldOrderNo { get {return Header().OldOrderNo;} }
            public TTReportField NatoStockNo { get {return Header().NatoStockNo;} }
            public TTReportField MaterialName { get {return Header().MaterialName;} }
            public TTReportField DistributionType { get {return Header().DistributionType;} }
            public TTReportField YearCensus { get {return Header().YearCensus;} }
            public TTReportField TotalIn { get {return Header().TotalIn;} }
            public TTReportField TotalOut { get {return Header().TotalOut;} }
            public TTReportField NewInheld { get {return Header().NewInheld;} }
            public TTReportField NewConsigned { get {return Header().NewConsigned;} }
            public TTReportField Total { get {return Header().Total;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportShape NewLine121 { get {return Header().NewLine121;} }
            public TTReportShape NewLine13 { get {return Header().NewLine13;} }
            public TTReportShape NewLine14 { get {return Header().NewLine14;} }
            public TTReportShape NewLine15 { get {return Header().NewLine15;} }
            public TTReportShape NewLine16 { get {return Header().NewLine16;} }
            public TTReportShape NewLine17 { get {return Header().NewLine17;} }
            public TTReportShape NewLine18 { get {return Header().NewLine18;} }
            public TTReportShape NewLine19 { get {return Header().NewLine19;} }
            public TTReportShape NewLine101 { get {return Header().NewLine101;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportShape NewLine161 { get {return Header().NewLine161;} }
            public TTReportShape NewLine171 { get {return Header().NewLine171;} }
            public TTReportShape NewLine181 { get {return Header().NewLine181;} }
            public TTReportShape NewLine191 { get {return Header().NewLine191;} }
            public TTReportShape NewLine131 { get {return Header().NewLine131;} }
            public TTReportShape NewLine151 { get {return Header().NewLine151;} }
            public TTReportShape NewLine141 { get {return Header().NewLine141;} }
            public TTReportField OldInheld { get {return Header().OldInheld;} }
            public TTReportField OldConsigned { get {return Header().OldConsigned;} }
            public TTReportField OldUsed { get {return Header().OldUsed;} }
            public TTReportShape NewLine20 { get {return Header().NewLine20;} }
            public TTReportShape NewLine112 { get {return Footer().NewLine112;} }
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
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[2];
                list[0] = new TTReportNqlData<StockCensusDetail.GetMaterialAccountingScheduleReportQuery_Class>("GetMaterialAccountingScheduleReportQuery", StockCensusDetail.GetMaterialAccountingScheduleReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTA.OBJECTID.CalcValue)));
                list[1] = new TTReportNqlData<StockCensusDetail.GetOldInfoForMaterialAccountingReportQuery_Class>("GetOldInfoForMaterialAccountingReportQuery", StockCensusDetail.GetOldInfoForMaterialAccountingReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTA.MATERIALID.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.PARTC.TermID.FormattedValue)));
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
                public MaterialAccountingScheduleReport MyParentReport
                {
                    get { return (MaterialAccountingScheduleReport)ParentReport; }
                }
                
                public TTReportField NewOrderNo;
                public TTReportField OldOrderNo;
                public TTReportField NatoStockNo;
                public TTReportField MaterialName;
                public TTReportField DistributionType;
                public TTReportField YearCensus;
                public TTReportField TotalIn;
                public TTReportField TotalOut;
                public TTReportField NewInheld;
                public TTReportField NewConsigned;
                public TTReportField Total;
                public TTReportShape NewLine12;
                public TTReportShape NewLine121;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportShape NewLine15;
                public TTReportShape NewLine16;
                public TTReportShape NewLine17;
                public TTReportShape NewLine18;
                public TTReportShape NewLine19;
                public TTReportShape NewLine101;
                public TTReportShape NewLine111;
                public TTReportShape NewLine11;
                public TTReportShape NewLine161;
                public TTReportShape NewLine171;
                public TTReportShape NewLine181;
                public TTReportShape NewLine191;
                public TTReportShape NewLine131;
                public TTReportShape NewLine151;
                public TTReportShape NewLine141;
                public TTReportField OldInheld;
                public TTReportField OldConsigned;
                public TTReportField OldUsed;
                public TTReportShape NewLine20; 
                public PARTDGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewOrderNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 12, 5, false);
                    NewOrderNo.Name = "NewOrderNo";
                    NewOrderNo.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewOrderNo.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewOrderNo.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewOrderNo.Value = @"{#NEWCARDORDER#}";

                    OldOrderNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 0, 24, 5, false);
                    OldOrderNo.Name = "OldOrderNo";
                    OldOrderNo.FieldType = ReportFieldTypeEnum.ftVariable;
                    OldOrderNo.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OldOrderNo.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNo.Value = @"{#OLDORDERNO#}";

                    NatoStockNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 0, 52, 5, false);
                    NatoStockNo.Name = "NatoStockNo";
                    NatoStockNo.FieldType = ReportFieldTypeEnum.ftVariable;
                    NatoStockNo.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NatoStockNo.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NatoStockNo.Value = @"{#NATOSTOCKNO#}";

                    MaterialName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 0, 151, 5, false);
                    MaterialName.Name = "MaterialName";
                    MaterialName.FieldType = ReportFieldTypeEnum.ftVariable;
                    MaterialName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    MaterialName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MaterialName.Value = @"{#MATERIALNAME#}";

                    DistributionType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 0, 170, 5, false);
                    DistributionType.Name = "DistributionType";
                    DistributionType.FieldType = ReportFieldTypeEnum.ftVariable;
                    DistributionType.CaseFormat = CaseFormatEnum.fcTitleCase;
                    DistributionType.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DistributionType.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DistributionType.Value = @"{#DISTRIBUTIONTYPE#}";

                    YearCensus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 0, 191, 5, false);
                    YearCensus.Name = "YearCensus";
                    YearCensus.FieldType = ReportFieldTypeEnum.ftVariable;
                    YearCensus.TextFormat = @"#,###";
                    YearCensus.HorzAlign = HorizontalAlignmentEnum.haRight;
                    YearCensus.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YearCensus.Value = @"{#YEARCENSUS#}";

                    TotalIn = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 0, 204, 5, false);
                    TotalIn.Name = "TotalIn";
                    TotalIn.FieldType = ReportFieldTypeEnum.ftVariable;
                    TotalIn.TextFormat = @"#,###";
                    TotalIn.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TotalIn.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TotalIn.Value = @"{#TOTALIN#}";

                    TotalOut = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 0, 217, 5, false);
                    TotalOut.Name = "TotalOut";
                    TotalOut.FieldType = ReportFieldTypeEnum.ftVariable;
                    TotalOut.TextFormat = @"#,###";
                    TotalOut.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TotalOut.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TotalOut.Value = @"{#TOTALOUT#}";

                    NewInheld = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 326, 0, 343, 5, false);
                    NewInheld.Name = "NewInheld";
                    NewInheld.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewInheld.TextFormat = @"#,###";
                    NewInheld.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewInheld.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewInheld.Value = @"{#TOTALINHELD#}";

                    NewConsigned = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 343, 0, 360, 5, false);
                    NewConsigned.Name = "NewConsigned";
                    NewConsigned.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewConsigned.TextFormat = @"#,###";
                    NewConsigned.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewConsigned.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewConsigned.Value = @"{#CONSIGNED#}";

                    Total = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 360, 0, 380, 5, false);
                    Total.Name = "Total";
                    Total.FieldType = ReportFieldTypeEnum.ftExpression;
                    Total.TextFormat = @"#,###";
                    Total.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Total.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Total.Value = @"(Convert.ToDouble(NewInheld.CalcValue)+Convert.ToDouble(NewConsigned.CalcValue)).ToString()";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 12, 0, 12, 5, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 24, 0, 24, 5, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 52, 0, 52, 5, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 151, 0, 151, 5, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 170, 0, 170, 5, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 191, 0, 191, 5, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 204, 0, 204, 5, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 217, 0, 217, 5, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine19 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 230, 0, 230, 5, false);
                    NewLine19.Name = "NewLine19";
                    NewLine19.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine101 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 248, 0, 248, 5, false);
                    NewLine101.Name = "NewLine101";
                    NewLine101.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 266, 0, 266, 5, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 380, 0, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 326, 0, 326, 5, false);
                    NewLine161.Name = "NewLine161";
                    NewLine161.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine171 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 343, 0, 343, 5, false);
                    NewLine171.Name = "NewLine171";
                    NewLine171.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine181 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 360, 0, 360, 5, false);
                    NewLine181.Name = "NewLine181";
                    NewLine181.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine191 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 380, 0, 380, 5, false);
                    NewLine191.Name = "NewLine191";
                    NewLine191.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 283, 0, 283, 5, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 307, 0, 307, 5, false);
                    NewLine151.Name = "NewLine151";
                    NewLine151.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 295, 0, 295, 5, false);
                    NewLine141.Name = "NewLine141";
                    NewLine141.DrawStyle = DrawStyleConstants.vbSolid;

                    OldInheld = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 432, 0, 457, 5, false);
                    OldInheld.Name = "OldInheld";
                    OldInheld.Visible = EvetHayirEnum.ehHayir;
                    OldInheld.FieldType = ReportFieldTypeEnum.ftVariable;
                    OldInheld.Value = @"{#INHELD!GetOldInfoForMaterialAccountingReportQuery#}";

                    OldConsigned = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 459, 0, 484, 5, false);
                    OldConsigned.Name = "OldConsigned";
                    OldConsigned.Visible = EvetHayirEnum.ehHayir;
                    OldConsigned.FieldType = ReportFieldTypeEnum.ftVariable;
                    OldConsigned.Value = @"{#CONSIGNED!GetOldInfoForMaterialAccountingReportQuery#}";

                    OldUsed = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 486, 0, 511, 5, false);
                    OldUsed.Name = "OldUsed";
                    OldUsed.Visible = EvetHayirEnum.ehHayir;
                    OldUsed.FieldType = ReportFieldTypeEnum.ftVariable;
                    OldUsed.Value = @"{#USED!GetOldInfoForMaterialAccountingReportQuery#}";

                    NewLine20 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 0, 5, false);
                    NewLine20.Name = "NewLine20";
                    NewLine20.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockCensusDetail.GetMaterialAccountingScheduleReportQuery_Class dataset_GetMaterialAccountingScheduleReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockCensusDetail.GetMaterialAccountingScheduleReportQuery_Class>(0);
                    StockCensusDetail.GetOldInfoForMaterialAccountingReportQuery_Class dataset_GetOldInfoForMaterialAccountingReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockCensusDetail.GetOldInfoForMaterialAccountingReportQuery_Class>(1);
                    NewOrderNo.CalcValue = (dataset_GetMaterialAccountingScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetMaterialAccountingScheduleReportQuery.Newcardorder) : "");
                    OldOrderNo.CalcValue = (dataset_GetMaterialAccountingScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetMaterialAccountingScheduleReportQuery.Oldorderno) : "");
                    NatoStockNo.CalcValue = (dataset_GetMaterialAccountingScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetMaterialAccountingScheduleReportQuery.NATOStockNO) : "");
                    MaterialName.CalcValue = (dataset_GetMaterialAccountingScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetMaterialAccountingScheduleReportQuery.Materialname) : "");
                    DistributionType.CalcValue = (dataset_GetMaterialAccountingScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetMaterialAccountingScheduleReportQuery.DistributionType) : "");
                    YearCensus.CalcValue = (dataset_GetMaterialAccountingScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetMaterialAccountingScheduleReportQuery.YearCensus) : "");
                    TotalIn.CalcValue = (dataset_GetMaterialAccountingScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetMaterialAccountingScheduleReportQuery.TotalIn) : "");
                    TotalOut.CalcValue = (dataset_GetMaterialAccountingScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetMaterialAccountingScheduleReportQuery.TotalOut) : "");
                    NewInheld.CalcValue = (dataset_GetMaterialAccountingScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetMaterialAccountingScheduleReportQuery.TotalInHeld) : "");
                    NewConsigned.CalcValue = (dataset_GetMaterialAccountingScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetMaterialAccountingScheduleReportQuery.Consigned) : "");
                    OldInheld.CalcValue = (dataset_GetOldInfoForMaterialAccountingReportQuery != null ? Globals.ToStringCore(dataset_GetOldInfoForMaterialAccountingReportQuery.Inheld) : "");
                    OldConsigned.CalcValue = (dataset_GetOldInfoForMaterialAccountingReportQuery != null ? Globals.ToStringCore(dataset_GetOldInfoForMaterialAccountingReportQuery.Consigned) : "");
                    OldUsed.CalcValue = (dataset_GetOldInfoForMaterialAccountingReportQuery != null ? Globals.ToStringCore(dataset_GetOldInfoForMaterialAccountingReportQuery.Used) : "");
                    Total.CalcValue = (Convert.ToDouble(NewInheld.CalcValue)+Convert.ToDouble(NewConsigned.CalcValue)).ToString();
                    return new TTReportObject[] { NewOrderNo,OldOrderNo,NatoStockNo,MaterialName,DistributionType,YearCensus,TotalIn,TotalOut,NewInheld,NewConsigned,OldInheld,OldConsigned,OldUsed,Total};
                }

                public override void RunScript()
                {
#region PARTD HEADER_Script
                    if(OldInheld.CalcValue != "")
                actionNew = Convert.ToDouble(OldInheld.CalcValue);
            if(OldUsed.CalcValue != "")
                actionUsed = Convert.ToDouble(OldUsed.CalcValue);
            if(OldConsigned.CalcValue != "")
                actionConsigned = Convert.ToDouble(OldConsigned.CalcValue);
#endregion PARTD HEADER_Script
                }
            }
            public partial class PARTDGroupFooter : TTReportSection
            {
                public MaterialAccountingScheduleReport MyParentReport
                {
                    get { return (MaterialAccountingScheduleReport)ParentReport; }
                }
                
                public TTReportShape NewLine112; 
                public PARTDGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 30;
                    RepeatCount = 0;
                    
                    NewLine112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 380, 0, false);
                    NewLine112.Name = "NewLine112";
                    NewLine112.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockCensusDetail.GetMaterialAccountingScheduleReportQuery_Class dataset_GetMaterialAccountingScheduleReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockCensusDetail.GetMaterialAccountingScheduleReportQuery_Class>(0);
                    StockCensusDetail.GetOldInfoForMaterialAccountingReportQuery_Class dataset_GetOldInfoForMaterialAccountingReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockCensusDetail.GetOldInfoForMaterialAccountingReportQuery_Class>(1);
                    return new TTReportObject[] { };
                }
            }

#region PARTD_Methods
            public static double actionNew = 0, actionUsed = 0, actionConsigned = 0;
#endregion PARTD_Methods
        }

        public PARTDGroup PARTD;

        public partial class MAINGroup : TTReportGroup
        {
            public MaterialAccountingScheduleReport MyParentReport
            {
                get { return (MaterialAccountingScheduleReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField TransactionAmount { get {return Body().TransactionAmount;} }
            public TTReportField DocumentNO { get {return Body().DocumentNO;} }
            public TTReportField ActionCode { get {return Body().ActionCode;} }
            public TTReportField TransactionDate { get {return Body().TransactionDate;} }
            public TTReportField Consigned { get {return Body().Consigned;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine3 { get {return Body().NewLine3;} }
            public TTReportShape NewLine4 { get {return Body().NewLine4;} }
            public TTReportShape NewLine5 { get {return Body().NewLine5;} }
            public TTReportShape NewLine6 { get {return Body().NewLine6;} }
            public TTReportShape NewLine7 { get {return Body().NewLine7;} }
            public TTReportShape NewLine8 { get {return Body().NewLine8;} }
            public TTReportShape NewLine9 { get {return Body().NewLine9;} }
            public TTReportShape NewLine10 { get {return Body().NewLine10;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine16 { get {return Body().NewLine16;} }
            public TTReportShape NewLine17 { get {return Body().NewLine17;} }
            public TTReportShape NewLine18 { get {return Body().NewLine18;} }
            public TTReportShape NewLine19 { get {return Body().NewLine19;} }
            public TTReportField New { get {return Body().New;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportField Used { get {return Body().Used;} }
            public TTReportShape NewLine15 { get {return Body().NewLine15;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportField MaintainLevelCode { get {return Body().MaintainLevelCode;} }
            public TTReportField StockLevelType { get {return Body().StockLevelType;} }
            public TTReportField InOut { get {return Body().InOut;} }
            public TTReportField Amount { get {return Body().Amount;} }
            public TTReportShape NewLine20 { get {return Body().NewLine20;} }
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
                list[0] = new TTReportNqlData<StockCensusDetail.GetDetailsForMaterialAccountingScheduleReportQuery_Class>("GetDetailsForMaterialAccountingScheduleReportQuery", StockCensusDetail.GetDetailsForMaterialAccountingScheduleReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTA.OBJECTID.CalcValue)));
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
                public MaterialAccountingScheduleReport MyParentReport
                {
                    get { return (MaterialAccountingScheduleReport)ParentReport; }
                }
                
                public TTReportField TransactionAmount;
                public TTReportField DocumentNO;
                public TTReportField ActionCode;
                public TTReportField TransactionDate;
                public TTReportField Consigned;
                public TTReportShape NewLine2;
                public TTReportShape NewLine12;
                public TTReportShape NewLine3;
                public TTReportShape NewLine4;
                public TTReportShape NewLine5;
                public TTReportShape NewLine6;
                public TTReportShape NewLine7;
                public TTReportShape NewLine8;
                public TTReportShape NewLine9;
                public TTReportShape NewLine10;
                public TTReportShape NewLine11;
                public TTReportShape NewLine16;
                public TTReportShape NewLine17;
                public TTReportShape NewLine18;
                public TTReportShape NewLine19;
                public TTReportField New;
                public TTReportShape NewLine13;
                public TTReportField Used;
                public TTReportShape NewLine15;
                public TTReportShape NewLine14;
                public TTReportField MaintainLevelCode;
                public TTReportField StockLevelType;
                public TTReportField InOut;
                public TTReportField Amount;
                public TTReportShape NewLine20; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    TransactionAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 0, 266, 5, false);
                    TransactionAmount.Name = "TransactionAmount";
                    TransactionAmount.FieldType = ReportFieldTypeEnum.ftVariable;
                    TransactionAmount.TextFormat = @"#,###";
                    TransactionAmount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TransactionAmount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TransactionAmount.Value = @"";

                    DocumentNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 0, 248, 5, false);
                    DocumentNO.Name = "DocumentNO";
                    DocumentNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DocumentNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DocumentNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DocumentNO.Value = @"{#DOCUMENTNO#}";

                    ActionCode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 0, 230, 5, false);
                    ActionCode.Name = "ActionCode";
                    ActionCode.FieldType = ReportFieldTypeEnum.ftVariable;
                    ActionCode.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ActionCode.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ActionCode.Value = @"{#ACTIONCODE#}";

                    TransactionDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 266, 0, 283, 5, false);
                    TransactionDate.Name = "TransactionDate";
                    TransactionDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    TransactionDate.TextFormat = @"dd/MM/yyyy";
                    TransactionDate.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TransactionDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TransactionDate.Value = @"{#TRANSACTIONDATE#}";

                    Consigned = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 307, 0, 326, 5, false);
                    Consigned.Name = "Consigned";
                    Consigned.FieldType = ReportFieldTypeEnum.ftVariable;
                    Consigned.TextFormat = @"#,###";
                    Consigned.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Consigned.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Consigned.Value = @"";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 12, 0, 12, 5, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 24, 0, 24, 5, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 52, 0, 52, 5, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 151, 0, 151, 5, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine5 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 170, 0, 170, 5, false);
                    NewLine5.Name = "NewLine5";
                    NewLine5.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 191, 0, 191, 5, false);
                    NewLine6.Name = "NewLine6";
                    NewLine6.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine7 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 204, 0, 204, 5, false);
                    NewLine7.Name = "NewLine7";
                    NewLine7.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine8 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 217, 0, 217, 5, false);
                    NewLine8.Name = "NewLine8";
                    NewLine8.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine9 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 230, 0, 230, 5, false);
                    NewLine9.Name = "NewLine9";
                    NewLine9.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine10 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 248, 0, 248, 5, false);
                    NewLine10.Name = "NewLine10";
                    NewLine10.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 266, 0, 266, 5, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 326, 0, 326, 5, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 343, 0, 343, 5, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 360, 0, 360, 5, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine19 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 380, 0, 380, 5, false);
                    NewLine19.Name = "NewLine19";
                    NewLine19.DrawStyle = DrawStyleConstants.vbSolid;

                    New = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 283, 0, 295, 5, false);
                    New.Name = "New";
                    New.FieldType = ReportFieldTypeEnum.ftVariable;
                    New.TextFormat = @"#,###";
                    New.HorzAlign = HorizontalAlignmentEnum.haRight;
                    New.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    New.Value = @"";

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 283, 0, 283, 5, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    Used = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 295, 0, 307, 5, false);
                    Used.Name = "Used";
                    Used.FieldType = ReportFieldTypeEnum.ftVariable;
                    Used.TextFormat = @"#,###";
                    Used.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Used.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Used.Value = @"";

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 307, 0, 307, 5, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 295, 0, 295, 5, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    MaintainLevelCode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 432, 0, 457, 5, false);
                    MaintainLevelCode.Name = "MaintainLevelCode";
                    MaintainLevelCode.Visible = EvetHayirEnum.ehHayir;
                    MaintainLevelCode.FieldType = ReportFieldTypeEnum.ftVariable;
                    MaintainLevelCode.Value = @"{#MAINTAINLEVELCODE#}";

                    StockLevelType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 459, 0, 484, 5, false);
                    StockLevelType.Name = "StockLevelType";
                    StockLevelType.Visible = EvetHayirEnum.ehHayir;
                    StockLevelType.FieldType = ReportFieldTypeEnum.ftVariable;
                    StockLevelType.Value = @"{#STOCKLEVELTYPESTATUS#}";

                    InOut = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 486, 0, 511, 5, false);
                    InOut.Name = "InOut";
                    InOut.Visible = EvetHayirEnum.ehHayir;
                    InOut.FieldType = ReportFieldTypeEnum.ftVariable;
                    InOut.Value = @"{#INOUT#}";

                    Amount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 513, 0, 538, 5, false);
                    Amount.Name = "Amount";
                    Amount.Visible = EvetHayirEnum.ehHayir;
                    Amount.FieldType = ReportFieldTypeEnum.ftVariable;
                    Amount.Value = @"{#AMOUNT#}";

                    NewLine20 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 0, 5, false);
                    NewLine20.Name = "NewLine20";
                    NewLine20.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockCensusDetail.GetDetailsForMaterialAccountingScheduleReportQuery_Class dataset_GetDetailsForMaterialAccountingScheduleReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockCensusDetail.GetDetailsForMaterialAccountingScheduleReportQuery_Class>(0);
                    TransactionAmount.CalcValue = @"";
                    DocumentNO.CalcValue = (dataset_GetDetailsForMaterialAccountingScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetDetailsForMaterialAccountingScheduleReportQuery.Documentno) : "");
                    ActionCode.CalcValue = (dataset_GetDetailsForMaterialAccountingScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetDetailsForMaterialAccountingScheduleReportQuery.Actioncode) : "");
                    TransactionDate.CalcValue = (dataset_GetDetailsForMaterialAccountingScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetDetailsForMaterialAccountingScheduleReportQuery.TransactionDate) : "");
                    Consigned.CalcValue = @"";
                    New.CalcValue = @"";
                    Used.CalcValue = @"";
                    MaintainLevelCode.CalcValue = (dataset_GetDetailsForMaterialAccountingScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetDetailsForMaterialAccountingScheduleReportQuery.MaintainLevelCode) : "");
                    StockLevelType.CalcValue = (dataset_GetDetailsForMaterialAccountingScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetDetailsForMaterialAccountingScheduleReportQuery.StockLevelTypeStatus) : "");
                    InOut.CalcValue = (dataset_GetDetailsForMaterialAccountingScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetDetailsForMaterialAccountingScheduleReportQuery.InOut) : "");
                    Amount.CalcValue = (dataset_GetDetailsForMaterialAccountingScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetDetailsForMaterialAccountingScheduleReportQuery.Amount) : "");
                    return new TTReportObject[] { TransactionAmount,DocumentNO,ActionCode,TransactionDate,Consigned,New,Used,MaintainLevelCode,StockLevelType,InOut,Amount};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(this.InOut.CalcValue == "In")
            {
                this.TransactionAmount.CalcValue = this.Amount.CalcValue;
            }
            else if(InOut.CalcValue == "Out")
            {
                this.TransactionAmount.CalcValue = " - " + this.Amount.CalcValue;
            }
            
            double amount = 0;
            if(Amount.CalcValue != "")
                amount = Convert.ToDouble(Amount.CalcValue);
            
            switch(this.MaintainLevelCode.CalcValue)
            {
                case "IncreaseInheld":
                    if(this.StockLevelType.CalcValue == "New")
                    {
                        PARTDGroup.actionNew = PARTDGroup.actionNew + amount;
                        this.New.CalcValue = PARTDGroup.actionNew.ToString();
                    }
                    else if(this.StockLevelType.CalcValue == "Used")
                    {
                        PARTDGroup.actionUsed = PARTDGroup.actionUsed + amount;
                        this.Used.CalcValue = PARTDGroup.actionUsed.ToString();
                    }
                    break;

                case "DecreaseInheld":
                    if(this.StockLevelType.CalcValue == "New")
                    {
                        PARTDGroup.actionNew = PARTDGroup.actionNew - amount;
                        this.New.CalcValue = PARTDGroup.actionNew.ToString();
                    }
                    else if(this.StockLevelType.CalcValue == "Used")
                    {
                        PARTDGroup.actionUsed = PARTDGroup.actionUsed - amount;
                        this.Used.CalcValue = PARTDGroup.actionUsed.ToString();
                    }
                    break;

                case "IncreaseConsigned":
                    PARTDGroup.actionConsigned = PARTDGroup.actionConsigned + amount;
                    this.Consigned.CalcValue = PARTDGroup.actionConsigned.ToString();
                    break;

                case "DecreaseConsigned":
                    PARTDGroup.actionConsigned = PARTDGroup.actionConsigned - amount;
                    this.Consigned.CalcValue = PARTDGroup.actionConsigned.ToString();
                    break;

                case "DecreaseInheld  IncreaseConsigned":
                    if (this.StockLevelType.CalcValue == "New")
                    {
                        PARTDGroup.actionNew = PARTDGroup.actionNew - amount;
                        this.New.CalcValue = PARTDGroup.actionNew.ToString();
                    }
                    else if (this.StockLevelType.CalcValue == "Used")
                    {
                        PARTDGroup.actionUsed = PARTDGroup.actionUsed - amount;
                        this.Used.CalcValue = PARTDGroup.actionUsed.ToString();
                    }
                    PARTDGroup.actionConsigned = PARTDGroup.actionConsigned + amount;
                    this.Consigned.CalcValue = PARTDGroup.actionConsigned.ToString();
                    break;

                case "IncreaseInheld  DecreaseConsigned":
                    if (this.StockLevelType.CalcValue == "New")
                    {
                        PARTDGroup.actionNew = PARTDGroup.actionNew + amount;
                        this.New.CalcValue = PARTDGroup.actionNew.ToString();
                    }
                    else if (this.StockLevelType.CalcValue == "Used")
                    {
                        PARTDGroup.actionUsed = PARTDGroup.actionUsed + amount;
                        this.Used.CalcValue = PARTDGroup.actionUsed.ToString();
                    }
                    PARTDGroup.actionConsigned = PARTDGroup.actionConsigned - amount;
                    this.Consigned.CalcValue = PARTDGroup.actionConsigned.ToString();
                    break;
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

        public MaterialAccountingScheduleReport()
        {
            PARTC = new PARTCGroup(this,"PARTC");
            PARTA = new PARTAGroup(PARTC,"PARTA");
            PARTD = new PARTDGroup(PARTA,"PARTD");
            MAIN = new MAINGroup(PARTD,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TERMID", "", "Devredilecek Dönemi Seçiniz", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("429e41e5-620c-4652-9e24-aa488e0aaaaf");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TERMID"))
                _runtimeParameters.TERMID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TERMID"]);
            Name = "MATERIALACCOUNTINGSCHEDULEREPORT";
            Caption = "Mal Muhasebe Çizelgesi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            PaperSize = 8;
            UserMarginLeft = 25;
            UserMarginTop = 15;
            p_PageWidth = 297;
            p_PageHeight = 420;
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