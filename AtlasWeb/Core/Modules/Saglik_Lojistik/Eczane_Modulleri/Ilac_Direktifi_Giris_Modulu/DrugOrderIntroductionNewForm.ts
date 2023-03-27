//$51533D5D

import { Component, ViewChild, OnInit, ViewContainerRef, AfterViewInit, NgZone, Renderer2 } from '@angular/core';
import {
    DrugOrderIntroductionNewFormViewModel, PrescriptionSignContent, SignedPrescriptionOutput, PrepareSignedDeletePrescriptionContent_Input,
    SendSignedDeletePrescriptionContent_Input, PrepareSignedDiagPrescriptionContent_Input, DiagnosisDefinitionList, SendSignedDiagPrescriptionContent_Input
    , PrepareSignedRecipeDescriptionPrescriptionContent_Input, SendSignedRecipeDescriptionPrescriptionContent_Input, PrepareSignedDrugDescriptionPrescriptionContent_Input,
    SendSignedDrugDescriptionPrescriptionContent_Input, DrugOrderObjectModel, CreateDrugOrderTS_Input, GetPatientDiagnosisGrid_output
} from './DrugOrderIntroductionNewFormViewModel';
import { QueryVademecumInteractionDVO, Product, VademecumProductDVO } from 'app/Logistic/Models/LogisticDashboardViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { DrugDefinition, ResSection, DrugReportType } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrder } from 'NebulaClient/Model/AtlasClientModel';
import { OldDrugOrder } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderIntroduction } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderIntroductionDet } from 'NebulaClient/Model/AtlasClientModel';
import { InPatientPhysicianApplication } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { DrugOrderTypeEnum } from 'NebulaClient/Model/AtlasClientModel';

