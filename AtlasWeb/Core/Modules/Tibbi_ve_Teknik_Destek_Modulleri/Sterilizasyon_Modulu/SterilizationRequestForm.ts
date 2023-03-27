//$642F4B99
import { Component, OnInit } from '@angular/core';
import { SterilizationRequestFormViewModel } from './SterilizationRequestFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { SterilizationRequest } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SterilizationHistory } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { TTObjectStateTransitionDef } from "app/NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef";

@Component({
    selector: 'SterilizationRequestForm',
    templateUrl: './SterilizationRequestForm.html',
    providers: [MessageService]
})
export class SterilizationRequestForm extends TTVisual.TTForm implements OnInit {
    RequestDate: TTVisual.ITTDateTimePicker;
    labelRequestDate: TTVisual.ITTLabel;
    labelRequestResource: TTVisual.ITTLabel;
    labelRequestUser: TTVisual.ITTLabel;
    labelSterilizationUnit: TTVisual.ITTLabel;
    RequestResource: TTVisual.ITTObjectListBox;
    RequestUser: TTVisual.ITTObjectListBox;
    ReusableMaterialSterilizationHistory: TTVisual.ITTListBoxColumn;
    SterilizationHistories: TTVisual.ITTGrid;
    SterilizationUnit: TTVisual.ITTObjectListBox;
    public SterilizationHistoriesColumns = [];
    public sterilizationRequestFormViewModel: SterilizationRequestFormViewModel = new SterilizationRequestFormViewModel();
    public get _SterilizationRequest(): SterilizationRequest {
        return this._TTObject as SterilizationRequest;
    }
    private SterilizationRequestForm_DocumentUrl: string = '/api/SterilizationRequestService/SterilizationRequestForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('STERILIZATIONREQUEST', 'SterilizationRequestForm');
        this._DocumentServiceUrl = this.SterilizationRequestForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new SterilizationRequest();
        this.sterilizationRequestFormViewModel = new SterilizationRequestFormViewModel();
        this._ViewModel = this.sterilizationRequestFormViewModel;
        this.sterilizationRequestFormViewModel._SterilizationRequest = this._TTObject as SterilizationRequest;
        this.sterilizationRequestFormViewModel._SterilizationRequest.SterilizationUnit = new ResSection();
        this.sterilizationRequestFormViewModel._SterilizationRequest.RequestResource = new ResSection();
        this.sterilizationRequestFormViewModel._SterilizationRequest.RequestUser = new ResUser();
        this.sterilizationRequestFormViewModel._SterilizationRequest.SterilizationHistories = new Array<SterilizationHistory>();
    }

    protected loadViewModel() {
        let that = this;
        that.sterilizationRequestFormViewModel = this._ViewModel as SterilizationRequestFormViewModel;
        that._TTObject = this.sterilizationRequestFormViewModel._SterilizationRequest;
        if (this.sterilizationRequestFormViewModel == null)
            this.sterilizationRequestFormViewModel = new SterilizationRequestFormViewModel();
        if (this.sterilizationRequestFormViewModel._SterilizationRequest == null)
            this.sterilizationRequestFormViewModel._SterilizationRequest = new SterilizationRequest();
        let sterilizationUnitObjectID = that.sterilizationRequestFormViewModel._SterilizationRequest["SterilizationUnit"];
        if (sterilizationUnitObjectID != null && (typeof sterilizationUnitObjectID === "string")) {
            let sterilizationUnit = that.sterilizationRequestFormViewModel.ResSections.find(o => o.ObjectID.toString() === sterilizationUnitObjectID.toString());
            if (sterilizationUnit) {
                that.sterilizationRequestFormViewModel._SterilizationRequest.SterilizationUnit = sterilizationUnit;
            }
        }

        let requestResourceObjectID = that.sterilizationRequestFormViewModel._SterilizationRequest["RequestResource"];
        if (requestResourceObjectID != null && (typeof requestResourceObjectID === "string")) {
            let requestResource = that.sterilizationRequestFormViewModel.ResSections.find(o => o.ObjectID.toString() === requestResourceObjectID.toString());
            if (requestResource) {
                that.sterilizationRequestFormViewModel._SterilizationRequest.RequestResource = requestResource;
            }
        }


        let requestUserObjectID = that.sterilizationRequestFormViewModel._SterilizationRequest["RequestUser"];
        if (requestUserObjectID != null && (typeof requestUserObjectID === "string")) {
            let requestUser = that.sterilizationRequestFormViewModel.ResUsers.find(o => o.ObjectID.toString() === requestUserObjectID.toString());
            if (requestUser) {
                that.sterilizationRequestFormViewModel._SterilizationRequest.RequestUser = requestUser;
            }
        }


        that.sterilizationRequestFormViewModel._SterilizationRequest.SterilizationHistories = that.sterilizationRequestFormViewModel.SterilizationHistoriesGridList;
        for (let detailItem of that.sterilizationRequestFormViewModel.SterilizationHistoriesGridList) {
            let reusableMaterialObjectID = detailItem["ReusableMaterial"];
            if (reusableMaterialObjectID != null && (typeof reusableMaterialObjectID === "string")) {
                let reusableMaterial = that.sterilizationRequestFormViewModel.ResReusableMaterials.find(o => o.ObjectID.toString() === reusableMaterialObjectID.toString());
                if (reusableMaterial) {
                    detailItem.ReusableMaterial = reusableMaterial;
                }
            }

        }
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        await super.AfterContextSavedScript(transDef);

        await this.load(SterilizationRequestFormViewModel);
    }



    protected async PreScript(): Promise<void> {
        await super.PreScript();
       this.RequestResource.ListFilterExpression = this.sterilizationRequestFormViewModel.RequestResourceFilterExpression;
    }

    async ngOnInit() {
        await this.load();
    }

    public onRequestDateChanged(event): void {
        if (this._SterilizationRequest != null && this._SterilizationRequest.RequestDate != event) {
            this._SterilizationRequest.RequestDate = event;
        }
    }

    public onRequestResourceChanged(event): void {
        if (this._SterilizationRequest != null && this._SterilizationRequest.RequestResource != event) {
            this._SterilizationRequest.RequestResource = event;
        }
    }

    public onRequestUserChanged(event): void {
        if (this._SterilizationRequest != null && this._SterilizationRequest.RequestUser != event) {
            this._SterilizationRequest.RequestUser = event;
        }
    }

    public onSterilizationUnitChanged(event): void {
        if (this._SterilizationRequest != null && this._SterilizationRequest.SterilizationUnit != event) {
            this._SterilizationRequest.SterilizationUnit = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.RequestDate, "Value", this.__ttObject, "RequestDate");
    }

    public initFormControls(): void {
        this.labelSterilizationUnit = new TTVisual.TTLabel();
        this.labelSterilizationUnit.Text = "İstek Yapılan Sterilizasyon Birimi";
        this.labelSterilizationUnit.Name = "labelSterilizationUnit";
        this.labelSterilizationUnit.TabIndex = 8;

        this.SterilizationUnit = new TTVisual.TTObjectListBox();
        this.SterilizationUnit.ListDefName = "ResSterilizationUnitListDefinition";
        this.SterilizationUnit.Name = "SterilizationUnit";


        this.labelRequestResource = new TTVisual.TTLabel();
        this.labelRequestResource.Text = "İstek Yapan Birim";
        this.labelRequestResource.Name = "labelRequestResource";
        this.labelRequestResource.TabIndex = 6;

        this.RequestResource = new TTVisual.TTObjectListBox();
        this.RequestResource.ListDefName = "ResourceListDefinition";
        this.RequestResource.Name = "RequestResource";
        this.RequestResource.TabIndex = 5;

        this.labelRequestUser = new TTVisual.TTLabel();
        this.labelRequestUser.Text = "İstek Yapan Personel";
        this.labelRequestUser.Name = "labelRequestUser";
        this.labelRequestUser.TabIndex = 4;

        this.RequestUser = new TTVisual.TTObjectListBox();
        this.RequestUser.ListDefName = "ResUserListDefinition";
        this.RequestUser.Name = "RequestUser";
        this.RequestUser.TabIndex = 3;

        this.SterilizationHistories = new TTVisual.TTGrid();
        this.SterilizationHistories.Name = "SterilizationHistories";
        this.SterilizationHistories.TabIndex = 2;
        this.SterilizationHistories.Height = 300;
        this.SterilizationHistories.ShowFilterCombo = true;
        this.SterilizationHistories.FilterColumnName = "ReusableMaterialSterilizationHistory";
        this.SterilizationHistories.FilterLabel = "Malzeme";
        this.SterilizationHistories.Filter = { ListDefName: "ResUsableMaterialWithoutPackageAndClearList" };
        this.SterilizationHistories.AllowUserToAddRows = false;

        this.ReusableMaterialSterilizationHistory = new TTVisual.TTListBoxColumn();
        this.ReusableMaterialSterilizationHistory.ListDefName = "ResUsableMaterialWithoutPackageAndClearList";
        this.ReusableMaterialSterilizationHistory.DataMember = "ReusableMaterial";
        this.ReusableMaterialSterilizationHistory.DisplayIndex = 0;
        this.ReusableMaterialSterilizationHistory.HeaderText = "Malzeme";
        this.ReusableMaterialSterilizationHistory.Name = "ReusableMaterialSterilizationHistory";
        this.ReusableMaterialSterilizationHistory.Width = 300;
        this.ReusableMaterialSterilizationHistory.ReadOnly = true;

        this.labelRequestDate = new TTVisual.TTLabel();
        this.labelRequestDate.Text = "RequestDate";
        this.labelRequestDate.Name = "labelRequestDate";
        this.labelRequestDate.TabIndex = 1;

        this.RequestDate = new TTVisual.TTDateTimePicker();
        this.RequestDate.Format = DateTimePickerFormat.Long;
        this.RequestDate.Name = "İstekTarihi";
        this.RequestDate.TabIndex = 0;

        this.SterilizationHistoriesColumns = [this.ReusableMaterialSterilizationHistory];
        this.Controls = [this.labelSterilizationUnit, this.SterilizationUnit, this.labelRequestResource, this.RequestResource, this.labelRequestUser, this.RequestUser, this.SterilizationHistories, this.ReusableMaterialSterilizationHistory, this.labelRequestDate, this.RequestDate];

    }


}
