//$A5BA00E4
import { Component, ViewChild, OnInit, ChangeDetectorRef, NgZone } from '@angular/core';
import { DailyDrugScheduleNewFormViewModel } from './DailyDrugScheduleNewFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { BaseDailyDrugScheduleForm } from 'Modules/Saglik_Lojistik/Eczane_Modulleri/Gunluk_Ilac_Cizelgesi_Modulu/BaseDailyDrugScheduleForm';
import { DailyDrugPatient } from 'NebulaClient/Model/AtlasClientModel';
import { DailyDrugSchedule } from 'NebulaClient/Model/AtlasClientModel';
import { DailyDrugSchOrder } from 'NebulaClient/Model/AtlasClientModel';
import { DailyDrugSchOrderDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DailyDrugUnDrug } from 'NebulaClient/Model/AtlasClientModel';
import { DailyDrugUnDrugDet } from 'NebulaClient/Model/AtlasClientModel';
import {
    DailyDrugScheduleService, PrepareDrugDetail_Output, PrepareDrugDetail_Output_Detail,
    PrepareUnDrugDetail_Output_Detail
} from 'ObjectClassService/DailyDrugScheduleService';
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { NursingApplication } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { ResourceService } from 'ObjectClassService/ResourceService';

import { DxDataGridComponent } from 'devextreme-angular';
import query from 'devextreme/data/query';

import { ServiceLocator } from 'Fw/Services/ServiceLocator';

