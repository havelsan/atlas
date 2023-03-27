//$DFBA562F
import { Component, OnInit, NgZone } from '@angular/core';
import { DirectMaterialSupplyNewFormViewModel } from './DirectMaterialSupplyNewFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseDirectMaterialSupplyForm } from "Modules/Saglik_Lojistik/Satinalma_Modulleri/F_Dogrudan_Temin_Modulleri/BaseDirectMaterialSupplyForm";
import { DirectMaterialSupplyAction } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { BaseTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';

import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'DirectMaterialSupplyNewForm',
    templateUrl: './DirectMaterialSupplyNewForm.html',
    providers: [MessageService]
})
export class DirectMaterialSupplyNewForm extends BaseDirectMaterialSupplyForm implements OnInit {
    public TreatmentMaterialsColumns = [];
    public directMaterialSupplyNewFormViewModel: DirectMaterialSupplyNewFormViewModel = new DirectMaterialSupplyNewFormViewModel();
    public get _DirectMaterialSupplyAction(): DirectMaterialSupplyAction {
        return this._TTObject as DirectMaterialSupplyAction;
    }
    private DirectMaterialSupplyNewForm_DocumentUrl: string = '/api/DirectMaterialSupplyActionService/DirectMaterialSupplyNewForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.DirectMaterialSupplyNewForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    // ***** Method declarations start *****

   /* protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);
        if (transDef !== null) {
            if (transDef.ToStateDefID === DirectMaterialSupplyAction.DirectMaterialSupplyActionStates.Request) {
                this._DirectMaterialSupplyAction.Send22F_SupplyRequestToXXXXXX(this._DirectMaterialSupplyAction);
            }
        }
        this._DirectMaterialSupplyAction.ObjectContext.Save();
    }*/
    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();

/*
        let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        mSelectForm.AddMSItem("Boş", "Boş", SupplyRequestTypeEnum.None);
        //mSelectForm.AddMSItem("İlaç", "İlaç", SupplyRequestTypeEnum.Ilac);
        mSelectForm.AddMSItem("Sarf Malzeme", "Sarf Malzeme", SupplyRequestTypeEnum.sarfMalzeme);
        mSelectForm.AddMSItem("Demirbaş", "Demirbaş", SupplyRequestTypeEnum.demirbas);
        let mkey: string = await mSelectForm.GetMSItem(this, "Malzeme türünü seçiniz. ", true);
        if (String.isNullOrEmpty(mkey))
            throw new TTException((await SystemMessageService.GetMessageV2(369, "Malzeme türünü seçmeden işleme devam edemezsiniz.")));
        this._DirectMaterialSupplyAction.RequestType = <SupplyRequestTypeEnum>mSelectForm.MSSelectedItemObject;
        if (this._DirectMaterialSupplyAction.RequestType === SupplyRequestTypeEnum.demirbas || this._DirectMaterialSupplyAction.RequestType === SupplyRequestTypeEnum.Ilac || this._DirectMaterialSupplyAction.RequestType === SupplyRequestTypeEnum.sarfMalzeme) {
            if (this._DirectMaterialSupplyAction.RequestType === SupplyRequestTypeEnum.demirbas)
                this.Material.ListFilterExpression = "OBJECTDEFID ='f38f2111-0ee4-4b9f-9707-a63ac02d29f4'  AND  MKYSMALZEMEKODU IS NOT NULL";
            //if (this._DirectMaterialSupplyAction.RequestType === SupplyRequestTypeEnum.Ilac)
            //    this.Material.ListFilterExpression = 'OBJECTDEFID =\'65a2337c-bc3c-4c6b-9575-ad47fa7a9a89\'';
            if (this._DirectMaterialSupplyAction.RequestType === SupplyRequestTypeEnum.sarfMalzeme)
                this.Material.ListFilterExpression = "OBJECTDEFID ='58d34696-808e-47de-87e0-1f001d0928a7'  AND  MKYSMALZEMEKODU IS NOT NULL";
        }
*/
if (this._DirectMaterialSupplyAction.RequestType == null)
                this.Material.ListFilterExpression = "OBJECTDEFID ='58d34696-808e-47de-87e0-1f001d0928a7'  AND  MKYSMALZEMEKODU IS NOT NULL";

