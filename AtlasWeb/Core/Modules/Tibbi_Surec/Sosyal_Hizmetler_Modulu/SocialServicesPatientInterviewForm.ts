//$8F376D48
import { Component, OnInit, ViewChildren, QueryList, NgZone } from '@angular/core';
import { SocialServicesPatientInterviewFormViewModel } from './SocialServicesPatientInterviewFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { HvlCheckBox } from 'Fw/Components/HvlCheckBox';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PatientInterviewForm } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMeslekler } from 'NebulaClient/Model/AtlasClientModel';
import { SocServAppliedProcedures } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOgrenimDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { PayerDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { SocServPatientFamilyInfo } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { ObjectContextService } from "Fw/Services/ObjectContextService";
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { IModalService } from 'Fw/Services/IModalService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { ModalInfo } from 'Fw/Models/ModalInfo';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { DateParam } from 'NebulaClient/Mscorlib/DateParam';
import { StringParam } from 'NebulaClient/Mscorlib/StringParam';
import { TTObjectStateTransitionDef } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef";
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { EpisodeActionData } from "Modules/Tibbi_Surec/Hasta_Dosyasi/MainPatientFolderFormViewModel";
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { FormSaveInfo } from 'NebulaClient/Mscorlib/FormSaveInfo';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';

@Component({
    selector: 'SocialServicesPatientInterviewForm',
    templateUrl: './SocialServicesPatientInterviewForm.html',
    providers: [SystemApiService, MessageService]
})
export class SocialServicesPatientInterviewForm extends TTVisual.TTForm implements OnInit {
    EducationStatus: TTVisual.ITTObjectListBox;
    Evaluation: TTVisual.ITTRichTextBoxControl;
    ExaminationDate: TTVisual.ITTDateTimePicker;
    GoodsAndMoneyHelp: TTVisual.ITTCheckBox;
    GroupStudyWithPatientFamily: TTVisual.ITTCheckBox;
    HomeOrOrganizationVisit: TTVisual.ITTCheckBox;
    InstutionalCarePlacement: TTVisual.ITTCheckBox;
    InterviewedContacts: TTVisual.ITTRichTextBoxControl;
    InterviewPlace: TTVisual.ITTRichTextBoxControl;
    MaritalStatus: TTVisual.ITTEnumComboBox;
    MasterResource: TTVisual.ITTObjectListBox;
    MeetingReason: TTVisual.ITTRichTextBoxControl;
    OtherVocationalInterventions: TTVisual.ITTCheckBox;
    PatientAccomodationEconomicCon: TTVisual.ITTRichTextBoxControl;
    PatientEducationAndWorkStudy: TTVisual.ITTCheckBox;
    PatientHealthPhysicalCond: TTVisual.ITTRichTextBoxControl;
    PatientJob: TTVisual.ITTObjectListBox;
    PatientPsychosocialFamilyCond: TTVisual.ITTRichTextBoxControl;
    PatientsGroupStudy: TTVisual.ITTCheckBox;
    PatientTransferervice: TTVisual.ITTCheckBox;
    PatientType: TTVisual.ITTEnumComboBox;
    PlacementInTemporaryShelters: TTVisual.ITTCheckBox;
    ProblemDefinition: TTVisual.ITTRichTextBoxControl;
    ProcedureByUser: TTVisual.ITTObjectListBox;
    PsychosocialEduPatientFamily: TTVisual.ITTCheckBox;
    PsychosocialStudyPatFamily: TTVisual.ITTCheckBox;
    PsychosocialStudyWithPatient: TTVisual.ITTCheckBox;
    ResultsAndRecommendations: TTVisual.ITTRichTextBoxControl;
    SchoolVisit: TTVisual.ITTCheckBox;
    SocialActivity: TTVisual.ITTCheckBox;
    SocialReviewAndEvolution: TTVisual.ITTCheckBox;
    TreatmentExpenseResourceRoute: TTVisual.ITTCheckBox;
    TypeOfService: TTVisual.ITTEnumComboBox;
    WorkplaceVisit: TTVisual.ITTCheckBox;
    /*SocServAppliedProcedures*/
    AdvancePayment: TTVisual.ITTCheckBox;
    AdvancePaymentInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    AllowancePayment: TTVisual.ITTCheckBox;
    AllowancePaymentInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    ArrangementOfLivingPlaces: TTVisual.ITTCheckBox;
    ArrangementOfLivingPlacesInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    ArrangementOfWorkSchoolEnv: TTVisual.ITTCheckBox;
    ArrangementOfWorkSchoolEnInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    BenefitingFromDonations: TTVisual.ITTCheckBox;
    BenefitingFromDonationsInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    BrotherExemptionFromMilitary: TTVisual.ITTCheckBox;
    BrotherExemptionFromMilitInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    CalcAndFollowRestProc: TTVisual.ITTCheckBox;
    CalcAndFollowRestProcInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    CashIdemnityTransactions: TTVisual.ITTCheckBox;
    CashIdemnityTransactionsInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    CoordWarVeteranContactUnit: TTVisual.ITTCheckBox;
    CoordWarVeteranContactUniInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    DomesticVehiclePurchases: TTVisual.ITTCheckBox;
    DomesticVehiclePurchasesInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    DonatedMedicalSupplyProcure: TTVisual.ITTCheckBox;
    DonatedMedicalSupplyProcInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    EducationAidBySGK: TTVisual.ITTCheckBox;
    EducationAidBySGKInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    ElectricAndWaterDiscount: TTVisual.ITTCheckBox;
    ElectricAndWaterDiscountInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    FreeAccessToPrivateEduInstit: TTVisual.ITTCheckBox;
    FreeAccessToPrivEduInstitInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    GivingCorporateHousingCredit: TTVisual.ITTCheckBox;
    GivingCorporateHousCreditInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    GivingVeteranRightsBrochure: TTVisual.ITTCheckBox;
    GivingVeteranRightsBrocInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    GrantingDealership: TTVisual.ITTCheckBox;
    GrantingDealershipInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    GrantingEmploymentRights: TTVisual.ITTCheckBox;
    GrantingEmploymentRightsInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    GuidanceAboutCareSalary: TTVisual.ITTCheckBox;
    GuidanceAboutCareSalaryInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    GuidanceAboutHomeHealthCare: TTVisual.ITTCheckBox;
    GuidanceAboutHomeHealthCrInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    GuidanceAboutLaw: TTVisual.ITTCheckBox;
    GuidanceAboutLawInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    GuidanceOnDrugSupplyAbroad: TTVisual.ITTCheckBox;
    VocationalRehabilitation: TTVisual.ITTCheckBox;
    GuidanceDrugSupplyAbroadInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    VocationalRehabilitationInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    GuidanceServiceOnPhone: TTVisual.ITTTextBox;
    GuidanceToCivilOrganizations: TTVisual.ITTCheckBox;
    GuidanceToCivilOrganizatInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    GuidanceToFoundations: TTVisual.ITTCheckBox;
    GuidanceToFoundationsInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    GuidanceToPublicInstitution: TTVisual.ITTCheckBox;
    GuidanceToPublicInstitInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    HealthAid: TTVisual.ITTCheckBox;
    HealthAidInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    IdentificationOfParticipants: TTVisual.ITTCheckBox;
    IdentificationOfParticipInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    ImportingDutyFreeVehicle: TTVisual.ITTCheckBox;
    ImportingDutyFreeVehicleInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    IncomeTaxDiscount: TTVisual.ITTCheckBox;
    IncomeTaxDiscountInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    IndemnityCompensation: TTVisual.ITTCheckBox;
    IndemnityCompensationInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    InformAndDirectRetireProc: TTVisual.ITTCheckBox;
    InformAndDirectRetireProcInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    InterCityTransportProcesses: TTVisual.ITTCheckBox;
    InterCityTransportProcessInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    IntraCityTransportProcesses: TTVisual.ITTCheckBox;
    IntraCityTransportProcessInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    JobResumeStatus: TTVisual.ITTCheckBox;
    JobResumeStatusInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    LegislativeReviewAndInfo: TTVisual.ITTCheckBox;
    LegislativeReviewAndInfoInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    MedicEqProcRefundInfoProcInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    MedicEqProcRefundInfoProcure: TTVisual.ITTCheckBox;
    MilitaryServiceNearBrotherHom: TTVisual.ITTCheckBox;
    MilitarServNearBrotherHomInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    OpenEducationHighSchool: TTVisual.ITTTextBox;
    OrganizingPermitDocuments: TTVisual.ITTCheckBox;
    OrganizingPermitDocumentsInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    Other: TTVisual.ITTTextBox;
    OTVandMTVExemption: TTVisual.ITTCheckBox;
    OTVandMTVExemptionInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    OYAKAid: TTVisual.ITTCheckBox;
    OYAKAidInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    PhoneCallWitPublicInstitution: TTVisual.ITTCheckBox;
    PhoneCallWitPublicInstitInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    ProvideHouseToDisabledStaff: TTVisual.ITTCheckBox;
    ProvideHouseToDisablStaffInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    ProvideInternalSecInjStatDoc: TTVisual.ITTCheckBox;
    ProvideInterSecInjStatDocInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    ProvidingAccomodation: TTVisual.ITTCheckBox;
    ProvidingAccomodationInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    ProvidingWarVeteranCard: TTVisual.ITTCheckBox;
    ProvidingWarVeteranCardInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    ProvisionIssues: TTVisual.ITTCheckBox;
    ProvisionIssuesInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    ResidenceTaxExemption: TTVisual.ITTCheckBox;
    ResidenceTaxExemptionInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    RetirementBonusBySGK: TTVisual.ITTCheckBox;
    RetirementBonusBySGKInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    SalaryStartBySGK: TTVisual.ITTCheckBox;
    SalaryStartBySGKInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    SoldierFoundationAid: TTVisual.ITTCheckBox;
    SoldierFoundationAidInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    SoldierLifeInsurance: TTVisual.ITTCheckBox;
    SoldierLifeInsuranceInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    StatePrideMedal: TTVisual.ITTCheckBox;
    StatePrideMedalInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    SupplementaryPaymentSGK: TTVisual.ITTCheckBox;
    SupplementaryPaymentSGKInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    XXXXXXSolidarityFoundationAid: TTVisual.ITTCheckBox;
    XXXXXXSolidarityFoundatioAidInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    UsageRightFromTOKIHouses: TTVisual.ITTCheckBox;
    UsageRightFromTOKIHousesInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    UtilityFromRehabilitationCent: TTVisual.ITTCheckBox;
    UtilityFromRehabilitCentInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    UtilizationOfPublicHousing: TTVisual.ITTCheckBox;
    UtilizationOfPublicHousinInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    WeaponPortageTransportLicense: TTVisual.ITTCheckBox;
    WeaponPortageTransportLicInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    WeeklyTeamMeetings: TTVisual.ITTCheckBox;
    WeeklyTeamMeetingsInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    WeeklyVisitAttendence: TTVisual.ITTCheckBox;
    WeeklyVisitAttendenceInfoSocServAppliedProcedures: TTVisual.ITTTextBox;
    /**/
    /*SocServPatientFamilyInfo*/
    ApplicationDateSocServPatientFamilyInfo: TTVisual.ITTDateTimePicker;
    AuxiliaryToolAfoSocServPatientFamilyInfo: TTVisual.ITTCheckBox;
    AuxiliaryToolArmRestSocServPatientFamilyInfo: TTVisual.ITTCheckBox;
    AuxiliaryToolHandSplintSocServPatientFamilyInfo: TTVisual.ITTCheckBox;
    AuxiliaryToolOtherInfoSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    AuxiliaryToolOtherSocServPatientFamilyInfo: TTVisual.ITTCheckBox;
    AuxiliaryToolTripodSocServPatientFamilyInfo: TTVisual.ITTCheckBox;
    AuxiliaryToolWalkerSocServPatientFamilyInfo: TTVisual.ITTCheckBox;
    AuxiliaryToolWheelchairSocServPatientFamilyInfo: TTVisual.ITTCheckBox;
    DateOfRetireSocServPatientFamilyInfo: TTVisual.ITTDateTimePicker;
    DateOfStartSocServPatientFamilyInfo: TTVisual.ITTDateTimePicker;
    EvaluationSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    ExactTransactionDateSocServPatientFamilyInfo: TTVisual.ITTDateTimePicker;
    JobMilitaryServStartDateSocServPatientFamilyInfo: TTVisual.ITTDateTimePicker;
    JobRightUseStatusSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    LivingHouseBasementSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    PatientDiagnosisSocServPatientFamilyInfo: TTVisual.ITTTextBox;

    LivingHouseDoorEntranceSocServPatientFamilyInfo: TTVisual.ITTEnumComboBox;
    SocioEconomicInfoEvaluationSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    TransportationArrivalSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    TransportationEvaluationSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    TransportationGoingSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    PhysicalStatusSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    PatientRelatedWorksSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    SubHeadersSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    LivingHouseBelongingInfoSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    LivingHouseBelongingSocServPatientFamilyInfo: TTVisual.ITTEnumComboBox;
    FamilyIncomingsSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    FamilyInformationEvaluationSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    FamilyInformationSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    LivingHouseWcTypeSocServPatientFamilyInfo: TTVisual.ITTEnumComboBox;
    PatientPayerNameSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    MaritalStatusSocServPatientFamilyInfo: TTVisual.ITTEnumComboBox;


    LivingHouseElevatorSocServPatientFamilyInfo: TTVisual.ITTEnumComboBox;
    LivingHouseEntranceSocServPatientFamilyInfo: TTVisual.ITTEnumComboBox;
    LivingHouseNumOfFloorSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    LivingHouseOtherInfoSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    LivingHouseTypeSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    LongTermArmBonusInterruptSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    MilitaryServiceEndDateSocServPatientFamilyInfo: TTVisual.ITTDateTimePicker;
    PreviousJobBeforeIllSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    RecruitmentOfficeSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    RestStateSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    SecondRetirementStatusSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    ShortEventStorySocServPatientFamilyInfo: TTVisual.ITTTextBox;
    SickOrInjuredPlaceSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    SickOrInjuryDateSocServPatientFamilyInfo: TTVisual.ITTDateTimePicker;
    SickOrInjuryTypeSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    SoldierPlaceOfWorkSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    SoldierRankSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    WCTypeClosetSocServPatientFamilyInfo: TTVisual.ITTCheckBox;
    WCTypeNotClosetSocServPatientFamilyInfo: TTVisual.ITTCheckBox;
    WorkPlaceSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    WrittenMedicalMaterialOrToolSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    ttobjectlistbox1: TTVisual.ITTObjectListBox;
    FatherNamePerson: TTVisual.ITTTextBox;
    NamePerson: TTVisual.ITTTextBox;
    MotherNamePerson: TTVisual.ITTTextBox;
    NameResource: TTVisual.ITTTextBox;
    SurnamePerson: TTVisual.ITTTextBox;
    UniqueRefNoPerson: TTVisual.ITTTextBox;
    MobilePhonePerson: TTVisual.ITTTextBox;
    SKRSMaritalStatus: TTVisual.ITTObjectListBox;
    BirthDatePerson: TTVisual.ITTDateTimePicker;
    HomeAddressPatientIdentityAndAddress: TTVisual.ITTTextBox;
    EducationStatusPatient: TTVisual.ITTObjectListBox;

    PatientLivesWithSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    CompanionPhoneNumSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    CompanionSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    EmploymentRecordIdSocServPatientFamilyInfo: TTVisual.ITTTextBox;
    NamePayerDefinition: TTVisual.ITTTextBox;
    public DegreeOfWarVeteranList: Array<any>= ["1","2","3","4","5","6"];


    /*Report Parameters*/
    ReportSelectedUserCombo: TTVisual.ITTObjectListBox;

    ReportStartDate: Date;
    ReportEndDate: Date;
    /**/

    @ViewChildren(HvlCheckBox) CheckBoxes: QueryList<HvlCheckBox>;

    public socialServicesPatientInterviewFormViewModel: SocialServicesPatientInterviewFormViewModel = new SocialServicesPatientInterviewFormViewModel();
    public UndoEnable: boolean = false;
    public get _PatientInterviewForm(): PatientInterviewForm {
        return this._TTObject as PatientInterviewForm;
    }
    private SocialServicesPatientInterviewForm_DocumentUrl: string = '/api/PatientInterviewFormService/SocialServicesPatientInterviewForm';
    public showReportsVisible: boolean = false;
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private sideBarMenuService: ISidebarMenuService,
        private objectContextService: ObjectContextService,
        private reportService: AtlasReportService,
        protected helpMenuService: HelpMenuService,
        public systemApiService: SystemApiService,
        protected ngZone: NgZone) {
        super('PATIENTINTERVIEWFORM', 'SocialServicesPatientInterviewForm');
        this._DocumentServiceUrl = this.SocialServicesPatientInterviewForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
       // this.DegreeOfWarVeteranList  = ["1","2","3","4","5","6"];
    }

    save() {
        if (this.socialServicesPatientInterviewFormViewModel.ReadOnly == false) {
            let checkControl: boolean;
            checkControl = false;
            let checkCounter: number = 0;
            if (this.CheckBoxes) {
                this.CheckBoxes.forEach(item => {
                    if (item.Checked && checkCounter < 17) {
                        checkControl = true;
                    }
                    checkCounter++;
                });
            }
            if (checkControl)
                if (this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.PatientType != null) {
                    return super.save();
                }
                else {
                    TTVisual.InfoBox.Alert(i18n("M18374", "Lütfen Hasta Türünü Seçiniz!"));
                }

            else
                TTVisual.InfoBox.Alert(i18n("M18370", "Lütfen en az 1 adet çalışma seçiniz!"));
        } else {
            TTVisual.InfoBox.Alert(i18n("M22726", "Tamamlanmış Çalışmayı Değiştiremezsiniz!"));
        }

    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
       
        await super.AfterContextSavedScript(transDef);

        await this.load(SocialServicesPatientInterviewFormViewModel);
    }

    openReportsPopup() {
        this.showReportsVisible = true;
    }

    undoPatientInterviewForm() {
        let that = this;
        let _DocumentServiceUrl: string = "/api/MainPatientFolderService/UndoLastTransitionEAorSPFlowableByObjectId?ObjectId=" + this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.ObjectID.toString();
        this.httpService.get<Array<EpisodeActionData>>(_DocumentServiceUrl).then(result => {
            ServiceLocator.MessageService.showSuccess("İşlem geri alınmıştır");
            //çthis.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("PATIENTINTERVIEWFORM", this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.ObjectID, null);
            this.httpService.episodeActionWorkListSharedService.refreshWorklist(true);

        }).catch(err => {
            ServiceLocator.MessageService.showError(i18n("M16843", "İşlem geri alınamamıştır.") + err);
        });
    }

    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();
        let reports = new DynamicSidebarMenuItem();
        reports.key = 'reports';
        reports.icon = 'fa fa-file-text-o';
        reports.label = i18n("M20887", "Raporlar");
        reports.componentInstance = this;
        reports.clickFunction = this.openReportsPopup;
        this.sideBarMenuService.addMenu('YardimciMenu', reports);
        if (this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.CurrentStateDefID.toString() != PatientInterviewForm.PatientInterviewFormStates.Procedure.toString()) {
            let undo = new DynamicSidebarMenuItem();
            undo.key = 'undo';
            undo.icon = 'fa fa-undo';
            undo.label = 'İşlemi Geri Al';
            undo.componentInstance = this;
            undo.clickFunction = this.undoPatientInterviewForm;
            this.sideBarMenuService.addMenu('YardimciMenu', undo);
            this.UndoEnable = true;
        }



    }
    private RemoveMenuFromHelpMenu() {
        this.sideBarMenuService.removeMenu('reports');
        if (this.UndoEnable) {
            this.sideBarMenuService.removeMenu('undo');
        }
    }






    protected async setState(transDef: TTObjectStateTransitionDef, saveInfo?: FormSaveInfo): Promise<void> {
        if (transDef.ToStateDefID.toString() == PatientInterviewForm.PatientInterviewFormStates.Completed.id.toString()) {
            let checkControl: boolean;
            checkControl = false;
            let checkCounter: number = 0;
            if (this.CheckBoxes) {
                this.CheckBoxes.forEach(item => {
                    if (item.Checked && checkCounter < 17) {
                        checkControl = true;
                    }
                    checkCounter++;
                });
            }
            if (checkControl)
                if (this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.PatientType != null) {
                    if (this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.ProcedureByUser != null) {
                        if (this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.PatientJob != null) {
                            await super.setState(transDef, saveInfo);
                            this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("PATIENTINTERVIEWFORM", this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.ObjectID, null,new DynamicComponentInputParam(null,new ActiveIDsModel(this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.ObjectID,null,null)));
                        } else {
                            TTVisual.InfoBox.Alert(i18n("M15467", "Hastanın Mesleğini Seçmeden Bu İşlemi Tamamlayamazsınız!"));
                        }
                    } else {
                        TTVisual.InfoBox.Alert(i18n("M22170", "Sosyal Çalışmacı Seçmeden Bu İşlemi Tamamlayamazsınız"));
                    }
                }
                else {
                    TTVisual.InfoBox.Alert(i18n("M18374", "Lütfen Hasta Türünü Seçiniz!"));
                }

            else
                TTVisual.InfoBox.Alert(i18n("M18370", "Lütfen en az 1 adet çalışma seçiniz!"));


        } else {
            await super.setState(transDef, saveInfo);
        }

    }

    // ***** Method declarations start *****
    async selectTab(e) {
        let selectedItem: string = e.addedItems[0].title;
        if (selectedItem == i18n("M15524", "Hastaya Yapılan İşlemler")) {
            // this.isInfertilityActive = true;
            if (this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.SocServAppliedProcedures == null) {
                // this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.SocServAppliedProcedures = new SocServAppliedProcedures();
                this._PatientInterviewForm.SocServAppliedProcedures = await this.objectContextService.getNewObjectWithDefName<SocServAppliedProcedures>(SocServAppliedProcedures.ObjectDefName);
                this._PatientInterviewForm.SocServAppliedProcedures = this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.SocServAppliedProcedures;
                this.socialServicesPatientInterviewFormViewModel.SocServAppliedProceduress.push(this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.SocServAppliedProcedures);

            }
        } else if (selectedItem == i18n("M15351", "Hasta-Aile Bilgi Formu")) {
            if (this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.SocServPatientFamilyInfo == null) {
                this._PatientInterviewForm.SocServPatientFamilyInfo = await this.objectContextService.getNewObjectWithDefName<SocServPatientFamilyInfo>(SocServPatientFamilyInfo.ObjectDefName);
                this._PatientInterviewForm.SocServPatientFamilyInfo = this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.SocServPatientFamilyInfo;
                this._PatientInterviewForm.SocServPatientFamilyInfo.Companion = this.socialServicesPatientInterviewFormViewModel.CompanionName;
                this._PatientInterviewForm.SocServPatientFamilyInfo.PatientPayerName = this.socialServicesPatientInterviewFormViewModel.PayerName;
                this._PatientInterviewForm.SocServPatientFamilyInfo.PatientDiagnosis = this.socialServicesPatientInterviewFormViewModel.Diagnosis;
                this.socialServicesPatientInterviewFormViewModel.SocServPatientFamilyInfos.push(this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.SocServPatientFamilyInfo);

            }
        }
    }

    public openTextAreaInPopup(a: any) {

        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'PopupTextAreaForm';
        componentInfo.ModuleName = 'PopupTextAreaModule';
        componentInfo.ModulePath = 'Modules/Tibbi_Surec/Sosyal_Hizmetler_Modulu/PopupTextArea/PopupTextAreaModule';
        componentInfo.InputParam =  new DynamicComponentInputParam(a.Text, new ActiveIDsModel(this._PatientInterviewForm.ObjectID, null, null));

        let modalInfo: ModalInfo = new ModalInfo();
        modalInfo.Title = "";
        modalInfo.Width = 950;
        modalInfo.Height = 950;

        let promise = new Promise<string>(function (resolve, reject) {
            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(res => {
                if (res.Param.toString() != "[object Object]")
                    a.Text = res.Param;
            }).catch(err => {
                reject(err);
            });
        });
        return promise;

    }

    public printAppliedProceduresReport() {
        const objectIdParam = new GuidParam(this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.SocServAppliedProcedures.ObjectID);
        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
        this.reportService.showReport('SocialServicesAppliedProceduresReport', reportParameters);
    }

    public printPatientFamilyInfoReport() {
        const objectIdParam = new GuidParam(this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.SocServPatientFamilyInfo.ObjectID);
        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
        this.reportService.showReport('SocialServicesPatientFamilyInfoReport', reportParameters);
    }
    // *****Method declarations end *****

    public printUnitRegistryReport() {
        let procedureByUserParam: StringParam;
        const startDateParam = new DateParam(this.ReportStartDate);
        const endDateParam = new DateParam(this.ReportEndDate);
        if (this.socialServicesPatientInterviewFormViewModel.ReportSelectedUser != null) {
            procedureByUserParam = new StringParam(this.socialServicesPatientInterviewFormViewModel.ReportSelectedUser.ObjectID.toString());
        } else {
            procedureByUserParam = new StringParam(null);
        }

        let reportParameters: any = { 'STARTDATE': startDateParam, 'ENDDATE': endDateParam, 'PROCEDUREBYUSER': procedureByUserParam };
        this.reportService.showReport(i18n("M22201", "SosyalHizmetBirimiKayitDefteri"), reportParameters);
    }
    public printUnitActivityReport() {
        let procedureByUserParam: StringParam;
        const startDateParam = new DateParam(this.ReportStartDate);
        const endDateParam = new DateParam(this.ReportEndDate);
        if (this.socialServicesPatientInterviewFormViewModel.ReportSelectedUser != null) {
            procedureByUserParam = new StringParam(this.socialServicesPatientInterviewFormViewModel.ReportSelectedUser.ObjectID.toString());
        } else {
            procedureByUserParam = new StringParam(null);
        }

        let reportParameters: any = { 'STARTDATE': startDateParam, 'ENDDATE': endDateParam, 'PROCEDUREBYUSER': procedureByUserParam };
        this.reportService.showReport(i18n("M14086", "FaaliyetRaporu"), reportParameters);
    }

    public initViewModel(): void {
        this._TTObject = new PatientInterviewForm();
        this.socialServicesPatientInterviewFormViewModel = new SocialServicesPatientInterviewFormViewModel();
        this._ViewModel = this.socialServicesPatientInterviewFormViewModel;
        this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm = this._TTObject as PatientInterviewForm;
        this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.MasterResource = new ResSection();
        this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.ProcedureByUser = new ResUser();
        this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.PatientJob = new SKRSMeslekler();
        this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.EducationStatus = new SKRSOgrenimDurumu();
        /*SocServAppliedProcedures*/
        this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.SocServAppliedProcedures = new SocServAppliedProcedures();
        /*SocServPatientFamilyInfo*/
        this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.SocServPatientFamilyInfo = new SocServPatientFamilyInfo();
        this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.Episode = new Episode();
        // this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.Episode.Room = new ResRoom();
        this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.Episode.Patient = new Patient();
        this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.Episode.Payer = new PayerDefinition();
        this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.Episode.Patient.EducationStatus = new SKRSOgrenimDurumu();
        //this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.Episode.Patient.PatientAddress = new PatientIdentityAndAddress();
        //this.socialServicesPatientInterviewFormViewModel.ReportSelectedUser = new ResUser();

    }



    protected async ClientSidePreScript(): Promise<void> {
        await this.setConsultationDoctorListFilter(this._PatientInterviewForm.MasterResource);
    }
    async setConsultationDoctorListFilter(data: any) {
        if (!data) {
            this.ProcedureByUser.ListFilterExpression = "1=1";
            this.ReportSelectedUserCombo.ListFilterExpression = "1=1";
        }
        else {
            this.ProcedureByUser.ListFilterExpression = "USERRESOURCES.RESOURCE ='" + data.ObjectID.toString() + "'";
            this.ReportSelectedUserCombo.ListFilterExpression = "USERRESOURCES.RESOURCE ='" + data.ObjectID.toString() + "'";
            //let consultationReqResList: Array<ResSection.ConsultationRequestResourceListNql_Class> = await ResSectionService.ConsultationRequestResourceListNql(this.ConsultationRequestedUser.ListFilterExpression);
        }
    }

    protected loadViewModel() {
        let that = this;
        that.socialServicesPatientInterviewFormViewModel = this._ViewModel as SocialServicesPatientInterviewFormViewModel;
        that._TTObject = this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm;
        if (this.socialServicesPatientInterviewFormViewModel == null)
            this.socialServicesPatientInterviewFormViewModel = new SocialServicesPatientInterviewFormViewModel();
        if (this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm == null)
            this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm = new PatientInterviewForm();
        let masterResourceObjectID = that.socialServicesPatientInterviewFormViewModel._PatientInterviewForm["MasterResource"];
        if (masterResourceObjectID != null && (typeof masterResourceObjectID === "string")) {
            let masterResource = that.socialServicesPatientInterviewFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
            if (masterResource) {
                that.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.MasterResource = masterResource;
            }
        }
        let procedureByUserObjectID = that.socialServicesPatientInterviewFormViewModel._PatientInterviewForm["ProcedureByUser"];
        if (procedureByUserObjectID != null && (typeof procedureByUserObjectID === "string")) {
            let procedureByUser = that.socialServicesPatientInterviewFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureByUserObjectID.toString());
            if (procedureByUser) {
                that.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.ProcedureByUser = procedureByUser;
            }
        }
        let patientJobObjectID = that.socialServicesPatientInterviewFormViewModel._PatientInterviewForm["PatientJob"];
        if (patientJobObjectID != null && (typeof patientJobObjectID === "string")) {
            let patientJob = that.socialServicesPatientInterviewFormViewModel.SKRSMesleklers.find(o => o.ObjectID.toString() === patientJobObjectID.toString());
            if (patientJob) {
                that.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.PatientJob = patientJob;
            }
        }
        let educationStatusObjectID = that.socialServicesPatientInterviewFormViewModel._PatientInterviewForm["EducationStatus"];
        if (educationStatusObjectID != null && (typeof educationStatusObjectID === "string")) {
            let educationStatus = that.socialServicesPatientInterviewFormViewModel.SKRSOgrenimDurumus.find(o => o.ObjectID.toString() === educationStatusObjectID.toString());
            if (educationStatus) {
                that.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.EducationStatus = educationStatus;
            }
        }
        let socServAppliedProceduresObjectID = that.socialServicesPatientInterviewFormViewModel._PatientInterviewForm["SocServAppliedProcedures"];
        if (socServAppliedProceduresObjectID != null && (typeof socServAppliedProceduresObjectID === "string")) {
            let socServAppliedProcedures = that.socialServicesPatientInterviewFormViewModel.SocServAppliedProceduress.find(o => o.ObjectID.toString() === socServAppliedProceduresObjectID.toString());
            if (socServAppliedProcedures) {
                that.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.SocServAppliedProcedures = socServAppliedProcedures;
            }
        }
        let socServPatientFamilyInfoObjectID = that.socialServicesPatientInterviewFormViewModel._PatientInterviewForm["SocServPatientFamilyInfo"];
        if (socServPatientFamilyInfoObjectID != null && (typeof socServPatientFamilyInfoObjectID === "string")) {
            let socServPatientFamilyInfo = that.socialServicesPatientInterviewFormViewModel.SocServPatientFamilyInfos.find(o => o.ObjectID.toString() === socServPatientFamilyInfoObjectID.toString());
            if (socServPatientFamilyInfo) {
                that.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.SocServPatientFamilyInfo = socServPatientFamilyInfo;
            }
        }

        let episodeObjectID = that.socialServicesPatientInterviewFormViewModel._PatientInterviewForm["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
            let episode = that.socialServicesPatientInterviewFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.Episode = episode;
            }
            /*if (episode != null) {
                let roomObjectID = episode["Room"];
                if (roomObjectID != null && (typeof roomObjectID === "string")) {
                    let room = that.socialServicesPatientInterviewFormViewModel.ResRooms.find(o => o.ObjectID.toString() === roomObjectID.toString());
                     if (room) {
                        episode.Room = room;
                    }
                }
            }*/
            if (episode != null) {
                let payerObjectID = episode["Payer"];
                if (payerObjectID != null && (typeof payerObjectID === "string")) {
                    let payer = that.socialServicesPatientInterviewFormViewModel.PayerDefinitions.find(o => o.ObjectID.toString() === payerObjectID.toString());
                    if (payer) {
                        episode.Payer = payer;
                    }
                }
            }
            if (episode != null) {
                let patientObjectID = episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === "string")) {
                    let patient = that.socialServicesPatientInterviewFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                    if (patient) {
                        episode.Patient = patient;
                    }
                    if (patient != null) {
                        let educationStatusObjectID = patient["EducationStatus"];
                        if (educationStatusObjectID != null && (typeof educationStatusObjectID === "string")) {
                            let educationStatus = that.socialServicesPatientInterviewFormViewModel.SKRSOgrenimDurumus.find(o => o.ObjectID.toString() === educationStatusObjectID.toString());
                            if (educationStatus) {
                                patient.EducationStatus = educationStatus;
                            }
                        }
                    }
                    /* if (patient != null) {
                         let patientAddressObjectID = patient["PatientAddress"];
                         if (patientAddressObjectID != null && (typeof patientAddressObjectID === "string")) {
                             let patientAddress = that.socialServicesPatientInterviewFormViewModel.PatientIdentityAndAddresss.find(o => o.ObjectID.toString() === patientAddressObjectID.toString());
                             if(patientAddress != undefined) 
                                 patient.PatientAddress = patientAddress;
                         }
                     }*/
                }
            }
        }
        this.onTypeOfServiceChanged(0);
        if (this.socialServicesPatientInterviewFormViewModel._PatientInterviewForm.CurrentStateDefID.toString() != PatientInterviewForm.PatientInterviewFormStates.Procedure.toString()) {
            this.UndoEnable = true;
        }

    }

    async ngOnInit() {
        let that = this;
        await this.load(SocialServicesPatientInterviewFormViewModel);
        this.AddHelpMenu();
  

    }
    public ngOnDestroy(): void {
        this.RemoveMenuFromHelpMenu();

    }


    private editorConfig: any = {
        height: '140px',
        width: '475px'
    };
    public onReportSelectedUserComboChanged(event): void {
        if (this.socialServicesPatientInterviewFormViewModel.ReportSelectedUser != null || this.socialServicesPatientInterviewFormViewModel.ReportSelectedUser != event) {
            this.socialServicesPatientInterviewFormViewModel.ReportSelectedUser = event;
        }
    }
    /*socServAppliedProcedures*/
    public onAdvancePaymentInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.AdvancePaymentInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.AdvancePaymentInfo = event;
            }
        }
    }

    public onAllowancePaymentInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.AllowancePaymentInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.AllowancePaymentInfo = event;
            }
        }
    }

    public onArrangementOfWorkSchoolEnInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.ArrangementOfWorkSchoolEnInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.ArrangementOfWorkSchoolEnInfo = event;
            }
        }
    }

    public onMaritalStatusChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.MaritalStatus != event) {
                this._PatientInterviewForm.MaritalStatus = event;
            }
        }
    }


    public onArrangementOfLivingPlacesInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.ArrangementOfLivingPlacesInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.ArrangementOfLivingPlacesInfo = event;
            }
        }
    }

    public onAdvancePaymentChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.AdvancePayment != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.AdvancePayment = event;
            }
        }
    }

    public onAllowancePaymentChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.AllowancePayment != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.AllowancePayment = event;
            }
        }
    }

    public onBenefitingFromDonationsInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.BenefitingFromDonationsInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.BenefitingFromDonationsInfo = event;
            }
        }
    }

    public onCashIdemnityTransactionsInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.CashIdemnityTransactionsInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.CashIdemnityTransactionsInfo = event;
            }
        }
    }

    public onCoordWarVeteranContactUniInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.CoordWarVeteranContactUniInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.CoordWarVeteranContactUniInfo = event;
            }
        }
    }
    public onDomesticVehiclePurchasesInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.DomesticVehiclePurchasesInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.DomesticVehiclePurchasesInfo = event;
            }
        }
    }
    public onEducationAidBySGKInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.EducationAidBySGKInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.EducationAidBySGKInfo = event;
            }
        }
    }

    public onElectricAndWaterDiscountInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.ElectricAndWaterDiscountInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.ElectricAndWaterDiscountInfo = event;
            }
        }
    }

    public onFreeAccessToPrivEduInstitInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.FreeAccessToPrivEduInstitInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.FreeAccessToPrivEduInstitInfo = event;
            }
        }
    }

    public onGivingCorporateHousCreditInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.GivingCorporateHousCreditInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.GivingCorporateHousCreditInfo = event;
            }
        }
    }

    public onGivingVeteranRightsBrocInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.GivingVeteranRightsBrocInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.GivingVeteranRightsBrocInfo = event;
            }
        }
    }

    public onGrantingDealershipInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.GrantingDealershipInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.GrantingDealershipInfo = event;
            }
        }
    }
    public onDonatedMedicalSupplyProcInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.DonatedMedicalSupplyProcInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.DonatedMedicalSupplyProcInfo = event;
            }
        }
    }

    public onGrantingEmploymentRightsInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.GrantingEmploymentRightsInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.GrantingEmploymentRightsInfo = event;
            }
        }
    }

    public onGuidanceAboutCareSalaryInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.GuidanceAboutCareSalaryInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.GuidanceAboutCareSalaryInfo = event;
            }
        }
    }

    public onGuidanceAboutHomeHealthCrInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.GuidanceAboutHomeHealthCrInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.GuidanceAboutHomeHealthCrInfo = event;
            }
        }
    }

    public onGuidanceAboutLawInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.GuidanceAboutLawInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.GuidanceAboutLawInfo = event;
            }
        }
    }

    public onGuidanceDrugSupplyAbroadInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.GuidanceDrugSupplyAbroadInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.GuidanceDrugSupplyAbroadInfo = event;
            }
        }
    }

    public onVocationalRehabilitationInfoSocServAppliedProceduresChanged(event): void {
        if (event != null)
        {
            if (this._PatientInterviewForm != null &&  this._PatientInterviewForm.SocServAppliedProcedures != null &&
                this._PatientInterviewForm.SocServAppliedProcedures.VocationalRehabilitationInfo != event)
            {
                this._PatientInterviewForm.SocServAppliedProcedures.VocationalRehabilitationInfo = event;
            }
        }
    }

    public onCalcAndFollowRestProcInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.CalcAndFollowRestProcInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.CalcAndFollowRestProcInfo = event;
            }
        }
    }
    public onGuidanceToCivilOrganizatInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.GuidanceToCivilOrganizatInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.GuidanceToCivilOrganizatInfo = event;
            }
        }
    }
    public onGuidanceToFoundationsInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.GuidanceToFoundationsInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.GuidanceToFoundationsInfo = event;
            }
        }
    }

    public onGuidanceToPublicInstitInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.GuidanceToPublicInstitInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.GuidanceToPublicInstitInfo = event;
            }
        }
    }

    public onHealthAidInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.HealthAidInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.HealthAidInfo = event;
            }
        }
    }

    public onIdentificationOfParticipInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.IdentificationOfParticipInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.IdentificationOfParticipInfo = event;
            }
        }
    }

    public onImportingDutyFreeVehicleInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.ImportingDutyFreeVehicleInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.ImportingDutyFreeVehicleInfo = event;
            }
        }
    }
    public onIncomeTaxDiscountInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.IncomeTaxDiscountInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.IncomeTaxDiscountInfo = event;
            }
        }
    }

    public onInformAndDirectRetireProcInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.InformAndDirectRetireProcInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.InformAndDirectRetireProcInfo = event;
            }
        }
    }

    public onIntraCityTransportProcessInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.IntraCityTransportProcessInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.IntraCityTransportProcessInfo = event;
            }
        }
    }

    public onJobResumeStatusInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.JobResumeStatusInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.JobResumeStatusInfo = event;
            }
        }
    }

    public onMedicEqProcRefundInfoProcInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.MedicEqProcRefundInfoProcInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.MedicEqProcRefundInfoProcInfo = event;
            }
        }
    }

    public onMilitarServNearBrotherHomInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.MilitarServNearBrotherHomInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.MilitarServNearBrotherHomInfo = event;
            }
        }
    }

    public onOrganizingPermitDocumentsInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.OrganizingPermitDocumentsInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.OrganizingPermitDocumentsInfo = event;
            }
        }
    }

    public onOTVandMTVExemptionInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.OTVandMTVExemptionInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.OTVandMTVExemptionInfo = event;
            }
        }
    }

    public onOYAKAidInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.OYAKAidInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.OYAKAidInfo = event;
            }
        }
    }

    public onPhoneCallWitPublicInstitInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.PhoneCallWitPublicInstitInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.PhoneCallWitPublicInstitInfo = event;
            }
        }
    }

    public onProvideHouseToDisablStaffInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.ProvideHouseToDisablStaffInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.ProvideHouseToDisablStaffInfo = event;
            }
        }
    }

    public onProvideInterSecInjStatDocInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.ProvideInterSecInjStatDocInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.ProvideInterSecInjStatDocInfo = event;
            }
        }
    }

    public onProvidingAccomodationInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.ProvidingAccomodationInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.ProvidingAccomodationInfo = event;
            }
        }
    }

    public onProvidingWarVeteranCardInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.ProvidingWarVeteranCardInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.ProvidingWarVeteranCardInfo = event;
            }
        }
    }

    public onProvisionIssuesInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.ProvisionIssuesInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.ProvisionIssuesInfo = event;
            }
        }
    }

    public onResidenceTaxExemptionInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.ResidenceTaxExemptionInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.ResidenceTaxExemptionInfo = event;
            }
        }
    }

    public onRetirementBonusBySGKInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.RetirementBonusBySGKInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.RetirementBonusBySGKInfo = event;
            }
        }
    }

    public onSalaryStartBySGKInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.SalaryStartBySGKInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.SalaryStartBySGKInfo = event;
            }
        }
    }

    public onSoldierFoundationAidInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.SoldierFoundationAidInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.SoldierFoundationAidInfo = event;
            }
        }
    }

    public onSoldierLifeInsuranceInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.SoldierLifeInsuranceInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.SoldierLifeInsuranceInfo = event;
            }
        }
    }

    public onStatePrideMedalInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.StatePrideMedalInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.StatePrideMedalInfo = event;
            }
        }
    }

    public onSupplementaryPaymentSGKInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.SupplementaryPaymentSGKInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.SupplementaryPaymentSGKInfo = event;
            }
        }
    }

    public onXXXXXXSolidarityFoundatioAidInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.XXXXXXSolidarityFoundatioAidInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.XXXXXXSolidarityFoundatioAidInfo = event;
            }
        }
    }

    public onUsageRightFromTOKIHousesInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.UsageRightFromTOKIHousesInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.UsageRightFromTOKIHousesInfo = event;
            }
        }
    }

    public onUtilityFromRehabilitCentInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.UtilityFromRehabilitCentInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.UtilityFromRehabilitCentInfo = event;
            }
        }
    }

    public onUtilizationOfPublicHousinInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.UtilizationOfPublicHousinInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.UtilizationOfPublicHousinInfo = event;
            }
        }
    }

    public onWeaponPortageTransportLicInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.WeaponPortageTransportLicInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.WeaponPortageTransportLicInfo = event;
            }
        }
    }

    public onWeeklyTeamMeetingsInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.WeeklyTeamMeetingsInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.WeeklyTeamMeetingsInfo = event;
            }
        }
    }

    public onWeeklyVisitAttendenceInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.WeeklyVisitAttendenceInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.WeeklyVisitAttendenceInfo = event;
            }
        }
    }

    public onLegislativeReviewAndInfoInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.LegislativeReviewAndInfoInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.LegislativeReviewAndInfoInfo = event;
            }
        }
    }


    public onInterCityTransportProcessInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.InterCityTransportProcessInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.InterCityTransportProcessInfo = event;
            }
        }
    }

    public onIndemnityCompensationInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.IndemnityCompensationInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.IndemnityCompensationInfo = event;
            }
        }
    }

    public onBrotherExemptionFromMilitInfoSocServAppliedProceduresChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.BrotherExemptionFromMilitInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.BrotherExemptionFromMilitInfo = event;
            }
        }
    }

    public onArrangementOfLivingPlacesChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.ArrangementOfLivingPlaces != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.ArrangementOfLivingPlaces = event;
            }
        }
    }

    public onArrangementOfWorkSchoolEnvChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.ArrangementOfWorkSchoolEnv != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.ArrangementOfWorkSchoolEnv = event;
            }
        }
    }

    public onBenefitingFromDonationsChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.BenefitingFromDonations != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.BenefitingFromDonations = event;
            }
        }
    }

    public onBrotherExemptionFromMilitaryChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.BrotherExemptionFromMilitary != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.BrotherExemptionFromMilitary = event;
            }
        }
    }

    public onCalcAndFollowRestProcChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.CalcAndFollowRestProc != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.CalcAndFollowRestProc = event;
            }
        }
    }

    public onCashIdemnityTransactionsChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.CashIdemnityTransactions != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.CashIdemnityTransactions = event;
            }
        }
    }

    public onCoordWarVeteranContactUnitChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.CoordWarVeteranContactUnit != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.CoordWarVeteranContactUnit = event;
            }
        }
    }

    public onDomesticVehiclePurchasesChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.DomesticVehiclePurchases != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.DomesticVehiclePurchases = event;
            }
        }
    }

    public onDonatedMedicalSupplyProcureChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.DonatedMedicalSupplyProcure != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.DonatedMedicalSupplyProcure = event;
            }
        }
    }

    public onEducationAidBySGKChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.EducationAidBySGK != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.EducationAidBySGK = event;
            }
        }
    }

    public onElectricAndWaterDiscountChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.ElectricAndWaterDiscount != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.ElectricAndWaterDiscount = event;
            }
        }
    }

    public onFreeAccessToPrivateEduInstitChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.FreeAccessToPrivateEduInstit != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.FreeAccessToPrivateEduInstit = event;
            }
        }
    }

    public onGivingCorporateHousingCreditChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.GivingCorporateHousingCredit != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.GivingCorporateHousingCredit = event;
            }
        }
    }

    public onGivingVeteranRightsBrochureChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.GivingVeteranRightsBrochure != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.GivingVeteranRightsBrochure = event;
            }
        }
    }

    public onGrantingDealershipChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.GrantingDealership != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.GrantingDealership = event;
            }
        }
    }

    public onGrantingEmploymentRightsChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.GrantingEmploymentRights != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.GrantingEmploymentRights = event;
            }
        }
    }

    public onGuidanceAboutCareSalaryChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.GuidanceAboutCareSalary != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.GuidanceAboutCareSalary = event;
            }
        }
    }

    public onGuidanceAboutHomeHealthCareChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.GuidanceAboutHomeHealthCare != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.GuidanceAboutHomeHealthCare = event;
            }
        }
    }

    public onGuidanceAboutLawChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.GuidanceAboutLaw != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.GuidanceAboutLaw = event;
            }
        }
    }

    public onGuidanceOnDrugSupplyAbroadChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.GuidanceOnDrugSupplyAbroad != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.GuidanceOnDrugSupplyAbroad = event;
            }
        }
    }
    public onVocationalRehabilitationChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.VocationalRehabilitation != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.VocationalRehabilitation = event;
            }
        }
    }
    public onGuidanceServiceOnPhoneChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.GuidanceServiceOnPhone != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.GuidanceServiceOnPhone = event;
            }
        }
    }

    public onGuidanceToCivilOrganizationsChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.GuidanceToCivilOrganizations != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.GuidanceToCivilOrganizations = event;
            }
        }
    }

    public onGuidanceToFoundationsChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.GuidanceToFoundations != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.GuidanceToFoundations = event;
            }
        }
    }

    public onGuidanceToPublicInstitutionChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.GuidanceToPublicInstitution != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.GuidanceToPublicInstitution = event;
            }
        }
    }

    public onHealthAidChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.HealthAid != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.HealthAid = event;
            }
        }
    }

    public onIdentificationOfParticipantsChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.IdentificationOfParticipants != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.IdentificationOfParticipants = event;
            }
        }
    }

    public onImportingDutyFreeVehicleChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.ImportingDutyFreeVehicle != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.ImportingDutyFreeVehicle = event;
            }
        }
    }

    public onIncomeTaxDiscountChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.IncomeTaxDiscount != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.IncomeTaxDiscount = event;
            }
        }
    }

    public onIndemnityCompensationChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.IndemnityCompensation != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.IndemnityCompensation = event;
            }
        }
    }

    public onInformAndDirectRetireProcChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.InformAndDirectRetireProc != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.InformAndDirectRetireProc = event;
            }
        }
    }


    public onInterCityTransportProcessesChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.InterCityTransportProcesses != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.InterCityTransportProcesses = event;
            }
        }
    }

    public onIntraCityTransportProcessesChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.IntraCityTransportProcesses != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.IntraCityTransportProcesses = event;
            }
        }
    }

    public onJobResumeStatusChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.JobResumeStatus != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.JobResumeStatus = event;
            }
        }
    }

    public onLegislativeReviewAndInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.LegislativeReviewAndInfo != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.LegislativeReviewAndInfo = event;
            }
        }
    }



    public onMedicEqProcRefundInfoProcureChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.MedicEqProcRefundInfoProcure != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.MedicEqProcRefundInfoProcure = event;
            }
        }
    }

    public onMilitaryServiceNearBrotherHomChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.MilitaryServiceNearBrotherHom != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.MilitaryServiceNearBrotherHom = event;
            }
        }
    }

    public onOpenEducationHighSchoolChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.OpenEducationHighSchool != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.OpenEducationHighSchool = event;
            }
        }
    }

    public onOrganizingPermitDocumentsChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.OrganizingPermitDocuments != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.OrganizingPermitDocuments = event;
            }
        }
    }

    public onOtherChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.Other != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.Other = event;
            }
        }
    }

    public onOTVandMTVExemptionChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.OTVandMTVExemption != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.OTVandMTVExemption = event;
            }
        }
    }

    public onOYAKAidChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.OYAKAid != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.OYAKAid = event;
            }
        }
    }

    public onPhoneCallWitPublicInstitutionChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.PhoneCallWitPublicInstitution != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.PhoneCallWitPublicInstitution = event;
            }
        }
    }



    public onProvideHouseToDisabledStaffChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.ProvideHouseToDisabledStaff != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.ProvideHouseToDisabledStaff = event;
            }
        }
    }

    public onProvideInternalSecInjStatDocChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.ProvideInternalSecInjStatDoc != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.ProvideInternalSecInjStatDoc = event;
            }
        }
    }

    public onProvidingAccomodationChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.ProvidingAccomodation != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.ProvidingAccomodation = event;
            }
        }
    }



    public onProvidingWarVeteranCardChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.ProvidingWarVeteranCard != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.ProvidingWarVeteranCard = event;
            }
        }
    }

    public onProvisionIssuesChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.ProvisionIssues != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.ProvisionIssues = event;
            }
        }
    }

    public onResidenceTaxExemptionChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.ResidenceTaxExemption != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.ResidenceTaxExemption = event;
            }
        }
    }

    public onRetirementBonusBySGKChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.RetirementBonusBySGK != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.RetirementBonusBySGK = event;
            }
        }
    }



    public onSalaryStartBySGKChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.SalaryStartBySGK != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.SalaryStartBySGK = event;
            }
        }
    }


    public onSoldierFoundationAidChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.SoldierFoundationAid != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.SoldierFoundationAid = event;
            }
        }
    }

    public onSoldierLifeInsuranceChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.SoldierLifeInsurance != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.SoldierLifeInsurance = event;
            }
        }
    }

    public onStatePrideMedalChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.StatePrideMedal != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.StatePrideMedal = event;
            }
        }
    }

    public onSupplementaryPaymentSGKChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.SupplementaryPaymentSGK != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.SupplementaryPaymentSGK = event;
            }
        }
    }



    public onXXXXXXSolidarityFoundationAidChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.XXXXXXSolidarityFoundationAid != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.XXXXXXSolidarityFoundationAid = event;
            }
        }
    }

    public onUsageRightFromTOKIHousesChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.UsageRightFromTOKIHouses != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.UsageRightFromTOKIHouses = event;
            }
        }
    }

    public onUtilityFromRehabilitationCentChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.UtilityFromRehabilitationCent != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.UtilityFromRehabilitationCent = event;
            }
        }
    }

    public onUtilizationOfPublicHousingChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.UtilizationOfPublicHousing != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.UtilizationOfPublicHousing = event;
            }
        }
    }

    public onWeaponPortageTransportLicenseChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.WeaponPortageTransportLicense != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.WeaponPortageTransportLicense = event;
            }
        }
    }

    public onWeeklyTeamMeetingsChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.WeeklyTeamMeetings != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.WeeklyTeamMeetings = event;
            }
        }
    }

    public onWeeklyVisitAttendenceChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocServAppliedProcedures != null && this._PatientInterviewForm.SocServAppliedProcedures.WeeklyVisitAttendence != event) {
                this._PatientInterviewForm.SocServAppliedProcedures.WeeklyVisitAttendence = event;
            }
        }
    }





    /**/
    /*SocServPatientFamilyInfo*/

    public onLivingHouseDoorEntranceSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.LivingHouseDoorEntrance != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.LivingHouseDoorEntrance = event;
            }
        }
    }

    public onSocioEconomicInfoEvaluationSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.SocioEconomicInfoEvaluation != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.SocioEconomicInfoEvaluation = event;
            }
        }
    }


    public onBirthDatePersonChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.Episode != null &&
                this._PatientInterviewForm.Episode.Patient != null && this._PatientInterviewForm.Episode.Patient.BirthDate != event) {
                this._PatientInterviewForm.Episode.Patient.BirthDate = event;
            }
        }
    }

    public onTransportationArrivalSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.TransportationArrival != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.TransportationArrival = event;
            }
        }
    }

    public onTransportationEvaluationSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.TransportationEvaluation != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.TransportationEvaluation = event;
            }
        }
    }

    public onPatientDiagnosisSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.PatientDiagnosis != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.PatientDiagnosis = event;
            }
        }
    }

    public onPatientPayerNameSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.PatientPayerName != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.PatientPayerName = event;
            }
        }
    }


    public onTransportationGoingSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.TransportationGoing != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.TransportationGoing = event;
            }
        }
    }

    public onPhysicalStatusSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.PhysicalStatus != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.PhysicalStatus = event;
            }
        }
    }

    public onPatientRelatedWorksSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.PatientRelatedWorks != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.PatientRelatedWorks = event;
            }
        }
    }

    public onSubHeadersSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.SubHeaders != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.SubHeaders = event;
            }
        }
    }

    public onLivingHouseBelongingInfoSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.LivingHouseBelongingInfo != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.LivingHouseBelongingInfo = event;
            }
        }
    }

    public onLivingHouseBelongingSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.LivingHouseBelonging != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.LivingHouseBelonging = event;
                if (event == 0 || event == 3) {
                    this.LivingHouseBelongingInfoSocServPatientFamilyInfo.Visible = true;
                } else {
                    this.LivingHouseBelongingInfoSocServPatientFamilyInfo.Visible = false;
                    this._PatientInterviewForm.SocServPatientFamilyInfo.LivingHouseBelongingInfo = null;
                }
            }
        }
    }

    public onFamilyIncomingsSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.FamilyIncomings != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.FamilyIncomings = event;
            }
        }
    }

    public onFamilyInformationEvaluationSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.FamilyInformationEvaluation != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.FamilyInformationEvaluation = event;
            }
        }
    }

    public onFamilyInformationSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.FamilyInformation != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.FamilyInformation = event;
            }
        }
    }

    public onLivingHouseWcTypeSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.LivingHouseWcType != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.LivingHouseWcType = event;
            }
        }
    }




    public onFatherNamePersonChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.Episode != null &&
                this._PatientInterviewForm.Episode.Patient != null && this._PatientInterviewForm.Episode.Patient.FatherName != event) {
                this._PatientInterviewForm.Episode.Patient.FatherName = event;
            }
        }
    }

    public onMaritalStatusPersonChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.Episode != null &&
                this._PatientInterviewForm.Episode.Patient != null && this._PatientInterviewForm.Episode.Patient.SKRSMaritalStatus != event) {
                this._PatientInterviewForm.Episode.Patient.SKRSMaritalStatus = event;
            }
        }
    }

    public onMobilePhonePersonChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.PatientPhoneNum != event) {
                this._PatientInterviewForm.PatientPhoneNum = event;
            }
        }
    }
    public onHomeAddressPatientIdentityAndAddressChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.PatientAddress != event) {
                this._PatientInterviewForm.PatientAddress = event;
            }
        }
    }

    public onMotherNamePersonChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.Episode != null &&
                this._PatientInterviewForm.Episode.Patient != null && this._PatientInterviewForm.Episode.Patient.MotherName != event) {
                this._PatientInterviewForm.Episode.Patient.MotherName = event;
            }
        }
    }

    public onNamePersonChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.Episode != null &&
                this._PatientInterviewForm.Episode.Patient != null && this._PatientInterviewForm.Episode.Patient.Name != event) {
                this._PatientInterviewForm.Episode.Patient.Name = event;
            }
        }
    }

    public onNameResourceChanged(event): void {
        if (event != null) {
            //if (this._PatientInterviewForm != null &&
            //    this._PatientInterviewForm.Episode != null &&
            //    this._PatientInterviewForm.Episode.Room != null && this._PatientInterviewForm.Episode.Room.Name != event) {
            //    this._PatientInterviewForm.Episode.Room.Name = event;
            //}
        }
    }

    public onSurnamePersonChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.Episode != null &&
                this._PatientInterviewForm.Episode.Patient != null && this._PatientInterviewForm.Episode.Patient.Surname != event) {
                this._PatientInterviewForm.Episode.Patient.Surname = event;
            }
        }
    }

    public onUniqueRefNoPersonChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.Episode != null &&
                this._PatientInterviewForm.Episode.Patient != null && this._PatientInterviewForm.Episode.Patient.UniqueRefNo != event) {
                this._PatientInterviewForm.Episode.Patient.UniqueRefNo = event;
            }
        }
    }

    public onPatientLivesWithSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.PatientLivesWith != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.PatientLivesWith = event;
            }
        }
    }

    public onEmploymentRecordIdSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.EmploymentRecordId != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.EmploymentRecordId = event;
            }
        }
    }

    public onNamePayerDefinitionChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.Episode != null &&
                this._PatientInterviewForm.Episode.Payer != null && this._PatientInterviewForm.Episode.Payer.Name != event) {
                this._PatientInterviewForm.Episode.Payer.Name = event;
            }
        }
    }

    public onCompanionPhoneNumSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.CompanionPhoneNum != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.CompanionPhoneNum = event;
            }
        }
    }

    public onCompanionSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.Companion != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.Companion = event;
            }
        }
    }

    public onApplicationDateSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.ApplicationDate != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.ApplicationDate = event;
            }
        }
    }

    public onAuxiliaryToolAfoSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.AuxiliaryToolAfo != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.AuxiliaryToolAfo = event;
            }
        }
    }

    public onAuxiliaryToolArmRestSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.AuxiliaryToolArmRest != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.AuxiliaryToolArmRest = event;
            }
        }
    }

    public onAuxiliaryToolHandSplintSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.AuxiliaryToolHandSplint != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.AuxiliaryToolHandSplint = event;
            }
        }
    }

    public onAuxiliaryToolOtherInfoSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.AuxiliaryToolOtherInfo != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.AuxiliaryToolOtherInfo = event;
            }
        }
    }

    public onAuxiliaryToolOtherSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.AuxiliaryToolOther != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.AuxiliaryToolOther = event;
            }
            if (event == 1) {
                this.AuxiliaryToolOtherInfoSocServPatientFamilyInfo.Visible = true;
            } else {
                this.AuxiliaryToolOtherInfoSocServPatientFamilyInfo.Visible = false;
            }
        }
    }

    public onAuxiliaryToolTripodSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.AuxiliaryToolTripod != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.AuxiliaryToolTripod = event;
            }
        }
    }

    public onAuxiliaryToolWalkerSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.AuxiliaryToolWalker != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.AuxiliaryToolWalker = event;
            }
        }
    }

    public onAuxiliaryToolWheelchairSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.AuxiliaryToolWheelchair != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.AuxiliaryToolWheelchair = event;
            }
        }
    }

    public onDateOfRetireSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.DateOfRetire != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.DateOfRetire = event;
            }
        }
    }

    public onDateOfStartSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.DateOfStart != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.DateOfStart = event;
            }
        }
    }

    public onEvaluationSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.Evaluation != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.Evaluation = event;
            }
        }
    }

    public onExactTransactionDateSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.ExactTransactionDate != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.ExactTransactionDate = event;
            }
        }
    }

    public onJobMilitaryServStartDateSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.JobMilitaryServStartDate != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.JobMilitaryServStartDate = event;
            }
        }
    }

    public onJobRightUseStatusSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.JobRightUseStatus != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.JobRightUseStatus = event;
            }
        }
    }

    public onLivingHouseBasementSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.LivingHouseBasement != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.LivingHouseBasement = event;
            }
        }
    }



    public onLivingHouseElevatorSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.LivingHouseElevator != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.LivingHouseElevator = event;
            }
        }
    }

    public onLivingHouseEntranceSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.LivingHouseEntrance != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.LivingHouseEntrance = event;
            }
        }
    }



    public onLivingHouseNumOfFloorSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.LivingHouseNumOfFloor != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.LivingHouseNumOfFloor = event;
            }
        }
    }



    public onLivingHouseTypeSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.LivingHouseType != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.LivingHouseType = event;
            }
        }
    }

    public onLongTermArmBonusInterruptSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.LongTermArmBonusInterrupt != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.LongTermArmBonusInterrupt = event;
            }
        }
    }

    public onMilitaryServiceEndDateSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.MilitaryServiceEndDate != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.MilitaryServiceEndDate = event;
            }
        }
    }

    public onPreviousJobBeforeIllSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.PreviousJobBeforeIll != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.PreviousJobBeforeIll = event;
            }
        }
    }

    public onRecruitmentOfficeSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.RecruitmentOffice != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.RecruitmentOffice = event;
            }
        }
    }

    public onRestStateSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.RestState != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.RestState = event;
            }
        }
    }

    public onSecondRetirementStatusSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.SecondRetirementStatus != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.SecondRetirementStatus = event;
            }
        }
    }

    public onDegreeOfWarVeteranSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.DegreeOfWarVeteran != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.DegreeOfWarVeteran = event.selectedItem;
            }
        }
    }
    
    public onShortEventStorySocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.ShortEventStory != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.ShortEventStory = event;
            }
        }
    }

    public onSickOrInjuredPlaceSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.SickOrInjuredPlace != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.SickOrInjuredPlace = event;
            }
        }
    }

    public onSickOrInjuryDateSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.SickOrInjuryDate != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.SickOrInjuryDate = event;
            }
        }
    }

    public onSickOrInjuryTypeSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.SickOrInjuryType != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.SickOrInjuryType = event;
            }
        }
    }

    public onSoldierPlaceOfWorkSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.SoldierPlaceOfWork != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.SoldierPlaceOfWork = event;
            }
        }
    }

    public onSoldierRankSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.SoldierRank != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.SoldierRank = event;
            }
        }
    }


    public onWorkPlaceSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.WorkPlace != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.WorkPlace = event;
            }
        }
    }

    public onWrittenMedicalMaterialOrToolSocServPatientFamilyInfoChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null &&
                this._PatientInterviewForm.SocServPatientFamilyInfo != null && this._PatientInterviewForm.SocServPatientFamilyInfo.WrittenMedicalMaterialOrTool != event) {
                this._PatientInterviewForm.SocServPatientFamilyInfo.WrittenMedicalMaterialOrTool = event;
            }
        }
    }


    /**/
    public onEducationStatusChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.EducationStatus != event) {
                this._PatientInterviewForm.EducationStatus = event;
            }
        }
    }

    public onEvaluationChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.Evaluation != event) {
                this._PatientInterviewForm.Evaluation = event;
            }
        }
    }

    public onExaminationDateChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.ExaminationDate != event) {
                this._PatientInterviewForm.ExaminationDate = event;
            }
        }
    }

    public onGoodsAndMoneyHelpChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.GoodsAndMoneyHelp != event) {
                this._PatientInterviewForm.GoodsAndMoneyHelp = event;
            }
        }
    }

    public onGroupStudyWithPatientFamilyChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.GroupStudyWithPatientFamily != event) {
                this._PatientInterviewForm.GroupStudyWithPatientFamily = event;
            }
        }
    }

    public onHomeOrOrganizationVisitChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.HomeOrOrganizationVisit != event) {
                this._PatientInterviewForm.HomeOrOrganizationVisit = event;
            }
        }
    }

    public onInstutionalCarePlacementChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.InstutionalCarePlacement != event) {
                this._PatientInterviewForm.InstutionalCarePlacement = event;
            }
        }
    }

    public onInterviewedContactsChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.InterviewedContacts != event) {
                this._PatientInterviewForm.InterviewedContacts = event;
            }
        }
    }

    public onInterviewPlaceChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.InterviewPlace != event) {
                this._PatientInterviewForm.InterviewPlace = event;
            }
        }
    }

    public onMasterResourceChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.MasterResource != event) {
                this._PatientInterviewForm.MasterResource = event;
            }
        }
    }

    public onMeetingReasonChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.MeetingReason != event) {
                this._PatientInterviewForm.MeetingReason = event;
            }
        }
    }

    public onOtherVocationalInterventionsChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.OtherVocationalInterventions != event) {
                this._PatientInterviewForm.OtherVocationalInterventions = event;
            }
        }
    }

    public onPatientAccomodationEconomicConChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.PatientAccomodationEcoCon != event) {
                this._PatientInterviewForm.PatientAccomodationEcoCon = event;
            }
        }
    }

    public onPatientEducationAndWorkStudyChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.PatientEducationAndWorkStudy != event) {
                this._PatientInterviewForm.PatientEducationAndWorkStudy = event;
            }
        }
    }

    public onPatientHealthPhysicalCondChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.PatientHealthPhysicalCond != event) {
                this._PatientInterviewForm.PatientHealthPhysicalCond = event;
            }
        }
    }

    public onPatientJobChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.PatientJob != event) {
                this._PatientInterviewForm.PatientJob = event;
            }
        }
    }

    public onPatientPsychosocialFamilyCondChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.PatientPsychosocialFamilyCond != event) {
                this._PatientInterviewForm.PatientPsychosocialFamilyCond = event;
            }
        }
    }

    public onPatientsGroupStudyChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.PatientsGroupStudy != event) {
                this._PatientInterviewForm.PatientsGroupStudy = event;
            }
        }
    }

    public onPatientTransfererviceChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.PatientTransferervice != event) {
                this._PatientInterviewForm.PatientTransferervice = event;
            }
        }
    }

    public onPatientTypeChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.PatientType != event) {
                this._PatientInterviewForm.PatientType = event;
            }
        }
    }

    public onPlacementInTemporarySheltersChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.PlacementInTemporaryShelters != event) {
                this._PatientInterviewForm.PlacementInTemporaryShelters = event;
            }
        }
    }

    public onProblemDefinitionChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.ProblemDefinition != event) {
                this._PatientInterviewForm.ProblemDefinition = event;
            }
        }
    }

    public onProcedureByUserChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.ProcedureByUser != event) {
                this._PatientInterviewForm.ProcedureByUser = event;
            }
        }
    }

    public onPsychosocialEduPatientFamilyChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.PsychosocialEduPatientFamily != event) {
                this._PatientInterviewForm.PsychosocialEduPatientFamily = event;
            }
        }
    }

    public onPsychosocialStudyPatFamilyChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.PsychosocialStudyPatFamily != event) {
                this._PatientInterviewForm.PsychosocialStudyPatFamily = event;
            }
        }
    }

    public onPsychosocialStudyWithPatientChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.PsychosocialStudyWithPatient != event) {
                this._PatientInterviewForm.PsychosocialStudyWithPatient = event;
            }
        }
    }

    public onResultsAndRecommendationsChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.ResultsAndRecommendations != event) {
                this._PatientInterviewForm.ResultsAndRecommendations = event;
            }
        }
    }

    public onSchoolVisitChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SchoolVisit != event) {
                this._PatientInterviewForm.SchoolVisit = event;
            }
        }
    }

    public onSocialActivityChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocialActivity != event) {
                this._PatientInterviewForm.SocialActivity = event;
            }
        }
    }



    public onSocialReviewAndEvolutionChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.SocialReviewAndEvolution != event) {
                this._PatientInterviewForm.SocialReviewAndEvolution = event;
            }
        }
    }

    public onTreatmentExpenseResourceRouteChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.TreatmentExpenseResourceRoute != event) {
                this._PatientInterviewForm.TreatmentExpenseResourceRoute = event;
            }
        }
    }

    public onTypeOfServiceChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.TypeOfService != event) {
                this._PatientInterviewForm.TypeOfService = event;
            }
        }
    }

    public onWorkplaceVisitChanged(event): void {
        if (event != null) {
            if (this._PatientInterviewForm != null && this._PatientInterviewForm.WorkplaceVisit != event) {
                this._PatientInterviewForm.WorkplaceVisit = event;
            }
        }
    }




    /*       @ViewChild('Evaluation') EvaluationAccordion: DxAccordionComponent;
           @ViewChild('InterviewPlace') InterviewPlaceAccordion: DxAccordionComponent;
           @ViewChild('ProblemDefinition') ProblemDefinitionAccordion: DxAccordionComponent;
           @ViewChild('HealthPhysicalCond') HealthPhysicalCondAccordion: DxAccordionComponent;
           @ViewChild('PatientAccomEconCon') PatientAccomEconConAccordion: DxAccordionComponent;
           @ViewChild('InterviewedContacts') InterviewedContactsAccordion: DxAccordionComponent;
           @ViewChild('MeetingReason') MeetingReasonAccordion: DxAccordionComponent;
           @ViewChild('PatientPsychoFamilyCond') PatientPsychoFamilyCondAccordion: DxAccordionComponent;
           @ViewChild('ResultsAndRecommendations') ResultsAndRecommendationsAccordion: DxAccordionComponent;
           
   
       ngAfterViewInit(){
           this.EvaluationAccordion.instance.collapseItem(0);
           this.InterviewPlaceAccordion.instance.collapseItem(0);
           this.ProblemDefinitionAccordion.instance.collapseItem(0);
           this.HealthPhysicalCondAccordion.instance.collapseItem(0);
           this.PatientAccomEconConAccordion.instance.collapseItem(0);
           this.InterviewedContactsAccordion.instance.collapseItem(0);
           this.MeetingReasonAccordion.instance.collapseItem(0);
           this.PatientPsychoFamilyCondAccordion.instance.collapseItem(0);
           this.ResultsAndRecommendationsAccordion.instance.collapseItem(0);
   
       }
   */
    protected redirectProperties(): void {
        redirectProperty(this.ExaminationDate, "Value", this.__ttObject, "ExaminationDate");
        redirectProperty(this.TypeOfService, "Value", this.__ttObject, "TypeOfService");
        redirectProperty(this.PatientType, "Value", this.__ttObject, "PatientType");
        redirectProperty(this.InterviewPlace, "Rtf", this.__ttObject, "InterviewPlace");
        redirectProperty(this.InterviewedContacts, "Rtf", this.__ttObject, "InterviewedContacts");
        redirectProperty(this.PsychosocialStudyWithPatient, "Value", this.__ttObject, "PsychosocialStudyWithPatient");
        redirectProperty(this.PsychosocialStudyPatFamily, "Value", this.__ttObject, "PsychosocialStudyPatFamily");
        redirectProperty(this.SocialReviewAndEvolution, "Value", this.__ttObject, "SocialReviewAndEvolution");
        redirectProperty(this.HomeOrOrganizationVisit, "Value", this.__ttObject, "HomeOrOrganizationVisit");
        redirectProperty(this.WorkplaceVisit, "Value", this.__ttObject, "WorkplaceVisit");
        redirectProperty(this.SchoolVisit, "Value", this.__ttObject, "SchoolVisit");
        redirectProperty(this.InstutionalCarePlacement, "Value", this.__ttObject, "InstutionalCarePlacement");
        redirectProperty(this.PlacementInTemporaryShelters, "Value", this.__ttObject, "PlacementInTemporaryShelters");
        redirectProperty(this.GoodsAndMoneyHelp, "Value", this.__ttObject, "GoodsAndMoneyHelp");
        redirectProperty(this.PatientsGroupStudy, "Value", this.__ttObject, "PatientsGroupStudy");
        redirectProperty(this.GroupStudyWithPatientFamily, "Value", this.__ttObject, "GroupStudyWithPatientFamily");
        redirectProperty(this.PatientEducationAndWorkStudy, "Value", this.__ttObject, "PatientEducationAndWorkStudy");
        redirectProperty(this.PatientTransferervice, "Value", this.__ttObject, "PatientTransferervice");
        redirectProperty(this.PsychosocialEduPatientFamily, "Value", this.__ttObject, "PsychosocialEduPatientFamily");
        redirectProperty(this.SocialActivity, "Value", this.__ttObject, "SocialActivity");
        redirectProperty(this.OtherVocationalInterventions, "Value", this.__ttObject, "OtherVocationalInterventions");
        redirectProperty(this.TreatmentExpenseResourceRoute, "Value", this.__ttObject, "TreatmentExpenseResourceRoute");
        redirectProperty(this.ProblemDefinition, "Rtf", this.__ttObject, "ProblemDefinition");
        redirectProperty(this.MeetingReason, "Rtf", this.__ttObject, "MeetingReason");
        redirectProperty(this.PatientHealthPhysicalCond, "Rtf", this.__ttObject, "PatientHealthPhysicalCond");
        redirectProperty(this.PatientPsychosocialFamilyCond, "Rtf", this.__ttObject, "PatientPsychosocialFamilyCond");
        redirectProperty(this.PatientAccomodationEconomicCon, "Rtf", this.__ttObject, "PatientAccomodationEcoCon");
        redirectProperty(this.Evaluation, "Rtf", this.__ttObject, "Evaluation");
        redirectProperty(this.ResultsAndRecommendations, "Rtf", this.__ttObject, "ResultsAndRecommendations");
        /*SocServAppliedProcedures*/
        redirectProperty(this.ProvidingAccomodation, "Value", this.__ttObject, "SocServAppliedProcedures.ProvidingAccomodation");
        redirectProperty(this.ProvideInternalSecInjStatDoc, "Value", this.__ttObject, "SocServAppliedProcedures.ProvideInternalSecInjStatDoc");
        redirectProperty(this.ProvisionIssues, "Value", this.__ttObject, "SocServAppliedProcedures.ProvisionIssues");
        redirectProperty(this.WeeklyVisitAttendence, "Value", this.__ttObject, "SocServAppliedProcedures.WeeklyVisitAttendence");
        redirectProperty(this.InformAndDirectRetireProc, "Value", this.__ttObject, "SocServAppliedProcedures.InformAndDirectRetireProc");
        redirectProperty(this.MedicEqProcRefundInfoProcure, "Value", this.__ttObject, "SocServAppliedProcedures.MedicEqProcRefundInfoProcure");
        redirectProperty(this.DonatedMedicalSupplyProcure, "Value", this.__ttObject, "SocServAppliedProcedures.DonatedMedicalSupplyProcure");
        redirectProperty(this.GuidanceOnDrugSupplyAbroad, "Value", this.__ttObject, "SocServAppliedProcedures.GuidanceOnDrugSupplyAbroad");
        redirectProperty(this.VocationalRehabilitation, "Value", this.__ttObject, "SocServAppliedProcedures.VocationalRehabilitation");
        redirectProperty(this.GuidanceToCivilOrganizations, "Value", this.__ttObject, "SocServAppliedProcedures.GuidanceToCivilOrganizations");
        redirectProperty(this.BenefitingFromDonations, "Value", this.__ttObject, "SocServAppliedProcedures.BenefitingFromDonations");
        redirectProperty(this.GuidanceAboutLaw, "Value", this.__ttObject, "SocServAppliedProcedures.GuidanceAboutLaw");
        redirectProperty(this.GuidanceAboutHomeHealthCare, "Value", this.__ttObject, "SocServAppliedProcedures.GuidanceAboutHomeHealthCare");
        redirectProperty(this.GuidanceToPublicInstitution, "Value", this.__ttObject, "SocServAppliedProcedures.GuidanceToPublicInstitution");
        redirectProperty(this.CoordWarVeteranContactUnit, "Value", this.__ttObject, "SocServAppliedProcedures.CoordWarVeteranContactUnit");
        redirectProperty(this.ArrangementOfWorkSchoolEnv, "Value", this.__ttObject, "SocServAppliedProcedures.ArrangementOfWorkSchoolEnv");
        redirectProperty(this.InterCityTransportProcesses, "Value", this.__ttObject, "SocServAppliedProcedures.InterCityTransportProcesses");
        redirectProperty(this.OrganizingPermitDocuments, "Value", this.__ttObject, "SocServAppliedProcedures.OrganizingPermitDocuments");
        redirectProperty(this.AdvancePayment, "Value", this.__ttObject, "SocServAppliedProcedures.AdvancePayment");
        redirectProperty(this.IndemnityCompensation, "Value", this.__ttObject, "SocServAppliedProcedures.IndemnityCompensation");
        redirectProperty(this.AllowancePayment, "Value", this.__ttObject, "SocServAppliedProcedures.AllowancePayment");
        redirectProperty(this.GivingVeteranRightsBrochure, "Value", this.__ttObject, "SocServAppliedProcedures.GivingVeteranRightsBrochure");
        redirectProperty(this.LegislativeReviewAndInfo, "Value", this.__ttObject, "SocServAppliedProcedures.LegislativeReviewAndInfo");
        redirectProperty(this.CashIdemnityTransactions, "Value", this.__ttObject, "SocServAppliedProcedures.CashIdemnityTransactions");
        redirectProperty(this.XXXXXXSolidarityFoundationAid, "Value", this.__ttObject, "SocServAppliedProcedures.XXXXXXSolidarityFoundationAid");
        redirectProperty(this.SoldierFoundationAid, "Value", this.__ttObject, "SocServAppliedProcedures.SoldierFoundationAid");
        redirectProperty(this.SoldierLifeInsurance, "Value", this.__ttObject, "SocServAppliedProcedures.SoldierLifeInsurance");
        redirectProperty(this.OYAKAid, "Value", this.__ttObject, "SocServAppliedProcedures.OYAKAid");
        redirectProperty(this.JobResumeStatus, "Value", this.__ttObject, "SocServAppliedProcedures.JobResumeStatus");
        redirectProperty(this.StatePrideMedal, "Value", this.__ttObject, "SocServAppliedProcedures.StatePrideMedal");
        redirectProperty(this.SalaryStartBySGK, "Value", this.__ttObject, "SocServAppliedProcedures.SalaryStartBySGK");
        redirectProperty(this.RetirementBonusBySGK, "Value", this.__ttObject, "SocServAppliedProcedures.RetirementBonusBySGK");
        redirectProperty(this.SupplementaryPaymentSGK, "Value", this.__ttObject, "SocServAppliedProcedures.SupplementaryPaymentSGK");
        redirectProperty(this.EducationAidBySGK, "Value", this.__ttObject, "SocServAppliedProcedures.EducationAidBySGK");
        redirectProperty(this.GrantingEmploymentRights, "Value", this.__ttObject, "SocServAppliedProcedures.GrantingEmploymentRights");
        redirectProperty(this.ProvidingWarVeteranCard, "Value", this.__ttObject, "SocServAppliedProcedures.ProvidingWarVeteranCard");
        redirectProperty(this.UtilizationOfPublicHousing, "Value", this.__ttObject, "SocServAppliedProcedures.UtilizationOfPublicHousing");
        redirectProperty(this.ProvideHouseToDisabledStaff, "Value", this.__ttObject, "SocServAppliedProcedures.ProvideHouseToDisabledStaff");
        redirectProperty(this.GivingCorporateHousingCredit, "Value", this.__ttObject, "SocServAppliedProcedures.GivingCorporateHousingCredit");
        redirectProperty(this.UsageRightFromTOKIHouses, "Value", this.__ttObject, "SocServAppliedProcedures.UsageRightFromTOKIHouses");
        redirectProperty(this.IncomeTaxDiscount, "Value", this.__ttObject, "SocServAppliedProcedures.IncomeTaxDiscount");
        redirectProperty(this.ResidenceTaxExemption, "Value", this.__ttObject, "SocServAppliedProcedures.ResidenceTaxExemption");
        redirectProperty(this.ElectricAndWaterDiscount, "Value", this.__ttObject, "SocServAppliedProcedures.ElectricAndWaterDiscount");
        redirectProperty(this.ImportingDutyFreeVehicle, "Value", this.__ttObject, "SocServAppliedProcedures.ImportingDutyFreeVehicle");
        redirectProperty(this.DomesticVehiclePurchases, "Value", this.__ttObject, "SocServAppliedProcedures.DomesticVehiclePurchases");
        redirectProperty(this.OTVandMTVExemption, "Value", this.__ttObject, "SocServAppliedProcedures.OTVandMTVExemption");
        redirectProperty(this.BrotherExemptionFromMilitary, "Value", this.__ttObject, "SocServAppliedProcedures.BrotherExemptionFromMilitary");
        redirectProperty(this.MilitaryServiceNearBrotherHom, "Value", this.__ttObject, "SocServAppliedProcedures.MilitaryServiceNearBrotherHom");
        redirectProperty(this.FreeAccessToPrivateEduInstit, "Value", this.__ttObject, "SocServAppliedProcedures.FreeAccessToPrivateEduInstit");
        redirectProperty(this.WeaponPortageTransportLicense, "Value", this.__ttObject, "SocServAppliedProcedures.WeaponPortageTransportLicense");
        redirectProperty(this.UtilityFromRehabilitationCent, "Value", this.__ttObject, "SocServAppliedProcedures.UtilityFromRehabilitationCent");
        redirectProperty(this.GrantingDealership, "Value", this.__ttObject, "SocServAppliedProcedures.GrantingDealership");
        redirectProperty(this.WeeklyTeamMeetings, "Value", this.__ttObject, "SocServAppliedProcedures.WeeklyTeamMeetings");
        redirectProperty(this.CalcAndFollowRestProc, "Value", this.__ttObject, "SocServAppliedProcedures.CalcAndFollowRestProc");
        redirectProperty(this.GuidanceToFoundations, "Value", this.__ttObject, "SocServAppliedProcedures.GuidanceToFoundations");
        redirectProperty(this.GuidanceAboutCareSalary, "Value", this.__ttObject, "SocServAppliedProcedures.GuidanceAboutCareSalary");
        redirectProperty(this.PhoneCallWitPublicInstitution, "Value", this.__ttObject, "SocServAppliedProcedures.PhoneCallWitPublicInstitution");
        redirectProperty(this.ArrangementOfLivingPlaces, "Value", this.__ttObject, "SocServAppliedProcedures.ArrangementOfLivingPlaces");
        redirectProperty(this.IntraCityTransportProcesses, "Value", this.__ttObject, "SocServAppliedProcedures.IntraCityTransportProcesses");
        redirectProperty(this.GuidanceServiceOnPhone, "Text", this.__ttObject, "SocServAppliedProcedures.GuidanceServiceOnPhone");
        redirectProperty(this.IdentificationOfParticipants, "Value", this.__ttObject, "SocServAppliedProcedures.IdentificationOfParticipants");
        redirectProperty(this.OpenEducationHighSchool, "Text", this.__ttObject, "SocServAppliedProcedures.OpenEducationHighSchool");
        redirectProperty(this.HealthAid, "Value", this.__ttObject, "SocServAppliedProcedures.HealthAid");
        redirectProperty(this.Other, "Text", this.__ttObject, "SocServAppliedProcedures.Other");
        redirectProperty(this.ProvidingAccomodationInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.ProvidingAccomodationInfo");
        redirectProperty(this.ProvideInterSecInjStatDocInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.ProvideInterSecInjStatDocInfo");
        redirectProperty(this.ProvisionIssuesInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.ProvisionIssuesInfo");
        redirectProperty(this.CashIdemnityTransactionsInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.CashIdemnityTransactionsInfo");
        redirectProperty(this.XXXXXXSolidarityFoundatioAidInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.XXXXXXSolidarityFoundatioAidInfo");
        redirectProperty(this.SoldierFoundationAidInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.SoldierFoundationAidInfo");
        redirectProperty(this.SoldierLifeInsuranceInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.SoldierLifeInsuranceInfo");
        redirectProperty(this.OYAKAidInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.OYAKAidInfo");
        redirectProperty(this.JobResumeStatusInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.JobResumeStatusInfo");
        redirectProperty(this.StatePrideMedalInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.StatePrideMedalInfo");
        redirectProperty(this.SalaryStartBySGKInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.SalaryStartBySGKInfo");
        redirectProperty(this.RetirementBonusBySGKInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.RetirementBonusBySGKInfo");
        redirectProperty(this.SupplementaryPaymentSGKInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.SupplementaryPaymentSGKInfo");
        redirectProperty(this.EducationAidBySGKInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.EducationAidBySGKInfo");
        redirectProperty(this.GrantingEmploymentRightsInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.GrantingEmploymentRightsInfo");
        redirectProperty(this.ProvidingWarVeteranCardInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.ProvidingWarVeteranCardInfo");
        redirectProperty(this.UtilizationOfPublicHousinInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.UtilizationOfPublicHousinInfo");
        redirectProperty(this.ProvideHouseToDisablStaffInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.ProvideHouseToDisablStaffInfo");
        redirectProperty(this.GivingCorporateHousCreditInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.GivingCorporateHousCreditInfo");
        redirectProperty(this.UsageRightFromTOKIHousesInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.UsageRightFromTOKIHousesInfo");
        redirectProperty(this.IncomeTaxDiscountInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.IncomeTaxDiscountInfo");
        redirectProperty(this.ResidenceTaxExemptionInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.ResidenceTaxExemptionInfo");
        redirectProperty(this.ElectricAndWaterDiscountInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.ElectricAndWaterDiscountInfo");
        redirectProperty(this.ImportingDutyFreeVehicleInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.ImportingDutyFreeVehicleInfo");
        redirectProperty(this.DomesticVehiclePurchasesInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.DomesticVehiclePurchasesInfo");
        redirectProperty(this.OTVandMTVExemptionInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.OTVandMTVExemptionInfo");
        redirectProperty(this.BrotherExemptionFromMilitInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.BrotherExemptionFromMilitInfo");
        redirectProperty(this.MilitarServNearBrotherHomInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.MilitarServNearBrotherHomInfo");
        redirectProperty(this.FreeAccessToPrivEduInstitInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.FreeAccessToPrivEduInstitInfo");
        redirectProperty(this.WeaponPortageTransportLicInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.WeaponPortageTransportLicInfo");
        redirectProperty(this.UtilityFromRehabilitCentInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.UtilityFromRehabilitCentInfo");
        redirectProperty(this.GrantingDealershipInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.GrantingDealershipInfo");
        redirectProperty(this.WeeklyTeamMeetingsInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.WeeklyTeamMeetingsInfo");
        redirectProperty(this.WeeklyVisitAttendenceInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.WeeklyVisitAttendenceInfo");
        redirectProperty(this.CalcAndFollowRestProcInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.CalcAndFollowRestProcInfo");
        redirectProperty(this.InformAndDirectRetireProcInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.InformAndDirectRetireProcInfo");
        redirectProperty(this.MedicEqProcRefundInfoProcInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.MedicEqProcRefundInfoProcInfo");
        redirectProperty(this.DonatedMedicalSupplyProcInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.DonatedMedicalSupplyProcInfo");
        redirectProperty(this.GuidanceDrugSupplyAbroadInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.GuidanceDrugSupplyAbroadInfo");
        redirectProperty(this.VocationalRehabilitationInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.VocationalRehabilitationInfo");
        redirectProperty(this.GuidanceToFoundationsInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.GuidanceToFoundationsInfo");
        redirectProperty(this.GuidanceToCivilOrganizatInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.GuidanceToCivilOrganizatInfo");
        redirectProperty(this.BenefitingFromDonationsInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.BenefitingFromDonationsInfo");
        redirectProperty(this.GuidanceAboutCareSalaryInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.GuidanceAboutCareSalaryInfo");
        redirectProperty(this.GuidanceAboutLawInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.GuidanceAboutLawInfo");
        redirectProperty(this.GuidanceAboutHomeHealthCrInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.GuidanceAboutHomeHealthCrInfo");
        redirectProperty(this.PhoneCallWitPublicInstitInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.PhoneCallWitPublicInstitInfo");
        redirectProperty(this.LegislativeReviewAndInfoInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.LegislativeReviewAndInfoInfo");
        redirectProperty(this.GuidanceToPublicInstitInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.GuidanceToPublicInstitInfo");
        redirectProperty(this.CoordWarVeteranContactUniInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.CoordWarVeteranContactUniInfo");
        redirectProperty(this.ArrangementOfLivingPlacesInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.ArrangementOfLivingPlacesInfo");
        redirectProperty(this.ArrangementOfWorkSchoolEnInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.ArrangementOfWorkSchoolEnInfo");
        redirectProperty(this.IntraCityTransportProcessInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.IntraCityTransportProcessInfo");
        redirectProperty(this.InterCityTransportProcessInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.InterCityTransportProcessInfo");
        redirectProperty(this.IdentificationOfParticipInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.IdentificationOfParticipInfo");
        redirectProperty(this.OrganizingPermitDocumentsInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.OrganizingPermitDocumentsInfo");
        redirectProperty(this.HealthAidInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.HealthAidInfo");
        redirectProperty(this.AdvancePaymentInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.AdvancePaymentInfo");
        redirectProperty(this.IndemnityCompensationInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.IndemnityCompensationInfo");
        redirectProperty(this.AllowancePaymentInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.AllowancePaymentInfo");
        redirectProperty(this.GivingVeteranRightsBrocInfoSocServAppliedProcedures, "Text", this.__ttObject, "SocServAppliedProcedures.GivingVeteranRightsBrocInfo");



        /*SocServPatientFamilyInfo*/
        redirectProperty(this.ApplicationDateSocServPatientFamilyInfo, "Value", this.__ttObject, "SocServPatientFamilyInfo.ApplicationDate");
        redirectProperty(this.NamePerson, "Text", this.__ttObject, "Episode.Patient.Name");
        redirectProperty(this.SurnamePerson, "Text", this.__ttObject, "Episode.Patient.Surname");
        redirectProperty(this.BirthDatePerson, "Value", this.__ttObject, "Episode.Patient.BirthDate");
        redirectProperty(this.MotherNamePerson, "Text", this.__ttObject, "Episode.Patient.MotherName");
        redirectProperty(this.FatherNamePerson, "Text", this.__ttObject, "Episode.Patient.FatherName");
        //redirectProperty(this.MaritalStatusPerson, "Value", this.__ttObject, "Episode.Patient.MaritalStatus");
        redirectProperty(this.UniqueRefNoPerson, "Text", this.__ttObject, "Episode.Patient.UniqueRefNo");
        redirectProperty(this.HomeAddressPatientIdentityAndAddress, "Text", this.__ttObject, "PatientAddress");
        redirectProperty(this.MobilePhonePerson, "Text", this.__ttObject, "PatientPhoneNum");
        redirectProperty(this.LivingHouseDoorEntranceSocServPatientFamilyInfo, "Value", this.__ttObject, "SocServPatientFamilyInfo.LivingHouseDoorEntrance");

        redirectProperty(this.CompanionSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.Companion");
        redirectProperty(this.CompanionPhoneNumSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.CompanionPhoneNum");
        redirectProperty(this.EmploymentRecordIdSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.EmploymentRecordId");
        redirectProperty(this.NamePayerDefinition, "Text", this.__ttObject, "Episode.Payer.Name");
        redirectProperty(this.PatientLivesWithSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.PatientLivesWith");


        redirectProperty(this.LivingHouseOtherInfoSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.LivingHouseOtherInfo");
        redirectProperty(this.LivingHouseTypeSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.LivingHouseType");
        redirectProperty(this.LivingHouseNumOfFloorSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.LivingHouseNumOfFloor");
        redirectProperty(this.LivingHouseElevatorSocServPatientFamilyInfo, "Value", this.__ttObject, "SocServPatientFamilyInfo.LivingHouseElevator");
        redirectProperty(this.LivingHouseBasementSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.LivingHouseBasement");
        redirectProperty(this.LivingHouseEntranceSocServPatientFamilyInfo, "Value", this.__ttObject, "SocServPatientFamilyInfo.LivingHouseEntrance");
        redirectProperty(this.SocioEconomicInfoEvaluationSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.SocioEconomicInfoEvaluation");
        redirectProperty(this.TransportationArrivalSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.TransportationArrival");
        redirectProperty(this.TransportationEvaluationSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.TransportationEvaluation");
        redirectProperty(this.TransportationGoingSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.TransportationGoing");
        redirectProperty(this.PhysicalStatusSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.PhysicalStatus");
        redirectProperty(this.PatientRelatedWorksSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.PatientRelatedWorks");
        redirectProperty(this.SubHeadersSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.SubHeaders");
        redirectProperty(this.LivingHouseBelongingSocServPatientFamilyInfo, "Value", this.__ttObject, "SocServPatientFamilyInfo.LivingHouseBelonging");
        redirectProperty(this.LivingHouseBelongingInfoSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.LivingHouseBelongingInfo");
        redirectProperty(this.FamilyIncomingsSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.FamilyIncomings");
        redirectProperty(this.FamilyInformationSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.FamilyInformation");
        redirectProperty(this.FamilyInformationEvaluationSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.FamilyInformationEvaluation");
        redirectProperty(this.PatientDiagnosisSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.PatientDiagnosis");
        redirectProperty(this.PatientPayerNameSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.PatientPayerName");

        redirectProperty(this.WCTypeClosetSocServPatientFamilyInfo, "Value", this.__ttObject, "SocServPatientFamilyInfo.WCTypeCloset");
        redirectProperty(this.WCTypeNotClosetSocServPatientFamilyInfo, "Value", this.__ttObject, "SocServPatientFamilyInfo.WCTypeNotCloset");
        redirectProperty(this.SickOrInjuredPlaceSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.SickOrInjuredPlace");
        redirectProperty(this.SickOrInjuryTypeSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.SickOrInjuryType");
        redirectProperty(this.SickOrInjuryDateSocServPatientFamilyInfo, "Value", this.__ttObject, "SocServPatientFamilyInfo.SickOrInjuryDate");
        redirectProperty(this.ShortEventStorySocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.ShortEventStory");
        redirectProperty(this.SoldierRankSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.SoldierRank");
        redirectProperty(this.SoldierPlaceOfWorkSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.SoldierPlaceOfWork");
        redirectProperty(this.PreviousJobBeforeIllSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.PreviousJobBeforeIll");
        redirectProperty(this.DateOfStartSocServPatientFamilyInfo, "Value", this.__ttObject, "SocServPatientFamilyInfo.DateOfStart");
        redirectProperty(this.DateOfRetireSocServPatientFamilyInfo, "Value", this.__ttObject, "SocServPatientFamilyInfo.DateOfRetire");
        redirectProperty(this.JobRightUseStatusSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.JobRightUseStatus");
        redirectProperty(this.WorkPlaceSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.WorkPlace");
        redirectProperty(this.LongTermArmBonusInterruptSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.LongTermArmBonusInterrupt");
        redirectProperty(this.SecondRetirementStatusSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.SecondRetirementStatus");
        redirectProperty(this.EvaluationSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.Evaluation");
        redirectProperty(this.AuxiliaryToolWalkerSocServPatientFamilyInfo, "Value", this.__ttObject, "SocServPatientFamilyInfo.AuxiliaryToolWalker");
        redirectProperty(this.AuxiliaryToolAfoSocServPatientFamilyInfo, "Value", this.__ttObject, "SocServPatientFamilyInfo.AuxiliaryToolAfo");
        redirectProperty(this.AuxiliaryToolHandSplintSocServPatientFamilyInfo, "Value", this.__ttObject, "SocServPatientFamilyInfo.AuxiliaryToolHandSplint");
        redirectProperty(this.AuxiliaryToolTripodSocServPatientFamilyInfo, "Value", this.__ttObject, "SocServPatientFamilyInfo.AuxiliaryToolTripod");
        redirectProperty(this.AuxiliaryToolArmRestSocServPatientFamilyInfo, "Value", this.__ttObject, "SocServPatientFamilyInfo.AuxiliaryToolArmRest");
        redirectProperty(this.AuxiliaryToolOtherSocServPatientFamilyInfo, "Value", this.__ttObject, "SocServPatientFamilyInfo.AuxiliaryToolOther");
        redirectProperty(this.AuxiliaryToolWheelchairSocServPatientFamilyInfo, "Value", this.__ttObject, "SocServPatientFamilyInfo.AuxiliaryToolWheelchair");
        redirectProperty(this.AuxiliaryToolOtherInfoSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.AuxiliaryToolOtherInfo");
        redirectProperty(this.WrittenMedicalMaterialOrToolSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.WrittenMedicalMaterialOrTool");
        redirectProperty(this.RestStateSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.RestState");
        redirectProperty(this.JobMilitaryServStartDateSocServPatientFamilyInfo, "Value", this.__ttObject, "SocServPatientFamilyInfo.JobMilitaryServStartDate");
        redirectProperty(this.MilitaryServiceEndDateSocServPatientFamilyInfo, "Value", this.__ttObject, "SocServPatientFamilyInfo.MilitaryServiceEndDate");
        redirectProperty(this.RecruitmentOfficeSocServPatientFamilyInfo, "Text", this.__ttObject, "SocServPatientFamilyInfo.RecruitmentOffice");
        redirectProperty(this.ExactTransactionDateSocServPatientFamilyInfo, "Value", this.__ttObject, "SocServPatientFamilyInfo.ExactTransactionDate");
        redirectProperty(this.NameResource, "Text", this.__ttObject, "Episode.Room.Name");

    }

    public initFormControls(): void {

        /**/


        this.Other = new TTVisual.TTTextBox();
        this.Other.Multiline = true;
        this.Other.Name = "Other";
        this.Other.TabIndex = 86;
        this.Other.Height = '50px';

        this.OpenEducationHighSchool = new TTVisual.TTTextBox();
        this.OpenEducationHighSchool.Multiline = true;
        this.OpenEducationHighSchool.Name = "OpenEducationHighSchool";
        this.OpenEducationHighSchool.TabIndex = 84;
        this.OpenEducationHighSchool.Height = '50px';


        this.GuidanceServiceOnPhone = new TTVisual.TTTextBox();
        this.GuidanceServiceOnPhone.Multiline = true;
        this.GuidanceServiceOnPhone.Name = "GuidanceServiceOnPhone";
        this.GuidanceServiceOnPhone.TabIndex = 40;
        this.GuidanceServiceOnPhone.Height = '50px';




        this.GrantingDealershipInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.GrantingDealershipInfoSocServAppliedProcedures.Name = "GrantingDealershipInfoSocServAppliedProcedures";
        this.GrantingDealershipInfoSocServAppliedProcedures.TabIndex = 10;

        this.OTVandMTVExemptionInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.OTVandMTVExemptionInfoSocServAppliedProcedures.Name = "OTVandMTVExemptionInfoSocServAppliedProcedures";
        this.OTVandMTVExemptionInfoSocServAppliedProcedures.TabIndex = 20;

        this.GrantingEmploymentRightsInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.GrantingEmploymentRightsInfoSocServAppliedProcedures.Name = "GrantingEmploymentRightsInfoSocServAppliedProcedures";
        this.GrantingEmploymentRightsInfoSocServAppliedProcedures.TabIndex = 22;

        this.UtilityFromRehabilitCentInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.UtilityFromRehabilitCentInfoSocServAppliedProcedures.Name = "UtilityFromRehabilitCentInfoSocServAppliedProcedures";
        this.UtilityFromRehabilitCentInfoSocServAppliedProcedures.TabIndex = 8;

        this.BrotherExemptionFromMilitInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.BrotherExemptionFromMilitInfoSocServAppliedProcedures.Name = "BrotherExemptionFromMilitInfoSocServAppliedProcedures";
        this.BrotherExemptionFromMilitInfoSocServAppliedProcedures.TabIndex = 0;

        this.MilitarServNearBrotherHomInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.MilitarServNearBrotherHomInfoSocServAppliedProcedures.Name = "MilitarServNearBrotherHomInfoSocServAppliedProcedures";
        this.MilitarServNearBrotherHomInfoSocServAppliedProcedures.TabIndex = 2;

        this.WeaponPortageTransportLicInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.WeaponPortageTransportLicInfoSocServAppliedProcedures.Name = "WeaponPortageTransportLicInfoSocServAppliedProcedures";
        this.WeaponPortageTransportLicInfoSocServAppliedProcedures.TabIndex = 6;

        this.DomesticVehiclePurchasesInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.DomesticVehiclePurchasesInfoSocServAppliedProcedures.Name = "DomesticVehiclePurchasesInfoSocServAppliedProcedures";
        this.DomesticVehiclePurchasesInfoSocServAppliedProcedures.TabIndex = 18;

        this.FreeAccessToPrivEduInstitInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.FreeAccessToPrivEduInstitInfoSocServAppliedProcedures.Name = "FreeAccessToPrivEduInstitInfoSocServAppliedProcedures";
        this.FreeAccessToPrivEduInstitInfoSocServAppliedProcedures.TabIndex = 4;

        this.ProvidingWarVeteranCardInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.ProvidingWarVeteranCardInfoSocServAppliedProcedures.Name = "ProvidingWarVeteranCardInfoSocServAppliedProcedures";
        this.ProvidingWarVeteranCardInfoSocServAppliedProcedures.TabIndex = 0;

        this.UtilizationOfPublicHousinInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.UtilizationOfPublicHousinInfoSocServAppliedProcedures.Name = "UtilizationOfPublicHousinInfoSocServAppliedProcedures";
        this.UtilizationOfPublicHousinInfoSocServAppliedProcedures.TabIndex = 2;

        this.ImportingDutyFreeVehicleInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.ImportingDutyFreeVehicleInfoSocServAppliedProcedures.Name = "ImportingDutyFreeVehicleInfoSocServAppliedProcedures";
        this.ImportingDutyFreeVehicleInfoSocServAppliedProcedures.TabIndex = 16;

        this.EducationAidBySGKInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.EducationAidBySGKInfoSocServAppliedProcedures.Name = "EducationAidBySGKInfoSocServAppliedProcedures";
        this.EducationAidBySGKInfoSocServAppliedProcedures.TabIndex = 20;

        this.ProvideHouseToDisablStaffInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.ProvideHouseToDisablStaffInfoSocServAppliedProcedures.Name = "ProvideHouseToDisablStaffInfoSocServAppliedProcedures";
        this.ProvideHouseToDisablStaffInfoSocServAppliedProcedures.TabIndex = 4;

        this.CashIdemnityTransactionsInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.CashIdemnityTransactionsInfoSocServAppliedProcedures.Name = "CashIdemnityTransactionsInfoSocServAppliedProcedures";
        this.CashIdemnityTransactionsInfoSocServAppliedProcedures.TabIndex = 0;

        this.ElectricAndWaterDiscountInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.ElectricAndWaterDiscountInfoSocServAppliedProcedures.Name = "ElectricAndWaterDiscountInfoSocServAppliedProcedures";
        this.ElectricAndWaterDiscountInfoSocServAppliedProcedures.TabIndex = 14;

        this.XXXXXXSolidarityFoundatioAidInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.XXXXXXSolidarityFoundatioAidInfoSocServAppliedProcedures.Name = "XXXXXXSolidarityFoundatioAidInfoSocServAppliedProcedures";
        this.XXXXXXSolidarityFoundatioAidInfoSocServAppliedProcedures.TabIndex = 2;

        this.GivingCorporateHousCreditInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.GivingCorporateHousCreditInfoSocServAppliedProcedures.Name = "GivingCorporateHousCreditInfoSocServAppliedProcedures";
        this.GivingCorporateHousCreditInfoSocServAppliedProcedures.TabIndex = 6;

        this.ResidenceTaxExemptionInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.ResidenceTaxExemptionInfoSocServAppliedProcedures.Name = "ResidenceTaxExemptionInfoSocServAppliedProcedures";
        this.ResidenceTaxExemptionInfoSocServAppliedProcedures.TabIndex = 12;

        this.SupplementaryPaymentSGKInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.SupplementaryPaymentSGKInfoSocServAppliedProcedures.Name = "SupplementaryPaymentSGKInfoSocServAppliedProcedures";
        this.SupplementaryPaymentSGKInfoSocServAppliedProcedures.TabIndex = 18;

        this.UsageRightFromTOKIHousesInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.UsageRightFromTOKIHousesInfoSocServAppliedProcedures.Name = "UsageRightFromTOKIHousesInfoSocServAppliedProcedures";
        this.UsageRightFromTOKIHousesInfoSocServAppliedProcedures.TabIndex = 8;

        this.IncomeTaxDiscountInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.IncomeTaxDiscountInfoSocServAppliedProcedures.Name = "IncomeTaxDiscountInfoSocServAppliedProcedures";
        this.IncomeTaxDiscountInfoSocServAppliedProcedures.TabIndex = 10;

        this.SoldierFoundationAidInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.SoldierFoundationAidInfoSocServAppliedProcedures.Name = "SoldierFoundationAidInfoSocServAppliedProcedures";
        this.SoldierFoundationAidInfoSocServAppliedProcedures.TabIndex = 4;

        this.RetirementBonusBySGKInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.RetirementBonusBySGKInfoSocServAppliedProcedures.Name = "RetirementBonusBySGKInfoSocServAppliedProcedures";
        this.RetirementBonusBySGKInfoSocServAppliedProcedures.TabIndex = 16;

        this.SoldierLifeInsuranceInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.SoldierLifeInsuranceInfoSocServAppliedProcedures.Name = "SoldierLifeInsuranceInfoSocServAppliedProcedures";
        this.SoldierLifeInsuranceInfoSocServAppliedProcedures.TabIndex = 6;

        this.SalaryStartBySGKInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.SalaryStartBySGKInfoSocServAppliedProcedures.Name = "SalaryStartBySGKInfoSocServAppliedProcedures";
        this.SalaryStartBySGKInfoSocServAppliedProcedures.TabIndex = 14;

        this.StatePrideMedalInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.StatePrideMedalInfoSocServAppliedProcedures.Name = "StatePrideMedalInfoSocServAppliedProcedures";
        this.StatePrideMedalInfoSocServAppliedProcedures.TabIndex = 12;

        this.JobResumeStatusInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.JobResumeStatusInfoSocServAppliedProcedures.Name = "JobResumeStatusInfoSocServAppliedProcedures";
        this.JobResumeStatusInfoSocServAppliedProcedures.TabIndex = 10;

        this.GivingVeteranRightsBrocInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.GivingVeteranRightsBrocInfoSocServAppliedProcedures.Name = "GivingVeteranRightsBrocInfoSocServAppliedProcedures";
        this.GivingVeteranRightsBrocInfoSocServAppliedProcedures.TabIndex = 12;

        this.OYAKAidInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.OYAKAidInfoSocServAppliedProcedures.Name = "OYAKAidInfoSocServAppliedProcedures";
        this.OYAKAidInfoSocServAppliedProcedures.TabIndex = 8;

        this.AllowancePaymentInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.AllowancePaymentInfoSocServAppliedProcedures.Name = "AllowancePaymentInfoSocServAppliedProcedures";
        this.AllowancePaymentInfoSocServAppliedProcedures.TabIndex = 10;


        this.HealthAidInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.HealthAidInfoSocServAppliedProcedures.Name = "HealthAidInfoSocServAppliedProcedures";
        this.HealthAidInfoSocServAppliedProcedures.TabIndex = 4;

        this.AdvancePaymentInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.AdvancePaymentInfoSocServAppliedProcedures.Name = "AdvancePaymentInfoSocServAppliedProcedures";
        this.AdvancePaymentInfoSocServAppliedProcedures.TabIndex = 6;

        this.IndemnityCompensationInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.IndemnityCompensationInfoSocServAppliedProcedures.Name = "IndemnityCompensationInfoSocServAppliedProcedures";
        this.IndemnityCompensationInfoSocServAppliedProcedures.TabIndex = 8;

        this.IdentificationOfParticipInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.IdentificationOfParticipInfoSocServAppliedProcedures.Name = "IdentificationOfParticipInfoSocServAppliedProcedures";
        this.IdentificationOfParticipInfoSocServAppliedProcedures.TabIndex = 0;

        this.OrganizingPermitDocumentsInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.OrganizingPermitDocumentsInfoSocServAppliedProcedures.Name = "OrganizingPermitDocumentsInfoSocServAppliedProcedures";
        this.OrganizingPermitDocumentsInfoSocServAppliedProcedures.TabIndex = 2;

        this.InterCityTransportProcessInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.InterCityTransportProcessInfoSocServAppliedProcedures.Name = "InterCityTransportProcessInfoSocServAppliedProcedures";
        this.InterCityTransportProcessInfoSocServAppliedProcedures.TabIndex = 20;

        this.IntraCityTransportProcessInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.IntraCityTransportProcessInfoSocServAppliedProcedures.Name = "IntraCityTransportProcessInfoSocServAppliedProcedures";
        this.IntraCityTransportProcessInfoSocServAppliedProcedures.TabIndex = 18;

        this.ArrangementOfWorkSchoolEnInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.ArrangementOfWorkSchoolEnInfoSocServAppliedProcedures.Name = "ArrangementOfWorkSchoolEnInfoSocServAppliedProcedures";
        this.ArrangementOfWorkSchoolEnInfoSocServAppliedProcedures.TabIndex = 16;

        this.ArrangementOfLivingPlacesInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.ArrangementOfLivingPlacesInfoSocServAppliedProcedures.Name = "ArrangementOfLivingPlacesInfoSocServAppliedProcedures";
        this.ArrangementOfLivingPlacesInfoSocServAppliedProcedures.TabIndex = 14;

        this.CoordWarVeteranContactUniInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.CoordWarVeteranContactUniInfoSocServAppliedProcedures.Name = "CoordWarVeteranContactUniInfoSocServAppliedProcedures";
        this.CoordWarVeteranContactUniInfoSocServAppliedProcedures.TabIndex = 12;

        this.GuidanceToPublicInstitInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.GuidanceToPublicInstitInfoSocServAppliedProcedures.Name = "GuidanceToPublicInstitInfoSocServAppliedProcedures";
        this.GuidanceToPublicInstitInfoSocServAppliedProcedures.TabIndex = 10;

        this.LegislativeReviewAndInfoInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.LegislativeReviewAndInfoInfoSocServAppliedProcedures.Name = "LegislativeReviewAndInfoInfoSocServAppliedProcedures";
        this.LegislativeReviewAndInfoInfoSocServAppliedProcedures.TabIndex = 8;

        this.PhoneCallWitPublicInstitInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.PhoneCallWitPublicInstitInfoSocServAppliedProcedures.Name = "PhoneCallWitPublicInstitInfoSocServAppliedProcedures";
        this.PhoneCallWitPublicInstitInfoSocServAppliedProcedures.TabIndex = 6;


        this.GuidanceAboutHomeHealthCrInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.GuidanceAboutHomeHealthCrInfoSocServAppliedProcedures.Name = "GuidanceAboutHomeHealthCrInfoSocServAppliedProcedures";
        this.GuidanceAboutHomeHealthCrInfoSocServAppliedProcedures.TabIndex = 4;

        this.GuidanceAboutLawInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.GuidanceAboutLawInfoSocServAppliedProcedures.Name = "GuidanceAboutLawInfoSocServAppliedProcedures";
        this.GuidanceAboutLawInfoSocServAppliedProcedures.TabIndex = 2;

        this.GuidanceAboutCareSalaryInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.GuidanceAboutCareSalaryInfoSocServAppliedProcedures.Name = "GuidanceAboutCareSalaryInfoSocServAppliedProcedures";
        this.GuidanceAboutCareSalaryInfoSocServAppliedProcedures.TabIndex = 0;

        this.GuidanceToCivilOrganizatInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.GuidanceToCivilOrganizatInfoSocServAppliedProcedures.Name = "GuidanceToCivilOrganizatInfoSocServAppliedProcedures";
        this.GuidanceToCivilOrganizatInfoSocServAppliedProcedures.TabIndex = 20;

        this.GuidanceToFoundationsInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.GuidanceToFoundationsInfoSocServAppliedProcedures.Name = "GuidanceToFoundationsInfoSocServAppliedProcedures";
        this.GuidanceToFoundationsInfoSocServAppliedProcedures.TabIndex = 22;

        this.BenefitingFromDonationsInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.BenefitingFromDonationsInfoSocServAppliedProcedures.Name = "BenefitingFromDonationsInfoSocServAppliedProcedures";
        this.BenefitingFromDonationsInfoSocServAppliedProcedures.TabIndex = 24;

        this.CalcAndFollowRestProcInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.CalcAndFollowRestProcInfoSocServAppliedProcedures.Name = "CalcAndFollowRestProcInfoSocServAppliedProcedures";
        this.CalcAndFollowRestProcInfoSocServAppliedProcedures.TabIndex = 10;

        this.InformAndDirectRetireProcInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.InformAndDirectRetireProcInfoSocServAppliedProcedures.Name = "InformAndDirectRetireProcInfoSocServAppliedProcedures";
        this.InformAndDirectRetireProcInfoSocServAppliedProcedures.TabIndex = 12;

        this.MedicEqProcRefundInfoProcInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.MedicEqProcRefundInfoProcInfoSocServAppliedProcedures.Name = "MedicEqProcRefundInfoProcInfoSocServAppliedProcedures";
        this.MedicEqProcRefundInfoProcInfoSocServAppliedProcedures.TabIndex = 14;

        this.WeeklyTeamMeetingsInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.WeeklyTeamMeetingsInfoSocServAppliedProcedures.Name = "WeeklyTeamMeetingsInfoSocServAppliedProcedures";
        this.WeeklyTeamMeetingsInfoSocServAppliedProcedures.TabIndex = 6;

        this.WeeklyVisitAttendenceInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.WeeklyVisitAttendenceInfoSocServAppliedProcedures.Name = "WeeklyVisitAttendenceInfoSocServAppliedProcedures";
        this.WeeklyVisitAttendenceInfoSocServAppliedProcedures.TabIndex = 8;

        this.ProvisionIssuesInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.ProvisionIssuesInfoSocServAppliedProcedures.Name = "ProvisionIssuesInfoSocServAppliedProcedures";
        this.ProvisionIssuesInfoSocServAppliedProcedures.TabIndex = 4;

        this.ProvideInterSecInjStatDocInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.ProvideInterSecInjStatDocInfoSocServAppliedProcedures.Name = "ProvideInterSecInjStatDocInfoSocServAppliedProcedures";
        this.ProvideInterSecInjStatDocInfoSocServAppliedProcedures.TabIndex = 2;

        this.ProvidingAccomodationInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.ProvidingAccomodationInfoSocServAppliedProcedures.Name = "ProvidingAccomodationInfoSocServAppliedProcedures";
        this.ProvidingAccomodationInfoSocServAppliedProcedures.TabIndex = 0;

        this.GuidanceDrugSupplyAbroadInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.GuidanceDrugSupplyAbroadInfoSocServAppliedProcedures.Name = "GuidanceDrugSupplyAbroadInfoSocServAppliedProcedures";
        this.GuidanceDrugSupplyAbroadInfoSocServAppliedProcedures.TabIndex = 18;

        this.VocationalRehabilitationInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.VocationalRehabilitationInfoSocServAppliedProcedures.Name = "VocationalRehabilitationInfoSocServAppliedProcedures";
        this.VocationalRehabilitationInfoSocServAppliedProcedures.TabIndex = 16;

        this.DonatedMedicalSupplyProcInfoSocServAppliedProcedures = new TTVisual.TTTextBox();
        this.DonatedMedicalSupplyProcInfoSocServAppliedProcedures.Name = "DonatedMedicalSupplyProcInfoSocServAppliedProcedures";
        this.DonatedMedicalSupplyProcInfoSocServAppliedProcedures.TabIndex = 16;

        this.GrantingDealership = new TTVisual.TTCheckBox();
        this.GrantingDealership.Value = false;
        this.GrantingDealership.Text = i18n("M30513", "Milli Piyango İdaresi Genel Müdürlüğü'nce Bayilik Verilmesi");
        this.GrantingDealership.Title = i18n("M30513", "Milli Piyango İdaresi Genel Müdürlüğü'nce Bayilik Verilmesi");
        this.GrantingDealership.Name = "GrantingDealership";
        this.GrantingDealership.TabIndex = 81;

        this.UtilityFromRehabilitationCent = new TTVisual.TTCheckBox();
        this.UtilityFromRehabilitationCent.Value = false;
        this.UtilityFromRehabilitationCent.Text = i18n("M30512", "XXXXXX Ali Çetinkaya İlk Kurşun Rehabilitasyon Merkezi'nden Yararlanma");
        this.UtilityFromRehabilitationCent.Title = i18n("M30512", "XXXXXX Ali Çetinkaya İlk Kurşun Rehabilitasyon Merkezi'nden Yararlanma");
        this.UtilityFromRehabilitationCent.Name = "UtilityFromRehabilitationCent";
        this.UtilityFromRehabilitationCent.TabIndex = 80;

        this.WeaponPortageTransportLicense = new TTVisual.TTCheckBox();
        this.WeaponPortageTransportLicense.Value = false;
        this.WeaponPortageTransportLicense.Text = i18n("M21867", "Silah Bulundurma Taşıma Ruhsatı");
        this.WeaponPortageTransportLicense.Title = i18n("M21867", "Silah Bulundurma Taşıma Ruhsatı");
        this.WeaponPortageTransportLicense.Name = "WeaponPortageTransportLicense";
        this.WeaponPortageTransportLicense.TabIndex = 79;

        this.FreeAccessToPrivateEduInstit = new TTVisual.TTCheckBox();
        this.FreeAccessToPrivateEduInstit.Value = false;
        this.FreeAccessToPrivateEduInstit.Text = i18n("M20091", "Özel Eğitim Kurumlarından Ücretsiz Yararlanma");
        this.FreeAccessToPrivateEduInstit.Title = i18n("M20091", "Özel Eğitim Kurumlarından Ücretsiz Yararlanma");
        this.FreeAccessToPrivateEduInstit.Name = "FreeAccessToPrivateEduInstit";
        this.FreeAccessToPrivateEduInstit.TabIndex = 78;

        this.MilitaryServiceNearBrotherHom = new TTVisual.TTCheckBox();
        this.MilitaryServiceNearBrotherHom.Value = false;
        this.MilitaryServiceNearBrotherHom.Text = i18n("M18539", "Malul Kardeşlerinin İkametgâhlarına Yakın bir Yerde XXXXXXlik Yapması");
        this.MilitaryServiceNearBrotherHom.Title = i18n("M18539", "Malul Kardeşlerinin İkametgâhlarına Yakın bir Yerde XXXXXXlik Yapması");
        this.MilitaryServiceNearBrotherHom.Name = "MilitaryServiceNearBrotherHom";
        this.MilitaryServiceNearBrotherHom.TabIndex = 77;

        this.BrotherExemptionFromMilitary = new TTVisual.TTCheckBox();
        this.BrotherExemptionFromMilitary.Value = false;
        this.BrotherExemptionFromMilitary.Text = i18n("M18542", "Malulün Kendisinden Sonraki Kardeşinin XXXXXXlikten Muaf Tutulması");
        this.BrotherExemptionFromMilitary.Title = i18n("M18542", "Malulün Kendisinden Sonraki Kardeşinin XXXXXXlikten Muaf Tutulması");
        this.BrotherExemptionFromMilitary.Name = "BrotherExemptionFromMilitary";
        this.BrotherExemptionFromMilitary.TabIndex = 76;

        this.OTVandMTVExemption = new TTVisual.TTCheckBox();
        this.OTVandMTVExemption.Value = false;
        this.OTVandMTVExemption.Text = i18n("M20072", "ÖTV ve MTV Muafiyeti");
        this.OTVandMTVExemption.Title = i18n("M20072", "ÖTV ve MTV Muafiyeti");
        this.OTVandMTVExemption.Name = "OTVandMTVExemption";
        this.OTVandMTVExemption.TabIndex = 75;

        this.DomesticVehiclePurchases = new TTVisual.TTCheckBox();
        this.DomesticVehiclePurchases.Value = false;
        this.DomesticVehiclePurchases.Text = i18n("M24730", "Yurtiçi Araç Alımları");
        this.DomesticVehiclePurchases.Title = i18n("M24730", "Yurtiçi Araç Alımları");
        this.DomesticVehiclePurchases.Name = "DomesticVehiclePurchases";
        this.DomesticVehiclePurchases.TabIndex = 74;

        this.ImportingDutyFreeVehicle = new TTVisual.TTCheckBox();
        this.ImportingDutyFreeVehicle.Value = false;
        this.ImportingDutyFreeVehicle.Text = i18n("M14997", "Gümrüksüz Araç İthal Edilmesi");
        this.ImportingDutyFreeVehicle.Title = i18n("M14997", "Gümrüksüz Araç İthal Edilmesi");
        this.ImportingDutyFreeVehicle.Name = "ImportingDutyFreeVehicle";
        this.ImportingDutyFreeVehicle.TabIndex = 73;

        this.ElectricAndWaterDiscount = new TTVisual.TTCheckBox();
        this.ElectricAndWaterDiscount.Value = false;
        this.ElectricAndWaterDiscount.Text = i18n("M13623", "Elektrik ve Su İndirimi");
        this.ElectricAndWaterDiscount.Title = i18n("M13623", "Elektrik ve Su İndirimi");
        this.ElectricAndWaterDiscount.Name = "ElectricAndWaterDiscount";
        this.ElectricAndWaterDiscount.TabIndex = 72;

        this.ResidenceTaxExemption = new TTVisual.TTCheckBox();
        this.ResidenceTaxExemption.Value = false;
        this.ResidenceTaxExemption.Text = i18n("M18927", "Mesken Vergisi Muafiyeti");
        this.ResidenceTaxExemption.Title = i18n("M18927", "Mesken Vergisi Muafiyeti");
        this.ResidenceTaxExemption.Name = "ResidenceTaxExemption";
        this.ResidenceTaxExemption.TabIndex = 71;

        this.IncomeTaxDiscount = new TTVisual.TTCheckBox();
        this.IncomeTaxDiscount.Value = false;
        this.IncomeTaxDiscount.Text = i18n("M14660", "Gelir Vergisi İndirimi");
        this.IncomeTaxDiscount.Title = i18n("M14660", "Gelir Vergisi İndirimi");
        this.IncomeTaxDiscount.Name = "IncomeTaxDiscount";
        this.IncomeTaxDiscount.TabIndex = 70;

        this.UsageRightFromTOKIHouses = new TTVisual.TTCheckBox();
        this.UsageRightFromTOKIHouses.Value = false;
        this.UsageRightFromTOKIHouses.Text = i18n("M23468", "TOKİ Konutlarından Faydalanma Hakkı");
        this.UsageRightFromTOKIHouses.Title = i18n("M23468", "TOKİ Konutlarından Faydalanma Hakkı");
        this.UsageRightFromTOKIHouses.Name = "UsageRightFromTOKIHouses";
        this.UsageRightFromTOKIHouses.TabIndex = 69;

        this.GivingCorporateHousingCredit = new TTVisual.TTCheckBox();
        this.GivingCorporateHousingCredit.Value = false;
        this.GivingCorporateHousingCredit.Text = i18n("M30511", "Toplu Konut Kredisi Verilmesi");
        this.GivingCorporateHousingCredit.Title = i18n("M30511", "Toplu Konut Kredisi Verilmesi");
        this.GivingCorporateHousingCredit.Name = "GivingCorporateHousingCredit";
        this.GivingCorporateHousingCredit.TabIndex = 68;

        this.ProvideHouseToDisabledStaff = new TTVisual.TTCheckBox();
        this.ProvideHouseToDisabledStaff.Value = false;
        this.ProvideHouseToDisabledStaff.Text = i18n("M14917", "Görevdeki Malul Personele Konut Tahsis Edilmesi");
        this.ProvideHouseToDisabledStaff.Title = i18n("M14917", "Görevdeki Malul Personele Konut Tahsis Edilmesi");
        this.ProvideHouseToDisabledStaff.Name = "ProvideHouseToDisabledStaff";
        this.ProvideHouseToDisabledStaff.TabIndex = 67;

        this.UtilizationOfPublicHousing = new TTVisual.TTCheckBox();
        this.UtilizationOfPublicHousing.Value = false;
        this.UtilizationOfPublicHousing.Text = i18n("M17141", "Kamu Konutlarından Yararlanma ve Kira Yardımı");
        this.UtilizationOfPublicHousing.Title = i18n("M17141", "Kamu Konutlarından Yararlanma ve Kira Yardımı");
        this.UtilizationOfPublicHousing.Name = "UtilizationOfPublicHousing";
        this.UtilizationOfPublicHousing.TabIndex = 66;

        this.ProvidingWarVeteranCard = new TTVisual.TTCheckBox();
        this.ProvidingWarVeteranCard.Value = false;
        this.ProvidingWarVeteranCard.Text = i18n("M30510", "ASPB Gazi Kartı Verilmesi");
        this.ProvidingWarVeteranCard.Title = i18n("M30510", "ASPB Gazi Kartı Verilmesi");
        this.ProvidingWarVeteranCard.Name = "ProvidingWarVeteranCard";
        this.ProvidingWarVeteranCard.TabIndex = 65;

        this.GrantingEmploymentRights = new TTVisual.TTCheckBox();
        this.GrantingEmploymentRights.Value = false;
        this.GrantingEmploymentRights.Text = i18n("M30509", "ASPB Tarafından İş Hakkı Verilmesi");
        this.GrantingEmploymentRights.Title = i18n("M30509", "ASPB Tarafından İş Hakkı Verilmesi");
        this.GrantingEmploymentRights.Name = "GrantingEmploymentRights";
        this.GrantingEmploymentRights.TabIndex = 64;

        this.EducationAidBySGK = new TTVisual.TTCheckBox();
        this.EducationAidBySGK.Value = false;
        this.EducationAidBySGK.Text = i18n("M21782", "SGK Öğrenim Yardımı");
        this.EducationAidBySGK.Title = i18n("M21782", "SGK Öğrenim Yardımı");
        this.EducationAidBySGK.Name = "EducationAidBySGK";
        this.EducationAidBySGK.TabIndex = 63;

        this.SupplementaryPaymentSGK = new TTVisual.TTCheckBox();
        this.SupplementaryPaymentSGK.Value = false;
        this.SupplementaryPaymentSGK.Text = i18n("M21778", "SGK Ek Ödeme");
        this.SupplementaryPaymentSGK.Title = i18n("M21778", "SGK Ek Ödeme");
        this.SupplementaryPaymentSGK.Name = "SupplementaryPaymentSGK";
        this.SupplementaryPaymentSGK.TabIndex = 62;

        this.RetirementBonusBySGK = new TTVisual.TTCheckBox();
        this.RetirementBonusBySGK.Value = false;
        this.RetirementBonusBySGK.Text = i18n("M21786", "SGK Tarafından Emekli İkramiyesi Verilmesi");
        this.RetirementBonusBySGK.Title = i18n("M21786", "SGK Tarafından Emekli İkramiyesi Verilmesi");
        this.RetirementBonusBySGK.Name = "RetirementBonusBySGK";
        this.RetirementBonusBySGK.TabIndex = 61;

        this.SalaryStartBySGK = new TTVisual.TTCheckBox();
        this.SalaryStartBySGK.Value = false;
        this.SalaryStartBySGK.Text = i18n("M21787", "SGK Tarafından Maaş Bağlanması");
        this.SalaryStartBySGK.Title = i18n("M21787", "SGK Tarafından Maaş Bağlanması");
        this.SalaryStartBySGK.Name = "SalaryStartBySGK";
        this.SalaryStartBySGK.TabIndex = 60;

        this.StatePrideMedal = new TTVisual.TTCheckBox();
        this.StatePrideMedal.Value = false;
        this.StatePrideMedal.Text = i18n("M12706", "Devlet Ödünç Madalyası, Malul Gazi Rozeti");
        this.StatePrideMedal.Title = i18n("M12706", "Devlet Ödünç Madalyası, Malul Gazi Rozeti");
        this.StatePrideMedal.Name = "StatePrideMedal";
        this.StatePrideMedal.TabIndex = 59;

        this.JobResumeStatus = new TTVisual.TTCheckBox();
        this.JobResumeStatus.Value = false;
        this.JobResumeStatus.Text = i18n("M14918", "Göreve Devam Etme Durumu");
        this.JobResumeStatus.Title = i18n("M14918", "Göreve Devam Etme Durumu");
        this.JobResumeStatus.Name = "JobResumeStatus";
        this.JobResumeStatus.TabIndex = 58;

        this.OYAKAid = new TTVisual.TTCheckBox();
        this.OYAKAid.Value = false;
        this.OYAKAid.Text = i18n("M30508", "OYAK Yardımı");
        this.OYAKAid.Title = i18n("M30508", "OYAK Yardımı");
        this.OYAKAid.Name = "OYAKAid";
        this.OYAKAid.TabIndex = 57;

        this.SoldierLifeInsurance = new TTVisual.TTCheckBox();
        this.SoldierLifeInsurance.Value = false;
        this.SoldierLifeInsurance.Text = i18n("M30507", "Mehmetçik Yaşam Sigortası");
        this.SoldierLifeInsurance.Title = i18n("M30507", "Mehmetçik Yaşam Sigortası");
        this.SoldierLifeInsurance.Name = "SoldierLifeInsurance";
        this.SoldierLifeInsurance.TabIndex = 56;

        this.SoldierFoundationAid = new TTVisual.TTCheckBox();
        this.SoldierFoundationAid.Value = false;
        this.SoldierFoundationAid.Text = i18n("M30506", "Mehmetçik Vakfı Yardımları");
        this.SoldierFoundationAid.Title = i18n("M30506", "Mehmetçik Vakfı Yardımları");
        this.SoldierFoundationAid.Name = "SoldierFoundationAid";
        this.SoldierFoundationAid.TabIndex = 55;

        this.XXXXXXSolidarityFoundationAid = new TTVisual.TTCheckBox();
        this.XXXXXXSolidarityFoundationAid.Value = false;
        this.XXXXXXSolidarityFoundationAid.Text = i18n("M23593", "XXXXXX Dayanışma Vakfı Yardımı");
        this.XXXXXXSolidarityFoundationAid.Title = i18n("M23593", "XXXXXX Dayanışma Vakfı Yardımı");
        this.XXXXXXSolidarityFoundationAid.Name = "XXXXXXSolidarityFoundationAid";
        this.XXXXXXSolidarityFoundationAid.TabIndex = 54;

        this.CashIdemnityTransactions = new TTVisual.TTCheckBox();
        this.CashIdemnityTransactions.Value = false;
        this.CashIdemnityTransactions.Text = i18n("M19399", "Nakdi Tazminat İşlemleri");
        this.CashIdemnityTransactions.Title = i18n("M19399", "Nakdi Tazminat İşlemleri");
        this.CashIdemnityTransactions.Name = "CashIdemnityTransactions";
        this.CashIdemnityTransactions.TabIndex = 53;


        this.GivingVeteranRightsBrochure = new TTVisual.TTCheckBox();
        this.GivingVeteranRightsBrochure.Value = false;
        this.GivingVeteranRightsBrochure.Text = i18n("M14539", "Gazilere Sağlanan Haklar Broşürünün Verilmesi");
        this.GivingVeteranRightsBrochure.Title = i18n("M14539", "Gazilere Sağlanan Haklar Broşürünün Verilmesi");
        this.GivingVeteranRightsBrochure.Name = "GivingVeteranRightsBrochure";
        this.GivingVeteranRightsBrochure.TabIndex = 50;

        this.AllowancePayment = new TTVisual.TTCheckBox();
        this.AllowancePayment.Value = false;
        this.AllowancePayment.Text = i18n("M15111", "Harçlık Ödemesi");
        this.AllowancePayment.Title = i18n("M15111", "Harçlık Ödemesi");
        this.AllowancePayment.Name = "AllowancePayment";
        this.AllowancePayment.TabIndex = 49;

        this.IndemnityCompensation = new TTVisual.TTCheckBox();
        this.IndemnityCompensation.Value = false;
        this.IndemnityCompensation.Text = i18n("M30505", "Özel Harekat ve Operasyon Tazminatı");
        this.IndemnityCompensation.Title = i18n("M30505", "Özel Harekat ve Operasyon Tazminatı");
        this.IndemnityCompensation.Name = "IndemnityCompensation";
        this.IndemnityCompensation.TabIndex = 48;

        this.AdvancePayment = new TTVisual.TTCheckBox();
        this.AdvancePayment.Value = false;
        this.AdvancePayment.Text = i18n("M11266", "Avans Ödemesi");
        this.AdvancePayment.Title = i18n("M11266", "Avans Ödemesi");
        this.AdvancePayment.Name = "AdvancePayment";
        this.AdvancePayment.TabIndex = 47;

        this.HealthAid = new TTVisual.TTCheckBox();
        this.HealthAid.Value = false;
        this.HealthAid.Text = i18n("M21268", "Sağlık Yardımı");
        this.HealthAid.Title = i18n("M21268", "Sağlık Yardımı");
        this.HealthAid.Name = "HealthAid";
        this.HealthAid.TabIndex = 46;


        this.OrganizingPermitDocuments = new TTVisual.TTCheckBox();
        this.OrganizingPermitDocuments.Value = false;
        this.OrganizingPermitDocuments.Text = i18n("M16971", "İzin Belgelerinin Düzenlenmesi");
        this.OrganizingPermitDocuments.Title = i18n("M16971", "İzin Belgelerinin Düzenlenmesi");
        this.OrganizingPermitDocuments.Name = "OrganizingPermitDocuments";
        this.OrganizingPermitDocuments.TabIndex = 43;

        this.IdentificationOfParticipants = new TTVisual.TTCheckBox();
        this.IdentificationOfParticipants.Value = false;
        this.IdentificationOfParticipants.Text = i18n("M14085", "Faaliyetlerde Katılımcıların Belirlenmesi");
        this.IdentificationOfParticipants.Title = i18n("M14085", "Faaliyetlerde Katılımcıların Belirlenmesi");
        this.IdentificationOfParticipants.Name = "IdentificationOfParticipants";
        this.IdentificationOfParticipants.TabIndex = 42;



        this.InterCityTransportProcesses = new TTVisual.TTCheckBox();
        this.InterCityTransportProcesses.Value = false;
        this.InterCityTransportProcesses.Text = i18n("M22577", "Taburculuk Sırasında İl Dışı 112 Ambulans, Uçak, Tren vb.");
        this.InterCityTransportProcesses.Title = i18n("M22577", "Taburculuk Sırasında İl Dışı 112 Ambulans, Uçak, Tren vb.");
        this.InterCityTransportProcesses.Name = "InterCityTransportProcesses";
        this.InterCityTransportProcesses.TabIndex = 37;

        this.IntraCityTransportProcesses = new TTVisual.TTCheckBox();
        this.IntraCityTransportProcesses.Value = false;
        this.IntraCityTransportProcesses.Text = i18n("M30504", "Tedavi Sürecinde İl İçi Ulaşım İşlemleri");
        this.IntraCityTransportProcesses.Title = i18n("M30504", "Tedavi Sürecinde İl İçi Ulaşım İşlemleri");
        this.IntraCityTransportProcesses.Name = "IntraCityTransportProcesses";
        this.IntraCityTransportProcesses.TabIndex = 36;


        this.ArrangementOfWorkSchoolEnv = new TTVisual.TTCheckBox();
        this.ArrangementOfWorkSchoolEnv.Value = false;
        this.ArrangementOfWorkSchoolEnv.Text = i18n("M16776", "İş Ortamının, Okul Ortamının Düzenlenmesi");
        this.ArrangementOfWorkSchoolEnv.Title = i18n("M16776", "İş Ortamının, Okul Ortamının Düzenlenmesi");
        this.ArrangementOfWorkSchoolEnv.Name = "ArrangementOfWorkSchoolEnv";
        this.ArrangementOfWorkSchoolEnv.TabIndex = 33;

        this.ArrangementOfLivingPlaces = new TTVisual.TTCheckBox();
        this.ArrangementOfLivingPlaces.Value = false;
        this.ArrangementOfLivingPlaces.Text = i18n("M24344", "Yaşam Alanlarının Düzenlenmesi");
        this.ArrangementOfLivingPlaces.Title = i18n("M24344", "Yaşam Alanlarının Düzenlenmesi");
        this.ArrangementOfLivingPlaces.Name = "ArrangementOfLivingPlaces";
        this.ArrangementOfLivingPlaces.TabIndex = 32;



        this.CoordWarVeteranContactUnit = new TTVisual.TTCheckBox();
        this.CoordWarVeteranContactUnit.Value = false;
        this.CoordWarVeteranContactUnit.Text = i18n("M15412", "XXXXXXdeki Gazi İrtibat Birimi ile Koordinasyon Kurulması");
        this.CoordWarVeteranContactUnit.Title = i18n("M15412", "XXXXXXdeki Gazi İrtibat Birimi ile Koordinasyon Kurulması");
        this.CoordWarVeteranContactUnit.Name = "CoordWarVeteranContactUnit";
        this.CoordWarVeteranContactUnit.TabIndex = 29;

        this.GuidanceToPublicInstitution = new TTVisual.TTCheckBox();
        this.GuidanceToPublicInstitution.Value = false;
        this.GuidanceToPublicInstitution.Text = i18n("M17144", "Kamu Kurum/Kuruluşlarına Yönlendirme");
        this.GuidanceToPublicInstitution.Title = i18n("M17144", "Kamu Kurum/Kuruluşlarına Yönlendirme");
        this.GuidanceToPublicInstitution.Name = "GuidanceToPublicInstitution";
        this.GuidanceToPublicInstitution.TabIndex = 28;

        this.LegislativeReviewAndInfo = new TTVisual.TTCheckBox();
        this.LegislativeReviewAndInfo.Value = false;
        this.LegislativeReviewAndInfo.Text = i18n("M17142", "Kamu Kurum/Kuruluşları ile İlgili Mevzuatın İncelenmesi ve Bilgilendirme");
        this.LegislativeReviewAndInfo.Title = i18n("M17142", "Kamu Kurum/Kuruluşları ile İlgili Mevzuatın İncelenmesi ve Bilgilendirme");
        this.LegislativeReviewAndInfo.Name = "LegislativeReviewAndInfo";
        this.LegislativeReviewAndInfo.TabIndex = 27;

        this.PhoneCallWitPublicInstitution = new TTVisual.TTCheckBox();
        this.PhoneCallWitPublicInstitution.Value = false;
        this.PhoneCallWitPublicInstitution.Text = i18n("M17145", "Kamu Kurum/Kuruluşlarıyla Yapılan Telefon Görüşmesi");
        this.PhoneCallWitPublicInstitution.Title = i18n("M17145", "Kamu Kurum/Kuruluşlarıyla Yapılan Telefon Görüşmesi");
        this.PhoneCallWitPublicInstitution.Name = "PhoneCallWitPublicInstitution";
        this.PhoneCallWitPublicInstitution.TabIndex = 26;


        this.GuidanceAboutHomeHealthCare = new TTVisual.TTCheckBox();
        this.GuidanceAboutHomeHealthCare.Value = false;
        this.GuidanceAboutHomeHealthCare.Text = i18n("M14001", "Evde Sağlık Hizmetleri ile İlgili Yönlendirme");
        this.GuidanceAboutHomeHealthCare.Title = i18n("M14001", "Evde Sağlık Hizmetleri ile İlgili Yönlendirme");
        this.GuidanceAboutHomeHealthCare.Name = "GuidanceAboutHomeHealthCare";
        this.GuidanceAboutHomeHealthCare.TabIndex = 23;

        this.GuidanceAboutLaw = new TTVisual.TTCheckBox();
        this.GuidanceAboutLaw.Value = false;
        this.GuidanceAboutLaw.Text = i18n("M10227", "2022 Sayılı Yasa ile İlgili Yönlendirme");
        this.GuidanceAboutLaw.Title = i18n("M10227", "2022 Sayılı Yasa ile İlgili Yönlendirme");
        this.GuidanceAboutLaw.Name = "GuidanceAboutLaw";
        this.GuidanceAboutLaw.TabIndex = 22;

        this.GuidanceAboutCareSalary = new TTVisual.TTCheckBox();
        this.GuidanceAboutCareSalary.Value = false;
        this.GuidanceAboutCareSalary.Text = i18n("M30503", "Bakım Maaşı ile İlgili Yönlendirme");
        this.GuidanceAboutCareSalary.Title = i18n("M30503", "Bakım Maaşı ile İlgili Yönlendirme");
        this.GuidanceAboutCareSalary.Name = "GuidanceAboutCareSalary";
        this.GuidanceAboutCareSalary.TabIndex = 21;



        this.GuidanceToCivilOrganizations = new TTVisual.TTCheckBox();
        this.GuidanceToCivilOrganizations.Value = false;
        this.GuidanceToCivilOrganizations.Text = i18n("M21951", "Sivil Toplum Örgütlerine Yönlendirme");
        this.GuidanceToCivilOrganizations.Title = i18n("M21951", "Sivil Toplum Örgütlerine Yönlendirme");
        this.GuidanceToCivilOrganizations.Name = "GuidanceToCivilOrganizations";
        this.GuidanceToCivilOrganizations.TabIndex = 18;

        this.GuidanceToFoundations = new TTVisual.TTCheckBox();
        this.GuidanceToFoundations.Value = false;
        this.GuidanceToFoundations.Text = i18n("M22196", "Sosyal Yardımlaşma ve Dayanışma Vakıflarına Yönlendirme");
        this.GuidanceToFoundations.Title = i18n("M22196", "Sosyal Yardımlaşma ve Dayanışma Vakıflarına Yönlendirme");
        this.GuidanceToFoundations.Name = "GuidanceToFoundations";
        this.GuidanceToFoundations.TabIndex = 17;

        this.BenefitingFromDonations = new TTVisual.TTCheckBox();
        this.BenefitingFromDonations.Value = false;
        this.BenefitingFromDonations.Text = i18n("M11423", "Bağışlardan Yararlandırma");
        this.BenefitingFromDonations.Title = i18n("M11423", "Bağışlardan Yararlandırma");
        this.BenefitingFromDonations.Name = "BenefitingFromDonations";
        this.BenefitingFromDonations.TabIndex = 16;


        this.GuidanceOnDrugSupplyAbroad = new TTVisual.TTCheckBox();
        this.GuidanceOnDrugSupplyAbroad.Value = false;
        this.GuidanceOnDrugSupplyAbroad.Text = i18n("M24728", "Yurtdışı İlaç Teminiyle İlgili Yönlendirme");
        this.GuidanceOnDrugSupplyAbroad.Title = i18n("M24728", "Yurtdışı İlaç Teminiyle İlgili Yönlendirme");
        this.GuidanceOnDrugSupplyAbroad.Name = "GuidanceOnDrugSupplyAbroad";
        this.GuidanceOnDrugSupplyAbroad.TabIndex = 13;

        this.VocationalRehabilitation = new TTVisual.TTCheckBox();
        this.VocationalRehabilitation.Value = false;
        this.VocationalRehabilitation.Text = i18n("M24728", "Mesleki Rehabilitasyona Yönlendirme");
        this.VocationalRehabilitation.Title = i18n("M24728", "Mesleki Rehabilitasyona Yönlendirme");
        this.VocationalRehabilitation.Name = "VocationalRehabilitation";
        this.VocationalRehabilitation.TabIndex = 13;


        this.DonatedMedicalSupplyProcure = new TTVisual.TTCheckBox();
        this.DonatedMedicalSupplyProcure.Value = false;
        this.DonatedMedicalSupplyProcure.Text = i18n("M30502", "Bağış Tıbbi Malzeme Temini");
        this.DonatedMedicalSupplyProcure.Title = i18n("M30502", "Bağış Tıbbi Malzeme Temini");
        this.DonatedMedicalSupplyProcure.Name = "DonatedMedicalSupplyProcure";
        this.DonatedMedicalSupplyProcure.TabIndex = 12;

        this.MedicEqProcRefundInfoProcure = new TTVisual.TTCheckBox();
        this.MedicEqProcRefundInfoProcure.Value = false;
        this.MedicEqProcRefundInfoProcure.Text = i18n("M23408", "Tıbbi Malzeme Prosedürü-Geri Ödeme,Bilgilendirme,Temini");
        this.MedicEqProcRefundInfoProcure.Title = i18n("M23408", "Tıbbi Malzeme Prosedürü-Geri Ödeme,Bilgilendirme,Temini");
        this.MedicEqProcRefundInfoProcure.Name = "MedicEqProcRefundInfoProcure";
        this.MedicEqProcRefundInfoProcure.TabIndex = 11;

        this.InformAndDirectRetireProc = new TTVisual.TTCheckBox();
        this.InformAndDirectRetireProc.Value = false;
        this.InformAndDirectRetireProc.Text = i18n("M13690", "Emeklilik Süreciyle İlgili Bilgilendirme ve Yönlendirme");
        this.InformAndDirectRetireProc.Title = i18n("M13690", "Emeklilik Süreciyle İlgili Bilgilendirme ve Yönlendirme");
        this.InformAndDirectRetireProc.Name = "InformAndDirectRetireProc";
        this.InformAndDirectRetireProc.TabIndex = 10;

        this.CalcAndFollowRestProc = new TTVisual.TTCheckBox();
        this.CalcAndFollowRestProc.Value = false;
        this.CalcAndFollowRestProc.Text = i18n("M16732", "İstirahat Süreçlerinin Hesaplanması ve Takibi");
        this.CalcAndFollowRestProc.Title = i18n("M16732", "İstirahat Süreçlerinin Hesaplanması ve Takibi");
        this.CalcAndFollowRestProc.Name = "CalcAndFollowRestProc";
        this.CalcAndFollowRestProc.TabIndex = 9;


        this.WeeklyVisitAttendence = new TTVisual.TTCheckBox();
        this.WeeklyVisitAttendence.Value = false;
        this.WeeklyVisitAttendence.Text = i18n("M15066", "Haftalık Vizite Katılım");
        this.WeeklyVisitAttendence.Title = i18n("M15066", "Haftalık Vizite Katılım");
        this.WeeklyVisitAttendence.Name = "WeeklyVisitAttendence";
        this.WeeklyVisitAttendence.TabIndex = 6;

        this.WeeklyTeamMeetings = new TTVisual.TTCheckBox();
        this.WeeklyTeamMeetings.Value = false;
        this.WeeklyTeamMeetings.Text = i18n("M15063", "Haftalık Ekip Toplantıları");
        this.WeeklyTeamMeetings.Title = i18n("M15063", "Haftalık Ekip Toplantıları");
        this.WeeklyTeamMeetings.Name = "WeeklyTeamMeetings";
        this.WeeklyTeamMeetings.TabIndex = 5;



        this.ProvisionIssues = new TTVisual.TTCheckBox();
        this.ProvisionIssues.Value = false;
        this.ProvisionIssues.Text = i18n("M20584", "Provizyon Sorunları");
        this.ProvisionIssues.Title = i18n("M20584", "Provizyon Sorunları");
        this.ProvisionIssues.Name = "ProvisionIssues";
        this.ProvisionIssues.TabIndex = 2;

        this.ProvideInternalSecInjStatDoc = new TTVisual.TTCheckBox();
        this.ProvideInternalSecInjStatDoc.Value = false;
        this.ProvideInternalSecInjStatDoc.Text = i18n("M16160", "İç Güvenlik Yaralı Durum Belgesi Temini");
        this.ProvideInternalSecInjStatDoc.Title = i18n("M16160", "İç Güvenlik Yaralı Durum Belgesi Temini");
        this.ProvideInternalSecInjStatDoc.Name = "ProvideInternalSecInjStatDoc";
        this.ProvideInternalSecInjStatDoc.TabIndex = 1;

        this.ProvidingAccomodation = new TTVisual.TTCheckBox();
        this.ProvidingAccomodation.Value = false;
        this.ProvidingAccomodation.Text = i18n("M30501", "Hasta ve Yakınlarına Kalacak Yer Temini");
        this.ProvidingAccomodation.Title = i18n("M30501", "Hasta ve Yakınlarına Kalacak Yer Temini");
        this.ProvidingAccomodation.Name = "ProvidingAccomodation";
        this.ProvidingAccomodation.TabIndex = 0;
        /**/
        /*SocServPatientFamilyInfo */

        this.LivingHouseDoorEntranceSocServPatientFamilyInfo = new TTVisual.TTEnumComboBox();
        this.LivingHouseDoorEntranceSocServPatientFamilyInfo.DataTypeName = "DoorEntranceTypesEnum";
        this.LivingHouseDoorEntranceSocServPatientFamilyInfo.Name = "LivingHouseDoorEntranceSocServPatientFamilyInfo";
        this.LivingHouseDoorEntranceSocServPatientFamilyInfo.TabIndex = 28;

        this.SocioEconomicInfoEvaluationSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.SocioEconomicInfoEvaluationSocServPatientFamilyInfo.Name = "SocioEconomicInfoEvaluationSocServPatientFamilyInfo";
        this.SocioEconomicInfoEvaluationSocServPatientFamilyInfo.TabIndex = 2;
        this.SocioEconomicInfoEvaluationSocServPatientFamilyInfo.Multiline = true;
        this.SocioEconomicInfoEvaluationSocServPatientFamilyInfo.Height = "'50px'";

        this.MaritalStatus = new TTVisual.TTEnumComboBox();
        this.MaritalStatus.DataTypeName = "MaritalStatusEnum";
        this.MaritalStatus.Name = "MaritalStatus";
        this.MaritalStatus.TabIndex = 69;
        this.TransportationArrivalSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.TransportationArrivalSocServPatientFamilyInfo.Name = "TransportationArrivalSocServPatientFamilyInfo";
        this.TransportationArrivalSocServPatientFamilyInfo.TabIndex = 0;

        this.TransportationEvaluationSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.TransportationEvaluationSocServPatientFamilyInfo.Name = "TransportationEvaluationSocServPatientFamilyInfo";
        this.TransportationEvaluationSocServPatientFamilyInfo.TabIndex = 2;
        this.TransportationEvaluationSocServPatientFamilyInfo.Multiline = true;
        this.TransportationEvaluationSocServPatientFamilyInfo.Height = "'50px'";

        this.PatientPayerNameSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.PatientPayerNameSocServPatientFamilyInfo.Name = "PatientPayerNameSocServPatientFamilyInfo";
        this.PatientPayerNameSocServPatientFamilyInfo.TabIndex = 71;


        this.TransportationGoingSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.TransportationGoingSocServPatientFamilyInfo.Name = "TransportationGoingSocServPatientFamilyInfo";
        this.TransportationGoingSocServPatientFamilyInfo.TabIndex = 4;

        this.PhysicalStatusSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.PhysicalStatusSocServPatientFamilyInfo.Name = "PhysicalStatusSocServPatientFamilyInfo";
        this.PhysicalStatusSocServPatientFamilyInfo.TabIndex = 2;

        this.PatientRelatedWorksSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.PatientRelatedWorksSocServPatientFamilyInfo.Name = "PatientRelatedWorksSocServPatientFamilyInfo";
        this.PatientRelatedWorksSocServPatientFamilyInfo.TabIndex = 0;

        this.SubHeadersSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.SubHeadersSocServPatientFamilyInfo.Name = "SubHeadersSocServPatientFamilyInfo";
        this.SubHeadersSocServPatientFamilyInfo.TabIndex = 4;
        this.SubHeadersSocServPatientFamilyInfo.Multiline = true;
        this.SubHeadersSocServPatientFamilyInfo.Height = "'50px'";

        this.LivingHouseBelongingInfoSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.LivingHouseBelongingInfoSocServPatientFamilyInfo.Name = "LivingHouseBelongingInfoSocServPatientFamilyInfo";
        this.LivingHouseBelongingInfoSocServPatientFamilyInfo.TabIndex = 26;
        this.LivingHouseBelongingInfoSocServPatientFamilyInfo.Visible = false;

        this.LivingHouseBelongingSocServPatientFamilyInfo = new TTVisual.TTEnumComboBox();
        this.LivingHouseBelongingSocServPatientFamilyInfo.DataTypeName = "LivingHouseTypeEnum";
        this.LivingHouseBelongingSocServPatientFamilyInfo.Name = "LivingHouseBelongingSocServPatientFamilyInfo";
        this.LivingHouseBelongingSocServPatientFamilyInfo.TabIndex = 24;

        this.FamilyIncomingsSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.FamilyIncomingsSocServPatientFamilyInfo.Name = "FamilyIncomingsSocServPatientFamilyInfo";
        this.FamilyIncomingsSocServPatientFamilyInfo.TabIndex = 0;

        this.FamilyInformationEvaluationSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.FamilyInformationEvaluationSocServPatientFamilyInfo.Name = "FamilyInformationEvaluationSocServPatientFamilyInfo";
        this.FamilyInformationEvaluationSocServPatientFamilyInfo.TabIndex = 2;
        this.FamilyInformationEvaluationSocServPatientFamilyInfo.Multiline = true;
        this.FamilyInformationEvaluationSocServPatientFamilyInfo.Height = "'50px'";

        this.FamilyInformationSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.FamilyInformationSocServPatientFamilyInfo.Name = "FamilyInformationSocServPatientFamilyInfo";
        this.FamilyInformationSocServPatientFamilyInfo.TabIndex = 0;

        this.LivingHouseWcTypeSocServPatientFamilyInfo = new TTVisual.TTEnumComboBox();
        this.LivingHouseWcTypeSocServPatientFamilyInfo.DataTypeName = "WCTypeEnum";
        this.LivingHouseWcTypeSocServPatientFamilyInfo.Name = "LivingHouseWcTypeSocServPatientFamilyInfo";
        this.LivingHouseWcTypeSocServPatientFamilyInfo.TabIndex = 30;

        this.PatientDiagnosisSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.PatientDiagnosisSocServPatientFamilyInfo.Name = "PatientDiagnosisSocServPatientFamilyInfo";
        this.PatientDiagnosisSocServPatientFamilyInfo.TabIndex = 67;
        this.PatientDiagnosisSocServPatientFamilyInfo.Multiline = true;
        this.PatientDiagnosisSocServPatientFamilyInfo.Height = "75px";



        this.CompanionPhoneNumSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.CompanionPhoneNumSocServPatientFamilyInfo.Name = "CompanionPhoneNumSocServPatientFamilyInfo";
        this.CompanionPhoneNumSocServPatientFamilyInfo.TabIndex = 21;

        this.PatientLivesWithSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.PatientLivesWithSocServPatientFamilyInfo.Name = "PatientLivesWithSocServPatientFamilyInfo";
        this.PatientLivesWithSocServPatientFamilyInfo.TabIndex = 23;

        this.NamePayerDefinition = new TTVisual.TTTextBox();
        this.NamePayerDefinition.Name = "NamePayerDefinition";
        this.NamePayerDefinition.TabIndex = 17;

        this.EmploymentRecordIdSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.EmploymentRecordIdSocServPatientFamilyInfo.BackColor = "#f8f8f8";
        this.EmploymentRecordIdSocServPatientFamilyInfo.ReadOnly = true;
        this.EmploymentRecordIdSocServPatientFamilyInfo.Name = "EmploymentRecordIdSocServPatientFamilyInfo";
        this.EmploymentRecordIdSocServPatientFamilyInfo.TabIndex = 19;

        this.CompanionSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.CompanionSocServPatientFamilyInfo.BackColor = "#f8f8f8";
        this.CompanionSocServPatientFamilyInfo.ReadOnly = true;
        this.CompanionSocServPatientFamilyInfo.Name = "CompanionSocServPatientFamilyInfo";
        this.CompanionSocServPatientFamilyInfo.TabIndex = 15;

        this.RestStateSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.RestStateSocServPatientFamilyInfo.Multiline = true;
        this.RestStateSocServPatientFamilyInfo.Name = "RestStateSocServPatientFamilyInfo";
        this.RestStateSocServPatientFamilyInfo.Height = "35px";
        this.RestStateSocServPatientFamilyInfo.TabIndex = 1;

        this.WrittenMedicalMaterialOrToolSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.WrittenMedicalMaterialOrToolSocServPatientFamilyInfo.Name = "WrittenMedicalMaterialOrToolSocServPatientFamilyInfo";
        this.WrittenMedicalMaterialOrToolSocServPatientFamilyInfo.TabIndex = 10;


        this.AuxiliaryToolOtherInfoSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.AuxiliaryToolOtherInfoSocServPatientFamilyInfo.Name = "AuxiliaryToolOtherInfoSocServPatientFamilyInfo";
        this.AuxiliaryToolOtherInfoSocServPatientFamilyInfo.Visible = false;
        this.AuxiliaryToolOtherInfoSocServPatientFamilyInfo.TabIndex = 8;

        this.AuxiliaryToolOtherSocServPatientFamilyInfo = new TTVisual.TTCheckBox();
        this.AuxiliaryToolOtherSocServPatientFamilyInfo.Value = false;
        this.AuxiliaryToolOtherSocServPatientFamilyInfo.Text = i18n("M12780", "Diğer");
        this.AuxiliaryToolOtherSocServPatientFamilyInfo.Title = i18n("M12780", "Diğer");
        this.AuxiliaryToolOtherSocServPatientFamilyInfo.Name = "AuxiliaryToolOtherSocServPatientFamilyInfo";
        this.AuxiliaryToolOtherSocServPatientFamilyInfo.TabIndex = 7;

        this.AuxiliaryToolArmRestSocServPatientFamilyInfo = new TTVisual.TTCheckBox();
        this.AuxiliaryToolArmRestSocServPatientFamilyInfo.Value = false;
        this.AuxiliaryToolArmRestSocServPatientFamilyInfo.Text = i18n("M17231", "Kanedyen");
        this.AuxiliaryToolArmRestSocServPatientFamilyInfo.Title = i18n("M17231", "Kanedyen");
        this.AuxiliaryToolArmRestSocServPatientFamilyInfo.Name = "AuxiliaryToolArmRestSocServPatientFamilyInfo";
        this.AuxiliaryToolArmRestSocServPatientFamilyInfo.TabIndex = 6;

        this.AuxiliaryToolTripodSocServPatientFamilyInfo = new TTVisual.TTCheckBox();
        this.AuxiliaryToolTripodSocServPatientFamilyInfo.Value = false;
        this.AuxiliaryToolTripodSocServPatientFamilyInfo.Text = i18n("M23588", "Tripot");
        this.AuxiliaryToolTripodSocServPatientFamilyInfo.Title = i18n("M23588", "Tripot");
        this.AuxiliaryToolTripodSocServPatientFamilyInfo.Name = "AuxiliaryToolTripodSocServPatientFamilyInfo";
        this.AuxiliaryToolTripodSocServPatientFamilyInfo.TabIndex = 5;

        this.AuxiliaryToolHandSplintSocServPatientFamilyInfo = new TTVisual.TTCheckBox();
        this.AuxiliaryToolHandSplintSocServPatientFamilyInfo.Value = false;
        this.AuxiliaryToolHandSplintSocServPatientFamilyInfo.Text = i18n("M13619", "El Splinti");
        this.AuxiliaryToolHandSplintSocServPatientFamilyInfo.Title = i18n("M13619", "El Splinti");
        this.AuxiliaryToolHandSplintSocServPatientFamilyInfo.Name = "AuxiliaryToolHandSplintSocServPatientFamilyInfo";
        this.AuxiliaryToolHandSplintSocServPatientFamilyInfo.TabIndex = 4;

        this.AuxiliaryToolAfoSocServPatientFamilyInfo = new TTVisual.TTCheckBox();
        this.AuxiliaryToolAfoSocServPatientFamilyInfo.Value = false;
        this.AuxiliaryToolAfoSocServPatientFamilyInfo.Text = "Afo";
        this.AuxiliaryToolAfoSocServPatientFamilyInfo.Title = "Afo";
        this.AuxiliaryToolAfoSocServPatientFamilyInfo.Name = "AuxiliaryToolAfoSocServPatientFamilyInfo";
        this.AuxiliaryToolAfoSocServPatientFamilyInfo.TabIndex = 3;

        this.AuxiliaryToolWalkerSocServPatientFamilyInfo = new TTVisual.TTCheckBox();
        this.AuxiliaryToolWalkerSocServPatientFamilyInfo.Value = false;
        this.AuxiliaryToolWalkerSocServPatientFamilyInfo.Text = i18n("M24203", "Walker");
        this.AuxiliaryToolWalkerSocServPatientFamilyInfo.Title = i18n("M24203", "Walker");
        this.AuxiliaryToolWalkerSocServPatientFamilyInfo.Name = "AuxiliaryToolWalkerSocServPatientFamilyInfo";
        this.AuxiliaryToolWalkerSocServPatientFamilyInfo.TabIndex = 2;

        this.AuxiliaryToolWheelchairSocServPatientFamilyInfo = new TTVisual.TTCheckBox();
        this.AuxiliaryToolWheelchairSocServPatientFamilyInfo.Value = false;
        this.AuxiliaryToolWheelchairSocServPatientFamilyInfo.Text = i18n("M23077", "Tekerlekli Sandalye");
        this.AuxiliaryToolWheelchairSocServPatientFamilyInfo.Title = i18n("M23077", "Tekerlekli Sandalye");
        this.AuxiliaryToolWheelchairSocServPatientFamilyInfo.Name = "AuxiliaryToolWheelchairSocServPatientFamilyInfo";
        this.AuxiliaryToolWheelchairSocServPatientFamilyInfo.TabIndex = 1;

        this.ShortEventStorySocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.ShortEventStorySocServPatientFamilyInfo.Name = "ShortEventStorySocServPatientFamilyInfo";
        this.ShortEventStorySocServPatientFamilyInfo.TabIndex = 7;

        this.SickOrInjuryDateSocServPatientFamilyInfo = new TTVisual.TTDateTimePicker();
        this.SickOrInjuryDateSocServPatientFamilyInfo.Format = DateTimePickerFormat.Short;
        this.SickOrInjuryDateSocServPatientFamilyInfo.Name = "SickOrInjuryDateSocServPatientFamilyInfo";
        this.SickOrInjuryDateSocServPatientFamilyInfo.TabIndex = 5;

        this.SickOrInjuryTypeSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.SickOrInjuryTypeSocServPatientFamilyInfo.Name = "SickOrInjuryTypeSocServPatientFamilyInfo";
        this.SickOrInjuryTypeSocServPatientFamilyInfo.TabIndex = 3;

        this.SickOrInjuredPlaceSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.SickOrInjuredPlaceSocServPatientFamilyInfo.Name = "SickOrInjuredPlaceSocServPatientFamilyInfo";
        this.SickOrInjuredPlaceSocServPatientFamilyInfo.TabIndex = 1;



        this.WCTypeClosetSocServPatientFamilyInfo = new TTVisual.TTCheckBox();
        this.WCTypeClosetSocServPatientFamilyInfo.Value = false;
        this.WCTypeClosetSocServPatientFamilyInfo.Text = "Klozetli";
        this.WCTypeClosetSocServPatientFamilyInfo.Title = "Klozetli";
        this.WCTypeClosetSocServPatientFamilyInfo.Name = "WCTypeClosetSocServPatientFamilyInfo";
        this.WCTypeClosetSocServPatientFamilyInfo.TabIndex = 21;

        this.WCTypeNotClosetSocServPatientFamilyInfo = new TTVisual.TTCheckBox();
        this.WCTypeNotClosetSocServPatientFamilyInfo.Value = false;
        this.WCTypeNotClosetSocServPatientFamilyInfo.Text = "Klozetli Değil";
        this.WCTypeNotClosetSocServPatientFamilyInfo.Title = "Klozetli Değil";
        this.WCTypeNotClosetSocServPatientFamilyInfo.Name = "WCTypeNotClosetSocServPatientFamilyInfo";
        this.WCTypeNotClosetSocServPatientFamilyInfo.TabIndex = 22;

        this.LivingHouseEntranceSocServPatientFamilyInfo = new TTVisual.TTEnumComboBox();
        this.LivingHouseEntranceSocServPatientFamilyInfo.DataTypeName = "YesNoEnum";
        this.LivingHouseEntranceSocServPatientFamilyInfo.Name = "LivingHouseEntranceSocServPatientFamilyInfo";
        this.LivingHouseEntranceSocServPatientFamilyInfo.TabIndex = 17;

        this.LivingHouseBasementSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.LivingHouseBasementSocServPatientFamilyInfo.Name = "LivingHouseBasementSocServPatientFamilyInfo";
        this.LivingHouseBasementSocServPatientFamilyInfo.TabIndex = 15;

        this.LivingHouseElevatorSocServPatientFamilyInfo = new TTVisual.TTEnumComboBox();
        this.LivingHouseElevatorSocServPatientFamilyInfo.DataTypeName = "VarYokEnum";
        this.LivingHouseElevatorSocServPatientFamilyInfo.Name = "LivingHouseElevatorSocServPatientFamilyInfo";
        this.LivingHouseElevatorSocServPatientFamilyInfo.TabIndex = 13;

        this.LivingHouseNumOfFloorSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.LivingHouseNumOfFloorSocServPatientFamilyInfo.Name = "LivingHouseNumOfFloorSocServPatientFamilyInfo";
        this.LivingHouseNumOfFloorSocServPatientFamilyInfo.TabIndex = 11;

        this.LivingHouseTypeSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.LivingHouseTypeSocServPatientFamilyInfo.Name = "LivingHouseTypeSocServPatientFamilyInfo";
        this.LivingHouseTypeSocServPatientFamilyInfo.TabIndex = 9;

        this.LivingHouseOtherInfoSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        //this.LivingHouseOtherInfoSocServPatientFamilyInfo.Multiline = true;
        this.LivingHouseOtherInfoSocServPatientFamilyInfo.Name = "LivingHouseOtherInfoSocServPatientFamilyInfo";
        this.LivingHouseOtherInfoSocServPatientFamilyInfo.TabIndex = 7;



        this.NameResource = new TTVisual.TTTextBox();
        this.NameResource.ReadOnly = true;
        this.NameResource.BackColor = "#f8f8f8";
        this.NameResource.Name = "NameResource";
        this.NameResource.TabIndex = 13;

        this.JobMilitaryServStartDateSocServPatientFamilyInfo = new TTVisual.TTDateTimePicker();
        this.JobMilitaryServStartDateSocServPatientFamilyInfo.Format = DateTimePickerFormat.Short;
        this.JobMilitaryServStartDateSocServPatientFamilyInfo.Name = "JobMilitaryServStartDateSocServPatientFamilyInfo";
        this.JobMilitaryServStartDateSocServPatientFamilyInfo.TabIndex = 1;

        this.ExactTransactionDateSocServPatientFamilyInfo = new TTVisual.TTDateTimePicker();
        this.ExactTransactionDateSocServPatientFamilyInfo.Format = DateTimePickerFormat.Short;
        this.ExactTransactionDateSocServPatientFamilyInfo.Name = "ExactTransactionDateSocServPatientFamilyInfo";
        this.ExactTransactionDateSocServPatientFamilyInfo.TabIndex = 7;

        this.MilitaryServiceEndDateSocServPatientFamilyInfo = new TTVisual.TTDateTimePicker();
        this.MilitaryServiceEndDateSocServPatientFamilyInfo.Format = DateTimePickerFormat.Short;
        this.MilitaryServiceEndDateSocServPatientFamilyInfo.Name = "MilitaryServiceEndDateSocServPatientFamilyInfo";
        this.MilitaryServiceEndDateSocServPatientFamilyInfo.TabIndex = 3;

        this.RecruitmentOfficeSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.RecruitmentOfficeSocServPatientFamilyInfo.Name = "RecruitmentOfficeSocServPatientFamilyInfo";
        this.RecruitmentOfficeSocServPatientFamilyInfo.TabIndex = 5;

        this.EvaluationSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.EvaluationSocServPatientFamilyInfo.Multiline = true;
        this.EvaluationSocServPatientFamilyInfo.Name = "EvaluationSocServPatientFamilyInfo";
        this.EvaluationSocServPatientFamilyInfo.Height = "35px";
        this.EvaluationSocServPatientFamilyInfo.TabIndex = 15;

        this.SecondRetirementStatusSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.SecondRetirementStatusSocServPatientFamilyInfo.Name = "SecondRetirementStatusSocServPatientFamilyInfo";
        this.SecondRetirementStatusSocServPatientFamilyInfo.TabIndex = 13;

        this.LongTermArmBonusInterruptSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.LongTermArmBonusInterruptSocServPatientFamilyInfo.Name = "LongTermArmBonusInterruptSocServPatientFamilyInfo";
        this.LongTermArmBonusInterruptSocServPatientFamilyInfo.TabIndex = 11;

        this.WorkPlaceSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.WorkPlaceSocServPatientFamilyInfo.Name = "WorkPlaceSocServPatientFamilyInfo";
        this.WorkPlaceSocServPatientFamilyInfo.TabIndex = 9;

        this.JobRightUseStatusSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.JobRightUseStatusSocServPatientFamilyInfo.Name = "JobRightUseStatusSocServPatientFamilyInfo";
        this.JobRightUseStatusSocServPatientFamilyInfo.TabIndex = 7;

        this.DateOfRetireSocServPatientFamilyInfo = new TTVisual.TTDateTimePicker();
        this.DateOfRetireSocServPatientFamilyInfo.Format = DateTimePickerFormat.Short;
        this.DateOfRetireSocServPatientFamilyInfo.Name = "DateOfRetireSocServPatientFamilyInfo";
        this.DateOfRetireSocServPatientFamilyInfo.TabIndex = 5;

        this.DateOfStartSocServPatientFamilyInfo = new TTVisual.TTDateTimePicker();
        this.DateOfStartSocServPatientFamilyInfo.Format = DateTimePickerFormat.Short;
        this.DateOfStartSocServPatientFamilyInfo.Name = "DateOfStartSocServPatientFamilyInfo";
        this.DateOfStartSocServPatientFamilyInfo.TabIndex = 3;

        this.PreviousJobBeforeIllSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.PreviousJobBeforeIllSocServPatientFamilyInfo.Name = "PreviousJobBeforeIllSocServPatientFamilyInfo";
        this.PreviousJobBeforeIllSocServPatientFamilyInfo.TabIndex = 1;

        this.SoldierPlaceOfWorkSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.SoldierPlaceOfWorkSocServPatientFamilyInfo.Name = "SoldierPlaceOfWorkSocServPatientFamilyInfo";
        this.SoldierPlaceOfWorkSocServPatientFamilyInfo.TabIndex = 3;

        this.SoldierRankSocServPatientFamilyInfo = new TTVisual.TTTextBox();
        this.SoldierRankSocServPatientFamilyInfo.Name = "SoldierRankSocServPatientFamilyInfo";
        this.SoldierRankSocServPatientFamilyInfo.TabIndex = 1;

        this.EducationStatusPatient = new TTVisual.TTObjectListBox();
        this.EducationStatusPatient.ListDefName = "SKRSOgrenimDurumuList";
        this.EducationStatusPatient.ReadOnly = true;
        this.EducationStatusPatient.Name = "EducationStatusPatient";
        this.EducationStatusPatient.TabIndex = 19;

        this.HomeAddressPatientIdentityAndAddress = new TTVisual.TTTextBox();
        this.HomeAddressPatientIdentityAndAddress.Name = "HomeAddressPatientIdentityAndAddress";
        this.HomeAddressPatientIdentityAndAddress.Multiline = true;
        this.HomeAddressPatientIdentityAndAddress.TabIndex = 17;

        this.UniqueRefNoPerson = new TTVisual.TTTextBox();
        this.UniqueRefNoPerson.BackColor = "#f8f8f8";
        this.UniqueRefNoPerson.ReadOnly = true;
        this.UniqueRefNoPerson.Name = "UniqueRefNoPerson";
        this.UniqueRefNoPerson.TabIndex = 15;

        this.SurnamePerson = new TTVisual.TTTextBox();
        this.SurnamePerson.BackColor = "#f8f8f8";
        this.SurnamePerson.ReadOnly = true;
        this.SurnamePerson.Name = "SurnamePerson";
        this.SurnamePerson.TabIndex = 13;

        this.NamePerson = new TTVisual.TTTextBox();
        this.NamePerson.BackColor = "#f8f8f8";
        this.NamePerson.ReadOnly = true;
        this.NamePerson.Name = "NamePerson";
        this.NamePerson.TabIndex = 11;

        this.MotherNamePerson = new TTVisual.TTTextBox();
        this.MotherNamePerson.BackColor = "#f8f8f8";
        this.MotherNamePerson.ReadOnly = true;
        this.MotherNamePerson.Name = "MotherNamePerson";
        this.MotherNamePerson.TabIndex = 9;

        this.MobilePhonePerson = new TTVisual.TTTextBox();
        this.MobilePhonePerson.Name = "MobilePhonePerson";
        this.MobilePhonePerson.TabIndex = 7;


        this.SKRSMaritalStatus = new TTVisual.TTObjectListBox();
        this.SKRSMaritalStatus.ListDefName = "SKRSMedeniHaliList";
        this.SKRSMaritalStatus.ReadOnly = true;
        this.SKRSMaritalStatus.Name = "SKRSMaritalStatus";
        this.SKRSMaritalStatus.TabIndex = 5;

        this.FatherNamePerson = new TTVisual.TTTextBox();
        this.FatherNamePerson.BackColor = "#f8f8f8";
        this.FatherNamePerson.ReadOnly = true;
        this.FatherNamePerson.Name = "FatherNamePerson";
        this.FatherNamePerson.TabIndex = 3;

        this.BirthDatePerson = new TTVisual.TTDateTimePicker();
        this.BirthDatePerson.BackColor = "#f8f8f8";
        this.BirthDatePerson.Format = DateTimePickerFormat.Short;
        this.BirthDatePerson.Enabled = false;
        this.BirthDatePerson.Name = "BirthDatePerson";
        this.BirthDatePerson.TabIndex = 1;

        this.ApplicationDateSocServPatientFamilyInfo = new TTVisual.TTDateTimePicker();
        this.ApplicationDateSocServPatientFamilyInfo.Format = DateTimePickerFormat.Short;
        this.ApplicationDateSocServPatientFamilyInfo.Name = "ApplicationDateSocServPatientFamilyInfo";
        this.ApplicationDateSocServPatientFamilyInfo.TabIndex = 53;

        this.ttobjectlistbox1 = new TTVisual.TTObjectListBox();
        this.ttobjectlistbox1.ListDefName = "SocialServicePersonelList";
        this.ttobjectlistbox1.Name = "ttobjectlistbox1";
        this.ttobjectlistbox1.TabIndex = 52;
        /**/
        this.ExaminationDate = new TTVisual.TTDateTimePicker();
        this.ExaminationDate.Format = DateTimePickerFormat.Short;
        this.ExaminationDate.Name = "ExaminationDate";
        this.ExaminationDate.TabIndex = 32;


        this.MasterResource = new TTVisual.TTObjectListBox();
        this.MasterResource.ListDefName = "ResourceListByResSectionListDefinition";
        this.MasterResource.Name = "MasterResource";
        this.MasterResource.TabIndex = 31;



        this.ProcedureByUser = new TTVisual.TTObjectListBox();
        this.ProcedureByUser.ListDefName = "ConsultationRequesterUserList";
        this.ProcedureByUser.Name = "ProcedureByUser";
        this.ProcedureByUser.TabIndex = 30;

        this.ReportSelectedUserCombo = new TTVisual.TTObjectListBox();
        this.ReportSelectedUserCombo.ListDefName = "ConsultationRequesterUserList";
        this.ReportSelectedUserCombo.Name = "ReportSelectedUserCombo";
        this.ReportSelectedUserCombo.TabIndex = 30;


        this.PatientType = new TTVisual.TTEnumComboBox();
        this.PatientType.DataTypeName = "PatientTypeEnum";
        this.PatientType.Name = "PatientType";
        this.PatientType.TabIndex = 29;



        this.TypeOfService = new TTVisual.TTEnumComboBox();
        this.TypeOfService.DataTypeName = "TypeOfServicesEnum";
        this.TypeOfService.Name = "TypeOfService";
        this.TypeOfService.SelectedIndex = 0;
        this.TypeOfService.TabIndex = 28;



        this.PatientJob = new TTVisual.TTObjectListBox();
        this.PatientJob.ListDefName = "SKRSMesleklerList";
        this.PatientJob.Name = "PatientJob";
        this.PatientJob.TabIndex = 27;



        this.EducationStatus = new TTVisual.TTObjectListBox();
        this.EducationStatus.ListDefName = "SKRSOgrenimDurumuList";
        this.EducationStatus.Name = "EducationStatus";
        this.EducationStatus.TabIndex = 26;

        this.ResultsAndRecommendations = new TTVisual.TTRichTextBoxControl();
        this.ResultsAndRecommendations.Name = "ResultsAndRecommendations";
        this.ResultsAndRecommendations.TabIndex = 25;



        this.Evaluation = new TTVisual.TTRichTextBoxControl();
        this.Evaluation.Name = "Evaluation";
        this.Evaluation.TabIndex = 24;



        this.PatientAccomodationEconomicCon = new TTVisual.TTRichTextBoxControl();
        this.PatientAccomodationEconomicCon.Name = "PatientAccomodationEconomicCon";
        this.PatientAccomodationEconomicCon.TabIndex = 23;



        this.PatientPsychosocialFamilyCond = new TTVisual.TTRichTextBoxControl();
        this.PatientPsychosocialFamilyCond.Name = "PatientPsychosocialFamilyCond";
        this.PatientPsychosocialFamilyCond.TabIndex = 22;



        this.PatientHealthPhysicalCond = new TTVisual.TTRichTextBoxControl();
        this.PatientHealthPhysicalCond.Name = "PatientHealthPhysicalCond";
        this.PatientHealthPhysicalCond.TabIndex = 21;



        this.MeetingReason = new TTVisual.TTRichTextBoxControl();
        this.MeetingReason.Name = "MeetingReason";
        this.MeetingReason.TabIndex = 20;


        this.ProblemDefinition = new TTVisual.TTRichTextBoxControl();
        this.ProblemDefinition.Name = "ProblemDefinition";
        this.ProblemDefinition.TabIndex = 19;



        this.InterviewedContacts = new TTVisual.TTRichTextBoxControl();
        this.InterviewedContacts.Name = "InterviewedContacts";
        this.InterviewedContacts.TabIndex = 18;



        this.InterviewPlace = new TTVisual.TTRichTextBoxControl();
        this.InterviewPlace.Name = "InterviewPlace";
        this.InterviewPlace.TabIndex = 17;



        this.OtherVocationalInterventions = new TTVisual.TTCheckBox();
        this.OtherVocationalInterventions.Value = false;
        this.OtherVocationalInterventions.Text = i18n("M12831", "Diğer Mesleki Müdahaleler");
        this.OtherVocationalInterventions.Name = "OtherVocationalInterventions";
        this.OtherVocationalInterventions.Title = i18n("M12831", "Diğer Mesleki Müdahaleler");
        this.OtherVocationalInterventions.TabIndex = 16;

        this.SocialActivity = new TTVisual.TTCheckBox();
        this.SocialActivity.Value = false;
        this.SocialActivity.Text = i18n("M22172", "Sosyal Etkinlik");
        this.SocialActivity.Name = "SocialActivity";
        this.SocialActivity.Title = i18n("M22172", "Sosyal Etkinlik");
        this.SocialActivity.TabIndex = 15;

        this.PsychosocialEduPatientFamily = new TTVisual.TTCheckBox();
        this.PsychosocialEduPatientFamily.Value = false;
        this.PsychosocialEduPatientFamily.Text = i18n("M15142", "Hasta Ailesinin Psikososyal Eğitimi");
        this.PsychosocialEduPatientFamily.Name = "PsychosocialEduPatientFamily";
        this.PsychosocialEduPatientFamily.Title = i18n("M15142", "Hasta Ailesinin Psikososyal Eğitimi");
        this.PsychosocialEduPatientFamily.TabIndex = 14;

        this.PatientTransferervice = new TTVisual.TTCheckBox();
        this.PatientTransferervice.Value = false;
        this.PatientTransferervice.Text = i18n("M15282", "Hasta Nakil Hizmeti");
        this.PatientTransferervice.Name = "PatientTransferervice";
        this.PatientTransferervice.Title = i18n("M15282", "Hasta Nakil Hizmeti");
        this.PatientTransferervice.TabIndex = 13;

        this.PatientEducationAndWorkStudy = new TTVisual.TTCheckBox();
        this.PatientEducationAndWorkStudy.Value = false;
        this.PatientEducationAndWorkStudy.Text = i18n("M15191", "Hasta Eğitimi ve Uğraşı Çalışması");
        this.PatientEducationAndWorkStudy.Name = "PatientEducationAndWorkStudy";
        this.PatientEducationAndWorkStudy.Title = i18n("M15191", "Hasta Eğitimi ve Uğraşı Çalışması");
        this.PatientEducationAndWorkStudy.TabIndex = 12;

        this.GroupStudyWithPatientFamily = new TTVisual.TTCheckBox();
        this.GroupStudyWithPatientFamily.Value = false;
        this.GroupStudyWithPatientFamily.Text = i18n("M15141", "Hasta Ailesi ile Grup Çalışması");
        this.GroupStudyWithPatientFamily.Name = "GroupStudyWithPatientFamily";
        this.GroupStudyWithPatientFamily.Title = i18n("M15141", "Hasta Ailesi ile Grup Çalışması");
        this.GroupStudyWithPatientFamily.TabIndex = 11;

        this.PatientsGroupStudy = new TTVisual.TTCheckBox();
        this.PatientsGroupStudy.Value = false;
        this.PatientsGroupStudy.Text = "Hastalara Grup Çalışması";
        this.PatientsGroupStudy.Name = "PatientsGroupStudy";
        this.PatientsGroupStudy.Title = "Hastalara Grup Çalışması";
        this.PatientsGroupStudy.TabIndex = 10;

        this.TreatmentExpenseResourceRoute = new TTVisual.TTCheckBox();
        this.TreatmentExpenseResourceRoute.Value = false;
        this.TreatmentExpenseResourceRoute.Text = i18n("M22985", "Tedavi Giderleri için Kaynak Bulma ve Yönlendirme");
        this.TreatmentExpenseResourceRoute.Name = "TreatmentExpenseResourceRoute";
        this.TreatmentExpenseResourceRoute.Title = i18n("M22985", "Tedavi Giderleri için Kaynak Bulma ve Yönlendirme");
        this.TreatmentExpenseResourceRoute.TabIndex = 9;

        this.GoodsAndMoneyHelp = new TTVisual.TTCheckBox();
        this.GoodsAndMoneyHelp.Value = false;
        this.GoodsAndMoneyHelp.Text = i18n("M11359", "Ayni ve Nakdi Yardım");
        this.GoodsAndMoneyHelp.Name = "GoodsAndMoneyHelp";
        this.GoodsAndMoneyHelp.Title = i18n("M11359", "Ayni ve Nakdi Yardım");
        this.GoodsAndMoneyHelp.TabIndex = 8;

        this.PlacementInTemporaryShelters = new TTVisual.TTCheckBox();
        this.PlacementInTemporaryShelters.Value = false;
        this.PlacementInTemporaryShelters.Text = i18n("M14605", "Geçici Barınma Merkezlerine Yerleştirme");
        this.PlacementInTemporaryShelters.Name = "PlacementInTemporaryShelters";
        this.PlacementInTemporaryShelters.Title = i18n("M14605", "Geçici Barınma Merkezlerine Yerleştirme");
        this.PlacementInTemporaryShelters.TabIndex = 7;

        this.InstutionalCarePlacement = new TTVisual.TTCheckBox();
        this.InstutionalCarePlacement.Value = false;
        this.InstutionalCarePlacement.Text = i18n("M18034", "Kurum Bakımına Yerleştirme");
        this.InstutionalCarePlacement.Name = "InstutionalCarePlacement";
        this.InstutionalCarePlacement.Title = i18n("M18034", "Kurum Bakımına Yerleştirme");
        this.InstutionalCarePlacement.TabIndex = 6;

        this.SchoolVisit = new TTVisual.TTCheckBox();
        this.SchoolVisit.Value = false;
        this.SchoolVisit.Text = i18n("M19625", "Okul Ziyareti");
        this.SchoolVisit.Name = "SchoolVisit";
        this.SchoolVisit.Title = i18n("M19625", "Okul Ziyareti");
        this.SchoolVisit.TabIndex = 5;

        this.WorkplaceVisit = new TTVisual.TTCheckBox();
        this.WorkplaceVisit.Value = false;
        this.WorkplaceVisit.Text = i18n("M16964", "İşyeri Ziyareti");
        this.WorkplaceVisit.Name = "WorkplaceVisit";
        this.WorkplaceVisit.Title = i18n("M16964", "İşyeri Ziyareti");
        this.WorkplaceVisit.TabIndex = 4;

        this.HomeOrOrganizationVisit = new TTVisual.TTCheckBox();
        this.HomeOrOrganizationVisit.Value = false;
        this.HomeOrOrganizationVisit.Text = i18n("M13989", "Ev veya Kuruluş Ziyareti");
        this.HomeOrOrganizationVisit.Name = "HomeOrOrganizationVisit";
        this.HomeOrOrganizationVisit.Title = i18n("M13989", "Ev veya Kuruluş Ziyareti");
        this.HomeOrOrganizationVisit.TabIndex = 3;

        this.SocialReviewAndEvolution = new TTVisual.TTCheckBox();
        this.SocialReviewAndEvolution.Value = false;
        this.SocialReviewAndEvolution.Text = i18n("M22190", "Sosyal İnceleme ve Değerlendirme");
        this.SocialReviewAndEvolution.Name = "SocialReviewAndEvolution";
        this.SocialReviewAndEvolution.Title = i18n("M22190", "Sosyal İnceleme ve Değerlendirme");
        this.SocialReviewAndEvolution.TabIndex = 2;

        this.PsychosocialStudyPatFamily = new TTVisual.TTCheckBox();
        this.PsychosocialStudyPatFamily.Value = false;
        this.PsychosocialStudyPatFamily.Text = i18n("M15143", "Hasta Ailesiyle Psikososyal Çalışma");
        this.PsychosocialStudyPatFamily.Name = "PsychosocialStudyPatFamily";
        this.PsychosocialStudyPatFamily.Title = i18n("M15143", "Hasta Ailesiyle Psikososyal Çalışma");
        this.PsychosocialStudyPatFamily.TabIndex = 1;

        this.PsychosocialStudyWithPatient = new TTVisual.TTCheckBox();
        this.PsychosocialStudyWithPatient.Value = false;
        this.PsychosocialStudyWithPatient.Text = i18n("M15534", "Hastayla Psikososyal Çalışma");
        this.PsychosocialStudyWithPatient.Name = "PsychosocialStudyWithPatient";
        this.PsychosocialStudyWithPatient.Title = i18n("M15534", "Hastayla Psikososyal Çalışma");
        this.PsychosocialStudyWithPatient.TabIndex = 0;

        this.Controls = [this.MaritalStatus, this.ExaminationDate, this.MasterResource, this.ProcedureByUser, this.ReportSelectedUserCombo, this.PatientType, this.TypeOfService, this.PatientJob, this.EducationStatus, this.ResultsAndRecommendations, this.Evaluation, this.PatientAccomodationEconomicCon, this.PatientPsychosocialFamilyCond, this.PatientHealthPhysicalCond, this.MeetingReason, this.ProblemDefinition, this.InterviewedContacts, this.InterviewPlace, this.OtherVocationalInterventions, this.SocialActivity, this.PsychosocialEduPatientFamily, this.PatientTransferervice, this.PatientEducationAndWorkStudy, this.GroupStudyWithPatientFamily, this.PatientsGroupStudy, this.TreatmentExpenseResourceRoute, this.GoodsAndMoneyHelp, this.PlacementInTemporaryShelters, this.InstutionalCarePlacement, this.SchoolVisit, this.WorkplaceVisit, this.HomeOrOrganizationVisit, this.SocialReviewAndEvolution, this.PsychosocialStudyPatFamily, this.PsychosocialStudyWithPatient
        /**/, this.GrantingDealershipInfoSocServAppliedProcedures, this.OTVandMTVExemptionInfoSocServAppliedProcedures, this.UtilityFromRehabilitCentInfoSocServAppliedProcedures, this.WeaponPortageTransportLicInfoSocServAppliedProcedures, this.EducationAidBySGKInfoSocServAppliedProcedures, this.ElectricAndWaterDiscountInfoSocServAppliedProcedures, this.CoordWarVeteranContactUniInfoSocServAppliedProcedures, this.ProvisionIssuesInfoSocServAppliedProcedures, this.ProvideInterSecInjStatDocInfoSocServAppliedProcedures, this.ProvidingAccomodationInfoSocServAppliedProcedures, this.WeeklyTeamMeetingsInfoSocServAppliedProcedures, this.WeeklyVisitAttendenceInfoSocServAppliedProcedures, this.GuidanceDrugSupplyAbroadInfoSocServAppliedProcedures, this.VocationalRehabilitationInfoSocServAppliedProcedures, this.DonatedMedicalSupplyProcInfoSocServAppliedProcedures, this.MedicEqProcRefundInfoProcInfoSocServAppliedProcedures, this.CalcAndFollowRestProcInfoSocServAppliedProcedures, this.InformAndDirectRetireProcInfoSocServAppliedProcedures, this.BenefitingFromDonationsInfoSocServAppliedProcedures, this.GuidanceToCivilOrganizatInfoSocServAppliedProcedures, this.GuidanceToFoundationsInfoSocServAppliedProcedures, this.GuidanceAboutCareSalaryInfoSocServAppliedProcedures, this.GuidanceAboutHomeHealthCrInfoSocServAppliedProcedures, this.GuidanceAboutLawInfoSocServAppliedProcedures, this.GuidanceToPublicInstitInfoSocServAppliedProcedures, this.LegislativeReviewAndInfoInfoSocServAppliedProcedures, this.PhoneCallWitPublicInstitInfoSocServAppliedProcedures, this.ArrangementOfWorkSchoolEnInfoSocServAppliedProcedures, this.ArrangementOfLivingPlacesInfoSocServAppliedProcedures, this.InterCityTransportProcessInfoSocServAppliedProcedures, this.IntraCityTransportProcessInfoSocServAppliedProcedures, this.IdentificationOfParticipInfoSocServAppliedProcedures, this.OrganizingPermitDocumentsInfoSocServAppliedProcedures, this.IndemnityCompensationInfoSocServAppliedProcedures, this.AdvancePaymentInfoSocServAppliedProcedures, this.HealthAidInfoSocServAppliedProcedures, this.AllowancePaymentInfoSocServAppliedProcedures, this.GivingVeteranRightsBrocInfoSocServAppliedProcedures, this.JobResumeStatusInfoSocServAppliedProcedures, this.StatePrideMedalInfoSocServAppliedProcedures, this.OYAKAidInfoSocServAppliedProcedures, this.SalaryStartBySGKInfoSocServAppliedProcedures, this.SoldierLifeInsuranceInfoSocServAppliedProcedures, this.RetirementBonusBySGKInfoSocServAppliedProcedures, this.SoldierFoundationAidInfoSocServAppliedProcedures, this.IncomeTaxDiscountInfoSocServAppliedProcedures, this.UsageRightFromTOKIHousesInfoSocServAppliedProcedures, this.SupplementaryPaymentSGKInfoSocServAppliedProcedures, this.ResidenceTaxExemptionInfoSocServAppliedProcedures, this.XXXXXXSolidarityFoundatioAidInfoSocServAppliedProcedures, this.GivingCorporateHousCreditInfoSocServAppliedProcedures, this.CashIdemnityTransactionsInfoSocServAppliedProcedures, this.ProvideHouseToDisablStaffInfoSocServAppliedProcedures, this.ImportingDutyFreeVehicleInfoSocServAppliedProcedures, this.UtilizationOfPublicHousinInfoSocServAppliedProcedures, this.ProvidingWarVeteranCardInfoSocServAppliedProcedures, this.DomesticVehiclePurchasesInfoSocServAppliedProcedures, this.FreeAccessToPrivEduInstitInfoSocServAppliedProcedures, this.MilitarServNearBrotherHomInfoSocServAppliedProcedures, this.BrotherExemptionFromMilitInfoSocServAppliedProcedures, this.DomesticVehiclePurchasesInfoSocServAppliedProcedures, this.WeaponPortageTransportLicInfoSocServAppliedProcedures, this.MilitarServNearBrotherHomInfoSocServAppliedProcedures, this.GrantingEmploymentRightsInfoSocServAppliedProcedures, this.Other, this.OpenEducationHighSchool, this.GuidanceServiceOnPhone, this.GrantingDealership, this.UtilityFromRehabilitationCent, this.WeaponPortageTransportLicense, this.FreeAccessToPrivateEduInstit, this.MilitaryServiceNearBrotherHom, this.BrotherExemptionFromMilitary, this.OTVandMTVExemption, this.DomesticVehiclePurchases, this.ImportingDutyFreeVehicle, this.ElectricAndWaterDiscount, this.ResidenceTaxExemption, this.IncomeTaxDiscount, this.UsageRightFromTOKIHouses, this.GivingCorporateHousingCredit, this.ProvideHouseToDisabledStaff, this.UtilizationOfPublicHousing, this.ProvidingWarVeteranCard, this.GrantingEmploymentRights, this.EducationAidBySGK, this.SupplementaryPaymentSGK, this.RetirementBonusBySGK, this.SalaryStartBySGK, this.StatePrideMedal, this.JobResumeStatus, this.OYAKAid, this.SoldierLifeInsurance, this.SoldierFoundationAid, this.XXXXXXSolidarityFoundationAid, this.CashIdemnityTransactions, this.GivingVeteranRightsBrochure, this.AllowancePayment, this.IndemnityCompensation, this.AdvancePayment, this.HealthAid, this.OrganizingPermitDocuments, this.IdentificationOfParticipants, this.InterCityTransportProcesses, this.IntraCityTransportProcesses, this.ArrangementOfWorkSchoolEnv, this.ArrangementOfLivingPlaces, this.CoordWarVeteranContactUnit, this.GuidanceToPublicInstitution, this.LegislativeReviewAndInfo, this.PhoneCallWitPublicInstitution, this.GuidanceAboutHomeHealthCare, this.GuidanceAboutLaw, this.GuidanceAboutCareSalary, this.GuidanceToCivilOrganizations, this.GuidanceToFoundations, this.BenefitingFromDonations, this.GuidanceOnDrugSupplyAbroad, this.VocationalRehabilitation, this.DonatedMedicalSupplyProcure, this.MedicEqProcRefundInfoProcure, this.InformAndDirectRetireProc, this.CalcAndFollowRestProc, this.WeeklyVisitAttendence, this.WeeklyTeamMeetings, this.ProvisionIssues, this.ProvideInternalSecInjStatDoc, this.ProvidingAccomodation,
        /*SocServPatientFamilyInfo*/  this.PatientPayerNameSocServPatientFamilyInfo, this.PatientDiagnosisSocServPatientFamilyInfo, this.LivingHouseWcTypeSocServPatientFamilyInfo, this.FamilyInformationEvaluationSocServPatientFamilyInfo, this.FamilyInformationSocServPatientFamilyInfo, this.FamilyIncomingsSocServPatientFamilyInfo, this.LivingHouseBelongingSocServPatientFamilyInfo, this.LivingHouseBelongingInfoSocServPatientFamilyInfo, this.SubHeadersSocServPatientFamilyInfo, this.PatientRelatedWorksSocServPatientFamilyInfo, this.PhysicalStatusSocServPatientFamilyInfo, this.TransportationGoingSocServPatientFamilyInfo, this.TransportationEvaluationSocServPatientFamilyInfo, this.TransportationArrivalSocServPatientFamilyInfo, this.SocioEconomicInfoEvaluationSocServPatientFamilyInfo, this.LivingHouseDoorEntranceSocServPatientFamilyInfo, this.CompanionPhoneNumSocServPatientFamilyInfo, this.CompanionSocServPatientFamilyInfo, this.EmploymentRecordIdSocServPatientFamilyInfo, this.PatientLivesWithSocServPatientFamilyInfo, this.NamePayerDefinition, this.RestStateSocServPatientFamilyInfo, this.WrittenMedicalMaterialOrToolSocServPatientFamilyInfo, this.AuxiliaryToolOtherInfoSocServPatientFamilyInfo, this.AuxiliaryToolOtherSocServPatientFamilyInfo, this.AuxiliaryToolArmRestSocServPatientFamilyInfo, this.AuxiliaryToolTripodSocServPatientFamilyInfo, this.AuxiliaryToolHandSplintSocServPatientFamilyInfo, this.AuxiliaryToolAfoSocServPatientFamilyInfo, this.AuxiliaryToolWalkerSocServPatientFamilyInfo, this.AuxiliaryToolWheelchairSocServPatientFamilyInfo, this.ShortEventStorySocServPatientFamilyInfo, this.SickOrInjuryDateSocServPatientFamilyInfo, this.SickOrInjuryTypeSocServPatientFamilyInfo, this.SickOrInjuredPlaceSocServPatientFamilyInfo, this.LivingHouseEntranceSocServPatientFamilyInfo, this.LivingHouseBasementSocServPatientFamilyInfo, this.LivingHouseElevatorSocServPatientFamilyInfo, this.LivingHouseNumOfFloorSocServPatientFamilyInfo, this.LivingHouseTypeSocServPatientFamilyInfo, this.LivingHouseOtherInfoSocServPatientFamilyInfo, this.WCTypeClosetSocServPatientFamilyInfo, this.WCTypeNotClosetSocServPatientFamilyInfo, this.NameResource, this.JobMilitaryServStartDateSocServPatientFamilyInfo, this.ExactTransactionDateSocServPatientFamilyInfo, this.MilitaryServiceEndDateSocServPatientFamilyInfo, this.RecruitmentOfficeSocServPatientFamilyInfo, this.EvaluationSocServPatientFamilyInfo, this.SecondRetirementStatusSocServPatientFamilyInfo, this.LongTermArmBonusInterruptSocServPatientFamilyInfo, this.WorkPlaceSocServPatientFamilyInfo, this.JobRightUseStatusSocServPatientFamilyInfo, this.DateOfRetireSocServPatientFamilyInfo, this.DateOfStartSocServPatientFamilyInfo, this.PreviousJobBeforeIllSocServPatientFamilyInfo, this.SoldierPlaceOfWorkSocServPatientFamilyInfo, this.SoldierRankSocServPatientFamilyInfo, this.EducationStatusPatient, this.HomeAddressPatientIdentityAndAddress, this.UniqueRefNoPerson, this.SurnamePerson, this.NamePerson, this.MotherNamePerson, this.MobilePhonePerson, this.SKRSMaritalStatus, this.FatherNamePerson, this.BirthDatePerson,];

    }


}
