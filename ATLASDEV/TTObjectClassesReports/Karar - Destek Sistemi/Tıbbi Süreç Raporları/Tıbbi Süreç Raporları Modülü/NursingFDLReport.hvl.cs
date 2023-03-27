
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
    /// Hemşirelik Bakım İzlem Raporu
    /// </summary>
    public partial class NursingFDLReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public string TEMPERATURE = (string)TTObjectDefManager.Instance.DataTypes["String100"].ConvertValue("TEMPERATURE");
            public string PULSE = (string)TTObjectDefManager.Instance.DataTypes["String100"].ConvertValue("PULSE");
            public string BLOODPRESSURE = (string)TTObjectDefManager.Instance.DataTypes["String100"].ConvertValue("BLOODPRESSURE");
            public string SPO2 = (string)TTObjectDefManager.Instance.DataTypes["String100"].ConvertValue("SPO2");
            public string RESPIRATION = (string)TTObjectDefManager.Instance.DataTypes["String100"].ConvertValue("RESPIRATION");
        }

        public partial class PartAGroup : TTReportGroup
        {
            public NursingFDLReport MyParentReport
            {
                get { return (NursingFDLReport)ParentReport; }
            }

            new public PartAGroupHeader Header()
            {
                return (PartAGroupHeader)_header;
            }

            new public PartAGroupFooter Footer()
            {
                return (PartAGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public PartAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PartAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PartAGroupHeader(this);
                _footer = new PartAGroupFooter(this);

            }

            public partial class PartAGroupHeader : TTReportSection
            {
                public NursingFDLReport MyParentReport
                {
                    get { return (NursingFDLReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK;
                public TTReportField LOGO; 
                public PartAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 57;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 5, 234, 46, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial";
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 8, 41, 31, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = @"";
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { LOGO,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion PARTA HEADER_Script
                }
            }
            public partial class PartAGroupFooter : TTReportSection
            {
                public NursingFDLReport MyParentReport
                {
                    get { return (NursingFDLReport)ParentReport; }
                }
                 
                public PartAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PartAGroup PartA;

        public partial class PatientGroup : TTReportGroup
        {
            public NursingFDLReport MyParentReport
            {
                get { return (NursingFDLReport)ParentReport; }
            }

            new public PatientGroupHeader Header()
            {
                return (PatientGroupHeader)_header;
            }

            new public PatientGroupFooter Footer()
            {
                return (PatientGroupFooter)_footer;
            }

            public TTReportField FULLNAME { get {return Header().FULLNAME;} }
            public TTReportField DIAGNOSISFIELD { get {return Header().DIAGNOSISFIELD;} }
            public TTReportField NewField113411 { get {return Header().NewField113411;} }
            public TTReportField lblPAtientName1 { get {return Header().lblPAtientName1;} }
            public TTReportField lblBirth { get {return Header().lblBirth;} }
            public TTReportField BirthDate { get {return Header().BirthDate;} }
            public TTReportField lblNurse { get {return Header().lblNurse;} }
            public TTReportField ResponsibleNurse { get {return Header().ResponsibleNurse;} }
            public TTReportField lblDiag { get {return Header().lblDiag;} }
            public TTReportField Clinic { get {return Header().Clinic;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public PatientGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PatientGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PatientGroupHeader(this);
                _footer = new PatientGroupFooter(this);

            }

            public partial class PatientGroupHeader : TTReportSection
            {
                public NursingFDLReport MyParentReport
                {
                    get { return (NursingFDLReport)ParentReport; }
                }
                
                public TTReportField FULLNAME;
                public TTReportField DIAGNOSISFIELD;
                public TTReportField NewField113411;
                public TTReportField lblPAtientName1;
                public TTReportField lblBirth;
                public TTReportField BirthDate;
                public TTReportField lblNurse;
                public TTReportField ResponsibleNurse;
                public TTReportField lblDiag;
                public TTReportField Clinic;
                public TTReportShape NewLine11; 
                public PatientGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 39;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    FULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 3, 123, 8, false);
                    FULLNAME.Name = "FULLNAME";
                    FULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME.Value = @"";

                    DIAGNOSISFIELD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 6, 237, 37, false);
                    DIAGNOSISFIELD.Name = "DIAGNOSISFIELD";
                    DIAGNOSISFIELD.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD.Value = @"";

                    NewField113411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 2, 165, 7, false);
                    NewField113411.Name = "NewField113411";
                    NewField113411.TextFont.Bold = true;
                    NewField113411.TextFont.CharSet = 162;
                    NewField113411.Value = @"Tanı";

                    lblPAtientName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 3, 37, 8, false);
                    lblPAtientName1.Name = "lblPAtientName1";
                    lblPAtientName1.Value = @"Adı Soyadı :";

                    lblBirth = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 10, 37, 15, false);
                    lblBirth.Name = "lblBirth";
                    lblBirth.Value = @"Doğum Tarihi";

                    BirthDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 10, 123, 15, false);
                    BirthDate.Name = "BirthDate";
                    BirthDate.Value = @"";

                    lblNurse = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 17, 37, 22, false);
                    lblNurse.Name = "lblNurse";
                    lblNurse.Value = @"Sorumlu Hemşire";

                    ResponsibleNurse = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 17, 123, 22, false);
                    ResponsibleNurse.Name = "ResponsibleNurse";
                    ResponsibleNurse.Value = @"";

                    lblDiag = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 24, 37, 29, false);
                    lblDiag.Name = "lblDiag";
                    lblDiag.Value = @"Klinik";

                    Clinic = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 24, 123, 29, false);
                    Clinic.Name = "Clinic";
                    Clinic.Value = @"";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 12, 1, 280, 1, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    FULLNAME.CalcValue = @"";
                    DIAGNOSISFIELD.CalcValue = DIAGNOSISFIELD.Value;
                    NewField113411.CalcValue = NewField113411.Value;
                    lblPAtientName1.CalcValue = lblPAtientName1.Value;
                    lblBirth.CalcValue = lblBirth.Value;
                    BirthDate.CalcValue = BirthDate.Value;
                    lblNurse.CalcValue = lblNurse.Value;
                    ResponsibleNurse.CalcValue = ResponsibleNurse.Value;
                    lblDiag.CalcValue = lblDiag.Value;
                    Clinic.CalcValue = Clinic.Value;
                    return new TTReportObject[] { FULLNAME,DIAGNOSISFIELD,NewField113411,lblPAtientName1,lblBirth,BirthDate,lblNurse,ResponsibleNurse,lblDiag,Clinic};
                }

                public override void RunScript()
                {
#region PATIENT HEADER_Script
                    string diagnoseStr = "";
            TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((NursingOrderReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            NursingApplication p = (NursingApplication)context.GetObject(new Guid(sObjectID), "NursingApplication");
            
            DateTime? birthDate = p.Episode.Patient.BirthDate;
            ResUser nurse = p.InPatientTreatmentClinicApp.ResponsibleNurse;
            ResSection clinic = p.InPatientTreatmentClinicApp.MasterResource;
            
            this.FULLNAME.CalcValue = p.Episode.Patient.Name + " " + p.Episode.Patient.Surname;
            this.BirthDate.CalcValue = birthDate != null ? birthDate.Value.ToString("dd/MM/yyyy") : "";
            this.ResponsibleNurse.CalcValue = nurse != null ? nurse.Name : "";
            this.Clinic.CalcValue = clinic != null ? clinic.Name : "";

            if (p.Episode.Diagnosis.Count > 0)// Buradan tanı girişi yapılmadıysa episodedaki kesin  tanılara bakar
            {
                foreach (DiagnosisGrid diagnosis in p.Episode.Diagnosis)
                {
                    diagnoseStr = diagnosis.Diagnose.Code + "-" + diagnosis.Diagnose.Name + "-" + diagnosis.FreeDiagnosis + "; " + "\n" + diagnoseStr;
                }
            }
            
            this.DIAGNOSISFIELD.CalcValue = diagnoseStr;
#endregion PATIENT HEADER_Script
                }
            }
            public partial class PatientGroupFooter : TTReportSection
            {
                public NursingFDLReport MyParentReport
                {
                    get { return (NursingFDLReport)ParentReport; }
                }
                 
                public PatientGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PatientGroup Patient;

        public partial class DATESGroup : TTReportGroup
        {
            public NursingFDLReport MyParentReport
            {
                get { return (NursingFDLReport)ParentReport; }
            }

            new public DATESGroupHeader Header()
            {
                return (DATESGroupHeader)_header;
            }

            new public DATESGroupFooter Footer()
            {
                return (DATESGroupFooter)_footer;
            }

            public DATESGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public DATESGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new DATESGroupHeader(this);
                _footer = new DATESGroupFooter(this);

            }

            public partial class DATESGroupHeader : TTReportSection
            {
                public NursingFDLReport MyParentReport
                {
                    get { return (NursingFDLReport)ParentReport; }
                }
                 
                public DATESGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class DATESGroupFooter : TTReportSection
            {
                public NursingFDLReport MyParentReport
                {
                    get { return (NursingFDLReport)ParentReport; }
                }
                 
                public DATESGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public DATESGroup DATES;

        public partial class MAINGroup : TTReportGroup
        {
            public NursingFDLReport MyParentReport
            {
                get { return (NursingFDLReport)ParentReport; }
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
                public NursingFDLReport MyParentReport
                {
                    get { return (NursingFDLReport)ParentReport; }
                }
                 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
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

        public NursingFDLReport()
        {
            PartA = new PartAGroup(this,"PartA");
            Patient = new PatientGroup(PartA,"Patient");
            DATES = new DATESGroup(Patient,"DATES");
            MAIN = new MAINGroup(DATES,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "TTOBJECTID", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter = Parameters.Add("TEMPERATURE", "TEMPERATURE", "", @"", false, false, false, new Guid("7cb2f3b0-2730-4ac0-b71d-024074f18bd9"));
            reportParameter = Parameters.Add("PULSE", "PULSE", "", @"", false, false, false, new Guid("7cb2f3b0-2730-4ac0-b71d-024074f18bd9"));
            reportParameter = Parameters.Add("BLOODPRESSURE", "BLOODPRESSURE", "", @"", false, false, false, new Guid("7cb2f3b0-2730-4ac0-b71d-024074f18bd9"));
            reportParameter = Parameters.Add("SPO2", "SPO2", "", @"", false, false, false, new Guid("7cb2f3b0-2730-4ac0-b71d-024074f18bd9"));
            reportParameter = Parameters.Add("RESPIRATION", "RESPIRATION", "", @"", false, false, false, new Guid("7cb2f3b0-2730-4ac0-b71d-024074f18bd9"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("TEMPERATURE"))
                _runtimeParameters.TEMPERATURE = (string)TTObjectDefManager.Instance.DataTypes["String100"].ConvertValue(parameters["TEMPERATURE"]);
            if (parameters.ContainsKey("PULSE"))
                _runtimeParameters.PULSE = (string)TTObjectDefManager.Instance.DataTypes["String100"].ConvertValue(parameters["PULSE"]);
            if (parameters.ContainsKey("BLOODPRESSURE"))
                _runtimeParameters.BLOODPRESSURE = (string)TTObjectDefManager.Instance.DataTypes["String100"].ConvertValue(parameters["BLOODPRESSURE"]);
            if (parameters.ContainsKey("SPO2"))
                _runtimeParameters.SPO2 = (string)TTObjectDefManager.Instance.DataTypes["String100"].ConvertValue(parameters["SPO2"]);
            if (parameters.ContainsKey("RESPIRATION"))
                _runtimeParameters.RESPIRATION = (string)TTObjectDefManager.Instance.DataTypes["String100"].ConvertValue(parameters["RESPIRATION"]);
            Name = "NURSINGFDLREPORT";
            Caption = "Hemşirelik Bakım İzlem Raporu";
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