
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
    /// Malzeme istekleri (Depolara Göre)
    /// </summary>
    public partial class MaterialRequestForStoresReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string STOCKCARDID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string TERMID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public MaterialRequestForStoresReport MyParentReport
            {
                get { return (MaterialRequestForStoresReport)ParentReport; }
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
            public TTReportField ReportName { get {return Header().ReportName;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField113 { get {return Header().NewField113;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField1311 { get {return Header().NewField1311;} }
            public TTReportField NewField142 { get {return Header().NewField142;} }
            public TTReportField NewField1312 { get {return Header().NewField1312;} }
            public TTReportField NATOStockNO { get {return Header().NATOStockNO;} }
            public TTReportField CardName { get {return Header().CardName;} }
            public TTReportField OrderNO { get {return Header().OrderNO;} }
            public TTReportField MainClassName { get {return Header().MainClassName;} }
            public TTReportField ClassName { get {return Header().ClassName;} }
            public TTReportField RenProduction { get {return Header().RenProduction;} }
            public TTReportField RenRepair { get {return Header().RenRepair;} }
            public TTReportField ProductionCheck { get {return Header().ProductionCheck;} }
            public TTReportField RepairCheck { get {return Header().RepairCheck;} }
            public TTReportField Ren { get {return Header().Ren;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
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
                public MaterialRequestForStoresReport MyParentReport
                {
                    get { return (MaterialRequestForStoresReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField ReportName;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField111;
                public TTReportField NewField13;
                public TTReportField NewField112;
                public TTReportField NewField14;
                public TTReportField NewField113;
                public TTReportField NewField141;
                public TTReportField NewField1311;
                public TTReportField NewField142;
                public TTReportField NewField1312;
                public TTReportField NATOStockNO;
                public TTReportField CardName;
                public TTReportField OrderNO;
                public TTReportField MainClassName;
                public TTReportField ClassName;
                public TTReportField RenProduction;
                public TTReportField RenRepair;
                public TTReportField ProductionCheck;
                public TTReportField RepairCheck;
                public TTReportField Ren; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 55;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.Value = @"";

                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 170, 20, false);
                    ReportName.Name = "ReportName";
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Size = 15;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"MALZEME İSTEKLERİ (DEPOLARA GÖRE)";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 2, 242, 7, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.ObjectDefName = "AccountingTerm";
                    STARTDATE.DataMember = "STARTDATE";
                    STARTDATE.Value = @"{@TERMID@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 9, 242, 14, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.ObjectDefName = "AccountingTerm";
                    ENDDATE.DataMember = "ENDDATE";
                    ENDDATE.Value = @"{@TERMID@}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 24, 21, 29, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"NATO Stok Nu.";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 29, 21, 34, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Kart İsmi";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 44, 21, 49, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Sınıfı";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 49, 21, 54, false);
                    NewField111.Name = "NewField111";
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Reni";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 34, 21, 39, false);
                    NewField13.Name = "NewField13";
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Sıra Nu.";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 39, 21, 44, false);
                    NewField112.Name = "NewField112";
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"Ana Sınıfı";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 24, 22, 29, false);
                    NewField14.Name = "NewField14";
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @":";

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 29, 22, 34, false);
                    NewField113.Name = "NewField113";
                    NewField113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113.TextFont.Bold = true;
                    NewField113.TextFont.CharSet = 162;
                    NewField113.Value = @":";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 34, 22, 39, false);
                    NewField141.Name = "NewField141";
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @":";

                    NewField1311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 39, 22, 44, false);
                    NewField1311.Name = "NewField1311";
                    NewField1311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1311.TextFont.Bold = true;
                    NewField1311.TextFont.CharSet = 162;
                    NewField1311.Value = @":";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 44, 22, 49, false);
                    NewField142.Name = "NewField142";
                    NewField142.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField142.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField142.TextFont.Bold = true;
                    NewField142.TextFont.CharSet = 162;
                    NewField142.Value = @":";

                    NewField1312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 49, 22, 54, false);
                    NewField1312.Name = "NewField1312";
                    NewField1312.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1312.TextFont.Bold = true;
                    NewField1312.TextFont.CharSet = 162;
                    NewField1312.Value = @":";

                    NATOStockNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 24, 47, 29, false);
                    NATOStockNO.Name = "NATOStockNO";
                    NATOStockNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOStockNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NATOStockNO.ObjectDefName = "StockCard";
                    NATOStockNO.DataMember = "NATOSTOCKNO";
                    NATOStockNO.Value = @"{@STOCKCARDID@}";

                    CardName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 29, 47, 34, false);
                    CardName.Name = "CardName";
                    CardName.FieldType = ReportFieldTypeEnum.ftVariable;
                    CardName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    CardName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CardName.NoClip = EvetHayirEnum.ehEvet;
                    CardName.ObjectDefName = "StockCard";
                    CardName.DataMember = "NAME";
                    CardName.Value = @"{@STOCKCARDID@}";

                    OrderNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 34, 47, 39, false);
                    OrderNO.Name = "OrderNO";
                    OrderNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    OrderNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OrderNO.ObjectDefName = "StockCard";
                    OrderNO.DataMember = "CARDORDERNO";
                    OrderNO.Value = @"{@STOCKCARDID@}";

                    MainClassName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 39, 47, 44, false);
                    MainClassName.Name = "MainClassName";
                    MainClassName.FieldType = ReportFieldTypeEnum.ftVariable;
                    MainClassName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    MainClassName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MainClassName.NoClip = EvetHayirEnum.ehEvet;
                    MainClassName.ObjectDefName = "StockCard";
                    MainClassName.DataMember = "STOCKCARDCLASS.PARENTSTOCKCARDCLASS.NAME";
                    MainClassName.Value = @"{@STOCKCARDID@}";

                    ClassName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 44, 47, 49, false);
                    ClassName.Name = "ClassName";
                    ClassName.FieldType = ReportFieldTypeEnum.ftVariable;
                    ClassName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ClassName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ClassName.NoClip = EvetHayirEnum.ehEvet;
                    ClassName.ObjectDefName = "StockCard";
                    ClassName.DataMember = "STOCKCARDCLASS.NAME";
                    ClassName.Value = @"{@STOCKCARDID@}";

                    RenProduction = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 31, 234, 36, false);
                    RenProduction.Name = "RenProduction";
                    RenProduction.Visible = EvetHayirEnum.ehHayir;
                    RenProduction.FieldType = ReportFieldTypeEnum.ftVariable;
                    RenProduction.CaseFormat = CaseFormatEnum.fcTitleCase;
                    RenProduction.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RenProduction.TextFont.CharSet = 162;
                    RenProduction.Value = @"";

                    RenRepair = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 31, 260, 36, false);
                    RenRepair.Name = "RenRepair";
                    RenRepair.Visible = EvetHayirEnum.ehHayir;
                    RenRepair.FieldType = ReportFieldTypeEnum.ftVariable;
                    RenRepair.CaseFormat = CaseFormatEnum.fcTitleCase;
                    RenRepair.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RenRepair.TextFont.CharSet = 162;
                    RenRepair.Value = @"";

                    ProductionCheck = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 16, 242, 21, false);
                    ProductionCheck.Name = "ProductionCheck";
                    ProductionCheck.Visible = EvetHayirEnum.ehHayir;
                    ProductionCheck.FieldType = ReportFieldTypeEnum.ftVariable;
                    ProductionCheck.ObjectDefName = "StockCard";
                    ProductionCheck.DataMember = "PRODUCTIONCHECKBOX";
                    ProductionCheck.Value = @"{@STOCKCARDID@}";

                    RepairCheck = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 23, 242, 28, false);
                    RepairCheck.Name = "RepairCheck";
                    RepairCheck.Visible = EvetHayirEnum.ehHayir;
                    RepairCheck.FieldType = ReportFieldTypeEnum.ftVariable;
                    RepairCheck.ObjectDefName = "StockCard";
                    RepairCheck.DataMember = "REPAIRCHECKBOX";
                    RepairCheck.Value = @"{@STOCKCARDID@}";

                    Ren = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 49, 47, 54, false);
                    Ren.Name = "Ren";
                    Ren.FieldType = ReportFieldTypeEnum.ftVariable;
                    Ren.CaseFormat = CaseFormatEnum.fcTitleCase;
                    Ren.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Ren.NoClip = EvetHayirEnum.ehEvet;
                    Ren.Value = @"{%RenProduction%}/{%RenRepair%}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = LOGO.Value;
                    ReportName.CalcValue = ReportName.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.TERMID.ToString();
                    STARTDATE.PostFieldValueCalculation();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.TERMID.ToString();
                    ENDDATE.PostFieldValueCalculation();
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField113.CalcValue = NewField113.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField1311.CalcValue = NewField1311.Value;
                    NewField142.CalcValue = NewField142.Value;
                    NewField1312.CalcValue = NewField1312.Value;
                    NATOStockNO.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDID.ToString();
                    NATOStockNO.PostFieldValueCalculation();
                    CardName.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDID.ToString();
                    CardName.PostFieldValueCalculation();
                    OrderNO.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDID.ToString();
                    OrderNO.PostFieldValueCalculation();
                    MainClassName.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDID.ToString();
                    MainClassName.PostFieldValueCalculation();
                    ClassName.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDID.ToString();
                    ClassName.PostFieldValueCalculation();
                    RenProduction.CalcValue = @"";
                    RenRepair.CalcValue = @"";
                    ProductionCheck.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDID.ToString();
                    ProductionCheck.PostFieldValueCalculation();
                    RepairCheck.CalcValue = MyParentReport.RuntimeParameters.STOCKCARDID.ToString();
                    RepairCheck.PostFieldValueCalculation();
                    Ren.CalcValue = MyParentReport.PARTA.RenProduction.CalcValue + @"/" + MyParentReport.PARTA.RenRepair.CalcValue;
                    return new TTReportObject[] { LOGO,ReportName,STARTDATE,ENDDATE,NewField1,NewField11,NewField12,NewField111,NewField13,NewField112,NewField14,NewField113,NewField141,NewField1311,NewField142,NewField1312,NATOStockNO,CardName,OrderNO,MainClassName,ClassName,RenProduction,RenRepair,ProductionCheck,RepairCheck,Ren};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    if(this.ProductionCheck.CalcValue == "True")
            {
                this.RenProduction.CalcValue = "Sarf Edilir";
            }
            else
            {
                this.RenProduction.CalcValue = "Sarf Edilmez";
            }
            
            if(this.RepairCheck.CalcValue == "True")
            {
                this.RenRepair.CalcValue = "Tamir Edilir";
            }
            else
            {
                this.RenRepair.CalcValue = "Tamir Edilmez";
            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public MaterialRequestForStoresReport MyParentReport
                {
                    get { return (MaterialRequestForStoresReport)ParentReport; }
                }
                
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportField PrintDate;
                public TTReportShape NewLine11; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 35;
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
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 170, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 25, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 170, 0, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

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

        public partial class PARTBGroup : TTReportGroup
        {
            public MaterialRequestForStoresReport MyParentReport
            {
                get { return (MaterialRequestForStoresReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField123 { get {return Header().NewField123;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
            public TTReportField RequestAmountTotal { get {return Footer().RequestAmountTotal;} }
            public TTReportField AmountTotal { get {return Footer().AmountTotal;} }
            public TTReportField SpendAmountTotal { get {return Footer().SpendAmountTotal;} }
            public TTReportField ReturningAmountTotal { get {return Footer().ReturningAmountTotal;} }
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
                public MaterialRequestForStoresReport MyParentReport
                {
                    get { return (MaterialRequestForStoresReport)ParentReport; }
                }
                
                public TTReportField NewField2;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField122;
                public TTReportField NewField123;
                public TTReportShape NewLine1; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 5;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 90, 5, false);
                    NewField2.Name = "NewField2";
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Size = 11;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Depo İsmi";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 0, 170, 5, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"İade Edilen";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 0, 150, 5, false);
                    NewField121.Name = "NewField121";
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Size = 11;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Sarf Edilen";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 0, 130, 5, false);
                    NewField122.Name = "NewField122";
                    NewField122.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.TextFont.Size = 11;
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"Karşılanan";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 0, 110, 5, false);
                    NewField123.Name = "NewField123";
                    NewField123.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField123.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField123.TextFont.Size = 11;
                    NewField123.TextFont.Bold = true;
                    NewField123.TextFont.CharSet = 162;
                    NewField123.Value = @"İstenen";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 5, 170, 5, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField2.CalcValue = NewField2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField123.CalcValue = NewField123.Value;
                    return new TTReportObject[] { NewField2,NewField12,NewField121,NewField122,NewField123};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public MaterialRequestForStoresReport MyParentReport
                {
                    get { return (MaterialRequestForStoresReport)ParentReport; }
                }
                
                public TTReportField NewField3;
                public TTReportField RequestAmountTotal;
                public TTReportField AmountTotal;
                public TTReportField SpendAmountTotal;
                public TTReportField ReturningAmountTotal; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 1, 90, 6, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Toplam:";

                    RequestAmountTotal = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 1, 110, 6, false);
                    RequestAmountTotal.Name = "RequestAmountTotal";
                    RequestAmountTotal.FieldType = ReportFieldTypeEnum.ftVariable;
                    RequestAmountTotal.TextFormat = @"#,###";
                    RequestAmountTotal.HorzAlign = HorizontalAlignmentEnum.haRight;
                    RequestAmountTotal.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RequestAmountTotal.Value = @"{@sumof(RequestTotal)@}";

                    AmountTotal = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 1, 130, 6, false);
                    AmountTotal.Name = "AmountTotal";
                    AmountTotal.FieldType = ReportFieldTypeEnum.ftVariable;
                    AmountTotal.TextFormat = @"#,###";
                    AmountTotal.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AmountTotal.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AmountTotal.Value = @"{@sumof(Total)@}";

                    SpendAmountTotal = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 1, 150, 6, false);
                    SpendAmountTotal.Name = "SpendAmountTotal";
                    SpendAmountTotal.FieldType = ReportFieldTypeEnum.ftVariable;
                    SpendAmountTotal.TextFormat = @"#,###";
                    SpendAmountTotal.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SpendAmountTotal.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SpendAmountTotal.Value = @"{@sumof(SpendTotal)@}";

                    ReturningAmountTotal = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 1, 170, 6, false);
                    ReturningAmountTotal.Name = "ReturningAmountTotal";
                    ReturningAmountTotal.FieldType = ReportFieldTypeEnum.ftVariable;
                    ReturningAmountTotal.TextFormat = @"#,###";
                    ReturningAmountTotal.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ReturningAmountTotal.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReturningAmountTotal.Value = @"{@sumof(ReturningTotal)@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField3.CalcValue = NewField3.Value;
                    RequestAmountTotal.CalcValue = ParentGroup.FieldSums["RequestTotal"].Value.ToString();;
                    AmountTotal.CalcValue = ParentGroup.FieldSums["Total"].Value.ToString();;
                    SpendAmountTotal.CalcValue = ParentGroup.FieldSums["SpendTotal"].Value.ToString();;
                    ReturningAmountTotal.CalcValue = ParentGroup.FieldSums["ReturningTotal"].Value.ToString();;
                    return new TTReportObject[] { NewField3,RequestAmountTotal,AmountTotal,SpendAmountTotal,ReturningAmountTotal};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTCGroup : TTReportGroup
        {
            public MaterialRequestForStoresReport MyParentReport
            {
                get { return (MaterialRequestForStoresReport)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField STOREID { get {return Header().STOREID;} }
            public TTReportField RequestTotal { get {return Footer().RequestTotal;} }
            public TTReportField Total { get {return Footer().Total;} }
            public TTReportField SpendTotal { get {return Footer().SpendTotal;} }
            public TTReportField ReturningTotal { get {return Footer().ReturningTotal;} }
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
                list[0] = new TTReportNqlData<StockActionDetailOut.GetStoreNameForMaterialRequestReportQuery_Class>("GetStoreNameForMaterialRequestReportQuery", StockActionDetailOut.GetStoreNameForMaterialRequestReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.PARTA.STARTDATE.FormattedValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.PARTA.ENDDATE.FormattedValue),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDID)));
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
                public MaterialRequestForStoresReport MyParentReport
                {
                    get { return (MaterialRequestForStoresReport)ParentReport; }
                }
                
                public TTReportField STOREID; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    STOREID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 1, 66, 6, false);
                    STOREID.Name = "STOREID";
                    STOREID.Visible = EvetHayirEnum.ehHayir;
                    STOREID.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOREID.Value = @"{#STOREID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockActionDetailOut.GetStoreNameForMaterialRequestReportQuery_Class dataset_GetStoreNameForMaterialRequestReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockActionDetailOut.GetStoreNameForMaterialRequestReportQuery_Class>(0);
                    STOREID.CalcValue = (dataset_GetStoreNameForMaterialRequestReportQuery != null ? Globals.ToStringCore(dataset_GetStoreNameForMaterialRequestReportQuery.Storeid) : "");
                    return new TTReportObject[] { STOREID};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public MaterialRequestForStoresReport MyParentReport
                {
                    get { return (MaterialRequestForStoresReport)ParentReport; }
                }
                
                public TTReportField RequestTotal;
                public TTReportField Total;
                public TTReportField SpendTotal;
                public TTReportField ReturningTotal; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    RequestTotal = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 0, 110, 5, false);
                    RequestTotal.Name = "RequestTotal";
                    RequestTotal.FieldType = ReportFieldTypeEnum.ftVariable;
                    RequestTotal.TextFormat = @"#,###";
                    RequestTotal.HorzAlign = HorizontalAlignmentEnum.haRight;
                    RequestTotal.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RequestTotal.Value = @"{@sumof(RequestAmount)@}";

                    Total = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 0, 130, 5, false);
                    Total.Name = "Total";
                    Total.FieldType = ReportFieldTypeEnum.ftVariable;
                    Total.TextFormat = @"#,###";
                    Total.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Total.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Total.Value = @"{@sumof(Amount)@}";

                    SpendTotal = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 0, 150, 5, false);
                    SpendTotal.Name = "SpendTotal";
                    SpendTotal.FieldType = ReportFieldTypeEnum.ftVariable;
                    SpendTotal.TextFormat = @"#,###";
                    SpendTotal.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SpendTotal.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SpendTotal.Value = @"{@sumof(SpendAmount)@}";

                    ReturningTotal = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 0, 170, 5, false);
                    ReturningTotal.Name = "ReturningTotal";
                    ReturningTotal.FieldType = ReportFieldTypeEnum.ftVariable;
                    ReturningTotal.TextFormat = @"#,###";
                    ReturningTotal.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ReturningTotal.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReturningTotal.Value = @"{@sumof(ReturningAmount)@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockActionDetailOut.GetStoreNameForMaterialRequestReportQuery_Class dataset_GetStoreNameForMaterialRequestReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockActionDetailOut.GetStoreNameForMaterialRequestReportQuery_Class>(0);
                    RequestTotal.CalcValue = ParentGroup.FieldSums["RequestAmount"].Value.ToString();;
                    Total.CalcValue = ParentGroup.FieldSums["Amount"].Value.ToString();;
                    SpendTotal.CalcValue = ParentGroup.FieldSums["SpendAmount"].Value.ToString();;
                    ReturningTotal.CalcValue = ParentGroup.FieldSums["ReturningAmount"].Value.ToString();;
                    return new TTReportObject[] { RequestTotal,Total,SpendTotal,ReturningTotal};
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class MAIN1Group : TTReportGroup
        {
            public MaterialRequestForStoresReport MyParentReport
            {
                get { return (MaterialRequestForStoresReport)ParentReport; }
            }

            new public MAIN1GroupBody Body()
            {
                return (MAIN1GroupBody)_body;
            }
            public TTReportField RequestAmount { get {return Body().RequestAmount;} }
            public TTReportField Amount { get {return Body().Amount;} }
            public TTReportField SpendAmount { get {return Body().SpendAmount;} }
            public TTReportField ReturningAmount { get {return Body().ReturningAmount;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportField DistributionAmount { get {return Body().DistributionAmount;} }
            public TTReportField DistributionRequest { get {return Body().DistributionRequest;} }
            public TTReportField SectionRequest { get {return Body().SectionRequest;} }
            public TTReportField SectionAmount { get {return Body().SectionAmount;} }
            public TTReportField VoucherAmount { get {return Body().VoucherAmount;} }
            public TTReportField VoucherRequest { get {return Body().VoucherRequest;} }
            public TTReportField StoreName { get {return Body().StoreName;} }
            public MAIN1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAIN1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[5];
                list[0] = new TTReportNqlData<StockActionDetailOut.GetReturningByStoreIDForMaterialRequestReportQuery_Class>("GetReturningByStoreIDForMaterialRequestReportQuery", StockActionDetailOut.GetReturningByStoreIDForMaterialRequestReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.PARTA.STARTDATE.FormattedValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.PARTA.ENDDATE.FormattedValue),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDID),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTC.STOREID.CalcValue)));
                list[1] = new TTReportNqlData<StockTransaction.GetSpendByStoreIDForMaterialRequestReportQuery_Class>("GetSpendByStoreIDForMaterialRequestReportQuery", StockTransaction.GetSpendByStoreIDForMaterialRequestReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.PARTA.STARTDATE.FormattedValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.PARTA.ENDDATE.FormattedValue),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDID),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTC.STOREID.CalcValue)));
                list[2] = new TTReportNqlData<DistributionDocumentMaterial.GetDistByStoreIDForMaterialRequestReportQuery_Class>("GetDistByStoreIDForMaterialRequestReportQuery", DistributionDocumentMaterial.GetDistByStoreIDForMaterialRequestReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.PARTA.STARTDATE.FormattedValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.PARTA.ENDDATE.FormattedValue),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDID),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTC.STOREID.CalcValue)));
                list[3] = new TTReportNqlData<SectionRequirementMaterial.GetSectionByStoreIDForMaterialRequestReportQuery_Class>("GetSectionByStoreIDForMaterialRequestReportQuery", SectionRequirementMaterial.GetSectionByStoreIDForMaterialRequestReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.PARTA.STARTDATE.FormattedValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.PARTA.ENDDATE.FormattedValue),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDID),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTC.STOREID.CalcValue)));
                list[4] = new TTReportNqlData<VoucherDistributingDocumentMaterial.GetVoucherByStoreIDForMaterialRequestReportQuery_Class>("GetVoucherByStoreIDForMaterialRequestReportQuery", VoucherDistributingDocumentMaterial.GetVoucherByStoreIDForMaterialRequestReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.PARTA.STARTDATE.FormattedValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.PARTA.ENDDATE.FormattedValue),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDID),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTC.STOREID.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAIN1GroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAIN1GroupBody : TTReportSection
            {
                public MaterialRequestForStoresReport MyParentReport
                {
                    get { return (MaterialRequestForStoresReport)ParentReport; }
                }
                
                public TTReportField RequestAmount;
                public TTReportField Amount;
                public TTReportField SpendAmount;
                public TTReportField ReturningAmount;
                public TTReportShape NewLine11;
                public TTReportField DistributionAmount;
                public TTReportField DistributionRequest;
                public TTReportField SectionRequest;
                public TTReportField SectionAmount;
                public TTReportField VoucherAmount;
                public TTReportField VoucherRequest;
                public TTReportField StoreName; 
                public MAIN1GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    RequestAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 1, 110, 6, false);
                    RequestAmount.Name = "RequestAmount";
                    RequestAmount.FieldType = ReportFieldTypeEnum.ftExpression;
                    RequestAmount.TextFormat = @"#,###";
                    RequestAmount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    RequestAmount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RequestAmount.Value = @"(Convert.ToDouble(""0"" + DistributionRequest.CalcValue) + Convert.ToDouble(""0"" + SectionRequest.CalcValue) + Convert.ToDouble(""0"" + VoucherRequest.CalcValue)).ToString()";

                    Amount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 1, 130, 6, false);
                    Amount.Name = "Amount";
                    Amount.FieldType = ReportFieldTypeEnum.ftExpression;
                    Amount.TextFormat = @"#,###";
                    Amount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Amount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Amount.Value = @"(Convert.ToDouble(""0"" + DistributionAmount.CalcValue) + Convert.ToDouble(""0"" + SectionAmount.CalcValue) + Convert.ToDouble(""0"" + VoucherAmount.CalcValue)).ToString()";

                    SpendAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 1, 150, 6, false);
                    SpendAmount.Name = "SpendAmount";
                    SpendAmount.FieldType = ReportFieldTypeEnum.ftVariable;
                    SpendAmount.TextFormat = @"#,###";
                    SpendAmount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SpendAmount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SpendAmount.Value = @"{#SPENDAMOUNT!GetSpendByStoreIDForMaterialRequestReportQuery#}";

                    ReturningAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 1, 170, 6, false);
                    ReturningAmount.Name = "ReturningAmount";
                    ReturningAmount.FieldType = ReportFieldTypeEnum.ftVariable;
                    ReturningAmount.TextFormat = @"#,###";
                    ReturningAmount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ReturningAmount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReturningAmount.Value = @"{#RETURNINGAMOUNT!GetReturningByStoreIDForMaterialRequestReportQuery#}";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 7, 170, 7, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    DistributionAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 1, 242, 6, false);
                    DistributionAmount.Name = "DistributionAmount";
                    DistributionAmount.Visible = EvetHayirEnum.ehHayir;
                    DistributionAmount.FieldType = ReportFieldTypeEnum.ftVariable;
                    DistributionAmount.Value = @"{#AMOUNT!GetDistByStoreIDForMaterialRequestReportQuery#}";

                    DistributionRequest = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 6, 242, 11, false);
                    DistributionRequest.Name = "DistributionRequest";
                    DistributionRequest.Visible = EvetHayirEnum.ehHayir;
                    DistributionRequest.FieldType = ReportFieldTypeEnum.ftVariable;
                    DistributionRequest.Value = @"{#REQUESTAMOUNT!GetDistByStoreIDForMaterialRequestReportQuery#}";

                    SectionRequest = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 245, 6, 270, 11, false);
                    SectionRequest.Name = "SectionRequest";
                    SectionRequest.Visible = EvetHayirEnum.ehHayir;
                    SectionRequest.FieldType = ReportFieldTypeEnum.ftVariable;
                    SectionRequest.Value = @"{#REQUESTAMOUNT!GetSectionByStoreIDForMaterialRequestReportQuery#}";

                    SectionAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 245, 1, 270, 6, false);
                    SectionAmount.Name = "SectionAmount";
                    SectionAmount.Visible = EvetHayirEnum.ehHayir;
                    SectionAmount.FieldType = ReportFieldTypeEnum.ftVariable;
                    SectionAmount.Value = @"{#AMOUNT!GetSectionByStoreIDForMaterialRequestReportQuery#}";

                    VoucherAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 273, 1, 298, 6, false);
                    VoucherAmount.Name = "VoucherAmount";
                    VoucherAmount.Visible = EvetHayirEnum.ehHayir;
                    VoucherAmount.FieldType = ReportFieldTypeEnum.ftVariable;
                    VoucherAmount.Value = @"{#AMOUNT!GetVoucherByStoreIDForMaterialRequestReportQuery#}";

                    VoucherRequest = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 273, 6, 298, 11, false);
                    VoucherRequest.Name = "VoucherRequest";
                    VoucherRequest.Visible = EvetHayirEnum.ehHayir;
                    VoucherRequest.FieldType = ReportFieldTypeEnum.ftVariable;
                    VoucherRequest.Value = @"{#REQUESTAMOUNT!GetVoucherByStoreIDForMaterialRequestReportQuery#}";

                    StoreName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 90, 6, false);
                    StoreName.Name = "StoreName";
                    StoreName.FieldType = ReportFieldTypeEnum.ftVariable;
                    StoreName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    StoreName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    StoreName.WordBreak = EvetHayirEnum.ehEvet;
                    StoreName.ObjectDefName = "Store";
                    StoreName.DataMember = "NAME";
                    StoreName.Value = @"{%PARTC.STOREID%}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockActionDetailOut.GetReturningByStoreIDForMaterialRequestReportQuery_Class dataset_GetReturningByStoreIDForMaterialRequestReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockActionDetailOut.GetReturningByStoreIDForMaterialRequestReportQuery_Class>(0);
                    StockTransaction.GetSpendByStoreIDForMaterialRequestReportQuery_Class dataset_GetSpendByStoreIDForMaterialRequestReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockTransaction.GetSpendByStoreIDForMaterialRequestReportQuery_Class>(1);
                    DistributionDocumentMaterial.GetDistByStoreIDForMaterialRequestReportQuery_Class dataset_GetDistByStoreIDForMaterialRequestReportQuery = ParentGroup.rsGroup.GetCurrentRecord<DistributionDocumentMaterial.GetDistByStoreIDForMaterialRequestReportQuery_Class>(2);
                    SectionRequirementMaterial.GetSectionByStoreIDForMaterialRequestReportQuery_Class dataset_GetSectionByStoreIDForMaterialRequestReportQuery = ParentGroup.rsGroup.GetCurrentRecord<SectionRequirementMaterial.GetSectionByStoreIDForMaterialRequestReportQuery_Class>(3);
                    VoucherDistributingDocumentMaterial.GetVoucherByStoreIDForMaterialRequestReportQuery_Class dataset_GetVoucherByStoreIDForMaterialRequestReportQuery = ParentGroup.rsGroup.GetCurrentRecord<VoucherDistributingDocumentMaterial.GetVoucherByStoreIDForMaterialRequestReportQuery_Class>(4);
                    SpendAmount.CalcValue = (dataset_GetSpendByStoreIDForMaterialRequestReportQuery != null ? Globals.ToStringCore(dataset_GetSpendByStoreIDForMaterialRequestReportQuery.Spendamount) : "");
                    ReturningAmount.CalcValue = (dataset_GetReturningByStoreIDForMaterialRequestReportQuery != null ? Globals.ToStringCore(dataset_GetReturningByStoreIDForMaterialRequestReportQuery.Returningamount) : "");
                    DistributionAmount.CalcValue = (dataset_GetDistByStoreIDForMaterialRequestReportQuery != null ? Globals.ToStringCore(dataset_GetDistByStoreIDForMaterialRequestReportQuery.Amount) : "");
                    DistributionRequest.CalcValue = (dataset_GetDistByStoreIDForMaterialRequestReportQuery != null ? Globals.ToStringCore(dataset_GetDistByStoreIDForMaterialRequestReportQuery.Requestamount) : "");
                    SectionRequest.CalcValue = (dataset_GetSectionByStoreIDForMaterialRequestReportQuery != null ? Globals.ToStringCore(dataset_GetSectionByStoreIDForMaterialRequestReportQuery.Requestamount) : "");
                    SectionAmount.CalcValue = (dataset_GetSectionByStoreIDForMaterialRequestReportQuery != null ? Globals.ToStringCore(dataset_GetSectionByStoreIDForMaterialRequestReportQuery.Amount) : "");
                    VoucherAmount.CalcValue = (dataset_GetVoucherByStoreIDForMaterialRequestReportQuery != null ? Globals.ToStringCore(dataset_GetVoucherByStoreIDForMaterialRequestReportQuery.Amount) : "");
                    VoucherRequest.CalcValue = (dataset_GetVoucherByStoreIDForMaterialRequestReportQuery != null ? Globals.ToStringCore(dataset_GetVoucherByStoreIDForMaterialRequestReportQuery.Requestamount) : "");
                    StoreName.CalcValue = MyParentReport.PARTC.STOREID.CalcValue;
                    StoreName.PostFieldValueCalculation();
                    RequestAmount.CalcValue = (Convert.ToDouble("0" + DistributionRequest.CalcValue) + Convert.ToDouble("0" + SectionRequest.CalcValue) + Convert.ToDouble("0" + VoucherRequest.CalcValue)).ToString();
                    Amount.CalcValue = (Convert.ToDouble("0" + DistributionAmount.CalcValue) + Convert.ToDouble("0" + SectionAmount.CalcValue) + Convert.ToDouble("0" + VoucherAmount.CalcValue)).ToString();
                    return new TTReportObject[] { SpendAmount,ReturningAmount,DistributionAmount,DistributionRequest,SectionRequest,SectionAmount,VoucherAmount,VoucherRequest,StoreName,RequestAmount,Amount};
                }
            }

        }

        public MAIN1Group MAIN1;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public MaterialRequestForStoresReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            PARTC = new PARTCGroup(PARTB,"PARTC");
            MAIN1 = new MAIN1Group(PARTC,"MAIN1");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STOCKCARDID", "", "Stok Kartını Seçiniz", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("e8c3b02e-4a08-4c98-bfd0-15d84fafb295");
            reportParameter = Parameters.Add("TERMID", "", "Hesap Dönemi Seçiniz", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("429e41e5-620c-4652-9e24-aa488e0aaaaf");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STOCKCARDID"))
                _runtimeParameters.STOCKCARDID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["STOCKCARDID"]);
            if (parameters.ContainsKey("TERMID"))
                _runtimeParameters.TERMID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TERMID"]);
            Name = "MATERIALREQUESTFORSTORESREPORT";
            Caption = "Malzeme istekleri (Depolara Göre)";
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

    }
}