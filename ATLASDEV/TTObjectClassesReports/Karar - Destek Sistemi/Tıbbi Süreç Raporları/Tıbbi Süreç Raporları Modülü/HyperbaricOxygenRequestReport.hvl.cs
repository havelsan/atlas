
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
    /// Hiperbarik Tedavi İstek Rap
    /// </summary>
    public partial class HyperbaricOxygenRequestReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class mainGroup : TTReportGroup
        {
            public HyperbaricOxygenRequestReport MyParentReport
            {
                get { return (HyperbaricOxygenRequestReport)ParentReport; }
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
                public HyperbaricOxygenRequestReport MyParentReport
                {
                    get { return (HyperbaricOxygenRequestReport)ParentReport; }
                }
                
                public TTReportField HospitalExplanation;
                public TTReportField ABD;
                public TTReportField Subject;
                public TTReportField ReportHeader;
                public TTReportField ReportDate; 
                public mainGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 44;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HospitalExplanation = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 3, 202, 20, false);
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

                    ABD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 24, 84, 29, false);
                    ABD.Name = "ABD";
                    ABD.Value = @"";

                    Subject = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 31, 84, 36, false);
                    Subject.Name = "Subject";
                    Subject.Value = @"";

                    ReportHeader = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 38, 120, 43, false);
                    ReportHeader.Name = "ReportHeader";
                    ReportHeader.TextFont.Bold = true;
                    ReportHeader.TextFont.CharSet = 162;
                    ReportHeader.Value = @"RAPOR";

                    ReportDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 23, 202, 28, false);
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
            Subject.CalcValue = "KONU : HASTA TEDAVİ İSTEK RAPORU";
            ReportDate.CalcValue = DateTime.Now.Date.Day + "." + DateTime.Now.Date.Month + "." + DateTime.Now.Date.Year;
#endregion MAIN HEADER_Script
                }
            }
            public partial class mainGroupFooter : TTReportSection
            {
                public HyperbaricOxygenRequestReport MyParentReport
                {
                    get { return (HyperbaricOxygenRequestReport)ParentReport; }
                }
                 
                public mainGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public mainGroup main;

        public partial class PARTAGroup : TTReportGroup
        {
            public HyperbaricOxygenRequestReport MyParentReport
            {
                get { return (HyperbaricOxygenRequestReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField OBJECTID1 { get {return Header().OBJECTID1;} }
            public TTReportField Diagnosis1 { get {return Header().Diagnosis1;} }
            public TTReportField DECISION1 { get {return Header().DECISION1;} }
            public TTReportField RequestDoctor11 { get {return Header().RequestDoctor11;} }
            public TTReportField ApprovedDoctor11 { get {return Header().ApprovedDoctor11;} }
            public TTReportField COMPLAINT1 { get {return Header().COMPLAINT1;} }
            public TTReportField HISTORY1 { get {return Header().HISTORY1;} }
            public TTReportField PHYSICALEXAMINATION1 { get {return Header().PHYSICALEXAMINATION1;} }
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
                public HyperbaricOxygenRequestReport MyParentReport
                {
                    get { return (HyperbaricOxygenRequestReport)ParentReport; }
                }
                
                public TTReportField OBJECTID1;
                public TTReportField Diagnosis1;
                public TTReportField DECISION1;
                public TTReportField RequestDoctor11;
                public TTReportField ApprovedDoctor11;
                public TTReportField COMPLAINT1;
                public TTReportField HISTORY1;
                public TTReportField PHYSICALEXAMINATION1; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 13;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    OBJECTID1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 4, 38, 9, false);
                    OBJECTID1.Name = "OBJECTID1";
                    OBJECTID1.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID1.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID1.Value = @"{@TTOBJECTID@}";

                    Diagnosis1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 3, 57, 11, false);
                    Diagnosis1.Name = "Diagnosis1";
                    Diagnosis1.Visible = EvetHayirEnum.ehHayir;
                    Diagnosis1.MultiLine = EvetHayirEnum.ehEvet;
                    Diagnosis1.NoClip = EvetHayirEnum.ehEvet;
                    Diagnosis1.WordBreak = EvetHayirEnum.ehEvet;
                    Diagnosis1.ExpandTabs = EvetHayirEnum.ehEvet;
                    Diagnosis1.Value = @"";

                    DECISION1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 3, 73, 10, false);
                    DECISION1.Name = "DECISION1";
                    DECISION1.Visible = EvetHayirEnum.ehHayir;
                    DECISION1.MultiLine = EvetHayirEnum.ehEvet;
                    DECISION1.NoClip = EvetHayirEnum.ehEvet;
                    DECISION1.WordBreak = EvetHayirEnum.ehEvet;
                    DECISION1.ExpandTabs = EvetHayirEnum.ehEvet;
                    DECISION1.Value = @"";

                    RequestDoctor11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 3, 100, 9, false);
                    RequestDoctor11.Name = "RequestDoctor11";
                    RequestDoctor11.Visible = EvetHayirEnum.ehHayir;
                    RequestDoctor11.MultiLine = EvetHayirEnum.ehEvet;
                    RequestDoctor11.WordBreak = EvetHayirEnum.ehEvet;
                    RequestDoctor11.Value = @"";

                    ApprovedDoctor11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 2, 123, 9, false);
                    ApprovedDoctor11.Name = "ApprovedDoctor11";
                    ApprovedDoctor11.Visible = EvetHayirEnum.ehHayir;
                    ApprovedDoctor11.MultiLine = EvetHayirEnum.ehEvet;
                    ApprovedDoctor11.WordBreak = EvetHayirEnum.ehEvet;
                    ApprovedDoctor11.Value = @"";

                    COMPLAINT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 3, 143, 8, false);
                    COMPLAINT1.Name = "COMPLAINT1";
                    COMPLAINT1.Visible = EvetHayirEnum.ehHayir;
                    COMPLAINT1.Value = @"";

                    HISTORY1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 3, 162, 9, false);
                    HISTORY1.Name = "HISTORY1";
                    HISTORY1.Visible = EvetHayirEnum.ehHayir;
                    HISTORY1.MultiLine = EvetHayirEnum.ehEvet;
                    HISTORY1.NoClip = EvetHayirEnum.ehEvet;
                    HISTORY1.WordBreak = EvetHayirEnum.ehEvet;
                    HISTORY1.ExpandTabs = EvetHayirEnum.ehEvet;
                    HISTORY1.Value = @"";

                    PHYSICALEXAMINATION1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 3, 194, 8, false);
                    PHYSICALEXAMINATION1.Name = "PHYSICALEXAMINATION1";
                    PHYSICALEXAMINATION1.Visible = EvetHayirEnum.ehHayir;
                    PHYSICALEXAMINATION1.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OBJECTID1.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    Diagnosis1.CalcValue = Diagnosis1.Value;
                    DECISION1.CalcValue = DECISION1.Value;
                    RequestDoctor11.CalcValue = RequestDoctor11.Value;
                    ApprovedDoctor11.CalcValue = ApprovedDoctor11.Value;
                    COMPLAINT1.CalcValue = COMPLAINT1.Value;
                    HISTORY1.CalcValue = HISTORY1.Value;
                    PHYSICALEXAMINATION1.CalcValue = PHYSICALEXAMINATION1.Value;
                    return new TTReportObject[] { OBJECTID1,Diagnosis1,DECISION1,RequestDoctor11,ApprovedDoctor11,COMPLAINT1,HISTORY1,PHYSICALEXAMINATION1};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    //            string objectID = this.OBJECTID1.CalcValue.ToString();
