
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
    /// Hemşirelik Gözlem Raporu
    /// </summary>
    public partial class NursingOrderReport : TTReport
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
            public NursingOrderReport MyParentReport
            {
                get { return (NursingOrderReport)ParentReport; }
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
                public NursingOrderReport MyParentReport
                {
                    get { return (NursingOrderReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK;
                public TTReportField LOGO; 
                public PartAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 50;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
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
                public NursingOrderReport MyParentReport
                {
                    get { return (NursingOrderReport)ParentReport; }
                }
                 
                public PartAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PartAGroup PartA;

        public partial class PatientGroup : TTReportGroup
        {
            public NursingOrderReport MyParentReport
            {
                get { return (NursingOrderReport)ParentReport; }
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
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1a { get {return Header().NewField1a;} }
            public TTReportField NewField113 { get {return Header().NewField113;} }
            public TTReportField NewField114 { get {return Header().NewField114;} }
            public TTReportField NewField115 { get {return Header().NewField115;} }
            public TTReportField NewField116 { get {return Header().NewField116;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField NewField1611 { get {return Header().NewField1611;} }
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
                public NursingOrderReport MyParentReport
                {
                    get { return (NursingOrderReport)ParentReport; }
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
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField1a;
                public TTReportField NewField113;
                public TTReportField NewField114;
                public TTReportField NewField115;
                public TTReportField NewField116;
                public TTReportShape NewLine11;
                public TTReportField NewField1611; 
                public PatientGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 46;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
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

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 40, 38, 45, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Tarih/Saat";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 40, 63, 45, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Ateş";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 40, 88, 45, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Nabız";

                    NewField1a = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 40, 113, 45, false);
                    NewField1a.Name = "NewField1a";
                    NewField1a.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1a.TextFont.Name = "Arial";
                    NewField1a.TextFont.Bold = true;
                    NewField1a.TextFont.CharSet = 162;
                    NewField1a.Value = @"Tansiyon";

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 40, 138, 45, false);
                    NewField113.Name = "NewField113";
                    NewField113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113.TextFont.Name = "Arial";
                    NewField113.TextFont.Bold = true;
                    NewField113.TextFont.CharSet = 162;
                    NewField113.Value = @"Solunum";

                    NewField114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 40, 163, 45, false);
                    NewField114.Name = "NewField114";
                    NewField114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField114.TextFont.Name = "Arial";
                    NewField114.TextFont.Bold = true;
                    NewField114.TextFont.CharSet = 162;
                    NewField114.Value = @"SPO2";

                    NewField115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 40, 238, 45, false);
                    NewField115.Name = "NewField115";
                    NewField115.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField115.TextFont.Name = "Arial";
                    NewField115.TextFont.Bold = true;
                    NewField115.TextFont.CharSet = 162;
                    NewField115.Value = @"Tedavi/Açıklama";

                    NewField116 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 40, 263, 45, false);
                    NewField116.Name = "NewField116";
                    NewField116.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField116.TextFont.Name = "Arial";
                    NewField116.TextFont.Bold = true;
                    NewField116.TextFont.CharSet = 162;
                    NewField116.Value = @"Hemşire";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 12, 1, 280, 1, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 40, 288, 45, false);
                    NewField1611.Name = "NewField1611";
                    NewField1611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1611.TextFont.Name = "Arial";
                    NewField1611.TextFont.Bold = true;
                    NewField1611.TextFont.CharSet = 162;
                    NewField1611.Value = @"Doktor";

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
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1a.CalcValue = NewField1a.Value;
                    NewField113.CalcValue = NewField113.Value;
                    NewField114.CalcValue = NewField114.Value;
                    NewField115.CalcValue = NewField115.Value;
                    NewField116.CalcValue = NewField116.Value;
                    NewField1611.CalcValue = NewField1611.Value;
                    return new TTReportObject[] { FULLNAME,DIAGNOSISFIELD,NewField113411,lblPAtientName1,lblBirth,BirthDate,lblNurse,ResponsibleNurse,lblDiag,Clinic,NewField1,NewField11,NewField111,NewField1a,NewField113,NewField114,NewField115,NewField116,NewField1611};
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
                public NursingOrderReport MyParentReport
                {
                    get { return (NursingOrderReport)ParentReport; }
                }
                 
                public PatientGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PatientGroup Patient;

        public partial class DATESGroup : TTReportGroup
        {
            public NursingOrderReport MyParentReport
            {
                get { return (NursingOrderReport)ParentReport; }
            }

            new public DATESGroupHeader Header()
            {
                return (DATESGroupHeader)_header;
            }

            new public DATESGroupFooter Footer()
            {
                return (DATESGroupFooter)_footer;
            }

            public TTReportField EXECUTIONDATE { get {return Header().EXECUTIONDATE;} }
            public TTReportField NOTES { get {return Header().NOTES;} }
            public TTReportField HEMSIRE { get {return Header().HEMSIRE;} }
            public TTReportField PROCEDUREBYUSER { get {return Header().PROCEDUREBYUSER;} }
            public DATESGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public DATESGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<NursingOrderDetail.GetDistinctExecutionDates_Class>("GetDistinctExecutionDates", NursingOrderDetail.GetDistinctExecutionDates((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new DATESGroupHeader(this);
                _footer = new DATESGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class DATESGroupHeader : TTReportSection
            {
                public NursingOrderReport MyParentReport
                {
                    get { return (NursingOrderReport)ParentReport; }
                }
                
                public TTReportField EXECUTIONDATE;
                public TTReportField NOTES;
                public TTReportField HEMSIRE;
                public TTReportField PROCEDUREBYUSER; 
                public DATESGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 4;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    EXECUTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 0, 80, 5, false);
                    EXECUTIONDATE.Name = "EXECUTIONDATE";
                    EXECUTIONDATE.Visible = EvetHayirEnum.ehHayir;
                    EXECUTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXECUTIONDATE.Value = @"{#EXECUTIONDATE#}";

                    NOTES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 25, 5, false);
                    NOTES.Name = "NOTES";
                    NOTES.Visible = EvetHayirEnum.ehHayir;
                    NOTES.FieldType = ReportFieldTypeEnum.ftVariable;
                    NOTES.Value = @"{#NOTES#}";

                    HEMSIRE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, -1, 52, 4, false);
                    HEMSIRE.Name = "HEMSIRE";
                    HEMSIRE.Visible = EvetHayirEnum.ehHayir;
                    HEMSIRE.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEMSIRE.Value = @"{#HEMSIRE#}";

                    PROCEDUREBYUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, -1, 108, 4, false);
                    PROCEDUREBYUSER.Name = "PROCEDUREBYUSER";
                    PROCEDUREBYUSER.Visible = EvetHayirEnum.ehHayir;
                    PROCEDUREBYUSER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREBYUSER.Value = @"{#PROCEDUREBYUSER#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NursingOrderDetail.GetDistinctExecutionDates_Class dataset_GetDistinctExecutionDates = ParentGroup.rsGroup.GetCurrentRecord<NursingOrderDetail.GetDistinctExecutionDates_Class>(0);
                    EXECUTIONDATE.CalcValue = (dataset_GetDistinctExecutionDates != null ? Globals.ToStringCore(dataset_GetDistinctExecutionDates.ExecutionDate) : "");
                    NOTES.CalcValue = (dataset_GetDistinctExecutionDates != null ? Globals.ToStringCore(dataset_GetDistinctExecutionDates.Notes) : "");
                    HEMSIRE.CalcValue = (dataset_GetDistinctExecutionDates != null ? Globals.ToStringCore(dataset_GetDistinctExecutionDates.Hemsire) : "");
                    PROCEDUREBYUSER.CalcValue = (dataset_GetDistinctExecutionDates != null ? Globals.ToStringCore(dataset_GetDistinctExecutionDates.ProcedureByUser) : "");
                    return new TTReportObject[] { EXECUTIONDATE,NOTES,HEMSIRE,PROCEDUREBYUSER};
                }
            }
            public partial class DATESGroupFooter : TTReportSection
            {
                public NursingOrderReport MyParentReport
                {
                    get { return (NursingOrderReport)ParentReport; }
                }
                 
                public DATESGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 5;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public DATESGroup DATES;

        public partial class MAINGroup : TTReportGroup
        {
            public NursingOrderReport MyParentReport
            {
                get { return (NursingOrderReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField18 { get {return Body().NewField18;} }
            public TTReportField EXECUTIONDATE { get {return Body().EXECUTIONDATE;} }
            public TTReportField ATES { get {return Body().ATES;} }
            public TTReportField NABIZ { get {return Body().NABIZ;} }
            public TTReportField SOLUNUM { get {return Body().SOLUNUM;} }
            public TTReportField TANSIYON { get {return Body().TANSIYON;} }
            public TTReportField SPO2 { get {return Body().SPO2;} }
            public TTReportField NOTES { get {return Body().NOTES;} }
            public TTReportField HEMSIRE { get {return Body().HEMSIRE;} }
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
                public NursingOrderReport MyParentReport
                {
                    get { return (NursingOrderReport)ParentReport; }
                }
                
                public TTReportField NewField18;
                public TTReportField EXECUTIONDATE;
                public TTReportField ATES;
                public TTReportField NABIZ;
                public TTReportField SOLUNUM;
                public TTReportField TANSIYON;
                public TTReportField SPO2;
                public TTReportField NOTES;
                public TTReportField HEMSIRE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 0, 288, 5, false);
                    NewField18.Name = "NewField18";
                    NewField18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField18.Value = @"";

                    EXECUTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 0, 38, 5, false);
                    EXECUTIONDATE.Name = "EXECUTIONDATE";
                    EXECUTIONDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    EXECUTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXECUTIONDATE.Value = @"{#DATES.EXECUTIONDATE#}";

                    ATES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 0, 63, 5, false);
                    ATES.Name = "ATES";
                    ATES.DrawStyle = DrawStyleConstants.vbSolid;
                    ATES.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATES.Value = @"";

                    NABIZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 0, 88, 5, false);
                    NABIZ.Name = "NABIZ";
                    NABIZ.DrawStyle = DrawStyleConstants.vbSolid;
                    NABIZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    NABIZ.Value = @"";

                    SOLUNUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 0, 138, 5, false);
                    SOLUNUM.Name = "SOLUNUM";
                    SOLUNUM.DrawStyle = DrawStyleConstants.vbSolid;
                    SOLUNUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    SOLUNUM.Value = @"";

                    TANSIYON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 0, 113, 5, false);
                    TANSIYON.Name = "TANSIYON";
                    TANSIYON.DrawStyle = DrawStyleConstants.vbSolid;
                    TANSIYON.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANSIYON.Value = @"";

                    SPO2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 0, 163, 5, false);
                    SPO2.Name = "SPO2";
                    SPO2.DrawStyle = DrawStyleConstants.vbSolid;
                    SPO2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SPO2.Value = @"";

                    NOTES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 0, 238, 5, false);
                    NOTES.Name = "NOTES";
                    NOTES.DrawStyle = DrawStyleConstants.vbSolid;
                    NOTES.FieldType = ReportFieldTypeEnum.ftVariable;
                    NOTES.Value = @"{#DATES.NOTES#}";

                    HEMSIRE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 0, 263, 5, false);
                    HEMSIRE.Name = "HEMSIRE";
                    HEMSIRE.DrawStyle = DrawStyleConstants.vbSolid;
                    HEMSIRE.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEMSIRE.Value = @"{#DATES.HEMSIRE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NursingOrderDetail.GetDistinctExecutionDates_Class dataset_GetDistinctExecutionDates = MyParentReport.DATES.rsGroup.GetCurrentRecord<NursingOrderDetail.GetDistinctExecutionDates_Class>(0);
                    NewField18.CalcValue = NewField18.Value;
                    EXECUTIONDATE.CalcValue = (dataset_GetDistinctExecutionDates != null ? Globals.ToStringCore(dataset_GetDistinctExecutionDates.ExecutionDate) : "");
                    ATES.CalcValue = @"";
                    NABIZ.CalcValue = @"";
                    SOLUNUM.CalcValue = @"";
                    TANSIYON.CalcValue = @"";
                    SPO2.CalcValue = @"";
                    NOTES.CalcValue = (dataset_GetDistinctExecutionDates != null ? Globals.ToStringCore(dataset_GetDistinctExecutionDates.Notes) : "");
                    HEMSIRE.CalcValue = (dataset_GetDistinctExecutionDates != null ? Globals.ToStringCore(dataset_GetDistinctExecutionDates.Hemsire) : "");
                    return new TTReportObject[] { NewField18,EXECUTIONDATE,ATES,NABIZ,SOLUNUM,TANSIYON,SPO2,NOTES,HEMSIRE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    DateTime executionTime;
                    if (MyParentReport.DATES.EXECUTIONDATE.CalcValue.Length == 19)
                        executionTime = DateTime.ParseExact(MyParentReport.DATES.EXECUTIONDATE.CalcValue, "dd.MM.yyyy HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);
                    else if (MyParentReport.DATES.EXECUTIONDATE.CalcValue.Length == 18)
                    {
                        if (MyParentReport.DATES.EXECUTIONDATE.CalcValue.IndexOf(".") == 2)
                            executionTime = DateTime.ParseExact(MyParentReport.DATES.EXECUTIONDATE.CalcValue, "dd.M.yyyy HH:mm:ss",
                                           System.Globalization.CultureInfo.InvariantCulture);
                        else
                            executionTime = DateTime.ParseExact(MyParentReport.DATES.EXECUTIONDATE.CalcValue, "d.MM.yyyy HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else if (MyParentReport.DATES.EXECUTIONDATE.CalcValue.Length == 17)
                        executionTime = DateTime.ParseExact(MyParentReport.DATES.EXECUTIONDATE.CalcValue, "d.M.yyyy HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);
                    else
                        executionTime = new DateTime();

                    string filterExpression = "";
                    if (MyParentReport.DATES.PROCEDUREBYUSER.CalcValue != null && MyParentReport.DATES.PROCEDUREBYUSER.CalcValue != "")
                        filterExpression += "AND THIS.NursingOrderDetails.ProcedureByUser = '" + MyParentReport.DATES.PROCEDUREBYUSER.CalcValue + "'";
                    else
                        filterExpression = "AND THIS.NursingOrderDetails.ProcedureByUser IS NULL";
                    if (MyParentReport.DATES.NOTES.CalcValue != null && MyParentReport.DATES.NOTES.CalcValue != "")
                        filterExpression += " AND THIS.NursingOrderDetails.Notes = '" + MyParentReport.DATES.NOTES.CalcValue + "'";
                    else
                        filterExpression = "AND THIS.NursingOrderDetails.Notes IS NULL";
                    var atesArray = Temperature.GetTemperatureByEpisodeActionAndDate(new Guid(MyParentReport.RuntimeParameters?.TTOBJECTID.ToString()), executionTime, filterExpression).ToArray();
                    var nabizArray = Pulse.GetPulseByEpisodeActionAndDate(new Guid(MyParentReport.RuntimeParameters?.TTOBJECTID.ToString()), executionTime, filterExpression).ToArray();
                    var tansiyonArray = BloodPressure.GetBloodPressureByEpisodeActionAndDate(new Guid(MyParentReport.RuntimeParameters?.TTOBJECTID.ToString()), executionTime, filterExpression).ToArray();
                    var solunumArray = Respiration.GetRespirationByEpisodeActionAndDate(new Guid(MyParentReport.RuntimeParameters?.TTOBJECTID.ToString()), executionTime, filterExpression).ToArray();
                    var SPO2Array = TTObjectClasses.SPO2.GetSPO2ByEpisodeActionAndDate(new Guid(MyParentReport.RuntimeParameters?.TTOBJECTID.ToString()), executionTime, filterExpression).ToArray();
                    if (atesArray.Count() > 0)
                        this.ATES.CalcValue = atesArray[0].Ates.ToString();
                    if (nabizArray.Count() > 0)
                        this.NABIZ.CalcValue = nabizArray[0].Nabiz.ToString();
                    if (tansiyonArray.Count() > 0)
                        this.TANSIYON.CalcValue = tansiyonArray[0].Sistolik.ToString() + "/" + tansiyonArray[0].Diastolik.ToString();
                    if (solunumArray.Count() > 0)
                        this.SOLUNUM.CalcValue = solunumArray[0].Solunum.ToString();
                    if (SPO2Array.Count() > 0)
                        this.SPO2.CalcValue = SPO2Array[0].Spo2.ToString();
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

        public NursingOrderReport()
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
            Name = "NURSINGORDERREPORT";
            Caption = "Hemşirelik Gözlem Raporu";
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