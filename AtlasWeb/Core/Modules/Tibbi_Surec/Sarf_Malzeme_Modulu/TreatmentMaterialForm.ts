//$69D05A6C
import { Component, ViewChild, ApplicationRef, Input, AfterViewInit, EventEmitter, Output } from '@angular/core';
import { TreatmentMaterialFormViewModel, GetTreatmentMaterialDetail_Input } from './TreatmentMaterialFormViewModel';
import { AddedTreatmentMaterialsViewModel, TreatmentMaterialStartUpViewModel } from './TreatmentMaterialFormViewModel';
import { AddedTreatmentMaterialInputDVO, TreatmentMaterialInputDVODetail, BaseTreatmentMaterialUTSUsageNotificationResultViewModel, MaterialProcedureViewModel } from './TreatmentMaterialFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { UserHelper } from 'app/Helper/UserHelper';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { BaseTreatmentMaterial, DrugReportType, DrugDefinition, Material, SubEpisode, DrugSpecifications, InPatientPhysicianApplication, NursingApplication, ResClinic, ResUser, ActionTypeEnum, PatientExamination, DentalExamination, Consultation, EmergencyIntervention, MaterialPatientTypeEnum, PatientStatusEnum, SubEpisodeStatusEnum, MaterialDescriptionShowTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MaterialItem, MaterialSelectInputDVO } from 'app/Logistic/Models/MaterialSelectViewModel';
import { EpisodeAction } from 'NebulaClient/Model/AtlasClientModel';

import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DxDataGridComponent, DxDropDownBoxComponent } from 'devextreme-angular';

import { SystemParameterService } from 'ObjectClassService/SystemParameterService';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ResourceService } from 'ObjectClassService/ResourceService';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { ModalInfo, ModalActionResult } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { IModalService } from 'Fw/Services/IModalService';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { EntityStateEnum } from 'NebulaClient/Utils/Enums/EntityStateEnum';



import { DrugOrderIntroductionService, GetDrugReportNo_Input } from 'app/NebulaClient/Services/ObjectService/DrugOrderIntroductionService';
import { throwIfEndless } from 'app/NebulaClient/System/Collections/Enumeration/Enumerator';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { isEmpty } from 'rxjs/operators';
import { DailyInpatientInfoModel } from '../Tibbi_Surec_Evrensel_Modulu/EpisodeActionFormViewModel';
import List from 'app/NebulaClient/System/Collections/List';
import { DailyProvisionInputModel, DailyProvisionSubscribeModel } from '../Tetkik_Istem_Modulu/ProcedureRequestViewModel';
import { Subscription } from 'rxjs';
import { ProcedureRequestSharedService } from "../Tetkik_Istem_Modulu/ProcedureRequestSharedService";
import { ClinicResultModel } from '../Tetkik_Istem_Modulu/RequestedProceduresFormViewModel';
import { PatientInputDTO } from 'app/Logistic/Views/PatientUsedMaterialComponent';
import DataSource from 'devextreme/data/data_source';
import CustomStore from 'devextreme/data/custom_store';
import { TreatmentMaterialTemplateDetailItem } from 'app/Logistic/Views/TreatmentMaterialTemplateComponent';


@Component({
    selector: 'TreatmentMaterialForm',
    templateUrl: './TreatmentMaterialForm.html',
    styles: [` ::ng-deep pointer-column {
        cursor: pointer;
    }
        `],
    providers: [MessageService]
})
export class TreatmentMaterialForm extends TTVisual.TTForm implements AfterViewInit {// implements  OnInit,AfterViewInit, OnChanges
    GridTreatmentMaterials: TTVisual.ITTGrid;
    SelectedStore: TTVisual.ITTObjectListBox;
    TreatmentMaterial: TTVisual.ITTObjectListBox;
    Material: TTVisual.ITTListBoxColumn;
    TreatmentMaterialActionDate: TTVisual.ITTDateTimePickerColumn;
    Barcode: TTVisual.ITTTextBoxColumn;
    DistributionType: TTVisual.ITTTextBoxColumn;
    Amount: TTVisual.ITTTextBoxColumn;
    Notes: TTVisual.ITTTextBoxColumn;
    Kdv: TTVisual.ITTTextBoxColumn;
    KodsuzMalzemeFiyatı: TTVisual.ITTTextBoxColumn;
    MalzemeBrans: TTVisual.ITTTextBoxColumn;
    MalzemeTuru: TTVisual.ITTListBoxColumn;
    SatinAlisTarihi: TTVisual.ITTDateTimePickerColumn;
    ListFilterExpression: string;
    Store: TTVisual.ITTListBoxColumn;
    ActionDate: TTVisual.ITTDateTimePicker;
    @ViewChild('treatmentMaterialGrid') datagrid: DxDataGridComponent;

    @Output() openIstem: EventEmitter<any> = new EventEmitter<any>();

    public showUpdateUTSbutton: boolean = true;

    //EM Grid iken Kullanılıyordu
    // public ComfirmRowDeletingFunc: Function;

    public GridTreatmentMaterialsColumns = [];

    public treatmentMaterialFormViewModel: TreatmentMaterialFormViewModel = new TreatmentMaterialFormViewModel();

    private operationControlObjectSubscription: Subscription;
    private dailyInputModelSubscription: Subscription;

    public get _EpisodeAction(): EpisodeAction {
        return this._TTObject as EpisodeAction;
    }

    private TreatmentMaterialForm_DocumentUrl: string = '/api/TreatmentMaterialService/';
    public requestedProcedureBoolObjectObservable: boolean;
    public stateAction: Array<any> = new Array<any>();
    public actionMenuVisible: boolean = false;
    public searchText: string;
    public showMaterialSelectGrid: boolean = false;
    public selectedMaterials: any[] = [];
    public selectedItem: any = {};
    public search: boolean = false;
    @ViewChild('materialGrid') materialGrid: DxDataGridComponent;
    public materialGridColumns = [
        {
            'caption': "Barkod",
            dataField: 'Barcode',
            width: 100,
            allowSorting: true
        },
        {
            'caption': "Malzeme Adı",
            dataField: 'Stockcardname',
            width: 250,
            allowSorting: true
        },
        {
            'caption': "Barkod Adı",
            dataField: 'Name',
            width: 250,
            allowSorting: true
        },
        {
            'caption': "Mevcut",
            dataField: 'Inheld',
            width: 80,
            allowSorting: true
        },
        {
            'caption': "Dağıtım Şekli",
            dataField: 'Distributiontypename',
            width: 100,
            allowSorting: true
        }
    ];


    constructor(protected httpService: NeHttpService, protected messageService: MessageService, private detector: ApplicationRef,
        protected modalService: IModalService, private objectContextService: ObjectContextService, private procedureRequestSharedService: ProcedureRequestSharedService) {
        super('', 'TreatmentMaterialForm');
        this._DocumentServiceUrl = this.TreatmentMaterialForm_DocumentUrl;

        //EM Grid iken Kullanılıyordu
        // this.ComfirmRowDeletingFunc = this.comfirmRowDeleting.bind(this);

        this.initViewModel();
        this.initFormControls();
        this.stateAction = [
            {
                Caption: "Çoklu Malzeme Seçimi",
                ActionName: "materialSelect"
            },
            {
                Caption: "Şablon Olarak Kaydet",
                ActionName: "addTemplate"
            },
            {
                Caption: "Şablondan Getir",
                ActionName: "getTemplate"
            },
            {
                Caption: "İlaç/Sarf Bilgileri",
                ActionName: "EpisodeUsedDrugs"
            },
        ];

    }

    showActionMenu(): void {
        this.actionMenuVisible = true;
    }

    onActionMenuClick(e: any) {
        if (e.itemData.ActionName === "materialSelect") {
            this.materialSelect();
        }

        if (e.itemData.ActionName === "addTemplate") {
            this.addTemplate();
        }

        if (e.itemData.ActionName === "getTemplate") {
            this.getTemplate();
        }


        if (e.itemData.ActionName === "EpisodeUsedDrugs") {
            this.EpisodeUsedDrugs();
        }
    }

    async ngAfterViewInit() {
        this.loadViewModel(); // loadViewModel, "datagrid" repaint yapamadigi icin constructor'dan buraya tasindi.
        this.setIsSGK();
        this.ControlRequestedProcedures();
        this.httpService.requestedProcedureSharedService.sendTriggerValues(true);

    }

    public ShowNewMaterialList: boolean = false;
    async ngOnInit() {
        let listParameter: string = (await SystemParameterService.GetParameterValue('SHOWNEWMATERIALLIST', 'FALSE'));
        if (listParameter === "TRUE") {
            this.ShowNewMaterialList = true;
        }
    }

    ngOnDestroy() {
        if (this.operationControlObjectSubscription != null) {
            this.operationControlObjectSubscription.unsubscribe();
            this.operationControlObjectSubscription = null;
        }

        if (this.dailyInputModelSubscription != null) {
            this.dailyInputModelSubscription.unsubscribe();
            this.dailyInputModelSubscription = null;
        }

    }