import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { FavoriteDrugService } from 'ObjectClassService/FavoriteDrugService';
import {
    DrugOrderIntroductionService, ActiveDrugOrders, Order, DrugList, DrugInfo, OrderDetail,
    UpdateOrderDetail_Output, AddInpatientPrescription_Output, AddOutpatientPrescription_Output,
    TempDrugOrder, OldDrugOrderIntroductionDet, ERecete, EReceteDetay, OpenColorPrescription_Input,
    repeatDrugOrder_Input, repeatDrugOrder_Output, CheckLabProcedure_Output, ValidationPatientAgeAndMaterialAgeBand_Output,
    ControlOfOverDoseActiveIngredient_Details, ControlOfOverDoseActiveIngredient_Output, ControlRepeatDay_Output, ControlOfActiveIngredientForRepeat_Output, GetDrugReportNo_Input, DrugIngredient
} from 'ObjectClassService/DrugOrderIntroductionService';
import { FrequencyEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { InpatientPresDetail } from 'NebulaClient/Model/AtlasClientModel';
import { InpatientPrescription } from 'NebulaClient/Model/AtlasClientModel';
import { OutPatientPrescription } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';

import { OutpatientPresDetail } from 'NebulaClient/Model/AtlasClientModel';
import { ITTObject } from 'NebulaClient/StorageManager/InstanceManagement/ITTObject';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { PrescriptionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { PeriodUnitTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { DrugUsageTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SystemMessageService } from 'ObjectClassService/SystemMessageService';
import { TTException } from 'NebulaClient/Utils/Exceptions/TTException';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { UserTemplateService } from 'ObjectClassService/UserTemplateService';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { CharacterCasing } from 'NebulaClient/Utils/Enums/CharacterCasing';
import { UserHelper } from 'app/Helper/UserHelper';
import DataSource from 'devextreme/data/data_source';
import {
    DxSchedulerComponent,
    DxDataGridComponent, DxRadioGroupComponent
} from 'devextreme-angular';
import { IModal, ModalInfo, ModalStateService, ModalActionResult } from 'Fw/Models/ModalInfo';
import { IModalService } from 'Fw/Services/IModalService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { ESignatureService } from 'app/ESignature/Services/esignature.service';
import { IESignatureService } from 'app/ESignature/Services/IESignatureService';
import { SystemParameterService } from 'ObjectClassService/SystemParameterService';
import query from 'devextreme/data/query';



import { SortByEnum } from 'NebulaClient/Utils/Enums/SortByEnum';
import { DescriptionTypeEnum, DrugShapeTypeEnum } from 'NebulaClient/Model/AtlasClientModel';

import { EntityStateEnum } from 'NebulaClient/Utils/Enums/EntityStateEnum';
import { HvlDataGrid } from 'Fw/Components/HvlDataGrid';

import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { Convert } from "NebulaClient/Mscorlib/Convert";
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';


@Component({
    selector: 'DrugOrderIntroductionNewForm',
    templateUrl: './DrugOrderIntroductionNewForm.html',
    styles: [` :host /deep/ .dx-datagrid-header-panel .dx-toolbar {
    margin: 0;
    padding-right: 20px;
    background-color: #5186C3;
}
:host /deep/ .dx-datagrid-header-panel .dx-toolbar-items-container  {
    height: 70px;
}
:host /deep/ .dx-datagrid-header-panel .dx-toolbar-before {
    background-color: #337AB7;
}
:host /deep/ .dx-datagrid-header-panel .dx-selectbox {
     margin: 17px 10px;
}
:host /deep/ .dx-datagrid-header-panel .dx-button {
     margin: 17px 0;
}
/deep/ .informer {
    height: 70px;
    width: 130px;
    text-align: center;
    background: #2A507C url("content/icons/arrow.png") no-repeat 100% 50%;
}
/deep/ .count {
    color: #fff;
    padding-top: 15px;
    line-height: 27px;
}
/deep/ .name {
    color: #619dd1;
}
    `],
    providers: [MessageService, { provide: IESignatureService, useClass: ESignatureService }]
})

export class DrugOrderIntroductionNewForm extends TTVisual.TTForm implements OnInit, AfterViewInit, IModal {
    ActionDate: TTVisual.ITTDateTimePicker;
    AutoSearch: TTVisual.ITTCheckBox;
    btnIlacBilgileri: TTVisual.ITTButton;
    btnSUTBilgileri: TTVisual.ITTButton;
    btnDrugInfo: TTVisual.ITTButton;
    cmdAddDrug: TTVisual.ITTButton;
    cmdAddTemplate: TTVisual.ITTButton;
    cmdFavoriteDrug: TTVisual.ITTButton;
    cmdGetTemplate: TTVisual.ITTButton;
    cmdRepat: TTVisual.ITTButtonColumn;
    cmdSearch: TTVisual.ITTButton;
    CodeDiagnosisForPresc: TTVisual.ITTTextBoxColumn;
    DayDrugOrderIntroductionDet: TTVisual.ITTTextBoxColumn;
    DiagnosisForPrescriptions: TTVisual.ITTGrid;
    Dose: TTVisual.ITTTextBox;
    DoseAmountDrugOrderIntroductionDet: TTVisual.ITTTextBoxColumn;
    DrugDescription: TTVisual.ITTTextBox;
    DrugDescriptionType: TTVisual.ITTEnumComboBox;
    DrugOrderType: TTVisual.TTEnumComboBoxColumn;

    DrugOrderTypeColumn: TTVisual.TTEnumComboBoxColumn;
    DrugListview: TTVisual.ITTListView;
    DrugName: TTVisual.ITTTextBox;
    DrugOrderIntroductionDetails: TTVisual.ITTGrid;
    DrugUsageType: TTVisual.ITTEnumComboBox;
    EReceteDescription: TTVisual.ITTComboBoxColumn;
    EReceteNo: TTVisual.ITTTextBoxColumn;
    FavoriteDrugDay: TTVisual.ITTTextBox;
    FavoriteDrugDose: TTVisual.ITTTextBox;
    FavoriteDrugFrequency: TTVisual.ITTTextBox;
    FavoriteDrugListview: TTVisual.ITTListView;
    FrequencyDrugOrderIntroductionDet: TTVisual.ITTEnumComboBoxColumn;
    FullNamePatient: TTVisual.ITTTextBox;
    ID: TTVisual.ITTTextBox;
    InpatientPresDetails: TTVisual.ITTGrid;
    IsBarcode: TTVisual.ITTCheckBox;
    IsInheldDrug: TTVisual.ITTCheckBox;
    labelActionDate: TTVisual.ITTLabel;
    labelDose: TTVisual.ITTLabel;
    labelDrugDescription: TTVisual.ITTLabel;
    labelDrugName: TTVisual.ITTLabel;
    labelDrugUsageType: TTVisual.ITTLabel;
    labelFullNamePatient: TTVisual.ITTLabel;
    labelID: TTVisual.ITTLabel;
    labelMasterResource: TTVisual.ITTLabel;
    labelMaxDose: TTVisual.ITTLabel;
    labelMaxDoseDay: TTVisual.ITTLabel;
    labelOrderDay: TTVisual.ITTLabel;
    labelOrderDose: TTVisual.ITTLabel;
    labelOrderFrequency: TTVisual.ITTLabel;
    labelPlannedStartTime: TTVisual.ITTLabel;
    labelRoutineDay: TTVisual.ITTLabel;
    labelVolume: TTVisual.ITTLabel;
    labelVolumeUnit: TTVisual.ITTLabel;
    labelPackageAmount: TTVisual.ITTLabel;
    labelPeriodUnitType: TTVisual.ITTLabel;
    MasterResource: TTVisual.ITTObjectListBox;
    MaterialDrugOrderIntroductionDet: TTVisual.ITTTextBoxColumn;
    MaxDose: TTVisual.ITTTextBox;
    MaxDoseDay: TTVisual.ITTTextBox;
    NameDiagnosisForPresc: TTVisual.ITTTextBoxColumn;
    NewOrderTabPage: TTVisual.ITTTabPage;
    OldDay: TTVisual.ITTTextBoxColumn;
    OldDoseAmount: TTVisual.ITTTextBoxColumn;
    OldDrug: TTVisual.ITTListBoxColumn;
    OldDrugFrequency: TTVisual.ITTEnumComboBoxColumn;
    OldDrugOrders: TTVisual.ITTGrid;
    OldDrugPlanDate: TTVisual.ITTDateTimePickerColumn;
    OldOrderTabPage: TTVisual.ITTTabPage;
    OldUseDescription: TTVisual.ITTTextBoxColumn;
    OrderDay: TTVisual.ITTTextBox;
    OrderDose: TTVisual.ITTTextBox;
    OrderFrequency: TTVisual.ITTTextBox;
    OutpatientPresDetails: TTVisual.ITTGrid;
    OutPatientTabPage: TTVisual.ITTTabPage;
    OutPresEReceteDesc: TTVisual.ITTTextBoxColumn;
    OutPresEReceteNo: TTVisual.ITTTextBoxColumn;
    OutPresType: TTVisual.ITTEnumComboBoxColumn;
    PatientInfoTabPage: TTVisual.ITTTabPage;
    PatientOwnDrug: TTVisual.ITTCheckBoxColumn;
    PatientOwnDrugCheck: TTVisual.ITTCheckBox;
    IsImmediateCheck: TTVisual.ITTCheckBox;
    IsImmediateCheckGrid: TTVisual.ITTCheckBoxColumn;

    CaseOfNeedCheck: TTVisual.ITTCheckBox;
    NextDayCheck: TTVisual.ITTCheckBox;

    CaseOfNeedCheckGrid: TTVisual.ITTCheckBoxColumn;

    PlannedStartTime: TTVisual.ITTDateTimePicker;
    PlannedTime: TTVisual.ITTDateTimePickerColumn;
    PeriodUnitType: TTVisual.ITTEnumComboBox;
    PackageAmount: TTVisual.ITTTextBox;
    PrescriptionTabPage: TTVisual.ITTTabPage;
    PrescriptionType: TTVisual.ITTEnumComboBoxColumn;
    SearchTextbox: TTVisual.ITTTextBox;
    SecondaryMasterResource: TTVisual.ITTObjectListBox;
    ttdatetimepicker1: TTVisual.ITTDateTimePicker;
    ttenumcombobox2: TTVisual.ITTEnumComboBox;
    buttonChangeSchedule: TTVisual.ITTButtonColumn;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttgroupbox2: TTVisual.ITTGroupBox;
    ttgroupbox3: TTVisual.ITTGroupBox;
    ttgroupbox4: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel11: TTVisual.ITTLabel;
    ttlabel12: TTVisual.ITTLabel;
    ttlabel13: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttextbox1: TTVisual.ITTTextBox;
    tttextbox7: TTVisual.ITTTextBox;
    tttextbox8: TTVisual.ITTTextBox;
    txtStoreName: TTVisual.ITTTextBox;
    ttenumcomboboxcolumn1: TTVisual.ITTEnumComboBoxColumn;
    ttenumcomboboxcolumn2: TTVisual.ITTEnumComboBoxColumn;
    tttextboxcolumn1: TTVisual.ITTTextBoxColumn;
    tttextboxcolumn2: TTVisual.ITTTextBoxColumn;
    tttextboxcolumn3: TTVisual.ITTTextBoxColumn;
    Unit: TTVisual.ITTTextBox;
    UsageNoteDrugOrderIntroductionDet: TTVisual.ITTTextBoxColumn;
    UseRoutineValue: TTVisual.ITTCheckBox;
    Volume: TTVisual.ITTTextBox;
    VolumeUnit: TTVisual.ITTTextBoxColumn;


    buttonDeleteDrugOrder: TTVisual.ITTButtonColumn;

    isInpatient: boolean = false;
    isOutpatient: boolean = false;
    isDischarged: boolean = false;
    isRequiedForm: boolean = false;
    IsSGK: boolean = false;
    isVademecumEntegrasyon = true;
    useOldMethodForColorPrescription: boolean = false;
    useNewMethodForColorPrescription: boolean = false;
    searchText: string;
    drugSource: DataSource;
    eReceteDataSource: any;
    selectedErecete: Array<ERecete>;
    eReceteList: Array<ERecete>;
    appointmentsData: Order[];
    resourcesData: DrugList[];
    detailResourcesData: DrugList[];
    orderDetailData: OrderDetail[];
    //prioritiesData: any[];
    currentDate: Date = new Date(Date.now());
    isFavoriteDrugList: boolean = false;
    isInheldDrugList: boolean = false;
    isPatientOwnDrug: boolean = false;
    favoriteDrugs: Array<DrugInfo>;
    patientOwnDrugs: Array<DrugInfo>;
    patientOwnDrugAmount: number = 0;
    frequencyies: string[];
    tempDrugOrders: Array<TempDrugOrder>;
    selectedTempItems: Array<TempDrugOrder>;
    expanded = true;
    totalCount: number;
    addingDruglist: Array<string>;
    loadingVisible = false;
    loadingVisibleDiag = false;
    hasErecetePassword: boolean = true;
    isInheld: boolean = false;
    public NextDayOrder1x1 = false;
    public NextDayOrderRepeat1x1 = false;
    public drugOrderTimeOffset: number;
    public patientAllergicDrug: Array<Guid> = new Array<Guid>();

    DrugUsageTypeComboBox: TTVisual.ITTEnumComboBoxColumn;
    selectedDrugDetailRows: EReceteDetay[];
    private DrugOrderQueryDayNumber: number = -10;


    views: any = ['month', {
        type: 'week',
        groups: ['typeId'],
        dateCellTemplate: 'dateCellTemplate'
    }, 'day'];

    @ViewChild('scheduler') _scheduler: DxSchedulerComponent;
    @ViewChild('detailScheduler') _detailScheduler: DxSchedulerComponent;
    @ViewChild(DxDataGridComponent) dataGridInstance: DxDataGridComponent;
    @ViewChild('eventRadioGroup') eventRadioGroup: DxRadioGroupComponent;
    @ViewChild('drugOrderDetail') drugOrderDetailGrid: HvlDataGrid;
    @ViewChild('inpatientPresDetail') inpatientPresDetailGrid: HvlDataGrid;
    @ViewChild('outPatientPresDetail') outPatientPresDetailGrid: HvlDataGrid;
    private PrepareSignedPrescriptionContentUrl: string = '/api/DrugOrderIntroductionService/PrepareSignedPrescriptionContent';
    private PrepareSignedApprovalPrescriptionContentUrl: string = '/api/DrugOrderIntroductionService/PrepareSignedApprovalPrescriptionContent';
    private PrepareSignedDeletePrescriptionContentUrl: string = '/api/DrugOrderIntroductionService/PrepareSignedDeletePrescriptionContent';
    private SendSignedApprovalPrescriptionContentUrl: string = '/api/DrugOrderIntroductionService/SendSignedApprovalPrescriptionContent';
    private SendSignedDeletePrescriptionContentUrl: string = '/api/DrugOrderIntroductionService/SendSignedDeletePrescriptionContent';

    private PrepareSignedDiagnosisPrescriptionContentUrl: string = '/api/DrugOrderIntroductionService/PrepareSignedDiagnosisPrescriptionContent';
    private SendSignedDiagnosisPrescriptionContentUrl: string = '/api/DrugOrderIntroductionService/SendSignedDiagnosisPrescriptionContent';

    private PrepareSignedRecipeDescriptionPrescriptionContentUrl: string = '/api/DrugOrderIntroductionService/PrepareSignedRecipeDescriptionPrescriptionContent';
    private SendSignedRecipeDescriptionPrescriptionContentUrl: string = '/api/DrugOrderIntroductionService/SendSignedRecipeDescriptionPrescriptionContent';


    private PrepareSignedDrugDescriptionPrescriptionContentUrl: string = '/api/DrugOrderIntroductionService/PrepareSignedDrugDescriptionPrescriptionContent';
    private SendSignedDrugDescriptionPrescriptionContentUrl: string = '/api/DrugOrderIntroductionService/SendSignedDrugDescriptionPrescriptionContent';
    public ShowDoseAmountManagerButton: boolean = false;
    public ShowDoseAmountManagerPassword: string = "";
    public selectedDiagnosis: DiagnosisDefinitionList = new DiagnosisDefinitionList;
    public DiagnosisForPrescriptionsColumns = [];
    public DrugOrderIntroductionDetailsColumns = [];
    public InpatientPresDetailsColumns = [];
    public OldDrugOrdersColumns = [];
    public OutpatientPresDetailsColumns = [];
    public selectedPlannedStartTime: Date = new Date(Date.now());
    public drugOrderIntroductionNewFormViewModel: DrugOrderIntroductionNewFormViewModel = new DrugOrderIntroductionNewFormViewModel();
    private formDefName = 'DrugOrderIntroductionNewForm';
    public get _DrugOrderIntroduction(): DrugOrderIntroduction {
        return this._TTObject as DrugOrderIntroduction;
    }
    public showDrugOrderDetails = false;

    private DrugOrderIntroductionNewForm_DocumentUrl: string = '/api/DrugOrderIntroductionService/DrugOrderIntroductionNewForm';
    constructor(protected messageService: MessageService,
        private reportService: AtlasReportService,
        private modalService: IModalService,
        private objectContextService: ObjectContextService,
        private http: NeHttpService,
        private modalStateService: ModalStateService,
        private signService: IESignatureService,
        protected ngZone: NgZone,
        private activeUserService: IActiveUserService,
        private renderer: Renderer2) {

        super('DRUGORDERINTRODUCTION', 'DrugOrderIntroductionNewForm');
        this._DocumentServiceUrl = this.DrugOrderIntroductionNewForm_DocumentUrl;
        this.ShowDoseAmountManagerButton = activeUserService.ActiveUser.IsSuperUser;
        this.initViewModel();
        this.initFormControls();


    }


    public async GetPatientDiagnosis() {

        let url: string = '/api/DrugOrderIntroductionService/GetPatientDiagnosisGridList';
        if (this._DrugOrderIntroduction.SubEpisode != null && this.drugOrderIntroductionNewFormViewModel.GridEpisodeDiagnosisGridList.length === 0) {
            let input = { 'id': this._DrugOrderIntroduction.SubEpisode.ObjectID };
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            let result = await httpService.post<Array<GetPatientDiagnosisGrid_output>>(url, input);

            let that = this;
            result.forEach(element => {
                let gridItem: DiagnosisGrid = element.diagnosisGrid;
                element.diagnosis['GeneratedDisplayExpression'] = element.diagnosis.Code + ' ' + element.diagnosis.Name;
                gridItem.Diagnose = element.diagnosis;
                gridItem.ResponsibleDoctor = element.responsibleDoctor;
                that.drugOrderIntroductionNewFormViewModel.GridEpisodeDiagnosisGridList.push(gridItem);
            });
        }


    }

    async onValueChangedErecete(event: any) {
        let title: string = event.addedItems[0].title;
        if (i18n("M30017", "Hastaya Tanı Ekle") === title) {
            this.GetPatientDiagnosis();
        } else if (i18n("M30018", "Reçeteye Tanı Ekle") === title) {

            this.loadingVisibleDiag = true;
            if (this.drugOrderIntroductionNewFormViewModel.DiagnosisDefinitionList === null ||
                this.drugOrderIntroductionNewFormViewModel.DiagnosisDefinitionList === undefined ||
                this.drugOrderIntroductionNewFormViewModel.DiagnosisDefinitionList.length === 0) {
                this.drugOrderIntroductionNewFormViewModel.DiagnosisDefinitionList = await DrugOrderIntroductionService.DiagnosisDefinition();
            }
            this.loadingVisibleDiag = false;
        } else {

        }
    }



    public drugDescriptionForErecete: string;
    public recipeDescription: string;


    public setInputParam(value: Object) {
        this._TTObject = value as DrugOrderIntroduction;
        this.drugOrderIntroductionNewFormViewModel = new DrugOrderIntroductionNewFormViewModel();
        this._ViewModel = this.drugOrderIntroductionNewFormViewModel;
        this.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction = value as DrugOrderIntroduction;
        this.addingDruglist = new Array<string>();
    }

    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    protected isLoadViewModel(): boolean {
        return false;
    }

    private async LoadDrugOrderDayNumber() {
        let result: string = await DrugOrderIntroductionService.GetDrugOrderQueryDayNumber();
        this.DrugOrderQueryDayNumber = Number.parseInt(result);
        if (this.DrugOrderQueryDayNumber > 0)
            this.DrugOrderQueryDayNumber *= (-1);
    }

    async ngOnInit() {
        let that = this;
        if (this._DrugOrderIntroduction.ActiveInPatientPhysicianApp !== undefined) {
            if (this._DrugOrderIntroduction.ActiveInPatientPhysicianApp.CurrentStateDefID.valueOf() === InPatientPhysicianApplication.InPatientPhysicianApplicationStates.Discharged.id ||
                this._DrugOrderIntroduction.ActiveInPatientPhysicianApp.CurrentStateDefID.valueOf() === InPatientPhysicianApplication.InPatientPhysicianApplicationStates.PreDischarged.id) {
                this.isDischarged = true;
                this.isOutpatient = true;
            } else {
                this.isInpatient = true;
            }
        } else {
            this.isOutpatient = true;
        }

        this.IsSGK = await DrugOrderIntroductionService.IsSGK(this._DrugOrderIntroduction.SubEpisode.ObjectID);

        this.LoadDrugOrderDayNumber();

        let masterResourceObjectID: Guid = <any>that.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction['MasterResource'];
        if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
            let masterResource: ResSection = await this.objectContextService.getObject<ResSection>(masterResourceObjectID, ResSection.ObjectDefID);
            this._DrugOrderIntroduction.MasterResource = masterResource;
        }


        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let fullApiUrl = this.DrugOrderIntroductionNewForm_DocumentUrl + '/' + this._DrugOrderIntroduction.ObjectID;
        let response = await httpService.get<DrugOrderIntroduction>(fullApiUrl);
        if (response !== null) {
            this._ViewModel = response;
            this.loadViewModel();
        } else {
            await this.load(DrugOrderIntroductionNewFormViewModel);
            if (this.isInpatient === false) {
                this.loadViewModel();
            }
        }

        this.drugOrderTimeOffset = await DrugOrderIntroductionService.GetDrugOrderTimeOffset();

        this.frequencyies = [
            '1X1',
            '2X1',
            '3X1',
        ];

        if (this.isInpatient === true) {
            this.DropStateList = new Array<Guid>();
            this.DropStateList.push(DrugOrderIntroduction.DrugOrderIntroductionStates.Completed);
        }
        if (this.isOutpatient === true) {
            this.DropStateList = new Array<Guid>();
            this.DropStateList.push(DrugOrderIntroduction.DrugOrderIntroductionStates.CompletedWithSign);
        }

        this.queryEndDateForActiveDrugOrders = new Date();
        this.queryStartDateForActiveDrugOrders = this.queryEndDateForActiveDrugOrders.AddDays(this.DrugOrderQueryDayNumber);

        let activeDrugOrders: ActiveDrugOrders = await DrugOrderIntroductionService.GetActiveDrugOrders(this._DrugOrderIntroduction.Episode, this.queryStartDateForActiveDrugOrders, this.queryEndDateForActiveDrugOrders);
        this.appointmentsData = activeDrugOrders.Orders;
        this.resourcesData = activeDrugOrders.Drugs;
        this.orderDetailData = activeDrugOrders.OrderDetails;
        this.detailResourcesData = activeDrugOrders.DetailDrugs;


        if (this.isInpatient) {
            this.patientOwnDrugs = await DrugOrderIntroductionService.GetPatientOwnDrug(this._DrugOrderIntroduction.Episode);
        }



        // this.loadOldDrugOrders();

        let date: Date = new Date();
        date = date.AddDays(this.DrugOrderQueryDayNumber);
        this.GetDrugOrderIntroductionsWithDate(date);

        this._DrugOrderIntroduction.PlannedStartTime = new Date(Date.now()); //await DrugOrderIntroductionService.GetPlannedStartTime();
        this._DrugOrderIntroduction.DrugOrderType = DrugOrderTypeEnum._Treatment.code;

        let vademecumEntg: string = (await SystemParameterService.GetParameterValue('VADEMECUMENTEGRASYON', 'FALSE'));
        if (vademecumEntg === 'FALSE') {
            this.isVademecumEntegrasyon = false;
        }

        let enableColorPrescriptionWithJSON: string = (await SystemParameterService.GetParameterValue('ENABLECOLORPRESCRIPTIONWITHJSON', 'FALSE'));
        if (enableColorPrescriptionWithJSON === 'FALSE') {
            this.useNewMethodForColorPrescription = false;
            this.useOldMethodForColorPrescription = true;
        }
        else {
            this.useNewMethodForColorPrescription = true;
            this.useOldMethodForColorPrescription = false;
        }

        this.patientAllergicDrug = await DrugOrderIntroductionService.GetPatientAllergicActiveIngredients(this._DrugOrderIntroduction.Episode.ObjectID);

        this.initFormControls();

    }

    private async loadOldDrugOrders() {
        let oldDrugOrders: Array<DrugOrderObjectModel> = await this.GetOldDrugOrders(this._DrugOrderIntroduction.Episode);

        if (oldDrugOrders.length > 0) {
            this._DrugOrderIntroduction.OldDrugOrders = new Array<OldDrugOrder>();
            for (let orderModel of oldDrugOrders) {
                let oldDrugOrder: OldDrugOrder = new OldDrugOrder();
                oldDrugOrder.DrugOrder = orderModel.drugOrder;
                oldDrugOrder.DrugOrder.Material = orderModel.material;

                this.drugOrderIntroductionNewFormViewModel.OldDrugOrdersGridList.push(oldDrugOrder);
                this._DrugOrderIntroduction.OldDrugOrders.push(oldDrugOrder);
            }
        }
    }



    private async GetOldDrugOrders(episode: Episode): Promise<Array<DrugOrderObjectModel>> {
        let url: string = '/api/DrugOrderIntroductionService/GetOldDrugOrders';
        let input = { 'episode': episode };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<Array<DrugOrderObjectModel>>(url, input);
        return result;
    }

    GetDrugOrderIntroductions(event) {
        let date: Date = null;
        this.GetDrugOrderIntroductionsWithDate(date);
    }

    async GetDrugOrderIntroductionsWithDate(date: Date) {

        if (date != null) {
            date = Convert.ToDateTime(Convert.ToDateTime(date).ToShortDateString() + " 00:00:00");
        }
        let oldOrders: OldDrugOrderIntroductionDet = await DrugOrderIntroductionService.GetOldDrugOrderIntroductionDetsWithDate(this._DrugOrderIntroduction.Episode, date);
        this.tempDrugOrders = oldOrders.TempDrugOrders;
        this.totalCount = this.getGroupCount('OrderDate', this.tempDrugOrders);
    }

    getGroupCount(groupField: string, DrugOrders: Array<TempDrugOrder>) {
        return query(DrugOrders)
            .groupBy(groupField)
            .toArray().length;
    }

   
    onToolbarPreparing(e) {
        e.toolbarOptions.items.unshift({
            location: 'before',
            template: 'totalGroupCount'
        }, {
                location: 'before',
                widget: 'dxSelectBox',
                options: {
                    width: 200,
                    items: [{
                        value: 'DrugName',
                        text: i18n("M16280", "İlaca Göre Grupla ")
                    }],
                    displayExpr: 'text',
                    valueExpr: 'value',
                    value: 'OrderDate',
                    onValueChanged: this.groupChanged.bind(this)//hataveren yer!! _co.valueChanged is not a function
                }
            }, {
                location: 'before',
                widget: 'dxButton',
                options: {
                    hint: i18n("M15727", "Hepsini Kapat"),
                    icon: 'chevrondown',
                    onClick: this.collapseAllClick.bind(this)
                }
            },
            {
                location: 'before',
                widget: 'dxButton',
                options: {
                    hint: i18n("M21544", "Seçilenleri Tekrarla"),
                    icon: 'repeat',
                    onClick: this.selectedItemRepeatClick.bind(this)
                }
            },
            {
                location: 'before',
                widget: 'dxButton',
                options: {
                    hint: i18n("M30013", "Tümünü Getir"),
                    icon: 'fa fa-align-justify',
                    onClick: this.GetDrugOrderIntroductions.bind(this)
                }
            },
            {
                location: 'before',
                widget: 'dxButton',
                options: {
                    hint: i18n("M21545", "Seçilenleri Temizle"),
                    icon: 'clear',
                    onClick: this.clearSelectedItemClick.bind(this)
                }
            },
            // {
            //     location: 'before',
            //     widget: 'dxCheckBox',
            //     options: {
            //         //hint: i18n("M21545", "Ertesi Güne Tekrarla"),
            //         text: "Ertesi Güne Tekrarla",
            //         onClick: this.setNextDayOrder.bind(this)
            //     }
            // },
            {
                location: 'after',
                widget: 'dxButton',
                options: {
                    icon: 'refresh',
                    onClick: this.refreshDataGrid.bind(this)
                }
            },
        );
    }

    groupChanged(e) {
        this.dataGridInstance.instance.clearGrouping();
        this.dataGridInstance.instance.columnOption(e.value, 'groupIndex', 0);
        this.totalCount = this.getGroupCount(e.value, this.tempDrugOrders);
    }

   

   
    collapseAllClick(e) {
        this.expanded = !this.expanded;
        e.component.option({
            icon: this.expanded ? 'chevrondown' : 'chevronnext',
            hint: this.expanded ? i18n("M15727", "Hepsini Kapat") : i18n("M15725", "Hepsini Aç")
        });
    }

    private MultiClickControlOnRepeat: boolean = false;
    async selectedItemRepeatClick(e) {

        if (this.MultiClickControlOnRepeat) {

        } else {
            this.MultiClickControlOnRepeat = true;
            try {
                if (this.selectedTempItems.length > 0) {
                    let bTarih: Date = new Date();
                    if (bTarih === null) {
                        TTVisual.InfoBox.Alert(i18n("M12872", "Direktif Tekrardan vazgeçildi"));
                    }
                    else {
                        this.orderPlannedDateEligable = '';
                        //Seçilen ilaçlar
                        let newAddedMaterialObjectIDList: Array<Guid> = new Array<Guid>();
                        this.selectedTempItems.forEach(element => {
                            newAddedMaterialObjectIDList.push(element.MaterialObjectID);
                        });
                        let errorMsg = '';
                        let error = false;
                        let input = { 'episode': this._DrugOrderIntroduction.Episode, 'newAddedMaterialObjectIDList': newAddedMaterialObjectIDList };
                        let controlOfActiveIngredient: Array<ControlOfActiveIngredientForRepeat_Output> = await this.http.post<Array<ControlOfActiveIngredientForRepeat_Output>>('api/DrugOrderIntroductionService/ControlOfActiveIngredientForRepeatedDrugs', input);
                        for (let activeDrugIngredient of controlOfActiveIngredient) {
                            let message: string;

                            message = activeDrugIngredient.CrossActiveIngridientNames + ' etken maddeye sahip ';
                            message += activeDrugIngredient.ComparedDrugDef.Name + ' isimli ilaç ';

                            activeDrugIngredient.CrossedActiveIngridientDrugs.forEach(element => {
                                message += element.ActiveIngridientCrossedDrugName + ', ';
                            });
                            message += ' isimli ilaç/ilaçlar ile' + ' aynı etken maddeye sahiptir.';

                            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), 'Etken Madde Etkileşimi',
                                message + i18n("M12687", "Devam Etmek İstiyor Musunuz?"));
                            if (result === 'V') {
                                this.selectedTempItems = this.selectedTempItems.filter(x => x.MaterialObjectID != activeDrugIngredient.ComparedDrugDef.ObjectID);
                                errorMsg = errorMsg + "Vazgeçildi";
                                error = true;
                            }
                        }

                        for (let oldDrug of this.selectedTempItems) {
                            let rptDrugOrderIntroductionDet: DrugOrderIntroductionDet = await DrugOrderIntroductionService.GetDrugOrderIntroductionDet(oldDrug.OrderObjectID);
                            let drugOrderIntroductionDet: DrugOrderIntroductionDet = new DrugOrderIntroductionDet();
                            let matobjID: Guid = <any>rptDrugOrderIntroductionDet['Material'];
                            let material: Material = await this.objectContextService.getObject<Material>(matobjID, DrugDefinition.ObjectDefID);
                            let rptPlannedStartDate = new Date(rptDrugOrderIntroductionDet.PlannedStartTime.toString());
                            let today = new Date(Date.now());
                            if (oldDrug.NextDayOrder && rptDrugOrderIntroductionDet.Frequency === FrequencyEnum.Q24H) {
                                let newPlannedStartTime;
                                newPlannedStartTime = new Date(today.getFullYear(), today.getMonth(), today.getDate(), rptPlannedStartDate.getHours(), rptPlannedStartDate.getMinutes(), 0);
                                drugOrderIntroductionDet.PlannedStartTime = newPlannedStartTime.AddDays(1);
                                drugOrderIntroductionDet.NextDayOrder = oldDrug.NextDayOrder;
                            }
                            else {
                                //drugOrderIntroductionDet.PlannedStartTime = await DrugOrderIntroductionService.GetPlannedStartTime(rptDrugOrderIntroductionDet.Frequency, new Date(Date.now()));
                                drugOrderIntroductionDet.PlannedStartTime = new Date(today.getFullYear(), today.getMonth(), today.getDate(), rptPlannedStartDate.getHours(), rptPlannedStartDate.getMinutes(), 0);
                            }
                            if (drugOrderIntroductionDet.PlannedStartTime < today.AddHours(-this.drugOrderTimeOffset)) {
                                this.isPlannedDateEligable = false;
                                this.orderPlannedDateEligable += material.Name + ' - ';
                            }
                            this._DrugOrderIntroduction.PlannedStartTime = drugOrderIntroductionDet.PlannedStartTime;
                            let rptDayOutput: ControlRepeatDay_Output = await DrugOrderIntroductionService.ControlRepeatDay(material.ObjectID, this._DrugOrderIntroduction.Episode, this._DrugOrderIntroduction.PlannedStartTime);
                            if (rptDayOutput.isWarning === true) {
                                TTVisual.InfoBox.Alert('Tekrar Gün', rptDayOutput.warningMessage, MessageIconEnum.InformationMessage);
                            } else {

                                if (this.IsExistingDrugOrderValidate(this.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.DrugOrderIntroductionDetails, matobjID.toString())) {
                                    TTVisual.InfoBox.Alert(drugOrderIntroductionDet.Material.Name + " daha öncesinden eklenmiştir.");
                                } else {
                                    //Description of the material will be displayed if it exists.
                                    if (String.isNullOrEmpty(material.Description) === false) {
                                        //ServiceLocator.MessageService.showInfo(material.Description);
                                        TTVisual.InfoBox.Alert('Açıklama', material.Description, MessageIconEnum.InformationMessage);
                                    }
                                    drugOrderIntroductionDet.Material = material;
                                    // let pDate: Date = new Date(rptDrugOrderIntroductionDet.PlannedStartTime.toString());
                                    // let copyDate: Date = new Date(bTarih.getFullYear(), bTarih.getMonth(), bTarih.getDate(), pDate.getHours(), pDate.getMinutes(), pDate.getSeconds(), pDate.getMilliseconds());
                                    // drugOrderIntroductionDet.PlannedStartTime = copyDate;
                                    drugOrderIntroductionDet.Day = 1;
                                    drugOrderIntroductionDet.DoseAmount = rptDrugOrderIntroductionDet.DoseAmount;
                                    drugOrderIntroductionDet.Frequency = rptDrugOrderIntroductionDet.Frequency;
                                    drugOrderIntroductionDet.IsImmediate = rptDrugOrderIntroductionDet.IsImmediate;
                                    drugOrderIntroductionDet.DrugUsageType = rptDrugOrderIntroductionDet.DrugUsageType;
                                    drugOrderIntroductionDet.CaseOfNeed = rptDrugOrderIntroductionDet.CaseOfNeed;
                                    drugOrderIntroductionDet.PatientOwnDrug = rptDrugOrderIntroductionDet.PatientOwnDrug;
                                    drugOrderIntroductionDet.Day = 1;
                                    drugOrderIntroductionDet.DoseAmount = rptDrugOrderIntroductionDet.DoseAmount;
                                    drugOrderIntroductionDet.PeriodUnitType = rptDrugOrderIntroductionDet.PeriodUnitType;
                                    drugOrderIntroductionDet.PackageAmount = rptDrugOrderIntroductionDet.PackageAmount;
                                    drugOrderIntroductionDet.DrugDescription = this._DrugOrderIntroduction.DrugDescription;
                                    drugOrderIntroductionDet.UsageNote = this._DrugOrderIntroduction.DrugDescription;
                                    drugOrderIntroductionDet.DrugUsageType = rptDrugOrderIntroductionDet.DrugUsageType;
                                    drugOrderIntroductionDet.DrugOrderType = rptDrugOrderIntroductionDet.DrugOrderType;
                                    drugOrderIntroductionDet.UsageNote = rptDrugOrderIntroductionDet.UsageNote;

                                    await this.addToDrugOrderIntroductionDetailsWithValidation(this._DrugOrderIntroduction.DrugOrderIntroductionDetails, drugOrderIntroductionDet); //this._DrugOrderIntroduction.DrugOrderIntroductionDetails.push(drugOrderIntroductionDet);
                                    let res: CreateDrugOrderTSViewModel = await this.CreateDrugOrderTSAndLoadEpisode(this._DrugOrderIntroduction, drugOrderIntroductionDet);
                                    let drugOrder = res.DrugOrder;
                                    drugOrderIntroductionDet.DrugOrder = drugOrder;
                                    this.drugOrderIntroductionNewFormViewModel.DrugOrders.push(drugOrder);
                                    this.drugOrderIntroductionNewFormViewModel.DrugOrderIntroductionDetailsGridList.push(drugOrderIntroductionDet);
                                    drugOrder.DrugOrderDetails.forEach(element => {
                                        this.drugOrderIntroductionNewFormViewModel.DrugOrderDetails.push(element);
                                    });

                                    let drug: DrugDefinition = <DrugDefinition>material;
                                    if (drug.DrugNutrientInteraction != null)
                                        TTVisual.InfoBox.Alert("İlaç Besin Etkileşimi Bulunmaktadır! ", drug.DrugNutrientInteraction, MessageIconEnum.InformationMessage);

                                    if (drugOrder.Type === "Yatan Hasta Reçetesi") {
                                        await this.addInpatientPres(drugOrder, <DrugDefinition>rptDrugOrderIntroductionDet.Material);
                                    }
                                    this.addingDruglist.push(material.ObjectID.toString());
                                }
                            }

                            if (!this.isPlannedDateEligable) {
                                this.isPlannedDateEligable = true;
                                this.orderPlannedDateEligable += ' ilaç/ilaçlara ait order zamanlarını düzenleyiniz.';
                                await TTVisual.InfoBox.Alert(this.orderPlannedDateEligable);
                            }
                            this.selectedTempItems = new Array<TempDrugOrder>();
                        }
                    }
                }
            } catch (ex) {
                this.MultiClickControlOnRepeat = false;
            }
            this.MultiClickControlOnRepeat = false;
        }
    }

    clearSelectedItemClick(e) {
        this.selectedTempItems = new Array<TempDrugOrder>();
    }

    refreshDataGrid() {
        this.dataGridInstance.instance.refresh();
    }

    public async changeDrugOrderClick(data: any) {
        let drugOrderDetails: Array<DrugOrderDetail> = await DrugOrderIntroductionService.GetActiveDrugOrderDetails(data.data.OrderObjectID);
        if (drugOrderDetails.length > 0)
            this.showDrugOrderSchedule(drugOrderDetails).then(res => {
                let modalActionResult = res as ModalActionResult;
                if (modalActionResult.Result === DialogResult.OK)
                    DrugOrderIntroductionService.UpdateDrugOrderDetails(res.Param as Array<DrugOrderDetail>).then(result => {
                        if (result)
                            ServiceLocator.MessageService.showSuccess('Güncelleme başarılı.');
                        else
                            ServiceLocator.MessageService.showError('Güncelleme yapılırken bir hata oluştu!');
                    });
            });
        else
            ServiceLocator.MessageService.showInfo('Bu Order için güncellenecek veri bulunmamaktadır.');
    }

    selectionChange(value: any) {

        let approvedTransactionCount: number = 0; //Onaylanacak statusü dışındaki işlemler

        for (let i = 0; i < value.currentSelectedRowKeys.length; i++) {
            if (value.currentSelectedRowKeys[i].OrderStatus === i18n("M12685", "Devam Ediyor")) {//"Onayla"
                approvedTransactionCount++;
                value.component.deselectRows(value.currentSelectedRowKeys[i]);
            }
        }
        // tslint:disable-next-line:curly
        // if (approvedTransactionCount > 0)
        //     this.messageService.showInfo(i18n("M12682", "Devam eden orderi tekrarlayamazsınız."));
    }

    onValueChangedFrequency(e) {
        if (e.value === '1X1') {
            this._DrugOrderIntroduction.OrderFrequency = 1;
            this._DrugOrderIntroduction.OrderDose = 1;
            this.NextDayCheck.Visible = true;
            this.nextDayOrderVisible = true;
        }
        if (e.value === '2X1') {
            this._DrugOrderIntroduction.OrderFrequency = 2;
            this._DrugOrderIntroduction.OrderDose = 1;
            this.NextDayCheck.Visible = true;
            this.nextDayOrderVisible = false;
            this.selectedPlannedStartTime = new Date(Date.now());
        }
        if (e.value === '3X1') {
            this._DrugOrderIntroduction.OrderFrequency = 3;
            this._DrugOrderIntroduction.OrderDose = 1;
            this.NextDayCheck.Visible = true;
            this.nextDayOrderVisible = false;
            this.selectedPlannedStartTime = new Date(Date.now());
        }
    }

    onTabItemRendered(e: any) {
        if (e.itemData.title === i18n("M10661", "Aktif İlaçlar")) {
            let that = this;
            if (that._scheduler !== undefined) {
                setTimeout(function () {
                    that._scheduler.instance.repaint();
                }, 50);
            }
        }
        if (e.itemData.title === i18n("M10660", "Aktif İlaç Planlamaları")) {
            let that = this;
            if (that._detailScheduler !== undefined) {
                setTimeout(function () {
                    that._detailScheduler.instance.repaint();
                }, 50);
            }
        }
    }

    ngAfterViewInit() {
        let that = this;
        if (that._scheduler !== undefined) {
            setTimeout(function () {
                that._scheduler.instance.repaint();
            }, 50);
        }
    }

    public queryStartDateForActiveDrugOrders: Date;
    public queryEndDateForActiveDrugOrders: Date;

    async onOptionChanged(event) {
        if (event != null && event.name === "currentDate") {
            this.queryStartDateForActiveDrugOrders = new Date(event.value).AddDays(-7);
            this.queryEndDateForActiveDrugOrders = new Date(event.value).AddDays(7);
            let plannedStartDate: Date = new Date();
            plannedStartDate = plannedStartDate.AddDays(this.DrugOrderQueryDayNumber);
            let activeDrugOrders: ActiveDrugOrders = await DrugOrderIntroductionService.GetActiveDrugOrders(this._DrugOrderIntroduction.Episode, this.queryStartDateForActiveDrugOrders, this.queryEndDateForActiveDrugOrders);
            this.appointmentsData = activeDrugOrders.Orders;
            this.resourcesData = activeDrugOrders.Drugs;
            this.orderDetailData = activeDrugOrders.OrderDetails;
            this.detailResourcesData = activeDrugOrders.DetailDrugs;
        }
    }

    async onAppointmentUpdated(e: any) {
        let updateOrderDetail: OrderDetail = <OrderDetail>e.appointmentData;
        let result: UpdateOrderDetail_Output = await DrugOrderIntroductionService.UpdateOrderDetail(updateOrderDetail);
        if (result.detailUpdate === false) {
            let plannedStartDate: Date = new Date();
            plannedStartDate = plannedStartDate.AddDays(this.DrugOrderQueryDayNumber);
            let activeDrugOrders: ActiveDrugOrders = await DrugOrderIntroductionService.GetActiveDrugOrders(this._DrugOrderIntroduction.Episode, this.queryStartDateForActiveDrugOrders, this.queryEndDateForActiveDrugOrders);
            this.appointmentsData = activeDrugOrders.Orders;
            this.resourcesData = activeDrugOrders.Drugs;
            this.orderDetailData = activeDrugOrders.OrderDetails;
            TTVisual.InfoBox.Alert(result.errorDescription, MessageIconEnum.ErrorMessage);
            let that = this;
            setTimeout(function () {
                that._detailScheduler.instance.repaint();
            }, 50);
        }
    }

    onAppointmentClick(e: any) {
        e.cancel = false;
    }

    onAppointmentDblClick(e: any) {
        e.cancel = true;
    }

    private openDetail(data: string): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DrugOrderDetailForm';
            componentInfo.ModuleName = 'TedaviIlacUgulamaModule';
            componentInfo.ModulePath = 'Modules/Saglik_Lojistik/Eczane_Modulleri/Tedavi_Ilac_Ugulama_Modulu/TedaviIlacUgulamaModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, new ActiveIDsModel(this._DrugOrderIntroduction.ObjectID, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M23747", "Uygulama");
            modalInfo.Width = 800;
            modalInfo.Height = 400;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    async openOrderDetail(value: any): Promise<void> {
        this.openDetail(value);
    }

    editDetails(orderDetail: any) {
        this.openDetail(orderDetail.id);
    }

    async stopOrder(order: any) {
        let result: string = await DrugOrderIntroductionService.StopDrugOrder(order.id);
        TTVisual.InfoBox.Alert(result);
        let activeDrugOrders: ActiveDrugOrders = await DrugOrderIntroductionService.GetActiveDrugOrders(this._DrugOrderIntroduction.Episode, this.queryStartDateForActiveDrugOrders, this.queryEndDateForActiveDrugOrders);
        this.appointmentsData = activeDrugOrders.Orders;
        this.resourcesData = activeDrugOrders.Drugs;
        this.orderDetailData = activeDrugOrders.OrderDetails;
        let user: ResUser = await UserHelper.CurrentResource;
        this.favoriteDrugs = await FavoriteDrugService.GetFavoriteDrugsWithResUser(user.ObjectID, this.isInheldDrugList, new Array<DrugIngredient>());

        //this.loadOldDrugOrders();

        let date: Date = new Date();
        date = date.AddDays(this.DrugOrderQueryDayNumber);
        this.GetDrugOrderIntroductionsWithDate(date);
    }

    private checkEquivalent(equivalentDrugs: Array<DrugInfo>): Promise<Material> {
        return new Promise<Material>((resolve, reject) => {
            if (equivalentDrugs.length > 0) {
                let drugObjectid: any = null;
                this.showEquivalentDrug(equivalentDrugs).then(result => {
                    let modalActionResult = result as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        let obj = result.Param as DrugInfo;
                        drugObjectid = obj.drugObjectId;
                        if (drugObjectid !== null) {
                            this.objectContextService.getObject<Material>(drugObjectid, DrugDefinition.ObjectDefID).then(mat => resolve(mat)).catch(error => reject(error));
                        } else {
                            resolve(null);
                        }
                    } else {
                        resolve(null);
                    }
                }).catch(err => reject(err));
            } else {
                resolve(null);
            }
        });
    }

    private showEquivalentDrug(data: Array<DrugInfo>): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DrugEquivalentComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, new ActiveIDsModel(this._DrugOrderIntroduction.ObjectID, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M13913", "Eşdeğer İlaçlar");
            modalInfo.Width = 600;
            modalInfo.Height = 400;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    private showDrugOrderSchedule(data: Array<DrugOrderDetail>): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DrugOrderScheduleComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, new ActiveIDsModel(this._DrugOrderIntroduction.ObjectID, null, null));

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

    private showUserTemplate(data: ResUser): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DrugTemplateSelectComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, new ActiveIDsModel(this._DrugOrderIntroduction.ObjectID, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M17918", "Kullanıcı Şablonları");
            modalInfo.Width = 1200;
            modalInfo.Height = 600;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    protected async setState(transDef: TTObjectStateTransitionDef) {
        try {
            if (this.isVademecumEntegrasyon === true) {
                let result = await this.showDrugInteractions();
                if (result === DialogResult.Cancel) {
                    TTVisual.InfoBox.Alert(i18n("M16907", "İşlemden vazgeçildi"));
                    return;
                }

                if (result === DialogResult.OK) {
                    this.reThrowSetStateException = true;
                    await super.setState(transDef);
                    if (this._modalInfo !== undefined) {
                        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this._DrugOrderIntroduction);
                    }
                }
            } else {
                this.reThrowSetStateException = true;
                await super.setState(transDef);
                if (this._modalInfo !== undefined) {
                    this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this._DrugOrderIntroduction);
                }
            }
        } catch (err) {
            TTVisual.InfoBox.Alert(err);
        }
    }

    protected async save() {
        try {
            if (this.isVademecumEntegrasyon === true) {
                let result = await this.showDrugInteractions();
                if (result === DialogResult.Cancel) {
                    throw new TTException(i18n("M16907", "İşlemden vazgeçildi"));
                }

                if (result === DialogResult.OK) {
                    await super.save();
                    this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this._DrugOrderIntroduction);
                }
            } else {
                await super.save();
                this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this._DrugOrderIntroduction);
            }
        } catch (err) {
            TTVisual.InfoBox.Alert(err);
        }
    }

    public cancel() {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }
    // ***** Method declarations start *****

    getDrugById(id) {
        for (let i = 0; i < this.resourcesData.length; i++) {
            if (this.resourcesData[i].id === id) {
                return this.resourcesData[i];
            }
        }
        return null;
    }

    public async onSelectionChanged(e: any) {
        this.searchText = '';
        if (e.value === true) {

            if (this.favoriteDrugs === undefined) {
                let user: ResUser = await UserHelper.CurrentResource;
                this.favoriteDrugs = await FavoriteDrugService.GetFavoriteDrugsWithResUser(user.ObjectID, this.isInheldDrugList, new Array<DrugIngredient>());
            }

            this.drugSource = new DataSource({
                store: this.favoriteDrugs,
                searchOperation: 'contains',
                searchExpr: 'name'
            });
            this.isPatientOwnDrug = false;
        } else {
            if (this.isPatientOwnDrug === false) {
                this.drugSource = new DataSource({
                });
            }
        }
    }

    onOwnDrugClicked(e: any) {
        //this.searchText = '';
        if (e.value === true) {
            this.drugSource = new DataSource({
                store: this.patientOwnDrugs,
                searchOperation: 'contains',
                searchExpr: 'name'
            });
            this._DrugOrderIntroduction.PatientOwnDrug = true;
            this.isFavoriteDrugList = false;
            this.isInheldDrugList = false;
        } else {
            if (this.isFavoriteDrugList === false) {
                this.drugSource = new DataSource({
                });
            }
            this._DrugOrderIntroduction.PatientOwnDrug = false;
        }
        this.initFormControls();
    }

    async onInheldClicked(event) {
        if (this.isFavoriteDrugList === true) {
            let user: ResUser = await UserHelper.CurrentResource;
            this.favoriteDrugs = await FavoriteDrugService.GetFavoriteDrugsWithResUser(user.ObjectID, this.isInheldDrugList, new Array<DrugIngredient>());
            this.drugSource = new DataSource({
                store: this.favoriteDrugs,
            });
            this.drugSource.searchValue(this.searchText);
            this.drugSource.load();
        } else if (this.isInheldDrugList) {
            let drugs: Array<DrugInfo> = await DrugOrderIntroductionService.SearchDrug(this.searchText, this.isInheldDrugList, new Array<DrugIngredient>());
            this.drugSource = new DataSource({
                store: drugs,
            });
        } else {

            let drugs: Array<DrugInfo> = new Array<DrugInfo>();
            this.drugSource = new DataSource({

            });
        }
    }

    async search(e) {
        if (this.isFavoriteDrugList === false) {
            if (e.value.length === 0) {
                this.drugSource = new DataSource({
                });
            }
            if (e.value.length > 2) {
                let drugs: Array<DrugInfo> = await DrugOrderIntroductionService.SearchDrug(e.value.toString(), this.isInheldDrugList, new Array<DrugIngredient>());
                this.drugSource = new DataSource({
                    store: drugs,
                });
            }
        }

        if (this.isFavoriteDrugList === true) {
            if (this.drugSource !== undefined) {
                this.drugSource.searchValue(e.value);
                this.drugSource.load();
            }
        }
    }

    selectedChangeFavoriteDrug(e) {
        if (e.itemData !== null) {
            let drugGuid: Guid = new Guid(e.itemData.DrugDefinition);
            if (this.isInpatient === true && this._DrugOrderIntroduction.IsConsultaitonOrder === true && e.itemData.inheldStatus === 'Var') {
                TTVisual.InfoBox.Alert(i18n("M24396", "Yatan hasta için Eczanede mevcudu olan ilacı Order ekranından yazabilirsiniz. "), MessageIconEnum.ErrorMessage);
                return;
            }


            this._DrugOrderIntroduction.DrugName = e.itemData.barcode + " " + e.itemData.Name;
            this._DrugOrderIntroduction.DrugObjectID = drugGuid;
            this._DrugOrderIntroduction.OrderFrequency = 1;
            this._DrugOrderIntroduction.OrderDose = 1;
            this._DrugOrderIntroduction.OrderDay = 1;
            this._DrugOrderIntroduction.DrugUsageType = e.itemData.drugUsageTypeEnum;
            this.isRequiedForm = e.itemData.PatientSafetyFrom;
            this._DrugOrderIntroduction.PackageAmount = 1;
            this._DrugOrderIntroduction.PeriodUnitType = PeriodUnitTypeEnum.DayPeriod;
            this.patientOwnDrugAmount = <number>e.itemData.inheldStatus;
            this.eventRadioGroup.value = '1X1';
            if (this.isOutpatient === true) {
                this._DrugOrderIntroduction.DrugDescriptionType = DescriptionTypeEnum.DiagnosticDescription;
            }
            if (e.itemData.inheldStatus === 'Var') {
                this.isInheld = true;
            } else if (e.itemData.inheldStatus === 'Yok') {
                this.isInheld = false;
            } else if (e.itemData.inheldStatus === '0') {
                this.isInheld = false;
            } else {
                this.isInheld = true;
            }
        } else {
            this._DrugOrderIntroduction.DrugName = '';
            this._DrugOrderIntroduction.DrugObjectID = null;
        }
        this.initFormControls();
    }

    drugReportNo: string;
    async selectedChange(e) {
        if (e.itemData !== null) {

            let drugGuid: Guid = new Guid(e.itemData.drugObjectId);
            this.setDefaultNextDayValues(true);
            /*if (e.itemData.prescriptionTypeEnum === PrescriptionTypeEnum.RedPrescription && this.isInpatient === true) {
                if (e.itemData.inheldStatus === 'Yok') {
                    TTVisual.InfoBox.Alert('Kırmızı Reçete için Renkli Reçete Uygulamasını kullanmalısınız.', MessageIconEnum.ErrorMessage);
                    return;
                }
            }
            if (e.itemData.prescriptionTypeEnum === PrescriptionTypeEnum.GreenPrescription && this.isInpatient === true) {
                if (e.itemData.inheldStatus === 'Yok') {
                    TTVisual.InfoBox.Alert('Yeşil Reçete için Renkli Reçete Uygulamasını kullanmalısınız.', MessageIconEnum.ErrorMessage);
                    return;
                }
            }*/


            if (e.itemData.DrugReportType === DrugReportType.RaporlaOdenir && this.IsSGK) {
                let input: GetDrugReportNo_Input = new GetDrugReportNo_Input();
                input.DrugID = drugGuid;
                input.EpisodeID = this._DrugOrderIntroduction.Episode.ObjectID;
                await this.http.post<string>('api/DrugOrderIntroductionService/GetDrugReportNo', input).then(result => {
                    this.drugReportNo = result;
                }).catch(err => {
                    TTVisual.InfoBox.Alert(err);
                    return;
                });

            }
            if (this.patientAllergicDrug.length > 0) {
                for (let drugActiveIngredient of e.itemData.ActiveIngeridents) {
                    if (this.patientAllergicDrug.find(x => x === drugActiveIngredient.Objectid) != null) {
                        TTVisual.InfoBox.Alert('Hastanın ' + drugActiveIngredient.Name + ' etken maddesine allerjisi vardır. Bu ilacı yazamazsınız.', MessageIconEnum.ErrorMessage);
                        return;
                    }
                }
            }

            if (this.isInpatient === true && this._DrugOrderIntroduction.IsConsultaitonOrder === true && e.itemData.inheldStatus === 'Var') {
                TTVisual.InfoBox.Alert(i18n("M24396", "Yatan hasta için Eczanede mevcudu olan ilacı Order ekranından yazabilirsiniz. "), MessageIconEnum.ErrorMessage);
                return;
            }
            let labInteractions: Array<CheckLabProcedure_Output> = await DrugOrderIntroductionService.CheckLabProcedure(drugGuid, this._DrugOrderIntroduction.Episode);
            if (labInteractions.length > 0) {
                for (let interaction of labInteractions) {
                    let message: string = interaction.interactionLabProcedure + '<br />' + interaction.interactionMessage + '<br />';
                    let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), 'Lab Sonuç Etkileşimi',
                        message + i18n("M12687", "Devam Etmek İstiyor Musunuz?"));
                    if (result === 'V') {
                        return;
                    }
                }
            }
            this._DrugOrderIntroduction.DrugName = e.itemData.barcode + " " + e.itemData.name;
            this._DrugOrderIntroduction.DrugObjectID = drugGuid;
            this._DrugOrderIntroduction.OrderFrequency = 1;
            this._DrugOrderIntroduction.OrderDose = 1;
            this._DrugOrderIntroduction.OrderDay = 1;
            this._DrugOrderIntroduction.DrugUsageType = e.itemData.drugUsageTypeEnum;
            this.isRequiedForm = e.itemData.PatientSafetyFrom;
            this._DrugOrderIntroduction.PackageAmount = 1;
            this._DrugOrderIntroduction.PeriodUnitType = PeriodUnitTypeEnum.DayPeriod;
            this.patientOwnDrugAmount = <number>e.itemData.inheldStatus;
            if (this.isOutpatient === true) {
                this._DrugOrderIntroduction.DrugDescriptionType = DescriptionTypeEnum.DiagnosticDescription;
            }
            this.eventRadioGroup.value = '1X1';
            if (e.itemData.inheldStatus === 'Var') {
                this.isInheld = true;
            } else if (e.itemData.inheldStatus === 'Yok') {
                this.isInheld = false;
            } else if (e.itemData.inheldStatus === '0') {
                this.isInheld = false;
            } else {
                this.isInheld = true;
            }

        } else {
            this._DrugOrderIntroduction.DrugName = '';
            this._DrugOrderIntroduction.DrugObjectID = null;
        }
        this.initFormControls();
    }

    private async AutoSearch_CheckedChanged(): Promise<void> {
        if (<boolean>this._DrugOrderIntroduction.AutoSearch) {
            this.cmdSearch.Enabled = false;
        } else {
            this.cmdSearch.Enabled = true;
        }
    }

    public nextDayOrderVisible = false;

    public async setPlannedStartTime(detailCount: number): Promise<void> {
        if (this.NextDayOrder1x1) {
            this._DrugOrderIntroduction.PlannedStartTime = this.selectedPlannedStartTime;
        }
        else
            this._DrugOrderIntroduction.PlannedStartTime = await DrugOrderIntroductionService.GetPlannedStartTime(detailCount, this.selectedPlannedStartTime);
    }

    public async cmdAddDrug_Click(): Promise<void> {
        let errorMsg: string = '';
        let error: boolean = false;
        let currentDate: Date = new Date();

        let orderFreq = this._DrugOrderIntroduction.OrderFrequency != null ? this._DrugOrderIntroduction.OrderFrequency.toString() : '-1';
        switch (orderFreq) {
            case '1':
                {
                    await this.setPlannedStartTime(FrequencyEnum.Q24H);
                    break;
                }
            case '2':
                {
                    await this.setPlannedStartTime(FrequencyEnum.Q12H);
                    break;
                }
            case '3':
                {
                    await this.setPlannedStartTime(FrequencyEnum.Q8H);
                    break;
                }
            case '4':
                {
                    await this.setPlannedStartTime(FrequencyEnum.Q6H);
                    break;
                }
            case '6':
                {
                    await this.setPlannedStartTime(FrequencyEnum.Q4H);
                    break;
                }
            case '8':
                {
                    await this.setPlannedStartTime(FrequencyEnum.Q3H);
                    break;
                }
            case '12':
                {
                    await this.setPlannedStartTime(FrequencyEnum.Q2H);
                    break;
                }
            case '24':
                {
                    await this.setPlannedStartTime(FrequencyEnum.Q1H);
                    break;
                }
            default:
                {
                    TTVisual.InfoBox.Alert(i18n("M24473", "Yazdığınız doz aralığı planlamaya uygun değildir."), MessageIconEnum.ErrorMessage);
                    return;
                }
        }
        let plannnedDate: Date = new Date(this._DrugOrderIntroduction.PlannedStartTime.toString());

        let himssIntegrated: string = (await SystemParameterService.GetParameterValue('HIMSSINTEGRATED', 'TRUE'));
        if (himssIntegrated === 'TRUE') {
            if (this._DrugOrderIntroduction.MasterResource !== null && this._DrugOrderIntroduction.MasterResource !== undefined) {
                let masterResourceItem = this._DrugOrderIntroduction['MasterResource'];
                if (masterResourceItem != null && (typeof masterResourceItem === 'string')) {
                    let objID: Guid = <any>this._DrugOrderIntroduction['MasterResource'];
                    let masterResource: ResSection = await this.objectContextService.getObject<ResSection>(objID, ResSection.ObjectDefID);
                    if (masterResource.HimssRequired !== null && masterResource !== undefined) {
                        if (masterResource.HimssRequired === true) {
                            if (currentDate > plannnedDate) {
                                errorMsg = errorMsg + 'Uygulama tarihi geçmiş tarih olamaz. <br />';
                                error = true;
                            } else {
                                await this.signService.showLoginModal();
                            }
                        }
                    }
                } else {
                    let masterResource: ResSection = this._DrugOrderIntroduction.MasterResource;
                    if (masterResource.HimssRequired !== null && masterResource !== undefined) {
                        if (masterResource.HimssRequired === true) {
                            if (currentDate > plannnedDate) {
                                errorMsg = errorMsg + 'Uygulama tarihi geçmiş tarih olamaz. <br />';
                                error = true;
                            } else {
                                await this.signService.showLoginModal();
                            }
                        }
                    }
                }
            }
        }





        if (this.addingDruglist.some(x => x === this._DrugOrderIntroduction.DrugObjectID.toString())) {
            errorMsg = errorMsg + this._DrugOrderIntroduction.DrugName + i18n("M16581", " isimli ilaç daha önce eklendiği için ekleyemezsiniz. <br />");
            error = true;
        }
        if (this._DrugOrderIntroduction.OrderDay == null) {//-
            errorMsg = errorMsg + i18n("M12870", "Direktif günü boş olamaz. <br />");
            error = true;
        }
        if (this._DrugOrderIntroduction.PlannedStartTime == null) {//-
            errorMsg = errorMsg + i18n("M23753", "Uygulama Başlangıç Zamanı boş olamaz. <br />");
            error = true;
        }
        if (this._DrugOrderIntroduction.OrderDose == null) {//-
            errorMsg = errorMsg + i18n("M12868", "Direktif dozu boş olamaz. <br />");
            error = true;
        }
        if (this._DrugOrderIntroduction.OrderFrequency == null) {//-
            errorMsg = errorMsg + i18n("M12867", "Direktif doz aralığı boş olamaz. <br />");
            error = true;
        }
        /*let gunuBirlikHastaMi: boolean = this._DrugOrderIntroduction.SubEpisode.PatientAdmission.AdmissionType.provizyonTipiKodu.Equals("G");
        if (gunuBirlikHastaMi) {*/
        if (this._DrugOrderIntroduction.DrugUsageType == null) {//-
            errorMsg = errorMsg + 'Kullanım Şekli boş olamaz. <br />';
            error = true;
        }
        //}
        if (this._DrugOrderIntroduction.DrugObjectID == null) {//-
            errorMsg = errorMsg + i18n("M16362", "İlaç seçmediniz. <br />");
            error = true;
        }

        let material: any = await this.objectContextService.getObject(this._DrugOrderIntroduction.DrugObjectID, DrugDefinition.ObjectDefID);
        let drug: DrugDefinition = <DrugDefinition>material;
        if ((drug.PatientSafetyFrom !== undefined) && <boolean>drug.PatientSafetyFrom) {
            if (String.isNullOrEmpty(this._DrugOrderIntroduction.DrugDescription)) {
                errorMsg = errorMsg + drug.Name + i18n("M16281", " ilacı için Hasta Güvenlik ve İzleme Formu seri numarası girmelisiniz. \r\n"); //-
                error = true;
            }
        }
        if (drug.PrescriptionType === PrescriptionTypeEnum.GreenPrescription && this.isOutpatient === true) {
            errorMsg = errorMsg + i18n("M24640", " Yeşil Reçete için Renkli Reçete Uygulamasını kullanmalısınız. \r\n"); //-
            error = true;
        }
        if (drug.PrescriptionType === PrescriptionTypeEnum.RedPrescription && this.isOutpatient === true) {
            errorMsg = errorMsg + i18n("M17524", " Kırmızı Reçete için Renkli Reçete Uygulamasını kullanmalısınız. \r\n"); //-
            error = true;
        }

        if (this.isInpatient === true && this.isInheld === false) {
            if (drug.PrescriptionType === PrescriptionTypeEnum.RedPrescription && this._DrugOrderIntroduction.PatientOwnDrug === false) {
                errorMsg = errorMsg + i18n("M17524", " Kırmızı Reçete için Renkli Reçete Uygulamasını kullanmalısınız. \r\n"); //-
                error = true;
            }
            if (drug.PrescriptionType === PrescriptionTypeEnum.GreenPrescription && this._DrugOrderIntroduction.PatientOwnDrug === false) {
                errorMsg = errorMsg + i18n("M24640", " Yeşil Reçete için Renkli Reçete Uygulamasını kullanmalısınız. \r\n"); //-
                error = true;
            }
        }

        //Description of the drugDefinition will be displayed if it exists.
        //if (String.isNullOrEmpty(drug.Description) === false) {
        //ServiceLocator.MessageService.showInfo(material.Description);
        //TTVisual.InfoBox.Alert('Açıklama', drug.Description, MessageIconEnum.InformationMessage);
        //

        // let controlOfActiveIngredient: Array<ControlOfActiveIngredient_Output> = await DrugOrderIntroductionService.ControlOfActiveIngredient(drug.ObjectID, this._DrugOrderIntroduction.Episode, Guid.Empty);
        // if (controlOfActiveIngredient.length > 0) {
        //     for (let activeDrugIngredient of controlOfActiveIngredient) {
        //         let message: string = activeDrugIngredient.activeIngredient + " etken maddeli " + activeDrugIngredient.drug + " isimli ilaç bugun içerinde istenmiştir.";
        //         let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), 'Etken Madde Etkileşimi',
        //             message + i18n("M12687", "Devam Etmek İstiyor Musunuz?"));
        //         if (result === 'V') {
        //             errorMsg = errorMsg + "Vazgeçildi";
        //             error = true;
        //         }
        //     }
        // }

        let newAddedMaterialObjectIDList: Array<Guid> = new Array<Guid>();
        this.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.DrugOrderIntroductionDetails.forEach(element => {
            newAddedMaterialObjectIDList.push(element.Material.ObjectID);
        });
        newAddedMaterialObjectIDList.push(drug.ObjectID);
        let input = { 'episode': this._DrugOrderIntroduction.Episode, 'newAddedMaterialObjectIDList': newAddedMaterialObjectIDList, 'drug': drug.ObjectID };
        let controlOfActiveIngredient: Array<ControlOfActiveIngredientForRepeat_Output> = await this.http.post<Array<ControlOfActiveIngredientForRepeat_Output>>('api/DrugOrderIntroductionService/ControlOfActiveIngredientForRepeatedDrugs', input);
        for (let activeDrugIngredient of controlOfActiveIngredient) {
            if (this.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.DrugOrderIntroductionDetails.find(x => x.Material.ObjectID == activeDrugIngredient.ComparedDrugDef.ObjectID) == null) {
                let message: string = ""; //= activeDrugIngredient.activeIngredient + " etken maddeli " + activeDrugIngredient.drug + " isimli ilaç bugun içerisinde istenmiştir.";
                message += "<b>" + activeDrugIngredient.CrossActiveIngridientNames + "</b> etken maddeye sahip ";
                message += activeDrugIngredient.ComparedDrugDef.Name + " isimli ilaç";

                let isRequestedInDayTrueCount = 0;
                let isRequestedInDayFalseCount = 0;

                for (let item of activeDrugIngredient.CrossedActiveIngridientDrugs.filter(x => x.IsRequestedInDay == true)) {

                    if (isRequestedInDayTrueCount == 0) {
                        message += " bugün içerisinde istenen ";
                        isRequestedInDayTrueCount++;
                    }

                    message += item.ActiveIngridientCrossedDrugName + "</b>, ";
                }
                for (let item of activeDrugIngredient.CrossedActiveIngridientDrugs.filter(x => x.IsRequestedInDay == false)) {
                    if (isRequestedInDayFalseCount == 0) {
                        message += " listede bulunan ";
                        isRequestedInDayFalseCount++;
                    }
                    message += item.ActiveIngridientCrossedDrugName + ", ";
                }

                message += " isimli ilaç/ilaçlar ile aynı etken maddeye sahiptir. Bilginize.</br></br>";
                let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), 'Etken Madde Etkileşimi',
                    message + i18n("M12687", "Devam Etmek İstiyor Musunuz?"));
                if (result === 'V') {
                    errorMsg = errorMsg + "Vazgeçildi";
                    error = true;
                }
            }
        }

        let url = '/api/DrugOrderIntroductionService/ControlOfDrugSpecificationNewDrugIntroduction?drugObjectID=' + drug.ObjectID + '&patientObjectID=' + this._DrugOrderIntroduction.Episode.Patient.ObjectID;
        let message = await this.http.get<string>(url);
        if (!String.isNullOrEmpty(message)) {
            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), 'Özellikli İlaç', message + i18n("M12687", "Devam Etmek İstiyor Musunuz?"));
            if (result === 'V') {
                errorMsg = errorMsg + "Vazgeçildi";
                error = true;
            }
        }


        let newDetails: Array<ControlOfOverDoseActiveIngredient_Details> = new Array<ControlOfOverDoseActiveIngredient_Details>();
        this.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.DrugOrderIntroductionDetails.forEach(element => {
            let det: ControlOfOverDoseActiveIngredient_Details = new ControlOfOverDoseActiveIngredient_Details();
            det.newMaterialObjectIDList = element.Material.ObjectID;
            switch (element.Frequency) {
                case FrequencyEnum.Q24H:
                    {
                        det.totalDose = element.DoseAmount;
                        break;
                    }
                case FrequencyEnum.Q12H:
                    {
                        det.totalDose = element.DoseAmount * 2;
                        break;
                    }
                case FrequencyEnum.Q8H:
                    {
                        det.totalDose = element.DoseAmount * 3;
                        break;
                    }
                case FrequencyEnum.Q6H:
                    {
                        det.totalDose = element.DoseAmount * 4;
                        break;
                    }
                case FrequencyEnum.Q4H:
                    {
                        det.totalDose = element.DoseAmount * 6;
                        break;
                    }
                case FrequencyEnum.Q3H:
                    {
                        det.totalDose = element.DoseAmount * 8;
                        break;
                    }
                case FrequencyEnum.Q2H:
                    {
                        det.totalDose = element.DoseAmount * 12;
                        break;
                    }
                case FrequencyEnum.Q1H:
                    {
                        det.totalDose = element.DoseAmount * 24;
                        break;
                    }
                default:
                    {
                        TTVisual.InfoBox.Alert(i18n("M24473", "Yazdığınız doz aralığı planlamaya uygun değildir."), MessageIconEnum.ErrorMessage);
                        return;
                    }
            }
            newDetails.push(det);
        });

        let controlOutput: ControlOfOverDoseActiveIngredient_Output = await DrugOrderIntroductionService.ControlOfOverDoseActiveIngredient(drug.ObjectID, this._DrugOrderIntroduction.Episode,
            this._DrugOrderIntroduction.OrderDose, this._DrugOrderIntroduction.OrderFrequency, newDetails);
        if (controlOutput.isWarning === true) {
            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), 'Etken Madde Doz Aşımı',
                controlOutput.warningMessage + i18n("M12687", " Devam Etmek İstiyor Musunuz?"));
            if (result === 'V') {
                errorMsg = errorMsg + "Vazgeçildi";
                error = true;
            }
        }

        let rptDayOutput: ControlRepeatDay_Output = await DrugOrderIntroductionService.ControlRepeatDay(drug.ObjectID, this._DrugOrderIntroduction.Episode, this._DrugOrderIntroduction.PlannedStartTime);
        if (rptDayOutput.isWarning === true) {
            errorMsg = errorMsg + rptDayOutput.warningMessage;
            error = true;
        }

        ////Maksimum Doz ve Gün Kontrolleri burada gerçekleştiriliyor...
        //let infoMessage: string = '';
        //let overDoseOrDay: boolean = false;
        //if (drug.MaxDose != null) {
        //    if (this._DrugOrderIntroduction.OrderDose > drug.MaxDose) {
        //        infoMessage = infoMessage + '\r\n Tanımlı maksimum doz miktarı aşımı tespit edildi. \r\n İstenilen doz miktarı: ' +
        //this._DrugOrderIntroduction.OrderDose.toString() + ' Tanımlı maksimum doz miktarı : ' + drug.MaxDose.toString() + '\r\n';
        //        overDoseOrDay = true;
        //    }
        //}
        //if (drug.MaxDoseDay != null)
        //{
        //    if (this._DrugOrderIntroduction.OrderDay > drug.MaxDoseDay)
        //    {
        //        infoMessage = infoMessage + '\r\n Tanımlı maksimum gün aşımı tespit edildi. \r\n İstenilen gün sayısı: ' +
        //this._DrugOrderIntroduction.OrderDay.toString() + ' Tanımlı maksimum gün : ' + drug.MaxDoseDay.toString() + '\r\n';
        //        overDoseOrDay = true;
        //    }
        //}
        //if (overDoseOrDay === true) {
        //    let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'OK,CANCEL', 'Uyarı', '', infoMessage);
        //    if (result === "CANCEL") {
        //        ServiceLocator.MessageService.showError('Ekleme işleminden vazgeçildi!');
        //        return;
        //    }
        //}
        //////Maksimum Doz ve Gün Kontrolleri burada sonlanıyor...
        if (error === false) {
            let addDrug: boolean = true;
            /*if (gunuBirlikHastaMi) {
                let inhelds: Stock.GetStockFromStoreAndMaterial_Class[] = await StockService.GetStockFromStoreAndMaterial(drug.ObjectID,
                 this._DrugOrderIntroduction.SecondaryMasterResource.Store.ObjectID);
                if (inhelds[0] > 0) {
                    let result: string = "V";// ShowBox.Show(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç", "T,V", "Uyarı", "Mevcut İlaç",
                    "Order etmek istediğiniz " + drug.Name + " isimli ilaç deponuzda mevcuttur.Bu ilacı isterseniz deponuzdan kullanabilirsiniz.\r\nDepo Adı: "
                    + _DrugOrderIntroduction.SecondaryMasterResource.Store.Name + "\r\nMevcut: " + inheld.ToString() + "\r\nOrder İşlemine Devam Etmek İstiyor Musunuz?");
                    if (result === "V") {
                        addDrug = false;
                        this.OrderFrequency.Text = "\"\"";
                        this.OrderDose.Text = "\"\"";
                        this.OrderDay.Text = "\"\"";
                        this.DrugUsageType = null;
                        this._DrugOrderIntroduction.DrugObjectID = null;
                        TTVisual.InfoBox.Alert("Order işleminden vazgeçtiniz.", MessageIconEnum.InformationMessage);
                    }
                }
            }*/
            if (addDrug) {
                let drugOrderIntroductionDet: DrugOrderIntroductionDet = new DrugOrderIntroductionDet();
                drugOrderIntroductionDet.Material = material;
                drugOrderIntroductionDet.Day = <number>this._DrugOrderIntroduction.OrderDay;
                drugOrderIntroductionDet.PatientOwnDrug = this._DrugOrderIntroduction.PatientOwnDrug;
                drugOrderIntroductionDet.DoseAmount = this._DrugOrderIntroduction.OrderDose;
                drugOrderIntroductionDet.PeriodUnitType = this._DrugOrderIntroduction.PeriodUnitType;
                drugOrderIntroductionDet.PackageAmount = this._DrugOrderIntroduction.PackageAmount;
                drugOrderIntroductionDet.DrugDescription = this._DrugOrderIntroduction.DrugDescription;
                drugOrderIntroductionDet.UsageNote = this._DrugOrderIntroduction.DrugDescription;
                drugOrderIntroductionDet.IsImmediate = this._DrugOrderIntroduction.IsImmediate;
                drugOrderIntroductionDet.CaseOfNeed = this._DrugOrderIntroduction.CaseOfNeed;
                drugOrderIntroductionDet.DrugUsageType = this._DrugOrderIntroduction.DrugUsageType;
                drugOrderIntroductionDet.DrugOrderType = this._DrugOrderIntroduction.DrugOrderType;

                if (drugOrderIntroductionDet.DrugDescription !== undefined || drugOrderIntroductionDet.DrugDescription !== null) {
                    drugOrderIntroductionDet.DrugDescriptionType = this._DrugOrderIntroduction.DrugDescriptionType;
                }

                let orderFreq = this._DrugOrderIntroduction.OrderFrequency != null ? this._DrugOrderIntroduction.OrderFrequency.toString() : '-1';
                switch (orderFreq) {
                    case '1':
                        {
                            drugOrderIntroductionDet.Frequency = FrequencyEnum.Q24H;
                            await this.setPlannedStartTime(FrequencyEnum.Q24H);
                            break;
                        }
                    case '2':
                        {
                            drugOrderIntroductionDet.Frequency = FrequencyEnum.Q12H;
                            await this.setPlannedStartTime(FrequencyEnum.Q12H);
                            break;
                        }
                    case '3':
                        {
                            drugOrderIntroductionDet.Frequency = FrequencyEnum.Q8H;
                            await this.setPlannedStartTime(FrequencyEnum.Q8H);
                            break;
                        }
                    case '4':
                        {
                            drugOrderIntroductionDet.Frequency = FrequencyEnum.Q6H;
                            await this.setPlannedStartTime(FrequencyEnum.Q6H);
                            break;
                        }
                    case '6':
                        {
                            drugOrderIntroductionDet.Frequency = FrequencyEnum.Q4H;
                            await this.setPlannedStartTime(FrequencyEnum.Q4H);
                            break;
                        }
                    case '8':
                        {
                            drugOrderIntroductionDet.Frequency = FrequencyEnum.Q3H;
                            await this.setPlannedStartTime(FrequencyEnum.Q3H);
                            break;
                        }
                    case '12':
                        {
                            drugOrderIntroductionDet.Frequency = FrequencyEnum.Q2H;
                            await this.setPlannedStartTime(FrequencyEnum.Q2H);
                            break;
                        }
                    case '24':
                        {
                            drugOrderIntroductionDet.Frequency = FrequencyEnum.Q1H;
                            await this.setPlannedStartTime(FrequencyEnum.Q1H);
                            break;
                        }
                    default:
                        {
                            TTVisual.InfoBox.Alert(i18n("M24473", "Yazdığınız doz aralığı planlamaya uygun değildir."), MessageIconEnum.ErrorMessage);
                            return;
                        }
                }
                drugOrderIntroductionDet.NextDayOrder = this.NextDayOrder1x1;
                drugOrderIntroductionDet.PlannedStartTime = <Date>this._DrugOrderIntroduction.PlannedStartTime;


                let gunuBirlikHastaMi: boolean = true;

                let res: CreateDrugOrderTSViewModel = null;
                let drugOrder: DrugOrder;
                try {
                    let res: CreateDrugOrderTSViewModel = await this.CreateDrugOrderTSAndLoadEpisode(this._DrugOrderIntroduction, drugOrderIntroductionDet);
                    drugOrder = res.DrugOrder; //await this.CreateDrugOrderTSAndLoadEpisode(this._DrugOrderIntroduction, drugOrderIntroductionDet);
                    drugOrder.MedulaReportNo = this.drugReportNo; //
                } catch (err) {
                    ServiceLocator.MessageService.showError(err);
                    throw err;
                }

                if (this.isPatientOwnDrug === true) {//
                    if (drug.Volume === drug.Dose) {
                        if (this.patientOwnDrugAmount < drugOrder.Amount) {
                            TTVisual.InfoBox.Alert(i18n("M12081", "Bu ilacı Hasta Yanında Getirdi olarak yazamazsınız. ") +
                                i18n("M15463", "Hastanın kalan miktarı:") + this.patientOwnDrugAmount.toString() + i18n("M19740", " Order Toplam Miktarı: ") + drugOrder.Amount.toString(),
                                MessageIconEnum.ErrorMessage);
                            return;
                        }
                    }
                }
                if (drugOrder.Type === "Yatan Hasta Reçetesi") {
                    if (this.isInpatient === true) {
                        let equivalentDrugs: Array<DrugInfo> = await DrugOrderIntroductionService.GetEquivalentDrug(material, drugOrder.Amount);
                        let equivalentDrug: any = await this.checkEquivalent(equivalentDrugs);
                        if (equivalentDrug !== null) {
                            drugOrder.Material = equivalentDrug;
                            drugOrder.Type = "K-Çizelgesi";
                            drugOrderIntroductionDet.Material = equivalentDrug;
                        }
                    }
                }
                if (drugOrder.Type === "Yatan Hasta Reçetesi" && drugOrderIntroductionDet.Day > 5) { //-
                    TTVisual.InfoBox.Alert(i18n("M20966", "Reçete yazılırken İlaç 5 günden fazla yazılamaz."), MessageIconEnum.ErrorMessage);
                    return;
                }

                if (drugOrder.Type === "Yatan Hasta Reçetesi" && this.isInheld) {//?
                    let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), i18n("M20924", "Reçete"),
                        i18n("M24475", "Yazdığınız ilacın Eczanede yeterli mevcudu bulunmamaktadır. Bu nedenle Yatan Hasta Reçetesine çıkacaktır.<br />") + i18n("M12687", "Devam Etmek İstiyor Musunuz?"));
                    if (result === 'V') {
                        return;
                    }
                }
                drugOrder.IsImmediate = this._DrugOrderIntroduction.IsImmediate;
                drugOrderIntroductionDet.DrugOrder = drugOrder;

                if (this.isInpatient === true) {
                    let packageAmount: number = 0;
                    if (drug.PackageAmount !== undefined) {
                        packageAmount = drug.PackageAmount;
                    } else {
                        packageAmount = 1;
                    }
                    drugOrderIntroductionDet.PackageAmount = Math.Ceiling(drugOrder.Amount / packageAmount);
                }


                this.drugOrderIntroductionNewFormViewModel.DrugOrders.push(drugOrder);
                this.drugOrderIntroductionNewFormViewModel.DrugOrderDetails = this.drugOrderIntroductionNewFormViewModel.DrugOrderDetails.concat(drugOrder.DrugOrderDetails);
                this.drugOrderIntroductionNewFormViewModel.DrugOrderIntroductionDetailsGridList.push(drugOrderIntroductionDet);

                if (this.isInpatient === true) {
                    if (drug.DrugNutrientInteraction != null)
                        TTVisual.InfoBox.Alert("İlaç Besin Etkileşimi Bulunmaktadır! ", drug.DrugNutrientInteraction, MessageIconEnum.InformationMessage);
                    await this.addToDrugOrderIntroductionDetailsWithValidation(this._DrugOrderIntroduction.DrugOrderIntroductionDetails, drugOrderIntroductionDet); //-
                }
                if (drugOrderIntroductionDet !== null) {
                    if (drugOrderIntroductionDet.DrugOrder !== null) {
                        if (this.isOutpatient === true) {
                            drugOrder.Type = "Yatan Hasta Reçetesi";
                            await this.addOutPatientPres(drugOrder, material, this._DrugOrderIntroduction.DrugUsageType, drugOrderIntroductionDet);
                        } else {
                            if (drugOrder.Type === "Yatan Hasta Reçetesi") {
                                await this.addInpatientPres(drugOrder, material);
                            }
                        }
                        this.addingDruglist.push(this._DrugOrderIntroduction.DrugObjectID.toString());
                        this._DrugOrderIntroduction.DrugName = '';
                        this._DrugOrderIntroduction.DrugObjectID = null;
                        this._DrugOrderIntroduction.DrugUsageType = null;
                        this._DrugOrderIntroduction.OrderFrequency = null;
                        this._DrugOrderIntroduction.OrderDose = null;
                        this._DrugOrderIntroduction.OrderDay = null;
                        this.setDefaultNextDayValues(false);
                        this.eventRadioGroup.value = null;
                        if (this.isPatientOwnDrug === false) {
                            this._DrugOrderIntroduction.PatientOwnDrug = false;
                        }
                        this._DrugOrderIntroduction.PackageAmount = null;
                        this._DrugOrderIntroduction.PeriodUnitType = null;
                        this._DrugOrderIntroduction.DrugDescription = null;
                        this._DrugOrderIntroduction.DrugDescriptionType = null;
                        this._DrugOrderIntroduction.IsImmediate = null;
                        this._DrugOrderIntroduction.CaseOfNeed = null;
                        this._DrugOrderIntroduction.DrugOrderType = DrugOrderTypeEnum._Treatment.code;
                        this.isRequiedForm = false;
                        this.isInheld = false;
                        this.initFormControls();
                        this.searchText = '';
                    } else {
                        (<ITTObject>drugOrderIntroductionDet).Delete();
                    }
                }
            }
        } else {
            TTVisual.InfoBox.Alert(errorMsg, MessageIconEnum.ErrorMessage);
        }
    }

    async addInpatientPres(drugOrder: DrugOrder, material: DrugDefinition) {
        let pres: InpatientPrescription = null;
        for (let presDetail of this.drugOrderIntroductionNewFormViewModel.InpatientPrescriptions) {
            if (material.PrescriptionType === presDetail.PrescriptionType) {
                pres = presDetail;
            }
        }
        let output: AddInpatientPrescription_Output = await DrugOrderIntroductionService.AddInpatientPrescription(drugOrder, pres, this._DrugOrderIntroduction.DrugDescription);
        if (pres === null) {
            let inpatientPresDetail: InpatientPresDetail = new InpatientPresDetail();
            inpatientPresDetail.InpatientPrescription = output.inpatientPrescription;

            if (this._DrugOrderIntroduction.InpatientPresDetails == null || this._DrugOrderIntroduction.InpatientPresDetails.length === 0) {
                this._DrugOrderIntroduction.InpatientPresDetails = new Array<InpatientPresDetail>();
            }

            if (output.inpatientPrescription != null) {
                this.drugOrderIntroductionNewFormViewModel.InpatientPrescriptions.push(output.inpatientPrescription);
            }

            this.drugOrderIntroductionNewFormViewModel.InpatientPresDetailsGridList.push(inpatientPresDetail);
            if (this.isInpatient === true) {
                this._DrugOrderIntroduction.InpatientPresDetails.push(inpatientPresDetail);
            }

        }
        if (output.inpatientDrugOrder != null) {
            this.drugOrderIntroductionNewFormViewModel.InpatientDrugOrders.push(output.inpatientDrugOrder);
        }
    }

    async addOutPatientPres(drugOrder: DrugOrder, material: DrugDefinition, drugUsageType: DrugUsageTypeEnum, drugOrderIntroductionDet: DrugOrderIntroductionDet) {
        let pres: OutPatientPrescription = null;
        for (let presDetail of this.drugOrderIntroductionNewFormViewModel.OutPatientPrescriptions) {
            if (material.PrescriptionType === presDetail.PrescriptionType) {
                pres = presDetail;
            }
        }
        let output: AddOutpatientPrescription_Output = await DrugOrderIntroductionService.AddOutpatientPrescription(drugOrder, pres,
            this._DrugOrderIntroduction.DrugDescription, drugUsageType, drugOrderIntroductionDet);
        if (pres === null) {
            let outpatientPresDetail: OutpatientPresDetail = new OutpatientPresDetail();
            if (this.isDischarged === true) {
                output.outPatientPrescription.IsDischargePrescripiton = true;
            }
            outpatientPresDetail.OutPatientPrescription = output.outPatientPrescription;
            if (this._DrugOrderIntroduction.OutpatientPresDetails == null) {
                this._DrugOrderIntroduction.OutpatientPresDetails = new Array<OutpatientPresDetail>();
            }

            this.drugOrderIntroductionNewFormViewModel.OutPatientPrescriptions.push(output.outPatientPrescription);
            this.drugOrderIntroductionNewFormViewModel.OutpatientPresDetailsGridList.push(outpatientPresDetail);
            //this._DrugOrderIntroduction.OutpatientPresDetails.push(outpatientPresDetail);
        }
        this.drugOrderIntroductionNewFormViewModel.OutPatientDrugOrders.push(output.outPatientDrugOrder);
    }

    public async cmdAddTemplate_Click(): Promise<void> {
        let description: string = await TTVisual.InputForm.GetText(i18n("M22433", "Şablon Açıklaması"));

        if (String.isNullOrEmpty(description) === false) {
            let user: ResUser = await UserHelper.CurrentResource;
            let isAvailable: boolean = await UserTemplateService.IsTemplateNameAvailable(user.ObjectID, description);
            if (isAvailable) {
                this._DrugOrderIntroduction.IsTemplate = true;
                this._DrugOrderIntroduction.TemplateDescription = description;
                this.cmdAddTemplate.Enabled = false;
            } else {
                TTVisual.InfoBox.Alert(description + i18n("M16582", " isimli şablonunuz bulunduğu için şablon kayıt edilemedi"), MessageIconEnum.ErrorMessage);
            }
        } else {
            TTVisual.InfoBox.Alert(i18n("M22458", "Şablona isim vermeden kaydedemezsiniz."), MessageIconEnum.ErrorMessage);
        }
    }
    public async AddTemplate(introductionDet: DrugOrderIntroductionDet) {
        let drugOrderIntroductionDet: DrugOrderIntroductionDet = new DrugOrderIntroductionDet();
        let matobjID: Guid = <any>introductionDet['Material'];
        let material: Material = await this.objectContextService.getObject<Material>(matobjID, DrugDefinition.ObjectDefID);
        let drug: DrugDefinition = <DrugDefinition>material;
        if (drug.DrugNutrientInteraction != null)
            TTVisual.InfoBox.Alert("İlaç Besin Etkileşimi Bulunmaktadır! ", drug.DrugNutrientInteraction, MessageIconEnum.InformationMessage);

        let drugDefinition: DrugDefinition = <DrugDefinition>material;
        drugOrderIntroductionDet.Material = material;
        drugOrderIntroductionDet.PlannedStartTime = <Date>this._DrugOrderIntroduction.PlannedStartTime;
        drugOrderIntroductionDet.Day = introductionDet.Day;
        drugOrderIntroductionDet.DoseAmount = introductionDet.DoseAmount;
        drugOrderIntroductionDet.Frequency = introductionDet.Frequency;
        drugOrderIntroductionDet.IsImmediate = introductionDet.IsImmediate;
        drugOrderIntroductionDet.DrugUsageType = introductionDet.DrugUsageType;
        drugOrderIntroductionDet.CaseOfNeed = introductionDet.CaseOfNeed;
        drugOrderIntroductionDet.PackageAmount = introductionDet.PackageAmount;
        drugOrderIntroductionDet.PeriodUnitType = introductionDet.PeriodUnitType;
        drugOrderIntroductionDet.DrugOrderType = introductionDet.DrugOrderType;
        let res: CreateDrugOrderTSViewModel = await this.CreateDrugOrderTSAndLoadEpisode(this._DrugOrderIntroduction, drugOrderIntroductionDet);
        let drugOrder = res.DrugOrder; //DrugOrder = await this.CreateDrugOrderTSAndLoadEpisode(this._DrugOrderIntroduction, drugOrderIntroductionDet);
        drugOrderIntroductionDet.DrugOrder = drugOrder;
        this.drugOrderIntroductionNewFormViewModel.DrugOrders.push(drugOrder);
        this.drugOrderIntroductionNewFormViewModel.DrugOrderIntroductionDetailsGridList.push(drugOrderIntroductionDet);
        if (this.isInpatient === true) {
            await this.addToDrugOrderIntroductionDetailsWithValidation(this._DrugOrderIntroduction.DrugOrderIntroductionDetails, drugOrderIntroductionDet); //this._DrugOrderIntroduction.DrugOrderIntroductionDetails.push(drugOrderIntroductionDet);
        }
        if (this.isOutpatient === true) {
            // await this.addOutPatientPres(drugOrder, drugDefinition, drugDefinition.drug;
        } else {
            await this.addInpatientPres(drugOrder, drugDefinition);
        }
    }

    public async cmdGetTemplate_Click(): Promise<void> {
        let user: ResUser = await UserHelper.CurrentResource;
        this.showUserTemplate(user).then(result => {
            let modalActionResult = result as ModalActionResult;
            let materialObjectIds: Array<any> = new Array<any>();
            let that = this;
            if (modalActionResult.Result === DialogResult.OK) {
                let selectedTemplate = result.Param as Array<DrugOrderIntroductionDet>;
                for (let introductionDet of selectedTemplate) {
                    this.AddTemplate(introductionDet);
                }
            }
        });
        /*       let userTemplates: any = await UserTemplateService.GetDrugOrderIntroductionTemplate(user.ObjectID);
               let keys = Object.keys(userTemplates);
               if (keys.length > 0) {
                   let pForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                   for (let itemKey of keys) {
                       pForm.AddMSItem(itemKey, itemKey, userTemplates[itemKey]);
                   }
                   let sKey: string = await pForm.GetMSItem(this, 'Şablon seçiniz.', false, false, false, false, true, false);
                   if (!String.isNullOrEmpty(sKey)) {
                       let selectedTemplate: Array<DrugOrderIntroductionDet> = <Array<DrugOrderIntroductionDet>>pForm.MSSelectedItemObject;
                       for (let introductionDet of selectedTemplate) {
                           let drugOrderIntroductionDet: DrugOrderIntroductionDet = new DrugOrderIntroductionDet();
                           let matobjID: Guid = <any>introductionDet['Material'];
                           let material: Material = await this.objectContextService.getObject<Material>(matobjID, DrugDefinition.ObjectDefID);
                           let drugDefinition: DrugDefinition = <DrugDefinition>material;
                           drugOrderIntroductionDet.Material = material;
                           drugOrderIntroductionDet.PlannedStartTime = <Date>this._DrugOrderIntroduction.PlannedStartTime;
                           drugOrderIntroductionDet.Day = introductionDet.Day;
                           drugOrderIntroductionDet.DoseAmount = introductionDet.DoseAmount;
                           drugOrderIntroductionDet.Frequency = introductionDet.Frequency;
                           let drugOrder: DrugOrder = await this.CreateDrugOrderTSAndLoadEpisode(this._DrugOrderIntroduction,drugOrderIntroductionDet);
                           drugOrderIntroductionDet.DrugOrder = drugOrder;
                           this.drugOrderIntroductionNewFormViewModel.DrugOrders.push(drugOrder);
                           this.drugOrderIntroductionNewFormViewModel.DrugOrderIntroductionDetailsGridList.push(drugOrderIntroductionDet);
                           this._DrugOrderIntroduction.DrugOrderIntroductionDetails.push(drugOrderIntroductionDet);
                           if (this.isOutpatient === true) {
                               // await this.addOutPatientPres(drugOrder, drugDefinition, drugDefinition.drug;
                           } else {
                               await this.addInpatientPres(drugOrder, drugDefinition);
                           }
                       }
                   }
               } else {
                   TTVisual.InfoBox.Alert('Herhangibir reçete şablonunuz bulunmamaktadır', MessageIconEnum.InformationMessage);
               }*/
    }

    private async DrugListview_DoubleClick(): Promise<void> {

    }


    drugOrderDoseKeyPress(event: KeyboardEvent) {
        if (event.charCode === 44)
            event.preventDefault();
        if (event.charCode === 46)
            event.preventDefault();
        // tslint:disable-next-line:radix
        if (isNaN(parseInt(event.key)))
            event.preventDefault();
    }


    OldDrugOrders_CellContentClickEmitted(data: any) {
        if (data && this.OldDrugOrders_CellContentClick && data.Row && data.Column) {
            this.OldDrugOrders.CurrentCell = {
                OwningRow: data.Row,
                OwningColumn: data.Column
            };
            this.OldDrugOrders_CellContentClick(data.RowIndex, data.ColIndex);
        }
    }

    private async OldDrugOrders_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
        if (this.OldDrugOrders.CurrentCell.OwningColumn.Text === i18n("M23128", "Tekrarla")) {
            let bTarih: Date = new Date(); //await TTVisual.InputForm.GetDateTime(i18n("M20375", "Planlama Başlangıç Zamanı Seçiniz"), 'dd/mm/yyyy hh:mm');
            if (bTarih === null) {
                TTVisual.InfoBox.Alert(i18n("M12872", "Direktif Tekrardan vazgeçildi"));
            } else {
                let rptDrugOrder: DrugOrder = (<OldDrugOrder>(this.OldDrugOrders.CurrentCell.OwningRow.TTObject)).DrugOrder;
                let drugOrderIntroductionDet: DrugOrderIntroductionDet = new DrugOrderIntroductionDet();
                drugOrderIntroductionDet.Material = rptDrugOrder.Material;
                drugOrderIntroductionDet.PlannedStartTime = bTarih;
                drugOrderIntroductionDet.Day = rptDrugOrder.Day;
                drugOrderIntroductionDet.DoseAmount = rptDrugOrder.DoseAmount;
                drugOrderIntroductionDet.Frequency = rptDrugOrder.Frequency;
                drugOrderIntroductionDet.IsImmediate = rptDrugOrder.IsImmediate;
                drugOrderIntroductionDet.DrugUsageType = rptDrugOrder.DrugUsageType;
                drugOrderIntroductionDet.CaseOfNeed = rptDrugOrder.CaseOfNeed;
                drugOrderIntroductionDet.DrugOrderType = rptDrugOrder.DrugOrderType;
                let res: CreateDrugOrderTSViewModel = await this.CreateDrugOrderTSAndLoadEpisode(this._DrugOrderIntroduction, drugOrderIntroductionDet);
                let drugOrder = res.DrugOrder; //: DrugOrder = await this.CreateDrugOrderTSAndLoadEpisode(this._DrugOrderIntroduction, drugOrderIntroductionDet);
                drugOrderIntroductionDet.DrugOrder = drugOrder;
                this.drugOrderIntroductionNewFormViewModel.DrugOrders.push(drugOrder);
                this.drugOrderIntroductionNewFormViewModel.DrugOrderIntroductionDetailsGridList.push(drugOrderIntroductionDet);
                await this.addToDrugOrderIntroductionDetailsWithValidation(this._DrugOrderIntroduction.DrugOrderIntroductionDetails, drugOrderIntroductionDet); //this._DrugOrderIntroduction.DrugOrderIntroductionDetails.push(drugOrderIntroductionDet);


                await this.addInpatientPres(drugOrder, <DrugDefinition>rptDrugOrder.Material);
            }
        }
    }

    private showDrugInteractions(): Promise<DialogResult> {

        return new Promise<DialogResult>((resolve, reject) => {

            let that = this;
            let productList: Array<Product> = new Array<Product>();
            for (let detailItem of that._DrugOrderIntroduction.DrugOrderIntroductionDetails) {
                if ((<DrugDefinition>detailItem.Material).VademecumProductID != null) {
                    let pdr: Product = new Product();
                    pdr.id = (<DrugDefinition>detailItem.Material).VademecumProductID;
                    productList.push(pdr);
                }
            }

            if (productList.length > 0) {
                let inputDvo = new QueryVademecumInteractionDVO();
                inputDvo.episodeID = that._DrugOrderIntroduction.Episode.ObjectID.toString();
                inputDvo.prdList = productList;
                let fullApiUrl: string = 'api/LogisticDashboard/QueryVademecum';
                this.http.post(fullApiUrl, inputDvo)
                    .then((res: DrugOrderIntroductionNewFormViewModel) => {
                        let componentInfo = new DynamicComponentInfo();
                        componentInfo.ComponentName = 'DrugInteractionComponent';
                        componentInfo.ModuleName = 'LogisticFormsModule';
                        componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
                        componentInfo.InputParam = new DynamicComponentInputParam(res, new ActiveIDsModel(this._DrugOrderIntroduction.ObjectID, null, null));

                        let modalInfo: ModalInfo = new ModalInfo();
                        modalInfo.Title = 'UYARI';
                        modalInfo.Width = 1200;
                        modalInfo.Height = 800;

                        let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
                        let result2 = modalService.create(componentInfo, modalInfo);
                        result2.then(res2 => {
                            resolve(res2.Result);
                        });

                    })
                    .catch(error => {
                        TTVisual.InfoBox.Alert(error);
                        reject(error);
                    });
            } else {
                ServiceLocator.MessageService.showInfo(i18n("M21522", "Seçilen ilaçların Vademecum sistemi eşleşmesi bulunamadığı için \"Etkileşim Uyarı Ekranı\" görüntülenemeyecektir!"));
                resolve(DialogResult.OK);
            }
        });

    }

    colorPresClick() {
        let input: OpenColorPrescription_Input = new OpenColorPrescription_Input();
        input.SubEpisodeObjectID = this._DrugOrderIntroduction.SubEpisode['ObjectID'];
        let fullApiUrl: string = 'api/DrugOrderIntroductionService/OpenColorPrescription';
        this.http.post(fullApiUrl, input).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    colorPresClick_2() {
        let input: OpenColorPrescription_Input = new OpenColorPrescription_Input();
        input.SubEpisodeObjectID = this._DrugOrderIntroduction.SubEpisode['ObjectID'];
        let fullApiUrl: string = 'api/DrugOrderIntroductionService/OpenColorPrescriptionWithJSON';
        this.http.post(fullApiUrl, input).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    private async btnDrugInfo_Click(): Promise<void> {
        if (this._DrugOrderIntroduction.DrugObjectID != null) {
            let drug: any = await this.objectContextService.getObject(this._DrugOrderIntroduction.DrugObjectID, DrugDefinition.ObjectDefID);
            if ((<DrugDefinition>drug).VademecumProductID != null) {
                let drugId: string = (<DrugDefinition>drug).VademecumProductID.toString();
                this.showDrugInfo(drugId);
            } else {
                ServiceLocator.MessageService.showError(i18n("M21533", "Seçilen malzemenin Vademecum sistem ID\'si bulunamamıştır!"));
            }
        } else {
            TTVisual.InfoBox.Alert(i18n("M19995", "Önce ilaç seçmelisiniz."), MessageIconEnum.ErrorMessage);
        }
    }

    private showDrugInfo(productID: string): Promise<DialogResult> {

        return new Promise<DialogResult>((resolve, reject) => {

            let productList: Array<Product> = new Array<Product>();
            for (let detailItem of this.drugOrderIntroductionNewFormViewModel.DrugOrderIntroductionDetailsGridList) {
                let pdr: Product = new Product();
                pdr.id = (<DrugDefinition>detailItem.Material).VademecumProductID;
                productList.push(pdr);
            }

            let inputDvo = new VademecumProductDVO();
            inputDvo.id = productID;

            let that = this;
            let fullApiUrl: string = 'api/LogisticDashboard/GetVademecumProductByID';
            this.http.post(fullApiUrl, inputDvo)
                .then((res: DrugOrderIntroductionNewFormViewModel) => {
                    let componentInfo = new DynamicComponentInfo();
                    componentInfo.ComponentName = 'DrugInfoComponent';
                    componentInfo.ModuleName = 'LogisticFormsModule';
                    componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
                    componentInfo.InputParam = new DynamicComponentInputParam(res, new ActiveIDsModel(this._DrugOrderIntroduction.ObjectID, null, null));

                    let modalInfo: ModalInfo = new ModalInfo();
                    modalInfo.Title = 'UYARI';
                    modalInfo.Width = 1200;
                    modalInfo.Height = 800;

                    let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
                    let result2 = modalService.create(componentInfo, modalInfo);
                    result2.then(res2 => {
                        resolve(res2.Result);
                    });

                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                    reject(error);
                });
        });
    }

    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();
        this.hasErecetePassword = await DrugOrderIntroductionService.CheckERecetePasswordForCurrentUser();
        if (this.hasErecetePassword === false) {
            ServiceLocator.MessageService.showError(i18n("M22801", "Tanımlı bir E- Recete şifresi bulunamamıştır! Bilgi İşlem Merkezi ile irtibat kurunuz."));
        }

    }

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);

        for (let detailItem of this._DrugOrderIntroduction.DrugOrderIntroductionDetails) {
            if ((<DrugDefinition>detailItem.Material).IsNarcotic === true) {
                ServiceLocator.MessageService.showInfo(detailItem.Material.Name + ' Yüksek Riskli İlaçtır!');
            }
            if ((<DrugDefinition>detailItem.Material).IsPsychotropic === true) {
                ServiceLocator.MessageService.showInfo(detailItem.Material.Name + i18n("M20617", " Psikotrop Madde içermektedir!"));
            }
        }


        let message: string = '';
        let control: boolean = false;
        for (let intDetail of this._DrugOrderIntroduction.DrugOrderIntroductionDetails) {
            intDetail.DrugOrder.UsageNote = intDetail.UsageNote;
            intDetail.DrugOrder.Frequency = intDetail.Frequency;
            intDetail.DrugOrder.DoseAmount = intDetail.DoseAmount;
            intDetail.DrugOrder.Day = intDetail.Day;
            intDetail.DrugOrder.PlannedStartTime = intDetail.PlannedStartTime;
            intDetail.DrugOrder.IsImmediate = intDetail.IsImmediate;
            intDetail.DrugOrder.DrugUsageType = intDetail.DrugUsageType;
            intDetail.DrugOrder.CaseOfNeed = intDetail.CaseOfNeed;
            for (let orderdetail of intDetail.DrugOrder.DrugOrderDetails) {
                orderdetail.UsageNote = intDetail.UsageNote;
            }

            for (let outDrugOrder of this.drugOrderIntroductionNewFormViewModel.OutPatientDrugOrders) {
                let matObjectID: any = outDrugOrder.Material;
                if (<Guid>matObjectID === intDetail.Material.ObjectID) {
                    outDrugOrder.Description = intDetail.DrugDescription;
                    outDrugOrder.DescriptionType = intDetail.DrugDescriptionType;
                    outDrugOrder.PackageAmount = intDetail.PackageAmount;
                }
            }

            for (let inDrugOrder of this.drugOrderIntroductionNewFormViewModel.InpatientDrugOrders) {
                let inMatObjectID: any = inDrugOrder.Material;
                if (<Guid>inMatObjectID === intDetail.Material.ObjectID) {
                    inDrugOrder.Description = intDetail.DrugDescription;
                    inDrugOrder.DescriptionType = intDetail.DrugDescriptionType;
                    inDrugOrder.PackageAmount = intDetail.PackageAmount;
                }
            }
        }


        if (transDef !== null) {
            if (this._DrugOrderIntroduction.InpatientPresDetails !== undefined) {
                for (let detail of this._DrugOrderIntroduction.InpatientPresDetails) {
                    if (detail.InpatientPrescription != null) {
                        if (detail.InpatientPrescription.PrescriptionType === PrescriptionTypeEnum.NormalPrescription) {
                            message = message + i18n("M19472", "Normal Reçeteye Çıkacak İlaçlar: <br />");
                            for (let normal of this.drugOrderIntroductionNewFormViewModel.InpatientDrugOrders) {
                                let presID: any = normal['InpatientPrescription'];
                                if (presID === detail.InpatientPrescription.ObjectID) {
                                    let matobjID: Guid = <any>normal['Material'];
                                    let material: Material = await this.objectContextService.getObject<Material>(matobjID, DrugDefinition.ObjectDefID);
                                    message = message + material.Name.toString() + '<br />';
                                }
                            }
                        }
                        if (detail.InpatientPrescription.PrescriptionType === PrescriptionTypeEnum.GreenPrescription) {
                            message = message + i18n("M24641", "Yeşil Reçeteye Çıkacak İlaçlar: <br />");
                            for (let green of this.drugOrderIntroductionNewFormViewModel.InpatientDrugOrders) {
                                let presID: any = green['InpatientPrescription'];
                                if (presID === detail.InpatientPrescription.ObjectID) {
                                    let matobjID: Guid = <any>green['Material'];
                                    let material: Material = await this.objectContextService.getObject<Material>(matobjID, DrugDefinition.ObjectDefID);
                                    message = message + material.Name.toString() + '<br />';
                                }
                            }
                        }
                        if (detail.InpatientPrescription.PrescriptionType === PrescriptionTypeEnum.OrangePrescription) {
                            message = message + i18n("M23603", "Turuncu Reçeteye Çıkacak İlaçlar: <br />");
                            for (let orange of this.drugOrderIntroductionNewFormViewModel.InpatientDrugOrders) {
                                let presID: any = orange['InpatientPrescription'];
                                if (presID === detail.InpatientPrescription.ObjectID) {
                                    let matobjID: Guid = <any>orange['Material'];
                                    let material: Material = await this.objectContextService.getObject<Material>(matobjID, DrugDefinition.ObjectDefID);
                                    message = message + material.Name.toString() + '<br />';
                                }
                            }
                        }
                        if (detail.InpatientPrescription.PrescriptionType === PrescriptionTypeEnum.RedPrescription) {
                            message = message + i18n("M17526", "Kırmızı Reçeteye Çıkacak İlaçlar: <br />");
                            for (let red of this.drugOrderIntroductionNewFormViewModel.InpatientDrugOrders) {
                                let presID: any = red['InpatientPrescription'];
                                if (presID === detail.InpatientPrescription.ObjectID) {
                                    let matobjID: Guid = <any>red['Material'];
                                    let material: Material = await this.objectContextService.getObject<Material>(matobjID, DrugDefinition.ObjectDefID);
                                    message = message + material.Name.toString() + '<br />';
                                }
                            }
                        }
                        if (detail.InpatientPrescription.PrescriptionType === PrescriptionTypeEnum.PurplePrescription) {
                            message = message + i18n("M19120", "Mor Reçeteye Çıkacak İlaçlar: <br />");
                            for (let purple of this.drugOrderIntroductionNewFormViewModel.InpatientDrugOrders) {
                                let presID: any = purple['InpatientPrescription'];
                                if (presID === detail.InpatientPrescription.ObjectID) {
                                    let matobjID: Guid = <any>purple['Material'];
                                    let material: Material = await this.objectContextService.getObject<Material>(matobjID, DrugDefinition.ObjectDefID);
                                    message = message + material.Name.toString() + '<br />';
                                }
                            }
                        }
                    }
                }
                control = true;
            }
            if (this._DrugOrderIntroduction.OutpatientPresDetails !== undefined) {
                for (let detail of this._DrugOrderIntroduction.OutpatientPresDetails) {
                    if (detail.OutPatientPrescription.PrescriptionType === PrescriptionTypeEnum.NormalPrescription) {
                        message = message + i18n("M19472", "Normal Reçeteye Çıkacak İlaçlar: <br />");
                        for (let normal of this.drugOrderIntroductionNewFormViewModel.OutPatientDrugOrders) {
                            let presID: any = normal['OutPatientPrescription'];
                            if (presID === detail.OutPatientPrescription.ObjectID) {
                                let matobjID: Guid = <any>normal['Material'];
                                let material: Material = await this.objectContextService.getObject<Material>(matobjID, DrugDefinition.ObjectDefID);
                                message = message + material.Name.toString() + '<br />';
                            }
                        }
                    }
                    if (detail.OutPatientPrescription.PrescriptionType === PrescriptionTypeEnum.GreenPrescription) {
                        message = message + i18n("M24641", "Yeşil Reçeteye Çıkacak İlaçlar: <br />");
                        for (let green of this.drugOrderIntroductionNewFormViewModel.OutPatientDrugOrders) {
                            let presID: any = green['OutPatientPrescription'];
                            if (presID === detail.OutPatientPrescription.ObjectID) {
                                let matobjID: Guid = <any>green['Material'];
                                let material: Material = await this.objectContextService.getObject<Material>(matobjID, DrugDefinition.ObjectDefID);
                                message = message + material.Name.toString() + '<br />';
                            }
                        }
                    }
                    if (detail.OutPatientPrescription.PrescriptionType === PrescriptionTypeEnum.OrangePrescription) {
                        message = message + i18n("M23603", "Turuncu Reçeteye Çıkacak İlaçlar: <br />");
                        for (let orange of this.drugOrderIntroductionNewFormViewModel.OutPatientDrugOrders) {
                            let presID: any = orange['OutPatientPrescription'];
                            if (presID === detail.OutPatientPrescription.ObjectID) {
                                let matobjID: Guid = <any>orange['Material'];
                                let material: Material = await this.objectContextService.getObject<Material>(matobjID, DrugDefinition.ObjectDefID);
                                message = message + material.Name.toString() + '<br />';
                            }
                        }
                    }
                    if (detail.OutPatientPrescription.PrescriptionType === PrescriptionTypeEnum.RedPrescription) {
                        message = message + i18n("M17526", "Kırmızı Reçeteye Çıkacak İlaçlar: <br />");
                        for (let red of this.drugOrderIntroductionNewFormViewModel.OutPatientDrugOrders) {
                            let presID: any = red['OutPatientPrescription'];
                            if (presID === detail.OutPatientPrescription.ObjectID) {
                                let matobjID: Guid = <any>red['Material'];
                                let material: Material = await this.objectContextService.getObject<Material>(matobjID, DrugDefinition.ObjectDefID);
                                message = message + material.Name.toString() + '<br />';
                            }
                        }
                    }
                    if (detail.OutPatientPrescription.PrescriptionType === PrescriptionTypeEnum.PurplePrescription) {
                        message = message + i18n("M19120", "Mor Reçeteye Çıkacak İlaçlar: <br />");
                        for (let purple of this.drugOrderIntroductionNewFormViewModel.OutPatientDrugOrders) {
                            let presID: any = purple['OutPatientPrescription'];
                            if (presID === detail.OutPatientPrescription.ObjectID) {
                                let matobjID: Guid = <any>purple['Material'];
                                let material: Material = await this.objectContextService.getObject<Material>(matobjID, DrugDefinition.ObjectDefID);
                                message = message + material.Name.toString() + '<br />';
                            }
                        }
                    }
                }
                control = true;
            }

            if (this._DrugOrderIntroduction.DrugOrderIntroductionDetails == null) {
                control = false;
                TTVisual.InfoBox.Show(i18n("M20969", "Reçeteye Çıkacak ilaçların Seçilmemiştir."));
            }

            if (control === true) {
                let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), i18n("M20964", "Reçete Türü"),
                    i18n("M20968", "Reçeteye Çıkacak ilaçların Reçete Türü : <br />") + message + '<br />' + i18n("M12687", "Devam Etmek İstiyor Musunuz?"));
                if (result === 'V') {
                    message = '';
                    throw new Exception((await SystemMessageService.GetMessage(719)));
                } else {
                    await this.signService.showLoginModal();
                    let eReceteEntg: string = (await SystemParameterService.GetParameterValue('ERECETEENTEGRASYON', 'TRUE'));
                    if (eReceteEntg === 'TRUE') {
                        if (await DrugOrderIntroductionService.IsSGK(this._DrugOrderIntroduction.SubEpisode.ObjectID)) {
                            //await this.signService.showLoginModal();

                            let signedPrescriptionOutput: SignedPrescriptionOutput =
                                await this.http.post<SignedPrescriptionOutput>(this.PrepareSignedPrescriptionContentUrl, this.drugOrderIntroductionNewFormViewModel);

                            for (let signContentItem of signedPrescriptionOutput.PrescriptionSignContentList) {
                                let signedContent = await this.signService.signContent(signContentItem.SignContent);
                                let prescriptionSignedContent = new PrescriptionSignContent();
                                prescriptionSignedContent.PrescriptionObjectID = signContentItem.PrescriptionObjectID;
                                prescriptionSignedContent.SignContent = signedContent;
                                prescriptionSignedContent.OrderNo = signContentItem.OrderNo;
                                if (this.drugOrderIntroductionNewFormViewModel.PrescriptionSignContentList === null) {
                                    this.drugOrderIntroductionNewFormViewModel.PrescriptionSignContentList = new Array<PrescriptionSignContent>();
                                }
                                this.drugOrderIntroductionNewFormViewModel.PrescriptionSignContentList.push(prescriptionSignedContent);
                            }
                        }
                    }
                }
            }
        }
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);

    }
    protected async PreScript() {
        super.PreScript();
        //await this.signService.showLoginModal();
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        let eReceteEntg: string = (await SystemParameterService.GetParameterValue('ERECETEENTEGRASYON', 'TRUE'));
        if (eReceteEntg === 'TRUE') {
            if (this.isInpatient === true && this.drugOrderIntroductionNewFormViewModel.InpatientPrescriptions.length > 0) {
                if (await DrugOrderIntroductionService.IsSGK(this._DrugOrderIntroduction.SubEpisode.ObjectID)) {
                    //await this.signService.showLoginModal();

                    let signedPrescriptionOutput: SignedPrescriptionOutput =
                        await this.http.post<SignedPrescriptionOutput>(this.PrepareSignedApprovalPrescriptionContentUrl, this.drugOrderIntroductionNewFormViewModel);

                    for (let signContentItem of signedPrescriptionOutput.PrescriptionSignContentList) {
                        let signedContent = await this.signService.signContent(signContentItem.SignContent);
                        let prescriptionSignedContent = new PrescriptionSignContent();
                        prescriptionSignedContent.PrescriptionObjectID = signContentItem.PrescriptionObjectID;
                        prescriptionSignedContent.SignContent = signedContent;
                        prescriptionSignedContent.OrderNo = signContentItem.OrderNo;
                        this.drugOrderIntroductionNewFormViewModel.PrescriptionSignContentList.push(prescriptionSignedContent);
                    }
                    await this.http.post<void>(this.SendSignedApprovalPrescriptionContentUrl, this.drugOrderIntroductionNewFormViewModel);
                }
            }
            if (this._DrugOrderIntroduction.OutpatientPresDetails !== null && this._DrugOrderIntroduction.OutpatientPresDetails !== undefined) {
                for (let outpatientPres of this._DrugOrderIntroduction.OutpatientPresDetails) {
                    const objectIdParam = new GuidParam(outpatientPres.OutPatientPrescription.ObjectID);
                    let reportParameters: any = { 'TTOBJECTID': objectIdParam };
                    this.reportService.showReport('OutpatientPrescriptionReportByFormat', reportParameters);
                }
            }

            let message: string = '';
            message = await DrugOrderIntroductionService.GetEreceteMessage(this._DrugOrderIntroduction.ObjectID);
            if (message !== '') {
                ServiceLocator.MessageService.showInfo('Yazılan E reçete(ler): ' + message);
                TTVisual.InfoBox.Alert('Yazılan E reçete(ler): ' + message);
            }
        }
    }

    async searchClick() {
        this.loadingVisible = true;
        this.eReceteList = await DrugOrderIntroductionService.GetEreceteList(this._DrugOrderIntroduction.Episode);
        this.eReceteDataSource = {
            store: {
                type: 'array',
                key: 'ReceteNo',
                data: this.eReceteList
            }
        };
        this.loadingVisible = false;
    }

    async deleteClick() {
        let eReceteNo: any = this.selectedErecete[0];
        await this.signService.showLoginModal();
        this.loadingVisible = true;
        let preInput: PrepareSignedDeletePrescriptionContent_Input = new PrepareSignedDeletePrescriptionContent_Input();
        preInput.eReceteNo = eReceteNo;
        let signedPrescriptionOutput: string = await this.http.post<string>(this.PrepareSignedDeletePrescriptionContentUrl, preInput);
        let signedContent: string = await this.signService.signContent(signedPrescriptionOutput);
        let preSend: SendSignedDeletePrescriptionContent_Input = new SendSignedDeletePrescriptionContent_Input();
        preSend.singContent = signedContent;
        let sonuc: boolean = await this.http.post<boolean>(this.SendSignedDeletePrescriptionContentUrl, preSend);
        if (sonuc === true) {
            await DrugOrderIntroductionService.GetPresciptionByErecete(eReceteNo, this._DrugOrderIntroduction.Episode.Patient.ObjectID.toString());
            ServiceLocator.MessageService.showInfo(eReceteNo + i18n("M19525", " numaralı reçete iptal edilmiştir."));
            this.eReceteList = await DrugOrderIntroductionService.GetEreceteList(this._DrugOrderIntroduction.Episode);
            this.eReceteDataSource = {
                store: {
                    type: 'array',
                    key: 'ReceteNo',
                    data: this.eReceteList
                }
            };
        } else {
            ServiceLocator.MessageService.showError(eReceteNo + i18n("M19524", " numaralı reçete iptal edilememiştir."));
        }
        this.loadingVisible = false;
    }

    async CreateDrugOrderTSAndLoadEpisode(drugOrderIntroduction: DrugOrderIntroduction, drugOrderIntroductionDet: DrugOrderIntroductionDet): Promise<CreateDrugOrderTSViewModel> {

        let inputModel: CreateDrugOrderTS_Input = new CreateDrugOrderTS_Input();
        inputModel.IsImmediate = drugOrderIntroduction.IsImmediate;
        inputModel.DrugObjectID = drugOrderIntroduction.ObjectID;
        inputModel.PlannedStartTime = drugOrderIntroduction.PlannedStartTime;
        inputModel.DrugDescription = drugOrderIntroduction.DrugDescription;
        inputModel.EpisodeObjectID = drugOrderIntroduction.Episode.ObjectID;
        inputModel.MasterResourceObjectID = drugOrderIntroduction.MasterResource.ObjectID;
        if (this.isInpatient === true) {
            if (drugOrderIntroduction.IsConsultaitonOrder === false)
                inputModel.SecondaryMasterResourceObjectID = drugOrderIntroduction.SecondaryMasterResource.ObjectID;

            inputModel.ActiveInPatientPhysicianAppObjectID = drugOrderIntroduction.ActiveInPatientPhysicianApp.ObjectID;

        }
        inputModel.CaseOfNeed = drugOrderIntroduction.CaseOfNeed;
        inputModel.drugOrderIntroductionDet = drugOrderIntroductionDet;
        inputModel.SubEpisodeObjectID = drugOrderIntroduction.SubEpisode.ObjectID;
        let url: string = '/api/DrugOrderIntroductionService/CreateDrugOrderTS';
        let input = { 'input': inputModel };
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<CreateDrugOrderTSViewModel>(url, inputModel);
        result.DrugOrder.DrugOrderDetails = new Array<DrugOrderDetail>();

        for (let detailItem of result.DrugOrderDetails) {
            result.DrugOrder.DrugOrderDetails.push(detailItem);
        }
        this._DrugOrderIntroduction.PlannedStartTime = new Date(Date.now());
        return result;
    }

    async DoseManageButtonClick() {
        let episodeObjectID: string = this._DrugOrderIntroduction.Episode.ObjectID.toString();
        let result: string = await DrugOrderIntroductionService.MaterialDoseManagerOnPatient(episodeObjectID, this.ShowDoseAmountManagerPassword);
        TTVisual.InfoBox.Alert(result);

    }
    async CreateDrugOrderDetails() {
        let episodeObjectID: string = this._DrugOrderIntroduction.Episode.ObjectID.toString();
        let result: string = await DrugOrderIntroductionService.CreateDrugOrderDetails();
        TTVisual.InfoBox.Alert(result);
    }

    GetDrugItemWithType(drugShapeTypeEnum: DrugShapeTypeEnum) {

        if (drugShapeTypeEnum == null) {
            return "../../Content/DrugShapes/dragee.png";
        } else if (drugShapeTypeEnum === DrugShapeTypeEnum.Ampul) {
            return "../../Content/DrugShapes/ampul.png";
        } else if (drugShapeTypeEnum === DrugShapeTypeEnum.Granul) {
            return "../../Content/DrugShapes/granul-şase.png";
        } else if (drugShapeTypeEnum === DrugShapeTypeEnum.Sase) {
            return "../../Content/DrugShapes/granul-şase.png";
        } else if (drugShapeTypeEnum === DrugShapeTypeEnum.Hap) {
            return "../../Content/DrugShapes/kapsul.png";
        } else if (drugShapeTypeEnum === DrugShapeTypeEnum.Losyon) {
            return "../../Content/DrugShapes/solüsyon-süspansiyon.png";
        } else if (drugShapeTypeEnum === DrugShapeTypeEnum.Solusyon) {
            return "../../Content/DrugShapes/solüsyon-süspansiyon.png";
        } else if (drugShapeTypeEnum === DrugShapeTypeEnum.Süspansiyon) {
            return "../../Content/DrugShapes/solüsyon-süspansiyon.png";
        } else if (drugShapeTypeEnum === DrugShapeTypeEnum.Krem) {
            return "../../Content/DrugShapes/pomad-krem.png";
        } else if (drugShapeTypeEnum === DrugShapeTypeEnum.Pomad) {
            return "../../Content/DrugShapes/pomad-krem.png";
        } else if (drugShapeTypeEnum === DrugShapeTypeEnum.Ovul) {
            return "../../Content/DrugShapes/ovul-supozituar.png";
        } else if (drugShapeTypeEnum === DrugShapeTypeEnum.Supozituar) {
            return "../../Content/DrugShapes/ovul-supozituar.png";
        } else if (drugShapeTypeEnum === DrugShapeTypeEnum.Toz) {
            return "../../Content/DrugShapes/toz.png";
        } else if (drugShapeTypeEnum === DrugShapeTypeEnum.Tablet) {
            return "../../Content/DrugShapes/tablet.png";
        } else {
            return "../../Content/DrugShapes/dragee.png";
        }
    }

    IsExistingDrugOrderValidate(DrugOrderIntroductionDetails: Array<DrugOrderIntroductionDet>, addMaterialObjectID: string): boolean {

        let isExist: boolean = false;
        let materialName: string = '';
        DrugOrderIntroductionDetails.forEach(element => {
            let elementMaterialObjectID: string = element.Material.ObjectID.toString();
            if (elementMaterialObjectID === addMaterialObjectID) {
                isExist = true;
                materialName = element.Material.Name;
            }
        });
        if (isExist)
            TTVisual.InfoBox.Alert(materialName + " daha öncesinden eklenmiştir.");

        return isExist;
    }

    async addToDrugOrderIntroductionDetailsWithValidation(DrugOrderIntroductionDetails: Array<DrugOrderIntroductionDet>, drugOrderIntroductionDet: DrugOrderIntroductionDet) {

        let episodeObjectID: string = this._DrugOrderIntroduction.Episode.ObjectID.toString();
        let materialObjectID: string = drugOrderIntroductionDet.Material.ObjectID.toString();

        /*if (this.IsExistingDrugOrderValidate(DrugOrderIntroductionDetails, materialObjectID)) {
            TTVisual.InfoBox.Alert(drugOrderIntroductionDet.Material.Name + " daha öncesinden eklenmiştir.");
            return true;
        }*/

        let AgeValidation: ValidationPatientAgeAndMaterialAgeBand_Output = await DrugOrderIntroductionService.GetValidationPatientAgeAndMaterialAgeBand(episodeObjectID, materialObjectID);
        let MaxAgeValidate: boolean = true;
        let MinAgeValidate: boolean = true;

        if (AgeValidation.MaterialMaxAge != null && AgeValidation.MaterialMaxAge < AgeValidation.PatientAge) {
            MaxAgeValidate = false;
        }
        if (AgeValidation.MaterialMinAge != null && AgeValidation.MaterialMinAge > AgeValidation.PatientAge) {
            MinAgeValidate = false;
        }

        if (MinAgeValidate && MaxAgeValidate) {
            DrugOrderIntroductionDetails.push(drugOrderIntroductionDet);
        }
        else {
            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), i18n("M20924", "Reçete"),
                i18n("M24475", "Yazdığınız ilaç hastanın yaş aralığı için uygun değildir. Hastanız " + AgeValidation.PatientAge + " yaşında, ilaç için tavsiye edilen yaş aralığı (" + AgeValidation.MaterialMinAge + ")-(" + AgeValidation.MaterialMaxAge + ") <br />") + i18n("M12687", "Devam Etmek İstiyor Musunuz?"));
            if (result === 'V') {
                this.deleteDrugOrderIntroductionFromAddedList(drugOrderIntroductionDet);
            } else {
                DrugOrderIntroductionDetails.push(drugOrderIntroductionDet);
            }
        }
    }

    async repeatDrugOrders() {
        if (this.selectedDrugDetailRows.length > 0) {
            let bTarih: Date = new Date();
            if (bTarih === null) {
                TTVisual.InfoBox.Alert(i18n("M12872", "Direktif Tekrardan vazgeçildi"));
            } else {
                let repeatDrugOrderInput: repeatDrugOrder_Input = new repeatDrugOrder_Input();
                repeatDrugOrderInput.PlannedStartDate = bTarih;
                repeatDrugOrderInput.EReceteDetays = this.selectedDrugDetailRows;
                let repeatDrugOrderOutput: repeatDrugOrder_Output = await DrugOrderIntroductionService.RepeatDrugOrder(repeatDrugOrderInput);
                if (repeatDrugOrderOutput.DrugOrderIntroductionDets !== null) {

                    for (let introductionDet of repeatDrugOrderOutput.DrugOrderIntroductionDets) {

                        let drugOrderIntroductionDet: DrugOrderIntroductionDet = new DrugOrderIntroductionDet();
                        let matobjID: Guid = <any>introductionDet.Material;
                        if (this.IsExistingDrugOrderValidate(this.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.DrugOrderIntroductionDetails, matobjID.toString())) {
                            await TTVisual.InfoBox.Alert(drugOrderIntroductionDet.Material.Name + " daha öncesinden eklenmiştir.");
                        }
                        else {
                            let material: Material = await this.objectContextService.getObject<Material>(matobjID, DrugDefinition.ObjectDefID);
                            drugOrderIntroductionDet.Material = material;
                            drugOrderIntroductionDet.PlannedStartTime = introductionDet.PlannedStartTime;
                            drugOrderIntroductionDet.Day = introductionDet.Day;
                            drugOrderIntroductionDet.DoseAmount = introductionDet.DoseAmount;
                            drugOrderIntroductionDet.Frequency = introductionDet.Frequency;
                            drugOrderIntroductionDet.PackageAmount = introductionDet.PackageAmount;
                            drugOrderIntroductionDet.PeriodUnitType = introductionDet.PeriodUnitType;
                            drugOrderIntroductionDet.DrugOrderType = introductionDet.DrugOrderType;
                            let res: CreateDrugOrderTSViewModel = await this.CreateDrugOrderTSAndLoadEpisode(this._DrugOrderIntroduction, drugOrderIntroductionDet);
                            let drugOrder = res.DrugOrder; //: DrugOrder = await this.CreateDrugOrderTSAndLoadEpisode(this._DrugOrderIntroduction, drugOrderIntroductionDet);
                            drugOrderIntroductionDet.DrugOrder = drugOrder;

                            let drug: DrugDefinition = <DrugDefinition>material;
                            if (drug.DrugNutrientInteraction != null)
                                TTVisual.InfoBox.Alert("İlaç Besin Etkileşimi Bulunmaktadır! ", drug.DrugNutrientInteraction, MessageIconEnum.InformationMessage);

                            await this.addToDrugOrderIntroductionDetailsWithValidation(this.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.DrugOrderIntroductionDetails, drugOrderIntroductionDet); //this.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.DrugOrderIntroductionDetails.push(drugOrderIntroductionDet);
                            this.drugOrderIntroductionNewFormViewModel.DrugOrders.push(drugOrder);
                            if (drugOrder.Type === "Yatan Hasta Reçetesi") {
                                await this.addInpatientPres(drugOrder, <DrugDefinition>introductionDet.Material);
                            }
                        }
                    }
                }
                this.selectedTempItems = new Array<TempDrugOrder>();
            }
        }
    }

    valueChangeddata: any;
    valueChanged: any;

    valueChangedDiagnosis(data) {
        this.selectedDiagnosis = data.value;
    }
    async addDiagnosis() { //  eReçete tanı Ekle
        let eReceteNo: any = this.selectedErecete[0];
        await this.signService.showLoginModal();
        this.loadingVisible = true;
        let preInput: PrepareSignedDiagPrescriptionContent_Input = new PrepareSignedDiagPrescriptionContent_Input();
        preInput.eReceteNo = eReceteNo;
        preInput.diagnosisObjID = this.selectedDiagnosis.DiagnosisObjID;
        let signedPrescriptionOutput: string = await this.http.post<string>(this.PrepareSignedDiagnosisPrescriptionContentUrl, preInput);
        let signedContent: string = await this.signService.signContent(signedPrescriptionOutput);
        let preSend: SendSignedDiagPrescriptionContent_Input = new SendSignedDiagPrescriptionContent_Input();
        preSend.singContent = signedContent;
        let sonuc: boolean = await this.http.post<boolean>(this.SendSignedDiagnosisPrescriptionContentUrl, preSend);
        if (sonuc === true) {
            ServiceLocator.MessageService.showInfo(eReceteNo + i18n("M19527", " numaralı reçete tanı girişi eklenmiştir."));
            this.drugOrderIntroductionNewFormViewModel.DiagnosisDefinitionList = await DrugOrderIntroductionService.DiagnosisDefinition();
        } else {
            ServiceLocator.MessageService.showError(eReceteNo + i18n("M19526", "  numaralı reçete tanı girişi  yapılamamıştır."));
        }
        this.loadingVisible = false;
    }

    async addRecipeDescription() { //eReçeteye Açıklama Ekle
        let eReceteNo: any = this.selectedErecete[0];
        await this.signService.showLoginModal();
        this.loadingVisible = true;
        let preInput: PrepareSignedRecipeDescriptionPrescriptionContent_Input = new PrepareSignedRecipeDescriptionPrescriptionContent_Input();
        preInput.eReceteNo = eReceteNo;
        preInput.desciption = this.recipeDescription;
        preInput.drugDescriptionType = this.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.DrugDescriptionType; //değişecek
        let signedPrescriptionOutput: string = await this.http.post<string>(this.PrepareSignedRecipeDescriptionPrescriptionContentUrl, preInput);
        let signedContent: string = await this.signService.signContent(signedPrescriptionOutput);
        let preSend: SendSignedRecipeDescriptionPrescriptionContent_Input = new SendSignedRecipeDescriptionPrescriptionContent_Input();
        preSend.singContent = signedContent;
        let sonuc: boolean = await this.http.post<boolean>(this.SendSignedRecipeDescriptionPrescriptionContentUrl, preSend);
        if (sonuc === true) {
            ServiceLocator.MessageService.showInfo(eReceteNo + i18n("M19523", " numaralı reçete açıklama eklenmiştir."));
            this._DrugOrderIntroduction.DrugDescriptionType = null;
            this.recipeDescription = '';
        } else {
            ServiceLocator.MessageService.showError(eReceteNo + i18n("M19522", "  numaralı reçete açıklama  yapılamamıştır."));
        }
        this.loadingVisible = false;
    }
    async addDrugDescription() { //  eReçete İlaç Ekle
        if (this.selectedErecete.length > 0) {
            if (this.selectedDrugDetailRows.length > 0 && this.selectedDrugDetailRows.length < 2) {
                let eReceteNo: any = this.selectedErecete[0];
                let barcodeNo: any = this.selectedDrugDetailRows[0].Barkod;
                await this.signService.showLoginModal();
                this.loadingVisible = true;
                let preInput: PrepareSignedDrugDescriptionPrescriptionContent_Input = new PrepareSignedDrugDescriptionPrescriptionContent_Input();
                preInput.eReceteNo = eReceteNo;
                preInput.drugDesciption = this.drugDescriptionForErecete;
                preInput.barcode = barcodeNo;
                preInput.drugDescriptionType = this.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.DrugDescriptionType;
                let signedPrescriptionOutput: string = await this.http.post<string>(this.PrepareSignedDrugDescriptionPrescriptionContentUrl, preInput);
                let signedContent: string = await this.signService.signContent(signedPrescriptionOutput);
                let preSend: SendSignedDrugDescriptionPrescriptionContent_Input = new SendSignedDrugDescriptionPrescriptionContent_Input();
                preSend.singContent = signedContent;
                let sonuc: boolean = await this.http.post<boolean>(this.SendSignedDrugDescriptionPrescriptionContentUrl, preSend);
                if (sonuc === true) {
                    ServiceLocator.MessageService.showInfo(eReceteNo + i18n("M19528", " numaralı reçetenin") + barcodeNo + i18n("M11549", " barkoldu ilaç  açıklama eklenmiştir."));
                    this.selectedDrugDetailRows = null;
                    this._DrugOrderIntroduction.DrugDescriptionType = null;
                    this._DrugOrderIntroduction.DrugDescription = '';
                } else {
                    ServiceLocator.MessageService.showError(eReceteNo + i18n("M19521", "  numaralı reçete  ilaç açıklama yapılamamıştır."));
                }
                this.loadingVisible = false;

            } else {
                ServiceLocator.MessageService.showError(i18n("M11847", "Birden fazla ilaça açıklama yapılamaz."));
            }
        } else {
            ServiceLocator.MessageService.showError(i18n("M20956", "Reçete Seçilmeden ilaça açıklama yapılamaz."));
        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this.drugOrderIntroductionNewFormViewModel = new DrugOrderIntroductionNewFormViewModel();
        this._ViewModel = this.drugOrderIntroductionNewFormViewModel;
        //this.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction = this._TTObject as DrugOrderIntroduction;
        /*this.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.SecondaryMasterResource = new ResSection();
        this.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.SecondaryMasterResource.Store = new Store();*/
        this.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.OldDrugOrders = new Array<OldDrugOrder>();
        this.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.InpatientPresDetails = new Array<InpatientPresDetail>();
        this.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.OutpatientPresDetails = new Array<OutpatientPresDetail>();
        /*this.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.DiagnosisForPrescriptions = new Array<DiagnosisForPresc>();
        this.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.Episode = new Episode();
        this.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.Episode.Patient = new Patient();
        this.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.MasterResource = new ResSection();*/
        this.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.DrugOrderIntroductionDetails = new Array<DrugOrderIntroductionDet>();
        this.drugOrderIntroductionNewFormViewModel.PrescriptionSignContentList = new Array<PrescriptionSignContent>();
    }

    protected loadViewModel() {
        let that = this;
        that.drugOrderIntroductionNewFormViewModel = this._ViewModel as DrugOrderIntroductionNewFormViewModel;
        that._TTObject = this.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction;
        if (this.drugOrderIntroductionNewFormViewModel == null)
            this.drugOrderIntroductionNewFormViewModel = new DrugOrderIntroductionNewFormViewModel();
        if (this.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction == null)
            this.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction = new DrugOrderIntroduction();

        let secondaryMasterResourceObjectID = that.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction['SecondaryMasterResource'];
        if (secondaryMasterResourceObjectID != null && (typeof secondaryMasterResourceObjectID === 'string')) {
            let secondaryMasterResource = that.drugOrderIntroductionNewFormViewModel.ResSections.find(o => o.ObjectID.toString() === secondaryMasterResourceObjectID.toString());
            if (secondaryMasterResource) {
                that.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.SecondaryMasterResource = secondaryMasterResource;
            }
            if (secondaryMasterResource != null) {
                let storeObjectID = secondaryMasterResource['Store'];
                if (storeObjectID != null && (typeof storeObjectID === 'string')) {
                    let store = that.drugOrderIntroductionNewFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
                    if (store) {
                        secondaryMasterResource.Store = store;
                    }
                }
            }
        }
        for (let detailItem of that.drugOrderIntroductionNewFormViewModel.DrugOrders) {
            let drugOrderObjectID = detailItem['DrugOrder'];
            if (drugOrderObjectID != null && (typeof drugOrderObjectID === 'string')) {
                let drugOrder = that.drugOrderIntroductionNewFormViewModel.DrugOrders.find(o => o.ObjectID.toString() === drugOrderObjectID.toString());
                if (drugOrder) {
                    detailItem = drugOrder;
                }
                if (drugOrder != null) {
                    let materialObjectID = drugOrder['Material'];
                    if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                        let material = that.drugOrderIntroductionNewFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                        if (material) {
                            drugOrder.Material = material;
                        }
                    }
                }
            }
        }
        for (let detailItem of that.drugOrderIntroductionNewFormViewModel.InpatientDrugOrders) {
            let inpatientDrugOrderObjectID = detailItem['InpatientDrugOrder'];
            if (inpatientDrugOrderObjectID != null && (typeof inpatientDrugOrderObjectID === 'string')) {
                let inpatientDrugOrder = that.drugOrderIntroductionNewFormViewModel.InpatientDrugOrders.find(o => o.ObjectID.toString() === inpatientDrugOrderObjectID.toString());
                if (inpatientDrugOrder) {
                    detailItem = inpatientDrugOrder;
                }
                if (inpatientDrugOrder != null) {
                    let materialObjectID = inpatientDrugOrder['Material'];
                    if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                        let material = that.drugOrderIntroductionNewFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                        if (material) {
                            inpatientDrugOrder.Material = material;
                        }
                    }
                }
            }
        }
        for (let detailItem of that.drugOrderIntroductionNewFormViewModel.OutPatientDrugOrders) {
            let outPatientDrugOrderObjectID = detailItem['OutPatientDrugOrder'];
            if (outPatientDrugOrderObjectID != null && (typeof outPatientDrugOrderObjectID === 'string')) {
                let outPatientDrugOrder = that.drugOrderIntroductionNewFormViewModel.OutPatientDrugOrders.find(o => o.ObjectID.toString() === outPatientDrugOrderObjectID.toString());
                if (outPatientDrugOrder) {
                    detailItem = outPatientDrugOrder;
                }
                if (outPatientDrugOrder != null) {
                    let materialObjectID = outPatientDrugOrder['Material'];
                    if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                        let material = that.drugOrderIntroductionNewFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                        if (material) {
                            outPatientDrugOrder.Material = material;
                        }
                    }
                }
            }
        }
        that.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.OldDrugOrders = that.drugOrderIntroductionNewFormViewModel.OldDrugOrdersGridList;
        for (let detailItem of that.drugOrderIntroductionNewFormViewModel.OldDrugOrdersGridList) {
            let drugOrderObjectID = detailItem['DrugOrder'];
            if (drugOrderObjectID != null && (typeof drugOrderObjectID === 'string')) {
                let drugOrder = that.drugOrderIntroductionNewFormViewModel.DrugOrders.find(o => o.ObjectID.toString() === drugOrderObjectID.toString());
                if (drugOrder) {
                    detailItem.DrugOrder = drugOrder;
                }
                if (drugOrder != null) {
                    let materialObjectID = drugOrder['Material'];
                    if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                        let material = that.drugOrderIntroductionNewFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                        if (material) {
                            drugOrder.Material = material;
                        }
                    }
                }
            }
        }
        that.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.InpatientPresDetails = that.drugOrderIntroductionNewFormViewModel.InpatientPresDetailsGridList;
        for (let detailItem of that.drugOrderIntroductionNewFormViewModel.InpatientPresDetailsGridList) {
            let inpatientPrescriptionObjectID = detailItem['InpatientPrescription'];
            if (inpatientPrescriptionObjectID != null && (typeof inpatientPrescriptionObjectID === 'string')) {
                let inpatientPrescription = that.drugOrderIntroductionNewFormViewModel.InpatientPrescriptions.find(o => o.ObjectID.toString() === inpatientPrescriptionObjectID.toString());
                if (inpatientPrescription) {
                    detailItem.InpatientPrescription = inpatientPrescription;
                }
            }
        }
        that.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.OutpatientPresDetails = that.drugOrderIntroductionNewFormViewModel.OutpatientPresDetailsGridList;
        for (let detailItem of that.drugOrderIntroductionNewFormViewModel.OutpatientPresDetailsGridList) {
            let outPatientPrescriptionObjectID = detailItem['OutPatientPrescription'];
            if (outPatientPrescriptionObjectID != null && (typeof outPatientPrescriptionObjectID === 'string')) {
                let outPatientPrescription = that.drugOrderIntroductionNewFormViewModel.OutPatientPrescriptions.find(o => o.ObjectID.toString() === outPatientPrescriptionObjectID.toString());
                if (outPatientPrescription) {
                    detailItem.OutPatientPrescription = outPatientPrescription;
                }
            }
        }
        that.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.DiagnosisForPrescriptions = that.drugOrderIntroductionNewFormViewModel.DiagnosisForPrescriptionsGridList;
        for (let detailItem of that.drugOrderIntroductionNewFormViewModel.DiagnosisForPrescriptionsGridList) {
        }
        let episodeObjectID = that.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction['Episode'];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.drugOrderIntroductionNewFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode['Patient'];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.drugOrderIntroductionNewFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                    if (patient) {
                        episode.Patient = patient;
                    }
                }
            }
        }

        /*     if (episodeObjectID != null && (typeof episodeObjectID === "string")) {
                 let episode = that.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.Episode
                 if (episode != null) {
                     episode.Diagnosis = that.drugOrderIntroductionNewFormViewModel.GridEpisodeDiagnosisGridList;
                     for (let detailItem of that.drugOrderIntroductionNewFormViewModel.GridEpisodeDiagnosisGridList) {
                         let diagnoseObjectID = detailItem["Diagnose"];
                         if (diagnoseObjectID != null && (typeof diagnoseObjectID === "string")) {
                             let diagnose = that.drugOrderIntroductionNewFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                             detailItem.Diagnose = diagnose;
                         }
                         let responsibleUserObjectID = detailItem["ResponsibleUser"];
                         if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === "string")) {
                             let responsibleUser = that.drugOrderIntroductionNewFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                             detailItem.ResponsibleUser = responsibleUser;
                         }
                     }
                 }
             }
     */
        let masterResourceObjectID = that.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction['MasterResource'];
        if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
            let masterResource = that.drugOrderIntroductionNewFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
            if (masterResource) {
                that.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.MasterResource = masterResource;
            }
        }
        let subEpisodeObjectID = that.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction['SubEpisode'];
        if (subEpisodeObjectID != null && (typeof subEpisodeObjectID === 'string')) {
            let subEpisode = that.drugOrderIntroductionNewFormViewModel.SubEpisodes.find(o => o.ObjectID.toString() === subEpisodeObjectID.toString());
            if (subEpisode) {
                that.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.SubEpisode = subEpisode;
            }
        }
        that.drugOrderIntroductionNewFormViewModel._DrugOrderIntroduction.DrugOrderIntroductionDetails = that.drugOrderIntroductionNewFormViewModel.DrugOrderIntroductionDetailsGridList;
        for (let detailItem of that.drugOrderIntroductionNewFormViewModel.DrugOrderIntroductionDetailsGridList) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.drugOrderIntroductionNewFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
            let drugOrderObjectID = detailItem['DrugOrder'];
            if (drugOrderObjectID != null && (typeof drugOrderObjectID === 'string')) {
                let drugOrder = that.drugOrderIntroductionNewFormViewModel.DrugOrders.find(o => o.ObjectID.toString() === drugOrderObjectID.toString());
                if (drugOrder) {
                    detailItem.DrugOrder = drugOrder;
                }
                if (drugOrder != null) {

                    let durOrderIsImmediate = drugOrder.IsImmediate;

                    let drugOrderMaterialObjectID = drugOrder['Material'];
                    if (drugOrderMaterialObjectID != null && (typeof drugOrderMaterialObjectID === 'string')) {
                        let material = that.drugOrderIntroductionNewFormViewModel.Materials.find(o => o.ObjectID.toString() === drugOrderMaterialObjectID.toString());
                        if (material) {
                            drugOrder.Material = material;
                        }
                    }
                }
            }
        }
    }




    public onActionDateChanged(event: any): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.ActionDate !== event) {
                this._DrugOrderIntroduction.ActionDate = event;
            }
        }
    }

    public onAutoSearchChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.AutoSearch !== event) {
                this._DrugOrderIntroduction.AutoSearch = event;
            }
        }
        this.AutoSearch_CheckedChanged();
    }

    public onDoseChanged(event: any): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.Dose !== event) {
                this._DrugOrderIntroduction.Dose = event;
            }
        }
    }

    public onDrugDescriptionChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.DrugDescription !== event) {
                this._DrugOrderIntroduction.DrugDescription = event;
            }
        }
    }

    public onDrugDescriptionTypeChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.DrugDescriptionType !== event) {
                this._DrugOrderIntroduction.DrugDescriptionType = event;
            }
        }
    }
    public onDrugOrderTypeChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.DrugOrderType !== event) {
                this._DrugOrderIntroduction.DrugOrderType = event;
            }
        }
    }
    public onDrugNameChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.DrugName !== event) {
                this._DrugOrderIntroduction.DrugName = event;
            }
        }
    }

    public onDrugUsageTypeChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.DrugUsageType !== event) {
                this._DrugOrderIntroduction.DrugUsageType = event;
            }
        }
    }

    public onFavoriteDrugDayChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.OrderDay !== event) {
                this._DrugOrderIntroduction.OrderDay = event;
            }
        }
    }

    public onFavoriteDrugDoseChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.OrderDose !== event) {
                this._DrugOrderIntroduction.OrderDose = event;
            }
        }
    }

    public onFavoriteDrugFrequencyChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.OrderFrequency !== event) {
                this._DrugOrderIntroduction.OrderFrequency = event;
            }
        }
    }

    public onFullNamePatientChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null &&
                this._DrugOrderIntroduction.Episode != null &&
                this._DrugOrderIntroduction.Episode.Patient != null && this._DrugOrderIntroduction.Episode.Patient.FullName !== event) {
                this._DrugOrderIntroduction.Episode.Patient.FullName = event;
            }
        }
    }

    public onIDChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.ID !== event) {
                this._DrugOrderIntroduction.ID = event;
            }
        }
    }

    public onIsBarcodeChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.IsBarcode !== event) {
                this._DrugOrderIntroduction.IsBarcode = event;
            }
        }
    }

    public onIsInheldDrugChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.IsInheldDrug !== event) {
                this._DrugOrderIntroduction.IsInheldDrug = event;
            }
        }
    }

    public onMasterResourceChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.MasterResource !== event) {
                this._DrugOrderIntroduction.MasterResource = event;
            }
        }
    }

    public onMaxDoseChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.MaxDose !== event) {
                this._DrugOrderIntroduction.MaxDose = event;
            }
        }
    }

    public onMaxDoseDayChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.MaxDoseDay !== event) {
                this._DrugOrderIntroduction.MaxDoseDay = event;
            }
        }
    }

    public onOrderDayChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.OrderDay !== event) {
                this._DrugOrderIntroduction.OrderDay = event;
            }
        }
    }

    public onOrderDoseChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.OrderDose !== event) {
                this._DrugOrderIntroduction.OrderDose = event;
            }

        }
    }

    public onOrderFrequencyChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.OrderFrequency !== event) {
                this._DrugOrderIntroduction.OrderFrequency = event;
            }
        }
    }

    public onPatientOwnDrugCheckChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.PatientOwnDrug !== event) {
                this._DrugOrderIntroduction.PatientOwnDrug = event;
            }
        }
    }

    public onIsImmediateCheckChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.IsImmediate !== event) {
                this._DrugOrderIntroduction.IsImmediate = event;
            }
        }
    }

    public onCaseOfNeedCheckChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.CaseOfNeed !== event) {
                this._DrugOrderIntroduction.CaseOfNeed = event;
            }
        }
    }

    public async onNextDayCheckChanged(event) {
        if (event != null) {
            let currentDate: Date = new Date(Date.now());
            //let currentDate: DateTime = new DateTime(new Date(cDate.Year, cDate.Month, cDate.Day, 8, 0, 0).AddDays(1).getMilliseconds(), DateTime.Kind.Utc)
            //let selectedTime: Date;
            //if (event)
            //selectedTime = await TTVisual.InputForm.GetDateTime(i18n("M20375", "Planlama Başlangıç Zamanı Seçiniz"), currentDate, 'hh:mm', false);
            this.NextDayOrder1x1 = event;
            this.PlannedStartTime.ReadOnly = event;
            if (event)
                this.selectedPlannedStartTime = new Date(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate(), 7, 0, 0, 0).AddDays(1);
            else
                this.selectedPlannedStartTime = new Date(Date.now());
        }
    }

    public setDefaultNextDayValues(nextDayOrderCheckVisible: boolean) {
        this.NextDayOrder1x1 = false;
        this.selectedPlannedStartTime = new Date(Date.now());
        this.nextDayOrderVisible = nextDayOrderCheckVisible;
    }

    public onPlannedStartTimeChanged(event): void {
        if (event != null) {
            //if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.PlannedStartTime !== event) {
            this.selectedPlannedStartTime = event;
            //}
        }
    }

    public onSecondaryMasterResourceChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.SecondaryMasterResource !== event) {
                this._DrugOrderIntroduction.SecondaryMasterResource = event;
            }
        }
    }

    public onttdatetimepicker1Changed(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.PlannedStartTime !== event) {
                this._DrugOrderIntroduction.PlannedStartTime = event;
            }
        }
    }

    public onttenumcombobox2Changed(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.Frequency !== event) {
                this._DrugOrderIntroduction.Frequency = event;
            }
        }
    }

    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.DrugName !== event) {
                this._DrugOrderIntroduction.DrugName = event;
            }
        }
    }

    public ontttextbox7Changed(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.RoutineDay !== event) {
                this._DrugOrderIntroduction.RoutineDay = event;
            }
        }
    }

    public ontttextbox8Changed(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.RoutineDose !== event) {
                this._DrugOrderIntroduction.RoutineDose = event;
            }
        }
    }

    public ontxtStoreNameChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null &&
                this._DrugOrderIntroduction.SecondaryMasterResource != null &&
                this._DrugOrderIntroduction.SecondaryMasterResource.Store != null && this._DrugOrderIntroduction.SecondaryMasterResource.Store.Name !== event) {
                this._DrugOrderIntroduction.SecondaryMasterResource.Store.Name = event;
            }
        }
    }

    public onUnitChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.Unit !== event) {
                this._DrugOrderIntroduction.Unit = event;
            }
        }
    }

    public onUseRoutineValueChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.UseRoutineValue !== event) {
                this._DrugOrderIntroduction.UseRoutineValue = event;
            }
        }
    }

    public onVolumeChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.Volume !== event) {
                this._DrugOrderIntroduction.Volume = event;
            }
        }
    }

    public onPackageAmountChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.PackageAmount !== event) {
                this._DrugOrderIntroduction.PackageAmount = event;
            }
        }
    }
    public onPeriodUnitTypeChanged(event): void {
        if (event != null) {
            if (this._DrugOrderIntroduction != null && this._DrugOrderIntroduction.PeriodUnitType !== event) {
                this._DrugOrderIntroduction.PeriodUnitType = event;
            }
        }
    }

    DrugOrderIntroductionDetails_CellValueChangedEmitted(data: any) {
        if (data && this.DrugOrderIntroductionDetails_CellValueChangedEmitted && data.Row && data.Column) {
            this.DrugOrderIntroductionDetails_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }

    public isPlannedDateEligable = true;
    public orderPlannedDateEligable = '';

    public DrugOrderIntroductionDetails_RowPrepared(row) {
        if (row.rowType == "data") {
            let plannedStartDate = new Date(row.values[1]);
            let today = new Date(Date.now());
            if (plannedStartDate < today.AddHours(-this.drugOrderTimeOffset)) {
                row.cells[0].row.cells[0].column.columnConfig.Text = 'Düzenle';
            } else {
                row.cells[0].row.cells[0].column.columnConfig.Text = 'Zaman Çizelgesi';
            }
        }
    }

    public onTempDrugOrderGridCellClick(event: any): void {
        if (event.key != null && event.key.FrequencyEnumValue != FrequencyEnum.Q24H && event.column.dataField == 'NextDayOrder') {
            ServiceLocator.MessageService.showInfo('Bu özellik sadece 1x1 ilaçlar için kullanılabilir.');
            event.key.NextDayOrder = false;
            event.cancel = true;
        }
        else
            event.cancel = false;
    }

    public async DrugOrderIntroductionDetails_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        if (data.Column.Name == 'DayDrugOrderIntroductionDet') {
            let ttObject = data.Row.TTObject;
            this.drugOrderIntroductionNewFormViewModel.DrugOrderDetails = this.drugOrderIntroductionNewFormViewModel.DrugOrderDetails.filter(x => <any>x.DrugOrder != ttObject.DrugOrder.ObjectID);
            this.drugOrderIntroductionNewFormViewModel.DrugOrders = this.drugOrderIntroductionNewFormViewModel.DrugOrders.filter(x => x.ObjectID != ttObject.DrugOrder.ObjectID);
            ttObject.DrugOrder = null;
            let res: CreateDrugOrderTSViewModel = await this.CreateDrugOrderTSAndLoadEpisode(this._DrugOrderIntroduction, ttObject);
            let drugOrder = res.DrugOrder;
            drugOrder.DrugOrderDetails.forEach(element => {
                this.drugOrderIntroductionNewFormViewModel.DrugOrderDetails.push(element);
            });
            this.drugOrderIntroductionNewFormViewModel.DrugOrders.push(drugOrder);
            ttObject.DrugOrder = drugOrder;
        }
    }


    onSelectionChangeDrugOrderIntroductionDetails(data: any) {
    }

    onDrugOrderIntroductionDetailsRowInserting(data: any) {
    }

    async onDrugOrderIntroductionDetailsCellContentClicked(data: any) {
        if (data && this.onDrugOrderIntroductionDetailsCellContentClicked && data.Row && data.Column) {
            if (data.Column.Name === 'buttonDeleteDrugOrder') {
                let drugOrderIntroductionDetail: DrugOrderIntroductionDet = <DrugOrderIntroductionDet>(data.Row.TTObject);
                let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), i18n("M20964", "Reçete Türü"),
                    i18n("M16349", "İlaç Listeden Çıkacak<br />") + drugOrderIntroductionDetail.Material.Name.toString() + i18n("M10048", "<br />Devam Etmek İstiyor Musunuz?"));
                if (result === 'T') {
                    this.deleteDrugOrderIntroductionFromAddedList(drugOrderIntroductionDetail);
                }
            }
            if (data.Column.Name === 'buttonChangeSchedule') {
                let drugOrderIntroductionDetail: DrugOrderIntroductionDet = <DrugOrderIntroductionDet>(data.Row.TTObject);
                this.showDrugOrderSchedule(drugOrderIntroductionDetail.DrugOrder.DrugOrderDetails).then(res => {
                    let modalActionResult = res as ModalActionResult;
                    drugOrderIntroductionDetail.DrugOrder.DrugOrderDetails = res.Param as Array<DrugOrderDetail>;
                    drugOrderIntroductionDetail.PlannedStartTime = drugOrderIntroductionDetail.DrugOrder.DrugOrderDetails.find(x => x.DetailNo == 1).OrderPlannedDate;
                });
            }
        }
    }

    deleteDrugOrderIntroductionFromAddedList(drugOrderIntroductionDetail: DrugOrderIntroductionDet) {

        let matGuid: Guid = drugOrderIntroductionDetail.Material.ObjectID;
        drugOrderIntroductionDetail.EntityState = EntityStateEnum.Deleted;
        drugOrderIntroductionDetail.DrugOrder.EntityState = EntityStateEnum.Deleted;
        for (let inpatient of drugOrderIntroductionDetail.DrugOrder.DrugOrderDetails) {
            inpatient.EntityState = EntityStateEnum.Deleted;
        }

        this._DrugOrderIntroduction.PlannedStartTime = new Date(Date.now());
        for (let inpatient of this.drugOrderIntroductionNewFormViewModel.InpatientDrugOrders) {
            let inObjId: any = inpatient['Material'];
            if (inObjId === drugOrderIntroductionDetail.Material.ObjectID.valueOf()) {
                inpatient.EntityState = EntityStateEnum.Deleted;
                inpatient.InpatientPrescription = null;
            }
        }

        let avalibleinPatientPrescription: Array<Guid> = new Array<Guid>();
        for (let inpatientDetail of this.drugOrderIntroductionNewFormViewModel.InpatientDrugOrders) {
            let inpatientPresObjectID: any = inpatientDetail['InpatientPrescription'];
            if (avalibleinPatientPrescription.some(x => x === inpatientPresObjectID) === false) {
                avalibleinPatientPrescription.push(inpatientPresObjectID);
            }
        }

        if (avalibleinPatientPrescription.length > 0) {
            for (let inPres of this.drugOrderIntroductionNewFormViewModel.InpatientPrescriptions) {
                if (avalibleinPatientPrescription.some(x => x === inPres.ObjectID) === false) {
                    inPres.EntityState = EntityStateEnum.Deleted;
                }
            }
        }

        for (let outPatient of this.drugOrderIntroductionNewFormViewModel.OutPatientDrugOrders) {
            let outObjId: any = outPatient['Material'];
            if (outObjId === drugOrderIntroductionDetail.Material.ObjectID.valueOf()) {
                outPatient.EntityState = EntityStateEnum.Deleted;

                outPatient.OutPatientPrescription = null;
            }
        }

        let avalibleOutPatientPrescription: Array<Guid> = new Array<Guid>();
        for (let outPatient of this.drugOrderIntroductionNewFormViewModel.OutPatientDrugOrders) {
            let outPatientPresObjectID: any = outPatient['OutPatientPrescription'];
            if (avalibleOutPatientPrescription.some(x => x === outPatientPresObjectID) === false) {
                avalibleOutPatientPrescription.push(outPatientPresObjectID);
            }
        }
        if (avalibleOutPatientPrescription.length > 0) {
            for (let outPres of this.drugOrderIntroductionNewFormViewModel.OutPatientPrescriptions) {
                if (avalibleOutPatientPrescription.some(x => x === outPres.ObjectID) === false) {
                    outPres.EntityState = EntityStateEnum.Deleted;
                }
            }
        }

        for (let outPresDet of this.drugOrderIntroductionNewFormViewModel.OutpatientPresDetailsGridList) {
            if (outPresDet.OutPatientPrescription.EntityState === EntityStateEnum.Deleted) {
                outPresDet.EntityState = EntityStateEnum.Deleted;
            }
        }

        for (let inPresDet of this.drugOrderIntroductionNewFormViewModel.InpatientPresDetailsGridList) {
            if (inPresDet.InpatientPrescription != null && inPresDet.InpatientPrescription.EntityState === EntityStateEnum.Deleted) {
                inPresDet.EntityState = EntityStateEnum.Deleted;
            }
        }

        const deleteDrugListFilter = this.addingDruglist.filter(item => item !== matGuid.toString());
        this.addingDruglist = deleteDrugListFilter;
        if (this.isInpatient === true) {

            if (this.drugOrderIntroductionNewFormViewModel.DrugOrderIntroductionDetailsGridList != null) {
                const deleteDrugOrderIntroductionDetail = this.drugOrderIntroductionNewFormViewModel.DrugOrderIntroductionDetailsGridList.filter(item => item.EntityState !== 1);
                this.drugOrderIntroductionNewFormViewModel.DrugOrderIntroductionDetailsGridList = deleteDrugOrderIntroductionDetail;
            }

            if (this._DrugOrderIntroduction.DrugOrderIntroductionDetails != null) {
                const deleteObjDrugOrderIntroductionDetail = this._DrugOrderIntroduction.DrugOrderIntroductionDetails.filter(item => item.EntityState !== 1);
                this._DrugOrderIntroduction.DrugOrderIntroductionDetails = deleteObjDrugOrderIntroductionDetail;
            }

            if (this.drugOrderIntroductionNewFormViewModel.DrugOrders != null) {
                const deleteDrugOrder = this.drugOrderIntroductionNewFormViewModel.DrugOrders.filter(item => item.EntityState !== 1);
                this.drugOrderIntroductionNewFormViewModel.DrugOrders = deleteDrugOrder;
            }

            if (this.drugOrderIntroductionNewFormViewModel.DrugOrderDetails != null) {
                const deleteDrugOrderDetails = this.drugOrderIntroductionNewFormViewModel.DrugOrderDetails.filter(item => item.EntityState !== 1);
                this.drugOrderIntroductionNewFormViewModel.DrugOrderDetails = deleteDrugOrderDetails;
            }

            if (this.drugOrderIntroductionNewFormViewModel.InpatientDrugOrders != null) {
                const deleteInpatientFilter = this.drugOrderIntroductionNewFormViewModel.InpatientDrugOrders.filter(item => item.EntityState !== 1);
                this.drugOrderIntroductionNewFormViewModel.InpatientDrugOrders = deleteInpatientFilter;
            }

            if (this.drugOrderIntroductionNewFormViewModel.OutPatientDrugOrders != null) {
                const deleteOutPatientFilter = this.drugOrderIntroductionNewFormViewModel.OutPatientDrugOrders.filter(item => item.EntityState !== 1);
                this.drugOrderIntroductionNewFormViewModel.OutPatientDrugOrders = deleteOutPatientFilter;
            }

            if (this.drugOrderIntroductionNewFormViewModel.InpatientPrescriptions != null) {
                const deleteOutPatientPresFilter = this.drugOrderIntroductionNewFormViewModel.OutPatientPrescriptions.filter(item => item.EntityState !== 1);
                this.drugOrderIntroductionNewFormViewModel.OutPatientPrescriptions = deleteOutPatientPresFilter;
            }

            if (this.drugOrderIntroductionNewFormViewModel.InpatientPrescriptions != null) {
                const deleteInPatientPresFilter = this.drugOrderIntroductionNewFormViewModel.InpatientPrescriptions.filter(item => item.EntityState !== 1);
                this.drugOrderIntroductionNewFormViewModel.InpatientPrescriptions = deleteInPatientPresFilter;
            }

            if (this.drugOrderIntroductionNewFormViewModel.InpatientPresDetailsGridList != null) {
                const deleteInPatientPresDetFilter = this.drugOrderIntroductionNewFormViewModel.InpatientPresDetailsGridList.filter(item => item.EntityState !== 1);
                this.drugOrderIntroductionNewFormViewModel.InpatientPresDetailsGridList = deleteInPatientPresDetFilter;
            }

            if (this._DrugOrderIntroduction.InpatientPresDetails != null) {
                const deleteObjInPatientPresDetFilter = this._DrugOrderIntroduction.InpatientPresDetails.filter(item => item.EntityState !== 1);
                this._DrugOrderIntroduction.InpatientPresDetails = deleteObjInPatientPresDetFilter;
            }

            if (this.drugOrderIntroductionNewFormViewModel.OutpatientPresDetailsGridList != null) {
                const deleteOutPatientPresDetFilter = this.drugOrderIntroductionNewFormViewModel.OutpatientPresDetailsGridList.filter(item => item.EntityState !== 1);
                this.drugOrderIntroductionNewFormViewModel.OutpatientPresDetailsGridList = deleteOutPatientPresDetFilter;
            }

            if (this._DrugOrderIntroduction.OutpatientPresDetails != null) {
                const deleteObjOutPatientPresDetFilter = this._DrugOrderIntroduction.OutpatientPresDetails.filter(item => item.EntityState !== 1);
                this._DrugOrderIntroduction.OutpatientPresDetails = deleteObjOutPatientPresDetFilter;
            }

        } else {
            this.drugOrderDetailGrid.RefreshFilter();
            if (this.inpatientPresDetailGrid !== undefined) {
                this.inpatientPresDetailGrid.RefreshFilter();
            }
            if (this.outPatientPresDetailGrid !== undefined) {
                this.outPatientPresDetailGrid.RefreshFilter();
            }
        }

    }
    async initDrugOrderIntroductionDetailsNewRow(data: any) {
    }


    protected redirectProperties(): void {
        redirectProperty(this.ID, 'Text', this.__ttObject, 'ID');
        redirectProperty(this.ActionDate, 'Value', this.__ttObject, 'ActionDate');
        redirectProperty(this.FullNamePatient, 'Text', this.__ttObject, 'Episode.Patient.FullName');
        redirectProperty(this.txtStoreName, 'Text', this.__ttObject, 'SecondaryMasterResource.Store.Name');
        redirectProperty(this.AutoSearch, 'Value', this.__ttObject, 'AutoSearch');
        redirectProperty(this.IsInheldDrug, 'Value', this.__ttObject, 'IsInheldDrug');
        redirectProperty(this.IsBarcode, 'Value', this.__ttObject, 'IsBarcode');
        redirectProperty(this.ttenumcombobox2, 'Value', this.__ttObject, 'Frequency');
        redirectProperty(this.tttextbox8, 'Text', this.__ttObject, 'RoutineDose');
        redirectProperty(this.tttextbox7, 'Text', this.__ttObject, 'RoutineDay');
        redirectProperty(this.UseRoutineValue, 'Value', this.__ttObject, 'UseRoutineValue');
        redirectProperty(this.Dose, 'Text', this.__ttObject, 'Dose');
        redirectProperty(this.Volume, 'Text', this.__ttObject, 'Volume');
        redirectProperty(this.Unit, 'Text', this.__ttObject, 'Unit');
        redirectProperty(this.MaxDose, 'Text', this.__ttObject, 'MaxDose');
        redirectProperty(this.MaxDoseDay, 'Text', this.__ttObject, 'MaxDoseDay');
        redirectProperty(this.DrugName, 'Text', this.__ttObject, 'DrugName');
        redirectProperty(this.OrderFrequency, 'Text', this.__ttObject, 'OrderFrequency');
        redirectProperty(this.OrderDose, 'Text', this.__ttObject, 'OrderDose');
        redirectProperty(this.OrderDay, 'Text', this.__ttObject, 'OrderDay');
        redirectProperty(this.PlannedStartTime, 'Value', this.__ttObject, 'PlannedStartTime');
        redirectProperty(this.DrugUsageType, 'Value', this.__ttObject, 'DrugUsageType');
        redirectProperty(this.PatientOwnDrugCheck, 'Value', this.__ttObject, 'PatientOwnDrug');
        redirectProperty(this.IsImmediateCheck, 'Value', this.__ttObject, 'IsImmediate');
        redirectProperty(this.IsImmediateCheckGrid, 'Value', this.__ttObject, 'IsImmediate');
        redirectProperty(this.CaseOfNeedCheck, 'Value', this.__ttObject, 'CaseOfNeed');
        redirectProperty(this.CaseOfNeedCheckGrid, 'Value', this.__ttObject, 'CaseOfNeed');
        redirectProperty(this.tttextbox1, 'Text', this.__ttObject, 'DrugName');
        redirectProperty(this.FavoriteDrugFrequency, 'Text', this.__ttObject, 'OrderFrequency');
        redirectProperty(this.FavoriteDrugDose, 'Text', this.__ttObject, 'OrderDose');
        redirectProperty(this.FavoriteDrugDay, 'Text', this.__ttObject, 'OrderDay');
        redirectProperty(this.ttdatetimepicker1, 'Value', this.__ttObject, 'PlannedStartTime');
        redirectProperty(this.DrugDescriptionType, 'Value', this.__ttObject, 'DrugDescriptionType');
        redirectProperty(this.DrugDescription, 'Text', this.__ttObject, 'DrugDescription');
        redirectProperty(this.PackageAmount, 'Text', this.__ttObject, 'PackageAmount');
        redirectProperty(this.PeriodUnitType, 'Value', this.__ttObject, 'PeriodUnitType');
        redirectProperty(this.DrugUsageTypeComboBox, 'Value', this.__ttObject, 'DrugUsageType');
        redirectProperty(this.DrugOrderType, 'Text', this.__ttObject, 'DrugOrderType');
    }

    public initFormControls(): void {
        this.ttlabel13 = new TTVisual.TTLabel();
        this.ttlabel13.Text = i18n("M12042", "Bölüm ve Depo :");
        this.ttlabel13.Name = 'ttlabel13';
        this.ttlabel13.TabIndex = 13;

        this.txtStoreName = new TTVisual.TTTextBox();
        this.txtStoreName.BackColor = '#F0F0F0';
        this.txtStoreName.ReadOnly = true;
        this.txtStoreName.Name = 'txtStoreName';
        this.txtStoreName.TabIndex = 12;

        this.DrugDescriptionType = new TTVisual.TTEnumComboBox();
        this.DrugDescriptionType.DataTypeName = 'DescriptionTypeEnum';
        this.DrugDescriptionType.Name = 'DrugDescriptionType';
        this.DrugDescriptionType.TabIndex = 20;



        this.labelPeriodUnitType = new TTVisual.TTLabel();
        this.labelPeriodUnitType.Text = i18n("M17980", "Kullanım Periyot Birimi");
        this.labelPeriodUnitType.Name = 'labelPeriodUnitType';
        this.labelPeriodUnitType.TabIndex = 17;

        this.PeriodUnitType = new TTVisual.TTEnumComboBox();
        this.PeriodUnitType.DataTypeName = 'PeriodUnitTypeEnum';
        this.PeriodUnitType.Name = 'PeriodUnitType';
        this.PeriodUnitType.TabIndex = 16;
        this.PeriodUnitType.ReadOnly = this.isInpatient;
        this.PeriodUnitType.Enabled = this.isOutpatient;

        this.labelPackageAmount = new TTVisual.TTLabel();
        this.labelPackageAmount.Text = i18n("M20130", "Paket Adedi");
        this.labelPackageAmount.Name = 'labelPackageAmount';
        this.labelPackageAmount.TabIndex = 15;

        this.PackageAmount = new TTVisual.TTTextBox();
        this.PackageAmount.Name = 'PackageAmount';
        this.PackageAmount.TabIndex = 14;


        this.SecondaryMasterResource = new TTVisual.TTObjectListBox();
        this.SecondaryMasterResource.ListDefName = 'ResourceListDefinition';
        this.SecondaryMasterResource.Name = 'SecondaryMasterResource';
        this.SecondaryMasterResource.TabIndex = 11;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = 'tttabcontrol1';
        this.tttabcontrol1.TabIndex = 0;

        this.NewOrderTabPage = new TTVisual.TTTabPage();
        this.NewOrderTabPage.DisplayIndex = 0;
        this.NewOrderTabPage.TabIndex = 0;
        this.NewOrderTabPage.Text = i18n("M16310", "İlaç Direktif");
        this.NewOrderTabPage.Name = 'NewOrderTabPage';

        this.IsBarcode = new TTVisual.TTCheckBox();
        this.IsBarcode.Value = false;
        this.IsBarcode.Text = i18n("M21099", "Sadece Barkodlular");
        this.IsBarcode.Name = 'IsBarcode';
        this.IsBarcode.TabIndex = 11;

        this.IsInheldDrug = new TTVisual.TTCheckBox();
        this.IsInheldDrug.Value = false;
        this.IsInheldDrug.Text = i18n("M21105", "Sadece Mevcutlu İlaçlar");
        this.IsInheldDrug.Name = 'IsInheldDrug';
        this.IsInheldDrug.TabIndex = 11;

        this.AutoSearch = new TTVisual.TTCheckBox();
        this.AutoSearch.Value = false;
        this.AutoSearch.Text = i18n("M19811", "Otomatik Arama");
        this.AutoSearch.Name = 'AutoSearch';
        this.AutoSearch.TabIndex = 1;

        this.cmdSearch = new TTVisual.TTButton();
        this.cmdSearch.Text = 'Ara';
        this.cmdSearch.Name = 'cmdSearch';
        this.cmdSearch.TabIndex = 2;

        this.PatientOwnDrugCheck = new TTVisual.TTCheckBox();
        this.PatientOwnDrugCheck.Value = false;
        this.PatientOwnDrugCheck.Title = i18n("M25807", "Hasta Yanında Getirdi");
        this.PatientOwnDrugCheck.Name = 'PatientOwnDrugCheck';
        this.PatientOwnDrugCheck.TabIndex = 4;
        this.PatientOwnDrugCheck.ReadOnly = this.isPatientOwnDrug;

        this.IsImmediateCheck = new TTVisual.TTCheckBox();
        this.IsImmediateCheck.Value = false;
        this.IsImmediateCheck.Title = i18n("M10430", "Acil İlaç");
        this.IsImmediateCheck.Name = 'IsImmediateCheck';
        this.IsImmediateCheck.TabIndex = 4;


        this.IsImmediateCheckGrid = new TTVisual.TTCheckBoxColumn();
        this.IsImmediateCheckGrid.HeaderText = i18n("M10430", "Acil İlaç");
        this.IsImmediateCheckGrid.Name = 'IsImmediateCheckGrid';
        this.IsImmediateCheckGrid.DataMember = 'IsImmediate';



        this.CaseOfNeedCheck = new TTVisual.TTCheckBox();
        this.CaseOfNeedCheck.Value = false;
        this.CaseOfNeedCheck.Title = i18n("M26386", "Lüzumu Halinde");
        this.CaseOfNeedCheck.Name = 'CaseOfNeedCheck';
        this.CaseOfNeedCheck.TabIndex = 4;

        this.NextDayCheck = new TTVisual.TTCheckBox();
        this.NextDayCheck.Value = false;
        //this.NextDayCheck.Visible = false;
        this.NextDayCheck.Title = i18n("M26386", "Gün Aşırı (1x1 için)");
        this.NextDayCheck.Name = 'NextDayCheck';
        this.NextDayCheck.TabIndex = 99;

        this.CaseOfNeedCheckGrid = new TTVisual.TTCheckBoxColumn();
        this.CaseOfNeedCheckGrid.HeaderText = i18n("M26386", "Lüzumu Halinde");
        this.CaseOfNeedCheckGrid.Name = 'CaseOfNeedCheckGrid';
        this.CaseOfNeedCheckGrid.DataMember = 'CaseOfNeed';





        this.ttgroupbox3 = new TTVisual.TTGroupBox();
        this.ttgroupbox3.Text = i18n("M20941", "Reçete Detayı");
        this.ttgroupbox3.Name = 'ttgroupbox3';
        this.ttgroupbox3.TabIndex = 3;

        this.DrugDescription = new TTVisual.TTTextBox();
        this.DrugDescription.Name = 'DrugDescription';
        this.DrugDescription.TabIndex = 14;
        this.DrugDescription.Visible = true;

        this.labelDrugDescription = new TTVisual.TTLabel();
        this.labelDrugDescription.Text = i18n("M15228", "Hasta Güvenlik ve İzleme Formu");
        this.labelDrugDescription.Name = 'labelDrugDescription';
        this.labelDrugDescription.TabIndex = 15;
        this.DrugDescription.Visible = true;

        this.labelDrugUsageType = new TTVisual.TTLabel();
        this.labelDrugUsageType.Text = i18n("M17982", "Kullanım Şekli");
        this.labelDrugUsageType.Name = 'labelDrugUsageType';
        this.labelDrugUsageType.TabIndex = 15;

        this.btnIlacBilgileri = new TTVisual.TTButton();
        this.btnIlacBilgileri.Text = i18n("M16306", "İlaç Bilgileri");
        this.btnIlacBilgileri.Name = 'btnIlacBilgileri';
        this.btnIlacBilgileri.TabIndex = 19;

        this.DrugUsageType = new TTVisual.TTEnumComboBox();
        this.DrugUsageType.DataTypeName = 'DrugUsageTypeEnum';
        this.DrugUsageType.Name = 'DrugUsageType';
        this.DrugUsageType.TabIndex = 14;
        this.DrugUsageType.SortBy = SortByEnum.DisplayText;

        this.labelDrugName = new TTVisual.TTLabel();
        this.labelDrugName.Text = i18n("M16287", "İlaç");
        this.labelDrugName.Name = 'labelDrugName';
        this.labelDrugName.TabIndex = 14;

        this.labelOrderDay = new TTVisual.TTLabel();
        this.labelOrderDay.Text = i18n("M14998", "Gün");
        this.labelOrderDay.Name = 'labelOrderDay';
        this.labelOrderDay.TabIndex = 18;

        this.DrugName = new TTVisual.TTTextBox();
        this.DrugName.BackColor = '#F0F0F0';
        this.DrugName.ReadOnly = true;
        this.DrugName.Name = 'DrugName';
        this.DrugName.TabIndex = 0;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = 'X';
        this.ttlabel5.Name = 'ttlabel5';
        this.ttlabel5.TabIndex = 2;

        this.OrderDay = new TTVisual.TTTextBox();
        this.OrderDay.Name = 'OrderDay';
        this.OrderDay.TabIndex = 3;

        this.labelPlannedStartTime = new TTVisual.TTLabel();
        this.labelPlannedStartTime.Text = i18n("M23752", "Uygulama Başlangıç Zamanı");
        this.labelPlannedStartTime.Name = 'labelPlannedStartTime';
        this.labelPlannedStartTime.TabIndex = 8;

        this.OrderDose = new TTVisual.TTTextBox();
        this.OrderDose.Name = 'OrderDose';
        this.OrderDose.TabIndex = 2;


        this.PlannedStartTime = new TTVisual.TTDateTimePicker();
        this.PlannedStartTime.CustomFormat = 'dd.MM.yyyy';
        this.PlannedStartTime.Format = DateTimePickerFormat.Short;
        this.PlannedStartTime.Name = 'PlannedStartTime';
        this.PlannedStartTime.TabIndex = 4;

        this.labelOrderDose = new TTVisual.TTLabel();
        this.labelOrderDose.Text = i18n("M13284", "Doz");
        this.labelOrderDose.Name = 'labelOrderDose';
        this.labelOrderDose.TabIndex = 14;

        this.btnSUTBilgileri = new TTVisual.TTButton();
        this.btnSUTBilgileri.Text = i18n("M22388", "SUT Bilgileri");
        this.btnSUTBilgileri.Name = 'btnSUTBilgileri';
        this.btnSUTBilgileri.TabIndex = 19;

        this.btnDrugInfo = new TTVisual.TTButton();
        this.btnDrugInfo.Text = i18n("M16306", "İlaç Bilgileri");
        this.btnDrugInfo.Name = 'btnSUTBilgileri';
        this.btnDrugInfo.TabIndex = 19;

        this.labelOrderFrequency = new TTVisual.TTLabel();
        this.labelOrderFrequency.Text = i18n("M13285", "Doz Aralığı");
        this.labelOrderFrequency.Name = 'labelOrderFrequency';
        this.labelOrderFrequency.TabIndex = 16;

        this.OrderFrequency = new TTVisual.TTTextBox();
        this.OrderFrequency.Name = 'OrderFrequency';
        this.OrderFrequency.TabIndex = 1;

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = i18n("M21519", "Seçilen İlacın Bilgileri");
        this.ttgroupbox1.Name = 'ttgroupbox1';
        this.ttgroupbox1.TabIndex = 9;

        this.labelVolumeUnit = new TTVisual.TTLabel();
        this.labelVolumeUnit.Text = 'Birim';
        this.labelVolumeUnit.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.labelVolumeUnit.ForeColor = '#000000';
        this.labelVolumeUnit.Name = 'labelVolumeUnit';
        this.labelVolumeUnit.TabIndex = 14;

        this.Unit = new TTVisual.TTTextBox();
        this.Unit.BackColor = '#F0F0F0';
        this.Unit.ReadOnly = true;
        this.Unit.Name = 'Unit';
        this.Unit.TabIndex = 13;


        this.Dose = new TTVisual.TTTextBox();
        this.Dose.BackColor = '#F0F0F0';
        this.Dose.ReadOnly = true;
        this.Dose.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.Dose.Name = 'Dose';
        this.Dose.TabIndex = 0;

        this.labelVolume = new TTVisual.TTLabel();
        this.labelVolume.Text = i18n("M15056", "Hacim");
        this.labelVolume.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.labelVolume.ForeColor = '#000000';
        this.labelVolume.Name = 'labelVolume';
        this.labelVolume.TabIndex = 13;

        this.Volume = new TTVisual.TTTextBox();
        this.Volume.BackColor = '#F0F0F0';
        this.Volume.ReadOnly = true;
        this.Volume.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.Volume.Name = 'Volume';
        this.Volume.TabIndex = 1;

        this.labelDose = new TTVisual.TTLabel();
        this.labelDose.Text = i18n("M13284", "Doz");
        this.labelDose.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.labelDose.ForeColor = '#000000';
        this.labelDose.Name = 'labelDose';
        this.labelDose.TabIndex = 12;

        this.MaxDose = new TTVisual.TTTextBox();
        this.MaxDose.BackColor = '#F0F0F0';
        this.MaxDose.ReadOnly = true;
        this.MaxDose.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.MaxDose.Name = 'MaxDose';
        this.MaxDose.TabIndex = 6;

        this.labelMaxDoseDay = new TTVisual.TTLabel();
        this.labelMaxDoseDay.Text = i18n("M18713", "Max. Gün");
        this.labelMaxDoseDay.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.labelMaxDoseDay.ForeColor = '#000000';
        this.labelMaxDoseDay.Name = 'labelMaxDoseDay';
        this.labelMaxDoseDay.TabIndex = 17;

        this.MaxDoseDay = new TTVisual.TTTextBox();
        this.MaxDoseDay.BackColor = '#F0F0F0';
        this.MaxDoseDay.ReadOnly = true;
        this.MaxDoseDay.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.MaxDoseDay.Name = 'MaxDoseDay';
        this.MaxDoseDay.TabIndex = 5;

        this.labelMaxDose = new TTVisual.TTLabel();
        this.labelMaxDose.Text = i18n("M18712", "Max. Doz");
        this.labelMaxDose.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.labelMaxDose.ForeColor = '#000000';
        this.labelMaxDose.Name = 'labelMaxDose';
        this.labelMaxDose.TabIndex = 18;

        this.ttgroupbox2 = new TTVisual.TTGroupBox();
        this.ttgroupbox2.Text = i18n("M21071", "Rutin Değerler");
        this.ttgroupbox2.BackColor = '#FFFFFF';
        this.ttgroupbox2.Name = 'ttgroupbox2';
        this.ttgroupbox2.TabIndex = 23;

        this.UseRoutineValue = new TTVisual.TTCheckBox();
        this.UseRoutineValue.Value = false;
        this.UseRoutineValue.Text = i18n("M21072", "Rutin Değerleri Kullan");
        this.UseRoutineValue.Name = 'UseRoutineValue';
        this.UseRoutineValue.TabIndex = 13;

        this.labelRoutineDay = new TTVisual.TTLabel();
        this.labelRoutineDay.Text = i18n("M14998", "Gün");
        this.labelRoutineDay.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.labelRoutineDay.ForeColor = '#000000';
        this.labelRoutineDay.Name = 'labelRoutineDay';
        this.labelRoutineDay.TabIndex = 19;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = i18n("M13285", "Doz Aralığı");
        this.ttlabel10.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ttlabel10.ForeColor = '#000000';
        this.ttlabel10.Name = 'ttlabel10';
        this.ttlabel10.TabIndex = 28;

        this.tttextbox7 = new TTVisual.TTTextBox();
        this.tttextbox7.BackColor = '#F0F0F0';
        this.tttextbox7.ReadOnly = true;
        this.tttextbox7.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.tttextbox7.Name = 'tttextbox7';
        this.tttextbox7.TabIndex = 17;

        this.tttextbox8 = new TTVisual.TTTextBox();
        this.tttextbox8.BackColor = '#F0F0F0';
        this.tttextbox8.ReadOnly = true;
        this.tttextbox8.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.tttextbox8.Name = 'tttextbox8';
        this.tttextbox8.TabIndex = 18;

        this.ttlabel11 = new TTVisual.TTLabel();
        this.ttlabel11.Text = i18n("M13294", "Doz Miktarı");
        this.ttlabel11.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ttlabel11.ForeColor = '#000000';
        this.ttlabel11.Name = 'ttlabel11';
        this.ttlabel11.TabIndex = 20;

        this.ttenumcombobox2 = new TTVisual.TTEnumComboBox();
        this.ttenumcombobox2.DataTypeName = 'FrequencyEnum';
        this.ttenumcombobox2.BackColor = '#F0F0F0';
        this.ttenumcombobox2.Enabled = false;
        this.ttenumcombobox2.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ttenumcombobox2.Name = 'ttenumcombobox2';
        this.ttenumcombobox2.TabIndex = 25;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M16287", "İlaç");
        this.ttlabel1.Name = 'ttlabel1';
        this.ttlabel1.TabIndex = 2;

        this.cmdAddDrug = new TTVisual.TTButton();
        this.cmdAddDrug.Text = i18n("M13543", "Ekle");
        this.cmdAddDrug.Name = 'cmdAddDrug';
        this.cmdAddDrug.TabIndex = 5;

        this.SearchTextbox = new TTVisual.TTTextBox();
        this.SearchTextbox.CharacterCasing = CharacterCasing.Upper;
        this.SearchTextbox.Name = 'SearchTextbox';
        this.SearchTextbox.TabIndex = 0;

        this.DrugListview = new TTVisual.TTListView();
        this.DrugListview.MultiSelect = false;
        this.DrugListview.Name = 'DrugListview';
        this.DrugListview.TabIndex = 0;

        this.OldOrderTabPage = new TTVisual.TTTabPage();
        this.OldOrderTabPage.DisplayIndex = 1;
        this.OldOrderTabPage.TabIndex = 1;
        this.OldOrderTabPage.Text = i18n("M13863", "Eski İlaç Direktifleri / Sık Kullanılan İlaçlar / Kullanıcı Şablonları");
        this.OldOrderTabPage.Name = 'OldOrderTabPage';

        this.cmdGetTemplate = new TTVisual.TTButton();
        this.cmdGetTemplate.Text = i18n("M22460", "Şablonlardan Seç");
        this.cmdGetTemplate.Name = 'cmdGetTemplate';
        this.cmdGetTemplate.TabIndex = 14;

        this.cmdAddTemplate = new TTVisual.TTButton();
        this.cmdAddTemplate.Text = i18n("M22450", "Şablon Olarak Ekle");
        this.cmdAddTemplate.Name = 'cmdAddTemplate';
        this.cmdAddTemplate.TabIndex = 13;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M13862", "Eski İlaç Direktifleri");
        this.ttlabel2.Name = 'ttlabel2';
        this.ttlabel2.TabIndex = 12;

        this.FavoriteDrugListview = new TTVisual.TTListView();
        this.FavoriteDrugListview.Name = 'FavoriteDrugListview';
        this.FavoriteDrugListview.TabIndex = 3;

        this.OldDrugOrders = new TTVisual.TTGrid();
        this.OldDrugOrders.Name = 'OldDrugOrders';
        this.OldDrugOrders.TabIndex = 11;
        this.OldDrugOrders.Height = '400px';
        this.OldDrugOrders.AllowUserToAddRows = false;
        this.OldDrugOrders.AllowUserToDeleteRows = false;

        this.cmdRepat = new TTVisual.TTButtonColumn();
        this.cmdRepat.Text = i18n("M23128", "Tekrarla");
        this.cmdRepat.DisplayIndex = 0;
        this.cmdRepat.HeaderText = i18n("M23128", "Tekrarla");
        this.cmdRepat.Name = 'cmdRepat';
        this.cmdRepat.ToolTipText = i18n("M23128", "Tekrarla");
        this.cmdRepat.Width = 80;

        this.OldDrugPlanDate = new TTVisual.TTDateTimePickerColumn();
        this.OldDrugPlanDate.Format = DateTimePickerFormat.Long;
        this.OldDrugPlanDate.CustomFormat = 'dd/MM/yyyy HH:mm';
        this.OldDrugPlanDate.DataMember = 'DrugOrder.PlannedStartTime';
        this.OldDrugPlanDate.DisplayIndex = 1;
        this.OldDrugPlanDate.HeaderText = i18n("M20372", "Plan.Baş.Tarihi");
        this.OldDrugPlanDate.Name = 'OldDrugPlanDate';
        this.OldDrugPlanDate.ReadOnly = true;
        this.OldDrugPlanDate.Width = 150;

        this.OldDrug = new TTVisual.TTListBoxColumn();
        this.OldDrug.ListDefName = 'DrugList';
        this.OldDrug.DataMember = 'DrugOrder.Material';
        this.OldDrug.DisplayIndex = 2;
        this.OldDrug.HeaderText = i18n("M16287", "İlaç");
        this.OldDrug.Name = 'OldDrug';
        this.OldDrug.ReadOnly = true;
        this.OldDrug.Width = 300;

        this.OldDrugFrequency = new TTVisual.TTEnumComboBoxColumn();
        this.OldDrugFrequency.DataTypeName = 'FrequencyEnum';
        this.OldDrugFrequency.DataMember = 'DrugOrder.Frequency';
        this.OldDrugFrequency.DisplayIndex = 3;
        this.OldDrugFrequency.HeaderText = i18n("M13285", "Doz Aralığı");
        this.OldDrugFrequency.Name = 'OldDrugFrequency';
        this.OldDrugFrequency.ReadOnly = true;
        this.OldDrugFrequency.Width = 150;

        this.OldDoseAmount = new TTVisual.TTTextBoxColumn();
        this.OldDoseAmount.DataMember = 'DrugOrder.DoseAmount';
        this.OldDoseAmount.DisplayIndex = 4;
        this.OldDoseAmount.HeaderText = i18n("M13294", "Doz Miktarı");
        this.OldDoseAmount.Name = 'OldDoseAmount';
        this.OldDoseAmount.ReadOnly = true;
        this.OldDoseAmount.Width = 80;

        this.OldDay = new TTVisual.TTTextBoxColumn();
        this.OldDay.DataMember = 'DrugOrder.Day';
        this.OldDay.DisplayIndex = 5;
        this.OldDay.HeaderText = i18n("M14998", "Gün");
        this.OldDay.Name = 'OldDay';
        this.OldDay.ReadOnly = false;
        this.OldDay.Width = 80;

        this.OldUseDescription = new TTVisual.TTTextBoxColumn();
        this.OldUseDescription.DataMember = 'DrugOrder.UsageNote';
        this.OldUseDescription.DisplayIndex = 6;
        this.OldUseDescription.HeaderText = i18n("M17991", "Kullanma Açıklaması");
        this.OldUseDescription.Name = 'OldUseDescription';
        this.OldUseDescription.ReadOnly = true;
        this.OldUseDescription.Width = 200;

        this.ttgroupbox4 = new TTVisual.TTGroupBox();
        this.ttgroupbox4.Text = i18n("M21797", "Sık Kullanılan İlaç Direktifi");
        this.ttgroupbox4.Name = 'ttgroupbox4';
        this.ttgroupbox4.TabIndex = 10;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M16287", "İlaç");
        this.ttlabel3.Name = 'ttlabel3';
        this.ttlabel3.TabIndex = 14;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M14998", "Gün");
        this.ttlabel4.Name = 'ttlabel4';
        this.ttlabel4.TabIndex = 18;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.BackColor = '#F0F0F0';
        this.tttextbox1.ReadOnly = true;
        this.tttextbox1.Name = 'tttextbox1';
        this.tttextbox1.TabIndex = 13;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = 'X';
        this.ttlabel6.Name = 'ttlabel6';
        this.ttlabel6.TabIndex = 17;

        this.FavoriteDrugDay = new TTVisual.TTTextBox();
        this.FavoriteDrugDay.Name = 'FavoriteDrugDay';
        this.FavoriteDrugDay.TabIndex = 17;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = i18n("M23752", "Uygulama Başlangıç Zamanı");
        this.ttlabel7.Name = 'ttlabel7';
        this.ttlabel7.TabIndex = 8;


        this.FavoriteDrugDose = new TTVisual.TTTextBox();
        this.FavoriteDrugDose.Name = 'FavoriteDrugDose';
        this.FavoriteDrugDose.TabIndex = 13;

        this.ttdatetimepicker1 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker1.CustomFormat = 'dd.MM.yyyy HH:mm';
        this.ttdatetimepicker1.Format = DateTimePickerFormat.Custom;
        this.ttdatetimepicker1.Name = 'ttdatetimepicker1';
        this.ttdatetimepicker1.TabIndex = 7;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = i18n("M13284", "Doz");
        this.ttlabel8.Name = 'ttlabel8';
        this.ttlabel8.TabIndex = 14;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = i18n("M13285", "Doz Aralığı");
        this.ttlabel9.Name = 'ttlabel9';
        this.ttlabel9.TabIndex = 16;

        this.cmdFavoriteDrug = new TTVisual.TTButton();
        this.cmdFavoriteDrug.Text = i18n("M13543", "Ekle");
        this.cmdFavoriteDrug.Name = 'cmdFavoriteDrug';
        this.cmdFavoriteDrug.TabIndex = 5;

        this.FavoriteDrugFrequency = new TTVisual.TTTextBox();
        this.FavoriteDrugFrequency.Name = 'FavoriteDrugFrequency';
        this.FavoriteDrugFrequency.TabIndex = 15;

        this.PrescriptionTabPage = new TTVisual.TTTabPage();
        this.PrescriptionTabPage.DisplayIndex = 2;
        this.PrescriptionTabPage.TabIndex = 2;
        this.PrescriptionTabPage.Text = i18n("M24404", "Yatan Hasta Reçeteleri");
        this.PrescriptionTabPage.Name = 'PrescriptionTabPage';

        this.InpatientPresDetails = new TTVisual.TTGrid();
        this.InpatientPresDetails.Name = 'InpatientPresDetails';
        this.InpatientPresDetails.TabIndex = 13;
        this.InpatientPresDetails.AllowUserToAddRows = false;
        this.InpatientPresDetails.AllowUserToDeleteRows = false;


        this.PrescriptionType = new TTVisual.TTEnumComboBoxColumn();
        this.PrescriptionType.DataTypeName = 'PrescriptionTypeEnum';
        this.PrescriptionType.DataMember = 'InpatientPrescription.PrescriptionType';
        this.PrescriptionType.DisplayIndex = 0;
        this.PrescriptionType.HeaderText = i18n("M20960", "Reçete Tipi");
        this.PrescriptionType.Name = 'PrescriptionType';
        this.PrescriptionType.ReadOnly = true;
        this.PrescriptionType.Width = 300;

        this.EReceteNo = new TTVisual.TTTextBoxColumn();
        this.EReceteNo.DataMember = 'InpatientPrescription.EReceteNo';
        this.EReceteNo.DisplayIndex = 1;
        this.EReceteNo.HeaderText = i18n("M13425", "E Reçete No");
        this.EReceteNo.Name = 'EReceteNo';
        this.EReceteNo.ReadOnly = true;
        this.EReceteNo.Width = 300;

        this.EReceteDescription = new TTVisual.TTComboBoxColumn();
        this.EReceteDescription.DataMember = 'InpatientPrescription.EReceteDescription';
        this.EReceteDescription.DisplayIndex = 2;
        this.EReceteDescription.HeaderText = i18n("M13426", "E Reçete Sonuç");
        this.EReceteDescription.Name = 'EReceteDescription';
        this.EReceteDescription.ReadOnly = true;
        this.EReceteDescription.Width = 300;

        this.OutPatientTabPage = new TTVisual.TTTabPage();
        this.OutPatientTabPage.DisplayIndex = 3;
        this.OutPatientTabPage.TabIndex = 4;
        this.OutPatientTabPage.Text = i18n("M15046", "Günübirlik Reçeteleri");
        this.OutPatientTabPage.Name = 'OutPatientTabPage';

        this.OutpatientPresDetails = new TTVisual.TTGrid();
        this.OutpatientPresDetails.Name = 'OutpatientPresDetails';
        this.OutpatientPresDetails.TabIndex = 14;
        this.OutpatientPresDetails.AllowUserToAddRows = false;
        this.OutpatientPresDetails.AllowUserToDeleteRows = false;

        this.OutPresType = new TTVisual.TTEnumComboBoxColumn();
        this.OutPresType.DataTypeName = 'PrescriptionTypeEnum';
        this.OutPresType.DataMember = 'OutPatientPrescription.PrescriptionType';
        this.OutPresType.DisplayIndex = 0;
        this.OutPresType.HeaderText = i18n("M20960", "Reçete Tipi");
        this.OutPresType.Name = 'OutPresType';
        this.OutPresType.ReadOnly = true;
        this.OutPresType.Width = 300;

        this.OutPresEReceteNo = new TTVisual.TTTextBoxColumn();
        this.OutPresEReceteNo.DataMember = 'OutPatientPrescription.EReceteNo';
        this.OutPresEReceteNo.DisplayIndex = 1;
        this.OutPresEReceteNo.HeaderText = i18n("M13425", "E Reçete No");
        this.OutPresEReceteNo.Name = 'OutPresEReceteNo';
        this.OutPresEReceteNo.ReadOnly = true;
        this.OutPresEReceteNo.Width = 300;

        this.OutPresEReceteDesc = new TTVisual.TTTextBoxColumn();
        this.OutPresEReceteDesc.DataMember = 'OutPatientPrescription.EReceteDescription';
        this.OutPresEReceteDesc.DisplayIndex = 2;
        this.OutPresEReceteDesc.HeaderText = i18n("M13426", "E Reçete Sonuç");
        this.OutPresEReceteDesc.Name = 'OutPresEReceteDesc';
        this.OutPresEReceteDesc.ReadOnly = true;
        this.OutPresEReceteDesc.Width = 300;

        this.PatientInfoTabPage = new TTVisual.TTTabPage();
        this.PatientInfoTabPage.DisplayIndex = 4;
        this.PatientInfoTabPage.TabIndex = 3;
        this.PatientInfoTabPage.Text = i18n("M15158", "Hasta Bilgileri");
        this.PatientInfoTabPage.Name = 'PatientInfoTabPage';

        this.ttlabel12 = new TTVisual.TTLabel();
        this.ttlabel12.Text = i18n("M15483", "Hastanın Tanıları");
        this.ttlabel12.Name = 'ttlabel12';
        this.ttlabel12.TabIndex = 13;

        this.DiagnosisForPrescriptions = new TTVisual.TTGrid();
        this.DiagnosisForPrescriptions.Name = 'DiagnosisForPrescriptions';
        this.DiagnosisForPrescriptions.TabIndex = 13;

        this.CodeDiagnosisForPresc = new TTVisual.TTTextBoxColumn();
        this.CodeDiagnosisForPresc.DataMember = 'Code';
        this.CodeDiagnosisForPresc.DisplayIndex = 0;
        this.CodeDiagnosisForPresc.HeaderText = 'Kodu';
        this.CodeDiagnosisForPresc.Name = 'CodeDiagnosisForPresc';
        this.CodeDiagnosisForPresc.Width = 80;

        this.NameDiagnosisForPresc = new TTVisual.TTTextBoxColumn();
        this.NameDiagnosisForPresc.DataMember = 'Name';
        this.NameDiagnosisForPresc.DisplayIndex = 1;
        this.NameDiagnosisForPresc.HeaderText = i18n("M10514", "Adı");
        this.NameDiagnosisForPresc.Name = 'NameDiagnosisForPresc';
        this.NameDiagnosisForPresc.Width = 500;

        this.FullNamePatient = new TTVisual.TTTextBox();
        this.FullNamePatient.BackColor = '#F0F0F0';
        this.FullNamePatient.ForeColor = '#FF0000';
        this.FullNamePatient.ReadOnly = true;
        this.FullNamePatient.Name = 'FullNamePatient';
        this.FullNamePatient.TabIndex = 9;

        this.ID = new TTVisual.TTTextBox();
        this.ID.BackColor = '#F0F0F0';
        this.ID.ReadOnly = true;
        this.ID.Name = 'ID';
        this.ID.TabIndex = 2;

        this.labelFullNamePatient = new TTVisual.TTLabel();
        this.labelFullNamePatient.Text = i18n("M15428", "Hastanın Adı Soyadı");
        this.labelFullNamePatient.Name = 'labelFullNamePatient';
        this.labelFullNamePatient.TabIndex = 10;

        this.labelMasterResource = new TTVisual.TTLabel();
        this.labelMasterResource.Text = i18n("M15565", "Havale Edilen Birim");
        this.labelMasterResource.Name = 'labelMasterResource';
        this.labelMasterResource.TabIndex = 6;

        this.MasterResource = new TTVisual.TTObjectListBox();
        this.MasterResource.ReadOnly = true;
        this.MasterResource.ListDefName = 'ResourceListDefinition';
        this.MasterResource.Name = 'MasterResource';
        this.MasterResource.TabIndex = 5;

        this.DrugOrderIntroductionDetails = new TTVisual.TTGrid();
        this.DrugOrderIntroductionDetails.Name = 'DrugOrderIntroductionDetails';
        this.DrugOrderIntroductionDetails.TabIndex = 4;
        this.DrugOrderIntroductionDetails.AllowUserToAddRows = false;
        //this.DrugOrderIntroductionDetails.AllowUserToDeleteRows = true;
        this.DrugOrderIntroductionDetails.Height = '200px';

        this.PatientOwnDrug = new TTVisual.TTCheckBoxColumn();
        this.PatientOwnDrug.DataMember = 'PatientOwnDrug';
        this.PatientOwnDrug.DisplayIndex = 0;
        this.PatientOwnDrug.HeaderText = i18n("M15218", "Hasta Getirdi");
        this.PatientOwnDrug.Name = 'PatientOwnDrug';
        this.PatientOwnDrug.ReadOnly = true;
        //this.PatientOwnDrug.Width = 50;


        this.PlannedTime = new TTVisual.TTDateTimePickerColumn();
        this.PlannedTime.Format = DateTimePickerFormat.Long;
        this.PlannedTime.CustomFormat = 'dd/MM/yyyy HH:mm';
        this.PlannedTime.DataMember = 'PlannedStartTime';
        this.PlannedTime.Required = true;
        this.PlannedTime.DisplayIndex = 1;
        this.PlannedTime.HeaderText = i18n("M27573", "Uyg. Baş. Zamanı");
        this.PlannedTime.Name = 'PlannedTime';
        this.PlannedTime.Width = 180;
        this.PlannedTime.ReadOnly = true;

        this.MaterialDrugOrderIntroductionDet = new TTVisual.TTTextBoxColumn();
        this.MaterialDrugOrderIntroductionDet.DataMember = 'Material.Name';
        this.MaterialDrugOrderIntroductionDet.Required = true;
        this.MaterialDrugOrderIntroductionDet.DisplayIndex = 2;
        this.MaterialDrugOrderIntroductionDet.HeaderText = i18n("M16287", "İlaç");
        this.MaterialDrugOrderIntroductionDet.Name = 'MaterialDrugOrderIntroductionDet';
        this.MaterialDrugOrderIntroductionDet.Width = 180;
        this.MaterialDrugOrderIntroductionDet.IsNumeric = false;

        /*this.VolumeUnit = new TTVisual.TTTextBoxColumn();
        this.VolumeUnit.DataMember = "VolumeUnit";
        this.VolumeUnit.DisplayIndex = 3;
        this.VolumeUnit.HeaderText = "İlaç Hacmi";
        this.VolumeUnit.Name = "VolumeUnit";
        this.VolumeUnit.ReadOnly = true;
        this.VolumeUnit.Width = 80;*/

        this.FrequencyDrugOrderIntroductionDet = new TTVisual.TTEnumComboBoxColumn();
        this.FrequencyDrugOrderIntroductionDet.DataTypeName = 'FrequencyEnum';
        this.FrequencyDrugOrderIntroductionDet.DataMember = 'Frequency';
        this.FrequencyDrugOrderIntroductionDet.Required = true;
        this.FrequencyDrugOrderIntroductionDet.DisplayIndex = 4;
        this.FrequencyDrugOrderIntroductionDet.HeaderText = i18n("M13285", "Doz Aralığı");
        this.FrequencyDrugOrderIntroductionDet.Name = 'FrequencyDrugOrderIntroductionDet';
        this.FrequencyDrugOrderIntroductionDet.ReadOnly = true;
        //this.FrequencyDrugOrderIntroductionDet.Width = 50;
        this.FrequencyDrugOrderIntroductionDet.ShowClearButton = false;


        this.DoseAmountDrugOrderIntroductionDet = new TTVisual.TTTextBoxColumn();
        this.DoseAmountDrugOrderIntroductionDet.DataMember = 'DoseAmount';
        this.DoseAmountDrugOrderIntroductionDet.Required = true;
        this.DoseAmountDrugOrderIntroductionDet.DisplayIndex = 5;
        this.DoseAmountDrugOrderIntroductionDet.HeaderText = i18n("M13294", "Doz Miktarı");
        this.DoseAmountDrugOrderIntroductionDet.Name = 'DoseAmountDrugOrderIntroductionDet';
        this.DoseAmountDrugOrderIntroductionDet.ReadOnly = true;
        //this.DoseAmountDrugOrderIntroductionDet.Width = 50;
        this.DoseAmountDrugOrderIntroductionDet.IsNumeric = true;

        this.DayDrugOrderIntroductionDet = new TTVisual.TTTextBoxColumn();
        this.DayDrugOrderIntroductionDet.DataMember = 'Day';
        this.DayDrugOrderIntroductionDet.Required = true;
        this.DayDrugOrderIntroductionDet.DisplayIndex = 6;
        this.DayDrugOrderIntroductionDet.HeaderText = i18n("M14998", "Gün");
        this.DayDrugOrderIntroductionDet.ReadOnly = false;
        this.DayDrugOrderIntroductionDet.Name = 'DayDrugOrderIntroductionDet';
        //this.DayDrugOrderIntroductionDet.Width = 50;

        this.UsageNoteDrugOrderIntroductionDet = new TTVisual.TTTextBoxColumn();
        this.UsageNoteDrugOrderIntroductionDet.DataMember = 'UsageNote';
        this.UsageNoteDrugOrderIntroductionDet.DisplayIndex = 7;
        this.UsageNoteDrugOrderIntroductionDet.HeaderText = i18n("M17991", "Kullanma Açıklaması");
        this.UsageNoteDrugOrderIntroductionDet.Name = 'UsageNoteDrugOrderIntroductionDet';
        //this.UsageNoteDrugOrderIntroductionDet.Width = 50;

        this.tttextboxcolumn2 = new TTVisual.TTTextBoxColumn();
        this.tttextboxcolumn2.DataMember = 'DrugDescription';
        this.tttextboxcolumn2.DisplayIndex = 11;
        this.tttextboxcolumn2.HeaderText = i18n("M16361", "İlaç Reçete Açk.");
        this.tttextboxcolumn2.Name = 'tttextboxcolumn2';
        //this.tttextboxcolumn2.Width = 50;


        this.tttextboxcolumn3 = new TTVisual.TTTextBoxColumn();
        this.tttextboxcolumn3.DataMember = 'DrugOrderType';
        this.tttextboxcolumn3.DisplayIndex = 12;
        this.tttextboxcolumn3.HeaderText = "Tedavi Türü";
        this.tttextboxcolumn3.Name = 'tttextboxcolumn3';
        //this.tttextboxcolumn3.Width = 50;
        this.tttextboxcolumn3.ReadOnly = true;

        this.labelID = new TTVisual.TTLabel();
        this.labelID.Text = i18n("M16869", "İşlem Nu.");
        this.labelID.Name = 'labelID';
        this.labelID.TabIndex = 3;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelActionDate.Name = 'labelActionDate';
        this.labelActionDate.TabIndex = 1;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = '#F0F0F0';
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = 'ActionDate';
        this.ActionDate.TabIndex = 0;


        this.ttenumcomboboxcolumn1 = new TTVisual.TTEnumComboBoxColumn();
        this.ttenumcomboboxcolumn1.DataTypeName = 'PeriodUnitTypeEnum';
        this.ttenumcomboboxcolumn1.DataMember = 'PeriodUnitType';
        this.ttenumcomboboxcolumn1.Required = true;
        this.ttenumcomboboxcolumn1.DisplayIndex = 7;
        this.ttenumcomboboxcolumn1.HeaderText = i18n("M17981", "Kullanım Peryodu");
        this.ttenumcomboboxcolumn1.Name = 'ttenumcomboboxcolumn1';
        //this.ttenumcomboboxcolumn1.Width = 50;
        this.ttenumcomboboxcolumn1.ReadOnly = this.isInpatient;


        this.tttextboxcolumn1 = new TTVisual.TTTextBoxColumn();
        this.tttextboxcolumn1.DataMember = 'PackageAmount';
        this.tttextboxcolumn1.Required = true;
        this.tttextboxcolumn1.DisplayIndex = 8;
        this.tttextboxcolumn1.HeaderText = i18n("M18120", "Kutu Adedi");
        this.tttextboxcolumn1.Name = 'tttextboxcolumn1';
        //this.tttextboxcolumn1.Width = 50;
        this.tttextboxcolumn1.ReadOnly = this.isInpatient;


        this.buttonDeleteDrugOrder = new TTVisual.TTButtonColumn();
        this.buttonDeleteDrugOrder.Text = 'Sil';
        this.buttonDeleteDrugOrder.Name = 'buttonDeleteDrugOrder';
        this.buttonDeleteDrugOrder.DisplayIndex = 1;
        //this.buttonDeleteDrugOrder.Width = 50;

        this.buttonChangeSchedule = new TTVisual.TTButtonColumn();
        this.buttonChangeSchedule.Text = 'Zaman Çizelgesi';
        this.buttonChangeSchedule.Name = 'buttonChangeSchedule';
        this.buttonChangeSchedule.Width = 130;

        //this.buttonChangeSchedule.DisplayIndex = 0;

        this.ttenumcomboboxcolumn2 = new TTVisual.TTEnumComboBoxColumn();
        this.ttenumcomboboxcolumn2.DataTypeName = 'DescriptionTypeEnum';
        this.ttenumcomboboxcolumn2.DataMember = 'DrugDescriptionType';
        this.ttenumcomboboxcolumn2.DisplayIndex = 10;
        this.ttenumcomboboxcolumn2.HeaderText = i18n("M20930", "Reçete Açk. Tür");
        this.ttenumcomboboxcolumn2.Name = 'ttenumcomboboxcolumn2';
        //this.ttenumcomboboxcolumn2.Width = 50;




        this.DrugOrderType = new TTVisual.TTEnumComboBoxColumn();
        this.DrugOrderType.DataTypeName = 'DrugOrderTypeEnum';
        this.DrugOrderType.DataMember = 'DrugOrderTypeEnum';
        this.DrugOrderType.DisplayIndex = 13;
        this.DrugOrderType.HeaderText = "Tedavi Türü";
        this.DrugOrderType.Name = 'DrugOrderType';
        //this.DrugOrderType.Width = 50;

        this.DrugOrderTypeColumn = new TTVisual.TTEnumComboBoxColumn();
        this.DrugOrderTypeColumn.DataTypeName = 'DrugOrderTypeEnum';
        this.DrugOrderTypeColumn.DataMember = 'DrugOrderType';
        this.DrugOrderTypeColumn.DisplayIndex = 13;
        this.DrugOrderTypeColumn.HeaderText = "Tedavi Türü";
        this.DrugOrderTypeColumn.Name = 'DrugOrderType';
        //this.DrugOrderTypeColumn.Width = 50;


        this.DrugUsageTypeComboBox = new TTVisual.TTEnumComboBoxColumn();
        this.DrugUsageTypeComboBox.DataTypeName = 'DrugUsageTypeEnum';
        this.DrugUsageTypeComboBox.DataMember = 'DrugUsageType';
        this.DrugUsageTypeComboBox.HeaderText = i18n("M17982", "Kullanım Şekli");

        this.OldDrugOrdersColumns = [this.cmdRepat, this.OldDrugPlanDate, this.OldDrug, this.OldDrugFrequency, this.OldDoseAmount, this.OldDay, this.OldUseDescription];
        this.InpatientPresDetailsColumns = [this.PrescriptionType, this.EReceteNo, this.EReceteDescription];
        this.OutpatientPresDetailsColumns = [this.OutPresType, this.OutPresEReceteNo, this.OutPresEReceteDesc];
        this.DiagnosisForPrescriptionsColumns = [this.CodeDiagnosisForPresc, this.NameDiagnosisForPresc];
       /* bu column sıraları önemli refactor yapılana kadar dikkat edilmeli.
       */ this.DrugOrderIntroductionDetailsColumns = [this.buttonChangeSchedule, this.PlannedTime, this.MaterialDrugOrderIntroductionDet,
         /*this.VolumeUnit,*/ this.FrequencyDrugOrderIntroductionDet, this.DoseAmountDrugOrderIntroductionDet, this.DayDrugOrderIntroductionDet, this.ttenumcomboboxcolumn1,
        this.tttextboxcolumn1, this.UsageNoteDrugOrderIntroductionDet, this.CaseOfNeedCheckGrid,
        this.IsImmediateCheckGrid, this.DrugUsageTypeComboBox, this.DrugOrderTypeColumn, this.buttonDeleteDrugOrder];
        this.tttabcontrol1.Controls = [this.NewOrderTabPage, this.OldOrderTabPage, this.PrescriptionTabPage, this.OutPatientTabPage, this.PatientInfoTabPage];
        this.NewOrderTabPage.Controls = [this.IsBarcode, this.IsInheldDrug, this.AutoSearch, this.cmdSearch, this.PatientOwnDrugCheck, this.IsImmediateCheck, this.DrugUsageTypeComboBox,
        this.ttgroupbox3, this.ttgroupbox1, this.ttlabel1, this.cmdAddDrug, this.SearchTextbox, this.DrugListview];
        this.ttgroupbox3.Controls = [this.DrugDescription, this.labelDrugDescription, this.labelDrugUsageType, this.btnIlacBilgileri,
        this.DrugUsageType, this.labelDrugName, this.labelOrderDay, this.DrugName, this.ttlabel5, this.OrderDay, this.labelPlannedStartTime,
        this.OrderDose, this.PlannedStartTime, this.labelOrderDose, this.btnSUTBilgileri, this.labelOrderFrequency, this.OrderFrequency];
        this.ttgroupbox1.Controls = [this.labelVolumeUnit, this.Unit, this.Dose, this.labelVolume, this.Volume, this.labelDose, this.MaxDose,
        this.labelMaxDoseDay, this.MaxDoseDay, this.labelMaxDose, this.ttgroupbox2];
        this.ttgroupbox2.Controls = [this.UseRoutineValue, this.labelRoutineDay, this.ttlabel10, this.tttextbox7, this.tttextbox8, this.ttlabel11, this.ttenumcombobox2];
        this.OldOrderTabPage.Controls = [this.cmdGetTemplate, this.cmdAddTemplate, this.ttlabel2, this.FavoriteDrugListview, this.OldDrugOrders, this.ttgroupbox4];
        this.ttgroupbox4.Controls = [this.ttlabel3, this.ttlabel4, this.tttextbox1, this.ttlabel6, this.FavoriteDrugDay, this.ttlabel7,
        this.FavoriteDrugDose, this.ttdatetimepicker1, this.ttlabel8, this.ttlabel9, this.cmdFavoriteDrug, this.FavoriteDrugFrequency];
        this.PrescriptionTabPage.Controls = [this.InpatientPresDetails];
        this.OutPatientTabPage.Controls = [this.OutpatientPresDetails];
        this.PatientInfoTabPage.Controls = [this.ttlabel12, this.DiagnosisForPrescriptions];
        this.Controls = [this.buttonChangeSchedule, this.ttlabel13, this.txtStoreName, this.SecondaryMasterResource, this.tttabcontrol1, this.DrugDescriptionType, this.NewOrderTabPage,
        this.IsBarcode, this.IsInheldDrug, this.AutoSearch, this.cmdSearch, this.PatientOwnDrugCheck, this.IsImmediateCheck, this.IsImmediateCheckGrid, this.DrugUsageTypeComboBox,
        this.CaseOfNeedCheck, this.CaseOfNeedCheckGrid, this.ttgroupbox3, this.DrugDescription,
        this.labelDrugDescription, this.labelDrugUsageType, this.btnIlacBilgileri, this.DrugUsageType, this.labelDrugName, this.labelOrderDay,
        this.DrugName, this.ttlabel5, this.OrderDay, this.labelPlannedStartTime, this.OrderDose, this.PlannedStartTime, this.labelOrderDose,
        this.btnSUTBilgileri, this.btnDrugInfo, this.labelOrderFrequency, this.OrderFrequency, this.ttgroupbox1, this.labelVolumeUnit,
        this.Unit, this.Dose, this.labelVolume, this.Volume, this.labelDose, this.MaxDose, this.labelMaxDoseDay, this.MaxDoseDay,
        this.labelMaxDose, this.ttgroupbox2, this.UseRoutineValue, this.labelRoutineDay, this.ttlabel10, this.tttextbox7, this.tttextbox8,
        this.ttlabel11, this.ttenumcombobox2, this.ttlabel1, this.cmdAddDrug, this.SearchTextbox, this.DrugListview, this.OldOrderTabPage,
        this.cmdGetTemplate, this.cmdAddTemplate, this.ttlabel2, this.FavoriteDrugListview, this.OldDrugOrders, this.cmdRepat,
        this.OldDrugPlanDate, this.OldDrug, this.OldDrugFrequency, this.OldDoseAmount, this.OldDay, this.OldUseDescription, this.ttgroupbox4,
        this.ttlabel3, this.ttlabel4, this.tttextbox1, this.ttlabel6, this.FavoriteDrugDay, this.ttlabel7, this.FavoriteDrugDose,
        this.ttdatetimepicker1, this.ttlabel8, this.ttlabel9, this.cmdFavoriteDrug, this.FavoriteDrugFrequency, this.PrescriptionTabPage,
        this.InpatientPresDetails, this.PrescriptionType, this.EReceteNo, this.EReceteDescription, this.OutPatientTabPage,
        this.OutpatientPresDetails, this.OutPresType, this.OutPresEReceteNo, this.OutPresEReceteDesc, this.PatientInfoTabPage,
        this.ttlabel12, this.DiagnosisForPrescriptions, this.CodeDiagnosisForPresc, this.NameDiagnosisForPresc,
        this.FullNamePatient, this.ID, this.labelFullNamePatient, this.labelMasterResource, this.MasterResource,
        this.DrugOrderIntroductionDetails, this.PatientOwnDrug, this.PlannedTime, this.MaterialDrugOrderIntroductionDet,
           /*this.VolumeUnit,*/ this.FrequencyDrugOrderIntroductionDet, this.DoseAmountDrugOrderIntroductionDet, this.DayDrugOrderIntroductionDet,
        this.UsageNoteDrugOrderIntroductionDet, this.ttenumcomboboxcolumn2, this.tttextboxcolumn2, this.tttextboxcolumn3, this.labelID, this.labelActionDate, this.ActionDate, this.DrugOrderType, this.buttonDeleteDrugOrder];

    }


}

export class CreateDrugOrderTSViewModel {
    public DrugOrder: DrugOrder;
    public DrugOrderDetails: Array<DrugOrderDetail>;
}
