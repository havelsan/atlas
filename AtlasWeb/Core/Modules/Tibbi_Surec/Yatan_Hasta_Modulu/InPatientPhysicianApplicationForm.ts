//$1D59E4F2
import { Component, ViewChild, OnInit, ApplicationRef, OnDestroy, NgZone, EventEmitter } from '@angular/core';
import { Http } from '@angular/http';
import { InPatientPhysicianApplicationFormViewModel, NursinOrderScheduleObj, SaveNursingOrderTemplateViewModel, MedulaResult, TakipDVO, OrderScheduleDetail, InPatientPhysicianProgressesInfoViewModel, NewNursingOrderDetail, EpisodeFolderModel, ArchiveRequestModel, ArchiveRequestInputModel } from './InPatientPhysicianApplicationFormViewModel';
import { PatientReportInfo } from "../Poliklinik_Modulu/PatientExaminationDoctorFormNewViewModel";
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseNewDoctorExaminationForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/BaseNewDoctorExaminationForm";
import { InPatientPhysicianApplication, MedicalStuffReport, NursingOrder, PatientAdmissionResourcesToBeReferred, ResClinic, BasvuruYatisBilgileriDVO, HastaYatisOkuCevapDVO, TreatmentDischarge, SKRSDurum, Morgue, TedaviTipi, YesNoEnum, EpisodeFolder, SafeSurgeryCheckList, BaseInpatientAdmission } from 'NebulaClient/Model/AtlasClientModel';
import { BaseTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { DietOrder } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { InPatientPhysicianProgresses, IntensiveCareTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { InPatientRtfBySpeciality } from 'NebulaClient/Model/AtlasClientModel';
import { InPatientTreatmentClinicApplication } from 'NebulaClient/Model/AtlasClientModel';
import { MealTypes } from 'NebulaClient/Model/AtlasClientModel';
import { NursingOrderDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DietOrderDetail } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SubEpisode } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { TTUser } from 'NebulaClient/StorageManager/Security/TTUser';
import DataSource from 'devextreme/data/data_source';
import { FrequencyEnum } from 'NebulaClient/Model/AtlasClientModel';
import { DxSchedulerComponent } from 'devextreme-angular';
import { Consultation } from 'NebulaClient/Model/AtlasClientModel';
import { InputForm } from 'NebulaClient/Visual/InputForm';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { DrugOrderIntroduction } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderIntroductionDet } from 'NebulaClient/Model/AtlasClientModel';
import { ModalInfo, ModalActionResult } from "Fw/Models/ModalInfo";
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";
import { TTObjectStateTransitionDef } from "app/NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef";
import { IActiveTabService } from 'Fw/Services/IActiveTabService';
import { ObjectContextService } from "Fw/Services/ObjectContextService";
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { IModalService } from "Fw/Services/IModalService";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { EntityStateEnum } from 'NebulaClient/Utils/Enums/EntityStateEnum';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { DischargeTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { DxDataGridComponent } from 'devextreme-angular';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { AtlasObjectCloner } from 'NebulaClient/ClassTransformer/AtlasObjectCloner';
import { ProcedureRequestForm } from "../Tetkik_Istem_Modulu/ProcedureRequestForm";
import { vmProcedureRequestFormDefinition, DailyProvisionInputModel } from '../Tetkik_Istem_Modulu/ProcedureRequestViewModel';
import { NursingOrderTemplateDetail } from 'NebulaClient/Model/AtlasClientModel';
import { NursingOrderTemplate } from 'NebulaClient/Model/AtlasClientModel';
import { Resource } from 'NebulaClient/Model/AtlasClientModel';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { PatientInterviewForm, ConsultationFromExternalHospital, DentalExamination } from 'NebulaClient/Model/AtlasClientModel';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { MostUsedProcedureRequestForm } from '../Tetkik_Istem_Modulu/MostUsedProcedureRequestForm';
import { ReportTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ParticipatnFreeDrugReport } from 'NebulaClient/Model/AtlasClientModel';
import { StatusNotificationReport } from 'NebulaClient/Model/AtlasClientModel';
import { MedulaTreatmentReport } from 'NebulaClient/Model/AtlasClientModel';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { QueryParams } from 'app/QueryList/Models/QueryParams';
import { DispatchToOtherHospitalComponentInfoViewModel } from 'Modules/Tibbi_Surec/XXXXXXler_Arasi_Sevk_Modulu/DispatchToOtherHospitalFormViewModel';
import { DispatchToOtherHospitalForm } from '../XXXXXXler_Arasi_Sevk_Modulu/DispatchToOtherHospitalForm';
import { NqlQueryService } from 'app/QueryList/Services/nql-query.service';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { DatePipe } from '@angular/common';
import { FormSaveInfo } from "NebulaClient/Mscorlib/FormSaveInfo";
import { Convert } from 'NebulaClient/Mscorlib/Convert';
import { OpenColorPrescription_Input } from 'ObjectClassService/DrugOrderIntroductionService';
import { StringParam } from 'app/NebulaClient/Mscorlib/StringParam';
import { EnumItem } from 'app/NebulaClient/Mscorlib/EnumItem';
import { IFavoriteService } from 'app/Favorites/IFavoriteService';
import { EpisodeActionService } from 'app/NebulaClient/Services/ObjectService/EpisodeActionService';
import { IDestroyEvent } from 'app/Interfaces/IDestroyEvent';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel, ClickFunctionParams } from 'app/Fw/Models/ParameterDefinitionModel';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';
import { ReportController } from '../Hemsirelik_Islemleri_Modulu/NursingApplicationMainFormViewModel';
import { DateParam } from 'app/NebulaClient/Mscorlib/DateParam';
import { DailyInpatientInfoModel, SurgeryChecklistModel } from '../Tibbi_Surec_Evrensel_Modulu/EpisodeActionFormViewModel';
import { RequestedProceduresForm } from '../Tetkik_Istem_Modulu/RequestedProceduresForm';
import List from 'app/NebulaClient/System/Collections/List';
import { TreatmentMaterialForm } from '../Sarf_Malzeme_Modulu/TreatmentMaterialForm';
import { TTException } from 'app/NebulaClient/Utils/Exceptions/TTException';
import { EmergencySpecialityObjectFormViewModel } from '../Acil_Modulu/EmergencySpecialityObjectFormViewModel';
import { MessageIconEnum } from 'app/NebulaClient/Utils/Enums/MessageIconEnum';
import { CharacterCasing } from 'app/NebulaClient/Utils/Enums/CharacterCasing';
import { PatientOnVacationForm } from './PatientOnVacationForm';
import { PatientVacationComponentInfoViewModel } from './PatientOnVacationFormViewModel';
import { Subscription } from 'rxjs';
import { DynamicFormParameters } from 'app/DynamicFormDesigner/Views/HvlDynamicForm';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { MorgueExDischargeFormViewModel } from '../Morg_Modulu/MorgueExDischargeFormViewModel';
import { EpisodeActionHelper } from 'app/Helper/EpisodeActionHelper';
import Exception from '../../../wwwroot/app/NebulaClient/System/Exception';
import { _ } from 'core-js';
import { PrepareInteraction_Output } from 'Modules/Saglik_Lojistik/Eczane_Modulleri/Ilac_Direktifi_Giris_Modulu/DrugOrderGridComponentViewModel';
import { ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { CommonService } from '../../../wwwroot/app/NebulaClient/Services/ObjectService/CommonService';
import { plainToClass } from 'NebulaClient/ClassTransformer';
import { OzellikliIzlemIdContainer } from './OzellikliBakimIzlemForm';

@Component({
    selector: 'InPatientPhysicianApplicationForm',
    templateUrl: './InPatientPhysicianApplicationForm.html',
    providers: [SystemApiService, MessageService, NqlQueryService, DatePipe, EpisodeActionHelper]
})
export class InPatientPhysicianApplicationForm extends BaseNewDoctorExaminationForm implements OnInit, OnDestroy, IDestroyEvent {

    VentilatorStatus: TTVisual.ITTObjectListBox;

    OnDestroy: EventEmitter<any> = new EventEmitter<any>();
    ReportParamActiveIDsModel: ActiveIDsModel;
    EpicrisisReportParamActiveIDsModel: ActiveIDsModel;
    StartPhysiotherapyRequest: TTVisual.ITTCheckBox;
    Amount: TTVisual.ITTTextBoxColumn;
    AmountForPeriodDietOrder: TTVisual.ITTTextBoxColumn;
    Barcode: TTVisual.ITTTextBoxColumn;
    Bed: TTVisual.ITTObjectListBox;
    Breakfast: TTVisual.ITTCheckBoxColumn;
    ClinicDischargeDate: TTVisual.ITTDateTimePicker;
    CokluOzelDurum: TTVisual.ITTButtonColumn;
    DescriptionInPatientPhysicianProgressesRch: TTVisual.ITTRichTextBoxControlColumn;
    DietOrders: TTVisual.ITTGrid;
    Dinner: TTVisual.ITTCheckBoxColumn;
    DistributionType: TTVisual.ITTTextBoxColumn;
    FrequencyDietOrder: TTVisual.ITTEnumComboBoxColumn;
    GridDiagnosis: TTVisual.ITTGrid;
    GridTreatmentMaterials: TTVisual.ITTGrid;
    InpatientProtocolNo: TTVisual.ITTTextBox;
    InPatientRtfBySpecialities: TTVisual.ITTGrid;
    Kdv: TTVisual.ITTTextBoxColumn;
    KodsuzMalzemeFiyatı: TTVisual.ITTTextBoxColumn;
    labelBed: TTVisual.ITTLabel;
    labelClinicDischargeDate: TTVisual.ITTLabel;
    labelInpatientDepartment: TTVisual.ITTLabel;
    labelProtocolNo: TTVisual.ITTLabel;
    labelReasonForInpatientAdmission: TTVisual.ITTLabel;
    labelResponsibleNurse: TTVisual.ITTLabel;
    labelRoom: TTVisual.ITTLabel;
    labelRoomGroup: TTVisual.ITTLabel;
    lableResponsibleDoctor: TTVisual.ITTLabel;
    Lunch: TTVisual.ITTCheckBoxColumn;
    MalzemeBrans: TTVisual.ITTTextBoxColumn;
    MalzemeTuru: TTVisual.ITTListBoxColumn;
    MasterResource: TTVisual.ITTObjectListBox;
    Material: TTVisual.ITTListBoxColumn;
    nAmountForPeriod: TTVisual.ITTTextBoxColumn;
    nFrequency: TTVisual.ITTEnumComboBoxColumn;
    NightBreakfast: TTVisual.ITTCheckBoxColumn;
    nOrderDescription: TTVisual.ITTTextBoxColumn;
    Notes: TTVisual.ITTTextBoxColumn;
    nPeriodStartTime: TTVisual.ITTDateTimePickerColumn;
    nProcedureObject: TTVisual.TTTextBoxColumn;
    nRecurrenceDayAmount: TTVisual.ITTTextBoxColumn;
    NursingOrderGrid: TTVisual.ITTGrid;
    OrderDescriptionDietOrder: TTVisual.ITTMaskedTextBoxColumn;
    OzelDurum: TTVisual.ITTListBoxColumn;
    PeriodEndTimeDietOrder: TTVisual.ITTDateTimePickerColumn;
    PeriodStartTimeDietOrder: TTVisual.ITTDateTimePickerColumn;
    ProcedureDoctorInPatientPhysicianProgresses: TTVisual.ITTListBoxColumn;
    ProcedureObjectDietOrder: TTVisual.TTTextBoxColumn;
    DietRPT: TTVisual.ITTButtonColumn;
    DietChange: TTVisual.ITTButtonColumn;
    ProgressDateInPatientPhysicianProgresses: TTVisual.ITTDateTimePickerColumn;
    Progresses: TTVisual.ITTGrid;
    ReasonForInpatientAdmission: TTVisual.ITTTextBox;
    RecurrenceDayAmountDietOrder: TTVisual.ITTTextBoxColumn;
    ResponsibleDoctor: TTVisual.ITTObjectListBox;
    ResponsibleNurse: TTVisual.ITTObjectListBox;
    Room: TTVisual.ITTObjectListBox;
    RoomGroup: TTVisual.ITTObjectListBox;
    RPT: TTVisual.ITTButtonColumn;
    showDetail: TTVisual.ITTButtonColumn;
    rtfComplaint: TTVisual.ITTRichTextBoxControl;
    rtfHistory: TTVisual.ITTRichTextBoxControl;
    RtfInPatientRtfBySpeciality: TTVisual.ITTTextBoxColumn;
    rtfPhysicalExamination: TTVisual.ITTRichTextBoxControl;
    SatinAlisTarihi: TTVisual.ITTDateTimePickerColumn;
    SecDiagnose: TTVisual.ITTListBoxColumn;
    SecDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    SecFreeDiagnosis: TTVisual.ITTTextBoxColumn;
    SecIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    SecResponsibleUser: TTVisual.ITTListBoxColumn;
    Snack1: TTVisual.ITTCheckBoxColumn;
    Snack2: TTVisual.ITTCheckBoxColumn;
    Snack3: TTVisual.ITTCheckBoxColumn;
    TitleInPatientRtfBySpeciality: TTVisual.ITTTextBoxColumn;
    TreatmentMaterialActionDate: TTVisual.ITTDateTimePickerColumn;
    UBBCode: TTVisual.ITTTextBoxColumn;
    InpatientObservationEndTime: TTVisual.ITTDateTimePicker;
    InpatientObservationTime: TTVisual.ITTDateTimePicker;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    nNursingOrderObject: TTVisual.ITTListBoxColumn;
    cmbReportType: TTVisual.ITTEnumComboBox;
    ProgressDescription: TTVisual.ITTRichTextBoxControl;
    public componentInfo: DynamicComponentInfo;
    public DietOrdersColumns = [];
    public GridDiagnosisColumns = [];
    public GridTreatmentMaterialsColumns = [];
    public InPatientRtfBySpecialitiesColumns = [];
    public NursingOrderGridColumns = [];
    public ProgressesColumns = [];
    txtReportName: TTVisual.TTTextBoxColumn;
    txtReportRequestReason: TTVisual.TTTextBoxColumn;
    txtReportAdmissionDate: TTVisual.TTTextBoxColumn;
    txtReportMasterResource: TTVisual.TTTextBoxColumn;

    IsPandemic: TTVisual.ITTEnumComboBox;

    tedaviTipi: TTVisual.ITTObjectListBox;
    public TedaviTipiSelectedObject: TedaviTipi;

    txtStartDate: TTVisual.TTTextBoxColumn;
    txtEndDate: TTVisual.TTTextBoxColumn;
    btnEdit: TTVisual.TTButtonColumn;
    txtProcedureByUser: TTVisual.TTTextBoxColumn;

    showSurgeryAppointmentForm: boolean = false;

    btnInPatientPhysicianApplicationSave: TTVisual.ITTButton;
    btnInPatientPhysicianApplicationSaveAndClose: TTVisual.ITTButton;
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    public enableInfluenzaHelpServiceButton: boolean = false;

    public showERaporSorgulaComponent = false;
    HCModeOfPayment: TTVisual.ITTEnumComboBox;
    GridPatientReportsColumns = [];
    listBoxTreatmentResult: TTVisual.ITTObjectListBox;

    public inPatientPhysicianApplicationFormViewModel: InPatientPhysicianApplicationFormViewModel = new InPatientPhysicianApplicationFormViewModel();
    public get _InPatientPhysicianApplication(): InPatientPhysicianApplication {
        return this._TTObject as InPatientPhysicianApplication;
    }
    private InPatientPhysicianApplicationForm_DocumentUrl: string = '/api/InPatientPhysicianApplicationService/InPatientPhysicianApplicationForm';
    public nursingOrderSource: any;
    public nursingOrderScheduleList = [];
    public nursingOrderScheduleResource = [];
    public nursingOrderDetailScheduleResource = [];
    public dietOrderDetailScheduleResource = [];
    public dietOrderSource: any;
    public dietOrderScheduleList = [];
    public dietOrderScheduleResource = [];
    public changeDietPopUp = false;
    public ShowCovidProgressWarning: boolean = false;
    //arşiv
    public archiveDescription: string = "";
    public ArchiveGridColumns = [
        {
            'caption': i18n("M20568", "Arşiv Numarası"),
            dataField: 'ArchiveNo',
            allowSorting: true,
        },
        {
            'caption': "Kabul No",
            dataField: 'ProtocolNo',
            allowSorting: true
        },
        {
            'caption': 'Yatış Tarihi',
            dataField: 'InpatientDate',
            dataType: 'date',
            format: 'dd.MM.yyyy',
        },
        {
            'caption': 'Çıkış Tarihi',
            dataField: 'DischargeDate',
            dataType: 'date',
            format: 'dd.MM.yyyy',
        },
        {
            'caption': i18n("M24454", "Yatış Yeri"),
            dataField: 'ClinicName',
            allowSorting: true
        },
        {
            'caption': i18n("M24454", "Arşiv Yeri"),
            dataField: 'Location',
            allowSorting: true
        },
        {
            'caption': i18n("M24454", "Arşiv Durumu"),
            dataField: 'Status',
            allowSorting: true
        }
    ];

    currentDate: Date = new Date(Date.now());
    nodScheduleViews: any = ['agenda', 'month', {
        type: 'week',
        //groups: ['typeId'],
        dateCellTemplate: 'dateCellTemplate'
    }, 'day'];

    @ViewChild('nodscheduler') _nodscheduler: DxSchedulerComponent;
    @ViewChild('noddetailscheduler') _noddetailscheduler: DxSchedulerComponent;




    @ViewChild('dietscheduler') _dietscheduler: DxSchedulerComponent;
    @ViewChild('dietdetailscheduler') _dietdetailscheduler: DxSchedulerComponent;

    @ViewChild('physicianProgressesGrid') physicianProgressesGrid: DxDataGridComponent;
    @ViewChild('memberDoctorsGrid') memberDoctorsGrid: DxDataGridComponent;
    public setMemberspecialityValueFunc: Function;

    showNursingOrderPopup: boolean;
    public NOrderTempDetail: Array<NursingOrderTemplateDetail> = new Array<NursingOrderTemplateDetail>();
    //public NursingOrderTempGridColumns = [];
    public statusNotificationReportObject = new StatusNotificationReport;
    public medulaTedaviRaporlariObject = new MedulaTreatmentReport;
    public ParticipationFreeDrugReportNewFormObject = new ParticipatnFreeDrugReport;
    public selectedRowKeysResultList: Array<NursingOrderTemplateDetail> = [];
    public txtNursingOrderTemplateName: string;
    public nursingOrderTempSource: any;
    public currentActionReports: boolean = false;
    fromTemplateSave: boolean = false;
    fromTemplateGet: boolean = false;
    showStatusNotificationReportForm = false;
    showMedulaTedaviRaporlariForm = false;
    showParticipationFreeDrugReportNewForm = false;
    nursingOrderScheduleDetailLoadedDateList: Array<string> = new Array<string>();
    dietOrderScheduleDetailLoadedDateList: Array<string> = new Array<string>();
    public reportTypeList: Array<EnumItem>;
    /*
     EPIKRIZ RAPORU
    */
    public epicrisisReportVisible: boolean = false;
    public epicrisisReportAllClinicsSelected: boolean = false;
    public selectedOldInpatient: Guid = new Guid();
    ReportSelectedDoctorCombo: TTVisual.ITTObjectListBox;

    /*
    EPIKRIZ RAPORU
    */

    public hasRoleForPrescriptionApproval: boolean = false;
    public ShowNewDrugOrderForm = false;
    public ComfirmRowDeletingFunc: Function;
    public showPopupVacationForm = false;

    public reportController: ReportController = new ReportController();

    panelMessage: string = "Günübirlik Yatış İşlemleri Yapılıyor Lütfen Bekleyiniz";

    public NursingOrderTempGridColumns = [
        {
            caption: i18n("M24169", "Vital Bulgu ve Hemşirelik İşlemleri"),
            dataField: "NursingOrderObject",
            dataType: "object",
            width: "auto",
            allowSorting: true,
            visible: false
            //valueExpr: 'NursingOrderObject.ObjectID',
            //displayExpr: 'NAME',
            //displayValue: 'NAME',
            //text: "NAME"
        },
        {
            caption: i18n("M24169", "Vital Bulgu ve Hemşirelik İşlemleri"),
            dataField: "NursingOrderObject.TempOrderName",
            width: "auto",
            allowSorting: true
            //valueExpr: 'NursingOrderObject.ObjectID',
            //displayExpr: 'NAME',
            //displayValue: 'NAME',
            //text: "NAME"
        },
        {
            caption: i18n("M23742", "Uyg. Aralığı"),
            dataField: "Frequency",
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M23744", "Uyg. Miktarı"),
            dataField: "AmountForPeriod",
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M14998", "Gün"),
            dataField: "RecurrenceDayAmount",
            width: "auto",
            allowSorting: true
        }
    ];

    ActivePage: string = "clinicProsess";
    RecentActiveTab: string;

    public hasEmergencySpecialityBasedObject: boolean = true;
    public hasEmergencyIntervention: boolean = false;
    public selectedReportType: EnumItem;
    public contextMenuItems: any;
    private refreshReportGridSubscription: Subscription;

    public showEDurumBildirirComponent = false;
    /* Yatan Hasta Sağlık Kurulu*/
    DisabledReportApplicationExplanation: TTVisual.ITTTextBox;
    DisabledReportApplicationReason: TTVisual.ITTEnumComboBox;  //Müracaat Nedeni
    DisabledReportApplicationType: TTVisual.ITTEnumComboBox;  //Müracaat Tipi ( Engelli Raporu )
    DisabledReportCorporateApplicationType: TTVisual.ITTEnumComboBox; //Kurumsal Müracaat Türü  
    DisabledReportPersonalApplicationType: TTVisual.ITTEnumComboBox; //Kişisel Müracaat Tipi
    DisabledReportTerrorAccidentInjuryAppReason: TTVisual.ITTEnumComboBox; // Terör - Kaza Yaralanma Müracaat Nedeni
    DisabledReportTerrorAccidentInjuryAppType: TTVisual.ITTEnumComboBox;

    /* E-Durum Bildirir Kurul Entegrasyonu*/
    EStatusNotRepCommitteeApplicationType: TTVisual.ITTEnumComboBox;  //Müracaat Tipi ( E-Durum Bildirir Kurul )

    /*E-Durum Bildirir Kurul Entegrasyonu*/
    /* Yatan Hasta Sağlık Kurulu*/
    constructor(private services: ServiceContainer,
        http: Http,
        protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected modalService: IModalService,
        protected objectContextService: ObjectContextService,
        private detector: ApplicationRef,
        protected tabService: IActiveTabService,
        private sideBarMenuService: ISidebarMenuService,
        protected helpMenuService: HelpMenuService,
        public systemApiService: SystemApiService,
        private reportService: AtlasReportService,
        protected ngZone: NgZone,
        protected datePipe: DatePipe,
        private favoriteService: IFavoriteService,
        protected episodeActionHelper: EpisodeActionHelper,
    ) {
        super(httpService, messageService, modalService, objectContextService, helpMenuService, ngZone);
        this._DocumentServiceUrl = this.InPatientPhysicianApplicationForm_DocumentUrl;

        this.ComfirmRowDeletingFunc = this.comfirmRowDeleting.bind(this);

        this.initViewModel();
        this.initFormControls();

        this.contextMenuItems = [{ text: i18n("M19741", "Order\'ı Durdur") }];
        this.reportTypeList = ReportTypeEnum.Items;
    }



    TabPanelClick(source) {
        this.tabService.setActiveTab(source, "ippaf");
        this.SetActivePage(source);
        this.RecentActiveTab = source;
    }


    // ***** Method declarations start *****

    taburcuSelected() {
        if (!this.checkIsLongShortInpatient()) {//Kısa/Uzun yatış ise önce sebep girişi yapılmalı
            if (this.inPatientPhysicianApplicationFormViewModel.myTreatmentDischarge != null)
                this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("TREATMENTDISCHARGE", this.inPatientPhysicianApplicationFormViewModel.myTreatmentDischarge.ObjectID, null, new DynamicComponentInputParam(null, this.getActiveIDsModel()));
            else
                this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("TREATMENTDISCHARGE", null, null, new DynamicComponentInputParam(null, this.getActiveIDsModel()));
        }
    }
    sevkSelected() {
        if (!this.checkIsLongShortInpatient()) {//Kısa/Uzun yatış ise önce sebep girişi yapılmalı
            if (this.inPatientPhysicianApplicationFormViewModel.myTreatmentDischarge != null)
                this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("TREATMENTDISCHARGE", this.inPatientPhysicianApplicationFormViewModel.myTreatmentDischarge.ObjectID, null, new DynamicComponentInputParam(DischargeTypeEnum.TransferingToOtherlHospital, this.getActiveIDsModel()));
            else
                this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("TREATMENTDISCHARGE", null, null, new DynamicComponentInputParam(DischargeTypeEnum.TransferingToOtherlHospital, this.getActiveIDsModel()));
        }
    }

    nakilSelected() {
        if (!this.checkIsLongShortInpatient()) {//Kısa/Uzun yatış ise önce sebep girişi yapılmalı
            if (this.inPatientPhysicianApplicationFormViewModel.InPatientTreatmentClinicApplications[0].IsDailyOperation == true) {
                //        ServiceLocator.MessageService.showError("Günübirlik yatışlarda kurum içi sevk işlemi yapılamaz. Hastanın yatışı Yardımcı Menüler'de bulunan Yatışa Çevir butonu ile gerçekleştirilmelidir.");
                TTVisual.InfoBox.Alert("Uyarı", "Günübirlik yatışlarda kurum içi sevk işlemi yapılamaz. Hastanın yatışı Yardımcı Menüler'de bulunan Yatışa Çevir butonu ile gerçekleştirilmelidir.", MessageIconEnum.ErrorMessage);
                return false;
            }
            if (this.inPatientPhysicianApplicationFormViewModel.myTreatmentDischarge != null)
                this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("TREATMENTDISCHARGE", this.inPatientPhysicianApplicationFormViewModel.myTreatmentDischarge.ObjectID, null, new DynamicComponentInputParam(DischargeTypeEnum.TransferToOtherClinic, this.getActiveIDsModel()));
            else
                this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("TREATMENTDISCHARGE", null, null, new DynamicComponentInputParam(DischargeTypeEnum.TransferToOtherClinic, this.getActiveIDsModel()));
        }
    }

    showTaburcuButtons(): Boolean {
        if (this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication != null) {

            if (this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.EmergencyIntervention != null)
                return false;
            if (this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp != null && (this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp.TreatmentDischarge == null
                || this.inPatientPhysicianApplicationFormViewModel.myTreatmentDischarge.CurrentStateDefID == TreatmentDischarge.TreatmentDischargeStates.Cancelled))
                return true;
        }
        return false;
    }

    showDischargePrescriptionButtons(): Boolean {
        if (this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication != null) {

            if (this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.EmergencyIntervention != null)
                return false;
            if (this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp != null &&
                this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp.TreatmentDischarge !== undefined)
                return true;
        }
        return false;
    }

    async ngAfterViewInit() {
        let influenzaCheckValue: string = (await SystemParameterService.GetParameterValue('INFLUENZASERVICEACTIVE', 'FALSE'));
        if (influenzaCheckValue === 'TRUE') {
            this.enableInfluenzaHelpServiceButton = true;
        }
        this.openSubscribers();
    }
    //ngAfterContentInit() {
    //    this.physicianProgressesGrid.instance.filter(['EntityState', '<>', 1]);
    //}

    public openSubscribers() {
        let that = this;
        this.refreshReportGridSubscription = this.httpService.medicalStuffReportSharedService.medicalStuffReportUpdateObservable.subscribe(value => {
            this.reloadReportList();
        });
    }

    ActiveAcc: string;
    RecentAcc: string;

    AccPinClick(acc) {
        if (this.RecentAcc == acc) {
            this.RecentAcc = undefined;
            this.tabService.setActiveTab(this.RecentAcc, 'ippafacc');
        }
        else {
            this.RecentAcc = acc;
            this.tabService.setActiveTab(this.RecentAcc, 'ippafacc');
        }
    }

    // procedure-request-form için
    @ViewChild(ProcedureRequestForm) procedureRequestForm: ProcedureRequestForm;
    @ViewChild(MostUsedProcedureRequestForm) mostUsedProcedureRequestForm: MostUsedProcedureRequestForm;


    loadProcedureRequestFormResourceIDs() {
        this.inPatientPhysicianApplicationFormViewModel.ProcedureRequestFormResourceIDs = new Array<Guid>();
        if (this._InPatientPhysicianApplication.ProcedureDoctor != null) {
            if (typeof this._InPatientPhysicianApplication.ProcedureDoctor === "string")
                this.inPatientPhysicianApplicationFormViewModel.ProcedureRequestFormResourceIDs.push(this._InPatientPhysicianApplication.ProcedureDoctor);
            else
                this.inPatientPhysicianApplicationFormViewModel.ProcedureRequestFormResourceIDs.push(this._InPatientPhysicianApplication.ProcedureDoctor.ObjectID);
        }

        if (this._InPatientPhysicianApplication.MasterResource != null) {
            if (typeof this._InPatientPhysicianApplication.MasterResource === "string")
                this.inPatientPhysicianApplicationFormViewModel.ProcedureRequestFormResourceIDs.push(this._InPatientPhysicianApplication.MasterResource);
            else
                this.inPatientPhysicianApplicationFormViewModel.ProcedureRequestFormResourceIDs.push(this._InPatientPhysicianApplication.MasterResource.ObjectID);
        }
    }

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    public dynamicEditorChanged(data, event) {
        if (this.rowIndex > -1) {
            this.inPatientPhysicianApplicationFormViewModel.ProgressesGridList[this.rowIndex].Description = event;
        }
    }

    public rowIndex: number = -1;
    public editorValue: string = '';
    public showRichTextBoxPopup: boolean = false;
    public isLastSelectedProgressCovid: boolean = false;
    public lastSelectedCovidIzlemId: string = "";
    public ozellikliIzlemIdContainer: OzellikliIzlemIdContainer;

    public async openEditor(progress) {
        this.lastSelectedCovidIzlemId = "";
        this.isLastSelectedProgressCovid = false;
        this.rowIndex = progress.dataIndex;
        this.editorValue = progress.data.Description;
        await this.getOzellikliVeriSeti(progress.data.ObjectID);
        this.showRichTextBoxPopup = true;
    }

    public async getOzellikliVeriSeti(objectId: string) {
        let that = this;
        let fullApiUrl: string = "/api/InpatientPhysicianApplicationService/GetOzellikliIzlemVeriSetiByProgress?ObjectId=" + objectId;
        await this.httpService.get<any>(fullApiUrl)
            .then(response => {
                if (response != null) {
                    this.lastSelectedCovidIzlemId = response.toString();
                    if (this.lastSelectedCovidIzlemId != null)
                        this.isLastSelectedProgressCovid = true;
                    this.ozellikliIzlemIdContainer.ozellikliIzlemObjectID = new Guid(this.lastSelectedCovidIzlemId);
                } else {
                    this.isLastSelectedProgressCovid = false;
                }
            })
            .catch(error => {
                console.log(error);
            });
    }
    public copyEditor(progress) {
        if (this.inPatientPhysicianApplicationFormViewModel) {
            if (this.inPatientPhysicianApplicationFormViewModel.ProgressDescription) {
                this.inPatientPhysicianApplicationFormViewModel.ProgressDescription += progress.data.Description;
            }
            else {
                this.inPatientPhysicianApplicationFormViewModel.ProgressDescription = progress.data.Description;
            }

        }
    }
    public async btnInPatientPhysicianApplicationSave_Click(event) {

        if (event.component != null) {
            let component = event.component,
                prevClickTime = component.lastClickTime;
            component.lastClickTime = new Date();
            if (prevClickTime && (component.lastClickTime - prevClickTime < 500)) {
                ServiceLocator.MessageService.showInfo("İşleminiz gerçekleştiriliyor, Lütfen Bekleyiniz...");
            }
            else {
                this.loadPanelOperation(true, 'İşlem kaydediliyor, lütfen bekleyiniz.');
                const param = new FormSaveInfo(this._EpisodeAction.ObjectDefID.toString(), false);
                try {
                    if (this.IsPandemic.Required == true && this._InPatientPhysicianApplication.IsPandemic == null) {
                        throw new Exception("Pandemi olgusu seçmek zorunludur!");
                    }

                    if (this._InPatientPhysicianApplication.IsPandemic == YesNoEnum.Yes && (this.inPatientPhysicianApplicationFormViewModel.IsIntensiveCare == false || this.inPatientPhysicianApplicationFormViewModel.IsIntensiveCare == null)) {//Yoğun bakım olmayan hastalarda Ispandemic Evet ise tanı zorunlu
                        let covidDiagnode = this.inPatientPhysicianApplicationFormViewModel.GridDiagnosisGridList.find(c => c.Diagnose.Code_Shadow == "U07.3");
                        if (covidDiagnode == null) {
                            throw new Exception("Pandemi olgusu U07.3 tanısı eklemeden pandemi olgusunu kayıt edemezsiniz!");
                        }
                    }
                    if (this.inPatientPhysicianApplicationFormViewModel.IsDischarged == true)
                        throw new TTException(i18n("M22146", "Taburculuğu tamamlanmış ücretli hastalarda yeni işlem yapılamaz."));

                    await this.controlIntensiveCareScores();

                    await this.controlEmergencyInterventionInfo();
                    await this.save(param);
                    this.loadPanelOperation(false, '');
                } catch (error) {
                    this.loadPanelOperation(false, '');
                    ServiceLocator.MessageService.showError(error);
                }

            }
        }
    }

    public async btnInPatientPhysicianApplicationSaveAndClose_Click(event) {
        if (event.component != null) {
            let component = event.component,
                prevClickTime = component.lastClickTime;
            component.lastClickTime = new Date();
            if (prevClickTime && (component.lastClickTime - prevClickTime < 500)) {
                ServiceLocator.MessageService.showInfo("İşleminiz gerçekleştiriliyor, Lütfen Bekleyiniz...");
            }
            else {
                this.loadPanelOperation(true, 'İşlem kaydediliyor, lütfen bekleyiniz.');
                const param = new FormSaveInfo(this._EpisodeAction.ObjectDefID.toString(), true);
                try {
                    if (this.IsPandemic.Required == true && this._InPatientPhysicianApplication.IsPandemic == null) {
                        throw new Exception("Pandemi olgusu seçmek zorunludur!");
                    }

                    if (this._InPatientPhysicianApplication.IsPandemic == YesNoEnum.Yes && (this.inPatientPhysicianApplicationFormViewModel.IsIntensiveCare == false || this.inPatientPhysicianApplicationFormViewModel.IsIntensiveCare == null)) {//Yoğun bakım olmayan hastalarda Ispandemic Evet ise tanı zorunlu
                        let covidDiagnode = this.inPatientPhysicianApplicationFormViewModel.GridDiagnosisGridList.find(c => c.Diagnose.Code_Shadow == "U07.3");
                        if (covidDiagnode == null) {
                            throw new Exception("Pandemi olgusu U07.3 tanısı eklemeden pandemi olgusunu kayıt edemezsiniz!");
                        }
                    }
                    if (this.inPatientPhysicianApplicationFormViewModel.IsDischarged == true)
                        throw new TTException(i18n("M22146", "Taburculuğu tamamlanmış ücretli hastalarda yeni işlem yapılamaz."));

                    await this.controlIntensiveCareScores();

                    await this.controlEmergencyInterventionInfo();
                    await this.save(param);
                    this.loadPanelOperation(false, '');
                } catch (error) {
                    this.loadPanelOperation(false, '');
                    ServiceLocator.MessageService.showError(error);
                }
            }
        }
    }

    public async controlIntensiveCareScores() {

        //Yoğun bakım uyarıları
        if (this.inPatientPhysicianApplicationFormViewModel.IsIntensiveCare) {
            let currentDate: Date = await CommonService.RecTime();
            currentDate = plainToClass(Date, currentDate);
            let clinicInpatientDateAdded: Date = new Date(this.inPatientPhysicianApplicationFormViewModel.ClinicInpatientDateAdded);
            if (currentDate > clinicInpatientDateAdded) {

                if (this.inPatientPhysicianApplicationFormViewModel.IntensiveCareType == IntensiveCareTypeEnum.AdultIntensiveCare) {
                    if (this.inPatientPhysicianApplicationFormViewModel.ApacheScoreList == null || (this.inPatientPhysicianApplicationFormViewModel.ApacheScoreList != null && this.inPatientPhysicianApplicationFormViewModel.ApacheScoreList.length == 0)) {
                        if (this.inPatientPhysicianApplicationFormViewModel.SpecialityBasedObjectViewModels == null || (this.inPatientPhysicianApplicationFormViewModel.SpecialityBasedObjectViewModels != null && this.inPatientPhysicianApplicationFormViewModel.SpecialityBasedObjectViewModels[0].ApacheScoreSummaryInfoList.length == 0)) {
                            throw new Exception("Yoğun Bakım Hastaları için Apache Skoru Girilmesi Zorunludur!");
                        }
                    }
                    if (this.inPatientPhysicianApplicationFormViewModel.GlaskowScoreList == null ||
                        (this.inPatientPhysicianApplicationFormViewModel.GlaskowScoreList != null && this.inPatientPhysicianApplicationFormViewModel.GlaskowScoreList.length == 0)) {
                        if (this.inPatientPhysicianApplicationFormViewModel.SpecialityBasedObjectViewModels == null || (this.inPatientPhysicianApplicationFormViewModel.SpecialityBasedObjectViewModels != null && this.inPatientPhysicianApplicationFormViewModel.SpecialityBasedObjectViewModels[0].GlaskowScoreSummaryInfoList.length == 0)) {
                            throw new Exception("Yoğun Bakım Hastaları için Glaskow Skoru Girilmesi Zorunludur!");
                        }
                    }
                }
                else if (this.inPatientPhysicianApplicationFormViewModel.IntensiveCareType == IntensiveCareTypeEnum.NewBornIntensiveCare) {
                    if (this.inPatientPhysicianApplicationFormViewModel.SnappeScoreList == null ||
                        (this.inPatientPhysicianApplicationFormViewModel.SnappeScoreList != null && this.inPatientPhysicianApplicationFormViewModel.SnappeScoreList.length == 0)) {
                        if (this.inPatientPhysicianApplicationFormViewModel.SpecialityBasedObjectViewModels == null || (this.inPatientPhysicianApplicationFormViewModel.SpecialityBasedObjectViewModels != null && this.inPatientPhysicianApplicationFormViewModel.SpecialityBasedObjectViewModels[0].SnappeIIScoreSummaryInfoList.length == 0)) {
                            throw new Exception("Yenidoğan Yoğun Bakım Hastaları için Snappe II Skoru Girilmesi Zorunludur!");
                        }
                    }
                }
                else if (this.inPatientPhysicianApplicationFormViewModel.IntensiveCareType == IntensiveCareTypeEnum.ChildIntensiveCare) {
                    if (this.inPatientPhysicianApplicationFormViewModel.PrismScoreList == null ||
                        (this.inPatientPhysicianApplicationFormViewModel.PrismScoreList != null && this.inPatientPhysicianApplicationFormViewModel.PrismScoreList.length == 0)) {
                        if (this.inPatientPhysicianApplicationFormViewModel.SpecialityBasedObjectViewModels == null || (this.inPatientPhysicianApplicationFormViewModel.SpecialityBasedObjectViewModels != null && this.inPatientPhysicianApplicationFormViewModel.SpecialityBasedObjectViewModels[0].PrismSummaryInfoList.length == 0)) {
                            throw new Exception("Yoğun Bakım Hastaları için Prism Skoru Girilmesi Zorunludur!");
                        }
                    }
                    if (this.inPatientPhysicianApplicationFormViewModel.GlaskowScoreList == null ||
                        (this.inPatientPhysicianApplicationFormViewModel.GlaskowScoreList != null && this.inPatientPhysicianApplicationFormViewModel.GlaskowScoreList.length == 0)) {
                        if (this.inPatientPhysicianApplicationFormViewModel.SpecialityBasedObjectViewModels == null || (this.inPatientPhysicianApplicationFormViewModel.SpecialityBasedObjectViewModels != null && this.inPatientPhysicianApplicationFormViewModel.SpecialityBasedObjectViewModels[0].GlaskowScoreSummaryInfoList.length == 0)) {
                            throw new Exception("Yoğun Bakım Hastaları için Glaskow Skoru Girilmesi Zorunludur!");
                        }
                    }
                }
            }
        }
    }

    public async controlEmergencyInterventionInfo() {
        if (this.inPatientPhysicianApplicationFormViewModel.SpecialityBasedObjectViewModels != null) {
            if (this.inPatientPhysicianApplicationFormViewModel.SpecialityBasedObjectViewModels[0] instanceof EmergencySpecialityObjectFormViewModel) {
                let viewModel: EmergencySpecialityObjectFormViewModel = this.inPatientPhysicianApplicationFormViewModel.SpecialityBasedObjectViewModels[0];

                if (viewModel._EmergencySpecialityObject.Triage == null) {
                    // ServiceLocator.MessageService.showError("Triaj Kodu alanı boş olamaz");
                    throw new TTException("Triaj Kodu alanı boş olamaz.");
                }
                else if (viewModel._EmergencySpecialityObject.Triage.KODU == '0') {
                    // ServiceLocator.MessageService.showError("'Triaj kodu' alanı bu adımda 'Belirtilmemiş' olarak seçilemez.");
                    throw new TTException("'Triaj kodu' alanı bu adımda 'Belirtilmemiş' olarak seçilemez.");
                }
                else if (viewModel._EmergencySpecialityObject.Triage.KODU == '1') {
                    throw new TTException("Müşahede işlemlerinde'Triaj kodu' alanı bu adımda 'Yeşil' olarak seçilemez.");
                }

                this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.EmergencyIntervention.Triage = viewModel._EmergencySpecialityObject.Triage;
            }
        }

        if (this._InPatientPhysicianApplication.EmergencyIntervention != null) {
            this.currentDate = new Date(Date.now());

            if (this._InPatientPhysicianApplication.EmergencyIntervention.InpatientObservationTime != null) {
                if (this._InPatientPhysicianApplication.EmergencyIntervention.InpatientObservationTime > this.currentDate)
                    throw new TTException("'Müşahede Başlangıç Tarihi' şu andan daha ileri olamaz.");
                else if (this._InPatientPhysicianApplication.EmergencyIntervention.InpatientObservationTime < this._InPatientPhysicianApplication.PatientAdmission.ActionDate)
                    throw new TTException("'Müşahede Başlangıç Tarihi' kabul tarihinden küçük olamaz.");

                if (this._InPatientPhysicianApplication.EmergencyIntervention.DischargeTime != null) {
                    if (this._InPatientPhysicianApplication.EmergencyIntervention.InpatientObservationTime >= this._InPatientPhysicianApplication.EmergencyIntervention.DischargeTime)
                        throw new TTException("'Müşahede Başlangıç Tarihi' 'Müşahede Bitiş Tarihi'nden büyük veya eşit olamaz.");

                    if (this._InPatientPhysicianApplication.EmergencyIntervention.DischargeTime > this.currentDate)
                        throw new TTException("'Müşahede Bitiş Tarihi' şu andan daha ileri olamaz.");
                }
            }
        }
    }

    public async btnInPatientPhysicianApplicationCancel_Click() {
        // const param = new FormSaveInfo(this._EpisodeAction.ObjectDefID.toString(), true);
        await this.cancel();
    }

    activeIdsParam: ActiveIDsModel = null;
    public showSurgeryAppointmentFormPopUp() {
        this.activeIdsParam = this.getClickFunctionParams().Params;
        this.showSurgeryAppointmentForm = true;
    }

    public CloseSurgeryAppointmentPopUp(event) {
        this.activeIdsParam = null;
        this.showSurgeryAppointmentForm = false;
    }

    onDrugOrderIntruductionCreate() {

        this.objectContextService.getNewObject<DrugOrderIntroduction>(DrugOrderIntroduction.ObjectDefID, DrugOrderIntroduction).then(result => {
            let drugOrderIntroduction: DrugOrderIntroduction = result;
            drugOrderIntroduction.MasterResource = this._InPatientPhysicianApplication.MasterResource;
            drugOrderIntroduction.FromResource = this._InPatientPhysicianApplication.MasterResource;
            drugOrderIntroduction.SecondaryMasterResource = this._InPatientPhysicianApplication.SecondaryMasterResource;
            drugOrderIntroduction.Episode = this._InPatientPhysicianApplication.Episode;
            drugOrderIntroduction.SubEpisode = this._InPatientPhysicianApplication.SubEpisode;
            drugOrderIntroduction.ActiveInPatientPhysicianApp = this._InPatientPhysicianApplication;
            drugOrderIntroduction.PatientOwnDrug = false;
            drugOrderIntroduction.CurrentStateDefID = DrugOrderIntroduction.DrugOrderIntroductionStates.New;
            drugOrderIntroduction.DrugOrderIntroductionDetails = new Array<DrugOrderIntroductionDet>();

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "DrugOrderIntroductionNewForm";
            componentInfo.ModuleName = "IlacDirektifiGirisModule";
            componentInfo.ModulePath = "/Modules/Saglik_Lojistik/Eczane_Modulleri/Ilac_Direktifi_Giris_Modulu/IlacDirektifiGirisModule";
            componentInfo.InputParam = new DynamicComponentInputParam(drugOrderIntroduction, new ActiveIDsModel(this._InPatientPhysicianApplication.ObjectID, null, null));
            this.componentInfo = componentInfo;

        });
    }

    drugOrderIntroductionExecuted() {
        let that = this;
        setTimeout(function () {
            that.onDrugOrderIntruductionCreate();
        }, 1000);
    }

    private showDrugOrderIntroduction(data: DrugOrderIntroduction): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DrugOrderIntroductionNewForm';
            componentInfo.ModuleName = 'IlacDirektifiGirisModule';
            componentInfo.ModulePath = '/Modules/Saglik_Lojistik/Eczane_Modulleri/Ilac_Direktifi_Giris_Modulu/IlacDirektifiGirisModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, new ActiveIDsModel(this._InPatientPhysicianApplication.ObjectID, null, null));

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

    async onDrugOrderIntruductionOpen() {
        this.objectContextService.getNewObject<DrugOrderIntroduction>(DrugOrderIntroduction.ObjectDefID, DrugOrderIntroduction).then(result => {
            let drugOrderIntroduction: DrugOrderIntroduction = result;
            drugOrderIntroduction.MasterResource = this._InPatientPhysicianApplication.MasterResource;
            drugOrderIntroduction.SecondaryMasterResource = this._InPatientPhysicianApplication.SecondaryMasterResource;
            drugOrderIntroduction.Episode = this._InPatientPhysicianApplication.Episode;
            drugOrderIntroduction.SubEpisode = this._InPatientPhysicianApplication.SubEpisode;
            drugOrderIntroduction.ActiveInPatientPhysicianApp = this._InPatientPhysicianApplication;
            drugOrderIntroduction.PatientOwnDrug = false;
            drugOrderIntroduction.CurrentStateDefID = DrugOrderIntroduction.DrugOrderIntroductionStates.New;
            drugOrderIntroduction.DrugOrderIntroductionDetails = new Array<DrugOrderIntroductionDet>();

            // tslint:disable-next-line:no-shadowed-variable
            this.showDrugOrderIntroduction(drugOrderIntroduction).then(result => {
            }).catch(err2 => {
                this.messageService.showError(err2);
            });
        }).catch(err3 => {
            this.messageService.showError(err3);
        });
    }

    private currentUser: ResUser;
    public get CurrentUser() {
        if (this.currentUser == null)
            this.currentUser = <ResUser>TTUser.CurrentUser.UserObject;
        return this.currentUser;

    }

    public isProgressReadOnly(resProgressUser: ResUser) {
        if (resProgressUser != null && this.CurrentUser.ObjectID == resProgressUser.ObjectID)
            return false;
        return true;
    }

    public StoreResourceId(): any {
        if (this._InPatientPhysicianApplication != null) {
            if (this._InPatientPhysicianApplication.SecondaryMasterResource != null) {
                if (typeof this._InPatientPhysicianApplication.SecondaryMasterResource === "string") {

                    return this._InPatientPhysicianApplication.SecondaryMasterResource;
                }
                else {
                    return this._InPatientPhysicianApplication.SecondaryMasterResource.ObjectID;
                }
            }
            if (this._InPatientPhysicianApplication.MasterResource != null) {
                if (typeof this._InPatientPhysicianApplication.MasterResource === "string") {

                    return this._InPatientPhysicianApplication.MasterResource;
                }
                else {
                    return this._InPatientPhysicianApplication.MasterResource.ObjectID;
                }
            }
        }
    }

    // Yeni Dogan Yoğun Bakım entegresi için

    //public setNewBornIntensiveCareViewModel(e: any) {

    //    let that = this;
    //    if (this.inPatientPhysicianApplicationFormViewModel.newBornIntensiveCareFormViewModel == null) {
    //        this.inPatientPhysicianApplicationFormViewModel.newBornIntensiveCareFormViewModel = e;
    //    }
    //}

    public getPatientId(): Patient {
        if (this.inPatientPhysicianApplicationFormViewModel._Patient)
            return this.inPatientPhysicianApplicationFormViewModel._Patient;
        else
            return null;
    }

    showLongShortInpatientReason: boolean = false;
    LongShortInpatientReasonTitle: string = "";
    openLongShortInpatientReasonDynamicComponent(objectDefName: any, objectID?: any, formDefId?: any, inputparam?: any) {
        this.showLongShortInpatientReason = true;
        if (objectID != null) {
            this.systemApiService.open(objectID, "INPATIENTTREATMENTCLINICAPPLICATION", formDefId, new DynamicComponentInputParam(inputparam, new ActiveIDsModel(this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp.ObjectID, this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.Episode.ObjectID, null))).then(x => {
            });
        } else {
            this.systemApiService.new("INPATIENTTREATMENTCLINICAPPLICATION", null, formDefId, new DynamicComponentInputParam(inputparam, new ActiveIDsModel(this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp.ObjectID, this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.Episode.ObjectID, null))).then(x => {
            });
        }
    }
    LongShortInpatientReasonActionExecuted(value: any) {
        this.showLongShortInpatientReason = false;
        this.inPatientPhysicianApplicationFormViewModel.IsLongInpatient = false;
        this.inPatientPhysicianApplicationFormViewModel.IsShortInpatient = false;
    }
    checkIsLongShortInpatient(): boolean {//checkIsLongShortInpatient = true ise uzun/kısa yatış, false ise değil
        if (this.inPatientPhysicianApplicationFormViewModel.IsLongInpatient == true) {
            this.openLongShortInpatientReasonDynamicComponent(this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp.ObjectDefID, this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp.ObjectID, "e3fc10fd-5124-41c6-bbe7-66f55cc0d990")
            this.LongShortInpatientReasonTitle = "Uzun Yatış Nedeni Giriniz!";
            return true;
        } else if (this.inPatientPhysicianApplicationFormViewModel.IsShortInpatient == true) {
            this.openLongShortInpatientReasonDynamicComponent(this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp.ObjectDefID, this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp.ObjectID, "3e0d1799-205b-4561-8e11-96719512143c")
            this.LongShortInpatientReasonTitle = "Kısa Yatış Nedeni Giriniz!";
            return true;
        }
        return false;
    }
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new InPatientPhysicianApplication();
        this.inPatientPhysicianApplicationFormViewModel = new InPatientPhysicianApplicationFormViewModel();
        this._ViewModel = this.inPatientPhysicianApplicationFormViewModel;
        this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication = this._TTObject as InPatientPhysicianApplication;
        this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.DietOrders = new Array<DietOrder>();
        this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.SubEpisode = new SubEpisode();
        this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.SubEpisode.InPatientRtfBySpecialities = new Array<InPatientRtfBySpeciality>();
        this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.SubEpisode.InPatientPhysicianProgresses = new Array<InPatientPhysicianProgresses>();
        this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp = new InPatientTreatmentClinicApplication();
        this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission = new BaseInpatientAdmission();
        //this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.Bed = new ResBed();
        //this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.RoomGroup = new ResRoomGroup();
        //this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.Room = new ResRoom();
        this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp.MasterResource = new ResSection();
        this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp.ResponsibleNurse = new ResUser();
        this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp.ProcedureDoctor = new ResUser();
        this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.Episode = new Episode();
        this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.NursingOrders = new Array<NursingOrder>();
        this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.TreatmentMaterials = new Array<BaseTreatmentMaterial>();
        this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.Consultations = new Array<Consultation>();
        /**/

        this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.PatientInteviewForms = new Array<PatientInterviewForm>();
        this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.LinkedDentalConsultations = new Array<DentalExamination>();

        /**/
        this.inPatientPhysicianApplicationFormViewModel.UserMostUsedFormDefinitions = new Array<vmProcedureRequestFormDefinition>();

        this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.VentilatorStatus = new SKRSDurum();

    }


    public openKlinikBilgiTab: boolean = false;
    openKlinikBilgi() {
        this.openKlinikBilgiTab = true;
    }

    public openDoktorTab: boolean = false;
    openDoktor() {
        this.openDoktorTab = true;
        if (this.RecentAcc == '#ilac_collapse')
            this.openIlacShow = true;
        if (this.RecentAcc == '#hemsire_collapse')
            this.openHemsireShow = true;
        if (this.RecentAcc == '#diyet_collapse')
            this.openDiyetShow = true;
    }

    openIlacShow = false;
    openIlac() {
        this.openIlacShow = true;
    }
    openHemsireShow = false;
    openHemsire() {
        this.openHemsireShow = true;
    }
    openDiyetShow = false;
    openDiyet() {
        this.openDiyetShow = true;
    }

    public openIstemTab: boolean = false;
    openIstem() {
        this.openIstemTab = true;
    }

    public openHastaGecmisiTab: boolean = false;
    public openHastaGecmisi() {
        this.openHastaGecmisiTab = true;

        this.setPatientHistoryShown(this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.ObjectID);
    }

    public openHemsirelikTab: boolean = false;
    public openHemsirelik() {
        this.openHemsirelikTab = true;
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

    protected loadViewModel() {
        let that = this;

        this.currentDate = new Date(Date.now());

        that.inPatientPhysicianApplicationFormViewModel = this._ViewModel as InPatientPhysicianApplicationFormViewModel;
        that._TTObject = this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication;
        if (this.inPatientPhysicianApplicationFormViewModel == null)
            this.inPatientPhysicianApplicationFormViewModel = new InPatientPhysicianApplicationFormViewModel();
        if (this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication == null)
            this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication = new InPatientPhysicianApplication();
        that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.DietOrders = that.inPatientPhysicianApplicationFormViewModel.DietOrdersGridList;
        for (let detailItem of that.inPatientPhysicianApplicationFormViewModel.DietOrdersGridList) {
            let procedureObjectObjectID = detailItem["ProcedureObject"];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
                let procedureObject = that.inPatientPhysicianApplicationFormViewModel.DietDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
            let mealTypeObjectID = detailItem["MealType"];
            if (mealTypeObjectID != null && (typeof mealTypeObjectID === 'string')) {
                let mealType = that.inPatientPhysicianApplicationFormViewModel.MealTypess.find(o => o.ObjectID.toString() === mealTypeObjectID.toString());
                if (mealType) {
                    detailItem.MealType = mealType;
                }
            }
        }
        let subEpisodeObjectID = that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication["SubEpisode"];
        if (subEpisodeObjectID != null && (typeof subEpisodeObjectID === 'string')) {
            let subEpisode = that.inPatientPhysicianApplicationFormViewModel.SubEpisodes.find(o => o.ObjectID.toString() === subEpisodeObjectID.toString());
            if (subEpisode) {
                that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.SubEpisode = subEpisode;
            }
            if (subEpisode != null) {
                subEpisode.InPatientRtfBySpecialities = that.inPatientPhysicianApplicationFormViewModel.InPatientRtfBySpecialitiesGridList;
                for (let detailItem of that.inPatientPhysicianApplicationFormViewModel.InPatientRtfBySpecialitiesGridList) {
                }
            }
            if (subEpisode != null) {
                subEpisode.InPatientPhysicianProgresses = that.inPatientPhysicianApplicationFormViewModel.ProgressesGridList;
                for (let detailItem of that.inPatientPhysicianApplicationFormViewModel.ProgressesGridList) {
                    let procedureDoctorObjectID = detailItem["ProcedureDoctor"];
                    if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
                        let procedureDoctor = that.inPatientPhysicianApplicationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                        if (procedureDoctor) {
                            detailItem.ProcedureDoctor = procedureDoctor;
                        }
                    }
                }
            }
        }
        let inPatientTreatmentClinicAppObjectID = that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication["InPatientTreatmentClinicApp"];
        if (inPatientTreatmentClinicAppObjectID != null && (typeof inPatientTreatmentClinicAppObjectID === 'string')) {
            let inPatientTreatmentClinicApp = that.inPatientPhysicianApplicationFormViewModel.InPatientTreatmentClinicApplications.find(o => o.ObjectID.toString() === inPatientTreatmentClinicAppObjectID.toString());
            if (inPatientTreatmentClinicApp) {
                that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp = inPatientTreatmentClinicApp;
            }
            if (inPatientTreatmentClinicApp != null) {
                let baseInpatientAdmissionObjectID = inPatientTreatmentClinicApp["BaseInpatientAdmission"];
                if (baseInpatientAdmissionObjectID != null && (typeof baseInpatientAdmissionObjectID === 'string')) {
                    let baseInpatientAdmission = that.inPatientPhysicianApplicationFormViewModel.BaseInpatientAdmissions.find(o => o.ObjectID.toString() === baseInpatientAdmissionObjectID.toString());
                    inPatientTreatmentClinicApp.BaseInpatientAdmission = baseInpatientAdmission;
                    //        if (baseInpatientAdmission != null) {
                    //            let bedObjectID = baseInpatientAdmission["Bed"];
                    //            if (bedObjectID != null && (typeof bedObjectID === 'string')) {
                    //                let bed = that.inPatientPhysicianApplicationFormViewModel.ResBeds.find(o => o.ObjectID.toString() === bedObjectID.toString());
                    //                baseInpatientAdmission.Bed = bed;
                    //            }
                    //        }
                    //        if (baseInpatientAdmission != null) {
                    //            let roomGroupObjectID = baseInpatientAdmission["RoomGroup"];
                    //            if (roomGroupObjectID != null && (typeof roomGroupObjectID === 'string')) {
                    //                let roomGroup = that.inPatientPhysicianApplicationFormViewModel.ResRoomGroups.find(o => o.ObjectID.toString() === roomGroupObjectID.toString());
                    //                baseInpatientAdmission.RoomGroup = roomGroup;
                    //            }
                    //        }
                    //        if (baseInpatientAdmission != null) {
                    //            let roomObjectID = baseInpatientAdmission["Room"];
                    //            if (roomObjectID != null && (typeof roomObjectID === 'string')) {
                    //                let room = that.inPatientPhysicianApplicationFormViewModel.ResRooms.find(o => o.ObjectID.toString() === roomObjectID.toString());
                    //                baseInpatientAdmission.Room = room;
                    //            }
                    //        }
                }
            }
            if (inPatientTreatmentClinicApp != null) {
                let masterResourceObjectID = inPatientTreatmentClinicApp["MasterResource"];
                if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
                    let masterResource = that.inPatientPhysicianApplicationFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
                    if (masterResource) {
                        inPatientTreatmentClinicApp.MasterResource = masterResource;
                    }
                }
            }
            if (inPatientTreatmentClinicApp != null) {
                let responsibleNurseObjectID = inPatientTreatmentClinicApp["ResponsibleNurse"];
                if (responsibleNurseObjectID != null && (typeof responsibleNurseObjectID === 'string')) {
                    let responsibleNurse = that.inPatientPhysicianApplicationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleNurseObjectID.toString());
                    if (responsibleNurse) {
                        inPatientTreatmentClinicApp.ResponsibleNurse = responsibleNurse;
                    }
                }
            }
            if (inPatientTreatmentClinicApp != null) {
                let procedureDoctorObjectID = inPatientTreatmentClinicApp["ProcedureDoctor"];
                if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
                    let procedureDoctor = that.inPatientPhysicianApplicationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                    if (procedureDoctor) {
                        inPatientTreatmentClinicApp.ProcedureDoctor = procedureDoctor;
                    }
                }
            }
        }
        that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.Consultations = that.inPatientPhysicianApplicationFormViewModel.GrdConsultationGridList;
        for (let detailItem of that.inPatientPhysicianApplicationFormViewModel.GrdConsultationGridList) {
            let masterResourceObjectID = detailItem["MasterResource"];
            if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
                let masterResource = that.inPatientPhysicianApplicationFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
                if (masterResource) {
                    detailItem.MasterResource = masterResource;
                }
            }
            let procedureDoctorObjectID = detailItem["ProcedureDoctor"];
            if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
                let procedureDoctor = that.inPatientPhysicianApplicationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                if (procedureDoctor) {
                    detailItem.ProcedureDoctor = procedureDoctor;
                }
            }
        }
        that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.PatientInteviewForms = that.inPatientPhysicianApplicationFormViewModel.GrdPatientInterviewFormGridList;
        for (let detailItem of that.inPatientPhysicianApplicationFormViewModel.GrdPatientInterviewFormGridList) {
            // tslint:disable-next-line:no-shadowed-variable
            let masterResourceObjectID = detailItem['MasterResource'];
            if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
                let masterResource = that.inPatientPhysicianApplicationFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
                if (masterResource) {
                    detailItem.MasterResource = masterResource;
                }
            }
            // tslint:disable-next-line:no-shadowed-variable
            let procedureDoctorObjectID = detailItem['ProcedureDoctor'];
            if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
                let procedureDoctor = that.inPatientPhysicianApplicationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                if (procedureDoctor) {
                    detailItem.ProcedureDoctor = procedureDoctor;
                }
            }
        }
        that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.ExternalConsultations = that.inPatientPhysicianApplicationFormViewModel.GrdExternalConsultationGridList;
        for (let detailItem of that.inPatientPhysicianApplicationFormViewModel.GrdExternalConsultationGridList) {
            // tslint:disable-next-line:no-shadowed-variable
            let masterResourceObjectID = detailItem['MasterResource'];
            if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
                let masterResource = that.inPatientPhysicianApplicationFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
                if (masterResource) {
                    detailItem.MasterResource = masterResource;
                }
            }
            // tslint:disable-next-line:no-shadowed-variable
            let procedureDoctorObjectID = detailItem['ProcedureDoctor'];
            if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
                let procedureDoctor = that.inPatientPhysicianApplicationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                if (procedureDoctor) {
                    detailItem.ProcedureDoctor = procedureDoctor;
                }
            }
        }
        let episodeObjectID = that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.inPatientPhysicianApplicationFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.Episode = episode;
            }
            if (episode != null) {
                episode.Patient = that.inPatientPhysicianApplicationFormViewModel._Patient;
                episode.Diagnosis = that.inPatientPhysicianApplicationFormViewModel.GridDiagnosisGridList;
                for (let detailItem of that.inPatientPhysicianApplicationFormViewModel.GridDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
                        let diagnose = that.inPatientPhysicianApplicationFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                        if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === 'string')) {
                        let responsibleUser = that.inPatientPhysicianApplicationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                        if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }
            }
        }
        /**/
        for (let detailItem of that.inPatientPhysicianApplicationFormViewModel.GrdConsAndPatientInterviewFormGridList) {
            if (detailItem instanceof Consultation) {
                that.inPatientPhysicianApplicationFormViewModel.GrdConsultationGridList.push(<Consultation>detailItem);
            }
            else if (detailItem instanceof PatientInterviewForm) {
                that.inPatientPhysicianApplicationFormViewModel.GrdPatientInterviewFormGridList.push(<PatientInterviewForm>detailItem);
            } else if (detailItem instanceof DentalExamination) {
                that.inPatientPhysicianApplicationFormViewModel.GrdDentalExaminationGridList.push(<DentalExamination>detailItem);
            }
        }
        that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.PatientInteviewForms = that.inPatientPhysicianApplicationFormViewModel.GrdPatientInterviewFormGridList;
        for (let detailItem of that.inPatientPhysicianApplicationFormViewModel.GrdPatientInterviewFormGridList) {
            let masterResourceObjectID = detailItem["MasterResource"];
            if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
                let masterResource = that.inPatientPhysicianApplicationFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
                if (masterResource) {
                    detailItem.MasterResource = masterResource;
                }
            }
            let procedureDoctorObjectID = detailItem["ProcedureDoctor"];
            if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
                let procedureDoctor = that.inPatientPhysicianApplicationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                if (procedureDoctor) {
                    detailItem.ProcedureDoctor = procedureDoctor;
                }
            }
        }
        that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.LinkedDentalConsultations = that.inPatientPhysicianApplicationFormViewModel.GrdDentalExaminationGridList;
        for (let detailItem of that.inPatientPhysicianApplicationFormViewModel.GrdDentalExaminationGridList) {
            // tslint:disable-next-line:no-shadowed-variable
            let masterResourceObjectID = detailItem['MasterResource'];
            if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
                let masterResource = that.inPatientPhysicianApplicationFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
                if (masterResource) {
                    detailItem.MasterResource = masterResource;
                }
            }
            // tslint:disable-next-line:no-shadowed-variable
            let procedureDoctorObjectID = detailItem['ProcedureDoctor'];
            if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
                let procedureDoctor = that.inPatientPhysicianApplicationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                if (procedureDoctor) {
                    detailItem.ProcedureDoctor = procedureDoctor;
                }
            }
        }
        /**/
        that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.NursingOrders = that.inPatientPhysicianApplicationFormViewModel.NursingOrderGridGridList;
        for (let detailItem of that.inPatientPhysicianApplicationFormViewModel.NursingOrderGridGridList) {
            let procedureObjectObjectID = detailItem["ProcedureObject"];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
                let procedureObject = that.inPatientPhysicianApplicationFormViewModel.VitalSignAndNursingDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
        }
        that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.TreatmentMaterials = that.inPatientPhysicianApplicationFormViewModel.GridTreatmentMaterialsGridList;
        for (let detailItem of that.inPatientPhysicianApplicationFormViewModel.GridTreatmentMaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.inPatientPhysicianApplicationFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.inPatientPhysicianApplicationFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.inPatientPhysicianApplicationFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let ozelDurum = that.inPatientPhysicianApplicationFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                if (ozelDurum) {
                    detailItem.OzelDurum = ozelDurum;
                }
            }

            if ((that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp != null
                && that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp.IsDailyOperation == true)
                || that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.EmergencyIntervention != null) {
                let subEpisodeID = detailItem['SubEpisode'];
                if (subEpisodeID != null && (typeof subEpisodeID === 'string')) {
                    let subEpisode = that.inPatientPhysicianApplicationFormViewModel.SubEpisodeList.find(o => o.ObjectID.toString() === subEpisodeID.toString());
                    if (subEpisode) {
                        detailItem.SubEpisode = subEpisode;
                    }
                }

                let episodeActionID = detailItem['EpisodeAction'];
                if (episodeActionID != null && (typeof episodeActionID === 'string')) {
                    let episodeAction = that.inPatientPhysicianApplicationFormViewModel.EpisodeActionList.find(o => o.ObjectID != null && o.ObjectID.toString() === episodeActionID.toString());
                    if (episodeAction) {
                        detailItem.EpisodeAction = episodeAction;
                    }
                }
            }
        }
        let emergencyInterventionID = that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication["EmergencyIntervention"];
        if (emergencyInterventionID != null && (typeof emergencyInterventionID === 'string')) {
            let emergencyIntervention = that.inPatientPhysicianApplicationFormViewModel.EmergencyInterventions.find(o => o.ObjectID.toString() === emergencyInterventionID.toString());
            if (emergencyIntervention) {
                that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.EmergencyIntervention = emergencyIntervention;
            }
        }

        let ventilatorStatusObjectID = that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication["VentilatorStatus"];
        if (ventilatorStatusObjectID != null && (typeof ventilatorStatusObjectID === "string")) {
            let ventilatorStatus = that.inPatientPhysicianApplicationFormViewModel.SKRSDurums.find(o => o.ObjectID.toString() === ventilatorStatusObjectID.toString());
            if (ventilatorStatus) {
                that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.VentilatorStatus = ventilatorStatus;
            }
        }

        this.nursingOrderSource = new DataSource({
            store: this.inPatientPhysicianApplicationFormViewModel.VitalSignAndNursingDefinitionList,
            searchOperation: "contains",
            searchExpr: "Name"
        });
        this.dietOrderSource = new DataSource({
            store: this.inPatientPhysicianApplicationFormViewModel.DietDefinitionList,
            searchOperation: "contains",
            searchExpr: "Name"
        });
        this.inPatientPhysicianApplicationFormViewModel.UserMostUsedFormDefinitions = new Array<vmProcedureRequestFormDefinition>();
        this.loadProcedureRequestFormResourceIDs();
        super.loadViewModel(); //Uzmanlık için
        this.controlDailyInpatient();
        this.SetActivePage(this.tabService.getActiveTab("ippaf"))

        //Uzmanlık için
        if (this.ActivePage == undefined) {
            if (this.inPatientPhysicianApplicationFormViewModel.hasSpecialityBasedObject == true)
                this.SetActivePage("uzmanlik");
            if (this.hasEmergencySpecialityBasedObject == true)
                this.SetActivePage("clinicProsess");
        } else if (this.ActivePage != undefined) {
            if (this.inPatientPhysicianApplicationFormViewModel.hasSpecialityBasedObject == false && this.ActivePage == "uzmanlik")
                this.SetActivePage("clinicProsess");
            if (this.hasEmergencySpecialityBasedObject == false && this.ActivePage == "clinicProsess")
                this.SetActivePage("uzmanlik");
            if (this.ActivePage === 'istem')
                this.openIstemTab = true;
            if (this.ActivePage === 'hastaGecmisi')
                this.openHastaGecmisi();
            if (this.ActivePage === 'doktorDirektifleri') {
                this.openDoktorTab = true;
                if (this.RecentAcc == '#ilac_collapse')
                    this.openIlacShow = true;
                if (this.RecentAcc == '#hemsire_collapse')
                    this.openHemsireShow = true;
                if (this.RecentAcc == '#diyet_collapse')
                    this.openDiyetShow = true;
            }
            if (this.ActivePage === 'hemsirelik')
                this.openHemsirelikTab = true;
        }
        if (this.ActivePage === 'uzmanlik' || !this.hasEmergencySpecialityBasedObject)
            this.openUzmanlikTab = true;



        this.RecentActiveTab = this.ActivePage;


        this.inPatientPhysicianApplicationFormViewModel.ENabizViewModels = [];
        if (this.inPatientPhysicianApplicationFormViewModel.HasFalling == true && this.Issave == true && this.inPatientPhysicianApplicationFormViewModel.showFallingRiskParameter)
            this.ShowFallingRiskPopup = true;


        if (this.inPatientPhysicianApplicationFormViewModel.HasFalling == true && this.inPatientPhysicianApplicationFormViewModel.showFallingRiskParameter) {
            this.ShowFallingRiskPopup = true;
            this.fallingRiskMessage = `1. Çevresel faktörleri kontrol ediniz.<br/>
                                       2. Hasta ve/ veya yakınlarına düşme riski eğitimi veriniz.<br/>
                                       3. Hemşire çağrı zili hastanın ulaşabileceği bir yerde bulundurunuz.<br/>
                                       4. Yatak kenarlıkları yukarıda tutunuz.Sedye, tekerlekli sandalye ve yatağın tekerlekleri kilitleyiniz.`;
        }
        else if (this.inPatientPhysicianApplicationFormViewModel.fallingWarningAge > -1 && this.inPatientPhysicianApplicationFormViewModel.showFallingRiskParameter) {
            this.ShowFallingAgeWarningPopup = true;
            if (this.inPatientPhysicianApplicationFormViewModel.fallingWarningAge > 65)
                this.fallingAgeWarningMessage = i18n("M15128", "Hasta 65 yaşının üstündedir. Lütfen Düşme Riski Değerlendirmesi Yapınız.");
            else if (this.inPatientPhysicianApplicationFormViewModel.fallingWarningAge < 7)
                this.fallingAgeWarningMessage = i18n("M15129", "Hasta 7 yaşın altındadır. Lütfen Düşme Riski Değerlendirmesi Yapınız.");
        }

        this.EpicrisisReportParamActiveIDsModel = new ActiveIDsModel(this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.ObjectID, this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.Episode.ObjectID, this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.Episode.Patient.ObjectID);
        that.ShowCovidProgressWarning = this.inPatientPhysicianApplicationFormViewModel.HasCovidDiagnosisOnPatient == true && !this.inPatientPhysicianApplicationFormViewModel.HasTodayCovidProgress;
        this.ozellikliIzlemIdContainer = new OzellikliIzlemIdContainer();
        this.ozellikliIzlemIdContainer.episodeActionId = this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.ObjectID;
    }
    fallingAgeWarningMessage: string = "";
    ShowFallingAgeWarningPopup: boolean = false;


    okClickFallingRiskBox(isDone: boolean) {
        this.ShowFallingRiskPopup = false;
        if (isDone) {
            let params: NursingAppDoneInfoInput = new NursingAppDoneInfoInput();
            params.NursingApplicationID = new Guid(this.inPatientPhysicianApplicationFormViewModel.NursingApplicationObjectID);

            let apiUrl: string = '/api/NursingApplicationService/setFallingRiskNursingAppDoneDate';
            this.httpService.post<void>(apiUrl, params);
        }
    }



    ShowFallingRiskPopup = false;
    fallingRiskMessage = `1. Çevresel faktörleri kontrol ediniz.<br/>
                            2. Hasta ve/ veya yakınlarına düşme riski eğitimi veriniz.<br/>
                            3. Hemşire çağrı zili hastanın ulaşabileceği bir yerde bulundurunuz.<br/>
                            4. Yatak kenarlıkları yukarıda tutunuz.Sedye, tekerlekli sandalye ve yatağın tekerlekleri kilitleyiniz.`;

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {


        await this.CheckIsDiagnosisExists(this.inPatientPhysicianApplicationFormViewModel.GridDiagnosisGridList);

        //bugün ve sonrasını kontrol et
        /*   let afterTodays = this.inPatientPhysicianApplicationFormViewModel.DietOrdersGridList.filter(x => x.PeriodStartTime.setHours(0, 0, 0, 0) >= this.currentDate.setHours(0, 0, 0, 0) && x.CurrentStateDefID != DietOrder.DietOrderStates.Cancelled);

           let result = afterTodays.filter(i1 => {
               let others = afterTodays.filter(i2 => i2 !== i1);
               let result = others.find(i3 => {

                   return ((i3.PeriodStartTime >= i1.PeriodStartTime && i3.PeriodStartTime <= i1.PeriodEndTime)
                       || (i3.PeriodEndTime >= i1.PeriodStartTime && i3.PeriodEndTime <= i1.PeriodEndTime)) &&
                       ((i1.MealType.Breakfast && i3.MealType.Breakfast == i1.MealType.Breakfast)
                           || (i1.MealType.Lunch && i1.MealType.Lunch == i3.MealType.Lunch) || (i1.MealType.Dinner && i1.MealType.Dinner == i3.MealType.Dinner)
                           || (i1.MealType.Snack1 && i1.MealType.Snack1 == i3.MealType.Snack1) || (i1.MealType.Snack2 && i1.MealType.Snack2 == i3.MealType.Snack2)
                           || (i1.MealType.Snack3 && i1.MealType.Snack3 == i3.MealType.Snack3) || (i1.MealType.NightBreakfast && i1.MealType.NightBreakfast == i3.MealType.NightBreakfast));
               })
               return result;
           });

           if (result.length > 0) {
               throw new Exception("Aynı gün aynı öğünler için farklı diyet seçimleri mevcut.\nDevam etmeden önce diyet girişlerini düzenlemelisiniz.");
           }*/

        super.ClientSidePostScript(transDef);
    }


    private SetActivePage(page: string) {
        this.ActivePage = page;

        if (page == 'clinicProsess') {
            this.openKlinikBilgiTab = true;
        }
        else if (page == 'uzmanlik') {
            this.openUzmanlikTab = true;
        }
        else if (page == 'istem') {
            this.openIstemTab = true;
        }
        else if (page == 'hastaGecmisi') {
            this.openHastaGecmisi();
        }
        else if (page == 'doktorDirektifleri') {
            this.openDoktorTab = true;
        }
        else if (page == 'hemsirelik') {
            this.openHemsirelikTab = true;
        }

    }

    protected async PostScript(transDef: TTObjectStateTransitionDef) {


        this.inPatientPhysicianApplicationFormViewModel.GrdConsultationGridList = new Array<Consultation>();
        this.inPatientPhysicianApplicationFormViewModel.GrdPatientInterviewFormGridList = new Array<PatientInterviewForm>();
        this.inPatientPhysicianApplicationFormViewModel.GrdDentalExaminationGridList = new Array<DentalExamination>();
        for (let detailItem of this.inPatientPhysicianApplicationFormViewModel.GrdConsAndPatientInterviewFormGridList) {
            if (detailItem instanceof Consultation) {
                this.inPatientPhysicianApplicationFormViewModel.GrdConsultationGridList.push(<Consultation>detailItem);
            }
            else if (detailItem instanceof PatientInterviewForm) {
                this.inPatientPhysicianApplicationFormViewModel.GrdPatientInterviewFormGridList.push(<PatientInterviewForm>detailItem);
            }
            else if (detailItem instanceof ConsultationFromExternalHospital) {
                this.inPatientPhysicianApplicationFormViewModel.GrdExternalConsultationGridList.push(<ConsultationFromExternalHospital>detailItem);
            } else if (detailItem instanceof DentalExamination) {
                this.inPatientPhysicianApplicationFormViewModel.GrdDentalExaminationGridList.push(<DentalExamination>detailItem);
            }
        }

        //yeni eklenen ve detayları değiştirilen hemşire direktifleri
        this.inPatientPhysicianApplicationFormViewModel.newNursingOrderDetailList = new Array<NewNursingOrderDetail>();
        let newOrderArray = this.inPatientPhysicianApplicationFormViewModel.NursingOrderGridGridList.filter(p => p.IsNew);
        for (let i = 0; i < newOrderArray.length; i++) {
            if (newOrderArray[i].OrderDetails != null && newOrderArray[i].OrderDetails.length > 0) {
                let _detail = new NewNursingOrderDetail();
                _detail.newNursingOrderDetail = newOrderArray[i].OrderDetails;
                _detail.NursingOrderID = newOrderArray[i].ProcedureObject.ObjectID;
                this.inPatientPhysicianApplicationFormViewModel.newNursingOrderDetailList.push(_detail);
            }

        }

    }
    Issave: boolean = true;
    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        await super.AfterContextSavedScript(transDef);
        this.Issave = false;
        if (this.inPatientPhysicianApplicationFormViewModel.GrdExternalConsultationGridList && this.inPatientPhysicianApplicationFormViewModel.GrdExternalConsultationGridList.length > 0) {
            for (let extConsultation of this.inPatientPhysicianApplicationFormViewModel.GrdExternalConsultationGridList) {
                try {
                    let extConsultationObjectID = extConsultation['ObjectID'];
                    if (extConsultationObjectID != null && (typeof extConsultationObjectID === 'string')) {
                        const objectIdParam = new GuidParam(extConsultationObjectID);
                        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
                        this.reportService.showReport("ConsultationFromExternalHospitalReport", reportParameters);
                    }
                } catch (err) {
                    ServiceLocator.MessageService.showError(err);
                }
            }
        }


        if (this.requestedProceduresFormInstance != undefined && this.requestedProceduresFormInstance.operationControl === true
            && this.hasEmergencyIntervention) {
            this.loadingVisible = true;
            await this.requestedProceduresFormInstance.DailyOperationsSave(this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication);
        }

        else if (this.treatmentMaterialFormInstance != undefined && this.treatmentMaterialFormInstance.operationControl === true
            && this.hasEmergencyIntervention) {
            this.loadingVisible = true;
            await this.treatmentMaterialFormInstance.DailyOperationsSave(this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication);
        }

        this.loadingVisible = false;

        if (transDef.SaveAndClose === false)
            await this.ngOnInit();

        await this.requestedProceduresFormInstance.checkPathologyRequest(this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication, transDef.SaveAndClose);


    }

    private InPatientRtfBySpecialitiesEditorConfig: any = {
        removePlugins: 'elementspath',
        height: '110px'
    };
    private InPatientPhysicianProgressesTableEditorConfig: any = {
        removePlugins: 'elementspath',
        height: 'auto'
    };

    public stockSiteNgIf: boolean = true;

    async ngOnInit() {
        //let url: string = '/api/Account/HasRole';
        //let input = { 'roleID': new Guid('e0108f2a-af23-4963-b0ae-b0a5d1272c58') };
        //let httpService: NeHttpService = ServiceLocator.NeHttpService;
        //let result = await httpService.post<boolean>(url, input);
        //this.hasRoleForPrescriptionApproval = result;

        this.ActiveAcc = this.tabService.getActiveTab('ippafacc');
        this.RecentAcc = this.ActiveAcc;
        let that = this;
        await this.load(InPatientPhysicianApplicationFormViewModel);
        this.onDrugOrderIntruductionCreate();

        this.AddHelpMenu();

        let stockSitesName: string = (await SystemParameterService.GetParameterValue("STOCKSITESNAME", "GAZİLER"));
        if (stockSitesName === "GAZİLER") {
            this.stockSiteNgIf = true;
        }
        else {
            this.stockSiteNgIf = false;
        }


        // this.httpService.eNabizButtonSharedService.changeButtonVisible(true);
    }



    protected async PreScript(): Promise<void> {
        await super.PreScript();
        //Uzmanlık için
        this.setSpesialityBasedObjectInfo();
        // afterviewInitte this.physicianProgressesGrid boş
        const physicianProgressesGridDataSource = this.physicianProgressesGrid.instance.getDataSource();
        if (this.physicianProgressesGrid && this.physicianProgressesGrid.instance && physicianProgressesGridDataSource && this.physicianProgressesGrid.instance.filter) {
            this.physicianProgressesGrid.instance.filter(['EntityState', '<>', 1]);
        }

        // servera taşındı
        this.DropStateButton(InPatientPhysicianApplication.InPatientPhysicianApplicationStates.Cancelled);
        this.DropStateButton(InPatientPhysicianApplication.InPatientPhysicianApplicationStates.PreDischarged);
        if (this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.EmergencyIntervention == null)
            this.DropStateButton(InPatientPhysicianApplication.InPatientPhysicianApplicationStates.Discharged);


        if (this._InPatientPhysicianApplication.EmergencyIntervention != null) {
            this.hasEmergencySpecialityBasedObject = false;
            this.hasEmergencyIntervention = true;
        }

        this.hasRequestedProceduresForm = true;

        if (this.inPatientPhysicianApplicationFormViewModel.StartPhysiotherapyRequest === true) {
            this.StartPhysiotherapyRequest.ReadOnly = true;
        }
        this.ReportSelectedDoctorCombo.ListFilterExpression = "USERRESOURCES.RESOURCE ='" + this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.MasterResource + "'";

        if (this.inPatientPhysicianApplicationFormViewModel.ShowNewDrugOrderForm === 'TRUE')
            this.ShowNewDrugOrderForm = true;
        else
            this.ShowNewDrugOrderForm = false;
        //(objectDefName: any, objectID?: any, formDefId?: any, inputparam?: any) 
        if (this.inPatientPhysicianApplicationFormViewModel.IsLongInpatient == true) {
            this.openLongShortInpatientReasonDynamicComponent(this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp.ObjectDefID, this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp.ObjectID, "e3fc10fd-5124-41c6-bbe7-66f55cc0d990")
            this.LongShortInpatientReasonTitle = "Uzun Yatış Nedeni Giriniz!";
        }

        if (this.inPatientPhysicianApplicationFormViewModel.IsNonInpatient == false) {//yatan hasta
            this.IsPandemic.Required = this.inPatientPhysicianApplicationFormViewModel.IsPandemicRequired;
            this.inPatientPhysicianApplicationFormViewModel.CovidDiagnose.Diagnose = this.inPatientPhysicianApplicationFormViewModel.CovidDiagnoseDef;
            this.inPatientPhysicianApplicationFormViewModel.CovidDiagnose.Diagnose['GeneratedDisplayExpression'] = this.inPatientPhysicianApplicationFormViewModel.CovidDiagnose.Diagnose.Code + ' ' + this.inPatientPhysicianApplicationFormViewModel.CovidDiagnose.Diagnose.Name;

        } else {//günübirlik ve müşahadeye alınan hasta 
            this.IsPandemic.Visible = false;
        }
    }

    onInPatientPhysicianProgressesRowRemoving(inPatientPhysicianProgress: any) {
        let that = this;
        setTimeout(function () {
            if (inPatientPhysicianProgress != null) {
                inPatientPhysicianProgress.EntityState = EntityStateEnum.Deleted;
                that.physicianProgressesGrid.instance.filter(['EntityState', '<>', 1]);
                that.physicianProgressesGrid.instance.refresh();
            }
        }, 50);

    }

    public onReportSelectedDoctorComboChanged(event): void {
        if (this.inPatientPhysicianApplicationFormViewModel.ReportSelectedDoctor != null || this.inPatientPhysicianApplicationFormViewModel.ReportSelectedDoctor != event) {
            this.inPatientPhysicianApplicationFormViewModel.ReportSelectedDoctor = event;
        }
    }

    selectAllClinics(event) {
        this.epicrisisReportAllClinicsSelected = event;
    }

    public printEpicrisisReport() {

        let selectedInpatientPhysicianApplication;
        let selectedDoctorParam;

        if (this.inPatientPhysicianApplicationFormViewModel.ReportSelectedDoctor != null) {
            if (this.epicrisisReportAllClinicsSelected == true) {
                this.inPatientPhysicianApplicationFormViewModel.PatientOldInpatients.forEach(oldInpatientPhysicianApp => {
                    selectedDoctorParam = new StringParam(this.inPatientPhysicianApplicationFormViewModel.ReportSelectedDoctor.ObjectID.toString());
                    selectedInpatientPhysicianApplication = new StringParam(oldInpatientPhysicianApp.ObjectID.toString());
                    let reportParameters: any = { 'TTOBJECTID': selectedInpatientPhysicianApplication, 'Doctor': selectedDoctorParam };
                    this.reportService.showReport("EpicrisisReportForPatient", reportParameters);
                });
            } else {
                selectedDoctorParam = new StringParam(this.inPatientPhysicianApplicationFormViewModel.ReportSelectedDoctor.ObjectID.toString());
                selectedInpatientPhysicianApplication = new StringParam(this.selectedOldInpatient.toString());

                let reportParameters: any = { 'TTOBJECTID': selectedInpatientPhysicianApplication, 'Doctor': selectedDoctorParam };
                this.reportService.showReport("EpicrisisReportForPatient", reportParameters);
            }
        } else {
            TTVisual.InfoBox.Alert("Doktor Seçmeden Bu Raporu Yazdıramazsınız");
        }

    }

    public onBedChanged(event): void {
        if (event != null) {
            if (this._InPatientPhysicianApplication != null &&
                this._InPatientPhysicianApplication.InPatientTreatmentClinicApp != null &&
                this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission != null && this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.Bed != event) {
                this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.Bed = event;
            }
        }
    }

    public onClinicDischargeDateChanged(event): void {
        if (event != null) {
            if (this._InPatientPhysicianApplication != null &&
                this._InPatientPhysicianApplication.InPatientTreatmentClinicApp != null && this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicDischargeDate != event) {
                this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicDischargeDate = event;
            }
        }
    }

    public onInpatientProtocolNoChanged(event): void {
        if (event != null) {
            if (this._InPatientPhysicianApplication != null &&
                this._InPatientPhysicianApplication.InPatientTreatmentClinicApp != null && this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.ProtocolNo != event) {
                this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.ProtocolNo = event;
            }
        }
    }

    public onMasterResourceChanged(event): void {
        if (event != null) {
            if (this._InPatientPhysicianApplication != null &&
                this._InPatientPhysicianApplication.InPatientTreatmentClinicApp != null && this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.MasterResource != event) {
                this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.MasterResource = event;
            }
        }
    }

    public onReasonForInpatientAdmissionChanged(event): void {
        if (event != null) {
            if (this._InPatientPhysicianApplication != null &&
                this._InPatientPhysicianApplication.InPatientTreatmentClinicApp != null &&
                this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission != null && this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.ReasonForInpatientAdmission != event) {
                this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.ReasonForInpatientAdmission = event;
            }
        }
    }

    public onResponsibleDoctorChanged(event): void {
        if (event != null) {
            if (this._InPatientPhysicianApplication != null &&
                this._InPatientPhysicianApplication.InPatientTreatmentClinicApp != null && this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.ProcedureDoctor != event) {
                this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.ProcedureDoctor = event;
            }
        }
    }

    public onResponsibleNurseChanged(event): void {
        if (event != null) {
            if (this._InPatientPhysicianApplication != null &&
                this._InPatientPhysicianApplication.InPatientTreatmentClinicApp != null && this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.ResponsibleNurse != event) {
                this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.ResponsibleNurse = event;
            }
        }
    }

    public onRoomChanged(event): void {
        if (event != null) {
            if (this._InPatientPhysicianApplication != null &&
                this._InPatientPhysicianApplication.InPatientTreatmentClinicApp != null &&
                this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission != null && this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.Room != event) {
                this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.Room = event;
            }
        }
    }

    public onHCModeOfPaymentChanged(event): void {

        if (this.inPatientPhysicianApplicationFormViewModel != event) {
            this.inPatientPhysicianApplicationFormViewModel.HCModeOfPayment = event;
        }

    }

    public onRoomGroupChanged(event): void {
        if (event != null) {
            if (this._InPatientPhysicianApplication != null &&
                this._InPatientPhysicianApplication.InPatientTreatmentClinicApp != null &&
                this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission != null && this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.RoomGroup != event) {
                this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission.RoomGroup = event;
            }
        }
    }

    public onrtfComplaintChanged(event): void {
        if (event != null) {
            if (this._InPatientPhysicianApplication != null && this._InPatientPhysicianApplication.Complaint != event) {
                this._InPatientPhysicianApplication.Complaint = event;
            }
        }
    }

    public onrtfHistoryChanged(event): void {
        if (event != null) {
            if (this._InPatientPhysicianApplication != null && this._InPatientPhysicianApplication.PatientHistory != event) {
                this._InPatientPhysicianApplication.PatientHistory = event;
            }
        }
    }

    public onrtfPhysicalExaminationChanged(event): void {
        if (event != null) {
            if (this._InPatientPhysicianApplication != null && this._InPatientPhysicianApplication.PhysicalExamination != event) {
                this._InPatientPhysicianApplication.PhysicalExamination = event;
            }
        }
    }
    public onInpatientObservationEndTimeChanged(event): void {
        if (event != null) {
            if (this._InPatientPhysicianApplication != null &&
                this._InPatientPhysicianApplication.EmergencyIntervention != null && this._InPatientPhysicianApplication.EmergencyIntervention.DischargeTime != event) {
                this._InPatientPhysicianApplication.EmergencyIntervention.DischargeTime = event;
            }
        }
    }

    public onInpatientObservationTimeChanged(event): void {
        if (event != null) {
            if (this._InPatientPhysicianApplication != null &&
                this._InPatientPhysicianApplication.EmergencyIntervention != null && this._InPatientPhysicianApplication.EmergencyIntervention.InpatientObservationTime != event) {
                this._InPatientPhysicianApplication.EmergencyIntervention.InpatientObservationTime = event;
            }
        }
    }
    public onProgressDescriptionChanged(event): void {
        if (event != null) {
            if (this.inPatientPhysicianApplicationFormViewModel != null && this.inPatientPhysicianApplicationFormViewModel.ProgressDescription != event) {
                this.inPatientPhysicianApplicationFormViewModel.ProgressDescription = event;
            }
        }
    }

    public onProgressTableDescriptionChanged(progres: InPatientPhysicianProgresses, event): void {
        if (event != null) {
            if (progres.Description != event) {
                progres.Description = event;
            }
        }
    }

    public onInPatientRtfBySpecialitiesChanged(rtf: InPatientRtfBySpeciality, event): void {
        if (event != null) {
            if (rtf.Rtf != event) {
                rtf.Rtf = event;
            }
        } else {
            rtf.Rtf = "";
        }
    }

    public onttdatetimepicker1Changed(event): void {
        if (event != null) {
            if (this.inPatientPhysicianApplicationFormViewModel.ProgressDate != event) {
                this.inPatientPhysicianApplicationFormViewModel.ProgressDate = event;
            }
        }
    }

    public onStartPhysiotherapyRequestChanged(event): void {
        if (event != null) {
            if (this._InPatientPhysicianApplication != null && this.StartPhysiotherapyRequest.Value !== event) {
                this.StartPhysiotherapyRequest.Value = event;
            }
            if (this._InPatientPhysicianApplication != null && this.inPatientPhysicianApplicationFormViewModel.StartPhysiotherapyRequest !== event) {
                this.inPatientPhysicianApplicationFormViewModel.StartPhysiotherapyRequest = event;
            }
        }
    }


    public onVentilatorStatusChanged(event): void {
        if (this._InPatientPhysicianApplication != null && this._InPatientPhysicianApplication.VentilatorStatus != event) {
            this._InPatientPhysicianApplication.VentilatorStatus = event;
        }
    }

    public async onIsPandemicChanged(event): Promise<void> {
        if (this._InPatientPhysicianApplication != null && this._InPatientPhysicianApplication.IsPandemic != event) {
            if (event == YesNoEnum.Yes) {
                let covidDiagnode = this.inPatientPhysicianApplicationFormViewModel.GridDiagnosisGridList.find(c => c.Diagnose.Code_Shadow == "U07.3");//mevcutta olan Covid19 tanısı
                if (covidDiagnode == null && (this.inPatientPhysicianApplicationFormViewModel.IsIntensiveCare == false || this.inPatientPhysicianApplicationFormViewModel.IsIntensiveCare == null)) {//yoğun bakım olmayan hastalarda tanı kontrolü yapılacak
                    let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M21498", "Pandemi olgusu U07.3 tanısı!"), "Hasta tanısında U07.3 tanısı bulunması zorunludur, tanı girişi yapılsın mı?");
                    if (messageResult === "E") {
                        this._InPatientPhysicianApplication.IsPandemic = event;
                        if (this.inPatientPhysicianApplicationFormViewModel.CovidDiagnose != null) {
                            this.inPatientPhysicianApplicationFormViewModel.GridDiagnosisGridList.push(this.inPatientPhysicianApplicationFormViewModel.CovidDiagnose);
                        }
                    } else {
                        this.messageService.showError("Pandemi olgusu U07.3 tanısı eklemeden pandemi olgusunu kayıt edemezsiniz!");
                        return;
                    }
                }
                else if (this.inPatientPhysicianApplicationFormViewModel.IsIntensiveCare == true || covidDiagnode != null) {//ekranda mevcut tanı varsa veya yoğun bakım hastası ise tanı kontrolü olmayacak
                    this._InPatientPhysicianApplication.IsPandemic = event;
                }
            } else {
                this._InPatientPhysicianApplication.IsPandemic = event;
            }
        }
    }

    protected redirectProperties(): void {
        redirectProperty(this.InpatientProtocolNo, "Text", this.__ttObject, "InPatientTreatmentClinicApp.ProtocolNo");
        redirectProperty(this.ClinicDischargeDate, "Value", this.__ttObject, "InPatientTreatmentClinicApp.ClinicDischargeDate");
        redirectProperty(this.rtfComplaint, "Rtf", this.__ttObject, "Complaint");
        redirectProperty(this.rtfHistory, "Rtf", this.__ttObject, "PatientHistory");
        redirectProperty(this.rtfPhysicalExamination, "Rtf", this.__ttObject, "PhysicalExamination");
        redirectProperty(this.ReasonForInpatientAdmission, "Text", this.__ttObject, "InPatientTreatmentClinicApp.BaseInpatientAdmission.ReasonForInpatientAdmission");
        redirectProperty(this.InpatientObservationTime, "Value", this.__ttObject, "EmergencyIntervention.InpatientObservationTime");
        redirectProperty(this.InpatientObservationEndTime, "Value", this.__ttObject, "EmergencyIntervention.DischargeTime");
        redirectProperty(this.HCModeOfPayment, "Value", this.__ttObject, "HCModeOfPayment");
        redirectProperty(this.IsPandemic, "Value", this.__ttObject, "IsPandemic");
    }

    public initFormControls(): void {


        this.VentilatorStatus = new TTVisual.TTObjectListBox();
        this.VentilatorStatus.ListDefName = "SKRSDurumList";
        this.VentilatorStatus.Name = "VentilatorStatus";
        this.VentilatorStatus.TabIndex = 2;
        this.VentilatorStatus.Required = true;

        this.IsPandemic = new TTVisual.TTEnumComboBox();
        this.IsPandemic.DataTypeName = "YesNoEnum";
        this.IsPandemic.Name = "IsPandemic";
        this.IsPandemic.TabIndex = 216;

        this.ReportSelectedDoctorCombo = new TTVisual.TTObjectListBox();
        this.ReportSelectedDoctorCombo.ListDefName = "DoctorListDefinition";
        this.ReportSelectedDoctorCombo.Name = "ReportSelectedDoctorCombo";
        this.ReportSelectedDoctorCombo.TabIndex = 30;

        this.StartPhysiotherapyRequest = new TTVisual.TTCheckBox();
        this.StartPhysiotherapyRequest.Value = false;
        this.StartPhysiotherapyRequest.Text = i18n("M14073", "F.T.R. İstek");
        this.StartPhysiotherapyRequest.Title = i18n("M14073", "F.T.R. İstek");
        this.StartPhysiotherapyRequest.Name = 'StartPhysiotherapyRequest';
        this.StartPhysiotherapyRequest.ReadOnly = false;
        this.StartPhysiotherapyRequest.TabIndex = 184;


        this.InpatientObservationEndTime = new TTVisual.TTDateTimePicker();
        this.InpatientObservationEndTime.Format = DateTimePickerFormat.Long;
        this.InpatientObservationEndTime.Name = "InpatientObservationEndTime";
        this.InpatientObservationEndTime.TabIndex = 215;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M19368", "Müşahede Bitiş");
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 214;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "Müşahedeye Alınış";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 213;

        this.InpatientObservationTime = new TTVisual.TTDateTimePicker();
        this.InpatientObservationTime.Format = DateTimePickerFormat.Long;
        this.InpatientObservationTime.Name = "InpatientObservationTime";
        this.InpatientObservationTime.TabIndex = 212;

        this.DietOrders = new TTVisual.TTGrid();
        this.DietOrders.Name = "DietOrders";
        this.DietOrders.TabIndex = 211;

        this.DietRPT = new TTVisual.TTButtonColumn();
        this.DietRPT.Text = i18n("M13051", "Diyet Tekrarla");
        this.DietRPT.DisplayIndex = 0;
        this.DietRPT.HeaderText = i18n("M13051", "Diyet Tekrarla");
        this.DietRPT.Name = "DietRPT";
        this.DietRPT.ToolTipText = i18n("M13051", "Diyet Tekrarla");
        //this.DietRPT.Clicked = this.ismail;

        this.DietChange = new TTVisual.TTButtonColumn();
        this.DietChange.Text = "Diyet Değiştir";
        this.DietChange.DisplayIndex = 1;
        this.DietChange.HeaderText = "Diyet Değiştir";
        this.DietChange.Name = "DietChange";
        this.DietChange.ToolTipText = "Diyet Değiştir";
        this.DietChange.Clicked = this.ismail;
        this.DietChange.ComponentReference = this;
        // this.DietRPT.Width = 90;

        //this.ProcedureObjectDietOrder = new TTVisual.TTListBoxColumn();
        //this.ProcedureObjectDietOrder.AllowMultiSelect = false;
        //this.ProcedureObjectDietOrder.ListDefName = "DietListDefinition";
        //this.ProcedureObjectDietOrder.DataMember = "ProcedureObject";
        //this.ProcedureObjectDietOrder.DisplayIndex = 1;
        //this.ProcedureObjectDietOrder.HeaderText = i18n("M13054", "Diyet Türü");
        //this.ProcedureObjectDietOrder.Name = "ProcedureObjectDietOrder";
        ////this.ProcedureObjectDietOrder.Width = 200;
        //this.ProcedureObjectDietOrder.ReadOnly = true;
        //this.ProcedureObjectDietOrder.Enabled = false;

        this.ProcedureObjectDietOrder = new TTVisual.TTTextBoxColumn();
        this.ProcedureObjectDietOrder.DataMember = "ProcedureObject.Name";
        this.ProcedureObjectDietOrder.DisplayIndex = 1;
        this.ProcedureObjectDietOrder.HeaderText = i18n("M13054", "Diyet Türü");
        this.ProcedureObjectDietOrder.Name = "ProcedureObjectDietOrder";
        this.ProcedureObjectDietOrder.ReadOnly = true;
        this.ProcedureObjectDietOrder.Enabled = false;

        this.PeriodStartTimeDietOrder = new TTVisual.TTDateTimePickerColumn();
        this.PeriodStartTimeDietOrder.DataMember = "PeriodStartTime";
        this.PeriodStartTimeDietOrder.DisplayIndex = 1;
        this.PeriodStartTimeDietOrder.Min = this.currentDate;
        this.PeriodStartTimeDietOrder.Format = DateTimePickerFormat.Short;
        this.PeriodStartTimeDietOrder.HeaderText = i18n("M11637", "Başlangıç Tarihi");
        this.PeriodStartTimeDietOrder.Name = "PeriodStartTimeDietOrder";
        this.PeriodStartTimeDietOrder.EnabledBindingPath = "_isNew";
        // this.PeriodStartTimeDietOrder.Width = 150;

        this.RecurrenceDayAmountDietOrder = new TTVisual.TTTextBoxColumn();
        this.RecurrenceDayAmountDietOrder.DataMember = "RecurrenceDayAmount";
        this.RecurrenceDayAmountDietOrder.DisplayIndex = 2;
        this.RecurrenceDayAmountDietOrder.HeaderText = i18n("M14998", "Gün");
        this.RecurrenceDayAmountDietOrder.Name = "RecurrenceDayAmountDietOrder";
        this.RecurrenceDayAmountDietOrder.EnabledBindingPath = "_isNew";
        // this.RecurrenceDayAmountDietOrder.Width = 30;

        this.PeriodEndTimeDietOrder = new TTVisual.TTDateTimePickerColumn();
        this.PeriodEndTimeDietOrder.DataMember = "PeriodEndTime";
        this.PeriodEndTimeDietOrder.Format = DateTimePickerFormat.Short;
        this.PeriodEndTimeDietOrder.DisplayIndex = 3;
        this.PeriodEndTimeDietOrder.HeaderText = i18n("M11939", "Bitiş Tarihi");
        this.PeriodEndTimeDietOrder.Name = "PeriodEndTimeDietOrder";
        this.PeriodEndTimeDietOrder.ReadOnly = true;
        // this.PeriodEndTimeDietOrder.Width = 125;

        this.OrderDescriptionDietOrder = new TTVisual.TTMaskedTextBoxColumn();
        this.OrderDescriptionDietOrder.DataMember = "OrderDescription";
        this.OrderDescriptionDietOrder.DisplayIndex = 4;
        this.OrderDescriptionDietOrder.HeaderText = i18n("M22698", "Diyet Açıklaması");
        this.OrderDescriptionDietOrder.Name = "OrderDescriptionDietOrder";
        this.OrderDescriptionDietOrder.EnabledBindingPath = "_isNew";
        //this.OrderDescriptionDietOrder.Width = 150;

        this.AmountForPeriodDietOrder = new TTVisual.TTTextBoxColumn();
        this.AmountForPeriodDietOrder.DataMember = "AmountForPeriod";
        this.AmountForPeriodDietOrder.DisplayIndex = 5;
        this.AmountForPeriodDietOrder.HeaderText = i18n("M23744", "Uyg. Miktarı");
        this.AmountForPeriodDietOrder.Name = "AmountForPeriodDietOrder";
        this.AmountForPeriodDietOrder.Visible = false;
        this.AmountForPeriodDietOrder.EnabledBindingPath = "_isNew";
        // this.AmountForPeriodDietOrder.Width = 50;

        this.FrequencyDietOrder = new TTVisual.TTEnumComboBoxColumn();
        this.FrequencyDietOrder.DataMember = "Frequency";
        this.FrequencyDietOrder.DisplayIndex = 6;
        this.FrequencyDietOrder.HeaderText = i18n("M23742", "Uyg. Aralığı");
        this.FrequencyDietOrder.Name = "FrequencyDietOrder";
        this.FrequencyDietOrder.Visible = false;
        this.FrequencyDietOrder.EnabledBindingPath = "_isNew";
        /// this.FrequencyDietOrder.Width = 125;

        this.Breakfast = new TTVisual.TTCheckBoxColumn();
        this.Breakfast.DataMember = "MealType.Breakfast";
        this.Breakfast.DisplayIndex = 7;
        this.Breakfast.HeaderText = "K";
        this.Breakfast.Name = "Breakfast";
        this.Breakfast.Width = 30;
        this.Breakfast.EnabledBindingPath = "_isNew";

        this.Dinner = new TTVisual.TTCheckBoxColumn();
        this.Dinner.DataMember = "MealType.Dinner";
        this.Dinner.DisplayIndex = 8;
        this.Dinner.HeaderText = "A";
        this.Dinner.Name = "Dinner";
        this.Dinner.EnabledBindingPath = "_isNew";
        this.Dinner.Width = 30;

        this.Lunch = new TTVisual.TTCheckBoxColumn();
        this.Lunch.DataMember = "MealType.Lunch";
        this.Lunch.DisplayIndex = 9;
        this.Lunch.HeaderText = "Ö";
        this.Lunch.Name = "Lunch";
        this.Lunch.EnabledBindingPath = "_isNew";
        this.Lunch.Width = 30;

        this.NightBreakfast = new TTVisual.TTCheckBoxColumn();
        this.NightBreakfast.DataMember = "MealType.NightBreakfast";
        this.NightBreakfast.DisplayIndex = 10;
        this.NightBreakfast.HeaderText = "G.K.";
        this.NightBreakfast.Name = "NightBreakfast";
        this.NightBreakfast.EnabledBindingPath = "_isNew";
        this.NightBreakfast.Width = 40;

        this.Snack1 = new TTVisual.TTCheckBoxColumn();
        this.Snack1.DataMember = "MealType.Snack1";
        this.Snack1.DisplayIndex = 11;
        this.Snack1.HeaderText = "A.Ö. 1";
        this.Snack1.Name = "Snack1";
        this.Snack1.EnabledBindingPath = "_isNew";
        this.Snack1.Width = 50;

        this.Snack2 = new TTVisual.TTCheckBoxColumn();
        this.Snack2.DataMember = "MealType.Snack2";
        this.Snack2.DisplayIndex = 12;
        this.Snack2.HeaderText = "A.Ö. 2";
        this.Snack2.Name = "Snack2";
        this.Snack2.EnabledBindingPath = "_isNew";
        this.Snack2.Width = 50;

        this.Snack3 = new TTVisual.TTCheckBoxColumn();
        this.Snack3.DataMember = "MealType.Snack3";
        this.Snack3.DisplayIndex = 13;
        this.Snack3.HeaderText = "A.Ö. 3";
        this.Snack3.Name = "Snack3";
        this.Snack3.EnabledBindingPath = "_isNew";
        this.Snack3.Width = 50;

        this.InPatientRtfBySpecialities = new TTVisual.TTGrid();
        this.InPatientRtfBySpecialities.Name = "InPatientRtfBySpecialities";
        this.InPatientRtfBySpecialities.TabIndex = 210;

        this.TitleInPatientRtfBySpeciality = new TTVisual.TTTextBoxColumn();
        this.TitleInPatientRtfBySpeciality.DataMember = "Title";
        this.TitleInPatientRtfBySpeciality.DisplayIndex = 0;
        this.TitleInPatientRtfBySpeciality.HeaderText = i18n("M11646", "Başlık");
        this.TitleInPatientRtfBySpeciality.MinimumWidth = 100;
        this.TitleInPatientRtfBySpeciality.Name = "TitleInPatientRtfBySpeciality";
        this.TitleInPatientRtfBySpeciality.Width = 100;

        this.RtfInPatientRtfBySpeciality = new TTVisual.TTTextBoxColumn();
        this.RtfInPatientRtfBySpeciality.DataMember = "Rtf";
        this.RtfInPatientRtfBySpeciality.DisplayIndex = 1;
        this.RtfInPatientRtfBySpeciality.HeaderText = i18n("M18946", "Metin Alanı");
        this.RtfInPatientRtfBySpeciality.Name = "RtfInPatientRtfBySpeciality";
        this.RtfInPatientRtfBySpeciality.Width = 300;

        this.InpatientProtocolNo = new TTVisual.TTTextBox();
        this.InpatientProtocolNo.BackColor = "#F0F0F0";
        this.InpatientProtocolNo.ReadOnly = true;
        this.InpatientProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.InpatientProtocolNo.Name = "InpatientProtocolNo";
        this.InpatientProtocolNo.TabIndex = 3;

        this.ReasonForInpatientAdmission = new TTVisual.TTTextBox();
        this.ReasonForInpatientAdmission.Multiline = true;
        this.ReasonForInpatientAdmission.Name = "ReasonForInpatientAdmission";
        this.ReasonForInpatientAdmission.TabIndex = 0;

        this.Progresses = new TTVisual.TTGrid();
        this.Progresses.Name = "Progresses";
        this.Progresses.TabIndex = 209;

        this.ProgressDateInPatientPhysicianProgresses = new TTVisual.TTDateTimePickerColumn();
        this.ProgressDateInPatientPhysicianProgresses.Format = DateTimePickerFormat.Custom;
        this.ProgressDateInPatientPhysicianProgresses.CustomFormat = "dd/MM/yyyy HH:mm";
        this.ProgressDateInPatientPhysicianProgresses.DataMember = "ProgressDate";
        this.ProgressDateInPatientPhysicianProgresses.DisplayIndex = 0;
        this.ProgressDateInPatientPhysicianProgresses.HeaderText = "Tarih/Saat";
        this.ProgressDateInPatientPhysicianProgresses.Name = "ProgressDateInPatientPhysicianProgresses";
        this.ProgressDateInPatientPhysicianProgresses.Width = 180;

        this.ProcedureDoctorInPatientPhysicianProgresses = new TTVisual.TTListBoxColumn();
        this.ProcedureDoctorInPatientPhysicianProgresses.ListDefName = "ResUserDefinitionList";
        this.ProcedureDoctorInPatientPhysicianProgresses.DataMember = "ProcedureDoctor";
        this.ProcedureDoctorInPatientPhysicianProgresses.DisplayIndex = 1;
        this.ProcedureDoctorInPatientPhysicianProgresses.HeaderText = i18n("M16928", "İşlemi Yapan Doktor");
        this.ProcedureDoctorInPatientPhysicianProgresses.Name = "ProcedureDoctorInPatientPhysicianProgresses";
        this.ProcedureDoctorInPatientPhysicianProgresses.Width = 300;

        this.DescriptionInPatientPhysicianProgressesRch = new TTVisual.TTRichTextBoxControlColumn();
        this.DescriptionInPatientPhysicianProgressesRch.DisplayIndex = 2;
        this.DescriptionInPatientPhysicianProgressesRch.HeaderText = "Klinik seyir";
        this.DescriptionInPatientPhysicianProgressesRch.Name = "DescriptionInPatientPhysicianProgressesRch";
        this.DescriptionInPatientPhysicianProgressesRch.Width = 100;

        this.GridDiagnosis = new TTVisual.TTGrid();
        this.GridDiagnosis.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridDiagnosis.Text = i18n("M22736", "Tanı");
        this.GridDiagnosis.Name = "GridDiagnosis";
        this.GridDiagnosis.TabIndex = 4;

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

        this.MasterResource = new TTVisual.TTObjectListBox();
        this.MasterResource.ReadOnly = true;
        this.MasterResource.Enabled = false;
        this.MasterResource.ListDefName = "ClinicListDefinition";
        this.MasterResource.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MasterResource.Name = "MasterResource";
        this.MasterResource.TabIndex = 8;

        this.labelInpatientDepartment = new TTVisual.TTLabel();
        this.labelInpatientDepartment.Text = i18n("M15485", "Hastanın Tedavi Gördüğü Klinik");
        this.labelInpatientDepartment.BackColor = "#DCDCDC";
        this.labelInpatientDepartment.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelInpatientDepartment.ForeColor = "#000000";
        this.labelInpatientDepartment.Name = "labelInpatientDepartment";
        this.labelInpatientDepartment.TabIndex = 208;

        this.cmbReportType = new TTVisual.TTEnumComboBox();
        this.cmbReportType.DataTypeName = 'ReportTypeEnum';
        this.cmbReportType.Name = 'cmbReportType';
        this.cmbReportType.TabIndex = 3;
        this.cmbReportType.ShowClearButton = true;

        this.labelRoom = new TTVisual.TTLabel();
        this.labelRoom.Text = i18n("M19602", "Oda");
        this.labelRoom.BackColor = "#DCDCDC";
        this.labelRoom.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelRoom.ForeColor = "#000000";
        this.labelRoom.Name = "labelRoom";
        this.labelRoom.TabIndex = 200;

        this.Bed = new TTVisual.TTObjectListBox();
        this.Bed.LinkedControlName = "Room";
        this.Bed.ReadOnly = true;
        this.Bed.Enabled = false;
        this.Bed.ListFilterExpression = "UsedByBedProcedure is Null";
        this.Bed.ListDefName = "BedListDefinition";
        this.Bed.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Bed.Name = "Bed";
        this.Bed.TabIndex = 11;

        this.RoomGroup = new TTVisual.TTObjectListBox();
        this.RoomGroup.LinkedControlName = "PhysicalStateClinic";
        this.RoomGroup.ReadOnly = true;
        this.RoomGroup.Enabled = false;
        this.RoomGroup.ListDefName = "RoomGroupListDefinition";
        this.RoomGroup.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RoomGroup.Name = "RoomGroup";
        this.RoomGroup.TabIndex = 9;

        this.labelRoomGroup = new TTVisual.TTLabel();
        this.labelRoomGroup.Text = i18n("M19605", "Oda Grubu");
        this.labelRoomGroup.BackColor = "#DCDCDC";
        this.labelRoomGroup.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelRoomGroup.ForeColor = "#000000";
        this.labelRoomGroup.Name = "labelRoomGroup";
        this.labelRoomGroup.TabIndex = 202;

        this.Room = new TTVisual.TTObjectListBox();
        this.Room.LinkedControlName = "RoomGroup";
        this.Room.ReadOnly = true;
        this.Room.Enabled = false;
        this.Room.ListDefName = "RoomListDefinition";
        this.Room.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Room.Name = "Room";
        this.Room.TabIndex = 10;

        this.labelBed = new TTVisual.TTLabel();
        this.labelBed.Text = i18n("M24353", "Yatak");
        this.labelBed.BackColor = "#DCDCDC";
        this.labelBed.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelBed.ForeColor = "#000000";
        this.labelBed.Name = "labelBed";
        this.labelBed.TabIndex = 198;

        this.ClinicDischargeDate = new TTVisual.TTDateTimePicker();
        this.ClinicDischargeDate.BackColor = "#F0F0F0";
        this.ClinicDischargeDate.CustomFormat = "";
        this.ClinicDischargeDate.Format = DateTimePickerFormat.Short;
        this.ClinicDischargeDate.Enabled = false;
        this.ClinicDischargeDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ClinicDischargeDate.Name = "ClinicDischargeDate";
        this.ClinicDischargeDate.TabIndex = 13;
        this.ClinicDischargeDate.Visible = false;

        this.labelClinicDischargeDate = new TTVisual.TTLabel();
        this.labelClinicDischargeDate.Text = i18n("M17657", "Klinik Taburcu Tarihi");
        this.labelClinicDischargeDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelClinicDischargeDate.ForeColor = "#000000";
        this.labelClinicDischargeDate.Name = "labelClinicDischargeDate";
        this.labelClinicDischargeDate.TabIndex = 100;
        this.labelClinicDischargeDate.Visible = false;

        this.labelProtocolNo = new TTVisual.TTLabel();
        this.labelProtocolNo.Text = i18n("M17649", "Klinik Protokol No");
        this.labelProtocolNo.BackColor = "#DCDCDC";
        this.labelProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProtocolNo.ForeColor = "#000000";
        this.labelProtocolNo.Name = "labelProtocolNo";
        this.labelProtocolNo.TabIndex = 8;

        this.rtfComplaint = new TTVisual.TTRichTextBoxControl();
        this.rtfComplaint.DisplayText = i18n("M22483", "Şikayet");
        this.rtfComplaint.TemplateGroupName = i18n("M19221", "Muayene Şikayet");
        this.rtfComplaint.BackColor = "#FFFFFF";
        this.rtfComplaint.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.rtfComplaint.Name = "rtfComplaint";
        this.rtfComplaint.TabIndex = 0;

        this.rtfHistory = new TTVisual.TTRichTextBoxControl();
        this.rtfHistory.DisplayText = i18n("M20117", "Özgeçmiş");
        this.rtfHistory.TemplateGroupName = i18n("M19209", "Muayene Özgeçmiş");
        this.rtfHistory.BackColor = "#FFFFFF";
        this.rtfHistory.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.rtfHistory.Name = "rtfHistory";
        this.rtfHistory.TabIndex = 1;

        this.rtfPhysicalExamination = new TTVisual.TTRichTextBoxControl();
        this.rtfPhysicalExamination.DisplayText = i18n("M19173", "Muayene Bulguları");
        this.rtfPhysicalExamination.TemplateGroupName = i18n("M19186", "Muayene Fizik");
        this.rtfPhysicalExamination.BackColor = "#FFFFFF";
        this.rtfPhysicalExamination.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.rtfPhysicalExamination.Name = "rtfPhysicalExamination";
        this.rtfPhysicalExamination.TabIndex = 2;

        this.ProgressDescription = new TTVisual.TTRichTextBoxControl();
        this.ProgressDescription.DisplayText = "Klinik Seyir";
        this.ProgressDescription.TemplateGroupName = "Klinik Seyir";
        this.ProgressDescription.BackColor = "#FFFFFF";
        this.ProgressDescription.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProgressDescription.Name = "ProgressDescription";
        this.ProgressDescription.TabIndex = 0;

        this.labelReasonForInpatientAdmission = new TTVisual.TTLabel();
        this.labelReasonForInpatientAdmission.Text = i18n("M24420", "Yatırılma Nedeni");
        this.labelReasonForInpatientAdmission.BackColor = "#DCDCDC";
        this.labelReasonForInpatientAdmission.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelReasonForInpatientAdmission.ForeColor = "#000000";
        this.labelReasonForInpatientAdmission.Name = "labelReasonForInpatientAdmission";
        this.labelReasonForInpatientAdmission.TabIndex = 8;

        this.NursingOrderGrid = new TTVisual.TTGrid();
        this.NursingOrderGrid.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.NursingOrderGrid.Name = "NursingOrderGrid";
        this.NursingOrderGrid.TabIndex = 0;

        this.RPT = new TTVisual.TTButtonColumn();
        this.RPT.Text = i18n("M22700", "Talimat Tekrarla");
        this.RPT.UseColumnTextForButtonValue = true;
        this.RPT.DisplayIndex = 0;
        this.RPT.HeaderText = i18n("M22700", "Talimat Tekrarla");
        this.RPT.Name = "RPT";
        this.RPT.Height = "25px";
        this.RPT.Width = "125px";
        //this.RPT.Width = 100;

        this.showDetail = new TTVisual.TTButtonColumn();
        this.showDetail.Text = "Zaman Çizelgesi";
        this.showDetail.UseColumnTextForButtonValue = true;
        this.showDetail.DisplayIndex = 0;
        this.showDetail.HeaderText = "Zaman Çizelgesi"
        this.showDetail.Name = "showDetail";
        this.showDetail.Height = "25px";
        this.showDetail.Width = "125px";
        this.showDetail.Type = "success";

        //this.nProcedureObject = new TTVisual.TTListBoxColumn();
        //this.nProcedureObject.AllowMultiSelect = true;
        //this.nProcedureObject.ListDefName = "VitalSignAndNursingListDefinition";
        //this.nProcedureObject.DataMember = "ProcedureObject";
        //this.nProcedureObject.DisplayIndex = 1;
        //this.nProcedureObject.HeaderText = i18n("M24169", "Vital Bulgu ve Hemşirelik İşlemleri");
        //this.nProcedureObject.Name = "nProcedureObject";
        ////this.nProcedureObject.Width = 200;
        ////this.nProcedureObject.MinimumWidth = 200;
        //this.nProcedureObject.EnabledBindingPath = "_isNew";
        //this.nProcedureObject.ReadOnly = true;
        //this.nProcedureObject.Enabled = false;

        this.nProcedureObject = new TTVisual.TTTextBoxColumn();
        this.nProcedureObject.DataMember = "ProcedureObject.Name";
        this.nProcedureObject.DisplayIndex = 1;
        this.nProcedureObject.HeaderText = i18n("M24169", "Vital Bulgu ve Hemşirelik İşlemleri");
        this.nProcedureObject.Name = "nProcedureObject";
        this.nProcedureObject.EnabledBindingPath = "_isNew";
        this.nProcedureObject.ReadOnly = true;
        this.nProcedureObject.Enabled = false;
        //this.nAmountForPeriod.Width = 80;


        this.nPeriodStartTime = new TTVisual.TTDateTimePickerColumn();
        this.nPeriodStartTime.Format = DateTimePickerFormat.Long;
        //this.nPeriodStartTime.CustomFormat = "dd/MM/yyyy HH:mm";
        this.nPeriodStartTime.DataMember = "PeriodStartTime";
        this.nPeriodStartTime.DisplayIndex = 2;
        this.nPeriodStartTime.HeaderText = i18n("M22699", "Talimat Başlama Zamanı");
        this.nPeriodStartTime.Name = "nPeriodStartTime";
        this.nPeriodStartTime.EnabledBindingPath = "_isNew";
        // this.nPeriodStartTime.Width = 180;

        this.nFrequency = new TTVisual.TTEnumComboBoxColumn();
        this.nFrequency.DataTypeName = "FrequencyEnum";
        this.nFrequency.DataMember = "Frequency";
        this.nFrequency.DisplayIndex = 3;
        this.nFrequency.HeaderText = i18n("M23742", "Uyg. Aralığı");
        this.nFrequency.Name = "nFrequency";
        this.nFrequency.EnabledBindingPath = "_isNew";
        //this.nFrequency.Width = 125;

        this.nAmountForPeriod = new TTVisual.TTTextBoxColumn();
        this.nAmountForPeriod.DataMember = "AmountForPeriod";
        this.nAmountForPeriod.DisplayIndex = 4;
        this.nAmountForPeriod.HeaderText = i18n("M23744", "Uyg. Miktarı");
        this.nAmountForPeriod.Name = "nAmountForPeriod";
        this.nAmountForPeriod.EnabledBindingPath = "_isNew";
        // this.nAmountForPeriod.IsNumeric=true;
        //this.nAmountForPeriod.Width = 80;

        this.nRecurrenceDayAmount = new TTVisual.TTTextBoxColumn();
        this.nRecurrenceDayAmount.DataMember = "RecurrenceDayAmount";
        this.nRecurrenceDayAmount.DisplayIndex = 5;
        this.nRecurrenceDayAmount.HeaderText = i18n("M14998", "Gün ");
        this.nRecurrenceDayAmount.Name = "nRecurrenceDayAmount";
        this.nRecurrenceDayAmount.EnabledBindingPath = "_isNew";
        // this.nRecurrenceDayAmount.Width = 50;

        this.nOrderDescription = new TTVisual.TTMaskedTextBoxColumn();
        this.nOrderDescription.DataMember = "OrderDescription";
        this.nOrderDescription.DisplayIndex = 6;
        this.nOrderDescription.HeaderText = i18n("M19734", "Order Açıklama");
        this.nOrderDescription.MinimumWidth = 100;
        this.nOrderDescription.Name = "nOrderDescription";
        this.nOrderDescription.EnabledBindingPath = "_isNew";
        // this.nOrderDescription.IsNumeric=false;
        //this.nOrderDescription.Width = 150;


        this.GridTreatmentMaterials = new TTVisual.TTGrid();
        this.GridTreatmentMaterials.Name = "GridTreatmentMaterials";
        this.GridTreatmentMaterials.TabIndex = 0;

        this.TreatmentMaterialActionDate = new TTVisual.TTDateTimePickerColumn();
        this.TreatmentMaterialActionDate.Format = DateTimePickerFormat.Custom;
        this.TreatmentMaterialActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.TreatmentMaterialActionDate.DataMember = "ActionDate";
        this.TreatmentMaterialActionDate.DisplayIndex = 0;
        this.TreatmentMaterialActionDate.HeaderText = "Tarih/Saat";
        this.TreatmentMaterialActionDate.Name = "TreatmentMaterialActionDate";
        this.TreatmentMaterialActionDate.ReadOnly = true;
        this.TreatmentMaterialActionDate.Width = 180;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.ListDefName = "ConsumableMaterialAndDrugList";
        this.Material.DataMember = "Material";
        this.Material.DisplayIndex = 1;
        this.Material.HeaderText = i18n("M21326", "Sarf Malzeme");
        this.Material.Name = "Material";
        this.Material.Width = 325;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Barcode";
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = "Barkodu";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 100;

        this.UBBCode = new TTVisual.TTTextBoxColumn();
        this.UBBCode.DataMember = "UBBCode";
        this.UBBCode.DisplayIndex = 3;
        this.UBBCode.HeaderText = i18n("M23689", "UBB Kodu");
        this.UBBCode.Name = "UBBCode";
        this.UBBCode.Width = 100;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 4;
        this.Amount.HeaderText = i18n("M19030", "Miktar");
        this.Amount.Name = "Amount";
        this.Amount.Width = 100;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "DistributionType";
        this.DistributionType.DisplayIndex = 5;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 100;

        this.OzelDurum = new TTVisual.TTListBoxColumn();
        this.OzelDurum.ListDefName = "OzelDurumListDefinition";
        this.OzelDurum.DataMember = "OzelDurum";
        this.OzelDurum.DisplayIndex = 6;
        this.OzelDurum.HeaderText = i18n("M20080", "Özel Durum");
        this.OzelDurum.Name = "OzelDurum";
        this.OzelDurum.Width = 100;

        this.Notes = new TTVisual.TTTextBoxColumn();
        this.Notes.DataMember = "Note";
        this.Notes.DisplayIndex = 7;
        this.Notes.HeaderText = i18n("M19485", "Notlar");
        this.Notes.Name = "Notes";
        this.Notes.Width = 100;

        this.CokluOzelDurum = new TTVisual.TTButtonColumn();
        this.CokluOzelDurum.DisplayIndex = 8;
        this.CokluOzelDurum.HeaderText = i18n("M12418", "Çoklu Özel Durum");
        this.CokluOzelDurum.Name = "CokluOzelDurum";
        this.CokluOzelDurum.Width = 100;

        this.KodsuzMalzemeFiyatı = new TTVisual.TTTextBoxColumn();
        this.KodsuzMalzemeFiyatı.DisplayIndex = 9;
        this.KodsuzMalzemeFiyatı.HeaderText = i18n("M17688", "Kodsuz Malzeme Fiyatı");
        this.KodsuzMalzemeFiyatı.Name = "KodsuzMalzemeFiyatı";
        this.KodsuzMalzemeFiyatı.Visible = false;
        this.KodsuzMalzemeFiyatı.Width = 100;

        this.MalzemeTuru = new TTVisual.TTListBoxColumn();
        this.MalzemeTuru.ListDefName = "MalzemeTuruDefinitionList";
        this.MalzemeTuru.DisplayIndex = 10;
        this.MalzemeTuru.HeaderText = i18n("M18650", "Malzemenin Türü");
        this.MalzemeTuru.Name = "MalzemeTuru";
        this.MalzemeTuru.Visible = false;
        this.MalzemeTuru.Width = 100;

        this.Kdv = new TTVisual.TTTextBoxColumn();
        this.Kdv.DisplayIndex = 11;
        this.Kdv.HeaderText = "Kdv";
        this.Kdv.Name = "Kdv";
        this.Kdv.Visible = false;
        this.Kdv.Width = 100;

        this.MalzemeBrans = new TTVisual.TTTextBoxColumn();
        this.MalzemeBrans.DisplayIndex = 12;
        this.MalzemeBrans.HeaderText = i18n("M18636", "Malzemenin Branşı");
        this.MalzemeBrans.Name = "MalzemeBrans";
        this.MalzemeBrans.Visible = false;
        this.MalzemeBrans.Width = 100;

        this.SatinAlisTarihi = new TTVisual.TTDateTimePickerColumn();
        this.SatinAlisTarihi.DisplayIndex = 13;
        this.SatinAlisTarihi.HeaderText = i18n("M21333", "Satın Alış Tarihi");
        this.SatinAlisTarihi.Name = "SatinAlisTarihi";
        this.SatinAlisTarihi.Visible = false;
        this.SatinAlisTarihi.Width = 100;

        this.ResponsibleNurse = new TTVisual.TTObjectListBox();
        this.ResponsibleNurse.ReadOnly = true;
        this.ResponsibleNurse.ListDefName = "ClinicNurseListDefinition";
        this.ResponsibleNurse.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ResponsibleNurse.Name = "ResponsibleNurse";
        this.ResponsibleNurse.TabIndex = 7;

        this.labelResponsibleNurse = new TTVisual.TTLabel();
        this.labelResponsibleNurse.Text = i18n("M22151", "Sorumlu Hemşire");
        this.labelResponsibleNurse.BackColor = "#DCDCDC";
        this.labelResponsibleNurse.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelResponsibleNurse.ForeColor = "#000000";
        this.labelResponsibleNurse.Name = "labelResponsibleNurse";
        this.labelResponsibleNurse.TabIndex = 206;

        this.lableResponsibleDoctor = new TTVisual.TTLabel();
        this.lableResponsibleDoctor.Text = i18n("M22158", "Sorumlu Tabip");
        this.lableResponsibleDoctor.BackColor = "#DCDCDC";
        this.lableResponsibleDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.lableResponsibleDoctor.ForeColor = "#000000";
        this.lableResponsibleDoctor.Name = "lableResponsibleDoctor";
        this.lableResponsibleDoctor.TabIndex = 204;

        this.ResponsibleDoctor = new TTVisual.TTObjectListBox();
        this.ResponsibleDoctor.ReadOnly = true;
        this.ResponsibleDoctor.ListDefName = "SpecialistDoctorListDefinition";
        this.ResponsibleDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ResponsibleDoctor.Name = "ResponsibleDoctor";
        this.ResponsibleDoctor.TabIndex = 6;

        this.nNursingOrderObject = new TTVisual.TTListBoxColumn();
        this.nNursingOrderObject.AllowMultiSelect = true;
        this.nNursingOrderObject.ListDefName = "VitalSignAndNursingListDefinition";
        this.nNursingOrderObject.DataMember = "NursingOrderObject";
        this.nNursingOrderObject.DisplayIndex = 1;
        this.nNursingOrderObject.HeaderText = i18n("M24169", "Vital Bulgu ve Hemşirelik İşlemleri");
        this.nNursingOrderObject.Name = "nNursingOrderObject";
        this.nNursingOrderObject.Width = 200;
        this.nNursingOrderObject.ReadOnly = true;
        this.nNursingOrderObject.Enabled = false;


        this.txtReportName = new TTVisual.TTTextBoxColumn();
        this.txtReportName.DataMember = "ReportName";
        this.txtReportName.Name = "ReportName";
        this.txtReportName.ToolTipText = "ReportName";
        this.txtReportName.Width = "50%";
        this.txtReportName.DisplayIndex = 1;
        this.txtReportName.HeaderText = "Rapor";
        this.txtReportName.ReadOnly = this.ReadOnly;

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


        this.txtStartDate = new TTVisual.TTTextBoxColumn();
        this.txtStartDate.DataMember = "StartDate";
        this.txtStartDate.Name = "StartDate";
        this.txtStartDate.ToolTipText = "StartDate";
        this.txtStartDate.Width = "20%";
        this.txtStartDate.DisplayIndex = 0;
        this.txtStartDate.HeaderText = i18n("M11637", "Başlangıç Tarihi");
        this.txtStartDate.ReadOnly = this.ReadOnly;

        this.txtEndDate = new TTVisual.TTTextBoxColumn();
        this.txtEndDate.DataMember = "EndDate";
        this.txtEndDate.Name = "EndDate";
        this.txtEndDate.ToolTipText = "EndDate";
        this.txtEndDate.Width = "20%";
        this.txtEndDate.DisplayIndex = 0;
        this.txtEndDate.HeaderText = i18n("M11939", "Bitiş Tarihi");
        this.txtEndDate.ReadOnly = this.ReadOnly;

        this.txtProcedureByUser = new TTVisual.TTTextBoxColumn();
        this.txtProcedureByUser.DataMember = "ProcedureByUser";
        this.txtProcedureByUser.Name = "ProcedureByUser";
        this.txtProcedureByUser.ToolTipText = "Rapor Oluşturan";
        this.txtProcedureByUser.Width = "20%";
        this.txtProcedureByUser.DisplayIndex = 0;
        this.txtProcedureByUser.HeaderText = i18n("M11939", "Rapor Oluşturan");
        this.txtProcedureByUser.Enabled = false;
        this.txtProcedureByUser.ReadOnly = true;

        this.btnEdit = new TTVisual.TTButtonColumn();
        this.btnEdit.Name = "btnEdit";
        this.btnEdit.Width = "10%";
        this.btnEdit.DisplayIndex = 0;
        this.btnEdit.HeaderText = i18n("M13405", "");
        this.btnEdit.ReadOnly = false;
        this.btnEdit.Text = "Düzenle";

        this.HCModeOfPayment = new TTVisual.TTEnumComboBox();
        this.HCModeOfPayment.DataTypeName = "WhoPaysEnum";
        this.HCModeOfPayment.Name = "HCModeOfPayment";
        this.HCModeOfPayment.TabIndex = 12;

        this.btnInPatientPhysicianApplicationSave = new TTVisual.TTButton();
        this.btnInPatientPhysicianApplicationSave.Text = i18n("M17386", "Kaydet");
        this.btnInPatientPhysicianApplicationSave.Name = 'btnInPatientPhysicianApplicationSave';
        this.btnInPatientPhysicianApplicationSave.TabIndex = 4;

        this.btnInPatientPhysicianApplicationSaveAndClose = new TTVisual.TTButton();
        this.btnInPatientPhysicianApplicationSaveAndClose.Text = i18n("M30113", "Kaydet / Kapat");
        this.btnInPatientPhysicianApplicationSaveAndClose.Name = 'btnInPatientPhysicianApplicationSaveAndClose';
        this.btnInPatientPhysicianApplicationSaveAndClose.TabIndex = 4;

        /* Yatan Hasta Sağlık Kurulu*/
        this.DisabledReportApplicationExplanation = new TTVisual.TTTextBox();
        this.DisabledReportApplicationExplanation.IsNonNumeric = true;
        this.DisabledReportApplicationExplanation.Name = "DisabledReportApplicationExplanation";
        this.DisabledReportApplicationExplanation.CharacterCasing = CharacterCasing.Upper;
        this.DisabledReportApplicationExplanation.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DisabledReportApplicationExplanation.TabIndex = 50;

        this.DisabledReportApplicationReason = new TTVisual.TTEnumComboBox();
        this.DisabledReportApplicationReason.DataTypeName = "EngelliRaporuMuracaatNedeniEnum";
        this.DisabledReportApplicationReason.Name = "DisabledReportApplicationReason";
        this.DisabledReportApplicationReason.TabIndex = 666;

        this.DisabledReportApplicationType = new TTVisual.TTEnumComboBox();
        this.DisabledReportApplicationType.DataTypeName = "EngelliRaporuMuracaatTipiEnum";
        this.DisabledReportApplicationType.Name = "DisabledReportApplicationType";
        this.DisabledReportApplicationType.TabIndex = 666;

        this.DisabledReportPersonalApplicationType = new TTVisual.TTEnumComboBox();
        this.DisabledReportPersonalApplicationType.DataTypeName = "EngelliRaporuKisiselMuracaatTuruEnum";
        this.DisabledReportPersonalApplicationType.Name = "DisabledReportPersonalApplicationType";
        this.DisabledReportPersonalApplicationType.TabIndex = 666;

        this.DisabledReportCorporateApplicationType = new TTVisual.TTEnumComboBox();
        this.DisabledReportCorporateApplicationType.DataTypeName = "EngelliRaporuKurumsalMuracaatTuruEnum";
        this.DisabledReportCorporateApplicationType.Name = "DisabledReportCorporateApplicationType";
        this.DisabledReportCorporateApplicationType.TabIndex = 666;

        this.DisabledReportTerrorAccidentInjuryAppReason = new TTVisual.TTEnumComboBox();
        this.DisabledReportTerrorAccidentInjuryAppReason.DataTypeName = "EngelliRaporuTerorKazaMuracaatNedeniEnum";
        this.DisabledReportTerrorAccidentInjuryAppReason.Name = "DisabledReportTerrorAccidentInjuryAppReason";
        this.DisabledReportTerrorAccidentInjuryAppReason.TabIndex = 666;

        this.DisabledReportTerrorAccidentInjuryAppType = new TTVisual.TTEnumComboBox();
        this.DisabledReportTerrorAccidentInjuryAppType.DataTypeName = "EngelliRaporuTerorKazaMuracaatTipiEnum";
        this.DisabledReportTerrorAccidentInjuryAppType.Name = "DisabledReportTerrorAccidentInjuryAppType";
        this.DisabledReportTerrorAccidentInjuryAppType.TabIndex = 666;

        this.tedaviTipi = new TTVisual.TTObjectListBox();
        this.tedaviTipi.ListDefName = "TedaviTipiListDefinition";
        this.tedaviTipi.Name = "tedaviTipi";
        this.tedaviTipi.TabIndex = 4;

        /*E-Durum Bildirir Kurul Entegrasyonu*/
        this.EStatusNotRepCommitteeApplicationType = new TTVisual.TTEnumComboBox();
        this.EStatusNotRepCommitteeApplicationType.DataTypeName = "EDurumBildirirKurulAppType";
        this.EStatusNotRepCommitteeApplicationType.Name = "EStatusNotRepCommitteeApplicationType";
        this.EStatusNotRepCommitteeApplicationType.TabIndex = 666;
        /*E-Durum Bildirir Kurul Entegrasyonu*/
        /*Yatan Hasta Sağlık Kurulu */

        this.listBoxTreatmentResult = new TTVisual.TTObjectListBox();
        this.listBoxTreatmentResult.ListDefName = 'SKRSCikisSekliList';
        this.listBoxTreatmentResult.Name = 'listBoxTreatmentResult';
        this.listBoxTreatmentResult.TabIndex = 52;
        this.listBoxTreatmentResult.AutoCompleteDialogHeight = '120%';

        this.GridPatientReportsColumns = [this.txtReportName, this.txtReportRequestReason, this.txtReportAdmissionDate, this.txtReportMasterResource, this.txtStartDate, this.txtEndDate, this.txtProcedureByUser, this.btnEdit];

        this.DietOrdersColumns = [this.DietRPT, this.DietChange, this.ProcedureObjectDietOrder, this.PeriodStartTimeDietOrder, this.RecurrenceDayAmountDietOrder, this.PeriodEndTimeDietOrder, this.AmountForPeriodDietOrder, this.FrequencyDietOrder, this.Breakfast, this.Dinner, this.Lunch, this.NightBreakfast, this.Snack1, this.Snack2, this.Snack3, this.OrderDescriptionDietOrder];
        this.InPatientRtfBySpecialitiesColumns = [this.TitleInPatientRtfBySpeciality, this.RtfInPatientRtfBySpeciality];
        this.ProgressesColumns = [this.ProgressDateInPatientPhysicianProgresses, this.ProcedureDoctorInPatientPhysicianProgresses, this.DescriptionInPatientPhysicianProgressesRch];
        this.GridDiagnosisColumns = [this.SecDiagnose, this.SecFreeDiagnosis, this.SecIsMainDiagnose, this.SecResponsibleUser, this.SecDiagnoseDate];
        this.NursingOrderGridColumns = [this.RPT, this.showDetail, this.nProcedureObject, this.nPeriodStartTime, this.nFrequency, this.nAmountForPeriod, this.nRecurrenceDayAmount, this.nOrderDescription];
        //this.NursingOrderTempGridColumns = [this.nNursingOrderObject, this.nFrequency, this.nAmountForPeriod, this.nRecurrenceDayAmount];

        this.GridTreatmentMaterialsColumns = [this.TreatmentMaterialActionDate, this.Material, this.Barcode, this.UBBCode, this.Amount, this.DistributionType, this.OzelDurum, this.Notes, this.CokluOzelDurum, this.KodsuzMalzemeFiyatı, this.MalzemeTuru, this.Kdv, this.MalzemeBrans, this.SatinAlisTarihi];
        this.Controls = [this.DietRPT, this.DietChange, this.tedaviTipi, this.VentilatorStatus, this.IsPandemic, this.DietOrders, this.ProcedureObjectDietOrder, this.PeriodStartTimeDietOrder, this.RecurrenceDayAmountDietOrder, this.PeriodEndTimeDietOrder, this.OrderDescriptionDietOrder, this.AmountForPeriodDietOrder, this.FrequencyDietOrder, this.Breakfast, this.Dinner, this.Lunch, this.NightBreakfast, this.Snack1, this.Snack2, this.Snack3, this.InPatientRtfBySpecialities, this.TitleInPatientRtfBySpeciality, this.RtfInPatientRtfBySpeciality, this.InpatientProtocolNo, this.ReasonForInpatientAdmission, this.Progresses, this.ProgressDateInPatientPhysicianProgresses, this.ProcedureDoctorInPatientPhysicianProgresses, this.DescriptionInPatientPhysicianProgressesRch, this.GridDiagnosis, this.SecDiagnose, this.SecFreeDiagnosis, this.SecIsMainDiagnose, this.SecResponsibleUser, this.SecDiagnoseDate, this.MasterResource, this.labelInpatientDepartment, this.labelRoom, this.Bed, this.RoomGroup, this.labelRoomGroup, this.Room, this.labelBed, this.ClinicDischargeDate, this.labelClinicDischargeDate, this.labelProtocolNo, this.rtfComplaint, this.rtfHistory, this.rtfPhysicalExamination, this.labelReasonForInpatientAdmission, this.NursingOrderGrid, this.RPT, this.nProcedureObject, this.nPeriodStartTime, this.nFrequency, this.nAmountForPeriod, this.nRecurrenceDayAmount, this.nOrderDescription, this.GridTreatmentMaterials, this.TreatmentMaterialActionDate, this.Material, this.Barcode, this.UBBCode, this.Amount, this.DistributionType, this.OzelDurum, this.Notes, this.CokluOzelDurum, this.KodsuzMalzemeFiyatı, this.MalzemeTuru, this.Kdv, this.MalzemeBrans, this.SatinAlisTarihi, this.ResponsibleNurse, this.labelResponsibleNurse, this.lableResponsibleDoctor, this.ResponsibleDoctor];

    }

    public searchNursingOder(e) {
        this.nursingOrderSource.searchValue(e.value);
        this.nursingOrderSource.load();
    }

    public async selectNursingOrder(e, fromRpt, fromTemplate) {
        if (fromRpt)//talimat tekrarı
        {
            if (!fromTemplate) {
                if (this.inPatientPhysicianApplicationFormViewModel.NursingOrderGridGridList.find(p => p.ProcedureObject.ObjectID == e.ProcedureObject.ObjectID && p.IsNew) != undefined) {
                    //TTVisual.InfoBox.Alert("Bu direktif planlanmak için daha önce eklendi");
                    ServiceLocator.MessageService.showInfo(i18n("M12073", "Bu direktif planlanmak için daha önce eklendi2"));
                    return false;
                }
            }
            else {
                if (this.inPatientPhysicianApplicationFormViewModel.NursingOrderGridGridList.find(p => p.ProcedureObject.ObjectID == e.NursingOrderObject.ObjectID && p.IsNew) != undefined) {
                    //TTVisual.InfoBox.Alert("Bu direktif planlanmak için daha önce eklendi");
                    ServiceLocator.MessageService.showInfo(i18n("M12073", "Bu direktif planlanmak için daha önce eklendi2"));
                    return false;
                }
            }

            let newNursingOrder: NursingOrder = new NursingOrder();
            // newNursingOrder.OrderDetails.AddNew
            newNursingOrder.ProcedureObject = fromTemplate == true ? e.NursingOrderObject : e.ProcedureObject;
            newNursingOrder.AmountForPeriod = e.AmountForPeriod; //miktar
            newNursingOrder.RecurrenceDayAmount = e.RecurrenceDayAmount; //gün
            newNursingOrder.Frequency = e.Frequency;

            let _newDate: Date = new Date(); //talimatın saati
            if (e.PeriodStartTime != undefined)//tekrarla
                newNursingOrder.PeriodStartTime = new Date(_newDate.getFullYear(), _newDate.getMonth(), _newDate.getDate(), e.PeriodStartTime.getHours(), e.PeriodStartTime.getMinutes(), 0, 0);
            else//şablon
                newNursingOrder.PeriodStartTime = new Date().getMinutes() > 0 ? new Date(new Date().AddHours(1).setMinutes(0, 0, 0)) : new Date();
            newNursingOrder.Active = true;
            newNursingOrder.IsNew = true;
            // console.log(newNursingOrder.OrderDetails);
            this.inPatientPhysicianApplicationFormViewModel.NursingOrderGridGridList.unshift(newNursingOrder);
        }
        else {
            if (e.itemData !== null) {
                //this.inPatientPhysicianApplicationFormViewModel.VitalSignAndNursingDefinitions.push(e.itemData as VitalSignAndNursingDefinition);
                //this.inPatientPhysicianApplicationFormViewModel.NursingOrderGridGridList.push(e.itemData)
                if (this.inPatientPhysicianApplicationFormViewModel.NursingOrderGridGridList.find(p => p.ProcedureObject.ObjectID == e.itemData.ObjectID && p.IsNew) != undefined) {
                    //TTVisual.InfoBox.Alert("Bu direktif planlanmak için daha önce eklendi");
                    ServiceLocator.MessageService.showInfo(i18n("M12073", "Bu direktif planlanmak için daha önce eklendi2"));
                    return false;
                }
                let newNursingOrder: NursingOrder = new NursingOrder();
                newNursingOrder.ProcedureObject = e.itemData;
                newNursingOrder.AmountForPeriod = 1; //miktar
                newNursingOrder.RecurrenceDayAmount = 1; //gün
                newNursingOrder.Frequency = FrequencyEnum.Q12H; //kaç. saatte
                newNursingOrder.PeriodStartTime = new Date().getMinutes() > 0 ? new Date(new Date().AddHours(1).setMinutes(0, 0, 0)) : new Date();
                newNursingOrder.Active = true;
                newNursingOrder.IsNew = true;

                // newNursingOrder.OrderDetails = new Array<NursingOrderDetail>();

                // await this.createNursingOrderDetail(newNursingOrder);                

                this.inPatientPhysicianApplicationFormViewModel.NursingOrderGridGridList.unshift(newNursingOrder);
            }
        }
    }

    async createNursingOrderDetail(nursingOrder: NursingOrder) {
        let fullApiUrl = "";
        let that = this;

        if (nursingOrder.OrderDetails != null && nursingOrder.OrderDetails.length > 0) {
            this.openNODPopup(<NursingOrder>nursingOrder).then(res => {
                let modalActionResult = res as ModalActionResult;
                if (modalActionResult.Result == DialogResult.OK && nursingOrder.IsNew) {
                    nursingOrder.OrderDetails = res.Param as Array<NursingOrderDetail>;
                    // alert("yeni")
                }
                // drugOrderIntroductionDetail.DrugOrder.DrugOrderDetails = res.Param as Array<DrugOrderDetail>;
                // drugOrderIntroductionDetail.PlannedStartTime = drugOrderIntroductionDetail.DrugOrder.DrugOrderDetails.find(x => x.DetailNo == 1).OrderPlannedDate;
            });
        }
        else {
            if (nursingOrder.IsNew) {
                fullApiUrl = '/api/InpatientPhysicianApplicationService/GetEmptyOrderDetail';

                let _detail = new NewNursingOrderDetail();
                _detail.newNursingOrderDetail = await this.httpService.post<Array<NursingOrderDetail>>(fullApiUrl, nursingOrder);
                _detail.NursingOrderID = nursingOrder.ProcedureObject.ObjectID;
                // that.inPatientPhysicianApplicationFormViewModel.newNursingOrderDetailList.push(_detail);

                nursingOrder.OrderDetails = _detail.newNursingOrderDetail as Array<NursingOrderDetail>;
            }
            else {
                fullApiUrl = '/api/InpatientPhysicianApplicationService/GetOrderDetailByNUrsingORder/?OrderID=' + nursingOrder.ObjectID.toString();

                let _detail = await this.httpService.get<Array<NursingOrderDetail>>(fullApiUrl);
                nursingOrder.OrderDetails = _detail as Array<NursingOrderDetail>;
            }

            this.openNODPopup(<NursingOrder>nursingOrder).then(res => {
                let modalActionResult = res as ModalActionResult;
                if (modalActionResult.Result == DialogResult.OK) {
                    nursingOrder.OrderDetails = res.Param as Array<NursingOrderDetail>;

                    if (nursingOrder.IsNew)
                        nursingOrder.PeriodStartTime = nursingOrder.OrderDetails[0].WorkListDate;
                    // drugOrderIntroductionDetail.PlannedStartTime = drugOrderIntroductionDetail.DrugOrder.DrugOrderDetails.find(x => x.DetailNo == 1).OrderPlannedDate;
                }
            });
        }

    }

    openNODPopup(data: NursingOrder): Promise<ModalActionResult> {
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'NODTimeLineComponent';
            componentInfo.ModuleName = 'YatanHastaModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Yatan_Hasta_Modulu/YatanHastaModule';

            let tempArray: Array<NursingOrderDetail> = new Array<NursingOrderDetail>();
            tempArray = <Array<NursingOrderDetail>>AtlasObjectCloner.clone(data.OrderDetails);

            componentInfo.InputParam = new DynamicComponentInputParam(tempArray, new ActiveIDsModel(this._InPatientPhysicianApplication.ObjectID, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Zaman Çizelgesi';
            modalInfo.Width = 600;
            modalInfo.Height = 400;
            modalInfo.IsShowCloseButton = false;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }

    prepareNursinOrderSchedule() {
        let nursinOrderScheduleObj: NursinOrderScheduleObj = new NursinOrderScheduleObj();
        let scheduleResourceObj: any;
        this.nursingOrderScheduleList = [];
        this.nursingOrderScheduleResource = [];

        this.loadPanelOperation(true, 'Ekran yükleniyor.');

        let _list = this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.NursingOrders;
        for (let i = 0; i < _list.length; i++) {
            if (_list[i].CurrentStateDefID != null && _list[i].CurrentStateDefID != NursingOrder.NursingOrderStates.Cancelled) {
                nursinOrderScheduleObj = new NursinOrderScheduleObj();
                nursinOrderScheduleObj.text = _list[i].ProcedureObject.Name_Shadow;
                nursinOrderScheduleObj.ownerId = _list[i].ProcedureObject.ObjectID;
                nursinOrderScheduleObj.startDate = _list[i].PeriodStartTime;
                nursinOrderScheduleObj.endDate = _list[i].PeriodStartTime.AddDays(_list[i].RecurrenceDayAmount);
                nursinOrderScheduleObj.id = _list[i].ObjectID;
                nursinOrderScheduleObj.stateID = _list[i].CurrentStateDefID.toString();
                this.nursingOrderScheduleList.push(nursinOrderScheduleObj);
            }
        }

        let resources: any[] = [
            {
                text: "Samantha Bright",
                id: NursingOrder.NursingOrderStates.Cancelled,
                color: "#F37171"
            }, {
                text: "John Heart",
                id: NursingOrder.NursingOrderStates.Planned,
                color: "#7876D8"
            }
        ];
        this.nursingOrderScheduleResource.push(resources);

        this.loadPanelOperation(false, '');

        //var _resourceList = this.inPatientPhysicianApplicationFormViewModel.VitalSignAndNursingDefinitionList;

        //for (var j = 0; j < _resourceList.length; j++) {
        //    scheduleResourceObj = new Object()
        //    scheduleResourceObj.text = _resourceList[j].Name_Shadow;
        //    scheduleResourceObj.id = _resourceList[j].ObjectID;
        //    scheduleResourceObj.color = "#cb6bb2";

        //    this.nursingOrderScheduleResource.push(scheduleResourceObj);
        //}
    }

    prepareNursingOrderDetailScheduleResource() {
        this.nursingOrderDetailScheduleResource = [
            { text: i18n("M19700", "Onaylandı"), id: NursingOrderDetail.NursingOrderDetailStates.Completed, color: 'Green' },
            { text: i18n("M19676", "Onay Bekliyor"), id: NursingOrderDetail.NursingOrderDetailStates.Execution, color: 'blue' },
            { text: i18n("M20983", "Reddedildi"), id: NursingOrderDetail.NursingOrderDetailStates.Cancelled, color: 'red' }
        ];
    }

    prepareDietOrderDetailScheduleResource() {
        this.dietOrderDetailScheduleResource = [
            { text: i18n("M13047", "Diyet Onay"), id: DietOrderDetail.DietOrderDetailStates.Approval, color: 'blue' },
            { text: i18n("M19700", "Onaylandı"), id: DietOrderDetail.DietOrderDetailStates.Completed, color: 'blue' },
            { text: i18n("M19691", "Onayla"), id: DietOrderDetail.DietOrderDetailStates.Execution, color: 'blue' },
            { text: i18n("M16526", "İptal"), id: DietOrderDetail.DietOrderDetailStates.Cancelled, color: 'red' }
        ];
    }

    grdOrderClicked($event) {
        if ($event.Column.Name == "RPT")
            this.selectNursingOrder($event.Row.TTObject, true, false);
        else if ($event.Column.Name == "showDetail")
            this.createNursingOrderDetail(<NursingOrder>$event.Row.TTObject);

        // this.openNODPopup(<NursingOrder>$event.Row.TTObject).then(res => {
        //     let modalActionResult = res as ModalActionResult;
        //     // drugOrderIntroductionDetail.DrugOrder.DrugOrderDetails = res.Param as Array<DrugOrderDetail>;
        //     // drugOrderIntroductionDetail.PlannedStartTime = drugOrderIntroductionDetail.DrugOrder.DrugOrderDetails.find(x => x.DetailNo == 1).OrderPlannedDate;
        // });
    }

    public searchDietOder(e) {
        this.dietOrderSource.searchValue(e.value);
        this.dietOrderSource.load();
    }

    grdDietClicked($event) {
        if ($event != null) {
            if ($event.Column.Name == "DietRPT")
                this.selectDietOrder($event.Row.TTObject, true);
            else if ($event.Column.Name)
                this.changeDietOrder($event);
        }

    }

    dietGridDayChange($event) {
        if (!$event.Row.TTObject._isNew) {
            this.messageService.showError(i18n("M17383", "Kaydedilmiş orderları değiştiremezsiniz./İptal edip yeni order tanımlayabilirsiniz ya da  \nuygulanmamış order detaylarını değiştirmek için \'Verilen Diyet Detayları\' sekmesini kullanabilirsiniz"));
            return false;
        }
        if ($event.Column.DataMember == "RecurrenceDayAmount" && !isNaN(parseInt($event.Row.TTObject.RecurrenceDayAmount)))
            $event.Row.TTObject.PeriodEndTime = $event.Row.TTObject.PeriodStartTime.AddDays(parseInt($event.Row.TTObject.RecurrenceDayAmount));
    }

    nodGridCellValueChanged($event) {
        // debugger;
        $event.Row.TTObject.OrderDetails = null;
        // alert();
    }

    prepareDietOrderSchedule() {
        let nursinOrderScheduleObj: NursinOrderScheduleObj = new NursinOrderScheduleObj();
        let scheduleResourceObj: any;
        this.loadPanelOperation(true, 'Ekran yükleniyor.');
        this.dietOrderScheduleList = [];
        this.dietOrderScheduleResource = [];

        let _list = this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.DietOrders;
        for (let i = 0; i < _list.length; i++) {
            if (_list[i].CurrentStateDefID != DietOrder.DietOrderStates.Cancelled) {
                nursinOrderScheduleObj = new NursinOrderScheduleObj();
                nursinOrderScheduleObj.text = _list[i].ProcedureObject.Name_Shadow;
                nursinOrderScheduleObj.ownerId = _list[i].ProcedureObject.ObjectID;
                nursinOrderScheduleObj.startDate = new Date(_list[i].PeriodStartTime.setHours(0, 0, 0, 0));
                nursinOrderScheduleObj.endDate = new Date(_list[i].PeriodEndTime.setHours(0, 0, 0, 0));
                nursinOrderScheduleObj.id = _list[i].ObjectID;
                this.dietOrderScheduleList.push(nursinOrderScheduleObj);
            }
        }

        let _resourceList = this.inPatientPhysicianApplicationFormViewModel.DietDefinitionList;

        for (let j = 0; j < _resourceList.length; j++) {
            scheduleResourceObj = new Object();
            scheduleResourceObj.text = _resourceList[j].Name_Shadow;
            scheduleResourceObj.id = _resourceList[j].ObjectID;
            //scheduleResourceObj.color = "#cb6bb2";

            this.dietOrderScheduleResource.push(scheduleResourceObj);
        }

        this.loadPanelOperation(false, '');
    }

    async selectDietOrder(e, fromRpt) {
        // let hasDrugInteraction1 = await  this.ControlDrugInteraction(e.ProcedureObject.ObjectID);

        let ObjectID = null;

        if (fromRpt)
            ObjectID = e.ProcedureObject.ObjectID;
        else {
            if (e.itemData != null)
                ObjectID = e.itemData.ObjectID;
        }

        this.loadPanelOperation(true, "Besin İlaç Etkileşimi Kontrol Ediliyor.");
        let hasDrugInteraction = await this.ControlDrugInteraction(ObjectID);
        this.loadPanelOperation(false, "");
        if (hasDrugInteraction === DialogResult.Cancel) {
            TTVisual.InfoBox.Alert(i18n("M16907", "İşlemden vazgeçildi"));
            return;
        }


        if (fromRpt)//talimat tekrarı
        {
            if (this.inPatientPhysicianApplicationFormViewModel.DietOrdersGridList.find(p => p.ProcedureObject.ObjectID == e.ProcedureObject.ObjectID && p.IsNew) != undefined) {
                ServiceLocator.MessageService.showInfo(i18n("M12073", "Bu direktif planlanmak için daha önce eklendi2"));
                return false;
            }

            let that = this;
            //yeni nesne oluştururken servise gitmek gerekiyor ki objectId vs oluşsun
            //oluşmaz ise relationları bağlayamıyor
            that.httpService.get<MealTypes>("/api/InpatientPhysicianApplicationService/CreateNewMealType")
                .then(response => {
                    let newDietOrder: DietOrder = new DietOrder();
                    newDietOrder.ProcedureObject = e.ProcedureObject;
                    newDietOrder.AmountForPeriod = e.AmountForPeriod; //miktar
                    newDietOrder.RecurrenceDayAmount = e.RecurrenceDayAmount; //gün
                    newDietOrder.Frequency = e.Frequency;
                    newDietOrder.PeriodStartTime = new Date();
                    newDietOrder.PeriodEndTime = newDietOrder.PeriodStartTime.AddDays(newDietOrder.RecurrenceDayAmount);
                    newDietOrder.Active = true;
                    newDietOrder.IsNew = true;
                    newDietOrder.OrderDescription = e.OrderDescription;

                    newDietOrder.MealType = response as MealTypes;
                    newDietOrder.MealType.Breakfast = e.MealType.Breakfast;
                    newDietOrder.MealType.Lunch = e.MealType.Lunch;
                    newDietOrder.MealType.Dinner = e.MealType.Dinner;
                    newDietOrder.MealType.NightBreakfast = e.MealType.NightBreakfast;
                    newDietOrder.MealType.Snack1 = e.MealType.Snack1;
                    newDietOrder.MealType.Snack2 = e.MealType.Snack2;
                    newDietOrder.MealType.Snack3 = e.MealType.Snack3;

                    //yine reliationları bağlayabilmesi için burayada push etmek gerekiyormuş
                    this.inPatientPhysicianApplicationFormViewModel.MealTypess.push(newDietOrder.MealType);

                    this.inPatientPhysicianApplicationFormViewModel.DietOrdersGridList.unshift(newDietOrder);
                })
                .catch(error => {
                    this.messageService.showError(error);

                });
        }
        else {
            if (e.itemData !== null) {
                if (this.inPatientPhysicianApplicationFormViewModel.DietOrdersGridList.find(p => p.ProcedureObject.ObjectID == e.itemData.ObjectID && p.IsNew) != undefined) {
                    ServiceLocator.MessageService.showInfo(i18n("M12073", "Bu direktif planlanmak için daha önce eklendi2"));
                    return false;
                }

                let that = this;
                //yeni nesne oluştururken servise gitmek gerekiyor ki objectId vs oluşsun
                //oluşmaz ise relationları bağlayamıyor
                that.httpService.get<MealTypes>("/api/InpatientPhysicianApplicationService/CreateNewMealType")
                    .then(response => {
                        let newDietOrder: DietOrder = new DietOrder();
                        newDietOrder.ProcedureObject = e.itemData;
                        newDietOrder.AmountForPeriod = 1; //miktar
                        newDietOrder.RecurrenceDayAmount = 1; //gün
                        newDietOrder.Frequency = FrequencyEnum.Q24H; //kaç. saatte
                        newDietOrder.PeriodStartTime = new Date();
                        newDietOrder.PeriodEndTime = newDietOrder.PeriodStartTime.AddDays(newDietOrder.RecurrenceDayAmount);
                        newDietOrder.Active = true;
                        newDietOrder.IsNew = true;

                        newDietOrder.MealType = response as MealTypes;
                        newDietOrder.MealType.Breakfast = e.itemData.Breakfast;
                        newDietOrder.MealType.Lunch = e.itemData.Lunch;
                        newDietOrder.MealType.Dinner = e.itemData.Dinner;
                        newDietOrder.MealType.NightBreakfast = e.itemData.NightBreakfast;
                        newDietOrder.MealType.Snack1 = e.itemData.Snack1;
                        newDietOrder.MealType.Snack2 = e.itemData.Snack2;
                        newDietOrder.MealType.Snack3 = e.itemData.Snack3;

                        //yine reliationları bağlayabilmesi için burayada push etmek gerekiyormuş
                        this.inPatientPhysicianApplicationFormViewModel.MealTypess.push(newDietOrder.MealType);

                        this.inPatientPhysicianApplicationFormViewModel.DietOrdersGridList.unshift(newDietOrder);
                    })
                    .catch(error => {
                        this.messageService.showError(error);

                    });

            }
        }
    }

    public ControlDrugInteraction(ObjectID: Guid): Promise<DialogResult> {
        let that = this;
        // that.httpService.get<MealTypes>("/api/InpatientPhysicianApplicationService/ShowFoodDrugInteraction/?ObjectID="+ObjectID)
        // .then(response => {

        // })
        // .catch(error => {
        //     this.messageService.showError(error);

        // });

        return new Promise<DialogResult>((resolve, reject) => {

            let fullApiUrl: string = 'api/DrugOrderIntroductionService/PrepareInteraction';
            this.httpService.get("/api/InpatientPhysicianApplicationService/ShowFoodDrugInteraction/?DietOrderID=" + ObjectID + "&Episode=" + that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.Episode.ObjectID)
                .then((res: PrepareInteraction_Output) => {
                    if (res.drugDrugInteractions.length > 0 || res.drugFoodInteractions.length > 0) {
                        let componentInfo = new DynamicComponentInfo();
                        componentInfo.ComponentName = 'DrugAtlasInteractionComponent';
                        componentInfo.ModuleName = 'LogisticFormsModule';
                        componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
                        componentInfo.InputParam = res;

                        let modalInfo: ModalInfo = new ModalInfo();
                        modalInfo.Title = 'UYARI';
                        modalInfo.Width = 1200;
                        modalInfo.Height = 800;

                        let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
                        let result2 = modalService.create(componentInfo, modalInfo);
                        result2.then(res2 => {
                            resolve(res2.Result);
                        });
                    } else {
                        resolve(DialogResult.OK);
                    }
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                    reject(error);
                });

        });


    }

    public previousDietOrder: DietOrder;
    async changeDietOrder(e) {
        this.previousDietOrder = e.Row.TTObject;

        let message: string = "Bugünden İtibaren Verilen  Orderlar İptal Edilecek ve Yeni Diyet Bilgisi Hastaya Eklenecektir.. Devam Etmek İstiyor Musunuz?";
        let result: string = await ShowBox.Show(1, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), "", message, 1);
        if (result === "OK") {
            this.changeDietPopUp = true;
        }
    }

    public onChangeDietOrder(e) {
        this.selectDietOrder(e, false);

        if (this.previousDietOrder.OrderDescription == undefined)
            this.previousDietOrder.OrderDescription = "";
        if (this.previousDietOrder.ReasonOfCancel == undefined)
            this.previousDietOrder.ReasonOfCancel = "";

        this.previousDietOrder.ReasonOfReject = "Diyet Değiştirildi";//servis tarafında bu bilgi kontrol edildi
        this.previousDietOrder.OrderDescription += "Bu Diyet " + e.itemData.Name + " isimli diyet ile Değiştirildi";
        this.previousDietOrder.ReasonOfCancel += "Bu Diyet " + e.itemData.Name + " isimli diyet ile Değiştirildi";
        this.changeDietPopUp = false;
    }

    onAppointmentUpdating(e: any) {
        if (e.newData.startDate < e.newData.periodStartTime) {
            ServiceLocator.MessageService.showError(i18n("M20391", "Planlama Zamanı order tarihinden küçük olamaz.\n Order Başlama Tarihi  =") + e.newData.periodStartTime.ToShortDateString() + " " + e.newData.periodStartTime.toLocaleTimeString());
            e.cancel = true;
            return false;
        }
        else if (e.newData.statusName == i18n("M22710", "Tamamlandı")) {
            ServiceLocator.MessageService.showError(i18n("M22725", "Tamamlanmış bir orderın detayını değiştiremezsiniz"));
            e.cancel = true;
            return false;
        }
    }

    async onAppointmentUpdated(e: any) {

        // Bu kod kapalı ilen içi değiştirildi açılıp Hata alınırsa tekrar bakılmalı
        let _object = this._nursingOrderScheduleDetail.find(o => o.id.toString() === e.appointmentData.id);

        _object.startDate = e.appointmentData.startDate;
        _object.isChanged = true;

        let index = this.inPatientPhysicianApplicationFormViewModel._nursingOrderScheduleDetail.findIndex(o => o.id.toString() === e.appointmentData.id); // Wiev model yanlız upadet gören nursing oreder detailları taşır
        if (index < 0)
            this.inPatientPhysicianApplicationFormViewModel._nursingOrderScheduleDetail.push(_object);
        else
            this.inPatientPhysicianApplicationFormViewModel._nursingOrderScheduleDetail[index] = _object;
    }


    async onDietAppointmentUpdated(e: any) {

        // Bu kod kapalı ilen içi değiştirildi açılıp Hata alınırsa tekrar bakılmalı
        let _object = this._dietOrderScheduleDetail.find(o => o.id.toString() === e.appointmentData.id);

        _object.startDate = e.appointmentData.startDate;
        _object.isChanged = true;

        let index = this.inPatientPhysicianApplicationFormViewModel._dietOrderScheduleDetail.findIndex(o => o.id.toString() === e.appointmentData.id); // Wiev model yanlız upadet gören nursing oreder detailları taşır
        if (index < 0)
            this.inPatientPhysicianApplicationFormViewModel._dietOrderScheduleDetail.push(_object);
        else
            this.inPatientPhysicianApplicationFormViewModel._dietOrderScheduleDetail[index] = _object;

    }

    //Hemşire Direktifleri Sekmesi
    public _nursingOrderScheduleDetail: Array<OrderScheduleDetail> = new Array<OrderScheduleDetail>();
    onNursingOrderScheduleDetailOptionChanged(e: any) {
        let startDate: Date = null;
        let endDate: Date = null;
        let selectedDate: Date = null;
        let currentView = null;
        if (e && e.name) {
            if (e.component && e.component._options) {
                if (e.name == "resources") { // ilk açılldığında
                    selectedDate = e.component._options.currentDate;
                    currentView = e.component._options.currentView;
                    if (currentView == "agenda" || (currentView != null && currentView.type == "week")) {
                        currentView = "week";
                    }
                }
                if (e.name == "currentDate") {
                    selectedDate = e.value;
                    currentView = e.component._options.currentView;
                    if (currentView == "agenda" || (currentView != null && currentView.type == "week")) {
                        currentView = "week";
                    }
                }
                if (e.name == "currentView") { // gün ay yıl geçişinde çalışır
                    selectedDate = e.component._options.currentDate;
                    currentView = e.value;
                    let previousView = e.previousValue;
                    if ((currentView == "agenda" || currentView == "week") && previousView == "day") {
                        currentView = "week";
                    }
                    else if (currentView == "day") {
                        currentView = ""; // Güne geçildiğinde zaten bir önceki view ya month ya da week olduğu için aşağıdaki null kontrolüne takılıp tekrar load edilmesin diye currentview null yapılır
                    }
                }
            }
            if (currentView != null && selectedDate != null) {

                if (currentView == "day") {
                    startDate = selectedDate.AddDays(-3);
                    endDate = selectedDate.AddDays(4);
                }
                else if (currentView == "week") {
                    startDate = selectedDate;
                    endDate = selectedDate.AddDays(7);
                }
                else if (currentView == "month") {

                    let mount = selectedDate.getMonth();
                    let year = selectedDate.getFullYear();
                    startDate = new Date(year, mount, 1);
                    endDate = new Date(year, mount + 1, 0);
                }
            }
            this.GetNursingOrderDetailsByDate(startDate, endDate);
        }

    }

    GetNursingOrderDetailsByDate(startDate: Date, endDate: Date) {

        if (startDate != null && endDate != null) {
            let that = this;
            let startDateString: string = this.datePipe.transform(startDate, 'dd.MM.yyyy');
            let endDateString: string = this.datePipe.transform(endDate, 'dd.MM.yyyy');

            let dateToAdd = startDate;
            let needToLoad: boolean = false;
            if (this.nursingOrderScheduleDetailLoadedDateList.length > 0) {
                while (dateToAdd <= endDate) {
                    if (this.nursingOrderScheduleDetailLoadedDateList.indexOf(dateToAdd.ToShortDateString()) == -1) {
                        needToLoad = true;
                        break;
                    }
                    dateToAdd = dateToAdd.AddDays(1);
                }
            }
            else
                needToLoad = true;

            if (needToLoad) {
                this.httpService.get<Array<OrderScheduleDetail>>("api/InPatientPhysicianApplicationService/GetNursingOrderDetailsByDate?StartDate=" + startDateString + "&EndDate=" + endDateString +
                    "&inPatientPhysicianApplicationObjectID=" + this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.ObjectID.toString())
                    .then(result => {
                        let neworderScheduleDetailList: Array<OrderScheduleDetail> = result as Array<OrderScheduleDetail>;

                        if (that._nursingOrderScheduleDetail == null || that._nursingOrderScheduleDetail.length == 0)
                            that._nursingOrderScheduleDetail = neworderScheduleDetailList;
                        else {
                            let concatedOrderScheduleDetailList = that._nursingOrderScheduleDetail.concat(neworderScheduleDetailList.filter(dr => that.nursingOrderScheduleDetailLoadedDateList.indexOf(Convert.ToDateTime(dr.startDate).ToShortDateString()) == -1));
                            that._nursingOrderScheduleDetail = concatedOrderScheduleDetailList;
                        }

                        dateToAdd = startDate;
                        while (dateToAdd <= endDate) {
                            if (that.nursingOrderScheduleDetailLoadedDateList.indexOf(dateToAdd.ToShortDateString()) == -1)
                                that.nursingOrderScheduleDetailLoadedDateList.unshift(dateToAdd.ToShortDateString());
                            dateToAdd = dateToAdd.AddDays(1);
                        }

                    })
                    .catch(error => {
                        that.messageService.showError(error);
                    });
            }
        }
    }

    // Diet
    public _dietOrderScheduleDetail: Array<OrderScheduleDetail> = new Array<OrderScheduleDetail>();
    onDietScheduleDetailOptionChanged(e: any) {
        let startDate: Date = null;
        let endDate: Date = null;
        let selectedDate: Date = null;
        let currentView = null;
        if (e && e.name) {
            if (e.component && e.component._options) {
                if (e.name == "resources") { // ilk açılldığında
                    selectedDate = e.component._options.currentDate;
                    currentView = e.component._options.currentView;
                    if (currentView == "agenda" || (currentView != null && currentView.type == "week")) {
                        currentView = "week";
                    }
                }
                if (e.name == "currentDate") {
                    selectedDate = e.value;
                    currentView = e.component._options.currentView;
                    if (currentView == "agenda" || (currentView != null && currentView.type == "week")) {
                        currentView = "week";
                    }
                }
                if (e.name == "currentView") { // gün ay yıl geçişinde çalışır
                    selectedDate = e.component._options.currentDate;
                    currentView = e.value;
                    let previousView = e.previousValue;
                    if ((currentView == "agenda" || currentView == "week") && previousView == "day") {
                        currentView = "week";
                    }
                    else if (currentView == "day") {
                        currentView = ""; // Güne geçildiğinde zaten bir önceki view ya month ya da week olduğu için aşağıdaki null kontrolüne takılıp tekrar load edilmesin diye currentview null yapılır
                    }
                }
            }
            if (currentView != null && selectedDate != null) {

                if (currentView == "day") {
                    startDate = selectedDate.AddDays(-3);
                    endDate = selectedDate.AddDays(4);
                }
                else if (currentView == "week") {
                    startDate = selectedDate;
                    endDate = selectedDate.AddDays(7);
                }
                else if (currentView == "month") {

                    let mount = selectedDate.getMonth();
                    let year = selectedDate.getFullYear();
                    startDate = new Date(year, mount, 1);
                    endDate = new Date(year, mount + 1, 0);
                }
            }
            this.GetDietOrderDetailsByDate(startDate, endDate);
        }

    }

    RefreshFindingGrid(event: any) {
        this.showRichTextBoxPopup = false;
        this.lastSelectedCovidIzlemId = "";
        this.ozellikliIzlemIdContainer.ozellikliIzlemObjectID = null;
        this.isLastSelectedProgressCovid = false;
        let date: Date = new Date();
        date = date.AddDays(1);
        this.getInPatientPhysicianProgressesInfoViewModelByDate(date);
    }

    getInPatientPhysicianProgressesInfoViewModelByDate(inputDate: Date = null) {

        let that = this;
        let lastLoadedProgressesInfoDate: string = "";
        if (inputDate == null)
            lastLoadedProgressesInfoDate = this.datePipe.transform(this.inPatientPhysicianApplicationFormViewModel.lastLoadedProgressesInfoDate, 'dd.MM.yyyy');
        else
            lastLoadedProgressesInfoDate = this.datePipe.transform(inputDate, 'dd.MM.yyyy');

        this.httpService.get<InPatientPhysicianProgressesInfoViewModel>("api/InPatientPhysicianApplicationService/GetInPatientPhysicianProgressesInfoViewModelByDate?lastLoadedProgressesInfoDate="
            + lastLoadedProgressesInfoDate + "&inPatientPhysicianApplicationObjectID=" + this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.ObjectID.toString())
            .then(result => {
                let inPatientPhysicianProgressesInfoViewModel: InPatientPhysicianProgressesInfoViewModel = result as InPatientPhysicianProgressesInfoViewModel;

                //let subEpisode = that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.SubEpisode
                //if (subEpisode != null) {

                inPatientPhysicianProgressesInfoViewModel.ProgressesGridList.forEach(dr => {
                    let procedureDoctorObjectID = dr["ProcedureDoctor"];
                    if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
                        let procedureDoctor = that.inPatientPhysicianApplicationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                        if (procedureDoctor == null) {
                            procedureDoctor = inPatientPhysicianProgressesInfoViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());

                            if (procedureDoctor != null) {
                                that.inPatientPhysicianApplicationFormViewModel.ResUsers.push(procedureDoctor);
                            }
                        }
                        if (procedureDoctor != null) {
                            dr.ProcedureDoctor = procedureDoctor;
                        }
                    }
                });

                if (that.inPatientPhysicianApplicationFormViewModel.ProgressesGridList == null)
                    that.inPatientPhysicianApplicationFormViewModel.ProgressesGridList = inPatientPhysicianProgressesInfoViewModel.ProgressesGridList;
                else {
                    if (inputDate == null) {
                        let newProgressesGridListExceptOld = inPatientPhysicianProgressesInfoViewModel.ProgressesGridList.filter(newdr => that.inPatientPhysicianApplicationFormViewModel.ProgressesGridList.every(dr => dr.ObjectID != newdr.ObjectID) == true);
                        if (newProgressesGridListExceptOld != null || newProgressesGridListExceptOld.length > 0) {
                            let concatedProgressesGridList = that.inPatientPhysicianApplicationFormViewModel.ProgressesGridList.concat(newProgressesGridListExceptOld);
                            that.inPatientPhysicianApplicationFormViewModel.ProgressesGridList = concatedProgressesGridList;
                        }
                    } else {
                        that.inPatientPhysicianApplicationFormViewModel.ProgressesGridList = inPatientPhysicianProgressesInfoViewModel.ProgressesGridList;
                    }
                }
                if (inPatientPhysicianProgressesInfoViewModel.lastLoadedProgressesInfoDate < that.inPatientPhysicianApplicationFormViewModel.lastLoadedProgressesInfoDate)
                    that.inPatientPhysicianApplicationFormViewModel.lastLoadedProgressesInfoDate = inPatientPhysicianProgressesInfoViewModel.lastLoadedProgressesInfoDate;

                //}
                this.physicianProgressesGrid.instance.refresh();
            })
            .catch(error => {
                that.messageService.showError(error);
            });

    }

    GetDietOrderDetailsByDate(startDate: Date, endDate: Date) {

        if (startDate != null && endDate != null) {
            let that = this;
            let startDateString: string = this.datePipe.transform(startDate, 'dd.MM.yyyy');
            let endDateString: string = this.datePipe.transform(endDate, 'dd.MM.yyyy');

            let dateToAdd = startDate;
            let needToLoad: boolean = false;
            if (this.dietOrderScheduleDetailLoadedDateList.length > 0) {
                while (dateToAdd <= endDate) {
                    if (this.dietOrderScheduleDetailLoadedDateList.indexOf(dateToAdd.ToShortDateString()) == -1) {
                        needToLoad = true;
                        break;
                    }
                    dateToAdd = dateToAdd.AddDays(1);
                }
            }
            else
                needToLoad = true;

            if (needToLoad) {
                this.httpService.get<Array<OrderScheduleDetail>>("api/InPatientPhysicianApplicationService/GetDietOrderDetailsByDate?StartDate=" + startDateString + "&EndDate=" + endDateString +
                    "&inPatientPhysicianApplicationObjectID=" + this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.ObjectID.toString())
                    .then(result => {
                        let neworderScheduleDetailList: Array<OrderScheduleDetail> = result as Array<OrderScheduleDetail>;

                        if (that._dietOrderScheduleDetail == null || that._dietOrderScheduleDetail.length == 0)
                            that._dietOrderScheduleDetail = neworderScheduleDetailList;
                        else {
                            let concatedOrderScheduleDetailList = that._dietOrderScheduleDetail.concat(neworderScheduleDetailList.filter(dr => that.dietOrderScheduleDetailLoadedDateList.indexOf(Convert.ToDateTime(dr.startDate).ToShortDateString()) == -1));
                            that._dietOrderScheduleDetail = concatedOrderScheduleDetailList;
                        }

                        dateToAdd = startDate;
                        while (dateToAdd <= endDate) {
                            if (that.dietOrderScheduleDetailLoadedDateList.indexOf(dateToAdd.ToShortDateString()) == -1)
                                that.dietOrderScheduleDetailLoadedDateList.unshift(dateToAdd.ToShortDateString());
                            dateToAdd = dateToAdd.AddDays(1);
                        }

                    })
                    .catch(error => {
                        that.messageService.showError(error);
                    });
            }
        }
    }

    //Diet


    onTabItemRendered(e: any) {
        let selectedItem: string = e.addedItems[0].title;
        if (selectedItem === i18n("M10657", "Aktif Direktifler")) {
            let that = this;
            this.prepareNursinOrderSchedule();
            setTimeout(function () {
                that._nodscheduler.instance.repaint();
            }, 300);
        }
        else if (selectedItem === i18n("M10656", "Aktif Direktif Planlamaları")) {
            let that = this;
            this.prepareNursingOrderDetailScheduleResource();
            setTimeout(function () {
                that._noddetailscheduler.instance.repaint();
            }, 300);
        }
        else if (selectedItem == i18n("M24106", "Verilen Diyetler")) {
            let that = this;
            this.prepareDietOrderSchedule();
            setTimeout(function () {
                that._dietscheduler.instance.repaint();
            }, 300);
        }
        else if (selectedItem === i18n("M24105", "Verilen Diyet Detayları")) {
            let that = this;
            this.prepareDietOrderDetailScheduleResource();
            setTimeout(function () {
                that._dietdetailscheduler.instance.repaint();
            }, 300);
        }
    }

    async cancelNursingOrder(e, b) {
        let rejectReason: string = await InputForm.GetText(i18n("M16559", "İptal Nedenini Giriniz."));

        if (String.isNullOrEmpty(rejectReason))
            this.messageService.showInfo(i18n("M16558", "İptal Nedeni Girmeden İşleme Devam Edemezsiniz."));
        else {
            let that = this;

            that.httpService.get<any>("api/InPatientPhysicianApplicationService/CancelNursingOrder?ObjectID=" + e.appointmentData.id + "&ReasonOfCancel=" + rejectReason)
                .then(response => {
                    that.messageService.showSuccess(i18n("M23794", "Uygulanmamış orderlar başarılı bir şekilde iptal edildi."));
                    let no: NursingOrder = that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.NursingOrders.find(p => p.ObjectID == e.appointmentData.id);
                    no.CurrentStateDefID = NursingOrder.NursingOrderStates.Cancelled;
                    let nu: number = that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.NursingOrders.findIndex(p => p.ObjectID == e.appointmentData.id);
                    that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.NursingOrders.splice(nu, 1);

                    nu = this.nursingOrderScheduleDetailLoadedDateList.findIndex(p => p == e.appointmentData.startDate.ToShortDateString());

                    if (nu >= 0)//performans için bi kere yüklenen tarih tekrar yüklenmiyor ama burda veri değiştiği için çıkarıp tekrar yüklenebilmesi sağlanıyor
                        this.nursingOrderScheduleDetailLoadedDateList.splice(nu, 1);

                    that.prepareNursinOrderSchedule();
                    setTimeout(function () {
                        that._nodscheduler.instance.repaint();
                    }, 300);
                })
                .catch(error => {
                    this.messageService.showError(error);

                });
        }
    }

    async cancelDietOrder(e, dietChange: boolean) {
        let rejectReason: string = await InputForm.GetText(i18n("M16559", "İptal Nedenini Giriniz."));

        if (String.isNullOrEmpty(rejectReason))
            this.messageService.showInfo(i18n("M16558", "İptal Nedeni Girmeden İşleme Devam Edemezsiniz."));
        else {
            let that = this;

            that.httpService.get<any>("api/InPatientPhysicianApplicationService/CancelDietOrder?ObjectID=" + e.appointmentData.id + "&ReasonOfCancel=" + rejectReason)
                .then(response => {
                    that.messageService.showSuccess(i18n("M23794", "Uygulanmamış orderlar başarılı bir şekilde iptal edildi."));
                    let no: DietOrder = that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.DietOrders.find(p => p.ObjectID == e.appointmentData.id);
                    no.CurrentStateDefID = DietOrder.DietOrderStates.Cancelled;
                    let nu: number = that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.DietOrders.findIndex(p => p.ObjectID == e.appointmentData.id);
                    that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.DietOrders.splice(nu, 1);

                    nu = this.dietOrderScheduleDetailLoadedDateList.findIndex(p => p == e.appointmentData.startDate.ToShortDateString());

                    if (nu >= 0)//performans için bi kere yüklenen tarih tekrar yüklenmiyor ama burda veri değiştiği için çıkarıp tekrar yüklenebilmesi sağlanıyor
                        this.dietOrderScheduleDetailLoadedDateList.splice(nu, 1);

                    that.prepareDietOrderSchedule();
                    setTimeout(function () {
                        that._dietscheduler.instance.repaint();
                    }, 300);
                })
                .catch(error => {
                    this.messageService.showError(error);

                });
        }
    }

    comfirmRowDeleting(data) {
        if (data != null) {
            // if (data.IsNew == true)
            // {
            //     this.messageService.showSuccess(i18n("M19735", "Order Başarılı bir şekilde silindi"));
            //     return true;
            // }
            if (data.IsNew == false) {
                // throw new Exception("Kaydedilmiş orderları silemezsiniz.\nOrder\'ı durdurmak için aktif direktifler sekmesini kullanabilirsiniz.");
                this.messageService.showError(i18n("M17384", "Kaydedilmiş orderları silemezsiniz.\nOrder\'ı durdurmak için aktif direktifler sekmesini kullanabilirsiniz."));
                return false;
            }
        }
        //console.log(data);
        //let that = this;

        //let jqDeferred = jQuery.Deferred();
        //data.cancel = jqDeferred;

        //if (data.ObjectID == undefined)//eklenmiş ama kaydedilmemiş
        //{
        //    jqDeferred.resolve(false);
        //    that.messageService.showSuccess("Order Başarılı bir şekilde silindi");
        //}
        //else {
        //    jqDeferred.resolve(true);
        //    throw new Exception("Kaydedilmiş orderları silemezsiniz.\nOrder\'ı durdurmak için aktif direktifler sekmesini kullanabilirsiniz.");
        //   // that.messageService.showError("Kaydedilmiş orderları silemezsiniz.\nOrder\'ı durdurmak için aktif direktifler sekmesini kullanabilirsiniz.");

        //}
        // if(new Date(event.data.PeriodStartTime.ToShortDateString()) < new Date(that.currentDate.ToShortDateString()))
        // {
        //     jqDeferred.resolve(true);
        //     that.messageService.showError("Geçmiş Tarihli Orderları Silemezsin");

        // }
        // else{

        //    jqDeferred.resolve(false);
        //     that.messageService.showSuccess("Order Başarılı bir şekilde silindi");

        // }
    }

    grdDietOrderRowPre(event) {
        //TODO:ismail iptal edilenlerin arka planını kırmızı yapmak için bi tasatım gerekiyor
        //if (event.rowType == "data" && event.data.CurrentStateDefID == DietOrder.DietOrderStates.Cancelled)
        //    event.rowElement.firstItem().bgColor = "red";
    }

    public setENabizViewModel(viewModels: Array<any>) {

        for (let i = 0; i < viewModels.length; i++) {
            this.inPatientPhysicianApplicationFormViewModel.ENabizViewModels.push(viewModels[i]);
        }

    }

    public setMaxProgressDate(progressDate: Date) {
        let maxDate: Date = this.currentDate;

        if ((this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.CurrentStateDefID == InPatientPhysicianApplication.InPatientPhysicianApplicationStates.PreDischarged
            || this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.CurrentStateDefID == InPatientPhysicianApplication.InPatientPhysicianApplicationStates.Discharged)
            && maxDate > this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicDischargeDate)
            maxDate = Convert.ToDateTime(this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp.ClinicDischargeDate);

        return maxDate;
    }


    //disableRequestForms(data: any) {
    //    if (this.procedureRequestForm != undefined) {
    //        this.procedureRequestForm.disableRequestForms(data);
    //        this.mostUsedProcedureRequestForm.disableRequestForms(data);
    //    }
    //}


    // Begin NursinOrderTemplate
    btnAddNursingOrderTemp_Click() {
        this.NOrderTempDetail = new Array<NursingOrderTemplateDetail>();
        this.selectedRowKeysResultList = new Array<NursingOrderTemplateDetail>();

        for (let req of this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.NursingOrders) {
            if (req.ObjectID == null) {
                let nOrder: NursingOrderTemplateDetail = new NursingOrderTemplateDetail();
                nOrder.AmountForPeriod = req.AmountForPeriod;
                nOrder.RecurrenceDayAmount = req.RecurrenceDayAmount;
                nOrder.Frequency = req.Frequency;
                nOrder.NursingOrderObject = req.ProcedureObject;
                nOrder.NursingOrderObject['TempOrderName'] = req.ProcedureObject.Name;

                this.NOrderTempDetail.push(nOrder);
                this.selectedRowKeysResultList.push(nOrder);
            }
        }

        if (this.NOrderTempDetail.length > 0) {
            this.showNursingOrderPopup = true;
            this.fromTemplateSave = true;
            this.fromTemplateGet = false;
        }
        else
            this.messageService.showError(i18n("M22451", "Şablon olarak eklenecek direktif bulunamadığı için sayfa açılamadı."));


    }

    async btnSaveNursingOrderTemplate_Click() {
        if (this.txtNursingOrderTemplateName == null || this.txtNursingOrderTemplateName == "") {
            this.messageService.showInfo(i18n("M22436", "Şablon Adı Boş Geçilemez"));
            return false;
        }

        this.showNursingOrderPopup = false;

        let that = this;
        let nOrderTemplate: NursingOrderTemplate = new NursingOrderTemplate();
        let nOrderTemplateDetails = new Array<NursingOrderTemplateDetail>();
        let _saveNursingOrderTemplateViewModel: SaveNursingOrderTemplateViewModel = new SaveNursingOrderTemplateViewModel();

        nOrderTemplate.Name = this.txtNursingOrderTemplateName;
        nOrderTemplate.OwnerResource = new Resource();

        //nOrderTemplate.OrderTemplateDetails = new Array <NursingOrderTemplateDetail>();
        nOrderTemplateDetails = this.selectedRowKeysResultList;

        _saveNursingOrderTemplateViewModel.PackageTemplateDef = nOrderTemplate;
        _saveNursingOrderTemplateViewModel.OrderTemplateDetails = nOrderTemplateDetails;

        let apiUrl: string = 'api/InpatientPhysicianApplicationService/SaveNursingOrderTemplate';
        let result = await this.httpService.post(apiUrl, _saveNursingOrderTemplateViewModel);

        this.NOrderTempDetail = new Array<NursingOrderTemplateDetail>();
        this.selectedRowKeysResultList = new Array<NursingOrderTemplateDetail>();
        this.txtNursingOrderTemplateName = "";

    }

    async btnGetNursingOrderTemp_Click() {
        this.NOrderTempDetail = new Array<NursingOrderTemplateDetail>();
        this.selectedRowKeysResultList = new Array<NursingOrderTemplateDetail>();

        let that = this;
        //yeni nesne oluştururken servise gitmek gerekiyor ki objectId vs oluşsun
        //oluşmaz ise relationları bağlayamıyor
        that.httpService.get<NursingOrderTemplate>("/api/InpatientPhysicianApplicationService/GetNursingOrderTemplate")
            .then(response => {

                that.nursingOrderTempSource = new DataSource({
                    store: response,
                    searchOperation: "contains",
                    searchExpr: "Name"
                });

                this.showNursingOrderPopup = true;
                this.fromTemplateSave = false;
                this.fromTemplateGet = true;
            })
            .catch(error => {
                that.messageService.showError(error);

            });
    }

    async btnGetNursingOrderTempDetail_Click($event) {
        let that = this;
        //yeni nesne oluştururken servise gitmek gerekiyor ki objectId vs oluşsun
        //oluşmaz ise relationları bağlayamıyor
        that.httpService.get<NursingOrderTemplateDetail[]>("/api/InpatientPhysicianApplicationService/GetNursingOrderTempDetail?TempID=" + $event.itemData.ObjectID)
            .then(response => {

                that.NOrderTempDetail = response;
                that.selectedRowKeysResultList = response;

                for (let req of that.NOrderTempDetail) {
                    let aa = req.NursingOrderObject.toString();
                    let noo = that.inPatientPhysicianApplicationFormViewModel.VitalSignAndNursingDefinitionList.find(p => p.ObjectID.toString() === aa);

                    if (noo != undefined) {
                        req.NursingOrderObject = noo;
                        req.NursingOrderObject['TempOrderName'] = noo.Name;
                    }

                }
            })
            .catch(error => {
                that.messageService.showError(error);

            });
    }

    btnaddTempDetailToGrid_Click() {
        for (let req of this.selectedRowKeysResultList) {
            this.selectNursingOrder(req, true, true);
        }
        this.showNursingOrderPopup = false;
    }

    //EndNursingOrderTemplate


    public openENabiz(): void {
        this.helpMenuService.showPatientENabizInfo(this.getClickFunctionParams());
    }

    colorPresClick() {
        let input: OpenColorPrescription_Input = new OpenColorPrescription_Input();
        input.SubEpisodeObjectID = new Guid(this._InPatientPhysicianApplication.SubEpisode.ObjectID.toString());
        let fullApiUrl: string = 'api/DrugOrderIntroductionService/OpenColorPrescriptionWithJSON';
        this.httpService.post(fullApiUrl, input).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public async openEDurumBildirirReport() {
        let parameterValue = await this.helpMenuService.getEDurumBildirirParameter();
        if (parameterValue)
            this.showEDurumBildirirComponent = true;
        else {
            this.helpMenuService.openEDurumBildirirReportPopUp(this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.ObjectID.toString());
        }
    }

    public async onlistBoxTreatmentResultChanged(event): Promise<void> {
        if (event != null) {
            if (this.inPatientPhysicianApplicationFormViewModel != null && this.inPatientPhysicianApplicationFormViewModel.TreatmentResult !== event) {
                this.inPatientPhysicianApplicationFormViewModel.TreatmentResult = event;
                if (!this.inPatientPhysicianApplicationFormViewModel.HasMorgue) {
                    if (this.inPatientPhysicianApplicationFormViewModel.TreatmentResult.KODU == "6")
                        this.getMorgueEpisodeAction();
                    else
                        this.inPatientPhysicianApplicationFormViewModel._MorgueViewModel = null;

                }
                else {
                    if (this.inPatientPhysicianApplicationFormViewModel.TreatmentResult.KODU != "6") { //Daha önce morg işlemi başlatılmış bir hastanın taburcu tipi değiştirildiyse
                        let morgueCancelMsg: string = i18n("M15512", "Hastaya başlatılmış morg işlemi bulunmaktadır.Taburcu tipini değiştirirseniz morg işlemi iptal edilecektir. Devam etmek istiyor musunuz?");

                        let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), '', morgueCancelMsg);
                        if (result === 'H')
                            this.inPatientPhysicianApplicationFormViewModel.TreatmentResult = this.inPatientPhysicianApplicationFormViewModel.DeathDefinition;
                    }
                }


            }


        }
        else
            this.inPatientPhysicianApplicationFormViewModel.TreatmentResult = event;

    }

    getMorgueEpisodeAction() {

        let episodeID: Guid = this._InPatientPhysicianApplication.Episode.ObjectID;
        this.episodeActionHelper.getNewEpisodeAction(Morgue.ObjectDefID, episodeID, Morgue.MorgueStates.Request).then(result => {
            let morgue: Morgue = result as Morgue;
            this.openMorgueExDischargeForm(morgue).then(result => {
                let modalActionResult = result as ModalActionResult;

            });
        }).catch(err => {
            this.messageService.showError(err);
        });
    }

    openMorgueExDischargeForm(morgue: Morgue): Promise<ModalActionResult> {
        let that = this;
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "MorgueExDischargeForm";
            componentInfo.ModuleName = "MorgModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Morg_Modulu/MorgModule";
            componentInfo.objectID = "";

            let selectedActionID: Guid = <any>that._InPatientPhysicianApplication.ObjectID;
            componentInfo.InputParam = new DynamicComponentInputParam(true, new ActiveIDsModel(selectedActionID, null, null));


            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M19128", "Morg İşlemleri");
            modalInfo.Width = 1000;
            modalInfo.Height = 760;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
                let morgueVM: MorgueExDischargeFormViewModel = inner.Param as MorgueExDischargeFormViewModel;
                if (morgueVM === undefined)
                    this.inPatientPhysicianApplicationFormViewModel.TreatmentResult = null;
                else {
                    this.inPatientPhysicianApplicationFormViewModel._MorgueViewModel = morgueVM;
                }
                //formu doldurmazsa taburcu şeklini resetle
            }).catch(err => {
                reject(err);
            });
        });
    }

    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();
        //#region Medula İşlemleri
        let takipAl = new DynamicSidebarMenuItem();
        takipAl.key = 'takipal';
        takipAl.label = i18n("M22634", "Takip Al");
        takipAl.icon = 'ai ai-takip-al';
        takipAl.componentInstance = this;
        takipAl.clickFunction = this.takipAl;
        this.sideBarMenuService.addMenu('YardimciMenu', takipAl);

        let takipOku = new DynamicSidebarMenuItem();
        takipOku.key = 'takipOku';
        takipOku.icon = 'ai ai-takip-oku';
        takipOku.label = i18n("M22663", "Takip Oku");
        takipOku.componentInstance = this;
        takipOku.clickFunction = this.takipOku;
        this.sideBarMenuService.addMenu('YardimciMenu', takipOku);

        let tedaviTipiDegistir = new DynamicSidebarMenuItem();
        tedaviTipiDegistir.key = 'tedaviTipiDegistir';
        tedaviTipiDegistir.label = i18n("M22634", "Tedavi Tipini Değiştir");
        tedaviTipiDegistir.icon = 'ai ai-takip-al';
        tedaviTipiDegistir.componentInstance = this;
        tedaviTipiDegistir.clickFunction = this.tedaviTipiDegistir;
        this.sideBarMenuService.addMenu('YardimciMenu', tedaviTipiDegistir);

        let yatısCikisOku = new DynamicSidebarMenuItem();
        yatısCikisOku.key = 'yatısCikisOku';
        yatısCikisOku.label = i18n("M22634", "Yatış Çıkış Oku");
        yatısCikisOku.icon = 'ai ai-takip-al';
        yatısCikisOku.componentInstance = this;
        yatısCikisOku.clickFunction = this.yatısCikisOku;
        this.sideBarMenuService.addMenu('YardimciMenu', yatısCikisOku);

        //let yatısCikisYap = new DynamicSidebarMenuItem();
        //yatısCikisYap.key = 'yatısCikisYap';
        //yatısCikisYap.label = i18n("M22634", "Yatış Çıkış Yap");
        //yatısCikisYap.icon = 'ai ai-takip-al';
        //yatısCikisYap.componentInstance = this;
        //yatısCikisYap.clickFunction = this.yatısCikisYap;
        //this.sideBarMenuService.addMenu('YardimciMenu', yatısCikisYap);

        //let yatısCikisIptal = new DynamicSidebarMenuItem();
        //yatısCikisIptal.key = 'yatısCikisIptal';
        //yatısCikisIptal.label = i18n("M22634", "Yatış Çıkış İptal");
        //yatısCikisIptal.icon = 'ai ai-takip-al';
        //yatısCikisIptal.componentInstance = this;
        //yatısCikisIptal.clickFunction = this.yatısCikisIptal;
        //this.sideBarMenuService.addMenu('YardimciMenu', yatısCikisIptal);
        //#endregion Medula İşlemleri

        let openPatientSgkReports = new DynamicSidebarMenuItem();
        openPatientSgkReports.key = 'openPatientSgkReports';
        openPatientSgkReports.icon = 'fa fa-file-alt';
        openPatientSgkReports.label = 'SGK Raporları Sorgula';
        openPatientSgkReports.componentInstance = this;
        openPatientSgkReports.clickFunction = this.openERaporSorgulaComponent;
        openPatientSgkReports.parameterFunctionInstance = this;
        //printEpicrisisForm.getParamsFunction = this.getClickFunctionParams;
        openPatientSgkReports.ParentInstance = this;
        this.sideBarMenuService.addMenu('ReportMainItem', openPatientSgkReports);


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
        colorPrescription.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', colorPrescription);

        //if (this.hasRoleForPrescriptionApproval === true) {
        let colorPrescriptionForApproval = new DynamicSidebarMenuItem();
        colorPrescriptionForApproval.key = 'colorPrescriptionForApproval';
        colorPrescriptionForApproval.icon = 'ai ai-recete-onay';
        colorPrescriptionForApproval.label = 'Reçete Onay';
        colorPrescriptionForApproval.componentInstance = this.helpMenuService;
        colorPrescriptionForApproval.clickFunction = this.helpMenuService.openColorPrescriptionForApproval_Ehu;
        this.sideBarMenuService.addMenu('YardimciMenu', colorPrescriptionForApproval);
        //}

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


        let surgery = new DynamicSidebarMenuItem();
        surgery.key = 'surgery';
        surgery.icon = 'ai ai-ameliyat-istek';
        surgery.label = i18n("M10815", "Ameliyat İstek");
        surgery.componentInstance = this.helpMenuService;
        surgery.clickFunction = this.helpMenuService.openSurgery;
        surgery.parameterFunctionInstance = this;
        surgery.getParamsFunction = this.getClickFunctionParams;
        surgery.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', surgery);

        let surgeryAppointment = new DynamicSidebarMenuItem();
        surgeryAppointment.key = 'surgeryAppointment';
        surgeryAppointment.icon = 'ai ai-ameliyat-istek';
        surgeryAppointment.label = i18n("M10815", "Ameliyat Randevusu");
        surgeryAppointment.componentInstance = this;
        surgeryAppointment.clickFunction = this.showSurgeryAppointmentFormPopUp;
        surgeryAppointment.parameterFunctionInstance = this;
        surgeryAppointment.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', surgeryAppointment);

        let inpatientAdmission = new DynamicSidebarMenuItem();
        inpatientAdmission.key = 'inpatientAdmission';
        inpatientAdmission.icon = 'ai ai-hasta-yatis-bilgi';
        inpatientAdmission.label = 'Hasta Yatış Bilgileri';
        inpatientAdmission.componentInstance = this.helpMenuService;
        inpatientAdmission.clickFunction = this.helpMenuService.openInpatientAdmission;
        inpatientAdmission.parameterFunctionInstance = this;
        inpatientAdmission.getParamsFunction = this.getClickFunctionParams;
        inpatientAdmission.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', inpatientAdmission);

        if (this._InPatientPhysicianApplication.InPatientTreatmentClinicApp != null) {
            if (this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.IsDailyOperation != true) {
                let inpatientTreatmentClinicApp = new DynamicSidebarMenuItem();
                inpatientTreatmentClinicApp.key = 'inpatientTreatmentClinicApp';
                inpatientTreatmentClinicApp.icon = 'ai ai-yatan-hasta-klinik';
                inpatientTreatmentClinicApp.label = 'Yatan Hasta Klinik İşlemleri';
                inpatientTreatmentClinicApp.componentInstance = this.helpMenuService;
                inpatientTreatmentClinicApp.clickFunction = this.helpMenuService.openInpatientTreatmentClinicApp;
                inpatientTreatmentClinicApp.parameterFunctionInstance = this;
                inpatientTreatmentClinicApp.getParamsFunction = this.getClickFunctionParams;
                inpatientTreatmentClinicApp.ParentInstance = this;
                this.sideBarMenuService.addMenu('YardimciMenu', inpatientTreatmentClinicApp);
            }
        }

        let nabizMessage = new DynamicSidebarMenuItem();
        nabizMessage.key = 'nabizMessage';
        nabizMessage.icon = 'ai ai-enabiz-mesaj-gonder';
        nabizMessage.label = i18n("M13710", "E-Nabız Mesaj Gönder");
        nabizMessage.componentInstance = this.helpMenuService;
        nabizMessage.clickFunction = this.helpMenuService.onSendENabizMessageOpen;
        this.sideBarMenuService.addMenu('YardimciMenu', nabizMessage);

        let printInpatientTreatmentBarcode = new DynamicSidebarMenuItem();
        printInpatientTreatmentBarcode.key = 'printInpatientTreatmentBarcode';
        printInpatientTreatmentBarcode.icon = 'ai ai-barkod-bas';
        printInpatientTreatmentBarcode.label = 'Yatan Hasta Barkodu Bas';
        printInpatientTreatmentBarcode.componentInstance = this.helpMenuService;
        printInpatientTreatmentBarcode.clickFunction = this.helpMenuService.printInpatientTreatmentBarcode;
        printInpatientTreatmentBarcode.parameterFunctionInstance = this;
        printInpatientTreatmentBarcode.getParamsFunction = this.getClickFunctionParams;
        printInpatientTreatmentBarcode.ParentInstance = this;
        this.sideBarMenuService.addMenu('Barkod', printInpatientTreatmentBarcode);

        let printInpatientBarcode = new DynamicSidebarMenuItem();
        printInpatientBarcode.key = 'printInpatientBarcode';
        printInpatientBarcode.icon = 'ai ai-barkod-bas';
        printInpatientBarcode.label = 'Hasta Bilekliği Bas';
        printInpatientBarcode.componentInstance = this.helpMenuService;
        printInpatientBarcode.clickFunction = this.helpMenuService.printInPatientWristBarcode;
        printInpatientBarcode.parameterFunctionInstance = this;
        printInpatientBarcode.getParamsFunction = this.getClickFunctionParams;
        printInpatientBarcode.ParentInstance = this;
        this.sideBarMenuService.addMenu('Barkod', printInpatientBarcode);

        let printEpicrisisForm = new DynamicSidebarMenuItem();
        printEpicrisisForm.key = 'epicrisisForm';
        printEpicrisisForm.icon = 'fa fa-file-text-o';
        printEpicrisisForm.label = 'Epikriz Formu';
        printEpicrisisForm.componentInstance = this;
        printEpicrisisForm.clickFunction = this.openEpicrisisReport;
        printEpicrisisForm.parameterFunctionInstance = this;
        //printEpicrisisForm.getParamsFunction = this.getClickFunctionParams;
        printEpicrisisForm.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', printEpicrisisForm);

        let printInPatientExaminationForm = new DynamicSidebarMenuItem();
        printInPatientExaminationForm.key = 'inPatientExaminationForm';
        printInPatientExaminationForm.icon = 'ai ai-doktor-muayene-formu';
        printInPatientExaminationForm.label = i18n("M13183", "Doktor Muayene Formu");
        printInPatientExaminationForm.componentInstance = this.helpMenuService;
        printInPatientExaminationForm.clickFunction = this.helpMenuService.printInPatientExaminationForm;
        printInPatientExaminationForm.parameterFunctionInstance = this;
        printInPatientExaminationForm.getParamsFunction = this.getClickFunctionParams;
        printInPatientExaminationForm.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', printInPatientExaminationForm);

        if (this.inPatientPhysicianApplicationFormViewModel.IsPhysiotherapyRequestFormUsing == true && this.inPatientPhysicianApplicationFormViewModel.HasAuthorityForPhysiotherapyRequest == true) {

            let openPhysiotherapyRequest = new DynamicSidebarMenuItem();
            openPhysiotherapyRequest.key = 'openPhysiotherapyRequest';
            openPhysiotherapyRequest.icon = 'ai ai-ftr-istek-ekle';
            openPhysiotherapyRequest.label = i18n("M14073", "F.T.R. İstek");
            openPhysiotherapyRequest.componentInstance = this.helpMenuService;
            openPhysiotherapyRequest.clickFunction = this.helpMenuService.openPhysiotherapyRequest;
            openPhysiotherapyRequest.parameterFunctionInstance = this;
            openPhysiotherapyRequest.getParamsFunction = this.getClickFunctionParams;
            openPhysiotherapyRequest.ParentInstance = this;
            this.sideBarMenuService.addMenu('YardimciMenu', openPhysiotherapyRequest);


            let openPhysiotherapyTreatmentNote = new DynamicSidebarMenuItem();
            openPhysiotherapyTreatmentNote.key = 'openPhysiotherapyTreatmentNote';
            openPhysiotherapyTreatmentNote.label = "F.T.R. Tedavi Seyri";
            openPhysiotherapyTreatmentNote.componentInstance = this.helpMenuService;
            openPhysiotherapyTreatmentNote.clickFunction = this.helpMenuService.openPhysiotherapyTreatmentNote;
            openPhysiotherapyTreatmentNote.parameterFunctionInstance = this;
            openPhysiotherapyTreatmentNote.getParamsFunction = this.getClickFunctionParams;
            openPhysiotherapyTreatmentNote.ParentInstance = this;
            this.sideBarMenuService.addMenu('YardimciMenu', openPhysiotherapyTreatmentNote);
        }

        let printOrthesisProsthesisReceptionReport = new DynamicSidebarMenuItem();
        printOrthesisProsthesisReceptionReport.key = 'printOrthesisProsthesisReceptionReport';
        printOrthesisProsthesisReceptionReport.icon = 'ai ai-ortez-protez-recete';
        printOrthesisProsthesisReceptionReport.label = i18n("M19787", "Ortez Protez Reçetesi");
        printOrthesisProsthesisReceptionReport.componentInstance = this.helpMenuService;
        printOrthesisProsthesisReceptionReport.clickFunction = this.helpMenuService.printOrthesisProsthesisReceptionReport;
        printOrthesisProsthesisReceptionReport.parameterFunctionInstance = this;
        printOrthesisProsthesisReceptionReport.getParamsFunction = this.getClickFunctionParams;
        printOrthesisProsthesisReceptionReport.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', printOrthesisProsthesisReceptionReport);

        let orthesisList = new DynamicSidebarMenuItem();
        orthesisList.key = 'orthesisList';
        orthesisList.icon = 'ai ai-kayitli-ortez-protez';
        orthesisList.label = 'Kayıtlı Ortez Protez Listesi';
        orthesisList.componentInstance = this.helpMenuService;
        orthesisList.clickFunction = this.helpMenuService.openOrthesisList;
        orthesisList.parameterFunctionInstance = this;
        orthesisList.getParamsFunction = this.getClickFunctionParams;
        orthesisList.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', orthesisList);

        let physioTherapyList = new DynamicSidebarMenuItem();
        physioTherapyList.key = 'physioTherapyList';
        physioTherapyList.icon = 'ai ai-kayitli-ftr';
        physioTherapyList.label = 'Kayıtlı F.T.R Listesi';
        physioTherapyList.componentInstance = this.helpMenuService;
        physioTherapyList.clickFunction = this.helpMenuService.openPhysioTherapyList;
        physioTherapyList.parameterFunctionInstance = this;
        physioTherapyList.getParamsFunction = this.getClickFunctionParams;
        physioTherapyList.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', physioTherapyList);

        if (this.inPatientPhysicianApplicationFormViewModel.HasAuthorityForObstetricInformationForm == true) {

            let openObstetric = new DynamicSidebarMenuItem();
            openObstetric.key = 'openObstetric';
            openObstetric.icon = 'ai ai-hamile';
            openObstetric.label = i18n("M14073", "Doğum İşlemleri");
            openObstetric.componentInstance = this.helpMenuService;
            openObstetric.clickFunction = this.helpMenuService.openBirthResult;
            openObstetric.parameterFunctionInstance = this;
            openObstetric.getParamsFunction = this.getClickFunctionParams;
            openObstetric.ParentInstance = this;
            this.sideBarMenuService.addMenu('YardimciMenu', openObstetric);
        }

        let dentistAdmission = new DynamicSidebarMenuItem();
        dentistAdmission.key = 'dentistAdmission';
        dentistAdmission.icon = 'ai ai-dis-kabul-al';
        dentistAdmission.label = 'Diş Kabulü';
        dentistAdmission.componentInstance = this;
        dentistAdmission.clickFunction = this.getDentistResource;
        this.sideBarMenuService.addMenu('YardimciMenu', dentistAdmission);
        if (this.enableInfluenzaHelpServiceButton) {
            let influenzaResult = new DynamicSidebarMenuItem();
            influenzaResult.key = 'influenzaResult';
            influenzaResult.icon = 'ai ai-virus';
            influenzaResult.label = 'Influenza Sonuç';
            influenzaResult.componentInstance = this.helpMenuService;
            influenzaResult.clickFunction = this.helpMenuService.UpdateInfluenzaResult;
            influenzaResult.parameterFunctionInstance = this;
            influenzaResult.getParamsFunction = this.getClickFunctionParams;
            influenzaResult.ParentInstance = this;
            this.sideBarMenuService.addMenu('YardimciMenu', influenzaResult);
        }


        let printInpatientAdmissionInfoByTreatmentClinicReport = new DynamicSidebarMenuItem();
        printInpatientAdmissionInfoByTreatmentClinicReport.key = 'printInpatientAdmissionInfoByTreatmentClinicReport';
        printInpatientAdmissionInfoByTreatmentClinicReport.icon = 'ai ai-hasta-yatis-formu';
        printInpatientAdmissionInfoByTreatmentClinicReport.label = i18n("M15342", "Hasta Yatış Formu");
        printInpatientAdmissionInfoByTreatmentClinicReport.componentInstance = this.helpMenuService;
        printInpatientAdmissionInfoByTreatmentClinicReport.clickFunction = this.helpMenuService.printInpatientAdmissionInfoByTreatmentClinicReport;
        printInpatientAdmissionInfoByTreatmentClinicReport.parameterFunctionInstance = this;
        printInpatientAdmissionInfoByTreatmentClinicReport.getParamsFunction = this.getClickFunctionParams;
        printInpatientAdmissionInfoByTreatmentClinicReport.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', printInpatientAdmissionInfoByTreatmentClinicReport);

        let printInpatientAllProceduresReport = new DynamicSidebarMenuItem();
        printInpatientAllProceduresReport.key = 'printInpatientAllProceduresReport';
        printInpatientAllProceduresReport.icon = 'far fa-file-alt';
        printInpatientAllProceduresReport.label = 'Tüm İşlem Raporu';
        printInpatientAllProceduresReport.componentInstance = this;
        printInpatientAllProceduresReport.clickFunction = this.showInpatientAllProceduresReport;
        printInpatientAllProceduresReport.parameterFunctionInstance = this;
        printInpatientAllProceduresReport.getParamsFunction = this.getClickFunctionParams;
        printInpatientAllProceduresReport.ParentInstance = this;
        this.sideBarMenuService.addMenu('ReportMainItem', printInpatientAllProceduresReport);


        let healthCommitteAdmission = new DynamicSidebarMenuItem();
        healthCommitteAdmission.key = 'healthCommitteAdmission';
        healthCommitteAdmission.icon = 'ai ai-saglik-kurulu-kabulu';
        healthCommitteAdmission.label = 'Sağlık Kurulu Kabulü';
        healthCommitteAdmission.componentInstance = this;
        healthCommitteAdmission.clickFunction = this.getHealthCommitteandReqReason;
        healthCommitteAdmission.parameterFunctionInstance = this;
        healthCommitteAdmission.getParamsFunction = this.getClickFunctionParams;
        healthCommitteAdmission.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', healthCommitteAdmission);


        let openHemodialysisRequest = new DynamicSidebarMenuItem();
        openHemodialysisRequest.key = 'openHemodialysisRequest';
        openHemodialysisRequest.icon = 'ai ai-hemodiyaliz-istek';
        openHemodialysisRequest.label = i18n("M14073", "Hemodiyaliz İstek");
        openHemodialysisRequest.componentInstance = this.helpMenuService;
        openHemodialysisRequest.clickFunction = this.helpMenuService.openHemodialysisRequest;
        openHemodialysisRequest.parameterFunctionInstance = this;
        openHemodialysisRequest.getParamsFunction = this.getClickFunctionParams;
        openHemodialysisRequest.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', openHemodialysisRequest);

        if (this.inPatientPhysicianApplicationFormViewModel.hasOrthesisRequestRole == true) {
            let ortezIstek = new DynamicSidebarMenuItem();
            ortezIstek.key = 'ortezIstek';
            ortezIstek.icon = 'ai ai-ortez-protez-ekle';
            ortezIstek.label = 'Ortez - Protez İstek';
            ortezIstek.componentInstance = this.helpMenuService;
            ortezIstek.clickFunction = this.helpMenuService.openOrthesisProcedure;
            ortezIstek.parameterFunctionInstance = this;
            ortezIstek.getParamsFunction = this.getClickFunctionParams;
            ortezIstek.ParentInstance = this;
            this.sideBarMenuService.addMenu('YardimciMenu', ortezIstek);
        }

        if (this.inPatientPhysicianApplicationFormViewModel.hasOpenEpisodeRole == true) {
            let openEpisode = new DynamicSidebarMenuItem();
            openEpisode.key = 'openEpisode';
            openEpisode.icon = 'fas fa-lock-open';
            openEpisode.label = 'Vakayı Aç';
            openEpisode.componentInstance = this.helpMenuService;
            openEpisode.clickFunction = this.helpMenuService.openEpisode;
            openEpisode.parameterFunctionInstance = this;
            openEpisode.getParamsFunction = this.getClickFunctionParams;
            openEpisode.ParentInstance = this;
            this.sideBarMenuService.addMenu('YardimciMenu', openEpisode);
        }

        if (this.inPatientPhysicianApplicationFormViewModel.hasCloseEpisodeRole == true) {
            let closeEpisode = new DynamicSidebarMenuItem();
            closeEpisode.key = 'closeEpisode';
            closeEpisode.icon = 'fas fa-lock';
            closeEpisode.label = 'Vakayı Kapat';
            closeEpisode.componentInstance = this.helpMenuService;
            closeEpisode.clickFunction = this.helpMenuService.closeEpisode;
            closeEpisode.parameterFunctionInstance = this;
            closeEpisode.getParamsFunction = this.getClickFunctionParams;
            closeEpisode.ParentInstance = this;
            this.sideBarMenuService.addMenu('YardimciMenu', closeEpisode);
        }

        let openVacationReport = new DynamicSidebarMenuItem();
        openVacationReport.key = 'openVacationReport';
        openVacationReport.label = "Hasta İzni Gir";
        openVacationReport.icon = 'fas fa-plane-departure';
        openVacationReport.componentInstance = this;
        openVacationReport.clickFunction = this.openVacationForm;
        this.sideBarMenuService.addMenu('YardimciMenu', openVacationReport);

        ///BEGIN RAPORLAR

        let orderInfoReport = new DynamicSidebarMenuItem();
        orderInfoReport.key = 'onMedulaReports';
        orderInfoReport.icon = 'fa fa-print';
        orderInfoReport.label = i18n("M30900", "Hasta Orderları Yazdır");
        orderInfoReport.componentInstance = this;
        orderInfoReport.clickFunction = this.openOrderInfoReport;
        this.sideBarMenuService.addMenu('ReportMainItem', orderInfoReport);

        let orderInfoReportBySign = new DynamicSidebarMenuItem();
        orderInfoReportBySign.key = 'onMedulaReports';
        orderInfoReportBySign.label = i18n("M30900", "Hemşirelik Uygulamaları Planı");
        orderInfoReportBySign.componentInstance = this;
        orderInfoReportBySign.clickFunction = this.openOrderInfoReportBySign;
        this.sideBarMenuService.addMenu('ReportMainItem', orderInfoReportBySign);

        let nursingApplicationDailyOrder = new DynamicSidebarMenuItem();
        nursingApplicationDailyOrder.key = 'onMedulaReports';
        nursingApplicationDailyOrder.icon = 'fa fa-file-text-o';
        nursingApplicationDailyOrder.label = i18n("M30900", "HEMŞİRELİK HİZMETLERİ HASTA İZLEM FORMU");
        nursingApplicationDailyOrder.componentInstance = this;
        nursingApplicationDailyOrder.clickFunction = this.opennursingApplicationDailyOrder;
        this.sideBarMenuService.addMenu('ReportMainItem', nursingApplicationDailyOrder);

        let patientVacationForm = new DynamicSidebarMenuItem();
        patientVacationForm.key = 'patientVacationForm';
        patientVacationForm.icon = 'fa fa-print';
        patientVacationForm.label = i18n("M30900", "Hasta İzin Formu");
        patientVacationForm.componentInstance = this;
        patientVacationForm.clickFunction = this.printVacationForm;
        this.sideBarMenuService.addMenu('ReportMainItem', patientVacationForm);

        if (this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.EmergencyIntervention != null) {
            let emergencyForm = new DynamicSidebarMenuItem();
            emergencyForm.key = 'emergencyForm';
            emergencyForm.icon = 'fas fa-chart-bar';
            emergencyForm.label = 'Acil Müşahede Formu'
            emergencyForm.componentInstance = this;
            emergencyForm.clickFunction = this.printAcilMusahedeForm;
            emergencyForm.ParentInstance = this;
            this.sideBarMenuService.addMenu('StatisticReportMainItem', emergencyForm);

            let emergencyOrderMenu = new DynamicSidebarMenuItem();
            emergencyOrderMenu.key = 'emergencyOrderMenu';
            emergencyOrderMenu.icon = 'fa fa-file-text-o';
            emergencyOrderMenu.label = "Acil Servis Direktif";
            emergencyOrderMenu.componentInstance = this.helpMenuService;
            emergencyOrderMenu.clickFunction = this.helpMenuService.onEmergencyOrderOpen;
            emergencyOrderMenu.parameterFunctionInstance = this;
            emergencyOrderMenu.getParamsFunction = this.getEmergencyClickFunctionParams;
            emergencyOrderMenu.ParentInstance = this;
            this.sideBarMenuService.addMenu('YardimciMenu', emergencyOrderMenu);

        }

        let empBedStaticForm = new DynamicSidebarMenuItem();
        empBedStaticForm.key = 'empBedStaticForm';
        empBedStaticForm.icon = 'fas fa-chart-bar';
        empBedStaticForm.label = 'Boş Yatak Listesi'
        empBedStaticForm.componentInstance = this;
        empBedStaticForm.clickFunction = this.getActiveClinicsForReport;
        empBedStaticForm.parameterFunctionInstance = this;
        empBedStaticForm.getParamsFunction = this.returnEmptyBedReportName;
        empBedStaticForm.ParentInstance = this;
        this.sideBarMenuService.addMenu('StatisticReportMainItem', empBedStaticForm);

        let inpatientListReport = new DynamicSidebarMenuItem();
        inpatientListReport.key = 'inpatientListReport';
        inpatientListReport.icon = 'fas fa-chart-bar';
        inpatientListReport.label = 'Yatan Hasta Listesi'
        inpatientListReport.componentInstance = this;
        inpatientListReport.clickFunction = this.getActiveClinicsForReport;
        inpatientListReport.parameterFunctionInstance = this;
        inpatientListReport.getParamsFunction = this.returnInpatientListReportName;
        inpatientListReport.ParentInstance = this;
        this.sideBarMenuService.addMenu('StatisticReportMainItem', inpatientListReport);

        let patientVacationListReport = new DynamicSidebarMenuItem();
        patientVacationListReport.key = 'patientVacationListReport';
        patientVacationListReport.icon = 'fas fa-chart-bar';
        patientVacationListReport.label = 'İzinli Hasta Listesi'
        patientVacationListReport.componentInstance = this;
        patientVacationListReport.clickFunction = this.getActiveClinicsForReport;
        patientVacationListReport.parameterFunctionInstance = this;
        patientVacationListReport.getParamsFunction = this.returnPatientVacationListReportName;
        patientVacationListReport.ParentInstance = this;
        this.sideBarMenuService.addMenu('StatisticReportMainItem', patientVacationListReport);

        let vaccineFollowup = new DynamicSidebarMenuItem();
        vaccineFollowup.key = 'vaccineFollowup';
        vaccineFollowup.icon = 'ai ai-asi-takip';
        vaccineFollowup.label = i18n("M11213", "Aşı Takip");
        vaccineFollowup.parameterFunctionInstance = this;
        vaccineFollowup.getParamsFunction = this.getClickFunctionParams;
        vaccineFollowup.componentInstance = this.helpMenuService;
        vaccineFollowup.clickFunction = this.helpMenuService.onVaccineFollowUpOpen;
        vaccineFollowup.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', vaccineFollowup);



        ///END RAPORLAR        

        if (this._InPatientPhysicianApplication.InPatientTreatmentClinicApp != null) {
            if (this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.IsDailyOperation) {
                let dailyInpatientOperation = new DynamicSidebarMenuItem();
                dailyInpatientOperation.key = 'dailyInpatientOperation';
                dailyInpatientOperation.icon = 'ai ai-patientatbed';
                dailyInpatientOperation.label = i18n("M30201", 'Yatışa Çevir');
                dailyInpatientOperation.componentInstance = this.helpMenuService;
                dailyInpatientOperation.clickFunction = this.helpMenuService.openInpatientTreatmentClinicApp;
                dailyInpatientOperation.parameterFunctionInstance = this;
                dailyInpatientOperation.getParamsFunction = this.getClickFunctionParams;
                dailyInpatientOperation.ParentInstance = this;
                this.sideBarMenuService.addMenu('YardimciMenu', dailyInpatientOperation);

                let cancelDailyInpatient = new DynamicSidebarMenuItem();
                cancelDailyInpatient.key = 'cancelDailyInpatient';
                cancelDailyInpatient.icon = 'fa fa-times';
                cancelDailyInpatient.label = i18n("M30201", 'Günübirlik Yatış İptal');
                cancelDailyInpatient.componentInstance = this;
                cancelDailyInpatient.clickFunction = this.CancelDailyInpatient;
                cancelDailyInpatient.parameterFunctionInstance = this;
                cancelDailyInpatient.ParentInstance = this;
                this.sideBarMenuService.addMenu('YardimciMenu', cancelDailyInpatient);
            }
        }
        let EpicrisisReport = new DynamicSidebarMenuItem();
        EpicrisisReport.key = 'EpicrisisReport';
        EpicrisisReport.icon = 'fa fa fa-pencil-square-o';
        EpicrisisReport.label = 'Epikriz Raporu';
        EpicrisisReport.componentInstance = this.helpMenuService;
        EpicrisisReport.clickFunction = this.helpMenuService.openEpicrisisScreen;
        EpicrisisReport.parameterFunctionInstance = this;
        EpicrisisReport.getParamsFunction = this.getClickFunctionParams;
        EpicrisisReport.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', EpicrisisReport);

        if (this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.EmergencyIntervention != null
            && this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.InPatientTreatmentClinicApp == null) {
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
        }



        //let clinicFormsRoot = new DynamicSidebarMenuItem();
        //clinicFormsRoot.key = 'clinicFormsRoot';
        //clinicFormsRoot.icon = 'ai ai-kanser';
        //clinicFormsRoot.label = 'Klinik Formlar';
        //this.sideBarMenuService.addMenu(null, clinicFormsRoot);

        //let covid19infoForm = new DynamicSidebarMenuItem();
        //covid19infoForm.key = 'covid19infoForm';
        //covid19infoForm.icon = 'ai ai-barkod-bas';
        //covid19infoForm.label = 'Covid-19 Vaka Formu';
        //covid19infoForm.componentInstance = this;
        //covid19infoForm.clickFunction = this.covid19ClickFunction;
        //covid19infoForm.parameterFunctionInstance = this;
        ////covid19infoForm.getParamsFunction = this.getClickFunctionParams;
        //covid19infoForm.ParentInstance = this;

        //this.sideBarMenuService.addMenu('clinicFormsRoot', covid19infoForm);

        let subEpisodeTracking = new DynamicSidebarMenuItem();
        subEpisodeTracking.key = 'subEpisodeTracking';
        subEpisodeTracking.icon = 'fas fa-user-clock';
        subEpisodeTracking.label = 'Kabul Bazlı Takip';
        subEpisodeTracking.componentInstance = this.helpMenuService;
        subEpisodeTracking.clickFunction = this.helpMenuService.trackBySubepisode;
        subEpisodeTracking.parameterFunctionInstance = this;
        subEpisodeTracking.getParamsFunction = this.getPatientTrackingParams;
        subEpisodeTracking.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', subEpisodeTracking);

        let patientTracking = new DynamicSidebarMenuItem();
        patientTracking.key = 'patientTracking';
        patientTracking.icon = "fas fa-user-times";
        patientTracking.label = 'Hasta Bazlı Takip';
        patientTracking.componentInstance = this.helpMenuService;
        patientTracking.clickFunction = this.helpMenuService.trackbyPatient;
        patientTracking.parameterFunctionInstance = this;
        patientTracking.getParamsFunction = this.getPatientTrackingParams;
        patientTracking.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', patientTracking);

        if (this.inPatientPhysicianApplicationFormViewModel.HasAuthorityForObstetricInformationForm == true) {
            let birthInformationReport = new DynamicSidebarMenuItem();
            birthInformationReport.key = 'birthInformationReport';
            birthInformationReport.icon = 'fa fa-file-text-o';
            birthInformationReport.label = 'Doğum Bilgileri Raporu'
            birthInformationReport.componentInstance = this;
            birthInformationReport.clickFunction = this.OpenBirthInfoReportPopUp;
            birthInformationReport.parameterFunctionInstance = this;
            birthInformationReport.ParentInstance = this;
            this.sideBarMenuService.addMenu('StatisticReportMainItem', birthInformationReport);
        }

        if (this._InPatientPhysicianApplication.EmergencyIntervention != null) {
            let ExPatientsInEmergenyDepartment = new DynamicSidebarMenuItem();
            ExPatientsInEmergenyDepartment.key = 'ExPatientsInEmergenyDepartment';
            ExPatientsInEmergenyDepartment.componentInstance = this.helpMenuService;
            ExPatientsInEmergenyDepartment.label = 'Acil Ex Hasta Listesi';
            ExPatientsInEmergenyDepartment.icon = 'fa fa-file-text-o';
            ExPatientsInEmergenyDepartment.clickFunction = this.helpMenuService.openExPatientListReport;
            this.sideBarMenuService.addMenu("StatisticReportMainItem", ExPatientsInEmergenyDepartment);

        }


        /* let occupancyRate = new DynamicSidebarMenuItem();
         occupancyRate.key = 'occupancyRate';
         occupancyRate.icon = 'fa fa-file-alt';
         occupancyRate.label = 'Bölüm Bilgileri';
         occupancyRate.componentInstance = this;
         occupancyRate.clickFunction = this.openDepartmentOccupancyRate;
         occupancyRate.parameterFunctionInstance = this;
         //printEpicrisisForm.getParamsFunction = this.getClickFunctionParams;
         occupancyRate.ParentInstance = this;
         this.sideBarMenuService.addMenu('YardimciMenu', occupancyRate);*/

        let archiveRequest = new DynamicSidebarMenuItem();
        archiveRequest.key = 'archiveRequest';
        archiveRequest.icon = "fa fa-archive";
        archiveRequest.label = 'Arşiv İstek';
        archiveRequest.componentInstance = this;
        archiveRequest.clickFunction = this.openArchiveRequest;
        archiveRequest.parameterFunctionInstance = this;
        //  archiveRequest.getParamsFunction = this.getPatientTrackingParams;
        archiveRequest.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', archiveRequest);

        let checklist = new DynamicSidebarMenuItem();
        checklist.key = 'checklist';
        checklist.icon = 'fa fa-list-ol';
        checklist.label = "Güvenli Cerrahi Kontrol Listesi";
        checklist.componentInstance = this;
        checklist.clickFunction = this.openSafeSurgeryChecklists;
        this.sideBarMenuService.addMenu('YardimciMenu', checklist);


        let labBarcode = new DynamicSidebarMenuItem();
        labBarcode.key = 'labBarcode';
        labBarcode.icon = 'fa fa-barcode';
        labBarcode.label = 'Laboratuvar Barkodu Bas';
        labBarcode.componentInstance = this.helpMenuService;
        labBarcode.clickFunction = this.helpMenuService.printLabBarcode;
        labBarcode.parameterFunctionInstance = this;
        labBarcode.getParamsFunction = this.getClickFunctionParams;
        labBarcode.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', labBarcode);

        let hastaNakilFormu = new DynamicSidebarMenuItem();
        hastaNakilFormu.key = 'hastaNakilFormu';
        hastaNakilFormu.icon = 'fa fa-file-text-o';
        hastaNakilFormu.label = '112 Hasta Nakil Formu';
        hastaNakilFormu.componentInstance = this.helpMenuService;
        hastaNakilFormu.clickFunction = this.helpMenuService.openHastaNakilFormu;
        hastaNakilFormu.parameterFunctionInstance = this;
        hastaNakilFormu.getParamsFunction = this.getClickFunctionParams;
        hastaNakilFormu.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', hastaNakilFormu);


    }

    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('colorPrescription');
        this.sideBarMenuService.removeMenu('colorPrescriptionForApproval');
        this.sideBarMenuService.removeMenu('takipal');
        this.sideBarMenuService.removeMenu('takipOku');
        this.sideBarMenuService.removeMenu('yatısCikisOku');
        //this.sideBarMenuService.removeMenu('yatısCikisYap');
        //this.sideBarMenuService.removeMenu('yatısCikisIptal');
        this.sideBarMenuService.removeMenu('manipulation');
        this.sideBarMenuService.removeMenu('patientDocumentUpload');
        this.sideBarMenuService.removeMenu('surgery');
        this.sideBarMenuService.removeMenu('inpatientAdmission');
        this.sideBarMenuService.removeMenu('inpatientTreatmentClinicApp');
        this.sideBarMenuService.removeMenu('nabizMessage');
        /*this.sideBarMenuService.removeMenu('showENabizInfo');*/
        this.sideBarMenuService.removeMenu('printInpatientTreatmentBarcode');
        this.sideBarMenuService.removeMenu('epicrisisForm');
        this.sideBarMenuService.removeMenu('inPatientExaminationForm');
        this.sideBarMenuService.removeMenu('openPhysiotherapyRequest');
        this.sideBarMenuService.removeMenu('openPhysiotherapyTreatmentNote');
        this.sideBarMenuService.removeMenu('openObstetric');
        this.sideBarMenuService.removeMenu('orthesisList');
        this.sideBarMenuService.removeMenu('physioTherapyList');
        this.sideBarMenuService.removeMenu('dentistAdmission');
        this.sideBarMenuService.removeMenu('influenzaResult');
        this.sideBarMenuService.removeMenu('printInPatientExaminationForm');
        this.sideBarMenuService.removeMenu('printInpatientAdmissionInfoByTreatmentClinicReport');
        this.sideBarMenuService.removeMenu('healthCommitteAdmission');
        this.sideBarMenuService.removeMenu('openHemodialysisRequest');
        this.sideBarMenuService.removeMenu('ortezIstek');
        this.sideBarMenuService.removeMenu('printOrthesisProsthesisReceptionReport');
        this.sideBarMenuService.removeMenu('orderInfoReport');
        this.sideBarMenuService.removeMenu('openVacationForm');
        this.sideBarMenuService.removeMenu('orderInfoReportBySign');
        this.sideBarMenuService.removeMenu('report');
        this.sideBarMenuService.removeMenu('onMedulaReports');
        this.sideBarMenuService.removeMenu('printInpatientBarcode');
        this.sideBarMenuService.removeMenu('emergencyForm');
        this.sideBarMenuService.removeMenu('dailyInpatientOperation');
        this.sideBarMenuService.removeMenu('cancelDailyInpatient');
        this.sideBarMenuService.removeMenu('empBedStaticForm');
        this.sideBarMenuService.removeMenu('vaccineFollowup');
        this.sideBarMenuService.removeMenu('EpicrisisReport');
        this.sideBarMenuService.removeMenu('openEpisode');
        this.sideBarMenuService.removeMenu('closeEpisode');
        this.sideBarMenuService.removeMenu('createEDurumBildirirReport');
        this.sideBarMenuService.removeMenu('openEDurumBildirirReportIndex');
        this.sideBarMenuService.removeMenu('openPatientSgkReports');
        this.sideBarMenuService.removeMenu('subEpisodeTracking');
        this.sideBarMenuService.removeMenu('patientTracking');
        this.sideBarMenuService.removeMenu('patientVacationForm');
        this.sideBarMenuService.removeMenu('patientVacationListReport');
        this.sideBarMenuService.removeMenu('emergencyOrderMenu');
        this.sideBarMenuService.removeMenu('birthInformationReport');
        this.sideBarMenuService.removeMenu('ExPatientsInEmergenyDepartment');
        // this.sideBarMenuService.removeMenu('occupancyRate');
        this.sideBarMenuService.removeMenu('surgeryAppointment');
        this.sideBarMenuService.removeMenu('archiveRequest');
        this.sideBarMenuService.removeMenu('checklist');
        this.sideBarMenuService.removeMenu('labBarcode');
        this.sideBarMenuService.removeMenu('hastaNakilFormu');

    }

    public covid19ClickFunction() {

        let params: DynamicFormParameters = {
            Code: 'COVID19_TEST3',
            Mode: 2,
            Parameters: {
                PatientID: this.getPatientId().ObjectID,
            },
            ReadOnly: false,
            ShowGrid: true,
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicForm';
            componentInfo.ModuleName = 'DynamicFormModule';
            componentInfo.ModulePath = '/app/DynamicFormDesigner/DynamicFormModule';
            componentInfo.InputParam = params;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "COVID-19 Vaka Formu"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {

                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }

    //#region Medula Provizyon İşlemleri

    public showProvisionPopup = false;
    public readProvisionResultArray: Array<TakipDVO> = [];
    async takipAl() {
        try {
            let that = this;
            if (this.inPatientPhysicianApplicationFormViewModel.SubEpisodeProtocol.ObjectID == null) {
                ServiceLocator.MessageService.showError("Hastaya alınacak takip numarası bulunamamıştır..");
            }
            if (this.inPatientPhysicianApplicationFormViewModel.SubEpisodeProtocol.MedulaTakipNo != null)
                ServiceLocator.MessageService.showError(i18n("M15511", "Hastaya alınmış takip numarası mevcuttur,önce takip siliniz."));
            let takipAlUrl = '';

            if (this.inPatientPhysicianApplicationFormViewModel.bagliTakipNo === '')
                ServiceLocator.MessageService.showError("Yeni takibin bağlanacağı bir takip bulunamadı. Kontrol ediniz.");
            else
                takipAlUrl = '/api/InvoiceTopMenuApi/takipAl?sepObjectID=' + this.inPatientPhysicianApplicationFormViewModel.SubEpisodeProtocol.ObjectID + '&bagliTakipNo=' + this.inPatientPhysicianApplicationFormViewModel.bagliTakipNo;

            this.httpService.get<MedulaResult>(takipAlUrl, MedulaResult)
                .then(result => {
                    ServiceLocator.MessageService.showInfo(result.SonucKodu + ' - ' + result.SonucMesaji);
                })
                .catch(error => {
                    ServiceLocator.MessageService.showError(error);
                });

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err.message);
        }
    }

    async takipOku() {
        let that = this;

        if (this.inPatientPhysicianApplicationFormViewModel.SubEpisodeProtocol.ObjectID == null)
            ServiceLocator.MessageService.showError(i18n("M30206", "Okunacak takip bilgisi bulunamamıştır."));

        let apiUrlTakipOku: string = '/api/InvoiceTopMenuApi/takipOku';
        let sepIDs: Array<any> = [];
        sepIDs.push(this.inPatientPhysicianApplicationFormViewModel.SubEpisodeProtocol.ObjectID);
        let tom: any = {};
        tom.sepObjectIDs = sepIDs;


        this.httpService.post<Array<TakipDVO>>(apiUrlTakipOku, tom)
            .then(result => {
                this.showProvisionPopup = true;
                this.readProvisionResultArray = this.changeCodeToNameOnProvisionResult(result);
            })
            .catch(error => {
                ServiceLocator.MessageService.showError(error);
            });

    }
    public showTedaviTipiPopup: boolean = false;
    async tedaviTipiDegistir() {
        this.showTedaviTipiPopup = true;
        //    });
    }
    public AcceptTedaviTipi() {
        let url = '/api/InPatientPhysicianApplicationService/UpdateSEPTedaviTipi?sepObjectID=' + this.inPatientPhysicianApplicationFormViewModel.SubEpisodeProtocol.ObjectID + '&tedaviTipiKodu=' + this.TedaviTipiSelectedObject.tedaviTipiKodu;

        let that = this;

        that.httpService.get<any>(url)
            .then(response => {
                that.messageService.showSuccess("Tedavi tipi başarılı bir şekilde değiştirildi.");
            })
            .catch(error => {
                this.messageService.showError(error);

            });

        this.showTedaviTipiPopup = false;
    }
    public CancelTedaviTipi() {
        this.showTedaviTipiPopup = false;
    }

    //#region yatısCikisOku
    showMedulaInpatientOpPopup: boolean = false;
    public MedulaInpatientInfo: HastaYatisOkuCevapDVO;
    async yatısCikisOku() {
        this.medulaInpatientOperation();
    }
    public MedulaInpatientFirstAndLastDateColumns = [
        {
            caption: i18n("M24448", "Yatış Tarihi"),
            allowEditing: false,
            dataField: 'baslangicTarihi',
            width: '30%'
        }, {
            caption: i18n("M12379", "Çıkış Tarihi"),
            allowEditing: false,
            dataField: 'bitisTarihi',
            width: '30%'
        }, {
            caption: i18n("M14131", "Fatura Durumu"),
            allowEditing: false,
            dataField: 'durum',
            width: '30%'
        }, {
            caption: i18n("M24444", "Yatış Sil"),
            width: '10%',
            allowEditing: false,
            cellTemplate: 'buttonDeleteInpatientCellTemplate',
            allowSorting: false
        }

    ];
    medulaInpatientOperation(): void {

        this.loadPanelOperation(true, i18n("M18840", "Meduladan yatış bilgisi okunuyor, lütfen bekleyiniz."));
        let apiUrlForgetRule: string = '/api/InvoiceTopMenuApi/HastaYatisOku?sepObjectID=' + this.inPatientPhysicianApplicationFormViewModel.SubEpisodeProtocol.ObjectID;

        this.httpService.get<HastaYatisOkuCevapDVO>(apiUrlForgetRule)
            .then(result => {
                this.loadPanelOperation(false, '');

                this.MedulaInpatientInfo = result;

                this.showMedulaInpatientOpPopup = true;
            })
            .catch(error => {
                ServiceLocator.MessageService.showError(error);
            });
    }

    //#endregion yatısCikisOku

    //async yatısCikisYap() {

    //}
    //async yatısCikisIptal() {

    //}

    changeCodeToNameOnProvisionResult(oldResult: Array<TakipDVO>): Array<TakipDVO> {

        //for (let i = 0; i < oldResult.length; i++) {
        //    oldResult[i].tedaviTuru = this.findFromArray(this.tedaviTuruArray, oldResult[i].tedaviTuru);
        //    oldResult[i].tedaviTipi = this.findFromArray(this.tedaviTipiArray, oldResult[i].tedaviTipi);
        //    oldResult[i].takipTipi = this.findFromArray(this.takipTipiArray, oldResult[i].takipTipi);
        //    oldResult[i].provizyonTipi = this.findFromArray(this.provizyonTipiArray, oldResult[i].provizyonTipi);
        //    oldResult[i].bransKodu = this.findFromArray(this.bransArray, oldResult[i].bransKodu);
        //    oldResult[i].istisnaiHal = this.findFromArray(this.istisnaiHalArray, oldResult[i].istisnaiHal);

        //    oldResult[i].hastaBilgileri.devredilenKurum = this.findFromArray(this.devredilenKurumArray, oldResult[i].hastaBilgileri.devredilenKurum);
        //    oldResult[i].hastaBilgileri.sigortaliTuru = this.findFromArray(this.sigortaliTuruArray, oldResult[i].hastaBilgileri.sigortaliTuru);
        //    oldResult[i].hastaBilgileri.cinsiyet = oldResult[i].hastaBilgileri.cinsiyet === 'E' ? i18n("M13837", "Erkek") : i18n("M17061", "Kadın");
        //    oldResult[i].hastaBilgileri.katilimPayindanMuaf = oldResult[i].hastaBilgileri.katilimPayindanMuaf === 'E' ? i18n("M14018", "Evet") : i18n("M15570", "Hayır");

        //    oldResult[i].sevkDurumu = oldResult[i].sevkDurumu === 'E' ? i18n("M14018", "Evet") : i18n("M15570", "Hayır");
        //    oldResult[i].takipDurumu = oldResult[i].takipDurumu === '0' ? i18n("M19861", "Ödeme sorgusu yapılmamış") : oldResult[i].takipDurumu === '1' ? i18n("M19862", "Ödeme sorgusu yapılmış") : i18n("M14250", "Faturalanmış");

        //}

        return oldResult;
    }

    public async openERaporSorgulaComponent() {

        this.showERaporSorgulaComponent = true;
    }



    findFromArray(arr: Array<any>, key: any): string {
        let temp = arr.find(t => t.Code === key);
        if (temp != null && temp !== undefined)
            return temp.Name.substring(0, 30); //32 Karakterden sonrası alt satıra geçiriyor.
        else
            return '';
    }
    //#endregion Medula Provizyon İşlemleri

    public ngOnDestroy(): void {
        if (this.refreshReportGridSubscription != null) {
            this.refreshReportGridSubscription.unsubscribe();
            this.refreshReportGridSubscription = null;
        }
        this.RemoveMenuFromHelpMenu();
        this.OnDestroy.emit();
        //this.httpService.eNabizButtonSharedService.changeButtonVisible(false);
    }

    public openEpicrisisReport() {
        this.epicrisisReportVisible = true;
    }

    public async onSelectedReportOpen(data: any) {
        this.ReportParamActiveIDsModel = new ActiveIDsModel(this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.ObjectID, this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.Episode.ObjectID, this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.Episode.Patient.ObjectID);
        if (data.code === ReportTypeEnum.DrugReport) {
            if (this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.CurrentStateDefID == InPatientPhysicianApplication.InPatientPhysicianApplicationStates.Discharged) {
                ServiceLocator.MessageService.showError(i18n("M22568", "Taburcu olmuş hastalara yeni İlaç Raporu yazılamaz."));
            }
            else {
                if (!(await EpisodeActionService.CheckInvoicedCompletely(this._InPatientPhysicianApplication.ObjectID)))
                    this.onParticipatientReportOpen(null);
                else
                    ServiceLocator.MessageService.showError("Faturası Kesilmiş Hastalara İlaç Raporu Yazamazsınız");
            }
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
        }
        else if (data.code === ReportTypeEnum.MedicalStuffReport) {
            this.onMedicalStuffReportOpen(null);
        }
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
            componentInfo.InputParam = new DynamicComponentInputParam(data, new ActiveIDsModel(this._InPatientPhysicianApplication.ObjectID, this._InPatientPhysicianApplication.Episode.ObjectID, this._InPatientPhysicianApplication.Episode.Patient.ObjectID));
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

            }).catch(err => {
                reject(err);
            });
        });
    }

    async onStatusNotificationReportForm(event: any) {
        this.showStatusNotificationReportForm = false;
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

    async GridPatientReports_CellContentClicked(data: any) {
        let that = this;
        this.ReportParamActiveIDsModel = new ActiveIDsModel(this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.ObjectID, this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.Episode.ObjectID, this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.Episode.Patient.ObjectID);
        // if (this.ReadOnly != true) {
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

        // }
    }
    public async onShowCancelledReports(val: any): Promise<void> {
        if (val.value != null) {

            let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.Episode.Patient.ObjectID + '&subepisodeObjectID=' + this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.SubEpisode.ObjectID + '&includedCancelledReports=' + val.value + '&currentActionReports=' + this.currentActionReports;
            let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);


            this.inPatientPhysicianApplicationFormViewModel.PatientReportInfoList = res;
        }
    }
    public async onShowAllReports(val: any): Promise<void> {
        if (val.value != null) {
            this.currentActionReports = !(val.value);
            let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.Episode.Patient.ObjectID + '&subepisodeObjectID=' + this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.SubEpisode.ObjectID + '&includedCancelledReports=false&currentActionReports=' + this.currentActionReports;
            let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);


            this.inPatientPhysicianApplicationFormViewModel.PatientReportInfoList = res;
        }
    }
    async OnStatusNotificationReportFormClosing(e) {
        //this.showStatusNotificationReportForm = false;

        //refreshReportTab
        this.reloadReportList();
        /*let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.Episode.Patient.ObjectID + '&subepisodeObjectID=' + this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.SubEpisode.ObjectID + '&includedCancelledReports=false&currentActionReports=' + this.currentActionReports;
        let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);
        this.inPatientPhysicianApplicationFormViewModel.PatientReportInfoList = res;*/
    }
    async OnMedulaTedaviRaporlariFormClosing(e) {
        if (e == true)
            this.showMedulaTedaviRaporlariForm = false;

        //refreshReportTab
        this.reloadReportList();
        /*let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.Episode.Patient.ObjectID + '&subepisodeObjectID=' + this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.SubEpisode.ObjectID + '&includedCancelledReports=false&currentActionReports=true';
        let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);
        this.inPatientPhysicianApplicationFormViewModel.PatientReportInfoList = res;*/

    }
    async OnParticipationFreeDrugReportNewFormClosing(e) {
        if (e == true)
            this.showParticipationFreeDrugReportNewForm = false;

        //refreshReportTab
        this.reloadReportList();
        /*let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.Episode.Patient.ObjectID + '&subepisodeObjectID=' + this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.SubEpisode.ObjectID + '&includedCancelledReports=false&currentActionReports=true';
        let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);
        this.inPatientPhysicianApplicationFormViewModel.PatientReportInfoList = res;*/
    }

    async onParticipationFreeDrugReportNewForm(event: any) {
        this.showParticipationFreeDrugReportNewForm = false;
        //refreshReportTab
        this.reloadReportList();
        /*let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.Episode.Patient.ObjectID + '&subepisodeObjectID=' + this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.SubEpisode.ObjectID + '&includedCancelledReports=false&currentActionReports=' + this.currentActionReports;
        let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);
        this.inPatientPhysicianApplicationFormViewModel.PatientReportInfoList = res;*/
    }

    async reloadReportList() {
        let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.Episode.Patient.ObjectID + '&subepisodeObjectID=' + this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.SubEpisode.ObjectID + '&includedCancelledReports=false&currentActionReports=' + this.currentActionReports;
        let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);
        this.inPatientPhysicianApplicationFormViewModel.PatientReportInfoList = res;
    }

    onMedulaTreatmentReportOpen(episodeAction: any) {
        if (this.inPatientPhysicianApplicationFormViewModel.IsAuthorizedToWriteTreatmentReport == false) {
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

    _openHemsirelik(data: any) {
        //this.systemApiService.open(this.inPatientPhysicianApplicationFormViewModel.NursingApplicationObjectID, "NURSINGAPPLICATION", null, null).then(x => {
        //    //this.loadPanelOperation(false, '');
        //});

        //this.showNursingInformation(data).then(result => {
        //    let modalActionResult = result as ModalActionResult;
        //    if (modalActionResult.Result == DialogResult.OK) {
        //        //let obj = result.Param as MedicalInformation;
        //    }
        //});
    }
    showNursingInformation(patientID): Promise<ModalActionResult> {
        let that = this;

        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "NursingAplicationDoctorForm";
            componentInfo.ModuleName = "HemsirelikIslemleriModule";
            componentInfo.ModulePath = "../Hemsirelik_Islemleri_Modulu/HemsirelikIslemleriModule";
            componentInfo.objectID = this.inPatientPhysicianApplicationFormViewModel.NursingApplicationObjectID;

            componentInfo.InputParam = new DynamicComponentInputParam(this.inPatientPhysicianApplicationFormViewModel.NursingApplicationObjectID.toString(), new ActiveIDsModel(this._InPatientPhysicianApplication.ObjectID, null, null));


            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M20020", "Önemli Tıbbi Bilgiler");
            modalInfo.Width = 800;
            modalInfo.Height = 950;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public saveDispatchComponent: boolean = true;
    public dispatchComponentInfo: DynamicComponentInfo;
    public dispatchQueryParameters: QueryParams;

    protected getComponentInfo() {
        let componentInfoViewModel: DispatchToOtherHospitalComponentInfoViewModel = DispatchToOtherHospitalForm.getComponentInfoViewModel(this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.ObjectID, this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.Episode.ObjectID, this.inPatientPhysicianApplicationFormViewModel._Patient.ObjectID, "inpatient");
        this.dispatchQueryParameters = componentInfoViewModel.dispatchQueryParameters;
        this.dispatchComponentInfo = componentInfoViewModel.dispatchComponentInfo;

    }

    public dispatchQueryResultLoaded(e: any) {
        DispatchToOtherHospitalForm.dispatchQueryResultLoaded(e);
    }


    public innerTabRender(e: any) {
        if (e.itemData.title === i18n("M21695", "Sevk")) {
            this.getComponentInfo();
        }
    }
    isHizmetTetkik: any = true;
    isConsultation: any = false;
    isMlzSarf: any = false;
    isRaporlar: any = false;
    isSevk: any = false;

    selectTab(e) {
        let selectedItem: string = e.addedItems[0].title;
        if (selectedItem == i18n("M17742", "Konsültasyon")) {
            this.isConsultation = true;
        }
        if (selectedItem == i18n("M19108", "Mlz.Sarf")) {
            this.isMlzSarf = true;
        }
        if (selectedItem == i18n("M15930", "Hizmet ve Tetkik")) {
            this.isHizmetTetkik = true;
        }
        if (selectedItem == i18n("M20887", "Raporlar")) {
            this.isRaporlar = true;
        }
        if (selectedItem == i18n("M21695", "Sevk")) {
            this.isSevk = true;
        }
    }

    public getMasterObjectIdForDentalExam() {
        return this._InPatientPhysicianApplication.InPatientTreatmentClinicApp.ObjectID;
    }

    ///
    ///Sağlık Kurulu begin
    ///
    public onInpMemberDoctorRemoving(event) {
        if (event.row != null) {

            if (event.row.data != null) {
                let index = this.ResourcesToBeReferredList.findIndex(o => o.ProcedureDoctorToBeReferred.ObjectID.toString() === event.row.data.ProcedureDoctorToBeReferred.ObjectID.toString()
                    && o.Resource.ObjectID.toString() === event.row.data.Resource.ObjectID.toString());

                if (index > -1)
                    this.ResourcesToBeReferredList.splice(index, 1);


                // if (event.row.data.IsNew != false) {

                //     let index = this.ResourcesToBeReferredList.findIndex(o => o.ProcedureDoctorToBeReferred.ObjectID.toString() === event.row.data.ProcedureDoctorToBeReferred.ObjectID.toString()
                //         && o.Resource.ObjectID.toString() === event.row.data.Resource.ObjectID.toString());

                //     if (index > -1) {
                //         this.ResourcesToBeReferredList.splice(index, 1);
                //         // this.inpatientHC_Class.resourcesToBeReferredList.splice(index, 1);//aynı referansa sahip olduğu için gerek yok
                //     }

                //     this.memberDoctorsGrid.instance.deleteRow(event.rowIndex);
                // }
                // else {
                //     event.data.EntityState = EntityStateEnum.Deleted;
                //     this.memberDoctorsGrid.instance.filter(['EntityState', '<>', 1]);
                //     this.memberDoctorsGrid.instance.refresh();
                // }
            }
        }
    }

    public async onResourcesToBeReferredPoliclinic(event: any) {
        let that: this;

        if (event != null && event.selectedItem != null) {
            // this.tempResourcesToBeReferredPoliclinic = event.selectedItem;
            this.inPatientPhysicianApplicationFormViewModel.HCDoctorList = await this.getProcedureDoctorToBeReferred(event.selectedItem.ObjectID);
        }
    }

    public async onProcedureDoctorToBeReferred(event: any) {
        // let that:this;
        // if(event != null && event.selectedItem != null)
        // {
        //     this.tempProcedureDoctorToBeReferred = event.selectedItem;             
        // }  

    }

    public async getProcedureDoctorToBeReferred(PoliclinicID: String): Promise<any> {

        let fullApiUrl = '/api/PatientAdmissionService/GetProcedureDoctorToBeReferred?PoliclinicID=' + PoliclinicID;
        return await this.httpService.get<ResUser>(fullApiUrl);
    }

    public async btnAddResourcesToBeReferred() {
        if (this.tempProcedureDoctorToBeReferred != null && this.tempResourcesToBeReferredPoliclinic != null) {

            let index = this.inpatientHC_Class.resourcesToBeReferredList.findIndex(o => o.ProcedureDoctorToBeReferred.ObjectID.toString() === this.tempProcedureDoctorToBeReferred.toString()
                && o.Resource.ObjectID.toString() === this.tempResourcesToBeReferredPoliclinic.toString());

            if (index > -1) {
                ServiceLocator.MessageService.showInfo("Bu Poliklinik ve Doktor bilgisi daha önce eklendiği için tekrar ekleyemezsiniz.");
                return;
            }

            let patientAdmissionResourcesToBeReferred: PatientAdmissionResourcesToBeReferred = new PatientAdmissionResourcesToBeReferred(this._InPatientPhysicianApplication.ObjectContext);
            patientAdmissionResourcesToBeReferred.ProcedureDoctorToBeReferred = this.inPatientPhysicianApplicationFormViewModel.HCDoctorList.find(x => x.ObjectID.toString() == this.tempProcedureDoctorToBeReferred);
            let _ttPol = this.inPatientPhysicianApplicationFormViewModel.HCResPoliclinic.find(x => x.ObjectID.toString() == this.tempResourcesToBeReferredPoliclinic);
            patientAdmissionResourcesToBeReferred.Resource = _ttPol;
            patientAdmissionResourcesToBeReferred.IsNew = true;
            //todo bg
            // patientAdmissionResourcesToBeReferred.Speciality = this.PoliclinicList.find( x => x.Department.ObjectID == _ttPol.ObjectID);
            if (this.inpatientHC_Class.resourcesToBeReferredList == undefined)
                this.inpatientHC_Class.resourcesToBeReferredList = new Array<PatientAdmissionResourcesToBeReferred>();

            this.ResourcesToBeReferredList.push(patientAdmissionResourcesToBeReferred);
            this.inpatientHC_Class.resourcesToBeReferredList = this.ResourcesToBeReferredList;

            this.tempProcedureDoctorToBeReferred = null;
            this.tempResourcesToBeReferredPoliclinic = null;

        }
        else
            ServiceLocator.MessageService.showInfo("Poliklinik ve Doktor alanlarını birlikte seçmelisiniz.");

    }

    /*E-Durum Bildirir Kurul Entegrasyonu*/
    public onEStatusNotRepComApplicationTypeChanged(event): void {
        if (event != null) {
            if (this._eStatusNotfReportObj != null &&
                this._eStatusNotfReportObj.ApplicationType != event) {
                this._eStatusNotfReportObj.ApplicationType = event;
            }
        }
    }
    /*E-Durum Bildirir Kurul Entegrasyonu*/


    public onDisabledReportApplicationExplanationChanged(event): void {
        if (event != null) {
            if (this._eDisabledReport != null &&
                this._eDisabledReport != null && this._eDisabledReport.ApplicationExplanation != event) {
                this._eDisabledReport.ApplicationExplanation = event;
            }
        }
    }

    public onDisabledReportApplicationReasonChanged(event): void {
        if (event != null) {
            if (this._eDisabledReport != null &&
                this._eDisabledReport != null && this._eDisabledReport.ApplicationReason != event) {
                this._eDisabledReport.ApplicationReason = event;
            }
        }
    }

    public onDisabledReportApplicationTypeChanged(event): void {
        if (event != null) {
            if (this._eDisabledReport != null &&
                this._eDisabledReport != null && this._eDisabledReport.ApplicationType != event) {
                this._eDisabledReport.ApplicationType = event;
            }
        }
    }

    public onDisabledReportCorporateApplicationTypeChanged(event): void {
        if (event != null) {
            if (this._eDisabledReport != null &&
                this._eDisabledReport != null && this._eDisabledReport.CorporateApplicationType != event) {
                this._eDisabledReport.CorporateApplicationType = event;
            }
        }
    }

    public onDisabledReportPersonalApplicationTypeChanged(event): void {
        if (event != null) {
            if (this._eDisabledReport != null &&
                this._eDisabledReport != null && this._eDisabledReport.PersonalApplicationType != event) {
                this._eDisabledReport.PersonalApplicationType = event;
            }
        }
    }

    public onDisabledReportTerrorAccidentInjuryAppReasonChanged(event): void {
        if (event != null) {
            if (this._eDisabledReport != null &&
                this._eDisabledReport != null && this._eDisabledReport.TerrorAccidentInjuryAppReason != event) {
                this._eDisabledReport.TerrorAccidentInjuryAppReason = event;
            }
        }
    }

    public onDisabledReportTerrorAccidentInjuryAppTypeChanged(event): void {
        if (event != null) {
            if (this._eDisabledReport != null &&
                this._eDisabledReport != null && this._eDisabledReport.TerrorAccidentInjuryAppType != event) {
                this._eDisabledReport.TerrorAccidentInjuryAppType = event;
            }
        }
    }
    ///
    ///Sağlık Kurulu end
    ///

    public openOrderInfoReport(event) {
        const objectIdParam = new GuidParam(this.inPatientPhysicianApplicationFormViewModel.NursingApplicationObjectID.toString());
        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
        this.reportService.showReportModal('NursingApplicationOrderInfoReport', reportParameters);
    }

    public openOrderInfoReportBySign(event) {
        const objectIdParam = new GuidParam(this.inPatientPhysicianApplicationFormViewModel.NursingApplicationObjectID.toString());
        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
        this.reportService.showReportModal('NursingApplicationOrderInfoReportBySign', reportParameters);
    }

    public opennursingApplicationDailyOrder(event) {
        let sdate: Date = new Date(this.reportController.startDate.Year, this.reportController.startDate.Month, this.reportController.startDate.Day, 0, 0, 0, 0);
        let edate: Date = new Date(this.reportController.endDate.Year, this.reportController.endDate.Month, this.reportController.endDate.Day, 23, 59, 59, 0);
        const objectIdParam = new GuidParam(this.inPatientPhysicianApplicationFormViewModel.NursingApplicationObjectID.toString());
        let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'STARTDATE': new DateParam(sdate), 'ENDDATE': new DateParam(edate) };
        this.reportService.showReportModal('NursingApplicationDailyOrderDetailReport', reportParameters);
    }

    public showInpatientAllProceduresReport() {
        let that = this;
        this.helpMenuService.printInpatientAllProceduresReport(that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.SubEpisode.ObjectID);
    }

    public printAcilMusahedeForm(): Promise<ModalActionResult> {
        let reportData: DynamicReportParameters = {

            Code: 'ACILMUSAHEDEFORMU',
            ReportParams: { ObjectID: this._InPatientPhysicianApplication.EmergencyIntervention.ObjectID },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = reportData;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "ACİL MÜŞAHEDE FORMU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {

                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }

    async printVacationForm() {

        let fullApiUrl = '/api/InpatientPhysicianApplicationService/GetPatientLastActiveVacation/?Patient=' + this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.Episode.Patient.ObjectID.toString();

        let ID = await this.httpService.get<string>(fullApiUrl);

        if (ID != "")
            this.onPrintVacationForm(ID);
        else
            this.messageService.showInfo("Hastaya ait aktif bir izin bulunamadı");
    }

    onPrintVacationForm(ID: string) {

        let reportData: DynamicReportParameters = {

            Code: 'VACATIONFORM',
            ReportParams: { ObjectID: ID },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, new ActiveIDsModel(null, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "HASTA İZİN FORMU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }

    public returnEmptyBedReportName(): ClickFunctionParams {
        let clickFunctionParams: ClickFunctionParams = new ClickFunctionParams(this, "BOSYATAKLISTESI");
        return clickFunctionParams;
    }

    public returnInpatientListReportName(): ClickFunctionParams {
        let clickFunctionParams: ClickFunctionParams = new ClickFunctionParams(this, "YATANHASTALISTESI");
        return clickFunctionParams;
    }

    public returnPatientVacationListReportName(): ClickFunctionParams {
        let clickFunctionParams: ClickFunctionParams = new ClickFunctionParams(this, "IZINLIHASTALISTESI");
        return clickFunctionParams;
    }

    public CancelDailyInpatient() {
        let that = this;
        this.httpService.post<any>("api/InPatientPhysicianApplicationService/CancelDailyInpatient", that.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication)
            .then(response => {
                let result = response;
                if (result) {
                    this.messageService.showInfo(i18n("M23794", "Günübirlik yatış işlemi başarılı bir şekilde iptal edildi."));
                }
            }
            )
            .catch(error => {
                this.messageService.showError(error);
            });
    }

    public openVacationForm() {
        this.showPopupVacationForm = true;
        this.getVacationComponentInfo();
    }

    public savevacationComponent: boolean;
    public vacationComponentInfo: DynamicComponentInfo;
    public vacationQueryParameters: QueryParams;

    protected getVacationComponentInfo() {
        let componentInfoViewModel: PatientVacationComponentInfoViewModel = PatientOnVacationForm.getComponentInfoViewModel(this._InPatientPhysicianApplication.ObjectID);
        this.vacationQueryParameters = componentInfoViewModel.vacationQueryParameters;
        this.vacationComponentInfo = componentInfoViewModel.vacationComponentInfo;

    }

    componentQueryResultLoaded(e: any) {
        PatientOnVacationForm.queryResultLoaded(e);
    }

    public showTreatmentResult: boolean = false;
    public saveInfo: FormSaveInfo;
    public async setStateToTransition(saveInfo: FormSaveInfo) {
        this.showTreatmentResult = true;
        this.saveInfo = saveInfo;
    }
    public async CreateDischarge() {
        if (this.inPatientPhysicianApplicationFormViewModel.TreatmentResult == null) {
            this.messageService.showError("Tedavi sonucu seçmeden taburculuk işlemini tamamlayamazsınız");
            return;
        }
        this.showTreatmentResult = false;
        await super.setStateToTransition(this.saveInfo);
    }
    public CancelDischarge() {
        this.inPatientPhysicianApplicationFormViewModel._MorgueViewModel = null;
        this.inPatientPhysicianApplicationFormViewModel.TreatmentResult = null;
        this.showTreatmentResult = false;
    }

    public showOccupancyRate: boolean;
    public async openDepartmentOccupancyRate() {
        this.showOccupancyRate = true;
    }

    public showArchiveRequest: boolean;
    public ArchiveRequest: ArchiveRequestModel = new ArchiveRequestModel();
    PatientEpisodeFolderList: Array<EpisodeFolderModel> = new Array<EpisodeFolderModel>();
    public async openArchiveRequest() {
        let fullApiUrl = '/api/InpatientPhysicianApplicationService/GetPatientEpisodeFolders?EpisodeActionID=' + this.inPatientPhysicianApplicationFormViewModel._InPatientPhysicianApplication.ObjectID.toString();
        await this.httpService.get<ArchiveRequestModel>(fullApiUrl).then(response => {
            let result = response;
            if (result != null) {
                this.ArchiveRequest = result;
                this.showArchiveRequest = true;
                this.PatientEpisodeFolderList = result.PatientEpisodeFolders;
            }
        }).catch(error => {
            ServiceLocator.MessageService.showError("Hata : " + error);
        });
    }

    selectedFolders: Array<EpisodeFolderModel> = new Array<EpisodeFolderModel>();
    selectionEpisodeFolder(data) {
        this.selectedFolders = data.selectedRowsData;

    }

    RequestedFilesList: Array<Guid> = new Array<Guid>();
    archiveRequestFormInput: Guid;
    public CreateArchiveRequest() {
        this.selectedFolders.forEach(folder => {
            this.RequestedFilesList.push(folder.ObjectID);
        });

        let requestInput: string = "";
        requestInput = JSON.stringify(this.RequestedFilesList);

        let that = this;
        let requestURL: string = '/api/InpatientPhysicianApplicationService/CreateArchiveRequest?inputList=' + requestInput
            + "&description=" + this.archiveDescription + "&requesterSectionId=" + new Guid(this._InPatientPhysicianApplication.MasterResource.toString());

        that.httpService.get<Guid>(requestURL).then(
            async result => {
                this.archiveRequestFormInput = result;
                this.messageService.showInfo("İstek Oluşturuldu");
                this.showArchiveRequest = false;
                this.archiveDescription = "";
                this.RequestedFilesList = new Array<Guid>();
                this.printRequestForm();
            }).catch(error => {
                this.messageService.showError(error);
            });
    }

    public async printRequestForm(): Promise<ModalActionResult> {


        let reportData: DynamicReportParameters = {

            Code: 'ARSIVISTEKFORMU',
            ReportParams: { ArchiveRequestObjectID: this.archiveRequestFormInput },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "ARŞİV İSTEK FORMU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }

    public ismail(e) {
        debugger;
        alert("a");
    }
    public ProceduresGridColumns = [
        {
            caption: i18n("M19030", "Ameliyat İstek Tarihi"),
            dataField: 'RequestDate',
            allowSorting: true,
            format: 'dd.MM.yyyy',
            dataType: 'date',
            width: 150
        },
        {
            caption: i18n("M19030", "Ameliyat Hizmetleri"),
            dataField: 'Procedures',
            dataType: 'string',
            allowEditing: false,
            width: 300
        }
    ];
    showChecklistSelection: boolean = false;
    safeSurgerydataSource: Array<SurgeryChecklistModel> = new Array<SurgeryChecklistModel>();
    public openSafeSurgeryChecklists() {
        let that = this;

        this.httpService.get<Array<SurgeryChecklistModel>>("api/SafeSurgeryCheckListService/GetSafeSurgeryChecklistsBySurgery?episodeActionId=" + this._InPatientPhysicianApplication.ObjectID).then(async result => {
            let checklists = result as Array<SurgeryChecklistModel>;
            if (checklists.length == 0) {
                this.messageService.showInfo('Kayıtlı Güvenli Cerrahi Kontrol Listesi bulunamamıştır');
                return;
            }
            else if (checklists.length > 1) {
                this.safeSurgerydataSource = checklists;
                this.showChecklistSelection = true;
            }
            else if (checklists.length == 1) {
                let param: ClickFunctionParams = this.getClickFunctionParams();
                await that.helpMenuService.showSurgeryChecklist(checklists[0].ChecklistID, param);
            }
        }).catch(error => {
            console.log(error);
        });
    }
    public selectedSurgery: SurgeryChecklistModel;
    public async onSafeSurgeryGridRowClick(event) {
        this.selectedSurgery = event.data;

        if (this.selectedSurgery == null) {
            this.messageService.showInfo('Lütfen açmak istediğiniz kaydı seçiniz');
            return;
        }

        else {
            let param: ClickFunctionParams = this.getClickFunctionParams();
            await this.helpMenuService.showSurgeryChecklist(this.selectedSurgery.ChecklistID, param);
        }
    }

}
export class NursingAppDoneInfoInput {
    public NursingApplicationID: Guid;
}