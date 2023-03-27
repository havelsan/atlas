
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
    public partial class PhysiotherapyRequestReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string PHYSIOTHERAPYREQUEST = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HeaderGroup : TTReportGroup
        {
            public PhysiotherapyRequestReport MyParentReport
            {
                get { return (PhysiotherapyRequestReport)ParentReport; }
            }

            new public HeaderGroupHeader Header()
            {
                return (HeaderGroupHeader)_header;
            }

            new public HeaderGroupFooter Footer()
            {
                return (HeaderGroupFooter)_footer;
            }

            public TTReportField HospitalInfo { get {return Header().HospitalInfo;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField NewField { get {return Footer().NewField;} }
            public TTReportField DoctorName { get {return Footer().DoctorName;} }
            public HeaderGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HeaderGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HeaderGroupHeader(this);
                _footer = new HeaderGroupFooter(this);

            }

            public partial class HeaderGroupHeader : TTReportSection
            {
                public PhysiotherapyRequestReport MyParentReport
                {
                    get { return (PhysiotherapyRequestReport)ParentReport; }
                }
                
                public TTReportField HospitalInfo;
                public TTReportField LOGO; 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 44;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HospitalInfo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 8, 196, 38, false);
                    HospitalInfo.Name = "HospitalInfo";
                    HospitalInfo.FieldType = ReportFieldTypeEnum.ftExpression;
                    HospitalInfo.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HospitalInfo.MultiLine = EvetHayirEnum.ehEvet;
                    HospitalInfo.NoClip = EvetHayirEnum.ehEvet;
                    HospitalInfo.WordBreak = EvetHayirEnum.ehEvet;
                    HospitalInfo.ExpandTabs = EvetHayirEnum.ehEvet;
                    HospitalInfo.TextFont.Size = 14;
                    HospitalInfo.TextFont.Bold = true;
                    HospitalInfo.TextFont.CharSet = 162;
                    HospitalInfo.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 10, 35, 33, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.TextFont.CharSet = 162;
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = @"";
                    HospitalInfo.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { LOGO,HospitalInfo};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion HEADER HEADER_Script
                }
            }
            public partial class HeaderGroupFooter : TTReportSection
            {
                public PhysiotherapyRequestReport MyParentReport
                {
                    get { return (PhysiotherapyRequestReport)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField DoctorName; 
                public HeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 6, 183, 11, false);
                    NewField.Name = "NewField";
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.Value = @"İmza";

                    DoctorName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 12, 208, 17, false);
                    DoctorName.Name = "DoctorName";
                    DoctorName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DoctorName.ObjectDefName = "UserTitleEnum";
                    DoctorName.DataMember = "Description";
                    DoctorName.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField.CalcValue = NewField.Value;
                    DoctorName.CalcValue = DoctorName.Value;
                    return new TTReportObject[] { NewField,DoctorName};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
                    PhysiotherapyRequest physiotherapyRequest = (PhysiotherapyRequest)objectContext.GetObject(new Guid(MyParentReport.RuntimeParameters.PHYSIOTHERAPYREQUEST), "PhysiotherapyRequest");
                                       this.DoctorName.CalcValue = ((TTDataDictionary.ITTEnumValueDef)TTObjectDefManager.Instance.DataTypes["UserTitleEnum"].EnumValueDefs[physiotherapyRequest.ProcedureDoctor.Title.Value.ToString()]).DisplayText.ToString() + " " + physiotherapyRequest.ProcedureDoctor.Name.ToString();
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HeaderGroup Header;

        public partial class PatientInfoGroup : TTReportGroup
        {
            public PhysiotherapyRequestReport MyParentReport
            {
                get { return (PhysiotherapyRequestReport)ParentReport; }
            }

            new public PatientInfoGroupBody Body()
            {
                return (PatientInfoGroupBody)_body;
            }
            public TTReportField Field { get {return Body().Field;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField Name { get {return Body().Name;} }
            public TTReportField RequestedSection { get {return Body().RequestedSection;} }
            public TTReportField RequestDate { get {return Body().RequestDate;} }
            public TTReportField BirthDate { get {return Body().BirthDate;} }
            public TTReportField PhoneNum { get {return Body().PhoneNum;} }
            public TTReportField Field1 { get {return Body().Field1;} }
            public TTReportField UnitName1 { get {return Body().UnitName1;} }
            public TTReportField ProcedureName1 { get {return Body().ProcedureName1;} }
            public TTReportField AppliedArea1 { get {return Body().AppliedArea1;} }
            public TTReportField ApplicationAreaInfo1 { get {return Body().ApplicationAreaInfo1;} }
            public TTReportField Dose1 { get {return Body().Dose1;} }
            public TTReportField Duration1 { get {return Body().Duration1;} }
            public TTReportField TotalSession1 { get {return Body().TotalSession1;} }
            public TTReportField Info1 { get {return Body().Info1;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField TcNum { get {return Body().TcNum;} }
            public TTReportField NewField142 { get {return Body().NewField142;} }
            public TTReportField Diagnose { get {return Body().Diagnose;} }
            public PatientInfoGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PatientInfoGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PatientInfoGroupBody(this);
            }

            public partial class PatientInfoGroupBody : TTReportSection
            {
                public PhysiotherapyRequestReport MyParentReport
                {
                    get { return (PhysiotherapyRequestReport)ParentReport; }
                }
                
                public TTReportField Field;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField Name;
                public TTReportField RequestedSection;
                public TTReportField RequestDate;
                public TTReportField BirthDate;
                public TTReportField PhoneNum;
                public TTReportField Field1;
                public TTReportField UnitName1;
                public TTReportField ProcedureName1;
                public TTReportField AppliedArea1;
                public TTReportField ApplicationAreaInfo1;
                public TTReportField Dose1;
                public TTReportField Duration1;
                public TTReportField TotalSession1;
                public TTReportField Info1;
                public TTReportField NewField141;
                public TTReportField TcNum;
                public TTReportField NewField142;
                public TTReportField Diagnose; 
                public PatientInfoGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 63;
                    RepeatCount = 0;
                    
                    Field = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 2, 37, 8, false);
                    Field.Name = "Field";
                    Field.TextFont.Size = 12;
                    Field.TextFont.Bold = true;
                    Field.TextFont.Underline = true;
                    Field.TextFont.CharSet = 162;
                    Field.Value = @"Hasta Bilgileri:";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 12, 45, 17, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Hasta Adı Soyadı  :";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 19, 45, 24, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Birimi  :";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 12, 173, 17, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"İstek Tarihi  :";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 19, 120, 24, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Size = 11;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Doğum Tarihi  :";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 20, 181, 25, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Size = 11;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Telefon Numarası  :";

                    Name = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 12, 88, 17, false);
                    Name.Name = "Name";
                    Name.TextFont.CharSet = 162;
                    Name.Value = @"NewField2";

                    RequestedSection = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 19, 90, 29, false);
                    RequestedSection.Name = "RequestedSection";
                    RequestedSection.TextFont.CharSet = 162;
                    RequestedSection.Value = @"NewField2";

                    RequestDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 12, 198, 17, false);
                    RequestDate.Name = "RequestDate";
                    RequestDate.TextFormat = @"dd/MM/yyyy";
                    RequestDate.TextFont.CharSet = 162;
                    RequestDate.Value = @"NewField2";

                    BirthDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 19, 143, 24, false);
                    BirthDate.Name = "BirthDate";
                    BirthDate.TextFormat = @"dd/MM/yyyy";
                    BirthDate.TextFont.CharSet = 162;
                    BirthDate.Value = @"NewField2";

                    PhoneNum = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 20, 206, 25, false);
                    PhoneNum.Name = "PhoneNum";
                    PhoneNum.TextFont.CharSet = 162;
                    PhoneNum.Value = @"NewField2";

                    Field1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 46, 37, 52, false);
                    Field1.Name = "Field1";
                    Field1.TextFont.Size = 12;
                    Field1.TextFont.Bold = true;
                    Field1.TextFont.Underline = true;
                    Field1.TextFont.CharSet = 162;
                    Field1.Value = @"Seans Bilgileri:";

                    UnitName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 54, 45, 63, false);
                    UnitName1.Name = "UnitName1";
                    UnitName1.DrawStyle = DrawStyleConstants.vbSolid;
                    UnitName1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UnitName1.TextFont.Bold = true;
                    UnitName1.TextFont.CharSet = 162;
                    UnitName1.Value = @"Tedavi Ünitesi";

                    ProcedureName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 54, 74, 63, false);
                    ProcedureName1.Name = "ProcedureName1";
                    ProcedureName1.DrawStyle = DrawStyleConstants.vbSolid;
                    ProcedureName1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ProcedureName1.TextFont.Bold = true;
                    ProcedureName1.TextFont.CharSet = 162;
                    ProcedureName1.Value = @"İşlem";

                    AppliedArea1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 54, 106, 63, false);
                    AppliedArea1.Name = "AppliedArea1";
                    AppliedArea1.DrawStyle = DrawStyleConstants.vbSolid;
                    AppliedArea1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AppliedArea1.TextFont.Bold = true;
                    AppliedArea1.TextFont.CharSet = 162;
                    AppliedArea1.Value = @"Vücut Bölgesi";

                    ApplicationAreaInfo1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 54, 139, 63, false);
                    ApplicationAreaInfo1.Name = "ApplicationAreaInfo1";
                    ApplicationAreaInfo1.DrawStyle = DrawStyleConstants.vbSolid;
                    ApplicationAreaInfo1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ApplicationAreaInfo1.TextFont.Bold = true;
                    ApplicationAreaInfo1.TextFont.CharSet = 162;
                    ApplicationAreaInfo1.Value = @"Vücut Bölgesi Açıklama