//            TTObjectContext context = new TTObjectContext(true);
//            HyperbarikOxygenTreatmentRequest hyperbarikOxygenTreatmentRequest = (HyperbarikOxygenTreatmentRequest)context.GetObject(new Guid(objectID), "HyperbarikOxygenTreatmentRequest");
//            
//            if (hyperbarikOxygenTreatmentRequest != null && hyperbarikOxygenTreatmentRequest.Episode != null)
//            {
//                Episode episodeForDiagnosis = hyperbarikOxygenTreatmentRequest.Episode;
//                if (episodeForDiagnosis != null)
//                {
//                    IList<string> oncekiTanilar = new List<string>();
//                    bool hyperEntry = false;
//                    foreach (DiagnosisGrid diagnosis in episodeForDiagnosis.Diagnosis)
//                    {
//                        if (diagnosis.Diagnose.Name != null && !oncekiTanilar.Contains(diagnosis.Diagnose.Code)) {
//                            if (diagnosis.EntryActionType == TTObjectClasses.ActionTypeEnum.HyperbarikOxygenTreatmentRequest) {
//                                if (!hyperEntry) {
//                                    Diagnosis1.CalcValue =  "";
//                                    hyperEntry = true;
//                                }
//                                Diagnosis1.CalcValue += (diagnosis.Diagnose.Name).ToString() + " / " + (diagnosis.Diagnose.Code).ToString() + System.Environment.NewLine;
//                            }
//                            else if(!hyperEntry)
//                            {
//                                Diagnosis1.CalcValue += (diagnosis.Diagnose.Name).ToString() + " / " + (diagnosis.Diagnose.Code).ToString() + System.Environment.NewLine;
//                            }
//                            oncekiTanilar.Add(diagnosis.Diagnose.Code);
//                        }
//                    }
//                }
//                DECISION1.CalcValue = hyperbarikOxygenTreatmentRequest.Decision;
//                COMPLAINT1.CalcValue = hyperbarikOxygenTreatmentRequest.Complaint != null ? TTObjectClasses.Common.GetTextOfRTFString(hyperbarikOxygenTreatmentRequest.Complaint.ToString())+ "\r\n" : "";
//                HISTORY1.CalcValue = hyperbarikOxygenTreatmentRequest.History;
//                PHYSICALEXAMINATION1.CalcValue = hyperbarikOxygenTreatmentRequest.PyhsicalExamination != null ? TTObjectClasses.Common.GetTextOfRTFString(hyperbarikOxygenTreatmentRequest.PyhsicalExamination.ToString())+ "\r\n" : "";
//                
//                if (hyperbarikOxygenTreatmentRequest.ProcedureDoctor != null) {
//                    string memberName = hyperbarikOxygenTreatmentRequest.ProcedureDoctor.Name;
//                    string memberMilClass = hyperbarikOxygenTreatmentRequest.ProcedureDoctor.MilitaryClass == null ? "" : hyperbarikOxygenTreatmentRequest.ProcedureDoctor.MilitaryClass.ShortName;
//                    string memberRank = hyperbarikOxygenTreatmentRequest.ProcedureDoctor.Rank == null ? "" : hyperbarikOxygenTreatmentRequest.ProcedureDoctor.Rank.ShortName;
//                    string memberTitle = !hyperbarikOxygenTreatmentRequest.ProcedureDoctor.Title.HasValue ? "" : TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(hyperbarikOxygenTreatmentRequest.ProcedureDoctor.Title.Value);
//                    string memberRecId = hyperbarikOxygenTreatmentRequest.ProcedureDoctor.EmploymentRecordID == null ? "" : hyperbarikOxygenTreatmentRequest.ProcedureDoctor.EmploymentRecordID;
//                    string memberMainSpeciality = "";
//                    string memberSpecialities = "";
//                    for (int s = 0; s < hyperbarikOxygenTreatmentRequest.ProcedureDoctor.ResourceSpecialities.Count; s++)
//                        if (hyperbarikOxygenTreatmentRequest.ProcedureDoctor.ResourceSpecialities[s].MainSpeciality.Equals(true))
//                    {
//                        memberMainSpeciality += hyperbarikOxygenTreatmentRequest.ProcedureDoctor.ResourceSpecialities[s].Speciality.Name;
//                        if (!hyperbarikOxygenTreatmentRequest.ProcedureDoctor.ResourceSpecialities[s].Speciality.Name.Contains("Uzm")) memberMainSpeciality += " Uzm.";
//                    }
//                    else
//                    {
//                        memberSpecialities += hyperbarikOxygenTreatmentRequest.ProcedureDoctor.ResourceSpecialities[s].Speciality.Name;
//                        if (!hyperbarikOxygenTreatmentRequest.ProcedureDoctor.ResourceSpecialities[s].Speciality.Name.Contains("Uzm") ) memberSpecialities += " Uzm.";
//                        memberSpecialities+="\r\n";
//                    }
//                    RequestDoctor11.CalcValue = memberName + "\r\n" + memberTitle + memberRank + " (" + memberRecId + ")" + "\r\n" + memberMainSpeciality + "\r\n" + memberSpecialities;
//                }
//                
//                if (hyperbarikOxygenTreatmentRequest.ApprovedDoctor != null) {
//                    string memberName = hyperbarikOxygenTreatmentRequest.ApprovedDoctor.Name;
//                    string memberMilClass = hyperbarikOxygenTreatmentRequest.ApprovedDoctor.MilitaryClass == null ? "" : hyperbarikOxygenTreatmentRequest.ApprovedDoctor.MilitaryClass.ShortName;
//                    string memberRank = hyperbarikOxygenTreatmentRequest.ApprovedDoctor.Rank == null ? "" : hyperbarikOxygenTreatmentRequest.ApprovedDoctor.Rank.ShortName;
//                    string memberTitle = !hyperbarikOxygenTreatmentRequest.ApprovedDoctor.Title.HasValue ? "" : TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(hyperbarikOxygenTreatmentRequest.ApprovedDoctor.Title.Value);
//                    string memberRecId = hyperbarikOxygenTreatmentRequest.ApprovedDoctor.EmploymentRecordID == null ? "" : hyperbarikOxygenTreatmentRequest.ApprovedDoctor.EmploymentRecordID;
//                    string memberMainSpeciality = "";
//                    string memberSpecialities = "";
//                    for (int s = 0; s < hyperbarikOxygenTreatmentRequest.ApprovedDoctor.ResourceSpecialities.Count; s++)
//                        if (hyperbarikOxygenTreatmentRequest.ApprovedDoctor.ResourceSpecialities[s].MainSpeciality.Equals(true))
//                    {
//                        memberMainSpeciality += hyperbarikOxygenTreatmentRequest.ApprovedDoctor.ResourceSpecialities[s].Speciality.Name;
//                        if (!hyperbarikOxygenTreatmentRequest.ApprovedDoctor.ResourceSpecialities[s].Speciality.Name.Contains("Uzm")) memberMainSpeciality += " Uzm.";
//                    }
//                    else
//                    {
//                        memberSpecialities += hyperbarikOxygenTreatmentRequest.ApprovedDoctor.ResourceSpecialities[s].Speciality.Name;
//                        if (!hyperbarikOxygenTreatmentRequest.ApprovedDoctor.ResourceSpecialities[s].Speciality.Name.Contains("Uzm") ) memberSpecialities += " Uzm.";
//                        memberSpecialities+="\r\n";
//                    }
//                    ApprovedDoctor11.CalcValue = memberName + "\r\n" + memberTitle + memberRank + " (" + memberRecId + ")" + "\r\n" + memberMainSpeciality + "\r\n" + memberSpecialities;
//                }
//                
//            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public HyperbaricOxygenRequestReport MyParentReport
                {
                    get { return (HyperbaricOxygenRequestReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public HyperbaricOxygenRequestReport MyParentReport
            {
                get { return (HyperbaricOxygenRequestReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField PatientNameLabel111 { get {return Body().PatientNameLabel111;} }
            public TTReportField PatientNameInfo { get {return Body().PatientNameInfo;} }
            public TTReportField ProtocolNoLabel111 { get {return Body().ProtocolNoLabel111;} }
            public TTReportField PatientBirthInfoLabel111 { get {return Body().PatientBirthInfoLabel111;} }
            public TTReportField PatientBirthInfo { get {return Body().PatientBirthInfo;} }
            public TTReportField PatientIDLabel111 { get {return Body().PatientIDLabel111;} }
            public TTReportField PatientID { get {return Body().PatientID;} }
            public TTReportField PatientAddressLabel111 { get {return Body().PatientAddressLabel111;} }
            public TTReportField PatientOtherHospitalLabel { get {return Body().PatientOtherHospitalLabel;} }
            public TTReportField CAMEHOSPITAL { get {return Body().CAMEHOSPITAL;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField PROTOCOLNO { get {return Body().PROTOCOLNO;} }
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
                list[0] = new TTReportNqlData<HyperbarikOxygenTreatmentRequest.HyperReportQuery_Class>("HyperReportQuery", HyperbarikOxygenTreatmentRequest.HyperReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public HyperbaricOxygenRequestReport MyParentReport
                {
                    get { return (HyperbaricOxygenRequestReport)ParentReport; }
                }
                
                public TTReportField PatientNameLabel111;
                public TTReportField PatientNameInfo;
                public TTReportField ProtocolNoLabel111;
                public TTReportField PatientBirthInfoLabel111;
                public TTReportField PatientBirthInfo;
                public TTReportField PatientIDLabel111;
                public TTReportField PatientID;
                public TTReportField PatientAddressLabel111;
                public TTReportField PatientOtherHospitalLabel;
                public TTReportField CAMEHOSPITAL;
                public TTReportField OBJECTID;
                public TTReportField PROTOCOLNO; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 40;
                    RepeatCount = 0;
                    
                    PatientNameLabel111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 2, 60, 7, false);
                    PatientNameLabel111.Name = "PatientNameLabel111";
                    PatientNameLabel111.Value = @"HASTANIN ADI SOYADI   :";

                    PatientNameInfo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 2, 185, 7, false);
                    PatientNameInfo.Name = "PatientNameInfo";
                    PatientNameInfo.Value = @"";

                    ProtocolNoLabel111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 8, 60, 13, false);
                    ProtocolNoLabel111.Name = "ProtocolNoLabel111";
                    ProtocolNoLabel111.Value = @"PROTOKOL NO   :";

                    PatientBirthInfoLabel111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 14, 60, 19, false);
                    PatientBirthInfoLabel111.Name = "PatientBirthInfoLabel111";
                    PatientBirthInfoLabel111.Value = @"DOĞUM YERİ/TARİHİ   :";

                    PatientBirthInfo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 14, 185, 19, false);
                    PatientBirthInfo.Name = "PatientBirthInfo";
                    PatientBirthInfo.Value = @"";

                    PatientIDLabel111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 20, 60, 25, false);
                    PatientIDLabel111.Name = "PatientIDLabel111";
                    PatientIDLabel111.Value = @"TC KİMLİK NO   :";

                    PatientID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 20, 185, 25, false);
                    PatientID.Name = "PatientID";
                    PatientID.Value = @"";

                    PatientAddressLabel111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 26, 60, 31, false);
                    PatientAddressLabel111.Name = "PatientAddressLabel111";
                    PatientAddressLabel111.Value = @"ADRESİ   :";

                    PatientOtherHospitalLabel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 32, 60, 37, false);
                    PatientOtherHospitalLabel.Name = "PatientOtherHospitalLabel";
                    PatientOtherHospitalLabel.Value = @"GELDİĞİ XXXXXX   :";

                    CAMEHOSPITAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 32, 185, 37, false);
                    CAMEHOSPITAL.Name = "CAMEHOSPITAL";
                    CAMEHOSPITAL.Value = @"";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 47, 239, 52, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 8, 185, 13, false);
                    PROTOCOLNO.Name = "PROTOCOLNO";
                    PROTOCOLNO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HyperbarikOxygenTreatmentRequest.HyperReportQuery_Class dataset_HyperReportQuery = ParentGroup.rsGroup.GetCurrentRecord<HyperbarikOxygenTreatmentRequest.HyperReportQuery_Class>(0);
                    PatientNameLabel111.CalcValue = PatientNameLabel111.Value;
                    PatientNameInfo.CalcValue = PatientNameInfo.Value;
                    ProtocolNoLabel111.CalcValue = ProtocolNoLabel111.Value;
                    PatientBirthInfoLabel111.CalcValue = PatientBirthInfoLabel111.Value;
                    PatientBirthInfo.CalcValue = PatientBirthInfo.Value;
                    PatientIDLabel111.CalcValue = PatientIDLabel111.Value;
                    PatientID.CalcValue = PatientID.Value;
                    PatientAddressLabel111.CalcValue = PatientAddressLabel111.Value;
                    PatientOtherHospitalLabel.CalcValue = PatientOtherHospitalLabel.Value;
                    CAMEHOSPITAL.CalcValue = CAMEHOSPITAL.Value;
                    OBJECTID.CalcValue = (dataset_HyperReportQuery != null ? Globals.ToStringCore(dataset_HyperReportQuery.ObjectID) : "");
                    PROTOCOLNO.CalcValue = PROTOCOLNO.Value;
                    return new TTReportObject[] { PatientNameLabel111,PatientNameInfo,ProtocolNoLabel111,PatientBirthInfoLabel111,PatientBirthInfo,PatientIDLabel111,PatientID,PatientAddressLabel111,PatientOtherHospitalLabel,CAMEHOSPITAL,OBJECTID,PROTOCOLNO};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //            string objectID = this.OBJECTID.CalcValue.ToString();
