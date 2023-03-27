
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
    /// Tarihler Arası Onarım Raporu (SİMBK)
    /// </summary>
    public partial class MonthlyRepairReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public MonthlyRepairReport MyParentReport
            {
                get { return (MonthlyRepairReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField HOSPITAL { get {return Header().HOSPITAL;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField123 { get {return Header().NewField123;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportField NewField132 { get {return Header().NewField132;} }
            public TTReportShape NewLine1112 { get {return Header().NewLine1112;} }
            public TTReportField NewField133 { get {return Header().NewField133;} }
            public TTReportShape NewLine1113 { get {return Header().NewLine1113;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportShape NewLine11111 { get {return Header().NewLine11111;} }
            public TTReportField NewField1231 { get {return Header().NewField1231;} }
            public TTReportShape NewLine12111 { get {return Header().NewLine12111;} }
            public TTReportField NewField1331 { get {return Header().NewField1331;} }
            public TTReportShape NewLine13111 { get {return Header().NewLine13111;} }
            public TTReportField NewField134 { get {return Header().NewField134;} }
            public TTReportShape NewLine1114 { get {return Header().NewLine1114;} }
            public TTReportField NewField1431 { get {return Header().NewField1431;} }
            public TTReportShape NewLine14111 { get {return Header().NewLine14111;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportShape NewLine13 { get {return Header().NewLine13;} }
            public TTReportField NewField11321 { get {return Header().NewField11321;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField MONTH1 { get {return Header().MONTH1;} }
            public TTReportField MONTH11 { get {return Header().MONTH11;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField REPORTNAME1 { get {return Header().REPORTNAME1;} }
            public TTReportField MATERIALTYPE1 { get {return Footer().MATERIALTYPE1;} }
            public TTReportField TOTALCENSUSFROMPREVIOUSMONTH { get {return Footer().TOTALCENSUSFROMPREVIOUSMONTH;} }
            public TTReportField TOTALNEWCOMES { get {return Footer().TOTALNEWCOMES;} }
            public TTReportField GRANDTOTAL1 { get {return Footer().GRANDTOTAL1;} }
            public TTReportField TOTALMAINTENANCEATFACTORY { get {return Footer().TOTALMAINTENANCEATFACTORY;} }
            public TTReportField TOTALTEAMREQUEST { get {return Footer().TOTALTEAMREQUEST;} }
            public TTReportField GRANDTOTAL2 { get {return Footer().GRANDTOTAL2;} }
            public TTReportField TOTALHEKFROMMAINTENANCE { get {return Footer().TOTALHEKFROMMAINTENANCE;} }
            public TTReportField TOTALHEKFROMFIRSTCHECK { get {return Footer().TOTALHEKFROMFIRSTCHECK;} }
            public TTReportField GRANDTOTAL3 { get {return Footer().GRANDTOTAL3;} }
            public TTReportField TOTALPROCESSING { get {return Footer().TOTALPROCESSING;} }
            public TTReportField TOTALCIRCULATING { get {return Footer().TOTALCIRCULATING;} }
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
                public MonthlyRepairReport MyParentReport
                {
                    get { return (MonthlyRepairReport)ParentReport; }
                }
                
                public TTReportField HOSPITAL;
                public TTReportField NewField1;
                public TTReportField NewField12;
                public TTReportField NewField122;
                public TTReportField NewField11;
                public TTReportField NewField123;
                public TTReportField NewField1221;
                public TTReportShape NewLine1;
                public TTReportField NewField13;
                public TTReportShape NewLine11;
                public TTReportShape NewLine111;
                public TTReportField NewField131;
                public TTReportShape NewLine1111;
                public TTReportField NewField132;
                public TTReportShape NewLine1112;
                public TTReportField NewField133;
                public TTReportShape NewLine1113;
                public TTReportField NewField111;
                public TTReportField NewField1131;
                public TTReportShape NewLine11111;
                public TTReportField NewField1231;
                public TTReportShape NewLine12111;
                public TTReportField NewField1331;
                public TTReportShape NewLine13111;
                public TTReportField NewField134;
                public TTReportShape NewLine1114;
                public TTReportField NewField1431;
                public TTReportShape NewLine14111;
                public TTReportShape NewLine12;
                public TTReportShape NewLine2;
                public TTReportShape NewLine13;
                public TTReportField NewField11321;
                public TTReportField NewField1111;
                public TTReportField MONTH1;
                public TTReportField MONTH11;
                public TTReportField NewField14;
                public TTReportField REPORTNAME1; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 86;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HOSPITAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 20, 287, 27, false);
                    HOSPITAL.Name = "HOSPITAL";
                    HOSPITAL.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITAL.TextFont.Name = "Arial";
                    HOSPITAL.TextFont.Size = 11;
                    HOSPITAL.TextFont.Bold = true;
                    HOSPITAL.TextFont.CharSet = 162;
                    HOSPITAL.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 44, 27, 84, false);
                    NewField1.Name = "NewField1";
                    NewField1.FontAngle = 900;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"SIRA NU.";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 44, 183, 84, false);
                    NewField12.Name = "NewField12";
                    NewField12.FontAngle = 900;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"ÖNCEKİ DÖNEMDEN";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 44, 187, 84, false);
                    NewField122.Name = "NewField122";
                    NewField122.FontAngle = 900;
                    NewField122.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField122.TextFont.Name = "Arial";
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"DEVİR";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 44, 177, 84, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"ATÖLYE";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 44, 192, 84, false);
                    NewField123.Name = "NewField123";
                    NewField123.FontAngle = 900;
                    NewField123.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField123.TextFont.Name = "Arial";
                    NewField123.TextFont.Bold = true;
                    NewField123.TextFont.CharSet = 162;
                    NewField123.Value = @"DÖNEM İÇİNDE";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 44, 197, 84, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.FontAngle = 900;
                    NewField1221.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1221.TextFont.Name = "Arial";
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @"GELEN";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 187, 44, 187, 84, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 44, 204, 84, false);
                    NewField13.Name = "NewField13";
                    NewField13.FontAngle = 900;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"TOPLAM";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 197, 44, 197, 84, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 207, 44, 207, 84, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, 49, 214, 84, false);
                    NewField131.Name = "NewField131";
                    NewField131.FontAngle = 900;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"FABRİKADA";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 217, 49, 217, 84, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 49, 224, 84, false);
                    NewField132.Name = "NewField132";
                    NewField132.FontAngle = 900;
                    NewField132.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField132.TextFont.Name = "Arial";
                    NewField132.TextFont.Bold = true;
                    NewField132.TextFont.CharSet = 162;
                    NewField132.Value = @"SYY. EKİP";

                    NewLine1112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 227, 49, 227, 84, false);
                    NewLine1112.Name = "NewLine1112";
                    NewLine1112.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 49, 234, 84, false);
                    NewField133.Name = "NewField133";
                    NewField133.FontAngle = 900;
                    NewField133.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField133.TextFont.Name = "Arial";
                    NewField133.TextFont.Bold = true;
                    NewField133.TextFont.CharSet = 162;
                    NewField133.Value = @"TOPLAM";

                    NewLine1113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 237, 49, 237, 84, false);
                    NewLine1113.Name = "NewLine1113";
                    NewLine1113.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 207, 44, 237, 49, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"ONARILAN";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 49, 244, 84, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.FontAngle = 900;
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"ONARIMDAN";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 247, 49, 247, 84, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 49, 252, 84, false);
                    NewField1231.Name = "NewField1231";
                    NewField1231.FontAngle = 900;
                    NewField1231.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1231.TextFont.Name = "Arial";
                    NewField1231.TextFont.Bold = true;
                    NewField1231.TextFont.CharSet = 162;
                    NewField1231.Value = @"İLK";

                    NewLine12111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 257, 49, 257, 84, false);
                    NewLine12111.Name = "NewLine12111";
                    NewLine12111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 260, 49, 264, 84, false);
                    NewField1331.Name = "NewField1331";
                    NewField1331.FontAngle = 900;
                    NewField1331.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1331.TextFont.Name = "Arial";
                    NewField1331.TextFont.Bold = true;
                    NewField1331.TextFont.CharSet = 162;
                    NewField1331.Value = @"TOPLAM";

                    NewLine13111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 267, 49, 267, 84, false);
                    NewLine13111.Name = "NewLine13111";
                    NewLine13111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField134 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 270, 44, 274, 84, false);
                    NewField134.Name = "NewField134";
                    NewField134.FontAngle = 900;
                    NewField134.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField134.TextFont.Name = "Arial";
                    NewField134.TextFont.Bold = true;
                    NewField134.TextFont.CharSet = 162;
                    NewField134.Value = @"İŞLEM GÖREN";

                    NewLine1114 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 277, 44, 277, 84, false);
                    NewLine1114.Name = "NewLine1114";
                    NewLine1114.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1431 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 280, 44, 284, 84, false);
                    NewField1431.Name = "NewField1431";
                    NewField1431.FontAngle = 900;
                    NewField1431.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1431.TextFont.Name = "Arial";
                    NewField1431.TextFont.Bold = true;
                    NewField1431.TextFont.CharSet = 162;
                    NewField1431.Value = @"DEVREDEN";

                    NewLine14111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 287, 44, 287, 84, false);
                    NewLine14111.Name = "NewLine14111";
                    NewLine14111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 44, 20, 84, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 84, 287, 84, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 44, 287, 44, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 252, 49, 256, 84, false);
                    NewField11321.Name = "NewField11321";
                    NewField11321.FontAngle = 900;
                    NewField11321.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11321.TextFont.Name = "Arial";
                    NewField11321.TextFont.Bold = true;
                    NewField11321.TextFont.CharSet = 162;
                    NewField11321.Value = @"MUAYENEDEN";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 44, 267, 49, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"HEK";

                    MONTH1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 27, 153, 34, false);
                    MONTH1.Name = "MONTH1";
                    MONTH1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MONTH1.TextFormat = @"dd/MM/yyyy";
                    MONTH1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MONTH1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MONTH1.TextFont.Name = "Arial";
                    MONTH1.TextFont.Bold = true;
                    MONTH1.TextFont.CharSet = 162;
                    MONTH1.Value = @"{@STARTDATE@}";

                    MONTH11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 27, 177, 34, false);
                    MONTH11.Name = "MONTH11";
                    MONTH11.FieldType = ReportFieldTypeEnum.ftVariable;
                    MONTH11.TextFormat = @"dd/MM/yyyy";
                    MONTH11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MONTH11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MONTH11.TextFont.Name = "Arial";
                    MONTH11.TextFont.Bold = true;
                    MONTH11.TextFont.CharSet = 162;
                    MONTH11.Value = @"{@ENDDATE@}";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 27, 155, 34, false);
                    NewField14.Name = "NewField14";
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"-";

                    REPORTNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 34, 261, 41, false);
                    REPORTNAME1.Name = "REPORTNAME1";
                    REPORTNAME1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME1.TextFont.Name = "Arial";
                    REPORTNAME1.TextFont.Size = 11;
                    REPORTNAME1.TextFont.Bold = true;
                    REPORTNAME1.TextFont.CharSet = 162;
                    REPORTNAME1.Value = @"TARİHLERİ ARASI ONARIM RAPORU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField123.CalcValue = NewField123.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField132.CalcValue = NewField132.Value;
                    NewField133.CalcValue = NewField133.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1231.CalcValue = NewField1231.Value;
                    NewField1331.CalcValue = NewField1331.Value;
                    NewField134.CalcValue = NewField134.Value;
                    NewField1431.CalcValue = NewField1431.Value;
                    NewField11321.CalcValue = NewField11321.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    MONTH1.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    MONTH11.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField14.CalcValue = NewField14.Value;
                    REPORTNAME1.CalcValue = REPORTNAME1.Value;
                    HOSPITAL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { NewField1,NewField12,NewField122,NewField11,NewField123,NewField1221,NewField13,NewField131,NewField132,NewField133,NewField111,NewField1131,NewField1231,NewField1331,NewField134,NewField1431,NewField11321,NewField1111,MONTH1,MONTH11,NewField14,REPORTNAME1,HOSPITAL};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    //DateTime selectedMonth = (DateTime)((MonthlyRepairReport)ParentReport).RuntimeParameters.DATE;
                    //switch (selectedMonth.Month)
                    //{
                    //    case 1:
                    //        MONTH.CalcValue = "OCAK " + selectedMonth.Year.ToString();
                    //        break;

                    //    case 2:
                    //        MONTH.CalcValue = "ŞUBAT " + selectedMonth.Year.ToString();
                    //        break;

                    //    case 3:
                    //        MONTH.CalcValue = "MART " + selectedMonth.Year.ToString();
                    //        break;

                    //    case 4:
                    //        MONTH.CalcValue = "NİSAN " + selectedMonth.Year.ToString();
                    //        break;

                    //    case 5:
                    //        MONTH.CalcValue = "MAYIS " + selectedMonth.Year.ToString();
                    //        break;

                    //    case 6:
                    //        MONTH.CalcValue = "HAZİRAN " + selectedMonth.Year.ToString();
                    //        break;

                    //    case 7:
                    //        MONTH.CalcValue = "TEMMUZ " + selectedMonth.Year.ToString();
                    //        break;

                    //    case 8:
                    //        MONTH.CalcValue = "AĞUSTOS " + selectedMonth.Year.ToString();
                    //        break;

                    //    case 9:
                    //        MONTH.CalcValue = "EYLÜL " + selectedMonth.Year.ToString();
                    //        break;

                    //    case 10:
                    //        MONTH.CalcValue = "EKİM " + selectedMonth.Year.ToString();
                    //        break;

                    //    case 11:
                    //        MONTH.CalcValue = "KASIM " + selectedMonth.Year.ToString();
                    //        break;

                    //    case 12:
                    //        MONTH.CalcValue = "ARALIK " + selectedMonth.Year.ToString();
                    //        break;
                    //}
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public MonthlyRepairReport MyParentReport
                {
                    get { return (MonthlyRepairReport)ParentReport; }
                }
                
                public TTReportField MATERIALTYPE1;
                public TTReportField TOTALCENSUSFROMPREVIOUSMONTH;
                public TTReportField TOTALNEWCOMES;
                public TTReportField GRANDTOTAL1;
                public TTReportField TOTALMAINTENANCEATFACTORY;
                public TTReportField TOTALTEAMREQUEST;
                public TTReportField GRANDTOTAL2;
                public TTReportField TOTALHEKFROMMAINTENANCE;
                public TTReportField TOTALHEKFROMFIRSTCHECK;
                public TTReportField GRANDTOTAL3;
                public TTReportField TOTALPROCESSING;
                public TTReportField TOTALCIRCULATING; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                    MATERIALTYPE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 177, 8, false);
                    MATERIALTYPE1.Name = "MATERIALTYPE1";
                    MATERIALTYPE1.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALTYPE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALTYPE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALTYPE1.TextFont.Name = "Arial";
                    MATERIALTYPE1.TextFont.Bold = true;
                    MATERIALTYPE1.TextFont.CharSet = 162;
                    MATERIALTYPE1.Value = @"TOPLAM";

                    TOTALCENSUSFROMPREVIOUSMONTH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 0, 187, 8, false);
                    TOTALCENSUSFROMPREVIOUSMONTH.Name = "TOTALCENSUSFROMPREVIOUSMONTH";
                    TOTALCENSUSFROMPREVIOUSMONTH.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALCENSUSFROMPREVIOUSMONTH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALCENSUSFROMPREVIOUSMONTH.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALCENSUSFROMPREVIOUSMONTH.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALCENSUSFROMPREVIOUSMONTH.TextFont.Name = "Arial";
                    TOTALCENSUSFROMPREVIOUSMONTH.TextFont.Bold = true;
                    TOTALCENSUSFROMPREVIOUSMONTH.TextFont.CharSet = 162;
                    TOTALCENSUSFROMPREVIOUSMONTH.Value = @"0";

                    TOTALNEWCOMES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 0, 197, 8, false);
                    TOTALNEWCOMES.Name = "TOTALNEWCOMES";
                    TOTALNEWCOMES.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALNEWCOMES.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALNEWCOMES.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALNEWCOMES.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALNEWCOMES.TextFont.Name = "Arial";
                    TOTALNEWCOMES.TextFont.Bold = true;
                    TOTALNEWCOMES.TextFont.CharSet = 162;
                    TOTALNEWCOMES.Value = @"0";

                    GRANDTOTAL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 197, 0, 207, 8, false);
                    GRANDTOTAL1.Name = "GRANDTOTAL1";
                    GRANDTOTAL1.DrawStyle = DrawStyleConstants.vbSolid;
                    GRANDTOTAL1.FieldType = ReportFieldTypeEnum.ftVariable;
                    GRANDTOTAL1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GRANDTOTAL1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GRANDTOTAL1.TextFont.Name = "Arial";
                    GRANDTOTAL1.TextFont.Bold = true;
                    GRANDTOTAL1.TextFont.CharSet = 162;
                    GRANDTOTAL1.Value = @"";

                    TOTALMAINTENANCEATFACTORY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 207, 0, 217, 8, false);
                    TOTALMAINTENANCEATFACTORY.Name = "TOTALMAINTENANCEATFACTORY";
                    TOTALMAINTENANCEATFACTORY.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALMAINTENANCEATFACTORY.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALMAINTENANCEATFACTORY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALMAINTENANCEATFACTORY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALMAINTENANCEATFACTORY.TextFont.Name = "Arial";
                    TOTALMAINTENANCEATFACTORY.TextFont.Bold = true;
                    TOTALMAINTENANCEATFACTORY.TextFont.CharSet = 162;
                    TOTALMAINTENANCEATFACTORY.Value = @"0";

                    TOTALTEAMREQUEST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 0, 227, 8, false);
                    TOTALTEAMREQUEST.Name = "TOTALTEAMREQUEST";
                    TOTALTEAMREQUEST.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALTEAMREQUEST.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALTEAMREQUEST.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALTEAMREQUEST.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALTEAMREQUEST.TextFont.Name = "Arial";
                    TOTALTEAMREQUEST.TextFont.Bold = true;
                    TOTALTEAMREQUEST.TextFont.CharSet = 162;
                    TOTALTEAMREQUEST.Value = @"0";

                    GRANDTOTAL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 0, 237, 8, false);
                    GRANDTOTAL2.Name = "GRANDTOTAL2";
                    GRANDTOTAL2.DrawStyle = DrawStyleConstants.vbSolid;
                    GRANDTOTAL2.FieldType = ReportFieldTypeEnum.ftVariable;
                    GRANDTOTAL2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GRANDTOTAL2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GRANDTOTAL2.TextFont.Name = "Arial";
                    GRANDTOTAL2.TextFont.Bold = true;
                    GRANDTOTAL2.TextFont.CharSet = 162;
                    GRANDTOTAL2.Value = @"0";

                    TOTALHEKFROMMAINTENANCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 0, 247, 8, false);
                    TOTALHEKFROMMAINTENANCE.Name = "TOTALHEKFROMMAINTENANCE";
                    TOTALHEKFROMMAINTENANCE.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALHEKFROMMAINTENANCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALHEKFROMMAINTENANCE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALHEKFROMMAINTENANCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALHEKFROMMAINTENANCE.TextFont.Name = "Arial";
                    TOTALHEKFROMMAINTENANCE.TextFont.Bold = true;
                    TOTALHEKFROMMAINTENANCE.TextFont.CharSet = 162;
                    TOTALHEKFROMMAINTENANCE.Value = @"0";

                    TOTALHEKFROMFIRSTCHECK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 0, 257, 8, false);
                    TOTALHEKFROMFIRSTCHECK.Name = "TOTALHEKFROMFIRSTCHECK";
                    TOTALHEKFROMFIRSTCHECK.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALHEKFROMFIRSTCHECK.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALHEKFROMFIRSTCHECK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALHEKFROMFIRSTCHECK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALHEKFROMFIRSTCHECK.TextFont.Name = "Arial";
                    TOTALHEKFROMFIRSTCHECK.TextFont.Bold = true;
                    TOTALHEKFROMFIRSTCHECK.TextFont.CharSet = 162;
                    TOTALHEKFROMFIRSTCHECK.Value = @"0";

                    GRANDTOTAL3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 0, 267, 8, false);
                    GRANDTOTAL3.Name = "GRANDTOTAL3";
                    GRANDTOTAL3.DrawStyle = DrawStyleConstants.vbSolid;
                    GRANDTOTAL3.FieldType = ReportFieldTypeEnum.ftVariable;
                    GRANDTOTAL3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GRANDTOTAL3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GRANDTOTAL3.TextFont.Name = "Arial";
                    GRANDTOTAL3.TextFont.Bold = true;
                    GRANDTOTAL3.TextFont.CharSet = 162;
                    GRANDTOTAL3.Value = @"0";

                    TOTALPROCESSING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 267, 0, 277, 8, false);
                    TOTALPROCESSING.Name = "TOTALPROCESSING";
                    TOTALPROCESSING.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALPROCESSING.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPROCESSING.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALPROCESSING.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALPROCESSING.TextFont.Name = "Arial";
                    TOTALPROCESSING.TextFont.Bold = true;
                    TOTALPROCESSING.TextFont.CharSet = 162;
                    TOTALPROCESSING.Value = @"0";

                    TOTALCIRCULATING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 277, 0, 287, 8, false);
                    TOTALCIRCULATING.Name = "TOTALCIRCULATING";
                    TOTALCIRCULATING.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALCIRCULATING.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALCIRCULATING.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALCIRCULATING.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALCIRCULATING.TextFont.Name = "Arial";
                    TOTALCIRCULATING.TextFont.Bold = true;
                    TOTALCIRCULATING.TextFont.CharSet = 162;
                    TOTALCIRCULATING.Value = @"0";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MATERIALTYPE1.CalcValue = MATERIALTYPE1.Value;
                    TOTALCENSUSFROMPREVIOUSMONTH.CalcValue = @"0";
                    TOTALNEWCOMES.CalcValue = @"0";
                    GRANDTOTAL1.CalcValue = @"";
                    TOTALMAINTENANCEATFACTORY.CalcValue = @"0";
                    TOTALTEAMREQUEST.CalcValue = @"0";
                    GRANDTOTAL2.CalcValue = @"0";
                    TOTALHEKFROMMAINTENANCE.CalcValue = @"0";
                    TOTALHEKFROMFIRSTCHECK.CalcValue = @"0";
                    GRANDTOTAL3.CalcValue = @"0";
                    TOTALPROCESSING.CalcValue = @"0";
                    TOTALCIRCULATING.CalcValue = @"0";
                    return new TTReportObject[] { MATERIALTYPE1,TOTALCENSUSFROMPREVIOUSMONTH,TOTALNEWCOMES,GRANDTOTAL1,TOTALMAINTENANCEATFACTORY,TOTALTEAMREQUEST,GRANDTOTAL2,TOTALHEKFROMMAINTENANCE,TOTALHEKFROMFIRSTCHECK,GRANDTOTAL3,TOTALPROCESSING,TOTALCIRCULATING};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    TOTALCENSUSFROMPREVIOUSMONTH.CalcValue = totalCensusFromPreviousMonth.ToString();
                    TOTALNEWCOMES.CalcValue = totalNewComes.ToString();
                    GRANDTOTAL1.CalcValue = (totalCensusFromPreviousMonth + totalNewComes).ToString();

                    TOTALMAINTENANCEATFACTORY.CalcValue = totalMaintenanceAtFactory.ToString();
                    TOTALTEAMREQUEST.CalcValue = totalTeamRequest.ToString();
                    GRANDTOTAL2.CalcValue = (totalMaintenanceAtFactory + totalTeamRequest).ToString();

                    TOTALHEKFROMMAINTENANCE.CalcValue = totalHEKFromMaintenance.ToString();
                    TOTALHEKFROMFIRSTCHECK.CalcValue = totalHEKFromFirstCheck.ToString();
                    GRANDTOTAL3.CalcValue = (totalHEKFromMaintenance + totalHEKFromFirstCheck).ToString();

                    TOTALPROCESSING.CalcValue = totalProcessing.ToString();
                    TOTALCIRCULATING.CalcValue = (Convert.ToInt32(GRANDTOTAL1.CalcValue) - totalProcessing).ToString();

                    totalCensusFromPreviousMonth = 0;
                    totalNewComes = 0;
                    totalMaintenanceAtFactory = 0;
                    totalTeamRequest = 0;
                    totalHEKFromMaintenance = 0;
                    totalHEKFromFirstCheck = 0;
                    totalProcessing = 0;
