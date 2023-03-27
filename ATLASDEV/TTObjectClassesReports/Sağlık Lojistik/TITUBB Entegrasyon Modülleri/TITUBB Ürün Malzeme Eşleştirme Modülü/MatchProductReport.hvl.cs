
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
    /// Eşleşen TITUBB Ürünleri
    /// </summary>
    public partial class MatchProductReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public MatchProductReport MyParentReport
            {
                get { return (MatchProductReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField ReportName1 { get {return Header().ReportName1;} }
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
                public MatchProductReport MyParentReport
                {
                    get { return (MatchProductReport)ParentReport; }
                }
                
                public TTReportField ReportName1; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 22;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ReportName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 2, 203, 22, false);
                    ReportName1.Name = "ReportName1";
                    ReportName1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName1.TextFont.Size = 15;
                    ReportName1.TextFont.Bold = true;
                    ReportName1.TextFont.CharSet = 162;
                    ReportName1.Value = @"EŞLEŞEN TITUBB ÜRÜNLERİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReportName1.CalcValue = ReportName1.Value;
                    return new TTReportObject[] { ReportName1};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public MatchProductReport MyParentReport
                {
                    get { return (MatchProductReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public MatchProductReport MyParentReport
            {
                get { return (MatchProductReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField PRODUCTNUMBER { get {return Header().PRODUCTNUMBER;} }
            public TTReportField NAME { get {return Header().NAME;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField Ürün_Numarası { get {return Header().Ürün_Numarası;} }
            public TTReportField Etiket_Adı { get {return Header().Etiket_Adı;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportShape NewLine121 { get {return Header().NewLine121;} }
            public TTReportShape NewLine122 { get {return Header().NewLine122;} }
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
                list[0] = new TTReportNqlData<MaterialProductLevel.DoubleMatchProductQuery_Class>("DoubleMatchProductQuery", MaterialProductLevel.DoubleMatchProductQuery());
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
                public MatchProductReport MyParentReport
                {
                    get { return (MatchProductReport)ParentReport; }
                }
                
                public TTReportField PRODUCTNUMBER;
                public TTReportField NAME;
                public TTReportShape NewLine11;
                public TTReportField Ürün_Numarası;
                public TTReportField Etiket_Adı;
                public TTReportShape NewLine111;
                public TTReportShape NewLine12;
                public TTReportShape NewLine121;
                public TTReportShape NewLine122; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 14;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PRODUCTNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 1, 37, 6, false);
                    PRODUCTNUMBER.Name = "PRODUCTNUMBER";
                    PRODUCTNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRODUCTNUMBER.ObjectDefName = "ProductDefinition";
                    PRODUCTNUMBER.DataMember = "PRODUCTNUMBER";
                    PRODUCTNUMBER.TextFont.Bold = true;
                    PRODUCTNUMBER.TextFont.CharSet = 162;
                    PRODUCTNUMBER.Value = @"{#PRODUCT#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 1, 203, 6, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.ObjectDefName = "ProductDefinition";
                    NAME.DataMember = "NAME";
                    NAME.TextFont.Bold = true;
                    NAME.TextFont.CharSet = 162;
                    NAME.Value = @"{#PRODUCT#}";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 7, 203, 7, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                    Ürün_Numarası = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 8, 37, 13, false);
                    Ürün_Numarası.Name = "Ürün_Numarası";
                    Ürün_Numarası.TextFont.Bold = true;
                    Ürün_Numarası.TextFont.CharSet = 162;
                    Ürün_Numarası.Value = @"Nato Stok Nu.";

                    Etiket_Adı = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 8, 203, 13, false);
                    Etiket_Adı.Name = "Etiket_Adı";
                    Etiket_Adı.TextFont.Bold = true;
                    Etiket_Adı.TextFont.CharSet = 162;
                    Etiket_Adı.Value = @"Malzeme Adı";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 14, 203, 14, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 37, 7, 37, 14, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.DrawWidth = 2;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 7, 4, 14, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.DrawWidth = 2;

                    NewLine122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 203, 7, 203, 14, false);
                    NewLine122.Name = "NewLine122";
                    NewLine122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine122.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaterialProductLevel.DoubleMatchProductQuery_Class dataset_DoubleMatchProductQuery = ParentGroup.rsGroup.GetCurrentRecord<MaterialProductLevel.DoubleMatchProductQuery_Class>(0);
                    PRODUCTNUMBER.CalcValue = (dataset_DoubleMatchProductQuery != null ? Globals.ToStringCore(dataset_DoubleMatchProductQuery.Product) : "");
                    PRODUCTNUMBER.PostFieldValueCalculation();
                    NAME.CalcValue = (dataset_DoubleMatchProductQuery != null ? Globals.ToStringCore(dataset_DoubleMatchProductQuery.Product) : "");
                    NAME.PostFieldValueCalculation();
                    Ürün_Numarası.CalcValue = Ürün_Numarası.Value;
                    Etiket_Adı.CalcValue = Etiket_Adı.Value;
                    return new TTReportObject[] { PRODUCTNUMBER,NAME,Ürün_Numarası,Etiket_Adı};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public MatchProductReport MyParentReport
                {
                    get { return (MatchProductReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 5;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public MatchProductReport MyParentReport
            {
                get { return (MatchProductReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField NAME { get {return Body().NAME;} }
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

                MaterialProductLevel.DoubleMatchProductQuery_Class dataSet_DoubleMatchProductQuery = ParentGroup.rsGroup.GetCurrentRecord<MaterialProductLevel.DoubleMatchProductQuery_Class>(0);    
                return new object[] {(dataSet_DoubleMatchProductQuery==null ? null : dataSet_DoubleMatchProductQuery.Product)};
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
                public MatchProductReport MyParentReport
                {
                    get { return (MatchProductReport)ParentReport; }
                }
                
                public TTReportField NATOSTOCKNO;
                public TTReportField NAME; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 0, 37, 5, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.Value = @"{#PARTB.NATOSTOCKNO#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 0, 203, 5, false);
                    NAME.Name = "NAME";
                    NAME.DrawStyle = DrawStyleConstants.vbSolid;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.ObjectDefName = "Material";
                    NAME.DataMember = "NAME";
                    NAME.Value = @"{#PARTB.MATERIAL#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaterialProductLevel.DoubleMatchProductQuery_Class dataset_DoubleMatchProductQuery = MyParentReport.PARTB.rsGroup.GetCurrentRecord<MaterialProductLevel.DoubleMatchProductQuery_Class>(0);
                    NATOSTOCKNO.CalcValue = (dataset_DoubleMatchProductQuery != null ? Globals.ToStringCore(dataset_DoubleMatchProductQuery.NATOStockNO) : "");
                    NAME.CalcValue = (dataset_DoubleMatchProductQuery != null ? Globals.ToStringCore(dataset_DoubleMatchProductQuery.Material) : "");
                    NAME.PostFieldValueCalculation();
                    return new TTReportObject[] { NATOSTOCKNO,NAME};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public MatchProductReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            Name = "MATCHPRODUCTREPORT";
            Caption = "Eşleşen TITUBB Ürünleri";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            UserMarginLeft = 2;
            UserMarginTop = 2;
            UsePrinterMargins = EvetHayirEnum.ehEvet;
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