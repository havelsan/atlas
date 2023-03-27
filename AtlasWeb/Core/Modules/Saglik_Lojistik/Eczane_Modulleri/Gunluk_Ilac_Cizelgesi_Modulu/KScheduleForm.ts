//$E61EB506
import { Component, ViewChild, OnInit, NgZone } from '@angular/core';
import { KScheduleFormViewModel } from './KScheduleFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { KSchedule } from 'NebulaClient/Model/AtlasClientModel';
import { KScheduleMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { KScheduleUnListMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionBaseForm } from "Modules/Saglik_Lojistik/Stok_Evrensel_Modulu/StockActionBaseForm";
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionService, InPatientPhysicianApplication_Output } from 'Fw/Services/StockActionService';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DrugOrderIntroductionService, TempDrugOrder, OldDrugOrderIntroductionDet } from 'ObjectClassService/DrugOrderIntroductionService';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import query from 'devextreme/data/query';
import { DxDataGridComponent } from 'devextreme-angular';


@Component({
    selector: 'KScheduleForm',
    templateUrl: './KScheduleForm.html',
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
    providers: [MessageService]
})
export class KScheduleForm extends StockActionBaseForm implements OnInit {
    Amount: TTVisual.ITTTextBoxColumn;
    MKYS_TeslimAlan: TTVisual.ITTTextBoxColumn;
    DemandAmount: TTVisual.ITTTextBoxColumn;
    DemandDescription: TTVisual.ITTTextBoxColumn;
    Description: TTVisual.ITTTextBox;
    DestinationStore: TTVisual.ITTObjectListBox;
    Dose: TTVisual.ITTTextBoxColumn;
    EndDate: TTVisual.ITTDateTimePicker;
    FullNamePatient: TTVisual.ITTTextBox;
    IDPatient: TTVisual.ITTTextBox;
    labelDescription: TTVisual.ITTLabel;
    labelDestinationStore: TTVisual.ITTLabel;
    labelFullNamePatient: TTVisual.ITTLabel;
    labelIDPatient: TTVisual.ITTLabel;
    labelStockActionID: TTVisual.ITTLabel;
    labelStore: TTVisual.ITTLabel;
    labelTransactionDate: TTVisual.ITTLabel;
    Material: TTVisual.ITTListBoxColumn;
    Reason: TTVisual.ITTTextBoxColumn;
    ReceivedAmount: TTVisual.ITTTextBoxColumn;
    RequestAmount: TTVisual.ITTTextBoxColumn;
    StartDate: TTVisual.ITTDateTimePicker;
    StockActionID: TTVisual.ITTTextBox;
    StockActionOutDetails: TTVisual.ITTGrid;
    StockLevelType: TTVisual.ITTListDefComboBoxColumn;
    Store: TTVisual.ITTObjectListBox;
    TransactionDate: TTVisual.ITTDateTimePicker;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage2: TTVisual.ITTTabPage;
    UnListDrug: TTVisual.ITTTextBoxColumn;
    UnSupplyGrid: TTVisual.ITTGrid;

    public clinicName: string;
    public clinicRoom: string;
    public clinicBed: string;
    public clinicProtocolNo: string;
    public clinicDischargeDate: Date;
    public hasPhysicianApplication: boolean = true;

