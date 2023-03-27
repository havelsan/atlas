
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
    /// Yıllık Onarım Listesi Raporu
    /// </summary>
    public partial class YearlyRepairListReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string STARTDATE = (string)TTObjectDefManager.Instance.DataTypes["String_4"].ConvertValue("");
            public string ENDDATE = (string)TTObjectDefManager.Instance.DataTypes["String_4"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public YearlyRepairListReport MyParentReport
            {
                get { return (YearlyRepairListReport)ParentReport; }
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
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField11221 { get {return Header().NewField11221;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField11231 { get {return Header().NewField11231;} }
            public TTReportField NewField112211 { get {return Header().NewField112211;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportShape NewLine11111 { get {return Header().NewLine11111;} }
            public TTReportShape NewLine111131 { get {return Header().NewLine111131;} }
            public TTReportField NewField111311 { get {return Header().NewField111311;} }
            public TTReportShape NewLine1111111 { get {return Header().NewLine1111111;} }
            public TTReportField NewField113311 { get {return Header().NewField113311;} }
            public TTReportField NewField11341 { get {return Header().NewField11341;} }
            public TTReportShape NewLine111141 { get {return Header().NewLine111141;} }
            public TTReportField NewField114311 { get {return Header().NewField114311;} }
            public TTReportShape NewLine1141111 { get {return Header().NewLine1141111;} }
            public TTReportShape NewLine1121 { get {return Header().NewLine1121;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportShape NewLine1131 { get {return Header().NewLine1131;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField TOPLAM { get {return Footer().TOPLAM;} }
            public TTReportField TOTALCENSUSFROMPREVIOUSMONTH { get {return Footer().TOTALCENSUSFROMPREVIOUSMONTH;} }
            public TTReportField TOTALNEWCOMES { get {return Footer().TOTALNEWCOMES;} }
            public TTReportField GRANDTOTAL1 { get {return Footer().GRANDTOTAL1;} }
            public TTReportField TOTALHEKFROMMAINTENANCE { get {return Footer().TOTALHEKFROMMAINTENANCE;} }
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
                public YearlyRepairListReport MyParentReport
                {
                    get { return (YearlyRepairListReport)ParentReport; }
                }
                
                public TTReportField HOSPITAL;
                public TTReportField REPORTNAME;
                public TTReportField MONTH;
                public TTReportField NewField111111;
                public TTReportField NewField111;
                public TTReportField NewField1121;
                public TTReportField NewField11221;
                public TTReportField NewField1111;
                public TTReportField NewField11231;
                public TTReportField NewField112211;
                public TTReportShape NewLine111;
                public TTReportField NewField1131;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine11111;
                public TTReportShape NewLine111131;
                public TTReportField NewField111311;
                public TTReportShape NewLine1111111;
                public TTReportField NewField113311;
                public TTReportField NewField11341;
                public TTReportShape NewLine111141;
                public TTReportField NewField114311;
                public TTReportShape NewLine1141111;
                public TTReportShape NewLine1121;
                public TTReportShape NewLine11;
                public TTReportShape NewLine1131;
                public TTReportShape NewLine1; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 80;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HOSPITAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 14, 252, 21, false);
                    HOSPITAL.Name = "HOSPITAL";
                    HOSPITAL.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITAL.TextFont.Name = "Arial";
                    HOSPITAL.TextFont.Size = 11;
                    HOSPITAL.TextFont.Bold = true;
                    HOSPITAL.TextFont.CharSet = 162;
                    HOSPITAL.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 21, 252, 28, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 11;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"YILLIK ONARIM LİSTESİ RAPORU";

                    MONTH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 28, 252, 35, false);
                    MONTH.Name = "MONTH";
                    MONTH.FieldType = ReportFieldTypeEnum.ftVariable;
                    MONTH.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MONTH.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MONTH.TextFont.Name = "Arial";
                    MONTH.TextFont.Size = 11;
                    MONTH.TextFont.Bold = true;
                    MONTH.TextFont.CharSet = 162;
                    MONTH.Value = @"";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 39, 232, 44, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111.TextFont.Name = "Arial";
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"HEK";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 39, 32, 79, false);
                    NewField111.Name = "NewField111";
                    NewField111.FontAngle = 900;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"SIRA NU.";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 39, 188, 79, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.FontAngle = 900;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"ÖNCEKİ YILDAN";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 39, 192, 79, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.FontAngle = 900;
                    NewField11221.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11221.TextFont.Name = "Arial";
                    NewField11221.TextFont.Bold = true;
                    NewField11221.TextFont.CharSet = 162;
                    NewField11221.Value = @"DEVİR";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 39, 182, 79, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"ATÖLYE";

                    NewField11231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 193, 39, 197, 79, false);
                    NewField11231.Name = "NewField11231";
                    NewField11231.FontAngle = 900;
                    NewField11231.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11231.TextFont.Name = "Arial";
                    NewField11231.TextFont.Bold = true;
                    NewField11231.TextFont.CharSet = 162;
                    NewField11231.Value = @"DÖNEM İÇİNDE";

                    NewField112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 197, 39, 202, 79, false);
                    NewField112211.Name = "NewField112211";
                    NewField112211.FontAngle = 900;
                    NewField112211.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField112211.TextFont.Name = "Arial";
                    NewField112211.TextFont.Bold = true;
                    NewField112211.TextFont.CharSet = 162;
                    NewField112211.Value = @"GELEN";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 192, 39, 192, 79, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 39, 209, 79, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.FontAngle = 900;
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"TOPLAM";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 202, 39, 202, 79, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 212, 39, 212, 79, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 232, 44, 232, 79, false);
                    NewLine111131.Name = "NewLine111131";
                    NewLine111131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField111311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 43, 219, 79, false);
                    NewField111311.Name = "NewField111311";
                    NewField111311.FontAngle = 900;
                    NewField111311.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField111311.TextFont.Name = "Arial";
                    NewField111311.TextFont.Bold = true;
                    NewField111311.TextFont.CharSet = 162;
                    NewField111311.Value = @"ONARIMDAN";

                    NewLine1111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 222, 44, 222, 79, false);
                    NewLine1111111.Name = "NewLine1111111";
                    NewLine1111111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField113311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 225, 43, 229, 79, false);
                    NewField113311.Name = "NewField113311";
                    NewField113311.FontAngle = 900;
                    NewField113311.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField113311.TextFont.Name = "Arial";
                    NewField113311.TextFont.Bold = true;
                    NewField113311.TextFont.CharSet = 162;
                    NewField113311.Value = @"TOPLAM";

                    NewField11341 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 39, 239, 79, false);
                    NewField11341.Name = "NewField11341";
                    NewField11341.FontAngle = 900;
                    NewField11341.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField11341.TextFont.Name = "Arial";
                    NewField11341.TextFont.Bold = true;
                    NewField11341.TextFont.CharSet = 162;
                    NewField11341.Value = @"İŞLEM GÖREN";

                    NewLine111141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 242, 39, 242, 79, false);
                    NewLine111141.Name = "NewLine111141";
                    NewLine111141.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField114311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 245, 39, 249, 79, false);
                    NewField114311.Name = "NewField114311";
                    NewField114311.FontAngle = 900;
                    NewField114311.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField114311.TextFont.Name = "Arial";
                    NewField114311.TextFont.Bold = true;
                    NewField114311.TextFont.CharSet = 162;
                    NewField114311.Value = @"DEVREDEN";

                    NewLine1141111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 252, 39, 252, 79, false);
                    NewLine1141111.Name = "NewLine1141111";
                    NewLine1141111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 25, 39, 25, 79, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 25, 79, 252, 79, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 25, 39, 252, 39, false);
                    NewLine1131.Name = "NewLine1131";
                    NewLine1131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 212, 44, 231, 44, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    MONTH.CalcValue = @"";
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField11221.CalcValue = NewField11221.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11231.CalcValue = NewField11231.Value;
                    NewField112211.CalcValue = NewField112211.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField111311.CalcValue = NewField111311.Value;
                    NewField113311.CalcValue = NewField113311.Value;
                    NewField11341.CalcValue = NewField11341.Value;
                    NewField114311.CalcValue = NewField114311.Value;
                    HOSPITAL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { REPORTNAME,MONTH,NewField111111,NewField111,NewField1121,NewField11221,NewField1111,NewField11231,NewField112211,NewField1131,NewField111311,NewField113311,NewField11341,NewField114311,HOSPITAL};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    string selectedStartDate ="01.01.";
                    string selectedEndDate ="31.12.";
                    selectedStartDate += ((YearlyRepairListReport)ParentReport).RuntimeParameters.STARTDATE.ToString();
                    selectedEndDate += ((YearlyRepairListReport)ParentReport).RuntimeParameters.ENDDATE.ToString();                
                    MONTH.CalcValue = selectedStartDate +" - "+selectedEndDate;
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public YearlyRepairListReport MyParentReport
                {
                    get { return (YearlyRepairListReport)ParentReport; }
                }
                
                public TTReportField TOPLAM;
                public TTReportField TOTALCENSUSFROMPREVIOUSMONTH;
                public TTReportField TOTALNEWCOMES;
                public TTReportField GRANDTOTAL1;
                public TTReportField TOTALHEKFROMMAINTENANCE;
                public TTReportField GRANDTOTAL3;
                public TTReportField TOTALPROCESSING;
                public TTReportField TOTALCIRCULATING; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                    TOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 0, 182, 8, false);
                    TOPLAM.Name = "TOPLAM";
                    TOPLAM.DrawStyle = DrawStyleConstants.vbSolid;
                    TOPLAM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOPLAM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOPLAM.TextFont.Name = "Arial";
                    TOPLAM.TextFont.Bold = true;
                    TOPLAM.TextFont.CharSet = 162;
                    TOPLAM.Value = @"TOPLAM";

                    TOTALCENSUSFROMPREVIOUSMONTH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 0, 192, 8, false);
                    TOTALCENSUSFROMPREVIOUSMONTH.Name = "TOTALCENSUSFROMPREVIOUSMONTH";
                    TOTALCENSUSFROMPREVIOUSMONTH.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALCENSUSFROMPREVIOUSMONTH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALCENSUSFROMPREVIOUSMONTH.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALCENSUSFROMPREVIOUSMONTH.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALCENSUSFROMPREVIOUSMONTH.TextFont.Name = "Arial";
                    TOTALCENSUSFROMPREVIOUSMONTH.TextFont.Bold = true;
                    TOTALCENSUSFROMPREVIOUSMONTH.TextFont.CharSet = 162;
                    TOTALCENSUSFROMPREVIOUSMONTH.Value = @"0";

                    TOTALNEWCOMES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 0, 202, 8, false);
                    TOTALNEWCOMES.Name = "TOTALNEWCOMES";
                    TOTALNEWCOMES.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALNEWCOMES.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALNEWCOMES.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALNEWCOMES.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALNEWCOMES.TextFont.Name = "Arial";
                    TOTALNEWCOMES.TextFont.Bold = true;
                    TOTALNEWCOMES.TextFont.CharSet = 162;
                    TOTALNEWCOMES.Value = @"0";

                    GRANDTOTAL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 0, 212, 8, false);
                    GRANDTOTAL1.Name = "GRANDTOTAL1";
                    GRANDTOTAL1.DrawStyle = DrawStyleConstants.vbSolid;
                    GRANDTOTAL1.FieldType = ReportFieldTypeEnum.ftVariable;
                    GRANDTOTAL1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GRANDTOTAL1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GRANDTOTAL1.TextFont.Name = "Arial";
                    GRANDTOTAL1.TextFont.Bold = true;
                    GRANDTOTAL1.TextFont.CharSet = 162;
                    GRANDTOTAL1.Value = @"0";

                    TOTALHEKFROMMAINTENANCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 0, 222, 8, false);
                    TOTALHEKFROMMAINTENANCE.Name = "TOTALHEKFROMMAINTENANCE";
                    TOTALHEKFROMMAINTENANCE.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALHEKFROMMAINTENANCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALHEKFROMMAINTENANCE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALHEKFROMMAINTENANCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALHEKFROMMAINTENANCE.TextFont.Name = "Arial";
                    TOTALHEKFROMMAINTENANCE.TextFont.Bold = true;
                    TOTALHEKFROMMAINTENANCE.TextFont.CharSet = 162;
                    TOTALHEKFROMMAINTENANCE.Value = @"0";

                    GRANDTOTAL3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 0, 232, 8, false);
                    GRANDTOTAL3.Name = "GRANDTOTAL3";
                    GRANDTOTAL3.DrawStyle = DrawStyleConstants.vbSolid;
                    GRANDTOTAL3.FieldType = ReportFieldTypeEnum.ftVariable;
                    GRANDTOTAL3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GRANDTOTAL3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GRANDTOTAL3.TextFont.Name = "Arial";
                    GRANDTOTAL3.TextFont.Bold = true;
                    GRANDTOTAL3.TextFont.CharSet = 162;
                    GRANDTOTAL3.Value = @"0";

                    TOTALPROCESSING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 0, 242, 8, false);
                    TOTALPROCESSING.Name = "TOTALPROCESSING";
                    TOTALPROCESSING.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALPROCESSING.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPROCESSING.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALPROCESSING.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALPROCESSING.TextFont.Name = "Arial";
                    TOTALPROCESSING.TextFont.Bold = true;
                    TOTALPROCESSING.TextFont.CharSet = 162;
                    TOTALPROCESSING.Value = @"0";

                    TOTALCIRCULATING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 242, 0, 252, 8, false);
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
                    TOPLAM.CalcValue = TOPLAM.Value;
                    TOTALCENSUSFROMPREVIOUSMONTH.CalcValue = @"0";
                    TOTALNEWCOMES.CalcValue = @"0";
                    GRANDTOTAL1.CalcValue = @"0";
                    TOTALHEKFROMMAINTENANCE.CalcValue = @"0";
                    GRANDTOTAL3.CalcValue = @"0";
                    TOTALPROCESSING.CalcValue = @"0";
                    TOTALCIRCULATING.CalcValue = @"0";
                    return new TTReportObject[] { TOPLAM,TOTALCENSUSFROMPREVIOUSMONTH,TOTALNEWCOMES,GRANDTOTAL1,TOTALHEKFROMMAINTENANCE,GRANDTOTAL3,TOTALPROCESSING,TOTALCIRCULATING};
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
            public YearlyRepairListReport MyParentReport
            {
                get { return (YearlyRepairListReport)ParentReport; }
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
            public TTReportField CURRENTDATE { get {return Body().CURRENTDATE;} }
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
                public YearlyRepairListReport MyParentReport
                {
                    get { return (YearlyRepairListReport)ParentReport; }
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
                public TTReportField CURRENTDATE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 9;
                    RepeatCount = 0;
                    
                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 0, 35, 8, false);
                    COUNT.Name = "COUNT";
                    COUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.TextFont.Name = "Arial";
                    COUNT.TextFont.Bold = true;
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{@counter@}";

                    WORKSHOP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 0, 182, 8, false);
                    WORKSHOP.Name = "WORKSHOP";
                    WORKSHOP.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKSHOP.FieldType = ReportFieldTypeEnum.ftVariable;
                    WORKSHOP.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKSHOP.TextFont.Name = "Arial";
                    WORKSHOP.TextFont.Bold = true;
                    WORKSHOP.TextFont.CharSet = 162;
                    WORKSHOP.Value = @"{#WORKSHOP#}";

                    CENSUSFROMPREVIOUSMONTH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 0, 192, 8, false);
                    CENSUSFROMPREVIOUSMONTH.Name = "CENSUSFROMPREVIOUSMONTH";
                    CENSUSFROMPREVIOUSMONTH.DrawStyle = DrawStyleConstants.vbSolid;
                    CENSUSFROMPREVIOUSMONTH.FieldType = ReportFieldTypeEnum.ftVariable;
                    CENSUSFROMPREVIOUSMONTH.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CENSUSFROMPREVIOUSMONTH.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CENSUSFROMPREVIOUSMONTH.TextFont.Name = "Arial";
                    CENSUSFROMPREVIOUSMONTH.TextFont.CharSet = 162;
                    CENSUSFROMPREVIOUSMONTH.Value = @"";

                    NEWCOMES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 0, 202, 8, false);
                    NEWCOMES.Name = "NEWCOMES";
                    NEWCOMES.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWCOMES.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWCOMES.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NEWCOMES.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEWCOMES.TextFont.Name = "Arial";
                    NEWCOMES.TextFont.CharSet = 162;
                    NEWCOMES.Value = @"";

                    TOTAL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 0, 212, 8, false);
                    TOTAL1.Name = "TOTAL1";
                    TOTAL1.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTAL1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTAL1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTAL1.TextFont.Name = "Arial";
                    TOTAL1.TextFont.Bold = true;
                    TOTAL1.TextFont.CharSet = 162;
                    TOTAL1.Value = @"";

                    HEKFROMMAINTENANCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 0, 222, 8, false);
                    HEKFROMMAINTENANCE.Name = "HEKFROMMAINTENANCE";
                    HEKFROMMAINTENANCE.DrawStyle = DrawStyleConstants.vbSolid;
                    HEKFROMMAINTENANCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEKFROMMAINTENANCE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEKFROMMAINTENANCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEKFROMMAINTENANCE.TextFont.Name = "Arial";
                    HEKFROMMAINTENANCE.TextFont.CharSet = 162;
                    HEKFROMMAINTENANCE.Value = @"";

                    TOTAL3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 0, 232, 8, false);
                    TOTAL3.Name = "TOTAL3";
                    TOTAL3.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTAL3.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTAL3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTAL3.TextFont.Name = "Arial";
                    TOTAL3.TextFont.Bold = true;
                    TOTAL3.TextFont.CharSet = 162;
                    TOTAL3.Value = @"";

                    PROCESSING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 0, 242, 8, false);
                    PROCESSING.Name = "PROCESSING";
                    PROCESSING.DrawStyle = DrawStyleConstants.vbSolid;
                    PROCESSING.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCESSING.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PROCESSING.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROCESSING.TextFont.Name = "Arial";
                    PROCESSING.TextFont.Bold = true;
                    PROCESSING.TextFont.CharSet = 162;
                    PROCESSING.Value = @"";

                    CIRCULATING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 242, 0, 252, 8, false);
                    CIRCULATING.Name = "CIRCULATING";
                    CIRCULATING.DrawStyle = DrawStyleConstants.vbSolid;
                    CIRCULATING.FieldType = ReportFieldTypeEnum.ftVariable;
                    CIRCULATING.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CIRCULATING.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CIRCULATING.TextFont.Name = "Arial";
                    CIRCULATING.TextFont.Bold = true;
                    CIRCULATING.TextFont.CharSet = 162;
                    CIRCULATING.Value = @"";

                    WORKSHOPID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 255, 1, 280, 6, false);
                    WORKSHOPID.Name = "WORKSHOPID";
                    WORKSHOPID.Visible = EvetHayirEnum.ehHayir;
                    WORKSHOPID.FieldType = ReportFieldTypeEnum.ftVariable;
                    WORKSHOPID.Value = @"{#WORKSHOPID#}";

                    CURRENTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 280, 3, 305, 8, false);
                    CURRENTDATE.Name = "CURRENTDATE";
                    CURRENTDATE.Visible = EvetHayirEnum.ehHayir;
                    CURRENTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CURRENTDATE.Value = @"{@printdate@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Repair.GetWorkshopNameFromRepairQuery_Class dataset_GetWorkshopNameFromRepairQuery = ParentGroup.rsGroup.GetCurrentRecord<Repair.GetWorkshopNameFromRepairQuery_Class>(0);
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    WORKSHOP.CalcValue = (dataset_GetWorkshopNameFromRepairQuery != null ? Globals.ToStringCore(dataset_GetWorkshopNameFromRepairQuery.Workshop) : "");
                    CENSUSFROMPREVIOUSMONTH.CalcValue = @"";
                    NEWCOMES.CalcValue = @"";
                    TOTAL1.CalcValue = @"";
                    HEKFROMMAINTENANCE.CalcValue = @"";
                    TOTAL3.CalcValue = @"";
                    PROCESSING.CalcValue = @"";
                    CIRCULATING.CalcValue = @"";
                    WORKSHOPID.CalcValue = (dataset_GetWorkshopNameFromRepairQuery != null ? Globals.ToStringCore(dataset_GetWorkshopNameFromRepairQuery.Workshopid) : "");
                    CURRENTDATE.CalcValue = DateTime.Now.ToShortDateString();
                    return new TTReportObject[] { COUNT,WORKSHOP,CENSUSFROMPREVIOUSMONTH,NEWCOMES,TOTAL1,HEKFROMMAINTENANCE,TOTAL3,PROCESSING,CIRCULATING,WORKSHOPID,CURRENTDATE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);
                    string selectedStartDate = ((YearlyRepairListReport)ParentReport).RuntimeParameters.STARTDATE.ToString();
                    string selectedEndDate = ((YearlyRepairListReport)ParentReport).RuntimeParameters.ENDDATE.ToString();
                    BindingList<Repair.GetMonthlyRepairReportFromRepairQuery_Class> list;
                   // string hekID = "3afb41ab-805b-4277-83dc-e5793b6407f4";
                    //Guid hekStateDefId = new Guid(hekID);
                    Guid hekStateDefId = Repair.States.HEK;
                    int startDate = Convert.ToInt32(selectedStartDate);
                    int endDate = Convert.ToInt32(selectedEndDate);
                    int totalCensus=0;
                    int totalNewComesMain = 0;
                    int total1 = 0;
                    int total3 = 0;
                    int hekRepair = 0;
                    int process = 0;
                    int circulatedRepair = 0;

                    if (WORKSHOPID.CalcValue != "")
                    {
                       
                       while(startDate<=endDate)
                       {
                        
                        //ÖNCEKİ AYDAN DEVİR
                        list = Repair.GetMonthlyRepairReportFromRepairQuery(ctx, new Guid(WORKSHOPID.CalcValue), "AND YEAR(STARTDATE) = " + (startDate - 1).ToString()
                                                                                + " AND CURRENTSTATE IS UNCOMPLETED");
                                             
                        totalCensus += Convert.ToInt32(list[0].Total);
                        CENSUSFROMPREVIOUSMONTH.CalcValue = totalCensus.ToString();
                        PARTAGroup.totalCensusFromPreviousMonth = PARTAGroup.totalCensusFromPreviousMonth + Convert.ToInt32(list[0].Total);

                        //DÖNEM İÇİNDE GELEN
                        list = Repair.GetMonthlyRepairReportFromRepairQuery(ctx, new Guid(WORKSHOPID.CalcValue), "AND YEAR(STARTDATE) = " + startDate.ToString());
                                                                           
                        totalNewComesMain += Convert.ToInt32(list[0].Total);
                        NEWCOMES.CalcValue =totalNewComesMain.ToString();
                        PARTAGroup.totalNewComes = PARTAGroup.totalNewComes + Convert.ToInt32(list[0].Total);
                 
                         //1. TOPLAM
                       total1 += totalCensus + totalNewComesMain;
                       TOTAL1.CalcValue = (Convert.ToInt32(CENSUSFROMPREVIOUSMONTH.CalcValue) + Convert.ToInt32(NEWCOMES.CalcValue)).ToString();


                        //ONARIMDAN HEK
                        IBindingList list2 = Repair.GetHekFromRepairQuery(ctx,new Guid(WORKSHOPID.CalcValue), " AND YEAR(ENDDATE) = " + startDate.ToString()); 
                        int hekCount = 0;
                        if(list2 != null)
                        {
                            foreach (Repair rep in list2)
                            {
                            
                                foreach (TTObjectState objectState in rep.GetStateHistory())
                                {
                                    if ((objectState.StateDefID.Equals(hekStateDefId)))
                                        hekCount++;
                                }

                            }
                        }
                            
                        hekRepair += hekCount;
                        HEKFROMMAINTENANCE.CalcValue = hekRepair.ToString();
                        PARTAGroup.totalHEKFromMaintenance = PARTAGroup.totalHEKFromMaintenance + hekCount;
                        

                        //3. TOPLAM
                        total3 =hekRepair;
                        TOTAL3.CalcValue = hekRepair.ToString();


                        //İŞLEM GÖREN
                        list = Repair.GetMonthlyRepairReportFromRepairQuery(ctx, new Guid(WORKSHOPID.CalcValue), "AND YEAR(ENDDATE) = " + startDate.ToString()
                                                                            + " AND CURRENTSTATE IS SUCCESSFUL");
                        process += Convert.ToInt32(list[0].Total);
                        PROCESSING.CalcValue = process.ToString();
                        PARTAGroup.totalProcessing = PARTAGroup.totalProcessing + Convert.ToInt32(list[0].Total);

                        //DEVREDEN
                        circulatedRepair += total1 - process;
                        CIRCULATING.CalcValue = (Convert.ToInt32(TOTAL1.CalcValue) - Convert.ToInt32(PROCESSING.CalcValue)).ToString();
               
                        startDate = startDate + 1;
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

        public YearlyRepairListReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Yılı", @"", true, true, false, new Guid("c202916a-01df-4eeb-a809-96e7bfbd2bd2"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Yılı", @"", true, true, false, new Guid("c202916a-01df-4eeb-a809-96e7bfbd2bd2"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (string)TTObjectDefManager.Instance.DataTypes["String_4"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (string)TTObjectDefManager.Instance.DataTypes["String_4"].ConvertValue(parameters["ENDDATE"]);
            Name = "YEARLYREPAIRLISTREPORT";
            Caption = "Yıllık Onarım Listesi Raporu";
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