    public ControlRequestedProcedures() {
        let that = this;
        this.operationControlObjectSubscription = this.httpService.requestedProcedureSharedService.operationControlBoolObjectObservable.subscribe(
            result => {
                that.requestedProcedureBoolObjectObservable = result;
            }
        );

        this.dailyInputModelSubscription = this.httpService.requestedProcedureSharedService.dailyProvisionInputModelObservable.subscribe(
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

    onRowPrepared(e: any) {
        //Farklı subepisodelarda bulunan hizmetler icin kabul numarası kolonunun renklendirilmesi.
        let data: BaseTreatmentMaterial = e.data as BaseTreatmentMaterial;
        let j = 0;
        let k = 0;

        for (j = 0; j < e.columns.length; j++) {
            if (e.columns[j].name == "SubEpisode") {
                break;
            }
        }

        if (e.rowElement.firstItem() !== undefined && e.rowType !== 'header' && e.rowType !== 'filter' && e.rowElement.firstItem() !== undefined && e.rowElement.firstItem().cells[j] !== undefined) {

            if (this.protocolNo != undefined && data != undefined
                && ((data.SubEpisode.ProtocolNo != this.protocolNo) || (data.SubEpisode.ProtocolNo == this.protocolNo && this.EpisodeAction.ActionType != data.EpisodeAction.ActionType))
                && !((this.EpisodeAction.ActionType == 54) && (data.EpisodeAction.ActionType == 56 || data.EpisodeAction.ActionType == 37 || data.EpisodeAction.ActionType == 54))) {
                e.rowElement.firstItem().cells[j].bgColor = '#ffa5a5';
            }

        }

        for (k = 0; k < e.columns.length; k++) {
            if (e.columns[k].name == "ActionType") {
                break;
            }
        }

        if (e.rowElement.firstItem() !== undefined && e.rowType !== 'header' && e.rowType !== 'filter' && e.rowElement.firstItem() !== undefined && e.rowElement.firstItem().cells[j] !== undefined) {

            if (this.EpisodeAction.ActionType != undefined && data != undefined
                && (data.EpisodeAction.ActionType != this.EpisodeAction.ActionType || (data.EpisodeAction.ActionType == this.EpisodeAction.ActionType && data.SubEpisode.ProtocolNo != this.protocolNo))
                && !((this.EpisodeAction.ActionType == 54) && (data.EpisodeAction.ActionType == 56 || data.EpisodeAction.ActionType == 37 || data.EpisodeAction.ActionType == 54))) {
                e.rowElement.firstItem().cells[k].bgColor = '#ffa5a5';
            }

        }


        ///TODO

    }

    public TreatmentMaterialListColumns = [];
    createMaterialListColumns() {
        this.TreatmentMaterialListColumns = [
            {
                caption: i18n("M27047", "Tarih/Saat"),
                name: "TreatmentMaterialActionDate",
                dataField: "ActionDate",
                alignment: "center",
                format: 'dd/MM/yyyy HH:mm',
                dataType: "datetime",
                width: '10%',
                visibleIndex: 1,
                sortOrder: "desc"
            },
            {
                caption: i18n("M11855", "Kabul Numarası"),
                name: "SubEpisode",
                dataField: "SubEpisode.ProtocolNo",
                width: '8%',
                visibleIndex: 2,
                visible: this.controlAction
            },
            {
                caption: i18n("M11855", "Eklendiği İşlem"),
                dataField: 'EpisodeAction',
                name: "ActionType",
                width: '10%',
                cellTemplate: "ActionTypeCellTemplate",
                visibleIndex: 3,
                visible: this.controlAction
            },
            /*
                        {
                    "caption": i18n("M15133", "Hasta Adı Soyadı"),
                    dataField: "PatientNameSurname",
                    dataType: 'string',
                    width: "auto",
                    cellTemplate: "PriorityCellTemplate",
                    fixed: true,
                    visible: false,
                    allowSorting: true,
                    cssClass: 'worklistGridCellFont',
                }, 
            */
            {
                caption: i18n("M12615", "Depo"),
                name: "Store",
                dataField: "Store.Name",
                width: '16%',
                visibleIndex: 4

            },
            {
                caption: i18n("M12615", "Sarf Malzeme"),
                name: "Material",
                dataField: "Material.Name",
                width: '20%',
                visibleIndex: 5

            },
            {
                caption: i18n("M19030", "Miktar"),
                name: "Amount",
                dataField: "CalculateAmount",
                cellTemplate: "AmountCellTemplate",
                alignment: "center",
                width: '4%',
                visibleIndex: 6
            },
            {
                caption: i18n("M19908", "Ölçü Birimi"),
                name: "DistributionType",
                alignment: "center",
                dataField: "CalculateDistributionType", //StockCard.DistributionType.DistributionType",
                width: '7%',
                visibleIndex: 7
            },
            {
                caption: i18n("M11855", "Birim Fiyat"),
                name: "CalculateUnitePrice",
                dataField: "CalculateUnitePrice",
                width: '6%',
                visibleIndex: 8
            },
            {
                caption: i18n("M23491", "Toplam Fiyat"),
                name: "TotalPrice",
                width: '8%',
                cellTemplate: "TotalPriceCellTemplate",
                visibleIndex: 9,
                alignment: "right"

            },
            {
                caption: i18n("M27355", "Barkodu"),
                name: "Barcode",
                alignment: "center",
                dataField: "Material.Barcode",
                width: '10%',
                visibleIndex: 10
            },

            {
                caption: i18n("M19485", "Notlar"),
                name: "Notes",
                dataField: "Note",
                width: '12%',
                visibleIndex: 11
            },
            {
                caption: "UTS Kullanım Bildirimi",
                name: "UTSUseNotification",
                dataField: "UTSUseNotification",
                alignment: "center",
                width: '10%',
                visibleIndex: 12
            },
            {
                caption: i18n("M27286", "Detay"),
                name: "RowDetail",
                alignment: "center",
                width: '3%',
                cellTemplate: "detailCellTemplate",
                visibleIndex: 13
            },
            {
                caption: 'UTS Bildirim İptal',
                name: "RowUTSDelete",
                alignment: "center",
                width: '9%',
                cellTemplate: "deleteUTSCellTemplate",
                visibleIndex: 14
            },
            {
                caption: i18n("M27286", "Sil"),
                name: "RowDelete",
                alignment: "center",
                width: '3%',
                cellTemplate: "deleteCellTemplate",
                visibleIndex: 15
            },
        ];

    }

    //SetUTSNotifStatus(row: BaseTreatmentMaterial): string {
    //    if (row.StockActionDetail.StockTransactions.find(x => x.InOut == 2).UTSNotificationDetails.length != row.StockActionDetail.Amount) {
    //        let a = 5;
    //        return "Bildirilmedi";
    //    }
    //    else
    //        return "Bildirildi";
    //}
    IsSGK: boolean;
    public stores: Array<Store> = new Array<Store>();
    public selectedStoreNew: Store;
    public selectStoreReadOnly: boolean = false;

    public dailyApplicationControl: boolean = false;
    public operationControl: boolean = false;
    public dailyControl: boolean = false;
    public summaryEpicrisis: string = "";
    public birim: any;
    public requestApp: any;
    public gunubirlikYatisKontrol: boolean = false;
    public yatisKontrol: boolean = false;
    public controlRequestedFormProperty: boolean = false;
    public protocolNo: string;


    async loadViewModel() {
        this.TreatmentMaterial.ListFilterExpression = '';
        this.createMaterialListColumns();
        //this.datagrid.instance.repaint();

        //let RecTime: Date;
        //(CommonService.RecTime()).then(response => {
        //    RecTime = response;
        //    this.ActionDate.Max = RecTime;
        //    this.treatmentMaterialFormViewModel.ActionDate = RecTime;
        //});

    }



    async onAmountChanged(data, row) {

        if (row.data.Material.DivideAmountToPatient == true) {
            if (data.value >= row.data.Material.DivideUnitAmount) {
                if (data.value % row.data.Material.DivideUnitAmount === 0) {
                    row.data.Amount = data.value / row.data.Material.DivideTotalAmount;
                    row.data.CalculateAmount = data.value;
                } else {
                    ServiceLocator.MessageService.showError("Birden fazla hastaya kullanılan malzemeler de Birim Doz katı miktar girmelisiniz. Birim Doz :" + row.data.Material.DivideUnitAmount);
                }

            } else {
                ServiceLocator.MessageService.showError("Birden fazla hastaya kullanılan malzemeler de Birim Doz dan az miktar giremezsiniz. Birim Doz :" + row.data.Material.DivideUnitAmount);
            }

        } else {
            row.data.Amount = data.value;
            row.data.CalculateAmount = data.value;
        }
        this.datagrid.instance.refresh();
    }

    onCalcTotalPrice(row: BaseTreatmentMaterial): number {
        return Math.Round((row.CalculateUnitePrice == null ? 0 : row.CalculateUnitePrice) * (row.Amount == null ? 0 : row.Amount), 2);
    }


    // ***** Method declarations start *****

    //@ViewChild('diagnosisQuickSelectionAccordion') diagnosisQuickSelectionAccordion: DxAccordionComponent;

    private _IgnoreSubEpisodeClosingDate: Boolean;
    @Input() set IgnoreSubEpisodeClosingDate(value: Boolean) {
        this._IgnoreSubEpisodeClosingDate = value;

    }
    get IgnoreSubEpisodeClosingDate(): Boolean {
        return this._IgnoreSubEpisodeClosingDate === true ? true : false;
    }

    private _UseSubEpisodeOpeningDateForMinDate: Boolean;
    @Input() set UseSubEpisodeOpeningDateForMinDate(value: Boolean) {
        this._UseSubEpisodeOpeningDateForMinDate = value;

    }
    get UseSubEpisodeOpeningDateForMinDate(): Boolean {
        return this._UseSubEpisodeOpeningDateForMinDate === true ? true : false;
    }

    private _isReadonly: Boolean;
    @Input() set IsReadOnly(value: Boolean) {
        this._isReadonly = value;

    }
    get IsReadOnly(): Boolean {
        return this._isReadonly === true ? true : false;
    }

    //private _treatmentMaterialTypeName: String;
    //@Input() set TreatmentMaterialTypeName(value: String) {
    //    this._treatmentMaterialTypeName = value;
    //}
    //get TreatmentMaterialTypeName(): String {
    //    return this._treatmentMaterialTypeName;
    //}
    @Input() TreatmentMaterialTypeName: String;

    private _selectStoreFromUserStore: Boolean;
    @Input() set SelectStoreFromUserStore(value: Boolean) {
        this._selectStoreFromUserStore = value;
        if (value == true) {
            this.SelectedStore.ReadOnly = false;
            this.selectStoreReadOnly = false;
            //    this.columns[1].visibleIndex = 4; // "Store" readonly değilse 2. son sutuna gitsin diye
            this.setSelectedStoreFilterExpression();
        }
    }

    get SelectStoreFromUserStore(): Boolean {
        return this._selectStoreFromUserStore == true ? true : false;
    }

    private _episodeAction: EpisodeAction;
    public controlAction: boolean;
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

            this.createMaterialListColumns();
            //   this.datagrid.instance.repaint();


            if (value && value.hasOwnProperty('ObjectID')) { // Form  ilk load olduğunda boş geliyor o zaman çalışmasın diye
                this.GetTreatmentMaterialStartUpViewModel();
            }
        }
    }

