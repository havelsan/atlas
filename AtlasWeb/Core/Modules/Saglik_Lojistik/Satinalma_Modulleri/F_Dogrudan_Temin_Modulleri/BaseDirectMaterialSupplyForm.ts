//$0C2E7D15
import { Component, OnInit, NgZone } from '@angular/core';
import { BaseDirectMaterialSupplyFormViewModel } from './BaseDirectMaterialSupplyFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { DirectMaterialSupplyAction } from 'NebulaClient/Model/AtlasClientModel';
import { BaseTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionService, InPatientPhysicianApplication_Output } from 'Fw/Services/StockActionService';

import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'BaseDirectMaterialSupplyForm',
    templateUrl: './BaseDirectMaterialSupplyForm.html',
    providers: [MessageService]
})
export class BaseDirectMaterialSupplyForm extends TTVisual.TTForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    AmountBaseTreatmentMaterial: TTVisual.ITTTextBoxColumn;
    DateOfSupply: TTVisual.ITTDateTimePicker;
    DateOfSurgery: TTVisual.ITTDateTimePicker;
    DescriptionForWorkList: TTVisual.ITTTextBox;
    DestinationStore: TTVisual.ITTObjectListBox;
    IsImmediate: TTVisual.ITTCheckBox;
    labelActionDate: TTVisual.ITTLabel;
    labelDateOfSupply: TTVisual.ITTLabel;
    labelDateOfSurgery: TTVisual.ITTLabel;
    labelDescriptionForWorkList: TTVisual.ITTLabel;
    labelDestinationStore: TTVisual.ITTLabel;
    labelPatientEpisode: TTVisual.ITTLabel;
    labelProcedureByUser: TTVisual.ITTLabel;
    labelStore: TTVisual.ITTLabel;
    Material: TTVisual.ITTListBoxColumn;
    Note: TTVisual.ITTTextBoxColumn;
    PatientEpisode: TTVisual.ITTObjectListBox;
    ProcedureByUser: TTVisual.ITTObjectListBox;
    Store: TTVisual.ITTObjectListBox;
    TreatmentMaterials: TTVisual.ITTGrid;
    ttgroupbox1: TTVisual.ITTGroupBox;

    public clinicName: string;
    public clinicRoom: string;
    public clinicBed: string;
    public clinicProtocolNo: string;
    public clinicDischargeDate: Date;
    public hasPhysicianApplication: boolean = true;

    public TreatmentMaterialsColumns = [];
    public baseDirectMaterialSupplyFormViewModel: BaseDirectMaterialSupplyFormViewModel = new BaseDirectMaterialSupplyFormViewModel();
    public get _DirectMaterialSupplyAction(): DirectMaterialSupplyAction {
        return this._TTObject as DirectMaterialSupplyAction;
    }
    private BaseDirectMaterialSupplyForm_DocumentUrl: string = '/api/DirectMaterialSupplyActionService/BaseDirectMaterialSupplyForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('DIRECTMATERIALSUPPLYACTION', 'BaseDirectMaterialSupplyForm');
        this._DocumentServiceUrl = this.BaseDirectMaterialSupplyForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();


        let output: InPatientPhysicianApplication_Output = await StockActionService.GetInPatientPhysicianApplication_InfoByEpisode(this._DirectMaterialSupplyAction.Episode.ObjectID.toString());

        if (output != null) {
            this.hasPhysicianApplication = true;
            this.clinicProtocolNo = output.clinicProtocolNo;
            this.clinicBed = output.clinicBed;
            this.clinicRoom = output.clinicRoom;
            this.clinicName = output.clinicName;
            this.clinicDischargeDate = output.clinicDischargeDate;
        }
        else {
            this.hasPhysicianApplication = false;
        }

    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DirectMaterialSupplyAction();
        this.baseDirectMaterialSupplyFormViewModel = new BaseDirectMaterialSupplyFormViewModel();
        this._ViewModel = this.baseDirectMaterialSupplyFormViewModel;
        this.baseDirectMaterialSupplyFormViewModel._DirectMaterialSupplyAction = this._TTObject as DirectMaterialSupplyAction;
        this.baseDirectMaterialSupplyFormViewModel._DirectMaterialSupplyAction.DestinationStore = new Store();
        this.baseDirectMaterialSupplyFormViewModel._DirectMaterialSupplyAction.Episode = new Episode();
        this.baseDirectMaterialSupplyFormViewModel._DirectMaterialSupplyAction.Episode.Patient = new Patient();
        this.baseDirectMaterialSupplyFormViewModel._DirectMaterialSupplyAction.ProcedureByUser = new ResUser();
        this.baseDirectMaterialSupplyFormViewModel._DirectMaterialSupplyAction.Store = new Store();
        this.baseDirectMaterialSupplyFormViewModel._DirectMaterialSupplyAction.TreatmentMaterials = new Array<BaseTreatmentMaterial>();
    }

    protected loadViewModel() {
        let that = this;

        that.baseDirectMaterialSupplyFormViewModel = this._ViewModel as BaseDirectMaterialSupplyFormViewModel;
        that._TTObject = this.baseDirectMaterialSupplyFormViewModel._DirectMaterialSupplyAction;
        if (this.baseDirectMaterialSupplyFormViewModel == null)
            this.baseDirectMaterialSupplyFormViewModel = new BaseDirectMaterialSupplyFormViewModel();
        if (this.baseDirectMaterialSupplyFormViewModel._DirectMaterialSupplyAction == null)
            this.baseDirectMaterialSupplyFormViewModel._DirectMaterialSupplyAction = new DirectMaterialSupplyAction();
        let destinationStoreObjectID = that.baseDirectMaterialSupplyFormViewModel._DirectMaterialSupplyAction["DestinationStore"];
        if (destinationStoreObjectID != null && (typeof destinationStoreObjectID === 'string')) {
            let destinationStore = that.baseDirectMaterialSupplyFormViewModel.Stores.find(o => o.ObjectID.toString() === destinationStoreObjectID.toString());
             if (destinationStore) {
                that.baseDirectMaterialSupplyFormViewModel._DirectMaterialSupplyAction.DestinationStore = destinationStore;
            }
        }
        let episodeObjectID = that.baseDirectMaterialSupplyFormViewModel._DirectMaterialSupplyAction["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.baseDirectMaterialSupplyFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.baseDirectMaterialSupplyFormViewModel._DirectMaterialSupplyAction.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.baseDirectMaterialSupplyFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                     if (patient) {
                        episode.Patient = patient;
                    }
                }
            }
        }
        let procedureByUserObjectID = that.baseDirectMaterialSupplyFormViewModel._DirectMaterialSupplyAction["ProcedureByUser"];
        if (procedureByUserObjectID != null && (typeof procedureByUserObjectID === 'string')) {
            let procedureByUser = that.baseDirectMaterialSupplyFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureByUserObjectID.toString());
             if (procedureByUser) {
                that.baseDirectMaterialSupplyFormViewModel._DirectMaterialSupplyAction.ProcedureByUser = procedureByUser;
            }
        }
        let storeObjectID = that.baseDirectMaterialSupplyFormViewModel._DirectMaterialSupplyAction["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.baseDirectMaterialSupplyFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
             if (store) {
                that.baseDirectMaterialSupplyFormViewModel._DirectMaterialSupplyAction.Store = store;
            }
        }
        that.baseDirectMaterialSupplyFormViewModel._DirectMaterialSupplyAction.TreatmentMaterials = that.baseDirectMaterialSupplyFormViewModel.TreatmentMaterialsGridList;
        for (let detailItem of that.baseDirectMaterialSupplyFormViewModel.TreatmentMaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.baseDirectMaterialSupplyFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(BaseDirectMaterialSupplyFormViewModel);
  
    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._DirectMaterialSupplyAction != null && this._DirectMaterialSupplyAction.ActionDate != event) {
                this._DirectMaterialSupplyAction.ActionDate = event;
            }
        }
    }

    public onDateOfSupplyChanged(event): void {
        if (event != null) {
            if (this._DirectMaterialSupplyAction != null && this._DirectMaterialSupplyAction.DateOfSupply != event) {
                this._DirectMaterialSupplyAction.DateOfSupply = event;
            }
        }
    }

    public onDateOfSurgeryChanged(event): void {
        if (event != null) {
            if (this._DirectMaterialSupplyAction != null && this._DirectMaterialSupplyAction.DateOfSurgery != event) {
                this._DirectMaterialSupplyAction.DateOfSurgery = event;
            }
        }
    }

    public onDescriptionForWorkListChanged(event): void {
        if (event != null) {
            if (this._DirectMaterialSupplyAction != null && this._DirectMaterialSupplyAction.DescriptionForWorkList != event) {
                this._DirectMaterialSupplyAction.DescriptionForWorkList = event;
            }
        }
    }

    public onDestinationStoreChanged(event): void {
        if (event != null) {
            if (this._DirectMaterialSupplyAction != null && this._DirectMaterialSupplyAction.DestinationStore != event) {
                this._DirectMaterialSupplyAction.DestinationStore = event;
            }
        }
    }

    public onIsImmediateChanged(event): void {
        if (event != null) {
            if (this._DirectMaterialSupplyAction != null && this._DirectMaterialSupplyAction.IsImmediate != event) {
                this._DirectMaterialSupplyAction.IsImmediate = event;
            }
        }
    }

    public onPatientEpisodeChanged(event): void {
        if (event != null) {
            if (this._DirectMaterialSupplyAction != null &&
                this._DirectMaterialSupplyAction.Episode != null && this._DirectMaterialSupplyAction.Episode.Patient != event) {
                this._DirectMaterialSupplyAction.Episode.Patient = event;
            }
        }
    }

    public onProcedureByUserChanged(event): void {
        if (event != null) {
            if (this._DirectMaterialSupplyAction != null && this._DirectMaterialSupplyAction.ProcedureByUser != event) {
                this._DirectMaterialSupplyAction.ProcedureByUser = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._DirectMaterialSupplyAction != null && this._DirectMaterialSupplyAction.Store != event) {
                this._DirectMaterialSupplyAction.Store = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.DateOfSupply, "Value", this.__ttObject, "DateOfSupply");
        redirectProperty(this.DateOfSurgery, "Value", this.__ttObject, "DateOfSurgery");
        redirectProperty(this.DescriptionForWorkList, "Text", this.__ttObject, "DescriptionForWorkList");
        redirectProperty(this.IsImmediate, "Value", this.__ttObject, "IsImmediate");
    }

    public initFormControls(): void {
        this.labelDateOfSurgery = new TTVisual.TTLabel();
        this.labelDateOfSurgery.Text = i18n("M10847", "Ameliyat Tarihi");
        this.labelDateOfSurgery.Name = "labelDateOfSurgery";
        this.labelDateOfSurgery.TabIndex = 17;

        this.DateOfSurgery = new TTVisual.TTDateTimePicker();
        this.DateOfSurgery.Format = DateTimePickerFormat.Long;
        this.DateOfSurgery.Name = "DateOfSurgery";
        this.DateOfSurgery.TabIndex = 16;

        this.labelDestinationStore = new TTVisual.TTLabel();
        this.labelDestinationStore.Text = i18n("M10896", "Ana Depo");
        this.labelDestinationStore.Name = "labelDestinationStore";
        this.labelDestinationStore.TabIndex = 15;

        this.DestinationStore = new TTVisual.TTObjectListBox();
        this.DestinationStore.ListDefName = "MainStoreList";
        this.DestinationStore.Name = "DestinationStore";
        this.DestinationStore.TabIndex = 14;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelActionDate.Name = "labelActionDate";
        this.labelActionDate.TabIndex = 13;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 12;

        this.IsImmediate = new TTVisual.TTCheckBox();
        this.IsImmediate.Value = false;
        this.IsImmediate.Text = "Acil";
        this.IsImmediate.Name = "IsImmediate";
        this.IsImmediate.TabIndex = 11;

        this.labelDateOfSupply = new TTVisual.TTLabel();
        this.labelDateOfSupply.Text = i18n("M17317", "Karşılanma Tarihi");
        this.labelDateOfSupply.Name = "labelDateOfSupply";
        this.labelDateOfSupply.TabIndex = 10;

        this.DateOfSupply = new TTVisual.TTDateTimePicker();
        this.DateOfSupply.Format = DateTimePickerFormat.Long;
        this.DateOfSupply.Name = "DateOfSupply";
        this.DateOfSupply.TabIndex = 9;

        this.labelDescriptionForWorkList = new TTVisual.TTLabel();
        this.labelDescriptionForWorkList.Text = i18n("M10469", "Açıklama");
        this.labelDescriptionForWorkList.Name = "labelDescriptionForWorkList";
        this.labelDescriptionForWorkList.TabIndex = 8;

        this.DescriptionForWorkList = new TTVisual.TTTextBox();
        this.DescriptionForWorkList.Multiline = true;
        this.DescriptionForWorkList.Name = "DescriptionForWorkList";
        this.DescriptionForWorkList.TabIndex = 7;

        this.labelPatientEpisode = new TTVisual.TTLabel();
        this.labelPatientEpisode.Text = i18n("M15125", "Hasta");
        this.labelPatientEpisode.Name = "labelPatientEpisode";
        this.labelPatientEpisode.TabIndex = 6;

        this.PatientEpisode = new TTVisual.TTObjectListBox();
        this.PatientEpisode.ListDefName = "PatientListDefinition";
        this.PatientEpisode.Name = "PatientEpisode";
        this.PatientEpisode.TabIndex = 5;

        this.labelProcedureByUser = new TTVisual.TTLabel();
        this.labelProcedureByUser.Text = i18n("M16666", "İstek Yapan Personel");
        this.labelProcedureByUser.Name = "labelProcedureByUser";
        this.labelProcedureByUser.TabIndex = 4;

        this.ProcedureByUser = new TTVisual.TTObjectListBox();
        this.ProcedureByUser.ListDefName = "ResUserListDefinition";
        this.ProcedureByUser.Name = "ProcedureByUser";
        this.ProcedureByUser.TabIndex = 3;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14859", "Gönderen Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 2;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ListDefName = "StoreListDefinition";
        this.Store.Name = "Store";
        this.Store.TabIndex = 1;

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = i18n("M16717", "İstenilen Malzemeler");
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 0;

        this.TreatmentMaterials = new TTVisual.TTGrid();
        this.TreatmentMaterials.Name = "TreatmentMaterials";
        this.TreatmentMaterials.TabIndex = 0;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.ListDefName = "TreatmentMaterialListDefinition";
        this.Material.DataMember = "Material";
        this.Material.DisplayIndex = 0;
        this.Material.HeaderText = i18n("M18545", "Malzeme");
        this.Material.Name = "Material";
        this.Material.Width = 300;

        this.AmountBaseTreatmentMaterial = new TTVisual.TTTextBoxColumn();
        this.AmountBaseTreatmentMaterial.DataMember = "Amount";
        this.AmountBaseTreatmentMaterial.DisplayIndex = 1;
        this.AmountBaseTreatmentMaterial.HeaderText = i18n("M19030", "Miktar");
        this.AmountBaseTreatmentMaterial.Name = "AmountBaseTreatmentMaterial";
        this.AmountBaseTreatmentMaterial.Width = 80;

        this.Note = new TTVisual.TTTextBoxColumn();
        this.Note.DataMember = "Note";
        this.Note.DisplayIndex = 2;
        this.Note.HeaderText = i18n("M10469", "Açıklama");
        this.Note.Name = "Note";
        this.Note.Width = 400;

        this.TreatmentMaterialsColumns = [this.Material, this.AmountBaseTreatmentMaterial, this.Note];
        this.ttgroupbox1.Controls = [this.TreatmentMaterials];
        this.Controls = [this.labelDateOfSurgery, this.DateOfSurgery, this.labelDestinationStore, this.DestinationStore, this.labelActionDate, this.ActionDate, this.IsImmediate, this.labelDateOfSupply, this.DateOfSupply, this.labelDescriptionForWorkList, this.DescriptionForWorkList, this.labelPatientEpisode, this.PatientEpisode, this.labelProcedureByUser, this.ProcedureByUser, this.labelStore, this.Store, this.ttgroupbox1, this.TreatmentMaterials, this.Material, this.AmountBaseTreatmentMaterial, this.Note];

    }


}
