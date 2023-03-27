
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
    /// İşlem Gören Tıbbi Cihaz ve XXXXXX Donanımları Raporu
    /// </summary>
    public partial class ProcessingMedicalDeviceAndHospitalHardwaresReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public ProcessingMedicalDeviceAndHospitalHardwaresReport MyParentReport
            {
                get { return (ProcessingMedicalDeviceAndHospitalHardwaresReport)ParentReport; }
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
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField11311 { get {return Header().NewField11311;} }
            public TTReportField NewField11312 { get {return Header().NewField11312;} }
            public TTReportField NewField11314 { get {return Header().NewField11314;} }
            public TTReportField NewField11315 { get {return Header().NewField11315;} }
            public TTReportField NewField151311 { get {return Header().NewField151311;} }
            public TTReportField NewField151312 { get {return Header().NewField151312;} }
            public TTReportField NewField151313 { get {return Header().NewField151313;} }
            public TTReportField NewField1313151 { get {return Header().NewField1313151;} }
            public TTReportField NewField1313152 { get {return Header().NewField1313152;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField HOSPITAL { get {return Header().HOSPITAL;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField1112 { get {return Header().NewField1112;} }
            public TTReportField NewField11513131 { get {return Header().NewField11513131;} }
            public TTReportField NewField113131511 { get {return Header().NewField113131511;} }
            public TTReportField NewField113131512 { get {return Header().NewField113131512;} }
            public TTReportField NewField11513132 { get {return Header().NewField11513132;} }
            public TTReportField NewField11513133 { get {return Header().NewField11513133;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField NewField123131511 { get {return Header().NewField123131511;} }
            public TTReportField NewField1115131321 { get {return Header().NewField1115131321;} }
            public TTReportField NewField1115131322 { get {return Header().NewField1115131322;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportField NewField12111 { get {return Header().NewField12111;} }
            public TTReportShape NewLine121 { get {return Header().NewLine121;} }
            public TTReportField NewField123131512 { get {return Header().NewField123131512;} }
            public TTReportField NewField133131511 { get {return Header().NewField133131511;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportShape NewLine3 { get {return Header().NewLine3;} }
            public TTReportShape NewLine4 { get {return Header().NewLine4;} }
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
                public ProcessingMedicalDeviceAndHospitalHardwaresReport MyParentReport
                {
                    get { return (ProcessingMedicalDeviceAndHospitalHardwaresReport)ParentReport; }
                }
                
                public TTReportField REPORTNAME;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField1131;
                public TTReportField NewField11311;
                public TTReportField NewField11312;
                public TTReportField NewField11314;
                public TTReportField NewField11315;
                public TTReportField NewField151311;
                public TTReportField NewField151312;
                public TTReportField NewField151313;
                public TTReportField NewField1313151;
                public TTReportField NewField1313152;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField HOSPITAL;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField NewField1112;
                public TTReportField NewField11513131;
                public TTReportField NewField113131511;
                public TTReportField NewField113131512;
                public TTReportField NewField11513132;
                public TTReportField NewField11513133;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportField NewField123131511;
                public TTReportField NewField1115131321;
                public TTReportField NewField1115131322;
                public TTReportShape NewLine12;
                public TTReportField NewField12111;
                public TTReportShape NewLine121;
                public TTReportField NewField123131512;
                public TTReportField NewField133131511;
                public TTReportShape NewLine2;
                public TTReportShape NewLine3;
                public TTReportShape NewLine4; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 56;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 10, 389, 15, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"STARTDATE.FormattedValue + "" - "" + ENDDATE.FormattedValue + "" ARIZALI CİHAZ İŞLEM RAPORU""";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 27, 9, 52, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 8;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"

SIRA NU.";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 27, 25, 52, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 8;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"

SİPARİŞ NU.";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 27, 176, 52, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 8;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"


ADI";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 27, 115, 52, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Size = 8;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"


CİHAZIN ADI";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 27, 231, 52, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11311.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11311.TextFont.Name = "Arial";
                    NewField11311.TextFont.Size = 8;
                    NewField11311.TextFont.Bold = true;
                    NewField11311.TextFont.CharSet = 162;
                    NewField11311.Value = @"

TESELLÜM
TARİHİ";

                    NewField11312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 27, 214, 52, false);
                    NewField11312.Name = "NewField11312";
                    NewField11312.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11312.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11312.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11312.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11312.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11312.TextFont.Name = "Arial";
                    NewField11312.TextFont.Size = 8;
                    NewField11312.TextFont.Bold = true;
                    NewField11312.TextFont.CharSet = 162;
                    NewField11312.Value = @"


YERİ";

                    NewField11314 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 27, 71, 52, false);
                    NewField11314.Name = "NewField11314";
                    NewField11314.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11314.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11314.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11314.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11314.TextFont.Name = "Arial";
                    NewField11314.TextFont.Size = 8;
                    NewField11314.TextFont.Bold = true;
                    NewField11314.TextFont.CharSet = 162;
                    NewField11314.Value = @"


ATÖLYESİ";

                    NewField11315 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 27, 248, 52, false);
                    NewField11315.Name = "NewField11315";
                    NewField11315.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11315.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11315.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11315.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11315.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11315.TextFont.Name = "Arial";
                    NewField11315.TextFont.Size = 8;
                    NewField11315.TextFont.Bold = true;
                    NewField11315.TextFont.CharSet = 162;
                    NewField11315.Value = @"
İLK MUAYENE TARİHİ";

                    NewField151311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 282, 20, 308, 52, false);
                    NewField151311.Name = "NewField151311";
                    NewField151311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151311.MultiLine = EvetHayirEnum.ehEvet;
                    NewField151311.TextFont.Name = "Arial";
                    NewField151311.TextFont.Size = 8;
                    NewField151311.TextFont.Bold = true;
                    NewField151311.TextFont.CharSet = 162;
                    NewField151311.Value = @"


SİPARİŞİ
KAPATAN
PERSONEL";

                    NewField151312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 27, 265, 52, false);
                    NewField151312.Name = "NewField151312";
                    NewField151312.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151312.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151312.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151312.MultiLine = EvetHayirEnum.ehEvet;
                    NewField151312.TextFont.Name = "Arial";
                    NewField151312.TextFont.Size = 8;
                    NewField151312.TextFont.Bold = true;
                    NewField151312.TextFont.CharSet = 162;
                    NewField151312.Value = @"
SİPARİŞİN
AÇILDIĞI
TARİH";

                    NewField151313 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 20, 328, 52, false);
                    NewField151313.Name = "NewField151313";
                    NewField151313.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151313.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151313.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151313.MultiLine = EvetHayirEnum.ehEvet;
                    NewField151313.TextFont.Name = "Arial";
                    NewField151313.TextFont.Size = 8;
                    NewField151313.TextFont.Bold = true;
                    NewField151313.TextFont.CharSet = 162;
                    NewField151313.Value = @"

ONARIM
İÇİN
HARCANAN
ZAMAN";

                    NewField1313151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 332, 27, 336, 52, false);
                    NewField1313151.Name = "NewField1313151";
                    NewField1313151.FontAngle = 900;
                    NewField1313151.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1313151.TextFont.Name = "Arial";
                    NewField1313151.TextFont.Size = 8;
                    NewField1313151.TextFont.Bold = true;
                    NewField1313151.TextFont.CharSet = 162;
                    NewField1313151.Value = @"FAAL";

                    NewField1313152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 265, 27, 282, 52, false);
                    NewField1313152.Name = "NewField1313152";
                    NewField1313152.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1313152.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1313152.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1313152.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1313152.TextFont.Name = "Arial";
                    NewField1313152.TextFont.Size = 8;
                    NewField1313152.TextFont.Bold = true;
                    NewField1313152.TextFont.CharSet = 162;
                    NewField1313152.Value = @"
SİPARİŞİN
KAPANDIĞI
TARİH";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 430, 11, 455, 16, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 430, 19, 455, 24, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.Value = @"{@ENDDATE@}";

                    HOSPITAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 389, 10, false);
                    HOSPITAL.Name = "HOSPITAL";
                    HOSPITAL.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITAL.TextFont.Name = "Arial";
                    HOSPITAL.TextFont.Bold = true;
                    HOSPITAL.TextFont.CharSet = 162;
                    HOSPITAL.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 20, 115, 27, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 8;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"MALZEMENİN";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 20, 214, 27, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Size = 8;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"MALZEMENİN GELDİĞİ BİRLİĞİN / XXXXXXNİN";

                    NewField1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 20, 282, 27, false);
                    NewField1112.Name = "NewField1112";
                    NewField1112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1112.TextFont.Name = "Arial";
                    NewField1112.TextFont.Size = 8;
                    NewField1112.TextFont.Bold = true;
                    NewField1112.TextFont.CharSet = 162;
                    NewField1112.Value = @"MALZEMENİN";

                    NewField11513131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 341, 27, 345, 52, false);
                    NewField11513131.Name = "NewField11513131";
                    NewField11513131.FontAngle = 900;
                    NewField11513131.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11513131.TextFont.Name = "Arial";
                    NewField11513131.TextFont.Size = 8;
                    NewField11513131.TextFont.Bold = true;
                    NewField11513131.TextFont.CharSet = 162;
                    NewField11513131.Value = @"İLK";

                    NewField113131511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 345, 27, 349, 52, false);
                    NewField113131511.Name = "NewField113131511";
                    NewField113131511.FontAngle = 900;
                    NewField113131511.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField113131511.TextFont.Name = "Arial";
                    NewField113131511.TextFont.Size = 8;
                    NewField113131511.TextFont.Bold = true;
                    NewField113131511.TextFont.CharSet = 162;
                    NewField113131511.Value = @"MUAYENEDEN";

                    NewField113131512 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 349, 27, 353, 52, false);
                    NewField113131512.Name = "NewField113131512";
                    NewField113131512.FontAngle = 900;
                    NewField113131512.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField113131512.TextFont.Name = "Arial";
                    NewField113131512.TextFont.Size = 8;
                    NewField113131512.TextFont.Bold = true;
                    NewField113131512.TextFont.CharSet = 162;
                    NewField113131512.Value = @"HEK";

                    NewField11513132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 355, 27, 359, 52, false);
                    NewField11513132.Name = "NewField11513132";
                    NewField11513132.FontAngle = 900;
                    NewField11513132.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11513132.TextFont.Name = "Arial";
                    NewField11513132.TextFont.Size = 8;
                    NewField11513132.TextFont.Bold = true;
                    NewField11513132.TextFont.CharSet = 162;
                    NewField11513132.Value = @"ONARIMDAN";

                    NewField11513133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 359, 27, 363, 52, false);
                    NewField11513133.Name = "NewField11513133";
                    NewField11513133.FontAngle = 900;
                    NewField11513133.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11513133.TextFont.Name = "Arial";
                    NewField11513133.TextFont.Size = 8;
                    NewField11513133.TextFont.Bold = true;
                    NewField11513133.TextFont.CharSet = 162;
                    NewField11513133.Value = @"HEK";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 341, 27, 341, 52, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 353, 27, 353, 52, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField123131511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 365, 20, 369, 52, false);
                    NewField123131511.Name = "NewField123131511";
                    NewField123131511.FontAngle = 900;
                    NewField123131511.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField123131511.TextFont.Name = "Arial";
                    NewField123131511.TextFont.Size = 8;
                    NewField123131511.TextFont.Bold = true;
                    NewField123131511.TextFont.CharSet = 162;
                    NewField123131511.Value = @"ONARIMI";

                    NewField1115131321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 369, 20, 373, 52, false);
                    NewField1115131321.Name = "NewField1115131321";
                    NewField1115131321.FontAngle = 900;
                    NewField1115131321.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1115131321.TextFont.Name = "Arial";
                    NewField1115131321.TextFont.Size = 8;
                    NewField1115131321.TextFont.Bold = true;
                    NewField1115131321.TextFont.CharSet = 162;
                    NewField1115131321.Value = @"DEVAM";

                    NewField1115131322 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 373, 20, 377, 52, false);
                    NewField1115131322.Name = "NewField1115131322";
                    NewField1115131322.FontAngle = 900;
                    NewField1115131322.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1115131322.TextFont.Name = "Arial";
                    NewField1115131322.TextFont.Size = 8;
                    NewField1115131322.TextFont.Bold = true;
                    NewField1115131322.TextFont.CharSet = 162;
                    NewField1115131322.Value = @"EDEN";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 365, 27, 365, 52, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField12111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 328, 20, 365, 27, false);
                    NewField12111.Name = "NewField12111";
                    NewField12111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12111.TextFont.Name = "Arial";
                    NewField12111.TextFont.Size = 8;
                    NewField12111.TextFont.Bold = true;
                    NewField12111.TextFont.CharSet = 162;
                    NewField12111.Value = @"BAKIM ONARIM SONUCU";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 377, 20, 377, 52, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField123131512 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 379, 20, 383, 52, false);
                    NewField123131512.Name = "NewField123131512";
                    NewField123131512.FontAngle = 900;
                    NewField123131512.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField123131512.TextFont.Name = "Arial";
                    NewField123131512.TextFont.Size = 8;
                    NewField123131512.TextFont.Bold = true;
                    NewField123131512.TextFont.CharSet = 162;
                    NewField123131512.Value = @"CİHAZIN";

                    NewField133131511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 383, 20, 387, 52, false);
                    NewField133131511.Name = "NewField133131511";
                    NewField133131511.FontAngle = 900;
                    NewField133131511.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField133131511.TextFont.Name = "Arial";
                    NewField133131511.TextFont.Size = 8;
                    NewField133131511.TextFont.Bold = true;
                    NewField133131511.TextFont.CharSet = 162;
                    NewField133131511.Value = @"DURUMU";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 389, 20, 389, 52, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 364, 20, 389, 20, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 328, 52, 389, 52, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    NewField11312.CalcValue = NewField11312.Value;
                    NewField11314.CalcValue = NewField11314.Value;
                    NewField11315.CalcValue = NewField11315.Value;
                    NewField151311.CalcValue = NewField151311.Value;
                    NewField151312.CalcValue = NewField151312.Value;
                    NewField151313.CalcValue = NewField151313.Value;
                    NewField1313151.CalcValue = NewField1313151.Value;
                    NewField1313152.CalcValue = NewField1313152.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1112.CalcValue = NewField1112.Value;
                    NewField11513131.CalcValue = NewField11513131.Value;
                    NewField113131511.CalcValue = NewField113131511.Value;
                    NewField113131512.CalcValue = NewField113131512.Value;
                    NewField11513132.CalcValue = NewField11513132.Value;
                    NewField11513133.CalcValue = NewField11513133.Value;
                    NewField123131511.CalcValue = NewField123131511.Value;
                    NewField1115131321.CalcValue = NewField1115131321.Value;
                    NewField1115131322.CalcValue = NewField1115131322.Value;
                    NewField12111.CalcValue = NewField12111.Value;
                    NewField123131512.CalcValue = NewField123131512.Value;
                    NewField133131511.CalcValue = NewField133131511.Value;
                    REPORTNAME.CalcValue = STARTDATE.FormattedValue + " - " + ENDDATE.FormattedValue + " ARIZALI CİHAZ İŞLEM RAPORU";
                    HOSPITAL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { NewField1,NewField11,NewField12,NewField1131,NewField11311,NewField11312,NewField11314,NewField11315,NewField151311,NewField151312,NewField151313,NewField1313151,NewField1313152,STARTDATE,ENDDATE,NewField111,NewField1111,NewField1112,NewField11513131,NewField113131511,NewField113131512,NewField11513132,NewField11513133,NewField123131511,NewField1115131321,NewField1115131322,NewField12111,NewField123131512,NewField133131511,REPORTNAME,HOSPITAL};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ProcessingMedicalDeviceAndHospitalHardwaresReport MyParentReport
                {
                    get { return (ProcessingMedicalDeviceAndHospitalHardwaresReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportShape NewLine1111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 20;
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

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 0, 209, 5, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 364, 0, 389, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 389, 0, false);
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
            public ProcessingMedicalDeviceAndHospitalHardwaresReport MyParentReport
            {
                get { return (ProcessingMedicalDeviceAndHospitalHardwaresReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField1111 { get {return Footer().NewField1111;} }
            public TTReportField TOTALACTIVE { get {return Footer().TOTALACTIVE;} }
            public TTReportField TOTALHEKFROMFIRSTCHECK { get {return Footer().TOTALHEKFROMFIRSTCHECK;} }
            public TTReportField TOTALHEKFROMREPAIR { get {return Footer().TOTALHEKFROMREPAIR;} }
            public TTReportField TOTALCONTINUETOREPAIR { get {return Footer().TOTALCONTINUETOREPAIR;} }
            public TTReportField TOTALREPAIRWORKLOAD { get {return Footer().TOTALREPAIRWORKLOAD;} }
            public TTReportField DEVICESTATUS1 { get {return Footer().DEVICESTATUS1;} }
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
                public ProcessingMedicalDeviceAndHospitalHardwaresReport MyParentReport
                {
                    get { return (ProcessingMedicalDeviceAndHospitalHardwaresReport)ParentReport; }
                }
                 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public ProcessingMedicalDeviceAndHospitalHardwaresReport MyParentReport
                {
                    get { return (ProcessingMedicalDeviceAndHospitalHardwaresReport)ParentReport; }
                }
                
                public TTReportField NewField1111;
                public TTReportField TOTALACTIVE;
                public TTReportField TOTALHEKFROMFIRSTCHECK;
                public TTReportField TOTALHEKFROMREPAIR;
                public TTReportField TOTALCONTINUETOREPAIR;
                public TTReportField TOTALREPAIRWORKLOAD;
                public TTReportField DEVICESTATUS1; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    RepeatCount = 0;
                    
                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 308, 7, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Size = 8;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"TOPLAM ";

                    TOTALACTIVE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 328, 0, 341, 7, false);
                    TOTALACTIVE.Name = "TOTALACTIVE";
                    TOTALACTIVE.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALACTIVE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALACTIVE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALACTIVE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALACTIVE.TextFont.Name = "Arial";
                    TOTALACTIVE.TextFont.Size = 8;
                    TOTALACTIVE.TextFont.CharSet = 162;
                    TOTALACTIVE.Value = @"{@sumof(ACTIVE)@}";

                    TOTALHEKFROMFIRSTCHECK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 341, 0, 353, 7, false);
                    TOTALHEKFROMFIRSTCHECK.Name = "TOTALHEKFROMFIRSTCHECK";
                    TOTALHEKFROMFIRSTCHECK.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALHEKFROMFIRSTCHECK.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALHEKFROMFIRSTCHECK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALHEKFROMFIRSTCHECK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALHEKFROMFIRSTCHECK.TextFont.Name = "Arial";
                    TOTALHEKFROMFIRSTCHECK.TextFont.Size = 8;
                    TOTALHEKFROMFIRSTCHECK.TextFont.CharSet = 162;
                    TOTALHEKFROMFIRSTCHECK.Value = @"{@sumof(HEKFROMFIRSTCHECK)@}";

                    TOTALHEKFROMREPAIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 353, 0, 365, 7, false);
                    TOTALHEKFROMREPAIR.Name = "TOTALHEKFROMREPAIR";
                    TOTALHEKFROMREPAIR.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALHEKFROMREPAIR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALHEKFROMREPAIR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALHEKFROMREPAIR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALHEKFROMREPAIR.TextFont.Name = "Arial";
                    TOTALHEKFROMREPAIR.TextFont.Size = 8;
                    TOTALHEKFROMREPAIR.TextFont.CharSet = 162;
                    TOTALHEKFROMREPAIR.Value = @"{@sumof(HEKFROMREPAIR)@}";

                    TOTALCONTINUETOREPAIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 365, 0, 377, 7, false);
                    TOTALCONTINUETOREPAIR.Name = "TOTALCONTINUETOREPAIR";
                    TOTALCONTINUETOREPAIR.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALCONTINUETOREPAIR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALCONTINUETOREPAIR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALCONTINUETOREPAIR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALCONTINUETOREPAIR.TextFont.Name = "Arial";
                    TOTALCONTINUETOREPAIR.TextFont.Size = 8;
                    TOTALCONTINUETOREPAIR.TextFont.CharSet = 162;
                    TOTALCONTINUETOREPAIR.Value = @"{@sumof(CONTINUETOREPAIR)@}";

                    TOTALREPAIRWORKLOAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 0, 328, 7, false);
                    TOTALREPAIRWORKLOAD.Name = "TOTALREPAIRWORKLOAD";
                    TOTALREPAIRWORKLOAD.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALREPAIRWORKLOAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALREPAIRWORKLOAD.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALREPAIRWORKLOAD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALREPAIRWORKLOAD.TextFont.Name = "Arial";
                    TOTALREPAIRWORKLOAD.TextFont.Size = 8;
                    TOTALREPAIRWORKLOAD.TextFont.CharSet = 162;
                    TOTALREPAIRWORKLOAD.Value = @"{@sumof(REPAIRWORKLOAD)@}";

                    DEVICESTATUS1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 377, 0, 389, 7, false);
                    DEVICESTATUS1.Name = "DEVICESTATUS1";
                    DEVICESTATUS1.DrawStyle = DrawStyleConstants.vbSolid;
                    DEVICESTATUS1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEVICESTATUS1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DEVICESTATUS1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DEVICESTATUS1.TextFont.Name = "Arial";
                    DEVICESTATUS1.TextFont.Size = 8;
                    DEVICESTATUS1.TextFont.CharSet = 162;
                    DEVICESTATUS1.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111.CalcValue = NewField1111.Value;
                    TOTALACTIVE.CalcValue = ParentGroup.FieldSums["ACTIVE"].Value.ToString();;
                    TOTALHEKFROMFIRSTCHECK.CalcValue = ParentGroup.FieldSums["HEKFROMFIRSTCHECK"].Value.ToString();;
                    TOTALHEKFROMREPAIR.CalcValue = ParentGroup.FieldSums["HEKFROMREPAIR"].Value.ToString();;
                    TOTALCONTINUETOREPAIR.CalcValue = ParentGroup.FieldSums["CONTINUETOREPAIR"].Value.ToString();;
                    TOTALREPAIRWORKLOAD.CalcValue = ParentGroup.FieldSums["REPAIRWORKLOAD"].Value.ToString();;
                    DEVICESTATUS1.CalcValue = @"";
                    return new TTReportObject[] { NewField1111,TOTALACTIVE,TOTALHEKFROMFIRSTCHECK,TOTALHEKFROMREPAIR,TOTALCONTINUETOREPAIR,TOTALREPAIRWORKLOAD,DEVICESTATUS1};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    TOTALACTIVE.CalcValue = PARTBGroup.totalActive.ToString();
            TOTALHEKFROMFIRSTCHECK.CalcValue = PARTBGroup.totalHekFromFirstCheck.ToString();
            TOTALHEKFROMREPAIR.CalcValue = PARTBGroup.totalHekFromRepair.ToString();
            TOTALCONTINUETOREPAIR.CalcValue = PARTBGroup.totalContinueToRepair.ToString();
            PARTBGroup.totalActive = 0;
            PARTBGroup.totalHekFromFirstCheck = 0;
            PARTBGroup.totalHekFromRepair = 0;
            PARTBGroup.totalContinueToRepair = 0;
