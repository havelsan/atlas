
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
    /// Taburcu Olan Hastalar Etiketi (XXXXXX Şube ile)
    /// </summary>
    public partial class DischargedPatientOfficeEtiquetteReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public DischargedPatientOfficeEtiquetteReport MyParentReport
            {
                get { return (DischargedPatientOfficeEtiquetteReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public DischargedPatientOfficeEtiquetteReport MyParentReport
                {
                    get { return (DischargedPatientOfficeEtiquetteReport)ParentReport; }
                }
                 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public DischargedPatientOfficeEtiquetteReport MyParentReport
                {
                    get { return (DischargedPatientOfficeEtiquetteReport)ParentReport; }
                }
                 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public DischargedPatientOfficeEtiquetteReport MyParentReport
            {
                get { return (DischargedPatientOfficeEtiquetteReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField MILITARYOFFICE { get {return Body().MILITARYOFFICE;} }
            public TTReportField PATIENTGROUPS { get {return Body().PATIENTGROUPS;} }
            public TTReportField TCNO { get {return Body().TCNO;} }
            public TTReportField UNIQUEREFNO { get {return Body().UNIQUEREFNO;} }
            public TTReportField FOREIGNNO { get {return Body().FOREIGNNO;} }
            public TTReportField SPACE { get {return Body().SPACE;} }
            public TTReportField SPACE2 { get {return Body().SPACE2;} }
            public TTReportField DISCHARGENUMBER { get {return Body().DISCHARGENUMBER;} }
            public TTReportField ETIQUETTE { get {return Body().ETIQUETTE;} }
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
                list[0] = new TTReportNqlData<InpatientAdmission.GetDischargeNumberForEtiquetteOffice_Class>("GetDischargeNumberForEtiquetteOffice", InpatientAdmission.GetDischargeNumberForEtiquetteOffice((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public DischargedPatientOfficeEtiquetteReport MyParentReport
                {
                    get { return (DischargedPatientOfficeEtiquetteReport)ParentReport; }
                }
                
                public TTReportField MILITARYOFFICE;
                public TTReportField PATIENTGROUPS;
                public TTReportField TCNO;
                public TTReportField UNIQUEREFNO;
                public TTReportField FOREIGNNO;
                public TTReportField SPACE;
                public TTReportField SPACE2;
                public TTReportField DISCHARGENUMBER;
                public TTReportField ETIQUETTE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 39;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 2;
                    RepeatWidth = 140;
                    
                    MILITARYOFFICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 356, 15, 460, 38, false);
                    MILITARYOFFICE.Name = "MILITARYOFFICE";
                    MILITARYOFFICE.Visible = EvetHayirEnum.ehHayir;
                    MILITARYOFFICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MILITARYOFFICE.MultiLine = EvetHayirEnum.ehEvet;
                    MILITARYOFFICE.NoClip = EvetHayirEnum.ehEvet;
                    MILITARYOFFICE.WordBreak = EvetHayirEnum.ehEvet;
                    MILITARYOFFICE.DataMember = "Name";
                    MILITARYOFFICE.TextFont.CharSet = 162;
                    MILITARYOFFICE.Value = @"";

                    PATIENTGROUPS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 300, 2, 325, 7, false);
                    PATIENTGROUPS.Name = "PATIENTGROUPS";
                    PATIENTGROUPS.Visible = EvetHayirEnum.ehHayir;
                    PATIENTGROUPS.FieldType = ReportFieldTypeEnum.ftExpression;
                    PATIENTGROUPS.TextFont.Name = "Arial Narrow";
                    PATIENTGROUPS.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""PATIENTGROUPSWITHUNITFORETIQUETTE"", """")";

                    TCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 409, 2, 460, 7, false);
                    TCNO.Name = "TCNO";
                    TCNO.Visible = EvetHayirEnum.ehHayir;
                    TCNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TCNO.MultiLine = EvetHayirEnum.ehEvet;
                    TCNO.NoClip = EvetHayirEnum.ehEvet;
                    TCNO.WordBreak = EvetHayirEnum.ehEvet;
                    TCNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TCNO.TextFont.CharSet = 162;
                    TCNO.Value = @"";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 300, 7, 325, 12, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.Visible = EvetHayirEnum.ehHayir;
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.TextFont.Name = "Arial Narrow";
                    UNIQUEREFNO.Value = @"{#TCNO#}";

                    FOREIGNNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 329, 2, 354, 7, false);
                    FOREIGNNO.Name = "FOREIGNNO";
                    FOREIGNNO.Visible = EvetHayirEnum.ehHayir;
                    FOREIGNNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FOREIGNNO.TextFont.Name = "Arial Narrow";
                    FOREIGNNO.Value = @"{#FOREAIGNNO#}";

                    SPACE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 356, 9, 460, 14, false);
                    SPACE.Name = "SPACE";
                    SPACE.Visible = EvetHayirEnum.ehHayir;
                    SPACE.MultiLine = EvetHayirEnum.ehEvet;
                    SPACE.NoClip = EvetHayirEnum.ehEvet;
                    SPACE.WordBreak = EvetHayirEnum.ehEvet;
                    SPACE.ExpandTabs = EvetHayirEnum.ehEvet;
                    SPACE.TextFont.CharSet = 162;
                    SPACE.Value = @"";

                    SPACE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 356, 39, 460, 49, false);
                    SPACE2.Name = "SPACE2";
                    SPACE2.Visible = EvetHayirEnum.ehHayir;
                    SPACE2.MultiLine = EvetHayirEnum.ehEvet;
                    SPACE2.NoClip = EvetHayirEnum.ehEvet;
                    SPACE2.WordBreak = EvetHayirEnum.ehEvet;
                    SPACE2.ExpandTabs = EvetHayirEnum.ehEvet;
                    SPACE2.TextFont.CharSet = 162;
                    SPACE2.Value = @"";

                    DISCHARGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 356, 2, 409, 7, false);
                    DISCHARGENUMBER.Name = "DISCHARGENUMBER";
                    DISCHARGENUMBER.Visible = EvetHayirEnum.ehHayir;
                    DISCHARGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISCHARGENUMBER.MultiLine = EvetHayirEnum.ehEvet;
                    DISCHARGENUMBER.NoClip = EvetHayirEnum.ehEvet;
                    DISCHARGENUMBER.WordBreak = EvetHayirEnum.ehEvet;
                    DISCHARGENUMBER.ExpandTabs = EvetHayirEnum.ehEvet;
                    DISCHARGENUMBER.TextFont.CharSet = 162;
                    DISCHARGENUMBER.Value = @"{#DISCHARGENUMBER#}";

                    ETIQUETTE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 122, 39, false);
                    ETIQUETTE.Name = "ETIQUETTE";
                    ETIQUETTE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ETIQUETTE.MultiLine = EvetHayirEnum.ehEvet;
                    ETIQUETTE.NoClip = EvetHayirEnum.ehEvet;
                    ETIQUETTE.WordBreak = EvetHayirEnum.ehEvet;
                    ETIQUETTE.TextFont.CharSet = 162;
                    ETIQUETTE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmission.GetDischargeNumberForEtiquetteOffice_Class dataset_GetDischargeNumberForEtiquetteOffice = ParentGroup.rsGroup.GetCurrentRecord<InpatientAdmission.GetDischargeNumberForEtiquetteOffice_Class>(0);
                    MILITARYOFFICE.CalcValue = @"";
                    TCNO.CalcValue = @"";
                    UNIQUEREFNO.CalcValue = (dataset_GetDischargeNumberForEtiquetteOffice != null ? Globals.ToStringCore(dataset_GetDischargeNumberForEtiquetteOffice.Tcno) : "");
                    FOREIGNNO.CalcValue = (dataset_GetDischargeNumberForEtiquetteOffice != null ? Globals.ToStringCore(dataset_GetDischargeNumberForEtiquetteOffice.Foreaignno) : "");
                    SPACE.CalcValue = SPACE.Value;
                    SPACE2.CalcValue = SPACE2.Value;
                    DISCHARGENUMBER.CalcValue = (dataset_GetDischargeNumberForEtiquetteOffice != null ? Globals.ToStringCore(dataset_GetDischargeNumberForEtiquetteOffice.DischargeNumber) : "");
                    ETIQUETTE.CalcValue = @"";
                    PATIENTGROUPS.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("PATIENTGROUPSWITHUNITFORETIQUETTE", "");
                    return new TTReportObject[] { MILITARYOFFICE,TCNO,UNIQUEREFNO,FOREIGNNO,SPACE,SPACE2,DISCHARGENUMBER,ETIQUETTE,PATIENTGROUPS};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(this.FOREIGNNO.CalcValue != null && this.FOREIGNNO.CalcValue != "")
                this.TCNO.CalcValue = this.FOREIGNNO.CalcValue;
            else
                this.TCNO.CalcValue = this.UNIQUEREFNO.CalcValue;
            
            
            int dischargeLength =  Convert.ToString(this.DISCHARGENUMBER.CalcValue).Length;
            int tcnoLength = Convert.ToString(this.TCNO.CalcValue).Length;
            
            int spaceLength = 45 - (dischargeLength + tcnoLength);
            string space = "";
            for(int i=0;i<spaceLength;i++)
            {
                space += " ";
            }
            
            string etiquette = this.DISCHARGENUMBER.CalcValue + space + this.TCNO.CalcValue + "\r\n" + space +"\r\n";
            etiquette += this.MILITARYOFFICE.CalcValue;
            
            this.ETIQUETTE.CalcValue = etiquette;
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

        public DischargedPatientOfficeEtiquetteReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "DISCHARGEDPATIENTOFFICEETIQUETTEREPORT";
            Caption = "Taburcu Olan Hastalar Etiketi (XXXXXX Şube ile)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 256;
            p_PageWidth = 300;
            p_PageHeight = 41;
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
            fd.TextFont.Name = "Courier New";
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