
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
    /// Hiperbarik Tedavi Raporu
    /// </summary>
    public partial class HyperbaricOxygenResultReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class mainGroup : TTReportGroup
        {
            public HyperbaricOxygenResultReport MyParentReport
            {
                get { return (HyperbaricOxygenResultReport)ParentReport; }
            }

            new public mainGroupHeader Header()
            {
                return (mainGroupHeader)_header;
            }

            new public mainGroupFooter Footer()
            {
                return (mainGroupFooter)_footer;
            }

            public TTReportField HospitalExplanation { get {return Header().HospitalExplanation;} }
            public TTReportField ABD { get {return Header().ABD;} }
            public TTReportField Subject { get {return Header().Subject;} }
            public TTReportField ReportHeader { get {return Header().ReportHeader;} }
            public TTReportField ReportDate { get {return Header().ReportDate;} }
            public mainGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public mainGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new mainGroupHeader(this);
                _footer = new mainGroupFooter(this);

            }

            public partial class mainGroupHeader : TTReportSection
            {
                public HyperbaricOxygenResultReport MyParentReport
                {
                    get { return (HyperbaricOxygenResultReport)ParentReport; }
                }
                
                public TTReportField HospitalExplanation;
                public TTReportField ABD;
                public TTReportField Subject;
                public TTReportField ReportHeader;
                public TTReportField ReportDate; 
                public mainGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 43;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HospitalExplanation = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 2, 204, 19, false);
                    HospitalExplanation.Name = "HospitalExplanation";
                    HospitalExplanation.FieldType = ReportFieldTypeEnum.ftExpression;
                    HospitalExplanation.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HospitalExplanation.MultiLine = EvetHayirEnum.ehEvet;
                    HospitalExplanation.NoClip = EvetHayirEnum.ehEvet;
                    HospitalExplanation.WordBreak = EvetHayirEnum.ehEvet;
                    HospitalExplanation.ExpandTabs = EvetHayirEnum.ehEvet;
                    HospitalExplanation.TextFont.Bold = true;
                    HospitalExplanation.TextFont.CharSet = 162;
                    HospitalExplanation.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    ABD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 23, 86, 28, false);
                    ABD.Name = "ABD";
                    ABD.Value = @"";

                    Subject = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 30, 86, 35, false);
                    Subject.Name = "Subject";
                    Subject.Value = @"";

                    ReportHeader = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 37, 122, 42, false);
                    ReportHeader.Name = "ReportHeader";
                    ReportHeader.TextFont.Bold = true;
                    ReportHeader.TextFont.CharSet = 162;
                    ReportHeader.Value = @"RAPOR";

                    ReportDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 22, 204, 27, false);
                    ReportDate.Name = "ReportDate";
                    ReportDate.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ReportDate.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ABD.CalcValue = ABD.Value;
                    Subject.CalcValue = Subject.Value;
                    ReportHeader.CalcValue = ReportHeader.Value;
                    ReportDate.CalcValue = ReportDate.Value;
                    HospitalExplanation.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { ABD,Subject,ReportHeader,ReportDate,HospitalExplanation};
                }

                public override void RunScript()
                {
#region MAIN HEADER_Script
                    ABD.CalcValue = "SU ALTI HEK. VE HİP. AD. BŞK.LIĞI";
            //if (hyperbarikOxygenTreatmentRequest.Emergency.Value)
            Subject.CalcValue = "KONU : HASTA TEDAVİ SONUÇ RAPORU";
            ReportDate.CalcValue = DateTime.Now.Date.Day + "." + DateTime.Now.Date.Month + "." + DateTime.Now.Date.Year;
#endregion MAIN HEADER_Script
                }
            }
            public partial class mainGroupFooter : TTReportSection
            {
                public HyperbaricOxygenResultReport MyParentReport
                {
                    get { return (HyperbaricOxygenResultReport)ParentReport; }
                }
                 
                public mainGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public mainGroup main;

        public partial class MAINGroup : TTReportGroup
        {
            public HyperbaricOxygenResultReport MyParentReport
            {
                get { return (HyperbaricOxygenResultReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField DECISION { get {return Body().DECISION;} }
            public TTReportField RequestDoctor { get {return Body().RequestDoctor;} }
            public TTReportField RequestDoctorLabel { get {return Body().RequestDoctorLabel;} }
            public TTReportField HistoryLabel { get {return Body().HistoryLabel;} }
            public TTReportField HISTORY { get {return Body().HISTORY;} }
            public TTReportField DiagnosisLabel { get {return Body().DiagnosisLabel;} }
            public TTReportField Diagnosis { get {return Body().Diagnosis;} }
            public TTReportField DecisionLabel { get {return Body().DecisionLabel;} }
            public TTReportField ResultLabel { get {return Body().ResultLabel;} }
            public TTReportField REPORT { get {return Body().REPORT;} }
            public TTReportField ApprovedDoctorLabel { get {return Body().ApprovedDoctorLabel;} }
            public TTReportField ApprovedDoctor { get {return Body().ApprovedDoctor;} }
            public TTReportField PROTOCOLNO { get {return Body().PROTOCOLNO;} }
            public TTReportField ComplaintLabel11 { get {return Body().ComplaintLabel11;} }
            public TTReportField COMPLAINT { get {return Body().COMPLAINT;} }
            public TTReportField PatientNameLabel11 { get {return Body().PatientNameLabel11;} }
            public TTReportField PatientNameInfo { get {return Body().PatientNameInfo;} }
            public TTReportField ProtocolNoLabel11 { get {return Body().ProtocolNoLabel11;} }
            public TTReportField PatientBirthInfoLabel11 { get {return Body().PatientBirthInfoLabel11;} }
            public TTReportField PatientBirthInfo { get {return Body().PatientBirthInfo;} }
            public TTReportField PatientIDLabel11 { get {return Body().PatientIDLabel11;} }
            public TTReportField PatientID { get {return Body().PatientID;} }
            public TTReportField PatientAddressLabel11 { get {return Body().PatientAddressLabel11;} }
            public TTReportField ReportNoOrOtherHospitalLabel { get {return Body().ReportNoOrOtherHospitalLabel;} }
            public TTReportField ReportNoOrOtherHospital { get {return Body().ReportNoOrOtherHospital;} }
            public TTReportField PyhsicalExamLabel11 { get {return Body().PyhsicalExamLabel11;} }
            public TTReportField PHYSICALEXAMINATION { get {return Body().PHYSICALEXAMINATION;} }
            public TTReportField PatientOtherHospitalLabel1 { get {return Body().PatientOtherHospitalLabel1;} }
            public TTReportField CAMEHOSPITAL { get {return Body().CAMEHOSPITAL;} }
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
                list[0] = new TTReportNqlData<HyperbaricOxygenTreatmentOrder.HyperResultReportQuery_Class>("HyperResultReportQuery", HyperbaricOxygenTreatmentOrder.HyperResultReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public HyperbaricOxygenResultReport MyParentReport
                {
                    get { return (HyperbaricOxygenResultReport)ParentReport; }
                }
                
                public TTReportField OBJECTID;
                public TTReportField DECISION;
                public TTReportField RequestDoctor;
                public TTReportField RequestDoctorLabel;
                public TTReportField HistoryLabel;
                public TTReportField HISTORY;
                public TTReportField DiagnosisLabel;
                public TTReportField Diagnosis;
                public TTReportField DecisionLabel;
                public TTReportField ResultLabel;
                public TTReportField REPORT;
                public TTReportField ApprovedDoctorLabel;
                public TTReportField ApprovedDoctor;
                public TTReportField PROTOCOLNO;
                public TTReportField ComplaintLabel11;
                public TTReportField COMPLAINT;
                public TTReportField PatientNameLabel11;
                public TTReportField PatientNameInfo;
                public TTReportField ProtocolNoLabel11;
                public TTReportField PatientBirthInfoLabel11;
                public TTReportField PatientBirthInfo;
                public TTReportField PatientIDLabel11;
                public TTReportField PatientID;
                public TTReportField PatientAddressLabel11;
                public TTReportField ReportNoOrOtherHospitalLabel;
                public TTReportField ReportNoOrOtherHospital;
                public TTReportField PyhsicalExamLabel11;
                public TTReportField PHYSICALEXAMINATION;
                public TTReportField PatientOtherHospitalLabel1;
                public TTReportField CAMEHOSPITAL; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 189;
                    RepeatCount = 0;
                    
                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 17, 240, 22, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    DECISION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 110, 188, 124, false);
                    DECISION.Name = "DECISION";
                    DECISION.MultiLine = EvetHayirEnum.ehEvet;
                    DECISION.NoClip = EvetHayirEnum.ehEvet;
                    DECISION.WordBreak = EvetHayirEnum.ehEvet;
                    DECISION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DECISION.Value = @"";

                    RequestDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 151, 69, 168, false);
                    RequestDoctor.Name = "RequestDoctor";
                    RequestDoctor.MultiLine = EvetHayirEnum.ehEvet;
                    RequestDoctor.WordBreak = EvetHayirEnum.ehEvet;
                    RequestDoctor.Value = @"";

                    RequestDoctorLabel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 145, 69, 150, false);
                    RequestDoctorLabel.Name = "RequestDoctorLabel";
                    RequestDoctorLabel.Value = @"İSTEK YAPAN DOKTOR   :";

                    HistoryLabel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 49, 64, 54, false);
                    HistoryLabel.Name = "HistoryLabel";
                    HistoryLabel.Value = @"HİKAYESİ   :";

                    HISTORY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 48, 188, 88, false);
                    HISTORY.Name = "HISTORY";
                    HISTORY.MultiLine = EvetHayirEnum.ehEvet;
                    HISTORY.NoClip = EvetHayirEnum.ehEvet;
                    HISTORY.WordBreak = EvetHayirEnum.ehEvet;
                    HISTORY.ExpandTabs = EvetHayirEnum.ehEvet;
                    HISTORY.Value = @"";

                    DiagnosisLabel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 96, 64, 101, false);
                    DiagnosisLabel.Name = "DiagnosisLabel";
                    DiagnosisLabel.Value = @"TANISI   :";

                    Diagnosis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 96, 188, 109, false);
                    Diagnosis.Name = "Diagnosis";
                    Diagnosis.MultiLine = EvetHayirEnum.ehEvet;
                    Diagnosis.NoClip = EvetHayirEnum.ehEvet;
                    Diagnosis.WordBreak = EvetHayirEnum.ehEvet;
                    Diagnosis.ExpandTabs = EvetHayirEnum.ehEvet;
                    Diagnosis.Value = @"";

                    DecisionLabel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 110, 64, 115, false);
                    DecisionLabel.Name = "DecisionLabel";
                    DecisionLabel.Value = @"KARAR   :";

                    ResultLabel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 124, 64, 129, false);
                    ResultLabel.Name = "ResultLabel";
                    ResultLabel.Value = @"SONUÇ   :";

                    REPORT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 125, 188, 139, false);
                    REPORT.Name = "REPORT";
                    REPORT.MultiLine = EvetHayirEnum.ehEvet;
                    REPORT.NoClip = EvetHayirEnum.ehEvet;
                    REPORT.WordBreak = EvetHayirEnum.ehEvet;
                    REPORT.ExpandTabs = EvetHayirEnum.ehEvet;
                    REPORT.Value = @"";

                    ApprovedDoctorLabel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 144, 198, 149, false);
                    ApprovedDoctorLabel.Name = "ApprovedDoctorLabel";
                    ApprovedDoctorLabel.Value = @"ONAYLAYAN DOKTOR   :";

                    ApprovedDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 150, 198, 167, false);
                    ApprovedDoctor.Name = "ApprovedDoctor";
                    ApprovedDoctor.MultiLine = EvetHayirEnum.ehEvet;
                    ApprovedDoctor.WordBreak = EvetHayirEnum.ehEvet;
                    ApprovedDoctor.Value = @"";

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 7, 188, 12, false);
                    PROTOCOLNO.Name = "PROTOCOLNO";
                    PROTOCOLNO.Value = @"";

                    ComplaintLabel11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 43, 64, 48, false);
                    ComplaintLabel11.Name = "ComplaintLabel11";
                    ComplaintLabel11.Value = @"ŞİKAYETİ   :";

                    COMPLAINT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 43, 188, 48, false);
                    COMPLAINT.Name = "COMPLAINT";
                    COMPLAINT.Value = @"";

                    PatientNameLabel11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 1, 64, 6, false);
                    PatientNameLabel11.Name = "PatientNameLabel11";
                    PatientNameLabel11.Value = @"HASTANIN ADI SOYADI   :";

                    PatientNameInfo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 1, 188, 6, false);
                    PatientNameInfo.Name = "PatientNameInfo";
                    PatientNameInfo.Value = @"";

                    ProtocolNoLabel11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 7, 64, 12, false);
                    ProtocolNoLabel11.Name = "ProtocolNoLabel11";
                    ProtocolNoLabel11.Value = @"PROTOKOL NO   :";

                    PatientBirthInfoLabel11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 13, 64, 18, false);
                    PatientBirthInfoLabel11.Name = "PatientBirthInfoLabel11";
                    PatientBirthInfoLabel11.Value = @"DOĞUM YERİ/TARİHİ   :";

                    PatientBirthInfo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 13, 188, 18, false);
                    PatientBirthInfo.Name = "PatientBirthInfo";
                    PatientBirthInfo.Value = @"";

                    PatientIDLabel11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 19, 64, 24, false);
                    PatientIDLabel11.Name = "PatientIDLabel11";
                    PatientIDLabel11.Value = @"TC KİMLİK NO   :";

                    PatientID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 19, 188, 24, false);
                    PatientID.Name = "PatientID";
                    PatientID.Value = @"";

                    PatientAddressLabel11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 25, 64, 30, false);
                    PatientAddressLabel11.Name = "PatientAddressLabel11";
                    PatientAddressLabel11.Value = @"ADRESİ   :";

                    ReportNoOrOtherHospitalLabel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 37, 64, 42, false);
                    ReportNoOrOtherHospitalLabel.Name = "ReportNoOrOtherHospitalLabel";
                    ReportNoOrOtherHospitalLabel.Value = @"RAPOR NO/TARİHİ";

                    ReportNoOrOtherHospital = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 37, 188, 42, false);
                    ReportNoOrOtherHospital.Name = "ReportNoOrOtherHospital";
                    ReportNoOrOtherHospital.Value = @"";

                    PyhsicalExamLabel11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 90, 64, 95, false);
                    PyhsicalExamLabel11.Name = "PyhsicalExamLabel11";
                    PyhsicalExamLabel11.Value = @"FİZİK MUAYENE   :";

                    PHYSICALEXAMINATION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 90, 188, 95, false);
                    PHYSICALEXAMINATION.Name = "PHYSICALEXAMINATION";
                    PHYSICALEXAMINATION.Value = @"";

                    PatientOtherHospitalLabel1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 31, 64, 36, false);
                    PatientOtherHospitalLabel1.Name = "PatientOtherHospitalLabel1";
                    PatientOtherHospitalLabel1.Value = @"GELDİĞİ XXXXXX   :";

                    CAMEHOSPITAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 31, 188, 36, false);
                    CAMEHOSPITAL.Name = "CAMEHOSPITAL";
                    CAMEHOSPITAL.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HyperbaricOxygenTreatmentOrder.HyperResultReportQuery_Class dataset_HyperResultReportQuery = ParentGroup.rsGroup.GetCurrentRecord<HyperbaricOxygenTreatmentOrder.HyperResultReportQuery_Class>(0);
                    OBJECTID.CalcValue = (dataset_HyperResultReportQuery != null ? Globals.ToStringCore(dataset_HyperResultReportQuery.ObjectID) : "");
                    DECISION.CalcValue = DECISION.Value;
                    RequestDoctor.CalcValue = RequestDoctor.Value;
                    RequestDoctorLabel.CalcValue = RequestDoctorLabel.Value;
                    HistoryLabel.CalcValue = HistoryLabel.Value;
                    HISTORY.CalcValue = HISTORY.Value;
                    DiagnosisLabel.CalcValue = DiagnosisLabel.Value;
                    Diagnosis.CalcValue = Diagnosis.Value;
                    DecisionLabel.CalcValue = DecisionLabel.Value;
                    ResultLabel.CalcValue = ResultLabel.Value;
                    REPORT.CalcValue = REPORT.Value;
                    ApprovedDoctorLabel.CalcValue = ApprovedDoctorLabel.Value;
                    ApprovedDoctor.CalcValue = ApprovedDoctor.Value;
                    PROTOCOLNO.CalcValue = PROTOCOLNO.Value;
                    ComplaintLabel11.CalcValue = ComplaintLabel11.Value;
                    COMPLAINT.CalcValue = COMPLAINT.Value;
                    PatientNameLabel11.CalcValue = PatientNameLabel11.Value;
                    PatientNameInfo.CalcValue = PatientNameInfo.Value;
                    ProtocolNoLabel11.CalcValue = ProtocolNoLabel11.Value;
                    PatientBirthInfoLabel11.CalcValue = PatientBirthInfoLabel11.Value;
                    PatientBirthInfo.CalcValue = PatientBirthInfo.Value;
                    PatientIDLabel11.CalcValue = PatientIDLabel11.Value;
                    PatientID.CalcValue = PatientID.Value;
                    PatientAddressLabel11.CalcValue = PatientAddressLabel11.Value;
                    ReportNoOrOtherHospitalLabel.CalcValue = ReportNoOrOtherHospitalLabel.Value;
                    ReportNoOrOtherHospital.CalcValue = ReportNoOrOtherHospital.Value;
                    PyhsicalExamLabel11.CalcValue = PyhsicalExamLabel11.Value;
                    PHYSICALEXAMINATION.CalcValue = PHYSICALEXAMINATION.Value;
                    PatientOtherHospitalLabel1.CalcValue = PatientOtherHospitalLabel1.Value;
                    CAMEHOSPITAL.CalcValue = CAMEHOSPITAL.Value;
                    return new TTReportObject[] { OBJECTID,DECISION,RequestDoctor,RequestDoctorLabel,HistoryLabel,HISTORY,DiagnosisLabel,Diagnosis,DecisionLabel,ResultLabel,REPORT,ApprovedDoctorLabel,ApprovedDoctor,PROTOCOLNO,ComplaintLabel11,COMPLAINT,PatientNameLabel11,PatientNameInfo,ProtocolNoLabel11,PatientBirthInfoLabel11,PatientBirthInfo,PatientIDLabel11,PatientID,PatientAddressLabel11,ReportNoOrOtherHospitalLabel,ReportNoOrOtherHospital,PyhsicalExamLabel11,PHYSICALEXAMINATION,PatientOtherHospitalLabel1,CAMEHOSPITAL};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //                                                                                                                                                            
