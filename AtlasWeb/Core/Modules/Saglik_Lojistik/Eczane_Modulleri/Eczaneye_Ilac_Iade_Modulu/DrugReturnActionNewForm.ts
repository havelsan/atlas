//$9734C9CD
import { Component, OnInit, NgZone } from '@angular/core';
import { DrugReturnActionNewFormViewModel } from './DrugReturnActionNewFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { DrugReturnActionService, GetReturnableDetails_Output, GetReturnDetails } from 'ObjectClassService/DrugReturnActionService';
import { DrugReturnAction, Store } from 'NebulaClient/Model/AtlasClientModel';
import { DrugReturnActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { PharmacyStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ModalInfo } from 'Fw/Models/ModalInfo';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';

import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { TTException } from 'NebulaClient/Utils/Exceptions/TTException';
import { PharmacyStoreDefinitionService } from 'ObjectClassService/PharmacyStoreDefinitionService';
@Component({
    selector: 'DrugReturnActionNewForm',
    templateUrl: './DrugReturnActionNewForm.html',
    providers: [MessageService]
})
export class DrugReturnActionNewForm extends TTVisual.TTForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    AmountDrugReturnActionDetail: TTVisual.ITTTextBoxColumn;
    DrugOrderTransactionDrugReturnActionDetail: TTVisual.ITTListBoxColumn;
    DrugReturnActionDetails: TTVisual.ITTGrid;
    ID: TTVisual.ITTTextBox;
    DrugReturnReason: TTVisual.ITTTextBox;
    labelActionDate: TTVisual.ITTLabel;
    labelID: TTVisual.ITTLabel;
    labelPharmacyStoreDefinition: TTVisual.ITTLabel;
    PharmacyStoreDefinition: TTVisual.ITTObjectListBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    tttextbox1: TTVisual.ITTTextBox;
    SendAmount: TTVisual.ITTTextBoxColumn;
    buttonDeleteDrugOrder: TTVisual.ITTButtonColumn;
    outputDetails: GetReturnDetails = new GetReturnDetails();
    returnableDetails: Array<GetReturnableDetails_Output> = new Array<GetReturnableDetails_Output>();
    selectedDetails: Array<GetReturnableDetails_Output> = new Array<GetReturnableDetails_Output>();
    reviewActionDetails: Array<GetReturnableDetails_Output> = new Array<GetReturnableDetails_Output>();



    public DrugReturnActionDetailsColumns = [];
    public drugReturnActionNewFormViewModel: DrugReturnActionNewFormViewModel = new DrugReturnActionNewFormViewModel();
    public get _DrugReturnAction(): DrugReturnAction {
        return this._TTObject as DrugReturnAction;
    }
    private DrugReturnActionNewForm_DocumentUrl: string = '/api/DrugReturnActionService/DrugReturnActionNewForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private objectContextService: ObjectContextService,
        protected ngZone: NgZone) {
        super('DRUGRETURNACTION', 'DrugReturnActionNewForm');
        this._DocumentServiceUrl = this.DrugReturnActionNewForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    public async setInputParam(value: Object) {
        this._TTObject = value as DrugReturnAction;
        this.drugReturnActionNewFormViewModel = new DrugReturnActionNewFormViewModel();
        this._ViewModel = this.drugReturnActionNewFormViewModel;
        this.drugReturnActionNewFormViewModel._DrugReturnAction = value as DrugReturnAction;
        //await this.PreScript();

    }

    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    protected isLoadViewModel(): boolean {
        return false;
    }
    // ***** Method declarations start *****



    editorPreparing(e: any) {
        if (e.parentType === 'dataRow' && e.dataField !== 'ReturnAmount' && e.dataField !== undefined) {
            e.editorOptions.readOnly = true;
        }
    }

    protected async PreScript() {
        super.PreScript();
        if (this._DrugReturnAction.PharmacyStoreDefinition == null) {
            let pharmacyStore: Store = await PharmacyStoreDefinitionService.GetPharmacy();
            if (pharmacyStore != null) {
                this._DrugReturnAction.PharmacyStoreDefinition = pharmacyStore;
            } /*else {
                let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                for (let mainStore of pharmacyStores) { mSelectForm.AddMSItem(mainStore.Name, mainStore.ObjectID.toString(), mainStore); }
                let mkey: string = await mSelectForm.GetMSItem(this, i18n("M16415", "İlgili Ana Depoyu Seçiniz"), true);
                if (String.isNullOrEmpty(mkey))
                    ServiceLocator.MessageService.showError(i18n("M16940", "İşlemin yapılacağı ana depo seçilmeden işleme devam edemezsiniz."));
                this._DrugReturnAction.PharmacyStoreDefinition = mSelectForm.MSSelectedItemObject as PharmacyStoreDefinition;
            }*/
        }
        this.DropStateButton(DrugReturnAction.DrugReturnActionStates.Completed);
        this.drugReturnActionNewFormViewModel.DrugReturnActionDetailsGridList = new Array<DrugReturnActionDetail>();
        this._DrugReturnAction.DrugReturnActionDetails = new Array<DrugReturnActionDetail>();
        let episodeId: string = this._DrugReturnAction.Episode.ObjectID.toString();

        this.outputDetails = await DrugReturnActionService.GetReturnableDetails(this._DrugReturnAction.Episode.ObjectID);
        if (this.outputDetails.getReturnableDetails.length > 0){
            this.returnableDetails = this.outputDetails.getReturnableDetails;
        }
        if (this.outputDetails.getReviewDetails.length > 0){
            this.reviewActionDetails = this.outputDetails.getReviewDetails;
        }
        //this.returnableDetails = await DrugReturnActionService.GetReturnableDetails(this._DrugReturnAction.Episode.ObjectID);




        /*for (let detail of allDrugOrderTransaction) {
            let drugReturnActionDetail: DrugReturnActionDetail = detail;
            let drugOrderTransactionId: Guid = <any>detail['DrugOrderTransaction'];
            let drugOrderTransaction: DrugOrderTransaction = await this.objectContextService.getObject<DrugOrderTransaction>(drugOrderTransactionId, DrugOrderTransaction.ObjectDefID);
            drugReturnActionDetail.DrugOrderTransaction = drugOrderTransaction;
            let drugOrderId: Guid = <any>drugReturnActionDetail.DrugOrderTransaction['DrugOrder'];
            let drugOrder: DrugOrder = await this.objectContextService.getObject<DrugOrder>(drugOrderId, DrugOrder.ObjectDefID);
            drugReturnActionDetail.DrugOrderTransaction.DrugOrder = drugOrder;
            let materialId: Guid = <any>drugReturnActionDetail.DrugOrderTransaction.DrugOrder['Material'];
            let material: Material = await this.objectContextService.getObject<Material>(materialId, Material.ObjectDefID);
            drugReturnActionDetail.DrugOrderTransaction.DrugOrder.Material = material;
            this.drugReturnActionNewFormViewModel.DrugReturnActionDetailsGridList.push(drugReturnActionDetail);
            this._DrugReturnAction.DrugReturnActionDetails.push(drugReturnActionDetail);
        }


        for (let sendAmountGrid of this.drugReturnActionNewFormViewModel._DrugReturnAction.DrugReturnActionDetails) {
            sendAmountGrid.SendAmount = sendAmountGrid.Amount;
        }*/
    }

    protected async PostScript() {

    }

    protected async ClientSidePostScript()
    {
        if (this._DrugReturnAction.DrugReturnReason !== null && this._DrugReturnAction.DrugReturnReason !== undefined) {
            if (this.selectedDetails.length > 0) {
                for (let detail of this.selectedDetails) {
                    if (detail.ReturnAmount <= detail.Amount) {
                        let drugReturnActionDetail: DrugReturnActionDetail = new DrugReturnActionDetail();
                        drugReturnActionDetail.DrugName = detail.drugName;
                        drugReturnActionDetail.Amount = detail.Amount;
                        drugReturnActionDetail.SendAmount = detail.ReturnAmount;
                        drugReturnActionDetail.DrugOrderTransaction = detail.drugOrderTransaction;
                        this.drugReturnActionNewFormViewModel.DrugReturnActionDetailsGridList.push(drugReturnActionDetail);
                        this._DrugReturnAction.DrugReturnActionDetails.push(drugReturnActionDetail);
                    } else {
                        ServiceLocator.MessageService.showError(i18n("M16062", "İade edilecek miktar kalan miktardan büyük olamaz!"));
                    }
                }
            } else {
                ServiceLocator.MessageService.showError(i18n("M16059", "İade edilecek ilaç(lar) seçilmedi!"));
            }
        } else {
            throw new TTException(i18n("M16070", "İade nedeni girmelisiniz!"));
            //ServiceLocator.MessageService.showError('İade nedeni girmelisiniz!');
            //return;
        }
    }


    initDrugReturnActionDetailsNewRow(data: any) { }
    onDrugReturnActionDetailsRowInserting(data: any) { }
    onSelectionChangeDrugReturnActionDetails(data: any) { }
    async DrugReturnActionDetails_CellValueChangedEmitted(data: any) {
        if (data.Column.Name === 'SendAmount') {
            let drugReturnActionDetails: DrugReturnActionDetail = <DrugReturnActionDetail>(data.Row.TTObject);
            if (drugReturnActionDetails.SendAmount != null) {
                if (drugReturnActionDetails.SendAmount === 0) {
                    ServiceLocator.MessageService.showError(i18n("M19032", "Miktar 0 olamaz."));
                    for (let sendAmountGrid of this.drugReturnActionNewFormViewModel._DrugReturnAction.DrugReturnActionDetails) {
                        if (sendAmountGrid === drugReturnActionDetails) {
                            drugReturnActionDetails.SendAmount = sendAmountGrid.Amount;
                        }
                    }

                }
                if (drugReturnActionDetails.SendAmount > drugReturnActionDetails.Amount) {
                    ServiceLocator.MessageService.showError(i18n("M15497", "Hastanın Üzerindeki ilaçdan fazla ilaç iade edilmez."));
                    for (let sendAmountGrid of this.drugReturnActionNewFormViewModel._DrugReturnAction.DrugReturnActionDetails) {
                        if (sendAmountGrid === drugReturnActionDetails) {
                            drugReturnActionDetails.SendAmount = sendAmountGrid.Amount;
                        }
                    }
                }
            }
        }
    }

    async onDrugReturnActionDetailsCellContentClicked(data: any) {
        if (data.Column.Name === 'buttonDeleteDrugOrder') {
            let drugReturnActionDetails: DrugReturnActionDetail = <DrugReturnActionDetail>(data.Row.TTObject);
            for (let deleteDrugReturnActionDetail of this.drugReturnActionNewFormViewModel._DrugReturnAction.DrugReturnActionDetails) {
                if (deleteDrugReturnActionDetail.DrugOrderTransaction === drugReturnActionDetails.DrugOrderTransaction) {
                    const deleteDrugOrderFilter = this.drugReturnActionNewFormViewModel._DrugReturnAction.DrugReturnActionDetails.filter(item => item !== deleteDrugReturnActionDetail);
                    this.drugReturnActionNewFormViewModel._DrugReturnAction.DrugReturnActionDetails = deleteDrugOrderFilter;
                }
            }

            for (let deleteDrugReturnActionDetailGrid of this.drugReturnActionNewFormViewModel.DrugReturnActionDetailsGridList) {
                if (deleteDrugReturnActionDetailGrid.DrugOrderTransaction === drugReturnActionDetails.DrugOrderTransaction) {
                    const deleteDrugOrderFilter = this.drugReturnActionNewFormViewModel.DrugReturnActionDetailsGridList.filter(item => item !== deleteDrugReturnActionDetailGrid);
                    this.drugReturnActionNewFormViewModel.DrugReturnActionDetailsGridList = deleteDrugOrderFilter;
                }
            }
        }
    }


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DrugReturnAction();
        this.drugReturnActionNewFormViewModel = new DrugReturnActionNewFormViewModel();
        this._ViewModel = this.drugReturnActionNewFormViewModel;
        this.drugReturnActionNewFormViewModel._DrugReturnAction = this._TTObject as DrugReturnAction;
        this.drugReturnActionNewFormViewModel._DrugReturnAction.PharmacyStoreDefinition = new PharmacyStoreDefinition();
        this.drugReturnActionNewFormViewModel._DrugReturnAction.DrugReturnActionDetails = new Array<DrugReturnActionDetail>();
        this.drugReturnActionNewFormViewModel._DrugReturnAction.Episode = new Episode();
        this.drugReturnActionNewFormViewModel._DrugReturnAction.Episode.Patient = new Patient();
    }

    protected loadViewModel() {
        let that = this;

        that.drugReturnActionNewFormViewModel = this._ViewModel as DrugReturnActionNewFormViewModel;
        that._TTObject = this.drugReturnActionNewFormViewModel._DrugReturnAction;
        if (this.drugReturnActionNewFormViewModel == null)
            this.drugReturnActionNewFormViewModel = new DrugReturnActionNewFormViewModel();
        if (this.drugReturnActionNewFormViewModel._DrugReturnAction == null)
            this.drugReturnActionNewFormViewModel._DrugReturnAction = new DrugReturnAction();
        let pharmacyStoreDefinitionObjectID = that.drugReturnActionNewFormViewModel._DrugReturnAction['PharmacyStoreDefinition'];
        if (pharmacyStoreDefinitionObjectID != null && (typeof pharmacyStoreDefinitionObjectID === 'string')) {
            let pharmacyStoreDefinition = that.drugReturnActionNewFormViewModel.PharmacyStoreDefinitions.find(o => o.ObjectID.toString() === pharmacyStoreDefinitionObjectID.toString());
             if (pharmacyStoreDefinition) {
                that.drugReturnActionNewFormViewModel._DrugReturnAction.PharmacyStoreDefinition = pharmacyStoreDefinition;
            }
        }
        that.drugReturnActionNewFormViewModel._DrugReturnAction.DrugReturnActionDetails = that.drugReturnActionNewFormViewModel.DrugReturnActionDetailsGridList;
        for (let detailItem of that.drugReturnActionNewFormViewModel.DrugReturnActionDetailsGridList) {
            let drugOrderTransactionObjectID = detailItem['DrugOrderTransaction'];
            if (drugOrderTransactionObjectID != null && (typeof drugOrderTransactionObjectID === 'string')) {
                let drugOrderTransaction = that.drugReturnActionNewFormViewModel.DrugOrderTransactions.find(o => o.ObjectID.toString() === drugOrderTransactionObjectID.toString());
                 if (drugOrderTransaction) {
                    detailItem.DrugOrderTransaction = drugOrderTransaction;
                }
                if (drugOrderTransaction != null) {
                    let drugOrderObjectID = drugOrderTransaction['DrugOrder'];
                    if (drugOrderObjectID != null && (typeof drugOrderObjectID === 'string')) {
                        let drugOrder = that.drugReturnActionNewFormViewModel.DrugOrders.find(o => o.ObjectID.toString() === drugOrderObjectID.toString());
                         if (drugOrder) {
                            drugOrderTransaction.DrugOrder = drugOrder;
                        }
                        if (drugOrder != null) {
                            let materialObjectID = drugOrder['Material'];
                            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                                let material = that.drugReturnActionNewFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                                 if (material) {
                                    drugOrder.Material = material;
                                }
                            }
                        }
                    }
                }
            }
        }
        let episodeObjectID = that.drugReturnActionNewFormViewModel._DrugReturnAction['Episode'];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.drugReturnActionNewFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.drugReturnActionNewFormViewModel._DrugReturnAction.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode['Patient'];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.drugReturnActionNewFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                     if (patient) {
                        episode.Patient = patient;
                    }
                }
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(DrugReturnActionNewFormViewModel);
        this.FormCaption = i18n("M15036", "İlaç İade Belgesi( Yeni )");

    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._DrugReturnAction != null && this._DrugReturnAction.ActionDate !== event) {
                this._DrugReturnAction.ActionDate = event;
            }
        }
    }

    public onIDChanged(event): void {
        if (event != null) {
            if (this._DrugReturnAction != null && this._DrugReturnAction.ID !== event) {
                this._DrugReturnAction.ID = event;
            }
        }
    }

    public onPharmacyStoreDefinitionChanged(event): void {
        if (event != null) {
            if (this._DrugReturnAction != null && this._DrugReturnAction.PharmacyStoreDefinition !== event) {
                this._DrugReturnAction.PharmacyStoreDefinition = event;
            }
        }
    }

    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._DrugReturnAction != null &&
                this._DrugReturnAction.Episode != null &&
                this._DrugReturnAction.Episode.Patient != null && this._DrugReturnAction.Episode.Patient.FullName !== event) {
                this._DrugReturnAction.Episode.Patient.FullName = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ID, 'Text', this.__ttObject, 'ID');
        redirectProperty(this.ActionDate, 'Value', this.__ttObject, 'ActionDate');
        redirectProperty(this.tttextbox1, 'Text', this.__ttObject, 'Episode.Patient.FullName');
    }

    public initFormControls(): void {
        this.labelPharmacyStoreDefinition = new TTVisual.TTLabel();
        this.labelPharmacyStoreDefinition.Text = i18n("M13452", "Eczane");
        this.labelPharmacyStoreDefinition.Name = 'labelPharmacyStoreDefinition';
        this.labelPharmacyStoreDefinition.TabIndex = 14;

        this.PharmacyStoreDefinition = new TTVisual.TTObjectListBox();
        this.PharmacyStoreDefinition.Required = true;
        this.PharmacyStoreDefinition.ListDefName = 'StoresList';
        this.PharmacyStoreDefinition.Name = 'PharmacyStoreDefinition';
        this.PharmacyStoreDefinition.TabIndex = 13;

        this.DrugReturnActionDetails = new TTVisual.TTGrid();
        this.DrugReturnActionDetails.ReadOnly = true;
        this.DrugReturnActionDetails.Name = 'DrugReturnActionDetails';
        this.DrugReturnActionDetails.TabIndex = 12;
        this.DrugReturnActionDetails.AllowUserToAddRows = false;
        this.DrugReturnActionDetails.Height = 350;
        this.DrugReturnActionDetails.AllowUserToDeleteRows = false;


        this.DrugOrderTransactionDrugReturnActionDetail = new TTVisual.TTListBoxColumn();
        this.DrugOrderTransactionDrugReturnActionDetail.ListDefName = 'DrugList';
        this.DrugOrderTransactionDrugReturnActionDetail.DataMember = 'DrugOrderTransaction.DrugOrder.Material';
        this.DrugOrderTransactionDrugReturnActionDetail.ReadOnly = true;
        this.DrugOrderTransactionDrugReturnActionDetail.DisplayIndex = 0;
        this.DrugOrderTransactionDrugReturnActionDetail.HeaderText = i18n("M16287", "İlaç");
        this.DrugOrderTransactionDrugReturnActionDetail.Name = 'DrugOrderTransactionDrugReturnActionDetail';
        this.DrugOrderTransactionDrugReturnActionDetail.Width = 400;

        this.AmountDrugReturnActionDetail = new TTVisual.TTTextBoxColumn();
        this.AmountDrugReturnActionDetail.DataMember = 'Amount';
        this.AmountDrugReturnActionDetail.ReadOnly = true;
        this.AmountDrugReturnActionDetail.DisplayIndex = 1;
        this.AmountDrugReturnActionDetail.HeaderText = i18n("M19030", "Miktar");
        this.AmountDrugReturnActionDetail.Name = 'AmountDrugReturnActionDetail';
        this.AmountDrugReturnActionDetail.Width = 80;


        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = '#F0F0F0';
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = 'ActionDate';
        this.ActionDate.TabIndex = 5;

        this.labelID = new TTVisual.TTLabel();
        this.labelID.Text = i18n("M16866", "İşlem No");
        this.labelID.Name = 'labelID';
        this.labelID.TabIndex = 10;

        this.ID = new TTVisual.TTTextBox();
        this.ID.BackColor = '#F0F0F0';
        this.ID.ReadOnly = true;
        this.ID.Name = 'ID';
        this.ID.TabIndex = 9;

        this.DrugReturnReason = new TTVisual.TTTextBox();
        this.DrugReturnReason.Name = 'DrugReturnReason';
        this.DrugReturnReason.TabIndex = 9;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.BackColor = '#F0F0F0';
        this.tttextbox1.ReadOnly = true;
        this.tttextbox1.Name = 'tttextbox1';
        this.tttextbox1.TabIndex = 11;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelActionDate.Name = 'labelActionDate';
        this.labelActionDate.TabIndex = 6;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M15133", "Hasta Adı Soyadı");
        this.ttlabel1.Name = 'ttlabel1';
        this.ttlabel1.TabIndex = 6;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M16389", "İlaçlar");
        this.ttlabel2.Name = 'ttlabel2';
        this.ttlabel2.TabIndex = 10;

        this.SendAmount = new TTVisual.TTTextBoxColumn();
        this.SendAmount.DataMember = 'SendAmount';
        this.SendAmount.DisplayIndex = 1;
        this.SendAmount.HeaderText = i18n("M19699", "Onaylanan Mİktar");
        this.SendAmount.Name = 'SendAmount';
        this.SendAmount.ReadOnly = false;
        this.SendAmount.Width = 80;


        this.buttonDeleteDrugOrder = new TTVisual.TTButtonColumn();
        this.buttonDeleteDrugOrder.Text = 'Sil';
        this.buttonDeleteDrugOrder.Name = 'buttonDeleteDrugOrder';
        this.buttonDeleteDrugOrder.DisplayIndex = 0;
        this.buttonDeleteDrugOrder.Width = 50;

        this.DrugReturnActionDetailsColumns = [this.DrugOrderTransactionDrugReturnActionDetail, this.AmountDrugReturnActionDetail, this.SendAmount, this.buttonDeleteDrugOrder];
        this.Controls = [this.labelPharmacyStoreDefinition, this.PharmacyStoreDefinition, this.DrugReturnActionDetails, this.DrugOrderTransactionDrugReturnActionDetail,
        this.AmountDrugReturnActionDetail, this.ActionDate, this.labelID, this.ID, this.DrugReturnReason, this.tttextbox1, this.labelActionDate, this.ttlabel1,
        this.ttlabel2];

    }


}
