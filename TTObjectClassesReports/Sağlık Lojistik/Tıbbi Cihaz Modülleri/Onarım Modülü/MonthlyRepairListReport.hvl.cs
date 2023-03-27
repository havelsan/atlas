
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
    /// Tarihler Arası Onarım Listesi Raporu (XXXXXX İçin)
    /// </summary>
    public partial class MonthlyRepairListReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public MonthlyRepairListReport MyParentReport
            {
                get { return (MonthlyRepairListReport)ParentReport; }
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
            public TTReportField REPORTNAME { get {return Header().REPORTNAME;} }
            public TTReportField MONTH { get {return Header().MONTH;} }
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
            public TTReportShape NewLine1113 { get {return Header().NewLine1113;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportShape NewLine11111 { get {return Header().NewLine11111;} }
            public TTReportField NewField1331 { get {return Header().NewField1331;} }
            public TTReportField NewField134 { get {return Header().NewField134;} }
            public TTReportShape NewLine1114 { get {return Header().NewLine1114;} }
            public TTReportField NewField1431 { get {return Header().NewField1431;} }
            public TTReportShape NewLine14111 { get {return Header().NewLine14111;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportShape NewLine13 { get {return Header().NewLine13;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField MONTH1 { get {return Header().MONTH1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField MATERIALTYPE1 { get {return Footer().MATERIALTYPE1;} }
            public TTReportField TOTALCENSUSFROMPREVIOUSMONTH { get {return Footer().TOTALCENSUSFROMPREVIOUSMONTH;} }
            public TTReportField TOTALNEWCOMES { get {return Footer().TOTALNEWCOMES;} }
            public TTReportField GRANDTOTAL1 { get {return Footer().GRANDTOTAL1;} }
            public TTReportField TOTALHEKFROMMAINTENANCE { get {return Footer().TOTALHEKFROMMAINTENANCE;} }
            public TTReportField GRANDTOTAL3 { get {return Footer().GRANDTOTAL3;} }
            public TTReportField TOTALPROCESSING { get {return Footer().TOTALPROCESSING;} }
            public TTReportField TOTALCIRCULATING { get {return Footer().TOTALCIRCULATING;} }
            public TTReportField PrintDate1111 { get {return Footer().PrintDate1111;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
            public TTReportField NewField4 { get {return Footer().NewField4;} }
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
                public MonthlyRepairListReport MyParentReport
                {
                    get { return (MonthlyRepairListReport)ParentReport; }
                }
                
                public TTReportField HOSPITAL;
                public TTReportField REPORTNAME;
                public TTReportField MONTH;
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
                public TTReportShape NewLine1113;
                public TTReportField NewField1131;
                public TTReportShape NewLine11111;
                public TTReportField NewField1331;
                public TTReportField NewField134;
                public TTReportShape NewLine1114;
                public TTReportField NewField1431;
                public TTReportShape NewLine14111;
                public TTReportShape NewLine12;
                public TTReportShape NewLine2;
                public TTReportShape NewLine13;
                public TTReportField NewField1111;
                public TTReportField MONTH1;
                public TTReportField NewField2; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 86;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HOSPITAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 20, 247, 27, false);
                    HOSPITAL.Name = "HOSPITAL";
                    HOSPITAL.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITAL.TextFont.Name = "Arial";
                    HOSPITAL.TextFont.Size = 11;
                    HOSPITAL.TextFont.Bold = true;
                    HOSPITAL.TextFont.CharSet = 162;
                    HOSPITAL.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 34, 247, 41, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 11;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"TARİHLERİ ARASI ONARIM RAPORU";

                    MONTH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 27, 132, 34, false);
                    MONTH.Name = "MONTH";
                    MONTH.FieldType = ReportFieldTypeEnum.ftVariable;
                    MONTH.TextFormat = @"dd/MM/yyyy";
                    MONTH.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MONTH.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MONTH.TextFont.Name = "Arial";
                    MONTH.TextFont.Size = 11;
                    MONTH.TextFont.Bold = true;
                    MONTH.TextFont.CharSet = 162;
                    MONTH.Value = @"{@STARTDATE@}";

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

                    NewLine1113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 227, 49, 227, 84, false);
                    NewLine1113.Name = "NewLine1113";
                    NewLine1113.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, 49, 214, 84, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.FontAngle = 900;
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"ONARIMDAN";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 217, 49, 217, 84, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 49, 224, 84, false);
                    NewField1331.Name = "NewField1331";
                    NewField1331.FontAngle = 900;
                    NewField1331.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1331.TextFont.Name = "Arial";
                    NewField1331.TextFont.Bold = true;
                    NewField1331.TextFont.CharSet = 162;
                    NewField1331.Value = @"TOPLAM";

                    NewField134 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 44, 234, 84, false);
                    NewField134.Name = "NewField134";
                    NewField134.FontAngle = 900;
                    NewField134.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField134.TextFont.Name = "Arial";
                    NewField134.TextFont.Bold = true;
                    NewField134.TextFont.CharSet = 162;
                    NewField134.Value = @"İŞLEM GÖREN";

                    NewLine1114 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 237, 44, 237, 84, false);
                    NewLine1114.Name = "NewLine1114";
                    NewLine1114.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1431 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 44, 244, 84, false);
                    NewField1431.Name = "NewField1431";
                    NewField1431.FontAngle = 900;
                    NewField1431.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1431.TextFont.Name = "Arial";
                    NewField1431.TextFont.Bold = true;
                    NewField1431.TextFont.CharSet = 162;
                    NewField1431.Value = @"DEVREDEN";

                    NewLine14111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 247, 44, 247, 84, false);
                    NewLine14111.Name = "NewLine14111";
                    NewLine14111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 44, 20, 84, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 84, 247, 84, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 44, 247, 44, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 207, 44, 227, 49, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"HEK";

                    MONTH1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 27, 156, 34, false);
                    MONTH1.Name = "MONTH1";
                    MONTH1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MONTH1.TextFormat = @"dd/MM/yyyy";
                    MONTH1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MONTH1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MONTH1.TextFont.Name = "Arial";
                    MONTH1.TextFont.Size = 11;
                    MONTH1.TextFont.Bold = true;
                    MONTH1.TextFont.CharSet = 162;
                    MONTH1.Value = @"{@ENDDATE@}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 27, 134, 34, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Size = 11;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"-";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    MONTH.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField1.CalcValue = NewField1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField123.CalcValue = NewField123.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1331.CalcValue = NewField1331.Value;
                    NewField134.CalcValue = NewField134.Value;
                    NewField1431.CalcValue = NewField1431.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    MONTH1.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField2.CalcValue = NewField2.Value;
                    HOSPITAL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { REPORTNAME,MONTH,NewField1,NewField12,NewField122,NewField11,NewField123,NewField1221,NewField13,NewField1131,NewField1331,NewField134,NewField1431,NewField1111,MONTH1,NewField2,HOSPITAL};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    /*DateTime selectedStartMonth = (DateTime)((MonthlyRepairListReport)ParentReport).RuntimeParameters.STARTDATE;
                    DateTime selectedEndMonth = (DateTime)((MonthlyRepairListReport)ParentReport).RuntimeParameters.ENDDATE;
                  string startDate ="";
                    switch (selectedStartMonth.Month)
                    {
                        case 1:
                            MONTH.CalcValue = "OCAK " + selectedStartMonth.Year.ToString();
                            break;

                        case 2:
                            MONTH.CalcValue = "ŞUBAT " + selectedStartMonth.Year.ToString();
                            break;

                        case 3:
                            MONTH.CalcValue = "MART " + selectedStartMonth.Year.ToString();
                            break;

                        case 4:
                            MONTH.CalcValue = "NİSAN " + selectedStartMonth.Year.ToString();
                            break;

                        case 5:
                            MONTH.CalcValue = "MAYIS " + selectedStartMonth.Year.ToString();
                            break;

                        case 6:
                            MONTH.CalcValue = "HAZİRAN " + selectedStartMonth.Year.ToString();
                            break;

                        case 7:
                            MONTH.CalcValue = "TEMMUZ " + selectedStartMonth.Year.ToString();
                            break;

                        case 8:
                            MONTH.CalcValue = "AĞUSTOS " + selectedStartMonth.Year.ToString();
                            break;

                        case 9:
                            MONTH.CalcValue = "EYLÜL " + selectedStartMonth.Year.ToString();
                            break;

                        case 10:
                            MONTH.CalcValue = "EKİM " + selectedStartMonth.Year.ToString();
                            break;

                        case 11:
                            MONTH.CalcValue = "KASIM " + selectedStartMonth.Year.ToString();
                            break;

                        case 12:
                            MONTH.CalcValue = "ARALIK " + selectedStartMonth.Year.ToString();
                            break;
                    }
                    startDate = MONTH.CalcValue + " - ";
                     switch (selectedEndMonth.Month)
                    {
                        case 1:
                            MONTH.CalcValue = startDate + "OCAK " + selectedEndMonth.Year.ToString();
                            break;

                        case 2:
                            MONTH.CalcValue = startDate + "ŞUBAT " + selectedEndMonth.Year.ToString();
                            break;

                        case 3:
                            MONTH.CalcValue = startDate + "MART " + selectedEndMonth.Year.ToString();
                            break;

                        case 4:
                            MONTH.CalcValue = startDate + "NİSAN " + selectedEndMonth.Year.ToString();
                            break;

                        case 5:
                            MONTH.CalcValue = startDate + "MAYIS " + selectedEndMonth.Year.ToString();
                            break;

                        case 6:
                            MONTH.CalcValue = startDate + "HAZİRAN " + selectedEndMonth.Year.ToString();
                            break;

                        case 7:
                            MONTH.CalcValue = startDate + "TEMMUZ " + selectedEndMonth.Year.ToString();
                            break;

                        case 8:
                            MONTH.CalcValue = startDate + "AĞUSTOS " + selectedEndMonth.Year.ToString();
                            break;

                        case 9:
                            MONTH.CalcValue = startDate + "EYLÜL " + selectedEndMonth.Year.ToString();
                            break;

                        case 10:
                            MONTH.CalcValue = startDate + "EKİM " + selectedEndMonth.Year.ToString();
                            break;

                        case 11:
                            MONTH.CalcValue = startDate + "KASIM " + selectedEndMonth.Year.ToString();
                            break;

                        case 12:
                            MONTH.CalcValue = startDate + "ARALIK " + selectedEndMonth.Year.ToString();
                            break;
                    }*/
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public MonthlyRepairListReport MyParentReport
                {
                    get { return (MonthlyRepairListReport)ParentReport; }
                }
                
                public TTReportField MATERIALTYPE1;
                public TTReportField TOTALCENSUSFROMPREVIOUSMONTH;
                public TTReportField TOTALNEWCOMES;
                public TTReportField GRANDTOTAL1;
                public TTReportField TOTALHEKFROMMAINTENANCE;
                public TTReportField GRANDTOTAL3;
                public TTReportField TOTALPROCESSING;
                public TTReportField TOTALCIRCULATING;
                public TTReportField PrintDate1111;
                public TTReportField NewField3;
                public TTReportField NewField4; 
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
                    GRANDTOTAL1.Value = @"0";

                    TOTALHEKFROMMAINTENANCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 207, 0, 217, 8, false);
                    TOTALHEKFROMMAINTENANCE.Name = "TOTALHEKFROMMAINTENANCE";
                    TOTALHEKFROMMAINTENANCE.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALHEKFROMMAINTENANCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALHEKFROMMAINTENANCE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALHEKFROMMAINTENANCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALHEKFROMMAINTENANCE.TextFont.Name = "Arial";
                    TOTALHEKFROMMAINTENANCE.TextFont.Bold = true;
                    TOTALHEKFROMMAINTENANCE.TextFont.CharSet = 162;
                    TOTALHEKFROMMAINTENANCE.Value = @"0";

                    GRANDTOTAL3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 0, 227, 8, false);
                    GRANDTOTAL3.Name = "GRANDTOTAL3";
                    GRANDTOTAL3.DrawStyle = DrawStyleConstants.vbSolid;
                    GRANDTOTAL3.FieldType = ReportFieldTypeEnum.ftVariable;
                    GRANDTOTAL3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GRANDTOTAL3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GRANDTOTAL3.TextFont.Name = "Arial";
                    GRANDTOTAL3.TextFont.Bold = true;
                    GRANDTOTAL3.TextFont.CharSet = 162;
                    GRANDTOTAL3.Value = @"0";

                    TOTALPROCESSING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 0, 237, 8, false);
                    TOTALPROCESSING.Name = "TOTALPROCESSING";
                    TOTALPROCESSING.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALPROCESSING.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPROCESSING.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALPROCESSING.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALPROCESSING.TextFont.Name = "Arial";
                    TOTALPROCESSING.TextFont.Bold = true;
                    TOTALPROCESSING.TextFont.CharSet = 162;
                    TOTALPROCESSING.Value = @"0";

                    TOTALCIRCULATING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 0, 247, 8, false);
                    TOTALCIRCULATING.Name = "TOTALCIRCULATING";
                    TOTALCIRCULATING.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALCIRCULATING.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALCIRCULATING.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALCIRCULATING.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALCIRCULATING.TextFont.Name = "Arial";
                    TOTALCIRCULATING.TextFont.Bold = true;
                    TOTALCIRCULATING.TextFont.CharSet = 162;
                    TOTALCIRCULATING.Value = @"0";

                    PrintDate1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 15, 60, 20, false);
                    PrintDate1111.Name = "PrintDate1111";
                    PrintDate1111.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate1111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PrintDate1111.TextFont.Bold = true;
                    PrintDate1111.TextFont.CharSet = 162;
                    PrintDate1111.Value = @"{@printdate@}";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 15, 36, 20, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"BU RAPOR";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 15, 102, 20, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"TARİHİNDE ALINMIŞTIR.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MATERIALTYPE1.CalcValue = MATERIALTYPE1.Value;
                    TOTALCENSUSFROMPREVIOUSMONTH.CalcValue = @"0";
                    TOTALNEWCOMES.CalcValue = @"0";
                    GRANDTOTAL1.CalcValue = @"0";
                    TOTALHEKFROMMAINTENANCE.CalcValue = @"0";
                    GRANDTOTAL3.CalcValue = @"0";
                    TOTALPROCESSING.CalcValue = @"0";
                    TOTALCIRCULATING.CalcValue = @"0";
                    PrintDate1111.CalcValue = DateTime.Now.ToShortDateString();
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    return new TTReportObject[] { MATERIALTYPE1,TOTALCENSUSFROMPREVIOUSMONTH,TOTALNEWCOMES,GRANDTOTAL1,TOTALHEKFROMMAINTENANCE,GRANDTOTAL3,TOTALPROCESSING,TOTALCIRCULATING,PrintDate1111,NewField3,NewField4};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    TOTALCENSUSFROMPREVIOUSMONTH.CalcValue = totalCensusFromPreviousMonth.ToString();
            TOTALNEWCOMES.CalcValue = totalNewComes.ToString();
            GRANDTOTAL1.CalcValue = (totalCensusFromPreviousMonth + totalNewComes).ToString();

            TOTALHEKFROMMAINTENANCE.CalcValue = totalHEKFromMaintenance.ToString();
            GRANDTOTAL3.CalcValue = (totalHEKFromMaintenance).ToString();

            TOTALPROCESSING.CalcValue = totalProcessing.ToString();
            TOTALCIRCULATING.CalcValue = circulating.ToString();

            totalCensusFromPreviousMonth = 0;
            totalNewComes = 0;
            totalMaintenanceAtFactory = 0;
            totalTeamRequest = 0;
            totalHEKFromMaintenance = 0;
            totalHEKFromFirstCheck = 0;
            totalProcessing = 0;
            circulating = 0;
