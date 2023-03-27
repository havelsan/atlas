//$B8EE16CA
import { Component, OnInit, NgZone } from '@angular/core';
import { DrugReturnActionApprovalFormViewModel } from './DrugReturnActionApprovalFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { DrugReturnAction } from 'NebulaClient/Model/AtlasClientModel';
import { DrugReturnActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { PharmacyStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';


@Component({
    selector: 'DrugReturnActionApprovalForm',
    templateUrl: './DrugReturnActionApprovalForm.html',
    providers: [MessageService]
})
export class DrugReturnActionApprovalForm extends TTVisual.TTForm implements OnInit {
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
    SendAmount: TTVisual.ITTTextBoxColumn;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    tttextbox1: TTVisual.ITTTextBox;
    public DrugReturnActionDetailsColumns = [];
    public drugReturnActionApprovalFormViewModel: DrugReturnActionApprovalFormViewModel = new DrugReturnActionApprovalFormViewModel();
    public get _DrugReturnAction(): DrugReturnAction {
        return this._TTObject as DrugReturnAction;
    }
    private DrugReturnActionApprovalForm_DocumentUrl: string = '/api/DrugReturnActionService/DrugReturnActionApprovalForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                private objectContextService: ObjectContextService,
                protected ngZone: NgZone) {
        super('DRUGRETURNACTION', 'DrugReturnActionApprovalForm');
        this._DocumentServiceUrl = this.DrugReturnActionApprovalForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    protected async PreScript() {
        super.PreScript();
        for (let sendAmountGrid of this.drugReturnActionApprovalFormViewModel._DrugReturnAction.DrugReturnActionDetails) {
            sendAmountGrid.Amount = sendAmountGrid.SendAmount;
        }
    }

    initDrugReturnActionDetailsNewRow(data: any) { }
    onDrugReturnActionDetailsRowInserting(data: any) { }
    onSelectionChangeDrugReturnActionDetails(data: any) { }
    async DrugReturnActionDetails_CellValueChangedEmitted(data: any) {
        if (data.Column.Name === 'AmountDrugReturnActionDetail') {
            let drugReturnActionDetails: DrugReturnActionDetail = <DrugReturnActionDetail>(data.Row.TTObject);
            if (drugReturnActionDetails.SendAmount != null){
                /*if (drugReturnActionDetails.Amount == 0)
                {
                    ServiceLocator.MessageService.showError(i18n("M19032", "Miktar 0 olamaz."));
                    for (let sendAmountGrid of this.drugReturnActionApprovalFormViewModel._DrugReturnAction.DrugReturnActionDetails) {
                        if (sendAmountGrid == drugReturnActionDetails)
                        {
                            drugReturnActionDetails.Amount = sendAmountGrid.SendAmount;
                        }
                    }

                }*/
                if (drugReturnActionDetails.Amount > drugReturnActionDetails.SendAmount)
                {
                    ServiceLocator.MessageService.showError(i18n("M15497", "Hastanın Üzerindeki ilaçdan fazla ilaç iade edilmez."));
                    for (let sendAmountGrid of this.drugReturnActionApprovalFormViewModel._DrugReturnAction.DrugReturnActionDetails) {
                        if (sendAmountGrid == drugReturnActionDetails)
                        {
                            drugReturnActionDetails.Amount = sendAmountGrid.SendAmount;
                        }
                    }
                }
            }
        }
    }

    onDrugReturnActionDetailsCellContentClicked(data: any){}
    GridDiagnosisGridList;
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DrugReturnAction();
        this.drugReturnActionApprovalFormViewModel = new DrugReturnActionApprovalFormViewModel();
        this._ViewModel = this.drugReturnActionApprovalFormViewModel;
        this.drugReturnActionApprovalFormViewModel._DrugReturnAction = this._TTObject as DrugReturnAction;
        this.drugReturnActionApprovalFormViewModel._DrugReturnAction.DrugReturnActionDetails = new Array<DrugReturnActionDetail>();
        this.drugReturnActionApprovalFormViewModel._DrugReturnAction.Episode = new Episode();
        this.drugReturnActionApprovalFormViewModel._DrugReturnAction.Episode.Patient = new Patient();
        this.drugReturnActionApprovalFormViewModel._DrugReturnAction.PharmacyStoreDefinition = new PharmacyStoreDefinition();
    }

    protected loadViewModel() {
        let that = this;

        that.drugReturnActionApprovalFormViewModel = this._ViewModel as DrugReturnActionApprovalFormViewModel;
        that._TTObject = this.drugReturnActionApprovalFormViewModel._DrugReturnAction;
        if (this.drugReturnActionApprovalFormViewModel == null)
            this.drugReturnActionApprovalFormViewModel = new DrugReturnActionApprovalFormViewModel();
        if (this.drugReturnActionApprovalFormViewModel._DrugReturnAction == null)
            this.drugReturnActionApprovalFormViewModel._DrugReturnAction = new DrugReturnAction();
        that.drugReturnActionApprovalFormViewModel._DrugReturnAction.DrugReturnActionDetails = that.drugReturnActionApprovalFormViewModel.DrugReturnActionDetailsGridList;
        for (let detailItem of that.drugReturnActionApprovalFormViewModel.DrugReturnActionDetailsGridList) {
            let drugOrderTransactionObjectID = detailItem["DrugOrderTransaction"];
            if (drugOrderTransactionObjectID != null && (typeof drugOrderTransactionObjectID === 'string')) {
                let drugOrderTransaction = that.drugReturnActionApprovalFormViewModel.DrugOrderTransactions.find(o => o.ObjectID.toString() === drugOrderTransactionObjectID.toString());
                 if (drugOrderTransaction) {
                    detailItem.DrugOrderTransaction = drugOrderTransaction;
                }
                if (drugOrderTransaction != null) {
                    let drugOrderObjectID = drugOrderTransaction["DrugOrder"];
                    if (drugOrderObjectID != null && (typeof drugOrderObjectID === 'string')) {
                        let drugOrder = that.drugReturnActionApprovalFormViewModel.DrugOrders.find(o => o.ObjectID.toString() === drugOrderObjectID.toString());
                         if (drugOrder) {
                            drugOrderTransaction.DrugOrder = drugOrder;
                        }
                        if (drugOrder != null) {
                            let materialObjectID = drugOrder["Material"];
                            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                                let material = that.drugReturnActionApprovalFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                                 if (material) {
                                    drugOrder.Material = material;
                                }
                            }
                        }
                    }
                }
            }
        }
        let episodeObjectID = that.drugReturnActionApprovalFormViewModel._DrugReturnAction["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.drugReturnActionApprovalFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.drugReturnActionApprovalFormViewModel._DrugReturnAction.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.drugReturnActionApprovalFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                     if (patient) {
                        episode.Patient = patient;
                    }
                }
            }
        }
        let pharmacyStoreDefinitionObjectID = that.drugReturnActionApprovalFormViewModel._DrugReturnAction["PharmacyStoreDefinition"];
        if (pharmacyStoreDefinitionObjectID != null && (typeof pharmacyStoreDefinitionObjectID === 'string')) {
            let pharmacyStoreDefinition = that.drugReturnActionApprovalFormViewModel.PharmacyStoreDefinitions.find(o => o.ObjectID.toString() === pharmacyStoreDefinitionObjectID.toString());
             if (pharmacyStoreDefinition) {
                that.drugReturnActionApprovalFormViewModel._DrugReturnAction.PharmacyStoreDefinition = pharmacyStoreDefinition;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(DrugReturnActionApprovalFormViewModel);
        this.FormCaption = i18n("M15036", "İlaç İade Belgesi ( Onay )");
  
    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._DrugReturnAction != null && this._DrugReturnAction.ActionDate != event) {
                this._DrugReturnAction.ActionDate = event;
            }
        }
    }

    public onIDChanged(event): void {
        if (event != null) {
            if (this._DrugReturnAction != null && this._DrugReturnAction.ID != event) {
                this._DrugReturnAction.ID = event;
            }
        }
    }

    public onPharmacyStoreDefinitionChanged(event): void {
        if (event != null) {
            if (this._DrugReturnAction != null && this._DrugReturnAction.PharmacyStoreDefinition != event) {
                this._DrugReturnAction.PharmacyStoreDefinition = event;
            }
        }
    }

    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._DrugReturnAction != null &&
                this._DrugReturnAction.Episode != null &&
                this._DrugReturnAction.Episode.Patient != null && this._DrugReturnAction.Episode.Patient.FullName != event) {
                this._DrugReturnAction.Episode.Patient.FullName = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ID, "Text", this.__ttObject, "ID");
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "Episode.Patient.FullName");
    }

    public initFormControls(): void {
        this.DrugReturnActionDetails = new TTVisual.TTGrid();
        this.DrugReturnActionDetails.ReadOnly = true;
        this.DrugReturnActionDetails.Name = "DrugReturnActionDetails";
        this.DrugReturnActionDetails.TabIndex = 12;
        this.DrugReturnActionDetails.AllowUserToAddRows = false;
        this.DrugReturnActionDetails.AllowUserToDeleteRows = false;

        this.DrugOrderTransactionDrugReturnActionDetail = new TTVisual.TTListBoxColumn();
        this.DrugOrderTransactionDrugReturnActionDetail.ListDefName = "DrugList";
        this.DrugOrderTransactionDrugReturnActionDetail.DataMember = "DrugOrderTransaction.DrugOrder.Material";
        this.DrugOrderTransactionDrugReturnActionDetail.DisplayIndex = 0;
        this.DrugOrderTransactionDrugReturnActionDetail.HeaderText = i18n("M16287", "İlaç");
        this.DrugOrderTransactionDrugReturnActionDetail.Name = "DrugOrderTransactionDrugReturnActionDetail";
        this.DrugOrderTransactionDrugReturnActionDetail.ReadOnly = true;
        this.DrugOrderTransactionDrugReturnActionDetail.Width = 400;

        this.SendAmount = new TTVisual.TTTextBoxColumn();
        this.SendAmount.DataMember = "SendAmount";
        this.SendAmount.DisplayIndex = 1;
        this.SendAmount.HeaderText = i18n("M16067", "İade Edilen Miktar");
        this.SendAmount.Name = "SendAmount";
        this.SendAmount.ReadOnly = true;
        this.SendAmount.Width = 100;

        this.AmountDrugReturnActionDetail = new TTVisual.TTTextBoxColumn();
        this.AmountDrugReturnActionDetail.DataMember = "Amount";
        this.AmountDrugReturnActionDetail.DisplayIndex = 2;
        this.AmountDrugReturnActionDetail.HeaderText = i18n("M17019", "Kabul Edilen Miktar");
        this.AmountDrugReturnActionDetail.Name = "AmountDrugReturnActionDetail";
        this.AmountDrugReturnActionDetail.ReadOnly = false;
        this.AmountDrugReturnActionDetail.Width = 200;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 5;

        this.labelID = new TTVisual.TTLabel();
        this.labelID.Text = i18n("M16866", "İşlem No");
        this.labelID.Name = "labelID";
        this.labelID.TabIndex = 10;

        this.ID = new TTVisual.TTTextBox();
        this.ID.BackColor = "#F0F0F0";
        this.ID.ReadOnly = true;
        this.ID.Name = "ID";
        this.ID.TabIndex = 9;

        this.DrugReturnReason = new TTVisual.TTTextBox();
        this.DrugReturnReason.Name = "DrugReturnReason";
        this.DrugReturnReason.TabIndex = 9;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.BackColor = "#F0F0F0";
        this.tttextbox1.ReadOnly = true;
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 11;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelActionDate.Name = "labelActionDate";
        this.labelActionDate.TabIndex = 6;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M15133", "Hasta Adı Soyadı");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 6;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M16389", "İlaçlar");
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 10;

        this.PharmacyStoreDefinition = new TTVisual.TTObjectListBox();
        this.PharmacyStoreDefinition.ReadOnly = true;
        this.PharmacyStoreDefinition.ListDefName = "StoresList";
        this.PharmacyStoreDefinition.Name = "PharmacyStoreDefinition";
        this.PharmacyStoreDefinition.TabIndex = 13;

        this.labelPharmacyStoreDefinition = new TTVisual.TTLabel();
        this.labelPharmacyStoreDefinition.Text = i18n("M13452", "Eczane");
        this.labelPharmacyStoreDefinition.Name = "labelPharmacyStoreDefinition";
        this.labelPharmacyStoreDefinition.TabIndex = 14;

        this.DrugReturnActionDetailsColumns = [this.DrugOrderTransactionDrugReturnActionDetail, this.SendAmount, this.AmountDrugReturnActionDetail];
        this.Controls = [this.DrugReturnActionDetails, this.DrugOrderTransactionDrugReturnActionDetail, this.SendAmount, this.AmountDrugReturnActionDetail, this.ActionDate, this.labelID, this.ID, this.DrugReturnReason, this.tttextbox1, this.labelActionDate, this.ttlabel1, this.ttlabel2, this.PharmacyStoreDefinition, this.labelPharmacyStoreDefinition];

    }


}