#endregion PARTB FOOTER_Script
                }
            }

#region PARTB_Methods
            public static double totalActive = 0, totalHekFromFirstCheck = 0, totalHekFromRepair = 0, totalContinueToRepair = 0;
#endregion PARTB_Methods
        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public ProcessingMedicalDeviceAndHospitalHardwaresReport MyParentReport
            {
                get { return (ProcessingMedicalDeviceAndHospitalHardwaresReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField MILITARYUNIT { get {return Body().MILITARYUNIT;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField ARRIVALDATE { get {return Body().ARRIVALDATE;} }
            public TTReportField FIRSTCHECKDATE { get {return Body().FIRSTCHECKDATE;} }
            public TTReportField ORDERCLOSE { get {return Body().ORDERCLOSE;} }
            public TTReportField ACTIVE { get {return Body().ACTIVE;} }
            public TTReportField HEKFROMFIRSTCHECK { get {return Body().HEKFROMFIRSTCHECK;} }
            public TTReportField HEKFROMREPAIR { get {return Body().HEKFROMREPAIR;} }
            public TTReportField CONTINUETOREPAIR { get {return Body().CONTINUETOREPAIR;} }
            public TTReportField STARTDATE { get {return Body().STARTDATE;} }
            public TTReportField ENDDATE { get {return Body().ENDDATE;} }
            public TTReportField REPAIRWORKLOAD { get {return Body().REPAIRWORKLOAD;} }
            public TTReportField DEVICESTATUS { get {return Body().DEVICESTATUS;} }
            public TTReportField WORKSHOP { get {return Body().WORKSHOP;} }
            public TTReportField ADDRESS { get {return Body().ADDRESS;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField ORDERSTATUS { get {return Body().ORDERSTATUS;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
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
                list[0] = new TTReportNqlData<MaintenanceOrder.GetProcessingDeviceAndHardwareReportQuery_Class>("GetProcessingDeviceAndHardwareReportQuery", MaintenanceOrder.GetProcessingDeviceAndHardwareReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public ProcessingMedicalDeviceAndHospitalHardwaresReport MyParentReport
                {
                    get { return (ProcessingMedicalDeviceAndHospitalHardwaresReport)ParentReport; }
                }
                
                public TTReportField COUNT;
                public TTReportField ORDERNO;
                public TTReportField MILITARYUNIT;
                public TTReportField MATERIALNAME;
                public TTReportField ARRIVALDATE;
                public TTReportField FIRSTCHECKDATE;
                public TTReportField ORDERCLOSE;
                public TTReportField ACTIVE;
                public TTReportField HEKFROMFIRSTCHECK;
                public TTReportField HEKFROMREPAIR;
                public TTReportField CONTINUETOREPAIR;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField REPAIRWORKLOAD;
                public TTReportField DEVICESTATUS;
                public TTReportField WORKSHOP;
                public TTReportField ADDRESS;
                public TTReportField OBJECTID;
                public TTReportField ORDERSTATUS;
                public TTReportField AMOUNT; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 11;
                    RepeatCount = 0;
                    
                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 9, 7, false);
                    COUNT.Name = "COUNT";
                    COUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.MultiLine = EvetHayirEnum.ehEvet;
                    COUNT.WordBreak = EvetHayirEnum.ehEvet;
                    COUNT.TextFont.Name = "Arial";
                    COUNT.TextFont.Size = 7;
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{@counter@}";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 25, 7, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.MultiLine = EvetHayirEnum.ehEvet;
                    ORDERNO.WordBreak = EvetHayirEnum.ehEvet;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.Size = 7;
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{#ORDERNO#}";

                    MILITARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 0, 176, 7, false);
                    MILITARYUNIT.Name = "MILITARYUNIT";
                    MILITARYUNIT.DrawStyle = DrawStyleConstants.vbSolid;
                    MILITARYUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MILITARYUNIT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MILITARYUNIT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MILITARYUNIT.MultiLine = EvetHayirEnum.ehEvet;
                    MILITARYUNIT.WordBreak = EvetHayirEnum.ehEvet;
                    MILITARYUNIT.TextFont.Name = "Arial";
                    MILITARYUNIT.TextFont.Size = 7;
                    MILITARYUNIT.TextFont.CharSet = 162;
                    MILITARYUNIT.Value = @"{#SENDERACCOUNTANCY#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 0, 115, 7, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALNAME.TextFont.Name = "Arial";
                    MATERIALNAME.TextFont.Size = 7;
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"{#MATERIALNAME#}";

                    ARRIVALDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 0, 231, 7, false);
                    ARRIVALDATE.Name = "ARRIVALDATE";
                    ARRIVALDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    ARRIVALDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ARRIVALDATE.TextFormat = @"dd/MM/yyyy";
                    ARRIVALDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ARRIVALDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ARRIVALDATE.MultiLine = EvetHayirEnum.ehEvet;
                    ARRIVALDATE.WordBreak = EvetHayirEnum.ehEvet;
                    ARRIVALDATE.TextFont.Name = "Arial";
                    ARRIVALDATE.TextFont.Size = 7;
                    ARRIVALDATE.TextFont.CharSet = 162;
                    ARRIVALDATE.Value = @"{#ARRIVALDATE#}";

                    FIRSTCHECKDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 0, 248, 7, false);
                    FIRSTCHECKDATE.Name = "FIRSTCHECKDATE";
                    FIRSTCHECKDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRSTCHECKDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRSTCHECKDATE.TextFormat = @"dd/MM/yyyy";
                    FIRSTCHECKDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRSTCHECKDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRSTCHECKDATE.MultiLine = EvetHayirEnum.ehEvet;
                    FIRSTCHECKDATE.WordBreak = EvetHayirEnum.ehEvet;
                    FIRSTCHECKDATE.TextFont.Name = "Arial";
                    FIRSTCHECKDATE.TextFont.Size = 7;
                    FIRSTCHECKDATE.TextFont.CharSet = 162;
                    FIRSTCHECKDATE.Value = @"{#CHECKDATE#}";

                    ORDERCLOSE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 282, 0, 308, 7, false);
                    ORDERCLOSE.Name = "ORDERCLOSE";
                    ORDERCLOSE.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERCLOSE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERCLOSE.CaseFormat = CaseFormatEnum.fcNameSurname;
                    ORDERCLOSE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERCLOSE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERCLOSE.MultiLine = EvetHayirEnum.ehEvet;
                    ORDERCLOSE.WordBreak = EvetHayirEnum.ehEvet;
                    ORDERCLOSE.TextFont.Name = "Arial";
                    ORDERCLOSE.TextFont.Size = 7;
                    ORDERCLOSE.TextFont.CharSet = 162;
                    ORDERCLOSE.Value = @"";

                    ACTIVE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 328, 0, 341, 7, false);
                    ACTIVE.Name = "ACTIVE";
                    ACTIVE.DrawStyle = DrawStyleConstants.vbSolid;
                    ACTIVE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIVE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACTIVE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACTIVE.MultiLine = EvetHayirEnum.ehEvet;
                    ACTIVE.WordBreak = EvetHayirEnum.ehEvet;
                    ACTIVE.TextFont.Name = "Arial";
                    ACTIVE.TextFont.Size = 7;
                    ACTIVE.TextFont.CharSet = 162;
                    ACTIVE.Value = @"";

                    HEKFROMFIRSTCHECK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 341, 0, 353, 7, false);
                    HEKFROMFIRSTCHECK.Name = "HEKFROMFIRSTCHECK";
                    HEKFROMFIRSTCHECK.DrawStyle = DrawStyleConstants.vbSolid;
                    HEKFROMFIRSTCHECK.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEKFROMFIRSTCHECK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEKFROMFIRSTCHECK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEKFROMFIRSTCHECK.MultiLine = EvetHayirEnum.ehEvet;
                    HEKFROMFIRSTCHECK.WordBreak = EvetHayirEnum.ehEvet;
                    HEKFROMFIRSTCHECK.TextFont.Name = "Arial";
                    HEKFROMFIRSTCHECK.TextFont.Size = 7;
                    HEKFROMFIRSTCHECK.TextFont.CharSet = 162;
                    HEKFROMFIRSTCHECK.Value = @"";

                    HEKFROMREPAIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 353, 0, 365, 7, false);
                    HEKFROMREPAIR.Name = "HEKFROMREPAIR";
                    HEKFROMREPAIR.DrawStyle = DrawStyleConstants.vbSolid;
                    HEKFROMREPAIR.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEKFROMREPAIR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEKFROMREPAIR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEKFROMREPAIR.MultiLine = EvetHayirEnum.ehEvet;
                    HEKFROMREPAIR.WordBreak = EvetHayirEnum.ehEvet;
                    HEKFROMREPAIR.TextFont.Name = "Arial";
                    HEKFROMREPAIR.TextFont.Size = 7;
                    HEKFROMREPAIR.TextFont.CharSet = 162;
                    HEKFROMREPAIR.Value = @"";

                    CONTINUETOREPAIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 365, 0, 377, 7, false);
                    CONTINUETOREPAIR.Name = "CONTINUETOREPAIR";
                    CONTINUETOREPAIR.DrawStyle = DrawStyleConstants.vbSolid;
                    CONTINUETOREPAIR.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONTINUETOREPAIR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CONTINUETOREPAIR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONTINUETOREPAIR.MultiLine = EvetHayirEnum.ehEvet;
                    CONTINUETOREPAIR.WordBreak = EvetHayirEnum.ehEvet;
                    CONTINUETOREPAIR.TextFont.Name = "Arial";
                    CONTINUETOREPAIR.TextFont.Size = 7;
                    CONTINUETOREPAIR.TextFont.CharSet = 162;
                    CONTINUETOREPAIR.Value = @"";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 0, 265, 7, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    STARTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTDATE.MultiLine = EvetHayirEnum.ehEvet;
                    STARTDATE.WordBreak = EvetHayirEnum.ehEvet;
                    STARTDATE.TextFont.Name = "Arial";
                    STARTDATE.TextFont.Size = 7;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{#STARTDATE#}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 265, 0, 282, 7, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftExpression;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ENDDATE.MultiLine = EvetHayirEnum.ehEvet;
                    ENDDATE.WordBreak = EvetHayirEnum.ehEvet;
                    ENDDATE.TextFont.Name = "Arial";
                    ENDDATE.TextFont.Size = 7;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{#ENDDATE#} != """" ? {#ENDDATE#} : ""- - -""";

                    REPAIRWORKLOAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 0, 328, 7, false);
                    REPAIRWORKLOAD.Name = "REPAIRWORKLOAD";
                    REPAIRWORKLOAD.DrawStyle = DrawStyleConstants.vbSolid;
                    REPAIRWORKLOAD.FieldType = ReportFieldTypeEnum.ftExpression;
                    REPAIRWORKLOAD.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPAIRWORKLOAD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPAIRWORKLOAD.MultiLine = EvetHayirEnum.ehEvet;
                    REPAIRWORKLOAD.WordBreak = EvetHayirEnum.ehEvet;
                    REPAIRWORKLOAD.TextFont.Name = "Arial";
                    REPAIRWORKLOAD.TextFont.Size = 7;
                    REPAIRWORKLOAD.TextFont.CharSet = 162;
                    REPAIRWORKLOAD.Value = @"{#REPAIRWORKLOAD#} != """" ? {#REPAIRWORKLOAD#} : ""0""";

                    DEVICESTATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 377, 0, 389, 7, false);
                    DEVICESTATUS.Name = "DEVICESTATUS";
                    DEVICESTATUS.DrawStyle = DrawStyleConstants.vbSolid;
                    DEVICESTATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEVICESTATUS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DEVICESTATUS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DEVICESTATUS.MultiLine = EvetHayirEnum.ehEvet;
                    DEVICESTATUS.WordBreak = EvetHayirEnum.ehEvet;
                    DEVICESTATUS.TextFont.Name = "Arial";
                    DEVICESTATUS.TextFont.Size = 7;
                    DEVICESTATUS.TextFont.CharSet = 162;
                    DEVICESTATUS.Value = @"";

                    WORKSHOP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 0, 71, 7, false);
                    WORKSHOP.Name = "WORKSHOP";
                    WORKSHOP.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKSHOP.FieldType = ReportFieldTypeEnum.ftVariable;
                    WORKSHOP.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WORKSHOP.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKSHOP.MultiLine = EvetHayirEnum.ehEvet;
                    WORKSHOP.WordBreak = EvetHayirEnum.ehEvet;
                    WORKSHOP.TextFont.Name = "Arial";
                    WORKSHOP.TextFont.Size = 7;
                    WORKSHOP.TextFont.CharSet = 162;
                    WORKSHOP.Value = @"{#WORKSHOP#}";

                    ADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 0, 214, 7, false);
                    ADDRESS.Name = "ADDRESS";
                    ADDRESS.DrawStyle = DrawStyleConstants.vbSolid;
                    ADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADDRESS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ADDRESS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ADDRESS.MultiLine = EvetHayirEnum.ehEvet;
                    ADDRESS.WordBreak = EvetHayirEnum.ehEvet;
                    ADDRESS.TextFont.Name = "Arial";
                    ADDRESS.TextFont.Size = 7;
                    ADDRESS.TextFont.CharSet = 162;
                    ADDRESS.Value = @"{#SENDERADDRESS#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 432, 0, 457, 5, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    ORDERSTATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 463, 0, 488, 5, false);
                    ORDERSTATUS.Name = "ORDERSTATUS";
                    ORDERSTATUS.Visible = EvetHayirEnum.ehHayir;
                    ORDERSTATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERSTATUS.Value = @"{#ORDERSTATUS#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 492, 0, 517, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.Visible = EvetHayirEnum.ehHayir;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.Value = @"{#AMOUNT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetProcessingDeviceAndHardwareReportQuery_Class dataset_GetProcessingDeviceAndHardwareReportQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetProcessingDeviceAndHardwareReportQuery_Class>(0);
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    ORDERNO.CalcValue = (dataset_GetProcessingDeviceAndHardwareReportQuery != null ? Globals.ToStringCore(dataset_GetProcessingDeviceAndHardwareReportQuery.OrderNO) : "");
                    MILITARYUNIT.CalcValue = (dataset_GetProcessingDeviceAndHardwareReportQuery != null ? Globals.ToStringCore(dataset_GetProcessingDeviceAndHardwareReportQuery.Senderaccountancy) : "");
                    MATERIALNAME.CalcValue = (dataset_GetProcessingDeviceAndHardwareReportQuery != null ? Globals.ToStringCore(dataset_GetProcessingDeviceAndHardwareReportQuery.Materialname) : "");
                    ARRIVALDATE.CalcValue = (dataset_GetProcessingDeviceAndHardwareReportQuery != null ? Globals.ToStringCore(dataset_GetProcessingDeviceAndHardwareReportQuery.ArrivalDate) : "");
                    FIRSTCHECKDATE.CalcValue = (dataset_GetProcessingDeviceAndHardwareReportQuery != null ? Globals.ToStringCore(dataset_GetProcessingDeviceAndHardwareReportQuery.CheckDate) : "");
                    ORDERCLOSE.CalcValue = @"";
                    ACTIVE.CalcValue = @"";
                    HEKFROMFIRSTCHECK.CalcValue = @"";
                    HEKFROMREPAIR.CalcValue = @"";
                    CONTINUETOREPAIR.CalcValue = @"";
                    STARTDATE.CalcValue = (dataset_GetProcessingDeviceAndHardwareReportQuery != null ? Globals.ToStringCore(dataset_GetProcessingDeviceAndHardwareReportQuery.StartDate) : "");
                    DEVICESTATUS.CalcValue = @"";
                    WORKSHOP.CalcValue = (dataset_GetProcessingDeviceAndHardwareReportQuery != null ? Globals.ToStringCore(dataset_GetProcessingDeviceAndHardwareReportQuery.Workshop) : "");
                    ADDRESS.CalcValue = (dataset_GetProcessingDeviceAndHardwareReportQuery != null ? Globals.ToStringCore(dataset_GetProcessingDeviceAndHardwareReportQuery.Senderaddress) : "");
                    OBJECTID.CalcValue = (dataset_GetProcessingDeviceAndHardwareReportQuery != null ? Globals.ToStringCore(dataset_GetProcessingDeviceAndHardwareReportQuery.ObjectID) : "");
                    ORDERSTATUS.CalcValue = (dataset_GetProcessingDeviceAndHardwareReportQuery != null ? Globals.ToStringCore(dataset_GetProcessingDeviceAndHardwareReportQuery.OrderStatus) : "");
                    AMOUNT.CalcValue = (dataset_GetProcessingDeviceAndHardwareReportQuery != null ? Globals.ToStringCore(dataset_GetProcessingDeviceAndHardwareReportQuery.Amount) : "");
                    ENDDATE.CalcValue = (dataset_GetProcessingDeviceAndHardwareReportQuery != null ? Globals.ToStringCore(dataset_GetProcessingDeviceAndHardwareReportQuery.EndDate) : "") != "" ? (dataset_GetProcessingDeviceAndHardwareReportQuery != null ? Globals.ToStringCore(dataset_GetProcessingDeviceAndHardwareReportQuery.EndDate) : "") : "- - -";
                    REPAIRWORKLOAD.CalcValue = (dataset_GetProcessingDeviceAndHardwareReportQuery != null ? Globals.ToStringCore(dataset_GetProcessingDeviceAndHardwareReportQuery.RepairWorkLoad) : "") != "" ? (dataset_GetProcessingDeviceAndHardwareReportQuery != null ? Globals.ToStringCore(dataset_GetProcessingDeviceAndHardwareReportQuery.RepairWorkLoad) : "") : "0";
                    return new TTReportObject[] { COUNT,ORDERNO,MILITARYUNIT,MATERIALNAME,ARRIVALDATE,FIRSTCHECKDATE,ORDERCLOSE,ACTIVE,HEKFROMFIRSTCHECK,HEKFROMREPAIR,CONTINUETOREPAIR,STARTDATE,DEVICESTATUS,WORKSHOP,ADDRESS,OBJECTID,ORDERSTATUS,AMOUNT,ENDDATE,REPAIRWORKLOAD};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            string objectID = OBJECTID.CalcValue;
            MaintenanceOrder mo = (MaintenanceOrder)ctx.GetObject(new Guid(objectID), typeof(MaintenanceOrder));
            if(mo.GetState("OrderClose", true) != null)
                ORDERCLOSE.CalcValue = mo.GetState("OrderClose", true).User.Name.ToString();
            else
                ORDERCLOSE.CalcValue = "- - -";
            
            if(AMOUNT.CalcValue == "")
                AMOUNT.CalcValue = "0";

            if (mo.GetState("Completed", true) == null)
            {
                CONTINUETOREPAIR.CalcValue = AMOUNT.CalcValue;
                ACTIVE.CalcValue = "0";
                HEKFROMFIRSTCHECK.CalcValue = "0";
                HEKFROMREPAIR.CalcValue = "0";
                PARTBGroup.totalContinueToRepair = PARTBGroup.totalContinueToRepair + Convert.ToDouble(AMOUNT.CalcValue);
            }
            else
            {
                CONTINUETOREPAIR.CalcValue = "0";
                if(mo.GetState("Cancelled", true) == null)
                {
                    if(ORDERSTATUS.CalcValue == "Active")
                    {
                        ACTIVE.CalcValue = AMOUNT.CalcValue;
                        PARTBGroup.totalActive = PARTBGroup.totalActive + Convert.ToDouble(AMOUNT.CalcValue);
                    }
                    else
                        ACTIVE.CalcValue = "0";
                    
                    if(ORDERSTATUS.CalcValue == "HEKFromFromExamination")
                    {
                        HEKFROMFIRSTCHECK.CalcValue = AMOUNT.CalcValue;
                        PARTBGroup.totalHekFromFirstCheck = PARTBGroup.totalHekFromFirstCheck + Convert.ToDouble(AMOUNT.CalcValue);
                    }
                    else
                        HEKFROMFIRSTCHECK.CalcValue = "0";
                    
                    if(ORDERSTATUS.CalcValue == "HEKFromFromRepair")
                    {
                        HEKFROMREPAIR.CalcValue = AMOUNT.CalcValue;
                    PARTBGroup.totalHekFromRepair = PARTBGroup.totalHekFromRepair + Convert.ToDouble(AMOUNT.CalcValue);
                    }
                    else
                        HEKFROMREPAIR.CalcValue = "0";
                }
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

        public ProcessingMedicalDeviceAndHospitalHardwaresReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihini Seçiniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihini Giriniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "PROCESSINGMEDICALDEVICEANDHOSPITALHARDWARESREPORT";
            Caption = "İşlem Gören Tıbbi Cihaz ve XXXXXX Donanımları Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            PaperSize = 8;
            UserMarginLeft = 15;
            UserMarginTop = 10;
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