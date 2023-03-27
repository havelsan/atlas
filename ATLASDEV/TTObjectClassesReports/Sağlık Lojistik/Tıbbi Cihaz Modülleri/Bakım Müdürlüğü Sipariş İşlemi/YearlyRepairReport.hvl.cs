
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
    /// Yıllık Onarım Raporu
    /// </summary>
    public partial class YearlyRepairReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string YEAR = (string)TTObjectDefManager.Instance.DataTypes["String_4"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public YearlyRepairReport MyParentReport
            {
                get { return (YearlyRepairReport)ParentReport; }
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
            public TTReportField YEAR { get {return Header().YEAR;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField OLDYEAR { get {return Header().OLDYEAR;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NEWYEAR { get {return Header().NEWYEAR;} }
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
            public TTReportField NewField1112 { get {return Header().NewField1112;} }
            public TTReportField MATERIALTYPE1 { get {return Footer().MATERIALTYPE1;} }
            public TTReportField TOTALCENSUSFROMPREVIOUSYEAR { get {return Footer().TOTALCENSUSFROMPREVIOUSYEAR;} }
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
                public YearlyRepairReport MyParentReport
                {
                    get { return (YearlyRepairReport)ParentReport; }
                }
                
                public TTReportField HOSPITAL;
                public TTReportField REPORTNAME;
                public TTReportField YEAR;
                public TTReportField NewField1;
                public TTReportField OLDYEAR;
                public TTReportField NewField122;
                public TTReportField NewField11;
                public TTReportField NEWYEAR;
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
                public TTReportField NewField1112; 
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

                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 27, 287, 34, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 11;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"YILLIK ONARIM RAPORU";

                    YEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 34, 287, 41, false);
                    YEAR.Name = "YEAR";
                    YEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    YEAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YEAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YEAR.TextFont.Name = "Arial";
                    YEAR.TextFont.Size = 11;
                    YEAR.TextFont.Bold = true;
                    YEAR.TextFont.CharSet = 162;
                    YEAR.Value = @"01.01.{@YEAR@} - 31.12.{@YEAR@}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 44, 27, 84, false);
                    NewField1.Name = "NewField1";
                    NewField1.FontAngle = 900;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"SIRA NU.";

                    OLDYEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 49, 183, 84, false);
                    OLDYEAR.Name = "OLDYEAR";
                    OLDYEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDYEAR.FontAngle = 900;
                    OLDYEAR.VertAlign = VerticalAlignmentEnum.vaBottom;
                    OLDYEAR.TextFont.Name = "Arial";
                    OLDYEAR.TextFont.Bold = true;
                    OLDYEAR.TextFont.CharSet = 162;
                    OLDYEAR.Value = @"";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 49, 187, 84, false);
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
                    NewField11.Value = @"ATÖLYELERİN İSİMLERİ";

                    NEWYEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 49, 192, 84, false);
                    NEWYEAR.Name = "NEWYEAR";
                    NEWYEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWYEAR.FontAngle = 900;
                    NEWYEAR.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NEWYEAR.TextFont.Name = "Arial";
                    NEWYEAR.TextFont.Bold = true;
                    NEWYEAR.TextFont.CharSet = 162;
                    NEWYEAR.Value = @"";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 49, 197, 84, false);
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

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 49, 204, 84, false);
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

                    NewField1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 44, 207, 49, false);
                    NewField1112.Name = "NewField1112";
                    NewField1112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1112.TextFont.Name = "Arial";
                    NewField1112.TextFont.Bold = true;
                    NewField1112.TextFont.CharSet = 162;
                    NewField1112.Value = @"ONARILACAK";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    YEAR.CalcValue = @"01.01." + MyParentReport.RuntimeParameters.YEAR.ToString() + @" - 31.12." + MyParentReport.RuntimeParameters.YEAR.ToString();
                    NewField1.CalcValue = NewField1.Value;
                    OLDYEAR.CalcValue = @"";
                    NewField122.CalcValue = NewField122.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NEWYEAR.CalcValue = @"";
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
                    NewField1112.CalcValue = NewField1112.Value;
                    HOSPITAL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { REPORTNAME,YEAR,NewField1,OLDYEAR,NewField122,NewField11,NEWYEAR,NewField1221,NewField13,NewField131,NewField132,NewField133,NewField111,NewField1131,NewField1231,NewField1331,NewField134,NewField1431,NewField11321,NewField1111,NewField1112,HOSPITAL};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    OLDYEAR.CalcValue = (Convert.ToInt32(((YearlyRepairReport)ParentReport).RuntimeParameters.YEAR) - 1).ToString() + " YILINDAN";
                    NEWYEAR.CalcValue = ((YearlyRepairReport)ParentReport).RuntimeParameters.YEAR + " YILINDA";
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public YearlyRepairReport MyParentReport
                {
                    get { return (YearlyRepairReport)ParentReport; }
                }
                
                public TTReportField MATERIALTYPE1;
                public TTReportField TOTALCENSUSFROMPREVIOUSYEAR;
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

                    TOTALCENSUSFROMPREVIOUSYEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 0, 187, 8, false);
                    TOTALCENSUSFROMPREVIOUSYEAR.Name = "TOTALCENSUSFROMPREVIOUSYEAR";
                    TOTALCENSUSFROMPREVIOUSYEAR.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALCENSUSFROMPREVIOUSYEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALCENSUSFROMPREVIOUSYEAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALCENSUSFROMPREVIOUSYEAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALCENSUSFROMPREVIOUSYEAR.TextFont.Name = "Arial";
                    TOTALCENSUSFROMPREVIOUSYEAR.TextFont.Bold = true;
                    TOTALCENSUSFROMPREVIOUSYEAR.TextFont.CharSet = 162;
                    TOTALCENSUSFROMPREVIOUSYEAR.Value = @"";

                    TOTALNEWCOMES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 0, 197, 8, false);
                    TOTALNEWCOMES.Name = "TOTALNEWCOMES";
                    TOTALNEWCOMES.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALNEWCOMES.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALNEWCOMES.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALNEWCOMES.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALNEWCOMES.TextFont.Name = "Arial";
                    TOTALNEWCOMES.TextFont.Bold = true;
                    TOTALNEWCOMES.TextFont.CharSet = 162;
                    TOTALNEWCOMES.Value = @"";

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
                    TOTALMAINTENANCEATFACTORY.Value = @"";

                    TOTALTEAMREQUEST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 0, 227, 8, false);
                    TOTALTEAMREQUEST.Name = "TOTALTEAMREQUEST";
                    TOTALTEAMREQUEST.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALTEAMREQUEST.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALTEAMREQUEST.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALTEAMREQUEST.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALTEAMREQUEST.TextFont.Name = "Arial";
                    TOTALTEAMREQUEST.TextFont.Bold = true;
                    TOTALTEAMREQUEST.TextFont.CharSet = 162;
                    TOTALTEAMREQUEST.Value = @"";

                    GRANDTOTAL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 0, 237, 8, false);
                    GRANDTOTAL2.Name = "GRANDTOTAL2";
                    GRANDTOTAL2.DrawStyle = DrawStyleConstants.vbSolid;
                    GRANDTOTAL2.FieldType = ReportFieldTypeEnum.ftVariable;
                    GRANDTOTAL2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GRANDTOTAL2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GRANDTOTAL2.TextFont.Name = "Arial";
                    GRANDTOTAL2.TextFont.Bold = true;
                    GRANDTOTAL2.TextFont.CharSet = 162;
                    GRANDTOTAL2.Value = @"";

                    TOTALHEKFROMMAINTENANCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 0, 247, 8, false);
                    TOTALHEKFROMMAINTENANCE.Name = "TOTALHEKFROMMAINTENANCE";
                    TOTALHEKFROMMAINTENANCE.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALHEKFROMMAINTENANCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALHEKFROMMAINTENANCE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALHEKFROMMAINTENANCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALHEKFROMMAINTENANCE.TextFont.Name = "Arial";
                    TOTALHEKFROMMAINTENANCE.TextFont.Bold = true;
                    TOTALHEKFROMMAINTENANCE.TextFont.CharSet = 162;
                    TOTALHEKFROMMAINTENANCE.Value = @"";

                    TOTALHEKFROMFIRSTCHECK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 0, 257, 8, false);
                    TOTALHEKFROMFIRSTCHECK.Name = "TOTALHEKFROMFIRSTCHECK";
                    TOTALHEKFROMFIRSTCHECK.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALHEKFROMFIRSTCHECK.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALHEKFROMFIRSTCHECK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALHEKFROMFIRSTCHECK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALHEKFROMFIRSTCHECK.TextFont.Name = "Arial";
                    TOTALHEKFROMFIRSTCHECK.TextFont.Bold = true;
                    TOTALHEKFROMFIRSTCHECK.TextFont.CharSet = 162;
                    TOTALHEKFROMFIRSTCHECK.Value = @"";

                    GRANDTOTAL3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 0, 267, 8, false);
                    GRANDTOTAL3.Name = "GRANDTOTAL3";
                    GRANDTOTAL3.DrawStyle = DrawStyleConstants.vbSolid;
                    GRANDTOTAL3.FieldType = ReportFieldTypeEnum.ftVariable;
                    GRANDTOTAL3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GRANDTOTAL3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GRANDTOTAL3.TextFont.Name = "Arial";
                    GRANDTOTAL3.TextFont.Bold = true;
                    GRANDTOTAL3.TextFont.CharSet = 162;
                    GRANDTOTAL3.Value = @"";

                    TOTALPROCESSING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 267, 0, 277, 8, false);
                    TOTALPROCESSING.Name = "TOTALPROCESSING";
                    TOTALPROCESSING.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALPROCESSING.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPROCESSING.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALPROCESSING.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALPROCESSING.TextFont.Name = "Arial";
                    TOTALPROCESSING.TextFont.Bold = true;
                    TOTALPROCESSING.TextFont.CharSet = 162;
                    TOTALPROCESSING.Value = @"";

                    TOTALCIRCULATING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 277, 0, 287, 8, false);
                    TOTALCIRCULATING.Name = "TOTALCIRCULATING";
                    TOTALCIRCULATING.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALCIRCULATING.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALCIRCULATING.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALCIRCULATING.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALCIRCULATING.TextFont.Name = "Arial";
                    TOTALCIRCULATING.TextFont.Bold = true;
                    TOTALCIRCULATING.TextFont.CharSet = 162;
                    TOTALCIRCULATING.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MATERIALTYPE1.CalcValue = MATERIALTYPE1.Value;
                    TOTALCENSUSFROMPREVIOUSYEAR.CalcValue = @"";
                    TOTALNEWCOMES.CalcValue = @"";
                    GRANDTOTAL1.CalcValue = @"";
                    TOTALMAINTENANCEATFACTORY.CalcValue = @"";
                    TOTALTEAMREQUEST.CalcValue = @"";
                    GRANDTOTAL2.CalcValue = @"";
                    TOTALHEKFROMMAINTENANCE.CalcValue = @"";
                    TOTALHEKFROMFIRSTCHECK.CalcValue = @"";
                    GRANDTOTAL3.CalcValue = @"";
                    TOTALPROCESSING.CalcValue = @"";
                    TOTALCIRCULATING.CalcValue = @"";
                    return new TTReportObject[] { MATERIALTYPE1,TOTALCENSUSFROMPREVIOUSYEAR,TOTALNEWCOMES,GRANDTOTAL1,TOTALMAINTENANCEATFACTORY,TOTALTEAMREQUEST,GRANDTOTAL2,TOTALHEKFROMMAINTENANCE,TOTALHEKFROMFIRSTCHECK,GRANDTOTAL3,TOTALPROCESSING,TOTALCIRCULATING};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    TOTALCENSUSFROMPREVIOUSYEAR.CalcValue = totalCensusFromPreviousYear.ToString();
            TOTALNEWCOMES.CalcValue = totalNewComes.ToString();
            GRANDTOTAL1.CalcValue = (totalCensusFromPreviousYear + totalNewComes).ToString();

            TOTALMAINTENANCEATFACTORY.CalcValue = totalMaintenanceAtFactory.ToString();
            TOTALTEAMREQUEST.CalcValue = totalTeamRequest.ToString();
            GRANDTOTAL2.CalcValue = (totalMaintenanceAtFactory + totalTeamRequest).ToString();

            TOTALHEKFROMMAINTENANCE.CalcValue = totalHEKFromMaintenance.ToString();
            TOTALHEKFROMFIRSTCHECK.CalcValue = totalHEKFromFirstCheck.ToString();
            GRANDTOTAL3.CalcValue = (totalHEKFromMaintenance + totalHEKFromFirstCheck).ToString();

            TOTALPROCESSING.CalcValue = totalProcessing.ToString();
            TOTALCIRCULATING.CalcValue = (Convert.ToInt32(GRANDTOTAL1.CalcValue) - totalProcessing).ToString();

            totalCensusFromPreviousYear = 0;
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
            public static int totalCensusFromPreviousYear = 0, totalNewComes = 0, totalHEKFromMaintenance = 0, totalHEKFromFirstCheck = 0,
                totalMaintenanceAtFactory = 0, totalTeamRequest = 0, totalProcessing = 0;
