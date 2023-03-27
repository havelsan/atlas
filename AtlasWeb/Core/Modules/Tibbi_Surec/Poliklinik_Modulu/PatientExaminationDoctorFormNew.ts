//$97B7D5AB
import { Component, ViewChild, OnInit, AfterViewInit, ApplicationRef, OnDestroy, NgZone, EventEmitter } from '@angular/core';
import { Http } from '@angular/http';
import { PatientExaminationDoctorFormNewViewModel, PatientReportInfo, ChangeProvisionTypeClass, GebelikBildirim, RadiologyAppointmentInfo } from './PatientExaminationDoctorFormNewViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { BaseNewDoctorExaminationForm } from 'Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/BaseNewDoctorExaminationForm';
import { DiagnosisGrid, ResClinic, TriajCode, SKRSTRIAJKODU, MedicalOncology, SpecialityBasedObject, SpecialityBasedObjectEnum, Morgue, Pregnancy } from 'NebulaClient/Model/AtlasClientModel';
import { EmergencyIntervention } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
//import { ExaminationInfoByBransService } from "ObjectClassService/ExaminationInfoByBransService";
//import { FollowedPatientListDefinitionService } from "ObjectClassService/FollowedPatientListDefinitionService";
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { OzelDurum } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { PatientExamination } from 'NebulaClient/Model/AtlasClientModel';
import { PatientExaminationService } from 'ObjectClassService/PatientExaminationService';
//import { PeriodicOrderService } from "ObjectClassService/PeriodicOrderService";
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderIntroduction } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderIntroductionDet } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderIntroductionService, OldDrugOrderIntroduction } from 'ObjectClassService/DrugOrderIntroductionService';
import { InpatientAdmission } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionHelper } from 'app/Helper/EpisodeActionHelper';
import { HCExaminationComponent } from 'NebulaClient/Model/AtlasClientModel';

//import { ResUserService } from "ObjectClassService/ResUserService";
import { SingleNursingOrder } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
//import { SpecialityDefinitionService } from "ObjectClassService/SpecialityDefinitionService";
import { SubEpisode } from 'NebulaClient/Model/AtlasClientModel';
import { SystemParameterService } from 'ObjectClassService/SystemParameterService';
import { TTException } from 'NebulaClient/Utils/Exceptions/TTException';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { UserTitleEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ParticipatnFreeDrugReport } from 'NebulaClient/Model/AtlasClientModel';
import { StatusNotificationReport } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalStuffReport } from 'NebulaClient/Model/AtlasClientModel';
import { Consultation } from 'NebulaClient/Model/AtlasClientModel';
import { DoctorGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ImportantMedicalInformation } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInfoAllergies } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInfoDisabledGroup } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInfoDrugAllergies } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInfoFoodAllergies } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInfoHabits } from 'NebulaClient/Model/AtlasClientModel';
import { MedicalInformation } from 'NebulaClient/Model/AtlasClientModel';
import { PatientExaminationAdditionalApplication } from 'NebulaClient/Model/AtlasClientModel';
import { PatientExaminationForensicProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { PatientExaminationTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { SevkVasitasi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSAlkolKullanimi } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSCikisSekli } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSSigaraKullanimi } from 'NebulaClient/Model/AtlasClientModel';
import { vmRequestedProcedure, DailyProvisionInputModel } from '../Tetkik_Istem_Modulu/ProcedureRequestViewModel';
import { vmProcedureRequestFormDefinition } from '../Tetkik_Istem_Modulu/ProcedureRequestViewModel';
import { ProcedureRequestForm } from '../Tetkik_Istem_Modulu/ProcedureRequestForm';
import { MostUsedProcedureRequestForm } from '../Tetkik_Istem_Modulu/MostUsedProcedureRequestForm';
//import { vmEpisodeActionWorkListForm } from "../Hasta_Is_Listesi/EpisodeActionWorkListFormViewModel";
//import { EpisodeActionRequestedProcedureInfo } from "./PatientExaminationDoctorFormNewViewModel";
import { NewConsultationRequestInfo } from './PatientExaminationDoctorFormNewViewModel';
import { IModalService } from 'Fw/Services/IModalService';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { NqlQueryService } from 'app/QueryList/Services/nql-query.service';
import { QueryParams } from 'app/QueryList/Models/QueryParams';
import { ModalInfo, ModalActionResult } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';