    get EpisodeAction(): EpisodeAction {
        return this._episodeAction;
    }

    private _storeResourceId: Guid;
    @Input() set StoreResourceId(value: Guid) {
        this._storeResourceId = value;
        let storeObjectID: Guid;
        let that = this;
        if (value != null) {
            this.SelectedStore.ReadOnly = true;
            this.selectStoreReadOnly = true;
            //     this.columns[1].visibleIndex = 14; //"Store" readonly olduğunda son sutuna gitsin diye
            this.getStoreByStoreResourceId().then((store: Store) => {
                that.selectedStoreNew = store;
                that.setTreatmentMaterialFilterExpression(store);
                that.getOrsetStoreObject(store);
                if (store != null)
                    storeObjectID = store.ObjectID;
            });

            let resuserUsableStore: string = "FALSE";
            let storeObjID: string = "";
            if (storeObjectID != null)
                storeObjID = storeObjectID.toString();

            SystemParameterService.GetParameterValue('RESUSERUSABLESTORE', 'FALSE').then(result => {
                resuserUsableStore = result;
                if (resuserUsableStore === "TRUE") {
                    let filterString: string = ' ';
                    UserHelper.UserUsableStores.then(resStore => {
                        filterString = ' OBJECTID IN (\'\'';
                        filterString += ',\'' + storeObjID + '\'';
                        for (let usableStore of resStore) {
                            filterString += ',\'' + usableStore.ObjectID.toString() + '\'';
                            this.stores.push(usableStore);
                        }
                        filterString += ')';
                        this.SelectedStore.ListFilterExpression = filterString;
                        this.SelectedStore.ReadOnly = false;
                        this.selectStoreReadOnly = false;
                    });
                }
            });
        }
    }
    get StoreResourceId(): Guid {
        return this._storeResourceId;
    }

    @Input() IncludeDrugDefinition: boolean = false;


    private _storeList: Array<Store>;
    get StoreList(): Array<Store> {
        if (this._storeList == null)
            this._storeList = new Array<Store>();
        return this._storeList;
    }

    public: Array<Store> = new Array<Store>();

    // Clienttdaki, StoreListe Object ekleme ya da çekmek için kullanılır
    public async getOrsetStoreObject(store: any): Promise<Store> {
        let storeObject: Store = null;
        if (store != null) {
            if (typeof store === 'string') {
                storeObject = this.StoreList.find(o => o.ObjectID.toString() === store.toString());
                if (storeObject == null) { // string geldi listede yoksa serverdan  get et
                    storeObject = await this.objectContextService.getObject<Store>(new Guid(store), Store.ObjectDefID);
                    if (storeObject)
                        this.StoreList.push(storeObject);
                }
            } else {
                storeObject = this.StoreList.find(o => o.ObjectID.toString() === store.ObjectID.toString());
                if (storeObject == null) {// obje geldiyse ve  listede yoksa listeye ekle
                    storeObject = store;
                    this.StoreList.push(store);
                }

            }

        }
        return storeObject;
    }

    private _subEpisode: SubEpisode;
    @Input() set SubEpisode(value: SubEpisode) {
        this._subEpisode = value;
        if (value && value.hasOwnProperty('ObjectID')) {
            this.GetTreatmentMaterialStartUpViewModel();
        }
    }

    get SubEpisode(): SubEpisode {
        return this._subEpisode;
    }