#endregion PARTA_Methods
        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public YearlyRepairReport MyParentReport
            {
                get { return (YearlyRepairReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField WORKSHOP { get {return Body().WORKSHOP;} }
            public TTReportField CENSUSFROMPREVIOUSYEAR { get {return Body().CENSUSFROMPREVIOUSYEAR;} }
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
                public YearlyRepairReport MyParentReport
                {
                    get { return (YearlyRepairReport)ParentReport; }
                }
                
                public TTReportField COUNT;
                public TTReportField WORKSHOP;
                public TTReportField CENSUSFROMPREVIOUSYEAR;
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

                    CENSUSFROMPREVIOUSYEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 0, 187, 8, false);
                    CENSUSFROMPREVIOUSYEAR.Name = "CENSUSFROMPREVIOUSYEAR";
                    CENSUSFROMPREVIOUSYEAR.DrawStyle = DrawStyleConstants.vbSolid;
                    CENSUSFROMPREVIOUSYEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    CENSUSFROMPREVIOUSYEAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CENSUSFROMPREVIOUSYEAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CENSUSFROMPREVIOUSYEAR.TextFont.Name = "Arial";
                    CENSUSFROMPREVIOUSYEAR.TextFont.CharSet = 162;
                    CENSUSFROMPREVIOUSYEAR.Value = @"";

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
                    CENSUSFROMPREVIOUSYEAR.CalcValue = @"";
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
                    return new TTReportObject[] { COUNT,WORKSHOP,CENSUSFROMPREVIOUSYEAR,NEWCOMES,TOTAL1,MAINTENANCEATFACTORY,TEAMREQUEST,TOTAL2,HEKFROMMAINTENANCE,HEKFROMFIRSTCHECK,TOTAL3,PROCESSING,CIRCULATING,WORKSHOPID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            string selectedYear = ((YearlyRepairReport)ParentReport).RuntimeParameters.YEAR;
            BindingList<MaintenanceOrder.GetMonthlyRepairReportQuery_Class> list;

            if (WORKSHOPID.CalcValue != "")
            {
                //ÖNCEKİ AYDAN DEVİR
                list = MaintenanceOrder.GetMonthlyRepairReportQuery(ctx, new Guid(WORKSHOPID.CalcValue), " AND YEAR(STARTDATE) = " + (Convert.ToInt32(selectedYear) - 1).ToString()
                                                                    + " AND CURRENTSTATE IS UNCOMPLETED AND MAINTENANCEORDERTYPE.TYPENAME IN ('Mahalinde Onarım ve Kalibrasyon', 'Fabrika Onarım')");
                CENSUSFROMPREVIOUSYEAR.CalcValue = list[0].Total.ToString();
                PARTAGroup.totalCensusFromPreviousYear = PARTAGroup.totalCensusFromPreviousYear + Convert.ToInt32(list[0].Total);
                
                //DÖNEM İÇİNDE GELEN
                list = MaintenanceOrder.GetMonthlyRepairReportQuery(ctx, new Guid(WORKSHOPID.CalcValue), " AND YEAR(STARTDATE) = " + selectedYear
                                                                    + " AND MAINTENANCEORDERTYPE.TYPENAME IN ('Mahalinde Onarım ve Kalibrasyon', 'Fabrika Onarım')");
                NEWCOMES.CalcValue = list[0].Total.ToString();
                PARTAGroup.totalNewComes = PARTAGroup.totalNewComes + Convert.ToInt32(list[0].Total);
                
                //1. TOPLAM
                TOTAL1.CalcValue = (Convert.ToInt32(CENSUSFROMPREVIOUSYEAR.CalcValue) + Convert.ToInt32(NEWCOMES.CalcValue)).ToString();
                
                //FABRİKADA ONARILAN
                list = MaintenanceOrder.GetMonthlyRepairReportQuery(ctx, new Guid(WORKSHOPID.CalcValue), " AND YEAR(STARTDATE) = " + selectedYear
                                                                    + " AND MAINTENANCEORDERTYPE.TYPENAME = 'Fabrika Onarım' AND CURRENTSTATE IS SUCCESSFUL AND (ORDERSTATUS NOT IN (2,3) OR ORDERSTATUS IS NULL)");
                MAINTENANCEATFACTORY.CalcValue = list[0].Total.ToString();
                PARTAGroup.totalMaintenanceAtFactory = PARTAGroup.totalMaintenanceAtFactory + Convert.ToInt32(list[0].Total);
                
                //SEYYAR EKİP TARAFINDAN ONARILAN
                list = list = MaintenanceOrder.GetMonthlyRepairReportQuery(ctx, new Guid(WORKSHOPID.CalcValue)," AND YEAR(STARTDATE) = " + selectedYear
                                                                           + " AND REFERTYPE = 3 AND MAINTENANCEORDERTYPE.TYPENAME = 'Mahalinde Onarım ve Kalibrasyon' AND CURRENTSTATE IS SUCCESSFUL AND (ORDERSTATUS NOT IN (2,3) OR ORDERSTATUS IS NULL)");
                TEAMREQUEST.CalcValue = list[0].Total.ToString();
                PARTAGroup.totalTeamRequest = PARTAGroup.totalTeamRequest + Convert.ToInt32(list[0].Total);
                
                //2. TOPLAM
                TOTAL2.CalcValue = (Convert.ToInt32(MAINTENANCEATFACTORY.CalcValue) + Convert.ToInt32(TEAMREQUEST.CalcValue)).ToString();

                //ONARIMDAN HEK
                list = MaintenanceOrder.GetMonthlyRepairReportQuery(ctx, new Guid(WORKSHOPID.CalcValue), " AND YEAR(STARTDATE) = " + selectedYear
                                                                    + " AND ORDERSTATUS = 3 AND CURRENTSTATE IS SUCCESSFUL AND MAINTENANCEORDERTYPE.TYPENAME IN ('Mahalinde Onarım ve Kalibrasyon', 'Fabrika Onarım')");
                HEKFROMMAINTENANCE.CalcValue = list[0].Total.ToString();
                PARTAGroup.totalHEKFromMaintenance = PARTAGroup.totalHEKFromMaintenance + Convert.ToInt32(list[0].Total);

                //İLK MUAYENEDEN HEK
                list = MaintenanceOrder.GetMonthlyRepairReportQuery(ctx, new Guid(WORKSHOPID.CalcValue), " AND YEAR(STARTDATE) = " + selectedYear
                                                                    + " AND ORDERSTATUS = 2 AND CURRENTSTATE IS SUCCESSFUL AND MAINTENANCEORDERTYPE.TYPENAME IN ('Mahalinde Onarım ve Kalibrasyon', 'Fabrika Onarım')");
                HEKFROMFIRSTCHECK.CalcValue = list[0].Total.ToString();
                PARTAGroup.totalHEKFromFirstCheck = PARTAGroup.totalHEKFromFirstCheck + Convert.ToInt32(list[0].Total);

                //3. TOPLAM
                TOTAL3.CalcValue = (Convert.ToInt32(HEKFROMMAINTENANCE.CalcValue) + Convert.ToInt32(HEKFROMFIRSTCHECK.CalcValue)).ToString();

                //İŞLEM GÖREN
                list = MaintenanceOrder.GetMonthlyRepairReportQuery(ctx, new Guid(WORKSHOPID.CalcValue), " AND YEAR(STARTDATE) = " + selectedYear
                                                                    + " AND CURRENTSTATE IS SUCCESSFUL AND MAINTENANCEORDERTYPE.TYPENAME IN ('Mahalinde Onarım ve Kalibrasyon', 'Fabrika Onarım')");
                PROCESSING.CalcValue = list[0].Total.ToString();
                PARTAGroup.totalProcessing = PARTAGroup.totalProcessing + Convert.ToInt32(list[0].Total);

                //DEVREDEN
                CIRCULATING.CalcValue = (Convert.ToInt32(TOTAL1.CalcValue) - Convert.ToInt32(PROCESSING.CalcValue)).ToString();
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

        public YearlyRepairReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("YEAR", "", "İstediğiniz Yılı Giriniz", @"", true, true, false, new Guid("c202916a-01df-4eeb-a809-96e7bfbd2bd2"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("YEAR"))
                _runtimeParameters.YEAR = (string)TTObjectDefManager.Instance.DataTypes["String_4"].ConvertValue(parameters["YEAR"]);
            Name = "YEARLYREPAIRREPORT";
            Caption = "Yıllık Onarım Raporu";
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