//            TTObjectContext context = new TTObjectContext(true);
//            HyperbarikOxygenTreatmentRequest hyperbarikOxygenTreatmentRequest = (HyperbarikOxygenTreatmentRequest)context.GetObject(new Guid(objectID), "HyperbarikOxygenTreatmentRequest");
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
////                if (episodeForDiagnosis != null)   {
////                    IList<string> oncekiTanilar = new List<string>();
////                    bool hyperEntry = false;
////                    foreach (DiagnosisGrid diagnosis in episodeForDiagnosis.Diagnosis)
////                    {
////                        if (diagnosis.Diagnose.Name != null && !oncekiTanilar.Contains(diagnosis.Diagnose.Code)) {
////                            if (diagnosis.EntryActionType == TTObjectClasses.ActionTypeEnum.HyperbarikOxygenTreatmentRequest) {
////                                if (!hyperEntry) {
////                                    Diagnosis.CalcValue =  "";
////                                    hyperEntry = true;
////                                }
////                                Diagnosis.CalcValue += (diagnosis.Diagnose.Name).ToString() + " / " + (diagnosis.Diagnose.Code).ToString() + System.Environment.NewLine;
////                            }
////                            else if(!hyperEntry)
////                            {
////                                Diagnosis.CalcValue += (diagnosis.Diagnose.Name).ToString() + " / " + (diagnosis.Diagnose.Code).ToString() + System.Environment.NewLine;
////                            }
////                            oncekiTanilar.Add(diagnosis.Diagnose.Code);
////                        }
////                    }
////                }
//            }
//            
//            if (hyperbarikOxygenTreatmentRequest.ProtocolNo != null && hyperbarikOxygenTreatmentRequest.RequestDate != null)
//                PROTOCOLNO.CalcValue = hyperbarikOxygenTreatmentRequest.ProtocolNo.Value.ToString() + " / " + hyperbarikOxygenTreatmentRequest.RequestDate.Value.ToShortDateString();
////            
////            COMPLAINT.CalcValue = hyperbarikOxygenTreatmentRequest.Complaint != null ? TTObjectClasses.Common.GetTextOfRTFString(hyperbarikOxygenTreatmentRequest.Complaint.ToString())+ "\r\n" : "";
////            HISTORY.CalcValue = hyperbarikOxygenTreatmentRequest.History;
////            PHYSICALEXAMINATION.CalcValue = hyperbarikOxygenTreatmentRequest.PyhsicalExamination != null ? TTObjectClasses.Common.GetTextOfRTFString(hyperbarikOxygenTreatmentRequest.PyhsicalExamination.ToString())+ "\r\n" : "";
//            CAMEHOSPITAL.CalcValue = hyperbarikOxygenTreatmentRequest.CameHospital;
//            //DECISION.CalcValue = hyperbarikOxygenTreatmentRequest.Decision;
//            
////            if (hyperbarikOxygenTreatmentRequest.ProcedureDoctor != null) {
////                string memberName = hyperbarikOxygenTreatmentRequest.ProcedureDoctor.Name;
////                string memberMilClass = hyperbarikOxygenTreatmentRequest.ProcedureDoctor.MilitaryClass == null ? "" : hyperbarikOxygenTreatmentRequest.ProcedureDoctor.MilitaryClass.ShortName;
////                string memberRank = hyperbarikOxygenTreatmentRequest.ProcedureDoctor.Rank == null ? "" : hyperbarikOxygenTreatmentRequest.ProcedureDoctor.Rank.ShortName;
////                string memberTitle = !hyperbarikOxygenTreatmentRequest.ProcedureDoctor.Title.HasValue ? "" : TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(hyperbarikOxygenTreatmentRequest.ProcedureDoctor.Title.Value);
////                string memberRecId = hyperbarikOxygenTreatmentRequest.ProcedureDoctor.EmploymentRecordID == null ? "" : hyperbarikOxygenTreatmentRequest.ProcedureDoctor.EmploymentRecordID;
////                string memberMainSpeciality = "";
////                string memberSpecialities = "";
////                for (int s = 0; s < hyperbarikOxygenTreatmentRequest.ProcedureDoctor.ResourceSpecialities.Count; s++)
////                    if (hyperbarikOxygenTreatmentRequest.ProcedureDoctor.ResourceSpecialities[s].MainSpeciality.Equals(true))
////                {
////                    memberMainSpeciality += hyperbarikOxygenTreatmentRequest.ProcedureDoctor.ResourceSpecialities[s].Speciality.Name;
////                    if (!hyperbarikOxygenTreatmentRequest.ProcedureDoctor.ResourceSpecialities[s].Speciality.Name.Contains("Uzm")) memberMainSpeciality += " Uzm.";
////                }
////                else
////                {
////                    memberSpecialities += hyperbarikOxygenTreatmentRequest.ProcedureDoctor.ResourceSpecialities[s].Speciality.Name;
////                    if (!hyperbarikOxygenTreatmentRequest.ProcedureDoctor.ResourceSpecialities[s].Speciality.Name.Contains("Uzm") ) memberSpecialities += " Uzm.";
////                    memberSpecialities+="\r\n";
////                }
////                RequestDoctor.CalcValue = memberName + "\r\n" + memberTitle + memberRank + " (" + memberRecId + ")" + "\r\n" + memberMainSpeciality + "\r\n" + memberSpecialities;
////            }
////            
////            if (hyperbarikOxygenTreatmentRequest.ApprovedDoctor != null) {
////                string memberName = hyperbarikOxygenTreatmentRequest.ApprovedDoctor.Name;
////                string memberMilClass = hyperbarikOxygenTreatmentRequest.ApprovedDoctor.MilitaryClass == null ? "" : hyperbarikOxygenTreatmentRequest.ApprovedDoctor.MilitaryClass.ShortName;
////                string memberRank = hyperbarikOxygenTreatmentRequest.ApprovedDoctor.Rank == null ? "" : hyperbarikOxygenTreatmentRequest.ApprovedDoctor.Rank.ShortName;
////                string memberTitle = !hyperbarikOxygenTreatmentRequest.ApprovedDoctor.Title.HasValue ? "" : TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(hyperbarikOxygenTreatmentRequest.ApprovedDoctor.Title.Value);
////                string memberRecId = hyperbarikOxygenTreatmentRequest.ApprovedDoctor.EmploymentRecordID == null ? "" : hyperbarikOxygenTreatmentRequest.ApprovedDoctor.EmploymentRecordID;
////                string memberMainSpeciality = "";
////                string memberSpecialities = "";
////                for (int s = 0; s < hyperbarikOxygenTreatmentRequest.ApprovedDoctor.ResourceSpecialities.Count; s++)
////                    if (hyperbarikOxygenTreatmentRequest.ApprovedDoctor.ResourceSpecialities[s].MainSpeciality.Equals(true))
////                {
////                    memberMainSpeciality += hyperbarikOxygenTreatmentRequest.ApprovedDoctor.ResourceSpecialities[s].Speciality.Name;
////                    if (!hyperbarikOxygenTreatmentRequest.ApprovedDoctor.ResourceSpecialities[s].Speciality.Name.Contains("Uzm")) memberMainSpeciality += " Uzm.";
////                }
////                else
////                {
////                    memberSpecialities += hyperbarikOxygenTreatmentRequest.ApprovedDoctor.ResourceSpecialities[s].Speciality.Name;
////                    if (!hyperbarikOxygenTreatmentRequest.ApprovedDoctor.ResourceSpecialities[s].Speciality.Name.Contains("Uzm") ) memberSpecialities += " Uzm.";
////                    memberSpecialities+="\r\n";
////                }
////                ApprovedDoctor.CalcValue = memberName + "\r\n" + memberTitle + memberRank + " (" + memberRecId + ")" + "\r\n" + memberMainSpeciality + "\r\n" + memberSpecialities;
////            }
//
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class SIKAYETGroup : TTReportGroup
        {
            public HyperbaricOxygenRequestReport MyParentReport
            {
                get { return (HyperbaricOxygenRequestReport)ParentReport; }
            }

            new public SIKAYETGroupBody Body()
            {
                return (SIKAYETGroupBody)_body;
            }
            public TTReportField ComplaintLabel1111 { get {return Body().ComplaintLabel1111;} }
            public TTReportField COMPLAINT { get {return Body().COMPLAINT;} }
            public SIKAYETGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public SIKAYETGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new SIKAYETGroupBody(this);
            }

            public partial class SIKAYETGroupBody : TTReportSection
            {
                public HyperbaricOxygenRequestReport MyParentReport
                {
                    get { return (HyperbaricOxygenRequestReport)ParentReport; }
                }
                
                public TTReportField ComplaintLabel1111;
                public TTReportField COMPLAINT; 
                public SIKAYETGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 10;
                    RepeatCount = 0;
                    
                    ComplaintLabel1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 3, 60, 8, false);
                    ComplaintLabel1111.Name = "ComplaintLabel1111";
                    ComplaintLabel1111.Value = @"ŞİKAYETİ   :";

                    COMPLAINT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 3, 185, 8, false);
                    COMPLAINT.Name = "COMPLAINT";
                    COMPLAINT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMPLAINT.MultiLine = EvetHayirEnum.ehEvet;
                    COMPLAINT.NoClip = EvetHayirEnum.ehEvet;
                    COMPLAINT.WordBreak = EvetHayirEnum.ehEvet;
                    COMPLAINT.ExpandTabs = EvetHayirEnum.ehEvet;
                    COMPLAINT.Value = @"{%PARTA.COMPLAINT1%}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ComplaintLabel1111.CalcValue = ComplaintLabel1111.Value;
                    COMPLAINT.CalcValue = MyParentReport.PARTA.COMPLAINT1.CalcValue;
                    return new TTReportObject[] { ComplaintLabel1111,COMPLAINT};
                }
            }

        }

        public SIKAYETGroup SIKAYET;

        public partial class HIKAYESIGroup : TTReportGroup
        {
            public HyperbaricOxygenRequestReport MyParentReport
            {
                get { return (HyperbaricOxygenRequestReport)ParentReport; }
            }

            new public HIKAYESIGroupBody Body()
            {
                return (HIKAYESIGroupBody)_body;
            }
            public TTReportField HistoryLabel11 { get {return Body().HistoryLabel11;} }
            public TTReportField HISTORY { get {return Body().HISTORY;} }
            public HIKAYESIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HIKAYESIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new HIKAYESIGroupBody(this);
            }

            public partial class HIKAYESIGroupBody : TTReportSection
            {
                public HyperbaricOxygenRequestReport MyParentReport
                {
                    get { return (HyperbaricOxygenRequestReport)ParentReport; }
                }
                
                public TTReportField HistoryLabel11;
                public TTReportField HISTORY; 
                public HIKAYESIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    HistoryLabel11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 2, 60, 7, false);
                    HistoryLabel11.Name = "HistoryLabel11";
                    HistoryLabel11.Value = @"HİKAYESİ   :";

                    HISTORY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 2, 186, 7, false);
                    HISTORY.Name = "HISTORY";
                    HISTORY.FieldType = ReportFieldTypeEnum.ftVariable;
                    HISTORY.MultiLine = EvetHayirEnum.ehEvet;
                    HISTORY.NoClip = EvetHayirEnum.ehEvet;
                    HISTORY.WordBreak = EvetHayirEnum.ehEvet;
                    HISTORY.ExpandTabs = EvetHayirEnum.ehEvet;
                    HISTORY.Value = @"{%PARTA.HISTORY1%}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HistoryLabel11.CalcValue = HistoryLabel11.Value;
                    HISTORY.CalcValue = MyParentReport.PARTA.HISTORY1.CalcValue;
                    return new TTReportObject[] { HistoryLabel11,HISTORY};
                }
            }

        }

        public HIKAYESIGroup HIKAYESI;

        public partial class MUAYENEGroup : TTReportGroup
        {
            public HyperbaricOxygenRequestReport MyParentReport
            {
                get { return (HyperbaricOxygenRequestReport)ParentReport; }
            }

            new public MUAYENEGroupBody Body()
            {
                return (MUAYENEGroupBody)_body;
            }
            public TTReportField PyhsicalExamLabel1111 { get {return Body().PyhsicalExamLabel1111;} }
            public TTReportField PHYSICALEXAMINATION { get {return Body().PHYSICALEXAMINATION;} }
            public MUAYENEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MUAYENEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MUAYENEGroupBody(this);
            }

            public partial class MUAYENEGroupBody : TTReportSection
            {
                public HyperbaricOxygenRequestReport MyParentReport
                {
                    get { return (HyperbaricOxygenRequestReport)ParentReport; }
                }
                
                public TTReportField PyhsicalExamLabel1111;
                public TTReportField PHYSICALEXAMINATION; 
                public MUAYENEGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 9;
                    RepeatCount = 0;
                    
                    PyhsicalExamLabel1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 2, 60, 7, false);
                    PyhsicalExamLabel1111.Name = "PyhsicalExamLabel1111";
                    PyhsicalExamLabel1111.Value = @"FİZİK MUAYENE   :";

                    PHYSICALEXAMINATION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 2, 185, 7, false);
                    PHYSICALEXAMINATION.Name = "PHYSICALEXAMINATION";
                    PHYSICALEXAMINATION.FieldType = ReportFieldTypeEnum.ftVariable;
                    PHYSICALEXAMINATION.MultiLine = EvetHayirEnum.ehEvet;
                    PHYSICALEXAMINATION.NoClip = EvetHayirEnum.ehEvet;
                    PHYSICALEXAMINATION.WordBreak = EvetHayirEnum.ehEvet;
                    PHYSICALEXAMINATION.ExpandTabs = EvetHayirEnum.ehEvet;
                    PHYSICALEXAMINATION.Value = @"{%PARTA.PHYSICALEXAMINATION1%}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PyhsicalExamLabel1111.CalcValue = PyhsicalExamLabel1111.Value;
                    PHYSICALEXAMINATION.CalcValue = MyParentReport.PARTA.PHYSICALEXAMINATION1.CalcValue;
                    return new TTReportObject[] { PyhsicalExamLabel1111,PHYSICALEXAMINATION};
                }
            }

        }

        public MUAYENEGroup MUAYENE;

        public partial class TANIGroup : TTReportGroup
        {
            public HyperbaricOxygenRequestReport MyParentReport
            {
                get { return (HyperbaricOxygenRequestReport)ParentReport; }
            }

            new public TANIGroupBody Body()
            {
                return (TANIGroupBody)_body;
            }
            public TTReportField DIAGNOSIS { get {return Body().DIAGNOSIS;} }
            public TTReportField DiagnosisLabel11 { get {return Body().DiagnosisLabel11;} }
            public TANIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TANIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new TANIGroupBody(this);
            }

            public partial class TANIGroupBody : TTReportSection
            {
                public HyperbaricOxygenRequestReport MyParentReport
                {
                    get { return (HyperbaricOxygenRequestReport)ParentReport; }
                }
                
                public TTReportField DIAGNOSIS;
                public TTReportField DiagnosisLabel11; 
                public TANIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 10;
                    RepeatCount = 0;
                    
                    DIAGNOSIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 3, 185, 8, false);
                    DIAGNOSIS.Name = "DIAGNOSIS";
                    DIAGNOSIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSIS.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSIS.NoClip = EvetHayirEnum.ehEvet;
                    DIAGNOSIS.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSIS.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSIS.Value = @"{%PARTA.Diagnosis1%}";

                    DiagnosisLabel11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 3, 60, 8, false);
                    DiagnosisLabel11.Name = "DiagnosisLabel11";
                    DiagnosisLabel11.Value = @"TANISI   :";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DIAGNOSIS.CalcValue = MyParentReport.PARTA.Diagnosis1.CalcValue;
                    DiagnosisLabel11.CalcValue = DiagnosisLabel11.Value;
                    return new TTReportObject[] { DIAGNOSIS,DiagnosisLabel11};
                }
            }

        }

        public TANIGroup TANI;

        public partial class KARARGroup : TTReportGroup
        {
            public HyperbaricOxygenRequestReport MyParentReport
            {
                get { return (HyperbaricOxygenRequestReport)ParentReport; }
            }

            new public KARARGroupBody Body()
            {
                return (KARARGroupBody)_body;
            }
            public TTReportField DecisionLabel11 { get {return Body().DecisionLabel11;} }
            public TTReportField DESICION { get {return Body().DESICION;} }
            public KARARGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public KARARGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new KARARGroupBody(this);
            }

            public partial class KARARGroupBody : TTReportSection
            {
                public HyperbaricOxygenRequestReport MyParentReport
                {
                    get { return (HyperbaricOxygenRequestReport)ParentReport; }
                }
                
                public TTReportField DecisionLabel11;
                public TTReportField DESICION; 
                public KARARGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 9;
                    RepeatCount = 0;
                    
                    DecisionLabel11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 2, 60, 7, false);
                    DecisionLabel11.Name = "DecisionLabel11";
                    DecisionLabel11.Value = @"KARAR   :";

                    DESICION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 2, 185, 7, false);
                    DESICION.Name = "DESICION";
                    DESICION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESICION.MultiLine = EvetHayirEnum.ehEvet;
                    DESICION.NoClip = EvetHayirEnum.ehEvet;
                    DESICION.WordBreak = EvetHayirEnum.ehEvet;
                    DESICION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESICION.Value = @"{%PARTA.DECISION1%}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DecisionLabel11.CalcValue = DecisionLabel11.Value;
                    DESICION.CalcValue = MyParentReport.PARTA.DECISION1.CalcValue;
                    return new TTReportObject[] { DecisionLabel11,DESICION};
                }
            }

        }

        public KARARGroup KARAR;

        public partial class DOKTORGroup : TTReportGroup
        {
            public HyperbaricOxygenRequestReport MyParentReport
            {
                get { return (HyperbaricOxygenRequestReport)ParentReport; }
            }

            new public DOKTORGroupBody Body()
            {
                return (DOKTORGroupBody)_body;
            }
            public TTReportField RequestDoctor2 { get {return Body().RequestDoctor2;} }
            public TTReportField RequestDoctorLabel111 { get {return Body().RequestDoctorLabel111;} }
            public TTReportField ApprovedDoctorLabel111 { get {return Body().ApprovedDoctorLabel111;} }
            public TTReportField ApprovedDoctor2 { get {return Body().ApprovedDoctor2;} }
            public DOKTORGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public DOKTORGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new DOKTORGroupBody(this);
            }

            public partial class DOKTORGroupBody : TTReportSection
            {
                public HyperbaricOxygenRequestReport MyParentReport
                {
                    get { return (HyperbaricOxygenRequestReport)ParentReport; }
                }
                
                public TTReportField RequestDoctor2;
                public TTReportField RequestDoctorLabel111;
                public TTReportField ApprovedDoctorLabel111;
                public TTReportField ApprovedDoctor2; 
                public DOKTORGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 15;
                    RepeatCount = 0;
                    
                    RequestDoctor2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 8, 65, 14, false);
                    RequestDoctor2.Name = "RequestDoctor2";
                    RequestDoctor2.FieldType = ReportFieldTypeEnum.ftVariable;
                    RequestDoctor2.MultiLine = EvetHayirEnum.ehEvet;
                    RequestDoctor2.NoClip = EvetHayirEnum.ehEvet;
                    RequestDoctor2.WordBreak = EvetHayirEnum.ehEvet;
                    RequestDoctor2.ExpandTabs = EvetHayirEnum.ehEvet;
                    RequestDoctor2.Value = @"{%PARTA.RequestDoctor11%}
