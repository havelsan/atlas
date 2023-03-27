
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
    public partial class SocialServicesPatientFamilyInfoReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HeaderGroup : TTReportGroup
        {
            public SocialServicesPatientFamilyInfoReport MyParentReport
            {
                get { return (SocialServicesPatientFamilyInfoReport)ParentReport; }
            }

            new public HeaderGroupHeader Header()
            {
                return (HeaderGroupHeader)_header;
            }

            new public HeaderGroupFooter Footer()
            {
                return (HeaderGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK111 { get {return Header().XXXXXXBASLIK111;} }
            public TTReportField REPORTHEADER1111 { get {return Header().REPORTHEADER1111;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField NewField11 { get {return Footer().NewField11;} }
            public TTReportField ProcedureByUser { get {return Footer().ProcedureByUser;} }
            public TTReportField NewField1121 { get {return Footer().NewField1121;} }
            public HeaderGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HeaderGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<SocServPatientFamilyInfo.GetSocServPatientFamilyInfo_Class>("GetSocServPatientFamilyInfo", SocServPatientFamilyInfo.GetSocServPatientFamilyInfo((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HeaderGroupHeader(this);
                _footer = new HeaderGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HeaderGroupHeader : TTReportSection
            {
                public SocialServicesPatientFamilyInfoReport MyParentReport
                {
                    get { return (SocialServicesPatientFamilyInfoReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK111;
                public TTReportField REPORTHEADER1111;
                public TTReportField LOGO; 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 51;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 4, 202, 38, false);
                    XXXXXXBASLIK111.Name = "XXXXXXBASLIK111";
                    XXXXXXBASLIK111.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK111.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK111.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK111.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK111.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK111.TextFont.Size = 14;
                    XXXXXXBASLIK111.TextFont.Bold = true;
                    XXXXXXBASLIK111.TextFont.CharSet = 162;
                    XXXXXXBASLIK111.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    REPORTHEADER1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 41, 188, 47, false);
                    REPORTHEADER1111.Name = "REPORTHEADER1111";
                    REPORTHEADER1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER1111.TextFont.Size = 12;
                    REPORTHEADER1111.TextFont.Bold = true;
                    REPORTHEADER1111.TextFont.CharSet = 162;
                    REPORTHEADER1111.Value = @"SOSYAL HİZMET HASTA-AİLE BİLGİ FORMU";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 17, 35, 40, false);
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
                    SocServPatientFamilyInfo.GetSocServPatientFamilyInfo_Class dataset_GetSocServPatientFamilyInfo = ParentGroup.rsGroup.GetCurrentRecord<SocServPatientFamilyInfo.GetSocServPatientFamilyInfo_Class>(0);
                    REPORTHEADER1111.CalcValue = REPORTHEADER1111.Value;
                    LOGO.CalcValue = @"";
                    XXXXXXBASLIK111.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { REPORTHEADER1111,LOGO,XXXXXXBASLIK111};
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
                public SocialServicesPatientFamilyInfoReport MyParentReport
                {
                    get { return (SocialServicesPatientFamilyInfoReport)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField ProcedureByUser;
                public TTReportField NewField1121; 
                public HeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 4, 182, 9, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.Value = @"İmza";

                    ProcedureByUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 10, 206, 15, false);
                    ProcedureByUser.Name = "ProcedureByUser";
                    ProcedureByUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ProcedureByUser.ObjectDefName = "UserTitleEnum";
                    ProcedureByUser.DataMember = "Description";
                    ProcedureByUser.TextFont.Size = 12;
                    ProcedureByUser.TextFont.CharSet = 162;
                    ProcedureByUser.Value = @"";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 16, 189, 21, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Sosyal Hizmet Uzmanı";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SocServPatientFamilyInfo.GetSocServPatientFamilyInfo_Class dataset_GetSocServPatientFamilyInfo = ParentGroup.rsGroup.GetCurrentRecord<SocServPatientFamilyInfo.GetSocServPatientFamilyInfo_Class>(0);
                    NewField11.CalcValue = NewField11.Value;
                    ProcedureByUser.CalcValue = ProcedureByUser.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    return new TTReportObject[] { NewField11,ProcedureByUser,NewField1121};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    TTObjectContext objectContext = new TTObjectContext(true);             
            SocServPatientFamilyInfo patientFamilyInfo = (SocServPatientFamilyInfo)objectContext.GetObject(new Guid(MyParentReport.RuntimeParameters.TTOBJECTID), "SocServPatientFamilyInfo");
             this.ProcedureByUser.CalcValue = patientFamilyInfo.PatientInterviewForm[0].ProcedureByUser.Name;
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HeaderGroup Header;

        public partial class MAINGroup : TTReportGroup
        {
            public SocialServicesPatientFamilyInfoReport MyParentReport
            {
                get { return (SocialServicesPatientFamilyInfoReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField PROCEDUREBYUSER { get {return Body().PROCEDUREBYUSER;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField EXAMINATIONDATE { get {return Body().EXAMINATIONDATE;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NameSurname { get {return Body().NameSurname;} }
            public TTReportField BirthDatePlace { get {return Body().BirthDatePlace;} }
            public TTReportField MotherName { get {return Body().MotherName;} }
            public TTReportField FatherName { get {return Body().FatherName;} }
            public TTReportField MaritalStatus { get {return Body().MaritalStatus;} }
            public TTReportField EducationStatus { get {return Body().EducationStatus;} }
            public TTReportField UniqueRefNo { get {return Body().UniqueRefNo;} }
            public TTReportField HomeAdress { get {return Body().HomeAdress;} }
            public TTReportField PhoneNum { get {return Body().PhoneNum;} }
            public TTReportField CompanionNum { get {return Body().CompanionNum;} }
            public TTReportField PatientLivesWith { get {return Body().PatientLivesWith;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField SoldierRank { get {return Body().SoldierRank;} }
            public TTReportField SoldierPlaceOfWork { get {return Body().SoldierPlaceOfWork;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField PreviousJobBeforeIll { get {return Body().PreviousJobBeforeIll;} }
            public TTReportField PatientPayerName { get {return Body().PatientPayerName;} }
            public TTReportField DateOfStart { get {return Body().DateOfStart;} }
            public TTReportField DateOfRetire { get {return Body().DateOfRetire;} }
            public TTReportField JobRightUseStatus { get {return Body().JobRightUseStatus;} }
            public TTReportField WorkPlace { get {return Body().WorkPlace;} }
            public TTReportField LongTermArmBonusInterrupt { get {return Body().LongTermArmBonusInterrupt;} }
            public TTReportField SecondRetirementStatus { get {return Body().SecondRetirementStatus;} }
            public TTReportField Evaluation { get {return Body().Evaluation;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField SickOrInjuredPlace { get {return Body().SickOrInjuredPlace;} }
            public TTReportField SickOrInjuryType { get {return Body().SickOrInjuryType;} }
            public TTReportField SickOrInjuryDate { get {return Body().SickOrInjuryDate;} }
            public TTReportField ShortEventStory { get {return Body().ShortEventStory;} }
            public TTReportField PatientDiagnosis { get {return Body().PatientDiagnosis;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField AuxiliaryToolWheelchair { get {return Body().AuxiliaryToolWheelchair;} }
            public TTReportField AuxiliaryToolWalker { get {return Body().AuxiliaryToolWalker;} }
            public TTReportField AuxiliaryToolAfo { get {return Body().AuxiliaryToolAfo;} }
            public TTReportField AuxiliaryToolHandSplint { get {return Body().AuxiliaryToolHandSplint;} }
            public TTReportField AuxiliaryToolTripod { get {return Body().AuxiliaryToolTripod;} }
            public TTReportField AuxiliaryToolArmRest { get {return Body().AuxiliaryToolArmRest;} }
            public TTReportField AuxiliaryToolOther { get {return Body().AuxiliaryToolOther;} }
            public TTReportField WrittenMedicalMaterialOrTool { get {return Body().WrittenMedicalMaterialOrTool;} }
            public TTReportField NewField1131 { get {return Body().NewField1131;} }
            public TTReportField RestState { get {return Body().RestState;} }
            public TTReportField NewField11311 { get {return Body().NewField11311;} }
            public TTReportField LivingHouseBelonging { get {return Body().LivingHouseBelonging;} }
            public TTReportField LivingHouseBelongingInfo { get {return Body().LivingHouseBelongingInfo;} }
            public TTReportField LivingHouseType { get {return Body().LivingHouseType;} }
            public TTReportField LivingHouseNumOfFloor { get {return Body().LivingHouseNumOfFloor;} }
            public TTReportField LivingHouseElevator { get {return Body().LivingHouseElevator;} }
            public TTReportField LivingHouseBasement { get {return Body().LivingHouseBasement;} }
            public TTReportField LivingHouseDoorEntrance { get {return Body().LivingHouseDoorEntrance;} }
            public TTReportField LivingHouseWcType { get {return Body().LivingHouseWcType;} }
            public TTReportField LivingHouseEntrance { get {return Body().LivingHouseEntrance;} }
            public TTReportField Patient { get {return Body().Patient;} }
            public TTReportField MaritalStatus1 { get {return Body().MaritalStatus1;} }
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
                public SocialServicesPatientFamilyInfoReport MyParentReport
                {
                    get { return (SocialServicesPatientFamilyInfoReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField PROCEDUREBYUSER;
                public TTReportField NewField11;
                public TTReportField EXAMINATIONDATE;
                public TTReportField NewField2;
                public TTReportField NameSurname;
                public TTReportField BirthDatePlace;
                public TTReportField MotherName;
                public TTReportField FatherName;
                public TTReportField MaritalStatus;
                public TTReportField EducationStatus;
                public TTReportField UniqueRefNo;
                public TTReportField HomeAdress;
                public TTReportField PhoneNum;
                public TTReportField CompanionNum;
                public TTReportField PatientLivesWith;
                public TTReportField NewField12;
                public TTReportField SoldierRank;
                public TTReportField SoldierPlaceOfWork;
                public TTReportField NewField121;
                public TTReportField PreviousJobBeforeIll;
                public TTReportField PatientPayerName;
                public TTReportField DateOfStart;
                public TTReportField DateOfRetire;
                public TTReportField JobRightUseStatus;
                public TTReportField WorkPlace;
                public TTReportField LongTermArmBonusInterrupt;
                public TTReportField SecondRetirementStatus;
                public TTReportField Evaluation;
                public TTReportField NewField13;
                public TTReportField SickOrInjuredPlace;
                public TTReportField SickOrInjuryType;
                public TTReportField SickOrInjuryDate;
                public TTReportField ShortEventStory;
                public TTReportField PatientDiagnosis;
                public TTReportField NewField131;
                public TTReportField AuxiliaryToolWheelchair;
                public TTReportField AuxiliaryToolWalker;
                public TTReportField AuxiliaryToolAfo;
                public TTReportField AuxiliaryToolHandSplint;
                public TTReportField AuxiliaryToolTripod;
                public TTReportField AuxiliaryToolArmRest;
                public TTReportField AuxiliaryToolOther;
                public TTReportField WrittenMedicalMaterialOrTool;
                public TTReportField NewField1131;
                public TTReportField RestState;
                public TTReportField NewField11311;
                public TTReportField LivingHouseBelonging;
                public TTReportField LivingHouseBelongingInfo;
                public TTReportField LivingHouseType;
                public TTReportField LivingHouseNumOfFloor;
                public TTReportField LivingHouseElevator;
                public TTReportField LivingHouseBasement;
                public TTReportField LivingHouseDoorEntrance;
                public TTReportField LivingHouseWcType;
                public TTReportField LivingHouseEntrance;
                public TTReportField Patient;
                public TTReportField MaritalStatus1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 217;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 4, 38, 9, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Formu Uygulayan :";

                    PROCEDUREBYUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 4, 90, 9, false);
                    PROCEDUREBYUSER.Name = "PROCEDUREBYUSER";
                    PROCEDUREBYUSER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREBYUSER.Value = @"{#Header.PROCEDUREBYUSERNAME#}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 38, 15, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Uygulama Tarihi    :";

                    EXAMINATIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 10, 90, 15, false);
                    EXAMINATIONDATE.Name = "EXAMINATIONDATE";
                    EXAMINATIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXAMINATIONDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    EXAMINATIONDATE.Value = @"{#Header.EXAMINATIONDATE#}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 17, 41, 22, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.Underline = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"KİMLİK BİLGİLERİ";

                    NameSurname = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 23, 110, 28, false);
                    NameSurname.Name = "NameSurname";
                    NameSurname.MultiLine = EvetHayirEnum.ehEvet;
                    NameSurname.NoClip = EvetHayirEnum.ehEvet;
                    NameSurname.WordBreak = EvetHayirEnum.ehEvet;
                    NameSurname.ExpandTabs = EvetHayirEnum.ehEvet;
                    NameSurname.Value = @"Adı Soyadı:";

                    BirthDatePlace = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 28, 110, 33, false);
                    BirthDatePlace.Name = "BirthDatePlace";
                    BirthDatePlace.MultiLine = EvetHayirEnum.ehEvet;
                    BirthDatePlace.NoClip = EvetHayirEnum.ehEvet;
                    BirthDatePlace.WordBreak = EvetHayirEnum.ehEvet;
                    BirthDatePlace.ExpandTabs = EvetHayirEnum.ehEvet;
                    BirthDatePlace.Value = @"Doğum Yeri ve Tarihi:";

                    MotherName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 33, 110, 38, false);
                    MotherName.Name = "MotherName";
                    MotherName.MultiLine = EvetHayirEnum.ehEvet;
                    MotherName.NoClip = EvetHayirEnum.ehEvet;
                    MotherName.WordBreak = EvetHayirEnum.ehEvet;
                    MotherName.ExpandTabs = EvetHayirEnum.ehEvet;
                    MotherName.Value = @"Anne Adı:";

                    FatherName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 38, 110, 43, false);
                    FatherName.Name = "FatherName";
                    FatherName.MultiLine = EvetHayirEnum.ehEvet;
                    FatherName.NoClip = EvetHayirEnum.ehEvet;
                    FatherName.WordBreak = EvetHayirEnum.ehEvet;
                    FatherName.ExpandTabs = EvetHayirEnum.ehEvet;
                    FatherName.Value = @"Baba Adı:";

                    MaritalStatus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 43, 110, 48, false);
                    MaritalStatus.Name = "MaritalStatus";
                    MaritalStatus.MultiLine = EvetHayirEnum.ehEvet;
                    MaritalStatus.NoClip = EvetHayirEnum.ehEvet;
                    MaritalStatus.WordBreak = EvetHayirEnum.ehEvet;
                    MaritalStatus.ExpandTabs = EvetHayirEnum.ehEvet;
                    MaritalStatus.Value = @"Medeni Hali:";

                    EducationStatus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 48, 110, 53, false);
                    EducationStatus.Name = "EducationStatus";
                    EducationStatus.MultiLine = EvetHayirEnum.ehEvet;
                    EducationStatus.NoClip = EvetHayirEnum.ehEvet;
                    EducationStatus.WordBreak = EvetHayirEnum.ehEvet;
                    EducationStatus.ExpandTabs = EvetHayirEnum.ehEvet;
                    EducationStatus.Value = @"Eğitim Durumu:";

                    UniqueRefNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 53, 110, 58, false);
                    UniqueRefNo.Name = "UniqueRefNo";
                    UniqueRefNo.MultiLine = EvetHayirEnum.ehEvet;
                    UniqueRefNo.NoClip = EvetHayirEnum.ehEvet;
                    UniqueRefNo.WordBreak = EvetHayirEnum.ehEvet;
                    UniqueRefNo.ExpandTabs = EvetHayirEnum.ehEvet;
                    UniqueRefNo.Value = @"TC Kimlik No:";

                    HomeAdress = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 58, 110, 71, false);
                    HomeAdress.Name = "HomeAdress";
                    HomeAdress.MultiLine = EvetHayirEnum.ehEvet;
                    HomeAdress.NoClip = EvetHayirEnum.ehEvet;
                    HomeAdress.WordBreak = EvetHayirEnum.ehEvet;
                    HomeAdress.ExpandTabs = EvetHayirEnum.ehEvet;
                    HomeAdress.Value = @"Ev Adresi:";

                    PhoneNum = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 71, 110, 76, false);
                    PhoneNum.Name = "PhoneNum";
                    PhoneNum.MultiLine = EvetHayirEnum.ehEvet;
                    PhoneNum.NoClip = EvetHayirEnum.ehEvet;
                    PhoneNum.WordBreak = EvetHayirEnum.ehEvet;
                    PhoneNum.ExpandTabs = EvetHayirEnum.ehEvet;
                    PhoneNum.Value = @"Tel:";

                    CompanionNum = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 76, 110, 81, false);
                    CompanionNum.Name = "CompanionNum";
                    CompanionNum.FieldType = ReportFieldTypeEnum.ftVariable;
                    CompanionNum.MultiLine = EvetHayirEnum.ehEvet;
                    CompanionNum.NoClip = EvetHayirEnum.ehEvet;
                    CompanionNum.WordBreak = EvetHayirEnum.ehEvet;
                    CompanionNum.ExpandTabs = EvetHayirEnum.ehEvet;
                    CompanionNum.Value = @"Refakatçi Tel: {#Header.COMPANIONPHONENUM#}";

                    PatientLivesWith = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 81, 110, 94, false);
                    PatientLivesWith.Name = "PatientLivesWith";
                    PatientLivesWith.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientLivesWith.MultiLine = EvetHayirEnum.ehEvet;
                    PatientLivesWith.NoClip = EvetHayirEnum.ehEvet;
                    PatientLivesWith.WordBreak = EvetHayirEnum.ehEvet;
                    PatientLivesWith.ExpandTabs = EvetHayirEnum.ehEvet;
                    PatientLivesWith.Value = @"Hasta Kiminle Yaşıyor: {#Header.PATIENTLIVESWITH#}";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 95, 89, 100, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.Underline = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"XXXXXXİ PERSONEL VE AİLESİ İÇİN";

                    SoldierRank = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 101, 110, 106, false);
                    SoldierRank.Name = "SoldierRank";
                    SoldierRank.FieldType = ReportFieldTypeEnum.ftVariable;
                    SoldierRank.MultiLine = EvetHayirEnum.ehEvet;
                    SoldierRank.NoClip = EvetHayirEnum.ehEvet;
                    SoldierRank.WordBreak = EvetHayirEnum.ehEvet;
                    SoldierRank.ExpandTabs = EvetHayirEnum.ehEvet;
                    SoldierRank.Value = @"Rütbesi: {#Header.SOLDIERRANK#}";

                    SoldierPlaceOfWork = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 106, 110, 120, false);
                    SoldierPlaceOfWork.Name = "SoldierPlaceOfWork";
                    SoldierPlaceOfWork.FieldType = ReportFieldTypeEnum.ftVariable;
                    SoldierPlaceOfWork.MultiLine = EvetHayirEnum.ehEvet;
                    SoldierPlaceOfWork.NoClip = EvetHayirEnum.ehEvet;
                    SoldierPlaceOfWork.WordBreak = EvetHayirEnum.ehEvet;
                    SoldierPlaceOfWork.ExpandTabs = EvetHayirEnum.ehEvet;
                    SoldierPlaceOfWork.Value = @"Görev Yeri:  {#Header.SOLDIERPLACEOFWORK#}";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 122, 89, 127, false);
                    NewField121.Name = "NewField121";
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.NoClip = EvetHayirEnum.ehEvet;
                    NewField121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.Underline = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"İŞ VE EMEKLİLİK BİLGİLERİ";

                    PreviousJobBeforeIll = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 128, 110, 139, false);
                    PreviousJobBeforeIll.Name = "PreviousJobBeforeIll";
                    PreviousJobBeforeIll.FieldType = ReportFieldTypeEnum.ftVariable;
                    PreviousJobBeforeIll.MultiLine = EvetHayirEnum.ehEvet;
                    PreviousJobBeforeIll.NoClip = EvetHayirEnum.ehEvet;
                    PreviousJobBeforeIll.WordBreak = EvetHayirEnum.ehEvet;
                    PreviousJobBeforeIll.ExpandTabs = EvetHayirEnum.ehEvet;
                    PreviousJobBeforeIll.Value = @"Hastalanmadan Önce Ne İş Yapıyordu: {#Header.PREVIOUSJOBBEFOREILL#}";

                    PatientPayerName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 139, 110, 148, false);
                    PatientPayerName.Name = "PatientPayerName";
                    PatientPayerName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientPayerName.MultiLine = EvetHayirEnum.ehEvet;
                    PatientPayerName.NoClip = EvetHayirEnum.ehEvet;
                    PatientPayerName.WordBreak = EvetHayirEnum.ehEvet;
                    PatientPayerName.ExpandTabs = EvetHayirEnum.ehEvet;
                    PatientPayerName.Value = @"Bağlı Bulunduğu Sosyal Güvenlik Kuruluşu: {#Header.PATIENTPAYERNAME#}";

                    DateOfStart = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 148, 110, 153, false);
                    DateOfStart.Name = "DateOfStart";
                    DateOfStart.FieldType = ReportFieldTypeEnum.ftVariable;
                    DateOfStart.MultiLine = EvetHayirEnum.ehEvet;
                    DateOfStart.NoClip = EvetHayirEnum.ehEvet;
                    DateOfStart.WordBreak = EvetHayirEnum.ehEvet;
                    DateOfStart.ExpandTabs = EvetHayirEnum.ehEvet;
                    DateOfStart.Value = @"İşe Başlama Tarihi:   {#Header.DATEOFSTART#}";

                    DateOfRetire = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 153, 110, 158, false);
                    DateOfRetire.Name = "DateOfRetire";
                    DateOfRetire.FieldType = ReportFieldTypeEnum.ftVariable;
                    DateOfRetire.MultiLine = EvetHayirEnum.ehEvet;
                    DateOfRetire.NoClip = EvetHayirEnum.ehEvet;
                    DateOfRetire.WordBreak = EvetHayirEnum.ehEvet;
                    DateOfRetire.ExpandTabs = EvetHayirEnum.ehEvet;
                    DateOfRetire.Value = @"Emeklilik Tarihi: {#Header.DATEOFRETIRE#}";

                    JobRightUseStatus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 158, 110, 170, false);
                    JobRightUseStatus.Name = "JobRightUseStatus";
                    JobRightUseStatus.FieldType = ReportFieldTypeEnum.ftVariable;
                    JobRightUseStatus.MultiLine = EvetHayirEnum.ehEvet;
                    JobRightUseStatus.NoClip = EvetHayirEnum.ehEvet;
                    JobRightUseStatus.WordBreak = EvetHayirEnum.ehEvet;
                    JobRightUseStatus.ExpandTabs = EvetHayirEnum.ehEvet;
                    JobRightUseStatus.Value = @"İş Hakkı Kullanma Durumu:  {#Header.JOBRIGHTUSESTATUS#}";

                    WorkPlace = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 170, 110, 182, false);
                    WorkPlace.Name = "WorkPlace";
                    WorkPlace.FieldType = ReportFieldTypeEnum.ftVariable;
                    WorkPlace.MultiLine = EvetHayirEnum.ehEvet;
                    WorkPlace.NoClip = EvetHayirEnum.ehEvet;
                    WorkPlace.WordBreak = EvetHayirEnum.ehEvet;
                    WorkPlace.ExpandTabs = EvetHayirEnum.ehEvet;
                    WorkPlace.Value = @"Nerede Çalıştığı: {#Header.WORKPLACE#}";

                    LongTermArmBonusInterrupt = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 182, 110, 192, false);
                    LongTermArmBonusInterrupt.Name = "LongTermArmBonusInterrupt";
                    LongTermArmBonusInterrupt.FieldType = ReportFieldTypeEnum.ftVariable;
                    LongTermArmBonusInterrupt.MultiLine = EvetHayirEnum.ehEvet;
                    LongTermArmBonusInterrupt.NoClip = EvetHayirEnum.ehEvet;
                    LongTermArmBonusInterrupt.WordBreak = EvetHayirEnum.ehEvet;
                    LongTermArmBonusInterrupt.ExpandTabs = EvetHayirEnum.ehEvet;
                    LongTermArmBonusInterrupt.Value = @"Uzun Vadeli Kollar Prim Kesinti Durumu: {#Header.LONGTERMARMBONUSINTERRUPT#}";

                    SecondRetirementStatus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 192, 110, 203, false);
                    SecondRetirementStatus.Name = "SecondRetirementStatus";
                    SecondRetirementStatus.FieldType = ReportFieldTypeEnum.ftVariable;
                    SecondRetirementStatus.MultiLine = EvetHayirEnum.ehEvet;
                    SecondRetirementStatus.NoClip = EvetHayirEnum.ehEvet;
                    SecondRetirementStatus.WordBreak = EvetHayirEnum.ehEvet;
                    SecondRetirementStatus.ExpandTabs = EvetHayirEnum.ehEvet;
                    SecondRetirementStatus.Value = @"2. Emeklilik Durumu: {#Header.SECONDRETIREMENTSTATUS#}";

                    Evaluation = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 203, 110, 214, false);
                    Evaluation.Name = "Evaluation";
                    Evaluation.FieldType = ReportFieldTypeEnum.ftVariable;
                    Evaluation.MultiLine = EvetHayirEnum.ehEvet;
                    Evaluation.NoClip = EvetHayirEnum.ehEvet;
                    Evaluation.WordBreak = EvetHayirEnum.ehEvet;
                    Evaluation.ExpandTabs = EvetHayirEnum.ehEvet;
                    Evaluation.Value = @"SHU Değerlendirme:  {#Header.EVALUATION#}";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 17, 181, 22, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.Underline = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"HASTANIN HASTALIK/YARALANMA DURUMU";

                    SickOrInjuredPlace = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 23, 205, 33, false);
                    SickOrInjuredPlace.Name = "SickOrInjuredPlace";
                    SickOrInjuredPlace.FieldType = ReportFieldTypeEnum.ftVariable;
                    SickOrInjuredPlace.MultiLine = EvetHayirEnum.ehEvet;
                    SickOrInjuredPlace.NoClip = EvetHayirEnum.ehEvet;
                    SickOrInjuredPlace.WordBreak = EvetHayirEnum.ehEvet;
                    SickOrInjuredPlace.ExpandTabs = EvetHayirEnum.ehEvet;
                    SickOrInjuredPlace.Value = @"Hastalandığı/Yaralandığı Yer:  {#Header.SICKORINJUREDPLACE#}";

                    SickOrInjuryType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 33, 205, 44, false);
                    SickOrInjuryType.Name = "SickOrInjuryType";
                    SickOrInjuryType.FieldType = ReportFieldTypeEnum.ftVariable;
                    SickOrInjuryType.MultiLine = EvetHayirEnum.ehEvet;
                    SickOrInjuryType.NoClip = EvetHayirEnum.ehEvet;
                    SickOrInjuryType.WordBreak = EvetHayirEnum.ehEvet;
                    SickOrInjuryType.ExpandTabs = EvetHayirEnum.ehEvet;
                    SickOrInjuryType.Value = @"Hastalanma/Yaralanma Şekli: {#Header.SICKORINJURYTYPE#}";

                    SickOrInjuryDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 44, 205, 49, false);
                    SickOrInjuryDate.Name = "SickOrInjuryDate";
                    SickOrInjuryDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    SickOrInjuryDate.MultiLine = EvetHayirEnum.ehEvet;
                    SickOrInjuryDate.NoClip = EvetHayirEnum.ehEvet;
                    SickOrInjuryDate.WordBreak = EvetHayirEnum.ehEvet;
                    SickOrInjuryDate.ExpandTabs = EvetHayirEnum.ehEvet;
                    SickOrInjuryDate.Value = @"Hastalanma/Yaralanma Tarihi:  {#Header.SICKORINJURYDATE#}";

                    ShortEventStory = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 49, 205, 60, false);
                    ShortEventStory.Name = "ShortEventStory";
                    ShortEventStory.FieldType = ReportFieldTypeEnum.ftVariable;
                    ShortEventStory.MultiLine = EvetHayirEnum.ehEvet;
                    ShortEventStory.NoClip = EvetHayirEnum.ehEvet;
                    ShortEventStory.WordBreak = EvetHayirEnum.ehEvet;
                    ShortEventStory.ExpandTabs = EvetHayirEnum.ehEvet;
                    ShortEventStory.Value = @"Kısaca Olay Hikayesi:  {#Header.SHORTEVENTSTORY#}";

                    PatientDiagnosis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 60, 205, 72, false);
                    PatientDiagnosis.Name = "PatientDiagnosis";
                    PatientDiagnosis.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientDiagnosis.MultiLine = EvetHayirEnum.ehEvet;
                    PatientDiagnosis.NoClip = EvetHayirEnum.ehEvet;
                    PatientDiagnosis.WordBreak = EvetHayirEnum.ehEvet;
                    PatientDiagnosis.ExpandTabs = EvetHayirEnum.ehEvet;
                    PatientDiagnosis.Value = @"Hastalığın Tanısı:  {#Header.PATIENTDIAGNOSIS#}";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 74, 181, 79, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.Underline = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"KULLANILAN YARDIMCI ARAÇLAR";

                    AuxiliaryToolWheelchair = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 81, 205, 86, false);
                    AuxiliaryToolWheelchair.Name = "AuxiliaryToolWheelchair";
                    AuxiliaryToolWheelchair.MultiLine = EvetHayirEnum.ehEvet;
                    AuxiliaryToolWheelchair.NoClip = EvetHayirEnum.ehEvet;
                    AuxiliaryToolWheelchair.WordBreak = EvetHayirEnum.ehEvet;
                    AuxiliaryToolWheelchair.ExpandTabs = EvetHayirEnum.ehEvet;
                    AuxiliaryToolWheelchair.Value = @"Tekerlekli Sandalye: ";

                    AuxiliaryToolWalker = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 86, 205, 91, false);
                    AuxiliaryToolWalker.Name = "AuxiliaryToolWalker";
                    AuxiliaryToolWalker.MultiLine = EvetHayirEnum.ehEvet;
                    AuxiliaryToolWalker.NoClip = EvetHayirEnum.ehEvet;
                    AuxiliaryToolWalker.WordBreak = EvetHayirEnum.ehEvet;
                    AuxiliaryToolWalker.ExpandTabs = EvetHayirEnum.ehEvet;
                    AuxiliaryToolWalker.Value = @"Walker:";

                    AuxiliaryToolAfo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 91, 205, 96, false);
                    AuxiliaryToolAfo.Name = "AuxiliaryToolAfo";
                    AuxiliaryToolAfo.MultiLine = EvetHayirEnum.ehEvet;
                    AuxiliaryToolAfo.NoClip = EvetHayirEnum.ehEvet;
                    AuxiliaryToolAfo.WordBreak = EvetHayirEnum.ehEvet;
                    AuxiliaryToolAfo.ExpandTabs = EvetHayirEnum.ehEvet;
                    AuxiliaryToolAfo.Value = @"Afo:";

                    AuxiliaryToolHandSplint = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 96, 205, 101, false);
                    AuxiliaryToolHandSplint.Name = "AuxiliaryToolHandSplint";
                    AuxiliaryToolHandSplint.MultiLine = EvetHayirEnum.ehEvet;
                    AuxiliaryToolHandSplint.NoClip = EvetHayirEnum.ehEvet;
                    AuxiliaryToolHandSplint.WordBreak = EvetHayirEnum.ehEvet;
                    AuxiliaryToolHandSplint.ExpandTabs = EvetHayirEnum.ehEvet;
                    AuxiliaryToolHandSplint.Value = @"El Splinti:";

                    AuxiliaryToolTripod = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 101, 205, 106, false);
                    AuxiliaryToolTripod.Name = "AuxiliaryToolTripod";
                    AuxiliaryToolTripod.MultiLine = EvetHayirEnum.ehEvet;
                    AuxiliaryToolTripod.NoClip = EvetHayirEnum.ehEvet;
                    AuxiliaryToolTripod.WordBreak = EvetHayirEnum.ehEvet;
                    AuxiliaryToolTripod.ExpandTabs = EvetHayirEnum.ehEvet;
                    AuxiliaryToolTripod.Value = @"Tripot:";

                    AuxiliaryToolArmRest = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 106, 205, 111, false);
                    AuxiliaryToolArmRest.Name = "AuxiliaryToolArmRest";
                    AuxiliaryToolArmRest.MultiLine = EvetHayirEnum.ehEvet;
                    AuxiliaryToolArmRest.NoClip = EvetHayirEnum.ehEvet;
                    AuxiliaryToolArmRest.WordBreak = EvetHayirEnum.ehEvet;
                    AuxiliaryToolArmRest.ExpandTabs = EvetHayirEnum.ehEvet;
                    AuxiliaryToolArmRest.Value = @"Kanedyen:";

                    AuxiliaryToolOther = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 111, 205, 123, false);
                    AuxiliaryToolOther.Name = "AuxiliaryToolOther";
                    AuxiliaryToolOther.MultiLine = EvetHayirEnum.ehEvet;
                    AuxiliaryToolOther.NoClip = EvetHayirEnum.ehEvet;
                    AuxiliaryToolOther.WordBreak = EvetHayirEnum.ehEvet;
                    AuxiliaryToolOther.ExpandTabs = EvetHayirEnum.ehEvet;
                    AuxiliaryToolOther.Value = @"Diğer:";

                    WrittenMedicalMaterialOrTool = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 123, 205, 136, false);
                    WrittenMedicalMaterialOrTool.Name = "WrittenMedicalMaterialOrTool";
                    WrittenMedicalMaterialOrTool.MultiLine = EvetHayirEnum.ehEvet;
                    WrittenMedicalMaterialOrTool.NoClip = EvetHayirEnum.ehEvet;
                    WrittenMedicalMaterialOrTool.WordBreak = EvetHayirEnum.ehEvet;
                    WrittenMedicalMaterialOrTool.ExpandTabs = EvetHayirEnum.ehEvet;
                    WrittenMedicalMaterialOrTool.Value = @"Yazılan Tıbbi Malzeme/Cihaz:";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 138, 181, 143, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.Underline = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"HAVA DEĞİŞİMİ/İSTİRAHAT DURUMU";

                    RestState = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 143, 205, 155, false);
                    RestState.Name = "RestState";
                    RestState.FieldType = ReportFieldTypeEnum.ftVariable;
                    RestState.MultiLine = EvetHayirEnum.ehEvet;
                    RestState.NoClip = EvetHayirEnum.ehEvet;
                    RestState.WordBreak = EvetHayirEnum.ehEvet;
                    RestState.ExpandTabs = EvetHayirEnum.ehEvet;
                    RestState.Value = @"{#Header.RESTSTATE#}";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 158, 181, 163, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.TextFont.Bold = true;
                    NewField11311.TextFont.Underline = true;
                    NewField11311.TextFont.CharSet = 162;
                    NewField11311.Value = @"YAŞANILAN EVİN NİTELİĞİ";

                    LivingHouseBelonging = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 164, 205, 169, false);
                    LivingHouseBelonging.Name = "LivingHouseBelonging";
                    LivingHouseBelonging.MultiLine = EvetHayirEnum.ehEvet;
                    LivingHouseBelonging.NoClip = EvetHayirEnum.ehEvet;
                    LivingHouseBelonging.WordBreak = EvetHayirEnum.ehEvet;
                    LivingHouseBelonging.ExpandTabs = EvetHayirEnum.ehEvet;
                    LivingHouseBelonging.Value = @"Ev Kime Ait:";

                    LivingHouseBelongingInfo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 169, 205, 174, false);
                    LivingHouseBelongingInfo.Name = "LivingHouseBelongingInfo";
                    LivingHouseBelongingInfo.MultiLine = EvetHayirEnum.ehEvet;
                    LivingHouseBelongingInfo.NoClip = EvetHayirEnum.ehEvet;
                    LivingHouseBelongingInfo.WordBreak = EvetHayirEnum.ehEvet;
                    LivingHouseBelongingInfo.ExpandTabs = EvetHayirEnum.ehEvet;
                    LivingHouseBelongingInfo.Value = @"";

                    LivingHouseType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 174, 205, 187, false);
                    LivingHouseType.Name = "LivingHouseType";
                    LivingHouseType.FieldType = ReportFieldTypeEnum.ftVariable;
                    LivingHouseType.MultiLine = EvetHayirEnum.ehEvet;
                    LivingHouseType.NoClip = EvetHayirEnum.ehEvet;
                    LivingHouseType.WordBreak = EvetHayirEnum.ehEvet;
                    LivingHouseType.ExpandTabs = EvetHayirEnum.ehEvet;
                    LivingHouseType.Value = @"Ev Tipi:  {#Header.LivingHouseType#}";

                    LivingHouseNumOfFloor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 187, 160, 192, false);
                    LivingHouseNumOfFloor.Name = "LivingHouseNumOfFloor";
                    LivingHouseNumOfFloor.FieldType = ReportFieldTypeEnum.ftVariable;
                    LivingHouseNumOfFloor.MultiLine = EvetHayirEnum.ehEvet;
                    LivingHouseNumOfFloor.NoClip = EvetHayirEnum.ehEvet;
                    LivingHouseNumOfFloor.WordBreak = EvetHayirEnum.ehEvet;
                    LivingHouseNumOfFloor.ExpandTabs = EvetHayirEnum.ehEvet;
                    LivingHouseNumOfFloor.Value = @"Kaçıncı Kat:  {#Header.LIVINGHOUSENUMOFFLOOR#}";

                    LivingHouseElevator = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 192, 205, 197, false);
                    LivingHouseElevator.Name = "LivingHouseElevator";
                    LivingHouseElevator.MultiLine = EvetHayirEnum.ehEvet;
                    LivingHouseElevator.NoClip = EvetHayirEnum.ehEvet;
                    LivingHouseElevator.WordBreak = EvetHayirEnum.ehEvet;
                    LivingHouseElevator.ExpandTabs = EvetHayirEnum.ehEvet;
                    LivingHouseElevator.Value = @"Asansör:  ";

                    LivingHouseBasement = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 192, 160, 197, false);
                    LivingHouseBasement.Name = "LivingHouseBasement";
                    LivingHouseBasement.FieldType = ReportFieldTypeEnum.ftVariable;
                    LivingHouseBasement.MultiLine = EvetHayirEnum.ehEvet;
                    LivingHouseBasement.NoClip = EvetHayirEnum.ehEvet;
                    LivingHouseBasement.WordBreak = EvetHayirEnum.ehEvet;
                    LivingHouseBasement.ExpandTabs = EvetHayirEnum.ehEvet;
                    LivingHouseBasement.Value = @"Basamak: {#Header.LIVINGHOUSEBASEMENT#}";

                    LivingHouseDoorEntrance = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 197, 160, 202, false);
                    LivingHouseDoorEntrance.Name = "LivingHouseDoorEntrance";
                    LivingHouseDoorEntrance.MultiLine = EvetHayirEnum.ehEvet;
                    LivingHouseDoorEntrance.NoClip = EvetHayirEnum.ehEvet;
                    LivingHouseDoorEntrance.WordBreak = EvetHayirEnum.ehEvet;
                    LivingHouseDoorEntrance.ExpandTabs = EvetHayirEnum.ehEvet;
                    LivingHouseDoorEntrance.Value = @"Kapı Girişleri:";

                    LivingHouseWcType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 197, 205, 202, false);
                    LivingHouseWcType.Name = "LivingHouseWcType";
                    LivingHouseWcType.MultiLine = EvetHayirEnum.ehEvet;
                    LivingHouseWcType.NoClip = EvetHayirEnum.ehEvet;
                    LivingHouseWcType.WordBreak = EvetHayirEnum.ehEvet;
                    LivingHouseWcType.ExpandTabs = EvetHayirEnum.ehEvet;
                    LivingHouseWcType.Value = @"WC:";

                    LivingHouseEntrance = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 187, 205, 192, false);
                    LivingHouseEntrance.Name = "LivingHouseEntrance";
                    LivingHouseEntrance.MultiLine = EvetHayirEnum.ehEvet;
                    LivingHouseEntrance.NoClip = EvetHayirEnum.ehEvet;
                    LivingHouseEntrance.WordBreak = EvetHayirEnum.ehEvet;
                    LivingHouseEntrance.ExpandTabs = EvetHayirEnum.ehEvet;
                    LivingHouseEntrance.Value = @"Giriş: ";

                    Patient = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 15, 239, 20, false);
                    Patient.Name = "Patient";
                    Patient.Visible = EvetHayirEnum.ehHayir;
                    Patient.FieldType = ReportFieldTypeEnum.ftVariable;
                    Patient.Value = @"{#Header.PATIENT#}";

                    MaritalStatus1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 24, 238, 29, false);
                    MaritalStatus1.Name = "MaritalStatus1";
                    MaritalStatus1.Visible = EvetHayirEnum.ehHayir;
                    MaritalStatus1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MaritalStatus1.Value = @"{#Header.MARITALSTATUS#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SocServPatientFamilyInfo.GetSocServPatientFamilyInfo_Class dataset_GetSocServPatientFamilyInfo = MyParentReport.Header.rsGroup.GetCurrentRecord<SocServPatientFamilyInfo.GetSocServPatientFamilyInfo_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    PROCEDUREBYUSER.CalcValue = (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.Procedurebyusername) : "");
                    NewField11.CalcValue = NewField11.Value;
                    EXAMINATIONDATE.CalcValue = (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.ExaminationDate) : "");
                    NewField2.CalcValue = NewField2.Value;
                    NameSurname.CalcValue = NameSurname.Value;
                    BirthDatePlace.CalcValue = BirthDatePlace.Value;
                    MotherName.CalcValue = MotherName.Value;
                    FatherName.CalcValue = FatherName.Value;
                    MaritalStatus.CalcValue = MaritalStatus.Value;
                    EducationStatus.CalcValue = EducationStatus.Value;
                    UniqueRefNo.CalcValue = UniqueRefNo.Value;
                    HomeAdress.CalcValue = HomeAdress.Value;
                    PhoneNum.CalcValue = PhoneNum.Value;
                    CompanionNum.CalcValue = @"Refakatçi Tel: " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.CompanionPhoneNum) : "");
                    PatientLivesWith.CalcValue = @"Hasta Kiminle Yaşıyor: " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.PatientLivesWith) : "");
                    NewField12.CalcValue = NewField12.Value;
                    SoldierRank.CalcValue = @"Rütbesi: " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.SoldierRank) : "");
                    SoldierPlaceOfWork.CalcValue = @"Görev Yeri:  " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.SoldierPlaceOfWork) : "");
                    NewField121.CalcValue = NewField121.Value;
                    PreviousJobBeforeIll.CalcValue = @"Hastalanmadan Önce Ne İş Yapıyordu: " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.PreviousJobBeforeIll) : "");
                    PatientPayerName.CalcValue = @"Bağlı Bulunduğu Sosyal Güvenlik Kuruluşu: " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.PatientPayerName) : "");
                    DateOfStart.CalcValue = @"İşe Başlama Tarihi:   " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.DateOfStart) : "");
                    DateOfRetire.CalcValue = @"Emeklilik Tarihi: " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.DateOfRetire) : "");
                    JobRightUseStatus.CalcValue = @"İş Hakkı Kullanma Durumu:  " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.JobRightUseStatus) : "");
                    WorkPlace.CalcValue = @"Nerede Çalıştığı: " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.WorkPlace) : "");
                    LongTermArmBonusInterrupt.CalcValue = @"Uzun Vadeli Kollar Prim Kesinti Durumu: " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.LongTermArmBonusInterrupt) : "");
                    SecondRetirementStatus.CalcValue = @"2. Emeklilik Durumu: " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.SecondRetirementStatus) : "");
                    Evaluation.CalcValue = @"SHU Değerlendirme:  " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.Evaluation) : "");
                    NewField13.CalcValue = NewField13.Value;
                    SickOrInjuredPlace.CalcValue = @"Hastalandığı/Yaralandığı Yer:  " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.SickOrInjuredPlace) : "");
                    SickOrInjuryType.CalcValue = @"Hastalanma/Yaralanma Şekli: " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.SickOrInjuryType) : "");
                    SickOrInjuryDate.CalcValue = @"Hastalanma/Yaralanma Tarihi:  " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.SickOrInjuryDate) : "");
                    ShortEventStory.CalcValue = @"Kısaca Olay Hikayesi:  " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.ShortEventStory) : "");
                    PatientDiagnosis.CalcValue = @"Hastalığın Tanısı:  " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.PatientDiagnosis) : "");
                    NewField131.CalcValue = NewField131.Value;
                    AuxiliaryToolWheelchair.CalcValue = AuxiliaryToolWheelchair.Value;
                    AuxiliaryToolWalker.CalcValue = AuxiliaryToolWalker.Value;
                    AuxiliaryToolAfo.CalcValue = AuxiliaryToolAfo.Value;
                    AuxiliaryToolHandSplint.CalcValue = AuxiliaryToolHandSplint.Value;
                    AuxiliaryToolTripod.CalcValue = AuxiliaryToolTripod.Value;
                    AuxiliaryToolArmRest.CalcValue = AuxiliaryToolArmRest.Value;
                    AuxiliaryToolOther.CalcValue = AuxiliaryToolOther.Value;
                    WrittenMedicalMaterialOrTool.CalcValue = WrittenMedicalMaterialOrTool.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    RestState.CalcValue = (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.RestState) : "");
                    NewField11311.CalcValue = NewField11311.Value;
                    LivingHouseBelonging.CalcValue = LivingHouseBelonging.Value;
                    LivingHouseBelongingInfo.CalcValue = LivingHouseBelongingInfo.Value;
                    LivingHouseType.CalcValue = @"Ev Tipi:  " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.LivingHouseType) : "");
                    LivingHouseNumOfFloor.CalcValue = @"Kaçıncı Kat:  " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.LivingHouseNumOfFloor) : "");
                    LivingHouseElevator.CalcValue = LivingHouseElevator.Value;
                    LivingHouseBasement.CalcValue = @"Basamak: " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.LivingHouseBasement) : "");
                    LivingHouseDoorEntrance.CalcValue = LivingHouseDoorEntrance.Value;
                    LivingHouseWcType.CalcValue = LivingHouseWcType.Value;
                    LivingHouseEntrance.CalcValue = LivingHouseEntrance.Value;
                    Patient.CalcValue = (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.Patient) : "");
                    MaritalStatus1.CalcValue = (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.MaritalStatus) : "");
                    return new TTReportObject[] { NewField1,PROCEDUREBYUSER,NewField11,EXAMINATIONDATE,NewField2,NameSurname,BirthDatePlace,MotherName,FatherName,MaritalStatus,EducationStatus,UniqueRefNo,HomeAdress,PhoneNum,CompanionNum,PatientLivesWith,NewField12,SoldierRank,SoldierPlaceOfWork,NewField121,PreviousJobBeforeIll,PatientPayerName,DateOfStart,DateOfRetire,JobRightUseStatus,WorkPlace,LongTermArmBonusInterrupt,SecondRetirementStatus,Evaluation,NewField13,SickOrInjuredPlace,SickOrInjuryType,SickOrInjuryDate,ShortEventStory,PatientDiagnosis,NewField131,AuxiliaryToolWheelchair,AuxiliaryToolWalker,AuxiliaryToolAfo,AuxiliaryToolHandSplint,AuxiliaryToolTripod,AuxiliaryToolArmRest,AuxiliaryToolOther,WrittenMedicalMaterialOrTool,NewField1131,RestState,NewField11311,LivingHouseBelonging,LivingHouseBelongingInfo,LivingHouseType,LivingHouseNumOfFloor,LivingHouseElevator,LivingHouseBasement,LivingHouseDoorEntrance,LivingHouseWcType,LivingHouseEntrance,Patient,MaritalStatus1};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext objectContext = new TTObjectContext(true); 
            Patient patient = (Patient)objectContext.GetObject(new Guid(this.Patient.CalcValue.ToString()),"Patient");
               SocServPatientFamilyInfo.GetSocServPatientFamilyInfo_Class dataset_GetSocServPatientFamilyInfo = MyParentReport.Header.rsGroup.GetCurrentRecord<SocServPatientFamilyInfo.GetSocServPatientFamilyInfo_Class>(0);

                   
                    this.NameSurname.CalcValue += patient.Name + " " + patient.Surname;
                    this.BirthDatePlace.CalcValue += patient.BirthPlace + " - " + ((DateTime)patient.BirthDate).ToString("dd.MM.yyyy");
                    this.MotherName.CalcValue += patient.MotherName;
                    this.FatherName.CalcValue += patient.FatherName;
                    this.EducationStatus.CalcValue += dataset_GetSocServPatientFamilyInfo.Educationstatus !=null ? dataset_GetSocServPatientFamilyInfo.Educationstatus : "";
                    this.UniqueRefNo.CalcValue += patient.UniqueRefNo;
                    this.HomeAdress.CalcValue += dataset_GetSocServPatientFamilyInfo.PatientAddress != null ? dataset_GetSocServPatientFamilyInfo.PatientAddress : "" ;
                    this.PhoneNum.CalcValue += dataset_GetSocServPatientFamilyInfo.PatientPhoneNum != null ? dataset_GetSocServPatientFamilyInfo.PatientPhoneNum : "" ;
                    this.AuxiliaryToolAfo.CalcValue += dataset_GetSocServPatientFamilyInfo.AuxiliaryToolAfo == true ? "  Var" : "";
                    this.AuxiliaryToolWalker.CalcValue += dataset_GetSocServPatientFamilyInfo.AuxiliaryToolWalker == true ? "  Var" : "";
                    this.AuxiliaryToolWheelchair.CalcValue += dataset_GetSocServPatientFamilyInfo.AuxiliaryToolWheelchair == true ? "  Var" : "";
                    this.AuxiliaryToolHandSplint.CalcValue += dataset_GetSocServPatientFamilyInfo.AuxiliaryToolHandSplint == true ? "  Var" : "";
                    this.AuxiliaryToolTripod.CalcValue += dataset_GetSocServPatientFamilyInfo.AuxiliaryToolTripod == true ? "  Var" : "";
                    this.AuxiliaryToolArmRest.CalcValue += dataset_GetSocServPatientFamilyInfo.AuxiliaryToolArmRest == true ? "  Var" : "";
                    this.AuxiliaryToolOther.CalcValue += dataset_GetSocServPatientFamilyInfo.AuxiliaryToolOther == true ? "  Var " + dataset_GetSocServPatientFamilyInfo.AuxiliaryToolOtherInfo : "";
                    if(dataset_GetSocServPatientFamilyInfo.MaritalStatus != null)
                    {
                        if(dataset_GetSocServPatientFamilyInfo.MaritalStatus == MaritalStatusEnum.Single)
                        {
                            this.MaritalStatus.CalcValue += "  Bekar";
                        } else if (dataset_GetSocServPatientFamilyInfo.MaritalStatus == MaritalStatusEnum.Married)
                        {
                            this.MaritalStatus.CalcValue += "  Evli";
                        } else if (dataset_GetSocServPatientFamilyInfo.MaritalStatus == MaritalStatusEnum.Divorced)
                        {
                            this.MaritalStatus.CalcValue += "  Boşanmış";
                        } else 
                        {
                            this.MaritalStatus.CalcValue += "  Dul";
                        }
                    }
                    if (dataset_GetSocServPatientFamilyInfo.LivingHouseBelonging != null)
                    {
                        if (dataset_GetSocServPatientFamilyInfo.LivingHouseBelonging == LivingHouseTypeEnum.Lodging)
                        {
                            this.LivingHouseBelonging.CalcValue += "  Lojman";
                        }
                        else if (dataset_GetSocServPatientFamilyInfo.LivingHouseBelonging == LivingHouseTypeEnum.Other)
                        {
                            this.LivingHouseBelonging.CalcValue += "  Diğer";
                        }
                        else if (dataset_GetSocServPatientFamilyInfo.LivingHouseBelonging == LivingHouseTypeEnum.Rent)
                        {
                            this.LivingHouseBelonging.CalcValue += "  Kira";
                        }
                        else
                        {
                            this.LivingHouseBelonging.CalcValue += "  Kendilerine Ait";
                        }
                    }
                    if(dataset_GetSocServPatientFamilyInfo.LivingHouseEntrance != null)
                    {
                        if (dataset_GetSocServPatientFamilyInfo.LivingHouseEntrance == YesNoEnum.No)
                            this.LivingHouseEntrance.CalcValue += "  Hayır";
                        else
                            this.LivingHouseEntrance.CalcValue += "  Evet";
                    }
                    if (dataset_GetSocServPatientFamilyInfo.LivingHouseDoorEntrance != null)
                    {
                        if (dataset_GetSocServPatientFamilyInfo.LivingHouseDoorEntrance == DoorEntranceTypesEnum.Appropriate)
                            this.LivingHouseDoorEntrance.CalcValue += "  Uygun";
                        else
                            this.LivingHouseDoorEntrance.CalcValue += "  Uygun Değil";
                    }
                    if (dataset_GetSocServPatientFamilyInfo.LivingHouseWcType != null)
                    {
                        if (dataset_GetSocServPatientFamilyInfo.LivingHouseWcType == WCTypeEnum.Closet)
                            this.LivingHouseWcType.CalcValue += "  Klozetli";
                        else
                            this.LivingHouseWcType.CalcValue += "  Klozetli Değil";
                    }
                    if (dataset_GetSocServPatientFamilyInfo.LivingHouseElevator != null)
                    {
                        if (dataset_GetSocServPatientFamilyInfo.LivingHouseElevator == VarYokEnum.V)
                            this.LivingHouseElevator.CalcValue += "  Var";
                        else if(dataset_GetSocServPatientFamilyInfo.LivingHouseElevator == VarYokEnum.Y)
                            this.LivingHouseElevator.CalcValue += "  Yok";
                    }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class main2Group : TTReportGroup
        {
            public SocialServicesPatientFamilyInfoReport MyParentReport
            {
                get { return (SocialServicesPatientFamilyInfoReport)ParentReport; }
            }

            new public main2GroupBody Body()
            {
                return (main2GroupBody)_body;
            }
            public TTReportField NewField11211 { get {return Body().NewField11211;} }
            public TTReportField JobMilitaryServStartDate { get {return Body().JobMilitaryServStartDate;} }
            public TTReportField MilitaryServiceEndDate { get {return Body().MilitaryServiceEndDate;} }
            public TTReportField RecruitmentOffice { get {return Body().RecruitmentOffice;} }
            public TTReportField ExactTransactionDate { get {return Body().ExactTransactionDate;} }
            public TTReportField Companion { get {return Body().Companion;} }
            public TTReportField RoomNumber { get {return Body().RoomNumber;} }
            public TTReportField NewField1113111 { get {return Body().NewField1113111;} }
            public TTReportField FamilyIncomings { get {return Body().FamilyIncomings;} }
            public TTReportField SocioEconomicInfoEvaluation { get {return Body().SocioEconomicInfoEvaluation;} }
            public main2Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public main2Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new main2GroupBody(this);
            }

            public partial class main2GroupBody : TTReportSection
            {
                public SocialServicesPatientFamilyInfoReport MyParentReport
                {
                    get { return (SocialServicesPatientFamilyInfoReport)ParentReport; }
                }
                
                public TTReportField NewField11211;
                public TTReportField JobMilitaryServStartDate;
                public TTReportField MilitaryServiceEndDate;
                public TTReportField RecruitmentOffice;
                public TTReportField ExactTransactionDate;
                public TTReportField Companion;
                public TTReportField RoomNumber;
                public TTReportField NewField1113111;
                public TTReportField FamilyIncomings;
                public TTReportField SocioEconomicInfoEvaluation; 
                public main2GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 59;
                    RepeatCount = 0;
                    
                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 4, 89, 9, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.Underline = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"YARALI/HASTA BİLGİLERİ";

                    JobMilitaryServStartDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 11, 110, 16, false);
                    JobMilitaryServStartDate.Name = "JobMilitaryServStartDate";
                    JobMilitaryServStartDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    JobMilitaryServStartDate.MultiLine = EvetHayirEnum.ehEvet;
                    JobMilitaryServStartDate.NoClip = EvetHayirEnum.ehEvet;
                    JobMilitaryServStartDate.WordBreak = EvetHayirEnum.ehEvet;
                    JobMilitaryServStartDate.ExpandTabs = EvetHayirEnum.ehEvet;
                    JobMilitaryServStartDate.Value = @"İş/XXXXXXlik Başlangıç Tarihi:  {#Header.JOBMILITARYSERVSTARTDATE#}";

                    MilitaryServiceEndDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 16, 110, 21, false);
                    MilitaryServiceEndDate.Name = "MilitaryServiceEndDate";
                    MilitaryServiceEndDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    MilitaryServiceEndDate.MultiLine = EvetHayirEnum.ehEvet;
                    MilitaryServiceEndDate.NoClip = EvetHayirEnum.ehEvet;
                    MilitaryServiceEndDate.WordBreak = EvetHayirEnum.ehEvet;
                    MilitaryServiceEndDate.ExpandTabs = EvetHayirEnum.ehEvet;
                    MilitaryServiceEndDate.Value = @"XXXXXXlik Bitiş Tarihi: {#Header.MILITARYSERVICEENDDATE#}";

                    RecruitmentOffice = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 21, 110, 34, false);
                    RecruitmentOffice.Name = "RecruitmentOffice";
                    RecruitmentOffice.FieldType = ReportFieldTypeEnum.ftVariable;
                    RecruitmentOffice.MultiLine = EvetHayirEnum.ehEvet;
                    RecruitmentOffice.NoClip = EvetHayirEnum.ehEvet;
                    RecruitmentOffice.WordBreak = EvetHayirEnum.ehEvet;
                    RecruitmentOffice.ExpandTabs = EvetHayirEnum.ehEvet;
                    RecruitmentOffice.Value = @"XXXXXXlik Şubesi:  {#Header.RECRUITMENTOFFICE#}";

                    ExactTransactionDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 34, 110, 39, false);
                    ExactTransactionDate.Name = "ExactTransactionDate";
                    ExactTransactionDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    ExactTransactionDate.MultiLine = EvetHayirEnum.ehEvet;
                    ExactTransactionDate.NoClip = EvetHayirEnum.ehEvet;
                    ExactTransactionDate.WordBreak = EvetHayirEnum.ehEvet;
                    ExactTransactionDate.ExpandTabs = EvetHayirEnum.ehEvet;
                    ExactTransactionDate.Value = @"Kesin İşlem Tarihi:  {#Header.EXACTTRANSACTIONDATE#}";

                    Companion = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 39, 110, 44, false);
                    Companion.Name = "Companion";
                    Companion.FieldType = ReportFieldTypeEnum.ftVariable;
                    Companion.MultiLine = EvetHayirEnum.ehEvet;
                    Companion.NoClip = EvetHayirEnum.ehEvet;
                    Companion.WordBreak = EvetHayirEnum.ehEvet;
                    Companion.ExpandTabs = EvetHayirEnum.ehEvet;
                    Companion.Value = @"Refakatçisi:  {#Header.COMPANION#}";

                    RoomNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 44, 110, 49, false);
                    RoomNumber.Name = "RoomNumber";
                    RoomNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    RoomNumber.MultiLine = EvetHayirEnum.ehEvet;
                    RoomNumber.NoClip = EvetHayirEnum.ehEvet;
                    RoomNumber.WordBreak = EvetHayirEnum.ehEvet;
                    RoomNumber.ExpandTabs = EvetHayirEnum.ehEvet;
                    RoomNumber.Value = @"Oda Numarası:  {#Header.ROOMNAME#}";

                    NewField1113111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 4, 181, 9, false);
                    NewField1113111.Name = "NewField1113111";
                    NewField1113111.TextFont.Bold = true;
                    NewField1113111.TextFont.Underline = true;
                    NewField1113111.TextFont.CharSet = 162;
                    NewField1113111.Value = @"SOSYO-EKONOMİK BİLGİLER";

                    FamilyIncomings = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 10, 205, 23, false);
                    FamilyIncomings.Name = "FamilyIncomings";
                    FamilyIncomings.FieldType = ReportFieldTypeEnum.ftVariable;
                    FamilyIncomings.MultiLine = EvetHayirEnum.ehEvet;
                    FamilyIncomings.NoClip = EvetHayirEnum.ehEvet;
                    FamilyIncomings.WordBreak = EvetHayirEnum.ehEvet;
                    FamilyIncomings.ExpandTabs = EvetHayirEnum.ehEvet;
                    FamilyIncomings.Value = @"Ailenin gelir kaynakları nelerdir : {#Header.FAMILYINCOMINGS#}";

                    SocioEconomicInfoEvaluation = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 23, 205, 38, false);
                    SocioEconomicInfoEvaluation.Name = "SocioEconomicInfoEvaluation";
                    SocioEconomicInfoEvaluation.FieldType = ReportFieldTypeEnum.ftVariable;
                    SocioEconomicInfoEvaluation.MultiLine = EvetHayirEnum.ehEvet;
                    SocioEconomicInfoEvaluation.NoClip = EvetHayirEnum.ehEvet;
                    SocioEconomicInfoEvaluation.WordBreak = EvetHayirEnum.ehEvet;
                    SocioEconomicInfoEvaluation.ExpandTabs = EvetHayirEnum.ehEvet;
                    SocioEconomicInfoEvaluation.Value = @"SHU Değerlendirme:  {#Header.SOCIOECONOMICINFOEVALUATION#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SocServPatientFamilyInfo.GetSocServPatientFamilyInfo_Class dataset_GetSocServPatientFamilyInfo = MyParentReport.Header.rsGroup.GetCurrentRecord<SocServPatientFamilyInfo.GetSocServPatientFamilyInfo_Class>(0);
                    NewField11211.CalcValue = NewField11211.Value;
                    JobMilitaryServStartDate.CalcValue = @"İş/XXXXXXlik Başlangıç Tarihi:  " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.JobMilitaryServStartDate) : "");
                    MilitaryServiceEndDate.CalcValue = @"XXXXXXlik Bitiş Tarihi: " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.MilitaryServiceEndDate) : "");
                    RecruitmentOffice.CalcValue = @"XXXXXXlik Şubesi:  " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.RecruitmentOffice) : "");
                    ExactTransactionDate.CalcValue = @"Kesin İşlem Tarihi:  " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.ExactTransactionDate) : "");
                    Companion.CalcValue = @"Refakatçisi:  " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.Companion) : "");
                    RoomNumber.CalcValue = @"Oda Numarası:  " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.Roomname) : "");
                    NewField1113111.CalcValue = NewField1113111.Value;
                    FamilyIncomings.CalcValue = @"Ailenin gelir kaynakları nelerdir : " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.FamilyIncomings) : "");
                    SocioEconomicInfoEvaluation.CalcValue = @"SHU Değerlendirme:  " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.SocioEconomicInfoEvaluation) : "");
                    return new TTReportObject[] { NewField11211,JobMilitaryServStartDate,MilitaryServiceEndDate,RecruitmentOffice,ExactTransactionDate,Companion,RoomNumber,NewField1113111,FamilyIncomings,SocioEconomicInfoEvaluation};
                }
            }

        }

        public main2Group main2;

        public partial class mainGroup : TTReportGroup
        {
            public SocialServicesPatientFamilyInfoReport MyParentReport
            {
                get { return (SocialServicesPatientFamilyInfoReport)ParentReport; }
            }

            new public mainGroupBody Body()
            {
                return (mainGroupBody)_body;
            }
            public TTReportField NewField111211 { get {return Body().NewField111211;} }
            public TTReportField TransportationArrival { get {return Body().TransportationArrival;} }
            public TTReportField TransportationGoing { get {return Body().TransportationGoing;} }
            public TTReportField TransportationEvaluation { get {return Body().TransportationEvaluation;} }
            public TTReportField NewField1112111 { get {return Body().NewField1112111;} }
            public TTReportField FamilyInformation { get {return Body().FamilyInformation;} }
            public TTReportField FamilyInformationEvaluation { get {return Body().FamilyInformationEvaluation;} }
            public TTReportField NewField11112111 { get {return Body().NewField11112111;} }
            public TTReportField PhysicalStatus { get {return Body().PhysicalStatus;} }
            public TTReportField NewField111121111 { get {return Body().NewField111121111;} }
            public TTReportField PatientRelatedWorks { get {return Body().PatientRelatedWorks;} }
            public TTReportField SubHeaders1 { get {return Body().SubHeaders1;} }
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
                _header = null;
                _footer = null;
                _body = new mainGroupBody(this);
            }

            public partial class mainGroupBody : TTReportSection
            {
                public SocialServicesPatientFamilyInfoReport MyParentReport
                {
                    get { return (SocialServicesPatientFamilyInfoReport)ParentReport; }
                }
                
                public TTReportField NewField111211;
                public TTReportField TransportationArrival;
                public TTReportField TransportationGoing;
                public TTReportField TransportationEvaluation;
                public TTReportField NewField1112111;
                public TTReportField FamilyInformation;
                public TTReportField FamilyInformationEvaluation;
                public TTReportField NewField11112111;
                public TTReportField PhysicalStatus;
                public TTReportField NewField111121111;
                public TTReportField PatientRelatedWorks;
                public TTReportField SubHeaders1; 
                public mainGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 145;
                    RepeatCount = 0;
                    
                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 6, 89, 11, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.Underline = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"ULAŞIM DEĞERLENDİRME";

                    TransportationArrival = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 12, 205, 25, false);
                    TransportationArrival.Name = "TransportationArrival";
                    TransportationArrival.FieldType = ReportFieldTypeEnum.ftVariable;
                    TransportationArrival.MultiLine = EvetHayirEnum.ehEvet;
                    TransportationArrival.NoClip = EvetHayirEnum.ehEvet;
                    TransportationArrival.WordBreak = EvetHayirEnum.ehEvet;
                    TransportationArrival.ExpandTabs = EvetHayirEnum.ehEvet;
                    TransportationArrival.Value = @"Geliş:  {#Header.TRANSPORTATIONARRIVAL#}";

                    TransportationGoing = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 25, 205, 38, false);
                    TransportationGoing.Name = "TransportationGoing";
                    TransportationGoing.FieldType = ReportFieldTypeEnum.ftVariable;
                    TransportationGoing.MultiLine = EvetHayirEnum.ehEvet;
                    TransportationGoing.NoClip = EvetHayirEnum.ehEvet;
                    TransportationGoing.WordBreak = EvetHayirEnum.ehEvet;
                    TransportationGoing.ExpandTabs = EvetHayirEnum.ehEvet;
                    TransportationGoing.Value = @"Gidiş:  {#Header.TRANSPORTATIONGOING#}";

                    TransportationEvaluation = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 38, 205, 52, false);
                    TransportationEvaluation.Name = "TransportationEvaluation";
                    TransportationEvaluation.FieldType = ReportFieldTypeEnum.ftVariable;
                    TransportationEvaluation.MultiLine = EvetHayirEnum.ehEvet;
                    TransportationEvaluation.NoClip = EvetHayirEnum.ehEvet;
                    TransportationEvaluation.WordBreak = EvetHayirEnum.ehEvet;
                    TransportationEvaluation.ExpandTabs = EvetHayirEnum.ehEvet;
                    TransportationEvaluation.Value = @"SHU Değerlendirme:  {#Header.TRANSPORTATIONEVALUATION#}";

                    NewField1112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 53, 89, 58, false);
                    NewField1112111.Name = "NewField1112111";
                    NewField1112111.TextFont.Bold = true;
                    NewField1112111.TextFont.Underline = true;
                    NewField1112111.TextFont.CharSet = 162;
                    NewField1112111.Value = @"AİLE BİLGİLERİ";

                    FamilyInformation = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 58, 205, 69, false);
                    FamilyInformation.Name = "FamilyInformation";
                    FamilyInformation.FieldType = ReportFieldTypeEnum.ftVariable;
                    FamilyInformation.MultiLine = EvetHayirEnum.ehEvet;
                    FamilyInformation.NoClip = EvetHayirEnum.ehEvet;
                    FamilyInformation.WordBreak = EvetHayirEnum.ehEvet;
                    FamilyInformation.ExpandTabs = EvetHayirEnum.ehEvet;
                    FamilyInformation.Value = @"{#Header.FAMILYINFORMATION#}";

                    FamilyInformationEvaluation = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 69, 205, 80, false);
                    FamilyInformationEvaluation.Name = "FamilyInformationEvaluation";
                    FamilyInformationEvaluation.FieldType = ReportFieldTypeEnum.ftVariable;
                    FamilyInformationEvaluation.MultiLine = EvetHayirEnum.ehEvet;
                    FamilyInformationEvaluation.NoClip = EvetHayirEnum.ehEvet;
                    FamilyInformationEvaluation.WordBreak = EvetHayirEnum.ehEvet;
                    FamilyInformationEvaluation.ExpandTabs = EvetHayirEnum.ehEvet;
                    FamilyInformationEvaluation.Value = @"SHU Değerlendirme:  {#Header.FAMILYINFORMATIONEVALUATION#}";

                    NewField11112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 82, 89, 87, false);
                    NewField11112111.Name = "NewField11112111";
                    NewField11112111.TextFont.Bold = true;
                    NewField11112111.TextFont.Underline = true;
                    NewField11112111.TextFont.CharSet = 162;
                    NewField11112111.Value = @"FİZİKSEL DURUM:";

                    PhysicalStatus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 87, 205, 99, false);
                    PhysicalStatus.Name = "PhysicalStatus";
                    PhysicalStatus.FieldType = ReportFieldTypeEnum.ftVariable;
                    PhysicalStatus.MultiLine = EvetHayirEnum.ehEvet;
                    PhysicalStatus.NoClip = EvetHayirEnum.ehEvet;
                    PhysicalStatus.WordBreak = EvetHayirEnum.ehEvet;
                    PhysicalStatus.ExpandTabs = EvetHayirEnum.ehEvet;
                    PhysicalStatus.Value = @"{#Header.PHYSICALSTATUS#}";

                    NewField111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 100, 89, 105, false);
                    NewField111121111.Name = "NewField111121111";
                    NewField111121111.TextFont.Bold = true;
                    NewField111121111.TextFont.Underline = true;
                    NewField111121111.TextFont.CharSet = 162;
                    NewField111121111.Value = @"HASTAYLA İLGİLİ YAPILAN İŞLER-KLİNİK İZLEM:";

                    PatientRelatedWorks = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 106, 205, 119, false);
                    PatientRelatedWorks.Name = "PatientRelatedWorks";
                    PatientRelatedWorks.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientRelatedWorks.MultiLine = EvetHayirEnum.ehEvet;
                    PatientRelatedWorks.NoClip = EvetHayirEnum.ehEvet;
                    PatientRelatedWorks.WordBreak = EvetHayirEnum.ehEvet;
                    PatientRelatedWorks.ExpandTabs = EvetHayirEnum.ehEvet;
                    PatientRelatedWorks.Value = @"{#Header.PATIENTRELATEDWORKS#}";

                    SubHeaders1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 119, 205, 137, false);
                    SubHeaders1.Name = "SubHeaders1";
                    SubHeaders1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SubHeaders1.MultiLine = EvetHayirEnum.ehEvet;
                    SubHeaders1.NoClip = EvetHayirEnum.ehEvet;
                    SubHeaders1.WordBreak = EvetHayirEnum.ehEvet;
                    SubHeaders1.ExpandTabs = EvetHayirEnum.ehEvet;
                    SubHeaders1.Value = @"Alt Başlıklar: {#Header.SUBHEADERS#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SocServPatientFamilyInfo.GetSocServPatientFamilyInfo_Class dataset_GetSocServPatientFamilyInfo = MyParentReport.Header.rsGroup.GetCurrentRecord<SocServPatientFamilyInfo.GetSocServPatientFamilyInfo_Class>(0);
                    NewField111211.CalcValue = NewField111211.Value;
                    TransportationArrival.CalcValue = @"Geliş:  " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.TransportationArrival) : "");
                    TransportationGoing.CalcValue = @"Gidiş:  " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.TransportationGoing) : "");
                    TransportationEvaluation.CalcValue = @"SHU Değerlendirme:  " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.TransportationEvaluation) : "");
                    NewField1112111.CalcValue = NewField1112111.Value;
                    FamilyInformation.CalcValue = (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.FamilyInformation) : "");
                    FamilyInformationEvaluation.CalcValue = @"SHU Değerlendirme:  " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.FamilyInformationEvaluation) : "");
                    NewField11112111.CalcValue = NewField11112111.Value;
                    PhysicalStatus.CalcValue = (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.PhysicalStatus) : "");
                    NewField111121111.CalcValue = NewField111121111.Value;
                    PatientRelatedWorks.CalcValue = (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.PatientRelatedWorks) : "");
                    SubHeaders1.CalcValue = @"Alt Başlıklar: " + (dataset_GetSocServPatientFamilyInfo != null ? Globals.ToStringCore(dataset_GetSocServPatientFamilyInfo.SubHeaders) : "");
                    return new TTReportObject[] { NewField111211,TransportationArrival,TransportationGoing,TransportationEvaluation,NewField1112111,FamilyInformation,FamilyInformationEvaluation,NewField11112111,PhysicalStatus,NewField111121111,PatientRelatedWorks,SubHeaders1};
                }
            }

        }

        public mainGroup main;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public SocialServicesPatientFamilyInfoReport()
        {
            Header = new HeaderGroup(this,"Header");
            MAIN = new MAINGroup(Header,"MAIN");
            main2 = new main2Group(Header,"main2");
            main = new mainGroup(Header,"main");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "SOCIALSERVICESPATIENTFAMILYINFOREPORT";
            Caption = "Sosyal Hizmetler Hasta Aile Bilgi Formu";
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