";

                    Dose1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 54, 180, 63, false);
                    Dose1.Name = "Dose1";
                    Dose1.DrawStyle = DrawStyleConstants.vbSolid;
                    Dose1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Dose1.TextFont.Bold = true;
                    Dose1.TextFont.CharSet = 162;
                    Dose1.Value = @"Doz";

                    Duration1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 54, 166, 63, false);
                    Duration1.Name = "Duration1";
                    Duration1.DrawStyle = DrawStyleConstants.vbSolid;
                    Duration1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Duration1.TextFont.Bold = true;
                    Duration1.TextFont.CharSet = 162;
                    Duration1.Value = @"Süre";

                    TotalSession1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 54, 152, 63, false);
                    TotalSession1.Name = "TotalSession1";
                    TotalSession1.DrawStyle = DrawStyleConstants.vbSolid;
                    TotalSession1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TotalSession1.TextFont.Bold = true;
                    TotalSession1.TextFont.CharSet = 162;
                    TotalSession1.Value = @"Seans";

                    Info1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 54, 208, 63, false);
                    Info1.Name = "Info1";
                    Info1.DrawStyle = DrawStyleConstants.vbSolid;
                    Info1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Info1.TextFont.Bold = true;
                    Info1.TextFont.CharSet = 162;
                    Info1.Value = @"Açıklama";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 12, 126, 17, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Size = 11;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"TC Kimlik No :";

                    TcNum = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 12, 143, 17, false);
                    TcNum.Name = "TcNum";
                    TcNum.TextFont.CharSet = 162;
                    TcNum.Value = @"NewField2";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 33, 41, 38, false);
                    NewField142.Name = "NewField142";
                    NewField142.TextFont.Size = 11;
                    NewField142.TextFont.Bold = true;
                    NewField142.TextFont.CharSet = 162;
                    NewField142.Value = @"Tanılar  :";

                    Diagnose = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 33, 206, 45, false);
                    Diagnose.Name = "Diagnose";
                    Diagnose.MultiLine = EvetHayirEnum.ehEvet;
                    Diagnose.NoClip = EvetHayirEnum.ehEvet;
                    Diagnose.WordBreak = EvetHayirEnum.ehEvet;
                    Diagnose.ExpandTabs = EvetHayirEnum.ehEvet;
                    Diagnose.TextFont.CharSet = 162;
                    Diagnose.Value = @"NewField2";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Field.CalcValue = Field.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    Name.CalcValue = Name.Value;
                    RequestedSection.CalcValue = RequestedSection.Value;
                    RequestDate.CalcValue = RequestDate.Value;
                    BirthDate.CalcValue = BirthDate.Value;
                    PhoneNum.CalcValue = PhoneNum.Value;
                    Field1.CalcValue = Field1.Value;
                    UnitName1.CalcValue = UnitName1.Value;
                    ProcedureName1.CalcValue = ProcedureName1.Value;
                    AppliedArea1.CalcValue = AppliedArea1.Value;
                    ApplicationAreaInfo1.CalcValue = ApplicationAreaInfo1.Value;
                    Dose1.CalcValue = Dose1.Value;
                    Duration1.CalcValue = Duration1.Value;
                    TotalSession1.CalcValue = TotalSession1.Value;
                    Info1.CalcValue = Info1.Value;
                    NewField141.CalcValue = NewField141.Value;
                    TcNum.CalcValue = TcNum.Value;
                    NewField142.CalcValue = NewField142.Value;
                    Diagnose.CalcValue = Diagnose.Value;
                    return new TTReportObject[] { Field,NewField1,NewField11,NewField12,NewField13,NewField14,Name,RequestedSection,RequestDate,BirthDate,PhoneNum,Field1,UnitName1,ProcedureName1,AppliedArea1,ApplicationAreaInfo1,Dose1,Duration1,TotalSession1,Info1,NewField141,TcNum,NewField142,Diagnose};
                }

                public override void RunScript()
                {
#region PATIENTINFO BODY_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
                    PhysiotherapyRequest physiotherapyRequest = (PhysiotherapyRequest)objectContext.GetObject(new Guid(MyParentReport.RuntimeParameters.PHYSIOTHERAPYREQUEST), "PhysiotherapyRequest");
                    this.Name.CalcValue = physiotherapyRequest.Episode.Patient.Name.ToString() + " " + physiotherapyRequest.Episode.Patient.Surname.ToString();
                    this.RequestedSection.CalcValue = physiotherapyRequest.FromResource.Name.ToString();
                    this.RequestDate.CalcValue = physiotherapyRequest.RequestDate.ToString();
                    this.BirthDate.CalcValue = physiotherapyRequest.Episode.Patient.BirthDate.ToString();                    
                    this.PhoneNum.CalcValue = physiotherapyRequest.SubEpisode.PatientAdmission.PA_Address.MobilePhone != null ? physiotherapyRequest.SubEpisode.PatientAdmission.PA_Address.MobilePhone.ToString() : "";
                    this.TcNum.CalcValue=physiotherapyRequest.Episode.Patient.UniqueRefNo!= null ? physiotherapyRequest.Episode.Patient.UniqueRefNo.ToString() :physiotherapyRequest.Episode.Patient.YUPASSNO.ToString();
                    this.Diagnose.CalcValue = "";
                    DiagnosisGrid[] episodeDiagnosis = physiotherapyRequest.Episode.Diagnosis.ToArray();
                    if (episodeDiagnosis.Length > 0)
                    {
                        foreach (DiagnosisGrid dG in episodeDiagnosis)
                        {
                            this.Diagnose.CalcValue += dG.Diagnose.Name + " - ";
                        }
                        this.Diagnose.CalcValue = this.Diagnose.CalcValue.Remove(this.Diagnose.CalcValue.Length - 3);

                    }
#endregion PATIENTINFO BODY_Script
                }
            }

        }

        public PatientInfoGroup PatientInfo;

        public partial class UnitGroup : TTReportGroup
        {
            public PhysiotherapyRequestReport MyParentReport
            {
                get { return (PhysiotherapyRequestReport)ParentReport; }
            }

            new public UnitGroupHeader Header()
            {
                return (UnitGroupHeader)_header;
            }

            new public UnitGroupFooter Footer()
            {
                return (UnitGroupFooter)_footer;
            }

            public TTReportField DiagnosisUnit1 { get {return Header().DiagnosisUnit1;} }
            public UnitGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public UnitGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PhysiotherapyOrder.GetExistingPhysiotherapyUnits_Class>("GetExistingPhysiotherapyUnits", PhysiotherapyOrder.GetExistingPhysiotherapyUnits((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.PHYSIOTHERAPYREQUEST)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new UnitGroupHeader(this);
                _footer = new UnitGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class UnitGroupHeader : TTReportSection
            {
                public PhysiotherapyRequestReport MyParentReport
                {
                    get { return (PhysiotherapyRequestReport)ParentReport; }
                }
                
                public TTReportField DiagnosisUnit1; 
                public UnitGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    DiagnosisUnit1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 1, 255, 6, false);
                    DiagnosisUnit1.Name = "DiagnosisUnit1";
                    DiagnosisUnit1.Visible = EvetHayirEnum.ehHayir;
                    DiagnosisUnit1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DiagnosisUnit1.Value = @"{#TREATMENTDIAGNOSISUNIT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PhysiotherapyOrder.GetExistingPhysiotherapyUnits_Class dataset_GetExistingPhysiotherapyUnits = ParentGroup.rsGroup.GetCurrentRecord<PhysiotherapyOrder.GetExistingPhysiotherapyUnits_Class>(0);
                    DiagnosisUnit1.CalcValue = (dataset_GetExistingPhysiotherapyUnits != null ? Globals.ToStringCore(dataset_GetExistingPhysiotherapyUnits.TreatmentDiagnosisUnit) : "");
                    return new TTReportObject[] { DiagnosisUnit1};
                }
            }
            public partial class UnitGroupFooter : TTReportSection
            {
                public PhysiotherapyRequestReport MyParentReport
                {
                    get { return (PhysiotherapyRequestReport)ParentReport; }
                }
                 
                public UnitGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 11;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public UnitGroup Unit;

        public partial class MAINGroup : TTReportGroup
        {
            public PhysiotherapyRequestReport MyParentReport
            {
                get { return (PhysiotherapyRequestReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField UnitName { get {return Body().UnitName;} }
            public TTReportField ProcedureName { get {return Body().ProcedureName;} }
            public TTReportField AppliedArea { get {return Body().AppliedArea;} }
            public TTReportField ApplicationAreaInfo { get {return Body().ApplicationAreaInfo;} }
            public TTReportField Dose { get {return Body().Dose;} }
            public TTReportField Duration { get {return Body().Duration;} }
            public TTReportField Info { get {return Body().Info;} }
            public TTReportField Session { get {return Body().Session;} }
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
                list[0] = new TTReportNqlData<PhysiotherapyOrder.GetPhysiotherapyOrdersByUnitAndRequest_Class>("GetPhysiotherapyOrdersByUnitAndRequest", PhysiotherapyOrder.GetPhysiotherapyOrdersByUnitAndRequest((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.PHYSIOTHERAPYREQUEST),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.Unit.DiagnosisUnit1.CalcValue)));
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
                public PhysiotherapyRequestReport MyParentReport
                {
                    get { return (PhysiotherapyRequestReport)ParentReport; }
                }
                
                public TTReportField UnitName;
                public TTReportField ProcedureName;
                public TTReportField AppliedArea;
                public TTReportField ApplicationAreaInfo;
                public TTReportField Dose;
                public TTReportField Duration;
                public TTReportField Info;
                public TTReportField Session; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 11;
                    RepeatCount = 0;
                    
                    UnitName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 0, 45, 9, false);
                    UnitName.Name = "UnitName";
                    UnitName.DrawStyle = DrawStyleConstants.vbSolid;
                    UnitName.FieldType = ReportFieldTypeEnum.ftVariable;
                    UnitName.MultiLine = EvetHayirEnum.ehEvet;
                    UnitName.WordBreak = EvetHayirEnum.ehEvet;
                    UnitName.ExpandTabs = EvetHayirEnum.ehEvet;
                    UnitName.TextFont.Bold = true;
                    UnitName.TextFont.CharSet = 162;
                    UnitName.Value = @"  {#Unit.NAME#}";

                    ProcedureName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 0, 74, 9, false);
                    ProcedureName.Name = "ProcedureName";
                    ProcedureName.DrawStyle = DrawStyleConstants.vbSolid;
                    ProcedureName.FieldType = ReportFieldTypeEnum.ftVariable;
                    ProcedureName.TextFont.CharSet = 162;
                    ProcedureName.Value = @"  {#NAME#}";

                    AppliedArea = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 0, 106, 9, false);
                    AppliedArea.Name = "AppliedArea";
                    AppliedArea.DrawStyle = DrawStyleConstants.vbSolid;
                    AppliedArea.FieldType = ReportFieldTypeEnum.ftVariable;
                    AppliedArea.MultiLine = EvetHayirEnum.ehEvet;
                    AppliedArea.WordBreak = EvetHayirEnum.ehEvet;
                    AppliedArea.ExpandTabs = EvetHayirEnum.ehEvet;
                    AppliedArea.TextFont.CharSet = 162;
                    AppliedArea.Value = @"  {#UYGULANANBOLGE#}";

                    ApplicationAreaInfo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 0, 139, 9, false);
                    ApplicationAreaInfo.Name = "ApplicationAreaInfo";
                    ApplicationAreaInfo.DrawStyle = DrawStyleConstants.vbSolid;
                    ApplicationAreaInfo.FieldType = ReportFieldTypeEnum.ftVariable;
                    ApplicationAreaInfo.MultiLine = EvetHayirEnum.ehEvet;
                    ApplicationAreaInfo.WordBreak = EvetHayirEnum.ehEvet;
                    ApplicationAreaInfo.ExpandTabs = EvetHayirEnum.ehEvet;
                    ApplicationAreaInfo.TextFont.CharSet = 162;
                    ApplicationAreaInfo.Value = @"  {#APPLICATIONAREA#}";

                    Dose = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 0, 180, 9, false);
                    Dose.Name = "Dose";
                    Dose.DrawStyle = DrawStyleConstants.vbSolid;
                    Dose.FieldType = ReportFieldTypeEnum.ftVariable;
                    Dose.TextFont.CharSet = 162;
                    Dose.Value = @"  {#DOSE#}";

                    Duration = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 0, 166, 9, false);
                    Duration.Name = "Duration";
                    Duration.DrawStyle = DrawStyleConstants.vbSolid;
                    Duration.FieldType = ReportFieldTypeEnum.ftVariable;
                    Duration.TextFont.CharSet = 162;
                    Duration.Value = @"  {#DURATION#}";

                    Info = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 0, 208, 9, false);
                    Info.Name = "Info";
                    Info.DrawStyle = DrawStyleConstants.vbSolid;
                    Info.FieldType = ReportFieldTypeEnum.ftVariable;
                    Info.MultiLine = EvetHayirEnum.ehEvet;
                    Info.WordBreak = EvetHayirEnum.ehEvet;
                    Info.ExpandTabs = EvetHayirEnum.ehEvet;
                    Info.TextFont.CharSet = 162;
                    Info.Value = @"  {#TREATMENTPROPERTIES#}";

                    Session = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 0, 152, 9, false);
                    Session.Name = "Session";
                    Session.DrawStyle = DrawStyleConstants.vbSolid;
                    Session.FieldType = ReportFieldTypeEnum.ftVariable;
                    Session.TextFont.CharSet = 162;
                    Session.Value = @"  {#SESSIONCOUNT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PhysiotherapyOrder.GetPhysiotherapyOrdersByUnitAndRequest_Class dataset_GetPhysiotherapyOrdersByUnitAndRequest = ParentGroup.rsGroup.GetCurrentRecord<PhysiotherapyOrder.GetPhysiotherapyOrdersByUnitAndRequest_Class>(0);
                    PhysiotherapyOrder.GetExistingPhysiotherapyUnits_Class dataset_GetExistingPhysiotherapyUnits = MyParentReport.Unit.rsGroup.GetCurrentRecord<PhysiotherapyOrder.GetExistingPhysiotherapyUnits_Class>(0);
                    UnitName.CalcValue = @"  " + (dataset_GetExistingPhysiotherapyUnits != null ? Globals.ToStringCore(dataset_GetExistingPhysiotherapyUnits.Name) : "");
                    ProcedureName.CalcValue = @"  " + (dataset_GetPhysiotherapyOrdersByUnitAndRequest != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrdersByUnitAndRequest.Name) : "");
                    AppliedArea.CalcValue = @"  " + (dataset_GetPhysiotherapyOrdersByUnitAndRequest != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrdersByUnitAndRequest.Uygulananbolge) : "");
                    ApplicationAreaInfo.CalcValue = @"  " + (dataset_GetPhysiotherapyOrdersByUnitAndRequest != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrdersByUnitAndRequest.ApplicationArea) : "");
                    Dose.CalcValue = @"  " + (dataset_GetPhysiotherapyOrdersByUnitAndRequest != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrdersByUnitAndRequest.Dose) : "");
                    Duration.CalcValue = @"  " + (dataset_GetPhysiotherapyOrdersByUnitAndRequest != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrdersByUnitAndRequest.Duration) : "");
                    Info.CalcValue = @"  " + (dataset_GetPhysiotherapyOrdersByUnitAndRequest != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrdersByUnitAndRequest.TreatmentProperties) : "");
                    Session.CalcValue = @"  " + (dataset_GetPhysiotherapyOrdersByUnitAndRequest != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrdersByUnitAndRequest.SessionCount) : "");
                    return new TTReportObject[] { UnitName,ProcedureName,AppliedArea,ApplicationAreaInfo,Dose,Duration,Info,Session};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            PhysiotherapyRequest physiotherapyRequest = (PhysiotherapyRequest)objectContext.GetObject(new Guid(MyParentReport.RuntimeParameters.PHYSIOTHERAPYREQUEST), "PhysiotherapyRequest");                   
            //this.Session.CalcValue+=physiotherapyRequest.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled).GroupBy(x => x.SessionNumber).Count().ToString();
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

        public PhysiotherapyRequestReport()
        {
            Header = new HeaderGroup(this,"Header");
            PatientInfo = new PatientInfoGroup(Header,"PatientInfo");
            Unit = new UnitGroup(Header,"Unit");
            MAIN = new MAINGroup(Unit,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("PHYSIOTHERAPYREQUEST", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("PHYSIOTHERAPYREQUEST"))
                _runtimeParameters.PHYSIOTHERAPYREQUEST = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["PHYSIOTHERAPYREQUEST"]);
            Name = "PHYSIOTHERAPYREQUESTREPORT";
            Caption = "Fizyoterapi İstek Formu";
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