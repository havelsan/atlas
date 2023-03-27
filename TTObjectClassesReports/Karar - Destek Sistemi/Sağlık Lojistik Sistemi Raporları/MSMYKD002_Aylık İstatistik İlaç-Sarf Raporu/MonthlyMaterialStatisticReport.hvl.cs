
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
    /// Aylık İstatistik İlaç/Sarf Raporu
    /// </summary>
    public partial class MonthlyMaterialStatisticReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public string PARENTCLASSID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public MonthlyMaterialStatisticReport MyParentReport
            {
                get { return (MonthlyMaterialStatisticReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField ReportNamE { get {return Header().ReportNamE;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField132 { get {return Header().NewField132;} }
            public TTReportField StartDate { get {return Header().StartDate;} }
            public TTReportField EndDate { get {return Header().EndDate;} }
            public TTReportField MainMaterialClass { get {return Header().MainMaterialClass;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
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
                public MonthlyMaterialStatisticReport MyParentReport
                {
                    get { return (MonthlyMaterialStatisticReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField ReportNamE;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField131;
                public TTReportField NewField132;
                public TTReportField StartDate;
                public TTReportField EndDate;
                public TTReportField MainMaterialClass; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 40;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.Value = @"";

                    ReportNamE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 257, 20, false);
                    ReportNamE.Name = "ReportNamE";
                    ReportNamE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportNamE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportNamE.TextFont.Name = "Arial";
                    ReportNamE.TextFont.Size = 15;
                    ReportNamE.TextFont.Bold = true;
                    ReportNamE.TextFont.CharSet = 162;
                    ReportNamE.Value = @"AYLIK İSTATİSTİK İLAÇ/SARF RAPORU";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 24, 35, 29, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.NoClip = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Başlangıç Tarihi";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 29, 35, 34, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.NoClip = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Bitiş Tarihi";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 34, 35, 39, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.NoClip = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Malzeme Ana Sınıfı";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 24, 37, 29, false);
                    NewField13.Name = "NewField13";
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @":";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 29, 37, 34, false);
                    NewField131.Name = "NewField131";
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @":";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 34, 37, 39, false);
                    NewField132.Name = "NewField132";
                    NewField132.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField132.TextFont.Name = "Arial";
                    NewField132.TextFont.Bold = true;
                    NewField132.TextFont.CharSet = 162;
                    NewField132.Value = @":";

                    StartDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 24, 62, 29, false);
                    StartDate.Name = "StartDate";
                    StartDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    StartDate.TextFormat = @"dd/MM/yyyy";
                    StartDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    StartDate.TextFont.Name = "Arial";
                    StartDate.TextFont.CharSet = 162;
                    StartDate.Value = @" {@STARTDATE@}";

                    EndDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 29, 62, 34, false);
                    EndDate.Name = "EndDate";
                    EndDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    EndDate.TextFormat = @"dd/MM/yyyy";
                    EndDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EndDate.TextFont.Name = "Arial";
                    EndDate.TextFont.CharSet = 162;
                    EndDate.Value = @" {@ENDDATE@}";

                    MainMaterialClass = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 34, 62, 39, false);
                    MainMaterialClass.Name = "MainMaterialClass";
                    MainMaterialClass.FieldType = ReportFieldTypeEnum.ftVariable;
                    MainMaterialClass.CaseFormat = CaseFormatEnum.fcTitleCase;
                    MainMaterialClass.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MainMaterialClass.NoClip = EvetHayirEnum.ehEvet;
                    MainMaterialClass.ObjectDefName = "StockCardClass";
                    MainMaterialClass.DataMember = "NAME";
                    MainMaterialClass.TextFont.Name = "Arial";
                    MainMaterialClass.TextFont.CharSet = 162;
                    MainMaterialClass.Value = @"{@PARENTCLASSID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = LOGO.Value;
                    ReportNamE.CalcValue = ReportNamE.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField132.CalcValue = NewField132.Value;
                    StartDate.CalcValue = @" " + MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    EndDate.CalcValue = @" " + MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    MainMaterialClass.CalcValue = MyParentReport.RuntimeParameters.PARENTCLASSID.ToString();
                    MainMaterialClass.PostFieldValueCalculation();
                    return new TTReportObject[] { LOGO,ReportNamE,NewField1,NewField11,NewField12,NewField13,NewField131,NewField132,StartDate,EndDate,MainMaterialClass};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public MonthlyMaterialStatisticReport MyParentReport
                {
                    get { return (MonthlyMaterialStatisticReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportShape NewLine1111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
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
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 0, 150, 5, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser.TextFont.Name = "Arial";
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 245, 0, 270, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 270, 0, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate,PageNumber,CurrentUser};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public MonthlyMaterialStatisticReport MyParentReport
            {
                get { return (MonthlyMaterialStatisticReport)ParentReport; }
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
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1122 { get {return Header().NewField1122;} }
            public TTReportField NewField12211 { get {return Header().NewField12211;} }
            public TTReportField NewField111221 { get {return Header().NewField111221;} }
            public TTReportField NewField1122111 { get {return Header().NewField1122111;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField12212 { get {return Header().NewField12212;} }
            public TTReportField NewField111222 { get {return Header().NewField111222;} }
            public TTReportField NewField1122112 { get {return Header().NewField1122112;} }
            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportField NewField121221 { get {return Header().NewField121221;} }
            public TTReportField NewField1222111 { get {return Header().NewField1222111;} }
            public TTReportField NewField12112211 { get {return Header().NewField12112211;} }
            public TTReportField NewField1122121 { get {return Header().NewField1122121;} }
            public TTReportField NewField11212211 { get {return Header().NewField11212211;} }
            public TTReportField NewField11212212 { get {return Header().NewField11212212;} }
            public TTReportField NewField11212213 { get {return Header().NewField11212213;} }
            public TTReportField NewField11212214 { get {return Header().NewField11212214;} }
            public TTReportField NewField11212215 { get {return Header().NewField11212215;} }
            public TTReportField NewField11212216 { get {return Header().NewField11212216;} }
            public TTReportField NewField11212217 { get {return Header().NewField11212217;} }
            public TTReportField NewField11212 { get {return Header().NewField11212;} }
            public TTReportField NewField12213 { get {return Header().NewField12213;} }
            public TTReportField NewField111223 { get {return Header().NewField111223;} }
            public TTReportField NewField1122113 { get {return Header().NewField1122113;} }
            public TTReportField NewField11112211 { get {return Header().NewField11112211;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NewField162 { get {return Header().NewField162;} }
            public TTReportField NewField163 { get {return Header().NewField163;} }
            public TTReportField NewField164 { get {return Header().NewField164;} }
            public TTReportField NewField165 { get {return Header().NewField165;} }
            public TTReportField NewField1561 { get {return Header().NewField1561;} }
            public TTReportField NewField1562 { get {return Header().NewField1562;} }
            public TTReportField NewField1563 { get {return Header().NewField1563;} }
            public TTReportField NewField1564 { get {return Header().NewField1564;} }
            public TTReportField NewField1565 { get {return Header().NewField1565;} }
            public TTReportField NewField1361 { get {return Header().NewField1361;} }
            public TTReportField NewField1362 { get {return Header().NewField1362;} }
            public TTReportField NewField1363 { get {return Header().NewField1363;} }
            public TTReportField NewField1364 { get {return Header().NewField1364;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
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
                public MonthlyMaterialStatisticReport MyParentReport
                {
                    get { return (MonthlyMaterialStatisticReport)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField12;
                public TTReportField NewField2;
                public TTReportField NewField121;
                public TTReportField NewField1121;
                public TTReportField NewField1122;
                public TTReportField NewField12211;
                public TTReportField NewField111221;
                public TTReportField NewField1122111;
                public TTReportField NewField11211;
                public TTReportField NewField12212;
                public TTReportField NewField111222;
                public TTReportField NewField1122112;
                public TTReportField NewField111211;
                public TTReportField NewField121221;
                public TTReportField NewField1222111;
                public TTReportField NewField12112211;
                public TTReportField NewField1122121;
                public TTReportField NewField11212211;
                public TTReportField NewField11212212;
                public TTReportField NewField11212213;
                public TTReportField NewField11212214;
                public TTReportField NewField11212215;
                public TTReportField NewField11212216;
                public TTReportField NewField11212217;
                public TTReportField NewField11212;
                public TTReportField NewField12213;
                public TTReportField NewField111223;
                public TTReportField NewField1122113;
                public TTReportField NewField11112211;
                public TTReportField NewField1;
                public TTReportField NewField3;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField161;
                public TTReportField NewField162;
                public TTReportField NewField163;
                public TTReportField NewField164;
                public TTReportField NewField165;
                public TTReportField NewField1561;
                public TTReportField NewField1562;
                public TTReportField NewField1563;
                public TTReportField NewField1564;
                public TTReportField NewField1565;
                public TTReportField NewField1361;
                public TTReportField NewField1362;
                public TTReportField NewField1363;
                public TTReportField NewField1364;
                public TTReportField NewField4;
                public TTReportField NewField5; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 41;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 29, 35, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 8;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"NATO
STOK
NU.";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 0, 71, 35, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 8;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"MALZEME ADI";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 0, 84, 35, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 7;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"AMBALAJ
ŞEKLİ";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 0, 212, 8, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"İKMAL KADEMELERİ KANALIYLA TEDARİK EDİLEN";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 8, 96, 27, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 6;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"DEPO
MEVCUDU";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 8, 142, 16, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Size = 8;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"GİREN MİKTAR";

                    NewField1122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 16, 107, 27, false);
                    NewField1122.Name = "NewField1122";
                    NewField1122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1122.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1122.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1122.TextFont.Name = "Arial";
                    NewField1122.TextFont.Size = 6;
                    NewField1122.TextFont.CharSet = 162;
                    NewField1122.Value = @"ANA
DEPODAN
ALINAN";

                    NewField12211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 16, 123, 27, false);
                    NewField12211.Name = "NewField12211";
                    NewField12211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12211.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField12211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12211.TextFont.Name = "Arial";
                    NewField12211.TextFont.Size = 6;
                    NewField12211.TextFont.CharSet = 162;
                    NewField12211.Value = @"MAHALLİNDEN
TEDARİK
EDİLEN";

                    NewField111221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 16, 132, 27, false);
                    NewField111221.Name = "NewField111221";
                    NewField111221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111221.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField111221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111221.TextFont.Name = "Arial";
                    NewField111221.TextFont.Size = 6;
                    NewField111221.TextFont.CharSet = 162;
                    NewField111221.Value = @"İADE
ALINAN";

                    NewField1122111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 16, 142, 27, false);
                    NewField1122111.Name = "NewField1122111";
                    NewField1122111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1122111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1122111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1122111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1122111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1122111.TextFont.Name = "Arial";
                    NewField1122111.TextFont.Size = 6;
                    NewField1122111.TextFont.CharSet = 162;
                    NewField1122111.Value = @"TOPLAM
GİREN";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 8, 181, 16, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11211.TextFont.Name = "Arial";
                    NewField11211.TextFont.Size = 8;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"SARF EDİLEN MİKTAR";

                    NewField12212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 16, 152, 27, false);
                    NewField12212.Name = "NewField12212";
                    NewField12212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12212.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField12212.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12212.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12212.TextFont.Name = "Arial";
                    NewField12212.TextFont.Size = 6;
                    NewField12212.TextFont.CharSet = 162;
                    NewField12212.Value = @"SARF
EDİLEN";

                    NewField111222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 16, 171, 27, false);
                    NewField111222.Name = "NewField111222";
                    NewField111222.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111222.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111222.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField111222.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111222.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111222.TextFont.Name = "Arial";
                    NewField111222.TextFont.Size = 6;
                    NewField111222.TextFont.CharSet = 162;
                    NewField111222.Value = @"HARİCİ MAL
SORUMLULARINA
DAĞITILAN";

                    NewField1122112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 16, 181, 27, false);
                    NewField1122112.Name = "NewField1122112";
                    NewField1122112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1122112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1122112.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1122112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1122112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1122112.TextFont.Name = "Arial";
                    NewField1122112.TextFont.Size = 6;
                    NewField1122112.TextFont.CharSet = 162;
                    NewField1122112.Value = @"TOPLAM
SARF";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 8, 212, 16, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111211.TextFont.Name = "Arial";
                    NewField111211.TextFont.Size = 8;
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"BİR SONRAKİ AYA DEVREDEN";

                    NewField121221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 16, 190, 35, false);
                    NewField121221.Name = "NewField121221";
                    NewField121221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121221.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField121221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121221.TextFont.Name = "Arial";
                    NewField121221.TextFont.Size = 6;
                    NewField121221.TextFont.CharSet = 162;
                    NewField121221.Value = @"MİKTAR
(ADET)";

                    NewField1222111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 16, 202, 35, false);
                    NewField1222111.Name = "NewField1222111";
                    NewField1222111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1222111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1222111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1222111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1222111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1222111.TextFont.Name = "Arial";
                    NewField1222111.TextFont.Size = 6;
                    NewField1222111.TextFont.CharSet = 162;
                    NewField1222111.Value = @"MUVAKKAT";

                    NewField12112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 16, 212, 35, false);
                    NewField12112211.Name = "NewField12112211";
                    NewField12112211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12112211.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField12112211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12112211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12112211.TextFont.Name = "Arial";
                    NewField12112211.TextFont.Size = 6;
                    NewField12112211.TextFont.CharSet = 162;
                    NewField12112211.Value = @"AYLIK
SARF
MİKTARI";

                    NewField1122121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 27, 96, 35, false);
                    NewField1122121.Name = "NewField1122121";
                    NewField1122121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1122121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1122121.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1122121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1122121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1122121.TextFont.Name = "Arial";
                    NewField1122121.TextFont.Size = 6;
                    NewField1122121.TextFont.CharSet = 162;
                    NewField1122121.Value = @"MİKTAR
(ADET)";

                    NewField11212211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 27, 107, 35, false);
                    NewField11212211.Name = "NewField11212211";
                    NewField11212211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11212211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11212211.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11212211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11212211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11212211.TextFont.Name = "Arial";
                    NewField11212211.TextFont.Size = 6;
                    NewField11212211.TextFont.CharSet = 162;
                    NewField11212211.Value = @"MİKTAR
(ADET)";

                    NewField11212212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 27, 123, 35, false);
                    NewField11212212.Name = "NewField11212212";
                    NewField11212212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11212212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11212212.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11212212.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11212212.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11212212.TextFont.Name = "Arial";
                    NewField11212212.TextFont.Size = 6;
                    NewField11212212.TextFont.CharSet = 162;
                    NewField11212212.Value = @"MİKTAR
(ADET)";

                    NewField11212213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 27, 132, 35, false);
                    NewField11212213.Name = "NewField11212213";
                    NewField11212213.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11212213.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11212213.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11212213.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11212213.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11212213.TextFont.Name = "Arial";
                    NewField11212213.TextFont.Size = 6;
                    NewField11212213.TextFont.CharSet = 162;
                    NewField11212213.Value = @"MİKTAR
(ADET)";

                    NewField11212214 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 27, 142, 35, false);
                    NewField11212214.Name = "NewField11212214";
                    NewField11212214.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11212214.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11212214.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11212214.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11212214.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11212214.TextFont.Name = "Arial";
                    NewField11212214.TextFont.Size = 6;
                    NewField11212214.TextFont.CharSet = 162;
                    NewField11212214.Value = @"MİKTAR
