
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
    /// Malzeme Mevcudu Raporu
    /// </summary>
    public partial class MaterialInheldReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string STOCKCARDID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public MaterialInheldReport MyParentReport
            {
                get { return (MaterialInheldReport)ParentReport; }
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
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
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
                public MaterialInheldReport MyParentReport
                {
                    get { return (MaterialInheldReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField NewField1; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 21;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 1, 254, 21, false);
                    LOGO.Name = "LOGO";
                    LOGO.Visible = EvetHayirEnum.ehHayir;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 0, 153, 20, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 12;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"MALZEME MEVCUDU RAPORU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = LOGO.Value;
                    NewField1.CalcValue = NewField1.Value;
                    return new TTReportObject[] { LOGO,NewField1};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public MaterialInheldReport MyParentReport
                {
                    get { return (MaterialInheldReport)ParentReport; }
                }
                
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportField PrintDate;
                public TTReportShape NewLine1; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 0, 95, 5, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser.ExcelCol = 1;
                    CurrentUser.TextFont.Name = "Arial";
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 170, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.ExcelCol = 2;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 25, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.ExcelCol = 1;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 170, 0, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    CurrentUser.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PageNumber,PrintDate,CurrentUser};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public MaterialInheldReport MyParentReport
            {
                get { return (MaterialInheldReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField NewField9 { get {return Header().NewField9;} }
            public TTReportField NewField10 { get {return Header().NewField10;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NATOSTOCKNO { get {return Header().NATOSTOCKNO;} }
            public TTReportField CARDNAME { get {return Header().CARDNAME;} }
            public TTReportField ORDERNO { get {return Header().ORDERNO;} }
            public TTReportField PARENTCLASS { get {return Header().PARENTCLASS;} }
            public TTReportField CLASS { get {return Header().CLASS;} }
            public TTReportField RenProduction { get {return Header().RenProduction;} }
            public TTReportField RenRepair { get {return Header().RenRepair;} }
            public TTReportField ProductionCheck { get {return Header().ProductionCheck;} }
            public TTReportField RepairCheck { get {return Header().RepairCheck;} }
            public TTReportField REPAIRPRODUCTION { get {return Header().REPAIRPRODUCTION;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField TotalInheld { get {return Footer().TotalInheld;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
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
                public MaterialInheldReport MyParentReport
                {
                    get { return (MaterialInheldReport)ParentReport; }
                }
                
                public TTReportField NewField14;
                public TTReportField NewField13;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField NewField9;
                public TTReportField NewField10;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportShape NewLine1;
                public TTReportField NATOSTOCKNO;
                public TTReportField CARDNAME;
                public TTReportField ORDERNO;
                public TTReportField PARENTCLASS;
                public TTReportField CLASS;
                public TTReportField RenProduction;
                public TTReportField RenRepair;
                public TTReportField ProductionCheck;
                public TTReportField RepairCheck;
                public TTReportField REPAIRPRODUCTION; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 46;
                    RepeatCount = 0;
                    
                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 40, 170, 45, false);
                    NewField14.Name = "NewField14";
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.ExcelCol = 2;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Size = 11;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Miktar";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 40, 25, 45, false);
                    NewField13.Name = "NewField13";
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.ExcelCol = 1;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Size = 11;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Depo İsmi";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 28, 5, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"NATO Stok Nu.";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 28, 10, false);
                    NewField2.Name = "NewField2";
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Kart İsmi";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 10, 28, 15, false);
                    NewField3.Name = "NewField3";
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Sıra Nu.";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 28, 20, false);
                    NewField4.Name = "NewField4";
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Ana Sınıfı";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 20, 28, 25, false);
                    NewField5.Name = "NewField5";
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"Sınıfı";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 25, 28, 30, false);
                    NewField6.Name = "NewField6";
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Name = "Arial";
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"Reni";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 0, 29, 5, false);
                    NewField7.Name = "NewField7";
                    NewField7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.TextFont.Name = "Arial";
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @":";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 5, 29, 10, false);
                    NewField8.Name = "NewField8";
                    NewField8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField8.TextFont.Name = "Arial";
                    NewField8.TextFont.Bold = true;
                    NewField8.TextFont.CharSet = 162;
                    NewField8.Value = @":";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 10, 29, 15, false);
                    NewField9.Name = "NewField9";
                    NewField9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField9.TextFont.Name = "Arial";
                    NewField9.TextFont.Bold = true;
                    NewField9.TextFont.CharSet = 162;
                    NewField9.Value = @":";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 15, 29, 20, false);
                    NewField10.Name = "NewField10";
                    NewField10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField10.TextFont.Name = "Arial";
                    NewField10.TextFont.Bold = true;
                    NewField10.TextFont.CharSet = 162;
                    NewField10.Value = @":";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 20, 29, 25, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @":";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 25, 29, 30, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @":";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 45, 170, 45, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 0, 170, 5, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NATOSTOCKNO.NoClip = EvetHayirEnum.ehEvet;
                    NATOSTOCKNO.ObjectDefName = "StockCard";
                    NATOSTOCKNO.DataMember = "NATOSTOCKNO";
                    NATOSTOCKNO.TextFont.Name = "Arial";
                    NATOSTOCKNO.TextFont.CharSet = 162;
                    NATOSTOCKNO.Value = @"{@STOCKCARDID@}";

                    CARDNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 5, 170, 10, false);
                    CARDNAME.Name = "CARDNAME";
                    CARDNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CARDNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CARDNAME.NoClip = EvetHayirEnum.ehEvet;
                    CARDNAME.ObjectDefName = "StockCard";
                    CARDNAME.DataMember = "NAME";
                    CARDNAME.TextFont.Name = "Arial";
                    CARDNAME.TextFont.CharSet = 162;
                    CARDNAME.Value = @"{@STOCKCARDID@}";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 10, 170, 15, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.ObjectDefName = "StockCard";
                    ORDERNO.DataMember = "CARDORDERNO";
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{@STOCKCARDID@}";

                    PARENTCLASS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 15, 170, 20, false);
                    PARENTCLASS.Name = "PARENTCLASS";
                    PARENTCLASS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PARENTCLASS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARENTCLASS.NoClip = EvetHayirEnum.ehEvet;
                    PARENTCLASS.ObjectDefName = "StockCard";
                    PARENTCLASS.DataMember = "STOCKCARDCLASS.PARENTSTOCKCARDCLASS.NAME";
                    PARENTCLASS.TextFont.Name = "Arial";
                    PARENTCLASS.TextFont.CharSet = 162;
                    PARENTCLASS.Value = @"{@STOCKCARDID@}";

                    CLASS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 20, 170, 25, false);
                    CLASS.Name = "CLASS";
                    CLASS.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLASS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CLASS.NoClip = EvetHayirEnum.ehEvet;
                    CLASS.ObjectDefName = "StockCard";
                    CLASS.DataMember = "STOCKCARDCLASS.NAME";
                    CLASS.TextFont.Name = "Arial";
                    CLASS.TextFont.CharSet = 162;
                    CLASS.Value = @"{@STOCKCARDID@}";

                    RenProduction = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 2, 230, 7, false);
                    RenProduction.Name = "RenProduction";
                    RenProduction.Visible = EvetHayirEnum.ehHayir;
                    RenProduction.FieldType = ReportFieldTypeEnum.ftVariable;
                    RenProduction.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RenProduction.TextFont.Name = "Arial";
                    RenProduction.TextFont.CharSet = 162;
                    RenProduction.Value = @"";

                    RenRepair = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 2, 256, 7, false);
                    RenRepair.Name = "RenRepair";
                    RenRepair.Visible = EvetHayirEnum.ehHayir;
                    RenRepair.FieldType = ReportFieldTypeEnum.ftVariable;
                    RenRepair.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RenRepair.TextFont.Name = "Arial";
                    RenRepair.TextFont.CharSet = 162;
                    RenRepair.Value = @"";

                    ProductionCheck = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 14, 245, 19, false);
                    ProductionCheck.Name = "ProductionCheck";
                    ProductionCheck.Visible = EvetHayirEnum.ehHayir;
                    ProductionCheck.FieldType = ReportFieldTypeEnum.ftVariable;
                    ProductionCheck.ObjectDefName = "StockCard";
                    ProductionCheck.DataMember = "PRODUCTIONCHECKBOX";
                    ProductionCheck.Value = @"{@STOCKCARDID@}";

                    RepairCheck = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 27, 244, 32, false);
                    RepairCheck.Name = "RepairCheck";
                    RepairCheck.Visible = EvetHayirEnum.ehHayir;
                    RepairCheck.FieldType = ReportFieldTypeEnum.ftVariable;
                    RepairCheck.ObjectDefName = "StockCard";
                    RepairCheck.DataMember = "REPAIRCHECKBOX";
                    RepairCheck.Value = @"{@STOCKCARDID@}";

                    REPAIRPRODUCTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 25, 170, 30, false);
                    REPAIRPRODUCTION.Name = "REPAIRPRODUCTION";
                    REPAIRPRODUCTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPAIRPRODUCTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPAIRPRODUCTION.NoClip = EvetHayirEnum.ehEvet;
                    REPAIRPRODUCTION.TextFont.Name = "Arial";
                    REPAIRPRODUCTION.TextFont.CharSet = 162;
                    REPAIRPRODUCTION.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField14.CalcValue = NewField14.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField9.CalcValue = NewField9.Value;
                    NewField10.CalcValue = NewField10.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NATOSTOCKNO.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDID.ToString();
                    NATOSTOCKNO.PostFieldValueCalculation();
                    CARDNAME.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDID.ToString();
                    CARDNAME.PostFieldValueCalculation();
                    ORDERNO.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDID.ToString();
                    ORDERNO.PostFieldValueCalculation();
                    PARENTCLASS.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDID.ToString();
                    PARENTCLASS.PostFieldValueCalculation();
                    CLASS.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDID.ToString();
                    CLASS.PostFieldValueCalculation();
                    RenProduction.CalcValue = @"";
                    RenRepair.CalcValue = @"";
                    ProductionCheck.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDID.ToString();
                    ProductionCheck.PostFieldValueCalculation();
                    RepairCheck.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDID.ToString();
                    RepairCheck.PostFieldValueCalculation();
                    REPAIRPRODUCTION.CalcValue = @"";
                    return new TTReportObject[] { NewField14,NewField13,NewField1,NewField2,NewField3,NewField4,NewField5,NewField6,NewField7,NewField8,NewField9,NewField10,NewField11,NewField12,NATOSTOCKNO,CARDNAME,ORDERNO,PARENTCLASS,CLASS,RenProduction,RenRepair,ProductionCheck,RepairCheck,REPAIRPRODUCTION};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    if (this.ProductionCheck.CalcValue == "True")
                        this.RenProduction.CalcValue = "Sarf Edilir";
                    else
                        this.RenProduction.CalcValue = "Sarf Edilmez";

                    if (this.RepairCheck.CalcValue == "True")
                        this.RenRepair.CalcValue = "Tamir Edilir";
                    else
                        this.RenRepair.CalcValue = "Tamir Edilmez";

                    REPAIRPRODUCTION.CalcValue = RenProduction.CalcValue + " / " + RenRepair.CalcValue;
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public MaterialInheldReport MyParentReport
                {
                    get { return (MaterialInheldReport)ParentReport; }
                }
                
                public TTReportField NewField15;
                public TTReportField TotalInheld;
                public TTReportShape NewLine11; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    RepeatCount = 0;
                    
                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 25, 6, false);
                    NewField15.Name = "NewField15";
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.ExcelCol = 1;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"Toplam";

                    TotalInheld = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 1, 171, 6, false);
                    TotalInheld.Name = "TotalInheld";
                    TotalInheld.FieldType = ReportFieldTypeEnum.ftVariable;
                    TotalInheld.TextFormat = @"#,###.#0";
                    TotalInheld.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TotalInheld.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TotalInheld.ExcelCol = 2;
                    TotalInheld.TextFont.Name = "Arial";
                    TotalInheld.TextFont.CharSet = 162;
                    TotalInheld.Value = @"{@sumof(Inheld)@}";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 170, 0, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField15.CalcValue = NewField15.Value;
                    TotalInheld.CalcValue = ParentGroup.FieldSums["Inheld"].Value.ToString();;
                    return new TTReportObject[] { NewField15,TotalInheld};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public MaterialInheldReport MyParentReport
            {
                get { return (MaterialInheldReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField STORENAME { get {return Body().STORENAME;} }
            public TTReportField Inheld { get {return Body().Inheld;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
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
                list[0] = new TTReportNqlData<Material.GetMaterialInheldReportQuery_Class>("GetMaterialInheldReportQuery", Material.GetMaterialInheldReportQuery((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDID)));
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
                public MaterialInheldReport MyParentReport
                {
                    get { return (MaterialInheldReport)ParentReport; }
                }
                
                public TTReportField STORENAME;
                public TTReportField Inheld;
                public TTReportShape NewLine1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    STORENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 141, 6, false);
                    STORENAME.Name = "STORENAME";
                    STORENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STORENAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STORENAME.WordBreak = EvetHayirEnum.ehEvet;
                    STORENAME.ExcelCol = 1;
                    STORENAME.TextFont.Name = "Arial";
                    STORENAME.TextFont.CharSet = 162;
                    STORENAME.Value = @"{#STORENAME#}";

                    Inheld = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 1, 170, 6, false);
                    Inheld.Name = "Inheld";
                    Inheld.FieldType = ReportFieldTypeEnum.ftVariable;
                    Inheld.TextFormat = @"#,###.#0";
                    Inheld.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Inheld.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Inheld.ExcelCol = 2;
                    Inheld.TextFont.Name = "Arial";
                    Inheld.TextFont.CharSet = 162;
                    Inheld.Value = @"{#INHELD#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 7, 170, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Material.GetMaterialInheldReportQuery_Class dataset_GetMaterialInheldReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Material.GetMaterialInheldReportQuery_Class>(0);
                    STORENAME.CalcValue = (dataset_GetMaterialInheldReportQuery != null ? Globals.ToStringCore(dataset_GetMaterialInheldReportQuery.Storename) : "");
                    Inheld.CalcValue = (dataset_GetMaterialInheldReportQuery != null ? Globals.ToStringCore(dataset_GetMaterialInheldReportQuery.Inheld) : "");
                    return new TTReportObject[] { STORENAME,Inheld};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    this.ParentReport.ChartDataTable.Rows.Add(STORENAME.CalcValue, Convert.ToDouble(Inheld.CalcValue));
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

        public MaterialInheldReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STOCKCARDID", "", "Stok Kartı Seçiniz", @"", true, true, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
            reportParameter.ListDefID = new Guid("e8c3b02e-4a08-4c98-bfd0-15d84fafb295");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STOCKCARDID"))
                _runtimeParameters.STOCKCARDID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["STOCKCARDID"]);
            Name = "MATERIALINHELDREPORT";
            Caption = "Malzeme Mevcudu Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
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


        protected override void RunPreScript()
        {
#region MATERIALINHELDREPORT_PreScript
            this.ChartDataTable = new DataTable();
            this.ChartDataTable.Columns.Add("Depo Adı", typeof(string));
            this.ChartDataTable.Columns.Add("Mevcut", typeof(double));
#endregion MATERIALINHELDREPORT_PreScript
        }
    }
}