       /* if (this._DirectMaterialSupplyAction.MasterResource.Store !== null) {
            this._DirectMaterialSupplyAction.Store = this._DirectMaterialSupplyAction.MasterResource.Store;
        }

        else {
            throw new TTException(this._DirectMaterialSupplyAction.MasterResource.Store.Name + " biriminin bağlı olduğu depo bilgisine ulaşılamadı.");
        }*/
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DirectMaterialSupplyAction();
        this.directMaterialSupplyNewFormViewModel = new DirectMaterialSupplyNewFormViewModel();
        this._ViewModel = this.directMaterialSupplyNewFormViewModel;
        this.directMaterialSupplyNewFormViewModel._DirectMaterialSupplyAction = this._TTObject as DirectMaterialSupplyAction;
        this.directMaterialSupplyNewFormViewModel._DirectMaterialSupplyAction.DestinationStore = new Store();
        this.directMaterialSupplyNewFormViewModel._DirectMaterialSupplyAction.Episode = new Episode();
        this.directMaterialSupplyNewFormViewModel._DirectMaterialSupplyAction.Episode.Patient = new Patient();
        this.directMaterialSupplyNewFormViewModel._DirectMaterialSupplyAction.ProcedureByUser = new ResUser();
        this.directMaterialSupplyNewFormViewModel._DirectMaterialSupplyAction.Store = new Store();
        this.directMaterialSupplyNewFormViewModel._DirectMaterialSupplyAction.TreatmentMaterials = new Array<BaseTreatmentMaterial>();
    }

    protected loadViewModel() {
        let that = this;

        that.directMaterialSupplyNewFormViewModel = this._ViewModel as DirectMaterialSupplyNewFormViewModel;
        that._TTObject = this.directMaterialSupplyNewFormViewModel._DirectMaterialSupplyAction;
        if (this.directMaterialSupplyNewFormViewModel == null)
            this.directMaterialSupplyNewFormViewModel = new DirectMaterialSupplyNewFormViewModel();
        if (this.directMaterialSupplyNewFormViewModel._DirectMaterialSupplyAction == null)
            this.directMaterialSupplyNewFormViewModel._DirectMaterialSupplyAction = new DirectMaterialSupplyAction();
        let destinationStoreObjectID = that.directMaterialSupplyNewFormViewModel._DirectMaterialSupplyAction["DestinationStore"];
        if (destinationStoreObjectID != null && (typeof destinationStoreObjectID === 'string')) {
            let destinationStore = that.directMaterialSupplyNewFormViewModel.Stores.find(o => o.ObjectID.toString() === destinationStoreObjectID.toString());
             if (destinationStore) {
                that.directMaterialSupplyNewFormViewModel._DirectMaterialSupplyAction.DestinationStore = destinationStore;
            }
        }
        let episodeObjectID = that.directMaterialSupplyNewFormViewModel._DirectMaterialSupplyAction["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.directMaterialSupplyNewFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.directMaterialSupplyNewFormViewModel._DirectMaterialSupplyAction.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.directMaterialSupplyNewFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                     if (patient) {
                        episode.Patient = patient;
                    }
                }
            }
        }
        let procedureByUserObjectID = that.directMaterialSupplyNewFormViewModel._DirectMaterialSupplyAction["ProcedureByUser"];
        if (procedureByUserObjectID != null && (typeof procedureByUserObjectID === 'string')) {
            let procedureByUser = that.directMaterialSupplyNewFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureByUserObjectID.toString());
             if (procedureByUser) {
                that.directMaterialSupplyNewFormViewModel._DirectMaterialSupplyAction.ProcedureByUser = procedureByUser;
            }
        }
        let storeObjectID = that.directMaterialSupplyNewFormViewModel._DirectMaterialSupplyAction["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.directMaterialSupplyNewFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
             if (store) {
                that.directMaterialSupplyNewFormViewModel._DirectMaterialSupplyAction.Store = store;
            }
        }
        that.directMaterialSupplyNewFormViewModel._DirectMaterialSupplyAction.TreatmentMaterials = that.directMaterialSupplyNewFormViewModel.TreatmentMaterialsGridList;
        for (let detailItem of that.directMaterialSupplyNewFormViewModel.TreatmentMaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.directMaterialSupplyNewFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(DirectMaterialSupplyNewFormViewModel);
  
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
        redirectProperty(this.Store, "Value", this.__ttObject, "Store");
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
        this.TreatmentMaterials.Height = 350;
        this.TreatmentMaterials.AllowUserToAddRows = false;
        this.TreatmentMaterials.AllowUserToDeleteRows = false;

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

    }


}