(ADET)";

                    NewField11212215 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 27, 152, 35, false);
                    NewField11212215.Name = "NewField11212215";
                    NewField11212215.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11212215.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11212215.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11212215.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11212215.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11212215.TextFont.Name = "Arial";
                    NewField11212215.TextFont.Size = 6;
                    NewField11212215.TextFont.CharSet = 162;
                    NewField11212215.Value = @"MİKTAR
(ADET)";

                    NewField11212216 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 27, 171, 35, false);
                    NewField11212216.Name = "NewField11212216";
                    NewField11212216.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11212216.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11212216.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11212216.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11212216.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11212216.TextFont.Name = "Arial";
                    NewField11212216.TextFont.Size = 6;
                    NewField11212216.TextFont.CharSet = 162;
                    NewField11212216.Value = @"MİKTAR
(ADET)";

                    NewField11212217 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 27, 181, 35, false);
                    NewField11212217.Name = "NewField11212217";
                    NewField11212217.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11212217.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11212217.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11212217.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11212217.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11212217.TextFont.Name = "Arial";
                    NewField11212217.TextFont.Size = 6;
                    NewField11212217.TextFont.CharSet = 162;
                    NewField11212217.Value = @"MİKTAR
(ADET)";

                    NewField11212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 0, 257, 8, false);
                    NewField11212.Name = "NewField11212";
                    NewField11212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11212.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11212.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11212.TextFont.Name = "Arial";
                    NewField11212.TextFont.Size = 7;
                    NewField11212.TextFont.Bold = true;
                    NewField11212.TextFont.CharSet = 162;
                    NewField11212.Value = @"ANLAŞMALI SİVİL ECZANELERDEN TEDARİK EDİLEN";

                    NewField12213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 8, 222, 35, false);
                    NewField12213.Name = "NewField12213";
                    NewField12213.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12213.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12213.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField12213.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12213.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12213.TextFont.Name = "Arial";
                    NewField12213.TextFont.Size = 6;
                    NewField12213.TextFont.CharSet = 162;
                    NewField12213.Value = @"YATAN