";

                    RequestDoctorLabel111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 2, 65, 7, false);
                    RequestDoctorLabel111.Name = "RequestDoctorLabel111";
                    RequestDoctorLabel111.Value = @"İSTEK YAPAN DOKTOR   :";

                    ApprovedDoctorLabel111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 2, 199, 7, false);
                    ApprovedDoctorLabel111.Name = "ApprovedDoctorLabel111";
                    ApprovedDoctorLabel111.Value = @"ONAYLAYAN DOKTOR   :";

                    ApprovedDoctor2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 8, 199, 13, false);
                    ApprovedDoctor2.Name = "ApprovedDoctor2";
                    ApprovedDoctor2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ApprovedDoctor2.MultiLine = EvetHayirEnum.ehEvet;
                    ApprovedDoctor2.NoClip = EvetHayirEnum.ehEvet;
                    ApprovedDoctor2.WordBreak = EvetHayirEnum.ehEvet;
                    ApprovedDoctor2.ExpandTabs = EvetHayirEnum.ehEvet;
                    ApprovedDoctor2.Value = @"{%PARTA.ApprovedDoctor11%}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    RequestDoctor2.CalcValue = MyParentReport.PARTA.RequestDoctor11.CalcValue + @"
";
                    RequestDoctorLabel111.CalcValue = RequestDoctorLabel111.Value;
                    ApprovedDoctorLabel111.CalcValue = ApprovedDoctorLabel111.Value;
                    ApprovedDoctor2.CalcValue = MyParentReport.PARTA.ApprovedDoctor11.CalcValue;
                    return new TTReportObject[] { RequestDoctor2,RequestDoctorLabel111,ApprovedDoctorLabel111,ApprovedDoctor2};
                }
            }

        }

        public DOKTORGroup DOKTOR;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HyperbaricOxygenRequestReport()
        {
            main = new mainGroup(this,"main");
            PARTA = new PARTAGroup(main,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            SIKAYET = new SIKAYETGroup(PARTA,"SIKAYET");
            HIKAYESI = new HIKAYESIGroup(PARTA,"HIKAYESI");
            MUAYENE = new MUAYENEGroup(PARTA,"MUAYENE");
            TANI = new TANIGroup(PARTA,"TANI");
            KARAR = new KARARGroup(PARTA,"KARAR");
            DOKTOR = new DOKTORGroup(PARTA,"DOKTOR");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HYPERBARICOXYGENREQUESTREPORT";
            Caption = "Hiperbarik Tedavi İstek Rap";
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