import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { PatientStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
//import { RequestedProceduresForm } from "../Tetkik_Istem_Modulu/RequestedProceduresForm";

import { PatientInterviewForm, DentalExamination } from 'NebulaClient/Model/AtlasClientModel';
import { PatientExaminationEnum } from 'NebulaClient/Model/AtlasClientModel';

import { IActiveTabService } from 'Fw/Services/IActiveTabService';
//import { EpisodeActionWorkListSharedService } from '../Hasta_Is_Listesi/EpisodeActionWorkListSharedService';
import { RequestedProceduresForm } from '../Tetkik_Istem_Modulu/RequestedProceduresForm';
import { TTUser } from 'NebulaClient/StorageManager/Security/TTUser';
import { ReportTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MedulaTreatmentReport } from 'NebulaClient/Model/AtlasClientModel';
import { TTTextBoxColumn } from 'NebulaClient/Visual/Controls/TTGrid/Columns/TTTextBoxColumn';
import { TTButtonColumn } from 'NebulaClient/Visual/Controls/TTGrid/Columns/TTButtonColumn';
import { ENabizDataSets } from '../E_Nabiz_Modulu/ENabizViewModel';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { ConsultationFromExternalHospital } from 'NebulaClient/Model/AtlasClientModel';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { DispatchToOtherHospitalComponentInfoViewModel } from 'Modules/Tibbi_Surec/XXXXXXler_Arasi_Sevk_Modulu/DispatchToOtherHospitalFormViewModel';
import { DispatchToOtherHospitalForm } from '../XXXXXXler_Arasi_Sevk_Modulu/DispatchToOtherHospitalForm';
import { CommonService } from 'app/NebulaClient/Services/ObjectService/CommonService';

import { FormSaveInfo } from "NebulaClient/Mscorlib/FormSaveInfo";

import {
    OpenColorPrescription_Input
} from 'ObjectClassService/DrugOrderIntroductionService';
import { EnumItem } from 'app/NebulaClient/Mscorlib/EnumItem';
import { EpisodeActionService } from 'app/NebulaClient/Services/ObjectService/EpisodeActionService';
import { DateTimePickerFormat } from 'app/NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ActiveIDsModel, ClickFunctionParams, GiveAppointmentModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { IDestroyEvent } from 'app/Interfaces/IDestroyEvent';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { EmergencySpecialityObjectFormViewModel } from '../Acil_Modulu/EmergencySpecialityObjectFormViewModel';
import List from 'app/NebulaClient/System/Collections/List';
import { DailyInpatientInfoModel } from '../Tibbi_Surec_Evrensel_Modulu/EpisodeActionFormViewModel';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { StringParam } from 'app/NebulaClient/Mscorlib/QueryParam';
import { TreatmentMaterialForm } from '../Sarf_Malzeme_Modulu/TreatmentMaterialForm';
import Exception from 'app/NebulaClient/System/Exception';
import { Subscription } from 'rxjs';
import { ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ENabizButtonResponseModel } from 'app/Fw/Components/HvlApp';
import { MorgueExDischargeFormViewModel } from '../Morg_Modulu/MorgueExDischargeFormViewModel';
import { WomanSpecialityFormViewModel } from '../Kadin_Dogum_Modulu/WomanSpecialityFormViewModel';
import { PregnancyStartFormViewModel } from '../Kadin_Dogum_Modulu/PregnancyStartFormViewModel';


@Component({
    selector: 'PatientExaminationDoctorFormNew',
    templateUrl: './PatientExaminationDoctorFormNew.html',
    providers: [MessageService, EpisodeActionHelper, SystemApiService, NqlQueryService]
})
export class PatientExaminationDoctorFormNew extends BaseNewDoctorExaminationForm implements OnInit, AfterViewInit, OnDestroy, IDestroyEvent {
    OnDestroy: EventEmitter<any> = new EventEmitter<any>();
    ReportParamActiveIDsModel: ActiveIDsModel;
    StartPhysiotherapyRequest: TTVisual.ITTCheckBox;
    IsExaminationCompleted: TTVisual.ITTCheckBox;
    cmbTriajCode: TTVisual.ITTEnumComboBox;
    IsApproveMHRSGreenList: TTVisual.ITTCheckBox;
    listBoxTreatmentResult: TTVisual.ITTObjectListBox;
    listViewWorkList: TTVisual.ITTListView;
    MedulaOzelDurum: TTVisual.ITTObjectListBox;
    medulaRefakatciDurumu: TTVisual.ITTCheckBox;
    MedulaSevkTab: TTVisual.ITTTabPage;
    MutatDisiGerekcesi: TTVisual.ITTTextBox;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    rtfComplaint: TTVisual.ITTRichTextBoxControl;
    rtfHistory: TTVisual.ITTRichTextBoxControl;
    rtfPatientStory: TTVisual.ITTRichTextBoxControl;
    rtfPhysicalExamination: TTVisual.ITTRichTextBoxControl;
    MTSConclusion: TTVisual.ITTRichTextBoxControl;
    btnPatientExaminationSave: TTVisual.ITTButton;
    btnPrint: TTVisual.ITTButton;
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
    cmbReportType: TTVisual.ITTEnumComboBox;
    txtReportName: TTTextBoxColumn;
    txtReportRequestReason: TTVisual.TTTextBoxColumn;
    txtReportAdmissionDate: TTVisual.TTTextBoxColumn;
    txtReportMasterResource: TTVisual.TTTextBoxColumn;
    /**Sağlık kurulu çözger mi */
    healthCommitteeIsCozger: boolean = false;
    /** */

    txtStartDate: TTTextBoxColumn;
    txtEndDate: TTTextBoxColumn;
    btnEdit: TTButtonColumn;
    txtProcedureByUser: TTTextBoxColumn;

    /** Geliş Sebebi Değiştirme BEGIN */
    AdmissionType: TTVisual.ITTListDefComboBox;
    MedulaVakaTarihi: TTVisual.ITTDateTimePicker;
    SKRSAdliVaka: TTVisual.ITTListDefComboBox;
    MedulaIstisnaiHalComboBox: TTVisual.ITTListDefComboBox;
    cbx112: TTVisual.ITTCheckBox;
    Emergency112RefNoTextbox: TTVisual.ITTTextBox;
    plakaNo: TTVisual.ITTTextBox;

    public showProvisionTypePopup: boolean;
    public changeProvisionTypeClass: ChangeProvisionTypeClass = new ChangeProvisionTypeClass();
    /** Geliş Sebebi Değiştirme END */

    public enablePrescriptionTab: boolean = true;

    public enableInfluenzaHelpServiceButton: boolean = false;
    reportStartDate: Date = new Date();
    reportEndDatee: Date = new Date();
    injectionStartDate: Date = new Date();
    injectionEndDate: Date = new Date();

    //Prescription Column Definitions
    public PrescriptionGridColumns = [];
    public GridPatientReportsColumns = [];
    public patientExaminationDoctorFormNewViewModel: PatientExaminationDoctorFormNewViewModel = new PatientExaminationDoctorFormNewViewModel();
    public episodeActionObjectID = Guid;
    public statusNotificationReportObject = new StatusNotificationReport;
    public medulaTedaviRaporlariObject = new MedulaTreatmentReport;
    public ParticipationFreeDrugReportNewFormObject = new ParticipatnFreeDrugReport;
    public PrescriptionList: Array<OldDrugOrderIntroduction> = new Array<OldDrugOrderIntroduction>();
    public ReportList: Array<DrugOrderIntroductionDet> = new Array<DrugOrderIntroductionDet>();
    isHealthCommittee: boolean = false;
    private HealthCommiteeActionsGridFilled: boolean = false;
    private ManipulationGridFilled: boolean = false;
    private OldPhysicialExaminationsGridFilled: boolean = false;
    public _groupTabMaximized: boolean = false;
    public currentActionReports: boolean = false;
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    gunubirlikYatisKontrol: boolean = false;
    public get _PatientExamination(): PatientExamination {
        return this._TTObject as PatientExamination;
    }

    ActivePage: string = "muayene";
    RecentActiveTab: string;
    public showMostUsedProceduresInfo: boolean = true;
    _nabizList: Array<ENabizDataSets> = [];
    showNabizPopup = false;
    showStatusNotificationReportForm = false;
    showMedulaTedaviRaporlariForm = false;
    showParticipationFreeDrugReportNewForm = false;
    showreportStartEndDate = false;
    showInjectionReport = false;
    private _eNabizViewModels: Array<any> = [];

    public reportTypeList: Array<EnumItem>;
    public selectedReportType: EnumItem;
    loadingVisible: boolean = false;
    panelMessage: string = "Günübirlik Yatış İşlemleri Yapılıyor Lütfen Bekleyiniz";

    /*Çalışabilir Kağıdı */
    public ShowWorkablePaperPopUp: boolean = false;
    public LeaveDateForWorkablePaper: Date = new Date();
    public WorkDateForWorkablePaper: Date = new Date();

    /*Çalışabilir Kağıdı */

    public showEDurumBildirirComponent = false;
    public showERaporSorgulaComponent = false;

    private refreshReportGridSubscription: Subscription;

    showRadiologyAppointmentPopUp: boolean = false;
    _RadiologyAppointmentList: Array<RadiologyAppointmentInfo> = new Array<RadiologyAppointmentInfo>();

    public RadiologyAppointmentsColumns = [{
        "caption": "İşlem Kodu",
        dataField: "ProcedureCode",
        width: 80,
        allowSorting: false,
        fixed: true
    }, {
        "caption": "İşlem Adı",
        dataField: "ProcedureName",
        width: 250,
        allowSorting: false,
        fixed: true
    }, {
        "caption": "Randevu Tarihi",
        dataField: "AppointmentDate",
        width: 100,
        allowSorting: false,
        fixed: true
    }, {
        "caption": "Randevu Saati",
        dataField: "AppointmentTime",
        width: 80,
        allowSorting: false,
        fixed: true
    }, {
        caption: 'Onayla',
        fixed: true,
        cellTemplate: 'radAppTemplate',
        width: 50
    }];


    private PatientExaminationDoctorFormNew_DocumentUrl: string = '/api/PatientExaminationService/PatientExaminationDoctorFormNew';
    constructor(private services: ServiceContainer,
        protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected modalService: IModalService,
        private sideBarMenuService: ISidebarMenuService,
        public systemApiService: SystemApiService,
        protected objectContextService: ObjectContextService,
        private detector: ApplicationRef,
        protected episodeActionHelper: EpisodeActionHelper,
        protected tabService: IActiveTabService,
        private reportService: AtlasReportService,
        protected helpMenuService: HelpMenuService,
        protected ngZone: NgZone) {
        super(httpService, messageService, modalService, objectContextService, helpMenuService, ngZone);
        this._DocumentServiceUrl = this.PatientExaminationDoctorFormNew_DocumentUrl;
        this.showNabizPopup = false;
        this.initViewModel();
        this.initFormControls();
        this.reportTypeList = ReportTypeEnum.Items;

    }




    TabPanelClick(source) {
        this.tabService.setActiveTab(source, 'pedfn');
        this.RecentActiveTab = source;
    }




    @ViewChild(ProcedureRequestForm) procedureRequestForm: ProcedureRequestForm;
    @ViewChild(RequestedProceduresForm) requestedProceduresFormInstance: RequestedProceduresForm;




    // ***** Method declarations start *****

    public async ProcedureDoctor_SelectedObjectChanged(): Promise<void> {
        if (this.ProcedureDoctor.SelectedObject !== null)
            this._PatientExamination.ResponsibleDoctor = <ResUser>this.ProcedureDoctor.SelectedObject;
        else this._PatientExamination.ResponsibleDoctor = null;
    }
    public async ResponsibleDoctor_SelectedObjectChanged(): Promise<void> {
        if (this._PatientExamination.ResponsibleDoctor !== null) {
            if ((this._PatientExamination.ResponsibleDoctor.Title === UserTitleEnum.UzmanOgr) ||
                (this._PatientExamination.ResponsibleDoctor.Title === UserTitleEnum.DoktoraOgr) ||
                (this._PatientExamination.ResponsibleDoctor.Title === UserTitleEnum.YanDalUzmanOgr) ||
                (this._PatientExamination.ResponsibleDoctor.Title === UserTitleEnum.YLisansUzmanOgr)) {
                TTVisual.InfoBox.Show('Sorumlu/Uzman Doktor Alanı için Uzman Hekim Seçmeniz Gerekmektedir!', MessageIconEnum.WarningMessage);
                this._PatientExamination.ResponsibleDoctor = null;
            } else {

            }
        }
    }





    isHizmetTetkik: any = true;
    isConsultation: any = false;
    isMlzSarf: any = false;
    isRecete: any = false;
    isRaporlar: any = false;
    isSevk: any = false;

    selectTab(e) {
        let selectedItem: string = e.addedItems[0].title;
        if (selectedItem == i18n("M17742", "Konsültasyon")) {
            this.isConsultation = true;
        }
        if (selectedItem == i18n("M20924", "Reçete")) {
            this.isRecete = true;
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
    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    ActiveAcc: string;
    RecentAcc: string;

    AccPinClick(acc) {
        if (this.RecentAcc == acc) {
            this.RecentAcc = undefined;
            this.tabService.setActiveTab(this.RecentAcc, 'pedfnacc');
        }
        else {
            this.RecentAcc = acc;
            this.tabService.setActiveTab(this.RecentAcc, 'pedfnacc');
        }
    }


    showProcedureRequiredInfoClick(): void {

        //this.showPopupRequiredInfoForm = false;
        //this.popupTitleRequiredInfoForm = "Hizmet İstem Zorunlu Bilgiler"

        //this.RequestedProceduresForRequiredInfoForm = new Array<Guid>();

        //for (let req of this.patientExaminationDoctorFormNewViewModel.RequestedProcedures) {
        //    if (req.isAdditionalApplication == false) {
        //        this.RequestedProceduresForRequiredInfoForm.push(req.SubActionProcedureObjectId);
        //    }
        //}

        //if (this.RequestedProceduresForRequiredInfoForm.length > 0) {
        //    this.showPopupRequiredInfoForm = true;
        //}
    }

    public controlInpatient: boolean = false;
    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        await super.AfterContextSavedScript(transDef);
        if (this._ViewModel.IsExaminationCompleted) {
            let isDisabledReport = false;
            if (this._ViewModel._PatientExamination.CurrentStateDefID.toString() !== PatientExamination.PatientExaminationStates.Completed.id) {
                if (this.patientExaminationDoctorFormNewViewModel._PatientExamination.PatientExaminationType === PatientExaminationEnum.HealthCommittee &&
                    this.patientExaminationDoctorFormNewViewModel._PatientExamination.HCExaminationComponent != null &&
                    this.patientExaminationDoctorFormNewViewModel.IsExaminationCompleted && this.patientExaminationDoctorFormNewViewModel.ISSinglePhysicianReport == false) {
                    if (this.patientExaminationDoctorFormNewViewModel._PatientExamination.HCExaminationComponent.EDisabledReport != null)
                        isDisabledReport = true;
                }
                let apiUrlForSaveProcedureRequest: string = 'api/PatientExaminationService/CompleteExamination?IsExaminationCompleted=' +
                    this._ViewModel.IsExaminationCompleted + '&peObjectID=' + this._ViewModel._PatientExamination.ObjectID;
                if (isDisabledReport == true)
                    this.loadPanelOperation(true, "Muayene ve Entegrasyon Süreci Tamamlanıyor, Lütfen Bekleyiniz");
                else
                    this.loadPanelOperation(true, "Muayene İşlemi Tamamlanıyor, Lütfen Bekleyiniz");

                try {
                    let response = await this.httpService.get(apiUrlForSaveProcedureRequest);
                    let result = response;
                } catch (ex) {
                    ServiceLocator.MessageService.showError(ex);
                    this.loadPanelOperation(false, "");

                } finally {
                    this.loadPanelOperation(false, "");

                }
                this.loadPanelOperation(false, "");
                //if (transDef) {
                //const objectIdParam = new GuidParam(this._PatientExamination.ObjectID);
                //let reportParameters: any = { 'OBJECTID': objectIdParam };
                //this.reportService.showReport('PatientExaminationReport', reportParameters);
                //}
            }
        }
        if (this.patientExaminationDoctorFormNewViewModel.GrdExternalConsultationGridList && this.patientExaminationDoctorFormNewViewModel.GrdExternalConsultationGridList.length > 0) {
            for (let extConsultation of this.patientExaminationDoctorFormNewViewModel.GrdExternalConsultationGridList) {
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


        if (this.requestedProceduresFormInstance != undefined && this.requestedProceduresFormInstance.operationControl === true) {
            this.loadingVisible = true;
            await this.requestedProceduresFormInstance.DailyOperationsSave(this.patientExaminationDoctorFormNewViewModel._PatientExamination);
        }

        else if (this.treatmentMaterialFormInstance != undefined && this.treatmentMaterialFormInstance.operationControl === true) {
            this.loadingVisible = true;
            await this.treatmentMaterialFormInstance.DailyOperationsSave(this.patientExaminationDoctorFormNewViewModel._PatientExamination);
        }


        this.loadingVisible = false;

        if (transDef.SaveAndClose === false)
            await this.ngOnInit();

        let pathologyresult: any = await this.requestedProceduresFormInstance.checkPathologyRequest(this.patientExaminationDoctorFormNewViewModel._PatientExamination, transDef.SaveAndClose);

        //Radyoloji Randevu
        if (this.patientExaminationDoctorFormNewViewModel.isRadiologyAppointmentActive == true) {

            await this.CheckScheduledRadiologyAppointments();

        }


    }


    protected async PreScript() {
        super.PreScript();

        this.AddHelpMenu();

        if (this.patientExaminationDoctorFormNewViewModel.StartPhysiotherapyRequest === true) {
            this.StartPhysiotherapyRequest.ReadOnly = true;
        }

        this.getComponentInfo();

        if (this.ActiveIDsModel == null) {
            this.LoadActiveIDsModel();
        }
    }

    protected async ClientSidePreScript(): Promise<void> {
        await super.ClientSidePreScript();
        this.setSpesialityBasedObjectInfo();
        //if (this._PatientExamination.MasterResource != null) {
        //    let resourceStore: Store = await ResourceService.GetStore(this._PatientExamination.MasterResource.ObjectID.toString());

        //    if (resourceStore === null) {
        //        TTVisual.InfoBox.Alert("Uyarı !", this._PatientExamination.MasterResource.Name + " bölümünün deposu bulunmadığı için malzeme sarf işlemi yapamazsınız.", MessageIconEnum.ErrorMessage);
        //    }
        //}
        //this.TreatmentMaterial.ListFilterExpression = "STOCKS.STORE = '" + resourceStore.ObjectID.toString() + "' AND STOCKS.INHELD > 0";

        let drugOrderIntDets: Array<OldDrugOrderIntroduction> = await DrugOrderIntroductionService.GetOldDrugOrderIntroductions(this._PatientExamination.Episode);
        if (drugOrderIntDets !== null) {
            this.PrescriptionList = new Array<OldDrugOrderIntroduction>();
            for (let drugOrder of drugOrderIntDets) {
                this.PrescriptionList.push(drugOrder);
            }
        }
        /*if (drugOrderIntDets != null && drugOrderIntDets.DrugOrderIntroductionDets != null) {
            this.PrescriptionList = new Array<OldDrugOrderIntroduction>();
            for (let drugOrder of drugOrderIntDets.DrugOrderIntroductionDets) {
                let materialObjectID = drugOrder.Material;
                if (materialObjectID != null) {
                    let material = drugOrderIntDets.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                    drugOrder.Material = material;
                }

                this.PrescriptionList.push(drugOrder);
            }
        }*/


        if (this._PatientExamination.PatientExaminationType === PatientExaminationEnum.HealthCommittee) {
            if (this.patientExaminationDoctorFormNewViewModel.ISSinglePhysicianReport == false) {//tek hekim değil ise
                this.IsExaminationCompleted.Visible = true;
                this.IsExaminationCompleted.Value = true;
                this._ViewModel.IsExaminationCompleted = true;
                this.btnPrint.Visible = false;
            }
            else {
                this.IsExaminationCompleted.Visible = false;
                this.IsExaminationCompleted.Value = false;
                this._ViewModel.IsExaminationCompleted = false;
                this.btnPrint.Visible = true;
            }
        } else {
            if (this._PatientExamination.CurrentStateDefID.toString() === PatientExamination.PatientExaminationStates.Examination.id ||
                this._PatientExamination.CurrentStateDefID.toString() === PatientExamination.PatientExaminationStates.ExaminationCompleted.id ||
                this._PatientExamination.CurrentStateDefID.toString() === PatientExamination.PatientExaminationStates.ProcedureRequested.id) {
                this.IsExaminationCompleted.Visible = true;
            }
            else {
                this.IsExaminationCompleted.Visible = false;
            }
            this.IsExaminationCompleted.Value = false;
            this._ViewModel.IsExaminationCompleted = false;
            this.btnPrint.Visible = true;
        }
    }

    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        let that = this;

        this.patientExaminationDoctorFormNewViewModel.GrdConsultationGridList = new Array<Consultation>();
        this.patientExaminationDoctorFormNewViewModel.GrdPatientInterviewFormGridList = new Array<PatientInterviewForm>();
        this.patientExaminationDoctorFormNewViewModel.GrdDentalExaminationGridList = new Array<DentalExamination>();
        this.patientExaminationDoctorFormNewViewModel.GrdExternalConsultationGridList = new Array<ConsultationFromExternalHospital>();
        for (let detailItem of this.patientExaminationDoctorFormNewViewModel.GrdConsAndPatientInterviewFormGridList) {
            if (detailItem instanceof Consultation) {
                this.patientExaminationDoctorFormNewViewModel.GrdConsultationGridList.push(<Consultation>detailItem);
            } else if (detailItem instanceof PatientInterviewForm) {
                this.patientExaminationDoctorFormNewViewModel.GrdPatientInterviewFormGridList.push(<PatientInterviewForm>detailItem);
            } else if (detailItem instanceof ConsultationFromExternalHospital) {
                this.patientExaminationDoctorFormNewViewModel.GrdExternalConsultationGridList.push(<ConsultationFromExternalHospital>detailItem);
            } else if (detailItem instanceof DentalExamination) {
                this.patientExaminationDoctorFormNewViewModel.GrdDentalExaminationGridList.push(<DentalExamination>detailItem);
            }
        }

        if (this.patientExaminationDoctorFormNewViewModel.ConsultationsHistory != null)
            this.patientExaminationDoctorFormNewViewModel.ConsultationsHistory.Clear();

        if (that.patientExaminationDoctorFormNewViewModel._PatientExamination.TreatmentResult && that.patientExaminationDoctorFormNewViewModel._PatientExamination.TreatmentResult.KODU == "6") { //Ölüm       
            this.openOBS();
        }



    }
    protected async openOBS() {
        let that = this;
        this.loadPanelOperation(true, 'Ölüm Bildirim Ekranı Açılıyor, Lütfen Bekleyiniz.');
        let fullApiUrl: string = 'api/TreatmentDischargeService/OpenOBS?SubepisodeID=' + this.patientExaminationDoctorFormNewViewModel.SubepisodeID + '&ProcedureDoctorObjectIDForOBS=' + this.patientExaminationDoctorFormNewViewModel.ProcedureDoctorObjectIDForOBS;
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
            this.loadPanelOperation(false, '');
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
            this.loadPanelOperation(false, '');
        });
    }

    public onIsExaminationCompleted(event): void {
        if (event != null) {
            if (this.IsExaminationCompleted != null) {
                this.IsExaminationCompleted.Value = event;
                this._ViewModel.IsExaminationCompleted = event;
            }
        }
    }

    // public onlistBoxTreatmentResultCleared(event): void {
    //     if (event == null) {
    //         if (this._PatientExamination != null && this._PatientExamination.TreatmentResult !== event) {
    //             this._PatientExamination.TreatmentResult = null;
    //         }
    //     }
    // }

    activeIdsParam: ActiveIDsModel = null;
    showSurgeryAppointmentForm: boolean = false;

    public showSurgeryAppointmentFormPopUp() {
        this.activeIdsParam = this.getClickFunctionParams().Params;
        this.showSurgeryAppointmentForm = true;
    }

    public CloseSurgeryAppointmentPopUp(event) {
        this.activeIdsParam = null;
        this.showSurgeryAppointmentForm = false;
    }

    private async PatientExaminationSave(saveInfo?: FormSaveInfo) {
        try {

            if (this.patientExaminationDoctorFormNewViewModel.SpecialityBasedObjectViewModels != null) {
                if (this.patientExaminationDoctorFormNewViewModel.SpecialityBasedObjectViewModels[0] instanceof EmergencySpecialityObjectFormViewModel) {
                    let viewModel: EmergencySpecialityObjectFormViewModel = this.patientExaminationDoctorFormNewViewModel.SpecialityBasedObjectViewModels[0];

                    if (viewModel._EmergencySpecialityObject.Triage == null) {
                        ServiceLocator.MessageService.showError("Triaj Kodu alanı boş olamaz");
                        return;
                    }
                    else if (viewModel._EmergencySpecialityObject.Triage.KODU == '0') {
                        ServiceLocator.MessageService.showError("'Triaj kodu' alanı bu adımda 'Belirtilmemiş' olarak seçilemez.");
                        return;

                    }
                    else if (viewModel._EmergencySpecialityObject.Triage.KODU == '1') {
                        let procedureCount = 0;
                        let filtredProcedure: Array<vmRequestedProcedure> = new Array<vmRequestedProcedure>();
                        //emergencyInterventiona bağlı işlem
                        filtredProcedure = filtredProcedure.concat(this.requestedProceduresFormInstance.RequestedProcedures.filter(x => x.EpisodeActionObjectId
                            == this.patientExaminationDoctorFormNewViewModel._PatientExamination.EmergencyIntervention.ObjectID && x.StateStatus != 4));

                        //uzmanlığa bağlı varsa
                        filtredProcedure = filtredProcedure.concat(this.requestedProceduresFormInstance.RequestedProcedures.filter(x => x.EpisodeActionObjectId
                            == viewModel._EmergencySpecialityObject.ObjectID && x.StateStatus != 4));

                        //direk muayeneye bağlı işlemler
                        filtredProcedure = filtredProcedure.concat(this.requestedProceduresFormInstance.RequestedProcedures.filter(x => x.EpisodeActionObjectId
                            == this.patientExaminationDoctorFormNewViewModel._PatientExamination.ObjectID && x.StateStatus != 4));

                        //yeni eklenenler    
                        filtredProcedure = filtredProcedure.concat(this.requestedProceduresFormInstance.RequestedProcedures.filter(x => x.EpisodeActionObjectId == null));

                        if (filtredProcedure != null && filtredProcedure.length > 0)
                            procedureCount = filtredProcedure.length;

                        if (procedureCount > 1)
                            throw new TTException("Yeşil Alan Muayenesi olan vakalarda başka hizmet bilgisi olmamalıdır.");
                        else if (procedureCount == 1
                            && filtredProcedure[0].ProcedureObjectId != this.patientExaminationDoctorFormNewViewModel.GreenAreaExaminationProcedureObjectId
                            && filtredProcedure[0].ProcedureObjectId != this.patientExaminationDoctorFormNewViewModel.EmergencyExaminationProcedureObjectId)
                            throw new TTException("Yeşil Alan Muayenesi olan vakalarda başka hizmet bilgisi olmamalıdır.");
                    }
                    // else if(this.patientExaminationDoctorFormNewViewModel._PatientExamination.EmergencyIntervention.Triage != null
                    //     && )

                    // else if(viewModel._EmergencySpecialityObject.Triage.KODU != "1")//yeşil değil

                    this.patientExaminationDoctorFormNewViewModel._PatientExamination.EmergencyIntervention.Triage = viewModel._EmergencySpecialityObject.Triage;
                }

                if (this.patientExaminationDoctorFormNewViewModel.SpecialityBasedObjectViewModels[0] instanceof WomanSpecialityFormViewModel) {
                    let viewModel: WomanSpecialityFormViewModel = this.patientExaminationDoctorFormNewViewModel.SpecialityBasedObjectViewModels[0];

                    if (viewModel._PostpartumFollowUpFormViewModel != null) {
                        if (viewModel._PostpartumFollowUpFormViewModel._PostpartumFollowUp.WhichPostpartumFollowUp == null) {
                            ServiceLocator.MessageService.showError('Kaçıncı lohusa izlem alanı boş bırakılamaz');
                            return;
                        }
                        if (viewModel._PostpartumFollowUpFormViewModel._PostpartumFollowUp.IronLogisticsAndSupplement == null) {
                            ServiceLocator.MessageService.showError('Demir Lojistiği ve Desteği alanı boş bırakılamaz');
                            return;
                        }
                        if (viewModel._PostpartumFollowUpFormViewModel._PostpartumFollowUp.VitaminDSupplements == null) {
                            ServiceLocator.MessageService.showError('D Vitamini Lojistiği ve Desteği alanı boş bırakılamaz');
                            return;
                        }
                        if (viewModel._PostpartumFollowUpFormViewModel._PostpartumFollowUp.UterusInvolution == null) {
                            ServiceLocator.MessageService.showError('Uterus Involusyon alanı boş bırakılamaz');
                            return;
                        }
                        if (viewModel._PostpartumFollowUpFormViewModel._PostpartumFollowUp.CongenitalAnomalies == null) {
                            ServiceLocator.MessageService.showError('Konjenital Anomali Varlığı alanı boş bırakılamaz');
                            return;
                        }
                        if (viewModel._PostpartumFollowUpFormViewModel._PostpartumFollowUp.PostpartumDepression == null) {
                            ServiceLocator.MessageService.showError('Postpartum Depresyon alanı boş bırakılamaz');
                            return;
                        }
                    }
                }
            }

            this.loadPanelOperation(true, 'İşlem kaydediliyor, lütfen bekleyiniz.');
            if (this.patientExaminationDoctorFormNewViewModel._PatientExamination["HCExaminationComponent"] != null) {
                await this.CheckIsDiagnosisExistsForCommitteeExamination(this.patientExaminationDoctorFormNewViewModel._PatientExamination, this.patientExaminationDoctorFormNewViewModel.GridEpisodeDiagnosisGridList);

            } else {
                await this.CheckIsDiagnosisExists(this.patientExaminationDoctorFormNewViewModel.GridEpisodeDiagnosisGridList);
            }
            if (this.patientExaminationDoctorFormNewViewModel._PatientExamination.ProcedureDoctor == null)
                throw new TTException(i18n("M22146", "Sorumlu doktor seçmeden muayene kaydedemezsiniz."));


            if (this.patientExaminationDoctorFormNewViewModel.IsDischarged == true)
                throw new TTException(i18n("M22146", "Taburculuğu tamamlanmış ücretli hastalarda yeni işlem yapılamaz."));

            if (this.patientExaminationDoctorFormNewViewModel._PatientExamination.PatientExaminationType === PatientExaminationEnum.HealthCommittee &&
                this.patientExaminationDoctorFormNewViewModel._PatientExamination.HCExaminationComponent != null &&
                this.patientExaminationDoctorFormNewViewModel.IsExaminationCompleted && this.patientExaminationDoctorFormNewViewModel.ISSinglePhysicianReport == false) {
                if (this.patientExaminationDoctorFormNewViewModel._PatientExamination.HCExaminationComponent.OfferOfDecision == null)
                    throw new TTException(i18n("M17286", "Karar Teklifi Yazmadan Sağlık Kurulu Muayenesini Tamamlayamazsınız ! "));
                else if (this.patientExaminationDoctorFormNewViewModel._PatientExamination.TreatmentResult == null)
                    throw new TTException(i18n("M17286", "Tedavi Sonucunu Seçmeden Sağlık Kurulu Muayenesini Tamamlayamazsınız ! "));
                else if (this.patientExaminationDoctorFormNewViewModel._PatientExamination.HCExaminationComponent.EDisabledReport != null && this.patientExaminationDoctorFormNewViewModel._PatientExamination.HCExaminationComponent.DisabledRatio == null)
                    throw new TTException("Engel Oranı Yazmadan Sağlık Kurulu Muayenesini Tamamlayamazsınız ! ");
                else if (this.healthCommitteeIsCozger == true
                    && (this.patientExaminationDoctorFormNewViewModel._PatientExamination.HCExaminationComponent.CozgerSpecReqArea == null
                        || this.patientExaminationDoctorFormNewViewModel._PatientExamination.HCExaminationComponent.CozgerSpecReqLevel == null))
                    throw new TTException("Çözger Raporlarında Özel Gereksinim Alanı ve Seviyesi Seçmeden Sağlık Kurulu Muayenesini Tamamlayamazsınız ! ");
            }

            if (this.patientExaminationDoctorFormNewViewModel._PatientExamination.CurrentStateDefID.toString() === PatientExamination.PatientExaminationStates.Completed.id) {
                if (this.patientExaminationDoctorFormNewViewModel._PatientExamination.HCExaminationComponent != null)
                    throw new TTException("Tamamlanmış Sağlık Kurulu Muayeneleri Üzerinde Değişiklik Yapamazsınız.");
                // else if(this.patientExaminationDoctorFormNewViewModel.DayLimitExceeded != 0)
                //     throw new TTException("Muayene işlemi üzerinden "+this.patientExaminationDoctorFormNewViewModel.DayLimitExceeded + " gün geçtiği için değişiklik yapamazsınız.");
            }


            if (this.patientExaminationDoctorFormNewViewModel.ConsultationsHistory != null)
                this.patientExaminationDoctorFormNewViewModel.ConsultationsHistory.Clear();


            let saveuserOption = await this.requestedProceduresFormInstance.saveProcedureTestFilterUserOption();
            let returnValue: number;
            returnValue = await this.requestedProceduresFormInstance.fireRequestedProceduresActions(this.patientExaminationDoctorFormNewViewModel._PatientExamination);
            if (returnValue === 0) {
                this.patientExaminationDoctorFormNewViewModel.createNewProcedure = true;
            }
            else if (returnValue === 2) {
                throw new TTException(i18n("M22395", "SUT Kural ihlali oldu ve işlemden vazgeçildi!"));

            }

            if (returnValue != null) {
                if (this.patientExaminationDoctorFormNewViewModel.isENabizActive)
                    this.checkENabiz(saveInfo);
                else
                    await this.save(saveInfo);
            }


            this.loadPanelOperation(false, '');

        } catch (err) {
            ServiceLocator.MessageService.showError(err);
            this.loadPanelOperation(false, '');
        }
    }

    showWorkableReportPopUp() {
        this.ShowWorkablePaperPopUp = true;
    }

    public createWorkableReport() {
        this.helpMenuService.printIsBasiCalisirKagidiReport(new Guid(this.patientExaminationDoctorFormNewViewModel.SubepisodeID), this.WorkDateForWorkablePaper, this.LeaveDateForWorkablePaper, this.getClickFunctionParams());
    }

    colorPresClick() {
        let input: OpenColorPrescription_Input = new OpenColorPrescription_Input();
        input.SubEpisodeObjectID = new Guid(this._PatientExamination.SubEpisode.toString());
        let fullApiUrl: string = 'api/DrugOrderIntroductionService/OpenColorPrescriptionWithJSON';
        this.httpService.post(fullApiUrl, input).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public async btnPatientExaminationSave_Click(event) {
        if (event.component != null) {
            let component = event.component,
                prevClickTime = component.lastClickTime;
            if (isNaN(Number(this.patientExaminationDoctorFormNewViewModel.anamnesisFormViewModel.vitalSingsViewModel.Height_Value))) {
                this.messageService.showError("Boy alanı için sayısal bir değer girilmelidir.");
                return;
            }
            if (isNaN(Number(this.patientExaminationDoctorFormNewViewModel.anamnesisFormViewModel.vitalSingsViewModel.Weight_Value))) {
                this.messageService.showError("Kilo alanı için sayısal bir değer girilmelidir.");
                return;
            }
            component.lastClickTime = new Date();
            if (prevClickTime && (component.lastClickTime - prevClickTime < 500)) {
                ServiceLocator.MessageService.showInfo("İşleminiz gerçekleştiriliyor, Lütfen Bekleyiniz...");
            }
            else {
                const param = new FormSaveInfo(this._EpisodeAction.ObjectDefID.toString(), false);
                this.PatientExaminationSave(param);
            }
        }
    }

    public async btnPatientExaminationSaveAndClose_Click(event) {
        if (event.component != null) {
            let component = event.component,
                prevClickTime = component.lastClickTime;
            component.lastClickTime = new Date();
            if (prevClickTime && (component.lastClickTime - prevClickTime < 500)) {
                ServiceLocator.MessageService.showInfo("İşleminiz gerçekleştiriliyor, Lütfen Bekleyiniz...");
            }
            else {
                const param = new FormSaveInfo(this._EpisodeAction.ObjectDefID.toString(), true);
                this.PatientExaminationSave(param);
            }
        }
    }

    public async btnPatientExaminationCancel_Click(event) {
        await this.cancel();
    }

    public async btnPrint_Click() {
        try {
            const objectIdParam = new GuidParam(this._PatientExamination.ObjectID);
            let reportParameters: any = { 'OBJECTID': objectIdParam };
            this.reportService.showReport('PatientExaminationReport', reportParameters);
        } catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }

    public async btnAppointment_Click() {
        try {
            let result = await this.showAppointmentForm(null);
            if (result.Result === DialogResult.Cancel) {
                ServiceLocator.MessageService.showError(i18n("M16907", "İşlemden vazgeçildi"));
                return;
            }
        } catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }

    /** Geliş Sebebi Değiştirme BEGIN*/
    public onAdmissionTypeChanged(event): void {

        if (this.changeProvisionTypeClass != null && this.changeProvisionTypeClass.AdmissionType != event) {
            this.changeProvisionTypeClass.AdmissionType = event;
        }
    }

    public onMedulaVakaTarihiChanged(event): void {

        if (this.changeProvisionTypeClass != null && this.changeProvisionTypeClass.MedulaVakaTarihi != event) {
            this.changeProvisionTypeClass.MedulaVakaTarihi = event;
        }

    }

    public onSKRSAdliVakaChanged(event): void {

        if (this.changeProvisionTypeClass != null && this.changeProvisionTypeClass.SKRSAdliVaka != event) {
            this.changeProvisionTypeClass.SKRSAdliVaka = event;
        }

    }

    public onMedulaIstisnaiHalComboBoxChanged(event): void {

        if (this.changeProvisionTypeClass.MedulaIstisnaiHal != event) {
            this.changeProvisionTypeClass.MedulaIstisnaiHal = event;
            if (event != null)
                this.MedulaIstisnaiHalComboBox.BackColor = "white";
        }

    }

    public onEmergency112RefNoChanged(event): void {
        if (event != null) {
            if (this.changeProvisionTypeClass != null && this.changeProvisionTypeClass.Emergency112RefNo != event) {
                this.changeProvisionTypeClass.Emergency112RefNo = event;
            }
            this.Emergency112RefNoTextbox.BackColor = "white";
        }
    }
    public onSevkli112Changed(event): void {
        if (event != null) {
            if (this.changeProvisionTypeClass != null && this.changeProvisionTypeClass.Sevkli112 != event) {
                this.changeProvisionTypeClass.Sevkli112 = event;
            }

            if (event)
                this.Emergency112RefNoTextbox.ReadOnly = false;
            else {
                this.Emergency112RefNoTextbox.ReadOnly = true;
                this.changeProvisionTypeClass.Emergency112RefNo = null;
            }
        }
    }

    public onplakaNoChanged(event): void {

        if (this.changeProvisionTypeClass.MedulaPlakaNo != event) {
            this.changeProvisionTypeClass.MedulaPlakaNo = event;
        }

    }
    /** Geliş Sebebi Değiştirme END*/


    // *****Method declarations end *****

    public initViewModel(): void {

        this._TTObject = new PatientExamination();
        this.patientExaminationDoctorFormNewViewModel = new PatientExaminationDoctorFormNewViewModel();

        this.patientExaminationDoctorFormNewViewModel._PatientExamination = this._TTObject as PatientExamination;
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.Episode = new Episode();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.Episode.Patient = new Patient();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.Episode.Patient.MedicalInformation = new MedicalInformation();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.Episode.Patient.MedicalInformation.MedicalInfoHabits = new MedicalInfoHabits();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.Episode.Patient.MedicalInformation.MedicalInfoHabits.CigaretteUsageFrequency = new SKRSSigaraKullanimi();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.Episode.Patient.MedicalInformation.MedicalInfoHabits.AlcoholUsageFrequency = new SKRSAlkolKullanimi();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.Episode.Patient.MedicalInformation.MedicalInfoDisabledGroup = new MedicalInfoDisabledGroup();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.Episode.Patient.MedicalInformation.MedicalInfoAllergies = new MedicalInfoAllergies();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.Episode.Patient.MedicalInformation.MedicalInfoAllergies.MedicalInfoFoodAllergies = new Array<MedicalInfoFoodAllergies>();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.Episode.Patient.MedicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies = new Array<MedicalInfoDrugAllergies>();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.Episode.Patient.ImportantMedicalInformation = new ImportantMedicalInformation();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.Episode.Patient.ImportantMedicalInformation.DiagnosisHistory = new Array<DiagnosisGrid>();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.OzelDurum = new OzelDurum();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.HCExaminationComponent = new HCExaminationComponent();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.EmergencyIntervention = new EmergencyIntervention();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.TreatmentResult = new SKRSCikisSekli();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.Diagnosis = new Array<DiagnosisGrid>();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.ResponsibleDoctor = new ResUser();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.ProcedureDoctor = new ResUser();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.ProcedureSpeciality = new SpecialityDefinition();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.MasterResource = new ResSection();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.PatientExaminationAdditionalApplications = new Array<PatientExaminationAdditionalApplication>();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.PatientExaminationTreatmentMaterials = new Array<PatientExaminationTreatmentMaterial>();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.Consultations = new Array<Consultation>();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.PatientInteviewForms = new Array<PatientInterviewForm>();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.LinkedDentalConsultations = new Array<DentalExamination>();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.MedulaSevkDonusVasitasi = new SevkVasitasi();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.DispatchedSpeciality = new SpecialityDefinition();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.MTSHospitalSendingTo = new ResSection();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.DoctorsGrid = new Array<DoctorGrid>();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.SingleNursingOrders = new Array<SingleNursingOrder>();
        this.patientExaminationDoctorFormNewViewModel._PatientExamination.PatientExaminationForensicProcedure = new Array<PatientExaminationForensicProcedure>();
        this.patientExaminationDoctorFormNewViewModel.RequestedProcedures = new Array<vmRequestedProcedure>();
        this.patientExaminationDoctorFormNewViewModel.UserMostUsedFormDefinitions = new Array<vmProcedureRequestFormDefinition>();
        this.patientExaminationDoctorFormNewViewModel.ProcedureRequestFormResourceIDs = new Array<Guid>();
        this._ViewModel = this.patientExaminationDoctorFormNewViewModel;
    }

    protected loadViewModel() {
        let that = this;
        that.patientExaminationDoctorFormNewViewModel = this._ViewModel as PatientExaminationDoctorFormNewViewModel;
        that.patientExaminationDoctorFormNewViewModel.createNewProcedure = false;
        that.patientExaminationDoctorFormNewViewModel.RequestedProcedures = new Array<vmRequestedProcedure>();
        that.patientExaminationDoctorFormNewViewModel.UserMostUsedFormDefinitions = new Array<vmProcedureRequestFormDefinition>();
        that.patientExaminationDoctorFormNewViewModel.ProcedureRequestFormResourceIDs = new Array<Guid>();
        that._TTObject = this.patientExaminationDoctorFormNewViewModel._PatientExamination;
        that.patientExaminationDoctorFormNewViewModel.EpisodeAction = this.patientExaminationDoctorFormNewViewModel._PatientExamination;
        if (this.patientExaminationDoctorFormNewViewModel == null)
            this.patientExaminationDoctorFormNewViewModel = new PatientExaminationDoctorFormNewViewModel();
        if (this.patientExaminationDoctorFormNewViewModel._PatientExamination == null)
            this.patientExaminationDoctorFormNewViewModel._PatientExamination = new PatientExamination();
        if (this.patientExaminationDoctorFormNewViewModel.NewConsultationRequests == null)
            this.patientExaminationDoctorFormNewViewModel.NewConsultationRequests = new Array<NewConsultationRequestInfo>();
        let episodeObjectID = that.patientExaminationDoctorFormNewViewModel._PatientExamination['Episode'];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.patientExaminationDoctorFormNewViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.patientExaminationDoctorFormNewViewModel._PatientExamination.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode['Patient'];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.patientExaminationDoctorFormNewViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                    this.services.Navigator.setTransferParameters('PatientObjectID', patientObjectID);
                    if (patient) {
                        episode.Patient = patient;
                    }
                    if (patient != null) {
                        let importantMedicalInformationObjectID = patient['ImportantMedicalInformation'];
                        if (importantMedicalInformationObjectID != null && (typeof importantMedicalInformationObjectID === 'string')) {
                            let importantMedicalInformation = that.patientExaminationDoctorFormNewViewModel.ImportantMedicalInformations.find(o =>
                                o.ObjectID.toString() === importantMedicalInformationObjectID.toString());
                            if (importantMedicalInformation) {
                                patient.ImportantMedicalInformation = importantMedicalInformation;
                            }
                            if (importantMedicalInformation != null) {
                                if (that.patientExaminationDoctorFormNewViewModel.DiagnosisHistoryGridList) {
                                    importantMedicalInformation.DiagnosisHistory = that.patientExaminationDoctorFormNewViewModel.DiagnosisHistoryGridList;
                                    for (let detailItem of that.patientExaminationDoctorFormNewViewModel.DiagnosisHistoryGridList) {
                                        let diagnoseObjectID = detailItem['Diagnose'];
                                        if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
                                            let diagnose = that.patientExaminationDoctorFormNewViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                                            if (diagnose) {
                                                detailItem.Diagnose = diagnose;
                                            }
                                        }
                                        let responsibleUserObjectID = detailItem['ResponsibleUser'];
                                        if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === 'string')) {
                                            let responsibleUser = that.patientExaminationDoctorFormNewViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
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
            }
            if (episode != null) {
                episode.Diagnosis = that.patientExaminationDoctorFormNewViewModel.GridEpisodeDiagnosisGridList;
                for (let detailItem of that.patientExaminationDoctorFormNewViewModel.GridEpisodeDiagnosisGridList) {
                    let diagnoseObjectID = detailItem['Diagnose'];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
                        let diagnose = that.patientExaminationDoctorFormNewViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                        if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem['ResponsibleUser'];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === 'string')) {
                        let responsibleUser = that.patientExaminationDoctorFormNewViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                        if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }
            }
        }
        let ozelDurumObjectID = that.patientExaminationDoctorFormNewViewModel._PatientExamination['OzelDurum'];
        if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === 'string')) {
            let ozelDurum = that.patientExaminationDoctorFormNewViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
            if (ozelDurum) {
                that.patientExaminationDoctorFormNewViewModel._PatientExamination.OzelDurum = ozelDurum;
            }
        }
        let emergencyInterventionObjectID = that.patientExaminationDoctorFormNewViewModel._PatientExamination['EmergencyIntervention'];
        if (emergencyInterventionObjectID != null && (typeof emergencyInterventionObjectID === 'string')) {
            let emergencyIntervention = that.patientExaminationDoctorFormNewViewModel.EmergencyInterventions.find(o => o.ObjectID.toString() === emergencyInterventionObjectID.toString());
            if (emergencyIntervention) {
                that.patientExaminationDoctorFormNewViewModel._PatientExamination.EmergencyIntervention = emergencyIntervention;
            }
        }
        let treatmentResultObjectID = that.patientExaminationDoctorFormNewViewModel._PatientExamination['TreatmentResult'];
        if (treatmentResultObjectID != null && (typeof treatmentResultObjectID === 'string')) {
            let treatmentResult = that.patientExaminationDoctorFormNewViewModel.SKRSCikisSeklis.find(o => o.ObjectID.toString() === treatmentResultObjectID.toString());
            if (treatmentResult) {
                that.patientExaminationDoctorFormNewViewModel._PatientExamination.TreatmentResult = treatmentResult;
            }
        }
        let hcExaminationComponentObjectID = that.patientExaminationDoctorFormNewViewModel._PatientExamination['HCExaminationComponent'];
        if (hcExaminationComponentObjectID != null && (typeof hcExaminationComponentObjectID === 'string')) {
            let hcExaminationComponent = that.patientExaminationDoctorFormNewViewModel.HCExaminationComponents.find(o => o.ObjectID.toString() === hcExaminationComponentObjectID.toString());
            if (hcExaminationComponent) {
                that.patientExaminationDoctorFormNewViewModel._PatientExamination.HCExaminationComponent = hcExaminationComponent;
                //console.log(this.patientExaminationDoctorFormNewViewModel._PatientExamination.HCExaminationComponent);
            }
        }
        let responsibleDoctorObjectID = that.patientExaminationDoctorFormNewViewModel._PatientExamination['ResponsibleDoctor'];
        if (responsibleDoctorObjectID != null && (typeof responsibleDoctorObjectID === 'string')) {
            let responsibleDoctor = that.patientExaminationDoctorFormNewViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleDoctorObjectID.toString());
            if (responsibleDoctor) {
                that.patientExaminationDoctorFormNewViewModel._PatientExamination.ResponsibleDoctor = responsibleDoctor;
            }
        }
        let procedureDoctorObjectID = null;
        if (TTUser.CurrentUser.ResponsibleSpecialist && TTUser.CurrentUser.UserObject) {
            let currentRes = <ResUser>TTUser.CurrentUser.UserObject;
            if (!currentRes.TakesPerformanceScore)
                procedureDoctorObjectID = TTUser.CurrentUser.ResponsibleSpecialist.ObjectID;
        }
        if (!procedureDoctorObjectID)
            procedureDoctorObjectID = that.patientExaminationDoctorFormNewViewModel._PatientExamination['ProcedureDoctor'];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
            let procedureDoctor = that.patientExaminationDoctorFormNewViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
            if (procedureDoctor) {
                that.patientExaminationDoctorFormNewViewModel._PatientExamination.ProcedureDoctor = procedureDoctor;
            }
            that.patientExaminationDoctorFormNewViewModel.ProcedureRequestFormResourceIDs.push(procedureDoctor.ObjectID);
        }
        let procedureSpecialityObjectID = that.patientExaminationDoctorFormNewViewModel._PatientExamination['ProcedureSpeciality'];
        if (procedureSpecialityObjectID != null && (typeof procedureSpecialityObjectID === 'string')) {
            let procedureSpeciality = that.patientExaminationDoctorFormNewViewModel.SpecialityDefinitions.find(o => o.ObjectID.toString() === procedureSpecialityObjectID.toString());
            if (procedureSpeciality) {
                that.patientExaminationDoctorFormNewViewModel._PatientExamination.ProcedureSpeciality = procedureSpeciality;
            }

        }
        let masterResourceObjectID = that.patientExaminationDoctorFormNewViewModel._PatientExamination['MasterResource'];
        if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
            let masterResource = that.patientExaminationDoctorFormNewViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
            if (masterResource) {
                that.patientExaminationDoctorFormNewViewModel._PatientExamination.MasterResource = masterResource;
            }
            that.ProcedureDoctor.ListFilterExpression = 'USERRESOURCES.RESOURCE =\'' + masterResource.ObjectID.toString() + '\'';
            //that.patientExaminationDoctorFormNewViewModel._PatientExaminationMasterResourceID = masterResource.ObjectID;
            that.patientExaminationDoctorFormNewViewModel.ProcedureRequestFormResourceIDs.push(masterResource.ObjectID);
        }
        //that.patientExaminationDoctorFormNewViewModel._PatientExamination.PatientExaminationAdditionalApplications = that.patientExaminationDoctorFormNewViewModel.GridAdditionalApplicationsGridList;
        //for (let detailItem of that.patientExaminationDoctorFormNewViewModel.GridAdditionalApplicationsGridList) {
        //    let procedureObjectObjectID = detailItem['ProcedureObject'];
        //    if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
        //        let procedureObject = that.patientExaminationDoctorFormNewViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
        //        detailItem.ProcedureObject = procedureObject;
        //    }
        //    // tslint:disable-next-line:no-shadowed-variable
        //    let procedureDoctorObjectID = detailItem['ProcedureDoctor'];
        //    if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
        //        let procedureDoctor = that.patientExaminationDoctorFormNewViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
        //        detailItem.ProcedureDoctor = procedureDoctor;
        //    }
        //    //TODO BB
        //    /*  let episodeActionObjectID = detailItem["EpisodeAction"];
        //      if (episodeActionObjectID != null && (typeof episodeActionObjectID === 'string')) {
        //          let episodeAction = that.patientExaminationDoctorFormNewViewModel.EpisodeActions.find(o => o.ObjectID.toString() === episodeActionObjectID.toString());
        //          detailItem.EpisodeAction = episodeAction;
        //          if (episodeAction != null) {
        //              let masterResourceObjectID = episodeAction["MasterResource"];
        //              if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
        //                  let masterResource = that.patientExaminationDoctorFormNewViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
        //                  episodeAction.MasterResource = masterResource;
        //              }
        //          }
        //      }
        //      */
        //}
        /*      that.patientExaminationDoctorFormNewViewModel._PatientExamination.PatientExaminationTreatmentMaterials = that.patientExaminationDoctorFormNewViewModel.GridTreatmentMaterialsGridList;
              for (let detailItem of that.patientExaminationDoctorFormNewViewModel.GridTreatmentMaterialsGridList) {
                  let materialObjectID = detailItem['Material'];
                  if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                      let material = that.patientExaminationDoctorFormNewViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                      if (material) {
                          detailItem.Material = material;
                      }
                      if (material != null) {
                          let stockCardObjectID = material['StockCard'];
                          if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                              let stockCard = that.patientExaminationDoctorFormNewViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                              if (stockCard) {
                                  material.StockCard = stockCard;
                              }
                              if (stockCard != null) {
                                  let distributionTypeObjectID = stockCard['DistributionType'];
                                  if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                      let distributionType = that.patientExaminationDoctorFormNewViewModel.DistributionTypeDefinitions.find(o =>
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
                      let ozelDurum = that.patientExaminationDoctorFormNewViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                      if (ozelDurum) {
                          detailItem.OzelDurum = ozelDurum;
                      }
                  }
              } */

        for (let detailItem of that.patientExaminationDoctorFormNewViewModel.NewGridTreatmentMaterialsGridList) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.patientExaminationDoctorFormNewViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material['StockCard'];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.patientExaminationDoctorFormNewViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard['DistributionType'];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.patientExaminationDoctorFormNewViewModel.DistributionTypeDefinitions.find(o =>
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
                let ozelDurum = that.patientExaminationDoctorFormNewViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                if (ozelDurum) {
                    detailItem.OzelDurum = ozelDurum;
                }
            }

            let subEpisodeID = detailItem['SubEpisode'];
            if (subEpisodeID != null && (typeof subEpisodeID === 'string')) {
                let subEpisode = that.patientExaminationDoctorFormNewViewModel.SubEpisodeList.find(o => o.ObjectID.toString() === subEpisodeID.toString());
                if (subEpisode) {
                    detailItem.SubEpisode = subEpisode;
                }
            }

            let episodeActionID = detailItem['EpisodeAction'];
            if (episodeActionID != null && (typeof episodeActionID === 'string')) {
                let episodeAction = that.patientExaminationDoctorFormNewViewModel.EpisodeActionList.find(o => o.ObjectID != null && o.ObjectID.toString() === episodeActionID.toString());
                if (episodeAction) {
                    detailItem.EpisodeAction = episodeAction;
                }
            }

        }

        for (let detailItem of that.patientExaminationDoctorFormNewViewModel.GrdConsAndPatientInterviewFormGridList) {
            if (detailItem instanceof Consultation) {
                that.patientExaminationDoctorFormNewViewModel.GrdConsultationGridList.push(<Consultation>detailItem);
            } else if (detailItem instanceof PatientInterviewForm) {
                that.patientExaminationDoctorFormNewViewModel.GrdPatientInterviewFormGridList.push(<PatientInterviewForm>detailItem);
            } else if (detailItem instanceof ConsultationFromExternalHospital) {
                that.patientExaminationDoctorFormNewViewModel.GrdExternalConsultationGridList.push(<ConsultationFromExternalHospital>detailItem);
            } else if (detailItem instanceof DentalExamination) {
                that.patientExaminationDoctorFormNewViewModel.GrdDentalExaminationGridList.push(<DentalExamination>detailItem);
            }
        }
        that.patientExaminationDoctorFormNewViewModel._PatientExamination.Consultations = that.patientExaminationDoctorFormNewViewModel.GrdConsultationGridList;
        for (let detailItem of that.patientExaminationDoctorFormNewViewModel.GrdConsultationGridList) {
            // tslint:disable-next-line:no-shadowed-variable
            let masterResourceObjectID = detailItem['MasterResource'];
            if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
                let masterResource = that.patientExaminationDoctorFormNewViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
                if (masterResource) {
                    detailItem.MasterResource = masterResource;
                }
            }
            // tslint:disable-next-line:no-shadowed-variable
            let procedureDoctorObjectID = detailItem['ProcedureDoctor'];
            if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
                let procedureDoctor = that.patientExaminationDoctorFormNewViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                if (procedureDoctor) {
                    detailItem.ProcedureDoctor = procedureDoctor;
                }
            }
            let procedureSpecialityObjectID = detailItem['ProcedureSpeciality'];
            if (procedureSpecialityObjectID != null && (typeof procedureSpecialityObjectID === 'string')) {
                let procedureSpeciality = that.patientExaminationDoctorFormNewViewModel.SpecialityDefinitions.find(o => o.ObjectID.toString() === procedureSpecialityObjectID.toString());
                if (procedureSpeciality) {
                    detailItem.ProcedureSpeciality = procedureSpeciality;
                }
            }
        }
        that.patientExaminationDoctorFormNewViewModel._PatientExamination.LinkedDentalConsultations = that.patientExaminationDoctorFormNewViewModel.GrdDentalExaminationGridList;
        for (let detailItem of that.patientExaminationDoctorFormNewViewModel.GrdDentalExaminationGridList) {
            // tslint:disable-next-line:no-shadowed-variable
            let masterResourceObjectID = detailItem['MasterResource'];
            if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
                let masterResource = that.patientExaminationDoctorFormNewViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
                if (masterResource) {
                    detailItem.MasterResource = masterResource;
                }
            }
            // tslint:disable-next-line:no-shadowed-variable
            let procedureDoctorObjectID = detailItem['ProcedureDoctor'];
            if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
                let procedureDoctor = that.patientExaminationDoctorFormNewViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                if (procedureDoctor) {
                    detailItem.ProcedureDoctor = procedureDoctor;
                }
            }
        }
        that.patientExaminationDoctorFormNewViewModel._PatientExamination.PatientInteviewForms = that.patientExaminationDoctorFormNewViewModel.GrdPatientInterviewFormGridList;
        for (let detailItem of that.patientExaminationDoctorFormNewViewModel.GrdPatientInterviewFormGridList) {
            // tslint:disable-next-line:no-shadowed-variable
            let masterResourceObjectID = detailItem['MasterResource'];
            if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
                let masterResource = that.patientExaminationDoctorFormNewViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
                if (masterResource) {
                    detailItem.MasterResource = masterResource;
                }
            }
            // tslint:disable-next-line:no-shadowed-variable
            let procedureDoctorObjectID = detailItem['ProcedureDoctor'];
            if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
                let procedureDoctor = that.patientExaminationDoctorFormNewViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                if (procedureDoctor) {
                    detailItem.ProcedureDoctor = procedureDoctor;
                }
            }
        }
        that.patientExaminationDoctorFormNewViewModel._PatientExamination.ExternalConsultations = that.patientExaminationDoctorFormNewViewModel.GrdExternalConsultationGridList;
        for (let detailItem of that.patientExaminationDoctorFormNewViewModel.GrdExternalConsultationGridList) {
            // tslint:disable-next-line:no-shadowed-variable
            let masterResourceObjectID = detailItem['MasterResource'];
            if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
                let masterResource = that.patientExaminationDoctorFormNewViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
                if (masterResource) {
                    detailItem.MasterResource = masterResource;
                }
            }
            // tslint:disable-next-line:no-shadowed-variable
            let procedureDoctorObjectID = detailItem['ProcedureDoctor'];
            if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
                let procedureDoctor = that.patientExaminationDoctorFormNewViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                if (procedureDoctor) {
                    detailItem.ProcedureDoctor = procedureDoctor;
                }
            }
        }
        let medulaSevkDonusVasitasiObjectID = that.patientExaminationDoctorFormNewViewModel._PatientExamination['MedulaSevkDonusVasitasi'];
        if (medulaSevkDonusVasitasiObjectID != null && (typeof medulaSevkDonusVasitasiObjectID === 'string')) {
            let medulaSevkDonusVasitasi = that.patientExaminationDoctorFormNewViewModel.SevkVasitasis.find(o => o.ObjectID.toString() === medulaSevkDonusVasitasiObjectID.toString());
            if (medulaSevkDonusVasitasi) {
                that.patientExaminationDoctorFormNewViewModel._PatientExamination.MedulaSevkDonusVasitasi = medulaSevkDonusVasitasi;
            }
        }
        let dispatchedSpecialityObjectID = that.patientExaminationDoctorFormNewViewModel._PatientExamination['DispatchedSpeciality'];
        if (dispatchedSpecialityObjectID != null && (typeof dispatchedSpecialityObjectID === 'string')) {
            let dispatchedSpeciality = that.patientExaminationDoctorFormNewViewModel.SpecialityDefinitions.find(o => o.ObjectID.toString() === dispatchedSpecialityObjectID.toString());
            if (dispatchedSpeciality) {
                that.patientExaminationDoctorFormNewViewModel._PatientExamination.DispatchedSpeciality = dispatchedSpeciality;
            }
        }
        let mTSHospitalSendingToObjectID = that.patientExaminationDoctorFormNewViewModel._PatientExamination['MTSHospitalSendingTo'];
        if (mTSHospitalSendingToObjectID != null && (typeof mTSHospitalSendingToObjectID === 'string')) {
            let mTSHospitalSendingTo = that.patientExaminationDoctorFormNewViewModel.ResSections.find(o => o.ObjectID.toString() === mTSHospitalSendingToObjectID.toString());
            if (mTSHospitalSendingTo) {
                that.patientExaminationDoctorFormNewViewModel._PatientExamination.MTSHospitalSendingTo = mTSHospitalSendingTo;
            }
        }
        that.patientExaminationDoctorFormNewViewModel._PatientExamination.DoctorsGrid = that.patientExaminationDoctorFormNewViewModel.ttgridSevkEdenDoktorlarGridList;
        for (let detailItem of that.patientExaminationDoctorFormNewViewModel.ttgridSevkEdenDoktorlarGridList) {
            let resUserObjectID = detailItem['ResUser'];
            if (resUserObjectID != null && (typeof resUserObjectID === 'string')) {
                let resUser = that.patientExaminationDoctorFormNewViewModel.ResUsers.find(o => o.ObjectID.toString() === resUserObjectID.toString());
                if (resUser) {
                    detailItem.ResUser = resUser;
                }
            }
        }
        that.patientExaminationDoctorFormNewViewModel._PatientExamination.SingleNursingOrders = that.patientExaminationDoctorFormNewViewModel.GridNursingOrdersGridList;
        for (let detailItem of that.patientExaminationDoctorFormNewViewModel.GridNursingOrdersGridList) {
            let procedureObjectObjectID = detailItem['ProcedureObject'];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
                let procedureObject = that.patientExaminationDoctorFormNewViewModel.VitalSignAndNursingDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
            let singleNursingOrderDetailObjectID = detailItem['SingleNursingOrderDetail'];
            if (singleNursingOrderDetailObjectID != null && (typeof singleNursingOrderDetailObjectID === 'string')) {
                let singleNursingOrderDetail = that.patientExaminationDoctorFormNewViewModel.SingleNursingOrderDetails.find(o => o.ObjectID.toString() === singleNursingOrderDetailObjectID.toString());
                if (singleNursingOrderDetail) {
                    detailItem.SingleNursingOrderDetail = singleNursingOrderDetail;
                }
            }
        }
        that.patientExaminationDoctorFormNewViewModel._PatientExamination.PatientExaminationForensicProcedure = that.patientExaminationDoctorFormNewViewModel.ForensicProceduresGridGridList;
        for (let detailItem of that.patientExaminationDoctorFormNewViewModel.ForensicProceduresGridGridList) {
            let procedureObjectObjectID = detailItem['ProcedureObject'];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
                let procedureObject = that.patientExaminationDoctorFormNewViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
            // tslint:disable-next-line:no-shadowed-variable
            let procedureDoctorObjectID = detailItem['ProcedureDoctor'];
            if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
                let procedureDoctor = that.patientExaminationDoctorFormNewViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                if (procedureDoctor) {
                    detailItem.ProcedureDoctor = procedureDoctor;
                }
            }
            //TODO BB
            /*
            let episodeActionObjectID = detailItem["EpisodeAction"];
            if (episodeActionObjectID != null && (typeof episodeActionObjectID === 'string')) {
                let episodeAction = that.patientExaminationDoctorFormNewViewModel.EpisodeActions.find(o => o.ObjectID.toString() === episodeActionObjectID.toString());
                detailItem.EpisodeAction = episodeAction;
                if (episodeAction != null) {
                    let masterResourceObjectID = episodeAction["MasterResource"];
                    if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
                        let masterResource = that.patientExaminationDoctorFormNewViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
                        episodeAction.MasterResource = masterResource;
                    }
                }
            }
            */
        }

        that.patientExaminationDoctorFormNewViewModel.ExaminationProcessAndEndDate = this.patientExaminationDoctorFormNewViewModel.ExaminationProcessAndEndDate;
        if (that.patientExaminationDoctorFormNewViewModel._PatientExamination.PatientExaminationType === PatientExaminationEnum.HealthCommittee)
            that.isHealthCommittee = true;
        super.loadViewModel();
        this.controlDailyInpatient();
        this.ActivePage = this.tabService.getActiveTab('pedfn');
        if (this.ActivePage === undefined) {
            if (this.patientExaminationDoctorFormNewViewModel.hasSpecialityBasedObject === true) {
                this.ActivePage = 'uzmanlik';
            }
            if (this.hasEmergencySpecialityBasedObject === true) {
                this.ActivePage = 'muayene';
            }

        } else if (this.ActivePage !== undefined) {
            if (this.patientExaminationDoctorFormNewViewModel.hasSpecialityBasedObject === false && this.ActivePage === 'uzmanlik') {
                this.ActivePage = 'muayene';
            }
            if (this.hasEmergencySpecialityBasedObject === false && this.ActivePage === 'muayene') {
                this.ActivePage = 'uzmanlik';
            }
            if (this.ActivePage === 'istem')
                this.openIstemTab = true;
            if (this.ActivePage === 'hastaGecmisi') {
                this.openHastaGecmisiTab = true;
                this.setPatientHistoryShown(this.patientExaminationDoctorFormNewViewModel._PatientExamination.ObjectID);
            }
        }
        if (this.ActivePage === 'uzmanlik' || !this.hasEmergencySpecialityBasedObject)
            this.openUzmanlikTab = true;
        this.RecentActiveTab = this.ActivePage;
        this.patientExaminationDoctorFormNewViewModel.ENabizViewModels = [];
        this.createDynamicComposComponentVariables();
        this.HighRiskPregnancyAlgorithm();

    }

    async HighRiskPregnancyAlgorithm() {
        if (this.patientExaminationDoctorFormNewViewModel.IsWomanSpecialityExam != true && this.patientExaminationDoctorFormNewViewModel.HighRiskPregnancyMessage != null && this.patientExaminationDoctorFormNewViewModel.HighRiskPregnancyMessage != "") {
            let result: string = await ShowBox.Show(1, '&Evet,&Hayır', 'OK,CANCEL', i18n("M23735", "Uyarı"), "", "Hastada Yüksek Riskli Gebelik bulunmaktadır. Sağlık verilerine ulaşmak ister misiniz?\nDetay:" + this.patientExaminationDoctorFormNewViewModel.HighRiskPregnancyMessage, 1);

            if (result === "OK")
                this.showPatientENabizInfoByParameter(this._PatientExamination.ObjectID, this._PatientExamination.Episode.Patient.ObjectID)
        }

    }

    private showPatientENabizInfoByParameter(episodeActionId: Guid, patientId: Guid) {
        let that = this;
        let apiUrl: string = '/api/PatientExaminationService/ShowPatientENabizInfo?episodeActionObjectID=' + episodeActionId + '&patientObjectID=' + patientId;


        that.httpService.get<ENabizButtonResponseModel>(apiUrl)
            .then(response => {
                let result: ENabizButtonResponseModel = response as ENabizButtonResponseModel;
                if (result.isResponseSuccess == true) {
                    let nabizURL = "http://xxxxxx.com/DoktorErisim/home?Token=" + result.responseLink;
                    let win = window.open(nabizURL, '_blank');
                    win.focus();
                } else {
                    TTVisual.InfoBox.Alert(result.responseMessage);
                }
            })
            .catch(error => {
                this.messageService.showError(error);
            });
    }

    async ngAfterViewInit() {

        let that = this;
        //Parametre değeri TRUE ise Reçete tabının gizlenmesi sağlanıyor.
        //if (that._PatientExamination.Episode.PatientStatus === PatientStatusEnum.Outpatient) {
        let enableColorPrescriptionWithJSON: string = (await SystemParameterService.GetParameterValue('ENABLECOLORPRESCRIPTIONWITHJSON', 'FALSE'));
        if (enableColorPrescriptionWithJSON === 'TRUE') {
            this.enablePrescriptionTab = false;
        }
        else {
            this.enablePrescriptionTab = true;
        }
        //}
        let influenzaCheckValue: string = (await SystemParameterService.GetParameterValue('INFLUENZASERVICEACTIVE', 'FALSE'));
        if (influenzaCheckValue === 'TRUE') {
            this.enableInfluenzaHelpServiceButton = true;
        }

        this.openSubscribers();
    }

    public openSubscribers() {
        this.refreshReportGridSubscription = this.httpService.medicalStuffReportSharedService.medicalStuffReportUpdateObservable.subscribe(value => {
            this.reloadReportList();
        });
    }

    async ngOnInit() {
        this.ActiveAcc = this.tabService.getActiveTab('pedfnacc');
        this.RecentAcc = this.ActiveAcc;
        await this.load(PatientExaminationDoctorFormNewViewModel);
    }
    public openIstemTab: boolean = false;
    openIstem(show: boolean) {
        this.openIstemTab = true;

        if (show != null)
            this.showMostUsedProceduresInfo = show;
        else
            this.showMostUsedProceduresInfo = false;
    }

    public openHastaGecmisiTab: boolean = false;
    public openHastaGecmisi() {
        this.openHastaGecmisiTab = true;
        this.showMostUsedProceduresInfo = false;

        this.setPatientHistoryShown(this.patientExaminationDoctorFormNewViewModel._PatientExamination.ObjectID);
    }

    public openUzmanlikTab: boolean = false;
    public openUzmanlik() {
        this.openUzmanlikTab = true;
        if (!this.hasEmergencySpecialityBasedObject)
            this.showMostUsedProceduresInfo = true;
        else
            this.showMostUsedProceduresInfo = false;
    }

    public onShowMostUsedProceduresInfo() {
        this.showMostUsedProceduresInfo = true;
    }


    public setPatientHistoryShown(episodeActionId: Guid) {
        let that = this;
        that.httpService.get<any>("api/PatientHistoryService/SetPatientHistoryShown?episodeActionId=" + episodeActionId)
            .then(response => {
            })
            .catch(error => {
            });
    }

    medicalInfoFoodAllergySelected(data: any) {
        this._ViewModel._selectedMedicalInfoFoodAllergyValue = data;
        let that = this;
        let peMedicalInfoFoodAllergy: MedicalInfoFoodAllergies = new MedicalInfoFoodAllergies();
        peMedicalInfoFoodAllergy.DietMaterial = data;
        that.patientExaminationDoctorFormNewViewModel.MedicalInfoFoodAllergiesMedicalInfoFoodAllergiesGridList.push(peMedicalInfoFoodAllergy);
    }

    medicalInfoDrugAllergySelected(data: any) {
        this._ViewModel._selectedMedicalInfoDrugAllergyValue = data;
        let that = this;
        let peMedicalInfoDrugAllergy: MedicalInfoDrugAllergies = new MedicalInfoDrugAllergies();
        peMedicalInfoDrugAllergy.ActiveIngredient = data;
        // that._PatientExamination.Episode.Patient.MedicalInformation.MedicalInfoAllergies.MedicalInfoDrugAllergies.push(peMedicalInfoDrugAllergy);
        that.patientExaminationDoctorFormNewViewModel.MedicalInfoDrugAllergiesMedicalInfoDrugAllergiesGridList.push(peMedicalInfoDrugAllergy);
    }
    selectHeight(data: any) {
        this.patientExaminationDoctorFormNewViewModel.Height = data;
        this.patientExaminationDoctorFormNewViewModel.anamnesisFormViewModel.vitalSingsViewModel.Height_Value = data;
    }
    selectWeight(data: any) {
        this.patientExaminationDoctorFormNewViewModel.Weight = data;
        this.patientExaminationDoctorFormNewViewModel.anamnesisFormViewModel.vitalSingsViewModel.Weight_Value = data;
    }
    getIsCozger(data: any) {
        this.healthCommitteeIsCozger = data;
    }
    public oncmbTriajCodeChanged(event): void {
        if (event != null) {

            if (event === 1) {
                this.cmbTriajCode.BackColor = '#F08080';
                this.cmbTriajCode.ForeColor = '#17202A';
            } else if (event === 2) {
                this.cmbTriajCode.BackColor = '#F9E79F';
                this.cmbTriajCode.ForeColor = '#17202A';
            } else if (event === 3) {
                this.cmbTriajCode.BackColor = '#7DCEA0';
                this.cmbTriajCode.ForeColor = '#17202A';
            } else if (event === 5) {
                this.cmbTriajCode.BackColor = '#566573';
                this.cmbTriajCode.ForeColor = '#FFFFFF';
            }


            /*if (this._PatientExamination != null &&
                this._PatientExamination.EmergencyIntervention != null && this._PatientExamination.EmergencyIntervention.Triage != event) {
                this._PatientExamination.EmergencyIntervention.TriajCode = event;
            }*/

        }
    }

    public onHospitalSendingToChanged(event): void {
        if (event != null) {
            if (this._PatientExamination != null && this._PatientExamination.MTSHospitalSendingTo !== event) {
                this._PatientExamination.MTSHospitalSendingTo = event;
            }
        }
    }

    public onIsApproveMHRSGreenListChanged(event): void {
        if (event != null) {
            if (this._PatientExamination != null && this._PatientExamination.IsApproveMHRSGreenList !== event) {
                this._PatientExamination.IsApproveMHRSGreenList = event;
            }
        }
    }

    public onIsObservationTakenChanged(event): void {
        if (event != null) {
            if (this._PatientExamination != null && this._PatientExamination.IsObservationTaken !== event) {
                this._PatientExamination.IsObservationTaken = event;
            }
        }
    }

    public onIsReportMHRSGreenListChanged(event): void {
        if (event != null) {
            if (this._PatientExamination != null && this._PatientExamination.IsReportMHRSGreenList !== event) {
                this._PatientExamination.IsReportMHRSGreenList = event;
            }
        }
    }

    public async onlistBoxTreatmentResultChanged(event): Promise<void> {
        if (event != null) {
            if (this._PatientExamination != null && this._PatientExamination.TreatmentResult !== event) {
                this._PatientExamination.TreatmentResult = event;
                if (!this.patientExaminationDoctorFormNewViewModel.HasMorgue) {
                    if (this._PatientExamination.TreatmentResult.KODU == "6")
                        this.getMorgueEpisodeAction();
                    else
                        this.patientExaminationDoctorFormNewViewModel._MorgueViewModel = null;

                }
                else {
                    if (this._PatientExamination.TreatmentResult.KODU != "6") { //Daha önce morg işlemi başlatılmış bir hastanın taburcu tipi değiştirildiyse
                        let morgueCancelMsg: string = i18n("M15512", "Hastaya başlatılmış morg işlemi bulunmaktadır.Taburcu tipini değiştirirseniz morg işlemi iptal edilecektir. Devam etmek istiyor musunuz?");

                        let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), '', morgueCancelMsg);
                        if (result === 'H')
                            this.patientExaminationDoctorFormNewViewModel._PatientExamination.TreatmentResult = this.patientExaminationDoctorFormNewViewModel.DeathDefinition;
                    }
                }


            }


        }
        else
            this._PatientExamination.TreatmentResult = event;

    }

    getMorgueEpisodeAction() {

        let episodeID: Guid = this._PatientExamination.Episode.ObjectID;
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

            let selectedActionID: Guid = <any>that.patientExaminationDoctorFormNewViewModel._PatientExamination.ObjectID;
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
                    this.patientExaminationDoctorFormNewViewModel._PatientExamination.TreatmentResult = null;
                else {
                    this.patientExaminationDoctorFormNewViewModel._MorgueViewModel = morgueVM;
                }
                //formu doldurmazsa taburcu şeklini resetle
            }).catch(err => {
                reject(err);
            });
        });
    }

    public onMedulaOzelDurumChanged(event): void {
        if (event != null) {
            if (this._PatientExamination != null && this._PatientExamination.OzelDurum !== event) {
                this._PatientExamination.OzelDurum = event;
            }
        }
    }

    public onmedulaRefakatciDurumuChanged(event): void {
        if (event != null) {
            if (this._PatientExamination != null && this._PatientExamination.MedulaRefakatciDurumu !== event) {
                this._PatientExamination.MedulaRefakatciDurumu = event;
            }
        }
    }

    public onStartPhysiotherapyRequestChanged(event): void {
        if (event != null) {
            if (this._PatientExamination != null && this.StartPhysiotherapyRequest.Value !== event) {
                this.StartPhysiotherapyRequest.Value = event;
            }
            if (this._PatientExamination != null && this.patientExaminationDoctorFormNewViewModel.StartPhysiotherapyRequest !== event) {
                this.patientExaminationDoctorFormNewViewModel.StartPhysiotherapyRequest = event;
            }
        }
    }

    public onMutatDisiGerekcesiChanged(event): void {
        if (event != null) {
            if (this._PatientExamination != null && this._PatientExamination.MutatDisiGerekcesi !== event) {
                this._PatientExamination.MutatDisiGerekcesi = event;
            }
        }
    }

    public async onProcedureDoctorChanged(event) {
        // tslint:disable-next-line:no-debugger
        let user: TTUser = TTUser.CurrentUser;
        if (!user.IsSuperUser) {
            if (this.patientExaminationDoctorFormNewViewModel.hasSavedDiagnosis) {
                throw new TTException('Tanısı girilmiş işlemin sorumlu doktorunu sadece super user türündeki kullanıcılar değiştirebilir.');
            }
        }

        if (this._PatientExamination != null && this._PatientExamination.ProcedureDoctor !== event) {

            if (this._PatientExamination.RequestDate != null && event != null) {
                let a = await CommonService.PersonelIzinKontrol(event.ObjectID, this._PatientExamination.RequestDate);
                if (a) {
                    this.messageService.showInfo(event.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._PatientExamination.ProcedureDoctor = null;
                    }, 500);

                }
                else {
                    this._PatientExamination.ProcedureDoctor = event;
                    TTUser.CurrentUser.ResponsibleSpecialist = <ResUser>event;
                    this.ProcedureDoctor_SelectedObjectChanged();
                }
            }

        }
    }

    public onProcedureSpecialityChanged(event): void {
        if (event != null) {
            if (this._PatientExamination != null && this._PatientExamination.ProcedureSpeciality !== event) {
                this._PatientExamination.ProcedureSpeciality = event;
            }
        }
    }

    public onRaporBaslangicTarihiChanged(event): void {
        if (event != null) {
            if (this._PatientExamination != null && this._PatientExamination.MutatDisiAracBaslangicTarihi !== event) {
                this._PatientExamination.MutatDisiAracBaslangicTarihi = event;
            }
        }
    }

    public onRaporBitisTarihiChanged(event): void {
        if (event != null) {
            if (this._PatientExamination != null && this._PatientExamination.MutatDisiAracBitisTarihi !== event) {
                this._PatientExamination.MutatDisiAracBitisTarihi = event;
            }
        }
    }

    public onRaporTarihiChanged(event): void {
        if (event != null) {
            if (this._PatientExamination != null && this._PatientExamination.MutatDisiAracRaporTarihi !== event) {
                this._PatientExamination.MutatDisiAracRaporTarihi = event;
            }
        }
    }

    public onResponsibleDoctorChanged(event): void {
        if (event != null) {
            if (this._PatientExamination != null && this._PatientExamination.ResponsibleDoctor !== event) {
                this._PatientExamination.ResponsibleDoctor = event;
            }
        }
        this.ResponsibleDoctor_SelectedObjectChanged();
    }

    public onrtfComplaintChanged(event): void {
        if (event != null) {
            if (this._PatientExamination != null && this._PatientExamination.Complaint !== event) {
                this._PatientExamination.Complaint = event;
            }
        }
    }

    public onrtfHistoryChanged(event): void {
        if (event != null) {
            if (this._PatientExamination != null && this._PatientExamination.PatientHistory !== event) {
                this._PatientExamination.PatientHistory = event;
            }
        }
    }

    public onrtfPatientStoryChanged(event): void {
        if (event != null) {
            if (this._PatientExamination != null && this._PatientExamination.PatientStory !== event) {
                this._PatientExamination.PatientStory = event;
            }
        }
    }

    public onrtfPhysicalExaminationChanged(event): void {
        if (event != null) {
            if (this._PatientExamination != null && this._PatientExamination.PhysicalExamination !== event) {
                this._PatientExamination.PhysicalExamination = event;
            }
        }
    }

    public onTTListBoxMedulaSevkVasitasiChanged(event): void {
        if (event != null) {
            if (this._PatientExamination != null && this._PatientExamination.MedulaSevkDonusVasitasi !== event) {
                this._PatientExamination.MedulaSevkDonusVasitasi = event;
            }
        }
    }

    public onMTSConclusionChanged(event): void {
        if (event != null) {
            if (this._PatientExamination != null && this._PatientExamination.MTSConclusion !== event) {
                this._PatientExamination.MTSConclusion = event;
            }
        }
    }

    public ontxtboxRefakatciGerekcesiChanged(event): void {
        if (event != null) {
            if (this._PatientExamination != null && this._PatientExamination.MedulaRefakatciGerekcesi !== event) {
                this._PatientExamination.MedulaRefakatciGerekcesi = event;
            }
        }
    }

    private showDrugOrderIntroduction(data: DrugOrderIntroduction): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DrugOrderIntroductionNewForm';
            componentInfo.ModuleName = 'IlacDirektifiGirisModule';
            componentInfo.ModulePath = '/Modules/Saglik_Lojistik/Eczane_Modulleri/Ilac_Direktifi_Giris_Modulu/IlacDirektifiGirisModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, new ActiveIDsModel(this._PatientExamination.ObjectID, null, null));

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
        let subEpisodeID: Guid = <any>this._PatientExamination['SubEpisode'];
        let diagnosisControlResult = await PatientExaminationService.CheckPatientSubEpisodeDiagnosisExistence(subEpisodeID); //.SendMKYSForInputDocumentTS(this._GrantMaterial);
        if (diagnosisControlResult == false) {
            ServiceLocator.MessageService.showError("Vakaya, Ön Tanı  girilip kaydedilmeden işleme devam edilemez!");
            return;
        }
        let subEps: SubEpisode = await this.objectContextService.getObject<SubEpisode>(subEpisodeID, SubEpisode.ObjectDefID);
        this.objectContextService.getNewObject<DrugOrderIntroduction>(DrugOrderIntroduction.ObjectDefID, DrugOrderIntroduction).then(result => {
            let drugOrderIntroduction: DrugOrderIntroduction = result;
            drugOrderIntroduction.MasterResource = this._PatientExamination.MasterResource;
            drugOrderIntroduction.SecondaryMasterResource = this._PatientExamination.SecondaryMasterResource;
            drugOrderIntroduction.Episode = this._PatientExamination.Episode;
            drugOrderIntroduction.SubEpisode = subEps;
            drugOrderIntroduction.PatientOwnDrug = false;
            drugOrderIntroduction.CurrentStateDefID = DrugOrderIntroduction.DrugOrderIntroductionStates.New;
            drugOrderIntroduction.DrugOrderIntroductionDetails = new Array<DrugOrderIntroductionDet>();

            // tslint:disable-next-line:no-shadowed-variable
            this.showDrugOrderIntroduction(drugOrderIntroduction).then(result => {
                DrugOrderIntroductionService.GetOldDrugOrderIntroductions(this._PatientExamination.Episode).then(drugOrderIntDets => {
                    this.PrescriptionList = drugOrderIntDets;
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

    async onSelectedReportOpen(data: any) {
        if (this.CheckIsDiagnosisExistsForReports(this.patientExaminationDoctorFormNewViewModel.GridEpisodeDiagnosisGridList) == false) {
            this.messageService.showError("Hasta üzerinde kayıtlı bir tanı olmadan Rapor yazamazsınız.!");
            return;
        }
        this.ReportParamActiveIDsModel = new ActiveIDsModel(this._PatientExamination.ObjectID, this._PatientExamination.Episode.ObjectID, this._PatientExamination.Episode.Patient.ObjectID);
        if (data.code === ReportTypeEnum.DrugReport) {
            if (!(await EpisodeActionService.CheckInvoicedCompletely(this._PatientExamination.ObjectID)))
                this.onParticipatientReportOpen(null);
            else
                ServiceLocator.MessageService.showError("Faturası Kesilmiş Hastalara İlaç Raporu Yazamazsınız");
        }
        else if (data.code === ReportTypeEnum.TreatmentReport) {

            if (this.patientExaminationDoctorFormNewViewModel._PatientExamination.PatientExaminationType === PatientExaminationEnum.Control) {
                if (this.patientExaminationDoctorFormNewViewModel._PatientExamination.CurrentStateDefID.toString() === PatientExamination.PatientExaminationStates.ExaminationCompleted.id) {
                    //if (await EpisodeActionService.CheckProvision()) {
                    this.onMedulaTreatmentReportOpen(null);
                    /* } else {
                         TTVisual.InfoBox.Alert("Hastanın Takip Numarası Yoktur. Medula Tedavi Raporu Yazılamaz");
                     }*/
                }
                else if (this.patientExaminationDoctorFormNewViewModel._PatientExamination.CurrentStateDefID.toString() === PatientExamination.PatientExaminationStates.Completed.id) {
                    //if (await EpisodeActionService.CheckProvision()) {
                    this.onMedulaTreatmentReportOpen(null);
                    /*} else {
                        TTVisual.InfoBox.Alert("Hastanın Takip Numarası Yoktur. Medula Tedavi Raporu Yazılamaz");
                    }*/
                }
                else {
                    ServiceLocator.MessageService.showError(i18n("M22718", "Tamamlanmamış hasta muayenelerinde Tedavi Raporu yazılamaz."));
                }
            }
            else {
                // if (await EpisodeActionService.CheckProvision()) {
                this.onMedulaTreatmentReportOpen(null);
                /*} else {
                    TTVisual.InfoBox.Alert("Hastanın Takip Numarası Yoktur. Medula Tedavi Raporu Yazılamaz");
                }*/
            }
        }
        else if (data.code === ReportTypeEnum.OtherReport) {
            this.onStatusNotificationReportOpen(null);
        }
        else if (data.code === ReportTypeEnum.MedicalStuffReport) {
            this.onMedicalStuffReportOpen(null);
        }
    }




    protected redirectProperties(): void {
        redirectProperty(this.IsApproveMHRSGreenList, 'Value', this.__ttObject, 'IsApproveMHRSGreenList');
        redirectProperty(this.rtfComplaint, 'Rtf', this.__ttObject, 'Complaint');
        redirectProperty(this.rtfPatientStory, 'Rtf', this.__ttObject, 'PatientStory');
        redirectProperty(this.rtfPhysicalExamination, 'Rtf', this.__ttObject, 'PhysicalExamination');
        redirectProperty(this.rtfHistory, 'Rtf', this.__ttObject, 'PatientHistory');
        redirectProperty(this.rtfHistory, 'Rtf', this.__ttObject, 'PatientHistory');
        redirectProperty(this.MTSConclusion, 'Rtf', this.__ttObject, 'MTSConclusion');
        redirectProperty(this.medulaRefakatciDurumu, 'Value', this.__ttObject, 'MedulaRefakatciDurumu');
        redirectProperty(this.MutatDisiGerekcesi, 'Text', this.__ttObject, 'MutatDisiGerekcesi');
    }

    public initFormControls(): void {

        this.StartPhysiotherapyRequest = new TTVisual.TTCheckBox();
        this.StartPhysiotherapyRequest.Value = false;
        this.StartPhysiotherapyRequest.Text = i18n("M14073", "F.T.R. İstek");
        this.StartPhysiotherapyRequest.Title = i18n("M14073", "F.T.R. İstek");
        this.StartPhysiotherapyRequest.Name = 'StartPhysiotherapyRequest';
        this.StartPhysiotherapyRequest.ReadOnly = false;
        this.StartPhysiotherapyRequest.TabIndex = 184;


        this.IsApproveMHRSGreenList = new TTVisual.TTCheckBox();
        this.IsApproveMHRSGreenList.Value = false;
        this.IsApproveMHRSGreenList.Text = 'MHRS Yeşil Liste Onayla(Kronik Hasta)';
        this.IsApproveMHRSGreenList.Name = 'IsApproveMHRSGreenList';
        this.IsApproveMHRSGreenList.TabIndex = 184;

        this.listBoxTreatmentResult = new TTVisual.TTObjectListBox();
        this.listBoxTreatmentResult.ListDefName = 'SKRSCikisSekliList';
        this.listBoxTreatmentResult.Name = 'listBoxTreatmentResult';
        this.listBoxTreatmentResult.TabIndex = 52;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.Required = true;
        this.ProcedureDoctor.Enabled = true;
        this.ProcedureDoctor.ListDefName = 'SpecialistDoctorListDefinition';
        this.ProcedureDoctor.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ProcedureDoctor.Name = 'ProcedureDoctor';
        this.ProcedureDoctor.TabIndex = 10;

        this.MTSConclusion = new TTVisual.TTRichTextBoxControl();
        this.MTSConclusion.DisplayText = i18n("M22997", "Tedavi Kararı");
        this.MTSConclusion.TemplateGroupName = i18n("M19209", "Muayene Özgeçmiş");
        this.MTSConclusion.Iconized = true;
        this.MTSConclusion.BackColor = '#FFFFFF';
        this.MTSConclusion.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.MTSConclusion.Name = 'MTSConclusion';
        this.MTSConclusion.TabIndex = 0;

        this.rtfComplaint = new TTVisual.TTRichTextBoxControl();
        this.rtfComplaint.DisplayText = i18n("M22483", "Şikayet");
        this.rtfComplaint.TemplateGroupName = i18n("M19221", "Muayene Şikayet");
        this.rtfComplaint.Iconized = true;
        this.rtfComplaint.BackColor = '#FFFFFF';
        this.rtfComplaint.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.rtfComplaint.Name = 'rtfComplaint';
        this.rtfComplaint.TabIndex = 0;

        this.rtfHistory = new TTVisual.TTRichTextBoxControl();
        this.rtfHistory.DisplayText = i18n("M20117", "Özgeçmiş");
        this.rtfHistory.TemplateGroupName = i18n("M19209", "Muayene Özgeçmiş");
        this.rtfHistory.Iconized = true;
        this.rtfHistory.BackColor = '#FFFFFF';
        this.rtfHistory.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.rtfHistory.Name = 'rtfHistory';
        this.rtfHistory.TabIndex = 1;

        this.rtfPatientStory = new TTVisual.TTRichTextBoxControl();
        this.rtfPatientStory.DisplayText = i18n("M15784", "Hikayesi");
        this.rtfPatientStory.TemplateGroupName = i18n("M15784", "Hikayesi");
        this.rtfPatientStory.Iconized = true;
        this.rtfPatientStory.BackColor = '#FFFFFF';
        this.rtfPatientStory.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.rtfPatientStory.Name = 'rtfPatientStory';
        this.rtfPatientStory.TabIndex = 1;

        this.btnPatientExaminationSave = new TTVisual.TTButton();
        this.btnPatientExaminationSave.Text = i18n("M17386", "Kaydet");
        this.btnPatientExaminationSave.Name = 'btnPatientExaminationSave';
        this.btnPatientExaminationSave.TabIndex = 4;

        this.btnPrint = new TTVisual.TTButton();
        this.btnPrint.Text = i18n("M24476", "Yazdır");
        this.btnPrint.Name = 'btnPrint';
        this.btnPrint.TabIndex = 4;

        this.MedulaSevkTab = new TTVisual.TTTabPage();
        this.MedulaSevkTab.DisplayIndex = 4;
        this.MedulaSevkTab.TabIndex = 4;
        this.MedulaSevkTab.Text = i18n("M18743", "Medula E-Sevk");
        this.MedulaSevkTab.Name = 'MedulaSevkTab';

        this.MutatDisiGerekcesi = new TTVisual.TTTextBox();
        this.MutatDisiGerekcesi.Multiline = true;
        this.MutatDisiGerekcesi.Name = 'MutatDisiGerekcesi';
        this.MutatDisiGerekcesi.TabIndex = 6;

        this.medulaRefakatciDurumu = new TTVisual.TTCheckBox();
        this.medulaRefakatciDurumu.Value = false;
        this.medulaRefakatciDurumu.Text = i18n("M20996", "Refakatçi Durumu");
        this.medulaRefakatciDurumu.Name = 'medulaRefakatciDurumu';
        this.medulaRefakatciDurumu.TabIndex = 46;

        this.rtfPhysicalExamination = new TTVisual.TTRichTextBoxControl();
        this.rtfPhysicalExamination.DisplayText = i18n("M19173", "Muayene Bulguları");
        this.rtfPhysicalExamination.TemplateGroupName = i18n("M19186", "Muayene Fizik");
        this.rtfPhysicalExamination.Iconized = true;
        this.rtfPhysicalExamination.BackColor = '#FFFFFF';
        this.rtfPhysicalExamination.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.rtfPhysicalExamination.Name = 'rtfPhysicalExamination';
        this.rtfPhysicalExamination.TabIndex = 2;

        this.listViewWorkList = new TTVisual.TTListView();
        this.listViewWorkList.Name = 'listViewWorkList';
        this.listViewWorkList.TabIndex = 2;

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

        this.IsExaminationCompleted = new TTVisual.TTCheckBox();
        this.IsExaminationCompleted.Value = false;
        this.IsExaminationCompleted.Title = i18n("M19263", "Muayeneyi Sonlandır");
        this.IsExaminationCompleted.Name = 'IsExaminationCompleted';
        this.IsExaminationCompleted.TabIndex = 0;

        this.cmbReportType = new TTVisual.TTEnumComboBox();
        this.cmbReportType.DataTypeName = 'ReportTypeEnum';
        this.cmbReportType.Name = 'cmbReportType';
        this.cmbReportType.TabIndex = 3;
        this.cmbReportType.ShowClearButton = true;

        this.txtReportName = new TTTextBoxColumn();
        this.txtReportName.DataMember = "ReportName";
        this.txtReportName.Name = "ReportName";
        this.txtReportName.ToolTipText = "ReportName";
        this.txtReportName.Width = "50%";
        this.txtReportName.DisplayIndex = 1;
        this.txtReportName.HeaderText = "Rapor";

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


        this.txtStartDate = new TTTextBoxColumn();
        this.txtStartDate.DataMember = "StartDate";
        this.txtStartDate.Name = "StartDate";
        this.txtStartDate.ToolTipText = "StartDate";
        this.txtStartDate.Width = "20%";
        this.txtStartDate.DisplayIndex = 0;
        this.txtStartDate.HeaderText = i18n("M11637", "Başlangıç Tarihi");

        this.txtEndDate = new TTTextBoxColumn();
        this.txtEndDate.DataMember = "EndDate";
        this.txtEndDate.Name = "EndDate";
        this.txtEndDate.ToolTipText = "EndDate";
        this.txtEndDate.Width = "20%";
        this.txtEndDate.DisplayIndex = 0;
        this.txtEndDate.HeaderText = i18n("M11939", "Bitiş Tarihi");

        this.txtProcedureByUser = new TTTextBoxColumn();
        this.txtProcedureByUser.DataMember = "ProcedureByUser";
        this.txtProcedureByUser.Name = "ProcedureByUser";
        this.txtProcedureByUser.ToolTipText = "Rapor Oluşturan";
        this.txtProcedureByUser.Width = "20%";
        this.txtProcedureByUser.DisplayIndex = 0;
        this.txtProcedureByUser.HeaderText = i18n("M11939", "Rapor Oluşturan");
        this.txtProcedureByUser.Enabled = false;
        this.txtProcedureByUser.ReadOnly = true;

        this.btnEdit = new TTButtonColumn();
        this.btnEdit.Name = "btnEdit";
        this.btnEdit.Width = "10%";
        this.btnEdit.DisplayIndex = 0;
        this.btnEdit.HeaderText = i18n("M13405", "Düzenle");


        this.PrescriptionGridColumns = [
            {
                caption: ' ',
                dataField: 'ObjectId',
                cellTemplate: 'buttonCellTemplate',
                width: 50
            },
            {
                'caption': i18n("M16886", "İşlem Tarihi"),
                dataField: 'ActionDate',
                allowSorting: true,
                dataType: 'date'
            },
            {
                'caption': i18n("M10469", "Açıklama"),
                dataField: 'Description',
                allowSorting: true
            },
            {
                'caption': i18n("M13814", "E-Reçete Durumu"),
                dataField: 'EReceteStatus',
                allowSorting: true
            }
        ];
        this.GridPatientReportsColumns = [this.txtReportName, this.txtReportRequestReason, this.txtReportAdmissionDate, this.txtReportMasterResource, this.txtStartDate, this.txtEndDate, this.txtProcedureByUser, this.btnEdit];

        /**GELİŞ SEBEBİ DEĞİŞTİRME BEGİN */

        this.AdmissionType = new TTVisual.TTListDefComboBox();
        this.AdmissionType.ListDefName = "ProvizyonTipiListDefinition";
        this.AdmissionType.Required = true;
        this.AdmissionType.Name = "AdmissionType";
        this.AdmissionType.TabIndex = 0;

        this.MedulaVakaTarihi = new TTVisual.TTDateTimePicker();
        this.MedulaVakaTarihi.BackColor = "#F0F0F0";
        this.MedulaVakaTarihi.Format = DateTimePickerFormat.Short;
        this.MedulaVakaTarihi.ReadOnly = false;
        this.MedulaVakaTarihi.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MedulaVakaTarihi.Name = "MedulaVakaTarihi";

        this.SKRSAdliVaka = new TTVisual.TTListDefComboBox();
        this.SKRSAdliVaka.ListDefName = "SKRSAdliVakaGelisSekliList";
        this.SKRSAdliVaka.Name = "SKRSAdliVaka";
        this.SKRSAdliVaka.TabIndex = 1;

        this.MedulaIstisnaiHalComboBox = new TTVisual.TTListDefComboBox();
        this.MedulaIstisnaiHalComboBox.ListDefName = "IstisnaiHalListDef";
        this.MedulaIstisnaiHalComboBox.Name = "ttlistdefcombobox1";
        this.MedulaIstisnaiHalComboBox.TabIndex = 2;

        this.cbx112 = new TTVisual.TTCheckBox();
        this.cbx112.Value = false;
        this.cbx112.Text = i18n("M10132", "112 Sağlık Hizmetleri");
        this.cbx112.Name = "cbx112";
        this.cbx112.TabIndex = 2;

        this.Emergency112RefNoTextbox = new TTVisual.TTTextBox();
        this.Emergency112RefNoTextbox.Name = "txt112ProtocolNo";
        this.Emergency112RefNoTextbox.TabIndex = 3;
        this.Emergency112RefNoTextbox.ReadOnly = true;

        this.plakaNo = new TTVisual.TTTextBox();
        this.plakaNo.Name = "plakaNo";
        this.plakaNo.TabIndex = 3;

        /**GELİŞ SEBEBİ DEĞİŞTİRME END */
    }

    async PrescriptionGrid_CellContentClicked(data: any) {

    }

    select(value: any) {

        let objectID: Guid = value.data.ObjectId;
        this.objectContextService.getObject<DrugOrderIntroduction>(objectID, DrugOrderIntroduction.ObjectDefID).then(result => {
            let drugOrderIntroduction: DrugOrderIntroduction = result;
            // tslint:disable-next-line:no-shadowed-variable
            this.showDrugOrderIntroduction(drugOrderIntroduction).then(result => {
                DrugOrderIntroductionService.GetOldDrugOrderIntroductions(this._PatientExamination.Episode).then(drugOrderIntDets => {
                    this.PrescriptionList = drugOrderIntDets;
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

    async GridPatientReports_CellContentClicked(data: any) {
        let that = this;
        this.ReportParamActiveIDsModel = new ActiveIDsModel(this._PatientExamination.ObjectID, this._PatientExamination.Episode.ObjectID, this._PatientExamination.Episode.Patient.ObjectID);

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

    private showMedulaTreatmentReport(data: MedulaTreatmentReport) {
        this.showMedulaTedaviRaporlariForm = true;

        this.medulaTedaviRaporlariObject = data as MedulaTreatmentReport;
    }

    async onParticipatientReportOpen(episodeAction: any) {
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
            componentInfo.InputParam = new DynamicComponentInputParam(data, new ActiveIDsModel(this._PatientExamination.ObjectID, this._PatientExamination.Episode.ObjectID, this._PatientExamination.Episode.Patient.ObjectID));
            componentInfo.ParentInstance = this;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M23409", "Tıbbi Malzeme Raporu");
            /*modalInfo.Width = 1300;
            modalInfo.Height = 900;*/
            modalInfo.fullScreen = true;
            modalInfo.DonotClosOnActionExecute = true;

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

    async reloadReportList() {
        let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.patientExaminationDoctorFormNewViewModel._PatientExamination.Episode.Patient.ObjectID + '&subepisodeObjectID=' + this.patientExaminationDoctorFormNewViewModel._PatientExamination.SubEpisode + '&includedCancelledReports=false&currentActionReports=' + this.currentActionReports;
        let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);
        this.patientExaminationDoctorFormNewViewModel.PatientReportInfoList = res;
    }

    async onStatusNotificationReportForm(event: any) {
        this.showStatusNotificationReportForm = false;
        //refreshReportTab
        this.reloadReportList();

    }
    async onMedulaTedaviRaporlariForm(event: any) {
        this.showMedulaTedaviRaporlariForm = false;
        //refreshReportTab
        this.reloadReportList();

    }
    async onParticipationFreeDrugReportNewForm(event: any) {
        this.showParticipationFreeDrugReportNewForm = false;
        //refreshReportTab
        this.reloadReportList();
        this.requestedProceduresFormInstance.reloadProceduresList();
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

    onMedulaTreatmentReportOpen(episodeAction: any) {
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

    async OnStatusNotificationReportFormClosing(e) {
        let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.patientExaminationDoctorFormNewViewModel._PatientExamination.Episode.Patient.ObjectID + '&subepisodeObjectID=' + this.patientExaminationDoctorFormNewViewModel._PatientExamination.SubEpisode + '&includedCancelledReports=false&currentActionReports=' + this.currentActionReports;
        let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);
        this.patientExaminationDoctorFormNewViewModel.PatientReportInfoList = res;
    }

    async OnMedulaTedaviRaporlariFormClosing(e) {
        if (e == true)
            this.showMedulaTedaviRaporlariForm = false;

        //refreshReportTab
        let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.patientExaminationDoctorFormNewViewModel._PatientExamination.Episode.Patient.ObjectID + '&subepisodeObjectID=' + this.patientExaminationDoctorFormNewViewModel._PatientExamination.SubEpisode + '&includedCancelledReports=false&currentActionReports=true';
        let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);
        this.patientExaminationDoctorFormNewViewModel.PatientReportInfoList = res;
    }
    async OnParticipationFreeDrugReportNewFormClosing(e) {
        if (e == true)
            this.showParticipationFreeDrugReportNewForm = false;


        //refreshReportTab
        let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.patientExaminationDoctorFormNewViewModel._PatientExamination.Episode.Patient.ObjectID + '&subepisodeObjectID=' + this.patientExaminationDoctorFormNewViewModel._PatientExamination.SubEpisode + '&includedCancelledReports=false&currentActionReports=true';
        let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);
        this.patientExaminationDoctorFormNewViewModel.PatientReportInfoList = res;



    }

    private showStatusNotificationReport(data: StatusNotificationReport) {
        this.showStatusNotificationReportForm = true;

        this.statusNotificationReportObject = data as StatusNotificationReport;


    }

    private showWatch(): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'EvdeSaglikIlkIzlemForm';
            componentInfo.ModuleName = "ENabizModule";
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/E_Nabiz_Modulu/ENabizModule';
            componentInfo.InputParam = new DynamicComponentInputParam('', new ActiveIDsModel(this._PatientExamination.ObjectID, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Ilk Izlem Form';
            modalInfo.Width = 1024;
            modalInfo.Height = 768;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    public isEmergencyIntervention(): Number {
        if (this._PatientExamination == null)
            return 0;
        if (this._PatientExamination.EmergencyIntervention == null)
            return 0;
        if (this._PatientExamination.EmergencyIntervention != null)
            return 1;

        return 0;

    }

    public includeDrugDefinition(): Boolean {// acil Muaynelerde Malzeme sarfdan ilaç girişi  yapılabilir
        //if (this.isEmergencyIntervention() > 0)
        //    return true;
        //return false;
        return this.patientExaminationDoctorFormNewViewModel.includeDrugDefinition;
    }

    async onTakeInpatientObservation() {
        if (this._PatientExamination.EmergencyIntervention != null) {
            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), 'Müşahedeye Al',
                "Hasta müşahedeye alınacaktır. Devam etmek istediğinize emin misiniz? ");
            if (result === 'V') {
                ServiceLocator.MessageService.showSuccess(i18n("M14753", "İşlemden Vazgeçildi"));
            }
            else {
                try {
                    let result = await this.httpService.post('/api/PatientExaminationService/TakeInpatientObservation', this.patientExaminationDoctorFormNewViewModel._PatientExamination.EmergencyIntervention);
                    this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("INPATIENTPHYSICIANAPPLICATION", result, null);
                    ServiceLocator.MessageService.showInfo(i18n("M15281", "Hasta müşahedeye alınmıştır."));
                } catch (err) {
                    ServiceLocator.MessageService.showError(err);
                }
            }
        } else {
            TTVisual.InfoBox.Show(i18n("M21097", "Sadece \'Acil Kabüller\' müşahedeye alınabilir."), MessageIconEnum.WarningMessage);
        }

    }

    public openProvisionTypePopup() {

        this.showProvisionTypePopup = true;

    }

    public ChangeProvisionType() {
        let that = this;
        // this.changeProvisionTypeClass = new ChangeProvisionTypeClass();
        if (this.changeProvisionTypeClass.AdmissionType == null) {
            ServiceLocator.MessageService.showError("Geliş sebebi alanı boş bırakılamaz.");
            return false;
        }
        else if (this.changeProvisionTypeClass.AdmissionType.provizyonTipiKodu.Equals("T") && this.changeProvisionTypeClass.MedulaPlakaNo == null) {
            ServiceLocator.MessageService.showError("Geliş Sebebi Trafik Kazası Olan İşlemler için Plaka Bilgisi Zorunludur.");
            return false;
        }
        else if (this.changeProvisionTypeClass.AdmissionType.provizyonTipiKodu.Equals("S") && this.changeProvisionTypeClass.MedulaIstisnaiHal == null) {
            ServiceLocator.MessageService.showError("Geliş sebebi 'İstisnai Hal' olan kabullerin İstisnai Hal alanı boş bırakılamaz.");
            return false;
        }
        else if (this.changeProvisionTypeClass.AdmissionType.provizyonTipiKodu.Equals("V") && this.changeProvisionTypeClass.SKRSAdliVaka == null) {
            ServiceLocator.MessageService.showError("Geliş sebebi 'Adli Vaka' olan kabullerin Adli Vaka Geliş Şekli alanı boş bırakılamaz.");
            return false;
        }
        else if (this.changeProvisionTypeClass.AdmissionType.provizyonTipiKodu.Equals("T") && this.changeProvisionTypeClass.MedulaVakaTarihi == null) {
            ServiceLocator.MessageService.showError("Geliş sebebi 'Trafik Kazası' olan kabullerin Vaka Tarihi alanı boş bırakılamaz.");
            return false;
        }
        else if (this.changeProvisionTypeClass.AdmissionType.provizyonTipiKodu.Equals("I") && this.changeProvisionTypeClass.MedulaVakaTarihi == null) {
            ServiceLocator.MessageService.showError("Geliş sebebi 'iş Kazası' olan kabullerin Vaka Tarihi alanı boş bırakılamaz.");
            return false;
        }
        else if (this.changeProvisionTypeClass.AdmissionType.provizyonTipiKodu.Equals("V") && this.changeProvisionTypeClass.MedulaVakaTarihi == null) {
            ServiceLocator.MessageService.showError("Geliş sebebi 'Adli Vaka' olan kabullerin Vaka Tarihi alanı boş bırakılamaz.");
            return false;
        }

        try {
            this.loadPanelOperation(true, 'Geliş Sebebi değiştiriliyor, lütfen bekleyiniz.');
            let apiUrlForUserCustomizationKayit: string = '/api/PatientExaminationService/ChangeProvisionType';

            that.changeProvisionTypeClass.SubepisodeID = that.patientExaminationDoctorFormNewViewModel._PatientExamination.SubEpisode.toString();
            this.httpService.post<Guid>(apiUrlForUserCustomizationKayit, that.changeProvisionTypeClass).then(response => {

                this.showProvisionTypePopup = false;
                ServiceLocator.MessageService.showSuccess(i18n("M18041", "Kurum değiştirme işlemi başarı ile sonuçlandı."));
                this.loadPanelOperation(false, "");
            }).catch(error => {
                ServiceLocator.MessageService.showError(error);
                this.loadPanelOperation(false, "");
                this.showProvisionTypePopup = false;
                console.log(error);
            });
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err.message);
            this.loadPanelOperation(false, "");
            this.showProvisionTypePopup = false;
        }
    }


    public setENabizViewModel(viewModels: Array<any>) {

        for (let i = 0; i < viewModels.length; i++) {
            this.patientExaminationDoctorFormNewViewModel.ENabizViewModels.push(viewModels[i]);
        }

    }

    public setLastMenstrualPeriod(event) {
        this.patientExaminationDoctorFormNewViewModel.hasSpecialityBasedObject = true;
        this.ActivePage = 'uzmanlik';
        this.openUzmanlikTab = true;
        this.TabPanelClick('uzmanlik');
        let that = this;
        that.loadPanelOperation(true, "Gebelik Bildirim Kontrolü Yapılıyor, Lütfen Bekleyiniz");
        let taskID = setInterval(() => {
            if (that.patientExaminationDoctorFormNewViewModel.SpecialityBasedObjectViewModels != null) {
                if (that.patientExaminationDoctorFormNewViewModel.SpecialityBasedObjectViewModels[0] instanceof WomanSpecialityFormViewModel) {
                    let viewModel: WomanSpecialityFormViewModel = that.patientExaminationDoctorFormNewViewModel.SpecialityBasedObjectViewModels[0];

                    if (viewModel._IsPregnancyStarted == false)
                        viewModel.showPregnancyStartPopup = true;

                    viewModel._GebelikBildirimViewModel = new Array<GebelikBildirim>();
                    viewModel._GebelikBildirimViewModel = event;

                    // viewModel._PregnancyStartFormViewModel= new PregnancyStartFormViewModel();
                    // viewModel._PregnancyStartFormViewModel._Pregnancy =new Pregnancy();
                    // viewModel._PregnancyStartFormViewModel._Pregnancy.LastMenstrualPeriod = new Date();

                    clearInterval(taskID);
                    that.loadPanelOperation(false, "");
                }
            }
        }, 500);


    }

    //selectRequestDate(data: any) {
    //    if (this.procedureRequestForm != undefined) {
    //        this.procedureRequestForm.requestDate = data;
    //        this.mostUsedProcedureRequestForm.requestDate = data;
    //    }

    //}

    //disableRequestForms(data: any) {
    //    if (this.procedureRequestForm != undefined) {
    //        this.procedureRequestForm.disableRequestForms(data);
    //        this.mostUsedProcedureRequestForm.disableRequestForms(data);
    //    }
    //}

    private async onEnabizClose(fromSave: boolean, saveInfo?: FormSaveInfo) { //Muayene kaydedilirken kontrol edildiği için veri girişi olmaz ise kaydet engellenmeli
        let that = this;
        try {
            if (fromSave) {//Nabız ektranındaki kaydetten geldiyse
                this.showNabizPopup = false;
                this.setENabizViewModel(this._eNabizViewModels);
                this.continueSave(saveInfo);

            } else//Cancel ise
            {
                //this.showNabizPopup = false;
                throw new TTException(i18n("M14008", "Evde Sağlık İzlemini Doldurmadan Kaydetme İşlemine Devam Edemezsiniz."));
            }
        } catch (err) {
            ServiceLocator.MessageService.showError(err.message);
        }

    }

    private async checkENabiz(saveInfo?: FormSaveInfo) {
        //Nabız kontrolü- Evde Sağlık İzlemnleri İçin

        let that = this;
        let apiUrlCheckENabiz: string = '/api/PatientExaminationService/CheckENabizForSave?ExaminationObjectID=' + this.patientExaminationDoctorFormNewViewModel._PatientExamination.ObjectID;

        that.httpService.get<any>(apiUrlCheckENabiz)
            .then(response => {
                let result = response;
                this._nabizList = response as Array<ENabizDataSets>;

                //Ekran aç
                if (this._nabizList.length > 0) {
                    this.showNabizPopup = true;

                } else {
                    this.continueSave(saveInfo);

                }

            })
            .catch(error => {
                console.log(error);
            });


    }

    private async continueSave(saveInfo?: FormSaveInfo) {
        await this.save(saveInfo);
    }

    public openENabiz(): void {
        this.helpMenuService.showPatientENabizInfo(this.getClickFunctionParams());
    }

    public getVaccineFollowUpParams(): ActiveIDsModel {
        let activeIDsModel: ActiveIDsModel = new ActiveIDsModel(null, this._PatientExamination.Episode.ObjectID, null);
        return activeIDsModel;
    }

    public async undoExamination() {
        let episodeActionID = this._ViewModel._PatientExamination.ObjectID;

        if (episodeActionID != null) {
            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), 'Hastayı Takibe Al',
                "İşlem geri alınacaktır. Devam etmek istediğinize emin misiniz? ");
            if (result === 'V') {
                ServiceLocator.MessageService.showSuccess(i18n("M14753", "İşlemden Vazgeçildi"));
            }
            else {
                try {
                    let that = this;
                    that.undoCompletedExamination(episodeActionID);
                } catch (error) {
                    ServiceLocator.MessageService.showError(error);
                    //alert("Hata : " + error);
                    console.log(error);
                }

            }
        } else {
            this.messageService.showError(i18n("M14482", "Hastayı Takibe Al özelliği ancak geçerli bir muayene işlemi üzerinden gerçekleştirilebilir."));
        }
    }


    private undoCompletedExamination(episodeActionID: Guid) {
        if (episodeActionID != null) {
            let that = this;
            let apiUrl: string = "/api/PatientExaminationService/undoCompletedExamination?episodeActionId=" + episodeActionID;
            that.httpService.get<any>(apiUrl).then(response => {
                let result = response;
                ServiceLocator.MessageService.showSuccess(i18n("M16826", "İşlem geri alındı."));
                this.ngOnInit();
            })
                .catch(error => {
                    ServiceLocator.MessageService.showError(error);
                    //alert("Hata : " + error);
                    console.log(error);
                });
        }
    }

    public async DailyOperations() {
        this.InpatientDate = this.patientExaminationDoctorFormNewViewModel._PatientExamination.ProcessDate.AddMinutes(1);
        super.DailyOperations();
    }

    public getShowMaternityAppointmentParams(): ClickFunctionParams {

        let model: ClickFunctionParams = new ClickFunctionParams(this, new GiveAppointmentModel(null, this.patientExaminationDoctorFormNewViewModel.SpecialityBasedObjectList[0]));
        return model;
    }

    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        if (this.patientExaminationDoctorFormNewViewModel.hasWomanSpecialityBasedObject === true) {
            let maternityAppointmentForm = new DynamicSidebarMenuItem();
            maternityAppointmentForm.key = 'maternityAppointmentForm';
            maternityAppointmentForm.icon = 'fa fa-file-text-o';
            maternityAppointmentForm.label = 'Doğum Randevusu';
            maternityAppointmentForm.componentInstance = this.helpMenuService;
            maternityAppointmentForm.clickFunction = this.helpMenuService.showAppointmentForm;
            maternityAppointmentForm.parameterFunctionInstance = this;
            maternityAppointmentForm.getParamsFunction = this.getShowMaternityAppointmentParams;
            maternityAppointmentForm.ParentInstance = this;
            this.sideBarMenuService.addMenu('YardimciMenu', maternityAppointmentForm);
        }

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

        let printEpicrisisForm = new DynamicSidebarMenuItem();
        printEpicrisisForm.key = 'printEpicrisisForm';
        printEpicrisisForm.icon = 'fa fa-file-text-o';
        printEpicrisisForm.label = 'Epikriz Formu';
        printEpicrisisForm.componentInstance = this;
        printEpicrisisForm.clickFunction = this.printEpicrisisReport;
        printEpicrisisForm.parameterFunctionInstance = this;
        //printEpicrisisForm.getParamsFunction = this.getClickFunctionParams;
        printEpicrisisForm.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', printEpicrisisForm);

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

        let nabizMessage = new DynamicSidebarMenuItem();
        nabizMessage.key = 'nabizMessage';
        nabizMessage.icon = 'ai ai-enabiz-mesaj-gonder';
        nabizMessage.label = i18n("M13710", "E-Nabız Mesaj Gönder");
        nabizMessage.componentInstance = this.helpMenuService;
        nabizMessage.clickFunction = this.helpMenuService.onSendENabizMessageOpen;
        nabizMessage.parameterFunctionInstance = this;
        nabizMessage.getParamsFunction = this.getClickFunctionParams;
        nabizMessage.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', nabizMessage);


        let ssk = new DynamicSidebarMenuItem();
        ssk.key = 'ssk';
        ssk.icon = 'ai ai-sgkisgoremez';
        ssk.label = i18n("M21780", "Sgk İş Görememezlik");
        ssk.componentInstance = this;
        ssk.clickFunction = this.openSskLink;
        this.sideBarMenuService.addMenu('YardimciMenu', ssk);

        if (this.patientExaminationDoctorFormNewViewModel.IsPhysiotherapyRequestFormUsing == true && this.patientExaminationDoctorFormNewViewModel.HasAuthorityForPhysiotherapyRequest == true) {

            let openPhysiotherapyRequest = new DynamicSidebarMenuItem();
            openPhysiotherapyRequest.key = 'openPhysiotherapyRequest';
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

       
        if (this.patientExaminationDoctorFormNewViewModel.isNewMHRS) {
            let addgreenList_New = new DynamicSidebarMenuItem();
            addgreenList_New.key = 'addgreenList_New';
            addgreenList_New.icon = 'ai ai-addlist ';
            addgreenList_New.label = "Yeşil Listeye Ekle/Güncelle(180 Gün)";
            addgreenList_New.componentInstance = this.helpMenuService;
            addgreenList_New.clickFunction = this.helpMenuService.addMHRSGreenList_New;
            addgreenList_New.parameterFunctionInstance = this;
            addgreenList_New.getParamsFunction = this.getClickFunctionParams;
            addgreenList_New.ParentInstance = this;
            this.sideBarMenuService.addMenu('YardimciMenu', addgreenList_New);

            let searchgreenList_New = new DynamicSidebarMenuItem();
            searchgreenList_New.key = 'searchgreenList_New';
            searchgreenList_New.icon = 'ai ai-checkist';
            searchgreenList_New.label = "Yeşil Liste Sorgula";
            searchgreenList_New.componentInstance = this.helpMenuService;
            searchgreenList_New.clickFunction = this.helpMenuService.searchMHRSGreenList_New;
            searchgreenList_New.parameterFunctionInstance = this;
            searchgreenList_New.getParamsFunction = this.getClickFunctionParams;
            searchgreenList_New.ParentInstance = this;
            this.sideBarMenuService.addMenu('YardimciMenu', searchgreenList_New);

        } else {
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


        let eNabizDataSets = new DynamicSidebarMenuItem();
        eNabizDataSets.key = 'eNabizDataSets';
        eNabizDataSets.label = i18n("M13708", "E-Nabız");
        eNabizDataSets.icon = 'ai ai-enabiz-mesaj-gonder';
        eNabizDataSets.componentInstance = this;
        eNabizDataSets.clickFunction = this.openENabizDataSets;
        this.sideBarMenuService.addMenu('YardimciMenu', eNabizDataSets);

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

        if (this._PatientExamination.EmergencyIntervention != null) {

            let onTakeInpatientObservation = new DynamicSidebarMenuItem();
            onTakeInpatientObservation.key = 'onTakeInpatientObservation';
            onTakeInpatientObservation.icon = 'ai ai-patientatbed';
            onTakeInpatientObservation.label = i18n("M30201", 'Müşahedeye Al');
            onTakeInpatientObservation.componentInstance = this;
            onTakeInpatientObservation.clickFunction = this.onTakeInpatientObservation;
            this.sideBarMenuService.addMenu('YardimciMenu', onTakeInpatientObservation);
        }

        let pathologyRequest = new DynamicSidebarMenuItem();
        pathologyRequest.key = 'pathologyRequest';
        pathologyRequest.icon = 'ai ai-chemical';
        pathologyRequest.label = i18n("M20230", "Patoloji İstek");
        pathologyRequest.componentInstance = this.helpMenuService;
        pathologyRequest.clickFunction = this.helpMenuService.onPathologyRequest;
        pathologyRequest.parameterFunctionInstance = this;
        pathologyRequest.getParamsFunction = this.getClickFunctionParams;
        pathologyRequest.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', pathologyRequest);

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

        let patientNoShown = new DynamicSidebarMenuItem();
        patientNoShown.key = 'patientNoShown';
        patientNoShown.icon = 'ai ai-muayenegelmedi';
        patientNoShown.label = 'Muayeneye Gelmedi';
        patientNoShown.componentInstance = this.helpMenuService;
        patientNoShown.clickFunction = this.helpMenuService.patientNoShown;
        patientNoShown.parameterFunctionInstance = this;
        patientNoShown.getParamsFunction = this.getClickFunctionParams;
        patientNoShown.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', patientNoShown);

        if (this._ViewModel._PatientExamination.CurrentStateDefID.toString() === PatientExamination.PatientExaminationStates.Completed.id) {
            let undoExamination = new DynamicSidebarMenuItem();
            undoExamination.key = 'undoExamination';
            undoExamination.icon = 'fa fa-undo';
            undoExamination.label = 'Hastayı Takibe Al';
            undoExamination.componentInstance = this;
            undoExamination.clickFunction = this.undoExamination;
            undoExamination.parameterFunctionInstance = this;
            undoExamination.getParamsFunction = this.getClickFunctionParams;
            undoExamination.ParentInstance = this;
            this.sideBarMenuService.addMenu('YardimciMenu', undoExamination);
        }

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

        if (this.isHealthCommittee) {
            let hC_RelevanceReport = new DynamicSidebarMenuItem();
            hC_RelevanceReport.key = 'hC_RelevanceReport';
            hC_RelevanceReport.icon = 'fa fa-file-text-o';
            hC_RelevanceReport.label = 'Tıbbi Uygunluk Raporu';
            hC_RelevanceReport.componentInstance = this;
            hC_RelevanceReport.clickFunction = this.OpenHC_RelevanceReport;
            this.sideBarMenuService.addMenu('YardimciMenu', hC_RelevanceReport);
        }

        if (this.patientExaminationDoctorFormNewViewModel.hasDoctorKotaRole) {
            let docorQuota = new DynamicSidebarMenuItem();
            docorQuota.key = 'docorQuota';
            docorQuota.icon = 'ai ai-doktor-kota';
            docorQuota.label = i18n("M15178", "Doktor Kota");
            docorQuota.componentInstance = this.helpMenuService;
            docorQuota.clickFunction = this.helpMenuService.openDoctorQuota;
            this.sideBarMenuService.addMenu('YardimciMenu', docorQuota);
        }

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

        if (this.patientExaminationDoctorFormNewViewModel.hasDoctorEAthleteRole == true) {
            let AthleteReport = new DynamicSidebarMenuItem();
            AthleteReport.key = 'AthleteReport';
            AthleteReport.componentInstance = this;
            AthleteReport.label = 'e-Sporcu Raporu Yaz';
            AthleteReport.icon = 'fa fa-futbol-o';
            AthleteReport.clickFunction = this.openAthleteReport;
            this.sideBarMenuService.addMenu("SaglikBakanligiRaporlari", AthleteReport);
        }

        if (this.patientExaminationDoctorFormNewViewModel.hasDoctorEDriverRole == true) {
            let DriverReport = new DynamicSidebarMenuItem();
            DriverReport.key = 'DriverReport';
            DriverReport.componentInstance = this;
            DriverReport.label = 'e-Sürücü Raporu Yaz';
            DriverReport.icon = 'fa fa-car';
            DriverReport.clickFunction = this.openDriverReport;
            this.sideBarMenuService.addMenu("SaglikBakanligiRaporlari", DriverReport);
        }
        if (this.patientExaminationDoctorFormNewViewModel.hasDoctorEPsychotecnicsRole == true) {
            let PsychotecnicsReport = new DynamicSidebarMenuItem();
            PsychotecnicsReport.key = 'PsychotecnicsReport';
            PsychotecnicsReport.componentInstance = this;
            PsychotecnicsReport.label = 'e-Psikoteknik Raporu Yaz';
            PsychotecnicsReport.icon = 'fa fa-address-card';
            PsychotecnicsReport.clickFunction = this.openPsychotecnicsReport;
            this.sideBarMenuService.addMenu("SaglikBakanligiRaporlari", PsychotecnicsReport);
        }

        if (this.patientExaminationDoctorFormNewViewModel.hasOrthesisRequestRole == true) {
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

        if (this.patientExaminationDoctorFormNewViewModel.IsPatientAdmissionEmergengy === true || this._PatientExamination.EmergencyIntervention != null) {
            let forensicMedicalReport = new DynamicSidebarMenuItem();
            forensicMedicalReport.key = 'forensicMedicalReport';
            forensicMedicalReport.icon = 'far fa-file-alt';
            forensicMedicalReport.label = 'Adli Vaka Formu'
            forensicMedicalReport.componentInstance = this.helpMenuService;
            forensicMedicalReport.clickFunction = this.helpMenuService.onForensicMedicalReportOpen;
            forensicMedicalReport.parameterFunctionInstance = this;
            forensicMedicalReport.getParamsFunction = this.getClickFunctionParams;
            forensicMedicalReport.ParentInstance = this;
            this.sideBarMenuService.addMenu('YardimciMenu', forensicMedicalReport);

            let forensicMedicalForm = new DynamicSidebarMenuItem();
            forensicMedicalForm.key = 'forensicMedicalForm';
            forensicMedicalForm.icon = 'far fa-file-alt';
            forensicMedicalForm.label = 'Adli Vaka Formu'
            forensicMedicalForm.componentInstance = this.helpMenuService;
            forensicMedicalForm.clickFunction = this.helpMenuService.onPrintForensicMedicalReport;
            forensicMedicalForm.parameterFunctionInstance = this;
            forensicMedicalForm.getParamsFunction = this.getClickFunctionParams;
            forensicMedicalForm.ParentInstance = this;
            this.sideBarMenuService.addMenu('ReportMainItem', forensicMedicalForm);
        }
        if (!this.isHealthCommittee) {
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
        }

        if (this._PatientExamination.EmergencyIntervention != null) {

            let changeProvisionType = new DynamicSidebarMenuItem();
            changeProvisionType.key = 'changeProvisionType';
            changeProvisionType.icon = 'ai ai-takip-al';
            changeProvisionType.label = 'Geliş Sebebi Değiştir';
            changeProvisionType.componentInstance = this;
            changeProvisionType.clickFunction = this.openProvisionTypePopup;
            this.sideBarMenuService.addMenu('YardimciMenu', changeProvisionType);
        }

        let emergencyStaticForm = new DynamicSidebarMenuItem();
        emergencyStaticForm.key = 'emergencyStaticForm';
        emergencyStaticForm.icon = 'fas fa-chart-bar';
        emergencyStaticForm.label = 'Acil Müşahede Listesi'
        emergencyStaticForm.componentInstance = this;
        emergencyStaticForm.clickFunction = this.openEmergencyStaticForm;
        // emergencyStaticForm.parameterFunctionInstance = this;
        // emergencyStaticForm.getParamsFunction = this.getClickFunctionParams;
        emergencyStaticForm.ParentInstance = this;
        this.sideBarMenuService.addMenu('StatisticReportMainItem', emergencyStaticForm);

        let injectionForm = new DynamicSidebarMenuItem();
        injectionForm.key = 'injectionForm';
        injectionForm.icon = 'fas fa-chart-bar';
        injectionForm.label = 'Enjeksiyon Defteri'
        injectionForm.componentInstance = this;
        injectionForm.clickFunction = this.openInjectionForm;
        injectionForm.ParentInstance = this;
        this.sideBarMenuService.addMenu('StatisticReportMainItem', injectionForm);

        if (this._PatientExamination.CurrentStateDefID == PatientExamination.PatientExaminationStates.ExaminationCompleted || this._PatientExamination.CurrentStateDefID == PatientExamination.PatientExaminationStates.ProcedureRequested) {
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


        let procedureReport = new DynamicSidebarMenuItem();
        procedureReport.key = 'procedureReport';
        procedureReport.icon = 'fa fa-file-text-o';
        procedureReport.label = 'İşlem Raporu';
        procedureReport.parameterFunctionInstance = this;
        procedureReport.getParamsFunction = this.getClickFunctionParams;
        procedureReport.componentInstance = this.helpMenuService;
        procedureReport.clickFunction = this.helpMenuService.onProcedureReportOpen;
        procedureReport.ParentInstance = this;
        this.sideBarMenuService.addMenu('ReportMainItem', procedureReport);

        let newPoliclinicBookReport = new DynamicSidebarMenuItem();
        newPoliclinicBookReport.key = 'newPoliclinicBookReport';
        newPoliclinicBookReport.icon = 'fa fa-file-text-o';
        newPoliclinicBookReport.label = 'Poliklinik Defteri';
        newPoliclinicBookReport.componentInstance = this;
        newPoliclinicBookReport.clickFunction = this.openPoliclinicBookReportInfo;
        this.sideBarMenuService.addMenu('ReportMainItem', newPoliclinicBookReport);

        let newJ11DiagnoseReport = new DynamicSidebarMenuItem();
        newJ11DiagnoseReport.key = 'newJ11DiagnoseReport';
        newJ11DiagnoseReport.icon = 'fa fa-file-text-o';
        newJ11DiagnoseReport.label = 'J11 Tanısı Girilen Hastalar';
        newJ11DiagnoseReport.componentInstance = this;
        newJ11DiagnoseReport.clickFunction = this.openJ11DiagnoseReportInfo;
        this.sideBarMenuService.addMenu('ReportMainItem', newJ11DiagnoseReport);

        let newExaminationTimeReport = new DynamicSidebarMenuItem();
        newExaminationTimeReport.key = 'newExaminationTimeReport';
        newExaminationTimeReport.icon = 'fa fa-file-text-o';
        newExaminationTimeReport.label = 'Muayene Süreleri';
        newExaminationTimeReport.componentInstance = this;
        newExaminationTimeReport.clickFunction = this.openExaminationTimeReportInfo;
        this.sideBarMenuService.addMenu('StatisticReportMainItem', newExaminationTimeReport);

        let openOBSWeb = new DynamicSidebarMenuItem();
        openOBSWeb.key = 'openOBSWeb';
        openOBSWeb.icon = 'ai ai-obs';
        openOBSWeb.label = 'Ölüm Bildirim Sistemi';
        openOBSWeb.parameterFunctionInstance = this;
        openOBSWeb.getParamsFunction = this.getClickFunctionParams;
        openOBSWeb.componentInstance = this.helpMenuService;
        openOBSWeb.clickFunction = this.helpMenuService.openOBSWeb;
        openOBSWeb.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', openOBSWeb);

        if (this.patientExaminationDoctorFormNewViewModel.hasOpenEpisodeRole == true) {
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

        if (this.patientExaminationDoctorFormNewViewModel.hasCloseEpisodeRole == true) {
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


        //KETEM
        if (this.patientExaminationDoctorFormNewViewModel.IsKetem == true) {
            let ketemroot = new DynamicSidebarMenuItem();
            ketemroot.key = 'ketemroot';
            ketemroot.icon = 'ai ai-kanser';
            ketemroot.label = 'KETEM';
            this.sideBarMenuService.addMenu(null, ketemroot);

            let cancerscreening = new DynamicSidebarMenuItem();
            cancerscreening.key = 'cancerscreening';
            cancerscreening.icon = 'fa fa-file-text-o';
            cancerscreening.label = 'Toplum Tabanlı Kanser Tarama Formu';
            cancerscreening.componentInstance = this.helpMenuService;
            cancerscreening.clickFunction = this.helpMenuService.onKetemCancerScreening;
            cancerscreening.parameterFunctionInstance = this;
            cancerscreening.getParamsFunction = this.getClickFunctionParams;
            cancerscreening.ParentInstance = this;
            this.sideBarMenuService.addMenu('ketemroot', cancerscreening);


            if (this.patientExaminationDoctorFormNewViewModel.GenderCode == "2") { //Kadın
                let breastscreening = new DynamicSidebarMenuItem();
                breastscreening.key = 'breastscreening';
                breastscreening.icon = 'fa fa-file-text-o';
                breastscreening.label = 'Meme Tarama Formu';
                breastscreening.componentInstance = this.helpMenuService;
                breastscreening.clickFunction = this.helpMenuService.onKetemBreastScreening;
                breastscreening.parameterFunctionInstance = this;
                breastscreening.getParamsFunction = this.getClickFunctionParams;
                breastscreening.ParentInstance = this;
                this.sideBarMenuService.addMenu('ketemroot', breastscreening);

                let smearscreening = new DynamicSidebarMenuItem();
                smearscreening.key = 'smearscreening';
                smearscreening.icon = 'fa fa-file-text-o';
                smearscreening.label = 'Smear Tarama Formu';
                smearscreening.componentInstance = this.helpMenuService;
                smearscreening.clickFunction = this.helpMenuService.onKetemSmearScreening;
                smearscreening.parameterFunctionInstance = this;
                smearscreening.getParamsFunction = this.getClickFunctionParams;
                smearscreening.ParentInstance = this;
                this.sideBarMenuService.addMenu('ketemroot', smearscreening);
            } else if (this.patientExaminationDoctorFormNewViewModel.GenderCode == "1") {

                let prostatescreening = new DynamicSidebarMenuItem();
                prostatescreening.key = 'prostatescreening';
                prostatescreening.icon = 'fa fa-file-text-o';
                prostatescreening.label = 'Prostat Kanseri Tarama Formu';
                prostatescreening.componentInstance = this.helpMenuService;
                prostatescreening.clickFunction = this.helpMenuService.onKetemProstateScreening;
                prostatescreening.parameterFunctionInstance = this;
                prostatescreening.getParamsFunction = this.getClickFunctionParams;
                prostatescreening.ParentInstance = this;
                this.sideBarMenuService.addMenu('ketemroot', prostatescreening);
            }

            let cigaretteInspection = new DynamicSidebarMenuItem();
            cigaretteInspection.key = 'cigaretteInspection';
            cigaretteInspection.icon = 'fa fa-file-text-o';
            cigaretteInspection.label = 'Sigara İzlem Formu';
            cigaretteInspection.componentInstance = this.helpMenuService;
            cigaretteInspection.clickFunction = this.helpMenuService.onCigaretteInspection;
            cigaretteInspection.parameterFunctionInstance = this;
            cigaretteInspection.getParamsFunction = this.getClickFunctionParams;
            cigaretteInspection.ParentInstance = this;
            this.sideBarMenuService.addMenu('ketemroot', cigaretteInspection);

            let cigaretteExamination = new DynamicSidebarMenuItem();
            cigaretteExamination.key = 'cigaretteExamination';
            cigaretteExamination.icon = 'fa fa-file-text-o';
            cigaretteExamination.label = 'Sigara Muayene Formu';
            cigaretteExamination.componentInstance = this.helpMenuService;
            cigaretteExamination.clickFunction = this.helpMenuService.onCigaretteExamination;
            cigaretteExamination.parameterFunctionInstance = this;
            cigaretteExamination.getParamsFunction = this.getClickFunctionParams;
            cigaretteExamination.ParentInstance = this;
            this.sideBarMenuService.addMenu('ketemroot', cigaretteExamination);

            let cigaretteAssesment = new DynamicSidebarMenuItem();
            cigaretteAssesment.key = 'cigaretteAssesment';
            cigaretteAssesment.icon = 'fa fa-file-text-o';
            cigaretteAssesment.label = 'Sigara Değerlendirme Formu';
            cigaretteAssesment.componentInstance = this.helpMenuService;
            cigaretteAssesment.clickFunction = this.helpMenuService.onCigaretteAssesment;
            cigaretteAssesment.parameterFunctionInstance = this;
            cigaretteAssesment.getParamsFunction = this.getClickFunctionParams;
            cigaretteAssesment.ParentInstance = this;
            this.sideBarMenuService.addMenu('ketemroot', cigaretteAssesment);
        }

        let openWorkablePaperPopUp = new DynamicSidebarMenuItem();
        openWorkablePaperPopUp.key = 'openWorkablePaperPopUp';
        openWorkablePaperPopUp.icon = 'fa fa-file-text-o';
        openWorkablePaperPopUp.label = i18n("M14009", "İşbaşı Çalışabilir Kağıdı");
        openWorkablePaperPopUp.componentInstance = this;
        openWorkablePaperPopUp.clickFunction = this.showWorkableReportPopUp;
        this.sideBarMenuService.addMenu('ReportMainItem', openWorkablePaperPopUp);

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

        if (this._PatientExamination.EmergencyIntervention != null) {
            let ExPatientsInEmergenyDepartment = new DynamicSidebarMenuItem();
            ExPatientsInEmergenyDepartment.key = 'ExPatientsInEmergenyDepartment';
            ExPatientsInEmergenyDepartment.componentInstance = this.helpMenuService;
            ExPatientsInEmergenyDepartment.label = 'Acil Ex Hasta Listesi';
            ExPatientsInEmergenyDepartment.icon = 'fa fa-file-text-o';
            ExPatientsInEmergenyDepartment.clickFunction = this.helpMenuService.openExPatientListReport;
            this.sideBarMenuService.addMenu("StatisticReportMainItem", ExPatientsInEmergenyDepartment);
        }

        //let userPackage = new DynamicSidebarMenuItem();
        //userPackage.key = 'userPackage';
        //userPackage.icon = "fa fa-file-text-o";
        //userPackage.label = 'Müdahale Paketi';
        //userPackage.componentInstance = this.helpMenuService;
        //userPackage.clickFunction = this.helpMenuService.openUserPackage;
        //userPackage.parameterFunctionInstance = this;
        //userPackage.getParamsFunction = this.getClickFunctionParams;
        //userPackage.ParentInstance = this;
        //this.sideBarMenuService.addMenu('YardimciMenu', userPackage);
        if (this.patientExaminationDoctorFormNewViewModel.IsIndustrialAccident == true) {
            let industrialAccidentReport = new DynamicSidebarMenuItem();
            industrialAccidentReport.key = 'industrialAccidentReport';
            industrialAccidentReport.icon = 'far fa-file-alt';
            industrialAccidentReport.label = 'İş Kazası Raporu'
            industrialAccidentReport.componentInstance = this.helpMenuService;
            industrialAccidentReport.clickFunction = this.helpMenuService.onIndustrialAccidentReportOpen;
            industrialAccidentReport.parameterFunctionInstance = this;
            industrialAccidentReport.getParamsFunction = this.getClickFunctionParams;
            industrialAccidentReport.ParentInstance = this;
            this.sideBarMenuService.addMenu('YardimciMenu', industrialAccidentReport);
        }

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

        if (this.patientExaminationDoctorFormNewViewModel.IsPcrRequested == true) {
            let newPcrRequestReport = new DynamicSidebarMenuItem();
            newPcrRequestReport.key = 'newPcrRequestReport';
            newPcrRequestReport.icon = 'fa fa-file-text-o';
            newPcrRequestReport.label = 'Geçici İzolasyon Raporu';
            newPcrRequestReport.componentInstance = this;
            newPcrRequestReport.clickFunction = this.openPcrRequestReportInfo;
            this.sideBarMenuService.addMenu('YardimciMenu', newPcrRequestReport);
        }

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
        //this.sideBarMenuService.removeMenu('userPackage');
        this.sideBarMenuService.removeMenu('printEpicrisisForm');
        this.sideBarMenuService.removeMenu('createEDurumBildirirReport');
        this.sideBarMenuService.removeMenu('openEDurumBildirirReportIndex');
        this.sideBarMenuService.removeMenu('openPatientSgkReports');
        this.sideBarMenuService.removeMenu('injectionForm');
        this.sideBarMenuService.removeMenu('hastaNakilFormu');

        this.sideBarMenuService.removeMenu('maternityAppointmentForm');
        this.sideBarMenuService.removeMenu('colorPrescription');
        this.sideBarMenuService.removeMenu('manipulation');
        this.sideBarMenuService.removeMenu('patientDocumentUpload');
        this.sideBarMenuService.removeMenu('surgery');
        this.sideBarMenuService.removeMenu('nabizMessage');
        /* this.sideBarMenuService.removeMenu('showENabizInfo');*/
        this.sideBarMenuService.removeMenu('ssk');
        this.sideBarMenuService.removeMenu('openPhysiotherapyRequest');
        this.sideBarMenuService.removeMenu('openPhysiotherapyTreatmentNote');
        this.sideBarMenuService.removeMenu('greenList');
        this.sideBarMenuService.removeMenu('greenListSearch');
        this.sideBarMenuService.removeMenu('printInpatientAdmissionInfoByTreatmentClinicReport');
        this.sideBarMenuService.removeMenu('printOrthesisProsthesisReceptionReport');
        this.sideBarMenuService.removeMenu('eNabizDataSets');
        this.sideBarMenuService.removeMenu('vaccineFollowup');
        this.sideBarMenuService.removeMenu('onTakeInpatientObservation');
        this.sideBarMenuService.removeMenu('pathologyRequest');
        this.sideBarMenuService.removeMenu('cancerscreening');
        this.sideBarMenuService.removeMenu('orthesisList');
        this.sideBarMenuService.removeMenu('physioTherapyList');
        this.sideBarMenuService.removeMenu('patientNoShown');
        this.sideBarMenuService.removeMenu('undoExamination');
        if (this.enableInfluenzaHelpServiceButton)
            this.sideBarMenuService.removeMenu('influenzaResult');
        this.sideBarMenuService.removeMenu('hC_RelevanceReport');
        this.sideBarMenuService.removeMenu('docorQuota');
        this.sideBarMenuService.removeMenu('openHemodialysisRequest');
        this.sideBarMenuService.removeMenu('AthleteReport');
        this.sideBarMenuService.removeMenu('ortezIstek');
        this.sideBarMenuService.removeMenu('DriverReport');
        this.sideBarMenuService.removeMenu('PsychotecnicsReport');
        this.sideBarMenuService.removeMenu('forensicMedicalReport');
        this.sideBarMenuService.removeMenu('openInpatientAdmission');
        this.sideBarMenuService.removeMenu('changeProvisionType');

        this.sideBarMenuService.removeMenu('forensicMedicalForm');
        this.sideBarMenuService.removeMenu('emergencyStaticForm');
        this.sideBarMenuService.removeMenu('dailyInpatient');
        this.sideBarMenuService.removeMenu('procedureReport');
        this.sideBarMenuService.removeMenu('newPoliclinicBookReport');
        this.sideBarMenuService.removeMenu('newJ11DiagnoseReport');
        this.sideBarMenuService.removeMenu('openOBSWeb');
        this.sideBarMenuService.removeMenu('openEpisode');
        this.sideBarMenuService.removeMenu('closeEpisode');
        this.sideBarMenuService.removeMenu('ketemroot');
        this.sideBarMenuService.removeMenu('prostatescreening');
        this.sideBarMenuService.removeMenu('breastscreening');
        this.sideBarMenuService.removeMenu('smearscreening');
        this.sideBarMenuService.removeMenu('cigaretteInspection');
        this.sideBarMenuService.removeMenu('cigaretteExamination');
        this.sideBarMenuService.removeMenu('cigaretteAssesment');
        this.sideBarMenuService.removeMenu('chemoRadioRequest');
        this.sideBarMenuService.removeMenu('openWorkablePaperPopUp');
        
        this.sideBarMenuService.removeMenu('subEpisodeTracking');
        this.sideBarMenuService.removeMenu('patientTracking');
        this.sideBarMenuService.removeMenu('ExPatientsInEmergenyDepartment');
        this.sideBarMenuService.removeMenu('surgeryAppointment');
        this.sideBarMenuService.removeMenu('industrialAccidentReport');
        this.sideBarMenuService.removeMenu('labBarcode');

        this.sideBarMenuService.removeMenu('newPcrRequestReport');
        this.sideBarMenuService.removeMenu('addgreenList_New');
    }



    public openPcrRequestReportInfo(): Promise<ModalActionResult> {
               
            let reportData: DynamicReportParameters = {

                Code: 'PCRIZOLASYONRAPOR',
                ReportParams: { PatientExaminationId: this.patientExaminationDoctorFormNewViewModel._PatientExamination.ObjectID},
                ViewerMode: true,
                DisablePrintButtons: false
            };

            return new Promise((resolve, reject) => {

                this.showPoliclinicBookReportInfo = false;

                let componentInfo = new DynamicComponentInfo();
                componentInfo.ComponentName = 'HvlDynamicReportComponent';
                componentInfo.ModuleName = 'DevexpressReportingModule';
                componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
                componentInfo.InputParam = reportData;

                let modalInfo: ModalInfo = new ModalInfo();
                modalInfo.Title = "Geçici İzolasyon Raporu"

                modalInfo.fullScreen = true;

                let result = this.modalService.create(componentInfo, modalInfo);
                result.then(inner => {

                    resolve(inner);
                }).catch(err => {
                    reject(err);
                });
            });
    }

    showPoliclinicBookReportInfo = false;
    policlinicBookReportStartDate: Date = new Date();
    policlinicBookReportEndDate: Date = new Date();
    policlinicBookReportClinic: any;
    public openPoliclinicBookReportInfo(): void {
        this.showPoliclinicBookReportInfo = true;
    }
    public CancelPoliclinicBookReportInfo() {
        this.showPoliclinicBookReportInfo = false;
    }
    public SavePoliclinicBookReportInfo() {
        if (this.policlinicBookReportStartDate == null || this.policlinicBookReportEndDate == null || this.policlinicBookReportClinic == null) {
            throw new TTException("Alanları Doldurmadan Rapor İşlemine Devam Edemezsiniz.");
        } else {
            this.onNewPoliclinicBookReportOpen();
        }
    }

    public onNewPoliclinicBookReportOpen(): Promise<ModalActionResult> {

        let reportData: DynamicReportParameters = {

            Code: 'POLIKLINIKDEFTERIRAPOR',
            ReportParams: { BaslangicTarihi: this.policlinicBookReportStartDate, BitisTarihi: this.policlinicBookReportEndDate, Birim: this.policlinicBookReportClinic },
            ViewerMode: true,
            DisablePrintButtons: false
        };

        return new Promise((resolve, reject) => {

            this.showPoliclinicBookReportInfo = false;

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = reportData;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "POLİKLİNİK DEFTERİ"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {

                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    //#region openJ11DiagnoseReportInfo
    showJ11DiagnoseReportInfo = false;
    J11DiagnoseReportStartDate: Date = new Date();
    J11DiagnoseReportEndDate: Date = new Date();
    public openJ11DiagnoseReportInfo(): void {
        this.showJ11DiagnoseReportInfo = true;
    }
    public CancelJ11DiagnoseReportInfo() {
        this.showJ11DiagnoseReportInfo = false;
    }
    public SaveJ11DiagnoseReportInfo() {
        if (this.J11DiagnoseReportStartDate == null || this.J11DiagnoseReportEndDate == null) {
            throw new TTException("Alanları Doldurmadan Rapor İşlemine Devam Edemezsiniz.");
        } else {
            this.onNewJ11DiagnoseReportOpen();
        }
    }

    public onNewJ11DiagnoseReportOpen(): Promise<ModalActionResult> {

        let reportData: DynamicReportParameters = {

            Code: 'J11TANILIHASTARAPOR',
            ReportParams: { BaslangicTarihi: this.J11DiagnoseReportStartDate, BitisTarihi: this.J11DiagnoseReportEndDate },
            ViewerMode: true,
            DisablePrintButtons: false
        };

        return new Promise((resolve, reject) => {

            this.showJ11DiagnoseReportInfo = false;

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = reportData;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "J11 TANISI GİRİLEN HASTALAR"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {

                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    //#endregion openJ11DiagnoseReportInfo


    //#region openExaminationTimeReportInfo
    showExaminationTimeReportInfo = false;
    ExaminationTimeReportStartDate: Date = new Date();
    ExaminationTimeReportEndDate: Date = new Date();
    public openExaminationTimeReportInfo(): void {
        this.showExaminationTimeReportInfo = true;
    }
    public CancelExaminationTimeReportInfo() {
        this.showExaminationTimeReportInfo = false;
    }
    public SaveExaminationTimeReportInfo() {
        if (this.ExaminationTimeReportStartDate == null || this.ExaminationTimeReportEndDate == null) {
            throw new TTException("Alanları Doldurmadan Rapor İşlemine Devam Edemezsiniz.");
        } else {
            this.onNewExaminationTimeReportOpen();
        }
    }

    public onNewExaminationTimeReportOpen(): Promise<ModalActionResult> {

        let reportData: DynamicReportParameters = {

            Code: 'MUAYENESURELERIRAPOR',
            ReportParams: { BaslangicTarihi: this.ExaminationTimeReportStartDate, BitisTarihi: this.ExaminationTimeReportEndDate },
            ViewerMode: true,
            DisablePrintButtons: false
        };

        return new Promise((resolve, reject) => {

            this.showExaminationTimeReportInfo = false;

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = reportData;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Muayene Süreleri"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {

                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    //#endregion openExaminationTimeReportInfo

    public printEpicrisisReport() {
        let selectedpatientExamination;
        let selectedDoctorParam;
        if (this.patientExaminationDoctorFormNewViewModel._PatientExamination.ProcedureDoctor != null) {

            selectedDoctorParam = new StringParam(this.patientExaminationDoctorFormNewViewModel._PatientExamination.ProcedureDoctor.ObjectID.toString());
            selectedpatientExamination = new StringParam(this.patientExaminationDoctorFormNewViewModel._PatientExamination.ObjectID.toString());
            let reportParameters: any = { 'TTOBJECTID': selectedpatientExamination, 'Doctor': selectedDoctorParam };
            this.reportService.showReport("EpicrisisReportForPatient", reportParameters);
        } else {
            TTVisual.InfoBox.Alert("Doktor Seçmeden Bu Raporu Yazdıramazsınız!");
        }

    }

    public async openERaporSorgulaComponent() {

        this.showERaporSorgulaComponent = true;
    }

    public async openEDurumBildirirReport() {
        if (this.CheckIsDiagnosisExistsForReports(this.patientExaminationDoctorFormNewViewModel.GridEpisodeDiagnosisGridList) == false) {
            this.messageService.showError("Hasta üzerinde kayıtlı bir tanı olmadan Rapor yazamazsınız.!");
            return;
        }
        let parameterValue = await this.helpMenuService.getEDurumBildirirParameter();
        if (parameterValue)
            this.showEDurumBildirirComponent = true;
        else {
            this.helpMenuService.openEDurumBildirirReportPopUp(this.patientExaminationDoctorFormNewViewModel._PatientExamination.ObjectID.toString());
        }
    }

    public openAthleteReport() {
        let fullApiUrl: string = 'api/EpisodeActionService/OpenAthleteCreateReport';
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public openDriverReport() {
        let fullApiUrl: string = 'api/EpisodeActionService/OpenDriverCreateReport';
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public openPsychotecnicsReport() {
        let fullApiUrl: string = 'api/EpisodeActionService/OpenPsychotecnicsCreateReport';
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    private openEmergencyStaticForm() {

        this.showreportStartEndDate = true;
        // this.printAcilMusahedeReport();
    }




    public printAcilMusahedeReport(): Promise<ModalActionResult> {
        let reportData: DynamicReportParameters = {

            Code: 'ACILMUSAHEDE',
            ReportParams: { BaslangicTarihi: this.reportStartDate, BitisTarihi: this.reportEndDatee },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            this.showreportStartEndDate = false;

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, new ActiveIDsModel(this._PatientExamination.ObjectID, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "ACİL MÜŞAHEDE LİSTESİ"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {

                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public onAcilMusahedeReportHiding() {
        this.showreportStartEndDate = false;
    }

    openInjectionForm() {
        this.showInjectionReport = true;
    }
    public onInjectionFormHiding() {
        this.showInjectionReport = false;
    }
    public printInjectionForm() {
        let reportData: DynamicReportParameters = {

            Code: 'ENJEKSIYONDEFTERI',
            ReportParams: { BaslangicTarihi: this.injectionStartDate, BitisTarihi: this.injectionEndDate },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            this.showreportStartEndDate = false;

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, new ActiveIDsModel(this._PatientExamination.ObjectID, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "ENJEKSİYON DEFTERİ"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {

                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }


    openSskLink() {
        this.openInNewTab("http://xxxxxx.com/BirinciBasamak");
    }
    openInNewTab(url) {
        if (url == null) {
            //InfoBox.Alert("Bu hizmetin sonucu bulunamadı!");
        } else {
            let win = window.open(url, '_blank');
            win.focus();
        }
    }
    public ngOnDestroy(): void {
        if (this.refreshReportGridSubscription != null) {
            this.refreshReportGridSubscription.unsubscribe();
            this.refreshReportGridSubscription = null;
        }
        this.RemoveMenuFromHelpMenu();
        this.OnDestroy.emit();
        // this.httpService.eNabizButtonSharedService.changeButtonVisible(false);
    }
    public async onShowCancelledReports(val: any): Promise<void> {
        if (val.value != null) {

            let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.patientExaminationDoctorFormNewViewModel._PatientExamination.Episode.Patient.ObjectID + '&subepisodeObjectID=' + this.patientExaminationDoctorFormNewViewModel._PatientExamination.SubEpisode + '&includedCancelledReports=' + val.value + '&currentActionReports=' + this.currentActionReports;
            let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);


            this.patientExaminationDoctorFormNewViewModel.PatientReportInfoList = res;
        }
    }
    public async onShowAllReports(val: any): Promise<void> {
        if (val.value != null) {
            this.currentActionReports = !(val.value);
            let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.patientExaminationDoctorFormNewViewModel._PatientExamination.Episode.Patient.ObjectID + '&subepisodeObjectID=' + this.patientExaminationDoctorFormNewViewModel._PatientExamination.SubEpisode + '&includedCancelledReports=false&currentActionReports=' + this.currentActionReports;
            let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);


            this.patientExaminationDoctorFormNewViewModel.PatientReportInfoList = res;
        }
    }
    onRowPreparedPatientReportInfoList(e: any): void {
        if (e.rowElement.firstItem() != undefined && e.rowType != 'header' && e.rowType != 'filter' && e.rowType != 'totalFooter' && e.rowElement.firstItem().length == 1) {
            if (e.data.CancelledReport == true) {
                e.rowElement.firstItem().Color = '#C78F8A';
                e.rowElement.firstItem().backgroundColor = '#380400';
            }
            else {
                e.rowElement.firstItem().style.backgroundColor = '#FFFFFF';
                e.rowElement.firstItem().style.color = '#000000';
            }
        }
    }


    public saveDispatchComponent: boolean = true;
    public dispatchComponentInfo: DynamicComponentInfo;
    public dispatchQueryParameters: QueryParams;

    protected getComponentInfo() {
        let componentInfoViewModel: DispatchToOtherHospitalComponentInfoViewModel = DispatchToOtherHospitalForm.getComponentInfoViewModel(this.patientExaminationDoctorFormNewViewModel._PatientExamination.ObjectID, this.patientExaminationDoctorFormNewViewModel._PatientExamination.Episode.ObjectID, this.patientExaminationDoctorFormNewViewModel._PatientExamination.Episode.Patient.ObjectID, "examination");
        this.dispatchQueryParameters = componentInfoViewModel.dispatchQueryParameters;
        this.dispatchComponentInfo = componentInfoViewModel.dispatchComponentInfo;

    }

    dispatchQueryResultLoaded(e: any) {
        DispatchToOtherHospitalForm.dispatchQueryResultLoaded(e);
    }

    /*Begin Sağlık Kurulu DİNAMİKL EK ALANLAR*/
    //HC Componentdan gelen  BaseHCExaminationDynamicObject den oluşan ek alanların gönderdiği View Modeli Yakalar
    public onSetBaseHCEComponentObjectViewModel(e: any): void {

        let that = this;
        if (this._ViewModel.BaseHCExaminationDynamicObjectFormViewModelList == null) {
            this._ViewModel.BaseHCExaminationDynamicObjectFormViewModelList = new Array<any>();
            this._ViewModel.BaseHCExaminationDynamicObjectFormViewModelList.push(e); // e BaseHCExaminationDynamicObjectFormViewModel tipinde bir ViewModel
        }
    }

    public onSetDisabledRatios(event: any): void {
        this.patientExaminationDoctorFormNewViewModel.HCExaminationDisabledRatios = event;
    }

    /*ENd DİNAMİK EK ALANLKAR*/


    public OpenHC_RelevanceReport(e: any) {

        if (this.patientExaminationDoctorFormNewViewModel.BaseHCExaminationDynamicObjectFormViewModelList.length > 0) {
            let episodeAction = this.patientExaminationDoctorFormNewViewModel.BaseHCExaminationDynamicObjectFormViewModelList[0]["_LowerExtremity"]["ObjectID"];
            if (episodeAction != null) {
                const objectIdParam = new GuidParam(episodeAction);
                let reportParameters: any = { 'TTOBJECTID': objectIdParam };
                this.reportService.showReportModal('HC_LowerExtremiteReport', reportParameters);
            }
        }
    }

    private openDynamicReportComponent(): Promise<ModalActionResult> {


        let data: DynamicReportParameters = {

            Code: 'ADLIVAKA',
            ReportParams: { ObjectID: 'fe70e128-95c7-4617-8974-5fe7f14e2a09', a: '', b: '' },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, new ActiveIDsModel(this._PatientExamination.ObjectID, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "... RAPORU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public openENabizDataSets() {
        let that = this;
        this.helpMenuService.showENabizDataSets(this._PatientExamination.ObjectID);
    }
    public anamnesisComposeComponentInfo: DynamicComponentInfo = new DynamicComponentInfo();

    createDynamicComposComponentVariables() {
        let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
        compInfo.ComponentName = 'AnamnesisForm';
        compInfo.ModuleName = 'AnamnezModule';
        compInfo.ModulePath = 'Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/AnamnezModule';
        compInfo.InputParam = this.patientExaminationDoctorFormNewViewModel.anamnesisFormViewModel;
        compInfo.objectID = null;
        this.anamnesisComposeComponentInfo = compInfo;

    }

    onContentReady(e) {
        if (this.isHealthCommittee) {
            let _index = e.component.option().items.findIndex(x => x.title == "Sağlık Kurulu");
            if (_index > 0)
                e.component.option("selectedIndex", _index);
        }
    }

    CheckScheduledRadiologyAppointments() {
        this.httpService.get<Array<RadiologyAppointmentInfo>>('api/PatientExaminationService/CheckScheduledRadiologyAppointments?EpisodeActionObjectID=' + this.patientExaminationDoctorFormNewViewModel._PatientExamination.ObjectID.toString()).then(response => {

            if (response.length > 0) {
                //Pop-up açılacak
                this.showRadiologyAppointmentPopUp = true;
                this._RadiologyAppointmentList = response as Array<RadiologyAppointmentInfo>;
            } else {
                this.showRadiologyAppointmentPopUp = false;
                this._RadiologyAppointmentList = new Array<RadiologyAppointmentInfo>();
            }


        }).catch(error => {

        });
    }
    CancelRadiologyAppointment() {
        this.showRadiologyAppointmentPopUp = false;
    }

    ApproveAppointment(data: RadiologyAppointmentInfo) {

        let that = this;
        let apiUrl: string = '/api/PatientExaminationService/ApproveRadiologyAppointment';

        this.httpService.post<any>(apiUrl, data).then(result => {

            TTVisual.InfoBox.Alert("Randevu Onaylandı.");

            this.CheckScheduledRadiologyAppointments();


        })
            .catch(error => {

            });


    }
}
