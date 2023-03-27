//$CCE3A76F
import { Component, ViewChild, OnInit, ApplicationRef } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { HalfDoseDestructionFormViewModel } from './HalfDoseDestructionFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { HalfDoseDestruction } from 'NebulaClient/Model/AtlasClientModel';
import { HalfDoseDestructionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { UnitDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { FormSaveInfo } from 'app/NebulaClient/Mscorlib/FormSaveInfo';

@Component({
    selector: 'HalfDoseDestructionForm',
    templateUrl: './HalfDoseDestructionForm.html',
    providers: [MessageService]
})
export class HalfDoseDestructionForm extends TTVisual.TTForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    AmountHalfDoseDestructionDetail: TTVisual.ITTTextBoxColumn;
    DrugNameHalfDoseDestructionDetail: TTVisual.ITTTextBoxColumn;
    EndDate: TTVisual.ITTDateTimePicker;
    HalfDoseDestructionDetails: TTVisual.ITTGrid;
    ID: TTVisual.ITTTextBox;
    labelActionDate: TTVisual.ITTLabel;
    labelEndDate: TTVisual.ITTLabel;
    labelID: TTVisual.ITTLabel;
    labelPharmacyStoreDefinition: TTVisual.ITTLabel;
    labelProcedureByUser: TTVisual.ITTLabel;
    labelStartDate: TTVisual.ITTLabel;
    PharmacyStoreDefinition: TTVisual.ITTObjectListBox;
    ProcedureByUser: TTVisual.ITTObjectListBox;
    StartDate: TTVisual.ITTDateTimePicker;
    UnitDefinitionHalfDoseDestructionDetail: TTVisual.ITTListBoxColumn;
    public HalfDoseDestructionDetailsColumns = [];
    public halfDoseDestructionFormViewModel: HalfDoseDestructionFormViewModel = new HalfDoseDestructionFormViewModel();
    public get _HalfDoseDestruction(): HalfDoseDestruction {
        return this._TTObject as HalfDoseDestruction;
    }
    private HalfDoseDestructionForm_DocumentUrl: string = '/api/HalfDoseDestructionService/HalfDoseDestructionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('HALFDOSEDESTRUCTION', 'HalfDoseDestructionForm');
        this._DocumentServiceUrl = this.HalfDoseDestructionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new HalfDoseDestruction();
        this.halfDoseDestructionFormViewModel = new HalfDoseDestructionFormViewModel();
        this._ViewModel = this.halfDoseDestructionFormViewModel;
        this.halfDoseDestructionFormViewModel._HalfDoseDestruction = this._TTObject as HalfDoseDestruction;
        this.halfDoseDestructionFormViewModel._HalfDoseDestruction.ProcedureByUser = new ResUser();
        this.halfDoseDestructionFormViewModel._HalfDoseDestruction.PharmacyStoreDefinition = new Store();
        this.halfDoseDestructionFormViewModel._HalfDoseDestruction.HalfDoseDestructionDetails = new Array<HalfDoseDestructionDetail>();
    }

    protected loadViewModel() {
        let that = this;
        that.halfDoseDestructionFormViewModel = this._ViewModel as HalfDoseDestructionFormViewModel;
        that._TTObject = this.halfDoseDestructionFormViewModel._HalfDoseDestruction;
        if (this.halfDoseDestructionFormViewModel == null)
            this.halfDoseDestructionFormViewModel = new HalfDoseDestructionFormViewModel();
        if (this.halfDoseDestructionFormViewModel._HalfDoseDestruction == null)
            this.halfDoseDestructionFormViewModel._HalfDoseDestruction = new HalfDoseDestruction();
        let procedureByUserObjectID = that.halfDoseDestructionFormViewModel._HalfDoseDestruction["ProcedureByUser"];
        if (procedureByUserObjectID != null && (typeof procedureByUserObjectID === "string")) {
            let procedureByUser = that.halfDoseDestructionFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureByUserObjectID.toString());
            if (procedureByUser) {
                that.halfDoseDestructionFormViewModel._HalfDoseDestruction.ProcedureByUser = procedureByUser;
            }
        }


        let pharmacyStoreDefinitionObjectID = that.halfDoseDestructionFormViewModel._HalfDoseDestruction["PharmacyStoreDefinition"];
        if (pharmacyStoreDefinitionObjectID != null && (typeof pharmacyStoreDefinitionObjectID === "string")) {
            let pharmacyStoreDefinition = that.halfDoseDestructionFormViewModel.Stores.find(o => o.ObjectID.toString() === pharmacyStoreDefinitionObjectID.toString());
            if (pharmacyStoreDefinition) {
                that.halfDoseDestructionFormViewModel._HalfDoseDestruction.PharmacyStoreDefinition = pharmacyStoreDefinition;
            }
        }

        that.halfDoseDestructionFormViewModel._HalfDoseDestruction.HalfDoseDestructionDetails = that.halfDoseDestructionFormViewModel.HalfDoseDestructionDetailsGridList;
        for (let detailItem of that.halfDoseDestructionFormViewModel.HalfDoseDestructionDetailsGridList) {
            let unitDefinitionObjectID = detailItem["UnitDefinition"];
            if (unitDefinitionObjectID != null && (typeof unitDefinitionObjectID === "string")) {
                let unitDefinition = that.halfDoseDestructionFormViewModel.UnitDefinitions.find(o => o.ObjectID.toString() === unitDefinitionObjectID.toString());
                if (unitDefinition) {
                    detailItem.UnitDefinition = unitDefinition;
                }
            }
        }
    }



    async ngOnInit() {
        let that = this;
        await this.load(HalfDoseDestructionFormViewModel);
        this.FormCaption = "Yarım Doz İmha";
    }

    public async stateChange(event: FormSaveInfo) {
        await super.setState(event.transDef, event);
    }

    public onActionDateChanged(event): void {
        if (this._HalfDoseDestruction != null && this._HalfDoseDestruction.ActionDate != event) {
            this._HalfDoseDestruction.ActionDate = event;
        }
    }

    public onEndDateChanged(event): void {
        if (this._HalfDoseDestruction != null && this._HalfDoseDestruction.EndDate != event) {
            this._HalfDoseDestruction.EndDate = event;
        }
    }

    public onIDChanged(event): void {
        if (this._HalfDoseDestruction != null && this._HalfDoseDestruction.ID != event) {
            this._HalfDoseDestruction.ID = event;
        }
    }

    public onPharmacyStoreDefinitionChanged(event): void {
        if (this._HalfDoseDestruction != null && this._HalfDoseDestruction.PharmacyStoreDefinition != event) {
            this._HalfDoseDestruction.PharmacyStoreDefinition = event;
        }
    }

    public onProcedureByUserChanged(event): void {
        if (this._HalfDoseDestruction != null && this._HalfDoseDestruction.ProcedureByUser != event) {
            this._HalfDoseDestruction.ProcedureByUser = event;
        }
    }

    public onStartDateChanged(event): void {
        if (this._HalfDoseDestruction != null && this._HalfDoseDestruction.StartDate != event) {
            this._HalfDoseDestruction.StartDate = event;
        }
    }



    public redirectProperties(): void {
        redirectProperty(this.ID, "Text", this.__ttObject, "ID");
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.StartDate, "Value", this.__ttObject, "StartDate");
        redirectProperty(this.EndDate, "Value", this.__ttObject, "EndDate");
    }

    public initFormControls(): void {
        this.labelEndDate = new TTVisual.TTLabel();
        this.labelEndDate.Text = "Bitiş Tarihi";
        this.labelEndDate.Name = "labelEndDate";
        this.labelEndDate.TabIndex = 12;

        this.EndDate = new TTVisual.TTDateTimePicker();
        this.EndDate.Format = DateTimePickerFormat.Long;
        this.EndDate.Name = "EndDate";
        this.EndDate.TabIndex = 11;
        this.EndDate.ReadOnly = true;

        this.labelStartDate = new TTVisual.TTLabel();
        this.labelStartDate.Text = "Başlanguç Tarihi";
        this.labelStartDate.Name = "labelStartDate";
        this.labelStartDate.TabIndex = 10;

        this.StartDate = new TTVisual.TTDateTimePicker();
        this.StartDate.Format = DateTimePickerFormat.Long;
        this.StartDate.Name = "StartDate";
        this.StartDate.TabIndex = 9;
        this.StartDate.ReadOnly = true;

        this.labelProcedureByUser = new TTVisual.TTLabel();
        this.labelProcedureByUser.Text = "İstek Yapan";
        this.labelProcedureByUser.Name = "labelProcedureByUser";
        this.labelProcedureByUser.TabIndex = 8;

        this.ProcedureByUser = new TTVisual.TTObjectListBox();
        this.ProcedureByUser.ListDefName = "ResUserDefinitionList";
        this.ProcedureByUser.Name = "ProcedureByUser";
        this.ProcedureByUser.TabIndex = 7;
        this.ProcedureByUser.ReadOnly = true;

        this.labelPharmacyStoreDefinition = new TTVisual.TTLabel();
        this.labelPharmacyStoreDefinition.Text = "Eczane";
        this.labelPharmacyStoreDefinition.Name = "labelPharmacyStoreDefinition";
        this.labelPharmacyStoreDefinition.TabIndex = 6;

        this.PharmacyStoreDefinition = new TTVisual.TTObjectListBox();
        this.PharmacyStoreDefinition.ListDefName = "StoresList";
        this.PharmacyStoreDefinition.Name = "PharmacyStoreDefinition";
        this.PharmacyStoreDefinition.TabIndex = 5;
        this.PharmacyStoreDefinition.ReadOnly = true;

        this.HalfDoseDestructionDetails = new TTVisual.TTGrid();
        this.HalfDoseDestructionDetails.Name = "HalfDoseDestructionDetails";
        this.HalfDoseDestructionDetails.TabIndex = 4;
        this.HalfDoseDestructionDetails.AllowUserToAddRows = false;
        this.HalfDoseDestructionDetails.AllowUserToDeleteRows = false;

        this.DrugNameHalfDoseDestructionDetail = new TTVisual.TTTextBoxColumn();
        this.DrugNameHalfDoseDestructionDetail.DataMember = "DrugName";
        this.DrugNameHalfDoseDestructionDetail.DisplayIndex = 0;
        this.DrugNameHalfDoseDestructionDetail.HeaderText = "İlaç";
        this.DrugNameHalfDoseDestructionDetail.Name = "DrugNameHalfDoseDestructionDetail";
        this.DrugNameHalfDoseDestructionDetail.Width = 500;
        this.DrugNameHalfDoseDestructionDetail.ReadOnly = true;

        this.AmountHalfDoseDestructionDetail = new TTVisual.TTTextBoxColumn();
        this.AmountHalfDoseDestructionDetail.DataMember = "Amount";
        this.AmountHalfDoseDestructionDetail.DisplayIndex = 1;
        this.AmountHalfDoseDestructionDetail.HeaderText = "Miktar";
        this.AmountHalfDoseDestructionDetail.Name = "AmountHalfDoseDestructionDetail";
        this.AmountHalfDoseDestructionDetail.Width = 100;
        this.AmountHalfDoseDestructionDetail.ReadOnly = true;

        this.UnitDefinitionHalfDoseDestructionDetail = new TTVisual.TTListBoxColumn();
        this.UnitDefinitionHalfDoseDestructionDetail.ListDefName = "UnitListDefinition";
        this.UnitDefinitionHalfDoseDestructionDetail.DataMember = "UnitDefinition";
        this.UnitDefinitionHalfDoseDestructionDetail.DisplayIndex = 2;
        this.UnitDefinitionHalfDoseDestructionDetail.HeaderText = "Birim";
        this.UnitDefinitionHalfDoseDestructionDetail.Name = "UnitDefinitionHalfDoseDestructionDetail";
        this.UnitDefinitionHalfDoseDestructionDetail.Width = 100;
        this.UnitDefinitionHalfDoseDestructionDetail.ReadOnly = true;

        this.labelID = new TTVisual.TTLabel();
        this.labelID.Text = "İşlem Nu.";
        this.labelID.Name = "labelID";
        this.labelID.TabIndex = 3;

        this.ID = new TTVisual.TTTextBox();
        this.ID.Name = "ID";
        this.ID.TabIndex = 2;
        this.ID.ReadOnly = true;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = "İşlem Tarihi";
        this.labelActionDate.Name = "labelActionDate";
        this.labelActionDate.TabIndex = 1;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 0;
        this.ActionDate.ReadOnly = true;

        this.HalfDoseDestructionDetailsColumns = [this.DrugNameHalfDoseDestructionDetail, this.AmountHalfDoseDestructionDetail, this.UnitDefinitionHalfDoseDestructionDetail];
        this.Controls = [this.labelEndDate, this.EndDate, this.labelStartDate, this.StartDate, this.labelProcedureByUser, this.ProcedureByUser, this.labelPharmacyStoreDefinition, this.PharmacyStoreDefinition, this.HalfDoseDestructionDetails, this.DrugNameHalfDoseDestructionDetail, this.AmountHalfDoseDestructionDetail, this.UnitDefinitionHalfDoseDestructionDetail, this.labelID, this.ID, this.labelActionDate, this.ActionDate];

    }


}
