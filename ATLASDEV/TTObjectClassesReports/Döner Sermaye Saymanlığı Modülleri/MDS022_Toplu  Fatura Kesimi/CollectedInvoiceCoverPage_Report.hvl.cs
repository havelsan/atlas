
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
    /// Toplu Fatura Kapak Sayfası
    /// </summary>
    public partial class CollectedInvoiceCoverPage : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public CollectedInvoiceCoverPage MyParentReport
            {
                get { return (CollectedInvoiceCoverPage)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

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
                public CollectedInvoiceCoverPage MyParentReport
                {
                    get { return (CollectedInvoiceCoverPage)ParentReport; }
                }
                 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public CollectedInvoiceCoverPage MyParentReport
                {
                    get { return (CollectedInvoiceCoverPage)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class HEADGroup : TTReportGroup
        {
            public CollectedInvoiceCoverPage MyParentReport
            {
                get { return (CollectedInvoiceCoverPage)ParentReport; }
            }

            new public HEADGroupHeader Header()
            {
                return (HEADGroupHeader)_header;
            }

            new public HEADGroupFooter Footer()
            {
                return (HEADGroupFooter)_footer;
            }

            public TTReportField UZMANLIKADI { get {return Header().UZMANLIKADI;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportField FATURANO { get {return Header().FATURANO;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportShape NewLine1112 { get {return Header().NewLine1112;} }
            public TTReportField XXXXXXADI { get {return Header().XXXXXXADI;} }
            public TTReportField HASTASAYISI { get {return Header().HASTASAYISI;} }
            public TTReportField KLASORSAYISI { get {return Header().KLASORSAYISI;} }
            public TTReportField YIL { get {return Header().YIL;} }
            public TTReportField TARIHARALIGI { get {return Header().TARIHARALIGI;} }
            public TTReportField AYAKTANYATAN { get {return Header().AYAKTANYATAN;} }
            public TTReportField XXXXXXKODU { get {return Header().XXXXXXKODU;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField PATIENTSTATUS { get {return Header().PATIENTSTATUS;} }
            public TTReportField EPISODECOUNT { get {return Header().EPISODECOUNT;} }
            public TTReportField TOTALPRICE { get {return Header().TOTALPRICE;} }
            public TTReportField DOCUMENTNO { get {return Header().DOCUMENTNO;} }
            public HEADGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<CollectedPatientList.CollectedInvoiceCoverPageQuery_Class>("CollectedInvoiceCoverPageQuery", CollectedPatientList.CollectedInvoiceCoverPageQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADGroupHeader(this);
                _footer = new HEADGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HEADGroupHeader : TTReportSection
            {
                public CollectedInvoiceCoverPage MyParentReport
                {
                    get { return (CollectedInvoiceCoverPage)ParentReport; }
                }
                
                public TTReportField UZMANLIKADI;
                public TTReportShape NewLine111;
                public TTReportField FATURANO;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine1112;
                public TTReportField XXXXXXADI;
                public TTReportField HASTASAYISI;
                public TTReportField KLASORSAYISI;
                public TTReportField YIL;
                public TTReportField TARIHARALIGI;
                public TTReportField AYAKTANYATAN;
                public TTReportField XXXXXXKODU;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField PATIENTSTATUS;
                public TTReportField EPISODECOUNT;
                public TTReportField TOTALPRICE;
                public TTReportField DOCUMENTNO; 
                public HEADGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 266;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    UZMANLIKADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 139, 179, 151, false);
                    UZMANLIKADI.Name = "UZMANLIKADI";
                    UZMANLIKADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZMANLIKADI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    UZMANLIKADI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UZMANLIKADI.MultiLine = EvetHayirEnum.ehEvet;
                    UZMANLIKADI.NoClip = EvetHayirEnum.ehEvet;
                    UZMANLIKADI.WordBreak = EvetHayirEnum.ehEvet;
                    UZMANLIKADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    UZMANLIKADI.TextFont.Name = "Arial";
                    UZMANLIKADI.TextFont.Size = 12;
                    UZMANLIKADI.TextFont.Bold = true;
                    UZMANLIKADI.TextFont.CharSet = 162;
                    UZMANLIKADI.Value = @"{#SPECIALITYNAME#}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 29, 197, 29, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                    FATURANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 244, 185, 250, false);
                    FATURANO.Name = "FATURANO";
                    FATURANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATURANO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FATURANO.TextFont.Name = "Arial";
                    FATURANO.TextFont.Size = 12;
                    FATURANO.TextFont.Bold = true;
                    FATURANO.TextFont.CharSet = 162;
                    FATURANO.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 29, 14, 258, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 197, 29, 197, 258, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                    NewLine1112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 258, 197, 258, false);
                    NewLine1112.Name = "NewLine1112";
                    NewLine1112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1112.DrawWidth = 2;

                    XXXXXXADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 37, 179, 61, false);
                    XXXXXXADI.Name = "XXXXXXADI";
                    XXXXXXADI.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXADI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    XXXXXXADI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXADI.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXADI.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXADI.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXADI.TextFont.Name = "Arial";
                    XXXXXXADI.TextFont.Size = 12;
                    XXXXXXADI.TextFont.Bold = true;
                    XXXXXXADI.TextFont.CharSet = 162;
                    XXXXXXADI.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    HASTASAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 160, 179, 166, false);
                    HASTASAYISI.Name = "HASTASAYISI";
                    HASTASAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTASAYISI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HASTASAYISI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HASTASAYISI.TextFont.Name = "Arial";
                    HASTASAYISI.TextFont.Size = 12;
                    HASTASAYISI.TextFont.Bold = true;
                    HASTASAYISI.TextFont.CharSet = 162;
                    HASTASAYISI.Value = @"";

                    KLASORSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 180, 179, 186, false);
                    KLASORSAYISI.Name = "KLASORSAYISI";
                    KLASORSAYISI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    KLASORSAYISI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KLASORSAYISI.TextFont.Name = "Arial";
                    KLASORSAYISI.TextFont.Size = 12;
                    KLASORSAYISI.TextFont.Bold = true;
                    KLASORSAYISI.TextFont.CharSet = 162;
                    KLASORSAYISI.Value = @"............... KLASÖR";

                    YIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 74, 179, 80, false);
                    YIL.Name = "YIL";
                    YIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    YIL.CaseFormat = CaseFormatEnum.fcUpperCase;
                    YIL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YIL.TextFont.Name = "Arial";
                    YIL.TextFont.Size = 12;
                    YIL.TextFont.Bold = true;
                    YIL.TextFont.CharSet = 162;
                    YIL.Value = @"";

                    TARIHARALIGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 88, 179, 94, false);
                    TARIHARALIGI.Name = "TARIHARALIGI";
                    TARIHARALIGI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIHARALIGI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    TARIHARALIGI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TARIHARALIGI.TextFont.Name = "Arial";
                    TARIHARALIGI.TextFont.Size = 12;
                    TARIHARALIGI.TextFont.Bold = true;
                    TARIHARALIGI.TextFont.CharSet = 162;
                    TARIHARALIGI.Value = @"";

                    AYAKTANYATAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 102, 179, 108, false);
                    AYAKTANYATAN.Name = "AYAKTANYATAN";
                    AYAKTANYATAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    AYAKTANYATAN.CaseFormat = CaseFormatEnum.fcUpperCase;
                    AYAKTANYATAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AYAKTANYATAN.TextFont.Name = "Arial";
                    AYAKTANYATAN.TextFont.Size = 12;
                    AYAKTANYATAN.TextFont.Bold = true;
                    AYAKTANYATAN.TextFont.CharSet = 162;
                    AYAKTANYATAN.Value = @"";

                    XXXXXXKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 116, 179, 122, false);
                    XXXXXXKODU.Name = "XXXXXXKODU";
                    XXXXXXKODU.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXKODU.CaseFormat = CaseFormatEnum.fcUpperCase;
                    XXXXXXKODU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXKODU.TextFont.Name = "Arial";
                    XXXXXXKODU.TextFont.Size = 12;
                    XXXXXXKODU.TextFont.Bold = true;
                    XXXXXXKODU.TextFont.CharSet = 162;
                    XXXXXXKODU.Value = @"""XXXXXX KODU : "" +  TTObjectClasses.SystemParameter.GetParameterValue(""MEDULASAGLIKTESISKODU"", """")";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 12, 46, 17, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.Value = @"{#STARTDATE#}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 12, 76, 17, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.Value = @"{#ENDDATE#}";

                    PATIENTSTATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 12, 106, 17, false);
                    PATIENTSTATUS.Name = "PATIENTSTATUS";
                    PATIENTSTATUS.Visible = EvetHayirEnum.ehHayir;
                    PATIENTSTATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTSTATUS.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PATIENTSTATUS.Value = @"{#PATIENTSTATUS#}";

                    EPISODECOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 12, 137, 17, false);
                    EPISODECOUNT.Name = "EPISODECOUNT";
                    EPISODECOUNT.Visible = EvetHayirEnum.ehHayir;
                    EPISODECOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODECOUNT.Value = @"{#EPISODECOUNT#}";

                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 12, 165, 17, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.Visible = EvetHayirEnum.ehHayir;
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.Value = @"{#TOTALPRICE#}";

                    DOCUMENTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 19, 46, 24, false);
                    DOCUMENTNO.Name = "DOCUMENTNO";
                    DOCUMENTNO.Visible = EvetHayirEnum.ehHayir;
                    DOCUMENTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNO.Value = @"{#DOCUMENTNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CollectedPatientList.CollectedInvoiceCoverPageQuery_Class dataset_CollectedInvoiceCoverPageQuery = ParentGroup.rsGroup.GetCurrentRecord<CollectedPatientList.CollectedInvoiceCoverPageQuery_Class>(0);
                    UZMANLIKADI.CalcValue = (dataset_CollectedInvoiceCoverPageQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceCoverPageQuery.Specialityname) : "");
                    FATURANO.CalcValue = @"";
                    HASTASAYISI.CalcValue = @"";
                    KLASORSAYISI.CalcValue = KLASORSAYISI.Value;
                    YIL.CalcValue = @"";
                    TARIHARALIGI.CalcValue = @"";
                    AYAKTANYATAN.CalcValue = @"";
                    STARTDATE.CalcValue = (dataset_CollectedInvoiceCoverPageQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceCoverPageQuery.STARTDATE) : "");
                    ENDDATE.CalcValue = (dataset_CollectedInvoiceCoverPageQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceCoverPageQuery.ENDDATE) : "");
                    PATIENTSTATUS.CalcValue = (dataset_CollectedInvoiceCoverPageQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceCoverPageQuery.PATIENTSTATUS) : "");
                    EPISODECOUNT.CalcValue = (dataset_CollectedInvoiceCoverPageQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceCoverPageQuery.Episodecount) : "");
                    TOTALPRICE.CalcValue = (dataset_CollectedInvoiceCoverPageQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceCoverPageQuery.Totalprice) : "");
                    DOCUMENTNO.CalcValue = (dataset_CollectedInvoiceCoverPageQuery != null ? Globals.ToStringCore(dataset_CollectedInvoiceCoverPageQuery.DocumentNo) : "");
                    XXXXXXADI.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    XXXXXXKODU.CalcValue = "XXXXXX KODU : " +  TTObjectClasses.SystemParameter.GetParameterValue("MEDULASAGLIKTESISKODU", "XXXXXX");
                    return new TTReportObject[] { UZMANLIKADI,FATURANO,HASTASAYISI,KLASORSAYISI,YIL,TARIHARALIGI,AYAKTANYATAN,STARTDATE,ENDDATE,PATIENTSTATUS,EPISODECOUNT,TOTALPRICE,DOCUMENTNO,XXXXXXADI,XXXXXXKODU};
                }

                public override void RunScript()
                {
#region HEAD HEADER_Script
                    if(PATIENTSTATUS.FormattedValue == "OUTPATIENT" || PATIENTSTATUS.FormattedValue == "OUTPATİENT" || PATIENTSTATUS.FormattedValue == "0")
            {
                AYAKTANYATAN.CalcValue = "(AYAKTAN)";
                HASTASAYISI.CalcValue = "(AYAKTAN " + EPISODECOUNT.CalcValue + " HASTA)";
            }
            else
            {
                AYAKTANYATAN.CalcValue = "(YATAN)";
                HASTASAYISI.CalcValue = "(YATAN " + EPISODECOUNT.CalcValue + " HASTA)";
            }
            
            string startDate = STARTDATE.FormattedValue;
            string endDate = ENDDATE.FormattedValue;
            string monthName = "";

            switch (endDate.Substring(3,2))
            {
                case "01":
                    monthName = "OCAK";
                    break;
                case "02":
                    monthName = "ŞUBAT";
                    break;
                case "03":
                    monthName = "MART";
                    break;
                case "04":
                    monthName = "NİSAN";
                    break;
                case "05":
                    monthName = "MAYIS";
                    break;
                case "06":
                    monthName = "HAZİRAN";
                    break;
                case "07":
                    monthName = "TEMMUZ";
                    break;
                case "08":
                    monthName = "AĞUSTOS";
                    break;
                case "09":
                    monthName = "EYLÜL";
                    break;
                case "10":
                    monthName = "EKİM";
                    break;
                case "11":
                    monthName = "KASIM";
                    break;
                case "12":
                    monthName = "ARALIK";
                    break;                    
            }
            
            YIL.CalcValue = endDate.Substring(6,4);
            TARIHARALIGI.CalcValue = "(" + startDate.Substring(0,2) + " - " + endDate.Substring(0,2) + " " + monthName + ")";
            FATURANO.CalcValue = "Fatura No : " + DOCUMENTNO.CalcValue;
#endregion HEAD HEADER_Script
                }
            }
            public partial class HEADGroupFooter : TTReportSection
            {
                public CollectedInvoiceCoverPage MyParentReport
                {
                    get { return (CollectedInvoiceCoverPage)ParentReport; }
                }
                 
                public HEADGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADGroup HEAD;

        public partial class MAINGroup : TTReportGroup
        {
            public CollectedInvoiceCoverPage MyParentReport
            {
                get { return (CollectedInvoiceCoverPage)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public CollectedInvoiceCoverPage MyParentReport
                {
                    get { return (CollectedInvoiceCoverPage)ParentReport; }
                }
                 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public CollectedInvoiceCoverPage()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            HEAD = new HEADGroup(PARTA,"HEAD");
            MAIN = new MAINGroup(HEAD,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action Object ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "COLLECTEDINVOICECOVERPAGE";
            Caption = "Toplu Fatura Kapak Sayfası";
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