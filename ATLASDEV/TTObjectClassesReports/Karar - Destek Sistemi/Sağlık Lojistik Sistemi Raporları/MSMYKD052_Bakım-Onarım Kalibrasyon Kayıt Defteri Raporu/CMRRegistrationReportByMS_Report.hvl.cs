
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
    /// Bakım-Onarım-Kalibrasyon Kayıt Defteri Raporu
    /// </summary>
    public partial class CMRRegistrationReportByMS : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? ORDERST = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public string YEAR = (string)TTObjectDefManager.Instance.DataTypes["String_4"].ConvertValue("2014");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public CMRRegistrationReportByMS MyParentReport
            {
                get { return (CMRRegistrationReportByMS)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField HEADER { get {return Header().HEADER;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField NewField1142 { get {return Header().NewField1142;} }
            public TTReportField NewField111421 { get {return Header().NewField111421;} }
            public TTReportField NewField111422 { get {return Header().NewField111422;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NewField1161 { get {return Header().NewField1161;} }
            public TTReportField NewField1162 { get {return Header().NewField1162;} }
            public TTReportField NewField11611 { get {return Header().NewField11611;} }
            public TTReportField NewField111611 { get {return Header().NewField111611;} }
            public TTReportField HEADER2 { get {return Header().HEADER2;} }
            public TTReportField HEADER3 { get {return Header().HEADER3;} }
            public TTReportField NewField1116111 { get {return Header().NewField1116111;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField1143 { get {return Header().NewField1143;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField1224111 { get {return Header().NewField1224111;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField YEAR2 { get {return Header().YEAR2;} }
            public TTReportField YEAR { get {return Header().YEAR;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
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
                public CMRRegistrationReportByMS MyParentReport
                {
                    get { return (CMRRegistrationReportByMS)ParentReport; }
                }
                
                public TTReportField HEADER;
                public TTReportField NewField141;
                public TTReportField NewField1141;
                public TTReportField NewField1142;
                public TTReportField NewField111421;
                public TTReportField NewField111422;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField161;
                public TTReportField NewField1161;
                public TTReportField NewField1162;
                public TTReportField NewField11611;
                public TTReportField NewField111611;
                public TTReportField HEADER2;
                public TTReportField HEADER3;
                public TTReportField NewField1116111;
                public TTReportField NewField1;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField1143;
                public TTReportField NewField11;
                public TTReportField NewField1224111;
                public TTReportField NewField111;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField YEAR2;
                public TTReportField YEAR; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 32;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, -1, 287, 5, false);
                    HEADER.Name = "HEADER";
                    HEADER.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEADER.TextFont.Name = "Arial";
                    HEADER.TextFont.Size = 12;
                    HEADER.TextFont.Bold = true;
                    HEADER.TextFont.CharSet = 162;
                    HEADER.Value = @"";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 270, 12, 282, 32, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Size = 7;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"

AÇIKLA
MALAR";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 197, 12, 211, 32, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1141.TextFont.Name = "Arial";
                    NewField1141.TextFont.Size = 7;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"

SİPARİŞİN
KAPATILDI
ĞI TARİH";

                    NewField1142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 12, 237, 32, false);
                    NewField1142.Name = "NewField1142";
                    NewField1142.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1142.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1142.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1142.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1142.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1142.TextFont.Name = "Arial";
                    NewField1142.TextFont.Size = 7;
                    NewField1142.TextFont.Bold = true;
                    NewField1142.TextFont.CharSet = 162;
                    NewField1142.Value = @"

SORUMLU TEKNİSYEN";

                    NewField111421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 11, 315, 31, false);
                    NewField111421.Name = "NewField111421";
                    NewField111421.Visible = EvetHayirEnum.ehHayir;
                    NewField111421.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111421.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111421.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111421.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111421.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111421.TextFont.Name = "Arial";
                    NewField111421.TextFont.Size = 7;
                    NewField111421.TextFont.Bold = true;
                    NewField111421.TextFont.CharSet = 162;
                    NewField111421.Value = @"

BAKIM/
ONARIM BİTİŞ TARİHİ";

                    NewField111422 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 12, 69, 32, false);
                    NewField111422.Name = "NewField111422";
                    NewField111422.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111422.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111422.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111422.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111422.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111422.TextFont.Name = "Arial";
                    NewField111422.TextFont.Size = 7;
                    NewField111422.TextFont.Bold = true;
                    NewField111422.TextFont.CharSet = 162;
                    NewField111422.Value = @"


MARKA 
MODEL";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 12, 23, 32, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.MultiLine = EvetHayirEnum.ehEvet;
                    NewField15.WordBreak = EvetHayirEnum.ehEvet;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Size = 7;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"

SİPARİŞ NU.";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 12, 105, 32, false);
                    NewField16.Name = "NewField16";
                    NewField16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.MultiLine = EvetHayirEnum.ehEvet;
                    NewField16.WordBreak = EvetHayirEnum.ehEvet;
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Size = 7;
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"

SEVK
TÜRÜ";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 12, 50, 32, false);
                    NewField161.Name = "NewField161";
                    NewField161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField161.MultiLine = EvetHayirEnum.ehEvet;
                    NewField161.WordBreak = EvetHayirEnum.ehEvet;
                    NewField161.TextFont.Name = "Arial";
                    NewField161.TextFont.Size = 7;
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"


MALZEMENİN İSMİ";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 12, 169, 32, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1161.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1161.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1161.TextFont.Name = "Arial";
                    NewField1161.TextFont.Size = 7;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"

TESELLÜM TARİHİ";

                    NewField1162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 12, 155, 32, false);
                    NewField1162.Name = "NewField1162";
                    NewField1162.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1162.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1162.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1162.TextFont.Name = "Arial";
                    NewField1162.TextFont.Size = 7;
                    NewField1162.TextFont.Bold = true;
                    NewField1162.TextFont.CharSet = 162;
                    NewField1162.Value = @"BİRLİĞİN ADI";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 12, 183, 32, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11611.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11611.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11611.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11611.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11611.TextFont.Name = "Arial";
                    NewField11611.TextFont.Size = 7;
                    NewField11611.TextFont.Bold = true;
                    NewField11611.TextFont.CharSet = 162;
                    NewField11611.Value = @"

İLK MUAYENE
TARİHİ";

                    NewField111611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 12, 197, 32, false);
                    NewField111611.Name = "NewField111611";
                    NewField111611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111611.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111611.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111611.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111611.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111611.TextFont.Name = "Arial";
                    NewField111611.TextFont.Size = 7;
                    NewField111611.TextFont.Bold = true;
                    NewField111611.TextFont.CharSet = 162;
                    NewField111611.Value = @"

SİPARİŞİN AÇILDIĞI TARİHİ";

                    HEADER2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 307, 2, 332, 7, false);
                    HEADER2.Name = "HEADER2";
                    HEADER2.Visible = EvetHayirEnum.ehHayir;
                    HEADER2.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEADER2.ObjectDefName = "MaintenanceOrderType";
                    HEADER2.DataMember = "TYPECODE";
                    HEADER2.Value = @"{@ORDERST@}";

                    HEADER3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 335, 2, 360, 7, false);
                    HEADER3.Name = "HEADER3";
                    HEADER3.Visible = EvetHayirEnum.ehHayir;
                    HEADER3.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEADER3.ObjectDefName = "MaintenanceOrderType";
                    HEADER3.DataMember = "TYPENAME";
                    HEADER3.Value = @"{@ORDERST@}";

                    NewField1116111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 321, 11, 342, 31, false);
                    NewField1116111.Name = "NewField1116111";
                    NewField1116111.Visible = EvetHayirEnum.ehHayir;
                    NewField1116111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1116111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1116111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1116111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1116111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1116111.TextFont.Name = "Arial";
                    NewField1116111.TextFont.Size = 7;
                    NewField1116111.TextFont.Bold = true;
                    NewField1116111.TextFont.CharSet = 162;
                    NewField1116111.Value = @"

ATÖLYESİ";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 12, 244, 32, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.FontAngle = 900;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1.NoClip = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Size = 7;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"HAR. ZAMAN(S.)";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 12, 251, 32, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.FontAngle = 900;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField12.NoClip = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Size = 7;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"BİRİM MAL. (TL)";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 251, 12, 258, 32, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.FontAngle = 900;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField121.NoClip = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Size = 7;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"HARC. MAL. (TL)";

                    NewField1143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 258, 12, 270, 32, false);
                    NewField1143.Name = "NewField1143";
                    NewField1143.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1143.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1143.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1143.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1143.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1143.TextFont.Name = "Arial";
                    NewField1143.TextFont.Size = 7;
                    NewField1143.TextFont.Bold = true;
                    NewField1143.TextFont.CharSet = 162;
                    NewField1143.Value = @"

SİPARİŞ DURUMU";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 12, 6, 32, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.FontAngle = 900;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11.NoClip = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Size = 8;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"   S. NO.";

                    NewField1224111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 12, 89, 32, false);
                    NewField1224111.Name = "NewField1224111";
                    NewField1224111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1224111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1224111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1224111.TextFont.Name = "Arial";
                    NewField1224111.TextFont.Size = 7;
                    NewField1224111.TextFont.Bold = true;
                    NewField1224111.TextFont.CharSet = 162;
                    NewField1224111.Value = @"SERİ NU.
";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 12, 111, 32, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.FontAngle = 900;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField111.NoClip = EvetHayirEnum.ehEvet;
                    NewField111.TextFont.Size = 8;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"   Sip. Mik.";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 352, 13, 377, 18, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 354, 21, 379, 26, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    YEAR2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 5, 189, 10, false);
                    YEAR2.Name = "YEAR2";
                    YEAR2.FieldType = ReportFieldTypeEnum.ftVariable;
                    YEAR2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YEAR2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YEAR2.TextFont.Size = 12;
                    YEAR2.TextFont.Bold = true;
                    YEAR2.TextFont.CharSet = 162;
                    YEAR2.Value = @"{@YEAR@} YILI İÇİN";

                    YEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 377, 3, 402, 8, false);
                    YEAR.Name = "YEAR";
                    YEAR.Visible = EvetHayirEnum.ehHayir;
                    YEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    YEAR.Value = @"{@YEAR@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HEADER.CalcValue = @"";
                    NewField141.CalcValue = NewField141.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField1142.CalcValue = NewField1142.Value;
                    NewField111421.CalcValue = NewField111421.Value;
                    NewField111422.CalcValue = NewField111422.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField1162.CalcValue = NewField1162.Value;
                    NewField11611.CalcValue = NewField11611.Value;
                    NewField111611.CalcValue = NewField111611.Value;
                    HEADER2.CalcValue = MyParentReport.RuntimeParameters.ORDERST.ToString();
                    HEADER2.PostFieldValueCalculation();
                    HEADER3.CalcValue = MyParentReport.RuntimeParameters.ORDERST.ToString();
                    HEADER3.PostFieldValueCalculation();
                    NewField1116111.CalcValue = NewField1116111.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1143.CalcValue = NewField1143.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField1224111.CalcValue = NewField1224111.Value;
                    NewField111.CalcValue = NewField111.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    YEAR2.CalcValue = MyParentReport.RuntimeParameters.YEAR.ToString() + @" YILI İÇİN";
                    YEAR.CalcValue = MyParentReport.RuntimeParameters.YEAR.ToString();
                    return new TTReportObject[] { HEADER,NewField141,NewField1141,NewField1142,NewField111421,NewField111422,NewField15,NewField16,NewField161,NewField1161,NewField1162,NewField11611,NewField111611,HEADER2,HEADER3,NewField1116111,NewField1,NewField12,NewField121,NewField1143,NewField11,NewField1224111,NewField111,STARTDATE,ENDDATE,YEAR2,YEAR};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    HEADER.CalcValue ="("+(HEADER2.CalcValue).ToUpper()+") "+(HEADER3.CalcValue).ToUpper()+" SİPARİŞ TAKİP VE KAYIT DEFTERİ";
            
            ((CMRRegistrationReportByMS)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime("01.01."+ this.YEAR.CalcValue + " 00:00:00");
            ((CMRRegistrationReportByMS)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime("31.12."+ this.YEAR.CalcValue + " 23:59:59");
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public CMRRegistrationReportByMS MyParentReport
                {
                    get { return (CMRRegistrationReportByMS)ParentReport; }
                }
                
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportField PrintDate;
                public TTReportShape NewLine111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 0, 155, 5, false);
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

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 0, 282, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 25, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 280, 0, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PageNumber.CalcValue = @"Sayfa Nu." + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    CurrentUser.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PageNumber,PrintDate,CurrentUser};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public CMRRegistrationReportByMS MyParentReport
            {
                get { return (CMRRegistrationReportByMS)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField DATE { get {return Body().DATE;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField REQUESTDATE { get {return Body().REQUESTDATE;} }
            public TTReportField REQUESTNO { get {return Body().REQUESTNO;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField MARK { get {return Body().MARK;} }
            public TTReportField PERSONNEL { get {return Body().PERSONNEL;} }
            public TTReportField OWNERMILITARYUNIT { get {return Body().OWNERMILITARYUNIT;} }
            public TTReportField REFERTYPE { get {return Body().REFERTYPE;} }
            public TTReportField ORDERDATE { get {return Body().ORDERDATE;} }
            public TTReportField ARRIVALDATE { get {return Body().ARRIVALDATE;} }
            public TTReportField ENDDATE { get {return Body().ENDDATE;} }
            public TTReportField ORDERNAME { get {return Body().ORDERNAME;} }
            public TTReportField TOTALMATERIALPRICE { get {return Body().TOTALMATERIALPRICE;} }
            public TTReportField TOTALWORKLOAD { get {return Body().TOTALWORKLOAD;} }
            public TTReportField WORK { get {return Body().WORK;} }
            public TTReportField LABORCOST { get {return Body().LABORCOST;} }
            public TTReportField DIRECTMATERIALEXPENSE { get {return Body().DIRECTMATERIALEXPENSE;} }
            public TTReportField MANUFACTURINGAMOUNT { get {return Body().MANUFACTURINGAMOUNT;} }
            public TTReportField UNITCOST { get {return Body().UNITCOST;} }
            public TTReportField DEPRECIATIONEXPENSE { get {return Body().DEPRECIATIONEXPENSE;} }
            public TTReportField GENERALPROCESSINGCOST { get {return Body().GENERALPROCESSINGCOST;} }
            public TTReportField SERIALNO { get {return Body().SERIALNO;} }
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
                list[0] = new TTReportNqlData<MaintenanceOrder.GetMaintenanceAndRepairRegistryByMSReportQuery_Class>("GetMaintenanceAndRepairRegistryByMSReportQuery2", MaintenanceOrder.GetMaintenanceAndRepairRegistryByMSReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.ORDERST),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public CMRRegistrationReportByMS MyParentReport
                {
                    get { return (CMRRegistrationReportByMS)ParentReport; }
                }
                
                public TTReportField COUNT;
                public TTReportField DATE;
                public TTReportField DESCRIPTION;
                public TTReportField OBJECTID;
                public TTReportField REQUESTDATE;
                public TTReportField REQUESTNO;
                public TTReportField MATERIALNAME;
                public TTReportField MARK;
                public TTReportField PERSONNEL;
                public TTReportField OWNERMILITARYUNIT;
                public TTReportField REFERTYPE;
                public TTReportField ORDERDATE;
                public TTReportField ARRIVALDATE;
                public TTReportField ENDDATE;
                public TTReportField ORDERNAME;
                public TTReportField TOTALMATERIALPRICE;
                public TTReportField TOTALWORKLOAD;
                public TTReportField WORK;
                public TTReportField LABORCOST;
                public TTReportField DIRECTMATERIALEXPENSE;
                public TTReportField MANUFACTURINGAMOUNT;
                public TTReportField UNITCOST;
                public TTReportField DEPRECIATIONEXPENSE;
                public TTReportField GENERALPROCESSINGCOST;
                public TTReportField SERIALNO;
                public TTReportField AMOUNT; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 15;
                    RepeatCount = 0;
                    
                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 6, 15, false);
                    COUNT.Name = "COUNT";
                    COUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.MultiLine = EvetHayirEnum.ehEvet;
                    COUNT.WordBreak = EvetHayirEnum.ehEvet;
                    COUNT.TextFont.Size = 7;
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{@counter@}";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 197, 0, 211, 15, false);
                    DATE.Name = "DATE";
                    DATE.DrawStyle = DrawStyleConstants.vbSolid;
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"Short Date";
                    DATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DATE.MultiLine = EvetHayirEnum.ehEvet;
                    DATE.WordBreak = EvetHayirEnum.ehEvet;
                    DATE.TextFont.Size = 7;
                    DATE.TextFont.CharSet = 162;
                    DATE.Value = @"{#ENDDATE#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 270, 0, 282, 15, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Size = 7;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 305, 2, 330, 9, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OBJECTID.MultiLine = EvetHayirEnum.ehEvet;
                    OBJECTID.WordBreak = EvetHayirEnum.ehEvet;
                    OBJECTID.TextFont.Name = "Arial";
                    OBJECTID.TextFont.Size = 7;
                    OBJECTID.TextFont.CharSet = 162;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 0, 169, 15, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFormat = @"Short Date";
                    REQUESTDATE.MultiLine = EvetHayirEnum.ehEvet;
                    REQUESTDATE.WordBreak = EvetHayirEnum.ehEvet;
                    REQUESTDATE.TextFont.Size = 7;
                    REQUESTDATE.TextFont.CharSet = 162;
                    REQUESTDATE.Value = @"";

                    REQUESTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 0, 23, 15, false);
                    REQUESTNO.Name = "REQUESTNO";
                    REQUESTNO.DrawStyle = DrawStyleConstants.vbSolid;
                    REQUESTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTNO.MultiLine = EvetHayirEnum.ehEvet;
                    REQUESTNO.WordBreak = EvetHayirEnum.ehEvet;
                    REQUESTNO.TextFont.Size = 7;
                    REQUESTNO.TextFont.CharSet = 162;
                    REQUESTNO.Value = @"{#REQUESTNO#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 0, 50, 15, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALNAME.TextFont.Size = 7;
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"{#MATERIALNAME#}";

                    MARK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 0, 69, 15, false);
                    MARK.Name = "MARK";
                    MARK.DrawStyle = DrawStyleConstants.vbSolid;
                    MARK.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARK.MultiLine = EvetHayirEnum.ehEvet;
                    MARK.WordBreak = EvetHayirEnum.ehEvet;
                    MARK.TextFont.Size = 7;
                    MARK.TextFont.CharSet = 162;
                    MARK.Value = @"{#MARK#} {#MODEL#}";

                    PERSONNEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 0, 237, 15, false);
                    PERSONNEL.Name = "PERSONNEL";
                    PERSONNEL.DrawStyle = DrawStyleConstants.vbSolid;
                    PERSONNEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    PERSONNEL.MultiLine = EvetHayirEnum.ehEvet;
                    PERSONNEL.WordBreak = EvetHayirEnum.ehEvet;
                    PERSONNEL.TextFont.Size = 7;
                    PERSONNEL.TextFont.CharSet = 162;
                    PERSONNEL.Value = @"{#PERSONNEL#}";

                    OWNERMILITARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 0, 155, 15, false);
                    OWNERMILITARYUNIT.Name = "OWNERMILITARYUNIT";
                    OWNERMILITARYUNIT.DrawStyle = DrawStyleConstants.vbSolid;
                    OWNERMILITARYUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    OWNERMILITARYUNIT.MultiLine = EvetHayirEnum.ehEvet;
                    OWNERMILITARYUNIT.WordBreak = EvetHayirEnum.ehEvet;
                    OWNERMILITARYUNIT.TextFont.Size = 7;
                    OWNERMILITARYUNIT.TextFont.CharSet = 162;
                    OWNERMILITARYUNIT.Value = @"{#OWNERMILITARYUNIT#}";

                    REFERTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 0, 105, 15, false);
                    REFERTYPE.Name = "REFERTYPE";
                    REFERTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    REFERTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REFERTYPE.MultiLine = EvetHayirEnum.ehEvet;
                    REFERTYPE.WordBreak = EvetHayirEnum.ehEvet;
                    REFERTYPE.ObjectDefName = "ReferTypeEnum";
                    REFERTYPE.DataMember = "DISPLAYTEXT";
                    REFERTYPE.TextFont.Size = 7;
                    REFERTYPE.TextFont.CharSet = 162;
                    REFERTYPE.Value = @"{#REFERTYPE#}";

                    ORDERDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 0, 183, 15, false);
                    ORDERDATE.Name = "ORDERDATE";
                    ORDERDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERDATE.TextFormat = @"Short Date";
                    ORDERDATE.MultiLine = EvetHayirEnum.ehEvet;
                    ORDERDATE.WordBreak = EvetHayirEnum.ehEvet;
                    ORDERDATE.TextFont.Size = 7;
                    ORDERDATE.TextFont.CharSet = 162;
                    ORDERDATE.Value = @"{#ORDERDATE#}";

                    ARRIVALDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 0, 197, 15, false);
                    ARRIVALDATE.Name = "ARRIVALDATE";
                    ARRIVALDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    ARRIVALDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ARRIVALDATE.TextFormat = @"Short Date";
                    ARRIVALDATE.MultiLine = EvetHayirEnum.ehEvet;
                    ARRIVALDATE.WordBreak = EvetHayirEnum.ehEvet;
                    ARRIVALDATE.TextFont.Size = 7;
                    ARRIVALDATE.TextFont.CharSet = 162;
                    ARRIVALDATE.Value = @"{#ARRIVALDATE#}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 418, 1, 432, 16, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.MultiLine = EvetHayirEnum.ehEvet;
                    ENDDATE.WordBreak = EvetHayirEnum.ehEvet;
                    ENDDATE.TextFont.Size = 7;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{#ENDDATE#}";

                    ORDERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 258, 0, 270, 15, false);
                    ORDERNAME.Name = "ORDERNAME";
                    ORDERNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNAME.MultiLine = EvetHayirEnum.ehEvet;
                    ORDERNAME.WordBreak = EvetHayirEnum.ehEvet;
                    ORDERNAME.TextFont.Size = 7;
                    ORDERNAME.TextFont.CharSet = 162;
                    ORDERNAME.Value = @"{#ORDERNAME#}";

                    TOTALMATERIALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 0, 251, 15, false);
                    TOTALMATERIALPRICE.Name = "TOTALMATERIALPRICE";
                    TOTALMATERIALPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALMATERIALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALMATERIALPRICE.TextFont.Size = 7;
                    TOTALMATERIALPRICE.TextFont.CharSet = 162;
                    TOTALMATERIALPRICE.Value = @"{#TOTALMATERIALPRICE#}";

                    TOTALWORKLOAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 0, 244, 15, false);
                    TOTALWORKLOAD.Name = "TOTALWORKLOAD";
                    TOTALWORKLOAD.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALWORKLOAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALWORKLOAD.TextFont.Size = 7;
                    TOTALWORKLOAD.TextFont.CharSet = 162;
                    TOTALWORKLOAD.Value = @"{#TOTALWORKLOAD#}";

                    WORK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 395, 1, 416, 16, false);
                    WORK.Name = "WORK";
                    WORK.Visible = EvetHayirEnum.ehHayir;
                    WORK.DrawStyle = DrawStyleConstants.vbSolid;
                    WORK.FieldType = ReportFieldTypeEnum.ftVariable;
                    WORK.MultiLine = EvetHayirEnum.ehEvet;
                    WORK.WordBreak = EvetHayirEnum.ehEvet;
                    WORK.TextFont.Size = 7;
                    WORK.TextFont.CharSet = 162;
                    WORK.Value = @"{#WORK#}";

                    LABORCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 351, 11, 362, 16, false);
                    LABORCOST.Name = "LABORCOST";
                    LABORCOST.Visible = EvetHayirEnum.ehHayir;
                    LABORCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    LABORCOST.Value = @"{#LABORCOST#}";

                    DIRECTMATERIALEXPENSE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 366, 9, 390, 14, false);
                    DIRECTMATERIALEXPENSE.Name = "DIRECTMATERIALEXPENSE";
                    DIRECTMATERIALEXPENSE.Visible = EvetHayirEnum.ehHayir;
                    DIRECTMATERIALEXPENSE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIRECTMATERIALEXPENSE.Value = @"{#DIRECTMATERIALEXPENSE#}";

                    MANUFACTURINGAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 333, 10, 350, 15, false);
                    MANUFACTURINGAMOUNT.Name = "MANUFACTURINGAMOUNT";
                    MANUFACTURINGAMOUNT.Visible = EvetHayirEnum.ehHayir;
                    MANUFACTURINGAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MANUFACTURINGAMOUNT.Value = @"{#MANUFACTURINGAMOUNT#}";

                    UNITCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 251, 0, 258, 15, false);
                    UNITCOST.Name = "UNITCOST";
                    UNITCOST.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITCOST.TextFormat = @"#,##0.#0";
                    UNITCOST.TextFont.Size = 7;
                    UNITCOST.TextFont.CharSet = 162;
                    UNITCOST.Value = @"";

                    DEPRECIATIONEXPENSE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 333, 2, 348, 7, false);
                    DEPRECIATIONEXPENSE.Name = "DEPRECIATIONEXPENSE";
                    DEPRECIATIONEXPENSE.Visible = EvetHayirEnum.ehHayir;
                    DEPRECIATIONEXPENSE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEPRECIATIONEXPENSE.Value = @"{#DEPRECIATIONEXPENSE#}";

                    GENERALPROCESSINGCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 350, 2, 369, 7, false);
                    GENERALPROCESSINGCOST.Name = "GENERALPROCESSINGCOST";
                    GENERALPROCESSINGCOST.Visible = EvetHayirEnum.ehHayir;
                    GENERALPROCESSINGCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    GENERALPROCESSINGCOST.Value = @"{#GENERALPROCESSINGCOST#}";

                    SERIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 0, 89, 15, false);
                    SERIALNO.Name = "SERIALNO";
                    SERIALNO.DrawStyle = DrawStyleConstants.vbSolid;
                    SERIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERIALNO.MultiLine = EvetHayirEnum.ehEvet;
                    SERIALNO.WordBreak = EvetHayirEnum.ehEvet;
                    SERIALNO.TextFont.Size = 7;
                    SERIALNO.TextFont.CharSet = 162;
                    SERIALNO.Value = @"{#SERIALNUMBER#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 0, 111, 15, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    AMOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    AMOUNT.TextFont.Size = 7;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#AMOUNT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceAndRepairRegistryByMSReportQuery_Class dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2 = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceAndRepairRegistryByMSReportQuery_Class>(0);
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    DATE.CalcValue = (dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2.EndDate) : "");
                    DESCRIPTION.CalcValue = @"";
                    OBJECTID.CalcValue = (dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2.ObjectID) : "");
                    REQUESTDATE.CalcValue = @"";
                    REQUESTNO.CalcValue = (dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2.RequestNo) : "");
                    MATERIALNAME.CalcValue = (dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2.Materialname) : "");
                    MARK.CalcValue = (dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2.Mark) : "") + @" " + (dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2.Model) : "");
                    PERSONNEL.CalcValue = (dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2.Personnel) : "");
                    OWNERMILITARYUNIT.CalcValue = (dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2.Ownermilitaryunit) : "");
                    REFERTYPE.CalcValue = (dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2.ReferType) : "");
                    REFERTYPE.PostFieldValueCalculation();
                    ORDERDATE.CalcValue = (dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2.OrderDate) : "");
                    ARRIVALDATE.CalcValue = (dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2.ArrivalDate) : "");
                    ENDDATE.CalcValue = (dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2.EndDate) : "");
                    ORDERNAME.CalcValue = (dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2.OrderName) : "");
                    TOTALMATERIALPRICE.CalcValue = (dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2.TotalMaterialPrice) : "");
                    TOTALWORKLOAD.CalcValue = (dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2.TotalWorkLoad) : "");
                    WORK.CalcValue = (dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2.Work) : "");
                    LABORCOST.CalcValue = (dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2.Laborcost) : "");
                    DIRECTMATERIALEXPENSE.CalcValue = (dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2.Directmaterialexpense) : "");
                    MANUFACTURINGAMOUNT.CalcValue = (dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2.ManufacturingAmount) : "");
                    UNITCOST.CalcValue = @"";
                    DEPRECIATIONEXPENSE.CalcValue = (dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2.Depreciationexpense) : "");
                    GENERALPROCESSINGCOST.CalcValue = (dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2.Generalprocessingcost) : "");
                    SERIALNO.CalcValue = (dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2.SerialNumber) : "");
                    AMOUNT.CalcValue = (dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryByMSReportQuery2.Amount) : "");
                    return new TTReportObject[] { COUNT,DATE,DESCRIPTION,OBJECTID,REQUESTDATE,REQUESTNO,MATERIALNAME,MARK,PERSONNEL,OWNERMILITARYUNIT,REFERTYPE,ORDERDATE,ARRIVALDATE,ENDDATE,ORDERNAME,TOTALMATERIALPRICE,TOTALWORKLOAD,WORK,LABORCOST,DIRECTMATERIALEXPENSE,MANUFACTURINGAMOUNT,UNITCOST,DEPRECIATIONEXPENSE,GENERALPROCESSINGCOST,SERIALNO,AMOUNT};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //            string objectID = OBJECTID.CalcValue;
            //            MaintenanceOrder mo = (MaintenanceOrder)MyParentReport.ReportObjectContext.GetObject(new Guid(objectID), typeof(MaintenanceOrder));
            //            if(mo.UsedConsumedMaterails.Count > 0)
            //            {
            //                foreach(UsedConsumedMaterail usedMaterial in mo.UsedConsumedMaterails)
            //                {
            //                    USEDMATERIALS.CalcValue += usedMaterial.Material.Name + "\n";
            //                }
            //            }
            
                                                      TTObjectContext cont = new TTObjectContext(true);
            string requestno = this.REQUESTNO.CalcValue;
            BindingList<Repair.GetActualDeliveryDate_Class> list = Repair.GetActualDeliveryDate(cont, requestno);
            foreach (Repair.GetActualDeliveryDate_Class lst in list)
            {
                if(lst.RequestNo == requestno)
                    this.REQUESTDATE.CalcValue = lst.ActualDeliveryDate.ToString();
            }
            
            
            if(MANUFACTURINGAMOUNT.CalcValue =="")
            {
                MANUFACTURINGAMOUNT.CalcValue = "1";
            }
            string totalCost = (Convert.ToDouble(LABORCOST.CalcValue) +
                                Convert.ToDouble(DIRECTMATERIALEXPENSE.CalcValue) +
                                Convert.ToDouble(DEPRECIATIONEXPENSE.CalcValue) +
                                Convert.ToDouble(GENERALPROCESSINGCOST.CalcValue)).ToString();
            UNITCOST.CalcValue = (Convert.ToDouble(totalCost) / Convert.ToDouble(MANUFACTURINGAMOUNT.CalcValue)).ToString();
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

        public CMRRegistrationReportByMS()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("ORDERST", "00000000-0000-0000-0000-000000000000", "Sipariş Türü", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("af7d16f1-157b-48ac-a4b1-a53600f07b22");
            reportParameter = Parameters.Add("STARTDATE", "", "", @"", false, false, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "", @"", false, false, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("YEAR", "2014", "Yılını Yazınız", @"", true, true, false, new Guid("c202916a-01df-4eeb-a809-96e7bfbd2bd2"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("ORDERST"))
                _runtimeParameters.ORDERST = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["ORDERST"]);
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("YEAR"))
                _runtimeParameters.YEAR = (string)TTObjectDefManager.Instance.DataTypes["String_4"].ConvertValue(parameters["YEAR"]);
            Name = "CMRREGISTRATIONREPORTBYMS";
            Caption = "SİPARİŞ TAKİP VE KAYIT DEFTERİ";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 10;
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