@Component({
    selector: 'DailyDrugScheduleNewForm',
    templateUrl: './DailyDrugScheduleNewForm.html',
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
export class DailyDrugScheduleNewForm extends BaseDailyDrugScheduleForm implements OnInit {

    public preparingDailyDrugOrder: PrepareDrugDetail_Output;
    public details: Array<PrepareDrugDetail_Output_Detail> = new Array<PrepareDrugDetail_Output_Detail>();
    public selectedDetails: Array<PrepareDrugDetail_Output_Detail> = new Array<PrepareDrugDetail_Output_Detail>();

    public unDrugDetails: Array<PrepareUnDrugDetail_Output_Detail> = new Array<PrepareUnDrugDetail_Output_Detail>();

    public PatientObjectID: Guid;
    public DailyDrugPatientsGridColumns = [];
    public DailyDrugSchOrdersGridColumns = [];
    public DailyDrugUnDrugsGridColumns = [];
    public dailyDrugScheduleNewFormViewModel: DailyDrugScheduleNewFormViewModel = new DailyDrugScheduleNewFormViewModel();
    public get _DailyDrugSchedule(): DailyDrugSchedule {
        return this._TTObject as DailyDrugSchedule;
    }
    private DailyDrugScheduleNewForm_DocumentUrl: string = '/api/DailyDrugScheduleService/DailyDrugScheduleNewForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, private objectContextService: ObjectContextService,
        private modalStateService: ModalStateService, private changeDetectorRef: ChangeDetectorRef, protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.DailyDrugScheduleNewForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public async setInputParam(value: Object) {
        if (value !== undefined) {
            if (value['ObjectDefID'] === NursingApplication.ObjectDefID.toString()) {
                let nursingApp: NursingApplication = <NursingApplication>value;
                let patientEpisode: Episode = nursingApp.Episode;
                this.PatientObjectID = <any>patientEpisode['Patient'];


                let resourceID: Guid = <any>nursingApp['SecondaryMasterResource'];
                let resourceStore: Store = await ResourceService.GetStore(resourceID.toString());
                this._DailyDrugSchedule.DestinationStore = resourceStore;
            }
        } else {
            this.PatientObjectID = undefined;
        }
    }

    protected async setState(transDef: TTObjectStateTransitionDef) {
        await super.setState(transDef);
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this._DailyDrugSchedule);
    }

    protected async save() {
        await super.save();
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this._DailyDrugSchedule);
    }

    public cancel() {
       // this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
        this.ActionExecuted.emit({ Cancelled: true });
    }

    @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent;
    totalCount: number;
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
                    }, {
                        value: 'PatientName',
                        text: i18n("M15516", "Hastaya Göre Grupla ")
                    }],
                    displayExpr: 'text',
                    valueExpr: 'value',
                    value: 'PatientName',
                    onValueChanged: this.groupChanged.bind(this)
                }
            });
    }

    getGroupCount(groupField) {
        return query(this.selectedDetails)
            .groupBy(groupField)
            .toArray().length;
    }

    groupChanged(e) {
        this.dataGrid.instance.clearGrouping();
        this.dataGrid.instance.columnOption(e.value, 'groupIndex', 0);
        this.totalCount = this.getGroupCount(e.value);
    }
    collapseAllClick(e) {
    }


    // ***** Method declarations start *****

    protected async PreScript() {

        super.PreScript();
       /* //GİÇTARİHPARAMETRE geldi ondan kapandı
        let dateStart: Date = new Date();
        dateStart.setHours(0, 0, 0);
        let dateEnd: Date = new Date();
        dateEnd.setHours(23, 59, 59);
        this.dailyDrugScheduleNewFormViewModel._DailyDrugSchedule.StartDate = dateStart;
        this.dailyDrugScheduleNewFormViewModel._DailyDrugSchedule.EndDate = dateEnd;*/
    }

    protected async PostScript() {
        this.dailyDrugScheduleNewFormViewModel.DailyDrugPatientsGridGridList = new Array<DailyDrugPatient>();
        this.dailyDrugScheduleNewFormViewModel.DailyDrugSchOrdersGridGridList = new Array<DailyDrugSchOrder>();
        this.dailyDrugScheduleNewFormViewModel.DailyDrugSchOrderDetails = new Array<DailyDrugSchOrderDetail>();

        for (let dailyDrugPatientNew of this.dailyDrugScheduleNewFormViewModel.DailyDrugUnDrugsGridGridList) {
            dailyDrugPatientNew.DailyDrugPatient = new DailyDrugPatient;
        }

        if (this.selectedDetails.length > 0) {
            for (let order of this.selectedDetails) {
                this.dailyDrugScheduleNewFormViewModel.DailyDrugSchOrdersGridGridList.push(order.dailyDrugSchOrder);
                for (let orderDet of order.dailyDrugSchOrderDetails) {
                    this.dailyDrugScheduleNewFormViewModel.DailyDrugSchOrderDetails.push(orderDet);
                }
                if (order.IsNarcotic == true) {
                    ServiceLocator.MessageService.showInfo(order.DrugName + ' Yüksek Riskli İlaçtır!');
                }
                if (order.IsPsychotropic == true) {
                    ServiceLocator.MessageService.showInfo(order.DrugName + i18n("M20617", " Psikotrop Madde İçermektedir!"));
                }
            }
        } else {
            TTVisual.InfoBox.Alert(i18n("M15235", "Hasta İlaç seçilmeden işlem devam ettirilemez!"), MessageIconEnum.ErrorMessage);
        }
    }
    expanded;
    loadIndicatorVisible = false;
    loadingVisible = false;
    public async DailyDrugOrderGetByDate_Click(): Promise<void> {
        if (this._DailyDrugSchedule.StartDate !== null && this._DailyDrugSchedule.EndDate !== null) {
            this.loadingVisible = true;
            this.preparingDailyDrugOrder = await DailyDrugScheduleService.PrapareDailyDrugPatient(this._DailyDrugSchedule.DestinationStore.ObjectID,
                <Date>this._DailyDrugSchedule.StartDate, <Date>this._DailyDrugSchedule.EndDate, this.PatientObjectID);

            if (this.preparingDailyDrugOrder != null) {
                this.details = this.preparingDailyDrugOrder.details;
            }

            this.loadingVisible = false;
            this.dailyDrugScheduleNewFormViewModel.DailyDrugSchOrdersGridGridList = this.preparingDailyDrugOrder.dailyDrugSchOrders;
            this.dailyDrugScheduleNewFormViewModel.DailyDrugSchOrderDetails = this.preparingDailyDrugOrder.dailyDrugSchOrderDetails;
            this.dailyDrugScheduleNewFormViewModel.DailyDrugUnDrugsGridGridList = this.preparingDailyDrugOrder.dailyDrugUnDrugs;
            this.dailyDrugScheduleNewFormViewModel.DailyDrugUnDrugDets = this.preparingDailyDrugOrder.dailyDrugUnDrugDets;
            this.dailyDrugScheduleNewFormViewModel.DailyDrugPatients = this.preparingDailyDrugOrder.dailyDrugPatients;

            this.dailyDrugScheduleNewFormViewModel._DailyDrugSchedule.DailyDrugUnDrugs = this.preparingDailyDrugOrder.dailyDrugUnDrugs;

            for (let unDrug of this.preparingDailyDrugOrder.udDrugDetails) {
                this.unDrugDetails.push(unDrug);
            }

            if (this.details.length > 0) {
                this.ttdatetimepicker1.ReadOnly = true;
                this.ttdatetimepicker2.ReadOnly = true;
                this.DailyDrugOrderGetByDate.ReadOnly = true;
            }
        } else {
            TTVisual.InfoBox.Alert(i18n("M11641", "Başlangıç ve bitiş tarihi dolu olmak zorundadır!"), MessageIconEnum.ErrorMessage);
        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DailyDrugSchedule();
        this.dailyDrugScheduleNewFormViewModel = new DailyDrugScheduleNewFormViewModel();
        this._ViewModel = this.dailyDrugScheduleNewFormViewModel;
        this.dailyDrugScheduleNewFormViewModel._DailyDrugSchedule = this._TTObject as DailyDrugSchedule;
        this.dailyDrugScheduleNewFormViewModel._DailyDrugSchedule.DailyDrugPatients = new Array<DailyDrugPatient>();
        this.dailyDrugScheduleNewFormViewModel._DailyDrugSchedule.DailyDrugSchOrders = new Array<DailyDrugSchOrder>();
        this.dailyDrugScheduleNewFormViewModel._DailyDrugSchedule.DailyDrugUnDrugs = new Array<DailyDrugUnDrug>();
        this.dailyDrugScheduleNewFormViewModel._DailyDrugSchedule.Store = new Store();
        this.dailyDrugScheduleNewFormViewModel._DailyDrugSchedule.DestinationStore = new Store();
        this.dailyDrugScheduleNewFormViewModel.DailyDrugSchOrderDetails = new Array<DailyDrugSchOrderDetail>();
        this.dailyDrugScheduleNewFormViewModel.DailyDrugUnDrugDets = new Array<DailyDrugUnDrugDet>();
    }

    protected loadViewModel() {
        let that = this;
        that.dailyDrugScheduleNewFormViewModel = this._ViewModel as DailyDrugScheduleNewFormViewModel;
        that._TTObject = this.dailyDrugScheduleNewFormViewModel._DailyDrugSchedule;
        if (this.dailyDrugScheduleNewFormViewModel == null) {
            this.dailyDrugScheduleNewFormViewModel = new DailyDrugScheduleNewFormViewModel();
        }
        if (this.dailyDrugScheduleNewFormViewModel._DailyDrugSchedule == null) {
            this.dailyDrugScheduleNewFormViewModel._DailyDrugSchedule = new DailyDrugSchedule();
        }
        that.dailyDrugScheduleNewFormViewModel._DailyDrugSchedule.DailyDrugPatients = that.dailyDrugScheduleNewFormViewModel.DailyDrugPatientsGridGridList;
        for (let detailItem of that.dailyDrugScheduleNewFormViewModel.DailyDrugPatientsGridGridList) {
            let episodeObjectID = detailItem['Episode'];
            if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
                let episode = that.dailyDrugScheduleNewFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
                 if (episode) {
                    detailItem.Episode = episode;
                }
                if (episode != null) {
                    let patientObjectID = episode['Patient'];
                    if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                        let patient = that.dailyDrugScheduleNewFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                         if (patient) {
                            episode.Patient = patient;
                        }
                    }
                }
            }
        }
        that.dailyDrugScheduleNewFormViewModel._DailyDrugSchedule.DailyDrugSchOrders = that.dailyDrugScheduleNewFormViewModel.DailyDrugSchOrdersGridGridList;
        for (let detailItem of that.dailyDrugScheduleNewFormViewModel.DailyDrugSchOrdersGridGridList) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.dailyDrugScheduleNewFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
            }
            let dailyDrugPatientObjectID = detailItem['DailyDrugPatient'];
            if (dailyDrugPatientObjectID != null && (typeof dailyDrugPatientObjectID === 'string')) {
                let dailyDrugPatient = that.dailyDrugScheduleNewFormViewModel.DailyDrugPatients.find(o => o.ObjectID.toString() === dailyDrugPatientObjectID.toString());
                 if (dailyDrugPatient) {
                    detailItem.DailyDrugPatient = dailyDrugPatient;
                }
                if (dailyDrugPatient != null) {
                    let episodeObjectID = dailyDrugPatient['Episode'];
                    if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
                        let episode = that.dailyDrugScheduleNewFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
                         if (episode) {
                            dailyDrugPatient.Episode = episode;
                        }
                        if (episode != null) {
                            let patientObjectID = episode['Patient'];
                            if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                                let patient = that.dailyDrugScheduleNewFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                                 if (patient) {
                                    episode.Patient = patient;
                                }
                            }
                        }
                    }
                }
            }
        }
        that.dailyDrugScheduleNewFormViewModel._DailyDrugSchedule.DailyDrugUnDrugs = that.dailyDrugScheduleNewFormViewModel.DailyDrugUnDrugsGridGridList;
        for (let detailItem of that.dailyDrugScheduleNewFormViewModel.DailyDrugUnDrugsGridGridList) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.dailyDrugScheduleNewFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
            }
            let dailyDrugPatientObjectID = detailItem['DailyDrugPatient'];
            if (dailyDrugPatientObjectID != null && (typeof dailyDrugPatientObjectID === 'string')) {
                let dailyDrugPatient = that.dailyDrugScheduleNewFormViewModel.DailyDrugPatients.find(o => o.ObjectID.toString() === dailyDrugPatientObjectID.toString());
                 if (dailyDrugPatient) {
                    detailItem.DailyDrugPatient = dailyDrugPatient;
                }
                if (dailyDrugPatient != null) {
                    let episodeObjectID = dailyDrugPatient['Episode'];
                    if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
                        let episode = that.dailyDrugScheduleNewFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
                         if (episode) {
                            dailyDrugPatient.Episode = episode;
                        }
                        if (episode != null) {
                            let patientObjectID = episode['Patient'];
                            if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                                let patient = that.dailyDrugScheduleNewFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                                 if (patient) {
                                    episode.Patient = patient;
                                }
                            }
                        }
                    }
                }
            }
        }
        let storeObjectID = that.dailyDrugScheduleNewFormViewModel._DailyDrugSchedule['Store'];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.dailyDrugScheduleNewFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
             if (store) {
                that.dailyDrugScheduleNewFormViewModel._DailyDrugSchedule.Store = store;
            }
        }
        let destinationStoreObjectID = that.dailyDrugScheduleNewFormViewModel._DailyDrugSchedule['DestinationStore'];
        if (destinationStoreObjectID != null && (typeof destinationStoreObjectID === 'string')) {
            let destinationStore = that.dailyDrugScheduleNewFormViewModel.Stores.find(o => o.ObjectID.toString() === destinationStoreObjectID.toString());
             if (destinationStore) {
                that.dailyDrugScheduleNewFormViewModel._DailyDrugSchedule.DestinationStore = destinationStore;
            }
        }
    }


    async ngOnInit() {
        await this.load();
        this.FormCaption = i18n("M15036", "Günlük İlaç Çizelgesi İstek ( Yeni )");
        this.changeDetectorRef.detectChanges();
    }

    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._DailyDrugSchedule != null && this._DailyDrugSchedule.ActionDate !== event) {
                this._DailyDrugSchedule.ActionDate = event;
            }
        }
    }

    public onDestinationStoreChanged(event): void {
        if (event != null) {
            if (this._DailyDrugSchedule != null && this._DailyDrugSchedule.DestinationStore !== event) {
                this._DailyDrugSchedule.DestinationStore = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._DailyDrugSchedule != null && this._DailyDrugSchedule.StockActionID !== event) {
                this._DailyDrugSchedule.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._DailyDrugSchedule != null && this._DailyDrugSchedule.Store !== event) {
                this._DailyDrugSchedule.Store = event;
            }
        }
    }

    public onttdatetimepicker1Changed(event): void {
        if (event != null) {
            if (this._DailyDrugSchedule != null && this._DailyDrugSchedule.StartDate !== event) {
                this._DailyDrugSchedule.StartDate = event;
            }
        }
    }

    public onttdatetimepicker2Changed(event): void {
        if (event != null) {
            if (this._DailyDrugSchedule != null && this._DailyDrugSchedule.EndDate !== event) {
                this._DailyDrugSchedule.EndDate = event;
            }
        }
    }
    public redirectProperties(): void {
        redirectProperty(this.StockActionID, 'Text', this.__ttObject, 'StockActionID');
        redirectProperty(this.ActionDate, 'Value', this.__ttObject, 'ActionDate');
        redirectProperty(this.ttdatetimepicker1, 'Value', this.__ttObject, 'StartDate');
        redirectProperty(this.ttdatetimepicker2, 'Value', this.__ttObject, 'EndDate');
    }

    public initFormControls(): void {
        this.tttabcontrol3 = new TTVisual.TTTabControl();
        this.tttabcontrol3.Name = 'tttabcontrol3';
        this.tttabcontrol3.TabIndex = 15;

        this.PatientTab = new TTVisual.TTTabPage();
        this.PatientTab.DisplayIndex = 0;
        this.PatientTab.TabIndex = 0;
        this.PatientTab.Text = i18n("M15369", "Hastalar");
        this.PatientTab.Name = 'PatientTab';

        this.DailyDrugPatientsGrid = new TTVisual.TTGrid();
        this.DailyDrugPatientsGrid.AllowUserToDeleteRows = false;
        this.DailyDrugPatientsGrid.Name = 'DailyDrugPatientsGrid';
        this.DailyDrugPatientsGrid.TabIndex = 16;
        this.DailyDrugPatientsGrid.Height = 350;
        this.DailyDrugPatientsGrid.AllowUserToAddRows = false;

        this.selecetedPatient = new TTVisual.TTCheckBoxColumn();
        this.selecetedPatient.DataMember = 'IsCheck';
        this.selecetedPatient.DisplayIndex = 0;
        this.selecetedPatient.HeaderText = i18n("M21507", "Seç");
        this.selecetedPatient.Name = 'selecetedPatient';
        this.selecetedPatient.Width = 100;

        this.patinetFullName = new TTVisual.TTTextBoxColumn();
        this.patinetFullName.DataMember = 'Episode.Patient.FullName';
        this.patinetFullName.DisplayIndex = 1;
        this.patinetFullName.HeaderText = i18n("M10517", "Adı Soyadı");
        this.patinetFullName.Name = 'patinetFullName';
        this.patinetFullName.ReadOnly = true;
        this.patinetFullName.Width = 300;

        this.tttabcontrol2 = new TTVisual.TTTabControl();
        this.tttabcontrol2.Name = 'tttabcontrol2';
        this.tttabcontrol2.TabIndex = 14;

        this.DrugListTab = new TTVisual.TTTabPage();
        this.DrugListTab.DisplayIndex = 0;
        this.DrugListTab.TabIndex = 0;
        this.DrugListTab.Text = i18n("M16389", "İlaçlar");
        this.DrugListTab.Name = 'DrugListTab';

        this.DailyDrugSchOrdersGrid = new TTVisual.TTGrid();
        this.DailyDrugSchOrdersGrid.AllowUserToDeleteRows = false;
        this.DailyDrugSchOrdersGrid.Name = 'DailyDrugSchOrdersGrid';
        this.DailyDrugSchOrdersGrid.TabIndex = 16;
        this.DailyDrugSchOrdersGrid.Height = 350;
        this.DailyDrugSchOrdersGrid.AllowUserToAddRows = false;

        this.drugOrderName = new TTVisual.TTTextBoxColumn();
        this.drugOrderName.DataMember = 'Material.Name';
        this.drugOrderName.DisplayIndex = 0;
        this.drugOrderName.HeaderText = i18n("M16294", "İlaç Adı");
        this.drugOrderName.Name = 'drugOrderName';
        this.drugOrderName.ReadOnly = true;
        this.drugOrderName.Width = 325;

        this.DoseAmountDailyDrugSchOrder = new TTVisual.TTTextBoxColumn();
        this.DoseAmountDailyDrugSchOrder.DataMember = 'DoseAmount';
        this.DoseAmountDailyDrugSchOrder.DisplayIndex = 1;
        this.DoseAmountDailyDrugSchOrder.HeaderText = i18n("M13294", "Doz Miktarı");
        this.DoseAmountDailyDrugSchOrder.Name = 'DoseAmountDailyDrugSchOrder';
        this.DoseAmountDailyDrugSchOrder.ReadOnly = true;
        this.DoseAmountDailyDrugSchOrder.Width = 100;
        this.DoseAmountDailyDrugSchOrder.IsNumeric = true;

        this.patientFullName = new TTVisual.TTTextBoxColumn();
        this.patientFullName.DataMember = 'DailyDrugPatient.Episode.Patient.FullName';
        this.patientFullName.DisplayIndex = 2;
        this.patientFullName.HeaderText = i18n("M15133", "Hasta Adı Soyadı");
        this.patientFullName.Name = 'patientFullName';
        this.patientFullName.ReadOnly = true;
        this.patientFullName.Width = 325;

        this.UnDrugListTab = new TTVisual.TTTabPage();
        this.UnDrugListTab.DisplayIndex = 1;
        this.UnDrugListTab.TabIndex = 1;
        this.UnDrugListTab.Text = 'Çıkmayan İlaçlar';
        this.UnDrugListTab.Name = 'UnDrugListTab';

        this.DailyDrugUnDrugsGrid = new TTVisual.TTGrid();
        this.DailyDrugUnDrugsGrid.AllowUserToDeleteRows = false;
        this.DailyDrugUnDrugsGrid.Name = 'DailyDrugUnDrugsGrid';
        this.DailyDrugUnDrugsGrid.TabIndex = 16;
        this.DailyDrugUnDrugsGrid.Height = 350;
        this.DailyDrugUnDrugsGrid.AllowUserToAddRows = false;

        this.UnDrugName = new TTVisual.TTTextBoxColumn();
        this.UnDrugName.DataMember = 'Material.Name';
        this.UnDrugName.DisplayIndex = 0;
        this.UnDrugName.HeaderText = i18n("M16294", "İlaç Adı");
        this.UnDrugName.Name = 'UnDrugName';
        this.UnDrugName.ReadOnly = true;
        this.UnDrugName.Width = 325;

        this.DoseAmountDailyDrugUnDrug = new TTVisual.TTTextBoxColumn();
        this.DoseAmountDailyDrugUnDrug.DataMember = 'DoseAmount';
        this.DoseAmountDailyDrugUnDrug.DisplayIndex = 1;
        this.DoseAmountDailyDrugUnDrug.HeaderText = i18n("M13294", "Doz Miktarı");
        this.DoseAmountDailyDrugUnDrug.Name = 'DoseAmountDailyDrugUnDrug';
        this.DoseAmountDailyDrugUnDrug.ReadOnly = true;
        this.DoseAmountDailyDrugUnDrug.Width = 80;
        this.DoseAmountDailyDrugUnDrug.IsNumeric = true;

        this.patientNameSurname = new TTVisual.TTTextBoxColumn();
        this.patientNameSurname.DataMember = 'DailyDrugPatient.Episode.Patient.FullName';
        this.patientNameSurname.DisplayIndex = 2;
        this.patientNameSurname.HeaderText = i18n("M15133", "Hasta Adı Soyadı");
        this.patientNameSurname.Name = 'patientNameSurname';
        this.patientNameSurname.ReadOnly = true;
        this.patientNameSurname.Width = 325;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = '#F0F0F0';
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = 'StockActionID';
        this.StockActionID.TabIndex = 4;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M13454", "Eczane Depo");
        this.labelStore.Name = 'labelStore';
        this.labelStore.TabIndex = 11;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = 'PharmacyStoreList';
        this.Store.Name = 'Store';
        this.Store.TabIndex = 10;

        this.labelDestinationStore = new TTVisual.TTLabel();
        this.labelDestinationStore.Text = i18n("M17628", "Klinik Depo");
        this.labelDestinationStore.Name = 'labelDestinationStore';
        this.labelDestinationStore.TabIndex = 9;

        this.DestinationStore = new TTVisual.TTObjectListBox();
        this.DestinationStore.ReadOnly = true;
        this.DestinationStore.ListDefName = 'RoomAndSubStoreList';
        this.DestinationStore.Name = 'DestinationStore';
        this.DestinationStore.TabIndex = 8;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelActionDate.Name = 'labelActionDate';
        this.labelActionDate.TabIndex = 7;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = '#F0F0F0';
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = 'ActionDate';
        this.ActionDate.TabIndex = 6;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = 'labelStockActionID';
        this.labelStockActionID.TabIndex = 5;

        this.labelStartDate = new TTVisual.TTLabel();
        this.labelStartDate.Text = i18n("M11637", "Başlangıç Tarihi");
        this.labelStartDate.Name = 'labelStartDate';
        this.labelStartDate.TabIndex = 3;


        this.labelEndDate = new TTVisual.TTLabel();
        this.labelEndDate.Text = i18n("M11939", "Bitiş Tarihi");
        this.labelEndDate.Name = 'labelEndDate';
        this.labelEndDate.TabIndex = 1;

        this.DailyDrugOrderGetByDate = new TTVisual.TTButton();
        this.DailyDrugOrderGetByDate.Text = 'Listele';
        this.DailyDrugOrderGetByDate.Name = 'DailyDrugOrderGetByDate';
        this.DailyDrugOrderGetByDate.TabIndex = 12;

        this.ttdatetimepicker2 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker2.Required = true;
        this.ttdatetimepicker2.BackColor = '#FFE3C6';
        //this.ttdatetimepicker2.CustomFormat = 'dd/MM/yyyy HH:mm';
        this.ttdatetimepicker2.Format = DateTimePickerFormat.Long;
        this.ttdatetimepicker2.Name = 'ttdatetimepicker2';
        this.ttdatetimepicker2.TabIndex = 5;

        this.ttdatetimepicker1 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker1.Required = true;
        this.ttdatetimepicker1.BackColor = '#FFE3C6';
        //this.ttdatetimepicker1.CustomFormat = 'dd/MM/yyyy HH:mm';
        this.ttdatetimepicker1.Format = DateTimePickerFormat.Long;
        this.ttdatetimepicker1.Name = 'ttdatetimepicker1';
        this.ttdatetimepicker1.TabIndex = 4;

        this.DailyDrugPatientsGridColumns = [this.selecetedPatient, this.patinetFullName];
        this.DailyDrugSchOrdersGridColumns = [this.drugOrderName, this.DoseAmountDailyDrugSchOrder, this.patientFullName];
        this.DailyDrugUnDrugsGridColumns = [this.UnDrugName, this.DoseAmountDailyDrugUnDrug, this.patientNameSurname];
        this.tttabcontrol3.Controls = [this.PatientTab];
        this.PatientTab.Controls = [this.DailyDrugPatientsGrid];
        this.tttabcontrol2.Controls = [this.DrugListTab, this.UnDrugListTab];
        this.DrugListTab.Controls = [this.DailyDrugSchOrdersGrid];
        this.UnDrugListTab.Controls = [this.DailyDrugUnDrugsGrid];
        this.Controls = [this.tttabcontrol3, this.PatientTab, this.DailyDrugPatientsGrid, this.selecetedPatient, this.patinetFullName,
        this.tttabcontrol2, this.DrugListTab, this.DailyDrugSchOrdersGrid, this.drugOrderName, this.DoseAmountDailyDrugSchOrder, this.patientFullName,
        this.UnDrugListTab, this.DailyDrugUnDrugsGrid, this.UnDrugName, this.DoseAmountDailyDrugUnDrug, this.patientNameSurname, this.StockActionID,
        this.labelStore, this.Store, this.labelDestinationStore, this.DestinationStore, this.labelActionDate, this.ActionDate, this.labelStockActionID,
        this.labelStartDate, this.labelEndDate, this.DailyDrugOrderGetByDate, this.ttdatetimepicker2, this.ttdatetimepicker1];

    }


}