    public async getStoreByStoreResourceId(): Promise<Store> {
        if (this.treatmentMaterialFormViewModel._selectedStoreValue == null) {
            this.treatmentMaterialFormViewModel._selectedStoreValue = await ResourceService.GetStore(this.StoreResourceId.toString());
            if (this.treatmentMaterialFormViewModel._selectedStoreValue == null) {
                if (this.EpisodeAction.MasterResource.Name != null)
                    TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), this.EpisodeAction.MasterResource.Name.toString() + i18n("M12047", " bölümünün deposu bulunmadığı için malzeme sarf işlemi yapamazsınız."),
                        MessageIconEnum.ErrorMessage);
                else
                    TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M16418", "İlgili bölümünün deposu bulunmadığı için malzeme sarf işlemi yapamazsınız."), MessageIconEnum.ErrorMessage);
                return null;
            }
            this.stores.push(this.treatmentMaterialFormViewModel._selectedStoreValue);
        }
        return this.treatmentMaterialFormViewModel._selectedStoreValue;
    }


    private _treatmentMaterialGridList: Array<BaseTreatmentMaterial>;
    @Input() set TreatmentMaterialGridList(value: Array<BaseTreatmentMaterial>) {
        this._treatmentMaterialGridList = value;
        for (let i = 0; i < this._treatmentMaterialGridList.length; i++) {
            if (this._treatmentMaterialGridList[i].UTSUseNotification == "Bildirilmedi") {
                this.showUpdateUTSbutton = false;
                break;
            }
        }
        this.filltreatmentMaterialGridListStore();
    }

    get TreatmentMaterialGridList(): Array<BaseTreatmentMaterial> {
        return this._treatmentMaterialGridList;
    }

    async filltreatmentMaterialGridListStore() {
        for (let i = 0; i < this._treatmentMaterialGridList.length; i++) {
            this._treatmentMaterialGridList[i].Store = await this.getOrsetStoreObject(this._treatmentMaterialGridList[i].Store);
        }
    }



    //async fillTreatmentMaterialUTSUsageNotifStatus() {
    //    for (let i = 0; i < this._treatmentMaterialGridList.length; i++) {
    //        if (this._treatmentMaterialGridList[i].StockActionDetail.StockTransactions.find(x => x.InOut == 2).UTSNotificationDetails.length != this._treatmentMaterialGridList[i].StockActionDetail.Amount) {
    //            let a = 5;
    //        }
    //    }

    //}
    async setSelectedStoreFilterExpression() {
        if (this.SelectedStore.ListFilterExpression == null) {
            let selectableStores: Array<Store> = await UserHelper.UseUserResourcesStores;
            this.stores = selectableStores;
            let filterString: string = ' OBJECTID IN (\'\'';
            for (let store of selectableStores) {
                filterString += ',\'' + store.ObjectID.toString() + '\'';
            }

            let resuserUsableStore: string = await SystemParameterService.GetParameterValue('RESUSERUSABLESTORE', 'FALSE');
            if (resuserUsableStore === 'TRUE') {
                let usableStores: Array<Store> = await UserHelper.UserUsableStores;
                for (let usableStore of usableStores) {
                    filterString += ',\'' + usableStore.ObjectID.toString() + '\'';
                }
            }

            filterString += ')';
            this.SelectedStore.ListFilterExpression = filterString;
        }
    }

    async setTreatmentMaterialFilterExpression(store: Store) {
        let filterString: string = '""';
        if (store) {
            // set edilen depoya göre Malzeme listesinin filtrelenmesi
            filterString = ' THIS.OBJECTDEFNAME IN (\'CONSUMABLEMATERIALDEFINITION\') ';
            if (this.IncludeDrugDefinition == true) {
                filterString = 'THIS.OBJECTDEFNAME IN (\'CONSUMABLEMATERIALDEFINITION\',\'DRUGDEFINITION\') ';
            }
            //if (!((await SystemParameterService.GetParameterValue("WORKWITHOUTSTOCK", "FALSE")) === "TRUE")) {
            if (store.ObjectID == null) {
                filterString = filterString + ' AND STOCKS.INHELD>0 AND STOCKS.STORE = \'' + await store + '\'';
            } else {
                filterString = filterString + ' AND STOCKS.INHELD>0 AND STOCKS.STORE = \'' + await store.ObjectID.toString() + '\'';
            }
            //}
            this.TreatmentMaterial.ListFilterExpression = filterString;
        } else {
            filterString = '1=0';
            this.TreatmentMaterial.ListFilterExpression = filterString;
        }
    }

    public selectStoreNewChange() {
        this.treatmentMaterialFormViewModel._selectedStoreValue = this.selectedStoreNew;
        this.setTreatmentMaterialFilterExpression(this.selectedStoreNew);
    }


    //async initNewRowMaterial(data: any) {

    //    //newItem.Episode = this._PatientExamination.Episode;
    //    //newItem.Eligible = true;
    //    //newItem.ActionDate = await CommonService.RecTime();
    //    //newItem.Active = true;
    //    //Object.assign(data, newItem);
    //}

    // Em Gridiken Kulllanılıyordu
    //comfirmRowDeleting(data: any) {

    //    //if (data != null) {
    //    //    if (data.IsNew != true) {
    //    //        this.messageService.showError("Kaydedilmiş malzemeleri silemezsiniz.");
    //    //        return false;
    //    //    }
    //    //}
    //    return true;
    //}
    //rowRemoved(data: any) {
    //    //if (data != null) {
    //    //    if (data.IsNew != true) {
    //    //        let a = 1;
    //    //    }
    //    //}
    //}

    protected getSubEpisodeObjectID(): Guid {

        if (this.EpisodeAction != null) {
            if (typeof this.EpisodeAction === "string")
                return null;
            else if (this.EpisodeAction.SubEpisode != null) {
                if (typeof this.EpisodeAction.SubEpisode === "string")
                    return this.EpisodeAction.SubEpisode;
                else {
                    this.protocolNo = this.EpisodeAction.SubEpisode.ProtocolNo;
                    return this.EpisodeAction.SubEpisode.ObjectID;
                }
            }
        }
        return null;
    }

    loadingVisibleTreatmenDataGrid = false;
    public LoadPanelMessage: string = "Lütfen Bekleyiniz.";
    public messageDetail: string;
    gridTreatmentMaterialGrid_CellContentClicked(data: any) {
        this.loadingVisibleTreatmenDataGrid = true;
        if (data.column.name == "RowDelete") {
            if (data.row != null) {
                if (data.row.key != null) {
                    if (data.row.key.IsNew) {
                        this.datagrid.instance.deleteRow(data.rowIndex);

                    }
                    else {
                        data.key.EntityState = EntityStateEnum.Cancelled;
                        this.datagrid.instance.filter(['EntityState', '<>', 4]);
                        //this.datagrid.instance.filter(['EntityState', '<>', 1]);
                        this.datagrid.instance.refresh();
                    }
                    if (data.data.Material.DailyStay === true) {
                        this.treatmentMaterialFormViewModel.countForDailyOperations -= 1;
                        if (this.treatmentMaterialFormViewModel.countForDailyOperations == 0)
                            //     this.operationControl = false;
                            this.ControlDailyOperation(false);
                    }
                }
            }
            this.loadingVisibleTreatmenDataGrid = false;
        }
        if (data.column.name == "RowDetail") {
            if (data.row.key != null) {
                try {
                    let that = this;
                    let input = new GetTreatmentMaterialDetail_Input();
                    input.Material = data.data;
                    let fullApiUrl: string = 'api/TreatmentMaterialService/GetTreatmentMaterialDetail';
                    this.httpService.post(fullApiUrl, input)
                        .then((res) => {
                            TTVisual.InfoBox.Alert(res.toString());
                        })
                        .catch(error => {
                            this.loadingVisibleTreatmenDataGrid = false;
                            TTVisual.InfoBox.Alert(error);
                        });
                    this.loadingVisibleTreatmenDataGrid = false;
                }
                catch (ex) {
                    this.loadingVisibleTreatmenDataGrid = false;
                    TTVisual.InfoBox.Alert(ex);
                }
            }
        }
        if (data.column.name == "RowUTSDelete") {
            if (data.row.key != null) {
                try {
                    let that = this;
                    let input = new GetTreatmentMaterialDetail_Input();
                    input.Material = data.data;
                    let fullApiUrl: string = 'api/TreatmentMaterialService/DeleteUTSRowTreatmentMaterialDetail';
                    this.httpService.post(fullApiUrl, input)
                        .then((res) => {
                            if (res) {
                                //data.row.data.UTSUseNotification = "Bildirilmedi";
                                this.showUpdateUTSbutton = false;
                                //this.datagrid.instance.refresh();
                                this.loadingVisibleTreatmenDataGrid = false;
                                // TTVisual.InfoBox.Alert(res.toString());
                                this.utsMessage = res.toString();
                                this.popupUTSVisible = true;
                            }
                        })
                        .catch(error => {
                            this.loadingVisibleTreatmenDataGrid = false;
                            //TTVisual.InfoBox.Alert(error);
                            this.utsMessage = error;
                            this.popupUTSVisible = true;

                        });
                }
                catch (ex) {
                    this.loadingVisibleTreatmenDataGrid = false;
                    //TTVisual.InfoBox.Alert(ex);
                    this.utsMessage = ex;
                    this.popupUTSVisible = true;
                }
            }
        }
        //this.loadingVisibleTreatmenDataGrid = false;
    }

    selectedStoreSelected(data: any) {
        this.treatmentMaterialFormViewModel._selectedStoreValue = data;
        if (data != null)
            this.setTreatmentMaterialFilterExpression(data);
        else
            this.TreatmentMaterial.ListFilterExpression = '';
    }

    GetEpisodeActionMasterResource(): Guid {
        if (this.EpisodeAction != null) {
            if (typeof this.EpisodeAction.MasterResource === "string") {

                return this.EpisodeAction.MasterResource;
            }
            else {
                return this.EpisodeAction.MasterResource.ObjectID;
            }
        }
        return null;
    }

    drugReportNo: string;
    public firstAdded: BaseTreatmentMaterial;
    public async treatmentMaterialSelected(data: any) {

        if (data != null) {
            if (String.isNullOrEmpty(data.Description) === false) {
                if (data.MaterialDescriptionShowType != null) {
                    if (data.MaterialDescriptionShowType === MaterialDescriptionShowTypeEnum.TraetmentMaterial ||
                        data.MaterialDescriptionShowType === MaterialDescriptionShowTypeEnum.All) {
                        TTVisual.InfoBox.Alert('Açıklama', data.Description, MessageIconEnum.InformationMessage);
                    }
                } else {
                    TTVisual.InfoBox.Alert('Açıklama', data.Description, MessageIconEnum.InformationMessage);
                }
            }

            let noerror = true;
            if (this.treatmentMaterialFormViewModel._selectedStoreValue == null) {
                TTVisual.InfoBox.Alert(i18n("M12637", "Depo Seçimi yapmadan işleme devam edmezsiniz"), MessageIconEnum.ErrorMessage);
                noerror = false;

            }
            if (this.treatmentMaterialFormViewModel.ActionDate == null || (this.ActionDate.Max != null && this.treatmentMaterialFormViewModel.ActionDate > this.ActionDate.Max)) {
                TTVisual.InfoBox.Alert(i18n("M30107", "Lütfen Geçerli Bir İstem Tarihi seçiniz."), MessageIconEnum.ErrorMessage);
                noerror = false;
            }

            if (data.MaterialPatientType != null) {
                if (data.MaterialPatientType === MaterialPatientTypeEnum.Inpatient) {
                    if (this.EpisodeAction.SubEpisode.PatientStatus === SubEpisodeStatusEnum.Outpatient || this.EpisodeAction.SubEpisode.PatientStatus === SubEpisodeStatusEnum.Daily) {
                        let inpatientQuestion = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), 'Yatan Hasta',
                            'Bu malzeme sadece yatan hastalara verilebilir olarak tanımlanmış. Yinede vermek istiyor musunuz ?');
                        if (inpatientQuestion === 'H') {
                            noerror = false;
                        }
                        //TTVisual.InfoBox.Alert("Bu malzeme sadece yatan hastalara verilebilir.", MessageIconEnum.ErrorMessage);
                    }
                }

                if (data.MaterialPatientType === MaterialPatientTypeEnum.Outpatient && this.EpisodeAction.SubEpisode.PatientStatus === SubEpisodeStatusEnum.Inpatient) {
                    let outpatientQuestion = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), 'Ayaktan Hasta',
                        'Bu malzeme sadece ayaktan hastalara verilebilir olarak tanımlanmış. Yinede vermek istiyor musunuz ?');
                    if (outpatientQuestion === 'H') {
                        noerror = false;
                    }
                    //TTVisual.InfoBox.Alert("Bu malzeme sadece ayaktan hastalara ", MessageIconEnum.ErrorMessage);
                }
            }

            if (!noerror) {
                window.setTimeout(t => {
                    if (this.treatmentMaterialFormViewModel._selectedMaterialValue === null)
                        this.treatmentMaterialFormViewModel._selectedMaterialValue = undefined;
                    else
                        this.treatmentMaterialFormViewModel._selectedMaterialValue = null;
                    this.detector.tick();
                }, 0);
            }
            else {
                let that = this;
                let materialObjectIds: Array<any> = new Array<any>();
                materialObjectIds.push(data.ObjectID);

                let inputDVO = new AddedTreatmentMaterialInputDVO();
                inputDVO.AddedTreatmentMaterials = new Array<TreatmentMaterialInputDVODetail>();

                let matDetailDVO: TreatmentMaterialInputDVODetail = new TreatmentMaterialInputDVODetail();
                matDetailDVO.MaterialObjectID = data.ObjectID;
                if (data.DivideAmountToPatient == true) {
                    let divideCount: number = data.DivideUnitAmount / data.DivideTotalAmount;
                    matDetailDVO.Amount = divideCount;
                } else {
                    matDetailDVO.Amount = 1;
                }

                inputDVO.AddedTreatmentMaterials.push(matDetailDVO);
                inputDVO.EpisodeActionMasterResourceId = this.GetEpisodeActionMasterResource();
                inputDVO.EpisodeActionObjectDefID = this.EpisodeAction.ObjectDefID.toString();
                inputDVO.ActionDate = this.treatmentMaterialFormViewModel.ActionDate;
                inputDVO.SubEpisodeGuid = this.getSubEpisodeObjectID();

                if (this.TreatmentMaterialTypeName != null) {
                    inputDVO.TreatmentMaterialTypeName = this.TreatmentMaterialTypeName.toString();
                }


                //let apiUrlForAddTreatmentMaterial: string = 'api/TreatmentMaterialService/GetAddedTreatmentMaterials?materialObjectIds=' + materialObjectIds + '&EpisodeActionObjectDefID=' + this.EpisodeAction.ObjectDefID.toString() + '';
                let apiUrlForAddTreatmentMaterial: string = 'api/TreatmentMaterialService/GetAddedTreatmentMaterials';

                await this.httpService.post<TreatmentMaterialFormViewModel>(apiUrlForAddTreatmentMaterial, inputDVO, TreatmentMaterialFormViewModel)
                    .then(async result => {

                        let _viewModel: TreatmentMaterialFormViewModel = result;
                        let that = this;
                        for (let addedViewModel of _viewModel.AddedTreatmentMaterials) {
                            if (addedViewModel) {
                                if (addedViewModel.material instanceof Material && addedViewModel.DrugReportType === DrugReportType.RaporlaOdenir && that.IsSGK) {
                                    let input: GetDrugReportNo_Input = new GetDrugReportNo_Input();
                                    input.DrugID = addedViewModel.material.ObjectID;
                                    input.EpisodeID = this.EpisodeAction.Episode.ObjectID;
                                    this.httpService.post<string>('api/DrugOrderIntroductionService/GetDrugReportNo', input).then(result => {
                                        this.drugReportNo = result;
                                    }).catch(err => {
                                        TTVisual.InfoBox.Alert(err);
                                        return;
                                    });
                                }
                                let ShowBoxresult: string;
                                let addedTreatmentMaterial: BaseTreatmentMaterial = addedViewModel.AddedTreatmentMaterial;

                                if (addedViewModel.drugSpecification != null && !String.isNullOrEmpty(addedViewModel.drugSpecification)) {

                                    ShowBoxresult = await ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), '', 'İlaç ' + addedViewModel.drugSpecification.Value + '  ' + ' Özelliktedir.Eklemek İstiyor musunuz?');
                                    if (ShowBoxresult === "OK") {
                                        addedTreatmentMaterial.ActionDate = addedViewModel.AddedTreatmentMaterial.ActionDate;
                                        addedTreatmentMaterial.Material = addedViewModel.material;
                                        addedTreatmentMaterial.Store = this.treatmentMaterialFormViewModel._selectedStoreValue;
                                        addedTreatmentMaterial.Episode = this.EpisodeAction.Episode;
                                        addedTreatmentMaterial.Material.Barcode = addedViewModel.Barcode;
                                        addedTreatmentMaterial.Material.StockCard = addedViewModel.StockCard;
                                        addedTreatmentMaterial.Material.StockCard.DistributionType = addedViewModel.DistributionTypeDef;
                                        addedTreatmentMaterial.Material.StockCard.DistributionType.DistributionType = addedViewModel.DistributionType;
                                        addedTreatmentMaterial.MedulaReportNo = this.drugReportNo;
                                        addedTreatmentMaterial.SubEpisode = addedViewModel.subEpisode;
                                        addedTreatmentMaterial.EpisodeAction = this.EpisodeAction;
                                        that.TreatmentMaterialGridList.unshift(addedTreatmentMaterial);
                                        //         that.checkAndSetMaterialProceduresOfSelectedMaterial(addedViewModel.MaterialProcedureViewModelList);
                                    }
                                }
                                else {
                                    addedTreatmentMaterial.ActionDate = addedViewModel.AddedTreatmentMaterial.ActionDate;
                                    addedTreatmentMaterial.Material = addedViewModel.material;
                                    addedTreatmentMaterial.Store = this.treatmentMaterialFormViewModel._selectedStoreValue;
                                    addedTreatmentMaterial.Episode = this.EpisodeAction.Episode;
                                    addedTreatmentMaterial.Material.Barcode = addedViewModel.Barcode;
                                    addedTreatmentMaterial.Material.StockCard = addedViewModel.StockCard;
                                    addedTreatmentMaterial.Material.StockCard.DistributionType = addedViewModel.DistributionTypeDef;
                                    addedTreatmentMaterial.Material.StockCard.DistributionType.DistributionType = addedViewModel.DistributionType;
                                    addedTreatmentMaterial.MedulaReportNo = this.drugReportNo;
                                    addedTreatmentMaterial.SubEpisode = addedViewModel.subEpisode;
                                    addedTreatmentMaterial.EpisodeAction = this.EpisodeAction;
                                    that.TreatmentMaterialGridList.unshift(addedTreatmentMaterial);
                                    //        that.checkAndSetMaterialProceduresOfSelectedMaterial(addedViewModel.MaterialProcedureViewModelList);
                                }

                                let inPatientPhyApp: InPatientPhysicianApplication = this.EpisodeAction as InPatientPhysicianApplication;
                                if (addedTreatmentMaterial.Material.DailyStay === true) {
                                    that.treatmentMaterialFormViewModel.countForDailyOperations += 1;
                                    if (that.treatmentMaterialFormViewModel.countForDailyOperations == 1
                                        && (!(this.EpisodeAction.ObjectDefID.toString().Equals(InPatientPhysicianApplication.ObjectDefID.id)) || ((this.EpisodeAction.ObjectDefID.toString().Equals(InPatientPhysicianApplication.ObjectDefID.id)) && inPatientPhyApp.InPatientTreatmentClinicApp == null && inPatientPhyApp.EmergencyIntervention != null))
                                        && !(this.EpisodeAction.ObjectDefID.toString().Equals(NursingApplication.ObjectDefID.id))
                                        && this.gunubirlikYatisKontrol == false
                                        && this.yatisKontrol == false) {
                                        // this.operationControl = true;
                                        this.ControlDailyOperation(true);
                                        if (this.requestedProcedureBoolObjectObservable != true)
                                            this.FillDataSource();
                                    }
                                }
                                if (addedTreatmentMaterial.Material.DailyStay === true && that.treatmentMaterialFormViewModel.countForDailyOperations == 1) {
                                    this.firstAdded = addedTreatmentMaterial;
                                }
                            }
                        }
                        window.setTimeout(t => {
                            if (that.treatmentMaterialFormViewModel._selectedMaterialValue === null)
                                that.treatmentMaterialFormViewModel._selectedMaterialValue = undefined;
                            else
                                that.treatmentMaterialFormViewModel._selectedMaterialValue = null;
                            that.detector.tick();
                        }, 0);
                    })
                    .catch(error => {
                        console.log(error);
                    });
            }
        }
    }


    result: string;
    async materialSelect() {

        if (this.treatmentMaterialFormViewModel._selectedStoreValue == null) {
            TTVisual.InfoBox.Alert(i18n("M12637", "Depo Seçimi yapmadan işleme devam edmezsiniz"), MessageIconEnum.ErrorMessage);
        } else {
            this.showMaterialSelect(this.treatmentMaterialFormViewModel._selectedStoreValue).then(async result => {
                let modalActionResult = result as ModalActionResult;
                let materialObjectIds: Array<any> = new Array<any>();
                let that = this;
                if (modalActionResult.Result == DialogResult.OK) {
                    let obj = result.Param as Array<MaterialItem>;
                    let inputDVO: AddedTreatmentMaterialInputDVO = new AddedTreatmentMaterialInputDVO();
                    inputDVO.AddedTreatmentMaterials = new Array<TreatmentMaterialInputDVODetail>();
                    let ShowBoxresult: string;
                    for (let item of obj) {
                        if (item != null) {
                            let matDetailDVO: TreatmentMaterialInputDVODetail = new TreatmentMaterialInputDVODetail();
                            matDetailDVO.MaterialObjectID = item.ObjectID;
                            matDetailDVO.Amount = item.Amount;
                            matDetailDVO.TransactionDate = item.TransactionDate;
                            if (item.drugSpecification != null && !String.isNullOrEmpty(item.drugSpecification)) {
                                ShowBoxresult = await ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), '', 'İlaç ' + item.drugSpecification.Value + '  ' + ' Özelliktedir.Eklemek İstiyor musunuz?');
                                if (ShowBoxresult === "OK") {
                                    inputDVO.AddedTreatmentMaterials.push(matDetailDVO);
                                }
                            }
                            else
                                inputDVO.AddedTreatmentMaterials.push(matDetailDVO);
                        }
                    }


                    inputDVO.EpisodeActionMasterResourceId = this.GetEpisodeActionMasterResource()
                    inputDVO.EpisodeActionObjectDefID = this.EpisodeAction.ObjectDefID.toString();
                    inputDVO.ActionDate = this.treatmentMaterialFormViewModel.ActionDate;
                    inputDVO.SubEpisodeGuid = this.getSubEpisodeObjectID();

                    //let apiUrlForAddTreatmentMaterial: string = 'api/TreatmentMaterialService/GetAddedTreatmentMaterials?materialObjectIds=' + materialObjectIds + '&EpisodeActionObjectDefID=' + this.EpisodeAction.ObjectDefID.toString() + '';
                    let apiUrlForAddTreatmentMaterial: string = 'api/TreatmentMaterialService/GetAddedTreatmentMaterials';

                    this.httpService.post<TreatmentMaterialFormViewModel>(apiUrlForAddTreatmentMaterial, inputDVO, TreatmentMaterialFormViewModel)
                        .then(_viewModel => {

                            for (let addedViewModel of _viewModel.AddedTreatmentMaterials) {
                                if (addedViewModel) {
                                    if (addedViewModel.material instanceof Material && addedViewModel.DrugReportType === DrugReportType.RaporlaOdenir && that.IsSGK) {
                                        let input: GetDrugReportNo_Input = new GetDrugReportNo_Input();
                                        input.DrugID = addedViewModel.material.ObjectID;
                                        input.EpisodeID = this.EpisodeAction.Episode.ObjectID;
                                        this.httpService.post<string>('api/DrugOrderIntroductionService/GetDrugReportNo', input).then(result => {
                                            this.drugReportNo = result;
                                        }).catch(err => {
                                            TTVisual.InfoBox.Alert(err);
                                            return;
                                        });
                                    }
                                    let addedTreatmentMaterial: BaseTreatmentMaterial = addedViewModel.AddedTreatmentMaterial;
                                    addedTreatmentMaterial.Material = addedViewModel.material;
                                    addedTreatmentMaterial.ActionDate = addedViewModel.AddedTreatmentMaterial.ActionDate;
                                    addedTreatmentMaterial.Store = this.treatmentMaterialFormViewModel._selectedStoreValue;
                                    addedTreatmentMaterial.Episode = this.EpisodeAction.Episode;
                                    addedTreatmentMaterial.Material.Barcode = addedViewModel.Barcode;
                                    addedTreatmentMaterial.Material.StockCard = addedViewModel.StockCard;
                                    addedTreatmentMaterial.Material.StockCard.DistributionType = addedViewModel.DistributionTypeDef;
                                    addedTreatmentMaterial.Material.StockCard.DistributionType.DistributionType = addedViewModel.DistributionType;
                                    addedTreatmentMaterial.MedulaReportNo = this.drugReportNo;
                                    addedTreatmentMaterial.SubEpisode = addedViewModel.subEpisode;
                                    addedTreatmentMaterial.EpisodeAction = this.EpisodeAction;

                                    that.TreatmentMaterialGridList.unshift(addedTreatmentMaterial);
                                    //        that.checkAndSetMaterialProceduresOfSelectedMaterial(addedViewModel.MaterialProcedureViewModelList);
                                }
                            }
                            window.setTimeout(t => {
                                if (that.treatmentMaterialFormViewModel._selectedMaterialValue === null)
                                    that.treatmentMaterialFormViewModel._selectedMaterialValue = undefined;
                                else
                                    that.treatmentMaterialFormViewModel._selectedMaterialValue = null;
                                that.detector.tick();
                            }, 0);
                        })
                        .catch(error => {
                            console.log(error);
                        });
                }
            });
        }
    }

    async setIsSGK() {
        let that = this;
        let subEpisodeObjectId = this.getSubEpisodeObjectID();
        if (subEpisodeObjectId !== null)
            that.IsSGK = await DrugOrderIntroductionService.IsSGK(subEpisodeObjectId);
    }

    EpisodeUsedDrugs() {
        setTimeout(() => {
            this.showEpisodeUsedDrugs();
        }, 1000);
    }

    private showEpisodeUsedDrugs(): Promise<ModalActionResult> {
        let that = this;

        let patientInfo: PatientInputDTO = new PatientInputDTO();
        patientInfo.EpisodeObjectID = this.EpisodeAction.Episode.ObjectID.toString();;
        patientInfo.SubepisodeObjectId = this.getSubEpisodeObjectID().toString();

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'PatientUsedMaterialComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = patientInfo;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Hasta Kullanılan İlaç/Malzeme Bilgileri';
            modalInfo.Width = 1200;
            modalInfo.Height = 800;


            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }


    //private checkAndSetMaterialProceduresOfSelectedMaterial(materialProcedureViewModelList: Array<MaterialProcedureViewModel>) {

    //    let procedureFormDetailList: Array<Guid> = new Array<Guid>();
    //    let procedureList: Array<Guid> = new Array<Guid>();
    //    let ignoredProcedureNameList: Array<string> = new Array<string>();

    //    let openIstemBeklemeSuresi: number = 0;
    //    materialProcedureViewModelList.forEach(dr => {
    //        if (dr.ProcedureRequestFormDetailObjectId != null && dr.ProcedureRequestFormDetailObjectId != new Guid("00000000-0000-0000-0000-000000000000")) {
    //            openIstemBeklemeSuresi = 500;
    //            this.openIstem.emit();// tetkik istem panelinden istenecek bir data varsa tetkik isem tabı dolmuş olmalı
    //            procedureFormDetailList.push(dr.ProcedureRequestFormDetailObjectId);
    //        }
    //        else if (dr.IsAdditionalApplication)
    //            procedureList.push(dr.ProcedureObjectId);
    //        else
    //            ignoredProcedureNameList.push(dr.ProcedureName);

    //    });

    //    window.setTimeout(t => {
    //        this.procedureRequestSharedService.onpackageSelected(procedureFormDetailList); // Tetkik istemden panelinden Checklemek için
    //    }, openIstemBeklemeSuresi);

    //    for (let procedureObjectId of procedureList) {
    //        this.procedureRequestSharedService.addProcedureToRequestedProcedureGrid(procedureObjectId, this.EpisodeAction.ObjectID); // Hizmet Tetkik istek Gridine atmak için
    //    }
    //    if (ignoredProcedureNameList.length > 0) {
    //        let msg = i18n("M11192", "Aşağıdaki Hizmetler İstem kataloğunda yer almadığı için istem yapılamadı");
    //        for (let procedureName of ignoredProcedureNameList) {
    //            msg = msg + "<br/>" + procedureName;
    //        }
    //        TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), msg, MessageIconEnum.WarningMessage, 400);
    //    }

    //}

    private showMaterialSelect(data: Store): Promise<ModalActionResult> {

        let that = this;
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'MaterialSelectComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            let dvo: MaterialSelectInputDVO = new MaterialSelectInputDVO();
            dvo.store = data;
            dvo.includeDrugDefinition = that.IncludeDrugDefinition;
            dvo.TransactionDateMax = that.ActionDate.Max;
            dvo.TransactionDateMin = that.ActionDate.Min;
            componentInfo.InputParam = new DynamicComponentInputParam(dvo, new ActiveIDsModel(that.EpisodeAction.ObjectID, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M12417", "Çoklu Malzeme Seçimi");
            modalInfo.Width = 1200;
            modalInfo.Height = 800;

            let result = that.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }


    //UTS için eklendi

    async patientBasedMaterialSelect() {

        if (this.treatmentMaterialFormViewModel._selectedStoreValue == null) {
            TTVisual.InfoBox.Alert(i18n("M12637", "Depo Seçimi yapmadan işleme devam edmezsiniz"), MessageIconEnum.ErrorMessage);
        } else {
            this.showMaterialSelect(this.treatmentMaterialFormViewModel._selectedStoreValue).then(result => {
                let modalActionResult = result as ModalActionResult;
                let materialObjectIds: Array<any> = new Array<any>();
                let that = this;
                if (modalActionResult.Result == DialogResult.OK) {
                    let obj = result.Param as Array<MaterialItem>;
                    let inputDVO: AddedTreatmentMaterialInputDVO = new AddedTreatmentMaterialInputDVO();
                    inputDVO.AddedTreatmentMaterials = new Array<TreatmentMaterialInputDVODetail>();
                    for (let item of obj) {
                        if (item != null) {
                            let matDetailDVO: TreatmentMaterialInputDVODetail = new TreatmentMaterialInputDVODetail();
                            matDetailDVO.MaterialObjectID = item.ObjectID;
                            matDetailDVO.Amount = item.Amount;
                            matDetailDVO.TransactionDate = item.TransactionDate;
                            inputDVO.AddedTreatmentMaterials.push(matDetailDVO);

                        }
                    }
                    inputDVO.EpisodeActionMasterResourceId = this.GetEpisodeActionMasterResource()
                    inputDVO.EpisodeActionObjectDefID = this.EpisodeAction.ObjectDefID.toString();
                    inputDVO.ActionDate = this.treatmentMaterialFormViewModel.ActionDate;
                    inputDVO.SubEpisodeGuid = this.getSubEpisodeObjectID();

                    //let apiUrlForAddTreatmentMaterial: string = 'api/TreatmentMaterialService/GetAddedTreatmentMaterials?materialObjectIds=' + materialObjectIds + '&EpisodeActionObjectDefID=' + this.EpisodeAction.ObjectDefID.toString() + '';
                    let apiUrlForAddTreatmentMaterial: string = 'api/TreatmentMaterialService/GetAddedTreatmentMaterials';

                    this.httpService.post<TreatmentMaterialFormViewModel>(apiUrlForAddTreatmentMaterial, inputDVO, TreatmentMaterialFormViewModel)
                        .then(_viewModel => {

                            for (let addedViewModel of _viewModel.AddedTreatmentMaterials) {
                                if (addedViewModel) {
                                    let addedTreatmentMaterial: BaseTreatmentMaterial = addedViewModel.AddedTreatmentMaterial;
                                    addedTreatmentMaterial.Material = addedViewModel.material;
                                    addedTreatmentMaterial.ActionDate = addedViewModel.AddedTreatmentMaterial.ActionDate;
                                    addedTreatmentMaterial.Store = this.treatmentMaterialFormViewModel._selectedStoreValue;
                                    addedTreatmentMaterial.Episode = this.EpisodeAction.Episode;
                                    addedTreatmentMaterial.Material.Barcode = addedViewModel.Barcode;
                                    addedTreatmentMaterial.Material.StockCard = addedViewModel.StockCard;
                                    addedTreatmentMaterial.Material.StockCard.DistributionType = addedViewModel.DistributionTypeDef;
                                    addedTreatmentMaterial.Material.StockCard.DistributionType.DistributionType = addedViewModel.DistributionType;
                                    addedTreatmentMaterial.SubEpisode = addedViewModel.subEpisode;
                                    addedTreatmentMaterial.EpisodeAction = this.EpisodeAction;

                                    that.TreatmentMaterialGridList.unshift(addedTreatmentMaterial);

                                    //                                    that.checkAndSetMaterialProceduresOfSelectedMaterial(addedViewModel.MaterialProcedureViewModelList);
                                }
                            }
                            window.setTimeout(t => {
                                if (that.treatmentMaterialFormViewModel._selectedMaterialValue === null)
                                    that.treatmentMaterialFormViewModel._selectedMaterialValue = undefined;
                                else
                                    that.treatmentMaterialFormViewModel._selectedMaterialValue = null;
                                that.detector.tick();
                            }, 0);
                        })
                        .catch(error => {
                            console.log(error);
                        });
                }
            });
        }
    }

    public popupUTSVisible: boolean = false;
    public utsMessage: string;
    public loadingVisible: boolean = false;
    public async MakeUsageNotificationAll(): Promise<void> {

        this.loadingVisible = true;

        var updateList: Array<Guid> = new Array<Guid>();

        for (let i = 0; i < this._treatmentMaterialGridList.length; i++) {
            if (this._treatmentMaterialGridList[i].UTSUseNotification == "Bildirilmedi") {
                this.showUpdateUTSbutton = false;
                updateList.push(this._treatmentMaterialGridList[i].ObjectID);
            }
        }

        try {
            let apiUrl = '/api/UTSIslemleriService/MakeUTSUsageNotificationAll';

            await this.httpService.post<any>(apiUrl, updateList).then(response => {
                let result: Array<BaseTreatmentMaterialUTSUsageNotificationResultViewModel> = response;
                if (result != null) {
                    for (var item of result) {
                        if (item.Message == "Succeed") {
                            this._treatmentMaterialGridList.find(x => x.ObjectID == item.ObjectId).UTSUseNotification = item.UTSUseNotificationState;
                        }
                        else {
                            this.utsMessage = "Hata : " + item.Message;
                            ServiceLocator.MessageService.showError("Hata : " + item.Message);
                        }
                    }

                    this.showUpdateUTSbutton = true;
                    for (let i = 0; i < this._treatmentMaterialGridList.length; i++) {
                        if (this._treatmentMaterialGridList[i].UTSUseNotification == "Bildirilmedi") {
                            this.showUpdateUTSbutton = false;
                            break;
                        }
                    }

                    /* if (this.showUpdateUTSbutton == false) {
                         ServiceLocator.MessageService.showSuccess("İşlem Gerçekleştirildi.");
                         //this.utsMessage = "İşlem Gerçekleştirildi.";
                     }*/
                    this.popupUTSVisible = true;
                    this.loadingVisible = false;
                }
            }).catch(error => {
                this.utsMessage = "Hata : " + error;
                ServiceLocator.MessageService.showError("Hata : " + error);
                this.loadingVisible = false;
                this.popupUTSVisible = true;
            });
        }
        catch (ex) {
            this.utsMessage = "Hata : " + ex;
            ServiceLocator.MessageService.showError(ex);
            this.loadingVisible = false;
            this.popupUTSVisible = true;
        }
    }

    private showPatientBasedMaterialSelect(data: Store): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'MaterialSelectComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            let dvo: MaterialSelectInputDVO = new MaterialSelectInputDVO();
            dvo.store = data;
            dvo.includeDrugDefinition = this.IncludeDrugDefinition;
            dvo.TransactionDateMax = this.ActionDate.Max;
            dvo.TransactionDateMin = this.ActionDate.Min;
            componentInfo.InputParam = new DynamicComponentInputParam(dvo, new ActiveIDsModel(this._EpisodeAction.ObjectID, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Hasta Bazlı Malzeme Seçimi";
            modalInfo.Width = 1200;
            modalInfo.Height = 800;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    async onActionDateChanged(event) {
        if (event != null) {
            if (this.treatmentMaterialFormViewModel != null &&
                this.treatmentMaterialFormViewModel.ActionDate != event) {
                this.treatmentMaterialFormViewModel.ActionDate = event;
            }
        }
    }

    public GetTreatmentMaterialStartUpViewModel() {

        // Sarf Tarihi için Max Min dete getirmece
        let episodeActionObjectId: string = "";
        let subEpisodeObjectId: string = "";
        let getRectimeForMaxDate: Boolean = false;
        let getSubEpisodeClosingDateForMaxDate: Boolean = false;
        let getSubEpisodeOpeningDateForMinDate: Boolean = false;
        let getEpisodeActionRequestDateForMinDate: Boolean = false;

        if (this.UseSubEpisodeOpeningDateForMinDate)
            getSubEpisodeOpeningDateForMinDate = true;
        else
            getEpisodeActionRequestDateForMinDate = true;
        if (this.IgnoreSubEpisodeClosingDate)
            getRectimeForMaxDate = true;
        else
            getSubEpisodeClosingDateForMaxDate = true;

        if (this._episodeAction != null) {
            if (typeof this._episodeAction === "string") {
                if (getEpisodeActionRequestDateForMinDate || getSubEpisodeClosingDateForMaxDate || getSubEpisodeOpeningDateForMinDate) { // elimizde subepisode da Episodeaction da yaok serverdan istiyecez
                    episodeActionObjectId = this._episodeAction;
                }
            }
            else {
                if (getEpisodeActionRequestDateForMinDate) {
                    if (this._episodeAction.RequestDate != null)
                        this.ActionDate.Min = this._episodeAction.RequestDate;
                    getEpisodeActionRequestDateForMinDate = false; // clientda bulduk serverdan çekmeye gerek yok
                }

                if (this._episodeAction.SubEpisode != null) {
                    if (typeof this._episodeAction.SubEpisode === "string") {
                        if (getSubEpisodeClosingDateForMaxDate || getSubEpisodeOpeningDateForMinDate)
                            subEpisodeObjectId = this._episodeAction.SubEpisode;
                    }
                    else {
                        if (getSubEpisodeClosingDateForMaxDate) {
                            getSubEpisodeClosingDateForMaxDate = false; // clinetda  bulduk tekrar get etmeye gerek yok
                            if (this._episodeAction.SubEpisode.ClosingDate != null)
                                this.ActionDate.Max = this._episodeAction.SubEpisode.ClosingDate;
                            else
                                getRectimeForMaxDate = true; // Subepisode hala açık Rectime'ı istiyorum

                        }
                        if (getSubEpisodeOpeningDateForMinDate) {
                            this.ActionDate.Min = this._episodeAction.SubEpisode.OpeningDate;
                            getSubEpisodeOpeningDateForMinDate = false;
                        }
                    }
                }

            }
            let that = this;

            this.httpService.get<TreatmentMaterialStartUpViewModel>(this._DocumentServiceUrl + "GetTreatmentMaterialStartUpViewModel?GetRectimeForMaxDate=" + getRectimeForMaxDate
                + "&GetSubEpisodeClosingDateForMaxDate=" + getSubEpisodeClosingDateForMaxDate
                + "&GetSubEpisodeOpeningDateForMinDate=" + getSubEpisodeOpeningDateForMinDate
                + "&GetEpisodeActionRequestDateForMinDate=" + getEpisodeActionRequestDateForMinDate
                + "&SubEpisodeObjectID=" + subEpisodeObjectId
                + "&EpisodeActionObjectID=" + episodeActionObjectId, TreatmentMaterialStartUpViewModel)
                .then(result => {
                    if (result.MinDate != null && that.ActionDate.Min == null) {
                        that.ActionDate.Min = result.MinDate;
                    }
                    if (result.MaxDate != null && that.ActionDate.Max == null) {
                        that.ActionDate.Max = result.MaxDate;
                    }
                    if (result.ProtocolNo != null && that.protocolNo == null) {
                        that.protocolNo = result.ProtocolNo;
                    }
                    if (that.ActionDate == null) {
                        that.treatmentMaterialFormViewModel.ActionDate = result.DefaultDate;
                    } else {
                        if (result.DefaultDate <= that.ActionDate.Max) {
                            that.treatmentMaterialFormViewModel.ActionDate = result.DefaultDate;
                        } else {
                            that.treatmentMaterialFormViewModel.ActionDate = that.ActionDate.Max;
                            //that.ActionDate.Min = that.treatmentMaterialFormViewModel.ActionDate;
                        }
                    }

                })
                .catch(error => {
                    console.log(error);
                });

        }
    }

    public CalculateTotalPrice(options) {
        if (options.name === "TotalPrice") {
            if (options.summaryProcess === "start") {
                options.totalValue = 0;
            } else if (options.summaryProcess === "calculate") {
                options.totalValue = Math.Round(Math.Round(options.totalValue, 2) + (Math.Round((options.value.CalculateUnitePrice == null ? 0 : options.value.CalculateUnitePrice) * (options.value.Amount == null ? 0 : options.value.Amount), 2)), 2);
            }
        }
    }

    selectedMaterialItem: any = {};
    public onClearMaterial(event: any) {
        if (event != null && event.value != null) {

        }
        else {
            this.selectedMaterialItem = {};
        }
    }

    openMaterialDropDown(e: any) {
        this.getMaterialDataSource();
    }

    materialDataSource: DataSource;
    getMaterialDataSource() {
        this.materialDataSource = new DataSource({
            store: new CustomStore({
                key: "ObjectID",
                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'AllowedConsumableMaterialAndDrugList'
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    return this.httpService.post<any>('/api/TreatmentMaterialService/GetMaterialList?storeID=' + this.TreatmentMaterial.ListFilterExpression, loadOptions);
                },
            }),
            paginate: true,
            pageSize: 10
        });
    }

    onEnterKey(e) {
        this.search = true;
        this.searchText = this.searchText.toUpperCase();
        this.materialGrid.searchPanel = { text: this.searchText };
        this.getNewMaterialDataSource();
    }

    getNewMaterialDataSource() {
        this.materialDataSource = new DataSource({
            store: new CustomStore({
                key: "ObjectID",
                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: this.searchText,
                        definitionName: 'AllowedConsumableMaterialAndDrugList'
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    return this.httpService.post<any>('/api/NewMaterialSelectComponent/GetTreatmentMaterialList?filterExpretion=' + this.TreatmentMaterial.ListFilterExpression, loadOptions);
                },
            }),
            paginate: true,
            pageSize: 10
        });
    }

    selectNewListMaterial(e) {
        var component = e.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        this.selectedItem = e.data;
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code  
            this.treatmentMaterialSelected(e.data);
            this.search = false;
        }
    }

    @ViewChild('materialDrop') materialDrop: DxDropDownBoxComponent;
    selectMaterial(e) {
        var component = e.component;
        component.lastClickTime = new Date();
        this.selectedMaterialItem = e.data;
        this.treatmentMaterialSelected(e.data);
        this.materialDrop.instance.close();
    }


    // *****Method declarations end *****

    public initViewModel(): void {
        this.treatmentMaterialFormViewModel = new TreatmentMaterialFormViewModel();
        this.treatmentMaterialFormViewModel.AddedTreatmentMaterials = new Array<AddedTreatmentMaterialsViewModel>();
        this._ViewModel = this.treatmentMaterialFormViewModel;

    }

    public initFormControls(): void {

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = '#F0F0F0';
        this.ActionDate.CustomFormat = '';
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Enabled = true;
        this.ActionDate.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ActionDate.Name = 'ActionDate';
        this.ActionDate.TabIndex = 1;

        this.GridTreatmentMaterials = new TTVisual.TTGrid();
        this.GridTreatmentMaterials.Name = 'GridTreatmentMaterials';
        this.GridTreatmentMaterials.TabIndex = 0;
        this.GridTreatmentMaterials.AllowUserToAddRows = false;

        this.TreatmentMaterial = new TTVisual.TTObjectListBox();
        this.TreatmentMaterial.ListDefName = 'AllowedConsumableMaterialAndDrugList';
        this.TreatmentMaterial.Name = 'TreatmentMaterial';
        this.TreatmentMaterial.AutoCompleteDialogHeight = '150';
        this.TreatmentMaterial.AutoCompleteDialogWidth = '50%';

        this.SelectedStore = new TTVisual.TTObjectListBox();
        this.SelectedStore.ListDefName = 'StoreListDefinition';
        this.SelectedStore.Name = 'SelectedStore';
        this.SelectedStore.AutoCompleteDialogHeight = '400px';


    }

    public ClinicList = new List<ResClinic>();
    async FillDataSource() {

        let result: DailyInpatientInfoModel = new DailyInpatientInfoModel();
        let apiUrl: string = 'api/EpisodeActionService/ControlDailyInpatient?episodeActionID=' + this.EpisodeAction.ObjectID;
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

                let input: EpisodeAction = this._episodeAction;

                await this.httpService.post<any>(apiUrlForPASearchUrl, input).then(response => {
                    let result = response as ClinicResultModel;
                    if (result) {
                        that.ClinicList = result.ClinicList;
                        if (result.DefaultClinic != null)
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
        // this.operationControl = true;
        this.ControlDailyOperation(true);

        let subscribeModel: DailyProvisionSubscribeModel = new DailyProvisionSubscribeModel();

        subscribeModel.DailyInpatientControl = this.gunubirlikYatisKontrol;
        subscribeModel.Epicrisis = this.summaryEpicrisis;
        subscribeModel.TreatmentClinic = this.birim;
        subscribeModel.NormalInpatientControl = this.yatisKontrol;

        this.httpService.requestedProcedureSharedService.sendDailyOperationInputModelForProcedures(subscribeModel);

    }

    async DailyOperationsSave(episodeAction: EpisodeAction) {
        try {

            let that = this;
            let apiUrlForPASearchUrl: string = '/api/EpisodeActionService/DailyInpatientOperations';
            let input: DailyProvisionInputModel = new DailyProvisionInputModel();
            input.EpisodeAction = episodeAction;
            input.Epicrisis = this.summaryEpicrisis;
            input.InpatientDate = this.treatmentMaterialFormViewModel.ActionDate;
            if (this.birim != undefined)
                input.TreatmentClinic = new Guid(this.birim.toString());
            input.DailyInpatientControl = this.gunubirlikYatisKontrol;
            input.NormalInpatientControl = this.yatisKontrol;
            if (typeof episodeAction.ProcedureDoctor === "string")
                input.ProcedureDoctorID = new Guid(episodeAction.ProcedureDoctor);
            else
                input.ProcedureDoctorID = episodeAction.ProcedureDoctor.ObjectID;
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });

            await this.httpService.post<any>(apiUrlForPASearchUrl, input).then(response => {
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    async onTreatmentMaterialCancel() {

        this.dailyApplicationControl = false;
        this.dailyControl = false;

        let index = this.TreatmentMaterialGridList.findIndex(element => element == this.firstAdded); //ilk elemanın indeks nosunu döndürür
        this.TreatmentMaterialGridList.splice(index, 1);
        this.treatmentMaterialFormViewModel.countForDailyOperations = 0;
        this.summaryEpicrisis = "";
        this.birim = null;
        //this.operationControl = false;
        this.ControlDailyOperation(false);

    }

    ControlDailyOperation(control: boolean): void {
        this.operationControl = control;
        this.httpService.requestedProcedureSharedService.sendDailyOperationControlForProcedures(control);
    }

    public onTreatmentMaterialGridUpdating(event: any) {
        console.log(event);
        //event.cancel = false;
    }

    public addTemplate() {
        let newAddedMaterials: Array<BaseTreatmentMaterial> = this.TreatmentMaterialGridList.filter(x => x.IsNew === true);
        if (newAddedMaterials != null)
            this.addTemplateShow(newAddedMaterials);
        else
            ServiceLocator.MessageService.showError("Hiç yeni malzeme eklemediniz.")
    }

    private addTemplateShow(newAddedMaterials: Array<BaseTreatmentMaterial>): Promise<ModalActionResult> {
        let that = this;
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'TreatmentMaterialTemplateAddNewComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = newAddedMaterials;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M12417", "Şablon Olarak Kaydet");
            modalInfo.Width = 1200;
            modalInfo.Height = 800;

            let result = that.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public async getTemplate() {
        if (this.treatmentMaterialFormViewModel._selectedStoreValue == null) {
            ServiceLocator.MessageService.showError("Depo Seçimi yapmadan işleme devam edmezsiniz");
        } else {
            this.getTemplateShow(this.treatmentMaterialFormViewModel._selectedStoreValue).then(async result => {
                let modalActionResult = result as ModalActionResult;
                let that = this;
                if (modalActionResult.Result == DialogResult.OK) {
                    let obj = result.Param as Array<TreatmentMaterialTemplateDetailItem>;
                    let inputDVO: AddedTreatmentMaterialInputDVO = new AddedTreatmentMaterialInputDVO();
                    inputDVO.AddedTreatmentMaterials = new Array<TreatmentMaterialInputDVODetail>();
                    for (let item of obj) {
                        if (item != null) {
                            let matDetailDVO: TreatmentMaterialInputDVODetail = new TreatmentMaterialInputDVODetail();
                            matDetailDVO.MaterialObjectID = item.MaterialObjectID.toString();
                            matDetailDVO.Amount = item.Amount;
                            matDetailDVO.TransactionDate = new Date(Date.now());
                            inputDVO.AddedTreatmentMaterials.push(matDetailDVO);
                        }
                    }
                    inputDVO.EpisodeActionMasterResourceId = this.GetEpisodeActionMasterResource()
                    inputDVO.EpisodeActionObjectDefID = this.EpisodeAction.ObjectDefID.toString();
                    inputDVO.ActionDate = this.treatmentMaterialFormViewModel.ActionDate;
                    inputDVO.SubEpisodeGuid = this.getSubEpisodeObjectID();

                    //let apiUrlForAddTreatmentMaterial: string = 'api/TreatmentMaterialService/GetAddedTreatmentMaterials?materialObjectIds=' + materialObjectIds + '&EpisodeActionObjectDefID=' + this.EpisodeAction.ObjectDefID.toString() + '';
                    let apiUrlForAddTreatmentMaterial: string = 'api/TreatmentMaterialService/GetAddedTreatmentMaterials';

                    this.httpService.post<TreatmentMaterialFormViewModel>(apiUrlForAddTreatmentMaterial, inputDVO, TreatmentMaterialFormViewModel)
                        .then(_viewModel => {

                            for (let addedViewModel of _viewModel.AddedTreatmentMaterials) {
                                if (addedViewModel) {
                                    if (addedViewModel.material instanceof Material && addedViewModel.DrugReportType === DrugReportType.RaporlaOdenir && that.IsSGK) {
                                        let input: GetDrugReportNo_Input = new GetDrugReportNo_Input();
                                        input.DrugID = addedViewModel.material.ObjectID;
                                        input.EpisodeID = this.EpisodeAction.Episode.ObjectID;
                                        this.httpService.post<string>('api/DrugOrderIntroductionService/GetDrugReportNo', input).then(result => {
                                            this.drugReportNo = result;
                                        }).catch(err => {
                                            TTVisual.InfoBox.Alert(err);
                                            return;
                                        });
                                    }
                                    let addedTreatmentMaterial: BaseTreatmentMaterial = addedViewModel.AddedTreatmentMaterial;
                                    addedTreatmentMaterial.Material = addedViewModel.material;
                                    addedTreatmentMaterial.ActionDate = addedViewModel.AddedTreatmentMaterial.ActionDate;
                                    addedTreatmentMaterial.Store = this.treatmentMaterialFormViewModel._selectedStoreValue;
                                    addedTreatmentMaterial.Episode = this.EpisodeAction.Episode;
                                    addedTreatmentMaterial.Material.Barcode = addedViewModel.Barcode;
                                    addedTreatmentMaterial.Material.StockCard = addedViewModel.StockCard;
                                    addedTreatmentMaterial.Material.StockCard.DistributionType = addedViewModel.DistributionTypeDef;
                                    addedTreatmentMaterial.Material.StockCard.DistributionType.DistributionType = addedViewModel.DistributionType;
                                    addedTreatmentMaterial.MedulaReportNo = this.drugReportNo;
                                    addedTreatmentMaterial.SubEpisode = addedViewModel.subEpisode;
                                    addedTreatmentMaterial.EpisodeAction = this.EpisodeAction;

                                    that.TreatmentMaterialGridList.unshift(addedTreatmentMaterial);
                                }
                            }
                            window.setTimeout(t => {
                                if (that.treatmentMaterialFormViewModel._selectedMaterialValue === null)
                                    that.treatmentMaterialFormViewModel._selectedMaterialValue = undefined;
                                else
                                    that.treatmentMaterialFormViewModel._selectedMaterialValue = null;
                                that.detector.tick();
                            }, 0);
                        })
                        .catch(error => {
                            console.log(error);
                        });
                }
            });
        }
    }

    private getTemplateShow(store: Store): Promise<ModalActionResult> {
        let that = this;
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'TreatmentMaterialTemplateComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = store.ObjectID;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M12417", "Şablondan Getir");
            modalInfo.Width = 1200;
            modalInfo.Height = 800;

            let result = that.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

}

