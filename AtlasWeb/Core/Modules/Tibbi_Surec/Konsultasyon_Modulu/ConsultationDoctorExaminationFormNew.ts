//$827B6556
import { Component, ViewChild, OnInit, OnDestroy, NgZone, EventEmitter } from '@angular/core';
import { Http } from "@angular/http";
import { ConsultationDoctorExaminationFormNewViewModel } from "./ConsultationDoctorExaminationFormNewViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import { PatientReportInfo } from "../Poliklinik_Modulu/PatientExaminationDoctorFormNewViewModel";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseNewDoctorExaminationForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/BaseNewDoctorExaminationForm";
import { BaseTreatmentMaterial, MedicalStuffReport, ResClinic } from 'NebulaClient/Model/AtlasClientModel';
import { CommonService } from "ObjectClassService/CommonService";
import { Consultation } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { ParticipatnFreeDrugReport, StatusNotificationReport, MedulaTreatmentReport } from 'NebulaClient/Model/AtlasClientModel';
import { Exception } from "NebulaClient/Mscorlib/Exception";
import { Genetic } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { InPatientPhysicianApplication } from 'NebulaClient/Model/AtlasClientModel';
import { ITTObject } from "NebulaClient/StorageManager/InstanceManagement/ITTObject";
import { LaboratoryRequest } from 'NebulaClient/Model/AtlasClientModel';
import { NuclearMedicine } from 'NebulaClient/Model/AtlasClientModel';
import { PathologyRequest } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { PatientStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureOrder } from 'NebulaClient/Model/AtlasClientModel';
import { Radiology } from 'NebulaClient/Model/AtlasClientModel';
import { ResLaboratoryDepartment } from 'NebulaClient/Model/AtlasClientModel';
import { SingleNursingOrder } from 'NebulaClient/Model/AtlasClientModel';
import { StateStatusEnum } from "NebulaClient/Utils/Enums/StateStatusEnum";
import { SubEpisode, DrugOrderIntroduction, DrugOrderIntroductionDet } from 'NebulaClient/Model/AtlasClientModel';
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { TTException } from "NebulaClient/Utils/Exceptions/TTException";
import { TTObject } from "NebulaClient/StorageManager/InstanceManagement/TTObject";
import { TTObjectContext } from "NebulaClient/StorageManager/InstanceManagement/TTObjectContext";
import { TTObjectDef } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectDef";
import { TTObjectDefManager } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectDefManager";
import { TTObjectStateTransitionDef } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef";
import { UserTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ImportantMedicalInformation } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInfoAllergies } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInfoDisabledGroup } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInfoDrugAllergies } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInfoFoodAllergies } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInfoHabits } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInformation } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAlkolKullanimi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSSigaraKullanimi } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from "NebulaClient/Utils/Enums/DateTimePickerFormat";
import { vmRequestedProcedure, DailyProvisionInputModel } from "../Tetkik_Istem_Modulu/ProcedureRequestViewModel";
import { vmProcedureRequestFormDefinition } from "../Tetkik_Istem_Modulu/ProcedureRequestViewModel";
import { ConsultationTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { IModalService } from "Fw/Services/IModalService";
import { EpisodeActionHelper } from "app/Helper/EpisodeActionHelper";
import { IActiveTabService } from 'Fw/Services/IActiveTabService';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { ObjectContextService } from "Fw/Services/ObjectContextService";
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { ModalInfo, ModalActionResult } from 'Fw/Models/ModalInfo';
import { DrugOrderIntroductionService, OldDrugOrderIntroductionDet } from 'ObjectClassService/DrugOrderIntroductionService';
import { InPatientPhysicianApplicationService } from 'ObjectClassService/InPatientPhysicianApplicationService';
import { ReportTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { OpenColorPrescription_Input } from 'ObjectClassService/DrugOrderIntroductionService';
import { UserHelper } from 'app/Helper/UserHelper';
import { EnumItem } from 'app/NebulaClient/Mscorlib/EnumItem';
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { EpisodeActionService } from 'app/NebulaClient/Services/ObjectService/EpisodeActionService';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { ActiveIDsModel, ClickFunctionParams } from 'app/Fw/Models/ParameterDefinitionModel';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import List from 'app/NebulaClient/System/Collections/List';
import { DailyInpatientInfoModel } from '../Tibbi_Surec_Evrensel_Modulu/EpisodeActionFormViewModel';
import { CommonHelper } from 'app/Helper/CommonHelper';
import { Subscription } from 'rxjs';

@Component({
    selector: 'ConsultationDoctorExaminationFormNew',
    templateUrl: './ConsultationDoctorExaminationFormNew.html',
    providers: [MessageService, EpisodeActionHelper]
})
export class ConsultationDoctorExaminationFormNew extends BaseNewDoctorExaminationForm implements OnInit, OnDestroy {
    OnDestroy: EventEmitter<any> = new EventEmitter<any>();
    ReportParamActiveIDsModel : ActiveIDsModel;

    ActiveIngredientMedicalInfoDrugAllergies: TTVisual.ITTListBoxColumn;
    AdditionalMasterResource: TTVisual.ITTListBoxColumn;
    AdditionalProcedureDoctor: TTVisual.ITTListBoxColumn;
    AlcoholMedicalInfoHabits: TTVisual.ITTCheckBox;
    AlcoholUsageFrequencyMedicalInfoHabits: TTVisual.ITTObjectListBox;
    //Amount: TTVisual.ITTTextBoxColumn;
    AProcedureObject: TTVisual.ITTListBoxColumn;
    //Barcode: TTVisual.ITTTextBoxColumn;
    btnConsultationRequest: TTVisual.ITTButton;
    btnReports: TTVisual.ITTButton;
    chkConsultationEmergency: TTVisual.ITTCheckBox;
    chkConsultationInPatientBed: TTVisual.ITTCheckBox;
    chkColumnEmergency: TTVisual.ITTCheckBoxColumn;
    chkInPatientBed: TTVisual.ITTCheckBoxColumn;
    ChronicDiseases: TTVisual.ITTTextBox;
    ChronicMedicalInfoDisabledGroup: TTVisual.ITTCheckBox;
    CigaretteMedicalInfoHabits: TTVisual.ITTCheckBox;
    CigaretteUsageFrequencyMedicalInfoHabits: TTVisual.ITTObjectListBox;
    CoffeeMedicalInfoHabits: TTVisual.ITTCheckBox;
    //CokluOzelDurum: TTVisual.ITTButtonColumn;
    ConsultationDate: TTVisual.ITTDateTimePickerColumn;
    ConsultationGrid: TTVisual.ITTGrid;
    ConsultationRequestedResource: TTVisual.ITTObjectListBox;
    ConsultationRequestedUser: TTVisual.ITTObjectListBox;
    ConsultationResultAndOffer: TTVisual.ITTRichTextBoxControlColumn;
    CreateOrderDetailBeforeSave: TTVisual.ITTButtonColumn;
    Department: TTVisual.ITTListBoxColumn;
    Description: TTVisual.ITTTextBoxColumn;
    DescriptionMedicalInfoHabits: TTVisual.ITTTextBox;
    Diagnose: TTVisual.ITTListBoxColumn;
    DiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    DiagnosisHistory: TTVisual.ITTGrid;
    DiagnosisType: TTVisual.ITTEnumComboBoxColumn;
    //DistributionType: TTVisual.ITTTextBoxColumn;
    DietMaterialMedicalInfoFoodAllergies: TTVisual.ITTListBoxColumn;
    dtpProcessEndDate: TTVisual.ITTDateTimePicker;
    EkUygulamalarTab: TTVisual.ITTTabPage;
    Emergency: TTVisual.ITTCheckBoxColumn;
    EntryActionType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeAddToHistory: TTVisual.ITTCheckBoxColumn;
    EpisodeDiagnose: TTVisual.ITTListBoxColumn;
    EpisodeDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    EpisodeDiagnosisType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeFreeDiagnosis: TTVisual.ITTTextBoxColumn;
    EpisodeIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    EpisodeResponsibleUser: TTVisual.ITTListBoxColumn;
    ExaminationDateTime: TTVisual.ITTDateTimePickerColumn;
    ExaminationIndication: TTVisual.ITTRichTextBoxControlColumn;
    ExecutionDate: TTVisual.ITTDateTimePickerColumn;
    GrdConsultation: TTVisual.ITTGrid;
    GridAdditionalApplications: TTVisual.ITTGrid;
    GridDiagnosis: TTVisual.ITTGrid;
    GridEpisodeDiagnosis: TTVisual.ITTGrid;
    GridNursingOrders: TTVisual.ITTGrid;
    //GridTreatmentMaterials: TTVisual.ITTGrid;
    //TreatmentMaterial: TTVisual.ITTObjectListBox;
    HCObjectID: TTVisual.ITTTextBoxColumn;
    HealthCommiteeActionDate: TTVisual.ITTDateTimePickerColumn;
    HealthCommiteeActionID: TTVisual.ITTTextBoxColumn;
    HealthCommiteeActions: TTVisual.ITTGrid;
    HealthCommiteeActionsTab: TTVisual.ITTTabPage;
    HearingMedicalInfoDisabledGroup: TTVisual.ITTCheckBox;
    Hemodialysis: TTVisual.ITTTextBox;
    Hospital: TTVisual.ITTTextBoxColumn;
    Implant: TTVisual.ITTTextBox;
    InPatientBed: TTVisual.ITTCheckBox;
    IsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    IsTreatmentMaterialEmpty: TTVisual.ITTCheckBox;
    //Kdv: TTVisual.ITTTextBoxColumn;
    //KodsuzMalzemeFiyatı: TTVisual.ITTTextBoxColumn;
    labelAlcoholUsageFrequencyMedicalInfoHabits: TTVisual.ITTLabel;
    labelChronicDiseases: TTVisual.ITTLabel;
    labelCigaretteUsageFrequencyMedicalInfoHabits: TTVisual.ITTLabel;
    labelDescriptionMedicalInfoHabits: TTVisual.ITTLabel;
    labelHemodialysis: TTVisual.ITTLabel;
    labelImplant: TTVisual.ITTLabel;
    labelOncologicFollowUp: TTVisual.ITTLabel;
    labelOtherAllergiesMedicalInfoAllergies: TTVisual.ITTLabel;
    labelOtherInformation: TTVisual.ITTLabel;
    labelProcedureDoctor: TTVisual.ITTLabel;
    labelRequesterDepatment: TTVisual.ITTLabel;
    labelTransplantation: TTVisual.ITTLabel;
    lblConsultationRequestedResource: TTVisual.ITTLabel;
    lblConsultationRequestedUser: TTVisual.ITTLabel;
    lblEpisodeDiagnosis: TTVisual.ITTLabel;
    lblOldDiagnosis: TTVisual.ITTLabel;
    lblPatientAdmissionGeneralInfo: TTVisual.ITTLabel;
    lblProcessDate: TTVisual.ITTLabel;
    lblProcessEndDate: TTVisual.ITTLabel;
    //MalzemeBrans: TTVisual.ITTTextBoxColumn;
    //MalzemeTuru: TTVisual.ITTListBoxColumn;
    ManipulationActionDate: TTVisual.ITTDateTimePickerColumn;
    ManipulationDoctor: TTVisual.ITTListBoxColumn;
    ManipulationGrid: TTVisual.ITTGrid;
    MasterResource: TTVisual.ITTObjectListBox;
    //Material: TTVisual.ITTListBoxColumn;
    MedicalInfoDrugAllergiesMedicalInfoDrugAllergies: TTVisual.ITTGrid;
    MedicalInfoFoodAllergiesMedicalInfoFoodAllergies: TTVisual.ITTGrid;
    MentalMedicalInfoDisabledGroup: TTVisual.ITTCheckBox;
    MlzSarfTab: TTVisual.ITTTabPage;
    NonexistenceMedicalInfoDisabledGroup: TTVisual.ITTCheckBox;
    //Notes: TTVisual.ITTTextBoxColumn;
    NurseNotes: TTVisual.ITTTextBoxColumn;
    NursingApplicationNurseNote: TTVisual.ITTTextBoxColumn;
    NursingApplicationResult: TTVisual.ITTTextBoxColumn;
    OldPhysicialExaminationsGrid: TTVisual.ITTGrid;
    OncologicFollowUp: TTVisual.ITTTextBox;
    OrderActionDate: TTVisual.ITTDateTimePickerColumn;
    OrderProcedureObject: TTVisual.ITTListBoxColumn;
    OrthopedicMedicalInfoDisabledGroup: TTVisual.ITTCheckBox;
    OtherAllergiesMedicalInfoAllergies: TTVisual.ITTTextBox;
    OtherInformation: TTVisual.ITTTextBox;
    OtherMedicalInfoHabits: TTVisual.ITTCheckBox;
    //OzelDurum: TTVisual.ITTListBoxColumn;
    PeriodStartTime: TTVisual.ITTDateTimePickerColumn;
    pnlRightBottom: TTVisual.ITTPanel;
    Pregnancy: TTVisual.ITTCheckBox;
    ProceduerDoctor: TTVisual.ITTObjectListBox;
    ProcedureObject: TTVisual.ITTListBoxColumn;
    ProcedureSpeciality: TTVisual.ITTObjectListBox;
    ProcessDate: TTVisual.ITTDateTimePicker;
    ProtocolNo: TTVisual.ITTTextBox;
    PsychicAndEmotionalMedicalInfoDisabledGroup: TTVisual.ITTCheckBox;
    public _groupTabMaximized: boolean = false;
    RequestDescription: TTVisual.ITTRichTextBoxControlColumn;
    RequestedDepartment: TTVisual.ITTTextBoxColumn;
    RequestedDoctor: TTVisual.ITTObjectListBox;
    // IsComplete: TTVisual.ITTCheckBox;
    RequestedHospital: TTVisual.ITTTextBoxColumn;
    RequestedResource: TTVisual.ITTListBoxColumn;
    RequesterDepartment: TTVisual.ITTTextBoxColumn;
    RequesterDepatment: TTVisual.ITTObjectListBox;
    RequesterHospital: TTVisual.ITTTextBoxColumn;
    RequestReason: TTVisual.ITTRichTextBoxControlColumn;
    ResponsibleUser: TTVisual.ITTListBoxColumn;
    Result: TTVisual.ITTTextBoxColumn;
    RPT: TTVisual.ITTButtonColumn;
    rtfHistory: TTVisual.ITTRichTextBoxControl;
    //SatinAlisTarihi: TTVisual.ITTDateTimePickerColumn;
    SDateTime: TTVisual.ITTDateTimePickerColumn;
    SecDiagnose: TTVisual.ITTListBoxColumn;
    SecDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    SecFreeDiagnosis: TTVisual.ITTTextBoxColumn;
    SecIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    SecResponsibleUser: TTVisual.ITTListBoxColumn;
    SpeechAndLanguageMedicalInfoDisabledGroup: TTVisual.ITTCheckBox;
    tabMedicalInformation: TTVisual.ITTTabControl;
    TeaMedicalInfoHabits: TTVisual.ITTCheckBox;
    Transplantation: TTVisual.ITTTextBox;
    //TreatmentMaterialActionDate: TTVisual.ITTDateTimePickerColumn;
    chkEmergency: TTVisual.ITTCheckBox;
    ttgroupboxAllergies: TTVisual.ITTGroupBox;
    ttgroupboxDisability: TTVisual.ITTGroupBox;
    ttgroupboxHabits: TTVisual.ITTGroupBox;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    ttlistboxcolumn8: TTVisual.ITTListBoxColumn;
    ttpanelPoliclinic: TTVisual.ITTPanel;
    ttpictureboxcontrol1: TTVisual.ITTPictureBoxControl;
    rtfComplaint: TTVisual.ITTRichTextBoxControl;
    rtfConsultationResultAndOffers: TTVisual.ITTRichTextBoxControl;
    rtfPhysicalExamination: TTVisual.ITTRichTextBoxControl;
    rtfRequestDescription: TTVisual.ITTRichTextBoxControl;
    tttabcontrol2: TTVisual.ITTTabControl;
    tttabcontrol3: TTVisual.ITTTabControl;
    tttabcontrolPoliclinic: TTVisual.ITTTabControl;
    tttabpage15: TTVisual.ITTTabPage;
    tttabpage16: TTVisual.ITTTabPage;
    tttabpage17: TTVisual.ITTTabPage;
    tttabpage18: TTVisual.ITTTabPage;
    tttabpage4: TTVisual.ITTTabPage;
    tttabpage5: TTVisual.ITTTabPage;
    tttabpageEOrder: TTVisual.ITTTabPage;
    tttabpageHastaGeçmişi: TTVisual.ITTTabPage;
    tttabpageIstemPaneli: TTVisual.ITTTabPage;
    tttabpageKonsultasyon: TTVisual.ITTTabPage;
    tttabpageMedicalInformation: TTVisual.ITTTabPage;
    tttabpageSagRapor: TTVisual.ITTTabPage;
    cmbReportType: TTVisual.ITTEnumComboBox;
    //UBBCode: TTVisual.ITTTextBoxColumn;
    UnclassifiedMedicalInfoDisabledGroup: TTVisual.ITTCheckBox;
    VisionMedicalInfoDisabledGroup: TTVisual.ITTCheckBox;
    public ConsultationGridColumns = [];
    public DiagnosisHistoryColumns = [];
    public GrdConsultationColumns = [];
    public GridAdditionalApplicationsColumns = [];
    public GridDiagnosisColumns = [];
    public GridEpisodeDiagnosisColumns = [];
    public GridNursingOrdersColumns = [];
    //public GridTreatmentMaterialsColumns = [];
    public HealthCommiteeActionsColumns = [];
    public ManipulationGridColumns = [];
    public GridPatientReportsColumns = [];
    public MedicalInfoDrugAllergiesMedicalInfoDrugAllergiesColumns = [];
    public MedicalInfoFoodAllergiesMedicalInfoFoodAllergiesColumns = [];
    public OldPhysicialExaminationsGridColumns = [];
    //Prescription Column Definitions
    PrescriptionGrid: TTVisual.ITTGrid;
    PhysicianDrug: TTVisual.ITTListBoxColumn;
    cmdSelectBarcodeLevel: TTVisual.ITTButtonColumn;
    Frequency: TTVisual.ITTEnumComboBoxColumn;
    DoseAmount: TTVisual.ITTTextBoxColumn;
    PeriodUnitType: TTVisual.ITTEnumComboBoxColumn;
    Day: TTVisual.ITTTextBoxColumn;
    PackageAmount: TTVisual.ITTTextBoxColumn;
    DrugUsageType: TTVisual.ITTEnumComboBoxColumn;
    DescriptionType: TTVisual.ITTEnumComboBoxColumn;
    DrugDescription: TTVisual.ITTTextBoxColumn;
    TreatmentTime: TTVisual.ITTTextBoxColumn;
    RequiredAmount: TTVisual.ITTTextBoxColumn;
    UsageNote: TTVisual.ITTTextBoxColumn;
    IlacEtkinMadde: TTVisual.ITTButtonColumn;
    SUTRules: TTVisual.ITTButtonColumn;
    txtReportName: TTVisual.TTTextBoxColumn;
    txtReportRequestReason: TTVisual.TTTextBoxColumn;
    txtReportAdmissionDate: TTVisual.TTTextBoxColumn;
    txtReportMasterResource: TTVisual.TTTextBoxColumn;


    gunubirlikYatisKontrol: boolean = false;
    txtStartDate: TTVisual.TTTextBoxColumn;
    txtEndDate: TTVisual.TTTextBoxColumn;
    btnEdit: TTVisual.TTButtonColumn;
    //Prescription Column Definitions
    public PrescriptionGridColumns = [];
    public statusNotificationReportObject = new StatusNotificationReport;
    public medulaTedaviRaporlariObject = new MedulaTreatmentReport;
    public ParticipationFreeDrugReportNewFormObject = new ParticipatnFreeDrugReport;

    public enablePrescriptionTab: boolean;

    public reportTypeList: Array<EnumItem>;
    public selectedReportType: EnumItem;

    panelMessage:string = "Günübirlik Yatış İşlemleri Yapılıyor Lütfen Bekleyiniz";

    isSaveAndCancelCommandVisible: boolean;
    showStatusNotificationReportForm = false;
    showMedulaTedaviRaporlariForm = false;
    showParticipationFreeDrugReportNewForm = false;
    public currentActionReports: boolean = false;
    ActivePage: string = "muayene";
    RecentActiveTab: string;

    public showEDurumBildirirComponent = false;
    private refreshReportGridSubscription : Subscription;

    public PrescriptionList: Array<DrugOrderIntroductionDet> = new Array<DrugOrderIntroductionDet>();
    public consultationDoctorExaminationFormNewViewModel: ConsultationDoctorExaminationFormNewViewModel = new ConsultationDoctorExaminationFormNewViewModel();
    public get _Consultation(): Consultation {
        return this._TTObject as Consultation;
    }
    private ConsultationDoctorExaminationFormNew_DocumentUrl: string = '/api/ConsultationService/ConsultationDoctorExaminationFormNew';
    constructor(http: Http,
        protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected modalService: IModalService,
        protected episodeActionHelper: EpisodeActionHelper,
        protected tabService: IActiveTabService,
        private reportService: AtlasReportService,
        protected objectContextService: ObjectContextService,
        private sideBarMenuService: ISidebarMenuService,
        protected helpMenuService: HelpMenuService,
        protected ngZone: NgZone) {
        super(httpService, messageService, modalService, objectContextService, helpMenuService, ngZone);
        this._DocumentServiceUrl = this.ConsultationDoctorExaminationFormNew_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
        this.reportTypeList = ReportTypeEnum.Items;

    }








    TabPanelClick(source) {
        this.tabService.setActiveTab(source, "cdef");
        this.RecentActiveTab = source;
    }


    //@ViewChild('anamnesisInfo') anamnesisInfoAccordion: DxAccordionComponent;

    // ***** Method declarations start *****
    
    async ngAfterViewInit() {        
        this.openSubscribers();
    }
    
    public openSubscribers(){
        let that = this;
        this.refreshReportGridSubscription = this.httpService.medicalStuffReportSharedService.medicalStuffReportUpdateObservable.subscribe( value => {
            this.reloadReportList();
        });
    }
    


    ActiveAcc: string;
    RecentAcc: string;

    AccPinClick(acc) {
        if (this.RecentAcc == acc) {
            this.RecentAcc = undefined;
            this.tabService.setActiveTab(this.RecentAcc, 'cdefnacc');
        }
        else {
            this.RecentAcc = acc;
            this.tabService.setActiveTab(this.RecentAcc, 'cdefnacc');
        }
    }

    private async btnAnesthesiaConsultationNewRequest_Click(): Promise<void> {
        this.CreateNewAnesthesiaConsultation();
    }
    private async btnBioChemical_Click(): Promise<void> {
        let microBiologyGuid: Guid = new Guid((await SystemParameterService.GetParameterValue("BIYOKIMYAMAINRESGUID", Guid.Empty.toString())));
        let labDep: ResLaboratoryDepartment = <ResLaboratoryDepartment>this._Consultation.ObjectContext.GetObject(microBiologyGuid, TTObjectDefManager.Instance.ObjectDefs[typeof ResLaboratoryDepartment], false);
        if (labDep === null)
            this.CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof LaboratoryRequest), null);
        else this.CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof LaboratoryRequest), labDep.ObjectID);
    }
    private async btnGeneticRequest_Click(): Promise<void> {
        this.CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof Genetic), null);
    }
    private async btnGroupBox4_Click(): Promise<void> {
        if (this._groupTabMaximized)
            this.MinimizeGroupTab();
        else this.MaximizeGroupTab();
    }
    private async btnImportantMedicalInfo_Click(): Promise<void> {
        this.FireNewImportantMedicalInfo();
    }
    private async btnManiplation_Click(): Promise<void> {
        this.CreateNewManipulationRequest();
    }
    private async btnMicroBiology_Click(): Promise<void> {
        let microBiologyGuid: Guid = new Guid((await SystemParameterService.GetParameterValue("MIKROBIYOLOJIMAINRESGUID", Guid.Empty.toString())));
        let labDep: ResLaboratoryDepartment = <ResLaboratoryDepartment>this._Consultation.ObjectContext.GetObject(microBiologyGuid, TTObjectDefManager.Instance.ObjectDefs[typeof ResLaboratoryDepartment], false);
        if (labDep === null)
            this.CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof LaboratoryRequest), null);
        else this.CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof LaboratoryRequest), labDep.ObjectID);
    }
    private async btnNewConsultationFromOtherHospRequest_Click(): Promise<void> {
        this.CreateNewConsultationFromOtherHospRequest();
    }
    private async btnNucleerMedicineRequest_Click(): Promise<void> {
        this.CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof NuclearMedicine), null);
    }
    private async btnNurseryProcedures_Click(): Promise<void> {
        this.MaximizeGroupTab();
        //ContinuousInfoTab.SelectedTab = ContinuousInfoTab.TabPages["NursingOrdersTab"];
        let a = 1;
    }
    private async btnPathologyRequest_Click(): Promise<void> {
        this.CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof PathologyRequest), null);
    }
    private async btnPrescription_Click(): Promise<void> {
        this.CreateNewOutPatientPrescription();
    }
    private async btnRadiologyRequest_Click(): Promise<void> {
        this.CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof Radiology), null);
    }
    private async btnReports_Click(): Promise<void> {
        /*let msitem: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        //msitem.AddMSItem("Sağlık Kurulu", "1");
        //msitem.AddMSItem("Diğer Birim(ler)den SKM ", "2");
        //msitem.AddMSItem("Üç Uzman Tabip İmzalı Rapor", "3");
        msitem.AddMSItem("Hasta Katılım Payından Muaf İlaç Raporu", "4");
        //msitem.AddMSItem("Profesörler Sağlık Kurulu", "5");
        msitem.AddMSItem("İş Göremezlik Raporu", "6");

        let mKey: string = msitem.GetMSItem(this, "İşlem yapmak istediğiniz raporu seçiniz");
        if (mKey === null) {
            TTVisual.InfoBox.Show("İşlemden vazgeçildi", MessageIconEnum.InformationMessage);
            return;
        }
        else {
            switch (mKey) {
                case "1":
                    this.CreateNewHealthCommittee();
                    break;
                case "2":
                    this.CreateNewHCExaminationFromOtherDepartments();
                    break;
                case "3":
                    this.CreateNewHealthCommitteeWithThreeSpecialist();
                    break;
                case "4":
                    this.CreateNewParticipatnFreeDrugReport();
                    break;
                case "5":
                    this.CreateNewHealthCommitteeOfProfessors();
                    break;
                case "6":
                    this.CreateNewUnavailableToWorkReport();
                    break;
                default:
                    break;
            }
        }
        */
    }
    private async btnSpecialLabRequest_Click(): Promise<void> {
        this.CreateNewLaboratoryRequest(TTObjectDefManager.Instance.GetObjectDef(typeof LaboratoryRequest), null);
    }
    private async btnTreatmentMaterial_Click(): Promise<void> {
        this.MaximizeGroupTab();
        //ContinuousInfoTab.SelectedTab = ContinuousInfoTab.TabPages["TreatmentMaterialsTab"];
        let a = 1;
    }
    /*async initNewRowMaterial(data: any) {

        let resourceStore: Store = await ResourceService.GetStore(this._Consultation.MasterResource.ObjectID.toString());
        if (resourceStore === null) {
            throw new TTException(this._Consultation.MasterResource.Name + " bölümünün deposu bulunmadığı için malzeme sarf işlemi yapamazsınız.");
        }
        let newItem = new ConsultationTreatmentMaterial();
        this.Material.ListFilterExpression = "STOCKS.STORE = '" + resourceStore.ObjectID.toString() + "' AND STOCKS.INHELD > 0";
        newItem.Episode = this._Consultation.Episode;
        newItem.Eligible = true;
        newItem.ActionDate = await CommonService.RecTime();
        newItem.Active = true;
        Object.assign(data, newItem);
    }*/

    colorPresClick() {
        let input: OpenColorPrescription_Input = new OpenColorPrescription_Input();
        input.SubEpisodeObjectID = new Guid(this._Consultation.SubEpisode.toString());
        let fullApiUrl: string = 'api/DrugOrderIntroductionService/OpenColorPrescriptionWithJSON';
        this.httpService.post(fullApiUrl, input).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    private async CreateNursingOrderDetailsAndCompleteOrder(): Promise<void> {
        //TODO ASLI
        /*for (let nursingOrder of this._Consultation.SingleNursingOrders) {
            if (nursingOrder.CurrentStateDefID === SingleNursingOrder.SingleNursingOrderStates.New) {
                let periodicOrderDetailList: Array<PeriodicOrderDetail> = (await PeriodicOrderService.CreateOrderDetails(nursingOrder));
                for (let periodicOrderDetail of periodicOrderDetailList) {
                    nursingOrder.OrderDetails.push(periodicOrderDetail);
                }
                nursingOrder.Update();
                nursingOrder.CurrentStateDefID = SingleNursingOrder.SingleNursingOrderStates.Planned;
            }
        }*/
    }
    private async CreateProcedureOrderDetailsAndCompleteOrder(): Promise<void> {
        for (let procedureOrder of this._Consultation.ProcedureOrders) {
            if (procedureOrder.CurrentStateDefID === ProcedureOrder.ProcedureOrderStates.New) {
                //procedureOrder.CreateOrderDetails();
                procedureOrder.Update();
                procedureOrder.CurrentStateDefID = ProcedureOrder.ProcedureOrderStates.Planned;
            }
        }
    }
    private async IsDentalSpeciality(): Promise<boolean> {
        if (this._Consultation.FromResource !== null) {
            for (let resSpeciality of this._Consultation.FromResource.ResourceSpecialities) {
                if (resSpeciality.Speciality !== null && (resSpeciality.Speciality.Code === "5100" || resSpeciality.Speciality.Code === "5200" || resSpeciality.Speciality.Code === "5300" || resSpeciality.Speciality.Code === "5400" || resSpeciality.Speciality.Code === "5500" || resSpeciality.Speciality.Code === "5600" || resSpeciality.Speciality.Code === "5700"))
                    return true;
            }
        }
        return false;
    }
    private async ttbutton11_Click(): Promise<void> {
        this.CreateNewConsultationRequest();
    }
    protected async BarcodeRead(value: string): Promise<void> {
        /* super.BarcodeRead(value);
         let barcode: string = (await CommonService.PrepareBarcode(value));
         let material: Material = null;
         let materials: Array<any> = this._Consultation.ObjectContext.QueryObjects("MATERIAL", "BARCODE='" + barcode + "'");
         let findMaterials: Array<Material> = new Array<Material>();
         if (materials.length === 0) {
             let productDefinitions: Array<any> = this._Consultation.ObjectContext.QueryObjects("PRODUCTDEFINITION", "PRODUCTNUMBER ='" + barcode + "'");
             if (productDefinitions.length > 0) {
                 for (let product of productDefinitions) {
                     let mpl: Array<any> = this._Consultation.ObjectContext.QueryObjects("MATERIALPRODUCTLEVEL", "PRODUCT=" + ConnectionManager.GuidToString(product.ObjectID));
                     for (let level of mpl) {
                         let store: Store = this.GetStore(this._Consultation.ObjectDef);
                         let inheld: number = level.Material.StockInheld(store);
                         //Stock stock = store.GetStock(level.Material);
                         if (inheld > 0)
                             findMaterials.push(level.Material);
                     }
                 }
                 if (findMaterials.length === 1)
                     material = findMaterials[0];
                 else if (findMaterials.length > 1) {
                     let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                     for (let m of findMaterials) {
                         multiSelectForm.AddMSItem(m.Name, m.Name, m);
                     }
                     let key: string = multiSelectForm.GetMSItem(this.ParentForm, "Malzeme seçin");
                     if (String.isNullOrEmpty(key))
                         TTVisual.InfoBox.Show("Herhangibir malzeme seçilmedi.", MessageIconEnum.ErrorMessage);
                     else material = multiSelectForm.MSSelectedItemObject as Material;
                 }
                 else TTVisual.InfoBox.Show(barcode + " UBB/Barkodlu malzeme bulunamadı.", MessageIconEnum.ErrorMessage);
             }
             else {
                 TTVisual.InfoBox.Show(barcode + " UBB/Barkodlu malzeme bulunamadı.", MessageIconEnum.ErrorMessage);
             }
         }
         else if (materials.length === 1)
             material = <Material>materials[0];
         if (material !== null) {
             let retAmount: string = TTVisual.InputForm.GetText("Sarf Edilecek Miktarı Giriniz.");
             let amount: Currency = 0;
             if (String.isNullOrEmpty(retAmount) === false) {
                 if (CurrencyType.TryConvertFrom(retAmount, false, amount) === false)
                     throw new TTException((await SystemMessageService.GetMessageV3(1192, [retAmount.toString()])));
             }
             let baseTreatmentMaterial: BaseTreatmentMaterial = new BaseTreatmentMaterial(this._Consultation.ObjectContext);
             baseTreatmentMaterial.UBBCode = barcode;
             baseTreatmentMaterial.Material = material;
             baseTreatmentMaterial.Amount = amount;
         }*/
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        await super.PostScript(transDef);
    }
    protected async PrapareFormToShow(frm: TTVisual.TTForm): Promise<void> {
        /* frm.ObjectUpdated += new ObjectUpdatedDelegate(ShowAction_ObjectUpdated);
         frm.GetTemplates = this.GetTemplates;
         frm.SaveTemplate = this.SaveTemplate;
         frm.TemplateSelected = this.TemplateSelected;*/
    }
    protected async PreScript() {
        await super.PreScript();
        if (this._Consultation.CurrentStateDefID == Consultation.ConsultationStates.Cancelled || this._Consultation.CurrentStateDefID == Consultation.ConsultationStates.Completed)
            this.isSaveAndCancelCommandVisible = false;
        else
            this.isSaveAndCancelCommandVisible = true;
        //TODO(await EpisodeActionService.CheckPaid(this._Consultation));
        if (this._Consultation.CurrentStateDefID == Consultation.ConsultationStates.Consultation) {
            //this.SetProcedureDoctorAsCurrentResource();
            if (this._Consultation.ProcessDate === null)
                this._Consultation.ProcessDate = (await CommonService.RecTime());
        }

        this.hasRequestedProceduresForm = true;
        //Request -> RequestAcception PostScript
        //if (this._Consultation.Episode.EmergencyPatientStatusInfo !== null)
        //    this._Consultation.Episode.EmergencyPatientStatusInfo.PatientStatus = EmergencyPatientStatusInfoEnum.ConsultationRequested;
    }
    protected async ShowAction_ObjectUpdated(ttObject: TTObject, contextSaved: boolean): Promise<void> {
        ttObject.ObjectContext.Save();
        contextSaved = true;
    }
    public async CreateNewAnesthesiaConsultation(): Promise<void> {
        //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
        ////SaveContextForNewDiagnose();
        //TTObjectClasses.AnesthesiaConsultation consultation;
        ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
        ////TTObjectContext objectContext = new TTObjectContext(false);
        //Guid savePointGuid = this._Consultation.ObjectContext.BeginSavePoint();
        //try
        //{
        //    consultation = new TTObjectClasses.AnesthesiaConsultation(this._Consultation.ObjectContext, this._Consultation);
        //    TTForm frm = TTForm.GetEditForm(consultation);
        //    this.PrapareFormToShow(frm);
        //    if (frm.ShowEdit(this.FindForm(), consultation) == DialogResult.OK)
        //        this._Consultation.ObjectContext.Save();
        //    else
        //        this._Consultation.ObjectContext.RollbackSavePoint(savePointGuid);
        //}
        //catch (Exception ex)
        //{
        //    this._Consultation.ObjectContext.RollbackSavePoint(savePointGuid);
        //    InfoBox.Show(ex);
        //}
        //finally
        //{
        //    //objectContext.Dispose();
        //}
        let a = 1;
    }
    public async CreateNewConsultationFromOtherHospRequest(): Promise<void> {
        //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
        ////SaveContextForNewDiagnose();
        //ConsultationFromOtherHospital consultationFromOtherHospital;
        ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
        ////TTObjectContext objectContext = new TTObjectContext(false);
        //Guid savePointGuid = this._Consultation.ObjectContext.BeginSavePoint();

        //try
        //{
        //    consultationFromOtherHospital = new ConsultationFromOtherHospital(this._Consultation.ObjectContext, this._Consultation);
        //    TTForm frm = TTForm.GetEditForm(consultationFromOtherHospital);
        //    this.PrapareFormToShow(frm);
        //    if (frm.ShowEdit(this.FindForm(), consultationFromOtherHospital) == DialogResult.OK)
        //        this._Consultation.ObjectContext.Save();
        //    else
        //        this._Consultation.ObjectContext.RollbackSavePoint(savePointGuid);
        //}
        //catch (Exception ex)
        //{
        //    this._Consultation.ObjectContext.RollbackSavePoint(savePointGuid);
        //    InfoBox.Show(ex);
        //}
        //finally
        //{
        //    //objectContext.Dispose();
        //}
        let a = 1;
    }
    public async CreateNewConsultationRequest(): Promise<void> {
        //            MultiSelectForm pForm = new MultiSelectForm();
        //            pForm.AddMSItem("Normal Konsültasyon", "ConsultationRequest");
        //            pForm.AddMSItem("Diş Konsültasyonu", "DentalConsultationRequest");
        //            string consultationType = pForm.GetMSItem(this, "Konsültasyon Tipini Seçiniz");
        //            pForm.ClearMSItems();
        //            if(consultationType == "ConsultationRequest")
        this.CreateNewNormalConsultationRequest();
        //            else if (consultationType == "DentalConsultationRequest")
        //                CreateNewDentalConsultationRequest();
        //            else
        //            {
        //                InfoBox.Show("Konsültasyon isteğinden vazgeçildi.");
        //                return;
        //            }
        let a = 1;
    }
    public async CreateNewDentalConsultationRequest(): Promise<void> {
        //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
        ////SaveContextForNewDiagnose();
        //DentalConsultationRequest dentalConsultationRequest;
        ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
        ////TTObjectContext objectContext = new TTObjectContext(false);
        //Guid savePointGuid = this._Consultation.ObjectContext.BeginSavePoint();
        //try
        //{
        //    dentalConsultationRequest = new DentalConsultationRequest(this._Consultation.ObjectContext, this._Consultation);
        //    TTForm frm = TTForm.GetEditForm(dentalConsultationRequest);
        //    this.PrapareFormToShow(frm);
        //    if (frm.ShowEdit(this.FindForm(), dentalConsultationRequest) == DialogResult.OK)
        //        this._Consultation.ObjectContext.Save();
        //    else
        //        this._Consultation.ObjectContext.RollbackSavePoint(savePointGuid);
        //}
        //catch (Exception ex)
        //{
        //    this._Consultation.ObjectContext.RollbackSavePoint(savePointGuid);
        //    InfoBox.Show(ex);
        //}
        let a = 1;
    }
    public async CreateNewEpicrisisReport(): Promise<void> {
        //            CreatingEpicrisis epicrisisReport;
        //            CreatingEpicrisis tempEpicrisisReport;
        //            TTObjectContext objectContext = new TTObjectContext(false);
        //            Guid savePointGuid = objectContext.BeginSavePoint();
        //            try
        //            {
        //                InPatientPhysicianApplication inPatientPhysicianApplication = null;
        //                if (this._ConsultationProcedure is InPatientPhysicianApplication)
        //                    inPatientPhysicianApplication = (InPatientPhysicianApplication)this._ConsultationProcedure;
        //                else
        //                {
        //                    foreach (EpisodeAction ea in _ConsultationProcedure.Episode.EpisodeActions)
        //                    {
        //                        if (ea is InPatientPhysicianApplication && ea.CurrentStateDefID == CreatingEpicrisis.States.Completed)
        //                            inPatientPhysicianApplication = (InPatientPhysicianApplication)ea;
        //                    }
        //                }
        //
        //                // if (this._ConsultationProcedure.Episode.MainSpeciality.Code == "4400")
        //
        //                if (inPatientPhysicianApplication != null || this._ConsultationProcedure.Episode.MainSpeciality.Code == "4400")
        //                {
        //                    if (this._ConsultationProcedure.Episode.MainSpeciality.Code != null && this._ConsultationProcedure.Episode.MainSpeciality.Code == "4400")
        //                    {
        //                        if (inPatientPhysicianApplication == null)
        //                        {
        //                            epicrisisReport = new CreatingEpicrisis(objectContext, this._ConsultationProcedure);
        //                            TTForm frm = TTForm.GetEdit Form(epicrisisReport);
        //                            this.PrapareF ormToShow(frm);
        //
        //                            if (frm.Show Edit(this.FindForm(), epicrisisReport) == DialogResult.OK)
        //                            {
        //                                objectContext.Save();
        //                            }
        //
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (inPatientPhysicianApplication.MyEpicrisisReport() == null)
        //                        {
        //                            epicrisisReport = new CreatingEpicrisis(objectContext, this._ConsultationProcedure);
        //                        }
        //                        else
        //                        {
        //                            tempEpicrisisReport = inPatientPhysicianApplication.MyEpicrisisReport();
        //                            epicrisisReport = (CreatingEpicrisis)objectContext.GetObject(tempEpicrisisReport.ObjectID, "CreatingEpicrisis");
        //                        }
        //
        //
        //                        TTForm frm = TTForm.GetEditForm(epicrisisReport);
        //                        this.Prap areFormToShow(frm);
        //                        if (frm.Show Edit(this.FindForm(), epicrisisReport) == DialogResult.OK)
        //                            objectContext.Save();
        //                    }
        //                }
        //                else
        //                {
        //                    InfoBox.S how("Hastanın Klinik Doktor İşlemlerine Bulunmamakta.");
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                objectContext.RollbackSavePoint(savePointGuid);
        //                InfoBox.S how(ex);
        //            }
        //            finally
        //            {
        //                objectContext.Dispose();
        //            }
        let a = 1;
    }
    public async CreateNewForensicMedicalReport(): Promise<void> {
        //            ForensicMedicalReport forensicMedicalReport;
        //            TTObjectContext objectContext = new TTObjectContext(false);
        //            Guid savePointGuid = objectContext.BeginSavePoint();
        //            try
        //            {
        //                forensicMedicalReport = new ForensicMedicalReport(objectContext, this._ConsultationProcedure);
        //                TTForm frm = TTForm.GetEdi tForm(forensicMedicalReport);
        //                this.PrapareFormToShow(frm);
        //                if (frm.ShowE dit(this.FindForm(), forensicMedicalReport) == DialogResult.OK)
        //                    objectContext.Save();
        //                else
        //                    objectContext.RollbackSavePoint(savePointGuid);
        //            }
        //            catch (Exception ex)
        //            {
        //                objectContext.RollbackSavePoint(savePointGuid);
        //                InfoBox.Sh ow(ex);
        //            }
        //            finally
        //            {
        //                objectContext.Dispose();
        //            }
        let a = 1;
    }
    public async CreateNewHCExaminationFromOtherDepartments(): Promise<void> {
        //            HealthCommitteeExaminationFromOtherDepartments hcefod;
        //            TTObjectContext objectContext = new TTObjectContext(false);
        //            Guid savePointGuid = objectContext.BeginSavePoint();
        //            try
        //            {
        //                hcefod = new HealthCommitteeExaminationFromOtherDepartments(objectContext, this._ConsultationProcedure);
        //                TTForm frm = TTForm.GetEditForm(hcefod);
        //                this.PrapareFormToShow(frm);
        //                if (frm.ShowEdit(this.FindForm(), hcefod) == DialogResult.OK)
        //                    objectContext.Save();
        //            }
        //            catch (Exception ex)
        //            {
        //                objectContext.RollbackSavePoint(savePointGuid);
        //                InfoBox.Show(ex);
        //            }
        //            finally
        //            {
        //                objectContext.Dispose();
        //            }
        let a = 1;
    }
    public async CreateNewHealthCommittee(): Promise<void> {
        //            HealthCommittee healthCommittee;
        //            TTObjectContext objectContext = new TTObjectContext(false);
        //            Guid savePointGuid = objectContext.BeginSavePoint();
        //            try
        //            {
        //                healthCommittee = new HealthCommittee(objectContext, this._ConsultationProcedure);
        //                TTForm frm = TTForm.GetEdit Form(healthCommittee);
        //                this.PrapareF ormToShow(frm);
        //                if (frm.Show Edit(this.FindForm(), healthCommittee) == DialogResult.OK)
        //                    objectContext.Save();
        //            }
        //            catch (Exception ex)
        //            {
        //                objectContext.RollbackSavePoint(savePointGuid);
        //                InfoBox.S how(ex);
        //            }
        //            finally
        //            {
        //                objectContext.Dispose();
        //            }
        let a = 1;
    }
    public async CreateNewHealthCommitteeOfProfessors(): Promise<void> {
        //            HealthCommitteeOfProfessors profHC;
        //            TTObjectContext objectContext = new TTObjectContext(false);
        //            Guid savePointGuid = objectContext.BeginSavePoint();
        //            try
        //            {
        //                profHC = new HealthCommitteeOfProfessors(objectContext, this._ConsultationProcedure);
        //                TTForm frm = TTForm.Get EditForm(profHC);
        //                this.Prapare FormToShow(frm);
        //                if (frm.Show Edit(this.FindForm(), profHC) == DialogResult.OK)
        //                    objectContext.Save();
        //            }
        //            catch (Exception ex)
        //            {
        //                objectContext.RollbackSavePoint(savePointGuid);
        //                InfoBox.S how(ex);
        //            }
        //            finally
        //            {
        //                objectContext.Dispose();
        //            }
        let a = 1;
    }
    public async CreateNewHealthCommitteeWithThreeSpecialist(): Promise<void> {
        //            HealthCommitteeWithThreeSpecialist hcw3s;
        //            TTObjectContext objectContext = new TTObjectContext(false);
        //            Guid savePointGuid = objectContext.BeginSavePoint();
        //            try
        //            {
        //                hcw3s = new HealthCommitteeWithThreeSpecialist(objectContext, this._ConsultationProcedure);
        //                TTForm frm = TTForm.Get EditForm(hcw3s);
        //                this.Prapare FormToShow(frm);
        //                if (frm.Show Edit(this.FindForm(), hcw3s) == DialogResult.OK)
        //                    objectContext.Save();
        //            }
        //            catch (Exception ex)
        //            {
        //                objectContext.RollbackSavePoint(savePointGuid);
        //                InfoBox.S how(ex);
        //            }
        //            finally
        //            {
        //                objectContext.Dispose();
        //            }
        let a = 1;
    }
    public async CreateNewLaboratoryRequest(objDef: TTObjectDef, resSectionGuid: Guid): Promise<void> {
        //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
        ////SaveContextForNewDiagnose();
        ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
        ////TTObjectContext objectContext = new TTObjectContext(false);
        //Guid savePointGuid = this._Consultation.ObjectContext.BeginSavePoint();
        //try
        //{
        //    EpisodeAction testRequest = null;
        //    if (objDef.ID == TTObjectDefManager.Instance.GetObjectDef(typeof(Genetic)).ID)
        //        testRequest = new Genetic(this._Consultation.ObjectContext, this._Consultation);
        //    else if (objDef.ID == TTObjectDefManager.Instance.GetObjectDef(typeof(LaboratoryRequest)).ID)
        //    {
        //        if (resSectionGuid != null)
        //        {
        //            ResSection resSection = (ResSection)_Consultation.ObjectContext.GetObject((Guid)resSectionGuid, typeof(ResSection).Name);
        //            testRequest = new LaboratoryRequest(this._Consultation.ObjectContext, this._Consultation, resSection);
        //        }
        //        else
        //            testRequest = new LaboratoryRequest(this._Consultation.ObjectContext, this._Consultation);
        //    }
        //    else if (objDef.ID == TTObjectDefManager.Instance.GetObjectDef(typeof(NuclearMedicine)).ID)
        //        testRequest = new NuclearMedicine(this._Consultation.ObjectContext, this._Consultation);
        //    else if (objDef.ID == TTObjectDefManager.Instance.GetObjectDef(typeof(PathologyRequest)).ID)
        //        testRequest = new PathologyRequest(this._Consultation.ObjectContext, this._Consultation);
        //    else if (objDef.ID == TTObjectDefManager.Instance.GetObjectDef(typeof(Radiology)).ID)
        //        testRequest = new Radiology(this._Consultation.ObjectContext, this._Consultation);

        //    TTForm frm = TTForm.GetEditForm(testRequest);
        //    this.PrapareFormToShow(frm);
        //    if (frm.ShowEdit(this.FindForm(), testRequest) == DialogResult.OK)
        //        this._Consultation.ObjectContext.Save();
        //    else
        //        this._Consultation.ObjectContext.RollbackSavePoint(savePointGuid);
        //}
        //catch (Exception ex)
        //{
        //    this._Consultation.ObjectContext.RollbackSavePoint(savePointGuid);
        //    InfoBox.Show(ex);
        //}
        //finally
        //{
        //    //objectContext.Dispose();
        //}
        let a = 1;
    }
    public async CreateNewManipulationRequest(): Promise<void> {
        //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
        ////SaveContextForNewDiagnose();
        //ManipulationRequest manipulationRequest;
        ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
        ////TTObjectContext objectContext = new TTObjectContext(false);
        //Guid savePointGuid = this._Consultation.ObjectContext.BeginSavePoint();
        //try
        //{
        //    manipulationRequest = new ManipulationRequest(this._Consultation.ObjectContext, this._Consultation);
        //    TTForm frm = TTForm.GetEditForm(manipulationRequest);
        //    this.PrapareFormToShow(frm);
        //    if (frm.ShowEdit(this.FindForm(), manipulationRequest) == DialogResult.OK)
        //        this._Consultation.ObjectContext.Save();
        //    else
        //        this._Consultation.ObjectContext.RollbackSavePoint(savePointGuid);
        //}
        //catch (Exception ex)
        //{
        //    this._Consultation.ObjectContext.RollbackSavePoint(savePointGuid);
        //    InfoBox.Show(ex);
        //}
        //finally
        //{
        //    //objectContext.Dispose();
        //}
        let a = 1;
    }
    public async CreateNewNormalConsultationRequest(): Promise<void> {
        //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
        ////SaveContextForNewDiagnose();
        //Consultation consultationRequest;
        ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
        ////TTObjectContext objectContext = new TTObjectContext(false);
        //Guid savePointGuid = this._Consultation.ObjectContext.BeginSavePoint();
        //try
        //{
        //    consultationRequest = new Consultation(this._Consultation.ObjectContext, this._Consultation);
        //    TTForm frm = TTForm.GetEditForm(consultationRequest);
        //    this.PrapareFormToShow(frm);
        //    if (frm.ShowEdit(this.FindForm(), consultationRequest) == DialogResult.OK)
        //        this._Consultation.ObjectContext.Save();
        //    else
        //        this._Consultation.ObjectContext.RollbackSavePoint(savePointGuid);
        //}
        //catch (Exception ex)
        //{
        //    this._Consultation.ObjectContext.RollbackSavePoint(savePointGuid);
        //    InfoBox.Show(ex);
        //}
        //finally
        //{
        //    //objectContext.Dispose();
        //}
        let a = 1;
    }
    public async CreateNewOutPatientPrescription(): Promise<void> {
        if (this._Consultation.Episode.PatientStatus != PatientStatusEnum.Inpatient)
            this.CreateOutPatientPrescription(this._Consultation.ObjectContext);
        else {
            TTVisual.InfoBox.Show(i18n("M11290", "Ayaktan Hasta Reçetesi sadece ayaktan hastaya başlatılır."));
            return;
        }
    }
    public async CreateNewParticipatnFreeDrugReport(): Promise<void> {
        //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
        //ParticipatnFreeDrugReport participatnFreeDrugReport;
        //TTObjectContext objectContext = new TTObjectContext(false);
        //Guid savePointGuid = objectContext.BeginSavePoint();
        //try
        //{
        //    participatnFreeDrugReport = new ParticipatnFreeDrugReport(objectContext, this._Consultation);
        //    TTForm frm = TTForm.GetEditForm(participatnFreeDrugReport);
        //    this.PrapareFormToShow(frm);
        //    if (frm.ShowEdit(this.FindForm(), participatnFreeDrugReport) == DialogResult.OK)
        //        objectContext.Save();
        //}
        //catch (Exception ex)
        //{
        //    objectContext.RollbackSavePoint(savePointGuid);
        //    InfoBox.Show(ex);
        //}
        //finally
        //{
        //    objectContext.Dispose();
        //}
        let a = 1;
    }
    public async CreateNewUnavailableToWorkReport(): Promise<void> {
        //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
        //UnavailableToWorkReport unavailableToWorkReport;
        //TTObjectContext objectContext = new TTObjectContext(false);
        //Guid savePointGuid = objectContext.BeginSavePoint();
        //try
        //{
        //    unavailableToWorkReport = new UnavailableToWorkReport(objectContext, this._Consultation);
        //    TTForm frm = TTForm.GetEditForm(unavailableToWorkReport);
        //    this.PrapareFormToShow(frm);
        //    if (frm.ShowEdit(this.FindForm(), unavailableToWorkReport) == DialogResult.OK)
        //        objectContext.Save();
        //}
        //catch (Exception ex)
        //{
        //    objectContext.RollbackSavePoint(savePointGuid);
        //    InfoBox.Show(ex);
        //}
        //finally
        //{
        //    objectContext.Dispose();
        //}
        let a = 1;
    }
    public async CreateOutPatientPrescription(objectContext: TTObjectContext): Promise<void> {
        //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
        //OutPatientPrescription outPatientPrescription;
        //Guid savePointGuid = objectContext.BeginSavePoint();
        //try
        //{
        //    outPatientPrescription = new OutPatientPrescription(objectContext, this._Consultation);
        //    //glassesReport = new GlassesReport(objectContext);
        //    TTForm frm = TTForm.GetEditForm(outPatientPrescription);
        //    this.PrapareFormToShow(frm);
        //    if (frm.ShowEdit(this.FindForm(), outPatientPrescription) == DialogResult.OK)
        //        objectContext.Save();
        //    else
        //        objectContext.RollbackSavePoint(savePointGuid);
        //}
        //catch (Exception ex)
        //{
        //    objectContext.RollbackSavePoint(savePointGuid);
        //    InfoBox.Show(ex);
        //}
        //finally
        //{
        //    //episodeAction ın context i gönderildiği zaman dispose etmek doğru değil.
        //    //objectContext.Dispose();
        //}
        let a = 1;
    }
    public async FillHealthCommiteeActionsGrid(HealthCommiteeActions: TTVisual.ITTGrid): Promise<void> {
        /*let hospID: Guid = new Guid((await SystemParameterService.GetParameterValue("HOSPITAL", Guid.Empty.toString())));
        let hospital: ResHospital = <ResHospital>this._Consultation.ObjectContext.GetObject(hospID, typeof ResHospital);
        let healthCommiteeList: Array<HealthCommittee>;
        //if (this._Consultation.Episode.Patient.IsSmartCardActive == true)
        //    healthCommiteeList = HealthCommittee.GetAllHealthCommiteesOfPatient(this._Consultation.ObjectContext, this._Consultation.Episode.Patient.ObjectID.ToString());
        //else
        healthCommiteeList = (await HealthCommitteeService.GetHealthCommiteesOfEpisode(this._Consultation.ObjectContext, this._Consultation.Episode.ObjectID.toString()));
        for (let healthCommittee of healthCommiteeList) {
            let gridRow: TTVisual.ITTGridRow = HealthCommiteeActions.Rows.push();
            gridRow.Cells["Hospital"].Value = hospital.Name; //şimdilik şu anki XXXXXXnin ismini getiriyor.
            gridRow.Cells["HealthCommiteeActionID"].Value = (healthCommittee.ID !== null ? healthCommittee.ID.toString() : "");
            gridRow.Cells["HealthCommiteeActionDate"].Value = healthCommittee.ActionDate;
            gridRow.Cells["HCObjectID"].Value = healthCommittee.ObjectID.toString();
        }
        */
    }
    public async FillLaboratoryResultsGrid(LaboratoryResultsGrid: TTVisual.ITTGrid): Promise<void> {
        /*let startDate: Date = Date.MinValue;
        let endDate: Date = Date.MaxValue;
        LaboratoryResultsGrid.Rows.Clear();
        let testProcedureList: Array<SubActionProcedure>;
        // akıllı kart devreye girdiğinde commentler açılacaktır
        // if (this._ConsultationProcedure.Episode.Patient.IsSmartCardActive == true)
        testProcedureList = (await SubActionProcedureService.GetTestsByPatient(this._Consultation.ObjectContext, this._Consultation.Episode.Patient.ObjectID.toString(), Common.RecTime().AddMonths(-3)));
        //            else
        //            {
        //                Info Box.Show("Hastanın Akıllı Kartı Takılı olmadığı için yalnızca bu vakaya ait Tetkikler Listelenecektir");
        //                testProcedureList = SubActionProcedure.GetTestsByEpisode(this._ConsultationProcedure.ObjectContext, subactionObjectDefName, testProcedureObjectID, this._ConsultationProcedure.Episode.ObjectID.ToString());
        //            }
        for (let testProcedure of testProcedureList) {
            // rapor için parametre
            if (testProcedure.CurrentStateDef.Status !== StateStatusEnum.Cancelled) {
                let gridRow: TTVisual.ITTGridRow = LaboratoryResultsGrid.Rows.push();
                gridRow.Cells["ProcedureDate"].Value = testProcedure.WorkListDate;
                gridRow.Cells["Procedure"].Value = (testProcedure.ProcedureObject !== null ? testProcedure.ProcedureObject.Name : "");
                if (testProcedure instanceof GeneticTest)
                    gridRow.Cells["ProcedureResult"].Value = (<GeneticTest>testProcedure).Genetic.Report;
                else if (testProcedure instanceof NuclearMedicineTest)
                    gridRow.Cells["ProcedureResult"].Value = (<NuclearMedicineTest>testProcedure).NuclearMedicine.Report;
                else if (testProcedure instanceof LaboratoryProcedure)
                    gridRow.Cells["ProcedureResult"].Value = (await CommonService.GetRTFOfTextString((<LaboratoryProcedure>testProcedure).Result));
                else if (testProcedure instanceof PathologyTestProcedure) {
                    let patReports: string = "Makroskopi Raporu\r\n" + (await CommonService.GetTextOfRTFString((<PathologyTestProcedure>testProcedure).Pathology.ReportMacroscopi.toString())) + "\r\n";
                    patReports += "Mikroskopi Raporu\r\n" + (await CommonService.GetTextOfRTFString((<PathologyTestProcedure>testProcedure).Pathology.ReportMicroscopi.toString())) + "\r\n";
                    patReports += "Doku İşlemi\r\n" + (await CommonService.GetTextOfRTFString((<PathologyTestProcedure>testProcedure).Pathology.ReportTissueProcedure.toString())) + "\r\n";
                    //patReports += "Ek İşlemler\r\n" + Common.GetTextOfRTFString(((PathologyTestProcedure)testProcedure).PathologyRequest.ReportAdditionalOperation) + "\r\n";
                    gridRow.Cells["ProcedureResult"].Value = (await CommonService.GetRTFOfTextString(patReports));
                }
                else if (testProcedure instanceof RadiologyTest)
                    gridRow.Cells["ProcedureResult"].Value = (<RadiologyTest>testProcedure).Report;
                gridRow.Cells["ObjectID"].Value = testProcedure.ObjectID;
            }
        }
        */
    }
    public async FillOldConsultationsGrid(ConsultationGrid: TTVisual.ITTGrid): Promise<void> {
        /*let consFromOtherHospList: Array<EpisodeAction>;
        //if (this._Consultation.Episode.Patient.IsSmartCardActive == true)
        //    consFromOtherHospList = EpisodeAction.GetAllConsFromOtherHospOfPatient(this._Consultation.ObjectContext, this._Consultation.Episode.Patient.ObjectID.ToString());
        //else
        consFromOtherHospList = (await EpisodeActionService.GetConsFromOtherHospOfEpisode(this._Consultation.ObjectContext, this._Consultation.Episode.ObjectID.toString()));
        for (let ea of consFromOtherHospList) {
            let gridRow: TTVisual.ITTGridRow = ConsultationGrid.Rows.push();
            gridRow.Cells["ConsultationDate"].Value = ea.ActionDate;
            if (ea instanceof ConsultationFromOtherHospital) {
                let consFromOtherHosp: ConsultationFromOtherHospital = <ConsultationFromOtherHospital>ea;
                if (consFromOtherHosp.RequesterHospital !== null)
                    gridRow.Cells["RequesterHospital"].Value = consFromOtherHosp.RequesterHospital.Name;
                gridRow.Cells["RequesterDepartment"].Value = consFromOtherHosp.RequesterResourceName;
                if (consFromOtherHosp.RequestedReferableHospital !== null && consFromOtherHosp.RequestedReferableHospital.ResOtherHospital !== null)
                    gridRow.Cells["RequestedHospital"].Value = consFromOtherHosp.RequestedReferableHospital.ResOtherHospital.Name;
                else if (consFromOtherHosp.RequestedExternalHospital !== null)
                    gridRow.Cells["RequestedHospital"].Value = consFromOtherHosp.RequestedExternalHospital.Name;
                if (consFromOtherHosp.RequestedReferableResource !== null)
                    gridRow.Cells["RequestedDepartment"].Value = consFromOtherHosp.RequestedReferableResource.ResourceName;
                else if (consFromOtherHosp.RequestedExternalDepartment !== null)
                    gridRow.Cells["RequestedDepartment"].Value = consFromOtherHosp.RequestedExternalDepartment.Name;
                gridRow.Cells["RequestReason"].Value = (await CommonService.GetRTFOfTextString(consFromOtherHosp.RequestDescription));
                if (consFromOtherHosp.ConsultationResultAndOffers !== null)
                    gridRow.Cells["ConsultationResultAndOffer"].Value = (await CommonService.GetRTFOfTextString(consFromOtherHosp.ConsultationResultAndOffers.toString()));
            }
        }
        let hospID: Guid = new Guid((await SystemParameterService.GetParameterValue("HOSPITAL", Guid.Empty.toString())));
        let hospital: ResHospital = <ResHospital>this._Consultation.ObjectContext.GetObject(hospID, typeof ResHospital);
        let consProcedureList: Array<SubActionProcedure> = (await SubActionProcedureService.GetAllConsultationProcOfPatient(this._Consultation.ObjectContext, this._Consultation.Episode.Patient.ObjectID.toString()));
        for (let spf of consProcedureList) {
            let gridRow: TTVisual.ITTGridRow = ConsultationGrid.Rows.push();
            gridRow.Cells["ConsultationDate"].Value = spf.ActionDate;
            if (spf instanceof ConsultationProcedure) {
                let consProcedure: ConsultationProcedure = <ConsultationProcedure>spf;
                if (hospital !== null) {
                    gridRow.Cells["RequesterHospital"].Value = hospital.Name;
                    gridRow.Cells["RequestedHospital"].Value = hospital.Name;
                }
                gridRow.Cells["RequesterDepartment"].Value = (consProcedure.Consultation.RequesterResource !== null ? consProcedure.Consultation.RequesterResource.Name : "");
                gridRow.Cells["RequestedDepartment"].Value = (consProcedure.Consultation.MasterResource !== null ? consProcedure.Consultation.MasterResource.Name : "");
                gridRow.Cells["RequestReason"].Value = consProcedure.Consultation.RequestDescription;
                gridRow.Cells["ConsultationResultAndOffer"].Value = consProcedure.Consultation.ConsultationResultAndOffers;
            }
        }
        let anesthesiaConsList: Array<EpisodeAction> = (await EpisodeActionService.GetAllAnesthesiaConsultationOfPatient(this._Consultation.ObjectContext, this._Consultation.Episode.Patient.ObjectID.toString()));
        for (let ea of anesthesiaConsList) {
            let gridRow: TTVisual.ITTGridRow = ConsultationGrid.Rows.push();
            gridRow.Cells["ConsultationDate"].Value = ea.ActionDate;
            if (ea instanceof AnesthesiaConsultation) {
                let anesthesiaConsultation: AnesthesiaConsultation = <AnesthesiaConsultation>ea;
                if (hospital !== null) {
                    gridRow.Cells["RequesterHospital"].Value = hospital.Name;
                    gridRow.Cells["RequestedHospital"].Value = hospital.Name;
                }
                gridRow.Cells["RequesterDepartment"].Value = (anesthesiaConsultation.FromResource !== null ? anesthesiaConsultation.FromResource.Name : "");
                gridRow.Cells["RequestedDepartment"].Value = (anesthesiaConsultation.MasterResource !== null ? anesthesiaConsultation.MasterResource.Name : "");
                gridRow.Cells["RequestReason"].Value = anesthesiaConsultation.ConsultationRequestNote;
                gridRow.Cells["ConsultationResultAndOffer"].Value = anesthesiaConsultation.ConsultationResult;
            }
        }
        */
    }
    public async FillOldManipulationsGrid(ManipulationGrid: TTVisual.ITTGrid): Promise<void> {
        /* let manipulationProcedureList: Array<ManipulationProcedure>;
         //            if (this._ConsultationProcedure.Episode.Patient.IsSmartCardActive == true)
         //                manipulationProcedureList = ManipulationProcedure.GetAllManipulationProceduresOfPatient(this._ConsultationProcedure.ObjectContext, this._ConsultationProcedure.Episode.Patient.ObjectID.ToString());
         //            else
         manipulationProcedureList = (await ManipulationProcedureService.GetManipulationProceduresOfEpisode(this._Consultation.ObjectContext, this._Consultation.Episode.ObjectID.toString()));
         for (let mp of manipulationProcedureList) {
             let gridRow: TTVisual.ITTGridRow = ManipulationGrid.Rows.push();
             gridRow.Cells["ManipulationActionDate"].Value = mp.ActionDate;
             if (mp.ProcedureObject !== null)
                 gridRow.Cells["ProcedureObject"].Value = mp.ProcedureObject.ObjectID;
             gridRow.Cells["Emergency"].Value = mp.Emergency;
             if (mp.ProcedureDepartment !== null)
                 gridRow.Cells["Department"].Value = mp.ProcedureDepartment.ObjectID;//emin değilim
             if (mp.ProcedureDoctor !== null)
                 gridRow.Cells["ManipulationDoctor"].Value = mp.ProcedureDoctor.ObjectID;
             gridRow.Cells["Description"].Value = mp.Description;
         }
         */
    }
    public async FillOldPhysicianExaminationsGrid(PhysicianExaminationsGrid: TTVisual.ITTGrid): Promise<void> {
        /*let examList: Array<EpisodeAction> = (await EpisodeActionService.GetAllExaminationsOfPatient(this._Consultation.ObjectContext, this._Consultation.Episode.Patient.ObjectID.toString()));
        let examinationIndication: Object = null;
        for (let ea of examList) {
            if (ea instanceof PatientExamination) {
                let pa: PatientExamination = <PatientExamination>ea;
                examinationIndication = pa.PhysicalExamination;
            }
            else if (ea instanceof FollowUpExamination) {
                let fe: FollowUpExamination = <FollowUpExamination>ea;
                examinationIndication = fe.PhysicalExamination;
            }
            else if (ea instanceof InPatientPhysicianApplication) {
                let ippa: InPatientPhysicianApplication = <InPatientPhysicianApplication>ea;
                examinationIndication = ippa.PhysicalExamination;
            }
            if (examinationIndication !== null) {
                let gridRow: TTVisual.ITTGridRow = PhysicianExaminationsGrid.Rows.push();
                gridRow.Cells["ExaminationDateTime"].Value = ea.ActionDate.Value;
                gridRow.Cells["ExaminationIndication"].Value = examinationIndication;
            }
        }*/
    }
    public async FireNewDrugOrderIntroduction(): Promise<void> {
        //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
        ////SaveContextForNewDiagnose();
        //DrugOrderIntroduction drugOrderIntroduction;
        ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
        ////TTObjectContext objectContext = new TTObjectContext(false);
        //Guid savePointGuid = this._Consultation.ObjectContext.BeginSavePoint();
        //try
        //{
        //    drugOrderIntroduction = new DrugOrderIntroduction(this._Consultation.ObjectContext);
        //    drugOrderIntroduction.CurrentStateDefID = DrugOrderIntroduction.States.New;
        //    drugOrderIntroduction.Episode = _Consultation.Episode;
        //    TTForm frm = TTForm.GetEditForm(drugOrderIntroduction);
        //    this.PrapareFormToShow(frm);
        //    if (frm.ShowEdit(this.FindForm(), drugOrderIntroduction) == DialogResult.OK)
        //        this._Consultation.ObjectContext.Save();
        //    else
        //        this._Consultation.ObjectContext.RollbackSavePoint(savePointGuid);
        //}
        //catch (Exception ex)
        //{
        //    this._Consultation.ObjectContext.RollbackSavePoint(savePointGuid);
        //    InfoBox.Show(ex);
        //}
        //finally
        //{
        //    //objectContext.Dispose();
        //}
        let a = 1;
    }
    public async FireNewImportantMedicalInfo(): Promise<void> {
        //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
        ////            TTObject ttObject = this._ConsultationProcedure.Episode.Patient.ImportantMedicalInformation;
        ////            if (ttObject != null)
        ////            {
        ////                TTForm frm = TTForm.GetEditForm(ttObject);
        ////                if (frm != null)
        ////                {
        ////                    DialogResult dialog = frm.ShowReadOnly(this.FindForm(), ttObject);
        ////                }
        ////            }
        ////            else
        ////                InfoBox.Show("Hastaya ait Önemli Tıbbi Bilgi işlemi kaydedilmemiştir.", MessageIconEnum.InformationMessage);

        ////SaveContextForNewDiagnose();
        //ImportantMedicalInformation importantMedicalInformation;
        ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
        ////TTObjectContext objectContext = new TTObjectContext(false);
        //Guid savePointGuid = this._Consultation.ObjectContext.BeginSavePoint();
        //try
        //{
        //    importantMedicalInformation = new ImportantMedicalInformation(this._Consultation.ObjectContext);
        //    importantMedicalInformation.CurrentStateDefID = ImportantMedicalInformation.States.New;
        //    importantMedicalInformation.Episode = _Consultation.Episode;
        //    TTForm frm = TTForm.GetEditForm(importantMedicalInformation);
        //    this.PrapareFormToShow(frm);
        //    if (frm.ShowEdit(this.FindForm(), importantMedicalInformation) == DialogResult.OK)
        //        this._Consultation.ObjectContext.Save();
        //    else
        //        this._Consultation.ObjectContext.RollbackSavePoint(savePointGuid);
        //}
        //catch (Exception ex)
        //{
        //    this._Consultation.ObjectContext.RollbackSavePoint(savePointGuid);
        //    InfoBox.Show(ex);
        //}
        //finally
        //{
        //    //objectContext.Dispose();
        //}
        let a = 1;
    }
    public async MaximizeGroupTab(): Promise<void> {
        //GroupTab.Location = new Point(12, 12);
        //Size sizeGroupTab = new Size(945, 670);
        //GroupTab.Size = sizeGroupTab;
        //Size sizertfHistory = new Size(900, 550);
        //rtfHistory.Size = sizertfHistory;
        //_groupTabMaximized = true;
        //pnlLeft.Visible = false;
        //GroupIdentification.Visible = false;
        //ConsultationResultTab.Visible = false;
        let a = 1;
    }
    public async MinimizeGroupTab(): Promise<void> {
        //GroupTab.Location = new Point(501, 319);
        //Size sizeGroupTab = new Size(482, 354);
        //GroupTab.Size = sizeGroupTab;
        //Size sizertfHistory = new Size(468, 164);
        //rtfHistory.Size = sizertfHistory;
        //_groupTabMaximized = false;
        //pnlLeft.Visible = true;
        //GroupIdentification.Visible = true;
        //ConsultationResultTab.Visible = true;
        let a = 1;
    }
    public async SetProcedureDoctorAsCurrentResource(): Promise<void> {

        let user: ResUser = await UserHelper.CurrentResource;
        if (this._Consultation.CurrentStateDefID == Consultation.ConsultationStates.RequestAcception || this._Consultation.CurrentStateDefID == Consultation.ConsultationStates.Consultation) {
            if (user.UserType === UserTypeEnum.Doctor || user.UserType === UserTypeEnum.Dentist) {
                if (this._Consultation.ProcedureDoctor === null) {
                    this._Consultation.ProcedureDoctor = user;
                }
                else {
                    if(this._Consultation.ProcedureDoctor != undefined)
                    {
                    if (this._Consultation.ProcedureDoctor.ObjectID !== user.ObjectID) {
                        let msg: string = "İşlemin sorumlu doktoru :  " + this._Consultation.ProcedureDoctor.Name + " . \r\n \r\nİşlemi kaydettiğinizde sorumlu doktor olarak kaydedileceksiniz.";
                        TTVisual.InfoBox.Alert(msg);
                        this._Consultation.ProcedureDoctor = user;
                    }
                }
                }
            }
        }
        if ((<ITTObject>this._Consultation).HasErrors === true)
            throw new Exception((<ITTObject>this._Consultation).GetErrors());

    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Consultation();
        this.consultationDoctorExaminationFormNewViewModel = new ConsultationDoctorExaminationFormNewViewModel();
        this._ViewModel = this.consultationDoctorExaminationFormNewViewModel;
        this.consultationDoctorExaminationFormNewViewModel._Consultation = this._TTObject as Consultation;
        this.consultationDoctorExaminationFormNewViewModel._Consultation.Episode = new Episode();
        this.consultationDoctorExaminationFormNewViewModel._Consultation.Episode.Patient = new Patient();
        this.consultationDoctorExaminationFormNewViewModel._Consultation.Episode.Patient.MedicalInformation = new MedicalInformation();
        this.consultationDoctorExaminationFormNewViewModel._Consultation.Episode.Patient.MedicalInformation.MedicalInfoHabits = new MedicalInfoHabits();
        this.consultationDoctorExaminationFormNewViewModel._Consultation.Episode.Patient.MedicalInformation.MedicalInfoHabits.CigaretteUsageFrequency = new SKRSSigaraKullanimi();
        this.consultationDoctorExaminationFormNewViewModel._Consultation.Episode.Patient.MedicalInformation.MedicalInfoHabits.AlcoholUsageFrequency = new SKRSAlkolKullanimi();
        this.consultationDoctorExaminationFormNewViewModel._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup = new MedicalInfoDisabledGroup();
        this.consultationDoctorExaminationFormNewViewModel._Consultation.Episode.Patient.MedicalInformation.MedicalInfoAllergies = new MedicalInfoAllergies();
        this.consultationDoctorExaminationFormNewViewModel._Consultation.Episode.Patient.MedicalInformation.MedicalInfoAllergies.MedicalInfoFoodAllergies = new Array<MedicalInfoFoodAllergies>();
        this.consultationDoctorExaminationFormNewViewModel._Consultation.Episode.Patient.MedicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies = new Array<MedicalInfoDrugAllergies>();
        this.consultationDoctorExaminationFormNewViewModel._Consultation.Episode.Patient.ImportantMedicalInformation = new ImportantMedicalInformation();
        this.consultationDoctorExaminationFormNewViewModel._Consultation.Episode.Patient.ImportantMedicalInformation.DiagnosisHistory = new Array<DiagnosisGrid>();
        this.consultationDoctorExaminationFormNewViewModel._Consultation.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.consultationDoctorExaminationFormNewViewModel._Consultation.ProcedureDoctor = new ResUser();
        this.consultationDoctorExaminationFormNewViewModel._Consultation.Diagnosis = new Array<DiagnosisGrid>();
        this.consultationDoctorExaminationFormNewViewModel._Consultation.RequesterResource = new ResSection();
        this.consultationDoctorExaminationFormNewViewModel._Consultation.RequesterDoctor = new ResUser();
        this.consultationDoctorExaminationFormNewViewModel._Consultation.MasterResource = new ResSection();
        this.consultationDoctorExaminationFormNewViewModel._Consultation.ProcedureSpeciality = new SpecialityDefinition();
        this.consultationDoctorExaminationFormNewViewModel._Consultation.TreatmentMaterials = new Array<BaseTreatmentMaterial>();
        this.consultationDoctorExaminationFormNewViewModel._Consultation.Consultations = new Array<Consultation>();
        this.consultationDoctorExaminationFormNewViewModel._Consultation.SingleNursingOrders = new Array<SingleNursingOrder>();
        this.consultationDoctorExaminationFormNewViewModel.RequestedProcedures = new Array<vmRequestedProcedure>();
        this.consultationDoctorExaminationFormNewViewModel.ProcedureRequestFormResourceIDs = new Array<Guid>();
        this.consultationDoctorExaminationFormNewViewModel.UserMostUsedFormDefinitions = new Array<vmProcedureRequestFormDefinition>();
        this.consultationDoctorExaminationFormNewViewModel._Consultation.ConsultationTreatmentMaterials = new Array<ConsultationTreatmentMaterial>();
    }

    protected loadViewModel() {
        let that = this;

        that.consultationDoctorExaminationFormNewViewModel = this._ViewModel as ConsultationDoctorExaminationFormNewViewModel;
        that._TTObject = this.consultationDoctorExaminationFormNewViewModel._Consultation;
        that.consultationDoctorExaminationFormNewViewModel.RequestedProcedures = new Array<vmRequestedProcedure>();
        that.consultationDoctorExaminationFormNewViewModel._EpisodeActionObjectId = this.consultationDoctorExaminationFormNewViewModel._Consultation.ObjectID;
        that.consultationDoctorExaminationFormNewViewModel.ProcedureRequestFormResourceIDs = new Array<Guid>();
        that.consultationDoctorExaminationFormNewViewModel.UserMostUsedFormDefinitions = new Array<vmProcedureRequestFormDefinition>();
        //  that.consultationDoctorExaminationFormNewViewModel._isComplete = false;
        if (this.consultationDoctorExaminationFormNewViewModel == null)
            this.consultationDoctorExaminationFormNewViewModel = new ConsultationDoctorExaminationFormNewViewModel();
        if (this.consultationDoctorExaminationFormNewViewModel._Consultation == null)
            this.consultationDoctorExaminationFormNewViewModel._Consultation = new Consultation();
        let episodeObjectID = that.consultationDoctorExaminationFormNewViewModel._Consultation["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.consultationDoctorExaminationFormNewViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.consultationDoctorExaminationFormNewViewModel._Consultation.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.consultationDoctorExaminationFormNewViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                    if (patient) {
                        episode.Patient = patient;
                    }
                    if (patient != null) {
                        let importantMedicalInformationObjectID = patient["ImportantMedicalInformation"];
                        if (importantMedicalInformationObjectID != null && (typeof importantMedicalInformationObjectID === 'string')) {
                            let importantMedicalInformation = that.consultationDoctorExaminationFormNewViewModel.ImportantMedicalInformations.find(o => o.ObjectID.toString() === importantMedicalInformationObjectID.toString());
                            if (importantMedicalInformation) {
                                patient.ImportantMedicalInformation = importantMedicalInformation;
                            }
                            if (importantMedicalInformation != null) {
                                importantMedicalInformation.DiagnosisHistory = that.consultationDoctorExaminationFormNewViewModel.DiagnosisHistoryGridList;
                                for (let detailItem of that.consultationDoctorExaminationFormNewViewModel.DiagnosisHistoryGridList) {
                                    let diagnoseObjectID = detailItem["Diagnose"];
                                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
                                        let diagnose = that.consultationDoctorExaminationFormNewViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                                        if (diagnose) {
                                            detailItem.Diagnose = diagnose;
                                        }
                                    }
                                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === 'string')) {
                                        let responsibleUser = that.consultationDoctorExaminationFormNewViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                                        if (responsibleUser) {
                                            detailItem.ResponsibleUser = responsibleUser;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (episode != null) {
                episode.Diagnosis = that.consultationDoctorExaminationFormNewViewModel.GridEpisodeDiagnosisGridList;
                for (let detailItem of that.consultationDoctorExaminationFormNewViewModel.GridEpisodeDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
                        let diagnose = that.consultationDoctorExaminationFormNewViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                        if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === 'string')) {
                        let responsibleUser = that.consultationDoctorExaminationFormNewViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                        if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }
            }
        }

        let procedureDoctorObjectID = that.consultationDoctorExaminationFormNewViewModel._Consultation["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
            let procedureDoctor = that.consultationDoctorExaminationFormNewViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
            if (procedureDoctor) {
                that.consultationDoctorExaminationFormNewViewModel._Consultation.ProcedureDoctor = procedureDoctor;
            }
            that.consultationDoctorExaminationFormNewViewModel.ProcedureRequestFormResourceIDs.push(procedureDoctor.ObjectID);
        }
        //that.consultationDoctorExaminationFormNewViewModel._Consultation.Diagnosis = that.consultationDoctorExaminationFormNewViewModel.GridDiagnosisGridList;
        //for (let detailItem of that.consultationDoctorExaminationFormNewViewModel.GridDiagnosisGridList) {
        //    let diagnoseObjectID = detailItem["Diagnose"];
        //    if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
        //        let diagnose = that.consultationDoctorExaminationFormNewViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
        //        detailItem.Diagnose = diagnose;
        //    }
        //    let responsibleUserObjectID = detailItem["ResponsibleUser"];
        //    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === 'string')) {
        //        let responsibleUser = that.consultationDoctorExaminationFormNewViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
        //        detailItem.ResponsibleUser = responsibleUser;
        //    }
        //}
        let requesterResourceObjectID = that.consultationDoctorExaminationFormNewViewModel._Consultation["RequesterResource"];
        if (requesterResourceObjectID != null && (typeof requesterResourceObjectID === 'string')) {
            let requesterResource = that.consultationDoctorExaminationFormNewViewModel.ResSections.find(o => o.ObjectID.toString() === requesterResourceObjectID.toString());
            if (requesterResource) {
                that.consultationDoctorExaminationFormNewViewModel._Consultation.RequesterResource = requesterResource;
            }
        }
        let requesterDoctorObjectID = that.consultationDoctorExaminationFormNewViewModel._Consultation["RequesterDoctor"];
        if (requesterDoctorObjectID != null && (typeof requesterDoctorObjectID === 'string')) {
            let requesterDoctor = that.consultationDoctorExaminationFormNewViewModel.ResUsers.find(o => o.ObjectID.toString() === requesterDoctorObjectID.toString());
            if (requesterDoctor) {
                that.consultationDoctorExaminationFormNewViewModel._Consultation.RequesterDoctor = requesterDoctor;
            }
        }
        let masterResourceObjectID = that.consultationDoctorExaminationFormNewViewModel._Consultation["MasterResource"];
        if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
            let masterResource = that.consultationDoctorExaminationFormNewViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
            if (masterResource) {
                that.consultationDoctorExaminationFormNewViewModel._Consultation.MasterResource = masterResource;
            }
            //that.consultationDoctorExaminationFormNewViewModel._ConsultationMasterResourseID = masterResource.ObjectID;
            that.consultationDoctorExaminationFormNewViewModel.ProcedureRequestFormResourceIDs.push(masterResource.ObjectID);
        }
        let procedureSpecialityObjectID = that.consultationDoctorExaminationFormNewViewModel._Consultation["ProcedureSpeciality"];
        if (procedureSpecialityObjectID != null && (typeof procedureSpecialityObjectID === 'string')) {
            let procedureSpeciality = that.consultationDoctorExaminationFormNewViewModel.SpecialityDefinitions.find(o => o.ObjectID.toString() === procedureSpecialityObjectID.toString());
            if (procedureSpeciality) {
                that.consultationDoctorExaminationFormNewViewModel._Consultation.ProcedureSpeciality = procedureSpeciality;
            }
        }
        //that.consultationDoctorExaminationFormNewViewModel._Consultation.TreatmentMaterials = that.consultationDoctorExaminationFormNewViewModel.GridTreatmentMaterialsGridList;
        //for (let detailItem of that.consultationDoctorExaminationFormNewViewModel.GridTreatmentMaterialsGridList) {
        //    let materialObjectID = detailItem["Material"];
        //    if (materialObjectID != null && (typeof materialObjectID === 'string')) {
        //        let material = that.consultationDoctorExaminationFormNewViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
        //        detailItem.Material = material;
        //    }
        //    let ozelDurumObjectID = detailItem["OzelDurum"];
        //    if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === 'string')) {
        //        let ozelDurum = that.consultationDoctorExaminationFormNewViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
        //        detailItem.OzelDurum = ozelDurum;
        //    }
        //}

        that.consultationDoctorExaminationFormNewViewModel._Consultation.ConsultationTreatmentMaterials = that.consultationDoctorExaminationFormNewViewModel.GridTreatmentMaterialsGridList;
        for (let detailItem of that.consultationDoctorExaminationFormNewViewModel.GridTreatmentMaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.consultationDoctorExaminationFormNewViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.consultationDoctorExaminationFormNewViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.consultationDoctorExaminationFormNewViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
            let ozelDurumObjectID = detailItem["OzelDurum"];
            if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === 'string')) {
                let ozelDurum = that.consultationDoctorExaminationFormNewViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                if (ozelDurum) {
                    detailItem.OzelDurum = ozelDurum;
                }
            }
        } 

   /*     for (let detailItem of that.consultationDoctorExaminationFormNewViewModel.NewGridTreatmentMaterialsGridList) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.consultationDoctorExaminationFormNewViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material['StockCard'];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.consultationDoctorExaminationFormNewViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard['DistributionType'];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.consultationDoctorExaminationFormNewViewModel.DistributionTypeDefinitions.find(o =>
                                    o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }

            // tslint:disable-next-line:no-shadowed-variable
            let ozelDurumObjectID = detailItem['OzelDurum'];
            if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === 'string')) {
                let ozelDurum = that.consultationDoctorExaminationFormNewViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                if (ozelDurum) {
                    detailItem.OzelDurum = ozelDurum;
                }
            }

            let subEpisodeID = detailItem['SubEpisode'];
            if(subEpisodeID != null && (typeof subEpisodeID === 'string'))
            {
                let subEpisode = that.consultationDoctorExaminationFormNewViewModel.SubEpisodeList.find(o => o.ObjectID.toString() === subEpisodeID.toString());
                if(subEpisode){
                    detailItem.SubEpisode = subEpisode;
                }
            }

            let episodeActionID = detailItem['EpisodeAction'];
            if(episodeActionID != null && (typeof episodeActionID === 'string'))
            {
                let episodeAction = that.consultationDoctorExaminationFormNewViewModel.EpisodeActionList.find(o => o.ObjectID != null && o.ObjectID.toString() === episodeActionID.toString());
                if(episodeAction){
                    detailItem.EpisodeAction = episodeAction;
                }
            }

        }*/


        that.consultationDoctorExaminationFormNewViewModel._Consultation.Consultations = that.consultationDoctorExaminationFormNewViewModel.GrdConsultationGridList;
        for (let detailItem of that.consultationDoctorExaminationFormNewViewModel.GrdConsultationGridList) {
            let masterResourceObjectID = detailItem["MasterResource"];
            if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
                let masterResource = that.consultationDoctorExaminationFormNewViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
                if (masterResource) {
                    detailItem.MasterResource = masterResource;
                }
            }
            let procedureDoctorObjectID = detailItem["ProcedureDoctor"];
            if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
                let procedureDoctor = that.consultationDoctorExaminationFormNewViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                if (procedureDoctor) {
                    detailItem.ProcedureDoctor = procedureDoctor;
                }
            }
        }
        that.consultationDoctorExaminationFormNewViewModel._Consultation.SingleNursingOrders = that.consultationDoctorExaminationFormNewViewModel.GridNursingOrdersGridList;
        for (let detailItem of that.consultationDoctorExaminationFormNewViewModel.GridNursingOrdersGridList) {
            let procedureObjectObjectID = detailItem["ProcedureObject"];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
                let procedureObject = that.consultationDoctorExaminationFormNewViewModel.VitalSignAndNursingDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
            let singleNursingOrderDetailObjectID = detailItem["SingleNursingOrderDetail"];
            if (singleNursingOrderDetailObjectID != null && (typeof singleNursingOrderDetailObjectID === 'string')) {
                let singleNursingOrderDetail = that.consultationDoctorExaminationFormNewViewModel.SingleNursingOrderDetails.find(o => o.ObjectID.toString() === singleNursingOrderDetailObjectID.toString());
                if (singleNursingOrderDetail) {
                    detailItem.SingleNursingOrderDetail = singleNursingOrderDetail;
                }
            }
        }
        super.loadViewModel();

        this.controlDailyInpatient();
        this.ActivePage = this.tabService.getActiveTab('cdef');
        if (this.ActivePage === undefined) {
            if (this.consultationDoctorExaminationFormNewViewModel.hasSpecialityBasedObject === true) {
                this.ActivePage = 'uzmanlik';
            }
            if (this.hasEmergencySpecialityBasedObject === true) {
                this.ActivePage = 'muayene';
            }

        } else if (this.ActivePage !== undefined) {
            if (this.consultationDoctorExaminationFormNewViewModel.hasSpecialityBasedObject === false && this.ActivePage === 'uzmanlik') {
                this.ActivePage = 'muayene';
            }
            if (this.hasEmergencySpecialityBasedObject === false && this.ActivePage === 'muayene') {
                this.ActivePage = 'uzmanlik';
            }
            if (this.ActivePage === 'istem')
                this.openIstemTab = true;
            if (this.ActivePage === 'hastaGecmisi')
                this.openHastaGecmisi();
        }
        if (this.ActivePage === 'uzmanlik' || !this.hasEmergencySpecialityBasedObject)
            this.openUzmanlikTab = true;
        this.RecentActiveTab = this.ActivePage;
        //this.consultationDoctorExaminationFormNewViewModel.ENabizViewModels = [];
    }

    private showDrugOrderIntroduction(data: DrugOrderIntroduction): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DrugOrderIntroductionNewForm';
            componentInfo.ModuleName = 'IlacDirektifiGirisModule';
            componentInfo.ModulePath = '/Modules/Saglik_Lojistik/Eczane_Modulleri/Ilac_Direktifi_Giris_Modulu/IlacDirektifiGirisModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, new ActiveIDsModel(this._Consultation.ObjectID, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M20924", "Reçete");
            modalInfo.Width = 1200;
            modalInfo.Height = 850;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    async onDrugOrderIntruductionOpen(data: any) {
        let subEpisodeID: Guid = <any>this._Consultation['SubEpisode'];
        let subEps: SubEpisode = await this.objectContextService.getObject<SubEpisode>(subEpisodeID, SubEpisode.ObjectDefID);
        let inPatientPhysicianApplication: InPatientPhysicianApplication =
            await InPatientPhysicianApplicationService.GetActiveInPatientPhysicianApplication(this._Consultation.Episode.ObjectID);

        this.objectContextService.getNewObject<DrugOrderIntroduction>(DrugOrderIntroduction.ObjectDefID, DrugOrderIntroduction).then(result => {
            let drugOrderIntroduction: DrugOrderIntroduction = result;
            drugOrderIntroduction.MasterResource = this._Consultation.MasterResource;
            drugOrderIntroduction.SecondaryMasterResource = this._Consultation.SecondaryMasterResource;
            drugOrderIntroduction.Episode = this._Consultation.Episode;
            drugOrderIntroduction.SubEpisode = subEps;
            drugOrderIntroduction.PatientOwnDrug = false;
            drugOrderIntroduction.IsConsultaitonOrder = true;
            drugOrderIntroduction.CurrentStateDefID = DrugOrderIntroduction.DrugOrderIntroductionStates.New;
            drugOrderIntroduction.DrugOrderIntroductionDetails = new Array<DrugOrderIntroductionDet>();
            if (inPatientPhysicianApplication !== null) {
                drugOrderIntroduction.ActiveInPatientPhysicianApp = inPatientPhysicianApplication;
            }
            // tslint:disable-next-line:no-shadowed-variable
            this.showDrugOrderIntroduction(drugOrderIntroduction).then(result => {
                DrugOrderIntroductionService.GetOldDrugOrderIntroductionDets(this._Consultation.Episode).then(drugOrderIntDets => {
                    this.PrescriptionList = new Array<DrugOrderIntroductionDet>();
                    for (let drugOrder of drugOrderIntDets.DrugOrderIntroductionDets) {
                        let materialObjectID = drugOrder.Material;
                        if (materialObjectID != null) {
                            let material = drugOrderIntDets.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                            drugOrder.Material = material;
                        }

                        this.PrescriptionList.push(drugOrder);
                    }
                }).catch(err => {
                    this.messageService.showError(err);
                });
            }).catch(err2 => {
                this.messageService.showError(err2);
            });
        }).catch(err3 => {
            this.messageService.showError(err3);
        });
    }


  

    async ngOnInit() {
        let that = this;
        await this.load(ConsultationDoctorExaminationFormNewViewModel);
        this.AddHelpMenu();

        //this.httpService.eNabizButtonSharedService.changeButtonVisible(true);

        //Parametre değeri TRUE ise Reçete tabının gizlenmesi sağlanıyor.
        let enableColorPrescriptionWithJSON: string = (await SystemParameterService.GetParameterValue('ENABLECOLORPRESCRIPTIONWITHJSON', 'FALSE'));
        if (enableColorPrescriptionWithJSON === 'TRUE') {
            this.enablePrescriptionTab = false;
        }
        else {
            this.enablePrescriptionTab = true;
        }
    }


    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        await super.AfterContextSavedScript(transDef);
        if (transDef && transDef.ToStateStatus == StateStatusEnum.CompletedSuccessfully) {
            const objectIdParam = new GuidParam(this.ObjectID);
            let reportParameters: any = { 'OBJECTID': objectIdParam };
            this.reportService.showReport('ConsultationReport', reportParameters);
        }

        if (this.requestedProceduresFormInstance != undefined && this.requestedProceduresFormInstance.operationControl === true) {
            this.loadingVisible = true;
            await this.requestedProceduresFormInstance.DailyOperationsSave(this.consultationDoctorExaminationFormNewViewModel._Consultation);
        }

        else if (this.treatmentMaterialFormInstance != undefined && this.treatmentMaterialFormInstance.operationControl === true) {
            this.loadingVisible = true;
            await this.treatmentMaterialFormInstance.DailyOperationsSave(this.consultationDoctorExaminationFormNewViewModel._Consultation);
        }

        this.loadingVisible = false;

        await this.ngOnInit();
    }

    public onAlcoholMedicalInfoHabitsChanged(event): void {
        if (event != null) {
            if (this._Consultation != null &&
                this._Consultation.Episode != null &&
                this._Consultation.Episode.Patient != null &&
                this._Consultation.Episode.Patient.MedicalInformation != null &&
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoHabits != null && this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoHabits.Alcohol != event) {
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoHabits.Alcohol = event;
            }
        }
    }

    public onAlcoholUsageFrequencyMedicalInfoHabitsChanged(event): void {
        if (event != null) {
            if (this._Consultation != null &&
                this._Consultation.Episode != null &&
                this._Consultation.Episode.Patient != null &&
                this._Consultation.Episode.Patient.MedicalInformation != null &&
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoHabits != null && this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoHabits.AlcoholUsageFrequency != event) {
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoHabits.AlcoholUsageFrequency = event;
            }
        }
    }

    public onChronicDiseasesChanged(event): void {
        if (event != null) {
            if (this._Consultation != null &&
                this._Consultation.Episode != null &&
                this._Consultation.Episode.Patient != null &&
                this._Consultation.Episode.Patient.MedicalInformation != null && this._Consultation.Episode.Patient.MedicalInformation.ChronicDiseases != event) {
                this._Consultation.Episode.Patient.MedicalInformation.ChronicDiseases = event;
            }
        }
    }

    public onChronicMedicalInfoDisabledGroupChanged(event): void {
        if (event != null) {
            if (this._Consultation != null &&
                this._Consultation.Episode != null &&
                this._Consultation.Episode.Patient != null &&
                this._Consultation.Episode.Patient.MedicalInformation != null &&
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup != null && this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Chronic != event) {
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Chronic = event;
            }
        }
    }

    public onCigaretteMedicalInfoHabitsChanged(event): void {
        if (event != null) {
            if (this._Consultation != null &&
                this._Consultation.Episode != null &&
                this._Consultation.Episode.Patient != null &&
                this._Consultation.Episode.Patient.MedicalInformation != null &&
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoHabits != null && this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoHabits.Cigarette != event) {
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoHabits.Cigarette = event;
            }
        }
    }

    public onCigaretteUsageFrequencyMedicalInfoHabitsChanged(event): void {
        if (event != null) {
            if (this._Consultation != null &&
                this._Consultation.Episode != null &&
                this._Consultation.Episode.Patient != null &&
                this._Consultation.Episode.Patient.MedicalInformation != null &&
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoHabits != null && this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoHabits.CigaretteUsageFrequency != event) {
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoHabits.CigaretteUsageFrequency = event;
            }
        }
    }

    public onCoffeeMedicalInfoHabitsChanged(event): void {
        if (event != null) {
            if (this._Consultation != null &&
                this._Consultation.Episode != null &&
                this._Consultation.Episode.Patient != null &&
                this._Consultation.Episode.Patient.MedicalInformation != null &&
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoHabits != null && this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoHabits.Coffee != event) {
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoHabits.Coffee = event;
            }
        }
    }

    public onDescriptionMedicalInfoHabitsChanged(event): void {
        if (event != null) {
            if (this._Consultation != null &&
                this._Consultation.Episode != null &&
                this._Consultation.Episode.Patient != null &&
                this._Consultation.Episode.Patient.MedicalInformation != null &&
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoHabits != null && this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoHabits.Description != event) {
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoHabits.Description = event;
            }
        }
    }

    public ondtpProcessEndDateChanged(event): void {
        if (event != null) {
            //let processEndDate: Date = new Date(event);
            if (this._Consultation != null && this._Consultation.ProcessEndDate != event) {
                this._Consultation.ProcessEndDate = event;
            }
        }
    }

    public onHearingMedicalInfoDisabledGroupChanged(event): void {
        if (event != null) {
            if (this._Consultation != null &&
                this._Consultation.Episode != null &&
                this._Consultation.Episode.Patient != null &&
                this._Consultation.Episode.Patient.MedicalInformation != null &&
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup != null && this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Hearing != event) {
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Hearing = event;
            }
        }
    }

    public onHemodialysisChanged(event): void {
        if (event != null) {
            if (this._Consultation != null &&
                this._Consultation.Episode != null &&
                this._Consultation.Episode.Patient != null &&
                this._Consultation.Episode.Patient.MedicalInformation != null && this._Consultation.Episode.Patient.MedicalInformation.Hemodialysis != event) {
                this._Consultation.Episode.Patient.MedicalInformation.Hemodialysis = event;
            }
        }
    }

    public onImplantChanged(event): void {
        if (event != null) {
            if (this._Consultation != null &&
                this._Consultation.Episode != null &&
                this._Consultation.Episode.Patient != null &&
                this._Consultation.Episode.Patient.MedicalInformation != null && this._Consultation.Episode.Patient.MedicalInformation.Implant != event) {
                this._Consultation.Episode.Patient.MedicalInformation.Implant = event;
            }
        }
    }

    public onInPatientBedChanged(event): void {
        if (event != null) {
            if (this._Consultation != null && this._Consultation.InPatientBed != event) {
                this._Consultation.InPatientBed = event;
            }
        }
    }

    public onIsTreatmentMaterialEmptyChanged(event): void {
        if (event != null) {
            if (this._Consultation != null && this._Consultation.IsTreatmentMaterialEmpty != event) {
                this._Consultation.IsTreatmentMaterialEmpty = event;
            }
        }
    }

    public onMasterResourceChanged(event): void {
        if (event != null) {
            if (this._Consultation != null && this._Consultation.MasterResource != event) {
                this._Consultation.MasterResource = event;
            }
        }
    }

    public onMentalMedicalInfoDisabledGroupChanged(event): void {
        if (event != null) {
            if (this._Consultation != null &&
                this._Consultation.Episode != null &&
                this._Consultation.Episode.Patient != null &&
                this._Consultation.Episode.Patient.MedicalInformation != null &&
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup != null && this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Mental != event) {
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Mental = event;
            }
        }
    }

    public onNonexistenceMedicalInfoDisabledGroupChanged(event): void {
        if (event != null) {
            if (this._Consultation != null &&
                this._Consultation.Episode != null &&
                this._Consultation.Episode.Patient != null &&
                this._Consultation.Episode.Patient.MedicalInformation != null &&
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup != null && this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Nonexistence != event) {
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Nonexistence = event;
            }
        }
    }

    public onOncologicFollowUpChanged(event): void {
        if (event != null) {
            if (this._Consultation != null &&
                this._Consultation.Episode != null &&
                this._Consultation.Episode.Patient != null &&
                this._Consultation.Episode.Patient.MedicalInformation != null && this._Consultation.Episode.Patient.MedicalInformation.OncologicFollowUp != event) {
                this._Consultation.Episode.Patient.MedicalInformation.OncologicFollowUp = event;
            }
        }
    }

    public onOrthopedicMedicalInfoDisabledGroupChanged(event): void {
        if (event != null) {
            if (this._Consultation != null &&
                this._Consultation.Episode != null &&
                this._Consultation.Episode.Patient != null &&
                this._Consultation.Episode.Patient.MedicalInformation != null &&
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup != null && this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Orthopedic != event) {
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Orthopedic = event;
            }
        }
    }

    public onOtherAllergiesMedicalInfoAllergiesChanged(event): void {
        if (event != null) {
            if (this._Consultation != null &&
                this._Consultation.Episode != null &&
                this._Consultation.Episode.Patient != null &&
                this._Consultation.Episode.Patient.MedicalInformation != null &&
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoAllergies != null && this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoAllergies.OtherAllergies != event) {
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoAllergies.OtherAllergies = event;
            }
        }
    }

    public onOtherInformationChanged(event): void {
        if (event != null) {
            if (this._Consultation != null &&
                this._Consultation.Episode != null &&
                this._Consultation.Episode.Patient != null &&
                this._Consultation.Episode.Patient.MedicalInformation != null && this._Consultation.Episode.Patient.MedicalInformation.OtherInformation != event) {
                this._Consultation.Episode.Patient.MedicalInformation.OtherInformation = event;
            }
        }
    }

    public onOtherMedicalInfoHabitsChanged(event): void {
        if (event != null) {
            if (this._Consultation != null &&
                this._Consultation.Episode != null &&
                this._Consultation.Episode.Patient != null &&
                this._Consultation.Episode.Patient.MedicalInformation != null &&
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoHabits != null && this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoHabits.Other != event) {
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoHabits.Other = event;
            }
        }
    }

    public onPregnancyChanged(event): void {
        if (event != null) {
            if (this._Consultation != null &&
                this._Consultation.Episode != null &&
                this._Consultation.Episode.Patient != null &&
                this._Consultation.Episode.Patient.MedicalInformation != null && this._Consultation.Episode.Patient.MedicalInformation.Pregnancy != event) {
                this._Consultation.Episode.Patient.MedicalInformation.Pregnancy = event;
            }
        }
    }

    public onProceduerDoctorChanged(event): void {
        if (event != null) {
            if (this._Consultation != null && this._Consultation.ProcedureDoctor != event) {
                this._Consultation.ProcedureDoctor = event;
            }
        }
    }

    public onProcedureSpecialityChanged(event): void {
        if (event != null) {
            if (this._Consultation != null && this._Consultation.ProcedureSpeciality != event) {
                this._Consultation.ProcedureSpeciality = event;
            }
        }
    }

    public onProcessDateChanged(event): void {
        if (event != null) {
            let processDate: Date = new Date(event);
            if (this._Consultation != null && this._Consultation.ProcessDate != processDate) {
                this._Consultation.ProcessDate = processDate;
            }
        }
    }

    public onProtocolNoChanged(event): void {
        if (event != null) {
            if (this._Consultation != null && this._Consultation.ProtocolNo != event) {
                this._Consultation.ProtocolNo = event;
            }
        }
    }

    public onPsychicAndEmotionalMedicalInfoDisabledGroupChanged(event): void {
        if (event != null) {
            if (this._Consultation != null &&
                this._Consultation.Episode != null &&
                this._Consultation.Episode.Patient != null &&
                this._Consultation.Episode.Patient.MedicalInformation != null &&
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup != null && this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.PsychicAndEmotional != event) {
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.PsychicAndEmotional = event;
            }
        }
    }

    public onRequestedDoctorChanged(event): void {
        if (event != null) {
            if (this._Consultation != null && this._Consultation.RequesterDoctor != event) {
                this._Consultation.RequesterDoctor = event;
            }
        }
    }

    public onRequesterDepatmentChanged(event): void {
        if (event != null) {
            if (this._Consultation != null && this._Consultation.RequesterResource != event) {
                this._Consultation.RequesterResource = event;
            }
        }
    }

    public onrtfHistoryChanged(event): void {
        if (event != null) {
            if (this._Consultation != null && this._Consultation.PatientHistory != event) {
                this._Consultation.PatientHistory = event;
            }
        }
    }

    public onSpeechAndLanguageMedicalInfoDisabledGroupChanged(event): void {
        if (event != null) {
            if (this._Consultation != null &&
                this._Consultation.Episode != null &&
                this._Consultation.Episode.Patient != null &&
                this._Consultation.Episode.Patient.MedicalInformation != null &&
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup != null && this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.SpeechAndLanguage != event) {
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.SpeechAndLanguage = event;
            }
        }
    }

    public onTeaMedicalInfoHabitsChanged(event): void {
        if (event != null) {
            if (this._Consultation != null &&
                this._Consultation.Episode != null &&
                this._Consultation.Episode.Patient != null &&
                this._Consultation.Episode.Patient.MedicalInformation != null &&
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoHabits != null && this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoHabits.Tea != event) {
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoHabits.Tea = event;
            }
        }
    }

    public onTransplantationChanged(event): void {
        if (event != null) {
            if (this._Consultation != null &&
                this._Consultation.Episode != null &&
                this._Consultation.Episode.Patient != null &&
                this._Consultation.Episode.Patient.MedicalInformation != null && this._Consultation.Episode.Patient.MedicalInformation.Transplantation != event) {
                this._Consultation.Episode.Patient.MedicalInformation.Transplantation = event;
            }
        }
    }

    public onchkEmergencyChanged(event): void {
        if (event != null) {
            if (this._Consultation != null && this._Consultation.Emergency != event) {
                this._Consultation.Emergency = event;
            }
        }
    }

    public onttrichtextboxcontrol10Changed(event): void {
        if (event != null) {
            if (this._Consultation != null && this._Consultation.ExaminationSummary != event) {
                this._Consultation.ExaminationSummary = event;
            }
        }
    }

    public onrtfConsultationResultAndOffersChanged(event): void {
        if (event != null) {
            if (this._Consultation != null && this._Consultation.ConsultationResultAndOffers != event) {
                this._Consultation.ConsultationResultAndOffers = event;
            }
        }
    }

    public onrtfComplaintChanged(event): void {
        if (event != null) {
            if (this._Consultation != null && this._Consultation.Complaint != event) {
                this._Consultation.Complaint = event;
            }
        }
    }

    public onttrichtextboxcontrol2Changed(event): void {
        if (event != null) {
            if (this._Consultation != null && this._Consultation.PatientStory != event) {
                this._Consultation.PatientStory = event;
            }
        }
    }

    public onrtfPhysicalExaminationChanged(event): void {
        if (event != null) {
            if (this._Consultation != null && this._Consultation.PhysicalExamination != event) {
                this._Consultation.PhysicalExamination = event;
            }
        }
    }

    public onrtfRequestDescriptionChanged(event): void {
        if (event != null) {
            if (this._Consultation != null && this._Consultation.RequestDescription != event) {
                this._Consultation.RequestDescription = event;
            }
        }
    }

    public onttrichtextboxcontrol7Changed(event): void {
        if (event != null) {
            if (this._Consultation != null && this._Consultation.PatientFamilyHistory != event) {
                this._Consultation.PatientFamilyHistory = event;
            }
        }
    }

    public onUnclassifiedMedicalInfoDisabledGroupChanged(event): void {
        if (event != null) {
            if (this._Consultation != null &&
                this._Consultation.Episode != null &&
                this._Consultation.Episode.Patient != null &&
                this._Consultation.Episode.Patient.MedicalInformation != null &&
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup != null && this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Unclassified != event) {
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Unclassified = event;
            }
        }
    }

    public onVisionMedicalInfoDisabledGroupChanged(event): void {
        if (event != null) {
            if (this._Consultation != null &&
                this._Consultation.Episode != null &&
                this._Consultation.Episode.Patient != null &&
                this._Consultation.Episode.Patient.MedicalInformation != null &&
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup != null && this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Vision != event) {
                this._Consultation.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Vision = event;
            }
        }
    }
    //public onIsCompleteChanged(event): void {
    //    if (event != null)
    //        this.consultationDoctorExaminationFormNewViewModel._isComplete = event;

    //}

    public async btnConsultationSave_Click() {
        this.save();
    }

    public SelectedPackageChange(data) {

    }

    public openKonsultasyonTab: boolean = false;
    openKonsultasyon() {
        this.openKonsultasyonTab = true;
    }

    public openIstemTab: boolean = false;
    openIstem() {
        this.openIstemTab = true;
    }

    public openHastaGecmisiTab: boolean = false;
    public openHastaGecmisi() {
        this.openHastaGecmisiTab = true;

        this.setPatientHistoryShown(this.consultationDoctorExaminationFormNewViewModel._Consultation.ObjectID);
    }

    public openUzmanlikTab: boolean = false;
    public openUzmanlik() {
        this.openUzmanlikTab = true;
    }


    public setPatientHistoryShown(episodeActionId: Guid) {
        let that = this;
        that.httpService.get<any>("api/PatientHistoryService/SetPatientHistoryShown?episodeActionId=" + episodeActionId)
            .then(response => {
            })
            .catch(error => {
            });
    }

    protected redirectProperties(): void {
        redirectProperty(this.chkEmergency, "Value", this.__ttObject, "Emergency");
        redirectProperty(this.InPatientBed, "Value", this.__ttObject, "InPatientBed");
        redirectProperty(this.ProtocolNo, "Text", this.__ttObject, "ProtocolNo");
        redirectProperty(this.ProcessDate, "Value", this.__ttObject, "ProcessDate");
        redirectProperty(this.dtpProcessEndDate, "Value", this.__ttObject, "ProcessEndDate");
        redirectProperty(this.rtfRequestDescription, "Rtf", this.__ttObject, "RequestDescription");
        redirectProperty(this.Pregnancy, "Value", this.__ttObject, "Episode.Patient.MedicalInformation.Pregnancy");
        redirectProperty(this.ChronicDiseases, "Text", this.__ttObject, "Episode.Patient.MedicalInformation.ChronicDiseases");
        redirectProperty(this.Transplantation, "Text", this.__ttObject, "Episode.Patient.MedicalInformation.Transplantation");
        redirectProperty(this.Hemodialysis, "Text", this.__ttObject, "Episode.Patient.MedicalInformation.Hemodialysis");
        redirectProperty(this.OncologicFollowUp, "Text", this.__ttObject, "Episode.Patient.MedicalInformation.OncologicFollowUp");
        redirectProperty(this.Implant, "Text", this.__ttObject, "Episode.Patient.MedicalInformation.Implant");
        redirectProperty(this.OtherInformation, "Text", this.__ttObject, "Episode.Patient.MedicalInformation.OtherInformation");
        redirectProperty(this.OtherAllergiesMedicalInfoAllergies, "Text", this.__ttObject, "Episode.Patient.MedicalInformation.MedicalInfoAllergies.OtherAllergies");
        redirectProperty(this.DescriptionMedicalInfoHabits, "Text", this.__ttObject, "Episode.Patient.MedicalInformation.MedicalInfoHabits.Description");
        redirectProperty(this.CigaretteMedicalInfoHabits, "Value", this.__ttObject, "Episode.Patient.MedicalInformation.MedicalInfoHabits.Cigarette");
        redirectProperty(this.TeaMedicalInfoHabits, "Value", this.__ttObject, "Episode.Patient.MedicalInformation.MedicalInfoHabits.Tea");
        redirectProperty(this.CoffeeMedicalInfoHabits, "Value", this.__ttObject, "Episode.Patient.MedicalInformation.MedicalInfoHabits.Coffee");
        redirectProperty(this.OtherMedicalInfoHabits, "Value", this.__ttObject, "Episode.Patient.MedicalInformation.MedicalInfoHabits.Other");
        redirectProperty(this.AlcoholMedicalInfoHabits, "Value", this.__ttObject, "Episode.Patient.MedicalInformation.MedicalInfoHabits.Alcohol");
        redirectProperty(this.NonexistenceMedicalInfoDisabledGroup, "Value", this.__ttObject, "Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Nonexistence");
        redirectProperty(this.ChronicMedicalInfoDisabledGroup, "Value", this.__ttObject, "Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Chronic");
        redirectProperty(this.VisionMedicalInfoDisabledGroup, "Value", this.__ttObject, "Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Vision");
        redirectProperty(this.HearingMedicalInfoDisabledGroup, "Value", this.__ttObject, "Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Hearing");
        redirectProperty(this.MentalMedicalInfoDisabledGroup, "Value", this.__ttObject, "Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Mental");
        redirectProperty(this.SpeechAndLanguageMedicalInfoDisabledGroup, "Value", this.__ttObject, "Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.SpeechAndLanguage");
        redirectProperty(this.OrthopedicMedicalInfoDisabledGroup, "Value", this.__ttObject, "Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Orthopedic");
        redirectProperty(this.PsychicAndEmotionalMedicalInfoDisabledGroup, "Value", this.__ttObject, "Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.PsychicAndEmotional");
        redirectProperty(this.UnclassifiedMedicalInfoDisabledGroup, "Value", this.__ttObject, "Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup.Unclassified");
        redirectProperty(this.rtfComplaint, "Rtf", this.__ttObject, "Complaint");
        redirectProperty(this.rtfConsultationResultAndOffers, "Rtf", this.__ttObject, "ConsultationResultAndOffers");
        redirectProperty(this.IsTreatmentMaterialEmpty, "Value", this.__ttObject, "IsTreatmentMaterialEmpty");
        redirectProperty(this.rtfPhysicalExamination, "Rtf", this.__ttObject, "PhysicalExamination");
        redirectProperty(this.rtfHistory, "Rtf", this.__ttObject, "PatientHistory");
    }

    public initFormControls(): void {
        this.tabMedicalInformation = new TTVisual.TTTabControl();
        this.tabMedicalInformation.Name = "tabMedicalInformation";
        this.tabMedicalInformation.TabIndex = 54;

        this.tttabpageMedicalInformation = new TTVisual.TTTabPage();
        this.tttabpageMedicalInformation.DisplayIndex = 0;
        this.tttabpageMedicalInformation.TabIndex = 0;
        this.tttabpageMedicalInformation.Text = i18n("M20020", "Önemli Tıbbi Bilgiler");
        this.tttabpageMedicalInformation.Name = "tttabpageMedicalInformation";

        this.labelChronicDiseases = new TTVisual.TTLabel();
        this.labelChronicDiseases.Text = i18n("M17876", "Kronik Hastalıklar");
        this.labelChronicDiseases.Name = "labelChronicDiseases";
        this.labelChronicDiseases.TabIndex = 1;

        this.labelHemodialysis = new TTVisual.TTLabel();
        this.labelHemodialysis.Text = i18n("M15629", "Hemodiyaliz");
        this.labelHemodialysis.Name = "labelHemodialysis";
        this.labelHemodialysis.TabIndex = 3;

        this.labelImplant = new TTVisual.TTLabel();
        this.labelImplant.Text = i18n("M16472", "İmplant");
        this.labelImplant.Name = "labelImplant";
        this.labelImplant.TabIndex = 5;

        this.labelOncologicFollowUp = new TTVisual.TTLabel();
        this.labelOncologicFollowUp.Text = i18n("M19719", "Onkolojik İzlem");
        this.labelOncologicFollowUp.Name = "labelOncologicFollowUp";
        this.labelOncologicFollowUp.TabIndex = 7;

        this.labelOtherInformation = new TTVisual.TTLabel();
        this.labelOtherInformation.Text = i18n("M12780", "Diğer");
        this.labelOtherInformation.Name = "labelOtherInformation";
        this.labelOtherInformation.TabIndex = 9;

        this.Pregnancy = new TTVisual.TTCheckBox();
        this.Pregnancy.Value = false;
        this.Pregnancy.Text = "Gebelik";
        this.Pregnancy.Name = "Pregnancy";
        this.Pregnancy.TabIndex = 10;

        this.ChronicDiseases = new TTVisual.TTTextBox();
        this.ChronicDiseases.Multiline = true;
        this.ChronicDiseases.BackColor = "#F0F0F0";
        this.ChronicDiseases.ReadOnly = false;
        this.ChronicDiseases.Name = "ChronicDiseases";
        this.ChronicDiseases.TabIndex = 0;

        this.labelTransplantation = new TTVisual.TTLabel();
        this.labelTransplantation.Text = i18n("M23579", "Transplantasyon");
        this.labelTransplantation.Name = "labelTransplantation";
        this.labelTransplantation.TabIndex = 12;

        this.ttgroupboxHabits = new TTVisual.TTGroupBox();
        this.ttgroupboxHabits.Text = i18n("M10722", "Alışkanlıklar");
        this.ttgroupboxHabits.Name = "ttgroupboxHabits";
        this.ttgroupboxHabits.TabIndex = 38;

        this.CigaretteMedicalInfoHabits = new TTVisual.TTCheckBox();
        this.CigaretteMedicalInfoHabits.Value = false;
        this.CigaretteMedicalInfoHabits.Text = i18n("M21832", "Sigara");
        this.CigaretteMedicalInfoHabits.Enabled = false;
        this.CigaretteMedicalInfoHabits.Name = "CigaretteMedicalInfoHabits";
        this.CigaretteMedicalInfoHabits.TabIndex = 27;

        this.CigaretteUsageFrequencyMedicalInfoHabits = new TTVisual.TTObjectListBox();
        this.CigaretteUsageFrequencyMedicalInfoHabits.ReadOnly = false;
        this.CigaretteUsageFrequencyMedicalInfoHabits.ListDefName = "SKRSSigaraKullanimiList";
        this.CigaretteUsageFrequencyMedicalInfoHabits.Name = "CigaretteUsageFrequencyMedicalInfoHabits";
        this.CigaretteUsageFrequencyMedicalInfoHabits.TabIndex = 33;

        this.labelDescriptionMedicalInfoHabits = new TTVisual.TTLabel();
        this.labelDescriptionMedicalInfoHabits.Text = i18n("M10469", "Açıklama");
        this.labelDescriptionMedicalInfoHabits.Name = "labelDescriptionMedicalInfoHabits";
        this.labelDescriptionMedicalInfoHabits.TabIndex = 30;

        this.OtherMedicalInfoHabits = new TTVisual.TTCheckBox();
        this.OtherMedicalInfoHabits.Value = false;
        this.OtherMedicalInfoHabits.Text = i18n("M12780", "Diğer");
        this.OtherMedicalInfoHabits.Enabled = false;
        this.OtherMedicalInfoHabits.Name = "OtherMedicalInfoHabits";
        this.OtherMedicalInfoHabits.TabIndex = 31;

        this.DescriptionMedicalInfoHabits = new TTVisual.TTTextBox();
        this.DescriptionMedicalInfoHabits.Multiline = true;
        this.DescriptionMedicalInfoHabits.BackColor = "#F0F0F0";
        this.DescriptionMedicalInfoHabits.ReadOnly = true;
        this.DescriptionMedicalInfoHabits.Name = "DescriptionMedicalInfoHabits";
        this.DescriptionMedicalInfoHabits.TabIndex = 29;

        this.TeaMedicalInfoHabits = new TTVisual.TTCheckBox();
        this.TeaMedicalInfoHabits.Value = false;
        this.TeaMedicalInfoHabits.Text = i18n("M12346", "Çay");
        this.TeaMedicalInfoHabits.Enabled = false;
        this.TeaMedicalInfoHabits.Name = "TeaMedicalInfoHabits";
        this.TeaMedicalInfoHabits.TabIndex = 32;

        this.labelAlcoholUsageFrequencyMedicalInfoHabits = new TTVisual.TTLabel();
        this.labelAlcoholUsageFrequencyMedicalInfoHabits.Text = i18n("M10727", "Alkol Kullanım Sıklığı");
        this.labelAlcoholUsageFrequencyMedicalInfoHabits.Name = "labelAlcoholUsageFrequencyMedicalInfoHabits";
        this.labelAlcoholUsageFrequencyMedicalInfoHabits.TabIndex = 36;

        this.AlcoholMedicalInfoHabits = new TTVisual.TTCheckBox();
        this.AlcoholMedicalInfoHabits.Value = false;
        this.AlcoholMedicalInfoHabits.Text = i18n("M10725", "Alkol");
        this.AlcoholMedicalInfoHabits.Enabled = false;
        this.AlcoholMedicalInfoHabits.Name = "AlcoholMedicalInfoHabits";
        this.AlcoholMedicalInfoHabits.TabIndex = 26;

        this.AlcoholUsageFrequencyMedicalInfoHabits = new TTVisual.TTObjectListBox();
        this.AlcoholUsageFrequencyMedicalInfoHabits.ReadOnly = true;
        this.AlcoholUsageFrequencyMedicalInfoHabits.ListDefName = "SKRSAlkolKullanimiList";
        this.AlcoholUsageFrequencyMedicalInfoHabits.Name = "AlcoholUsageFrequencyMedicalInfoHabits";
        this.AlcoholUsageFrequencyMedicalInfoHabits.TabIndex = 35;

        this.labelCigaretteUsageFrequencyMedicalInfoHabits = new TTVisual.TTLabel();
        this.labelCigaretteUsageFrequencyMedicalInfoHabits.Text = i18n("M21840", "Sigara Kullanım Sıklığı");
        this.labelCigaretteUsageFrequencyMedicalInfoHabits.Name = "labelCigaretteUsageFrequencyMedicalInfoHabits";
        this.labelCigaretteUsageFrequencyMedicalInfoHabits.TabIndex = 34;

        this.CoffeeMedicalInfoHabits = new TTVisual.TTCheckBox();
        this.CoffeeMedicalInfoHabits.Value = false;
        this.CoffeeMedicalInfoHabits.Text = i18n("M17076", "Kahve");
        this.CoffeeMedicalInfoHabits.Enabled = false;
        this.CoffeeMedicalInfoHabits.Name = "CoffeeMedicalInfoHabits";
        this.CoffeeMedicalInfoHabits.TabIndex = 28;

        this.ttgroupboxDisability = new TTVisual.TTGroupBox();
        this.ttgroupboxDisability.Text = i18n("M13727", "Engel Durumu");
        this.ttgroupboxDisability.Name = "ttgroupboxDisability";
        this.ttgroupboxDisability.TabIndex = 39;

        this.ChronicMedicalInfoDisabledGroup = new TTVisual.TTCheckBox();
        this.ChronicMedicalInfoDisabledGroup.Value = false;
        this.ChronicMedicalInfoDisabledGroup.Text = i18n("M22422", "Süreğen(Kronik)");
        this.ChronicMedicalInfoDisabledGroup.Enabled = false;
        this.ChronicMedicalInfoDisabledGroup.Name = "ChronicMedicalInfoDisabledGroup";
        this.ChronicMedicalInfoDisabledGroup.TabIndex = 13;

        this.NonexistenceMedicalInfoDisabledGroup = new TTVisual.TTCheckBox();
        this.NonexistenceMedicalInfoDisabledGroup.Value = false;
        this.NonexistenceMedicalInfoDisabledGroup.Text = i18n("M24703", "Yok");
        this.NonexistenceMedicalInfoDisabledGroup.Enabled = false;
        this.NonexistenceMedicalInfoDisabledGroup.Name = "NonexistenceMedicalInfoDisabledGroup";
        this.NonexistenceMedicalInfoDisabledGroup.TabIndex = 16;

        this.HearingMedicalInfoDisabledGroup = new TTVisual.TTCheckBox();
        this.HearingMedicalInfoDisabledGroup.Value = false;
        this.HearingMedicalInfoDisabledGroup.Text = i18n("M16816", "İşitme");
        this.HearingMedicalInfoDisabledGroup.Enabled = false;
        this.HearingMedicalInfoDisabledGroup.Name = "HearingMedicalInfoDisabledGroup";
        this.HearingMedicalInfoDisabledGroup.TabIndex = 14;

        this.MentalMedicalInfoDisabledGroup = new TTVisual.TTCheckBox();
        this.MentalMedicalInfoDisabledGroup.Value = false;
        this.MentalMedicalInfoDisabledGroup.Text = i18n("M24771", "Zihinsel");
        this.MentalMedicalInfoDisabledGroup.Enabled = false;
        this.MentalMedicalInfoDisabledGroup.Name = "MentalMedicalInfoDisabledGroup";
        this.MentalMedicalInfoDisabledGroup.TabIndex = 15;

        this.OrthopedicMedicalInfoDisabledGroup = new TTVisual.TTCheckBox();
        this.OrthopedicMedicalInfoDisabledGroup.Value = false;
        this.OrthopedicMedicalInfoDisabledGroup.Text = i18n("M19803", "Ortopedik");
        this.OrthopedicMedicalInfoDisabledGroup.Enabled = false;
        this.OrthopedicMedicalInfoDisabledGroup.Name = "OrthopedicMedicalInfoDisabledGroup";
        this.OrthopedicMedicalInfoDisabledGroup.TabIndex = 17;

        this.PsychicAndEmotionalMedicalInfoDisabledGroup = new TTVisual.TTCheckBox();
        this.PsychicAndEmotionalMedicalInfoDisabledGroup.Value = false;
        this.PsychicAndEmotionalMedicalInfoDisabledGroup.Text = i18n("M21065", "Ruhsal ve Duygusal");
        this.PsychicAndEmotionalMedicalInfoDisabledGroup.Enabled = false;
        this.PsychicAndEmotionalMedicalInfoDisabledGroup.Name = "PsychicAndEmotionalMedicalInfoDisabledGroup";
        this.PsychicAndEmotionalMedicalInfoDisabledGroup.TabIndex = 18;

        this.SpeechAndLanguageMedicalInfoDisabledGroup = new TTVisual.TTCheckBox();
        this.SpeechAndLanguageMedicalInfoDisabledGroup.Value = false;
        this.SpeechAndLanguageMedicalInfoDisabledGroup.Text = i18n("M12854", "Dil ve Konuşma");
        this.SpeechAndLanguageMedicalInfoDisabledGroup.Enabled = false;
        this.SpeechAndLanguageMedicalInfoDisabledGroup.Name = "SpeechAndLanguageMedicalInfoDisabledGroup";
        this.SpeechAndLanguageMedicalInfoDisabledGroup.TabIndex = 19;

        this.VisionMedicalInfoDisabledGroup = new TTVisual.TTCheckBox();
        this.VisionMedicalInfoDisabledGroup.Value = false;
        this.VisionMedicalInfoDisabledGroup.Text = i18n("M14922", "Görme");
        this.VisionMedicalInfoDisabledGroup.Enabled = false;
        this.VisionMedicalInfoDisabledGroup.Name = "VisionMedicalInfoDisabledGroup";
        this.VisionMedicalInfoDisabledGroup.TabIndex = 21;

        this.UnclassifiedMedicalInfoDisabledGroup = new TTVisual.TTCheckBox();
        this.UnclassifiedMedicalInfoDisabledGroup.Value = false;
        this.UnclassifiedMedicalInfoDisabledGroup.Text = i18n("M21813", "Sınıflanmayan");
        this.UnclassifiedMedicalInfoDisabledGroup.Enabled = false;
        this.UnclassifiedMedicalInfoDisabledGroup.Name = "UnclassifiedMedicalInfoDisabledGroup";
        this.UnclassifiedMedicalInfoDisabledGroup.TabIndex = 20;

        this.ttgroupboxAllergies = new TTVisual.TTGroupBox();
        this.ttgroupboxAllergies.Text = i18n("M10688", "Alerjiler");
        this.ttgroupboxAllergies.Name = "ttgroupboxAllergies";
        this.ttgroupboxAllergies.TabIndex = 37;

        this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies = new TTVisual.TTGrid();
        this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies.ReadOnly = true;
        this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies.Name = "MedicalInfoFoodAllergiesMedicalInfoFoodAllergies";
        this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies.TabIndex = 24;

        this.DietMaterialMedicalInfoFoodAllergies = new TTVisual.TTListBoxColumn();
        this.DietMaterialMedicalInfoFoodAllergies.ListDefName = "DietMaterialListDefinition";
        this.DietMaterialMedicalInfoFoodAllergies.DataMember = "DietMaterial";
        this.DietMaterialMedicalInfoFoodAllergies.DisplayIndex = 0;
        this.DietMaterialMedicalInfoFoodAllergies.HeaderText = i18n("M14780", "Gıda Maddesi");
        this.DietMaterialMedicalInfoFoodAllergies.Name = "DietMaterialMedicalInfoFoodAllergies";
        this.DietMaterialMedicalInfoFoodAllergies.Width = 300;

        this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies = new TTVisual.TTGrid();
        this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies.ReadOnly = true;
        this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies.Name = "MedicalInfoDrugAllergiesMedicalInfoDrugAllergies";
        this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies.TabIndex = 25;

        this.ActiveIngredientMedicalInfoDrugAllergies = new TTVisual.TTListBoxColumn();
        this.ActiveIngredientMedicalInfoDrugAllergies.ListDefName = "ActiveIngredientList";
        this.ActiveIngredientMedicalInfoDrugAllergies.DataMember = "ActiveIngredient";
        this.ActiveIngredientMedicalInfoDrugAllergies.DisplayIndex = 0;
        this.ActiveIngredientMedicalInfoDrugAllergies.HeaderText = i18n("M16321", "İlaç Etken Maddesi");
        this.ActiveIngredientMedicalInfoDrugAllergies.Name = "ActiveIngredientMedicalInfoDrugAllergies";
        this.ActiveIngredientMedicalInfoDrugAllergies.Width = 300;

        this.OtherAllergiesMedicalInfoAllergies = new TTVisual.TTTextBox();
        this.OtherAllergiesMedicalInfoAllergies.Multiline = true;
        this.OtherAllergiesMedicalInfoAllergies.BackColor = "#F0F0F0";
        this.OtherAllergiesMedicalInfoAllergies.ReadOnly = false;
        this.OtherAllergiesMedicalInfoAllergies.Name = "OtherAllergiesMedicalInfoAllergies";
        this.OtherAllergiesMedicalInfoAllergies.TabIndex = 22;

        this.labelOtherAllergiesMedicalInfoAllergies = new TTVisual.TTLabel();
        this.labelOtherAllergiesMedicalInfoAllergies.Text = i18n("M12782", "Diğer Alerjiler");
        this.labelOtherAllergiesMedicalInfoAllergies.Name = "labelOtherAllergiesMedicalInfoAllergies";
        this.labelOtherAllergiesMedicalInfoAllergies.TabIndex = 23;

        this.Hemodialysis = new TTVisual.TTTextBox();
        this.Hemodialysis.Multiline = true;
        this.Hemodialysis.BackColor = "#F0F0F0";
        this.Hemodialysis.ReadOnly = false;
        this.Hemodialysis.Name = "Hemodialysis";
        this.Hemodialysis.TabIndex = 2;

        this.Transplantation = new TTVisual.TTTextBox();
        this.Transplantation.Multiline = true;
        this.Transplantation.BackColor = "#F0F0F0";
        this.Transplantation.ReadOnly = true;
        this.Transplantation.Name = "Transplantation";
        this.Transplantation.TabIndex = 11;

        this.Implant = new TTVisual.TTTextBox();
        this.Implant.Multiline = true;
        this.Implant.BackColor = "#F0F0F0";
        this.Implant.ReadOnly = false;
        this.Implant.Name = "Implant";
        this.Implant.TabIndex = 4;

        this.OtherInformation = new TTVisual.TTTextBox();
        this.OtherInformation.Multiline = true;
        this.OtherInformation.BackColor = "#F0F0F0";
        this.OtherInformation.ReadOnly = false;
        this.OtherInformation.Name = "OtherInformation";
        this.OtherInformation.TabIndex = 8;

        this.OncologicFollowUp = new TTVisual.TTTextBox();
        this.OncologicFollowUp.Multiline = true;
        this.OncologicFollowUp.BackColor = "#F0F0F0";
        this.OncologicFollowUp.ReadOnly = false;
        this.OncologicFollowUp.Name = "OncologicFollowUp";
        this.OncologicFollowUp.TabIndex = 6;

        this.ttpanelPoliclinic = new TTVisual.TTPanel();
        this.ttpanelPoliclinic.AutoSize = true;
        this.ttpanelPoliclinic.Text = i18n("M14681", "Genel Bilgiler");
        this.ttpanelPoliclinic.Name = "ttpanelPoliclinic";
        this.ttpanelPoliclinic.TabIndex = 53;

        this.rtfRequestDescription = new TTVisual.TTRichTextBoxControl();
        this.rtfRequestDescription.DisplayText = i18n("M16609", "İstek Açıklaması");
        this.rtfRequestDescription.TemplateGroupName = i18n("M17755", "Konsültasyon İstek Açıklaması");
        this.rtfRequestDescription.BackColor = "#DCDCDC";
        this.rtfRequestDescription.Name = "rtfRequestDescription";
        this.rtfRequestDescription.TabIndex = 10;
        this.rtfRequestDescription.ReadOnly = true;

        this.InPatientBed = new TTVisual.TTCheckBox();
        this.InPatientBed.Value = false;
        this.InPatientBed.Text = "Yatağında";
        this.InPatientBed.Enabled = false;
        this.InPatientBed.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.InPatientBed.Name = "InPatientBed";
        this.InPatientBed.TabIndex = 5;

        this.lblProcessEndDate = new TTVisual.TTLabel();
        this.lblProcessEndDate.Text = i18n("M17746", "Konsültasyon Bitiş Tarihi");
        this.lblProcessEndDate.Name = "lblProcessEndDate";
        this.lblProcessEndDate.TabIndex = 188;

        this.ProceduerDoctor = new TTVisual.TTObjectListBox();
        //this.ProceduerDoctor.LinkedControlName = "MasterResource";
        //this.ProceduerDoctor.LinkedRelationPath = "USERRESOURCES.RESOURCE";
        //this.ProceduerDoctor.ReadOnly = true;
        this.ProceduerDoctor.ListDefName = "ConsultationRequesterUserList";
        this.ProceduerDoctor.Name = "ProceduerDoctor";
        this.ProceduerDoctor.TabIndex = 1;

        this.lblProcessDate = new TTVisual.TTLabel();
        this.lblProcessDate.Text = i18n("M17744", "Konsültasyon Başlangıç Tarihi");
        this.lblProcessDate.Name = "lblProcessDate";
        this.lblProcessDate.TabIndex = 187;

        this.GridDiagnosis = new TTVisual.TTGrid();
        this.GridDiagnosis.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridDiagnosis.Text = i18n("M22736", "Tanı");
        this.GridDiagnosis.Name = "GridDiagnosis";
        this.GridDiagnosis.TabIndex = 5;

        this.SecDiagnose = new TTVisual.TTListBoxColumn();
        this.SecDiagnose.AllowMultiSelect = true;
        this.SecDiagnose.ListDefName = "DiagnosisListDefinition";
        this.SecDiagnose.DataMember = "Diagnose";
        this.SecDiagnose.DisplayIndex = 0;
        this.SecDiagnose.HeaderText = i18n("M17498", "Kesin Tanı");
        this.SecDiagnose.Name = "SecDiagnose";
        this.SecDiagnose.Width = 300;

        this.SecFreeDiagnosis = new TTVisual.TTTextBoxColumn();
        this.SecFreeDiagnosis.DataMember = "FreeDiagnosis";
        this.SecFreeDiagnosis.DisplayIndex = 1;
        this.SecFreeDiagnosis.HeaderText = i18n("M22737", "Tanı Açıklaması");
        this.SecFreeDiagnosis.Name = "SecFreeDiagnosis";
        this.SecFreeDiagnosis.Width = 200;

        this.SecIsMainDiagnose = new TTVisual.TTCheckBoxColumn();
        this.SecIsMainDiagnose.DataMember = "IsMainDiagnose";
        this.SecIsMainDiagnose.DisplayIndex = 2;
        this.SecIsMainDiagnose.HeaderText = i18n("M10926", "Ana Tanı");
        this.SecIsMainDiagnose.Name = "SecIsMainDiagnose";
        this.SecIsMainDiagnose.Width = 75;

        this.SecResponsibleUser = new TTVisual.TTListBoxColumn();
        this.SecResponsibleUser.ListDefName = "UserListDefinition";
        this.SecResponsibleUser.DataMember = "ResponsibleUser";
        this.SecResponsibleUser.DisplayIndex = 3;
        this.SecResponsibleUser.HeaderText = i18n("M22813", "Tanıyı Koyan");
        this.SecResponsibleUser.Name = "SecResponsibleUser";
        this.SecResponsibleUser.ReadOnly = true;
        this.SecResponsibleUser.Width = 200;

        this.SecDiagnoseDate = new TTVisual.TTDateTimePickerColumn();
        this.SecDiagnoseDate.Format = DateTimePickerFormat.Custom;
        this.SecDiagnoseDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.SecDiagnoseDate.DataMember = "DiagnoseDate";
        this.SecDiagnoseDate.DisplayIndex = 4;
        this.SecDiagnoseDate.HeaderText = i18n("M22750", "Tanı Giriş Tarihi");
        this.SecDiagnoseDate.Name = "SecDiagnoseDate";
        this.SecDiagnoseDate.ReadOnly = true;
        this.SecDiagnoseDate.Width = 170;

        this.RequesterDepatment = new TTVisual.TTObjectListBox();
        this.RequesterDepatment.ReadOnly = true;
        this.RequesterDepatment.ListDefName = "ResourceListDefinition";
        this.RequesterDepatment.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RequesterDepatment.Name = "RequesterDepatment";
        this.RequesterDepatment.TabIndex = 2;

        this.dtpProcessEndDate = new TTVisual.TTDateTimePicker();
        //this.dtpProcessEndDate.BackColor = "#F0F0F0";
        this.dtpProcessEndDate.CustomFormat = "dd/MM/yyyy hh:mm";
        this.dtpProcessEndDate.Format = DateTimePickerFormat.Long;
        //this.dtpProcessEndDate.ReadOnly = true;
        this.dtpProcessEndDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.dtpProcessEndDate.Name = "dtpProcessEndDate";
        this.dtpProcessEndDate.TabIndex = 186;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = i18n("M16656", "İstek Yapan");
        this.ttlabel8.BackColor = "#DCDCDC";
        this.ttlabel8.ForeColor = "#000000";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 51;

        this.ttpictureboxcontrol1 = new TTVisual.TTPictureBoxControl();
        this.ttpictureboxcontrol1.Name = "ttpictureboxcontrol1";
        this.ttpictureboxcontrol1.TabIndex = 0;

        this.chkEmergency = new TTVisual.TTCheckBox();
        this.chkEmergency.Value = false;
        this.chkEmergency.Text = "Acil";
        this.chkEmergency.Enabled = false;
        this.chkEmergency.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.chkEmergency.Name = "chkEmergency";
        this.chkEmergency.TabIndex = 4;

        this.ProcessDate = new TTVisual.TTDateTimePicker();
        //this.ProcessDate.BackColor = "#F0F0F0";
        this.ProcessDate.CustomFormat = "dd/MM/yyyy hh:mm";
        this.ProcessDate.Format = DateTimePickerFormat.Long;
        //this.ProcessDate.ReadOnly = true;
        this.ProcessDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProcessDate.Name = "ProcessDate";
        this.ProcessDate.TabIndex = 3;

        this.labelProcedureDoctor = new TTVisual.TTLabel();
        this.labelProcedureDoctor.Text = i18n("M17795", "Konsültasyonu Yapan");
        this.labelProcedureDoctor.BackColor = "#DCDCDC";
        this.labelProcedureDoctor.ForeColor = "#000000";
        this.labelProcedureDoctor.Name = "labelProcedureDoctor";
        this.labelProcedureDoctor.TabIndex = 53;

        this.lblPatientAdmissionGeneralInfo = new TTVisual.TTLabel();
        this.lblPatientAdmissionGeneralInfo.Text = "ApiController da model doldurulurken Common.PatientAdmissionInfo çağırılacak";
        this.lblPatientAdmissionGeneralInfo.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.lblPatientAdmissionGeneralInfo.ForeColor = "#FF0000";
        this.lblPatientAdmissionGeneralInfo.Name = "lblPatientAdmissionGeneralInfo";
        this.lblPatientAdmissionGeneralInfo.TabIndex = 184;

        this.RequestedDoctor = new TTVisual.TTObjectListBox();
        this.RequestedDoctor.ReadOnly = true;
        this.RequestedDoctor.ListDefName = "ConsultationRequesterUserList";
        this.RequestedDoctor.Name = "RequestedDoctor";
        this.RequestedDoctor.TabIndex = 0;

        /*    this.IsComplete = new TTVisual.TTCheckBox();
            this.IsComplete.Value = false;
            this.IsComplete.Title = "Tamamla";
            this.IsComplete.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
            this.IsComplete.Name = "IsComplete";
            this.IsComplete.TabIndex = 3;*/

        this.labelRequesterDepatment = new TTVisual.TTLabel();
        this.labelRequesterDepatment.Text = i18n("M16657", "İstek Yapan Birim");
        this.labelRequesterDepatment.BackColor = "#DCDCDC";
        this.labelRequesterDepatment.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelRequesterDepatment.ForeColor = "#000000";
        this.labelRequesterDepatment.Name = "labelRequesterDepatment";
        this.labelRequesterDepatment.TabIndex = 29;

        this.MasterResource = new TTVisual.TTObjectListBox();
        this.MasterResource.ReadOnly = true;
        this.MasterResource.ListDefName = "ResourceListDefinition";
        this.MasterResource.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MasterResource.Name = "MasterResource";
        this.MasterResource.TabIndex = 5;

        this.ProcedureSpeciality = new TTVisual.TTObjectListBox();
        this.ProcedureSpeciality.ReadOnly = true;
        this.ProcedureSpeciality.ListDefName = "SpecialityListDefinition";
        this.ProcedureSpeciality.Name = "ProcedureSpeciality";
        this.ProcedureSpeciality.TabIndex = 6;

        this.ProtocolNo = new TTVisual.TTTextBox();
        this.ProtocolNo.BackColor = "#F0F0F0";
        this.ProtocolNo.ReadOnly = true;
        this.ProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProtocolNo.Name = "ProtocolNo";
        this.ProtocolNo.TabIndex = 2;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = i18n("M17801", "Konsültasyonun Yapıldığı Uzmanlık Dalı");
        this.ttlabel7.BackColor = "#DCDCDC";
        this.ttlabel7.ForeColor = "#000000";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 182;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = i18n("M20566", "Protokol No");
        this.ttlabel9.BackColor = "#DCDCDC";
        this.ttlabel9.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel9.ForeColor = "#000000";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 8;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = i18n("M17800", "Konsültasyonun Yapıldığı Birim");
        this.ttlabel10.BackColor = "#DCDCDC";
        this.ttlabel10.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel10.ForeColor = "#000000";
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 35;

        this.tttabcontrolPoliclinic = new TTVisual.TTTabControl();
        this.tttabcontrolPoliclinic.Name = "tttabcontrolPoliclinic";
        this.tttabcontrolPoliclinic.TabIndex = 52;

        this.tttabpageKonsultasyon = new TTVisual.TTTabPage();
        this.tttabpageKonsultasyon.DisplayIndex = 0;
        this.tttabpageKonsultasyon.TabIndex = 0;
        this.tttabpageKonsultasyon.Text = i18n("M17742", "Konsültasyon");
        this.tttabpageKonsultasyon.Name = "tttabpageKonsultasyon";

        this.rtfHistory = new TTVisual.TTRichTextBoxControl();
        this.rtfHistory.DisplayText = i18n("M20117", "Özgeçmiş");
        this.rtfHistory.TemplateGroupName = i18n("M19209", "Muayene Özgeçmiş");
        this.rtfHistory.Iconized = true;
        this.rtfHistory.ReadOnly = true;
        this.rtfHistory.Enabled = false;
        this.rtfHistory.BackColor = "#FFFFFF";
        this.rtfHistory.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.rtfHistory.Name = "rtfHistory";
        this.rtfHistory.TabIndex = 1;

        this.tttabcontrol2 = new TTVisual.TTTabControl();
        this.tttabcontrol2.Name = "tttabcontrol2";
        this.tttabcontrol2.TabIndex = 5;

        this.EkUygulamalarTab = new TTVisual.TTTabPage();
        this.EkUygulamalarTab.DisplayIndex = 0;
        this.EkUygulamalarTab.TabIndex = 1;
        this.EkUygulamalarTab.Text = i18n("M13536", "Ek Uygulamalar");
        this.EkUygulamalarTab.Name = "EkUygulamalarTab";

        this.GridAdditionalApplications = new TTVisual.TTGrid();
        this.GridAdditionalApplications.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridAdditionalApplications.Name = "GridAdditionalApplications";
        this.GridAdditionalApplications.TabIndex = 0;

        this.SDateTime = new TTVisual.TTDateTimePickerColumn();
        this.SDateTime.Format = DateTimePickerFormat.Custom;
        this.SDateTime.CustomFormat = "dd/MM/yyyy HH:mm";
        this.SDateTime.DataMember = "ACTIONDATE";
        this.SDateTime.DisplayIndex = 0;
        this.SDateTime.HeaderText = "Tarih/Saat";
        this.SDateTime.Name = "SDateTime";
        this.SDateTime.ReadOnly = true;
        this.SDateTime.Width = 180;

        this.AProcedureObject = new TTVisual.TTListBoxColumn();
        this.AProcedureObject.ListDefName = "AdditionalApplicationListDefinition";
        this.AProcedureObject.DataMember = "PROCEDUREOBJECT";
        this.AProcedureObject.DisplayIndex = 1;
        this.AProcedureObject.HeaderText = i18n("M24283", "Yapılan İşlem");
        this.AProcedureObject.Name = "AProcedureObject";
        this.AProcedureObject.Width = 400;

        this.AdditionalProcedureDoctor = new TTVisual.TTListBoxColumn();
        this.AdditionalProcedureDoctor.ListDefName = "SpecialistDoctorListDefinition";
        this.AdditionalProcedureDoctor.DataMember = "PROCEDUREDOCTOR";
        this.AdditionalProcedureDoctor.LinkedControlName = "MasterResource";
        this.AdditionalProcedureDoctor.LinkedRelationPath = "USERRESOURCES.RESOURCE";
        this.AdditionalProcedureDoctor.DisplayIndex = 2;
        this.AdditionalProcedureDoctor.HeaderText = i18n("M16928", "İşlemi Yapan Doktor");
        this.AdditionalProcedureDoctor.Name = "AdditionalProcedureDoctor";
        this.AdditionalProcedureDoctor.Width = 200;

        this.Result = new TTVisual.TTTextBoxColumn();
        this.Result.DataMember = "RESULT";
        this.Result.DisplayIndex = 3;
        this.Result.HeaderText = i18n("M22078", "Sonuç");
        this.Result.Name = "Result";
        this.Result.Width = 100;

        this.NurseNotes = new TTVisual.TTTextBoxColumn();
        this.NurseNotes.DataMember = "NURSENOTES";
        this.NurseNotes.DisplayIndex = 4;
        this.NurseNotes.HeaderText = i18n("M13186", "Doktor Notu");
        this.NurseNotes.Name = "NurseNotes";
        this.NurseNotes.Width = 150;

        this.AdditionalMasterResource = new TTVisual.TTListBoxColumn();
        this.AdditionalMasterResource.ListDefName = "ResourceListDefinition";
        this.AdditionalMasterResource.DataMember = "EPISODEACTION.MASTERRESOURCE";
        this.AdditionalMasterResource.DisplayIndex = 5;
        this.AdditionalMasterResource.HeaderText = "MasterResource";
        this.AdditionalMasterResource.Name = "AdditionalMasterResource";
        this.AdditionalMasterResource.Visible = false;
        this.AdditionalMasterResource.Width = 100;

        this.MlzSarfTab = new TTVisual.TTTabPage();
        this.MlzSarfTab.DisplayIndex = 1;
        this.MlzSarfTab.TabIndex = 0;
        this.MlzSarfTab.Text = i18n("M19108", "Mlz.Sarf");
        this.MlzSarfTab.Name = "MlzSarfTab";

        this.cmbReportType = new TTVisual.TTEnumComboBox();
        this.cmbReportType.DataTypeName = 'ReportTypeEnum';
        this.cmbReportType.Name = 'cmbReportType';
        this.cmbReportType.TabIndex = 3;
        this.cmbReportType.ShowClearButton = true;

        //this.GridTreatmentMaterials = new TTVisual.TTGrid();
        //this.GridTreatmentMaterials.Name = "GridTreatmentMaterials";
        //this.GridTreatmentMaterials.TabIndex = 0;
        //this.GridTreatmentMaterials.AllowUserToAddRows = false;


        //this.TreatmentMaterial = new TTVisual.TTObjectListBox();
        //this.TreatmentMaterial.ListDefName = "ConsumableMaterialAndDrugList";
        //this.TreatmentMaterial.Name = "TreatmentMaterial";

        //this.TreatmentMaterialActionDate = new TTVisual.TTDateTimePickerColumn();
        //this.TreatmentMaterialActionDate.Format = DateTimePickerFormat.Custom;
        //this.TreatmentMaterialActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        //this.TreatmentMaterialActionDate.DataMember = "ActionDate";
        //this.TreatmentMaterialActionDate.DisplayIndex = 0;
        //this.TreatmentMaterialActionDate.HeaderText = "Tarih/Saat";
        //this.TreatmentMaterialActionDate.Name = "TreatmentMaterialActionDate";
        //this.TreatmentMaterialActionDate.ReadOnly = true;
        //this.TreatmentMaterialActionDate.Width = 180;

        //this.Material = new TTVisual.TTListBoxColumn();
        //this.Material.ListDefName = "ConsumableMaterialAndDrugList";
        //this.Material.DataMember = "Material";
        //this.Material.DisplayIndex = 1;
        //this.Material.HeaderText = "Sarf Malzeme";
        //this.Material.Name = "Material";
        //this.Material.Width = 325;

        //this.Barcode = new TTVisual.TTTextBoxColumn();
        //this.Barcode.DataMember = "Material.Barcode";
        //this.Barcode.DisplayIndex = 2;
        //this.Barcode.HeaderText = "Barkodu";
        //this.Barcode.Name = "Barcode";
        //this.Barcode.ReadOnly = true;
        //this.Barcode.Width = 100;

        //this.DistributionType = new TTVisual.TTTextBoxColumn();
        //this.DistributionType.DataMember = "Material.StockCard.DistributionType.DistributionType";
        //this.DistributionType.DisplayIndex = 4;
        //this.DistributionType.HeaderText = "Ölçü Birimi";
        //this.DistributionType.Name = "DistributionType";
        //this.DistributionType.ReadOnly = true;
        //this.DistributionType.Width = 100;

        ////this.UBBCode = new TTVisual.TTTextBoxColumn();
        ////this.UBBCode.DataMember = "UBBCode";
        ////this.UBBCode.DisplayIndex = 3;
        ////this.UBBCode.HeaderText = "UBB Kodu";
        ////this.UBBCode.Name = "UBBCode";
        ////this.UBBCode.Width = 100;

        //this.Amount = new TTVisual.TTTextBoxColumn();
        //this.Amount.DataMember = "Amount";
        //this.Amount.DisplayIndex = 4;
        //this.Amount.HeaderText = "Miktar";
        //this.Amount.Name = "Amount";
        //this.Amount.Width = 100;

        //this.OzelDurum = new TTVisual.TTListBoxColumn();
        //this.OzelDurum.ListDefName = "OzelDurumListDefinition";
        //this.OzelDurum.DataMember = "OzelDurum";
        //this.OzelDurum.DisplayIndex = 5;
        //this.OzelDurum.HeaderText = "Özel Durum";
        //this.OzelDurum.Name = "OzelDurum";
        //this.OzelDurum.Width = 100;

        //this.Notes = new TTVisual.TTTextBoxColumn();
        //this.Notes.DataMember = "Note";
        //this.Notes.DisplayIndex = 6;
        //this.Notes.HeaderText = "Notlar";
        //this.Notes.Name = "Notes";
        //this.Notes.Width = 100;

        //this.CokluOzelDurum = new TTVisual.TTButtonColumn();
        //this.CokluOzelDurum.DisplayIndex = 7;
        //this.CokluOzelDurum.HeaderText = "Çoklu Özel Durum";
        //this.CokluOzelDurum.Name = "CokluOzelDurum";
        //this.CokluOzelDurum.Width = 100;

        //this.KodsuzMalzemeFiyatı = new TTVisual.TTTextBoxColumn();
        //this.KodsuzMalzemeFiyatı.DisplayIndex = 8;
        //this.KodsuzMalzemeFiyatı.HeaderText = "Kodsuz Malzeme Fiyatı";
        //this.KodsuzMalzemeFiyatı.Name = "KodsuzMalzemeFiyatı";
        //this.KodsuzMalzemeFiyatı.Visible = false;
        //this.KodsuzMalzemeFiyatı.Width = 100;

        //this.MalzemeTuru = new TTVisual.TTListBoxColumn();
        //this.MalzemeTuru.ListDefName = "MalzemeTuruDefinitionList";
        //this.MalzemeTuru.DisplayIndex = 9;
        //this.MalzemeTuru.HeaderText = "Malzemenin Türü";
        //this.MalzemeTuru.Name = "MalzemeTuru";
        //this.MalzemeTuru.Visible = false;
        //this.MalzemeTuru.Width = 100;

        //this.Kdv = new TTVisual.TTTextBoxColumn();
        //this.Kdv.DisplayIndex = 10;
        //this.Kdv.HeaderText = "Kdv";
        //this.Kdv.Name = "Kdv";
        //this.Kdv.Visible = false;
        //this.Kdv.Width = 100;

        //this.MalzemeBrans = new TTVisual.TTTextBoxColumn();
        //this.MalzemeBrans.DisplayIndex = 11;
        //this.MalzemeBrans.HeaderText = "Malzemenin Branşı";
        //this.MalzemeBrans.Name = "MalzemeBrans";
        //this.MalzemeBrans.Visible = false;
        //this.MalzemeBrans.Width = 100;

        //this.SatinAlisTarihi = new TTVisual.TTDateTimePickerColumn();
        //this.SatinAlisTarihi.DisplayIndex = 12;
        //this.SatinAlisTarihi.HeaderText = "Satın Alış Tarihi";
        //this.SatinAlisTarihi.Name = "SatinAlisTarihi";
        //this.SatinAlisTarihi.Visible = false;
        //this.SatinAlisTarihi.Width = 100;

        this.tttabpage4 = new TTVisual.TTTabPage();
        this.tttabpage4.DisplayIndex = 2;
        this.tttabpage4.TabIndex = 2;
        this.tttabpage4.Text = i18n("M17742", "Konsültasyon");
        this.tttabpage4.Name = "tttabpage4";

        this.ConsultationGrid = new TTVisual.TTGrid();
        this.ConsultationGrid.Name = "ConsultationGrid";
        this.ConsultationGrid.TabIndex = 50;

        this.ConsultationDate = new TTVisual.TTDateTimePickerColumn();
        this.ConsultationDate.DisplayIndex = 0;
        this.ConsultationDate.HeaderText = i18n("M16886", "İşlem Tarihi");
        this.ConsultationDate.Name = "ConsultationDate";
        this.ConsultationDate.ReadOnly = true;
        this.ConsultationDate.Width = 100;

        this.RequesterHospital = new TTVisual.TTTextBoxColumn();
        this.RequesterHospital.DisplayIndex = 1;
        this.RequesterHospital.HeaderText = i18n("M16664", "İstek Yapan XXXXXX");
        this.RequesterHospital.Name = "RequesterHospital";
        this.RequesterHospital.ReadOnly = true;
        this.RequesterHospital.Width = 150;

        this.RequesterDepartment = new TTVisual.TTTextBoxColumn();
        this.RequesterDepartment.DisplayIndex = 2;
        this.RequesterDepartment.HeaderText = i18n("M16657", "İstek Yapan Birim");
        this.RequesterDepartment.Name = "RequesterDepartment";
        this.RequesterDepartment.ReadOnly = true;
        this.RequesterDepartment.Width = 150;

        this.RequestedHospital = new TTVisual.TTTextBoxColumn();
        this.RequestedHospital.DisplayIndex = 3;
        this.RequestedHospital.HeaderText = i18n("M16682", "İstek Yapılan XXXXXX");
        this.RequestedHospital.Name = "RequestedHospital";
        this.RequestedHospital.ReadOnly = true;
        this.RequestedHospital.Width = 150;

        this.RequestedDepartment = new TTVisual.TTTextBoxColumn();
        this.RequestedDepartment.DisplayIndex = 4;
        this.RequestedDepartment.HeaderText = i18n("M16678", "İstek Yapılan Birim");
        this.RequestedDepartment.Name = "RequestedDepartment";
        this.RequestedDepartment.ReadOnly = true;
        this.RequestedDepartment.Width = 150;

        this.RequestReason = new TTVisual.TTRichTextBoxControlColumn();
        this.RequestReason.DisplayIndex = 5;
        this.RequestReason.HeaderText = i18n("M16635", "İstek Nedeni");
        this.RequestReason.Name = "RequestReason";
        this.RequestReason.ReadOnly = true;
        this.RequestReason.Width = 150;

        this.ConsultationResultAndOffer = new TTVisual.TTRichTextBoxControlColumn();
        this.ConsultationResultAndOffer.DisplayIndex = 6;
        this.ConsultationResultAndOffer.HeaderText = i18n("M17781", "Konsültasyon Sonucu");
        this.ConsultationResultAndOffer.Name = "ConsultationResultAndOffer";
        this.ConsultationResultAndOffer.ReadOnly = true;
        this.ConsultationResultAndOffer.Width = 150;

        this.btnConsultationRequest = new TTVisual.TTButton();
        this.btnConsultationRequest.Text = i18n("M16655", "İstek Yap");
        this.btnConsultationRequest.Name = "btnConsultationRequest";
        this.btnConsultationRequest.TabIndex = 12;

        this.chkConsultationInPatientBed = new TTVisual.TTCheckBox();
        this.chkConsultationInPatientBed.Value = false;
        this.chkConsultationInPatientBed.Text = "Yatağında";
        this.chkConsultationInPatientBed.Name = "chkConsultationInPatientBed";
        this.chkConsultationInPatientBed.TabIndex = 11;

        this.chkConsultationEmergency = new TTVisual.TTCheckBox();
        this.chkConsultationEmergency.Value = false;
        this.chkConsultationEmergency.Text = "Acil";
        this.chkConsultationEmergency.Name = "chkConsultationEmergency";
        this.chkConsultationEmergency.TabIndex = 10;

        this.lblConsultationRequestedUser = new TTVisual.TTLabel();
        this.lblConsultationRequestedUser.Text = i18n("M17772", "Konsültasyon İstenen Kişi");
        this.lblConsultationRequestedUser.Name = "lblConsultationRequestedUser";
        this.lblConsultationRequestedUser.TabIndex = 8;

        this.ConsultationRequestedUser = new TTVisual.TTObjectListBox();
        this.ConsultationRequestedUser.LinkedControlName = "ConsultationRequestedResource";
        this.ConsultationRequestedUser.LinkedRelationPath = "USERRESOURCES.RESOURCE";
        this.ConsultationRequestedUser.ListDefName = "ConsultationRequesterUserList";
        this.ConsultationRequestedUser.Name = "ConsultationRequestedUser";
        this.ConsultationRequestedUser.TabIndex = 7;

        this.lblConsultationRequestedResource = new TTVisual.TTLabel();
        this.lblConsultationRequestedResource.Text = i18n("M17765", "Konsültasyon İstenen Birim");
        this.lblConsultationRequestedResource.Name = "lblConsultationRequestedResource";
        this.lblConsultationRequestedResource.TabIndex = 6;

        this.ConsultationRequestedResource = new TTVisual.TTObjectListBox();
        this.ConsultationRequestedResource.ListDefName = "ConsultationRequestResourceList";
        this.ConsultationRequestedResource.Name = "ConsultationRequestedResource";
        this.ConsultationRequestedResource.TabIndex = 5;

        this.GrdConsultation = new TTVisual.TTGrid();
        this.GrdConsultation.Name = "GrdConsultation";
        this.GrdConsultation.TabIndex = 4;

        this.RequestedResource = new TTVisual.TTListBoxColumn();
        this.RequestedResource.ListDefName = "ConsultationRequestResourceList";
        this.RequestedResource.DataMember = "MasterResource";
        this.RequestedResource.DisplayIndex = 0;
        this.RequestedResource.HeaderText = i18n("M17765", "Konsültasyon İstenen Birim");
        this.RequestedResource.Name = "RequestedResource";
        this.RequestedResource.Width = 100;

        this.ttlistboxcolumn8 = new TTVisual.TTListBoxColumn();
        this.ttlistboxcolumn8.ListDefName = "ConsultationRequesterUserList";
        this.ttlistboxcolumn8.DataMember = "ProcedureDoctor";
        this.ttlistboxcolumn8.LinkedControlName = "RequestedResource";
        this.ttlistboxcolumn8.LinkedRelationPath = "USERRESOURCES.RESOURCE";
        this.ttlistboxcolumn8.DisplayIndex = 1;
        this.ttlistboxcolumn8.HeaderText = "Konsültasyon İstenen";
        this.ttlistboxcolumn8.Name = "ttlistboxcolumn8";
        this.ttlistboxcolumn8.Width = 100;

        this.RequestDescription = new TTVisual.TTRichTextBoxControlColumn();
        this.RequestDescription.DataMember = "RequestDescription";
        this.RequestDescription.DisplayIndex = 2;
        this.RequestDescription.HeaderText = i18n("M16609", "İstek Açıklaması");
        this.RequestDescription.Name = "RequestDescription";
        this.RequestDescription.Width = 100;

        this.chkColumnEmergency = new TTVisual.TTCheckBoxColumn();
        this.chkColumnEmergency.DataMember = "Emergency";
        this.chkColumnEmergency.DisplayIndex = 3;
        this.chkColumnEmergency.HeaderText = "Acil";
        this.chkColumnEmergency.Name = "chkColumnEmergency";
        this.chkColumnEmergency.Width = 100;

        this.chkInPatientBed = new TTVisual.TTCheckBoxColumn();
        this.chkInPatientBed.DataMember = "InPatientBed";
        this.chkInPatientBed.DisplayIndex = 4;
        this.chkInPatientBed.HeaderText = "Yatağında";
        this.chkInPatientBed.Name = "chkInPatientBed";
        this.chkInPatientBed.Width = 100;

        this.tttabpage5 = new TTVisual.TTTabPage();
        this.tttabpage5.DisplayIndex = 3;
        this.tttabpage5.TabIndex = 3;
        this.tttabpage5.Text = i18n("M22097", "Sonuç Grafik");
        this.tttabpage5.Name = "tttabpage5";

        this.pnlRightBottom = new TTVisual.TTPanel();
        this.pnlRightBottom.AutoSize = true;
        this.pnlRightBottom.Name = "pnlRightBottom";
        this.pnlRightBottom.TabIndex = 2;

        this.rtfConsultationResultAndOffers = new TTVisual.TTRichTextBoxControl();
        this.rtfConsultationResultAndOffers.DisplayText = "Konsültasyon Sonuç Ve Önerileri";
        this.rtfConsultationResultAndOffers.TemplateGroupName = "Konsültasyon Sonuç Ve Önerileri";
        this.rtfConsultationResultAndOffers.BackColor = "#DCDCDC";
        this.rtfConsultationResultAndOffers.Name = "rtfConsultationResultAndOffers";
        this.rtfConsultationResultAndOffers.TabIndex = 11;

        this.IsTreatmentMaterialEmpty = new TTVisual.TTCheckBox();
        this.IsTreatmentMaterialEmpty.Value = false;
        this.IsTreatmentMaterialEmpty.Text = i18n("M18603", "Malzeme Sarfı Yoktur.");
        this.IsTreatmentMaterialEmpty.Name = "IsTreatmentMaterialEmpty";
        this.IsTreatmentMaterialEmpty.TabIndex = 8;

        this.rtfPhysicalExamination = new TTVisual.TTRichTextBoxControl();
        this.rtfPhysicalExamination.DisplayText = i18n("M14387", "Fiziki Muayene");
        this.rtfPhysicalExamination.TemplateGroupName = i18n("M19186", "Muayene Fizik");
        this.rtfPhysicalExamination.Iconized = true;
        this.rtfPhysicalExamination.ReadOnly = true;
        this.rtfPhysicalExamination.Enabled = false;
        this.rtfPhysicalExamination.BackColor = "#FFFFFF";
        this.rtfPhysicalExamination.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.rtfPhysicalExamination.Name = "rtfPhysicalExamination";
        this.rtfPhysicalExamination.TabIndex = 2;

        this.rtfComplaint = new TTVisual.TTRichTextBoxControl();
        this.rtfComplaint.DisplayText = i18n("M22483", "Şikayet");
        this.rtfComplaint.TemplateGroupName = i18n("M19221", "Muayene Şikayet");
        this.rtfComplaint.Iconized = true;
        this.rtfComplaint.BackColor = "#FFFFFF";
        this.rtfComplaint.ReadOnly = true;
        this.rtfComplaint.Enabled = false;
        this.rtfComplaint.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.rtfComplaint.Name = "rtfComplaint";
        this.rtfComplaint.TabIndex = 0;

        this.tttabpageIstemPaneli = new TTVisual.TTTabPage();
        this.tttabpageIstemPaneli.DisplayIndex = 1;
        this.tttabpageIstemPaneli.TabIndex = 3;
        this.tttabpageIstemPaneli.Text = i18n("M16693", "İstem Paneli");
        this.tttabpageIstemPaneli.Name = "tttabpageIstemPaneli";

        this.tttabpageEOrder = new TTVisual.TTTabPage();
        this.tttabpageEOrder.DisplayIndex = 2;
        this.tttabpageEOrder.TabIndex = 4;
        this.tttabpageEOrder.Text = "E-Order";
        this.tttabpageEOrder.Name = "tttabpageEOrder";

        this.GridNursingOrders = new TTVisual.TTGrid();
        this.GridNursingOrders.Name = "GridNursingOrders";
        this.GridNursingOrders.TabIndex = 0;

        this.RPT = new TTVisual.TTButtonColumn();
        this.RPT.Text = i18n("M22700", "Talimat Tekrarla");
        this.RPT.DisplayIndex = 0;
        this.RPT.HeaderText = i18n("M22700", "Talimat Tekrarla");
        this.RPT.Name = "RPT";
        this.RPT.Width = 100;

        this.OrderActionDate = new TTVisual.TTDateTimePickerColumn();
        this.OrderActionDate.Format = DateTimePickerFormat.Custom;
        this.OrderActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.OrderActionDate.DataMember = "ActionDate";
        this.OrderActionDate.DisplayIndex = 1;
        this.OrderActionDate.HeaderText = "Tarih/Saat";
        this.OrderActionDate.Name = "OrderActionDate";
        this.OrderActionDate.ReadOnly = true;
        this.OrderActionDate.Width = 120;

        this.OrderProcedureObject = new TTVisual.TTListBoxColumn();
        this.OrderProcedureObject.ListDefName = "VitalSignAndNursingListDefinition";
        this.OrderProcedureObject.DataMember = "ProcedureObject";
        this.OrderProcedureObject.DisplayIndex = 2;
        this.OrderProcedureObject.HeaderText = i18n("M16818", "İşlem");
        this.OrderProcedureObject.Name = "OrderProcedureObject";
        this.OrderProcedureObject.Width = 250;

        this.PeriodStartTime = new TTVisual.TTDateTimePickerColumn();
        this.PeriodStartTime.Format = DateTimePickerFormat.Custom;
        this.PeriodStartTime.CustomFormat = "dd/MM/yyyy HH:mm";
        this.PeriodStartTime.DataMember = "PeriodStartTime";
        this.PeriodStartTime.DisplayIndex = 3;
        this.PeriodStartTime.HeaderText = i18n("M16654", "İstek Uygulama Zamanı");
        this.PeriodStartTime.Name = "PeriodStartTime";
        this.PeriodStartTime.Width = 160;

        this.ExecutionDate = new TTVisual.TTDateTimePickerColumn();
        this.ExecutionDate.DataMember = "ExecutionDate";
        this.ExecutionDate.DisplayIndex = 4;
        this.ExecutionDate.HeaderText = i18n("M23792", "Uygulanma Zamanı");
        this.ExecutionDate.Name = "ExecutionDate";
        this.ExecutionDate.ReadOnly = true;
        this.ExecutionDate.Width = 160;

        this.NursingApplicationResult = new TTVisual.TTTextBoxColumn();
        this.NursingApplicationResult.DataMember = "Result";
        this.NursingApplicationResult.DisplayIndex = 5;
        this.NursingApplicationResult.HeaderText = i18n("M22078", "Sonuç");
        this.NursingApplicationResult.Name = "NursingApplicationResult";
        this.NursingApplicationResult.ReadOnly = true;
        this.NursingApplicationResult.Width = 100;

        this.NursingApplicationNurseNote = new TTVisual.TTTextBoxColumn();
        this.NursingApplicationNurseNote.DataMember = "Notes";
        this.NursingApplicationNurseNote.DisplayIndex = 6;
        this.NursingApplicationNurseNote.HeaderText = i18n("M15653", "Hemşire Notu");
        this.NursingApplicationNurseNote.Name = "NursingApplicationNurseNote";
        this.NursingApplicationNurseNote.ReadOnly = true;
        this.NursingApplicationNurseNote.Width = 150;

        this.CreateOrderDetailBeforeSave = new TTVisual.TTButtonColumn();
        this.CreateOrderDetailBeforeSave.Text = i18n("M15719", "Hemşireye Gönder");
        this.CreateOrderDetailBeforeSave.DisplayIndex = 7;
        this.CreateOrderDetailBeforeSave.HeaderText = i18n("M15719", "Hemşireye Gönder");
        this.CreateOrderDetailBeforeSave.Name = "CreateOrderDetailBeforeSave";
        this.CreateOrderDetailBeforeSave.Width = 100;

        this.tttabpageSagRapor = new TTVisual.TTTabPage();
        this.tttabpageSagRapor.DisplayIndex = 3;
        this.tttabpageSagRapor.TabIndex = 5;
        this.tttabpageSagRapor.Text = i18n("M21157", "Sağ.Rapor");
        this.tttabpageSagRapor.Name = "tttabpageSagRapor";

        this.btnReports = new TTVisual.TTButton();
        this.btnReports.Text = i18n("M20887", "Raporlar");
        this.btnReports.Name = "btnReports";
        this.btnReports.TabIndex = 7;

        this.tttabpageHastaGeçmişi = new TTVisual.TTTabPage();
        this.tttabpageHastaGeçmişi.DisplayIndex = 4;
        this.tttabpageHastaGeçmişi.TabIndex = 7;
        this.tttabpageHastaGeçmişi.Text = "Hasta Geçmişi";
        this.tttabpageHastaGeçmişi.Name = "tttabpageHastaGeçmişi";

        this.tttabcontrol3 = new TTVisual.TTTabControl();
        this.tttabcontrol3.Name = "tttabcontrol3";
        this.tttabcontrol3.TabIndex = 1;

        this.HealthCommiteeActionsTab = new TTVisual.TTTabPage();
        this.HealthCommiteeActionsTab.DisplayIndex = 0;
        this.HealthCommiteeActionsTab.TabIndex = 1;
        this.HealthCommiteeActionsTab.Text = i18n("M21156", "Sağ.Kurulu");
        this.HealthCommiteeActionsTab.Name = "HealthCommiteeActionsTab";

        this.HealthCommiteeActions = new TTVisual.TTGrid();
        this.HealthCommiteeActions.OnRowMarkerDoubleClickShowTTObjectForm = false;
        this.HealthCommiteeActions.Name = "HealthCommiteeActions";
        this.HealthCommiteeActions.TabIndex = 0;

        this.Hospital = new TTVisual.TTTextBoxColumn();
        this.Hospital.DisplayIndex = 0;
        this.Hospital.HeaderText = "XXXXXX";
        this.Hospital.Name = "Hospital";
        this.Hospital.ReadOnly = true;
        this.Hospital.Width = 195;

        this.HealthCommiteeActionID = new TTVisual.TTTextBoxColumn();
        this.HealthCommiteeActionID.DisplayIndex = 1;
        this.HealthCommiteeActionID.HeaderText = i18n("M16866", "İşlem No");
        this.HealthCommiteeActionID.Name = "HealthCommiteeActionID";
        this.HealthCommiteeActionID.ReadOnly = true;
        this.HealthCommiteeActionID.Width = 100;

        this.HealthCommiteeActionDate = new TTVisual.TTDateTimePickerColumn();
        this.HealthCommiteeActionDate.DisplayIndex = 2;
        this.HealthCommiteeActionDate.HeaderText = i18n("M16886", "İşlem Tarihi");
        this.HealthCommiteeActionDate.Name = "HealthCommiteeActionDate";
        this.HealthCommiteeActionDate.ReadOnly = true;
        this.HealthCommiteeActionDate.Width = 120;

        this.HCObjectID = new TTVisual.TTTextBoxColumn();
        this.HCObjectID.DisplayIndex = 3;
        this.HCObjectID.HeaderText = "HCObjectID";
        this.HCObjectID.Name = "HCObjectID";
        this.HCObjectID.ReadOnly = true;
        this.HCObjectID.Visible = false;
        this.HCObjectID.Width = 100;

        this.tttabpage15 = new TTVisual.TTTabPage();
        this.tttabpage15.DisplayIndex = 1;
        this.tttabpage15.TabIndex = 6;
        this.tttabpage15.Text = i18n("M22792", "Tanıları");
        this.tttabpage15.Name = "tttabpage15";

        this.GridEpisodeDiagnosis = new TTVisual.TTGrid();
        this.GridEpisodeDiagnosis.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridEpisodeDiagnosis.ReadOnly = true;
        this.GridEpisodeDiagnosis.Text = i18n("M22736", "Tanı");
        this.GridEpisodeDiagnosis.Name = "GridEpisodeDiagnosis";
        this.GridEpisodeDiagnosis.TabIndex = 6;

        this.EpisodeAddToHistory = new TTVisual.TTCheckBoxColumn();
        this.EpisodeAddToHistory.DataMember = "AddToHistory";
        this.EpisodeAddToHistory.DisplayIndex = 0;
        this.EpisodeAddToHistory.HeaderText = i18n("M20121", "Özgeçmişe Ekle");
        this.EpisodeAddToHistory.Name = "EpisodeAddToHistory";
        this.EpisodeAddToHistory.Width = 90;

        this.EpisodeDiagnose = new TTVisual.TTListBoxColumn();
        this.EpisodeDiagnose.ListDefName = "DiagnosisListDefinition";
        this.EpisodeDiagnose.DataMember = "Diagnose";
        this.EpisodeDiagnose.DisplayIndex = 1;
        this.EpisodeDiagnose.HeaderText = i18n("M22736", "Tanı");
        this.EpisodeDiagnose.Name = "EpisodeDiagnose";
        this.EpisodeDiagnose.Width = 275;

        this.EpisodeFreeDiagnosis = new TTVisual.TTTextBoxColumn();
        this.EpisodeFreeDiagnosis.DataMember = "FreeDiagnosis";
        this.EpisodeFreeDiagnosis.DisplayIndex = 2;
        this.EpisodeFreeDiagnosis.HeaderText = i18n("M21631", "Serbest Tanı");
        this.EpisodeFreeDiagnosis.Name = "EpisodeFreeDiagnosis";
        this.EpisodeFreeDiagnosis.Width = 200;

        this.EpisodeDiagnosisType = new TTVisual.TTEnumComboBoxColumn();
        this.EpisodeDiagnosisType.DataTypeName = "DiagnosisTypeEnum";
        this.EpisodeDiagnosisType.DataMember = "DiagnosisType";
        this.EpisodeDiagnosisType.DisplayIndex = 3;
        this.EpisodeDiagnosisType.HeaderText = i18n("M22781", "Tanı Tipi");
        this.EpisodeDiagnosisType.Name = "EpisodeDiagnosisType";
        this.EpisodeDiagnosisType.Width = 80;

        this.EpisodeIsMainDiagnose = new TTVisual.TTCheckBoxColumn();
        this.EpisodeIsMainDiagnose.DataMember = "IsMainDiagnose";
        this.EpisodeIsMainDiagnose.DisplayIndex = 4;
        this.EpisodeIsMainDiagnose.HeaderText = i18n("M10926", "Ana Tanı");
        this.EpisodeIsMainDiagnose.Name = "EpisodeIsMainDiagnose";
        this.EpisodeIsMainDiagnose.Width = 75;

        this.EpisodeResponsibleUser = new TTVisual.TTListBoxColumn();
        this.EpisodeResponsibleUser.ListDefName = "UserListDefinition";
        this.EpisodeResponsibleUser.DataMember = "ResponsibleUser";
        this.EpisodeResponsibleUser.DisplayIndex = 5;
        this.EpisodeResponsibleUser.HeaderText = i18n("M22813", "Tanıyı Koyan");
        this.EpisodeResponsibleUser.Name = "EpisodeResponsibleUser";
        this.EpisodeResponsibleUser.Width = 115;

        this.EpisodeDiagnoseDate = new TTVisual.TTDateTimePickerColumn();
        this.EpisodeDiagnoseDate.Format = DateTimePickerFormat.Custom;
        this.EpisodeDiagnoseDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.EpisodeDiagnoseDate.DataMember = "DiagnoseDate";
        this.EpisodeDiagnoseDate.DisplayIndex = 6;
        this.EpisodeDiagnoseDate.HeaderText = i18n("M22750", "Tanı Giriş Tarihi");
        this.EpisodeDiagnoseDate.Name = "EpisodeDiagnoseDate";
        this.EpisodeDiagnoseDate.Width = 100;

        this.EntryActionType = new TTVisual.TTEnumComboBoxColumn();
        this.EntryActionType.DataTypeName = "ActionTypeEnum";
        this.EntryActionType.DataMember = "EntryActionType";
        this.EntryActionType.DisplayIndex = 7;
        this.EntryActionType.HeaderText = i18n("M14808", "Giriş Yapılan İşlem");
        this.EntryActionType.Name = "EntryActionType";
        this.EntryActionType.Width = 100;

        this.DiagnosisHistory = new TTVisual.TTGrid();
        this.DiagnosisHistory.ReadOnly = true;
        this.DiagnosisHistory.Name = "DiagnosisHistory";
        this.DiagnosisHistory.TabIndex = 0;

        this.DiagnoseDate = new TTVisual.TTDateTimePickerColumn();
        this.DiagnoseDate.DataMember = "DiagnoseDate";
        this.DiagnoseDate.DisplayIndex = 0;
        this.DiagnoseDate.HeaderText = i18n("M22750", "Tanı Giriş Tarihi  ");
        this.DiagnoseDate.Name = "DiagnoseDate";
        this.DiagnoseDate.ReadOnly = true;
        this.DiagnoseDate.Width = 170;

        this.Diagnose = new TTVisual.TTListBoxColumn();
        this.Diagnose.ListDefName = "DiagnosisListDefinition";
        this.Diagnose.DataMember = "Diagnose";
        this.Diagnose.DisplayIndex = 1;
        this.Diagnose.HeaderText = i18n("M22736", "Tanı");
        this.Diagnose.Name = "Diagnose";
        this.Diagnose.ReadOnly = true;
        this.Diagnose.Width = 300;

        this.ResponsibleUser = new TTVisual.TTListBoxColumn();
        this.ResponsibleUser.ListDefName = "UserListDefinition";
        this.ResponsibleUser.DataMember = "ResponsibleUser";
        this.ResponsibleUser.DisplayIndex = 2;
        this.ResponsibleUser.HeaderText = i18n("M22813", "Tanıyı Koyan");
        this.ResponsibleUser.Name = "ResponsibleUser";
        this.ResponsibleUser.ReadOnly = true;
        this.ResponsibleUser.Width = 170;

        this.DiagnosisType = new TTVisual.TTEnumComboBoxColumn();
        this.DiagnosisType.DataTypeName = "DiagnosisTypeEnum";
        this.DiagnosisType.DataMember = "DiagnosisType";
        this.DiagnosisType.DisplayIndex = 3;
        this.DiagnosisType.HeaderText = i18n("M22781", "Tanı Tipi");
        this.DiagnosisType.Name = "DiagnosisType";
        this.DiagnosisType.ReadOnly = true;
        this.DiagnosisType.Width = 70;

        this.IsMainDiagnose = new TTVisual.TTCheckBoxColumn();
        this.IsMainDiagnose.DataMember = "IsMainDiagnose";
        this.IsMainDiagnose.DisplayIndex = 4;
        this.IsMainDiagnose.HeaderText = i18n("M10926", "Ana Tanı");
        this.IsMainDiagnose.Name = "IsMainDiagnose";
        this.IsMainDiagnose.ReadOnly = true;
        this.IsMainDiagnose.Width = 70;

        this.lblOldDiagnosis = new TTVisual.TTLabel();
        this.lblOldDiagnosis.Text = i18n("M14636", "Geçmiş Tanıları");
        this.lblOldDiagnosis.Name = "lblOldDiagnosis";
        this.lblOldDiagnosis.TabIndex = 2;

        this.lblEpisodeDiagnosis = new TTVisual.TTLabel();
        this.lblEpisodeDiagnosis.Text = i18n("M24028", "Vaka Tanıları");
        this.lblEpisodeDiagnosis.Name = "lblEpisodeDiagnosis";
        this.lblEpisodeDiagnosis.TabIndex = 7;

        this.tttabpage16 = new TTVisual.TTTabPage();
        this.tttabpage16.DisplayIndex = 2;
        this.tttabpage16.TabIndex = 10;
        this.tttabpage16.Text = "Tıbbi Uyglmr.";
        this.tttabpage16.Name = "tttabpage16";

        this.ManipulationGrid = new TTVisual.TTGrid();
        this.ManipulationGrid.ReadOnly = true;
        this.ManipulationGrid.Name = "ManipulationGrid";
        this.ManipulationGrid.TabIndex = 0;

        this.ManipulationActionDate = new TTVisual.TTDateTimePickerColumn();
        this.ManipulationActionDate.Format = DateTimePickerFormat.Custom;
        this.ManipulationActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ManipulationActionDate.DisplayIndex = 0;
        this.ManipulationActionDate.HeaderText = i18n("M16886", "İşlem Tarihi");
        this.ManipulationActionDate.Name = "ManipulationActionDate";
        this.ManipulationActionDate.ReadOnly = true;
        this.ManipulationActionDate.Width = 120;

        this.ProcedureObject = new TTVisual.TTListBoxColumn();
        this.ProcedureObject.ListDefName = "ManiplationListDefinition";
        this.ProcedureObject.DisplayIndex = 1;
        this.ProcedureObject.HeaderText = "Tıbbi/Cerrahi Uygulama";
        this.ProcedureObject.Name = "ProcedureObject";
        this.ProcedureObject.ReadOnly = true;
        this.ProcedureObject.Width = 300;

        this.Emergency = new TTVisual.TTCheckBoxColumn();
        this.Emergency.DisplayIndex = 2;
        this.Emergency.HeaderText = "Acil";
        this.Emergency.Name = "Emergency";
        this.Emergency.ReadOnly = true;
        this.Emergency.Width = 35;

        this.Department = new TTVisual.TTListBoxColumn();
        this.Department.ListDefName = "ResourceListDefinition";
        this.Department.DisplayIndex = 3;
        this.Department.HeaderText = i18n("M23784", "Uygulanan Birim");
        this.Department.Name = "Department";
        this.Department.ReadOnly = true;
        this.Department.Width = 150;

        this.ManipulationDoctor = new TTVisual.TTListBoxColumn();
        this.ManipulationDoctor.ListDefName = "DoctorListDefinition";
        this.ManipulationDoctor.DisplayIndex = 4;
        this.ManipulationDoctor.HeaderText = i18n("M16938", "İşlemi Yapması Öngörülen Tabip");
        this.ManipulationDoctor.Name = "ManipulationDoctor";
        this.ManipulationDoctor.ReadOnly = true;
        this.ManipulationDoctor.Width = 180;

        this.Description = new TTVisual.TTTextBoxColumn();
        this.Description.DisplayIndex = 5;
        this.Description.HeaderText = i18n("M10469", "Açıklama");
        this.Description.Name = "Description";
        this.Description.ReadOnly = true;
        this.Description.Width = 100;

        this.tttabpage17 = new TTVisual.TTTabPage();
        this.tttabpage17.DisplayIndex = 3;
        this.tttabpage17.TabIndex = 11;
        this.tttabpage17.Text = i18n("M19152", "Mua.Bulguları");
        this.tttabpage17.Name = "tttabpage17";

        this.OldPhysicialExaminationsGrid = new TTVisual.TTGrid();
        this.OldPhysicialExaminationsGrid.Name = "OldPhysicialExaminationsGrid";
        this.OldPhysicialExaminationsGrid.TabIndex = 0;

        this.ExaminationDateTime = new TTVisual.TTDateTimePickerColumn();
        this.ExaminationDateTime.DisplayIndex = 0;
        this.ExaminationDateTime.HeaderText = i18n("M19222", "Muayene Tarihi");
        this.ExaminationDateTime.Name = "ExaminationDateTime";
        this.ExaminationDateTime.ReadOnly = true;
        this.ExaminationDateTime.Width = 125;

        this.ExaminationIndication = new TTVisual.TTRichTextBoxControlColumn();
        this.ExaminationIndication.DisplayIndex = 1;
        this.ExaminationIndication.HeaderText = i18n("M19174", "Muayene Bulgusu");
        this.ExaminationIndication.Name = "ExaminationIndication";
        this.ExaminationIndication.ReadOnly = true;
        this.ExaminationIndication.Width = 360;

        this.tttabpage18 = new TTVisual.TTTabPage();
        this.tttabpage18.DisplayIndex = 4;
        this.tttabpage18.TabIndex = 12;
        this.tttabpage18.Text = i18n("M19153", "Mua.Özeti");
        this.tttabpage18.Name = "tttabpage18";

        //Prescription Grid
        this.PrescriptionGrid = new TTVisual.TTGrid();
        this.PrescriptionGrid.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.PrescriptionGrid.Text = i18n("M20924", "Reçete");
        this.PrescriptionGrid.Name = 'PrescriptionGrid';
        this.PrescriptionGrid.AllowUserToAddRows = false;
        this.PrescriptionGrid.AllowUserToDeleteRows = false;
        this.PrescriptionGrid.TabIndex = 6;
        this.PrescriptionGrid.ReadOnly = true;
        this.PrescriptionGrid.Enabled = false;

        this.PhysicianDrug = new TTVisual.TTListBoxColumn();
        this.PhysicianDrug.AllowMultiSelect = false;
        this.PhysicianDrug.ListDefName = 'DrugList';
        this.PhysicianDrug.DataMember = 'Material';
        this.PhysicianDrug.DisplayIndex = 2;
        this.PhysicianDrug.HeaderText = i18n("M16287", "İlaç");
        this.PhysicianDrug.Name = 'PhysicianDrug';
        this.PhysicianDrug.Width = '50%';
        this.PhysicianDrug.Enabled = false;
        this.PhysicianDrug.ReadOnly = true;

        this.Frequency = new TTVisual.TTEnumComboBoxColumn();
        this.Frequency.DataTypeName = 'FrequencyEnum';
        this.Frequency.DataMember = 'Frequency';
        this.Frequency.Required = true;
        this.Frequency.DisplayIndex = 5;
        this.Frequency.HeaderText = i18n("M13285", "Doz Aralığı");
        this.Frequency.Name = 'Frequency';
        this.Frequency.Width = '10%';

        this.DoseAmount = new TTVisual.TTTextBoxColumn();
        this.DoseAmount.DataMember = 'DoseAmount';
        this.DoseAmount.DisplayIndex = 7;
        this.DoseAmount.HeaderText = i18n("M13294", "Doz Miktarı");
        this.DoseAmount.Name = 'DoseAmount';
        this.DoseAmount.Width = '10%';

        this.Day = new TTVisual.TTTextBoxColumn();
        this.Day.DataMember = 'Day';
        this.Day.DisplayIndex = 7;
        this.Day.HeaderText = i18n("M17001", "K. Peryodu (Gün)");
        this.Day.Name = 'Day';
        this.Day.Width = '10%';

        this.UsageNote = new TTVisual.TTTextBoxColumn();
        this.UsageNote.DataMember = 'UsageNote';
        this.UsageNote.DisplayIndex = 7;
        this.UsageNote.HeaderText = i18n("M17992", "Kullanma Tarifi");
        this.UsageNote.Name = 'UsageNote';
        this.UsageNote.Width = '20%';

        this.cmbReportType = new TTVisual.TTEnumComboBox();
        this.cmbReportType.DataTypeName = 'ReportTypeEnum';
        this.cmbReportType.Name = 'cmbReportType';
        this.cmbReportType.TabIndex = 3;

        this.txtReportName = new TTVisual.TTTextBoxColumn();
        this.txtReportName.DataMember = "ReportName";
        this.txtReportName.Name = "ReportName";
        this.txtReportName.ToolTipText = "ReportName";
        this.txtReportName.Width = "50%";
        this.txtReportName.DisplayIndex = 1;
        this.txtReportName.HeaderText = "Rapor";

        this.txtStartDate = new TTVisual.TTTextBoxColumn();
        this.txtStartDate.DataMember = "StartDate";
        this.txtStartDate.Name = "StartDate";
        this.txtStartDate.ToolTipText = "StartDate";
        this.txtStartDate.Width = "20%";
        this.txtStartDate.DisplayIndex = 0;
        this.txtStartDate.HeaderText = i18n("M11637", "Başlangıç Tarihi");

        this.txtReportRequestReason = new TTVisual.TTTextBoxColumn();
        this.txtReportRequestReason.DataMember = "RequestReason";
        this.txtReportRequestReason.Name = "RequestReason";
        this.txtReportRequestReason.ToolTipText = "RequestReason";
        this.txtReportRequestReason.Width = "20%";
        this.txtReportRequestReason.DisplayIndex = 1;
        this.txtReportRequestReason.HeaderText = "İstek Nedeni";

        this.txtReportAdmissionDate = new TTVisual.TTTextBoxColumn();
        this.txtReportAdmissionDate.DataMember = "AdmissionDate";
        this.txtReportAdmissionDate.Name = "AdmissionDate";
        this.txtReportAdmissionDate.ToolTipText = "AdmissionDate";
        this.txtReportAdmissionDate.Width = "10%";
        this.txtReportAdmissionDate.DisplayIndex = 1;
        this.txtReportAdmissionDate.HeaderText = "Kabul Tarihi";

        this.txtReportMasterResource = new TTVisual.TTTextBoxColumn();
        this.txtReportMasterResource.DataMember = "MasterResource";
        this.txtReportMasterResource.Name = "MasterResource";
        this.txtReportMasterResource.ToolTipText = "MasterResource";
        this.txtReportMasterResource.Width = "20%";
        this.txtReportMasterResource.DisplayIndex = 1;
        this.txtReportMasterResource.HeaderText = "Birim";


        this.txtEndDate = new TTVisual.TTTextBoxColumn();
        this.txtEndDate.DataMember = "EndDate";
        this.txtEndDate.Name = "EndDate";
        this.txtEndDate.ToolTipText = "EndDate";
        this.txtEndDate.Width = "20%";
        this.txtEndDate.DisplayIndex = 0;
        this.txtEndDate.HeaderText = i18n("M11939", "Bitiş Tarihi");

        this.btnEdit = new TTVisual.TTButtonColumn();
        this.btnEdit.Name = "btnEdit";
        this.btnEdit.Width = "10%";
        this.btnEdit.DisplayIndex = 0;
        this.btnEdit.HeaderText = i18n("M13405", "Düzenle");

        this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergiesColumns = [this.DietMaterialMedicalInfoFoodAllergies];
        this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergiesColumns = [this.ActiveIngredientMedicalInfoDrugAllergies];
        this.GridDiagnosisColumns = [this.SecDiagnose, this.SecFreeDiagnosis, this.SecIsMainDiagnose, this.SecResponsibleUser, this.SecDiagnoseDate];
        this.GridAdditionalApplicationsColumns = [this.SDateTime, this.AProcedureObject, this.AdditionalProcedureDoctor, this.Result, this.NurseNotes, this.AdditionalMasterResource];
        //this.GridTreatmentMaterialsColumns = [this.TreatmentMaterialActionDate, this.Material, this.Barcode, this.DistributionType, this.Amount, this.OzelDurum, this.Notes, this.CokluOzelDurum, this.KodsuzMalzemeFiyatı, this.MalzemeTuru, this.Kdv, this.MalzemeBrans, this.SatinAlisTarihi];
        this.ConsultationGridColumns = [this.ConsultationDate, this.RequesterHospital, this.RequesterDepartment, this.RequestedHospital, this.RequestedDepartment, this.RequestReason, this.ConsultationResultAndOffer];
        this.GrdConsultationColumns = [this.RequestedResource, this.ttlistboxcolumn8, this.RequestDescription, this.chkColumnEmergency, this.chkInPatientBed];
        this.GridNursingOrdersColumns = [this.RPT, this.OrderActionDate, this.OrderProcedureObject, this.PeriodStartTime, this.ExecutionDate, this.NursingApplicationResult, this.NursingApplicationNurseNote, this.CreateOrderDetailBeforeSave];
        this.HealthCommiteeActionsColumns = [this.Hospital, this.HealthCommiteeActionID, this.HealthCommiteeActionDate, this.HCObjectID];
        this.GridEpisodeDiagnosisColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeFreeDiagnosis, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType];
        this.DiagnosisHistoryColumns = [this.DiagnoseDate, this.Diagnose, this.ResponsibleUser, this.DiagnosisType, this.IsMainDiagnose];
        this.ManipulationGridColumns = [this.ManipulationActionDate, this.ProcedureObject, this.Emergency, this.Department, this.ManipulationDoctor, this.Description];
        this.OldPhysicialExaminationsGridColumns = [this.ExaminationDateTime, this.ExaminationIndication];
        this.tabMedicalInformation.Controls = [this.tttabpageMedicalInformation];
        this.tttabpageMedicalInformation.Controls = [this.labelChronicDiseases, this.labelHemodialysis, this.labelImplant, this.labelOncologicFollowUp, this.labelOtherInformation, this.Pregnancy, this.ChronicDiseases, this.labelTransplantation, this.ttgroupboxHabits, this.ttgroupboxDisability, this.ttgroupboxAllergies, this.Hemodialysis, this.Transplantation, this.Implant, this.OtherInformation, this.OncologicFollowUp];
        this.ttgroupboxHabits.Controls = [this.CigaretteMedicalInfoHabits, this.CigaretteUsageFrequencyMedicalInfoHabits, this.labelDescriptionMedicalInfoHabits, this.OtherMedicalInfoHabits, this.DescriptionMedicalInfoHabits, this.TeaMedicalInfoHabits, this.labelAlcoholUsageFrequencyMedicalInfoHabits, this.AlcoholMedicalInfoHabits, this.AlcoholUsageFrequencyMedicalInfoHabits, this.labelCigaretteUsageFrequencyMedicalInfoHabits, this.CoffeeMedicalInfoHabits];
        this.ttgroupboxDisability.Controls = [this.ChronicMedicalInfoDisabledGroup, this.NonexistenceMedicalInfoDisabledGroup, this.HearingMedicalInfoDisabledGroup, this.MentalMedicalInfoDisabledGroup, this.OrthopedicMedicalInfoDisabledGroup, this.PsychicAndEmotionalMedicalInfoDisabledGroup, this.SpeechAndLanguageMedicalInfoDisabledGroup, this.VisionMedicalInfoDisabledGroup, this.UnclassifiedMedicalInfoDisabledGroup];
        this.ttgroupboxAllergies.Controls = [this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies, this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies, this.OtherAllergiesMedicalInfoAllergies, this.labelOtherAllergiesMedicalInfoAllergies];
        this.ttpanelPoliclinic.Controls = [this.rtfRequestDescription, this.InPatientBed, this.lblProcessEndDate, this.ProceduerDoctor, this.lblProcessDate, this.GridDiagnosis, this.RequesterDepatment, this.dtpProcessEndDate, this.ttlabel8, this.ttpictureboxcontrol1, this.chkEmergency, this.ProcessDate, this.labelProcedureDoctor, this.lblPatientAdmissionGeneralInfo, this.RequestedDoctor, this.labelRequesterDepatment, this.MasterResource, this.ProcedureSpeciality, this.ProtocolNo, this.ttlabel7, this.ttlabel9, this.ttlabel10];
        this.tttabcontrolPoliclinic.Controls = [this.tttabpageKonsultasyon, this.tttabpageIstemPaneli, this.tttabpageEOrder, this.tttabpageSagRapor, this.tttabpageHastaGeçmişi];
        this.tttabpageKonsultasyon.Controls = [this.rtfHistory, this.tttabcontrol2, this.pnlRightBottom, this.rtfPhysicalExamination, this.rtfComplaint];
        this.tttabcontrol2.Controls = [this.EkUygulamalarTab, this.MlzSarfTab, this.tttabpage4, this.tttabpage5];
        this.EkUygulamalarTab.Controls = [this.GridAdditionalApplications];
        //this.MlzSarfTab.Controls = [this.GridTreatmentMaterials];
        this.tttabpage4.Controls = [this.ConsultationGrid, this.btnConsultationRequest, this.chkConsultationInPatientBed, this.chkConsultationEmergency, this.lblConsultationRequestedUser, this.ConsultationRequestedUser, this.lblConsultationRequestedResource, this.ConsultationRequestedResource, this.GrdConsultation];
        this.pnlRightBottom.Controls = [this.rtfConsultationResultAndOffers, this.IsTreatmentMaterialEmpty];
        this.tttabpageEOrder.Controls = [this.GridNursingOrders];
        this.tttabpageSagRapor.Controls = [this.btnReports];
        this.tttabpageHastaGeçmişi.Controls = [this.tttabcontrol3];
        this.tttabcontrol3.Controls = [this.HealthCommiteeActionsTab, this.tttabpage15, this.tttabpage16, this.tttabpage17, this.tttabpage18];
        this.HealthCommiteeActionsTab.Controls = [this.HealthCommiteeActions];
        this.tttabpage15.Controls = [this.GridEpisodeDiagnosis, this.DiagnosisHistory, this.lblOldDiagnosis, this.lblEpisodeDiagnosis];
        this.tttabpage16.Controls = [this.ManipulationGrid];
        this.tttabpage17.Controls = [this.OldPhysicialExaminationsGrid];
        this.PrescriptionGridColumns = [this.PhysicianDrug, this.Frequency, this.DoseAmount, this.Day, this.UsageNote];
        this.Controls = [this.tabMedicalInformation, this.tttabpageMedicalInformation, this.labelChronicDiseases, this.labelHemodialysis, this.labelImplant, this.labelOncologicFollowUp, this.labelOtherInformation, this.Pregnancy, this.ChronicDiseases, this.labelTransplantation, this.ttgroupboxHabits, this.CigaretteMedicalInfoHabits, this.CigaretteUsageFrequencyMedicalInfoHabits, this.labelDescriptionMedicalInfoHabits, this.OtherMedicalInfoHabits, this.DescriptionMedicalInfoHabits, this.TeaMedicalInfoHabits, this.labelAlcoholUsageFrequencyMedicalInfoHabits, this.AlcoholMedicalInfoHabits, this.AlcoholUsageFrequencyMedicalInfoHabits, this.labelCigaretteUsageFrequencyMedicalInfoHabits, this.CoffeeMedicalInfoHabits, this.ttgroupboxDisability, this.ChronicMedicalInfoDisabledGroup, this.NonexistenceMedicalInfoDisabledGroup, this.HearingMedicalInfoDisabledGroup, this.MentalMedicalInfoDisabledGroup, this.OrthopedicMedicalInfoDisabledGroup, this.PsychicAndEmotionalMedicalInfoDisabledGroup, this.SpeechAndLanguageMedicalInfoDisabledGroup, this.VisionMedicalInfoDisabledGroup, this.UnclassifiedMedicalInfoDisabledGroup, this.ttgroupboxAllergies, this.MedicalInfoFoodAllergiesMedicalInfoFoodAllergies, this.DietMaterialMedicalInfoFoodAllergies, this.MedicalInfoDrugAllergiesMedicalInfoDrugAllergies, this.ActiveIngredientMedicalInfoDrugAllergies, this.OtherAllergiesMedicalInfoAllergies, this.labelOtherAllergiesMedicalInfoAllergies, this.Hemodialysis, this.Transplantation, this.Implant, this.OtherInformation, this.OncologicFollowUp, this.ttpanelPoliclinic, this.rtfRequestDescription, this.InPatientBed, this.lblProcessEndDate, this.ProceduerDoctor, this.lblProcessDate, this.GridDiagnosis, this.SecDiagnose, this.SecFreeDiagnosis, this.SecIsMainDiagnose, this.SecResponsibleUser, this.SecDiagnoseDate, this.RequesterDepatment, this.dtpProcessEndDate, this.ttlabel8, this.ttpictureboxcontrol1, this.chkEmergency, this.ProcessDate, this.labelProcedureDoctor, this.lblPatientAdmissionGeneralInfo, this.RequestedDoctor, this.labelRequesterDepatment, this.MasterResource, this.ProcedureSpeciality, this.ProtocolNo, this.ttlabel7, this.ttlabel9, this.ttlabel10, this.tttabcontrolPoliclinic, this.tttabpageKonsultasyon, this.rtfHistory, this.tttabcontrol2, this.EkUygulamalarTab, this.GridAdditionalApplications, this.SDateTime, this.AProcedureObject, this.AdditionalProcedureDoctor, this.Result, this.NurseNotes, this.AdditionalMasterResource, this.MlzSarfTab, this.tttabpage4, this.ConsultationGrid, this.ConsultationDate, this.RequesterHospital, this.RequesterDepartment, this.RequestedHospital, this.RequestedDepartment, this.RequestReason, this.ConsultationResultAndOffer, this.btnConsultationRequest, this.chkConsultationInPatientBed, this.chkConsultationEmergency, this.lblConsultationRequestedUser, this.ConsultationRequestedUser, this.lblConsultationRequestedResource, this.ConsultationRequestedResource, this.GrdConsultation, this.RequestedResource, this.ttlistboxcolumn8, this.RequestDescription, this.chkColumnEmergency, this.chkInPatientBed, this.tttabpage5, this.pnlRightBottom, this.rtfConsultationResultAndOffers, this.IsTreatmentMaterialEmpty, this.rtfPhysicalExamination, this.rtfComplaint, this.tttabpageIstemPaneli, this.tttabpageEOrder, this.GridNursingOrders, this.RPT, this.OrderActionDate, this.OrderProcedureObject, this.PeriodStartTime, this.ExecutionDate, this.NursingApplicationResult, this.NursingApplicationNurseNote, this.CreateOrderDetailBeforeSave, this.tttabpageSagRapor, this.btnReports, this.tttabpageHastaGeçmişi, this.tttabcontrol3, this.HealthCommiteeActionsTab, this.HealthCommiteeActions, this.Hospital, this.HealthCommiteeActionID, this.HealthCommiteeActionDate, this.HCObjectID, this.tttabpage15, this.GridEpisodeDiagnosis, this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeFreeDiagnosis, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.DiagnosisHistory, this.DiagnoseDate, this.Diagnose, this.ResponsibleUser, this.DiagnosisType, this.IsMainDiagnose, this.lblOldDiagnosis, this.lblEpisodeDiagnosis, this.tttabpage16, this.ManipulationGrid, this.ManipulationActionDate, this.ProcedureObject, this.Emergency, this.Department, this.ManipulationDoctor, this.Description, this.tttabpage17, this.OldPhysicialExaminationsGrid, this.ExaminationDateTime, this.ExaminationIndication, this.tttabpage18];
        this.GridPatientReportsColumns = [this.txtReportName, this.txtReportRequestReason, this.txtReportAdmissionDate, this.txtReportMasterResource, this.txtStartDate, this.txtEndDate, this.btnEdit];
    }

    async PrescriptionGrid_CellContentClicked(data: any) {

    }

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
        if (this._Consultation.RequestDate && this._Consultation.ProcessDate && this._Consultation.ProcessDate <= this._Consultation.RequestDate)
            throw new Exception("Konsültasyon başlangıç tarihi, konsültasyon istek tarihinden küçük veya istek tarihine eşit olamaz.");

        if (this._Consultation.ProcessEndDate && this._Consultation.ProcessDate && this._Consultation.ProcessEndDate <= this._Consultation.ProcessDate)
            throw new Exception(i18n("M17748", "Konsültasyon bitiş tarihi, başlangıç tarihinden küçük veya başlangıç tarihine eşit olamaz."));

        if (transDef !== null) {
            if (transDef.ToStateDefID.toString().Equals(Consultation.ConsultationStates.Completed.toString())) {
                if (this._Consultation.ConsultationResultAndOffers == null || this._Consultation.ConsultationResultAndOffers == "" || CommonHelper.getInnerText(this._Consultation.ConsultationResultAndOffers.toString()).length <= 0)
                    throw new Exception(i18n("M17784", "Konsültasyon Sonucunu Girmeden İşlemi Tamamlayamazsınız."));
                if (this._Consultation.ProcessEndDate == null || this._Consultation.ProcessEndDate.toString() == "")
                    this._Consultation.ProcessEndDate = await CommonService.RecTime();
                if (this._Consultation.ProcedureDoctor == null || this._Consultation.ProcedureDoctor.ObjectID == null)
                    throw new Exception(i18n("M17798", "Konsültasyonu Yapan Doktoru Seçmeden İşlemi Tamamlayamazsınız."));
            }

            if (transDef.ToStateDefID.valueOf() === Consultation.ConsultationStates.Cancelled.valueOf()) {
                let getDescription: string = await TTVisual.InputForm.GetText(i18n("M16531", "İptal açıklaması giriniz."), "", false, true);
                if (String.isNullOrEmpty(getDescription) === false)
                    this._Consultation.ReasonOfCancel = getDescription;
                else
                    throw new TTException(i18n("M16532", "İptal açıklaması girmelisiniz!"));
            }
        }

    }
    protected async ClientSidePreScript(): Promise<void> {
        await super.ClientSidePreScript();
        this.setSpesialityBasedObjectInfo();
        //let resourceStore: Store = await ResourceService.GetStore(this._Consultation.MasterResource.ObjectID.toString());
        //if (resourceStore === null) {
        //    throw new TTException(this._Consultation.MasterResource.Name + " bölümünün deposu bulunmadığı için malzeme sarf işlemi yapamazsınız.");
        //}
        //this.TreatmentMaterial.ListFilterExpression = "STOCKS.STORE = '" + resourceStore.ObjectID.toString() + "' AND STOCKS.INHELD > 0";
        //export class ConsultationStates {
        //        public static RequestAcception: Guid = new Guid('35722241-407f-4891-a5d0-ab738e5fb997');
        //        public static PatientNoShown: Guid = new Guid('6cd25fd8-c8bb-4124-8ee3-5216f5d95250');
        //        public static InsertedIntoQueue: Guid = new Guid('e58aa431-f813-4923-b501-3c7e80a0d087');
        //        public static Consultation: Guid = new Guid('73f3ec27-26d4-4f3a-bc5c-7324ba60a4e0');
        //        public static Completed: Guid = new Guid('942f0e19-c8d2-4b3f-8d2c-6501e11f2a78');
        //        public static Cancelled: Guid = new Guid('3ae0012a-f817-4df7-b89e-2d3be91b4f4b');
        //        public static Appointment: Guid = new Guid('52c80877-3f49-4e43-95b0-43a81e9bcb18');
        //    }

        switch (this.consultationDoctorExaminationFormNewViewModel._Consultation.CurrentStateDefID.toString()) {
            case '35722241-407f-4891-a5d0-ab738e5fb997': // RequestAcception
                this.DropStateButton(Consultation.ConsultationStates.InsertedIntoQueue);
                this.DropStateButton(Consultation.ConsultationStates.Consultation);
                break;
        }
        await this.setConsultationDoctorListFilter(this._Consultation.MasterResource);

        let drugOrderIntDets: OldDrugOrderIntroductionDet = await DrugOrderIntroductionService.GetOldDrugOrderIntroductionDets(this._Consultation.Episode);
        if (drugOrderIntDets != null && drugOrderIntDets.DrugOrderIntroductionDets != null) {
            this.PrescriptionList = new Array<DrugOrderIntroductionDet>();
            for (let drugOrder of drugOrderIntDets.DrugOrderIntroductionDets) {
                let materialObjectID = drugOrder.Material;
                if (materialObjectID != null) {
                    let material = drugOrderIntDets.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                    drugOrder.Material = material;
                }

                this.PrescriptionList.push(drugOrder);
            }
        }
        if (this._Consultation.CurrentStateDefID != Consultation.ConsultationStates.Completed && this._Consultation.CurrentStateDefID != Consultation.ConsultationStates.Cancelled)
            this.SetProcedureDoctorAsCurrentResource();
    }

    async setConsultationDoctorListFilter(data: any) {
        if (!data)
            this.ProceduerDoctor.ListFilterExpression = "1=1";
        else {
            this.ProceduerDoctor.ListFilterExpression = "USERRESOURCES.RESOURCE ='" + data.ObjectID.toString() + "'";
            //let consultationReqResList: Array<ResSection.ConsultationRequestResourceListNql_Class> = await ResSectionService.ConsultationRequestResourceListNql(this.ConsultationRequestedUser.ListFilterExpression);
        }
    }
    /*treatmentMaterialSelected(data: any) {
        this._ViewModel._selectedMaterialValue = data;
        if (data != null) {
            let that = this;
            let body = JSON.stringify(data.ObjectId);
            let apiUrlForAddTreatmentMaterial: string = 'api/PatientExaminationService/GetTreatmentMaterialInfo?materialObjectId=' + data.ObjectID;
            this.http.get(apiUrlForAddTreatmentMaterial)
                .toPromise()
                .then(response => {
                    let result = response.json();
                    let cTreatmentMaterial: ConsultationTreatmentMaterial = new ConsultationTreatmentMaterial();
                    cTreatmentMaterial.Material = result.Result.Material;
                    cTreatmentMaterial.Material.Barcode = result.Result.Barcode;
                    cTreatmentMaterial.Material.StockCard = result.Result.StockCard;
                    cTreatmentMaterial.Material.StockCard.DistributionType = result.Result.DistributionTypeDef;
                    cTreatmentMaterial.Material.StockCard.DistributionType.DistributionType = result.Result.DistributionType;
                    cTreatmentMaterial.Amount = result.Result.Amount;
                    cTreatmentMaterial.Episode = this._Consultation.Episode;
                    cTreatmentMaterial.Eligible = true;
                    cTreatmentMaterial.ActionDate = result.Result.ActionDate;
                    cTreatmentMaterial.Active = true;
                    that._Consultation.ConsultationTreatmentMaterials.push(cTreatmentMaterial);
                })
                .catch(error => {
                    console.log(error);
                });
        }
    }*/


    public async onSelectedReportOpen(data: any) {
        this.ReportParamActiveIDsModel = new ActiveIDsModel(this._Consultation.ObjectID,this._Consultation.Episode.ObjectID,this._Consultation.Episode.Patient.ObjectID);

        if (data.code === ReportTypeEnum.DrugReport) {
            if (!(await EpisodeActionService.CheckInvoicedCompletely(this._Consultation.ObjectID)))
                this.onParticipatientReportOpen(null);
            else
                ServiceLocator.MessageService.showError("Faturası Kesilmiş Hastalara İlaç Raporu Yazamazsınız");
        }
        else if (data.code === ReportTypeEnum.TreatmentReport) {
            //if (await EpisodeActionService.CheckProvision()) {
            this.onMedulaTreatmentReportOpen(null);
            /*} else {
                TTVisual.InfoBox.Alert("Hastanın Takip Numarası Yoktur. Medula Tedavi Raporu Yazılamaz");
            }*/
        }
        else if (data.code === ReportTypeEnum.OtherReport) {
            this.onStatusNotificationReportOpen(null);
        } else if (data.code === ReportTypeEnum.MedicalStuffReport) {
            this.onMedicalStuffReportOpen(null);
        }
    }

    async onMedulaTreatmentReportOpen(episodeAction: any) {
        if (this.consultationDoctorExaminationFormNewViewModel.IsAuthorizedToWriteTreatmentReport == false) {
            this.messageService.showInfo(i18n("M23021", "Tedavi raporu yazmaya yetkili bir uzmanlık dalına sahip değilsiniz, Rapor yazamazsınız!"));
            return;
        }

        let temp;
        if (episodeAction == null) {
            this.showMedulaTreatmentReport(null);
        }
        else {
            this.objectContextService.getObject<MedulaTreatmentReport>(episodeAction, MedulaTreatmentReport.ObjectDefID, MedulaTreatmentReport).then(result => {
                let temp: MedulaTreatmentReport = result;
                temp = result;
                this.showMedulaTreatmentReport(temp);
            });
        }
    }

    private showMedulaTreatmentReport(data: MedulaTreatmentReport) {
        this.showMedulaTedaviRaporlariForm = true;

        this.medulaTedaviRaporlariObject = data as MedulaTreatmentReport;
    }

    async OnStatusNotificationReportFormClosing(e) {
        //this.showStatusNotificationReportForm = false;

        //refreshReportTab
        this.reloadReportList();
        /*let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.consultationDoctorExaminationFormNewViewModel._Consultation.Episode.Patient.ObjectID + '&subepisodeObjectID=' + this.consultationDoctorExaminationFormNewViewModel._Consultation.SubEpisode + '&includedCancelledReports=false&currentActionReports=true';
        let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);
        this.consultationDoctorExaminationFormNewViewModel.PatientReportInfoList = res;*/
    }

    async OnMedulaTedaviRaporlariFormClosing(e) {
        if (e == true)
            this.showMedulaTedaviRaporlariForm = false;

        //refreshReportTab
        this.reloadReportList();
        /*let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.consultationDoctorExaminationFormNewViewModel._Consultation.Episode.Patient.ObjectID + '&subepisodeObjectID=' + this.consultationDoctorExaminationFormNewViewModel._Consultation.SubEpisode + '&includedCancelledReports=false&currentActionReports=true';
        let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);
        this.consultationDoctorExaminationFormNewViewModel.PatientReportInfoList = res;*/
    }

    async OnParticipationFreeDrugReportNewFormClosing(e) {
        if (e == true)
            this.showParticipationFreeDrugReportNewForm = false;

        //refreshReportTab
        this.reloadReportList();
        /*let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.consultationDoctorExaminationFormNewViewModel._Consultation.Episode.Patient.ObjectID + '&subepisodeObjectID=' + this.consultationDoctorExaminationFormNewViewModel._Consultation.SubEpisode + '&includedCancelledReports=false&currentActionReports=true';
        let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);
        this.consultationDoctorExaminationFormNewViewModel.PatientReportInfoList = res;*/
    }

    async reloadReportList() {
        let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.consultationDoctorExaminationFormNewViewModel._Consultation.Episode.Patient.ObjectID + '&subepisodeObjectID=' + this.consultationDoctorExaminationFormNewViewModel._Consultation.SubEpisode + '&includedCancelledReports=false&currentActionReports=true';
        let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);
        this.consultationDoctorExaminationFormNewViewModel.PatientReportInfoList = res;
    }

    async onParticipationFreeDrugReportNewForm(event: any) {
        this.showParticipationFreeDrugReportNewForm = false;
        //refreshReportTab
        let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.consultationDoctorExaminationFormNewViewModel._Consultation.Episode.Patient + '&subepisodeObjectID=' + this.consultationDoctorExaminationFormNewViewModel._Consultation.SubEpisode.ObjectID + '&includedCancelledReports=false&currentActionReports=' + this.currentActionReports;
        let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);
        this.consultationDoctorExaminationFormNewViewModel.PatientReportInfoList = res;
    }

    onStatusNotificationReportOpen(episodeAction: any) {
        let temp;
        if (episodeAction == null) {
            this.showStatusNotificationReport(null);
        }
        else {
            this.objectContextService.getObject<StatusNotificationReport>(episodeAction, StatusNotificationReport.ObjectDefID, StatusNotificationReport).then(result => {
                let temp: StatusNotificationReport = result;
                temp = result;
                this.showStatusNotificationReport(temp);
            });
        }
    }
    private showStatusNotificationReport(data: StatusNotificationReport) {
        this.showStatusNotificationReportForm = true;

        this.statusNotificationReportObject = data as StatusNotificationReport;


    }

    onParticipatientReportOpen(episodeAction: any) {
        let temp;

        if (episodeAction == null) {
            this.showParticipatnFreeDrugReport(null);
        }
        else {
            this.objectContextService.getObject<ParticipatnFreeDrugReport>(episodeAction, ParticipatnFreeDrugReport.ObjectDefID, ParticipatnFreeDrugReport).then(result => {
                let temp: ParticipatnFreeDrugReport = result;
                temp = result;
                this.showParticipatnFreeDrugReport(temp);
            });
        }
    }
    private showParticipatnFreeDrugReport(data: ParticipatnFreeDrugReport) {
        this.showParticipationFreeDrugReportNewForm = true;

        this.ParticipationFreeDrugReportNewFormObject = data as ParticipatnFreeDrugReport;
    }

    onMedicalStuffReportOpen(episodeAction: any) {
        if (episodeAction == null) {
            this.objectContextService.getNewObject<MedicalStuffReport>(MedicalStuffReport.ObjectDefID, MedicalStuffReport).then(result => {
                let medicalStuffReport: MedicalStuffReport = result;

                // tslint:disable-next-line:no-shadowed-variable
                this.showMedicalStuffReport(medicalStuffReport).then(result => {
                    let modalActionResult = result as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        let obj = result.Param as MedicalStuffReport;
                    }
                });
            }).catch(err => {
                this.messageService.showError(err);
            });
        }
        else {
            this.objectContextService.getObject<MedicalStuffReport>(episodeAction, MedicalStuffReport.ObjectDefID, MedicalStuffReport).then(result => {
                let medicalStuffReport: MedicalStuffReport = result;

                // tslint:disable-next-line:no-shadowed-variable
                this.showMedicalStuffReport(medicalStuffReport).then(result => {
                    let modalActionResult = result as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        let obj = result.Param as MedicalStuffReport;
                    }
                });
            }).catch(err => {
                this.messageService.showError(err);
            });
        }


    }

    private showMedicalStuffReport(data: MedicalStuffReport): Promise<ModalActionResult> {
        let that = this;
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'MedicalStuffReportForm';
            componentInfo.ModuleName = 'TibbiMalzemeModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Tibbi_Malzeme_Modulu/TibbiMalzemeModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, new ActiveIDsModel(this._Consultation.ObjectID,this._Consultation.Episode.ObjectID,this._Consultation.Episode.Patient.ObjectID));
            componentInfo.ParentInstance = this;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M23409", "Tıbbi Malzeme Raporu");
            /*modalInfo.Width = 1300;
            modalInfo.Height = 900;*/
            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
                let add: boolean = true;
                let report: MedicalStuffReport = inner.Param as MedicalStuffReport;
                //for (let item of this.patientExaminationDoctorFormNewViewModel.PatientReportInfoList) {
                //    if (item.ObjectID == report.ObjectID) {
                //        item.EndDate = (report.EndDate != null || report.EndDate != undefined) ? this.toShortDateStringWithDot(report.EndDate) : null;
                //        item.StartDate = this.toShortDateStringWithDot(report.StartDate);
                //        add = false;
                //    }
                //    else if (report.ObjectID == null)
                //        add = false;
                //}
                //if (add) {
                //    let patientReportInfo: PatientReportInfo = new PatientReportInfo();
                //    patientReportInfo.ObjectID = report.ObjectID;
                //    patientReportInfo.ObjectDefName = "MEDICALSTUFFREPORT";
                //    patientReportInfo.ID = (report.ID != null || report.ID != undefined) ? report.ID.toString() : null;
                //    patientReportInfo.StartDate = this.toShortDateStringWithDot(report.StartDate);
                //    patientReportInfo.EndDate = (report.EndDate != null || report.EndDate != undefined) ? this.toShortDateStringWithDot(report.EndDate) : null;
                //    patientReportInfo.ReportName = "Tıbbi Malzeme Raporu";
                //    that.patientExaminationDoctorFormNewViewModel.PatientReportInfoList.push(patientReportInfo);
                //}
            }).catch(err => {
                reject(err);
            });
        });
    }

    async GridPatientReports_CellContentClicked(data: any) {
        let that = this;
        this.ReportParamActiveIDsModel = new ActiveIDsModel(this._Consultation.ObjectID,this._Consultation.Episode.ObjectID,this._Consultation.Episode.Patient.ObjectID);

        if (this.ReadOnly != true) {
            if (data.Column.Name == "btnEdit") {
                if (data.Row != null) {
                    if (data.Row.TTObject != null) {
                        let patientReportGrid = data.Row.TTObject;
                        if (patientReportGrid.ObjectID != null && patientReportGrid.ObjectDefName != null) {
                            if (patientReportGrid.ObjectDefName == "PARTICIPATNFREEDRUGREPORT")
                                this.onParticipatientReportOpen(patientReportGrid.ObjectID);
                            if (patientReportGrid.ObjectDefName == "STATUSNOTIFICATIONREPORT")
                                this.onStatusNotificationReportOpen(patientReportGrid.ObjectID);
                            if (patientReportGrid.ObjectDefName == "MEDULATREATMENTREPORT")
                                this.onMedulaTreatmentReportOpen(patientReportGrid.ObjectID);
                            if (patientReportGrid.ObjectDefName == "MEDICALSTUFFREPORT")
                                this.onMedicalStuffReportOpen(patientReportGrid.ObjectID);
                        }
                    }
                }
            }

        }
    }

    public setENabizViewModel(viewModels: Array<any>) {

        for (let i = 0; i < viewModels.length; i++) {
            //this.consultationDoctorExaminationFormNewViewModel.ENabizViewModels.push(viewModels[i]);
        }

    }

    public getManipulationRequestParam() : ClickFunctionParams{

        let model : ClickFunctionParams = new ClickFunctionParams(this, new ActiveIDsModel(null,this._Consultation.Episode.ObjectID,null));
        return model;
    }

    public async openEDurumBildirirReport() {
        let parameterValue = await this.helpMenuService.getEDurumBildirirParameter();
        if (parameterValue)
            this.showEDurumBildirirComponent = true;
        else {
            this.helpMenuService.openEDurumBildirirReportPopUp(this.consultationDoctorExaminationFormNewViewModel._Consultation.ObjectID.toString());
        }
    } 

    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        let createEDurumBildirirReport = new DynamicSidebarMenuItem();
        createEDurumBildirirReport.key = 'createEDurumBildirirReport';
        createEDurumBildirirReport.icon = 'fa fa-plus';
        createEDurumBildirirReport.label = 'E-Durum Bildirir Raporu Yaz';
        createEDurumBildirirReport.componentInstance = this;
        createEDurumBildirirReport.clickFunction = this.openEDurumBildirirReport;
        createEDurumBildirirReport.parameterFunctionInstance = this;
        //printEpicrisisForm.getParamsFunction = this.getClickFunctionParams;
        createEDurumBildirirReport.ParentInstance = this;
        this.sideBarMenuService.addMenu('SaglikBakanligiRaporlari', createEDurumBildirirReport);
        let openEDurumBildirirReportIndex = new DynamicSidebarMenuItem();
        openEDurumBildirirReportIndex.key = 'openEDurumBildirirReportIndex';
        openEDurumBildirirReportIndex.icon = 'fa fa-list';
        openEDurumBildirirReportIndex.label = 'E-Durum Bildirir Raporu Index';
        openEDurumBildirirReportIndex.componentInstance = this;
        openEDurumBildirirReportIndex.clickFunction = this.helpMenuService.OpenEDurumBildirirIndex;
        openEDurumBildirirReportIndex.parameterFunctionInstance = this;
        //printEpicrisisForm.getParamsFunction = this.getClickFunctionParams;
        openEDurumBildirirReportIndex.ParentInstance = this;
        this.sideBarMenuService.addMenu('SaglikBakanligiRaporlari', openEDurumBildirirReportIndex);

        let colorPrescription = new DynamicSidebarMenuItem();
        colorPrescription.key = 'colorPrescription';
        colorPrescription.componentInstance = this;
        colorPrescription.label = 'Reçete';
        colorPrescription.icon = 'ai ai-recete';
        colorPrescription.clickFunction = this.colorPresClick;
        this.sideBarMenuService.addMenu('YardimciMenu', colorPrescription);

        let manipulation = new DynamicSidebarMenuItem();
        manipulation.key = 'manipulation';
        manipulation.icon = 'ai ai-tibbi-uygulama-istek';
        manipulation.label = 'Tıbbi/Uygulama İstek';
        manipulation.componentInstance = this.helpMenuService;
        manipulation.clickFunction = this.helpMenuService.openManipulationRequest;
        manipulation.parameterFunctionInstance = this;
        manipulation.getParamsFunction = this.getClickFunctionParams;
        manipulation.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', manipulation);

        let patientDocumentUpload = new DynamicSidebarMenuItem();
        patientDocumentUpload.key = 'patientDocumentUpload';
        patientDocumentUpload.icon = 'ai ai-hasta-dokuman-ekle';
        patientDocumentUpload.label = i18n("M15178", "Hasta Dokümanı Ekle");
        patientDocumentUpload.componentInstance = this.helpMenuService;
        patientDocumentUpload.clickFunction = this.helpMenuService.patientDocumentUpload;
        patientDocumentUpload.parameterFunctionInstance = this;
        patientDocumentUpload.getParamsFunction = this.getClickFunctionParams;
        patientDocumentUpload.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', patientDocumentUpload);

        let nabizMessage = new DynamicSidebarMenuItem();
        nabizMessage.key = 'nabizMessage';
        nabizMessage.icon = 'ai ai-enabiz-mesaj-gonder';
        nabizMessage.label = i18n("M13710", "E-Nabız Mesaj Gönder");
        nabizMessage.componentInstance = this.helpMenuService;
        nabizMessage.clickFunction = this.helpMenuService.onSendENabizMessageOpen;
        this.sideBarMenuService.addMenu('YardimciMenu', nabizMessage);

        let showENabizInfo = new DynamicSidebarMenuItem();
        showENabizInfo.key = 'showENabizInfo';
        showENabizInfo.icon = 'ai ai-enabiz-mesaj-gonder';
        showENabizInfo.label = i18n("M13709", "E-Nabız Hasta Sağlık Bilgileri Sorgula");
        showENabizInfo.componentInstance = this.helpMenuService;
        showENabizInfo.clickFunction = this.helpMenuService.showPatientENabizInfo;
        showENabizInfo.parameterFunctionInstance = this;
        showENabizInfo.getParamsFunction = this.getClickFunctionParams;
        showENabizInfo.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', showENabizInfo);

        let dailyInpatient = new DynamicSidebarMenuItem();
        dailyInpatient.key = 'dailyInpatient';
        dailyInpatient.icon = 'fas fa-bed';
        dailyInpatient.label = 'Günübirlik Yatış Başlat';
        dailyInpatient.componentInstance = this;
        dailyInpatient.clickFunction = this.onDailyOperationClick;
        dailyInpatient.parameterFunctionInstance = this;
        dailyInpatient.getParamsFunction = this.getClickFunctionParams;
        dailyInpatient.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', dailyInpatient); 

        let openInpatientAdmission = new DynamicSidebarMenuItem();
        openInpatientAdmission.key = 'openInpatientAdmission';
        openInpatientAdmission.icon = 'fas fa-bed';
        openInpatientAdmission.label = 'Yatış İsteği';
        openInpatientAdmission.componentInstance = this.helpMenuService;
        openInpatientAdmission.clickFunction = this.helpMenuService.onInpatientAdmissionRequestOpen;
        openInpatientAdmission.parameterFunctionInstance = this;
        openInpatientAdmission.getParamsFunction = this.getClickFunctionParams;
        openInpatientAdmission.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', openInpatientAdmission);
        
        let greenList = new DynamicSidebarMenuItem();
        greenList.key = 'greenList';
        greenList.icon = 'ai ai-addlist ';
        greenList.label = i18n("M24637", "Yeşil Listeye Ekle(90 Gün)");
        greenList.componentInstance = this.helpMenuService;
        greenList.clickFunction = this.helpMenuService.addMHRSGreenList;
        greenList.parameterFunctionInstance = this;
        greenList.getParamsFunction = this.getClickFunctionParams;
        greenList.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', greenList);

        let greenListSearch = new DynamicSidebarMenuItem();
        greenListSearch.key = 'greenListSearch';
        greenListSearch.icon = 'ai ai-checkist';
        greenListSearch.label = i18n("M24638", "Yeşil Listeye Ekle/Onayla(Kronik Hasta)");
        greenListSearch.componentInstance = this.helpMenuService;
        greenListSearch.clickFunction = this.helpMenuService.searchAddAproveMHRSGreenList;
        greenListSearch.parameterFunctionInstance = this;
        greenListSearch.getParamsFunction = this.getClickFunctionParams;
        greenListSearch.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', greenListSearch);

    }

    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('colorPrescription');
        this.sideBarMenuService.removeMenu('manipulation');
        this.sideBarMenuService.removeMenu('patientDocumentUpload');
        this.sideBarMenuService.removeMenu('nabizMessage');
        this.sideBarMenuService.removeMenu('showENabizInfo');
        this.sideBarMenuService.removeMenu('dailyInpatient');
        this.sideBarMenuService.removeMenu('openInpatientAdmission');
        this.sideBarMenuService.removeMenu('createEDurumBildirirReport');
        this.sideBarMenuService.removeMenu('openEDurumBildirirReportIndex');
        this.sideBarMenuService.removeMenu('greenList');
        this.sideBarMenuService.removeMenu('greenListSearch');
    }
    public ngOnDestroy(): void {
        if(this.refreshReportGridSubscription != null){
            this.refreshReportGridSubscription.unsubscribe();
            this.refreshReportGridSubscription = null;
        }
        this.RemoveMenuFromHelpMenu();
        this.OnDestroy.emit();
        //this.httpService.eNabizButtonSharedService.changeButtonVisible(false);
    }

    public async onShowCancelledReports(val: any): Promise<void> {
        if (val.value != null) {

            let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.consultationDoctorExaminationFormNewViewModel._Consultation.Episode.Patient.ObjectID + '&subepisodeObjectID=' + this.consultationDoctorExaminationFormNewViewModel._Consultation.SubEpisode + '&includedCancelledReports=' + val.value + '&currentActionReports=' + this.currentActionReports;
            let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);


            this.consultationDoctorExaminationFormNewViewModel.PatientReportInfoList = res;
        }
    }
    public async onShowAllReports(val: any): Promise<void> {
        if (val.value != null) {
            this.currentActionReports = !(val.value);
            let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.consultationDoctorExaminationFormNewViewModel._Consultation.Episode.Patient.ObjectID + '&subepisodeObjectID=' + this.consultationDoctorExaminationFormNewViewModel._Consultation.SubEpisode + '&includedCancelledReports=false&currentActionReports=' + this.currentActionReports;
            let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);


            this.consultationDoctorExaminationFormNewViewModel.PatientReportInfoList = res;
        }
    }

}
