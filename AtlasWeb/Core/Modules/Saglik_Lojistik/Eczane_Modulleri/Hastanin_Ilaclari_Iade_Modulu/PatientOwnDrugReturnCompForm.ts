//$B7EBAD61
import { Component,  OnInit, ApplicationRef } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { PatientOwnDrugReturnCompFormViewModel } from './PatientOwnDrugReturnCompFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PatientOwnDrugReturn } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { PatientOwnDrugReturnDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'PatientOwnDrugReturnCompForm',
    templateUrl: './PatientOwnDrugReturnCompForm.html',
    providers: [MessageService]
})
export class PatientOwnDrugReturnCompForm extends TTVisual.TTForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    AmountPatientOwnDrugReturnDetail: TTVisual.ITTTextBoxColumn;
    ID: TTVisual.ITTTextBox;
    labelActionDate: TTVisual.ITTLabel;
    labelID: TTVisual.ITTLabel;
    MaterialPatientOwnDrugReturnDetail: TTVisual.ITTListBoxColumn;
    PatientOwnDrugReturnDetails: TTVisual.ITTGrid;
    public PatientOwnDrugReturnDetailsColumns = [];
    public patientOwnDrugReturnCompFormViewModel: PatientOwnDrugReturnCompFormViewModel = new PatientOwnDrugReturnCompFormViewModel();
    public get _PatientOwnDrugReturn(): PatientOwnDrugReturn {
        return this._TTObject as PatientOwnDrugReturn;
    }
    private PatientOwnDrugReturnCompForm_DocumentUrl: string = '/api/PatientOwnDrugReturnService/PatientOwnDrugReturnCompForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('PATIENTOWNDRUGRETURN', 'PatientOwnDrugReturnCompForm');
        this._DocumentServiceUrl = this.PatientOwnDrugReturnCompForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PatientOwnDrugReturn();
        this.patientOwnDrugReturnCompFormViewModel = new PatientOwnDrugReturnCompFormViewModel();
        this._ViewModel = this.patientOwnDrugReturnCompFormViewModel;
        this.patientOwnDrugReturnCompFormViewModel._PatientOwnDrugReturn = this._TTObject as PatientOwnDrugReturn;
        this.patientOwnDrugReturnCompFormViewModel._PatientOwnDrugReturn.PatientOwnDrugReturnDetails = new Array<PatientOwnDrugReturnDetail>();
    }

    protected loadViewModel() {
        let that = this;
        that.patientOwnDrugReturnCompFormViewModel = this._ViewModel as PatientOwnDrugReturnCompFormViewModel;
        that._TTObject = this.patientOwnDrugReturnCompFormViewModel._PatientOwnDrugReturn;
        if (this.patientOwnDrugReturnCompFormViewModel == null)
            this.patientOwnDrugReturnCompFormViewModel = new PatientOwnDrugReturnCompFormViewModel();
        if (this.patientOwnDrugReturnCompFormViewModel._PatientOwnDrugReturn == null)
            this.patientOwnDrugReturnCompFormViewModel._PatientOwnDrugReturn = new PatientOwnDrugReturn();
        that.patientOwnDrugReturnCompFormViewModel._PatientOwnDrugReturn.PatientOwnDrugReturnDetails = that.patientOwnDrugReturnCompFormViewModel.PatientOwnDrugReturnDetailsGridList;
        for (let detailItem of that.patientOwnDrugReturnCompFormViewModel.PatientOwnDrugReturnDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.patientOwnDrugReturnCompFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }

        }
    }

    async ngOnInit() {
        await this.load();
    }

    public onActionDateChanged(event): void {
        if (this._PatientOwnDrugReturn != null && this._PatientOwnDrugReturn.ActionDate !== event) {
            this._PatientOwnDrugReturn.ActionDate = event;
        }
    }

    public onIDChanged(event): void {
        if (this._PatientOwnDrugReturn != null && this._PatientOwnDrugReturn.ID !== event) {
            this._PatientOwnDrugReturn.ID = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ID, "Text", this.__ttObject, "ID");
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
    }

    public initFormControls(): void {
        this.PatientOwnDrugReturnDetails = new TTVisual.TTGrid();
        this.PatientOwnDrugReturnDetails.Name = "PatientOwnDrugReturnDetails";
        this.PatientOwnDrugReturnDetails.TabIndex = 4;

        this.MaterialPatientOwnDrugReturnDetail = new TTVisual.TTListBoxColumn();
        this.MaterialPatientOwnDrugReturnDetail.ListDefName = "MaterialListDefinition";
        this.MaterialPatientOwnDrugReturnDetail.DataMember = "Material";
        this.MaterialPatientOwnDrugReturnDetail.DisplayIndex = 0;
        this.MaterialPatientOwnDrugReturnDetail.HeaderText = "İlaç";
        this.MaterialPatientOwnDrugReturnDetail.Name = "MaterialPatientOwnDrugReturnDetail";
        this.MaterialPatientOwnDrugReturnDetail.ReadOnly = true;
        this.MaterialPatientOwnDrugReturnDetail.Width = 300;

        this.AmountPatientOwnDrugReturnDetail = new TTVisual.TTTextBoxColumn();
        this.AmountPatientOwnDrugReturnDetail.DataMember = "Amount";
        this.AmountPatientOwnDrugReturnDetail.DisplayIndex = 1;
        this.AmountPatientOwnDrugReturnDetail.HeaderText = "Miktar";
        this.AmountPatientOwnDrugReturnDetail.Name = "AmountPatientOwnDrugReturnDetail";
        this.AmountPatientOwnDrugReturnDetail.ReadOnly = true;
        this.AmountPatientOwnDrugReturnDetail.Width = 80;

        this.labelID = new TTVisual.TTLabel();
        this.labelID.Text = "İşlem Nu.";
        this.labelID.Name = "labelID";
        this.labelID.TabIndex = 3;

        this.ID = new TTVisual.TTTextBox();
        this.ID.BackColor = "#F0F0F0";
        this.ID.ReadOnly = true;
        this.ID.Name = "ID";
        this.ID.TabIndex = 2;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = "İşlem Tarihi";
        this.labelActionDate.Name = "labelActionDate";
        this.labelActionDate.TabIndex = 1;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 0;

        this.PatientOwnDrugReturnDetailsColumns = [this.MaterialPatientOwnDrugReturnDetail, this.AmountPatientOwnDrugReturnDetail];
        this.Controls = [this.PatientOwnDrugReturnDetails, this.MaterialPatientOwnDrugReturnDetail, this.AmountPatientOwnDrugReturnDetail, this.labelID, this.ID, this.labelActionDate, this.ActionDate];

    }


}
