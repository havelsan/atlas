
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
    /// Karşılaştırmalı Fiyat Listesi Raporu
    /// </summary>
    public partial class ComparativePriceListReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string PROCEDURE = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public ComparativePriceListReport MyParentReport
            {
                get { return (ComparativePriceListReport)ParentReport; }
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
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField PROCEDURE { get {return Header().PROCEDURE;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField NewField1222 { get {return Header().NewField1222;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField123 { get {return Header().NewField123;} }
            public TTReportField PROCEDURENAME { get {return Header().PROCEDURENAME;} }
            public TTReportField PROCEDURECODE { get {return Header().PROCEDURECODE;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
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
                public ComparativePriceListReport MyParentReport
                {
                    get { return (ComparativePriceListReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField PROCEDURE;
                public TTReportField NewField121;
                public TTReportField NewField122;
                public TTReportField NewField1221;
                public TTReportField NewField1222;
                public TTReportField NewField1121;
                public TTReportField NewField11211;
                public TTReportShape NewLine1;
                public TTReportField NewField12;
                public TTReportField NewField123;
                public TTReportField PROCEDURENAME;
                public TTReportField PROCEDURECODE;
                public TTReportField LOGO; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 45;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 8, 179, 28, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"KARŞILAŞTIRMALI FİYAT LİSTESİ";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 30, 27, 35, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Hizmet Adı  :";

                    PROCEDURE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 30, 293, 35, false);
                    PROCEDURE.Name = "PROCEDURE";
                    PROCEDURE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDURE.Value = @"{%PROCEDURECODE%}  {%PROCEDURENAME%}";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 38, 132, 43, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Fiyat Açıklaması";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 38, 208, 43, false);
                    NewField122.Name = "NewField122";
                    NewField122.MultiLine = EvetHayirEnum.ehEvet;
                    NewField122.NoClip = EvetHayirEnum.ehEvet;
                    NewField122.WordBreak = EvetHayirEnum.ehEvet;
                    NewField122.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"Başlangıç Tarihi";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 38, 157, 43, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @"Fiyat Listesi";

                    NewField1222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 38, 229, 43, false);
                    NewField1222.Name = "NewField1222";
                    NewField1222.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1222.NoClip = EvetHayirEnum.ehEvet;
                    NewField1222.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1222.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1222.TextFont.Bold = true;
                    NewField1222.TextFont.CharSet = 162;
                    NewField1222.Value = @"Bitiş Tarihi";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 38, 293, 43, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Fiyat Grubu";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 38, 181, 43, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Fiyat";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 44, 293, 44, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 38, 39, 43, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Fiyat Kodu";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 38, 20, 43, false);
                    NewField123.Name = "NewField123";
                    NewField123.TextFont.Bold = true;
                    NewField123.TextFont.CharSet = 162;
                    NewField123.Value = @"Sıra No";

                    PROCEDURENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 13, 331, 18, false);
                    PROCEDURENAME.Name = "PROCEDURENAME";
                    PROCEDURENAME.Visible = EvetHayirEnum.ehHayir;
                    PROCEDURENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDURENAME.ObjectDefName = "ProcedureDefinition";
                    PROCEDURENAME.DataMember = "NAME";
                    PROCEDURENAME.Value = @"{@PROCEDURE@}";

                    PROCEDURECODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 7, 331, 12, false);
                    PROCEDURECODE.Name = "PROCEDURECODE";
                    PROCEDURECODE.Visible = EvetHayirEnum.ehHayir;
                    PROCEDURECODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDURECODE.ObjectDefName = "ProcedureDefinition";
                    PROCEDURECODE.DataMember = "CODE";
                    PROCEDURECODE.Value = @"{@PROCEDURE@}";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 8, 49, 28, false);
                    LOGO.Name = "LOGO";
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    PROCEDURECODE.CalcValue = MyParentReport.RuntimeParameters.PROCEDURE.ToString();
                    PROCEDURECODE.PostFieldValueCalculation();
                    PROCEDURENAME.CalcValue = MyParentReport.RuntimeParameters.PROCEDURE.ToString();
                    PROCEDURENAME.PostFieldValueCalculation();
                    PROCEDURE.CalcValue = MyParentReport.PARTA.PROCEDURECODE.CalcValue + @"  " + MyParentReport.PARTA.PROCEDURENAME.CalcValue;
                    NewField121.CalcValue = NewField121.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField1222.CalcValue = NewField1222.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField123.CalcValue = NewField123.Value;
                    LOGO.CalcValue = LOGO.Value;
                    return new TTReportObject[] { NewField1,NewField2,PROCEDURECODE,PROCEDURENAME,PROCEDURE,NewField121,NewField122,NewField1221,NewField1222,NewField1121,NewField11211,NewField12,NewField123,LOGO};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ComparativePriceListReport MyParentReport
                {
                    get { return (ComparativePriceListReport)ParentReport; }
                }
                
                public TTReportShape NewLine111;
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportField PrintDate; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 1, 293, 1, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 2, 179, 7, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 268, 2, 293, 7, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 2, 40, 7, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    CURRENTUSER.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PageNumber,PrintDate,CURRENTUSER};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public ComparativePriceListReport MyParentReport
            {
                get { return (ComparativePriceListReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField CODE { get {return Body().CODE;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField PRICELIST { get {return Body().PRICELIST;} }
            public TTReportField DATESTART { get {return Body().DATESTART;} }
            public TTReportField DATEEND { get {return Body().DATEEND;} }
            public TTReportField PRICE { get {return Body().PRICE;} }
            public TTReportField GROUP { get {return Body().GROUP;} }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
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
                list[0] = new TTReportNqlData<ProcedurePriceDefinition.ProcedurePriceListByProcedure_Class>("ProcedurePriceListByProcedure", ProcedurePriceDefinition.ProcedurePriceListByProcedure((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.PROCEDURE)));
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
                public ComparativePriceListReport MyParentReport
                {
                    get { return (ComparativePriceListReport)ParentReport; }
                }
                
                public TTReportField CODE;
                public TTReportField DESCRIPTION;
                public TTReportField PRICELIST;
                public TTReportField DATESTART;
                public TTReportField DATEEND;
                public TTReportField PRICE;
                public TTReportField GROUP;
                public TTReportField SIRANO; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 1, 39, 6, false);
                    CODE.Name = "CODE";
                    CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODE.TextFont.CharSet = 162;
                    CODE.Value = @"{#EXTERNALCODE#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 1, 132, 6, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{#DESCRIPTION#}";

                    PRICELIST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 1, 156, 6, false);
                    PRICELIST.Name = "PRICELIST";
                    PRICELIST.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICELIST.TextFont.CharSet = 162;
                    PRICELIST.Value = @"{#PRICELISTNAME#}";

                    DATESTART = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 1, 208, 6, false);
                    DATESTART.Name = "DATESTART";
                    DATESTART.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATESTART.TextFormat = @"Short Date";
                    DATESTART.TextFont.CharSet = 162;
                    DATESTART.Value = @"{#DATESTART#}";

                    DATEEND = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 1, 229, 6, false);
                    DATEEND.Name = "DATEEND";
                    DATEEND.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATEEND.TextFormat = @"Short Date";
                    DATEEND.TextFont.CharSet = 162;
                    DATEEND.Value = @"{#DATEEND#}";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 1, 181, 6, false);
                    PRICE.Name = "PRICE";
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"#,##0.#0";
                    PRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICE.TextFont.CharSet = 162;
                    PRICE.Value = @"{#PRICE#}";

                    GROUP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 1, 293, 6, false);
                    GROUP.Name = "GROUP";
                    GROUP.FieldType = ReportFieldTypeEnum.ftVariable;
                    GROUP.MultiLine = EvetHayirEnum.ehEvet;
                    GROUP.NoClip = EvetHayirEnum.ehEvet;
                    GROUP.WordBreak = EvetHayirEnum.ehEvet;
                    GROUP.ExpandTabs = EvetHayirEnum.ehEvet;
                    GROUP.TextFont.CharSet = 162;
                    GROUP.Value = @"{#PRICEGROUPCODE#} {#PRICEGROUPNAME#}";

                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 20, 6, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ProcedurePriceDefinition.ProcedurePriceListByProcedure_Class dataset_ProcedurePriceListByProcedure = ParentGroup.rsGroup.GetCurrentRecord<ProcedurePriceDefinition.ProcedurePriceListByProcedure_Class>(0);
                    CODE.CalcValue = (dataset_ProcedurePriceListByProcedure != null ? Globals.ToStringCore(dataset_ProcedurePriceListByProcedure.ExternalCode) : "");
                    DESCRIPTION.CalcValue = (dataset_ProcedurePriceListByProcedure != null ? Globals.ToStringCore(dataset_ProcedurePriceListByProcedure.Description) : "");
                    PRICELIST.CalcValue = (dataset_ProcedurePriceListByProcedure != null ? Globals.ToStringCore(dataset_ProcedurePriceListByProcedure.Pricelistname) : "");
                    DATESTART.CalcValue = (dataset_ProcedurePriceListByProcedure != null ? Globals.ToStringCore(dataset_ProcedurePriceListByProcedure.DateStart) : "");
                    DATEEND.CalcValue = (dataset_ProcedurePriceListByProcedure != null ? Globals.ToStringCore(dataset_ProcedurePriceListByProcedure.DateEnd) : "");
                    PRICE.CalcValue = (dataset_ProcedurePriceListByProcedure != null ? Globals.ToStringCore(dataset_ProcedurePriceListByProcedure.Price) : "");
                    GROUP.CalcValue = (dataset_ProcedurePriceListByProcedure != null ? Globals.ToStringCore(dataset_ProcedurePriceListByProcedure.Pricegroupcode) : "") + @" " + (dataset_ProcedurePriceListByProcedure != null ? Globals.ToStringCore(dataset_ProcedurePriceListByProcedure.Pricegroupname) : "");
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    return new TTReportObject[] { CODE,DESCRIPTION,PRICELIST,DATESTART,DATEEND,PRICE,GROUP,SIRANO};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ComparativePriceListReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("PROCEDURE", "", "Hizmet", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("9fa2796c-e744-4d0f-9dc3-71c5053c23fd");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("PROCEDURE"))
                _runtimeParameters.PROCEDURE = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["PROCEDURE"]);
            Name = "COMPARATIVEPRICELISTREPORT";
            Caption = "Karşılaştırmalı Fiyat Listesi";
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