//            string objectID = this.OBJECTID.CalcValue.ToString();
//            TTObjectContext context = new TTObjectContext(true);
//            HyperbaricOxygenTreatmentOrder hyperbaricOxygenTreatmentOrder = (HyperbaricOxygenTreatmentOrder)context.GetObject(new Guid(objectID), "HyperbaricOxygenTreatmentOrder");
//            
//            HyperbarikOxygenTreatmentRequest hyperbarikOxygenTreatmentRequest = hyperbaricOxygenTreatmentOrder.HyperOxygenTreatmentRequest;
//            
//            if (hyperbarikOxygenTreatmentRequest.Episode != null && hyperbarikOxygenTreatmentRequest.Episode.Patient != null) {
//                if (!string.IsNullOrEmpty(hyperbarikOxygenTreatmentRequest.Episode.Patient.Name) && !string.IsNullOrEmpty(hyperbarikOxygenTreatmentRequest.Episode.Patient.Surname))
//                    PatientNameInfo.CalcValue = hyperbarikOxygenTreatmentRequest.Episode.Patient.Name + " " + hyperbarikOxygenTreatmentRequest.Episode.Patient.Surname;
//
//                if (hyperbarikOxygenTreatmentRequest.Episode.Patient.CityOfBirth != null)
//                    PatientBirthInfo.CalcValue = hyperbarikOxygenTreatmentRequest.Episode.Patient.CityOfBirth.Name;
//                
//                if (hyperbarikOxygenTreatmentRequest.Episode.Patient.BirthDate != null)
//                    PatientBirthInfo.CalcValue += " - " + hyperbarikOxygenTreatmentRequest.Episode.Patient.BirthDate.Value.Day + "." + hyperbarikOxygenTreatmentRequest.Episode.Patient.BirthDate.Value.Month + "." + hyperbarikOxygenTreatmentRequest.Episode.Patient.BirthDate.Value.Year;
//                
//                PatientID.CalcValue = hyperbarikOxygenTreatmentRequest.Episode.Patient.RefNo;
//                
//                if (!string.IsNullOrEmpty(hyperbarikOxygenTreatmentRequest.Episode.Patient.FullAddress))
//                    PatientAddress.CalcValue = hyperbarikOxygenTreatmentRequest.Episode.Patient.FullAddress;
//                
//                Episode episodeForDiagnosis = hyperbarikOxygenTreatmentRequest.Episode;
//                if (episodeForDiagnosis != null)   {
//                    IList<string> oncekiTanilar = new List<string>();
//                    bool hyperEntry = false;
//                    foreach (DiagnosisGrid diagnosis in episodeForDiagnosis.Diagnosis)
//                    {
//                        if (diagnosis.Diagnose.Name != null && !oncekiTanilar.Contains(diagnosis.Diagnose.Code)) {
//                            if (diagnosis.EntryActionType == TTObjectClasses.ActionTypeEnum.HyperbarikOxygenTreatmentRequest) {
//                                if (!hyperEntry) {
//                                    Diagnosis.CalcValue =  "";
//                                    hyperEntry = true;
//                                }
//                                Diagnosis.CalcValue += (diagnosis.Diagnose.Name).ToString() + " / " + (diagnosis.Diagnose.Code).ToString() + System.Environment.NewLine;
//                            }
//                            else if(!hyperEntry)
//                            {
//                                Diagnosis.CalcValue += (diagnosis.Diagnose.Name).ToString() + " / " + (diagnosis.Diagnose.Code).ToString() + System.Environment.NewLine;
//                            }
//                            oncekiTanilar.Add(diagnosis.Diagnose.Code);
//                        }
//                    }
//                }
//            }
//            
//            if (hyperbarikOxygenTreatmentRequest.ProtocolNo != null && hyperbarikOxygenTreatmentRequest.RequestDate != null)
//                PROTOCOLNO.CalcValue = hyperbarikOxygenTreatmentRequest.ProtocolNo.Value.ToString() + " / " + hyperbarikOxygenTreatmentRequest.RequestDate.Value.ToShortDateString();
//            
//               COMPLAINT.CalcValue = hyperbarikOxygenTreatmentRequest.Complaint != null ? TTObjectClasses.Common.GetTextOfRTFString(hyperbarikOxygenTreatmentRequest.Complaint.ToString())+ "\r\n" : "";
//            HISTORY.CalcValue = hyperbarikOxygenTreatmentRequest.History;
//            PHYSICALEXAMINATION.CalcValue = hyperbarikOxygenTreatmentRequest.PyhsicalExamination != null ? TTObjectClasses.Common.GetTextOfRTFString(hyperbarikOxygenTreatmentRequest.PyhsicalExamination.ToString())+ "\r\n" : "";
//            CAMEHOSPITAL.CalcValue = hyperbarikOxygenTreatmentRequest.CameHospital;
//            DECISION.CalcValue = hyperbarikOxygenTreatmentRequest.Decision;
//            
//            if (hyperbarikOxygenTreatmentRequest.ProcedureDoctor != null) {
//                string memberName = hyperbarikOxygenTreatmentRequest.ProcedureDoctor.Name;
//                string memberMilClass = hyperbarikOxygenTreatmentRequest.ProcedureDoctor.MilitaryClass == null ? "" : hyperbarikOxygenTreatmentRequest.ProcedureDoctor.MilitaryClass.ShortName;
//                string memberRank = hyperbarikOxygenTreatmentRequest.ProcedureDoctor.Rank == null ? "" : hyperbarikOxygenTreatmentRequest.ProcedureDoctor.Rank.ShortName;
//                string memberTitle = !hyperbarikOxygenTreatmentRequest.ProcedureDoctor.Title.HasValue ? "" : TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(hyperbarikOxygenTreatmentRequest.ProcedureDoctor.Title.Value);
//                string memberRecId = hyperbarikOxygenTreatmentRequest.ProcedureDoctor.EmploymentRecordID == null ? "" : hyperbarikOxygenTreatmentRequest.ProcedureDoctor.EmploymentRecordID;
//                string memberMainSpeciality = "";
//                string memberSpecialities = "";
//                for (int s = 0; s < hyperbarikOxygenTreatmentRequest.ProcedureDoctor.ResourceSpecialities.Count; s++)
//                    if (hyperbarikOxygenTreatmentRequest.ProcedureDoctor.ResourceSpecialities[s].MainSpeciality.Equals(true))
//                {
//                    memberMainSpeciality += hyperbarikOxygenTreatmentRequest.ProcedureDoctor.ResourceSpecialities[s].Speciality.Name;
//                    if (!hyperbarikOxygenTreatmentRequest.ProcedureDoctor.ResourceSpecialities[s].Speciality.Name.Contains("Uzm")) memberMainSpeciality += " Uzm.";
//                }
//                else
//                {
//                    memberSpecialities += hyperbarikOxygenTreatmentRequest.ProcedureDoctor.ResourceSpecialities[s].Speciality.Name;
//                    if (!hyperbarikOxygenTreatmentRequest.ProcedureDoctor.ResourceSpecialities[s].Speciality.Name.Contains("Uzm") ) memberSpecialities += " Uzm.";
//                    memberSpecialities+="\r\n";
//                }
//                RequestDoctor.CalcValue = memberName + "\r\n" + memberTitle + memberRank + " (" + memberRecId + ")" + "\r\n" + memberMainSpeciality + "\r\n" + memberSpecialities;
//            }
//            
//            if (hyperbarikOxygenTreatmentRequest.ApprovedDoctor != null) {
//                string memberName = hyperbarikOxygenTreatmentRequest.ApprovedDoctor.Name;
//                string memberMilClass = hyperbarikOxygenTreatmentRequest.ApprovedDoctor.MilitaryClass == null ? "" : hyperbarikOxygenTreatmentRequest.ApprovedDoctor.MilitaryClass.ShortName;
//                string memberRank = hyperbarikOxygenTreatmentRequest.ApprovedDoctor.Rank == null ? "" : hyperbarikOxygenTreatmentRequest.ApprovedDoctor.Rank.ShortName;
//                string memberTitle = !hyperbarikOxygenTreatmentRequest.ApprovedDoctor.Title.HasValue ? "" : TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(hyperbarikOxygenTreatmentRequest.ApprovedDoctor.Title.Value);
//                string memberRecId = hyperbarikOxygenTreatmentRequest.ApprovedDoctor.EmploymentRecordID == null ? "" : hyperbarikOxygenTreatmentRequest.ApprovedDoctor.EmploymentRecordID;
//                string memberMainSpeciality = "";
//                string memberSpecialities = "";
//                for (int s = 0; s < hyperbarikOxygenTreatmentRequest.ApprovedDoctor.ResourceSpecialities.Count; s++)
//                    if (hyperbarikOxygenTreatmentRequest.ApprovedDoctor.ResourceSpecialities[s].MainSpeciality.Equals(true))
//                {
//                    memberMainSpeciality += hyperbarikOxygenTreatmentRequest.ApprovedDoctor.ResourceSpecialities[s].Speciality.Name;
//                    if (!hyperbarikOxygenTreatmentRequest.ApprovedDoctor.ResourceSpecialities[s].Speciality.Name.Contains("Uzm")) memberMainSpeciality += " Uzm.";
//                }
//                else
//                {
//                    memberSpecialities += hyperbarikOxygenTreatmentRequest.ApprovedDoctor.ResourceSpecialities[s].Speciality.Name;
//                    if (!hyperbarikOxygenTreatmentRequest.ApprovedDoctor.ResourceSpecialities[s].Speciality.Name.Contains("Uzm") ) memberSpecialities += " Uzm.";
//                    memberSpecialities+="\r\n";
//                }
//                ApprovedDoctor.CalcValue = memberName + "\r\n" + memberTitle + memberRank + " (" + memberRecId + ")" + "\r\n" + memberMainSpeciality + "\r\n" + memberSpecialities;
//            }
//                   
//            
//            if(hyperbaricOxygenTreatmentOrder.Report != null)
//            {
//                REPORT.CalcValue += TTObjectClasses.Common.GetTextOfRTFString(hyperbaricOxygenTreatmentOrder.Report.ToString()) + "\r\n";
//            }
//            
//            if (!string.IsNullOrEmpty(hyperbaricOxygenTreatmentOrder.ReportNo) && hyperbaricOxygenTreatmentOrder.ReportDate != null && string.IsNullOrEmpty(ReportNoOrOtherHospital.CalcValue)) {
//                ReportNoOrOtherHospital.CalcValue = hyperbaricOxygenTreatmentOrder.ReportNo + " / " + hyperbaricOxygenTreatmentOrder.ReportDate.Value.Day + "." + hyperbaricOxygenTreatmentOrder.ReportDate.Value.Month + "." + hyperbaricOxygenTreatmentOrder.ReportDate.Value.Year;
//            }
//
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

        public HyperbaricOxygenResultReport()
        {
            main = new mainGroup(this,"main");
            MAIN = new MAINGroup(main,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HYPERBARICOXYGENRESULTREPORT";
            Caption = "Hiperbarik Tedavi Raporu";
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