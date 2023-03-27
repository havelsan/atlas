//$9FF938A8
import { Component, OnInit, NgZone } from '@angular/core';
import { InpatientAdmissinDepositMaterialFormViewModel, DepositComponentInfoViewModel} from './InpatientAdmissinDepositMaterialFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { InpatientAdmissionDepositMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { QueryParams } from 'app/QueryList/Models/QueryParams';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { FormSaveInfo } from 'app/NebulaClient/Mscorlib/FormSaveInfo';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';


@Component({
    selector: 'InpatientAdmissinDepositMaterialForm',
    templateUrl: './InpatientAdmissinDepositMaterialForm.html',
    providers: [MessageService]
})
export class InpatientAdmissinDepositMaterialForm extends TTVisual.TTForm implements OnInit {
    Description: TTVisual.ITTTextBox;
    labelDescription: TTVisual.ITTLabel;
    labelProcessDate: TTVisual.ITTLabel;
    labelProcessUser: TTVisual.ITTLabel;
    labelQuarantineProcessType: TTVisual.ITTLabel;
    ProcessDate: TTVisual.ITTDateTimePicker;
    ProcessUser: TTVisual.ITTObjectListBox;
    QuarantineProcessType: TTVisual.ITTEnumComboBox;
    public inpatientAdmissinDepositMaterialFormViewModel: InpatientAdmissinDepositMaterialFormViewModel = new InpatientAdmissinDepositMaterialFormViewModel();
    public get _InpatientAdmissionDepositMaterial(): InpatientAdmissionDepositMaterial {
        return this._TTObject as InpatientAdmissionDepositMaterial;
    }
    private InpatientAdmissinDepositMaterialForm_DocumentUrl: string = '/api/InpatientAdmissionDepositMaterialService/InpatientAdmissinDepositMaterialForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('INPATIENTADMISSIONDEPOSITMATERIAL', 'InpatientAdmissinDepositMaterialForm');
        this._DocumentServiceUrl = this.InpatientAdmissinDepositMaterialForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public static getDepositInfoViewModel(episodeId: Guid): DepositComponentInfoViewModel {
        let componentInfoViewModel = new DepositComponentInfoViewModel();
        let queryParameters = new QueryParams();
        queryParameters.ObjectDefID = new Guid('a85e7f73-bf5a-4d84-a5d8-82e5d035908a');
        queryParameters.QueryDefID = new Guid('c0ba534c-f9bb-4af4-9170-50d8ea27afb4'); //InpatientAdmissionDepositMaterialFormList
        let parameters = {};
        parameters['EPISODE'] = new GuidParam(episodeId);
        queryParameters.Parameters = parameters;
        componentInfoViewModel.depositQueryParameters = queryParameters;
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'InpatientAdmissinDepositMaterialForm';
        componentInfo.ModuleName = 'YatanHastaModule';
        componentInfo.ModulePath = '/Modules/Tibbi_Surec/Yatan_Hasta_Modulu/YatanHastaModule';
        componentInfo.InputParam = new DynamicComponentInputParam(null,new ActiveIDsModel(null,episodeId,null));
        componentInfoViewModel.depositComponentInfo = componentInfo;
        return componentInfoViewModel;
    }

    public static queryResultLoaded(e: any) {

        let columns = e as Array<any>;
        for (let column of columns) {
            if (column.dataField === "PROCESSDATE") {
                column.caption = i18n("M16886", "İşlem Tarihi");
            }
            if (column.dataField === "PROCESSTYPE") {
                column.caption = i18n("M16893", "İşlem Tipi");
            }
            if (column.dataField === "DESCRIPTION") {
                column.caption = i18n("M13633", "Emanet Açıklaması");
            }
            if (column.dataField === "PROCESSUSER") {
                column.caption = i18n("M16913", "İşlemi Gerçekleştiren Kullanıcı");
            }

        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new InpatientAdmissionDepositMaterial();
        this.inpatientAdmissinDepositMaterialFormViewModel = new InpatientAdmissinDepositMaterialFormViewModel();
        this._ViewModel = this.inpatientAdmissinDepositMaterialFormViewModel;
        this.inpatientAdmissinDepositMaterialFormViewModel._InpatientAdmissionDepositMaterial = this._TTObject as InpatientAdmissionDepositMaterial;
        this.inpatientAdmissinDepositMaterialFormViewModel._InpatientAdmissionDepositMaterial.ProcessUser = new ResUser();
    }

    protected loadViewModel() {
        let that = this;

        that.inpatientAdmissinDepositMaterialFormViewModel = this._ViewModel as InpatientAdmissinDepositMaterialFormViewModel;
        that._TTObject = this.inpatientAdmissinDepositMaterialFormViewModel._InpatientAdmissionDepositMaterial;
        if (this.inpatientAdmissinDepositMaterialFormViewModel == null)
            this.inpatientAdmissinDepositMaterialFormViewModel = new InpatientAdmissinDepositMaterialFormViewModel();
        if (this.inpatientAdmissinDepositMaterialFormViewModel._InpatientAdmissionDepositMaterial == null)
            this.inpatientAdmissinDepositMaterialFormViewModel._InpatientAdmissionDepositMaterial = new InpatientAdmissionDepositMaterial();
        let processUserObjectID = that.inpatientAdmissinDepositMaterialFormViewModel._InpatientAdmissionDepositMaterial["ProcessUser"];
        if (processUserObjectID != null && (typeof processUserObjectID === 'string')) {
            let processUser = that.inpatientAdmissinDepositMaterialFormViewModel.ResUsers.find(o => o.ObjectID.toString() === processUserObjectID.toString());
             if (processUser) {
                that.inpatientAdmissinDepositMaterialFormViewModel._InpatientAdmissionDepositMaterial.ProcessUser = processUser;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(InpatientAdmissinDepositMaterialFormViewModel);
  
    }


    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmissionDepositMaterial != null && this._InpatientAdmissionDepositMaterial.Description != event) {
                this._InpatientAdmissionDepositMaterial.Description = event;
            }
        }
    }

