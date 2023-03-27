//$7F9C0C2F
import { Component, ViewChild, OnInit, ApplicationRef } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { PatientOwnDrugReturnFormViewModel } from './PatientOwnDrugReturnFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PatientOwnDrugReturn, PatientOwnDrugTrx, Episode, Patient } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { PatientOwnDrugReturnDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ModalInfo } from 'Fw/Models/ModalInfo';
import { DrugReturnActionService } from 'ObjectClassService/DrugReturnActionService';

import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { ObjectContextService } from 'app/Fw/Services/ObjectContextService';

@Component({
    selector: 'PatientOwnDrugReturnForm',
    templateUrl: './PatientOwnDrugReturnForm.html',
    providers: [MessageService]
})
export class PatientOwnDrugReturnForm extends TTVisual.TTForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    AmountPatientOwnDrugReturnDetail: TTVisual.ITTTextBoxColumn;
    ID: TTVisual.ITTTextBox;
    labelActionDate: TTVisual.ITTLabel;
    labelID: TTVisual.ITTLabel;
    MaterialPatientOwnDrugReturnDetail: TTVisual.ITTListBoxColumn;
    PatientOwnDrugReturnDetails: TTVisual.ITTGrid;
    public PatientOwnDrugReturnDetailsColumns = [];
    public patientOwnDrugReturnFormViewModel: PatientOwnDrugReturnFormViewModel = new PatientOwnDrugReturnFormViewModel();
    public EpisodeID: Guid;
    public get _PatientOwnDrugReturn(): PatientOwnDrugReturn {
        return this._TTObject as PatientOwnDrugReturn;
    }
    private PatientOwnDrugReturnForm_DocumentUrl: string = '/api/PatientOwnDrugReturnService/PatientOwnDrugReturnForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, private objectContextService: ObjectContextService) {
        super('PATIENTOWNDRUGRETURN', 'PatientOwnDrugReturnForm');
        this._DocumentServiceUrl = this.PatientOwnDrugReturnForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    public async setInputParam(value: Object) {
        this._TTObject = value as PatientOwnDrugReturn;
        this.patientOwnDrugReturnFormViewModel = new PatientOwnDrugReturnFormViewModel();
        this._ViewModel = this.patientOwnDrugReturnFormViewModel;
        this.patientOwnDrugReturnFormViewModel._PatientOwnDrugReturn = value as PatientOwnDrugReturn;
        this.EpisodeID = this.patientOwnDrugReturnFormViewModel._PatientOwnDrugReturn.Episode.ObjectID;
    }

    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    protected isLoadViewModel(): boolean {
        return false;
    }
    
    protected async PreScript() {
        super.PreScript();
        this.patientOwnDrugReturnFormViewModel.PatientOwnDrugReturnDetailsGridList = new Array<PatientOwnDrugReturnDetail>();
        this._PatientOwnDrugReturn.PatientOwnDrugReturnDetails = new Array<PatientOwnDrugReturnDetail>();

        let details: Array<PatientOwnDrugReturnDetail> = await DrugReturnActionService.GetReturnableOwnDetails(this.EpisodeID);
        for (let detail of details) {
            let patientOwnDrugReturnDetail: PatientOwnDrugReturnDetail = detail;
            let TransactionId: Guid = <any>detail['PatientOwnDrugTrx'];
            let ownTransaction: PatientOwnDrugTrx = await this.objectContextService.getObject<PatientOwnDrugTrx>(TransactionId, PatientOwnDrugTrx.ObjectDefID);
            patientOwnDrugReturnDetail.PatientOwnDrugTrx = ownTransaction;
            let materialId: Guid = <any>detail['Material'];
            let material: Material = await this.objectContextService.getObject<Material>(materialId, Material.ObjectDefID);
            patientOwnDrugReturnDetail.Material = material;
            this.patientOwnDrugReturnFormViewModel.PatientOwnDrugReturnDetailsGridList.push(patientOwnDrugReturnDetail);
            this.patientOwnDrugReturnFormViewModel._PatientOwnDrugReturn.PatientOwnDrugReturnDetails.push(patientOwnDrugReturnDetail);
        }
    }

    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PatientOwnDrugReturn();
        this.patientOwnDrugReturnFormViewModel = new PatientOwnDrugReturnFormViewModel();
        this._ViewModel = this.patientOwnDrugReturnFormViewModel;
        this.patientOwnDrugReturnFormViewModel._PatientOwnDrugReturn = this._TTObject as PatientOwnDrugReturn;
        this.patientOwnDrugReturnFormViewModel._PatientOwnDrugReturn.PatientOwnDrugReturnDetails = new Array<PatientOwnDrugReturnDetail>();
        this.patientOwnDrugReturnFormViewModel._PatientOwnDrugReturn.Episode = new Episode();
        this.patientOwnDrugReturnFormViewModel._PatientOwnDrugReturn.Episode.Patient = new Patient();
    }

    protected loadViewModel() {
        let that = this;
        that.patientOwnDrugReturnFormViewModel = this._ViewModel as PatientOwnDrugReturnFormViewModel;
        that._TTObject = this.patientOwnDrugReturnFormViewModel._PatientOwnDrugReturn;
        if (this.patientOwnDrugReturnFormViewModel == null)
            this.patientOwnDrugReturnFormViewModel = new PatientOwnDrugReturnFormViewModel();
        if (this.patientOwnDrugReturnFormViewModel._PatientOwnDrugReturn == null)
            this.patientOwnDrugReturnFormViewModel._PatientOwnDrugReturn = new PatientOwnDrugReturn();
        that.patientOwnDrugReturnFormViewModel._PatientOwnDrugReturn.PatientOwnDrugReturnDetails = that.patientOwnDrugReturnFormViewModel.PatientOwnDrugReturnDetailsGridList;
        for (let detailItem of that.patientOwnDrugReturnFormViewModel.PatientOwnDrugReturnDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.patientOwnDrugReturnFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }
        }

        let episodeObjectID = that.patientOwnDrugReturnFormViewModel._PatientOwnDrugReturn['Episode'];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.patientOwnDrugReturnFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.patientOwnDrugReturnFormViewModel._PatientOwnDrugReturn.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode['Patient'];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.patientOwnDrugReturnFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                     if (patient) {
                        episode.Patient = patient;
                    }
                }
            }
        }

    }

    async ngOnInit() {
        let that = this;
        await this.load(PatientOwnDrugReturnFormViewModel);
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
        this.MaterialPatientOwnDrugReturnDetail.Width = 300;

        this.AmountPatientOwnDrugReturnDetail = new TTVisual.TTTextBoxColumn();
        this.AmountPatientOwnDrugReturnDetail.DataMember = "Amount";
        this.AmountPatientOwnDrugReturnDetail.DisplayIndex = 1;
        this.AmountPatientOwnDrugReturnDetail.HeaderText = "Miktar";
        this.AmountPatientOwnDrugReturnDetail.Name = "AmountPatientOwnDrugReturnDetail";
        this.AmountPatientOwnDrugReturnDetail.Width = 80;

        this.labelID = new TTVisual.TTLabel();
        this.labelID.Text = "İşlem Nu.";
        this.labelID.Name = "labelID";
        this.labelID.TabIndex = 3;

        this.ID = new TTVisual.TTTextBox();
        this.ID.Name = "ID";
        this.ID.TabIndex = 2;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = "İşlem Tarihi";
        this.labelActionDate.Name = "labelActionDate";
        this.labelActionDate.TabIndex = 1;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 0;

        this.PatientOwnDrugReturnDetailsColumns = [this.MaterialPatientOwnDrugReturnDetail, this.AmountPatientOwnDrugReturnDetail];
        this.Controls = [this.PatientOwnDrugReturnDetails, this.MaterialPatientOwnDrugReturnDetail, this.AmountPatientOwnDrugReturnDetail, this.labelID, this.ID, this.labelActionDate, this.ActionDate];

    }


}