#endregion PARTA FOOTER_Script
                }
            }

#region PARTA_Methods
            public static int totalCensusFromPreviousMonth = 0, totalNewComes = 0, totalHEKFromMaintenance = 0, totalHEKFromFirstCheck = 0,
                totalMaintenanceAtFactory = 0, totalTeamRequest = 0, totalProcessing = 0,circulating=0;
#endregion PARTA_Methods
        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public MonthlyRepairListReport MyParentReport
            {
                get { return (MonthlyRepairListReport)ParentReport; }
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
            public TTReportField HEKFROMMAINTENANCE { get {return Body().HEKFROMMAINTENANCE;} }
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
                list[0] = new TTReportNqlData<Repair.GetWorkshopNameFromRepairQuery_Class>("GetWorkshopNameFromRepairQuery", Repair.GetWorkshopNameFromRepairQuery());
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
                public MonthlyRepairListReport MyParentReport
                {
                    get { return (MonthlyRepairListReport)ParentReport; }
                }
                
                public TTReportField COUNT;
                public TTReportField WORKSHOP;
                public TTReportField CENSUSFROMPREVIOUSMONTH;
                public TTReportField NEWCOMES;
                public TTReportField TOTAL1;
                public TTReportField HEKFROMMAINTENANCE;
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

                    HEKFROMMAINTENANCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 207, 0, 217, 8, false);
                    HEKFROMMAINTENANCE.Name = "HEKFROMMAINTENANCE";
                    HEKFROMMAINTENANCE.DrawStyle = DrawStyleConstants.vbSolid;
                    HEKFROMMAINTENANCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEKFROMMAINTENANCE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEKFROMMAINTENANCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEKFROMMAINTENANCE.TextFont.Name = "Arial";
                    HEKFROMMAINTENANCE.TextFont.CharSet = 162;
                    HEKFROMMAINTENANCE.Value = @"";

                    TOTAL3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 0, 227, 8, false);
                    TOTAL3.Name = "TOTAL3";
                    TOTAL3.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTAL3.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTAL3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTAL3.TextFont.Name = "Arial";
                    TOTAL3.TextFont.Bold = true;
                    TOTAL3.TextFont.CharSet = 162;
                    TOTAL3.Value = @"";

                    PROCESSING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 0, 237, 8, false);
                    PROCESSING.Name = "PROCESSING";
                    PROCESSING.DrawStyle = DrawStyleConstants.vbSolid;
                    PROCESSING.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCESSING.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PROCESSING.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROCESSING.TextFont.Name = "Arial";
                    PROCESSING.TextFont.Bold = true;
                    PROCESSING.TextFont.CharSet = 162;
                    PROCESSING.Value = @"";

                    CIRCULATING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 0, 247, 8, false);
                    CIRCULATING.Name = "CIRCULATING";
                    CIRCULATING.DrawStyle = DrawStyleConstants.vbSolid;
                    CIRCULATING.FieldType = ReportFieldTypeEnum.ftVariable;
                    CIRCULATING.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CIRCULATING.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CIRCULATING.TextFont.Name = "Arial";
                    CIRCULATING.TextFont.Bold = true;
                    CIRCULATING.TextFont.CharSet = 162;
                    CIRCULATING.Value = @"";

                    WORKSHOPID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 288, 3, 313, 8, false);
                    WORKSHOPID.Name = "WORKSHOPID";
                    WORKSHOPID.Visible = EvetHayirEnum.ehHayir;
                    WORKSHOPID.FieldType = ReportFieldTypeEnum.ftVariable;
                    WORKSHOPID.Value = @"{#WORKSHOPID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Repair.GetWorkshopNameFromRepairQuery_Class dataset_GetWorkshopNameFromRepairQuery = ParentGroup.rsGroup.GetCurrentRecord<Repair.GetWorkshopNameFromRepairQuery_Class>(0);
                    COUNT.CalcValue = ParentGroup.Counter.ToString() + @".";
                    WORKSHOP.CalcValue = @" " + (dataset_GetWorkshopNameFromRepairQuery != null ? Globals.ToStringCore(dataset_GetWorkshopNameFromRepairQuery.Workshop) : "");
                    CENSUSFROMPREVIOUSMONTH.CalcValue = @"";
                    NEWCOMES.CalcValue = @"";
                    TOTAL1.CalcValue = @"";
                    HEKFROMMAINTENANCE.CalcValue = @"";
                    TOTAL3.CalcValue = @"";
                    PROCESSING.CalcValue = @"";
                    CIRCULATING.CalcValue = @"";
                    WORKSHOPID.CalcValue = (dataset_GetWorkshopNameFromRepairQuery != null ? Globals.ToStringCore(dataset_GetWorkshopNameFromRepairQuery.Workshopid) : "");
                    return new TTReportObject[] { COUNT,WORKSHOP,CENSUSFROMPREVIOUSMONTH,NEWCOMES,TOTAL1,HEKFROMMAINTENANCE,TOTAL3,PROCESSING,CIRCULATING,WORKSHOPID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            DateTime selectedStartDate = Convert.ToDateTime(((MonthlyRepairListReport)ParentReport).RuntimeParameters.STARTDATE.ToString());
            DateTime selectedEndDate = Convert.ToDateTime(((MonthlyRepairListReport)ParentReport).RuntimeParameters.ENDDATE.ToString());
            //   BindingList<Repair.GetMonthlyRepairReportFromRepairQuery_Class> list;
            //   BindingList<Repair.GetMonthlyRepairReportFromRepairQuery_Class> donemlist;
            BindingList<Repair.GetMonthlyRepairReportFromRepairQuery_Class> donemlistdevam;
            BindingList<Repair.GetMonthlyRepairReportFromRepairQuery_Class> listUncomplated;
            
            
            int tamamlanmisHEK =0 ;
            int tamamlanmisOnalarim = 0;
            int tamamlanmisHEKDonem =0 ;
            int tamamlanmisOnalarimDonem = 0;
            int devamEdenDonem = 0;
            // int tamamlanmamisdevir = 0;
            int hekEdilen = 0;
            int onarimGoren = 0;
            int oncekiDonemDevir = 0;
            int devirEden = 0;
            
            if (WORKSHOPID.CalcValue != "")
            {
                
                
                //tamamlanmış işleri getir benim bas tr. küçük olanlar
                IList list = Repair.GetHekFromRepairQuery(ctx,new Guid(WORKSHOPID.CalcValue)," AND ENDDATE >=  TODATE('"+selectedStartDate.ToString("yyyy.MM.dd HH:mm:ss",null) + "') AND ENDDATE <= TODATE('"+selectedEndDate.ToString("yyyy.MM.dd HH:mm:ss",null) + "')  AND CURRENTSTATE IS NOT UNCOMPLETED");
                int hekCounter = 0;
                foreach (Repair rep in list)
                {
                    if(rep.RepairHEKCommisionMembers.Count > 0)
                    {
                        hekCounter++;
                    }
                }
                tamamlanmisHEK = hekCounter;
                tamamlanmisOnalarim = Convert.ToInt32(list.Count) - tamamlanmisHEK;
                
                //seçili dönemdeki tamamlanan işler
                IList  donemlist = Repair.GetHekFromRepairQuery(ctx, new Guid(WORKSHOPID.CalcValue), " AND STARTDATE <= TODATE('" + selectedStartDate.ToString("yyyy.MM.dd HH:mm:ss",null) + "') AND ENDDATE > TODATE('"+ selectedEndDate.ToString("yyyy.MM.dd HH:mm:ss",null) + "') AND CURRENTSTATE IS NOT UNCOMPLETED");
                int hekCounter2 = 0;
                foreach (Repair rep2 in donemlist)
                {
                    if(rep2.RepairHEKCommisionMembers.Count > 0)
                    {
                        hekCounter2++;
                    }
                }
                tamamlanmisHEKDonem = hekCounter2+hekCounter;
                tamamlanmisOnalarimDonem = Convert.ToInt32(donemlist.Count)- tamamlanmisHEKDonem;
                
                
                //seçili dönemdeki tamamlanmayan işler
                donemlistdevam = Repair.GetMonthlyRepairReportFromRepairQuery(ctx, new Guid(WORKSHOPID.CalcValue), "AND STARTDATE <= TODATE('" + selectedStartDate.ToString("yyyy.MM.dd HH:mm:ss",null) + "') AND ENDDATE > TODATE('"+ selectedEndDate.ToString("yyyy.MM.dd HH:mm:ss",null) + "') AND CURRENTSTATE IS UNCOMPLETED");
                devamEdenDonem = Convert.ToInt32(donemlistdevam[0].Total);
                
                
                IList  newdonem = Repair.GetHekFromRepairQuery(ctx, new Guid(WORKSHOPID.CalcValue), " AND STARTDATE <= TODATE('" + selectedStartDate.ToString("yyyy.MM.dd HH:mm:ss",null) + "') AND ENDDATE > TODATE('"+ selectedEndDate.ToString("yyyy.MM.dd HH:mm:ss",null) + "')");
                
                NEWCOMES.CalcValue = newdonem.Count.ToString();
                PARTAGroup.totalNewComes = PARTAGroup.totalNewComes + Convert.ToInt32(newdonem.Count);
                
                //tamamlanmamış işler seçilen tarihden sonra başlamış ve bitmemiş
                listUncomplated = Repair.GetMonthlyRepairReportFromRepairQuery(ctx,new Guid(WORKSHOPID.CalcValue)," AND STARTDATE < TODATE('"+ selectedStartDate.ToString("yyyy.MM.dd HH:mm:ss",null) + "') AND CURRENTSTATE IS UNCOMPLETED");
                //önceki dönemden devreden sayısı
                oncekiDonemDevir = Convert.ToInt32(listUncomplated[0].Total);
                CENSUSFROMPREVIOUSMONTH.CalcValue = oncekiDonemDevir.ToString();
                PARTAGroup.totalCensusFromPreviousMonth = PARTAGroup.totalCensusFromPreviousMonth + Convert.ToInt32(listUncomplated[0].Total);
                //NEWCOMES.CalcValue = (devamEdenDonem + Convert.ToInt32(listUncomplated[0].Total)).ToString();//yeni gelenler
                
                TOTAL1.CalcValue = ((devamEdenDonem + Convert.ToInt32(donemlist.Count))+oncekiDonemDevir).ToString();
                
                //toplam dönem içindeki hek sayısı
                hekEdilen = tamamlanmisHEK +  tamamlanmisHEKDonem;
                HEKFROMMAINTENANCE.CalcValue = hekEdilen.ToString();
                PARTAGroup.totalHEKFromMaintenance = PARTAGroup.totalHEKFromMaintenance + hekEdilen;
                
                TOTAL3.CalcValue = hekEdilen.ToString();
                
                //toplam işlem gören
                onarimGoren = tamamlanmisOnalarim + tamamlanmisOnalarimDonem;
                
                if(onarimGoren < 0)
                    onarimGoren = 0;
                
                PROCESSING.CalcValue = onarimGoren.ToString();
                PARTAGroup.totalProcessing = PARTAGroup.totalProcessing + onarimGoren;
                
                
                //sonraki döneme devir edeceklerin sayısı
                devirEden = oncekiDonemDevir + devamEdenDonem;
                //CIRCULATING.CalcValue = devirEden.ToString();

                int cir = ((((devamEdenDonem + Convert.ToInt32(donemlist.Count))+oncekiDonemDevir))-(onarimGoren-hekEdilen));
                if(cir < 0)
                    cir= 0;
                
                CIRCULATING.CalcValue = cir.ToString();
                PARTAGroup.circulating = PARTAGroup.circulating + Convert.ToInt32(CIRCULATING.CalcValue);
                
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

        public MonthlyRepairListReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "MONTHLYREPAIRLISTREPORT";
            Caption = "Tarihler Arası Onarım Listesi Raporu (XXXXXX İçin)";
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