    public onProcessDateChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmissionDepositMaterial != null && this._InpatientAdmissionDepositMaterial.ProcessDate != event) {
                this._InpatientAdmissionDepositMaterial.ProcessDate = event;
            }
        }
    }

    public onProcessUserChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmissionDepositMaterial != null && this._InpatientAdmissionDepositMaterial.ProcessUser != event) {
                this._InpatientAdmissionDepositMaterial.ProcessUser = event;
            }
        }
    }

    public onQuarantineProcessTypeChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmissionDepositMaterial != null && this._InpatientAdmissionDepositMaterial.QuarantineProcessType != event) {
                this._InpatientAdmissionDepositMaterial.QuarantineProcessType = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.QuarantineProcessType, "Value", this.__ttObject, "QuarantineProcessType");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.ProcessDate, "Value", this.__ttObject, "ProcessDate");
    }
    
    public async saveForm(saveInfo: FormSaveInfo) {
        if(this._InpatientAdmissionDepositMaterial.QuarantineProcessType == null){
            ServiceLocator.MessageService.showError("İşlem Tipi seçimi boş bırakılamaz");
            return;
        }
        await super.save(saveInfo);
    }

    public initFormControls(): void {
        this.labelProcessUser = new TTVisual.TTLabel();
        this.labelProcessUser.Text = i18n("M16912", "İşlemi Gerçekleştiren ");
        this.labelProcessUser.Name = "labelProcessUser";
        this.labelProcessUser.TabIndex = 7;

        this.ProcessUser = new TTVisual.TTObjectListBox();
        this.ProcessUser.ReadOnly = true;
        this.ProcessUser.ListDefName = "UserListDefinition";
        this.ProcessUser.Name = "ProcessUser";
        this.ProcessUser.TabIndex = 6;

        this.labelProcessDate = new TTVisual.TTLabel();
        this.labelProcessDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelProcessDate.Name = "labelProcessDate";
        this.labelProcessDate.TabIndex = 5;

        this.ProcessDate = new TTVisual.TTDateTimePicker();
        this.ProcessDate.Format = DateTimePickerFormat.Long;
        this.ProcessDate.Name = "ProcessDate";
        this.ProcessDate.TabIndex = 4;

        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = i18n("M13633", "Emanet Açıklaması");
        this.labelDescription.Name = "labelDescription";
        this.labelDescription.TabIndex = 3;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 2;
        this.Description.Height = "110px";

        this.labelQuarantineProcessType = new TTVisual.TTLabel();
        this.labelQuarantineProcessType.Text = i18n("M17263", "Karantina işlem Türü");
        this.labelQuarantineProcessType.Name = "labelQuarantineProcessType";
        this.labelQuarantineProcessType.TabIndex = 1;

        this.QuarantineProcessType = new TTVisual.TTEnumComboBox();
        this.QuarantineProcessType.DataTypeName = "QuarantineProcessTypeEnum";
        this.QuarantineProcessType.Name = "QuarantineProcessType";
        this.QuarantineProcessType.TabIndex = 0;

        this.Controls = [this.labelProcessUser, this.ProcessUser, this.labelProcessDate, this.ProcessDate, this.labelDescription, this.Description, this.labelQuarantineProcessType, this.QuarantineProcessType];

    }


}
