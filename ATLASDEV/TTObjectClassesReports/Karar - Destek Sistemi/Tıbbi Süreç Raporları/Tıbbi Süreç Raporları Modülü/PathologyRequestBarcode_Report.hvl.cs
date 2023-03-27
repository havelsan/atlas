
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
    /// Patoloji İstek Barkodu
    /// </summary>
    public partial class PathologyRequestBarcode : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public PathologyRequestBarcode MyParentReport
            {
                get { return (PathologyRequestBarcode)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField Uniquerefno { get {return Body().Uniquerefno;} }
            public TTReportField NameSurname { get {return Body().NameSurname;} }
            public TTReportField UniquerefnoBarcode { get {return Body().UniquerefnoBarcode;} }
            public TTReportField Clinic { get {return Body().Clinic;} }
            public TTReportField lbl32 { get {return Body().lbl32;} }
            public TTReportField lbl31 { get {return Body().lbl31;} }
            public TTReportField lbl33 { get {return Body().lbl33;} }
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
                list[0] = new TTReportNqlData<PathologyRequest.PathologyRequestBarcodeNQL_Class>("PathologyRequestBarcodeNQL", PathologyRequest.PathologyRequestBarcodeNQL((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public PathologyRequestBarcode MyParentReport
                {
                    get { return (PathologyRequestBarcode)ParentReport; }
                }
                
                public TTReportField Uniquerefno;
                public TTReportField NameSurname;
                public TTReportField UniquerefnoBarcode;
                public TTReportField Clinic;
                public TTReportField lbl32;
                public TTReportField lbl31;
                public TTReportField lbl33; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    RepeatCount = 0;
                    
                    Uniquerefno = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 0, 39, 4, false);
                    Uniquerefno.Name = "Uniquerefno";
                    Uniquerefno.FieldType = ReportFieldTypeEnum.ftVariable;
                    Uniquerefno.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Uniquerefno.TextFont.Size = 8;
                    Uniquerefno.TextFont.CharSet = 162;
                    Uniquerefno.Value = @"{#UNIQUEREFNO#}";

                    NameSurname = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 11, 39, 15, false);
                    NameSurname.Name = "NameSurname";
                    NameSurname.FieldType = ReportFieldTypeEnum.ftVariable;
                    NameSurname.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NameSurname.TextFont.Size = 8;
                    NameSurname.TextFont.CharSet = 162;
                    NameSurname.Value = @"{#NAME#} {#SURNAME#}";

                    UniquerefnoBarcode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 4, 39, 11, false);
                    UniquerefnoBarcode.Name = "UniquerefnoBarcode";
                    UniquerefnoBarcode.FieldType = ReportFieldTypeEnum.ftVariable;
                    UniquerefnoBarcode.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UniquerefnoBarcode.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UniquerefnoBarcode.TextFont.Name = "Code39HalfInchTT-Regular";
                    UniquerefnoBarcode.TextFont.Size = 14;
                    UniquerefnoBarcode.TextFont.CharSet = 0;
                    UniquerefnoBarcode.Value = @"{#UNIQUEREFNO#}";

                    Clinic = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 15, 39, 25, false);
                    Clinic.Name = "Clinic";
                    Clinic.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Clinic.MultiLine = EvetHayirEnum.ehEvet;
                    Clinic.WordBreak = EvetHayirEnum.ehEvet;
                    Clinic.TextFont.Size = 8;
                    Clinic.TextFont.CharSet = 162;
                    Clinic.Value = @"";

                    lbl32 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 11, 16, 15, false);
                    lbl32.Name = "lbl32";
                    lbl32.TextFont.Name = "Arial";
                    lbl32.TextFont.Size = 7;
                    lbl32.TextFont.Bold = true;
                    lbl32.TextFont.CharSet = 162;
                    lbl32.Value = @"Adı Soyadı:";

                    lbl31 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 0, 16, 4, false);
                    lbl31.Name = "lbl31";
                    lbl31.TextFont.Name = "Arial";
                    lbl31.TextFont.Size = 7;
                    lbl31.TextFont.Bold = true;
                    lbl31.TextFont.CharSet = 162;
                    lbl31.Value = @"TCKimlikNo:";

                    lbl33 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 14, 15, 25, false);
                    lbl33.Name = "lbl33";
                    lbl33.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lbl33.MultiLine = EvetHayirEnum.ehEvet;
                    lbl33.NoClip = EvetHayirEnum.ehEvet;
                    lbl33.WordBreak = EvetHayirEnum.ehEvet;
                    lbl33.ExpandTabs = EvetHayirEnum.ehEvet;
                    lbl33.TextFont.Name = "Arial";
                    lbl33.TextFont.Size = 7;
                    lbl33.TextFont.Bold = true;
                    lbl33.TextFont.CharSet = 162;
                    lbl33.Value = @"Yattığı Klinik:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PathologyRequest.PathologyRequestBarcodeNQL_Class dataset_PathologyRequestBarcodeNQL = ParentGroup.rsGroup.GetCurrentRecord<PathologyRequest.PathologyRequestBarcodeNQL_Class>(0);
                    Uniquerefno.CalcValue = (dataset_PathologyRequestBarcodeNQL != null ? Globals.ToStringCore(dataset_PathologyRequestBarcodeNQL.UniqueRefNo) : "");
                    NameSurname.CalcValue = (dataset_PathologyRequestBarcodeNQL != null ? Globals.ToStringCore(dataset_PathologyRequestBarcodeNQL.Name) : "") + @" " + (dataset_PathologyRequestBarcodeNQL != null ? Globals.ToStringCore(dataset_PathologyRequestBarcodeNQL.Surname) : "");
                    UniquerefnoBarcode.CalcValue = (dataset_PathologyRequestBarcodeNQL != null ? Globals.ToStringCore(dataset_PathologyRequestBarcodeNQL.UniqueRefNo) : "");
                    Clinic.CalcValue = Clinic.Value;
                    lbl32.CalcValue = lbl32.Value;
                    lbl31.CalcValue = lbl31.Value;
                    lbl33.CalcValue = lbl33.Value;
                    return new TTReportObject[] { Uniquerefno,NameSurname,UniquerefnoBarcode,Clinic,lbl32,lbl31,lbl33};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);    
            string sObjectID = ((PathologyRequestBarcode)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
                        
            PathologyRequest pathology = (PathologyRequest)context.GetObject(new Guid(sObjectID),"PathologyRequest");
            
            if(pathology.Episode.PatientStatus == PatientStatusEnum.Inpatient)
            {
                foreach(EpisodeAction action in pathology.Episode.EpisodeActions)
                {
                    if(action is BaseInpatientAdmission)
                    {
                        if(((BaseInpatientAdmission)action).PhysicalStateClinic != null)
                        {
                            this.Clinic.CalcValue = ((BaseInpatientAdmission)action).PhysicalStateClinic.Name.Trim();
                        }
                    }
                }
            }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public PathologyRequestBarcode()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "EpisodeActionObjectID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "PATHOLOGYREQUESTBARCODE";
            Caption = "Patoloji İstek Barkodu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 256;
            p_PageWidth = 40;
            p_PageHeight = 25;
            UsePrinterMargins = EvetHayirEnum.ehEvet;
            DontUseWatermark = EvetHayirEnum.ehEvet;
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