    tempDrugOrders: Array<TempDrugOrder>;
    expanded = true;
    totalCount: number;
    @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent;
    public StockActionOutDetailsColumns = [];
    public UnSupplyGridColumns = [];
    public kScheduleFormViewModel: KScheduleFormViewModel = new KScheduleFormViewModel();
    public get _KSchedule(): KSchedule {
        return this._TTObject as KSchedule;
    }
    private KScheduleForm_DocumentUrl: string = '/api/KScheduleService/KScheduleForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                private objectContextService: ObjectContextService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.KScheduleForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    /*protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);
        if (transDef !== null) {
            if (transDef.ToStateDefID === KSchedule.KScheduleStates.RequestPreparation || transDef.ToStateDefID === KSchedule.KScheduleStates.Approval) {
                let parameter: Dictionary<string, TTReportTool.PropertyCache<Object>> = new Dictionary<string, TTReportTool.PropertyCache<Object>>();
                let objectID: TTReportTool.PropertyCache<Object> = new TTReportTool.PropertyCache<Object>();
                objectID.push("VALUE", this._KSchedule.ObjectID.toString());
                parameter.push("TTOBJECTID", objectID);
                let reportType: Type = typeof TTReportClasses.I_KScheduleReport;
                if (this._KSchedule instanceof KScheduleDaily) {
                    reportType = typeof TTReportClasses.I_KScheduleDailyReport;
                }
                TTReportTool.TTReport.PrintReport(reportType, true, 1, parameter);
            }
        }
    }*/
    protected async ClientSidePreScript(): Promise<void> {

        let dateTime: Date = null;
        let oldOrders: OldDrugOrderIntroductionDet = await DrugOrderIntroductionService.GetOldDrugOrderIntroductionDetsWithDate(this._KSchedule.Episode, dateTime);
        this.tempDrugOrders = oldOrders.TempDrugOrders;
        this.totalCount = this.getGroupCount('OrderType');

        if (this._KSchedule.InPatientPhysicianApplication != undefined) {

            this.hasPhysicianApplication = true;

            let output: InPatientPhysicianApplication_Output = await StockActionService.GetInPatientPhysicianApplication_Info(this._KSchedule.InPatientPhysicianApplication.toString());

            if (output != null) {
                this.clinicProtocolNo = output.clinicProtocolNo;
                this.clinicBed = output.clinicBed;
                this.clinicRoom = output.clinicRoom;
                this.clinicName = output.clinicName;
                this.clinicDischargeDate = output.clinicDischargeDate;
            }

        }
        else {
            this.hasPhysicianApplication = false;
        }
    }

    getGroupCount(groupField) {
        return query(this.tempDrugOrders)
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
                    value: 'OrderType',
                    onValueChanged: this.groupChanged.bind(this)
                }
            }, {
                location: 'before',
                widget: 'dxButton',
                options: {
                    hint: i18n("M15727", "Hepsini Kapat"),
                    icon: 'chevrondown',
                    onClick: this.collapseAllClick.bind(this)
                }
            }, {
                location: 'after',
                widget: 'dxButton',
                options: {
                    icon: 'refresh',
                    onClick: this.refreshDataGrid.bind(this)
                }
            });
    }

    groupChanged(e) {
        this.dataGrid.instance.clearGrouping();
        this.dataGrid.instance.columnOption(e.value, 'groupIndex', 0);
        this.totalCount = this.getGroupCount(e.value);
    }

    collapseAllClick(e) {
        this.expanded = !this.expanded;
        e.component.option({
            icon: this.expanded ? 'chevrondown' : 'chevronnext',
            hint: this.expanded ? 'Collapse All' : 'Expand All'
        });
    }

    refreshDataGrid() {
        this.dataGrid.instance.refresh();
    }
    /*
    protected async PreScript() {
        if (this._KSchedule instanceof KScheduleDaily) {
            this.DropStateButton(KSchedule.KScheduleStates.Approval);
        }
        else {
            this.DropStateButton(KSchedule.KScheduleStates.RequestPreparation);
        }
        let kSchedule: KSchedule = this._KSchedule;
        let ttObject: ITTObject = <ITTObject>kSchedule;
        let readOnlyContext: TTObjectContext = new TTObjectContext(true);
        if (ttObject.IsNew) {
            this.StartDate.Enabled = false;
            this.EndDate.Enabled = false;
            let store: Store;
            /*if ((await SystemParameterService.GetParameterValue("MKYS_INTEGRATED", "FALSE")) === "FALSE") {
                let pharmacyStore: Array<PharmacyStoreDefinition> = (await PharmacyStoreDefinitionService.GetInpatientPharmacyStore(readOnlyContext));
                store = pharmacyStore[0];
            }
            else {
                let storeId: string = (await SystemParameterService.GetParameterValue("PHARMACYSTOREOBJECTID", ""));
                if (storeId === "") {
                    throw new TTException(" Eczahane Depo Parametresini Tanımlayın! ");
                }
                store = <Store>this._KSchedule.ObjectContext.GetObject(Guid.Parse(storeId), typeof Store);
            }
            this._KSchedule.Store = store;
            let myDrugOrderDetails: Array<DrugOrderDetail> = null;
            if (this._KSchedule instanceof KScheduleDaily) {
                myDrugOrderDetails = (await DrugOrderDetailService.GetDrugOrderDetailsForDaily(this._KSchedule.ObjectContext, <Date>kSchedule.StartDate, <Date>kSchedule.EndDate, this._KSchedule.DestinationStore.ObjectID));
            }
            else {
                myDrugOrderDetails = (await DrugOrderDetailService.GetDrugOrderDetails(this._KSchedule.ObjectContext, <Date>kSchedule.StartDate, <Date>kSchedule.EndDate, this._KSchedule.DestinationStore.ObjectID));
            }
            let detailsHashtable: Dictionary<Guid, number> = new Dictionary<Guid, number>();
            let totalAmount: number = 0;
            for (let drugOrderDetail of myDrugOrderDetails) {
                if (drugOrderDetail.DrugOrder !== null && drugOrderDetail.Amount > 0) {
                    if (detailsHashtable.containsKey(drugOrderDetail.DrugOrder.ObjectID)) {
                        totalAmount = 0;
                        totalAmount = detailsHashtable[drugOrderDetail.DrugOrder.ObjectID];
                        totalAmount += <number>drugOrderDetail.Amount;
                        detailsHashtable[drugOrderDetail.DrugOrder.ObjectID] = totalAmount;
                    }
                    else {
                        detailsHashtable.push(drugOrderDetail.DrugOrder.ObjectID, <number>drugOrderDetail.Amount);
                    }
                }
            }
            for (let de of detailsHashtable) {
                let restDose: number = 0;
                let unListDetails: Dictionary<Guid, DrugOrderDetail> = new Dictionary<Guid, DrugOrderDetail>();
                let drugOrder: DrugOrder = <DrugOrder>kSchedule.ObjectContext.GetObject(new Guid(de.Key.toString()), "DRUGORDER");
                let rests: Dictionary<Object, number> = (await DrugOrderTransactionService.GetPatientRestDose(drugOrder.Material, drugOrder.Episode));
                for (let rest of rests) {
                    restDose = restDose + rest.Value;
                }
                if (restDose === 0) {
                    let rAmount: number = de.Value;
                    let kScheduleMaterial: KScheduleMaterial = KSchedule.CreateKScheduleMaterial(kSchedule.ObjectContext, drugOrder, de.Value);
                    kSchedule.StockActionOutDetails.push(kScheduleMaterial);
                    let drugOrderDetails: Array<any> = (await DrugOrderDetailService.GetDrugOrderDetailsByDrugOrder(drugOrder.ObjectID, <Date>kSchedule.StartDate, <Date>kSchedule.EndDate));
                    let kScheduleCollectedOrder: KScheduleCollectedOrder = new KScheduleCollectedOrder(this._KSchedule.ObjectContext);
                    for (let detail of drugOrderDetails) {
                        let drugOrderDetail: DrugOrderDetail = <DrugOrderDetail>kSchedule.ObjectContext.GetObject(<Guid>detail.ObjectID, "DRUGORDERDETAIL");
                        kScheduleCollectedOrder.DrugOrderDetails.push(drugOrderDetail);
                    }
                    kScheduleMaterial.KScheduleCollectedOrder = kScheduleCollectedOrder;
                }
                if (restDose > 0 && restDose << number > de.Value) {
                    let rAmount: number = <number>de.Value - restDose;
                    let kScheduleMaterial: KScheduleMaterial = (await KScheduleService.CreateKScheduleMaterial(kSchedule.ObjectContext, drugOrder, rAmount));
                    kSchedule.StockActionOutDetails.push(kScheduleMaterial);
                    let drugOrderDetails: Array<any> = (await DrugOrderDetailService.GetDrugOrderDetailsByDrugOrder(drugOrder.ObjectID, <Date>kSchedule.StartDate, <Date>kSchedule.EndDate));
                    let kScheduleCollectedOrder: KScheduleCollectedOrder = new KScheduleCollectedOrder(this._KSchedule.ObjectContext);
                    let drugType: boolean = (await DrugOrderService.GetDrugUsedType((<DrugDefinition>drugOrder.Material)));
                    for (let detail of drugOrderDetails) {
                        let drugOrderDetail: DrugOrderDetail = <DrugOrderDetail>kSchedule.ObjectContext.GetObject(<Guid>detail.ObjectID, "DRUGORDERDETAIL");
                        if (rAmount >= detail.Amount) {
                            rAmount -= <number>detail.Amount;
                            kScheduleCollectedOrder.DrugOrderDetails.push(drugOrderDetail);
                        }
                        else {
                            unListDetails.push(drugOrderDetail.ObjectID, drugOrderDetail);
                        }
                    }
                    kScheduleMaterial.KScheduleCollectedOrder = kScheduleCollectedOrder;
                }
                if (restDose > 0 && restDose >= <number>de.Value) {
                    let drugOrderDetails: Array<any> = (await DrugOrderDetailService.GetDrugOrderDetailsByDrugOrder(drugOrder.ObjectID, <Date>kSchedule.StartDate, <Date>kSchedule.EndDate));
                    let drugType: boolean = (await DrugOrderService.GetDrugUsedType((<DrugDefinition>drugOrder.Material)));
                    for (let detail of drugOrderDetails) {
                        let drugOrderDetail: DrugOrderDetail = <DrugOrderDetail>kSchedule.ObjectContext.GetObject(<Guid>detail.ObjectID, "DRUGORDERDETAIL");
                        unListDetails.push(drugOrderDetail.ObjectID, drugOrderDetail);
                    }
                }
                if (unListDetails.length > 0) {
                    let readonlyContext: TTObjectContext = new TTObjectContext(true);
                    let unlistPatient: Patient = <Patient>readonlyContext.GetObject(new Guid(drugOrder.Episode.Patient.ObjectID.toString()), "PATIENT");
                    let unlistDrug: DrugDefinition = <DrugDefinition>readonlyContext.GetObject(new Guid(drugOrder.Material.ObjectID.toString()), "DRUGDEFINITION");
                    let kScheduleUnListMaterial: KScheduleUnListMaterial = new KScheduleUnListMaterial(this._KSchedule.ObjectContext);
                    kScheduleUnListMaterial.UnlistDrug = unlistDrug.Name;
                    kScheduleUnListMaterial.UnlistPatient = unlistPatient.FullName;
                    let drugType: boolean = (await DrugOrderService.GetDrugUsedType(unlistDrug));
                    if (drugType) {
                        kScheduleUnListMaterial.UnlistAmount = restDose;
                        kScheduleUnListMaterial.UnlistVolume = restDose * unlistDrug.Volume;
                    }
                    else {
                        kScheduleUnListMaterial.UnlistAmount = restDose / unlistDrug.Volume;
                        kScheduleUnListMaterial.UnlistVolume = restDose;
                    }
                    kScheduleUnListMaterial.UnlistReason = "Hasta üzerinde bu ilaç bulunmaktadır.";
                    this._KSchedule.KScheduleUnListMaterials.push(kScheduleUnListMaterial);
                    for (let unListDetail of unListDetails) {
                        unListDetail.Value.KScheduleUnListMaterial = kScheduleUnListMaterial;
                    }
                }
            }
        }
    }*/

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new KSchedule();
        this.kScheduleFormViewModel = new KScheduleFormViewModel();
        this._ViewModel = this.kScheduleFormViewModel;
        this.kScheduleFormViewModel._KSchedule = this._TTObject as KSchedule;
        this.kScheduleFormViewModel._KSchedule.Episode = new Episode();
        this.kScheduleFormViewModel._KSchedule.Episode.Patient = new Patient();
        this.kScheduleFormViewModel._KSchedule.DestinationStore = new Store();
        this.kScheduleFormViewModel._KSchedule.KScheduleMaterials = new Array<KScheduleMaterial>();
        this.kScheduleFormViewModel._KSchedule.KScheduleUnListMaterials = new Array<KScheduleUnListMaterial>();
        this.kScheduleFormViewModel._KSchedule.Store = new Store();
    }

    protected loadViewModel() {
        let that = this;

        that.kScheduleFormViewModel = this._ViewModel as KScheduleFormViewModel;
        that._TTObject = this.kScheduleFormViewModel._KSchedule;
        if (this.kScheduleFormViewModel == null)
            this.kScheduleFormViewModel = new KScheduleFormViewModel();
        if (this.kScheduleFormViewModel._KSchedule == null)
            this.kScheduleFormViewModel._KSchedule = new KSchedule();
        let episodeObjectID = that.kScheduleFormViewModel._KSchedule["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.kScheduleFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.kScheduleFormViewModel._KSchedule.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.kScheduleFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                     if (patient) {
                        episode.Patient = patient;
                    }
                }
            }
        }
        let destinationStoreObjectID = that.kScheduleFormViewModel._KSchedule["DestinationStore"];
        if (destinationStoreObjectID != null && (typeof destinationStoreObjectID === 'string')) {
            let destinationStore = that.kScheduleFormViewModel.Stores.find(o => o.ObjectID.toString() === destinationStoreObjectID.toString());
             if (destinationStore) {
                that.kScheduleFormViewModel._KSchedule.DestinationStore = destinationStore;
            }
        }
        that.kScheduleFormViewModel._KSchedule.KScheduleMaterials = that.kScheduleFormViewModel.StockActionOutDetailsGridList;
        for (let detailItem of that.kScheduleFormViewModel.StockActionOutDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.kScheduleFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
            }
            let stockLevelTypeObjectID = detailItem["StockLevelType"];
            if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === 'string')) {
                let stockLevelType = that.kScheduleFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                 if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        that.kScheduleFormViewModel._KSchedule.KScheduleUnListMaterials = that.kScheduleFormViewModel.UnSupplyGridGridList;
        for (let detailItem of that.kScheduleFormViewModel.UnSupplyGridGridList) {
        }
        let storeObjectID = that.kScheduleFormViewModel._KSchedule["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.kScheduleFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
             if (store) {
                that.kScheduleFormViewModel._KSchedule.Store = store;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(KScheduleFormViewModel);
        this.FormCaption = i18n("M15032", "Günlük İlaç Çizelgesi ( Yeni )");
  
    }


    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._KSchedule != null && this._KSchedule.Description != event) {
                this._KSchedule.Description = event;
            }
        }
    }

    public onDestinationStoreChanged(event): void {
        if (event != null) {
            if (this._KSchedule != null && this._KSchedule.DestinationStore != event) {
                this._KSchedule.DestinationStore = event;
            }
        }
    }

    public onEndDateChanged(event): void {
        if (event != null) {
            if (this._KSchedule != null && this._KSchedule.EndDate != event) {
                this._KSchedule.EndDate = event;
            }
        }
    }

    public onFullNamePatientChanged(event): void {
        if (event != null) {
            if (this._KSchedule != null &&
                this._KSchedule.Episode != null &&
                this._KSchedule.Episode.Patient != null && this._KSchedule.Episode.Patient.FullName != event) {
                this._KSchedule.Episode.Patient.FullName = event;
            }
        }
    }

    public onIDPatientChanged(event): void {
        if (event != null) {
            if (this._KSchedule != null &&
                this._KSchedule.Episode != null &&
                this._KSchedule.Episode.Patient != null && this._KSchedule.Episode.Patient.ID != event) {
                this._KSchedule.Episode.Patient.ID = event;
            }
        }
    }

    public onStartDateChanged(event): void {
        if (event != null) {
            if (this._KSchedule != null && this._KSchedule.StartDate != event) {
                this._KSchedule.StartDate = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._KSchedule != null && this._KSchedule.StockActionID != event) {
                this._KSchedule.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._KSchedule != null && this._KSchedule.Store != event) {
                this._KSchedule.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._KSchedule != null && this._KSchedule.TransactionDate != event) {
                this._KSchedule.TransactionDate = event;
            }
        }
    }



    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.StartDate, "Value", this.__ttObject, "StartDate");
        redirectProperty(this.EndDate, "Value", this.__ttObject, "EndDate");
        redirectProperty(this.IDPatient, "Text", this.__ttObject, "Episode.Patient.ID");
        redirectProperty(this.FullNamePatient, "Text", this.__ttObject, "Episode.Patient.FullName");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.labelFullNamePatient = new TTVisual.TTLabel();
        this.labelFullNamePatient.Text = i18n("M15428", "Hastanın Adı Soyadı ");
        this.labelFullNamePatient.Name = "labelFullNamePatient";
        this.labelFullNamePatient.TabIndex = 20;

        this.FullNamePatient = new TTVisual.TTTextBox();
        this.FullNamePatient.BackColor = "#F0F0F0";
        this.FullNamePatient.ReadOnly = true;
        this.FullNamePatient.Name = "FullNamePatient";
        this.FullNamePatient.TabIndex = 19;

        this.IDPatient = new TTVisual.TTTextBox();
        this.IDPatient.BackColor = "#F0F0F0";
        this.IDPatient.ReadOnly = true;
        this.IDPatient.Name = "IDPatient";
        this.IDPatient.TabIndex = 17;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Description.Name = "Description";
        this.Description.TabIndex = 6;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.labelIDPatient = new TTVisual.TTLabel();
        this.labelIDPatient.Text = i18n("M15230", "Hasta ID");
        this.labelIDPatient.Name = "labelIDPatient";
        this.labelIDPatient.TabIndex = 18;

        this.StartDate = new TTVisual.TTDateTimePicker();
        this.StartDate.BackColor = "#F0F0F0";
        this.StartDate.CustomFormat = "dd.MM.yyyy HH:mm";
        this.StartDate.Format = DateTimePickerFormat.Custom;
        this.StartDate.Enabled = false;
        this.StartDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.StartDate.Name = "StartDate";
        this.StartDate.TabIndex = 1;

        this.DestinationStore = new TTVisual.TTObjectListBox();
        this.DestinationStore.ReadOnly = true;
        this.DestinationStore.ListDefName = "RoomAndSubStoreList";
        this.DestinationStore.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DestinationStore.Name = "DestinationStore";
        this.DestinationStore.TabIndex = 5;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = "#F0F0F0";
        this.TransactionDate.CustomFormat = "";
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 1;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.BackColor = "#DCDCDC";
        this.labelTransactionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelTransactionDate.ForeColor = "#000000";
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 9;

        this.EndDate = new TTVisual.TTDateTimePicker();
        this.EndDate.BackColor = "#F0F0F0";
        this.EndDate.CustomFormat = "dd.MM.yyyy HH:mm";
        this.EndDate.Format = DateTimePickerFormat.Custom;
        this.EndDate.Enabled = false;
        this.EndDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.EndDate.Name = "EndDate";
        this.EndDate.TabIndex = 1;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 16;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.BackColor = "#FFFFFF";
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = i18n("M16709", "İstenen İlaçlar");
        this.tttabpage1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttabpage1.Name = "tttabpage1";

        this.StockActionOutDetails = new TTVisual.TTGrid();
        this.StockActionOutDetails.Required = true;
        this.StockActionOutDetails.AllowUserToAddRows = false;
        this.StockActionOutDetails.AllowUserToDeleteRows = false;
        this.StockActionOutDetails.BackColor = "#FFE3C6";
        this.StockActionOutDetails.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.StockActionOutDetails.Name = "StockActionOutDetails";
        this.StockActionOutDetails.TabIndex = 7;
        this.StockActionOutDetails.Height = 350;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.ListDefName = "MaterialListDefinition";
        this.Material.DataMember = "Material";
        this.Material.DisplayIndex = 0;
        this.Material.HeaderText = i18n("M16287", "İlaç");
        this.Material.Name = "Material";
        this.Material.ReadOnly = true;
        this.Material.Width = 500;

        this.RequestAmount = new TTVisual.TTTextBoxColumn();
        this.RequestAmount.DataMember = "RequestAmount";
        this.RequestAmount.DisplayIndex = 1;
        this.RequestAmount.HeaderText = i18n("M16713", "İstenen Miktar");
        this.RequestAmount.Name = "RequestAmount";
        this.RequestAmount.Width = 160;
        this.RequestAmount.IsNumeric = true;

        this.ReceivedAmount = new TTVisual.TTTextBoxColumn();
        this.ReceivedAmount.DataMember = "Amount";
        this.ReceivedAmount.DisplayIndex = 2;
        this.ReceivedAmount.HeaderText = i18n("M17315", "Karşılanan Miktar");
        this.ReceivedAmount.Name = "ReceivedAmount";
        this.ReceivedAmount.ReadOnly = true;
        this.ReceivedAmount.Width = 160;
        this.ReceivedAmount.IsNumeric = true;

        this.DemandDescription = new TTVisual.TTTextBoxColumn();
        this.DemandDescription.DataMember = "Description";
        this.DemandDescription.DisplayIndex = 3;
        this.DemandDescription.HeaderText = i18n("M10469", "Açıklama");
        this.DemandDescription.Name = "DemandDescription";
        this.DemandDescription.Width = 160;

        this.DemandAmount = new TTVisual.TTTextBoxColumn();
        this.DemandAmount.DataMember = "Amount";
        this.DemandAmount.DisplayIndex = 4;
        this.DemandAmount.HeaderText = i18n("M19030", "Miktar");
        this.DemandAmount.Name = "DemandAmount";
        this.DemandAmount.ReadOnly = true;
        this.DemandAmount.Visible = false;
        this.DemandAmount.Width = 160;
        this.DemandAmount.IsNumeric = true;

        this.StockLevelType = new TTVisual.TTListDefComboBoxColumn();
        this.StockLevelType.ListDefName = "StockLevelTypeList";
        this.StockLevelType.DataMember = "StockLevelType";
        this.StockLevelType.DisplayIndex = 5;
        this.StockLevelType.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelType.Name = "StockLevelType";
        this.StockLevelType.ReadOnly = true;
        this.StockLevelType.Width = 160;

        this.tttabpage2 = new TTVisual.TTTabPage();
        this.tttabpage2.DisplayIndex = 1;
        this.tttabpage2.BackColor = "#FFFFFF";
        this.tttabpage2.TabIndex = 0;
        this.tttabpage2.Text = "Çıkmayan İlaçlar";
        this.tttabpage2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttabpage2.Name = "tttabpage2";

        this.UnSupplyGrid = new TTVisual.TTGrid();
        this.UnSupplyGrid.ReadOnly = true;
        this.UnSupplyGrid.Name = "UnSupplyGrid";
        this.UnSupplyGrid.TabIndex = 15;
        this.UnSupplyGrid.Height = 350;
        this.UnSupplyGrid.AllowUserToAddRows = false;
        this.UnSupplyGrid.AllowUserToDeleteRows = false;

        this.UnListDrug = new TTVisual.TTTextBoxColumn();
        this.UnListDrug.DataMember = "UnlistDrug";
        this.UnListDrug.DisplayIndex = 0;
        this.UnListDrug.HeaderText = i18n("M16287", "İlaç");
        this.UnListDrug.Name = "UnListDrug";
        this.UnListDrug.ReadOnly = true;
        this.UnListDrug.Width = 500;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "UnlistAmount";
        this.Amount.DisplayIndex = 1;
        this.Amount.HeaderText = i18n("M19030", "Miktar");
        this.Amount.Name = "Amount";
        this.Amount.ReadOnly = true;
        this.Amount.Width = 160;
        this.Amount.IsNumeric = true;

        this.Dose = new TTVisual.TTTextBoxColumn();
        this.Dose.DataMember = "UnlistVolume";
        this.Dose.DisplayIndex = 2;
        this.Dose.HeaderText = i18n("M13284", "Doz");
        this.Dose.Name = "Dose";
        this.Dose.ReadOnly = true;
        this.Dose.Width = 160;

        this.Reason = new TTVisual.TTTextBoxColumn();
        this.Reason.DataMember = "UnlistReason";
        this.Reason.DisplayIndex = 3;
        this.Reason.HeaderText = i18n("M21504", "Sebebi");
        this.Reason.Name = "Reason";
        this.Reason.ReadOnly = true;
        this.Reason.Width = 270;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M16679", "İstek Yapılan Depo");
        this.labelStore.BackColor = "#DCDCDC";
        this.labelStore.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelStore.ForeColor = "#000000";
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 10;

        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = i18n("M10469", "Açıklama");
        this.labelDescription.BackColor = "#DCDCDC";
        this.labelDescription.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelDescription.ForeColor = "#000000";
        this.labelDescription.Name = "labelDescription";
        this.labelDescription.TabIndex = 14;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.BackColor = "#DCDCDC";
        this.labelStockActionID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelStockActionID.ForeColor = "#000000";
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 8;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "StoresList";
        this.Store.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Store.Name = "Store";
        this.Store.TabIndex = 2;

        this.labelDestinationStore = new TTVisual.TTLabel();
        this.labelDestinationStore.Text = i18n("M16660", "İstek Yapan Depo");
        this.labelDestinationStore.BackColor = "#DCDCDC";
        this.labelDestinationStore.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelDestinationStore.ForeColor = "#000000";
        this.labelDestinationStore.Name = "labelDestinationStore";
        this.labelDestinationStore.TabIndex = 13;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M11637", "Başlangıç Tarihi");
        this.ttlabel1.BackColor = "#DCDCDC";
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 9;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M11939", "Bitiş Tarihi");
        this.ttlabel2.BackColor = "#DCDCDC";
        this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 9;

        this.MKYS_TeslimAlan = new TTVisual.TTTextBoxColumn();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";

        this.StockActionOutDetailsColumns = [this.Material, this.RequestAmount, this.ReceivedAmount, this.DemandDescription, this.DemandAmount, this.StockLevelType];
        this.UnSupplyGridColumns = [this.UnListDrug, this.Amount, this.Dose, this.Reason];
        this.tttabcontrol1.Controls = [this.tttabpage1, this.tttabpage2];
        this.tttabpage1.Controls = [this.StockActionOutDetails];
        this.tttabpage2.Controls = [this.UnSupplyGrid];
        this.Controls = [this.MKYS_TeslimAlan, this.labelFullNamePatient, this.FullNamePatient, this.IDPatient, this.Description, this.StockActionID, this.labelIDPatient, this.StartDate, this.DestinationStore, this.TransactionDate, this.labelTransactionDate, this.EndDate, this.tttabcontrol1, this.tttabpage1, this.StockActionOutDetails, this.Material, this.RequestAmount, this.ReceivedAmount, this.DemandDescription, this.DemandAmount, this.StockLevelType, this.tttabpage2, this.UnSupplyGrid, this.UnListDrug, this.Amount, this.Dose, this.Reason, this.labelStore, this.labelDescription, this.labelStockActionID, this.Store, this.labelDestinationStore, this.ttlabel1, this.ttlabel2];

    }


}