HASTA
İÇİN
TEDARİK
EDİLEN";

                    NewField111223 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 8, 234, 35, false);
                    NewField111223.Name = "NewField111223";
                    NewField111223.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111223.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111223.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField111223.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111223.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111223.TextFont.Name = "Arial";
                    NewField111223.TextFont.Size = 6;
                    NewField111223.TextFont.CharSet = 162;
                    NewField111223.Value = @"AYAKTAN ERBAŞ VE ER İÇİN TEDARİK EDİLEN";

                    NewField1122113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 8, 247, 35, false);
                    NewField1122113.Name = "NewField1122113";
                    NewField1122113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1122113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1122113.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1122113.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1122113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1122113.TextFont.Name = "Arial";
                    NewField1122113.TextFont.Size = 6;
                    NewField1122113.TextFont.CharSet = 162;
                    NewField1122113.Value = @"AYAKTAN SB. ASTSB.
UZM. ERB.
SİVİL ME.
KENDİLERİ
VE AİLELERİ
İÇİN";

                    NewField11112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 8, 257, 35, false);
                    NewField11112211.Name = "NewField11112211";
                    NewField11112211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11112211.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11112211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11112211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11112211.TextFont.Name = "Arial";
                    NewField11112211.TextFont.Size = 6;
                    NewField11112211.TextFont.CharSet = 162;
                    NewField11112211.Value = @"TOPLAM
