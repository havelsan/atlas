
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
    /// Depo Mevcudu Raporu ( Malzeme Grubuna Göre)
    /// </summary>
    public partial class StockInheldByMaterialTree : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? MATERIALTREEID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public StockInheldByMaterialTree MyParentReport
            {
                get { return (StockInheldByMaterialTree)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField REPORTNAME11 { get {return Header().REPORTNAME11;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PAGENUMBER { get {return Footer().PAGENUMBER;} }
            public TTReportShape NewLine11111 { get {return Footer().NewLine11111;} }
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
                public StockInheldByMaterialTree MyParentReport
                {
                    get { return (StockInheldByMaterialTree)ParentReport; }
                }
                
                public TTReportField REPORTNAME11; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 23;
                    RepeatCount = 0;
                    
                    REPORTNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 9, 207, 21, false);
                    REPORTNAME11.Name = "REPORTNAME11";
                    REPORTNAME11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME11.TextFont.Size = 15;
                    REPORTNAME11.TextFont.Bold = true;
                    REPORTNAME11.Value = @"DEPO MEVCUDU RAPORU ( MALZEME GRUBUNA GÖRE )";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME11.CalcValue = REPORTNAME11.Value;
                    return new TTReportObject[] { REPORTNAME11};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public StockInheldByMaterialTree MyParentReport
                {
                    get { return (StockInheldByMaterialTree)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CURRENTUSER;
                public TTReportField PAGENUMBER;
                public TTReportShape NewLine11111; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 32, 6, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Size = 8;
                    PrintDate.Value = @"{@printdate@}";

                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 1, 114, 6, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 1, 206, 6, false);
                    PAGENUMBER.Name = "PAGENUMBER";
                    PAGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGENUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER.TextFont.Size = 8;
                    PAGENUMBER.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 1, 207, 1, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PAGENUMBER.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CURRENTUSER.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate,PAGENUMBER,CURRENTUSER};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public StockInheldByMaterialTree MyParentReport
            {
                get { return (StockInheldByMaterialTree)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField MATERIALTREENAME { get {return Header().MATERIALTREENAME;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField MATERIALTREECODE { get {return Header().MATERIALTREECODE;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Stock.GetStockInheldByMaterialTreeRQ_Class>("GetStockInheldByMaterialTreeRQ", Stock.GetStockInheldByMaterialTreeRQ((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MATERIALTREEID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public StockInheldByMaterialTree MyParentReport
                {
                    get { return (StockInheldByMaterialTree)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField NewField2;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField MATERIALTREENAME;
                public TTReportField NewField3;
                public TTReportField NewField14;
                public TTReportField MATERIALTREECODE;
                public TTReportField NewField121;
                public TTReportField NewField141; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 28;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 23, 189, 28, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"Malzeme Adı";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 23, 74, 28, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"Barkod";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 23, 45, 28, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 11;
                    NewField111.TextFont.Bold = true;
                    NewField111.Value = @"Taşınır Kodu";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 23, 207, 28, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Size = 11;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.Value = @"Miktar";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 3, 28, 8, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Size = 11;
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"DEPO ADI";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 15, 28, 20, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @"GRUP ADI";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 3, 207, 8, false);
                    NewField13.Name = "NewField13";
                    NewField13.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField13.ObjectDefName = "Store";
                    NewField13.DataMember = "NAME";
                    NewField13.Value = @"{@STOREID@}";

                    MATERIALTREENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 15, 207, 20, false);
                    MATERIALTREENAME.Name = "MATERIALTREENAME";
                    MATERIALTREENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALTREENAME.ObjectDefName = "MaterialTreeDefinition";
                    MATERIALTREENAME.DataMember = "NAME";
                    MATERIALTREENAME.Value = @"{@MATERIALTREEID@}";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 3, 30, 8, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @":";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 15, 30, 20, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Bold = true;
                    NewField14.Value = @":";

                    MATERIALTREECODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 9, 207, 14, false);
                    MATERIALTREECODE.Name = "MATERIALTREECODE";
                    MATERIALTREECODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALTREECODE.ObjectDefName = "MaterialTreeDefinition";
                    MATERIALTREECODE.DataMember = "GROUPCODE";
                    MATERIALTREECODE.Value = @"{@MATERIALTREEID@}";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 9, 28, 14, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Size = 11;
                    NewField121.TextFont.Bold = true;
                    NewField121.Value = @"GRUP KODU";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 9, 30, 14, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Bold = true;
                    NewField141.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Stock.GetStockInheldByMaterialTreeRQ_Class dataset_GetStockInheldByMaterialTreeRQ = ParentGroup.rsGroup.GetCurrentRecord<Stock.GetStockInheldByMaterialTreeRQ_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = MyParentReport.RuntimeParameters.STOREID.ToString();
                    NewField13.PostFieldValueCalculation();
                    MATERIALTREENAME.CalcValue = MyParentReport.RuntimeParameters.MATERIALTREEID.ToString();
                    MATERIALTREENAME.PostFieldValueCalculation();
                    NewField3.CalcValue = NewField3.Value;
                    NewField14.CalcValue = NewField14.Value;
                    MATERIALTREECODE.CalcValue = MyParentReport.RuntimeParameters.MATERIALTREEID.ToString();
                    MATERIALTREECODE.PostFieldValueCalculation();
                    NewField121.CalcValue = NewField121.Value;
                    NewField141.CalcValue = NewField141.Value;
                    return new TTReportObject[] { NewField1,NewField11,NewField111,NewField1111,NewField2,NewField12,NewField13,MATERIALTREENAME,NewField3,NewField14,MATERIALTREECODE,NewField121,NewField141};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public StockInheldByMaterialTree MyParentReport
                {
                    get { return (StockInheldByMaterialTree)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public StockInheldByMaterialTree MyParentReport
            {
                get { return (StockInheldByMaterialTree)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField BARCODE { get {return Body().BARCODE;} }
            public TTReportField TOPLAMMIKTAR { get {return Body().TOPLAMMIKTAR;} }
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

                Stock.GetStockInheldByMaterialTreeRQ_Class dataSet_GetStockInheldByMaterialTreeRQ = ParentGroup.rsGroup.GetCurrentRecord<Stock.GetStockInheldByMaterialTreeRQ_Class>(0);    
                return new object[] {(dataSet_GetStockInheldByMaterialTreeRQ==null ? null : dataSet_GetStockInheldByMaterialTreeRQ.Materialtreename)};
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
                public StockInheldByMaterialTree MyParentReport
                {
                    get { return (StockInheldByMaterialTree)ParentReport; }
                }
                
                public TTReportField NATOSTOCKNO;
                public TTReportField MATERIALNAME;
                public TTReportField BARCODE;
                public TTReportField TOPLAMMIKTAR; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 0, 45, 5, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.Value = @"{#PARTA.NATOSTOCKNO#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 0, 189, 5, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.Value = @"{#PARTA.MATERIALNAME#}";

                    BARCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 0, 74, 5, false);
                    BARCODE.Name = "BARCODE";
                    BARCODE.DrawStyle = DrawStyleConstants.vbSolid;
                    BARCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BARCODE.Value = @"{#PARTA.BARCODE#}";

                    TOPLAMMIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 0, 207, 5, false);
                    TOPLAMMIKTAR.Name = "TOPLAMMIKTAR";
                    TOPLAMMIKTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    TOPLAMMIKTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMMIKTAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOPLAMMIKTAR.Value = @"{#PARTA.TOPLAMMIKTAR#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Stock.GetStockInheldByMaterialTreeRQ_Class dataset_GetStockInheldByMaterialTreeRQ = MyParentReport.PARTA.rsGroup.GetCurrentRecord<Stock.GetStockInheldByMaterialTreeRQ_Class>(0);
                    NATOSTOCKNO.CalcValue = (dataset_GetStockInheldByMaterialTreeRQ != null ? Globals.ToStringCore(dataset_GetStockInheldByMaterialTreeRQ.NATOStockNO) : "");
                    MATERIALNAME.CalcValue = (dataset_GetStockInheldByMaterialTreeRQ != null ? Globals.ToStringCore(dataset_GetStockInheldByMaterialTreeRQ.Materialname) : "");
                    BARCODE.CalcValue = (dataset_GetStockInheldByMaterialTreeRQ != null ? Globals.ToStringCore(dataset_GetStockInheldByMaterialTreeRQ.Barcode) : "");
                    TOPLAMMIKTAR.CalcValue = (dataset_GetStockInheldByMaterialTreeRQ != null ? Globals.ToStringCore(dataset_GetStockInheldByMaterialTreeRQ.Toplammiktar) : "");
                    return new TTReportObject[] { NATOSTOCKNO,MATERIALNAME,BARCODE,TOPLAMMIKTAR};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public StockInheldByMaterialTree()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STOREID", "00000000-0000-0000-0000-000000000000", "Depo", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("65405b70-5e35-4486-b140-c95af3d8bf5d");
            reportParameter = Parameters.Add("MATERIALTREEID", "00000000-0000-0000-0000-000000000000", "Malzeme Grubu", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("bacc77d4-3d6b-40d9-b15c-ba661678d270");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STOREID"))
                _runtimeParameters.STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STOREID"]);
            if (parameters.ContainsKey("MATERIALTREEID"))
                _runtimeParameters.MATERIALTREEID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["MATERIALTREEID"]);
            Name = "STOCKINHELDBYMATERIALTREE";
            Caption = "Depo Mevcudu Raporu ( Malzeme Grubuna Göre)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
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
            fd.TextFont.CharSet = 162;
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