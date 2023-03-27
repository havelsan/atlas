//$770BBC3E

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Component, OnInit, OnDestroy, Input, Output, EventEmitter, ApplicationRef, ViewChild, Renderer2 } from '@angular/core';
import { ProcedureRequestViewModel, vmRequestedProcedure, vmPackageTemplateDefinition, vmPackageProcedure, vmPackageTemplateICD, EpisodeActionRequestedProcedureInfo, vmRequestedBloodBankProcedureInfo, vmAdditionalProcedureInfo, vmRequestedProcedureInfo, EpisodeActionFireRequestedProceduresResultInfo, SUTRuleViolateMessage, QueryInputDVO, AdditionalAppInfoInputDVO, vmPackageTemplate, TestResultQueryInputDVO, vmRequestedProcedureForm, UserOptionInputDVO, ProcedureUserObj, DailyProvisionSubscribeModel, SUTRuleResult } from "./ProcedureRequestViewModel";
import { TTUnboundForm } from 'NebulaClient/Visual/TTUnboundForm';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { InfoBox } from "NebulaClient/Visual/InfoBox";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { ProcedureRequestSharedService } from "./ProcedureRequestSharedService";
import { CommonService } from "ObjectClassService/CommonService";
import { EpisodeAction, ResPoliclinic, InpatientAdmission, ResClinic, InPatientPhysicianApplication, ResSection, NursingApplication, PatientExamination, Consultation, DentalExamination, HealthCommittee, HealthCommitteeExamination, EmergencyIntervention, InPatientTreatmentClinicApplication, RightLeftEnum, DiagnosisDefinition, DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { LaboratoryProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { RadiologyTest } from 'NebulaClient/Model/AtlasClientModel';
import { Subscription } from 'rxjs';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { ModalInfo, ModalActionResult } from "Fw/Models/ModalInfo";
import { IModalService } from "Fw/Services/IModalService";
import { MessageService } from 'Fw/Services/MessageService';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { TTUser } from 'NebulaClient/StorageManager/Security/TTUser';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { SubActionProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { UserTitleEnum } from 'NebulaClient/Model/AtlasClientModel';
import { TTObject } from 'NebulaClient/StorageManager/InstanceManagement/TTObject';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { PatientStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { DatePipe } from '@angular/common';
import { UserOptionType } from 'NebulaClient/Model/AtlasClientModel';
import { UserOption } from 'NebulaClient/Model/AtlasClientModel';
import { BaseAdditionalInfoFormViewModel } from './BaseAdditionalInfoFormViewModel';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { ActionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ShowBox } from 'NebulaClient/Visual/ShowBox';
import { ShowBoxTypeEnum } from "NebulaClient/Utils/Enums/ShowBoxTypeEnum";
import { DxDataGridComponent, DxSelectBoxComponent } from "devextreme-angular";
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Convert } from 'NebulaClient/Mscorlib/Convert';
import { RepeatedProceduresQueryInputDVO } from "./ProcedureRequestViewModel";
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { AsyncSubject } from "rxjs";
import List from "app/NebulaClient/System/Collections/List";
import { InputModelForDoctorList, DoctorModel, ClinicResultModel, ObjectIDForAI } from "./RequestedProceduresFormViewModel";
import { InputModelForQueries } from "../Kayit_Kabul_Modulu/PatientAdmissionFormViewModel";
import { LaboratoryWorkListSubItemDetailModel } from "../Laboratuar_Is_Listesi/LaboratoryWorkListFormViewModel";
import { ActiveIDsModel, ClickFunctionParams, ConsultationRequestParametersModel } from "app/Fw/Models/ParameterDefinitionModel";
import { IDestroyEvent } from 'app/Interfaces/IDestroyEvent';
import { DailyProvisionInputModel } from "./ProcedureRequestViewModel";
import { DynamicComponentInputParam } from "app/Fw/Models/DynamicComponentInputParam";
import { DailyInpatientInfoModel } from "../Tibbi_Surec_Evrensel_Modulu/EpisodeActionFormViewModel";
import { DynamicReportParameters } from "app/Fw/Components/Reporting/HvlDynamicReportComponent";
import { ProcedureList } from "app/TestPad/Models/TestComponentViewModel";
import { DiagnosisGridSharedService } from "../Tani_Modulu/DiagnosisGridSharedService";

declare var jQuery: any;

@Component({
    selector: 'requested-procedures-form',
    templateUrl: './RequestedProceduresForm.html',
    providers: [MessageService, DatePipe]
})
export class RequestedProceduresForm extends TTUnboundForm implements OnInit, OnDestroy {
    OnDestroy: EventEmitter<any> = new EventEmitter<any>();

    AdditionalApplication: TTVisual.ITTObjectListBox;
    ProcedureUserList: TTVisual.ITTObjectListBox;
    ProcedurePackageTemplate: TTVisual.ITTObjectListBox;
    btnAddPackage: TTVisual.ITTButton;
    txtPackageTemplateName: TTVisual.ITTTextBox;
    txtPackageTemplateObjectId: Guid;
    txtProcedureName: TTVisual.ITTTextBox;
    showPopup: boolean;
    addPackage: boolean;
    choosePackage: boolean;
    updatePackage: boolean;
    popupTitle: string;
    hiddenProcedureSearch: boolean;
    showPopupRequiredInfoForm: boolean = false;
    showPopupSUTRuleCheckResultsForm: boolean;
    ignoreSUTRuleCheck: boolean = false;
    popupTitleRequiredInfoForm: string;
    SUTRuleViolateMessages: Array<SUTRuleViolateMessage> = new Array<SUTRuleViolateMessage>();
    public ClinicAnemnesis: String;
    RequestedProcedures: Array<vmRequestedProcedure> = new Array<vmRequestedProcedure>();
    AddedProcedures: Array<vmRequestedProcedure> = new Array<vmRequestedProcedure>();
    showProcedureInstructionBtn: boolean = false;
    //chkListTodayProcedures: TTVisual.ITTCheckBox;
    chkIncludeCancelledProcedures: TTVisual.ITTCheckBox;
    chkOnlyProcedures: TTVisual.ITTCheckBox;
    chkOnlyTests: TTVisual.ITTCheckBox;
    chkGetAllTests: TTVisual.ITTCheckBox;
    public RequestedProceduresForRequiredInfoForm: Array<Guid> = new Array<Guid>();
    showPopupQuickProcedureEntry: boolean;
    showQuickProcedureEntryBtn: boolean = false;
    _TotalPrice: Currency = 0;
    //loadViewModel ile yuklenen SubEpisode altindaki tum hizmetleri tutan array. Mukerrer hizmet kontrolu icin gerekli
    PatientAllProcedures: Array<vmRequestedProcedure> = new Array<vmRequestedProcedure>();
    public showPanelTestResultPopup: boolean = false;
    public showMikrobiyolojiTestResultPopup: boolean = false;
    public mikroBiyolojiTestResultDesc:string ="";
    LaboratorySubProcedureList: Array<LaboratoryWorkListSubItemDetailModel>;

    public dailyApplicationControl: boolean = false;
    public operationControl: boolean = false;
    public dailyControl: boolean = false;
    MovedTransactions: TTVisual.TTTextBoxColumn;
    MovedDrugs: TTVisual.TTTextBoxColumn;
    public summaryEpicrisis: string = "";
    public birim: any;
    public vmDailyRequests: Array<vmRequestedProcedure> = new Array<vmRequestedProcedure>();
    public requestApp: any;
    public gunubirlikYatisKontrol: boolean = false;
    public yatisKontrol: boolean = false;

    public ignoreUserOptionForChecks: boolean = false;

    public triggerValueObservable: boolean;
    private triggerValueSubscription: Subscription;


    private operationControlObjectSubscription: Subscription;
    private dailyInputModelSubscription: Subscription;
    public requestedProcedureBoolObjectObservable: boolean;

    public controlAction: boolean;

    public controlVisibleOfColumns: boolean = false;
    loadingVisible: boolean = false;
    panelMessage: string = "İşlemler yükleniyor, lütfen bekleyiniz";

    public isRighLeftInfoNeed: boolean = false;
    public procedureName: string;
    public popupHeight: string;
    public showCloseButton: boolean = false;

    radioGroupItems = [
        { text: "Sağ", value: 0 },
        { text: "Sol", value: 1 }

    ];

    public rightLeftitemValue: string;
    public vmProceduresList: Array<vmRequestedProcedure> = new Array<vmRequestedProcedure>();

    //public subEpisode: SubEpisode = new SubEpisode();
    //@Output() RequestDate: EventEmitter<Date> = new EventEmitter<Date>();
    // @Output() DisableRequestForms: EventEmitter<boolean> = new EventEmitter<boolean>();

    @Output() OpenRequestTab: EventEmitter<boolean> = new EventEmitter<boolean>();
    @Input() GridDiagnosisGridList: Array<any> = new Array<any>();
    @ViewChild('hizmetGrid') _hizmetGrid: DxDataGridComponent;
    //@ViewChild('select') _selectBox: DxSelectBoxComponent;

    private _episodeAction: EpisodeAction;
    deleteControl: boolean;
    @Input() set EpisodeAction(value: EpisodeAction) {
        this._episodeAction = value;
        if (this._episodeAction != null && this._episodeAction.ObjectDefID != null) {
            if (this._episodeAction.ObjectDefID == PatientExamination.ObjectDefID) {
                let temp: PatientExamination = this._episodeAction as PatientExamination;
                if (temp.HCExaminationComponent != null) {
                    this.controlAction = false;
                }
                else
                    this.controlAction = true;

            }
            else if (this._episodeAction.ObjectDefID == DentalExamination.ObjectDefID
                || this._episodeAction.ObjectDefID == EmergencyIntervention.ObjectDefID) {

                this.controlAction = true;
            }
            else if (this._episodeAction.ObjectDefID == InPatientPhysicianApplication.ObjectDefID) {
                let temp: InPatientPhysicianApplication = this._episodeAction as InPatientPhysicianApplication;
                if ((temp.InPatientTreatmentClinicApp && temp.InPatientTreatmentClinicApp.IsDailyOperation == true) || temp.EmergencyIntervention != null) {
                    this.controlAction = true;
                }
                else
                    this.controlAction = false;
            }
            else if (this._episodeAction.ObjectDefID == NursingApplication.ObjectDefID) {
                let temp: NursingApplication = this._episodeAction as NursingApplication;
                if (temp.InPatientTreatmentClinicApp != null && temp.InPatientTreatmentClinicApp.IsDailyOperation == true) {
                    this.controlAction = true;
                }
                else
                    this.controlAction = false;
            }

            else
                this.controlAction = false;

            this.loadViewModel(false, this.ignoreUserOptionForChecks, this.ignoreUserOptionForChecks, !this.ignoreUserOptionForChecks);
        }
    }
    get EpisodeAction(): EpisodeAction {
        return this._episodeAction;
    }

    private _rowVisible: boolean = false;
    @Input() set RowVisible(value: boolean) {
        if (value != undefined)
            this._rowVisible = value;
    }
    get RowVisible(): boolean {
        return this._rowVisible;
    }

    private _isReadOnly: boolean = false;
    @Input() set IsReadOnly(value: boolean) {
        if (value != undefined)
            this._isReadOnly = value;
    }
    get IsReadOnly(): boolean {
        return this._isReadOnly;
    }

    public _gridList: Array<vmRequestedProcedure> = new Array<vmRequestedProcedure>();
    @Input() set GridList(value: Array<vmRequestedProcedure>) {
        this._gridList = value;

    }
    get GridList(): Array<vmRequestedProcedure> {
        return this._gridList;
    }

    private _showButton: Boolean = false;
    @Input() set ShowTahlilTetkikIstemButton(value: Boolean) {
        this._showButton = value;
    }
    
    //private _fireEpisodeActionRequestedProcedure: Boolean
    //@Input() set FireEpisodeActionRequestedProcedure(value: Boolean) {
    //    if (value == true) {
    //        this.fireRequestedProceduresActions(this.EpisodeAction);
    //    }
    //}
    //get FireEpisodeActionRequestedProcedure(): Boolean {
    //    return this._fireEpisodeActionRequestedProcedure;
    //}

    public ViewModel: ProcedureRequestViewModel = new ProcedureRequestViewModel();
    public RequestedProceduresForPackage: Array<vmPackageProcedure> = new Array<vmPackageProcedure>();
    public ICDListForPackage: Array<vmPackageTemplateICD> = new Array<vmPackageTemplateICD>();
    public get procedureRequestViewModel(): ProcedureRequestViewModel {
        return this.ViewModel;
    }
    PackageProcedureGrid: TTVisual.ITTGrid;
    ProcedureCode: TTVisual.ITTTextBoxColumn;
    ProcedureName: TTVisual.ITTTextBoxColumn;
    IsSelected: TTVisual.ITTCheckBoxColumn;
    public PackageProcedureColumns = [];

    PackageICDGrid: TTVisual.ITTGrid;
    DiagnoseCode: TTVisual.ITTTextBoxColumn;
    DiagnoseName: TTVisual.ITTTextBoxColumn;
    DiagnoseIsSelected: TTVisual.ITTCheckBoxColumn;
    public PackageICDListColumns = [];
    viewResultURL: string = "";
    RequestDateField: TTVisual.ITTDateTimePicker;
    labelRequestDate: TTVisual.ITTLabel;

    SubEpisodeOpeningDate: Date;
    SubEpisodeClosingDate: Date;
    ClosingDate: Date;


    private _procedureRequestFormResourceIDs: Array<Guid>;
    public MasterAction: EpisodeAction;


    private _physicianSuggestionsIsActive: Boolean;
    @Input() set PhysicianSuggestionsIsActive(value: Boolean) {
        this._physicianSuggestionsIsActive = value;
    }
    get PhysicianSuggestionsIsActive(): Boolean {
        if (this._physicianSuggestionsIsActive == null)
            this._physicianSuggestionsIsActive = false;
        return this._physicianSuggestionsIsActive;
    }

    public procedureUserArray: Array<ProcedureUserObj> = [];




    public ProcedureUserCache: any;
    public ProcedureListColumns = [];

    createProcedureListColumns() {
        this.ProcedureListColumns = [

            {
                "caption": i18n("M16694", "İstem Tarihi"),
                dataField: "RequestDate",
                width: '165',
                dataType: "datetime",
                format: "dd/MM/yyyy HH:mm",
                allowSorting: true,
                allowEditing: false,
                cellTemplate: "requestdateTemplate",

                fixed: true
            },
            {
                "caption": "Kabul No",
                dataField: "ProtocolNo",
                width: 80,
                allowSorting: true,
                allowEditing: false,
                fixed: true,
                visible: this.controlAction
            },
            {
                caption: i18n("M11855", "Eklendiği İşlem"),
                dataField: "ActionType",
                cellTemplate: "ActionTypeCellTemplate",
                width: 120,
                allowSorting: true,
                allowEditing: false,
                fixed: true,
                visible: this.controlAction

            },
            {
                "caption": i18n("M16860", "İşlem Kodu"),
                dataField: "ProcedureCode",
                width: 80,
                allowSorting: true,
                allowEditing: false,
                cellTemplate: "ExternalRequestCellTemplate",
                fixed: true
            },
            {
                "caption": i18n("M16821", "İşlem Adı"),
                dataField: "ProcedureName",
                width: 250,
                allowSorting: true,
                allowEditing: false,
                cellTemplate: "PriorityCellTemplate",
                fixed: true
            },
            {
                "caption": i18n("M10505", "Adet"),
                dataField: "Amount",
                width: 60,
                allowSorting: true,
                allowEditing: false,
                //cellTemplate: "amountTemplate",
                fixed: true
            },
            {
                "caption": i18n("M16837", "İşlem Durum"),
                dataField: "ActionStatus",
                width: 100,
                allowSorting: true,
                allowEditing: false,
                fixed: true
            },
            {
                "caption": i18n("M22091", "Sonuç Değer"),
                dataField: "ResultValue",
                width: 150,
                allowSorting: true,
                allowEditing: false,
                fixed: true
            },
            {
                "caption": i18n("M22078", "Sonuç"),
                dataField: "ProcedureResultLink",
                width: 60,
                allowSorting: true,
                allowEditing: false,
                cellTemplate: "linkCellTemplateResult",
                fixed: true
            },
            {
                "caption": "Rapor",
                dataField: "ProcedureReportLink",
                width: 60,
                allowSorting: true,
                allowEditing: false,
                cellTemplate: "linkCellTemplateReport",
                fixed: true
            },
            {
                "caption": i18n("M16695", "İstem Uygulayan"),
                dataField: "ProcedureUserId",
                width: 150,
                allowSorting: false,

                lookup: {
                    dataSource: this.procedureUserArray,
                    valueExpr: 'ObjectID',
                    displayExpr: 'Name'

                }
            },
            {
                "caption": i18n("M16696", "İstem Yapan"),
                dataField: "RequestedByResUser",
                width: "%100",
                allowEditing: false,
                allowSorting: true
            }, 
            // {
            //     "caption": "Birim Fiyat",
            //     dataField: "UnitPrice",
            //     width: "100",
            //     allowEditing: false,
            //     allowSorting: true
            // },
            {
                "caption": "",
                width: 40,
                allowSorting: true,
                allowEditing: false,
                cellTemplate: "saveCellTemplate"

            }

        ];
    }

    public PanelTestProcedureColumns = [
        {
            "caption": i18n("M16860", "İşlem Kodu"),
            dataField: "TestCode",
            width: 80,
            allowSorting: true
        },
        {
            "caption": i18n("M16821", "İşlem Adı"),
            dataField: "LaboratoryTestName",
            width: 100,
            allowSorting: true
        },
        {
            "caption": "Barkod",
            dataField: "BarcodeID",
            width: 110,
            allowSorting: true
        },
        {
            "caption": i18n("M19543", "Numune No"),
            dataField: "SpecimenID",
            width: 110,
            allowSorting: true
        },
        {
            "caption": i18n("M22078", "Sonuç"),
            dataField: "Result",
            width: 60,
            allowSorting: true
        },
        {
            "caption": "Birim",
            dataField: "Unit",
            width: 60,
            allowSorting: true
        },
        {
            "caption": i18n("M21010", "Referans Aralığı"),
            dataField: "Reference",
            width: 100,
            allowSorting: true
        }

    ];




    public procedureRequestFormDetailSubscribe: Subscription;
    public procedureRequestFormDetailIDSubscribe: Subscription;
    public emergencyCheckRequestedProceduresSubscribe: Subscription;
    public hasProcedureUserRole: boolean = false;
    public ProtocolNo: string;

    constructor(private httpService: NeHttpService, private detector: ApplicationRef, private procedureRequestSharedService: ProcedureRequestSharedService,private diagnosisGridSharedService:DiagnosisGridSharedService, protected modalService: IModalService, protected messageService: MessageService, private reportService: AtlasReportService, private objectContextService: ObjectContextService, protected activeUserService: IActiveUserService, private datePipe: DatePipe, protected helpMenuService: HelpMenuService, private renderer: Renderer2) {
        super("", "");
        this.initSubscribers();
        SystemParameterService.GetParameterValue('IGNOREUSEROPTIONFORCHECKS', 'TRUE').then(x => {
            this.ignoreUserOptionForChecks = (x == 'TRUE');
        }
        ).catch(error => {
            this.messageService.showError(error);
        });
    }

    async ngOnInit() {
        this.initFormControls();
        this.initSubscribers();

        let input: InputModelForQueries = new InputModelForQueries();
        this.FillDataSourceForAdditionalApplication(input);
        this.FillDataSourceForPackage(input);
        this.chkOnlyProcedures.Value = true;
        this.chkOnlyTests.Value = true;
    }

    async ngAfterViewInit() {
        this.ControlTriggerValue();
        this.ControlTreatmentMaterials();
    }



    ngOnDestroy() {

        this.procedureRequestSharedService.ProcedureRequestFormDetailParam = null;
        this.procedureRequestSharedService.ProcedureRequestFormDetailIDParam = null;
        this.procedureRequestSharedService.EmergencyCheckRequestedProceduresParam = null;
        this.procedureRequestSharedService.SelectedPackageProceduresFormDetailIDParam = new Array<Guid>();

        if (this.procedureRequestFormDetailSubscribe != null) {
            this.procedureRequestFormDetailSubscribe.unsubscribe();
            this.procedureRequestFormDetailSubscribe = null;
        }

        if (this.procedureRequestFormDetailIDSubscribe != null) {
            this.procedureRequestFormDetailIDSubscribe.unsubscribe();
            this.procedureRequestFormDetailIDSubscribe = null;
        }

        if (this.emergencyCheckRequestedProceduresSubscribe != null) {
            this.emergencyCheckRequestedProceduresSubscribe.unsubscribe();
            this.emergencyCheckRequestedProceduresSubscribe = null;
        }
        if (this.operationControlObjectSubscription != null) {
            this.operationControlObjectSubscription.unsubscribe();
            this.operationControlObjectSubscription = null;
        }
        if (this.dailyInputModelSubscription != null) {
            this.dailyInputModelSubscription.unsubscribe();
            this.dailyInputModelSubscription = null;
        }
        if (this.triggerValueSubscription != null) {
            this.triggerValueSubscription.unsubscribe();
            this.triggerValueSubscription = null;
        }
        this.OnDestroy.emit();
    }

    reloadProceduresList(): void {
        this.loadViewModel(false, this.ignoreUserOptionForChecks, this.ignoreUserOptionForChecks, !this.ignoreUserOptionForChecks);
    }

    onContextMenuPreparing(e: any): void {
        let that = this;
        if (e.row !== undefined && e.row !== null) {
            if (e.row.rowType === 'data') {
                e.items = [{
                    text: "Sık Kullanılanlara Ekle",
                    disabled: false,
                    onItemClick: function () {

                        if (e.row.data.isAddedToMostUsedRequest == true)
                            that.AddMostUsed(e.row.data);
                        else
                            TTVisual.InfoBox.Alert(i18n("M30812", "Seçtiğiniz hizmet Sık Kullanılanlar Paneline eklemek için uygun değildir!"));
                    }
                }
                ];
            }
        }
    }

    public ControlTriggerValue() {
        let that = this;
        this.triggerValueSubscription = this.httpService.requestedProcedureSharedService.triggerValueObservable.subscribe(
            result => {
                if (result === true) {
                    that.httpService.requestedProcedureSharedService.sendDailyOperationControlBooleanObject(that.operationControl);

                    let subscribeModel: DailyProvisionSubscribeModel = new DailyProvisionSubscribeModel();

                    subscribeModel.DailyInpatientControl = that.gunubirlikYatisKontrol;
                    subscribeModel.Epicrisis = that.summaryEpicrisis;
                    subscribeModel.TreatmentClinic = that.birim;
                    subscribeModel.NormalInpatientControl = that.yatisKontrol;
                    
                    that.httpService.requestedProcedureSharedService.sendDailyOperationInputModel(subscribeModel);
                }

            }
        );
    }

    public nullControl: boolean = false;
    public async RightLeftInformationClick(e: any) {
        this.nullControl = false;
        for (let proc of this.vmProceduresList) {
            if (proc.RightLeftInfoNeeded == true && (proc.RightLeftInformation == undefined || proc.RightLeftInformation == null)) {
                this.nullControl = true;
            }
        }

        if (this.nullControl == true) {
            this.messageService.showInfo("Sağ / Sol seçimi yapınız");
        }

        else {
            if ( this.vmProceduresList[0].SubActionProcedureObjectId != null) {
                try {
                    let apiUrl: string = 'api/ProcedureRequestService/UpdateRightLeftInformation?SubactionProcedureObjectId=' + this.vmProceduresList[0].SubActionProcedureObjectId.toString() + '&newValue=' + this.vmProceduresList[0].RightLeftInformation;
                    let result = await this.httpService.get<boolean>(apiUrl);
                    if (result == true)
                        this.messageService.showInfo("Seçim güncellendi");
                }
                catch (ex) {
                    ServiceLocator.MessageService.showError(ex);
                }
            }
            this.vmProceduresList.Clear();
            this.isRighLeftInfoNeed = false;
        }
    }

    async AddMostUsed(data) {
        let param: AddMostUsedProcedureRequestFormParam = new AddMostUsedProcedureRequestFormParam();
        param.ProcedureObjectID = data.ProcedureObjectId;
        if (data.isAdditionalApplication == false)
            param.ObservationUnit = data.MasterResourceObjectId;

        let apiUrl: string = '/api/ProcedureRequestService/AddMostUsedProcedureRequestForm';
        await this.httpService.post<any>(apiUrl, param).then(
            x => {
                this.messageService.showInfo(i18n("M30813", "Hizmet/Tetkik, Sık Kullanılanlar Paneline eklendi."));
                this.procedureRequestSharedService.refreshMostUsedForm(true);
            }
        ).catch(error => {
            this.messageService.showError(error);
        });
    }



    async  initSubscribers() {
        if (this.procedureRequestFormDetailSubscribe == null) {
            this.procedureRequestFormDetailSubscribe = this.procedureRequestSharedService.ProcedureRequestFormDetail.subscribe(
                requestedProcedure => {
                    if (this.procedureRequestSharedService.ProcedureRequestFormDetailParam != null) {
                        if (this.procedureRequestSharedService.ProcedureRequestFormDetailParam.ExternalProcedureId == null || this.procedureRequestSharedService.ProcedureRequestFormDetailParam.ExternalProcedureId == "") {
                            // useSelectedDataByUser = true iken ProcedureResUser,ProcedureUserId,RequestDate bilgileri RequestedProcedureFormdan seçilen değerler olarak alır
                            if (this.procedureRequestSharedService.ProcedureRequestFormDetailParam.useSelectedDataByUser == true) {
                                let selectedDoctor = <ResUser>this.ViewModel._selectedDoctorValue;
                                if (this.ViewModel._selectedDoctorValue != null) {
                                    this.procedureRequestSharedService.ProcedureRequestFormDetailParam.ProcedureResUser = selectedDoctor.Name.toString();
                                    this.procedureRequestSharedService.ProcedureRequestFormDetailParam.ProcedureUserId = selectedDoctor.ObjectID;
                                }
                                this.procedureRequestSharedService.ProcedureRequestFormDetailParam.RequestDate = this.ViewModel.requestDate;
                            }

                            //Secilen tetkigin AlertMessage i varsa kullanıcıya sorulacak
                            if (requestedProcedure.AlertMessage != null) {
                                this.showAlertMessageAndContinue(requestedProcedure.AlertMessage, requestedProcedure).then(
                                    retValue => {

                                        if (retValue == true) {
                                            let isExist: boolean = false;
                                            if (this.EpisodeAction != null) {
                                                this.isRepeatedRequestExists(requestedProcedure.ProcedureObjectId, requestedProcedure.Id, requestedProcedure.ProcedureType, this.EpisodeAction.Episode.PatientStatus).then(
                                                    x => {
                                                        isExist = x;
                                                        if (isExist == false) {
                                                            this.RequestedProcedures.unshift(this.procedureRequestSharedService.ProcedureRequestFormDetailParam);
                                                            this.AddedProcedures.unshift(this.procedureRequestSharedService.ProcedureRequestFormDetailParam);
                                                            this.openRightLeftPopUp(this.procedureRequestSharedService.ProcedureRequestFormDetailParam);
                                                            if (this.procedureRequestSharedService.ProcedureRequestFormDetailParam.hasProcedureInstruction == true)
                                                                this.showProcedureInstructionBtn = true;
                                                        }
                                                    });
                                            } else {
                                                this.RequestedProcedures.unshift(this.procedureRequestSharedService.ProcedureRequestFormDetailParam);
                                                this.AddedProcedures.unshift(this.procedureRequestSharedService.ProcedureRequestFormDetailParam);
                                                this.openRightLeftPopUp(this.procedureRequestSharedService.ProcedureRequestFormDetailParam);
                                                this._gridList = this.RequestedProcedures;
                                                this.RetGridList.emit(this.RequestedProcedures);
                                                if (this.procedureRequestSharedService.ProcedureRequestFormDetailParam.hasProcedureInstruction == true)
                                                    this.showProcedureInstructionBtn = true;
                                            }


                                        }
                                    });
                            }
                            else {

                                let isExist: boolean = false;
                                if (this.EpisodeAction != null) {
                                    this.isRepeatedRequestExists(requestedProcedure.ProcedureObjectId, requestedProcedure.Id, requestedProcedure.ProcedureType, this.EpisodeAction.Episode.PatientStatus).then(
                                        x => {
                                            isExist = x;
                                            if (isExist == false) {
                                                this.RequestedProcedures.unshift(this.procedureRequestSharedService.ProcedureRequestFormDetailParam);
                                                this.AddedProcedures.unshift(this.procedureRequestSharedService.ProcedureRequestFormDetailParam);
                                                this.openRightLeftPopUp(this.procedureRequestSharedService.ProcedureRequestFormDetailParam);
                                                if (this.procedureRequestSharedService.ProcedureRequestFormDetailParam.hasProcedureInstruction == true)
                                                    this.showProcedureInstructionBtn = true;
                                            }
                                        });
                                } else {
                                    this.RequestedProcedures.unshift(this.procedureRequestSharedService.ProcedureRequestFormDetailParam);
                                    this.AddedProcedures.unshift(this.procedureRequestSharedService.ProcedureRequestFormDetailParam);
                                    this.openRightLeftPopUp(this.procedureRequestSharedService.ProcedureRequestFormDetailParam);
                                    this._gridList = this.RequestedProcedures;
                                    this.RetGridList.emit(this.RequestedProcedures);
                                    if (this.procedureRequestSharedService.ProcedureRequestFormDetailParam.hasProcedureInstruction == true)
                                        this.showProcedureInstructionBtn = true;
                                }

                            }
                        }
                        else {
                            //KAN BANKASI ISTEM ICIN YAPILMISTI, KULLANILMIYOR
                            let isExists: boolean = false;

                            for (let req of this.RequestedProcedures) {
                                if (req.ProcedureType == "BLOODREQ") {
                                    if (req.ExternalProcedureId != null && req.ExternalProcedureId != "") {
                                        if (req.ExternalProcedureId == this.procedureRequestSharedService.ProcedureRequestFormDetailParam.ExternalProcedureId) {
                                            isExists = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (isExists == false) {
                                this.RequestedProcedures.unshift(this.procedureRequestSharedService.ProcedureRequestFormDetailParam);
                                this.AddedProcedures.unshift(this.procedureRequestSharedService.ProcedureRequestFormDetailParam);
                                if (this.procedureRequestSharedService.ProcedureRequestFormDetailParam.hasProcedureInstruction == true)
                                    this.showProcedureInstructionBtn = true;
                            }
                        }
                    }
                });
        }

        if (this.procedureRequestFormDetailIDSubscribe == null) {
            this.procedureRequestFormDetailIDSubscribe = this.procedureRequestSharedService.ProcedureRequestFormDetailID.subscribe(
                detailId => {
                    if (this.procedureRequestSharedService.ProcedureRequestFormDetailIDParam != null) {
                        let delVmRequestedProcedure: vmRequestedProcedure;
                        for (let req of this.RequestedProcedures) {
                            // Istem panelinden yeni istenen tetkikler icin hizmet gridinden cikarma kodu calismali.
                            if (req.SubActionProcedureObjectId == undefined || req.SubActionProcedureObjectId === null) {
                                if (req.Id.toString() === this.procedureRequestSharedService.ProcedureRequestFormDetailIDParam.toString()) {
                                    delVmRequestedProcedure = req;
                                    break;
                                }
                            }
                        }

                        let index = this.RequestedProcedures.indexOf(delVmRequestedProcedure, 0);
                        if (index > -1) {
                            this.RequestedProcedures.splice(index, 1);
                        }

                        for (let req of this.AddedProcedures) {
                            if (req.Id.toString() === this.procedureRequestSharedService.ProcedureRequestFormDetailIDParam.toString()) {
                                delVmRequestedProcedure = req;
                                break;
                            }
                        }
                        index = this.AddedProcedures.indexOf(delVmRequestedProcedure, 0);
                        if (index > -1) {
                            this.AddedProcedures.splice(index, 1);
                        }
                    }
                }
            );
        }
        if (this.emergencyCheckRequestedProceduresSubscribe == null) {
            this.emergencyCheckRequestedProceduresSubscribe = this.procedureRequestSharedService.EmergencyCheckRequestedProcedures.subscribe(
                emergencyChecked => {
                    if (this.procedureRequestSharedService.EmergencyCheckRequestedProceduresParam != null) {
                        for (let req of this.RequestedProcedures) {
                            if (req.SubActionProcedureObjectId === null)
                                req.isEmergency = this.procedureRequestSharedService.EmergencyCheckRequestedProceduresParam;
                        }
                        for (let req of this.AddedProcedures) {
                            req.isEmergency = this.procedureRequestSharedService.EmergencyCheckRequestedProceduresParam;
                        }
                    }
                }
            );
        }

    }


    public initFormControls(): void {
        this.AdditionalApplication = new TTVisual.TTObjectListBox();
        this.AdditionalApplication.ListDefName = "AdditionalApplicationListDefinition";
        this.AdditionalApplication.Name = "AdditionalApplication";
        this.AdditionalApplication.AutoCompleteDialogWidth = "50%";

        this.ProcedureUserList = new TTVisual.TTObjectListBox();
        this.ProcedureUserList.ListDefName = "DoctorListDefinition";
        this.ProcedureUserList.Name = "ProcedureUserList";

        this.ProcedurePackageTemplate = new TTVisual.TTObjectListBox();
        this.ProcedurePackageTemplate.ListDefName = "PackageTemplateListDefinition";
        this.ProcedurePackageTemplate.Name = "ProcedurePackageTemplate";

        this.btnAddPackage = new TTVisual.TTButton();
        this.btnAddPackage.Text = i18n("M20171", "Paket Oluştur");
        this.btnAddPackage.Name = "btnAddPackage";

        this.txtPackageTemplateName = new TTVisual.TTTextBox();
        this.txtPackageTemplateName.Name = "txtPackageTemplateName";
        this.txtPackageTemplateName.Text = "";

        //paket icerigindeki hizmet gridi
        this.ProcedureCode = new TTVisual.TTTextBoxColumn();
        this.ProcedureCode.DataMember = "ProcedureCode";
        this.ProcedureCode.DisplayIndex = 1;
        this.ProcedureCode.HeaderText = i18n("M15894", "Hizmet Kodu");
        this.ProcedureCode.Name = "ProcedureCode";
        this.ProcedureCode.ReadOnly = true;
        this.ProcedureCode.Width = 100;

        this.ProcedureName = new TTVisual.TTTextBoxColumn();
        this.ProcedureName.DataMember = "ProcedureName";
        this.ProcedureName.DisplayIndex = 2;
        this.ProcedureName.HeaderText = i18n("M15821", "Hizmet Adı");
        this.ProcedureName.Name = "ProcedureName";
        this.ProcedureName.ReadOnly = true;
        this.ProcedureName.Width = 360;

        this.IsSelected = new TTVisual.TTCheckBoxColumn();
        this.IsSelected.DataMember = "isSelected";
        this.IsSelected.DisplayIndex = 3;
        this.IsSelected.HeaderText = i18n("M21507", "Seç");
        this.IsSelected.Name = "IsSelected";
        this.IsSelected.Width = 80;

        this.PackageProcedureGrid = new TTVisual.TTGrid();
        this.PackageProcedureGrid.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PackageProcedureGrid.Text = i18n("M15930", "Hizmet ve Tetkik");
        this.PackageProcedureGrid.Name = "PackageProcedureGrid";
        this.PackageProcedureGrid.TabIndex = 1;
        this.PackageProcedureColumns = [this.ProcedureCode, this.ProcedureName, this.IsSelected];


        //paket icerigindeki tani gridi
        this.DiagnoseCode = new TTVisual.TTTextBoxColumn();
        this.DiagnoseCode.DataMember = "DiagnoseCode";
        this.DiagnoseCode.DisplayIndex = 1;
        this.DiagnoseCode.HeaderText = i18n("M22763", "Tanı Kodu");
        this.DiagnoseCode.Name = "DiagnoseCode";
        this.DiagnoseCode.ReadOnly = true;
        this.DiagnoseCode.Width = 100;

        this.DiagnoseName = new TTVisual.TTTextBoxColumn();
        this.DiagnoseName.DataMember = "DiagnoseName";
        this.DiagnoseName.DisplayIndex = 2;
        this.DiagnoseName.HeaderText = i18n("M22738", "Tanı Adı");
        this.DiagnoseName.Name = "DiagnoseName";
        this.DiagnoseName.ReadOnly = true;
        this.DiagnoseName.Width = 360;

        this.DiagnoseIsSelected = new TTVisual.TTCheckBoxColumn();
        this.DiagnoseIsSelected.DataMember = "isSelected";
        this.DiagnoseIsSelected.DisplayIndex = 3;
        this.DiagnoseIsSelected.HeaderText = i18n("M21507", "Seç");
        this.DiagnoseIsSelected.Name = "IsSelected";
        this.DiagnoseIsSelected.Width = 80;

        this.PackageICDGrid = new TTVisual.TTGrid();
        this.PackageICDGrid.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PackageICDGrid.Text = i18n("M22736", "Tanı");
        this.PackageICDGrid.Name = "PackageICDGrid";
        this.PackageICDGrid.TabIndex = 1;

        this.PackageICDListColumns = [this.DiagnoseCode, this.DiagnoseName, this.DiagnoseIsSelected];

        this.labelRequestDate = new TTVisual.TTLabel();
        this.labelRequestDate.Text = i18n("M16694", "İstem Tarihi");
        this.labelRequestDate.Name = "labelRequestDate";
        this.labelRequestDate.TabIndex = 15;

        this.RequestDateField = new TTVisual.TTDateTimePicker();
        this.RequestDateField.Format = DateTimePickerFormat.Long;
        this.RequestDateField.Name = "ApplicationDate";
        this.RequestDateField.TabIndex = 14;

        //this.chkListTodayProcedures = new TTVisual.TTCheckBox();
        //this.chkListTodayProcedures.Value = false;
        //this.chkListTodayProcedures.Title = "Günün İşlemleri";
        //this.chkListTodayProcedures.Name = "chkListTodayProcedures";
        //this.chkListTodayProcedures.TabIndex = 80;

        this.chkIncludeCancelledProcedures = new TTVisual.TTCheckBox();
        //this.chkIncludeCancelledProcedures.Value = false;
        this.chkIncludeCancelledProcedures.Title = i18n("M16567", "İptaller Dahil");
        this.chkIncludeCancelledProcedures.Name = "chkIncludeCancelledProcedures";
        this.chkIncludeCancelledProcedures.TabIndex = 80;

        this.chkOnlyProcedures = new TTVisual.TTCheckBox();
        //this.chkOnlyProcedures.Value = true;
        this.chkOnlyProcedures.Title = i18n("M15818", "Hizmet");
        this.chkOnlyProcedures.Name = "chkOnlyProcedures";
        this.chkOnlyProcedures.TabIndex = 80;

        this.chkOnlyTests = new TTVisual.TTCheckBox();
        //this.chkOnlyTests.Value = true;
        this.chkOnlyTests.Title = i18n("M23295", "Tetkik");
        this.chkOnlyTests.Name = "chkOnlyProcedures";
        this.chkOnlyTests.TabIndex = 80;


        this.chkGetAllTests = new TTVisual.TTCheckBox();
        this.chkGetAllTests.Title = i18n("M23653", "Tümünü Getir");
        this.chkGetAllTests.Name = "chkGetAllTests";
        this.chkGetAllTests.Value = false;
        this.chkGetAllTests.TabIndex = 80;


        this.Controls = [this.labelRequestDate, this.RequestDateField];
    }


    async additionalApplicationProcedureUserSelected(data: any) {
        if (data.selectedItem != null) {

            if ((data.selectedItem.Title === UserTitleEnum.UzmanOgr) ||
                (data.selectedItem.Title === UserTitleEnum.DoktoraOgr) ||
                (data.selectedItem.Title === UserTitleEnum.YanDalUzmanOgr) ||
                (data.selectedItem.Title === UserTitleEnum.YLisansUzmanOgr) ||
                (data.selectedItem.Title === null)) {
                TTVisual.InfoBox.Alert(i18n("M16700", "İstemi Uygulayan Doktor Alanı için Uzman Hekim Seçmeniz Gerekmektedir!"));
                this.ViewModel._selectedDoctorValue = null;
            }
            else {
                this.ViewModel._selectedDoctorValue = data.selectedItem;
                if (this.ViewModel._selectedDoctorValue != null && this.ViewModel.requestDate != null) {

                    let a = await CommonService.PersonelIzinKontrol(data.selectedItem.ObjectID, this.ViewModel.requestDate);
                    if (a) {
                        this.messageService.showInfo(data.selectedItem.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                        setTimeout(() => {
                            this.ViewModel._selectedDoctorValue = null;
                        }, 500);

                    }
                }

                if (this.ViewModel._selectedValue != null && this.ViewModel._selectedDoctorValue != null) {
                    this.addAdditionalApplication();
                }
            }
        }
        else
            this.ViewModel._selectedDoctorValue = null;

        if (this.ViewModel._selectedDoctorValue != null)
            this.procedureRequestSharedService.onProcedureByUserChange(data.selectedItem.ObjectID);
        else
            this.procedureRequestSharedService.onProcedureByUserChange(null);
    }

    public firstAdded: vmRequestedProcedure;
    async addAdditionalApplication() {


        let that = this;
        let inputDVO = new AdditionalAppInfoInputDVO();
        inputDVO.EpisodeActionObjectId = that.EpisodeAction.ObjectID.toString();
        inputDVO.ProcedureDefObjectId = (<TTObject>that.ViewModel._selectedValue).ObjectID.toString(); //data.ObjectID;

        let apiUrl: string = 'api/ProcedureRequestService/GetProcedureRequestInfo';
        await this.httpService.post<vmRequestedProcedure>(apiUrl, inputDVO, vmRequestedProcedure).then(result => {
            let vmRequest: vmRequestedProcedure = new vmRequestedProcedure();

            let inPatientPhyApp: InPatientPhysicianApplication = this._episodeAction as InPatientPhysicianApplication;
            if (result.DailyMedulaProvisionNecessity) {
                this.ViewModel.countForDailyOperations += 1;
                if (this.ViewModel.countForDailyOperations == 1
                    && (!(this._episodeAction.ObjectDefID.toString().Equals(InPatientPhysicianApplication.ObjectDefID.id)) || ((this._episodeAction.ObjectDefID.toString().Equals(InPatientPhysicianApplication.ObjectDefID.id)) && inPatientPhyApp.InPatientTreatmentClinicApp == null && inPatientPhyApp.EmergencyIntervention != null))
                    && !(this._episodeAction.ObjectDefID.toString().Equals(NursingApplication.ObjectDefID.id))
                    && this.gunubirlikYatisKontrol == false
                    && this.yatisKontrol == false) {
                    //         if (this.ViewModel.countForDailyOperations == 1 && !(this._episodeAction.ObjectDefID.toString().Equals(InPatientPhysicianApplication.ObjectDefID.id)) && !(this._episodeAction.ObjectDefID.toString().Equals(NursingApplication.ObjectDefID.id)) && this.gunubirlikYatisKontrol == false) {
                    //  this.operationControl = true;
                    this.ControlDailyOperation(true);
                    if (this.requestedProcedureBoolObjectObservable != true)
                        this.FillDataSource();
                }
            }
            vmRequest.Id = result.Id;
            vmRequest.ProcedureObjectId = result.Id;
            vmRequest.ProcedureCode = result.ProcedureCode;
            vmRequest.ProcedureName = result.ProcedureName;
            vmRequest.RequestDate = that.ViewModel.requestDate;
            vmRequest.RequestedByResUser = result.RequestedByResUser;
            vmRequest.RequestedById = result.RequestedById;
            vmRequest.DailyMedulaProvisionNecessity = result.DailyMedulaProvisionNecessity;


            if (vmRequest.DailyMedulaProvisionNecessity == true && this.procedureRequestViewModel.countForDailyOperations == 1) {
                this.firstAdded = vmRequest;
            }

            vmRequest.BaseAdditionalInfoFormGuids = new Array<Guid>();
            vmRequest.BaseAdditionalInfoFormViewModels = new Array<BaseAdditionalInfoFormViewModel>();

            if (that.ViewModel._selectedDoctorValue != null) {
                vmRequest.ProcedureResUser = (<ResUser>that.ViewModel._selectedDoctorValue).Name.toString();
                vmRequest.ProcedureUserId = (<ResUser>that.ViewModel._selectedDoctorValue).ObjectID;
            }
            else
                vmRequest.ProcedureUserId = result.RequestedById;

            vmRequest.RightLeftInfoNeeded = result.RightLeftInfoNeeded;

            if (vmRequest.RightLeftInfoNeeded == true) {

                this.vmProceduresList.push(vmRequest);
                this.procedureName = vmRequest.ProcedureName;
                this.popupHeight = "145px";
                this.showCloseButton = false;
                this.isRighLeftInfoNeed = true;
            }

            vmRequest.MasterResource = result.MasterResource;
            vmRequest.Amount = result.Amount;
            vmRequest.UnitPrice = result.UnitPrice;
            vmRequest.isAdditionalApplication = true;
            vmRequest.isAddedToMostUsedRequest = true;
            vmRequest.isProcedureReadOnly = false;
            vmRequest.isNew = true;
            vmRequest.isReportRequired = result.isReportRequired;
            vmRequest.isRISIntegrated = result.isRISIntegrated;
            vmRequest.isRadiologyProcedure = result.isRadiologyProcedure;
            vmRequest.isRISIntegrated = result.isRISIntegrated;
            vmRequest.isPathologyRequired = result.isPathologyRequired;
            vmRequest.isResultNeeded = result.isResultNeeded;
            vmRequest.isSkinPrickTest = result.isSkinPrickTest;
            let physiotherapyTestForm: string = "";
            let IsDescriptionNeeded: boolean = false;

            this.httpService.get<any>('api/ProcedureRequestService/GetRelatedPhysiotherapyTestForm?ProcedureCode=' + vmRequest.ProcedureCode).then(response => {
                physiotherapyTestForm = response;
                if (physiotherapyTestForm != "")
                    this.openPhysiotherapyTestsForm(physiotherapyTestForm, vmRequest, null);
            }).catch(error => {
                this.messageService.showError(error);
            });

            this.httpService.get<any>('api/ProcedureRequestService/IsDescriptionNeeded?ProcedureCode=' + vmRequest.ProcedureCode).then(response => {
                IsDescriptionNeeded = response;
                if (IsDescriptionNeeded)
                    this.openDescriptionForm(vmRequest, true);
            }).catch(error => {
                this.messageService.showError(error);
            });

            if (vmRequest.isReportRequired) {
                this.openAdditionalReportForm(vmRequest, null);
            }

            if (vmRequest.isResultNeeded) {
                this.openProcedureResultForm(vmRequest, null);
                //alert("sonuç değeri");
            }

            that.RequestedProcedures.unshift(vmRequest);
            that.AddedProcedures.unshift(vmRequest);
            this.RetGridList.emit(this.RequestedProcedures);
            window.setTimeout(t => {
                if (that.ViewModel._selectedValue === null)
                    that.ViewModel._selectedValue = undefined;
                else
                    that.ViewModel._selectedValue = null;
                that.detector.tick();
            }, 0);



        }).catch(err => {
            this.messageService.showError(err);
        });



    }

    btnShowAdditionalInfoForm(e, data) {

        if (data.key.isReportRequired) {
            if (data.key.BaseAdditionalInfoFormGuids.length > 0)
                this.openAdditionalReportForm(data.key, data.key.BaseAdditionalInfoFormGuids[0].toString());
            else
                this.openAdditionalReportForm(data.key, null);

        } else if (data.key.isResultNeeded) {
            if (data.key.BaseAdditionalInfoFormGuids.length > 0)
                this.openProcedureResultForm(data.key, data.key.BaseAdditionalInfoFormGuids[0].toString());
            else
                this.openProcedureResultForm(data.key, null);

        }
        else {

            let physiotherapyTestForm = "";
            this.httpService.get<any>('api/ProcedureRequestService/GetRelatedPhysiotherapyTestForm?ProcedureCode=' + data.key.ProcedureCode).then(response => {
                physiotherapyTestForm = response;
                if (physiotherapyTestForm != "") {
                    if (data.key.BaseAdditionalInfoFormGuids.length > 0)
                        this.openPhysiotherapyTestsForm(physiotherapyTestForm, data.key, data.key.BaseAdditionalInfoFormGuids[0].toString());
                    else
                        this.openPhysiotherapyTestsForm(physiotherapyTestForm, data.key, null);
                }
            }).catch(error => {
                this.messageService.showError(error);
            });
        }
    }

    RequestedByResUser: string;
    openPhysiotherapyTestsForm(physiotherapyTestForm: string, vmRequest: vmRequestedProcedure, objectID?: string) {
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();

            componentInfo.ComponentName = physiotherapyTestForm;
            componentInfo.ModuleName = "FizyoterapiModule";
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Fizyoterapi_Modulu/FizyoterapiModule';
            this.RequestedByResUser = vmRequest.RequestedByResUser;
            componentInfo.InputParam = this;
            if (objectID != null)
                componentInfo.objectID = objectID;

            let modalInfo: ModalInfo = new ModalInfo();
            //modalInfo.Title = ;
            modalInfo.Width = 700;
            modalInfo.Height = 500;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                let baseAdditionalInfoFormViewModel = inner.Param as BaseAdditionalInfoFormViewModel;
                if (baseAdditionalInfoFormViewModel != null && baseAdditionalInfoFormViewModel instanceof BaseViewModel) {
                    if (vmRequest.BaseAdditionalInfoFormViewModels == null) {
                        vmRequest.BaseAdditionalInfoFormViewModels = new Array<BaseAdditionalInfoFormViewModel>();
                    }
                    vmRequest.BaseAdditionalInfoFormViewModels.push(baseAdditionalInfoFormViewModel);
                }

                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    openDescriptionForm(vmRequest: vmRequestedProcedure, isNew: boolean) {
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();

            componentInfo.ComponentName = "BaseAdditionalApplicationDescriptionForm";
            componentInfo.ModuleName = "TibbiSurecEvrenselModule";
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/TibbiSurecEvrenselModule';

            componentInfo.InputParam = vmRequest.Description;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Lütfen Açıklama Giriniz!";
            modalInfo.Width = 700;
            modalInfo.Height = 280;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                if (inner.Result == 1) {
                    vmRequest.Description = inner.Param.toString();
                    if (!isNew) {
                        this.httpService.get<any>('api/ProcedureRequestService/UpdateBaseAdditionalApplicationDescription?SubActionProcedureObjectId=' + vmRequest.SubActionProcedureObjectId + '&Description=' + vmRequest.Description);
                    }
                }
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }
    async additionalApplicationSelected(data: any) {
        try {
            if (data.selectedItem != null) {

                let that = this;
                let noerror = true;
                if (this.gunubirlikYatisKontrol != true) {
                    if (that.ViewModel.requestDate == null || (this.SubEpisodeClosingDate != null && that.ViewModel.requestDate > this.SubEpisodeClosingDate)) {
                        TTVisual.InfoBox.Alert(i18n("M30107", "Lütfen Geçerli Bir İstem Tarihi seçiniz."));
                        noerror = false;
                    }
                }

                if (that.ViewModel._selectedDoctorValue == null) {
                    that.ViewModel._selectedValue = data.selectedItem;
                    TTVisual.InfoBox.Alert(i18n("M16701", "İstemi Uygulayan Doktor seçmeden hizmet ekleyemezsiniz!"));
                    noerror = false;
                }
                if (noerror) {

                    that.ViewModel._selectedValue = data.selectedItem;
                    that.addAdditionalApplication();
                }
            }
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }


    selectProcedure(data) {
        let a = 0;
        a++;
    }

    async addProcedureForSelectedPackage(data: any) {
        try {
            if (data != null) {
                let that = this;
                let inputDVO = new AdditionalAppInfoInputDVO();
                inputDVO.EpisodeActionObjectId = that.EpisodeAction.ObjectID.toString();
                inputDVO.ProcedureDefObjectId = data;

                let apiUrl: string = 'api/ProcedureRequestService/GetProcedureRequestInfo';
                let result = await this.httpService.post<vmRequestedProcedure>(apiUrl, inputDVO, vmRequestedProcedure);

                let vmRequest: vmRequestedProcedure = new vmRequestedProcedure();
                vmRequest.Id = result.Id;
                vmRequest.ProcedureObjectId = result.Id;
                vmRequest.ProcedureCode = result.ProcedureCode;
                vmRequest.ProcedureName = result.ProcedureName;
                vmRequest.RequestDate = that.ViewModel.requestDate;
                vmRequest.RequestedByResUser = result.RequestedByResUser;
                vmRequest.RequestedById = result.RequestedById;
                //    vmRequest.ProcedureUserId = result.RequestedById;
                if (this.ViewModel._selectedDoctorValue != null) {
                    vmRequest.ProcedureResUser = (<ResUser>this.ViewModel._selectedDoctorValue).Name.toString();
                    vmRequest.ProcedureUserId = (<ResUser>this.ViewModel._selectedDoctorValue).ObjectID;
                }
                else
                    vmRequest.ProcedureUserId = result.RequestedById;
                vmRequest.MasterResource = result.MasterResource;
                vmRequest.Amount = result.Amount;
                vmRequest.UnitPrice = result.UnitPrice;
                vmRequest.isAdditionalApplication = true;
                vmRequest.isAddedToMostUsedRequest = true;
                vmRequest.isProcedureReadOnly = false;
                vmRequest.isNew = true;
                vmRequest.isReportRequired = result.isReportRequired;
                vmRequest.isResultNeeded = result.isResultNeeded;
                vmRequest.isRISIntegrated = result.isRISIntegrated;
                vmRequest.isRadiologyProcedure = result.isRadiologyProcedure;
                vmRequest.isPathologyRequired = result.isPathologyRequired;
                vmRequest.isResultNeeded = result.isResultNeeded;
                vmRequest.isSkinPrickTest = result.isSkinPrickTest;
                vmRequest.RightLeftInfoNeeded = result.RightLeftInfoNeeded;

                if (vmRequest.RightLeftInfoNeeded == true) {

                    this.vmProceduresList.push(vmRequest);
                    this.procedureName = vmRequest.ProcedureName;
                }
                if (vmRequest.isResultNeeded) {
                    this.openProcedureResultForm(vmRequest, null);
                }


                that.RequestedProcedures.unshift(vmRequest);
                that.AddedProcedures.unshift(vmRequest);
                this.RetGridList.emit(this.RequestedProcedures);
                window.setTimeout(t => {
                    if (that.ViewModel._selectedValue === null)
                        that.ViewModel._selectedValue = undefined;
                    else
                        that.ViewModel._selectedValue = null;
                    that.detector.tick();
                }, 0);



            }
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }





    async onAmountChanged(data, row) {
        //Default deger 1 oldugu icin 1 den buyuk bir deger girildiginde kontroller calistirildi.
        if (data.value > 1) {
            let currentUser: ResUser = <ResUser>TTUser.CurrentUser.UserObject;
            let canBeChanged: boolean = false;

            if (row.data.RequestedById != null && row.data.RequestedById.toString() == currentUser.ObjectID.toString())
                canBeChanged = true;
            else {
                let hasRole: boolean = false;
                hasRole = await this.hasAmountUpdateRole();
                if (hasRole)
                    canBeChanged = true;
                else {
                    ServiceLocator.MessageService.showError(i18n("M16864", "İşlem miktarını değiştirme yetkiniz bulunmamaktadır!"));
                    window.setTimeout(() => {
                        row.text = "1";
                    });
                }
            }

            if (canBeChanged) {
                if (row != null && row.data != null) {
                    if (data.value != null)
                        if (data.value > 50)
                            this.messageService.showError(i18n("M10508", "Adet değeri 50 den büyük olamaz!"));
                        else if (data.value < 1)
                            this.messageService.showError(i18n("M10507", "Adet değeri 1 den küçük olamaz!"));
                        else {
                            row.data.Amount = data.value;
                            row.data.isAmountChanged = true;
                        }
                }
            }
        }
    }

    //isAmountReadOnly(row): boolean {
    //    debugger;
    //    if (row != null && row.data != null ) {
    //        if (row.data.SubActionProcedureObjectId == null) { //yeni eklenmiş hizmet ise amount değiştirilebilir
    //            if (row.data.isAdditionalApplication)
    //                return false;
    //        } else {
    //            if (row.data.isAdditionalApplication && this.hasAmountUpdateRole() && row.data.isAllowedToCancel)
    //                return false;

    //        }


    //    }
    //    return true;
    //}

    isProcedureUserEditable(row): boolean {
        if (row != null && row.data != null) {
            if (row.data.SubActionProcedureObjectId == null) {
                if (row.data.ProcedureType == 'PSYCH') {
                    return true;
                }
            }
        }
        return false;
    }

    public onEpicrisisChanged(event): void {
        if (event != null) {
            if (this.summaryEpicrisis != event) {
                this.summaryEpicrisis = event;
                //  this.ViewModel.DailyProvisionInputModel.Epicrisis = this.summaryEpicrisis;
            }
        }
    }


    public ClinicList = new List<ResClinic>();
    async FillDataSource() {

        let result: DailyInpatientInfoModel = new DailyInpatientInfoModel();
        let apiUrl: string = 'api/EpisodeActionService/ControlDailyInpatient?episodeActionID=' + this._episodeAction.ObjectID;
        result = await this.httpService.get<DailyInpatientInfoModel>(apiUrl);

        this.gunubirlikYatisKontrol = result.HasDailyInpatient;
        this.yatisKontrol = result.HasNormalInpatient;

        if (this.gunubirlikYatisKontrol == false && this.yatisKontrol == false) {
            try {
                let that = this;
                let body = "";
                let apiUrlForPASearchUrl: string;
                let headers = new Headers({ 'Content-Type': 'application/json' });
                apiUrlForPASearchUrl = '/api/RequestedProceduresService/FillClinicList';
                let index;

     /*           await this.httpService.post<any>(apiUrlForPASearchUrl, null).then(response => {
                    let result = response;
                    if (result) {
                        this.ClinicList = result;
                    }

                    this.dailyApplicationControl = true;
                }).catch(error => {
                    ServiceLocator.MessageService.showError("Hata : " + error);
                }); */

                let input: EpisodeAction = this._episodeAction;

                await this.httpService.post<any>(apiUrlForPASearchUrl, input).then(response => {
                    let result = response as ClinicResultModel;
                    if (result) {
                        that.ClinicList = result.ClinicList;
                        if(result.DefaultClinic != null)
                        that.birim = result.DefaultClinic.ObjectID;
                    }

                    this.dailyApplicationControl = true;

                }).catch(error => {
                    ServiceLocator.MessageService.showError("Hata : " + error);
                });
            }

            catch (ex) {
                ServiceLocator.MessageService.showError(ex);
            }
        }
        else if (this.gunubirlikYatisKontrol == true) {
            ServiceLocator.MessageService.showError("Hastanın aktif bir günübirlik yatışı bulunmaktadır hizmet aktif yatışa aktarılacaktır");
        }
    }


    async  onRowDeleted(data) {

        let jqDeferred = new AsyncSubject<boolean>(); // jQuery.Deferred();
        data.cancel = jqDeferred.toPromise();

        let currentUser: ResUser = <ResUser>TTUser.CurrentUser.UserObject;
        if (data.data.RequestedById != null && data.data.RequestedById.toString() == currentUser.ObjectID.toString()) {

            if (data.data.DailyMedulaProvisionNecessity) {
                this.ViewModel.countForDailyOperations -= 1;

                if (this.ViewModel.countForDailyOperations == 0)
                    this.ControlDailyOperation(false);
            }

            this.procedureRequestSharedService.onRowDeleted(data).then(
                cancelOK => {
                    if (cancelOK == true) {
                        //jqDeferred.resolve(false);
                        jqDeferred.next(false);
                        jqDeferred.complete();
                    }
                    else {
                        //jqDeferred.resolve(true);
                        jqDeferred.next(true);
                        jqDeferred.complete();
                    }
                });
        }
        else {
            let hasRole: boolean = false;
            hasRole = await this.hasRowDeleteRole();

            if (hasRole) {

                if (data.data.DailyMedulaProvisionNecessity) {
                    this.ViewModel.countForDailyOperations -= 1;

                    if (this.ViewModel.countForDailyOperations == 0)
                        this.ControlDailyOperation(false);
                }
                this.procedureRequestSharedService.onRowDeleted(data).then(
                    cancelOK => {
                        if (cancelOK == true) {
                            //jqDeferred.resolve(false);
                            jqDeferred.next(false);
                            jqDeferred.complete();
                        }
                        else {
                            //jqDeferred.resolve(true);
                            jqDeferred.next(true);
                            jqDeferred.complete();
                        }
                    });
            }
            else {
                ServiceLocator.MessageService.showError(i18n("M16917", "İşlemi silme yetkiniz bulunmamaktadır!"));
                //jqDeferred.resolve(true);
                jqDeferred.next(true);
                jqDeferred.complete();
            }

        }
        this.RetGridList.emit(data.data);


    }

    onRowInserted(data) {
        this.RetGridList.emit(data.data);
    }

    @Output() RetGridList: EventEmitter<any> = new EventEmitter<any>();
    openInNewTab(url) {
        if (url == null) {
            InfoBox.Alert(i18n("M12080", "Bu hizmetin sonucu bulunamadı!"));
        } else {
            let win = window.open(url, '_blank');
            win.focus();
        }
    }

    async selectReport(row) {

        if (row.data.ProcedureType == "MANIPULATION") {
            this.openManipulationReport(row.data.SubActionProcedureObjectId);
        } else if (row.data.ProcedureType == "PSYCH") {
            this.openPsychologyTestResultReport(row.data.SubActionProcedureObjectId);
        }
        else if (row.data.ProcedureType == "RAD") {
            this.openRadiologyReport(row.data.SubActionProcedureObjectId);
        }
        else if (row.data.ProcedureType == "NUCLEARTEST") {
            this.openNuclearMedicineReport(row.data.EpisodeActionObjectId);
        } else if (row.data.ProcedureType == "PAT") {
            this.openPathologyReport(row.data.SubActionProcedureObjectId);
        }
        else {
            this.openInNewTab(row.displayValue);

            if (row.data.isResultSeen == false) {
                let fullApiUrl: string = "api/ProcedureRequestService/SetIsResultSeenValue?subactionProcedureObjectID=" + row.data.SubActionProcedureObjectId.toString();
                let result = await this.httpService.get<boolean>(fullApiUrl);

                if (result == true)
                    row.data.isResultSeen = true;
                else
                    InfoBox.Alert(i18n("M15948", "Hizmetin Sonuç Görüntülendi özelliğinin set edilmesinde sorun oluştu!"));
            }
        }

    }

    async selectResultView(row) {

        let hasResultViewed: boolean = true;
        if (row.data.ProcedureType == "PAT") {
            this.openPathologyResult(row.data.SubActionProcedureObjectId);
        }
        else if (row.data.ProcedureType == "MANIPULATION") {
            this.openManipulationResult(row.data.SubActionProcedureObjectId);
        }
        else {
            let hasRole: boolean = false;
            hasRole = await this.hasRadiologyImageViewRole();
            if (hasRole)
                this.openInNewTab(row.displayValue);
            else {
                hasResultViewed = false;
                ServiceLocator.MessageService.showError(i18n("M12084", "Bu işlem için yetkiniz yoktur."));
            }
        }

        if (hasResultViewed == true) {
            if (row.data.isResultSeen == false) {
                let fullApiUrl: string = "api/ProcedureRequestService/SetIsResultSeenValue?subactionProcedureObjectID=" + row.data.SubActionProcedureObjectId.toString();
                let result = await this.httpService.get<boolean>(fullApiUrl);

                if (result == true)
                    row.data.isResultSeen = true;
                else
                    InfoBox.Alert(i18n("M15948", "Hizmetin Sonuç Görüntülendi özelliğinin set edilmesinde sorun oluştu!"));
            }
        }
    }

    async hasRadiologyImageViewRole(): Promise<boolean> {

        let fullApiUrl: string = 'api/ProcedureRequestService/hasRadiologyImageViewRole';
        let result = await this.httpService.get<boolean>(fullApiUrl);
        return result;

    }

    async hasRowDeleteRole(): Promise<boolean> {

        let fullApiUrl: string = 'api/ProcedureRequestService/hasProcedureDeleteRole';
        let result = await this.httpService.get<boolean>(fullApiUrl);
        return result;
    }

    async hasAmountUpdateRole(): Promise<boolean> {

        let fullApiUrl: string = 'api/ProcedureRequestService/hasProcedureAmountUpdateRole';
        let result = await this.httpService.get<boolean>(fullApiUrl);
        return result;
    }

    async loadViewModel(isCancelledIncluded?: boolean, listProceduresChecked?: boolean, listTestsChecked?: boolean, loadUserOption?: boolean) {
        let that = this;
        that.procedureUserArray = await this.GetProcedureUsers();
        this.createProcedureListColumns();
        this.operationControl = false;
        this._procedureRequestFormResourceIDs = new Array <Guid>();

        if (loadUserOption == true) {
            // Hizmet/Tetkik ve Iptaller Dahil filtrelemesi icin userOption dan checkboxlar yuklenecek, user optionda yoksa default herikisi de checkli gelecek
            // CheckBoxlar initial degerlere set ediliyor
            this.chkIncludeCancelledProcedures.Value = false;
            this.chkOnlyProcedures.Value = false;
            this.chkOnlyTests.Value = false;

            await this.getUserOptionForProcedureTestFilter().then(result => {
                let filterStr: string = result;
                if (filterStr != null) {
                    let filterArr: string[] = result.split(";");
                    if (filterArr != null && filterArr.length > 0) {
                        for (let filter of filterArr) {
                            if (filter == "P") //Hizmet
                            {
                                this.chkOnlyProcedures.Value = true;
                                listProceduresChecked = true;
                            }
                            if (filter == "T") //Tetkik
                            {
                                this.chkOnlyTests.Value = true;
                                listTestsChecked = true;
                            }
                            if (filter == "C") //İptaller Dahil
                            {
                                this.chkIncludeCancelledProcedures.Value = true;
                                isCancelledIncluded = true;
                            }
                        }
                    }
                    else {
                        this.chkOnlyProcedures.Value = true;
                        this.chkOnlyTests.Value = true;
                        this.chkIncludeCancelledProcedures.Value = false;
                        listProceduresChecked = true;
                        listTestsChecked = true;
                        isCancelledIncluded = false;
                    }
                }
                else {
                    this.chkOnlyProcedures.Value = true;
                    this.chkOnlyTests.Value = true;
                    this.chkIncludeCancelledProcedures.Value = false;
                    listProceduresChecked = true;
                    listTestsChecked = true;
                    isCancelledIncluded = false;
                }

            }).catch(err => {
                this.messageService.showError(err);
            });

        }


        //yatan hasta klinik doktor islemleri ve hemsirelik hizmetleri islemlerinde Hizli Islem Giris butonu gorunecek.
        if (this.EpisodeAction.ObjectDefID.toString() == "92accee7-68ce-44a6-8e02-8747e426104b" || this.EpisodeAction.ObjectDefID.toString() == "eb1d324d-9956-438f-8056-e4177421ad56")
            this.showQuickProcedureEntryBtn = true;

        try {
            let hasProcedureInstruction: boolean = false;
            this.RequestedProcedures = new Array<vmRequestedProcedure>();
            this.PatientAllProcedures = new Array<vmRequestedProcedure>();
            this.GridList = new Array<vmRequestedProcedure>();
            this.ProcedureUserList.SelectedObjectID = null;
            this.ViewModel._selectedDoctorValue = null;

            let that = this;

            if(typeof this.EpisodeAction.MasterAction === "string" && this.EpisodeAction.ActionType === ActionTypeEnum.Surgery){
                try {
                    let apiUrl: string = '/api/RequestedProceduresService/GetMasterAction?MasterActionID=' + this.EpisodeAction.MasterAction;
                    let result = await this.httpService.get<Guid>(apiUrl);
                    if (result) {
                        this._procedureRequestFormResourceIDs.push(result);
                    }
                }
                catch (ex) {
                    ServiceLocator.MessageService.showError(ex);
                }
                    
            }

                if (this.EpisodeAction.MasterResource != null) {
                if (typeof this.EpisodeAction.MasterResource === "string") {
                    that.ProcedureUserList.ListFilterExpression = 'USERRESOURCES.RESOURCE =\'' + this.EpisodeAction.MasterResource + '\'';
                    if(this.EpisodeAction.ActionType != ActionTypeEnum.Surgery)
                    this._procedureRequestFormResourceIDs.push(new Guid(this.EpisodeAction.MasterResource));
                }
                
                else {
                    that.ProcedureUserList.ListFilterExpression = 'USERRESOURCES.RESOURCE =\'' + this.EpisodeAction.MasterResource.ObjectID.toString() + '\'';
                    if(this.EpisodeAction.ActionType != ActionTypeEnum.Surgery)
                    this._procedureRequestFormResourceIDs.push(this.EpisodeAction.MasterResource.ObjectID);
                }
            }

            if (this.EpisodeAction.ProcedureDoctor != null) {
                if (typeof this.EpisodeAction.ProcedureDoctor === "string") {
                    this._procedureRequestFormResourceIDs.push(new Guid(this.EpisodeAction.ProcedureDoctor));
                }
                else {
                    let resourceId="";
                    if(typeof this.EpisodeAction.MasterResource === "string"){
                        resourceId = this.EpisodeAction.MasterResource;
                    }else {
                        resourceId = this.EpisodeAction.MasterResource.ObjectID.toString();
                    }
                    that.ProcedureUserList.ListFilterExpression = 'USERRESOURCES.RESOURCE =\'' + resourceId + '\'';
                    this._procedureRequestFormResourceIDs.push(this.EpisodeAction.ProcedureDoctor.ObjectID);
                }
            }

            let input: InputModelForDoctorList = new InputModelForDoctorList();
            input.filter = " AND this.ISACTIVE = 1";
            input.filter += " AND " + that.ProcedureUserList.ListFilterExpression;

            this.FillDataSources(input);

            let currentResUser: ResUser = new ResUser;
            currentResUser = <ResUser>that.activeUserService.ActiveUser.UserObject;

            if ((currentResUser.Title != UserTitleEnum.UzmanOgr) &&
                (currentResUser.Title != UserTitleEnum.DoktoraOgr) &&
                (currentResUser.Title != UserTitleEnum.YanDalUzmanOgr) &&
                (currentResUser.Title != UserTitleEnum.YLisansUzmanOgr) &&
                (currentResUser.Title != UserTitleEnum.Unused) &&
                (currentResUser.Title != null)) {
                that.ProcedureUserList.SelectedObjectID = that.activeUserService.ActiveUser.UserObject.ObjectID;
                let doctor: DoctorModel = new DoctorModel();
                let resUser: ResUser = that.activeUserService.ActiveUser.UserObject as ResUser;

                doctor.Name = resUser.Name;
                doctor.ObjectID = resUser.ObjectID;
                doctor.Title = resUser.Title;

                that.ViewModel._selectedDoctorValue = doctor;
            }

            if (this.ViewModel._selectedDoctorValue != null)
                this.procedureRequestSharedService.onProcedureByUserChange(that.activeUserService.ActiveUser.UserObject.ObjectID);
            else
                this.procedureRequestSharedService.onProcedureByUserChange(null);

            //Paket Listesine sadece kendisine ait paketlerin gelmesi
            that.ProcedurePackageTemplate.ListFilterExpression = "PACKAGEOWNERRESOURCE= '" + currentResUser.ObjectID + "'";


            let inputDVO = new QueryInputDVO();
            inputDVO.EpisodeActionObjectID = this.EpisodeAction.ObjectID;
            inputDVO.PhysicianSuggestionsIsActive = this.PhysicianSuggestionsIsActive;
            inputDVO.IsCancelledIncluded = isCancelledIncluded;


            inputDVO.StartDate = Convert.ToDateTime("01.01.1900 00:00:00");
            inputDVO.EndDate = Convert.ToDateTime("01.01.2900 00:00:00");


            //Hizlandirma calismasi : Yatan hasta icin default olarak son 10 gunluk (sistem parametresi) veri getiriliyor. Tumunu Getir check i isaretli ise hersey gelecek.
            if (this.EpisodeAction.Episode.PatientStatus == PatientStatusEnum.Discharge || this.EpisodeAction.Episode.PatientStatus == PatientStatusEnum.Inpatient) {
                if (this.chkGetAllTests.Value == false) {
                    let timeStr: string;
                    timeStr = await SystemParameterService.GetParameterValue('DAYDURATIONFORLOADING', '10');
                    let timeInterval: number = parseInt(timeStr);
                    let queryEndDate: Date = new Date();
                    queryEndDate = Convert.ToDateTime(Convert.ToDateTime(queryEndDate).ToShortDateString() + " 23:59:59");

                    let queryStartDate: Date = queryEndDate.AddDays(-timeInterval);
                    queryStartDate = Convert.ToDateTime(Convert.ToDateTime(queryStartDate).ToShortDateString() + " 00:00:00");

                    inputDVO.StartDate = queryStartDate;
                    inputDVO.EndDate = queryEndDate;
                }
            }
            else
                this.chkGetAllTests.Visible = false;

            let fullApiUrl: string = "api/ProcedureRequestService/GetRequestedProceduresFormViewModel";
            this.loadingVisible = true;
            let result = await this.httpService.post<any>(fullApiUrl, inputDVO, vmRequestedProcedureForm) as vmRequestedProcedureForm;
            this.loadingVisible = false;
            //let ProceduresList: List<vmRequestedProcedure[]> = new List<vmRequestedProcedure[]>();
            this.ProtocolNo = result.ProtocolNo;

            //ProceduresList.add(result.InpatientRequestedProcedureList);
            //ProceduresList.add(result.ExaminationsRequestedProcedureList);
            //ProceduresList.add(result.ControlRequestedProcedureList);
            //ProceduresList.add(result.RequestedProcedureList);

            //for (let index = 0; index <= 3; index++) {
            //    for (let vmSubActionProcedure of ProceduresList.get(index)) {
            for (let vmSubActionProcedure of result.RequestedProcedureList) {
                let vmRequest: vmRequestedProcedure = new vmRequestedProcedure();
                vmRequest.SubActionProcedureObjectId = vmSubActionProcedure.SubActionProcedureObjectId;
                vmRequest.CurrentStateDefID = vmSubActionProcedure.CurrentStateDefID;
                vmRequest.StateStatus = vmSubActionProcedure.StateStatus;
                vmRequest.ProcedureObjectId = vmSubActionProcedure.ProcedureObjectId;
                vmRequest.EpisodeActionObjectId = vmSubActionProcedure.EpisodeActionObjectId;
                vmRequest.ProcedureCode = vmSubActionProcedure.ProcedureCode;
                vmRequest.ProcedureName = vmSubActionProcedure.ProcedureName;
                vmRequest.ProcedureType = vmSubActionProcedure.ProcedureType;
                vmRequest.RequestDate = vmSubActionProcedure.RequestDate;
                vmRequest.RequestedByResUser = vmSubActionProcedure.RequestedByResUser;
                vmRequest.RequestedById = vmSubActionProcedure.RequestedById;
                vmRequest.ProcedureUserId = vmSubActionProcedure.ProcedureUserId;
                vmRequest.ProcedureResUser = vmSubActionProcedure.ProcedureResUser;
                vmRequest.MasterResource = vmSubActionProcedure.MasterResource;
                vmRequest.MasterResourceObjectId = vmSubActionProcedure.MasterResourceObjectId;
                vmRequest.Amount = vmSubActionProcedure.Amount;
                vmRequest.UnitPrice = vmSubActionProcedure.UnitPrice;
                vmRequest.ActionStatus = vmSubActionProcedure.ActionStatus;
                vmRequest.ProcedureResultLink = vmSubActionProcedure.ProcedureResultLink;
                vmRequest.ProcedureReportLink = vmSubActionProcedure.ProcedureReportLink;
                vmRequest.isResultShown = vmSubActionProcedure.isResultShown;
                vmRequest.canAnalyzeWithAI = vmSubActionProcedure.canAnalyzeWithAI;
                vmRequest.isReportShown = vmSubActionProcedure.isReportShown;
                vmRequest.isResultSeen = vmSubActionProcedure.isResultSeen;
                vmRequest.isAdditionalApplication = vmSubActionProcedure.isAdditionalApplication;
                vmRequest.isAddedToMostUsedRequest = vmSubActionProcedure.isAddedToMostUsedRequest;
                vmRequest.isEmergency = vmSubActionProcedure.isEmergency;
                vmRequest.ExternalProcedureId = vmSubActionProcedure.ExternalProcedureId;
                vmRequest.hasProcedureInstruction = vmSubActionProcedure.hasProcedureInstruction;
                vmRequest.ProcedureInstructions = vmSubActionProcedure.ProcedureInstructions;
                vmRequest.ProcedureInstructionReportName = vmSubActionProcedure.ProcedureInstructionReportName;
                vmRequest.ProtocolNo = vmSubActionProcedure.ProtocolNo;
                vmRequest.ActionType = vmSubActionProcedure.ActionType;
                vmRequest.isObserved = vmSubActionProcedure.isObserved;
                vmRequest.RightLeftInformation = vmSubActionProcedure.RightLeftInformation;
                vmRequest.RightLeftInfoNeeded = vmSubActionProcedure.RightLeftInfoNeeded;
                if (hasProcedureInstruction == false && vmSubActionProcedure.hasProcedureInstruction == true)
                    hasProcedureInstruction = true;
                vmRequest.isExternalProcedureRequest = vmSubActionProcedure.isExternalProcedureRequest;
                vmRequest.isProcedureRejected = vmSubActionProcedure.isProcedureRejected;
                vmRequest.RejectReason = vmSubActionProcedure.RejectReason;
                vmRequest.hasPanicValue = vmSubActionProcedure.hasPanicValue;
                if (vmSubActionProcedure.hasPanicValue == true)
                    vmRequest.PanicValue = vmSubActionProcedure.PanicValue;
                vmRequest.ResultValue = vmSubActionProcedure.ResultValue;

                //Ek hizmetler detay formlarının yüklenmesi
                vmRequest.BaseAdditionalInfoFormGuids = new Array<Guid>();
                if (vmSubActionProcedure.BaseAdditionalInfoFormGuids != null) {
                    for (let baseAdditionalInfoFormGuid of vmSubActionProcedure.BaseAdditionalInfoFormGuids) {
                        vmRequest.BaseAdditionalInfoFormGuids.push(baseAdditionalInfoFormGuid);
                    }
                }
                if (vmRequest.BaseAdditionalInfoFormViewModels == undefined)
                    vmRequest.BaseAdditionalInfoFormViewModels = new Array<BaseAdditionalInfoFormViewModel>();

                if (vmSubActionProcedure.Description != null || vmSubActionProcedure.Description != undefined)
                    vmRequest.Description = vmSubActionProcedure.Description;
                else
                    vmRequest.Description = '';


                if (listProceduresChecked == true && listTestsChecked == true)
                    that.RequestedProcedures.unshift(vmRequest);

                if (listProceduresChecked == true && listTestsChecked == false) {
                    if (vmRequest.ProcedureType != 'LAB' && vmRequest.ProcedureType != 'RAD' && vmRequest.ProcedureType != 'PAT' && vmRequest.ProcedureType != 'NUCLEARTEST')
                        that.RequestedProcedures.unshift(vmRequest);
                }

                if (listProceduresChecked == false && listTestsChecked == true) {
                    if (vmRequest.ProcedureType == 'LAB' || vmRequest.ProcedureType == 'RAD' || vmRequest.ProcedureType == 'PAT' || vmRequest.ProcedureType == 'NUCLEARTEST')
                        that.RequestedProcedures.unshift(vmRequest);
                }

                vmRequest.isProcedureReadOnly = vmSubActionProcedure.isProcedureReadOnly;
                vmRequest.isNew = false;
                vmRequest.isPanelTest = vmSubActionProcedure.isPanelTest;
                vmRequest.isReportRequired = vmSubActionProcedure.isReportRequired;
                vmRequest.isResultNeeded = vmSubActionProcedure.isResultNeeded;
                vmRequest.isRISIntegrated = vmSubActionProcedure.isRISIntegrated;
                vmRequest.isRadiologyProcedure = vmSubActionProcedure.isRadiologyProcedure;
                vmRequest.isPathologyRequired = vmSubActionProcedure.isPathologyRequired;
                vmRequest.isSkinPrickTest = vmSubActionProcedure.isSkinPrickTest;
                vmRequest.isMikrobiyolojiTest = vmSubActionProcedure.isMikrobiyolojiTest;
                vmRequest.mikrobiyolojiResult = vmSubActionProcedure.mikrobiyolojiResult;
                //hastanın tum tetkık ve hızmetlerını doldur
                that.PatientAllProcedures.unshift(vmRequest);
            }
            //}

            //TODO      }
            // Set sırası önemli
            this.ViewModel.requestDate = result.RequestDate;
            if (result.SubEpisodeOpeningDate != null)
                this.SubEpisodeOpeningDate = result.SubEpisodeOpeningDate;
            if(result.ClosingDate != null){
                this.ClosingDate = result.ClosingDate;
            }
            if (result.SubEpisodeClosingDate != null) {
                this.SubEpisodeClosingDate = result.SubEpisodeClosingDate;

                if (this._episodeAction.ObjectDefID.toString() == "2a112388-5c95-40c2-b074-d40eab3c6a1b" || this._episodeAction.ObjectDefID.toString() == "232dd688-7f7c-44ff-bee1-d135d2a90d98" || this._episodeAction.ObjectDefID.toString() == "37809a1b-4c90-45b9-b475-ef4c985fb9e3" || this._episodeAction.ObjectDefID.toString() == "92accee7-68ce-44a6-8e02-8747e426104b") {
                    let result: DailyInpatientInfoModel = new DailyInpatientInfoModel();
                    let apiUrl: string = 'api/EpisodeActionService/ControlDailyInpatient?episodeActionID=' + this._episodeAction.ObjectID;
                    result = await this.httpService.get<DailyInpatientInfoModel>(apiUrl);

                    this.gunubirlikYatisKontrol = result.HasDailyInpatient;

                    if (this.gunubirlikYatisKontrol != true)
                        this.procedureRequestSharedService.setDisableRequestForm(true); // Closing Datei set edilmiş Subepisodelar için Tetkik istem yapılamaz
                    else {
                        this.SubEpisodeClosingDate = null;
                        this.procedureRequestSharedService.setDisableRequestForm(false);
                        this.ControlDailyOperation(true);
                    }
                }
            }

            else
               this.procedureRequestSharedService.setDisableRequestForm(false); // Closing Datei set edilmiş Subepisodelar için Tetkik istem yapılamaz

            if (hasProcedureInstruction)
                this.showProcedureInstructionBtn = true;
            else
                this.showProcedureInstructionBtn = false;

            this.ViewModel.IsSGKPatient = result.IsSGKPatient;
            this.ViewModel.PatientTCNo = result.PatientTCNo;
            this.ViewModel.PatientObjectID = result.PatientObjectId;

            // LabProcedure Sonuçlarına göre İşlem Önerisi varsa
            this.PhysicianSuggestionsIsActive = false; // ekran bir kere yüklenirken sorduktan sonra bir daha sormasın diye
            if (result.ProcedureSuggestionInputDVOList != null) {
                for (let procedureSuggestionInputDVO of result.ProcedureSuggestionInputDVOList) {
                    let result: string = await ShowBox.CustomShow(ShowBoxTypeEnum.Message, i18n("M14022", "Evet,Hayır"), "E,H", "Doktor KKD", "", procedureSuggestionInputDVO.Message, 1);
                    if (result == "E") {
                        if (procedureSuggestionInputDVO.ActionType != null) {

                            switch (procedureSuggestionInputDVO.ActionType) {
                                case ActionTypeEnum.Consultation: {
                                    this.helpMenuService.openConsultationWithResourceInfo(new ClickFunctionParams(this, new ConsultationRequestParametersModel(this._episodeAction.Episode.ObjectID, procedureSuggestionInputDVO.MasterResource, procedureSuggestionInputDVO.MasterResourceGuidList, null, this._episodeAction)));
                                    break;
                                }
                                case ActionTypeEnum.Surgery: {
                                    this.helpMenuService.openSurgery(new ClickFunctionParams(this, new ActiveIDsModel(null, this._episodeAction.Episode.ObjectID, null)));
                                    break;
                                }
                                case ActionTypeEnum.ManipulationRequest: {
                                    this.helpMenuService.openManipulationRequest(new ClickFunctionParams(this, new ActiveIDsModel(null, this._episodeAction.Episode.ObjectID, null)));
                                    break;
                                }
                                case ActionTypeEnum.PhysiotherapyRequest: {
                                    this.helpMenuService.openPhysiotherapyRequest(new ClickFunctionParams(this, new ActiveIDsModel(this._episodeAction.ObjectID, null, null)));
                                    break;
                                }
                                default: {
                                    //statements;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }

    async procedurePackageTemplateSelected(data: any) {
        if (this.dataColumnAction != true) {
            if (this.ViewModel._selectedDoctorValue == null) {
                TTVisual.InfoBox.Alert(i18n("M16700", "İstemi Uygulayan Doktor Alanı için Uzman Hekim Seçmeniz Gerekmektedir!"));
                return;
            }

            try {
                if (data.selectedRowsData != null && data.selectedRowsData.length > 0) {
                    this.addPackage = false;
                    this.choosePackage = true;
                    this.updatePackage = false;
                    this.popupTitle = data.selectedRowsData[0].Name;
                    this.ViewModel._selectedPackageValue = data.selectedRowsData[0];
                    this.OpenRequestTab.emit(true);

                    this.RequestedProceduresForPackage = new Array<vmPackageProcedure>();
                    this.ICDListForPackage = new Array<vmPackageTemplateICD>();

                    let that = this;
                    let apiUrl: string = 'api/ProcedureRequestService/GetPackageTemplateDetail?PackageTemplateObjectId=' + data.selectedRowsData[0].ObjectID.toString();
                    let result = await this.httpService.get<vmPackageTemplate>(apiUrl, vmPackageTemplate);

                    for (let vmPackProc of result.PackageProcedures) {
                        let packProc: vmPackageProcedure = new vmPackageProcedure();
                        packProc.Id = vmPackProc.Id;
                        packProc.ProcedureCode = vmPackProc.ProcedureCode;
                        packProc.ProcedureName = vmPackProc.ProcedureName;
                        packProc.isSelected = true;
                        packProc.isAdditionalApplication = vmPackProc.isAdditionalApplication;

                        this.RequestedProceduresForPackage.push(packProc);
                    }

                    for (let vmPackICD of result.PackageICDs) {
                        let packICD: vmPackageTemplateICD = new vmPackageTemplateICD();
                        packICD.DiagnoseObjectId = vmPackICD.DiagnoseObjectId;
                        packICD.DiagnoseCode = vmPackICD.DiagnoseCode;
                        packICD.DiagnoseName = vmPackICD.DiagnoseName;
                        packICD.Diagnose = vmPackICD.Diagnose;
                        packICD.isSelected = true;
                        this.ICDListForPackage.push(packICD);
                    }

                    this.showPopup = true;
                    window.setTimeout(t => {
                        if (that.ViewModel._selectedPackageValue === null)
                            that.ViewModel._selectedPackageValue = undefined;
                        else
                            that.ViewModel._selectedPackageValue = null;
                        that.detector.tick();
                    }, 0);
                }
            }
            catch (err) {
                ServiceLocator.MessageService.showError(err);
            }
        } else {
            this.dataColumnAction = false;
        }
    }

    dataColumnAction: boolean = false;//(true durumu)satır delete/update butonu ile tetiklenirse buton fonksiyonu çalışacak; (false durumu)buton tıklanmamışsa delete/Update değil paket seçim işlemi çalışacak 
    async procedurePackageTemplateDelete(data: any) {
        if (data.column.name = "RowDelete") {
            if (data.row != null) {
                if (data.row.key != null) {
                    this.dataColumnAction = true;
                    let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), "Paket Silme", "<b>'" + data.row.key.Name + "'</b>  isimli paket silinecektir! \r\n\r\n Devam etmek istiyor musunuz?");
                    if (messageResult === "E") {
                        let that = this;
                        let urlString: string = '/api/RequestedProceduresService/DeleteSelectedPackage?PackageId=' + data.row.key.ObjectID;
                        that.httpService.get<any>(urlString)
                            .then(response => {
                                let result = response;
                                let input: InputModelForQueries = new InputModelForQueries();
                                this.FillDataSourceForPackage(input);
                            })
                            .catch(error => {
                                console.log(error);
                            });
                    } else {
                        let d = 3;
                    }
                }
            }
        }
    }

    async procedurePackageTemplateUpdate(data: any) {
        if (data.column.name = "RowDelete") {
            if (data.row != null) {
                if (data.row.key != null) {
                    this.dataColumnAction = true;
                    try {
                        this.addPackage = false;
                        this.choosePackage = false;
                        this.updatePackage = true;
                        this.popupTitle = "Paket Güncelleme";
                        this.txtPackageTemplateName.Text = data.row.key.Name;
                        this.txtPackageTemplateObjectId = data.row.key.ObjectID;
                        this.ViewModel._selectedPackageValue = data.row.key;
                        this.OpenRequestTab.emit(true);

                        this.RequestedProceduresForPackage = new Array<vmPackageProcedure>();
                        this.ICDListForPackage = new Array<vmPackageTemplateICD>();

                        let that = this;
                        let apiUrl: string = 'api/ProcedureRequestService/GetPackageTemplateDetail?PackageTemplateObjectId=' + data.row.key.ObjectID.toString();
                        let result = await this.httpService.get<vmPackageTemplate>(apiUrl, vmPackageTemplate);

                        for (let vmPackProc of result.PackageProcedures) {
                            let packProc: vmPackageProcedure = new vmPackageProcedure();
                            packProc.Id = vmPackProc.Id;
                            packProc.ProcedureCode = vmPackProc.ProcedureCode;
                            packProc.ProcedureName = vmPackProc.ProcedureName;
                            packProc.isSelected = true;
                            packProc.isAdditionalApplication = vmPackProc.isAdditionalApplication;
                            this.RequestedProceduresForPackage.push(packProc);
                        }

                        for (let vmPackICD of result.PackageICDs) {
                            let packICD: vmPackageTemplateICD = new vmPackageTemplateICD();
                            packICD.DiagnoseObjectId = vmPackICD.DiagnoseObjectId;
                            packICD.DiagnoseCode = vmPackICD.DiagnoseCode;
                            packICD.DiagnoseName = vmPackICD.DiagnoseName;
                            packICD.Diagnose = vmPackICD.Diagnose;
                            packICD.isSelected = true;
                            this.ICDListForPackage.push(packICD);
                        }

                        this.showPopup = true;
                        window.setTimeout(t => {
                            if (that.ViewModel._selectedPackageValue === null)
                                that.ViewModel._selectedPackageValue = undefined;
                            else
                                that.ViewModel._selectedPackageValue = null;
                            that.detector.tick();
                        }, 0);

                    }
                    catch (err) {
                        ServiceLocator.MessageService.showError(err);
                    }

                }
            }
        }
    }

    _selectedAdditionalApplication: Object;
    async PackageAdditionalApplicationSelected(data: any) {
        try {
            if (data.selectedItem != null) {
                this._selectedAdditionalApplication = data.selectedItem;


                let packProc: vmPackageProcedure = new vmPackageProcedure();
                packProc.Id = data.selectedItem.ObjectID;
                packProc.ProcedureCode = data.selectedItem.Code;
                packProc.ProcedureName = data.selectedItem.Name;
                packProc.isSelected = true;
                packProc.isAdditionalApplication = true;//TODO Merve true mu olmalı?
                this.RequestedProceduresForPackage.push(packProc);

                let that = this;
                window.setTimeout(t => {
                    if (that._selectedAdditionalApplication === null)
                        that._selectedAdditionalApplication = undefined;
                    else
                        that._selectedAdditionalApplication = null;
                    that.detector.tick();
                }, 0);

            }
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }

    public columns = [
        {
            caption: i18n("M27286", "Sil"),
            name: "RowDelete",
            width: 40,
            cellTemplate: "deleteCellTemplate",
        },
        {
            caption: "Paket",
            name: "Name",
            dataField: "Name",
            width: 375,
        },
    ];



    public DoctorList;
    async FillDataSources(input: InputModelForDoctorList) {
        try {

            let that = this;
            let apiUrlForPASearchUrl: string = '/api/RequestedProceduresService/FillDataSources';
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
            //  let options = new RequestOptions({ headers: headers });
            /*

            let result = await this.httpService.post(apiUrlForPASearchUrl, body);
            this.DoctorList = result;

            */
            await that.httpService.post<any>(apiUrlForPASearchUrl, input).then(response => {
                let result = response;
                if (result) {
                    that.DoctorList = result;

                    let doctor: DoctorModel = new DoctorModel();
                    let resUser: ResUser = that.activeUserService.ActiveUser.UserObject as ResUser;

                    doctor.Name = resUser.Name;
                    doctor.ObjectID = resUser.ObjectID;
                    doctor.Title = resUser.Title;

                    if ((that._episodeAction.ObjectDefID == PatientExamination.ObjectDefID && that._episodeAction.CurrentStateDefID != PatientExamination.PatientExaminationStates.Examination)
                        || (that._episodeAction.ObjectDefID == Consultation.ObjectDefID && that._episodeAction.CurrentStateDefID != Consultation.ConsultationStates.RequestAcception)
                        || (that._episodeAction.ObjectDefID == DentalExamination.ObjectDefID && that._episodeAction.CurrentStateDefID != DentalExamination.DentalExaminationStates.Examination)) {

                        for (let doctorObject of that.DoctorList) {
                            if (doctorObject.ObjectID.toString() == resUser.ObjectID.toString()) {
                                that.ViewModel._selectedDoctorValue = doctor;
                                break;
                            }

                            //doktordan baska bir kullanici giris yaparsa istem yapan doktor alaninin doldurulmasi icin
                            else {
                                let doctorForAnotherRole: DoctorModel = new DoctorModel();
                                doctorForAnotherRole.Name = that._episodeAction.ProcedureDoctor.Name;
                                doctorForAnotherRole.ObjectID = that._episodeAction.ProcedureDoctor.ObjectID;
                                doctorForAnotherRole.Title = that._episodeAction.ProcedureDoctor.Title;

                                if ((doctorForAnotherRole.Title === UserTitleEnum.UzmanOgr) ||
                                    (doctorForAnotherRole.Title === UserTitleEnum.DoktoraOgr) ||
                                    (doctorForAnotherRole.Title === UserTitleEnum.YanDalUzmanOgr) ||
                                    (doctorForAnotherRole.Title === UserTitleEnum.YLisansUzmanOgr) ||
                                    (doctorForAnotherRole.Title === null) ||
                                    (doctorForAnotherRole.Title === undefined)) {
                                    that.ViewModel._selectedDoctorValue = null;
                                    break;
                                }

                                else {
                                    that.ViewModel._selectedDoctorValue = doctorForAnotherRole;
                                    break;
                                }
                            }
                        }
                    }

                    else
                        that.ViewModel._selectedDoctorValue = doctor;
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    public AICommentForSelectedProcedure: Array<string> = new Array<string>();
    public showAICommentPopUp: boolean = false;
    async GetAICommentForProcedure(data: any){
        let that=this;
        that.loadingVisible = true;
        that.panelMessage = "Yapay zeka tarafından görüntü işleniyor, Lütfen bekleyin";
        let carrier : ObjectIDForAI = new ObjectIDForAI();
        carrier.objectId = data.SubActionProcedureObjectId;
        await that.httpService.post<Array<string>>("/api/RequestedProceduresService/GetAIComments",carrier).then(response => {
            that.AICommentForSelectedProcedure = response;
            that.showAICommentPopUp = true;
            
        that.loadingVisible = false;
        that.panelMessage = "";
        }).catch(error => {
            ServiceLocator.MessageService.showError("Hata : " + error);
            that.loadingVisible = false;
            that.panelMessage = "";
        });
        that.loadingVisible = false;
        that.panelMessage = "";
    }


    public PackageList;
    async FillDataSourceForPackage(input: InputModelForQueries) {
        try {

            let that = this;
            let apiUrlForPASearchUrl: string = '/api/RequestedProceduresService/FillDataSourceForPackage';
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
            //  let options = new RequestOptions({ headers: headers });
            /*

            let result = await this.httpService.post(apiUrlForPASearchUrl, body);
            this.DoctorList = result;

            */
            await this.httpService.post<any>(apiUrlForPASearchUrl, input).then(response => {
                let result = response;
                if (result) {
                    this.PackageList = result;
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    public HizmetList;
    async FillDataSourceForAdditionalApplication(input: InputModelForQueries) {
        try {

            let that = this;
            let apiUrlForPASearchUrl: string = '/api/RequestedProceduresService/FillDataSourceForAdditionalApplication';
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
            //  let options = new RequestOptions({ headers: headers });
            /*

            let result = await this.httpService.post(apiUrlForPASearchUrl, body);
            this.DoctorList = result;

            */
            await this.httpService.post<any>(apiUrlForPASearchUrl, input).then(response => {
                let result = response;
                if (result) {
                    this.HizmetList = result;
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }
    btnAddPackage_Click(): void {
        this.addPackage = true;
        this.choosePackage = false;
        this.updatePackage = false;
        this.popupTitle = i18n("M20166", "Paket Kaydetme");
        this.RequestedProceduresForPackage = new Array<vmPackageProcedure>();
        this.ICDListForPackage = new Array<vmPackageTemplateICD>();
        for (let req of this.RequestedProcedures) {
            if (req.SubActionProcedureObjectId == null && req.isRISIntegrated != true) {
                let vmPackProcedure: vmPackageProcedure = new vmPackageProcedure();
                vmPackProcedure.Id = req.Id;
                vmPackProcedure.ProcedureCode = req.ProcedureCode;
                vmPackProcedure.ProcedureName = req.ProcedureName;
                vmPackProcedure.isSelected = true;
                this.RequestedProceduresForPackage.push(vmPackProcedure);
            }
        }

        for (let icd of this.GridDiagnosisGridList) {
            let vmPackICD: vmPackageTemplateICD = new vmPackageTemplateICD();
            vmPackICD.Diagnose = icd.Diagnose;
            vmPackICD.DiagnoseObjectId = icd.Diagnose.ObjectID;
            vmPackICD.DiagnoseCode = icd.Diagnose.Code;
            vmPackICD.DiagnoseName = icd.Diagnose.Name;

            vmPackICD.isSelected = true;
            this.ICDListForPackage.push(vmPackICD);
        }
        this.showPopup = true;
    }

    async btnSavePackage_Click() {
        try {
            this.showPopup = false;

            let that = this;
            let vmPackageTemplate: vmPackageTemplateDefinition = new vmPackageTemplateDefinition();
            vmPackageTemplate.Name = this.txtPackageTemplateName.Text.toString();

            for (let req of that.RequestedProceduresForPackage) {
                if (req.isSelected == true) {
                    vmPackageTemplate.PackageRequestedProcedures.push(req.Id);
                }
            }

            for (let req of that.ICDListForPackage) {
                if (req.isSelected == true) {
                    vmPackageTemplate.PackageICDs.push(req.DiagnoseObjectId);
                }
            }

            let apiUrl: string = 'api/ProcedureRequestService/AddPackageTemplateDefinition';
            let result = await this.httpService.post(apiUrl, vmPackageTemplate);
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }

    }

    async btnChoosePackage_Click() {
        this.showPopup = false;
        let that = this;
        let packageProcedureFormDetails: Array<Guid> = new Array<Guid>();
        let packageProcedures: Array<Guid> = new Array<Guid>();
        let packageDiagnosises: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();

        for (let req of that.RequestedProceduresForPackage) {
            if (req.isSelected == true) {
                if (req.isAdditionalApplication == true)
                    packageProcedures.push(req.Id);
                else
                    packageProcedureFormDetails.push(req.Id);
            }
        }
        for (let req of that.ICDListForPackage) {
            if (req.isSelected == true) {
                if (req.Diagnose != null)
                    packageDiagnosises.push(req.Diagnose);                
            }
        }
        this.procedureRequestSharedService.onpackageSelected(packageProcedureFormDetails);

        if(packageDiagnosises.length > 0)
            this.diagnosisGridSharedService.AddDiagnosisList(packageDiagnosises);
        let packageProcedureCount: number = 0;
        for (let procID of packageProcedures) {
            await this.addProcedureForSelectedPackage(procID);
            packageProcedureCount += 1;
        }

        if (this.vmProceduresList.length > 0) {
            this.showCloseButton = false;
            this.isRighLeftInfoNeed = true;
            packageProcedureCount = (packageProcedureCount * 100) + 45;
            this.popupHeight = packageProcedureCount.toString() + "px";
        }
    }


    async btnUpdatePackage_Click() {
        try {
            this.showPopup = false;
            let c = this.ViewModel._selectedPackageValue;
            let that = this;
            let vmPackageTemplate: vmPackageTemplateDefinition = new vmPackageTemplateDefinition();
            vmPackageTemplate.Name = this.txtPackageTemplateName.Text.toString();
            vmPackageTemplate.ObjectId = this.txtPackageTemplateObjectId;

            for (let req of that.RequestedProceduresForPackage) {
                if (req.isSelected == true) {
                    vmPackageTemplate.PackageRequestedProcedures.push(req.Id);
                }
            }

            for (let req of that.ICDListForPackage) {
                if (req.isSelected == true) {
                    vmPackageTemplate.PackageICDs.push(req.DiagnoseObjectId);
                }
            }

            let apiUrl: string = 'api/ProcedureRequestService/UpdatePackageTemplateDefinition';
            let result = await this.httpService.post(apiUrl, vmPackageTemplate);
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }

    }
    //showProcedureRequiredInfoClick(): void {

    //    this.showPopupRequiredInfoForm = false;
    //    this.popupTitleRequiredInfoForm = "Hizmet İstem Zorunlu Bilgiler"

    //    this.RequestedProceduresForRequiredInfoForm = new Array<Guid>();

    //    for (let req of this.RequestedProcedures)
    //    {
    //        if (req.isAdditionalApplication == false)
    //        {
    //            this.RequestedProceduresForRequiredInfoForm.push(req.SubActionProcedureObjectId);
    //        }
    //    }

    //    if (this.RequestedProceduresForRequiredInfoForm.length > 0 )
    //    {
    //        this.showPopupRequiredInfoForm = true;
    //    }
    //}

    async showAlertMessageAndContinue(msg: string, requestedProc: vmRequestedProcedure): Promise<boolean> {
        let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M23336", "Tetkik Uyarı Mesajı"), "İstenilen tetkiğin (" + requestedProc.ProcedureCode + '-' + requestedProc.ProcedureName + i18n("M10020", ")  uyarı mesajı bulunmaktadır. <br/> Uyarı : ") + msg + i18n("M10049", "<br/> Devam etmek istiyor musunuz?"));
        if (messageResult === "H") {
            this.procedureRequestSharedService.DeletedProcedureRequestFormDetailIDParam = requestedProc.Id;
            this.procedureRequestSharedService._deletedProcedureRequestFormDetailID.next(requestedProc.Id);
            return false;
        }
        else
            return true;
    }

    async isRepeatedRequestExists(procedureObjID: Guid, requestedFormDetailID: Guid, procedureType: string, patientStatus: PatientStatusEnum): Promise<boolean> {

        //LAB procedure leri icin yazildi, RAD icin de uyarlanacak
        let that = this;
        let returnValue: boolean = false;
        let blockRequest: boolean = false;
        let msg: string = "";
        let stateName: string = "";

        if (procedureType == "LAB") {

            for (let req of that.PatientAllProcedures) {
                if (req.ProcedureType == "LAB") {
                    if (req.SubActionProcedureObjectId != null || req.SubActionProcedureObjectId != Guid.empty()) {
                        if (procedureObjID.toString() == req.ProcedureObjectId.toString()) {

                            //Dış Istem ise Istek Kabul ve Numune Alma  asamaları kontrol edılecek ve engel olunacak
                            if (req.isExternalProcedureRequest == true) {
                                msg = i18n("M16716", "İstenilen dış tetkik (") + req.ProcedureCode + '-' + req.ProcedureName + i18n("M10021", ") daha önce ") + this.datePipe.transform(req.RequestDate, 'dd.MM.yyyy') + " tarihinde " + req.RequestedByResUser.toString() + i18n("M22826", " tarafından istenmiştir.<br/>");
                                if (req.CurrentStateDefID.toString() == LaboratoryProcedure.LaboratoryProcedureStates.SampleAccept.toString()) {
                                    stateName = i18n("M16623", "İstek Kabul");
                                    blockRequest = true;
                                }
                                else if (req.CurrentStateDefID.toString() == LaboratoryProcedure.LaboratoryProcedureStates.SampleTaking.toString()) {
                                    stateName = i18n("M19538", "Numune Alma");
                                    blockRequest = true;
                                }
                                msg = msg + "İstem " + stateName + i18n("M11194", " aşamasındadır. Aynı istem tekrar yapılamaz!");
                            }
                            else {
                                msg = i18n("M16718", "İstenilen tetkik (") + req.ProcedureCode + '-' + req.ProcedureName + i18n("M10021", ") daha önce ") + this.datePipe.transform(req.RequestDate, 'dd.MM.yyyy') + " tarihinde " + req.RequestedByResUser.toString() + i18n("M22826", " tarafından istenmiştir.<br/>");
                                if (req.CurrentStateDefID.toString() == LaboratoryProcedure.LaboratoryProcedureStates.SampleAccept.toString()) {
                                    stateName = i18n("M16623", "İstek Kabul");
                                    blockRequest = true;
                                }
                                else if (req.CurrentStateDefID.toString() == LaboratoryProcedure.LaboratoryProcedureStates.SampleTaking.toString()) {
                                    stateName = i18n("M19538", "Numune Alma");
                                    blockRequest = true;
                                }
                                else if (req.CurrentStateDefID.toString() == LaboratoryProcedure.LaboratoryProcedureStates.SampleLaboratoryAccept.toString()) {
                                    stateName = i18n("M19541", "Numune Kabul");
                                    blockRequest = true;
                                }
                                else if (req.CurrentStateDefID.toString() == LaboratoryProcedure.LaboratoryProcedureStates.Procedure.toString()) {
                                    stateName = i18n("M18255", "Laboratuvarda");
                                    blockRequest = true;
                                }
                                msg = msg + "İstem " + stateName + i18n("M11194", " aşamasındadır. Aynı istem tekrar yapılamaz!");
                            }


                            //Istemi yapmasına engel olunacak, check kaldirilacak
                            if (blockRequest == true) {
                                InfoBox.Alert(i18n("M19355", "Mükerrer İstem!"), msg.toString(), null, 250, 500);
                                this.procedureRequestSharedService.DeletedProcedureRequestFormDetailIDParam = requestedFormDetailID;
                                this.procedureRequestSharedService._deletedProcedureRequestFormDetailID.next(requestedFormDetailID);
                                returnValue = true;
                                break;
                            }
                        }
                    }

                }
            }

            //TODO: Gecici olarak asagıdaki blok kapatıldı. Bagımlı tetkıklerde sonuclanmıs tetkıkler varsa TTVisual.ShowBox.Show tan dolayı bozuluyor.

            //if (returnValue == false) {
            //    //Sonuclanmis mukerrer tetkigin ayaktan hasta icin son 10 gun icindeki test sonucu, Yatan hasta ise son 1 gundeki test sonucu gosterilecek.
            //    //Devam edip etmeyecegi kullanıcıya sorulacak


            //    let timeStr: string;
            //    if (patientStatus == PatientStatusEnum.Outpatient)
            //        timeStr = await SystemParameterService.GetParameterValue('REPEATEDTESTCONTROLTIMEFOROUTPATIENT', '10');
            //    else
            //        timeStr = await SystemParameterService.GetParameterValue('REPEATEDTESTCONTROLTIMEFORINPATIENT', '1');

            //    let currentDate: Date = new Date();
            //    let timeInterval: number = parseInt(timeStr);
            //    let minDate: Date = currentDate.AddDays(-timeInterval);

            //    let procList: Array<vmRequestedProcedure> = new Array<vmRequestedProcedure>();
            //    procList = that.RequestedProcedures.sort(x => x.RequestDate.valueOf()).filter(x => x.ProcedureType == "LAB" && x.ProcedureObjectId.toString() == procedureObjID.toString() && x.SubActionProcedureObjectId != null && x.CurrentStateDefID.toString() == LaboratoryProcedure.LaboratoryProcedureStates.Completed.toString() && x.RequestDate >= minDate);
            //    if (procList != null) {
            //        if (procList.length > 0) {
            //            let i: number = procList.length - 1;
            //            let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M19354", "Mükerrer İstem"), i18n("M16718", "İstenilen tetkik (") + procList[i].ProcedureCode + '-' + procList[i].ProcedureName + i18n("M10021", ") daha önce ") + this.datePipe.transform(procList[i].RequestDate, 'dd.MM.yyyy') + " tarihinde " + procList[i].RequestedByResUser.toString() + i18n("M22825", " tarafından istenmiş ve sonuçlanmıştır.<br/> Sonuç Bilgisi : ") + procList[i].ResultValue + i18n("M10049", "<br/> Devam etmek istiyor musunuz?"));
            //            if (messageResult === "H") {
            //                this.procedureRequestSharedService.DeletedProcedureRequestFormDetailIDParam = requestedFormDetailID;
            //                this.procedureRequestSharedService._deletedProcedureRequestFormDetailID.next(requestedFormDetailID);
            //                returnValue = true;
            //            }
            //        }
            //    }
            //}
        }

        if (procedureType == "RAD") {
            for (let req of that.PatientAllProcedures) {
                if (req.ProcedureType == "RAD") {
                    if (req.SubActionProcedureObjectId != null || req.SubActionProcedureObjectId != Guid.empty()) {
                        if (procedureObjID.toString() == req.ProcedureObjectId.toString()) {
                            //Dış Istem ise her durumda engellenmeyecek cunku dıs ıstem sonuclanmıs olsa bıle stateler ılerlemıyor.
                            if (req.isExternalProcedureRequest != true) {
                                msg = i18n("M16718", "İstenilen tetkik (") + req.ProcedureCode + '-' + req.ProcedureName + i18n("M10021", ") daha önce ") + this.datePipe.transform(req.RequestDate, 'dd.MM.yyyy') + " tarihinde " + req.RequestedByResUser.toString() + i18n("M22826", " tarafından istenmiştir.<br/>");
                                if (req.CurrentStateDefID.toString() == RadiologyTest.RadiologyTestStates.RequestAcception.toString()) {
                                    stateName = i18n("M16623", "İstek Kabul");
                                    blockRequest = true;
                                }
                                else if (req.CurrentStateDefID.toString() == RadiologyTest.RadiologyTestStates.Appointment.toString()) {
                                    stateName = i18n("M20714", "Randevu");
                                    blockRequest = true;
                                }
                                else if (req.CurrentStateDefID.toString() == RadiologyTest.RadiologyTestStates.Procedure.toString()) {
                                    stateName = i18n("M16903", "İşlemde");
                                    blockRequest = true;
                                }
                                msg = msg + "İstem " + stateName + i18n("M11194", " aşamasındadır. Aynı istem tekrar yapılamaz!");
                            }

                            //Istemi yapmasına engel olunacak, check kaldirilacak
                            if (blockRequest == true) {
                                InfoBox.Alert(i18n("M19354", "Mükerrer İstem"), msg.toString(), null, 250, 500);
                                this.procedureRequestSharedService.DeletedProcedureRequestFormDetailIDParam = requestedFormDetailID;
                                this.procedureRequestSharedService._deletedProcedureRequestFormDetailID.next(requestedFormDetailID);
                                returnValue = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        return returnValue;
    }

    //Hizmet/tetkik filtrelemesini user option olarak saklamak icin
    async saveProcedureTestFilterUserOption(): Promise<boolean> {
        try {
            let inputDVO = new UserOptionInputDVO();
            inputDVO.UserOptionType = UserOptionType.FilterProcedureAndTests;

            let optionValue = "";
            if (this.chkOnlyProcedures.Value == true)
                optionValue = optionValue + "P;";
            if (this.chkOnlyTests.Value == true)
                optionValue = optionValue + "T;";
            if (this.chkIncludeCancelledProcedures.Value == true)
                optionValue = optionValue + "C;";

            inputDVO.OptionValue = optionValue;

            let apiUrl: string = 'api/ProcedureRequestService/SaveUserOption';
            let result = await this.httpService.post(apiUrl, inputDVO);
            return true;

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            return false;
        }

    }

    //Hizmet/tetkik filtrelemesini useroption dan getirmek icin
    async getUserOptionForProcedureTestFilter(): Promise<string> {

        try {
            let inputDVO = new UserOptionInputDVO();
            inputDVO.UserOptionType = UserOptionType.FilterProcedureAndTests;

            let apiUrl: string = 'api/ProcedureRequestService/GetUserOption';
            let result = await this.httpService.post<UserOption>(apiUrl, inputDVO, UserOption);
            if (result != null) {
                if (result.OptionValue != null)
                    return result.OptionValue.toString();
                else
                    return null;
            }
            else
                return null;
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            return null;
        }
    }



    async DailyOperationsSave(episodeAction: EpisodeAction) {
        try {

            let that = this;
            let apiUrlForPASearchUrl: string = '/api/EpisodeActionService/DailyInpatientOperations';
            let input: DailyProvisionInputModel = new DailyProvisionInputModel();
            let doctor: ResUser = this.procedureRequestViewModel._selectedDoctorValue as ResUser;
            input.EpisodeAction = episodeAction;
            input.Epicrisis = this.summaryEpicrisis;
            input.InpatientDate = this.ViewModel.requestDate;
            if (this.birim != undefined)
                input.TreatmentClinic = new Guid(this.birim.toString());
            if (typeof this.procedureRequestViewModel._selectedDoctorValue === "string")
                input.ProcedureDoctorID = new Guid(this.procedureRequestViewModel._selectedDoctorValue);
            else
                input.ProcedureDoctorID = doctor.ObjectID;
            input.DailyInpatientControl = this.gunubirlikYatisKontrol;
            input.NormalInpatientControl = this.yatisKontrol;
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });

            await this.httpService.post<any>(apiUrlForPASearchUrl, input).then(response => {
                if (response) {
                    that.operationControl = false;
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    async DailyOperations() {

        if (this.summaryEpicrisis.Equals("")) {
            ServiceLocator.MessageService.showError("Özet epikriz yazılmadan günübirlik yatış işlemi başlatılamaz");
            return;
        }

        if (this.birim == null) {
            ServiceLocator.MessageService.showError("Birim seçilmeden günübirlik yatış işlemi başlatılamaz");
            return;
        }

        this.dailyApplicationControl = false;
        this.dailyControl = true;
        this.ControlDailyOperation(true);
        let subscribeModel: DailyProvisionSubscribeModel = new DailyProvisionSubscribeModel();

        subscribeModel.DailyInpatientControl = this.gunubirlikYatisKontrol;
        subscribeModel.Epicrisis = this.summaryEpicrisis;
        subscribeModel.TreatmentClinic = this.birim;
        subscribeModel.NormalInpatientControl = this.yatisKontrol;

        this.httpService.requestedProcedureSharedService.sendDailyOperationInputModel(subscribeModel);
    }

    async onAdditionalAppCancel() {

        this.dailyApplicationControl = false;
        this.dailyControl = false;

        let index = this.RequestedProcedures.findIndex(element => element == this.firstAdded); //ilk elemanın indeks nosunu döndürür
        this.RequestedProcedures.splice(index, 1);
        this.ViewModel.countForDailyOperations = 0;
        this.summaryEpicrisis = "";
        this.birim = null;
        // this.operationControl = false;
        this.ControlDailyOperation(false);
    }
    async fireRequestedProceduresActions(ea: EpisodeAction): Promise<number> {
        //Istem panelinde istenen testler icin action fire ediliyor.
        /* returnValue: 0,1,2
           0: Procedure yaratıldı, ana actıon save edılecek ve patıentexam ıcın state atlatılacak.
           1: Procedure yaratılmadı, ama ana actıon save edılecek
           2: Procedure yaratılırken SUT Kural ıhlalı oldu ve ısleme devam edılmekten vazgecıldı. Ana actıon save edılmeyecek.
        */
        //if (ea.IsOldAction) {
        //    ServiceLocator.MessageService.showError("Aktarılmış işlemler değiştirilemez.");
        //    return;
        //}
        try {
            let clinicAnemnesisStr: string = "";
            let complaint: string = ea["Complaint"];
            let history: string = ea["PatientHistory"];
            let physicalexam: string = ea["PhysicalExamination"];
            let conclusion: string = ea["MTSConclusion"];


            //let ClinicAnemnesis = ea["Complaint"] ;
            if (complaint != null && complaint != "") {
                clinicAnemnesisStr = clinicAnemnesisStr + i18n("M22494", "Şikayeti: ") + (await CommonService.GetTextOfRTFString(complaint));
            }
            if (history != null && history != "") {
                clinicAnemnesisStr = clinicAnemnesisStr + i18n("M20123", "Özgeçmişi: ") + (await CommonService.GetTextOfRTFString(history));
            }
            if (physicalexam != null && physicalexam != "") {
                clinicAnemnesisStr = clinicAnemnesisStr + i18n("M14390", "Fiziki Muayene: ") + (await CommonService.GetTextOfRTFString(physicalexam));
            }
            if (conclusion != null&& conclusion != "") {
                clinicAnemnesisStr = clinicAnemnesisStr + i18n("M23000", "Tedavi Kararı: ") + (await CommonService.GetTextOfRTFString(conclusion));
            }

            this.ClinicAnemnesis = clinicAnemnesisStr; //"sıkayetım var!!";

            let that = this;
            let eaReqProcInfo: EpisodeActionRequestedProcedureInfo = new EpisodeActionRequestedProcedureInfo();
            let createNewProcedure: boolean = false;
            let returnValue: number;
            let forwardProcedureRequestedStep: boolean = false;

            eaReqProcInfo.episodeActionObjectID = ea.ObjectID;
            eaReqProcInfo.emergency = false;
            eaReqProcInfo.ignoreSUTRules = this.ignoreSUTRuleCheck;

            for (let req of that.RequestedProcedures) {
                if (req.SubActionProcedureObjectId == null || req.SubActionProcedureObjectId == Guid.empty()) {
                    if (req.isEmergency == true) {
                        eaReqProcInfo.emergency = true;
                        break;
                    }
                }
            }

            //Mukerrer tetkik (MT):
            let requestedProceduresObjectIDList: Array<string> = new Array<string>();

            for (let req of that.RequestedProcedures) {
                if (req.SubActionProcedureObjectId == null || req.SubActionProcedureObjectId == Guid.empty()) {
                    if (req.isAdditionalApplication == true) {
                        let addApplication: vmAdditionalProcedureInfo = new vmAdditionalProcedureInfo();
                        addApplication.ProcedureObjectId = req.ProcedureObjectId;
                        addApplication.Amount = req.Amount;
                        addApplication.RequestDate = req.RequestDate;
                        addApplication.ProcedureUserId = req.ProcedureUserId;
                        addApplication.Description = req.Description;
                        addApplication.MedulaReportNo = req.MedulaReportNo;
                        addApplication.ReportApplicationArea = req.ReportApplicationArea;
                        addApplication.RightLeftInformation = req.RightLeftInformation;

                        addApplication.BaseAdditionalInfoFormViewModels = req.BaseAdditionalInfoFormViewModels;
                        eaReqProcInfo.procedureRequestAdditionalApplications.push(addApplication);
                    }
                    else {
                        if (req.ProcedureType == "BLOODREQ") {
                            let bloodProduct: vmRequestedBloodBankProcedureInfo = new vmRequestedBloodBankProcedureInfo();
                            bloodProduct.procedureRequestFormDetailDefinitionID = req.Id;
                            bloodProduct.externalSystemBloodProductID = req.ExternalProcedureId;  //tetkık ıstem ıd ve urun ıd | pıpe  ıle ayrı olarak set edıldı
                            //bloodProduct.procedureDefinitionID = req.ProcedureObjectDefId;
                            eaReqProcInfo.requestedBloodProducts.push(bloodProduct);
                        }
                        else {
                            let procedureReqFormDet: vmRequestedProcedureInfo = new vmRequestedProcedureInfo();
                            procedureReqFormDet.ProcedureRequestFormDetailDefinitionID = req.Id;
                            procedureReqFormDet.RequestDate = req.RequestDate;
                            procedureReqFormDet.ProcedureUserId = req.ProcedureUserId;
                            //Mukerrer Tetkik
                            procedureReqFormDet.ProcedureDefinitionObjectID = req.ProcedureObjectId;
                            procedureReqFormDet.RightLeftInformation = req.RightLeftInformation;
                            procedureReqFormDet.ReasonForRepetition = req.ReasonForRepetition;
                            requestedProceduresObjectIDList.push(req.ProcedureObjectId.toString());
                            //Mukerrer Tetkik
                            eaReqProcInfo.procedureRequestFormDetailDefinitions.push(procedureReqFormDet);
                        }
                    }
                    createNewProcedure = true;
                }
            }



            if (createNewProcedure) {

                if (this.EpisodeAction.Episode.PatientStatus == PatientStatusEnum.Outpatient) {

                    //Mukerrer Tetkık: Hastanın dıger epısodelarında tekrar eden test var mı kontrol edılıyor.
                    //Kontrol hasta Ayaktan  hasta ise yapiliyor. Yatan hastada sadece ilgili episode unda istem girislerinde kontrol yapiliyor.
                    let repeatedTestFound: boolean = false;

                    let inputDVO = new RepeatedProceduresQueryInputDVO();
                    if (typeof this.EpisodeAction.Episode.Patient === "string"){
                        inputDVO.PatientID = this.EpisodeAction.Episode.Patient;
                    }
                    else{
                        inputDVO.PatientID = this.EpisodeAction.Episode.Patient.ObjectID.toString();
                    }
                    inputDVO.RequestedProceduresObjectIDList = requestedProceduresObjectIDList;

                    let apiUrlForRepeatedProcedure: string = 'api/ProcedureRequestService/CheckRepeatedProceduresByPatient';
                    await this.httpService.post<any>(apiUrlForRepeatedProcedure, inputDVO).then(
                        result => {
                            let repeatedProceduresList = result as Array<ProcedureDefinition>;
                            if (repeatedProceduresList.length > 0) {
                                let msgStr: string = "";
                                for (let procedureDef of repeatedProceduresList) {
                                    msgStr = msgStr + procedureDef.Code + "-" + procedureDef.Name + "<br/>";
                                }

                                InfoBox.Alert(i18n("M19354", "Mükerrer İstem!"), "Aşağıdaki istemler mükerrer olduğu için istenmemiştir.<br/>" + msgStr, MessageIconEnum.WarningMessage, 600, 400);

                                //Mukerrer olan procedure ler CreateActionForMyProcedureRequests a gitmemeli
                                for (let repeatedProc of repeatedProceduresList) {
                                    for (let requestedProc of eaReqProcInfo.procedureRequestFormDetailDefinitions) {
                                        if (repeatedProc.ObjectID.toString() == requestedProc.ProcedureDefinitionObjectID.toString()) {

                                            let index = eaReqProcInfo.procedureRequestFormDetailDefinitions.indexOf(requestedProc, 0); //   this.RequestedProcedures.indexOf(delVmRequestedProcedure, 0);
                                            if (index > -1) {
                                                eaReqProcInfo.procedureRequestFormDetailDefinitions.splice(index, 1);
                                            }
                                        }
                                    }
                                }
                            }
                        });
                }

                eaReqProcInfo.DiagnosisObjectIdList = this.GridDiagnosisGridList.filter(dg => dg.Diagnose != null && dg.RemoveSubEpisodeRelation != true).map(dg => dg.Diagnose.ObjectID);

                let apiUrlForSaveProcedureRequest: string = 'api/PatientExaminationService/CreateActionForMyProcedureRequests';
                let result = await this.httpService.post<EpisodeActionFireRequestedProceduresResultInfo>(apiUrlForSaveProcedureRequest, eaReqProcInfo, EpisodeActionFireRequestedProceduresResultInfo);

                if (result.GeneralValidationMsg != null && result.GeneralValidationMsg != "") //
                {
                    InfoBox.Alert("Hizmet Tetkik İstem Hatası", result.GeneralValidationMsg, MessageIconEnum.WarningMessage);
                    return 2;
                }
                if (result.SutRuleResult.validateSutRules) {
                    //Kan urunu istemleri icin Kan Bankasi  tarafindan urune ve isteme verilen tekil numaralar HBYS de de set ediliyor.
                    for (let proc of result.FiredProcedureRequestInfoList) {
                        if (proc.ProcedureObjectDefinitionID.toString() == 'e0a1c9eb-5ab9-44cd-a1d3-6756165c6962')  //BloodBankTestDefinition
                        {
                            for (let req of that.RequestedProcedures) {
                                if (req.SubActionProcedureObjectId == null || req.SubActionProcedureObjectId == Guid.empty()) {
                                    if (req.ProcedureType == "BLOODREQ") {


                                    }
                                }
                            }
                        }
                    }

                    this.RequestedProceduresForRequiredInfoForm = new Array<Guid>();

                    for (let proc of result.FiredProcedureRequestInfoList) {
                        if (proc.ProcedureObjectDefinitionID.toString() == '2a86ddb5-6508-41c6-ae55-6b983add9c84')  //Radyoloji test def.
                        {
                            if (proc.TestTypeName != null) {
                                if (proc.TestTypeName == "CR" ) {
                                    if (proc.isDescriptionNeeded == true)
                                            this.RequestedProceduresForRequiredInfoForm.push(proc.SubActionProcedureObjectID);
                                } else
                                    this.RequestedProceduresForRequiredInfoForm.push(proc.SubActionProcedureObjectID);
                            }
                                                    
                        } else if (proc.ProcedureObjectDefinitionID.toString() == 'f0b2d1dd-e2fc-4c5a-bcb7-f1e498552beb') { //Psikolog test def.
                            this.RequestedProceduresForRequiredInfoForm.push(proc.SubActionProcedureObjectID);
                        }
                        else if (proc.ProcedureObjectDefinitionID.toString() == '0ec41b0f-08bb-4549-ad85-3ffc8e3c8ae6') { //Pathology test def.
                            this.RequestedProceduresForRequiredInfoForm.push(proc.SubActionProcedureObjectID);
                        }
                        else if (proc.ProcedureObjectDefinitionID.toString() == 'c8f0ec5a-969b-458e-9f5c-fdd67db7a42f') { //Nükleer Tıp tet  test def.
                            this.RequestedProceduresForRequiredInfoForm.push(proc.SubActionProcedureObjectID);
                        }
                        //else if (proc.ProcedureObjectDefinitionID.toString() == '3c01da70-344c-4f44-9dc5-8e936758499f') { //Surgery def.
                        //    this.RequestedProceduresForRequiredInfoForm.push(proc.SubActionProcedureObjectID);
                        //}
                    }

                    if (this.RequestedProceduresForRequiredInfoForm.length > 0) {
                        this.showPopupRequiredInfoForm = true;
                        this.popupTitleRequiredInfoForm = i18n("M15861", "Hizmet İstem Zorunlu Bilgiler");
                    }

                    if (eaReqProcInfo.procedureRequestFormDetailDefinitions.length > 0) {
                        returnValue = 0;

                        //Dıs Tetkık ıstem yapıldıysa formunu vıew edecek

                        let eaObjectIDList: Array<string> = new Array<string>();
                        for (let subActProc of result.FiredProcedureRequestInfoList) {
                            for (let req of that.RequestedProcedures) {
                                if (req.ProcedureType != 'RAD' && req.ProcedureType != 'PAT') {

                                    if (req.SubActionProcedureObjectId == null || req.SubActionProcedureObjectId == Guid.empty()) {
                                        if (req.isExternalProcedureRequest == true) {
                                            if (req.ProcedureObjectDefId.toString() == subActProc.ProcedureObjectID.toString()) {
                                                let isFound: boolean = false;
                                                for (let eaObjectID of eaObjectIDList) {
                                                    if (eaObjectID.toString() == subActProc.EpisodeActionObjectID.toString()) {
                                                        isFound = true;
                                                        break;
                                                    }
                                                }
                                                if (isFound == false)
                                                    eaObjectIDList.push(subActProc.EpisodeActionObjectID.toString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (eaObjectIDList.length > 0) {
                            for (let eaObjectID of eaObjectIDList) {
                                const objectIdParam = new GuidParam(eaObjectID.toString());
                                let reportParameters: any = { 'TTOBJECTID': objectIdParam };
                                this.reportService.showReport('ExternalProcedureRequestReportByEpisodeAction', reportParameters);
                            }
                        }
                    }
                    else
                        returnValue = 1;
                }
                else {
                    await this.openSUTRuleCheckResultsForm(result.SutRuleResult).then(result => {

                        if (result.Result == 1)  //Devam et secildi
                            this.ignoreSUTRuleCheck = true;
                        if (result.Result == 2)  //Cancel secildi
                            returnValue = 2;

                    }).catch(err => {
                        this.messageService.showError(err);
                    });

                    if (this.ignoreSUTRuleCheck == true) {
                        returnValue = await this.fireRequestedProceduresActions(this._episodeAction);
                        this.ignoreSUTRuleCheck = false;
                    }
                }

            }
            else {
                returnValue = 1;
            }

            return returnValue;
        }


        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }

    CloseRequestInfoForm(data: any) {
        this.showPopupRequiredInfoForm = data;
    }

    openSUTRuleCheckResultsForm(data: SUTRuleResult): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'SUTRuleCheckResultsForm';
            componentInfo.ModuleName = 'ProcedureRequestModule';
            componentInfo.ModulePath = 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/ProcedureRequestModule';
            componentInfo.InputParam = data;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M22397", "SUT Kural Kontrol Sonuçları");
            modalInfo.Width = 800;
            modalInfo.Height = 350;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public async GetViewResultURL(viewType: string): Promise<void> {

        let that = this;
        let inputDVO = new TestResultQueryInputDVO();
        inputDVO.ViewType = viewType;
        inputDVO.EpisodeID = this.EpisodeAction.Episode.ID.toString();

        let apiUrl: string = 'api/ProcedureRequestService/GetURLForAllTestResults'; //?ViewType=' + viewType + "&EpisodeID=" + this.EpisodeAction.Episode.ID.toString();
        let result = await this.httpService.post<string>(apiUrl, inputDVO);
        this.viewResultURL = result;
    }


    btnShowGridViewResult_Click(): void {
        this.viewResultURL = "";
        this.GetViewResultURL("GRID").then(() => {
            this.openInNewTab(this.viewResultURL);
        });

    }

    btnShowPivotViewResult_Click(): void {
        this.viewResultURL = "";
        this.GetViewResultURL("PIVOT").then(() => {
            this.openInNewTab(this.viewResultURL);
        });
    }

    btnShowLISResultViewForAllEpisodes_Click(): void {
        this.viewResultURL = "";
        this.GetViewResultURLForAllEpisodes().then(() => {
            this.openInNewTab(this.viewResultURL);
        });
    }

    public async GetViewResultURLForAllEpisodes(): Promise<void> {

        let that = this;
        let inputDVO = new TestResultQueryInputDVO();


        inputDVO.PatientTCKN = this.ViewModel.PatientTCNo;
        inputDVO.EpisodeID = this.EpisodeAction.Episode.ID.toString();

        let apiUrl: string = 'api/ProcedureRequestService/GetURLForAllEpisodeTestResults';
        let result = await this.httpService.post<string>(apiUrl, inputDVO);
        this.viewResultURL = result;
    }


    btnQuickProcedureEntry_Click(): void {
        this.showPopupQuickProcedureEntry = true;

    }

    async btnPrintTestInstructions_Click(data, row) {
        //TODO: Tetkik talimatı olan testlerin tetkik istem raporlarını print edecek
        if (row.data.SubActionProcedureObjectId == null) {
            InfoBox.Alert(i18n("M23332", "Tetkik Talimatlarının alınabilmesi için önce işlem kaydedilmelidir."));
        }
        else {

            let subActionProcObjectId: Guid = <any>row.data.SubActionProcedureObjectId;
            let subactionProcedure: SubActionProcedure = await this.objectContextService.getObject<SubActionProcedure>(subActionProcObjectId, SubActionProcedure.ObjectDefID);

            if (row.data.ProcedureType == "LAB") {
                if (row.data.ProcedureInstructionReportName != "" && row.data.ProcedureInstructionReportName != null) {
                    let reportName: string = row.data.ProcedureInstructionReportName;
                    let reportNameArray: Array<string>;
                    reportNameArray = reportName.split("|");

                    for (let repName of reportNameArray) {
                        if (repName != null && repName != "") {
                            if (repName == "LaboratoryTestPatientInstructionReport") {
                                let testObjectID: string = <any>subactionProcedure['ProcedureObject'];
                                const objectIdParam = new GuidParam(testObjectID);
                                let reportParameters: any = { 'TESTOBJECTID': objectIdParam };
                                this.reportService.showReport(repName, reportParameters);

                            }
                            else {
                                let episodeActionObjectID: string = <any>subactionProcedure['EpisodeAction'];
                                const objectIdParam = new GuidParam(episodeActionObjectID);
                                let reportParameters: any = { 'TTOBJECTID': objectIdParam };
                                this.reportService.showReport(repName, reportParameters);
                            }
                        }
                    }
                }
            }

            if (row.data.ProcedureType == "RAD") {
                let episodeActionObjectID: string = <any>subactionProcedure['EpisodeAction'];
                const objectIdParam = new GuidParam(episodeActionObjectID);
                const testObjectIdParam = new GuidParam(subActionProcObjectId);
                let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'TESTOBJECTID': testObjectIdParam };
                this.reportService.showReport("RadiologyTestRequestDescription", reportParameters);
            }

        }
        //UreaBreathTestPatientInstructionReport
        //LaboratoryTripleTestInfoReport
    }

    async btnPrintExternalProcedureRequestReport_Click(data, row) {

        if (row.data.SubActionProcedureObjectId == null) {
            InfoBox.Alert(i18n("M12745", "Dış İstem Formunun alınabilmesi için önce işlem kaydedilmelidir."));
        }
        else {

            let episodeActionObjectId: Guid = <any>row.data.EpisodeActionObjectId;
            const objectIdParam = new GuidParam(episodeActionObjectId.toString());
            let reportParameters: any = { 'TTOBJECTID': objectIdParam };
            this.reportService.showReport('ExternalProcedureRequestReportByEpisodeAction', reportParameters);
        }

    }

    async btnShowRejectReason_Click(data, row) {
        if (row.data.isProcedureRejected == true) {
            InfoBox.Alert("RED NEDENİ", row.data.RejectReason.toString());
        }

    }

    async openPathologyResult(SubActionProcedureObjectId: Guid) {
        //İşlemin bağlı bulunduğu patolojinin ekranını aç <PathologyMainForm>
        let that = this;

        let apiUrl: string = 'api/ProcedureRequestService/GetPathologyObjectID?SubActionProcedureObjectID=' + SubActionProcedureObjectId.toString();
        let result = await this.httpService.get<Guid>(apiUrl);

        this.showPathologyReportInfo(result);

    }

    async openPathologyReport(SubActionProcedureObjectId: Guid) {
        let that = this;

        let apiUrl: string = 'api/ProcedureRequestService/GetPathologyObjectID?SubActionProcedureObjectID=' + SubActionProcedureObjectId.toString();
        let result = await this.httpService.get<Guid>(apiUrl);

        let reportData: DynamicReportParameters = {

            Code: 'PATOLOJISONUCRAPOR',
            ReportParams: { ObjectID: result },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = reportData;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "PATOLOJİ SONUÇ RAPORU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {

                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });


    }

    showPathologyReportInfo(pathologyObjectID: Guid): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "PathologyMainForm";
            componentInfo.ModuleName = "PatolojiModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Patoloji_Modulu/PatolojiModule";
            componentInfo.InputParam = pathologyObjectID.toString();

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M20256", "Patoloji Rapor");
            modalInfo.Width = 1300;
            modalInfo.Height = 700;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    async onRequestDateChanged(event) {
        if (event != null) {
            //this.RequestDate.emit(event.value);
            this.procedureRequestSharedService.onRequestDateChange(event.value);

            // this.DisableRequestForms.emit(false);
            this.procedureRequestSharedService.setDisableRequestForm(false);
            this.AdditionalApplication.Enabled = true;
            this.ProcedurePackageTemplate.Enabled = true;

            let dayCount: number = null;
            let currentDate: Date = await CommonService.RecTime();

            if (event.value != null) {
                //İstem tarihi EpisodeAction ın RequestDate ınden geri bir tarih olmamalı
                let inputDate: Date = <Date>event.value;
                let eaRequestDate = this.EpisodeAction.RequestDate;

                dayCount = DateUtil.totalDays(inputDate, eaRequestDate);
                if (dayCount > 0)  //EpisodeAction tarihi input tarihinden
                {
                    //this.DisableRequestForms.emit(true);
                    this.procedureRequestSharedService.setDisableRequestForm(true);
                    this.AdditionalApplication.Enabled = false;
                    this.ProcedurePackageTemplate.Enabled = false;
                    this.messageService.showError(i18n("M10916", "Ana işlemin başlangıç tarihinden önceki tarihe hizmet girilemez."));
                }
                else {
                    //istem tarihi bugunden once girilirse formdan secim kapatilacak
                    dayCount = DateUtil.totalDays(currentDate, inputDate);
                    if (dayCount > 0)  //Bugunden ileri bir tarih girildi
                    {
                        // this.DisableRequestForms.emit(false);
                        this.procedureRequestSharedService.setDisableRequestForm(false);
                        this.AdditionalApplication.Enabled = false;
                        this.ProcedurePackageTemplate.Enabled = false;
                    }
                    else if (dayCount < 0 && dayCount >= -10 && this.SubEpisodeClosingDate == null) 
                    {
                        // this.DisableRequestForms.emit(false);
                        this.procedureRequestSharedService.setDisableRequestForm(false);
                        this.AdditionalApplication.Enabled = false;
                        this.ProcedurePackageTemplate.Enabled = false;
                    }
                    else if (dayCount < 0) {
                        //this.DisableRequestForms.emit(true);
                        this.procedureRequestSharedService.setDisableRequestForm(true);
                        this.AdditionalApplication.Enabled = true;
                        this.ProcedurePackageTemplate.Enabled = false;
                    }

                }
            } else {
                //this.DisableRequestForms.emit(true);
                this.procedureRequestSharedService.setDisableRequestForm(true);
                this.AdditionalApplication.Enabled = false;
                this.ProcedurePackageTemplate.Enabled = false;
            }
            if (this.ViewModel._selectedDoctorValue != null && this.ViewModel.requestDate != null) {
                let a = await CommonService.PersonelIzinKontrol(this.ViewModel._selectedDoctorValue["ObjectID"], this.ViewModel.requestDate);
                if (a) {
                    this.messageService.showInfo(this.ViewModel._selectedDoctorValue["Name"] + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this.ViewModel._selectedDoctorValue = null;
                    }, 500);

                }
            }
        }
    }

    //Tarih araligina gore hizmetleri sorgulamak icin yazilmisti.
    //async doSearch(startDate: Date, endDate: Date) {
    //    //filtreleme kriterlerine gore DB den ve AddedProcedures lıstesınden verılerı getırıp grıde dolduracak.
    //    try {
    //        this.RequestedProcedures = new Array<vmRequestedProcedure>();
    //        let hasProcedureInstruction: boolean = false;
    //        let inputDVO = new QueryInputDVO();
    //        inputDVO.EpisodeActionObjectID = this.EpisodeAction.ObjectID;
    //        inputDVO.StartDate = startDate;
    //        inputDVO.EndDate = endDate;

    //        let fullApiUrl: string = "api/ProcedureRequestService/GetRequestedProceduresFormViewModelByRequestDateFilter";
    //        let result = await this.httpService.post<any>(fullApiUrl, inputDVO, vmRequestedProcedure) as Array<vmRequestedProcedure>;

    //        for (let vmSubActionProcedure of result) {
    //            let vmRequest: vmRequestedProcedure = new vmRequestedProcedure();
    //            vmRequest.SubActionProcedureObjectId = vmSubActionProcedure.SubActionProcedureObjectId;
    //            vmRequest.EpisodeActionObjectId = vmSubActionProcedure.EpisodeActionObjectId;
    //            vmRequest.ProcedureCode = vmSubActionProcedure.ProcedureCode;
    //            vmRequest.ProcedureName = vmSubActionProcedure.ProcedureName;
    //            vmRequest.RequestDate = vmSubActionProcedure.RequestDate;
    //            vmRequest.RequestedByResUser = vmSubActionProcedure.RequestedByResUser;
    //            vmRequest.RequestedById = vmSubActionProcedure.RequestedById;
    //            vmRequest.ProcedureUserId = vmSubActionProcedure.ProcedureUserId;
    //            vmRequest.ProcedureResUser = vmSubActionProcedure.ProcedureResUser;
    //            vmRequest.MasterResource = vmSubActionProcedure.MasterResource;
    //            vmRequest.Amount = vmSubActionProcedure.Amount;
    //            vmRequest.UnitPrice = vmSubActionProcedure.UnitPrice;
    //            vmRequest.ActionStatus = vmSubActionProcedure.ActionStatus;
    //            vmRequest.ProcedureResultLink = vmSubActionProcedure.ProcedureResultLink;
    //            vmRequest.ProcedureReportLink = vmSubActionProcedure.ProcedureReportLink;
    //            vmRequest.isResultShown = vmSubActionProcedure.isResultShown;
    //            vmRequest.isReportShown = vmSubActionProcedure.isReportShown;
    //            vmRequest.isResultSeen = vmSubActionProcedure.isResultSeen;
    //            vmRequest.isAdditionalApplication = vmSubActionProcedure.isAdditionalApplication;
    //            vmRequest.ProcedureType = vmSubActionProcedure.ProcedureType;
    //            vmRequest.isEmergency = vmSubActionProcedure.isEmergency;
    //            vmRequest.ExternalProcedureId = vmSubActionProcedure.ExternalProcedureId;
    //            vmRequest.hasProcedureInstruction = vmSubActionProcedure.hasProcedureInstruction;
    //            vmRequest.ProcedureInstructions = vmSubActionProcedure.ProcedureInstructions;
    //            vmRequest.ProcedureInstructionReportName = vmSubActionProcedure.ProcedureInstructionReportName;
    //            if (hasProcedureInstruction == false && vmSubActionProcedure.hasProcedureInstruction == true)
    //                hasProcedureInstruction = true;
    //            vmRequest.isExternalProcedureRequest = vmSubActionProcedure.isExternalProcedureRequest;
    //            vmRequest.isProcedureRejected = vmSubActionProcedure.isProcedureRejected;
    //            vmRequest.RejectReason = vmSubActionProcedure.RejectReason;
    //            vmRequest.hasPanicValue = vmSubActionProcedure.hasPanicValue;
    //            if (vmSubActionProcedure.hasPanicValue == true)
    //                vmRequest.PanicValue = vmSubActionProcedure.PanicValue;
    //            vmRequest.ResultValue = vmSubActionProcedure.ResultValue;


    //            this.RequestedProcedures.unshift(vmRequest);
    //        }
    //    }
    //    catch (err) {
    //        ServiceLocator.MessageService.showError(err);
    //    }
    //}


    //async chkListTodayProceduresChecked(isChecked: boolean) {

    //    if (isChecked) //sadece bugun tarihli hizmetler gelecek
    //    {
    //        let currentDate: Date = await CommonService.RecTime();
    //        await this.doSearch(currentDate, currentDate);
    //    }
    //    else  //ilk yuklenisteki gibi supepisode altindaki tum hizmet gelecek
    //        this.loadViewModel();

    //}

    async chkGetAllTestsChecked(isChecked: boolean) {

        this.loadViewModel(this.chkIncludeCancelledProcedures.Value, this.chkOnlyProcedures.Value, this.chkOnlyTests.Value, false);
    }

    async chkIncludeCancelledProceduresChecked(isChecked: boolean) {

        this.loadViewModel(isChecked, this.chkOnlyProcedures.Value, this.chkOnlyTests.Value, false);

    }

    async chkOnlyProceduresChecked(isChecked: boolean) {

        this.loadViewModel(this.chkIncludeCancelledProcedures.Value, isChecked, this.chkOnlyTests.Value, false);

    }

    async chkOnlyTestsChecked(isChecked: boolean) {

        this.loadViewModel(this.chkIncludeCancelledProcedures.Value, this.chkOnlyProcedures.Value, isChecked, false);

    }


    async procedureUserSelected(data, row) {
        row.data.ProcedureUserId = data.ObjectID;
        row.data.ProcedureResUser = data;
    }

    async openManipulationResult(SubActionProcedureObjectId: Guid) {
        //Manipulationın objectIDsini çek
        let that = this;

        let apiUrl: string = 'api/ProcedureRequestService/GetManipulationObjectID?SubActionProcedureObjectID=' + SubActionProcedureObjectId.toString();
        let result = await this.httpService.get<Guid>(apiUrl);

        this.showManipulationResult(result);

    }

    showManipulationResult(manipulationObjectID: Guid): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "OldManipulationForm";
            componentInfo.ModuleName = "PatientHistoryModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Hasta_Gecmisi/PatientHistoryModule";
            componentInfo.InputParam = manipulationObjectID.toString();

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Tıbbi/Cerrahi Uygulama";
            modalInfo.Width = 600;
            modalInfo.Height = 700;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    async openManipulationReport(SubActionProcedureObjectId: Guid) {
        let that = this;

        let apiUrl: string = 'api/ProcedureRequestService/GetManipulationObjectID?SubActionProcedureObjectID=' + SubActionProcedureObjectId.toString();
        let result = await this.httpService.get<Guid>(apiUrl);

        const objectIdParam = new GuidParam(result);
        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
        this.reportService.showReport('ManipulationProcedureReport', reportParameters);


    }

    async openRadiologyReport(SubActionProcedureObjectId: Guid) {

        let paramNewRadiologyReport: string;
        paramNewRadiologyReport = await SystemParameterService.GetParameterValue('NEWRADIOLOGYREPORT', 'FALSE');
        if (paramNewRadiologyReport == "TRUE") {

            let reportData: DynamicReportParameters = {

                Code: 'RADYOLOJISONUCRAPOR',
                ReportParams: { ObjectID: SubActionProcedureObjectId },
                ViewerMode: true

            };

            return new Promise((resolve, reject) => {

                let componentInfo = new DynamicComponentInfo();
                componentInfo.ComponentName = 'HvlDynamicReportComponent';
                componentInfo.ModuleName = 'DevexpressReportingModule';
                componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
                componentInfo.InputParam = reportData;

                let modalInfo: ModalInfo = new ModalInfo();
                modalInfo.Title = "RADYOLOJI SONUÇ RAPORU"

                modalInfo.fullScreen = true;

                let result = this.modalService.create(componentInfo, modalInfo);
                result.then(inner => {

                    resolve(inner);
                }).catch(err => {
                    reject(err);
                });
            });
        } else {


            let that = this;
            const objectIdParam = new GuidParam(SubActionProcedureObjectId);
            let reportParameters: any = { 'TTOBJECTID': objectIdParam };
            this.reportService.showReport('RadiologyTestResultReport', reportParameters);
        }
    }

    async openNuclearMedicineReport(EpisodeActionObjectId: Guid) {
        let that = this;
        const objectIdParam = new GuidParam(EpisodeActionObjectId);
        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
        this.reportService.showReport('NuclearMedicineResultReport', reportParameters);
    }

    showPopupRadiologyTestResultsForm: boolean;
    popupTitleRadiologyTestResultsForm: string;
    btnShowPatientAllRadiologyTestResult_Click(): void {

        this.popupTitleRadiologyTestResultsForm = "Geçmiş Radyoloji Sonuçları";
        this.showPopupRadiologyTestResultsForm = true;
    }

    async openPsychologyTestResultReport(SubActionProcedureObjectId: Guid) {
        let that = this;

        let apiUrl: string = 'api/ProcedureRequestService/GetPsychologyTestObjectID?SubActionProcedureObjectID=' + SubActionProcedureObjectId.toString();
        let result = await this.httpService.get<Guid>(apiUrl);

        const objectIdParam = new GuidParam(result);
        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
        this.reportService.showReport('PsychologyTestReport', reportParameters);


    }

    onRowPrepared(e: any) {
        if (e.key != null && e.rowType == "data") {
            if (e.data.PanicValue == "LL" || e.data.PanicValue == "HH") {
                //e.rowElement.firstItem().css("background-color", "red");
                this.renderer.setStyle(e.rowElement.firstItem(), "background-color", "red");
            }

            //kaydet butonunun bulunduğu hücrenin renklenmesi

            if (e.cells.length > 11) {
                if (!e.data.isNew && (e.data.isAmountChanged || e.data.isDateChanged || e.data.isProcedureUserChanged)) {
                    e.rowElement.firstItem().cells[11].bgColor = '#C78F8A';
                } else
                    e.rowElement.firstItem().cells[11].bgColor = 'white';
            }

        }

        //Farklı subepisodelarda bulunan hizmetler icin kabul numarası kolonunun renklendirilmesi.
        let data: vmRequestedProcedure = e.data as vmRequestedProcedure;
        let j = 0;
        let k = 0;

        for (j = 0; j < e.columns.length; j++) {
            if (e.columns[j].dataField == "ProtocolNo") {
                break;
            }
        }

        if (e.rowElement.firstItem() !== undefined && e.rowType !== 'header' && e.rowType !== 'filter' && e.rowElement.firstItem() !== undefined && e.rowElement.firstItem().cells[j] !== undefined) {

            if (this.ProtocolNo != undefined && data != undefined && data.isNew != true
                && (data.ProtocolNo != this.ProtocolNo || (data.ProtocolNo == this.ProtocolNo && this.EpisodeAction.ActionType != data.ActionType))
                && !((this.EpisodeAction.ActionType == 54) && (data.ActionType == 56 || data.ActionType == 37 || data.ActionType == 54))) {
                e.rowElement.firstItem().cells[j].bgColor = '#ffa5a5';
            }

        }

        for (k = 0; k < e.columns.length; k++) {
            if (e.columns[k].dataField == "ActionType") {
                break;
            }
        }

        if (e.rowElement.firstItem() !== undefined && e.rowType !== 'header' && e.rowType !== 'filter' && e.rowElement.firstItem() !== undefined && e.rowElement.firstItem().cells[j] !== undefined) {

            if (this.EpisodeAction.ActionType != undefined && data != undefined && data.isNew != true
                && (data.ActionType != this.EpisodeAction.ActionType || (data.ActionType == this.EpisodeAction.ActionType && data.ProtocolNo != this.ProtocolNo))
                && !((this.EpisodeAction.ActionType == 54) && (data.ActionType == 56 || data.ActionType == 37 || data.ActionType == 54))) {
                e.rowElement.firstItem().cells[k].bgColor = '#ffa5a5';
            }

        }


        ///TODO

    }

    repaintHizmetGrid() {
        let that = this;
        setTimeout(function () {
            that._hizmetGrid.instance.repaint();
        }, 100);
    }


    addQuickProcedures(data: any) {

        for (let temp of data) {
            this.RequestedProcedures.push(temp);
        }

    }

    closeQuickProcedurePopup(data: any) {
        if (data == true)
            this.showPopupQuickProcedureEntry = false;
    }



    async onGridRequestDateChanged(data, row) {
        row.data.isDateChanged = true;
        let dayCount: number = null;
        let inputDate: Date = <Date>data.value;
        let eaRequestDate = this.EpisodeAction.RequestDate;
        let currentDate: Date = await CommonService.RecTime();



        if (row.data.isAdditionalApplication) {
            //İstem tarihi EpisodeAction ın RequestDate ınden geri bir tarih olmamalı

            dayCount = DateUtil.totalDays(inputDate, eaRequestDate);
            if (dayCount > 0)  //EpisodeAction tarihi input tarihinden 
            {

                this.messageService.showError("Ana işlemin başlangıç tarihinden ( " + eaRequestDate.ToShortDateString() + " ) önceki bir tarihi seçemezsiniz.");
                row.data.RequestDate = data.previousValue;
            }
            else {

                dayCount = DateUtil.totalDays(currentDate, inputDate);
                if (dayCount > 0)  //Bugunden ileri bir tarih girildi
                {
                    this.messageService.showError("İleri tarih seçemezsiniz.");
                    row.data.RequestDate = data.previousValue;
                }


            }
        } else
            return;



    }

    public async GetProcedureUsers(): Promise<any> {
        if (!this.ProcedureUserCache) {
            let url: string = "";
            if (this.EpisodeAction.MasterResource != null) {
                if (typeof this.EpisodeAction.MasterResource === "string")
                    url = "/api/ProcedureRequestService/GetProcedureUsers?MasterResourceID=" + this.EpisodeAction.MasterResource;
                else
                    url = "/api/ProcedureRequestService/GetProcedureUsers?MasterResourceID=" + this.EpisodeAction.MasterResource.ObjectID.toString();
            }
            this.ProcedureUserCache = this.httpService.get(url);
            return this.ProcedureUserCache;
        }
        else {
            return this.ProcedureUserCache;
        }
    }



    public async UpdateProcedure(row: vmRequestedProcedure): Promise<any> {
        try {

            let apiUrl: string = 'api/ProcedureRequestService/UpdateProcedure';
            await this.httpService.post(apiUrl, row);
            row.isProcedureUserChanged = false;
            row.isDateChanged = false;
            row.isAmountChanged = false;
            this.reloadProceduresList();
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }
    onRowUpdated(event) {

        if (event.data.ProcedureUserId != undefined || event.data.ProcedureUserID != null) {
            event.key.isProcedureUserChanged = true;
        }

    }

    onEditingStartRequestedProceduresGrid(event: any) {

        if (event.column.dataField == 'ProcedureUserId') {
            if (event.data.isProcedureReadOnly)
                event.cancel = true;
            else
                event.cancel = false;
        }
    }

    public async openPanelTestResultView(row) {
        if(row.isMikrobiyolojiTest == true)
        {
            this.showMikrobiyolojiTestResultPopup = true;
            this.mikroBiyolojiTestResultDesc = row.mikrobiyolojiResult;
        }
        else{
            this.showPanelTestResultPopup = true;
            this.LaboratorySubProcedureList = new Array<LaboratoryWorkListSubItemDetailModel>();

            let that = this;
            let fullApiUrl: string = "api/LaboratoryWorkListService/GetPanelSubTestsInfo?LaboratoryProcedureObjectID=" + row.SubActionProcedureObjectId.toString();
            let result = await this.httpService.get<any>(fullApiUrl, LaboratoryWorkListSubItemDetailModel) as Array<LaboratoryWorkListSubItemDetailModel>;
            if (result != null)
                this.LaboratorySubProcedureList = result;
        }
    }



    customizePrice(data) {
        return "Toplam: " + Math.Round(data.value, 2);
    }

    public DailyInpatientOperation(): void {
        let dailyInpatient = new InpatientAdmission();
    }

    public async AddAdditionalReport(e, data) {
        if (data.key.BaseAdditionalInfoFormGuids.length > 0)
            this.openAdditionalReportForm(data.key, data.key.BaseAdditionalInfoFormGuids[0].toString());
        else
            this.openAdditionalReportForm(data.key, null);
    }

    openAdditionalReportForm(vmRequest: vmRequestedProcedure, objectID?: string) {
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();

            componentInfo.ComponentName = "AdditionalReportForm";
            componentInfo.ModuleName = "ProcedureRequestModule";
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Tetkik_Istem_Modulu/ProcedureRequestModule';
            this.RequestedByResUser = vmRequest.RequestedByResUser;
            componentInfo.InputParam = new DynamicComponentInputParam(this, new ActiveIDsModel(null, null, null));
            if (objectID != null)
                componentInfo.objectID = objectID;

            let modalInfo: ModalInfo = new ModalInfo();
            //modalInfo.Title = ;
            modalInfo.Width = 700;
            modalInfo.Height = 500;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                let baseAdditionalInfoFormViewModel = inner.Param as BaseAdditionalInfoFormViewModel;
                if (baseAdditionalInfoFormViewModel != null && baseAdditionalInfoFormViewModel instanceof BaseViewModel) {
                    if (vmRequest.BaseAdditionalInfoFormViewModels == null) {
                        vmRequest.BaseAdditionalInfoFormViewModels = new Array<BaseAdditionalInfoFormViewModel>();
                    }
                    vmRequest.BaseAdditionalInfoFormViewModels.push(baseAdditionalInfoFormViewModel);
                }

                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public async AddProcedureResult(e, data) {

        if (data.key.BaseAdditionalInfoFormGuids.length > 0)
            this.openProcedureResultForm(data.key, data.key.BaseAdditionalInfoFormGuids[0].toString());
        else {
            if (data.key.SubActionProcedureObjectId != Guid.Empty && data.key.SubActionProcedureObjectId != undefined) {
                //İşlem kaydedildiyse daha sonra sonuç değeri ekleniyorsa kaydedilmemiş işlem var mı kontrol edilmeli.(Grid refreshlendiği için)

                let flag: boolean = false;
                for (let i = 0; i < this.RequestedProcedures.length; i++) {
                    if (this.RequestedProcedures[i].SubActionProcedureObjectId == undefined || this.RequestedProcedures[i].SubActionProcedureObjectId == null) {
                        flag = true;
                    }
                    if (flag) {
                        break;
                    }
                }
                if (flag) {

                    TTVisual.InfoBox.Alert("Devam etmek için önce işlemler kaydedilmelidir.");
                    return;
                }

            }
            this.openProcedureResultForm(data.key, null);
        }
    }
    _FromResultNeeded: boolean = false;
    _vmObjectID: Guid = Guid.Empty;
    openProcedureResultForm(vmRequest: vmRequestedProcedure, objectID?: string) {
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();

            componentInfo.ComponentName = "ProcedureResultInfoForm";
            componentInfo.ModuleName = "ProcedureRequestModule";
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Tetkik_Istem_Modulu/ProcedureRequestModule';
            this.RequestedByResUser = vmRequest.RequestedByResUser;
            this._FromResultNeeded = true;
            this._vmObjectID = vmRequest.SubActionProcedureObjectId;
            componentInfo.InputParam = new DynamicComponentInputParam(this, new ActiveIDsModel(null, null, null));
            if (objectID != null)
                componentInfo.objectID = objectID;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Sonuç Değeri";
            modalInfo.Width = 500;
            modalInfo.Height = 250;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                let baseAdditionalInfoFormViewModel = inner.Param as BaseAdditionalInfoFormViewModel;
                if (baseAdditionalInfoFormViewModel != null && baseAdditionalInfoFormViewModel instanceof BaseViewModel) {
                    if (vmRequest.BaseAdditionalInfoFormViewModels == null) {
                        vmRequest.BaseAdditionalInfoFormViewModels = new Array<BaseAdditionalInfoFormViewModel>();
                    }
                    vmRequest.BaseAdditionalInfoFormViewModels.push(baseAdditionalInfoFormViewModel);
                }
                if (objectID == null) {
                    if (vmRequest.SubActionProcedureObjectId != null && vmRequest.SubActionProcedureObjectId != undefined) {
                        this.UpdateProcedure(vmRequest);
                    }
                }

                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public async AddSkinPrickTestResult(e, data) {

        if (data.key.BaseAdditionalInfoFormGuids.length > 0)
            this.openSkinPrickTestResult(data.key, data.key.BaseAdditionalInfoFormGuids[0].toString());
        else {
            if (data.key.SubActionProcedureObjectId != Guid.Empty && data.key.SubActionProcedureObjectId != undefined) {
                //İşlem kaydedildiyse daha sonra sonuç  ekleniyorsa kaydedilmemiş işlem var mı kontrol edilmeli.(Grid refreshlendiği için)

                let flag: boolean = false;
                for (let i = 0; i < this.RequestedProcedures.length; i++) {
                    if (this.RequestedProcedures[i].SubActionProcedureObjectId == undefined || this.RequestedProcedures[i].SubActionProcedureObjectId == null) {
                        flag = true;
                    }
                    if (flag) {
                        break;
                    }
                }
                if (flag) {

                    TTVisual.InfoBox.Alert("Devam etmek için önce işlemler kaydedilmelidir.");
                    return;
                }

            }
            this.openSkinPrickTestResult(data.key, null);
        }
    }

    public async ShowRightLeftInformationScreen(e, data) {
        if (data.data != null) {
            this.vmProceduresList.push(data.data);
            this.showCloseButton = true;
            this.isRighLeftInfoNeed = true;
        }
    }
    openSkinPrickTestResult(vmRequest: vmRequestedProcedure, objectID?: string) {
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();

            componentInfo.ComponentName = "SkinPrickTestResultForm";
            componentInfo.ModuleName = "ProcedureRequestModule";
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Tetkik_Istem_Modulu/ProcedureRequestModule';
            this.RequestedByResUser = vmRequest.RequestedByResUser;
            //this._FromResultNeeded = true;
            //this._vmObjectID = vmRequest.SubActionProcedureObjectId;
            componentInfo.InputParam = new DynamicComponentInputParam(this, new ActiveIDsModel(vmRequest.SubActionProcedureObjectId, null, null)); //SkinPrick Servise SubactionProcedure'un ObjectIDsini göndermek için ActiveIDsModeldeki episodeaction alanını kullandım.
            if (objectID != null)
                componentInfo.objectID = objectID;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Deri Prick Test Sonuçları";
            modalInfo.Width = 800;
            modalInfo.Height = 500;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                let baseAdditionalInfoFormViewModel = inner.Param as BaseAdditionalInfoFormViewModel;
                if (baseAdditionalInfoFormViewModel != null && baseAdditionalInfoFormViewModel instanceof BaseViewModel) {
                    if (vmRequest.BaseAdditionalInfoFormViewModels == null) {
                        vmRequest.BaseAdditionalInfoFormViewModels = new Array<BaseAdditionalInfoFormViewModel>();
                    }
                    vmRequest.BaseAdditionalInfoFormViewModels.push(baseAdditionalInfoFormViewModel);
                }
                if (objectID == null) {
                    if (vmRequest.SubActionProcedureObjectId != null && vmRequest.SubActionProcedureObjectId != undefined) {
                        this.UpdateProcedure(vmRequest);
                    }
                }


                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }



    showPathologyResultsPopUp: boolean = false;

    btnShowAllPathologyResults(): void {

        this.showPathologyResultsPopUp = true;
    }

    //Bu fonksyionu operationControl objesinin düzenlenmesi ve gerekli yerlerde dinlenmesi için oluşturuldu. 
    //operationControl günübirlik yatışın yapılıp yapılmayacağını kontrol eder.
    ControlDailyOperation(control: boolean): void {
        this.operationControl = control;
        this.httpService.requestedProcedureSharedService.sendDailyOperationControlBooleanObject(control);
    }

    public ControlTreatmentMaterials() {
        let that = this;
        this.operationControlObjectSubscription = this.httpService.requestedProcedureSharedService.operationControlForProcedureObservable.subscribe(
            result => {
                that.requestedProcedureBoolObjectObservable = result;
            }
        );

        this.dailyInputModelSubscription = this.httpService.requestedProcedureSharedService.dailyInputModelForProcedureObservable.subscribe(
            inputModel => {
                if (inputModel != null) {
                    that.birim = inputModel.TreatmentClinic;
                    that.summaryEpicrisis = inputModel.Epicrisis;
                    that.gunubirlikYatisKontrol = inputModel.DailyInpatientControl;
                    that.yatisKontrol = inputModel.NormalInpatientControl;
                }
            }
        );
    }

    private async  openPathologyRequest(pathologyRequiredProcedures, pathologyRequiredProcedureObjectIDs, pathologyRequiredProceduresObjects, pathologyRequiredProcedureCodes, fromSaveAndClose, ea: EpisodeAction): Promise<void> {
        let that = this;

        let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Patoloji İstem,&Sil", "E,H", i18n("M23735", "Uyarı"), "", "Aşağıda listelenen işlemler patoloji istemi gerektirir. Patoloji isteme devam etmek istiyor musunuz? Devam edilmemesi durumunda işlemler silinecektir.<br/> " + pathologyRequiredProcedures, 1,true);
        if (result === "E")//Patoloji istem başlatılmayacaksa mevcut hizmetler silinmeli kullanıcıya uyarı verilmeli
        {
            this.helpMenuService.onPathologyRequestFromCheck(new ClickFunctionParams(this, new ActiveIDsModel(this._episodeAction.ObjectID, this._episodeAction.Episode.ObjectID, null)));

        } else {
            if (fromSaveAndClose === false) {
                let apiUrl: string = 'api/ProcedureRequestService/CancelPathologyRequiredProcedures';
                let returnResult = await this.httpService.post(apiUrl, pathologyRequiredProcedureObjectIDs);
                for (let req of pathologyRequiredProceduresObjects) {
                    let index = this.RequestedProcedures.indexOf(req, 0);
                    if (index > -1) {
                        this.RequestedProcedures.splice(index, 1);
                    }

                }
            } else {


                this.httpService.get<any>('api/ProcedureRequestService/CancelPathologyRequiredProceduresByCode?EpisodeActionObjectID=' + ea.ObjectID.toString() + '&pathologyRequiredProcedureCodes=' + pathologyRequiredProcedureCodes).then(response => {
                   

                }).catch(error => {

                });

            }

        }


    }

    async checkPathologyRequest(ea: EpisodeAction,fromSaveAndClose:boolean ): Promise<void> {
        let that = this;
        let hasPathologyRequest: boolean = false;
        let pathologyRequiredProcedures: string = "";
        let pathologyRequiredProcedureObjectIDs = Array<string>();
        let pathologyRequiredProcedureCodes : string = "";
        let pathologyRequiredProceduresObjects = Array<vmRequestedProcedure>();//Silinenleri listeden çıkarmak için

        for (let i = 0; i < that.RequestedProcedures.length; i++) {
            if (that.RequestedProcedures[i].isPathologyRequired) {

                pathologyRequiredProcedures += that.RequestedProcedures[i].ProcedureCode + " - " + that.RequestedProcedures[i].ProcedureName + "<br/>";
                if (fromSaveAndClose ===false)
                    pathologyRequiredProcedureObjectIDs.push(that.RequestedProcedures[i].SubActionProcedureObjectId.toString()); //Aftercontextsave'de kontrol edildiği için objectidleri alındı.
                pathologyRequiredProcedureCodes += that.RequestedProcedures[i].ProcedureCode + ",";
                pathologyRequiredProceduresObjects.push(that.RequestedProcedures[i]);
            }
        }

        if (pathologyRequiredProcedures != "") {//Patoloji gerektiren bir işlem eklendiyse

            this.httpService.get<boolean>('api/ProcedureRequestService/HasPathologyRequest?EpisodeActionObjectID=' + ea.ObjectID.toString()).then(response => {
                hasPathologyRequest = response;
                if (!hasPathologyRequest) { //Patoloji istemi yoksa
                    this.openPathologyRequest(pathologyRequiredProcedures, pathologyRequiredProcedureObjectIDs, pathologyRequiredProceduresObjects, pathologyRequiredProcedureCodes, fromSaveAndClose,ea);
                }

            }).catch(error => {

            });

        }
    }

    public onRowPreparedPanelTestGrid(e) {
        if (e.rowElement.firstItem() != undefined && e.rowElement.length > 0 && e.rowType == 'data' && e.data != undefined) {
            if (e.data.IsOutOfReference) {
                e.rowElement.firstItem().style.color = '#ab2222';

            }

        }
    }

    onInit(e: any) {
        e.component.registerKeyHandler("escape", function (arg) {
            arg.stopPropagation();
        });

    }

    public clearList(e: any) {
        this.vmProceduresList.Clear();
    }

    public openRightLeftPopUp(procedure: vmRequestedProcedure){
        if (procedure.RightLeftInfoNeeded == true) {
            this.vmProceduresList.push(procedure);
            this.popupHeight = "145px";
            this.showCloseButton = false;
            this.isRighLeftInfoNeed = true;
        }

    }

    public openIstemPopUp: boolean = false;
    public openPanel(){
        this.openIstemPopUp = true;
    }

}
export class AddMostUsedProcedureRequestFormParam {
    public ProcedureObjectID: Guid;
    public ObservationUnit: Guid;
}

