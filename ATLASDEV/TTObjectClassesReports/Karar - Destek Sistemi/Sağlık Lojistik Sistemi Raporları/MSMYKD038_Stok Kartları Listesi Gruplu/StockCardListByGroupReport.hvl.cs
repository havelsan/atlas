
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
    /// Stok Kartları Listesi Gruplu
    /// </summary>
    public partial class StockCardListByGroupReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public StockCardListByGroupReport MyParentReport
            {
                get { return (StockCardListByGroupReport)ParentReport; }
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
                public StockCardListByGroupReport MyParentReport
                {
                    get { return (StockCardListByGroupReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField ReportName; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 21;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.Value = @"";

                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 170, 20, false);
                    ReportName.Name = "ReportName";
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Name = "Arial";
                    ReportName.TextFont.Size = 12;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"STOK KARTLARI GRUPLU LİSTESİ RAPORU";

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
                public StockCardListByGroupReport MyParentReport
                {
                    get { return (StockCardListByGroupReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField PageNumber;
                public TTReportField CurrentUser;
                public TTReportShape NewLine11; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 25, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 170, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 0, 100, 5, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser.TextFont.Name = "Arial";
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
            public StockCardListByGroupReport MyParentReport
            {
                get { return (StockCardListByGroupReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField PARENTCLASSNAME { get {return Header().PARENTCLASSNAME;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField4 { get {return Footer().NewField4;} }
            public TTReportField TOTAL { get {return Footer().TOTAL;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Material.GetStockCardListByGroupReportQuery_Class>("GetStockCardListByGroupReportQuery", Material.GetStockCardListByGroupReportQuery());
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public StockCardListByGroupReport MyParentReport
                {
                    get { return (StockCardListByGroupReport)ParentReport; }
                }
                
                public TTReportField PARENTCLASSNAME;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportShape NewLine1; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 12;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PARENTCLASSNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 170, 5, false);
                    PARENTCLASSNAME.Name = "PARENTCLASSNAME";
                    PARENTCLASSNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PARENTCLASSNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARENTCLASSNAME.WordBreak = EvetHayirEnum.ehEvet;
                    PARENTCLASSNAME.TextFont.Name = "Arial";
                    PARENTCLASSNAME.TextFont.Size = 11;
                    PARENTCLASSNAME.TextFont.Bold = true;
                    PARENTCLASSNAME.TextFont.CharSet = 162;
                    PARENTCLASSNAME.Value = @"{#NAME#}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 6, 25, 11, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Kart Statüsü";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 6, 170, 11, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Kart Adedi";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 11, 170, 11, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Material.GetStockCardListByGroupReportQuery_Class dataset_GetStockCardListByGroupReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Material.GetStockCardListByGroupReportQuery_Class>(0);
                    PARENTCLASSNAME.CalcValue = (dataset_GetStockCardListByGroupReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardListByGroupReportQuery.Name) : "");
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    return new TTReportObject[] { PARENTCLASSNAME,NewField2,NewField3};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public StockCardListByGroupReport MyParentReport
                {
                    get { return (StockCardListByGroupReport)ParentReport; }
                }
                
                public TTReportField NewField4;
                public TTReportField TOTAL; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    RepeatCount = 0;
                    
                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 1, 145, 6, false);
                    NewField4.Name = "NewField4";
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Genel Toplam :";

                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 1, 170, 6, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL.TextFormat = @"#,##0";
                    TOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTAL.TextFont.Name = "Arial";
                    TOTAL.TextFont.CharSet = 162;
                    TOTAL.Value = @"{@sumof(StatusCount)@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Material.GetStockCardListByGroupReportQuery_Class dataset_GetStockCardListByGroupReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Material.GetStockCardListByGroupReportQuery_Class>(0);
                    NewField4.CalcValue = NewField4.Value;
                    TOTAL.CalcValue = ParentGroup.FieldSums["StatusCount"].Value.ToString();;
                    return new TTReportObject[] { NewField4,TOTAL};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public StockCardListByGroupReport MyParentReport
            {
                get { return (StockCardListByGroupReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField STATUS { get {return Body().STATUS;} }
            public TTReportField StatusCount { get {return Body().StatusCount;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                Material.GetStockCardListByGroupReportQuery_Class dataSet_GetStockCardListByGroupReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Material.GetStockCardListByGroupReportQuery_Class>(0);    
                return new object[] {(dataSet_GetStockCardListByGroupReportQuery==null ? null : dataSet_GetStockCardListByGroupReportQuery.Name)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public StockCardListByGroupReport MyParentReport
                {
                    get { return (StockCardListByGroupReport)ParentReport; }
                }
                
                public TTReportField STATUS;
                public TTReportField StatusCount;
                public TTReportShape NewLine11; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    STATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 25, 6, false);
                    STATUS.Name = "STATUS";
                    STATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    STATUS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STATUS.NoClip = EvetHayirEnum.ehEvet;
                    STATUS.ObjectDefName = "StockCardStatusEnum";
                    STATUS.DataMember = "DISPLAYTEXT";
                    STATUS.TextFont.Name = "Arial";
                    STATUS.TextFont.CharSet = 162;
                    STATUS.Value = @"{#PARTB.STATUS#}";

                    StatusCount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 1, 170, 6, false);
                    StatusCount.Name = "StatusCount";
                    StatusCount.FieldType = ReportFieldTypeEnum.ftVariable;
                    StatusCount.TextFormat = @"#,##0";
                    StatusCount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    StatusCount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    StatusCount.TextFont.Name = "Arial";
                    StatusCount.TextFont.CharSet = 162;
                    StatusCount.Value = @"{#PARTB.COUNTSTATUS#}";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 7, 170, 7, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Material.GetStockCardListByGroupReportQuery_Class dataset_GetStockCardListByGroupReportQuery = MyParentReport.PARTB.rsGroup.GetCurrentRecord<Material.GetStockCardListByGroupReportQuery_Class>(0);
                    STATUS.CalcValue = (dataset_GetStockCardListByGroupReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardListByGroupReportQuery.Status) : "");
                    STATUS.PostFieldValueCalculation();
                    StatusCount.CalcValue = (dataset_GetStockCardListByGroupReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardListByGroupReportQuery.Countstatus) : "");
                    return new TTReportObject[] { STATUS,StatusCount};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public StockCardListByGroupReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            Name = "STOCKCARDLISTBYGROUPREPORT";
            Caption = "Stok Kartları Listesi Gruplu";
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