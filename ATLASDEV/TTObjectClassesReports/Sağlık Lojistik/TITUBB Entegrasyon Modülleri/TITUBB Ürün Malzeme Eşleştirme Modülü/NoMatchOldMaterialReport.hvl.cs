
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
    /// TITUBB Eşleşmesi Yapılmayan Malzemeler(Mevcutlu)
    /// </summary>
    public partial class NoMatchOldMaterialReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public int? ALL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public NoMatchOldMaterialReport MyParentReport
            {
                get { return (NoMatchOldMaterialReport)ParentReport; }
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
                public NoMatchOldMaterialReport MyParentReport
                {
                    get { return (NoMatchOldMaterialReport)ParentReport; }
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
                    ReportName1.Value = @"TITUBB EŞLEŞMESİ YAPILMAYAN MALZEMELER";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReportName1.CalcValue = ReportName1.Value;
                    return new TTReportObject[] { ReportName1};
                }
                public override void RunPreScript()
                {
#region PARTA HEADER_PreScript
                    if(MyParentReport.RuntimeParameters.STORE == Guid.Empty )
                MyParentReport.RuntimeParameters.ALL= 1;
            else
               MyParentReport.RuntimeParameters.ALL= 0;
#endregion PARTA HEADER_PreScript
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public NoMatchOldMaterialReport MyParentReport
                {
                    get { return (NoMatchOldMaterialReport)ParentReport; }
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
            public NoMatchOldMaterialReport MyParentReport
            {
                get { return (NoMatchOldMaterialReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField Ürün_Numarası1 { get {return Header().Ürün_Numarası1;} }
            public TTReportField Etiket_Adı1 { get {return Header().Etiket_Adı1;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportShape NewLine121 { get {return Header().NewLine121;} }
            public TTReportField NAME { get {return Header().NAME;} }
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
                list[0] = new TTReportNqlData<Stock.NoMatchOldMaterailQuery_Class>("NoMatchOldMaterailQuery", Stock.NoMatchOldMaterailQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STORE),(string)TTObjectDefManager.Instance.DataTypes["String_1"].ConvertValue(MyParentReport.RuntimeParameters.ALL)));
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
                public NoMatchOldMaterialReport MyParentReport
                {
                    get { return (NoMatchOldMaterialReport)ParentReport; }
                }
                
                public TTReportShape NewLine11;
                public TTReportField Ürün_Numarası1;
                public TTReportField Etiket_Adı1;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine1;
                public TTReportShape NewLine12;
                public TTReportShape NewLine121;
                public TTReportField NAME; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 16;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 8, 203, 8, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                    Ürün_Numarası1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 9, 37, 14, false);
                    Ürün_Numarası1.Name = "Ürün_Numarası1";
                    Ürün_Numarası1.TextFont.Bold = true;
                    Ürün_Numarası1.TextFont.CharSet = 162;
                    Ürün_Numarası1.Value = @"Nato Stok Nu";

                    Etiket_Adı1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 9, 203, 14, false);
                    Etiket_Adı1.Name = "Etiket_Adı1";
                    Etiket_Adı1.TextFont.Bold = true;
                    Etiket_Adı1.TextFont.CharSet = 162;
                    Etiket_Adı1.Value = @"Malzeme Adı";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 15, 203, 15, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.DrawWidth = 2;

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 37, 8, 37, 15, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 4, 8, 4, 15, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.DrawWidth = 2;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 203, 9, 203, 16, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.DrawWidth = 2;

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 1, 203, 6, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.TextFont.Size = 12;
                    NAME.TextFont.Bold = true;
                    NAME.TextFont.CharSet = 162;
                    NAME.Value = @"{#NAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Stock.NoMatchOldMaterailQuery_Class dataset_NoMatchOldMaterailQuery = ParentGroup.rsGroup.GetCurrentRecord<Stock.NoMatchOldMaterailQuery_Class>(0);
                    Ürün_Numarası1.CalcValue = Ürün_Numarası1.Value;
                    Etiket_Adı1.CalcValue = Etiket_Adı1.Value;
                    NAME.CalcValue = (dataset_NoMatchOldMaterailQuery != null ? Globals.ToStringCore(dataset_NoMatchOldMaterailQuery.Name) : "");
                    return new TTReportObject[] { Ürün_Numarası1,Etiket_Adı1,NAME};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public NoMatchOldMaterialReport MyParentReport
                {
                    get { return (NoMatchOldMaterialReport)ParentReport; }
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
            public NoMatchOldMaterialReport MyParentReport
            {
                get { return (NoMatchOldMaterialReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField MATERIAL { get {return Body().MATERIAL;} }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
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

                Stock.NoMatchOldMaterailQuery_Class dataSet_NoMatchOldMaterailQuery = ParentGroup.rsGroup.GetCurrentRecord<Stock.NoMatchOldMaterailQuery_Class>(0);    
                return new object[] {(dataSet_NoMatchOldMaterailQuery==null ? null : dataSet_NoMatchOldMaterailQuery.Name)};
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
                public NoMatchOldMaterialReport MyParentReport
                {
                    get { return (NoMatchOldMaterialReport)ParentReport; }
                }
                
                public TTReportField MATERIAL;
                public TTReportField NATOSTOCKNO; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    MATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 0, 203, 5, false);
                    MATERIAL.Name = "MATERIAL";
                    MATERIAL.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIAL.ObjectDefName = "Material";
                    MATERIAL.DataMember = "NAME";
                    MATERIAL.Value = @"{#PARTB.MATERIAL#}";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 0, 37, 5, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.TextFont.CharSet = 162;
                    NATOSTOCKNO.Value = @"{#PARTB.NATOSTOCKNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Stock.NoMatchOldMaterailQuery_Class dataset_NoMatchOldMaterailQuery = MyParentReport.PARTB.rsGroup.GetCurrentRecord<Stock.NoMatchOldMaterailQuery_Class>(0);
                    MATERIAL.CalcValue = (dataset_NoMatchOldMaterailQuery != null ? Globals.ToStringCore(dataset_NoMatchOldMaterailQuery.Material) : "");
                    MATERIAL.PostFieldValueCalculation();
                    NATOSTOCKNO.CalcValue = (dataset_NoMatchOldMaterailQuery != null ? Globals.ToStringCore(dataset_NoMatchOldMaterailQuery.NATOStockNO) : "");
                    return new TTReportObject[] { MATERIAL,NATOSTOCKNO};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public NoMatchOldMaterialReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STORE", "00000000-0000-0000-0000-000000000000", "Depo Seçiniz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("65405b70-5e35-4486-b140-c95af3d8bf5d");
            reportParameter = Parameters.Add("ALL", "", "All", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STORE"))
                _runtimeParameters.STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STORE"]);
            if (parameters.ContainsKey("ALL"))
                _runtimeParameters.ALL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["ALL"]);
            Name = "NOMATCHOLDMATERIALREPORT";
            Caption = "TITUBB Eşleşmesi Yapılmayan Malzemeler(Mevcutlu)";
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