
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
    /// Reçete Takip Raporu
    /// </summary>
    public partial class PrescriptionDetailInformationReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? MATERIAL = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public int? ALLSTORE = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public PrescriptionDetailInformationReport MyParentReport
            {
                get { return (PrescriptionDetailInformationReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField MATERIAL12 { get {return Header().MATERIAL12;} }
            public TTReportField MATERIAL121 { get {return Header().MATERIAL121;} }
            public TTReportField MATERIAL1121 { get {return Header().MATERIAL1121;} }
            public TTReportField MATERIAL11211 { get {return Header().MATERIAL11211;} }
            public TTReportField ReportName111 { get {return Header().ReportName111;} }
            public TTReportField DEPO { get {return Header().DEPO;} }
            public TTReportField StoreName { get {return Header().StoreName;} }
            public TTReportField PrescriptionType { get {return Header().PrescriptionType;} }
            public TTReportField ReceteTuru { get {return Header().ReceteTuru;} }
            public TTReportField HOSPITAL11 { get {return Header().HOSPITAL11;} }
            public TTReportField PrintDate11 { get {return Footer().PrintDate11;} }
            public TTReportField PageNumber11 { get {return Footer().PageNumber11;} }
            public TTReportField CurrentUser11 { get {return Footer().CurrentUser11;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
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
                public PrescriptionDetailInformationReport MyParentReport
                {
                    get { return (PrescriptionDetailInformationReport)ParentReport; }
                }
                
                public TTReportField MATERIAL12;
                public TTReportField MATERIAL121;
                public TTReportField MATERIAL1121;
                public TTReportField MATERIAL11211;
                public TTReportField ReportName111;
                public TTReportField DEPO;
                public TTReportField StoreName;
                public TTReportField PrescriptionType;
                public TTReportField ReceteTuru;
                public TTReportField HOSPITAL11; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 61;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    MATERIAL12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 56, 22, 61, false);
                    MATERIAL12.Name = "MATERIAL12";
                    MATERIAL12.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIAL12.TextFont.Bold = true;
                    MATERIAL12.TextFont.CharSet = 162;
                    MATERIAL12.Value = @"Sıra No";

                    MATERIAL121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 56, 148, 61, false);
                    MATERIAL121.Name = "MATERIAL121";
                    MATERIAL121.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIAL121.TextFont.Bold = true;
                    MATERIAL121.TextFont.CharSet = 162;
                    MATERIAL121.Value = @"BULUNDUĞU YER";

                    MATERIAL1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 56, 199, 61, false);
                    MATERIAL1121.Name = "MATERIAL1121";
                    MATERIAL1121.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIAL1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIAL1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIAL1121.TextFont.Bold = true;
                    MATERIAL1121.TextFont.CharSet = 162;
                    MATERIAL1121.Value = @"Numarası";

                    MATERIAL11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 56, 174, 61, false);
                    MATERIAL11211.Name = "MATERIAL11211";
                    MATERIAL11211.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIAL11211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIAL11211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIAL11211.TextFont.Bold = true;
                    MATERIAL11211.TextFont.CharSet = 162;
                    MATERIAL11211.Value = @"Seri Numarası";

                    ReportName111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 19, 205, 33, false);
                    ReportName111.Name = "ReportName111";
                    ReportName111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName111.TextFont.Size = 13;
                    ReportName111.TextFont.Bold = true;
                    ReportName111.TextFont.CharSet = 162;
                    ReportName111.Value = @"REÇETE TAKİP RAPORU";

                    DEPO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 44, 35, 49, false);
                    DEPO.Name = "DEPO";
                    DEPO.DrawStyle = DrawStyleConstants.vbSolid;
                    DEPO.TextFont.Bold = true;
                    DEPO.TextFont.CharSet = 162;
                    DEPO.Value = @"Depo Adı :";

                    StoreName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 44, 199, 49, false);
                    StoreName.Name = "StoreName";
                    StoreName.DrawStyle = DrawStyleConstants.vbSolid;
                    StoreName.FieldType = ReportFieldTypeEnum.ftVariable;
                    StoreName.Value = @"";

                    PrescriptionType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 39, 199, 44, false);
                    PrescriptionType.Name = "PrescriptionType";
                    PrescriptionType.DrawStyle = DrawStyleConstants.vbSolid;
                    PrescriptionType.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrescriptionType.ObjectDefName = "Material";
                    PrescriptionType.DataMember = "Name";
                    PrescriptionType.Value = @"{@MATERIAL@}";

                    ReceteTuru = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 39, 35, 44, false);
                    ReceteTuru.Name = "ReceteTuru";
                    ReceteTuru.DrawStyle = DrawStyleConstants.vbSolid;
                    ReceteTuru.TextFont.Bold = true;
                    ReceteTuru.TextFont.CharSet = 162;
                    ReceteTuru.Value = @"Reçete Türü :";

                    HOSPITAL11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 3, 205, 17, false);
                    HOSPITAL11.Name = "HOSPITAL11";
                    HOSPITAL11.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITAL11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITAL11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITAL11.TextFont.Name = "Arial";
                    HOSPITAL11.TextFont.Size = 11;
                    HOSPITAL11.TextFont.Bold = true;
                    HOSPITAL11.TextFont.CharSet = 162;
                    HOSPITAL11.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MATERIAL12.CalcValue = MATERIAL12.Value;
                    MATERIAL121.CalcValue = MATERIAL121.Value;
                    MATERIAL1121.CalcValue = MATERIAL1121.Value;
                    MATERIAL11211.CalcValue = MATERIAL11211.Value;
                    ReportName111.CalcValue = ReportName111.Value;
                    DEPO.CalcValue = DEPO.Value;
                    StoreName.CalcValue = @"";
                    PrescriptionType.CalcValue = MyParentReport.RuntimeParameters.MATERIAL.ToString();
                    PrescriptionType.PostFieldValueCalculation();
                    ReceteTuru.CalcValue = ReceteTuru.Value;
                    HOSPITAL11.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { MATERIAL12,MATERIAL121,MATERIAL1121,MATERIAL11211,ReportName111,DEPO,StoreName,PrescriptionType,ReceteTuru,HOSPITAL11};
                }
                public override void RunPreScript()
                {
#region PARTA HEADER_PreScript
                    if (MyParentReport.RuntimeParameters.STORE == Guid.Empty)
                MyParentReport.RuntimeParameters.ALLSTORE = 1;
            else
                MyParentReport.RuntimeParameters.ALLSTORE = 0;
#endregion PARTA HEADER_PreScript
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    if (MyParentReport.RuntimeParameters.ALLSTORE == 0)
            {
                TTObjectContext context = new TTObjectContext(true);
                Store store = (Store)context.GetObject((Guid)MyParentReport.RuntimeParameters.STORE, typeof(Store));
                StoreName.CalcValue = store.Name;
            }
            else
                StoreName.CalcValue = "";
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public PrescriptionDetailInformationReport MyParentReport
                {
                    get { return (PrescriptionDetailInformationReport)ParentReport; }
                }
                
                public TTReportField PrintDate11;
                public TTReportField PageNumber11;
                public TTReportField CurrentUser11;
                public TTReportShape NewLine1111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 17;
                    RepeatCount = 0;
                    
                    PrintDate11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 33, 5, false);
                    PrintDate11.Name = "PrintDate11";
                    PrintDate11.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate11.TextFont.Size = 8;
                    PrintDate11.TextFont.CharSet = 162;
                    PrintDate11.Value = @"{@printdate@}";

                    PageNumber11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, -1, 205, 4, false);
                    PageNumber11.Name = "PageNumber11";
                    PageNumber11.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber11.TextFont.Size = 8;
                    PageNumber11.TextFont.CharSet = 162;
                    PageNumber11.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    CurrentUser11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 0, 121, 5, false);
                    CurrentUser11.Name = "CurrentUser11";
                    CurrentUser11.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser11.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser11.TextFont.Size = 8;
                    CurrentUser11.TextFont.CharSet = 162;
                    CurrentUser11.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 0, 205, 0, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate11.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber11.CalcValue = @"Sayfa Nu." + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser11.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate11,PageNumber11,CurrentUser11};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public PrescriptionDetailInformationReport MyParentReport
            {
                get { return (PrescriptionDetailInformationReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SERIALNO { get {return Body().SERIALNO;} }
            public TTReportField VOLUMENO { get {return Body().VOLUMENO;} }
            public TTReportField STORENAME { get {return Body().STORENAME;} }
            public TTReportField ORDERNO1 { get {return Body().ORDERNO1;} }
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
                list[0] = new TTReportNqlData<PrescriptionPaper.GetPrescriptionPapersDetail_Class>("GetPrescriptionPapersDetail2", PrescriptionPaper.GetPrescriptionPapersDetail((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MATERIAL),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STORE),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.ALLSTORE)));
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
                public PrescriptionDetailInformationReport MyParentReport
                {
                    get { return (PrescriptionDetailInformationReport)ParentReport; }
                }
                
                public TTReportField SERIALNO;
                public TTReportField VOLUMENO;
                public TTReportField STORENAME;
                public TTReportField ORDERNO1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 4;
                    RepeatCount = 0;
                    
                    SERIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 0, 174, 5, false);
                    SERIALNO.Name = "SERIALNO";
                    SERIALNO.DrawStyle = DrawStyleConstants.vbSolid;
                    SERIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERIALNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SERIALNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SERIALNO.Value = @"{#SERIALNO#}";

                    VOLUMENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 0, 199, 5, false);
                    VOLUMENO.Name = "VOLUMENO";
                    VOLUMENO.DrawStyle = DrawStyleConstants.vbSolid;
                    VOLUMENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    VOLUMENO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    VOLUMENO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    VOLUMENO.Value = @"{#VOLUMENO#}";

                    STORENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 0, 148, 5, false);
                    STORENAME.Name = "STORENAME";
                    STORENAME.DrawStyle = DrawStyleConstants.vbSolid;
                    STORENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STORENAME.Value = @"{#STORENAME#}";

                    ORDERNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 0, 22, 5, false);
                    ORDERNO1.Name = "ORDERNO1";
                    ORDERNO1.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO1.TextFont.Size = 9;
                    ORDERNO1.TextFont.CharSet = 162;
                    ORDERNO1.Value = @"{@counter@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrescriptionPaper.GetPrescriptionPapersDetail_Class dataset_GetPrescriptionPapersDetail2 = ParentGroup.rsGroup.GetCurrentRecord<PrescriptionPaper.GetPrescriptionPapersDetail_Class>(0);
                    SERIALNO.CalcValue = (dataset_GetPrescriptionPapersDetail2 != null ? Globals.ToStringCore(dataset_GetPrescriptionPapersDetail2.SerialNo) : "");
                    VOLUMENO.CalcValue = (dataset_GetPrescriptionPapersDetail2 != null ? Globals.ToStringCore(dataset_GetPrescriptionPapersDetail2.VolumeNo) : "");
                    STORENAME.CalcValue = (dataset_GetPrescriptionPapersDetail2 != null ? Globals.ToStringCore(dataset_GetPrescriptionPapersDetail2.Storename) : "");
                    ORDERNO1.CalcValue = ParentGroup.Counter.ToString();
                    return new TTReportObject[] { SERIALNO,VOLUMENO,STORENAME,ORDERNO1};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public PrescriptionDetailInformationReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("MATERIAL", "00000000-0000-0000-0000-000000000000", "Malzeme", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("af1a7c6a-7e8b-4bc1-ac89-f800f14f259b");
            reportParameter = Parameters.Add("STORE", "00000000-0000-0000-0000-000000000000", "Depo", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("65405b70-5e35-4486-b140-c95af3d8bf5d");
            reportParameter = Parameters.Add("ALLSTORE", "", "Tüm Depolar", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter.ListDefID = new Guid("65405b70-5e35-4486-b140-c95af3d8bf5d");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("MATERIAL"))
                _runtimeParameters.MATERIAL = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["MATERIAL"]);
            if (parameters.ContainsKey("STORE"))
                _runtimeParameters.STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STORE"]);
            if (parameters.ContainsKey("ALLSTORE"))
                _runtimeParameters.ALLSTORE = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["ALLSTORE"]);
            Name = "PRESCRIPTIONDETAILINFORMATIONREPORT";
            Caption = "Reçete Takip Raporu";
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