MİKTAR";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 9, 35, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 8;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"S.
NU.";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 35, 96, 39, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Size = 5;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"A";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 35, 107, 39, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Size = 5;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"B";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 35, 123, 39, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Size = 5;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"C";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 35, 132, 39, false);
                    NewField16.Name = "NewField16";
                    NewField16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Size = 5;
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"D";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 35, 142, 39, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.TextFont.Name = "Arial";
                    NewField17.TextFont.Size = 5;
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"E (B+C+D)";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 35, 152, 39, false);
                    NewField161.Name = "NewField161";
                    NewField161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField161.TextFont.Name = "Arial";
                    NewField161.TextFont.Size = 5;
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"F";

                    NewField162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 35, 171, 39, false);
                    NewField162.Name = "NewField162";
                    NewField162.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField162.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField162.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField162.TextFont.Name = "Arial";
                    NewField162.TextFont.Size = 5;
                    NewField162.TextFont.Bold = true;
                    NewField162.TextFont.CharSet = 162;
                    NewField162.Value = @"G";

                    NewField163 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 35, 181, 39, false);
                    NewField163.Name = "NewField163";
                    NewField163.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField163.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField163.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField163.TextFont.Name = "Arial";
                    NewField163.TextFont.Size = 5;
                    NewField163.TextFont.Bold = true;
                    NewField163.TextFont.CharSet = 162;
                    NewField163.Value = @"H (F+G)";

                    NewField164 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 35, 190, 39, false);
                    NewField164.Name = "NewField164";
                    NewField164.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField164.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField164.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField164.TextFont.Name = "Arial";
                    NewField164.TextFont.Size = 5;
                    NewField164.TextFont.Bold = true;
                    NewField164.TextFont.CharSet = 162;
                    NewField164.Value = @"I (A+E-H)";

                    NewField165 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 35, 202, 39, false);
                    NewField165.Name = "NewField165";
                    NewField165.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField165.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField165.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField165.TextFont.Size = 7;
                    NewField165.TextFont.Bold = true;
                    NewField165.TextFont.CharSet = 162;
                    NewField165.Value = @"";

                    NewField1561 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 35, 212, 39, false);
                    NewField1561.Name = "NewField1561";
                    NewField1561.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1561.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1561.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1561.TextFont.Size = 7;
                    NewField1561.TextFont.Bold = true;
                    NewField1561.TextFont.CharSet = 162;
                    NewField1561.Value = @"";

                    NewField1562 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 35, 84, 39, false);
                    NewField1562.Name = "NewField1562";
                    NewField1562.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1562.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1562.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1562.TextFont.Size = 7;
                    NewField1562.TextFont.Bold = true;
                    NewField1562.TextFont.CharSet = 162;
                    NewField1562.Value = @"";

                    NewField1563 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 35, 71, 39, false);
                    NewField1563.Name = "NewField1563";
                    NewField1563.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1563.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1563.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1563.TextFont.Size = 7;
                    NewField1563.TextFont.Bold = true;
                    NewField1563.TextFont.CharSet = 162;
                    NewField1563.Value = @"";

                    NewField1564 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 35, 29, 39, false);
                    NewField1564.Name = "NewField1564";
                    NewField1564.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1564.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1564.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1564.TextFont.Size = 7;
                    NewField1564.TextFont.Bold = true;
                    NewField1564.TextFont.CharSet = 162;
                    NewField1564.Value = @"";

                    NewField1565 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 35, 9, 39, false);
                    NewField1565.Name = "NewField1565";
                    NewField1565.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1565.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1565.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1565.TextFont.Size = 7;
                    NewField1565.TextFont.Bold = true;
                    NewField1565.TextFont.CharSet = 162;
                    NewField1565.Value = @"";

                    NewField1361 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 35, 222, 39, false);
                    NewField1361.Name = "NewField1361";
                    NewField1361.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1361.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1361.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1361.TextFont.Name = "Arial";
                    NewField1361.TextFont.Size = 5;
                    NewField1361.TextFont.Bold = true;
                    NewField1361.TextFont.CharSet = 162;
                    NewField1361.Value = @"J";

                    NewField1362 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 35, 234, 39, false);
                    NewField1362.Name = "NewField1362";
                    NewField1362.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1362.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1362.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1362.TextFont.Name = "Arial";
                    NewField1362.TextFont.Size = 5;
                    NewField1362.TextFont.Bold = true;
                    NewField1362.TextFont.CharSet = 162;
                    NewField1362.Value = @"K";

                    NewField1363 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 35, 247, 39, false);
                    NewField1363.Name = "NewField1363";
                    NewField1363.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1363.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1363.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1363.TextFont.Name = "Arial";
                    NewField1363.TextFont.Size = 5;
                    NewField1363.TextFont.Bold = true;
                    NewField1363.TextFont.CharSet = 162;
                    NewField1363.Value = @"L";

                    NewField1364 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 35, 257, 39, false);
                    NewField1364.Name = "NewField1364";
                    NewField1364.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1364.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1364.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1364.TextFont.Name = "Arial";
                    NewField1364.TextFont.Size = 5;
                    NewField1364.TextFont.Bold = true;
                    NewField1364.TextFont.CharSet = 162;
                    NewField1364.Value = @"N (J+K+L)";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 0, 270, 35, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.MultiLine = EvetHayirEnum.ehEvet;
                    NewField4.WordBreak = EvetHayirEnum.ehEvet;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Size = 7;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"DEPODAN İLAÇ VERİLİŞ TARİHİ";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 35, 270, 39, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField5.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1122.CalcValue = NewField1122.Value;
                    NewField12211.CalcValue = NewField12211.Value;
                    NewField111221.CalcValue = NewField111221.Value;
                    NewField1122111.CalcValue = NewField1122111.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField12212.CalcValue = NewField12212.Value;
                    NewField111222.CalcValue = NewField111222.Value;
                    NewField1122112.CalcValue = NewField1122112.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField121221.CalcValue = NewField121221.Value;
                    NewField1222111.CalcValue = NewField1222111.Value;
                    NewField12112211.CalcValue = NewField12112211.Value;
                    NewField1122121.CalcValue = NewField1122121.Value;
                    NewField11212211.CalcValue = NewField11212211.Value;
                    NewField11212212.CalcValue = NewField11212212.Value;
                    NewField11212213.CalcValue = NewField11212213.Value;
                    NewField11212214.CalcValue = NewField11212214.Value;
                    NewField11212215.CalcValue = NewField11212215.Value;
                    NewField11212216.CalcValue = NewField11212216.Value;
                    NewField11212217.CalcValue = NewField11212217.Value;
                    NewField11212.CalcValue = NewField11212.Value;
                    NewField12213.CalcValue = NewField12213.Value;
                    NewField111223.CalcValue = NewField111223.Value;
                    NewField1122113.CalcValue = NewField1122113.Value;
                    NewField11112211.CalcValue = NewField11112211.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField162.CalcValue = NewField162.Value;
                    NewField163.CalcValue = NewField163.Value;
                    NewField164.CalcValue = NewField164.Value;
                    NewField165.CalcValue = NewField165.Value;
                    NewField1561.CalcValue = NewField1561.Value;
                    NewField1562.CalcValue = NewField1562.Value;
                    NewField1563.CalcValue = NewField1563.Value;
                    NewField1564.CalcValue = NewField1564.Value;
                    NewField1565.CalcValue = NewField1565.Value;
                    NewField1361.CalcValue = NewField1361.Value;
                    NewField1362.CalcValue = NewField1362.Value;
                    NewField1363.CalcValue = NewField1363.Value;
                    NewField1364.CalcValue = NewField1364.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    return new TTReportObject[] { NewField11,NewField111,NewField12,NewField2,NewField121,NewField1121,NewField1122,NewField12211,NewField111221,NewField1122111,NewField11211,NewField12212,NewField111222,NewField1122112,NewField111211,NewField121221,NewField1222111,NewField12112211,NewField1122121,NewField11212211,NewField11212212,NewField11212213,NewField11212214,NewField11212215,NewField11212216,NewField11212217,NewField11212,NewField12213,NewField111223,NewField1122113,NewField11112211,NewField1,NewField3,NewField14,NewField15,NewField16,NewField17,NewField161,NewField162,NewField163,NewField164,NewField165,NewField1561,NewField1562,NewField1563,NewField1564,NewField1565,NewField1361,NewField1362,NewField1363,NewField1364,NewField4,NewField5};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public MonthlyMaterialStatisticReport MyParentReport
                {
                    get { return (MonthlyMaterialStatisticReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTCGroup : TTReportGroup
        {
            public MonthlyMaterialStatisticReport MyParentReport
            {
                get { return (MonthlyMaterialStatisticReport)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField MATERIALID { get {return Header().MATERIALID;} }
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
                list[0] = new TTReportNqlData<StockTransaction.GetMaterialIDQuery_Class>("GetMaterialIDQuery", StockTransaction.GetMaterialIDQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.PARENTCLASSID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public MonthlyMaterialStatisticReport MyParentReport
                {
                    get { return (MonthlyMaterialStatisticReport)ParentReport; }
                }
                
                public TTReportField MATERIALID; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 10;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    MATERIALID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 2, 54, 7, false);
                    MATERIALID.Name = "MATERIALID";
                    MATERIALID.Visible = EvetHayirEnum.ehHayir;
                    MATERIALID.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALID.Value = @"{#MATERIALID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockTransaction.GetMaterialIDQuery_Class dataset_GetMaterialIDQuery = ParentGroup.rsGroup.GetCurrentRecord<StockTransaction.GetMaterialIDQuery_Class>(0);
                    MATERIALID.CalcValue = (dataset_GetMaterialIDQuery != null ? Globals.ToStringCore(dataset_GetMaterialIDQuery.Materialid) : "");
                    return new TTReportObject[] { MATERIALID};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public MonthlyMaterialStatisticReport MyParentReport
                {
                    get { return (MonthlyMaterialStatisticReport)ParentReport; }
                }
                 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTCGroup PARTC;

        public partial class MAINGroup : TTReportGroup
        {
            public MonthlyMaterialStatisticReport MyParentReport
            {
                get { return (MonthlyMaterialStatisticReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField OrderNO { get {return Body().OrderNO;} }
            public TTReportField NatoStockNO { get {return Body().NatoStockNO;} }
            public TTReportField MaterialName { get {return Body().MaterialName;} }
            public TTReportField DistributionType { get {return Body().DistributionType;} }
            public TTReportField Inheld { get {return Body().Inheld;} }
            public TTReportField MainStoreAmount { get {return Body().MainStoreAmount;} }
            public TTReportField ChequeAmount { get {return Body().ChequeAmount;} }
            public TTReportField ReturningAmount { get {return Body().ReturningAmount;} }
            public TTReportField TotalIn { get {return Body().TotalIn;} }
            public TTReportField ConsumptionAmount { get {return Body().ConsumptionAmount;} }
            public TTReportField DistributionAmount { get {return Body().DistributionAmount;} }
            public TTReportField TotalConsumption { get {return Body().TotalConsumption;} }
            public TTReportField Amount { get {return Body().Amount;} }
            public TTReportField Consigned { get {return Body().Consigned;} }
            public TTReportField MonthlyConsumption { get {return Body().MonthlyConsumption;} }
            public TTReportField InPatientAmount { get {return Body().InPatientAmount;} }
            public TTReportField OutPatientPrivateAmount { get {return Body().OutPatientPrivateAmount;} }
            public TTReportField OutPatientOthersAmount { get {return Body().OutPatientOthersAmount;} }
            public TTReportField TotalAmount { get {return Body().TotalAmount;} }
            public TTReportField TransactionDate { get {return Body().TransactionDate;} }
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
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[10];
                list[0] = new TTReportNqlData<StockTransaction.GetMainFieldsForStatisticReportQuery_Class>("GetMainFieldsForStatisticReportQuery", StockTransaction.GetMainFieldsForStatisticReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTC.MATERIALID.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                list[1] = new TTReportNqlData<StockTransaction.GetChequeDocumentForStatisticReportQuery_Class>("GetChequeDocumentForStatisticReportQuery", StockTransaction.GetChequeDocumentForStatisticReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTC.MATERIALID.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                list[2] = new TTReportNqlData<StockTransaction.GetReturningDocumentForStatisticReportQuery_Class>("GetReturningDocumentForStatisticReportQuery", StockTransaction.GetReturningDocumentForStatisticReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTC.MATERIALID.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE)));
                list[3] = new TTReportNqlData<StockTransaction.GetConsumptionDocumentForStatisticReportQuery_Class>("GetConsumptionDocumentForStatisticReportQuery", StockTransaction.GetConsumptionDocumentForStatisticReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTC.MATERIALID.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                list[4] = new TTReportNqlData<StockTransaction.GetDistributionDocumentForStatisticReportQuery_Class>("GetDistributionDocumentForStatisticReportQuery", StockTransaction.GetDistributionDocumentForStatisticReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTC.MATERIALID.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                list[5] = new TTReportNqlData<StockTransaction.GetOtherDocumentsForStatisticReportQuery_Class>("GetOtherDocumentsForStatisticReportQuery", StockTransaction.GetOtherDocumentsForStatisticReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTC.MATERIALID.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                list[6] = new TTReportNqlData<InpatientDrugOrder.GetInPatientAmountForStatisticReportQuery_Class>("GetInPatientAmountForStatisticReportQuery", InpatientDrugOrder.GetInPatientAmountForStatisticReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTC.MATERIALID.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                list[7] = new TTReportNqlData<OutPatientDrugOrder.GetOutPatientPrivateNonComForStatisticReportQuery_Class>("GetOutPatientPrivateNonComForStatisticReportQuery", OutPatientDrugOrder.GetOutPatientPrivateNonComForStatisticReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTC.MATERIALID.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                list[8] = new TTReportNqlData<OutPatientDrugOrder.GetOutPatientOtherGroupsForStatisticReportQuery_Class>("GetOutPatientOtherGroupsForStatisticReportQuery", OutPatientDrugOrder.GetOutPatientOtherGroupsForStatisticReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTC.MATERIALID.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                list[9] = new TTReportNqlData<StockTransaction.GetMonthlyConsumptionReportQuery_Class>("GetMonthlyConsumptionReportQuery", StockTransaction.GetMonthlyConsumptionReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTC.MATERIALID.CalcValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public MonthlyMaterialStatisticReport MyParentReport
                {
                    get { return (MonthlyMaterialStatisticReport)ParentReport; }
                }
                
                public TTReportField OrderNO;
                public TTReportField NatoStockNO;
                public TTReportField MaterialName;
                public TTReportField DistributionType;
                public TTReportField Inheld;
                public TTReportField MainStoreAmount;
                public TTReportField ChequeAmount;
                public TTReportField ReturningAmount;
                public TTReportField TotalIn;
                public TTReportField ConsumptionAmount;
                public TTReportField DistributionAmount;
                public TTReportField TotalConsumption;
                public TTReportField Amount;
                public TTReportField Consigned;
                public TTReportField MonthlyConsumption;
                public TTReportField InPatientAmount;
                public TTReportField OutPatientPrivateAmount;
                public TTReportField OutPatientOthersAmount;
                public TTReportField TotalAmount;
                public TTReportField TransactionDate; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 14;
                    RepeatCount = 0;
                    
                    OrderNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 9, 4, false);
                    OrderNO.Name = "OrderNO";
                    OrderNO.DrawStyle = DrawStyleConstants.vbSolid;
                    OrderNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    OrderNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OrderNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OrderNO.TextFont.Name = "Arial";
                    OrderNO.TextFont.Size = 7;
                    OrderNO.TextFont.CharSet = 162;
                    OrderNO.Value = @"{@counter@}";

                    NatoStockNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 29, 4, false);
                    NatoStockNO.Name = "NatoStockNO";
                    NatoStockNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NatoStockNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NatoStockNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NatoStockNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NatoStockNO.TextFont.Name = "Arial";
                    NatoStockNO.TextFont.Size = 7;
                    NatoStockNO.TextFont.CharSet = 162;
                    NatoStockNO.Value = @"{#NATOSTOCKNO#}";

                    MaterialName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 0, 71, 4, false);
                    MaterialName.Name = "MaterialName";
                    MaterialName.DrawStyle = DrawStyleConstants.vbSolid;
                    MaterialName.FieldType = ReportFieldTypeEnum.ftVariable;
                    MaterialName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    MaterialName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MaterialName.WordBreak = EvetHayirEnum.ehEvet;
                    MaterialName.TextFont.Name = "Arial";
                    MaterialName.TextFont.Size = 7;
                    MaterialName.TextFont.CharSet = 162;
                    MaterialName.Value = @"{#NAME#}";

                    DistributionType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 0, 84, 4, false);
                    DistributionType.Name = "DistributionType";
                    DistributionType.DrawStyle = DrawStyleConstants.vbSolid;
                    DistributionType.FieldType = ReportFieldTypeEnum.ftVariable;
                    DistributionType.CaseFormat = CaseFormatEnum.fcTitleCase;
                    DistributionType.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DistributionType.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DistributionType.TextFont.Name = "Arial";
                    DistributionType.TextFont.Size = 7;
                    DistributionType.TextFont.CharSet = 162;
                    DistributionType.Value = @"{#DISTRIBUTIONTYPE#}";

                    Inheld = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 0, 96, 4, false);
                    Inheld.Name = "Inheld";
                    Inheld.DrawStyle = DrawStyleConstants.vbSolid;
                    Inheld.FieldType = ReportFieldTypeEnum.ftVariable;
                    Inheld.TextFormat = @"#,###";
                    Inheld.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Inheld.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Inheld.TextFont.Name = "Arial";
                    Inheld.TextFont.Size = 7;
                    Inheld.TextFont.CharSet = 162;
                    Inheld.Value = @"{#INHELD#}";

                    MainStoreAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 0, 107, 4, false);
                    MainStoreAmount.Name = "MainStoreAmount";
                    MainStoreAmount.DrawStyle = DrawStyleConstants.vbSolid;
                    MainStoreAmount.FieldType = ReportFieldTypeEnum.ftVariable;
                    MainStoreAmount.TextFormat = @"#,###";
                    MainStoreAmount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MainStoreAmount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MainStoreAmount.TextFont.Name = "Arial";
                    MainStoreAmount.TextFont.Size = 7;
                    MainStoreAmount.TextFont.CharSet = 162;
                    MainStoreAmount.Value = @"";

                    ChequeAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 0, 123, 4, false);
                    ChequeAmount.Name = "ChequeAmount";
                    ChequeAmount.DrawStyle = DrawStyleConstants.vbSolid;
                    ChequeAmount.FieldType = ReportFieldTypeEnum.ftVariable;
                    ChequeAmount.TextFormat = @"#,###";
                    ChequeAmount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ChequeAmount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ChequeAmount.TextFont.Name = "Arial";
                    ChequeAmount.TextFont.Size = 7;
                    ChequeAmount.TextFont.CharSet = 162;
                    ChequeAmount.Value = @"{#CHEQUEAMOUNT!GetChequeDocumentForStatisticReportQuery#}";

                    ReturningAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 0, 132, 4, false);
                    ReturningAmount.Name = "ReturningAmount";
                    ReturningAmount.DrawStyle = DrawStyleConstants.vbSolid;
                    ReturningAmount.FieldType = ReportFieldTypeEnum.ftVariable;
                    ReturningAmount.TextFormat = @"#,###";
                    ReturningAmount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ReturningAmount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReturningAmount.TextFont.Name = "Arial";
                    ReturningAmount.TextFont.Size = 7;
                    ReturningAmount.TextFont.CharSet = 162;
                    ReturningAmount.Value = @"{#RETURNINGAMOUNT!GetReturningDocumentForStatisticReportQuery#}";

                    TotalIn = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 0, 142, 4, false);
                    TotalIn.Name = "TotalIn";
                    TotalIn.DrawStyle = DrawStyleConstants.vbSolid;
                    TotalIn.FieldType = ReportFieldTypeEnum.ftExpression;
                    TotalIn.TextFormat = @"#,###";
                    TotalIn.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TotalIn.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TotalIn.TextFont.Name = "Arial";
                    TotalIn.TextFont.Size = 7;
                    TotalIn.TextFont.CharSet = 162;
                    TotalIn.Value = @"(Convert.ToDouble(""0""+MainStoreAmount.CalcValue)+Convert.ToDouble(""0""+ChequeAmount.CalcValue)+Convert.ToDouble(""0""+ReturningAmount.CalcValue)).ToString()";

                    ConsumptionAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 0, 152, 4, false);
                    ConsumptionAmount.Name = "ConsumptionAmount";
                    ConsumptionAmount.DrawStyle = DrawStyleConstants.vbSolid;
                    ConsumptionAmount.FieldType = ReportFieldTypeEnum.ftVariable;
                    ConsumptionAmount.TextFormat = @"#,###";
                    ConsumptionAmount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ConsumptionAmount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ConsumptionAmount.TextFont.Name = "Arial";
                    ConsumptionAmount.TextFont.Size = 7;
                    ConsumptionAmount.TextFont.CharSet = 162;
                    ConsumptionAmount.Value = @"{#CONSUMPTIONAMOUNT!GetConsumptionDocumentForStatisticReportQuery#}";

                    DistributionAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 0, 171, 4, false);
                    DistributionAmount.Name = "DistributionAmount";
                    DistributionAmount.DrawStyle = DrawStyleConstants.vbSolid;
                    DistributionAmount.FieldType = ReportFieldTypeEnum.ftVariable;
                    DistributionAmount.TextFormat = @"#,###";
                    DistributionAmount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DistributionAmount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DistributionAmount.TextFont.Name = "Arial";
                    DistributionAmount.TextFont.Size = 7;
                    DistributionAmount.TextFont.CharSet = 162;
                    DistributionAmount.Value = @"{#DISTRIBUTIONAMOUNT!GetDistributionDocumentForStatisticReportQuery#}";

                    TotalConsumption = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 0, 181, 4, false);
                    TotalConsumption.Name = "TotalConsumption";
                    TotalConsumption.DrawStyle = DrawStyleConstants.vbSolid;
                    TotalConsumption.FieldType = ReportFieldTypeEnum.ftExpression;
                    TotalConsumption.TextFormat = @"#,###";
                    TotalConsumption.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TotalConsumption.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TotalConsumption.TextFont.Name = "Arial";
                    TotalConsumption.TextFont.Size = 7;
                    TotalConsumption.TextFont.CharSet = 162;
                    TotalConsumption.Value = @"(Convert.ToDouble(""0""+ConsumptionAmount.CalcValue)+Convert.ToDouble(""0""+DistributionAmount.CalcValue)).ToString()";

                    Amount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 0, 190, 4, false);
                    Amount.Name = "Amount";
                    Amount.DrawStyle = DrawStyleConstants.vbSolid;
                    Amount.FieldType = ReportFieldTypeEnum.ftExpression;
                    Amount.TextFormat = @"#,###";
                    Amount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Amount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Amount.TextFont.Name = "Arial";
                    Amount.TextFont.Size = 7;
                    Amount.TextFont.CharSet = 162;
                    Amount.Value = @"(Convert.ToDouble(""0""+Inheld.CalcValue)+Convert.ToDouble(""0""+TotalIn.CalcValue)-Convert.ToDouble(""0""+TotalConsumption.CalcValue)).ToString()";

                    Consigned = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 0, 202, 4, false);
                    Consigned.Name = "Consigned";
                    Consigned.DrawStyle = DrawStyleConstants.vbSolid;
                    Consigned.FieldType = ReportFieldTypeEnum.ftVariable;
                    Consigned.TextFormat = @"#,###";
                    Consigned.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Consigned.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Consigned.TextFont.Name = "Arial";
                    Consigned.TextFont.Size = 7;
                    Consigned.TextFont.CharSet = 162;
                    Consigned.Value = @"{#CONSIGNED#}";

                    MonthlyConsumption = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 0, 212, 4, false);
                    MonthlyConsumption.Name = "MonthlyConsumption";
                    MonthlyConsumption.DrawStyle = DrawStyleConstants.vbSolid;
                    MonthlyConsumption.FieldType = ReportFieldTypeEnum.ftVariable;
                    MonthlyConsumption.TextFormat = @"#,###";
                    MonthlyConsumption.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MonthlyConsumption.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MonthlyConsumption.TextFont.Name = "Arial";
                    MonthlyConsumption.TextFont.Size = 7;
                    MonthlyConsumption.TextFont.CharSet = 162;
                    MonthlyConsumption.Value = @"{#CONSUMPTIONAMOUNT!GetMonthlyConsumptionReportQuery#}";

                    InPatientAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 0, 222, 4, false);
                    InPatientAmount.Name = "InPatientAmount";
                    InPatientAmount.DrawStyle = DrawStyleConstants.vbSolid;
                    InPatientAmount.FieldType = ReportFieldTypeEnum.ftVariable;
                    InPatientAmount.TextFormat = @"#,###";
                    InPatientAmount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    InPatientAmount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    InPatientAmount.TextFont.Name = "Arial";
                    InPatientAmount.TextFont.Size = 7;
                    InPatientAmount.TextFont.CharSet = 162;
                    InPatientAmount.Value = @"{#INPATIENTAMOUNT!GetInPatientAmountForStatisticReportQuery#}";

                    OutPatientPrivateAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 0, 234, 4, false);
                    OutPatientPrivateAmount.Name = "OutPatientPrivateAmount";
                    OutPatientPrivateAmount.DrawStyle = DrawStyleConstants.vbSolid;
                    OutPatientPrivateAmount.FieldType = ReportFieldTypeEnum.ftVariable;
                    OutPatientPrivateAmount.TextFormat = @"#,###";
                    OutPatientPrivateAmount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OutPatientPrivateAmount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OutPatientPrivateAmount.TextFont.Name = "Arial";
                    OutPatientPrivateAmount.TextFont.Size = 7;
                    OutPatientPrivateAmount.TextFont.CharSet = 162;
                    OutPatientPrivateAmount.Value = @"{#OUTPATIENTAMOUNT!GetOutPatientPrivateNonComForStatisticReportQuery#}";

                    OutPatientOthersAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 0, 247, 4, false);
                    OutPatientOthersAmount.Name = "OutPatientOthersAmount";
                    OutPatientOthersAmount.DrawStyle = DrawStyleConstants.vbSolid;
                    OutPatientOthersAmount.FieldType = ReportFieldTypeEnum.ftVariable;
                    OutPatientOthersAmount.TextFormat = @"#,###";
                    OutPatientOthersAmount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OutPatientOthersAmount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OutPatientOthersAmount.TextFont.Name = "Arial";
                    OutPatientOthersAmount.TextFont.Size = 7;
                    OutPatientOthersAmount.TextFont.CharSet = 162;
                    OutPatientOthersAmount.Value = @"{#OUTPATIENTAMOUNT!GetOutPatientOtherGroupsForStatisticReportQuery#}";

                    TotalAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 0, 257, 4, false);
                    TotalAmount.Name = "TotalAmount";
                    TotalAmount.DrawStyle = DrawStyleConstants.vbSolid;
                    TotalAmount.FieldType = ReportFieldTypeEnum.ftExpression;
                    TotalAmount.TextFormat = @"#,###";
                    TotalAmount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TotalAmount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TotalAmount.TextFont.Name = "Arial";
                    TotalAmount.TextFont.Size = 7;
                    TotalAmount.TextFont.CharSet = 162;
                    TotalAmount.Value = @"(Convert.ToDouble(""0""+InPatientAmount.CalcValue)+Convert.ToDouble(""0""+OutPatientPrivateAmount.CalcValue)+Convert.ToDouble(""0""+OutPatientOthersAmount.CalcValue)).ToString()";

                    TransactionDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 0, 270, 4, false);
                    TransactionDate.Name = "TransactionDate";
                    TransactionDate.DrawStyle = DrawStyleConstants.vbSolid;
                    TransactionDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    TransactionDate.TextFormat = @"dd/MM/yyyy";
                    TransactionDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TransactionDate.TextFont.Name = "Arial";
                    TransactionDate.TextFont.Size = 7;
                    TransactionDate.TextFont.CharSet = 162;
                    TransactionDate.Value = @"{#TRANSACTIONDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockTransaction.GetMainFieldsForStatisticReportQuery_Class dataset_GetMainFieldsForStatisticReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockTransaction.GetMainFieldsForStatisticReportQuery_Class>(0);
                    StockTransaction.GetChequeDocumentForStatisticReportQuery_Class dataset_GetChequeDocumentForStatisticReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockTransaction.GetChequeDocumentForStatisticReportQuery_Class>(1);
                    StockTransaction.GetReturningDocumentForStatisticReportQuery_Class dataset_GetReturningDocumentForStatisticReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockTransaction.GetReturningDocumentForStatisticReportQuery_Class>(2);
                    StockTransaction.GetConsumptionDocumentForStatisticReportQuery_Class dataset_GetConsumptionDocumentForStatisticReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockTransaction.GetConsumptionDocumentForStatisticReportQuery_Class>(3);
                    StockTransaction.GetDistributionDocumentForStatisticReportQuery_Class dataset_GetDistributionDocumentForStatisticReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockTransaction.GetDistributionDocumentForStatisticReportQuery_Class>(4);
                    StockTransaction.GetOtherDocumentsForStatisticReportQuery_Class dataset_GetOtherDocumentsForStatisticReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockTransaction.GetOtherDocumentsForStatisticReportQuery_Class>(5);
                    InpatientDrugOrder.GetInPatientAmountForStatisticReportQuery_Class dataset_GetInPatientAmountForStatisticReportQuery = ParentGroup.rsGroup.GetCurrentRecord<InpatientDrugOrder.GetInPatientAmountForStatisticReportQuery_Class>(6);
                    OutPatientDrugOrder.GetOutPatientPrivateNonComForStatisticReportQuery_Class dataset_GetOutPatientPrivateNonComForStatisticReportQuery = ParentGroup.rsGroup.GetCurrentRecord<OutPatientDrugOrder.GetOutPatientPrivateNonComForStatisticReportQuery_Class>(7);
                    OutPatientDrugOrder.GetOutPatientOtherGroupsForStatisticReportQuery_Class dataset_GetOutPatientOtherGroupsForStatisticReportQuery = ParentGroup.rsGroup.GetCurrentRecord<OutPatientDrugOrder.GetOutPatientOtherGroupsForStatisticReportQuery_Class>(8);
                    StockTransaction.GetMonthlyConsumptionReportQuery_Class dataset_GetMonthlyConsumptionReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockTransaction.GetMonthlyConsumptionReportQuery_Class>(9);
                    OrderNO.CalcValue = ParentGroup.Counter.ToString();
                    NatoStockNO.CalcValue = (dataset_GetMainFieldsForStatisticReportQuery != null ? Globals.ToStringCore(dataset_GetMainFieldsForStatisticReportQuery.NATOStockNO) : "");
                    MaterialName.CalcValue = (dataset_GetMainFieldsForStatisticReportQuery != null ? Globals.ToStringCore(dataset_GetMainFieldsForStatisticReportQuery.Name) : "");
                    DistributionType.CalcValue = (dataset_GetMainFieldsForStatisticReportQuery != null ? Globals.ToStringCore(dataset_GetMainFieldsForStatisticReportQuery.DistributionType) : "");
                    Inheld.CalcValue = (dataset_GetMainFieldsForStatisticReportQuery != null ? Globals.ToStringCore(dataset_GetMainFieldsForStatisticReportQuery.Inheld) : "");
                    MainStoreAmount.CalcValue = @"";
                    ChequeAmount.CalcValue = (dataset_GetChequeDocumentForStatisticReportQuery != null ? Globals.ToStringCore(dataset_GetChequeDocumentForStatisticReportQuery.Chequeamount) : "");
                    ReturningAmount.CalcValue = (dataset_GetReturningDocumentForStatisticReportQuery != null ? Globals.ToStringCore(dataset_GetReturningDocumentForStatisticReportQuery.Returningamount) : "");
                    ConsumptionAmount.CalcValue = (dataset_GetConsumptionDocumentForStatisticReportQuery != null ? Globals.ToStringCore(dataset_GetConsumptionDocumentForStatisticReportQuery.Consumptionamount) : "");
                    DistributionAmount.CalcValue = (dataset_GetDistributionDocumentForStatisticReportQuery != null ? Globals.ToStringCore(dataset_GetDistributionDocumentForStatisticReportQuery.Distributionamount) : "");
                    Consigned.CalcValue = (dataset_GetMainFieldsForStatisticReportQuery != null ? Globals.ToStringCore(dataset_GetMainFieldsForStatisticReportQuery.Consigned) : "");
                    MonthlyConsumption.CalcValue = (dataset_GetMonthlyConsumptionReportQuery != null ? Globals.ToStringCore(dataset_GetMonthlyConsumptionReportQuery.Consumptionamount) : "");
                    InPatientAmount.CalcValue = (dataset_GetInPatientAmountForStatisticReportQuery != null ? Globals.ToStringCore(dataset_GetInPatientAmountForStatisticReportQuery.Inpatientamount) : "");
                    OutPatientPrivateAmount.CalcValue = (dataset_GetOutPatientPrivateNonComForStatisticReportQuery != null ? Globals.ToStringCore(dataset_GetOutPatientPrivateNonComForStatisticReportQuery.Outpatientamount) : "");
                    OutPatientOthersAmount.CalcValue = (dataset_GetOutPatientOtherGroupsForStatisticReportQuery != null ? Globals.ToStringCore(dataset_GetOutPatientOtherGroupsForStatisticReportQuery.Outpatientamount) : "");
                    TransactionDate.CalcValue = (dataset_GetMainFieldsForStatisticReportQuery != null ? Globals.ToStringCore(dataset_GetMainFieldsForStatisticReportQuery.Transactiondate) : "");
                    TotalIn.CalcValue = (Convert.ToDouble("0"+MainStoreAmount.CalcValue)+Convert.ToDouble("0"+ChequeAmount.CalcValue)+Convert.ToDouble("0"+ReturningAmount.CalcValue)).ToString();
                    TotalConsumption.CalcValue = (Convert.ToDouble("0"+ConsumptionAmount.CalcValue)+Convert.ToDouble("0"+DistributionAmount.CalcValue)).ToString();
                    Amount.CalcValue = (Convert.ToDouble("0"+Inheld.CalcValue)+Convert.ToDouble("0"+TotalIn.CalcValue)-Convert.ToDouble("0"+TotalConsumption.CalcValue)).ToString();
                    TotalAmount.CalcValue = (Convert.ToDouble("0"+InPatientAmount.CalcValue)+Convert.ToDouble("0"+OutPatientPrivateAmount.CalcValue)+Convert.ToDouble("0"+OutPatientOthersAmount.CalcValue)).ToString();
                    return new TTReportObject[] { OrderNO,NatoStockNO,MaterialName,DistributionType,Inheld,MainStoreAmount,ChequeAmount,ReturningAmount,ConsumptionAmount,DistributionAmount,Consigned,MonthlyConsumption,InPatientAmount,OutPatientPrivateAmount,OutPatientOthersAmount,TransactionDate,TotalIn,TotalConsumption,Amount,TotalAmount};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //            double totalIn = Convert.ToDouble(MainStoreAmount.CalcValue) + Convert.ToDouble(ChequeAmount.CalcValue) + Convert.ToDouble(ReturningAmount.CalcValue);
//            TotalIn.CalcValue = totalIn.ToString();
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

        public MonthlyMaterialStatisticReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            PARTC = new PARTCGroup(PARTB,"PARTC");
            MAIN = new MAINGroup(PARTC,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihini Seçiniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihini Seçiniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("PARENTCLASSID", "", "Malzeme Ana Sınıfını Seçiniz", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("868b54df-fc49-488a-8810-4dee66438aa3");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("PARENTCLASSID"))
                _runtimeParameters.PARENTCLASSID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["PARENTCLASSID"]);
            Name = "MONTHLYMATERIALSTATISTICREPORT";
            Caption = "Aylık İstatistik İlaç/Sarf Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 20;
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