#endregion PARTA FOOTER_Script
                }
            }

#region PARTA_Methods
            public static int totalCensusFromPreviousMonth = 0, totalNewComes = 0, totalHEKFromMaintenance = 0, totalHEKFromFirstCheck = 0,
                totalMaintenanceAtFactory = 0, totalTeamRequest = 0, totalProcessing = 0;
#endregion PARTA_Methods
        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public MonthlyRepairReport MyParentReport
            {
                get { return (MonthlyRepairReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField WORKSHOP { get {return Body().WORKSHOP;} }
            public TTReportField CENSUSFROMPREVIOUSMONTH { get {return Body().CENSUSFROMPREVIOUSMONTH;} }
            public TTReportField NEWCOMES { get {return Body().NEWCOMES;} }
            public TTReportField TOTAL1 { get {return Body().TOTAL1;} }
            public TTReportField MAINTENANCEATFACTORY { get {return Body().MAINTENANCEATFACTORY;} }
            public TTReportField TEAMREQUEST { get {return Body().TEAMREQUEST;} }
            public TTReportField TOTAL2 { get {return Body().TOTAL2;} }
            public TTReportField HEKFROMMAINTENANCE { get {return Body().HEKFROMMAINTENANCE;} }
            public TTReportField HEKFROMFIRSTCHECK { get {return Body().HEKFROMFIRSTCHECK;} }
            public TTReportField TOTAL3 { get {return Body().TOTAL3;} }
            public TTReportField PROCESSING { get {return Body().PROCESSING;} }
            public TTReportField CIRCULATING { get {return Body().CIRCULATING;} }
            public TTReportField WORKSHOPID { get {return Body().WORKSHOPID;} }
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
                list[0] = new TTReportNqlData<MaintenanceOrder.GetWorkshopNameQuery_Class>("GetWorkshopNameQuery", MaintenanceOrder.GetWorkshopNameQuery());
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
                public MonthlyRepairReport MyParentReport
                {
                    get { return (MonthlyRepairReport)ParentReport; }
                }
                
                public TTReportField COUNT;
                public TTReportField WORKSHOP;
                public TTReportField CENSUSFROMPREVIOUSMONTH;
                public TTReportField NEWCOMES;
                public TTReportField TOTAL1;
                public TTReportField MAINTENANCEATFACTORY;
                public TTReportField TEAMREQUEST;
                public TTReportField TOTAL2;
                public TTReportField HEKFROMMAINTENANCE;
                public TTReportField HEKFROMFIRSTCHECK;
                public TTReportField TOTAL3;
                public TTReportField PROCESSING;
                public TTReportField CIRCULATING;
                public TTReportField WORKSHOPID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 11;
                    RepeatCount = 0;
                    
                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 30, 8, false);
                    COUNT.Name = "COUNT";
                    COUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.TextFont.Name = "Arial";
                    COUNT.TextFont.Bold = true;
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{@counter@}.";

                    WORKSHOP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 0, 177, 8, false);
                    WORKSHOP.Name = "WORKSHOP";
                    WORKSHOP.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKSHOP.FieldType = ReportFieldTypeEnum.ftVariable;
                    WORKSHOP.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKSHOP.TextFont.Name = "Arial";
                    WORKSHOP.TextFont.Bold = true;
                    WORKSHOP.TextFont.CharSet = 162;
                    WORKSHOP.Value = @" {#WORKSHOP#}";

                    CENSUSFROMPREVIOUSMONTH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 0, 187, 8, false);
                    CENSUSFROMPREVIOUSMONTH.Name = "CENSUSFROMPREVIOUSMONTH";
                    CENSUSFROMPREVIOUSMONTH.DrawStyle = DrawStyleConstants.vbSolid;
                    CENSUSFROMPREVIOUSMONTH.FieldType = ReportFieldTypeEnum.ftVariable;
                    CENSUSFROMPREVIOUSMONTH.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CENSUSFROMPREVIOUSMONTH.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CENSUSFROMPREVIOUSMONTH.TextFont.Name = "Arial";
                    CENSUSFROMPREVIOUSMONTH.TextFont.CharSet = 162;
                    CENSUSFROMPREVIOUSMONTH.Value = @"";

                    NEWCOMES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 0, 197, 8, false);
                    NEWCOMES.Name = "NEWCOMES";
                    NEWCOMES.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWCOMES.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWCOMES.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NEWCOMES.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEWCOMES.TextFont.Name = "Arial";
                    NEWCOMES.TextFont.CharSet = 162;
                    NEWCOMES.Value = @"";

                    TOTAL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 197, 0, 207, 8, false);
                    TOTAL1.Name = "TOTAL1";
                    TOTAL1.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTAL1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTAL1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTAL1.TextFont.Name = "Arial";
                    TOTAL1.TextFont.Bold = true;
                    TOTAL1.TextFont.CharSet = 162;
                    TOTAL1.Value = @"";

                    MAINTENANCEATFACTORY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 207, 0, 217, 8, false);
                    MAINTENANCEATFACTORY.Name = "MAINTENANCEATFACTORY";
                    MAINTENANCEATFACTORY.DrawStyle = DrawStyleConstants.vbSolid;
                    MAINTENANCEATFACTORY.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAINTENANCEATFACTORY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MAINTENANCEATFACTORY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MAINTENANCEATFACTORY.TextFont.Name = "Arial";
                    MAINTENANCEATFACTORY.TextFont.CharSet = 162;
                    MAINTENANCEATFACTORY.Value = @"";

                    TEAMREQUEST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 0, 227, 8, false);
                    TEAMREQUEST.Name = "TEAMREQUEST";
                    TEAMREQUEST.DrawStyle = DrawStyleConstants.vbSolid;
                    TEAMREQUEST.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEAMREQUEST.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEAMREQUEST.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEAMREQUEST.TextFont.Name = "Arial";
                    TEAMREQUEST.TextFont.CharSet = 162;
                    TEAMREQUEST.Value = @"";

                    TOTAL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 0, 237, 8, false);
                    TOTAL2.Name = "TOTAL2";
                    TOTAL2.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTAL2.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTAL2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTAL2.TextFont.Name = "Arial";
                    TOTAL2.TextFont.Bold = true;
                    TOTAL2.TextFont.CharSet = 162;
                    TOTAL2.Value = @"";

                    HEKFROMMAINTENANCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 0, 247, 8, false);
                    HEKFROMMAINTENANCE.Name = "HEKFROMMAINTENANCE";
                    HEKFROMMAINTENANCE.DrawStyle = DrawStyleConstants.vbSolid;
                    HEKFROMMAINTENANCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEKFROMMAINTENANCE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEKFROMMAINTENANCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEKFROMMAINTENANCE.TextFont.Name = "Arial";
                    HEKFROMMAINTENANCE.TextFont.CharSet = 162;
                    HEKFROMMAINTENANCE.Value = @"";

                    HEKFROMFIRSTCHECK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 0, 257, 8, false);
                    HEKFROMFIRSTCHECK.Name = "HEKFROMFIRSTCHECK";
                    HEKFROMFIRSTCHECK.DrawStyle = DrawStyleConstants.vbSolid;
                    HEKFROMFIRSTCHECK.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEKFROMFIRSTCHECK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEKFROMFIRSTCHECK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEKFROMFIRSTCHECK.TextFont.Name = "Arial";
                    HEKFROMFIRSTCHECK.TextFont.CharSet = 162;
                    HEKFROMFIRSTCHECK.Value = @"";

                    TOTAL3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 0, 267, 8, false);
                    TOTAL3.Name = "TOTAL3";
                    TOTAL3.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTAL3.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTAL3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTAL3.TextFont.Name = "Arial";
                    TOTAL3.TextFont.Bold = true;
                    TOTAL3.TextFont.CharSet = 162;
                    TOTAL3.Value = @"";

                    PROCESSING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 267, 0, 277, 8, false);
                    PROCESSING.Name = "PROCESSING";
                    PROCESSING.DrawStyle = DrawStyleConstants.vbSolid;
                    PROCESSING.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCESSING.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PROCESSING.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROCESSING.TextFont.Name = "Arial";
                    PROCESSING.TextFont.Bold = true;
                    PROCESSING.TextFont.CharSet = 162;
                    PROCESSING.Value = @"";

                    CIRCULATING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 277, 0, 287, 8, false);
                    CIRCULATING.Name = "CIRCULATING";
                    CIRCULATING.DrawStyle = DrawStyleConstants.vbSolid;
                    CIRCULATING.FieldType = ReportFieldTypeEnum.ftVariable;
                    CIRCULATING.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CIRCULATING.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CIRCULATING.TextFont.Name = "Arial";
                    CIRCULATING.TextFont.Bold = true;
                    CIRCULATING.TextFont.CharSet = 162;
                    CIRCULATING.Value = @"";

                    WORKSHOPID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 2, 326, 7, false);
                    WORKSHOPID.Name = "WORKSHOPID";
                    WORKSHOPID.Visible = EvetHayirEnum.ehHayir;
                    WORKSHOPID.FieldType = ReportFieldTypeEnum.ftVariable;
                    WORKSHOPID.Value = @"{#WORKSHOPID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetWorkshopNameQuery_Class dataset_GetWorkshopNameQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetWorkshopNameQuery_Class>(0);
                    COUNT.CalcValue = ParentGroup.Counter.ToString() + @".";
                    WORKSHOP.CalcValue = @" " + (dataset_GetWorkshopNameQuery != null ? Globals.ToStringCore(dataset_GetWorkshopNameQuery.Workshop) : "");
                    CENSUSFROMPREVIOUSMONTH.CalcValue = @"";
                    NEWCOMES.CalcValue = @"";
                    TOTAL1.CalcValue = @"";
                    MAINTENANCEATFACTORY.CalcValue = @"";
                    TEAMREQUEST.CalcValue = @"";
                    TOTAL2.CalcValue = @"";
                    HEKFROMMAINTENANCE.CalcValue = @"";
                    HEKFROMFIRSTCHECK.CalcValue = @"";
                    TOTAL3.CalcValue = @"";
                    PROCESSING.CalcValue = @"";
                    CIRCULATING.CalcValue = @"";
                    WORKSHOPID.CalcValue = (dataset_GetWorkshopNameQuery != null ? Globals.ToStringCore(dataset_GetWorkshopNameQuery.Workshopid) : "");
                    return new TTReportObject[] { COUNT,WORKSHOP,CENSUSFROMPREVIOUSMONTH,NEWCOMES,TOTAL1,MAINTENANCEATFACTORY,TEAMREQUEST,TOTAL2,HEKFROMMAINTENANCE,HEKFROMFIRSTCHECK,TOTAL3,PROCESSING,CIRCULATING,WORKSHOPID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            DateTime selectedStartDate = Convert.ToDateTime(((MonthlyRepairReport)ParentReport).RuntimeParameters.STARTDATE.ToString());
            DateTime selectedEndDate = Convert.ToDateTime(((MonthlyRepairReport)ParentReport).RuntimeParameters.ENDDATE.ToString());
            
            BindingList<MaintenanceOrder.GetMonthlyRepairReportQuery_Class> list;
            BindingList<MaintenanceOrder.GetMonthlyMaintenanceReportFromMaintenanceQuery_Class> listUncomplated;
            BindingList<MaintenanceOrder.GetMonthlyMaintenanceReportFromMaintenanceQuery_Class> donemlistdevam;
            int oncekiDonemDevir = 0;
            int devamEdenDonem = 0;
            if (WORKSHOPID.CalcValue != "")
            {
                //önceki dönemde açılmış ve hala devam eden işleri getir
                listUncomplated = MaintenanceOrder.GetMonthlyMaintenanceReportFromMaintenanceQuery(ctx,new Guid(WORKSHOPID.CalcValue)," AND STARTDATE >= TODATE('"+ selectedStartDate.ToString("yyyy.MM.dd HH:mm:ss",null) + "') AND CURRENTSTATE IS UNCOMPLETED");
                oncekiDonemDevir = Convert.ToInt32(listUncomplated.Count);
                CENSUSFROMPREVIOUSMONTH.CalcValue = oncekiDonemDevir.ToString();
                
                PARTAGroup.totalCensusFromPreviousMonth = PARTAGroup.totalCensusFromPreviousMonth + oncekiDonemDevir;
                
                //seçili  dönemde açılmıştüm işler.
                IList  newdonem = MaintenanceOrder.GetHekFromMaintenanceQuery(ctx, new Guid(WORKSHOPID.CalcValue)," AND STARTDATE <= TODATE('" + selectedStartDate.ToString("yyyy.MM.dd HH:mm:ss",null) + "') AND ENDDATE >= TODATE('"+ selectedEndDate.ToString("yyyy.MM.dd HH:mm:ss",null) + "')");
                NEWCOMES.CalcValue = newdonem.Count.ToString();
                PARTAGroup.totalNewComes = PARTAGroup.totalNewComes + newdonem.Count;
                
                TOTAL1.CalcValue = (oncekiDonemDevir + newdonem.Count).ToString();
        
                //FABRİKADA ONARILAN yeni
                list = MaintenanceOrder.GetMonthlyRepairReportQuery(ctx,new Guid(WORKSHOPID.CalcValue)," AND STARTDATE <= TODATE('" + selectedStartDate.ToString("yyyy.MM.dd HH:mm:ss",null)
                                                                    + "') AND ENDDATE >= TODATE('"+ selectedEndDate.ToString("yyyy.MM.dd HH:mm:ss",null)
                                                                    + "')  AND MAINTENANCEORDERTYPE.TYPENAME = 'Fabrika Onarım' AND CURRENTSTATE IS SUCCESSFUL AND (ORDERSTATUS NOT IN (2,3) OR ORDERSTATUS IS NULL)");
                MAINTENANCEATFACTORY.CalcValue = list[0].Total.ToString();
                PARTAGroup.totalMaintenanceAtFactory = PARTAGroup.totalMaintenanceAtFactory + Convert.ToInt32(list[0].Total);
                
                //SEYYAR EKİP TARAFINDAN ONARILAN
                list = MaintenanceOrder.GetMonthlyRepairReportQuery(ctx,new Guid(WORKSHOPID.CalcValue)," AND STARTDATE <= TODATE('" + selectedStartDate.ToString("yyyy.MM.dd HH:mm:ss",null)
                                                                    + "') AND ENDDATE >= TODATE('"+ selectedEndDate.ToString("yyyy.MM.dd HH:mm:ss",null)
                                                                    + "')  AND REFERTYPE = 3 AND MAINTENANCEORDERTYPE.TYPENAME = 'Mahalinde Onarım ve Kalibrasyon' AND CURRENTSTATE IS SUCCESSFUL AND (ORDERSTATUS NOT IN (2,3) OR ORDERSTATUS IS NULL)");
                TEAMREQUEST.CalcValue = list[0].Total.ToString();
                PARTAGroup.totalTeamRequest = PARTAGroup.totalTeamRequest + Convert.ToInt32(list[0].Total);
                
                //2. TOPLAM
                TOTAL2.CalcValue = (Convert.ToInt32(MAINTENANCEATFACTORY.CalcValue) + Convert.ToInt32(TEAMREQUEST.CalcValue)).ToString();

                //ONARIMDAN HEK
                list = MaintenanceOrder.GetMonthlyRepairReportQuery(ctx,new Guid(WORKSHOPID.CalcValue)," AND STARTDATE <= TODATE('" + selectedStartDate.ToString("yyyy.MM.dd HH:mm:ss",null)
                                                                    + "') AND ENDDATE >= TODATE('"+ selectedEndDate.ToString("yyyy.MM.dd HH:mm:ss",null)
                                                                    + "') AND ORDERSTATUS = 3 AND CURRENTSTATE IS SUCCESSFUL AND MAINTENANCEORDERTYPE.TYPENAME IN ('Mahalinde Onarım ve Kalibrasyon', 'Fabrika Onarım')");
                
                HEKFROMMAINTENANCE.CalcValue = list[0].Total.ToString();
                PARTAGroup.totalHEKFromMaintenance = PARTAGroup.totalHEKFromMaintenance + Convert.ToInt32(list[0].Total);

                //İLK MUAYENEDEN HEK
                list = MaintenanceOrder.GetMonthlyRepairReportQuery(ctx,new Guid(WORKSHOPID.CalcValue)," AND STARTDATE <= TODATE('" + selectedStartDate.ToString("yyyy.MM.dd HH:mm:ss",null)
                                                                    + "') AND ENDDATE >= TODATE('"+ selectedEndDate.ToString("yyyy.MM.dd HH:mm:ss",null)
                                                                    + "') AND ORDERSTATUS = 2 AND CURRENTSTATE IS SUCCESSFUL AND MAINTENANCEORDERTYPE.TYPENAME IN ('Mahalinde Onarım ve Kalibrasyon', 'Fabrika Onarım')");
                
                HEKFROMFIRSTCHECK.CalcValue = list[0].Total.ToString();
                PARTAGroup.totalHEKFromFirstCheck = PARTAGroup.totalHEKFromFirstCheck + Convert.ToInt32(list[0].Total);

                //3. TOPLAM
                TOTAL3.CalcValue = (Convert.ToInt32(HEKFROMMAINTENANCE.CalcValue) + Convert.ToInt32(HEKFROMFIRSTCHECK.CalcValue)).ToString();

                //İŞLEM GÖREN
                list = MaintenanceOrder.GetMonthlyRepairReportQuery(ctx,new Guid(WORKSHOPID.CalcValue)," AND STARTDATE <= TODATE('" + selectedStartDate.ToString("yyyy.MM.dd HH:mm:ss",null)
                                                                    + "') AND ENDDATE >= TODATE('"+ selectedEndDate.ToString("yyyy.MM.dd HH:mm:ss",null)
                                                                    + "') AND CURRENTSTATE IS SUCCESSFUL AND MAINTENANCEORDERTYPE.TYPENAME IN ('Mahalinde Onarım ve Kalibrasyon', 'Fabrika Onarım')");
                
                PROCESSING.CalcValue = list[0].Total.ToString();
                PARTAGroup.totalProcessing = PARTAGroup.totalProcessing + Convert.ToInt32(list[0].Total);

                //DEVREDEN
                CIRCULATING.CalcValue = (Convert.ToInt32(TOTAL1.CalcValue) -(Convert.ToInt32(TOTAL2.CalcValue)+Convert.ToInt32(TOTAL3.CalcValue)+Convert.ToInt32(PROCESSING.CalcValue))).ToString();
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

        public MonthlyRepairReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi :", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi :", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "MONTHLYREPAIRREPORT";
            Caption = "Tarihler Arası Onarım Raporu (SİMBK)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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