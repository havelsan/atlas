//$DB4CDF1B
import { Component, OnInit, NgZone } from '@angular/core';
import { DirectMaterialSupplyCancelledFormViewModel } from './DirectMaterialSupplyCancelledFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseDirectMaterialSupplyForm } from "Modules/Saglik_Lojistik/Satinalma_Modulleri/F_Dogrudan_Temin_Modulleri/BaseDirectMaterialSupplyForm";
import { DirectMaterialSupplyAction } from 'NebulaClient/Model/AtlasClientModel';
import { BaseTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'DirectMaterialSupplyCancelledForm',
    templateUrl: './DirectMaterialSupplyCancelledForm.html',
    providers: [MessageService]
})
export class DirectMaterialSupplyCancelledForm extends BaseDirectMaterialSupplyForm implements OnInit {
    public TreatmentMaterialsColumns = [];
    public directMaterialSupplyCancelledFormViewModel: DirectMaterialSupplyCancelledFormViewModel = new DirectMaterialSupplyCancelledFormViewModel();
    public get _DirectMaterialSupplyAction(): DirectMaterialSupplyAction {
        return this._TTObject as DirectMaterialSupplyAction;
    }
    private DirectMaterialSupplyCancelledForm_DocumentUrl: string = '/api/DirectMaterialSupplyActionService/DirectMaterialSupplyCancelledForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.DirectMaterialSupplyCancelledForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

     protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();

    }

    onXXXXXXKayitIdChanged(data: any){}
    onXXXXXXMesajChanged(data: any){}
    XXXXXXKayitId;
    XXXXXXMesaj;
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DirectMaterialSupplyAction();
        this.directMaterialSupplyCancelledFormViewModel = new DirectMaterialSupplyCancelledFormViewModel();
        this._ViewModel = this.directMaterialSupplyCancelledFormViewModel;
        this.directMaterialSupplyCancelledFormViewModel._DirectMaterialSupplyAction = this._TTObject as DirectMaterialSupplyAction;
        this.directMaterialSupplyCancelledFormViewModel._DirectMaterialSupplyAction.DestinationStore = new Store();
        this.directMaterialSupplyCancelledFormViewModel._DirectMaterialSupplyAction.Episode = new Episode();
        this.directMaterialSupplyCancelledFormViewModel._DirectMaterialSupplyAction.Episode.Patient = new Patient();
        this.directMaterialSupplyCancelledFormViewModel._DirectMaterialSupplyAction.ProcedureByUser = new ResUser();
        this.directMaterialSupplyCancelledFormViewModel._DirectMaterialSupplyAction.Store = new Store();
        this.directMaterialSupplyCancelledFormViewModel._DirectMaterialSupplyAction.TreatmentMaterials = new Array<BaseTreatmentMaterial>();
    }

    protected loadViewModel() {
        let that = this;

        that.directMaterialSupplyCancelledFormViewModel = this._ViewModel as DirectMaterialSupplyCancelledFormViewModel;
        that._TTObject = this.directMaterialSupplyCancelledFormViewModel._DirectMaterialSupplyAction;
        if (this.directMaterialSupplyCancelledFormViewModel == null)
            this.directMaterialSupplyCancelledFormViewModel = new DirectMaterialSupplyCancelledFormViewModel();
        if (this.directMaterialSupplyCancelledFormViewModel._DirectMaterialSupplyAction == null)
            this.directMaterialSupplyCancelledFormViewModel._DirectMaterialSupplyAction = new DirectMaterialSupplyAction();
        let destinationStoreObjectID = that.directMaterialSupplyCancelledFormViewModel._DirectMaterialSupplyAction["DestinationStore"];
        if (destinationStoreObjectID != null && (typeof destinationStoreObjectID === 'string')) {
            let destinationStore = that.directMaterialSupplyCancelledFormViewModel.Stores.find(o => o.ObjectID.toString() === destinationStoreObjectID.toString());
             if (destinationStore) {
                that.directMaterialSupplyCancelledFormViewModel._DirectMaterialSupplyAction.DestinationStore = destinationStore;
            }
        }
        let episodeObjectID = that.directMaterialSupplyCancelledFormViewModel._DirectMaterialSupplyAction["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.directMaterialSupplyCancelledFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.directMaterialSupplyCancelledFormViewModel._DirectMaterialSupplyAction.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.directMaterialSupplyCancelledFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                     if (patient) {
                        episode.Patient = patient;
                    }
                }
            }
        }
        let procedureByUserObjectID = that.directMaterialSupplyCancelledFormViewModel._DirectMaterialSupplyAction["ProcedureByUser"];
        if (procedureByUserObjectID != null && (typeof procedureByUserObjectID === 'string')) {
            let procedureByUser = that.directMaterialSupplyCancelledFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureByUserObjectID.toString());
             if (procedureByUser) {
                that.directMaterialSupplyCancelledFormViewModel._DirectMaterialSupplyAction.ProcedureByUser = procedureByUser;
            }
        }
        let storeObjectID = that.directMaterialSupplyCancelledFormViewModel._DirectMaterialSupplyAction["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.directMaterialSupplyCancelledFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
             if (store) {
                that.directMaterialSupplyCancelledFormViewModel._DirectMaterialSupplyAction.Store = store;
            }
        }
        that.directMaterialSupplyCancelledFormViewModel._DirectMaterialSupplyAction.TreatmentMaterials = that.directMaterialSupplyCancelledFormViewModel.TreatmentMaterialsGridList;
        for (let detailItem of that.directMaterialSupplyCancelledFormViewModel.TreatmentMaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.directMaterialSupplyCancelledFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(DirectMaterialSupplyCancelledFormViewModel);
  
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
        this.IsImmediate.Title = "Acil";
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
        this.TreatmentMaterials.AllowUserToAddRows = false;
        this.TreatmentMaterials.AllowUserToDeleteRows = false;
        this.TreatmentMaterials.Height = 350;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.ListDefName = "TreatmentMaterialListDefinition";
        this.Material.DataMember = "Material";
        this.Material.DisplayIndex = 0;
        this.Material.HeaderText = i18n("M18545", "Malzeme");
        this.Material.Name = "Material";
        this.Material.Width = 400;

        this.AmountBaseTreatmentMaterial = new TTVisual.TTTextBoxColumn();
        this.AmountBaseTreatmentMaterial.DataMember = "Amount";
        this.AmountBaseTreatmentMaterial.DisplayIndex = 1;
        this.AmountBaseTreatmentMaterial.HeaderText = i18n("M19030", "Miktar");
        this.AmountBaseTreatmentMaterial.Name = "AmountBaseTreatmentMaterial";
        this.AmountBaseTreatmentMaterial.Width = 120;
        this.AmountBaseTreatmentMaterial.IsNumeric = true;

        this.Note = new TTVisual.TTTextBoxColumn();
        this.Note.DataMember = "Note";
        this.Note.DisplayIndex = 2;
        this.Note.HeaderText = i18n("M10469", "Açıklama");
        this.Note.Name = "Note";
        this.Note.Width = 400;

        this.TreatmentMaterialsColumns = [this.Material, this.AmountBaseTreatmentMaterial, this.Note];
        this.ttgroupbox1.Controls = [this.TreatmentMaterials];
        this.Controls = [this.labelDateOfSurgery, this.DateOfSurgery, this.labelDestinationStore, this.DestinationStore, this.labelActionDate, this.ActionDate, this.IsImmediate, this.labelDateOfSupply, this.DateOfSupply, this.labelDescriptionForWorkList, this.DescriptionForWorkList, this.labelPatientEpisode, this.PatientEpisode, this.labelProcedureByUser, this.ProcedureByUser, this.labelStore, this.Store, this.ttgroupbox1, this.TreatmentMaterials, this.Material, this.AmountBaseTreatmentMaterial, this.Note];
        for (let control of this.Controls) {
            control.ReadOnly = true;
            control.Enabled = false;
        }
    }


}
