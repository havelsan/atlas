
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
    /// Sayım Listesi Raporu
    /// </summary>
    public partial class CensusListReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public CensusListReport MyParentReport
            {
                get { return (CensusListReport)ParentReport; }
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
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
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
                public CensusListReport MyParentReport
                {
                    get { return (CensusListReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField ReportName; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 20;
                    KeepTogether = EvetHayirEnum.ehEvet;
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
                    ReportName.Value = @"SAYIM LİSTESİ RAPORU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = LOGO.Value;
                    ReportName.CalcValue = ReportName.Value;
                    return new TTReportObject[] { LOGO,ReportName};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public CensusListReport MyParentReport
                {
                    get { return (CensusListReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField PageNumber;
                public TTReportField CurrentUser;
                public TTReportShape NewLine11; 
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
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 170, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 0, 100, 5, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 170, 0, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

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

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public CensusListReport MyParentReport
            {
                get { return (CensusListReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
            public TTReportField Total { get {return Footer().Total;} }
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
                public CensusListReport MyParentReport
                {
                    get { return (CensusListReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField111;
                public TTReportField NewField112;
                public TTReportShape NewLine1; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 13, 6, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Sıra Nu.";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 1, 41, 6, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Nato Stok Nu.";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 1, 120, 6, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Malzeme İsmi";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 1, 143, 6, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Size = 11;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Dağıtım Şekli";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 1, 170, 6, false);
                    NewField112.Name = "NewField112";
                    NewField112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.TextFont.Size = 11;
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"Miktar";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 6, 170, 6, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField112.CalcValue = NewField112.Value;
                    return new TTReportObject[] { NewField1,NewField11,NewField12,NewField111,NewField112};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public CensusListReport MyParentReport
                {
                    get { return (CensusListReport)ParentReport; }
                }
                
                public TTReportField NewField2;
                public TTReportShape NewLine2;
                public TTReportField Total; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 5;
                    IsAligned = EvetHayirEnum.ehEvet;
                    AutoSizeGap = 1;
                    RepeatCount = 0;
                    
                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 0, 143, 5, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.Value = @"Genel Toplam:";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 170, 0, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    Total = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 0, 170, 5, false);
                    Total.Name = "Total";
                    Total.FieldType = ReportFieldTypeEnum.ftVariable;
                    Total.TextFormat = @"#,##0";
                    Total.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Total.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Total.Value = @"{@sumof(Amount)@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField2.CalcValue = NewField2.Value;
                    Total.CalcValue = ParentGroup.FieldSums["Amount"].Value.ToString();;
                    return new TTReportObject[] { NewField2,Total};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public CensusListReport MyParentReport
            {
                get { return (CensusListReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField OrderNO { get {return Body().OrderNO;} }
            public TTReportField NATOStockNO { get {return Body().NATOStockNO;} }
            public TTReportField StockCardName { get {return Body().StockCardName;} }
            public TTReportField DistributionType { get {return Body().DistributionType;} }
            public TTReportField Amount { get {return Body().Amount;} }
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
                list[0] = new TTReportNqlData<CensusOrder.GetCensusListReportQuery_Class>("GetCensusListReportQuery", CensusOrder.GetCensusListReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public CensusListReport MyParentReport
                {
                    get { return (CensusListReport)ParentReport; }
                }
                
                public TTReportField OrderNO;
                public TTReportField NATOStockNO;
                public TTReportField StockCardName;
                public TTReportField DistributionType;
                public TTReportField Amount;
                public TTReportShape NewLine1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    OrderNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 13, 6, false);
                    OrderNO.Name = "OrderNO";
                    OrderNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    OrderNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OrderNO.Value = @"{@counter@}";

                    NATOStockNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 1, 41, 6, false);
                    NATOStockNO.Name = "NATOStockNO";
                    NATOStockNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOStockNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NATOStockNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NATOStockNO.Value = @"{#NATOSTOCKNO#}";

                    StockCardName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 1, 121, 6, false);
                    StockCardName.Name = "StockCardName";
                    StockCardName.FieldType = ReportFieldTypeEnum.ftVariable;
                    StockCardName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    StockCardName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    StockCardName.Value = @"{#NAME#}";

                    DistributionType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 1, 143, 6, false);
                    DistributionType.Name = "DistributionType";
                    DistributionType.FieldType = ReportFieldTypeEnum.ftVariable;
                    DistributionType.CaseFormat = CaseFormatEnum.fcTitleCase;
                    DistributionType.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DistributionType.Value = @"{#DISTRIBUTIONTYPE#}";

                    Amount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 1, 170, 6, false);
                    Amount.Name = "Amount";
                    Amount.FieldType = ReportFieldTypeEnum.ftVariable;
                    Amount.TextFormat = @"#,##0";
                    Amount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Amount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Amount.Value = @"{#NEWINHELD#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 7, 170, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CensusOrder.GetCensusListReportQuery_Class dataset_GetCensusListReportQuery = ParentGroup.rsGroup.GetCurrentRecord<CensusOrder.GetCensusListReportQuery_Class>(0);
                    OrderNO.CalcValue = ParentGroup.Counter.ToString();
                    NATOStockNO.CalcValue = (dataset_GetCensusListReportQuery != null ? Globals.ToStringCore(dataset_GetCensusListReportQuery.NATOStockNO) : "");
                    StockCardName.CalcValue = (dataset_GetCensusListReportQuery != null ? Globals.ToStringCore(dataset_GetCensusListReportQuery.Name) : "");
                    DistributionType.CalcValue = (dataset_GetCensusListReportQuery != null ? Globals.ToStringCore(dataset_GetCensusListReportQuery.DistributionType) : "");
                    Amount.CalcValue = (dataset_GetCensusListReportQuery != null ? Globals.ToStringCore(dataset_GetCensusListReportQuery.NewInheld) : "");
                    return new TTReportObject[] { OrderNO,NATOStockNO,StockCardName,DistributionType,Amount};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public CensusListReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Sayım Emri", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "CENSUSLISTREPORT";
            Caption = "Sayım Listesi Raporu";
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