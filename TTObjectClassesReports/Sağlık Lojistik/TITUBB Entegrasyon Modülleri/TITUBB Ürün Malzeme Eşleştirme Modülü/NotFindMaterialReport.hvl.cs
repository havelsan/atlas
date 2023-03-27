
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
    /// TITUBB'da Bulunamayan Malzemeler
    /// </summary>
    public partial class NotFindMaterialReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public NotFindMaterialReport MyParentReport
            {
                get { return (NotFindMaterialReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField ReportName11 { get {return Header().ReportName11;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportField Ürün_Numarası11 { get {return Header().Ürün_Numarası11;} }
            public TTReportField Etiket_Adı11 { get {return Header().Etiket_Adı11;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportShape NewLine121 { get {return Header().NewLine121;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportField Etiket_Adı111 { get {return Header().Etiket_Adı111;} }
            public TTReportShape NewLine112 { get {return Header().NewLine112;} }
            public TTReportShape NewLine113 { get {return Header().NewLine113;} }
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
                public NotFindMaterialReport MyParentReport
                {
                    get { return (NotFindMaterialReport)ParentReport; }
                }
                
                public TTReportField ReportName11;
                public TTReportShape NewLine111;
                public TTReportField Ürün_Numarası11;
                public TTReportField Etiket_Adı11;
                public TTReportShape NewLine11;
                public TTReportShape NewLine121;
                public TTReportShape NewLine1111;
                public TTReportField Etiket_Adı111;
                public TTReportShape NewLine112;
                public TTReportShape NewLine113; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 36;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ReportName11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 4, 202, 24, false);
                    ReportName11.Name = "ReportName11";
                    ReportName11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName11.TextFont.Size = 15;
                    ReportName11.TextFont.Bold = true;
                    ReportName11.TextFont.CharSet = 162;
                    ReportName11.Value = @"TITUBB'DA BULUNAMAYAN MALZEMELER";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 3, 29, 202, 29, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                    Ürün_Numarası11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 30, 28, 35, false);
                    Ürün_Numarası11.Name = "Ürün_Numarası11";
                    Ürün_Numarası11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Ürün_Numarası11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Ürün_Numarası11.TextFont.Bold = true;
                    Ürün_Numarası11.TextFont.CharSet = 162;
                    Ürün_Numarası11.Value = @"Nato Stok Nu";

                    Etiket_Adı11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 30, 172, 35, false);
                    Etiket_Adı11.Name = "Etiket_Adı11";
                    Etiket_Adı11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Etiket_Adı11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Etiket_Adı11.TextFont.Bold = true;
                    Etiket_Adı11.TextFont.CharSet = 162;
                    Etiket_Adı11.Value = @"Malzeme Adı";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 28, 29, 28, 36, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 3, 29, 3, 36, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.DrawWidth = 2;

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 3, 36, 202, 36, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.DrawWidth = 2;

                    Etiket_Adı111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 30, 200, 35, false);
                    Etiket_Adı111.Name = "Etiket_Adı111";
                    Etiket_Adı111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Etiket_Adı111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Etiket_Adı111.TextFont.Bold = true;
                    Etiket_Adı111.TextFont.CharSet = 162;
                    Etiket_Adı111.Value = @"Malzeme Barkodu";

                    NewLine112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 173, 29, 173, 36, false);
                    NewLine112.Name = "NewLine112";
                    NewLine112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine112.DrawWidth = 2;

                    NewLine113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 202, 29, 202, 36, false);
                    NewLine113.Name = "NewLine113";
                    NewLine113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine113.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReportName11.CalcValue = ReportName11.Value;
                    Ürün_Numarası11.CalcValue = Ürün_Numarası11.Value;
                    Etiket_Adı11.CalcValue = Etiket_Adı11.Value;
                    Etiket_Adı111.CalcValue = Etiket_Adı111.Value;
                    return new TTReportObject[] { ReportName11,Ürün_Numarası11,Etiket_Adı11,Etiket_Adı111};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public NotFindMaterialReport MyParentReport
                {
                    get { return (NotFindMaterialReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public NotFindMaterialReport MyParentReport
            {
                get { return (NotFindMaterialReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField BARCODE { get {return Body().BARCODE;} }
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
                list[0] = new TTReportNqlData<Material.ProductNotMatchMaterialQuery_Class>("ProductNotMatchMaterialQuery", Material.ProductNotMatchMaterialQuery());
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
                public NotFindMaterialReport MyParentReport
                {
                    get { return (NotFindMaterialReport)ParentReport; }
                }
                
                public TTReportField OBJECTID;
                public TTReportField NATOSTOCKNO;
                public TTReportField BARCODE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 0, 173, 5, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.DrawStyle = DrawStyleConstants.vbSolid;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.ObjectDefName = "Material";
                    OBJECTID.DataMember = "NAME";
                    OBJECTID.Value = @"{#OBJECTID#}";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 0, 28, 5, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    BARCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 0, 202, 5, false);
                    BARCODE.Name = "BARCODE";
                    BARCODE.DrawStyle = DrawStyleConstants.vbSolid;
                    BARCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BARCODE.Value = @"{#BARCODE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Material.ProductNotMatchMaterialQuery_Class dataset_ProductNotMatchMaterialQuery = ParentGroup.rsGroup.GetCurrentRecord<Material.ProductNotMatchMaterialQuery_Class>(0);
                    OBJECTID.CalcValue = (dataset_ProductNotMatchMaterialQuery != null ? Globals.ToStringCore(dataset_ProductNotMatchMaterialQuery.ObjectID) : "");
                    OBJECTID.PostFieldValueCalculation();
                    NATOSTOCKNO.CalcValue = (dataset_ProductNotMatchMaterialQuery != null ? Globals.ToStringCore(dataset_ProductNotMatchMaterialQuery.NATOStockNO) : "");
                    BARCODE.CalcValue = (dataset_ProductNotMatchMaterialQuery != null ? Globals.ToStringCore(dataset_ProductNotMatchMaterialQuery.Barcode) : "");
                    return new TTReportObject[] { OBJECTID,NATOSTOCKNO,BARCODE};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public NotFindMaterialReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            Name = "NOTFINDMATERIALREPORT";
            Caption = "TITUBB'da Bulunamayan Malzemeler";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
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